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

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSourceCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetSource
{
    /// <summary>
    /// FrmBudgetSourceDetail
    /// </summary>
    public partial class FrmBudgetSourceDetail : FrmXtraBaseTreeDetail, IBudgetSourceView, IBudgetSourcesView, IBudgetSourceCategoriesView
    {
        private readonly BudgetSourcePresenter _budgetSourcePresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly BudgetSourceCategoriesPresenter _budgetSourceCategoriesPresenter;
        private readonly BanksPresenter _banksPresenter;
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBudgetSourceDetail"/> class.
        /// </summary>
        public FrmBudgetSourceDetail()
        {
            InitializeComponent();
            _budgetSourcePresenter = new BudgetSourcePresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetSourceCategoriesPresenter = new BudgetSourceCategoriesPresenter(this);
            //_banksPresenter = new BanksPresenter(this);
            //_projectsPresenter = new ProjectsPresenter(this);
        }

        #region IBudgetSourceView

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        /// The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode
        {
            get { return txtBudgetSourceCode.Text.Trim(); }
            set { txtBudgetSourceCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the budget source.
        /// </summary>
        /// <value>
        /// The name of the budget source.
        /// </value>
        public string BudgetSourceName
        {
            get { return txtBudgetSourceName.Text.Trim(); }
            set { txtBudgetSourceName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public string ParentId
        {
            get
            {
                return gridLookUpEditParentId.EditValue == null
                           ? null
                           : (string)gridLookUpEditParentId.GetColumnValue("BudgetSourceId");
            }
            set { gridLookUpEditParentId.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is parent].
        /// Gets or sets a value indicating whether [is parent].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is parent]; otherwise, <c>false</c>.
        /// </value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is saving expenses].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is saving expenses]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSavingExpenses { get; set; }

        /// <summary>
        /// Gets or sets the budget source category identifier.
        /// </summary>
        /// <value>
        /// The budget source category identifier.
        /// </value>
        public string BudgetSourceCategoryId
        {
            get { return string.IsNullOrEmpty(gridLookUpEditBudgetSourceCategoryId.Text) ? null : (string)gridLookUpEditBudgetSourceCategoryId.GetColumnValue("BudgetSourceCategoryId"); }
            set { gridLookUpEditBudgetSourceCategoryId.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget source property.
        /// </summary>
        /// <value>
        /// The budget source property.
        /// </value>
        public int BudgetSourceProperty
        {
            get { return cboBudgetSourceProperty.SelectedIndex; }
            set { cboBudgetSourceProperty.SelectedIndex = value; }
        }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>
        /// The bank account.
        /// </value>
        public string BankAccountId
        {
            //get { return string.IsNullOrEmpty(gridLookUpEditBankAccount.Text) ? null : (string)gridLookUpEditBankAccount.GetColumnValue("BankId"); }
            //set { gridLookUpEditBankAccount.EditValue = value; }
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets or sets the payable bank account.
        /// </summary>
        /// <value>
        /// The payable bank account.
        /// </value>
        public string PayableBankAccountId
        {
            //get { return string.IsNullOrEmpty(gridLookUpEditPayableBankAccount.Text) ? null : (string)gridLookUpEditPayableBankAccount.GetColumnValue("BankId"); }
            //set { gridLookUpEditPayableBankAccount.EditValue = value; }
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets or sets the target code.
        /// </summary>
        /// <value>
        /// The target code.
        /// </value>
        public string ProjectId
        {
            //get { return string.IsNullOrEmpty(gridLookUpEditTargetCode.Text) ? null : (string)gridLookUpEditTargetCode.GetColumnValue("ProjectId"); }
            //set { gridLookUpEditTargetCode.EditValue = value; }
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is self control].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is self control]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelfControl { get; set; }

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
        /// Set or get BudgetCode
        /// </summary>
        public string BudgetCode
        {
            get { return txtBudgetCode.Text.Trim(); }
            set
            {
                if (value != null)
                    txtBudgetCode.Text = value.Trim();
            }
        }

        /// <summary>
        /// Gets or sets the type of the budget source.
        /// </summary>
        /// <value>
        /// The type of the budget source.
        /// </value>
        public short BudgetSourceType
        {
            get
            {
                int budgetSourceType;
                if (radioGroup1.SelectedIndex == 0)
                    budgetSourceType = 0;
                else if (radioGroup2.SelectedIndex == 0)
                    budgetSourceType = 1;
                else if (radioGroup3.SelectedIndex == 0)
                    budgetSourceType = 2;
                else
                    budgetSourceType = -1;
                return (short)budgetSourceType;
            }
            set
            {
                if (value == 0)
                    radioGroup1.SelectedIndex = 0;
                else if (value == 1)
                    radioGroup2.SelectedIndex = 0;
                else if (value == 2)
                    radioGroup3.SelectedIndex = 0;
                else
                    radioGroup1.SelectedIndex = -1;
            }
        }

        #endregion

        #region IBudgetSourceCategoriesView
        /// <summary>
        /// Sets the budget source categories.
        /// </summary>
        /// <value>
        /// The budget source categories.
        /// </value>
        public IList<BudgetSourceCategoryModel> BudgetSourceCategories
        {
            set
            {
                gridLookUpEditBudgetSourceCategoryId.Properties.DataSource = value;
                gridLookUpEditBudgetSourceCategoryId.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceCategoryCode", ColumnCaption = "Mã loại", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "BudgetSourceCategoryName", ColumnCaption = "Tên loại", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridLookUpEditBudgetSourceCategoryId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridLookUpEditBudgetSourceCategoryId.Properties.SortColumnIndex = column.ColumnPosition;
                        gridLookUpEditBudgetSourceCategoryId.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        gridLookUpEditBudgetSourceCategoryId.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                gridLookUpEditBudgetSourceCategoryId.Properties.DisplayMember = "BudgetSourceCategoryName";
                gridLookUpEditBudgetSourceCategoryId.Properties.ValueMember = "BudgetSourceCategoryId";
            }
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>
        /// The budget sources.
        /// </value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                gridLookUpEditParentId.Properties.DataSource = value;
                gridLookUpEditParentId.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn vốn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 },
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSavingExpenses", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceProperty", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BankAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "PayableBankAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSelfControl", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceType", ColumnVisible = false }
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridLookUpEditParentId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridLookUpEditParentId.Properties.SortColumnIndex = column.ColumnPosition;
                        gridLookUpEditParentId.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        gridLookUpEditParentId.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                gridLookUpEditParentId.Properties.DisplayMember = "BudgetSourceName";
                gridLookUpEditParentId.Properties.ValueMember = KeyFieldName;
            }
        }
        
        #endregion

        #region Form Event
        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _budgetSourceCategoriesPresenter.DisplayActive();
            //_banksPresenter.DisplayActive(true);
            //_projectsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();

            if (KeyValue != null)
            {
                _budgetSourcePresenter.Display(KeyValue);
            }
            else
            {
                if (CurrentNode != null)
                {
                    txtBudgetSourceCode.Text = ((BudgetSourceModel)CurrentNode).BudgetSourceCode;
                    gridLookUpEditParentId.EditValue = ((BudgetSourceModel)CurrentNode).BudgetSourceId;
                    gridLookUpEditBudgetSourceCategoryId.EditValue = ((BudgetSourceModel)CurrentNode).BudgetSourceCategoryId;
                    cboBudgetSourceProperty.SelectedIndex = ((BudgetSourceModel)CurrentNode).BudgetSourceProperty;
                }
            }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtBudgetSourceCode.Focus();
            cboBudgetSourceProperty.SelectedItem = 1;
            radioGroup1.SelectedIndex = 0;
            radioGroup2.SelectedIndex = -1;
            radioGroup3.SelectedIndex = -1;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            var result = _budgetSourcePresenter.Save();
            if (!string.IsNullOrEmpty(result))
                GlobalVariable.BudgetSourceIDAccountTransferForm = result;
            return result;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(BudgetSourceCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSourceCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetSourceCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BudgetSourceName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSourceName"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetSourceName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BudgetSourceCategoryId))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyBudgetSourceCategoryID"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridLookUpEditBudgetSourceCategoryId.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ControlEvent

        /// <summary>
        /// Handles the KeyDown event of the gridLookUpEditParentId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void gridLookUpEditParentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridLookUpEditParentId.SelectionLength == gridLookUpEditParentId.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                gridLookUpEditParentId.EditValue = null;
                e.Handled = true;
            }
        }


        /// <summary>
        /// Handles the KeyDown event of the gridLookUpEditBudgetSourceCategoryId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void gridLookUpEditBudgetSourceCategoryId_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridLookUpEditBudgetSourceCategoryId.SelectionLength == gridLookUpEditBudgetSourceCategoryId.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                gridLookUpEditBudgetSourceCategoryId.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the radioGroup1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void radioGroup1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                radioGroup2.SelectedIndex = -1;
                radioGroup3.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the radioGroup2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void radioGroup2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (radioGroup2.SelectedIndex == 0)
            {
                radioGroup1.SelectedIndex = -1;
                radioGroup3.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the radioGroup3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void radioGroup3_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (radioGroup3.SelectedIndex == 0)
            {
                radioGroup1.SelectedIndex = -1;
                radioGroup2.SelectedIndex = -1;
            }
        }

        private void gridLookUpEditParentId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBudgetSource = new FrmBudgetSourceDetail();
                frmBudgetSource.ShowDialog();
                if (frmBudgetSource.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetSourceIDAccountTransferForm))
                    {
                        _budgetSourcesPresenter.DisplayActive();
                        gridLookUpEditParentId.EditValue = GlobalVariable.BudgetSourceIDAccountTransferForm;
                    }
                }
            }
        }
        #endregion

    }
}
