/***********************************************************************
 * <copyright file="frmFAIncrementDecrementDetail.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.Model.BusinessObjects.PUInvoice;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraGrid.Views.Base;
using Buca.Application.iBigTime2020.Presenter.IncrementDecrement;
using Buca.Application.iBigTime2020.View.IncrementDecrement;
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.PUInvoice
{
    /// <summary>
    /// frmFAIncrementDecrementDetail
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.IncrementDecrement.IFAIncrementDecrementView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFixedAssetsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IDepartmentsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.ICashWithdrawTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IActivitysView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    public partial class frmFAIncrementDecrementDetail : FrmXtraBaseVoucherDetail, IFAIncrementDecrementView, IAccountingObjectsView,
        IFixedAssetsView, IDepartmentsView, IAccountsView, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView,
        ICashWithdrawTypesView, IActivitysView,
        IProjectsView, IBanksView, IBudgetExpensesView
    {
        #region Variable
        public delegate void RecallFunction();

        List<FixedAssetModel> _listFixedAsset;
        List<AccountModel> _listAccounts;
        List<BudgetItemModel> _listBudgetItems;
        public string _journalMemo;

        public List<FAIncrementDecrementDetailModel> ListSendSourceDetail;
        public bool IsOpenFromFixedAssetDetail;

        AccountingObjectsPresenter _accountingObjectsPresenter;
        FAIncrementDecrementPresenter _fAIncrementDecrementPresenter;
        FixedAssetsPresenter _fixedAssetsPresenter;
        DepartmentsPresenter _departmentsPresenter;
        AccountsPresenter _accountsPresenter;
        BanksPresenter _banksPresenter;
        BudgetSourcesPresenter _budgetSourcesPresenter;
        BudgetChaptersPresenter _budgetChaptersPresenter;
        BudgetKindItemsPresenter _budgetKindItemsPresenter;
        BudgetItemsPresenter _budgetItemsPresenter;
        CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;
        ActivitysPresenter _activitysPresenter;
        ProjectsPresenter _projectsPresenter;
        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;

        private RepositoryItemGridLookUpEdit _gridLookUpBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;
        private GridView _gridLookUpEditFixedAssetView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        private GridView _gridLookUpEditDepartmentView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;
        private GridView _gridLookUpEditAccountView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditTaxAccount;
        private GridView _gridLookUpEditTaxAccountView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditMethodTribute;
        private GridView _gridLookUpEditMethodTributeView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        private GridView _gridLookUpEditBudgetChapterView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        private GridView _gridLookUpEditBudgetSubKindItemView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        private GridView _gridLookUpEditBudgetSubItemView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private GridView _gridLookUpEditBudgetItemView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;
        private GridView _gridLookUpEditCashWithdrawTypeView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        private GridView _gridLookUpEditAccountingObjectView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditListItemId;
        private GridView _gridLookUpEditListItemIdView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="frmFAIncrementDecrementDetail"/> class.
        /// </summary>
        public frmFAIncrementDecrementDetail()
        {
            InitializeComponent();

            BaseRefTypeId = BuCA.Enum.RefType.FAIncrementDecrement;
            grdMaster.Visible = false;

            IsDisplayInventoryItem = true;
            tabInventoryItem.Text = "Hạch toán";

            IsDisplayAccounting = true;
            tabAccounting.Text = "Thống kê";

            IsDisplayAccountingDetail = false;
            IsDisplayTax = false;
            tabMain.SelectedTabPage = tabInventoryItem;

            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _fAIncrementDecrementPresenter = new FAIncrementDecrementPresenter(this);

            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);

            FormCaption = CommonText.CaptionFAIncrementDecrement;
            RefTypeUsingDisplayReport = BuCA.Enum.RefType.FAIncrementDecrement;
        }

        #region Overide
        protected override void InitData()
        {
            InitRepositoryControlData();

            _accountingObjectsPresenter.DisplayActive(true);
            _fixedAssetsPresenter.DisplayByActive(true);
            _departmentsPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _banksPresenter.DisplayActive(true);
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _activitysPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _budgetExpensesPresenter.DisplayActive();
            if (MasterBindingSource != null) if (MasterBindingSource.Current != null)
                KeyValue = ((FAIncrementDecrementModel)MasterBindingSource.Current).RefId;

            _fAIncrementDecrementPresenter.Display(KeyValue, true);

            JournalMemo = _journalMemo;
        }

        protected override void GridViewMasterCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            // Overide hàm này để không nhảy số tiền về 0 khi xóa dòng
        }

        protected override void DeleteRowItemInBandedGridView()
        {
            // Tính lại tiền ở master khi xóa dòng
            CalTotalAmount();
        }

        private void CalTotalAmount()
        {
            var _source = bindingSourceDetail.DataSource;
            List<FAIncrementDecrementDetailModel> _listSource = new List<FAIncrementDecrementDetailModel>();
            if (_source != null)
            {
                _listSource = (List<FAIncrementDecrementDetailModel>)bindingSourceDetail.DataSource;
                this.TotalAmountOC = _listSource.Sum(m => m.Amount);
            }
        }
        #endregion

        #region View Master
        public string RefId { get; set; }

        public int RefType { get { return (int)this.BaseRefTypeId; } set { } }

        public DateTime RefDate { get { return dtRefDate.DateTime.Date; } set { dtRefDate.DateTime = value; } }

        public DateTime PostedDate { get { return dtPostDate.DateTime.Date; } set { dtPostDate.DateTime = value; } }

        public string RefNo { get { return txtRefNo.Text; } set { txtRefNo.Text = value; } }

        public string ParalellRefNo { get; set; }

        public string JournalMemo { get { return txtNote.Text; } set { txtNote.Text = value; } }

        public decimal TotalAmount { get { return (decimal)gridViewMaster.GetRowCellValue(0, nameof(PUInvoiceModel.TotalAmount)); } set { gridViewMaster.SetRowCellValue(0, nameof(PUInvoiceModel.TotalAmount), value); } }

        public string GeneratedRefId { get; set; }

        public string CurrencyCode
        {
            get { return gridViewMaster.GetRowCellValue(0, nameof(PUInvoiceModel.CurrencyCode)) == null ? GlobalVariable.MainCurrencyId : gridViewMaster.GetRowCellValue(0, nameof(PUInvoiceModel.CurrencyCode)).ToString(); }
            set { gridViewMaster.SetRowCellValue(0, nameof(PUInvoiceModel.CurrencyCode), value ?? GlobalVariable.MainCurrencyId); }
        }

        public decimal ExchangeRate
        {
            get
            {
                if (CurrencyCode == GlobalVariable.MainCurrencyId)
                    return 1;
                return (decimal)gridViewMaster.GetRowCellValue(0, nameof(PUInvoiceModel.ExchangeRate));
            }
            set
            {
                if (CurrencyCode == GlobalVariable.MainCurrencyId)
                    value = 1;
                gridViewMaster.SetRowCellValue(0, nameof(PUInvoiceModel.ExchangeRate), value);
            }
        }

        public decimal TotalAmountOC { get { return (decimal)gridViewMaster.GetRowCellValue(0, nameof(PUInvoiceModel.TotalAmountOC)); } set { gridViewMaster.SetRowCellValue(0, nameof(PUInvoiceModel.TotalAmountOC), value); } }

        IList<AccountingObjectModel> IAccountingObjectsView.AccountingObjects
        {
            set
            {
                if (value == null)
                    value = new List<AccountingObjectModel>();

                _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountingObjectModel.AccountingObjectCode), ColumnCaption = "Mã đối tượng", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountingObjectModel.AccountingObjectName), ColumnCaption = "Tên đối tượng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, value, nameof(AccountingObjectModel.AccountingObjectName), nameof(AccountingObjectModel.AccountingObjectId), gridColumnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountingObjectView);
            }
        }
        #endregion

        #region View Detail

        /// <summary>
        /// Gets or sets the fa increment decrement details.
        /// </summary>
        /// <value>
        /// The fa increment decrement details.
        /// </value>
        public IList<FAIncrementDecrementDetailModel> FAIncrementDecrementDetails
        {
            get
            {
                if (grdDetailByInventoryItemView.DataSource != null && grdDetailByInventoryItemView.RowCount > 0)
                {
                    for (var i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
                    {
                        var rowVoucher = (FAIncrementDecrementDetailModel)grdDetailByInventoryItemView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            grdDetailByInventoryItemView.SetRowCellValue(i,
                                grdDetailByInventoryItemView.Columns["SortOrder"], i);
                        }
                    }
                }
                var _source = bindingSourceDetail.DataSource;
                List<FAIncrementDecrementDetailModel> _listSource = new List<FAIncrementDecrementDetailModel>();
                if (_source != null)
                {
                    _listSource = (List<FAIncrementDecrementDetailModel>)bindingSourceDetail.DataSource;
                }
                return _listSource;
            }
            set
            {
                // Lấy dữ liệu ghi tăng TSCĐ tự động
                if (IsOpenFromFixedAssetDetail)
                    value = ListSendSourceDetail;

                if (value == null)
                    value = new List<FAIncrementDecrementDetailModel>();

                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList();
                if (IsOpenFromFixedAssetDetail)
                {
                    ListSendSourceDetail = null;
                    IsOpenFromFixedAssetDetail = false;
                    CalTotalAmount();
                }
                grdAccountingView.PopulateColumns(value);
                grdDetailByInventoryItemView.PopulateColumns(value);
                grdAccountingDetailView.PopulateColumns(value);

                // Tab hạch toán
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.FixedAssetId), ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 3, AllowEdit = true, RepositoryControl = _gridLookUpEditFixedAsset });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.Description), ColumnCaption = "Diễn giải", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 4, AllowEdit = true, });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.DepartmentId), ColumnCaption = "Phòng ban", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 5, RepositoryControl = _gridLookUpEditDepartment });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.DebitAccount), ColumnCaption = "TK nợ", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 6, AllowEdit = true, RepositoryControl = _gridLookUpEditDebitAccount });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.CreditAccount), ColumnCaption = "TK có", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 7, AllowEdit = true, RepositoryControl = _gridLookUpEditAccount });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.Quantity), ColumnCaption = "Số lượng", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 8, IsNumeric = true, AllowEdit = true });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.Amount), ColumnCaption = "Số tiền", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 8, IsNumeric = true, AllowEdit = true });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.BudgetSourceId), ColumnCaption = "Nguồn vốn", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 9, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSource });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.BudgetChapterCode), ColumnCaption = "Chương", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 10, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetChapter });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.BudgetSubKindItemCode), ColumnCaption = "Khoản", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 11, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.BudgetSubItemCode), ColumnCaption = "Tiểu mục", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 12, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSubItem });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.BudgetItemCode), ColumnCaption = "Mục", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 13, RepositoryControl = _gridLookUpEditBudgetItem });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.MethodDistributeId), ColumnCaption = "Cấp phát", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 14, AllowEdit = true, RepositoryControl = _gridLookUpEditMethodTribute });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.CashWithDrawTypeId), ColumnCaption = "Nghiệp vụ", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 15, AllowEdit = true, RepositoryControl = _gridLookUpEditCashWithdrawType });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.BankId), ColumnVisible = true, ColumnWith = 250, ColumnCaption = "Tài khoản NH, KB", ColumnPosition = 16, RepositoryControl = _gridLookUpEditBank, AllowEdit = true });

                XtraColumnCollectionHelper<FAIncrementDecrementDetailModel>.ShowXtraColumnInGridView(gridColumnsCollection, grdDetailByInventoryItemView);

                // Tab thống kê
                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.FixedAssetId), ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1, AllowEdit = true, RepositoryControl = _gridLookUpEditFixedAsset });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.Description), ColumnCaption = "Diễn giải", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2, AllowEdit = true, });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.AccountingObjectId), ColumnCaption = "Đối tượng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 3, AllowEdit = true, RepositoryControl = _gridLookUpEditAccountingObject });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.ActivityId), ColumnCaption = "Hoạt động", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 4, AllowEdit = true, RepositoryControl = _gridLookUpEditActivity });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.ProjectId), ColumnCaption = "CTMT, dự án", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 5, AllowEdit = true, RepositoryControl = _gridLookUpEditProject });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.ListItemId), ColumnCaption = "Mã thống kê", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 6, AllowEdit = true, RepositoryControl = _gridLookUpEditListItemId });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.BudgetExpenseId), ColumnCaption = "Phí lệ phí", ColumnVisible = true, ColumnWith = 220, ColumnPosition = 6, AllowEdit = true, RepositoryControl = _gridLookUpBudgetExpense });
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FAIncrementDecrementDetailModel.SortOrderTemp), ColumnCaption = "", ColumnVisible = false, ColumnWith = 220, ColumnPosition = 6, AllowEdit = true});
                XtraColumnCollectionHelper<FAIncrementDecrementDetailModel>.ShowXtraColumnInGridView(gridColumnsCollection, grdAccountingView);
            }
        }

        /// <summary>
        /// Sets the fixed assets.
        /// </summary>
        /// <value>
        /// The fixed assets.
        /// </value>
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                if (value == null)
                    return;
                _listFixedAsset = value.ToList();

                _gridLookUpEditFixedAssetView = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridViewReponsitory();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FixedAssetModel.FixedAssetCode), ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FixedAssetModel.FixedAssetName), ColumnCaption = "Tên TSCĐ", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditFixedAsset = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFixedAssetView, value, nameof(FixedAssetModel.FixedAssetCode), nameof(FixedAssetModel.FixedAssetId), gridColumnsCollection);
                XtraColumnCollectionHelper<FixedAssetModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFixedAssetView);
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
                if (value == null)
                    return;

                _gridLookUpEditDepartmentView = XtraColumnCollectionHelper<DepartmentModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(DepartmentModel.DepartmentCode), ColumnCaption = "Mã phòng ban", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(DepartmentModel.DepartmentName), ColumnCaption = "Tên phòng ban", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditDepartment = XtraColumnCollectionHelper<DepartmentModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDepartmentView, value, nameof(DepartmentModel.DepartmentName), nameof(DepartmentModel.DepartmentId), gridColumnsCollection);
                XtraColumnCollectionHelper<DepartmentModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDepartmentView);
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
                if (value == null)
                    return;
                _listAccounts = value.ToList();
                this.AccountLists = _listAccounts;

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountModel.AccountNumber), ColumnCaption = "Mã tài khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountModel.AccountName), ColumnCaption = "Tên tài khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                // Sử dụng cho 3 tài khoản nợ, có và thuế
                // Tài khoản có                
                var creditAccounts = value.ToList().CreditAccounts((int)BaseRefTypeId, RefTypes.ToList());
                _gridLookUpEditAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                _gridLookUpEditAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountView, creditAccounts, nameof(AccountModel.AccountNumber), nameof(AccountModel.AccountNumber), gridColumnsCollection);

                XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountView);

                // Tài khoản nợ
                var debitAccounts = value.ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
                _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccounts, nameof(AccountModel.AccountNumber), nameof(AccountModel.AccountNumber), gridColumnsCollection);

                XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);

                // Tài khoản thuế
                var taxAccounts = value.ToList();
                _gridLookUpEditTaxAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                _gridLookUpEditTaxAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditTaxAccountView, taxAccounts, nameof(AccountModel.AccountNumber), nameof(AccountModel.AccountNumber), gridColumnsCollection);

                XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditTaxAccountView);
            }
        }

        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>
        /// The banks.
        /// </value>
        public IList<BankModel> Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BankModel.BankAccount), ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BankModel.BankName), ColumnCaption = "Tên NH, KB", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, nameof(BankModel.BankAccount), nameof(BankModel.BankId), gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        /// <summary>
        /// Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {
            // Cấp phát
            var methodDistribute = typeof(MethodDistribute).ToList();
            _gridLookUpEditMethodTributeView = XtraColumnCollectionHelper<StockModel>.CreateGridViewReponsitory();
            _gridLookUpEditMethodTribute = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditMethodTributeView, methodDistribute, nameof(KeyValuePair<int, string>.Value), nameof(KeyValuePair<int, string>.Key));
            _gridLookUpEditMethodTribute.PopupFormSize = new Size(268, 150);
            var gridColumnsCollection = new List<XtraColumn>();
            gridColumnsCollection.Add(new XtraColumn { ColumnName = "Value", ColumnCaption = "Cấp phát", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

            XtraColumnCollectionHelper<KeyValuePair<int, string>>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditMethodTributeView);

            // Mã thống kê
            var itemIds = new Dictionary<string, string> { { "Thue_KTTN", "Thuế khấu trừ tại nguồn" }, { "Thue_TNTX", "Thuế thu nhập thường xuyên" }, { "VT", "Nhận viện trợ bằng hiện vật" } };
            _gridLookUpEditListItemIdView = XtraColumnCollectionHelper<StockModel>.CreateGridViewReponsitory();
            gridColumnsCollection = new List<XtraColumn>();
            gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(KeyValuePair<string, string>.Key), ColumnCaption = "Mã thống kê", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
            gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(KeyValuePair<string, string>.Value), ColumnCaption = "Tên thống kê", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

            _gridLookUpEditListItemId = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditListItemIdView, itemIds.ToList(), nameof(KeyValuePair<string, string>.Value), nameof(KeyValuePair<string, string>.Key), gridColumnsCollection);
            XtraColumnCollectionHelper<KeyValuePair<string, string>>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditListItemIdView);
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
                if (value == null)
                    value = new List<BudgetSourceModel>();

                _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetSourceModel.BudgetSourceCode), ColumnCaption = "Mã nguồn", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetSourceModel.BudgetSourceName), ColumnCaption = "Tên nguồn", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, value, nameof(BudgetSourceModel.BudgetSourceCode), nameof(BudgetSourceModel.BudgetSourceId), gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
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
                if (value == null)
                    value = new List<BudgetChapterModel>();

                _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetChapterModel.BudgetChapterCode), ColumnCaption = "Mã chương", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetChapterModel.BudgetChapterName), ColumnCaption = "Tên chương", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, nameof(BudgetChapterModel.BudgetChapterCode), nameof(BudgetChapterModel.BudgetChapterCode), gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);
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
                if (value == null)
                    value = new List<BudgetKindItemModel>();

                value = value.Where(v => !v.IsParent).ToList();

                _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetKindItemModel.BudgetKindItemCode), ColumnCaption = "Mã khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetKindItemModel.BudgetKindItemName), ColumnCaption = "Tên khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, value, nameof(BudgetKindItemModel.BudgetKindItemCode), nameof(BudgetKindItemModel.BudgetKindItemCode), gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);
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
                if (value == null)
                    value = new List<BudgetItemModel>();
                _listBudgetItems = value.ToList();

                var budgetItemModels = value.Where(v => v.BudgetItemType == 2).ToList(); // éo biết = 2 và = 3 là gì (copy)
                var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3).ToList();

                // Tiểu mục
                _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetItemModel.BudgetItemCode), ColumnCaption = "Mã tiểu mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetItemModel.BudgetItemName), ColumnCaption = "Tên tiểu mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, budgetSubItemModels, nameof(BudgetItemModel.BudgetItemCode), nameof(BudgetItemModel.BudgetItemCode), gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);

                // Mục
                _gridLookUpEditBudgetItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetItemModel.BudgetItemCode), ColumnCaption = "Mã mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetItemModel.BudgetItemName), ColumnCaption = "Tên mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemView, budgetItemModels, nameof(BudgetItemModel.BudgetItemCode), nameof(BudgetItemModel.BudgetItemCode), gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetItemView);
            }
        }

        /// <summary>
        /// Sets the cash withdraw type models.
        /// </summary>
        /// <value>
        /// The cash withdraw type models.
        /// </value>
        public IList<CashWithdrawTypeModel> CashWithdrawTypeModels
        {
            set
            {
                if (value == null)
                    value = new List<CashWithdrawTypeModel>();

                _gridLookUpEditCashWithdrawTypeView = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridViewReponsitory();
                //_gridLookUpEditCashWithdrawType.PopupFormSize = new Size(268, 150);
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(CashWithdrawTypeModel.CashWithdrawTypeName), ColumnCaption = "Nghiệp vụ", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 1 });

                _gridLookUpEditCashWithdrawType = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCashWithdrawTypeView, value, nameof(CashWithdrawTypeModel.CashWithdrawTypeName), nameof(CashWithdrawTypeModel.CashWithdrawTypeId), gridColumnsCollection);
                XtraColumnCollectionHelper<CashWithdrawTypeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCashWithdrawTypeView);
            }
        }

        /// <summary>
        /// Hoạt động sự nghiệp
        /// </summary>
        /// <value>
        /// The activitys.
        /// </value>
        public IList<ActivityModel> Activitys
        {
            set
            {
                if (value == null)
                    value = new List<ActivityModel>();

                _gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                //_gridLookUpEditActivity.PopupFormSize = new Size(268, 150);
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(ActivityModel.ActivityName), ColumnCaption = "Hoạt động sự nghiệp", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, nameof(ActivityModel.ActivityName), nameof(ActivityModel.ActivityId), gridColumnsCollection);
                XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);
            }
        }

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>
        /// The projects.
        /// </value>
        public IList<ProjectModel> Projects
        {
            set
            {
                if (value == null)
                    value = new List<ProjectModel>();

                _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(ProjectModel.ProjectCode), ColumnCaption = "Mã CTMT", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(ProjectModel.ProjectName), ColumnCaption = "Tên CTMT", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, value, nameof(ProjectModel.ProjectName), nameof(ProjectModel.ProjectId), gridColumnsCollection);
                XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
            }
        }

        #region BudgetExpenses
        public IList<BudgetExpenseModel> BudgetExpenses
        {
            set
            {
                if (value == null)
                    value = new List<BudgetExpenseModel>();

                _gridLookUpEditBudgetExpenseView = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseCode", ColumnCaption = "Mã lệ phí", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseName", ColumnCaption = "Tên phí, lệ phí", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, "BudgetExpenseName", "BudgetExpenseId", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetExpenseModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetExpenseView);
            }
        }
        #endregion	
        #endregion

        #region EditValue Change
        protected override void GridPurchaseCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            CellValuechange(sender, e);
        }

        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            CellValuechange(sender, e);
        }

        protected override void GridAccountingDetailCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            CellValuechange(sender, e);
        }

        protected override void GridTaxCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            CellValuechange(sender, e);
        }

        private void CellValuechange(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            switch (e.Column.FieldName)
            {
                case nameof(FAIncrementDecrementDetailModel.FixedAssetId):
                    var item = _listFixedAsset?.FirstOrDefault(m => m.FixedAssetId.Equals(Convert.ToString(e.Value)));
                    if (item != null)
                    {
                        view.SetRowCellValue(e.RowHandle, nameof(FAIncrementDecrementDetailModel.Description), item.FixedAssetName);
                        view.SetRowCellValue(e.RowHandle, nameof(FAIncrementDecrementDetailModel.DepartmentId), item.DepartmentId);
                        if (!string.IsNullOrEmpty(item.OrgPriceAccount))
                            view.SetRowCellValue(e.RowHandle, nameof(FAIncrementDecrementDetailModel.DebitAccount), item.OrgPriceAccount);
                        view.SetRowCellValue(e.RowHandle, nameof(FAIncrementDecrementDetailModel.Amount), item.OrgPrice);

                        view.SetRowCellValue(e.RowHandle, nameof(FAIncrementDecrementDetailModel.BudgetSubItemCode), item.BudgetSubItemCode);
                    }
                    break;

                case nameof(FAIncrementDecrementDetailModel.Amount):
                    CalTotalAmount();
                    break;

                case nameof(FAIncrementDecrementDetailModel.BudgetSubItemCode):
                    var _item = _listBudgetItems?.FirstOrDefault(m => m.BudgetItemCode.Equals(Convert.ToString(e.Value)));
                    if (_item != null)
                    {
                        var itemParent = _listBudgetItems?.FirstOrDefault(m => m.BudgetItemId.Equals(_item.ParentId));
                        if (itemParent != null)
                            view.SetRowCellValue(e.RowHandle, nameof(FAIncrementDecrementDetailModel.BudgetItemCode), itemParent.BudgetItemCode);
                    }
                    break;
            }
        }

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            bindingSourceDetail.ResetBindings(false);
        }
        #endregion

        #region  Init new row
        protected override void InitDetailRowForAcountingDetailByInventoryItem(InitNewRowEventArgs e, GridView view)
        {
            InitNewRow(e, view);
        }

        protected override void InitDetailRow(InitNewRowEventArgs e, GridView view)
        {
            InitNewRow(e, view);
        }

        protected override void InitDetailRowForAcountingDetail(InitNewRowEventArgs e, GridView view)
        {
            InitNewRow(e, view);
        }

        protected override void InitDetailRowForAcountingDetailByTax(InitNewRowEventArgs e, GridView view)
        {
            InitNewRow(e, view);
        }

        private void InitNewRow(InitNewRowEventArgs e, GridView view)
        {
            if (view == null)
                return;
        }
        #endregion

        #region Save data
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            var _detail = FAIncrementDecrementDetails.ToList();

            if (_detail.Count <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_detail.Exists(m => string.IsNullOrEmpty(m.FixedAssetId)))
            {
                CommonText.ShowMessageWarning(CommonText.FixedAssetValid);
                return false;
            }

            if (_detail.Exists(m => string.IsNullOrEmpty(m.DebitAccount)))
            {
                CommonText.ShowMessageWarning(CommonText.DebitAccountValid);
                return false;
            }

            if (_detail.Exists(m => string.IsNullOrEmpty(m.CreditAccount)))
            {
                CommonText.ShowMessageWarning(CommonText.CreditAccountValid);
                return false;
            }


            return true;
        }

        protected override string SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = KeyValue;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = null;

            return _fAIncrementDecrementPresenter.Save();
        }

        protected override void DeleteVoucher()
        {
            _fAIncrementDecrementPresenter.Delete(KeyValue);
        }
        #endregion
    }
}