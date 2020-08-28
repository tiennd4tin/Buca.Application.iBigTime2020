/***********************************************************************
 * <copyright file="IBudgetProvidencesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 26, 2017
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
    ///     IBudgetProvidencesView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IBudgetProvidencesView : IView
    {
        /// <summary>
        ///     Sets the budget providence models.
        /// </summary>
        /// <value>
        ///     The budget providence models.
        /// </value>
        IList<BudgetProvidenceModel> BudgetProvidenceModels { set; }
    }
}