/***********************************************************************
 * <copyright file="FrmS12H.cs" company="BUCA JSC">
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
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using DateTimeRangeBlockDev.Helper;


namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS12H.
    /// </summary>
    public partial class FrmS12HDetail : FrmXtraBaseParameter, IBudgetChaptersView, IBudgetKindItemsView, IBanksView, IAccountsView
    {
        /// <summary>
        /// The _DB option helper
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BanksPresenter _banksPresenter;
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
        }

        /// <summary>
        /// Gets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId
        {
            get
            {
                return cboBankId.EditValue.ToString() == @"0" ? null : cboBankId.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is summary bank identifier.
        /// </summary>
        /// <value><c>true</c> if this instance is summary bank identifier; otherwise, <c>false</c>.</value>
        public bool IsSummaryBankId
        {
            get { return cboBankId.EditValue.ToString() != @"0"; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is summary budget chapter.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget chapter; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetChapter
        {
            get
            {
                return cboBudgetSubKindItem.EditValue.ToString() == "<<Tổng hợp>>";
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
        /// Initializes a new instance of the <see cref="FrmS12H"/> class.
        /// </summary>
        public FrmS12HDetail()
        {
            InitializeComponent();
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);

            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.All;
            dateTimeRangeV1.InitSelectedIndex = 7;
        }

        /// <summary>
        /// Handles the Load event of the FrmS12H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmS12H_Load(object sender, EventArgs e)
        {
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _banksPresenter.DisplayActive(true);
            _accountsPresenter.DisplayActive();

            cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
            cboBudgetSubKindItem.EditValue = @"<<Tổng hợp>>";
            cboBankId.EditValue = @"0";
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
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
                result.AddRange(value.Where(v => v.BudgetKindItemCode == "251" || v.BudgetKindItemCode == "373" ||
                                            v.BudgetKindItemCode == "463" || v.BudgetKindItemCode == "494" ||
                                            v.BudgetKindItemCode == "521" || v.BudgetKindItemCode == "534"));

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
        public IList<BankModel> Banks
        {
            set
            {
                var result = new List<BankModel>
                {
                    new BankModel {BankAccount = "<<Tất cả>>", BankName = "<<Tất cả>>", BankId = "0"}
                };
                result.AddRange(value);

                cboBankId.Properties.DataSource = result;
                cboBankId.Properties.ForceInitialize();
                cboBankId.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BankAccount",
                    ColumnCaption = "Số TK",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BankName",
                    ColumnCaption = "Tên ngân hàng",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsOpenInBank", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankAddress", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBankId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBankId.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBankId.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBankId.Properties.DisplayMember = "BankAccount";
                cboBankId.Properties.ValueMember = "BankId";
            }
        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                cboAccountNumber.Properties.DataSource = value.Where(v => v.AccountCategoryId == "112").ToList();
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
    }
}