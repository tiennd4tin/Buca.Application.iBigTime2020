/***********************************************************************
 * <copyright file="ICalculateClosingsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Tuesday, December 23, 2014
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
    /// ICalculateClosingsView
    /// </summary>
    public interface ICalculateClosingsView : IView
    {
        /// <summary>
        /// Gets or sets the Calculate Closings.
        /// </summary>
        /// <value>
        /// The Calculate Closings.
        /// </value>
        IList<CalculateClosingModel> CalculateClosings { get; set; }
    }
}
