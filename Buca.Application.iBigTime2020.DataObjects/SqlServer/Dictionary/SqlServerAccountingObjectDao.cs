/***********************************************************************
 * <copyright file="SqlServerAccountingObjectDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{

    /// <summary>
    /// SqlServerAccountingObjectDao
    /// </summary>
    public class SqlServerAccountingObjectDao : IAccountingObjectDao
    {
        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <returns></returns>
        public AccountingObjectEntity GetAccountingObjectById(string accountingObjectId)
        {
            const string sql = @"uspGet_AccountingObject_ByID";
            object[] parms = { "@AccountingObjectID", accountingObjectId };
            return Db.Read(sql, true, Make, parms);
        } 

        /// <summary>
        /// Gets the accounting object.
        /// </summary>
        /// <param name="accountingObjectCode">The accounting object code.</param>
        /// <returns></returns>
        public AccountingObjectEntity GetAccountingObject(string accountingObjectCode)
        {
            const string sql = @"uspGet_AccountingObject_ByCode";
            object[] parms = { "@AccountingObjectCode", accountingObjectCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the specified code.
        /// </summary>
        /// <param name="accountingObjectCode">The accounting object code.</param>
        /// <returns></returns>
        public List<AccountingObjectEntity> GetAccountingObjectByCode(string accountingObjectCode)
        {
            const string sql = @"uspGet_AccountingObject_ByCode";
            object[] parms = { "@AccountingObjectCode", accountingObjectCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the employee by code.
        /// </summary>
        /// <param name="accountingObjectCode">The accounting object code.</param>
        /// <returns></returns>
        public AccountingObjectEntity GetEmployeeByCode(string accountingObjectCode)
        {
            const string sql = @"uspGet_Employee_ByCode";
            object[] parms = { "@AccountingObjectCode", accountingObjectCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Getses this instance. 
        /// </summary>
        /// <returns></returns>
        public List<AccountingObjectEntity> GetAccountingObjects()
        {
            const string sql = @"uspGet_All_AccountingObject";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        /// Gets the by actives.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<AccountingObjectEntity> GetAccountingObjectByActives(bool isActive)
        {
            const string sql = @"uspGet_AccountingObject_IsActive";
            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }



        /// <summary>
        /// Gets the accounting objects by accounting object category identifier.
        /// </summary>
        /// <param name="accountingObjectCategoryId">The accounting object category identifier.</param>
        /// <returns></returns>
        public List<AccountingObjectEntity> GetAccountingObjectsByAccountingObjectCategoryId(string accountingObjectCategoryId)
        {
            const string sql = @"uspGet_AccountingObjectsByAccountingObjectCategoryId";
            object[] parms = { "@AccountingObjectCategoryId", accountingObjectCategoryId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the accounting objects by is active.
        /// </summary>
        /// <returns></returns>
        public List<AccountingObjectEntity> GetAccountingObjectsByIsEmployee(bool isEmployee)
        {
            const string sql = @"uspGet_AccountingObject_ByIsEmployee";
            object[] parms = { "@IsEmployee", isEmployee };
            return Db.ReadList(sql, true, Make, parms);
        }
        public List<AccountingObjectEntity> GetAccountObjectByDepartmentId(string departmentid)
        {
            const string sql = @"uspGet_AccountingObject_ByDepartmentId";
            object[] parms = { "@departmentid", departmentid };
            return Db.ReadList(sql, true, Make, parms);
        }
        /// <summary>
        /// Gets the accounting objects by is customer vendor.
        /// </summary>
        /// <param name="isCustomerVendor">if set to <c>true</c> [is customer vendor].</param>
        /// <returns>List&lt;AccountingObjectEntity&gt;.</returns>
        public List<AccountingObjectEntity> GetAccountingObjectsByIsCustomerVendor(bool isCustomerVendor)
        {
            const string sql = @"uspGet_AccountingObject_ByIsCustomerVendor";
            object[] parms = { "@IsCustomerVendor", isCustomerVendor };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the accounting object.
        /// </summary>
        /// <param name="accountingObject">The accounting object.</param>
        /// <returns></returns>
        public string InsertAccountingObject(AccountingObjectEntity accountingObject)
        {
            const string sql = @"uspInsert_AccountingObject";
            return Db.Insert(sql, true, Take(accountingObject));
        }

        /// <summary>
        /// Updates the accounting object.
        /// </summary>
        /// <param name="accountingObject">The accounting object.</param>
        /// <returns></returns>
        public string UpdateAccountingObject(AccountingObjectEntity accountingObject)
        {
            const string sql = @"uspUpdate_AccountingObject";
            return Db.Update(sql, true, Take(accountingObject));
        }

        public string DeleteAccountingObject(AccountingObjectEntity accountingObject)
        {
            const string sql = @"uspDelete_AccountingObject";
            object[] parms = { "@AccountingObjectID", accountingObject.AccountingObjectId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteAccountingObjectConvert()
        {
            const string sql = @"usp_ConvertAccountingObject";
            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AccountingObjectEntity> Make = reader =>
            new AccountingObjectEntity
            {
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                AccountingObjectCode = reader["AccountingObjectCode"].AsString(),
                AccountingObjectCategoryId = reader["AccountingObjectCategoryID"].AsString(),
                AccountingObjectName = reader["AccountingObjectName"].AsString(),
                Address = reader["Address"].AsString(),
                Tel = reader["Tel"].AsString(),
                Fax = reader["Fax"].AsString(),
                Website = reader["Website"].AsString(),
                BankAccount = reader["BankAccount"].AsString(),
                BankName = reader["BankName"].AsString(),
                CompanyTaxCode = reader["CompanyTaxCode"].AsString(),
                BudgetCode = reader["BudgetCode"].AsString(),
                AreaCode = reader["AreaCode"].AsString(),
                Description = reader["Description"].AsString(),
                ContactName = reader["ContactName"].AsString(),
                ContactTitle = reader["ContactTitle"].AsString(),
                ContactSex = reader["ContactSex"].AsInt(),
                ContactMobile = reader["ContactMobile"].AsString(),
                ContactEmail = reader["ContactEmail"].AsString(),
                ContactOfficeTel = reader["ContactOfficeTel"].AsString(),
                ContactHomeTel = reader["ContactHomeTel"].AsString(),
                ContactAddress = reader["ContactAddress"].AsString(),
                IsEmployee = reader["IsEmployee"].AsBool(),
                IsPersonal = reader["IsPersonal"].AsBool(),
                IdentificationNumber = reader["IdentificationNumber"].AsString(),
                IssueDate = reader["IssueDate"].AsDateTimeForNull(),
                IssueBy = reader["IssueBy"].AsString(),
                DepartmentId = reader["DepartmentID"].AsString(),
                SalaryScaleId = reader["SalaryScaleID"].AsString(),
                Insured = reader["Insured"].AsBool(),
                LabourUnionFee = reader["LabourUnionFee"].AsBool(),
                FamilyDeductionAmount = reader["FamilyDeductionAmount"].AsDecimal(),
                IsActive = reader["IsActive"].AsBool(),
                ProjectId = reader["ProjectID"].AsString(),
                IsCustomerVendor = reader["IsCustomerVendor"].AsBool(),
                SalaryCoefficient = reader["SalaryCoefficient"].AsDecimal(),
                NumberFamilyDependent = reader["NumberFamilyDependent"].AsInt(),
                EmployeeTypeId = reader["EmployeeTypeID"].AsString(),
                SalaryForm = reader["SalaryForm"].AsInt(),
                SalaryPercentRate = reader["SalaryPercentRate"].AsDecimal(),
                SalaryAmount = reader["SalaryAmount"].AsDecimal(),
                IsPayInsuranceOnSalary = reader["IsPayInsuranceOnSalary"].AsBool(),
                InsuranceAmount = reader["InsuranceAmount"].AsDecimal(),
                IsUnEmploymentInsurance = reader["IsUnEmploymentInsurance"].AsBool(),
                RefTypeAO = reader["RefTypeAO"].AsInt(),
                SalaryGrade = reader["SalaryGrade"].AsInt(),
                CustomField1 = reader["CustomField1"].AsString(),
                CustomField2 = reader["CustomField2"].AsString(),
                CustomField3 = reader["CustomField3"].AsString(),
                CustomField4 = reader["CustomField4"].AsString(),
                CustomField5 = reader["CustomField5"].AsString(),
                IsPaidInsuranceForPayrollItem = reader["IsPaidInsuranceForPayrollItem"].AsBool(),
                IsBornLeave = reader["IsBornLeave"].AsBool(),
                TaxDepartmentName = reader["TaxDepartmentName"].AsString(),
                TreasuryName = reader["TreasuryName"].AsString(),
                BudgetChapterId = reader["BudgetChapterID"].AsString(),
                BudgetItemId = reader["FundStructureID"].AsString(),
                OrganizationFeeCode = reader["OrganizationFeeCode"].AsString(),
                OrganizationManageFee = reader["OrganizationManageFee"].AsString(),
                TreasuryManageFee = reader["TreasuryManageFee"].AsString()
            };

        /// <summary>
        /// Takes the specified budget source property.
        /// </summary>
        /// <param name="accountingObjectEntity">The take.</param>
        /// <returns></returns>
        private static object[] Take(AccountingObjectEntity accountingObjectEntity)
        {
            return new object[]
            {
                "@AccountingObjectID" , accountingObjectEntity.AccountingObjectId,
                "@AccountingObjectCode" , accountingObjectEntity.AccountingObjectCode,
                "@AccountingObjectCategoryID" , accountingObjectEntity.AccountingObjectCategoryId,
                "@AccountingObjectName" , accountingObjectEntity.AccountingObjectName,
                "@Address" , accountingObjectEntity.Address,
                "@Tel" , accountingObjectEntity.Tel,
                "@Fax" , accountingObjectEntity.Fax,
                "@Website" , accountingObjectEntity.Website,
                "@BankAccount" , accountingObjectEntity.BankAccount,
                "@BankName" , accountingObjectEntity.BankName,
                "@CompanyTaxCode" , accountingObjectEntity.CompanyTaxCode,
                "@BudgetCode" , accountingObjectEntity.BudgetCode,
                "@AreaCode", accountingObjectEntity.AreaCode,
                "@Description", accountingObjectEntity.Description,
                "@ContactName" , accountingObjectEntity.ContactName,
                "@ContactTitle" , accountingObjectEntity.ContactTitle,
                "@ContactSex" , accountingObjectEntity.ContactSex,
                "@ContactMobile" , accountingObjectEntity.ContactMobile,
                "@ContactEmail", accountingObjectEntity.ContactEmail,
                "@ContactOfficeTel", accountingObjectEntity.ContactOfficeTel,
                "@ContactHomeTel" , accountingObjectEntity.ContactHomeTel,
                "@ContactAddress" , accountingObjectEntity.ContactAddress,
                "@IsEmployee" , accountingObjectEntity.IsEmployee,
                "@IsPersonal" , accountingObjectEntity.IsPersonal,
                "@IdentificationNumber", accountingObjectEntity.IdentificationNumber,
                "@IssueDate", accountingObjectEntity.IssueDate,
                "@IssueBy" , accountingObjectEntity.IssueBy,
                "@DepartmentID" , accountingObjectEntity.DepartmentId,
                "@SalaryScaleID" , accountingObjectEntity.SalaryScaleId,
                "@Insured" , accountingObjectEntity.Insured,
                "@LabourUnionFee", accountingObjectEntity.LabourUnionFee,
                "@FamilyDeductionAmount", accountingObjectEntity.FamilyDeductionAmount,
                "@IsActive" , accountingObjectEntity.IsActive,
                "@ProjectID", accountingObjectEntity.ProjectId,
                "@IsCustomerVendor" , accountingObjectEntity.IsCustomerVendor,
                "@SalaryCoefficient" , accountingObjectEntity.SalaryCoefficient,
                "@NumberFamilyDependent", accountingObjectEntity.NumberFamilyDependent,
                "@EmployeeTypeID", accountingObjectEntity.EmployeeTypeId,
                "@SalaryForm" , accountingObjectEntity.SalaryForm,
                "@SalaryPercentRate" , accountingObjectEntity.SalaryPercentRate,
                "@SalaryAmount" , accountingObjectEntity.SalaryAmount,
                "@IsPayInsuranceOnSalary" , accountingObjectEntity.IsPayInsuranceOnSalary,
                "@InsuranceAmount", accountingObjectEntity.InsuranceAmount,
                "@IsUnEmploymentInsurance", accountingObjectEntity.IsUnEmploymentInsurance,
                "@RefTypeAO" , accountingObjectEntity.RefTypeAO,
                "@SalaryGrade", accountingObjectEntity.SalaryGrade,
                "@CustomField1", accountingObjectEntity.CustomField1,
                "@CustomField2" , accountingObjectEntity.CustomField2,
                "@CustomField3" , accountingObjectEntity.CustomField3,
                "@CustomField4" , accountingObjectEntity.CustomField4,
                "@CustomField5" , accountingObjectEntity.CustomField5,
                "@IsPaidInsuranceForPayrollItem", accountingObjectEntity.IsPaidInsuranceForPayrollItem,
                "@IsBornLeave", accountingObjectEntity.IsBornLeave,
                "@TaxDepartmentName" , accountingObjectEntity.TaxDepartmentName,
                "@TreasuryName", accountingObjectEntity.TreasuryName,
                "@BudgetChapterID", accountingObjectEntity.BudgetChapterId,
                "@FundStructureID", accountingObjectEntity.BudgetItemId,
                "@OrganizationFeeCode", accountingObjectEntity.OrganizationFeeCode,
                "@OrganizationManageFee", accountingObjectEntity.OrganizationManageFee,
                "@TreasuryManageFee", accountingObjectEntity.TreasuryManageFee,
            };
        }
    }
}
