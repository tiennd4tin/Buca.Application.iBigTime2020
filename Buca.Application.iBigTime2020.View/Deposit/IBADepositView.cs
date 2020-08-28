/***********************************************************************
 * <copyright file="ibadepositview.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 19, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;

namespace Buca.Application.iBigTime2020.View.Deposit
{
    /// <summary>
    ///     IBADepositView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IBADepositView : IView
    {
        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        string RefId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        ///     The type of the reference.
        /// </value>
        int RefType { get; set; }

        /// <summary>
        ///     Gets or sets the reference date.
        /// </summary>
        /// <value>
        ///     The reference date.
        /// </value>
        DateTime RefDate { get; set; }

        /// <summary>
        ///     Gets or sets the posted date.
        /// </summary>
        /// <value>
        ///     The posted date.
        /// </value>
        DateTime PostedDate { get; set; }

        /// <summary>
        ///     Gets or sets the reference no.
        /// </summary>
        /// <value>
        ///     The reference no.
        /// </value>
        string RefNo { get; set; }

        /// <summary>
        ///     Gets or sets the currency code.
        /// </summary>
        /// <value>
        ///     The currency code.
        /// </value>
        string CurrencyCode { get; set; }

        /// <summary>
        ///     Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        ///     The exchange rate.
        /// </value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        ///     Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        ///     The paralell reference no.
        /// </value>
        string ParalellRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the outward reference no.
        /// </summary>
        /// <value>
        ///     The outward reference no.
        /// </value>
        string OutwardRefNo { get; set; }

        /// <summary>
        ///     Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        ///     The accounting object identifier.
        /// </value>
        string AccountingObjectId { get; set; }

        /// <summary>
        ///     Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        ///     The bank identifier.
        /// </value>
        string BankId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the inv.
        /// </summary>
        /// <value>
        ///     The type of the inv.
        /// </value>
        int? InvType { get; set; }

        /// <summary>
        ///     Gets or sets the inv date.
        /// </summary>
        /// <value>
        ///     The inv date.
        /// </value>
        DateTime? InvDate { get; set; }

        /// <summary>
        ///     Gets or sets the inv series.
        /// </summary>
        /// <value>
        ///     The inv series.
        /// </value>
        string InvSeries { get; set; }

        /// <summary>
        ///     Gets or sets the inv no.
        /// </summary>
        /// <value>
        ///     The inv no.
        /// </value>
        string InvNo { get; set; }

        /// <summary>
        ///     Gets or sets the journal memo.
        /// </summary>
        /// <value>
        ///     The journal memo.
        /// </value>
        string JournalMemo { get; set; }

        /// <summary>
        ///     Gets or sets the total amount.
        /// </summary>
        /// <value>
        ///     The total amount.
        /// </value>
        decimal TotalAmount { get; set; }

        /// <summary>
        ///     Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        ///     The total amount oc.
        /// </value>
        decimal TotalAmountOC { get; set; }

        /// <summary>
        ///     Gets or sets the total tax amount.
        /// </summary>
        /// <value>
        ///     The total tax amount.
        /// </value>
        decimal TotalTaxAmount { get; set; }

        /// <summary>
        ///     Gets or sets the total outward amount.
        /// </summary>
        /// <value>
        ///     The total outward amount.
        /// </value>
        decimal TotalOutwardAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IBADepositView"/> is reconciled.
        /// </summary>
        /// <value><c>true</c> if reconciled; otherwise, <c>false</c>.</value>
        bool Reconciled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IBADepositView"/> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        bool Posted { get; set; }

        /// <summary>
        ///     Gets or sets the post version.
        /// </summary>
        /// <value>
        ///     The post version.
        /// </value>
        int? PostVersion { get; set; }

        /// <summary>
        ///     Gets or sets the edit version.
        /// </summary>
        /// <value>
        ///     The edit version.
        /// </value>
        int? EditVersion { get; set; }

        /// <summary>
        ///     Gets or sets the reference order.
        /// </summary>
        /// <value>
        ///     The reference order.
        /// </value>
        int? RefOrder { get; set; }

        /// <summary>
        ///     Gets or sets the invoice form.
        /// </summary>
        /// <value>
        ///     The invoice form.
        /// </value>
        int? InvoiceForm { get; set; }

        /// <summary>
        ///     Gets or sets the invoice form number identifier.
        /// </summary>
        /// <value>
        ///     The invoice form number identifier.
        /// </value>
        string InvoiceFormNumberId { get; set; }

        /// <summary>
        ///     Gets or sets the inv series prefix.
        /// </summary>
        /// <value>
        ///     The inv series prefix.
        /// </value>
        string InvSeriesPrefix { get; set; }

        /// <summary>
        ///     Gets or sets the inv series suffix.
        /// </summary>
        /// <value>
        ///     The inv series suffix.
        /// </value>
        string InvSeriesSuffix { get; set; }

        /// <summary>
        ///     Gets or sets the pay form.
        /// </summary>
        /// <value>
        ///     The pay form.
        /// </value>
        string PayForm { get; set; }

        /// <summary>
        ///     Gets or sets the COM pany taxcode.
        /// </summary>
        /// <value>
        ///     The COM pany taxcode.
        /// </value>
        string ComPanyTaxcode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the accounting object contact.
        /// </summary>
        /// <value>
        ///     The name of the accounting object contact.
        /// </value>
        string AccountingObjectContactName { get; set; }

        /// <summary>
        ///     Gets or sets the list no.
        /// </summary>
        /// <value>
        ///     The list no.
        /// </value>
        string ListNo { get; set; }

        /// <summary>
        ///     Gets or sets the list date.
        /// </summary>
        /// <value>
        ///     The list date.
        /// </value>
        DateTime? ListDate { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is attach list.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is attach list; otherwise, <c>false</c>.
        /// </value>
        bool IsAttachList { get; set; }

        /// <summary>
        ///     Gets or sets the list common name inventory.
        /// </summary>
        /// <value>
        ///     The list common name inventory.
        /// </value>
        string ListCommonNameInventory { get; set; }

        /// <summary>
        ///     Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>
        ///     The bu commitment request identifier.
        /// </value>
        string BUCommitmentRequestId { get; set; }

        /// <summary>
        ///     Gets or sets the total receipt amount.
        /// </summary>
        /// <value>
        ///     The total receipt amount.
        /// </value>
        decimal TotalReceiptAmount { get; set; }
        string Payer { get; set; }

        /// <summary>
        ///     Gets or sets the ba deposit details.
        /// </summary>
        /// <value>
        ///     The ba deposit details.
        /// </value>
        IList<BADepositDetailModel> BADepositDetails { get; set; }

        /// <summary>
        ///     Gets or sets the ba deposit detail fixed asset entities.
        /// </summary>
        /// <value>
        ///     The ba deposit detail fixed asset entities.
        /// </value>
        IList<BADepositDetailFixedAssetModel> BADepositDetailFixedAssets { get; set; }

        /// <summary>
        ///     Gets or sets the ba deposit detail sale entities.
        /// </summary>
        /// <value>
        ///     The ba deposit detail sale entities.
        /// </value>
        IList<BADepositDetailSaleModel> BADepositDetailSales { get; set; }

        /// <summary>
        ///     Gets or sets the ba deposit detail tax entities.
        /// </summary>
        /// <value>
        ///     The ba deposit detail tax entities.
        /// </value>
        IList<BADepositDetailTaxModel> BADepositDetailTaxs { get; set; }

        /// <summary>
        /// Gets or sets the ba deposit detail parallels.
        /// </summary>
        /// <value>The ba deposit detail parallels.</value>
        IList<BADepositDetailParallelModel> BADepositDetailParallels { get; set; }
    }
}