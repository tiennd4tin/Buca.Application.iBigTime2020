/***********************************************************************
 * <copyright file="AccountingObjectsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using System.Collections.Generic;
using System.Linq;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject
{

    /// <summary>
    /// AccountingObjectsPresenter clas
    /// </summary>
    public class AccountingObjectsPresenter : Presenter<IAccountingObjectsView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountingObjectsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountingObjectsPresenter(IAccountingObjectsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()

        {
            View.AccountingObjects = Model.GetAccountingObjects();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayActive(bool isActive)
        {
            View.AccountingObjects = Model.GetAccountingObjectsByIsActive(isActive);
        }

        public void DisplayActive(bool isActive, bool isEmployee)
        {
            var _accountingObjects = Model.GetAccountingObjectsByIsActive(isActive);
            View.AccountingObjects = _accountingObjects.Where(m => m.IsEmployee.Equals(isEmployee)).ToList();
        }

        /// <summary>
        /// Displays the accounting object category identifier.
        /// </summary>
        /// <param name="accountingObjectCategoryId">The accounting object category identifier.</param>
        public void DisplayAccountingObjectCategoryId(string accountingObjectCategoryId)
        {
            View.AccountingObjects = Model.GetAccountingObjectsByAccountingObjectCategoryId(accountingObjectCategoryId);
        }

        /// <summary>
        /// Displays the by is employee.
        /// </summary>
        /// <param name="isEmployee">if set to <c>true</c> [is employee].</param>
        public void DisplayByIsEmployee(bool isEmployee)
        {
            View.AccountingObjects = Model.GetAccountingObjectsByIsEmployee(isEmployee);
        }

        public void DisplayByDepartment(string departmentid)
        {
            View.AccountingObjects = Model.GetAccountingObjectsByDepartment(departmentid);
        }

        /// <summary>
        /// Displays the by is customer vendor.
        /// </summary>
        /// <param name="isCustomerVendor">if set to <c>true</c> [is customer vendor].</param>
        public void DisplayByIsCustomerVendor(bool isCustomerVendor)
        {
            View.AccountingObjects = Model.GetAccountingObjectsByIsCustomerVendor(isCustomerVendor);
        }

        public void DisplayByIsActiveAndIsCustomerVendor(bool isActive, bool isCustomerVendor)
        {
            var _accountingObjects = Model.GetAccountingObjectsByIsActive(isActive);
            if (_accountingObjects == null)
                _accountingObjects = new List<AccountingObjectModel>();
            View.AccountingObjects = _accountingObjects.Where(m => m.IsEmployee.Equals(isCustomerVendor)).ToList();
        }
    }
}
