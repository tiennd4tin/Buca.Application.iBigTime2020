/***********************************************************************
 * <copyright file="IEmployeeLeasingsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 09 June 2014
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
    /// IEmployeeLeasingsView
    /// </summary>
    public interface IEmployeeLeasingsView
    {
        /// <summary>
        /// Sets the employee leasings.
        /// </summary>
        /// <value>
        /// The employee leasings.
        /// </value>
        IList<EmployeeLeasingModel> EmployeeLeasings { set; }
    }
}
