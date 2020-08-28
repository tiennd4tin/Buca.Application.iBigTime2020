/***********************************************************************
 * <copyright file="ISitesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 22 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;


namespace Buca.Application.iBigTime2020.View.System
{
    /// <summary>
    /// interface ISitesView
    /// </summary>
    public interface ISitesView
    {
        /// <summary>
        /// Sets the sites.
        /// </summary>
        /// <value>
        /// The sites.
        /// </value>
        IList<SiteModel> Sites { set; }
    }
}
