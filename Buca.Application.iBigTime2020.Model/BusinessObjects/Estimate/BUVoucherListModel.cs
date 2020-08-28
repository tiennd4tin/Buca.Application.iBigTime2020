/***********************************************************************
 * <copyright file="BUVoucherListModel.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate
{
    /// <summary>
    ///     BUVoucherListModel
    /// </summary>
    public class BUVoucherListModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BUVoucherListModel" /> class.
        /// </summary>
        public BUVoucherListModel()
        {
            BUVoucherListDetailModels = new List<BUVoucherListDetailModel>();
            BUVoucherListDetailParallelModels = new List<BUVoucherListDetailParallelModel>();
            BUVoucherListDetailTransferModels = new List<BUVoucherListDetailTransferModel>();
        }

        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        ///     The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        ///     Gets or sets the reference date.
        /// </summary>
        /// <value>
        ///     The reference date.
        /// </value>
        public DateTime RefDate { get; set; }

        /// <summary>
        ///     Gets or sets the posted date.
        /// </summary>
        /// <value>
        ///     The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        ///     Gets or sets the reference no.
        /// </summary>
        /// <value>
        ///     The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        ///     Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        ///     The paralell reference no.
        /// </value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        ///     Gets or sets from date.
        /// </summary>
        /// <value>
        ///     From date.
        /// </value>
        public DateTime FromDate { get; set; }

        /// <summary>
        ///     Gets or sets to date.
        /// </summary>
        /// <value>
        ///     To date.
        /// </value>
        public DateTime ToDate { get; set; }

        /// <summary>
        ///     Gets or sets the journal memo.
        /// </summary>
        /// <value>
        ///     The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="BUVoucherListEntity" /> is posted.
        /// </summary>
        /// <value>
        ///     <c>true</c> if posted; otherwise, <c>false</c>.
        /// </value>
        public bool Posted { get; set; }

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
        ///     Gets or sets the total amount.
        /// </summary>
        /// <value>
        ///     The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        ///     Gets or sets the post version.
        /// </summary>
        /// <value>
        ///     The post version.
        /// </value>
        public int? PostVersion { get; set; }

        /// <summary>
        ///     Gets or sets the edit version.
        /// </summary>
        /// <value>
        ///     The edit version.
        /// </value>
        public int? EditVersion { get; set; }

        /// <summary>
        ///     Gets or sets the bu voucher list detail models.
        /// </summary>
        /// <value>
        ///     The bu voucher list detail models.
        /// </value>
        public IList<BUVoucherListDetailModel> BUVoucherListDetailModels { get; set; }

        /// <summary>
        ///     Gets or sets the bu voucher list detail parallel models.
        /// </summary>
        /// <value>
        ///     The bu voucher list detail parallel models.
        /// </value>
        public IList<BUVoucherListDetailParallelModel> BUVoucherListDetailParallelModels { get; set; }

        /// <summary>
        ///     Gets or sets the bu voucher list detail transfer models.
        /// </summary>
        /// <value>
        ///     The bu voucher list detail transfer models.
        /// </value>
        public IList<BUVoucherListDetailTransferModel> BUVoucherListDetailTransferModels { get; set; }


    }
}