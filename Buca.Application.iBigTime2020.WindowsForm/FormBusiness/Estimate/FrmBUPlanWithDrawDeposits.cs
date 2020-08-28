/***********************************************************************
 * <copyright file="FrmBUPlanWithDrawDeposits.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, November 2, 2017
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.Presenter.IncrementDecrement;
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
    /// <summary>
    ///     FrmBUPlanWithDrawDeposits
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseVoucherList" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Estimate.IBUPlanWithdrawsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.ICashWithdrawTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    public partial class FrmBUPlanWithDrawDeposits : FrmBaseVoucherList, IBUPlanWithdrawsView, ICashWithdrawTypesView,
        IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView
        , IAccountsView, IBudgetItemsView, IProjectsView, IFundStructuresView
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmBUPlanWithDrawDeposits" /> class.
        /// </summary>
        public FrmBUPlanWithDrawDeposits()
        {
            InitializeComponent();
            _bUPlanWithdrawsPresenter = new BUPlanWithdrawsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _model = new Model.Model();
        }

        #region IBUPlanWithdrawsView

        /// <summary>
        ///     Sets the bu plan withdraw.
        /// </summary>
        /// <value>
        ///     The bu plan withdraw.
        /// </value>
        public IList<BUPlanWithdrawModel> BUPlanWithdraws
        {
            set
            {
                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PostedDate",
                    ColumnCaption = "Ngày HT",
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    Alignment = HorzAlignment.Center,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số CT",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày CT",
                    Alignment = HorzAlignment.Center,
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "JournalMemo",
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 200
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmount",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefType",
                    ColumnCaption = "Hình thức rút",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    RepositoryControl = GridLookUpEditRefType,
                    ColumnWith = 120
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CashWithDrawType",
                    ColumnVisible = true,
                    ColumnWith = 80,
                    ColumnCaption = "Nghiệp vụ",
                    ColumnPosition = 7,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditCashWithdrawType
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParalellRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TargetProgramId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOC", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "GeneratedRefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Posted", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BUCommitmentRequestId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BUPlanWithdrawDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectBankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAReceiptRefId", ColumnVisible = false });
                XtraColumnCollectionHelper<BUPlanWithdrawModel>.ShowXtraColumnInGridView(ColumnsCollection, gridView);
            }
        }

        #endregion

        #region RepositoryItemGridLookUpEdit

        /// <summary>
        ///     The grid look up edit fund structure
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;

        /// <summary>
        ///     The grid look up edit fund structure view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

        /// <summary>
        ///     The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;

        /// <summary>
        ///     The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditCashWithdrawTypeView;

        /// <summary>
        ///     The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;

        /// <summary>
        ///     The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        ///     The grid look up edit budget chapter
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;

        /// <summary>
        ///     The grid look up edit budget chapter view
        /// </summary>
        private GridView _gridLookUpEditBudgetChapterView;

        /// <summary>
        ///     The grid look up edit budget sub kind item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;

        /// <summary>
        ///     The grid look up edit budget sub kind item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubKindItemView;

        /// <summary>
        ///     The grid look up edit budget sub item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;

        /// <summary>
        ///     The grid look up edit budget sub item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubItemView;

        /// <summary>
        ///     The grid look up edit budget item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;

        /// <summary>
        ///     The grid look up edit budget item view
        /// </summary>
        private GridView _gridLookUpEditBudgetItemView;

        /// <summary>
        ///     The grid look up edit account_gridLookUpEditAccount
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;

        /// <summary>
        ///     The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditAccountView;

        /// <summary>
        ///     The grid look up edit project
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;

        /// <summary>
        ///     The grid look up edit project view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        #endregion

        #region Presenter

        /// <summary>
        ///     The b u plan withdraws presenter
        /// </summary>
        private readonly BUPlanWithdrawsPresenter _bUPlanWithdrawsPresenter;

        /// <summary>
        ///     The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        ///     The budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        /// <summary>
        ///     The fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;

        /// <summary>
        ///     The cash withdraw types presenter
        /// </summary>
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;

        /// <summary>
        ///     The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        ///     The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        /// <summary>
        ///     The model
        /// </summary>
        private readonly IModel _model;

        /// <summary>
        ///     The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        /// <summary>
        ///     The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        /// <summary>
        ///     The projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        #endregion                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    .

        #region override

        /// <summary>
        ///     Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _accountsPresenter.DisplayActive();
            _budgetKindItemsPresenter.DisplayActive();
            _projectsPresenter.DisPlayForFAIncrementDecrement();
            _budgetItemsPresenter.DisplayActive(true);
            _fundStructuresPresenter.Display();
            _cashWithdrawTypesPresenter.DisplayList();
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _bUPlanWithdrawsPresenter.DisplayByRefType((int)RefType.BUPlanWithDrawDeposit);
        }

        /// <summary>
        ///     Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BUPlanWithdrawPresenter(null).Delete(PrimaryKeyValue);
            if (new BUTransferPresenter(null).GetBUTransferByBUPlanWithdrawRefId(PrimaryKeyValue).Length > 0)
            {
                DialogResult dialog = XtraMessageBox.Show(string.Format("Bạn có muốn xóa chứng từ chuyển khoản kho bạc vào tài khoản tiền gửi số {0} không?", new BUTransferPresenter(null).GetBUTransferByBUPlanWithdrawRefId(PrimaryKeyValue)), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    new BUTransferPresenter(null).DeleteBUTransferByBUTransferRefId(PrimaryKeyValue);
                }
            }
        }

        /// <summary>
        ///     Loads the data into grid detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(string refId)
        {
            var sAIncrementDecrement = _model.GetBUPlanWithdrawByRefId(refId, true);
            if (sAIncrementDecrement == null)
                return;
            bindingSourceDetail.DataSource = sAIncrementDecrement.BUPlanWithdrawDetails;
            gridViewDetail.PopulateColumns(sAIncrementDecrement.BUPlanWithdrawDetails);
            var columnsCollection = new List<XtraColumn>
            {
                new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Số chứng từ gốc",
                        ColumnPosition = 1,
                        AllowEdit = true

                    },
                    new XtraColumn {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Ngày CT gốc",
                        ColumnPosition = 2,
                        AllowEdit = true,
                        RepositoryControl = new RepositoryItemDateEdit()
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Nội dung thanh toán",
                        ColumnPosition = 3,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 4,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Chương",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Mục",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },

                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Tài khoản NH, KB",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccount


                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 10,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {ColumnName = "AmountOC", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = true,
                        ColumnWith = 180,
                        ColumnCaption = "CTMT, dự án",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditProject
                    },
                    new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
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

        protected override bool ValidEdit()
        {
            var item = gridView.GetFocusedRow();
            if (item == null)
                return false;

            var model = (BUPlanWithdrawModel)item;
            if (!string.IsNullOrEmpty(model.CAReceiptRefId))
                return XtraMessageBox.Show(string.Format("Giấy dự toán hiện thời đã sinh chuyển khoản kho bạc số {0}, bạn có muốn sửa giấy rút này không?", model.LinkRefNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
            return true;
        }
        #endregion

        #region IView Extens

        /// <summary>
        ///     Sets the fund structures.
        /// </summary>
        /// <value>
        ///     The fund structures.
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
                            ColumnCaption = "Tên khoản chi",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Inactive", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false},
                        new XtraColumn {ColumnName = "InvestmentPeriod", ColumnVisible = false}
                    };
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditFundStructure.DisplayMember = "FundStructureName";
                    _gridLookUpEditFundStructure.ValueMember = "FundStructureId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                        {
                            ColumnName = "CashWithdrawTypeId",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "CashWithdrawTypeName",
                            ColumnCaption = "Nghiệp vụ",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "CashWithdrawNo", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SubSystemId", ColumnVisible = false}
                    };
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
        ///     Sets the budget chapters.
        /// </summary>
        /// <value>
        ///     The budget chapters.
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

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditBudgetChapter.DisplayMember = "BudgetChapterCode";
                    _gridLookUpEditBudgetChapter.ValueMember = "BudgetChapterCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///     Sets the budget kind items.
        /// </summary>
        /// <value>
        ///     The budget kind items.
        /// </value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                try
                {
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
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditBudgetSubKindItem.DisplayMember = "BudgetKindItemCode";
                    _gridLookUpEditBudgetSubKindItem.ValueMember = "BudgetKindItemCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///     Sets the BudgetItems.
        /// </summary>
        /// <value>
        ///     The BudgetItems.
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
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
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
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditBudgetSubItem.DisplayMember = "BudgetItemCode";
                    _gridLookUpEditBudgetSubItem.ValueMember = "BudgetItemCode";

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

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "AccountId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "AccountNumber",
                            ColumnCaption = "Số tài khoản",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "AccountName",
                            ColumnCaption = "Tên tài khỏan",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "AccountCategoryId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AccountCategoryKind", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "AccountForeignName",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "DetailByBudgetSource",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByBudgetChapter",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByBudgetKindItem",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByBudgetItem",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByBudgetSubItem",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByMethodDistribute",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByAccountingObject",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "DetailByActivity", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailByProject", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailByTask", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailBySupply", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "DetailByInventoryItem",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByFixedAsset",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "DetailByFund", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailByBankAccount", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "DetailByProjectActivity",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "DetailByInvestor", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailByCurrency", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "IsDisplayOnAccountBalanceSheet",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "IsDisplayBalanceOnReport",
                            ColumnVisible = false
                        }
                    };

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
        ///     Sets the projects.
        /// </summary>
        /// <value>
        ///     The projects.
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
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditProject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditProject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditProject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditProject.View.BestFitColumns();

                    _gridLookUpEditProject.DataSource = value;
                    _gridLookUpEditProjectView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "ProjectCode",
                            ColumnCaption = "Mã CTMT, dự án",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "ProjectName",
                            ColumnCaption = "Tên CTMT, dự án",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
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
                        new XtraColumn {ColumnName = "ContractorID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ContractorName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ContractorAddress", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectSize", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BuildLocation", ColumnVisible = false},
                        new XtraColumn {ColumnName = "InvestmentClass", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CDCActivityType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Investment", ColumnVisible = false}
                    };
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
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

        #endregion
    }
}