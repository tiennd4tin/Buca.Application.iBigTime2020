/***********************************************************************
 * <copyright file="ipurchasepurposeview.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 12, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    ///     IPurchasePurposeView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IPurchasePurposeView : IView
    {
        /// <summary>
        /// Gets or sets the stock identifier.
        /// </summary>
        /// <value>The stock identifier.</value>
        string PurchasePurposeId { get; set; }

        /// <summary>
        /// Gets or sets the stock code.
        /// </summary>
        /// <value>The stock code.</value>
        string PurchasePurposeCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the stock.
        /// </summary>
        /// <value>The name of the stock.</value>
        string PurchasePurposeName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        bool IsActive { get; set; }
    }
}