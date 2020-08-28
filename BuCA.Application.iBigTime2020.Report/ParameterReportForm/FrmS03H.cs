using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    public partial class FrmS03H : FrmXtraBaseParameter, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IAccountsView
    {
        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>
        /// The selection.
        /// </value>
        internal GridCheckMarksSelection Selection { get; private set; }

        /// <summary>
        /// Gets the select budget.
        /// </summary>
        /// <value>
        /// The select budget.
        /// </value>
        internal GridCheckMarksSelection SelectBudget { get; private set; }

        #region Presenter
        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        #endregion

        #region Variable
        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget source.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is summary budget source; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryBudgetSource
        {
            get
            {
                if (Convert.ToString(checkcboBudgetSource.EditValue).Contains("00000000-0000-0000-0000-000000000000"))
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public string StartDate
        {
            get { return GlobalVariable.StartedDate; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget chapter.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is summary budget chapter; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryBudgetChapter
        {
            get
            {
                if (Convert.ToString(checkcboBudgetChapter.EditValue).Contains("<<Tổng hợp>>"))
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget sub kind item.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is summary budget sub kind item; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryBudgetSubKindItem
        {
            get
            {
                if (Convert.ToString(checkcboBudgetKindItem.EditValue).Contains("<<Tổng hợp>>"))
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is print all year and month13.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is print all year and month13; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrintAllYearAndMonth13
        {
            get { return chkIsPrintAllYearAndMonth13.Checked; }
        }

        public bool IsDetail { get { return ckbDetail.Checked; } }

        /// <summary>
        /// Gets a value indicating whether this instance is print month13.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is print month13; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrintMonth13
        {
            get { return chkpIsPrintMonth13.Checked; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [add same entry].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [add same entry]; otherwise, <c>false</c>.
        /// </value>
        public bool AddSameEntry
        {
            get { return checkAddSameEntry.Checked; }
        }
        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode
        {
            get
            {                
                if (checkcboBudgetSource.EditValue.ToString() == @"<<Tổng hợp>>" ||
                    checkcboBudgetSource.EditValue.ToString() == @"<<Tất cả>>")
                {
                    return null;
                }
                else
                    return "," + checkcboBudgetSource.EditValue.ToString() + ",";
            }
        }
        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode
        {
            get
            {
                var sBudgetChapterCode = Convert.ToString(checkcboBudgetChapter.EditValue);
                if (string.IsNullOrEmpty(sBudgetChapterCode) ||
                    sBudgetChapterCode.Contains("<<Tổng hợp>>") ||
                    sBudgetChapterCode.Contains("<<Tất cả>>"))
                {
                    return null;
                }
                else
                    return "," + checkcboBudgetChapter.EditValue.ToString() + ",";
            }
        }
        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        /// The budget kind item code.
        /// </value>
        public string BudgetKindItemCode
        {
            get
            {
                var sBudgetKindItemCode = Convert.ToString(checkcboBudgetKindItem.EditValue);
                if (string.IsNullOrEmpty(sBudgetKindItemCode) ||
                    sBudgetKindItemCode.Contains("<<Tổng hợp>>") ||
                    sBudgetKindItemCode.Contains("<<Tất cả>>"))
                {
                    return null;
                }
                else
                    return "," + checkcboBudgetKindItem.EditValue.ToString() + ",";
            }
        }

        /// <summary>
        /// Gets the account list.
        /// </summary>
        /// <value>
        /// The account list.
        /// </value>
        public string AccountList
        {
            get
            {
                var clause = GetClause();
                return clause;
            }
        }

        /// <summary>
        /// Gets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }
        /// <summary>
        /// Gets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }
        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS03H" /> class.
        /// </summary>

        public FrmS03H()
        {
            InitializeComponent();
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
        }

        #region IView
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
                var result = new List<BudgetChapterModel>
                {
                    new BudgetChapterModel {BudgetChapterCode = "<<Tổng hợp>>", BudgetChapterName = "<<Tổng hợp>>"},
                    new BudgetChapterModel {BudgetChapterCode = "<<Tất cả>>", BudgetChapterName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                checkcboBudgetChapter.Properties.DataSource = result;
                checkcboBudgetChapter.Properties.DisplayMember = "BudgetChapterName";
                checkcboBudgetChapter.Properties.ValueMember = "BudgetChapterCode";
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
                var result = new List<BudgetKindItemModel>
                {
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tổng hợp>>", BudgetKindItemName = "<<Tổng hợp>>"},
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tất cả>>", BudgetKindItemName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                checkcboBudgetKindItem.Properties.DataSource = result;
                checkcboBudgetKindItem.Properties.DisplayMember = "BudgetKindItemName";
                checkcboBudgetKindItem.Properties.ValueMember = "BudgetKindItemCode";
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
                var result = new List<BudgetSourceModel>
                {
                    new BudgetSourceModel {BudgetSourceId = "00000000-0000-0000-0000-000000000000", BudgetSourceCode = "<<Tổng hợp>>", BudgetSourceName = "<<Tổng hợp>>"},
                    new BudgetSourceModel { BudgetSourceId = "10000000-0000-0000-0000-000000000000", BudgetSourceCode = "<<Tất cả>>", BudgetSourceName = "<<Tất cả>>" }
                };
                result.AddRange(value);
                checkcboBudgetSource.Properties.DataSource = result;
                checkcboBudgetSource.Properties.DisplayMember = "BudgetSourceName";
                checkcboBudgetSource.Properties.ValueMember = "BudgetSourceId";
            }
        }

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
                bindingSource.DataSource = value ?? new List<AccountModel>();
                gridviewAccount.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "Số tài khoản",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountName",
                    ColumnCaption = "Tên tài khỏan",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false, });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetExpense", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByContract", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByExpense", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCapitalPlan", ColumnVisible = false });


                gridviewAccount = InitGridLayout(columnsCollection, gridviewAccount);
                gridviewAccount.OptionsView.ShowFooter = false;
            }
        }

        #endregion

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns></returns>
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
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = @"Tổng cộng";
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
        /// Handles the Load event of the FrmS03H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmS03H_Load(object sender, EventArgs e)
        {
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.Display();
            checkAddSameEntry.Checked = false;

            dateTimeRangeV1.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;

            checkcboBudgetSource.SetEditValue(@"00000000-0000-0000-0000-000000000000");
            checkcboBudgetChapter.EditValue = "<<Tổng hợp>>";
            checkcboBudgetKindItem.EditValue = "<<Tổng hợp>>";

            Selection = new GridCheckMarksSelection(gridviewAccount);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            gridviewAccount.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridviewAccount.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rndOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rndOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rndOption.SelectedIndex == 0)
            {
                checkcboBudgetSource.EditValue = "<<Tất cả>>";
                checkcboBudgetChapter.EditValue = "<<Tất cả>>";
                checkcboBudgetKindItem.EditValue = "<<Tất cả>>";
            }
            if (rndOption.SelectedIndex == 1)
            {
                checkcboBudgetSource.EditValue = "<<Tổng hợp>>";
                checkcboBudgetChapter.EditValue = "<<Tổng hợp>>";
                checkcboBudgetKindItem.EditValue = "<<Tổng hợp>>";
            }
        }

        /// <summary>
        /// Gets the clause.
        /// </summary>
        /// <returns></returns>
        private string GetClause()
        {
            string Clause = ",";

            if (gridviewAccount.DataSource != null && gridviewAccount.RowCount > 0)
            {
                for (var i = 0; i < gridviewAccount.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (AccountModel)gridviewAccount.GetRow(i);
                        Clause = Clause + row.AccountNumber + ",";
                    }
                }
            }
            return Clause;
        }

        /// <summary>
        /// Gets the budget source.
        /// </summary>
        /// <returns></returns>
        private string GetBudgetSource()
        {
            string Clause = ",";

            if (gridviewAccount.DataSource != null && gridviewAccount.RowCount > 0)
            {
                for (var i = 0; i < gridviewAccount.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (BudgetKindItemModel)gridviewAccount.GetRow(i);
                        Clause = Clause + row.BudgetKindItemCode + ",";
                    }
                }
            }
            return Clause;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            var selectedItem = 0;
            if (gridviewAccount.DataSource != null && gridviewAccount.RowCount > 0)
            {
                for (var i = 0; i < gridviewAccount.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        selectedItem += 1;
                    }
                }
                if (selectedItem <= 0)
                {
                    XtraMessageBox.Show("Bạn chưa chọn tài khoản!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

            }
            return true;
        }

    }
}
