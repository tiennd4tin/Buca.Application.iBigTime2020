/***********************************************************************
 * <copyright file="frmbunoestimatevoucherlists.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, June 14, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
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

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    public partial class FrmBUNoEstimateVoucherLists : FrmBaseVoucherList, IBUVoucherListsView, IBudgetSourcesView,
        ICashWithdrawTypesView, IAccountsView
    {
        private readonly IModel _model;

        #region Presenter

        /// <summary>
        ///     The b u voucher lists presenter
        /// </summary>
        private readonly BUVoucherListsPresenter _bUVoucherListsPresenter;

        /// <summary>
        ///     The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        ///     The cash withdraw types presenter
        /// </summary>
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;

        /// <summary>
        ///     The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        #endregion

        #region RepositoryItemGridLookUpEdit

        /// <summary>
        ///     The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;

        /// <summary>
        ///     The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        ///     The repository method distribute identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        /// <summary>
        ///     The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;

        /// <summary>
        ///     The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditCashWithdrawTypeView;

        /// <summary>
        ///     The grid look up edit account
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;

        /// <summary>
        ///     The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditAccountView;

        #endregion

        public FrmBUNoEstimateVoucherLists()
        {
            InitializeComponent();
            _bUVoucherListsPresenter = new BUVoucherListsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _model = new Model.Model();
        }

        #region override

        /// <summary>
        ///     Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            InitRepositoryControlData();
            _budgetSourcesPresenter.DisplayActive();
            _cashWithdrawTypesPresenter.DisplayList();
            _accountsPresenter.DisplayActive();
            bindingSource.AllowNew = true;

            // Hiển thị các reftype
            // Chuyển khoản kho bạc
            // Chuyển khoản kho bạc mua vật tư hàng hóa
            //var _listRefType = new List<RefTypeModel>() { new RefTypeModel() { RefTypeId = (int)RefType.BUTransfer }, new RefTypeModel() { RefTypeId = (int)RefType.BUTransferPurchase } };
            //_bUTransfersPresenter.Display(_listRefType);
            _bUVoucherListsPresenter.Display((int)RefType.BUNoEstimateVoucherList);
        }

        /// <summary>
        ///     Initializes the repository control data.
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
        ///     Loads the data into grid detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(string refId)
        {
            var bUVoucherList = _model.GetBUVoucherList(refId, false, false, true);
            if (bUVoucherList == null)
                return;
            bindingSourceDetail.DataSource = bUVoucherList.BUVoucherListDetailTransferModels;
            gridViewDetail.PopulateColumns(bUVoucherList.BUVoucherListDetailTransferModels);
            var columnsCollection = new List<XtraColumn>
            {
                new XtraColumn
                {
                    ColumnName = "BudgetSourceId",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Nguồn",
                    ColumnPosition = 1,
                    AllowEdit = false,
                    RepositoryControl = _gridLookUpEditBudgetSource
                },
                new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Chương",
                    ColumnPosition = 2,
                    IsSummnary = false,
                    AllowEdit = false
                },
                new XtraColumn
                {
                    ColumnName = "BudgetKindItemCode",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Loại",
                    IsSummnary = false,
                    ColumnPosition = 3,
                    AllowEdit = false
                },
                new XtraColumn
                {
                    ColumnName = "BudgetSubKindItemCode",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Khoản",
                    IsSummnary = false,
                    ColumnPosition = 4,
                    AllowEdit = false
                },
                new XtraColumn
                {
                    ColumnName = "BudgetSubItemCode",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Tiểu mục",
                    ColumnPosition = 5,
                    AllowEdit = false
                },
                new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Mục",
                    ColumnPosition = 6,
                    AllowEdit = false
                },
                new XtraColumn
                {
                    ColumnName = "MethodDistributeId",
                    ColumnVisible = true,
                    ColumnWith = 120,
                    ColumnCaption = "Cấp phát",
                    ColumnPosition = 7,
                    AllowEdit = false,
                    RepositoryControl = _repositoryMethodDistributeId
                },
                new XtraColumn
                {
                    ColumnName = "CashWithDrawTypeId",
                    ColumnVisible = true,
                    ColumnWith = 120,
                    ColumnCaption = "Nghiệp vụ",
                    ColumnPosition = 8,
                    AllowEdit = false,
                    RepositoryControl = _gridLookUpEditCashWithdrawType
                },
                new XtraColumn
                {
                    ColumnName = "AmountOC",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 9,
                    AllowEdit = false,
                    ColumnType = UnboundColumnType.Decimal
                },
                new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Quy đổi",
                    ColumnPosition = 10,
                    AllowEdit = false,
                    ColumnType = UnboundColumnType.Decimal
                },
                new XtraColumn
                {
                    ColumnName = "DebitAccount",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "TK Nợ",
                    ColumnPosition = 11,
                    AllowEdit = false,
                    RepositoryControl = _gridLookUpEditAccount
                },
                new XtraColumn
                {
                    ColumnName = "CreditAccount",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "TK Có",
                    ColumnPosition = 12,
                    AllowEdit = false,
                    RepositoryControl = _gridLookUpEditAccount
                },
                new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                new XtraColumn {ColumnName = "CurrencyCode", ColumnVisible = false},
                new XtraColumn {ColumnName = "ExchangeRate", ColumnVisible = false},
                new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                new XtraColumn {ColumnName = "BankAccount", ColumnVisible = false},
                new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false}
            };
            gridViewDetail = InitGridLayout(columnsCollection, gridViewDetail);
            SetNumericFormatControl(gridViewDetail, true);
            gridViewDetail.OptionsView.ShowFooter = false;
        }

        /// <summary>
        ///     Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>
        ///     GridView.
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

        /// <summary>
        ///     Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BUVoucherListPresenter(null).Delete(PrimaryKeyValue);
        }

        #endregion

        #region IView

        #region BUVoucherListModels

        /// <summary>
        ///     Sets the bu voucher list models.
        /// </summary>
        /// <value>
        ///     The bu voucher list models.
        /// </value>
        public IList<BUVoucherListModel> BUVoucherListModels
        {
            set
            {
                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);
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
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày lập",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FromDate",
                    ColumnCaption = "Từ ngày",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ToDate",
                    ColumnCaption = "Đến ngày",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 50
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "JournalMemo",
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmount",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnWith = 100
                });


                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefType",
                    ColumnCaption = "Loại chứng từ",
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    RepositoryControl = GridLookUpEditRefType,
                    ColumnWith = 40
                });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParalellRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Posted", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostVersion", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EditVersion", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BUVoucherListDetailModels", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BUVoucherListDetailParallelModels",
                    ColumnVisible = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BUVoucherListDetailTransferModels",
                    ColumnVisible = false
                });
                XtraColumnCollectionHelper<BUVoucherListModel>.ShowXtraColumnInGridView(ColumnsCollection, gridView);
            }
        }

        #endregion

        #region BudgetSources

        /// <summary>
        ///     Sets the budget sources.
        /// </summary>
        /// <value>
        ///     The budget sources.
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

        #endregion

        #region CashWithdrawTypeModels

        /// <summary>
        ///     Sets the cash withdraw type models.
        /// </summary>
        /// <value>
        ///     The cash withdraw type models.
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
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditCashWithdrawType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCashWithdrawType.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCashWithdrawType.PopupFormSize = new Size(268, 150);

                    _gridLookUpEditCashWithdrawType.View.BestFitColumns();

                    _gridLookUpEditCashWithdrawType.DataSource = value;
                    _gridLookUpEditCashWithdrawTypeView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = false
                    });
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
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
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

        #region Accounts

        /// <summary>
        ///     Sets the accounts.
        /// </summary>
        /// <value>
        ///     The accounts.
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

        #endregion

        #endregion
    }
}
