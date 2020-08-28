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
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetItem
{
    /// <summary>
    /// FrmBudgetItemDetail
    /// </summary>
    public partial class FrmBudgetItemDetail : FrmXtraBaseTreeDetail, IBudgetItemView, IBudgetItemsView
    {
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly BudgetItemPresenter _budgetItemPresenter;
        public string CurrentBudgetItemCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBudgetItemDetail"/> class.
        /// </summary>
        public FrmBudgetItemDetail()
        {
            InitializeComponent();
            _budgetItemPresenter = new BudgetItemPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
        }

        #region IBudgetItemView

        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>
        /// The budget item identifier.
        /// </value>
        public string BudgetItemId { get; set; }

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
                if (grdLookUpEditParentId.EditValue == null) return null;
                if (String.IsNullOrEmpty(KeyFieldName)) KeyFieldName = "BudgetItemId";//AnhNT: Set cứng phần này tránh lỗi khi add new Mục tiểu mục từ Form Đối tượng, chỉ có tác dụng với add new trong Form danh mục Đối tượng (vì KeyFieldName sẽ ko ăn theo TablePrimaryKey trên formbase)
                return grdLookUpEditParentId.GetColumnValue(KeyFieldName).ToString();
            }
            set { grdLookUpEditParentId.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the type of the budget item.
        /// </summary>
        /// <value>
        /// The type of the budget item.
        /// </value>
        public int BudgetItemType
        {
            get { return cboBudgetItemType.SelectedIndex; }
            set { cboBudgetItemType.SelectedIndex = value; }
        }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode
        {
            get { return txtBudgetItemCode.Text.Trim(); }
            set { txtBudgetItemCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the budget item.
        /// </summary>
        /// <value>
        /// The name of the budget item.
        /// </value>
        public string BudgetItemName
        {
            get { return txtBudgetItemName.Text.Trim(); }
            set { txtBudgetItemName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the budget group item code.
        /// </summary>
        /// <value>
        /// The budget group item code.
        /// </value>
        public string BudgetGroupItemCode { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is parent].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is parent]; otherwise, <c>false</c>.
        /// </value>
        public bool IsParent { get; set; }

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
        #endregion

        #region IBudgetItemsView

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>
        /// The BudgetItems.
        /// </value>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                grdLookUpEditParentId.Properties.DataSource = value;
                grdLookUpEditParentId.Properties.PopulateColumns();
                
                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                        new XtraColumn{ColumnName = "BudgetItemCode",ColumnCaption = "Mã",ColumnPosition = 1,ColumnVisible = true,ColumnWith = 50},
                        new XtraColumn{ColumnName = "BudgetItemName",ColumnCaption = "Tên",ColumnPosition = 2,ColumnVisible = true,ColumnWith = 300},
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetGroupItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpEditParentId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditParentId.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditParentId.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpEditParentId.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpEditParentId.Properties.DisplayMember = "BudgetItemCode";
                grdLookUpEditParentId.Properties.ValueMember = "BudgetItemId";
            }
        }
        #endregion

        #region Form Event

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _budgetItemsPresenter.DisplayActive(true);
            
            if (KeyValue != null)
            {
                _budgetItemPresenter.Display(KeyValue);
                CurrentBudgetItemCode = BudgetItemCode;
            }
            else
            {
                if (CurrentNode != null)
                {
                    txtBudgetItemCode.Text = ((BudgetItemModel) CurrentNode).BudgetItemCode;
                    grdLookUpEditParentId.EditValue = ((BudgetItemModel) CurrentNode).BudgetItemId;
                    if (((BudgetItemModel) CurrentNode).BudgetItemType < 3 ||
                        ((BudgetItemModel) CurrentNode).BudgetItemType > 0)
                        cboBudgetItemType.SelectedIndex = ((BudgetItemModel) CurrentNode).BudgetItemType + 1;
                    else
                        cboBudgetItemType.SelectedIndex = ((BudgetItemModel) CurrentNode).BudgetItemType;
                }
                else
                {
                    grdLookUpEditParentId.ItemIndex = 0;

                }
            }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtBudgetItemCode.Focus();
            cboBudgetItemType.SelectedIndex = 1;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            var result = _budgetItemPresenter.Save();
            if (!String.IsNullOrEmpty(result))
                GlobalVariable.BudgetItemDetailAccountingObjectDetailForm = result;
            return result;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(BudgetItemCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetItemCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBudgetItemCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BudgetItemName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetItemName"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBudgetItemName.Focus();
                return false;
            }
            return true;
        }
        #endregion 

        #region Control event

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditParentId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditParentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditParentId.SelectionLength == grdLookUpEditParentId.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditParentId.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboBudgetItemType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboBudgetItemType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboBudgetItemType.SelectedIndex == 0)
            {
                lblParentID.Text = @"Thuộc nhóm";
                grdLookUpEditParentId.Enabled = false;
                grdLookUpEditParentId.EditValue = null;
            }
            else if (cboBudgetItemType.SelectedIndex == 1)
            {
                lblParentID.Text = @"Thuộc nhóm";
                grdLookUpEditParentId.Enabled = true;
                _budgetItemsPresenter.Display(0, true);
            }
            else if (cboBudgetItemType.SelectedIndex == 2)
            {
                lblParentID.Text = @"Thuộc TN";
                lblParentID.ToolTip = @"Thuộc tiểu nhóm";
                grdLookUpEditParentId.Enabled = true;
                _budgetItemsPresenter.Display(1, true);
            }
            else
            {
                lblParentID.Text = @"Thuộc mục";
                grdLookUpEditParentId.Enabled = true;
                _budgetItemsPresenter.Display(2, true);
            }
        }

        private void grdLookUpEditParentId_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmBudgetItemDetail frmDetail = new FrmBudgetItemDetail();
                frmDetail.ShowDialog();
                if (frmDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetItemDetailAccountingObjectDetailForm))
                    {
                        _budgetItemsPresenter.Display();
                        grdLookUpEditParentId.EditValue = GlobalVariable.BudgetItemDetailAccountingObjectDetailForm;
                    }
                }
            }
        }
        #endregion
    }
}
