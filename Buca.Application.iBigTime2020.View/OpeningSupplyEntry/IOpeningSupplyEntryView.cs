/***********************************************************************
 * <copyright file="IOpeningSupplyEntryView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, January 3, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, January 3, 2018 Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.OpeningSupplyEntry
{
    /// <summary>
    /// Interface IOpeningSupplyEntryView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IOpeningSupplyEntryView : IView
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        string RefId { get; set; }
        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        int RefType { get; set; }
        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        DateTime PostedDate { get; set; }
        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        string CurrencyCode { get; set; }
        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        decimal ExchangeRate { get; set; }
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        string AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the inventory item identifier.
        /// </summary>
        /// <value>The inventory item identifier.</value>
        string InventoryItemId { get; set; }
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        string DepartmentId { get; set; }
        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        string BudgetChapterCode { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        decimal Quantity { get; set; }
        /// <summary>
        /// Gets or sets the unit price oc.
        /// </summary>
        /// <value>The unit price oc.</value>
        decimal UnitPriceOC { get; set; }
        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        decimal UnitPrice { get; set; }
        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>The amount oc.</value>
        decimal AmountOC { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        decimal Amount { get; set; }
        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>The post version.</value>
        int PostVersion { get; set; }
        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>The edit version.</value>
        int EditVersion { get; set; }
        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        int SortOrder { get; set; }
    }
}
