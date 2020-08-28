/***********************************************************************
 * <copyright file="IFAIncrementDecrementView.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;

namespace Buca.Application.iBigTime2020.View.IncrementDecrement
{
    /// <summary>
    ///     IFAIncrementDecrementView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IFAIncrementDecrementView : IView
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
        ///     Gets or sets the generated reference identifier.
        /// </summary>
        /// <value>
        ///     The generated reference identifier.
        /// </value>
        string GeneratedRefId { get; set; }

        /// <summary>
        ///     Gets or sets the fa increment decrement details.
        /// </summary>
        /// <value>
        ///     The fa increment decrement details.
        /// </value>
        IList<FAIncrementDecrementDetailModel> FAIncrementDecrementDetails { get; set; }
    }
}