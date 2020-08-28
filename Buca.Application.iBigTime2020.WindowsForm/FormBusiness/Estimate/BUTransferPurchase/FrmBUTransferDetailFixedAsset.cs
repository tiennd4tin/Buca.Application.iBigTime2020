﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Data;
using BuCA.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    public partial class FrmBUTransferDetailFixedAsset : FrmXtraBaseVoucherDetail, IBUTransferView,
        IFixedAssetsView, IDepartmentsView, IAccountsView, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView,
        ICashWithdrawTypesView, IAccountingObjectsView, IActivitysView,
        IProjectsView, IBanksView, IBudgetExpensesView, IAccountingObjectCategoriesView
    {
        
        public string DebitAccountParallel { get; set; }
        public string CreditAccountParallel { get; set; }
        #region Variable
        /// <summary>
        /// Tài khoản nợ ngầm định
        /// </summary>
        AccountModel _defaultDebitAccount;

        /// <summary>
        /// Tài khoản có ngầm định
        /// </summary>
        AccountModel _defaultCreditAccount;

        /// <summary>
        /// Danh sách tài khoản
        /// </summary>
        List<AccountModel> _listAccounts;
        List<FixedAssetModel> _listFixedAsset;
        List<BudgetItemModel> _listBudgetItems;
        DateTime _minValueSql = new DateTime(1753, 1, 1);

        /// <summary>
        /// Dùng để ghi tăng tự động TSCĐ
        /// </summary>
        public List<BUTransferDetailFixedAssetlModel> ListSendSourceDetail;
        private List<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetKindItemModel> _budgetSubKindItemModels;
        public bool IsOpenFromFixedAssetDetail;
        public string _accountingObjectId;
        public string _journalMemo;
        #endregion

        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;
        private GridView _gridLookUpEditFixedAssetView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        private GridView _gridLookUpEditDepartmentView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditTaxRate;
        private GridView _gridLookUpEditTaxRateView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditMethodTribute;
        private GridView _gridLookUpEditMethodTributeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;
        private GridView _gridLookUpEditCashWithdrawTypeView;

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

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;
        private GridView _gridLookUpEditAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        private GridView _gridLookUpEditAccountingObjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditParallelAccount;
        private GridView _gridLookUpEditParalleAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;
        #endregion

        #region Presenter
        readonly FixedAssetsPresenter _fixedAssetsPresenter;
        readonly DepartmentsPresenter _departmentsPresenter;
        private readonly IModel _model;

        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;

        /// <summary>
        /// The b u plan withdraw presenter
        /// </summary>
        private readonly BUTransferPresenter _bUTransferPresenter;

        /// <summary>
        /// The banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        /// The budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        /// <summary>
        /// The fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;

        /// <summary>
        /// The cash withdraw types presenter
        /// </summary>
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;

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
        /// The cash withdraw type models
        /// </summary>
        private List<CashWithdrawTypeModel> _cashWithdrawTypeModels;

        /// <summary>
        /// The projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;

        /// <summary>
        /// The activitys presenter
        /// </summary>
        private readonly ActivitysPresenter _activitysPresenter;
        private readonly AccountingObjectCategoriesPresenter _accountingObjectCategoryPresenter;
        public List<SelectItemModel> Parallels { get; set; }
        #endregion

        public FrmBUTransferDetailFixedAsset()
        {
            InitializeComponent();
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
            _bUTransferPresenter = new BUTransferPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _accountingObjectCategoryPresenter = new AccountingObjectCategoriesPresenter(this);
            _model = new Model.Model();

            this.RefType = (int)BuCA.Enum.RefType.BUTransferFixedAsset;

            // Hiển thị các tab
            this.IsDisplayAccounting = true;
            this.IsDisplayAccountingDetail = true;
            this.IsDisplayInventoryItem = true;
            this.IsDisplayTax = true;

            // Lấy các mẫu in
            this.RefTypeUsingDisplayReport = BuCA.Enum.RefType.BUTransferFixedAsset;
        }

        protected override void InitControls()
        {
            grdMaster.Visible = false;
            grdAccountingParallel.DataSource = bindingSourceDetailParallel;
            tabAccounting.Text = @"Hạch toán";
            tabInventoryItem.Text = @"MLNS";
            tabMain.TabPages.Move(1, tabAccounting);

            //// Đổi tab thuế lên đứng thứ 2 và chung source với các tab khác
            grdTax.DataSource = bindingSourceDetail;
            //tabMain.TabPages.Move(2, tabTax);

            //// Đổi tên tab hàng hóa thành MLNS và đứng thứ 3
            //tabMain.TabPages.Move(3, tabInventoryItem);
            //tabInventoryItem.Text = "MLNS";

            //switch (ActionMode)
            //{
            //    case ActionModeVoucherEnum.AddNew:
            //        this.Text = "Thêm mới chứng từ mua TSCĐ bằng chuyển khoản";
            //        break;
            //    case ActionModeVoucherEnum.Edit:
            //        this.Text = "Sửa chứng từ mua TSCĐ bằng chuyển khoản";
            //        break;
            //}
        }

        protected override void SetEnableGroupBox(bool isEnable)
        {
            EnableControlsInGroup(groupControl1, isEnable);
            EnableControlsInGroup(groupControl2, isEnable);
            lookUpEditAccountingObject.Enabled = isEnable;
            grdViewAccountingParallel.OptionsBehavior.Editable = isEnable;
            grdViewAccountingParallel.OptionsBehavior.ReadOnly = !isEnable;
            grdViewAccountingParallel.FocusRectStyle = DrawFocusRectStyle.None;
            grdViewAccountingParallel.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdViewAccountingParallel.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
        }

        protected override void InitData()
        {
            InitRepositoryControlData();

            this.BaseRefTypeId = BuCA.Enum.RefType.BUTransferFixedAsset;
            this.RefType = (int) BuCA.Enum.RefType.BUTransferFixedAsset;

            _accountsPresenter.DisplayActive();
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _accountingObjectsPresenter.DisplayActive(true);
            _activitysPresenter.DisplayActive(true);
            _fixedAssetsPresenter.DisplayByActive(true);
            _projectsPresenter.DisplayActive();
            _banksPresenter.DisplayActive(true);
            _budgetExpensesPresenter.DisplayActive();
            _departmentsPresenter.DisplayActive();
            _accountingObjectCategoryPresenter.Display();

            if (MasterBindingSource != null)
            if (MasterBindingSource.Current != null)
                    KeyValue = ((BUTransferModel) MasterBindingSource.Current).RefId;

            _bUTransferPresenter.Display(KeyValue);

            this.BaseRefTypeId = BuCA.Enum.RefType.BUTransferFixedAsset;
            this.RefType = (int) BuCA.Enum.RefType.BUTransferFixedAsset;
            AutoProjectId = TargetProgramId;
            AutoBankId = BankInfoId;
            AutoAccountingObjectId = AccountingObjectId;

            if (ActionMode == ActionModeVoucherEnum.LinkVoucher)
            {
                AccountingObjectId = _accountingObjectId;
                JournalMemo = _journalMemo;
            }
        }

        private void InitRepositoryControlData()
        {
            // Cấp phát
            var methodDistribute = typeof(MethodDistribute).ToList();
            _gridLookUpEditMethodTributeView = XtraColumnCollectionHelper<StockModel>.CreateGridViewReponsitory();
            _gridLookUpEditMethodTribute = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditMethodTributeView, methodDistribute, "Value", "Key");
            _gridLookUpEditMethodTribute.PopupFormSize = new Size(268, 150);
            var gridColumnsCollection = new List<XtraColumn>();
            gridColumnsCollection.Add(new XtraColumn { ColumnName = "Value", ColumnCaption = "Cấp phát", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

            XtraColumnCollectionHelper<KeyValuePair<int, string>>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditMethodTributeView);

            // Thuế suất
            var vatRates = new Dictionary<int, string> { { 0, "0%" }, { 5, "10%" }, { 10, "15%" }, { -1, "KCT" } };  // Không chịu thế = -1 tương đương thuế suất = 0
            _gridLookUpEditTaxRateView = XtraColumnCollectionHelper<StockModel>.CreateGridViewReponsitory();
            _gridLookUpEditTaxRate = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditTaxRateView, vatRates.ToList(), "Value", "Key");
            _gridLookUpEditTaxRate.PopupFormSize = new Size(180, 150);
            gridColumnsCollection = new List<XtraColumn>();
            gridColumnsCollection.Add(new XtraColumn { ColumnName = "Value", ColumnCaption = "Thuế suất", ColumnVisible = true, ColumnWith = 180, ColumnPosition = 1 });

            XtraColumnCollectionHelper<KeyValuePair<int, string>>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditTaxRateView);
        }

        #region IView Detail
        /// <summary>
        /// Danh sách tài sản cố định
        /// </summary>
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                if (value == null)
                    return;
                _listFixedAsset = value.ToList();

                _gridLookUpEditFixedAssetView = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridViewReponsitory();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCode", ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetName", ColumnCaption = "Tên TSCĐ", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditFixedAsset = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFixedAssetView, value, "FixedAssetCode", "FixedAssetId", gridColumnsCollection);
                XtraColumnCollectionHelper<FixedAssetModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFixedAssetView);
            }
        }

        /// <summary>
        /// Danh sách phòng ban
        /// </summary>
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
                XtraColumnCollectionHelper<DepartmentModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDepartmentView);
            }
        }

        /// <summary>
        /// Danh sách tài khoản nợ, có, đồng thời
        /// </summary>
        public IList<AccountModel> Accounts
        {
            set
            {
                if (value == null)
                    return;
                _listAccounts = value.ToList();

                // Lấy tài khoản mặc định
                _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(_listAccounts, (int)BaseRefTypeId, RefTypes.ToList());
                _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(_listAccounts, (int)BaseRefTypeId, RefTypes.ToList());

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "Mã tài khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                // Sử dụng cho 3 tài khoản nợ, có và đồng thời
                // Tài khoản có                
                var creditAccounts = value.ToList().CreditAccounts((int)BaseRefTypeId, RefTypes.ToList());
                _gridLookUpEditAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                _gridLookUpEditAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountView, creditAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);

                XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountView);

                // Tài khoản nợ
                var debitAccounts = value.ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
                _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);

                XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);

                // Tài khoản đồng thời
                var parallelAccounts = value.ToList().ParallelAccounts();
                _gridLookUpEditParalleAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                _gridLookUpEditParallelAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditParalleAccountView, debitAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);

                XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditParalleAccountView);
            }
        }

        /// <summary>
        /// Danh sách nguồn
        /// </summary>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                if (value == null)
                    return;

                _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, value, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
            }
        }

        /// <summary>
        /// Danh sách chương
        /// </summary>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                if (value == null)
                    return;

                _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Mã chương", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterName", ColumnCaption = "Tên chương", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);
            }
        }

        /// <summary>
        /// Danh sách khoản, lấy từ dnah mục loại khoản
        /// </summary>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                if (value == null)
                    return;
                _budgetSubKindItemModels = value.ToList();
                value = value.Where(v => !v.IsParent).ToList();

                _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnCaption = "Mã khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemName", ColumnCaption = "Tên khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, value, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);
            }
        }

        /// <summary>
        /// Danh sách tiểu mục + mục
        /// </summary>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                if (value == null)
                    return;
                _listBudgetItems = value.ToList();

                var budgetItemModels = value.Where(v => v.BudgetItemType == 2).ToList(); // éo biết = 2 và = 3 là gì (copy)
                var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3).ToList();

                // Tiểu mục
                _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã tiểu mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên tiểu mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, budgetSubItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);

                // Mục
                _gridLookUpEditBudgetItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemView, budgetItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetItemView);
            }
        }

        /// <summary>
        /// Danh sách nghiệp vụ
        /// </summary>
        public IList<CashWithdrawTypeModel> CashWithdrawTypeModels
        {
            set
            {
                if (value == null)
                    return;

                _gridLookUpEditCashWithdrawTypeView = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridViewReponsitory();
                //_gridLookUpEditCashWithdrawType.PopupFormSize = new Size(268, 150);
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawTypeName", ColumnCaption = "Nghiệp vụ", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 1 });

                _gridLookUpEditCashWithdrawType = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCashWithdrawTypeView, value, "CashWithdrawTypeName", "CashWithdrawTypeId", gridColumnsCollection);
                XtraColumnCollectionHelper<CashWithdrawTypeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCashWithdrawTypeView);
            }
        }

        /// <summary>
        /// Công việc
        /// </summary>
        public IList<ActivityModel> Activitys
        {
            set
            {
                if (value == null)
                    return;

                _gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                //_gridLookUpEditActivity.PopupFormSize = new Size(268, 150);
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityName", ColumnCaption = "Công việc", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, "ActivityName", "ActivityId", gridColumnsCollection);
                XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);
            }
        }

        /// <summary>
        /// Đối tượng
        /// </summary>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                var accountingObjects = new List<AccountingObjectModel>();
                if (!string.IsNullOrEmpty(AccountingObjectCategoryId))
                {
                    if (AccountingObjectCategoryId == "00000000-0000-0000-0000-000000000000")
                    {
                        accountingObjects = value.Where(a => a.IsEmployee == true && string.IsNullOrEmpty(a.AccountingObjectCategoryId)).OrderBy(c => c.AccountingObjectCode).ToList();
                    }
                    else
                        accountingObjects = value.Where(a => a.AccountingObjectCategoryId == AccountingObjectCategoryId).OrderBy(c => c.AccountingObjectCode).ToList();
                }
                else
                    accountingObjects = value.OrderBy(c => c.AccountingObjectCode).ToList();

                if (accountingObjects == null)
                    return;

                _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã đơn vị", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectName", ColumnCaption = "Tên đơn vị", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, value, "AccountingObjectCode", "AccountingObjectId", gridColumnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountingObjectView);

                lookUpEditAccountingObject.Properties.DataSource = accountingObjects;
                lookUpEditAccountingObject.Properties.PopulateColumns();
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInLookUpEdit(gridColumnsCollection, lookUpEditAccountingObject);
            }
        }

        /// <summary>
        /// Danh sách detail
        /// </summary>
        public IList<BUTransferDetailFixedAssetlModel> BUTransferDetailFixedAssets
        {
            get
            {
                grdDetailByInventoryItem.RefreshDataSource();
                var _source = bindingSourceDetail.DataSource;
                List<BUTransferDetailFixedAssetlModel> _listSource = new List<BUTransferDetailFixedAssetlModel>();
                if (_source != null)
                {
                    _listSource = (List<BUTransferDetailFixedAssetlModel>)bindingSourceDetail.DataSource;
                    TotalAmount = _listSource.Sum(m => m.Amount);
                    TotalAmountOC = TotalAmount;
                    TotalTaxAmount = _listSource.Sum(m => m.TaxAmount);
                    for (int i = 0; i < _listSource.Count; i++)
                        _listSource[i].SortOrder = i;
                }
                //if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                //{
                //    for (var i = 0; i < grdAccountingView.RowCount; i++)
                //    {
                //        var rowVoucher = (BUTransferDetailFixedAssetlModel) grdAccountingView.GetRow(i);
                //        if (rowVoucher != null)
                //        {
                //            var item = new BUTransferDetailFixedAssetlModel
                //            {
                //                OrgRefDate = rowVoucher.OrgRefDate,
                //            };
                //            if (item.OrgRefDate.Equals(null))
                //            {
                //                grdAccountingView.SetRowCellValue(i, nameof(BUTransferDetailFixedAssetlModel.OrgRefDate), "");
                //            }
                //        }
                //    }
                //}
                return _listSource;
            }
            set
            {
                // Lấy dữ liệu ghi tăng TSCĐ tự động
                if (IsOpenFromFixedAssetDetail)
                {
                    value = ListSendSourceDetail;
                    ListSendSourceDetail = null;
                    IsOpenFromFixedAssetDetail = false;
                }

                if (value == null)
                    value = new List<BUTransferDetailFixedAssetlModel>();

                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList();
                grdAccountingView.PopulateColumns(value);
                grdDetailByInventoryItemView.PopulateColumns(value);
                grdAccountingDetailView.PopulateColumns(value);

                // Tab hạch toán
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "OrgRefNo", ColumnCaption = "Số chứng từ gốc", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1, AllowEdit = true });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "OrgRefDate", ColumnCaption = "Ngày chứng từ gốc", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 2, AllowEdit = true, Alignment = HorzAlignment.Center, IsDateTime = true });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 3, AllowEdit = true, RepositoryControl = _gridLookUpEditFixedAsset });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnVisible = true, AllowEdit = true, ColumnWith = 250, ColumnPosition = 4 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 5, RepositoryControl = _gridLookUpEditDepartment });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAccount", ColumnCaption = "TK nợ", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 6, AllowEdit = true, RepositoryControl = _gridLookUpEditDebitAccount });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAccount", ColumnCaption = "TK có", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 7, AllowEdit = true, RepositoryControl = _gridLookUpEditAccount });
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnCaption = "ĐVT", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 6, AllowEdit = true, });
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnCaption = "Số lượng", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 7, AllowEdit = true, ColumnType = UnboundColumnType.Decimal });
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnCaption = "Đơn giá", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 8, AllowEdit = true, ColumnType = UnboundColumnType.Decimal });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Số tiền", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 9, IsNumeric = true, AllowEdit =  true });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnCaption = "Tài khoản NH,KB", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 10, AllowEdit = true, RepositoryControl = _gridLookUpEditBank });

                XtraColumnCollectionHelper<BUTransferDetailFixedAssetlModel>.ShowXtraColumnInGridView(gridColumnsCollection, grdAccountingView);

                // Tab Thuế
                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1, AllowEdit = true, RepositoryControl = _gridLookUpEditFixedAsset });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", AllowEdit = true, ColumnVisible = true, ColumnWith = 250, ColumnPosition = 4 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaxRate", ColumnCaption = "Thuế suất", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 10, AllowEdit = true, RepositoryControl = _gridLookUpEditTaxRate });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaxAmount", ColumnCaption = "Tiền thuế", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 11, AllowEdit = true, IsNumeric = true });

                XtraColumnCollectionHelper<BUTransferDetailFixedAssetlModel>.ShowXtraColumnInGridView(gridColumnsCollection, grdTaxView);

                // Tab MLNS
                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1, AllowEdit = true, RepositoryControl = _gridLookUpEditFixedAsset });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnVisible = true, AllowEdit = true, ColumnWith = 250, ColumnPosition = 2 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnCaption = "Nguồn vốn", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 3, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSource });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 4, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetChapter });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnCaption = "Loại", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 5, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 6, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSubItem });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 7, RepositoryControl = _gridLookUpEditBudgetItem });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnCaption = "Cấp phát", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 8, AllowEdit = true, RepositoryControl = _gridLookUpEditMethodTribute });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUTransferDetailFixedAssetlModel.CashWithdrawTypeId), ColumnCaption = "Nghiệp vụ", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 9, AllowEdit = true, RepositoryControl = _gridLookUpEditCashWithdrawType });

                XtraColumnCollectionHelper<BUTransferDetailFixedAssetlModel>.ShowXtraColumnInGridView(gridColumnsCollection, grdDetailByInventoryItemView);

                // Tab thống kê
                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1, AllowEdit = true, RepositoryControl = _gridLookUpEditFixedAsset });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnVisible = true, AllowEdit = true, ColumnWith = 250, ColumnPosition = 2 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnCaption = "Hoạt động SN", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 3, AllowEdit = true, RepositoryControl = _gridLookUpEditActivity });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 4, AllowEdit = true, RepositoryControl = _gridLookUpEditAccountingObject });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "CTMT, dự án", ColumnVisible = true, ColumnWith = 220, ColumnPosition = 5, AllowEdit = true, RepositoryControl = _gridLookUpEditProject });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseId", ColumnCaption = "Phí lệ phí", ColumnVisible = true, ColumnWith = 220, ColumnPosition = 6, AllowEdit = true, RepositoryControl = _gridLookUpBudgetExpense });

                XtraColumnCollectionHelper<BUTransferDetailFixedAssetlModel>.ShowXtraColumnInGridView(gridColumnsCollection, grdAccountingDetailView);
            }
        }

        /// <summary>
        /// Hạch toán đồng thời
        /// </summary>
        public IList<BUTransferDetailParallelModel> BuTransferDetailParallel
        {
            get
            {
                var _source = bindingSourceDetailParallel.DataSource;
                List<BUTransferDetailParallelModel> _listSource = new List<BUTransferDetailParallelModel>();
                if (_source != null)
                {
                    _listSource = (List<BUTransferDetailParallelModel>)bindingSourceDetailParallel.DataSource;
                    for (int i = 0; i < _listSource.Count; i++)
                    {
                        _listSource[i].SortOrder = i;
                        _listSource[i].DebitAccount = DebitAccountParallel;
                        _listSource[i].DebitAccount = CreditAccountParallel;
                    }
                        
                }
                return _listSource;
            }
            set
            {
                if (value == null)
                    value = new List<BUTransferDetailParallelModel>();

                bindingSourceDetailParallel.DataSource = value.OrderBy(c => c.SortOrder).ToList();
                grdViewAccountingParallel.PopulateColumns(value);

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnVisible = true, ColumnWith = 300, ColumnPosition = 1, AllowEdit = true });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAccount", ColumnCaption = "TK Nợ", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 2, AllowEdit = true, RepositoryControl = _gridLookUpEditParallelAccount });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAccount", ColumnCaption = "TK Có", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 3, AllowEdit = true, RepositoryControl = _gridLookUpEditParallelAccount });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Số tiền", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 4, AllowEdit = true, IsNumeric = true });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Số tiền quy đổi", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 5, IsNumeric = true });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnCaption = "Nguồn vốn", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 6, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSource });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 7, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetChapter });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 8, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 9, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSubItem });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 10, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetItem });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnCaption = "Cấp phát", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 11, AllowEdit = true, RepositoryControl = _gridLookUpEditMethodTribute });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUTransferDetailParallelModel.CashWithdrawTypeId), ColumnCaption = "Nghiệp vụ", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 12, AllowEdit = true, RepositoryControl = _gridLookUpEditCashWithdrawType });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnCaption = "Hoạt động SN", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 13, AllowEdit = true, RepositoryControl = _gridLookUpEditActivity });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 14, AllowEdit = true, RepositoryControl = _gridLookUpEditAccountingObject });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "CTMT, dự án", ColumnVisible = true, ColumnWith = 220, ColumnPosition = 15, AllowEdit = true, RepositoryControl = _gridLookUpEditProject });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnCaption = "Tài khoản NH,KB", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 16, AllowEdit = true, RepositoryControl = _gridLookUpEditBank });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseId", ColumnCaption = "Phí, lệ phí", ColumnVisible = true, ColumnWith = 220, ColumnPosition = 17, AllowEdit = true, RepositoryControl = _gridLookUpBudgetExpense });

                XtraColumnCollectionHelper<BUTransferDetailParallelModel>.ShowXtraColumnInGridView(gridColumnsCollection, grdViewAccountingParallel);
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

        #region IView Master  IBUTransferView
        public string BUPlanWithdrawRefId { get; set; }
        public bool Approved { get; set; }
        public string RefId { get; set; }

        public int RefType
        {
            get;
            set;
        }

        public DateTime RefDate
        {
            get { return dtRefDate.EditValue == null ? DateTime.Now : (DateTime)dtRefDate.EditValue; }
            set { dtRefDate.EditValue = value; }
        }

        public DateTime PostedDate
        {
            get { return dtPostDate.EditValue == null ? DateTime.Now : (DateTime)dtPostDate.EditValue; }
            set { dtPostDate.EditValue = value; }
        }

        public string RefNo
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.Text = value; }
        }

        public string CurrencyCode
        {
            get { return gridViewMaster.GetRowCellValue(0, "CurrencyCode") == null ? GlobalVariable.MainCurrencyId : gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString(); }
            set { gridViewMaster.SetRowCellValue(0, "CurrencyCode", value ?? GlobalVariable.MainCurrencyId); }
        }

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

        public string ParalellRefNo
        {
            get { return txtBUCommitmentRequest.Text; }
            set { txtBUCommitmentRequest.Text = value; }
        }

        public string TargetProgramId
        {
            get { return cboTargetProgramId.EditValue == null ? null : cboTargetProgramId.EditValue.ToString(); }
            set
            {
                cboTargetProgramId.EditValue = value;
                if (cboTargetProgramId.EditValue != null)
                {
                    var targetProgramName = (string)cboTargetProgramId.GetColumnValue("ProjectName");
                    txtTargetProgramName.Text = targetProgramName;
                }
            }
        }

        public string AccountingObjectId
        {
            get { return lookUpEditAccountingObject.EditValue == null ? null : lookUpEditAccountingObject.EditValue.ToString(); }
            set
            {
                lookUpEditAccountingObject.EditValue = value;
                if (lookUpEditAccountingObject.EditValue != null)
                {
                    var accountingObject = (string)lookUpEditAccountingObject.GetColumnValue("AccountingObjectName");
                    txtAccountingObjectName.Text = accountingObject;
                }
            }
        }

        public string JournalMemo
        {
            get { return txtDocumentIncluded.Text; }
            set { txtDocumentIncluded.Text = value; }
        }

        public decimal TotalAmount { get; set; }

        public decimal TotalAmountOC { get; set; }

        public bool Posted { get; set; }

        public string BUCommitmentRequestId { get; set; }

        public string BankInfoId
        {
            get { return cboBankPay.EditValue == null ? null : cboBankPay.EditValue.ToString(); }
            set
            {
                cboBankPay.EditValue = value;
                if (cboBankPay.EditValue != null)
                {
                    var address = (string)cboBankPay.GetColumnValue("BankName");
                }
            }
        }

        public string AccountingObjectName
        {
            get { return txtAccountingObjectName.Text; }
            set { txtAccountingObjectName.Text = value; }
        }

        public string AccountingObjectAddress
        {
            get { return txtAccountingObjectAddress.Text; }
            set { txtAccountingObjectAddress.Text = value; }
        }

        public string AccountingObjectBankAccount
        {
            get { return txtAccountingObjectBankAccount.Text; }
            set { txtAccountingObjectBankAccount.Text = value; }
        }

        public string AccountingObjectBankName
        {
            get { return txtAccountingObjectBankName.Text; }
            set { txtAccountingObjectBankName.Text = value; }
        }

        public string DocumentIncluded { get; set; }

        public string InwardStockRefNo { get; set; }

        public DateTime? WithdrawRefDate
        {
            get { return dateWithdrawRefDate.EditValue == null ? _minValueSql : (DateTime)dateWithdrawRefDate.EditValue; }
            set { dateWithdrawRefDate.EditValue = value.Equals(_minValueSql) ? null : value; }
        }

        public string WithdrawRefNo
        {
            get { return txtWithdrawRefNo.Text; }
            set { txtWithdrawRefNo.Text = value; }
        }

        /// <summary>
        /// Số chứng từ ghi tăng
        /// </summary>
        public string IncrementRefNo
        {
            get { return txtIncrementRefNo.Text; }
            set { txtIncrementRefNo.Text = value; }
        }

        public decimal TotalTaxAmount { get; set; }

        public decimal TotalFreightAmount { get; set; }

        public decimal TotalInwardAmount { get; set; }

        public int? PostVersion { get; set; }

        public int? EditVersion { get; set; }

        public int? RefOrder { get; set; }

        public string RelationRefId { get; set; }

        public decimal TotalFixedAssetAmount { get; set; }

        public IList<BUTransferDetailModel> BUTransferDetails { get; set; }
        public IList<BUTransferDetailPurchaselModel> BUTransferDetailPurchases { get; set; }

        /// <summary>
        /// Chương trình mục tiêu
        /// </summary>
        public IList<ProjectModel> Projects
        {
            set
            {
                if (value == null)
                    value = new List<ProjectModel>();

                cboTargetProgramId.Properties.DataSource = value;
                cboTargetProgramId.Properties.PopulateColumns();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã CTMT, dự án", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectName", ColumnCaption = "Tên CTMT, dự án", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });

                XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInLookUpEdit(gridColumnsCollection, cboTargetProgramId);
                _gridLookUpEditProjectView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditProject = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, value, "ProjectName", "ProjectId");

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã CTMT, dự án", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectName", ColumnCaption = "Tên CTMT, dự án", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });

                XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
            }
        }

        /// <summary>
        /// Danh sách ngân hàng
        /// </summary>
        public IList<BankModel> Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();

                cboBankPay.Properties.DataSource = value;
                cboBankPay.Properties.PopulateColumns();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInLookUpEdit(gridColumnsCollection, cboBankPay);

                cboBankPay.Properties.DisplayMember = "BankAccount";
                cboBankPay.Properties.ValueMember = "BankId";
                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
                //Filter cho gridview
                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }
        #endregion

        #region overrides
        protected override void ReloadParallelGrid()
        {
            _bUTransferPresenter.Display(KeyValue);
        }

        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");

            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show("Bạn chưa nhập số chứng từ", detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

            if (PostedDate.Equals(_minValueSql))
            {
                XtraMessageBox.Show("Bạn chưa nhập ngày hạch toán", detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtPostDate.Focus();
                return false;
            }

            if (RefDate.Equals(_minValueSql))
            {
                XtraMessageBox.Show("Bạn chưa nhập ngày chứng từ", detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtRefDate.Focus();
                return false;
            }

            var bUTransferDetailPurchases = BUTransferDetailFixedAssets.ToList();
            if (bUTransferDetailPurchases.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (bUTransferDetailPurchases.Exists(m => string.IsNullOrEmpty(m.FixedAssetId)))
            {
                XtraMessageBox.Show("Bạn chưa chọn tài sản", detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (bUTransferDetailPurchases.Exists(m => string.IsNullOrEmpty(m.DepartmentId)))
            {
                XtraMessageBox.Show("Bạn chưa chọn phòng ban", detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (bUTransferDetailPurchases.Exists(m => string.IsNullOrEmpty(m.DebitAccount)))
            {
                XtraMessageBox.Show("Bạn chưa chọn TK nợ", detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (bUTransferDetailPurchases.Exists(m => string.IsNullOrEmpty(m.CreditAccount)))
            {
                XtraMessageBox.Show("Bạn chưa chọn TK có", detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //foreach (var item in bUTransferDetailPurchases)
            //{
            //    var debitAccount = _listAccounts.FirstOrDefault(c => c.AccountNumber.Equals(item.DebitAccount));
            //    if (debitAccount == null)
            //    {
            //        XtraMessageBox.Show("TK nợ không tồn tại", detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //    else
            //    {
            //        var isError = debitAccount.ValidDetailBy(item.BudgetSourceId,
            //            item.BudgetChapterCode, null,
            //            item.BudgetItemCode, item.BudgetSubItemCode,
            //            item.MethodDistributeId,
            //            item.AccountingObjectId, item.ActivityId,
            //            null, null, item.InventoryItemId,
            //            null, null);
            //        if (!isError)
            //            return false;
            //    }

            //    var creditAccount = _listAccounts.FirstOrDefault(c => c.AccountNumber.Equals(item.CreditAccount));
            //    if (creditAccount == null)
            //    {
            //        XtraMessageBox.Show("TK có không tồn tại", detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //    else
            //    {
            //        var isError = creditAccount.ValidDetailBy(item.BudgetSourceId,
            //            item.BudgetChapterCode, null,
            //            item.BudgetItemCode, item.BudgetSubItemCode,
            //            item.MethodDistributeId,
            //            item.AccountingObjectId, item.ActivityId,
            //            null, null, item.InventoryItemId,
            //            null, null);
            //        if (!isError)
            //            return false;
            //    }
            //}

            return true;
        }

        protected override void DeleteVoucher()
        {
            new BUTransferPresenter(null).Delete(KeyValue);
        }

        protected override string SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = KeyValue;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = null;
            var result = new DialogResult();
            if (BuTransferDetailParallel.Count > 0)
            {
                result = XtraMessageBox.Show("Bạn có muốn cập nhật lại định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                result = XtraMessageBox.Show("Bạn có muốn sinh tự động định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            
            return result == DialogResult.OK ? _bUTransferPresenter.Save(true) : _bUTransferPresenter.Save(false);
        }

        protected override void GridViewMasterCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            // Overide hàm này để không nhảy số tiền về 0 khi xóa dòng
        }
        #endregion

        #region Control edit value changed
        private void cboTargetProgramId_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTargetProgramId.EditValue == null)
                return;
            var projectName = (string)cboTargetProgramId.GetColumnValue("ProjectName");

            txtTargetProgramName.Text = projectName;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {

                AutoProjectId = TargetProgramId;
                SetDetailFromMaster(grdAccountingView, 3, AccountingObjectId, BankInfoId, TargetProgramId);
            }
        }

        private void cboBankPay_EditValueChanged(object sender, EventArgs e)
        {
            if (cboBankPay.EditValue == null)
                return;
            var bankName = (string)cboBankPay.GetColumnValue("BankName");
            txtBankPayName.Text = bankName;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoBankId = BankInfoId;
                SetDetailFromMaster(grdAccountingView, 2, AccountingObjectId, BankInfoId, TargetProgramId);
            }
        }

        private void lookUpEditAccountingObject_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditAccountingObject.EditValue == null)
                return;
            var accountingObjectName = (string)lookUpEditAccountingObject.GetColumnValue("AccountingObjectName");
            var accountingObjectAddress = (string)lookUpEditAccountingObject.GetColumnValue("Address");
            var bankAccount = (string)lookUpEditAccountingObject.GetColumnValue("BankAccount");
            var bankName = (string)lookUpEditAccountingObject.GetColumnValue("BankName");

            txtAccountingObjectName.Text = accountingObjectName;
            txtAccountingObjectAddress.Text = accountingObjectAddress;
            txtAccountingObjectBankAccount.Text = bankAccount;
            txtAccountingObjectBankName.Text = bankName;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoAccountingObjectId = AccountingObjectId;
                SetDetailFromMaster(grdAccountingView, 1, AccountingObjectId, BankInfoId, TargetProgramId);
            }
        }

        /// <summary>
        /// Tab hạch toán
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            switch (e.Column.FieldName)
            {
                case "FixedAssetId":
                    var item = _listFixedAsset?.FirstOrDefault(m => m.FixedAssetId.Equals(Convert.ToString(e.Value)));
                    if (item != null)
                    {
                        view.SetRowCellValue(e.RowHandle, "Description", item.FixedAssetName);
                        view.SetRowCellValue(e.RowHandle, "DepartmentId", item.DepartmentId);
                        view.SetRowCellValue(e.RowHandle, "DebitAccount", string.IsNullOrEmpty(item.OrgPriceAccount) ? _defaultDebitAccount.AccountNumber : item.OrgPriceAccount);
                        view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
                        view.SetRowCellValue(e.RowHandle, "Amount", item.OrgPrice);
                        view.SetRowCellValue(e.RowHandle, "TaxAmount", item.OrgPrice);
                        if (!string.IsNullOrEmpty(item.BudgetChapterCode))
                            view.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailFixedAssetlModel.BudgetChapterCode), item.BudgetChapterCode);
                        if (!string.IsNullOrEmpty(item.BudgetSubKindItemCode))
                            view.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailFixedAssetlModel.BudgetSubKindItemCode), item.BudgetSubKindItemCode);
                        if (!string.IsNullOrEmpty(item.BudgetSubItemCode))
                            view.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailFixedAssetlModel.BudgetSubItemCode), item.BudgetSubItemCode);
                        if (!string.IsNullOrEmpty(item.BudgetItemCode))
                            view.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailFixedAssetlModel.BudgetItemCode), item.BudgetItemCode);
                       // bindingSourceDetail.ResetBindings(false);
                    }
                    break;
            }
        }

        /// <summary>
        /// Tab thuế
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void GridTaxCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            switch (e.Column.FieldName)
            {
                case "TaxRate":
                    var amount = grdAccountingView.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 : (decimal)grdAccountingView.GetRowCellValue(e.RowHandle, "Amount");
                    var taxRate = Convert.ToInt32(e.Value ?? 0);
                    taxRate = taxRate < 0 ? 0 : taxRate;
                    view.SetRowCellValue(e.RowHandle, "TaxAmount", amount + amount * taxRate / 100);
                    break;
            }
        }

        /// <summary>
        /// Tab hàng tiền - MLNS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void GridPurchaseCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            switch (e.Column.FieldName)
            {
                case "BudgetSubItemCode":
                    var item = _listBudgetItems?.FirstOrDefault(m => m.BudgetItemCode.Equals(Convert.ToString(e.Value)));
                    if (item != null)
                    {
                        var itemParent = _listBudgetItems?.FirstOrDefault(m => m.BudgetItemId.Equals(item.ParentId));
                        if (itemParent != null)
                        {
                            view.SetRowCellValue(e.RowHandle, "BudgetItemCode", itemParent.BudgetItemCode);
                        }
                    }
                    break;

                case "BudgetSubKindItemCode":
                        var budgetSubKindItemCode = _budgetSubKindItemModels?.FirstOrDefault(m => m.BudgetKindItemCode.Equals(Convert.ToString(e.Value)));
                    if (budgetSubKindItemCode != null)
                    {
                        var itemParent = _budgetSubKindItemModels?.FirstOrDefault(m => m.BudgetKindItemId.Equals(budgetSubKindItemCode.ParentId));
                        if (itemParent != null)
                        {
                            view.SetRowCellValue(e.RowHandle, "BudgetKindItemCode", itemParent.BudgetKindItemCode);
                        }
                    }
                    break;
            }
        }
        #endregion

        #region Init new row
        /// <summary>
        /// Tab hạch toán
        /// </summary>
        /// <param name="e"></param>
        /// <param name="view"></param>
        protected override void InitDetailRow(InitNewRowEventArgs e, GridView view)
        {
            if (_defaultDebitAccount != null)
                view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
            if (_defaultCreditAccount != null)
                view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
            InitNewRow(e, view);
        }

        /// <summary>
        /// Tab thống kê
        /// </summary>
        /// <param name="e"></param>
        /// <param name="view"></param>
        protected override void InitDetailRowForAcountingDetail(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                if (_defaultDebitAccount != null)
                    view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
                if (_defaultCreditAccount != null)
                    view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
                InitNewRow(e, view);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public IList<AccountingObjectCategoryModel> AccountingObjectCategories
        {
            set
            {
                value.Add(
                    new AccountingObjectCategoryModel { AccountingObjectCategoryCode = "NV", AccountingObjectCategoryName = "Nhân Viên", AccountingObjectCategoryId = "00000000-0000-0000-0000-000000000000", IsActive = true, IsSystem = false }
                    );

                lkAccountObjectCategory.Properties.DataSource = value;
                lkAccountObjectCategory.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCategoryCode",
                        ColumnCaption = "Mã loại đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCategoryName",
                        ColumnCaption = "Tên loại đối tượng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                new XtraColumn { ColumnName = "AccountingObjectCategoryId", ColumnVisible = false },
                new XtraColumn { ColumnName = "AccountingObjectCode", ColumnVisible = false },
                new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false },
                new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false }
                };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lkAccountObjectCategory.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lkAccountObjectCategory.Properties.SortColumnIndex = column.ColumnPosition;
                        lkAccountObjectCategory.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        lkAccountObjectCategory.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                lkAccountObjectCategory.Properties.DisplayMember = "AccountingObjectCategoryCode";
                lkAccountObjectCategory.Properties.ValueMember = "AccountingObjectCategoryId";


            }
        }
        #endregion

        #region Event
        /// <summary>
        /// Handles the ButtonClick event of the lookUpEditAccountingObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void lookUpEditAccountingObject_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                if (!lkAccountObjectCategory.ItemIndex.Equals(-1))
                {
                    if (lkAccountObjectCategory.Text.Equals("NV")) //Thêm nhân viên
                    {
                        using (var frmDetail = new FrmEmployeeDetail())
                        {
                            frmDetail.ShowDialog();
                            if (frmDetail.CloseBox)
                            {
                                if (!string.IsNullOrEmpty(GlobalVariable.EmployeeIDDetailForm))
                                {
                                    _accountingObjectsPresenter.Display();
                                    lookUpEditAccountingObject.EditValue = GlobalVariable.EmployeeIDDetailForm;
                                }
                            }
                        }
                    }
                    else //Thêm đối tượng
                    {
                        using (var frmDetail = new FrmXtraAccountingObjectDetail())
                        {
                            frmDetail.ShowDialog();
                            if (frmDetail.CloseBox)
                            {
                                if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                                {
                                    _accountingObjectsPresenter.Display();
                                    lookUpEditAccountingObject.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                                }
                            }
                        }
                    }
                }
                else
                {
                    var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
                    XtraMessageBox.Show("Bạn chưa chọn loại đối tượng", detailContent,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmBUTransferDetailFixedAsset_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(panel1, true, false);
        }

        protected override string AccountingObjectCategoryId
        {
            get { return lkAccountObjectCategory.EditValue == null ? null : lkAccountObjectCategory.EditValue.ToString(); }
            set { lkAccountObjectCategory.EditValue = value; }
        }

        private void FrmBUTransferDetailFixedAsset_Load(object sender, EventArgs e)
        {
            var accountingObject = _model.GetAccountingObject(AccountingObjectId) ?? new AccountingObjectModel();
            if (string.IsNullOrEmpty(accountingObject.AccountingObjectCategoryId) && accountingObject.IsEmployee)

            {
                AccountingObjectCategoryId = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                AccountingObjectCategoryId = accountingObject.AccountingObjectCategoryId;
            }
        }

        private void LkAccountObjectCategory_EditValueChanged(object sender, EventArgs e)
        {
            _accountingObjectsPresenter.DisplayActive(true);
        }

        private void cboBankPay_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBankDetail = new FrmBankDetail();
                frmBankDetail.ShowDialog();
                if (frmBankDetail.CloseBox)
                {
                    if (!String.IsNullOrEmpty(GlobalVariable.BankIDProjectDetailForm))
                    {
                        _banksPresenter.DisplayActive(true);
                        cboBankPay.EditValue = GlobalVariable.BankIDProjectDetailForm;
                    }
                }
            }
        }
        #endregion

        #region  Init new row
        /// <summary>
        /// Initializes the detail row for acounting detail by inventory item.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetailByInventoryItem(InitNewRowEventArgs e, GridView view)
        {
            InitNewRow(e, view);
        }


        /// <summary>
        /// Initializes the detail row for acounting detail by tax.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetailByTax(InitNewRowEventArgs e, GridView view)
        {
            InitNewRow(e, view);
        }

        /// <summary>
        /// Initializes the new row.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        private void InitNewRow(InitNewRowEventArgs e, GridView view)
        {
            if (view == null)
                return;

            view.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailFixedAssetlModel.OrgRefDate), DateTime.Now.Date);
            view.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailFixedAssetlModel.OrgRefDate), null);

            view.SetRowCellValue(e.RowHandle, nameof(BUTransferModel.AccountingObjectId), this.AccountingObjectId);
        }

        /// <summary>
        /// InitNewRow paralel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdViewAccountingParallel_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.BudgetSourceId), GlobalVariable.DefaultBudgetSourceID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.BudgetChapterCode), GlobalVariable.DefaultBudgetChapterCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.BudgetKindItemCode), GlobalVariable.DefaultBudgetKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.BudgetSubKindItemCode), GlobalVariable.DefaultBudgetSubKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.CashWithdrawTypeId), GlobalVariable.DefaultCashWithDrawTypeID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.MethodDistributeId), GlobalVariable.DefaultMethodDistributeID);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// CellValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdViewAccountingParallel_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (DesignMode)
                return;
            if (e.Column.FieldName == "AmountOC")
            {
                var amountOC = grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "AmountOC") == null ? 0 : (decimal)grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "AmountOC");
                var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null ? 0 : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "Amount", exchangeRate * amountOC);
            }

            if (e.Column.FieldName == "BudgetSubItemCode" && e.Value != null)
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    return;
                var parentId = _listBudgetItems.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                var budgetItemCode = _listBudgetItems.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode);
            }
        }
        #endregion

    }
}