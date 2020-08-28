using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetExpense
{
    /// <summary>
    /// Class FrmBudgetExpenseDetail.
    /// </summary>
    public partial class FrmBudgetExpenseDetail : FrmXtraBaseCategoryDetail, IBudgetExpenseView
    {
        private readonly BudgetExpensePresenter _budgetExpensePresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBudgetExpenseDetail"/> class.
        /// </summary>
        public FrmBudgetExpenseDetail()
        {
            InitializeComponent();
            _budgetExpensePresenter = new BudgetExpensePresenter(this);
        }

        /// <summary>
        /// Gets or sets the budget expense identifier.
        /// </summary>
        /// <value>The budget expense identifier.</value>
        public string BudgetExpenseId { get; set; }

        /// <summary>
        /// Gets or sets the budget expense code.
        /// </summary>
        /// <value>The budget expense code.</value>
        public string BudgetExpenseCode
        {
            get { return txtBudgetExpenseCode.Text; }
            set { txtBudgetExpenseCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the budget expense.
        /// </summary>
        /// <value>The name of the budget expense.</value>
        public string BudgetExpenseName
        {
            get { return txtBudgetExpenseName.Text; }
            set { txtBudgetExpenseName.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="!:BudgetExpenseEntity" /> is inactive.
        /// </summary>
        /// <value><c>true</c> if inactive; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return (bool)chkIsActive.EditValue; }
            set { chkIsActive.EditValue = value; }
        }

        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the type of the budget expense.
        /// </summary>
        /// <value>The type of the budget expense.</value>
        public int BudgetExpenseType
        {
            get { return cboBudgetExpenseType.SelectedIndex; }
            set { cboBudgetExpenseType.SelectedIndex = value; }
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
                _budgetExpensePresenter.Display(KeyValue);
            else
            {
                IsSystem = false;
                IsActive = true;
            }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtBudgetExpenseCode.Focus();
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string SaveData()
        {
            return _budgetExpensePresenter.Save();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            if (string.IsNullOrEmpty(BudgetExpenseCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("BudgetExpenseCode"), detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetExpenseCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(BudgetExpenseName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("BudgetExpenseName"), detailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetExpenseName.Focus();
                return false;
            }

            return true;
        }
    }
}