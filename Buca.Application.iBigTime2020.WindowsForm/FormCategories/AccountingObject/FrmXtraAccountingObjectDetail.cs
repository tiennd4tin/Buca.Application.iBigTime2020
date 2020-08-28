/***********************************************************************
 * <copyright file="frmxtraaccountingobjectdetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, October 26, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, October 26, 2017 Author SonTV  Description 
 * 
 * ************************************************************************/



using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetChapter;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetItem;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject
{

    /// <summary>
    /// FrmXtraAccountingObjectDetail class
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseCategoryDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectCategoriesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    internal partial class FrmXtraAccountingObjectDetail : FrmXtraBaseCategoryDetail, IAccountingObjectView, IAccountingObjectCategoriesView, IProjectsView, IFundStructuresView, IBudgetChaptersView, IBudgetItemsView
    {

        /// <summary>
        /// The _accounting object presenter
        /// </summary>
        private readonly AccountingObjectPresenter _accountingObjectPresenter;
        /// <summary>
        /// The accounting object categories presenter
        /// </summary>
        private readonly AccountingObjectCategoriesPresenter _accountingObjectCategoriesPresenter;
        /// <summary>
        /// The projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;
        /// <summary>
        /// The fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        /// <summary>
        /// The _banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraAccountingObjectDetail" /> class.
        /// </summary>
        public FrmXtraAccountingObjectDetail()
        {
            InitializeComponent();
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _accountingObjectPresenter = new AccountingObjectPresenter(this);
            _accountingObjectCategoriesPresenter = new AccountingObjectCategoriesPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
        }

        #region Property
        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId
        {
            get;
            set;
        }
        public string AccountingObjectCategoryID { get; set; }
        /// <summary>
        /// Gets or sets the accounting object code.
        /// </summary>
        /// <value>The accounting object code.</value>
        public string AccountingObjectCode
        {
            get { return txtAccountingObjectCode.Text.Trim(); }
            set { txtAccountingObjectCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the accounting object category identifier.
        /// </summary>
        /// <value>The accounting object category identifier.</value>
        public string AccountingObjectCategoryId
        {
            get { return txtAccountingObjectType.EditValue == null ? "" : txtAccountingObjectType.EditValue.ToString(); }
            set { txtAccountingObjectType.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>The name of the accounting object.</value>
        public string AccountingObjectName
        {
            get { return txtAccountingObjectName.Text.Trim(); }
            set { txtAccountingObjectName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address
        {
            get { return txtAddress.Text.Trim(); }
            set { txtAddress.Text = value; }
        }

        /// <summary>
        /// Gets or sets the tel.
        /// </summary>
        /// <value>The tel.</value>
        public string Tel
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>The fax.</value>
        public string Fax
        {
            get { return txtFax.Text; }
            set { txtFax.Text = value; }
        }
        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>The website.</value>
        public string Website
        {
            get { return txtWebsite.Text; }
            set { txtWebsite.Text = value; }
        }
        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        public string BankAccount
        {
            get { return txtBankAccount.Text; }
            set { txtBankAccount.Text = value; }
        }
        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>The name of the bank.</value>
        public string BankName
        {
            get { return txtBankName.Text.Trim(); }
            set { txtBankName.Text = value; }
        }
        /// <summary>
        /// Gets or sets the company tax code.
        /// </summary>
        /// <value>The company tax code.</value>
        public string CompanyTaxCode
        {
            get { return txtTax.Text; }
            set { txtTax.Text = value; }
        }
        /// <summary>
        /// Gets or sets the budget code.
        /// </summary>
        /// <value>The budget code.</value>
        public string BudgetCode
        {
            get { return txtBudgetRelations.Text; }
            set { txtBudgetRelations.Text = value; }
        }
        /// <summary>
        /// Gets or sets the area code.
        /// </summary>
        /// <value>The area code.</value>
        public string AreaCode
        {
            get { return txtAreaCode.Text; }
            set { txtAreaCode.Text = value; }
        }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }
        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>The name of the contact.</value>
        public string ContactName
        {
            get { return txtContactName.Text.Trim(); }
            set { txtContactName.Text = value; }
        }
        /// <summary>
        /// Gets or sets the contact title.
        /// </summary>
        /// <value>The contact title.</value>
        public string ContactTitle
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the contact sex.
        /// </summary>
        /// <value>The contact sex.</value>
        public int? ContactSex
        {
            get { return lookupContactSex.EditValue == null ? 0 : (int)lookupContactSex.EditValue; }
            set { lookupContactSex.EditValue = value; }
        }
        /// <summary>
        /// Gets or sets the contact mobile.
        /// </summary>
        /// <value>The contact mobile.</value>
        public string ContactMobile
        {
            get { return txtContactMobile.Text; }
            set { txtContactMobile.Text = value; }
        }
        /// <summary>
        /// Gets or sets the contact email.
        /// </summary>
        /// <value>The contact email.</value>
        public string ContactEmail
        {
            get { return txtEmail.Text.Trim(); }
            set { txtEmail.Text = value; }
        }
        /// <summary>
        /// Gets or sets the contact office tel.
        /// </summary>
        /// <value>The contact office tel.</value>
        public string ContactOfficeTel
        {
            get { return txtContactOfficeTel.Text; }
            set { txtContactOfficeTel.Text = value; }
        }
        /// <summary>
        /// Gets or sets the contact home tel.
        /// </summary>
        /// <value>The contact home tel.</value>
        public string ContactHomeTel
        {
            get { return txtContactHomeTel.Text; }
            set { txtContactHomeTel.Text = value; }
        }
        /// <summary>
        /// Gets or sets the contact address.
        /// </summary>
        /// <value>The contact address.</value>
        public string ContactAddress
        {
            get { return txtAreaCode.Text.Trim(); }
            set { txtAreaCode.Text = value; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [is employee].
        /// </summary>
        /// <value><c>true</c> if [is employee]; otherwise, <c>false</c>.</value>
        public bool IsEmployee
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the is personal.
        /// </summary>
        /// <value>The is personal.</value>
        public bool? IsPersonal
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the identification number.
        /// </summary>
        /// <value>The identification number.</value>
        public string IdentificationNumber
        {
            get { return txtIdentificationNumber.Text; }
            set { txtIdentificationNumber.Text = value; }
        }
        /// <summary>
        /// Gets or sets the issue date.
        /// </summary>
        /// <value>The issue date.</value>
        public DateTime? IssueDate
        {
            get { return dateIssueDate.EditValue == null ? (DateTime?)null : (DateTime)dateIssueDate.EditValue; }
            set { dateIssueDate.EditValue = value; }
        }
        /// <summary>
        /// Gets or sets the issue by.
        /// </summary>
        /// <value>The issue by.</value>
        public string IssueBy
        {
            get { return txtIssueBy.Text; }
            set { txtIssueBy.Text = value; }
        }
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        public string DepartmentId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the salary scale identifier.
        /// </summary>
        /// <value>The salary scale identifier.</value>
        public string SalaryScaleId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [insured].
        /// </summary>
        /// <value><c>true</c> if [insured]; otherwise, <c>false</c>.</value>
        public bool Insured
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [labour union fee].
        /// </summary>
        /// <value><c>true</c> if [labour union fee]; otherwise, <c>false</c>.</value>
        public bool LabourUnionFee
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the family deduction amount.
        /// </summary>
        /// <value>The family deduction amount.</value>
        public decimal FamilyDeductionAmount
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return (bool)cbIsActive.EditValue; }
            set { cbIsActive.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is customer vendor].
        /// </summary>
        /// <value><c>true</c> if [is customer vendor]; otherwise, <c>false</c>.</value>
        public bool IsCustomerVendor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the salary coefficient.
        /// </summary>
        /// <value>The salary coefficient.</value>
        public decimal SalaryCoefficient { get; set; }

        /// <summary>
        /// Gets or sets the number family dependent.
        /// </summary>
        /// <value>The number family dependent.</value>
        public int NumberFamilyDependent { get; set; }

        /// <summary>
        /// Gets or sets the employee type identifier.
        /// </summary>
        /// <value>The employee type identifier.</value>
        public string EmployeeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the salary form.
        /// </summary>
        /// <value>The salary form.</value>
        public int SalaryForm { get; set; }

        /// <summary>
        /// Gets or sets the salary percent rate.
        /// </summary>
        /// <value>The salary percent rate.</value>
        public decimal SalaryPercentRate { get; set; }

        /// <summary>
        /// Gets or sets the salary amount.
        /// </summary>
        /// <value>The salary amount.</value>
        public decimal SalaryAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is pay insurance on salary].
        /// </summary>
        /// <value><c>true</c> if [is pay insurance on salary]; otherwise, <c>false</c>.</value>
        public bool IsPayInsuranceOnSalary { get; set; }

        /// <summary>
        /// Gets or sets the insurance amount.
        /// </summary>
        /// <value>The insurance amount.</value>
        public decimal InsuranceAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is un employment insurance].
        /// </summary>
        /// <value><c>true</c> if [is un employment insurance]; otherwise, <c>false</c>.</value>
        public bool IsUnEmploymentInsurance { get; set; }

        /// <summary>
        /// Gets or sets the reference type ao.
        /// </summary>
        /// <value>The reference type ao.</value>
        public int RefTypeAO { get; set; }

        /// <summary>
        /// Gets or sets the salary grade.
        /// </summary>
        /// <value>The salary grade.</value>
        public int SalaryGrade { get; set; }

        /// <summary>
        /// Gets or sets the custom field1.
        /// </summary>
        /// <value>The custom field1.</value>
        public string CustomField1 { get; set; }

        /// <summary>
        /// Gets or sets the custom field2.
        /// </summary>
        /// <value>The custom field2.</value>
        public string CustomField2 { get; set; }

        /// <summary>
        /// Gets or sets the custom field3.
        /// </summary>
        /// <value>The custom field3.</value>
        public string CustomField3 { get; set; }

        /// <summary>
        /// Gets or sets the custom field4.
        /// </summary>
        /// <value>The custom field4.</value>
        public string CustomField4 { get; set; }

        /// <summary>
        /// Gets or sets the custom field5.
        /// </summary>
        /// <value>The custom field5.</value>
        public string CustomField5 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is paid insurance for payroll item].
        /// </summary>
        /// <value><c>true</c> if [is paid insurance for payroll item]; otherwise, <c>false</c>.</value>
        public bool IsPaidInsuranceForPayrollItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is born leave].
        /// </summary>
        /// <value><c>true</c> if [is born leave]; otherwise, <c>false</c>.</value>
        public bool IsBornLeave { get; set; }

        /// <summary>
        /// Gets or sets the name of the tax department.
        /// </summary>
        /// <value>The name of the tax department.</value>
        public string TaxDepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the name of the treasury.
        /// </summary>
        /// <value>The name of the treasury.</value>
        public string TreasuryName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>The project identifier.</value>
        public string ProjectId
        {
            get { return lkUpTargetProgram.EditValue == null ? "" : (lkUpTargetProgram.EditValue).ToString(); }
            set { lkUpTargetProgram.EditValue = value; }
        }
        #endregion

        public IList<BankModel> AccountingObjectBanks
        {
            get
            {
                var banks = new List<BankModel>();
                if (grdBankView.DataSource != null && grdBankView.RowCount > 0)
                {
                    for (var i = 0; i < grdBankView.RowCount; i++)
                    {
                        var rowVoucher = (BankModel)grdBankView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            
                            var item = new BankModel()
                            {
                                BankId = rowVoucher.BankId,
                                BankAccount = rowVoucher.BankAccount,
                                BankName = rowVoucher.BankName,
                                SortBank = rowVoucher.SortBank,
                            };
                            banks.Add(item);
                        }
                    }
                  
                    //var getLastBank = banks[banks.Count - 1];
                    //if(getLastBank.BankId == null)
                    //{
                    //    banks.RemoveAt(banks.Count - 1);
                    //    var bankLast = new BankModel()
                    //    {
                    //        BankId = Guid.NewGuid().ToString(),
                    //        BankAccount = getLastBank.BankAccount,
                    //        BankName = getLastBank.BankName,
                    //        IsActive = true,
                    //    };
                    //    GlobalVariable.BankObjectId = bankLast.BankId;
                    //    banks.Add(bankLast);
                    //}
                    //else
                    //    GlobalVariable.BankObjectId = getLastBank.BankId;
                    //GlobalVariable.BankObjectName = getLastBank.BankName;
                }
                return banks;
            }
            set
            {
                bindingSourceDetail.DataSource = value ?? new List<BankModel>();
                grdBankView.PopulateColumns(value);

                #region columns for grdBankView
                var columnsCollection = new List<XtraColumn>
                {
                 new XtraColumn{ColumnName = "BankId", ColumnVisible = false, AllowEdit = true},
                 new XtraColumn{ColumnName = "BankAddress", ColumnVisible = false, AllowEdit = true},
                 new XtraColumn{ColumnName = "BudgetCode", ColumnVisible = false, AllowEdit = true},
                 new XtraColumn{ColumnName = "Description", ColumnVisible = false, AllowEdit = true},
                 new XtraColumn{ColumnName = "IsActive", ColumnVisible = false, AllowEdit = true},
                 new XtraColumn{ColumnName = "IsOpenInBank", ColumnVisible = false, AllowEdit = true},
                 new XtraColumn{ColumnName = "Used", ColumnVisible = false, AllowEdit = true},
                  new XtraColumn{ColumnName = "SortBank", ColumnVisible = false, AllowEdit = true},
                new XtraColumn
                {
                    ColumnName = "BankAccount",
                    ColumnVisible = true,
                    ColumnWith = 320,
                    ColumnCaption = "Số tài khoản",
                    ColumnPosition = 1,
                    AllowEdit = true,
                    
                },

                new XtraColumn
                {
                    ColumnName = "BankName",
                    ColumnVisible = true,
                    ColumnWith = 390,
                    ColumnCaption = "Tên ngân hàng",
                    ColumnPosition = 2,
                    AllowEdit = true
                },
            };
                grdBankView = InitGridLayout(columnsCollection, grdBankView);
                SetNumericFormatControl(grdBankView, true);
                grdBankView.OptionsView.ShowFooter = false;
                grdBankView.OptionsCustomization.AllowSort = false;
                grdBankView.ViewCaption = "";

                #endregion
            }
        }
        private void grdAccountingView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                if (grdBankView.RowCount == 0)
                {
                    view.SetRowCellValue(e.RowHandle, "SortBank", 0);
                }
                else
                {
                    //int sort = (Int32)grdBankView.GetRowCellValue(0, "SortBank");
                    var source = grdBankView.DataSource;
                    List<decimal> values = new List<decimal>();
                    for (int i = 0; i < grdBankView.RowCount; i++)
                    {
                        decimal value = Convert.ToDecimal(grdBankView.GetRowCellValue(i, "SortBank"));
                        values.Add(value);
                    }
                    values.Sort();
                    decimal sort = values[grdBankView.RowCount - 1];
                    view.SetRowCellValue(e.RowHandle, "SortBank", sort + 1);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Clipboard.Clear();
            }
        }
        private void OnGrid_Mag_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.InRow)
            {
                var result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContent"), ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    var used = (bool)view.GetRowCellValue(hitInfo.RowHandle, "Used");
                    var bankAccount = view.GetRowCellValue(hitInfo.RowHandle, "BankAccount").ToString() == null ? "" : view.GetRowCellValue(hitInfo.RowHandle, "BankAccount").ToString();
                    if (used)
                    {
                        XtraMessageBox.Show(
                                "Bạn không thể xóa: "+bankAccount + "vì đã phát sinh trong chứng từ hoặc danh mục liên quan!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        view.DeleteRow(hitInfo.RowHandle);
                    }
               
                }             
            }
        }
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
            {
                if (column.ColumnVisible)
                {
                    grdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    grdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                    grdView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    grdView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                    grdView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                    grdView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    grdView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    grdView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                    if (column.IsSummaryText)
                    {
                        grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                        grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                    }
                }
                else
                {
                    grdView.Columns[column.ColumnName].Visible = false;
                }
            }
            return grdView;
        }
        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                this.grdBankView.DeleteRow(this.grdBankView.FocusedRowHandle);
            }
        }
        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>The banks.</value>
        //public IList<BankModel> Banks
        //{
        //    set
        //    {
        //        lkuBankId.Properties.DataSource = value;
        //        lkuBankId.Properties.PopulateColumns();
        //        var treeColumnsCollection = new List<XtraColumn> {
        //                                        new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
        //                                        new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnPosition = 1, ColumnVisible = true },
        //                                        new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false },
        //                                        new XtraColumn { ColumnName = "BankAddress", ColumnVisible = false },
        //                                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
        //                                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
        //                                    };
        //        foreach (var column in treeColumnsCollection)
        //        {
        //            if (column.ColumnVisible)
        //            {
        //                lkuBankId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
        //                lkuBankId.Properties.SortColumnIndex = column.ColumnPosition;
        //            }
        //            else lkuBankId.Properties.Columns[column.ColumnName].Visible = false;
        //        }
        //        lkuBankId.Properties.ValueMember = "BankId";
        //        lkuBankId.Properties.DisplayMember = "BankName";
        //    }
        //}

        public IList<AccountingObjectCategoryModel> AccountingObjectCategories
        {
            set
            {
                txtAccountingObjectType.Properties.DataSource = value;
                txtAccountingObjectType.Properties.ForceInitialize();
                txtAccountingObjectType.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "AccountingObjectCategoryId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "AccountingObjectCategoryName", ColumnCaption = "Tên loại đối tượng", ColumnPosition = 1, ColumnVisible = true},
                                                new XtraColumn { ColumnName = "AccountingObjectCategoryCode", ColumnCaption = "Mã loại đối tượng", ColumnPosition = 1, ColumnVisible = true},
                                                new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        txtAccountingObjectType.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        txtAccountingObjectType.Properties.SortColumnIndex = column.ColumnPosition;
                        txtAccountingObjectType.Properties.PopupWidth = 594;
                        txtAccountingObjectType.Properties.Columns[2].Width = 394;
                        txtAccountingObjectType.Properties.Columns[1].Width = 200;
                    }
                    else
                        txtAccountingObjectType.Properties.Columns[column.ColumnName].Visible = false;
                }
                txtAccountingObjectType.Properties.ValueMember = "AccountingObjectCategoryId";
                txtAccountingObjectType.Properties.DisplayMember = "AccountingObjectCategoryName";
            }
        }

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public IList<ProjectModel> Projects
        {
            set
            {
                lkUpTargetProgram.Properties.DataSource = value;
                lkUpTargetProgram.Properties.ForceInitialize();
                lkUpTargetProgram.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ProjectName", ColumnCaption = "Tên CTMT/Dự án", ColumnPosition = 1, ColumnVisible = true },
                                                new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã CTMT/Dự án", ColumnPosition = 1, ColumnVisible = true },

                                                 new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "StartDate", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "ParentID", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "IsActive",ColumnCaption = "Được sử dụng", ColumnPosition = 1, ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "ObjectTypeName",ColumnCaption = "Loại", ColumnPosition = 1, ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "Investment", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lkUpTargetProgram.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lkUpTargetProgram.Properties.SortColumnIndex = column.ColumnPosition;
                        lkUpTargetProgram.Properties.PopupWidth = 500;
                        lkUpTargetProgram.Properties.Columns[2].Width = 300;
                        lkUpTargetProgram.Properties.Columns[1].Width = 200;
                    }
                    else
                        lkUpTargetProgram.Properties.Columns[column.ColumnName].Visible = false;
                }
                lkUpTargetProgram.Properties.ValueMember = "ProjectId";
                lkUpTargetProgram.Properties.DisplayMember = "ProjectCode";

            }
        }

        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>The fund structures.</value>
        public IList<FundStructureModel> FundStructures
        {
            set
            {
                //lookUpFundStructureId.Properties.DataSource = value;
                //lookUpFundStructureId.Properties.PopulateColumns();
                //var treeColumnsCollection = new List<XtraColumn> {
                //                                new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "FundStructureName", ColumnCaption = "Tên NDKT", ColumnPosition = 1, ColumnVisible = true },
                //                                new XtraColumn { ColumnName = "FundStructureCode", ColumnCaption = "Mã NDKT", ColumnPosition = 1, ColumnVisible = true },
                //                                new XtraColumn { ColumnName = "Inactive", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "BUCACodeId", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "Inactive", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                //                                new XtraColumn { ColumnName = "InvestmentPeriod", ColumnVisible = false },


                //                            };
                //foreach (var column in treeColumnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        lookUpFundStructureId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        lookUpFundStructureId.Properties.SortColumnIndex = column.ColumnPosition;
                //        lookUpFundStructureId.Properties.PopupWidth = 500;
                //        lookUpFundStructureId.Properties.Columns[2].Width = 300;
                //        lookUpFundStructureId.Properties.Columns[1].Width = 200;
                //    }
                //    else
                //        lookUpFundStructureId.Properties.Columns[column.ColumnName].Visible = false;
                //}
                //lookUpFundStructureId.Properties.ValueMember = "FundStructureId";
                //lookUpFundStructureId.Properties.DisplayMember = "FundStructureCode";

            }
        }

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                lookUpBudgetChapterId.Properties.DataSource = value;
                lookUpBudgetChapterId.Properties.ForceInitialize();
                lookUpBudgetChapterId.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BudgetChapterName", ColumnCaption = "Tên chương", ColumnPosition = 1, ColumnVisible = true },
                                                new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Mã chương", ColumnPosition = 1, ColumnVisible = true },
                                                new XtraColumn { ColumnName = "IsActive",ColumnCaption = "Được sử dụng", ColumnPosition = 1, ColumnVisible = false },

                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lookUpBudgetChapterId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lookUpBudgetChapterId.Properties.SortColumnIndex = column.ColumnPosition;
                        lookUpBudgetChapterId.Properties.PopupWidth = 500;
                        lookUpBudgetChapterId.Properties.Columns[2].Width = 300;
                        lookUpBudgetChapterId.Properties.Columns[1].Width = 100;
                        lookUpBudgetChapterId.Properties.Columns[3].Width = 100;
                    }
                    else
                        lookUpBudgetChapterId.Properties.Columns[column.ColumnName].Visible = false;
                }
                lookUpBudgetChapterId.Properties.ValueMember = "BudgetChapterId";
                lookUpBudgetChapterId.Properties.DisplayMember = "BudgetChapterCode";
            }
        }

        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                lookUpFundStructureId.Properties.DataSource = value;
                lookUpFundStructureId.Properties.ForceInitialize();
                lookUpFundStructureId.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                  new XtraColumn{ColumnName = "BudgetItemId",ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetItemCode",ColumnCaption = "Mã NDKT",ColumnPosition = 1,ColumnVisible = true,ColumnWith = 110},
                    new XtraColumn{ColumnName = "BudgetItemName",ColumnCaption = "Tên NDKT ",ColumnPosition = 2,ColumnVisible = true,ColumnWith = 380},
                    new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetItemType", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
            };

                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lookUpFundStructureId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lookUpFundStructureId.Properties.SortColumnIndex = column.ColumnPosition;
                        //lookUpFundStructureId.Properties.PopupWidth = 500;
                        // lookUpFundStructureId.Properties.Columns[2].Width = 350;
                        //lookUpFundStructureId.Properties.Columns[1].Width = 150;
                        lookUpFundStructureId.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        lookUpFundStructureId.Properties.Columns[column.ColumnName].Visible = false;
                }
                lookUpFundStructureId.Properties.ValueMember = "BudgetItemId";
                lookUpFundStructureId.Properties.DisplayMember = "BudgetItemCode";
            }
        }

        /// <summary>
        /// Gets or sets the budger chapter identifier.
        /// </summary>
        /// <value>The budger chapter identifier.</value>
        public string BudgetChapterId
        {
            get
            {
                return lookUpBudgetChapterId.EditValue == null ? "" : lookUpBudgetChapterId.EditValue.ToString();
            }

            set
            {
                lookUpBudgetChapterId.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the fund structure.
        /// </summary>
        /// <value>The fund structure.</value>
        public string FundStructureId { get; set; }

        public string BudgetItemId
        {
            get
            {
                return lookUpFundStructureId.EditValue == null ? "" : lookUpFundStructureId.EditValue.ToString();
            }

            set
            {
                lookUpFundStructureId.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the organization fee code.
        /// </summary>
        /// <value>The organization fee code.</value>
        public string OrganizationFeeCode
        {
            get
            {
                return txtOrganizationFeeCode.Text;
            }

            set
            {
                txtOrganizationFeeCode.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the organization manage fee.
        /// </summary>
        /// <value>The organization manage fee.</value>
        public string OrganizationManageFee
        {
            get
            {
                return txtOrganizationManageFee.Text;
            }

            set
            {
                txtOrganizationManageFee.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the treasury manage fee.
        /// </summary>
        /// <value>The treasury manage fee.</value>
        public string TreasuryManageFee
        {
            get
            {
                return txtTreasuryManageFee.Text;
            }

            set
            {
                txtTreasuryManageFee.Text = value;
            }
        }

        /// <summary>
        /// Binds the look up sex.
        /// </summary>
        protected void BindLookUpSex()
        {
            var bankSource = new List<ComboLookUpItem> { new ComboLookUpItem { Id = 0, Name = "Nam" }, new ComboLookUpItem { Id = 1, Name = "Nữ" } };
            lookupContactSex.Properties.DataSource = bankSource;
            lookupContactSex.Properties.ForceInitialize();
            lookupContactSex.Properties.PopulateColumns();
            var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "Id", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Name", ColumnCaption = "Giới tính", ColumnPosition = 1, ColumnVisible = true }
                                            };
            foreach (var column in treeColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    lookupContactSex.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    lookupContactSex.Properties.SortColumnIndex = column.ColumnPosition;
                }
                else
                    lookupContactSex.Properties.Columns[column.ColumnName].Visible = false;
            }
            lookupContactSex.Properties.ValueMember = "Id";
            lookupContactSex.Properties.DisplayMember = "Name";
        }

        #region override

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            groupboxMain.Text = ResourceHelper.GetResourceValueByName("ResCommonCaption");
            grbContactInfo.Text = ResourceHelper.GetResourceValueByName("ResContactCaption");
            dateIssueDate.Properties.MaxValue = DateTime.Now;
            base.InitControls();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountingObjectPresenter.DisplayAccoutingObjectBanks(KeyValue);
            if (KeyValue != null)
            {
                _accountingObjectPresenter.Display(KeyValue);
            }

            else
            {
                txtAccountingObjectCode.Text = GetAutoNumber();
                lookupContactSex.EditValue = 0;
                // dateIssueDate.EditValue = DateTime.Now;
            }
            // _banksPresenter.DisplayActive(true);
            _budgetItemsPresenter.DisplayActive(true);
            _accountingObjectCategoriesPresenter.Display();
            _projectsPresenter.Display();
            _budgetChaptersPresenter.Display();
            _fundStructuresPresenter.Display();
            if (KeyValue != null)
            {
                if (lkUpTargetProgram.GetColumnValue("ProjectName") != null)
                    txtProjectName.EditValue = lkUpTargetProgram.GetColumnValue("ProjectName").ToString();
            }
            BindLookUpSex();
            if (!String.IsNullOrEmpty(AccountingObjectCategoryID))
                txtAccountingObjectType.EditValue = AccountingObjectCategoryID;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(AccountingObjectCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountingObjectCode.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(AccountingObjectCode) && IsEmployee && _accountingObjectPresenter.CodeIsExist(KeyValue, txtAccountingObjectCode.Text, true))
            {
                XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResAccountingObjectCodeEmployeeDuplicate"), AccountingObjectCode),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccountingObjectCode.Text = "";
                txtAccountingObjectCode.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(AccountingObjectCode) && !IsEmployee && _accountingObjectPresenter.CodeIsExist(KeyValue, txtAccountingObjectCode.Text, false))
            {
                XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResAccountingObjectCodeDuplicate"), AccountingObjectCode),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccountingObjectCode.Text = "";
                txtAccountingObjectCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AccountingObjectName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountingObjectName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AccountingObjectCategoryId))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingObjectCategoryID"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountingObjectName.Focus();
                return false;
            }


            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string SaveData()
        {

            var sResult = _accountingObjectPresenter.Save();
            if (!string.IsNullOrEmpty(sResult))
            {
                GlobalVariable.AccountingObjectIDInventoryItemDetailForm = sResult;
                this.DialogResult = DialogResult.OK;
            }
            return sResult;           
        }
        #endregion

        #region Event control

        /// <summary>
        /// Handles the EditValueChanged event of the lkUpTargetProgram control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lkUpTargetProgram_EditValueChanged(object sender, EventArgs e)
        {
            if (lkUpTargetProgram.GetColumnValue("ProjectName") != null)
                txtProjectName.EditValue = lkUpTargetProgram.GetColumnValue("ProjectName").ToString();
            else
                txtProjectName.EditValue = "";
        }

        private void lkUpTargetProgram_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmProjectDetail frmProjectDetail = new FrmProjectDetail();
                frmProjectDetail.ShowDialog();
                if (frmProjectDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.ProjectIDAccountingObjectDetailForm))
                    {
                        _projectsPresenter.Display();
                        lkUpTargetProgram.EditValue = GlobalVariable.ProjectIDAccountingObjectDetailForm;
                    }
                }
            }
        }

        private void lookUpBudgetChapterId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmBudgetChapterDetail frmBudgetChapterDetail = new FrmBudgetChapterDetail();
                frmBudgetChapterDetail.ShowDialog();
                if (frmBudgetChapterDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetChapterIDAccountingObjectDetailForm))
                    {
                        _budgetChaptersPresenter.Display();
                        lookUpBudgetChapterId.EditValue = GlobalVariable.BudgetChapterIDAccountingObjectDetailForm;
                    }
                }
            }
        }

        private void lookUpFundStructureId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmBudgetItemDetail frmBudgetItemDetail = new FrmBudgetItemDetail();
                frmBudgetItemDetail.ShowDialog();
                if (frmBudgetItemDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetItemDetailAccountingObjectDetailForm))
                    {
                        _budgetItemsPresenter.Display();
                        lookUpFundStructureId.EditValue = GlobalVariable.BudgetItemDetailAccountingObjectDetailForm;
                    }
                }
            }
        }
        #endregion
        public void SelectTab(int tab)
        {
            tabControl1.SelectTab(tab);
            if (tab == 0)
                ((Control)this.tabPage2).Enabled = false;
            else
                ((Control)this.tabPage1).Enabled = false;
        }
    }
}