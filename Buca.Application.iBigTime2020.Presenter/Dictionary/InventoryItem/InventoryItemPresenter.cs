/***********************************************************************
 * <copyright file="InventoryItemPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem
{
    /// <summary>
    /// Class InventoryItemPresenter.
    /// </summary>
    public class InventoryItemPresenter : Presenter<IInventoryItemView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItemPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public InventoryItemPresenter(IInventoryItemView view) : base(view)
        {

        }

        /// <summary>
        /// Displays the specified inventory item identifier.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        public void Display(string inventoryItemId)
        {
            if (inventoryItemId == null)
            {
                View.InventoryItemId = null;
                return;
            }

            var inventoryItem = Model.GetInventoryItem(inventoryItemId);

            View.InventoryItemId = inventoryItem.InventoryItemId;
            View.InventoryCategoryId = inventoryItem.InventoryCategoryId;
            View.InventoryItemCode = inventoryItem.InventoryItemCode;
            View.InventoryItemName = inventoryItem.InventoryItemName;
            View.Description = inventoryItem.Description;
            View.Unit = inventoryItem.Unit;
            View.ConvertUnit = inventoryItem.ConvertUnit;
            View.ConvertRate = inventoryItem.ConvertRate;
            View.UnitPrice = inventoryItem.UnitPrice;
            View.SalePrice = inventoryItem.SalePrice;
            View.DefaultStockId = inventoryItem.DefaultStockId;
            View.DepartmentId = inventoryItem.DepartmentId;
            View.InventoryAccount = inventoryItem.InventoryAccount;
            View.COGSAccount = inventoryItem.COGSAccount;
            View.SaleAccount = inventoryItem.SaleAccount;
            View.CostMethod = inventoryItem.CostMethod;
            View.AccountingObjectId = inventoryItem.AccountingObjectId;
            View.TaxRate = inventoryItem.TaxRate;
            View.IsTool = inventoryItem.IsTool;
            View.IsService = inventoryItem.IsService;
            View.IsActive = inventoryItem.IsActive;
            View.IsTaxable = inventoryItem.IsTaxable;
            View.IsStock = inventoryItem.IsStock;
            View.MadeIn = inventoryItem.MadeIn;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var inventoryItem = new InventoryItemModel
            {
                InventoryItemId = View.InventoryItemId,
                InventoryCategoryId = View.InventoryCategoryId,
                InventoryItemCode = View.InventoryItemCode,
                InventoryItemName = View.InventoryItemName,
                Description = View.Description,
                Unit = View.Unit,
                ConvertUnit = View.ConvertUnit,
                ConvertRate = View.ConvertRate,
                UnitPrice = View.UnitPrice,
                SalePrice = View.SalePrice,
                DefaultStockId = View.DefaultStockId,
                DepartmentId = View.DepartmentId,
                InventoryAccount = View.InventoryAccount,
                COGSAccount = View.COGSAccount,
                SaleAccount = View.SaleAccount,
                CostMethod = View.CostMethod,
                AccountingObjectId = View.AccountingObjectId,
                TaxRate = View.TaxRate,
                IsTool = View.IsTool,
                IsService = View.IsService,
                IsActive = View.IsActive,
                IsTaxable = View.IsTaxable,
                IsStock = View.IsStock,
                MadeIn = View.MadeIn
            };
            return View.InventoryItemId == null ? Model.InsertInventoryItem(inventoryItem) : Model.UpdateInventoryItem(inventoryItem);
        }

        /// <summary>
        /// Deletes the specified inventory item identifier.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>System.Int32.</returns>
        public string Delete(string inventoryItemId)
        {
            return Model.Delete(inventoryItemId);
        }

        /// <summary>
        /// Tính số lượng tồn trong kho
        /// </summary>
        /// <returns></returns>
        public static InventoryItemModel GetUnitsInStock(string inventoryItemId, string stockId ,DateTime Todate)
        {
            return Model.GetUnitsInStock(inventoryItemId, stockId, Todate);
        }

        /// <summary>
        /// Calculates the outward price.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>System.String.</returns>
        public string CalculateOutwardPrice(DateTime fromDate, DateTime toDate, string inventoryItemId)
        {
            return Model.CalculateOutwardPrice(fromDate, toDate, inventoryItemId);
        }
    }
}
