/***********************************************************************
 * <copyright file="ISUIncrementDecrementsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 25, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;

namespace Buca.Application.iBigTime2020.View.IncrementDecrement
{
    /// <summary>
    ///     ISUIncrementDecrementsView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface ISUIncrementDecrementsView : IView
    {
        /// <summary>
        ///     Sets the su increment decrement models.
        /// </summary>
        /// <value>
        ///     The su increment decrement models.
        /// </value>
        IList<SUIncrementDecrementModel> SUIncrementDecrementModels { set; }
    }
}