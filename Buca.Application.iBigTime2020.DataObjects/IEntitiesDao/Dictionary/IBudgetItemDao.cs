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
    /// interface IBudgetItemDao
    /// </summary>
    public interface IBudgetItemDao
    {
        /// <summary>
        /// Gets the Budget item.
        /// </summary>
        /// <param name="budgetItemId">The Budget item identifier.</param>
        /// <returns></returns>
        BudgetItemEntity GetBudgetItem(string budgetItemId);

        /// <summary>
        /// Gets the Budget items.
        /// </summary>
        /// <returns></returns>
        List<BudgetItemEntity> GetBudgetItems();

        /// <summary>
        /// Gets the budget items by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<BudgetItemEntity> GetBudgetItemsByIsActive(bool isActive);

        /// <summary>
        /// Gets the Budget items for combo tree.
        /// </summary>
        /// <param name="budgetItemId">The Budget item identifier.</param>
        /// <returns></returns>
        List<BudgetItemEntity> GetBudgetItemsForComboTree(string budgetItemId);

        /// <summary>
        /// Gets the type of the budget items by budget item.
        /// </summary>
        /// <param name="budgetItemType">Type of the budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<BudgetItemEntity> GetBudgetItemsByBudgetItemType(int budgetItemType, bool isActive);

        /// <summary>
        /// Gets the Budget items active.
        /// </summary>
        /// <returns></returns>
        List<BudgetItemEntity> GetBudgetItemsByIsReceipt(bool isReceipt);

        /// <summary>
        /// Gets the budget items by capital allocate.
        /// </summary>
        /// <returns></returns>
        List<BudgetItemEntity> GetBudgetItemsByCapitalAllocate();

        /// <summary>
        /// Gets the budget items by pay voucher.
        /// </summary>
        /// <returns></returns>
        List<BudgetItemEntity> GetBudgetItemsByPayVoucher();

        /// <summary>
        /// Gets the budget items by is receipt for estimate.
        /// </summary>
        /// <param name="isReceipt">if set to <c>true</c> [is receipt].</param>
        /// <returns></returns>
        List<BudgetItemEntity> GetBudgetItemsByIsReceiptForEstimate(bool isReceipt);

        /// <summary>
        /// Gets the budget item and sub items.
        /// </summary>
        /// <param name="isBudgetItemType">Type of the is budget item.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<BudgetItemEntity> GetBudgetItemAndSubItems(int isBudgetItemType, bool isActive);

        /// <summary>
        /// Gets the Budget items by code.
        /// </summary>
        /// <returns></returns>
        BudgetItemEntity GetBudgetItemsByCode(string budgetItemCode);
        
        /// <summary>
        /// Inserts the Budget item.
        /// </summary>
        /// <param name="budgetItem">The Budget item.</param>
        /// <returns></returns>
        string InsertBudgetItem(BudgetItemEntity budgetItem);

        /// <summary>
        /// Updates the Budget item.
        /// </summary>
        /// <param name="budgetItem">The Budget item.</param>
        /// <returns></returns>
        string UpdateBudgetItem(BudgetItemEntity budgetItem);

        /// <summary>
        /// Deletes the Budget item.
        /// </summary>
        /// <param name="budgetItem">The Budget item.</param>
        /// <returns></returns>
        string DeleteBudgetItem(BudgetItemEntity budgetItem);
        string DeleteBudgetItemConvert();

        /// <summary>
        /// Gets the budget item by type.
        /// </summary>
        /// <returns></returns>
        List<BudgetItemEntity> GetBudgetItems(int type);
    }
}
