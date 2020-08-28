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
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetKindItem
{
    /// <summary>
    /// FrmBudgetKindItemDetail
    /// </summary>
    public partial class FrmBudgetKindItemDetail : FrmXtraBaseTreeDetail, IBudgetKindItemView, IBudgetKindItemsView
    {
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BudgetKindItemPresenter _budgetKindItemPresenter;
        public string CurrentBudgetKindItemCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBudgetKindItemDetail"/> class.
        /// </summary>
        public FrmBudgetKindItemDetail()
        {
            InitializeComponent();
            _budgetKindItemPresenter = new BudgetKindItemPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
        }

        #region IBudgetKindItemView
        /// <summary>
        /// Gets or sets the budget kind item identifier.
        /// </summary>
        /// <value>
        /// The budget kind item identifier.
        /// </value>
        public string BudgetKindItemId { get; set; }

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
                return grdLookUpEditParentId.Text == null
                           ? null
                           : (string)grdLookUpEditParentId.GetColumnValue("BudgetKindItemId");
            }
            set { grdLookUpEditParentId.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        /// The budget kind item code.
        /// </value>
        public string BudgetKindItemCode
        {
            get { return txtBudgetKindItemCode.Text.Trim(); }
            set { txtBudgetKindItemCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the budget kind item.
        /// </summary>
        /// <value>
        /// The name of the budget kind item.
        /// </value>
        public string BudgetKindItemName
        {
            get { return memoBudgetKindItemName.Text.Trim(); }
            set { memoBudgetKindItemName.Text = value; }
        }

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

        #region BudgetKindItems
        /// <summary>
        /// Sets the budget kind items.
        /// </summary>
        /// <value>
        /// The budget kind items.
        /// </value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                grdLookUpEditParentId.Properties.DataSource = value;
                grdLookUpEditParentId.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetKindItemId", ColumnVisible = false},
                        new XtraColumn{ColumnName = "BudgetKindItemCode",ColumnCaption = "Mã Loại Khoản",ColumnPosition = 1,ColumnVisible = true,ColumnWith = 100},
                        new XtraColumn{ColumnName = "BudgetKindItemName",ColumnCaption = "Tên Loại Khoản",ColumnPosition = 2,ColumnVisible = true,ColumnWith = 300},
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
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
                grdLookUpEditParentId.Properties.DisplayMember = "BudgetKindItemCode";
                grdLookUpEditParentId.Properties.ValueMember = "BudgetKindItemId";
            }
        }
        #endregion

        #region Form Event
        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _budgetKindItemsPresenter.Display();
            
            if (KeyValue != null)
            {
                _budgetKindItemPresenter.Display(KeyValue);
                CurrentBudgetKindItemCode = BudgetKindItemCode;
            }
            else
            {
                if (CurrentNode != null)
                {
                    txtBudgetKindItemCode.Text = ((BudgetKindItemModel)CurrentNode).BudgetKindItemCode;
                    grdLookUpEditParentId.EditValue = ((BudgetKindItemModel)CurrentNode).BudgetKindItemId;
                }
            }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtBudgetKindItemCode.Focus();
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            var result = _budgetKindItemPresenter.Save();
            if (!string.IsNullOrEmpty(result))
                GlobalVariable.BudgetKindItemIDAutoBusinessForm = result;
            return result;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(BudgetKindItemCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyBudgetKindItemCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetKindItemCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BudgetKindItemName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyBudgetKindItemName"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                memoBudgetKindItemName.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region ControlEvent
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

        private void grdLookUpEditParentId_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBudgetKindItem = new FrmBudgetKindItemDetail();
                frmBudgetKindItem.ShowDialog();
                if (frmBudgetKindItem.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetKindItemIDAutoBusinessForm))
                    {
                        _budgetKindItemsPresenter.Display();
                        grdLookUpEditParentId.EditValue = GlobalVariable.BudgetKindItemIDAutoBusinessForm;
                    }
                }
            }
        }
        #endregion

    }
}
