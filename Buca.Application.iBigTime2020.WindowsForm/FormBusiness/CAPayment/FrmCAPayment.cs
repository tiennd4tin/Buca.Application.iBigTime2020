﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Cash.PaymentVoucher;
using Buca.Application.iBigTime2020.Presenter.Cash.ReceiptVoucher;
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
using Buca.Application.iBigTime2020.View.Cash;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAPayment
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseVoucherList" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Cash.ICAPaymentsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
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
    public partial class FrmCAPayment : FrmBaseVoucherList, ICAPaymentsView, IAccountingObjectsView, IBudgetSourcesView, IAccountsView,
        IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, ICashWithdrawTypesView, IBanksView, IActivitysView, IProjectsView,
        IFundStructuresView
    {
        /// <summary>
        /// The payments presenter
        /// </summary>
        private readonly CAPaymentsPresenter _paymentsPresenter;
        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
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

        #region RepositoryItemGridLookUpEdit

        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        /// The grid look up edit account
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;
        /// <summary>
        /// The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditAccountView;

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
        /// The grid look up edit fund structure
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        /// <summary>
        /// The grid look up edit fund structure view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

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

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCAPayment"/> class.
        /// </summary>
        public FrmCAPayment()
        {
            InitializeComponent();
            _paymentsPresenter = new CAPaymentsPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
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

            Model = new Model.Model();
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public static IModel Model { get; set; }

        /// <summary>
        /// Sets the ca payments.
        /// </summary>
        /// <value>
        /// The ca payments.
        /// </value>
        public IList<CAPaymentModel> CAPayments
        {
            set
            {
                var data = value.OrderByDescending(m => m.PostedDate).ToList();
                bindingSource.DataSource = data;
                gridView.PopulateColumns(data);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PostedDate",
                    ColumnCaption = "Ngày HT",
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    Alignment = HorzAlignment.Center,
                    ColumnWith = 40,
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số PC",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày PC",
                    Alignment = HorzAlignment.Center,
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 40
                });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParalellRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DocumentIncluded", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectId",
                    ColumnCaption = "Người nhận",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    RepositoryControl = _gridLookUpEditAccountingObject,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "JournalMemo",
                    ColumnCaption = "Lý do chi",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmount",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnWith = 40
                });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CurrencyCode",
                    ColumnCaption = "Loại tiền",
                    Alignment = HorzAlignment.Center,
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 40
                }
               );
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefType",
                    ColumnCaption = "Loại phiếu chi",
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    RepositoryControl = GridLookUpEditRefType,
                    ColumnWith = 40
                });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ActivityId",
                    ColumnCaption = "Công việc",
                    ColumnPosition = 9,
                    ColumnVisible = true,
                    RepositoryControl = _gridLookUpEditActivity,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOC", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalTaxAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Posted", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefOrder", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IncrementRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InwardRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalFreightAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalInwardAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalPaymentAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RelationRefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CaPaymentDetailTaxes", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetailPurchases", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetailFixedAssets", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetailParallels", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Receiver", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            InitRepositoryControlData();

            _accountingObjectsPresenter.DisplayActive(true);
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _banksPresenter.DisplayActive(true);
            _activitysPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.Display();


            //_paymentsPresenter.Display((int)RefType.CAPayment);
            var _listRefType = new List<RefTypeModel>()
            {
                new RefTypeModel() { RefTypeId = (int)RefType.CAPayment },
                //new RefTypeModel() { RefTypeId = (int)RefType.CAPaymentInventoryItem },
                //new RefTypeModel() { RefTypeId = (int)RefType.CAPaymentDetailFixedAsset },
                //new RefTypeModel() { RefTypeId = (int)RefType.CAPaymentTreasury },
            };
            _paymentsPresenter.Display(_listRefType);
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
        /// Loads the data into grid detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(string refId)
        {
            var paymentModel = Model.GetPaymentVoucher(refId);

            switch (this.RefTypeId)
            {
                case RefType.CAPayment:
                case RefType.CAPaymentTreasury:
                    bindingSourceDetail.DataSource = paymentModel.CAPaymentDetails;
                    gridViewDetail.PopulateColumns(paymentModel.CAPaymentDetails);
                    break;
                case RefType.CAPaymentInventoryItem:
                    bindingSourceDetail.DataSource = paymentModel.CAPaymentDetailPurchases;
                    gridViewDetail.PopulateColumns(paymentModel.CAPaymentDetailPurchases);
                    break;
                case RefType.CAPaymentDetailFixedAsset:
                    bindingSourceDetail.DataSource = paymentModel.CAPaymentDetailFixedAssets;
                    gridViewDetail.PopulateColumns(paymentModel.CAPaymentDetailFixedAssets);
                    break;
            }

            var columnsCollection = new List<XtraColumn>
            {
                new XtraColumn {ColumnName = "Description",ColumnVisible = true,ColumnWith = 200,ColumnCaption = "Diễn giải",ColumnPosition = 1,AllowEdit = true,},
                new XtraColumn {ColumnName = "DebitAccount",ColumnVisible = true,RepositoryControl = _gridLookUpEditAccount,ColumnWith = 80,ColumnCaption = "TK Nợ",ColumnPosition = 2,AllowEdit = true},
                new XtraColumn {ColumnName = "CreditAccount",ColumnVisible = true,ColumnWith = 80,ColumnCaption = "TK Có",ColumnPosition = 3,AllowEdit = true,RepositoryControl = _gridLookUpEditAccount},
                new XtraColumn {ColumnName = "Amount",ColumnVisible = true,ColumnWith = 100,ColumnCaption = "Số tiền",ColumnPosition = 4,IsSummnary = true,AllowEdit = true,ColumnType = UnboundColumnType.Decimal},
                new XtraColumn {ColumnName = "BudgetSourceId",ColumnVisible = true,ColumnWith = 150,ColumnCaption = "Nguồn",ColumnPosition = 4,AllowEdit = true,RepositoryControl = _gridLookUpEditBudgetSource},
                new XtraColumn {ColumnName = "BudgetChapterCode",ColumnVisible = true,ColumnWith = 80,ColumnCaption = "Chương",ColumnPosition = 5,AllowEdit = true,RepositoryControl = _gridLookUpEditBudgetChapter},
                new XtraColumn {ColumnName = "BudgetSubKindItemCode",ColumnVisible = true,ColumnWith = 80,ColumnCaption = "Khoản",ColumnPosition = 6,AllowEdit = true,RepositoryControl = _gridLookUpEditBudgetSubKindItem},
                new XtraColumn {ColumnName = "BudgetSubItemCode",ColumnVisible = true,ColumnWith = 80,ColumnCaption = "Tiểu mục",ColumnPosition = 7,AllowEdit = true,RepositoryControl = _gridLookUpEditBudgetSubItem},
                new XtraColumn {ColumnName = "BudgetItemCode",ColumnVisible = true,ColumnWith = 80,ColumnCaption = "Mục",ColumnPosition = 8,AllowEdit = true,RepositoryControl = _gridLookUpEditBudgetItem},
                 new XtraColumn {ColumnName = "ActivityId",ColumnVisible = true,ColumnWith = 80,ColumnCaption = "Công việc",ColumnPosition = 9,AllowEdit = true,RepositoryControl = _gridLookUpEditActivity},
                new XtraColumn {ColumnName = "MethodDistributeId",ColumnVisible = false,ColumnWith = 120,ColumnCaption = "Cấp phát",ColumnPosition = 9,AllowEdit = true,RepositoryControl = _repositoryMethodDistributeId},
                new XtraColumn {ColumnName = "FundStructureId",ColumnVisible = false,ColumnWith = 120,ColumnCaption = "Cơ cấu vốn",ColumnPosition = 11,AllowEdit = true,RepositoryControl = _gridLookUpEditFundStructure},
            };

            //gridViewDetail = InitGridLayout(columnsCollection, gridViewDetail);
            //SetNumericFormatControl(gridViewDetail, true);
            switch (this.RefTypeId)
            {
                case RefType.CAPayment:
                case RefType.CAPaymentTreasury:
                    XtraColumnCollectionHelper<CAPaymentDetailModel>.ShowXtraColumnInGridView(columnsCollection, gridViewDetail);
                    break;
                case RefType.CAPaymentInventoryItem:
                    XtraColumnCollectionHelper<CAPaymentDetailPurchaseModel>.ShowXtraColumnInGridView(columnsCollection, gridViewDetail);
                    break;
                case RefType.CAPaymentDetailFixedAsset:
                    XtraColumnCollectionHelper<CAPaymentDetailFixedAssetModel>.ShowXtraColumnInGridView(columnsCollection, gridViewDetail);
                    break;
            }

            gridViewDetail.OptionsView.ShowFooter = false;
        }

        #region IView

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

        #endregion

        #region IAccountsView

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
                    _gridLookUpEditAccountView = new GridView();
                    _gridLookUpEditAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditAccountView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditAccount.View.BestFitColumns();

                    _gridLookUpEditAccount.DataSource = value;
                    _gridLookUpEditAccountView.PopulateColumns(value);

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
                        ColumnCaption = "Tên tài khỏan",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false, });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditAccount.DisplayMember = "AccountNumber";
                    _gridLookUpEditAccount.ValueMember = "AccountNumber";
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
                        TextEditStyle = TextEditStyles.Standard,
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
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3).ToList();

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

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        #endregion

        #region AccountingObjects

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
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "AccountingObjectBanks", ColumnVisible = false },
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
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                };
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
                _gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectName";
                _gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";

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
                        ColumnCaption = "Mã cơ cấu vốn",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FundStructureName",
                        ColumnCaption = "Tên cơ cấu vốn",
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

        #endregion

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new CAPaymentPresenter(null).Delete(PrimaryKeyValue);
        }

        #region AddData
        /// <summary>
        /// Changes the form detail.
        /// </summary>
        protected override void ChangeFormDetail()
        {
            //if (string.IsNullOrEmpty(PrimaryKeyValue)) return;
            var obj = gridView.GetFocusedRow();
            if (obj == null)
            {
                SetFormDetail((int)RefType.CAPayment);
                return;
            }
            
            var model = (CAPaymentModel)obj;
            SetFormDetail(model.RefType);
        }

        /// <summary>
        /// Adds the data.
        /// </summary>
        public override void AddData()
        {
            SetFormDetail((int)RefType.CAPayment);
            base.AddData();
        }
        #endregion
    }
}
