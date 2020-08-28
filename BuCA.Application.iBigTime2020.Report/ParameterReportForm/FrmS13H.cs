using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Currency;
using Buca.Application.iBigTime2020.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Utils;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmS13H : FrmXtraBaseParameter, ICurrenciesView, IAccountsView,IBanksView
    {
        #region Declare

        private readonly CurrenciesPresenter _currenciesPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();

        /// <summary>
        /// The columns collection account
        /// </summary>
        public List<XtraColumn> ColumnsCollectionAccount = new List<XtraColumn>();

        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>
        /// The selection.
        /// </value>
        internal GridCheckMarksSelection Selection { get; private set; }

        /// <summary>
        /// Gets the selection account.
        /// </summary>
        /// <value>The selection account.</value>
        internal GridCheckMarksSelection SelectionAccount { get; private set; }
        #endregion

        #region Variable
        /// <summary>
        /// Sets from date.
        /// </summary>
        /// <value>From date.</value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }

        /// <summary>
        /// Sets to date.
        /// </summary>
        /// <value>To date.</value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }

        /// <summary>
        /// Sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber
        {
            get
            {
                var selectAccount = ",";
                if (SelectionAccount.SelectedCount > 0)
                {
                    for (int i = 0; i < gridAccountsView.RowCount; i++)
                    {
                        if (SelectionAccount.IsRowSelected(i))
                        {
                            selectAccount +=   gridAccountsView.GetRowCellValue(i, "AccountNumber") + ",";
                        }
                    }
                }
                else
                    selectAccount = null;
                return selectAccount;
            }
        }

        public string BankAccount
        {
            get
            {
                var selectAccount = ",";
                if (Selection.SelectedCount > 0)
                {
                    for (int i = 0; i < grdViewBank.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            selectAccount += grdViewBank.GetRowCellValue(i, "BankAccount") + ",";
                        }
                    }
                }
                else
                    selectAccount = null;
                return selectAccount;
            }
        }

        /// <summary>
        /// Sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string CurrencyCode
        {
            get
            {
                if (lookUpEditCurrencyCode.EditValue.ToString() == "<<Tất cả>>")
                    return null;

                else

                    return lookUpEditCurrencyCode.EditValue.ToString();
            }
        }

        /// <summary>
        /// Xem chi tiết
        /// </summary>
        public bool IsDetail
        {
            get { return checkIsDetail.Checked; }
        }
        public bool IsDetailMonth
        {
            get { return ckbIsDetailMonth.Checked; }
        }
        #endregion

        #region Form Event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS13H"/> class.
        /// </summary> 
        public FrmS13H()
        {
            InitializeComponent();
            _currenciesPresenter = new CurrenciesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            lookUpEditCurrencyCode.EditValue = @"<<Tất cả>>";
        }

        /// <summary>
        /// Handles the Load event of the FrmS13H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmS13H_Load(object sender, EventArgs e)
        {
            _accountsPresenter.DisplayActive();
            _currenciesPresenter.DisplayActive();
            _banksPresenter.DisplayActive(true);

            SelectionAccount = new GridCheckMarksSelection(gridAccountsView);
            SelectionAccount.CheckMarkColumn.VisibleIndex = 0;
            SelectionAccount.CheckMarkColumn.Width = 10;
            SelectionAccount.SelectAll();
            switch (1)
            {
                case 1:
                case 2:
                    break;

            }

            Selection = new GridCheckMarksSelection(grdViewBank);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 10;
            Selection.SelectAll();
            switch (1)
            {
                case 1:
                case 2:
                    break;

            }
        }
        #endregion

        #region MemberViews

        /// <summary>
        /// Sets the currencies.
        /// </summary>
        /// <value>
        /// The currencies.
        /// </value>
        public IList<CurrencyModel> Currencies
        {
            set
            {
                var result = new List<CurrencyModel>
                {
                    
                    new CurrencyModel {CurrencyCode = "<<Tất cả>>", CurrencyName = "<<Tất cả>>"}
                };
                result.AddRange(value.Where(x=>x.CurrencyCode!="VND").ToList()
                    );
                lookUpEditCurrencyCode.Properties.DataSource = result;
                lookUpEditCurrencyCode.Properties.ForceInitialize();
                lookUpEditCurrencyCode.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "CurrencyId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CurrencyCode",
                    ColumnCaption = "Mã loại tiền",
                    ColumnPosition = 1,
                    ColumnVisible = false,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CurrencyName",
                    ColumnCaption = "Tên loại tiền",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250,

                });
                columnsCollection.Add(new XtraColumn { ColumnName = "Prefix", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Suffix", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsMain", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lookUpEditCurrencyCode.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lookUpEditCurrencyCode.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        lookUpEditCurrencyCode.Properties.Columns[column.ColumnName].Visible = false;
                }
                lookUpEditCurrencyCode.Properties.DisplayMember = "CurrencyCode";
                lookUpEditCurrencyCode.Properties.ValueMember = "CurrencyCode";
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
                var accounts = value.Where(c => c.AccountNumber.StartsWith("1112") || c.AccountNumber.StartsWith("1122")).ToList();
                bindingSource.DataSource = accounts;
                gridAccountsView.PopulateColumns(accounts);

                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "Số tài khoản", ToolTip = "Số tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 30 });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ToolTip = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "Grade", ColumnCaption = "Bậc TK", ToolTip = "Bậc TK", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 20 });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByBudgetExpense", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByContract", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByExpense", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "DetailByCapitalPlan", ColumnVisible = false });

                if (ColumnsCollectionAccount == null) return;
                foreach (var column in ColumnsCollectionAccount)
                {
                    if (gridAccountsView.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {

                            gridAccountsView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridAccountsView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            gridAccountsView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridAccountsView.Columns[column.ColumnName].Width = column.ColumnWith;
                            gridAccountsView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            gridAccountsView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            gridAccountsView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            gridAccountsView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            gridAccountsView.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;
                        }
                        else
                            gridAccountsView.Columns[column.ColumnName].Visible = false;
                    }
                }

            }
        }

        public IList<BankModel> Banks
        {            
            set
            {
                var banks = value.ToList();
                bindingSourceBank.DataSource = banks;
                grdViewBank.PopulateColumns(banks);

                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số tài khoản", ToolTip = "Số tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 30 });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên tài khoản", ToolTip = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "IsOpenInBank", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "BankAddress", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollectionAccount.Add(new XtraColumn { ColumnName = "Used", ColumnVisible = false });

                if (ColumnsCollectionAccount == null) return;
                foreach (var column in ColumnsCollectionAccount)
                {
                    if (grdViewBank.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {

                            grdViewBank.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            grdViewBank.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            grdViewBank.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            grdViewBank.Columns[column.ColumnName].Width = column.ColumnWith;
                            grdViewBank.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            grdViewBank.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            grdViewBank.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            grdViewBank.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            grdViewBank.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;
                        }
                        else
                            grdViewBank.Columns[column.ColumnName].Visible = false;
                    }
                }

            }
        }

        #endregion
    }
}
