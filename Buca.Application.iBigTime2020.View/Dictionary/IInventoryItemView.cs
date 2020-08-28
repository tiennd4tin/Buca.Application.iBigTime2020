/***********************************************************************
 * <copyright file="IInventoryItemView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// Interface IInventoryItemView
    /// </summary>
    public interface IInventoryItemView : IView
    {
        /// <summary>
        /// Gets or sets the inventory item identifier.
        /// </summary>
        /// <value>The inventory item identifier.</value>
         string InventoryItemId { get; set; }

        /// <summary>
        /// Gets or sets the inventory category identifier.
        /// </summary>
        /// <value>The inventory category identifier.</value>
         string InventoryCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the inventory item code.
        /// </summary>
        /// <value>The inventory item code.</value>
         string InventoryItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the inventory item.
        /// </summary>
        /// <value>The name of the inventory item.</value>
         string InventoryItemName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
         string Description { get; set; }

        /// <summary>
        /// Gets or sets the made in.
        /// </summary>
        /// <value>The made in.</value>
        string MadeIn { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
         string Unit { get; set; }

        /// <summary>
        /// Gets or sets the convert unit.
        /// </summary>
        /// <value>The convert unit.</value>
         string ConvertUnit { get; set; }

        /// <summary>
        /// Gets or sets the convert rate.
        /// </summary>
        /// <value>The convert rate.</value>
         decimal? ConvertRate { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
         decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the sale price.
        /// </summary>
        /// <value>The sale price.</value>
         decimal? SalePrice { get; set; }

        /// <summary>
        /// Gets or sets the default stock identifier.
        /// </summary>
        /// <value>The default stock identifier.</value>
         string DefaultStockId { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        string DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the inventory account.
        /// </summary>
        /// <value>The inventory account.</value>
         string InventoryAccount { get; set; }

        /// <summary>
        /// Gets or sets the cogs account.
        /// </summary>
        /// <value>The cogs account.</value>
         string COGSAccount { get; set; }

        /// <summary>
        /// Gets or sets the sale account.
        /// </summary>
        /// <value>The sale account.</value>
         string SaleAccount { get; set; }

        /// <summary>
        /// Gets or sets the cost method.
        /// </summary>
        /// <value>The cost method.</value>
         int? CostMethod { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
         string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        /// <value>The tax rate.</value>
         decimal? TaxRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is tool.
        /// </summary>
        /// <value><c>true</c> if this instance is tool; otherwise, <c>false</c>.</value>
         bool IsTool { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is service.
        /// </summary>
        /// <value><c>true</c> if this instance is service; otherwise, <c>false</c>.</value>
         bool IsService { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
         bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is taxable.
        /// </summary>
        /// <value><c>true</c> if this instance is taxable; otherwise, <c>false</c>.</value>
         bool IsTaxable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is stock.
        /// </summary>
        /// <value><c>true</c> if this instance is stock; otherwise, <c>false</c>.</value>
        bool IsStock { get; set; }
    }
}
