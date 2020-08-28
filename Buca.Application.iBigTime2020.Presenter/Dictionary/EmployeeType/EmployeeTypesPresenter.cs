/***********************************************************************
 * <copyright file="employeetypiespresenter.cs" company="BUCA JSC">
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

using System.Linq;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.EmployeeType
{
    /// <summary>
    ///     EmployeeTypiesPresenter
    /// </summary>
    /// <seealso
    ///     cref="Buca.Application.iBigTime2020.Presenter.Presenter{IEmployeeTypiesView}" />
    public class EmployeeTypesPresenter : Presenter<IEmployeeTypesView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EmployeeTypesPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public EmployeeTypesPresenter(IEmployeeTypesView view) : base(view)
        {
        }

        /// <summary>
        ///     Displays this instance.
        /// </summary>
        public void Display()
        {
            View.EmployeeTypes = Model.GetEmployeeTypes();
        }

        /// <summary>
        ///     Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.EmployeeTypes = Model.GetEmployeeTypes().Where(x => x.IsActive).ToList();
        }
    }
}