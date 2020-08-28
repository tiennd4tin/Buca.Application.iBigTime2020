using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmS52H : FrmXtraBaseParameter, IAccountsView
    {
        private readonly AccountsPresenter _accountsPresenter;


        #region Variable

        private string accountlist =",";
        public string AccountNumber
        {
            get
            {
                if (cboAccount.EditValue.ToString() == "<<Tất cả>>" || cboAccount.EditValue.ToString() == "<<Tổng hợp>>")
                {
                    return accountlist;
                }
                else
                    return ","+ cboAccount.EditValue.ToString() +",";
            }
        }

        public bool issumaccount
        {
            get
            {
                if (cboAccount.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                else return false;
            }
        }
        public string StartDate
        {
            get { return GlobalVariable.StartedDate; }
        }
        /// <summary>
        /// Gets from date.
        /// </summary>
        /// <value>From date.</value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }
        /// <summary>
        /// Gets to date.
        /// </summary>
        /// <value>To date.</value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }
        #endregion

        public bool pGroupTheSameItem
        {
            get { return chkGroupTheSameItem.Checked; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS03H"/> class.
        /// </summary>

        public FrmS52H()
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
        }

        #region IView
       

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                var result = new List<AccountModel>
                {
                    new AccountModel {  AccountNumber = "<<Tất cả>>", AccountName = "<<Tất cả>>"},
                    new AccountModel {  AccountNumber = "<<Tổng hợp>>", AccountName = "<<Tổng hợp>>"}
                };
                foreach (var accountitem in value.Where(v => v.AccountNumber.Contains("337")))
                {
                    accountlist += accountitem.AccountNumber + ",";
                }
                result.AddRange(value.Where(v => v.AccountNumber.Contains("337")).ToList());
                cboAccount.Properties.DataSource = result;
                cboAccount.Properties.ForceInitialize();
                cboAccount.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "Số tài khoản",
                    ColumnPosition = 1,
                    ColumnVisible = false,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountName",
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
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboAccount.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboAccount.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboAccount.Properties.DisplayMember = "AccountName";
                cboAccount.Properties.ValueMember = "AccountNumber";
            }
        }


        #endregion
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

        private void FrmS03H_Load(object sender, EventArgs e)
        {
            _accountsPresenter.Display();
            cboAccount.Text = "<<Tất cả>>";
        }
    }
}
