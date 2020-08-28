/***********************************************************************
 * <copyright file="IBAWithDrawsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 23, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;

namespace Buca.Application.iBigTime2020.View.Deposit
{
    /// <summary>
    ///     IBAWithDrawsView
    /// </summary>
    public interface IBAWithDrawsView : IView
    {
        /// <summary>
        ///     Sets the ba with draws.
        /// </summary>
        /// <value>
        ///     The ba with draws.
        /// </value>
        IList<BAWithDrawModel> BaWithDraws { set; }
    }
}