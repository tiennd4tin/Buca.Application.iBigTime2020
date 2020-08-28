/***********************************************************************
 * <copyright file="EmployeeTypeEntity.cs" company="BUCA JSC">
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

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    ///     EmployeeTypeEntity
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class EmployeeTypeEntity : BusinessEntities
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DepartmentEntity" /> class.
        /// </summary>
        public EmployeeTypeEntity()
        {
            AddRule(new ValidateRequired("EmployeeTypeName"));
            AddRule(new ValidateRequired("EmployeeTypeCode"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentEntity" /> class.
        /// </summary>
        /// <param name="employeeTypeId">The employee type identifier.</param>
        /// <param name="employeeTypeName">Name of the employee type.</param>
        /// <param name="description">The description.</param>
        /// <param name="employeeTypeCode">The employee type code.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public EmployeeTypeEntity(string employeeTypeId, string employeeTypeName, string description, string employeeTypeCode,
            bool isActive)
            : this()
        {
            EmployeeTypeId = employeeTypeId;
            EmployeeTypeName = employeeTypeName;
            EmployeeTypeCode = employeeTypeCode;
            IsActive = isActive;
            Description = description;
        }

        /// <summary>
        ///     Gets or sets the employee type identifier.
        /// </summary>
        /// <value>
        ///     The employee type identifier.
        /// </value>
        public string EmployeeTypeId { get; set; }

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
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is system; otherwise, <c>false</c>.
        /// </value>
        public string EmployeeTypeCode { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}