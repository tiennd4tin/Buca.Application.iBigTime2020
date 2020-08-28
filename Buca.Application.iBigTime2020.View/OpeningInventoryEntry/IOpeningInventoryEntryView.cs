/***********************************************************************
 * <copyright file="IOpeningAccountEntryView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 28 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;

namespace Buca.Application.iBigTime2020.View.OpeningInventoryEntry
{
    /// <summary>
    /// interface IOpeningAccountEntryView
    /// </summary>
    public interface IOpeningInventoryEntryView : IView
    {
        string RefId { get; set; }
        int RefType { get; set; }
        DateTime PostedDate { get; set; }
        string CurrencyCode { get; set; }
        decimal ExchangeRate { get; set; }
        string AccountNumber { get; set; }
        string InventoryItemId { get; set; }
        string StockId { get; set; }
        string BudgetSourceId { get; set; }
        string BudgetChapterCode { get; set; }
        string BudgetKindItemCode { get; set; }
        string BudgetSubKindItemCode { get; set; }
        string BudgetItemCode { get; set; }
        string BudgetSubItemCode { get; set; }
        decimal Quantity { get; set; }
        decimal UnitPriceOC { get; set; }
        decimal UnitPrice { get; set; }
        decimal AmountOC { get; set; }
        decimal Amount { get; set; }
        DateTime ExpiryDate { get; set; }
        string LotNo { get; set; }
        int PostVersion { get; set; }
        int EditVersion { get; set; }
        int SortOrder { get; set; }
        int RefOrder { get; set; }
        IList<OpeningInventoryEntryModel> OpeningInventoryEntries { get; set; }
    }
}
