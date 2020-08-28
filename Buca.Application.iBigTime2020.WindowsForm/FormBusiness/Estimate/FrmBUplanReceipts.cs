using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetGroupItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    public partial class FrmBUplanReceipts : FrmBaseVoucherList, IBUPlanReceiptsView, IAccountsView, IBudgetSourcesView, IBudgetKindItemsView, IFundStructuresView, IBanksView, IProjectsView, IBudgetGroupItemsView, IActivitysView
    {
        public FrmBUplanReceipts()
        {
            InitializeComponent();
            _buPlanReceiptsPresenter = new BUPlanReceiptsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetGroupItemsPresenter = new BudgetGroupItemsPresenter(this);
            _activityPresenter = new ActivitysPresenter(this);
            _model = new Model.Model();
        }

        #region Presenter
        /// <summary>
        /// The s u increment decrements presenter
        /// </summary>
        private readonly BUPlanReceiptsPresenter _buPlanReceiptsPresenter;

        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;
        
        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly ActivitysPresenter _activityPresenter;

        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        /// <summary>
        /// The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        /// <summary>
        /// The _fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;

        /// <summary>
        /// The _projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// The _banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// The budget group items presenter
        /// </summary>
        private readonly BudgetGroupItemsPresenter _budgetGroupItemsPresenter;

        /// <summary>
        /// The model
        /// </summary>
        private readonly IModel _model;
        #endregion

        #region RepositoryItemLookUpEdit
        /// <summary>
        /// The grid look up edit account_gridLookUpEditAccount
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;

        /// <summary>
        /// The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditAccountView;

        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;

        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;

        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditActivityView;


        /// <summary>
        /// The grid look up edit budget sub kind item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetKindItem;

        /// <summary>
        /// The grid look up edit budget sub kind item view
        /// </summary>
        private GridView _gridLookUpEditBudgetKindItemView;

        /// <summary>
        /// The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;

        /// <summary>
        /// The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

        /// <summary>
        /// The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBank; 

        /// <summary>
        /// The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditBankView;

        /// <summary>
        /// The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;

        /// <summary>
        /// The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        /// <summary>
        /// The _repository method distribute identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditRefType;

        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditRefTypeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetGroupItem;
        private GridView _gridLookUpEditBudgetGroupItemView;

        private List<BudgetItemModel> _budgetItemModels;

        #endregion

        #region override

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            InitRepositoryControlData();
            
            _accountsPresenter.DisplayActive();
            _budgetKindItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _banksPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.Display();
            _budgetGroupItemsPresenter.Display();
            _activityPresenter.Display();
            //_buPlanReceiptsPresenter.Display((int)RefType.BUPlanReceiptEarlyYear);
            _buPlanReceiptsPresenter.Display();
            bindingSource.AllowNew = true;
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
             var abc =  _repositoryMethodDistributeId.IsFilterLookUp;
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BUPlanReceiptPresenter(null).Delete(PrimaryKeyValue);
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(string refId)
        {
            var buPlanReceipt = _model.GetBUPlanReceiptVoucherByRefId(refId, true);
            if (buPlanReceipt == null)
                return;
            bindingSourceDetail.DataSource = buPlanReceipt.BUPlanReceiptDetails;
            gridViewDetail.PopulateColumns(buPlanReceipt.BUPlanReceiptDetails);
            var columnsCollection = new List<XtraColumn>
            {
                new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 320,
                        ColumnCaption = "Chỉ tiêu",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 3,
                        IsSummnary = false,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 4,
                        AllowEdit = false,
                        RepositoryControl = _gridLookUpEditBudgetSource,},

                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditBudgetKindItem,
                        ColumnWith = 100,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 5,
                        AllowEdit = false},
                    new XtraColumn
                    {
                        ColumnName = "BudgetParentItemCode",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnCaption = "Nhóm mục",
                        ColumnPosition = 6,
                        IsSummnary = true,
                        AllowEdit = true,
                        //RepositoryControl = _gridLookUpEditBudgetItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnCaption = "Mục",
                        ColumnPosition = 7,
                        IsSummnary = true,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "AmountOC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetGroupItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditFundStructure,
                        ColumnWith = 130,
                        ColumnCaption = "Nhóm mục chi",
                        ColumnPosition = 8,
                        AllowEdit = false},
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditBank,
                        ColumnWith = 130,
                        ColumnCaption = "Tài khoản NH, KB",
                        ColumnPosition = 9,
                        AllowEdit = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditProject,
                        ColumnWith = 130,
                        ColumnCaption = "CTMT, dự án",
                        ColumnPosition = 8,
                        AllowEdit = false},
                    new XtraColumn{ColumnName = "MethodDistributeId", ColumnVisible = false,                        
                        ColumnWith = 120,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        IsLastColumn = true,
                        RepositoryControl = _repositoryMethodDistributeId},
                    new XtraColumn{ColumnName = "ActivityId", ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        IsLastColumn = true,
                        RepositoryControl = _gridLookUpEditActivity},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater1", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater1OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater2", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater2OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater3", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater3OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater4", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater4OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth1", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth1OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth2", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth2OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth3", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth3OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth4", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth4OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth5", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth5OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth6", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth6OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth7", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth7OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth8", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth8OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth9", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth9OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth10", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth10OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth11", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth11OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth12", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth12OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContractId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CapitalPlanId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailBy", ColumnVisible = false}
            };
            gridViewDetail = InitGridLayout(columnsCollection, gridViewDetail);
            SetNumericFormatControl(gridViewDetail, true);
            gridViewDetail.OptionsView.ShowFooter = false;
        }

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
                if (grdView.Columns[column.ColumnName] != null)
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
                        //grdView.Columns[column.ColumnName].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                        //grdView.Columns[column.ColumnName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                        if (column.IsSummaryText)
                        {
                            grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat =
                                Properties.Resources.SummaryText;
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
            return grdView;
        }

        #endregion

        #region IView Extens

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
                        TextEditStyle = TextEditStyles.Standard
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
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountForeignName",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetSource",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetChapter",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetKindItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetSubItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByMethodDistribute",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByAccountingObject",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByInventoryItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByFixedAsset",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByProjectActivity",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDisplayOnAccountBalanceSheet",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDisplayBalanceOnReport",
                        ColumnVisible = false
                    });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditAccount.DisplayMember = "AccountNumber";
                    _gridLookUpEditAccount.ValueMember = "AccountNumber";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                try
                {
                    _budgetSubKindItemModels = value.Where(v => !v.IsParent).ToList();

                    _gridLookUpEditBudgetKindItemView = new GridView();
                    _gridLookUpEditBudgetKindItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetKindItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetKindItemView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetKindItem.View.BestFitColumns();

                    _gridLookUpEditBudgetKindItem.DataSource = _budgetSubKindItemModels;
                    _gridLookUpEditBudgetKindItemView.PopulateColumns(_budgetSubKindItemModels);

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
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetKindItemView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditBudgetKindItem.DisplayMember = "BudgetKindItemCode";
                    _gridLookUpEditBudgetKindItem.ValueMember = "BudgetKindItemCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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

        /// <summary>
        /// Sets the bu plan receipts.
        /// </summary>
        /// <value>
        /// The bu plan receipts.
        /// </value>
        public IList<BUPlanReceiptModel> BUPlanReceipts
        {
            set
            {

                var receiptModel = value.Where(v => v.RefType == 51 || v.RefType == 52).ToList();
                bindingSource.DataSource = (receiptModel);
                gridView.PopulateColumns(receiptModel);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefType",
                    ColumnCaption = "Loại CT",
                    ColumnPosition = 1,
                    ColumnVisible = false,
                    ColumnWith = 60,
                    RepositoryControl = GridLookUpEditRefType
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày CT",
                    Alignment = HorzAlignment.Center,
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PostedDate",
                    ColumnCaption = "Ngày HT",
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    Alignment = HorzAlignment.Center,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số CT",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CurrencyCode",
                    ColumnCaption = "Tiền tệ",
                    ColumnPosition = 4,
                    ColumnVisible = false,
                    ColumnWith = 80
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParalellRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DecisionDate",
                    ColumnCaption = "Ngày QĐ",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DecisionNo",
                    ColumnCaption = "Số QĐ",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Chương",
                    ColumnPosition = 6,
                    ColumnVisible = false,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "JournalMemo",
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmount",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOC", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Posted", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AllocationConfig", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BUPlanReceiptDetails", ColumnVisible = false });
                InitGridLayout(ColumnsCollection,gridView);
            }
        }

        /// <summary>
        /// Sets the bu plan withdraw.
        /// </summary>
        /// <value>
        /// The bu plan withdraw.
        /// </value>
        public IList<BUPlanReceiptDetailModel> BUPlanWithdraw { set; private get; }

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
                _gridLookUpEditRefTypeView = new GridView();
                _gridLookUpEditRefTypeView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpEditRefType = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditRefTypeView,
                    TextEditStyle = TextEditStyles.Standard
                };
                _gridLookUpEditRefType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditRefType.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditRefType.PopupFormSize = new Size(368, 150);
                _gridLookUpEditRefType.View.BestFitColumns();

                _gridLookUpEditRefType.DataSource = value;
                _gridLookUpEditRefTypeView.PopulateColumns(value);

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "RefTypeName", ColumnCaption = "Tên chứng từ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 320 },
                        new XtraColumn { ColumnName = "FunctionId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "RefTypeCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "MasterTableName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailTableName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "LayoutMaster", ColumnVisible = false },
                        new XtraColumn { ColumnName = "LayoutDetail", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultDebitAccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultDebitAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultCreditAccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultCreditAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultTaxAccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultTaxAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AllowDefaultSetting", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Postable", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Searchable", ColumnVisible = false },
                        new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false },
                        new XtraColumn { ColumnName = "SubSystem", ColumnVisible = false }
                    };

                foreach (var column in gridgridColumnsCollection)
                    if (column.ColumnVisible)
                    {
                        _gridLookUpEditRefTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _gridLookUpEditRefTypeView.Columns[column.ColumnName].VisibleIndex =
                            column.ColumnPosition;
                        _gridLookUpEditRefTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        _gridLookUpEditRefTypeView.Columns[column.ColumnName].Visible = false;
                    }
                _gridLookUpEditRefType.DisplayMember = "RefTypeName";
                _gridLookUpEditRefType.ValueMember = "RefTypeId";
            }
        }

        #region BudgetGroupItem
        public IList<BudgetGroupItemModel> BudgetGroupItems
        {
            set
            {
                try
                {
                    _gridLookUpEditBudgetGroupItemView = new GridView();
                    _gridLookUpEditBudgetGroupItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetGroupItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetGroupItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetGroupItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetGroupItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetGroupItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetGroupItem.View.BestFitColumns();
                    _gridLookUpEditBudgetGroupItem.AllowNullInput = DefaultBoolean.True;

                    _gridLookUpEditBudgetGroupItem.DataSource = value;
                    _gridLookUpEditBudgetGroupItemView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetGroupItemCode",
                        ColumnCaption = "Mã nhóm mục",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetGroupItemName",
                        ColumnCaption = "Tên nhóm mục",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RepBudgetItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetGroupItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetGroupItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetGroupItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetGroupItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetGroupItem.DisplayMember = "BudgetGroupItemName";
                    _gridLookUpEditBudgetGroupItem.ValueMember = "BudgetGroupItemCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<ActivityModel> Activitys {
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
                    _gridLookUpEditActivity.PopupFormSize = new Size(368, 150);

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
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ActivityName",
                        ColumnCaption = "Tên công việc",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    //gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    //gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    //gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    //gridColumnsCollection.Add(new XtraColumn { ColumnName = "Inactive", ColumnVisible = false });
                    //gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    //gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentPeriod", ColumnVisible = false });
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

        //public IList<BudgetItemModel> BudgetItems
        //{
        //    set
        //    {
        //        if (value == null)
        //            return;
        //        _budgetItemModels = value.ToList();
        //        var budgetItemModels = value.Where(v => v.BudgetItemType <= 1).ToList();
        //        var budgetSubItemModels = value.Where(v => v.BudgetItemType == 2).ToList();

        //        // Tiểu mục

        //        var gridColumnsCollection = new List<XtraColumn>();
        //        gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã tiểu mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
        //        gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên tiểu mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

        //        XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);

        //        // Mục
        //        _gridLookUpEditBudgetItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
        //        _gridLookUpEditBudgetItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemView, budgetItemModels, "BudgetItemCode", "BudgetItemCode");

        //        gridColumnsCollection = new List<XtraColumn>();
        //        gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
        //        gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

        //        XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetItemView);
        //    }
        //}

        #endregion
    }
}
