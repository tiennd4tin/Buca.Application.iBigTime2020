using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAssetCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Buca.Application.iBigTime2020.WindowsForm.CommonControl;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using Buca.Application.iBigTime2020.Presenter.Opening;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.PUInvoice;
using Buca.Application.iBigTime2020.Model.BusinessObjects.PUInvoice;
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Department;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetChapter;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetItem;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetKindItem;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.FixedAssetCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.FixedAsset
{
    public partial class FrmFixedAssetDetail : FrmXtraBaseCategoryDetail, IFixedAssetView, IDepartmentsView,
            IAccountingObjectsView, IFixedAssetCategoriesView, IAccountsView, IBudgetKindItemsView, IBudgetItemsView, IBudgetChaptersView, IRefTypesView, IFundStructuresView

    {
        #region Variable
        List<AccountModel> _listAccounts;
        OpeningFixedAssetEntryPresenter _openingFixedAssetEntryPresenter;
        #endregion

        private readonly RefTypesPresenter _refTypesPresenter;
        private readonly FixedAssetPresenter _fixedAssetPresenter;
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategoryPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private RepositoryItemLookUpEdit _repositoryFixedAssetActivity;
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;
        private GridView _gridLookUpEditAccountView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        private IModel _model;

        public FrmFixedAssetDetail()
        {

            InitializeComponent();
            _fixedAssetPresenter = new FixedAssetPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetCategoryPresenter = new FixedAssetCategoriesPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);

            _openingFixedAssetEntryPresenter = new OpeningFixedAssetEntryPresenter(null);
            _model = new Model.Model();


        }

        #region Property

        private int _editFlag;

        public int SelectTabpage;
        private int _rowAccessoryHandle;
        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public string FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset category identifier.
        /// </summary>
        /// <value>
        /// The fixed asset category identifier.
        /// </value>
        public string FixedAssetCategoryId
        {
            get
            {
                return cboFixedAssetCategory.EditValue == null ? "" : cboFixedAssetCategory.EditValue.ToString();
            }
            set
            {
                cboFixedAssetCategory.EditValue = value;

            }
        }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public string DepartmentId
        {
            get
            {
                if (cboDepartment.EditValue == null)
                    return null;
                return cboDepartment.EditValue.ToString();
            }
            set
            {
                cboDepartment.EditValue = value;

            }
        }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public string FixedAssetCode
        {
            get
            {
                return txtFixedAssetCode.Text.Trim();
            }
            set
            {
                txtFixedAssetCode.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        /// The name of the fixed asset.
        /// </value>
        public string FixedAssetName
        {
            get
            {
                return txtFixedAssetName.Text.Trim();
            }
            set
            {
                txtFixedAssetName.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public decimal Quantity
        {
            get { return calcQuantity.Value; }
            set { calcQuantity.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the production year.
        /// </summary>
        /// <value>
        /// The production year.
        /// </value>
        public int ProductionYear
        {
            get { return (int)calcProductionYear.Value; }
            set { calcProductionYear.Value = value; }
        }

        /// <summary>
        /// Gets or sets the made in.
        /// </summary>
        /// <value>
        /// The made in.
        /// </value>
        public string MadeIn
        {
            get { return txtMadeIn.Text.Trim(); }
            set { txtMadeIn.Text = value; }
        }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>
        /// The serial number.
        /// </value>
        public string SerialNumber
        {
            get { return txtSerialNumber.Text.Trim(); }
            set { txtSerialNumber.Text = value; }
        }

        /// <summary>
        /// Gets or sets the accessories.
        /// </summary>
        /// <value>
        /// The accessories.
        /// </value>
        public string Accessories { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public string VendorId
        {
            get
            {
                if (cboVendor.EditValue == null)
                    return null;
                return cboVendor.EditValue.ToString();
            }
            set
            {
                cboVendor.EditValue = value;

            }
        }

        /// <summary>
        /// Gets or sets the duration of the guarantee.
        /// </summary>
        /// <value>
        /// The duration of the guarantee.
        /// </value>
        public string GuaranteeDuration
        {
            get { return txtGuaranteeDuration.Text.Trim(); }
            set { txtGuaranteeDuration.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is second hand.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is second hand; otherwise, <c>false</c>.
        /// </value>
        public bool IsSecondHand { get; set; }

        /// <summary>
        /// Gets or sets the last state.
        /// </summary>
        /// <value>
        /// The last state.
        /// </value>
        public int LastState { get; set; }

        /// <summary>
        /// Gets or sets the disposed date.
        /// </summary>
        /// <value>
        /// The disposed date.
        /// </value>
        public DateTime DisposedDate
        {
            get
            {
                return DateTime.Now;
            }
            set
            { }
        }

        /// <summary>
        /// Gets or sets the disposed amount.
        /// </summary>
        /// <value>
        /// The disposed amount.
        /// </value>
        public decimal DisposedAmount { get; set; }

        /// <summary>
        /// Gets or sets the disposed reason.
        /// </summary>
        /// <value>
        /// The disposed reason.
        /// </value>
        public string DisposedReason { get; set; }

        /// <summary>
        /// Gets or sets the purchased date.
        /// </summary>
        /// <value>
        /// The purchased date.
        /// </value>
        public DateTime PurchasedDate
        {
            get
            {
                return (DateTime)datePurchaseDate.EditValue;
            }
            set
            {
                datePurchaseDate.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the used date.
        /// </summary>
        /// <value>
        /// The used date.
        /// </value>
        public DateTime UsedDate
        {
            get
            {
                return (DateTime)dateUsedDate.EditValue;
            }
            set
            {
                dateUsedDate.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the remaining life time.
        /// </summary>
        /// <value>
        /// The remaining life time.
        /// </value>
        public int RemainingLifeTime
        {
            get { return (int)calcRemainLifeTime.Value > 0 ? (int)calcRemainLifeTime.Value : 0; }
            set { calcRemainLifeTime.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the depreciation date.
        /// </summary>
        /// <value>
        /// The depreciation date.
        /// </value>
        public DateTime DepreciationDate
        {
            get
            {
                return (DateTime)dateDepreciationDate.EditValue;
            }
            set
            {
                dateDepreciationDate.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the increment date.
        /// </summary>
        /// <value>
        /// The increment date.
        /// </value>
        public DateTime IncrementDate
        {
            get
            {
                return (DateTime)dateIncrementDate.EditValue;
            }
            set
            {
                dateIncrementDate.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public decimal OrgPrice
        {
            get { return calcOrigPrice.Value; }
            set { calcOrigPrice.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the depreciation value caculated.
        /// </summary>
        /// <value>
        /// The depreciation value caculated.
        /// </value>
        public decimal DepreciationValueCaculated
        {
            // get { return calcDepreciationAmount.Value; }
            // set { calcDepreciationAmount.EditValue = value; }
            get; set;
        }

        /// <summary>
        /// Gets or sets the accum depreciation amount.
        /// </summary>
        /// <value>
        /// The accum depreciation amount.
        /// </value>
        public decimal AccumDepreciationAmount
        {
            get { return calcAccumDepreciation.Value; }
            set { calcAccumDepreciation.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the life time.
        /// </summary>
        /// <value>
        /// The life time.
        /// </value>
        public int LifeTime
        {
            get { return (int)calcLifeTime.Value; }
            set { calcLifeTime.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the depreciation rate.
        /// </summary>
        /// <value>
        /// The depreciation rate.
        /// </value>
        public decimal DepreciationRate
        {
            get { return calcDepreciationRate.Value; }
            set { calcDepreciationRate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the period depreciation amount.
        /// </summary>
        /// <value>
        /// The period depreciation amount.
        /// </value>
        public decimal PeriodDepreciationAmount
        {
            get { return calcPeriodDepreciation.Value; }
            set { calcPeriodDepreciation.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the remaining amount.
        /// </summary>
        /// <value>
        /// The remaining amount.
        /// </value>
        public decimal RemainingAmount
        {
            get { return calcRemainDepreciationAmount.Value; }
            set { calcRemainDepreciationAmount.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the end year.
        /// </summary>
        /// <value>
        /// The end year.
        /// </value>
        public int EndYear { get; set; }

        /// <summary>
        /// Gets or sets the org price account.
        /// </summary>
        /// <value>
        /// The org price account.
        /// </value>
        public string OrgPriceAccount
        {
            get
            {
                return cboOrigAccount.EditValue != null ? cboOrigAccount.EditValue.ToString() : "";
            }
            set
            {
                cboOrigAccount.EditValue = value;

            }

        }

        /// <summary>
        /// Gets or sets the revenue account.
        /// </summary>
        /// <value>
        /// The revenue account.
        /// </value>
        public string RevenueAccount
        {
            get
            {
                //if (cboRevenueAccount.EditValue == null) return null;
                //return (string)cboRevenueAccount.Text;
                return null;
            }
            set
            {
                //cboRevenueAccount.EditValue = value;

            }

        }

        /// <summary>
        /// Gets or sets the capital account.
        /// </summary>
        /// <value>
        /// The capital account.f
        /// </value>
        public string CapitalAccount
        {
            get
            {
                return cboCapitalAccount.EditValue != null ? cboCapitalAccount.EditValue.ToString() : "";
            }
            set { cboCapitalAccount.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the credit depreciation account.
        /// </summary>
        /// <value>
        /// The credit depreciation account.
        /// </value>
        public string CreditDepreciationAccount
        {
            get
            {
                return cboDepreciationCreditAccount.EditValue.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    cboDepreciationCreditAccount.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the debit depreciation account.
        /// </summary>
        /// <value>
        /// The debit depreciation account.
        /// </value>
        public string DebitDepreciationAccount
        {
            get
            {
                return cboDepreciationDebitAccount.EditValue.ToString();
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    cboDepreciationDebitAccount.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fixed asset transfer.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is fixed asset transfer; otherwise, <c>false</c>.
        /// </value>
        public bool IsFixedAssetTransfer
        {
            get { return chkIsFixedAssetTransfer.Checked; }
            set { chkIsFixedAssetTransfer.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the depreciation time caculated.
        /// </summary>
        /// <value>
        /// The depreciation time caculated.
        /// </value>
        public decimal DepreciationTimeCaculated { get; set; }

        public string FundStructureId
        {
            get
            {
                return cboFundStructureItem.EditValue == null ? null : cboFundStructureItem.EditValue.ToString();
            }
            set
            {
                cboFundStructureItem.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        public string Unit
        {
            get { return txtUnit.Text; }
            set { txtUnit.Text = value; }
        }

        public int OldSource { get; set; }
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public int Source
        {
            get { return (int)cboSource.EditValue; }
            set
            {
                if (value != null && value != 0)
                {
                    OldSource = value;
                    cboSource.EditValue = value;
                }
                else
                {
                    cboSource.EditValue = 1;
                    UpdateHaoMon();
                }
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return chkActive.Checked; }
            set { chkActive.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        /// The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode
        {
            get { return cboBudgetChapter.EditValue != null ? cboBudgetChapter.EditValue.ToString() : ""; }
            set { cboBudgetChapter.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        /// The budget kind item code.
        /// </value>
        public string BudgetKindItemCode
        {
            get { return cboBudgetKindItem.EditValue != null ? cboBudgetKindItem.EditValue.ToString() : ""; }
            set { cboBudgetKindItem.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>
        /// The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode
        {
            get { return cboBudgetSubKindItem.EditValue != null ? cboBudgetSubKindItem.EditValue.ToString() : ""; }
            set { cboBudgetSubKindItem.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode
        {
            get { return cboBudgetItem.EditValue != null ? cboBudgetItem.EditValue.ToString() : ""; }
            set { cboBudgetItem.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>
        /// The budget sub item code.
        /// </value>
        public string BudgetSubItemCode
        {
            get { return cboBudgetSubItem.EditValue != null ? cboBudgetSubItem.EditValue.ToString() : ""; }
            set { cboBudgetSubItem.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the using ratio.
        /// </summary>
        /// <value>
        /// The using ratio.
        /// </value>
        public decimal UsingRatio
        {
            get { return (decimal)spUsingRatio.EditValue; }
            set { spUsingRatio.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the devaluation date.
        /// </summary>
        /// <value>
        /// The devaluation date.
        /// </value>
        public DateTime DevaluationDate
        {
            get { return dateDevaluationDate.DateTime; }
            set { dateDevaluationDate.DateTime = value; }
        }

        /// <summary>
        /// Gets or sets the devaluation life time.
        /// </summary>
        /// <value>
        /// The devaluation life time.
        /// </value>
        public decimal DevaluationLifeTime
        {
            get { return Convert.ToDecimal(calcRemainingDevaluationLifeTime.EditValue); }
            set { calcRemainingDevaluationLifeTime.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the devaluation period.
        /// </summary>
        /// <value>
        /// The devaluation period.
        /// </value>
        public int DevaluationPeriod
        {
            get { return cbbDevaluationPeriod.SelectedIndex; }
            set { cbbDevaluationPeriod.SelectedIndex = value; }
        }

        /// <summary>
        /// Gets or sets the devaluation rate.
        /// </summary>
        /// <value>
        /// The devaluation rate.
        /// </value>
        public decimal DevaluationRate
        {
            get { return (decimal)calcDevaluationRate.EditValue; }
            set { calcDevaluationRate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the devaluation debit account.
        /// </summary>
        /// <value>
        /// The devaluation debit account.
        /// </value>
        public string DevaluationDebitAccount
        {
            get { return (cboDevaluationDebitAccount.EditValue == null ? "" : cboDevaluationDebitAccount.EditValue.ToString()); }
            set { if (!string.IsNullOrEmpty(value)) cboDevaluationDebitAccount.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the devaluation credit account.
        /// </summary>
        /// <value>
        /// The devaluation credit account.
        /// </value>
        public string DevaluationCreditAccount
        {
            get { return (cboDevaluationCreditAccount.EditValue == null ? "" : cboDevaluationCreditAccount.EditValue.ToString()); }
            set { if (!string.IsNullOrEmpty(value)) cboDevaluationCreditAccount.EditValue = value; }
        }

        public decimal AccumDevaluationAmount
        {
            get { return Convert.ToDecimal(calcAccumDevaluationAmount.EditValue); }
            set { calcAccumDevaluationAmount.EditValue = value; }
        }

        public DateTime EndDevaluationDate { get; set; }
        public decimal PeriodDevaluationAmount
        {
            get { return calcPeriodDevaluationAmount.Value; }
            set { calcPeriodDevaluationAmount.EditValue = value; }
        }

        public decimal DevaluationAmount
        {
            get { return calcDevaluationAmount.Value; }
            set { calcDevaluationAmount.EditValue = value; }
        }

        #endregion

        #region Member
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
                if (value == null)
                    value = new List<AccountModel>();
                _listAccounts = value.ToList();

                var origAccount = value.Where(a => a.AccountNumber.StartsWith("211") ||
                                                    a.AccountNumber.StartsWith("213")).OrderBy(a => a.AccountNumber).ThenBy(a => a.Grade).ToList();
                //var credit = value.Where(a => a.IsParent == false).Where(a => a.AccountNumber.StartsWith("214")).OrderBy(a => a.AccountNumber).ToList();

                //var debit = value.Where(a => a.IsParent == false).Where(a => a.AccountNumber.StartsWith("154") || a.AccountNumber.StartsWith("431") ||
                //                                 a.AccountNumber.StartsWith("6") || a.AccountNumber.StartsWith("811")).OrderBy(a => a.AccountNumber).ToList();

                var debit = value;
                var credit = value;
                var capital = value.Where(a => a.AccountNumber.StartsWith("366") || a.AccountNumber.StartsWith("431")).OrderBy(a => a.AccountNumber).ToList();

                cboOrigAccount.Properties.DataSource = origAccount;
                cboOrigAccount.Properties.ForceInitialize();
                cboOrigAccount.Properties.PopulateColumns();

                cboDepreciationDebitAccount.Properties.DataSource = debit;
                cboDepreciationDebitAccount.Properties.ForceInitialize();
                cboDepreciationDebitAccount.Properties.PopulateColumns();

                cboDevaluationDebitAccount.Properties.DataSource = debit;
                cboDevaluationDebitAccount.Properties.ForceInitialize();
                cboDevaluationDebitAccount.Properties.PopulateColumns();

                cboDepreciationCreditAccount.Properties.DataSource = credit;
                cboDepreciationCreditAccount.Properties.ForceInitialize();
                cboDepreciationCreditAccount.Properties.PopulateColumns();


                cboCapitalAccount.Properties.DataSource = capital;
                cboCapitalAccount.Properties.ForceInitialize();
                cboCapitalAccount.Properties.PopulateColumns();

                cboDevaluationCreditAccount.Properties.DataSource = credit;
                cboDevaluationCreditAccount.Properties.ForceInitialize();
                cboDevaluationCreditAccount.Properties.PopulateColumns();

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
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByContract", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByExpense", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCapitalPlan", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboOrigAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboOrigAccount.Properties.SortColumnIndex = column.ColumnPosition;

                        cboDepreciationDebitAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDepreciationDebitAccount.Properties.SortColumnIndex = column.ColumnPosition;

                        cboDepreciationCreditAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDepreciationCreditAccount.Properties.SortColumnIndex = column.ColumnPosition;

                        cboDevaluationCreditAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDevaluationCreditAccount.Properties.SortColumnIndex = column.ColumnPosition;

                        cboDevaluationDebitAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDevaluationDebitAccount.Properties.SortColumnIndex = column.ColumnPosition;

                        cboCapitalAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboCapitalAccount.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                    {
                        cboOrigAccount.Properties.Columns[column.ColumnName].Visible = false;
                        cboDepreciationDebitAccount.Properties.Columns[column.ColumnName].Visible = false;
                        cboDepreciationCreditAccount.Properties.Columns[column.ColumnName].Visible = false;
                        cboDevaluationCreditAccount.Properties.Columns[column.ColumnName].Visible = false;
                        cboDevaluationDebitAccount.Properties.Columns[column.ColumnName].Visible = false;
                        cboCapitalAccount.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                cboOrigAccount.Properties.ValueMember = "AccountNumber";
                cboOrigAccount.Properties.DisplayMember = "AccountNumber";
                cboDepreciationDebitAccount.Properties.ValueMember = "AccountNumber";
                cboDepreciationDebitAccount.Properties.DisplayMember = "AccountNumber";
                cboDepreciationCreditAccount.Properties.ValueMember = "AccountNumber";
                cboDepreciationCreditAccount.Properties.DisplayMember = "AccountNumber";
                cboDevaluationCreditAccount.Properties.ValueMember = "AccountNumber";
                cboDevaluationCreditAccount.Properties.DisplayMember = "AccountNumber";
                cboDevaluationDebitAccount.Properties.ValueMember = "AccountNumber";
                cboDevaluationDebitAccount.Properties.DisplayMember = "AccountNumber";
                cboCapitalAccount.Properties.ValueMember = "AccountNumber";
                cboCapitalAccount.Properties.DisplayMember = "AccountNumber";

                //if (ActionMode == ActionModeEnum.AddNew)
                //{
                //    cboOrigAccount.EditValue = @"211";
                //}

                //grid lookup

                try
                {
                    #region init controls

                    //credit account
                    _gridLookUpEditAccountView = new GridView();
                    _gridLookUpEditAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditAccountView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditAccount.View.BestFitColumns();

                    //debit account
                    _gridLookUpEditDebitAccountView = new GridView();
                    _gridLookUpEditDebitAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditDebitAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditDebitAccountView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditDebitAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDebitAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDebitAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditDebitAccount.View.BestFitColumns();

                    #endregion

                    var debitAccounts = value;
                    _gridLookUpEditDebitAccount.DataSource = debitAccounts;
                    _gridLookUpEditDebitAccountView.PopulateColumns(debitAccounts);

                    var creditAccounts = value;
                    _gridLookUpEditAccount.DataSource = creditAccounts;
                    _gridLookUpEditAccountView.PopulateColumns(creditAccounts);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountNumber",
                        ColumnCaption = "Số tài khoản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountName",
                        ColumnCaption = "Tên tài khỏan",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false, });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false });


                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Width = column.ColumnWith;

                            _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditDebitAccountView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Visible = false;
                            _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Visible = false;
                        }
                    }
                    _gridLookUpEditAccount.DisplayMember = "AccountNumber";
                    _gridLookUpEditAccount.ValueMember = "AccountNumber";

                    _gridLookUpEditDebitAccount.DisplayMember = "AccountNumber";
                    _gridLookUpEditDebitAccount.ValueMember = "AccountNumber";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        public IList<DepartmentModel> Departments
        {
            set
            {
                cboDepartment.Properties.DataSource = value.Where(a => a.IsActive).ToList();
                cboDepartment.Properties.ForceInitialize();
                cboDepartment.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn  {ColumnName = "DepartmentId", ColumnVisible = false},
                                                new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                                                new XtraColumn
                                                {
                                                    ColumnName = "DepartmentCode",
                                                    ColumnCaption = "Mã",
                                                    ColumnPosition = 1,
                                                    ColumnVisible = true,
                                                    ColumnWith = 100
                                                },
                                                new XtraColumn
                                                {
                                                    ColumnName = "DepartmentName",
                                                    ColumnCaption = "Tên phòng ban",
                                                    ColumnPosition = 2,
                                                    ColumnVisible = true,
                                                    ColumnWith = 200
                                                },
                                                new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                                                new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                                                new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                                                new XtraColumn {ColumnName = "Grade", ColumnVisible = false}
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboDepartment.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDepartment.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboDepartment.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboDepartment.Properties.ValueMember = "DepartmentId";
                cboDepartment.Properties.DisplayMember = "DepartmentName";
            }
        }

        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <value>
        /// The accounting objects.
        /// </value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                cboVendor.Properties.DataSource = value;
                cboVendor.Properties.ForceInitialize();
                cboVendor.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "AccountingObjectCode",ColumnCaption = "Mã đối tượng", ColumnPosition = 0, ColumnVisible = true, ColumnWith = 50 },
                                                new XtraColumn { ColumnName = "AccountingObjectName", ColumnCaption = "Tên đối tượng", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 },
                                                new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "AccountingObjectCategoryId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Address", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Tel", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Fax", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Website", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BankName", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CompanyTaxCode", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "AreaCode", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactName", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactTitle", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactSex", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactMobile", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactEmail", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactOfficeTel", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactHomeTel", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ContactAddress", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsPersonal", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IdentificationNumber", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IssueDate", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IssueBy", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryScaleId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Insured", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "LabourUnionFee", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "FamilyDeductionAmount", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsCustomerVendor", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryCoefficient", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "NumberFamilyDependent", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "EmployeeTypeId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryForm", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryPercentRate", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryAmount", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsPayInsuranceOnSalary", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "InsuranceAmount", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsUnEmploymentInsurance", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "RefTypeAO", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "SalaryGrade", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CustomField1", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CustomField2", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CustomField3", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CustomField4", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CustomField5", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsPaidInsuranceForPayrollItem", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsBornLeave", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "TaxDepartmentName", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "TreasuryName", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "IsActive", ColumnVisible = false}
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboVendor.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboVendor.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboVendor.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboVendor.Properties.ValueMember = "AccountingObjectId";
                cboVendor.Properties.DisplayMember = "AccountingObjectName";
            }
        }

        /// <summary>
        /// Sets the fixed asset categories.
        /// </summary>
        /// <value>
        /// The fixed asset categories.
        /// </value>
        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set
            {
                cboFixedAssetCategory.Properties.DataSource = value.Where(a => a.IsParent == false).Where(a => a.IsActive).ToList();
                cboFixedAssetCategory.Properties.ForceInitialize();
                cboFixedAssetCategory.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                              new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "FixedAssetCategoryCode",ColumnCaption = "Mã nhóm tài sản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150  },

                                              new XtraColumn { ColumnName = "FixedAssetCategoryName", ColumnCaption = "Tên nhóm tài sản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150  },

                                              new XtraColumn { ColumnName = "Description", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "Grade", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "LifeTime", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "DepreciationRate", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "OrgPriceAccount", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "DepreciationAccount", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "CapitalAccount", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = false },

                                              new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboFixedAssetCategory.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboFixedAssetCategory.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboFixedAssetCategory.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboFixedAssetCategory.Properties.ValueMember = "FixedAssetCategoryId";
                cboFixedAssetCategory.Properties.DisplayMember = "FixedAssetCategoryName";
            }
        }

        public IList<FixedAssetDetailAccessoryModel> FixedAssetDetailAccessories
        {
            get
            {
                var fixedAssetDetailAccessories = new List<FixedAssetDetailAccessoryModel>();
                if (grvAccessoryDetail.DataSource != null && grvAccessoryDetail.RowCount > 0)
                {
                    for (int i = 0; i < grvAccessoryDetail.RowCount; i++)
                    {
                        var rowAccessory = (FixedAssetDetailAccessoryModel)grvAccessoryDetail.GetRow(i);
                        if (rowAccessory != null)
                        {
                            fixedAssetDetailAccessories.Add(new FixedAssetDetailAccessoryModel
                            {
                                FixedAssetId = rowAccessory.FixedAssetId,
                                Amount = rowAccessory.Amount,
                                Description = rowAccessory.Description,
                                Quantity = rowAccessory.Quantity,
                                SortOrder = rowAccessory.SortOrder,
                                Unit = rowAccessory.Unit
                            });
                        }
                    }
                }
                return fixedAssetDetailAccessories.ToList();
            }
            set
            {
                bindingSourceFixedAssetDetailAccessory.DataSource = value ?? new List<FixedAssetDetailAccessoryModel>();
                grvAccessoryDetail.BestFitColumns();
                grvAccessoryDetail.PopulateColumns(value);
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FixedAssetDetailAccessoryId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnCaption = "Tên, quy cách dụng cụ, phụ tùng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 286,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Unit",
                        ColumnCaption = "Đơn vị tính",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 160,
                        AllowEdit = true

                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnCaption = "Số lượng",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 160,
                        AllowEdit = true,
                        DisplayFormat = "n0",
                        ColumnType = UnboundColumnType.Decimal

                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnCaption = "Giá trị",
                        ColumnPosition = 4,
                        ColumnVisible = true,
                        ColumnWith = 160,
                        AllowEdit = true,
                        DisplayFormat = "n0",
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false}
                };
                grvAccessoryDetail.InitGridLayout(gridColumnsCollection);
                grvAccessoryDetail.SetNumericFormatControl(true);
                grvAccessoryDetail.OptionsView.ShowFooter = true;
            }
        }
        public IList<FixedAssetVoucherAttachModel> OldFixedAssetVoucherAttachs { get; set; }
        public IList<FixedAssetVoucherAttachModel> FixedAssetVoucherAttachs
        {
            get { return null; }
            set
            {
                grvVouchers.DataSource = value ?? new List<FixedAssetVoucherAttachModel>();
                grvVoucherDetail.PopulateColumns(value);
                OldFixedAssetVoucherAttachs = value;
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {
                        ColumnName = "RefNo",
                        ColumnCaption = "Số chứng từ",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        AllowEdit = true

                    },
                    new XtraColumn
                    {
                        ColumnName = "RefDate",
                        ColumnCaption = "Ngày chứng từ",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 166,
                        AllowEdit = true

                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnCaption = "Tài khoản nợ",
                        ColumnPosition = 4,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnCaption = "Tài khoản có",
                        ColumnPosition = 5,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 6,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        AllowEdit = true,
                        DisplayFormat = "n0",
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnCaption = "Quy đổi",
                        ColumnPosition = 7,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        AllowEdit = true,
                        DisplayFormat = "n0",
                        ColumnType = UnboundColumnType.Decimal
                    }
                };
                grvVoucherDetail.InitGridLayout(gridColumnsCollection);
                grvVoucherDetail.SetNumericFormatControl(true);
                grvVoucherDetail.OptionsView.ShowFooter = true;
            }
        }

        /// <summary>
        /// Gets or sets the fixed asset activities.
        /// </summary>
        /// <value>
        /// The fixed asset activities.
        /// </value>
        //public IList<FixedAssetActivityModel> FixedAssetActivities
        //{
        //    get
        //    {
        //        var fixedAssetActivities = new List<FixedAssetActivityModel>();
        //        if (grdDetailView.DataSource != null && grdDetailView.RowCount > 0)
        //        {
        //            for (var i = 0; i < grdDetailView.RowCount; i++)
        //            {
        //                var rowActivity = (FixedAssetActivityModel)grdDetailView.GetRow(i);
        //                if (rowActivity != null)
        //                {
        //                    var item = new FixedAssetActivityModel
        //                    {
        //                        FixedAssetId = rowActivity.FixedAssetId,
        //                        FixedAssetActivityId = rowActivity.FixedAssetActivityId,
        //                        DebitDepreciationAccount = rowActivity.DebitDepreciationAccount,
        //                        CreditDepreciationAccount = rowActivity.CreditDepreciationAccount,
        //                        DepreciationValueCaculated = rowActivity.DepreciationValueCaculated
        //                    };
        //                    fixedAssetActivities.Add(item);
        //                }
        //            }

        //        }
        //        return fixedAssetActivities.ToList();
        //    }
        //    set
        //    {
        //        bindingSourceFixedAssetActity.DataSource = value ?? new List<FixedAssetActivityModel>();
        //        grdDetailView.PopulateColumns(value);

        //        var gridColumnsCollection = new List<XtraColumn>
        //        {
        //            new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = false},
        //            new XtraColumn
        //            {
        //            ColumnName = "FixedAssetActivityId",
        //            ColumnCaption = "Hoạt động",
        //            ColumnPosition = 1,
        //            ColumnVisible = true,
        //            ColumnWith = 200,
        //            AllowEdit = true,
        //            RepositoryControl = _repositoryFixedAssetActivity
        //            },

        //        new XtraColumn
        //            {
        //                ColumnName = "DebitDepreciationAccount",
        //                ColumnCaption = "Tài khoản nợ",
        //                ColumnPosition = 2,
        //                ColumnVisible = true,
        //                ColumnWith = 100,
        //                AllowEdit = true,
        //                RepositoryControl = _gridLookUpEditAccount,
        //            },
        //         new XtraColumn
        //            {
        //                ColumnName = "CreditDepreciationAccount",
        //                ColumnCaption = "Tài khoản có",
        //                ColumnPosition = 3,
        //                ColumnVisible = true,
        //                ColumnWith = 100,
        //                AllowEdit = true,
        //                RepositoryControl = _gridLookUpEditAccount,
        //            },
        //         new XtraColumn
        //            {
        //                ColumnName = "DepreciationValueCaculated",
        //                ColumnCaption = "Số tiền",
        //                ColumnPosition = 4,
        //                ColumnVisible = true,
        //                ColumnType = UnboundColumnType.Decimal,
        //                ColumnWith = 100,
        //                AllowEdit = true,
        //            },

        //        };
        //        grdDetailView.InitGridLayout(gridColumnsCollection);
        //        grdDetailView.OptionsView.ShowFooter = false;
        //    }
        //}

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
                var budgetItem = value.Where(c => c.BudgetItemType == 2).Where(a => a.IsActive).ToList();
                var budgetSubItem = value.Where(c => c.BudgetItemType == 3).Where(a => a.IsActive).ToList();
                cboBudgetItem.Properties.DataSource = budgetItem;
                cboBudgetSubItem.Properties.DataSource = budgetSubItem;

                cboBudgetItem.Properties.ForceInitialize();
                cboBudgetSubItem.Properties.ForceInitialize();

                cboBudgetSubItem.Properties.PopulateColumns();
                cboBudgetItem.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                        new XtraColumn{ColumnName = "BudgetItemCode",ColumnCaption = "Mã M/TM",ColumnPosition = 1,ColumnVisible = true,ColumnWith = 100},
                        new XtraColumn{ColumnName = "BudgetItemName",ColumnCaption = "Tên M/TM",ColumnPosition = 2,ColumnVisible = true,ColumnWith = 300},
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetGroupItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetItem.Properties.SortColumnIndex = column.ColumnPosition;
                        cboBudgetItem.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboBudgetSubItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetSubItem.Properties.SortColumnIndex = column.ColumnPosition;
                        cboBudgetSubItem.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        cboBudgetItem.Properties.Columns[column.ColumnName].Visible = false;
                        cboBudgetSubItem.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                cboBudgetItem.Properties.DisplayMember = "BudgetItemCode";
                cboBudgetItem.Properties.ValueMember = "BudgetItemCode";
                cboBudgetSubItem.Properties.DisplayMember = "BudgetItemCode";
                cboBudgetSubItem.Properties.ValueMember = "BudgetItemCode";
            }
        }

        /// <summary>
        /// Sets the budget kind items.
        /// </summary>
        /// <value>
        /// The budget kind items.
        /// </value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                var budgetKindItem = value.ToList();
                var budgetSubKindItem = value.Where(c => c.IsParent == false).Where(a => a.IsActive).ToList();
                cboBudgetKindItem.Properties.DataSource = budgetKindItem;
                cboBudgetSubKindItem.Properties.DataSource = budgetSubKindItem;

                cboBudgetKindItem.Properties.ForceInitialize();
                cboBudgetSubKindItem.Properties.ForceInitialize();

                cboBudgetKindItem.Properties.PopulateColumns();
                cboBudgetSubKindItem.Properties.PopulateColumns();

                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetKindItemId", ColumnVisible = false},
                        new XtraColumn{ColumnName = "BudgetKindItemCode",ColumnCaption = "Mã Loại",ColumnPosition = 1,ColumnVisible = true,ColumnWith = 100},
                        new XtraColumn{ColumnName = "BudgetKindItemName",ColumnCaption = "Tên Loại",ColumnPosition = 2,ColumnVisible = true,ColumnWith = 300},
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetKindItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetKindItem.Properties.SortColumnIndex = column.ColumnPosition;
                        cboBudgetKindItem.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboBudgetSubKindItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetSubKindItem.Properties.SortColumnIndex = column.ColumnPosition;
                        cboBudgetSubKindItem.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        cboBudgetKindItem.Properties.Columns[column.ColumnName].Visible = false;
                        cboBudgetSubKindItem.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                cboBudgetKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                cboBudgetKindItem.Properties.ValueMember = "BudgetKindItemCode";
                cboBudgetSubKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                cboBudgetSubKindItem.Properties.ValueMember = "BudgetKindItemCode";
            }
        }

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>
        /// The budget chapters.
        /// </value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                cboBudgetChapter.Properties.DataSource = value.Where(a => a.IsActive).ToList();
                cboBudgetChapter.Properties.ForceInitialize();
                cboBudgetChapter.Properties.PopulateColumns();
                var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "BudgetChapterName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300  },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                    };

                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetChapter.Properties.SortColumnIndex = column.ColumnPosition;
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                cboBudgetChapter.Properties.DisplayMember = "BudgetChapterCode";
                cboBudgetChapter.Properties.ValueMember = "BudgetChapterCode";
            }
        }

        #endregion

        #region Form Event
        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            var sources = new List<SourceModel>() {
                new SourceModel() { Text = "Nguồn thu hoạt động quản lý dự án", Code = 1},
                new SourceModel() { Text = "Nguồn hình thành qua đầu tư XDCB", Code = 2},
                new SourceModel() { Text = "Nguồn NSNN", Code = 3 },
                new SourceModel() { Text = "Nguồn viện trợ", Code = 4},
                new SourceModel() { Text = "Nguồn phí khấu trừ, để lại", Code = 5},
                new SourceModel() { Text = "Quỹ phúc lợi", Code = 6},
                new SourceModel() { Text = "Quỹ phát triển hoạt động sự nghiệp", Code = 7},
                new SourceModel() { Text = "Nguồn biếu tặng", Code =8},
                new SourceModel() { Text = "Nguồn cấp trên cấp cho", Code = 9} };
            cboSource.Properties.DataSource = sources;
            cboSource.Properties.ForceInitialize();
            cboSource.Properties.PopulateColumns();
            var gridgridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "Text", ColumnCaption = "Tên nguồn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300  },
                        new XtraColumn { ColumnName = "Code", ColumnVisible = false }
                    };

            foreach (var column in gridgridColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    cboSource.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    cboSource.Properties.SortColumnIndex = column.ColumnPosition;
                    cboSource.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                }
                else
                {
                    cboSource.Properties.Columns[column.ColumnName].Visible = false;
                }
            }
            cboSource.Properties.DisplayMember = "Text";
            cboSource.Properties.ValueMember = "Code";
            // _fixedAssetPresenter.Display(KeyValue);
            if (KeyValue != null)
            {
                ActionMode = ActionModeEnum.None;
                // _fixedAssetPresenter.Display(KeyValue);
                btnEditable.Visible = true;
                btnEditable.Enabled = true;
                // Disable control when edit
                cboFixedAssetCategory.Enabled = false;
                cboDepartment.Enabled = false;
                cboFundStructureItem.Enabled = false;
                cboSource.Enabled = false;

                cboDevaluationCreditAccount.Enabled = false;
                cboDevaluationDebitAccount.Enabled = false;
                cboDepreciationCreditAccount.Enabled = false;
                cboDepreciationDebitAccount.Enabled = false;
                cboBudgetSubKindItem.Enabled = false;
                cboBudgetSubItem.Enabled = false;
                cboBudgetChapter.Enabled = false;

                dateDevaluationDate.Enabled = false;
                cbbDevaluationPeriod.Enabled = false;
                calcDevaluationRate.Enabled = false;
                calcRemainingDevaluationLifeTime.Enabled = false;
                cboDevaluationDebitAccount.Enabled = false;
                cboDevaluationCreditAccount.Enabled = false;
                txtFixedAssetCode.Enabled = false;
                txtFixedAssetName.Enabled = false;
                calcQuantity.Enabled = false;
                txtUnit.Enabled = false;
                txtSerialNumber.Enabled = false;
                txtGuaranteeDuration.Enabled = false;
                calcProductionYear.Enabled = false;
                txtMadeIn.Enabled = false;
                cboVendor.Enabled = false;
                txtVendorAddress.Enabled = false;
                txtDescription.Enabled = false;
                cboCapitalAccount.Enabled = false;
            }
            else
            {
                datePurchaseDate.Enabled = true;
                dateIncrementDate.Enabled = true;
                dateUsedDate.Enabled = true;
                calcOrigPrice.Enabled = true;
                spUsingRatio.Enabled = true;
                dateDepreciationDate.Enabled = true;
                calcAccumDepreciation.Enabled = true;
                cboDepreciationDebitAccount.Enabled = true;
                cboDepreciationCreditAccount.Enabled = true;
                btnSave.Enabled = true;
                cboCapitalAccount.Enabled = true;

            }
            _accountingObjectsPresenter.Display();
            _departmentsPresenter.Display();
            _fixedAssetCategoryPresenter.Display();
            _accountsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _budgetKindItemsPresenter.Display();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _refTypesPresenter.Display();
            _fundStructuresPresenter.DisplayActive(true);
            _fixedAssetPresenter.Display(KeyValue);
            if (KeyValue == null)
            {
                dateDepreciationDate.EditValue = DateTime.Now;
                dateIncrementDate.EditValue = DateTime.Now;
                datePurchaseDate.EditValue = DateTime.Now;
                dateUsedDate.EditValue = DateTime.Now;
                dateDevaluationDate.EditValue = DateTime.Now;
                //   cboDepreciationDebitAccount.EditValue = "61113";
                //   cboDevaluationDebitAccount.EditValue = "154";
            }

            // Hiển thị nút in thẻ TSCĐ
            this.btnPrintFixAsset.Visible = this.ActionMode != ActionModeEnum.AddNew;
            // Mặc định số lượng 1 khi thêm mới
            if (this.ActionMode == ActionModeEnum.AddNew)
                this.Quantity = 1;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            var endDate = (DateTime)dateIncrementDate.EditValue;
            endDate = endDate.AddYears((int)calcLifeTime.Value);
            EndYear = endDate.Year;
            var endDevaluationDate = (DateTime)dateDevaluationDate.EditValue;
            endDevaluationDate = endDevaluationDate.AddYears((int)calcLifeTime.Value);
            EndDevaluationDate = endDevaluationDate;
            FixedAssetId = _fixedAssetPresenter.save(DateTime.Parse(GlobalVariable.SystemDate));
            return this.FixedAssetId;
        }

        protected override void CloseForm()
        {
            if (DateTime.Parse(datePurchaseDate.Text) >= DateTime.Parse(GlobalVariable.SystemDate))
            {
                #region Ghi tăng TSCĐ
                var fixedAssets = _model.GetFixedAssetsByIncrement(FixedAssetId);

                // Thêm mới thì tự động ghi tăng
                if (ActionMode == ActionModeEnum.AddNew || (ActionMode == ActionModeEnum.Edit && fixedAssets.Count <= 0))
                {
                    #region Ghi tăng lần đầu khi thêm mới

                    FrmSelectVoucher frmSelectVoucher = new FrmSelectVoucher(KeyForSend, (int)cboSource.EditValue);
                    frmSelectVoucher.ShowDialog();

                    if (frmSelectVoucher.DialogResult == DialogResult.OK)
                    {
                        var valueReturn = frmSelectVoucher.ValueReturn;
                        string _creditAccount = null;
                        string _debitAccount = null;

                        FrmXtraBaseVoucherDetail frmReference;
                        List<SelectItemModel> parallels = new List<SelectItemModel>();
                        int refType = (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset;

                        // _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(_listAccounts, (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset, RefTypes.ToList());
                        //   _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(_listAccounts, (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset, RefTypes.ToList());
                        _debitAccount = this.OrgPriceAccount;
                        switch (valueReturn)
                        {
                            case 1:
                                refType = (int)BuCA.Enum.RefType.BUTransferFixedAsset;
                                break;
                            case 2:
                                refType = (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset;
                                break;
                            case 3:
                                refType = (int)BuCA.Enum.RefType.BAWithDrawFixedAsset;
                                break;
                            case 4:
                                refType = (int)BuCA.Enum.RefType.PUInvoiceFixedAsset;
                                break;
                            default:
                                refType = (int)BuCA.Enum.RefType.FAIncrementDecrement;
                                break;
                        }

                        if (Source == 1)
                        {

                            parallels.Add(new SelectItemModel("3378", "36611"));
                            parallels.Add(new SelectItemModel(null, "018"));
                            _creditAccount = "1121";
                        }
                        if (Source == 2)
                        {

                            parallels.Add(new SelectItemModel("3664", "36611"));
                            _creditAccount = "2412";
                        }
                        if (Source == 3)
                        {

                            parallels.Add(new SelectItemModel(null, "008"));
                            _creditAccount = "36611";
                        }
                        if (Source == 4)
                        {

                            if (valueReturn == 3)
                            {
                                parallels.Add(new SelectItemModel("3372", "36621"));
                                parallels.Add(new SelectItemModel(null, "004"));
                                _creditAccount = "1121";
                            }
                            if (valueReturn == 2)
                            {
                                parallels.Add(new SelectItemModel("3372", "36621"));
                                parallels.Add(new SelectItemModel(null, "004"));
                                _creditAccount = "1111";
                            }

                        }
                        if (Source == 5)
                        {
                            if (valueReturn == 3)
                            {
                                parallels.Add(new SelectItemModel("3373", "36631"));
                                parallels.Add(new SelectItemModel(null, "014"));
                                _creditAccount = "1121";
                            }
                            if (valueReturn == 2)
                            {
                                parallels.Add(new SelectItemModel("3373", "36631"));
                                parallels.Add(new SelectItemModel(null, "014"));
                                _creditAccount = "1111";
                            }
                        }
                        if (Source == 6)
                        {
                            if (valueReturn == 3)
                            {
                                parallels.Add(new SelectItemModel("43121", "43122"));
                                _creditAccount = "1121";
                            }
                            if (valueReturn == 2)
                            {
                                parallels.Add(new SelectItemModel("43121", "43122"));
                                _creditAccount = "1111";
                            }
                            if (valueReturn == 4)
                            {
                                parallels.Add(new SelectItemModel("43121", "43122"));
                                _creditAccount = "3318";
                            }
                            if (valueReturn == 7)
                            {
                                parallels.Add(new SelectItemModel("43121", "43122"));
                                _creditAccount = "2412";
                            }
                        }
                        if (Source == 7)
                        {
                            if (valueReturn == 3)
                            {
                                parallels.Add(new SelectItemModel("43141", "43142"));
                                _creditAccount = "1121";
                            }
                            if (valueReturn == 2)
                            {
                                parallels.Add(new SelectItemModel("43141", "43142"));
                                _creditAccount = "1111";
                            }
                            if (valueReturn == 4)
                            {
                                parallels.Add(new SelectItemModel("43141", "43142"));
                                _creditAccount = "3318";
                            }
                        }
                        if (Source == 8)
                        {
                            _creditAccount = "36611";
                        }
                        if (Source == 9)
                        {
                            _creditAccount = "36611";
                        }
                        var frmCAPaymentFixedAssetDetail = new FormBusiness.FixedAsset.FrmCAPaymentFixedAssetDetail(refType);
                        frmCAPaymentFixedAssetDetail.ActionMode = ActionModeVoucherEnum.AddNew;
                        frmCAPaymentFixedAssetDetail.KeyValue = null;
                        var _listCAPaymentDetailSend = new List<Model.BusinessObjects.Cash.CAPaymentDetailFixedAssetModel>();
                        var _listCAPaymentDetailParallelSend = new List<Model.BusinessObjects.Cash.CAPaymentDetailParallelModel>();
                        _listCAPaymentDetailSend.Add(new Model.BusinessObjects.Cash.CAPaymentDetailFixedAssetModel()
                        {
                            FixedAssetId = this.FixedAssetId,
                            Description = this.FixedAssetName,
                            DepartmentId = this.DepartmentId,
                            DebitAccount = _debitAccount,
                            CreditAccount = _creditAccount,
                            Amount = this.OrgPrice,
                            ExchangeAmount= this.OrgPrice,
                            OrgRefDate = System.DateTime.Now.Date,
                            OrgPrice = this.OrgPrice / calcQuantity.Value,
                            AccountingObjectId = VendorId,
                            BudgetKindItemCode = string.IsNullOrEmpty(this.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : this.BudgetKindItemCode,
                            BudgetSubKindItemCode = string.IsNullOrEmpty(this.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : this.BudgetSubKindItemCode,
                            BudgetSubItemCode = this.BudgetSubItemCode,
                            BudgetItemCode = this.BudgetItemCode,
                            BudgetSourceId = this.BudgetSourceId == null ? GlobalVariable.DefaultBudgetSourceID : BudgetSourceId,
                            BudgetChapterCode = string.IsNullOrEmpty(this.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : this.BudgetChapterCode,
                            MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                            // CashWithdrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID,
                            Quantity = calcQuantity.Value,
                            FundStructureId = this.FundStructureId
                        });
                        foreach (var item in parallels)
                        {
                      
                            _listCAPaymentDetailParallelSend.Add(new Model.BusinessObjects.Cash.CAPaymentDetailParallelModel()
                            {
                                FixedAssetId = this.FixedAssetId,
                                Description = this.FixedAssetName,
                                //DepartmentId = this.DepartmentId,
                                DebitAccount = item.Debit,
                                CreditAccount = item.Credit,
                                Amount = this.OrgPrice,
                                AmountOC= this.OrgPrice,
                                OrgRefDate = System.DateTime.Now.Date,
                                UnitPrice = this.OrgPrice / calcQuantity.Value,
                                AccountingObjectId = VendorId,
                                BudgetKindItemCode = string.IsNullOrEmpty(this.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : this.BudgetKindItemCode,
                                BudgetSubKindItemCode = string.IsNullOrEmpty(this.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : this.BudgetSubKindItemCode,
                                BudgetSubItemCode = this.BudgetSubItemCode,
                                BudgetItemCode = this.BudgetItemCode,
                                BudgetSourceId = this.BudgetSourceId == null ? GlobalVariable.DefaultBudgetSourceID : BudgetSourceId,
                                BudgetChapterCode = string.IsNullOrEmpty(this.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : this.BudgetChapterCode,
                                MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                                // CashWithdrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID,
                                Quantity = calcQuantity.Value,
                                FundStructureId = this.FundStructureId
                            });
                        }
                      
                        //        frmCAPaymentFixedAssetDetail.RefType = refType;
                        frmCAPaymentFixedAssetDetail.Parallels = parallels;
                        frmCAPaymentFixedAssetDetail._accountingObjectId = VendorId;
                        frmCAPaymentFixedAssetDetail.JournalMemo = this.FixedAssetName;
                        frmCAPaymentFixedAssetDetail._journalMemo = @"Ghi tăng TSCĐ " + FixedAssetName;
                        frmCAPaymentFixedAssetDetail.ListSendSourceDetail = _listCAPaymentDetailSend;
                        frmCAPaymentFixedAssetDetail.ListSendSourceDetailParallel = _listCAPaymentDetailParallelSend;
                        frmCAPaymentFixedAssetDetail.IsOpenFromFixedAssetDetail = true;
                        frmCAPaymentFixedAssetDetail.totalAmountDelegate = _listCAPaymentDetailSend[0].Amount;
                        frmCAPaymentFixedAssetDetail.totalAmountOCDelegate = _listCAPaymentDetailSend[0].Amount;
                        frmCAPaymentFixedAssetDetail.ShowDialog();

                        //   switch (valueReturn)
                        //    {
                        //    case 1: // Chuyển khoản kho bạc
                        //       var frmDetail = new FrmBUTransferDetailFixedAsset();
                        //        frmDetail.ActionMode = ActionModeVoucherEnum.AddNew;
                        //        frmDetail.KeyValue = null;
                        //        var _listDetailSend = new List<Model.BUTransferDetailFixedAssetlModel>();
                        //        _listDetailSend.Add(new Model.BUTransferDetailFixedAssetlModel()
                        //        {
                        //            FixedAssetId = this.FixedAssetId,
                        //            Description = this.FixedAssetName,
                        //            //DepartmentId = this.DepartmentId,
                        //            DebitAccount = _debitAccount,
                        //            CreditAccount = _creditAccount,
                        //            Amount = this.OrgPrice,
                        //            AccountingObjectId = VendorId,
                        //            OrgRefDate = System.DateTime.Now.Date,
                        //            BudgetKindItemCode = string.IsNullOrEmpty(this.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : this.BudgetKindItemCode,
                        //            BudgetSubKindItemCode = string.IsNullOrEmpty(this.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : this.BudgetSubKindItemCode,
                        //            BudgetSubItemCode = this.BudgetSubItemCode,
                        //            BudgetItemCode = this.BudgetItemCode,
                        //            BudgetSourceId = this.BudgetSourceId == null ? GlobalVariable.DefaultBudgetSourceID : BudgetSourceId,
                        //            BudgetChapterCode = string.IsNullOrEmpty(this.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : this.BudgetChapterCode,
                        //            MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                        //            CashWithdrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID
                        //        });

                        //        frmDetail.Parallels = parallels;
                        //        frmDetail._accountingObjectId = VendorId;
                        //        frmDetail._journalMemo = @"Ghi tăng TSCĐ " + FixedAssetName;
                        //        frmDetail.ListSendSourceDetail = _listDetailSend;
                        //        frmDetail.CreditAccountParallel = "008";
                        //        frmDetail.IsOpenFromFixedAssetDetail = true;
                        //        frmDetail.ShowDialog();
                        //        break;

                        //    case 2: // Tiền mặt
                        //       var frmCAPaymentFixedAssetDetail = new FormBusiness.FixedAsset.FrmCAPaymentFixedAssetDetail();
                        //        frmCAPaymentFixedAssetDetail.ActionMode = ActionModeVoucherEnum.AddNew;
                        //        frmCAPaymentFixedAssetDetail.KeyValue = null;
                        //        var _listCAPaymentDetailSend = new List<Model.BusinessObjects.Cash.CAPaymentDetailFixedAssetModel>();
                        //        _listCAPaymentDetailSend.Add(new Model.BusinessObjects.Cash.CAPaymentDetailFixedAssetModel()
                        //        {
                        //            FixedAssetId = this.FixedAssetId,
                        //            Description = this.FixedAssetName,
                        //            DepartmentId = this.DepartmentId,
                        //            DebitAccount = _debitAccount,
                        //            CreditAccount = _creditAccount,
                        //            Amount = this.OrgPrice * calcQuantity.Value,
                        //            OrgRefDate = System.DateTime.Now.Date,
                        //            OrgPrice = this.OrgPrice,
                        //            AccountingObjectId = VendorId,
                        //            BudgetKindItemCode = string.IsNullOrEmpty(this.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : this.BudgetKindItemCode,
                        //            BudgetSubKindItemCode = string.IsNullOrEmpty(this.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : this.BudgetSubKindItemCode,
                        //            BudgetSubItemCode = this.BudgetSubItemCode,
                        //            BudgetItemCode = this.BudgetItemCode,
                        //            BudgetSourceId = this.BudgetSourceId == null ? GlobalVariable.DefaultBudgetSourceID : BudgetSourceId,
                        //            BudgetChapterCode = string.IsNullOrEmpty(this.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : this.BudgetChapterCode,
                        //            MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                        //            // CashWithdrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID,
                        //            Quantity = calcQuantity.Value,
                        //            FundStructureId = this.FundStructureId
                        //        });

                        //        frmCAPaymentFixedAssetDetail.Parallels = parallels;
                        //        frmCAPaymentFixedAssetDetail._accountingObjectId = VendorId;
                        //        frmCAPaymentFixedAssetDetail.JournalMemo = this.FixedAssetName;
                        //        frmCAPaymentFixedAssetDetail._journalMemo = @"Ghi tăng TSCĐ " + FixedAssetName;
                        //        frmCAPaymentFixedAssetDetail.ListSendSourceDetail = _listCAPaymentDetailSend;
                        //        frmCAPaymentFixedAssetDetail.IsOpenFromFixedAssetDetail = true;
                        //        frmCAPaymentFixedAssetDetail.ShowDialog();
                        //                   break;

                        //    case 3: // Tiền gửi
                        //        var frmBAWithDrawFixedAssetDetail = new FormBusiness.BAWithDraw.FrmBAWithDrawFixedAssetDetail();
                        //        frmBAWithDrawFixedAssetDetail.ActionMode = ActionModeVoucherEnum.AddNew;
                        //        frmBAWithDrawFixedAssetDetail.KeyValue = null;
                        //        var _listBAWithDrawDetailSend = new List<Model.BusinessObjects.Deposit.BAWithDrawDetailFixedAssetModel>();
                        //        _listBAWithDrawDetailSend.Add(new Model.BusinessObjects.Deposit.BAWithDrawDetailFixedAssetModel()
                        //        {
                        //            FixedAssetId = this.FixedAssetId,
                        //            Description = this.FixedAssetName,
                        //            DepartmentId = this.DepartmentId,
                        //            DebitAccount = _debitAccount,
                        //            CreditAccount = _creditAccount,
                        //            Amount = this.OrgPrice,
                        //            OrgRefDate = System.DateTime.Now.Date,
                        //            OrgPrice = this.OrgPrice,
                        //            AccountingObjectId = VendorId,
                        //            BudgetKindItemCode = string.IsNullOrEmpty(this.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : this.BudgetKindItemCode,
                        //            BudgetSubKindItemCode = string.IsNullOrEmpty(this.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : this.BudgetSubKindItemCode,
                        //            BudgetSubItemCode = this.BudgetSubItemCode,
                        //            BudgetItemCode = this.BudgetItemCode,
                        //            BudgetSourceId = this.BudgetSourceId == null ? GlobalVariable.DefaultBudgetSourceID : BudgetSourceId,
                        //            BudgetChapterCode = string.IsNullOrEmpty(this.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : this.BudgetChapterCode,
                        //            MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                        //            CashWithdrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID
                        //        });
                        //        frmBAWithDrawFixedAssetDetail.Parallels = parallels;
                        //        frmBAWithDrawFixedAssetDetail._accountingObjectId = VendorId;
                        //        frmBAWithDrawFixedAssetDetail._journalMemo = @"Ghi tăng TSCĐ " + FixedAssetName;
                        //        frmBAWithDrawFixedAssetDetail.ListSendSourceDetail = _listBAWithDrawDetailSend;
                        //        frmBAWithDrawFixedAssetDetail.IsOpenFromFixedAssetDetail = true;
                        //        frmBAWithDrawFixedAssetDetail.ShowDialog();
                        //        break;

                        //    case 4: // Chưa thanh toán
                        frmReference = new FrmPUInvoiceDetailFixedAsset();
                        //        frmReference.ActionMode = ActionModeVoucherEnum.AddNew;
                        //        frmReference.KeyValue = null;
                        //        var _listPUSend = new List<PUInvoiceDetailFixedAssetModel>();
                        //        _listPUSend.Add(new PUInvoiceDetailFixedAssetModel()
                        //        {
                        //            FixedAssetId = this.FixedAssetId,
                        //            Description = this.FixedAssetName,
                        //            DepartmentId = this.DepartmentId,
                        //            DebitAccount = _debitAccount,
                        //            CreditAccount = _creditAccount,
                        //            Amount = this.OrgPrice,
                        //            OrgRefDate = System.DateTime.Now.Date,
                        //            InvDate = System.DateTime.Now.Date,
                        //            OrgPrice = this.OrgPrice,
                        //            AccountingObjectId = VendorId,
                        //            BudgetSourceId = this.BudgetSourceId == null ? GlobalVariable.DefaultBudgetSourceID : BudgetSourceId,
                        //            BudgetChapterCode = string.IsNullOrEmpty(this.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : this.BudgetChapterCode,
                        //            BudgetKindItemCode = string.IsNullOrEmpty(this.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : this.BudgetKindItemCode,
                        //            BudgetSubKindItemCode = string.IsNullOrEmpty(this.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : this.BudgetSubKindItemCode,
                        //            CashWithDrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID,
                        //            MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                        //            BudgetSubItemCode = this.BudgetSubItemCode,
                        //            BudgetItemCode = this.BudgetItemCode
                        //        });
                        //        ((FrmPUInvoiceDetailFixedAsset)frmReference).Parallels = parallels;
                        //        ((FrmPUInvoiceDetailFixedAsset)frmReference)._accountingObjectId = VendorId;
                        //        ((FrmPUInvoiceDetailFixedAsset)frmReference)._journalMemo = @"Ghi tăng TSCĐ " + FixedAssetName;
                        //        ((FrmPUInvoiceDetailFixedAsset)frmReference).ListSendSourceDetail = _listPUSend;
                        //        ((FrmPUInvoiceDetailFixedAsset)frmReference).IsOpenFromFixedAssetDetail = true;
                        //        frmReference.ShowDialog();
                        //        break;

                        //    default: // nhận bằng hiện vật
                        //      frmReference = new frmFAIncrementDecrementDetail();
                        //        frmReference.ActionMode = ActionModeVoucherEnum.AddNew;
                        //        frmReference.KeyValue = null;
                        //        var _listFASend = new List<FAIncrementDecrementDetailModel>();

                        //        if (IncrementDate > DateTime.Parse(GlobalVariable.SystemDate) && AccumDepreciationAmount > 0)

                        //        {
                        //            _listFASend.Add(new FAIncrementDecrementDetailModel()
                        //            {
                        //                FixedAssetId = this.FixedAssetId,
                        //                Description = this.FixedAssetName,
                        //                DepartmentId = this.DepartmentId,
                        //                DebitAccount = this.OrgPriceAccount,
                        //                CreditAccount = this.CreditDepreciationAccount,
                        //                Amount = this.AccumDepreciationAmount,
                        //                AccountingObjectId = VendorId,

                        //                BudgetSourceId = this.BudgetSourceId == null ? GlobalVariable.DefaultBudgetSourceID : BudgetSourceId,
                        //                BudgetChapterCode = string.IsNullOrEmpty(this.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : this.BudgetChapterCode,
                        //                BudgetKindItemCode = string.IsNullOrEmpty(this.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : this.BudgetKindItemCode,
                        //                BudgetSubKindItemCode = string.IsNullOrEmpty(this.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : this.BudgetSubKindItemCode,
                        //                CashWithDrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID,
                        //                MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                        //                BudgetSubItemCode = this.BudgetSubItemCode,
                        //                BudgetItemCode = this.BudgetItemCode
                        //            });

                        //            _listFASend.Add(new FAIncrementDecrementDetailModel()
                        //            {
                        //                FixedAssetId = this.FixedAssetId,
                        //                Description = this.FixedAssetName,
                        //                DepartmentId = this.DepartmentId,
                        //                DebitAccount = this.OrgPriceAccount,
                        //                CreditAccount = this.CapitalAccount,
                        //                Amount = this.RemainingAmount,
                        //                AccountingObjectId = VendorId,

                        //                BudgetSourceId = this.BudgetSourceId == null ? GlobalVariable.DefaultBudgetSourceID : BudgetSourceId,
                        //                BudgetChapterCode = string.IsNullOrEmpty(this.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : this.BudgetChapterCode,
                        //                BudgetKindItemCode = string.IsNullOrEmpty(this.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : this.BudgetKindItemCode,
                        //                BudgetSubKindItemCode = string.IsNullOrEmpty(this.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : this.BudgetSubKindItemCode,
                        //                CashWithDrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID,
                        //                MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                        //                BudgetSubItemCode = this.BudgetSubItemCode,
                        //                BudgetItemCode = this.BudgetItemCode
                        //            });
                        //        }
                        //        else
                        //        {
                        //            _listFASend.Add(new FAIncrementDecrementDetailModel()
                        //            {
                        //                FixedAssetId = this.FixedAssetId,
                        //                Description = this.FixedAssetName,
                        //                DepartmentId = this.DepartmentId,
                        //                DebitAccount = _debitAccount,
                        //                CreditAccount = _creditAccount,
                        //                Amount = this.OrgPrice,
                        //                AccountingObjectId = VendorId,

                        //                BudgetSourceId = this.BudgetSourceId == null ? GlobalVariable.DefaultBudgetSourceID : BudgetSourceId,
                        //                BudgetChapterCode = string.IsNullOrEmpty(this.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : this.BudgetChapterCode,
                        //                BudgetKindItemCode = string.IsNullOrEmpty(this.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : this.BudgetKindItemCode,
                        //                BudgetSubKindItemCode = string.IsNullOrEmpty(this.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : this.BudgetSubKindItemCode,
                        //                CashWithDrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID,
                        //                MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                        //                BudgetSubItemCode = this.BudgetSubItemCode,
                        //                BudgetItemCode = this.BudgetItemCode
                        //            });
                        //        }

                        //                    ((frmFAIncrementDecrementDetail)frmReference)._journalMemo = @"Ghi tăng TSCĐ " + FixedAssetName;
                        //        ((frmFAIncrementDecrementDetail)frmReference).ListSendSourceDetail = _listFASend;
                        //        ((frmFAIncrementDecrementDetail)frmReference).IsOpenFromFixedAssetDetail = true;
                        //        frmReference.ShowDialog();
                        //        break;
                        //}
                    }
                    #endregion

                }
            }
            #endregion
            else
            {
                #region Đầu kì TSCĐ
                // Nhỏ hơn ngày bắt đầu hạch toán thì lưu xuống bảng số dư dầu kì tài sản
                // Thêm mới thì lưu đầu kì (tạm thời ko tính sửa)
                if (ActionMode == ActionModeEnum.AddNew || ActionMode == ActionModeEnum.Edit)
                {

                    //.Kiểm tra KH/HM lũy kế  có bằng nguyên giá hoặc KH/HM lũy kế bằng 0 ==> lưu 1 dòng

                    //if (this.calcTotalDepreciation.Value == 0)
                    //{
                    //    var entity = new OpeningFixedAssetEntryModel()
                    //    {
                    //        RefId = Guid.NewGuid().ToString(),
                    //        RefType = (int)BuCA.Enum.RefType.OpeningFixedAsset,
                    //        PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1),
                    //        CurrencyCode = GlobalVariable.MainCurrencyId,
                    //        ExchangeRate = 1,
                    //        FixedAssetId = this.FixedAssetId,
                    //        DepartmentId = this.DepartmentId,
                    //        BudgetChapterCode = this.BudgetChapterCode,
                    //        OrgPriceAccount = this.OrgPriceAccount,
                    //        OrgPriceDebitAmountOC = this.OrgPrice,
                    //        DepreciationAccount = this.CapitalAccount,
                    //        DepreciationCreditAmountOC = 0,
                    //        CapitalAccount = this.CapitalAccount,
                    //        CapitalCreditAmountOC = Convert.ToDecimal(this.calcRemainAmount.EditValue),
                    //        SortOrder = 0,
                    //        DevaluationCreditAmount = AccumDevaluationAmount,
                    //        FixedAssetCode = this.FixedAssetCode
                    //    };
                    //    entity.OrgPriceDebitAmount = entity.OrgPriceDebitAmountOC * entity.ExchangeRate;
                    //    entity.DepreciationCreditAmount = entity.DepreciationCreditAmountOC * entity.ExchangeRate;
                    //    entity.CapitalCreditAmount = entity.CapitalCreditAmountOC * entity.ExchangeRate;
                    //    var _result = _openingFixedAssetEntryPresenter.Save(entity);
                    //}
                    //else if (this.calcTotalDepreciation.Value == this.calcOrigPrice.Value)
                    //{
                    //    var entity = new OpeningFixedAssetEntryModel()
                    //    {
                    //        RefId = Guid.NewGuid().ToString(),
                    //        RefType = (int)BuCA.Enum.RefType.OpeningFixedAsset,
                    //        PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1),
                    //        CurrencyCode = GlobalVariable.MainCurrencyId,
                    //        ExchangeRate = 1,
                    //        FixedAssetId = this.FixedAssetId,
                    //        DepartmentId = this.DepartmentId,
                    //        BudgetChapterCode = this.BudgetChapterCode,
                    //        OrgPriceAccount = this.OrgPriceAccount,
                    //        OrgPriceDebitAmountOC = this.OrgPrice,
                    //        DepreciationAccount = this.CreditDepreciationAccount,
                    //        DepreciationCreditAmountOC = this.AccumDepreciationAmount,
                    //        CapitalAccount = this.CapitalAccount,
                    //        CapitalCreditAmountOC = Convert.ToDecimal(this.calcRemainAmount.EditValue),
                    //        SortOrder = 0,
                    //        DevaluationCreditAmount = AccumDevaluationAmount,
                    //        FixedAssetCode = this.FixedAssetCode
                    //    };
                    //    entity.OrgPriceDebitAmount = entity.OrgPriceDebitAmountOC * entity.ExchangeRate;
                    //    entity.DepreciationCreditAmount = entity.DepreciationCreditAmountOC * entity.ExchangeRate;
                    //    entity.CapitalCreditAmount = entity.CapitalCreditAmountOC * entity.ExchangeRate;
                    //    var _result = _openingFixedAssetEntryPresenter.Save(entity);
                    //}

                    //.Trường hợp KH/HM lũy kế khác nguyên giá ==> lưu 3 dòng
                    //else
                    //{
                        //IList<OpeningFixedAssetEntryModel> entities = new List<OpeningFixedAssetEntryModel>();
                        //var entityRow1 = new OpeningFixedAssetEntryModel()
                        //{
                        //    RefId = Guid.NewGuid().ToString(),
                        //    RefType = (int)BuCA.Enum.RefType.OpeningFixedAsset,
                        //    PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1),
                        //    CurrencyCode = GlobalVariable.MainCurrencyId,
                        //    ExchangeRate = 1,
                        //    FixedAssetId = this.FixedAssetId,
                        //    DepartmentId = this.DepartmentId,
                        //    BudgetChapterCode = this.BudgetChapterCode,
                        //    OrgPriceAccount = this.OrgPriceAccount,
                        //    OrgPriceDebitAmountOC = this.OrgPrice,
                        //    DepreciationAccount = "",
                        //    //DepreciationAccount = this.CreditDepreciationAccount,
                        //    DepreciationCreditAmountOC = this.AccumDepreciationAmount,
                        //    CapitalAccount = this.CapitalAccount,
                        //    CapitalCreditAmountOC = Convert.ToDecimal(this.calcRemainAmount.EditValue),
                        //    SortOrder = 0,
                        //    //DevaluationCreditAmount = AccumDevaluationAmount,
                        //    FixedAssetCode = this.FixedAssetCode
                        //};
                        //entityRow1.OrgPriceDebitAmount = entityRow1.OrgPriceDebitAmountOC * entityRow1.ExchangeRate - this.calcTotalDepreciation.Value;
                        //entityRow1.DepreciationCreditAmount = entityRow1.DepreciationCreditAmountOC * entityRow1.ExchangeRate;
                        //entityRow1.CapitalCreditAmount = entityRow1.CapitalCreditAmountOC * entityRow1.ExchangeRate;
                        //entityRow1.OrgPriceDebitAmountOC = entityRow1.CapitalCreditAmountOC;


                        //entities.Add(entityRow1);
                        //var entityRow2 = new OpeningFixedAssetEntryModel()
                        //{
                        //    RefId = Guid.NewGuid().ToString(),
                        //    RefType = (int)BuCA.Enum.RefType.OpeningFixedAsset,
                        //    PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1),
                        //    CurrencyCode = GlobalVariable.MainCurrencyId,
                        //    ExchangeRate = 1,
                        //    FixedAssetId = this.FixedAssetId,
                        //    DepartmentId = this.DepartmentId,
                        //    BudgetChapterCode = this.BudgetChapterCode,
                        //    OrgPriceAccount = this.OrgPriceAccount,
                        //    OrgPriceDebitAmountOC = this.OrgPrice,
                        //    //DepreciationAccount = this.DevaluationCreditAccount,
                        //    DepreciationAccount = "",
                        //    DepreciationCreditAmountOC = this.AccumDepreciationAmount,
                        //    CapitalAccount = this.CreditDepreciationAccount,
                        //    CapitalCreditAmountOC = Convert.ToDecimal(this.calcAccumDepreciation.EditValue),
                        //    SortOrder = 0,
                        //    DevaluationCreditAmount = AccumDevaluationAmount,
                        //    FixedAssetCode = this.FixedAssetCode
                        //};
                        //entityRow2.OrgPriceDebitAmount = this.calcTotalDepreciation.Value;
                        //entityRow2.DepreciationCreditAmount = entityRow2.DepreciationCreditAmountOC * entityRow2.ExchangeRate;
                        //entityRow2.CapitalCreditAmount = entityRow2.CapitalCreditAmountOC * entityRow2.ExchangeRate;
                        //entityRow2.OrgPriceDebitAmountOC = entityRow2.OrgPriceDebitAmount;

                        //entities.Add(entityRow2);
                        IList<OpeningFixedAssetEntryModel> entities = new List<OpeningFixedAssetEntryModel>();
                        var entityRow1 = new OpeningFixedAssetEntryModel()
                        {
                            RefId = Guid.NewGuid().ToString(),
                            RefType = (int)BuCA.Enum.RefType.OpeningFixedAsset,
                            PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1),
                            CurrencyCode = GlobalVariable.MainCurrencyId,
                            ExchangeRate = 1,
                            FixedAssetId = this.FixedAssetId,
                            DepartmentId = this.DepartmentId,
                            BudgetChapterCode = this.BudgetChapterCode,
                            OrgPriceAccount = this.OrgPriceAccount,
                            OrgPriceDebitAmountOC = this.OrgPrice,
                            DepreciationAccount = this.CapitalAccount,
                            //DepreciationAccount = this.CreditDepreciationAccount,
                            //DepreciationCreditAmountOC = this.AccumDepreciationAmount,
                            CapitalAccount = this.CapitalAccount,
                            CapitalCreditAmountOC = Convert.ToDecimal(this.calcRemainAmount.EditValue),
                            SortOrder = 0,
                            //DevaluationCreditAmount = AccumDevaluationAmount,
                            FixedAssetCode = this.FixedAssetCode
                        };
                        entityRow1.OrgPriceDebitAmount = entityRow1.OrgPriceDebitAmountOC * entityRow1.ExchangeRate - this.calcTotalDepreciation.Value;
                        entityRow1.DepreciationCreditAmount = entityRow1.DepreciationCreditAmountOC * entityRow1.ExchangeRate;
                        entityRow1.CapitalCreditAmount = entityRow1.CapitalCreditAmountOC * entityRow1.ExchangeRate;
                        entityRow1.OrgPriceDebitAmountOC = entityRow1.CapitalCreditAmountOC;


                        entities.Add(entityRow1);
                        var entityRow2 = new OpeningFixedAssetEntryModel()
                        {
                            RefId = Guid.NewGuid().ToString(),
                            RefType = (int)BuCA.Enum.RefType.OpeningFixedAsset,
                            PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1),
                            CurrencyCode = GlobalVariable.MainCurrencyId,
                            ExchangeRate = 1,
                            FixedAssetId = this.FixedAssetId,
                            DepartmentId = this.DepartmentId,
                            BudgetChapterCode = this.BudgetChapterCode,
                            OrgPriceAccount = this.OrgPriceAccount,
                            OrgPriceDebitAmountOC = this.OrgPrice,
                            //DepreciationAccount = this.DevaluationCreditAccount,
                            DepreciationAccount = this.CreditDepreciationAccount,
                            DepreciationCreditAmountOC = this.AccumDepreciationAmount,
                            CapitalAccount = this.CreditDepreciationAccount,
                            CapitalCreditAmountOC = Convert.ToDecimal(this.AccumDepreciationAmount),
                            SortOrder = 0,
                            DevaluationCreditAmount = AccumDevaluationAmount,
                            FixedAssetCode = this.FixedAssetCode
                        };
                        entityRow2.OrgPriceDebitAmount = this.calcTotalDepreciation.Value;
                        entityRow2.DepreciationCreditAmount = entityRow2.DepreciationCreditAmountOC * entityRow2.ExchangeRate;
                        entityRow2.CapitalCreditAmount = entityRow2.CapitalCreditAmountOC * entityRow2.ExchangeRate;
                        entityRow2.OrgPriceDebitAmountOC = entityRow2.OrgPriceDebitAmount;

                        entities.Add(entityRow2);
                        _openingFixedAssetEntryPresenter.Save(entities);
                    }

                //}

                #endregion
            }
            Close();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(FixedAssetCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetCode"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFixedAssetCode.Focus();
                return false;
            }
            if (cboSource.EditValue == null || cboSource.EditValue.ToString() == "" || (int)cboSource.EditValue == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn nguồn hình thành TS",
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFixedAssetCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(FixedAssetName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetName"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFixedAssetName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(FixedAssetCategoryId))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetCategoryId"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboFixedAssetCategory.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(DepartmentId))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetDepartmentId"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboDepartment.Focus();
                return false;
            }
            if (Quantity <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetQuantity"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                calcQuantity.Focus();
                return false;
            }
            if (Source < 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetSource"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboSource.Focus();
                return false;
            }
            if (OrgPrice <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetOrgPrice"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabFixedAsset.SelectedTabPage = tabDepreciation;
                calcOrigPrice.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(OrgPriceAccount))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetOrgPriceAccount"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabFixedAsset.SelectedTabPage = tabDepreciation;
                cboOrigAccount.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(CapitalAccount))
            {
                XtraMessageBox.Show("Chưa chọn tài khoản giá trị còn lại",
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCapitalAccount.Focus();
                return false;
            }
            //var fixedassetactivities = FixedAssetActivities;
            //if (fixedassetactivities.Count == 0)
            //{
            //    XtraMessageBox.Show("Chưa nhập chi tiết hoạt động!", "Thông báo lỗi",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //foreach (var fixactivity in fixedassetactivities)
            //{
            //    if (fixactivity.CreditDepreciationAccount == null || fixactivity.DebitDepreciationAccount == null)
            //    {
            //        XtraMessageBox.Show("Bạn chưa nhập tài khoản khấu hao",
            //            "Thông báo lỗi", MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);
            //        return false;
            //    }
            //}
            return true;
        }

        /// <summary>
        /// Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {
            var fixedAssetActivities = typeof(FixedAssetActivity).ToList();
            _repositoryFixedAssetActivity = new RepositoryItemLookUpEdit
            {
                DataSource = fixedAssetActivities,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryFixedAssetActivity.PopulateColumns();
            _repositoryFixedAssetActivity.Columns["Key"].Visible = false;
            ActiveControl = txtFixedAssetCode;
        }

        /// <summary>
        /// Handles the Load event of the FrmFixedAssetDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmFixedAssetDetail_Load(object sender, EventArgs e)
        {
            InitRepositoryControlData();
            txtFixedAssetCode.Focus();
            if (ActionMode == ActionModeEnum.AddNew)
            {
                cboBudgetChapter.EditValue = GlobalVariable.DefaultBudgetChapterCode;
                cboBudgetSubKindItem.EditValue = GlobalVariable.DefaultBudgetSubKindItemCode;
            }
            checkBox1.Checked = false;
            if (SelectTabpage==1)
                tabFixedAsset.SelectedTabPage = tabDepreciation;
        }

        #endregion

        #region Control Event
        /// <summary>
        /// Handles the EditValueChanged event of the cboFixedAssetCategory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboFixedAssetCategory_EditValueChanged(object sender, EventArgs e)
        {
            //check fixedasset exits
            if (ActionMode == ActionModeEnum.Edit)
            {
                var fixedAssetCategoryOld = _model.GetFixedAssetById(FixedAssetId).FixedAssetCategoryId;
                var fixAssetLedger = _model.GetFixedAssetLedgerById(FixedAssetId).Where(x => x.RefType != 603).ToList();
                if (fixAssetLedger.Count() > 0)
                {
                    if (cboFixedAssetCategory.EditValue.ToString() != fixedAssetCategoryOld)
                    {
                        DialogResult dlResult = XtraMessageBox.Show("  Tài sản đã phát sinh chứng từ !Bạn không thể thay đổi danh mục loại tài sản!", "Thông báo",
                                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cboFixedAssetCategory.EditValue = fixedAssetCategoryOld;
                    return;
                }
            }



            if (cboFixedAssetCategory.EditValue == null)
                return;
            var lifeTime = Convert.ToInt16(cboFixedAssetCategory.GetColumnValue("LifeTime"));
            var depreciationRate = Convert.ToDecimal(cboFixedAssetCategory.GetColumnValue("DepreciationRate"));
            var usingLifeTime = DateTime.Parse(GlobalVariable.SystemDate).Year - dateDepreciationDate.DateTime.Year <= 0
                ? 0
                : DateTime.Parse(GlobalVariable.SystemDate).Year - dateDepreciationDate.DateTime.Year;
            // Auto change value HM
            calcLifeTime.EditValue = lifeTime;
            calcDepreciationRate.EditValue = Convert.ToDecimal(cboFixedAssetCategory.GetColumnValue("DepreciationRate"));
            cboOrigAccount.EditValue = cboFixedAssetCategory.GetColumnValue("OrgPriceAccount");
            //  cboDepreciationDebitAccount.EditValue = cboFixedAssetCategory.GetColumnValue("OrgPriceAccount");
            calcRemainLifeTime.Text = lifeTime - usingLifeTime > 0 ? (lifeTime - usingLifeTime).ToString() : 0.ToString();
            DepreciationAccount = cboFixedAssetCategory.GetColumnValue("DepreciationAccount") != null ? cboFixedAssetCategory.GetColumnValue("DepreciationAccount").ToString() : "2141";
            //  cboDevaluationCreditAccount.EditValue = cboFixedAssetCategory.GetColumnValue("DepreciationAccount") != null ? cboFixedAssetCategory.GetColumnValue("DepreciationAccount") : "2141";
            // Auto change value KH
            cbbDevaluationPeriod.SelectedIndex = 0;
            calcDevaluationRate.EditValue = depreciationRate;
            cboDepreciationCreditAccount.EditValue = DepreciationAccount;
            calcRemainingDevaluationLifeTime.EditValue = lifeTime;
        }
        public string DepreciationAccount { get; set; }
        /// <summary>
        /// Handles the EditValueChanged event of the calcOrigPrice control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void calcOrigPrice_EditValueChanged(object sender, EventArgs e)
        {
            var originalPrice = (decimal)calcOrigPrice.EditValue;
            decimal lifeTime = decimal.Parse(calcDepreciationRate.EditValue.ToString()) / 100;

            var ratio = (decimal)spUsingRatio.EditValue;
            calcPeriodDepreciationValue.EditValue = Math.Round(originalPrice * (100 - ratio) / 100, 0);
            calcDevaluationAmount.EditValue = originalPrice - (decimal)calcPeriodDepreciationValue.EditValue;
            var periodDepreciationValue = (decimal)calcPeriodDepreciationValue.EditValue * lifeTime;
            var times = DateTime.Parse(GlobalVariable.SystemDate).Year - dateDepreciationDate.DateTime.Year <= 0 ? 0 : DateTime.Parse(GlobalVariable.SystemDate).Year - dateDepreciationDate.DateTime.Year;
            if (ActionMode != ActionModeEnum.None)
            {
                calcAccumDepreciation.EditValue = (decimal)calcPeriodDepreciationValue.EditValue < (periodDepreciationValue * times) ? (decimal)calcPeriodDepreciationValue.EditValue : (periodDepreciationValue * times);
            }
            calcRemainDepreciationAmount.EditValue = (decimal)calcPeriodDepreciationValue.EditValue - (decimal)calcAccumDepreciation.EditValue;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the spUsingRatio control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void spUsingRatio_EditValueChanged(object sender, EventArgs e)
        {
            var ratio = (decimal)spUsingRatio.EditValue;
            var originalPrice = (decimal)calcOrigPrice.EditValue;
            calcPeriodDepreciationValue.EditValue = Math.Round(originalPrice * (100 - ratio) / 100, 0);
            if (ActionMode != ActionModeEnum.None)
            {
                if (ratio != 0)
                {
                    dateDevaluationDate.Enabled = true;
                    cbbDevaluationPeriod.Enabled = true;
                    calcDevaluationRate.Enabled = true;
                    calcRemainingDevaluationLifeTime.Enabled = true;
                    //calcAccumDevaluationAmount.Enabled = true;
                    cboDevaluationDebitAccount.Enabled = true;
                    cboDevaluationCreditAccount.Enabled = true;
                }
                else
                {
                    dateDevaluationDate.Enabled = false;
                    cbbDevaluationPeriod.Enabled = false;
                    calcDevaluationRate.Enabled = false;
                    calcRemainingDevaluationLifeTime.Enabled = false;
                    calcAccumDevaluationAmount.Enabled = false;
                    cboDevaluationDebitAccount.Enabled = false;
                    cboDevaluationCreditAccount.Enabled = false;
                }
            }
            calcDevaluationAmount.EditValue = originalPrice - (decimal)calcPeriodDepreciationValue.EditValue;
            decimal lifeTime = decimal.Parse(calcDepreciationRate.EditValue.ToString()) / 100;
            calcPeriodDepreciationValue.EditValue = Math.Round(originalPrice * (100 - ratio) / 100, 0);
            calcDevaluationAmount.EditValue = originalPrice - (decimal)calcPeriodDepreciationValue.EditValue;
            var periodDepreciationValue = (decimal)calcPeriodDepreciationValue.EditValue * lifeTime;
            var times = DateTime.Parse(GlobalVariable.SystemDate).Year - dateDepreciationDate.DateTime.Year <= 0 ? 0 : DateTime.Parse(GlobalVariable.SystemDate).Year - dateDepreciationDate.DateTime.Year;
            if (ActionMode != ActionModeEnum.None)
            {
                calcAccumDepreciation.EditValue = (decimal)calcPeriodDepreciationValue.EditValue < (periodDepreciationValue * times) ? (decimal)calcPeriodDepreciationValue.EditValue : (periodDepreciationValue * times);
            }
            calcRemainDepreciationAmount.EditValue = (decimal)calcPeriodDepreciationValue.EditValue - (decimal)calcAccumDepreciation.EditValue;
        }

        private void calcPeriodDepreciationValue_EditValueChanged(object sender, EventArgs e)
        {
            calcPeriodDepreciation.EditValue = (decimal)calcPeriodDepreciationValue.EditValue * decimal.Parse(calcDepreciationRate.EditValue.ToString()) / 100;
            if (ActionMode != ActionModeEnum.None)

            {
                //calcAccumDepreciation.EditValue = (decimal)calcPeriodDepreciationValue.EditValue < ((DateTime.Now.Year - dateDepreciationDate.DateTime.Year) * (decimal)calcPeriodDepreciation.EditValue) ? (decimal)calcPeriodDepreciationValue.EditValue : (DateTime.Now.Year - dateDepreciationDate.DateTime.Year) * (decimal)calcPeriodDepreciation.EditValue;
                calcAccumDepreciation.EditValue = (decimal)calcPeriodDepreciationValue.EditValue < ((dateIncrementDate.DateTime.Year - dateDepreciationDate.DateTime.Year) * (decimal)calcPeriodDepreciation.EditValue) ? (decimal)calcPeriodDepreciationValue.EditValue : ((dateIncrementDate.DateTime.Year - dateDepreciationDate.DateTime.Year) * (decimal)calcPeriodDepreciation.EditValue > 0 ? (dateIncrementDate.DateTime.Year - dateDepreciationDate.DateTime.Year) * (decimal)calcPeriodDepreciation.EditValue : 0);
            }
            calcRemainDepreciationAmount.EditValue = (decimal)calcPeriodDepreciationValue.EditValue - (decimal)calcAccumDepreciation.EditValue;

        }

        private void dateDepreciationDate_EditValueChanged(object sender, EventArgs e)
        {
            var periodDepreciationValue = (decimal)calcPeriodDepreciationValue.EditValue * decimal.Parse(calcDepreciationRate.EditValue.ToString()) / 100;
            var times = DateTime.Parse(GlobalVariable.SystemDate).Year - dateDepreciationDate.DateTime.Year <= 0 ? 0 : DateTime.Parse(GlobalVariable.SystemDate).Year - dateDepreciationDate.DateTime.Year;
            if (ActionMode != ActionModeEnum.None)
            {
                calcAccumDepreciation.EditValue = (decimal)calcPeriodDepreciationValue.EditValue < (periodDepreciationValue * times) ? (decimal)calcPeriodDepreciationValue.EditValue : (periodDepreciationValue * times);
            }
            calcRemainDepreciationAmount.EditValue = (decimal)calcPeriodDepreciationValue.EditValue - (decimal)calcAccumDepreciation.EditValue;
            var remainLifeTime = Convert.ToInt16(calcLifeTime.Value);
            calcRemainLifeTime.EditValue = remainLifeTime - times > 0 ? remainLifeTime - times : 0;
        }

        private void calcDepreciationRate_EditValueChanged(object sender, EventArgs e)
        {
            calcPeriodDepreciation.EditValue = (decimal)calcPeriodDepreciationValue.EditValue * decimal.Parse(calcDepreciationRate.EditValue.ToString()) / 100;
            var years = DateTime.Parse(GlobalVariable.SystemDate).Year - dateDepreciationDate.DateTime.Year <= 0
                ? 0
                : DateTime.Parse(GlobalVariable.SystemDate).Year - dateDepreciationDate.DateTime.Year;
            if (ActionMode != ActionModeEnum.None)
            {
                calcAccumDepreciation.EditValue = (decimal)calcPeriodDepreciationValue.EditValue < (years * (decimal)calcPeriodDepreciation.EditValue) ? (decimal)calcPeriodDepreciationValue.EditValue : (years * (decimal)calcPeriodDepreciation.EditValue);
            }
        }

        private void calcAccumDepreciation_EditValueChanged(object sender, EventArgs e)
        {
            calcRemainDepreciationAmount.EditValue = (decimal)calcPeriodDepreciationValue.EditValue - (decimal)calcAccumDepreciation.EditValue;
            calcTotalDepreciation.EditValue = (decimal)calcAccumDepreciation.EditValue + (decimal)calcAccumDevaluationAmount.EditValue;
        }

        private void calcDevaluationAmount_EditValueChanged(object sender, EventArgs e)
        {
            var devaluationAmount = (decimal)calcDevaluationAmount.EditValue;
            //var years = DateTime.Now.Year - dateDevaluationDate.DateTime.Year;
            var years = DateTime.Parse(GlobalVariable.SystemDate).Year - dateDevaluationDate.DateTime.Year <= 0 ? 0 : DateTime.Parse(GlobalVariable.SystemDate).Year - dateDevaluationDate.DateTime.Year;
            var months = years + DateTime.Parse(GlobalVariable.SystemDate).Month - dateDevaluationDate.DateTime.Month < 0 ? 0 : years + DateTime.Parse(GlobalVariable.SystemDate).Month - dateDevaluationDate.DateTime.Month;
            calcPeriodDevaluationAmount.EditValue = devaluationAmount * (decimal)calcDevaluationRate.EditValue / 100;
            if (ActionMode != ActionModeEnum.None)
            {
                if (cbbDevaluationPeriod.SelectedIndex == 0)
                {
                    calcAccumDevaluationAmount.EditValue = (decimal)calcDevaluationAmount.EditValue < (years * (decimal)calcPeriodDevaluationAmount.EditValue) ? (decimal)calcDevaluationAmount.EditValue : (years * (decimal)calcPeriodDevaluationAmount.EditValue);
                }
                else if (cbbDevaluationPeriod.SelectedIndex == 1)
                {
                    calcAccumDevaluationAmount.EditValue = (decimal)calcDevaluationAmount.EditValue < (Math.Floor((decimal)months / 4) * (decimal)calcPeriodDevaluationAmount.EditValue) ? (decimal)calcDevaluationAmount.EditValue : (Math.Floor((decimal)months / 4) * (decimal)calcPeriodDevaluationAmount.EditValue);
                }
                else
                    calcAccumDevaluationAmount.EditValue = (decimal)calcDevaluationAmount.EditValue < (months * (decimal)calcPeriodDevaluationAmount.EditValue) ? (decimal)calcDevaluationAmount.EditValue : (months * (decimal)calcPeriodDevaluationAmount.EditValue);
            }
            calcRemainingDevaluationAmount.EditValue = devaluationAmount - (decimal)calcAccumDevaluationAmount.EditValue;

        }

        private void dateDevaluationDate_EditValueChanged(object sender, EventArgs e)
        {
            var devaluationAmount = (decimal)calcDevaluationAmount.EditValue;
            calcPeriodDevaluationAmount.EditValue = (decimal)calcDevaluationRate.EditValue * devaluationAmount / 100;
            var years = DateTime.Parse(GlobalVariable.SystemDate).Year - dateDevaluationDate.DateTime.Year <= 0 ? 0 : DateTime.Parse(GlobalVariable.SystemDate).Year - dateDevaluationDate.DateTime.Year;
            var months = years * 12 + DateTime.Parse(GlobalVariable.SystemDate).Month - dateDevaluationDate.DateTime.Month <= 0 ? 0 : years * 12 + DateTime.Parse(GlobalVariable.SystemDate).Month - dateDevaluationDate.DateTime.Month;
            if (ActionMode != ActionModeEnum.None)
            {
                if (cbbDevaluationPeriod.SelectedIndex == 0)
                {
                    calcAccumDevaluationAmount.EditValue = (decimal)calcDevaluationAmount.EditValue < ((decimal)calcPeriodDevaluationAmount.EditValue * years) ? (decimal)calcDevaluationAmount.EditValue : ((decimal)calcPeriodDevaluationAmount.EditValue * years);
                }
                else if (cbbDevaluationPeriod.SelectedIndex == 1)
                {
                    calcAccumDevaluationAmount.EditValue = (decimal)calcDevaluationAmount.EditValue < (Math.Round(devaluationAmount * Math.Floor((decimal)months / 4)) * (decimal)calcDevaluationRate.EditValue / 100) ? (decimal)calcDevaluationAmount.EditValue : (Math.Round(devaluationAmount * Math.Floor((decimal)months / 4)) * (decimal)calcDevaluationRate.EditValue / 100);
                }
                else
                {
                    calcAccumDevaluationAmount.EditValue = (decimal)calcDevaluationAmount.EditValue < ((decimal)calcPeriodDevaluationAmount.EditValue * months) ? (decimal)calcDevaluationAmount.EditValue : ((decimal)calcPeriodDevaluationAmount.EditValue * months);
                }
            }
            calcRemainingDevaluationAmount.EditValue = devaluationAmount - (decimal)calcAccumDevaluationAmount.EditValue;
        }


        private void cbbDevaluationPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lifeTime = Convert.ToInt16(cboFixedAssetCategory.GetColumnValue("LifeTime"));
            var depreciationRate = Convert.ToDecimal(cboFixedAssetCategory.GetColumnValue("DepreciationRate"));
            if (cbbDevaluationPeriod.SelectedIndex == 0)
            {
                calcDevaluationRate.EditValue = depreciationRate;
                calcRemainingDevaluationLifeTime.EditValue = lifeTime != 0 ? lifeTime : calcRemainingDevaluationLifeTime.EditValue;
            }
            else if (cbbDevaluationPeriod.SelectedIndex == 1)
            {
                calcDevaluationRate.EditValue = Math.Round(depreciationRate / 4, 2);
                calcRemainingDevaluationLifeTime.EditValue = lifeTime != 0
                    ? lifeTime * 4
                    : calcRemainingDevaluationLifeTime.EditValue;
            }
            else
            {
                calcDevaluationRate.EditValue = Math.Round(depreciationRate / 12, 2);
                calcRemainingDevaluationLifeTime.EditValue = lifeTime != 0
                    ? lifeTime * 12
                    : calcRemainingDevaluationLifeTime.EditValue;
            }
        }

        private void calcDevaluationRate_EditValueChanged(object sender, EventArgs e)
        {

            var devaluationAmount = (decimal)calcDevaluationAmount.EditValue;
            var years = DateTime.Parse(GlobalVariable.SystemDate).Year - dateDevaluationDate.DateTime.Year;
            var months = years * 12 + DateTime.Parse(GlobalVariable.SystemDate).Month - dateDevaluationDate.DateTime.Month <= 0 ? 0 : years * 12 + DateTime.Parse(GlobalVariable.SystemDate).Month - dateDevaluationDate.DateTime.Month;
            calcPeriodDevaluationAmount.EditValue = devaluationAmount * (decimal)calcDevaluationRate.EditValue / 100;
            if (ActionMode != ActionModeEnum.None)
            {
                if (cbbDevaluationPeriod.SelectedIndex == 0)
                {
                    calcAccumDevaluationAmount.EditValue = (decimal)calcDevaluationAmount.EditValue < (devaluationAmount * years * (decimal)calcDepreciationRate.EditValue / 100) ? (decimal)calcDevaluationAmount.EditValue : (devaluationAmount * years * (decimal)calcDepreciationRate.EditValue / 100);
                }
                else if (cbbDevaluationPeriod.SelectedIndex == 1)
                {
                    calcAccumDevaluationAmount.EditValue = (decimal)calcDevaluationAmount.EditValue < (Math.Round(devaluationAmount * Math.Ceiling((decimal)months / 3)) * (decimal)calcDevaluationRate.EditValue / 100) ? (decimal)calcDevaluationAmount.EditValue : (Math.Round(devaluationAmount * Math.Ceiling((decimal)months / 3)) * (decimal)calcDevaluationRate.EditValue / 100);
                }
                else
                {
                    calcAccumDevaluationAmount.EditValue = (decimal)calcDevaluationAmount.EditValue < (Math.Round(devaluationAmount * months) * (decimal)calcDevaluationRate.EditValue / 100) ? (decimal)calcDevaluationAmount.EditValue : (Math.Round(devaluationAmount * months) * (decimal)calcDevaluationRate.EditValue / 100);
                }
            }
        }

        private void calcAccumDevaluationAmount_EditValueChanged(object sender, EventArgs e)
        {
            calcRemainingDevaluationAmount.EditValue = (decimal)calcDevaluationAmount.EditValue - (decimal)calcAccumDevaluationAmount.EditValue;
            calcTotalDepreciation.EditValue = (decimal)calcAccumDepreciation.EditValue + (decimal)calcAccumDevaluationAmount.EditValue;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the calcLifeTime control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void calcLifeTime_EditValueChanged(object sender, EventArgs e)
        {
            calcRemainLifeTime.EditValue = calcLifeTime.EditValue;
            //DateTime depreciationDate = (DateTime)dateDepreciationDate.EditValue;
            //int endyear = Convert.ToInt16(calcLifeTime.EditValue) + Convert.ToInt16(depreciationDate.Year);
            //calcEndYear.EditValue = endyear;
        }

        /// <summary>
        /// Handles the Leave event of the datePurchaseDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void datePurchaseDate_Leave(object sender, EventArgs e)
        {
            dateUsedDate.EditValue = datePurchaseDate.EditValue;
            dateIncrementDate.EditValue = datePurchaseDate.EditValue;
            dateDepreciationDate.EditValue = datePurchaseDate.EditValue;
            dateDevaluationDate.EditValue = datePurchaseDate.EditValue;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboBudgetSubKindItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboBudgetSubKindItem_EditValueChanged(object sender, EventArgs e)
        {
            var row = (BudgetKindItemModel)cboBudgetSubKindItem.GetSelectedDataRow();
            if (row == null)
                return;
            {
                BudgetKindItemModel budgetKindItem = _budgetKindItemsPresenter.GetBudgetKindItem(row.ParentId);
                cboBudgetKindItem.EditValue = budgetKindItem.BudgetKindItemCode;
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboBudgetSubItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboBudgetSubItem_EditValueChanged(object sender, EventArgs e)
        {
            var row = (BudgetItemModel)cboBudgetSubItem.GetSelectedDataRow();
            if (row == null)
                return;
            {
                BudgetItemModel budgetItem = _budgetItemsPresenter.GetBudgetItem(row.ParentId);
                cboBudgetItem.EditValue = budgetItem.BudgetItemCode;
            }
        }

        private void calcRemainDepreciationAmount_EditValueChanged(object sender, EventArgs e)
        {
            calcRemainAmount.EditValue = (decimal)calcRemainingDevaluationAmount.EditValue + (decimal)calcRemainDepreciationAmount.EditValue;
        }

        private void calcRemainingDevaluationAmount_EditValueChanged(object sender, EventArgs e)
        {
            calcRemainAmount.EditValue = (decimal)calcRemainingDevaluationAmount.EditValue + (decimal)calcRemainDepreciationAmount.EditValue;
        }

        private void btnEditable_Click(object sender, EventArgs e)
        {
            ActionMode = ActionModeEnum.Edit;
            datePurchaseDate.Enabled = true;
            dateIncrementDate.Enabled = true;
            dateUsedDate.Enabled = true;
            calcOrigPrice.Enabled = true;
            spUsingRatio.Enabled = true;
            dateDepreciationDate.Enabled = true;
            calcAccumDepreciation.Enabled = true;

            cboDepreciationDebitAccount.Enabled = true;
            cboDepreciationCreditAccount.Enabled = true;
            cboSource.Enabled = true;
            cboFundStructureItem.Enabled = true;
            cboBudgetChapter.Enabled = true;
            cboBudgetSubKindItem.Enabled = true;
            cboBudgetSubItem.Enabled = true;

            cboFixedAssetCategory.Enabled = true;
            cboDepartment.Enabled = true;
            cboDevaluationCreditAccount.Enabled = true;
            cboDevaluationDebitAccount.Enabled = true;
            cboDepreciationCreditAccount.Enabled = true;
            cboDepreciationDebitAccount.Enabled = true;
            txtFixedAssetCode.Enabled = true;
            txtFixedAssetName.Enabled = true;
            calcQuantity.Enabled = true;
            txtUnit.Enabled = true;
            txtSerialNumber.Enabled = true;
            txtGuaranteeDuration.Enabled = true;
            calcProductionYear.Enabled = true;
            txtMadeIn.Enabled = true;
            cboVendor.Enabled = true;
            txtDescription.Enabled = true;
            cboCapitalAccount.Enabled = true;
            var usingRatio = (decimal)spUsingRatio.EditValue;
            if (usingRatio != 0)
            {
                dateDevaluationDate.Enabled = true;
                cbbDevaluationPeriod.Enabled = true;
                calcDevaluationRate.Enabled = true;
                calcRemainingDevaluationLifeTime.Enabled = true;
                calcAccumDevaluationAmount.Enabled = true;
                cboDevaluationDebitAccount.Enabled = true;
                cboDepreciationCreditAccount.Enabled = true;
            }
            btnEditable.Enabled = false;
            btnSave.Enabled = true;
        }

        private void grvAccessoryDetail_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenuAccessory.ShowPopup(grvAccessory.PointToScreen(e.Point));
                }
            }
        }

        private void barToolManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnDeleteAccessory":
                    if (grvAccessoryDetail.DataSource != null)
                    {
                        grvAccessoryDetail.DeleteRow(_rowAccessoryHandle);
                    }
                    break;
            }
        }

        private void grvAccessoryDetail_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (grvAccessory.DataSource != null)
            {
                _rowAccessoryHandle = grvAccessoryDetail.FocusedRowHandle;
            }
        }

        public IList<RefTypeModel> RefTypes { get; set; }
        public IList<FundStructureModel> FundStructures
        {
            set
            {
                cboFundStructureItem.Properties.DataSource = value;
                cboFundStructureItem.Properties.ForceInitialize();
                cboFundStructureItem.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>
                {

                    new XtraColumn
                    {
                        ColumnName = "FundStructureCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Mã khoản chi",
                        ColumnPosition = 2,
                        AllowEdit = true,
                        //ColumnType = UnboundColumnType.Decimal,
                        IsSummnary = true,
                    },
                    new XtraColumn {
                        ColumnName = "FundStructureName",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tên khoản chi",
                        ColumnPosition = 3,
                        IsSummnary = true,
                        AllowEdit = false,
                        //ColumnType = UnboundColumnType.Decimal,
                    }
                };
                cboFundStructureItem = InitColumn(columnsCollection, cboFundStructureItem);
                cboFundStructureItem.Properties.DisplayMember = "FundStructureCode";
                cboFundStructureItem.Properties.ValueMember = "FundStructureId";

            }
        }
        private LookUpEdit InitColumn(List<XtraColumn> columnsCollections, LookUpEdit grdView)
        {
            for (var i = 0; i < grdView.Properties.Columns.Count; i++)
            {
                var column = grdView.Properties.Columns[i];
                var columnsCollection = columnsCollections.FirstOrDefault(c => c.ColumnName == column.FieldName);

                if (columnsCollection != null)
                {
                    column.Visible = true;
                    column.Caption = columnsCollection.ColumnCaption;
                    column.Width = columnsCollection.ColumnWith;
                }
                else
                {
                    column.Visible = false;
                }

            }
            return grdView;
        }
        /// <summary>
        /// Thay đổi nguồn hình thành tài sản sẽ thay đổi tài khoản giá trị còn lại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSource_EditValueChanged(object sender, EventArgs e)
        {
            if (OldFixedAssetVoucherAttachs != null && OldFixedAssetVoucherAttachs.Count() > 0 && Int32.Parse(cboSource.EditValue.ToString()) != OldSource)
            {
                cboSource.EditValue = OldSource;
                XtraMessageBox.Show("Tài sản đã phát sinh nghiệp vụ. Bạn không thể thay đổi nguồn hình thành tài sản",
                       ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateHaoMon();

        }
        public void UpdateHaoMon()
        {

            if (Source == 1)
            {
                // tk no 1
                cboDepreciationDebitAccount.EditValue = "6113";
                // tk co 1
                //    cboDepreciationCreditAccount.EditValue = "2141";
                // tk no 2
                cboDevaluationDebitAccount.EditValue = "36611";
                // tk co 2
                cboDevaluationCreditAccount.EditValue = "5118";
                // tai khoan con lai
                cboCapitalAccount.EditValue = "36611";
            }
            if (Source == 2)
            {
                // tk no 1
                cboDepreciationDebitAccount.EditValue = "6113";
                // tk co 1
                //    cboDepreciationCreditAccount.EditValue = "2141";
                // tk no 2
                cboDevaluationDebitAccount.EditValue = "36611";
                // tk co 2
                cboDevaluationCreditAccount.EditValue = "5118";
                // tai khoan con lai
                cboCapitalAccount.EditValue = "36611";
            }
            if (Source == 3)
            {
                // tk no 1
                cboDepreciationDebitAccount.EditValue = "6113";
                // tk co 1
                //    cboDepreciationCreditAccount.EditValue = "2141";
                // tk no 2
                cboDevaluationDebitAccount.EditValue = "36611";
                // tk co 2
                cboDevaluationCreditAccount.EditValue = "5111";
                // tai khoan con lai
                cboCapitalAccount.EditValue = "36611";
            }
            // check theo cả loại
            if (Source == 4)
            {
                // tk no 1
                cboDepreciationDebitAccount.EditValue = "6121";
                // tk co 1
                //      cboDepreciationCreditAccount.EditValue = "2141";
                // tk no 2
                cboDevaluationDebitAccount.EditValue = "36621";
                // tk co 2
                cboDevaluationCreditAccount.EditValue = "5112";
                // tai khoan con lai
                cboCapitalAccount.EditValue = "36621";
            }
            if (Source == 5)
            {
                // tk no 1
                cboDepreciationDebitAccount.EditValue = "6143";
                // tk co 1
                //     cboDepreciationCreditAccount.EditValue = "2141";
                // tk no 2
                cboDevaluationDebitAccount.EditValue = "36631";
                // tk co 2
                cboDevaluationCreditAccount.EditValue = "5114";
                // tai khoan con lai
                cboCapitalAccount.EditValue = "36631";
            }
            if (Source == 6)
            {
                // tk no 1
                cboDepreciationDebitAccount.EditValue = "43122";
                // tk co 1
                //  cboDepreciationCreditAccount.EditValue = "2141";
                // tk no 2
                cboDevaluationDebitAccount.EditValue = null;
                // tk co 2
                cboDevaluationCreditAccount.EditValue = null;
                // tai khoan con lai
                cboCapitalAccount.EditValue = "43122";
            }
            if (Source == 7)
            {
                // tk no 1
                cboDepreciationDebitAccount.EditValue = "6113";
                // tk co 1
                //    cboDepreciationCreditAccount.EditValue = "2141";
                // tk no 2
                cboDevaluationDebitAccount.EditValue = "43142";
                // tk co 2
                cboDevaluationCreditAccount.EditValue = "421";
                // tai khoan con lai
                cboCapitalAccount.EditValue = "43142";
            }
            if (Source == 8)
            {
                // tk no 1
                cboDepreciationDebitAccount.EditValue = "6113";
                // tk co 1
                // cboDepreciationCreditAccount.EditValue = "2141";
                // tk no 2
                cboDevaluationDebitAccount.EditValue = "36611";
                // tk co 2
                cboDevaluationCreditAccount.EditValue = "5118";
                // tai khoan con lai
                cboCapitalAccount.EditValue = "36611";
            }
            if (Source == 9)
            {
                // tk no 1
                cboDepreciationDebitAccount.EditValue = "6113";
                // tk co 1
                // cboDepreciationCreditAccount.EditValue = "2141";
                // tk no 2
                cboDevaluationDebitAccount.EditValue = "36611";
                // tk co 2
                cboDevaluationCreditAccount.EditValue = "5118";
                // tai khoan con lai
                cboCapitalAccount.EditValue = "36611";
            }
        }
        private void cboVendor_EditValueChanged(object sender, EventArgs e)
        {
            if (cboVendor.EditValue == null)
                return;
            var address = (string)cboVendor.GetColumnValue("Address");
            txtVendorAddress.Text = address;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TableLayoutRowStyleCollection styles =
                this.tableLayoutPanel18.RowStyles;

            // for (int i = 0; i < styles.Count; i++)
            if (!checkBox1.Checked)
            {
                styles[0].Height = 28;
                styles[1].Height = 16;
                styles[2].Height = 26;
                styles[3].Height = 5;
                styles[4].Height = 16;
                styles[5].Height = 37;
                this.Size = new Size(this.Size.Width, 573);
                groupBox2.Size = new Size(groupBox2.Size.Width, 160);
            }
            else
            {
                styles[0].Height = 28;
                styles[1].Height = 16;
                styles[2].Height = 26;
                styles[3].Height = 26;
                styles[4].Height = 16;
                styles[5].Height = 16;
                this.Size = new Size(this.Size.Width, 685);
                groupBox2.Size = new Size(groupBox2.Size.Width, 266);
            }
            this.CenterToScreen();
            //foreach (RowStyle style in styles)
            //{
            //    if (style.SizeType == SizeType.Absolute)
            //    {
            //        style.SizeType = SizeType.AutoSize;
            //    }
            //    else if (style.SizeType == SizeType.AutoSize)
            //    {
            //        style.SizeType = SizeType.Percent;

            //        // Set the row height to be a percentage
            //        // of the TableLayoutPanel control's height.
            //        style.Height = 33;
            //    }
            //    else
            //    {

            //        // Set the row height to 50 pixels.
            //        style.SizeType = SizeType.Absolute;
            //        style.Height = 50;
            //    }
            //}
        }


        private void CboDepartment_EditValueChanged(object sender, EventArgs e)
        {
            //check fixedasset exits
            if (ActionMode == ActionModeEnum.Edit)
            {
                var departmentIdOld = _model.GetFixedAssetById(FixedAssetId).DepartmentId;
                var fixAssetLedger = _model.GetFixedAssetLedgerById(FixedAssetId).Where(x => x.RefType != 603).ToList();

                if (fixAssetLedger.Count() > 0)
                {
                    if (cboDepartment.EditValue.ToString() != departmentIdOld)
                    {
                        DialogResult dlResult = XtraMessageBox.Show("  Tài sản đã phát sinh chứng từ !Bạn không thể thay đổi danh mục phòng ban !", "Thông báo",
                                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cboFixedAssetCategory.EditValue = departmentIdOld;

                }
            }
        }

        private void btnAddChapter_Click(object sender, EventArgs e)
        {
            var frmBudgetChapter = new FrmBudgetChapterDetail();
            frmBudgetChapter.ShowDialog();
            if (frmBudgetChapter.CloseBox)
            {
                if (!string.IsNullOrEmpty(GlobalVariable.BudgetChapterIDAccountingObjectDetailForm))
                {
                    _budgetChaptersPresenter.DisplayByIsActive(true);
                    cboBudgetChapter.Properties.DisplayMember = "BudgetChapterCode";
                    cboBudgetChapter.Properties.ValueMember = "BudgetChapterId";
                    cboBudgetChapter.EditValue = GlobalVariable.BudgetChapterIDAccountingObjectDetailForm;
                }
            }
        }
        /// <summary>
        /// Thêm mới loại TSCĐ
        /// </summary>
        private void cboFixedAssetCategory_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frm = new FrmFixedAssetCategoryDetail();
                frm.ShowDialog();
                if (frm.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.FixedAssetCategoryDetailForm))
                    {
                        _fixedAssetCategoryPresenter.Display();
                        cboFixedAssetCategory.EditValue = GlobalVariable.FixedAssetCategoryDetailForm;
                    }
                }
            }
        }

        /// <summary>
        /// Thêm mới phòng ban
        /// </summary>
        private void cboDepartment_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

            if (e.Button.Index.Equals(1))
            {
                FrmDepartmentDetail frmDepartmentDetail = new FrmDepartmentDetail();
                frmDepartmentDetail.ShowDialog();
                if (frmDepartmentDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.DepartmentIDEmployeeDetailForm))
                    {
                        _departmentsPresenter.Display();
                        cboDepartment.EditValue = GlobalVariable.DepartmentIDEmployeeDetailForm;
                    }
                }
            }
        }

        private void cboBudgetChapter_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBudgetChapter = new FrmBudgetChapterDetail();
                frmBudgetChapter.ShowDialog();
                if (frmBudgetChapter.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetChapterIDAccountingObjectDetailForm))
                    {
                        _budgetChaptersPresenter.DisplayByIsActive(true);
                        cboBudgetChapter.Properties.DisplayMember = "BudgetChapterCode";
                        cboBudgetChapter.Properties.ValueMember = "BudgetChapterId";
                        cboBudgetChapter.EditValue = GlobalVariable.BudgetChapterIDAccountingObjectDetailForm;
                    }
                }
            }
        }

        /// <summary>
        /// Thêm mới khoản
        /// </summary>
        private void cboBudgetSubKindItem_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBudgetKindItem = new FrmBudgetKindItemDetail();
                frmBudgetKindItem.ShowDialog();
                if (frmBudgetKindItem.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetKindItemIDAutoBusinessForm))
                    {
                        _budgetKindItemsPresenter.DisplayActive();
                        cboBudgetSubKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                        cboBudgetSubKindItem.Properties.ValueMember = "BudgetKindItemId";
                        cboBudgetSubKindItem.EditValue = GlobalVariable.BudgetKindItemIDAutoBusinessForm;
                    }
                }
            }
        }

        /// <summary>
        /// Thêm mới tiểu mục
        /// </summary>
        private void cboBudgetSubItem_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBudgetItem = new FrmBudgetItemDetail();
                frmBudgetItem.ShowDialog();
                if (frmBudgetItem.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetItemDetailAccountingObjectDetailForm))
                    {
                        _budgetItemsPresenter.DisplayActive(true);

                        cboBudgetSubItem.Properties.DisplayMember = "BudgetItemCode";
                        cboBudgetSubItem.Properties.ValueMember = "BudgetItemId";
                        cboBudgetSubItem.EditValue = GlobalVariable.BudgetItemDetailAccountingObjectDetailForm;
                    }
                }
            }
        }

        /// <summary>
        /// Thêm mới đối tượng nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboVendor_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmXtraAccountingObjectDetail frmAccountingObjectDetail = new FrmXtraAccountingObjectDetail();
                frmAccountingObjectDetail.ShowDialog();
                if (frmAccountingObjectDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                    {
                        _accountingObjectsPresenter.Display();
                        cboVendor.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                    }
                }
            }
        }


        /// <summary>
        /// Thêm mới tk giá trị còn lại
        /// </summary>
        private void cboCapitalAccount_ButtonClick(object sender, ButtonPressedEventArgs e)
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
                        cboCapitalAccount.Properties.DisplayMember = "AccountNumber";
                        cboCapitalAccount.Properties.ValueMember = "AccountId";
                        cboCapitalAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;
                    }
                }
            }
        }

        /// <summary>
        /// Thêm mới tk có
        /// </summary>
        private void cboDepreciationDebitAccount_ButtonClick(object sender, ButtonPressedEventArgs e)
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
                        cboDepreciationDebitAccount.Properties.DisplayMember = "AccountNumber";
                        cboDepreciationDebitAccount.Properties.ValueMember = "AccountId";
                        cboDepreciationDebitAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;
                    }
                }
            }
        }

        /// <summary>
        /// Thêm mới tk nợ
        /// </summary>
        private void cboDepreciationCreditAccount_ButtonClick(object sender, ButtonPressedEventArgs e)
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
                        cboDepreciationCreditAccount.Properties.DisplayMember = "AccountNumber";
                        cboDepreciationCreditAccount.Properties.ValueMember = "AccountId";
                        cboDepreciationCreditAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;
                    }
                }
            }
        }
        #endregion

        #region In thẻ TSCĐ
        protected override void PrintFixAsset(object sender, EventArgs e)
        {
            var _reportList = new Model.Model().GetReportListByReportId(CommonText.ReportFixedAssetTag);
            if (_reportList == null || string.IsNullOrEmpty(_reportList.ReportId))
                return;
            object[] parms = { nameof(this.FixedAssetId), this.FixedAssetId };
            ReportTool.PreviewReport(this, _reportList, parms, null);
        }
        #endregion
    }
}