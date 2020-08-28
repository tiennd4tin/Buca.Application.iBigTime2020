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
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetItem
{
    /// <summary>
    /// 
    /// </summary>
    //public class BudgetItemType
    //{
    //    public string BudgetItemTypeName { get; set; }
    //    public  int    BudgetItemTypes { get; set;}

    //}
    public partial class FrmBudgetItems : FrmBaseTreeList, IBudgetItemsView
    {
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private RepositoryItemLookUpEdit _repositoryBudgetItems;

      

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBudgetItems"/> class.
        /// </summary>
        public FrmBudgetItems()
        {
            InitializeComponent();
            _budgetItemsPresenter = new BudgetItemsPresenter(this);

            InitData();

        }

        public void InitData()
        {

            var budgetItemsType = new Dictionary<string, string> { { "0", "Nhóm" }, { "1", "Tiểu Nhóm" }, { "2", "Mục" }, { "3", "Tiểu Mục" } };
            _repositoryBudgetItems = new RepositoryItemLookUpEdit
            {
                DataSource = budgetItemsType,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
        }
        
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                

                treeList.DataSource = value;
                treeList.PopulateColumns();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 30, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemType", ColumnCaption = "Loại", ColumnVisible = true, ColumnPosition = 3, ColumnWith = 30, Alignment = HorzAlignment.Default, RepositoryControl = _repositoryBudgetItems, AllowEdit = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 30, Alignment = HorzAlignment.Default });
            }
        }

        /// <summary>
        /// Loads the data into tree.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _budgetItemsPresenter.Display();
        }

        /// <summary>
        /// Deletes the tree.
        /// </summary>
        protected override void DeleteTree()
        {
            new BudgetItemPresenter(null).Delete(PrimaryKeyValue);
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmBudgetItemDetail();
        }

        /// <summary>
        /// Shows the error delete parent.
        /// </summary>
        protected override void ShowErrorDeleteParent()
        {
            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteBudgetItemHasChild"),
                ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region private helper


        #endregion
    }
}
