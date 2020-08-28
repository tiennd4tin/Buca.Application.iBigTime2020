/***********************************************************************
 * <copyright file="IEmployeeTypeDao.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    ///     IEmployeeTypeDao
    /// </summary>
    public interface IEmployeeTypeDao
    {
        /// <summary>
        ///     Gets the employeeType.
        /// </summary>
        /// <param name="employeeTypeId">The employeeType identifier.</param>
        /// <returns></returns>
        EmployeeTypeEntity GetEmployeeType(string employeeTypeId);

        /// <summary>
        ///     Gets the employeeTypes.
        /// </summary>
        /// <returns></returns>
        List<EmployeeTypeEntity> GetEmployeeTypes();

        /// <summary>
        ///     Inserts the employeeType.
        /// </summary>
        /// <param name="employeeType">The employeeType.</param>
        /// <returns></returns>
        string InsertEmployeeType(EmployeeTypeEntity employeeType);

        /// <summary>
        ///     Updates the employeeType.
        /// </summary>
        /// <param name="employeeType">The employeeType.</param>
        /// <returns></returns>
        string UpdateEmployeeType(EmployeeTypeEntity employeeType);

        /// <summary>
        ///     Deletes the employeeType.
        /// </summary>
        /// <param name="employeeType">The employeeType.</param>
        /// <returns>System.String.</returns>
        string DeleteEmployeeType(EmployeeTypeEntity employeeType);
        string DeleteEmployeeTypeConvert();

        /// <summary>
        ///     Gets the employeeTypes by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;EmployeeTypeEntity&gt;.</returns>
        List<EmployeeTypeEntity> GetEmployeeTypesByIsActive(bool isActive);

        /// <summary>
        ///     Lấy danh sách các kho theo mã
        /// </summary>
        /// <param name="employeeTypeCode"></param>
        /// <returns></returns>
        List<EmployeeTypeEntity> GetEmployeeTypesByEmployeeTypeCode(string employeeTypeCode);
    }
}