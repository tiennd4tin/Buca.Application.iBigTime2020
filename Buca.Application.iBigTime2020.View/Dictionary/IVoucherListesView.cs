/***********************************************************************
 * <copyright file="IVoucherListsView.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;


namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// IVoucherListesView
    /// </summary>
    public interface IVoucherListesView : IView
    {
        /// <summary>
        /// Sets the automatic businesses.
        /// </summary>
        /// <value>
        /// The automatic businesses.
        /// </value>
        IList<VoucherListModel> VoucherListes { set; }
    }
}