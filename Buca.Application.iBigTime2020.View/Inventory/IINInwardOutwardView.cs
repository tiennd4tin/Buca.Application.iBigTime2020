/***********************************************************************
 * <copyright file="IReceiptVoucherView.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Inventory;

namespace Buca.Application.iBigTime2020.View.Inventory
{
    /// <summary>
    /// IReceiptVoucherView interface
    /// </summary>
    public interface IINInwardOutwardView : IView
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>The paralell reference no.</value>
        string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>The total tax amount.</value>
        decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the generated reference identifier.
        /// </summary>
        /// <value>The generated reference identifier.</value>
        string GeneratedRefId { get; set; }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        int? RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the inward outward details.
        /// </summary>
        /// <value>The inward outward details.</value>
        IList<INInwardOutwardDetailModel> InwardOutwardDetails { get; set; }
        ///<summary>
        ///Gets or sets the inward outward details Parallel
        /// </summary>
        /// <value>The inward outward detail parallel</value>
        IList<INInwardOutwardDetailParallelModel> INInwardOutwardDetailParallels { get; set; }
        /// <summary>
        /// Gets or sets the doument include.
        /// Kèm theo
        /// </summary>
        /// <value>The doument include.</value>
        string DocumentInclued { get; set; }

        string CurrencyCode { get; set; }
        /// <summary>
        ///     Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        ///     The exchange rate.
        /// </value>
        decimal ExchangeRate { get; set; }

    }
}
