/***********************************************************************
 * <copyright file="AccountingObjectPresenter.cs" company="BUCA JSC">
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject
{

    /// <summary>
    /// AccountingObjectPresenter class
    /// </summary>
    public class AccountingObjectPresenter : Presenter<IAccountingObjectView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountingObjectPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountingObjectPresenter(IAccountingObjectView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display(string accountingObjectId)
        {
            if (accountingObjectId == null)
            {
                View.AccountingObjectId = null;
                return;
            }

            var accountingObject = Model.GetAccountingObject(accountingObjectId);

            View.AccountingObjectId = accountingObject.AccountingObjectId;
            View.AccountingObjectCode = accountingObject.AccountingObjectCode;
            View.AccountingObjectCategoryId = accountingObject.AccountingObjectCategoryId;
            View.AccountingObjectName = accountingObject.AccountingObjectName;
            View.Address = accountingObject.Address;
            View.Tel = accountingObject.Tel;
            View.Fax = accountingObject.Fax;
            View.Website = accountingObject.Website;
            View.BankAccount = accountingObject.BankAccount;
            View.BankName = accountingObject.BankName;
            View.CompanyTaxCode = accountingObject.CompanyTaxCode;
            View.BudgetCode = accountingObject.BudgetCode;
            View.AreaCode = accountingObject.AreaCode;
            View.Description = accountingObject.Description;
            View.ContactName = accountingObject.ContactName;
            View.ContactTitle = accountingObject.ContactTitle;
            View.ContactSex = accountingObject.ContactSex;
            View.ContactMobile = accountingObject.ContactMobile;
            View.ContactEmail = accountingObject.ContactEmail;
            View.ContactOfficeTel = accountingObject.ContactOfficeTel;
            View.ContactHomeTel = accountingObject.ContactHomeTel;
            View.ContactAddress = accountingObject.ContactAddress;
            View.IsEmployee = accountingObject.IsEmployee;
            View.IsPersonal = accountingObject.IsPersonal;
            View.IdentificationNumber = accountingObject.IdentificationNumber;
            View.IssueDate = accountingObject.IssueDate;
            View.IssueBy = accountingObject.IssueBy;
            View.DepartmentId = accountingObject.DepartmentId;
            View.SalaryScaleId = accountingObject.SalaryScaleId;
            View.Insured = accountingObject.Insured;
            View.LabourUnionFee = accountingObject.LabourUnionFee;
            View.FamilyDeductionAmount = accountingObject.FamilyDeductionAmount;
            View.IsActive = accountingObject.IsActive;
            View.ProjectId = accountingObject.ProjectId;
            View.IsCustomerVendor = accountingObject.IsCustomerVendor;
            View.SalaryCoefficient = accountingObject.SalaryCoefficient;
            View.NumberFamilyDependent = accountingObject.NumberFamilyDependent;
            View.EmployeeTypeId = accountingObject.EmployeeTypeId;
            View.SalaryForm = accountingObject.SalaryForm;
            View.SalaryPercentRate = accountingObject.SalaryPercentRate;
            View.SalaryAmount = accountingObject.SalaryAmount;
            View.IsPayInsuranceOnSalary = accountingObject.IsPayInsuranceOnSalary;
            View.InsuranceAmount = accountingObject.InsuranceAmount;
            View.IsUnEmploymentInsurance = accountingObject.IsUnEmploymentInsurance;
            View.RefTypeAO = accountingObject.RefTypeAO;
            View.SalaryGrade = accountingObject.SalaryGrade;
            View.CustomField1 = accountingObject.CustomField1;
            View.CustomField2 = accountingObject.CustomField2;
            View.CustomField3 = accountingObject.CustomField3;
            View.CustomField4 = accountingObject.CustomField4;
            View.CustomField5 = accountingObject.CustomField5;
            View.IsPaidInsuranceForPayrollItem = accountingObject.IsPaidInsuranceForPayrollItem;
            View.IsBornLeave = accountingObject.IsBornLeave;
            View.TaxDepartmentName = accountingObject.TaxDepartmentName;
            View.TreasuryName = accountingObject.TreasuryName;
            View.BudgetChapterId = accountingObject.BudgetChapterId;
            View.BudgetItemId = accountingObject.BudgetItemId;
            View.OrganizationFeeCode = accountingObject.OrganizationFeeCode;
            View.OrganizationManageFee = accountingObject.OrganizationManageFee;
            View.TreasuryManageFee = accountingObject.TreasuryManageFee;
        }
        public void DisplayAccoutingObjectBanks(string objectId)
        {
            View.AccountingObjectBanks = Model.GetProjectBank(objectId);
        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var accountingObject = new AccountingObjectModel
            {
                AccountingObjectId = View.AccountingObjectId,
                AccountingObjectCode = View.AccountingObjectCode,
                AccountingObjectCategoryId = View.AccountingObjectCategoryId,
                AccountingObjectName = View.AccountingObjectName,
                Address = View.Address,
                Tel = View.Tel,
                Fax = View.Fax,
                Website = View.Website,
                BankAccount = View.BankAccount,
                BankName = View.BankName,
                CompanyTaxCode = View.CompanyTaxCode,
                BudgetCode = View.BudgetCode,
                AreaCode = View.AreaCode,
                Description = View.Description,
                ContactName = View.ContactName,
                ContactTitle = View.ContactTitle,
                ContactSex = View.ContactSex,
                ContactMobile = View.ContactMobile,
                ContactEmail = View.ContactEmail,
                ContactOfficeTel = View.ContactOfficeTel,
                ContactHomeTel = View.ContactHomeTel,
                ContactAddress = View.ContactAddress,
                IsEmployee = View.IsEmployee,
                IsPersonal = View.IsPersonal,
                IdentificationNumber = View.IdentificationNumber,
                IssueDate = View.IssueDate,
                IssueBy = View.IssueBy,
                DepartmentId = View.DepartmentId,
                SalaryScaleId = View.SalaryScaleId,
                Insured = View.Insured,
                LabourUnionFee = View.LabourUnionFee,
                FamilyDeductionAmount = View.FamilyDeductionAmount,
                IsActive = View.IsActive,
                ProjectId = View.ProjectId,
                IsCustomerVendor = View.IsCustomerVendor,
                SalaryCoefficient = View.SalaryCoefficient,
                NumberFamilyDependent = View.NumberFamilyDependent,
                EmployeeTypeId = View.EmployeeTypeId,
                SalaryForm = View.SalaryForm,
                SalaryPercentRate = View.SalaryPercentRate,
                SalaryAmount = View.SalaryAmount,
                IsPayInsuranceOnSalary = View.IsPayInsuranceOnSalary,
                InsuranceAmount = View.InsuranceAmount,
                IsUnEmploymentInsurance = View.IsUnEmploymentInsurance,
                RefTypeAO = View.RefTypeAO,
                SalaryGrade = View.SalaryGrade,
                CustomField1 = View.CustomField1,
                CustomField2 = View.CustomField2,
                CustomField3 = View.CustomField3,
                CustomField4 = View.CustomField4,
                CustomField5 = View.CustomField5,
                IsPaidInsuranceForPayrollItem = View.IsPaidInsuranceForPayrollItem,
                IsBornLeave = View.IsBornLeave,
                TaxDepartmentName = View.TaxDepartmentName,
                TreasuryName = View.TreasuryName,
                BudgetChapterId = View.BudgetChapterId,
                BudgetItemId = View.BudgetItemId,
                OrganizationFeeCode = View.OrganizationFeeCode,
                OrganizationManageFee = View.OrganizationManageFee,
                TreasuryManageFee = View.TreasuryManageFee,
                AccountingObjectBanks = View.AccountingObjectBanks
            };
            if (accountingObject.AccountingObjectBanks == null)
            {
                accountingObject.AccountingObjectBanks = new List<BankModel>();
            }
            if (View.AccountingObjectId == null)
                return Model.AddAccountingObject(accountingObject);
            return Model.UpdateAccountingObject(accountingObject);
        }

        ///// <summary>
        ///// Get list Account Category
        ///// </summary>
        ///// <returns>IList{Model.BusinessObjects.Dictionary.AccountCategoryModel}.</returns>
        //public IList<AccountingObjectModel> GetAccountingObjects()
        //{
        //    return Model.GetAccountingObjects();
        //}

        public string Delete(string accountingObjectId)
        {
            return Model.DeleteAccountingObject(accountingObjectId);
        }

        public bool CodeIsExist(string accountingObjectId, string accountingObjectCode, bool isEmployee)
        {
            var accountingObject = Model.GetAccountingObjectsByIsEmployee(isEmployee)
                .Where(x => x.AccountingObjectId != accountingObjectId && x.AccountingObjectCode == accountingObjectCode).ToList();
            return accountingObject.Any();
        }
    }
}
