﻿/***********************************************************************
 * <copyright file="BAWithDrawDetailPurchaseEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 23, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit
{
    /// <summary>
    ///     BAWithDrawDetailPurchaseEntity
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class BAWithDrawDetailPurchaseEntity : BusinessEntities
    {
        /// <summary>
        ///     Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>
        ///     The reference detail identifier.
        /// </value>
        public string RefDetailId { get; set; }

        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        ///     Gets or sets the inventory item identifier.
        /// </summary>
        /// <value>
        ///     The inventory item identifier.
        /// </value>
        public string InventoryItemId { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the stock identifier.
        /// </summary>
        /// <value>
        ///     The stock identifier.
        /// </value>
        public string StockId { get; set; }

        /// <summary>
        ///     Gets or sets the debit account.
        /// </summary>
        /// <value>
        ///     The debit account.
        /// </value>
        public string DebitAccount { get; set; }

        /// <summary>
        ///     Gets or sets the credit account.
        /// </summary>
        /// <value>
        ///     The credit account.
        /// </value>
        public string CreditAccount { get; set; }

        /// <summary>
        ///     Gets or sets the unit.
        /// </summary>
        /// <value>
        ///     The unit.
        /// </value>
        public string Unit { get; set; }

        /// <summary>
        ///     Gets or sets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        public decimal Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the unit price.
        /// </summary>
        /// <value>
        ///     The unit price.
        /// </value>
        public decimal UnitPrice { get; set; }

        /// <summary>
        ///     Gets or sets the quantity convert.
        /// </summary>
        /// <value>
        ///     The quantity convert.
        /// </value>
        public decimal QuantityConvert { get; set; }

        /// <summary>
        ///     Gets or sets the unit price convert.
        /// </summary>
        /// <value>
        ///     The unit price convert.
        /// </value>
        public decimal UnitPriceConvert { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>
        ///     The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Gets or sets the tax rate.
        /// </summary>
        /// <value>
        ///     The tax rate.
        /// </value>
        public decimal? TaxRate { get; set; }

        /// <summary>
        ///     Gets or sets the tax amount.
        /// </summary>
        /// <value>
        ///     The tax amount.
        /// </value>
        public decimal TaxAmount { get; set; }

        /// <summary>
        ///     Gets or sets the tax account.
        /// </summary>
        /// <value>
        ///     The tax account.
        /// </value>
        public string TaxAccount { get; set; }

        /// <summary>
        ///     Gets or sets the type of the inv.
        /// </summary>
        /// <value>
        ///     The type of the inv.
        /// </value>
        public int? InvType { get; set; }

        /// <summary>
        ///     Gets or sets the inv date.
        /// </summary>
        /// <value>
        ///     The inv date.
        /// </value>
        public DateTime? InvDate { get; set; }

        /// <summary>
        ///     Gets or sets the inv series.
        /// </summary>
        /// <value>
        ///     The inv series.
        /// </value>
        public string InvSeries { get; set; }

        /// <summary>
        ///     Gets or sets the inv no.
        /// </summary>
        /// <value>
        ///     The inv no.
        /// </value>
        public string InvNo { get; set; }

        /// <summary>
        ///     Gets or sets the purchase purpose identifier.
        /// </summary>
        /// <value>
        ///     The purchase purpose identifier.
        /// </value>
        public string PurchasePurposeId { get; set; }

        /// <summary>
        ///     Gets or sets the freight amount.
        /// </summary>
        /// <value>
        ///     The freight amount.
        /// </value>
        public decimal FreightAmount { get; set; }

        /// <summary>
        ///     Gets or sets the inward amount.
        /// </summary>
        /// <value>
        ///     The inward amount.
        /// </value>
        public decimal InwardAmount { get; set; }

        /// <summary>
        ///     Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        ///     The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        ///     Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        ///     The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        ///     The budget kind item code.
        /// </value>
        public string BudgetKindItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>
        ///     The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget item code.
        /// </summary>
        /// <value>
        ///     The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the budget sub item code.
        /// </summary>
        /// <value>
        ///     The budget sub item code.
        /// </value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>
        ///     The method distribute identifier.
        /// </value>
        public int? MethodDistributeId { get; set; }

        /// <summary>
        ///     Gets or sets the cash withdraw type identifier.
        /// </summary>
        /// <value>
        ///     The cash withdraw type identifier.
        /// </value>
        public int? CashWithdrawTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        ///     The accounting object identifier.
        /// </value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        ///     Gets or sets the activity identifier.
        /// </summary>
        /// <value>
        ///     The activity identifier.
        /// </value>
        public string ActivityId { get; set; }

        /// <summary>
        ///     Gets or sets the project identifier.
        /// </summary>
        /// <value>
        ///     The project identifier.
        /// </value>
        public string ProjectId { get; set; }

        /// <summary>
        ///     Gets or sets the project activity identifier.
        /// </summary>
        /// <value>
        ///     The project activity identifier.
        /// </value>
        public string ProjectActivityId { get; set; }

        /// <summary>
        ///     Gets or sets the fund identifier.
        /// </summary>
        /// <value>
        ///     The fund identifier.
        /// </value>
        public string FundId { get; set; }

        /// <summary>
        ///     Gets or sets the list item identifier.
        /// </summary>
        /// <value>
        ///     The list item identifier.
        /// </value>
        public string ListItemId { get; set; }

        /// <summary>
        ///     Gets or sets the expiry date.
        /// </summary>
        /// <value>
        ///     The expiry date.
        /// </value>
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        ///     Gets or sets the lot no.
        /// </summary>
        /// <value>
        ///     The lot no.
        /// </value>
        public string LotNo { get; set; }

        /// <summary>
        ///     Gets or sets the sort order.
        /// </summary>
        /// <value>
        ///     The sort order.
        /// </value>
        public int? SortOrder { get; set; }

        /// <summary>
        ///     Gets or sets the budget detail item code.
        /// </summary>
        /// <value>
        ///     The budget detail item code.
        /// </value>
        public string BudgetDetailItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the invoice type code.
        /// </summary>
        /// <value>
        ///     The invoice type code.
        /// </value>
        public string InvoiceTypeCode { get; set; }

        /// <summary>
        ///     Gets or sets the org reference no.
        /// </summary>
        /// <value>
        ///     The org reference no.
        /// </value>
        public string OrgRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the org reference date.
        /// </summary>
        /// <value>
        ///     The org reference date.
        /// </value>
        public DateTime? OrgRefDate { get; set; }

        /// <summary>
        ///     Gets or sets the fund structure identifier.
        /// </summary>
        /// <value>
        ///     The fund structure identifier.
        /// </value>
        public string FundStructureId { get; set; }

        /// <summary>
        ///     Gets or sets the project activity ea identifier.
        /// </summary>
        /// <value>
        ///     The project activity ea identifier.
        /// </value>
        public string ProjectActivityEAId { get; set; }

        public string BudgetExpenseId { get; set; }

        public string BankId { get; set; }

    }
}