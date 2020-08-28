/***********************************************************************
 * <copyright file="FrmOpeningSupplyEntryDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, July 19, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.View.OpeningSupplyEntry;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.Presenter.Opening;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Mask;
using BuCA.Application.iBigTime2020.Session;
using System.Threading;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Enum;
using System.IO;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.OpeningAccount
{
    /// <summary>
    /// Số dư đầu kì CCDC không qua kho chi tiết
    /// </summary>
    /// <seealso cref="DevExpress.XtraEditors.XtraForm" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IDepartmentsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.OpeningSupplyEntry.IOpeningSupplyEntriesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemsView" />
    public partial class FrmOpeningSupplyEntryDetail : XtraForm, IDepartmentsView, IOpeningSupplyEntriesView, IInventoryItemsView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmOpeningSupplyEntryDetail"/> class.
        /// </summary>
        public FrmOpeningSupplyEntryDetail()
        {
            InitializeComponent();
            _departmentsPresenter = new DepartmentsPresenter(this);
            _openingSupplyEntriesPresenter = new OpeningSupplyEntriesPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmOpeningSupplyEntryDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmOpeningSupplyEntryDetail_Load(object sender, EventArgs e)
        {
            _departmentsPresenter.Display();
            _inventoryItemsPresenter.DisplayByIsStockAndIsActiveAndCategoryCode(false, true, "CCDC");
            _openingSupplyEntriesPresenter.Display();

            switch (this.ActionMode)
            {
                case ActionModeVoucherEnum.None:
                    grdOpeningSuppyEntryView.OptionsBehavior.Editable = false;
                    grdOpeningSuppyEntryView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    btnOk.Enabled = false;
                    break;
                case ActionModeVoucherEnum.AddNew:
                    this.Text = "Thêm số dư CCDC";
                    break;
                case ActionModeVoucherEnum.Edit:
                    this.Text = "Sửa số dư CCDC";
                    break;
            }
        }

        #region RepositoryItemGridLookUpEdit
        /// <summary>
        /// The grid look up edit department
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        /// <summary>
        /// The grid look up edit department view
        /// </summary>
        private GridView _gridLookUpEditDepartmentView;

        /// <summary>
        /// The grid look up edit inventory item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItem;
        /// <summary>
        /// The grid look up edit inventory item view
        /// </summary>
        private GridView _gridLookUpEditInventoryItemView;
        #endregion

        #region Properties
        /// <summary>
        /// Trạng thái: Thêm, Sửa
        /// </summary>
        /// <value>
        /// The action mode.
        /// </value>
        public ActionModeVoucherEnum ActionMode { get; set; }
        #endregion

        #region Presenter
        /// <summary>
        /// The departments presenter
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;
        /// <summary>
        /// The inventory items presenter
        /// </summary>
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        /// <summary>
        /// The opening supply entries presenter
        /// </summary>
        private readonly OpeningSupplyEntriesPresenter _openingSupplyEntriesPresenter;
        #endregion

        #region Danh sách công cụ dụng cụ không qua kho
        /// <summary>
        /// The list iventory item
        /// </summary>
        List<InventoryItemModel> _listIventoryItem;

        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>
        /// The inventory items.
        /// </value>
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                try
                {
                    if (value == null)
                        return;
                    _listIventoryItem = value.ToList();

                    _gridLookUpEditInventoryItemView = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridViewReponsitory();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã CCDC", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên CCDC", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    _gridLookUpEditInventoryItem = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInventoryItemView, value, "InventoryItemCode", "InventoryItemId", gridColumnsCollection);
                    _gridLookUpEditInventoryItem.Popup += _gridLookUpEditInventoryItem_Popup;
                    _gridLookUpEditInventoryItem.KeyPress += _gridLookUpEditInventoryItem_KeyPress;
                    XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInventoryItemView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// The flag key
        /// </summary>
        bool _flagKey;

        /// <summary>
        /// Handles the KeyPress event of the _gridLookUpEditInventoryItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditInventoryItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = _flagKey;
        }

        /// <summary>
        /// Handles the Popup event of the _gridLookUpEditInventoryItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditInventoryItem_Popup(object sender, EventArgs e)
        {
            GridLookUpEdit look = sender as GridLookUpEdit;
            if (look == null)
                return;

            if (bindingSourceOpeningSupplyEntry.DataSource == null)
                return;
            var openingSuppyEntries = ((IList<OpeningSupplyEntryModel>)bindingSourceOpeningSupplyEntry.DataSource).ToList();
            if (openingSuppyEntries.Count == 0)
                return;

            if (look.Properties.DataSource == null)
                return;

            string sFilter = string.Empty;

            var openingSupplyEntryModel = (OpeningSupplyEntryModel)grdOpeningSuppyEntryView.GetFocusedRow();
            if (openingSupplyEntryModel == null)
            {
                look.Properties.View.ActiveFilterString = string.Empty;
                return;
            }

            if (grdOpeningSuppyEntryView.FocusedRowHandle >= 0)
            {
                // Nếu sửa lại dòng cũ
                // Chưa có phòng ban => chọn tất cả vật tư
                if (string.IsNullOrEmpty(openingSupplyEntryModel.DepartmentId))
                {
                    sFilter = string.Empty;
                }
                // Có phòng ban rồi thì bỏ các vật tư mà phòng ban đó đã có
                else
                {
                    openingSuppyEntries = openingSuppyEntries.Where(m => (m.DepartmentId ?? string.Empty).Equals(openingSupplyEntryModel.DepartmentId)).ToList();

                    // Đã có vật tư rồi thì giữ lại chính nó
                    if (!string.IsNullOrEmpty(openingSupplyEntryModel.InventoryItemId))
                    {
                        openingSuppyEntries = openingSuppyEntries.Where(m => !(m.InventoryItemId ?? string.Empty).Equals(openingSupplyEntryModel.InventoryItemId)).ToList();
                    }

                    sFilter = "NOT [InventoryItemId] IN ('" + string.Join("','", openingSuppyEntries.Select(m => { return m.InventoryItemId; }).ToArray()) + "')";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(openingSupplyEntryModel.DepartmentId))
                {
                    openingSuppyEntries = openingSuppyEntries.Where(m => (m.DepartmentId ?? string.Empty).Equals(openingSupplyEntryModel.DepartmentId)).ToList();
                    sFilter = "NOT [InventoryItemId] IN ('" + string.Join("','", openingSuppyEntries.Select(m => { return m.InventoryItemId; }).ToArray()) + "')";
                }
                else
                {
                    sFilter = string.Empty;
                }
            }

            look.Properties.View.ActiveFilterString = sFilter;
        }
        #endregion

        #region Danh sách phòng ban
        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        public IList<DepartmentModel> Departments
        {
            set
            {
                if (value == null)
                    return;
                _gridLookUpEditDepartmentView = XtraColumnCollectionHelper<DepartmentModel>.CreateGridViewReponsitory();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentCode", ColumnCaption = "Mã phòng ban", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentName", ColumnCaption = "Tên phòng ban", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });
                _gridLookUpEditDepartment = XtraColumnCollectionHelper<DepartmentModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDepartmentView, value, "DepartmentName", "DepartmentId", gridColumnsCollection);
                _gridLookUpEditDepartment.KeyPress += _gridLookUpEditDepartment_KeyPress;
                _gridLookUpEditDepartment.Popup += _gridLookUpEditDepartment_Popup;
                XtraColumnCollectionHelper<DepartmentModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDepartmentView);
            }
        }

        /// <summary>
        /// Handles the KeyPress event of the _gridLookUpEditDepartment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditDepartment_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = _flagKey;
        }

        /// <summary>
        /// Handles the Popup event of the _gridLookUpEditDepartment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditDepartment_Popup(object sender, EventArgs e)
        {
            GridLookUpEdit look = sender as GridLookUpEdit;
            if (look == null)
                return;

            if (bindingSourceOpeningSupplyEntry.DataSource == null)
                return;
            var openingSuppyEntries = ((IList<OpeningSupplyEntryModel>)bindingSourceOpeningSupplyEntry.DataSource).ToList();
            if (openingSuppyEntries.Count == 0)
                return;

            if (look.Properties.DataSource == null)
                return;

            string sFilter = string.Empty;

            var openingSupplyEntryModel = (OpeningSupplyEntryModel)grdOpeningSuppyEntryView.GetFocusedRow();
            if (openingSupplyEntryModel == null)
            {
                look.Properties.View.ActiveFilterString = string.Empty;
                return;
            }

            if (grdOpeningSuppyEntryView.FocusedRowHandle >= 0)
            {
                // Nếu sửa lại dòng cũ
                // Chưa có vật tư => chọn tất cả phòng ban
                if (string.IsNullOrEmpty(openingSupplyEntryModel.InventoryItemId))
                {
                    sFilter = string.Empty;
                }
                // Có vật tư rồi thì bỏ các phòng ban mà vật tư đó đã có
                else
                {
                    openingSuppyEntries = openingSuppyEntries.Where(m => (m.InventoryItemId ?? string.Empty).Equals(openingSupplyEntryModel.InventoryItemId)).ToList();

                    // Đã có phòng ban rồi thì giữ lại chính nó
                    if (!string.IsNullOrEmpty(openingSupplyEntryModel.DepartmentId))
                    {
                        openingSuppyEntries = openingSuppyEntries.Where(m => !(m.DepartmentId ?? string.Empty).Equals(openingSupplyEntryModel.DepartmentId)).ToList();
                    }

                    sFilter = "NOT [DepartmentId] IN ('" + string.Join("','", openingSuppyEntries.Select(m => { return m.DepartmentId; }).ToArray()) + "')";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(openingSupplyEntryModel.InventoryItemId))
                {
                    openingSuppyEntries = openingSuppyEntries.Where(m => (m.InventoryItemId ?? string.Empty).Equals(openingSupplyEntryModel.InventoryItemId)).ToList();
                    sFilter = "NOT [DepartmentId] IN ('" + string.Join("','", openingSuppyEntries.Select(m => { return m.DepartmentId; }).ToArray()) + "')";
                }
                else
                {
                    sFilter = string.Empty;
                }
            }

            look.Properties.View.ActiveFilterString = sFilter;
        }
        #endregion

        #region Hiển thị danh sách lên grid
        /// <summary>
        /// Sets the opening account entries.
        /// </summary>
        /// <value>
        /// The opening account entries.
        /// </value>
        public IList<OpeningSupplyEntryModel> OpeningSupplyEntries
        {
            get
            {
                var openingSuppyEntries = new List<OpeningSupplyEntryModel>();
                openingSuppyEntries = ((IList<OpeningSupplyEntryModel>)bindingSourceOpeningSupplyEntry.DataSource).ToList();

                openingSuppyEntries.ForEach(m =>
                {
                    m.PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1);
                    m.CurrencyCode = GlobalVariable.MainCurrencyId;
                    m.ExchangeRate = 1;
                    m.Amount = m.AmountOC;
                    m.UnitPrice = m.UnitPriceOC;
                    m.RefType = (int)RefType.OpeningSupplyEntry;
                });
                return openingSuppyEntries;
            }

            set
            {
                if (value == null)
                    return;

                bindingSourceOpeningSupplyEntry.DataSource = value.OrderBy(c => c.SortOrder).ToList();
                grdOpeningSuppyEntryView.PopulateColumns(value);

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = true, ColumnWith = 200, ColumnCaption = "Mã CCDC", ColumnPosition = 1, AllowEdit = true, RepositoryControl = _gridLookUpEditInventoryItem });
                columnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnVisible = true, ColumnWith = 350, ColumnCaption = "Tên CCDC", ColumnPosition = 2, });
                columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = true, ColumnWith = 300, ColumnCaption = "Phòng ban", ColumnPosition = 3, AllowEdit = true, RepositoryControl = _gridLookUpEditDepartment });
                columnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Số lượng tồn", ColumnPosition = 3, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                columnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceOC", ColumnVisible = true, ColumnWith = 150, ColumnCaption = "Đơn giá tồn", ColumnPosition = 4, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                columnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnVisible = true, ColumnWith = 200, ColumnCaption = "Giá trị tồn", ColumnPosition = 5, ColumnType = UnboundColumnType.Decimal, AllowEdit = true, IsSummnary = true });
                XtraColumnCollectionHelper<OpeningSupplyEntryModel>.ShowXtraColumnInGridView(columnsCollection, grdOpeningSuppyEntryView);
            }
        }
        #endregion

        #region Function
        /// <summary>
        /// Sets the numeric format control.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        private void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryDateEdit = new RepositoryItemDateEdit() { AllowMouseWheel = false };

            foreach (GridColumn oCol in gridView.Columns)
            {
                if (!oCol.Visible)
                    continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        if (oCol.Name == "ExchangeRate")
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.ExchangeRateDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(GlobalVariable.ExchangeRateDecimalDigits);
                        }
                        else if (oCol.Name.Equals("UnitPriceOC"))
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = GlobalVariable.CurrencyDecimalDigits;
                        }
                        else
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyUnitPriceDigits;
                            repositoryCurrencyCalcEdit.Precision = GlobalVariable.CurrencyUnitPriceDigits;
                        }

                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.DateTime:
                        repositoryDateEdit.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
                        repositoryDateEdit.Mask.EditMask = @"dd/MM/yyyy";
                        repositoryDateEdit.DisplayFormat.FormatType = FormatType.DateTime;
                        repositoryDateEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryDateEdit;
                        break;
                }
            }
        }
        #endregion

        #region Button click
        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <param name="openingSupplyEntries">The opening supply entries.</param>
        /// <returns></returns>
        bool ValidData(List<OpeningSupplyEntryModel> openingSupplyEntries)
        {
            if (openingSupplyEntries.Exists(m => string.IsNullOrEmpty(m.InventoryItemId)))
            {
                XtraMessageBox.Show("Chọn công cụ dụng cụ.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (openingSupplyEntries.Exists(m => string.IsNullOrEmpty(m.DepartmentId)))
            {
                XtraMessageBox.Show("Chọn phòng ban.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            grdOpeningSuppyEntryView.CloseEditor();
            var openingSupplyEntries = this.OpeningSupplyEntries;
            if (!ValidData(openingSupplyEntries.ToList()))
                return;
            _openingSupplyEntriesPresenter.Save(openingSupplyEntries);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Handles the ItemClick event of the barManager1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs"/> instance containing the event data.</param>
        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "barItemDelete":
                    grdOpeningSuppyEntryView.DeleteSelectedRows();
                    break;
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// Nhập số lượng và giá trị tồn tự động tính ra đơn giá
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        private void grdOpeningSuppyEntryView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            // Số lượng
            if (e.Column.FieldName == "Quantity")
            {
                var quantity = e.Value ?? 0;
                if ((decimal)quantity == 0)
                    view.SetRowCellValue(e.RowHandle, "UnitPriceOC", 0);
                else
                {
                    var amountOC = view.GetRowCellValue(e.RowHandle, "AmountOC") == null ? 0 : (decimal)view.GetRowCellValue(e.RowHandle, "AmountOC");
                    if (amountOC == 0)
                        view.SetRowCellValue(e.RowHandle, "UnitPriceOC", 0);
                    else
                        view.SetRowCellValue(e.RowHandle, "UnitPriceOC", amountOC / (decimal)quantity);
                }
            }

            // Giá trị tồn
            if (e.Column.FieldName == "AmountOC")
            {
                var amountOC = e.Value ?? 0;
                if ((decimal)amountOC == 0)
                    view.SetRowCellValue(e.RowHandle, "UnitPriceOC", 0);
                else
                {
                    var quantity = view.GetRowCellValue(e.RowHandle, "Quantity") == null ? 0 : (decimal)view.GetRowCellValue(e.RowHandle, "Quantity");
                    if (quantity == 0)
                        view.SetRowCellValue(e.RowHandle, "UnitPriceOC", 0);
                    else
                        view.SetRowCellValue(e.RowHandle, "UnitPriceOC", (decimal)amountOC / quantity);
                }
            }

            if (e.Column.FieldName.Equals("InventoryItemId"))
            {
                if (_listIventoryItem == null)
                    return;

                InventoryItemModel iventory = _listIventoryItem.FirstOrDefault(m => m.InventoryItemId.Equals(Convert.ToString(e.Value)));
                if (iventory != null)
                {
                    grdOpeningSuppyEntryView.SetRowCellValue(e.RowHandle, "InventoryItemName", iventory.InventoryItemName);
                    grdOpeningSuppyEntryView.SetRowCellValue(e.RowHandle, "DepartmentId", iventory.DepartmentId);
                    grdOpeningSuppyEntryView.SetRowCellValue(e.RowHandle, "InventoryItemCode", iventory.InventoryItemCode);
                }
                else
                {
                    grdOpeningSuppyEntryView.SetRowCellValue(e.RowHandle, "InventoryItemName", string.Empty);
                    grdOpeningSuppyEntryView.SetRowCellValue(e.RowHandle, "DepartmentId", string.Empty);
                    grdOpeningSuppyEntryView.SetRowCellValue(e.RowHandle, "InventoryItemCode", string.Empty);
                }
            }
        }

        /// <summary>
        /// Handles the PopupMenuShowing event of the grdOpeningSuppyEntryView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PopupMenuShowingEventArgs"/> instance containing the event data.</param>
        private void grdOpeningSuppyEntryView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenuDetail.ShowPopup(grdOpeningSuppyEntry.PointToScreen(e.Point));
                }
            }
        }

        /// <summary>
        /// Disable paste
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdOpeningSuppyEntry_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.Equals(Keys.Control) && e.KeyCode.Equals(Keys.V))
                _flagKey = true;
            else
                _flagKey = false;
        }
        #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(117));
        }
    }
}
