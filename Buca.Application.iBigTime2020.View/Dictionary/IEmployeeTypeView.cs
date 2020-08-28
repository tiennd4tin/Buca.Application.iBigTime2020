/***********************************************************************
 * <copyright file="IEmployeeTypeView.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    ///     IEmployeeTypeView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IEmployeeTypeView : IView
    {
        /// <summary>
        ///     Gets or sets the employeeType identifier.
        /// </summary>
        /// <value>
        ///     The employeeType identifier.
        /// </value>
        string EmployeeTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the employeeType.
        /// </summary>
        /// <value>
        ///     The name of the employeeType.
        /// </value>
        string EmployeeTypeName { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is system; otherwise, <c>false</c>.
        /// </value>
        string EmployeeTypeCode { get; set; }
    }
}