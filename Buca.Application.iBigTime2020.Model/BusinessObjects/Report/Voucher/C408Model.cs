/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/11/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
 
namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher
{
    /// <summary>
    /// C408Model
    /// </summary>
   public class C408Model
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the debit account.
        /// </summary>
        /// <value>The debit account.</value>
        public string DebitAccount { get; set; }

        /// <summary>
        /// Gets or sets the credit account.
        /// </summary>
        /// <value>The credit account.</value>
        public string CreditAccount { get; set; }

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
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>
        /// The name of the accounting object.
        /// </value>
        public string AccountingObjectName { get; set; }

        /// <summary>
        /// Gets or sets the accounting object address.
        /// </summary>
        /// <value>
        /// The accounting object address.
        /// </value>
        public string AccountingObjectAddress { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>The details.</value>
        public IList<C408DetailModel> C408Details { get; set; }

       /// <summary>
        /// Gets or sets the debit account all.
        /// </summary>
        /// <value>The debit account all.</value>
        public string DebitAccountAll { get; set; }

        /// <summary>
        /// Gets or sets the credit account all.
        /// </summary>
        /// <value>The credit account all.</value>
        public string CreditAccountAll { get; set; }

        /// <summary>
        /// Gets or sets the sum amount oc.
        /// </summary>
        /// <value>The sum amount oc.</value>
        public decimal SumAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the sum amount.
        /// </summary>
        /// <value>The sum amount.</value>
        public decimal SumAmount { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>
        /// The amount oc.
        /// </value>
        public decimal AmountOC { get; set; }

        public string Receiver { get; set; }
        public string Payer { get; set; }
    }
}
