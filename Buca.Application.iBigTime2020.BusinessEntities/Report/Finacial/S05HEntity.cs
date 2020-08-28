/***********************************************************************
 * <copyright file="S05HEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Tuesday, December 26, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateTuesday, December 26, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial
{
    /// <summary>
    /// Class S05HEntity.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class S05HEntity : BusinessEntities
    {
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
        /// Gets or sets the account category.
        /// </summary>
        /// <value>The account category.</value>
        public int AccountCategory { get; set; }
        /// <summary>
        /// Gets or sets the kind of the account category.
        /// </summary>
        /// <value>The kind of the account category.</value>
        public int AccountCategoryKind { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is parent.
        /// </summary>
        /// <value><c>true</c> if this instance is parent; otherwise, <c>false</c>.</value>
        public bool IsParent { get; set; }
        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }
        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode { get; set; }
        /// <summary>
        /// Gets or sets the open debit amount.
        /// </summary>
        /// <value>The open debit amount.</value>
        public decimal OpenDebitAmount { get; set; }
        /// <summary>
        /// Gets or sets the open credit amount.
        /// </summary>
        /// <value>The open credit amount.</value>
        public decimal OpenCreditAmount { get; set; }
        /// <summary>
        /// Gets or sets the open ajust debit amount.
        /// </summary>
        /// <value>The open ajust debit amount.</value>
        public decimal OpenAjustDebitAmount { get; set; }
        /// <summary>
        /// Gets or sets the open ajust credit amount.
        /// </summary>
        /// <value>The open ajust credit amount.</value>
        public decimal OpenAjustCreditAmount { get; set; }
        /// <summary>
        /// Gets or sets the movement debit amount.
        /// </summary>
        /// <value>The movement debit amount.</value>
        public decimal MovementDebitAmount { get; set; }
        /// <summary>
        /// Gets or sets the movement credit amount.
        /// </summary>
        /// <value>The movement credit amount.</value>
        public decimal MovementCreditAmount { get; set; }
        /// <summary>
        /// Gets or sets the LKDN debit amount.
        /// </summary>
        /// <value>The LKDN debit amount.</value>
        public decimal LKDN_DebitAmount { get; set; }
        /// <summary>
        /// Gets or sets the LKDN credit amount.
        /// </summary>
        /// <value>The LKDN credit amount.</value>
        public decimal LKDN_CreditAmount { get; set; }
        /// <summary>
        /// Gets or sets the closing debit amount.
        /// </summary>
        /// <value>The closing debit amount.</value>
        public decimal ClosingDebitAmount { get; set; }
        /// <summary>
        /// Gets or sets the closing credit amount.
        /// </summary>
        /// <value>The closing credit amount.</value>
        public decimal ClosingCreditAmount { get; set; }
    }
}
