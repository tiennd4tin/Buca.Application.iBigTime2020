/***********************************************************************
 * <copyright file="FrmProjectDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, October 27, 2017lkuBankAccount
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, October 27, 2017Author SonTV  Description 
 * 
  ***********************************************************************/


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
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Department;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Reflection;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using DevExpress.Data;
using System.ComponentModel;
using DevExpress.XtraBars;
using System.Linq;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project
{

    /// <summary>
    /// FrmXtraAccountingObjectDetail class
    /// </summary>
    internal partial class FrmProjectDetail : FrmXtraBaseTreeDetail, IProjectView, IProjectsView
    //, IAccountingObjectView, IBanksView, IAccountingObjectCategoriesView
    {

        /// <summary>
        /// The _accounting object presenter
        /// </summary>
        private readonly AccountingObjectPresenter _accountingObjectPresenter;
        private readonly AccountingObjectCategoriesPresenter _accountingObjectCategoriesPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly ProjectPresenter _projectPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        /// <summary>
        /// The _banks presenter
        /// </summary>
        // private readonly BanksPresenter _banksPresenter;
        public bool EditBank { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraAccountingObjectDetail"/> class.
        /// </summary>
        public FrmProjectDetail()
        {
            InitializeComponent();
            _projectPresenter = new ProjectPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            //_banksPresenter = new BanksPresenter(this);
            this.Load += new System.EventHandler(this.FrmXtraRegister_Load);
            //_accountingObjectsPresenter = new AccountingObjectsPresenter(this);
        }
        private void FrmXtraRegister_Load(object sender, EventArgs e)
        {

            // lấy text của chủ đầu tư theo license

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
                return calcTotalAmountApproved.EditValue == null ? 0 : (decimal)calcTotalAmountApproved.EditValue;
            }
            set
            {
                calcTotalAmountApproved.EditValue = value;
            }
        }

        public string ParentID
        {
            get { return lkUpTargetProgram.EditValue == null ? "" : (lkUpTargetProgram.EditValue).ToString(); }
            set
            {
                if (!string.IsNullOrEmpty(ProjectId))
                {
                    lkUpTargetProgram.EditValue = value;
                }
            }
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
            get; set;
        }

        public string ContractorName
        {
            get; set;
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
                return txtBuildLacation.Text.Trim();
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
            //get
            //{// return lkuBankAccount.EditValue == null ? "" : (lkuBankAccount.EditValue).ToString();
            //    if (lkuBankAccount.EditValue == null) return null;
            //    return lkuBankAccount.GetColumnValue(KeyFieldName).ToString();
            //}
            //set { lkuBankAccount.EditValue = value; }

            get
            {
                return lkuBankAccount.EditValue == null ? "" : (lkuBankAccount.EditValue).ToString();
            }
            set
            {
                lkuBankAccount.EditValue = value;
            }
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
                if (string.IsNullOrEmpty(value))
                    txtInvest.Text = !GlobalVariable.IsValidLicense ? "" : GlobalVariable.CompanyName;

            }
        }

        public IList<BankModel> ProjectBanks
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
                           new XtraColumn{ColumnName = "Used", ColumnVisible = false, AllowEdit = true},
                 new XtraColumn{ColumnName = "BankId", ColumnVisible = false, AllowEdit = true},
                  new XtraColumn{ColumnName = "BankAddress", ColumnVisible = false, AllowEdit = true},
                   new XtraColumn{ColumnName = "BudgetCode", ColumnVisible = false, AllowEdit = true},
                    new XtraColumn{ColumnName = "Description", ColumnVisible = false, AllowEdit = true},
                     new XtraColumn{ColumnName = "IsActive", ColumnVisible = false, AllowEdit = true},
                       new XtraColumn{ColumnName = "IsOpenInBank", ColumnVisible = false, AllowEdit = true},
                            new XtraColumn{ColumnName = "SortBank", ColumnVisible = false, AllowEdit = true},
                new XtraColumn
                {
                    ColumnName = "BankAccount",
                    ColumnVisible = true,
                    ColumnWith = 320,
                    ColumnCaption = "Số tài khoản",
                    ColumnPosition = 1,
                    AllowEdit = true
                },

                new XtraColumn
                {
                    ColumnName = "BankName",
                    ColumnVisible = true,
                    ColumnWith = 315,
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

        public IList<ProjectModel> Projects
        {
            set
            {
                lkUpTargetProgram.Properties.DataSource = value.Where(p => p.ProjectId != ProjectId && p.IsActive == true).ToList();
                lkUpTargetProgram.Properties.PopulateColumns();
                var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "ProjectCode",
                            ColumnCaption = "Mã Dự án",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 120
                        },
                        new XtraColumn
                        {
                            ColumnName = "ProjectName",
                            ColumnCaption = "Tên Dự án",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 330
                        },
                        new XtraColumn {ColumnName = "ProjectNumber", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "ProjectEnglishName",
                            ColumnVisible = false
                        },
                           new XtraColumn {ColumnName = "ProjectBanks", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BUCACodeID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "StartDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FinishDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ExecutionUnit", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DepartmentID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TotalAmountApproved", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ParentID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "IsDetailbyActivityAndExpense",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                         new XtraColumn {ColumnName = "ObjectType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ObjectTypeName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ContractorID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ContractorName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ContractorAddress", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectSize", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BuildLocation", ColumnVisible = false},
                        new XtraColumn {ColumnName = "InvestmentClass", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CDCActivityType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Investment", ColumnVisible = false}
                    };
                foreach (var column in gridColumnsCollection)
                    if (column.ColumnVisible)
                    {
                        //_gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        //_gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        //_gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                        lkUpTargetProgram.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lkUpTargetProgram.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        // _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                        lkUpTargetProgram.Properties.Columns[column.ColumnName].Visible = false;
                    }
                //_gridLookUpEditProject.DisplayMember = "ProjectCode";
                //_gridLookUpEditProject.ValueMember = "ProjectId";
                lkUpTargetProgram.Properties.DisplayMember = "ProjectCode";
                lkUpTargetProgram.Properties.ValueMember = "ProjectId";

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
        #endregion
        private void grdAccountingView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                //var view = (GridView)sender;
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
        //private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    (grdBank.DataSource as BindingList<BankModel>).AddNew();
        //}
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
            _projectPresenter.DisplayProject(KeyValue);
            //_accountingObjectsPresenter.DisplayByIsCustomerVendor(true);
            _projectsPresenter.DisplayByObjectType("2");
            if (KeyValue != null)
            {
                _projectPresenter.Display(KeyValue);
                //if (lkUpTargetProgram.GetColumnValue("ProjectId") != null)
                //    txtTargetProjectName.EditValue = lkUpTargetProgram.GetColumnValue("ProjectName").ToString();
                //else
                //    txtTargetProjectName.EditValue = "";
                //txtxBankName.EditValue = lkuBankAccount.GetColumnValue("BankName") == null ? "" : lkuBankAccount.GetColumnValue("BankName").ToString();
            }
            else
            {
                dateStartDate.EditValue = DateTime.Now;
                //if (CurrentNode != null)
                //{
                //    lkUpTargetProgram.EditValue = ((ProjectModel)CurrentNode).ProjectId;
                //    txtTargetProjectName.Text = ((ProjectModel)CurrentNode).ProjectName;
                //}
            }
            this.EditBank = false;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {

            ObjectType = 2;
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
            if (string.IsNullOrEmpty(Investment))
            {
                XtraMessageBox.Show("Bạn chưa nhập chủ đầu tư",
                               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvest.Focus();
                return false;
            }
            if (StartDate == null || StartDate == DateTime.MinValue)
            {
                XtraMessageBox.Show("Bạn chưa nhập ngày bắt đầu",
                               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateStartDate.Focus();
                return false;
            }
            if (FinishDate == null || FinishDate == DateTime.MinValue)
            {
                XtraMessageBox.Show("Bạn chưa nhập ngày kết thúc",
                               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateFinishDate.Focus();
                return false;
            }
            if (StartDate?.Date >= FinishDate?.Date)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDateCompare"),
                               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateStartDate.Focus();
                return false;
            }

            return true;
        }
        protected virtual void DeleteRowItem()
        {
            grdBankView.DeleteSelectedRows();
            this.EditBank = true;
            DeleteRowItemInBandedGridView();
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
                    this.EditBank = true;
                    var used = (bool)view.GetRowCellValue(hitInfo.RowHandle, "Used");
                    var bankAccount = view.GetRowCellValue(hitInfo.RowHandle, "BankAccount").ToString();
                    if (used)
                    {
                        XtraMessageBox.Show(
                                "Bạn không thể xóa: " + bankAccount + "vì đã phát sinh trong chứng từ hoặc danh mục liên quan!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        view.DeleteRow(hitInfo.RowHandle);
                    }

                }
            }

        }
        protected virtual void DeleteRowItemInBandedGridView()
        {
        }
        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            var result = _projectPresenter.Save();
            if (!String.IsNullOrEmpty(result))
                GlobalVariable.ProjectIDAccountingObjectDetailForm = result;
            return result;
        }
        #endregion

        #region Event

        private void cbIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Handles the EditValueChanged event of the lkUpTargetProgram control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lkUpTargetProgram_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit textEditor = (TextEdit)sender;
            if (!string.IsNullOrEmpty(textEditor.Text))
                txtTargetProjectName.EditValue = lkUpTargetProgram.GetColumnValue("ProjectName").ToString();
            else
                txtTargetProjectName.EditValue = "";
        }

        private void lkuBankAccount_EditValueChanged_1(object sender, EventArgs e)
        {
            if (lkuBankAccount.GetColumnValue("BankName") != null)
                txtxBankName.EditValue = lkuBankAccount.GetColumnValue("BankName").ToString();
            else
                txtxBankName.EditValue = "";
        }

        private void lkUpTargetProgram_KeyDown(object sender, KeyEventArgs e)
        {
            if (lkUpTargetProgram.SelectionLength == lkUpTargetProgram.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                lkUpTargetProgram.EditValue = null;
                e.Handled = true;
            }
        }
        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                this.grdBankView.DeleteRow(this.grdBankView.FocusedRowHandle);
            }
        }
        private void lkUpTargetProgram_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                lkUpTargetProgram.EditValue = null;
                txtTargetProjectName.EditValue = null;
            }
        }

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
                        // _banksPresenter.DisplayActive(true);
                        lkuBankAccount.EditValue = GlobalVariable.BankIDProjectDetailForm;
                    }
                }
            }
        }
        #endregion

        private void groupboxMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbCode_Click(object sender, EventArgs e)
        {

        }

        private void txtInvest_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnEstimateDetail_Click(object sender, EventArgs e)
        {

        }

        private void lukExecutionUnit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl9_Click(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void txtxBankName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTargetProjectName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl17_Click(object sender, EventArgs e)
        {

        }

        private void calcTotalAmountApproved_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtProjectSize_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lkuBankAccount_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void labelControl18_Click(object sender, EventArgs e)
        {

        }

        private void txtBuildLacation_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void labelControl15_Click(object sender, EventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl14_Click(object sender, EventArgs e)
        {

        }

        private void txtInvestmentClass_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtProjectNumber_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void grdBankView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

            this.EditBank = true;
        }
    }
}