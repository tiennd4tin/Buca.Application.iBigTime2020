using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
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
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
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
using Buca.Application.iBigTime2020.Presenter.Dictionary.InvoiceFormNumber;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.FixedAsset
{
    public partial class FrmCAPaymentFixedAssetDetail : FrmXtraBaseVoucherDetail, IAccountingObjectsView, ICAPaymentView, IInventoryItemsView, IStocksView,
        IAccountsView, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, ICashWithdrawTypesView, IActivitysView,
        IProjectsView, IFundStructuresView, IPurchasePurposesView, IFixedAssetsView, IDepartmentsView, IBanksView, IInvoiceFormNumbersView, IBudgetExpensesView, IContractsView, ICapitalPlansView
    {
        #region Variable
        /// <summary>
        /// Dùng để ghi tăng tự động TSCĐ
        /// </summary>
        public List<CAPaymentDetailFixedAssetModel> ListSendSourceDetail;
        public List<CAPaymentDetailParallelModel> ListSendSourceDetailParallel;
        public decimal totalAmountDelegate;
        public decimal totalAmountOCDelegate;
        public bool IsOpenFromFixedAssetDetail;
        private List<AccountModel> _accountModels;
        public string _accountingObjectId;
        public string _journalMemo;
        #endregion

        #region Tài khoản ngầm định
        /// <summary>
        /// Tài khoản nợ ngầm định
        /// </summary>
        AccountModel _defaultDebitAccount;

        /// <summary>
        /// Tài khoản có ngầm định
        /// </summary>
        AccountModel _defaultCreditAccount;
        private IList<BudgetItemModel> _budgetItemModels;
        #endregion
        public string Address { get; set; }
        public List<SelectItemModel> Parallels { get; set; }
        private readonly ContractsPresenter _contractsPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;
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
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly BanksPresenter _banksPresenter;
        private readonly InvoiceFormNumbersPresenter _invoiceFormNumbersPresenter;
        private string _fixedAssetId;
        private readonly IModel _model;

        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        private GridView _gridLookUpEditContractView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCapitalPlan;
        private GridView _gridLookUpEditCapitalPlanView;

        private RepositoryItemGridLookUpEdit _gridLookUpBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItem;
        private GridView _gridLookUpEditInventoryItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditStock;
        private GridView _gridLookUpEditStockView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCreditAccount;
        private GridView _gridLookUpEditCreditAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountParallel;
        private GridView _gridLookUpEditAccountParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditTaxAccount;
        private GridView _gridLookUpEditTaxAccountView;

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

        private List<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;
        private GridView _gridLookUpEditFixedAssetView;


        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        private GridView _gridLookUpEditDepartmentView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditInvoiceFormNumber;
        private GridView _gridLookUpEditInvoiceFormNumberView;

        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;
        private RepositoryItemLookUpEdit _repositoryVATRate;
        private RepositoryItemLookUpEdit _repositoryInvType;

        #endregion

        public FrmCAPaymentFixedAssetDetail()
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
            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _invoiceFormNumbersPresenter = new InvoiceFormNumbersPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);

            AutoBankId = BankId;
            AutoAccountingObjectId = AccountingObjectId;
            lkAccountingObjectCategory.Visible = true;
            lbAccountingObjectCategory.Visible = true;
            _model = new Model.Model();
            this.grdDetailByInventoryItemView.InitNewRow += GrdAccountingView_InitNewRow;

        }
        private void GrdAccountingView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            InitDetailRow(e, grdAccountingView);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCAPaymentFixedAssetDetail"/> class.
        /// </summary>
        public FrmCAPaymentFixedAssetDetail(int refType)
        {
            InitializeComponent();
            RefType = refType;
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
            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _invoiceFormNumbersPresenter = new InvoiceFormNumbersPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);

            AutoBankId = BankId;
            AutoAccountingObjectId = AccountingObjectId;
            lkAccountingObjectCategory.Visible = true;
            lbAccountingObjectCategory.Visible = true;
            _model = new Model.Model();
        }
        private void FrmInitCmponent()
        {

        }
        public FrmCAPaymentFixedAssetDetail(string fixedAssetId)
        {
            InitializeComponent();
            _fixedAssetId = fixedAssetId;
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
            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);

        }

        #region overrides function

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Location = new System.Drawing.Point(7, 200);
            tabMain.SelectedTabPage = tabInventoryItem;
            grdTax.DataSource = bindingSourceDetail;
            if (string.IsNullOrEmpty(_fixedAssetId))
            {
                bindingSourceDetail.AddNew();
            }

            tabInventoryItem.TabIndex = 1;
            tabTax.TabIndex = 2;
            txtAddress.Size = new System.Drawing.Size(123, 20);
            tabAccounting.TabIndex = 3;
            tabAccountingDetail.TabIndex = 4;
            grdAccountingParallel.DataSource = bindingSourceDetailParallel;
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            SAmountEx = "ExchangeAmount";
            SAmountOCEx = "Amount";//Amount
            SAmountExParallel = "Amount";
            SAmountOCExParallel = "AmountOC";
            grdViewParallel = grdViewAccountingParallel;

            InitRepositoryControlData();

            _contractsPresenter.Display();
            _capitalPlansPresenter.Display();
            _invoiceFormNumbersPresenter.DisplayActive();
            _accountingObjectsPresenter.DisplayActive(true);
            _inventoryItemsPresenter.Display();
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
            _fixedAssetsPresenter.DisplayByActive(true);
            _departmentsPresenter.Display();
            _budgetExpensesPresenter.DisplayActive();

            _banksPresenter.Display();
            //  InitRepositoryControlData();

            //_paymentPresenter.Display(KeyValue, false, false, false, true);

            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = null;
            else
            {
                if (MasterBindingSource != null)
                    if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((CAPaymentModel)MasterBindingSource.Current).RefId;

            }

            _paymentPresenter.Display(KeyValue, false, false, false, true);
            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                CurrencyCode = GlobalVariable.MainCurrencyId;
                ExchangeRate = 1;
                if (RefType == null || RefType == 0)
                {
                    RefType = (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset;
                }

            }
            if ((int)(BuCA.Enum.RefType)RefType == 252)
                RefType = (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset;
            BaseRefTypeId = (BuCA.Enum.RefType)RefType;
            RefTypeUsingDisplayReport = (BuCA.Enum.RefType)RefType;
            if (ActionMode == ActionModeVoucherEnum.LinkVoucher)
            {
                AccountingObjectId = _accountingObjectId;
                JournalMemo = _journalMemo;
            }
            if (RefId == null && grdAccountingView.RowCount == 0)
            {
                grdAccountingView.AddNewRow();
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
        /// Enable the control.
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

            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            var paymentDetailFixedAssets = CAPaymentDetailFixedAssets;
            if (paymentDetailFixedAssets.Count == 0)
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
            IModel model = new Model.Model();
            if (e.Column.FieldName == "FixedAssetId")
            {
                // var inventoryItemModel = (FixedAssetModel)_gridLookUpEditInventoryItem.GetRowByKeyValue(e.Value);
                var fixedAssetModel = model.GetFixedAssetById(e.Value.ToString());
                var fixedAssetName = fixedAssetModel == null ? "" : fixedAssetModel.FixedAssetName;
                var unit = fixedAssetModel == null ? "" : fixedAssetModel.Unit;
                var amount = fixedAssetModel == null ? 0 : fixedAssetModel.OrgPrice;


                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Description", fixedAssetName);
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Unit", unit);
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", amount);
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "OrgPrice", amount);
                if (fixedAssetModel != null)
                {
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DepartmentId", fixedAssetModel.DepartmentId);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DebitAccount", fixedAssetModel.OrgPriceAccount);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetSourceId", GlobalVariable.DefaultBudgetSourceID);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetChapterCode", string.IsNullOrEmpty(fixedAssetModel.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : fixedAssetModel.BudgetChapterCode);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetKindItemCode", string.IsNullOrEmpty(fixedAssetModel.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : fixedAssetModel.BudgetKindItemCode);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", string.IsNullOrEmpty(fixedAssetModel.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : fixedAssetModel.BudgetSubKindItemCode);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetSubItemCode", fixedAssetModel.BudgetSubItemCode);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetItemCode", fixedAssetModel.BudgetItemCode);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "MethodDistributeId", GlobalVariable.DefaultMethodDistributeID);
                    //grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "CashWithdrawTypeId", GlobalVariable.DefaultCashWithDrawTypeID);
                }

                //bindingSourceDetail.ResetBindings(false);
            }
            if (e.Column.FieldName == "Quantity")
            {
                var unitPrice = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "OrgPrice") == null ? 0 :
                    (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "OrgPrice");
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", (decimal)e.Value * unitPrice);
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "InwardAmount", (decimal)e.Value * unitPrice);
            }
            if (e.Column.FieldName == "OrgPrice")
            {
                var quantity = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity") == null ? 0 :
                    (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity");
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", (decimal)e.Value * quantity);
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "InwardAmount", (decimal)e.Value * quantity);
            }
           
            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetItem = model.GetBudgetItems().Where(x => x.BudgetItemCode == budgetSubItemCode);

                foreach (var item in budgetItem)
                {
                    var budgetItemCode = model.GetBudgetItem(item.ParentId);
                    grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode.BudgetItemCode);
                }

            }
          
        }

        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //string textError = "";
            IModel model = new Model.Model();

          
            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var _budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetItem = model.GetBudgetItems().Where(x => x.BudgetItemCode == _budgetSubItemCode);

                foreach (var item in budgetItem)
                {
                    var _budgetItemCode = model.GetBudgetItem(item.ParentId);
                    grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", _budgetItemCode.BudgetItemCode);
                }

            }
        }

        /// <summary>
        /// Grids the tax cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        protected override void GridTaxCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "TaxRate")
            {
                var amount = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 :
                    (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Amount");
                var taxRate = e.Value ?? 0;
                var taxAmount = (amount * (decimal)taxRate) / 100;
                grdTaxView.SetRowCellValue(e.RowHandle, "TaxAmount", taxAmount);
            }
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

        /// <summary>
        /// Initializes the detail row for acounting detail.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetail(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                if (_defaultDebitAccount != null)
                    view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
                if (_defaultCreditAccount != null)
                    view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
                //InitNewRow(e, view);
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
            _paymentPresenter.Display(KeyValue, false, false, false, true);
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
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new CAPaymentPresenter(null).Delete(KeyValue);
        }

        #endregion

        #region ICAPaymentView

        public string Receiver
        {
            get { return txtReceiver.Text; }
            set { txtReceiver.Text = value; }
        }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }
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
            get { return txtRefNo.Text; }
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
        public string IncrementRefNo
        {
            get { return txtIncreaseRefNo.Text; }
            set { txtIncreaseRefNo.Text = value; }
        }
        /// <summary>
        /// Gets or sets the inward reference no.
        /// </summary>
        /// <value>The inward reference no.</value>
        public string InwardRefNo

        {
            get;
            set;
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
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the document included.
        /// </summary>
        /// <value>The document included.</value>
        public string DocumentIncluded
        {
            get { return txtDocumentIncluded.Text; }
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
        /// Gets or sets the ca payment detail fixed assets.
        /// </summary>
        /// <value>The ca payment detail fixed assets.</value>
        /// 
        public IList<InvoiceFormNumberModel> InvoiceFormNumbers
        {
            set
            {
                try
                {
                    _gridLookUpEditInvoiceFormNumberView = new GridView();
                    _gridLookUpEditInvoiceFormNumberView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditInvoiceFormNumber = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditInvoiceFormNumberView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditInvoiceFormNumber.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditInvoiceFormNumber.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditInvoiceFormNumber.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditInvoiceFormNumber.View.BestFitColumns();

                    _gridLookUpEditInvoiceFormNumber.DataSource = value;
                    _gridLookUpEditInvoiceFormNumberView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvoiceFormNumberId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InvoiceFormNumberCode",
                        ColumnCaption = "Mã mẫu số HĐ",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InvoiceFormNumberName",
                        ColumnCaption = "Tên mẫu số HĐ",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvoiceType", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditInvoiceFormNumberView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditInvoiceFormNumberView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditInvoiceFormNumberView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditInvoiceFormNumberView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditInvoiceFormNumber.DisplayMember = "InvoiceFormNumberCode";
                    _gridLookUpEditInvoiceFormNumber.ValueMember = "InvoiceFormNumberId";
                    //Filter cho gridview
                    _gridLookUpEditInvoiceFormNumberView = XtraColumnCollectionHelper<InvoiceFormNumberModel>.CreateGridViewReponsitory();
                    _gridLookUpEditInvoiceFormNumber = XtraColumnCollectionHelper<InvoiceFormNumberModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInvoiceFormNumberView, value, "InvoiceFormNumberCode", "InvoiceFormNumberId", gridColumnsCollection);
                    XtraColumnCollectionHelper<InvoiceFormNumberModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInvoiceFormNumberView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public List<CAPaymentDetailFixedAssetModel> CAPaymentDetailFixedAssets
        {
            get
            {
                grdAccountingParallel.RefreshDataSource();
                var paymentDetailFixedAssets = new List<CAPaymentDetailFixedAssetModel>();
                if (grdDetailByInventoryItemView.DataSource != null && grdDetailByInventoryItemView.RowCount > 0)
                {
                    for (var i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
                    {
                        var rowVoucher = (CAPaymentDetailFixedAssetModel)grdDetailByInventoryItemView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var item = new CAPaymentDetailFixedAssetModel
                            {
                                FixedAssetId = rowVoucher.FixedAssetId,
                                Description = rowVoucher.Description,
                                DepartmentId = rowVoucher.DepartmentId,
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                OrgPrice = rowVoucher.OrgPrice,
                                BankId = rowVoucher.BankId,
                                Amount = rowVoucher.Amount,
                                TaxRate = rowVoucher.TaxRate,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                Quantity = rowVoucher.Quantity,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                CashWithdrawTypeId = rowVoucher.CashWithdrawTypeId,
                                BudgetExpenseId = rowVoucher.BudgetExpenseId,
                                SortOrder = i,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ProjectId = rowVoucher.ProjectId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                FundStructureId = rowVoucher.FundStructureId,
                                ActivityId= rowVoucher.ActivityId,
                                ExchangeAmount= rowVoucher.ExchangeAmount,
                                OrgRefDate= rowVoucher.OrgRefDate,
                                OrgRefNo=rowVoucher.OrgRefNo,
                            };
                            paymentDetailFixedAssets.Add(item);
                        }
                    }
                }

                if (grdTaxView.DataSource != null && grdTaxView.RowCount > 0)
                {
                    for (var i = 0; i < grdTaxView.RowCount; i++)
                    {
                        var rowVoucher = (CAPaymentDetailFixedAssetModel)grdTaxView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            paymentDetailFixedAssets[i].TaxAmount = rowVoucher.TaxAmount;
                            paymentDetailFixedAssets[i].TaxAccount = rowVoucher.TaxAccount;
                            paymentDetailFixedAssets[i].InvType = rowVoucher.InvType;
                            paymentDetailFixedAssets[i].InvDate = rowVoucher.InvDate;
                            paymentDetailFixedAssets[i].InvoiceTypeCode = rowVoucher.InvoiceTypeCode;
                            paymentDetailFixedAssets[i].InvSeries = rowVoucher.InvSeries;
                            paymentDetailFixedAssets[i].PurchasePurposeId = rowVoucher.PurchasePurposeId;
                            paymentDetailFixedAssets[i].InvNo = rowVoucher.InvNo;
                            paymentDetailFixedAssets[i].TaxRate = rowVoucher.TaxRate;
                            paymentDetailFixedAssets[i].SortOrder = i;
                            paymentDetailFixedAssets[i].ContractId = rowVoucher.ContractId;
                            paymentDetailFixedAssets[i].CapitalPlanId = rowVoucher.CapitalPlanId;
                            paymentDetailFixedAssets[i].Quantity = rowVoucher.Quantity;
                        }
                    }
                }

                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (CAPaymentDetailFixedAssetModel)grdAccountingView.GetRow(i);
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

                            paymentDetailFixedAssets[i].BudgetSourceId = rowVoucher.BudgetSourceId;
                            paymentDetailFixedAssets[i].BudgetChapterCode = rowVoucher.BudgetChapterCode;
                            paymentDetailFixedAssets[i].BudgetKindItemCode = budgetKindItemCode;
                            paymentDetailFixedAssets[i].BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode;
                            paymentDetailFixedAssets[i].BudgetItemCode = rowVoucher.BudgetItemCode;
                            paymentDetailFixedAssets[i].BudgetSubItemCode = rowVoucher.BudgetSubItemCode;
                            paymentDetailFixedAssets[i].MethodDistributeId = rowVoucher.MethodDistributeId;
                            paymentDetailFixedAssets[i].CashWithdrawTypeId = rowVoucher.CashWithdrawTypeId;
                            paymentDetailFixedAssets[i].TaxRate = rowVoucher.TaxRate;
                            paymentDetailFixedAssets[i].SortOrder = i;
                            paymentDetailFixedAssets[i].ContractId = rowVoucher.ContractId;
                            paymentDetailFixedAssets[i].CapitalPlanId = rowVoucher.CapitalPlanId;
                            paymentDetailFixedAssets[i].Quantity = rowVoucher.Quantity;
                        }
                    }
                }

                if (grdAccountingDetailView.DataSource != null && grdAccountingDetailView.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingDetailView.RowCount; i++)
                    {
                        var rowVoucher = (CAPaymentDetailFixedAssetModel)grdAccountingDetailView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            paymentDetailFixedAssets[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                            paymentDetailFixedAssets[i].ActivityId = rowVoucher.ActivityId;
                            paymentDetailFixedAssets[i].ProjectId = rowVoucher.ProjectId;
                            paymentDetailFixedAssets[i].FundStructureId = rowVoucher.FundStructureId;
                            paymentDetailFixedAssets[i].TaxRate = rowVoucher.TaxRate;
                            paymentDetailFixedAssets[i].SortOrder = i;
                            paymentDetailFixedAssets[i].ContractId = rowVoucher.ContractId;
                            paymentDetailFixedAssets[i].CapitalPlanId = rowVoucher.CapitalPlanId;
                            paymentDetailFixedAssets[i].Quantity = rowVoucher.Quantity;
                        }
                    }
                }

                return paymentDetailFixedAssets;
            }

            set
            {
                // Lấy dữ liệu ghi tăng TSCĐ tự động
                if (IsOpenFromFixedAssetDetail)
                {
                    value = ListSendSourceDetail.OrderBy(c => c.SortOrder).ToList();
                    ListSendSourceDetail = null;
                    //IsOpenFromFixedAssetDetail = false;
                }
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<CAPaymentDetailFixedAssetModel>();
                grdAccountingView.PopulateColumns(value);
                grdAccountingDetailView.PopulateColumns(value);
                grdDetailByInventoryItemView.PopulateColumns(value);
                grdTaxView.PopulateColumns(value);

                #region columns for grdDetailByInventoryItemView

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "FixedAssetId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditFixedAsset,
                        ColumnWith = 150,
                        ColumnCaption = "Mã tài sản",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                      new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 150,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCreditAccount,
                        ColumnWith = 150,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 4,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số lượng",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },

                     new XtraColumn
                    {
                        ColumnName = "OrgPrice",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Đơn giá",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "ExchangeAmount",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {
                        ColumnName = "BudgetSourceId", //"ContractId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nguồn vốn",
                        ColumnPosition = 19,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource //_gridLookUpEditContract
                    },
                    new XtraColumn {ColumnName = "CapitalPlanId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxRate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InvType", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InvDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InvSeries", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InvNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "PurchasePurposeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false},
                       new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContractId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = true, ColumnWith = 150,
                        ColumnCaption = "Chương",
                        ColumnPosition = 110,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = true,
                                            ColumnCaption = "Khoản",
                        ColumnPosition = 111,
                         ColumnWith = 150,
                        AllowEdit = true,
                    RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = true,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 112,
                         ColumnWith = 150,
                        AllowEdit = true,
                    RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = true,
                     ColumnCaption = "Mục",
                        ColumnPosition = 113,
                         ColumnWith = 150,
                        AllowEdit = true,
                    RepositoryControl = _gridLookUpEditBudgetItem},
                     new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 114,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                      new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Tài khoản NH, KB",
                        ColumnPosition = 115,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },
                    new XtraColumn {ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                      ColumnWith = 150,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 116,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                           new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },
                    new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 118,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false,
                        ColumnWith = 120,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 118,
                        AllowEdit = true,
                        RepositoryControl = _repositoryMethodDistributeId
                    },
                      new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số hóa đơn",
                        ColumnPosition = 119,
                        AllowEdit = true,
                    },

                     new XtraColumn
                    {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Ngày hóa đơn",
                        ColumnPosition = 120,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.DateTime,
                        DisplayFormat = "dd-mm-yyyy",
                    },
                    //new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InvoiceTypeCode", ColumnVisible = false},
                    

                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                };

                grdDetailByInventoryItemView = InitGridLayout(columnsCollection, grdDetailByInventoryItemView);
                SetNumericFormatControl(grdDetailByInventoryItemView, true);
                grdDetailByInventoryItemView.OptionsView.ShowFooter = false;
                #endregion

                #region columns for grdTaxView
                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "FixedAssetId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditFixedAsset,
                        ColumnWith = 150,
                        ColumnCaption = "Mã tài sản",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxRate",
                        ColumnVisible = true,
                        RepositoryControl = _repositoryVATRate,
                        ColumnWith = 150,
                        ColumnCaption = "Thuế suất",
                        ColumnPosition = 3,
                        AllowEdit = true
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
                        AllowEdit = true  ,
                       RepositoryControl = _gridLookUpEditInvoiceFormNumber
                    },
                    new XtraColumn
                    {
                        ColumnVisible = true,
                        ColumnName = "InvSeries",
                        ColumnWith = 100,
                        ColumnCaption = "Ký hiệu HĐ",
                        ColumnPosition = 9,
                        AllowEdit = true
                    },

                    new XtraColumn
                    {
                        ColumnName = "InvNo",
                        ColumnVisible = true,
                         ColumnWith = 150,
                        ColumnCaption = "Số HĐ",
                        ColumnPosition = 10,
                        AllowEdit = true
                    },

                       new XtraColumn
                      {
                        ColumnName = "PurchasePurposeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nhóm HHDV",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditPurchasePurpose
                      },


                    new XtraColumn
                    {
                        ColumnName = "DepartmentId",
                        ColumnVisible = false,
                        RepositoryControl = _gridLookUpEditDepartment,
                        ColumnWith = 150,
                        ColumnCaption = "Phòng ban",
                        ColumnPosition = 3,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "ContractId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CapitalPlanId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DebitAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgPrice", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Amount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},

                    new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false},
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
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},

                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                };

                grdTaxView = InitGridLayout(columnsCollection, grdTaxView);
                SetNumericFormatControl(grdTaxView, true);
                grdTaxView.OptionsView.ShowFooter = false;
                #endregion

                #region grdAccountingView
                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "FixedAssetId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditFixedAsset,
                        ColumnWith = 150,
                        ColumnCaption = "Mã tài sản",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true
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
                        ColumnName = "InvSeries",
                        ColumnVisible = false

                    },
                    new XtraColumn
                    {
                        ColumnName = "InvoiceTypeCode",
                        ColumnVisible = false
                    },

                    new XtraColumn
                    {
                        ColumnName = "InvNo",
                        ColumnVisible = false
                    },

                       new XtraColumn
                      {
                        ColumnName = "PurchasePurposeId",
                        ColumnVisible = false
                      },


                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DebitAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgPrice", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Amount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},

                    new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Chương",
                        ColumnPosition = 4,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                         ColumnWith = 150,
                        ColumnCaption = "Mục",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },

                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false,
                         ColumnWith = 150,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        RepositoryControl = _repositoryMethodDistributeId
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },
                    new XtraColumn
                    {
                        ColumnName = "ContractId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditContract,
                        ColumnWith = 130,
                        ColumnCaption = "Hợp đồng",
                        ColumnPosition = 10,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 11,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},

                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                };

                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;

                #endregion

                #region grdAccountingDetailView
                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "FixedAssetId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditFixedAsset,
                        ColumnWith = 150,
                        ColumnCaption = "Mã tài sản",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true
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
                        ColumnName = "InvSeries",
                        ColumnVisible = false

                    },
                    new XtraColumn
                    {
                        ColumnName = "InvoiceTypeCode",
                        ColumnVisible = false
                    },

                    new XtraColumn
                    {
                        ColumnName = "InvNo",
                        ColumnVisible = false
                    },

                       new XtraColumn
                      {
                        ColumnName = "PurchasePurposeId",
                        ColumnVisible = false
                      },


                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DebitAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgPrice", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Amount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},

                    new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false},
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
                    new XtraColumn
                    {
                        ColumnName = "BudgetKindItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
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
                        RepositoryControl = _gridLookUpEditAccountingObject,
                        ColumnWith = 150,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 3,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                         RepositoryControl = _gridLookUpEditActivity,
                        ColumnWith = 150,
                        ColumnCaption = "Hoạt động SN",
                        ColumnPosition = 4,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                         RepositoryControl = _gridLookUpEditFundStructure,
                        ColumnWith = 150,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 5,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetExpenseId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Phí lệ phí",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpBudgetExpense
                    },

                    new XtraColumn {ColumnName = "ContractId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CapitalPlanId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},

                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                };

                grdAccountingDetailView = InitGridLayout(columnsCollection, grdAccountingDetailView);
                SetNumericFormatControl(grdAccountingDetailView, true);
                grdAccountingDetailView.OptionsView.ShowFooter = false;
                #endregion

                if (CurrencyCode == "VND")
                {
                    grdDetailByInventoryItemView.Columns.ColumnByFieldName("ExchangeAmount").Visible = false;
                }
            }
        }

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
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    for (var i = 0; i < grdViewAccountingParallel.RowCount; i++)
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

                                Description = rowVoucher.Description,
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount = rowVoucher.Amount,
                                AmountOC = rowVoucher.AmountOC,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                CashWithdrawTypeId = rowVoucher.CashWithdrawTypeId,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                FixedAssetId = rowVoucher.FixedAssetId,
                                ActivityId = rowVoucher.ActivityId,
                                ProjectId = rowVoucher.ProjectId,
                                Approved = true,
                                SortOrder = rowVoucher.SortOrder ?? i,
                                OrgRefNo = rowVoucher.OrgRefNo,
                                OrgRefDate = rowVoucher.OrgRefDate,
                                BudgetExpenseId = rowVoucher.BudgetExpenseId,
                                BudgetProvideCode = rowVoucher.BudgetProvideCode,
                                BankId = rowVoucher.BankId,
                                FundStructureId = rowVoucher.FundStructureId,
                                Quantity = rowVoucher.Quantity,
                                UnitPrice = rowVoucher.UnitPrice,
                                
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
                // Lấy dữ liệu ghi tăng TSCĐ tự động
                if (IsOpenFromFixedAssetDetail)
                {
                    var data = ListSendSourceDetailParallel.OrderBy(c => c.SortOrder).ToList();
                    ListSendSourceDetailParallel = null;
                    IsOpenFromFixedAssetDetail = false;
                    bindingSourceDetailParallel.DataSource = data;
                    grdViewAccountingParallel.PopulateColumns(data);
                }
                else
                {
                    bindingSourceDetailParallel.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<CAPaymentDetailParallelModel>();
                    grdViewAccountingParallel.PopulateColumns(value);
                }    


                #region columns for grdViewAccountingParallel

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                     new XtraColumn   {
                        ColumnName = "FixedAssetId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditFixedAsset,
                        ColumnWith = 150,
                        ColumnCaption = "Mã tài sản",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                     new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditAccountParallel,
                        ColumnWith = 100,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountParallel
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 300,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 4,
                        AllowEdit = true
                    },
                       new XtraColumn {
                        ColumnName = "Quantity",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số lượng",
                        ColumnPosition = 5,
                        AllowEdit = true,

                    },
                         new XtraColumn {
                        ColumnName = "UnitPrice",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Đơn giá",
                        ColumnPosition = 6,
                           ColumnType = UnboundColumnType.Decimal,
                        AllowEdit = true
                    },

                    new XtraColumn
                    {
                         ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 7,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 8,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Nguồn vốn",
                        ColumnPosition = 19,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Chương",
                        ColumnPosition = 110,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false}, //chon thang subkinditem la ra kinditem
                    new XtraColumn {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 111,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 112,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Mục",
                        ColumnPosition = 113,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                         new XtraColumn  {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 114,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },                               
                  

  new XtraColumn {ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                      ColumnWith = 150,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 116,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                           new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false,
                        ColumnWith = 120,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 118,
                        AllowEdit = true,
                        RepositoryControl = _repositoryMethodDistributeId
                    },
                           new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Tài khoản NH,KB",
                        ColumnPosition = 119,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },
                    new XtraColumn {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 120,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = false,
                        ColumnWith = 130,
                        ColumnCaption = "Dự án",
                        ColumnPosition = 113,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditProject
                    },
                    new XtraColumn
                    {
                        ColumnName = "ContractId",
                        ColumnVisible = false,
                        RepositoryControl = _gridLookUpEditContract,
                        ColumnWith = 130,
                        ColumnCaption = "Hợp đồng",
                        ColumnPosition = 114,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = false,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 114,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                      new XtraColumn {ColumnName = "AutoBusinessId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "BudgetExpenseId",
                        ColumnVisible = false,
                        ColumnWith = 220,
                        ColumnCaption = "Phí, lệ phí",
                        ColumnPosition = 116,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpBudgetExpense
                    },
                      new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số hóa đơn",
                        ColumnPosition = 221,
                        AllowEdit = true,
                    },

                     new XtraColumn
                    {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Ngày hóa đơn",
                        ColumnPosition = 222,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.DateTime,
                        DisplayFormat = "dd-mm-yyyy",
                    },
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false}
                };

                grdViewAccountingParallel = InitGridLayout(columnsCollection, grdViewAccountingParallel);
                SetNumericFormatControl(grdViewAccountingParallel, true);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;
                bool visibale = (CurrencyCode != "VND");
                grdViewAccountingParallel.Columns["Amount"].Visible = visibale;

                #endregion
            }
        }
          
        #endregion

        #region private helper

        /// <summary>
        ///     Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>GridView.</returns>
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
                        //if ((column.ColumnPosition == 1) | (column.ColumnPosition == 3))
                        //{
                        //    grdView.Columns[column.ColumnName].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                        //    grdView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                        //}
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

            var vatRates = new Dictionary<int, string> { { 0, "0%" }, { 5, "10%" }, { 10, "15%" }, { -1, "KCT" } };
            _repositoryVATRate = new RepositoryItemLookUpEdit
            {
                DataSource = vatRates.ToList(),
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
                if (value == null)
                    value = new List<BudgetSourceModel>();
                else
                {
                    var budgetSourceModels = value.Where(o => o.IsParent == false && o.IsActive == true).ToList();
                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetSourceModel.BudgetSourceCode), ColumnCaption = "Mã nguồn", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetSourceModel.BudgetSourceName), ColumnCaption = "Tên nguồn", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, budgetSourceModels, nameof(BudgetSourceModel.BudgetSourceCode), nameof(BudgetSourceModel.BudgetSourceId), gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
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

                    value = value.Where(v => !v.IsParent).ToList();

                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetKindItemModel.BudgetKindItemCode), ColumnCaption = "Mã khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetKindItemModel.BudgetKindItemName), ColumnCaption = "Tên khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, value, nameof(BudgetKindItemModel.BudgetKindItemCode), nameof(BudgetKindItemModel.BudgetKindItemCode), gridColumnsCollection);
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
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2).ToList();
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
                if (value == null)
                    value = new List<CashWithdrawTypeModel>();

                _gridLookUpEditCashWithdrawTypeView = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridViewReponsitory();
                //_gridLookUpEditCashWithdrawType.PopupFormSize = new Size(268, 150);
                var gridColumnsCollection = new List<XtraColumn>();
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(CashWithdrawTypeModel.CashWithdrawNo), ColumnCaption = "Mã", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(CashWithdrawTypeModel.CashWithdrawTypeName), ColumnCaption = "Nghiệp vụ", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 1 });

                _gridLookUpEditCashWithdrawType = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCashWithdrawTypeView, value, nameof(CashWithdrawTypeModel.CashWithdrawTypeName), nameof(CashWithdrawTypeModel.CashWithdrawTypeId), gridColumnsCollection);
                XtraColumnCollectionHelper<CashWithdrawTypeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCashWithdrawTypeView);
            }
        }

        #endregion

        public List<AccountingObjectModel> OldAccountingObjects { get; set; }
        #region AccountingObjects

        /// <summary>
        ///     Sets the accounting objects.
        /// </summary>
        /// <value>The accounting objects.</value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                if(value != null)
                {
                    OldAccountingObjects = value.ToList();
                }
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

                //      cboObjectCode.Properties.BestFitColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã người nhận",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên người nhận",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 280
                    },
                    new XtraColumn {ColumnName = "AccountingObjectBanks", ColumnVisible = false},
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
                    new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false },
                    new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false }
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

                _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();

                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, accountingObjects, "AccountingObjectCode", "AccountingObjectId", columnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(columnsCollection, _gridLookUpEditAccountingObjectView);

                //_gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                //_gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
                //{
                //    NullText = "",
                //    View = _gridLookUpEditAccountingObjectView,
                //    TextEditStyle = TextEditStyles.Standard,
                //};
                //_gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                //_gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                //_gridLookUpEditAccountingObject.PopupFormSize = new Size(440, 150);

                //_gridLookUpEditAccountingObject.View.BestFitColumns();

                ////_gridLookUpEditAccountingObject.DataSource = value;       
                ////_gridLookUpEditAccountingObjectView.PopulateColumns(value);
                //_gridLookUpEditAccountingObject.DataSource = accountingObjects;
                //_gridLookUpEditAccountingObjectView.PopulateColumns(accountingObjects);

                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                //    }
                //    else
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                //}
                //_gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectCode";
                //_gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";
                ////Filter cho gridview
                //_gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                //_gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, accountingObjects, "AccountingObjectCode", "AccountingObjectId", columnsCollection);
                //XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(columnsCollection, _gridLookUpEditAccountingObjectView);

                #endregion
            }
        }

        #endregion

        #region Activities
        /// <summary>
        /// Sets the activitys.
        /// </summary>
        /// <value>The activitys.</value>
        public IList<ActivityModel> Activitys
        {
            set
            {
                if (value == null)
                    value = new List<ActivityModel>();
                var gridColumnsCollection = new List<XtraColumn>();

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityCode", ColumnCaption = "Mã công việc", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityName", ColumnCaption = "Tên công việc", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                _gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, "ActivityCode", "ActivityId", gridColumnsCollection);

                XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);
                _gridLookUpEditActivity.EndUpdate();
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

                if (value == null)
                    value = new List<FundStructureModel>();
                var data = value.Where(o => o.IsParent == false && o.Inactive == true).ToList();
                _gridLookUpEditFundStructureView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FundStructureModel.FundStructureCode), ColumnCaption = "Mã khoản chi", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FundStructureModel.FundStructureName), ColumnCaption = "Tên khoản chi", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpEditFundStructure = XtraColumnCollectionHelper<FundStructureModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, data, nameof(FundStructureModel.FundStructureCode), nameof(FundStructureModel.FundStructureId), gridColumnsCollection);
                XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);
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
                if (value == null)
                    value = new List<PurchasePurposeModel>();

                _gridLookUpEditPurchasePurposeView = XtraColumnCollectionHelper<PurchasePurposeModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PurchasePurposeModel.PurchasePurposeCode), ColumnCaption = "Mã nhóm", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(PurchasePurposeModel.PurchasePurposeName), ColumnCaption = "Tên tên nhóm", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpEditPurchasePurpose = XtraColumnCollectionHelper<PurchasePurposeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditPurchasePurposeView, value, nameof(PurchasePurposeModel.PurchasePurposeName), nameof(PurchasePurposeModel.PurchasePurposeId), gridColumnsCollection);
                XtraColumnCollectionHelper<PurchasePurposeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditPurchasePurposeView);
            }
        }

        #endregion

        #region InventoryItems
        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>The inventory items.</value>
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                if (value == null)
                    value = new List<InventoryItemModel>();

                _gridLookUpEditInventoryItemView = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(InventoryItemModel.InventoryItemCode), ColumnCaption = "Mã hàng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(InventoryItemModel.InventoryItemName), ColumnCaption = "Tên hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpEditInventoryItem = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInventoryItemView, value, nameof(InventoryItemModel.InventoryItemName), nameof(InventoryItemModel.InventoryItemId), gridColumnsCollection);
                XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInventoryItemView);
            }
        }
        #endregion

        #region Stocks
        /// <summary>
        /// Sets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public IList<StockModel> Stocks
        {
            set
            {
                if (value == null)
                    value = new List<StockModel>();

                _gridLookUpEditStockView = XtraColumnCollectionHelper<StockModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(StockModel.StockCode), ColumnCaption = "Mã hàng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(StockModel.StockName), ColumnCaption = "Tên hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpEditStock = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditStockView, value, nameof(StockModel.StockName), nameof(StockModel.StockId), gridColumnsCollection);
                XtraColumnCollectionHelper<StockModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditStockView);
            }
        }
        #endregion

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
                    _accountModels = value.ToList();
                    var debitAccounts = value.ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var creditAccounts = value.ToList().CreditAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(value.ToList(), (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset, RefTypes.ToList());
                    _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(value.ToList(), (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset, RefTypes.ToList());

                    //  var parallelAccounts = value.ToList().ParallelAccounts();
                    var parallelAccounts = value.ToList();
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

                    _gridLookUpEditTaxAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditTaxAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditTaxAccountView, value, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditTaxAccountView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region FixedAssets
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
                // _listFixedAsset = value.ToList();

                _gridLookUpEditFixedAssetView = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridViewReponsitory();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FixedAssetModel.FixedAssetCode), ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FixedAssetModel.FixedAssetName), ColumnCaption = "Tên TSCĐ", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditFixedAsset = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFixedAssetView, value, nameof(FixedAssetModel.FixedAssetCode), nameof(FixedAssetModel.FixedAssetId), gridColumnsCollection);
                XtraColumnCollectionHelper<FixedAssetModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFixedAssetView);
            }
        }
        #endregion

        #region Departments

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
                // _listFixedAsset = value.ToList();

                _gridLookUpEditDepartmentView = XtraColumnCollectionHelper<DepartmentModel>.CreateGridViewReponsitory();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(DepartmentModel.DepartmentCode), ColumnCaption = "Mã phòng/ban", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(DepartmentModel.DepartmentName), ColumnCaption = "Tên phòng/ban", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditDepartment = XtraColumnCollectionHelper<DepartmentModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDepartmentView, value, nameof(DepartmentModel.DepartmentName), nameof(DepartmentModel.DepartmentId), gridColumnsCollection);
                XtraColumnCollectionHelper<DepartmentModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDepartmentView);
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

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BankModel.BankAccount), ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BankModel.BankName), ColumnCaption = "Tên NH, KB", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, nameof(BankModel.BankAccount), nameof(BankModel.BankId), gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
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

                _gridLookUpEditBudgetExpenseView = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetExpenseModel.BudgetExpenseCode), ColumnCaption = "Mã lệ phí", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetExpenseModel.BudgetExpenseName), ColumnCaption = "Tên phí, lệ phí", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, nameof(BudgetExpenseModel.BudgetExpenseName), nameof(BudgetExpenseModel.BudgetExpenseId), gridColumnsCollection);
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

        #endregion


        public List<CAPaymentDetailPurchaseModel> CAPaymentDetailPurchases
        {
            get;
            set;
        }

        #endregion

        #region Event

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
            for (int i = 0; i < grdViewAccountingParallel.RowCount; i++)
            {
                grdViewAccountingParallel.SetRowCellValue(i, "AccountingObjectId", AccountingObjectId);
                if (BankId != null)
                {
                    grdViewAccountingParallel.SetRowCellValue(i, "BankId", BankId);
                }
            }
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoAccountingObjectId = AccountingObjectId;
                SetDetailFromMaster(grdAccountingView, 1, AccountingObjectId, BankId, null);
                SetDetailFromMaster(grdDetailByInventoryItemView, 1, AccountingObjectId, BankId, null);
            }
            IModel model = new Model.Model();
            var accountingObjectBank = model.GetProjectBank(cboObjectCode.EditValue.ToString()).FirstOrDefault();
            BankId = accountingObjectBank == null ? null : accountingObjectBank.BankId;
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
            if (e.Column.FieldName == "BudgetSubItemCode" && e.Value != null)
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    return;
                var parentId = _budgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                var budgetItemCode = _budgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode);
            }
            if(e.Column.FieldName== "Amount")
            {
                //var amountOC = grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "Amount") == null ? 1 : (decimal)grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "Amount");
                //var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null ? 1 : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                //grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "Amount", exchangeRate * amountOC);
            }
            if (e.Column.FieldName == "Quantity")
            {
                var unitPrice = grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "UnitPrice") == null ? 0 :
                    (decimal)grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "UnitPrice");
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "Amount", (decimal)e.Value * unitPrice);
            }
            if (e.Column.FieldName == "UnitPrice")
            {
                var quantity = grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "Quantity") == null ? 0 :
                    (decimal)grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "Quantity");
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "Amount", (decimal)e.Value * quantity);
            }
        }

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the grdViewAccountingParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        private void grdViewAccountingParallel_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (GridViewInfo)grdAccountingView.GetViewInfo();
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
               // grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(CAPaymentDetailParallelModel.CashWithdrawTypeId), GlobalVariable.DefaultCashWithDrawTypeID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(CAPaymentDetailParallelModel.MethodDistributeId), GlobalVariable.DefaultMethodDistributeID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(CAPaymentDetailParallelModel.AccountingObjectId), this.AccountingObjectId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void grdDetailByInventoryItemView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (GridViewInfo)grdDetailByInventoryItemView.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            if (e.Column == null)
                return;
            if (e.Column == viewInfo.FixedLeftColumn)
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
        #endregion

        private void FrmCAPaymentFixedAssetDetail_Load(object sender, EventArgs e)
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
            if((totalAmountDelegate != null && totalAmountDelegate !=0)  && (totalAmountOCDelegate!= null && totalAmountOCDelegate != 0))
            {
                gridViewMaster.SetRowCellValue(0, "TotalAmount", totalAmountDelegate);
                gridViewMaster.SetRowCellValue(0, "TotalAmountOC", totalAmountDelegate);
            }



        }
        protected override void LkAccountingObjectCategory_EditValueChanged(object sender, EventArgs e)
        {
            _accountingObjectsPresenter.DisplayActive(true);
            CAPaymentDetailFixedAssets = CAPaymentDetailFixedAssets;
            CAPaymentDetailParallels = CAPaymentDetailParallels;
            //if(lkAccountingObjectCategory.EditValue != null)
            //{
            //    var values = OldAccountingObjects.Where(o => (o.AccountingObjectCategoryId == lkAccountingObjectCategory.EditValue.ToString()) || (lkAccountingObjectCategory.EditValue.ToString() == Guid.Empty.ToString() && (o.AccountingObjectCategoryId == null))).ToList();
            //    _gridLookUpEditAccountingObject.DataSource = values;
            //    cboObjectCode.Properties.DataSource = values;
            //}
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
                                grdDetailByInventoryItemView.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
                                grdViewAccountingParallel.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
                                cboObjectCode.EditValue = GlobalVariable.EmployeeIDDetailForm;
                            }
                        }
                    }
                }
                else //Thêm đối tượng
                {
                    using (var frmDetail = new FrmXtraAccountingObjectDetail())
                    {
                        frmDetail.AccountingObjectCategoryID = lkAccountingObjectCategory.EditValue == null ? "" : lkAccountingObjectCategory.EditValue.ToString();
                        frmDetail.ShowDialog();
                        if (frmDetail.CloseBox)
                        {
                            if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                            {
                                _accountingObjectsPresenter.Display();
                                grdDetailByInventoryItemView.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
                                grdViewAccountingParallel.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
                                cboObjectCode.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
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

        #region  Init new row
        /// <summary>
        /// Initializes the detail row for acounting detail by inventory item.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetailByInventoryItem(InitNewRowEventArgs e, GridView view)
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


        /// <summary>
        /// Initializes the detail row for acounting detail by tax.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetailByTax(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                if (_defaultDebitAccount != null)
                    view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
                if (_defaultCreditAccount != null)
                    view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
                //InitNewRow(e, view);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            view.SetRowCellValue(e.RowHandle, nameof(CAPaymentModel.AccountingObjectId), this.AccountingObjectId);
        }

        #endregion

        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }
        protected override void HiddenParallelAndOpenByCurrencyCode(object sender, CellValueChangedEventArgs e)
        {
            bool visibale = !e.Value.ToString().Equals("VND");
            grdDetailByInventoryItemView.Columns.ColumnByFieldName("ExchangeAmount").Visible = visibale;
            grdViewAccountingParallel.Columns.ColumnByFieldName("AmountOC").Visible = true;
            grdViewAccountingParallel.Columns.ColumnByFieldName("Amount").Visible = visibale;
            grdDetailByInventoryItemView.Columns.ColumnByFieldName("Amount").Visible = true;
            //ShowAmountByCurrencyCode(grdViewAccountingParallel, "Amount", visibale);
            //ShowAmountByCurrencyCode(grdDetailByInventoryItemView, "ExchangeAmount", visibale);
            
        }
    }
}