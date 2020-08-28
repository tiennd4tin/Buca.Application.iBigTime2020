/***********************************************************************
 * <copyright file="IAccountingObjectDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
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
    /// IAccountingObjectDao interface
    /// </summary>
    public interface IAccountingObjectDao
    {

        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <returns></returns>
        AccountingObjectEntity GetAccountingObjectById(string accountingObjectId);

        /// <summary>
        /// Gets the accounting object.
        /// </summary>
        /// <param name="accountingObjectCode">The accounting object code.</param>
        /// <returns></returns>
        AccountingObjectEntity GetAccountingObject(string accountingObjectCode);

        /// <summary>
        /// Gets the specified code.
        /// </summary>
        /// <param name="accountingObjectCode">The accounting object code.</param>
        /// <returns></returns>
        List<AccountingObjectEntity> GetAccountingObjectByCode(string accountingObjectCode);

        /// <summary>
        /// Gets the employee by code.
        /// </summary>
        /// <param name="accountingObjectCode">The accounting object code.</param>
        /// <returns></returns>
        AccountingObjectEntity GetEmployeeByCode(string accountingObjectCode);

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns></returns>
        List<AccountingObjectEntity> GetAccountingObjects();

        /// <summary>
        /// Gets the accounting objects by accounting object category identifier.
        /// </summary>
        /// <param name="accountingObjectCategoryId">The accounting object category identifier.</param>
        /// <returns></returns>
        List<AccountingObjectEntity> GetAccountingObjectsByAccountingObjectCategoryId(string accountingObjectCategoryId);

        /// <summary>
        /// Gets the accounting objects by is active.
        /// </summary>
        /// <returns></returns>
        List<AccountingObjectEntity> GetAccountingObjectsByIsEmployee(bool isEmployee);


        /// <summary>
        /// Gets the accounting object by is customer vendor.
        /// </summary>
        /// <param name="isCustomerVendor">if set to <c>true</c> [is customer vendor].</param>
        /// <returns>List&lt;AccountingObjectEntity&gt;.</returns>
        List<AccountingObjectEntity> GetAccountingObjectsByIsCustomerVendor(bool isCustomerVendor);

            /// <summary>
        /// Gets the by actives.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<AccountingObjectEntity> GetAccountingObjectByActives(bool isActive);

        List<AccountingObjectEntity> GetAccountObjectByDepartmentId(string departmentid);

        /// <summary>
        /// Inserts the accounting object.
        /// </summary>
        /// <param name="accountingObject">The accounting object.</param>
        /// <returns></returns>
        string InsertAccountingObject(AccountingObjectEntity accountingObject);

        /// <summary>
        /// Updates the accounting object.
        /// </summary>
        /// <param name="accountingObject">The accounting object.</param>
        /// <returns></returns>
        string UpdateAccountingObject(AccountingObjectEntity accountingObject);

        /// <summary>
        /// Deletes the accounting object.
        /// </summary>
        /// <param name="accountingObject">The accounting object.</param>
        /// <returns></returns>
        string DeleteAccountingObject(AccountingObjectEntity accountingObject);
        string DeleteAccountingObjectConvert();
    }
}
