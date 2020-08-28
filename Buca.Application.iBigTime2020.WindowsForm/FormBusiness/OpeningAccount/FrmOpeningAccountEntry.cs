/***********************************************************************
 * <copyright file="FrmOpeningAccountEntry.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungNS
 * Email:    tungns@buca.vn
 * Website:
 * Create Date: 
 * Usage: 
 * 
 * RevisionHistory: 
 * Date   Friday, April 20, 2018      Author      Tudt         Description
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Opening;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.OpeningAccountEntry;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.OpeningAccount
{
    /// <summary>
    /// Class FrmOpeningAccountEntry.
    /// </summary>
    public partial class FrmOpeningAccountEntry : FrmBaseTreeList, IOpeningAccountEntriesView, IAccountView
    {
        /// <summary>
        /// The _opening account entries presenter
        /// </summary>
        private readonly OpeningAccountEntriesPresenter _openingAccountEntriesPresenter;
        private readonly AccountPresenter _accountPresenter;


        /// <summary>
        /// The _repository item date edit
        /// </summary>
        private readonly RepositoryItemDateEdit _repositoryItemDateEdit = new RepositoryItemDateEdit();

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmOpeningAccountEntry"/> class.
        /// </summary>
        public FrmOpeningAccountEntry()
        {
            InitializeComponent();
            _openingAccountEntriesPresenter = new OpeningAccountEntriesPresenter(this);
            _accountPresenter = new AccountPresenter(this);

            // Ẩn các nút thêm, xóa, tìm
            this.VisibleButtonAddNew = false;
            this.VisibleButtonDelete = false;
            this.VisibleButtonFind = false;
            //bar1.Manager.Items["barButtonPrintItem"].Visibility = BarItemVisibility.Never;
        }

        /// <summary>
        /// Sets the opening account entries.
        /// </summary>
        /// <value>The opening account entries.</value>
        public IList<OpeningAccountEntryModel> OpeningAccountEntries
        {
            set
            {
                treeList.DataSource = value;
                treeList.PopulateColumns();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnVisible = true });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Số tài khoản",
                    ColumnPosition = 1,
                    AllowEdit = true,
                    IsSummnary = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountName",
                    ColumnVisible = true,
                    ColumnWith = 250,
                    ColumnCaption = "Tên tài khoản",
                    ColumnPosition = 3,
                    AllowEdit = true,
                    IsSummnary = true
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingCateObjectCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccBeginningDebitAmountOC", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DebitAmountOC",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Dư nợ",
                    ColumnPosition = 4,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.Decimal,
                    IsSummnary = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CreditAmountOC",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Dư có",
                    ColumnPosition = 5,
                    AllowEdit = true,
                    IsSummnary = true,
                    ColumnType = UnboundColumnType.Decimal,
                });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingCateObjectCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccBeginningDebitAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccBeginningCreditAmountOC", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccBeginningCreditAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TaskId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ApprovedDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityEAID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractId", ColumnVisible = false });
                //gridView = InitGridLayout(ColumnsCollection, gridView);
                //SetNumericFormatControl(gridView, true);
                //gridView.OptionsView.ShowFooter = false;
            }
            get
            {
                var openingAccountEntryDetails = new List<OpeningAccountEntryModel>();
                return openingAccountEntryDetails;
            }
        }

        //protected override void LoadDataIntoGrid()
        //{
        //    _openingAccountEntriesPresenter.Display();
        //}

        /// <summary>
        /// Loads the data into tree.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _openingAccountEntriesPresenter.Display();
        }

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
            return grdView;
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns>FrmXtraBaseTreeDetail.</returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            _accountPresenter.Display(PrimaryKeyValue);
            if (DetailByFixedAsset)
            {
                XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResAccountOpenFixedAsset"), AccountNumber), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return new FrmOpeningFixedAssetEntryDetail();
                return null;
            }
            return new FrmOpeningAccountEntryDetail();
        }

        #region Account View
        public string AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountCategoryId { get; set; }
        public string ParentId { get; set; }
        public string AccountName { get; set; }
        public string AccountForeignName { get; set; }
        public string Description { get; set; }
        public int AccountCategoryKind { get; set; }
        public bool DetailByBudgetSource { get; set; }
        public bool DetailByBudgetChapter { get; set; }
        public bool DetailByBudgetKindItem { get; set; }
        public bool DetailByBudgetItem { get; set; }
        public bool DetailByBudgetSubItem { get; set; }
        public bool DetailByMethodDistribute { get; set; }
        public bool DetailByAccountingObject { get; set; }
        public bool DetailByActivity { get; set; }
        public bool DetailByProject { get; set; }
        public bool DetailByTask { get; set; }
        public bool DetailBySupply { get; set; }
        public bool DetailByInventoryItem { get; set; }
        public bool DetailByFixedAsset { get; set; }
        public bool DetailByFund { get; set; }
        public bool DetailByBankAccount { get; set; }
        public bool DetailByProjectActivity { get; set; }
        public bool DetailByInvestor { get; set; }
        public int Grade { get; set; }
        public bool IsParent { get; set; }
        public bool IsActive { get; set; }
        public bool IsDisplayOnAccountBalanceSheet { get; set; }
        public bool IsDisplayBalanceOnReport { get; set; }
        public bool DetailByCurrency { get; set; }
        public bool DetailByBudgetExpense { get; set; }
        public bool DetailByExpense { get; set; }
        public bool DetailByContract { get; set; }
        public bool DetailByCapitalPlan { get; set; }

        /// <summary>
        /// Thêm mới cũng như sửa
        /// </summary>
        protected override void AddData()
        {
            EditData();
        }
        #endregion
        ///<summary>
        ///Validate edited
        /// </summary>
        protected override bool ValidEdit()
        {
            try
            {
                if (!GlobalVariable.IsPostToParentAccount)
                {
                    PrimaryKeyValue = treeList.Nodes.Count > 0
                                          ? treeList.FocusedNode[treeList.KeyFieldName].ToString()
                                          : null;
                    if (PrimaryKeyValue != null && treeList.FindNodeByKeyID(PrimaryKeyValue).HasChildren)
                    {
                        XtraMessageBox.Show(
                            ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryListIsPostToParentAccount"),
                            ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else
                {
                    PrimaryKeyValue = treeList.Nodes.Count > 0
                      ? treeList.FocusedNode[treeList.KeyFieldName].ToString()
                      : null;
                }

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResDeleteCaption"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
    }
}
