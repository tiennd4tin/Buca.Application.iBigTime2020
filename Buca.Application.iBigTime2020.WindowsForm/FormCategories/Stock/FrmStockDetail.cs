/***********************************************************************
 * <copyright file="FrmXtraStockDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account;
using DevExpress.Utils;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Stock
{
    /// <summary>
    /// Class FrmXtraStockDetail.
    /// </summary>
    public partial class FrmStockDetail : FrmXtraBaseCategoryDetail, IStockView, IAccountsView
    {
        /// <summary>
        /// The _stock presenter
        /// </summary>
        private readonly StockPresenter _stockPresenter;
        private readonly AccountsPresenter _accountsPresenter;

        #region Property Stock
        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>The cus identifier.</value>
        public string StockId { get; set; }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>The cus identifier.</value>
        public string StockCode
        {
            get { return txtStockCode.Text; }
            set { txtStockCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>The cus identifier.</value>
        public string StockName
        {
            get { return txtStockName.Text; }
            set { txtStockName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>The cus identifier.</value>
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>The cus identifier.</value>
        public bool IsActive
        {
            get { return chkActive.Checked; }
            set { chkActive.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the default account number.
        /// </summary>
        /// <value>The default account number.</value>
        public string DefaultAccountNumber
        {
            get
            {
                if (string.IsNullOrEmpty(cboDefaultAccountNumber.Text))
                    return null;
                return (string)cboDefaultAccountNumber.GetColumnValue("AccountNumber");
            }
            set
            {
                cboDefaultAccountNumber.EditValue = value;
                if (cboDefaultAccountNumber.EditValue == null) return;
                var accountName = (string)cboDefaultAccountNumber.GetColumnValue("AccountName");
                txtAccountName.Text = accountName;
            }
        }

        #endregion

        #region Property Accounts

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                cboDefaultAccountNumber.Properties.DataSource = value.Where(a => a.DetailByInventoryItem).OrderBy(a => a.Grade).ToList();
                cboDefaultAccountNumber.Properties.ForceInitialize();
                cboDefaultAccountNumber.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "Số TK",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 50,
                    Alignment = HorzAlignment.Center
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountName",
                    ColumnCaption = "Tên TK",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 200
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });

                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByContract", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByExpense", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCapitalPlan", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false });
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
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetExpense", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboDefaultAccountNumber.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDefaultAccountNumber.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboDefaultAccountNumber.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboDefaultAccountNumber.Properties.DisplayMember = "AccountNumber";
                cboDefaultAccountNumber.Properties.ValueMember = "AccountNumber";
            }
        }

        #endregion

        #region Initialize

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmStockDetail"/> class.
        /// </summary>
        public FrmStockDetail()
        {
            InitializeComponent();
            _stockPresenter = new StockPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountsPresenter.DisplayActive();
            if (KeyValue != null)
                _stockPresenter.Display(KeyValue);
            else
                txtStockCode.Text = GetAutoNumber();
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtStockCode.Focus();
        } 
        #endregion

        #region Functions

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            var result = _stockPresenter.Save();
            if (!string.IsNullOrEmpty(result))
            {
                GlobalVariable.StockIDInventoryItemDetailForm = result;
            }
            return result;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(StockCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResStockCode"),
                                ResourceHelper.GetResourceValueByName("ResStockCode"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(StockName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResStockName"),
                                ResourceHelper.GetResourceValueByName("ResStockName"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockName.Focus();
                return false;
            }

            //if (string.IsNullOrEmpty(DefaultAccountNumber))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResStockDefaultAccountNumber"),
            //                    ResourceHelper.GetResourceValueByName("ResStockDefaultAccountNumber"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cboDefaultAccountNumber.Focus();
            //    return false;
            //}

            return true;
        } 
        #endregion

        #region Event control

        /// <summary>
        /// Handles the EditValueChanged event of the cboDefaultAccountNumber control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboDefaultAccountNumber_EditValueChanged(object sender, System.EventArgs e)
        {
            if (cboDefaultAccountNumber.EditValue == null) return;
            var accountName = (string)cboDefaultAccountNumber.GetColumnValue("AccountName");
            txtAccountName.Text = accountName;
        }

        /// <summary>
        /// Button thêm mới account
        /// </summary>
        private void cboDefaultAccountNumber_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                        cboDefaultAccountNumber.Properties.DisplayMember = "AccountNumber";
                        cboDefaultAccountNumber.Properties.ValueMember = "AccountId";
                        cboDefaultAccountNumber.EditValue = GlobalVariable.AccountIDAccountTransferForm;
                    }
                }
            }
        }
        #endregion

    }
}
