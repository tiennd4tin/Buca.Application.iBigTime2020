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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IBudgetKindItemDao
    /// </summary>
    public interface IBudgetKindItemDao
    {
        /// <summary>
        /// Gets the Budget item.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns></returns>
        BudgetKindItemEntity GetBudgetKindItem(string budgetKindItemId);

        /// <summary>
        /// Gets the Budget items.
        /// </summary>
        /// <returns></returns>
        List<BudgetKindItemEntity> GetBudgetKindItems();

        /// <summary>
        /// Gets the Budget items for combo tree.
        /// </summary>
        /// <param name="budgetKindItemId">The budget kind item identifier.</param>
        /// <returns></returns>
        List<BudgetKindItemEntity> GetBudgetKindItemsForComboTree(string budgetKindItemId);

        /// <summary>
        /// Gets the Budget items active.
        /// </summary>
        /// <returns></returns>
        List<BudgetKindItemEntity> GetBudgetKindItemsActive();

        /// <summary>
        /// Gets the Budget items active.
        /// </summary>
        /// <param name="isReceipt">if set to <c>true</c> [is receipt].</param>
        /// <returns></returns>
        List<BudgetKindItemEntity> GetBudgetKindItemsByIsReceipt(bool isReceipt);

        /// <summary>
        /// Gets the budget items by capital allocate.
        /// </summary>
        /// <returns></returns>
        List<BudgetKindItemEntity> GetBudgetKindItemsByCapitalAllocate();

        /// <summary>
        /// Gets the budget items by pay voucher.
        /// </summary>
        /// <returns></returns>
        List<BudgetKindItemEntity> GetBudgetKindItemsByPayVoucher();

        /// <summary>
        /// Gets the budget items by is receipt for estimate.
        /// </summary>
        /// <param name="isReceipt">if set to <c>true</c> [is receipt].</param>
        /// <returns></returns>
        List<BudgetKindItemEntity> GetBudgetKindItemsByIsReceiptForEstimate(bool isReceipt);

        /// <summary>
        /// Gets the budget item and sub items.
        /// </summary>
        /// <param name="isBudgetKindItemType">Type of the is budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<BudgetKindItemEntity> GetBudgetKindItemAndSubItems(int isBudgetKindItemType, bool isActive);

        /// <summary>
        /// Gets the Budget items by code.
        /// </summary>
        /// <param name="budgetKindItemCode">The budget kind item code.</param>
        /// <returns></returns>
        BudgetKindItemEntity GetBudgetKindItemsByCode(string budgetKindItemCode);

        /// <summary>
        /// Inserts the Budget item.
        /// </summary>
        /// <param name="budgetKindItem">The budget kind item.</param>
        /// <returns></returns>
        string InsertBudgetKindItem(BudgetKindItemEntity budgetKindItem);

        /// <summary>
        /// Updates the Budget item.
        /// </summary>
        /// <param name="budgetKindItem">The budget kind item.</param>
        /// <returns></returns>
        string UpdateBudgetKindItem(BudgetKindItemEntity budgetKindItem);

        /// <summary>
        /// Deletes the Budget item.
        /// </summary>
        /// <param name="budgetKindItem">The budget kind item.</param>
        /// <returns></returns>
        string DeleteBudgetKindItem(BudgetKindItemEntity budgetKindItem);
        string DeleteBudgetKindItemConvert();

        /// <summary>
        /// Gets the budget item by type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        List<BudgetKindItemEntity> GetBudgetKindItems(int type);

        /// <summary>
        /// Gets the budget kind items by code include parent code.
        /// </summary>
        /// <param name="budgetKindItemCode">The budget kind item code.</param>
        /// <returns></returns>
        BudgetKindItemEntity GetBudgetKindItemsByCodeIncludeParentCode(string budgetKindItemCode);
    }
}
