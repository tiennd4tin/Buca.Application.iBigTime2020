/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusiness;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetSource;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetChapter;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetItem;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetKindItem;
using System;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.AutoBusiness
{
    /// <summary>
    /// FrmAutoBusinessDetail
    /// </summary>
    public partial class FrmAutoBusinessDetail : FrmXtraBaseCategoryDetail, IAutoBusinessView, IAccountsView, IBudgetSourcesView, IBudgetKindItemsView, IBudgetItemsView, IBudgetChaptersView, IRefTypesView, ICashWithdrawTypesView
    {
        #region Declare parameter
        private readonly AutoBusinessPresenter _autoBusinessPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly RefTypesPresenter _refTypesPresenter;
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAutoBusinessDetail"/> class.
        /// </summary>
        public FrmAutoBusinessDetail()
        {
            InitializeComponent();
            _autoBusinessPresenter = new AutoBusinessPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
        }

        #region IAutoBusinessView

        /// <summary>
        /// Gets or sets the automatic business identifier.
        /// </summary>
        /// <value>
        /// The automatic business identifier.
        /// </value>
        public string AutoBusinessId { get; set; }

        /// <summary>
        /// Gets or sets the automatic business code.
        /// </summary>
        /// <value>
        /// The automatic business code.
        /// </value>
        public string AutoBusinessCode
        {
            get { return txtAutoBusinessCode.Text.Trim(); }
            set { txtAutoBusinessCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the automatic business.
        /// </summary>
        /// <value>
        /// The name of the automatic business.
        /// </value>
        public string AutoBusinessName
        {
            get { return txtAutoBusinessName.Text.Trim(); }
            set { txtAutoBusinessName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public int RefTypeId
        {
            get { return (int)grdLookUpEditRefType.GetColumnValue("RefTypeId"); }
            set { grdLookUpEditRefType.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the debit account.
        /// </summary>
        /// <value>
        /// The debit account.
        /// </value>
        public string DebitAccount
        {
            get { return string.IsNullOrEmpty(grdLookUpEditDebitAccount.Text) ? null : (string)grdLookUpEditDebitAccount.GetColumnValue("AccountNumber"); }
            set { grdLookUpEditDebitAccount.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the credit account.
        /// </summary>
        /// <value>
        /// The credit account.
        /// </value>
        public string CreditAccount
        {
            get { return string.IsNullOrEmpty(grdLookUpEditCreditAccount.Text) ? null : (string)grdLookUpEditCreditAccount.GetColumnValue("AccountNumber"); }
            set { grdLookUpEditCreditAccount.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        /// The budget source identifier.
        /// </value>
        public string BudgetSourceId
        {
            get { return string.IsNullOrEmpty(grdLookUpEditBudgetSource.Text) ? null : (string)grdLookUpEditBudgetSource.GetColumnValue("BudgetSourceId"); }
            set { grdLookUpEditBudgetSource.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode
        {
            get { return string.IsNullOrEmpty(grdLookUpEditBudgetChapter.Text) ? null : (string)grdLookUpEditBudgetChapter.GetColumnValue("BudgetChapterCode"); }
            set { grdLookUpEditBudgetChapter.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        /// The budget kind item code.
        /// </value>
        public string BudgetKindItemCode
        {
            get { return string.IsNullOrEmpty(grdLookUpEditBudgetKindItem.Text) ? null : (string)grdLookUpEditBudgetKindItem.GetColumnValue("BudgetKindItemCode"); }
            set { grdLookUpEditBudgetKindItem.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>
        /// The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode
        {
            get { return string.IsNullOrEmpty(grdLookUpEditBudgetSubKindItem.Text) ? null : (string)grdLookUpEditBudgetSubKindItem.GetColumnValue("BudgetKindItemCode"); }
            set { grdLookUpEditBudgetSubKindItem.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode
        {
            get { return string.IsNullOrEmpty(grdLookUpEditBudgetItem.Text) ? null : (string)grdLookUpEditBudgetItem.GetColumnValue("BudgetItemCode"); }
            set { grdLookUpEditBudgetItem.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>
        /// The budget sub item code.
        /// </value>
        public string BudgetSubItemCode
        {
            get { return string.IsNullOrEmpty(grdLookUpEditBudgetSubItem.Text) ? null : (string)grdLookUpEditBudgetSubItem.GetColumnValue("BudgetItemCode"); }
            set { grdLookUpEditBudgetSubItem.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>
        /// The method distribute identifier.
        /// </value>
        public int? MethodDistributeId { get; set; }

        /// <summary>
        /// Gets or sets the cash with draw type identifier.
        /// </summary>
        /// <value>
        /// The cash with draw type identifier.
        /// </value>
        public int? CashWithDrawTypeId
        {
            get
            {
                return string.IsNullOrEmpty(grdLookUpEditCashWithdrawType.Text)
                           ? null
                           : (int?)grdLookUpEditCashWithdrawType.GetColumnValue("CashWithdrawTypeId");
            }
            set { grdLookUpEditCashWithdrawType.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return memoDescription.Text.Trim(); }
            set { memoDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        #endregion

        #region Member
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
                grdLookUpEditDebitAccount.Properties.DataSource = value;
                grdLookUpEditCreditAccount.Properties.DataSource = value;
                grdLookUpEditDebitAccount.Properties.PopulateColumns();
                grdLookUpEditCreditAccount.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "AccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByBudgetExpense", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByContract", ColumnVisible = false},
                        new XtraColumn { ColumnName = "DetailByExpense", ColumnVisible = false},
                        new XtraColumn { ColumnName = "DetailByCapitalPlan", ColumnVisible = false},
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpEditCreditAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditCreditAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditCreditAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdLookUpEditDebitAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditDebitAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditDebitAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpEditCreditAccount.Properties.Columns[column.ColumnName].Visible = false;
                        grdLookUpEditDebitAccount.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpEditCreditAccount.Properties.DisplayMember = "AccountNumber";
                grdLookUpEditCreditAccount.Properties.ValueMember = "AccountNumber";
                grdLookUpEditDebitAccount.Properties.DisplayMember = "AccountNumber";
                grdLookUpEditDebitAccount.Properties.ValueMember = "AccountNumber";
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
                grdLookUpEditBudgetSource.Properties.DataSource = value;
                grdLookUpEditBudgetSource.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn vốn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300  },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSavingExpenses", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceProperty", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BankAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "PayableBankAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSelfControl", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceType", ColumnVisible = false }
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpEditBudgetSource.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditBudgetSource.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditBudgetSource.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdLookUpEditBudgetSource.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditBudgetSource.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditBudgetSource.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpEditBudgetSource.Properties.Columns[column.ColumnName].Visible = false;
                        grdLookUpEditBudgetSource.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }

                grdLookUpEditBudgetSource.Properties.DisplayMember = "BudgetSourceCode";
                grdLookUpEditBudgetSource.Properties.ValueMember = "BudgetSourceId";
            }
        }

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
                var budgetItem = value.Where(c => c.BudgetItemType == 2).ToList();
                var budgetSubItem = value.Where(c => c.BudgetItemType == 3).ToList();
                grdLookUpEditBudgetItem.Properties.DataSource = budgetItem;
                grdLookUpEditBudgetSubItem.Properties.DataSource = budgetSubItem;
                grdLookUpEditBudgetSubItem.Properties.PopulateColumns();
                grdLookUpEditBudgetItem.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                        new XtraColumn{ColumnName = "BudgetItemCode",ColumnCaption = "Mã M/TM",ColumnPosition = 1,ColumnVisible = true,ColumnWith = 100},
                        new XtraColumn{ColumnName = "BudgetItemName",ColumnCaption = "Tên M/TM",ColumnPosition = 2,ColumnVisible = true,ColumnWith = 300},
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetGroupItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpEditBudgetItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditBudgetItem.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditBudgetItem.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdLookUpEditBudgetSubItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditBudgetSubItem.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditBudgetSubItem.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpEditBudgetItem.Properties.Columns[column.ColumnName].Visible = false;
                        grdLookUpEditBudgetSubItem.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpEditBudgetItem.Properties.DisplayMember = "BudgetItemCode";
                grdLookUpEditBudgetItem.Properties.ValueMember = "BudgetItemCode";
                grdLookUpEditBudgetSubItem.Properties.DisplayMember = "BudgetItemCode";
                grdLookUpEditBudgetSubItem.Properties.ValueMember = "BudgetItemCode";
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
                var budgetKindItem = value.Where(c => c.IsParent).ToList();
                var budgetSubKindItem = value.Where(c => c.IsParent == false).ToList();
                grdLookUpEditBudgetKindItem.Properties.DataSource = budgetKindItem;
                grdLookUpEditBudgetSubKindItem.Properties.DataSource = budgetSubKindItem;
                grdLookUpEditBudgetKindItem.Properties.PopulateColumns();
                grdLookUpEditBudgetSubKindItem.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetKindItemId", ColumnVisible = false},
                        new XtraColumn{ColumnName = "BudgetKindItemCode",ColumnCaption = "Mã Loại",ColumnPosition = 1,ColumnVisible = true,ColumnWith = 100},
                        new XtraColumn{ColumnName = "BudgetKindItemName",ColumnCaption = "Tên Loại",ColumnPosition = 2,ColumnVisible = true,ColumnWith = 300},
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpEditBudgetKindItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditBudgetKindItem.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditBudgetKindItem.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdLookUpEditBudgetSubKindItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditBudgetSubKindItem.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditBudgetSubKindItem.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpEditBudgetKindItem.Properties.Columns[column.ColumnName].Visible = false;
                        grdLookUpEditBudgetSubKindItem.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpEditBudgetKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                grdLookUpEditBudgetKindItem.Properties.ValueMember = "BudgetKindItemCode";
                grdLookUpEditBudgetSubKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                grdLookUpEditBudgetSubKindItem.Properties.ValueMember = "BudgetKindItemCode";
            }
        }

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
                grdLookUpEditBudgetChapter.Properties.DataSource = value;
                grdLookUpEditBudgetChapter.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "BudgetChapterName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300  },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpEditBudgetChapter.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditBudgetChapter.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditBudgetChapter.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpEditBudgetChapter.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpEditBudgetChapter.Properties.DisplayMember = "BudgetChapterCode";
                grdLookUpEditBudgetChapter.Properties.ValueMember = "BudgetChapterCode";
            }
        }

        /// <summary>
        /// Sets the reference types.
        /// </summary>
        /// <value>
        /// The reference types.
        /// </value>
        public IList<RefTypeModel> RefTypes
        {
            set
            {
                grdLookUpEditRefType.Properties.DataSource = value;
                grdLookUpEditRefType.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "RefTypeName", ColumnCaption = "Tên chứng từ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 320 },
                        new XtraColumn { ColumnName = "FunctionId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "RefTypeCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "MasterTableName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailTableName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "LayoutMaster", ColumnVisible = false },
                        new XtraColumn { ColumnName = "LayoutDetail", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultDebitAccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultDebitAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultCreditAccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultCreditAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultTaxAccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultTaxAccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AllowDefaultSetting", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Postable", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Searchable", ColumnVisible = false },
                        new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false },
                        new XtraColumn { ColumnName = "SubSystem", ColumnVisible = false }
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpEditRefType.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditRefType.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditRefType.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpEditRefType.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpEditRefType.Properties.DisplayMember = "RefTypeName";
                grdLookUpEditRefType.Properties.ValueMember = "RefTypeId";
            }
        }

        /// <summary>
        /// Sets the cash withdraw type models.
        /// </summary>
        /// <value>
        /// The cash withdraw type models.
        /// </value>
        public IList<CashWithdrawTypeModel> CashWithdrawTypeModels
        {
            set
            {
                grdLookUpEditCashWithdrawType.Properties.DataSource = value;
                grdLookUpEditCashWithdrawType.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "CashWithdrawTypeName", ColumnCaption = "Nghiệp vụ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 320 },
                        new XtraColumn { ColumnName = "CashWithdrawNo", ColumnVisible = false },
                        new XtraColumn { ColumnName = "SubSystemId", ColumnVisible = false }
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpEditCashWithdrawType.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditCashWithdrawType.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditCashWithdrawType.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpEditCashWithdrawType.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpEditCashWithdrawType.Properties.DisplayMember = "CashWithdrawTypeName";
                grdLookUpEditCashWithdrawType.Properties.ValueMember = "CashWithdrawTypeId";
            }
        }

        /// <summary>
        /// Sets the cash withdraw type model.
        /// </summary>
        /// <value>
        /// The cash withdraw type model.
        /// </value>
        public CashWithdrawTypeModel CashWithdrawTypeModel { set; get; }
        #endregion

        #region Form Event
        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            //_autoBusinessesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _refTypesPresenter.Display();
            _cashWithdrawTypesPresenter.DisplayList();
            if (KeyValue != null)
                _autoBusinessPresenter.Display(KeyValue);
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdLookUpEditRefType.Focus();
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            return _autoBusinessPresenter.Save();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (grdLookUpEditRefType.ItemIndex < 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyRefType"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpEditRefType.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AutoBusinessCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyAutoBusinessCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutoBusinessCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AutoBusinessName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyAutoBusinessName"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutoBusinessName.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region Control Event
        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditRefTypeCategory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditRefTypeCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditRefType.SelectionLength == grdLookUpEditRefType.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditRefType.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditDebitAccount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditDebitAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditDebitAccount.SelectionLength == grdLookUpEditDebitAccount.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditDebitAccount.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditCreditAccount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditCreditAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditCreditAccount.SelectionLength == grdLookUpEditCreditAccount.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditCreditAccount.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditBudgetSource control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditBudgetSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditBudgetSource.SelectionLength == grdLookUpEditBudgetSource.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditBudgetSource.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditBudgetChapter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditBudgetChapter_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditBudgetChapter.SelectionLength == grdLookUpEditBudgetChapter.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditBudgetChapter.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditBudgetKindItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditBudgetKindItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditBudgetKindItem.SelectionLength == grdLookUpEditBudgetKindItem.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditBudgetKindItem.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditBudgetSubKindItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditBudgetSubKindItem_KeyDown(object sender, KeyEventArgs e)
        {

        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditBudgetItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditBudgetItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditBudgetItem.SelectionLength == grdLookUpEditBudgetItem.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditBudgetItem.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditBudgetSubItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditBudgetSubItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditBudgetSubItem.SelectionLength == grdLookUpEditBudgetSubItem.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditBudgetSubItem.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditCashWithdrawType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditCashWithdrawType_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditCashWithdrawType.SelectionLength == grdLookUpEditCashWithdrawType.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditCashWithdrawType.EditValue = null;
                e.Handled = true;
            }
        }
       
        /// <summary>
        /// Handles the EditValueChanged event of the grdLookUpEditBudgetSubKindItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditBudgetSubKindItem_EditValueChanged(object sender, System.EventArgs e)
        {
            var row = (BudgetKindItemModel)grdLookUpEditBudgetSubKindItem.GetSelectedDataRow();
            if (row == null) return;
            {
                BudgetKindItemModel budgetKindItem = _budgetKindItemsPresenter.GetBudgetKindItem(row.ParentId);
                if (budgetKindItem != null)
                    grdLookUpEditBudgetKindItem.EditValue = budgetKindItem.BudgetKindItemCode;
                else
                    grdLookUpEditBudgetKindItem.EditValue = null;
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the grdLookUpEditBudgetSubItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditBudgetSubItem_EditValueChanged(object sender, System.EventArgs e)
        {
            var row = (BudgetItemModel)grdLookUpEditBudgetSubItem.GetSelectedDataRow();
            if (row == null) return;
            {
                BudgetItemModel budgetItem = _budgetItemsPresenter.GetBudgetItem(row.ParentId);
                if (budgetItem != null)
                {
                    grdLookUpEditBudgetItem.EditValue = budgetItem.BudgetItemCode;
                }
                else
                    grdLookUpEditBudgetItem.EditValue = null;
            }
        }

        private void grdLookUpEditDebitAccount_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmAccountDetail = new FrmAccountDetail();
                frmAccountDetail.ShowDialog();
                if (frmAccountDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.AccountIDAccountTransferForm))
                    {
                        _accountsPresenter.DisplayActive();
                        grdLookUpEditDebitAccount.Properties.DisplayMember = "AccountNumber";
                        grdLookUpEditDebitAccount.Properties.ValueMember = "AccountId";
                        grdLookUpEditDebitAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;
                    }
                }
            }
        }

        private void grdLookUpEditCreditAccount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmAccountDetail = new FrmAccountDetail();
                frmAccountDetail.ShowDialog();
                if (frmAccountDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.AccountIDAccountTransferForm))
                    {
                        _accountsPresenter.DisplayActive();
                        grdLookUpEditCreditAccount.Properties.DisplayMember = "AccountNumber";
                        grdLookUpEditCreditAccount.Properties.ValueMember = "AccountId";
                        grdLookUpEditCreditAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;
                    }
                }
            }
        }

        private void grdLookUpEditBudgetSource_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBudgetSource = new FrmBudgetSourceDetail();
                frmBudgetSource.ShowDialog();
                if (frmBudgetSource.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetSourceIDAccountTransferForm))
                    {
                        _budgetSourcesPresenter.DisplayActive();
                        grdLookUpEditBudgetSource.EditValue = GlobalVariable.BudgetSourceIDAccountTransferForm;
                    }
                }
            }
        }

        private void grdLookUpEditBudgetChapter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                        grdLookUpEditBudgetChapter.Properties.DisplayMember = "BudgetChapterCode";
                        grdLookUpEditBudgetChapter.Properties.ValueMember = "BudgetChapterId";
                        grdLookUpEditBudgetChapter.EditValue = GlobalVariable.BudgetChapterIDAccountingObjectDetailForm;
                    }
                }
            }
        }

        private void grdLookUpEditBudgetSubKindItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBudgetKindItem = new FrmBudgetKindItemDetail();
                frmBudgetKindItem.ShowDialog();
                if (frmBudgetKindItem.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetKindItemIDAutoBusinessForm))
                    {
                        _budgetKindItemsPresenter.DisplayActive();
                        grdLookUpEditBudgetSubKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                        grdLookUpEditBudgetSubKindItem.Properties.ValueMember = "BudgetKindItemId";
                        grdLookUpEditBudgetSubKindItem.EditValue = GlobalVariable.BudgetKindItemIDAutoBusinessForm;
                    }
                }
            }
        }

        private void grdLookUpEditBudgetSubItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBudgetItem = new FrmBudgetItemDetail();
                frmBudgetItem.ShowDialog();
                if (frmBudgetItem.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetItemDetailAccountingObjectDetailForm))
                    {
                        _budgetItemsPresenter.DisplayActive(true);

                        grdLookUpEditBudgetSubItem.Properties.DisplayMember = "BudgetItemCode";
                        grdLookUpEditBudgetSubItem.Properties.ValueMember = "BudgetItemId";
                        grdLookUpEditBudgetSubItem.EditValue =
                            GlobalVariable.BudgetItemDetailAccountingObjectDetailForm;
                    }
                }
            }
        }
        #endregion

    }
}
