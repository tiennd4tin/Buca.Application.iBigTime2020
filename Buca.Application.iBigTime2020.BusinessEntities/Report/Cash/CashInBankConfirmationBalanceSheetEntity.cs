/***********************************************************************
 * <copyright file="CashInBankConfirmationBalanceSheetEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, November 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, November 30, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Cash
{
    /// <summary>
    /// Class CashInBankConfirmationBalanceSheetEntity.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class CashInBankConfirmationBalanceSheetEntity: BusinessEntities
    {
        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        public string BankAccount { get; set; }
        /// <summary>
        /// Gets or sets the bank distribution code.
        /// </summary>
        /// <value>The bank distribution code.</value>
        public string BankDistributionCode { get; set; }
        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>The project identifier.</value>
        public string ProjectId { get; set; }
        /// <summary>
        /// Gets or sets the project code.
        /// </summary>
        /// <value>The project code.</value>
        public string ProjectCode { get; set; }
        /// <summary>
        /// Gets or sets the opening balance.
        /// </summary>
        /// <value>The opening balance.</value>
        public decimal OpeningBalance { get; set; }
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
        /// Gets or sets the closing balance.
        /// </summary>
        /// <value>The closing balance.</value>
        public decimal ClosingBalance { get; set; }
        /// <summary>
        /// Gets or sets the openning balance112.
        /// </summary>
        /// <value>The openning balance112.</value>
        public decimal OpenningBalance112 { get; set; }
        /// <summary>
        /// Gets or sets the movement debit112.
        /// </summary>
        /// <value>The movement debit112.</value>
        public decimal MovementDebit112 { get; set; }
        /// <summary>
        /// Gets or sets the movement credit112.
        /// </summary>
        /// <value>The movement credit112.</value>
        public decimal MovementCredit112 { get; set; }
        /// <summary>
        /// Gets or sets the closing balance112.
        /// </summary>
        /// <value>The closing balance112.</value>
        public decimal ClosingBalance112 { get; set; }
    }
}
