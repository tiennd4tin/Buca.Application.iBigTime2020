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
using System.Drawing;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSourceCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetSource
{
    /// <summary>
    /// Class UserControlBudgetSourceList.
    /// </summary>
    public partial class FrmBudgetSources : FrmBaseTreeList, IBudgetSourcesView, IBudgetSourceCategoriesView
    {
        /// <summary>
        /// The _budgetSources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSourceCategory;
        private GridView _gridLookUpEditBudgetSourceCategoryView;
        private readonly BudgetSourceCategoriesPresenter _budgetSourceCategoriesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBudgetSources" /> class.
        /// </summary>
        public FrmBudgetSources()
        {
            InitializeComponent();
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetSourceCategoriesPresenter = new BudgetSourceCategoriesPresenter(this);
        }

        #region IBudgetSourcesView Members

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                treeList.DataSource = value;
                for (int i = 0; i < value.Count; i++)
                {
                    value[i].BudgetCode = value[i].BudgetSourceProperty == 0 ? "Nguồn vốn trong nước" : "Nguồn vốn ngoài nước";
                }
                treeList.PopulateColumns();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn vốn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnCaption = "Loại nguồn vốn", ColumnVisible = false, ColumnPosition = 5, ColumnWith = 80, Alignment = HorzAlignment.Center, RepositoryControl = _gridLookUpEditBudgetSourceCategory });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnCaption = "Loại nguồn vốn", ColumnVisible = true, ColumnPosition = 5, ColumnWith = 80, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnVisible = true, ColumnPosition = 6, ColumnWith = 80, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSavingExpenses", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceProperty", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccountId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PayableBankAccountId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TargetName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSelfControl", ColumnVisible = false });
                //ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceType", ColumnVisible = false });
            }
        }

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
                try
                {
                    //RepositoryItemGridLookUpEdit VoucherType
                    _gridLookUpEditBudgetSourceCategoryView = new GridView();
                    _gridLookUpEditBudgetSourceCategoryView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSourceCategory = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSourceCategoryView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowFooter = false
                    };
                    _gridLookUpEditBudgetSourceCategory.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSourceCategory.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSourceCategory.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
                    _gridLookUpEditBudgetSourceCategory.View.OptionsView.ShowColumnHeaders = false;
                    _gridLookUpEditBudgetSourceCategory.View.BestFitColumns();
                    
                    _gridLookUpEditBudgetSourceCategory.DataSource = value;
                    _gridLookUpEditBudgetSourceCategoryView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceCategoryCode", ColumnCaption = "Mã loại nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "BudgetSourceCategoryName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSourceCategoryView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetSourceCategoryView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetSourceCategoryView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetSourceCategoryView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetSourceCategory.DisplayMember = "BudgetSourceCategoryName";
                    _gridLookUpEditBudgetSourceCategory.ValueMember = "BudgetSourceCategoryId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Form Event
        /// <summary>
        /// Loads the data into tree.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _budgetSourceCategoriesPresenter.Display();
            _budgetSourcesPresenter.Display();
        }

        /// <summary>
        /// Deletes the tree.
        /// </summary>
        protected override void DeleteTree()
        {
            new BudgetSourcePresenter(null).Delete(PrimaryKeyValue);
        }

        /// <summary>
        /// Shows the error delete parent.
        /// </summary>
        protected override void ShowErrorDeleteParent()
        {
            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteBudgetSourceHasChild"),
                ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmBudgetSourceDetail();
        }
        #endregion
    }
}
