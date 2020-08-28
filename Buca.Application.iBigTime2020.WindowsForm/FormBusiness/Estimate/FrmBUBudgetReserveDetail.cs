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
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetChapter;
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
    /// <summary>
    /// FrmBUBudgetReserveDetail
    /// </summary>
    public partial class FrmBUBudgetReserveDetail : FrmXtraBaseVoucherDetail, IBUBudgetReserveView, IBudgetSourcesView, IBudgetKindItemsView, IBudgetItemsView, IBudgetChaptersView
    {
        #region Presenter

        /// <summary>
        /// The _bu budget reserve presenter
        /// </summary>
        private readonly BUBudgetReservePresenter _buBudgetReservePresenter;
        /// <summary>
        /// The _budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        /// <summary>
        /// The _budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        /// <summary>
        /// The _budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        #endregion

        #region RepositoryItemLookUpEdit

        /// <summary>
        /// The _grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        /// <summary>
        /// The _grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        /// The _grid look up edit budget sub kind item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        /// <summary>
        /// The _grid look up edit budget sub kind item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubKindItemView;

        /// <summary>
        /// The _grid look up edit budget item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        /// <summary>
        /// The _grid look up edit budget item view
        /// </summary>
        private GridView _gridLookUpEditBudgetItemView;

        /// <summary>
        /// The _budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        /// <summary>
        /// The _model
        /// </summary>
        private readonly IModel _model;

        #endregion

        #region private helper

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>
        /// GridView.
        /// </returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView, GridControl grid)
        {
            var totalColumnWidth = 0;
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
                    totalColumnWidth += column.ColumnWith;
                    if (column.IsSummaryText)
                    {
                        grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                        grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
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
            }
            return grdView;
        }

        
        #endregion

        #region overrides

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBUBudgetReserveDetail" /> class.
        /// </summary>
        public FrmBUBudgetReserveDetail()
        {
            InitializeComponent();
            _buBudgetReservePresenter = new BUBudgetReservePresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _model = new Model.Model();
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Location = new Point(9, 172);
            tabMain.Location = new Point(8, 229);
            tabMain.SelectedTabPage = tabInventoryItem;
            tabAccounting.TabControl.ShowTabHeader = DefaultBoolean.False;
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _budgetSourcesPresenter.DisplayActive();
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _budgetChaptersPresenter.DisplayByIsActive(true);
            if (MasterBindingSource != null) if (MasterBindingSource.Current != null)
                KeyValue = ((BUBudgetReserveModel)MasterBindingSource.Current).RefId;
            _buBudgetReservePresenter.Display(KeyValue);

            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.BUBudgetReserve;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            var buBudgetReserveDetails = BUBudgetReserveDetails;
            if (buBudgetReserveDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (dtPostDate.EditValue == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBUBudgetReserveDecisionDate"),
                                       ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                lookUpEditBudgetChapterCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtRefNo.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBUBudgetReserveDecisionNo"),
                                       ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                lookUpEditBudgetChapterCode.Focus();
                return false;
            }
            if (BudgetChapterCode == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetChapterCodeRequired"),
                                       ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                lookUpEditBudgetChapterCode.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// LinhMC
        /// Initializes the detail row.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRow(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                view.SetRowCellValue(e.RowHandle, "Amount", 0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Initializes the detail row for acounting detail.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetail(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                //view.SetRowCellValue(e.RowHandle, "DebitAccount", "1111");
                //view.SetRowCellValue(e.RowHandle, "Amount", 0);
                //view.SetRowCellValue(e.RowHandle, "BudgetChapterCode", "423");
                //view.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", "521");
                //view.SetRowCellValue(e.RowHandle, "MethodDistributeId", 0);
                //view.SetRowCellValue(e.RowHandle, "CashWithdrawTypeId", 0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = KeyValue;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = null;
            return _buBudgetReservePresenter.Save();
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new BUBudgetReservePresenter(null).Delete(KeyValue);
        }

        #endregion

        #region IViews IBUBudgetReserveView

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime RefDate
        {
            get { return dtRefDate.EditValue == null ? DateTime.Now : (DateTime)dtRefDate.EditValue; }
            set { dtRefDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate
        {
            get { return dtPostDate.EditValue == null ? DateTime.Now : (DateTime)dtPostDate.EditValue; }
            set { dtPostDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo
        {
            get { return txtRefNo.Text.Trim(); }
            set { txtRefNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode
        {
            get { return lookUpEditBudgetChapterCode.EditValue == null ? null : lookUpEditBudgetChapterCode.EditValue.ToString(); }
            set { lookUpEditBudgetChapterCode.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the budget chapter.
        /// </summary>
        /// <value>
        /// The name of the budget chapter.
        /// </value>
        public string BudgetChapterName { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo
        {
            get { return txtJournalMemo.Text.Trim(); }
            set { txtJournalMemo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode
        {
            get { return gridViewMaster.GetRowCellValue(0, "CurrencyCode") == null ? GlobalVariable.MainCurrencyId : gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString(); }
            set { gridViewMaster.SetRowCellValue(0, "CurrencyCode", value ?? GlobalVariable.MainCurrencyId); }
        }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate
        {
            get
            {
                if (CurrencyCode == GlobalVariable.MainCurrencyId)
                    return 1;
                return (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
            }
            set
            {
                if (CurrencyCode == GlobalVariable.MainCurrencyId)
                    value = 1;
                gridViewMaster.SetRowCellValue(0, "ExchangeRate", value);
            }
        }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount
        {
            get
            {
                return (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmount");
            }
            set
            {
                gridViewMaster.SetRowCellValue(0, "TotalAmount", value);
            }
        }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        /// The total amount oc.
        /// </value>
        public decimal TotalAmountOC
        {
            get
            {
                return (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmountOC");
            }
            set
            {
                gridViewMaster.SetRowCellValue(0, "TotalAmountOC", value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [posted].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [posted]; otherwise, <c>false</c>.
        /// </value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>
        /// The edit version.
        /// </value>
        public int? EditVersion { get; set; }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>
        /// The post version.
        /// </value>
        public int? PostVersion { get; set; }

        /// <summary>
        /// Gets or sets the bu budget reserve details.
        /// </summary>
        /// <value>
        /// The bu budget reserve details.
        /// </value>
        public IList<BUBudgetReserveDetailModel> BUBudgetReserveDetails
        {
            get
            {
                var buBudgetReserveDetails = new List<BUBudgetReserveDetailModel>();
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    decimal totalAmount = 0;
                    decimal totalAmountOC = 0;
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BUBudgetReserveDetailModel)grdAccountingView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var item = new BUBudgetReserveDetailModel
                            {
                                Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                                Amount = rowVoucher.AmountOC * ExchangeRate,
                                AmountOC = rowVoucher.AmountOC,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                SortOrder = i
                            };
                            totalAmount += item.Amount;
                            totalAmountOC += item.AmountOC;
                            buBudgetReserveDetails.Add(item);
                        }
                        TotalAmount = totalAmount;
                        TotalAmountOC = totalAmountOC;
                    }
                }
                return buBudgetReserveDetails;
            }

            set
            {
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BUBudgetReserveDetailModel>();
                grdAccountingView.PopulateColumns(value);

                #region columns for grdAccountingView
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
                    AllowEdit = true
                },
                new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                new XtraColumn
                {
                    ColumnName = "BudgetSubKindItemCode",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Khoản",
                    ColumnPosition = 3,
                    RepositoryControl = _gridLookUpEditBudgetSubKindItem,
                    AllowEdit = true
                },
                new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Mục",
                    ColumnPosition = 4,
                    IsSummnary = false,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditBudgetItem
                },
                new XtraColumn
                {
                    ColumnName = "AmountOC",
                    ColumnVisible = true,
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 5,
                    ColumnWith = 150,
                    IsSummnary = false,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.Decimal
                },
                new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnVisible = true,
                    ColumnCaption = "Quy đổi",
                    ColumnPosition = 6,
                    ColumnWith = 150,
                    IsSummnary = false,
                    AllowEdit = true,
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
                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView, grdAccounting);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;
                #endregion
            }
        }
        #endregion

        #region IViews Member

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
                try
                {
                    _gridLookUpEditBudgetSourceView = new GridView();
                    _gridLookUpEditBudgetSourceView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSource = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSourceView,
                        TextEditStyle = TextEditStyles.Standard,
                        AllowNullInput = DefaultBoolean.True
                    };
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSource.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSource.View.BestFitColumns();
                    _gridLookUpEditBudgetSource.KeyDown += _gridLookUpEditBudgetSourceView_KeyDown;

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
                    //gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceCategoryId",
                        ColumnVisible = false
                    });
                    
                 
                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, value, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                try
                {
                    _budgetSubKindItemModels = value.Where(v => !v.IsParent).ToList();

                    _gridLookUpEditBudgetSubKindItemView = new GridView();
                    _gridLookUpEditBudgetSubKindItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubKindItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubKindItemView,
                        TextEditStyle = TextEditStyles.Standard,
                        AllowNullInput = DefaultBoolean.True
                    };
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItem.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSubKindItem.KeyDown += _gridLookUpEditBudgetSubKindItemView_KeyDown;

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
                    //foreach (var column in gridColumnsCollection)
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption =
                    //            column.ColumnCaption;
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Visible = false;
                    //    }
                    //_gridLookUpEditBudgetSubKindItem.DisplayMember = "BudgetKindItemCode";
                    //_gridLookUpEditBudgetSubKindItem.ValueMember = "BudgetKindItemCode";

                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, _budgetSubKindItemModels, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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
                        AllowNullInput = DefaultBoolean.True
                    };
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetItem.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetItem.KeyDown += _gridLookUpEditBudgetItemView_KeyDown;

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditBudgetItem.DisplayMember = "BudgetItemCode";
                    //_gridLookUpEditBudgetItem.ValueMember = "BudgetItemCode";

                    _gridLookUpEditBudgetItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemView, budgetItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetItemView);

                    #endregion
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>
        /// The budget chapters.
        /// </value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                try
                {
                    lookUpEditBudgetChapterCode.Properties.DataSource = value;
                    lookUpEditBudgetChapterCode.Properties.PopulateColumns();

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnCaption = "Mã Chương",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetChapterName",
                        ColumnCaption = "Tên Chương",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            lookUpEditBudgetChapterCode.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            lookUpEditBudgetChapterCode.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            lookUpEditBudgetChapterCode.Properties.Columns[column.ColumnName].Visible = false;
                    }
                    lookUpEditBudgetChapterCode.Properties.DisplayMember = "BudgetChapterCode";
                    lookUpEditBudgetChapterCode.Properties.ValueMember = "BudgetChapterCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Control Events

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSourceView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSourceView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceId = grdAccountingView.Columns["BudgetSourceId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceId, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSubKindItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSubKindItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSubKindItemCode = grdAccountingView.Columns["BudgetSubKindItemCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSubKindItemCode, null);
            e.Handled = true;
        }


        /// <summary>
        /// Handles the KeyDown event of the lookUpEditBudgetChapterCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditBudgetItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetItemCode = grdAccountingView.Columns["BudgetItemCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetItemCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the lookUpEditBudgetChapterCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lookUpEditBudgetChapterCode_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditBudgetChapterCode.EditValue == null)
                return;
            var budgetChapterName = (string)lookUpEditBudgetChapterCode.GetColumnValue("BudgetChapterName");
            txtBudgetChapterName.Text = budgetChapterName;
        }


        private void lookUpEditBudgetChapterCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBudgetChapter = new FrmBudgetChapterDetail();
                frmBudgetChapter.ShowDialog();
                if (frmBudgetChapter.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetChapterIDAccountingObjectDetailForm))
                    {
                        _budgetChaptersPresenter.DisplayByIsActive(true);
                        lookUpEditBudgetChapterCode.Properties.DisplayMember = "BudgetChapterCode";
                        lookUpEditBudgetChapterCode.Properties.ValueMember = "BudgetChapterId";
                        lookUpEditBudgetChapterCode.EditValue =
                            GlobalVariable.BudgetChapterIDAccountingObjectDetailForm;
                    }
                }
            }
        }
        #endregion
    }
}
