/***********************************************************************
 * <copyright file="FrmOpeningAccountEntryDetail.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Currency;
using Buca.Application.iBigTime2020.Presenter.Dictionary.DBOption;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Opening;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.OpeningAccountEntry;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.View.OpeningInventoryEntry;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using Buca.Application.iBigTime2020.Presenter.OpeningInventory;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using DevExpress.XtraGrid;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.OpeningAccount
{
    /// <summary>
    /// Số dư đầu kì theo tài khoản
    /// </summary>
    public partial class FrmOpeningAccountEntryDetail : FrmXtraBaseTreeDetail, IOpeningAccountEntriesView, IOpeningInventoryEntriesView
        , IInventoryItemsView, IStocksView
        , IAccountsView, IProjectsView, IBanksView, IAccountingObjectCategoriesView
        , IAccountingObjectsView, IActivitysView, IBudgetChaptersView, IBudgetItemsView, IBudgetSourcesView, IBudgetKindItemsView, IFundStructuresView, IFixedAssetsView, ICurrenciesView, IBudgetExpensesView, IContractsView, ICapitalPlansView
    {
        #region presenter
        private readonly ContractsPresenter _contractsPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;
        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly BanksPresenter _banksPresenter;
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly OpeningAccountEntriesPresenter _openingAccountEntryPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;
        private readonly CurrenciesPresenter _currenciesPresenter;
        private readonly ActivitysPresenter _activitysPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        private readonly StocksPresenter _stocksPresenter;
        private readonly OpeningInventoryEntriesPresenter _openingInventoryEntriesPresenter;
        #endregion

        #region variables
        private IList<AccountModel> _accounts;
        private AccountModel _account;
        private List<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetKindItemModel> _budgetSubKindItemModels;
        private List<BudgetItemModel> _listBudgetItems;
        private List<InventoryItemModel> _listIventoryItems;
        private List<CurrencyModel> _listCurrency;
        IList<OpeningInventoryEntryModel> _openingInventoryEntries;
        IList<OpeningAccountEntryModel> _openingAccountEntriesModel;
        #endregion

        private readonly AccountingObjectCategoriesPresenter _accountingObjectCategoryPresenter;
        #region RepositoryItemGridLookUpEdit
        private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        private GridView _gridLookUpEditContractView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCapitalPlan;
        private GridView _gridLookUpEditCapitalPlanView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;

        private RepositoryItemGridLookUpEdit _gridLookUpBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        private GridView _gridLookUpEditBudgetChapterView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetKindItem;
        private GridView _gridLookUpEditBudgetKindItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        private GridView _gridLookUpEditBudgetSubKindItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private GridView _gridLookUpEditBudgetItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        private GridView _gridLookUpEditBudgetSubItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;
        private GridView _gridLookUpEditCashWithdrawTypeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCurrency;
        private GridView _gridLookUpEditCurrencyView;
        // Cho vật tư/CCDC
        private RepositoryItemGridLookUpEdit _gridLookUpEditCurrencyCode;
        private GridView _gridLookUpEditCurrencyViewCode;


        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        private GridView _gridLookUpEditAccountingObjectView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingCateObject;
        private GridView _gridLookUpEditAccountingCateObjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;
        private GridView _gridLookUpEditFixedAssetView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItem;
        private GridView _gridLookUpEditInventoryItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditStock;
        private GridView _gridLookUpEditStockView;

        private readonly IModel _model;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmOpeningAccountEntryDetail"/> class.
        /// </summary>
        public FrmOpeningAccountEntryDetail()
        {
            InitializeComponent();
            _contractsPresenter = new ContractsPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _openingAccountEntryPresenter = new OpeningAccountEntriesPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _currenciesPresenter = new CurrenciesPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _stocksPresenter = new StocksPresenter(this);
            _openingInventoryEntriesPresenter = new OpeningInventoryEntriesPresenter(this);
            _accountingObjectCategoryPresenter = new AccountingObjectCategoriesPresenter(this);
            _model = new Model.Model();
        }

        /// <summary>
        /// Handles the Load event of the FrmOpeningAccountEntryDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmOpeningAccountEntryDetail_Load(object sender, EventArgs e)
        {
            _accountsPresenter.Display();
            _accountingObjectCategoryPresenter.Display();
            _account = (from accountModel in _accounts where accountModel.AccountId == KeyValue select accountModel).FirstOrDefault();
            if (_account != null && _account.DetailByContract)
                _contractsPresenter.Display();
            if (_account != null && _account.DetailByCapitalPlan)
                _capitalPlansPresenter.Display();
            if (_account != null && _account.DetailByBudgetSource)
                _budgetSourcesPresenter.DisplayActive();

            if (_account != null && (_account != null && _account.DetailByBudgetItem || _account.DetailByBudgetSubItem))
                _budgetItemsPresenter.Display();

            if (_account != null && _account.DetailByBudgetChapter)
                _budgetChaptersPresenter.DisplayByIsActive(true);

            if (_account != null && _account.DetailByAccountingObject)
                _accountingObjectsPresenter.Display();

            if (_account != null && _account.DetailByProject)
                _projectsPresenter.Display();

            //if (_account != null && _account.DetailByBudgetKindItem) //AnhtNT, disable đi tránh lỗi nhập số tiền ở các tài khoản chỉ có cột dư có
            _budgetKindItemsPresenter.Display();

            if (_account != null && _account.DetailByBudgetExpense)
                _budgetExpensesPresenter.DisplayActive();

            //edit by thangnd o xai fund nen bo tam
            if (_account != null && _account.DetailByExpense)
                _fundStructuresPresenter.DisplayActive(true);

            if (_account != null && _account.DetailByFixedAsset)
                _fixedAssetsPresenter.Display();
            if (_account != null && _account.DetailByActivity)
                _activitysPresenter.Display();
            if (_account != null && _account.DetailByCurrency)
                _currenciesPresenter.Display();
            if (_account != null && _account.DetailByBankAccount)
                _banksPresenter.Display();
            if (_account == null)
                return;

            _openingAccountEntryPresenter.Display(_account.AccountNumber);
            _inventoryItemsPresenter.DisplayOpening(true);
            _stocksPresenter.Display();
            _openingInventoryEntriesPresenter.Display(_account.AccountNumber);

            switch (this.ActionMode)
            {
                case ActionModeEnum.None:
                    grdDetailView.OptionsBehavior.Editable = false;
                    grdDetailView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    btnSave.Enabled = false;
                    break;
                case ActionModeEnum.Edit:
                    this.Text = "Sửa số dư đầu kỳ tài khoản";
                    break;
            }
        }

        #region Save

        bool ValidData(List<OpeningInventoryEntryModel> openingInventoryEntries)
        {
            #region Check detail by
            if (_account.DetailByBudgetSource)
            {
                if (openingInventoryEntries.Exists(m => string.IsNullOrEmpty(m.BudgetSourceId)))
                {
                    XtraMessageBox.Show("Chọn nguồn vốn.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (_account.DetailByBudgetChapter)
            {
                if (openingInventoryEntries.Exists(m => string.IsNullOrEmpty(m.BudgetChapterCode)))
                {
                    XtraMessageBox.Show("Chọn chương.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (_account.DetailByBudgetKindItem)
            {
                if (openingInventoryEntries.Exists(m => string.IsNullOrEmpty(m.BudgetSubKindItemCode)))
                {
                    XtraMessageBox.Show("Chọn khoản.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (_account.DetailByBudgetSubItem)
            {
                if (openingInventoryEntries.Exists(m => string.IsNullOrEmpty(m.BudgetSubItemCode)))
                {
                    XtraMessageBox.Show("Chọn tiểu mục.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (openingInventoryEntries.Exists(m => string.IsNullOrEmpty(m.BudgetItemCode)))
                {
                    XtraMessageBox.Show("Chọn mục.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (openingInventoryEntries.Exists(m => string.IsNullOrEmpty(m.InventoryItemId)))
            {
                XtraMessageBox.Show("Chọn vật tư.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (openingInventoryEntries.Exists(m => string.IsNullOrEmpty(m.StockId)))
            {
                XtraMessageBox.Show("Chọn kho.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            #endregion

            return true;
        }
        protected override string SaveData()
        {
            grdDetailView.CloseEditor();

            if (_account.DetailByInventoryItem) // Theo vật tư

            {
                //if (_openingInventoryEntries != null && _openingInventoryEntries.Count > 0)
                //    return _openingInventoryEntriesPresenter.Save(_openingInventoryEntries, _account.AccountNumber);
                //else
                return _openingInventoryEntriesPresenter.Save(_openingInventoryEntries, _account.AccountNumber);//AnhNT: Đã xử lý phương thức xóa all vật tư của 1 acc trong hàm này.
                //return _openingInventoryEntriesPresenter.Save(_account.AccountNumber);//Ko cần sử dụng hàm này nữa.
            }

            if (_openingAccountEntriesModel != null && _openingAccountEntriesModel.Count > 0)
            {
                return _openingAccountEntryPresenter.Save();
            }
            return _openingAccountEntryPresenter.Save(_account.AccountNumber);
        }

        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            // Nhập số dư đầu kì cho tài khoản cha thì thông báo
            if (_account.IsParent)
            {
                if (XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryIsParent"), detailContent,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }

            if (_account.DetailByInventoryItem)
            {
                _openingInventoryEntries = this.OpeningInventoryEntries;
                if (_openingInventoryEntries.Count < 0 || _openingInventoryEntries == null)
                {
                    XtraMessageBox.Show("Bạn chưa nhập đầy đủ chi tiết dữ liệu.", detailContent, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                return ValidData(_openingInventoryEntries.ToList());
            }
            else
            {
                _openingAccountEntriesModel = OpeningAccountEntries;
                List<OpeningAccountEntryModel> _openingAccountEntries = this.OpeningAccountEntries.ToList();
                if (_openingAccountEntries == null || _openingAccountEntries.Count < 0)

                {
                    XtraMessageBox.Show("Bạn chưa nhập đầy đủ chi tiết dữ liệu.", detailContent, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                #region Check detail by
                if (_account.DetailByBudgetSource)
                {
                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.BudgetSourceId)))
                    {
                        XtraMessageBox.Show("Chọn nguồn vốn.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (_account.DetailByBudgetChapter)
                {
                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.BudgetChapterCode)))
                    {
                        XtraMessageBox.Show("Chọn chương.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (_account.DetailByBudgetKindItem)
                {
                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.BudgetSubKindItemCode)))
                    {
                        XtraMessageBox.Show("Chọn khoản.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (_account.DetailByBudgetSubItem)
                {
                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.BudgetSubItemCode)))
                    {
                        XtraMessageBox.Show("Chọn tiểu mục.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.BudgetItemCode)))
                    {
                        XtraMessageBox.Show("Chọn mục.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (_account.DetailByAccountingObject)
                {
                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.AccountingObjectId)))
                    {
                        XtraMessageBox.Show("Chọn đối tượng.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (_account.DetailByActivity)
                {
                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.ActivityId)))
                    {
                        XtraMessageBox.Show("Chọn hoạt động sự nghiệp.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (_account.DetailByProject)
                {
                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.ProjectId)))
                    {
                        XtraMessageBox.Show("Chọn dự án.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (_account.DetailByBankAccount)
                {
                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.BankId)))
                    {
                        XtraMessageBox.Show("Chọn tài khoản ngân hàng.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (_account.DetailByCurrency)
                {
                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.CurrencyId)))
                    {
                        XtraMessageBox.Show("Chọn tiền tệ.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (_account.DetailByContract)
                {
                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.ContractId)))
                    {
                        XtraMessageBox.Show("Chọn hợp đồng.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (_account.DetailByCapitalPlan)
                {
                    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.CapitalPlanId)))
                    {
                        XtraMessageBox.Show("Chọn kế hoạch vốn.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                //edit by thangnd ko xai fund nen bo tam di
                //if (_account.DetailByFund)
                //{
                //    if (_openingAccountEntries.Exists(m => string.IsNullOrEmpty(m.FundStructureId)))
                //    {
                //        XtraMessageBox.Show("Chọn cơ cấu vốn.", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return false;
                //    }
                //}
                #endregion
            }

            return true;
        }
        #endregion

        #region Extention Iview

        #region Vật tư + kho
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                if (_account.DetailByInventoryItem)
                {
                    if (value == null)
                        return;
                    if (_account.AccountNumber.Contains("152"))
                    {
                        value = value.Where(ac => ac.IsTool == false).ToList();
                    }
                    if (_account.AccountNumber.Contains("153"))
                    {
                        value = value.Where(ac => ac.IsTool == true).ToList();
                    }
                    _listIventoryItems = value.ToList();


                    //_gridLookUpEditInventoryItem.KeyPress += _gridLookUpEditInventoryItem_KeyPress;
                    //_gridLookUpEditInventoryItem.Popup += _gridLookUpEditInventoryItem_Popup;
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = _account.AccountNumber == "153" ? "Mã công cụ, dụng cụ" : "Mã nguyên liệu, vật liệu", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = _account.AccountNumber == "153" ? "Tên công cụ, dụng cụ" : "Tên nguyên liệu, vật liệu", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    _gridLookUpEditInventoryItemView = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditInventoryItem = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInventoryItemView, _listIventoryItems, "InventoryItemName", "InventoryItemId", gridColumnsCollection);
                    XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInventoryItemView);
                }
            }
        }
        bool _flagKey;
        private void _gridLookUpEditInventoryItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = _flagKey;
        }

        private void _gridLookUpEditInventoryItem_Popup(object sender, EventArgs e)
        {
            GridLookUpEdit look = sender as GridLookUpEdit;
            if (look == null)
                return;

            if (bindingSourceDetail.DataSource == null)
                return;
            var openingSuppyEntries = ((IList<OpeningInventoryEntryModel>)bindingSourceDetail.DataSource).ToList();
            if (openingSuppyEntries.Count == 0)
                return;

            if (look.Properties.DataSource == null)
                return;

            if (grdDetailView.FocusedRowHandle >= 0)
            {
                var openingSupplyEntryModel = (OpeningInventoryEntryModel)grdDetailView.GetFocusedRow();
                openingSuppyEntries = openingSuppyEntries.Where(m => !(m.InventoryItemId ?? string.Empty).Equals(openingSupplyEntryModel.InventoryItemId)).ToList();
            }

            //    string sFilter = "NOT [InventoryItemId] IN ('" + string.Join("','", openingSuppyEntries.Select(m => { return m.InventoryItemId; }).ToArray()) + "')";
            //    look.Properties.View.ActiveFilterString = sFilter;
        }

        public IList<StockModel> Stocks
        {
            set
            {
                if (_account.DetailByInventoryItem)
                {
                    if (value == null)
                        return;


                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "StockCode", ColumnCaption = "Mã kho", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "StockName", ColumnCaption = "Tên kho", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });




                    _gridLookUpEditStockView = XtraColumnCollectionHelper<StockModel>.CreateGridViewReponsitory();
                    _gridLookUpEditStock = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditStockView, value, "StockName", "StockId", gridColumnsCollection);
                    XtraColumnCollectionHelper<StockModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditStockView);
                }
            }
        }
        #endregion
        public IList<AccountingObjectModel> OldAccountingObjects { get; set; }
        public IList<ContractModel> OldContracts { get; set; }
        #region đối tượng
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                if (_account.DetailByAccountingObject)
                {
                    if (value == null)
                        value = new List<AccountingObjectModel>();
                    OldAccountingObjects = value;
                    //       value = value.Where(v => v.AccountingObjectCategoryId == "c21a7ab9-296b-4790-be11-d4e8007dd615").ToList();


                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã đối tượng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectName", ColumnCaption = "Tên đối tượng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, value, "AccountingObjectCode", "AccountingObjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountingObjectView);
                }
            }
        }
        #endregion

        #region hoạt động sự nghiệp
        public IList<ActivityModel> Activitys
        {
            set
            {
                if (_account.DetailByActivity)
                {
                    if (value == null)
                        value = new List<ActivityModel>();


                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityCode", ColumnCaption = "Mã hoạt động SN", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityName", ColumnCaption = "Tên hoạt động SN", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });



                    _gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                    _gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, "ActivityName", "ActivityId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);

                }
            }
        }
        #endregion

        #region Nguồn vốn
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                var budgetSourceList = value.Where(nv => nv.IsActive == true && nv.IsParent == false).ToList();
                if (budgetSourceList == null)
                    budgetSourceList = new List<BudgetSourceModel>();



                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn vốn", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn vốn", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });



                _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, budgetSourceList, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
            }
        }
        #endregion

        #region Chương
        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                if (_account.DetailByBudgetChapter)
                {
                    if (value == null)
                        value = new List<BudgetChapterModel>();



                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Mã chương", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterName", ColumnCaption = "Tên chương", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });


                    _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);

                }
            }
        }
        #endregion

        #region Khoản
        /// <summary>
        /// Sets the budget kind items.
        /// </summary>
        /// <value>The budget kind items.</value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                try
                {
                    _budgetKindItemModels = value.Where(v => v.IsParent).ToList();
                    _budgetSubKindItemModels = value.Where(v => !v.IsParent).ToList();

                    var budgetKindItems = value.Where(v => v.IsParent && v.IsActive).ToList();
                    var budgetSubKindItems = value.Where(v => !v.IsParent && v.IsActive).ToList();

                    #region Loại
                    _gridLookUpEditBudgetKindItemView = new GridView();
                    _gridLookUpEditBudgetKindItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetKindItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetKindItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetKindItem.View.BestFitColumns();

                    _gridLookUpEditBudgetKindItem.DataSource = budgetKindItems;
                    _gridLookUpEditBudgetKindItemView.PopulateColumns(budgetKindItems);
                    #endregion

                    #region Khoản
                    _gridLookUpEditBudgetSubKindItemView = new GridView();
                    _gridLookUpEditBudgetSubKindItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubKindItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubKindItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubKindItem.View.BestFitColumns();

                    _gridLookUpEditBudgetSubKindItem.DataSource = budgetSubKindItems;
                    _gridLookUpEditBudgetSubKindItemView.PopulateColumns(budgetSubKindItems);
                    #endregion



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
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;

                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Visible = false;
                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].Visible = false;
                        }

                    }
                    //_gridLookUpEditBudgetSubKindItem.DisplayMember = "BudgetKindItemCode";
                    //_gridLookUpEditBudgetSubKindItem.ValueMember = "BudgetKindItemCode";

                    //_gridLookUpEditBudgetKindItem.DisplayMember = "BudgetKindItemCode";
                    //_gridLookUpEditBudgetKindItem.ValueMember = "BudgetKindItemCode";

                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, budgetSubKindItems, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);

                    _gridLookUpEditBudgetKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetKindItemView, budgetKindItems, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetKindItemView);


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region mục/tiểu mục
        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>The BudgetItems.</value>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                try
                {
                    _listBudgetItems = value?.ToList();

                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2 && v.IsActive == true).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3 && v.IsActive == true).ToList();

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

                    #region BudgetSubItem
                    _gridLookUpEditBudgetSubItemView = new GridView();
                    _gridLookUpEditBudgetSubItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetSubItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubItem.View.BestFitColumns();

                    _gridLookUpEditBudgetSubItem.DataSource = budgetSubItemModels;
                    _gridLookUpEditBudgetSubItemView.PopulateColumns(budgetSubItemModels);
                    gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnCaption = "Mã tiểu mục",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemName",
                        ColumnCaption = "Tên tiểu mục",
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
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditBudgetSubItem.DisplayMember = "BudgetItemCode";
                    //_gridLookUpEditBudgetSubItem.ValueMember = "BudgetItemCode";
                    _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, budgetSubItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);


                    #endregion
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Loại chứng từ
        /// <summary>
        /// Sets the cash withdraw type models.
        /// </summary>
        /// <value>The cash withdraw type models.</value>
        public IList<CashWithdrawTypeModel> CashWithdrawTypeModels
        {
            set
            {
                try
                {
                    _gridLookUpEditCashWithdrawTypeView = new GridView();
                    _gridLookUpEditCashWithdrawTypeView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCashWithdrawType = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCashWithdrawTypeView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditCashWithdrawType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCashWithdrawType.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCashWithdrawType.PopupFormSize = new Size(268, 150);

                    _gridLookUpEditCashWithdrawType.View.BestFitColumns();

                    _gridLookUpEditCashWithdrawType.DataSource = value;
                    _gridLookUpEditCashWithdrawTypeView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeName",
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawNo", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SubSystemId", ColumnVisible = false });
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditCashWithdrawType.DisplayMember = "CashWithdrawTypeName";
                    //_gridLookUpEditCashWithdrawType.ValueMember = "CashWithdrawTypeId";

                    _gridLookUpEditCashWithdrawTypeView = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCashWithdrawType = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCashWithdrawTypeView, value, "CashWithdrawTypeName", "CashWithdrawTypeId", gridColumnsCollection);
                    XtraColumnCollectionHelper<CashWithdrawTypeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCashWithdrawTypeView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Tài khoản ngân hàng
        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>The banks.</value>
        public IList<BankModel> Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();

                //_gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                //_gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                //  XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);


                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }
        #endregion

        #region tài khoản
        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                _accounts = value;
            }
        }

        #endregion

        #region dự án
        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public IList<ProjectModel> Projects
        {
            set
            {
                try
                {
                    _gridLookUpEditProjectView = new GridView();
                    _gridLookUpEditProjectView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditProject = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditProjectView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditProject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditProject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditProject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditProject.View.BestFitColumns();

                    var listproduct = value.Where(p => p.ObjectType == 2).ToList();

                    _gridLookUpEditProject.DataSource = listproduct;
                    _gridLookUpEditProjectView.PopulateColumns(listproduct);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectCode",
                        ColumnCaption = "Mã dự án",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectName",
                        ColumnCaption = "Tên dự án",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDetailbyActivityAndExpense",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                    //}

                    //XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
                    //_gridLookUpEditProject.DisplayMember = "ProjectCode";
                    //_gridLookUpEditProject.ValueMember = "ProjectId";

                    _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, listproduct, "ProjectCode", "ProjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        public IList<FundStructureModel> FundStructures
        {
            set
            {

                if (value == null)
                    value = new List<FundStructureModel>();
                var gridColumnsCollection = new List<XtraColumn>();

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FundStructureCode",
                    ColumnCaption = "Mã khoản chi",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FundStructureName",
                    ColumnCaption = "Tên khoản chi",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });

                _gridLookUpEditFundStructureView = XtraColumnCollectionHelper<CapitalPlanModel>.CreateGridViewReponsitory();
                _gridLookUpEditFundStructure = XtraColumnCollectionHelper<CapitalPlanModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, value, "FundStructureCode", "FundStructureId", gridColumnsCollection);

                XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);
                _gridLookUpEditFundStructure.EndUpdate();
            }
        }
        #region cơ cấu vốn
        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>The fund structures.</value>

        #endregion

        #region tài sản cố định
        /// <summary>
        /// Sets the fixed assets.
        /// </summary>
        /// <value>The fixed assets.</value>
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                try
                {
                    _gridLookUpEditFixedAssetView = new GridView();
                    _gridLookUpEditFixedAssetView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFixedAsset = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFixedAssetView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFixedAsset.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFixedAsset.View.BestFitColumns();

                    _gridLookUpEditFixedAsset.DataSource = value;
                    _gridLookUpEditFixedAssetView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FixedAssetCode",
                        ColumnCaption = "Mã tài sản",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FixedAssetName",
                        ColumnCaption = "Tên tài sản",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProductionYear", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SerialNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Accessories", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "GuaranteeDuration", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSecondHand", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LastState", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedReason", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "PurchasedDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "UsedDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IncrementDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPrice", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationValueCaculated", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccumDepreciationAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LifeTime", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "PeriodDepreciationAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingLifeTime", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "EndYear", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPriceAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CreditDepreciationAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DebitDepreciationAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsFixedAssetTransfer", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationTimeCaculated", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditFixedAsset.DisplayMember = "FixedAssetCode";
                    _gridLookUpEditFixedAsset.ValueMember = "FixedAssetId";

                    _gridLookUpEditFixedAssetView = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridViewReponsitory();
                    _gridLookUpEditFixedAsset = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFixedAssetView, value, "FixedAssetCode", "FixedAssetId", gridColumnsCollection);
                    XtraColumnCollectionHelper<FixedAssetModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFixedAssetView);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region tiền

        /// <summary>
        /// Sets the currencies.
        /// </summary>
        /// <value>The currencies.</value>
        public IList<CurrencyModel> Currencies
        {
            set
            {
                try
                {
                    _gridLookUpEditCurrencyView = new GridView();
                    _gridLookUpEditCurrencyView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCurrency = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCurrencyView,
                        TextEditStyle = TextEditStyles.Standard
                    };

                    _gridLookUpEditCurrencyViewCode = new GridView();
                    _gridLookUpEditCurrencyViewCode.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCurrencyCode = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCurrencyViewCode,
                        TextEditStyle = TextEditStyles.Standard
                    };

                    _gridLookUpEditCurrency.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCurrency.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCurrency.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditCurrency.View.BestFitColumns();
                    _listCurrency = value.Where(tt => tt.IsActive == true).ToList();
                    _gridLookUpEditCurrency.DataSource = _listCurrency;
                    _gridLookUpEditCurrencyView.PopulateColumns(_listCurrency);


                    _gridLookUpEditCurrencyCode.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCurrencyCode.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCurrency.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditCurrencyCode.View.BestFitColumns();
                    _gridLookUpEditCurrencyCode.DataSource = _listCurrency;
                    _gridLookUpEditCurrencyViewCode.PopulateColumns(_listCurrency);
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "CurrencyId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "CurrencyCode",
                            ColumnCaption = "Mã tiền",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "CurrencyName",
                            ColumnCaption = "Tiền tệ",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "Prefix", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Suffix", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsMain", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    };
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Width = column.ColumnWith;

                            _gridLookUpEditCurrencyViewCode.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditCurrencyViewCode.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditCurrencyViewCode.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Visible = false;
                            _gridLookUpEditCurrencyViewCode.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditCurrency.DisplayMember = "CurrencyName";
                    _gridLookUpEditCurrency.ValueMember = "CurrencyId";

                    _gridLookUpEditCurrencyView = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCurrency = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCurrencyView, _listCurrency, "CurrencyCode", "CurrencyId", gridColumnsCollection);
                    XtraColumnCollectionHelper<CurrencyModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCurrencyView);


                    _gridLookUpEditCurrencyCode.DisplayMember = "CurrencyName";
                    _gridLookUpEditCurrencyCode.ValueMember = "CurrencyCode";

                    _gridLookUpEditCurrencyViewCode = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCurrencyCode = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCurrencyViewCode, _listCurrency, "CurrencyName", "CurrencyCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<CurrencyModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCurrencyViewCode);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region BudgetExpenses
        public IList<BudgetExpenseModel> BudgetExpenses
        {
            set
            {
                if (value == null)
                    value = new List<BudgetExpenseModel>();

                //_gridLookUpEditBudgetExpenseView = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridViewReponsitory();
                //_gridLookUpBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, "BudgetExpenseName", "BudgetExpenseId");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseCode", ColumnCaption = "Mã", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseName", ColumnCaption = "Tên phí, lệ phí", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 1 });

                // XtraColumnCollectionHelper<BudgetExpenseModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetExpenseView);

                _gridLookUpEditBudgetExpenseView = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridViewReponsitory();
                _gridLookUpBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, "BudgetExpenseName", "BudgetExpenseId", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetExpenseModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetExpenseView);

            }
        }
        #endregion


        #region Contract

        /// <summary>
        /// Contract
        /// </summary>
        public IList<ContractModel> Contracts
        {
            set
            {

                if (value == null)
                    value = new List<ContractModel>();
                OldContracts = value.ToList();
                var gridColumnsCollection = new List<XtraColumn>();

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractNo", ColumnCaption = "Số hợp đồng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractName", ColumnCaption = "Tên hợp đồng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditContractView = XtraColumnCollectionHelper<ContractModel>.CreateGridViewReponsitory();
                _gridLookUpEditContract = XtraColumnCollectionHelper<ContractModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditContractView, value, "ContractName", "ContractId", gridColumnsCollection);

                XtraColumnCollectionHelper<ContractModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditContractView);
                _gridLookUpEditContract.EndUpdate();
            }
        }

        #endregion

        #region CapitalPlan

        /// <summary>
        /// Contract
        /// </summary>
        public IList<CapitalPlanModel> CapitalPlans
        {
            set
            {

                if (value == null)
                    value = new List<CapitalPlanModel>();
                var gridColumnsCollection = new List<XtraColumn>();

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanCode", ColumnCaption = "Mã kế hoạch vốn", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanName", ColumnCaption = "Tên kế hoạch vốn", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditCapitalPlanView = XtraColumnCollectionHelper<CapitalPlanModel>.CreateGridViewReponsitory();
                _gridLookUpEditCapitalPlan = XtraColumnCollectionHelper<CapitalPlanModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCapitalPlanView, value, "CapitalPlanCode", "CapitalPlanId", gridColumnsCollection);

                XtraColumnCollectionHelper<CapitalPlanModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCapitalPlanView);
                if (_gridLookUpEditContract != null)
                    _gridLookUpEditContract.EndUpdate();
            }
        }

        #endregion


        #endregion

        #region Iview Detail

        /// <summary>
        /// Sets the opening account entries.
        /// </summary>
        /// <value>
        /// The opening account entries.
        /// </value>
        public IList<OpeningAccountEntryModel> OpeningAccountEntries
        {
            get
            {

                var openingAccountEntryDetails = new List<OpeningAccountEntryModel>();
                if (grdDetailView.DataSource != null && grdDetailView.RowCount > 0)
                {
                    for (var i = 0; i < grdDetailView.RowCount; i++)
                    {
                        var rowVoucher = (OpeningAccountEntryModel)grdDetailView.GetRow(i);
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

                            var budgetItemCode = "";
                            if (!string.IsNullOrEmpty(rowVoucher.BudgetSubItemCode))
                            {
                                var budgetSubItemCode = _listBudgetItems.FirstOrDefault(b => b.BudgetItemCode == rowVoucher.BudgetSubItemCode);
                                if (budgetSubItemCode == null)
                                    budgetItemCode = null;
                                else
                                {
                                    var budgetItem = _listBudgetItems.FirstOrDefault(b => b.BudgetItemId == budgetSubItemCode.ParentId);
                                    budgetItemCode = budgetItem == null ? null : budgetItem.BudgetItemCode;
                                }
                            }

                            string currencyId = "E583FDB5-116D-436D-9743-6E12076847A5";
                            GlobalVariable.CurrencyMain = "VND";                            // set mặc là VND nếu ở tk 24311 ko tích chọn vào loại tiền tệ
                            //decimal exchangeRate = 1;
                            if (rowVoucher.CurrencyId != null || rowVoucher.CurrencyId != string.Empty)
                                currencyId = rowVoucher.CurrencyId;
                            var item = new OpeningAccountEntryModel
                            {
                                RefType = (int)BuCA.Enum.RefType.OpeningAccountEntry,
                                PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1),
                                AccountNumber = _account.AccountNumber,
                                CurrencyId = currencyId,
                                CurrencyCode = _listCurrency == null ? GlobalVariable.CurrencyMain : _listCurrency.FirstOrDefault(c => c.CurrencyId == currencyId).CurrencyCode,                               
                                ExchangeRate = rowVoucher.ExchangeRate == null ? 1 : rowVoucher.ExchangeRate,
                                AccBeginningDebitAmount = rowVoucher.AccBeginningDebitAmount,
                                AccBeginningCreditAmount = rowVoucher.AccBeginningDebitAmount,
                                DebitAmount = rowVoucher.DebitAmount,
                                CreditAmount = rowVoucher.CreditAmount,
                                DebitAmountOC = rowVoucher.DebitAmountOC,
                                CreditAmountOC = rowVoucher.CreditAmountOC,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = budgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                CashWithdrawTypeId = rowVoucher.CashWithdrawTypeId,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ActivityId = rowVoucher.ActivityId,
                                ProjectId = rowVoucher.ProjectId,
                                TaskId = rowVoucher.TaskId,
                                BankId = rowVoucher.BankId,
                                Approved = rowVoucher.Approved,
                                SortOrder = i,
                                BudgetDetailItemCode = rowVoucher.BudgetDetailItemCode,
                                ProjectActivityId = rowVoucher.ProjectActivityId,
                                ApprovedDate = DateTime.Today.AddDays(-1),
                                FundStructureId = rowVoucher.FundStructureId,
                                ProjectActivityEAID = rowVoucher.ProjectActivityEAID,
                                BudgetProvideCode = rowVoucher.BudgetProvideCode,
                                BudgetExpenseId = rowVoucher.BudgetExpenseId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                            };
                            openingAccountEntryDetails.Add(item);
                        }
                    }

                }
                return openingAccountEntryDetails;
            }

            set
            {
                if (value == null || _account == null)
                    return;
                value = value.OrderBy(c => c.SortOrder).ToList();
                #region Không tích theo vật tư
                if (!_account.DetailByInventoryItem)
                {
                    var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                    //repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                    //repositoryNumberCalcEdit.Mask.EditMask = GlobalVariable.ExchangeRateDecimalDigits; //lay theo option
                    //repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                    repositoryNumberCalcEdit.Mask.EditMask = @"c" + GlobalVariable.ExchangeRateDecimalDigits;
                    repositoryNumberCalcEdit.Precision = int.Parse(GlobalVariable.ExchangeRateDecimalDigits);
                    foreach (var item in value)
                    {
                        if (_account.DetailByAccountingObject)
                        {
                            if (item.AccountingObjectId != null)
                            {
                                var accoutingobject = OldAccountingObjects.FirstOrDefault(o => o.AccountingObjectId == item.AccountingObjectId);
                                if (accoutingobject != null)
                                {
                                    var accountObjectCate = OldAccountingObjectCategories.FirstOrDefault(o => o.AccountingObjectCategoryId == accoutingobject.AccountingObjectCategoryId);
                                    if (accountObjectCate != null)
                                    {
                                        item.AccountingCateObjectCode = accountObjectCate.AccountingObjectCategoryCode;
                                    }
                                }
                                if (accoutingobject.AccountingObjectCategoryId == null)
                                {
                                    item.AccountingCateObjectCode = "NV";
                                }
                                var newE = new RepositoryItemGridLookUpEdit();
                                var newView = new GridView();
                                var gridColumnsCollection2 = new List<XtraColumn>();
                                gridColumnsCollection2.Add(new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã đối tượng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                                gridColumnsCollection2.Add(new XtraColumn { ColumnName = "AccountingObjectName", ColumnCaption = "Tên đối tượng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                                newView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                                newE = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(newView, OldAccountingObjects.Where(b => b.AccountingObjectCategoryId == accoutingobject.AccountingObjectCategoryId).ToList(), "AccountingObjectCode", "AccountingObjectId", gridColumnsCollection2);
                                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(gridColumnsCollection2, newView);
                                inplaceEditors.Add(newE);
                                grdDetail.RepositoryItems.Add(newE);
                            }
                            else
                            {
                                var newE = new RepositoryItemGridLookUpEdit();
                                var newView = new GridView();
                                var gridColumnsCollection2 = new List<XtraColumn>();
                                gridColumnsCollection2.Add(new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã đối tượng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                                gridColumnsCollection2.Add(new XtraColumn { ColumnName = "AccountingObjectName", ColumnCaption = "Tên đối tượng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                                newView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                                newE = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(newView, OldAccountingObjects.ToList(), "AccountingObjectCode", "AccountingObjectId", gridColumnsCollection2);
                                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(gridColumnsCollection2, newView);
                                inplaceEditors.Add(newE);
                                grdDetail.RepositoryItems.Add(newE);
                            }

                        }
                        if (_account.DetailByProject && OldContracts != null)
                        {
                            if (item.ProjectId != null)
                            {
                                var newE = new RepositoryItemGridLookUpEdit();
                                var newView = new GridView();
                                var gridColumnsCollection2 = new List<XtraColumn>();
                                gridColumnsCollection2.Add(new XtraColumn { ColumnName = "ContractNo", ColumnCaption = "Số hợp đồng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                                gridColumnsCollection2.Add(new XtraColumn { ColumnName = "ContractName", ColumnCaption = "Tên hợp đồng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });
                                newView = XtraColumnCollectionHelper<ContractModel>.CreateGridViewReponsitory();
                                newE = XtraColumnCollectionHelper<ContractModel>.CreateGridLookUpEditReponsitory(newView, OldContracts.Where(b => b.ProjectId == item.ProjectId).ToList(), "ContractName", "ContractId", gridColumnsCollection2);
                                XtraColumnCollectionHelper<ContractModel>.ShowXtraColumnInGridView(gridColumnsCollection2, newView);
                                inplaceContractEditors.Add(newE);
                                grdDetail.RepositoryItems.Add(newE);
                            }
                            else
                            {
                                var newE = new RepositoryItemGridLookUpEdit();
                                var newView = new GridView();
                                var gridColumnsCollection2 = new List<XtraColumn>();
                                gridColumnsCollection2.Add(new XtraColumn { ColumnName = "ContractNo", ColumnCaption = "Số hợp đồng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                                gridColumnsCollection2.Add(new XtraColumn { ColumnName = "ContractName", ColumnCaption = "Tên hợp đồng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });
                                newView = XtraColumnCollectionHelper<ContractModel>.CreateGridViewReponsitory();
                                newE = XtraColumnCollectionHelper<ContractModel>.CreateGridLookUpEditReponsitory(newView, OldContracts.ToList(), "ContractName", "ContractId", gridColumnsCollection2);
                                XtraColumnCollectionHelper<ContractModel>.ShowXtraColumnInGridView(gridColumnsCollection2, newView);
                                inplaceContractEditors.Add(newE);
                                grdDetail.RepositoryItems.Add(newE);
                            }

                        }
                    }


                    var gridColumnsCollection = new List<XtraColumn>();
                    bindingSourceDetail.DataSource = value;
                    grdDetailView.PopulateColumns(value);

                    #region Nguồn vốn
                    if (_account.DetailByBudgetSource)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetSourceId",
                            ColumnCaption = "Nguồn vốn",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            AllowEdit = true,
                            RepositoryControl = _gridLookUpEditBudgetSource
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetSourceId",
                            ColumnVisible = false
                        });

                    }
                    // gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                    #endregion

                    #region Chương
                    if (_account.DetailByBudgetChapter)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetChapterCode",
                            ColumnCaption = "Chương",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditBudgetChapter,
                            AllowEdit = true,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetChapterCode",
                            ColumnVisible = false
                        });

                    }
                    #endregion

                    #region Khoản
                    if (_account.DetailByBudgetKindItem)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetKindItemCode",
                            ColumnCaption = "Loại",
                            ColumnPosition = 4,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditBudgetKindItem,
                            AllowEdit = false,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetKindItemCode",
                            ColumnVisible = false
                        });

                    }
                    if (_account.DetailByBudgetKindItem)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetSubKindItemCode",
                            ColumnCaption = "Khoản",
                            ColumnPosition = 3,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditBudgetSubKindItem,
                            AllowEdit = true,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetSubKindItemCode",
                            ColumnVisible = false
                        });

                    }
                    #endregion

                    #region tiểu mục
                    if (_account.DetailByBudgetSubItem)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetSubItemCode",
                            ColumnCaption = "Tiểu mục",
                            ColumnPosition = 5,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditBudgetSubItem,
                            AllowEdit = true,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetSubItemCode",
                            ColumnVisible = false
                        });

                    }
                    #endregion

                    #region Mục
                    if (_account.DetailByBudgetItem)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetItemCode",
                            ColumnCaption = "Mục",
                            ColumnPosition = 6,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditBudgetItem,
                            AllowEdit = true,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetItemCode",
                            ColumnVisible = false,
                            AllowEdit = true,
                        });

                    }
                    #endregion

                    #region Đối tượng
                    if (_account.DetailByAccountingObject)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "AccountingCateObjectCode",
                            ColumnCaption = "Loại đối tượng",
                            ColumnPosition = 7,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditAccountingCateObject,
                            AllowEdit = true,
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "AccountingObjectId",
                            ColumnCaption = "Đối tượng",
                            ColumnPosition = 7,
                            ColumnVisible = true,
                            //     RepositoryControl = _gridLookUpEditAccountingObject,
                            ColumnWith = 130,
                            AllowEdit = true,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "AccountingObjectId",
                            ColumnVisible = false
                        });
                    }
                    #endregion

                    #region hoạt động sự nghiệp
                    if (_account.DetailByActivity)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "ActivityId",
                            ColumnCaption = "Hoạt động sự nghiệp",
                            ColumnPosition = 11,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditActivity,
                            AllowEdit = true,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "ActivityId",
                            ColumnVisible = false,
                            AllowEdit = true,
                        });

                    }
                    #endregion

                    #region dự án
                    if (_account.DetailByProject)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "ProjectId",
                            ColumnCaption = "Dự án",
                            ColumnPosition = 11,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditProject,
                            AllowEdit = true,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "ProjectId",
                            ColumnVisible = false
                        });

                    }
                    #endregion

                    #region hợp đồng
                    if (_account.DetailByContract)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "ContractId",
                            ColumnCaption = "Hợp đồng",
                            ColumnPosition = 12,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            AllowEdit = true,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "ContractId",
                            ColumnVisible = false
                        });

                    }
                    #endregion

                    #region tài khoản ngân hàng
                    if (_account.DetailByBankAccount)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BankId",
                            ColumnCaption = "Tài khoản ngân hàng",
                            ColumnPosition = 11,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditBank,
                            AllowEdit = true,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BankId",
                            ColumnVisible = false
                        });

                    }
                    #endregion

                    #region tiền
                    if (_account.DetailByCurrency)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "CurrencyId",
                            ColumnCaption = "Tiền tệ",
                            ColumnPosition = 5,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditCurrency,
                            AllowEdit = true
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "ExchangeRate",
                            ColumnCaption = "Tỉ giá hối đoái",
                            ColumnPosition = 5,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            ColumnType = UnboundColumnType.Decimal,
                            IsNumeric=true,
                            AllowEdit = true,
                            RepositoryControl = repositoryNumberCalcEdit,
                            //RepositoryControl = _gridLookUpEditCurrency
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "CurrencyId",
                            ColumnVisible = false
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "ExchangeRate",
                            ColumnVisible = false
                        });
                    }
                    #endregion

                    #region Cơ cấu vốn
                    if (_account.DetailByExpense)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "FundStructureId",
                            ColumnCaption = "Khoản chi",
                            ColumnPosition = 8,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditFundStructure,
                            AllowEdit = true,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "FundStructureId",
                            ColumnVisible = false
                        });

                    }
                    //edit by thangnd ba bảo ko xài detailbyfund
                    //gridColumnsCollection.Add(new XtraColumn
                    //{
                    //    ColumnName = "FundStructureId",
                    //    ColumnVisible = false
                    //});
                    #endregion

                    #region Số dư
                    if (_account.AccountCategoryKind == 2)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "DebitAmountOC",
                            ColumnCaption = "Dư nợ",
                            ColumnPosition = 30,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            ColumnType = UnboundColumnType.Decimal,
                            IsNumeric = true,
                            AllowEdit = true,

                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "CreditAmountOC",
                            ColumnCaption = "Dư có",
                            ColumnPosition = 31,
                            ColumnVisible = true,
                            ColumnType = UnboundColumnType.Decimal,
                            ColumnWith = 130,
                            IsNumeric = true,
                            AllowEdit = true,

                        });
                        if (_account.DetailByCurrency)
                        {
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "DebitAmount",
                                ColumnCaption = "Dư nợ (Quy đổi)",
                                ColumnPosition = 32,
                                ColumnVisible = true,
                                ColumnWith = 130,
                                ColumnType = UnboundColumnType.Decimal,
                                IsNumeric = true,
                                AllowEdit = true,
                            });
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "CreditAmount",
                                ColumnCaption = "Dư có (Quy đổi)",
                                ColumnPosition = 33,
                                ColumnVisible = true,
                                ColumnType = UnboundColumnType.Decimal,
                                ColumnWith = 130,
                                IsNumeric = true,
                                AllowEdit = true,

                            });
                        }
                        else
                        {
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "DebitAmount",
                                ColumnCaption = "Dư nợ (Quy đổi)",
                                ColumnPosition = 32,
                                ColumnVisible = false,
                                ColumnWith = 130,
                                ColumnType = UnboundColumnType.Decimal,
                                IsNumeric = true,
                                AllowEdit = true,

                            });
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "CreditAmount",
                                ColumnCaption = "Dư có (Quy đổi)",
                                ColumnPosition = 33,
                                ColumnVisible = false,
                                ColumnType = UnboundColumnType.Decimal,
                                ColumnWith = 130,
                                IsNumeric = true,
                                AllowEdit = true,

                            });
                        }
                    }
                    if (_account.AccountCategoryKind == 0)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "DebitAmountOC",
                            ColumnCaption = "Dư nợ",
                            ColumnPosition = 30,
                            ColumnVisible = true,
                            ColumnType = UnboundColumnType.Decimal,
                            ColumnWith = 130,
                            IsNumeric = true,
                            AllowEdit = true,

                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "CreditAmountOC",
                            ColumnCaption = "Dư có",
                            ColumnPosition = 31,
                            ColumnVisible = false,
                            ColumnType = UnboundColumnType.Decimal,
                            ColumnWith = 130,
                            IsNumeric = true,
                            AllowEdit = true,

                        });
                        if (_account.DetailByCurrency)
                        {
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "DebitAmount",
                                ColumnCaption = "Dư nợ (Quy đổi)",
                                ColumnPosition = 32,
                                ColumnVisible = true,
                                ColumnWith = 130,
                                ColumnType = UnboundColumnType.Decimal,
                                IsNumeric = true,
                                AllowEdit = true,

                            });
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "CreditAmount",
                                ColumnCaption = "Dư có (Quy đổi)",
                                ColumnPosition = 33,
                                ColumnVisible = false,
                                ColumnType = UnboundColumnType.Decimal,
                                ColumnWith = 130,
                                IsNumeric = true,
                                AllowEdit = true,

                            });
                        }
                        else
                        {
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "DebitAmount",
                                ColumnCaption = "Dư nợ (Quy đổi)",
                                ColumnPosition = 32,
                                ColumnVisible = false,
                                ColumnWith = 130,
                                ColumnType = UnboundColumnType.Decimal,
                                IsNumeric = true,
                                AllowEdit = true,

                            });
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "CreditAmount",
                                ColumnCaption = "Dư có (Quy đổi)",
                                ColumnPosition = 33,
                                ColumnVisible = false,
                                ColumnType = UnboundColumnType.Decimal,
                                ColumnWith = 130,
                                IsNumeric = true,
                                AllowEdit = true,

                            });
                        }
                    }
                    if (_account.AccountCategoryKind == 1)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "DebitAmountOC",
                            ColumnCaption = "Dư nợ",
                            ColumnPosition = 30,
                            ColumnVisible = false,
                            ColumnType = UnboundColumnType.Decimal,
                            ColumnWith = 130,
                            IsNumeric = true,
                            AllowEdit = true,

                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "CreditAmountOC",
                            ColumnCaption = "Dư có",
                            ColumnPosition = 31,
                            ColumnVisible = true,
                            ColumnType = UnboundColumnType.Decimal,
                            ColumnWith = 130,
                            IsNumeric = true,
                            AllowEdit = true,

                        });
                        if (_account.DetailByCurrency)
                        {
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "DebitAmount",
                                ColumnCaption = "Dư nợ (Quy đổi)",
                                ColumnPosition = 32,
                                ColumnVisible = false,
                                ColumnWith = 130,
                                ColumnType = UnboundColumnType.Decimal,
                                IsNumeric = true,
                                AllowEdit = true,
                            });
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "CreditAmount",
                                ColumnCaption = "Dư có (Quy đổi)",
                                ColumnPosition = 33,
                                ColumnVisible = true,
                                ColumnType = UnboundColumnType.Decimal,
                                ColumnWith = 130,
                                IsNumeric = true,
                                AllowEdit = true,

                            });
                        }
                        else
                        {
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "DebitAmount",
                                ColumnCaption = "Dư nợ (Quy đổi)",
                                ColumnPosition = 32,
                                ColumnVisible = false,
                                ColumnWith = 130,
                                ColumnType = UnboundColumnType.Decimal,
                                IsNumeric = true,
                                AllowEdit = true,
                            });
                            gridColumnsCollection.Add(new XtraColumn
                            {
                                ColumnName = "CreditAmount",
                                ColumnCaption = "Dư có (Quy đổi)",
                                ColumnPosition = 33,
                                ColumnVisible = false,
                                ColumnType = UnboundColumnType.Decimal,
                                ColumnWith = 130,
                                IsNumeric = true,
                                AllowEdit = true,

                            });
                        }
                    }
                    #endregion

                    #region Phí, lệ phí
                    if (_account.DetailByBudgetExpense)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetExpenseId",
                            ColumnVisible = true,
                            ColumnWith = 200,
                            ColumnCaption = "Phí lệ phí",
                            ColumnPosition = 9,
                            AllowEdit = true,
                            RepositoryControl = _gridLookUpBudgetExpense
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "BudgetExpenseId",
                            ColumnVisible = false,
                        });
                    }
                    #endregion

                    #region kế hoạch vốn
                    if (_account.DetailByCapitalPlan)
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "CapitalPlanId",
                            ColumnCaption = "kế hoạch vốn",
                            ColumnPosition = 11,
                            ColumnVisible = true,
                            ColumnWith = 130,
                            RepositoryControl = _gridLookUpEditCapitalPlan,
                            AllowEdit = true,
                        });
                    }
                    else
                    {
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "CapitalPlanId",
                            ColumnVisible = false
                        });

                    }
                    #endregion

                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccBeginningDebitAmountOC", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccBeginningDebitAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccBeginningCreditAmountOC", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccBeginningCreditAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityEAID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ApprovedDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaskId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (grdDetailView.Columns[column.ColumnName] != null)
                        {
                            if (column.ColumnVisible)
                            {
                                grdDetailView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                                grdDetailView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                                grdDetailView.Columns[column.ColumnName].Width = column.ColumnWith;
                                if (column.ColumnName != "AccountingObjectId")
                                {
                                    grdDetailView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                                }

                                //grdDetailView.Columns[column.ColumnName].Pro
                            }
                            else
                                grdDetailView.Columns[column.ColumnName].Visible = false;
                        }

                    }
                    //SetNumericFormatControl(grdDetailView,true);
                    XtraColumnCollectionHelper<OpeningAccountEntryModel>.ShowXtraColumnInGridView(gridColumnsCollection, grdDetailView);

                }
                #endregion
                grdDetailView.CustomRowCellEdit += (sender2, e2) =>
                {
                    GridView view = sender2 as GridView;
                    int editorIndex2 = (view.GetDataSourceRowIndex(e2.RowHandle));
                    if (e2.Column.FieldName == "AccountingObjectId")
                    {
                        if (editorIndex2 >= 0 && inplaceEditors.ElementAtOrDefault(editorIndex2) != null)
                        {
                            e2.RepositoryItem = inplaceEditors[editorIndex2];
                        }
                    }
                    if (e2.Column.FieldName == "ContractId")
                    {
                        if (editorIndex2 >= 0 && inplaceContractEditors.ElementAtOrDefault(editorIndex2) != null)
                        {
                            e2.RepositoryItem = inplaceContractEditors[editorIndex2];
                        }
                    }
                };
            }

        }
        List<RepositoryItemGridLookUpEdit> inplaceEditors = new List<RepositoryItemGridLookUpEdit>();
        List<RepositoryItemGridLookUpEdit> inplaceContractEditors = new List<RepositoryItemGridLookUpEdit>();
        private void grdDetailView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "AccountingObjectId")
            {
                int editorIndex = (view.GetDataSourceRowIndex(e.RowHandle));
                if (editorIndex >= 0)
                {
                    e.Column.ColumnEdit = inplaceEditors[editorIndex];

                }
            }
        }
        public List<AccountingObjectCategoryModel> OldAccountingObjectCategories { get; set; }
        public IList<AccountingObjectCategoryModel> AccountingObjectCategories
        {
            set
            {
                value.Add(
                    new AccountingObjectCategoryModel
                    {
                        AccountingObjectCategoryCode = "NV",
                        AccountingObjectCategoryName = "Nhân Viên",
                        AccountingObjectCategoryId = "00000000-0000-0000-0000-000000000000",
                        IsActive = true,
                        IsSystem = false
                    }
                );
                OldAccountingObjectCategories = value.ToList();
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
                    }
                };
                _gridLookUpEditAccountingCateObjectView = XtraColumnCollectionHelper<AccountingObjectCategoryModel>.CreateGridViewReponsitory();
                _gridLookUpEditAccountingCateObject = XtraColumnCollectionHelper<AccountingObjectCategoryModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingCateObjectView, value, "AccountingObjectCategoryName", "AccountingObjectCategoryCode", columnsCollection);
                XtraColumnCollectionHelper<AccountingObjectCategoryModel>.ShowXtraColumnInGridView(columnsCollection, _gridLookUpEditAccountingCateObjectView);

            }
        }

        private void gridViewMaster_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (GridViewInfo)grdDetailView.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

            if (e.Column == null || e.Column.FieldName != "AccountingObjectId")
                return;
            if (e.Column == viewInfo.FixedLeftColumn || e.Column == viewInfo.ColumnsInfo.LastColumnInfo.Column)
            {
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible)
                        continue;
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }

                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache),
                    rec, e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1,
                    e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Sets the opening account entries.
        /// </summary>
        /// <value>
        /// The opening account entries.
        /// </value>
        public IList<OpeningInventoryEntryModel> OpeningInventoryEntries
        {
            get
            {
                var openingInventoryEntries = new List<OpeningInventoryEntryModel>();
                openingInventoryEntries = ((IList<OpeningInventoryEntryModel>)bindingSourceDetail.DataSource).ToList();

                openingInventoryEntries.ForEach(m =>
                {
                    m.AccountNumber = _account.AccountNumber;
                    m.PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1);
                    m.CurrencyCode = m.CurrencyCode == null? GlobalVariable.MainCurrencyId : m.CurrencyCode;
                    m.ExchangeRate = m.ExchangeRate == 0? 1 : m.ExchangeRate;
                    //m.ExchangeRate = 1;
                    m.Amount = m.Amount;
                    m.AmountOC = m.AmountOC;
                    m.UnitPriceOC = m.UnitPrice;
                    m.ExpiryDate = m.PostedDate; // Chưa có hạn sử dụng nên lấy tạm giá trị này
                    m.RefType = (int)RefType.OpeningAccountEntry;
                });
                return openingInventoryEntries;
            }
            set
            {
                if (value == null || _account == null)
                    return;

                #region Theo vật tư
                if (_account.DetailByInventoryItem)
                {
                    var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                    //repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                    //repositoryNumberCalcEdit.Mask.EditMask = GlobalVariable.ExchangeRateDecimalDigits; //lay theo option
                    //repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                    repositoryNumberCalcEdit.Mask.EditMask = @"c" + GlobalVariable.ExchangeRateDecimalDigits;
                    repositoryNumberCalcEdit.Precision = int.Parse(GlobalVariable.ExchangeRateDecimalDigits);
                    int columnIndex = 0;

                    bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList();
                    grdDetailView.PopulateColumns(value);
                    #region Nguồn
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = _account.DetailByBudgetSource,
                        ColumnCaption = "Nguồn vốn",
                        ColumnPosition = columnIndex += 1,
                        AllowEdit = true,
                        ColumnWith = 250,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    });
                    #endregion
                    #region Chương
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = _account.DetailByBudgetChapter,
                        ColumnCaption = "Chương",
                        ColumnPosition = columnIndex += 1,
                        AllowEdit = true,
                        ColumnWith = 150,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    });
                    #endregion
                    #region Khoản
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = _account.DetailByBudgetKindItem,
                        ColumnCaption = "Khoản",
                        ColumnPosition = columnIndex += 1,
                        AllowEdit = true,
                        ColumnWith = 150,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    });
                    #endregion
                    #region Tiểu mục
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = _account.DetailByBudgetSubItem,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = columnIndex += 1,
                        AllowEdit = true,
                        ColumnWith = 130,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    });
                    #endregion
                    #region Mục
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = _account.DetailByBudgetItem && _account.DetailByBudgetSubItem,
                        ColumnCaption = "Mục",
                        ColumnPosition = columnIndex += 1,
                        AllowEdit = false,
                        ColumnWith = 130,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    });
                    #endregion
                    #region Công cụ
                        gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        ColumnCaption = _account.AccountNumber == "153" ? "Công cụ, dụng cụ" : "Nguyên liệu, vật liệu",
                        ColumnPosition = columnIndex += 1,
                        AllowEdit = true,
                        ColumnWith = 200,
                        RepositoryControl = _gridLookUpEditInventoryItem
                    });
                    #endregion
                    #region Kho
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "StockId",
                        ColumnVisible = true,
                        ColumnCaption = "Kho",
                        ColumnPosition = columnIndex += 1,
                        AllowEdit = false,
                        ColumnWith = 150,
                        RepositoryControl = _gridLookUpEditStock
                    });
                    #endregion
                    #region Số lượng
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = true,
                        ColumnCaption = "Số lượng",
                        ColumnPosition = columnIndex += 1,
                        AllowEdit = true,
                        ColumnWith = 80,
                        IsNumeric = true,
                        ColumnType = UnboundColumnType.Decimal
                    });
                    #endregion
                    #region Đơn giá
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnVisible = true,
                        ColumnCaption = "Đơn giá",
                        ColumnPosition = columnIndex += 1,
                        AllowEdit = true,
                        ColumnWith = 120,
                        IsNumeric = true,
                        ColumnType = UnboundColumnType.Decimal
                    });
                    #endregion
                    #region Tiền tệ
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "CurrencyCode",
                        ColumnVisible = _account.DetailByCurrency,
                        ColumnCaption = "Tiền tệ",
                        ColumnPosition = columnIndex += 2,
                        AllowEdit = true,
                        ColumnWith = 130,
                        RepositoryControl = _gridLookUpEditCurrencyCode,
                    });
                    #endregion
                    #region Tỉ giá hối đoái
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ExchangeRate",
                        ColumnVisible = _account.DetailByCurrency,
                        ColumnCaption = "Tỉ giá hối đoái",
                        ColumnPosition = columnIndex += 1,
                        AllowEdit = true,
                        ColumnWith = 130,
                        ColumnType = UnboundColumnType.Decimal,
                        IsNumeric = true,
                        RepositoryControl = repositoryNumberCalcEdit,
                    }) ;
                    #endregion   
                    #region Thành tiền
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnCaption = "Thành tiền",
                        ColumnPosition = columnIndex += 1,
                        AllowEdit = true,
                        ColumnWith = 150,
                        IsNumeric = true,
                        IsSummnary = true,
                        ColumnType = UnboundColumnType.Decimal
                    });
                    #endregion
                    #region Quy đổi
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = _account.DetailByCurrency,
                        ColumnCaption = "Quy đổi",
                        ColumnPosition = columnIndex += 3,
                        AllowEdit = false,
                        ColumnWith = 150,
                        IsNumeric = true,
                        IsSummnary = true,
                        ColumnType = UnboundColumnType.Decimal
                    });
                    #endregion


                    XtraColumnCollectionHelper<OpeningInventoryEntryModel>.ShowXtraColumnInGridView(gridColumnsCollection, grdDetailView);
                }
                #endregion
            }
        }

        /// <summary>
        /// Handles the CellValueChanged event of the grdDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void grdDetailView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (DesignMode)
                return;

            #region Theo vật tư
            if (_account.DetailByInventoryItem)
            {
                GridView view = sender as GridView;
                if (view == null)
                    return;
                // Chọn tiểu mục thì tự động nhảy mục
                if (_account.DetailByBudgetSubItem)
                {
                    if (e.Column.FieldName.Equals("BudgetSubItemCode"))
                    {
                        BudgetItemModel budgetItem = _listBudgetItems?.FirstOrDefault(m => m.BudgetItemCode.Equals(Convert.ToString(e.Value)));
                        if (budgetItem != null)
                        {
                            BudgetItemModel budgetItemParent = _listBudgetItems?.FirstOrDefault(m => m.BudgetItemId.Equals(budgetItem.ParentId));
                            view.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemParent?.BudgetItemCode);
                        }
                        else
                        {
                            view.SetRowCellValue(e.RowHandle, "BudgetItemCode", null);
                        }
                    }
                }

                if (e.Column.FieldName == "Quantity")
                {
                    var quantity = e.Value ?? 0;
                    if ((decimal)quantity == 0)
                        view.SetRowCellValue(e.RowHandle, "UnitPrice", 0);
                    else
                    {
                        var amountOC = view.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 : (decimal)view.GetRowCellValue(e.RowHandle, "Amount");
                        if (amountOC == 0)
                            view.SetRowCellValue(e.RowHandle, "UnitPrice", 0);
                        else
                            view.SetRowCellValue(e.RowHandle, "UnitPrice", amountOC / (decimal)quantity);
                    }
                }

                if (e.Column.FieldName == "Amount")
                {
                    var amountOC = e.Value ?? 0;
                    if ((decimal)amountOC == 0)
                        view.SetRowCellValue(e.RowHandle, "UnitPrice", 0);
                    else
                    {
                        var quantity = view.GetRowCellValue(e.RowHandle, "Quantity") == null ? 0 : (decimal)view.GetRowCellValue(e.RowHandle, "Quantity");
                        if (quantity == 0)
                            view.SetRowCellValue(e.RowHandle, "UnitPrice", 0);
                        else
                            view.SetRowCellValue(e.RowHandle, "UnitPrice", (decimal)amountOC / quantity);
                    }
                }

                if (e.Column.FieldName.Equals("InventoryItemId"))
                {
                    InventoryItemModel iventory = _listIventoryItems?.FirstOrDefault(m => m.InventoryItemId.Equals(Convert.ToString(e.Value)));
                    if (iventory != null)
                    {
                        view.SetRowCellValue(e.RowHandle, "StockId", iventory.DefaultStockId);
                    }
                    else
                    {
                        view.SetRowCellValue(e.RowHandle, "StockId", null);
                    }
                }
            }
            #endregion
            else
            {
                if (e.Column.FieldName == "DebitAmountOC")
                {
                    var amountOC = grdDetailView.GetRowCellValue(e.RowHandle, "DebitAmountOC") == null
                        ? 0
                        : (decimal)grdDetailView.GetRowCellValue(e.RowHandle, "DebitAmountOC");
                    var exchangeRate = (grdDetailView.GetRowCellValue(e.RowHandle, "ExchangeRate") == null || grdDetailView.GetRowCellValue(e.RowHandle, "ExchangeRate").ToString() == "0")
                        ? 1
                        : (decimal)grdDetailView.GetRowCellValue(e.RowHandle, "ExchangeRate");
                    if (exchangeRate == 0) exchangeRate = 1;
                    grdDetailView.SetRowCellValue(e.RowHandle, "DebitAmount", exchangeRate * amountOC);
                }
                if (e.Column.FieldName == "CreditAmountOC")
                {
                    var amountOC = grdDetailView.GetRowCellValue(e.RowHandle, "CreditAmountOC") == null
                        ? 0
                        : (decimal)grdDetailView.GetRowCellValue(e.RowHandle, "CreditAmountOC");
                    var exchangeRate = (grdDetailView.GetRowCellValue(e.RowHandle, "ExchangeRate") == null || grdDetailView.GetRowCellValue(e.RowHandle, "ExchangeRate").ToString() == "0")
                        ? 1
                        : (decimal)grdDetailView.GetRowCellValue(e.RowHandle, "ExchangeRate");
                    if (exchangeRate == 0) exchangeRate = 1;
                    grdDetailView.SetRowCellValue(e.RowHandle, "CreditAmount", exchangeRate * amountOC);
                }
                if (e.Column.FieldName == "BudgetSubKindItemCode")
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                        return;
                    var parentId = _budgetSubKindItemModels.FirstOrDefault(b => b.BudgetKindItemCode == e.Value.ToString()).ParentId;
                    var budgetItemCode = _budgetKindItemModels.FirstOrDefault(b => b.BudgetKindItemId == parentId).BudgetKindItemCode;
                    grdDetailView.SetRowCellValue(e.RowHandle, "BudgetKindItemCode", budgetItemCode);
                }

                if (e.Column.FieldName == "BudgetSubItemCode")
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                        return;
                    var parentId = _listBudgetItems.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                    var budgetItemCode = _listBudgetItems.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                    grdDetailView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode);
                }
                if (e.Column.FieldName == "AccountingCateObjectCode")
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                        return;
                    var accoutingObjectCate = OldAccountingObjectCategories.FirstOrDefault(b => b.AccountingObjectCategoryCode == e.Value.ToString());
                    int editorIndex = (grdDetailView.GetDataSourceRowIndex(e.RowHandle));
                    if (editorIndex >= 0)
                    {
                        if (accoutingObjectCate.AccountingObjectCategoryId == null || accoutingObjectCate.AccountingObjectCategoryId == Guid.Empty.ToString())
                        {
                            inplaceEditors[editorIndex].DataSource = OldAccountingObjects.Where(b => b.AccountingObjectCategoryId == null || b.AccountingObjectCategoryId == accoutingObjectCate.AccountingObjectCategoryId).ToList();
                        }
                        else
                        {
                            inplaceEditors[editorIndex].DataSource = OldAccountingObjects.Where(b => b.AccountingObjectCategoryId == accoutingObjectCate.AccountingObjectCategoryId).ToList();
                        }
                        grdDetailView.CustomRowCellEdit += (sender2, e2) =>
                        {
                            GridView view = sender2 as GridView;
                            int editorIndex2 = (view.GetDataSourceRowIndex(e2.RowHandle));
                            if (e2.Column.FieldName == "AccountingObjectId")
                            {
                                if (editorIndex >= 0 && inplaceEditors.ElementAtOrDefault(editorIndex2) != null)
                                {
                                    e2.RepositoryItem = inplaceEditors[editorIndex2];
                                }
                            }
                        };
                    }
                }
                if (e.Column.FieldName == "ProjectId")
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                        return;
                    int editorIndex = (grdDetailView.GetDataSourceRowIndex(e.RowHandle));
                    if (editorIndex >= 0)
                    {
                        if (OldContracts != null)
                            inplaceContractEditors[editorIndex].DataSource = OldContracts.Where(b => b.ProjectId == e.Value.ToString()).ToList();
                        grdDetailView.CustomRowCellEdit += (sender2, e2) =>
                        {
                            GridView view = sender2 as GridView;
                            int editorIndex2 = (view.GetDataSourceRowIndex(e2.RowHandle));
                            if (e2.Column.FieldName == "ContractId")
                            {
                                if (editorIndex >= 0 && inplaceContractEditors.ElementAtOrDefault(editorIndex2) != null)
                                {
                                    e2.RepositoryItem = inplaceContractEditors[editorIndex2];
                                }
                            }
                        };
                    }
                }
            }
        }

        /// <summary>
        /// Handles the InitNewRow event of the grdDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        private void grdDetailView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (_account.DetailByCurrency)
                {

                    //grdDetailView.SetRowCellValue(e.RowHandle, "CurrencyId", "E583FDB5-116D-436D-9743-6E12076847A5");
                    grdDetailView.SetRowCellValue(e.RowHandle, nameof(OpeningInventoryEntryModel.ExchangeRate), 1);
                }
                if (_account.DetailByAccountingObject)
                {
                    var newE = new RepositoryItemGridLookUpEdit();
                    var newView = new GridView();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã đối tượng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectName", ColumnCaption = "Tên đối tượng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    newView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                    newE = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(newView, OldAccountingObjects, "AccountingObjectCode", "AccountingObjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, newView);
                    inplaceEditors.Add(newE);
                    grdDetail.RepositoryItems.Add(newE);
                }
                if (_account.DetailByProject && OldContracts!=null)
                {
                    var newE = new RepositoryItemGridLookUpEdit();
                    var newView = new GridView();
                    var gridColumnsCollection2 = new List<XtraColumn>();
                    gridColumnsCollection2.Add(new XtraColumn { ColumnName = "ContractNo", ColumnCaption = "Số hợp đồng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection2.Add(new XtraColumn { ColumnName = "ContractName", ColumnCaption = "Tên hợp đồng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });
                    newView = XtraColumnCollectionHelper<ContractModel>.CreateGridViewReponsitory();
                    newE = XtraColumnCollectionHelper<ContractModel>.CreateGridLookUpEditReponsitory(newView, OldContracts, "ContractName", "ContractId", gridColumnsCollection2);
                    XtraColumnCollectionHelper<ContractModel>.ShowXtraColumnInGridView(gridColumnsCollection2, newView);
                    inplaceContractEditors.Add(newE);
                    grdDetail.RepositoryItems.Add(newE);
                }
                //Thiết lập ngầm định (AnhNT add)
                if (!string.IsNullOrEmpty(GlobalVariable.DefaultBudgetSourceID))
                    grdDetailView.SetRowCellValue(e.RowHandle, nameof(OpeningInventoryEntryModel.BudgetSourceId), GlobalVariable.DefaultBudgetSourceID);

                //Kiem tra Chuong ngam dinh co hop le hay khong truoc khi gan gia tri
                var budgetchapter = _model.GetBudgetItemByCode(GlobalVariable.DefaultBudgetChapterCode);
                if (budgetchapter != null)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.DefaultBudgetChapterCode))
                        grdDetailView.SetRowCellValue(e.RowHandle, nameof(OpeningInventoryEntryModel.BudgetChapterCode), GlobalVariable.DefaultBudgetChapterCode);
                }

                if (!string.IsNullOrEmpty(GlobalVariable.DefaultBudgetKindItemCode))
                    grdDetailView.SetRowCellValue(e.RowHandle, nameof(OpeningInventoryEntryModel.BudgetKindItemCode), GlobalVariable.DefaultBudgetKindItemCode);
                if (!string.IsNullOrEmpty(GlobalVariable.DefaultBudgetSubKindItemCode))
                    grdDetailView.SetRowCellValue(e.RowHandle, nameof(OpeningInventoryEntryModel.BudgetSubKindItemCode), GlobalVariable.DefaultBudgetSubKindItemCode);
                if (!GlobalVariable.DefaultCashWithDrawTypeID.Equals(null))
                    grdDetailView.SetRowCellValue(e.RowHandle, "CashWithdrawTypeId", GlobalVariable.DefaultCashWithDrawTypeID);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the PopupMenuShowing event of the grdDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PopupMenuShowingEventArgs"/> instance containing the event data.</param>
        private void grdDetailView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenuDetail.ShowPopup(grdDetail.PointToScreen(e.Point));
                }
            }
        }

        /// <summary>
        /// Handles the ProcessGridKey event of the grdDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdDetail_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.Equals(Keys.Control) && e.KeyCode.Equals(Keys.V))
                _flagKey = true;
            else
                _flagKey = false;
        }
        #endregion

        #region Xóa dòng chuột phải

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
                    grdDetailView.DeleteSelectedRows();
                    if (grdDetailView.SelectedRowsCount >= 0)
                    {
                        for (var i = 0; i < grdDetailView.GetSelectedRows().Length; i++)
                        {
                            if (inplaceEditors.ElementAtOrDefault(grdDetailView.GetSelectedRows()[i]) != null)
                            {

                                inplaceEditors.Remove(inplaceEditors[grdDetailView.GetSelectedRows()[i]]);
                            }
                            if (inplaceContractEditors.ElementAtOrDefault(grdDetailView.GetSelectedRows()[i]) != null)
                            {

                                inplaceContractEditors.Remove(inplaceContractEditors[grdDetailView.GetSelectedRows()[i]]);
                            }
                        }

                    }
                    break;
            }
        }

        #endregion
    }
}
