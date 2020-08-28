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
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.EmployeeType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Department;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee
{
    /// <summary>
    /// FrmEmployeeDetail
    /// </summary>
    public partial class FrmEmployeeDetail : FrmXtraBaseCategoryDetail, IAccountingObjectView, IEmployeeTypesView, IDepartmentsView
    {

        #region Parametter
        private readonly AccountingObjectPresenter _accountingObjectPresenter;
        private readonly EmployeeTypesPresenter _employeeTypesPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;
   
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmEmployeeDetail"/> class.
        /// </summary>
        public FrmEmployeeDetail()
        {
            InitializeComponent();
            GlobalVariable.EmployeeIDDetailForm = "";
            _accountingObjectPresenter = new AccountingObjectPresenter(this);
            _employeeTypesPresenter = new EmployeeTypesPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
        }

        #region IAccountingObjectView

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
        public string AccountingObjectCode
        {
            get { return txtEmployeeCode.Text.Trim(); }
            set { txtEmployeeCode.Text = value; }
        }

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
        public string AccountingObjectName
        {
            get { return txtEmployeeName.Text.Trim(); }
            set { txtEmployeeName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address
        {
            get { return txtAddress.Text.Trim(); }
            set { txtAddress.Text = value; }
        }

        /// <summary>
        /// Gets or sets the tel.
        /// </summary>
        /// <value>
        /// The tel.
        /// </value>
        public string Tel
        {
            get { return txtPhoneNumber.Text.Trim(); }
            set { txtPhoneNumber.Text = value; }
        }

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
        public string BankAccount
        {
            get { return txtBankAccount.Text.Trim(); }
            set { txtBankAccount.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>
        /// The name of the bank.
        /// </value>
        public string BankName
        {
            get { return txtBankName.Text.Trim(); }
            set { txtBankName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the company tax code.
        /// </summary>
        /// <value>
        /// The company tax code.
        /// </value>
        public string CompanyTaxCode
        {
            get { return txtCompanyTaxCode.Text.Trim(); }
            set { txtCompanyTaxCode.Text = value; }
        }

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
        public string ContactTitle
        {
            get { return txtContactTitle.Text.Trim(); }
            set { txtContactTitle.Text = value; }
        }

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
        public string ContactEmail
        {
            get { return txtEmail.Text.Trim(); }
            set { txtEmail.Text = value; }
        }

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
        public virtual bool IsEmployee { get; set; }

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
        public string IdentificationNumber
        {
            get { return txtIdentificationNumber.Text.Trim(); }
            set { txtIdentificationNumber.Text = value; }
        }

        /// <summary>
        /// Gets or sets the issue date.
        /// </summary>
        /// <value>
        /// The issue date.
        /// </value>
        public DateTime? IssueDate
        {
            get { return dtIssueDate.EditValue == null ? (DateTime?)null : (DateTime)dtIssueDate.EditValue; }
            set
            {
                dtIssueDate.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the issue by.
        /// </summary>
        /// <value>
        /// The issue by.
        /// </value>
        public string IssueBy
        {
            get { return txtIssueBy.Text; }
            set { txtIssueBy.Text = value; }
        }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public string DepartmentId
        {
            get { return string.IsNullOrEmpty(gridLookUpEditDepartment.Text) ? null : (string)gridLookUpEditDepartment.GetColumnValue("DepartmentId"); }
            set { gridLookUpEditDepartment.EditValue = value; }
        }

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
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

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
        public bool IsCustomerVendor
        {
            get { return chkIsCustomerVendor.Checked; }
            set { chkIsCustomerVendor.Checked = value; }
        }

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
        public int NumberFamilyDependent
        {
            get { return (int)spnNumberFamilyDependent.Value; }
            set { spnNumberFamilyDependent.Value = value; }
        }

        /// <summary>
        /// Gets or sets the employee type identifier.
        /// </summary>
        /// <value>
        /// The employee type identifier.
        /// </value>
        public string EmployeeTypeId
        {
            get { return string.IsNullOrEmpty(gridLookUpEditEmployeeType.Text) ? null : (string)gridLookUpEditEmployeeType.GetColumnValue("EmployeeTypeId"); }
            set { gridLookUpEditEmployeeType.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the salary form.
        /// </summary>
        /// <value>
        /// The salary form.
        /// </value>
        public int SalaryForm
        {
            get { return cboSalaryForm.SelectedIndex; }
            set { cboSalaryForm.SelectedIndex = value; }
        }

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
        public decimal SalaryAmount
        {
            get { return (decimal)spnSalaryAmount.EditValue; }
            set { spnSalaryAmount.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is pay insurance on salary].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is pay insurance on salary]; otherwise, <c>false</c>.
        /// </value>
        public bool IsPayInsuranceOnSalary
        {
            get { return chkIsPayInsuranceOnSalary.Checked; }
            set { chkIsPayInsuranceOnSalary.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the insurance amount.
        /// </summary>
        /// <value>
        /// The insurance amount.
        /// </value>
        public decimal InsuranceAmount
        {
            get { return calInsuranceAmount.Value; }
            set { calInsuranceAmount.Value = value; }
        }

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
        public int SalaryGrade
        {
            get { return (int)spnSalaryGrade.Value; }
            set { spnSalaryGrade.Value = value; }
        }

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
        public bool IsPaidInsuranceForPayrollItem
        {
            get
            {
                if (radIsPaidInsuranceForPayrollItem.SelectedIndex == 1)
                    return true;
                else return false;
            }
            set
            {
                if (value == true)
                    radIsPaidInsuranceForPayrollItem.SelectedIndex = 1;
                else radIsPaidInsuranceForPayrollItem.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is born leave].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is born leave]; otherwise, <c>false</c>.
        /// </value>
        public bool IsBornLeave
        {
            get { return chkIsBornLeave.Checked; }
            set { chkIsBornLeave.Checked = value; }
        }

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
        /// <value>
        /// The budger chapter identifier.
        /// </value>
        public string BudgetChapterId { get; set; }

        /// <summary>
        /// Gets or sets the fund structure.
        /// </summary>
        /// <value>
        /// The fund structure.
        /// </value>
        public string BudgetItemId { get; set; }

        /// <summary>
        /// Gets or sets the organization fee code.
        /// </summary>
        /// <value>
        /// The organization fee code.
        /// </value>
        public string OrganizationFeeCode { get; set; }

        /// <summary>
        /// Gets or sets the organization manage fee.
        /// </summary>
        /// <value>
        /// The organization manage fee.
        /// </value>
        public string OrganizationManageFee { get; set; }

        /// <summary>
        /// Gets or sets the treasury manage fee.
        /// </summary>
        /// <value>
        /// The treasury manage fee.
        /// </value>
        public string TreasuryManageFee { get; set; }

        #endregion

        #region Member

        /// <summary>
        /// Gets or sets the employee models.
        /// </summary>
        /// <value>
        /// The employee models.
        /// </value>
        public IList<EmployeeTypeModel> EmployeeTypes
        {
            set
            {
                gridLookUpEditEmployeeType.Properties.DataSource = value;
                gridLookUpEditEmployeeType.Properties.ForceInitialize();
                gridLookUpEditEmployeeType.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "EmployeeTypeId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "EmployeeTypeCode", ColumnCaption = "Mã loại cán bộ",
                                                    ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100},
                                                new XtraColumn { ColumnName = "EmployeeTypeName", ColumnCaption = "Tên loại cán bộ",
                                                    ColumnPosition = 2, ColumnVisible = true, ColumnWith = 250},
                                                new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridLookUpEditEmployeeType.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridLookUpEditEmployeeType.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        gridLookUpEditEmployeeType.Properties.Columns[column.ColumnName].Visible = false;
                }
                gridLookUpEditEmployeeType.Properties.ValueMember = "EmployeeTypeId";
                gridLookUpEditEmployeeType.Properties.DisplayMember = "EmployeeTypeName";
            }
        }

        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        public IList<DepartmentModel> Departments
        {
            set
            {
                gridLookUpEditDepartment.Properties.DataSource = value;
                gridLookUpEditDepartment.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "DepartmentCode", ColumnCaption = "Mã phòng ban", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100},
                                                new XtraColumn { ColumnName = "DepartmentName", ColumnCaption = "Tên phòng ban", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300},
                                                new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridLookUpEditDepartment.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridLookUpEditDepartment.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else gridLookUpEditDepartment.Properties.Columns[column.ColumnName].Visible = false;
                }
                gridLookUpEditDepartment.Properties.ValueMember = "DepartmentId";
                gridLookUpEditDepartment.Properties.DisplayMember = "DepartmentName";
            }
        }

        #endregion

        #region Form Event

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _employeeTypesPresenter.DisplayActive();
            _departmentsPresenter.DisplayActive();
            if (KeyValue != null)
                _accountingObjectPresenter.Display(KeyValue);
            else IsEmployee = true;
        }
        public IList<BankModel> AccountingObjectBanks { get; set; }
        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtEmployeeCode.Focus();
            calInsuranceAmount.Enabled = false;
            cboSalaryForm.SelectedIndex = 0;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            var result = _accountingObjectPresenter.Save();
            GlobalVariable.EmployeeIDDetailForm = result;
            return result;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(AccountingObjectCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
                return false;
            }
            if (_accountingObjectPresenter.CodeIsExist(AccountingObjectId, AccountingObjectCode, true))
            {
                XtraMessageBox.Show(String.Format(ResourceHelper.GetResourceValueByName("ResEmployeeCodeDuplicate"), AccountingObjectCode),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AccountingObjectName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeName"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(DepartmentId))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyDepartmentID"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditDepartment.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region Control Event

        /// <summary>
        /// Handles the KeyDown event of the gridLookUpEditDepartment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void gridLookUpEditDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridLookUpEditDepartment.SelectionLength == gridLookUpEditDepartment.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                gridLookUpEditDepartment.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the gridLookUpEditEmployeeType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void gridLookUpEditEmployeeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridLookUpEditEmployeeType.SelectionLength == gridLookUpEditDepartment.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                gridLookUpEditEmployeeType.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkIsPayInsuranceOnSalary control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkIsPayInsuranceOnSalary_CheckedChanged(object sender, EventArgs e)
        {
            calInsuranceAmount.Enabled = chkIsPayInsuranceOnSalary.Checked;
            if (chkIsPayInsuranceOnSalary.Checked == false)
            {
                calInsuranceAmount.Text = "";
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPayInsuranceOnSalary.SelectedIndex == 0)
            {
                calInsuranceAmount.Enabled = true;
            }
            else
            {
                calInsuranceAmount.Enabled = false;
                calInsuranceAmount.Text = "";
            }
        }

        private void gridLookUpEditDepartment_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmDepartmentDetail frmDepartmentDetail = new FrmDepartmentDetail();
                frmDepartmentDetail.ShowDialog();
                if (frmDepartmentDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.DepartmentIDEmployeeDetailForm))
                    {
                        _departmentsPresenter.DisplayActive();
                        gridLookUpEditDepartment.EditValue = GlobalVariable.DepartmentIDEmployeeDetailForm;
                    }
                }
            }
        }
        #endregion

    }
}
