/***********************************************************************
 * <copyright file="F0101BCQTModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Wednesday, May 23, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Settlement
{
    /// <summary>
    /// Class F0101BCQTModel.
    /// </summary>
    public class F0101BCQTModel
    {
        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the report item.
        /// </summary>
        /// <value>The name of the report item.</value>
        public string ReportItemName { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>The budget kind item code.</value>
        public string BudgetKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>The budget sub kind item code.</value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget sub kind item.
        /// </summary>
        /// <value>The name of the budget sub kind item.</value>
        public string BudgetSubKindItemName { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>The budget item code.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget item.
        /// </summary>
        /// <value>The name of the budget item.</value>
        public string BudgetItemName { get; set; }

        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>The budget sub item code.</value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget sub item.
        /// </summary>
        /// <value>The name of the budget sub item.</value>
        public string BudgetSubItemName { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the domestic budget amount.
        /// </summary>
        /// <value>The domestic budget amount.</value>
        public decimal DomesticBudgetAmount { get; set; }

        /// <summary>
        /// Gets or sets the aid budget amount.
        /// </summary>
        /// <value>The aid budget amount.</value>
        public decimal AidBudgetAmount { get; set; }

        /// <summary>
        /// Gets or sets the foreign loans budget amount.
        /// </summary>
        /// <value>The foreign loans budget amount.</value>
        public decimal ForeignLoansBudgetAmount { get; set; }

        /// <summary>
        /// Gets or sets the deductible budget amount.
        /// </summary>
        /// <value>The deductible budget amount.</value>
        public decimal DeductibleBudgetAmount { get; set; }

        /// <summary>
        /// Gets or sets the other budget amount.
        /// </summary>
        /// <value>The other budget amount.</value>
        public decimal OtherBudgetAmount { get; set; }
    }
}
