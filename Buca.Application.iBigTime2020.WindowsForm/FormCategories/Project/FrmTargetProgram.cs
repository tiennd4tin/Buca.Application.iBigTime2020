/***********************************************************************
 * <copyright file="FrmTargetProgram.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, October 27, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, October 27, 2017Author SonTV  Description 
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
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Department;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project
{

    /// <summary>
    /// FrmXtraAccountingObjectDetail class
    /// </summary>
    internal partial class FrmTargetProgram : FrmXtraBaseTreeDetail, IProjectView, IProjectsView
    //, IAccountingObjectView, IBanksView, IAccountingObjectCategoriesView
    {

        /// <summary>
        /// The _accounting object presenter
        /// </summary>
        private readonly AccountingObjectPresenter _accountingObjectPresenter;
        /// <summary>
        /// The accounting object categories presenter{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly AccountingObjectCategoriesPresenter _accountingObjectCategoriesPresenter;
        /// <summary>
        /// The project presenter{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly ProjectPresenter _projectPresenter;
        /// <summary>
        /// The projects presenter{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;
        /// <summary>
        /// The _banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;
        public bool EditBank { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraAccountingObjectDetail" /> class.
        /// </summary>
        public FrmTargetProgram()
        {
            InitializeComponent();
            _projectPresenter = new ProjectPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
        }


        #region Implement

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>The project identifier.</value>
        public string ProjectId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the project code.
        /// </summary>
        /// <value>The project code.</value>
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
        /// <summary>
        /// Gets or sets the project number.
        /// </summary>
        /// <value>The project number.</value>
        public string ProjectNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        /// <value>The name of the project.</value>
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

        /// <summary>
        /// Gets or sets the name of the project english.
        /// </summary>
        /// <value>The name of the project english.</value>
        public string ProjectEnglishName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the buca code identifier.
        /// </summary>
        /// <value>The buca code identifier.</value>
        public string BUCACodeID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime? StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the finish date.
        /// </summary>
        /// <value>The finish date.</value>
        public DateTime? FinishDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the execution unit.
        /// </summary>
        /// <value>The execution unit.</value>
        public string ExecutionUnit
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        public string DepartmentID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total amount approved.
        /// </summary>
        /// <value>The total amount approved.</value>
        public decimal TotalAmountApproved
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public string ParentID
        {
            get { return lukTargetProgram.EditValue == null ? "" : (lukTargetProgram.EditValue).ToString(); }
            set { lukTargetProgram.EditValue = value.Trim(); }
        }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the is parent.
        /// </summary>
        /// <value>The is parent.</value>
        public bool IsParent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the is detailby activity and expense.
        /// </summary>
        /// <value>The is detailby activity and expense.</value>
        public bool IsDetailbyActivityAndExpense
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the is system.
        /// </summary>
        /// <value>The is system.</value>
        public bool IsSystem
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>The is active.</value>
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

        /// <summary>
        /// Gets or sets the type of the object.
        /// </summary>
        /// <value>The type of the object.</value>
        public int? ObjectType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the contractor identifier.
        /// </summary>
        /// <value>The contractor identifier.</value>
        public string ContractorID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the contractor.
        /// </summary>
        /// <value>The name of the contractor.</value>
        public string ContractorName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the contractor address.
        /// </summary>
        /// <value>The contractor address.</value>
        public string ContractorAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the size of the project.
        /// </summary>
        /// <value>The size of the project.</value>
        public string ProjectSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the build location.
        /// </summary>
        /// <value>The build location.</value>
        public string BuildLocation
        {
            get;

            set;
        }

        /// <summary>
        /// Gets or sets the investment class.
        /// </summary>
        /// <value>The investment class.</value>
        public string InvestmentClass
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the CDC activity.
        /// </summary>
        /// <value>The type of the CDC activity.</value>
        public int? CDCActivityType
        {
            get;
            set;
        }

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public IList<ProjectModel> Projects
        {
            set
            {
                lukTargetProgram.Properties.DataSource = value;
                lukTargetProgram.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ProjectName", ColumnCaption = "Tên CTMT", ColumnPosition = 1, ColumnVisible = true },
                                                new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã CTMT", ColumnPosition = 1, ColumnVisible = true },

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
                                                 new XtraColumn { ColumnName = "ProjectBanks", ColumnVisible = false },
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lukTargetProgram.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lukTargetProgram.Properties.SortColumnIndex = column.ColumnPosition;
                        lukTargetProgram.Properties.PopupWidth = 500;
                        lukTargetProgram.Properties.Columns[2].Width = 300;
                        lukTargetProgram.Properties.Columns[1].Width = 300;
                    }
                    else lukTargetProgram.Properties.Columns[column.ColumnName].Visible = false;
                }
                lukTargetProgram.Properties.ValueMember = "ProjectId";
                lukTargetProgram.Properties.DisplayMember = "ProjectName";
            }
        }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the investment.
        /// </summary>
        /// <value>The investment.</value>
        public string Investment
        {
            get;

            set;
        }
        public IList<BankModel> ProjectBanks { get; set; }
        #endregion

        #region override

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            groupboxMain.Text = ResourceHelper.GetResourceValueByName("ResCommonCaption");
            base.InitControls();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
            {
                _projectPresenter.Display(KeyValue);

            }
            else
            {
                if (CurrentNode != null)
                {
                    var projectId = ((ProjectModel)CurrentNode).ProjectId;
                    lukTargetProgram.EditValue = projectId;
                    //var projectName = ((ProjectModel)CurrentNode).ProjectName.Trim();
                    //lukTargetProgram.Text = projectName;
                }
            }
            _projectsPresenter.DisplayByObjectType("1");

        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns>System.Boolean.</returns>
        protected override bool ValidData()
        {
            ObjectType = 1;
            if (string.IsNullOrEmpty(ProjectCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResTargetProgramCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProjectCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(ProjectName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResTargetProgramName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProjectName.Focus();
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
            var result = _projectPresenter.Save();
            if (!String.IsNullOrEmpty(result))
            {
                GlobalVariable.TargetProgramIDTargetProgamForm = result;
            }
            return result;
        }
        #endregion

        #region Event

        /// <summary>
        /// Lbs the tax code click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void lbTaxCode_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Texts the tax code edit value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void txtTaxCode_EditValueChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Cbs the is active checked changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void cbIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lukTargetProgram_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmTargetProgram = new FrmTargetProgram();
                frmTargetProgram.ShowDialog();
                if (frmTargetProgram.CloseBox)
                {

                    if (!String.IsNullOrEmpty(GlobalVariable.TargetProgramIDTargetProgamForm))
                    {
                        _projectsPresenter.DisplayByObjectType("1");
                        lukTargetProgram.EditValue = GlobalVariable.TargetProgramIDTargetProgamForm;
                    }
                }
            }
        }
        #endregion
    }
}