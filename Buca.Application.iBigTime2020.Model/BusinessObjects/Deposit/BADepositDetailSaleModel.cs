/***********************************************************************
 * <copyright file="BADepositDetailSaleModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 19, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit
{
    /// <summary>
    ///     BADepositDetailSaleModel
    /// </summary>
    public class BADepositDetailSaleModel
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
        ///     Gets or sets the outward price.
        /// </summary>
        /// <value>
        ///     The outward price.
        /// </value>
        public decimal OutwardPrice { get; set; }

        /// <summary>
        ///     Gets or sets the outward amount.
        /// </summary>
        /// <value>
        ///     The outward amount.
        /// </value>
        public decimal OutwardAmount { get; set; }

        /// <summary>
        ///     Gets or sets the inventory account.
        /// </summary>
        /// <value>
        ///     The inventory account.
        /// </value>
        public string InventoryAccount { get; set; }

        /// <summary>
        ///     Gets or sets the cogs account.
        /// </summary>
        /// <value>
        ///     The cogs account.
        /// </value>
        public string COGSAccount { get; set; }

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
        ///     Gets or sets the project expense identifier.
        /// </summary>
        /// <value>
        ///     The project expense identifier.
        /// </value>
        public string ProjectExpenseId { get; set; }

        /// <summary>
        ///     Gets or sets the list item identifier.
        /// </summary>
        /// <value>
        ///     The list item identifier.
        /// </value>
        public string ListItemId { get; set; }

        /// <summary>
        ///     Gets or sets the confronting reference identifier.
        /// </summary>
        /// <value>
        ///     The confronting reference identifier.
        /// </value>
        public string ConfrontingRefId { get; set; }

        /// <summary>
        ///     Gets or sets the confronting reference no.
        /// </summary>
        /// <value>
        ///     The confronting reference no.
        /// </value>
        public string ConfrontingRefNo { get; set; }

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
        ///     Gets or sets the fund structure identifier.
        /// </summary>
        /// <value>
        ///     The fund structure identifier.
        /// </value>
        public string FundStructureId { get; set; }

        /// <summary>
        ///     Gets or sets the project expense ea identifier.
        /// </summary>
        /// <value>
        ///     The project expense ea identifier.
        /// </value>
        public string ProjectExpenseEAId { get; set; }

        /// <summary>
        ///     Gets or sets the project activity ea identifier.
        /// </summary>
        /// <value>
        ///     The project activity ea identifier.
        /// </value>
        public string ProjectActivityEAId { get; set; }

        /// <summary>
        ///     Gets or sets the discount rate.
        /// </summary>
        /// <value>
        ///     The discount rate.
        /// </value>
        public decimal DiscountRate { get; set; }

        /// <summary>
        ///     Gets or sets the discount amount.
        /// </summary>
        /// <value>
        ///     The discount amount.
        /// </value>
        public decimal DiscountAmount { get; set; }
    }
}