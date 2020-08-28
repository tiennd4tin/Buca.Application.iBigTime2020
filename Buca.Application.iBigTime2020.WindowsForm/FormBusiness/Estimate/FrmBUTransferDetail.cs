using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
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
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project;
using Buca.Application.iBigTime2020.WindowsForm.FormSystem;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusiness;
using Microsoft.VisualBasic;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusinessParallel;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    /// <summary>
    /// Class FrmBUPlanWithdrawCashDetail.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IActivitysView" />
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Estimate.IBUTransferView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.ICashWithdrawTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    public partial class FrmBUTransferDetail : FrmXtraBaseVoucherDetail, IBUTransferView, ICashWithdrawTypesView, IProjectView, IAccountingObjectView,
        IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IAutoBusinessesView, IBanksView, IAutoBusinessParallelsView
        , IAccountsView, IBudgetItemsView, IProjectsView, IFundStructuresView, IAccountingObjectsView, IActivitysView, IBUCommitmentRequestsView, IBudgetExpensesView, IContractsView, ICapitalPlansView
    {

        #region Liên kết
        /// <summary>
        /// </summary>
        public List<BUTransferDetailModel> ListSendSourceDetail;
        public bool IsOpenFrmBUTransferDetail;
        public BUTransferModel buTTransferModel;
        IList<BankModel> ListBank;
        #endregion

        #region Variable
        /// <summary>
        /// Tài khoản nợ ngầm định
        /// </summary>
        AccountModel _defaultDebitAccount;
        public bool EditBank { get; set; }
        /// <summary>
        /// Tài khoản có ngầm định
        /// </summary>
        AccountModel _defaultCreditAccount;

        /// <summary>
        /// Danh sách tài khoản
        /// </summary>
        List<AccountModel> _listAccounts;

        /// <summary>
        /// Danh sách phí, lệ phí
        /// </summary>
        private List<BudgetExpenseModel> _listBudgetExpenses;

        IModel model = new Model.Model();
        #endregion

        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        private GridView _gridLookUpEditContractView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCapitalPlan;
        private GridView _gridLookUpEditCapitalPlanView;
        /// <summary>
        /// The grid look up edit fund structure
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;

        /// <summary>
        /// The grid look up edit fund structure view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

        /// <summary>
        /// The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;

        /// <summary>
        /// The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditCashWithdrawTypeView;

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

        /// <summary>
        /// The grid look up edit budget sub item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;

        /// <summary>
        /// The grid look up edit budget sub item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubItemView;

        /// <summary>
        /// The grid look up edit budget item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;

        /// <summary>
        /// The grid look up edit budget item view
        /// </summary>
        private GridView _gridLookUpEditBudgetItemView;

        /// <summary>
        /// The grid look up edit account_gridLookUpEditAccount
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;

        /// <summary>
        /// The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        /// <summary>
        /// The grid look up edit budget expense view
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;


        /// <summary>
        /// The grid look up edit project
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;

        /// <summary>
        /// The grid look up edit project view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        /// <summary>
        /// The budget kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetKindItemModels;

        /// <summary>
        /// The grid look up edit bank
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        /// <summary>
        /// The grid look up edit bank view
        /// </summary>
        private GridView _gridLookUpEditBankView;

        /// <summary>
        /// The grid look up edit accounting object
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        /// <summary>
        /// The grid look up edit accounting object view
        /// </summary>
        private GridView _gridLookUpEditAccountingObjectView;

        /// <summary>
        /// The repository method distribute identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        /// <summary>
        /// The grid look up edit bank
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        /// <summary>
        /// The grid look up edit bank view
        /// </summary>
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountParallel;
        private GridView _gridLookUpEditAccountParallelView;
        private IList<BudgetItemModel> _budgetSubItemModels;
        private IList<BudgetItemModel> _budgetItemModels;
        private IList<BankModel> _bankModels;


        #endregion

        #region Presenter

        private readonly ContractsPresenter _contractsPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;
        /// <summary>
        /// The b u plan withdraw presenter
        /// </summary>
        private readonly BUTransferPresenter _bUTransferPresenter;
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// The banks presenter
        /// </summary>
        private readonly ProjectPresenter _projectPresenter;

        private readonly AccountingObjectPresenter _accountingObjectPresenter;

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
        /// The model
        /// </summary>
        private readonly IModel _model;

        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        /// <summary>
        /// The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;
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

        private readonly AutoBusinessesPresenter _autoBusinessPresenter;
        /// <summary>
        /// The activitys presenter
        /// </summary>
        private readonly ActivitysPresenter _activitysPresenter;

        private readonly BUCommitmentRequestsPresenter _buCommitmentRequestsPresenter;

        /// <summary>
        /// The budget expense presenter
        /// </summary>
        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;
        private readonly AutoBusinessParallelsPresenter _autoBusinessParallelsPresenter;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAutoBusiness;
        private GridView _gridLookUpEditAutoBusinessView;
        #endregion
        public List<SelectItemModel> Parallels { get; set; }
        public List<AutoBusinessParallelModel> ListAutoBussParallels { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBUTransferDetail" /> class.
        /// </summary>
        public FrmBUTransferDetail()
        {
            InitializeComponent();
            _contractsPresenter = new ContractsPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
            _bUTransferPresenter = new BUTransferPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _projectPresenter = new ProjectPresenter(this);
            _accountingObjectPresenter = new AccountingObjectPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _buCommitmentRequestsPresenter = new BUCommitmentRequestsPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
            _autoBusinessPresenter = new AutoBusinessesPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _autoBusinessParallelsPresenter = new AutoBusinessParallelsPresenter(this);
            _model = new Model.Model();

            this.grdDetailByInventoryItemView.InitNewRow += GrdAccountingView_InitNewRow;
            grdViewParallel = grdViewAccountingParallel;
        }

        #region--Check validate form detail
        private void GrdAccountingView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            InitDetailRow(e, grdAccountingView);
        }
        #endregion



        #region overrides
        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Visible = true;
            grdMaster.Location = new Point(7, 288);
            grdAccountingParallel.DataSource = bindingSourceDetailParallel;
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _contractsPresenter.Display();
            _capitalPlansPresenter.Display();
            _accountsPresenter.DisplayByIsDetail(GlobalVariable.IsPostToParentAccount);
            _budgetKindItemsPresenter.DisplayActive();
            _projectsPresenter.DisPlayForFAIncrementDecrement();


            _budgetItemsPresenter.DisplayActive(true);
            _fundStructuresPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);

            _accountingObjectsPresenter.DisplayActive(true);
            _activitysPresenter.DisplayActive(true);
            _buCommitmentRequestsPresenter.Display();
            _budgetExpensesPresenter.DisplayActive();
            _autoBusinessPresenter.DisplayActive();
            _banksPresenter.Display();
            _autoBusinessParallelsPresenter.Display();
            InitRepositoryControlData();

            if (IsOpenFrmBUTransferDetail && buTTransferModel != null && ActionMode == ActionModeVoucherEnum.AddNew)
            {

                IsOpenFrmBUTransferDetail = false;
                BUTransferDetails = ListSendSourceDetail;


                RefDate = buTTransferModel.RefDate;
                AccountingObjectBankAccount = buTTransferModel.AccountingObjectBankAccount;
                AccountingObjectBankName = buTTransferModel.AccountingObjectBankName;
                PostedDate = buTTransferModel.PostedDate;

                AccountingObjectId = buTTransferModel.AccountingObjectId;
                JournalMemo = buTTransferModel.JournalMemo;
                BasePostedDate = buTTransferModel.PostedDate;
                CurrencyCode = buTTransferModel.CurrencyCode;
                ExchangeRate = buTTransferModel.ExchangeRate;
                TotalAmount = buTTransferModel.TotalAmount;
                TotalAmountOC = buTTransferModel.TotalAmountOC;
                BUPlanWithdrawRefId = buTTransferModel.RefId;
                TargetProgramId = buTTransferModel.TargetProgramId;
                BankInfoId = buTTransferModel.BankInfoId;
                BUCommitmentRequestId = buTTransferModel.BUCommitmentRequestId;

                BuTransferDetailParallel = new List<BUTransferDetailParallelModel>();
            }
            else
            {
                if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((BUTransferModel)MasterBindingSource.Current).RefId;
                else
                {
                    if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                            KeyValue = ((BUTransferModel)MasterBindingSource.Current).RefId;
                }
                _bUTransferPresenter.Display(KeyValue);
            }

            _projectPresenter.DisplayProject(this.TargetProgramId);
            _accountingObjectPresenter.DisplayAccoutingObjectBanks(this.AccountingObjectId);
            if (RefType == 0)
            {
                RefType = (int)BuCA.Enum.RefType.BUTransfer;
                Posted = true;
            }
        }
        
        /// <summary>
        /// Refreshes the navigation button.
        /// </summary>
        protected override void RefreshNavigationButton()
        {
            base.RefreshNavigationButton();

            cboBankPay.Enabled = false;
            cboTargetProgramId.Enabled = false;
            cboBankPay.Enabled = false;
            lookUpEditAccountingObject.Enabled = false;
            cbObjectBank.Enabled = false;
            txtDocumentIncluded.Enabled = false;
        }
        /// <summary>
        /// Enables the control.
        /// </summary>
        protected override void EnableControl()
        {
            // cboBankPay.Enabled = true;
            //// cboAccountingObject.Enabled = true;
            cboBankPay.Enabled = true;
            cboTargetProgramId.Enabled = true;
            cboBankPay.Enabled = true;
            lookUpEditAccountingObject.Enabled = true;
            cbObjectBank.Enabled = true;
            txtDocumentIncluded.Enabled = true;
            //// txtJournalMemo.Enabled = true;
        }
        protected override void ReloadParallelGrid()
        {
            _bUTransferPresenter.Display(KeyValue);
        }
        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            EnableControlsInGroup(groupControl1, isEnable);
            EnableControlsInGroup(groupControl2, isEnable);
            grdViewAccountingParallel.OptionsBehavior.Editable = isEnable;
            grdViewAccountingParallel.OptionsBehavior.ReadOnly = !isEnable;
            grdViewAccountingParallel.FocusRectStyle = DrawFocusRectStyle.None;
            grdViewAccountingParallel.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdViewAccountingParallel.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
            cboBankPay.Enabled = isEnable;
            cboTargetProgramId.Enabled = isEnable;
            cboBankPay.Enabled = isEnable;
            lookUpEditAccountingObject.Enabled = isEnable;
            cbObjectBank.Enabled = isEnable;
            txtDocumentIncluded.Enabled = isEnable;
        }

        protected override void GridDetailByInventoryItemValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "AmountOC")
            {
                var amountOC = grdAccountingView.GetRowCellValue(e.RowHandle, "AmountOC") == null
                    ? 0
                    : (decimal)grdAccountingView.GetRowCellValue(e.RowHandle, "AmountOC");
                var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null
                    ? 1
                    : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                exchangeRate = exchangeRate == 0 ? 1 : exchangeRate;
            }

        }

        protected override void GridPurchaseCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "AmountOC")
            {
                var amountOC = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AmountOC") == null ? 0 : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AmountOC");
                var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null ? 1 : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                exchangeRate = exchangeRate == 0 ? 1 : exchangeRate;

                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", amountOC * exchangeRate);
                decimal totalAmountOC = 0;
                //grdDetailByInventoryItem.RefreshDataSource();
                for (var i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
                {
                    if (e.RowHandle < 0 && e.RowHandle == i)
                    {
                        totalAmountOC += (decimal)e.Value;
                    }
                    else
                    {
                        var rowVoucher = (BUTransferDetailModel)grdDetailByInventoryItemView.GetRow(i);
                        if (rowVoucher != null)
                            totalAmountOC += rowVoucher.AmountOC;
                    }
                }
                if (e.RowHandle < 0 || IsCopyRow)
                    totalAmountOC += (decimal)e.Value;
                gridViewMaster.SetRowCellValue(0, "TotalAmountOC", totalAmountOC);
            }
            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetItem = _budgetItemsPresenter.GetBudgetItems().Where(x => x.BudgetItemCode == budgetSubItemCode);
                foreach (var item in budgetItem)
                {
                    var budgetItemCode = _budgetItemsPresenter.GetBudgetItem(item.ParentId);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode.BudgetItemCode);
                }
            }
            if (e.Column.FieldName == "ProjectId" && e.Value != null)
            {
                //var values = OldContracts.Where(w => w.ProjectId == e.Value.ToString()).ToList();
                //_gridLookUpEditContract.DataSource = values;
                //var gridColumnsCollection = new List<XtraColumn>();

                //gridColumnsCollection = new List<XtraColumn>();
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractNo", ColumnCaption = "Số hợp đồng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractName", ColumnCaption = "Tên hợp đồng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                //_gridLookUpEditContractView = XtraColumnCollectionHelper<ContractModel>.CreateGridViewReponsitory();
                //_gridLookUpEditContract = XtraColumnCollectionHelper<ContractModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditContractView, values, "ContractName", "ContractId", gridColumnsCollection);

                //XtraColumnCollectionHelper<ContractModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditContractView);
                //_gridLookUpEditContract.EndUpdate();
            }
            if (e.Column.FieldName == "BankId" && e.Value != null)
            {
                //var values = OldContracts.Where(w => w.ProjectId == e.Value.ToString()).ToList();
                //_gridLookUpEditContract.DataSource = values;
                //var gridColumnsCollection = new List<XtraColumn>();

                //gridColumnsCollection = new List<XtraColumn>();
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractNo", ColumnCaption = "Số hợp đồng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractName", ColumnCaption = "Tên hợp đồng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                //_gridLookUpEditContractView = XtraColumnCollectionHelper<ContractModel>.CreateGridViewReponsitory();
                //_gridLookUpEditContract = XtraColumnCollectionHelper<ContractModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditContractView, values, "ContractName", "ContractId", gridColumnsCollection);

                //XtraColumnCollectionHelper<ContractModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditContractView);
                //_gridLookUpEditContract.EndUpdate();
            }

            if (e.Column.FieldName == "AutoBusinessID")
            {
                var autoBusinessId = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AutoBusinessID") == null ? string.Empty : grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AutoBusinessID").ToString();
                if (autoBusinessId != string.Empty)
                {
                    var autoBusiness = (AutoBusinessModel)_gridLookUpEditAutoBusiness.GetRowByKeyValue(autoBusinessId);
                    //&& autoBusiness.RefTypeId == (int)BaseRefTypeId
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
            //TienNV 17/8/2020
            if (e.Column.FieldName == "Description")
            {
                if (grdDetailByInventoryItemView.IsFirstRow && (txtDocumentIncluded.EditValue == null || txtDocumentIncluded.EditValue.ToString() == ""))
                {
                    txtDocumentIncluded.Text = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Description").ToString();
                }
            }
        }

        // cái hàm bên dưới dùng detected ProjectId để lấy ra danh mục hợp đồng tương ứng cho từng dự án
        protected override void GridDetailByInventoryItemViewMouseDown(object sender, MouseEventArgs e)
        {
            //var location = grdDetailByInventoryItemView.CalcHitInfo(e.Location);
            //int row = grdDetailByInventoryItemView.DataRowCount;

            //if (null == location)
            //{
            //    return;
            //}
            //if (location.InRowCell && location.Column.FieldName == "ContractId")
            //{
            //    int rowHandle = location.RowHandle;
            //    var index = grdDetailByInventoryItemView.GetRowCellValue(rowHandle, grdDetailByInventoryItemView.Columns["ProjectId"]);
            //    if (index != null)
            //    {
            //        var values = OldContracts.Where(w => w.ProjectId == index.ToString()).ToList();
            //        _gridLookUpEditContract.DataSource = values;
            //    }

            //}
        }
        protected override void GridPurchaseShowEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            BUTransferDetailModel data = view.GetFocusedRow() as BUTransferDetailModel;
            if (view.FocusedColumn.FieldName == "ContractId" && view.ActiveEditor is GridLookUpEdit)
            {
                GridLookUpEdit editor = view.ActiveEditor as GridLookUpEdit;
                if (data != null && !string.IsNullOrEmpty(data.ProjectId))
                {
                    var contracts = OldContracts.Where(x => x.ProjectId == data.ProjectId).ToList();
                    if (contracts == null || contracts.Count == 0) editor.Properties.DataSource = OldContracts;
                    else
                    {
                        editor.Properties.DataSource = contracts;
                    }
                }
                else
                {
                    editor.Properties.DataSource = OldContracts;
                }
            }
        }
        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            ListAutoBussParallels = ListAutoBussParallels.ToList();
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
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                txtRefNo.ErrorIcon = BaseEdit.DefaultErrorIcon;
                txtRefNo.ErrorText = "Không thể bỏ trống";
                return false;
            }
            var bUTransferDetails = BUTransferDetails;
            if (bUTransferDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount?.AccountNumber);
                view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount?.AccountNumber);

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
        /// Initializes the detail row
        /// </summary>
        /// <param name="e"></param>
        /// <param name="view"></param>
        protected override void InitDetailRowForAcountingDetailByInventoryItem(InitNewRowEventArgs e, GridView view)
        {
            if (_defaultDebitAccount != null)
                view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
            if (_defaultCreditAccount != null)
                view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new BUTransferPresenter(null).Delete(KeyValue);
            if (new BUPlanWithdrawPresenter(null).GetBUTransferByBUTransferRefId(KeyValue).Length > 0)
            {
                DialogResult dialog = XtraMessageBox.Show(string.Format("Bạn có muốn xóa chứng từ rút dự toán chuyển khoản số {0} không?", new BUPlanWithdrawPresenter(null).GetBUTransferByBUTransferRefId(KeyValue)), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    new BUPlanWithdrawPresenter(null).DeleteBUTransferByBUTransferRefId(KeyValue);
                }
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
            //   cboAccountingObject.Enabled = false;
            //cboBankPay.Enabled = false;
            //cboTargetProgramId.Enabled = false;
            //  txtJournalMemo.Enabled = false;
            //txtDocumentInclude.ReadOnly = true;
            //txtTaxCode.ReadOnly = true;

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
            IsOpenFrmBUTransferDetail = false;
            return result == DialogResult.OK ? _bUTransferPresenter.Save(true) : _bUTransferPresenter.Save(false);
        }

        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        //protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        //{
        //    IModel model = new Model.Model();
        //    if (e.Column.FieldName == "BudgetSubItemCode")
        //    {
        //        var budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
        //        var budgetItem = model.GetBudgetItems().Where(x => x.BudgetItemCode == budgetSubItemCode);

        //        foreach (var item in budgetItem)
        //        {
        //            var budgetItemCode = model.GetBudgetItem(item.ParentId);
        //            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode.BudgetItemCode);
        //        }

        //    }
        //}

        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string textError = "";
            IModel model = new Model.Model();



            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var _budgetSubItemCode = grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode") == null ? null : (string)grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetSubItem = _budgetSubItemModels.FirstOrDefault(x => x.BudgetItemCode == _budgetSubItemCode);
                if (budgetSubItem != null)
                {
                    var budgetItem = _budgetItemModels.FirstOrDefault(x => x.BudgetItemId == budgetSubItem.ParentId);
                    grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItem == null ? "" : budgetItem.BudgetItemCode);
                }
            }
            if (e.Column.FieldName == "AutoBusinessID")
            {
                var autoBusinessId = grdAccountingView.GetRowCellValue(e.RowHandle, "AutoBusinessId") == null ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "AutoBusinessId").ToString();
                if (autoBusinessId != string.Empty)
                {
                    var autoBusiness = (AutoBusinessModel)_gridLookUpEditAutoBusiness.GetRowByKeyValue(autoBusinessId);
                    if (autoBusiness != null && autoBusiness.RefTypeId == (int)BaseRefTypeId)
                    {

                        if (autoBusiness.BudgetSourceId == "00000000-0000-0000-0000-000000000000") grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSourceId", null);
                        else
                            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSourceId", autoBusiness.BudgetSourceId);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "DebitAccount", autoBusiness.DebitAccount);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "CreditAccount", autoBusiness.CreditAccount);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "Description", autoBusiness.AutoBusinessName);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSourceId", autoBusiness.BudgetSourceId);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetChapterCode", autoBusiness.BudgetChapterCode);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetKindItemCode", autoBusiness.BudgetKindItemCode);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", autoBusiness.BudgetSubKindItemCode);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", autoBusiness.BudgetItemCode);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSubItemCode", autoBusiness.BudgetSubItemCode);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "MethodDistributeID", autoBusiness.MethodDistributeId);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "CashWithDrawTypeID", autoBusiness.CashWithDrawTypeId);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "Description", autoBusiness.Description);
                    }
                }
            }
            GridView view = sender as GridView;
            if (view == null)
                return;

            switch (e.Column.FieldName)
            {
                case nameof(BADepositDetailModel.AmountOC):
                    decimal turnOver = Convert.ToDecimal((e.Value ?? 0));
                    view.SetFocusedRowCellValue(nameof(BADepositDetailModel.TurnOver), turnOver);

                    decimal vatRate = Convert.ToDecimal((view.GetFocusedRowCellValue(nameof(BADepositDetailModel.VATRate)) ?? 0));
                    if (vatRate < 0)
                        vatRate = 0;

                    view.SetFocusedRowCellValue(nameof(BADepositDetailModel.VATAmount), turnOver * vatRate / 100);
                    break;
            }
        }

        #endregion

        #region private helper

        /// <summary>
        /// Initializes the grid layout.
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

            //var vatRates = new Dictionary<string, string> { { "0", "0%" }, { "10", "10%" }, { "15", "15%" }, { "", "KCT" } };
            //_repositoryVATRate = new RepositoryItemLookUpEdit
            //{
            //    DataSource = vatRates,
            //    AllowNullInput = DefaultBoolean.True,
            //    NullText = null,
            //    NullValuePrompt = null,
            //    DisplayMember = "Value",
            //    ValueMember = "Key",
            //    ShowHeader = false
            //};

            //_repositoryVATRate.PopulateColumns();
            //_repositoryVATRate.Columns["Key"].Visible = false;

            //var invoiceTypes = typeof(InvoiceType).ToList();
            //_repositoryInvType = new RepositoryItemLookUpEdit
            //{
            //    DataSource = invoiceTypes,
            //    AllowNullInput = DefaultBoolean.True,
            //    NullText = null,
            //    NullValuePrompt = null,
            //    DisplayMember = "Value",
            //    ValueMember = "Key",
            //    ShowHeader = false
            //};
            //_repositoryInvType.PopulateColumns();
            //_repositoryInvType.Columns["Key"].Visible = false;
        }

        #endregion

        #region IView BUTransfer
        public string BUPlanWithdrawRefId { get; set; }
        public IList<BUTransferDetailFixedAssetlModel> BUTransferDetailFixedAssets { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
        public bool Approved
        {
            get;
            set;
        }

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
        public string ParalellRefNo
        {
            get { return cboBUCommitmentRequestId.Text; }
            set
            {
                //TienNV 14/08/2020
                //cboBUCommitmentRequestId.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the target program identifier.
        /// </summary>
        /// <value>The target program identifier.</value>
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
                else
                {
                    txtTargetProgramName.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId
        {
            get { return cboBankPay.EditValue == null ? null : cboBankPay.EditValue.ToString(); }
            set
            {
                cboBankPay.EditValue = value;
                if (cboBankPay.EditValue != null)
                {
                    var address = (string)cboBankPay.GetColumnValue("BankName");
                    txtBank.Text = address;
                }
            }
        }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
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

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo
        {
            get { return txtDocumentIncluded.Text; }
            set { txtDocumentIncluded.Text = value; }
        }

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
        /// Gets or sets the accounting object bank identifier.
        /// </summary>
        /// <value>The accounting object bank identifier.</value>
        public string AccountingObjectBankId
        {
            get { return cboBankPay.EditValue == null ? null : cboBankPay.EditValue.ToString(); }
            set
            {
                cboBankPay.EditValue = value;
                if (cboBankPay.EditValue != null)
                {
                    var address = (string)cboBankPay.GetColumnValue("BankName");
                    txtBankPayName.Text = address;
                }
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
        /// Gets or sets the generated reference identifier.
        /// </summary>
        /// <value>The generated reference identifier.</value>
        public string GeneratedRefId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="!:BUPlanWithdrawEntity" /> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        public string CurrencyId
        {
            get { return gridViewMaster.GetRowCellValue(0, "CurrencyCode") == null ? GlobalVariable.MainCurrencyId : gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString(); }
            set { gridViewMaster.SetRowCellValue(0, "CurrencyCode", value ?? GlobalVariable.MainCurrencyId); }
        }

        /// <summary>
        /// Gets or sets the bank information identifier.
        /// </summary>
        /// <value>The bank information identifier.</value>
        public string BankInfoId
        {
            get { return cboBankPay.EditValue == null ? null : cboBankPay.EditValue.ToString(); }
            set
            {
                cboBankPay.EditValue = value;
                if (cboBankPay.EditValue != null)
                {
                    var address = (string)cboBankPay.GetColumnValue("BankName");
                    txtBank.Text = address;
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>The name of the accounting object.</value>
        public string AccountingObjectName
        {
            get { return txtAccountingObjectName.Text; }
            set { txtAccountingObjectName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the accounting object address.
        /// </summary>
        /// <value>The accounting object address.</value>
        public string AccountingObjectAddress
        {
            get { return txtAccountingObjectAddress.Text; }
            set { txtAccountingObjectAddress.Text = value; }
        }

        /// <summary>
        /// Gets or sets the accounting object bank account.
        /// </summary>
        /// <value>The accounting object bank account.</value>
        public string AccountingObjectBankAccount
        {
            get { return cbObjectBank.EditValue == null ? null : cbObjectBank.EditValue.ToString(); }
            set { cbObjectBank.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the accounting object bank.
        /// </summary>
        /// <value>The name of the accounting object bank.</value>
        public string AccountingObjectBankName
        {
            get { return txtAccountingObjectBankName.Text; }
            set { txtAccountingObjectBankName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the document included.
        /// </summary>
        /// <value>The document included.</value>
        public string DocumentIncluded
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the inward stock reference no.
        /// </summary>
        /// <value>The inward stock reference no.</value>
        public string InwardStockRefNo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the withdraw reference date.
        /// </summary>
        /// <value>The withdraw reference date.</value>
        public DateTime? WithdrawRefDate
        {
            get { return dateWithdrawRefDate.EditValue == null ? DateTime.Now : (DateTime)dateWithdrawRefDate.EditValue; }
            set { dateWithdrawRefDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the withdraw reference no.
        /// </summary>
        /// <value>The withdraw reference no.</value>
        public string WithdrawRefNo
        {
            get { return txtWithdrawRefNo.Text; }
            set { txtWithdrawRefNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the increment reference no.
        /// </summary>
        /// <value>The increment reference no.</value>
        public string IncrementRefNo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>The total tax amount.</value>
        public decimal TotalTaxAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total freight amount.
        /// </summary>
        /// <value>The total freight amount.</value>
        public decimal TotalFreightAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total inward amount.
        /// </summary>
        /// <value>The total inward amount.</value>
        public decimal TotalInwardAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>The post version.</value>
        public int? PostVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>The edit version.</value>
        public int? EditVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int? RefOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>The relation reference identifier.</value>
        public string RelationRefId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total fixed asset amount.
        /// </summary>
        /// <value>The total fixed asset amount.</value>
        public decimal TotalFixedAssetAmount
        {
            get;
            set;
        }
        public IList<AutoBusinessModel> AutoBusinesses
        {
            set
            {
                try
                {
                    var data = value.Where(o => o.RefTypeId == (int)BuCA.Enum.RefType.BUTransfer).ToList();
                    _gridLookUpEditAutoBusinessView = new GridView();
                    _gridLookUpEditAutoBusinessView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditAutoBusiness = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditAutoBusinessView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditAutoBusiness.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditAutoBusiness.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditAutoBusiness.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditAutoBusiness.View.BestFitColumns();
                    _gridLookUpEditAutoBusiness.DataSource = data;
                    _gridLookUpEditAutoBusinessView.PopulateColumns(data);

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

                        new XtraColumn {ColumnName = "AutoBusinessId", ColumnVisible = false},
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

                    _gridLookUpEditAutoBusinessView = XtraColumnCollectionHelper<AutoBusinessModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAutoBusiness = XtraColumnCollectionHelper<AutoBusinessModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAutoBusinessView, data, "AutoBusinessCode", "AutoBusinessId", gridColumnsCollection);
                    XtraColumnCollectionHelper<AutoBusinessModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAutoBusinessView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Gets or sets the bu transfer details.
        /// </summary>
        /// <value>The bu transfer details.</value>
        public IList<BUTransferDetailModel> BUTransferDetails
        {
            get
            {
                grdDetailByInventoryItem.RefreshDataSource();
                var bUTransferDetails = new List<BUTransferDetailModel>();

                #region Tab Hạch toán

                if (grdDetailByInventoryItemView.DataSource != null && grdDetailByInventoryItemView.RowCount > 0)
                {
                    for (var i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
                    {
                        var rowVoucher = (BUTransferDetailModel)grdDetailByInventoryItemView.GetRow(i);
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
                            var item = new BUTransferDetailModel
                            {
                                Description = rowVoucher.Description,
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount = rowVoucher.Amount,// == 0 ? rowVoucher.AmountOC : rowVoucher.Amount,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                AmountOC = rowVoucher.AmountOC,
                                BudgetDetailItemCode = rowVoucher.BudgetDetailItemCode,
                                BudgetProvideCode = rowVoucher.BudgetProvideCode,
                                FundStructureId = rowVoucher.FundStructureId,
                                ListItemId = rowVoucher.ListItemId,
                                OrgRefDate = rowVoucher.OrgRefDate,
                                OrgRefNo = rowVoucher.OrgRefNo,
                                CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                BankId = rowVoucher.BankId,
                                SortOrder = i,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ProjectId = rowVoucher.ProjectId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                OldAdvanceRecovery = rowVoucher.OldAdvanceRecovery,
                                AdvanceRecovery = rowVoucher.AdvanceRecovery,
                                AutoBusinessID = rowVoucher.AutoBusinessID,
                                ActivityId = rowVoucher.ActivityId
                            };
                            bUTransferDetails.Add(item);
                        }
                    }
                }
                #endregion

                #region Tab thống kê

                if (bUTransferDetails.Count > 0)
                {
                    if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingView.RowCount; i++)
                        {
                            var rowVoucher = (BUTransferDetailModel)grdAccountingView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                bUTransferDetails[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                                bUTransferDetails[i].ActivityId = rowVoucher.ActivityId;
                                bUTransferDetails[i].FundStructureId = rowVoucher.FundStructureId;
                                bUTransferDetails[i].BudgetExpenseId = rowVoucher.BudgetExpenseId;
                                bUTransferDetails[i].ProjectId = rowVoucher.ProjectId;
                                bUTransferDetails[i].SortOrder = i;
                            }
                        }
                    }
                }

                #endregion

                #region Tab Hạch toán đồng thời

                if (bUTransferDetails.Count > 0)
                {
                    if (grdAccountingDetailView.DataSource != null && grdAccountingDetailView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingDetailView.RowCount; i++)
                        {
                            var rowVoucher = (BUTransferDetailModel)grdAccountingDetailView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                bUTransferDetails[i].ProjectId = rowVoucher.ProjectId;
                                bUTransferDetails[i].FundStructureId = rowVoucher.FundStructureId;
                                bUTransferDetails[i].SortOrder = i;
                                bUTransferDetails[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                                bUTransferDetails[i].ActivityId = rowVoucher.ActivityId;
                            }
                        }
                    }
                }

                #endregion
                return bUTransferDetails;

            }
            set
            {
                // Lấy dữ liệu từ form rút dự toán truyền sang
                if (IsOpenFrmBUTransferDetail)
                {
                    value = ListSendSourceDetail;
                    ListSendSourceDetail = null;
                }

                if (value == null || value.Count() == 0)
                {
                    value = new List<BUTransferDetailModel>() { new BUTransferDetailModel()
                    {
                        DebitAccount = _defaultDebitAccount?.AccountNumber,
                        CreditAccount = _defaultCreditAccount?.AccountNumber,
                        BudgetSourceId = GlobalVariable.DefaultBudgetSourceID,
                        BudgetChapterCode = GlobalVariable.DefaultBudgetChapterCode,
                        BudgetKindItemCode = GlobalVariable.DefaultBudgetKindItemCode,
                        BudgetSubKindItemCode = GlobalVariable.DefaultBudgetSubKindItemCode,

                    }};
                }

                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList();
                if(grdAccountingView.DataSource==null)
                {
                    BindingSource bd = new BindingSource();
                    bd.DataSource = bindingSourceDetail.DataSource;
                    grdAccounting.DataSource = bd;
                }
                grdDetailByInventoryItemView.PopulateColumns(value);
                grdAccountingView.PopulateColumns(value);
                grdAccountingDetailView.PopulateColumns(value);
                //SetDefaultValue(grdAccountingDetailView);

                #region Colunms for grdDetailByInventoryItemView

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AutoBusinessID",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditAutoBusiness,
                        ColumnWith = 100,
                        ColumnCaption = "ĐK tự động",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
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
                        RepositoryControl = _gridLookUpEditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 4,
                        AllowEdit = true,
                    },
                    new XtraColumn {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 5,
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
                        ColumnPosition = 6,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 17,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 18,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Chương",
                        ColumnPosition = 19,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 110,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 111,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                     new XtraColumn {
                         ColumnName = "BudgetItemCode",
                         ColumnVisible = true,
                         ColumnWith = 80,
                         ColumnCaption = "Mục",
                         ColumnPosition = 112,
                         AllowEdit = true,
                         RepositoryControl = _gridLookUpEditBudgetItem
                     },
                    new XtraColumn {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 113,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Dự án",
                        ColumnPosition = 114,
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
                        ColumnPosition = 115,
                        AllowEdit = true
                    },
                    // new XtraColumn
                    // {
	                    // ColumnName = "MethodDistributeId",
	                    // ColumnVisible = false,
	                    // ColumnWith = 120,
	                    // ColumnCaption = "Cấp phát",
	                    // ColumnPosition = 16,
	                    // AllowEdit = true,
	                    // RepositoryControl = _repositoryMethodDistributeId
                    // },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 116,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithDrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 230,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },
                              new XtraColumn
                    {
                        ColumnName = "OldAdvanceRecovery",
                        ColumnVisible = true,
                        ColumnType = UnboundColumnType.Decimal,
                        ColumnWith = 130,
                        ColumnCaption = "Thu hồi năm trước",
                        ColumnPosition = 118,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "AdvanceRecovery",
                        ColumnVisible = true,
                        ColumnType = UnboundColumnType.Decimal,
                        ColumnWith = 130,
                        ColumnCaption = "Thu hồi năm nay",
                        ColumnPosition = 119,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Tài khoản NH,KB",
                        ColumnPosition = 120,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },
                     new XtraColumn
                     {
                         ColumnName = "ActivityId",
                         ColumnVisible = true,
                         ColumnWith = 220,
                         ColumnCaption = "Công việc",
                         ColumnPosition = 121,
                         AllowEdit = true,
                         RepositoryControl = _gridLookUpEditActivity
                     },
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TotalAmount", ColumnVisible = false},
                    //new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                    //new XtraColumn {ColumnName = "ActivityI", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "WithdrawRefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Tax", ColumnVisible = false}
                };


                XtraColumnCollectionHelper<BUTransferDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdDetailByInventoryItemView);
                SetNumericFormatControl(grdDetailByInventoryItemView, true);
                grdDetailByInventoryItemView.OptionsView.ShowFooter = false;
                bool visibale = (CurrencyCode != "VND");
                grdDetailByInventoryItemView.Columns["Amount"].Visible = visibale;

                #endregion

                #region Colunms for grdAccountingView

                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},

                    new XtraColumn
                    {
                        ColumnName = "AutoBusinessId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditAutoBusiness,
                        ColumnWith = 200,
                        ColumnCaption = "ĐK tự động",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số chứng từ gốc",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                     new XtraColumn
                    {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Ngày chứng từ gốc",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 300,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 3,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 100,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 4,
                        AllowEdit = true
                    },
                     new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccount
                    },
                     new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = false,
                        ColumnWith = 100,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = false,
                        ColumnWith = 130,
                        ColumnCaption = "Dự án",
                        ColumnPosition = 5,
                        AllowEdit = false,
                        RepositoryControl = _gridLookUpEditProject
                    },
                    new XtraColumn
                    {
                        ColumnName = "ContractId",
                        ColumnVisible = false,
                        RepositoryControl = _gridLookUpEditContract,
                        ColumnWith = 130,
                        ColumnCaption = "Hợp đồng",
                        ColumnPosition = 6,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = false,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 7,
                        AllowEdit = true
                    },
                                            new XtraColumn
                    {
                        ColumnName = "OldAdvanceRecovery",
                        ColumnVisible = true,
                        ColumnType = UnboundColumnType.Decimal,
                        ColumnWith = 130,
                        ColumnCaption = "Thu hồi năm trước",
                        ColumnPosition = 18,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "AdvanceRecovery",
                        ColumnVisible = true,
                        ColumnType = UnboundColumnType.Decimal,
                        ColumnWith = 130,
                        ColumnCaption = "Thu hồi năm nay",
                        ColumnPosition = 19,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetExpenseId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Phí, lệ phí",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpBudgetExpense
                    },
                       new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                    new XtraColumn {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Mục",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        RepositoryControl = _repositoryMethodDistributeId
                    },
                    new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = false,
                        ColumnWith = 130,
                        ColumnCaption = "Tài khoản NH,KB",
                        ColumnPosition = 13,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },
                    new XtraColumn {
                        ColumnName = "Quanlity",
                        ColumnVisible = false
                    },
                    new XtraColumn {
                        ColumnName = "Quota",
                        ColumnVisible = false
                    },
                    new XtraColumn {
                        ColumnName = "AmountOC",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
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
                    new XtraColumn {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithDrawTypeId",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "WithdrawRefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "WithdrawDetailId", ColumnVisible = false},
                };

                XtraColumnCollectionHelper<BUTransferDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdAccountingView);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;

                #endregion

                #region Colunms for grdAccountingDetailView

                columnsCollection = new List<XtraColumn>
                {
                        new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DebitAccount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = false},
                         new XtraColumn {ColumnName = "Amount", ColumnVisible = false},
                         new XtraColumn {ColumnName = "AmountOC", ColumnVisible = false},
                         new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "WithdrawRefDetailId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                };
                XtraColumnCollectionHelper<BUTransferDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdAccountingDetailView);
                SetNumericFormatControl(grdAccountingDetailView, true);
                grdAccountingDetailView.OptionsView.ShowFooter = false;
                grdAccountingDetailView.Columns["Amount"].Visible = visibale;

                #endregion
            }
        }

        #endregion

        #region IView Extens

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
                    _gridLookUpEditFundStructureView = new GridView();
                    _gridLookUpEditFundStructureView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFundStructure = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFundStructureView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditFundStructure.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFundStructure.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFundStructure.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFundStructure.View.BestFitColumns();

                    _gridLookUpEditFundStructure.DataSource = value;
                    _gridLookUpEditFundStructureView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "FundStructureCode",
                            ColumnCaption = "Mã khoản chi",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "FundStructureName",
                            ColumnCaption = "Tên khoản chị",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Inactive", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false},
                        new XtraColumn {ColumnName = "InvestmentPeriod", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BUCACodeId", ColumnVisible = false}
                    };
                    //foreach (var column in gridColumnsCollection)
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Visible = false;
                    //    }
                    //_gridLookUpEditFundStructure.DisplayMember = "FundStructureCode";
                    //_gridLookUpEditFundStructure.ValueMember = "FundStructureId";
                    _gridLookUpEditFundStructureView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();
                    _gridLookUpEditFundStructure = XtraColumnCollectionHelper<FundStructureModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, value, "FundStructureCode", "FundStructureId", gridColumnsCollection);
                    XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the cash withdraw type models.
        /// </summary>
        /// <value>The cash withdraw type models.</value>
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

                    var budgetSourceList = value.Where(nv => nv.IsActive == true && nv.IsParent == false).ToList();
                    _gridLookUpEditBudgetSource.DataSource = budgetSourceList;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(budgetSourceList);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                        {
                            ColumnName = "BudgetSourceCode",
                            ColumnCaption = "Mã nguồn vốn",
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnPosition = 1
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetSourceName",
                            ColumnCaption = "Tên nguồn vốn",
                            ColumnVisible = true,
                            ColumnWith = 250,
                            ColumnPosition = 2
                        }
                    };
                    //XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    //_gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    //_gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";
                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, budgetSourceList, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
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
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetChapter.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetChapter.View.BestFitColumns();

                    _gridLookUpEditBudgetChapter.DataSource = value;
                    _gridLookUpEditBudgetChapterView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetChapterId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "BudgetChapterCode",
                            ColumnCaption = "Mã Chương",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetChapterName",
                            ColumnCaption = "Tên Chương",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };

                    //foreach (var column in gridColumnsCollection)
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                    //    }
                    //_gridLookUpEditBudgetChapter.DisplayMember = "BudgetChapterCode";
                    //_gridLookUpEditBudgetChapter.ValueMember = "BudgetChapterCode";

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
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubKindItem.View.BestFitColumns();

                    _gridLookUpEditBudgetSubKindItem.DataSource = _budgetSubKindItemModels;
                    _gridLookUpEditBudgetSubKindItemView.PopulateColumns(_budgetSubKindItemModels);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetKindItemId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "BudgetKindItemCode",
                            ColumnCaption = "Mã Khoản",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetKindItemName",
                            ColumnCaption = "Tên Khoản",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };
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
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2 && v.IsActive == true).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3 && v.IsActive == true).ToList();

                    #region BudgetItem

                    _gridLookUpEditBudgetItemView = new GridView();
                    _gridLookUpEditBudgetItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetItemView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetItem.View.BestFitColumns();

                    _gridLookUpEditBudgetItem.DataSource = budgetItemModels;
                    _gridLookUpEditBudgetItemView.PopulateColumns(budgetItemModels);
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "BudgetItemCode",
                            ColumnCaption = "Mã Mục",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetItemName",
                            ColumnCaption = "Tên Mục",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetGroupItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };
                    //foreach (var column in gridColumnsCollection)
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Visible = false;
                    //    }
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
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetSubItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubItem.View.BestFitColumns();

                    _gridLookUpEditBudgetSubItem.DataSource = budgetSubItemModels;
                    _gridLookUpEditBudgetSubItemView.PopulateColumns(budgetSubItemModels);
                    gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "BudgetItemCode",
                            ColumnCaption = "Mã tiểu mục",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetItemName",
                            ColumnCaption = "Tên tiểu mục",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetGroupItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };
                    //foreach (var column in gridColumnsCollection)
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Visible = false;
                    //    }
                    //_gridLookUpEditBudgetSubItem.DisplayMember = "BudgetItemCode";
                    //_gridLookUpEditBudgetSubItem.ValueMember = "BudgetItemCode";

                    _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, budgetSubItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);

                    #endregion
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
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                try
                {
                    _listAccounts = value.ToList();

                    var debitAccounts = value.ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var creditAccounts = value.ToList().CreditAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var parallelAccounts = value.ToList().ParallelAccounts();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "Số tài khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });


                    _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);

                    _gridLookUpEditAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountView, creditAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountView);

                    _gridLookUpEditAccountParallelView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAccountParallel = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountParallelView, parallelAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountParallelView);

                    _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(_listAccounts, (int)BaseRefTypeId, RefTypes.ToList());
                    _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(_listAccounts, (int)BaseRefTypeId, RefTypes.ToList());
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


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
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditProject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditProject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditProject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditProject.View.BestFitColumns();


                    cboTargetProgramId.Properties.DataSource = value;
                    cboTargetProgramId.Properties.PopulateColumns();
                    _gridLookUpEditProject.DataSource = value;
                    _gridLookUpEditProjectView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "ProjectCode",
                            ColumnCaption = "Mã Dự án",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 120
                        },
                        new XtraColumn
                        {
                            ColumnName = "ProjectName",
                            ColumnCaption = "Tên Dự án",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 330
                        },
                        new XtraColumn {ColumnName = "ProjectNumber", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "ProjectEnglishName",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "BUCACodeID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "StartDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FinishDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ExecutionUnit", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DepartmentID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TotalAmountApproved", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ParentID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "IsDetailbyActivityAndExpense",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                         new XtraColumn {ColumnName = "ObjectType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ObjectTypeName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ContractorID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ContractorName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ContractorAddress", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectSize", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BuildLocation", ColumnVisible = false},
                        new XtraColumn {ColumnName = "InvestmentClass", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CDCActivityType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectBanks", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Investment", ColumnVisible = false}
                    };
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            //_gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            //_gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            //_gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                            cboTargetProgramId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            cboTargetProgramId.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            // _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                            cboTargetProgramId.Properties.Columns[column.ColumnName].Visible = false;
                        }
                    //_gridLookUpEditProject.DisplayMember = "ProjectCode";
                    //_gridLookUpEditProject.ValueMember = "ProjectId";
                    cboTargetProgramId.Properties.DisplayMember = "ProjectCode";
                    cboTargetProgramId.Properties.ValueMember = "ProjectId";

                    _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, value, "ProjectCode", "ProjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);


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
        /// <value>The accounting objects.</value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                // lấy đối tượng là nhà cung cấp
                value = value.Where(v => v.AccountingObjectCategoryId != null).ToList();
                lookUpEditAccountingObject.Properties.DataSource = value;
                lookUpEditAccountingObject.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đơn vị",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên đơn vị",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 330
                    },
                               new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectBanks", ColumnVisible = false},
                       new XtraColumn {ColumnName = "AccountingObjectCategoryId", ColumnVisible = false},
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
                    new XtraColumn {ColumnName = "BudgetChapterId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrganizationFeeCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrganizationManageFee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TreasuryManageFee", ColumnVisible = false}
                };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lookUpEditAccountingObject.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lookUpEditAccountingObject.Properties.SortColumnIndex = column.ColumnPosition;
                        lookUpEditAccountingObject.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        lookUpEditAccountingObject.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                lookUpEditAccountingObject.Properties.DisplayMember = "AccountingObjectCode";
                lookUpEditAccountingObject.Properties.ValueMember = "AccountingObjectId";

                #region Lookup edit accounting objects

                _gridLookUpEditAccountingObjectView = new GridView();
                _gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditAccountingObjectView,
                    TextEditStyle = TextEditStyles.Standard,
                };
                _gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditAccountingObject.PopupFormSize = new Size(368, 150);

                _gridLookUpEditAccountingObject.View.BestFitColumns();

                _gridLookUpEditAccountingObject.DataSource = value;
                _gridLookUpEditAccountingObjectView.PopulateColumns(value);


                _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, value, "AccountingObjectCode", "AccountingObjectId", columnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(columnsCollection, _gridLookUpEditAccountingObjectView);

                #endregion
            }
        }

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
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(CashWithdrawTypeModel.CashWithdrawTypeName), ColumnCaption = "Nghiệp vụ", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 1 });

                _gridLookUpEditCashWithdrawType = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCashWithdrawTypeView, value, nameof(CashWithdrawTypeModel.CashWithdrawTypeName), nameof(CashWithdrawTypeModel.CashWithdrawTypeId), gridColumnsCollection);
                XtraColumnCollectionHelper<CashWithdrawTypeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCashWithdrawTypeView);
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
                //if (value == null)
                //    value = new List<ActivityModel>();

                //_gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                ////_gridLookUpEditActivity.PopupFormSize = new Size(268, 150);
                //var gridColumnsCollection = new List<XtraColumn>();
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(ActivityModel.ActivityName), ColumnCaption = "Công việc", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                //_gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, nameof(ActivityModel.ActivityName), nameof(ActivityModel.ActivityId), gridColumnsCollection);
                //XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);

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

        public IList<BUTransferDetailParallelModel> BuTransferDetailParallel
        {
            get
            {
                grdAccountingParallel.RefreshDataSource();
                var withDrawDetailParallels = new List<BUTransferDetailParallelModel>();
                if (grdViewAccountingParallel.DataSource != null && grdViewAccountingParallel.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BUTransferDetailParallelModel)grdViewAccountingParallel.GetRow(i);
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
                            var item = new BUTransferDetailParallelModel()
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
                            };
                            withDrawDetailParallels.Add(item);
                            //TotalAmount += item.Amount;
                            //TotalAmountOC += item.Amount;
                        }
                    }
                }
                return withDrawDetailParallels;

            }
            set
            {
                bindingSourceDetailParallel.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BUTransferDetailParallelModel>();
                grdViewAccountingParallel.PopulateColumns(value);

                #region columns for grdViewAccountingParallel

                var columnsCollection = new List<XtraColumn>
                {                    
                    //new XtraColumn
                    //{
                    //    ColumnName = "AutoBusinessId",
                    //    ColumnVisible = true,
                    //    RepositoryControl = _gridLookUpEditAutoBusiness,
                    //    ColumnWith = 200,
                    //    ColumnCaption = "ĐK tự động",
                    //    ColumnPosition = 1,
                    //    AllowEdit = true,
                    //},
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditAccountParallel,
                        ColumnWith = 100,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 2,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountParallel
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 300,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 3,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 4,
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
                        ColumnPosition = 5,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 16,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 17,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Chương",
                        ColumnPosition = 18,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 19,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 110,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                     new XtraColumn {
                         ColumnName = "BudgetItemCode",
                         ColumnVisible = true,
                         ColumnWith = 80,
                         ColumnCaption = "Mục",
                         ColumnPosition = 111,
                         AllowEdit = true,
                         RepositoryControl = _gridLookUpEditBudgetItem
                     },
                    new XtraColumn {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 112,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Dự án",
                        ColumnPosition = 113,
                        AllowEdit = false,
                        RepositoryControl = _gridLookUpEditProject
                    },
                    new XtraColumn
                    {
                        ColumnName = "ContractId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditContract,
                        ColumnWith = 130,
                        ColumnCaption = "Hợp đồng",
                        ColumnPosition = 114,
                        AllowEdit = true
                    },
                     new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 115,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },
                    new XtraColumn
                    {
                        ColumnName = "OldAdvanceRecovery",
                        ColumnVisible = true,
                        ColumnType = UnboundColumnType.Decimal,
                        ColumnWith = 1130,
                        ColumnCaption = "Thu hồi năm trước",
                        ColumnPosition = 17,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "AdvanceRecovery",
                        ColumnVisible = true,
                        ColumnType = UnboundColumnType.Decimal,
                        ColumnWith = 130,
                        ColumnCaption = "Thu hồi năm nay",
                        ColumnPosition = 118,
                        AllowEdit = true
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
                     new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 120,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ParentRefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    //new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                    //new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false}
                };

                grdViewAccountingParallel = InitGridLayout(columnsCollection, grdViewAccountingParallel);
                SetNumericFormatControl(grdViewAccountingParallel, true);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;

                bool visibale = (CurrencyCode != "VND");
                grdViewAccountingParallel.Columns["Amount"].Visible = visibale;
                #endregion
            }
        }

        public IList<BUTransferDetailPurchaselModel> BUTransferDetailPurchases { get; set; }

        public IList<BUCommitmentRequestModel> BUCommitmentRequests
        {
            set
            {
                cboBUCommitmentRequestId.Properties.DataSource = value;
                cboBUCommitmentRequestId.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "RefNo",
                        ColumnCaption = "Số chứng từ",
                        ColumnVisible = true,
                        ColumnPosition = 1,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "RefDate",
                        ColumnCaption = "Ngày chứng từ",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 330
                    },
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "PostedDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefType", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TABMISCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContractNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContractFrameNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSourceKind", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TotalAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TotalAmountOC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsForeignCurrency", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Posted", ColumnVisible = false},
                    new XtraColumn {ColumnName = "EditVersion", ColumnVisible = false},
                    new XtraColumn {ColumnName = "PostVersion", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectInvestmentCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectInvestmentName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SignDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContractAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "PrevYearCommitmentAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BUCommitmentRequestDetails", ColumnVisible = false}
                };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBUCommitmentRequestId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBUCommitmentRequestId.Properties.SortColumnIndex = column.ColumnPosition;
                        cboBUCommitmentRequestId.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        cboBUCommitmentRequestId.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                cboBUCommitmentRequestId.Properties.DisplayMember = "RefNo";
                cboBUCommitmentRequestId.Properties.ValueMember = "RefId";
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
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetExpenseModel.BudgetExpenseCode), ColumnCaption = "Mã lệ phí", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetExpenseModel.BudgetExpenseName), ColumnCaption = "Tên phí, lệ phí", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, nameof(BudgetExpenseModel.BudgetExpenseName), nameof(BudgetExpenseModel.BudgetExpenseId), gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetExpenseModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetExpenseView);
            }
        }
        #endregion


        #region Contract
        public List<ContractModel> OldContracts { get; set; }
        /// <summary>
        /// Contract
        /// </summary>
        public IList<ContractModel> Contracts
        {
            set
            {
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
                _gridLookUpEditContract.EndUpdate();
            }
        }

        #endregion


        #endregion

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
            var viewInfo = (GridViewInfo)grdDetailByInventoryItemView.GetViewInfo();
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

        #endregion

        #region Event Control

        /// <summary>
        /// Handles the EditValueChanged event of the cboObjectCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cboObjectCode_EditValueChanged(object sender, EventArgs e)
        {
            if (cboObjectCode.EditValue == null)
                return;
            var accountingObjectName = (string)cboObjectCode.GetColumnValue("AccountingObjectName");
            var address = (string)cboObjectCode.GetColumnValue("Address");

            cboObjectName.Text = accountingObjectName;
            txtAddress.Text = address;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboBank control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cboBank_EditValueChanged(object sender, EventArgs e)
        {
            if (cboBankPay.EditValue == null)
                return;

            var bankName = (string)cboBankPay.GetColumnValue("BankName");
            txtBankPayName.Text = bankName;

            //txtBankPayName.EditValue = value.FirstOrDefault(v => v.BankId == BankInfoId).BankName;
            //if (cboTargetProgramId.EditValue == null)
            //    return;
            //var projectName = (string)cboTargetProgramId.GetColumnValue("ProjectName");

            //txtTargetProgramName.Text = projectName;
            //if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            //{
            //    this._projectPresenter.DisplayProject(cboTargetProgramId.EditValue.ToString());
            //    AutoProjectId = TargetProgramId;
            //    SetDetailFromMaster(grdAccountingView, 3, AccountingObjectId, BankId, TargetProgramId);
            //}
        }
        private void cboObjectBank_EditValueChanged(object sender, EventArgs e)
        {
            if (cbObjectBank.EditValue == null)
                return;

            var bankName = (string)cbObjectBank.GetColumnValue("BankName");
            txtAccountingObjectBankName.Text = bankName;
            //if (cboTargetProgramId.EditValue == null)
            //    return;
            //var projectName = (string)cboTargetProgramId.GetColumnValue("ProjectName");

            //txtTargetProgramName.Text = projectName;
            //if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            //{
            //    this._projectPresenter.DisplayProject(cboTargetProgramId.EditValue.ToString());
            //    AutoProjectId = TargetProgramId;
            //    SetDetailFromMaster(grdAccountingView, 3, AccountingObjectId, BankId, TargetProgramId);
            //}
        }
        /// <summary>
        /// Handles the EditValueChanged event of the cboAccountingObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cboAccountingObject_EditValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboTargetProgramId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboTargetProgramId_EditValueChanged(object sender, EventArgs e)
        {
            //if (grdAccountingView.rowcount == 1)
            //{
            //    grdAccountingView.addnewrow();
            //}
            if (cboTargetProgramId.EditValue == null)
                return;
            var projectName = (string)cboTargetProgramId.GetColumnValue("ProjectName");

            txtTargetProgramName.Text = projectName;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit || ActionMode==ActionModeVoucherEnum.DuplicateVoucher)
            {
                this._projectPresenter.DisplayProject(cboTargetProgramId.EditValue.ToString());
                AutoProjectId = TargetProgramId;
                var banks = model.GetProjectBank(cboTargetProgramId.EditValue.ToString());
                if (banks != null & banks.Count > 0)
                {
                    cboBankPay.EditValue = banks[0].BankId;
                    txtBankPayName.EditValue = banks[0].BankName;
                }
                SetDetailFromMaster(grdAccountingView, 3, AccountingObjectId, BankId, TargetProgramId);
            }
            var gridColumnsCollection = new List<XtraColumn>();
            //var values = OldContracts.Where(w => w.ProjectId == cboTargetProgramId.EditValue.ToString()).ToList();
            //_gridLookUpEditContract.DataSource = values;

            //gridColumnsCollection = new List<XtraColumn>();
            //gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractNo", ColumnCaption = "Số hợp đồng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
            //gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractName", ColumnCaption = "Tên hợp đồng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

            //_gridLookUpEditContractView = XtraColumnCollectionHelper<ContractModel>.CreateGridViewReponsitory();
            //var values = (OldContracts != null && OldContracts.Count() > 0) ? OldContracts.Where(p => p.ProjectId == cboTargetProgramId.EditValue.ToString()) : new List<ContractModel>();
            //_gridLookUpEditContract = XtraColumnCollectionHelper<ContractModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditContractView, values, "ContractName", "ContractId", gridColumnsCollection);

            //XtraColumnCollectionHelper<ContractModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditContractView);
            //_gridLookUpEditContract.EndUpdate();
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboBankPay control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboBankPay_EditValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the EditValueChanged event of the lookUpEditAccountingObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
            _accountingObjectPresenter.DisplayAccoutingObjectBanks(lookUpEditAccountingObject.EditValue.ToString());
            //  txtAccountingObjectBankName.Text = bankName;

            for (int i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
            {
                grdDetailByInventoryItemView.SetRowCellValue(i, "AccountingObjectId", lookUpEditAccountingObject.EditValue);
            }

            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoAccountingObjectId = AccountingObjectId;
                SetDetailFromMaster(grdAccountingView, 1, AccountingObjectId, BankId, TargetProgramId);
            }

            var banks = _model.GetProjectBank(lookUpEditAccountingObject.EditValue.ToString());
            this.AccountingObjectBanks = banks;

            if (banks != null && banks.Count() > 0)
            {
                var firstBank = banks.FirstOrDefault() == null ? null : banks.FirstOrDefault();
                cbObjectBank.EditValue = firstBank == null ? null : firstBank.BankId;
                txtAccountingObjectBankName.EditValue = firstBank == null ? null : firstBank.BankName;

            }
            else
            {
                cbObjectBank.EditValue = "";
                txtAccountingObjectBankName.Text = "";
            }
        }

        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBUTransferDetail_Load(object sender, EventArgs e)
        {
            AutoProjectId = TargetProgramId;
            AutoBankId = BankId;
            AutoAccountingObjectId = AccountingObjectId;
            cboBUCommitmentRequestId.Visible = false;
            txtWithdrawRefNo.Visible = false;
            labelControl14.Visible = false;
            labelControl11.Visible = false;
        }

        private void grdAccountingParallel_Click(object sender, EventArgs e)
        {

        }

        public string BUCommitmentRequestId
        {
            get { return cboBUCommitmentRequestId.EditValue == null ? null : cboBUCommitmentRequestId.EditValue.ToString(); }
            set
            {
                if (IsOpenFrmBUTransferDetail && buTTransferModel != null)
                    cboBUCommitmentRequestId.EditValue = buTTransferModel.BUCommitmentRequestId;
                else
                    cboBUCommitmentRequestId.EditValue = value;
            }
        }
        public IList<BankModel> AccountingObjectBanks
        {
            get { return new List<BankModel>(); }
            set
            {
                if (value == null)
                    value = new List<BankModel>();
                ListBank = value;
                cbObjectBank.Properties.DataSource = value;
                cbObjectBank.Properties.PopulateColumns();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInLookUpEdit(gridColumnsCollection, cbObjectBank);

                cbObjectBank.Properties.DisplayMember = "BankAccount";
                cbObjectBank.Properties.ValueMember = "BankId";

                //_gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                //_gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                //gridColumnsCollection = new List<XtraColumn>();
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                ////XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);

                //_gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                //_gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                //XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
                //if (value.Count > 0)
                //{
                //    cbObjectBank.EditValue = value[0].BankId;
                //    txtBankPayName.EditValue = value[0].BankName;
                //}
            }
        }

        #region accountingobject

        /// <summary>
        /// Gets or sets the accounting object code.
        /// </summary>
        /// <value>
        /// The accounting object code.
        /// </value>
        public string AccountingObjectCode { get; set; }

        /// <summary>
        /// Gets or sets the accounting object category identifier.
        /// </summary>
        /// <value>
        /// The accounting object category identifier.
        /// </value>
        public string AccountingObjectCategoryId { get; set; }


        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the tel.
        /// </summary>
        /// <value>
        /// The tel.
        /// </value>
        public string Tel { get; set; }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>
        /// The fax.
        /// </value>
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>
        /// The bank account.
        /// </value>
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>
        /// The name of the bank.
        /// </value>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the company tax code.
        /// </summary>
        /// <value>
        /// The company tax code.
        /// </value>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Gets or sets the budget code.
        /// </summary>
        /// <value>
        /// The budget code.
        /// </value>
        public string BudgetCode { get; set; }

        /// <summary>
        /// Gets or sets the area code.
        /// </summary>
        /// <value>
        /// The area code.
        /// </value>
        public string AreaCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>
        /// The name of the contact.
        /// </value>
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the contact title.
        /// </summary>
        /// <value>
        /// The contact title.
        /// </value>
        public string ContactTitle { get; set; }

        /// <summary>
        /// Gets or sets the contact sex.
        /// </summary>
        /// <value>
        /// The contact sex.
        /// </value>
        public int? ContactSex { get; set; }

        /// <summary>
        /// Gets or sets the contact mobile.
        /// </summary>
        /// <value>
        /// The contact mobile.
        /// </value>
        public string ContactMobile { get; set; }

        /// <summary>
        /// Gets or sets the contact email.
        /// </summary>
        /// <value>
        /// The contact email.
        /// </value>
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the contact office tel.
        /// </summary>
        /// <value>
        /// The contact office tel.
        /// </value>
        public string ContactOfficeTel { get; set; }

        /// <summary>
        /// Gets or sets the contact home tel.
        /// </summary>
        /// <value>
        /// The contact home tel.
        /// </value>
        public string ContactHomeTel { get; set; }

        /// <summary>
        /// Gets or sets the contact address.
        /// </summary>
        /// <value>
        /// The contact address.
        /// </value>
        public string ContactAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is employee].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is employee]; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmployee { get; set; }

        /// <summary>
        /// Gets or sets the is personal.
        /// </summary>
        /// <value>
        /// The is personal.
        /// </value>
        public bool? IsPersonal { get; set; }

        /// <summary>
        /// Gets or sets the identification number.
        /// </summary>
        /// <value>
        /// The identification number.
        /// </value>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets the issue date.
        /// </summary>
        /// <value>
        /// The issue date.
        /// </value>
        public DateTime? IssueDate { get; set; }

        /// <summary>
        /// Gets or sets the issue by.
        /// </summary>
        /// <value>
        /// The issue by.
        /// </value>
        public string IssueBy { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public string DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the salary scale identifier.
        /// </summary>
        /// <value>
        /// The salary scale identifier.
        /// </value>
        public string SalaryScaleId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [insured].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [insured]; otherwise, <c>false</c>.
        /// </value>
        public bool Insured { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [labour union fee].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [labour union fee]; otherwise, <c>false</c>.
        /// </value>
        public bool LabourUnionFee { get; set; }

        /// <summary>
        /// Gets or sets the family deduction amount.
        /// </summary>
        /// <value>
        /// The family deduction amount.
        /// </value>
        public decimal FamilyDeductionAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether [is customer vendor].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is customer vendor]; otherwise, <c>false</c>.
        /// </value>
        public bool IsCustomerVendor { get; set; }

        /// <summary>
        /// Gets or sets the salary coefficient.
        /// </summary>
        /// <value>
        /// The salary coefficient.
        /// </value>
        public decimal SalaryCoefficient { get; set; }

        /// <summary>
        /// Gets or sets the number family dependent.
        /// </summary>
        /// <value>
        /// The number family dependent.
        /// </value>
        public int NumberFamilyDependent { get; set; }

        /// <summary>
        /// Gets or sets the employee type identifier.
        /// </summary>
        /// <value>
        /// The employee type identifier.
        /// </value>
        public string EmployeeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the salary form.
        /// </summary>
        /// <value>
        /// The salary form.
        /// </value>
        public int SalaryForm { get; set; }

        /// <summary>
        /// Gets or sets the salary percent rate.
        /// </summary>
        /// <value>
        /// The salary percent rate.
        /// </value>
        public decimal SalaryPercentRate { get; set; }

        /// <summary>
        /// Gets or sets the salary amount.
        /// </summary>
        /// <value>
        /// The salary amount.
        /// </value>
        public decimal SalaryAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is pay insurance on salary].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is pay insurance on salary]; otherwise, <c>false</c>.
        /// </value>
        public bool IsPayInsuranceOnSalary { get; set; }

        /// <summary>
        /// Gets or sets the insurance amount.
        /// </summary>
        /// <value>
        /// The insurance amount.
        /// </value>
        public decimal InsuranceAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is un employment insurance].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is un employment insurance]; otherwise, <c>false</c>.
        /// </value>
        public bool IsUnEmploymentInsurance { get; set; }

        /// <summary>
        /// Gets or sets the reference type ao.
        /// </summary>
        /// <value>
        /// The reference type ao.
        /// </value>
        public int RefTypeAO { get; set; }

        /// <summary>
        /// Gets or sets the salary grade.
        /// </summary>
        /// <value>
        /// The salary grade.
        /// </value>
        public int SalaryGrade { get; set; }

        /// <summary>
        /// Gets or sets the custom field1.
        /// </summary>
        /// <value>
        /// The custom field1.
        /// </value>
        public string CustomField1 { get; set; }

        /// <summary>
        /// Gets or sets the custom field2.
        /// </summary>
        /// <value>
        /// The custom field2.
        /// </value>
        public string CustomField2 { get; set; }

        /// <summary>
        /// Gets or sets the custom field3.
        /// </summary>
        /// <value>
        /// The custom field3.
        /// </value>
        public string CustomField3 { get; set; }

        /// <summary>
        /// Gets or sets the custom field4.
        /// </summary>
        /// <value>
        /// The custom field4.
        /// </value>
        public string CustomField4 { get; set; }

        /// <summary>
        /// Gets or sets the custom field5.
        /// </summary>
        /// <value>
        /// The custom field5.
        /// </value>
        public string CustomField5 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is paid insurance for payroll item].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is paid insurance for payroll item]; otherwise, <c>false</c>.
        /// </value>
        public bool IsPaidInsuranceForPayrollItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is born leave].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is born leave]; otherwise, <c>false</c>.
        /// </value>
        public bool IsBornLeave { get; set; }

        /// <summary>
        /// Gets or sets the name of the tax department.
        /// </summary>
        /// <value>
        /// The name of the tax department.
        /// </value>
        public string TaxDepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the name of the treasury.
        /// </summary>
        /// <value>
        /// The name of the treasury.
        /// </value>
        public string TreasuryName { get; set; }

        /// <summary>
        /// Gets or sets the budger chapter identifier.
        /// </summary>
        /// <value>The budger chapter identifier.</value>
        public string BudgetChapterId { get; set; }

        /// <summary>
        /// Gets or sets the fund structure.
        /// </summary>
        /// <value>The fund structure.</value>
        public string BudgetItemId { get; set; }

        /// <summary>
        /// Gets or sets the organization fee code.
        /// </summary>
        /// <value>The organization fee code.</value>
        public string OrganizationFeeCode { get; set; }

        /// <summary>
        /// Gets or sets the organization manage fee.
        /// </summary>
        /// <value>The organization manage fee.</value>
        public string OrganizationManageFee { get; set; }

        /// <summary>
        /// Gets or sets the treasury manage fee.
        /// </summary>
        /// <value>The treasury manage fee.</value>
        public string TreasuryManageFee { get; set; }
        #endregion
        public string ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string BUCACodeID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string ExecutionUnit { get; set; }
        public string DepartmentID { get; set; }
        public decimal TotalAmountApproved { get; set; }
        public string ParentID { get; set; }
        public int Grade { get; set; }
        public bool IsParent { get; set; }
        public bool IsDetailbyActivityAndExpense { get; set; }
        public int? ObjectType { get; set; }
        public string ContractorID { get; set; }
        public string ContractorName { get; set; }
        public string ContractorAddress { get; set; }
        public string ProjectSize { get; set; }
        public string BuildLocation { get; set; }
        public string InvestmentClass { get; set; }
        public int? CDCActivityType { get; set; }
        public string Investment { get; set; }
        public IList<BankModel> ProjectBanks
        {
            get { return ProjectBanks; }
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

                //_gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                //_gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                //gridColumnsCollection = new List<XtraColumn>();
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                //gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                ////XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);

                //_gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                //_gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                //XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
                if (value.Count > 0)
                {
                    if (BankInfoId != "" && BankInfoId != null)
                    {
                        cboBankPay.EditValue = this.BankInfoId;//value[0].BankId;
                        txtBankPayName.EditValue = value.FirstOrDefault(v => v.BankId == BankInfoId) == null ? "" : value.FirstOrDefault(v => v.BankId == BankInfoId).BankName;
                    }
                }
            }
        }

        public IList<BankModel> Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });
                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        public IList<AutoBusinessParallelModel> AutoBusinessParallels
        {
            set
            {
                ListAutoBussParallels = value.ToList();
            }
        }

        public string ProjectEnglishName { get; set; }

        protected override void SetAutoNumber()
        {
            try
            {
                grdDetailByInventoryItemView.AddNewRow();
                var rowHandle = grdDetailByInventoryItemView.GetSelectedRows()[0];

                if (AutoBusinessModel.BudgetSourceId != (new Guid()).ToString())
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetSourceId", AutoBusinessModel.BudgetSourceId);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetChapterCode))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetChapterCode", AutoBusinessModel.BudgetChapterCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetKindItemCode))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetKindItemCode", AutoBusinessModel.BudgetKindItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetSubKindItemCode))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetSubKindItemCode", AutoBusinessModel.BudgetSubKindItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetSubItemCode))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetSubItemCode", AutoBusinessModel.BudgetSubItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetItemCode))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetItemCode", AutoBusinessModel.BudgetItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.AutoBusinessName))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "Description", AutoBusinessModel.AutoBusinessName);
                grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "DebitAccount", AutoBusinessModel.DebitAccount.Replace("\r\n", ""));
                grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "CreditAccount", AutoBusinessModel.CreditAccount.Replace("\r\n", ""));
                grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "MethodDistributeId", AutoBusinessModel.MethodDistributeId);
                grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "CashWithDrawTypeId", AutoBusinessModel.CashWithDrawTypeId);


            }
            //catch {   }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
        }
        private void FrmBUTransferDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(panel1, true, true);
        }

        private void grdDetailByInventoryItemView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (DesignMode)
                return;
            if (e.Column.FieldName == "AmountOC")
            {
                var amountOC = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AmountOC") == null ? 0 : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AmountOC");
                var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null ? 0 : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", exchangeRate * amountOC);
            }

        }

        /// <summary>
        /// thêm mới ctmt
        /// </summary>
        private void cboTargetProgramId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var listObjBeforeAddNew = model.GetProjects().ToList();
                FrmProjectDetail frmProjectDetail = new FrmProjectDetail();
                //frmProjectDetail.KeyValue = this.cboTargetProgramId.EditValue.ToString();
                frmProjectDetail.ShowDialog();
                if (frmProjectDetail.CloseBox)
                {
                    var listObjAfterAddnew = model.GetProjects().ToList();
                    if (listObjBeforeAddNew.Count < listObjAfterAddnew.Count)
                    {
                        _projectsPresenter.Display();
                        grdDetailByInventoryItemView.Columns["ProjectId"].ColumnEdit = _gridLookUpEditProject;
                        grdViewAccountingParallel.Columns["ProjectId"].ColumnEdit = _gridLookUpEditProject;
                        cboTargetProgramId.EditValue = GlobalVariable.ProjectIDAccountingObjectDetailForm;
                    }
                }
            }
        }

        /// <summary>
        /// Button thêm mới bank
        /// </summary>
        private void cboBankPay_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //if (e.Button.Index.Equals(1))
            //{
            //    var frmBankDetail = new FrmBankDetail();
            //    frmBankDetail.ShowDialog();
            //    if (frmBankDetail.CloseBox)
            //    {
            //        if (!String.IsNullOrEmpty(GlobalVariable.BankIDProjectDetailForm))
            //        {
            //          //  _banksPresenter.DisplayActive(true);
            //            cboBankPay.EditValue = GlobalVariable.BankIDProjectDetailForm;
            //        }
            //    }
            //}

            if (e.Button.Index.Equals(1))
            {
                if (this.cboTargetProgramId.EditValue != null)
                {
                    string  before = GlobalVariable.ProjectIDAccountingObjectDetailForm;
                    FrmProjectDetail frmProjectDetail = new FrmProjectDetail();
                    frmProjectDetail.KeyValue = this.cboTargetProgramId.EditValue.ToString();
                    //var textBank = cboBankPay.Text;
                    //var textBankId = cboBankPay.EditValue;
                    string programId = this.cboTargetProgramId.EditValue.ToString();
                    frmProjectDetail.ShowDialog();
                    if (frmProjectDetail.CloseBox)
                    {
                        //cboBankPay.Text = textBank;
                        //cboBankPay.EditValue = textBankId;
                        //if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
                        //{
                        //    this._projectPresenter.DisplayProject(cboTargetProgramId.EditValue.ToString());
                        //    AutoProjectId = TargetProgramId;
                        //    SetDetailFromMaster(grdAccountingView, 3, AccountingObjectId, BankId, TargetProgramId);
                        //}
                        //if (!string.IsNullOrEmpty(GlobalVariable.ProjectIDAccountingObjectDetailForm))
                        //{
                        //    _projectsPresenter.Display();
                        //    cboTargetProgramId.EditValue = GlobalVariable.ProjectIDAccountingObjectDetailForm;
                        //}

                        string after = GlobalVariable.ProjectIDAccountingObjectDetailForm;
                        if (before != after)
                        {
                            var banks = _model.GetProjectBank(cboTargetProgramId.EditValue.ToString()).FirstOrDefault() == null ? null : _model.GetProjectBank(cboTargetProgramId.EditValue.ToString()).FirstOrDefault();
                            cboBankPay.Properties.DataSource = _model.GetProjectBank(cboTargetProgramId.EditValue.ToString());
                            cboBankPay.EditValue = banks == null ? null : banks.BankId;
                            txtBankPayName.Text = banks == null ? null : banks.BankName;
                            //if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
                            //{
                            //    this._accountingObjectsPresenter.DisplayAccountingObjectCategoryId(lookUpEditAccountingObject.EditValue.ToString());
                            //    // AutoProjectId = TargetProgramId;
                            //    //SetDetailFromMaster(grdAccountingView, 3, AccountingObjectId, BankId, TargetProgramId);
                            //    _accountingObjectPresenter.DisplayAccoutingObjectBanks(this.AccountingObjectId);
                            //}
                            if (!string.IsNullOrEmpty(GlobalVariable.ProjectIDAccountingObjectDetailForm))
                            {
                                _accountingObjectsPresenter.Display();
                                cboTargetProgramId.EditValue = GlobalVariable.ProjectIDAccountingObjectDetailForm;
                            }
                            else
                            {
                                cboTargetProgramId.EditValue = programId;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Button thêm mới đối tượng
        /// </summary>
        private void lookUpEditAccountingObject_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                using (var form = new FrmDialogCustom("Bạn muốn thêm loại đối tượng nào?", new string[] { "Đối tượng", "Cán bộ" }))
                {
                    form.ShowDialog();
                    switch (form.Result)
                    {
                        case 1:
                            using (var frmDetail = new FrmXtraAccountingObjectDetail())
                            {
                                frmDetail.ShowDialog();
                                if (frmDetail.CloseBox)
                                {
                                    if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                                    {
                                        _accountingObjectsPresenter.Display();
                                        grdDetailByInventoryItemView.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
                                        grdViewAccountingParallel.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
                                        lookUpEditAccountingObject.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                                    }
                                }
                            }
                            break;
                        case 2:
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
                                        lookUpEditAccountingObject.EditValue = GlobalVariable.EmployeeIDDetailForm;
                                    }
                                }
                            }
                            break;
                        default: break;
                    }
                    //MessageBox.Show(form.Result.ToString());
                }
            }
        }
        #endregion

        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }
        protected override void HiddenParallelAndOpenByCurrencyCode(object sender, CellValueChangedEventArgs e)
        {
            bool visibale = !e.Value.ToString().Equals("VND");
            ShowAmountByCurrencyCode(grdViewAccountingParallel, "Amount", visibale);
        }

        private void cbObjectBank_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                if (this.lookUpEditAccountingObject.EditValue != null)
                {
                    FrmXtraAccountingObjectDetail frmXtraAccountingObjectDetail = new FrmXtraAccountingObjectDetail();

                    frmXtraAccountingObjectDetail.KeyValue = this.lookUpEditAccountingObject.EditValue.ToString();
                    //var textBank = cbObjectBank.Text;
                    //var textBankId = cbObjectBank.EditValue;
                    string projectId = this.lookUpEditAccountingObject.EditValue.ToString();

                    frmXtraAccountingObjectDetail.ShowDialog();
                    ;
                    if (frmXtraAccountingObjectDetail.CloseBox)
                    {
                        //cbObjectBank.Text = textBank;
                        //cbObjectBank.EditValue = textBankId;
                        //cbObjectBank.Text = GlobalVariable.BankObjectId;
                        //cbObjectBank.EditValue = GlobalVariable.BankObjectName;
                        var banks = _model.GetProjectBank(lookUpEditAccountingObject.EditValue.ToString()).FirstOrDefault() == null ? null : _model.GetProjectBank(lookUpEditAccountingObject.EditValue.ToString()).FirstOrDefault();
                        cbObjectBank.Properties.DataSource = _model.GetProjectBank(lookUpEditAccountingObject.EditValue.ToString());
                        cbObjectBank.EditValue = banks == null ? null : banks.BankId;
                        txtAccountingObjectBankName.EditValue = banks == null ? null : banks.BankName;
                        //if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
                        //{
                        //    this._accountingObjectsPresenter.DisplayAccountingObjectCategoryId(lookUpEditAccountingObject.EditValue.ToString());
                        //    // AutoProjectId = TargetProgramId;
                        //    //SetDetailFromMaster(grdAccountingView, 3, AccountingObjectId, BankId, TargetProgramId);
                        //    _accountingObjectPresenter.DisplayAccoutingObjectBanks(this.AccountingObjectId);
                        //}
                        if (!string.IsNullOrEmpty(GlobalVariable.ProjectIDAccountingObjectDetailForm))
                        {
                            _accountingObjectsPresenter.Display();
                            lookUpEditAccountingObject.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                        }
                        else
                        {
                            lookUpEditAccountingObject.EditValue = projectId;
                        }
                    }
                }
            }
        }

        private void txtDocumentIncluded_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (grdDetailByInventoryItemView.RowCount > 0)
            {
                txtDocumentIncluded.Text = "";
                for (int i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
                {
                    var description = grdDetailByInventoryItemView.GetRowCellValue(i, "Description");
                    if (description == null) description = grdDetailByInventoryItemView.GetRowCellValue(i, "ItemName");
                    if (description != null)
                        txtDocumentIncluded.Text = string.IsNullOrEmpty(txtDocumentIncluded.Text)
                            ? description.ToString()
                            : txtDocumentIncluded.Text + ", " + description;
                }
            }
        }
    }
}
