/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
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
    /// Class BudgetItemFacade.
    /// </summary>
    public class BudgetItemFacade
    {
        /// <summary>
        /// The budget item DAO
        /// </summary>
        private static readonly IBudgetItemDao BudgetItemDao = DataAccess.DataAccess.BudgetItemDao;

        /// <summary>
        /// Gets the budget items.
        /// </summary>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItems()
        {
            return BudgetItemDao.GetBudgetItems();
        }

        /// <summary>
        /// Gets the budget items.
        /// </summary>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <returns></returns>
        public BudgetItemEntity GetBudgetItemByCode(string budgetItemCode)
        {
            return BudgetItemDao.GetBudgetItemsByCode(budgetItemCode);
        }

        /// <summary>
        /// Gets the budget items by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemsByIsActive(bool isActive)
        {
            return BudgetItemDao.GetBudgetItemsByIsActive(isActive);
        }

        /// <summary>
        /// Gets the budget items by is active.
        /// </summary>
        /// <param name="budgetItemType">Type of the budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<BudgetItemEntity> GetBudgetItemsByBudgetItemType(int budgetItemType, bool isActive)
        {
            return BudgetItemDao.GetBudgetItemsByBudgetItemType(budgetItemType, isActive);
        }

        /// <summary>
        /// Gets the budget item by identifier.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns></returns>
        public BudgetItemEntity GetBudgetItemById(string budgetItemId)
        {
            return BudgetItemDao.GetBudgetItem(budgetItemId);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="budgetItemEntity">The budget item entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetItemResponse InsertBudgetItem(BudgetItemEntity budgetItemEntity)
        {
            var response = new BudgetItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetItemEntity.Validate())
                {
                    foreach (string error in budgetItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var budgetItem = BudgetItemDao.GetBudgetItemsByCode(budgetItemEntity.BudgetItemCode.Trim());
                if (budgetItem != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã Mục/Tiểu mục " + budgetItemEntity.BudgetItemCode.Trim() + @" đã tồn tại !";
                    return response;
                }

                budgetItemEntity.BudgetItemId = Guid.NewGuid().ToString();
                response.Message = BudgetItemDao.InsertBudgetItem(budgetItemEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetItemId = budgetItemEntity.BudgetItemId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public BudgetItemResponse InsertBudgetItemConvert(BudgetItemEntity budgetItemEntity)
        {
            var response = new BudgetItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetItemEntity.Validate())
                {
                    foreach (string error in budgetItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var budgetItem = BudgetItemDao.GetBudgetItemsByCode(budgetItemEntity.BudgetItemCode.Trim());
                if (budgetItem != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã Mục/Tiểu mục " + budgetItemEntity.BudgetItemCode.Trim() + @" đã tồn tại !";
                    return response;
                }

              
                response.Message = BudgetItemDao.InsertBudgetItem(budgetItemEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetItemId = budgetItemEntity.BudgetItemId;
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
        /// <param name="budgetItemEntity">The budget item entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetItemResponse UpdateBudgetItem(BudgetItemEntity budgetItemEntity)
        {
            var response = new BudgetItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetItemEntity.Validate())
                {
                    foreach (string error in budgetItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var budgetItem = BudgetItemDao.GetBudgetItemsByCode(budgetItemEntity.BudgetItemCode.Trim());
                if (budgetItem != null)
                {
                    if (budgetItem.BudgetItemId != budgetItemEntity.BudgetItemId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã Mục/Tiểu mục " + budgetItemEntity.BudgetItemCode.Trim() + @" đã tồn tại !";
                        return response;
                    }
                }

                response.Message = BudgetItemDao.UpdateBudgetItem(budgetItemEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetItemId = budgetItemEntity.BudgetItemId;
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
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetItemResponse DeleteBudgetItem(string budgetItemId)
        {
            var response = new BudgetItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var budgetItemEntity = BudgetItemDao.GetBudgetItem(budgetItemId);
                response.Message = BudgetItemDao.DeleteBudgetItem(budgetItemEntity);

                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK_BUBudgetReserveDetail_BudgetItem") ||
                        response.Message.Contains("FK_FixedAsset_BudgetItem_BudgetItemCode") ||
                        response.Message.Contains("FK_FixedAsset_BudgetItem_BudgetSubItemCode") ||
                        response.Message.Contains("FK_BUBudgetReserveDetail_BudgetSubItem") ||
                        response.Message.Contains("FK_CAPaymentDetail_BudgetItem") ||
                        response.Message.Contains("FK_CAPaymentDetail_BudgetItem1") ||
                        response.Message.Contains("FK_BUPlanWithdrawDetail_BudgetItem") ||
                        response.Message.Contains("FK_BUPlanWithdrawDetail_BudgetItem1") ||
                        response.Message.Contains("FK_GLVoucherDetail_BudgetItem") ||
                        response.Message.Contains("FK_GLVoucherDetail_BudgetItem1") ||
                        response.Message.Contains("FK_BUCommitmentRequestDetail_BudgetItem") ||
                        response.Message.Contains("FK_BUCommitmentRequestDetail_BudgetSubItem") ||
                        response.Message.Contains("FK_OpeningAccountEntry_BudgetItem") ||
                        response.Message.Contains("FK_OpeningAccountEntry_BudgetItem1") ||
                        response.Message.Contains("FK_BUPlanAdjustmentDetail_BudgetItem1") ||
                        response.Message.Contains("FK_FADepreciationDetail_BudgetItem1") ||
                        response.Message.Contains("FK_BUCommitmentAdjustmentDetail_BudgetItem") ||
                        response.Message.Contains("FK_BAWithDrawDetailPurchase_BudgetItem") ||
                        response.Message.Contains("FK_BAWithDrawDetailPurchase_BudgetItem1") ||
                        response.Message.Contains("FK_BUCommitmentAdjustmentDetail_BudgetSubItem") ||
                        response.Message.Contains("FK_BUTransferDetailPurchase_BudgetItem1") ||
                        response.Message.Contains("FK_CAPaymentDetailFixedAsset_BudgetItem1") ||
                        response.Message.Contains("FK_BADepositDetail_BudgetItem") ||
                        response.Message.Contains("FK_BADepositDetail_BudgetItem1") ||
                        response.Message.Contains("FK_BUPlanAdjustmentDetail_BudgetItem") ||
                        response.Message.Contains("FK_FADepreciationDetail_BudgetItem") ||
                        response.Message.Contains("FK_BAWithDrawDetailFixedAsset_BudgetItem") ||
                        response.Message.Contains("FK_BAWithDrawDetailFixedAsset_BudgetItem1") ||
                        response.Message.Contains("FK_BADepositDetailSale_BudgetItem") ||
                        response.Message.Contains("FK_BADepositDetailSale_BudgetItem1") ||
                        response.Message.Contains("FK_BUTransferDetailPurchase_BudgetItem") ||
                        response.Message.Contains("FK_CAPaymentDetailFixedAsset_BudgetItem") ||
                        response.Message.Contains("FK_CAPaymentDetailPurchase_BudgetItem") ||
                        response.Message.Contains("FK_CAPaymentDetailPurchase_BudgetItem1") ||
                        response.Message.Contains("FK_CAReceiptDetailFixedAsset_BudgetItem"))
                    {
                        response.Message = @"Bạn không thể xóa Mục/ Tiểu mục " + budgetItemEntity.BudgetItemCode + " vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    }
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                response.BudgetItemId = budgetItemEntity.BudgetItemId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public BudgetItemResponse DeleteBudgetItemConvert()
        {
            var response = new BudgetItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                
                response.Message = BudgetItemDao.DeleteBudgetItemConvert();

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

