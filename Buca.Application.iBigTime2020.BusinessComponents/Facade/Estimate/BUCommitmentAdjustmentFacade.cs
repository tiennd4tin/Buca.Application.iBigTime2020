/***********************************************************************
 * <copyright file="BUCommitmentAdjustmentFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, December 11, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Estimate
{
    public class BUCommitmentAdjustmentFacade
    {
        /// <summary>
        /// The bu commitment request DAO
        /// </summary>
        private static readonly IBUCommitmentAdjustmentDao BUCommitmentAdjustmentDao = DataAccess.DataAccess.BUCommitmentAdjustmentDao;
        private static readonly IBUCommitmentAdjustmentDetailDao BUCommitmentAdjustmentDetailDao = DataAccess.DataAccess.BUCommitmentAdjustmentDetailDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;

        /// <summary>
        /// Gets the bu commitment requestby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentAdjustmentEntity.</returns>
        public BUCommitmentAdjustmentEntity GetBUCommitmentAdjustmentbyRefId(string refId)
        {
            return BUCommitmentAdjustmentDao.GetBUCommitmentAdjustmentbyRefId(refId);
        }
        /// <summary>
        /// Gets the bu plan receipt voucher by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedBUCommitmentAdjustmentDetail">if set to <c>true</c> [is included bu commitment request detail].</param>
        /// <returns>BUCommitmentAdjustmentEntity.</returns>
        public BUCommitmentAdjustmentEntity GetBUCommitmentAdjustmentVoucherByRefId(string refId, bool isIncludedBUCommitmentAdjustmentDetail)
        {
            var bUCommitmentAdjustment = BUCommitmentAdjustmentDao.GetBUCommitmentAdjustmentbyRefId(refId);
            if (isIncludedBUCommitmentAdjustmentDetail && bUCommitmentAdjustment != null)
            {
                bUCommitmentAdjustment.BUCommitmentAdjustmentDetails = BUCommitmentAdjustmentDetailDao.GetBUCommitmentAdjustmentDetailbyRefId(bUCommitmentAdjustment.RefId);
            }
            return bUCommitmentAdjustment;
        }


        /// <summary>
        /// Gets the bu commitment request.
        /// </summary>
        /// <returns>List&lt;BUCommitmentAdjustmentEntity&gt;.</returns>
        public List<BUCommitmentAdjustmentEntity> GetBUCommitmentAdjustment()
        {
            return BUCommitmentAdjustmentDao.GetBUCommitmentAdjustment();
        }
        /// <summary>
        /// Gets the bu commitment requests by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentAdjustmentEntity&gt;.</returns>
        public List<BUCommitmentAdjustmentEntity> GetBUCommitmentAdjustmentsByRefTypeId(int refTypeId)
        {
            return BUCommitmentAdjustmentDao.GetBUCommitmentAdjustmentsByRefTypeId(refTypeId);
        }
        /// <summary>
        /// Inserts the bu commitment request.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>BUCommitmentAdjustmentResponse.</returns>
        public BUCommitmentAdjustmentResponse InsertBUCommitmentAdjustment(BUCommitmentAdjustmentEntity bUCommitmentRequest)
        {
            var bUCommitmentRequestResponse = new BUCommitmentAdjustmentResponse { Acknowledge = AcknowledgeType.Success };


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
                    var bUCommitmentAdjust = BUCommitmentAdjustmentDao.GetBUCommitmentAdjustmentsByRefNo(bUCommitmentRequest.RefNo, bUCommitmentRequest.PostedDate);
                    if (bUCommitmentAdjust != null && bUCommitmentAdjust.PostedDate.Year == bUCommitmentRequest.PostedDate.Year)
                    {
                        bUCommitmentRequestResponse.Message = string.Format("Số phiếu điều chỉnh \'{0}\' đã tồn tại!", bUCommitmentRequest.RefNo);
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUCommitmentRequestResponse;
                    }

                    bUCommitmentRequest.RefId = Guid.NewGuid().ToString();
                    bUCommitmentRequestResponse.Message = BUCommitmentAdjustmentDao.InsertBUCommitmentAdjustment(bUCommitmentRequest);

                    if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUCommitmentRequestResponse;
                    }

                    foreach (var bUCommitmentRequestDetail in bUCommitmentRequest.BUCommitmentAdjustmentDetails)
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
                            BUCommitmentAdjustmentDetailDao.InsertBUCommitmentAdjustmenttDetail(bUCommitmentRequestDetail);
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
                            CurrencyCode = bUCommitmentRequest.CurrencyCode,
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
        /// <returns>BUCommitmentAdjustmentResponse.</returns>
        public BUCommitmentAdjustmentResponse UpdateBUCommitmentAdjustment(BUCommitmentAdjustmentEntity bUCommitmentRequest)
        {
            var bUCommitmentRequestResponse = new BUCommitmentAdjustmentResponse { Acknowledge = AcknowledgeType.Success };


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
                    var bUCommitmentAdjust = BUCommitmentAdjustmentDao.GetBUCommitmentAdjustmentsByRefNo(bUCommitmentRequest.RefNo, bUCommitmentRequest.PostedDate);
                    if (bUCommitmentAdjust != null && bUCommitmentRequest.RefId != bUCommitmentAdjust.RefId && bUCommitmentAdjust.PostedDate.Year == bUCommitmentRequest.PostedDate.Year)
                    {
                        bUCommitmentRequestResponse.Message = string.Format("Số phiếu điều chỉnh \'{0}\' đã tồn tại!", bUCommitmentRequest.RefNo);
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUCommitmentRequestResponse;
                    }

                    bUCommitmentRequestResponse.Message = BUCommitmentAdjustmentDao.UpdateBUCommitmentAdjustment(bUCommitmentRequest);

                    if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUCommitmentRequestResponse;
                    }

                    #region Delete OriginalGeneralLedger
                    if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUCommitmentRequestResponse;
                    }
                    bUCommitmentRequestResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bUCommitmentRequest.RefId);
                    #endregion

                    bUCommitmentRequestResponse.Message = BUCommitmentAdjustmentDetailDao.DeleteBUCommitmentAdjustmentDetail(bUCommitmentRequest.RefId);

                    if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                    {
                        bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUCommitmentRequestResponse;
                    }

                    foreach (var bUCommitmentRequestDetail in bUCommitmentRequest.BUCommitmentAdjustmentDetails)
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
                            BUCommitmentAdjustmentDetailDao.InsertBUCommitmentAdjustmenttDetail(bUCommitmentRequestDetail);
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
                            ContractId = bUCommitmentRequestDetail.ContractId,
                            CurrencyCode = bUCommitmentRequest.CurrencyCode

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
        /// <returns>BUCommitmentAdjustmentResponse.</returns>
        public BUCommitmentAdjustmentResponse DeleteBUCommitmentAdjustment(string refId)
        {
            var bUCommitmentRequestResponse = new BUCommitmentAdjustmentResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                var bUCommitmentRequestForDelete = BUCommitmentAdjustmentDao.GetBUCommitmentAdjustmentbyRefId(refId);


                bUCommitmentRequestResponse.Message = BUCommitmentAdjustmentDao.DeleteBUCommitmentAdjustment(bUCommitmentRequestForDelete);
                if (bUCommitmentRequestResponse.Message != null)
                {
                    bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return bUCommitmentRequestResponse;
                }

                #region Delete OriginalGeneralLedger
                if (!string.IsNullOrEmpty(bUCommitmentRequestResponse.Message))
                {
                    bUCommitmentRequestResponse.Acknowledge = AcknowledgeType.Failure;
                    return bUCommitmentRequestResponse;
                }
                bUCommitmentRequestResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bUCommitmentRequestForDelete.RefId);
                #endregion
                scope.Complete();
            }

            return bUCommitmentRequestResponse;
        }
    }
}
