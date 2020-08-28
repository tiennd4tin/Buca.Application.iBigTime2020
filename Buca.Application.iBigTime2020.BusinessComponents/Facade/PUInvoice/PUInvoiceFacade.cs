using Buca.Application.iBigTime2020.BusinessComponents.Facade.System;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.PUInvoice;
using Buca.Application.iBigTime2020.BusinessEntities.Business.PUInvoice;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.PUInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.PUInvoice
{
    public class PUInvoiceFacade : FacadeBase
    {
        IPUInvoiceDao PUInvoiceDao = DataAccess.DataAccess.PUInvoiceDao;
        IPUInvoiceDetailFixedAssetDao PUInvoiceDetailFixedAssetDao = DataAccess.DataAccess.PUInvoiceDetailFixedAssetDao;

        public List<PUInvoiceEntity> GetPUInvoicesByRefTypeId(int refTypeId)
        {
            return PUInvoiceDao.GetPUInvoicesByRefTypeId(refTypeId);
        }
        public List<PUInvoiceEntity> GetPUInvoices()
        {
            return PUInvoiceDao.GetPUInvoices();
        }

        public PUInvoiceEntity GetPUInvoice(string refId, bool isIncludedBUTransferDetail)
        {
            var pUInvoice = PUInvoiceDao.GetPUInvoice(refId);

            if (isIncludedBUTransferDetail && pUInvoice != null)
            {
                switch (pUInvoice.RefType)
                {
                    case (int)BuCA.Enum.RefType.PUInvoiceFixedAsset:
                        pUInvoice.PUInvoiceDetailFixedAssets = PUInvoiceDetailFixedAssetDao.GetPUInvoiceDetailFixedAssets(refId);
                        break;
                }
            }
            return pUInvoice;
        }

        public PUInvoiceResponse UpdatePUInvoice(PUInvoiceEntity pUInvoice)
        {
            var pUInvoiceResponse = new PUInvoiceResponse { Acknowledge = AcknowledgeType.Success };

            if (pUInvoice != null && !pUInvoice.Validate())
            {
                foreach (var error in pUInvoice.ValidationErrors)
                    pUInvoiceResponse.Message += error + Environment.NewLine;
                pUInvoiceResponse.Acknowledge = AcknowledgeType.Failure;
                return pUInvoiceResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (pUInvoice != null)
                {
                    #region Master
                    var pUInvoiceByRefNo = PUInvoiceDao.GetPUInvoiceByRefNo(pUInvoice.RefNo, pUInvoice.PostedDate);
                    if (pUInvoiceByRefNo != null && !pUInvoiceByRefNo.RefId.Equals(pUInvoice.RefId) && pUInvoiceByRefNo.PostedDate.Year == pUInvoice.PostedDate.Year)
                    {
                        pUInvoiceResponse.Acknowledge = AcknowledgeType.Failure;
                        pUInvoiceResponse.Message = string.Format("Số chứng từ \'{0}\' đã tồn tại!", pUInvoice.RefNo);
                        return pUInvoiceResponse;
                    }

                    if (string.IsNullOrEmpty(pUInvoice.RefId))
                        pUInvoice.RefId = Guid.NewGuid().ToString();
                    else
                    {
                        // Xóa detail
                        pUInvoiceResponse.Message = PUInvoiceDetailFixedAssetDao.DeletePUInvoiceDetailFixedAssets(pUInvoice.RefId);
                        if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                            goto Error;

                        AutoMapper(DeleteGeneralLedger(pUInvoice.RefId), pUInvoiceResponse);
                        if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                            goto Error;

                        AutoMapper(DeleteOriginalLedger(pUInvoice.RefId), pUInvoiceResponse);
                        if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                            goto Error;

                        AutoMapper(DeleteFixAssetLedger(pUInvoice.RefId, pUInvoice.RefType), pUInvoiceResponse);
                        if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                            goto Error;
                    }

                    pUInvoiceResponse.Message = PUInvoiceDao.UpdatePUInvoice(pUInvoice);
                    if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                        goto Error;
                    #endregion

                    #region Detail
                    if (pUInvoice.PUInvoiceDetailFixedAssets != null && pUInvoice.PUInvoiceDetailFixedAssets.Count > 0)
                    {
                        foreach (PUInvoiceDetailFixedAssetEntity entity in pUInvoice.PUInvoiceDetailFixedAssets)
                        {
                            entity.RefDetailId = Guid.NewGuid().ToString();
                            entity.RefId = pUInvoice.RefId;
                            pUInvoiceResponse.Message = PUInvoiceDetailFixedAssetDao.UpdatePUInvoiceDetailFixedAsset(entity);
                            if (!string.IsNullOrEmpty(pUInvoiceResponse.Message)) 
                                goto Error;

                            #region General Ledger
                            AutoMapper(InsertGeneralLedger(entity, pUInvoice), pUInvoiceResponse);
                            if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                                goto Error;
                            #endregion

                            #region Original Ledger
                            AutoMapper(InsertOriginalLedger(entity, pUInvoice), pUInvoiceResponse);
                            if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                                goto Error;
                            #endregion

                            #region FixedAsset Ledger
                            if (entity.DebitAccount.StartsWith("21"))
                            {
                                AutoMapper(InsertFixAssetLedger(entity, pUInvoice), pUInvoiceResponse);
                                if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                                    goto Error;
                            }

                            #endregion
                        }
                    }
                    #endregion

                    #region Error
                    Error:
                    if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                    {
                        pUInvoiceResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return pUInvoiceResponse;
                    }
                    pUInvoiceResponse.RefId = pUInvoice.RefId;
                    scope.Complete();
                    #endregion
                }
                return pUInvoiceResponse;
            }
        }

        public PUInvoiceResponse DeletePUInvoice(string refId, int refType)
        {
            var pUInvoiceResponse = new PUInvoiceResponse { Acknowledge = AcknowledgeType.Success };

            using (var scope = new TransactionScope())
            {
                #region Delete
                pUInvoiceResponse.Message = PUInvoiceDao.DeletePUInvoice(refId);
                if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                    goto Error;

                pUInvoiceResponse.Message = PUInvoiceDetailFixedAssetDao.DeletePUInvoiceDetailFixedAssets(refId);
                if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                    goto Error;

                AutoMapper(DeleteGeneralLedger(refId), pUInvoiceResponse);
                if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                    goto Error;

                AutoMapper(DeleteOriginalLedger(refId), pUInvoiceResponse);
                if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                    goto Error;

                AutoMapper(DeleteFixAssetLedger(refId, refType), pUInvoiceResponse);
                if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                    goto Error;
                #endregion

                #region Error
                Error:
                if (!string.IsNullOrEmpty(pUInvoiceResponse.Message))
                {
                    pUInvoiceResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return pUInvoiceResponse;
                }
                pUInvoiceResponse.RefId = refId;
                scope.Complete();
                #endregion
            }
            return pUInvoiceResponse;
        }
    }
}
