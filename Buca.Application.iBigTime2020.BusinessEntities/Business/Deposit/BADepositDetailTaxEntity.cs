/***********************************************************************
 * <copyright file="BADepositDetailTaxEntity.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit
{
    /// <summary>
    /// BADepositDetailTaxEntity
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class BADepositDetailTaxEntity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>
        /// The reference detail identifier.
        /// </value>
        public string RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the vat amount.
        /// </summary>
        /// <value>
        /// The vat amount.
        /// </value>
        public decimal VATAmount { get; set; }

        /// <summary>
        /// Gets or sets the vat rate.
        /// </summary>
        /// <value>
        /// The vat rate.
        /// </value>
        public decimal? VATRate { get; set; }

        /// <summary>
        /// Gets or sets the turn over.
        /// </summary>
        /// <value>
        /// The turn over.
        /// </value>
        public decimal TurnOver { get; set; }

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
        /// Gets or sets the purchase purpose identifier.
        /// </summary>
        /// <value>
        /// The purchase purpose identifier.
        /// </value>
        public string PurchasePurposeId { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>
        /// The name of the accounting object.
        /// </value>
        public string AccountingObjectName { get; set; }

        /// <summary>
        /// Gets or sets the accounting object address.
        /// </summary>
        /// <value>
        /// The accounting object address.
        /// </value>
        public string AccountingObjectAddress { get; set; }

        /// <summary>
        /// Gets or sets the company tax code.
        /// </summary>
        /// <value>
        /// The company tax code.
        /// </value>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int? SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the invoice type code.
        /// </summary>
        /// <value>
        /// The invoice type code.
        /// </value>
        public string InvoiceTypeCode { get; set; }
    }
}