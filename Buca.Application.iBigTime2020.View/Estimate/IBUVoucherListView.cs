/***********************************************************************
 * <copyright file="IBUVoucherListView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, June 5, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;

namespace Buca.Application.iBigTime2020.View.Estimate
{
    /// <summary>
    ///     IBUVoucherListView
    /// </summary>
    public interface IBUVoucherListView
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
        ///     Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        ///     The paralell reference no.
        /// </value>
        string ParalellRefNo { get; set; }

        /// <summary>
        ///     Gets or sets from date.
        /// </summary>
        /// <value>
        ///     From date.
        /// </value>
        DateTime FromDate { get; set; }

        /// <summary>
        ///     Gets or sets to date.
        /// </summary>
        /// <value>
        ///     To date.
        /// </value>
        DateTime ToDate { get; set; }

        /// <summary>
        ///     Gets or sets the journal memo.
        /// </summary>
        /// <value>
        ///     The journal memo.
        /// </value>
        string JournalMemo { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="BUVoucherListEntity" /> is posted.
        /// </summary>
        /// <value>
        ///     <c>true</c> if posted; otherwise, <c>false</c>.
        /// </value>
        bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        ///     Gets or sets the total amount.
        /// </summary>
        /// <value>
        ///     The total amount.
        /// </value>
        decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        decimal TotalAmountOC { get; set; }

        /// <summary>
        ///     Gets or sets the post version.
        /// </summary>
        /// <value>
        ///     The post version.
        /// </value>

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
        ///     Gets or sets the bu voucher list detail models.
        /// </summary>
        /// <value>
        ///     The bu voucher list detail models.
        /// </value>
        IList<BUVoucherListDetailModel> BUVoucherListDetailModels { get; set; }

        /// <summary>
        ///     Gets or sets the bu voucher list detail parallel models.
        /// </summary>
        /// <value>
        ///     The bu voucher list detail parallel models.
        /// </value>
        IList<BUVoucherListDetailParallelModel> BUVoucherListDetailParallelModels { get; set; }

        /// <summary>
        ///     Gets or sets the bu voucher list detail transfer models.
        /// </summary>
        /// <value>
        ///     The bu voucher list detail transfer models.
        /// </value>
        IList<BUVoucherListDetailTransferModel> BUVoucherListDetailTransferModels { get; set; }
    }
}