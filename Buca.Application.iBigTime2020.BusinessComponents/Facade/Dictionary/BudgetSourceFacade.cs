/***********************************************************************
 * <copyright file="BudgetSourceFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thurday, September 28, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class BudgetSourceFacade.
    /// </summary>
    public class BudgetSourceFacade
    {
        /// <summary>
        /// The budget source DAO
        /// </summary>
        private static readonly IBudgetSourceDao BudgetSourceDao = DataAccess.DataAccess.BudgetSourceDao;

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<BudgetSourceEntity> GetBudgetSource()
        {
            return BudgetSourceDao.GetBudgetSources();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<BudgetSourceEntity> GetBudgetSourcesByIsActive(bool isActive)
        {
            return BudgetSourceDao.GetBudgetSourcesActive();
        }

        /// <summary>
        /// Gets the account category by identifier.
        /// </summary>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <returns>
        /// AccountCategoryEntity.
        /// </returns>
        public BudgetSourceEntity GetBudgetSourceById(string budgetSourceId)
        {
            return BudgetSourceDao.GetBudgetSource(budgetSourceId);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="budgetSourceEntity">The budget source entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetSourceResponse InsertBudgetSource(BudgetSourceEntity budgetSourceEntity)
        {
            var response = new BudgetSourceResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetSourceEntity.Validate())
                {
                    foreach (string error in budgetSourceEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var budgetSource = BudgetSourceDao.GetBudgetSourcesByCode(budgetSourceEntity.BudgetSourceCode.Trim());
                if (budgetSource != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã nguồn vốn " + budgetSourceEntity.BudgetSourceCode.Trim() + @" đã tồn tại !";
                    return response;
                }

                budgetSourceEntity.BudgetSourceId = Guid.NewGuid().ToString();
                response.Message = BudgetSourceDao.InsertBudgetSource(budgetSourceEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetSourceId = budgetSourceEntity.BudgetSourceId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public BudgetSourceResponse InsertBudgetSourceConvert(BudgetSourceEntity budgetSourceEntity)
        {
            var response = new BudgetSourceResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetSourceEntity.Validate())
                {
                    foreach (string error in budgetSourceEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var budgetSource = BudgetSourceDao.GetBudgetSourcesByCode(budgetSourceEntity.BudgetSourceCode.Trim());
                if (budgetSource != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã nguồn vốn " + budgetSourceEntity.BudgetSourceCode.Trim() + @" đã tồn tại !";
                    return response;
                }

                response.Message = BudgetSourceDao.InsertBudgetSource(budgetSourceEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetSourceId = budgetSourceEntity.BudgetSourceId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }


        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="budgetSourceEntity">The budget source entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetSourceResponse UpdateBudgetSource(BudgetSourceEntity budgetSourceEntity)
        {
            var response = new BudgetSourceResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetSourceEntity.Validate())
                {
                    foreach (string error in budgetSourceEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var budgetSource = BudgetSourceDao.GetBudgetSourcesByCode(budgetSourceEntity.BudgetSourceCode.Trim());
                if (budgetSource != null)
                {
                    if (budgetSource.BudgetSourceId != budgetSourceEntity.BudgetSourceId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã nguồn vốn " + budgetSourceEntity.BudgetSourceCode.Trim() + @" đã tồn tại !";
                        return response;
                    }
                }

                response.Message = BudgetSourceDao.UpdateBudgetSource(budgetSourceEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetSourceId = budgetSourceEntity.BudgetSourceId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetSourceResponse DeleteBudgetSource(string budgetSourceId)
        {
            var response = new BudgetSourceResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var budgetSourceEntity = BudgetSourceDao.GetBudgetSource(budgetSourceId);
                response.Message = BudgetSourceDao.DeleteBudgetSource(budgetSourceEntity);

                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK_BADepositDetail_BudgetSource") ||
                        response.Message.Contains("FK_BADepositDetailFixedAsset_BudgetSource") ||
                        response.Message.Contains("FK_BADepositDetailSale_BudgetSource") ||
                        response.Message.Contains("FK_BAWithDrawDetail_BudgetSource") ||
                        response.Message.Contains("FK_BAWithDrawDetailFixedAsset_BudgetSource") ||
                        response.Message.Contains("FK_BAWithDrawDetailPurchase_BudgetSource") ||
                        response.Message.Contains("FK_BUBudgetReserveDetail_BudgetSource") ||
                        response.Message.Contains("FK_BUCommitmentAdjustmentDetail_BudgetSource") ||
                        response.Message.Contains("FK_BUCommitmentRequestDetail_BudgetSource") ||
                        response.Message.Contains("FK_BUPlanAdjustmentDetail_BudgetSource") ||
                        response.Message.Contains("FK_BUPlanReceiptDetail_BudgetSource") ||
                        response.Message.Contains("FK_BUPlanWithdrawDetail_BudgetSource") ||
                        response.Message.Contains("FK_BUTransferDetail_BudgetSource") ||
                        response.Message.Contains("FK_BUTransferDetailPurchase_BudgetSource") ||
                        response.Message.Contains("FK_CAPaymentDetail_BudgetSource") ||
                        response.Message.Contains("FK_CAPaymentDetailFixedAsset_BudgetSource") ||
                        response.Message.Contains("FK_CAPaymentDetailPurchase_BudgetSource") ||
                        response.Message.Contains("FK_CAReceiptDetail_BudgetSource") ||
                        response.Message.Contains("FK_CAReceiptDetailFixedAsset_BudgetSource") ||
                        response.Message.Contains("FK_FADepreciationDetail_BudgetSource") ||
                        response.Message.Contains("FK_FAIncrementDecrementDetail_BudgetSource") ||
                        response.Message.Contains("FK_GLVoucherDetail_BudgetSource") ||
                        response.Message.Contains("FK_INInwardOutwardDetail_BudgetSource") ||
                        response.Message.Contains("FK_InventoryLedger_BudgetSource") ||
                        response.Message.Contains("FK_OpeningAccountEntry_BudgetSource") ||
                        response.Message.Contains("FK_SUIncrementDecrementDetail_BudgetSource"))
                    {
                        response.Message = @"Bạn không thể xóa nguồn vốn " + budgetSourceEntity.BudgetSourceCode + " vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    }
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                response.BudgetSourceId = budgetSourceEntity.BudgetSourceId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public BudgetSourceResponse DeleteBudgetSourceConvert()
        {
            var response = new BudgetSourceResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
              
                response.Message = BudgetSourceDao.DeleteBudgetSourceConvert();
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
