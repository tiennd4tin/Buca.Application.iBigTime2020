/***********************************************************************
 * <copyright file="frminoutwarddetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, October 26, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, October 26, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
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
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.PurchasePurpose;
using Buca.Application.iBigTime2020.View.Dictionary;
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
using Buca.Application.iBigTime2020.View.Inventory;
using Buca.Application.iBigTime2020.Presenter.Inventory;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Inventory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using Buca.Application.iBigTime2020.Model;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusiness;
using DevExpress.XtraGrid;
using DevExpress.XtraRichEdit.Fields;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory
{
    /// <summary>
    /// Class FrmINOutwardDetail.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Inventory.IINInwardOutwardView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.ICashWithdrawTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IActivitysView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IPurchasePurposesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IDepartmentsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IStocksView" />
    public partial class FrmINOutwardDetail : FrmXtraBaseVoucherDetail, IAccountingObjectsView, IINInwardOutwardView, IBudgetSourcesView, IAccountsView,
        IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, ICashWithdrawTypesView, IBanksView, IActivitysView, IProjectsView,
        IFundStructuresView, IPurchasePurposesView, IDepartmentsView, IInventoryItemsView, IStocksView, IBudgetExpensesView, IContractsView, ICapitalPlansView, IAutoBusinessesView
    {
        #region Variable
        /// <summary>
        /// Tài khoản nợ ngầm định
        /// </summary>
        /// 

        AccountModel _defaultDebitAccount;

        /// <summary>
        /// Tài khoản có ngầm định
        /// </summary>
        AccountModel _defaultCreditAccount;

        /// <summary>
        /// Danh sách tài khoản
        /// </summary>
        List<AccountModel> listAccounts;

        public string ConfrontingRefID;

        public decimal Quantityfromlist;
        #endregion

        #region Presenters
        private readonly ContractsPresenter _contractsPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;
        /// <summary>
        /// _budgetExpensesPresenter
        /// </summary>
        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;
        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        /// <summary>
        /// The i n inward outward presenter
        /// </summary>
        private readonly INInwardOutwardPresenter _iNInwardOutwardPresenter;
        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;
        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        /// <summary>
        /// The budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        /// <summary>
        /// The cash withdraw types presenter
        /// </summary>
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;
        /// <summary>
        /// The banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;
        /// <summary>
        /// The activitys presenter
        /// </summary>
        private readonly ActivitysPresenter _activitysPresenter;
        /// <summary>
        /// The projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;
        /// <summary>
        /// The departments presenter
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;
        /// <summary>
        /// The fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        /// <summary>
        /// The purchase purposes presenter
        /// </summary>
        private readonly PurchasePurposesPresenter _purchasePurposesPresenter;
        /// <summary>
        /// The inventory items presenter
        /// </summary>
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        /// <summary>
        /// The stocks presenter
        /// </summary>
        private readonly StocksPresenter _stocksPresenter;
        /// <summary>
        /// The inventory item presenter
        /// </summary>
        private readonly InventoryItemPresenter _inventoryItemPresenter;
        private readonly AutoBusinessesPresenter _autoBusinessPresenter;

        private readonly IModel _model;

        #endregion

        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        private GridView _gridLookUpEditContractView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCapitalPlan;
        private GridView _gridLookUpEditCapitalPlanView;
        private RepositoryItemGridLookUpEdit _gridLookUpBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;

        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        /// The grid look up edit inventory item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItem;
        /// <summary>
        /// The grid look up edit inventory item view
        /// </summary>
        private GridView _gridLookUpEditInventoryItemView;

        /// <summary>
        /// The grid look up edit account
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;
        /// <summary>
        /// The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditAccountView;

        /// <summary>
        /// The grid look up edit account
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        /// <summary>
        /// The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditDebitAccountView;

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
        /// The grid look up edit budget item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        /// <summary>
        /// The grid look up edit budget item view
        /// </summary>
        private GridView _gridLookUpEditBudgetItemView;

        /// <summary>
        /// The grid look up edit budget sub item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        /// <summary>
        /// The grid look up edit budget sub item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubItemView;

        /// <summary>
        /// The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;
        /// <summary>
        /// The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditCashWithdrawTypeView;

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
        /// The grid look up edit activity
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        /// <summary>
        /// The grid look up edit activity view
        /// </summary>
        private GridView _gridLookUpEditActivityView;

        /// <summary>
        /// The grid look up edit project
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        /// <summary>
        /// The grid look up edit project view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        /// <summary>
        /// The grid look up edit department
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        /// <summary>
        /// The grid look up edit department view
        /// </summary>
        private GridView _gridLookUpEditDepartmentView;

        /// <summary>
        /// The grid look up edit fund structure
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        /// <summary>
        /// The grid look up edit fund structure view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

        /// <summary>
        /// The grid look up edit purchase purpose
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditPurchasePurpose;
        /// <summary>
        /// The grid look up edit purchase purpose view
        /// </summary>
        private GridView _gridLookUpEditPurchasePurposeView;

        /// <summary>
        /// The grid look up edit stock
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditStock;
        ///// <summary>
        ///// The grid look up edit stock view
        ///// </summary>
        private GridView _gridLookUpEditStockView;

        /// <summary>
        /// The budget kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetKindItemModels;
        /// <summary>
        /// The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        /// <summary>
        /// The repository method distribute identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;
        /// <summary>
        /// The repository vat rate
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryVATRate;
        /// <summary>
        /// The repository inv type
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryInvType;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAutoBusiness;
        private GridView _gridLookUpEditDebitAutoBusinessView;

        #endregion

        private List<INInwardOutwardDetailModel> _list;
        public List<INInwardOutwardDetailModel> ListSourceDetail;
        private List<ProjectModel> _projectModel;
        public List<InventoryItemModel> _InventoryItems;
        private List<ContractModel> _contractModels;
        public bool IsFIFO;
        List<RepositoryItemGridLookUpEdit> inplaceEditors = new List<RepositoryItemGridLookUpEdit>();
        private List<BudgetItemModel> _budgetItemModels;
        #region Form Event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmINOutwardDetail" /> class.
        /// </summary>
        public FrmINOutwardDetail()
        {
            InitializeComponent();
            _iNInwardOutwardPresenter = new INInwardOutwardPresenter(this);
            _contractsPresenter = new ContractsPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
            _autoBusinessPresenter = new AutoBusinessesPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            //_iNInwardOutwardPresenter = new INInwardOutwardPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _purchasePurposesPresenter = new PurchasePurposesPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _stocksPresenter = new StocksPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
            grdMaster.Visible = true;
            grdMaster.Location = new Point(7, 198);
            lkAccountingObjectCategory.Visible = true;
            lbAccountingObjectCategory.Visible = true;
            _model = new Model.Model();

            grdDetailByInventoryItemView.OptionsView.ShowFooter = true;
            AutoAccountingObjectId = AccountingObjectId;
            this.grdDetailByInventoryItemView.InitNewRow += GrdAccountingView_InitNewRow;
            grdViewParallel = grdViewgrdInInwardOurwardDetailParallel;
            SAmountEx = "AmountExchange";
            SAmountOCEx = "Amount";
            SAmountExParallel = "AmountOC";
            SAmountOCExParallel = "Amount";
        }
        public List<StockModel> OldStocks { get; set; }
        private void GrdAccountingView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            InitDetailRow(e, grdAccountingView);
        }
        /// <summary>
        /// Handles the Load event of the FrmINOutwardDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmINOutwardDetail_Load(object sender, EventArgs e)
        {
            _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(listAccounts, (int)BaseRefTypeId, RefTypes.ToList());
            _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(listAccounts, (int)BaseRefTypeId, RefTypes.ToList());
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

        #region Control Events

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




            var description = (string)cboObjectCode.GetColumnValue("Description");

            cboObjectName.Text = accountName;
            txtAddress.Text = address;

            txtDescription.Text = description;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoAccountingObjectId = AccountingObjectId;
                SetDetailFromMaster(grdAccountingView, 1, AccountingObjectId, BankId, null);
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
                        grdView.Columns[column.ColumnName].Visible = true;
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

            var vatRates = new Dictionary<string, string> { { "0", "0%" }, { "10", "10%" }, { "15", "15%" }, { "", "KCT" } };
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

        #region overrides

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            //  tabMain.Location = new Point(6, 249);
            tabMain.SelectedTabPage = tabInventoryItem;
            ///Tintv ẩn tab Thốn kế và thuế
            tabMain.TabPages[4].PageVisible = false;
            tabMain.TabPages[3].PageVisible = false;
            tabMain.TabPages[2].PageVisible = false;
            grdInInwardOurwardDetailParallel.DataSource = bindingSourceDetailParallel;
        }
        ///<summary>
        ///Grids the purchase show editor
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void GridPurchaseShowEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            INInwardOutwardDetailModel data = view.GetFocusedRow() as INInwardOutwardDetailModel;
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
        /// <summary>
        /// Grids the purchase cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridPurchaseCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            IModel model = new Model.Model();
            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetItem = model.GetBudgetItems().Where(x => x.BudgetItemCode == budgetSubItemCode);

                foreach (var item in budgetItem)
                {
                    var budgetItemCode = model.GetBudgetItem(item.ParentId);
                    if (budgetItemCode != null) grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode.BudgetItemCode);
                }

            }
            if (e.Column.FieldName == "ProjectId")
            {
                /* var project = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "ProjectId");
                 var contracts = _contractModels.Where(x => x.ProjectId == project).ToList();
                 if (contracts == null || contracts.Count == 0) _gridLookUpEditContract.DataSource = _contractModels.ToList();
                 else
                 {
                     _gridLookUpEditContract.DataSource = contracts;

                 }*/

            }
            if (e.Column.FieldName == "StockId")
            {
                if (e.Value == null)
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
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "CreditAccount", accoutingObjectCate.DefaultAccountNumber);
                }
            }



            if (e.Column.FieldName == "AutoBusinessId")
            {
                var autoBusinessId = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AutoBusinessId") == null ? string.Empty : grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AutoBusinessId").ToString();
                if (autoBusinessId != string.Empty)
                {
                    var autoBusiness = (AutoBusinessModel)_gridLookUpEditDebitAutoBusiness.GetRowByKeyValue(autoBusinessId);
                    //&& autoBusiness.RefTypeId == (int)BaseRefTypeId
                    if (autoBusiness != null)
                    {
                        if (autoBusiness.BudgetSourceId == "00000000-0000-0000-0000-000000000000") grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetSourceId", null);
                        else
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetSourceId", autoBusiness.BudgetSourceId);
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
            if (e.Column.FieldName == "InventoryItemId")
            {
                var inventoryItemModel = (InventoryItemModel)_gridLookUpEditInventoryItem.GetRowByKeyValue(e.Value);
                var inventoryItemName = inventoryItemModel == null ? "" : inventoryItemModel.InventoryItemName;
                var unit = inventoryItemModel == null ? "" : inventoryItemModel.Unit;
                if (inventoryItemName != null)
                {
                    if (inventoryItemModel != null)
                    {
                        var inventoryItem = model.GetInventoryItem(inventoryItemModel.InventoryItemId);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "StockId", inventoryItem.DefaultStockId);
                    }

                    //grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DebitAccount",
                    //inventoryItem.InventoryAccount);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Description", inventoryItemName);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Unit", unit);
                }
            }


            var quantity = (grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity") == null ? 0 : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity"));
            var priceUnit = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "UnitPrice") == null ? 0 : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "UnitPrice");
            var amount = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Amount");
            var inventoryItemId = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "InventoryItemId");


            switch (e.Column.FieldName)
            {
                case "Quantity":
                    IsFIFO = true;

                    if (amount != quantity * priceUnit)
                    {
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", quantity * priceUnit);
                    }
                    //pp đích danh
                    if (GlobalVariable.DefaultCostMethod == 2)
                    {
                        //if (quantity > Quantityfromlist)
                        //{
                        //    XtraMessageBox.Show("Số lượng vượt quá chứng từ nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    grdDetailByInventoryItemView.DeleteRow(e.RowHandle);
                        //    //grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Quantity", 1);
                        //    return;
                        //}
                    }
                    //pp nhập trước xuất trước
                    if (GlobalVariable.DefaultCostMethod == 3)
                    {
                        if (ListSourceDetail != null)
                            _list = ListSourceDetail.Where(c => c.InventoryItemId != inventoryItemId).ToList();
                        else
                            _list = new List<INInwardOutwardDetailModel>();
                        var ListInventoryItem__ = model.GetInventoryItemsByInventoryItemdestinations(inventoryItemId, RefDate, 0, 0);
                        //var inventoryItem = model.GetInventoryItem(inventoryItemId);
                        var inventoryItem = _InventoryItems.FirstOrDefault(c => c.InventoryItemId == inventoryItemId);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Description", inventoryItem.InventoryItemName);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "StockId", inventoryItem.DefaultStockId);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Unit", inventoryItem.Unit);
                        foreach (var item in ListInventoryItem__)
                        {
                            if (quantity < item.Quantity)
                            {
                                var row = new INInwardOutwardDetailModel()
                                {
                                    InventoryItemId = item.InventoryItemId,

                                    StockId = item.StockId,
                                    Quantity = quantity,
                                    UnitPrice = (decimal)item.UnitPrice,
                                    Amount = quantity * (decimal)item.UnitPrice,
                                    ConfrontingRefId = item.RefDetailId,
                                    CreditAccount = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "CreditAccount"),
                                    DebitAccount = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "DebitAccount"),
                                    Description = inventoryItem.InventoryItemName,
                                    //DebitAccount = _defaultDebitAccount.AccountNumber,
                                    //CreditAccount = _defaultCreditAccount.AccountNumber,
                                    Unit = item.Unit
                                };
                                _list.Add(row);
                                ListSourceDetail = _list;
                                InwardOutwardDetails = ListSourceDetail;

                                break;
                            }
                            if (quantity == item.Quantity)
                            {
                                var row = new INInwardOutwardDetailModel()
                                {
                                    InventoryItemId = item.InventoryItemId,

                                    StockId = item.StockId,
                                    Quantity = quantity,
                                    UnitPrice = (decimal)item.UnitPrice,
                                    ConfrontingRefId = item.RefDetailId,
                                    Amount = quantity * (decimal)item.UnitPrice,
                                    // CreditAccount = "152",
                                    CreditAccount = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "CreditAccount"),
                                    DebitAccount = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "DebitAccount"),
                                    Description = inventoryItem.InventoryItemName,
                                    Unit = item.Unit
                                };
                                _list.Add(row);
                                ListSourceDetail = _list;
                                InwardOutwardDetails = ListSourceDetail;

                                break;
                            }
                            if (quantity > item.Quantity)
                            {
                                var CurenQuantity = quantity - item.Quantity;
                                quantity = (decimal)CurenQuantity;
                                var row = new INInwardOutwardDetailModel()
                                {
                                    InventoryItemId = item.InventoryItemId,

                                    StockId = item.StockId,
                                    Quantity = (decimal)item.Quantity,
                                    UnitPrice = (decimal)item.UnitPrice,
                                    Amount = (decimal)item.Quantity * (decimal)item.UnitPrice,
                                    ConfrontingRefId = item.RefDetailId,
                                    //    CreditAccount = "152",
                                    CreditAccount = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "CreditAccount"),
                                    DebitAccount = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "DebitAccount"),
                                    Description = inventoryItem.InventoryItemName,
                                    Unit = item.Unit
                                };
                                _list.Add(row);
                            }
                            else
                            {
                            }
                            ListSourceDetail = _list;
                            InwardOutwardDetails = ListSourceDetail;
                        }
                    }
                    break;
                case "UnitPrice":
                    if (amount != quantity * priceUnit)
                    {
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", quantity * priceUnit);
                    }
                    break;
                case "InventoryItemId":
                    if (!string.IsNullOrEmpty(inventoryItemId))
                    {
                        var inventoryItemValue = _InventoryItems.FirstOrDefault(c => c.InventoryItemId == inventoryItemId);
                        //pp tính giá đích danh 
                        if (GlobalVariable.DefaultCostMethod == 2)
                        {
                            var frmListInventory = new ListInventoryItem();
                            frmListInventory.InventoryItemsId = inventoryItemId;
                            frmListInventory.RefDate = RefDate;
                            frmListInventory.RefOrder = 0;
                            frmListInventory.UnitPriceDecimalDigitNumber = 0;
                            frmListInventory.ShowDialog();
                            //ConfrontingRefID đối ứng với [RefDetailID] để tính số lượng
                            ConfrontingRefID = frmListInventory.RefDetailID;
                            Quantityfromlist = frmListInventory.Quantity;
                            var ListInventoryItem = model.GetInventoryItemsByInventoryItemdestinations(inventoryItemId, RefDate, 0, 0);
                            foreach (var item in ListInventoryItem)
                            {
                                if (frmListInventory.RefNo == item.RefNo)
                                {
                                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Quantity", item.Quantity);
                                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "RefNo", item.RefNo);
                                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "UnitPrice", item.UnitPrice);
                                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Unit", item.Unit);
                                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "ConfrontingRefId", item.RefDetailId);
                                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DebitAccount", inventoryItemValue.COGSAccount);
                                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "CreditAccount", inventoryItemValue.InventoryAccount);
                                }
                            }
                        }
                        //pp nhập trước xuất trước
                        if (GlobalVariable.DefaultCostMethod == 3)
                        {
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Description", inventoryItemValue.InventoryItemName);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "StockId", inventoryItemValue.DefaultStockId);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DebitAccount", inventoryItemValue.COGSAccount);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "CreditAccount", inventoryItemValue.InventoryAccount);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Unit", inventoryItemValue.Unit);
                        }
                        var inventoryItem = model.GetInventoryItem(inventoryItemId);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Description", inventoryItem.InventoryItemName);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "StockId", inventoryItem.DefaultStockId);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Unit", inventoryItem.Unit);

                    }
                    break;
            }
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
                IModel model = new Model.Model();
                if (e.Column.FieldName == "BudgetSubItemCode")
                {
                    var budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                    var budgetItem = model.GetBudgetItems().Where(x => x.BudgetItemCode == budgetSubItemCode);

                    foreach (var item in budgetItem)
                    {
                        var budgetItemCode = model.GetBudgetItem(item.ParentId);
                        grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode.BudgetItemCode);
                    }

                }
                if (e.Column.FieldName == "AutoBusinessId")
                {
                    var autoBusinessId = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AutoBusinessId") == null ? string.Empty : grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AutoBusinessId").ToString();
                    if (autoBusinessId != string.Empty)
                    {
                        var autoBusiness = (AutoBusinessModel)_gridLookUpEditDebitAutoBusiness.GetRowByKeyValue(autoBusinessId);
                        //&& autoBusiness.RefTypeId == (int)BaseRefTypeId
                        if (autoBusiness != null)
                        {
                            if (autoBusiness.BudgetSourceId == "00000000-0000-0000-0000-000000000000") grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetSourceId", null);
                            else
                                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetSourceId", autoBusiness.BudgetSourceId);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DebitAccount", autoBusiness.DebitAccount);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "CreditAccount", autoBusiness.CreditAccount);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetChapterCode", autoBusiness.BudgetChapterCode);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetKindItemCode", autoBusiness.BudgetKindItemCode);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", autoBusiness.BudgetSubKindItemCode);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetItemCode", autoBusiness.BudgetItemCode);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetSubItemCode", autoBusiness.BudgetSubItemCode);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "MethodDistributeID", autoBusiness.MethodDistributeId);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "CashWithDrawTypeID", autoBusiness.CashWithDrawTypeId);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Description", autoBusiness.Description);
                        }
                    }
                }
                if (e.Column.FieldName == "StockId")
                {
                    var stockId = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "StockId") == null ? string.Empty : grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "StockId").ToString();
                    if (!String.IsNullOrEmpty(stockId) && OldStocks != null && OldStocks.Count > 0)
                    {
                        var stock = OldStocks.FirstOrDefault(o => o.StockId == stockId);
                        if (stock != null)
                        {
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "CreditAccount", stock.DefaultAccountNumber);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _contractsPresenter.Display();
            _capitalPlansPresenter.Display();
            _accountingObjectsPresenter.DisplayActive(true);
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayByIsDetail(GlobalVariable.IsPostToParentAccount);
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _banksPresenter.DisplayActive(true);
            _activitysPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.DisplayActive(true);
            _purchasePurposesPresenter.DisplayByIsActive(true);
            _departmentsPresenter.DisplayActive();
            _inventoryItemsPresenter.DisplayByIsToolAndIsStock(true);
            _stocksPresenter.DisplayByIsActive(true);
            _budgetExpensesPresenter.DisplayActive();

            _autoBusinessPresenter.DisplayActive();
            InitRepositoryControlData();
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((INInwardOutwardModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((INInwardOutwardModel)MasterBindingSource.Current).RefId;
            }

            _iNInwardOutwardPresenter.Display(KeyValue, true, true);
            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.INOutward;
            if (RefId == null)
            {
                grdAccountingView.AddNewRow();
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
            if (AccountingObjectId == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingObjectId"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboObjectCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(RefNo) && (_iNInwardOutwardPresenter.IsExistRefNo(KeyValue, RefNo, 202)))
            {
                XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResReceiptExistRefNo"), RefNo),
                   ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                txtRefNo.SelectAll();
                return false;
            }
            var receiptVoucherDetails = InwardOutwardDetails;
            if (receiptVoucherDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            foreach (var inOutwardDEtail in InwardOutwardDetails)
            {
                if (string.IsNullOrEmpty(inOutwardDEtail.InventoryItemId))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemId"), detailContent,
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    return false;
                }

                if (inOutwardDEtail.StockId == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResStockId"), detailContent,
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
        /// 

        protected override void InitDetailRowForAcountingDetailByInventoryItem(InitNewRowEventArgs e, GridView view)
        {
            AddNewRepoInventory();
            if (_defaultDebitAccount != null)
                view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
            if (_defaultCreditAccount != null)
                view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
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
        private void InitNewRow(InitNewRowEventArgs e, GridView view)
        {
            if (view == null)
                return;

            view.SetRowCellValue(e.RowHandle, nameof(INInwardOutwardModel.AccountingObjectId), this.AccountingObjectId);
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
                view.SetRowCellValue(e.RowHandle, "CreditAccount", "152");
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
        /// <returns>System.String.</returns>
        protected override string SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = KeyValue;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = null;

            var result = new DialogResult();
            if (INInwardOutwardDetailParallels.Count > 0)
            {
                result = XtraMessageBox.Show("Bạn có muốn cập nhật lại định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                result = XtraMessageBox.Show("Bạn có muốn sinh tự động định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            return result == DialogResult.OK ? _iNInwardOutwardPresenter.Save(true, GlobalVariable.IsOutwardNegativeStock) : _iNInwardOutwardPresenter.Save(false, GlobalVariable.IsOutwardNegativeStock);

        }

        /// <summary>
        /// Reloads the parallel grid.
        /// </summary>
        protected override void ReloadParallelGrid()
        {
            _iNInwardOutwardPresenter.Display(KeyValue, true, true);
        }
        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new INInwardOutwardPresenter(null).Delete(KeyValue);
        }

        #endregion

        #region ICAReceiptView

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
            get { return txtRefNo.Text.Trim(); }
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
        /// Gets or sets the outward reference no.
        /// </summary>
        /// <value>The outward reference no.</value>
        public string OutwardRefNo { get; set; }

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
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the document included.
        /// Kèm theo
        /// </summary>
        /// <value>The document included.</value>
        public string DocumentInclued
        {
            get { return txtDocumentInclued.Text.Trim(); }
            set { txtDocumentInclued.Text = value; }
        }

        /// <summary>
        /// Gets or sets the type of the inv.
        /// </summary>
        /// <value>The type of the inv.</value>
        public int? InvType { get; set; }
        /// <summary>
        /// Gets or sets the inv date or withdraw reference date.
        /// </summary>
        /// <value>The inv date or withdraw reference date.</value>
        public DateTime? InvDateOrWithdrawRefDate { get; set; }
        /// <summary>
        /// Gets or sets the inv series.
        /// </summary>
        /// <value>The inv series.</value>
        public string InvSeries { get; set; }
        /// <summary>
        /// Gets or sets the inv no or withdraw reference no.
        /// </summary>
        /// <value>The inv no or withdraw reference no.</value>
        public string InvNoOrWithdrawRefNo { get; set; }
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
                return (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmountOC");
            }
            set
            {
                OldTotalAmountOC = value;
                gridViewMaster.SetRowCellValue(0, "TotalAmountOC", value);
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
        public decimal OldTotalAmountOC { get; set; }
        public decimal OldTotalTaxAmount { get; set; }
        /// <summary>
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>The total tax amount.</value>
        public decimal TotalTaxAmount
        {
            get
            {
                return (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmount");
            }
            set
            {
                OldTotalTaxAmount = value;
                gridViewMaster.SetRowCellValue(0, "TotalAmount", value);
            }
        }

        /// <summary>
        /// Gets or sets the total outward amount.
        /// </summary>
        /// <value>The total outward amount.</value>
        public decimal TotalOutwardAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FrmINOutwardDetail"/> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int? RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the invoice form.
        /// </summary>
        /// <value>The invoice form.</value>
        public int? InvoiceForm { get; set; }

        /// <summary>
        /// Gets or sets the invoice form number identifier.
        /// </summary>
        /// <value>The invoice form number identifier.</value>
        public string InvoiceFormNumberId { get; set; }

        /// <summary>
        /// Gets or sets the inv series prefix.
        /// </summary>
        /// <value>The inv series prefix.</value>
        public string InvSeriesPrefix { get; set; }

        /// <summary>
        /// Gets or sets the inv series suffix.
        /// </summary>
        /// <value>The inv series suffix.</value>
        public string InvSeriesSuffix { get; set; }

        /// <summary>
        /// Gets or sets the pay form.
        /// </summary>
        /// <value>The pay form.</value>
        public string PayForm { get; set; }

        /// <summary>
        /// Gets or sets the company taxcode.
        /// </summary>
        /// <value>The company taxcode.</value>
        public string CompanyTaxcode { get; set; }

        /// <summary>
        /// Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>The relation reference identifier.</value>
        public string RelationRefId { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>The bu commitment request identifier.</value>
        public string BUCommitmentRequestId { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object contact.
        /// </summary>
        /// <value>The name of the accounting object contact.</value>
        public string AccountingObjectContactName { get; set; }

        /// <summary>
        /// Gets or sets the list no.
        /// </summary>
        /// <value>The list no.</value>
        public string ListNo { get; set; }

        /// <summary>
        /// Gets or sets the list date.
        /// </summary>
        /// <value>The list date.</value>
        public DateTime? ListDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is attach list.
        /// </summary>
        /// <value><c>true</c> if this instance is attach list; otherwise, <c>false</c>.</value>
        public bool IsAttachList { get; set; }

        /// <summary>
        /// Gets or sets the list common name inventory.
        /// </summary>
        /// <value>The list common name inventory.</value>
        public string ListCommonNameInventory { get; set; }

        /// <summary>
        /// Gets or sets the total receipt amount.
        /// </summary>
        /// <value>The total receipt amount.</value>
        public decimal TotalReceiptAmount { get; set; }

        /// <summary>
        /// Gets or sets the generated reference identifier.
        /// </summary>
        /// <value>The generated reference identifier.</value>
        public string GeneratedRefId
        {
            get;

            set;
        }

        /// <summary>
        /// Gets or sets the inward outward details.
        /// </summary>
        /// <value>The inward outward details.</value>
        public IList<INInwardOutwardDetailModel> InwardOutwardDetails
        {
            get
            {
                var iNInwardOutwardDetail = new List<INInwardOutwardDetailModel>();
                if (grdAccountingView.DataSource != null && grdAccountingView.DataRowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.DataRowCount; i++)
                    {
                        var rowVoucher = (INInwardOutwardDetailModel)grdAccountingView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var budgetKindItemCode = "";
                            if (!string.IsNullOrEmpty(rowVoucher.BudgetKindItemCode))
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
                            if (GlobalVariable.DefaultCostMethod == 3)
                            {
                                var item = new INInwardOutwardDetailModel
                                {
                                    AutoBusinessId = rowVoucher.AutoBusinessId,
                                    Description = string.IsNullOrEmpty(rowVoucher.Description) ? string.Empty : rowVoucher.Description.Trim(),
                                    DebitAccount = rowVoucher.DebitAccount,
                                    CreditAccount = rowVoucher.CreditAccount,
                                    Amount = rowVoucher.Amount,
                                    AmountExchange = rowVoucher.AmountExchange,
                                    StockId = rowVoucher.StockId,
                                    InventoryItemId = rowVoucher.InventoryItemId,
                                    BudgetSourceId = rowVoucher.BudgetSourceId,
                                    BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                    BudgetKindItemCode = rowVoucher.BudgetKindItemCode,
                                    BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                    BudgetItemCode = rowVoucher.BudgetItemCode,
                                    BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                    MethodDistributeId = rowVoucher.MethodDistributeId,
                                    CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                                    BankId = rowVoucher.BankId,
                                    ConfrontingRefNo = rowVoucher.ConfrontingRefNo,
                                    Unit = rowVoucher.Unit,
                                    Quantity = rowVoucher.Quantity,
                                    UnitPrice = rowVoucher.UnitPrice,
                                    SortOrder = i,
                                    ConfrontingRefId = rowVoucher.ConfrontingRefId,
                                    AccountingObjectId = rowVoucher.AccountingObjectId,
                                    ProjectId = rowVoucher.ProjectId,
                                    ContractId = rowVoucher.ContractId,
                                    CapitalPlanId = rowVoucher.CapitalPlanId,
                                    ActivityId = rowVoucher.ActivityId,


                                };
                                iNInwardOutwardDetail.Add(item);

                            }
                            if (GlobalVariable.DefaultCostMethod == 2)
                            {
                                var item = new INInwardOutwardDetailModel
                                {
                                    AutoBusinessId = rowVoucher.AutoBusinessId,
                                    Description = string.IsNullOrEmpty(rowVoucher.Description) ? string.Empty : rowVoucher.Description.Trim(),
                                    DebitAccount = rowVoucher.DebitAccount,
                                    CreditAccount = rowVoucher.CreditAccount,
                                    Amount = rowVoucher.Amount,
                                    AmountExchange = rowVoucher.AmountExchange,
                                    StockId = rowVoucher.StockId,
                                    InventoryItemId = rowVoucher.InventoryItemId,
                                    BudgetSourceId = rowVoucher.BudgetSourceId,
                                    BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                    BudgetKindItemCode = rowVoucher.BudgetKindItemCode,
                                    BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                    BudgetItemCode = rowVoucher.BudgetItemCode,
                                    BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                    MethodDistributeId = rowVoucher.MethodDistributeId,
                                    CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                                    BankId = rowVoucher.BankId,
                                    ConfrontingRefNo = rowVoucher.ConfrontingRefNo,
                                    Unit = rowVoucher.Unit,
                                    Quantity = rowVoucher.Quantity,
                                    UnitPrice = rowVoucher.UnitPrice,
                                    SortOrder = i,
                                    ConfrontingRefId = rowVoucher.ConfrontingRefId,
                                    AccountingObjectId = rowVoucher.AccountingObjectId,
                                    ProjectId = rowVoucher.ProjectId,
                                    ContractId = rowVoucher.ContractId,
                                    CapitalPlanId = rowVoucher.CapitalPlanId,
                                    ActivityId = rowVoucher.ActivityId,

                                    //ConfrontingRefId = ConfrontingRefID,
                                };
                                iNInwardOutwardDetail.Add(item);

                            }
                            if (GlobalVariable.DefaultCostMethod == 0 || GlobalVariable.DefaultCostMethod == 1)
                            {
                                var item = new INInwardOutwardDetailModel
                                {
                                    AutoBusinessId = rowVoucher.AutoBusinessId,
                                    Description = string.IsNullOrEmpty(rowVoucher.Description) ? string.Empty : rowVoucher.Description.Trim(),
                                    DebitAccount = rowVoucher.DebitAccount,
                                    CreditAccount = rowVoucher.CreditAccount,
                                    Amount = rowVoucher.Amount,
                                    AmountExchange = rowVoucher.AmountExchange,
                                    StockId = rowVoucher.StockId,
                                    InventoryItemId = rowVoucher.InventoryItemId,
                                    BudgetSourceId = rowVoucher.BudgetSourceId,
                                    BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                    BudgetKindItemCode = rowVoucher.BudgetKindItemCode,
                                    BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                    BudgetItemCode = rowVoucher.BudgetItemCode,
                                    BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                    MethodDistributeId = rowVoucher.MethodDistributeId,
                                    CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                                    BankId = rowVoucher.BankId,
                                    ConfrontingRefNo = rowVoucher.ConfrontingRefNo,
                                    Unit = rowVoucher.Unit,
                                    Quantity = rowVoucher.Quantity,
                                    UnitPrice = rowVoucher.UnitPrice,
                                    SortOrder = i,
                                    AccountingObjectId = rowVoucher.AccountingObjectId,
                                    ProjectId = rowVoucher.ProjectId,
                                    ContractId = rowVoucher.ContractId,
                                    CapitalPlanId = rowVoucher.CapitalPlanId,
                                    ActivityId = rowVoucher.ActivityId,

                                    //ConfrontingRefId = ConfrontingRefID,
                                };
                                iNInwardOutwardDetail.Add(item);

                            }


                        }
                    }
                }
                if (iNInwardOutwardDetail.Count > 0)
                {
                    if (grdAccountingView.DataSource != null && grdAccountingView.DataRowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingView.DataRowCount; i++)
                        {
                            var rowVoucher = (INInwardOutwardDetailModel)grdAccountingView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                iNInwardOutwardDetail[i].InventoryItemId = rowVoucher.InventoryItemId;
                                iNInwardOutwardDetail[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                                iNInwardOutwardDetail[i].ActivityId = rowVoucher.ActivityId;
                                iNInwardOutwardDetail[i].ProjectId = rowVoucher.ProjectId;
                                iNInwardOutwardDetail[i].FundStructureId = rowVoucher.FundStructureId;
                                iNInwardOutwardDetail[i].DepartmentId = rowVoucher.DepartmentId;
                                iNInwardOutwardDetail[i].BudgetExpenseId = rowVoucher.BudgetExpenseId;
                                iNInwardOutwardDetail[i].SortOrder = i;
                            }
                        }
                    }
                }

                return iNInwardOutwardDetail;
            }

            set
            {
                // TotalAmountOC = OldTotalTaxAmount;
                var newExhangeRate = (OldTotalTaxAmount) / (OldTotalAmountOC == 0 ? 1 : OldTotalAmountOC);
                newExhangeRate = newExhangeRate == 0 ? 1 : newExhangeRate;
                if (newExhangeRate != 1)
                {
                    gridViewMaster.SetRowCellValue(0, "CurrencyCode", "USD");
                }
                value = value.OrderBy(c => c.SortOrder).ToList();
                gridViewMaster.SetRowCellValue(0, "ExchangeRate", newExhangeRate);
                //var totalAmount = value.Sum(v => v.Amount);
                //if (totalAmount > 0)
                //{
                //    gridViewMaster.SetRowCellValue(0, "TotalAmount", totalAmount);
                //    gridViewMaster.SetRowCellValue(0, "TotalAmountOC", totalAmount);

                //}

                value.ToList().ForEach(item =>
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
                    grdAccounting.RepositoryItems.Add(newE);
                    grdAccountingDetail.RepositoryItems.Add(newE);
                });

                if (IsFIFO == true)
                {
                    value = ListSourceDetail == null ? value : ListSourceDetail.OrderBy(c => c.SortOrder).ToList();
                    bindingSourceDetail.DataSource = ListSourceDetail;
                    grdAccountingView.PopulateColumns(ListSourceDetail);
                    grdAccountingDetailView.PopulateColumns(ListSourceDetail);
                }

                bindingSourceDetail.DataSource = value ?? new List<INInwardOutwardDetailModel>();

                grdDetailByInventoryItemView.PopulateColumns(value);
                grdAccountingView.PopulateColumns(value);
                grdAccountingDetailView.PopulateColumns(value);

                #region columns for grdDetailByInventoryItemView

                var columnsCollection = new List<XtraColumn>();

                if (GlobalVariable.DefaultCostMethod == 2)
                {
                    columnsCollection = new List<XtraColumn>
                    {
                         new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},

                    new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 200,
                        ColumnCaption = "Mã VT,HH",
                        ColumnPosition = 1,
                        AllowEdit = true,
                        Alignment = HorzAlignment.Near,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 600,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "StockId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditStock,
                        ColumnWith = 200,
                        ColumnCaption = "Kho",
                        ColumnPosition = 3,
                        AllowEdit = true,
                    },

                        new XtraColumn
                        {
                            ColumnName = "Unit",
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnCaption = "ĐVT",
                            ColumnPosition = 4,
                            AllowEdit = true,
                            //RepositoryControl = _gri
                        },
                        new XtraColumn
                        {
                            ColumnName = "Quantity",
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnCaption = "Số lượng",
                            ColumnPosition = 5,
                            AllowEdit = true,
                            ColumnType = UnboundColumnType.Integer
                        },

                        new XtraColumn
                        {
                            ColumnName = "UnitPrice",
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnCaption = "Đơn giá",
                            ColumnPosition = 6,
                            AllowEdit = false,
                            ColumnType = UnboundColumnType.Decimal
                        },
                         new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditActivity,
                        ColumnWith = 200,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 7,
                        AllowEdit = true,
                    },

                        new XtraColumn
                        {
                            ColumnName = "ConfrontingRefNo",
                            ColumnVisible = false,
                            AllowEdit = true
                        },
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
                    new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    //new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ConfrontingRefId", ColumnVisible = false},

                    new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},

                    };
                }
                else
                {
                    columnsCollection = new List<XtraColumn>
                    {

                        new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "AutoBusinessId",
                            ColumnVisible = true,
                            RepositoryControl = _gridLookUpEditDebitAutoBusiness,
                            ColumnWith = 200,
                            ColumnCaption = "ĐK tự động",
                            ColumnPosition = 1,
                            AllowEdit = true,
                            Alignment = HorzAlignment.Near,
                        },
                          new XtraColumn
                         {
                             ColumnName = "StockId",
                             ColumnVisible = true,
                             RepositoryControl = _gridLookUpEditStock,
                            ColumnWith = 200,
                            ColumnCaption = "Kho",
                            ColumnPosition = 2,
                            AllowEdit = true,
                            Alignment = HorzAlignment.Default,
                         },
                        new XtraColumn
                        {
                            ColumnName = "InventoryItemId",
                            ColumnVisible = true,
                            //RepositoryControl = _gridLookUpEditInventoryItem,
                            ColumnWith = 200,
                            ColumnCaption = "Mã vật tư,CCDC",
                            ColumnPosition = 3,
                            AllowEdit = true,
                            Alignment = HorzAlignment.Near,
                        },

                        new XtraColumn
                        {
                            ColumnName = "DebitAccount",
                            ColumnVisible = true,
                            RepositoryControl = _gridLookUpEditDebitAccount,
                            ColumnWith = 80,
                            ColumnCaption = "TK Nợ",
                            ColumnPosition = 4,
                            AllowEdit = true
                        },
                        new XtraColumn
                        {
                            ColumnName = "CreditAccount",
                            ColumnVisible = true,
                            ColumnWith = 80,
                            ColumnCaption = "TK Có",
                            ColumnPosition = 5,
                            AllowEdit = true,
                            RepositoryControl = _gridLookUpEditAccount
                        },
                        new XtraColumn
                        {
                            ColumnName = "Description",
                            ColumnVisible = true,
                            ColumnWith = 300,
                            ColumnCaption = "Diễn giải",
                            ColumnPosition = 6,
                            AllowEdit = true,
                        },
                              new XtraColumn
                        {
                            ColumnName = "Unit",
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnCaption = "ĐVT",
                            ColumnPosition = 7,
                            AllowEdit = true,
                            //RepositoryControl = _gri
                        },
                        new XtraColumn
                        {
                            ColumnName = "Quantity",
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnCaption = "Số lượng",
                            ColumnPosition = 8,
                            AllowEdit = true,
                            ColumnType = UnboundColumnType.Integer
                        },
                        new XtraColumn
                        {
                            ColumnName = "UnitPrice",
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnCaption = "Đơn giá",
                            ColumnPosition = 9,
                            AllowEdit = true,
                            ColumnType = UnboundColumnType.Decimal
                        },
                        new XtraColumn
                        {
                            ColumnName = "Amount",
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnCaption = "Thành tiền",
                            ColumnPosition = 10,
                            IsSummnary = true,
                            AllowEdit = false,
                            ColumnType = UnboundColumnType.Decimal
                        },
                        new XtraColumn
                        {
                            ColumnName = "AmountExchange",
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnCaption = "Số tiền quy đổi",
                            ColumnPosition = 11,
                            IsSummnary = true,
                            AllowEdit = true,
                            ColumnType = UnboundColumnType.Decimal
                        },
                         new XtraColumn
                        {
                             ColumnName = "BudgetSourceId",
                             ColumnVisible = true,
                             RepositoryControl = _gridLookUpEditBudgetSource,
                            ColumnWith = 200,
                            ColumnCaption = "Nguồn",
                            ColumnPosition = 112,
                            AllowEdit = true,
                            Alignment = HorzAlignment.Default,
                         },
                          new XtraColumn
                        {
                            ColumnName = "CapitalPlanId",
                            ColumnVisible = true,
                            RepositoryControl = _gridLookUpEditCapitalPlan,
                            ColumnWith = 130,
                            ColumnCaption = "Kế hoạch vốn",
                            ColumnPosition = 113,
                            AllowEdit = true
                        },

                          new XtraColumn
                        {
                            ColumnName = "BudgetChapterCode",
                            ColumnVisible = true,
                            RepositoryControl = _gridLookUpEditBudgetChapter,
                            ColumnWith = 200,
                            ColumnCaption = "Chương",
                            ColumnPosition = 114,
                            AllowEdit = true,
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetSubKindItemCode",
                            ColumnVisible = true,
                            RepositoryControl = _gridLookUpEditBudgetSubKindItem,
                            ColumnWith = 200,
                            ColumnCaption = "Khoản",
                            ColumnPosition =115,
                            AllowEdit = true,
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetSubItemCode",
                            ColumnVisible = true,
                            RepositoryControl = _gridLookUpEditBudgetSubItem,
                            ColumnWith = 200,
                            ColumnCaption = "Tiểu mục",
                            ColumnPosition = 116,
                            AllowEdit = true,
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetItemCode",
                            ColumnVisible = true,
                            RepositoryControl = _gridLookUpEditBudgetItem,
                            ColumnWith = 200,
                            ColumnCaption = "Mục",
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
                            ColumnPosition = 118,
                            AllowEdit = true
                        },

                        new XtraColumn
                        {
                            ColumnName = "ProjectId",
                            ColumnVisible = true,
                             RepositoryControl = _gridLookUpEditProject,
                            ColumnWith = 200,
                            ColumnCaption = "Dự án",
                            ColumnPosition = 119,
                            AllowEdit = true,
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
                        new XtraColumn
                        {
                            ColumnName = "AccountingObjectId",
                            ColumnVisible = true,
                            RepositoryControl = _gridLookUpEditAccountingObject,
                            ColumnWith = 200,
                            ColumnCaption = "Đối tượng",
                            ColumnPosition = 121,
                            AllowEdit = true,
                        },
                        new XtraColumn
                        {
                            ColumnName = "CashWithDrawTypeId",
                            ColumnVisible = true,
                            RepositoryControl = _gridLookUpEditCashWithdrawType,
                            ColumnWith = 200,
                            ColumnCaption = "Nghiệp vụ",
                            ColumnPosition = 12,
                            AllowEdit = true,

                        },
                        new XtraColumn
                        {
                            ColumnName = "MethodDistributeId",
                            ColumnVisible = false,
                        },
                        new XtraColumn
                        {
                            ColumnName = "BankId",
                            ColumnVisible = true,
                            ColumnWith = 190,
                            ColumnCaption = "Tài khoản NH KB",
                            ColumnPosition = 123,
                            AllowEdit = true,
                            RepositoryControl = _gridLookUpEditBank
                        },
                         new XtraColumn
                        {
                            ColumnName = "ActivityId",
                            ColumnVisible = true,
                            RepositoryControl = _gridLookUpEditActivity,
                            ColumnWith = 200,
                            ColumnCaption = "Công việc",
                            ColumnPosition = 124,
                            AllowEdit = true,

                        },
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
                        //         new XtraColumn
                        //{
                        //    ColumnName = "InventoryItemId",
                        //    ColumnVisible = false
                        //},
                        new XtraColumn
                        {
                            ColumnName = "BudgetKindItemCode",
                            ColumnVisible = false
                        },
                        ////new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                        ////new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "TaxRate", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "TaxAmount", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "InwardAmount", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                        ////new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "ConfrontingRefId", ColumnVisible = false},

                        //new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},

                };
                }
                grdDetailByInventoryItemView.InitGridLayout(columnsCollection);
                grdDetailByInventoryItemView.SetNumericFormatControl(true);

                grdDetailByInventoryItemView.OptionsView.ShowFooter = true;
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
                #endregion

                #region colunm for grdAccountingView
                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},

                     new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        //RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 200,
                        ColumnCaption = "Mã VT,HH",
                        ColumnPosition = 1,
                        AllowEdit = true,
                         Alignment = HorzAlignment.Near,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 300,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                     new XtraColumn
                     {
                         ColumnName = "AccountingObjectId",
                         ColumnVisible = false
                     },
                      new XtraColumn
                     {
                         ColumnName = "CapitalPlanId",
                         ColumnVisible = false
                     },


                     new XtraColumn
                    {
                        ColumnName = "AutoBusinessId",
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
                        ColumnName = "CashWithDrawTypeId",
                        ColumnVisible = false
                    },
                        new XtraColumn
                    {
                        ColumnName = "ContractId",
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
                        ColumnName = "BankId",
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
                           new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = false
                    },
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

                    new XtraColumn {ColumnName = "StockId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                    new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxRate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InwardAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ConfrontingRefId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ConfrontingRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                       };
                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView);
                grdAccountingView.SetNumericFormatControl(true);
                grdAccountingView.OptionsView.ShowFooter = true;

                #endregion

                #region colunm for grdAccountingDetailView
                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},

                     new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 200,
                        ColumnCaption = "Mã VT,HH",
                        ColumnPosition = 1,
                        AllowEdit = true,
                         Alignment = HorzAlignment.Near,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 700,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },

                     new XtraColumn
                     {
                         ColumnName = "BudgetSourceID",
                         ColumnVisible = false
                     },
                      new XtraColumn
                      {
                          ColumnName = "DepartmentId",
                          ColumnVisible = true,
                         RepositoryControl = _gridLookUpEditDepartment,
                        ColumnWith = 200,
                        ColumnCaption = "Phòng ban",
                        ColumnPosition = 3,
                        AllowEdit = true,
                      },
                        new XtraColumn
                        {
                            ColumnName = "ActivityId",
                            ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditActivity,
                        ColumnWith = 200,
                        ColumnCaption = "Hoạt động SN",
                        ColumnPosition = 4,
                        AllowEdit = true,
                        },



                    new XtraColumn
                    {
                        ColumnName = "BudgetExpenseId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Phí lệ phí",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpBudgetExpense
                    },

                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = false,
                        RepositoryControl = _gridLookUpEditBudgetChapter,
                        ColumnWith = 200,
                        ColumnCaption = "Chương",
                        ColumnPosition = 6,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "ContractId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
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
                        ColumnName = "BankId",
                        ColumnVisible = false
                    },
                      new XtraColumn
                    {
                        ColumnName = "Unit",
                        ColumnVisible = false,
                        ColumnWith = 100,
                        ColumnCaption = "ĐVT",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },
                       new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = false,
                        ColumnWith = 100,
                        ColumnCaption = "Số lượng",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Integer
                    },
                           new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnVisible = false,
                        ColumnWith = 100,
                        ColumnCaption = "Đơn giá",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = false,
                        ColumnWith = 100,
                        ColumnCaption = "Thành tiền",
                        ColumnPosition = 10,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "OutwardPurpose",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "AutoBusinessId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "StockId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                    new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxRate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InwardAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ConfrontingRefId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ConfrontingRefNo", ColumnVisible = false,
                        ColumnWith = 150,
                        ColumnCaption = "Mục đích xuất",
                        ColumnPosition = 11,
                        AllowEdit = true},
                    new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                       };
                grdAccountingDetailView = InitGridLayout(columnsCollection, grdAccountingDetailView);
                grdAccountingDetailView.SetNumericFormatControl(true);
                grdAccountingDetailView.OptionsView.ShowFooter = true;
                bool visibale = (CurrencyCode != "VND");
                grdAccountingDetailView.Columns["AmountExchange"].Visible = visibale;
                #endregion

            }
        }
        ///<summary>
        ///Gets or sets the inward outward details parallel
        /// </summary>
        /// <value> The inward outward detail parallel</value>
        public IList<INInwardOutwardDetailParallelModel> INInwardOutwardDetailParallels
        {
            get
            {
                grdInInwardOurwardDetailParallel.RefreshDataSource();
                var paymentDetailParallels = new List<INInwardOutwardDetailParallelModel>();
                if (grdViewgrdInInwardOurwardDetailParallel.DataSource != null && grdViewgrdInInwardOurwardDetailParallel.DataRowCount > 0)
                {
                    for (var i = 0; i < grdViewgrdInInwardOurwardDetailParallel.DataRowCount; i++)
                    {
                        var rowVoucher = (INInwardOutwardDetailParallelModel)grdViewgrdInInwardOurwardDetailParallel.GetRow(i);

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
                            var item = new INInwardOutwardDetailParallelModel
                            {
                                AutoBusinessId = rowVoucher.AutoBusinessId,
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
                                SortOrder = i,
                                OrgRefNo = rowVoucher.OrgRefNo,
                                OrgRefDate = rowVoucher.OrgRefDate,
                                BudgetExpenseId = rowVoucher.BudgetExpenseId,
                                BudgetProvideCode = rowVoucher.BudgetProvideCode,
                                BankId = rowVoucher.BankId,
                                FundStructureId = rowVoucher.FundStructureId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                Quantity = rowVoucher.Quantity,
                                UnitPrice = rowVoucher.UnitPrice

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
                if (value == null)
                    bindingSourceDetailParallel.DataSource = new List<INInwardOutwardDetailParallelModel>();
                else
                    bindingSourceDetailParallel.DataSource = value.OrderBy(c => c.SortOrder).ToList();

                grdViewgrdInInwardOurwardDetailParallel.PopulateColumns(value);

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
                        ColumnVisible = false,
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
                        ColumnVisible = false,
                        //RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 150,
                        ColumnCaption = "Mã vật tư,CCDC",
                        ColumnPosition = 3,
                        AllowEdit = false},
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
                        RepositoryControl = _gridLookUpEditAccount,
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
                    new XtraColumn {ColumnName = "getSourceId",ColumnVisible = true,RepositoryControl = _gridLookUpEditBudgetSource,ColumnWith = 200,ColumnCaption = "Nguồn",ColumnPosition = 110,AllowEdit = true,Alignment = HorzAlignment.Default,},
                    new XtraColumn {ColumnName = "CapitalPlanId",ColumnVisible = true,RepositoryControl = _gridLookUpEditCapitalPlan,ColumnWith = 130,ColumnCaption = "Kế hoạch vốn",ColumnPosition = 111,AllowEdit = true},
                    new XtraColumn {ColumnName = "BudgetChapterCode",ColumnVisible = true,RepositoryControl = _gridLookUpEditBudgetChapter,ColumnWith = 200,ColumnCaption = "Chương",ColumnPosition = 112,AllowEdit = true,},
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
                                ColumnCaption = "Đối tượng",
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
                            new XtraColumn {
                                   ColumnName = "ActivityId",
                                   ColumnVisible = true,
                                   RepositoryControl = _gridLookUpEditActivity,
                                   ColumnWith = 200,
                                   ColumnCaption = "Công việc",
                                   ColumnPosition = 122,
                                   AllowEdit = true,
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
                        new XtraColumn {ColumnName = "InventoryItemId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ConfrontingRefId", ColumnVisible = false},

                        new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false}

                };

                XtraColumnCollectionHelper<INInwardOutwardDetailParallelModel>.ShowXtraColumnInGridView(columnsCollection, grdViewgrdInInwardOurwardDetailParallel);
                grdViewgrdInInwardOurwardDetailParallel.OptionsView.ShowFooter = false;
                bool visibale = (CurrencyCode != "VND");
                grdViewgrdInInwardOurwardDetailParallel.Columns["AmountOC"].Visible = visibale;
                #endregion
            }
        }

        #endregion

        #region IView

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

        #region IAccountsViewf

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
                    listAccounts = value.Where(x => x.DetailByInventoryItem == true).ToList();

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
                    _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(listAccounts, (int)BaseRefTypeId, RefTypes.ToList());
                    _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(listAccounts, (int)BaseRefTypeId, RefTypes.ToList());


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
                    //Filter cho gridview
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
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetSubItem.DisplayMember = "BudgetItemCode";
                    _gridLookUpEditBudgetSubItem.ValueMember = "BudgetItemCode";
                    //Filter cho gridview
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
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        #endregion

        #region AccountingObjects

        /// <summary>
        /// Sets the accounting objects.
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
                        ColumnCaption = "Mã Người nhận",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên Người nhận",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
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
                    new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false },
                    new XtraColumn { ColumnName = "AccountingObjectBanks", ColumnVisible = false },


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
                _gridLookUpEditAccountingObject.PopupFormSize = new Size(368, 150);

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
                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, accountingObjects, "AccountingObjectName", "AccountingObjectId", columnsCollection);
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

        #region Department
        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>The departments.</value>
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
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditDepartment.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDepartment.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDepartment.PopupFormSize = new Size(380, 150);

                    _gridLookUpEditDepartment.View.BestFitColumns();

                    _gridLookUpEditDepartment.DataSource = value;
                    _gridLookUpEditDepartmentView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DepartmentCode",
                        ColumnCaption = "Mã phòng ban",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 130
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DepartmentName",
                        ColumnCaption = "Tên phòng ban",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditDepartment.DisplayMember = "DepartmentName";
                    _gridLookUpEditDepartment.ValueMember = "DepartmentId";
                    //Filter cho gridview
                    _gridLookUpEditDepartmentView = XtraColumnCollectionHelper<DepartmentModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDepartment = XtraColumnCollectionHelper<DepartmentModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDepartmentView, value, "DepartmentName", "DepartmentId", gridColumnsCollection);
                    XtraColumnCollectionHelper<DepartmentModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDepartmentView);
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
                    _projectModel = value.ToList();
                    // Chỉ loại dự án là dự án
                    var data = value.Where(o => o.ObjectType == 2 && o.IsActive == true).ToList();
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

                    _gridLookUpEditProject.DataSource = data;
                    _gridLookUpEditProjectView.PopulateColumns(data);
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
                    XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
                    _gridLookUpEditProject.DisplayMember = "ProjectCode";
                    _gridLookUpEditProject.ValueMember = "ProjectId";
                    //Filter cho gridview
                    _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, data, "ProjectCode", "ProjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

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
        #region InventoryItem
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
                    _InventoryItems = value.ToList();
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
                    OldInventoryItems = value.ToList();
                    _gridLookUpEditInventoryItem.View.BestFitColumns();

                    _gridLookUpEditInventoryItem.DataSource = value;
                    _gridLookUpEditInventoryItemView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
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
                        ColumnCaption = "Tên vật tư",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "UnitsInStock", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
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
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Stock
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultAccountNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
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
                    _gridLookUpEditStock = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditStockView, value, "StockName", "StockId", gridColumnsCollection);
                    XtraColumnCollectionHelper<StockModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditStockView);
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

        #region FundStructures

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
                    var data = value.Where(o => o.RefTypeId == (int)BuCA.Enum.RefType.INOutward).ToList();

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

        #region Event control

        protected override void LkAccountingObjectCategory_EditValueChanged(object sender, EventArgs e)
        {
            _accountingObjectsPresenter.DisplayActive(true);
            //InwardOutwardDetails = InwardOutwardDetails;
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
                                grdViewgrdInInwardOurwardDetailParallel.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
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
                                grdViewgrdInInwardOurwardDetailParallel.Columns["AccountingObjectId"].ColumnEdit = _gridLookUpEditAccountingObject;
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

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        protected override void HiddenParallelAndOpenByCurrencyCode(object sender, CellValueChangedEventArgs e)
        {
            bool visibale = !e.Value.ToString().Equals("VND");
            ShowAmountByCurrencyCode(grdViewgrdInInwardOurwardDetailParallel, "AmountOC", visibale);
            if (grdDetailByInventoryItemView.Columns["Amount"] != null)
            {
                grdDetailByInventoryItemView.Columns["Amount"].Visible = true;
            }
            //ShowAmountByCurrencyCode(grdDetailByInventoryItemView, "AmountExchange", visibale);
            if (grdDetailByInventoryItemView.Columns["AmountExchange"] != null)
            {
                grdDetailByInventoryItemView.Columns["AmountExchange"].Visible = visibale;
            }
            //grdDetailByInventoryItemView.Columns.ColumnByFieldName("AmountExchange").Visible = false;


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
        #region grdViewgrdInInwardOurwardDetailParallel

        /// <summary>
        /// Handles the InitNewRow event of the grdViewgrdInInwardOurwardDetailParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        private void grdViewgrdInInwardOurwardDetailParallel_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;

                grdViewgrdInInwardOurwardDetailParallel.SetRowCellValue(e.RowHandle, nameof(INInwardOutwardDetailParallelModel.BudgetSourceId), GlobalVariable.DefaultBudgetSourceID);
                grdViewgrdInInwardOurwardDetailParallel.SetRowCellValue(e.RowHandle, nameof(INInwardOutwardDetailParallelModel.BudgetChapterCode), GlobalVariable.DefaultBudgetChapterCode);
                grdViewgrdInInwardOurwardDetailParallel.SetRowCellValue(e.RowHandle, nameof(INInwardOutwardDetailParallelModel.BudgetKindItemCode), GlobalVariable.DefaultBudgetKindItemCode);
                grdViewgrdInInwardOurwardDetailParallel.SetRowCellValue(e.RowHandle, nameof(INInwardOutwardDetailParallelModel.BudgetSubKindItemCode), GlobalVariable.DefaultBudgetSubKindItemCode);
                grdViewgrdInInwardOurwardDetailParallel.SetRowCellValue(e.RowHandle, nameof(INInwardOutwardDetailParallelModel.CashWithdrawTypeId), GlobalVariable.DefaultCashWithDrawTypeID);
                grdViewgrdInInwardOurwardDetailParallel.SetRowCellValue(e.RowHandle, nameof(INInwardOutwardDetailParallelModel.MethodDistributeId), GlobalVariable.DefaultMethodDistributeID);


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the CellValueChanged event of the grdViewgrdInInwardOurwardDetailParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void grdViewgrdInInwardOurwardDetailParallel_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (DesignMode)
                return;

            if (e.Column.FieldName == "Amount")
            {

                var amountOC = grdViewgrdInInwardOurwardDetailParallel.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 : (decimal)grdViewgrdInInwardOurwardDetailParallel.GetRowCellValue(e.RowHandle, "Amount");
                var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null ? 1 : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                exchangeRate = exchangeRate == 0 ? 1 : exchangeRate;
                grdViewgrdInInwardOurwardDetailParallel.SetRowCellValue(e.RowHandle, "AmountOC", amountOC * exchangeRate);
            }
            if (e.Column.FieldName == "BudgetSubItemCode" && e.Value != null)
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    return;
                var parentId = _budgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                var budgetItemCode = _budgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                grdViewgrdInInwardOurwardDetailParallel.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode);
            }
        }
        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the grdViewgrdInInwardOurwardDetailParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        private void grdViewgrdInInwardOurwardDetailParallel_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo)grdAccountingView.GetViewInfo();
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
        #endregion
        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            grdViewgrdInInwardOurwardDetailParallel.OptionsBehavior.Editable = isEnable;
            grdViewgrdInInwardOurwardDetailParallel.OptionsBehavior.ReadOnly = !isEnable;
            grdViewgrdInInwardOurwardDetailParallel.FocusRectStyle = DrawFocusRectStyle.None;
            grdViewgrdInInwardOurwardDetailParallel.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdViewgrdInInwardOurwardDetailParallel.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
            cboObjectCode.Enabled = isEnable;
        }

        private void grdViewgrdInInwardOurwardDetailParallel_ShownEditor(object sender, EventArgs e)
        {
            try
            {

                GridView view = sender as GridView;
                INInwardOutwardDetailParallelModel data = view.GetFocusedRow() as INInwardOutwardDetailParallelModel;
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
            catch
            {


            }
        }

    }
}