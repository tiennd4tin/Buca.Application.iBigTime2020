using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    public class FundStructureModel
    {
        /// <summary>
        /// Gets or sets the fund structure identifier.
        /// </summary>
        /// <value>The fund structure identifier.</value>
        public string FundStructureId { get; set; }

        /// <summary>
        /// Gets or sets the fund structure code.
        /// </summary>
        /// <value>The fund structure code.</value>
        public string FundStructureCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the fund structure.
        /// </summary>
        /// <value>The name of the fund structure.</value>
        public string FundStructureName { get; set; }

        /// <summary>
        /// Gets or sets the buca code identifier.
        /// </summary>
        /// <value>The buca code identifier.</value>
        public string BUCACodeId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is parent.
        /// </summary>
        /// <value><c>true</c> if this instance is parent; otherwise, <c>false</c>.</value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FundStructureModel"/> is inactive.
        /// </summary>
        /// <value><c>true</c> if inactive; otherwise, <c>false</c>.</value>
        public bool Inactive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the investment period.
        /// </summary>
        /// <value>The investment period.</value>
        public int? InvestmentPeriod { get; set; }

        public string BudgetItemId { get; set; }
        public int CashWithdrawTypeId { get; set; }
        public bool IsProjectExpense { get; set; }
        public bool IsAllocateExpense { get; set; }
        public bool IsExpenseNoBuilding { get; set; }
    }
}
