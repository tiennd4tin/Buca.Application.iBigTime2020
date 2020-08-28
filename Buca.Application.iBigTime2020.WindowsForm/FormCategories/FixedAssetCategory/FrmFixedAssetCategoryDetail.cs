using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAssetCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.FixedAssetCategory
{
    public partial class FrmFixedAssetCategoryDetail : FrmXtraBaseTreeDetail, IFixedAssetCategoriesView, IFixedAssetCategoryView, IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, IAccountsView
    {
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategoriesPresenter;
        private readonly FixedAssetCategoryPresenter _fixedAssetCategoryPresenter;
        private readonly BudgetChaptersPresenter _budgetChapterPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly AccountsPresenter _accountPresenter;


        /// <summary>
        /// Initializes a new instance of the <see cref="FrmFixedAssetCategoryDetail"/> class.
        /// </summary>
        public FrmFixedAssetCategoryDetail()
        {

            InitializeComponent();
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);
            _fixedAssetCategoryPresenter = new FixedAssetCategoryPresenter(this);
            _budgetChapterPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _accountPresenter = new AccountsPresenter(this);
           
            if (ActionMode == BuCA.Enum.ActionModeEnum.AddNew)
            {
                ckbActive.Checked = true;
            }
        }

        #region Propety
        public string FixedAssetCategoryCode
        {
            get { return txtFixedAssetCategoryCode.Text; }
            set { txtFixedAssetCategoryCode.Text = value; }
        }
        public string Description { get; set; }
        public string FixedAssetCategoryName
        {
            get { return txtFixedAssetCategoryName.Text; }
            set { txtFixedAssetCategoryName.Text = value; }
        }
        public string ParentId
        {
            get
            {
                if (grdLookUpFixedAssetCategoryKind.EditValue != null)
                    return grdLookUpFixedAssetCategoryKind.EditValue.ToString();
                return grdLookUpFixedAssetCategoryKind.Text;
            }
            set { grdLookUpFixedAssetCategoryKind.EditValue = value; }
        }
        public decimal LifeTime
        {
            get { return spnLifeTime.Value; }
            set { spnLifeTime.Value = value; }
        }
        public decimal DepreciationRate
        {
            get { return spnDepreciationRate.Value; }
            set { spnDepreciationRate.Value = value; }
        }
        public string OrgPriceAccount
        {
            get
            {
                if (grdLookUpOrgPriceAccount.EditValue != null)
                    return grdLookUpOrgPriceAccount.EditValue.ToString();
                return (grdLookUpOrgPriceAccount.Text);
            }
            set { grdLookUpOrgPriceAccount.EditValue = value; }
        }

        public string DepreciationAccount
        {
            get
            {

                if (grdLookUpDepreciationAccount.EditValue != null)
                    
                    return grdLookUpDepreciationAccount.EditValue.ToString();
                return grdLookUpDepreciationAccount.Text;

            }
            set { grdLookUpDepreciationAccount.EditValue = value; }
        }
        public string BudgetChapterCode { get; set; }


        public string FixedAssetCategoryId
        {
            get; set;

        }


        public int Grade
        {
            get; set;

        }

        public bool IsParent
        {
            get; set;
        }

        public string CapitalAccount
        {
            get
            {
                if (grdLookUpCapitalAccount.EditValue != null)
                    return (grdLookUpCapitalAccount.EditValue).ToString();
                return grdLookUpCapitalAccount.Text;
            }
            set { grdLookUpCapitalAccount.EditValue = value; }
        }

        public string BudgetKindItemCode { get; set; }

        public string BudgetSubKindItemCode { get; set; }

        public string BudgetItemCode { get; set; }

        public string BudgetSubItemCode { get; set; }

        public bool IsActive
        {
            get { return ckbActive.Checked; }
            set { ckbActive.Checked = value; }
        }

        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set
            {
                grdLookUpFixedAssetCategoryKind.Properties.DataSource = value;
                //treeList.BeginUpdate();
                grdLookUpFixedAssetCategoryKind.Properties.PopulateColumns();
                for (var i = 0; i < grdLookUpFixedAssetCategoryKind.Properties.Columns.Count; i++)
                {
                    if (grdLookUpFixedAssetCategoryKind.Properties.Columns[i].FieldName != "FixedAssetCategoryName" &&
                        grdLookUpFixedAssetCategoryKind.Properties.Columns[i].FieldName != "FixedAssetCategoryCode")
                    {
                        grdLookUpFixedAssetCategoryKind.Properties.Columns[i].Visible = false;
                    }
                    else
                    {
                        grdLookUpFixedAssetCategoryKind.Properties.Columns["FixedAssetCategoryName"].Caption = @"Tên nhóm";
                        grdLookUpFixedAssetCategoryKind.Properties.Columns["FixedAssetCategoryCode"].Caption = @"Mã nhóm";
                    }
                    grdLookUpFixedAssetCategoryKind.Properties.DisplayMember = "FixedAssetCategoryName";
                    grdLookUpFixedAssetCategoryKind.Properties.ValueMember = "FixedAssetCategoryId";
                }

            }


        }


        public IList<BudgetChapterModel> BudgetChapters { get;set; }

        public IList<BudgetKindItemModel> BudgetKindItems { get; set; }

        public IList<BudgetItemModel> BudgetItems { get; set; }

        public IList<AccountModel> Accounts
        {
            set
            {

                var origAccount = value.Where(a => a.AccountNumber.StartsWith("211") ||
                                                    a.AccountNumber.StartsWith("213")).ToList();

                grdLookUpOrgPriceAccount.Properties.DataSource = origAccount;
                grdLookUpOrgPriceAccount.Properties.ForceInitialize();
                grdLookUpOrgPriceAccount.Properties.PopulateColumns();

                var credidDepreciation = value.Where(a => a.AccountNumber.StartsWith("214")).ToList();
                grdLookUpDepreciationAccount.Properties.DataSource = credidDepreciation;
                grdLookUpDepreciationAccount.Properties.ForceInitialize();
                grdLookUpDepreciationAccount.Properties.PopulateColumns();

                grdLookUpCapitalAccount.Properties.DataSource = value;
                grdLookUpCapitalAccount.Properties.ForceInitialize();
                grdLookUpCapitalAccount.Properties.PopulateColumns();


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
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetExpense", ColumnVisible = false });


                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpOrgPriceAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpOrgPriceAccount.Properties.SortColumnIndex = column.ColumnPosition;

                        grdLookUpDepreciationAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpDepreciationAccount.Properties.SortColumnIndex = column.ColumnPosition;

                        grdLookUpCapitalAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpCapitalAccount.Properties.SortColumnIndex = column.ColumnPosition;


                    }
                    else
                    {
                        grdLookUpOrgPriceAccount.Properties.Columns[column.ColumnName].Visible = false;
                        grdLookUpDepreciationAccount.Properties.Columns[column.ColumnName].Visible = false;
                        grdLookUpCapitalAccount.Properties.Columns[column.ColumnName].Visible = false;

                    }
                }



                grdLookUpOrgPriceAccount.Properties.DisplayMember = "AccountNumber";
                grdLookUpOrgPriceAccount.Properties.ValueMember = "AccountNumber";
                grdLookUpDepreciationAccount.Properties.DisplayMember = "AccountNumber";
                grdLookUpDepreciationAccount.Properties.ValueMember = "AccountNumber";
                grdLookUpCapitalAccount.Properties.DisplayMember = "AccountNumber";
                grdLookUpCapitalAccount.Properties.ValueMember = "AccountId";




            }
        }
        #endregion

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
            {
                _fixedAssetCategoryPresenter.Display(KeyValue);
            }
            else
            {
                if (CurrentNode != null)
                {
                    txtFixedAssetCategoryCode.Text = ((FixedAssetCategoryModel)CurrentNode).FixedAssetCategoryCode;
                    grdLookUpFixedAssetCategoryKind.EditValue = ((FixedAssetCategoryModel)CurrentNode).FixedAssetCategoryId;
                }
            }
            _fixedAssetCategoriesPresenter.Display();
            _budgetChapterPresenter.Display();
            _budgetKindItemsPresenter.Display();
            _budgetItemsPresenter.Display();
            _accountPresenter.Display();
            txtFixedAssetCategoryCode.Focus();
        }

        /// <summary>
        /// Determines whether the specified p text is number.
        /// </summary>
        /// <param name="pText">The p text.</param>
        /// <returns>
        ///   <c>true</c> if the specified p text is number; otherwise, <c>false</c>.
        /// </returns>
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            if (string.IsNullOrEmpty(OrgPriceAccount))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResOrgPriceAccount"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpOrgPriceAccount.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(DepreciationAccount))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDepreciationAccount"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpDepreciationAccount.Focus();
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
            var result = _fixedAssetCategoryPresenter.Save();
            if (!String.IsNullOrEmpty(result))
                GlobalVariable.FixedAssetCategoryDetailForm = result;
            return result;
        }

        #region Event Control

        /// <summary>
        /// Handles the CheckedChanged event of the ckbActive control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ckbActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpCapitalAccount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpCapitalAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                grdLookUpCapitalAccount.EditValue = "";
        }

        /// <summary>
        /// Thêm mới nhóm TSCD
        /// </summary>
        private void grdLookUpFixedAssetCategoryKind_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frm = new FrmFixedAssetCategoryDetail();
                frm.ShowDialog();
                if (frm.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.FixedAssetCategoryDetailForm))
                    {
                        _fixedAssetCategoriesPresenter.Display();
                        grdLookUpFixedAssetCategoryKind.EditValue = GlobalVariable.FixedAssetCategoryDetailForm;
                    }
                }
            }
        }

        /// <summary>
        /// Thêm mới tài khoản
        /// </summary>
        private void grdLookUpOrgPriceAccount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmAccountDetail = new FrmAccountDetail();
            frmAccountDetail.ShowDialog();
                if (frmAccountDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.AccountIDAccountTransferForm))
                    {
                        _accountPresenter.DisplayActive();
                        grdLookUpOrgPriceAccount.Properties.DisplayMember = "AccountNumber";
                        grdLookUpOrgPriceAccount.Properties.ValueMember = "AccountId";
                        grdLookUpOrgPriceAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;

                    }
                }
            }
        }

        /// <summary>
        /// Thêm mới tài khoản
        /// </summary>
        private void grdLookUpDepreciationAccount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmAccountDetail = new FrmAccountDetail();
                frmAccountDetail.ShowDialog();
                if (frmAccountDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.AccountIDAccountTransferForm))
                    {
                        _accountPresenter.DisplayActive();
                        grdLookUpDepreciationAccount.Properties.DisplayMember = "AccountNumber";
                        grdLookUpDepreciationAccount.Properties.ValueMember = "AccountId";
                        grdLookUpDepreciationAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;

                    }
                }
            }
        }

        /// <summary>
        /// Thêm mới tài khoản
        /// </summary>
        private void grdLookUpCapitalAccount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmAccountDetail = new FrmAccountDetail();
            frmAccountDetail.ShowDialog();
                if (frmAccountDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.AccountIDAccountTransferForm))
                    {
                        _accountPresenter.DisplayActive();
                        grdLookUpCapitalAccount.Properties.DisplayMember = "AccountNumber";
                        grdLookUpCapitalAccount.Properties.ValueMember = "AccountId";
                        grdLookUpCapitalAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;

                    }
                }
            }
        }
        #endregion
    }
}
