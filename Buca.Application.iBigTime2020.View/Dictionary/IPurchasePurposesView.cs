/***********************************************************************
 * <copyright file="ipurchasepurposesview.cs" company="BUCA JSC">
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
    ///     IPurchasePurposesView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IPurchasePurposesView : IView
    {
        /// <summary>
        ///     Gets the purchase purposes.
        /// </summary>
        /// <value>
        ///     The purchase purposes.
        /// </value>
        IList<PurchasePurposeModel> PurchasePurposes { set; }
    }
}