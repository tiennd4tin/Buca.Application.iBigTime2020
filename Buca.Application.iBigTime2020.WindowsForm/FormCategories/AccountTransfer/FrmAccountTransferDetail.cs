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
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountTransfer;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetSource;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountTransfer
{
    /// <summary>
    /// FrmAccountTransferDetail
    /// </summary>
    public partial class FrmAccountTransferDetail : FrmXtraBaseCategoryDetail, IAccountTransferView, IAccountsView, IBudgetSourcesView
    {
        private readonly AccountTransferPresenter _accountTransferPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAccountTransferDetail"/> class.
        /// </summary>
        public FrmAccountTransferDetail()
        {
            InitializeComponent();
            _accountTransferPresenter = new AccountTransferPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
        }

        #region Account Transfer Member

        /// <summary>
        /// Gets or sets the account tranfer identifier.
        /// </summary>
        /// <value>
        /// The account tranfer identifier.
        /// </value>
        public string AccountTransferId { get; set; }

        /// <summary>
        /// Gets or sets the account tranfer code.
        /// </summary>
        /// <value>
        /// The account tranfer code.
        /// </value>
        public string AccountTransferCode
        {
            get { return txtAccountTransferCode.Text.Trim(); }
            set { txtAccountTransferCode.Text = value; }
        }
        /// <summary>
        /// Gets or sets the type of the business.
        /// </summary>
        /// <value>
        /// The type of the business.
        /// </value>
        public int BusinessType
        {
            get { return cboBusinessType.SelectedIndex; }
            set { cboBusinessType.SelectedIndex = value; }
        }
        /// <summary>
        /// Gets or sets the referent account.
        /// </summary>
        /// <value>
        /// The referent account.
        /// </value>
        public string ReferentAccount
        {
            get { return string.IsNullOrEmpty(grdLookUpEditReferentAccount.Text) ? null : (string)grdLookUpEditReferentAccount.GetColumnValue("AccountNumber"); }
            set { grdLookUpEditReferentAccount.EditValue = value; }
        }
        /// <summary>
        /// Gets or sets the transfer order.
        /// </summary>
        /// <value>
        /// The transfer order.
        /// </value>
        public int TransferOrder
        {
            get { return (int)spinTransferOrder.Value; }
            set { spinTransferOrder.EditValue = value; }
        }
        /// <summary>
        /// Gets or sets from account.
        /// </summary>
        /// <value>
        /// From account.
        /// </value>
        public string FromAccount
        {
            get { return string.IsNullOrEmpty(grdLookUpEditFromAccount.Text) ? null : (string)grdLookUpEditFromAccount.GetColumnValue("AccountNumber"); }
            set { grdLookUpEditFromAccount.EditValue = value; }
        }
        /// <summary>
        /// Gets or sets to account.
        /// </summary>
        /// <value>
        /// To account.
        /// </value>
        public string ToAccount
        {
            get { return string.IsNullOrEmpty(grdLookUpEditToAccount.Text) ? null : (string)grdLookUpEditToAccount.GetColumnValue("AccountNumber"); }
            set
            {
                grdLookUpEditToAccount.EditValue = value;
            }
        }
        /// <summary>
        /// Gets or sets the transfer side.
        /// </summary>
        /// <value>
        /// The transfer side.
        /// </value>
        public int TransferSide
        {
            get { return cboTransferSide.SelectedIndex; }
            set { cboTransferSide.SelectedIndex = value; }
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
        /// Gets or sets a value indicating whether [is system].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is system]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystem { get; set; }
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

        #region GridLookup

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
                grdLookUpEditToAccount.Properties.DataSource = value;
                grdLookUpEditFromAccount.Properties.DataSource = value;
                grdLookUpEditReferentAccount.Properties.DataSource = value;
                grdLookUpEditToAccount.Properties.PopulateColumns();
                grdLookUpEditFromAccount.Properties.PopulateColumns();
                grdLookUpEditReferentAccount.Properties.PopulateColumns();
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
                        new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailByBudgetExpense", ColumnVisible = false },
                        new XtraColumn {ColumnName = "DetailByContract", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailByExpense", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailByCapitalPlan", ColumnVisible = false},
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpEditToAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditToAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditToAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdLookUpEditFromAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditFromAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditFromAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdLookUpEditReferentAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpEditReferentAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpEditReferentAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpEditToAccount.Properties.Columns[column.ColumnName].Visible = false;
                        grdLookUpEditFromAccount.Properties.Columns[column.ColumnName].Visible = false;
                        grdLookUpEditReferentAccount.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpEditToAccount.Properties.DisplayMember = "AccountNumber";
                grdLookUpEditToAccount.Properties.ValueMember = "AccountNumber";
                grdLookUpEditFromAccount.Properties.DisplayMember = "AccountNumber";
                grdLookUpEditFromAccount.Properties.ValueMember = "AccountNumber";



                grdLookUpEditReferentAccount.Properties.DisplayMember = "AccountNumber";
                grdLookUpEditReferentAccount.Properties.ValueMember = "AccountNumber";
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
                    }
                    else
                    {
                        grdLookUpEditBudgetSource.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpEditBudgetSource.Properties.DisplayMember = "BudgetSourceCode";
                grdLookUpEditBudgetSource.Properties.ValueMember = "BudgetSourceId";
            }
        }
        #endregion

        #region Form Event

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            if (KeyValue != null)
                _accountTransferPresenter.Display(KeyValue);
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtAccountTransferCode.Focus();
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            return _accountTransferPresenter.Save();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(AccountTransferCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountTransferCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountTransferCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(FromAccount))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountSourceCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpEditFromAccount.Focus();
                return false;
            }
            if (!FromAccount[0].ToString().Equals("0"))//Chỉ cho phép TK đầu 0 thực hiện bút toán đơn - AnhNT 
            {
                if (string.IsNullOrEmpty(ToAccount))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountDestinationCode"),
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    grdLookUpEditToAccount.Focus();
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Control Event

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditFromAccount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditFromAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditFromAccount.SelectionLength == grdLookUpEditFromAccount.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditFromAccount.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditToAccount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditToAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditToAccount.SelectionLength == grdLookUpEditToAccount.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditToAccount.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditReferentAccount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditReferentAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditReferentAccount.SelectionLength == grdLookUpEditReferentAccount.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditReferentAccount.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLookUpEditBudgetSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditBudgetSource.SelectionLength == grdLookUpEditBudgetSource.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditBudgetSource.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLookUpEditFromAccount_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                        grdLookUpEditFromAccount.Properties.DisplayMember = "AccountNumber";
                        grdLookUpEditFromAccount.Properties.ValueMember = "AccountId";
                        grdLookUpEditFromAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;

                    }
                }
            }
        }

        private void grdLookUpEditToAccount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                        grdLookUpEditToAccount.Properties.DisplayMember = "AccountNumber";
                        grdLookUpEditToAccount.Properties.ValueMember = "AccountId";
                        grdLookUpEditToAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;
                    }
                }
            }
        }

        /// <summary>
        /// Thêm nguồn vốn
        /// </summary>
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
        #endregion
    }
}
