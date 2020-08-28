/***********************************************************************
 * <copyright file="FrmXtraAccountingObjectDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Windows.Forms;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using BuCA.Application.iBigTime2020.Session;
namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank
{

    /// <summary>
    /// FrmXtraAccountingObjectDetail class
    /// </summary>
    internal partial class FrmBankDetail : FrmXtraBaseCategoryDetail, IBankView
    {
        #region Property

        /// <summary>
        /// The _accounting object presenter
        /// </summary>
        private readonly BankPresenter _bankPresenter;

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        public string BankAccount
        {
            get { return txtBankAccount.Text; }
            set { txtBankAccount.Text = value; }
        }

        /// <summary>
        /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the bank address.
        /// </summary>
        /// <value>{D255958A-8513-4226-94B9-080D98F904A1}The bank address.</value>
        public string BankAddress
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        /// <summary>
        /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the name of the bank.
        /// </summary>
        /// <value>{D255958A-8513-4226-94B9-080D98F904A1}The name of the bank.</value>
        public string BankName
        {
            get { return txtBankName.Text; }
            set { txtBankName.Text = value; }
        }

        /// <summary>
        /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the description.
        /// </summary>
        /// <value>{D255958A-8513-4226-94B9-080D98F904A1}The description.</value>
        public string Description
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>{D255958A-8513-4226-94B9-080D98F904A1}<c>true</c> if [is active]; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return cbIsActive.Checked; }
            set { cbIsActive.Checked = value; }
        }
        /// <summary>
        /// {D255958A-8513-4226-94B9-080D98F904A1}Gets or sets the budget code.
        /// </summary>
        /// <value>The budget code.</value>
        public string BudgetCode
        {
            get { return txtBudgetCode.Text.Trim(); }
            set { txtBudgetCode.Text = value; }
        }

        public bool IsOpenInBank
        {
            get { return radIsOpenInBank.SelectedIndex == 1 ? true : false; }
            set
            {
                if (value)
                    radIsOpenInBank.SelectedIndex = 1;
                else
                    radIsOpenInBank.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBankDetail"/> class.
        /// </summary>
        public FrmBankDetail()
        {
            InitializeComponent();
            _bankPresenter = new BankPresenter(this);

        }

        #endregion

        #region override

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            groupboxMain.Text = ResourceHelper.GetResourceValueByName("ResCommonCaption");

            base.InitControls();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
            {
                _bankPresenter.Display(KeyValue);
            }
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(BankAccount))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBankCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBankAccount.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(BankAccount) && _bankPresenter.CodeIsExist(KeyValue, BankAccount.Trim()))
            {
                XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResBankCodeDuplicate"), BankAccount.Trim()),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBankAccount.Text = "";
                txtBankAccount.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BankName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBankName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBankName.Focus();
                return false;
            }
            if(radIsOpenInBank.SelectedIndex == -1)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResIsOpenInBank"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                radIsOpenInBank.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            var result = _bankPresenter.Save();
            if (!string.IsNullOrEmpty(result))
                GlobalVariable.BankIDProjectDetailForm = result;
            return result;
        }

        #endregion
    }

}