﻿/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;


namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// IAutoBusinessesView
    /// </summary>
    public interface IAutoBusinessesView : IView
    {
        /// <summary>
        /// Sets the automatic businesses.
        /// </summary>
        /// <value>
        /// The automatic businesses.
        /// </value>
        IList<AutoBusinessModel> AutoBusinesses { set; }
    }
}