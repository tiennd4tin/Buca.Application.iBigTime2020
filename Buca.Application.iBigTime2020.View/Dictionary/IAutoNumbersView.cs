/***********************************************************************
 * <copyright file="IAutoNumbersView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 20 May 2014
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
    /// IAutoNumbersView
    /// </summary>
    public interface IAutoNumbersView : IView
    {
        /// <summary>
        /// Gets or sets the automatic numbers.
        /// </summary>
        /// <value>
        /// The automatic numbers.
        /// </value>
        IList<AutoIDModel> AutoNumbers { get; set; }
    }
}
