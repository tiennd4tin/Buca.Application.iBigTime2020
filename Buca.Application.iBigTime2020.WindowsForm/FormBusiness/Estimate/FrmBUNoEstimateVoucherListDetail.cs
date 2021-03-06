﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BADeposit;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAPayment;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAReceipt;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.FixedAsset;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.IncrementDecrement;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    public partial class FrmBUNoEstimateVoucherListDetail : FrmXtraBaseVoucherDetail, IBUVoucherListView, IBudgetSourcesView,
        IProjectsView, ICashWithdrawTypesView, IBudgetExpensesView
    {
        public FrmBUNoEstimateVoucherListDetail()
        {
            InitializeComponent();
            _buVoucherListPresenter = new BUVoucherListPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
        }

        #region Helper

        /// <summary>
        ///     Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns></returns>
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

        #endregion

        #region Presenter

        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;
        /// <summary>
        ///     The bu voucher list presenter
        /// </summary>
        private readonly BUVoucherListPresenter _buVoucherListPresenter;

        /// <summary>
        ///     The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        ///     The projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        ///     The cash withdraw types presenter
        /// </summary>
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;

        #endregion

        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;
        /// <summary>
        ///     The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;

        /// <summary>
        ///     The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        ///     The grid look up edit project
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;

        /// <summary>
        ///     The grid look up edit project view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

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

        #endregion

        #region override

        /// <summary>
        ///     Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            InitRepositoryControlData();
            _budgetExpensesPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _projectsPresenter.DisplayActive();
            _cashWithdrawTypesPresenter.DisplayList();
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((BUVoucherListModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((BUVoucherListModel)MasterBindingSource.Current).RefId;
            }

            _buVoucherListPresenter.Display(KeyValue, true, false, true);
            if (RefType == 0)
            {
                RefType = (int)BuCA.Enum.RefType.BUNoEstimateVoucherList;
                grdAccounting.DataSource = new List<BUVoucherListDetailModel>();
            }
        }

        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Visible = false;
            tabTax.Text = @"Hạch toán đồng thời";
            tabMain.SelectedTabPage = tabAccounting;
            dtPostDate.Properties.Mask.EditMask = @"dd/MM/yyyy";
            dtRefDate.Properties.Mask.EditMask = @"dd/MM/yyyy";
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
            //var model = new Model.Model();
            //var bUVoucherList = model.GetBUVoucherListByRefNo(RefNo);
            //if ((bUVoucherList != null && string.IsNullOrEmpty(RefId)) || (bUVoucherList != null && bUVoucherList.RefId == RefId))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefNoBankTranferDuplicate"), detailContent,
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtRefNo.Focus();
            //    return false;
            //}

            var bUVoucherListDetailModels = BUVoucherListDetailModels;
            if (bUVoucherListDetailModels.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = KeyValue;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = null;
            return _buVoucherListPresenter.Save();
        }

        /// <summary>
        ///     Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            _buVoucherListPresenter.Delete(KeyValue);
        }

        /// <summary>
        /// Deletes the row item in banded grid view.
        /// </summary>
        protected override void DeleteRowItemInBandedGridView()
        {
            if (tabMain.SelectedTabPage.Equals(tabAccounting))
            {
                grdTax.DataSource = new List<BUVoucherListDetailTransferModel>();
                var listClause = new List<BUVoucherListDetailTransferModel>();

                if (grdAccounting.DataSource != null && grdAccountingView.RowCount > 0)
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var row = (BUVoucherListDetailModel)grdAccountingView.GetRow(i);
                        if (row == null)
                            continue;
                        if (row.MethodDistributeId == 1)
                        {
                            var items = new BUVoucherListDetailTransferModel
                            {
                                BudgetSourceId = row.BudgetSourceId,
                                Amount = row.Amount,
                                CreditAccount = null,
                                DebitAccount = "013",
                                SortOrder = 0,
                                RefId = row.RefId,
                                ExchangeRate = row.ExchangeRate,
                                CurrencyCode = row.CurrencyCode,
                                CashWithDrawTypeId = 3,
                                Description = row.Description,
                                BankAccount = row.BankAccount,
                                AmountOC = Math.Abs(row.AmountOC.Value),
                                RefDetailId = row.RefDetailId,
                                AccountingObjectId = row.AccountingObjectId,
                                ActivityId = row.ActivityId,
                                BudgetChapterCode = row.BudgetChapterCode,
                                BudgetDetailItemCode = row.BudgetDetailItemCode,
                                BudgetItemCode = row.BudgetItemCode,
                                BudgetKindItemCode = row.BudgetKindItemCode,
                                BudgetProvideCode = row.BudgetProvideCode,
                                BudgetSubItemCode = row.BudgetSubItemCode,
                                BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                FundStructureId = row.FundStructureId,
                                ListItemId = row.ListItemId,
                                MethodDistributeId = row.MethodDistributeId,
                                ProjectActivityEAId = row.ProjectActivityEAId,
                                ProjectActivityId = row.ProjectActivityId,
                                ProjectExpenseEAId = row.ProjectExpenseEAId,
                                ProjectExpenseId = row.ProjectExpenseId,
                                ProjectId = row.ProjectId
                            };
                            listClause.Add(items);
                        }
                        else
                        {
                            if (row.MethodDistributeId == 0)
                            {
                                var debitAccountOne = "";
                                var debitAccountTwo = "";
                                if (row.CreditAccount.StartsWith("6111"))
                                {
                                    debitAccountOne = "008211";
                                    debitAccountTwo = "008212";
                                    listClause.Add(new BUVoucherListDetailTransferModel
                                    {
                                        BudgetSourceId = row.BudgetSourceId,
                                        Amount = row.Amount,
                                        CreditAccount = null,
                                        DebitAccount = debitAccountOne,
                                        SortOrder = 0,
                                        RefId = row.RefId,
                                        ExchangeRate = row.ExchangeRate,
                                        CurrencyCode = row.CurrencyCode,
                                        CashWithDrawTypeId = 3,
                                        Description = row.Description,
                                        BankAccount = row.BankAccount,
                                        AmountOC = Math.Abs(row.AmountOC.Value) * -1,
                                        RefDetailId = row.RefDetailId,
                                        AccountingObjectId = row.AccountingObjectId,
                                        ActivityId = row.ActivityId,
                                        BudgetChapterCode = row.BudgetChapterCode,
                                        BudgetDetailItemCode = row.BudgetDetailItemCode,
                                        BudgetItemCode = row.BudgetItemCode,
                                        BudgetKindItemCode = row.BudgetKindItemCode,
                                        BudgetProvideCode = row.BudgetProvideCode,
                                        BudgetSubItemCode = row.BudgetSubItemCode,
                                        BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                        FundStructureId = row.FundStructureId,
                                        ListItemId = row.ListItemId,
                                        MethodDistributeId = row.MethodDistributeId,
                                        ProjectActivityEAId = row.ProjectActivityEAId,
                                        ProjectActivityId = row.ProjectActivityId,
                                        ProjectExpenseEAId = row.ProjectExpenseEAId,
                                        ProjectExpenseId = row.ProjectExpenseId,
                                        ProjectId = row.ProjectId
                                    });
                                    listClause.Add(new BUVoucherListDetailTransferModel
                                    {
                                        BudgetSourceId = row.BudgetSourceId,
                                        Amount = row.Amount,
                                        CreditAccount = null,
                                        DebitAccount = debitAccountTwo,
                                        SortOrder = 0,
                                        RefId = row.RefId,
                                        ExchangeRate = row.ExchangeRate,
                                        CurrencyCode = row.CurrencyCode,
                                        CashWithDrawTypeId = 3,
                                        Description = row.Description,
                                        BankAccount = row.BankAccount,
                                        AmountOC = Math.Abs(row.AmountOC.Value),
                                        RefDetailId = row.RefDetailId,
                                        AccountingObjectId = row.AccountingObjectId,
                                        ActivityId = row.ActivityId,
                                        BudgetChapterCode = row.BudgetChapterCode,
                                        BudgetDetailItemCode = row.BudgetDetailItemCode,
                                        BudgetItemCode = row.BudgetItemCode,
                                        BudgetKindItemCode = row.BudgetKindItemCode,
                                        BudgetProvideCode = row.BudgetProvideCode,
                                        BudgetSubItemCode = row.BudgetSubItemCode,
                                        BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                        FundStructureId = row.FundStructureId,
                                        ListItemId = row.ListItemId,
                                        MethodDistributeId = row.MethodDistributeId,
                                        ProjectActivityEAId = row.ProjectActivityEAId,
                                        ProjectActivityId = row.ProjectActivityId,
                                        ProjectExpenseEAId = row.ProjectExpenseEAId,
                                        ProjectExpenseId = row.ProjectExpenseId,
                                        ProjectId = row.ProjectId
                                    });
                                }
                                if (row.CreditAccount.StartsWith("6112"))
                                {
                                    debitAccountOne = "008221";
                                    debitAccountTwo = "008222";
                                    listClause.Add(new BUVoucherListDetailTransferModel
                                    {
                                        BudgetSourceId = row.BudgetSourceId,
                                        Amount = row.Amount,
                                        CreditAccount = null,
                                        DebitAccount = debitAccountOne,
                                        SortOrder = 0,
                                        RefId = row.RefId,
                                        ExchangeRate = row.ExchangeRate,
                                        CurrencyCode = row.CurrencyCode,
                                        CashWithDrawTypeId = 3,
                                        Description = row.Description,
                                        BankAccount = row.BankAccount,
                                        AmountOC = Math.Abs(row.AmountOC.Value) * -1,
                                        RefDetailId = row.RefDetailId,
                                        AccountingObjectId = row.AccountingObjectId,
                                        ActivityId = row.ActivityId,
                                        BudgetChapterCode = row.BudgetChapterCode,
                                        BudgetDetailItemCode = row.BudgetDetailItemCode,
                                        BudgetItemCode = row.BudgetItemCode,
                                        BudgetKindItemCode = row.BudgetKindItemCode,
                                        BudgetProvideCode = row.BudgetProvideCode,
                                        BudgetSubItemCode = row.BudgetSubItemCode,
                                        BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                        FundStructureId = row.FundStructureId,
                                        ListItemId = row.ListItemId,
                                        MethodDistributeId = row.MethodDistributeId,
                                        ProjectActivityEAId = row.ProjectActivityEAId,
                                        ProjectActivityId = row.ProjectActivityId,
                                        ProjectExpenseEAId = row.ProjectExpenseEAId,
                                        ProjectExpenseId = row.ProjectExpenseId,
                                        ProjectId = row.ProjectId
                                    });
                                    listClause.Add(new BUVoucherListDetailTransferModel
                                    {
                                        BudgetSourceId = row.BudgetSourceId,
                                        Amount = row.Amount,
                                        CreditAccount = null,
                                        DebitAccount = debitAccountTwo,
                                        SortOrder = 0,
                                        RefId = row.RefId,
                                        ExchangeRate = row.ExchangeRate,
                                        CurrencyCode = row.CurrencyCode,
                                        CashWithDrawTypeId = 3,
                                        Description = row.Description,
                                        BankAccount = row.BankAccount,
                                        AmountOC = Math.Abs(row.AmountOC.Value),
                                        RefDetailId = row.RefDetailId,
                                        AccountingObjectId = row.AccountingObjectId,
                                        ActivityId = row.ActivityId,
                                        BudgetChapterCode = row.BudgetChapterCode,
                                        BudgetDetailItemCode = row.BudgetDetailItemCode,
                                        BudgetItemCode = row.BudgetItemCode,
                                        BudgetKindItemCode = row.BudgetKindItemCode,
                                        BudgetProvideCode = row.BudgetProvideCode,
                                        BudgetSubItemCode = row.BudgetSubItemCode,
                                        BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                        FundStructureId = row.FundStructureId,
                                        ListItemId = row.ListItemId,
                                        MethodDistributeId = row.MethodDistributeId,
                                        ProjectActivityEAId = row.ProjectActivityEAId,
                                        ProjectActivityId = row.ProjectActivityId,
                                        ProjectExpenseEAId = row.ProjectExpenseEAId,
                                        ProjectExpenseId = row.ProjectExpenseId,
                                        ProjectId = row.ProjectId
                                    });
                                }
                            }
                        }
                    }
                grdTax.DataSource = listClause;
                grdTaxView.RefreshData();
            }
        }
        
        #endregion

        #region IView

        #region BUVoucherList

        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        ///     The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        ///     Gets or sets the reference date.
        /// </summary>
        /// <value>
        ///     The reference date.
        /// </value>
        public DateTime RefDate
        {
            get { return dtRefDate.EditValue == null ? DateTime.Now : (DateTime)dtRefDate.EditValue; }
            set { dtRefDate.EditValue = value; }
        }

        /// <summary>
        ///     Gets or sets the posted date.
        /// </summary>
        /// <value>
        ///     The posted date.
        /// </value>
        public DateTime PostedDate
        {
            get { return dtPostDate.EditValue == null ? DateTime.Now : (DateTime)dtPostDate.EditValue; }
            set { dtPostDate.EditValue = value; }
        }

        /// <summary>
        ///     Gets or sets the reference no.
        /// </summary>
        /// <value>
        ///     The reference no.
        /// </value>
        public string RefNo
        {
            get { return txtRefNo.Text.Trim(); }
            set { txtRefNo.Text = value; }
        }

        /// <summary>
        ///     Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        ///     The paralell reference no.
        /// </value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        ///     Gets or sets from date.
        /// </summary>
        /// <value>
        ///     From date.
        /// </value>
        public DateTime FromDate { get; set; }

        /// <summary>
        ///     Gets or sets to date.
        /// </summary>
        /// <value>
        ///     To date.
        /// </value>
        public DateTime ToDate { get; set; }

        /// <summary>
        ///     Gets or sets the journal memo.
        /// </summary>
        /// <value>
        ///     The journal memo.
        /// </value>
        public string JournalMemo
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="!:BUVoucherListEntity" /> is posted.
        /// </summary>
        /// <value>
        ///     <c>true</c> if posted; otherwise, <c>false</c>.
        /// </value>
        public bool Posted { get; set; }

        /// <summary>
        ///     Gets or sets the total amount.
        /// </summary>
        /// <value>
        ///     The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        ///     Gets or sets the post version.
        /// </summary>
        /// <value>
        ///     The post version.
        /// </value>
        public int? PostVersion { get; set; }

        /// <summary>
        ///     Gets or sets the edit version.
        /// </summary>
        /// <value>
        ///     The edit version.
        /// </value>
        public int? EditVersion { get; set; }

        /// <summary>
        ///     Gets or sets the bu voucher list detail models.
        /// </summary>
        /// <value>
        ///     The bu voucher list detail models.
        /// </value>
        public IList<BUVoucherListDetailModel> BUVoucherListDetailModels
        {
            get
            {
                var bUVoucherListDetails = new List<BUVoucherListDetailModel>();
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    decimal totalAmount = 0;
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BUVoucherListDetailModel)grdAccountingView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            rowVoucher.SortOrder = i;
                            totalAmount += rowVoucher.Amount; // item.Amount;
                            bUVoucherListDetails.Add(rowVoucher); // (item);
                        }
                        TotalAmount = totalAmount;
                    }
                }
                return bUVoucherListDetails;
            }
            set
            {
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BUVoucherListDetailModel>();
                grdAccountingView.PopulateColumns(value);
                grdAccountingDetailView.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "VoucherRefDetailId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "VoucherRefId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseEAId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityEAId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số CT",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 150
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày CT",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 150
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DebitAccount",
                    ColumnCaption = "TK Nợ",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CreditAccount",
                    ColumnCaption = "TK Có",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnCaption = "Số Tiền",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceId",
                    ColumnCaption = "Nguồn",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    RepositoryControl = _gridLookUpEditBudgetSource
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Chương",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetKindItemCode",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Loại",
                    IsSummnary = false,
                    ColumnPosition = 8,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSubKindItemCode",
                    ColumnCaption = "Khoản",
                    ColumnPosition = 9,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSubItemCode",
                    ColumnCaption = "Tiểu Mục",
                    ColumnPosition = 10,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục",
                    ColumnPosition = 11,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn Giải",
                    ColumnPosition = 12,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "MethodDistributeId",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Cấp phát",
                    ColumnPosition = 13,
                    AllowEdit = true,
                    RepositoryControl = _repositoryMethodDistributeId
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CashWithDrawTypeId",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Nghiệp vụ",
                    ColumnPosition = 14,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditCashWithdrawType
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetExpenseId",
                    ColumnVisible = true,
                    ColumnWith = 200,
                    ColumnCaption = "Phí lệ phí",
                    ColumnPosition = 15,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpBudgetExpense
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectId",
                    ColumnCaption = "CTMT,Dự Án",
                    ColumnPosition = 16,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    RepositoryControl = _gridLookUpEditProject
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PostedDate",
                    ColumnVisible = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgRefNo",
                    ColumnCaption = "Số CT Gốc",
                    ColumnPosition = 16,
                    ColumnVisible = false,
                    ColumnWith = 150
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgRefDate",
                    ColumnCaption = "Ngày CT Gốc",
                    ColumnPosition = 15,
                    ColumnVisible = true,
                    ColumnWith = 150
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VoucherRefType",
                    ColumnCaption = "Loại chứng từ",
                    ColumnPosition = 1,
                    ColumnVisible = false,
                    ColumnWith = 200,
                    FixedColumn = FixedStyle.Left,
                    RepositoryControl = GridLookUpEditRefType,
                    AllowEdit = true
                });
                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;
            }
        }

        /// <summary>
        ///     Gets or sets the bu voucher list detail parallel models.
        /// </summary>
        /// <value>
        ///     The bu voucher list detail parallel models.
        /// </value>
        public IList<BUVoucherListDetailParallelModel> BUVoucherListDetailParallelModels { get; set; }

        /// <summary>
        ///     Gets or sets the bu voucher list detail transfer models.
        /// </summary>
        /// <value>
        ///     The bu voucher list detail transfer models.
        /// </value>
        public IList<BUVoucherListDetailTransferModel> BUVoucherListDetailTransferModels
        {
            get
            {
                var bUVoucherListDetailTransfers = new List<BUVoucherListDetailTransferModel>();
                if (grdTaxView.DataSource != null && grdTaxView.RowCount > 0)
                    for (var i = 0; i < grdTaxView.RowCount; i++)
                    {
                        var rowVoucher = (BUVoucherListDetailTransferModel)grdTaxView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            bUVoucherListDetailTransfers.Add(rowVoucher); // (item);
                            rowVoucher.SortOrder = i;
                        }
                    }
                return bUVoucherListDetailTransfers;
            }
            set
            {
                grdTax.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BUVoucherListDetailTransferModel>();
                grdTaxView.PopulateColumns(value);
                grdTaxView.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseEAId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityEAId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceId",
                    ColumnCaption = "Nguồn",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    RepositoryControl = _gridLookUpEditBudgetSource
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Chương",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetKindItemCode",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Loại",
                    IsSummnary = false,
                    ColumnPosition = 3,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSubKindItemCode",
                    ColumnCaption = "Khoản",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSubItemCode",
                    ColumnCaption = "Tiểu Mục",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn Giải",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "MethodDistributeId",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Cấp phát",
                    ColumnPosition = 8,
                    AllowEdit = true,
                    RepositoryControl = _repositoryMethodDistributeId
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CashWithDrawTypeId",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Nghiệp vụ",
                    ColumnPosition = 9,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditCashWithdrawType
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnCaption = "Số Tiền",
                    ColumnPosition = 10,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    ColumnType = UnboundColumnType.Decimal,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DebitAccount",
                    ColumnCaption = "TK Có",
                    ColumnPosition = 11,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CreditAccount",
                    ColumnCaption = "TK Nợ",
                    ColumnPosition = 12,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn Giải",
                    ColumnPosition = 13,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgRefNo",
                    ColumnCaption = "Số CT Gốc",
                    ColumnPosition = 14,
                    ColumnVisible = false,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetExpenseId",
                    ColumnVisible = true,
                    ColumnWith = 200,
                    ColumnCaption = "Phí lệ phí",
                    ColumnPosition = 15,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpBudgetExpense
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgRefDate",
                    ColumnCaption = "Ngày CT Gốc",
                    ColumnPosition = 16,
                    ColumnVisible = false,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectId",
                    ColumnCaption = "CTMT,Dự Án",
                    ColumnPosition = 14,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    RepositoryControl = _gridLookUpEditProject
                });
                grdTaxView = InitGridLayout(columnsCollection, grdTaxView);
                SetNumericFormatControl(grdTaxView, true);
                grdTaxView.OptionsView.ShowFooter = false;
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

        #endregion

        #region Projects

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
                    var projects = value.OrderBy(c => c.ProjectCode).ToList();

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

                    _gridLookUpEditProject.DataSource = projects;
                    _gridLookUpEditProjectView.PopulateColumns(projects);
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
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectEnglishName",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });
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

        public string CurrencyCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal ExchangeRate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal TotalAmountOC { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion
        #endregion

        /// <summary>
        /// Handles the Click event of the btnSelectVoucher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSelectVoucher_Click(object sender, EventArgs e)
        {
            if (ActionMode != ActionModeVoucherEnum.AddNew && ActionMode != ActionModeVoucherEnum.Edit)
                return;

            using (var frmParam = new FrmBUVoucherListDetailParameter(FromDate, ToDate, BUVoucherListDetailModels,"02"))
            {
                frmParam.Text = @"Chọn chứng từ";
                if (frmParam.ShowDialog() == DialogResult.OK)
                {
                    FromDate = frmParam.FromDate;
                    ToDate = frmParam.ToDate;
                    var bUVoucherListDetailModels = new List<BUVoucherListDetailModel>();
                    if (grdAccounting.DataSource != null && grdAccountingView.RowCount > 0)
                        for (var i = 0; i < grdAccountingView.RowCount; i++)
                        {
                            var row = (BUVoucherListDetailModel)grdAccountingView.GetRow(i);
                            if (row == null)
                                continue;
                            bUVoucherListDetailModels.Add(row);
                        }
                    bUVoucherListDetailModels.AddRange(frmParam.BUVoucherListDetailModels);
                    grdAccounting.DataSource = bUVoucherListDetailModels;
                    grdAccounting.RefreshDataSource();
                    grdAccountingView.RefreshData();
                    var bUVoucherListDetailTransferModels = new List<BUVoucherListDetailTransferModel>();
                    if (grdTax.DataSource != null && grdTaxView.RowCount > 0)
                        for (var i = 0; i < grdTaxView.RowCount; i++)
                        {
                            var row = (BUVoucherListDetailTransferModel)grdTaxView.GetRow(i);
                            if (row == null)
                                continue;
                            bUVoucherListDetailTransferModels.Add(row);
                        }
                    bUVoucherListDetailTransferModels.AddRange(frmParam.BUVoucherListDetailTransferModels);
                    grdTax.DataSource = bUVoucherListDetailTransferModels;
                    grdTax.RefreshDataSource();
                    grdTaxView.RefreshData();
                }
            }
        }

        /// <summary>
        /// Shows the form detail.
        /// </summary>
        /// <param name="item">The item.</param>
        void ShowFormDetail(BUVoucherListDetailModel item)
        {
            FrmBaseVoucherList frmList = new FrmBaseVoucherList();
            try
            {
                FrmXtraBaseVoucherDetail frmDetail = null;

                switch (item.VoucherRefType)
                {
                    case (int)BuCA.Enum.RefType.BUPlanReceiptEarlyYear: //51
                    case (int)BuCA.Enum.RefType.BUPlanReceiptAddition: //52
                        frmDetail = new FrmBUPlanReceiptDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUPlanWithDrawCash: //54
                        frmDetail = new FrmBUPlanWithdrawCashDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUPlanWithDrawTransfer: //55
                        frmDetail = new FrmBUPlanWithDrawTransferDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUTransfer: //56
                        frmDetail = new FrmBUTransferDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUPlanCancel: //69
                        frmDetail = new FrmBUPlanCancelDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUBudgetReserve: //73
                        frmDetail = new FrmBUBudgetReserveDetail();
                        break;

                    case (int)BuCA.Enum.RefType.CAReceipt: //101
                        frmDetail = new FrmCAReceiptDetail();
                        break;

                    case (int)BuCA.Enum.RefType.CAReceiptEstimate: //105
                        frmDetail = new FrmCAReceiptEstimateDetail();
                        break;

                    case (int)BuCA.Enum.RefType.CAPayment: //106
                        frmDetail = new FrmCAPaymentDetail();
                        break;

                    case (int)BuCA.Enum.RefType.CAPaymentTreasury: //113
                        frmDetail = new FrmCAPaymentTreasuryDetail();
                        break;

                    case (int)BuCA.Enum.RefType.CAReceiptTreasury: //114
                        frmDetail = new FrmCAReceiptTreasuryDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BADeposit: //153
                        frmDetail = new FrmBADepositDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BAWithDraw: //157
                        frmDetail = new FrmBAWithDrawDetail();
                        break;

                    case (int)BuCA.Enum.RefType.INInward: //201
                        frmDetail = new FrmINInwardDetail();
                        break;

                    case (int)BuCA.Enum.RefType.INOutward: //202
                        frmDetail = new FrmINOutwardDetail();
                        break;

                    case (int)BuCA.Enum.RefType.SUTransfer: //207
                        frmDetail = new FrmSUTransferDetail();
                        break;

                    case (int)BuCA.Enum.RefType.FADecrement: //253
                        frmDetail = new FrmFADecrementDetail();
                        break;

                    case (int)BuCA.Enum.RefType.FADepreciation: //255
                        frmDetail = new FrmFADepreciationDetail();
                        break;

                    case (int)BuCA.Enum.RefType.GLVoucher: //401
                        frmDetail = new FrmGLVoucherDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUTransferDeposits: //561
                        frmDetail = new FrmBUTransferDepositDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUPlanWithDrawDeposit: //562
                        frmDetail = new FrmBUPlanWithDrawDepositDetail();
                        break;
                }
                if (frmDetail == null)
                    return;
                frmDetail.ActionMode = ActionModeVoucherEnum.None;
                frmDetail.KeyValue = item.VoucherRefId;
                frmDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnShowVoucherDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnShowVoucherDetail_Click(object sender, EventArgs e)
        {
            var item = (BUVoucherListDetailModel)grdAccountingView.GetFocusedRow();
            if (item == null)
                return;
            ShowFormDetail(item);
        }

        /// <summary>
        /// Handles the Click event of the btnDeeteVoucher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDeeteVoucher_Click(object sender, EventArgs e)
        {
            if (tabMain.SelectedTabPage == tabAccounting)
                grdAccountingView.DeleteSelectedRows();
            else
            {
                grdTaxView.DeleteSelectedRows();
            }
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            base.SetEnableGroupBox(isEnable);
            EnableControlsInGroup(groupObject, isEnable);
        }
    }
}
