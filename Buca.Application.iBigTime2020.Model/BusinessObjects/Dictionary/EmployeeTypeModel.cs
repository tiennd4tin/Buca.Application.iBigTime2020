/***********************************************************************
 * <copyright file="EmployeeTypeModel.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// EmployeeTypeModel
    /// </summary>
    public class EmployeeTypeModel
    {
        /// <summary>
        ///     Gets or sets the employee type identifier.
        /// </summary>
        /// <value>
        ///     The employee type identifier.
        /// </value>
        public string EmployeeTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is system; otherwise, <c>false</c>.
        /// </value>
        public string EmployeeTypeCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the employee type.
        /// </summary>
        /// <value>
        ///     The name of the employee type.
        /// </value>
        public string EmployeeTypeName { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}