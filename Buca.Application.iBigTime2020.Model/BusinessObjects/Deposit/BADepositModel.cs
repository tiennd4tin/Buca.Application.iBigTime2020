/***********************************************************************
 * <copyright file="BADepositModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 18, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit
{
    /// <summary>
    ///     BADepositModel
    /// </summary>
    public class BADepositModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BADepositModel"/> class.
        /// </summary>
        public BADepositModel()
        {
            BADepositDetailModels = new List<BADepositDetailModel>();
            BADepositDetailFixedAssetModels = new List<BADepositDetailFixedAssetModel>();
            BADepositDetailSaleModels = new List<BADepositDetailSaleModel>();
            BADepositDetailTaxModels = new List<BADepositDetailTaxModel>();
            BADepositDetailParallels = new List<BADepositDetailParallelModel>();
        }
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
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        /// The paralell reference no.
        /// </value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the outward reference no.
        /// </summary>
        /// <value>
        /// The outward reference no.
        /// </value>
        public string OutwardRefNo { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets the type of the inv.
        /// </summary>
        /// <value>
        /// The type of the inv.
        /// </value>
        public int? InvType { get; set; }

        /// <summary>
        /// Gets or sets the inv date.
        /// </summary>
        /// <value>
        /// The inv date.
        /// </value>
        public DateTime? InvDate { get; set; }

        /// <summary>
        /// Gets or sets the inv series.
        /// </summary>
        /// <value>
        /// The inv series.
        /// </value>
        public string InvSeries { get; set; }

        /// <summary>
        /// Gets or sets the inv no.
        /// </summary>
        /// <value>
        /// The inv no.
        /// </value>
        public string InvNo { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        /// The total amount oc.
        /// </value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>
        /// The total tax amount.
        /// </value>
        public decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the total outward amount.
        /// </summary>
        /// <value>
        /// The total outward amount.
        /// </value>
        public decimal TotalOutwardAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BADepositEntity"/> is reconciled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if reconciled; otherwise, <c>false</c>.
        /// </value>
        public bool Reconciled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BADepositEntity"/> is posted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if posted; otherwise, <c>false</c>.
        /// </value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>
        /// The post version.
        /// </value>
        public int? PostVersion { get; set; }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>
        /// The edit version.
        /// </value>
        public int? EditVersion { get; set; }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>
        /// The reference order.
        /// </value>
        public int? RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the invoice form.
        /// </summary>
        /// <value>
        /// The invoice form.
        /// </value>
        public int? InvoiceForm { get; set; }

        /// <summary>
        /// Gets or sets the invoice form number identifier.
        /// </summary>
        /// <value>
        /// The invoice form number identifier.
        /// </value>
        public string InvoiceFormNumberId { get; set; }

        /// <summary>
        /// Gets or sets the inv series prefix.
        /// </summary>
        /// <value>
        /// The inv series prefix.
        /// </value>
        public string InvSeriesPrefix { get; set; }

        /// <summary>
        /// Gets or sets the inv series suffix.
        /// </summary>
        /// <value>
        /// The inv series suffix.
        /// </value>
        public string InvSeriesSuffix { get; set; }

        /// <summary>
        /// Gets or sets the pay form.
        /// </summary>
        /// <value>
        /// The pay form.
        /// </value>
        public string PayForm { get; set; }

        /// <summary>
        /// Gets or sets the COM pany taxcode.
        /// </summary>
        /// <value>
        /// The COM pany taxcode.
        /// </value>
        public string ComPanyTaxcode { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object contact.
        /// </summary>
        /// <value>
        /// The name of the accounting object contact.
        /// </value>
        public string AccountingObjectContactName { get; set; }

        /// <summary>
        /// Gets or sets the list no.
        /// </summary>
        /// <value>
        /// The list no.
        /// </value>
        public string ListNo { get; set; }

        /// <summary>
        /// Gets or sets the list date.
        /// </summary>
        /// <value>
        /// The list date.
        /// </value>
        public DateTime? ListDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is attach list.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is attach list; otherwise, <c>false</c>.
        /// </value>
        public bool IsAttachList { get; set; }

        /// <summary>
        /// Gets or sets the list common name inventory.
        /// </summary>
        /// <value>
        /// The list common name inventory.
        /// </value>
        public string ListCommonNameInventory { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>
        /// The bu commitment request identifier.
        /// </value>
        public string BUCommitmentRequestId { get; set; }

        /// <summary>
        /// Gets or sets the total receipt amount.
        /// </summary>
        /// <value>
        /// The total receipt amount.
        /// </value>
        public decimal TotalReceiptAmount { get; set; }

        /// <summary>
        /// Gets or sets the ba deposit details.
        /// </summary>
        /// <value>
        /// The ba deposit details.
        /// </value>
        public IList<BADepositDetailModel> BADepositDetailModels { get; set; }

        /// <summary>
        /// Gets or sets the ba deposit detail fixed asset entities.
        /// </summary>
        /// <value>
        /// The ba deposit detail fixed asset entities.
        /// </value>
        public IList<BADepositDetailFixedAssetModel> BADepositDetailFixedAssetModels { get; set; }

        /// <summary>
        /// Gets or sets the ba deposit detail sale entities.
        /// </summary>
        /// <value>
        /// The ba deposit detail sale entities.
        /// </value>
        public IList<BADepositDetailSaleModel> BADepositDetailSaleModels { get; set; }

        /// <summary>
        /// Gets or sets the ba deposit detail tax entities.
        /// </summary>
        /// <value>
        /// The ba deposit detail tax entities.
        /// </value>
        public IList<BADepositDetailTaxModel> BADepositDetailTaxModels { get; set; }

        /// <summary>
        /// Gets or sets the ba deposit detail parallels.
        /// </summary>
        /// <value>The ba deposit detail parallels.</value>
        public IList<BADepositDetailParallelModel> BADepositDetailParallels { get; set; }

        public string Payer { get; set; }
    }
}