/***********************************************************************
 * <copyright file="IEmployeeTypiesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, September 28, 2017
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
    ///     IEmployeeTypiesView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IEmployeeTypesView : IView
    {
        /// <summary>
        ///     Gets or sets the employee models.
        /// </summary>
        /// <value>
        ///     The employee models.
        /// </value>
        IList<EmployeeTypeModel> EmployeeTypes { set; }
    }
}