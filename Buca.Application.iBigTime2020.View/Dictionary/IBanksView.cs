/***********************************************************************
 * <copyright file="IBanksView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using System.Collections.Generic;


namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// IBanksView
    /// </summary>
    public interface IBanksView : IView
    {
        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>
        /// The banks.
        /// </value>
        IList<BankModel> Banks { set; }
    }
}