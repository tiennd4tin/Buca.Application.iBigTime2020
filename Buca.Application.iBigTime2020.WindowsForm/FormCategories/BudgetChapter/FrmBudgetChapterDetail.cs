/***********************************************************************
 * <copyright file="FrmXtraBudgetChapterDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Tuesday, February 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using BuCA.Application.iBigTime2020.Session;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetChapter
{
    public partial class FrmBudgetChapterDetail : FrmXtraBaseCategoryDetail, IBudgetChapterView
    {
        private readonly BudgetChapterPresenter _budgetChapterPresenter;

        #region IBudgetChapterView Properties

        /// <summary>
        /// Gets or sets the budget source property identifier.
        /// </summary>
        /// <value>
        /// The budget source property identifier.
        /// </value>
        public string BudgetChapterId { get; set; }

        /// <summary>
        /// Gets or sets the budget source property code.
        /// </summary>
        /// <value>
        /// The budget source property code.
        /// </value>
        public string BudgetChapterCode
        {
            get { return txtBudgetChapterCode.Text; }
            set { txtBudgetChapterCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the budget source property.
        /// </summary>
        /// <value>
        /// The name of the budget source property.
        /// </value>
        public string BudgetChapterName
        {
            get { return txtBudgetChapterName.Text; }
            set { txtBudgetChapterName.Text = value; }
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

        public FrmBudgetChapterDetail()
        {
            InitializeComponent();
            _budgetChapterPresenter = new BudgetChapterPresenter(this);
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
                _budgetChapterPresenter.Display(KeyValue);
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            var resDetailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            if (string.IsNullOrEmpty(BudgetChapterCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetChapterCode"), resDetailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetChapterCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BudgetChapterName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetChapterName"), resDetailContent, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetChapterCode.Focus();
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
            var result = _budgetChapterPresenter.Save();
            if (!String.IsNullOrEmpty(result))
                GlobalVariable.BudgetChapterIDAccountingObjectDetailForm = result;
            return result;
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtBudgetChapterCode.Focus();
        }

    }
}