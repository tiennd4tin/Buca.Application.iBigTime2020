using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DevExpress.XtraEditors;


namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account
{
    public partial class FrmAccountDetail : FrmXtraBaseTreeDetail, IAccountView, IAccountsView,IAccountCategoriesView
    {
       
        #region Declare

        private readonly AccountsPresenter _accountsPresenter;
        private readonly AccountPresenter _accountPresenter;
        private readonly AccountCategoriesPresenter _accountCategoryPresenter;
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        private IList<AccountModel> _myListAccount;
        private string _currentCode;
        private int _gradeNew;
        private int _ParentId { get; set; }

        #endregion
        public FrmAccountDetail()
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            _accountPresenter = new AccountPresenter(this);
            _accountCategoryPresenter = new AccountCategoriesPresenter(this);
            if (ActionMode == ActionModeEnum.AddNew)
                this.chkIsActive.Checked = true;
        }
        protected override void InitData()
        {
            _accountsPresenter.Display();
            _accountCategoryPresenter.Display();
            if (KeyValue != null)
            {
                _accountPresenter.Display(KeyValue);
                _currentCode = AccountNumber;
            }
            else
            {
                if (CurrentNode != null)
                {
                    txtAccountCode.Text = ((AccountModel)CurrentNode).AccountNumber;
                    //txtAccountName.Text = @"Tài khoản mới";
                    this.ParentId = ((AccountModel) CurrentNode).AccountId;
                    this.AccountCategoryId = ((AccountModel) CurrentNode).AccountCategoryId;
                    this.AccountCategoryKind = ((AccountModel) CurrentNode).AccountCategoryKind;
                    //grdLookUpParentID.Text = ((AccountModel)CurrentNode).AccountNumber;
                    // cboBalanceSide.EditValue = ((AccountModel) CurrentNode).AccountCategoryKind;
                }
            }
        }
        protected override void InitControls()
        {
            grdLookUpParentID.Properties.Enabled = ActionMode != ActionModeEnum.Edit || !HasChildren;
        }

        #region Implement
        public string AccountId { get; set; }

        public string AccountNumber
        {
            get
            {
                return txtAccountCode.Text.Trim();
            }
            set
            {
                txtAccountCode.Text = value;
            }
        }

        public string AccountCategoryId
        {
            get
            {
                if (grdLookUpCategoryAccount.EditValue == null) return null;
                return grdLookUpCategoryAccount.EditValue.ToString();
            }
            set
            {
                grdLookUpCategoryAccount.EditValue = value;

            }
        }

        public string ParentId
        {
            get
            {
                if (grdLookUpParentID.EditValue == null) return null;
                return (string)grdLookUpParentID.GetColumnValue(KeyFieldName);
            }
            set
            {
                grdLookUpParentID.EditValue = value;

            }
        }

        public string AccountName
        {
            get
            {
                return txtAccountName.Text.Trim();
            }
            set
            {
                txtAccountName.Text = value;
            }
        }

        public string AccountForeignName { get; set; }

        public string Description { get; set; }

        public int AccountCategoryKind
        {
            get { return cboBalanceSide.SelectedIndex; }
            set { cboBalanceSide.SelectedIndex = value; }
        }

        public bool DetailByBudgetSource
        {
            get { return chkSource.Checked; }
            set { chkSource.Checked = value; }
        }

        public bool DetailByBudgetChapter
        {
            get { return chkChapter.Checked; }
            set { chkChapter.Checked = value; }
        }

        public bool DetailByBudgetKindItem
        {
            get { return chkKindItem.Checked; }
            set { chkKindItem.Checked = value; }
        }

        public bool DetailByBudgetItem {
            get { return chkBudgetItem.Checked; }
            set { chkBudgetItem.Checked = value; }
        }

        public bool DetailByBudgetSubItem {
            get { return chkSubItem.Checked; }
            set { chkSubItem.Checked = value; }
        }

        public bool DetailByMethodDistribute {
            get { return chkMethodDistribute.Checked; }
            set { chkMethodDistribute.Checked = value; }
        }

        public bool DetailByAccountingObject {
            get { return chkAccountObject.Checked; }
            set { chkAccountObject.Checked = value; }
        }

        public bool DetailByActivity {
            get { return chkActivity.Checked; }
            set { chkActivity.Checked = value; }
        }

        public bool DetailByProject {
            get { return chkProject.Checked; }
            set { chkProject.Checked = value; }
        }

        public bool DetailByTask { get; set;
            //get { return chkTask.Checked; }
            //set { chkTask.Checked = value; }
        }

        public bool DetailBySupply {
            get { return chkSupply.Checked; }
            set { chkSupply.Checked = value; }
        }

        public bool DetailByInventoryItem {
            get { return chkInventoryItem.Checked; }
            set { chkInventoryItem.Checked = value; }
        }

        public bool DetailByFixedAsset {
            get { return chkFixedAsset.Checked; }
            set { chkFixedAsset.Checked = value; }
        }

        public bool DetailByFund {
            get { return chkFun.Checked; }
            set { chkFun.Checked = value; }
        }

        public bool DetailByBankAccount {
            get { return chkBankAccount.Checked; }
            set { chkBankAccount.Checked = value; }
        }

        public bool DetailByProjectActivity { get; set;
            //get { return chkProjectActivity.Checked; }
            //set { chkProjectActivity.Checked = value; }
        }

        public bool DetailByInvestor { get; set;
            //get { return chkInvestor.Checked; }
            //set { chkInvestor.Checked = value; }
        }

        public int Grade { get; set; }

        public bool IsParent { get; set;
            //get { return chkParent.Checked; }
            //set { chkParent.Checked = value; }
        }

        public bool IsActive {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }
        public bool DetailByCurrency
        {
            get { return chkDetailByCurrency.Checked; }
            set { chkDetailByCurrency.Checked = value; }
        }

        public bool IsDisplayOnAccountBalanceSheet { get; set;
            //get { return chkonBalance.Checked; }
            //set { chkonBalance.Checked = value; }
        }

        public bool IsDisplayBalanceOnReport { get; set;
            //get { return chkOnReport.Checked; }
            //set { chkOnReport.Checked = value; }
        }
        protected override string SaveData()
        {
            var result = _accountPresenter.Save();
            if (!String.IsNullOrEmpty(result))
                GlobalVariable.AccountIDAccountTransferForm = result;

            return result;
        }

        public bool DetailByExpense
        {
            get { return chkExpense.Checked; }
            set { chkExpense.Checked = value; }
        }

        public bool DetailByContract
        {
            get { return chkContract.Checked; }
            set { chkContract.Checked = value; }
        }

        public bool DetailByCapitalPlan
        {
            get { return chkCapitalPlan.Checked; }
            set { chkCapitalPlan.Checked = value; }
        }

        public bool DetailByBudgetExpense
        {
            get { return chkDetailByBudgetExpense.Checked; }
            set { chkDetailByBudgetExpense.Checked = value; }
        }

        public IList<AccountModel> Accounts
        {
            set
            {
                grdLookUpParentID.Properties.DataSource = value.Where(x => x.AccountId != KeyValue && x.IsActive).ToList();
                grdLookUpParentID.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "AccountId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "AccountNumber",
                        ColumnCaption = "Mã",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 70
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountName",
                        ColumnCaption = "Tên tài khoản",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 230
                    },
                    new XtraColumn {ColumnName = "AccountCategoryId", ColumnVisible = false},

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

                    new XtraColumn {ColumnName = "DetailByCurrency", ColumnVisible = false},

                    new XtraColumn {ColumnName = "DetailByBudgetExpense", ColumnVisible = false},

                    new XtraColumn {ColumnName = "DetailByContract", ColumnVisible = false},

                    new XtraColumn {ColumnName = "DetailByExpense", ColumnVisible = false},

                    new XtraColumn {ColumnName = "DetailByCapitalPlan", ColumnVisible = false},
                };

                foreach (var column in treeColumnsCollection)
                    if (column.ColumnVisible)
                    {
                        grdLookUpParentID.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpParentID.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpParentID.Properties.PopupWidth = 300;
                    }
                    else
                    {
                        grdLookUpParentID.Properties.Columns[column.ColumnName].Visible = false;
                    }
                grdLookUpParentID.Properties.DisplayMember = "AccountNumber";
                grdLookUpParentID.Properties.ValueMember = KeyFieldName;
                grdLookUpParentID.Properties.NullText = string.Empty;
                grdLookUpParentID.Properties.ShowFooter = false;
            }
        }

        public IList<AccountCategoryModel> AccountCategories
        {
            set
            {
                grdLookUpCategoryAccount.Properties.DataSource = value;
                grdLookUpCategoryAccount.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AccountCategoryId",
                        ColumnCaption = "Mã nhóm tài khoản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 70},
                    new XtraColumn
                    {
                        ColumnName = "AccountCategoryKind", ColumnVisible = false,
                    },
                    new XtraColumn {
                        ColumnName = "AccountCategoryName",
                        ColumnCaption = "Tên nhóm tài khoản",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 230},
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

                    new XtraColumn {ColumnName = "DetailByBankAccount", ColumnVisible = false},

                    new XtraColumn {ColumnName = "DetailByFund", ColumnVisible = false},

                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                };

                foreach (var column in treeColumnsCollection)
                    if (column.ColumnVisible)
                    {
                        grdLookUpCategoryAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpCategoryAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpCategoryAccount.Properties.PopupWidth = 300;
                        //grdLookUpCategoryAccount.Properties.Columns[2].Width = 300;
                        //grdLookUpCategoryAccount.Properties.Columns[1].Width = 100;
                        //grdLookUpCategoryAccount.Properties.Columns[3].Width = 100;
                    }
                    else
                    {
                        grdLookUpCategoryAccount.Properties.Columns[column.ColumnName].Visible = false;
                    }
                grdLookUpCategoryAccount.Properties.DisplayMember = "AccountCategoryId";
                grdLookUpCategoryAccount.Properties.ValueMember = "AccountCategoryId";
                grdLookUpCategoryAccount.Properties.NullText = string.Empty;
                grdLookUpCategoryAccount.Properties.ShowFooter = false;
            }
        }

        #endregion

        private void grdLookUpCategoryAccount_EditValueChanged(object sender, EventArgs e)
        {
            if (grdLookUpCategoryAccount.GetColumnValue("AccountCategoryKind") != null)
            {
                chkSource.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByBudgetSource"));

                chkChapter.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByBudgetChapter"));

                chkKindItem.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByBudgetKindItem"));

                chkBudgetItem.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByBudgetItem"));

                chkSubItem.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByBudgetSubItem"));

                chkMethodDistribute.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByMethodDistribute"));

                chkAccountObject.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByAccountingObject"));

                chkActivity.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByActivity"));

                chkProject.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByProject"));

                //chkTask.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByTask"));

                //chkTask.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailBySupply"));

                chkInventoryItem.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByInventoryItem"));

                chkFixedAsset.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByFixedAsset"));

                chkFun.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByFund"));

                chkBankAccount.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByBankAccount"));

                chkDetailByBudgetExpense.Checked =
                    Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByBudgetExpense"));

                //chkProjectActivity.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByProjectActivity"));

                //chkInvestor.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByInvestor"));

                //chkonBalance.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("IsDisplayOnAccountBalanceSheet"));

                //chkOnReport.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("IsDisplayBalanceOnReport"));
                chkExpense.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByExpense"));
                chkContract.Checked = Convert.ToBoolean(grdLookUpCategoryAccount.GetColumnValue("DetailByContract"));
            }
            //else
               // chkChapter.Checked = false;
        }
        protected override bool ValidData()
        {
            string check=new AccountPresenter(null).CheckExistAccountNumber(AccountId,AccountNumber);
            if (check == "YES")
            {
                if (XtraMessageBox.Show("Số tài khoản đã phát sinh chứng từ liên quan. Bạn có muốn cập nhật lại tất cả không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return false;
                }
            }
            if (string.IsNullOrEmpty(AccountNumber))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountNumberMissing"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AccountName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountNameMissing"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountCode.Focus();
                return false;
            }
            return true;
        }
    }
}
