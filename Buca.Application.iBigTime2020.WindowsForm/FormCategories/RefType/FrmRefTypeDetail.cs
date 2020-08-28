using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Enum;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.RefType
{
    public partial class FrmRefTypeDetail : FrmXtraBaseCategoryDetail, IRefTypeView, IAccountsView
    {
        private readonly AccountsPresenter _accountsPresenter;
        private readonly RefTypePresenter _refTypePresenter;

        public FrmRefTypeDetail()
        {
            InitializeComponent();
            _refTypePresenter = new RefTypePresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
        }

        /// <summary>
        ///     Sets the accounts.
        /// </summary>
        /// <value>
        ///     The accounts.
        /// </value>
        public IList<AccountModel> Accounts
        {
            set
            {
                cboDefaultTaxAccountId.Properties.DataSource = value.Where(x => x.IsActive).ToList();
                cboDefaultTaxAccountId.Properties.PopulateColumns();

                cboDefaultCreditAccountId.Properties.DataSource = value.Where(x => x.IsActive).ToList();
                cboDefaultCreditAccountId.Properties.PopulateColumns();

                cboDefaultDebitAccountId.Properties.DataSource = value.Where(x => x.IsActive).ToList();
                cboDefaultDebitAccountId.Properties.PopulateColumns();

                var treeColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "AccountId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "AccountNumber",
                        ColumnVisible = true,
                        ColumnWith = 50,
                        ColumnCaption = "Tài khoản"
                    },
                    new XtraColumn {ColumnName = "AccountCategoryId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "AccountName",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Tên tài khoản"
                    },
                    new XtraColumn {ColumnName = "DetailByBudgetExpense", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountForeignName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountCategoryKind", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBudgetSource", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBudgetChapter", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBudgetKindItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBudgetItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBudgetSubItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByMethodDistribute", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByAccountingObject", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByActivity", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByProject", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByTask", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailBySupply", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByInventoryItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByFixedAsset", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByFund", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBankAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByProjectActivity", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByInvestor", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByCurrency",ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByContract", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByExpense", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByCapitalPlan", ColumnVisible = false},
                };

                foreach (var column in treeColumnsCollection)
                    if (column.ColumnVisible)
                    {
                        cboDefaultTaxAccountId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDefaultTaxAccountId.Properties.SortColumnIndex = column.ColumnPosition;

                        cboDefaultCreditAccountId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDefaultCreditAccountId.Properties.SortColumnIndex = column.ColumnPosition;

                        cboDefaultDebitAccountId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDefaultDebitAccountId.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                    {
                        cboDefaultTaxAccountId.Properties.Columns[column.ColumnName].Visible = false;

                        cboDefaultCreditAccountId.Properties.Columns[column.ColumnName].Visible = false;

                        cboDefaultDebitAccountId.Properties.Columns[column.ColumnName].Visible = false;
                    }
                cboDefaultTaxAccountId.Properties.DisplayMember = "AccountNumber";
                cboDefaultTaxAccountId.Properties.ValueMember = "AccountNumber";
                cboDefaultTaxAccountId.Properties.NullText = string.Empty;
                cboDefaultTaxAccountId.Properties.ShowFooter = false;

                cboDefaultCreditAccountId.Properties.DisplayMember = "AccountNumber";
                cboDefaultCreditAccountId.Properties.ValueMember = "AccountNumber";
                cboDefaultCreditAccountId.Properties.NullText = string.Empty;
                cboDefaultCreditAccountId.Properties.ShowFooter = false;

                cboDefaultDebitAccountId.Properties.DisplayMember = "AccountNumber";
                cboDefaultDebitAccountId.Properties.ValueMember = "AccountNumber";
                cboDefaultDebitAccountId.Properties.NullText = string.Empty;
                cboDefaultDebitAccountId.Properties.ShowFooter = false;
            }
        }

        /// <summary>
        /// Handles the ButtonClick event of the cboDefaultCreditAccountId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void cboDefaultCreditAccountId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                ShowAccountDetail();
            if (e.Button.Index == 2)
                cboDefaultCreditAccountId.EditValue = null;
        }
        private void cboDefaultDebitAccountId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                ShowAccountDetail();
            if (e.Button.Index == 2)
                cboDefaultDebitAccountId.EditValue = null;
        }
        private void cboDefaultTaxAccountId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                ShowAccountDetail();
            if (e.Button.Index == 2)
                cboDefaultTaxAccountId.EditValue = null;
        }
        /// <summary>
        /// Gets the account detail.
        /// </summary>
        /// <returns></returns>
        private FrmXtraBaseTreeDetail GetAccountDetail()
        {
            return new FrmAccountDetail();
        }

        private FrmXtraBaseParameter GetAccounts(string parameter, TextEdit txtTextEdit)
        {
            return new FrmAccountList(parameter, txtTextEdit);
        }

        /// <summary>
        /// Shows the account detail.
        /// </summary>
        private void ShowAccountDetail()
        {
            try
            {
                using (var frmDetail = GetAccountDetail())
                {
                    frmDetail.KeyFieldName = "AccountId";
                    frmDetail.ActionMode = ActionModeEnum.AddNew;
                    frmDetail.HelpTopicId = HelpTopicId;
                    frmDetail.KeyValue = null;
                    if (frmDetail.ShowDialog() == DialogResult.OK) { }
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        /// <summary>
        /// Shows the account detail.
        /// </summary>
        private void ShowAccounts(string parameter, TextEdit txtTextEdit)
        {
            try
            {
                using (var frmDetail = GetAccounts(parameter, txtTextEdit))
                {
                    if (frmDetail.ShowDialog() == DialogResult.OK) { }
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDefaultDebitAccountCategoryId_Click(object sender, EventArgs e)
        {
            ShowAccounts(DefaultDebitAccountCategoryId, txtDefaultDebitAccountCategoryId);
        }

        private void btnDefaultCreditAccountCategoryId_Click(object sender, EventArgs e)
        {
            ShowAccounts(DefaultCreditAccountCategoryId, txtDefaultCreditAccountCategoryId);
        }

        private void btnDefaultTaxAccountCategoryId_Click(object sender, EventArgs e)
        {
            ShowAccounts(DefaultTaxAccountCategoryId, txtDefaultTaxAccountCategoryId);
        }

        #region Overide

        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtDefaultDebitAccountCategoryId.Focus();
            cboDefaultTaxAccountId.Properties.NullText = "";

            cboDefaultCreditAccountId.Properties.NullText = "";

            cboDefaultDebitAccountId.Properties.NullText = "";
        }

        /// <summary>
        /// Loads the look up edit.
        /// </summary>
        public void LoadLookUpEdit()
        {
            _accountsPresenter.Display();
        }

        /// <summary>
        ///     Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountsPresenter.Display();
            if (KeyValue != null)
                _refTypePresenter.Display(int.Parse(KeyValue));
        }

        /// <summary>
        ///     Saves the data.
        /// </summary>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        protected override string SaveData()
        {
            return _refTypePresenter.Save();
        }

        #endregion

        #region Property

        /// <summary>
        ///     Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        ///     The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the reference type.
        /// </summary>
        /// <value>
        ///     The name of the reference type.
        /// </value>
        public string RefTypeName
        {
            get { return txtRefTypeName.Text; }
            set
            {
                txtRefTypeName.Text = value;
            }
        }

        /// <summary>
        ///     Gets or sets the default debit account category Identifier.
        /// </summary>
        /// <value>
        ///     The default debit account category Identifier.
        /// </value>
        public string DefaultDebitAccountCategoryId
        {
            get { return txtDefaultDebitAccountCategoryId.Text; }
            set
            {
                txtDefaultDebitAccountCategoryId.Text = value;
            }
        }

        /// <summary>
        ///     Gets or sets the default debit account Identifier.
        /// </summary>
        /// <value>
        ///     The default debit account Identifier.
        /// </value>
        public string DefaultDebitAccountId
        {
            get { return cboDefaultDebitAccountId.EditValue == null ? null : cboDefaultDebitAccountId.EditValue.ToString(); }
            set
            {
                if (string.IsNullOrEmpty(txtDefaultDebitAccountCategoryId.EditValue.ToString()))
                    cboDefaultDebitAccountId.EditValue = "";
                else
                    cboDefaultDebitAccountId.EditValue = value;
            }
        }

        /// <summary>
        ///     Gets or sets the default credit account category Identifier.
        /// </summary>
        /// <value>
        ///     The default credit account category Identifier.
        /// </value>
        public string DefaultCreditAccountCategoryId
        {
            get { return txtDefaultCreditAccountCategoryId.Text; }
            set { txtDefaultCreditAccountCategoryId.Text = value; }
        }

        /// <summary>
        ///     Gets or sets the default credit account Identifier.
        /// </summary>
        /// <value>
        ///     The default credit account Identifier.
        /// </value>
        public string DefaultCreditAccountId
        {
            get { return cboDefaultCreditAccountId.EditValue == null ? null : cboDefaultCreditAccountId.EditValue.ToString(); }
            set
            {
                if (string.IsNullOrEmpty(txtDefaultCreditAccountCategoryId.EditValue.ToString()))
                    cboDefaultCreditAccountId.EditValue = "";
                else
                    cboDefaultCreditAccountId.EditValue = value;
            }
        }

        /// <summary>
        ///     Gets or sets the default tax account category Identifier.
        /// </summary>
        /// <value>
        ///     The default tax account category Identifier.
        /// </value>
        public string DefaultTaxAccountCategoryId
        {
            get { return txtDefaultTaxAccountCategoryId.Text; }
            set
            {
                txtDefaultTaxAccountCategoryId.Text = value;
            }
        }

        /// <summary>
        ///     Gets or sets the default tax account Identifier.
        /// </summary>
        /// <value>
        ///     The default tax account Identifier.
        /// </value>
        public string DefaultTaxAccountId
        {
            get { return cboDefaultTaxAccountId.EditValue == null ? null : cboDefaultTaxAccountId.EditValue.ToString(); }
            set
            {
                if (string.IsNullOrEmpty(txtDefaultTaxAccountCategoryId.EditValue.ToString()))
                    cboDefaultTaxAccountId.EditValue = "";
                else
                    cboDefaultTaxAccountId.EditValue = value;
            }
        }

        #endregion

        private void cboDefaultDebitAccountId_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Control button = sender as Control;
            var name = button.Name;
            var list = new List<string>();
            switch (name)
            {
                case "cboDefaultTaxAccountId":
                    list = new List<string>();
                    if (!string.IsNullOrEmpty(DefaultTaxAccountCategoryId))
                    {
                        list = DefaultTaxAccountCategoryId.Split(';').ToList();
                    }
                    cboDefaultTaxAccountId.Properties.DataSource = new AccountsPresenter(null).GetAccounts().Where(x => x.IsActive && (list.Contains(x.AccountNumber) || list.Contains(x.AccountCategoryId)));
                    break;
                case "cboDefaultCreditAccountId":
                    list = new List<string>();
                    if (!string.IsNullOrEmpty(DefaultCreditAccountCategoryId))
                    {
                        list = DefaultCreditAccountCategoryId.Split(';').ToList();
                    }
                    cboDefaultCreditAccountId.Properties.DataSource = new AccountsPresenter(null).GetAccounts().Where(x => x.IsActive && (list.Contains(x.AccountNumber) || list.Contains(x.AccountCategoryId)));
                    break;
                case "cboDefaultDebitAccountId":
                    list = new List<string>();
                    if (!string.IsNullOrEmpty(DefaultDebitAccountCategoryId))
                    {
                        list = DefaultDebitAccountCategoryId.Split(';').ToList();
                    }
                    cboDefaultDebitAccountId.Properties.DataSource = new AccountsPresenter(null).GetAccounts().Where(x => x.IsActive && (list.Contains(x.AccountNumber) || list.Contains(x.AccountCategoryId)));
                    break;
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtDefaultDebitAccountCategoryId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtDefaultDebitAccountCategoryId_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDefaultDebitAccountCategoryId.EditValue.ToString()))
                cboDefaultDebitAccountId.EditValue = "";
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtDefaultCreditAccountCategoryId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtDefaultCreditAccountCategoryId_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDefaultCreditAccountCategoryId.EditValue.ToString()))
                cboDefaultCreditAccountId.EditValue = "";
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtDefaultTaxAccountCategoryId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtDefaultTaxAccountCategoryId_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDefaultTaxAccountCategoryId.EditValue.ToString()))
                cboDefaultTaxAccountId.EditValue = "";
        }
    }
}