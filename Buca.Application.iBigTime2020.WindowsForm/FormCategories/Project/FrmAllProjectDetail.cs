/***********************************************************************
 * <copyright file="FrmXtraAccountingObjectDetail.cs" company="BUCA JSC">
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
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using System.Data;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Department;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project
{

    /// <summary>
    /// FrmXtraAccountingObjectDetail class
    /// </summary>
    internal partial class FrmAllProjectDetail : FrmXtraBaseTreeDetail, IProjectView, IProjectsView, IBanksView, IAccountingObjectsView
    //, IAccountingObjectView, IBanksView, IAccountingObjectCategoriesView
    {
        /// <summary>
        /// The _accounting object presenter
        /// </summary>
        private readonly AccountingObjectPresenter _accountingObjectPresenter;
        private readonly AccountingObjectCategoriesPresenter _accountingObjectCategoriesPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly ProjectPresenter _projectPresenter;
        public bool EditBank { get; set; }
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        /// <summary>
        /// The _banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraAccountingObjectDetail"/> class.
        /// </summary>
        public FrmAllProjectDetail()
        {
            InitializeComponent();
            _projectPresenter = new ProjectPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
        }

        #region Implement

        public string ProjectId
        {
            get;
            set;
        }
        public string ProjectCode
        {
            get
            {
                return txtProjectCode.Text.Trim();
            }
            set
            {
                txtProjectCode.Text = value;
            }
        }
        public string ProjectNumber
        {
            get
            {
                return txtProjectNumber.Text;
            }
            set
            {
                txtProjectNumber.Text = value;
            }
        }
        public string ProjectName
        {
            get
            {
                return txtProjectName.Text.Trim();
            }
            set
            {
                txtProjectName.Text = value;
            }
        }

        public string ProjectEnglishName
        {
            get;
            set;
        }

        public string BUCACodeID
        {
            get;
            set;
        }

        public DateTime? StartDate
        {
            get
            {
                return (DateTime?)dateStartDate.EditValue;
            }
            set
            {
                dateStartDate.EditValue = value;
            }
        }

        public DateTime? FinishDate
        {
            get
            {
                return (DateTime?)dateFinishDate.EditValue;
            }
            set
            {
                dateFinishDate.EditValue = value;
            }
        }

        public string ExecutionUnit
        {
            get
            {
                return lukExecutionUnit.EditValue == null ? "" : (lukExecutionUnit.EditValue).ToString();
            }
            set
            {
                lukExecutionUnit.EditValue = value;
            }
        }

        public string DepartmentID
        {
            get;
            set;
        }

        public decimal TotalAmountApproved
        {
            get
            {
                return calcTotalAmountApproved.EditValue == null ? 0 :(decimal)calcTotalAmountApproved.EditValue;
            }
            set
            {
                calcTotalAmountApproved.EditValue = value;
            }
        }

        public string ParentID
        {
            get { return lkUpTargetProgram.EditValue == null ? "" : (lkUpTargetProgram.EditValue).ToString(); }
            set { lkUpTargetProgram.EditValue = value; }
        }

        public int Grade
        {
            get;
            set;
        }

        public bool IsParent
        {
            get;
            set;
        }

        public bool IsDetailbyActivityAndExpense
        {
            get;
            set;
        }
        public bool IsSystem
        {
            get;
            set;
        }
        public bool IsActive
        {
            get
            {
                return cbIsActive.Checked;
            }
            set
            {
                cbIsActive.Checked = value;
            }
        }

        public int? ObjectType
        {
            get;
            set;
        }

        public string ContractorID
        {
            get;
            set;
        }

        public string ContractorName
        {
            get;
            set;
        }

        public string ContractorAddress
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string ProjectSize
        {
            get;
            set;
        }

        public string BuildLocation
        {
            get
            {
                return txtBuildLacation.Text;
            }

            set
            {
                txtBuildLacation.Text = value;
            }
        }

        public string InvestmentClass
        {
            get
            {
                return txtInvestmentClass.Text;
            }

            set
            {
                txtInvestmentClass.Text = value;
            }
        }

        public int? CDCActivityType
        {
            get;
            set;
        }
        public string BankId
        {
            get { return lkuBankAccount.EditValue == null ? "" : (lkuBankAccount.EditValue).ToString(); }
            set { lkuBankAccount.EditValue = value; }
        }
        public string Investment
        {
            get
            {
                return txtInvest.Text;
            }

            set
            {
                txtInvest.Text = value;
            }
        }

        public IList<BankModel> Banks
        {
            set
            {
                lkuBankAccount.Properties.DataSource = value;
                lkuBankAccount.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsOpenInBank", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số tài khoản", ColumnPosition = 1, ColumnVisible = true },
                                                new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnPosition = 1, ColumnVisible = true },
                                                new XtraColumn { ColumnName = "BankAddress", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 1, ColumnVisible = false },
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lkuBankAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lkuBankAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        lkuBankAccount.Properties.PopupWidth = 500;
                        lkuBankAccount.Properties.Columns[2].Width = 300;
                        lkuBankAccount.Properties.Columns[1].Width = 100;
                    }
                    else lkuBankAccount.Properties.Columns[column.ColumnName].Visible = false;
                }
                lkuBankAccount.Properties.ValueMember = "BankId";
                lkuBankAccount.Properties.DisplayMember = "BankAccount";
            }
        }
        public IList<ProjectModel> Projects
        {
            set
            {
                var result = new List<ProjectModel>
                {
                    new ProjectModel {ProjectCode = "", ProjectName = ""},
                };

                result.AddRange(value);

                lkUpTargetProgram.Properties.DataSource = result;
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
                                                 new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "Investment", ColumnVisible = false },
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lkUpTargetProgram.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lkUpTargetProgram.Properties.SortColumnIndex = column.ColumnPosition;
                        lkUpTargetProgram.Properties.PopupWidth = 500;
                        lkUpTargetProgram.Properties.Columns[2].Width = 300;
                        lkUpTargetProgram.Properties.Columns[1].Width = 100;
                        lkUpTargetProgram.Properties.Columns[3].Width = 100;
                    }
                    else lkUpTargetProgram.Properties.Columns[column.ColumnName].Visible = false;
                }
                lkUpTargetProgram.Properties.ValueMember = "ProjectId";
                lkUpTargetProgram.Properties.DisplayMember = "ProjectCode";
            }
        }

        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                lukExecutionUnit.Properties.DataSource = value;
                lukExecutionUnit.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã đối tượng", ColumnPosition = 1, ColumnVisible = true },
                                                new XtraColumn { ColumnName = "AccountingObjectName", ColumnCaption = "Tên đối tượng", ColumnPosition = 1, ColumnVisible = true },
                                                new XtraColumn { ColumnName = "AccountingObjectCategoryId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Address", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Tel", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Fax", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Website", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BankName", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CompanyTaxCode", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "AreaCode", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactName", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactTitle", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactSex", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactMobile", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactEmail", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactOfficeTel", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactHomeTel", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactAddress", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsPersonal", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IdentificationNumber", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IssueDate", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IssueBy", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryScaleId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Insured", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "LabourUnionFee", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "FamilyDeductionAmount", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsCustomerVendor", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryCoefficient", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "NumberFamilyDependent", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryForm", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryPercentRate", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryAmount", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsPayInsuranceOnSalary", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "InsuranceAmount", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsUnEmploymentInsurance", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "RefTypeAO", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryGrade", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CustomField1", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CustomField2", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CustomField3", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CustomField4", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CustomField5", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsPaidInsuranceForPayrollItem", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsBornLeave", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "TaxDepartmentName", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "TreasuryName", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "EmployeeTypeId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 1, ColumnVisible = false },
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (lukExecutionUnit.Properties.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            lukExecutionUnit.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            lukExecutionUnit.Properties.SortColumnIndex = column.ColumnPosition;
                            lukExecutionUnit.Properties.PopupWidth = 500;
                            lukExecutionUnit.Properties.Columns[2].Width = 300;
                            lukExecutionUnit.Properties.Columns[1].Width = 100;
                        }
                        else lukExecutionUnit.Properties.Columns[column.ColumnName].Visible = false;
                    }

                }
                lukExecutionUnit.Properties.ValueMember = "AccountingObjectId";
                lukExecutionUnit.Properties.DisplayMember = "AccountingObjectName";
            }
        }

        public IList<BankModel> ProjectBanks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }





        #endregion

        #region override

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            groupboxMain.Text = ResourceHelper.GetResourceValueByName("ResCommonCaption");
            dateStartDate.Properties.MaxValue = DateTime.Now;
            dateFinishDate.EditValue = DateTime.Now;
            base.InitControls();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _banksPresenter.Display();
            _accountingObjectsPresenter.Display();
            _projectsPresenter.Display();
            _banksPresenter.DisplayActive(true);
            if (KeyValue != null)
            {
                _projectPresenter.Display(KeyValue);
                txtTargetProjectName.EditValue = ProjectName;
                txtxBankName.EditValue = lkuBankAccount.GetColumnValue("BankName") == null ? "" : lkuBankAccount.GetColumnValue("BankName").ToString();
            }
            else
            {
                dateStartDate.EditValue = DateTime.Now;
            }          
          
          
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(ProjectCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResProjectCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProjectCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(ProjectName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResProjectName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProjectName.Focus();
                return false;
            }
            if(StartDate > FinishDate )
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDateCompare"),
                               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateStartDate.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            ObjectType = 2;
            return _projectPresenter.Save();
        }
        #endregion

        #region Event

        private void cbIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Event control

        private void lukExecutionUnit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lkuBankAccount_EditValueChanged(object sender, EventArgs e)
        {
            if (lkuBankAccount.GetColumnValue("BankName") != null)
                txtxBankName.EditValue = lkuBankAccount.GetColumnValue("BankName").ToString();
            else
                txtxBankName.EditValue = "";
        }

        private void lkUpTargetProgram_EditValueChanged_1(object sender, EventArgs e)
        {
            if (lkUpTargetProgram.GetColumnValue("ProjectName") != null)
                txtTargetProjectName.EditValue = lkUpTargetProgram.GetColumnValue("ProjectName").ToString();
            else
                txtTargetProjectName.EditValue = "";
        }


        /// <summary>
        /// Button thêm mới CTMT
        /// </summary>
        private void lkUpTargetProgram_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

        /// <summary>
        /// Button thêm mới bank
        /// </summary>
        private void lkuBankAccount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBankDetail = new FrmBankDetail();
                frmBankDetail.ShowDialog();
                if (frmBankDetail.CloseBox)
                {
                    if (!String.IsNullOrEmpty(GlobalVariable.BankIDProjectDetailForm))
                    {
                        _banksPresenter.DisplayActive(true);
                        lkuBankAccount.EditValue = GlobalVariable.BankIDProjectDetailForm;
                    }
                }
            }
        }

        /// <summary>
        /// Button thêm mới đối tượng
        /// </summary>
        private void lukExecutionUnit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index.Equals(1))
            { 
            FrmXtraAccountingObjectDetail frmAccountingObjectDetail = new FrmXtraAccountingObjectDetail();
            frmAccountingObjectDetail.ShowDialog();
            if (frmAccountingObjectDetail.CloseBox)
            {
                if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                {
                    _accountingObjectsPresenter.Display();
                    lukExecutionUnit.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                }
            }
            }
        }
        #endregion
    }
}