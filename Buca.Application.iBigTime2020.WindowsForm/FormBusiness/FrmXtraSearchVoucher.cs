/***********************************************************************
 * <copyright file="FrmXtraSearchVoucher.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    tuanhm@buca.vn, ThangNK 16/08/2014
 * Website:
 * Create Date: Saturday, June 1, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Search;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Enum;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.DataHelpers;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using DevExpress.XtraGrid.Views.Base;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAReceipt;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAPayment;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.FixedAsset;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BADeposit;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BAWithDraw;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.IncrementDecrement;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.PUInvoice;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General;
using System.IO;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.OpeningAccount;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.FixedAsset;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness
{
    /// <summary>
    /// Class FrmXtraSearchVoucher.
    /// </summary>
    /// <seealso cref="DevExpress.XtraEditors.XtraForm" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.ICashWithdrawTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IRefTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IActivitysView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFixedAssetsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IDepartmentsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    public partial class FrmXtraSearchVoucher : XtraForm, IAccountsView, ICashWithdrawTypesView, IRefTypesView, IBudgetSourcesView, IBanksView,
        IAccountingObjectsView, IActivitysView, IFixedAssetsView, IDepartmentsView, IBudgetItemsView, IBudgetKindItemsView, IBudgetExpensesView, IFundStructuresView, IContractsView, IProjectsView
    {
        #region Declaration

        /// <summary>
        /// The currency accounting
        /// </summary>
        protected string CurrencyAccounting;
        /// <summary>
        /// The currency local
        /// </summary>
        protected string CurrencyLocal;
        /// <summary>
        /// The where clause
        /// </summary>
        protected string WhereClause = " ";
        /// <summary>
        /// The currency code
        /// </summary>
        protected string CurrencyCode = "";
        /// <summary>
        /// From date
        /// </summary>
        protected string FromDate = "";
        /// <summary>
        /// To date
        /// </summary>
        protected string ToDate = "";
        /// <summary>
        /// The fixed asset code
        /// </summary>
        protected string FixedAssetCode = "";
        /// <summary>
        /// The budget group code
        /// </summary>
        protected string BudgetGroupCode = "";
        /// <summary>
        /// The refno
        /// </summary>
        protected string Refno = "";
        /// <summary>
        /// The department code
        /// </summary>
        protected string DepartmentCode = "";
        /// <summary>
        /// The creditaccount
        /// </summary>
        protected string creditaccount;
        /// <summary>
        /// The debitaccount
        /// </summary>
        protected string debitaccount;
        /// <summary>
        /// The amount oc from
        /// </summary>
        protected string amountOCFrom = ""; //số tiền
        /// <summary>
        /// The amount oc to
        /// </summary>
        protected string amountOCTo = ""; //số tiền
        /// <summary>
        /// The budget sourcecode
        /// </summary>
        protected string budgetSourcecode = "";// Nguồn vốn
        /// <summary>
        /// The budgechaptercode
        /// </summary>
        protected string budgechaptercode = ""; //Chương
        /// <summary>
        /// The budget item code
        /// </summary>
        protected string budgetItemCode = "";//Mục/Tiểu mục
        /// <summary>
        /// The inventoryitemid
        /// </summary>
        protected string inventoryitemid = ""; //"Vật tư

        /// <summary>
        /// The reftypeid
        /// </summary>
        protected string reftypeid = ""; //"Loại chứng từ
        /// <summary>
        /// The currencycode
        /// </summary>
        protected string currencycode = ""; //"Loại tiền
        /// <summary>
        /// The amount exchange
        /// </summary>
        protected string amountExchange = ""; //Quy đổi
        /// <summary>
        /// The cash with draw type identifier
        /// </summary>
        protected string cashWithDrawTypeID = ""; //"Nghiệp vụ
        /// <summary>
        /// The method distribute identifier
        /// </summary>
        protected string methodDistributeID = ""; //"Cấp phát
        /// <summary>
        /// The budget sub kind item code
        /// </summary>
        protected string budgetSubKindItemCode = ""; //Loại khoản
        /// <summary>
        /// The inventory item identifier
        /// </summary>
        protected string inventoryItemID = ""; //"Công cụ dụng cụ
        /// <summary>
        /// The accounting object identifier
        /// </summary>
        protected string accountingObjectID = ""; //"Đối tượng
        /// <summary>
        /// The accounting object code
        /// </summary>
        protected string accountingObjectCode = ""; //"Cán bộ
        /// <summary>
        /// The fixed asset code
        /// </summary>
        protected string fixedAssetCode = ""; //"Tài sản
        /// <summary>
        /// The activity identifier
        /// </summary>
        protected string activityID = ""; //"Hoạt động SN
        /// <summary>
        /// The bank identifier
        /// </summary>
        protected string bankID = ""; //"Tài khoản ngân hàng
        /// <summary>
        /// The project identifier
        /// </summary>
        protected string projectid = ""; //""Dự án
        protected string projectID = ""; //""CTMT
        protected string contractID = ""; // Hợp đồng


        private IList<AccountModel> _accounts;
        private IList<BudgetItemModel> _budgetItems;
        private IList<BudgetKindItemModel> _budgetKindItems;
        private RepositoryItemGridLookUpEdit _rpsExpressionSearch;
        private GridView _rpsExpressionSearchView;
        private readonly BanksPresenter _banksPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly ActivitysPresenter _activitysPresenter;
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        private readonly ContractsPresenter _contractsPresenter;

        private readonly RefTypesPresenter _refTypesPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;
        private GridView _gridLookUpEditCashWithdrawTypeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        protected RepositoryItemGridLookUpEdit _gridLookUpEditRefType;
        protected GridView _gridLookUpEditRefTypeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        private GridView _gridLookUpEditAccountingObjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;
        private GridView _gridLookUpEditFixedAssetView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        private GridView _gridLookUpEditDepartmentView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private GridView _gridLookUpEditBudgetItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        private GridView _gridLookUpEditBudgetSubItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        private GridView _gridLookUpEditContractView;



        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        protected static IModel Model { get; private set; }
        #endregion

        #region Form Event
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraSearchVoucher"/> class.
        /// </summary>
        public FrmXtraSearchVoucher()
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            Model = new Model.Model();
            _banksPresenter = new BanksPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _contractsPresenter = new ContractsPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraSearchVoucher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraSearchVoucher_Load(object sender, EventArgs e)
        {
            InitGridMain();
            _cashWithdrawTypesPresenter.DisplayList();
            _budgetSourcesPresenter.Display();
            InitRepositoryControlData();
            _banksPresenter.DisplayActive(true);
            _accountingObjectsPresenter.DisplayActive(true);
            _activitysPresenter.DisplayActive(true);
            _fixedAssetsPresenter.DisplayByActive(true);
            _departmentsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetExpensesPresenter.DisplayActive();
            _fundStructuresPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _contractsPresenter.DisplayActive();

            _refTypesPresenter.Display();
            _rpsExpressionSearch = new RepositoryItemGridLookUpEdit { NullText = "" };
            _rpsExpressionSearchView = new GridView();
            _rpsExpressionSearch.View = _rpsExpressionSearchView;
            _rpsExpressionSearch.TextEditStyle = TextEditStyles.Standard;
            _rpsExpressionSearch.ShowFooter = false;
            // gán data to 
            _rpsExpressionSearch.DataSource = new List<GridLookUpItem> { new GridLookUpItem("AND", "Và"), new GridLookUpItem("OR", "Hoặc") };
            _rpsExpressionSearch.PopulateViewColumns();
            _rpsExpressionSearch.View.OptionsView.ShowIndicator = false;
            _rpsExpressionSearch.View.OptionsView.ShowColumnHeaders = false;
            _rpsExpressionSearch.PopupFormWidth = 200;
            _rpsExpressionSearch.DisplayMember = "DataMember";
            _rpsExpressionSearch.ValueMember = "DataValue";
            grdlookUpExpressionSearch.DataSource = _dataForSearch;
            grdlookUpExpressionSearchView.Columns["ExpressionLogic"].ColumnEdit = _rpsExpressionSearch;
            grdlookUpExpressionSearchView.Columns["ExpressionLogic"].OptionsColumn.AllowEdit = true;
            txtRefNo.Visible = true;
            lblRefNo.Visible = true;
            txtRefNo.Location = new Point(250, 24);
            lblRefNo.Location = new Point(185, 26);
            grdObjectValue.Visible = false;
            lblValue.Visible = false;
            dtFromDate.Visible = false;
            dtToDate.Visible = false;
            lblFromDate.Visible = false;
            lblTodate.Visible = false;
            lblgreater.Visible = false;
            lbllesser.Visible = false;
            txtgreater.Visible = false;
            txtlesser.Visible = false;
            txtlesser.Properties.Mask.UseMaskAsDisplayFormat = true;
            FormatGridExpression();
            // grdList.DataSource = new List<OriginalGeneralLedgerEntity>(); // Khởi tạo trên header trên grid
            grdList.DataSource = new List<SearchModel>(); // Khởi tạo trên header trên grid
            if (grdList.DataSource != null)
            {
                FormatGrdList();
            }
        }
        #endregion

        #region Search Voucher
        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            WhereClause = "";
            FromDate = "";
            ToDate = "";
            if (grdlookUpExpressionSearch.DataSource != null && grdlookUpExpressionSearchView.RowCount > 0)
            {
                try
                {
                    bool hasRefDate = false;
                    string expressionLogic = "AND";
                    for (var i = 0; i < grdlookUpExpressionSearchView.RowCount; i++)
                    {
                        var rowVoucherDetailData = (ObjectExpressionSearch)grdlookUpExpressionSearchView.GetRow(i);

                        #region Get WhereClause
                        switch (rowVoucherDetailData.ObjectFieldSearchId)
                        {
                            case "FromDate": // Ngày chứng từ
                                string yyyy = dtFromDate.EditValue.AsString("yyyy/MM/dd").Replace("/", "").Substring(4, 4);
                                string MM = dtFromDate.EditValue.AsString("yyyy/MM/dd").Replace("/", "").Substring(2, 2);
                                string dd = dtFromDate.EditValue.AsString("yyyy/MM/dd").Replace("/", "").Substring(0, 2);
                                FromDate = yyyy + "-" + MM + "-" + dd;

                                string yyyy2 = dtToDate.EditValue.AsString("yyyy/MM/dd").Replace("/", "").Substring(4, 4);
                                string MM2 = dtToDate.EditValue.AsString("yyyy/MM/dd").Replace("/", "").Substring(2, 2);
                                string dd2 = dtToDate.EditValue.AsString("yyyy/MM/dd").Replace("/", "").Substring(0, 2);
                                ToDate = yyyy2 + "-" + MM2 + "-" + dd2;

                                hasRefDate = true;
                                expressionLogic = rowVoucherDetailData.ExpressionLogic;
                                break;
                            case "DepartmentCode": // Phòng ban
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " DepartmentID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " DepartmentID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                            case "DebitAccount": // TK nợ
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " DebitAccount LIKE N'" + rowVoucherDetailData.ObjectSearchValueId + "%'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " DebitAccount LIKE N'" + rowVoucherDetailData.ObjectSearchValueId + "%'";
                                break;
                            case "CreditAccount": // TK có
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " CreditAccount LIKE N'" + rowVoucherDetailData.ObjectSearchValueId + "%'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " CreditAccount LIKE N'" + rowVoucherDetailData.ObjectSearchValueId + "%'";
                                break;
                            case "RefNo": //Tìm theo gần đúng số chứng từ
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " RefNo LIKE N'%" + rowVoucherDetailData.ObjectSearchValueId + "%'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " RefNo LIKE N'%" + rowVoucherDetailData.ObjectSearchValueId + "%'";
                                break;
                            case "AmountOC": //số tiền
                                amountOCFrom = (txtgreater.EditValue).ToString();
                                amountOCTo = (txtlesser.EditValue).ToString();

                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " AmountOC >= " + amountOCFrom;
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " AmountOC <= " + amountOCTo;
                                break;
                            case "AmountExchange": //số tiền
                                amountOCFrom = (txtgreater.EditValue).ToString();
                                amountOCTo = (txtlesser.EditValue).ToString();
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " Amount >= " + amountOCFrom;
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " Amount <= " + amountOCTo;
                                break;
                            case "BudgetChapterCode": //chương
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " BudgetChapterCode = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " BudgetChapterCode = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                            case "BudgetSourceCode": // Nguồn vốn
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " BudgetSourceID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " BudgetSourceID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                            case "BudgetItemCode"://Mục/Tiểu mục
                                budgetItemCode = rowVoucherDetailData.ObjectSearchValueId;
                                var budgetItem = _budgetItems.FirstOrDefault(c => c.BudgetItemCode == budgetItemCode);
                                int budgetItemType = budgetItem.BudgetItemType;
                                if (budgetItemType == 2)
                                {
                                    if (string.IsNullOrEmpty(WhereClause))
                                        WhereClause = " BudgetItemCode = '" + rowVoucherDetailData.ObjectSearchValueId +
                                                      "'";
                                    else
                                        WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic +
                                                      " BudgetItemCode = '" + rowVoucherDetailData.ObjectSearchValueId +
                                                      "'";
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(WhereClause))
                                        WhereClause = " BudgetSubItemCode = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                    else
                                        WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " BudgetSubItemCode = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                }

                                break;
                            case "InventoryItemID": //"Vật tư
                            case "InventoryItemID_CCDC": //"CCDC
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " InventoryItemID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " InventoryItemID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                            case "RefTypeID": //"Loại chứng từ
                                var objectSearchValueId = rowVoucherDetailData.ObjectSearchValueId;
                                if (rowVoucherDetailData.ObjectSearchValueName == "Ghi tăng")
                                {
                                    objectSearchValueId = "(58,108,159,251,252)";
                                    WhereClause = " Reftype IN " + objectSearchValueId;
                                }

                                else
                                {
                                    if (string.IsNullOrEmpty(WhereClause))
                                        WhereClause = " Reftype = " + objectSearchValueId;
                                    else
                                    {
                                        //if (rowVoucherDetailData.ObjectSearchValueName == "Ghi tăng")
                                        //    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " Reftype IN " + objectSearchValueId;
                                        //else
                                            WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " Reftype = " + objectSearchValueId;
                                    }
                                }


                                break;
                            case "CurrencyCode": //"Loại tiền
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " CurrencyCode = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " CurrencyCode = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                            case "CashWithDrawTypeID": //"Nghiệp vụ
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " CashWithDrawTypeID = " + rowVoucherDetailData.ObjectSearchValueId;
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " CashWithDrawTypeID = " + rowVoucherDetailData.ObjectSearchValueId;
                                break;
                            case "MethodDistributeID": //"Cấp phát
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " MethodDistributeID = " + rowVoucherDetailData.ObjectSearchValueId;
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " MethodDistributeID = " + rowVoucherDetailData.ObjectSearchValueId;
                                break;
                            case "BudgetSubKindItemCode": //"Loại khoản
                                var budgetKindItemCode = rowVoucherDetailData.ObjectSearchValueId;
                                var budgetKindItem = _budgetKindItems.FirstOrDefault(c => c.BudgetKindItemCode == budgetKindItemCode);
                                string parentId = budgetKindItem.ParentId;
                                if (parentId != null)
                                {
                                    if (string.IsNullOrEmpty(WhereClause))
                                        WhereClause = " BudgetSubKindItemCode = '" +
                                                      rowVoucherDetailData.ObjectSearchValueId + "'";
                                    else
                                        WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic +
                                                      " BudgetSubKindItemCode = '" +
                                                      rowVoucherDetailData.ObjectSearchValueId + "'";
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(WhereClause))
                                        WhereClause = " BudgetKindItemCode = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                    else
                                        WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " BudgetKindItemCode = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                }

                                break;
                            case "AccountingObjectID": //""Đối tượng
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " AccountingObjectID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " AccountingObjectID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                            case "AccountingObjectCode": //""Cán bộ
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " AccountingObjectID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " AccountingObjectID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                            case "FixedAssetCode": //"TSCĐ
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " FixedAssetID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " FixedAssetID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                            case "BankID": //"Tài khoản ngân hàng
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " BankID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " BankID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;


                            case "ProjectID": //"Dự án
                            case "ProjectID_CTMT": //"CCDC
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " ProjectID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " ProjectID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;


                            case "ActivityID": //"Hoạt động SN
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " ActivityID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " ActivityID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                            case "BudgetExpenseID": // Phí, lệ phí
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " BudgetExpenseID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " BudgetExpenseID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                            case "FundStructureID": //khoản chi
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " FundStructureID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " FundStructureID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                            case "ContractID": //Hợp đồng
                                if (string.IsNullOrEmpty(WhereClause))
                                    WhereClause = " ContractID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                else
                                    WhereClause = WhereClause + " " + rowVoucherDetailData.ExpressionLogic + " ContractID = '" + rowVoucherDetailData.ObjectSearchValueId + "'";
                                break;
                        }
                    }
                    if (hasRefDate)
                    {
                        if (string.IsNullOrEmpty(WhereClause))
                            WhereClause = " RefDate >= CONVERT(DATE,'" + FromDate + "') AND RefDate <= CONVERT(DATE,'" + ToDate + "')";
                        else
                            WhereClause = WhereClause + " " + expressionLogic + " RefDate >= CONVERT(DATE,'" + FromDate + "') AND RefDate <= CONVERT(DATE,'" + ToDate + "')";
                    }

                    #endregion
                }
                catch { }
            }
            if (grdlookUpExpressionSearchView.RowCount > 0)
            {
                SetDataForResult(WhereClause);
                InitRepositoryControlData();
            }
            else
            {
                SetDataForResult(WhereClause);
                InitRepositoryControlData();
            }
        }

        /// <summary>
        /// Sets the data for result.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        private void SetDataForResult(string whereClause)
        {
            try
            {
                var generalLedgerdata = Model.GetSearchVoucher(whereClause).ToList();
                List<OriginalGeneralLedgerModel> listData = new List<OriginalGeneralLedgerModel>();
                foreach (var item in generalLedgerdata)
                {
                    // chuyển reftype của ghi tăng về chung là tiền gửi để hiển thị được loại chứng từ
                    if (item.RefType == (int)BuCA.Enum.RefType.BUTransferFixedAsset
                    || item.RefType == (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset
                    || item.RefType == (int)BuCA.Enum.RefType.BAWithDrawFixedAsset
                    || item.RefType == (int)BuCA.Enum.RefType.PUInvoiceFixedAsset
                    || item.RefType == (int)BuCA.Enum.RefType.FAIncrementDecrement)
                    {
                        item.RefType = (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset;
                    }
                    if (item.RefType != null && item.RefType != 0)
                        listData.Add(item);
                }
                grdList.DataSource = listData;
                gridView.PopulateColumns(generalLedgerdata);
                if (generalLedgerdata.Count == 0)
                { FormatGrdList(); XtraMessageBox.Show("Không tìm thấy bản ghi nào! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                if (grdList.DataSource != null)
                {
                    FormatGrdList();
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                XtraMessageBox.Show("Không tìm thấy bản ghi nào! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            WhereClause = "";
            CurrencyCode = "";
            FromDate = "";
            ToDate = "";
            DepartmentCode = "";
            debitaccount = "";
            creditaccount = "";
            Refno = "";
            amountOCFrom = "";
            amountOCTo = "";
            budgechaptercode = "";
            budgetSourcecode = "";
            budgetItemCode = "";
            inventoryitemid = "";
            ToDate = "";
            reftypeid = "";
            currencycode = "";
            amountExchange = "";
            cashWithDrawTypeID = "";
            methodDistributeID = "";
            budgetSubKindItemCode = "";
            inventoryItemID = "";
            accountingObjectID = "";
            accountingObjectCode = "";
            fixedAssetCode = "";
            activityID = "";
            bankID = "";
            projectID = "";
            projectID = "";
            contractID = "";
        }
        #endregion

        #region IView Extend
        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public IList<AccountModel> Accounts
        {
            set { _accounts = value; }
        }

        /// <summary>
        /// Sets the activitys.
        /// </summary>
        /// <value>
        /// The activitys.
        /// </value>
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
                    };
                    _gridLookUpEditActivity.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditActivity.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditActivity.PopupFormSize = new Size(380, 150);

                    _gridLookUpEditActivity.View.BestFitColumns();
                    _gridLookUpEditActivity.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditActivity.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditActivity.NullText = "";
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
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                try
                {
                    _gridLookUpEditFixedAssetView = new GridView();
                    _gridLookUpEditFixedAssetView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFixedAsset = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFixedAssetView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFixedAsset.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFixedAsset.View.BestFitColumns();

                    _gridLookUpEditFixedAsset.DataSource = value;
                    _gridLookUpEditFixedAssetView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FixedAssetCode",
                        ColumnCaption = "Mã tài sản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FixedAssetName",
                        ColumnCaption = "Tên tài sản",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
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
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Visible = false;
                    }
                    //XtraColumnCollectionHelper<FixedAssetModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFixedAssetView);
                    _gridLookUpEditFixedAsset.DisplayMember = "FixedAssetCode";
                    _gridLookUpEditFixedAsset.ValueMember = "FixedAssetId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _gridLookUpEditAccountingObjectView = new GridView();
                _gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditAccountingObjectView,
                    TextEditStyle = TextEditStyles.Standard,
                    AllowNullInput = DefaultBoolean.True
                };
                _gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditAccountingObject.PopupFormSize = new Size(268, 150);
                _gridLookUpEditAccountingObject.View.BestFitColumns();
                _gridLookUpEditAccountingObject.DataSource = value;
                _gridLookUpEditAccountingObjectView.PopulateColumns(value);

                var columnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                            {
                                ColumnName = "AccountingObjectCode",
                                ColumnCaption = "Mã đối tượng",
                                ColumnVisible = true,
                                ColumnWith = 120,
                                Alignment = HorzAlignment.Center
                            },
                        new XtraColumn
                            {
                                ColumnName = "AccountingObjectName",
                                ColumnCaption = "Tên đối tượng",
                                ColumnPosition = 1,
                                ColumnVisible = true,
                                ColumnWith = 250
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
                        new XtraColumn {ColumnName = "BudgetChapterId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrganizationFeeCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrganizationManageFee", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TreasuryManageFee", ColumnVisible = false}
                    };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex =
                            column.ColumnPosition;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                    }
                }
                _gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectName";
                _gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";
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
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        #region CashWithdrawTypeModels
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
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region BudgetSources

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
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<ContractModel> Contracts
        {
            set
            {
                try
                {
                    _gridLookUpEditContractView = new GridView();
                    _gridLookUpEditContractView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditContract = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditContractView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditContract.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditContract.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditContract.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditContract.View.BestFitColumns();

                    _gridLookUpEditContract.DataSource = value;
                    _gridLookUpEditContractView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ContractNo",
                        ColumnCaption = "Hợp đồng số",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ContractName",
                        ColumnCaption = "Tên Hợp đồng",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    XtraColumnCollectionHelper<ContractModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditContractView);
                    _gridLookUpEditContract.DisplayMember = "ContractNo";
                    _gridLookUpEditContract.ValueMember = "ContractId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        /// <summary>
        /// Sets the reference types.
        /// </summary>
        /// <value>
        /// The reference types.
        /// </value>
        public IList<RefTypeModel> RefTypes
        {
            set
            {
                try
                {
                    _gridLookUpEditRefTypeView = new GridView();
                    _gridLookUpEditRefTypeView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditRefType = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditRefTypeView,
                        TextEditStyle = TextEditStyles.Standard,
                        AllowNullInput = DefaultBoolean.True,
                        NullValuePrompt = null,
                        DisplayMember = "RefTypeName",
                        ValueMember = "RefTypeId"
                    };
                    _gridLookUpEditRefTypeView.PopulateColumns();

                    _gridLookUpEditRefType.DataSource = value;
                    _gridLookUpEditRefTypeView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "RefTypeName",
                        ColumnCaption = "Tên loại CT",
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FunctionId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MasterTableName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailTableName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LayoutMaster", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LayoutDetail", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultDebitAccountCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultDebitAccountId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultCreditAccountCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultCreditAccountId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultTaxAccountCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "DefaultTaxAccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "AllowDefaultSetting", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Postable", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Searchable", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SubSystem", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditRefTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditRefTypeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditRefTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditRefTypeView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditRefType.DisplayMember = "RefTypeName";
                    _gridLookUpEditRefType.ValueMember = "RefTypeId";
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
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditDepartment.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDepartment.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDepartment.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditDepartment.View.BestFitColumns();

                    _gridLookUpEditDepartment.DataSource = value;
                    _gridLookUpEditDepartmentView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DepartmentCode",
                        ColumnCaption = "Mã phòng/ban",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DepartmentName",
                        ColumnCaption = "Tên phòng/ban",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
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
                    _gridLookUpEditDepartment.DisplayMember = "DepartmentCode";
                    _gridLookUpEditDepartment.ValueMember = "DepartmentId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region BudgetItems

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
                    _budgetItems = value.ToList();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

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
                    _budgetKindItems = value.ToList();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region BudgetExpenses
        public IList<BudgetExpenseModel> BudgetExpenses
        {
            set
            {
                try
                {
                    _gridLookUpEditBudgetExpenseView = new GridView();
                    _gridLookUpEditBudgetExpenseView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetExpense = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetExpenseView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetExpense.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetExpense.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetExpense.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetExpense.View.BestFitColumns();

                    _gridLookUpEditBudgetExpense.DataSource = value;
                    _gridLookUpEditBudgetExpenseView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                        {
                            ColumnName = "BudgetExpenseCode",
                            ColumnCaption = "Mã",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetExpenseName",
                            ColumnCaption = "Phí lệ phí",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetExpenseType", ColumnVisible = false}
                    };

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditBudgetExpense.DisplayMember = "BudgetExpenseName";
                    _gridLookUpEditBudgetExpense.ValueMember = "BudgetExpenseId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _gridLookUpEditFundStructureView = new GridView();
                    _gridLookUpEditFundStructureView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFundStructure = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFundStructureView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditFundStructure.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFundStructure.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFundStructure.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFundStructure.View.BestFitColumns();

                    _gridLookUpEditFundStructure.DataSource = value;
                    _gridLookUpEditFundStructureView.PopulateColumns(value);
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

                    _gridLookUpEditProject.DataSource = value;
                    _gridLookUpEditProjectView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectCode",
                        ColumnCaption = "Mã CTMT, dự án",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectName",
                        ColumnCaption = "Tên CTMT, dự án",
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
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        #endregion
        #endregion

        #region Control Event

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
        /// Initializes the grid main.
        /// </summary>
        protected void InitGridMain()
        {
            grdlookUpFieldSearch.DataSource = ObjectFieldSearchs();
            gridViewFieldSearch.PopulateColumns();
            var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "ObjectFieldSearchId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ObjectFieldSearchName", ColumnCaption = "Trường", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 120},
                    };

            foreach (var column in gridColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    gridViewFieldSearch.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    gridViewFieldSearch.Columns[column.ColumnName].Width = column.ColumnWith;
                }
                else { gridViewFieldSearch.Columns[column.ColumnName].Visible = false; }
            }

        }

        /// <summary>
        /// The data for search
        /// </summary>
        List<ObjectExpressionSearch> _dataForSearch = new List<ObjectExpressionSearch>();

        /// <summary>
        /// Handles the Click event of the grdlookUpFieldSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void grdlookUpFieldSearch_Click(object sender, EventArgs e)
        {
            if (gridViewFieldSearch.FocusedRowHandle > -1)
            {
                var objectFieldSearchIdCol = gridViewFieldSearch.Columns["ObjectFieldSearchId"];
                string objectFieldSearchId = gridViewFieldSearch.GetRowCellValue(gridViewFieldSearch.FocusedRowHandle, objectFieldSearchIdCol).ToString();

                switch (objectFieldSearchId)
                {
                    case "RefNo":

                        grdObjectValue.Visible = false;
                        dtFromDate.Visible = false;
                        dtToDate.Visible = false;
                        lblFromDate.Visible = false;
                        lblTodate.Visible = false;
                        lblValue.Visible = false;
                        lblRefNo.Visible = true;
                        txtRefNo.Visible = true;
                        lblgreater.Visible = false;
                        lbllesser.Visible = false;
                        txtgreater.Visible = false;
                        txtlesser.Visible = false;
                        lblTodate.Visible = false;
                        break;
                    case "FromDate":
                        grdObjectValue.Visible = false;
                        dtFromDate.Visible = true;
                        dtToDate.Visible = true;
                        lblFromDate.Visible = true;
                        lblTodate.Visible = true;
                        lblValue.Visible = false;

                        lblRefNo.Visible = false;
                        txtRefNo.Visible = false;

                        lblgreater.Visible = false;
                        lbllesser.Visible = false;
                        txtgreater.Visible = false;
                        txtlesser.Visible = false;
                        lblTodate.Visible = true;
                        //var baseFromDate = new DateTime(Convert.ToDateTime(GlobalVariable.PostedDate).Year, 1, 1);
                        //var baseToDate = new DateTime(Convert.ToDateTime(GlobalVariable.PostedDate).Year, 12, 31);
                        dtFromDate.EditValue = new DateTime(Convert.ToDateTime(GlobalVariable.PostedDate).Year, 1, 1);
                        dtToDate.EditValue = new DateTime(Convert.ToDateTime(GlobalVariable.PostedDate).Year, 12, 31);
                        break;
                    case "AmountOC":
                        grdObjectValue.Visible = false;
                        dtFromDate.Visible = false;
                        dtToDate.Visible = false;
                        lblFromDate.Visible = false;
                        lblTodate.Visible = true;
                        lblValue.Visible = false;
                        lblRefNo.Visible = false;
                        txtRefNo.Visible = false;
                        lblTodate.Visible = false;
                        lblgreater.Visible = true;
                        txtgreater.Visible = true;
                        lbllesser.Visible = true;
                        txtlesser.Visible = true;
                        txtgreater.EditValue = null;
                        txtlesser.EditValue = null;
                        lblgreater.Location = new Point(192, 28);
                        txtgreater.Location = new Point(224, 24);
                        lbllesser.Location = new Point(192, 60);
                        txtlesser.Location = new Point(224, 56);

                        txtgreater.Properties.Mask.MaskType = MaskType.Numeric;
                        txtgreater.Properties.Mask.EditMask = @"c" + Convert.ToString(GlobalVariable.CurrencyDecimalDigits);
                        txtgreater.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        txtgreater.Properties.Mask.UseMaskAsDisplayFormat = true;

                        txtlesser.Properties.Mask.MaskType = MaskType.Numeric;
                        txtlesser.Properties.Mask.EditMask = @"c" + Convert.ToString(GlobalVariable.CurrencyDecimalDigits);
                        txtlesser.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        txtlesser.Properties.Mask.UseMaskAsDisplayFormat = true;
                        break;
                    case "AmountExchange":
                        grdObjectValue.Visible = false;
                        dtFromDate.Visible = false;
                        dtToDate.Visible = false;
                        lblFromDate.Visible = false;
                        lblTodate.Visible = true;
                        lblValue.Visible = false;
                        lblRefNo.Visible = false;
                        txtRefNo.Visible = false;
                        lblgreater.Visible = true;
                        lbllesser.Visible = true;
                        txtgreater.Visible = true;
                        txtlesser.Visible = true;
                        lblTodate.Visible = false;
                        txtgreater.EditValue = null;
                        txtlesser.EditValue = null;
                        lblgreater.Location = new Point(192, 28);
                        txtgreater.Location = new Point(224, 24);
                        lbllesser.Location = new Point(192, 60);
                        txtlesser.Location = new Point(224, 56);

                        txtgreater.Properties.Mask.MaskType = MaskType.Numeric;
                        txtgreater.Properties.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                        txtgreater.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        txtgreater.Properties.Mask.UseMaskAsDisplayFormat = true;

                        txtlesser.Properties.Mask.MaskType = MaskType.Numeric;
                        txtlesser.Properties.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                        txtlesser.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        txtlesser.Properties.Mask.UseMaskAsDisplayFormat = true;
                        break;
                    default:
                        lblRefNo.Visible = false;
                        txtRefNo.Visible = false;
                        grdObjectValue.Visible = true;
                        dtFromDate.Visible = false;
                        dtToDate.Visible = false;
                        lblFromDate.Visible = false;
                        lblTodate.Visible = false;
                        lblValue.Visible = true;
                        lblTodate.Visible = false;
                        lblgreater.Visible = false;
                        lbllesser.Visible = false;
                        txtgreater.Visible = false;
                        txtlesser.Visible = false;
                        SetDataSourceCombobox(objectFieldSearchId);
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the data source combobox.
        /// </summary>
        /// <param name="objectFieldSearchId">The object field search identifier.</param>
        private void SetDataSourceCombobox(string objectFieldSearchId)
        {
            grdObjectValue.Properties.PopupWidth = 500;
            if (objectFieldSearchId == "RefTypeID") //Loại CT
            {
                var list = Model.GetRefTypes();
                foreach (var refTypeModel in list.ToList())
                {
                    if (refTypeModel.RefTypeId == 110 || refTypeModel.RefTypeId == 120)
                    {
                        list.Remove(refTypeModel);
                    }
                }
                grdObjectValue.Properties.DataSource = list;// Model.GetRefTypes();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                //  grdObjectValue.Properties.Columns["RefTypeId"].Visible = true;
                grdObjectValue.Properties.Columns["RefTypeName"].Visible = true;
                grdObjectValue.Properties.Columns["RefTypeName"].Width = 400;
                grdObjectValue.Properties.Columns["RefTypeId"].Width = 100;
                grdObjectValue.Properties.Columns["RefTypeId"].Caption = @"Mã loại chứng từ";
                grdObjectValue.Properties.Columns["RefTypeName"].Caption = @"Loại chứng từ";
                grdObjectValue.Properties.Columns["RefTypeId"].Alignment = HorzAlignment.Near;
                grdObjectValue.Properties.ValueMember = "RefTypeId";
                grdObjectValue.Properties.DisplayMember = "RefTypeName";
            }

            if (objectFieldSearchId == "CurrencyCode") // Loại Tiền
            {
                grdObjectValue.Properties.DataSource = Model.GetCurrenciesActive();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["CurrencyName"].Visible = true;
                grdObjectValue.Properties.Columns["CurrencyCode"].Visible = true;
                grdObjectValue.Properties.Columns["CurrencyName"].Width = 400;
                grdObjectValue.Properties.Columns["CurrencyCode"].Width = 100;
                grdObjectValue.Properties.Columns["CurrencyName"].Caption = @"Tên Loại Tiền";
                grdObjectValue.Properties.Columns["CurrencyCode"].Caption = @"Mã Loại Tiền";
                grdObjectValue.Properties.ValueMember = "CurrencyCode";
                grdObjectValue.Properties.DisplayMember = "CurrencyCode";
                // InitDefaultCurrencies();
            }
            if (objectFieldSearchId == "ProjectID") //Dự án
            {
                grdObjectValue.Properties.DataSource = Model.GetProjectsByObjectType("2");
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["ProjectName"].Visible = true;
                grdObjectValue.Properties.Columns["ProjectCode"].Visible = true;
                grdObjectValue.Properties.Columns["ProjectName"].Width = 400;
                grdObjectValue.Properties.Columns["ProjectCode"].Width = 100;
                grdObjectValue.Properties.Columns["ProjectName"].Caption = @"Tên Dự án";
                grdObjectValue.Properties.Columns["ProjectCode"].Caption = @"Mã Dự án";
                grdObjectValue.Properties.Columns["ProjectCode"].Alignment = HorzAlignment.Near;
                grdObjectValue.Properties.ValueMember = "ProjectId";
                grdObjectValue.Properties.DisplayMember = "ProjectCode";
            }

            if (objectFieldSearchId == "ProjectID_CTMT") //CTMT
            {
                grdObjectValue.Properties.DataSource = Model.GetProjectsByObjectType("1");
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["ProjectName"].Visible = true;
                grdObjectValue.Properties.Columns["ProjectCode"].Visible = true;
                grdObjectValue.Properties.Columns["ProjectName"].Width = 400;
                grdObjectValue.Properties.Columns["ProjectCode"].Width = 100;
                grdObjectValue.Properties.Columns["ProjectName"].Caption = @"Tên chương trình";
                grdObjectValue.Properties.Columns["ProjectCode"].Caption = @"Mã chương trình";
                grdObjectValue.Properties.Columns["ProjectCode"].Alignment = HorzAlignment.Near;
                grdObjectValue.Properties.ValueMember = "ProjectId";
                grdObjectValue.Properties.DisplayMember = "ProjectCode";
            }

            if (objectFieldSearchId == "CreditAccount") //TK có 
            {
                // Model.GetAccountsByIsActive(true);
                grdObjectValue.Properties.DataSource = Model.GetAccounts().Where(x => x.IsActive == true).ToList(); ;
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["AccountName"].Visible = true;
                grdObjectValue.Properties.Columns["AccountNumber"].Visible = true;
                grdObjectValue.Properties.Columns["AccountName"].Width = 400;
                grdObjectValue.Properties.Columns["AccountNumber"].Width = 100;
                grdObjectValue.Properties.Columns["AccountName"].Caption = @"Tên tài khoản";
                grdObjectValue.Properties.Columns["AccountNumber"].Caption = @"Mã tài khoản";
                grdObjectValue.Properties.Columns["AccountNumber"].Alignment = HorzAlignment.Near;
                grdObjectValue.Properties.ValueMember = "AccountNumber";
                grdObjectValue.Properties.DisplayMember = "AccountNumber";
            }
            if (objectFieldSearchId == "DebitAccount") //TK nợ
            {
                grdObjectValue.Properties.DataSource = Model.GetAccounts().Where(x => x.IsActive == true).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["AccountName"].Visible = true;
                grdObjectValue.Properties.Columns["AccountNumber"].Visible = true;
                grdObjectValue.Properties.Columns["AccountName"].Width = 400;
                grdObjectValue.Properties.Columns["AccountNumber"].Width = 100;
                grdObjectValue.Properties.Columns["AccountName"].Caption = @"Tên tài khoản";
                grdObjectValue.Properties.Columns["AccountNumber"].Caption = @"Mã tài khoản";
                grdObjectValue.Properties.Columns["AccountNumber"].Alignment = HorzAlignment.Near;
                grdObjectValue.Properties.ValueMember = "AccountNumber";
                grdObjectValue.Properties.DisplayMember = "AccountNumber";
            }
            if (objectFieldSearchId == "CashWithDrawTypeID") //Nghiệp vụ
            {
                grdObjectValue.Properties.DataSource = Model.GetCashWithdrawTypeModels();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["CashWithdrawTypeName"].Visible = true;
                //grdObjectValue.Properties.Columns["CashWithdrawTypeId"].Visible = true;
                grdObjectValue.Properties.Columns["CashWithdrawTypeId"].Caption = @"Mã Nghiệp vụ";
                grdObjectValue.Properties.Columns["CashWithdrawTypeName"].Caption = @"Nghiệp vụ";
                grdObjectValue.Properties.Columns["CashWithdrawTypeName"].Width = 400;
                grdObjectValue.Properties.Columns["CashWithdrawTypeId"].Width = 100;
                grdObjectValue.Properties.Columns["CashWithdrawTypeId"].Alignment = HorzAlignment.Near;
                grdObjectValue.Properties.ValueMember = "CashWithdrawTypeId";
                grdObjectValue.Properties.DisplayMember = "CashWithdrawTypeName";
            }
            if (objectFieldSearchId == "BudgetSourceCode") //Nguồn vốn
            {
                grdObjectValue.Properties.DataSource = Model.GetBudgetSourcesActive();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BudgetSourceCode"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetSourceName"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetSourceCode"].Caption = @"Mã nguồn";
                grdObjectValue.Properties.Columns["BudgetSourceName"].Caption = @"Tên nguồn";
                grdObjectValue.Properties.Columns["BudgetSourceCode"].Width = 100;
                grdObjectValue.Properties.Columns["BudgetSourceName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "BudgetSourceId";
                grdObjectValue.Properties.DisplayMember = "BudgetSourceCode";
            }

            if (objectFieldSearchId == "MethodDistributeID") //cấp phát
            {
                var result = new List<MethodDistributeModel>
                {
                    new MethodDistributeModel {MethodDistributeID = 0, MethodDistributeName = "Dự toán"},
                    new MethodDistributeModel {MethodDistributeID = 1, MethodDistributeName = "Lệnh chi"},
                    new MethodDistributeModel {MethodDistributeID = 2, MethodDistributeName = "Hiện vật"},
                    new MethodDistributeModel {MethodDistributeID = 3, MethodDistributeName = "Ghi thu, ghi chi"},
                    new MethodDistributeModel {MethodDistributeID = 4, MethodDistributeName = "Khác"},
                };
                // result.AddRange(result);
                grdObjectValue.Properties.DataSource = result;
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                //   grdObjectValue.Properties.Columns["MethodDistributeID"].Visible = true;
                grdObjectValue.Properties.Columns["MethodDistributeName"].Visible = true;
                grdObjectValue.Properties.Columns["MethodDistributeID"].Caption = @"Mã cấp phát";
                grdObjectValue.Properties.Columns["MethodDistributeName"].Caption = @"Cấp phát";
                grdObjectValue.Properties.Columns["MethodDistributeID"].Alignment = HorzAlignment.Near;
                grdObjectValue.Properties.Columns["MethodDistributeID"].Width = 100;
                grdObjectValue.Properties.Columns["MethodDistributeName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "MethodDistributeID";
                grdObjectValue.Properties.DisplayMember = "MethodDistributeName";

            }
            if (objectFieldSearchId == "BudgetChapterCode") //Chương
            {
                grdObjectValue.Properties.DataSource = Model.GetBudgetChaptersByIsActive(true);
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BudgetChapterCode"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetChapterName"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetChapterCode"].Caption = @"Mã chương";
                grdObjectValue.Properties.Columns["BudgetChapterName"].Caption = @"Tên chương";
                grdObjectValue.Properties.Columns["BudgetChapterCode"].Width = 100;
                grdObjectValue.Properties.Columns["BudgetChapterName"].Width = 400;
                grdObjectValue.Properties.Columns["BudgetChapterCode"].Alignment = HorzAlignment.Near;
                grdObjectValue.Properties.ValueMember = "BudgetChapterCode";
                grdObjectValue.Properties.DisplayMember = "BudgetChapterCode";
            }
            if (objectFieldSearchId == "BudgetSubKindItemCode") //Loại khoản
            {

                grdObjectValue.Properties.DataSource = Model.GetBudgetKindItemsByActive();
                //grdObjectValue.Properties.DataSource = _budgetKindItems;
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BudgetKindItemCode"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetKindItemName"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetKindItemCode"].Caption = @"Mã loại khoản";
                grdObjectValue.Properties.Columns["BudgetKindItemName"].Caption = @"Tên loại khoản";
                grdObjectValue.Properties.Columns["BudgetKindItemCode"].Width = 400;
                grdObjectValue.Properties.Columns["BudgetKindItemCode"].Width = 100;
                grdObjectValue.Properties.ValueMember = "BudgetKindItemCode";
                grdObjectValue.Properties.DisplayMember = "BudgetKindItemCode";
            }
            if (objectFieldSearchId == "BudgetItemCode") //Mục/ Tiểu mục
            {
                grdObjectValue.Properties.DataSource = _budgetItems;
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BudgetItemCode"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetItemName"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetItemCode"].Caption = @"Mã mục";
                grdObjectValue.Properties.Columns["BudgetItemName"].Caption = @"Tên mục";
                grdObjectValue.Properties.Columns["BudgetItemCode"].Width = 100;
                grdObjectValue.Properties.Columns["BudgetItemName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "BudgetItemCode";
                grdObjectValue.Properties.DisplayMember = "BudgetItemCode";
            }


            if (objectFieldSearchId == "BudgetItemId") //Nhóm mục
            {
                grdObjectValue.Properties.DataSource = Model.GetBudgetItems().Where(x => x.BudgetItemType <= 2).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BudgetItemCode"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetItemName"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetItemCode"].Caption = @"Mã nhóm mục";
                grdObjectValue.Properties.Columns["BudgetItemName"].Caption = @"Tên tên nhóm mục";
                grdObjectValue.Properties.Columns["BudgetItemCode"].Width = 100;
                grdObjectValue.Properties.Columns["BudgetItemName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "BudgetItemCode"; //BudgetGroupCode
                grdObjectValue.Properties.DisplayMember = "BudgetItemCode";
            }


            if (objectFieldSearchId == "DepartmentCode") //phòng ban
            {
                grdObjectValue.Properties.DataSource = Model.GetDepartments().Where(x => x.IsActive).ToList().OrderBy(x => x.DepartmentCode).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["DepartmentCode"].Visible = true;
                grdObjectValue.Properties.Columns["DepartmentName"].Visible = true;
                grdObjectValue.Properties.Columns["DepartmentCode"].Caption = @"Mã phòng ban";
                grdObjectValue.Properties.Columns["DepartmentName"].Caption = @"Tên phòng ban";
                grdObjectValue.Properties.Columns["DepartmentCode"].Width = 100;
                grdObjectValue.Properties.Columns["DepartmentName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "DepartmentId";
                grdObjectValue.Properties.DisplayMember = "DepartmentCode";
            }
            if (objectFieldSearchId == "InventoryItemID") //Vật tư
            {
                grdObjectValue.Properties.DataSource = Model.GetInventoryItemsByIsToolAndIsActive(false, true);
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["InventoryItemName"].Visible = true;
                grdObjectValue.Properties.Columns["InventoryItemCode"].Visible = true;

                grdObjectValue.Properties.Columns["InventoryItemName"].Width = 400;
                grdObjectValue.Properties.Columns["InventoryItemCode"].Width = 100;
                grdObjectValue.Properties.Columns["InventoryItemName"].Caption = @"Tên vật tư";
                grdObjectValue.Properties.Columns["InventoryItemCode"].Caption = @"Mã vật tư";
                grdObjectValue.Properties.ValueMember = "InventoryItemId";
                grdObjectValue.Properties.DisplayMember = "InventoryItemCode";
            }

            if (objectFieldSearchId == "InventoryItemID_CCDC") //CCDC
            {
                grdObjectValue.Properties.DataSource = Model.GetInventoryItemsByIsToolAndIsActive(true, true);
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["InventoryItemName"].Visible = true;
                grdObjectValue.Properties.Columns["InventoryItemCode"].Visible = true;

                grdObjectValue.Properties.Columns["InventoryItemName"].Width = 400;
                grdObjectValue.Properties.Columns["InventoryItemCode"].Width = 100;
                grdObjectValue.Properties.Columns["InventoryItemName"].Caption = @"Tên CCDC";
                grdObjectValue.Properties.Columns["InventoryItemCode"].Caption = @"Mã CCDC";
                grdObjectValue.Properties.ValueMember = "InventoryItemId";
                grdObjectValue.Properties.DisplayMember = "InventoryItemCode";
            }

            if (objectFieldSearchId == "FixedAssetCode") //Tài sản CĐ
            {
                grdObjectValue.Properties.DataSource = Model.GetFixedAssetsActive(true);
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["FixedAssetName"].Visible = true;
                grdObjectValue.Properties.Columns["FixedAssetCode"].Visible = true;
                grdObjectValue.Properties.Columns["FixedAssetName"].Caption = @"Tên tài sản";
                grdObjectValue.Properties.Columns["FixedAssetCode"].Caption = @"Mã tài sản";
                grdObjectValue.Properties.Columns["FixedAssetCode"].Width = 100;
                grdObjectValue.Properties.Columns["FixedAssetName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "FixedAssetId";
                grdObjectValue.Properties.DisplayMember = "FixedAssetCode";
            }
            if (objectFieldSearchId == @"ActivityID") //hoạt động sư nghiệp
            {
                grdObjectValue.Properties.DataSource = Model.GetActivitysActive(true);
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["ActivityCode"].Visible = true;
                grdObjectValue.Properties.Columns["ActivityName"].Visible = true;
                grdObjectValue.Properties.Columns["ActivityCode"].Caption = @"Mã công việc";
                grdObjectValue.Properties.Columns["ActivityName"].Caption = @"Tên công việc";
                grdObjectValue.Properties.Columns["ActivityCode"].Width = 150;
                grdObjectValue.Properties.Columns["ActivityName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "ActivityId";
                grdObjectValue.Properties.DisplayMember = "ActivityCode";
            }
            if (objectFieldSearchId == @"VendorID") //Nhà cung cấp
            {
                //   grdObjectValue.Properties.DataSource = Model.GetVendors().OrderBy(x=>x.VendorCode).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["VendorCode"].Visible = true;
                grdObjectValue.Properties.Columns["VendorName"].Visible = true;
                grdObjectValue.Properties.Columns["VendorCode"].Width = 100;
                grdObjectValue.Properties.Columns["VendorName"].Width = 400;
                grdObjectValue.Properties.Columns["VendorCode"].Caption = @"Mã NCC";
                grdObjectValue.Properties.Columns["VendorName"].Caption = @"Tên NCC";
                grdObjectValue.Properties.ValueMember = "VendorId";
                grdObjectValue.Properties.DisplayMember = "VendorCode";
            }
            if (objectFieldSearchId == @"BankID") //Tài khoản ngân hàng
            {
                grdObjectValue.Properties.DataSource = Model.GetBanksActive(true);
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BankAccount"].Visible = true;
                grdObjectValue.Properties.Columns["BankName"].Visible = true;
                grdObjectValue.Properties.Columns["BankAccount"].Width = 100;
                grdObjectValue.Properties.Columns["BankName"].Width = 400;
                grdObjectValue.Properties.Columns["BankAccount"].Caption = @"Số TK";
                grdObjectValue.Properties.Columns["BankName"].Caption = @"Tên ngân hàng";
                grdObjectValue.Properties.ValueMember = "BankId";
                grdObjectValue.Properties.DisplayMember = "BankAccount";
            }

            if (objectFieldSearchId == @"EmployeeID") //Nhân viên
            {
                // grdObjectValue.Properties.DataSource = Model.GetEmployees().OrderBy(x=>x.EmployeeCode).ToList(); 
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["EmployeeCode"].Visible = true;
                grdObjectValue.Properties.Columns["EmployeeName"].Visible = true;
                grdObjectValue.Properties.Columns["EmployeeName"].Caption = @"Tên NV";
                grdObjectValue.Properties.Columns["EmployeeCode"].Caption = @"Mã NV";
                grdObjectValue.Properties.Columns["EmployeeCode"].Width = 100;
                grdObjectValue.Properties.Columns["EmployeeName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "EmployeeCode";
                grdObjectValue.Properties.DisplayMember = "EmployeeCode";
            }
            if (objectFieldSearchId == "AccountingObjectID") //Đối tượng
            {
                //var ds = Model.GetAccountingObjectsByIsEmployee(false);
                grdObjectValue.Properties.DataSource = Model.GetAccountingObjectsByIsEmployee(false).Where(e => e.IsActive).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["AccountingObjectName"].Visible = true;
                grdObjectValue.Properties.Columns["AccountingObjectCode"].Visible = true;
                grdObjectValue.Properties.Columns["AccountingObjectCode"].Width = 100;
                grdObjectValue.Properties.Columns["AccountingObjectName"].Width = 400;
                grdObjectValue.Properties.Columns["AccountingObjectName"].Caption = @"Tên đối tượng";
                grdObjectValue.Properties.Columns["AccountingObjectCode"].Caption = @"Mã đối tượng";
                grdObjectValue.Properties.ValueMember = "AccountingObjectId";
                grdObjectValue.Properties.DisplayMember = "AccountingObjectCode";
            }

            if (objectFieldSearchId == "AccountingObjectCode") //cán bộ
            {
                grdObjectValue.Properties.DataSource = Model.GetAccountingObjectsByIsEmployee(true).Where(e => e.IsActive).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["AccountingObjectName"].Visible = true;
                grdObjectValue.Properties.Columns["AccountingObjectCode"].Visible = true;
                grdObjectValue.Properties.Columns["AccountingObjectCode"].Width = 100;
                grdObjectValue.Properties.Columns["AccountingObjectName"].Width = 400;
                grdObjectValue.Properties.Columns["AccountingObjectName"].Caption = @"Tên cán bộ";
                grdObjectValue.Properties.Columns["AccountingObjectCode"].Caption = @"Mã cán bộ";
                grdObjectValue.Properties.ValueMember = "AccountingObjectId";
                grdObjectValue.Properties.DisplayMember = "AccountingObjectCode";
            }
            if (objectFieldSearchId == "BudgetExpenseID") //Phi, le phi
            {
                grdObjectValue.Properties.DataSource = Model.GetBudgetExpensesByIsActive(true);
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BudgetExpenseName"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetExpenseCode"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetExpenseName"].Width = 400;
                grdObjectValue.Properties.Columns["BudgetExpenseCode"].Width = 100;
                grdObjectValue.Properties.Columns["BudgetExpenseName"].Caption = @"Tên CTMT/Dự án";
                grdObjectValue.Properties.Columns["BudgetExpenseCode"].Caption = @"Mã CTMT/Dự án";
                grdObjectValue.Properties.Columns["BudgetExpenseCode"].Alignment = HorzAlignment.Near;
                grdObjectValue.Properties.ValueMember = "BudgetExpenseId";
                grdObjectValue.Properties.DisplayMember = "BudgetExpenseCode";
            }
            if (objectFieldSearchId == "FundStructureID") //Phi, le phi
            {
                grdObjectValue.Properties.DataSource = Model.GetFundStructuresActive(true);
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["FundStructureName"].Visible = true;
                grdObjectValue.Properties.Columns["FundStructureCode"].Visible = true;
                grdObjectValue.Properties.Columns["FundStructureName"].Width = 400;
                grdObjectValue.Properties.Columns["FundStructureCode"].Width = 100;
                grdObjectValue.Properties.Columns["FundStructureName"].Caption = @"Tên khoản chi";
                grdObjectValue.Properties.Columns["FundStructureCode"].Caption = @"Mã khoản chi";
                grdObjectValue.Properties.Columns["FundStructureCode"].Alignment = HorzAlignment.Near;
                grdObjectValue.Properties.ValueMember = "FundStructureId";
                grdObjectValue.Properties.DisplayMember = "FundStructureCode";
            }
            if (objectFieldSearchId == "ContractID") //Hợp đồng
            {
                grdObjectValue.Properties.DataSource = Model.GetContractsActive(true);
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["ContractNo"].Visible = true;
                grdObjectValue.Properties.Columns["ContractName"].Visible = true;
                grdObjectValue.Properties.Columns["ContractNo"].Caption = @"Hợp đồng số";
                grdObjectValue.Properties.Columns["ContractName"].Caption = @"Tên hợp đồng";
                grdObjectValue.Properties.Columns["ContractNo"].Width = 100;
                grdObjectValue.Properties.Columns["ContractName"].Width = 400;
                grdObjectValue.Properties.Columns["ContractNo"].Alignment = HorzAlignment.Near;
                grdObjectValue.Properties.ValueMember = "ContractId";
                grdObjectValue.Properties.DisplayMember = "ContractNo";
            }
            grdObjectValue.Properties.ShowFooter = false;
        }

        /// <summary>
        /// Initializes the default currencies.
        /// </summary>
        protected void InitDefaultCurrencies()
        {
            if (CurrencyLocal == CurrencyAccounting)
            {
                grdObjectValue.Properties.DataSource = new List<GridLookUpItem> { new GridLookUpItem(CurrencyAccounting, CurrencyAccounting) };
            }
            else
            {
                grdObjectValue.Properties.DataSource = new List<GridLookUpItem> { new GridLookUpItem(CurrencyAccounting, CurrencyAccounting), new GridLookUpItem(CurrencyLocal, CurrencyLocal) };
            }

            grdObjectValue.Properties.PopulateColumns();
            foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
            {
                grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
            }
            var currencyColumns = new List<XtraColumn>
                                          {
                                              new XtraColumn
                                                  {
                                                      ColumnName = "DataValue",
                                                      ColumnVisible = false,
                                                       ColumnCaption = "Mã tiền tệ",
                                                      Alignment = HorzAlignment.Center
                                                  },
                                              new XtraColumn
                                                  {
                                                      ColumnName = "DataMember",
                                                      ColumnCaption = "Tên tiền tệ",
                                                      ColumnVisible = true,
                                                      ColumnPosition = 2,
                                                      ColumnWith = 500
                                                  }
                                          };

            foreach (var column in currencyColumns)
            {

                grdObjectValue.Properties.Columns[column.ColumnName].Visible = true;
                grdObjectValue.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                grdObjectValue.Properties.Columns[column.ColumnName].Width = column.ColumnWith;

            }
            grdObjectValue.Properties.ValueMember = "DataValue";
            grdObjectValue.Properties.DisplayMember = "DataMember";
        }

        /// <summary>
        /// Sets the numeric format control.
        /// </summary>
        /// <param name="grdView">The GRD view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        public void SetNumericFormatControl(GridView grdView, bool isSummary)
        {
            //Get format data from db to format grid control
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
                        else
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = GlobalVariable.CurrencyDecimalDigits;
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
                        //oCol.DisplayFormat.FormatString =
                        //    Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        repositoryDateEdit.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
                        repositoryDateEdit.Mask.EditMask = @"dd/MM/yyyy";
                        repositoryDateEdit.DisplayFormat.FormatType = FormatType.DateTime;
                        repositoryDateEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryDateEdit;

                        //oCol.DisplayFormat.FormatString = "dd/MM/yyyy";
                        //oCol.DisplayFormat.FormatType = FormatType.DateTime;
                        //oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the grdList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void grdList_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Click event of the btnExportToExcel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            gridView.OptionsPrint.AutoWidth = false;
            gridView.BestFitColumns();
            gridView.ExportToXls(@"Search.xls", new XlsExportOptions() { TextExportMode = TextExportMode.Text });
            Process.Start("Search.xls");
        }

        /// <summary>
        /// Handles the Click event of the btnPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //// Open the Preview window.
            gridView.OptionsPrint.AutoWidth = false;
            gridView.BestFitColumns();
            DisplayColumns(false);

            // Create a PrintingSystem component. 
            var ps = new PrintingSystem();
            // Create a link that will print a control. 
            var link = new PrintableComponentLink(ps)
            {
                Component = grdList,
                Landscape = true,
                PaperKind = System.Drawing.Printing.PaperKind.A3
            };

            link.CreateReportHeaderArea += printableComponentLink_CreateReportHeaderArea;
            // Generate the report. 
            link.CreateDocument();
            // Show the report. 
            link.ShowPreview();

            DisplayColumns(true);
        }

        /// <summary>
        /// Handles the PopupMenuShowing event of the grdlookUpExpressionSearchView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PopupMenuShowingEventArgs"/> instance containing the event data.</param>
        private void grdlookUpExpressionSearchView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenu1.ShowPopup(grdlookUpExpressionSearch.PointToScreen(e.Point));
                }
            }
        }

        /// <summary>
        /// Deletes the row item.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(139));
        }

        #endregion

        #region FieldSearch
        /// <summary>
        /// Objects the field searchs.
        /// </summary>
        /// <returns></returns>
        protected IList<ObjectFieldSearch> ObjectFieldSearchs()
        {
            IList<ObjectFieldSearch> listOc = new List<ObjectFieldSearch>();
            listOc.Add(new ObjectFieldSearch("RefNo", "Số chứng từ"));
            listOc.Add(new ObjectFieldSearch("FromDate", "Ngày chứng từ"));
            listOc.Add(new ObjectFieldSearch("RefTypeID", "Loại chứng từ"));
            listOc.Add(new ObjectFieldSearch("CurrencyCode", "Loại tiền"));
            listOc.Add(new ObjectFieldSearch("DebitAccount", "Tài khoản nợ"));
            listOc.Add(new ObjectFieldSearch("CreditAccount", "Tài khoản có"));
            listOc.Add(new ObjectFieldSearch("AmountExchange", "Quy đổi"));
            listOc.Add(new ObjectFieldSearch("AmountOC", "Số tiền"));
            listOc.Add(new ObjectFieldSearch("CashWithDrawTypeID", "Nghiệp vụ"));
            listOc.Add(new ObjectFieldSearch("BudgetSourceCode", "Nguồn vốn"));
            listOc.Add(new ObjectFieldSearch("MethodDistributeID", "Cấp phát"));
            listOc.Add(new ObjectFieldSearch("BudgetChapterCode", "Chương"));
            listOc.Add(new ObjectFieldSearch("BudgetSubKindItemCode", "Loại khoản"));
            listOc.Add(new ObjectFieldSearch("BudgetItemCode", "Mục/Tiểu mục"));
            listOc.Add(new ObjectFieldSearch("InventoryItemID", "Vật tư"));
            listOc.Add(new ObjectFieldSearch("InventoryItemID_CCDC", "Công cụ dụng cụ"));
            listOc.Add(new ObjectFieldSearch("AccountingObjectID", "Đối tượng"));
            listOc.Add(new ObjectFieldSearch("AccountingObjectCode", "Cán bộ"));//
            listOc.Add(new ObjectFieldSearch("DepartmentCode", "Phòng ban"));
            listOc.Add(new ObjectFieldSearch("FixedAssetCode", "TSCĐ"));
            listOc.Add(new ObjectFieldSearch("BankID", "Tài khoản ngân hàng"));
            listOc.Add(new ObjectFieldSearch("ProjectID", "Dự án"));
            listOc.Add(new ObjectFieldSearch("ProjectID_CTMT", "Chương trình mục tiêu"));
            listOc.Add(new ObjectFieldSearch("FundStructureID", "Khoản chi"));
            listOc.Add(new ObjectFieldSearch("BudgetExpenseID", "Phí, lệ phí"));
            listOc.Add(new ObjectFieldSearch("ContractID", "Hợp đồng"));
            listOc.Add(new ObjectFieldSearch("ActivityID", "Công việc"));
            //  
            return listOc;
        }

        /// <summary>
        /// Handles the Click event of the btnShowRef control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnShowRef_Click(object sender, EventArgs e)
        {
            _dataForSearch = new List<ObjectExpressionSearch>();
            grdlookUpExpressionSearch.DataSource = _dataForSearch;
            grdlookUpExpressionSearchView.RefreshData();
            WhereClause = " ";
            CurrencyCode = "";
            FromDate = "";
            ToDate = "";
        }

        /// <summary>
        /// Formats the grid expression.
        /// </summary>
        private void FormatGridExpression()
        {
            var gridColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "ObjectFieldSearchId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ObjectFieldSearchName", ColumnCaption = "Tên trường", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  150 },
                                                new XtraColumn { ColumnName = "ExpressionLogic", ColumnCaption = "Chọn toán tử", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 120 },
                                                new XtraColumn { ColumnName = "ObjectSearchValueName", ColumnCaption = "Giá trị", ColumnPosition = 2, ColumnVisible = true, ColumnWith =  250 },
                                                new XtraColumn { ColumnName = "ObjectSearchValueId", ColumnVisible = false },
                                              //  new XtraColumn { ColumnName = "ParentId", ColumnVisible = false }
                                            };

            foreach (var column in gridColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    grdlookUpExpressionSearchView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //  grdlookUpExpressionSearchView.Columns[column.ColumnName].OptionsColumn = column.ColumnPosition;
                    grdlookUpExpressionSearchView.Columns[column.ColumnName].Width = column.ColumnWith;
                }
                else { grdlookUpExpressionSearchView.Columns[column.ColumnName].Visible = false; }
            }
        }

        /// <summary>
        /// Formats the GRD list.
        /// </summary>
        private void FormatGrdList()
        {
            var gridColumnsCollection = new List<XtraColumn> {
                #region OriginalGeneralLedger
                new XtraColumn { ColumnName = "OriginalGeneralLedgerId", ColumnCaption = "0", ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "RefId", ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "RefType", ColumnCaption = "Loại chứng từ", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  200, RepositoryControl = _gridLookUpEditRefType},
                new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số chứng từ", ColumnPosition = 2, ColumnVisible = true, ColumnWith =  150,},
                new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ColumnPosition = 3, ColumnVisible = true, ColumnWith =  90, Alignment = HorzAlignment.Center,ColumnType = UnboundColumnType.DateTime},
                new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 4, ColumnVisible = true, ColumnWith =  90,ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center},
                new XtraColumn { ColumnName = "DebitAccount", ColumnCaption = "TK nợ", ColumnPosition = 5, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "CreditAccount", ColumnCaption = "TK có", ColumnPosition = 6, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền", ColumnPosition = 7, ColumnVisible = true, ColumnWith =  90, Alignment = HorzAlignment.Center},
                new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "------", ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "InvNo", ColumnCaption = "------", ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "InvDate", ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "AmountOC", ColumnCaption = "Số tiền", ColumnPosition = 8, ColumnVisible = true, ColumnWith =  150 ,ColumnType = UnboundColumnType.Decimal},
                new XtraColumn { ColumnName = "Amount", ColumnCaption = "Quy đổi", ColumnPosition = 9, ColumnVisible = true, ColumnWith =  150 ,ColumnType = UnboundColumnType.Decimal},
                new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Nội dung thanh toán", ColumnVisible = false, ColumnWith =  140 },
                new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 10, ColumnVisible = true, ColumnWith =  300 },
                new XtraColumn { ColumnName = "BudgetSourceId", ColumnCaption = "Nguồn vốn", ColumnPosition = 11, ColumnVisible = true, ColumnWith =  90, RepositoryControl = _gridLookUpEditBudgetSource},
                new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 12, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnCaption = "Loại", ColumnPosition = 13, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 14, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 15, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 16, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "MethodDistributeId", ColumnCaption = "Cấp phát", ColumnPosition = 17, ColumnVisible = true, ColumnWith =  150, RepositoryControl = _repositoryMethodDistributeId},
                new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 18, ColumnVisible = true, ColumnWith =  150, RepositoryControl = _gridLookUpEditCashWithdrawType},
                new XtraColumn { ColumnName = "BankId", ColumnCaption = "Ngân hàng",ColumnPosition = 19, ColumnVisible = true, ColumnWith =  150, RepositoryControl = _gridLookUpEditBank},
                new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng", ColumnPosition = 20, ColumnVisible = true, ColumnWith =  150, RepositoryControl = _gridLookUpEditAccountingObject},
                new XtraColumn { ColumnName = "FixedAssetCode", ColumnCaption = "TSCĐ",  ColumnPosition = 21, ColumnVisible = true, ColumnWith =  150, RepositoryControl = _gridLookUpEditFixedAsset},
                new XtraColumn { ColumnName = "DepartmentName", ColumnCaption = "Phòng ban", ColumnPosition = 22, ColumnVisible = true, ColumnWith =  90, RepositoryControl = _gridLookUpEditDepartment},
                new XtraColumn { ColumnName = "FundStructureId", ColumnCaption = "Khoản chi", ColumnPosition = 23, ColumnVisible = true, ColumnWith =  150, RepositoryControl = _gridLookUpEditFundStructure},
                new XtraColumn { ColumnName = "BudgetExpenseId", ColumnCaption = "Phí, lệ phí", ColumnPosition = 24, ColumnVisible = true, ColumnWith =  150, RepositoryControl = _gridLookUpEditBudgetExpense},
                new XtraColumn { ColumnName = "ContractId", ColumnCaption = "Hợp đồng", ColumnPosition = 25, ColumnVisible = true, ColumnWith =  150 ,RepositoryControl = _gridLookUpEditContract},
                new XtraColumn { ColumnName = "CreditAccountingObjectId", ColumnVisible = false },
                new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 26, ColumnVisible = true, ColumnWith =  150, RepositoryControl = _gridLookUpEditProject},
                 new XtraColumn { ColumnName = "ActivityId", ColumnCaption = "Công việc",  ColumnPosition = 27, ColumnVisible = true, ColumnWith =  150, RepositoryControl = _gridLookUpEditActivity},
                new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false },
                new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false },
                new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false },
                new XtraColumn { ColumnName = "PurchasePurposeId", ColumnCaption = "Ngân hàng", ColumnVisible = false },
                new XtraColumn { ColumnName = "PurchasePurposeCode", ColumnCaption = "Ngân hàng", ColumnVisible = false },
                new XtraColumn { ColumnName = "OrgPrice", ColumnVisible = false },
                new XtraColumn { ColumnName = "BankName", ColumnVisible = false },
                new XtraColumn { ColumnName = "ToBankId", ColumnCaption = "Khoản chi",ColumnVisible = false },
                new XtraColumn { ColumnName = "Approved",  ColumnVisible = false },
                new XtraColumn { ColumnName = "InvType", ColumnVisible = false },
                new XtraColumn { ColumnName = "TaxAccount", ColumnVisible = false },
                new XtraColumn { ColumnName = "TaxAmount", ColumnCaption = "---",ColumnVisible = false },
                new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false },
                new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false },
                new XtraColumn { ColumnName = "OrgRefNo", ColumnVisible = false },
                new XtraColumn { ColumnName = "OrgRefDate", ColumnVisible = false },
                new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false },
                     
#endregion
            };
            try
            {
                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridView.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    }
                    else { gridView.Columns[column.ColumnName].Visible = false; }
                }
                gridView.InitGridLayout(gridColumnsCollection);
                SetNumericFormatControl(gridView, true);
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        /// <summary>
        /// Handles the Click event of the simpleselect control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void simpleselect_Click(object sender, EventArgs e)
        {
            try
            {
                grdlookUpExpressionSearchView.DeleteRow(grdlookUpExpressionSearchView.FocusedRowHandle);
            }
            catch { }

        }

        /// <summary>
        /// Handles the ItemClick event of the barButtonItem1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs"/> instance containing the event data.</param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRowItem();
        }

        /// <summary>
        /// Deletes the row item.
        /// </summary>
        protected virtual void DeleteRowItem()
        {
            grdlookUpExpressionSearchView.DeleteSelectedRows();
        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string objectFieldSearchId = gridViewFieldSearch.GetFocusedRowCellValue("ObjectFieldSearchId").ToString();
                string objectFieldSearchName = gridViewFieldSearch.GetFocusedRowCellValue("ObjectFieldSearchName").ToString();

                string objectSearchValueId;
                string objectSearchValueName;
                if (txtRefNo.Visible)
                {
                    objectSearchValueId = txtRefNo.Text;
                    if (objectSearchValueId.Length > 0)
                    {
                        _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName,
                                                                     objectSearchValueId, objectSearchValueId, "AND"));
                    }
                    else
                    {
                        XtraMessageBox.Show(@"Vui lòng nhập giá trị tìm kiếm!",
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtRefNo.Focus();
                        return;
                    }
                }
                else if (dtToDate.Visible)
                {
                    objectSearchValueId = dtFromDate.EditValue.ToString().Substring(0, 10);
                    objectFieldSearchName = "Từ ngày";
                    objectSearchValueName = dtFromDate.EditValue.ToString().Substring(0, 10); //.GetColumnValue(""); 
                    _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId, objectSearchValueName, "AND"));

                    objectSearchValueId = dtToDate.EditValue.ToString().Substring(0, 10);
                    objectFieldSearchName = "Đến ngày";
                    objectSearchValueName = dtToDate.EditValue.ToString().Substring(0, 10);//.GetColumnValue(""); 
                    _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId, objectSearchValueName, "AND"));
                }
                else if (txtgreater.Visible && objectFieldSearchId == "AmountOC")
                {
                    var greaterValue = decimal.Parse(txtgreater.EditValue.ToString());
                    var lesserValue = decimal.Parse(txtlesser.EditValue.ToString());
                    /*Kiểm tra dữ liệu trước khi thêm vào Grid điều kiệns*/
                    if (greaterValue > lesserValue)
                    {
                        XtraMessageBox.Show(@"Giá trị số tiền tìm kiếm chưa hợp lệ!",
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtgreater.Focus();
                        return;
                    }
                    objectSearchValueId = ">= " + Convert.ToDecimal(txtgreater.EditValue);
                    objectFieldSearchName = "Số tiền ";
                    objectSearchValueName = ">= " + txtgreater.Text;
                    _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId, objectSearchValueName, "AND"));

                    objectSearchValueId = " <= " + Convert.ToDecimal(txtlesser.EditValue);
                    objectFieldSearchName = "Số tiền";
                    objectSearchValueName = " <= " + txtlesser.Text;
                    _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId, objectSearchValueName, "AND"));
                }
                else if (txtgreater.Visible && objectFieldSearchId == "AmountExchange")
                {
                    var greaterValue = decimal.Parse(txtgreater.EditValue.ToString());
                    var lesserValue = decimal.Parse(txtlesser.EditValue.ToString());

                    /*Kiểm tra dữ liệu trước khi thêm vào Grid điều kiện*/
                    if (greaterValue > lesserValue)
                    {
                        XtraMessageBox.Show(@"Giá trị số tiền tìm kiếm chưa hợp lệ!",
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtgreater.Focus();
                        return;
                    }

                    objectSearchValueId = ">= " + Convert.ToDecimal(txtgreater.EditValue);
                    objectFieldSearchName = " Quy đổi";
                    objectSearchValueName = ">= " + Convert.ToDecimal(txtgreater.Text);
                    _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId, objectSearchValueName, "AND"));

                    objectSearchValueId = "<= " + Convert.ToDecimal(txtlesser.EditValue);
                    objectFieldSearchName = "Quy đổi ";
                    objectSearchValueName = "<= " + Convert.ToDecimal(txtlesser.Text);
                    _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId, objectSearchValueName, "AND"));
                }
                else
                {
                    if (string.IsNullOrEmpty(grdObjectValue.EditValue.ToString()))
                        return;
                    objectSearchValueId = grdObjectValue.EditValue.ToString();
                    objectSearchValueName = grdObjectValue.Text; //.GetColumnValue(""); 
                    if (objectSearchValueId.Length > 0)
                    {
                        _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName,
                                                                        objectSearchValueId, objectSearchValueName, "AND"));
                    }
                    else
                    {
                        XtraMessageBox.Show(@"Vui lòng nhập giá trị tìm kiếm!",
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        grdObjectValue.Focus();
                        return;
                    }
                }

                grdlookUpExpressionSearch.DataSource = _dataForSearch;
                grdlookUpExpressionSearchView.RefreshData();
                FormatGridExpression();
            }
            catch (Exception ex)
            { XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region  Search Result GridView

        /// <summary>
        /// Displays the columns.
        /// </summary>
        /// <param name="isDisplay">if set to <c>true</c> [is display].</param>
        private void DisplayColumns(bool isDisplay)
        {
            foreach (GridColumn column in gridView.Columns)
            {
                if (column.FieldName == "RefType")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 1 : -1;
                }
                else if (column.FieldName == "CurrencyCode")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 7 : -1;
                }
                else if (column.FieldName == "Amount")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 9 : -1;
                }
                else if (column.FieldName == "BudgetSourceId")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 11 : -1;
                }
                else if (column.FieldName == "BudgetChapterCode")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 12 : -1;
                }
                else if (column.FieldName == "BudgetKindItemCode")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 13 : -1;
                }
                else if (column.FieldName == "BudgetSubKindItemCode")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 14 : -1;
                }
                else if (column.FieldName == "BudgetItemCode")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 15 : -1;
                }
                else if (column.FieldName == "BudgetSubItemCode")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 16 : -1;
                }
                else if (column.FieldName == "MethodDistributeId")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 17 : -1;
                }
                else if (column.FieldName == "CashWithDrawTypeId")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 18 : -1;
                }
                else if (column.FieldName == "BankId")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 19 : -1;
                }
                else if (column.FieldName == "AccountingObjectId")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 20 : -1;
                }
                else if (column.FieldName == "ActivityId")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 21 : -1;
                }
                else if (column.FieldName == "FixedAssetCode")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 23 : -1;
                }
                else if (column.FieldName == "DepartmentName")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 22 : -1;
                }
                else if (column.FieldName == "BudgetExpenseId")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 21 : -1;
                }
                else if (column.FieldName == "FundStructureId")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 21 : -1;
                }
                else if (column.FieldName == "ContractId")
                {
                    column.Visible = isDisplay;
                    column.VisibleIndex = isDisplay ? 27 : -1;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnGoToVoucher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGoToVoucher_Click(object sender, EventArgs e)
        {
            _accountsPresenter.Display();
            if ((gridView.GetFocusedRowCellValue("RefType") != null))
            {
                bool flag = true;
                int refTypeId = int.Parse(gridView.GetFocusedRowCellValue("RefType").ToString());

                //Chung tu dau  ky
                /* if ( refTypeId == (int)BuCA.Enum.RefType.OpeningFixedAsset)
                     return;*/

                string objectFieldSearchId = gridView.GetFocusedRowCellValue("RefId").ToString();
                var frmDetail = new FrmXtraBaseVoucherDetail();
                switch (refTypeId)
                {
                    case (int)BuCA.Enum.RefType.BUPlanReceiptEarlyYear: // Nhận dự toán đầu năm
                        frmDetail = new FrmBUPlanReceiptDetail(); break;
                    case (int)BuCA.Enum.RefType.BUPlanReceiptAddition: // Nhận dự toán bổ sung
                        frmDetail = new FrmBUPlanReceiptDetail(); break;
                    case (int)BuCA.Enum.RefType.BUPlanAdjustment: // Điều chỉnh dự toán
                        frmDetail = new FrmBUPlanAdjustmentDetail(); break;
                    case (int)BuCA.Enum.RefType.BUPlanWithDrawCash: // Rút dự toán tiền mặt
                        frmDetail = new FrmBUPlanWithdrawCashDetail(); break;
                    case (int)BuCA.Enum.RefType.BUPlanWithDrawTransfer: // Rút dự toán chuyển khoản
                        frmDetail = new FrmBUPlanWithDrawTransferDetail(); break;
                    case (int)BuCA.Enum.RefType.BUTransfer: // Chuyển khoản kho bạc
                        frmDetail = new FrmBUTransferDetail(); break;
                    case (int)BuCA.Enum.RefType.BUTransferPurchase: // Chuyển khoản kho bạc mua vật tư hàng hóa
                        frmDetail = new FrmBUTransferDetailPurchase(); break;
                    case (int)BuCA.Enum.RefType.BUTransferFixedAsset: // Chuyển khoản kho bạc mua tài sản cố định
                        frmDetail = new FrmCAPaymentFixedAssetDetail(); break;
                    case (int)BuCA.Enum.RefType.BUTransferPayWage: // Chuyển khoản kho bạc trả lương 
                        frmDetail = new FrmBUTransfersPayWageDetail(); break;
                    case (int)BuCA.Enum.RefType.BUTransferPayInsurrance: // Chuyển khoản kho bạc trả bảo hiểm
                        frmDetail = new FrmBUTransfersPayInsurranceDetail(); break;
                    case (int)BuCA.Enum.RefType.BUVoucherList: // Bảng kê chứng từ thanh toán đã cấp dự toán 
                        frmDetail = new FrmBUVoucherListDetail(); break;
                    case (int)BuCA.Enum.RefType.BUNoEstimateVoucherList: // Bảng kê chứng từ thanh toán chưa cấp dự toán 
                        frmDetail = new FrmBUNoEstimateVoucherListDetail(); break;
                    case (int)BuCA.Enum.RefType.BUCashBasicVoucherList:// Bảng kê chứng từ thực chi
                        frmDetail = new FrmBUCashBasicVoucherListDetail(); break;
                    case (int)BuCA.Enum.RefType.BUPlanCancel: // Hủy dự toán 
                        frmDetail = new FrmBUPlanCancelDetail(); break;
                    case (int)BuCA.Enum.RefType.BUCommitmentRequest: // Đề nghị cam kết chi 
                        frmDetail = new FrmBUCommitmentRequestDetail(); break;
                    case (int)BuCA.Enum.RefType.BUCommitmentAdjustment: // Điều chỉnh cam kết chi
                        frmDetail = new FrmBUCommitmentAdjustmentDetail(); break;
                    case (int)BuCA.Enum.RefType.BUBudgetReserve: // Dự toán giữ lại 
                        frmDetail = new FrmBUBudgetReserveDetail(); break;
                    case (int)BuCA.Enum.RefType.CAReceipt: // Phiếu thu 
                        frmDetail = new FrmCAReceiptDetail(); break;
                    case (int)BuCA.Enum.RefType.CAReceiptEstimate: // Phiếu thu từ ngân sách nhà nước
                        frmDetail = new FrmCAReceiptEstimateDetail(); break;
                    case (int)BuCA.Enum.RefType.CAPayment: // Phiếu chi 
                        frmDetail = new FrmCAPaymentDetail(); break;
                    case (int)BuCA.Enum.RefType.CAPaymentInventoryItem: // Phiếu chi mua vật tư hàng hóa
                        frmDetail = new FrmCAPaymentInwardDetail(); break;
                    case (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset: // Phiếu chi mua tài sản cố định
                        frmDetail = new FrmCAPaymentFixedAssetDetail(); break;
                    case (int)BuCA.Enum.RefType.CAPaymentTreasury: // Phiếu chi nộp tiền vào NH, KB
                        frmDetail = new FrmCAPaymentTreasuryDetail(); break;
                    case (int)BuCA.Enum.RefType.CAReceiptTreasury: // Phiếu thu rút tiền gửi NH, KB 
                        frmDetail = new FrmCAReceiptTreasuryDetail(); break;
                    case (int)BuCA.Enum.RefType.BADeposit: // Thu tiền gửi 
                        frmDetail = new FrmBADepositDetail(); break;
                    case (int)BuCA.Enum.RefType.BAWithDraw: // Chi tiền gửi 
                        frmDetail = new FrmBAWithDrawDetail(); break;
                    case (int)BuCA.Enum.RefType.BAWithDrawPurchase: // Chi tiền gửi mua vật tư hàng hóa
                        frmDetail = new FrmBAWithDrawPurchaseDetail(); break;
                    case (int)BuCA.Enum.RefType.BAWithDrawFixedAsset: // Chi tiền gửi mua tài sản cố định
                        frmDetail = new FrmCAPaymentFixedAssetDetail(); break;
                    case (int)BuCA.Enum.RefType.BABankTransfer: // Chuyển tiền nội bộ 
                        frmDetail = new FrmBABankTransferDetail(); break;
                    case (int)BuCA.Enum.RefType.INInward: // Nhập kho 
                        frmDetail = new FrmCAPaymentInwardDetail(); break;
                    case (int)BuCA.Enum.RefType.INOutward: // Xuất kho
                        frmDetail = new FrmINOutwardDetail(); break;
                    case (int)BuCA.Enum.RefType.SUIncrement: // Ghi tăng công cụ dụng cụ
                        frmDetail = new FrmSUIncrementDetail(); break;
                    case (int)BuCA.Enum.RefType.SUDecrement: // Ghi giảm công cụ dụng cụ 
                        frmDetail = new FrmSUDecrementDetail(); break;
                    case (int)BuCA.Enum.RefType.SUTransfer: // Điều chuyển công cụ dụng cụ 
                        frmDetail = new FrmSUTransferDetail(); break;
                    case (int)BuCA.Enum.RefType.FAIncrementDecrement: // Nhận bằng hiện vật và ghi tăng tài sản cố định 
                        frmDetail = new FrmCAPaymentFixedAssetDetail(); break;
                    case (int)BuCA.Enum.RefType.FADecrement: // Ghi giảm tài sản cố định
                        frmDetail = new FrmFADecrementDetail(); break;
                    case (int)BuCA.Enum.RefType.FADepreciation: // Hao mòn tài sản cố định 
                        frmDetail = new FrmFADepreciationDetail(); break;
                    case (int)BuCA.Enum.RefType.RevaluationOfFixedAsset: // Đánh giá lại tài sản cố định 
                        frmDetail = new FrmRevaluationOfFixedAssetDetail(); break;
                    case (int)BuCA.Enum.RefType.GLVoucher: // Chứng từ nghiệp vụ khác
                        frmDetail = new FrmGLVoucherDetail(); break;
                    case (int)BuCA.Enum.RefType.GLVoucherLastYear: // Kết chuyển số dư cuối năm 
                        frmDetail = new FrmGLVoucherLastYearDetail(); break;
                    case (int)BuCA.Enum.RefType.GLVoucherEarlyYear: // Quyết toán số dư đầu năm 
                        frmDetail = new FrmGLVouchersEarlyYearDetail(); break;
                    case (int)BuCA.Enum.RefType.GLVoucherPerformanceResults: // Xác định kết quả hoạt động
                        frmDetail = new FrmGLVouchersPerformanceResultsDetail(); break;
                    case (int)BuCA.Enum.RefType.GLVoucherList: // Chứng từ ghi sổ 
                        frmDetail = new FrmGLVoucherListDetail(); break;
                    case (int)BuCA.Enum.RefType.GLPaymentList: // Bảng phân bổ thanh toán tạm ứng 
                        frmDetail = new FrmGLPaymentListDetail(); break;
                    case (int)BuCA.Enum.RefType.FADevaluation: // Trích khấu hao tài sản cố định 
                        frmDetail = new FrmFADevaluationDetail(); break;
                    case (int)BuCA.Enum.RefType.BUTransferDeposits: // Chuyển khoản kho bạc vào TK tiền gửi
                        frmDetail = new FrmBUTransferDepositDetail(); break;
                    case (int)BuCA.Enum.RefType.BUPlanWithDrawDeposit: // Rút dự toán tiền gửi
                        frmDetail = new FrmBUPlanWithDrawDepositDetail(); break;
                    case (int)BuCA.Enum.RefType.BUPlanWithdrawTransferInsurrance: // Rút dự toán chuyển khoản lương, bảo hiểm 
                        frmDetail = new FrmBUPlanWithDrawTransferInsurranceDetail(); break;
                    case (int)BuCA.Enum.RefType.OpeningCommitment: // Cam kết chi ban đầu
                        frmDetail = new FrmOpeningCommitmentDetail(); break;
                    case (int)BuCA.Enum.RefType.PUInvoiceFixedAsset: // Số dư ban đầu
                        frmDetail = new FrmCAPaymentFixedAssetDetail(); break;
                    case (int)BuCA.Enum.RefType.OpeningInventoryEntry://Sửa số dư ban đầu kỳ tài khoản
                        LoadFrmOpeningAccountEntryDetail();
                        flag = false;
                        break;
                    case (int)BuCA.Enum.RefType.OpeningAccountEntry://Sửa số dư đầu kỳ tài khoản
                        LoadFrmOpeningAccountEntryDetail();
                        flag = false;
                        break;
                    case (int)BuCA.Enum.RefType.OpeningFixedAsset://Số dư đầu kì TSCĐ
                        LoadFrmOpeningFixedAsset();
                        flag = false;
                        break;

                }
                if (flag)
                {
                    frmDetail.ActionMode = ActionModeVoucherEnum.None;
                    frmDetail.KeyValue = objectFieldSearchId;
                    frmDetail.ShowDialog();
                }
            }
        }
        /// <summary>
        /// Load from FrmOpeningAccountEntryDetail
        /// </summary>
        private void LoadFrmOpeningAccountEntryDetail()
        {
            using (var frmDetail1 = new FrmOpeningAccountEntryDetail())
            {
                if (frmDetail1 != null)
                {
                    string _strAccountNumber;
                    var x = gridView.GetFocusedRowCellValue("DebitAccount");
                    if (x != null)
                    {
                        _strAccountNumber = x.ToString();
                    }
                    else
                    {
                        _strAccountNumber = gridView.GetFocusedRowCellValue("CreditAccount").ToString();
                    }
                    var data = Model.GetAccountbyAccountNumber(_strAccountNumber);
                    frmDetail1.KeyFieldName = "AccountId";
                    frmDetail1.ParentName = "ParentId";
                    frmDetail1.ActionMode = BuCA.Enum.ActionModeEnum.Edit;
                    frmDetail1.HelpTopicId = 138;
                    frmDetail1.KeyValue = data.AccountId;
                    frmDetail1.HasChildren = false;
                    if (frmDetail1.ShowDialog() == DialogResult.OK)
                    { }

                }
                btnSearch_Click(null, null);
            }
        }

        /// <summary>
        /// Load from FrmOpeningAccountEntryDetail
        /// </summary>
        private void LoadFrmOpeningFixedAsset()
        {
            using (var frmDetail1 = new FrmFixedAssetDetail())
            {
                if (frmDetail1 != null)
                {
                    var data = gridView.GetFocusedRowCellValue("FixedAssetCode").ToString();
                    frmDetail1.ActionMode = BuCA.Enum.ActionModeEnum.Edit;
                    frmDetail1.HelpTopicId = 123;
                    frmDetail1.SelectTabpage =1;
                    frmDetail1.KeyValue = data ?? null;
                    if (frmDetail1.ShowDialog() == DialogResult.OK)
                    { }

                }
                btnSearch_Click(null, null);
            }
        }
        /// <summary>
        /// Handles the DoubleClick event of the grdList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void grdList_DoubleClick(object sender, EventArgs e)
        {
            btnGoToVoucher_Click(sender, e);
        }

        /// <summary>
        /// Handles the CreateReportHeaderArea event of the printableComponentLink control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CreateAreaEventArgs"/> instance containing the event data.</param>
        private void printableComponentLink_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            const string reportHeader = "KẾT QUẢ TÌM KIẾM";
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Tahoma", 14, FontStyle.Bold);
            var rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
            e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
        }
        #endregion
    }

    #region Extension Class
    /// <summary>
    /// 
    /// </summary>
    public class ObjectFieldSearch
    {
        /// <summary>
        /// Gets or sets the object category identifier.
        /// </summary>
        /// <value>
        /// The object category identifier.
        /// </value>
        public string ObjectFieldSearchId { get; set; }

        /// <summary>
        /// Gets or sets the name of the object category.
        /// </summary>
        /// <value>
        /// The name of the object category.
        /// </value>
        public string ObjectFieldSearchName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFieldSearch" /> class.
        /// </summary>
        /// <param name="objectFieldSearchId">The object field search identifier.</param>
        /// <param name="objectFieldSearchName">Name of the object field search.</param>
        public ObjectFieldSearch(string objectFieldSearchId, string objectFieldSearchName)
        {
            ObjectFieldSearchId = objectFieldSearchId;
            ObjectFieldSearchName = objectFieldSearchName;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ObjectExpressionSearch
    {
        /// <summary>
        /// Gets or sets the object category identifier.
        /// </summary>
        /// <value>
        /// The object category identifier.
        /// </value>
        public string ObjectFieldSearchId { get; set; }

        /// <summary>
        /// Gets or sets the object category identifier.
        /// </summary>
        /// <value>
        /// The object category identifier.
        /// </value>
        public string ObjectFieldSearchName { get; set; }

        /// <summary>
        /// Gets or sets the name of the object category.
        /// </summary>
        /// <value>
        /// The name of the object category.
        /// </value>
        public string ObjectSearchValueId { get; set; }
        /// <summary>
        /// Gets or sets the name of the object category.
        /// </summary>
        /// <value>
        /// The name of the object category.
        /// </value>
        /// 
        public string ObjectSearchValueName { get; set; }

        /// <summary>
        /// Gets or sets the expression logic.
        /// </summary>
        /// <value>
        /// The expression logic.
        /// </value>
        public string ExpressionLogic { get; set; } //0: và 1: hoặc

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectExpressionSearch" /> class.
        /// </summary>
        /// <param name="objectFieldSearchId">The object field search identifier.</param>
        /// <param name="objectFieldSearchName">Name of the object field search.</param>
        /// <param name="objectSearchValueId">The object search value identifier.</param>
        /// <param name="objectSearchValueName">Name of the object search value.</param>
        /// <param name="expressionLogic">The expression logic.</param>
        public ObjectExpressionSearch(string objectFieldSearchId, string objectFieldSearchName, string objectSearchValueId, string objectSearchValueName, string expressionLogic)
        {
            ObjectFieldSearchId = objectFieldSearchId;
            ObjectFieldSearchName = objectFieldSearchName;
            ObjectSearchValueId = objectSearchValueId;
            ObjectSearchValueName = objectSearchValueName;
            ExpressionLogic = expressionLogic;
        }

    }
    #endregion
}