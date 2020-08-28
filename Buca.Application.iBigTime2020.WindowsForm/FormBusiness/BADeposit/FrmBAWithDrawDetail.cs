// ***********************************************************************
// Assembly         : A-BIGTIME2018
// Author           : thangnd
// Created          : 10-23-2017
//
// Last Modified By : thangnd
// Last Modified On : 11-02-2018
// ***********************************************************************
// <copyright file="FrmBAWithDrawDetail.cs" company="BuCA JSC">
//     Copyright © BuCA JSC
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Deposit;
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
using Buca.Application.iBigTime2020.View.Deposit;
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
using Buca.Application.iBigTime2020.Model.DataTransferObjectMapper;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using DevExpress.XtraBars;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee;
using Buca.Application.iBigTime2020.WindowsForm.FormSystem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusiness;
using Buca.Application.iBigTime2020.Model;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Drawing;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BADeposit
{
    public partial class FrmBAWithDrawDetail : FrmXtraBaseVoucherDetail, IBAWithDrawView, IAccountingObjectsView, IBudgetSourcesView, IAccountsView,
        IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, ICashWithdrawTypesView, IBanksView, IActivitysView, IProjectsView, IFundStructuresView, IPurchasePurposesView, IBudgetExpensesView
        , IInvoiceFormNumbersView, IContractsView, ICapitalPlansView, IAutoBusinessesView
    {
        #region Tài khoản ngầm định
        /// <summary>
        /// Tài khoản nợ ngầm định
        /// </summary>
        AccountModel _defaultDebitAccount;

        /// <summary>
        /// Tài khoản có ngầm định
        /// </summary>
        AccountModel _defaultCreditAccount;

        #region Liên kết
        /// <summary>
        /// Reference FrmBUTransferDepositDetail
        /// </summary>
        public List<BAWithDrawDetailModel> ListSendSourceDetail;
        public bool IsOpenFromBUPlanWithDrawDepositDetail;
        public BAWithDrawModel bAWithdrawModel;
        List<AccountModel> _listAccounts;
        #endregion
        #endregion

        private List<BudgetItemModel> _budgetItemModels;
        private IList<AccountModel> _accountModels;
        private IList<BudgetItemModel> _budgetSubItemModels;
        private List<ContractModel> _contractModels;
        private readonly IModel _model;

        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpEditAutoBusines;
        private GridView _gridLookUpEditAutoBusinesView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        private GridView _gridLookUpEditContractView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCapitalPlan;
        private GridView _gridLookUpEditCapitalPlanView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditTaxRate;
        private GridView _gridLookUpEditTaxRateView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditInvoiceFormNumber;
        private GridView _gridLookUpEditInvoiceFormNumberView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSourceParallel;
        private GridView _gridLookUpEditBudgetSourceParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCreditAccount;
        private GridView _gridLookUpEditCreditAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountParallel;
        private GridView _gridLookUpEditAccountParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        private GridView _gridLookUpEditBudgetChapterView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapterParallel;
        private GridView _gridLookUpEditBudgetChapterParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        private GridView _gridLookUpEditBudgetSubKindItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItemParallel;
        private GridView _gridLookUpEditBudgetSubKindItemParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private GridView _gridLookUpEditBudgetItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItemParallel;
        private GridView _gridLookUpEditBudgetItemParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        private GridView _gridLookUpEditBudgetSubItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItemParallel;
        private GridView _gridLookUpEditBudgetSubItemParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;
        private GridView _gridLookUpEditCashWithdrawTypeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawTypeParallel;
        private GridView _gridLookUpEditCashWithdrawTypeParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        private GridView _gridLookUpEditAccountingObjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructureParallel;
        private GridView _gridLookUpEditFundStructureParallelView;

        private List<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetKindItemModel> _budgetSubKindItemModels;
        private List<BudgetSourceModel> _budgetSourceModels;

        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        private RepositoryItemGridLookUpEdit _gridLookUpEditPurchasePurpose;
        private GridView _gridLookUpEditPurchasePurposeView;
        private RepositoryItemLookUpEdit _repositoryInvType;

        IModel model = new Model.Model();

        #endregion

        #region Presenter

        private readonly ContractsPresenter _contractsPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;
        private readonly BudgetExpensesPresenter _budgetExpensePresenter;

        private readonly InvoiceFormNumbersPresenter _invoiceFormNumbersPresenter;
        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        /// <summary>
        /// The b a deposit presenter
        /// </summary>
        private readonly BAWithDrawPresenter _bAWithDrawPresenter;
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
        /// The fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        private readonly PurchasePurposesPresenter _purchasePurposesPresenter;
        private readonly AutoBusinessesPresenter _autoBusinessPresenter;

        #endregion
        public List<SelectItemModel> Parallels { get; set; }
        public FrmBAWithDrawDetail()
        {
            InitializeComponent();
            _contractsPresenter = new ContractsPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _bAWithDrawPresenter = new BAWithDrawPresenter(this);
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
            _invoiceFormNumbersPresenter = new InvoiceFormNumbersPresenter(this);
            _budgetExpensePresenter = new BudgetExpensesPresenter(this);
            _autoBusinessPresenter = new AutoBusinessesPresenter(this);
            // Tab thuế chung source với các tab khác
            grdTax.DataSource = bindingSourceDetail;
            this.barLargeButtonUtility.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.barButtonSalary.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //AutoBankId = BankId;
            AutoAccountingObjectId = AccountingObjectId;
            _model = new Model.Model();
            grdViewParallel = grdViewAccountingParallel;

        }
        private void FrmBAWithDrawDetail_Load(object sender, EventArgs e)
        {
            if (ActionMode == ActionModeVoucherEnum.AddNew) ClickSomePoint();

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
        #region--Check validate form detail
        private void GrdAccountingView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            InitDetailRow(e, grdAccountingView);
        }
        #endregion

        #region IBAWithDrawView

        public string RefId { get; set; }
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
        public string AccountingObjectBankAccount
        {
            get { return cboAccountingBankId.EditValue == null ? null : cboAccountingBankId.EditValue.ToString(); }
            set { cboAccountingBankId.EditValue = value; }
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
        public string ParalellRefNo { get; set; }
        public string InwardRefNo { get; set; }
        public string IncrementRefNo { get; set; }
        public string BankId
        {
            get { return cboBankId.EditValue == null ? null : cboBankId.EditValue.ToString(); }
            set
            {
                cboBankId.EditValue = value;
                AutoBankId = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>The name of the bank.</value>
        public string BankName
        {
            get { return string.IsNullOrEmpty(txtBankName.Text) ? null : txtBankName.Text.Trim(); }
            set { txtBankName.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo
        {
            get { return string.IsNullOrEmpty(txtJournalMemo.Text) ? null : txtJournalMemo.Text.Trim(); }
            set { txtJournalMemo.Text = value; }
        }


        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId
        {
            get { return cboObjectCode.EditValue == null ? null : cboObjectCode.EditValue.ToString(); }
            set
            {
                cboObjectCode.EditValue = value;
                if (cboObjectCode.EditValue != null)
                {
                    var address = (string)cboObjectCode.GetColumnValue("Address");
                    txtAddress.Text = address;
                }
            }
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
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalFreightAmount { get; set; }
        public decimal TotalInwardAmount { get; set; }
        public bool? Reconciled { get; set; }
        public bool Posted { get; set; }
        public int? PostVersion { get; set; }
        public int? EditVersion { get; set; }
        public int? RefOrder { get; set; }
        public string RelationRefId { get; set; }
        public int RelationType { get; set; }
        public decimal TotalPaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets the ba with draw details.
        /// </summary>
        /// <value>The ba with draw details.</value>
        public IList<BAWithDrawDetailModel> BAWithDrawDetails
        {
            get
            {
                // grdAccounting.RefreshDataSource();
                var bAWithDrawDetails = new List<BAWithDrawDetailModel>();
                if (grdAccounting.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BAWithDrawDetailModel)grdAccountingView.GetRow(i);
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
                            var item = new BAWithDrawDetailModel
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
                                BankId = rowVoucher.BankId,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                                SortOrder = i,
                                OrgRefNo = rowVoucher.OrgRefNo,
                                OrgRefDate = rowVoucher.OrgRefDate,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ProjectId = rowVoucher.ProjectId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                FundStructureId = rowVoucher.FundStructureId,
                                ActivityId = rowVoucher.ActivityId,
                            };
                            bAWithDrawDetails.Add(item);
                        }
                    }
                }

                if (bAWithDrawDetails.Count > 0)
                {
                    if (grdAccountingDetail.DataSource != null && grdAccountingDetailView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingDetailView.RowCount; i++)
                        {
                            var rowVoucher = (BAWithDrawDetailModel)grdAccountingDetailView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                bAWithDrawDetails[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                                bAWithDrawDetails[i].ActivityId = rowVoucher.ActivityId;
                                bAWithDrawDetails[i].ProjectId = rowVoucher.ProjectId;
                                bAWithDrawDetails[i].FundStructureId = rowVoucher.FundStructureId;
                                bAWithDrawDetails[i].BudgetExpenseId = rowVoucher.BudgetExpenseId;
                            }
                        }
                    }
                }

                return bAWithDrawDetails;
            }
            set
            {
                if (IsOpenFromBUPlanWithDrawDepositDetail)
                {
                    value = ListSendSourceDetail;
                    ListSendSourceDetail = null;
                }
                var data = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BAWithDrawDetailModel>();
                bindingSourceDetail.DataSource = data;
                grdAccountingView.PopulateColumns(data);
                grdAccountingDetailView.PopulateColumns(data);

                #region columns for grdAccountingView
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AutoBusinessId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditAutoBusines,
                        ColumnWith = 200,
                        ColumnCaption = "ĐK tự động",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 80,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCreditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 4,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 5,
                        IsSummnary = true,
                        AllowEdit = true,
                        SummaryType = SummaryItemType.Sum,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 6,
                        IsSummnary = true,
                        AllowEdit = true,
                        SummaryType = SummaryItemType.Sum,
                        ColumnType = UnboundColumnType.Decimal
                    },

                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 120,
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
                    new XtraColumn
                    {
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
                    new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Mục",
                        ColumnPosition =112,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 113,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = true,
                        ColumnWith = 220,
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
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditAccountingObject,
                        ColumnWith = 130,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 116,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithDrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Tài khoản NH, KB",
                        ColumnPosition = 118,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },

                     new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 119,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                      new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 150,
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
                        ColumnPosition = 121,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.DateTime,
                        DisplayFormat = "dd-mm-yyyy",
                    },
                };

                XtraColumnCollectionHelper<BAWithDrawDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdAccountingView);
                grdAccountingView.OptionsView.ShowFooter = false;

                bool visibale = (CurrencyCode != "VND");
                grdAccountingView.Columns["Amount"].Visible = visibale;

                #endregion

                #region columns for grdAccountingDetailView

                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false
                    },

                    new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Ngân hàng",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },

                };

                XtraColumnCollectionHelper<BAWithDrawDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdAccountingDetailView);
                grdAccountingDetailView.OptionsView.ShowFooter = false;
                #endregion
            }
        }

        public IList<BAWithDrawDetailFixedAssetModel> BAWithDrawDetailFixedAssets { get; set; }

        public IList<BAWithDrawDetailPurchaseModel> BAWithDrawDetailPurchases { get; set; }

        public IList<BAWithdrawDetailSalaryModel> BAWithdrawDetailSalarys { get; set; }

        /// <summary>
        /// Gets or sets the ba withdraw detail taxs.
        /// </summary>
        /// <value>The ba withdraw detail taxs.</value>
        public IList<BAWithdrawDetailTaxModel> BAWithdrawDetailTaxs
        {
            get
            {
                //var source = (List<GLVoucherDetailModel>)bindingSourceDetail.DataSource;

                //return source.Select(m => Mapper.AutoMapper(m, new GLVoucherDetailTaxModel())).ToList();
                var baWithDrawDetailTaxes = new List<BAWithdrawDetailTaxModel>();
                if (grdTaxView.DataSource != null && grdTaxView.RowCount > 0)
                {
                    #region kiennt
                    for (var i = 0; i < grdTaxView.RowCount; i++)
                    {
                        var rowVoucher = (BAWithDrawDetailModel)grdTaxView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var item = new BAWithDrawDetailModel
                            {
                                Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                                VATAmount = rowVoucher.VATAmount,
                                VATRate = rowVoucher.VATRate,
                                TurnOver = rowVoucher.TurnOver,
                                InvType = rowVoucher.InvType,
                                InvDate = rowVoucher.InvDate,
                                InvNo = rowVoucher.InvNo == null ? null : rowVoucher.InvNo.Trim(),
                                PurchasePurposeId = rowVoucher.PurchasePurposeId,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                CompanyTaxCode = rowVoucher.CompanyTaxCode == null ? null : rowVoucher.CompanyTaxCode.Trim(),
                                InvoiceTypeCode = rowVoucher.InvoiceTypeCode == null ? null : rowVoucher.InvoiceTypeCode.Trim(),
                                SortOrder = i
                            };
                            baWithDrawDetailTaxes.Add(item);
                        }
                    }
                    #endregion

                }


                return baWithDrawDetailTaxes;

            }


            set
            {
                if (value == null)
                    value = new List<BAWithdrawDetailTaxModel>();
                //bindingSourceDetail.DataSource = value;
                var data = value.OrderBy(c => c.SortOrder).ToList();
                var source = (List<BAWithDrawDetailModel>)bindingSourceDetail.DataSource;
                for (int i = 0; i < data.Count; i++)
                {
                    Mapper.AutoMapper(data[i], source[i]);
                }
                grdTax.ForceInitialize();
                #region columns for grdAccountingView
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnVisible = true,
                    ColumnWith = 220,
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 1,
                    AllowEdit = true,
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VATAmount",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Tiền thuế",
                    ColumnPosition = 2,
                    IsSummnary = true,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VATRate",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Thuế suất",
                    ColumnPosition = 3,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditTaxRate
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TurnOver",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Giá tính thuế",
                    ColumnPosition = 4,
                    IsSummnary = true,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InvType",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Loại hóa đơn",
                    ColumnPosition = 5,
                    AllowEdit = true,
                    RepositoryControl = _repositoryInvType
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InvoiceTypeCode",
                    ColumnVisible = true,
                    ColumnWith = 250,
                    ColumnCaption = "Mẫu số HĐ",
                    ColumnPosition = 6,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditInvoiceFormNumber
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InvDate",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Ngày hóa đơn",
                    ColumnPosition = 7,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.DateTime
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InvSeries",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Ký hiệu HĐ",
                    ColumnPosition = 8,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InvNo",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Số hóa đơn",
                    ColumnPosition = 9,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PurchasePurposeId",
                    ColumnVisible = true,
                    ColumnWith = 200,
                    ColumnCaption = "Nhóm HHDV",
                    ColumnPosition = 10,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditPurchasePurpose
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectId",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Đối tượng",
                    ColumnPosition = 11,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditAccountingObject
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectName",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Đối tượng khác",
                    ColumnPosition = 12,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectAddress",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Địa chỉ",
                    ColumnPosition = 13,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CompanyTaxCode",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Mã số thuế",
                    ColumnPosition = 14,
                    AllowEdit = true
                });



                XtraColumnCollectionHelper<BAWithDrawDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdTaxView);
                //grdTaxView.InitGridLayout(columnsCollection);
                //SetNumericFormatControl(grdTaxView, true);
                grdTaxView.OptionsView.ShowFooter = false;
                #endregion
            }
        }

        /// <summary>
        /// Gets or sets the ba with draw detail parallels.
        /// </summary>
        /// <value>The ba with draw detail parallels.</value>
        public IList<BAWithDrawDetailParallelModel> BAWithDrawDetailParallels
        {
            get
            {
                grdAccountingParallel.RefreshDataSource();
                var withDrawDetailParallels = new List<BAWithDrawDetailParallelModel>();
                if (grdViewAccountingParallel.DataSource != null && grdViewAccountingParallel.RowCount > 0)
                {
                    for (var i = 0; i < grdViewAccountingParallel.RowCount; i++)
                    {
                        var rowVoucher = (BAWithDrawDetailParallelModel)grdViewAccountingParallel.GetRow(i);
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
                            var item = new BAWithDrawDetailParallelModel()
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
                bindingSourceDetailParallel.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BAWithDrawDetailParallelModel>();
                grdViewAccountingParallel.PopulateColumns(value);

                #region columns for grdViewAccountingParallel

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AutoBusinessId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditAutoBusines,
                        ColumnWith = 200,
                        ColumnCaption = "ĐK tự động",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 80,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCreditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 4,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 5,
                        IsSummnary = true,
                        AllowEdit = true,
                        SummaryType = SummaryItemType.Sum,
                        ColumnType = UnboundColumnType.Decimal
                    },
                     new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 6,
                        IsSummnary = true,
                        AllowEdit = true,
                        SummaryType = SummaryItemType.Sum,
                        ColumnType = UnboundColumnType.Decimal
                    },

                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 17,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSourceParallel
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
                        RepositoryControl = _gridLookUpEditBudgetChapterParallel
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 110,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItemParallel
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 111,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItemParallel
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Mục",
                        ColumnPosition =112,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItemParallel
                    },
                    new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 113,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructureParallel
                    },
                      new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = true,
                        ColumnWith = 220,
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
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditAccountingObject,
                        ColumnWith = 130,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 116,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithDrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawTypeParallel
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Tài khoản NH, KB",
                        ColumnPosition = 118,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },

                    new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 119,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                      new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 150,
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
                        ColumnPosition = 121,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.DateTime,
                        DisplayFormat = "dd-mm-yyyy",
                    },
                };

                //grdViewAccountingParallel.InitGridLayout(columnsCollection);
                //SetNumericFormatControl(grdViewAccountingParallel, true);
                //grdViewAccountingParallel.OptionsView.ShowFooter = false;
                XtraColumnCollectionHelper<BAWithDrawDetailParallelModel>.ShowXtraColumnInGridView(columnsCollection, grdViewAccountingParallel);
                SetNumericFormatControl(grdViewAccountingParallel, true);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;
                bool visibale = (CurrencyCode != "VND");
                grdViewAccountingParallel.Columns["Amount"].Visible = visibale;
                #endregion
            }
        }

        #endregion

        #region overrides

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Location = new Point(7, 290);
            tabMain.Location = new Point(7, 352);
            //tabMain.Size = new System.Drawing.Size(1015, 214);
            //xtraTabControl1.Location = new System.Drawing.Point(9, 650);
            tabMain.SelectedTabPage = tabAccounting;
            //Tintv ẩn tab Thốn kế và thuế
            tabMain.TabPages[4].PageVisible = false;
            tabMain.TabPages[3].PageVisible = false;
            //panel1.Location = new Point(7, 660);
            //panel1.Size = new System.Drawing.Size(976, 175);
            //grdTax.DataSource = bindingSourceDetail;
            grdAccountingParallel.DataSource = bindingSourceDetailParallel;
            cboBankId.Focus();

        }
        /// <summary>
        /// Enable Control.
        /// </summary>
        protected override void EnableControl()
        {
            ClickSomePoint(); // event gia click chuot vao vi tri nao do
            cboBankId.Enabled = true;
            cboAccountingBankId.Enabled = true;
            cboObjectCode.Enabled = true;
        }
        /// <summary>
        /// Refresh Navigation Button
        /// </summary>
        protected override void RefreshNavigationButton()
        {
            base.RefreshNavigationButton();
            cboBankId.Enabled = false;
            cboAccountingBankId.Enabled = false;
            cboObjectCode.Enabled = false;
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
            _invoiceFormNumbersPresenter.Display();
            _budgetExpensePresenter.DisplayActive();
            _autoBusinessPresenter.DisplayActive();
            InitRepositoryControlData();
            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                cboAccountingBankId.EditValue = null;
                txtAccountingObjectBankName.EditValue = null;
                txtReceiveName.EditValue = null;
                txtReceiveId.EditValue = null;
                txtReceiveIssueDate.EditValue = null;
                txtReceiveIssueLocation.EditValue = null;
                KeyValue = ((BAWithDrawModel)MasterBindingSource.Current).RefId;
            }
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((BAWithDrawModel)MasterBindingSource.Current).RefId;
            }

            _bAWithDrawPresenter.Display(KeyValue, true, false, false, false, true);
            //_accountingObjectPresenter.Display(this.AccountingObjectBankAccount);

            if (IsOpenFromBUPlanWithDrawDepositDetail && bAWithdrawModel != null)
            {
                IsOpenFromBUPlanWithDrawDepositDetail = false;
                AccountingObjectId = bAWithdrawModel.AccountingObjectId;
                JournalMemo = bAWithdrawModel.JournalMemo;
                BasePostedDate = bAWithdrawModel.PostedDate;
                CurrencyCode = bAWithdrawModel.CurrencyCode;
                ExchangeRate = bAWithdrawModel.ExchangeRate;
                TotalAmount = bAWithdrawModel.TotalAmount;
                TotalAmountOC = bAWithdrawModel.TotalAmountOC;
                BankId = bAWithdrawModel.BankId;
                RelationRefId = bAWithdrawModel.RelationRefId;
                RelationType = bAWithdrawModel.RelationType;
            }
            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.BAWithDraw;
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
            grdAccountingDetailView.CloseEditor();
            grdTaxView.CloseEditor();
            grdDetailByInventoryItemView.CloseEditor();

            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");

            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            var bAWithDrawDetails = BAWithDrawDetails;
            if (bAWithDrawDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (BAWithDrawDetails.Count > 0)
            {
                for (int i = 0; i < BAWithDrawDetails.Count; i++)
                {
                    var butranferDetail = BAWithDrawDetails[i];
                    var debitAccount = _listAccounts.FirstOrDefault(c => c.AccountNumber == butranferDetail.DebitAccount);
                    var creditAccount = _listAccounts.FirstOrDefault(c => c.AccountNumber == butranferDetail.CreditAccount);
                    if (BAWithDrawDetails[i].DebitAccount == null || debitAccount == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDebitAccount"),
                                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (BAWithDrawDetails[i].CreditAccount == null || creditAccount == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherAccountNumberEmpty"),
                                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        return false;
                    }
                    if (BAWithDrawDetails[i].BankId == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherBankEmpty"),
                                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        return false;
                    }

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
                if (_defaultDebitAccount != null)
                    view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount?.AccountNumber);
                if (_defaultCreditAccount != null)
                    view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount?.AccountNumber);
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

            var result = new DialogResult();
            if (BAWithDrawDetailParallels.Count > 0)
            {
                result = XtraMessageBox.Show("Bạn có muốn cập nhật lại định khoản đồng thời không?", "Định khoản đồng thời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                result = XtraMessageBox.Show("Bạn có muốn sinh tự động định khoản đồng thời không?", "Định khoản đồng thời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            return result == DialogResult.OK ? _bAWithDrawPresenter.Save(true) : _bAWithDrawPresenter.Save(false);
            //return _bAWithDrawPresenter.Save();
        }

        /// <summary>
        /// Reloads the parallel grid.
        /// </summary>
        protected override void ReloadParallelGrid()
        {
            _bAWithDrawPresenter.Display(KeyValue, true, false, false, false, true);
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            EnableControlsInGroup(groupboxMain, isEnable);
            grdViewAccountingParallel.OptionsBehavior.Editable = isEnable;
            grdViewAccountingParallel.OptionsBehavior.ReadOnly = !isEnable;
            grdViewAccountingParallel.FocusRectStyle = DrawFocusRectStyle.None;
            grdViewAccountingParallel.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdViewAccountingParallel.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
            cboBankId.Enabled = isEnable;
            cboAccountingBankId.Enabled = isEnable;
            cboObjectCode.Enabled = isEnable;
        }
        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "BudgetSubItemCode")
                {
                    var budgetSubItemCode = grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode") == null ? null : (string)grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                    var budgetSubItem = _budgetSubItemModels.FirstOrDefault(x => x.BudgetItemCode == budgetSubItemCode);
                    if (budgetSubItem != null)
                    {
                        var budgetItem = _budgetItemModels.FirstOrDefault(x => x.BudgetItemId == budgetSubItem.ParentId);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItem == null ? "" : budgetItem.BudgetItemCode);
                    }
                }
                if (e.Column.FieldName == "ProjectId")
                {
                    var project = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "ProjectId");
                    var contracts = _contractModels.Where(x => x.ProjectId == project).ToList();
                    if (contracts == null || contracts.Count == 0) _gridLookUpEditContract.DataSource = _contractModels.ToList();
                    else
                    {
                        _gridLookUpEditContract.DataSource = contracts;

                    }


                }
                if (e.Column.FieldName == "AutoBusinessId")
                {
                    var autoBusinessId = grdAccountingView.GetRowCellValue(e.RowHandle, "AutoBusinessId") == null ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "AutoBusinessId").ToString();
                    if (autoBusinessId != string.Empty)
                    {
                        var autoBusiness = (AutoBusinessModel)_gridLookUpEditAutoBusines.GetRowByKeyValue(autoBusinessId);
                        if (autoBusiness != null)
                        {
                            if (autoBusiness.BudgetSourceId == "00000000-0000-0000-0000-000000000000") grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSourceId", null);
                            else
                                grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSourceId", autoBusiness.BudgetSourceId);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "DebitAccount", autoBusiness.DebitAccount);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "CreditAccount", autoBusiness.CreditAccount);
                            grdAccountingView.SetRowCellValue(e.RowHandle, "Description", autoBusiness.AutoBusinessName);
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
                if (e.Column.FieldName == "Description")
                {
                    //dong nay gay loi dinh khoan tu dong
                    // grdAccounting.RefreshDataSource();
                    var bAWithdrawDetailTaxs = BAWithdrawDetailTaxs;
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var description = grdAccountingView.GetRowCellValue(i, "Description") == null ? "" : grdAccountingView.GetRowCellValue(i, "Description").ToString();
                        if (!string.IsNullOrEmpty(description))
                        {
                            if (bAWithdrawDetailTaxs.Count == 0)
                            {
                                bAWithdrawDetailTaxs = new List<BAWithdrawDetailTaxModel>
                                {
                                    new BAWithdrawDetailTaxModel {Description = description}
                                };
                                BAWithdrawDetailTaxs = bAWithdrawDetailTaxs;
                            }
                            else
                            {
                                if (bAWithdrawDetailTaxs.Count == i)
                                {
                                    var bAWithdrawDetailTax = new BAWithdrawDetailTaxModel
                                    {
                                        Description = description
                                    };
                                    bAWithdrawDetailTaxs.Add(bAWithdrawDetailTax);
                                }
                                else
                                {
                                    bAWithdrawDetailTaxs[i].Description = description;
                                }
                            }
                            BAWithdrawDetailTaxs = bAWithdrawDetailTaxs;
                        }
                    }

                    if (grdAccountingView.IsFirstRow && (txtJournalMemo.EditValue == null || txtJournalMemo.EditValue.ToString() == ""))
                    {
                        txtJournalMemo.Text = grdAccountingView.GetRowCellValue(e.RowHandle, "Description").ToString();
                    }
                }
                GridView view = sender as GridView;
                if (view == null)
                    return;

                switch (e.Column.FieldName)
                {
                    case nameof(BAWithDrawDetailModel.AmountOC):
                        decimal turnOver = Convert.ToDecimal((e.Value ?? 0));
                        view.SetFocusedRowCellValue(nameof(BAWithDrawDetailModel.TurnOver), turnOver);

                        decimal vatRate = Convert.ToDecimal((view.GetFocusedRowCellValue(nameof(BAWithDrawDetailModel.VATRate)) ?? 0));
                        if (vatRate < 0)
                            vatRate = 0;

                        view.SetFocusedRowCellValue(nameof(BAWithDrawDetailModel.VATAmount), turnOver * vatRate / 100);
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Grids the tax cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridTaxCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view == null)
                    return;
                switch (e.Column.FieldName)
                {
                    case nameof(BAWithDrawDetailModel.VATRate):
                        decimal turnOver = Convert.ToDecimal((view.GetFocusedRowCellValue(nameof(BAWithDrawDetailModel.TurnOver)) ?? 0));

                        decimal vatRate = Convert.ToDecimal((e.Value ?? 0));
                        if (vatRate < 0)
                            vatRate = 0;

                        view.SetFocusedRowCellValue(nameof(BAWithDrawDetailModel.VATAmount), turnOver * vatRate / 100);
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void DeleteVoucher()
        {
            _bAWithDrawPresenter.Delete(KeyValue);
        }

        protected override void ShowVoucherList()
        {
            var frmReference = new FrmGLVoucherDetail();
            frmReference.ActionMode = ActionModeVoucherEnum.AddNew;
            frmReference.KeyValue = null;

            var _source = this.bindingSourceDetail.DataSource;
            var _listDetail = new List<BAWithDrawDetailModel>();
            if (_source != null)
                _listDetail = (List<BAWithDrawDetailModel>)_source;

            var _listDetailSend = _listDetail.Select(m => Mapper.AutoMapper(m, new GLVoucherDetailModel())).ToList();

            var _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(_listAccounts, (int)BuCA.Enum.RefType.GLVoucher, RefTypes.ToList());
            var _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(_listAccounts, (int)BuCA.Enum.RefType.GLVoucher, RefTypes.ToList());

            _listDetailSend = _listDetailSend.Select(m =>
            {
                //m.DebitAccount = _defaultDebitAccount?.AccountNumber;
                //m.CreditAccount = _defaultCreditAccount?.AccountNumber;
                m.CashWithDrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID;
                m.MethodDistributeId = GlobalVariable.DefaultMethodDistributeID;

                return m;
            }).ToList();

            frmReference.ListSendSourceDetail = _listDetailSend;
            frmReference.IsOpenFrmGLVoucherDetail = true;
            frmReference.IsPaymenInsurrance = true;
            // Thông tin master
            var item = new GLVoucherModel()
            {
                JournalMemo = JournalMemo,
                PostedDate = PostedDate,
                RefDate = RefDate,
                CurrencyCode = CurrencyCode,
                ExchangeRate = ExchangeRate,
                TotalAmount = TotalAmount,
                TotalAmountOC = TotalAmountOC,
            };
            frmReference.gLVoucherModel = item;

            frmReference.ShowDialog();
        }

        /// <summary>
        /// Hạch toán chi phí lương
        /// </summary>
        protected override void ShowFormUtility()
        {
            var frmReference = new FrmGLVoucherDetail();
            frmReference.ActionMode = ActionModeVoucherEnum.AddNew;
            frmReference.KeyValue = null;

            var _source = this.bindingSourceDetail.DataSource;
            var _listDetail = new List<BAWithDrawDetailModel>();
            if (_source != null)
                _listDetail = (List<BAWithDrawDetailModel>)_source;

            var _listDetailSend = _listDetail.Select(m => Mapper.AutoMapper(m, new GLVoucherDetailModel())).ToList();

            //var _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(_listAccounts, (int)BuCA.Enum.RefType.GLVoucher, RefTypes.ToList());
            //var _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(_listAccounts, (int)BuCA.Enum.RefType.GLVoucher, RefTypes.ToList());

            // Fix cứng tài khoản mặc định hạch toán chi phí lương
            var _debitAccounts = BusinessExtension.DebitAccounts(_listAccounts, (int)BuCA.Enum.RefType.GLVoucher, RefTypes.ToList());
            var _creditAccounts = BusinessExtension.CreditAccounts(_listAccounts, (int)BuCA.Enum.RefType.GLVoucher, RefTypes.ToList());
            if (_debitAccounts != null)
                _defaultDebitAccount = _debitAccounts.FirstOrDefault(m => m.AccountNumber.Equals(CommonText.AccountNumber61111));
            else
                _defaultDebitAccount = null;
            if (_creditAccounts != null)
                _defaultCreditAccount = _creditAccounts.FirstOrDefault(m => m.AccountNumber.Equals(CommonText.AccountNumber3341));
            else
                _defaultCreditAccount = null;

            _listDetailSend = _listDetailSend.Select(m =>
            {
                m.DebitAccount = _defaultDebitAccount?.AccountNumber;
                m.CreditAccount = _defaultCreditAccount?.AccountNumber;
                m.CashWithDrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID;
                m.MethodDistributeId = GlobalVariable.DefaultMethodDistributeID;

                return m;
            }).ToList();

            frmReference.ListSendSourceDetail = _listDetailSend;
            frmReference.IsOpenFrmGLVoucherDetail = true;

            // Thông tin master
            var item = new GLVoucherModel()
            {
                JournalMemo = JournalMemo,
                PostedDate = PostedDate,
                RefDate = RefDate,
                CurrencyCode = CurrencyCode,
                ExchangeRate = ExchangeRate,
                TotalAmount = TotalAmount,
                TotalAmountOC = TotalAmountOC,
            };
            frmReference.gLVoucherModel = item;

            frmReference.ShowDialog();
        }
        #endregion

        #region Control Events

        /// <summary>
        /// Handles the EditValueChanged event of the cboObjectCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void cboObjectCode_EditValueChanged(object sender, EventArgs e)
        {
            EvenChangeObjectCode();
            AccountingObjectBanks = cboObjectCode.EditValue != null ? model.GetProjectBank(cboObjectCode.EditValue.ToString()).ToList() : null;
            var banks = cboObjectCode.EditValue != null ? model.GetProjectBank(cboObjectCode.EditValue.ToString()).FirstOrDefault() : null;
            cboAccountingBankId.EditValue = banks == null ? null : banks.BankId;
            txtAccountingObjectBankName.EditValue = banks == null ? "" : banks.BankName;

            BAWithDrawDetails = BAWithDrawDetails;
        }
        void EvenChangeObjectCode()
        {
            if (cboObjectCode.EditValue == null)
                return;
            var accountName = (string)cboObjectCode.GetColumnValue("AccountingObjectName");
            var address = (string)cboObjectCode.GetColumnValue("Address");
            var accountId = cboObjectCode.EditValue;
            var accountingObject = _model.GetAccountingObject(AccountingObjectId) ?? new AccountingObjectModel();
            var bank = _model.GetProjectBank(accountId.ToString()).OrderByDescending(o => o.SortBank).FirstOrDefault();

            cboObjectName.Text = accountName;
            txtAddress.Text = address;

            for (int i = 0; i < grdAccountingView.RowCount; i++)
            {
                grdAccountingView.SetRowCellValue(i, "AccountingObjectId", AccountingObjectId);
                //if (bank != null)
                //{
                //    grdAccountingView.SetRowCellValue(i, "BankId", bank.BankId);
                //}
            }

            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoAccountingObjectId = AccountingObjectId;
                SetDetailFromMaster(grdAccountingView, 1, AccountingObjectId, BankId, null);
                grdAccountingView.SetRowCellValue(1, "AccountingObjectId", AutoAccountingObjectId);
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboBankId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboBankId_EditValueChanged(object sender, EventArgs e)
        {
            if (cboBankId.EditValue == null)
                return;
            var bankName = (string)cboBankId.GetColumnValue("BankName");
            txtBankName.Text = bankName;

            for (int i = 0; i < grdAccountingView.RowCount; i++)
            {
                grdAccountingView.SetRowCellValue(i, "BankId", BankId);
            }
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                SetDetailFromMaster(grdAccountingView, 2, AccountingObjectId, BankId, null);
                AutoBankId = BankId;
                grdAccountingView.SetRowCellValue(1, "BankId", AutoBankId);
            }
        }

        private void cboAccountingBankId_EditValueChanged(object sender, EventArgs e)
        {
            if (cboAccountingBankId.EditValue == null)
                return;
            else
            {
                var bank = model.GetBank(cboAccountingBankId.EditValue.ToString());
                txtAccountingObjectBankName.Text = bank == null ? null : bank.BankName;
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
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.BudgetSourceId), GlobalVariable.DefaultBudgetSourceID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.BudgetChapterCode), GlobalVariable.DefaultBudgetChapterCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.BudgetKindItemCode), GlobalVariable.DefaultBudgetKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.BudgetSubKindItemCode), GlobalVariable.DefaultBudgetSubKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.CashWithdrawTypeId), GlobalVariable.DefaultCashWithDrawTypeID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.MethodDistributeId), GlobalVariable.DefaultMethodDistributeID);
                SetDetailFromMaster(view, 0, AutoAccountingObjectId, BankId, AutoProjectId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

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

            // Thuế suất
            var vatRates = new Dictionary<int, string> { { 0, "0%" }, { 10, "10%" }, { 15, "15%" }, { -1, "KCT" } };  // Không chịu thế = -1 tương đương thuế suất = 0
            _gridLookUpEditTaxRateView = XtraColumnCollectionHelper<StockModel>.CreateGridViewReponsitory();
            _gridLookUpEditTaxRate = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditTaxRateView, vatRates.ToList(), "Value", "Key");
            _gridLookUpEditTaxRate.PopupFormSize = new Size(180, 150);
            var gridColumnsCollection = new List<XtraColumn>();
            gridColumnsCollection.Add(new XtraColumn { ColumnName = "Value", ColumnCaption = "Thuế suất", ColumnVisible = true, ColumnWith = 180, ColumnPosition = 1 });
            XtraColumnCollectionHelper<KeyValuePair<int, string>>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditTaxRateView);

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

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            bindingSourceDetail.ResetBindings(false);
        }
        #endregion

        #region IView
        #region Mẫu số hóa đơn
        public IList<InvoiceFormNumberModel> InvoiceFormNumbers
        {
            set
            {
                if (value == null)
                    value = new List<InvoiceFormNumberModel>();

                _gridLookUpEditInvoiceFormNumberView = XtraColumnCollectionHelper<InvoiceFormNumberModel>.CreateGridViewReponsitory();
                _gridLookUpEditInvoiceFormNumber = XtraColumnCollectionHelper<InvoiceFormNumberModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInvoiceFormNumberView, value, "InvoiceFormNumberName", "InvoiceFormNumberCode");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvoiceFormNumberCode", ColumnCaption = "Mẫu số", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvoiceFormNumberName", ColumnCaption = "Tên mẫu", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditInvoiceFormNumberView = XtraColumnCollectionHelper<InvoiceFormNumberModel>.CreateGridViewReponsitory();
                _gridLookUpEditInvoiceFormNumber = XtraColumnCollectionHelper<InvoiceFormNumberModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInvoiceFormNumberView, value, "InvoiceFormNumberCode", "InvoiceFormNumberId", gridColumnsCollection);
                XtraColumnCollectionHelper<InvoiceFormNumberModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInvoiceFormNumberView);

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

                    _budgetSourceModels = value.ToList();
                    var budgetSourceModels = value.Where(o => o.IsParent == false && o.IsActive == true).ToList();

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

                    _gridLookUpEditBudgetSource.DataSource = budgetSourceModels;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(budgetSourceModels);

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

                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, budgetSourceModels, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);

                    _gridLookUpEditBudgetSourceParallelView = new GridView();
                    _gridLookUpEditBudgetSourceParallelView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSourceParallel = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSourceParallelView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetSourceParallel.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSourceParallel.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSourceParallel.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSourceParallel.View.BestFitColumns();

                    _gridLookUpEditBudgetSourceParallel.DataSource = budgetSourceModels;
                    _gridLookUpEditBudgetSourceParallelView.PopulateColumns(budgetSourceModels);

                    _gridLookUpEditBudgetSourceParallelView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSourceParallel = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceParallelView, budgetSourceModels, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceParallelView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    if (value == null)
                        value = new List<AccountModel>();
                    _listAccounts = value.ToList();

                    _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(value.ToList(), (int)BaseRefTypeId, RefTypes.ToList());
                    _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(value.ToList(), (int)BaseRefTypeId, RefTypes.ToList());

                    _accountModels = value;

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
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
        public IList<BankModel> AccountingObjectBanks
        {

            get { return new List<BankModel>(); }
            set
            {
                if (value == null)
                    value = new List<BankModel>();
                cboAccountingBankId.Properties.DataSource = value;
                cboAccountingBankId.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "BankAccount",
                        ColumnCaption = "Số TK",
                        ColumnPosition = 0,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "BankName",
                        ColumnCaption = "Tên ngân hàng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 150
                    },
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankAddress", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsOpenInBank", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Used", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortBank", ColumnVisible = false},
                };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboAccountingBankId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboAccountingBankId.Properties.SortColumnIndex = column.ColumnPosition;
                        cboAccountingBankId.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        cboAccountingBankId.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                cboAccountingBankId.Properties.DisplayMember = "BankAccount";
                cboAccountingBankId.Properties.ValueMember = "BankId";
            }
        }
        #region BudgetChapters

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>
        /// The budget chapters.
        /// </value>
        /// 
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
                    };
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetChapter.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetChapter.View.BestFitColumns();
                    _gridLookUpEditBudgetChapter.DataSource = value;
                    _gridLookUpEditBudgetChapterView.PopulateColumns(value);


                    _gridLookUpEditBudgetChapterParallelView = new GridView();
                    _gridLookUpEditBudgetChapterParallelView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetChapterParallel = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetChapterParallelView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetChapterParallel.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetChapterParallel.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetChapterParallel.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetChapterParallel.View.BestFitColumns();
                    _gridLookUpEditBudgetChapterParallel.DataSource = value;
                    _gridLookUpEditBudgetChapterParallelView.PopulateColumns(value);

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

                            _gridLookUpEditBudgetChapterParallelView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetChapterParallelView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetChapterParallelView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                            _gridLookUpEditBudgetChapterParallelView.Columns[column.ColumnName].Visible = false;
                        }
                    }

                    _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);

                    _gridLookUpEditBudgetChapterParallelView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetChapterParallel = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterParallelView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterParallelView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        public IList<AutoBusinessModel> AutoBusinesses
        {
            set
            {
                try
                {
                    var data = value.Where(o => o.RefTypeId == (int)BuCA.Enum.RefType.BAWithDraw).ToList();
                    _gridLookUpEditAutoBusinesView = new GridView();
                    _gridLookUpEditAutoBusinesView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditAutoBusines = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditAutoBusinesView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditAutoBusines.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditAutoBusines.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditAutoBusines.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditAutoBusines.View.BestFitColumns();

                    _gridLookUpEditAutoBusines.DataSource = data;
                    _gridLookUpEditAutoBusinesView.PopulateColumns(data);

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

                    _gridLookUpEditAutoBusinesView = XtraColumnCollectionHelper<AutoBusinessModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAutoBusines = XtraColumnCollectionHelper<AutoBusinessModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAutoBusinesView, data, "AutoBusinessCode", "AutoBusinessId", gridColumnsCollection);
                    XtraColumnCollectionHelper<AutoBusinessModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAutoBusinesView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #region BudgetKindItems

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
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItem.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSubKindItem.View.BestFitColumns();
                    _gridLookUpEditBudgetSubKindItem.DataSource = _budgetSubKindItemModels;
                    _gridLookUpEditBudgetSubKindItemView.PopulateColumns(_budgetSubKindItemModels);


                    _gridLookUpEditBudgetSubKindItemParallelView = new GridView();
                    _gridLookUpEditBudgetSubKindItemParallelView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubKindItemParallel = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubKindItemParallelView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetSubKindItemParallel.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItemParallel.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItemParallel.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSubKindItemParallel.View.BestFitColumns();
                    _gridLookUpEditBudgetSubKindItemParallel.DataSource = _budgetSubKindItemModels;
                    _gridLookUpEditBudgetSubKindItemParallelView.PopulateColumns(_budgetSubKindItemModels);


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

                            _gridLookUpEditBudgetSubKindItemParallelView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetSubKindItemParallelView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetSubKindItemParallelView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Visible = false;
                            _gridLookUpEditBudgetSubKindItemParallelView.Columns[column.ColumnName].Visible = false;
                        }
                    }

                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, _budgetSubKindItemModels, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);

                    _gridLookUpEditBudgetSubKindItemParallelView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubKindItemParallel = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemParallelView, _budgetSubKindItemModels, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemParallelView);
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
        /// <value>
        /// The BudgetItems.
        /// </value>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                try
                {
                    _budgetItemModels = value.ToList();
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2 && v.IsActive == true).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3 && v.IsActive == true).ToList();
                    _budgetSubItemModels = budgetSubItemModels;

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

                    _gridLookUpEditBudgetItemParallelView = new GridView();
                    _gridLookUpEditBudgetItemParallelView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetItemParallel = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetItemParallelView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetItemParallel.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetItemParallel.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetItemParallel.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetItemParallel.View.BestFitColumns();
                    _gridLookUpEditBudgetItemParallel.DataSource = budgetItemModels;
                    _gridLookUpEditBudgetItemParallelView.PopulateColumns(budgetItemModels);

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

                            _gridLookUpEditBudgetItemParallelView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetItemParallelView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetItemParallelView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Visible = false;
                            _gridLookUpEditBudgetItemParallelView.Columns[column.ColumnName].Visible = false;
                        }
                    }

                    _gridLookUpEditBudgetItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemView, budgetItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetItemView);

                    _gridLookUpEditBudgetItemParallelView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetItemParallel = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemParallelView, budgetItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetItemParallelView);

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

                    _gridLookUpEditBudgetSubItemParallelView = new GridView();
                    _gridLookUpEditBudgetSubItemParallelView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubItemParallel = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubItemParallelView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetSubItemParallel.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubItemParallel.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubItemParallel.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSubItemParallel.View.BestFitColumns();
                    _gridLookUpEditBudgetSubItemParallel.DataSource = budgetSubItemModels;
                    _gridLookUpEditBudgetSubItemParallelView.PopulateColumns(budgetSubItemModels);

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

                    _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, budgetSubItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);

                    _gridLookUpEditBudgetSubItemParallelView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubItemParallel = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemParallelView, budgetSubItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemParallelView);

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


                    _gridLookUpEditCashWithdrawTypeParallelView = new GridView();
                    _gridLookUpEditCashWithdrawTypeParallelView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCashWithdrawTypeParallel = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCashWithdrawTypeParallelView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditCashWithdrawTypeParallel.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCashWithdrawTypeParallel.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCashWithdrawTypeParallel.PopupFormSize = new Size(268, 150);
                    _gridLookUpEditCashWithdrawTypeParallel.View.BestFitColumns();
                    _gridLookUpEditCashWithdrawTypeParallel.DataSource = value;
                    _gridLookUpEditCashWithdrawTypeParallelView.PopulateColumns(value);

                    _gridLookUpEditCashWithdrawTypeView = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCashWithdrawType = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCashWithdrawTypeView, value, "CashWithdrawTypeName", "CashWithdrawTypeId", gridColumnsCollection);
                    XtraColumnCollectionHelper<CashWithdrawTypeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCashWithdrawTypeView);

                    _gridLookUpEditCashWithdrawTypeParallelView = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCashWithdrawTypeParallel = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCashWithdrawTypeParallelView, value, "CashWithdrawTypeName", "CashWithdrawTypeId", gridColumnsCollection);
                    XtraColumnCollectionHelper<CashWithdrawTypeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCashWithdrawTypeParallelView);
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
        /// <value>
        /// The banks.
        /// </value>
        public IList<BankModel> Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();

                cboBankId.Properties.DataSource = value;
                cboBankId.Properties.PopulateColumns();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInLookUpEdit(gridColumnsCollection, cboBankId);

                cboBankId.Properties.DisplayMember = "BankAccount";
                cboBankId.Properties.ValueMember = "BankId";

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        #endregion

        #region AccountingObjects
        protected override void LkAccountingObjectCategory_EditValueChanged(object sender, EventArgs e)
        {
            _accountingObjectsPresenter.DisplayActive(true);
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
                    new XtraColumn { ColumnName = "AccountingObjectBanks", ColumnVisible = false },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 100,
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
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false },
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

                string _accountingObjectCategoryID = null;
                if (lkAccountingObjectCategory.EditValue != null)
                {
                    if (lkAccountingObjectCategory.EditValue.ToString() != Guid.Empty.ToString())
                    {
                        _accountingObjectCategoryID = lkAccountingObjectCategory.EditValue.ToString();
                    }
                }
                //HungNT tam thoi bo dieu kien loai
                //var data = value.Where(o => string.Equals(o.AccountingObjectCategoryId, _accountingObjectCategoryID)).ToList();
                var data = value;
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
                _gridLookUpEditAccountingObject.DataSource = data;
                _gridLookUpEditAccountingObjectView.PopulateColumns(data);

                _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, data, "AccountingObjectCode", "AccountingObjectId", columnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(columnsCollection, _gridLookUpEditAccountingObjectView);

                #endregion
            }
        }

        #endregion

        #region Activitys
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
        /// <value>
        /// The projects.
        /// </value>
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
        /// <value>
        /// The fund structures.
        /// </value>
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
                    };
                    _gridLookUpEditFundStructure.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFundStructure.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFundStructure.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditFundStructure.View.BestFitColumns();
                    _gridLookUpEditFundStructure.DataSource = data;
                    _gridLookUpEditFundStructureView.PopulateColumns(data);

                    _gridLookUpEditFundStructureParallelView = new GridView();
                    _gridLookUpEditFundStructureParallelView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFundStructureParallel = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFundStructureParallelView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditFundStructureParallel.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFundStructureParallel.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFundStructureParallel.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditFundStructureParallel.View.BestFitColumns();
                    _gridLookUpEditFundStructureParallel.DataSource = data;
                    _gridLookUpEditFundStructureParallelView.PopulateColumns(data);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeId", ColumnVisible = false });
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentPeriod", ColumnVisible = false });

                    _gridLookUpEditFundStructureView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();
                    _gridLookUpEditFundStructure = XtraColumnCollectionHelper<FundStructureModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, data, "FundStructureCode", "FundStructureId", gridColumnsCollection);
                    XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);

                    _gridLookUpEditFundStructureParallelView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();
                    _gridLookUpEditFundStructureParallel = XtraColumnCollectionHelper<FundStructureModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureParallelView, data, "FundStructureCode", "FundStructureId", gridColumnsCollection);
                    XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureParallelView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region IView PurchasePurposes

        /// <summary>
        /// Gets the purchase purposes.
        /// </summary>
        /// <value>
        /// The purchase purposes.
        /// </value>
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

                    _gridLookUpEditBudgetExpenseView = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, "BudgetExpenseName", "BudgetExpenseId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetExpenseModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetExpenseView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        public string ReceiveName
        {
            get { return txtReceiveName.EditValue?.ToString(); }
            set
            {
                txtReceiveName.EditValue = value;
            }
        }
        public string ReceiveId
        {
            get { return txtReceiveId.EditValue?.ToString(); }
            set { txtReceiveId.EditValue = value; }
        }
        public DateTime? ReceiveIssueDate
        {
            get
            {
                if (!string.IsNullOrEmpty(txtReceiveIssueDate.Text))
                    return Convert.ToDateTime(txtReceiveIssueDate.EditValue);
                else
                    return null;
            }
            set { txtReceiveIssueDate.EditValue = value; }
        }

        public string ReceiveIssueLocation { get { return txtReceiveIssueLocation.EditValue?.ToString(); } set { txtReceiveIssueLocation.EditValue = value; } }

        #endregion

        #endregion

        #region Event control

        /// <summary>
        /// Handles the BeforePopup event of the popupUtility control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void popupUtility_BeforePopup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            popupUtility.ItemLinks[2].Item.Visibility = BarItemVisibility.Never;
        }

        private void FrmBAWithDrawDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(panel1, true, true);
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
                if (isGrdMaster == true)
                {
                    grMasterHeigh = grdMaster.Height;
                    // grdMaster.Location = new Point(6, yMaster);
                    ytabMain = yMaster + grMasterHeigh + 7;
                    grdLayoutHeight = formHeight - yMaster - grMasterHeigh - 7;

                    tabMainHeight = ((grdLayoutHeight / 10) * 6);
                    tabMainWith = tabMain.Width;
                    tabMain.Size = new Size(tabMainWith, (formHeight - 380) / 2);
                    // tabMain.Location = new Point(6, ytabMain);

                    ypanel1 = ytabMain + tabMainHeight + 15;
                    panel1Height = grdLayoutHeight - tabMainHeight;
                    panel1.Height = panel1Height;
                    panel1.Location = new Point(6, ypanel1);
                    panel1.Size = new Size(tabMainWith, ((formHeight - 380) / 2) - 35);
                }

                else

                {
                    //grMasterHeigh = grdMaster.Height;
                    //grdMaster.Location = new Point(6, yMaster);
                    ytabMain = yMaster + grMasterHeigh + 7;
                    grdLayoutHeight = formHeight - yMaster - grMasterHeigh - 7;

                    tabMainHeight = ((grdLayoutHeight / 10) * 6);
                    tabMainWith = tabMain.Width;
                    tabMain.Size = new Size(tabMainWith, tabMainHeight - 70);
                    tabMain.Location = new Point(6, ytabMain);

                    ypanel1 = ytabMain + tabMainHeight + 7;
                    panel1Height = grdLayoutHeight - tabMainHeight;
                    panel1.Height = panel1Height;
                    panel1.Location = new Point(6, ypanel1);
                }

            }
        }
        /// <summary>
        /// Thêm mới đối tượng từ combobox
        /// </summary>
        protected override void ShowAccountingObjectDetail()
        {
            using (var form = new FrmDialogCustom("Bạn muốn thêm loại đối tượng nào?", new string[] { "Đối tượng", "Cán bộ" }))
            {
                form.ShowDialog();
                switch (form.Result)
                {
                    case 1:
                        using (var frmDetail = new FrmXtraAccountingObjectDetail())
                        {
                            frmDetail.AccountingObjectCategoryId = lkAccountingObjectCategory.EditValue.ToString();
                            frmDetail.ShowDialog();
                            if (frmDetail.CloseBox)
                            {
                                if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                                {
                                    _accountingObjectsPresenter.Display();
                                    cboObjectCode.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                                    EvenChangeObjectCode();
                                    var accounting = _model.GetAccountingObject(GlobalVariable.AccountingObjectIDInventoryItemDetailForm);
                                    lkAccountingObjectCategory.EditValue = accounting.AccountingObjectCategoryId;
                                    cboObjectName.EditValue = accounting.AccountingObjectName;
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
                                    cboObjectCode.EditValue = GlobalVariable.EmployeeIDDetailForm;
                                    EvenChangeObjectCode();
                                    var accounting = _model.GetAccountingObject(GlobalVariable.EmployeeIDDetailForm);
                                    lkAccountingObjectCategory.EditValue = accounting.AccountingObjectCategoryId;
                                    cboObjectName.EditValue = accounting.AccountingObjectName;
                                }
                            }
                        }
                        break;
                    default: break;
                }
                //MessageBox.Show(form.Result.ToString());
            }
        }

        /// <summary>
        /// Thêm mới account
        /// </summary>
        private void cboBankId_ButtonClick(object sender, ButtonPressedEventArgs e)
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
                        BAWithDrawDetails = BAWithDrawDetails;
                        cboBankId.EditValue = GlobalVariable.BankIDProjectDetailForm;

                    }
                }
            }
        }

        private void cboAccountingBankId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                if (e.Button.Index.Equals(1))
                {
                    if (this.AccountingObjectId != null)
                    {
                        FrmXtraAccountingObjectDetail frmXtraAccountingObjectDetail = new FrmXtraAccountingObjectDetail();

                        frmXtraAccountingObjectDetail.KeyValue = this.AccountingObjectId;
                        string projectId = this.cboObjectCode.EditValue.ToString();
                        var banks1 = model.GetProjectBank(cboObjectCode.EditValue.ToString()) == null ? null : model.GetProjectBank(cboObjectCode.EditValue.ToString());
                        frmXtraAccountingObjectDetail.ShowDialog();

                        if (frmXtraAccountingObjectDetail.CloseBox)
                        {
                            var banks = model.GetProjectBank(cboObjectCode.EditValue.ToString()) == null ? null : model.GetProjectBank(cboObjectCode.EditValue.ToString());

                            if(banks != null && banks1.Count < banks.Count)
                            {
                                cboAccountingBankId.EditValue = banks == null ? null : banks.FirstOrDefault().BankId;
                                AccountingObjectBanks = model.GetProjectBank(cboObjectCode.EditValue.ToString());
                                txtBankName.EditValue = banks == null ? "" : banks.FirstOrDefault().BankName;

                                if (!string.IsNullOrEmpty(GlobalVariable.ProjectIDAccountingObjectDetailForm))
                                {
                                    _accountingObjectsPresenter.Display();
                                    cboObjectCode.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                                }
                                else
                                {
                                    cboObjectCode.EditValue = projectId;
                                }
                            }
                          
                        }
                    }
                }
            }
        }
        #endregion

        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        protected override void HiddenParallelAndOpenByCurrencyCode(object sender, CellValueChangedEventArgs e)
        {
            bool visibale = !e.Value.ToString().Equals("VND");
            ShowAmountByCurrencyCode(grdViewAccountingParallel, "Amount", visibale);
        }
        protected override void GridPurchaseShowEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            BAWithDrawDetailModel data = view.GetFocusedRow() as BAWithDrawDetailModel;
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

        protected void SetDetailParallelFromMaster(string bankValue)
        {
            var _bankId = nameof(BankModel.BankId); // Ngân hàng
            grdAccountingParallel.ForceInitialize();
            if (grdViewAccountingParallel.Columns.ColumnByFieldName(_bankId) != null &&
                !string.IsNullOrEmpty(bankValue))
            {
                if (grdViewAccountingParallel.Columns.ColumnByFieldName(_bankId).Visible)
                {
                    for (int i = 0; i < grdViewAccountingParallel.RowCount; i++)
                    {
                        // TK Ngân hàng
                        grdViewAccountingParallel.SetRowCellValue(i, _bankId, bankValue);

                    }
                }
            }
        }

        private void txtJournalMemo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    if (grdAccountingView.RowCount >= 0)
                    {
                        grdAccountingView.UpdateCurrentRow();
                        var dataSource = (List<BAWithDrawDetailModel>)((BindingSource)grdAccounting.DataSource).DataSource;
                        txtJournalMemo.Text = String.Join(", ", dataSource.Select(o => o.Description).ToArray());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }
    }
}
