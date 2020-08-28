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
    /// BudgetKindItemFacade
    /// </summary>
    public class BudgetKindItemFacade
    {
        /// <summary>
        /// The budget item DAO
        /// </summary>
        private static readonly IBudgetKindItemDao BudgetKindItemDao = DataAccess.DataAccess.BudgetKindItemDao;

        /// <summary>
        /// Gets the budget items.
        /// </summary>
        /// <returns></returns>
        public List<BudgetKindItemEntity> GetBudgetKindItems()
        {
            return BudgetKindItemDao.GetBudgetKindItems();
        }

        /// <summary>
        /// Gets the budget items by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<BudgetKindItemEntity> GetBudgetKindItemsByIsActive(bool isActive)
        {
            return BudgetKindItemDao.GetBudgetKindItemsActive();
        }

        /// <summary>
        /// Gets the budget item by identifier.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns></returns>
        public BudgetKindItemEntity GetBudgetKindItemById(string budgetKindItemId)
        {
            return BudgetKindItemDao.GetBudgetKindItem(budgetKindItemId);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="budgetKindItemEntity">The budget kind item entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetKindItemResponse InsertBudgetKindItem(BudgetKindItemEntity budgetKindItemEntity)
        {
            var response = new BudgetKindItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetKindItemEntity.Validate())
                {
                    foreach (string error in budgetKindItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var budgetKindItem = BudgetKindItemDao.GetBudgetKindItemsByCode(budgetKindItemEntity.BudgetKindItemCode.Trim());
                if (budgetKindItem != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã Loại/ Khoản " + budgetKindItemEntity.BudgetKindItemCode.Trim() + @" đã tồn tại !";
                    return response;
                }

                budgetKindItemEntity.BudgetKindItemId = Guid.NewGuid().ToString();
                response.Message = BudgetKindItemDao.InsertBudgetKindItem(budgetKindItemEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetKindItemId = budgetKindItemEntity.BudgetKindItemId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public BudgetKindItemResponse InsertBudgetKindItemConvert(BudgetKindItemEntity budgetKindItemEntity)
        {
            var response = new BudgetKindItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetKindItemEntity.Validate())
                {
                    foreach (string error in budgetKindItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var budgetKindItem = BudgetKindItemDao.GetBudgetKindItemsByCode(budgetKindItemEntity.BudgetKindItemCode.Trim());
                if (budgetKindItem != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã Loại/ Khoản " + budgetKindItemEntity.BudgetKindItemCode.Trim() + @" đã tồn tại !";
                    return response;
                }

               
                response.Message = BudgetKindItemDao.InsertBudgetKindItem(budgetKindItemEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetKindItemId = budgetKindItemEntity.BudgetKindItemId;
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
        /// <param name="budgetKindItemEntity">The budget kind item entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetKindItemResponse UpdateBudgetKindItem(BudgetKindItemEntity budgetKindItemEntity)
        {
            var response = new BudgetKindItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!budgetKindItemEntity.Validate())
                {
                    foreach (string error in budgetKindItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var budgetKindItem = BudgetKindItemDao.GetBudgetKindItemsByCode(budgetKindItemEntity.BudgetKindItemCode.Trim());

                if (budgetKindItem != null)
                {
                    if (budgetKindItem.BudgetKindItemId != budgetKindItemEntity.BudgetKindItemId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã Loại/ Khoản " + budgetKindItemEntity.BudgetKindItemCode.Trim() + @" đã tồn tại !";
                        return response;
                    }
                }

                response.Message = BudgetKindItemDao.UpdateBudgetKindItem(budgetKindItemEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.BudgetKindItemId = budgetKindItemEntity.BudgetKindItemId;
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
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public BudgetKindItemResponse DeleteBudgetKindItem(string budgetKindItemId)
        {
            var response = new BudgetKindItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var budgetKindItemEntity = BudgetKindItemDao.GetBudgetKindItem(budgetKindItemId);
                response.Message = BudgetKindItemDao.DeleteBudgetKindItem(budgetKindItemEntity);

                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK_BUPlanWithdrawDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_BUBudgetReserveDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_BUBudgetReserveDetail_BudgetSubKindItem") ||
                        response.Message.Contains("FK_CAPaymentDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_CAPaymentDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_INInwardOutwardDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_BUCommitmentRequestDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_GLVoucherDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_BUCommitmentRequestDetail_BudgetSubKindItem") ||
                        response.Message.Contains("FK_OpeningAccountEntry_BudgetKindItem") ||
                        response.Message.Contains("FK_OpeningAccountEntry_BudgetKindItem1") ||
                        response.Message.Contains("FK_BUPlanWithdrawDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_BAWithDrawDetailPurchase_BudgetKindItem") ||
                        response.Message.Contains("FK_BAWithDrawDetailPurchase_BudgetKindItem1") ||
                        response.Message.Contains("FK_BUCommitmentAdjustmentDetail_BudgetSubKindItem") ||
                        response.Message.Contains("FK_SUIncrementDecrementDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_SUIncrementDecrementDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_GLVoucherDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_CAPaymentDetailFixedAsset_BudgetKindItem1") ||
                        response.Message.Contains("FK_BADepositDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_BADepositDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_FADepreciationDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_FADepreciationDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_BUCommitmentAdjustmentDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_BAWithDrawDetailFixedAsset_BudgetKindItem1") ||
                        response.Message.Contains("FK_BADepositDetailSale_BudgetKindItem") ||
                        response.Message.Contains("FK_BADepositDetailSale_BudgetKindItem1") ||
                        response.Message.Contains("FK_BUTransferDetailPurchase_BudgetKindItem") ||
                        response.Message.Contains("FK_CAPaymentDetailFixedAsset_BudgetKindItem") ||
                        response.Message.Contains("FK_BUTransferDetailPurchase_BudgetKindItem1") ||
                        response.Message.Contains("FK_CAPaymentDetailPurchase_BudgetKindItem1") ||
                        response.Message.Contains("FK_CAReceiptDetailFixedAsset_BudgetKindItem") ||
                        response.Message.Contains("FK_CAReceiptDetailFixedAsset_BudgetKindItem1") ||
                        response.Message.Contains("FK_BUPlanReceiptDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_BUPlanReceiptDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_BAWithDrawDetailFixedAsset_BudgetKindItem") ||
                        response.Message.Contains("FK_BAWithDrawDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_BADepositDetailFixedAsset_BudgetKindItem") ||
                        response.Message.Contains("FK_BADepositDetailFixedAsset_BudgetKindItem1") ||
                        response.Message.Contains("FK_BUTransferDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_BUTransferDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_CAPaymentDetailPurchase_BudgetKindItem") ||
                        response.Message.Contains("FK_INInwardOutwardDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_FAIncrementDecrementDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_FAIncrementDecrementDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_CAReceiptDetail_BudgetKindItem") ||
                        response.Message.Contains("FK_CAReceiptDetail_BudgetKindItem1") ||
                        response.Message.Contains("FK_BAWithDrawDetail_BudgetKindItem"))
                    {
                        response.Message = @"Bạn không thể xóa Loại/ Khoản " + budgetKindItemEntity.BudgetKindItemCode + " vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    }
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                response.BudgetKindItemId = budgetKindItemEntity.BudgetKindItemId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public BudgetKindItemResponse DeleteBudgetKindItemConvert()
        {
            var response = new BudgetKindItemResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
             
                response.Message = BudgetKindItemDao.DeleteBudgetKindItemConvert();

               
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                

             
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Gets the budget kind items by code include parent code.
        /// </summary>
        /// <param name="budgetKindItemCode">The budget kind item code.</param>
        /// <returns></returns>
        public BudgetKindItemEntity GetBudgetKindItemsByCodeIncludeParentCode(string budgetKindItemCode)
        {
            return BudgetKindItemDao.GetBudgetKindItemsByCodeIncludeParentCode(budgetKindItemCode);
        }
        public BudgetKindItemEntity GetBudgetKindItemsByCode(string budgetKindItemCode)
        {
            return BudgetKindItemDao.GetBudgetKindItemsByCode(budgetKindItemCode);
        }
    }
}
