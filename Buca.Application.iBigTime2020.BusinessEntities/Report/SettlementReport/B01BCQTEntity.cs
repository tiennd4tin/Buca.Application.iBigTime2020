/***********************************************************************
 * <copyright file="b01bcqtentity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, June 13, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.SettlementReport
{
    /// <summary>
    ///     B01BCQTEntity
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class B01BCQTEntity : BusinessEntities
    {
        /// <summary>
        ///     Gets or sets the name of the report item.
        /// </summary>
        /// <value>
        ///     The name of the report item.
        /// </value>
        public string ReportItemName { get; set; }

        /// <summary>
        ///     Gets or sets the report item code.
        /// </summary>
        /// <value>
        ///     The report item code.
        /// </value>
        public string ReportItemCode { get; set; }

        /// <summary>
        ///     Gets or sets the report item alias.
        /// </summary>
        /// <value>
        ///     The report item alias.
        /// </value>
        public string ReportItemAlias { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is bold.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is bold; otherwise, <c>false</c>.
        /// </value>
        public bool IsBold { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is italic.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is italic; otherwise, <c>false</c>.
        /// </value>
        public bool IsItalic { get; set; }

        /// <summary>
        ///     Gets or sets the summary amount.
        /// </summary>
        /// <value>
        ///     The summary amount.
        /// </value>
        public decimal SummaryAmount { get; set; }

        /// <summary>
        ///     Gets or sets the summary budget kind item amount.
        /// </summary>
        /// <value>
        ///     The summary budget kind item amount.
        /// </value>
        public decimal SummaryBudgetKindItemAmount { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>
        ///     The amount.
        /// </value>
        public decimal Amount { get; set; }
    }
}