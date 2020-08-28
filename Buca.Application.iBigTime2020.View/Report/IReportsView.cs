﻿/***********************************************************************
 * <copyright file="IReportView.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.com
 * Website:
 * Create Date: Monday, February 24, 2014
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
    /// interface IReportView
    /// </summary>
    public interface IReportsView : IView
    {
        /// <summary>
        /// Sets the report lists.
        /// </summary>
        /// <value>
        /// The report lists.
        /// </value>
        List<ReportListModel> ReportLists {set; }
    }
}
