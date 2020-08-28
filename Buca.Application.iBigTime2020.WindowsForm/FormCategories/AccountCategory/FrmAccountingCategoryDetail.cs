using System.Windows.Forms;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountCategory
{
    /// <summary>
    /// Class FrmAccountingCategoryDetail.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseCategoryDetail" />
    public partial class FrmAccountingCategoryDetail : FrmXtraBaseCategoryDetail, IAccountCategoryView
    {
        private readonly AccountCategoryPresenter _accountCategoryPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAccountingCategoryDetail"/> class.
        /// </summary>
        public FrmAccountingCategoryDetail()
        {
            InitializeComponent();
            _accountCategoryPresenter = new AccountCategoryPresenter(this);
        }

        #region IAccountCategoryView

        /// <summary>
        /// Gets or sets the account category identifier.
        /// </summary>
        /// <value>The account category identifier.</value>
        public string AccountCategoryId
        {
            get { return txtAccountCategoryId.Text; }
            set { txtAccountCategoryId.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the account category.
        /// </summary>
        /// <value>The name of the account category.</value>
        public string AccountCategoryName
        {
            get { return string.IsNullOrEmpty(txtAccountCategoryName.Text) ? null : txtAccountCategoryName.Text.Trim(); }
            set { txtAccountCategoryName.Text = value; }
        }

        /// <summary>
        /// Gets the kind of the account category.
        /// </summary>
        /// <value>The kind of the account category.</value>
        public int AccountCategoryKind
        {
            get
            {
                if (string.IsNullOrEmpty(choAccountCategoryKind.Text))
                    return 0;
                return choAccountCategoryKind.SelectedIndex;
            }
            set { choAccountCategoryKind.SelectedIndex = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by budget source].
        /// </summary>
        /// <value><c>true</c> if [detail by budget source]; otherwise, <c>false</c>.</value>
        public bool DetailByBudgetSource
        {
            get { return chkDetailByBudgetSource.Checked; }
            set { chkDetailByBudgetSource.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by budget chapter].
        /// </summary>
        /// <value><c>true</c> if [detail by budget chapter]; otherwise, <c>false</c>.</value>
        public bool DetailByBudgetChapter
        {
            get { return chkDetailByBudgetChapter.Checked; }
            set { chkDetailByBudgetChapter.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by budget kind item].
        /// </summary>
        /// <value><c>true</c> if [detail by budget kind item]; otherwise, <c>false</c>.</value>
        public bool DetailByBudgetKindItem
        {
            get { return chkDetailByBudgetKindItem.Checked; }
            set { chkDetailByBudgetKindItem.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by budget item].
        /// </summary>
        /// <value><c>true</c> if [detail by budget item]; otherwise, <c>false</c>.</value>
        public bool DetailByBudgetItem
        {
            get { return chkDetailByBudgetItem.Checked; }
            set { chkDetailByBudgetItem.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by budget sub item].
        /// </summary>
        /// <value><c>true</c> if [detail by budget sub item]; otherwise, <c>false</c>.</value>
        public bool DetailByBudgetSubItem
        {
            get { return chkDetailByBudgetSubItem.Checked; }
            set { chkDetailByBudgetSubItem.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by method distribute].
        /// </summary>
        /// <value><c>true</c> if [detail by method distribute]; otherwise, <c>false</c>.</value>
        public bool DetailByMethodDistribute
        {
            get { return chkDetailByMethodDistribute.Checked; }
            set { chkDetailByMethodDistribute.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by accounting object].
        /// </summary>
        /// <value><c>true</c> if [detail by accounting object]; otherwise, <c>false</c>.</value>
        public bool DetailByAccountingObject
        {
            get { return chkDetailByAccountingObject.Checked; }
            set { chkDetailByAccountingObject.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by activity].
        /// </summary>
        /// <value><c>true</c> if [detail by activity]; otherwise, <c>false</c>.</value>
        public bool DetailByActivity
        {
            get { return chkDetailByActivity.Checked; }
            set { chkDetailByActivity.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by project].
        /// </summary>
        /// <value><c>true</c> if [detail by project]; otherwise, <c>false</c>.</value>
        public bool DetailByProject
        {
            get { return chkDetailByProject.Checked; }
            set { chkDetailByProject.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by task].
        /// </summary>
        /// <value><c>true</c> if [detail by task]; otherwise, <c>false</c>.</value>
        public bool DetailByTask { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by supply].
        /// </summary>
        /// <value><c>true</c> if [detail by supply]; otherwise, <c>false</c>.</value>
        public bool DetailBySupply { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by inventory item].
        /// </summary>
        /// <value><c>true</c> if [detail by inventory item]; otherwise, <c>false</c>.</value>
        public bool DetailByInventoryItem
        {
            get { return chkDetailByInventoryItem.Checked; }
            set { chkDetailByInventoryItem.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by fixed asset].
        /// </summary>
        /// <value><c>true</c> if [detail by fixed asset]; otherwise, <c>false</c>.</value>
        public bool DetailByFixedAsset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by bank account].
        /// </summary>
        /// <value><c>true</c> if [detail by bank account]; otherwise, <c>false</c>.</value>
        public bool DetailByBankAccount
        {
            get { return chkDetailByBankAccount.Checked; }
            set { chkDetailByBankAccount.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [detail by fund].
        /// </summary>
        /// <value><c>true</c> if [detail by fund]; otherwise, <c>false</c>.</value>
        public bool DetailByFund
        {
            get { return chkDetailByFund.Checked; }
            set { chkDetailByFund.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        #endregion

        #region overrides method

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            //chkDetailByBudgetChapter.Enabled = false;
            txtAccountCategoryName.Focus();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
                _accountCategoryPresenter.Display(KeyValue);
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            if (string.IsNullOrEmpty(AccountCategoryName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountCategoryNameRequired"), detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountCategoryName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>System.Int32.</returns>
        protected override string SaveData()
        {
            return _accountCategoryPresenter.Save();
        }

        #endregion
    }
}