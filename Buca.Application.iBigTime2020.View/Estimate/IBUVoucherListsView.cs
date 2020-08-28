/***********************************************************************
 * <copyright file="IBUVoucherListsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, June 5, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;

namespace Buca.Application.iBigTime2020.View.Estimate
{
    /// <summary>
    ///     IBUVoucherListsView
    /// </summary>
    public interface IBUVoucherListsView
    {
        /// <summary>
        ///     Sets the bu voucher list models.
        /// </summary>
        /// <value>
        ///     The bu voucher list models.
        /// </value>
        IList<BUVoucherListModel> BUVoucherListModels { set; }
    }
}