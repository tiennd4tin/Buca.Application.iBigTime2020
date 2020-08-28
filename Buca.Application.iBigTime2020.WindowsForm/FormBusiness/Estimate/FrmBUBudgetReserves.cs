/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    13/12/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    public partial class FrmBUBudgetReserves : FrmBaseVoucherList, IBUBudgetReservesView, IBudgetSourcesView, IBudgetKindItemsView, IBudgetItemsView
    {
        #region Presenter

        private readonly BUBudgetReservesPresenter _buBudgetReservesPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        #endregion 

        #region RepositoryItemLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        private GridView _gridLookUpEditBudgetSubKindItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private GridView _gridLookUpEditBudgetItemView;

        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        private readonly IModel _model;

        #endregion 

        #region Form Event

        public FrmBUBudgetReserves()
        {
            InitializeComponent();
            _buBudgetReservesPresenter = new BUBudgetReservesPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _model = new Model.Model();
        }

        #endregion 

        #region override

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            InitRepositoryControlData();
            _budgetKindItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
           _buBudgetReservesPresenter.Display((int)RefType.BUBudgetReserve);
        }

        /// <summary>
        /// Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {

        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BUBudgetReservePresenter(null).Delete(PrimaryKeyValue);
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(string refId)
        {
            var buPlanReceipt = _model.GetBUBudgetReserveByRefId(refId, true);
            if (buPlanReceipt == null)
                return;
            bindingSourceDetail.DataSource = buPlanReceipt.BUBudgetReserveDetails;
            gridViewDetail.PopulateColumns(buPlanReceipt.BUBudgetReserveDetails);
            var columnsCollection = new List<XtraColumn>
            {
                new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                new XtraColumn 
                {
                    ColumnName = "Description", 
                    ColumnVisible = true,
                    ColumnWith = 320,
                    ColumnCaption = "Chỉ tiêu",
                    ColumnPosition = 1,
                    AllowEdit = true
                },
                new XtraColumn
                {
                    ColumnName = "BudgetSourceId", 
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Nguồn",
                    ColumnPosition = 2,
                    RepositoryControl = _gridLookUpEditBudgetSource,
                    AllowEdit = false
                },
                new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                new XtraColumn
                {
                    ColumnName = "BudgetSubKindItemCode", 
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Khoản",
                    ColumnPosition = 2,
                    RepositoryControl = _gridLookUpEditBudgetSubKindItem,
                    AllowEdit = false
                },
                new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Mục",
                    ColumnPosition = 3,
                    IsSummnary = false,
                    AllowEdit = false,
                    RepositoryControl = _gridLookUpEditBudgetItem,
                    ColumnType = UnboundColumnType.Decimal
                },
                new XtraColumn
                {
                    ColumnName = "AmountOC",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 4,
                    IsSummnary = false,
                    AllowEdit = false,
                    ColumnType = UnboundColumnType.Decimal
                },
                new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Quy đổi",
                    ColumnPosition = 5,
                    IsSummnary = false,
                    AllowEdit = false,
                    ColumnType = UnboundColumnType.Decimal,
                    IsLastColumn = true
                },                
                new XtraColumn {ColumnName = "BudgetSubItemCode"},
                new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                new XtraColumn {ColumnName = "BudgetGroupItemCode", ColumnVisible = false},
                new XtraColumn {ColumnName = "BankAccount", ColumnVisible = false},
                new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false}
            };
            gridViewDetail = InitGridLayout(columnsCollection, gridViewDetail, gridDetail);
            SetNumericFormatControl(gridViewDetail, true);
            gridViewDetail.OptionsView.ShowFooter = false;
        }

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <param name="grid">The grid.</param>
        /// <returns>
        /// GridView.
        /// </returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView, GridControl grid)
        {
            var totalColumnWidth = 0;
            foreach (var column in columnsCollection)
                if (grdView.Columns[column.ColumnName] != null)
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
                        totalColumnWidth += column.ColumnWith;
                        if (column.IsSummaryText)
                        {
                            grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat =
                                Properties.Resources.SummaryText;
                        }
                        if (column.IsLastColumn)
                        {
                            if (grid.Width - totalColumnWidth <= column.ColumnWith)
                                grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                            else
                                grdView.Columns[column.ColumnName].Width = grid.Width - totalColumnWidth + column.ColumnWith;
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
            return grdView;
        }

        #endregion

        #region IView Members

        public IList<BUBudgetReserveModel> BUBudgetReserves
        {
            set
            {
                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày quyết định",
                    Alignment = HorzAlignment.Center,
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 3,
                    ColumnVisible = false,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PostedDate",
                    ColumnCaption = "Ngày quyết định",
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    Alignment = HorzAlignment.Center,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số quyết định",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 80
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Chương",
                    ColumnVisible = false,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "JournalMemo",
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn {ColumnName = "TotalAmountOC", ColumnCaption = "Số tiền nguyên tệ",ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmount",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Posted", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EditVersion", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostVersion", ColumnVisible = false });
                ColumnsCollection.Add(
                    new XtraColumn { ColumnName = "BUBudgetReserveDetails", ColumnVisible = false });
            }
        }

        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                try
                {
                    _gridLookUpEditBudgetSourceView = new GridView();
                    _gridLookUpEditBudgetSourceView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSource = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSourceView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSource.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSource.View.BestFitColumns();

                    _gridLookUpEditBudgetSource.DataSource = value;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceCode",
                        ColumnCaption = "Mã nguồn vốn",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceName",
                        ColumnCaption = "Tên nguồn vốn",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    _gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    _gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                try
                {
                    _budgetSubKindItemModels = value.Where(v => !v.IsParent).ToList();

                    _gridLookUpEditBudgetSubKindItemView = new GridView();
                    _gridLookUpEditBudgetSubKindItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubKindItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubKindItemView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubKindItem.View.BestFitColumns();

                    _gridLookUpEditBudgetSubKindItem.DataSource = _budgetSubKindItemModels;
                    _gridLookUpEditBudgetSubKindItemView.PopulateColumns(_budgetSubKindItemModels);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetKindItemCode",
                        ColumnCaption = "Mã Khoản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetKindItemName",
                        ColumnCaption = "Tên Khoản",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditBudgetSubKindItem.DisplayMember = "BudgetKindItemCode";
                    _gridLookUpEditBudgetSubKindItem.ValueMember = "BudgetKindItemCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                try
                {
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2).ToList();

                    #region BudgetItem
                    _gridLookUpEditBudgetItemView = new GridView();
                    _gridLookUpEditBudgetItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetItem.View.BestFitColumns();

                    _gridLookUpEditBudgetItem.DataSource = budgetItemModels;
                    _gridLookUpEditBudgetItemView.PopulateColumns(budgetItemModels);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnCaption = "Mã Mục",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemName",
                        ColumnCaption = "Tên Mục",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetItem.DisplayMember = "BudgetItemCode";
                    _gridLookUpEditBudgetItem.ValueMember = "BudgetItemCode";
                    #endregion
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion 
    }
}
