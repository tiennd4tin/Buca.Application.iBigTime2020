/***********************************************************************
 * <copyright file="S150H1Entity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   AnhNT
 * Email:    anh@buca.vn
 * Website:
 * Create Date: Tuesday, July 17, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.TreasuaryReport
{
    /// <summary>
    /// S106H1Entity
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class S106H1Entity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the part identifier.
        /// </summary>
        /// <value>
        /// The part identifier.
        /// </value>
        public int PartId { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget source.
        /// </summary>
        /// <value>
        /// The name of the budget source.
        /// </value>
        public string BudgetSourceName { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>
        /// The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        /// The budget kind item code.
        /// </value>
        public string BudgetKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>
        /// The reference detail identifier.
        /// </value>
        public string RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the month year.
        /// </summary>
        /// <value>
        /// The month year.
        /// </value>
        public int MonthYear { get; set; }

        /// <summary>
        /// Gets or sets the display month.
        /// </summary>
        /// <value>
        /// The display month.
        /// </value>
        public int DisplayMonth { get; set; }

        /// <summary>
        /// Gets or sets the type of the detail.
        /// </summary>
        /// <value>
        /// The type of the detail.
        /// </value>
        public int DetailType { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget expense.
        /// </summary>
        /// <value>
        /// The name of the budget expense.
        /// </value>
        public string BudgetExpenseName { get; set; }

        /// <summary>
        /// Gets or sets the budget expense code.
        /// </summary>
        /// <value>
        /// The budget expense code.
        /// </value>
        public string BudgetExpenseCode { get; set; }

        /// <summary>
        /// Gets or sets the regular amount.
        /// </summary>
        /// <value>
        /// The regular amount.
        /// </value>
        public decimal RegularAmount { get; set; }

        /// <summary>
        /// Gets or sets the no regular amount.
        /// </summary>
        /// <value>
        /// The no regular amount.
        /// </value>
        public decimal NoRegularAmount { get; set; }

        public decimal OpeningAmount { get; set; }
        public decimal BeginBalance { get; set; }
        public decimal BeginBalance1 { get; set; }
        public decimal BeginBalance2 { get; set; }
    }
}
