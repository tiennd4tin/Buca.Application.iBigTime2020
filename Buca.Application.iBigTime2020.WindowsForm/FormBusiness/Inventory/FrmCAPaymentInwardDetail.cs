/***********************************************************************
 * <copyright file="FrmCAPaymentInwardDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ChuongBV
 * Email:    chuongbv@buca.vn
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Cash.PaymentVoucher;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.PurchasePurpose;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using Buca.Application.iBigTime2020.View.Cash;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusiness;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory
{
    /// <summary>
    /// FrmCAPaymentInwardDetail
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Cash.ICAPaymentView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IStocksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.ICashWithdrawTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IActivitysView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IPurchasePurposesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    public partial class FrmCAPaymentInwardDetail : FrmXtraBaseVoucherDetail, IAccountingObjectsView, ICAPaymentView, IInventoryItemsView, IStocksView,
        IAccountsView, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, ICashWithdrawTypesView, IActivitysView,
        IProjectsView, IFundStructuresView, IPurchasePurposesView, IBanksView, IBudgetExpensesView, IContractsView, ICapitalPlansView, IAutoBusinessesView
    {
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
        #endregion
        public string Address
        {
            get { return txtAddress.EditValue == null ? null : txtAddress.EditValue.ToString(); }
            set { txtAddress.EditValue = value; }
        }
        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        private readonly StocksPresenter _stocksPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly CAPaymentPresenter _paymentPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;
        private readonly ActivitysPresenter _activitysPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        private readonly PurchasePurposesPresenter _purchasePurposesPresenter;
        private readonly BanksPresenter _banksPresenter;
        private readonly ContractsPresenter _contractsPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;
        List<RepositoryItemGridLookUpEdit> inplaceEditors = new List<RepositoryItemGridLookUpEdit>();

        private List<BudgetItemModel> _budgetItemModels;
        private string _mainCurrencyId;
        private decimal _exchangeRateDefault;
        private List<AccountModel> _accountModels;
        private List<InventoryItemModel> _inventoryItemModel;
        private static IModel _model;
        public List<SelectItemModel> Parallels { get; set; }
        #region RepositoryItemGridLookUpEdit

        private readonly AutoBusinessesPresenter _autoBusinessPresenter;

        private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        private GridView _gridLookUpEditContractView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCapitalPlan;
        private GridView _gridLookUpEditCapitalPlanView;

        private RepositoryItemGridLookUpEdit _gridLookUpBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItem;
        private GridView _gridLookUpEditInventoryItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditStock;
        private GridView _gridLookUpEditStockView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditTaxAccount;
        private GridView _gridLookUpEditTaxAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCreditAccount;
        private GridView _gridLookUpEditCreditAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountParallel;
        private GridView _gridLookUpEditAccountParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        private GridView _gridLookUpEditBudgetChapterView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        private GridView _gridLookUpEditBudgetSubKindItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private GridView _gridLookUpEditBudgetItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        private GridView _gridLookUpEditBudgetSubItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;
        private GridView _gridLookUpEditCashWithdrawTypeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        private GridView _gridLookUpEditAccountingObjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditPurchasePurpose;
        private GridView _gridLookUpEditPurchasePurposeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAutoBusiness;
        private GridView _gridLookUpEditDebitAutoBusinessView;

        private List<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetKindItemModel> _budgetSubKindItemModels;
        private List<ContractModel> _contractModels;

        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;
        private RepositoryItemLookUpEdit _repositoryVATRate;
        private RepositoryItemLookUpEdit _repositoryInvType;

        #endregion

        #region Form event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCAPaymentInwardDetail" /> class.
        /// </summary>
        public FrmCAPaymentInwardDetail()
        {
            InitializeComponent();

            _contractsPresenter = new ContractsPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _stocksPresenter = new StocksPresenter(this);
            _paymentPresenter = new CAPaymentPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _purchasePurposesPresenter = new PurchasePurposesPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
            _autoBusinessPresenter = new AutoBusinessesPresenter(this);
            AutoAccountingObjectId = AccountingObjectId;

            lkAccountingObjectCategory.Visible = true;
            lbAccountingObjectCategory.Visible = true;
            _model = new Model.Model();
            grdViewParallel = grdViewAccountingParallel;
            SAmountEx = "AmountExchange";
            SAmountOCEx = "Amount";
            SAmountExParallel = "AmountOC";
            SAmountOCExParallel = "Amount";
        }

        /// <summary>
        /// Handles the Load event of the FrmCAPaymentInwardDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmCAPaymentInwardDetail_Load(object sender, EventArgs e)
        {
            _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(_listAccounts, (int)BaseRefTypeId, RefTypes.ToList());
            _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(_listAccounts, (int)BaseRefTypeId, RefTypes.ToList());
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

        #endregion

        #region overrides function

        protected override void DeleteVoucher()
        {
            _paymentPresenter.Delete(KeyValue);
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Visible = true;
            grdMaster.Location = new Point(7, 198);
            tabMain.SelectedTabPage = tabInventoryItem;
            this.tabMain.Location = new System.Drawing.Point(6, 270);
            grdTax.DataSource = bindingSourceDetail;
            // this.tabMain.Location = new System.Drawing.Point(6, 270);
            //   this.tabMain.Size = new System.Drawing.Size(1888, 355);
            //tabInventoryItem.TabIndex = 1;
            //tabTax.TabIndex = 2;
            //tabAccounting.TabIndex = 3;
            //tabAccountingDetail.TabIndex = 4;

            //Tintv ẩn tab Thống kế và thuế
            //tabMain.TabPages[2].PageVisible = false;
            //tabMain.TabPages[4].PageVisible = false;
            //tabMain.TabPages[3].PageVisible = false;

            grdAccountingParallel.DataSource = bindingSourceDetailParallel;
           
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            InitRepositoryControlData();
            _contractsPresenter.Display();
            _capitalPlansPresenter.Display();
            _accountingObjectsPresenter.DisplayActive(true);
            _inventoryItemsPresenter.DisplayByIsToolAndIsStock(true);
            _stocksPresenter.DisplayByIsActive(true);
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayByIsDetail(GlobalVariable.IsPostToParentAccount);
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _activitysPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.DisplayActive(true);
            _purchasePurposesPresenter.DisplayByIsActive(true);
            _banksPresenter.DisplayActive(true);
            _budgetExpensesPresenter.DisplayActive();

            _autoBusinessPresenter.DisplayActive();
            InitRepositoryControlData();
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((CAPaymentModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((CAPaymentModel)MasterBindingSource.Current).RefId;
            }

            _paymentPresenter.Display(KeyValue, false, false, true);
            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.INInward;

            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                CurrencyCode = GlobalVariable.MainCurrencyId;
                ExchangeRate = 1;

            }
            if (inplaceEditors.Count() == 0)
            {
                AddNewRepoInventory();
            }
        }
        /// <summary>
        /// Enable the control.
        /// </summary>
        protected override void EnableControl()
        {
            cboObjectCode.Enabled = true;
        }
        /// <summary>
        /// <summary>
        /// Refresh Navigation Button.
        /// </summary>
        protected override void RefreshNavigationButton()
        {
            base.RefreshNavigationButton();
            cboObjectCode.Enabled = false;
        }
        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            //if (AccountingObjectId == null)
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingObjectId"), detailContent,
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cboObjectCode.Focus();
            //    return false;
            //}
            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(@"Bạn chưa nhập số phiếu chi", detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInwardRefNo.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(InwardRefNo))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInwardRefNo"), detailContent,
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtInwardRefNo.Focus();
            //    return false;
            //}
            var paymentDetailPurchases = CAPaymentDetailPurchases;
            if (paymentDetailPurchases.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        /// <summary>
        /// Grids the purchase cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        protected override void GridPurchaseCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string textError = "";
            IModel model = new Model.Model();


            var inventoryItemId = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "InventoryItemId");
            if (e.Column.FieldName == "InventoryItemId")
            {
                var inventoryItemModel = (InventoryItemModel)_gridLookUpEditInventoryItem.GetRowByKeyValue(e.Value);
                var inventoryItemName = inventoryItemModel == null ? "" : inventoryItemModel.InventoryItemName;
                var unit = inventoryItemModel == null ? "" : inventoryItemModel.Unit;
                if (inventoryItemId != null)
                {
                    var inventoryItem = model.GetInventoryItem(inventoryItemId);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "StockId", inventoryItem.DefaultStockId);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DebitAccount",
                        inventoryItem.InventoryAccount);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Description", inventoryItemName);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Unit", unit);
                }
            }
            if (e.Column.FieldName == "StockId")
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    return;
                var accoutingObjectCate = OldStocks.FirstOrDefault(b => b.StockId == e.Value.ToString());
                int editorIndex = (grdDetailByInventoryItemView.GetDataSourceRowIndex(e.RowHandle));
                if (editorIndex >= 0)
                {
                    if (accoutingObjectCate.StockId == null || accoutingObjectCate.StockId == Guid.Empty.ToString())
                    {
                        inplaceEditors[editorIndex].DataSource = OldInventoryItems.Where(b => b.DefaultStockId == null || b.DefaultStockId == accoutingObjectCate.StockId).ToList();
                    }
                    else
                    {
                        inplaceEditors[editorIndex].DataSource = OldInventoryItems.Where(b => b.DefaultStockId == accoutingObjectCate.StockId).ToList();
                    }
                    grdDetailByInventoryItemView.CustomRowCellEdit += (sender2, e2) =>
                    {
                        GridView view = sender2 as GridView;
                        int editorIndex2 = (view.GetDataSourceRowIndex(e2.RowHandle));
                        if (e2.Column.FieldName == "InventoryItemId")
                        {
                            if (editorIndex >= 0 && inplaceEditors.ElementAtOrDefault(editorIndex2) != null)
                            {
                                e2.RepositoryItem = inplaceEditors[editorIndex2];
                            }
                        }
                    };
                }

                if (accoutingObjectCate != null)
                {
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DebitAccount", accoutingObjectCate.DefaultAccountNumber);
                }
            }
            if (e.Column.FieldName == "Quantity")
            {
                var unitPrice = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "UnitPrice") == null ? 0 :
                    (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "UnitPrice");
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", (decimal)e.Value * unitPrice);
                // grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "InwardAmount", (decimal)e.Value * unitPrice);
            }
            if (e.Column.FieldName == "UnitPrice")
            {
                var quantity = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity") == null ? 0 :
                    (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity");
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", (decimal)e.Value * quantity);
                //grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "InwardAmount", (decimal)e.Value * quantity);
            }

            //if (e.Column.FieldName == "AmountOC")
            //{
            //    decimal totalAmountOC = 0;
            //    //grdAccounting.RefreshDataSource();
            //    for (var i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
            //    {
            //        if (e.RowHandle < 0 && e.RowHandle == i)
            //        {
            //            totalAmountOC += (decimal)e.Value;
            //        }
            //        else
            //        {
            //            var rowVoucher = (CAPaymentDetailModel)grdDetailByInventoryItemView.GetRow(i);
            //            if (rowVoucher != null)
            //                totalAmountOC += rowVoucher.AmountOC;
            //        }
            //    }
            //    if (e.RowHandle < 0 || IsCopyRow)
            //        totalAmountOC += (decimal)e.Value;
            //    gridViewMaster.SetRowCellValue(0, "TotalAmountOC", totalAmountOC);
            //}

            if (e.Column.FieldName == "BudgetSubItemCode" && e.Value != null)
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    return;
                var parentId = _budgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                var _budgetItemCode = _budgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetItemCode", _budgetItemCode);
            }
            if (e.Column.FieldName != "AccountingObjectId")
            {
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "AccountingObjectId", this.AccountingObjectId);
            }
            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var _budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetItem = _budgetItemsPresenter.GetBudgetItems().Where(x => x.BudgetItemCode == _budgetSubItemCode);
                foreach (var item in budgetItem)
                {
                    var _budgetItemCode = _budgetItemsPresenter.GetBudgetItem(item.ParentId);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetItemCode", _budgetItemCode.BudgetItemCode);
                }
            }
            if (e.Column.FieldName == "BudgetSubKindItemCode")
            {
                var _budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubKindItemCode");
                var budgetItem = _budgetSubKindItemModels.Where(x => x.BudgetKindItemCode == _budgetSubItemCode);
                foreach (var item in budgetItem)
                {
                    var _budgetKindItemCode = _budgetKindItemsPresenter.GetBudgetKindItem(item.ParentId);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetKindItemCode", _budgetKindItemCode.BudgetKindItemCode);
                }
            }

            //if (e.Column.FieldName == "ProjectId")
            //{
            //var project = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "ProjectId");
            //var contracts = _contractModels.Where(x => x.ProjectId == project).ToList();
            //if (contracts == null || contracts.Count == 0) _gridLookUpEditContract.DataSource = _contractModels.ToList();
            //else
            //{
            //    _gridLookUpEditContract.DataSource = contracts;

            //}


            //}

            if (e.Column.FieldName == "AutoBusinessId")
            {
                var autoBusinessId = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AutoBusinessId") == null ? string.Empty : grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AutoBusinessId").ToString();
                if (autoBusinessId != string.Empty)
                {
                    var autoBusiness = (AutoBusinessModel)_gridLookUpEditDebitAutoBusiness.GetRowByKeyValue(autoBusinessId);
                    if (autoBusiness != null)
                    {
                        if (autoBusiness.BudgetSourceId == "00000000-0000-0000-0000-000000000000") grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSourceId", null);
                        else
                            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSourceId", autoBusiness.BudgetSourceId);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DebitAccount", autoBusiness.DebitAccount);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "CreditAccount", autoBusiness.CreditAccount);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Description", autoBusiness.AutoBusinessName);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetChapterCode", autoBusiness.BudgetChapterCode);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetKindItemCode", autoBusiness.BudgetKindItemCode);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", autoBusiness.BudgetSubKindItemCode);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetItemCode", autoBusiness.BudgetItemCode);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetSubItemCode", autoBusiness.BudgetSubItemCode);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "MethodDistributeID", autoBusiness.MethodDistributeId);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "CashWithDrawTypeID", autoBusiness.CashWithDrawTypeId);

                    }
                }
            }
            

        }
       
        protected override void AdjustControlSize(Panel panel1, bool isPanel, bool isGrdMaster)
        {
            if (isPanel == true)
            {
                int formHeight = this.Height;
                int grVoucherHeight = groupVoucher.Height;
                int ygrVoucherHeight = groupVoucher.Location.Y;
                int yMaster = grVoucherHeight + ygrVoucherHeight + 7;
                int grMasterHeigh = 0;
                int ytabMain = 0;
                int grdLayoutHeight = 0;
                int tabMainHeight = 0;
                int tabMainWith = 0;
                int ypanel1 = 0;
                int panel1Height = 0;
                grMasterHeigh = grdMaster.Height;
                // grdMaster.Location = new Point(6, yMaster);
                ytabMain = yMaster + grMasterHeigh + 7;
                grdLayoutHeight = formHeight - yMaster - grMasterHeigh - 7;

                tabMainHeight = ((grdLayoutHeight / 10) * 6);
                tabMainWith = tabMain.Width;
                tabMain.Size = new Size(tabMainWith, (formHeight - 300) / 2);
                // tabMain.Location = new Point(6, ytabMain);

                ypanel1 = ytabMain + tabMainHeight + 15;
                panel1Height = grdLayoutHeight - tabMainHeight;
                panel1.Height = panel1Height;
                panel1.Location = new Point(6, ypanel1);
                panel1.Size = new Size(tabMainWith, ((formHeight - 300) / 2) - 35);
            }
        }
        /// <summary>
        /// Grids the tax cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        protected override void GridTaxCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "TaxRate")
                {
                    var amount = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 :
                        (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Amount");
                    var taxRate = (decimal)e.Value == -1 ? 0 : (decimal)e.Value;
                    var taxAmount = (amount * taxRate) / 100;
                    grdTaxView.SetRowCellValue(e.RowHandle, "TaxAmount", taxAmount);
                }

                else if (e.Column.FieldName.Equals("TaxAmount"))
                {
                    decimal taxAmount = (decimal)(e.Value ?? 0);
                    // Update InwardAmount
                    decimal quantity = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity") == null ? 0 :
                        (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity");
                    decimal unitPrice = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "UnitPrice") == null ? 0 :
                        (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "UnitPrice");
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "InwardAmount", taxAmount + quantity * unitPrice);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// LinhMC
        /// Initializes the detail row.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetailByInventoryItem(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                var newE = new RepositoryItemGridLookUpEdit();
                var newView = new GridView();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCode",
                    ColumnCaption = "Mã vật tư,CCDC",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemName",
                    ColumnCaption = "Tên vật tư,CCDC",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                newView = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridViewReponsitory();
                newE = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridLookUpEditReponsitory(newView, OldInventoryItems, "InventoryItemCode", "InventoryItemId", gridColumnsCollection);
                XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, newView);
                inplaceEditors.Add(newE);
                grdDetailByInventoryItem.RepositoryItems.Add(newE);
                if (_defaultDebitAccount != null)
                    view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
                if (_defaultCreditAccount != null)
                    view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddNewRepoInventory()
        {
            var newE = new RepositoryItemGridLookUpEdit();
            var newView = new GridView();
            var gridColumnsCollection = new List<XtraColumn>();
            gridColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "InventoryItemCode",
                ColumnCaption = "Mã vật tư,CCDC",
                ColumnPosition = 1,
                ColumnVisible = true,
                ColumnWith = 100
            });
            gridColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "InventoryItemName",
                ColumnCaption = "Tên vật tư,CCDC",
                ColumnPosition = 2,
                ColumnVisible = true,
                ColumnWith = 250
            });
            newView = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridViewReponsitory();
            newE = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridLookUpEditReponsitory(newView, OldInventoryItems, "InventoryItemCode", "InventoryItemId", gridColumnsCollection);
            XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, newView);
            inplaceEditors.Add(newE);
            grdDetailByInventoryItem.RepositoryItems.Add(newE);
        }
        /// <summary>
        /// Initializes the detail row for acounting detail by tax.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetailByTax(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                //view.SetRowCellValue(e.RowHandle, "InvType", 2);
                //view.SetRowCellValue(e.RowHandle, "TaxAmount", 0);
                //view.SetRowCellValue(e.RowHandle, "TaxAccount", 31131);
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
        /// <returns>System.String.</returns>
        protected override string SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = KeyValue;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = null;

            var result = new DialogResult();
            if (CAPaymentDetailParallels.Count > 0)
            {
                result = XtraMessageBox.Show("Bạn có muốn cập nhật lại định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                result = XtraMessageBox.Show("Bạn có muốn sinh tự động định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            return result == DialogResult.OK ? _paymentPresenter.Save(true) : _paymentPresenter.Save(false);
        }

        /// <summary>
        /// Reloads the parallel grid.
        /// </summary>
        protected override void ReloadParallelGrid()
        {
            _paymentPresenter.Display(KeyValue, false, false, true);
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            grdViewAccountingParallel.OptionsBehavior.Editable = isEnable;
            grdViewAccountingParallel.OptionsBehavior.ReadOnly = !isEnable;
            grdViewAccountingParallel.FocusRectStyle = DrawFocusRectStyle.None;
            grdViewAccountingParallel.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdViewAccountingParallel.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
            cboObjectCode.Enabled = isEnable;
        }

        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {

                if (e.Column.FieldName == "BudgetSubItemCode" && e.Value != null)
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                        return;
                    var parentId = _budgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                    var _budgetItemCode = _budgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                    grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", _budgetItemCode);
                }
                if (e.Column.FieldName != "AccountingObjectId")
                {
                    grdAccountingDetailView.SetRowCellValue(e.RowHandle, "AccountingObjectId", this.AccountingObjectId);
                }
                if (e.Column.FieldName == "BudgetSubItemCode")
                {
                    var _budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                    var budgetItem = _budgetItemsPresenter.GetBudgetItems().Where(x => x.BudgetItemCode == _budgetSubItemCode);
                    foreach (var item in budgetItem)
                    {
                        var _budgetItemCode = _budgetItemsPresenter.GetBudgetItem(item.ParentId);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetItemCode", _budgetItemCode.BudgetItemCode);
                    }
                }
                if (e.Column.FieldName == "BudgetSubKindItemCode")
                {
                    var _budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubKindItemCode");
                    var budgetItem = _budgetSubKindItemModels.Where(x => x.BudgetKindItemCode == _budgetSubItemCode);
                    foreach (var item in budgetItem)
                    {
                        var _budgetKindItemCode = _budgetKindItemsPresenter.GetBudgetKindItem(item.ParentId);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetKindItemCode", _budgetKindItemCode.BudgetKindItemCode);
                    }
                }
                if (e.Column.FieldName == "AutoBusinessId")
                {
                    var autoBusinessId = grdAccountingView.GetRowCellValue(e.RowHandle, "AutoBusinessId") == null ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "AutoBusinessId").ToString();
                    if (autoBusinessId != string.Empty)
                    {
                        var autoBusiness = (AutoBusinessModel)_gridLookUpEditDebitAutoBusiness.GetRowByKeyValue(autoBusinessId);
                        if (autoBusiness != null)
                        {
                            grdAccountingView.SetRowCellValue(e.RowHandle, "DebitAccount", autoBusiness.DebitAccount);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "CreditAccount", autoBusiness.CreditAccount);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSourceId", autoBusiness.BudgetSourceId);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetChapterCode", autoBusiness.BudgetChapterCode);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetKindItemCode", autoBusiness.BudgetKindItemCode);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", autoBusiness.BudgetSubKindItemCode);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", autoBusiness.BudgetItemCode);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSubItemCode", autoBusiness.BudgetSubItemCode);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "MethodDistributeID", autoBusiness.MethodDistributeId);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "CashWithDrawTypeID", autoBusiness.CashWithDrawTypeId);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ICAPaymentView
        public string Receiver { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime RefDate
        {
            get { return dtRefDate.EditValue == null ? DateTime.Now : (DateTime)dtRefDate.EditValue; }
            set { dtRefDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime PostedDate
        {
            get { return dtPostDate.EditValue == null ? DateTime.Now : (DateTime)dtPostDate.EditValue; }
            set { dtPostDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo
        {
            get { return string.IsNullOrEmpty(txtRefNo.Text) ? null : txtRefNo.Text.Trim(); }
            set { txtRefNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        public string CurrencyCode
        {
            get { return gridViewMaster.GetRowCellValue(0, "CurrencyCode") == null ? GlobalVariable.MainCurrencyId : gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString(); }
            set { gridViewMaster.SetRowCellValue(0, "CurrencyCode", value ?? GlobalVariable.MainCurrencyId); }
            //get { return string.IsNullOrEmpty(_mainCurrencyId) ? GlobalVariable.MainCurrencyId : _mainCurrencyId; }
            //set { _mainCurrencyId = value; }
        }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
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
            //get { return _exchangeRateDefault == 0 ? 1 : _exchangeRateDefault; }
            //set { _exchangeRateDefault = value; }
        }
        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>The paralell reference no.</value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the increment reference no.
        /// </summary>
        /// <value>The increment reference no.</value>
        /// 
        public string IncrementRefNo { get; set; }

        /// <summary>
        /// Gets or sets the inward reference no.
        /// </summary>
        /// <value>The inward reference no.</value>
        public string InwardRefNo

        {
            get { return string.IsNullOrEmpty(txtRefNo.Text) ? null : txtRefNo.Text.Trim(); }
            set { txtRefNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId
        {
            get { return cboObjectCode.EditValue == null ? null : cboObjectCode.EditValue.ToString(); }
            set { cboObjectCode.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo
        {
            get { return string.IsNullOrEmpty(txtDescription.Text) ? null : txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the document included.
        /// </summary>
        /// <value>The document included.</value>
        public string DocumentIncluded
        {
            get { return string.IsNullOrEmpty(txtDocumentIncluded.Text) ? null : txtDocumentIncluded.Text.Trim(); }
            set { txtDocumentIncluded.Text = value; }
        }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
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
        /// <value>The total amount oc.</value>
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
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>The total tax amount.</value>
        public decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the total freight amount.
        /// </summary>
        /// <value>The total freight amount.</value>
        public decimal TotalFreightAmount { get; set; }

        /// <summary>
        /// Gets or sets the total inward amount.
        /// </summary>
        /// <value>The total inward amount.</value>
        public decimal TotalInwardAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [posted].
        /// </summary>
        /// <value><c>true</c> if [posted]; otherwise, <c>false</c>.</value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>The relation reference identifier.</value>
        public string RelationRefId { get; set; }

        /// <summary>
        /// Gets or sets the total payment amount.
        /// </summary>
        /// <value>The total payment amount.</value>
        public decimal TotalPaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets the ca payment details.
        /// </summary>
        /// <value>The ca payment details.</value>
        public List<CAPaymentDetailModel> CaPaymentDetails { get; set; }

        /// <summary>
        /// Gets or sets the ca payment detail taxes.
        /// </summary>
        /// <value>The ca payment detail taxes.</value>
        public List<CAPaymentDetailTaxModel> CaPaymentDetailTaxes { get; set; }

        /// <summary>
        /// Gets or sets the ca payment detail purchases.
        /// </summary>
        /// <value>The ca payment detail purchases.</value>
        public List<CAPaymentDetailPurchaseModel> CAPaymentDetailPurchases
        {
            get
            {
                var paymentDetailPurchases = new List<CAPaymentDetailPurchaseModel>();

                grdDetailByInventoryItemView.CloseEditor();
                grdDetailByInventoryItemView.UpdateCurrentRow();
                grdAccountingView.CloseEditor();
                grdAccountingView.UpdateCurrentRow();
                grdAccountingDetailView.CloseEditor();
                grdAccountingDetailView.UpdateCurrentRow();
                grdTaxView.CloseEditor();
                grdTaxView.UpdateCurrentRow();

                //reset amount 
                TotalTaxAmount = 0;
                TotalInwardAmount = 0;
                TotalPaymentAmount = 0;

                if (grdDetailByInventoryItemView.DataSource != null && grdDetailByInventoryItemView.DataRowCount > 0)
                {
                    for (var i = 0; i < grdDetailByInventoryItemView.DataRowCount; i++)
                    {
                        var rowVoucher = (CAPaymentDetailPurchaseModel)grdDetailByInventoryItemView.GetRow(i);
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

                            var item = new CAPaymentDetailPurchaseModel
                            {
                                AutoBusinessId = rowVoucher.AutoBusinessId,
                                Description = string.IsNullOrEmpty(rowVoucher.Description) ? string.Empty : rowVoucher.Description.Trim(),
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount = rowVoucher.Amount,
                                StockId = rowVoucher.StockId,
                                InventoryItemId = rowVoucher.InventoryItemId,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode, //rowVoucher.BudgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                ActivityId = rowVoucher.ActivityId,
                                CashWithdrawTypeId = rowVoucher.CashWithdrawTypeId,
                                FundStructureId = rowVoucher.FundStructureId,
                                Unit = rowVoucher.Unit,
                                Quantity = rowVoucher.Quantity,
                                UnitPrice = rowVoucher.UnitPrice,
                                SortOrder = i,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ProjectId = rowVoucher.ProjectId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                BankId = rowVoucher.BankId,
                                AmountExchange = rowVoucher.AmountExchange,
                                CurrencyCode = CurrencyCode,
                                OrgRefDate= rowVoucher.OrgRefDate,
                                OrgRefNo= rowVoucher.OrgRefNo,
                            };

                            TotalInwardAmount += rowVoucher.InwardAmount;
                            paymentDetailPurchases.Add(item);
                        }
                    }
                }

                //if (grdTaxView.DataSource != null && grdTaxView.DataRowCount > 0)
                //{
                //    for (var i = 0; i < grdTaxView.DataRowCount; i++)
                //    {
                //        var rowVoucher = (CAPaymentDetailPurchaseModel)grdTaxView.GetRow(i);
                //        if (rowVoucher != null)
                //        {
                //            paymentDetailPurchases[i].TaxRate = rowVoucher.TaxRate == -1 ? null : rowVoucher.TaxRate;
                //            paymentDetailPurchases[i].TaxAmount = rowVoucher.TaxAmount;
                //            paymentDetailPurchases[i].TaxAccount = rowVoucher.TaxAccount;
                //            paymentDetailPurchases[i].InvType = rowVoucher.InvType;
                //            paymentDetailPurchases[i].InvDate = rowVoucher.InvDate;
                //            paymentDetailPurchases[i].InvoiceTypeCode = rowVoucher.InvoiceTypeCode;
                //            paymentDetailPurchases[i].InvSeries = rowVoucher.InvSeries;
                //            paymentDetailPurchases[i].PurchasePurposeId = rowVoucher.PurchasePurposeId;
                //            paymentDetailPurchases[i].InvNo = rowVoucher.InvNo;
                //            paymentDetailPurchases[i].SortOrder = i;
                //            TotalTaxAmount += rowVoucher.TaxAmount;
                //        }
                //    }
                //}

                //if (grdAccountingView.DataSource != null && grdAccountingView.DataRowCount > 0)
                //{
                //    for (var i = 0; i < grdAccountingView.DataRowCount; i++)
                //    {
                //        var rowVoucher = (CAPaymentDetailPurchaseModel)grdAccountingView.GetRow(i);
                //        if (rowVoucher != null)
                //        {
                //            var budgetKindItemCode = "";
                //            if (!string.IsNullOrEmpty(rowVoucher.BudgetSubKindItemCode))
                //            {
                //                var budgetSubKindItem = _budgetSubKindItemModels.FirstOrDefault(b => b.BudgetKindItemCode == rowVoucher.BudgetSubKindItemCode);
                //                if (budgetSubKindItem == null)
                //                    budgetKindItemCode = null;
                //                else
                //                {
                //                    var budgetKindItem = _budgetKindItemModels.FirstOrDefault(b => b.BudgetKindItemId == budgetSubKindItem.ParentId);
                //                    budgetKindItemCode = budgetKindItem == null ? null : budgetKindItem.BudgetKindItemCode;
                //                }
                //            }

                //            paymentDetailPurchases[i].BudgetSourceId = rowVoucher.BudgetSourceId;
                //            paymentDetailPurchases[i].BudgetChapterCode = rowVoucher.BudgetChapterCode;
                //            paymentDetailPurchases[i].BudgetKindItemCode = budgetKindItemCode;
                //            paymentDetailPurchases[i].BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode;
                //            paymentDetailPurchases[i].BudgetItemCode = rowVoucher.BudgetItemCode;
                //            paymentDetailPurchases[i].BudgetSubItemCode = rowVoucher.BudgetSubItemCode;
                //            paymentDetailPurchases[i].MethodDistributeId = rowVoucher.MethodDistributeId;
                //            paymentDetailPurchases[i].ActivityId = rowVoucher.ActivityId;
                //            paymentDetailPurchases[i].CashWithdrawTypeId = rowVoucher.CashWithdrawTypeId;
                //            paymentDetailPurchases[i].SortOrder = i;
                //        }
                //    }
                //}

                if (grdAccountingDetailView.DataSource != null && grdAccountingDetailView.DataRowCount > 0)
                {
                    for (var i = 0; i < grdAccountingDetailView.DataRowCount; i++)
                    {
                        var rowVoucher = (CAPaymentDetailPurchaseModel)grdAccountingDetailView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            paymentDetailPurchases[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                            paymentDetailPurchases[i].ActivityId = rowVoucher.ActivityId;
                            paymentDetailPurchases[i].ProjectId = rowVoucher.ProjectId;
                            paymentDetailPurchases[i].BudgetExpenseId = rowVoucher.BudgetExpenseId;
                            paymentDetailPurchases[i].FundStructureId = rowVoucher.FundStructureId;
                            paymentDetailPurchases[i].SortOrder = i;

                        }
                    }
                }
                TotalPaymentAmount = TotalAmount + TotalTaxAmount;

                return paymentDetailPurchases;
            }
            set
            {
                if (value == null)
                {
                    value = new List<CAPaymentDetailPurchaseModel>();
                }
                value = value.OrderBy(c => c.SortOrder).ToList();
                value.ForEach(item =>
                {

                    var newE = new RepositoryItemGridLookUpEdit();
                    var newView = new GridView();
                    var gridColumnsCollection2 = new List<XtraColumn>();
                    gridColumnsCollection2.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã vật tư, CCDC", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection2.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên vật tư, CCDC", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    newView = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridViewReponsitory();
                    newE = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridLookUpEditReponsitory(newView, OldInventoryItems.Where(b => b.DefaultStockId == item.StockId).ToList(), "InventoryItemCode", "InventoryItemId", gridColumnsCollection2);
                    XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(gridColumnsCollection2, newView);
                    inplaceEditors.Add(newE);
                    grdDetailByInventoryItem.RepositoryItems.Add(newE);
                });

                bindingSourceDetail.DataSource = value ?? new List<CAPaymentDetailPurchaseModel>();
                grdAccountingView.PopulateColumns(value);

                grdAccountingDetailView.PopulateColumns(value);

                grdDetailByInventoryItemView.PopulateColumns(value);
                grdTaxView.PopulateColumns(value);

                if (value == null || value.Count() == 0)
                {
                    value = new List<CAPaymentDetailPurchaseModel>() { new CAPaymentDetailPurchaseModel()
                    {
                        DebitAccount = _defaultDebitAccount?.AccountNumber,
                        CreditAccount = _defaultCreditAccount?.AccountNumber
                    }};
                }

                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList();


                #region columns for grdAccountingView

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {
                        ColumnName = "RefDetailId",
                        ColumnVisible = false
                    },
                    new XtraColumn {
                        ColumnName = "RefId",
                        ColumnVisible = false
                    },

                    new XtraColumn {
                        ColumnName = "AutoBusinessId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAutoBusiness,
                        ColumnWith = 200,
                        ColumnCaption = "ĐK tự động",
                        ColumnPosition = 1,
                        AllowEdit = true,
                        Alignment = HorzAlignment.Near,
                    },
                    new XtraColumn {
                        ColumnName = "StockId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditStock,
                        ColumnWith = 100,
                        ColumnCaption = "Kho",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },

                    new XtraColumn {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        //RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 150,
                        ColumnCaption = "Mã vật tư,CCDC",
                        ColumnPosition = 3,
                        AllowEdit = true},
                    new XtraColumn {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 80,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 4,
                        AllowEdit = true},
                    new XtraColumn {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,ColumnWith = 80,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCreditAccount
                    },
                    new XtraColumn {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 400,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 6,
                        AllowEdit = true,
                    },
                    new XtraColumn {
                        ColumnName = "Quantity",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số lượng",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {
                        ColumnName = "QuantityConvert",
                        ColumnVisible = false
                    },
                    new XtraColumn {
                        ColumnName = "UnitPrice",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Đơn giá",
                        ColumnPosition = 8,
                        ColumnType = UnboundColumnType.Decimal,
                        AllowEdit = true
                    },
                    new XtraColumn {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Thành tiền",
                        ColumnPosition = 9,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },

                    new XtraColumn {
                        ColumnName = "AmountExchange",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 10,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditBudgetSource,
                        ColumnWith = 200,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 111,
                        AllowEdit = true,
                        Alignment = HorzAlignment.Default,
                    },
                    new XtraColumn {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 112,
                        AllowEdit = true
                    },
                    new XtraColumn {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter,
                        ColumnWith = 200,
                        ColumnCaption = "Chương",
                        ColumnPosition = 113,
                        AllowEdit = true,
                    },


                    new XtraColumn
                            {
                                ColumnName = "BudgetSubKindItemCode",
                                ColumnVisible = true,
                                RepositoryControl = _gridLookUpEditBudgetSubKindItem,
                                ColumnWith = 200,
                                ColumnCaption = "Khoản",
                                ColumnPosition =114,
                                AllowEdit = true,
                            },
                             new XtraColumn
                            {
                                ColumnName = "BudgetSubItemCode",
                                ColumnVisible = true,
                                RepositoryControl = _gridLookUpEditBudgetSubItem,
                                ColumnWith = 200,
                                ColumnCaption = "Tiểu mục",
                                ColumnPosition = 115,
                                AllowEdit = true,
                            },

                            new XtraColumn
                            {
                                ColumnName = "BudgetItemCode",
                                ColumnVisible = true,
                                 RepositoryControl = _gridLookUpEditBudgetItem,
                                ColumnWith = 200,
                                ColumnCaption = "Mục",
                                ColumnPosition = 116,
                                AllowEdit = true,
                            },
                            new XtraColumn {
                                ColumnName = "ProjectId",
                                ColumnVisible = true,
                                RepositoryControl = _gridLookUpEditProject,
                                ColumnWith = 200,
                                ColumnCaption = "Dự án",
                                ColumnPosition = 117,
                                AllowEdit = true,
                            },
                            new XtraColumn
                            {
                                ColumnName = "AccountingObjectId",
                                ColumnVisible = true,
                                ColumnWith = 200,
                                ColumnCaption = "Đối tượng",
                                ColumnPosition = 118,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditAccountingObject
                            },
                            new XtraColumn
                            {
                                ColumnName = "FundStructureId",
                                ColumnVisible = true,
                                RepositoryControl = _gridLookUpEditFundStructure,
                                ColumnWith = 220,
                                ColumnCaption = "Khoản chi",
                                ColumnPosition = 119,
                                AllowEdit = true
                            },
                               new XtraColumn
                            {
                                ColumnName = "ContractId",
                                ColumnVisible = true,
                                RepositoryControl = _gridLookUpEditContract,
                                ColumnWith = 130,
                                ColumnCaption = "Hợp đồng",
                                ColumnPosition = 120,
                                AllowEdit = true
                            },

                               new XtraColumn {
                                   ColumnName = "CashWithdrawTypeId",
                                   ColumnVisible = true,
                                   RepositoryControl = _gridLookUpEditCashWithdrawType,
                                   ColumnWith = 200,
                                   ColumnCaption = "Nghiệp vụ",
                                   ColumnPosition = 12,
                                   AllowEdit = true,
                               },
                               new XtraColumn
                            {
                                ColumnName = "BankId",
                                ColumnVisible = true,
                                ColumnWith = 130,
                                ColumnCaption = "Tài khoản NH,KB",
                                ColumnPosition = 122,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditBank
                            },
                                new XtraColumn
                            {
                                ColumnName = "ActivityId",
                                ColumnVisible = true,
                                ColumnWith = 130,
                                ColumnCaption = "Công việc",
                                ColumnPosition = 123,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditActivity
                            },
                                  new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số hóa đơn",
                        ColumnPosition = 124,
                        AllowEdit = true,
                    },

                     new XtraColumn
                    {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Ngày hóa đơn",
                        ColumnPosition = 125,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.DateTime,
                        DisplayFormat = "dd-mm-yyyy",
                    },
                               new XtraColumn
                              {
                                  ColumnName = "AccountingObjectId",
                                  ColumnVisible = false,
                              },

                                new XtraColumn
                               {
                                    ColumnName = "MethodDistributeId",
                                    ColumnVisible = false,
                                },
                                //    new XtraColumn
                                //{
                                //    ColumnName = "BankId",
                                //    ColumnVisible = false,
                                //},
                        new XtraColumn
                        {
                            ColumnName = "OutwardPurpose",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "FundStructureId",
                            ColumnVisible = false
                        },
                                 new XtraColumn
                        {
                            ColumnName = "InventoryItemId",
                            ColumnVisible = false
                        },
                                              new XtraColumn
                            {
                                ColumnName = "BudgetKindItemCode",
                                ColumnVisible = false
                            },
                        new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                        new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TaxRate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TaxAmount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "InwardAmount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ConfrontingRefId", ColumnVisible = false},

                        new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false}
                };
                grdDetailByInventoryItemView.InitGridLayout(columnsCollection);
                SetNumericFormatControl(grdDetailByInventoryItemView, true);
                grdDetailByInventoryItemView.OptionsView.ShowFooter = true;

                #endregion

                #region columns for grdTaxView

                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        //RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 150,
                        ColumnCaption = "Mã vật tư,CCDC",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "StockId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Unit",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxRate",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Thuế suất",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _repositoryVATRate
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAmount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiền thuế",
                        ColumnPosition = 4,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditTaxAccount,
                        ColumnWith = 100,
                        ColumnCaption = "TK thuế",
                        ColumnPosition = 5,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvType", ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Loại HĐ",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _repositoryInvType
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvDate",
                        ColumnWith = 100,
                        ColumnCaption = "Ngày HĐ",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.DateTime
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvoiceTypeCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Mẫu số HĐ",
                        ColumnPosition = 8,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvSeries",
                        ColumnWith = 100,
                        ColumnCaption = "Ký hiệu HĐ",
                        ColumnPosition = 9,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "PurchasePurposeId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Nhóm HHDV",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditPurchasePurpose
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvNo",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số HĐ",
                        ColumnPosition = 11,
                        AllowEdit = true
                    },

                    new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InwardAmount",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CashWithdrawTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                      new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số hóa đơn",
                        ColumnPosition = 12,
                        AllowEdit = true,
                    },

                     new XtraColumn
                    {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Ngày hóa đơn",
                        ColumnPosition = 13,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.DateTime,
                        DisplayFormat = "dd-mm-yyyy",
                    },
                };

                grdTaxView.InitGridLayout(columnsCollection);
                SetNumericFormatControl(grdTaxView, true);
                grdTaxView.OptionsView.ShowFooter = true;
                #endregion

                #region columns for grdAccountingView

                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 150,
                        ColumnCaption = "Mã vật tư,CCDC",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 280,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "StockId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Unit",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxRate",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAmount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvType",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvDate",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvoiceTypeCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvSeries",
                        ColumnWith = 100,
                        ColumnCaption = "Ký hiệu HĐ",
                        ColumnPosition = 9,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "PurchasePurposeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvNo",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InwardAmount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 110,
                        ColumnCaption = "Chương",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false}, //chon thang subkinditem la ra kinditem
                    new XtraColumn {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 110,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 110,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 110,
                        ColumnCaption = "Mục",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                      new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số hóa đơn",
                        ColumnPosition = 13,
                        AllowEdit = true,
                    },

                     new XtraColumn
                    {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Ngày hóa đơn",
                        ColumnPosition = 14,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.DateTime,
                        DisplayFormat = "dd-mm-yyyy",
                    },
                };

                grdAccountingView.InitGridLayout(columnsCollection);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = true;
                #endregion

                #region columns for grdAccountingDetailView

                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        //RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 150,
                        ColumnCaption = "Mã vật tư,CCDC",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 280,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "StockId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Unit",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxRate",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAmount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvType",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvDate",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvoiceTypeCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvSeries",
                        ColumnWith = 100,
                        ColumnCaption = "Ký hiệu HĐ",
                        ColumnPosition = 9,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "PurchasePurposeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvNo",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InwardAmount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false}, //chon thang subkinditem la ra kinditem
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                    new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnCaption = "Hoạt động SN",
                        ColumnPosition = 4,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = true,
                        ColumnWith = 180,
                        ColumnCaption = "Dự án",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditProject
                    },
                    new XtraColumn
                    {
                        ColumnName = "ContractId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditContract,
                        ColumnWith = 130,
                        ColumnCaption = "Hợp đồng",
                        ColumnPosition = 6,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 6,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 180,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetExpenseId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Phí lệ phí",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpBudgetExpense
                    },
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                      new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 8,
                        ColumnCaption = "Số hóa đơn",
                        ColumnPosition = 120,
                        AllowEdit = true,
                    },

                     new XtraColumn
                    {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Ngày hóa đơn",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.DateTime,
                        DisplayFormat = "dd-mm-yyyy",
                    },
                };

                grdAccountingDetailView.InitGridLayout(columnsCollection);
                SetNumericFormatControl(grdAccountingDetailView, true);
                grdAccountingDetailView.OptionsView.ShowFooter = true;
                #endregion

                if (CurrencyCode == "VND")
                {
                    grdDetailByInventoryItemView.Columns.ColumnByFieldName("AmountExchange").Visible = false;
                }
                grdDetailByInventoryItemView.CustomRowCellEdit += (sender2, e2) =>
                {
                    GridView view = sender2 as GridView;
                    int editorIndex2 = (view.GetDataSourceRowIndex(e2.RowHandle));
                    if (e2.Column.FieldName == "InventoryItemId")
                    {
                        if (editorIndex2 >= 0 && inplaceEditors.ElementAtOrDefault(editorIndex2) != null)
                        {
                            e2.RepositoryItem = inplaceEditors[editorIndex2];
                        }
                    }
                };
            }
        }
        protected override void DeleteRowItemInBandedGridView()
        {
            if (grdDetailByInventoryItemView.SelectedRowsCount >= 0)
            {
                for (var i = 0; i < grdDetailByInventoryItemView.GetSelectedRows().Length; i++)
                {
                    if (inplaceEditors.ElementAtOrDefault(grdDetailByInventoryItemView.GetSelectedRows()[i]) != null)
                    {
                        inplaceEditors.Remove(inplaceEditors[grdDetailByInventoryItemView.GetSelectedRows()[i]]);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the ca payment detail fixed assets.
        /// </summary>
        /// <value>
        /// The ca payment detail fixed assets.
        /// </value>
        public List<CAPaymentDetailFixedAssetModel> CAPaymentDetailFixedAssets { get; set; }

        /// <summary>
        /// Gets or sets the ca payment detail parallels.
        /// </summary>
        /// <value>The ca payment detail parallels.</value>
        public List<CAPaymentDetailParallelModel> CAPaymentDetailParallels
        {
            get
            {
                grdAccountingParallel.RefreshDataSource();
                var paymentDetailParallels = new List<CAPaymentDetailParallelModel>();
                if (grdViewAccountingParallel.DataSource != null && grdViewAccountingParallel.DataRowCount > 0)
                {
                    for (var i = 0; i < grdViewAccountingParallel.DataRowCount; i++)
                    {
                        var rowVoucher = (CAPaymentDetailParallelModel)grdViewAccountingParallel.GetRow(i);

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
                            var item = new CAPaymentDetailParallelModel
                            {
                                AutoBusinessId = rowVoucher.AutoBusinessId,
                                Description = rowVoucher.Description,
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount = rowVoucher.Amount,
                                AmountOC = rowVoucher.AmountOC,
                                UnitPrice = rowVoucher.UnitPrice,
                                Quantity = rowVoucher.Quantity,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                CashWithdrawTypeId = rowVoucher.CashWithdrawTypeId,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ActivityId = rowVoucher.ActivityId,
                                ProjectId = rowVoucher.ProjectId,
                                Approved = true,
                                SortOrder = i,
                                OrgRefNo = rowVoucher.OrgRefNo,
                                OrgRefDate = rowVoucher.OrgRefDate,
                                BudgetExpenseId = rowVoucher.BudgetExpenseId,
                                BudgetProvideCode = rowVoucher.BudgetProvideCode,
                                BankId = rowVoucher.BankId,
                                FundStructureId = rowVoucher.FundStructureId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                

                            };
                            paymentDetailParallels.Add(item);
                            //TotalAmount += item.Amount;
                            //TotalAmountOC += item.Amount;
                        }
                    }
                }
                return paymentDetailParallels;

            }
            set
            {
                bindingSourceDetailParallel.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<CAPaymentDetailParallelModel>();
                grdViewAccountingParallel.PopulateColumns(value);

                #region columns for grdViewAccountingParallel

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {
                        ColumnName = "RefDetailId",
                        ColumnVisible = false
                    },
                    new XtraColumn {
                        ColumnName = "RefId",
                        ColumnVisible = false
                    },

                    new XtraColumn {
                        ColumnName = "AutoBusinessId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAutoBusiness,
                        ColumnWith = 200,
                        ColumnCaption = "ĐK tự động",
                        ColumnPosition = 1,
                        AllowEdit = true,
                        Alignment = HorzAlignment.Near,
                    },
                    new XtraColumn {
                        ColumnName = "StockId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditStock,
                        ColumnWith = 100,
                        ColumnCaption = "Kho",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },

                    new XtraColumn {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        //RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 150,
                        ColumnCaption = "Mã vật tư,CCDC",
                        ColumnPosition = 3,
                        AllowEdit = true},
                    new XtraColumn {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 80,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 4,
                        AllowEdit = true},
                    new XtraColumn {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,ColumnWith = 80,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCreditAccount
                    },
                    new XtraColumn {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 400,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 6,
                        AllowEdit = true,
                    },
                     new XtraColumn {
                        ColumnName = "Quantity",
                        ColumnVisible = false,
                        ColumnWith = 100,
                        ColumnCaption = "Số lượng",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {
                        ColumnName = "QuantityConvert",
                        ColumnVisible = false
                    },
                    new XtraColumn {
                        ColumnName = "UnitPrice",
                        ColumnVisible = false,
                        ColumnWith = 100,
                        ColumnCaption = "Đơn giá",
                        ColumnPosition = 8,
                        ColumnType = UnboundColumnType.Decimal,
                        AllowEdit = true
                    },
                    new XtraColumn {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Thành tiền",
                        ColumnPosition = 9,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },

                    new XtraColumn {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 11,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {
                        ColumnName = "getSourceId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditBudgetSource,
                        ColumnWith = 200,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 110,
                        AllowEdit = true,
                        Alignment = HorzAlignment.Default,
                    },
                    new XtraColumn {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 111,
                        AllowEdit = true
                    },
                    new XtraColumn {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter,
                        ColumnWith = 200,
                        ColumnCaption = "Chương",
                        ColumnPosition = 112,
                        AllowEdit = true,
                    },
                    new XtraColumn
                            {
                                ColumnName = "BudgetSubKindItemCode",
                                ColumnVisible = true,
                                RepositoryControl = _gridLookUpEditBudgetSubKindItem,
                                ColumnWith = 200,
                                ColumnCaption = "Khoản",
                                ColumnPosition =113,
                                AllowEdit = true,
                            },
                             new XtraColumn
                            {
                                ColumnName = "BudgetSubItemCode",
                                ColumnVisible = true,
                                RepositoryControl = _gridLookUpEditBudgetSubItem,
                                ColumnWith = 200,
                                ColumnCaption = "Tiểu mục",
                                ColumnPosition = 114,
                                AllowEdit = true,
                            },

                            new XtraColumn
                            {
                                ColumnName = "BudgetItemCode",
                                ColumnVisible = true,
                                 RepositoryControl = _gridLookUpEditBudgetItem,
                                ColumnWith = 200,
                                ColumnCaption = "Mục",
                                ColumnPosition = 115,
                                AllowEdit = true,
                            },
                            new XtraColumn {
                                ColumnName = "ProjectId",
                                ColumnVisible = true,
                                RepositoryControl = _gridLookUpEditProject,
                                ColumnWith = 200,
                                ColumnCaption = "Dự án",
                                ColumnPosition = 117,
                                AllowEdit = true,
                            },
                            new XtraColumn
                            {
                                ColumnName = "FundStructureId",
                                ColumnVisible = true,
                                RepositoryControl = _gridLookUpEditFundStructure,
                                ColumnWith = 220,
                                ColumnCaption = "Khoản chi",
                                ColumnPosition = 116,
                                AllowEdit = true
                            },
                               new XtraColumn
                            {
                                ColumnName = "ContractId",
                                ColumnVisible = true,
                                RepositoryControl = _gridLookUpEditContract,
                                ColumnWith = 130,
                                ColumnCaption = "Hợp đồng",
                                ColumnPosition = 118,
                                AllowEdit = true
                            },
                               new XtraColumn
                            {
                                ColumnName = "AccountingObjectId",
                                ColumnVisible = true,
                                ColumnWith = 200,
                                ColumnCaption = "Nhà cung cấp",
                                ColumnPosition = 119,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditAccountingObject
                            },
                               new XtraColumn {
                                   ColumnName = "CashWithdrawTypeId",
                                   ColumnVisible = true,
                                   RepositoryControl = _gridLookUpEditCashWithdrawType,
                                   ColumnWith = 200,
                                   ColumnCaption = "Nghiệp vụ",
                                   ColumnPosition = 12,
                                   AllowEdit = true,
                               },
                               new XtraColumn
                            {
                                ColumnName = "BankId",
                                ColumnVisible = true,
                                ColumnWith = 130,
                                ColumnCaption = "Tài khoản NH,KB",
                                ColumnPosition = 121,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditBank
                            },
                               new XtraColumn
                            {
                                ColumnName = "ActivityId",
                                ColumnVisible = true,
                                ColumnWith = 130,
                                ColumnCaption = "Công việc",
                                ColumnPosition = 122,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditActivity
                            },
                               new XtraColumn
                              {
                                  ColumnName = "AccountingObjectId",
                                  ColumnVisible = false,
                              },

                                new XtraColumn
                               {
                                    ColumnName = "MethodDistributeId",
                                    ColumnVisible = false,
                                },
                                //    new XtraColumn
                                //{
                                //    ColumnName = "BankId",
                                //    ColumnVisible = false,
                                //},
                        new XtraColumn
                        {
                            ColumnName = "OutwardPurpose",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "FundStructureId",
                            ColumnVisible = false
                        },
                                 new XtraColumn
                        {
                            ColumnName = "InventoryItemId",
                            ColumnVisible = false
                        },
                                              new XtraColumn
                            {
                                ColumnName = "BudgetKindItemCode",
                                ColumnVisible = false
                            },
                        new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                        new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TaxRate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TaxAmount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "InwardAmount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ConfrontingRefId", ColumnVisible = false},

                        new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                          new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số hóa đơn",
                        ColumnPosition = 123,
                        AllowEdit = true,
                    },

                     new XtraColumn
                    {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Ngày hóa đơn",
                        ColumnPosition = 124,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.DateTime,
                        DisplayFormat = "dd-mm-yyyy",
                    },
                };

                //grdViewAccountingParallel.InitGridLayout(columnsCollection);
                //SetNumericFormatControl(grdViewAccountingParallel, true);
                XtraColumnCollectionHelper<CAPaymentDetailParallelModel>.ShowXtraColumnInGridView(columnsCollection, grdViewAccountingParallel);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;
                bool visibale = (CurrencyCode != "VND");
                grdViewAccountingParallel.Columns["AmountOC"].Visible = visibale;
                #endregion
            }
        }

        #endregion

        #region private helper

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

            var vatRates = new Dictionary<string, string> { { "0", "0%" }, { "5", "5%" }, { "10", "10%" }, { "-1", "KCT" } };
            _repositoryVATRate = new RepositoryItemLookUpEdit
            {
                DataSource = vatRates,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryVATRate.PopulateColumns();
            _repositoryVATRate.Columns["Key"].Visible = false;

            var invoiceTypes = typeof(InvoiceType).ToList();
            _repositoryInvType = new RepositoryItemLookUpEdit
            {
                DataSource = invoiceTypes,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryInvType.PopulateColumns();
            _repositoryInvType.Columns["Key"].Visible = false;
        }

        #endregion

        #region IViews

        #region BudgetSources

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<BudgetSourceModel>();
                    else
                        value = value.Where(w => w.IsParent == false).ToList();

                    _gridLookUpEditBudgetSourceView = new GridView();
                    _gridLookUpEditBudgetSourceView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSource = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSourceView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
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
                    //Filter cho gridview
                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, value, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region BudgetChapters

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
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
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetChapter.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetChapter.View.BestFitColumns();

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
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetChapter.DisplayMember = "BudgetChapterCode";
                    _gridLookUpEditBudgetChapter.ValueMember = "BudgetChapterCode";
                    //Filter cho gridview
                    //EnableFilterForGridView<BudgetChapterModel>(_gridLookUpEditBudgetChapter, _gridLookUpEditBudgetChapterView, value, gridColumnsCollection, "BudgetChapterName", "BudgetChapterId");
                    _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region BudgetKindItems

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

                    _gridLookUpEditBudgetSubKindItemView = new GridView();
                    _gridLookUpEditBudgetSubKindItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubKindItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubKindItemView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
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
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
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
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region BudgetItems

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
                    _budgetItemModels = value.ToList();
                    //var budgetItemModels = value.Where(v => v.BudgetItemType == 2 && v.IsActive).ToList();
                    //var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3 && v.IsActive).ToList();
                    //Tintv: Chỉ hiển thị Mục/Tiểu mục thuộc "Nhóm tiểu mục 0136" 
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
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
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
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
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

        #region CashWithdrawTypeModels
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
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
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
                        ColumnWith = 350
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawNo", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SubSystemId", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditCashWithdrawType.DisplayMember = "CashWithdrawTypeName";
                    _gridLookUpEditCashWithdrawType.ValueMember = "CashWithdrawTypeId";
                    //Filter cho gridview
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

        #region AccountingObjects

        /// <summary>
        ///     Sets the accounting objects.
        /// </summary>
        /// <value>The accounting objects.</value>
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

                cboObjectCode.Properties.DataSource = accountingObjects;
                cboObjectCode.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 135,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên đối tượng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 280
                    },
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectCategoryId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Address", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Tel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Fax", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Website", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CompanyTaxCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AreaCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactTitle", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactSex", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactMobile", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactEmail", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactOfficeTel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactHomeTel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactAddress", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsEmployee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPersonal", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IdentificationNumber", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IssueDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IssueBy", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryScaleId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Insured", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LabourUnionFee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FamilyDeductionAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsCustomerVendor", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryCoefficient", ColumnVisible = false},
                    new XtraColumn {ColumnName = "NumberFamilyDependent", ColumnVisible = false},
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryForm", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryPercentRate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPayInsuranceOnSalary", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InsuranceAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsUnEmploymentInsurance", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefTypeAO", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryGrade", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField1", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField2", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField3", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField4", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField5", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPaidInsuranceForPayrollItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBornLeave", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxDepartmentName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TreasuryName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false },
                    new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false },
                    new XtraColumn { ColumnName = "AccountingObjectBanks", ColumnVisible = false }
                };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboObjectCode.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboObjectCode.Properties.SortColumnIndex = column.ColumnPosition;
                        cboObjectCode.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        cboObjectCode.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                cboObjectCode.Properties.DisplayMember = "AccountingObjectCode";
                cboObjectCode.Properties.ValueMember = "AccountingObjectId";

                #region Lookup edit accounting objects

                _gridLookUpEditAccountingObjectView = new GridView();
                _gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditAccountingObjectView,
                    TextEditStyle = TextEditStyles.Standard,
                    ShowDropDown = ShowDropDown.SingleClick,
                    ImmediatePopup = true
                };
                _gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditAccountingObject.PopupFormSize = new Size(440, 150);

                _gridLookUpEditAccountingObject.View.BestFitColumns();

                _gridLookUpEditAccountingObject.DataSource = accountingObjects;
                _gridLookUpEditAccountingObjectView.PopulateColumns(accountingObjects);

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                }
                _gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectCode";
                _gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";
                //Filter cho gridview
                _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, accountingObjects, "AccountingObjectCode", "AccountingObjectId", columnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(columnsCollection, _gridLookUpEditAccountingObjectView);

                #endregion
            }
        }

        #endregion

        #region Activitys
        /// <summary>
        /// Sets the activitys.
        /// </summary>
        /// <value>The activitys.</value>
        public IList<ActivityModel> Activitys
        {
            set
            {
                try
                {
                    _gridLookUpEditActivityView = new GridView();
                    _gridLookUpEditActivityView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditActivity = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditActivityView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditActivity.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditActivity.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditActivity.PopupFormSize = new Size(380, 150);

                    _gridLookUpEditActivity.View.BestFitColumns();

                    _gridLookUpEditActivity.DataSource = value;
                    _gridLookUpEditActivityView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ActivityCode",
                        ColumnCaption = "Mã công việc",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 130
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ActivityName",
                        ColumnCaption = "Tên công việc",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditActivityView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditActivityView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditActivityView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditActivityView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditActivity.DisplayMember = "ActivityCode";
                    _gridLookUpEditActivity.ValueMember = "ActivityId";
                    //Filter cho gridview
                    _gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                    _gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, "ActivityCode", "ActivityId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Projects
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
                    var projects = value.Where(o => o.ObjectType == 2).OrderBy(c => c.ProjectCode).ToList();
                    _gridLookUpEditProjectView = new GridView();
                    _gridLookUpEditProjectView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditProject = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditProjectView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditProject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditProject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditProject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditProject.View.BestFitColumns();

                    _gridLookUpEditProject.DataSource = projects;
                    _gridLookUpEditProjectView.PopulateColumns(projects);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectCode",
                        ColumnCaption = "Mã Dự án",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectName",
                        ColumnCaption = "Tên Dự án",
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditProject.DisplayMember = "ProjectCode";
                    _gridLookUpEditProject.ValueMember = "ProjectId";
                    //Filter cho gridview
                    _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, projects, "ProjectCode", "ProjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region FundStructures
        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>The fund structures.</value>
        public IList<FundStructureModel> FundStructures
        {
            set
            {
                try
                {
                    var data = value.Where(o => o.IsParent == false && o.Inactive == true).ToList();
                    _gridLookUpEditFundStructureView = new GridView();
                    _gridLookUpEditFundStructureView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFundStructure = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFundStructureView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditFundStructure.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFundStructure.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFundStructure.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFundStructure.View.BestFitColumns();

                    _gridLookUpEditFundStructure.DataSource = data;
                    _gridLookUpEditFundStructureView.PopulateColumns(data);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Inactive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentPeriod", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeId", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditFundStructure.DisplayMember = "FundStructureCode";
                    _gridLookUpEditFundStructure.ValueMember = "FundStructureId";
                    //Filter cho gridview
                    _gridLookUpEditFundStructureView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();
                    _gridLookUpEditFundStructure = XtraColumnCollectionHelper<FundStructureModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, data, "FundStructureCode", "FundStructureId", gridColumnsCollection);
                    XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region PurchasePurposes

        /// <summary>
        /// Gets the purchase purposes.
        /// </summary>
        /// <value>The purchase purposes.</value>
        public IList<PurchasePurposeModel> PurchasePurposes
        {
            set
            {
                try
                {
                    _gridLookUpEditPurchasePurposeView = new GridView();
                    _gridLookUpEditPurchasePurposeView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditPurchasePurpose = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditPurchasePurposeView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditPurchasePurpose.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditPurchasePurpose.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditPurchasePurpose.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditPurchasePurpose.View.BestFitColumns();

                    _gridLookUpEditPurchasePurpose.DataSource = value;
                    _gridLookUpEditPurchasePurposeView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "PurchasePurposeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "PurchasePurposeCode",
                        ColumnCaption = "Mã nhóm",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "PurchasePurposeName",
                        ColumnCaption = "Tên nhóm",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditPurchasePurpose.DisplayMember = "PurchasePurposeName";
                    _gridLookUpEditPurchasePurpose.ValueMember = "PurchasePurposeId";
                    //Filter cho gridview
                    _gridLookUpEditPurchasePurposeView = XtraColumnCollectionHelper<PurchasePurposeModel>.CreateGridViewReponsitory();
                    _gridLookUpEditPurchasePurpose = XtraColumnCollectionHelper<PurchasePurposeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditPurchasePurposeView, value, "PurchasePurposeName", "PurchasePurposeId", gridColumnsCollection);
                    XtraColumnCollectionHelper<PurchasePurposeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditPurchasePurposeView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
        public List<InventoryItemModel> OldInventoryItems { get; set; }
        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>The inventory items.</value>
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                try
                {
                    _inventoryItemModel = value.ToList();
                    _gridLookUpEditInventoryItemView = new GridView();
                    _gridLookUpEditInventoryItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditInventoryItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditInventoryItemView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditInventoryItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditInventoryItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditInventoryItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditInventoryItem.View.BestFitColumns();
                    OldInventoryItems = value.ToList();
                    _gridLookUpEditInventoryItem.DataSource = value;
                    _gridLookUpEditInventoryItemView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemCode",
                        ColumnCaption = "Mã vật tư,CCDC",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemName",
                        ColumnCaption = "Tên vật tư,CCDC",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });

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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaxRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsService", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTaxable", ColumnVisible = false });

                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsStock", ColumnVisible = false });
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditInventoryItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Visible = false;
                    //}
                    XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInventoryItemView);
                    _gridLookUpEditInventoryItem.DisplayMember = "InventoryItemCode";
                    _gridLookUpEditInventoryItem.ValueMember = "InventoryItemId";
                    //Filter cho gridview
                    _gridLookUpEditInventoryItemView = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditInventoryItem = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInventoryItemView, value, "InventoryItemCode", "InventoryItemId", gridColumnsCollection);
                    XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInventoryItemView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public List<StockModel> OldStocks { get; set; }
        /// <summary>
        /// Sets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public IList<StockModel> Stocks
        {
            set
            {
                try
                {
                    _gridLookUpEditStockView = new GridView();
                    _gridLookUpEditStockView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditStock = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditStockView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditStock.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditStock.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditStock.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditStock.View.BestFitColumns();
                    OldStocks = value.ToList();
                    _gridLookUpEditStock.DataSource = value;
                    _gridLookUpEditStockView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "StockCode",
                        ColumnCaption = "Mã kho",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "StockName",
                        ColumnCaption = "Tên kho",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultAccountNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditStockView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditStockView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditStockView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditStockView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditStock.DisplayMember = "StockName";
                    _gridLookUpEditStock.ValueMember = "StockId";
                    //Filter cho gridview
                    _gridLookUpEditStockView = XtraColumnCollectionHelper<StockModel>.CreateGridViewReponsitory();
                    _gridLookUpEditStock = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditStockView, value, "StockCode", "StockId", gridColumnsCollection);
                    XtraColumnCollectionHelper<StockModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditStockView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region IAccountsView

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                try
                {
                    _listAccounts = value.ToList();
                    _accountModels = value.ToList();

                    var debitAccounts = value.ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var creditAccounts = value.ToList().CreditAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var parallelAccounts = value.ToList().ParallelAccounts();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "Số tài khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });


                    _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);

                    _gridLookUpEditCreditAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCreditAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCreditAccountView, creditAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCreditAccountView);

                    _gridLookUpEditAccountParallelView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAccountParallel = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountParallelView, parallelAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountParallelView);
                    _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(_listAccounts, (int)BaseRefTypeId, RefTypes.ToList());
                    _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(_listAccounts, (int)BaseRefTypeId, RefTypes.ToList());

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Banks

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

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        #endregion

        #region BudgetExpenses
        public IList<BudgetExpenseModel> BudgetExpenses
        {
            set
            {
                _gridLookUpEditBudgetExpenseView = new GridView();
                _gridLookUpEditBudgetExpenseView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpBudgetExpense = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditBudgetExpenseView,
                    TextEditStyle = TextEditStyles.Standard,
                };
                _gridLookUpBudgetExpense.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpBudgetExpense.View.OptionsView.ShowIndicator = false;
                _gridLookUpBudgetExpense.PopupFormSize = new Size(368, 150);

                _gridLookUpBudgetExpense.View.BestFitColumns();

                _gridLookUpBudgetExpense.DataSource = value;
                _gridLookUpEditBudgetExpenseView.PopulateColumns(value);
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetExpenseCode",
                    ColumnCaption = "Mã",
                    ColumnPosition = 0,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetExpenseName",
                    ColumnCaption = "Tên phí, lệ phí",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseId", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseType", ColumnVisible = false });
                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Visible = false;
                }
                _gridLookUpBudgetExpense.DisplayMember = "BudgetExpenseName";
                _gridLookUpBudgetExpense.ValueMember = "BudgetExpenseId";
                //Filter cho gridview
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
                _contractModels = value.ToList();
                if (value == null)
                    value = new List<ContractModel>();
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
                _gridLookUpEditContract.EndUpdate();
            }
        }

        public IList<AutoBusinessModel> AutoBusinesses
        {
            set
            {
                try
                {
                    var data = value.Where(o => o.RefTypeId == (int)BuCA.Enum.RefType.INInward).ToList();
                    _gridLookUpEditDebitAutoBusinessView = new GridView();
                    _gridLookUpEditDebitAutoBusinessView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditDebitAutoBusiness = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditDebitAutoBusinessView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditDebitAutoBusiness.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDebitAutoBusiness.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDebitAutoBusiness.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditDebitAutoBusiness.View.BestFitColumns();

                    _gridLookUpEditDebitAutoBusiness.DataSource = data;
                    _gridLookUpEditDebitAutoBusinessView.PopulateColumns(data);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                        {
                            ColumnName = "AutoBusinessCode",
                            ColumnCaption = "Mã",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 150
                        },
                        new XtraColumn
                        {
                            ColumnName = "AutoBusinessName",
                            ColumnCaption = "ĐK tự động",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 300
                        },

                        new XtraColumn {ColumnName = "AutoBusinessID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RefTypeID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DebitAccount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "MethodDistributeID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CashWithDrawTypeID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    };

                    //foreach (var column in gridColumnsCollection)
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Visible = false;
                    //    }
                    //_gridLookUpEditBudgetExpense.DisplayMember = "BudgetExpenseName";
                    //_gridLookUpEditBudgetExpense.ValueMember = "BudgetExpenseId";

                    _gridLookUpEditDebitAutoBusinessView = XtraColumnCollectionHelper<AutoBusinessModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAutoBusiness = XtraColumnCollectionHelper<AutoBusinessModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAutoBusinessView, data, "AutoBusinessCode", "AutoBusinessId", gridColumnsCollection);
                    XtraColumnCollectionHelper<AutoBusinessModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAutoBusinessView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
        #endregion

        #region Events control

        /// <summary>
        /// Handles the EditValueChanged event of the cboObjectCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboObjectCode_EditValueChanged(object sender, EventArgs e)
        {
            if (cboObjectCode.EditValue == null)
                return;
            var accountName = (string)cboObjectCode.GetColumnValue("AccountingObjectName");
            var address = (string)cboObjectCode.GetColumnValue("Address");

            cboObjectName.Text = accountName;
            txtAddress.Text = address;

            for (int i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
            {
                grdDetailByInventoryItemView.SetRowCellValue(i, "AccountingObjectId", cboObjectCode.EditValue);
            }

            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoAccountingObjectId = AccountingObjectId;
                SetDetailFromMaster(grdAccountingView, 1, AccountingObjectId, BankId, null);
            }


        }

        #region grdViewAccountingParallel

        /// <summary>
        /// Handles the CellValueChanged event of the grdViewAccountingParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void grdViewAccountingParallel_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (DesignMode)
                return;
            if (e.Column.FieldName == "Amount")
            {
                var amount = grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 : (decimal)grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "Amount");
                var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null ? 1 : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "AmountOC", exchangeRate * amount);
            }

            if (e.Column.FieldName == "BudgetSubItemCode" && e.Value != null)
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    return;
                var parentId = _budgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                var budgetItemCode = _budgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode);
            }
        }

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the grdViewAccountingParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        private void grdViewAccountingParallel_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (GridViewInfo)grdViewAccountingParallel.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            if (e.Column == null)
                return;
            if (e.Column == viewInfo.FixedLeftColumn || e.Column == viewInfo.ColumnsInfo.LastColumnInfo.Column)
            {
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible)
                        continue;
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }
                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache), rec, e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the InitNewRow event of the grdViewAccountingParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        private void grdViewAccountingParallel_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;

                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(CAPaymentDetailParallelModel.BudgetSourceId), GlobalVariable.DefaultBudgetSourceID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(CAPaymentDetailParallelModel.BudgetChapterCode), GlobalVariable.DefaultBudgetChapterCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(CAPaymentDetailParallelModel.BudgetKindItemCode), GlobalVariable.DefaultBudgetKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(CAPaymentDetailParallelModel.BudgetSubKindItemCode), GlobalVariable.DefaultBudgetSubKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(CAPaymentDetailParallelModel.CashWithdrawTypeId), GlobalVariable.DefaultCashWithDrawTypeID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(CAPaymentDetailParallelModel.MethodDistributeId), GlobalVariable.DefaultMethodDistributeID);


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void FrmCAPaymentInwardDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(panel1, true, false);
        }

        protected override void LkAccountingObjectCategory_EditValueChanged(object sender, EventArgs e)
        {
            _accountingObjectsPresenter.DisplayActive(true);
            CAPaymentDetailPurchases = CAPaymentDetailPurchases;
        }

        /// <summary>
        /// Thêm mới đối tượng từ combobox
        /// </summary>
        protected override void ShowAccountingObjectDetail()
        {
            if (!lkAccountingObjectCategory.ItemIndex.Equals(-1))
            {
                if (lkAccountingObjectCategory.Text.Equals("NV")) //Thêm nhân viên
                {
                    using (var frmDetail = new FrmEmployeeDetail())
                    {
                        frmDetail.ShowDialog();
                        if (frmDetail.CloseBox)
                        {
                            if (!string.IsNullOrEmpty(GlobalVariable.EmployeeIDDetailForm))
                            {
                                _accountingObjectsPresenter.Display();
                                cboObjectCode.EditValue = GlobalVariable.EmployeeIDDetailForm;
                                grdDetailByInventoryItemView.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
                                grdViewAccountingParallel.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
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
                                cboObjectCode.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                                grdDetailByInventoryItemView.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
                                grdViewAccountingParallel.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
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
        #endregion

        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }

        protected override void HiddenParallelAndOpenByCurrencyCode(object sender, CellValueChangedEventArgs e)
        {
            //grdDetailByInventoryItemView.Columns.ColumnByFieldName("AmountExchange").Visible = false;
            bool visibale = !e.Value.ToString().Equals("VND");
            grdDetailByInventoryItemView.Columns.ColumnByFieldName("AmountExchange").Visible = visibale;
            ShowAmountByCurrencyCode(grdViewAccountingParallel, "AmountOC", visibale);
            ShowAmountByCurrencyCode(grdDetailByInventoryItemView, "Amount", true);
            ShowAmountByCurrencyCode(grdViewAccountingParallel, "Amount", true);
            //ShowAmountByCurrencyCode(grdDetailByInventoryItemView, "AmountExchange", visibale);
        }
        protected override void GridPurchaseShowEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            CAPaymentDetailPurchaseModel data = view.GetFocusedRow() as CAPaymentDetailPurchaseModel;
            if (view.FocusedColumn.FieldName == "ContractId" && view.ActiveEditor is GridLookUpEdit)
            {
                GridLookUpEdit editor = view.ActiveEditor as GridLookUpEdit;
                if (data != null && !string.IsNullOrEmpty(data.ProjectId))
                {
                    var contracts = _contractModels.Where(x => x.ProjectId == data.ProjectId).ToList();
                    if (contracts == null || contracts.Count == 0) editor.Properties.DataSource = _contractModels;
                    else
                    {
                        editor.Properties.DataSource = contracts;
                    }
                }
                else
                {
                    editor.Properties.DataSource = _contractModels;
                }
            }
        }
    }
}