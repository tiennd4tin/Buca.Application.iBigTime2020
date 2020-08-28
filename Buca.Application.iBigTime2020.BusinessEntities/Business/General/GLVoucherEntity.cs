/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.General
{
    /// <summary>
    /// GLVoucherEntity
    /// </summary>
    public class GLVoucherEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GLVoucherEntity"/> class.
        /// </summary>
        public GLVoucherEntity()
        {
            AddRule(new ValidateRequired("RefType"));
            AddRule(new ValidateRequired("RefDate"));
        }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }
        public bool Approved { get; set; }
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
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        /// The paralell reference no.
        /// </value>
        public string ParalellRefNo { get; set; }

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
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the parent reference identifier.
        /// </summary>
        /// <value>
        /// The parent reference identifier.
        /// </value>
        public string ParentRefId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [posted].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [posted]; otherwise, <c>false</c>.
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
        /// Gets or sets the advance payment order.
        /// </summary>
        /// <value>
        /// The advance payment order.
        /// </value>
        public int? AdvancePaymentOrder { get; set; }

        public string BUTransferRefId { get; set; }

        public int BUTransferType { get; set; }
        public string LinkRefNo { get; set; }

        /// <summary>
        /// Gets or sets the gl voucher details.
        /// </summary>
        /// <value>
        /// The gl voucher details.
        /// </value>
        public IList<GLVoucherDetailEntity> GLVoucherDetails { get; set; }

        /// <summary>
        /// Gets or sets the gl voucher detail taxes.
        /// </summary>
        /// <value>
        /// The gl voucher detail taxes.
        /// </value>
        public IList<GLVoucherDetailTaxEntity> GLVoucherDetailTaxes { get; set; }

        /// <summary>
        /// Gets or sets the gl voucher detail parallels.
        /// </summary>
        /// <value>The gl voucher detail parallels.</value>
        public IList<GLVoucherDetailParallelEntity> GLVoucherDetailParallels { get; set; }
    }
}
