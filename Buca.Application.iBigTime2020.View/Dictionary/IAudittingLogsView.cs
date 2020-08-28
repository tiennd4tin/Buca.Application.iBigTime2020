﻿/***********************************************************************
 * <copyright file="IAudittingLogsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 12 March 2014
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
    /// IAudittingLogsView
    /// </summary>
    public interface IAudittingLogsView : IView
    {
        /// <summary>
        /// Sets the auditting logs.
        /// </summary>
        /// <value>
        /// The auditting logs.
        /// </value>
        IList<AudittingLogModel> AudittingLogs { set; }
    }
}
