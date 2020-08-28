/***********************************************************************
 * <copyright file="FrmS11H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, September 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

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
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;


namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS11H.
    /// </summary>
    public partial class FrmS11H : FrmXtraBaseParameter, IBudgetChaptersView, IBudgetKindItemsView,IAccountsView,IBudgetSourcesView
    {
        /// <summary>
        /// The _DB option helper
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
       
        private readonly AccountsPresenter _accountsPresenter;
        
        #region Params

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

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public string StartDate
        {
            get { return GlobalVariable.StartedDate; }
        }

        /// <summary>
        /// Gets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode
        {
            get
            {
                if (cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>" || cboBudgetChapter.EditValue.ToString() == "<<Tất cả>>")
                    return null;
                return cboBudgetChapter.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets the budget sub kind item code.
        /// </summary>
        /// <value>The budget sub kind item code.</value>
        public string BudgetSubKindItemCode
        {
            get
            {
                if (cboBudgetSubKindItem.EditValue.ToString() == "<<Tổng hợp>>" || cboBudgetSubKindItem.EditValue.ToString() == "<<Tất cả>>")
                    return null;
                return cboBudgetSubKindItem.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber
        {
            get { return cboAccountNumber.EditValue.ToString(); }
            set { cboAccountNumber.EditValue = "1111"; }
        }

        public string Account
        {
            get
            {
                if (cboAccountNumber.Properties.DataSource != null)
                {
                    List<AccountModel> accounts = (List<AccountModel>)cboAccountNumber.Properties.DataSource;
                    var account = accounts.FirstOrDefault(item => item.AccountNumber == cboAccountNumber.EditValue.ToString());
                    if (account != null)
                    {
                        return string.Format("{0} - {1}", account.AccountNumber, account.AccountName);
                    }
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BudgetSource
        {
            get
            {
                if (cboBudgetSource.EditValue.ToString() == "<00000000-0000-0000-0000-000000000000>" || cboBudgetSource.EditValue.ToString() == "00000000 - 0000 - 0000 - 0000 - 000000000001")
                    return null;
                return cboBudgetSource.EditValue.ToString();
            }
        }

        public bool IsDetail
        {
            get { return ckbDetail.Checked; }
        }

        public bool IsDetailMonth
        {
            get { return chkDetailMonth.Checked; }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is summary bank identifier.
        /// </summary>
        /// <value><c>true</c> if this instance is summary bank identifier; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetSource
        {
            get { return cboBudgetSource.EditValue.ToString() == "00000000-0000-0000-0000-000000000000"; }
        }
        public string ListBudgetSourceId
        {
            get
            {
                if ((cboBudgetSource.EditValue.ToString().Contains("00000000-0000-0000-0000-000000000001")) || (cboBudgetSource.EditValue.ToString().Contains("00000000-0000-0000-0000-000000000000")))
                {
                    return null;
                }
                string listKey = "";
                var list = cboBudgetSource.Properties.GetItems().GetCheckedValues();
                foreach (var key in list)
                {
                    listKey = listKey + key + ",";
                }
                if (list.Count != 0)
                {
                    listKey = listKey.Remove(0, 0);
                }
               
                   
                return listKey;
            }
        }

      
        /// <summary>
        /// Gets a value indicating whether this instance is summary budget chapter.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget chapter; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetChapter
        {
            get
            {
                return cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>";
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is summary budget sub kind item.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget sub kind item; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetSubKindItem
        {
            get
            {
                return cboBudgetSubKindItem.EditValue.ToString() == "<<Tổng hợp>>";
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS11H"/> class.
        /// </summary>
        public FrmS11H()
        {
            InitializeComponent();
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
         
            _accountsPresenter = new AccountsPresenter(this);
            //dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.All;
            //dateTimeRangeV1.InitSelectedIndex = 7;
        }

        /// <summary>
        /// Handles the Load event of the FrmS11H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmS11H_Load(object sender, EventArgs e)
        {
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
          
            _accountsPresenter.DisplayActive();
            dateTimeRangeV1.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
            cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
            cboBudgetSubKindItem.EditValue = @"<<Tổng hợp>>";
            cboBudgetSource.SetEditValue("00000000-0000-0000-0000-000000000000"); 
            cboAccountNumber.EditValue = @"1111";
        }

        protected override bool ValidData()
        {
            if (ListBudgetSourceId == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn nguồn", "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                var result = new List<BudgetChapterModel>
                {
                    new BudgetChapterModel {BudgetChapterCode = "<<Tổng hợp>>", BudgetChapterName = "<<Tổng hợp>>"},
                    new BudgetChapterModel {BudgetChapterCode = "<<Tất cả>>", BudgetChapterName = "<<Tất cả>>"}
                };
                //result.AddRange(value.Where(v => v.BudgetChapterCode == "160" || v.BudgetChapterCode == "170" ||
                //                            v.BudgetChapterCode == "422" || v.BudgetChapterCode == "423" ||
                //                            v.BudgetChapterCode == "623" || v.BudgetChapterCode == "823"));
                result.AddRange(value.Where(v => v.IsActive ==true));

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

        /// <summary>
        /// Gets or sets the budget kind items.
        /// </summary>
        /// <value>The budget kind items.</value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                var result = new List<BudgetKindItemModel>
                {
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tổng hợp>>", BudgetKindItemName = "<<Tổng hợp>>"},
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tất cả>>", BudgetKindItemName = "<<Tất cả>>"}
                };
                result.AddRange(value.Where(v => v.IsActive == true).ToList());

                cboBudgetSubKindItem.Properties.DataSource = result;
                cboBudgetSubKindItem.Properties.ForceInitialize();
                cboBudgetSubKindItem.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetKindItemCode",
                    ColumnCaption = "Mã Khoản",
                    ColumnPosition = 1,
                    ColumnVisible = true,
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
                        cboBudgetSubKindItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetSubKindItem.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetSubKindItem.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetSubKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                cboBudgetSubKindItem.Properties.ValueMember = "BudgetKindItemCode";
            }
        }

        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>The banks.</value>
       

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                cboAccountNumber.Properties.DataSource = value.Where(v => v.AccountCategoryId == "111").ToList();
                cboAccountNumber.Properties.ForceInitialize();
                cboAccountNumber.Properties.PopulateColumns();
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
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetExpense", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboAccountNumber.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboAccountNumber.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboAccountNumber.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboAccountNumber.Properties.DisplayMember = "AccountNumber";
                cboAccountNumber.Properties.ValueMember = "AccountNumber";
            }
        }

        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                var result = new List<BudgetSourceModel>
                {
                    new BudgetSourceModel {BudgetSourceId = "00000000-0000-0000-0000-000000000000",BudgetSourceCode = "<<Tổng hợp>>", BudgetSourceName = "<<Tổng hợp>>"},
                    new BudgetSourceModel {BudgetSourceId = "00000000-0000-0000-0000-000000000001",BudgetSourceCode = "<<Tất cả>>", BudgetSourceName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboBudgetSource.Properties.DataSource = result;
                //cboBudgetSource.Properties.ForceInitialize();
                //cboBudgetSource.Properties.PopulateColumns();
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
                    //if (column != null)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        cboBudgetSource.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        cboBudgetSource.Properties.SortColumnIndex = column.ColumnPosition;
                    //    }
                    //    else
                    //        cboBudgetSource.Properties.Columns[column.ColumnName].Visible = false;
                    //}
                }
                cboBudgetSource.Properties.DisplayMember = "BudgetSourceCode";
                cboBudgetSource.Properties.ValueMember = "BudgetSourceId";
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
        }

        private void groupboxMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimeRangeV1_Load(object sender, EventArgs e)
        {

        }
    }
}