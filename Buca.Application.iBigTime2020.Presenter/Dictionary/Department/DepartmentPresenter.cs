/***********************************************************************
 * <copyright file="DepartmentPresenter.cs" company="BUCA JSC">
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

using System;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Department
{
    /// <summary>
    /// DepartmentPresenter
    /// </summary>
    public class DepartmentPresenter : Presenter<IDepartmentView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public DepartmentPresenter(IDepartmentView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified department identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        public void Display(string departmentId)
        {
            if (departmentId == null) { View.DepartmentId = String.Empty; return; }

            var department = Model.GetDepartment(departmentId);

            View.DepartmentId = department.DepartmentId;
            View.DepartmentCode = department.DepartmentCode;
            View.DepartmentName = department.DepartmentName;
            View.ParentId = department.ParentId;
            View.Description = department.Description;
            View.IsActive = department.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var department = new DepartmentModel
            {
                DepartmentId = View.DepartmentId,
                DepartmentCode = View.DepartmentCode,
                DepartmentName = View.DepartmentName,
                ParentId = View.ParentId,
                Description = View.Description,
                IsActive = View.IsActive
            };

            return string.IsNullOrEmpty(View.DepartmentId) ? Model.InsertDepartment(department) : Model.UpdateDepartment(department);
        }

        /// <summary>
        /// Deletes the specified accont identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        public string Delete(string departmentId)
        {
            return Model.DeleteDepartment(departmentId);
        }

        /// <summary>
        /// Codes the is exist.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <returns></returns>
        public bool CodeIsExist(string departmentId, string departmentCode)
        {
            var department = Model.GetDepartmentByCode(departmentCode);
            if (department != null)
                return string.IsNullOrEmpty(departmentId) ? (department == null) : (department.DepartmentId.Equals(departmentId));
            return department == null;
        }
    }
}
