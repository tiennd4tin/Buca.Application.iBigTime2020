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
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetKindItem
{
    /// <summary>
    /// FrmBudgetKindItems
    /// </summary>
    public partial class FrmBudgetKindItems : FrmBaseTreeList, IBudgetKindItemsView
    {
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBudgetKindItems"/> class.
        /// </summary>
        public FrmBudgetKindItems()
        {
            InitializeComponent();
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
        }

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
                treeList.DataSource = value;
                treeList.PopulateColumns();

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnCaption = "Mã Loại khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemName", ColumnCaption = "Tên Loại khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 250, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = true, ColumnCaption = "Được sử dụng", ColumnPosition = 2, ColumnWith = 50, Alignment = HorzAlignment.Default });
            }
        }

        /// <summary>
        /// Loads the data into tree.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _budgetKindItemsPresenter.Display();
            treeList.ExpandAll();
        }

        /// <summary>
        /// Deletes the tree.
        /// </summary>
        protected override void DeleteTree()
        {
            new BudgetKindItemPresenter(null).Delete(PrimaryKeyValue);
        }

        /// <summary>
        /// Shows the error delete parent.
        /// </summary>
        protected override void ShowErrorDeleteParent()
        {
            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteBudgetKindItemHasChild"),
                ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //#endregion

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmBudgetKindItemDetail();
        }

        #region private helper


        #endregion
    }
}
