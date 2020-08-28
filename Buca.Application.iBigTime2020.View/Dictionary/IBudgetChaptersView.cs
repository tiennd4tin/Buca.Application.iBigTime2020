﻿/***********************************************************************
 * <copyright file="IBudgetChaptersView.cs" company="BUCA JSC">
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
    /// Interface IBudgetChaptersView
    /// </summary>
    public interface IBudgetChaptersView : IView
    {
        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
        IList<BudgetChapterModel> BudgetChapters { set; }
    }
}
