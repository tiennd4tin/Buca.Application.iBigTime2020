
using System.Collections;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using BuCA.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountCategory
{
    /// <summary>
    /// Class FrmAccountingCategories.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseList" />
    public partial class FrmAccountingCategories : FrmBaseList, IAccountCategoriesView
    {
        private readonly AccountCategoriesPresenter _accountCategoriesPresenter;
        private RepositoryItemLookUpEdit _repositoryAccountCategoryKind;

        #region event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAccountingCategories"/> class.
        /// </summary>
        public FrmAccountingCategories()
        {
            InitializeComponent();
            InitRepositoryControlData();
            _accountCategoriesPresenter = new AccountCategoriesPresenter(this);
        }

        #endregion

        #region properties

        public IList<AccountCategoryModel> AccountCategories
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountCategoryId", ColumnCaption = "Mã nhóm TK", ColumnVisible = true, ColumnWith = 20, Alignment = HorzAlignment.Near
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountCategoryName", ColumnCaption = "Tên nhóm TK", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountCategoryKind",
                    ColumnCaption = "Tính chất",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 40,
                    RepositoryControl = _repositoryAccountCategoryKind
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 20 });
            }
        }

        #endregion

        #region override methods

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _accountCategoriesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new AccountCategoryPresenter(null).Delete(PrimaryKeyValue);
        }

        #endregion

        #region private helper

        private void InitRepositoryControlData()
        {
            var accountKind = typeof(AccountKind).ToList();
            _repositoryAccountCategoryKind = new RepositoryItemLookUpEdit
            {
                DataSource = accountKind,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryAccountCategoryKind.PopulateColumns();
            _repositoryAccountCategoryKind.Columns["Key"].Visible = false;
        }

        #endregion
    }
}
