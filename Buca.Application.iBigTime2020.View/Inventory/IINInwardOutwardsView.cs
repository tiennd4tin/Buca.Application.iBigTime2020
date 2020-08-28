/***********************************************************************
 * <copyright file="IReceiptVouchersView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Inventory;

namespace Buca.Application.iBigTime2020.View.Inventory
{
    /// <summary>
    /// Interface IINInwardOutwardsView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IINInwardOutwardsView : IView
    {
        /// <summary>
        /// Sets the in inward outwards.
        /// </summary>
        /// <value>The in inward outwards.</value>
        IList<INInwardOutwardModel> INInwardOutwards { set; }
    }
}
