/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// AccountingObjectModel class
    /// </summary>
    public class AccountingObjectModel
    {
        public IList<BankModel> AccountingObjectBanks { get; set; }
        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the accounting object code.
        /// </summary>
        /// <value>
        /// The accounting object code.
        /// </value>
        public string AccountingObjectCode { get; set; }

        /// <summary>
        /// Gets or sets the accounting object category identifier.
        /// </summary>
        /// <value>
        /// The accounting object category identifier.
        /// </value>
        public string AccountingObjectCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>
        /// The name of the accounting object.
        /// </value>
        public string AccountingObjectName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the tel.
        /// </summary>
        /// <value>
        /// The tel.
        /// </value>
        public string Tel { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>
        /// The fax.
        /// </value>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>
        /// The bank account.
        /// </value>
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>
        /// The name of the bank.
        /// </value>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the company tax code.
        /// </summary>
        /// <value>
        /// The company tax code.
        /// </value>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Gets or sets the budget code.
        /// </summary>
        /// <value>
        /// The budget code.
        /// </value>
        public string BudgetCode { get; set; }

        /// <summary>
        /// Gets or sets the area code.
        /// </summary>
        /// <value>
        /// The area code.
        /// </value>
        public string AreaCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>
        /// The name of the contact.
        /// </value>
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the contact title.
        /// </summary>
        /// <value>
        /// The contact title.
        /// </value>
        public string ContactTitle { get; set; }

        /// <summary>
        /// Gets or sets the contact sex.
        /// </summary>
        /// <value>
        /// The contact sex.
        /// </value>
        public int? ContactSex { get; set; }

        /// <summary>
        /// Gets or sets the contact mobile.
        /// </summary>
        /// <value>
        /// The contact mobile.
        /// </value>
        public string ContactMobile { get; set; }

        /// <summary>
        /// Gets or sets the contact email.
        /// </summary>
        /// <value>
        /// The contact email.
        /// </value>
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the contact office tel.
        /// </summary>
        /// <value>
        /// The contact office tel.
        /// </value>
        public string ContactOfficeTel { get; set; }

        /// <summary>
        /// Gets or sets the contact home tel.
        /// </summary>
        /// <value>
        /// The contact home tel.
        /// </value>
        public string ContactHomeTel { get; set; }

        /// <summary>
        /// Gets or sets the contact address.
        /// </summary>
        /// <value>
        /// The contact address.
        /// </value>
        public string ContactAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is employee].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is employee]; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmployee { get; set; }

        /// <summary>
        /// Gets or sets the is personal.
        /// </summary>
        /// <value>
        /// The is personal.
        /// </value>
        public bool? IsPersonal { get; set; }

        /// <summary>
        /// Gets or sets the identification number.
        /// </summary>
        /// <value>
        /// The identification number.
        /// </value>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets the issue date.
        /// </summary>
        /// <value>
        /// The issue date.
        /// </value>
        public DateTime? IssueDate { get; set; }

        /// <summary>
        /// Gets or sets the issue by.
        /// </summary>
        /// <value>
        /// The issue by.
        /// </value>
        public string IssueBy { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public string DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the salary scale identifier.
        /// </summary>
        /// <value>
        /// The salary scale identifier.
        /// </value>
        public string SalaryScaleId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [insured].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [insured]; otherwise, <c>false</c>.
        /// </value>
        public bool Insured { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [labour union fee].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [labour union fee]; otherwise, <c>false</c>.
        /// </value>
        public bool LabourUnionFee { get; set; }

        /// <summary>
        /// Gets or sets the family deduction amount.
        /// </summary>
        /// <value>
        /// The family deduction amount.
        /// </value>
        public decimal FamilyDeductionAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is customer vendor].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is customer vendor]; otherwise, <c>false</c>.
        /// </value>
        public bool IsCustomerVendor { get; set; }

        /// <summary>
        /// Gets or sets the salary coefficient.
        /// </summary>
        /// <value>
        /// The salary coefficient.
        /// </value>
        public decimal SalaryCoefficient { get; set; }

        /// <summary>
        /// Gets or sets the number family dependent.
        /// </summary>
        /// <value>
        /// The number family dependent.
        /// </value>
        public int NumberFamilyDependent { get; set; }

        /// <summary>
        /// Gets or sets the employee type identifier.
        /// </summary>
        /// <value>
        /// The employee type identifier.
        /// </value>
        public string EmployeeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the salary form.
        /// </summary>
        /// <value>
        /// The salary form.
        /// </value>
        public int SalaryForm { get; set; }

        /// <summary>
        /// Gets or sets the salary percent rate.
        /// </summary>
        /// <value>
        /// The salary percent rate.
        /// </value>
        public decimal SalaryPercentRate { get; set; }

        /// <summary>
        /// Gets or sets the salary amount.
        /// </summary>
        /// <value>
        /// The salary amount.
        /// </value>
        public decimal SalaryAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is pay insurance on salary].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is pay insurance on salary]; otherwise, <c>false</c>.
        /// </value>
        public bool IsPayInsuranceOnSalary { get; set; }

        /// <summary>
        /// Gets or sets the insurance amount.
        /// </summary>
        /// <value>
        /// The insurance amount.
        /// </value>
        public decimal InsuranceAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is un employment insurance].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is un employment insurance]; otherwise, <c>false</c>.
        /// </value>
        public bool IsUnEmploymentInsurance { get; set; }

        /// <summary>
        /// Gets or sets the reference type ao.
        /// </summary>
        /// <value>
        /// The reference type ao.
        /// </value>
        public int RefTypeAO { get; set; }

        /// <summary>
        /// Gets or sets the salary grade.
        /// </summary>
        /// <value>
        /// The salary grade.
        /// </value>
        public int SalaryGrade { get; set; }

        /// <summary>
        /// Gets or sets the custom field1.
        /// </summary>
        /// <value>
        /// The custom field1.
        /// </value>
        public string CustomField1 { get; set; }

        /// <summary>
        /// Gets or sets the custom field2.
        /// </summary>
        /// <value>
        /// The custom field2.
        /// </value>
        public string CustomField2 { get; set; }

        /// <summary>
        /// Gets or sets the custom field3.
        /// </summary>
        /// <value>
        /// The custom field3.
        /// </value>
        public string CustomField3 { get; set; }

        /// <summary>
        /// Gets or sets the custom field4.
        /// </summary>
        /// <value>
        /// The custom field4.
        /// </value>
        public string CustomField4 { get; set; }

        /// <summary>
        /// Gets or sets the custom field5.
        /// </summary>
        /// <value>
        /// The custom field5.
        /// </value>
        public string CustomField5 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is paid insurance for payroll item].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is paid insurance for payroll item]; otherwise, <c>false</c>.
        /// </value>
        public bool IsPaidInsuranceForPayrollItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is born leave].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is born leave]; otherwise, <c>false</c>.
        /// </value>
        public bool IsBornLeave { get; set; }

        /// <summary>
        /// Gets or sets the name of the tax department.
        /// </summary>
        /// <value>
        /// The name of the tax department.
        /// </value>
        public string TaxDepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the name of the treasury.
        /// </summary>
        /// <value>
        /// The name of the treasury.
        /// </value>
        public string TreasuryName { get; set; }

        /// <summary>
        /// Gets or sets the budger chapter identifier.
        /// </summary>
        /// <value>The budger chapter identifier.</value>
        public string BudgetChapterId { get; set; }

        /// <summary>
        /// Gets or sets the fund structure.
        /// </summary>
        /// <value>The fund structure.</value>
        public string FundStructureId { get; set; }
        public string BudgetItemId { get; set; }

        /// <summary>
        /// Gets or sets the organization fee code.
        /// </summary>
        /// <value>The organization fee code.</value>
        public string OrganizationFeeCode { get; set; }

        /// <summary>
        /// Gets or sets the organization manage fee.
        /// </summary>
        /// <value>The organization manage fee.</value>
        public string OrganizationManageFee { get; set; }

        /// <summary>
        /// Gets or sets the treasury manage fee.
        /// </summary>
        /// <value>The treasury manage fee.</value>
        public string TreasuryManageFee { get; set; }
    }
}
