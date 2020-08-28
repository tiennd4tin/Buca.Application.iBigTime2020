/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 06, 2017
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
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetChapter;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    /// <summary>
    /// FrmBUPlanCancelDetail
    /// </summary>
    public partial class FrmBUPlanCancelDetail : FrmXtraBaseVoucherDetail, IBUPlanReceiptView, IAccountsView, IBudgetSourcesView, IBudgetKindItemsView, IFundStructuresView, IBanksView, IProjectsView, IBudgetChaptersView, IBudgetItemsView
    {
        #region IBUPlanReceiptView
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime RefDate
        {
            get { return dtRefDate.EditValue == null ? DateTime.Now : (DateTime)dtRefDate.EditValue; }
            set { dtRefDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate
        {
            get { return dtPostDate.EditValue == null ? DateTime.Now : (DateTime)dtPostDate.EditValue; }
            set { dtPostDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo
        {
            get { return txtRefNo.Text.Trim(); }
            set { txtRefNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode
        {
            get { return gridViewMaster.GetRowCellValue(0, "CurrencyCode") == null ? GlobalVariable.MainCurrencyId : gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString(); }
            set { gridViewMaster.SetRowCellValue(0, "CurrencyCode", value ?? GlobalVariable.MainCurrencyId); }
        }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
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
        /// <value>
        /// The paralell reference no.
        /// </value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the decision date.
        /// </summary>
        /// <value>
        /// The decision date.
        /// </value>
        public DateTime? DecisionDate
        {
            get { return dtDecisionDate.EditValue == null || string.IsNullOrEmpty(dtDecisionDate.EditValue.ToString()) ? (DateTime?)null : (DateTime)dtDecisionDate.EditValue; }
            set { dtDecisionDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the decision no.
        /// </summary>
        /// <value>
        /// The decision no.
        /// </value>
        public string DecisionNo
        {
            get { return txtDecisionNo.Text.Trim(); }
            set { txtDecisionNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode
        {
            get { return lookUpEditBudgetChapterCode.EditValue == null ? null : lookUpEditBudgetChapterCode.EditValue.ToString(); }
            set { lookUpEditBudgetChapterCode.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [posted].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [posted]; otherwise, <c>false</c>.
        /// </value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
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
        /// <value>
        /// The total amount oc.
        /// </value>
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
        /// Gets or sets the allocation configuration.
        /// </summary>
        /// <value>
        /// The allocation configuration.
        /// </value>
        public int AllocationConfig { get; set; }

        /// <summary>
        /// Gets or sets the bu plan receipt detail models.
        /// </summary>
        /// <value>
        /// The bu plan receipt detail models.
        /// </value>
        public IList<BUPlanReceiptDetailModel> BuPlanReceiptDetailModels
        {
            get
            {
                var buPlanReceiptDetails = new List<BUPlanReceiptDetailModel>();
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    decimal totalAmount = 0;
                    decimal totalAmountOC = 0;
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BUPlanReceiptDetailModel)grdAccountingView.GetRow(i);
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

                            var item = new BUPlanReceiptDetailModel
                            {
                                Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                                Amount = rowVoucher.AmountOC * ExchangeRate,
                                AmountOC = rowVoucher.AmountOC,
                                DebitAccount = rowVoucher.DebitAccount,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                FundStructureId = rowVoucher.FundStructureId,
                                BankId = rowVoucher.BankId,
                                ProjectId = rowVoucher.ProjectId,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetParentItemCode = rowVoucher.BudgetParentItemCode,
                                SortOrder = i
                            };
                            totalAmount += item.Amount;
                            totalAmountOC += item.AmountOC;
                            buPlanReceiptDetails.Add(item);
                        }
                        TotalAmount = totalAmount;
                        TotalAmountOC = totalAmountOC;
                    }
                }
                return buPlanReceiptDetails;
            }
            set
            {
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BUPlanReceiptDetailModel>();
                grdAccountingView.PopulateColumns(value);

                #region columns for grdAccountingView
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 290,
                        ColumnCaption = "Chỉ tiêu",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetGroupItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditDebitAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 3,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Quy đổi",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditBudgetSource,
                        ColumnWith = 80,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 5,
                        AllowEdit = true},
                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem,
                        ColumnWith = 80,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 6,
                        AllowEdit = true},
                    new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Mục",
                        ColumnPosition = 7,
                        IsSummnary = true,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetParentItemCode",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nhóm mục",
                        ColumnPosition = 8,
                        IsSummnary = true,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditFundStructure,
                        ColumnWith = 120,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 9,
                        AllowEdit = true},
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditBank,
                        ColumnWith = 120,
                        ColumnCaption = "Tài khoản NH, KB",
                        ColumnPosition = 10,
                        AllowEdit = true},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditProject,
                        ColumnWith = 120,
                        ColumnCaption = "CTMT, dự án",
                        ColumnPosition = 11,
                        AllowEdit = true},
                    new XtraColumn{ColumnName = "MethodDistributeId", ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        IsLastColumn = true,
                        RepositoryControl = _repositoryMethodDistributeId},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
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
                    new XtraColumn {ColumnName = "DetailBy", ColumnVisible = false}
            };
                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView, grdAccounting);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;
                #endregion
            }
        }
        #endregion

        #region Presenter
        /// <summary>
        /// The s u increment decrements presenter
        /// </summary>
        private readonly BUPlanReceiptPresenter _buPlanReceiptPresenter;

        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        /// <summary>
        /// The _fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;

        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        /// <summary>
        /// The _projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// The _banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// The budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        /// <summary>
        /// The _model
        /// </summary>
        private readonly IModel _model;

        /// <summary>
        /// The _account models
        /// </summary>
        private List<AccountModel> _accountModels;

        #endregion

        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        private GridView _gridLookUpEditBudgetSubKindItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;

        private List<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private GridView _gridLookUpEditBudgetItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        private GridView _gridLookUpEditBudgetSubItemView;

        private List<BudgetItemModel> _budgetItemModels;

        #endregion

        #region private helper

        /// <summary>
        ///     Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>GridView.</returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView, GridControl grid)
        {
            var totalColumnWidth = 0;
            foreach (var column in columnsCollection)
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
                    totalColumnWidth += column.ColumnWith;
                    if (column.IsSummaryText)
                    {
                        grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                        grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                    }
                    if (column.IsLastColumn)
                    {
                        if (grid.Width - totalColumnWidth <= column.ColumnWith)
                            grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                        else
                            grdView.Columns[column.ColumnName].Width = grid.Width - totalColumnWidth + column.ColumnWith;
                    }
                }
                else
                {
                    grdView.Columns[column.ColumnName].Visible = false;
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
        }

        #endregion

        #region overrides
        public FrmBUPlanCancelDetail()
        {
            InitializeComponent();
            _banksPresenter = new BanksPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _buPlanReceiptPresenter = new BUPlanReceiptPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _model = new Model.Model();
        }

        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Location = new Point(9, 176);
            tabMain.Location = new Point(8, 232);
            tabMain.SelectedTabPage = tabInventoryItem;
            tabAccounting.TabControl.ShowTabHeader = DefaultBoolean.False;
        }

        /// <summary>
        ///     Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _budgetKindItemsPresenter.DisplayActive();
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.DisplayActive(true);
            _banksPresenter.DisplayActive(true);
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetItemsPresenter.DisplayActive(true);
            InitRepositoryControlData();
            if (RefId == null)
                DecisionDate = DateTime.Now;
            if (MasterBindingSource != null) if (MasterBindingSource.Current != null)
                    KeyValue = ((BUPlanReceiptModel)MasterBindingSource.Current).RefId;
            _buPlanReceiptPresenter.Display(KeyValue);

            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.BUPlanCancel;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            if (BudgetChapterCode == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetChapterCodeRequired"),
                                       ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                lookUpEditBudgetChapterCode.Focus();
                return false;
            }

            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            var buPlanReceiptDetails = BuPlanReceiptDetailModels;
            if (buPlanReceiptDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            foreach (var buPlanReceiptDetail in BuPlanReceiptDetailModels)
            {
                if (buPlanReceiptDetail.DebitAccount == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDebitAccount"),
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    return false;
                }

                # region Check detail by DebitAccount

                if (buPlanReceiptDetail.DebitAccount != null)
                {
                    //var debitAccount = _accountModels.FirstOrDefault(c => c.AccountNumber == buPlanReceiptDetail.DebitAccount);
                    //var isError = debitAccount.ValidDetailBy(buPlanReceiptDetail.BudgetSourceId, BudgetChapterCode, buPlanReceiptDetail.BudgetSubKindItemCode,
                    //    buPlanReceiptDetail.BudgetItemCode, buPlanReceiptDetail.BudgetSubItemCode, buPlanReceiptDetail.MethodDistributeId,
                    //    null, null, buPlanReceiptDetail.ProjectId, buPlanReceiptDetail.BankId, null, null);
                    //if (!isError)
                    //    return false;
                }
                #endregion
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
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = KeyValue;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = null;
            return _buPlanReceiptPresenter.Save();
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new BUPlanReceiptPresenter(null).Delete(KeyValue);
        }

        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            
            if (e.Column.FieldName == "BudgetItemCode" && e.Value != null)
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    return;
                var parentId = _budgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                var budgetItem = _budgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId);
                if (budgetItem != null)
                {
                    var budgetItemCode = budgetItem.BudgetItemCode;
                    grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetParentItemCode", budgetItemCode);
                }
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
                    };
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSource.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSource.View.BestFitColumns();
                    _gridLookUpEditBudgetSource.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetSource.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetSource.NullText = "";
                    _gridLookUpEditBudgetSource.KeyDown += _gridLookUpEditBudgetSourceView_KeyDown;

                    _gridLookUpEditBudgetSource.DataSource = value;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "BudgetSourceCode",ColumnCaption = "Mã nguồn vốn",ColumnVisible = true,ColumnWith = 100,ColumnPosition = 1},
                            new XtraColumn {ColumnName = "BudgetSourceName",ColumnCaption = "Tên nguồn vốn",ColumnVisible = true,ColumnWith = 250,ColumnPosition = 2}
                        };

                    //XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    //_gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    //_gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";

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
                    AccountLists = value;

                    var debitAccounts = value.ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var creditAccounts = value.ToList().CreditAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var parallelAccounts = value.ToList().ParallelAccounts();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "Số tài khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);

                    #endregion
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
                    };
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubKindItem.View.BestFitColumns();
                    _gridLookUpEditBudgetSubKindItem.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetSubKindItem.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetSubKindItem.NullText = "";
                    _gridLookUpEditBudgetSubKindItem.KeyDown += _gridLookUpEditBudgetSubKindItemView_KeyDown;

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditBudgetSubKindItem.DisplayMember = "BudgetKindItemCode";
                    //_gridLookUpEditBudgetSubKindItem.ValueMember = "BudgetKindItemCode";
                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, _budgetSubKindItemModels, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);
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
                    _gridLookUpEditProject.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditProject.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditProject.NullText = "";
                    _gridLookUpEditProject.KeyDown += _gridLookUpEditProjectView_KeyDown;

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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });
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
                    //_gridLookUpEditProject.DisplayMember = "ProjectCode";
                    //_gridLookUpEditProject.ValueMember = "ProjectId";

                    _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, value, "ProjectCode", "ProjectId", gridColumnsCollection);
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
                    _gridLookUpEditFundStructure.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditFundStructure.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditFundStructure.NullText = "";
                    _gridLookUpEditFundStructure.KeyDown += _gridLookUpEditFundStructureView_KeyDown;

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditFundStructure.DisplayMember = "FundStructureName";
                    //_gridLookUpEditFundStructure.ValueMember = "FundStructureId";

                    _gridLookUpEditProjectView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();
                    _gridLookUpEditFundStructure = XtraColumnCollectionHelper<FundStructureModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, value, "FundStructureCode", "FundStructureId", gridColumnsCollection);
                    XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);

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
                    lookUpEditBudgetChapterCode.Properties.DataSource = value;
                    lookUpEditBudgetChapterCode.Properties.PopulateColumns();

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
                            lookUpEditBudgetChapterCode.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            lookUpEditBudgetChapterCode.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            lookUpEditBudgetChapterCode.Properties.Columns[column.ColumnName].Visible = false;
                    }
                    lookUpEditBudgetChapterCode.Properties.DisplayMember = "BudgetChapterCode";
                    lookUpEditBudgetChapterCode.Properties.ValueMember = "BudgetChapterCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region BudgetItem
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
                if (value == null)
                    return;
                _budgetItemModels = value.ToList();
                var budgetItemModels = value.Where(v => v.BudgetItemType <= 1).ToList();
                var budgetSubItemModels = value.Where(v => v.BudgetItemType == 2).ToList();

                // Tiểu mục


                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã tiểu mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên tiểu mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, budgetSubItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);

                // Mục


                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                _gridLookUpEditBudgetItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemView, budgetItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetItemView);
            }
        }
        #endregion

        #region Control Events

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditAccountView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditDebitAccountView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var account = grdAccountingView.Columns["DebitAccount"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, account, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSourceView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSourceView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceId = grdAccountingView.Columns["BudgetSourceId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceId, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSubKindItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSubKindItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSubKindItemCode = grdAccountingView.Columns["BudgetSubKindItemCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSubKindItemCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditProjectView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditProjectView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var projectId = grdAccountingView.Columns["ProjectId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, projectId, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditFundStructureView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditFundStructureView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var fundStructureId = grdAccountingView.Columns["FundStructureId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, fundStructureId, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the lookUpEditBudgetChapterCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void lookUpEditBudgetChapterCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetChapterCode = grdAccountingView.Columns["BudgetChapterCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetChapterCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the CellValueChanged event of the grdAccountingView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        private void grdAccountingView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (DesignMode)
                    return;
                if (!e.Column.FieldName.Equals("DetailBy"))
                {
                    var debitAccount = grdDetailByInventoryItemView.GetFocusedRowCellValue("DebitAccount");
                    var accountNumberDetailBy = "";
                    if (debitAccount != null)
                    {
                        accountNumberDetailBy = GetAccountDetailBy(debitAccount.ToString());
                    }

                    var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                    var detail = string.Join(";", detailByArray);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DetailBy", detail);
                }
                if (e.Column.FieldName == "BudgetItemCode" && e.Value != null)
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                        return;
                    var parentId = _budgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                    var budgetItem = _budgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId);
                    if (budgetItem != null)
                    {
                        var budgetItemCode = budgetItem.BudgetItemCode;
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetParentItemCode", budgetItemCode);
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the lookUpEditBudgetChapterCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lookUpEditBudgetChapterCode_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditBudgetChapterCode.EditValue == null)
                return;
            var budgetChapterName = (string)lookUpEditBudgetChapterCode.GetColumnValue("BudgetChapterName");
            txtBudgetChapterName.Text = budgetChapterName;
        }

        /// <summary>
        /// Handles the ProcessGridKey event of the grdMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdMaster_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {

                GridControl grid = sender as GridControl;

                GridView view = grid.FocusedView as GridView;

                if ((e.Modifiers == Keys.None && view.IsLastRow && view.FocusedColumn.VisibleIndex == view.VisibleColumns.Count - 1)

                    || (e.Modifiers == Keys.Shift && view.IsFirstRow && view.FocusedColumn.VisibleIndex == 0))
                {

                    if (view.IsEditing)

                        view.CloseEditor();

                    tabAccounting.Focus();
                    grdAccountingView.FocusedColumn = grdAccountingView.Columns[0];

                    e.Handled = true;

                }

            }
        }

        private void lookUpEditBudgetChapterCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBudgetChapter = new FrmBudgetChapterDetail();
                frmBudgetChapter.ShowDialog();
                if (frmBudgetChapter.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetChapterIDAccountingObjectDetailForm))
                    {
                        _budgetChaptersPresenter.DisplayByIsActive(true);
                        lookUpEditBudgetChapterCode.Properties.DisplayMember = "BudgetChapterCode";
                        lookUpEditBudgetChapterCode.Properties.ValueMember = "BudgetChapterId";
                        lookUpEditBudgetChapterCode.EditValue =
                            GlobalVariable.BudgetChapterIDAccountingObjectDetailForm;
                    }
                }
            }
        }
        #endregion
    }
}
