using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Deposit
{
    /// <summary>
    /// Class S12HEntity.
    /// </summary>
    public class S12HDetailEntity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the start of quater.
        /// </summary>
        /// <value>The start of quater.</value>
        public DateTime StartOfQuater { get; set; }

        /// <summary>
        /// Gets or sets the start of month.
        /// </summary>
        /// <value>The start of month.</value>
        public DateTime StartOfMonth { get; set; }

        /// <summary>
        /// Gets or sets the type of the order.
        /// </summary>
        /// <value>The type of the order.</value>
        public int OrderType { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>The name of the account.</value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>The name of the bank.</value>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>The budget source code.</value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget source.
        /// </summary>
        /// <value>The name of the budget source.</value>
        public string BudgetSourceName { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>The budget sub kind item code.</value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>The name of the accounting object.</value>
        public string AccountingObjectName { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public string SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the cot1.
        /// </summary>
        /// <value>The cot1.</value>
        public decimal Cot1 { get; set; }

        /// <summary>
        /// Gets or sets the cot2.
        /// </summary>
        /// <value>The cot2.</value>
        public decimal Cot2 { get; set; }

        /// <summary>
        /// Gets or sets the acc cot2.
        /// </summary>
        /// <value>The acc cot2.</value>
        public decimal AccCot2 { get; set; }

        /// <summary>
        /// Gets or sets the quy cot2.
        /// </summary>
        /// <value>The quy cot2.</value>
        public decimal QuyCot2 { get; set; }

        /// <summary>
        /// Gets or sets the cot3.
        /// </summary>
        /// <value>The cot3.</value>
        public decimal Cot3 { get; set; }

        /// <summary>
        /// Gets or sets the acc cot3.
        /// </summary>
        /// <value>The acc cot3.</value>
        public decimal AccCot3 { get; set; }

        /// <summary>
        /// Gets or sets the quy cot3.
        /// </summary>
        /// <value>The quy cot3.</value>
        public decimal QuyCot3 { get; set; }

        /// <summary>
        /// Gets or sets the is one budget chapter code.
        /// </summary>
        /// <value>The is one budget chapter code.</value>
        public int IsOneBudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the is one budget source code.
        /// </summary>
        /// <value>The is one budget source code.</value>
        public int IsOneBudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the is one budget sub kind item code.
        /// </summary>
        /// <value>The is one budget sub kind item code.</value>
        public int IsOneBudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>The corresponding account number.</value>
        public string CorrespondingAccountNumber { get; set; }
    }
}
