using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmGLVoucherListLedger : FrmXtraBaseParameter, IBudgetChaptersView, IBudgetKindItemsView, IBudgetSourcesView,IAccountsView

    {
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        internal GridCheckMarksSelection Selection { get; private set; }
        public DateTime FromDate
        {
            get { return dateTimeRangeV1.FromDate; }

        }

        public DateTime ToDate
        {
            get { return dateTimeRangeV1.ToDate; }
        }

        public string ListBudgetSourceId
        {
            get
            {
                if ((cboBudgetSourceId.EditValue.ToString().Contains("<<Tất cả>>")) || (cboBudgetSourceId.EditValue.ToString().Contains("<<Tổng hợp>>")))
                {
                    return "";
                }
                string listKey = "";
                var list = cboBudgetSourceId.Properties.GetItems().GetCheckedValues();
                foreach (var key in list)
                {
                    listKey = listKey + key + ",,";
                }
                if (list.Count != 0)
                {
                    listKey = listKey.Remove(0, 0);
                }
                if (listKey == ",,")
                    return null;
                return listKey;
            }
        }

        public string BudgetChapterCode
        {
            get
            {
                if (cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>" ||
                    cboBudgetChapter.EditValue.ToString() == "<<Tất cả>>")
                    return "";
                return cboBudgetChapter.EditValue == null ? "" : cboBudgetChapter.EditValue.ToString();
            }
        }

        public string BudgetSubKindItemCode
        {
            get
            {
                if (cboBudgetKindItem.EditValue.ToString() == "<<Tổng hợp>>" ||
                    cboBudgetKindItem.EditValue.ToString() == "<<Tất cả>>")
                    return "";
                return cboBudgetKindItem.EditValue == null ? "" : cboBudgetKindItem.EditValue.ToString();
            }
        }
        public bool IsSummaryBudgetSource
        {
            get
            {
                if (cboBudgetSourceId.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                else
                    return false;
            }
        }
      
        public bool IsSummaryBudgetChapter
        {
            get
            {
                if (cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                else
                    return false;
            }
        }
      
        public bool IsSummaryBudgetSubKindItem
        {
            get
            {
                if (cboBudgetKindItem.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                else
                    return false;
            }
        }
        public string Account
        {
            get
            {
                var clause = GetClause();
                return clause;
            }
        }

        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                var result = new List<BudgetChapterModel>
                {
                    new BudgetChapterModel {BudgetChapterCode = "<<Tổng hợp>>", BudgetChapterName = "<<Tổng hợp>>"},
                    new BudgetChapterModel {BudgetChapterCode = "<<Tất cả>>", BudgetChapterName = "<<Tất cả>>"}
                };
                result.AddRange(value.Where(v => v.BudgetChapterCode == "160" || v.BudgetChapterCode == "170" ||
                                            v.BudgetChapterCode == "422" || v.BudgetChapterCode == "423" ||
                                            v.BudgetChapterCode == "623" || v.BudgetChapterCode == "823"));

                cboBudgetChapter.Properties.DataSource = result;
                cboBudgetChapter.Properties.ForceInitialize();
                cboBudgetChapter.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Mã Chương",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterName",
                    ColumnCaption = "Tên Chương",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetChapter.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetChapter.Properties.DisplayMember = "BudgetChapterCode";
                cboBudgetChapter.Properties.ValueMember = "BudgetChapterCode";
            }
        }

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
                cboBudgetKindItem.Properties.DataSource = result;
                cboBudgetKindItem.Properties.ForceInitialize();
                cboBudgetKindItem.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetKindItemCode",
                    ColumnCaption = "Mã Khoản",
                    ColumnPosition = 1,
                    ColumnVisible = false,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetKindItemName",
                    ColumnCaption = "Tên Khoản",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetKindItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetKindItem.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetKindItem.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                cboBudgetKindItem.Properties.ValueMember = "BudgetKindItemCode";
            }
        }

        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                var result = new List<BudgetSourceModel>
                {
                    new BudgetSourceModel {BudgetSourceCode = "<<Tổng hợp>>", BudgetSourceName = "<<Tổng hợp>>"},
                    new BudgetSourceModel {BudgetSourceCode = "<<Tất cả>>", BudgetSourceName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboBudgetSourceId.Properties.DataSource = result;
                //cboBudgetSourceId.Properties.ForceInitialize();
                //cboBudgetSourceId.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCode",
                    ColumnCaption = "Mã nguồn vốn",
                    ColumnPosition = 1,
                    ColumnVisible = false,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceName",
                    ColumnPosition = 2,
                    ColumnCaption = "Tên nguồn vốn",
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSavingExpenses", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceProperty", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankAccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "PayableBankAccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSelfControl", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceType", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                    }
                }
                cboBudgetSourceId.Properties.DisplayMember = "BudgetSourceCode";
                cboBudgetSourceId.Properties.ValueMember = "BudgetSourceId";
            }
        }

        /// <summary>
        /// Gets to date.
        /// </summary>
        /// <value>To date.</value>
       

        public IList<AccountModel> Accounts
        {
           
            set
            {
                bindingSource1.DataSource = value ?? new List<AccountModel>();
                gridviewAccountingObject.PopulateColumns(value);
                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "Số Tài Khoản", ColumnVisible = true, ColumnWith = 30 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên Tài Khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false });

                gridviewAccountingObject = InitGridLayout(ColumnsCollection, gridviewAccountingObject);
                gridviewAccountingObject.OptionsView.ShowFooter = false;
            }
        }
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
        public FrmGLVoucherListLedger()
        {
            InitializeComponent();
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _accountsPresenter =new AccountsPresenter(this);
        }

        private void FrmGLVoucherListLedger_Load(object sender, EventArgs e)
        {
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            //  _dbOptionHelper.Register();
            cboBudgetSourceId.EditValue = @"<<Tổng hợp>>";
            cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
            cboBudgetKindItem.EditValue = @"<<Tổng hợp>>";

            Selection = new GridCheckMarksSelection(gridviewAccountingObject);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private void rndOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rndOption.SelectedIndex == 0)
            {
                cboBudgetSourceId.EditValue = "<<Tất cả>>";
                cboBudgetChapter.EditValue = "<<Tất cả>>";
                cboBudgetKindItem.EditValue = "<<Tất cả>>";
            }
            if (rndOption.SelectedIndex == 1)
            {
                cboBudgetSourceId.EditValue = "<<Tổng hợp>>";
                cboBudgetChapter.EditValue = "<<Tổng hợp>>";
                cboBudgetKindItem.EditValue = "<<Tổng hợp>>";
            }
        }

        private string GetClause()
        {
            string Clause = ",";

            if (gridviewAccountingObject.DataSource != null && gridviewAccountingObject.RowCount > 0)
            {
                for (var i = 0; i < gridviewAccountingObject.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (AccountModel)gridviewAccountingObject.GetRow(i);
                        Clause = Clause + row.AccountNumber + ",";
                    }
                }
            }
            return Clause;
        }

        private void rndOption_SizeChanged(object sender, EventArgs e)
        {

        }
        protected override bool ValidData()
        {
            if (gridviewAccountingObject.DataSource != null && gridviewAccountingObject.RowCount > 0)
            {
                for (var i = 0; i < gridviewAccountingObject.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        return true;
                    }
                    else {
                        XtraMessageBox.Show(string.Format("Chọn tài khoản báo cáo"));
                         return false; }
                }
            }
            return true;
        }

    }
}
