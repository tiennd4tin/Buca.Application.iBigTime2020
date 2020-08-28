/***********************************************************************
 * <copyright file="IMergerFundsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
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
    /// Interface IMergerFundsView
    /// </summary>
    public interface IMergerFundsView : IView
    {
        /// <summary>
        /// Sets the merger funds.
        /// </summary>
        /// <value>The merger funds.</value>
        IList<MergerFundModel> MergerFunds { set; }
    }
}
