/***********************************************************************
 * <copyright file="BudgetChapterFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class BudgetChapterFacade.
    /// </summary>
    public class BudgetChapterFacade
    {
        /// <summary>
        /// The budget chapter DAO
        /// </summary>
        private static readonly IBudgetChapterDao BudgetChapterDao = DataAccess.DataAccess.BudgetChapterDao;

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>List&lt;BudgetChapterEntity&gt;.</returns>
        public List<BudgetChapterEntity> GetBudgetChapters()
        {
            return BudgetChapterDao.GetBudgetChapters();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;BudgetChapterEntity&gt;.</returns>
        public List<BudgetChapterEntity> GetBudgetChaptersByIsActive(bool isActive)
        {
            return BudgetChapterDao.GetBudgetChaptersByActive(isActive);
        }

        /// <summary>
        /// Gets the account category by identifier.
        /// </summary>
        /// <param name="budgetChapterId">The account category identifier.</param>
        /// <returns>BudgetChapterEntity.</returns>
        public BudgetChapterEntity GetBudgetChapterById(string budgetChapterId)
        {
            return BudgetChapterDao.GetBudgetChapter(budgetChapterId);
        }

        /// <summary>
        /// Gets the budget chapter by budget chapter code.
        /// </summary>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <returns>BudgetChapterEntity.</returns>
        public BudgetChapterEntity GetBudgetChapterByBudgetChapterCode(string budgetChapterCode)
        {
            return BudgetChapterDao.GetBudgetChaptersByBudgetChapterCode(budgetChapterCode);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="budgetChapterEntity">The account category entity.</param>
        /// <returns>BudgetChapterResponse.</returns>
        public BudgetChapterResponse InsertBudgetChapter(BudgetChapterEntity budgetChapterEntity)
        {
            var response = new BudgetChapterResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetChapterEntity.Validate())
                {
                    foreach (string error in budgetChapterEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                budgetChapterEntity.BudgetChapterId = Guid.NewGuid().ToString();
                //check ma trung
                var budgetChapterEntityExited = BudgetChapterDao.GetBudgetChaptersByBudgetChapterCode(budgetChapterEntity.BudgetChapterCode);
                if (budgetChapterEntityExited != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format(@"Mã chương {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác", budgetChapterEntityExited.BudgetChapterCode);
                    return response;
                }

                response.Message = BudgetChapterDao.InsertBudgetChapter(budgetChapterEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetChapterId = budgetChapterEntity.BudgetChapterId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public BudgetChapterResponse InsertBudgetChapterConvert(BudgetChapterEntity budgetChapterEntity)
        {
            var response = new BudgetChapterResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetChapterEntity.Validate())
                {
                    foreach (string error in budgetChapterEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                budgetChapterEntity.BudgetChapterId = Guid.NewGuid().ToString();
                //check ma trung
                var budgetChapterEntityExited = BudgetChapterDao.GetBudgetChaptersByBudgetChapterCode(budgetChapterEntity.BudgetChapterCode);
                if (budgetChapterEntityExited != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format(@"Mã chương {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác", budgetChapterEntityExited.BudgetChapterCode);
                    return response;
                }

                response.Message = BudgetChapterDao.InsertBudgetChapter(budgetChapterEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetChapterId = budgetChapterEntity.BudgetChapterId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="budgetChapterEntity">The account category entity.</param>
        /// <returns>BudgetChapterResponse.</returns>
        public BudgetChapterResponse UpdateBudgetChapter(BudgetChapterEntity budgetChapterEntity)
        {
            var response = new BudgetChapterResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetChapterEntity.Validate())
                {
                    foreach (string error in budgetChapterEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                //check ma trung
                var budgetChapterEntityExited = BudgetChapterDao.GetBudgetChaptersByBudgetChapterCode(budgetChapterEntity.BudgetChapterCode);
                if (budgetChapterEntityExited != null && budgetChapterEntity.BudgetChapterCode != budgetChapterEntityExited.BudgetChapterCode)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = string.Format(@"Mã chương {0} đã tồn tại trong hệ thống. Vui lòng nhập mã khác", budgetChapterEntityExited.BudgetChapterCode);
                    return response;
                }
                response.Message = BudgetChapterDao.UpdateBudgetChapter(budgetChapterEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK_AccountingObject_BudgetChapter") ||
                        response.Message.Contains("FK_BABankTransferDetailParallel_BudgetChapter") ||
                        response.Message.Contains("FK_BADepositDetail_BudgetChapter") ||
                        response.Message.Contains("FK_BADepositDetailFixedAsset_BudgetChapter") ||
                        response.Message.Contains("FK_BADepositDetailParallel_BudgetChapter") ||
                        response.Message.Contains("FK_BADepositDetailSale_BudgetChapter") ||
                        response.Message.Contains("FK_BAWithDrawDetail_BudgetChapter") ||
                        response.Message.Contains("FK_BAWithDrawDetailFixedAsset_BudgetChapter") ||
                        response.Message.Contains("FK_BAWithDrawDetailParallel_BudgetChapter") ||
                        response.Message.Contains("FK_BAWithDrawDetailPurchase_BudgetChapter") ||
                        response.Message.Contains("FK_BUBudgetReserve_BudgetChapter") ||
                        response.Message.Contains("FK_BUCommitmentAdjustmentDetail_BudgetChapter") ||
                        response.Message.Contains("FK_BUCommitmentRequestDetail_BudgetChapter") ||
                        response.Message.Contains("FK_BUPlanAdjustmentDetail_BudgetChapter") ||
                        response.Message.Contains("FK_BUPlanWithdrawDetail_BudgetChapter") ||
                        response.Message.Contains("FK_BUTransferDetail_BudgetChapter") ||
                        response.Message.Contains("FK_BUTransferDetailFixedAsset_BudgetChapter") ||
                        response.Message.Contains("FK_BUTransferDetailParallel_BudgetChapter") ||
                        response.Message.Contains("FK_BUTransferDetailPurchase_BudgetChapter") ||
                        response.Message.Contains("FK_BUVoucherListDetailParallel_BudgetChapter") ||
                        response.Message.Contains("FK_BUVoucherListDetailTransfer_BudgetChapter") ||
                        response.Message.Contains("FK_CAPaymentDetail_BudgetChapter") ||
                        response.Message.Contains("FK_CAPaymentDetailFixedAsset_BudgetChapter") ||
                        response.Message.Contains("FK_CAPaymentDetailParallel_BudgetChapter") ||
                        response.Message.Contains("FK_CAPaymentDetailPurchase_BudgetChapter") ||
                        response.Message.Contains("FK_CAReceiptDetail_BudgetChapter") ||
                        response.Message.Contains("FK_CAReceiptDetailFixedAsset_BudgetChapter") ||
                        response.Message.Contains("FK_CAReceiptDetailParallel_BudgetChapter") ||
                        response.Message.Contains("FK_FAAdjustmentDetail_BudgetChapter") ||
                        response.Message.Contains("FK_FAIncrementDecrementDetail_BudgetChapter") ||
                        response.Message.Contains("FK_FixedAsset_BudgetChapter_BudgetChapterCode") ||
                        response.Message.Contains("FK_GLVoucherDetail_BudgetChapter") ||
                        response.Message.Contains("FK_GLVoucherDetailParallel_BudgetChapter") ||
                        response.Message.Contains("FK_INInwardOutwardDetail_BudgetChapter") ||
                        response.Message.Contains("FK_OpeningAccountEntry_BudgetChapter") ||
                        response.Message.Contains("FK_OpeningFixedAssetEntry_BudgetChapter") ||
                        response.Message.Contains("FK_OpeningInventoryEntry_BudgetChapter") ||
                        response.Message.Contains("FK_PUInvoiceDetailFixedAsset_BudgetChapter"))
                        response.Message = @"Chương " + budgetChapterEntity.BudgetChapterCode + " đã phát sinh tại các nghiệp vụ liên quan không thể sửa mã!";
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetChapterId = budgetChapterEntity.BudgetChapterId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="budgetChapterId">The account category identifier.</param>
        /// <returns>BudgetChapterResponse.</returns>
        public BudgetChapterResponse DeleteBudgetChapter(string budgetChapterId)
        {
            var response = new BudgetChapterResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var budgetChapterEntity = BudgetChapterDao.GetBudgetChapter(budgetChapterId);
                response.Message = BudgetChapterDao.DeleteBudgetChapter(budgetChapterEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK_CAPaymentDetail_BudgetChapter"))
                        response.Message = @"Chương " + budgetChapterEntity.BudgetChapterCode + " đã phát sinh nghiệp vụ ở Phiếu chi không thể xóa";
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetChapterId = budgetChapterEntity.BudgetChapterId;
                return response;
            }
            catch (SqlException sqlException)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = sqlException.Message;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public BudgetChapterResponse DeleteBudgetChapterConvert()
        {
            var response = new BudgetChapterResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
             
                response.Message = BudgetChapterDao.DeleteBudgetChapterConvert();
               
                return response;
            }
            catch (SqlException sqlException)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = sqlException.Message;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
