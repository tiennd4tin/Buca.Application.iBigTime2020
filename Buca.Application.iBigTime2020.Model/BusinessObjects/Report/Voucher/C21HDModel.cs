/***********************************************************************
 * <copyright file="C21HDModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, November 9, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, November 9, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher
{
    /// <summary>
    /// Class C21HDModel.
    /// </summary>
    public class C21HDModel
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
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
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime PostedDate { get; set; }
        /// <summary>
        /// Gets or sets the receiver.
        /// </summary>
        /// <value>The receiver.</value>
        public string Receiver { get; set; }
        /// <summary>
        /// Gets or sets the receiver address.
        /// </summary>
        /// <value>The receiver address.</value>
        public string ReceiverAddress { get; set; }
        /// <summary>
        /// Gets or sets the stock identifier.
        /// </summary>
        /// <value>The stock identifier.</value>
        public string StockId { get; set; }
        /// <summary>
        /// Gets or sets the name of the stock.
        /// </summary>
        /// <value>The name of the stock.</value>
        public string StockName { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the debit accounts.
        /// </summary>
        /// <value>The debit accounts.</value>
        public string DebitAccounts { get; set; }
        /// <summary>
        /// Gets or sets the credit accounts.
        /// </summary>
        /// <value>The credit accounts.</value>
        public string CreditAccounts { get; set; }
        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>The details.</value>
        public IList<C21HDDetailModel> Details { get; set; }
        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Gets or sets the document include.
        /// </summary>
        /// <value>The document include.</value>
        public string DocumentInclude { get; set; }
        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo { get; set; }
    }
}
