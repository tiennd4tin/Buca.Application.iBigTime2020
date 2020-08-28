/***********************************************************************
 * <copyright file="BUCommitmentRequestFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 6, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 6, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Estimate
{
    /// <summary>
    /// Class BUCommitmentRequestFacade.
    /// </summary>
    public class BUCommitmentRequestFacade
    {
        /// <summary>
        /// The bu commitment request DAO
        /// </summary>
        private static readonly IBUCommitmentRequestDao BUCommitmentRequestDao = DataAccess.DataAccess.BUCommitmentRequestDao;
        private static readonly IBUCommitmentRequestDetailDao BUCommitmentRequestDetailDao = DataAccess.DataAccess.BUCommitmentRequestDetailDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;
        /// <summary>
        /// Gets the bu commitment requestby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestEntity.</returns>
        public BUCommitmentRequestEntity GetBUCommitmentRequestbyRefId(string refId)
        {
            return BUCommitmentRequestDao.GetBUCommitmentRequestbyRefId(refId);
        }
        /// <summary>
        /// Gets the bu plan receipt voucher by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedBUCommitmentRequestDetail">if set to <c>true</c> [is included bu commitment request detail].</param>
        /// <returns>BUCommitmentRequestEntity.</returns>
        public BUCommitmentRequestEntity GetBUCommitmentRequestVoucherByRefId(string refId, bool isIncludedBUCommitmentRequestDetail)
        {
            var bUCommitmentRequest = BUCommitmentRequestDao.GetBUCommitmentRequestbyRefId(refId);
            if (isIncludedBUCommitmentRequestDetail && bUCommitmentRequest != null)
            {
                bUCommitmentRequest.BUCommitmentRequestDetails = BUCommitmentRequestDetailDao.GetBUCommitmentRequestDetailbyRefId(bUCommitmentRequest.RefId);
            }
            return bUCommitmentRequest;
        }


        /// <summary>
        /// Gets the bu commitment request.
        /// </summary>
        /// <returns>List&lt;BUCommitmentRequestEntity&gt;.</returns>
        public List<BUCommitmentRequestEntity> GetBUCommitmentRequest()
        {
            return BUCommitmentRequestDao.GetBUCommitmentRequest();
        }
        /// <summary>
        /// Gets the bu commitment request.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestEntity&gt;.</returns>
        public List<BUCommitmentRequestEntity> GetBUCommitmentRequest(string refTypeId)
        {
            return BUCommitmentRequestDao.GetBUCommitmentRequest(refTypeId);
        }
        /// <summary>
        /// Gets the bu commitment requests by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestEntity&gt;.</returns>
        public List<BUCommitmentRequestEntity> GetBUCommitmentRequestsByRefTypeId(int refTypeId)
        {
            return BUCommitmentRequestDao.GetBUCommitmentRequestsByRefTypeId(refTypeId);
        }
        /// <summary>
        /// Inserts the bu commitment request.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>BUCommitmentRequestResponse.</returns>
        public BUCommitmentRequestResponse InsertBUCommitmentRequest(BUCommitmentRequestEntity bUCommitmentRequest)
        {
            var bUCommitmentRequestResponse = new BUCommitmentRequestResponse { Acknowledge = AcknowledgeType.Success };


            if (bUCommitmentRequest != null && !bUCommitmentRequest.Validate())
            {
                foreach (var error in bUCommitmentRequest.ValidationErrors)
                    bUCommitmentRequestResponse.Message += error + Environment.NewLine;
                bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                return bUCommitmentRequestResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (bUCommitmentRequest != null)
                {
                    var bUCommitmentRequestEntityExited = BUCommitmentRequestDao.GetBUCommitmentRequestByRefNo(bUCommitmentRequest.RefNo.Trim(), bUCommitmentRequest.PostedDate);
                    if (bUCommitmentRequestEntityExited != null && bUCommitmentRequestEntityExited.PostedDate.Year == bUCommitmentRequest.PostedDate.Year)
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        bUCommitmentRequestResponse.Message = @"Số chứng từ '" + bUCommitmentRequest.RefNo + @"' đã tồn tại!";
                        return bUCommitmentRequestResponse;
                    }

                    bUCommitmentRequest.RefId = Guid.NewGuid().ToString();
                    bUCommitmentRequestResponse.Message = BUCommitmentRequestDao.InsertBUCommitmentRequest(bUCommitmentRequest);

                    if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUCommitmentRequestResponse;
                    }

                    foreach (var bUCommitmentRequestDetail in bUCommitmentRequest.BUCommitmentRequestDetails)
                    {
                        bUCommitmentRequestDetail.RefId = bUCommitmentRequest.RefId;
                        bUCommitmentRequestDetail.RefDetailId = Guid.NewGuid().ToString();
                        if (!bUCommitmentRequestDetail.Validate())
                        {
                            foreach (var error in bUCommitmentRequestDetail.ValidationErrors)
                                bUCommitmentRequestResponse.Message += error + Environment.NewLine;
                            bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                            return bUCommitmentRequestResponse;
                        }
                        bUCommitmentRequestResponse.Message =
                            BUCommitmentRequestDetailDao.InsertBUPlanReceiptDetail(bUCommitmentRequestDetail);
                        if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                        {
                            bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                            return bUCommitmentRequestResponse;
                        }
                        #region Insert OriginalGeneralLedger
                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = bUCommitmentRequest.RefType,
                            RefId = bUCommitmentRequest.RefId,
                            RefDetailId = bUCommitmentRequestDetail.RefDetailId,
                            RefDate = bUCommitmentRequest.RefDate,
                            RefNo = bUCommitmentRequest.RefNo,
                            Amount = bUCommitmentRequestDetail.Amount,
                            AmountOC = bUCommitmentRequestDetail.AmountOC,
                            BudgetChapterCode = bUCommitmentRequestDetail.BudgetChapterCode,
                            BudgetDetailItemCode = bUCommitmentRequestDetail.BudgetDetailItemCode,
                            BudgetItemCode = bUCommitmentRequestDetail.BudgetItemCode,
                            BudgetKindItemCode = bUCommitmentRequestDetail.BudgetKindItemCode,
                            BudgetSourceId = bUCommitmentRequestDetail.BudgetSourceId,
                            BudgetSubItemCode = bUCommitmentRequestDetail.BudgetSubItemCode,
                            BudgetSubKindItemCode = bUCommitmentRequestDetail.BudgetSubKindItemCode,
                            Description = bUCommitmentRequestDetail.Description,
                            FundStructureId = bUCommitmentRequestDetail.FundStructureId,
                            ProjectId = bUCommitmentRequestDetail.ProjectId,
                            PostedDate = bUCommitmentRequest.PostedDate,
                            //CurrencyCode = bUCommitmentRequest.CurrencyCode,
                            //ExchangeRate = bUCommitmentRequest.ExchangeRate,
                            ContractId = bUCommitmentRequestDetail.ContractId,
                        };
                        bUCommitmentRequestResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                        if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                        {
                            bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                            return bUCommitmentRequestResponse;
                        }

                        #endregion
                    }

                    if (bUCommitmentRequestResponse.Message != null)
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUCommitmentRequestResponse;
                    }
                    bUCommitmentRequestResponse.RefId = bUCommitmentRequest.RefId;
                    scope.Complete();
                }

                return bUCommitmentRequestResponse;
            }
        }
        /// <summary>
        /// Updates the bu commitment request.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>BUCommitmentRequestResponse.</returns>
        public BUCommitmentRequestResponse UpdateBUCommitmentRequest(BUCommitmentRequestEntity bUCommitmentRequest)
        {
            var bUCommitmentRequestResponse = new BUCommitmentRequestResponse { Acknowledge = AcknowledgeType.Success };


            if (bUCommitmentRequest != null && !bUCommitmentRequest.Validate())
            {
                foreach (var error in bUCommitmentRequest.ValidationErrors)
                    bUCommitmentRequestResponse.Message += error + Environment.NewLine;
                bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                return bUCommitmentRequestResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (bUCommitmentRequest != null)
                {
                    var bUCommitmentRequestEntityExited = BUCommitmentRequestDao.GetBUCommitmentRequestByRefNo(bUCommitmentRequest.RefNo.Trim(), bUCommitmentRequest.PostedDate);
                    if (bUCommitmentRequestEntityExited != null && bUCommitmentRequest.RefId != bUCommitmentRequestEntityExited.RefId && bUCommitmentRequestEntityExited.PostedDate.Year == bUCommitmentRequest.PostedDate.Year)
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        bUCommitmentRequestResponse.Message = @"Số chứng từ '" + bUCommitmentRequest.RefNo + @"' đã tồn tại!";
                        return bUCommitmentRequestResponse;
                    }

                    bUCommitmentRequestResponse.Message = BUCommitmentRequestDao.UpdateBUCommitmentRequest(bUCommitmentRequest);

                    if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUCommitmentRequestResponse;
                    }
                    bUCommitmentRequestResponse.Message = BUCommitmentRequestDetailDao.DeleteBUCommitmentRequestDetail(bUCommitmentRequest.RefId);

                    if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUCommitmentRequestResponse;
                    }
                    bUCommitmentRequestResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bUCommitmentRequest.RefId);
                    if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUCommitmentRequestResponse;
                    }
                    foreach (var bUCommitmentRequestDetail in bUCommitmentRequest.BUCommitmentRequestDetails)
                    {
                        bUCommitmentRequestDetail.RefId = bUCommitmentRequest.RefId;
                        bUCommitmentRequestDetail.RefDetailId = Guid.NewGuid().ToString();
                        if (!bUCommitmentRequestDetail.Validate())
                        {
                            foreach (var error in bUCommitmentRequestDetail.ValidationErrors)
                                bUCommitmentRequestResponse.Message += error + Environment.NewLine;
                            bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                            return bUCommitmentRequestResponse;
                        }
                        bUCommitmentRequestResponse.Message =
                            BUCommitmentRequestDetailDao.InsertBUPlanReceiptDetail(bUCommitmentRequestDetail);
                        if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                        {
                            bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                            return bUCommitmentRequestResponse;
                        }

                        #region Insert OriginalGeneralLedger
                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = bUCommitmentRequest.RefType,
                            RefId = bUCommitmentRequest.RefId,
                            RefDetailId = bUCommitmentRequestDetail.RefDetailId,
                            RefDate = bUCommitmentRequest.RefDate,
                            RefNo = bUCommitmentRequest.RefNo,
                            Amount = bUCommitmentRequestDetail.Amount,
                            AmountOC = bUCommitmentRequestDetail.AmountOC,
                            BudgetChapterCode = bUCommitmentRequestDetail.BudgetChapterCode,
                            BudgetDetailItemCode = bUCommitmentRequestDetail.BudgetDetailItemCode,
                            BudgetItemCode = bUCommitmentRequestDetail.BudgetItemCode,
                            BudgetKindItemCode = bUCommitmentRequestDetail.BudgetKindItemCode,
                            BudgetSourceId = bUCommitmentRequestDetail.BudgetSourceId,
                            BudgetSubItemCode = bUCommitmentRequestDetail.BudgetSubItemCode,
                            BudgetSubKindItemCode = bUCommitmentRequestDetail.BudgetSubKindItemCode,
                            Description = bUCommitmentRequestDetail.Description,
                            FundStructureId = bUCommitmentRequestDetail.FundStructureId,
                            ProjectId = bUCommitmentRequestDetail.ProjectId,
                            PostedDate = bUCommitmentRequest.PostedDate,
                            //CurrencyCode = bUCommitmentRequest.CurrencyCode,
                            //ExchangeRate = bUCommitmentRequest.ExchangeRate,
                            ContractId = bUCommitmentRequestDetail.ContractId,
                        };
                        bUCommitmentRequestResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                        if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                        {
                            bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                            return bUCommitmentRequestResponse;
                        }

                        #endregion
                    }

                    if (bUCommitmentRequestResponse.Message != null)
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUCommitmentRequestResponse;
                    }
                    bUCommitmentRequestResponse.RefId = bUCommitmentRequest.RefId;
                    scope.Complete();
                }

                return bUCommitmentRequestResponse;
            }
        }
        /// <summary>
        /// Deletes the bu commitment request.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestResponse.</returns>
        public BUCommitmentRequestResponse DeleteBUCommitmentRequest(string refId)
        {
            var bUCommitmentRequestResponse = new BUCommitmentRequestResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {


                //var bUCommitmentRequestEntry = BUCommitmentRequestDao.GetBUCommitmentRequestbyRefId(refId);
                //bUCommitmentRequestResponse.Message = BUCommitmentRequestDao.DeleteBUCommitmentRequest(bUCommitmentRequestEntry);

                var bUCommitmentRequestForDelete = BUCommitmentRequestDao.GetBUCommitmentRequestbyRefId(refId);

                bUCommitmentRequestResponse.Message = BUCommitmentRequestDao.DeleteBUCommitmentRequest(bUCommitmentRequestForDelete);
                if (bUCommitmentRequestResponse.Message != null)
                {
                    bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return bUCommitmentRequestResponse;
                }
                bUCommitmentRequestResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bUCommitmentRequestForDelete.RefId);
                if (bUCommitmentRequestResponse.Message != null)
                {
                    bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return bUCommitmentRequestResponse;
                }

                scope.Complete();
            }

            return bUCommitmentRequestResponse;
        }
    }
}
