/***********************************************************************
 * <copyright file="N01_SDKP_DVDTEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   KienNT
 * Email:    kiennt@buca.vn
 * Website:
 * Create Date: Tuesdaypublic decimal  August 28public decimal  2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date Tuesdaypublic decimal  August 28public decimal  2018        Author        Tudt       Description: Fomat code
 * 
 * ************************************************************************/
 
namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Cash
{
    /// <summary>
    /// N01_SDKP_DVDTEntity
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class N01_SDKP_DVDTEntity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        /// The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

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
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the debit amount.
        /// </summary>
        /// <value>
        /// The debit amount.
        /// </value>
        public decimal DebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the credit amount.
        /// </summary>
        /// <value>
        /// The credit amount.
        /// </value>
        public decimal CreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the movement debit amount.
        /// </summary>
        /// <value>
        /// The movement debit amount.
        /// </value>
        public decimal MovementDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the sum debit.
        /// </summary>
        /// <value>
        /// The sum debit.
        /// </value>
        public decimal SumDebit { get; set; }

        /// <summary>
        /// Gets or sets the sum credit.
        /// </summary>
        /// <value>
        /// The sum credit.
        /// </value>
        public decimal SumCredit { get; set; }

        /// <summary>
        /// Gets or sets the early sum debit.
        /// </summary>
        /// <value>
        /// The early sum debit.
        /// </value>
        public decimal EarlySumDebit { get; set; }

        /// <summary>
        /// Gets or sets the commitment.
        /// </summary>
        /// <value>
        /// The commitment.
        /// </value>
        public decimal Commitment { get; set; }

        /// <summary>
        /// Gets or sets the sum commitment.
        /// </summary>
        /// <value>
        /// The sum commitment.
        /// </value>
        public decimal SumCommitment { get; set; }

        /// <summary>
        /// Gets or sets the reserved.
        /// </summary>
        /// <value>
        /// The reserved.
        /// </value>
        public decimal Reserved { get; set; }

        /// <summary>
        /// Gets or sets the useable amount.
        /// </summary>
        /// <value>
        /// The useable amount.
        /// </value>
        public decimal UseableAmount { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount.
        /// </summary>
        /// <value>
        /// The remaining amount.
        /// </value>
        public decimal RemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>
        /// The type of the item.
        /// </value>
        public int ItemType { get; set; }
        
        /// <summary>
        /// Gets or sets the part.
        /// </summary>
        /// <value>
        /// The part.
        /// </value>
        public int Part { get; set; }
    }
}
