/***********************************************************************
 * <copyright file="FAIncrementDecrementModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement
{
    /// <summary>
    ///     FAIncrementDecrementModel
    /// </summary>
    public class FAIncrementDecrementModel
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FAIncrementDecrementModel" /> class.
        /// </summary>
        public FAIncrementDecrementModel()
        {
            FAIncrementDecrementDetails = new List<FAIncrementDecrementDetailModel>();
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
        ///     Gets or sets the journal memo.
        /// </summary>
        /// <value>
        ///     The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        ///     Gets or sets the total amount.
        /// </summary>
        /// <value>
        ///     The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        ///     Gets or sets the generated reference identifier.
        /// </summary>
        /// <value>
        ///     The generated reference identifier.
        /// </value>
        public string GeneratedRefId { get; set; }

        /// <summary>
        ///     Gets or sets the fa increment decrement details.
        /// </summary>
        /// <value>
        ///     The fa increment decrement details.
        /// </value>
        public IList<FAIncrementDecrementDetailModel> FAIncrementDecrementDetails { get; set; }
    }
}