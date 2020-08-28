/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 25, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement
{
    /// <summary>
    ///     SUIncrementDecrementDetailModel
    /// </summary>
    public class SUIncrementDecrementDetailModel
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
        ///     Gets or sets the department identifier.
        /// </summary>
        /// <value>
        ///     The department identifier.
        /// </value>
        public string DepartmentId { get; set; }

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
        ///     Gets or sets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        public decimal Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the quantity convert.
        /// </summary>
        /// <value>
        ///     The quantity convert.
        /// </value>
        public decimal QuantityConvert { get; set; }

        /// <summary>
        ///     Gets or sets the unit price.
        /// </summary>
        /// <value>
        ///     The unit price.
        /// </value>
        public decimal UnitPrice { get; set; }

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
        ///     Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        ///     The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        ///     Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        ///     The accounting object identifier.
        /// </value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        ///     Gets or sets the list item identifier.
        /// </summary>
        /// <value>
        ///     The list item identifier.
        /// </value>
        public string ListItemId { get; set; }

        /// <summary>
        ///     Gets or sets the sort order.
        /// </summary>
        /// <value>
        ///     The sort order.
        /// </value>
        public int? SortOrder { get; set; }

        /// <summary>
        ///     Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        ///     The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

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
        ///     Gets or sets the budget provide code.
        /// </summary>
        /// <value>
        ///     The budget provide code.
        /// </value>
        public string BudgetProvideCode { get; set; }

        /// <summary>
        ///     Gets or sets the topic identifier.
        /// </summary>
        /// <value>
        ///     The topic identifier.
        /// </value>
        public string TopicId { get; set; }
    }
}