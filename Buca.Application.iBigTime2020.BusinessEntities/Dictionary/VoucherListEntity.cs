/***********************************************************************
 * <copyright file="VoucherListEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 02 October 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// class VoucherListEntity
    /// </summary>
    public class VoucherListEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherListEntity"/> class.
        /// </summary>
        public VoucherListEntity()
        {
            AddRule(new ValidateRequired("VoucherListCode"));
            AddRule(new ValidateRequired("VoucherListName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherListEntity" /> class.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <param name="voucherListCode">The voucher list code.</param>
        /// <param name="voucherListName">Name of the voucher list.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="documentAttached">The document attached.</param>
        /// <param name="description">The description.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public VoucherListEntity(string voucherListId, string voucherListCode, string voucherListName, DateTime? fromDate, DateTime? toDate, string documentAttached, string description, bool isActive)
            : this()
        {
            VoucherListId = voucherListId;
            VoucherListCode = voucherListCode;
            VoucherListName = voucherListName;
            FromDate = fromDate;
            ToDate = toDate;
            DocumentAttached = documentAttached;
            Description = description;
            IsActive = isActive;
        }

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

        public bool IsActive { get; set; }
    }
}
