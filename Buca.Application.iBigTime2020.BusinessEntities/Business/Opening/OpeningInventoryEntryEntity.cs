/***********************************************************************
 * <copyright file="OpeningAccountEntryEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;


namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Opening
{
    /// <summary>
    /// 
    /// </summary>
    public class OpeningInventoryEntryEntity : BusinessEntities  
    {
        public string RefId { get; set; }
        public int RefType { get; set; }
        public DateTime PostedDate { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public string AccountNumber { get; set; }
        public string InventoryItemId { get; set; }
        public string StockId { get; set; }
        public string BudgetSourceId { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetKindItemCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPriceOC { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal AmountOC { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string LotNo { get; set; }
        public int PostVersion { get; set; }
        public int EditVersion { get; set; }
        public int SortOrder { get; set; }
        public int RefOrder { get; set; }
        public string ContractId { get; set; }
        public string CapitalPlanId { get; set; }

    }
}