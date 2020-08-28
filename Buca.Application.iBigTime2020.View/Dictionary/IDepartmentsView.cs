/***********************************************************************
 * <copyright file="IDepartmentsView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using System.Collections.Generic;


namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// IDepartmentsView
    /// </summary>
    public interface IDepartmentsView : IView
    {
        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        IList<DepartmentModel> Departments { set; }
    }
}
