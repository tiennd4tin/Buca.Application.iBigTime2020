/***********************************************************************
 * <copyright file="CashEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;


namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Cash
{
    /// <summary>
    /// PaymentCashEntity class
    /// </summary>
    public class CAReceiptEntity : BusinessEntities
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CAReceiptEntity"/> class.
        /// </summary>
        public CAReceiptEntity()
        {
            AddRule(new ValidateRequired("RefType"));
            AddRule(new ValidateRequired("RefDate"));
        }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
           public string Address { get; set; }
        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }

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
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>The paralell reference no.</value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the outward reference no.
        /// </summary>
        /// <value>The outward reference no.</value>
        public string OutwardRefNo { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the document included.
        /// </summary>
        /// <value>The document included.</value>
        public string DocumentIncluded { get; set; }

        /// <summary>
        /// Gets or sets the type of the inv.
        /// </summary>
        /// <value>The type of the inv.</value>
        public int? InvType { get; set; }

        /// <summary>
        /// Gets or sets the inv date or withdraw reference date.
        /// </summary>
        /// <value>The inv date or withdraw reference date.</value>
        public DateTime? InvDateOrWithdrawRefDate { get; set; }

        /// <summary>
        /// Gets or sets the inv series.
        /// </summary>
        /// <value>The inv series.</value>
        public string InvSeries { get; set; }

        /// <summary>
        /// Gets or sets the inv no or withdraw reference no.
        /// </summary>
        /// <value>The inv no or withdraw reference no.</value>
        public string InvNoOrWithdrawRefNo { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>The total tax amount.</value>
        public decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the total outward amount.
        /// </summary>
        /// <value>The total outward amount.</value>
        public decimal TotalOutwardAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CAReceiptEntity"/> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int? RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the invoice form.
        /// </summary>
        /// <value>The invoice form.</value>
        public int? InvoiceForm { get; set; }

        /// <summary>
        /// Gets or sets the invoice form number identifier.
        /// </summary>
        /// <value>The invoice form number identifier.</value>
        public string InvoiceFormNumberId { get; set; }

        /// <summary>
        /// Gets or sets the inv series prefix.
        /// </summary>
        /// <value>The inv series prefix.</value>
        public string InvSeriesPrefix { get; set; }

        /// <summary>
        /// Gets or sets the inv series suffix.
        /// </summary>
        /// <value>The inv series suffix.</value>
        public string InvSeriesSuffix { get; set; }

        /// <summary>
        /// Gets or sets the pay form.
        /// </summary>
        /// <value>The pay form.</value>
        public string PayForm { get; set; }

        /// <summary>
        /// Gets or sets the company taxcode.
        /// </summary>
        /// <value>The company taxcode.</value>
        public string CompanyTaxcode { get; set; }

        /// <summary>
        /// Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>The relation reference identifier.</value>
        public string RelationRefId { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>The bu commitment request identifier.</value>
        public string BUCommitmentRequestId { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object contact.
        /// </summary>
        /// <value>The name of the accounting object contact.</value>
        public string AccountingObjectContactName { get; set; }

        /// <summary>
        /// Gets or sets the list no.
        /// </summary>
        /// <value>The list no.</value>
        public string ListNo { get; set; }

        /// <summary>
        /// Gets or sets the list date.
        /// </summary>
        /// <value>The list date.</value>
        public DateTime? ListDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is attach list.
        /// </summary>
        /// <value><c>true</c> if this instance is attach list; otherwise, <c>false</c>.</value>
        public bool IsAttachList { get; set; }

        /// <summary>
        /// Gets or sets the list common name inventory.
        /// </summary>
        /// <value>The list common name inventory.</value>
        public string ListCommonNameInventory { get; set; }

        /// <summary>
        /// Gets or sets the total receipt amount.
        /// </summary>
        /// <value>The total receipt amount.</value>
        public decimal TotalReceiptAmount { get; set; }

        /// <summary>
        /// Gets or sets the ca receipt detail entities.
        /// </summary>
        /// <value>The ca receipt detail entities.</value>
        public IList<CAReceiptDetailEntity> CAReceiptDetails { get; set; }

        /// <summary>
        /// Gets or sets the ca receipt detail tax.
        /// </summary>
        /// <value>The ca receipt detail tax.</value>
        public IList<CAReceiptDetailTaxEntity> CAReceiptDetailTaxes { get; set; }

        /// <summary>
        /// Gets or sets the ca receipt detail parallels.
        /// </summary>
        /// <value>The ca receipt detail parallels.</value>
        public IList<CAReceiptDetailParallelEntity> CAReceiptDetailParallels { get; set; }

        /// <summary>
        /// Id Liên kết: rút dự toán tiền mặt - phiếu thu từ ngân sách nhà nước
        /// </summary>
        public string BUPlanWithdrawRefId { get; set; }

        public string Payer { get; set; }
    }
}
