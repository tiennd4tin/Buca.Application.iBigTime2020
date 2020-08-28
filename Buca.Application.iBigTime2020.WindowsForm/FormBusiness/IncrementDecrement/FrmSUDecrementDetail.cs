/***********************************************************************
 * <copyright file="FrmSUIncrementDecrements.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 27, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.IncrementDecrement;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.IncrementDecrement;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.IncrementDecrement
{
    /// <summary>
    /// FrmSUDecrementDetail
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.IncrementDecrement.ISUIncrementDecrementView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IDepartmentsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    public partial class FrmSUDecrementDetail : FrmXtraBaseVoucherDetail, ISUIncrementDecrementView, IInventoryItemsView,
        IDepartmentsView, IAccountsView, IAccountingObjectsView,
        IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmSUDecrementDetail"/> class.
        /// </summary>
        public FrmSUDecrementDetail()
        {
            InitializeComponent();
            _suIncrementDecrementPresenter = new SUIncrementDecrementPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
        }

        #region Presenter

        /// <summary>
        /// The s u increment decrements presenter
        /// </summary>
        private readonly SUIncrementDecrementPresenter _suIncrementDecrementPresenter;

        /// <summary>
        /// The inventory items presenter
        /// </summary>
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;

        /// <summary>
        /// The departments presenter
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;

        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;

        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        /// <summary>
        /// The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        /// <summary>
        /// The budget kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetKindItemModels;

        private List<InventoryItemModel> _inventoryItemModels;

        #endregion

        #region RepositoryItemLookUpEdit

        /// <summary>
        /// The repository method distribute identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        /// <summary>
        /// The grid look up edit inventory item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItem;

        /// <summary>
        /// The grid look up edit inventory item view
        /// </summary>
        private GridView _gridLookUpEditInventoryItemView;

        /// <summary>
        /// The grid look up edit department
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;

        /// <summary>
        /// The grid look up edit department view
        /// </summary>
        private GridView _gridLookUpEditDepartmentView;

        /// <summary>
        /// The grid look up edit account
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;

        /// <summary>
        /// The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditDebitAccountView;

        /// <summary>
        /// The grid look up edit account
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditCreditAccount;

        /// <summary>
        /// The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditCreditAccountView;

        /// <summary>
        /// The grid look up edit accounting object
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;

        /// <summary>
        /// The grid look up edit accounting object view
        /// </summary>
        private GridView _gridLookUpEditAccountingObjectView;

        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;

        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        /// The grid look up edit budget chapter
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;

        /// <summary>
        /// The grid look up edit budget chapter view
        /// </summary>
        private GridView _gridLookUpEditBudgetChapterView;

        /// <summary>
        /// The grid look up edit budget sub kind item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;

        /// <summary>
        /// The grid look up edit budget sub kind item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubKindItemView;

        #endregion

        #region overrides

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Visible = false;
            tabMain.SelectedTabPage = tabAccounting;
            grdAccounting.Visible = true;
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountingObjectsPresenter.DisplayActive(true);
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _departmentsPresenter.DisplayActive();
            _inventoryItemsPresenter.DisplaybyInventoryCategoryCode("CCDC");
            InitRepositoryControlData();
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((SUIncrementDecrementModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((SUIncrementDecrementModel)MasterBindingSource.Current).RefId;
            }

            _suIncrementDecrementPresenter.Display(KeyValue, true);

            //if (RefType == 0)
            //    RefType = (int)BuCA.Enum.RefType.CAPayment;

            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.SUDecrement;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
        protected override bool ValidData()
        {
            grdAccountingView.CloseEditor();
            grdAccountingView.UpdateCurrentRow();

            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            if (dtPostDate.EditValue == null || dtPostDate.DateTime == DateTime.MinValue || PostedDate == null || PostedDate == DateTime.MinValue)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostDate"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtPostDate.Focus();
                return false;
            }
            if (dtRefDate.EditValue == null || dtRefDate.DateTime == DateTime.MinValue || RefDate == null || RefDate == DateTime.MinValue)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDate"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtRefDate.Focus();
                return false;
            }

            var sUIncrementDecrementDetails = SUIncrementDecrementDetails;
            if (sUIncrementDecrementDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            foreach (var suIncrementDecrementDetailModel in sUIncrementDecrementDetails)
            {
                if (string.IsNullOrEmpty(suIncrementDecrementDetailModel.InventoryItemId))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemIdRequired"), detailContent,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (string.IsNullOrEmpty(suIncrementDecrementDetailModel.DepartmentId))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDepartmentIdRequired"), detailContent,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
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
            //txtDocumentInclude.ReadOnly = true;
            //txtTaxCode.ReadOnly = true;
            return _suIncrementDecrementPresenter.Save();
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new SUIncrementDecrementPresenter(null).Delete(KeyValue);
        }

        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "UnitPrice")
            {
                var unitPrice = grdAccountingView.GetRowCellValue(e.RowHandle, "UnitPrice") == null ? 0 : (decimal)grdAccountingView.GetRowCellValue(e.RowHandle, "UnitPrice");
                var quantity = grdAccountingView.GetRowCellValue(e.RowHandle, "Quantity") == null ? 0 : (decimal)grdAccountingView.GetRowCellValue(e.RowHandle, "Quantity");

                grdAccountingView.SetRowCellValue(e.RowHandle, "Amount", unitPrice * quantity);
            }
            if (e.Column.FieldName == "Quantity")
            {
                var unitPrice = grdAccountingView.GetRowCellValue(e.RowHandle, "UnitPrice") == null ? 0 : (decimal)grdAccountingView.GetRowCellValue(e.RowHandle, "UnitPrice");
                var quantity = grdAccountingView.GetRowCellValue(e.RowHandle, "Quantity") == null ? 0 : (decimal)grdAccountingView.GetRowCellValue(e.RowHandle, "Quantity");

                grdAccountingView.SetRowCellValue(e.RowHandle, "Amount", unitPrice * quantity);
            }
            if (e.Column.FieldName == "InventoryItemId")
            {
                var inventoryItemId = grdAccountingView.GetRowCellValue(e.RowHandle, "InventoryItemId") == null ? null : (string)grdAccountingView.GetRowCellValue(e.RowHandle, "InventoryItemId");
                var inventoryItem = _inventoryItemModels.FirstOrDefault(x => x.InventoryItemId == inventoryItemId);
                grdAccountingView.SetRowCellValue(e.RowHandle, "UnitPrice", inventoryItem == null ? 0 : inventoryItem.UnitPrice);
                grdAccountingView.SetRowCellValue(e.RowHandle, "Description", inventoryItem == null ? "" : inventoryItem.InventoryItemName);
            }
        }

        #endregion

        #region ISUIncrementDecrementView
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefType { get; set; }

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
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        /// The paralell reference no.
        /// </value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
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
                return SUIncrementDecrementDetails.Sum(x => x.Amount);

            }
            set { }
        }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>
        /// The edit version.
        /// </value>
        public int? EditVersion { get; set; }

        /// <summary>
        /// Gets or sets the su increment decrement details.
        /// </summary>
        /// <value>
        /// The su increment decrement details.
        /// </value>
        public IList<SUIncrementDecrementDetailModel> SUIncrementDecrementDetails
        {
            get
            {
                var sUIncrementDecrementDetails = new List<SUIncrementDecrementDetailModel>();
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (SUIncrementDecrementDetailModel)grdAccountingView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var budgetKindItemCode = "";
                            if (!string.IsNullOrEmpty(rowVoucher.BudgetSubKindItemCode))
                            {
                                var budgetSubKindItem = _budgetSubKindItemModels.FirstOrDefault(b => b.BudgetKindItemCode == rowVoucher.BudgetSubKindItemCode);
                                if (budgetSubKindItem == null)
                                    budgetKindItemCode = null;
                                else
                                {
                                    var budgetKindItem = _budgetKindItemModels.FirstOrDefault(b => b.BudgetKindItemId == budgetSubKindItem.ParentId);
                                    budgetKindItemCode = budgetKindItem == null ? null : budgetKindItem.BudgetKindItemCode;
                                }
                            }
                            var item = new SUIncrementDecrementDetailModel
                            {
                                Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                                Amount = rowVoucher.Amount,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                DepartmentId = rowVoucher.DepartmentId,
                                InventoryItemId = rowVoucher.InventoryItemId,
                                Quantity = rowVoucher.Quantity,
                                UnitPrice = rowVoucher.UnitPrice,
                                SortOrder = i
                            };
                            sUIncrementDecrementDetails.Add(item);
                        }
                    }
                }

                return sUIncrementDecrementDetails;
            }
            set
            { 
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<SUIncrementDecrementDetailModel>();
                grdAccountingView.PopulateColumns(value);

                #region columns for grdAccountingView
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 120,
                        ColumnCaption = "Mã CCDC",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 300,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "DepartmentId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDepartment,
                        ColumnWith = 100,
                        ColumnCaption = "Phòng/Ban",
                        ColumnPosition = 3,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = false,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 80,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 4,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = false,
                        ColumnWith = 80,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCreditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số lượng",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Integer
                    },
                    new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Đơn giá",
                        ColumnPosition = 7,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Thành tiền",
                        ColumnPosition = 8,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode",ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Chương",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetKindItemCode",
                        ColumnVisible = false
                    }, //chon thang subkinditem la ra kinditem
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 121,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    }
            };
                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;
                #endregion
            }
        }

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
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
            {
                if (grdView.Columns[column.ColumnName] != null)
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
                        if (column.IsSummaryText)
                        {
                            grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
                }
            }
            return grdView;
        }

        /// <summary>
        /// Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {
            var methodDistribute = typeof(MethodDistribute).ToList();
            _repositoryMethodDistributeId = new RepositoryItemLookUpEdit
            {
                DataSource = methodDistribute,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryMethodDistributeId.PopulateColumns();
            _repositoryMethodDistributeId.Columns["Key"].Visible = false;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditAccountingObjectView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditAccountingObjectView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var accountingObjectId = grdAccountingView.Columns["AccountingObjectId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, accountingObjectId, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditInventoryItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditInventoryItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var inventoryItemId = grdAccountingView.Columns["InventoryItemId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, inventoryItemId, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditDepartmentView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditDepartmentView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var departmentId = grdAccountingView.Columns["DepartmentId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, departmentId, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditAccountView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditDebitAccountView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var creditAccount = grdAccountingView.Columns["CreditAccount"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, creditAccount, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditAccountView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditCreditAccountView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var debitAccount = grdAccountingView.Columns["DebitAccount"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, debitAccount, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSourceView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSourceView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceId = grdAccountingView.Columns["BudgetSourceId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceId, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetChapterView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditBudgetChapterView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetChapterCode = grdAccountingView.Columns["BudgetChapterCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetChapterCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSubKindItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSubKindItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSubKindItemCode = grdAccountingView.Columns["BudgetSubKindItemCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSubKindItemCode, null);
            e.Handled = true;
        }
        #endregion

        #region IView Members

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
                    _gridLookUpEditInventoryItemView = new GridView();
                    _gridLookUpEditInventoryItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditInventoryItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditInventoryItemView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditInventoryItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditInventoryItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditInventoryItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditInventoryItem.View.BestFitColumns();
                    _gridLookUpEditInventoryItem.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditInventoryItem.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditInventoryItem.NullText = "";
                    _gridLookUpEditInventoryItem.KeyDown += _gridLookUpEditInventoryItemView_KeyDown;
                     
                    var suinventory = value == null ? new List<InventoryItemModel>() : value.Where(x => x.IsStock == false).ToList();
                    _gridLookUpEditInventoryItem.DataSource = suinventory;
                    _gridLookUpEditInventoryItemView.PopulateColumns(suinventory);
                    _inventoryItemModels = suinventory.ToList();

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemCode",
                        ColumnCaption = "Mã CCDC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemName",
                        ColumnCaption = "Tên CCDC",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalePrice", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultStockId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "COGSAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SaleAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CostMethod", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaxRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsService", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTaxable", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsStock", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "UnitsInStock", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditInventoryItem.DisplayMember = "InventoryItemCode";
                    _gridLookUpEditInventoryItem.ValueMember = "InventoryItemId";
                    //Filter cho gridview
                    _gridLookUpEditInventoryItemView = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditInventoryItem = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInventoryItemView, value, "InventoryItemCode", "InventoryItemId", gridColumnsCollection);
                    XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInventoryItemView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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
                try
                {
                    _gridLookUpEditDepartmentView = new GridView();
                    _gridLookUpEditDepartmentView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditDepartment = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditDepartmentView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditDepartment.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDepartment.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDepartment.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditDepartment.View.BestFitColumns();
                    _gridLookUpEditDepartment.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditDepartment.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditDepartment.NullText = "";
                    _gridLookUpEditDepartment.KeyDown += _gridLookUpEditDepartmentView_KeyDown;

                    _gridLookUpEditDepartment.DataSource = value;
                    _gridLookUpEditDepartmentView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DepartmentCode",
                        ColumnCaption = "Mã phòng/ban",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DepartmentName",
                        ColumnCaption = "Tên phòng/ban",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditDepartment.DisplayMember = "DepartmentCode";
                    _gridLookUpEditDepartment.ValueMember = "DepartmentId";
                    //Filter cho gridview
                    _gridLookUpEditDepartmentView = XtraColumnCollectionHelper<DepartmentModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDepartment = XtraColumnCollectionHelper<DepartmentModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDepartmentView, value, "DepartmentName", "DepartmentId", gridColumnsCollection);
                    XtraColumnCollectionHelper<DepartmentModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDepartmentView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public IList<AccountModel> Accounts
        {
            set
            {
                try
                {
                    var debitAccounts = value;
                    var creditAccounts = value; //.Where(c => c.AccountNumber.StartsWith("005")).ToList();

                    #region DebitAccount
                    _gridLookUpEditDebitAccountView = new GridView();
                    _gridLookUpEditDebitAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditDebitAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditDebitAccountView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditDebitAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDebitAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDebitAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditDebitAccount.View.BestFitColumns();
                    _gridLookUpEditDebitAccount.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditDebitAccount.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditDebitAccount.NullText = "";
                    _gridLookUpEditDebitAccount.KeyDown += _gridLookUpEditDebitAccountView_KeyDown;


                    _gridLookUpEditDebitAccount.DataSource = debitAccounts;
                    _gridLookUpEditDebitAccountView.PopulateColumns(debitAccounts);
                    #endregion 

                    #region CreditAccount
                    _gridLookUpEditCreditAccountView = new GridView();
                    _gridLookUpEditCreditAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCreditAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCreditAccountView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditCreditAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCreditAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCreditAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditCreditAccount.View.BestFitColumns();
                    _gridLookUpEditCreditAccount.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditCreditAccount.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditCreditAccount.NullText = "";
                    _gridLookUpEditCreditAccount.KeyDown += _gridLookUpEditCreditAccountView_KeyDown;


                    _gridLookUpEditCreditAccount.DataSource = creditAccounts;
                    _gridLookUpEditCreditAccountView.PopulateColumns(creditAccounts);
                    #endregion

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountNumber",
                        ColumnCaption = "Số tài khoản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountName",
                        ColumnCaption = "Tên tài khoản",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountForeignName",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetSource",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetChapter",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetKindItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetSubItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByMethodDistribute",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByAccountingObject",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByInventoryItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByFixedAsset",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByProjectActivity",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDisplayOnAccountBalanceSheet",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDisplayBalanceOnReport",
                        ColumnVisible = false
                    });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditDebitAccountView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Width = column.ColumnWith;

                            _gridLookUpEditCreditAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditCreditAccountView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditCreditAccountView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Visible = false;
                            _gridLookUpEditCreditAccountView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditDebitAccount.DisplayMember = "AccountNumber";
                    _gridLookUpEditDebitAccount.ValueMember = "AccountNumber";

                    _gridLookUpEditCreditAccount.DisplayMember = "AccountNumber";
                    _gridLookUpEditCreditAccount.ValueMember = "AccountNumber";
                    //Filter cho gridview
                    _gridLookUpEditCreditAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCreditAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCreditAccountView, value, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCreditAccountView);
                    //Filter cho gridview
                    _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, value, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <value>
        /// The accounting objects.
        /// </value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                try
                {
                    _gridLookUpEditAccountingObjectView = new GridView();
                    _gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditAccountingObjectView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditAccountingObject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditAccountingObject.View.BestFitColumns();
                    _gridLookUpEditAccountingObject.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditAccountingObject.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditAccountingObject.NullText = "";
                    _gridLookUpEditAccountingObject.KeyDown += _gridLookUpEditAccountingObjectView_KeyDown;

                    _gridLookUpEditAccountingObject.DataSource = value;
                    _gridLookUpEditAccountingObjectView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Tel", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Fax", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Website", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CompanyTaxCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AreaCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactTitle", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactSex", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactMobile", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactEmail", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactOfficeTel", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactHomeTel", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactAddress", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsPersonal", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IdentificationNumber",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IssueDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IssueBy", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryScaleId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Insured", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LabourUnionFee", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FamilyDeductionAmount",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsCustomerVendor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryCoefficient", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "NumberFamilyDependent",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryForm", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryPercentRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsPayInsuranceOnSalary",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InsuranceAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsUnEmploymentInsurance",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeAO", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryGrade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField1", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField2", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField3", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField4", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField5", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsPaidInsuranceForPayrollItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsBornLeave", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaxDepartmentName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeTypeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "OrganizationManageFee",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectCode";
                    _gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";
                    //Filter cho gridview
                    _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, value, "AccountingObjectCode", "AccountingObjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountingObjectView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    _gridLookUpEditBudgetSource.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetSource.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetSource.NullText = "";
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
                   
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    _gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    _gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";
                    //Filter cho gridview
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
                    _gridLookUpEditBudgetChapterView = new GridView();
                    _gridLookUpEditBudgetChapterView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetChapter = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetChapterView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetChapter.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetChapter.View.BestFitColumns();
                    _gridLookUpEditBudgetChapter.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetChapter.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetChapter.NullText = "";
                    _gridLookUpEditBudgetChapter.KeyDown += _gridLookUpEditBudgetChapterView_KeyDown;

                    _gridLookUpEditBudgetChapter.DataSource = value;
                    _gridLookUpEditBudgetChapterView.PopulateColumns(value);

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
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditBudgetChapter.DisplayMember = "BudgetChapterCode";
                    _gridLookUpEditBudgetChapter.ValueMember = "BudgetChapterCode";
                    //Filter cho gridview
                    _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);
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
                    _budgetKindItemModels = value.Where(v => v.IsParent).ToList();
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
                    _gridLookUpEditBudgetSubKindItem.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetSubKindItem.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetSubKindItem.NullText = "";
                    _gridLookUpEditBudgetSubKindItem.KeyDown += _gridLookUpEditBudgetSubKindItemView_KeyDown;


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
                    //Filter cho gridview
                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, value, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }
    }
}
