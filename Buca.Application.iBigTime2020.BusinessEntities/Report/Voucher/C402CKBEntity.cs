/***********************************************************************
 * <copyright file="C402CKBEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, November 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    /// <summary>
    ///     C402CKBEntity
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class C402CKBEntity : BusinessEntities
    {
        /// <summary>
        ///     Gets or sets the account in bank.
        /// </summary>
        /// <value>
        ///     The account in bank.
        /// </value>
        public string AccountInBank { get; set; }

        /// <summary>
        ///     Gets or sets the bank account.
        /// </summary>
        /// <value>
        ///     The bank account.
        /// </value>
        public string BankAccount { get; set; }

        /// <summary>
        ///     Gets or sets the name of the receipt object.
        /// </summary>
        /// <value>
        ///     The name of the receipt object.
        /// </value>
        public string ReceiptObjectName { get; set; }

        /// <summary>
        ///     Gets or sets the receipt code.
        /// </summary>
        /// <value>
        ///     The receipt code.
        /// </value>
        public string ReceiptCode { get; set; }


        /// <summary>
        ///     Gets or sets the accounting object address.
        /// </summary>
        /// <value>
        ///     The accounting object address.
        /// </value>
        public string AccountingObjectAddress { get; set; }

        /// <summary>
        ///     Gets or sets the accounting object bank account.
        /// </summary>
        /// <value>
        ///     The accounting object bank account.
        /// </value>
        public string AccountingObjectBankAccount { get; set; }

        /// <summary>
        ///     Gets or sets the receipt target program.
        /// </summary>
        /// <value>
        ///     The receipt target program.
        /// </value>
        public string ReceiptTargetProgram { get; set; }

        /// <summary>
        ///     Gets or sets the receipt account in bank.
        /// </summary>
        /// <value>
        ///     The receipt account in bank.
        /// </value>
        public string ReceiptAccountInBank { get; set; }
        public string ActivityCode { get; set; }
        public string ActivityGrade { get; set; }

        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        ///     Gets or sets the reference no.
        /// </summary>
        /// <value>
        ///     The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        ///     Gets or sets the reference date.
        /// </summary>
        /// <value>
        ///     The reference date.
        /// </value>
        public DateTime RefDate { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the description replaced.
        /// </summary>
        /// <value>
        ///     The description replaced.
        /// </value>
        public string DescriptionReplaced { get; set; }

        /// <summary>
        ///     Gets or sets the tax.
        /// </summary>
        /// <value>
        ///     The tax.
        /// </value>
        public decimal Tax { get; set; }

        /// <summary>
        ///     Gets or sets the payment.
        /// </summary>
        /// <value>
        ///     The payment.
        /// </value>
        public decimal Payment { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>
        ///     The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Gets or sets the edit version.
        /// </summary>
        /// <value>
        ///     The edit version.
        /// </value>
        public int EditVersion { get; set; }
        public string CurencyCode { get; set; }
        public int RefType { get; set; }
        public bool IsOpenInBank { get; set; }
        public string BudgetCode { get; set; }
        public string BudgetChapterCode { get; set; }
        public string ProjectBankName { get; set; }
        public string ProjectName { get; set; }
        public string Investment { get; set; }
        public string ProjectBankAccount { get; set; }
        public int CashWithDrawTypeID { get; set; }
        public string OrgRefNo { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string ReceiveName { get; set; }
        public string ReceiveId { get; set; }
        public string ReceiveIssueLocation { get; set; }
        public string ReceiveIssueDate { get; set; }
    }
}