/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{

    /// <summary>
    /// VoucherListModel
    /// </summary>
    public class VoucherListModel
    {
        /// <summary>
        /// Gets or sets the voucher list identifier.
        /// </summary>
        /// <value>
        /// The voucher list identifier.
        /// </value>
        public string VoucherListId { get; set; }

        /// <summary>
        /// Gets or sets the voucher list code.
        /// </summary>
        /// <value>
        /// The voucher list code.
        /// </value>
        public string VoucherListCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the voucher list.
        /// </summary>
        /// <value>
        /// The name of the voucher list.
        /// </value>
        public string VoucherListName { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the document attached.
        /// </summary>
        /// <value>
        /// The document attached.
        /// </value>
        public string DocumentAttached { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
