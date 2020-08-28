/***********************************************************************
 * <copyright file="ItemTransactionEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Inventory
{
    /// <summary>
    /// ItemTransactionEntity
    /// </summary>
    public class INInwardOutwardModel
    {
        public INInwardOutwardModel()
        {
            InwardOutwardDetails = new List<INInwardOutwardDetailModel>();
        }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

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
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>The paralell reference no.</value>
        public string ParalellRefNo { get; set; }

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
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>The total tax amount.</value>
        public decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the generated reference identifier.
        /// </summary>
        /// <value>The generated reference identifier.</value>
        public string GeneratedRefId { get; set; }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int? RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the inward outward details.
        /// </summary>
        /// <value>The inward outward details.</value>
        public IList<INInwardOutwardDetailModel> InwardOutwardDetails { get; set; }
        /// <summary>
        /// Gets or sets the inward outward details paraller.
        /// </summary>
        /// <value>The inward outward details paraller.</value>
        public IList<INInwardOutwardDetailParallelModel> InwardOutwardDetailParallels { get; set; }
        /// <summary>
        /// Gets or sets the doument include.
        /// Kèm theo
        /// </summary>
        /// <value>The doument include.</value>
        public string DocumentInclued { get; set; }

        public string CurrencyCode { get; set; }
        /// <summary>
        ///     Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        ///     The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }
    }
}