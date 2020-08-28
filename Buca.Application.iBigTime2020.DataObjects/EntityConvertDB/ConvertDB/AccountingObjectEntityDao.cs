using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    
     
    public class AccountingObjectEntityDao : IEntityAccountingObjectDao
    {
        public class Employee:EmployeeType
        {
            public  string _EmployeeTypeID { get; set; }
        }
       
    
        public List<AccountingObjectConvertEntity> GetAccountingObject(string connectionString)
        {  
            List<AccountingObjectConvertEntity> listAccount = new List<AccountingObjectConvertEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                
                var department = context.Departments.ToList();
                var employees =context.EmployeeTypes.ToList();
                var lstEmployee = new List<Employee>();
                
                foreach (var _employee in employees)
                {
                    var _emp = new Employee();
                    _emp._EmployeeTypeID = Guid.NewGuid().ToString();
                    _emp.EmployeeTypeName = _employee.EmployeeTypeName;
                    _emp.EmployeeTypeID = _employee.EmployeeTypeID;
                    lstEmployee.Add(_emp);
                }




                var categories = context.AccountingObjects.ToList();
                foreach (var result in categories)
                {
                    var accountingObject = new AccountingObjectConvertEntity();
                    accountingObject.AccountingObjectId = result.AccountingObjectID.ToString();
                    accountingObject.AccountingObjectCode = result.AccountingObjectCode; 
                    accountingObject.AccountingObjectName = result.AccountingObjectName;
                    accountingObject.Address = result.Address;
                    accountingObject.Tel = result.Tel;
                    accountingObject.Fax = result.Fax;
                    accountingObject.Website = result.Website;
                    accountingObject.BankAccount = result.BankAccount;
                    accountingObject.BankName = result.BankName;
                    accountingObject.CompanyTaxCode = result.CompanyTaxCode;
                    accountingObject.BudgetCode = result.BudgetCode;
                    accountingObject.AreaCode = result.AreaCode;
                    accountingObject.Description = result.Description;
                    accountingObject.ContactName = result.ContactName;
                    accountingObject.ContactTitle = result.ContactTitle;
                    accountingObject.ContactSex = result.ContactSex;
                    accountingObject.ContactMobile = result.ContactMobile;
                    accountingObject.ContactEmail = result.ContactEmail;
                    accountingObject.ContactOfficeTel = result.ContactOfficeTel;
                    accountingObject.ContactHomeTel = result.ContactHomeTel;
                    accountingObject.ContactAddress = result.ContactAddress;
                    accountingObject.IsEmployee = result.IsEmployee;
                    accountingObject.IsPersonal = result.IsPersonal;
                    accountingObject.IdentificationNumber = result.IdentificationNumber;
                    accountingObject.IssueDate = result.IssueDate;
                    accountingObject.IssueBy = result.IssueBy;
                    accountingObject.DepartmentId = result.Department ==null?null: result.Department.DepartmentID.ToString();
                    accountingObject.SalaryScaleId = result.SalaryScaleID.ToString();
                    accountingObject.Insured = result.Insured;
                    accountingObject.LabourUnionFee = result.LabourUnionFee;
                    accountingObject.FamilyDeductionAmount = result.FamilyDeductionAmount;
                    accountingObject.IsActive = result.Inactive ==true ?false:true;
                    accountingObject.ProjectId = result.ProjectID.ToString();
                    accountingObject.IsCustomerVendor = result.IsCustomerVendor;
                    accountingObject.SalaryCoefficient = result.SalaryCoefficient;
                    accountingObject.NumberFamilyDependent = result.NumberFamilyDependent;
                    accountingObject.SalaryForm = result.SalaryForm;
                    accountingObject.SalaryPercentRate = result.SalaryPercenRate;
                    accountingObject.SalaryAmount = result.SalaryAmount;
                    accountingObject.IsPayInsuranceOnSalary = result.IsPayInsuranceOnSalary;
                    accountingObject.InsuranceAmount = result.InsuranceAmount;
                    accountingObject.IsUnEmploymentInsurance = result.IsUnEmploymentInsurance;
                    accountingObject.RefTypeAO = result.RefTypeAO;
                    accountingObject.SalaryGrade = result.SalaryGrade;
                    accountingObject.CustomField1 = result.CustomField1;
                    accountingObject.CustomField2 = result.CustomField2;
                    accountingObject.CustomField3 = result.CustomField3;
                    accountingObject.CustomField4 = result.CustomField4;
                    accountingObject.CustomField5 = result.CustomField5;
                    accountingObject.IsPaidInsuranceForPayrollItem = result.IsPaidInsuranceForPayrollItem;
                    accountingObject.IsBornLeave = result.IsBornLeave;
                    accountingObject.EmployeeTypeId =lstEmployee.FirstOrDefault(x=>x.EmployeeTypeID == result.EmployeeType.EmployeeTypeID)._EmployeeTypeID;
                    accountingObject.EmployeeDescription = result.EmployeeType.Description;
                    accountingObject.EmployeeIsActive = result.EmployeeType.Inactive == true ? false : true;
                    accountingObject.EmployeeTypeCode = result.EmployeeType.EmployeeTypeID.ToString();
                    accountingObject.EmployeeTypeName = result.EmployeeType.EmployeeTypeName;


                    listAccount.Add(accountingObject);

                }

                foreach (var _employee in employees)
                {
                    if (categories.Where(x => x.EmployeeType.EmployeeTypeID == _employee.EmployeeTypeID).Count() == 0)
                    {
                        var accountingObject = new AccountingObjectConvertEntity();
                        accountingObject.EmployeeTypeId = Guid.NewGuid().ToString();
                        accountingObject.EmployeeDescription = _employee.Description;
                        accountingObject.EmployeeIsActive = _employee.Inactive == true ? false : true;
                        accountingObject.EmployeeTypeCode = _employee.EmployeeTypeID.ToString();
                        accountingObject.EmployeeTypeName = _employee.EmployeeTypeName;
                        listAccount.Add(accountingObject);
                    }

                   
                }
            }

            return listAccount;
        }

      
    }
}
