﻿/***********************************************************************
 * <copyright file="IReportGroupView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;

namespace Buca.Application.iBigTime2020.View.Report
{
    /// <summary>
    /// interface IReportGroupView
    /// </summary>
    public interface IReportGroupView : IView
    {
        /// <summary>
        /// Sets the report groups.
        /// </summary>
        /// <value>
        /// The report groups.
        /// </value>
        List<ReportGroupModel> ReportGroups { set; }
    }
}
