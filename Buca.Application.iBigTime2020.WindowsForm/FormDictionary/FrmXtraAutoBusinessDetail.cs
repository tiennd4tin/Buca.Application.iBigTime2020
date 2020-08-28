/***********************************************************************
 * <copyright file="SqlServerAutoBusinessDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 27 September 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusiness;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace Buca.Application.iBigTime2020.WindowsForm.FormDictionary
{
    /// <summary>
    /// FrmXtraAutoBusinessDetail
    /// </summary>
    public partial class FrmXtraAutoBusinessDetail : FrmXtraBaseCategoryDetail, IAutoBusinessView
    {
        private readonly AutoBusinessPresenter _autoBusinessPresenter;
        //private readonly AccountsPresenter _accountsPresenter;
        //private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        //private readonly BudgetItemsPresenter _budgetItemsPresenter;
        //private readonly VoucherTypesPresenter _voucherTypesPresenter;
        //private readonly RefTypesPresenter _refTypesPresenter;

        #region IAutoBusinessView Members

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
            get { return txtAutoBusinessCode.Text; }
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
            get { return txtAutoBusinessName.Text; }
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
            get
            {
                if (ReferenceEquals(grdLockUpRefTypeId.EditValue, "")) return 0;
                return (int)grdLockUpRefTypeId.EditValue;
            }
            set
            {
                grdLockUpRefTypeId.EditValue = value;
            }
        }

        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public string BudgetSourceId { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetKindItemCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string BudgetItemCode { get; set; }

        //public string CreditAccountNumber
       // {
       //     get
       //     {
       //         if (ReferenceEquals(grdLookUpCreditAccountNumber.EditValue, "")) return null;
       //         return (string)grdLookUpCreditAccountNumber.EditValue;
       //     }
       //     set { grdLookUpCreditAccountNumber.EditValue = value; }
       // }
        
        public string BudgetSubItemCode { get; set; }
        public int? MethodDistributeId { get; set; }
        public int? CashWithDrawTypeId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return memoDescription.Text; }
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

        #region Combobox

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
                grdLookUpDebitAccountNumber.Properties.DataSource = value;
                grdLookUpCreditAccountNumber.Properties.DataSource = value;
                grdLookUpDebitAccountNumberView.PopulateColumns(value);
                grdLookUpCreditAccountNumberView.PopulateColumns(value);
                var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "AccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 },
                        new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 350 },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsDetail", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BalanceSide", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ConcomitantAccount", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsChapter", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetCategory", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetGroup", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetSource", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActivity", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCurrency", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCustomer", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsVendor", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsAccountingObject", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsInventoryItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsFixedAsset", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCapitalAllocate", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCurrency", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsAllowinputcts", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsProject", ColumnVisible = false }
                    };

                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpDebitAccountNumberView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpDebitAccountNumberView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        grdLookUpDebitAccountNumberView.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdLookUpCreditAccountNumberView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpCreditAccountNumberView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        grdLookUpCreditAccountNumberView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpDebitAccountNumberView.Columns[column.ColumnName].Visible = false;
                        grdLookUpCreditAccountNumberView.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpDebitAccountNumber.Properties.DisplayMember = "AccountCode";
                grdLookUpDebitAccountNumber.Properties.ValueMember = "AccountCode";
                grdLookUpCreditAccountNumber.Properties.DisplayMember = "AccountCode";
                grdLookUpCreditAccountNumber.Properties.ValueMember = "AccountCode";
            }
        }

        /// <summary>
        /// Sets the voucher types.
        /// </summary>
        /// <value>
        /// The voucher types.
        /// </value>
        public IList<VoucherTypeModel> VoucherTypes
        {
            set
            {
                grdLockUpVoucherTypeId.Properties.DataSource = value;
                grdLockUpVoucherTypeIdView.PopulateColumns(value);
                var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "VoucherTypeId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "VoucherTypeName", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true },
                    };
                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLockUpVoucherTypeIdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLockUpVoucherTypeIdView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        grdLockUpVoucherTypeIdView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLockUpVoucherTypeIdView.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLockUpVoucherTypeId.Properties.DisplayMember = "VoucherTypeName";
                grdLockUpVoucherTypeId.Properties.ValueMember = "VoucherTypeId";
            }
        }

        /// <summary>
        /// Sets the voucher types.
        /// </summary>
        /// <value>
        /// The voucher types.
        /// </value>
        public IList<RefTypeModel> RefTypes
        {
            set
            {
                grdLockUpRefTypeId.Properties.DataSource = value;
                grdLockUpRefTypeIdView.PopulateColumns(value);
                var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "FunctionId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "MasterTableName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DetailTableName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultDebitAccountCategoryCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultDebitAccountCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultCreditAccountCategoryCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultCreditAccountCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DefaultObjectType", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsDefaultSetting", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsPostToGL", ColumnVisible = false },
                        new XtraColumn { ColumnName = "RefTypeName", ColumnCaption = "Mã loại chứng từ", ColumnPosition = 1, ColumnVisible = true },
                    };
                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLockUpRefTypeIdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLockUpRefTypeIdView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        grdLockUpRefTypeIdView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLockUpRefTypeIdView.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLockUpRefTypeId.Properties.DisplayMember = "RefTypeName";
                grdLockUpRefTypeId.Properties.ValueMember = "RefTypeId";
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
                grdLookUpBudgetSourceCode.Properties.DataSource = value;
                grdLookUpBudgetSourceCodeView.PopulateColumns(value);
                var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150, Alignment = HorzAlignment.Center },
                        new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn vốn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 350, Alignment = HorzAlignment.Center },
                        new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Type", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Allocation", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsFund", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsExpense", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AutonomyBudgetType", ColumnVisible = false }
                    };
                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpBudgetSourceCodeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpBudgetSourceCodeView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        grdLookUpBudgetSourceCodeView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpBudgetSourceCodeView.Columns[column.ColumnName].Visible = false;
                        grdLookUpBudgetSourceCodeView.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpBudgetSourceCode.Properties.DisplayMember = "BudgetSourceCode";
                grdLookUpBudgetSourceCode.Properties.ValueMember = "BudgetSourceCode";
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
                grdLookUpBudgetItemCode.Properties.DataSource = value;
                grdLookUpBudgetItemCodeView.PopulateColumns(value);
                var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã MLNS", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center },
                        new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên MLNS", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400, Alignment = HorzAlignment.Center },
                        new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetGroupId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsExpandItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsFixedItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsNoAllocate", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsOrganItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetItemType", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsReceipt", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsChoose", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Rate", ColumnVisible = false },
                        new XtraColumn { ColumnName = "NumberOrder", ColumnVisible = false }
                    };
                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpBudgetItemCodeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpBudgetItemCodeView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        grdLookUpBudgetItemCodeView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        grdLookUpBudgetItemCodeView.Columns[column.ColumnName].Visible = false;
                        grdLookUpBudgetItemCodeView.Columns[column.ColumnName].Visible = false;
                    }
                }
                grdLookUpBudgetItemCode.Properties.DisplayMember = "BudgetItemCode";
                grdLookUpBudgetItemCode.Properties.ValueMember = "BudgetItemCode";
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraAutoBusinessDetail" /> class.
        /// </summary>
        public FrmXtraAutoBusinessDetail()
        {
            InitializeComponent();
            _autoBusinessPresenter = new AutoBusinessPresenter(this);
            //_accountsPresenter = new AccountsPresenter(this);
            //_voucherTypesPresenter = new VoucherTypesPresenter(this);
            //_refTypesPresenter = new RefTypesPresenter(this);
            //_budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            //_budgetItemsPresenter = new BudgetItemsPresenter(this);
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            //_refTypesPresenter.Display();
            //_accountsPresenter.DisplayActive();
            //_voucherTypesPresenter.DisplayActive();
            //_budgetSourcesPresenter.DisplayActive();
            //_budgetItemsPresenter.DisplayActive();
            if (KeyValue != null) { _autoBusinessPresenter.Display(KeyValue); }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {

        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(AutoBusinessCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoBusinessCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutoBusinessCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AutoBusinessName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoBusinessName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutoBusinessName.Focus();
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
            return _autoBusinessPresenter.Save();
        }


    }
}