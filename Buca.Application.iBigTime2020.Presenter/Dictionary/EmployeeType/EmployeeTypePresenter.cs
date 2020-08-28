using System;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.EmployeeType
{
    public class EmployeeTypePresenter : Presenter<IEmployeeTypeView>
    {
        public EmployeeTypePresenter(IEmployeeTypeView view) : base(view)
        {
        }

        /// <summary>
        /// Displays the specified employeeType identifier.
        /// </summary>
        /// <param name="employeeTypeId">The employeeType identifier.</param>
        public void Display(string employeeTypeId)
        {
            if (employeeTypeId == null) { View.EmployeeTypeId = String.Empty; return; }

            var employeeType = Model.GetEmployeeType(employeeTypeId);

            View.EmployeeTypeId = employeeType.EmployeeTypeId;
            View.EmployeeTypeName = employeeType.EmployeeTypeName;
            View.EmployeeTypeCode = employeeType.EmployeeTypeCode;
            View.Description = employeeType.Description;
            View.IsActive = employeeType.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var employeeType = new EmployeeTypeModel
            {
                EmployeeTypeId = View.EmployeeTypeId,
                EmployeeTypeName = View.EmployeeTypeName,
                Description = View.Description,
                IsActive = View.IsActive,
                EmployeeTypeCode = View.EmployeeTypeCode
            };

            return string.IsNullOrEmpty(View.EmployeeTypeId) ? Model.InsertEmployeeType(employeeType) : Model.UpdateEmployeeType(employeeType);
        }

        /// <summary>
        /// Deletes the specified accont identifier.
        /// </summary>
        /// <param name="employeeTypeId">The employeeType identifier.</param>
        /// <returns></returns>
        public string Delete(string employeeTypeId)
        {
            return Model.DeleteEmployeeType(employeeTypeId);
        }

        /// <summary>
        /// Codes the is exist.
        /// </summary>
        /// <param name="employeeTypeId">The employee type identifier.</param>
        /// <param name="employeeTypeCode">The employee type code.</param>
        /// <returns></returns>
        public bool CodeIsExist(string employeeTypeId, string employeeTypeCode)
        {
            return Model.GetEmployeeTypes().Where(x =>x.EmployeeTypeId != employeeTypeId && x.EmployeeTypeCode == employeeTypeCode).ToList().Count > 0;
        }
    }
}