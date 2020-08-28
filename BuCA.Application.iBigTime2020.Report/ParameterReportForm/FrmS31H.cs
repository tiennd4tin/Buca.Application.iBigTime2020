using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using DevExpress.XtraRichEdit.Layout;
using Microsoft.SqlServer.Management.Smo;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using DevExpress.Utils;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Currency;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.General;
using Buca.Application.iBigTime2020.View.General;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using DevExpress.Data;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS31H.
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    public partial class FrmS31H : FrmXtraBaseParameter, IAccountsView, IAccountingObjectsView, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IProjectsView, IAccountingObjectCategoriesView, ICurrenciesView, IFundStructuresView, IContractsView, IBudgetItemsView, IBanksView, IInventoryItemsView, IFixedAssetsView, IActivitysView, ICapitalPlansView
    {
        List<AccountModel> AccoutsCurrents = new List<AccountModel>();
        #region Presenter
        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;
        /// <summary>
        /// The Accounting Object Categorie Presenter
        /// </summary>
        private readonly AccountingObjectCategoriesPresenter _accountingObjectCategoriessPresenter;
        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        /// <summary>
        /// The projects Presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;
        ///<summary>
        ///The currency
        /// </summary>
        private readonly CurrenciesPresenter _currenciesPresenter;
        ///<summary>
        ///The Contracts
        /// </summary>
        private readonly ContractsPresenter _contractsPresenter;
        ///<summary>
        ///The BudgetItems
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        ///<summary>
        ///The Banks
        /// </summary>
        private readonly BanksPresenter _banksPresenter;
        ///<summary>
        ///The InventoryItems
        /// </summary>
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        ///<summary>
        ///The FixedAssets
        /// </summary>
        private readonly FixedAssetsPresenter _FixedAssetsPresenter;
        ///<summary>
        ///The Activitys
        /// </summary>
        private readonly ActivitysPresenter _activitysPresenter;
        ///<summary>
        ///The CapitalPlans
        /// </summary>
        private readonly CapitalPlansPresenter _capitalPlansPresenter;
        /// <summary>
        /// Gets the Fund Structures
        /// </summary>
        /// <value>The Fund Structures.</value>
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        #endregion
        #region Variable
        /// <summary>
        /// Sets from date.
        /// </summary>
        /// <value>From date.</value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }
        /// <summary>
        /// Sets to date.
        /// </summary>
        /// <value>To date.</value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }
        /// <summary>
        /// Sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber
        {
            get
            {
                if (grdLookUpAccount.EditValue != null)
                {
                    return grdLookUpAccount.GetColumnValue("AccountNumber").ToString();
                }
                else
                    return "";
            }
        }
        /// <summary>
        /// Sets a value WhereClause.
        /// </summary>
        /// <value> WhereClause.</value>
        public string CorrespondingAccountNumber
        {
            get
            {
                return Convert.ToString(grdLookUpCorrespondingAccount.EditValue);
            }
        }
        public string CustomerID
        {
            get
            {
                if (chkCustomer.Checked && cboCustomer.EditValue != null)
                    return Convert.ToString(cboCustomer.EditValue);
                else
                    return "";
            }
        }
        public string VendorID
        {
            get
            {
                if (chkVendor.Checked && cboVendor.EditValue != null)
                    return Convert.ToString(cboVendor.EditValue);
                else
                    return "";
            }
        }
        public string EmployeeID
        {
            get
            {
                if (chkEmployee.Checked && cboEmployee.EditValue != null)
                    return Convert.ToString(cboEmployee.EditValue);
                else
                    return "";
            }
        }
        public string AccountingObjectID
        {
            get
            {
                if (chkAccountingObject.Checked && cboAccountingObject.EditValue != null)
                    return Convert.ToString(cboAccountingObject.EditValue);
                else
                    return "";
            }
        }
        public string BudgetSourceID
        {
            get
            {
                if (chkBudgetSource.Checked && cboBudgetSource.EditValue != null)
                    return Convert.ToString(cboBudgetSource.EditValue);
                else
                    return "";
            }
        }
        public string FundStructureID
        {
            get
            {
                if (chkExpend.Checked && cboExpend.EditValue != null)
                    return Convert.ToString(cboExpend.EditValue);
                else
                    return "";
            }
        }
        public string BudgetChapterCode
        {
            get
            {
                if (chkBudgetChapter.Checked && cboBudgetChapter.EditValue != null)
                    return Convert.ToString(cboBudgetChapter.EditValue);
                else
                    return "";
            }
        }
        public string BudgetKindItemCode
        {
            get
            {
                if (chkBudgetCategory.Checked && cboBudgetCategory.EditValue != null)
                    return Convert.ToString(cboBudgetCategory.EditValue);
                else
                    return "";
            }
        }
        public string BudgetItemCode
        {
            get
            {
                if (chkBudgetItem.Checked && cboBudgetItem.EditValue != null)
                    return Convert.ToString(cboBudgetItem.EditValue);
                else
                    return "";
            }
        }
        public string ProjectID
        {
            get
            {
                if (chkProject.Checked && cboProject.EditValue != null)
                    return Convert.ToString(cboProject.EditValue);
                else
                    return "";
            }
        }
        public string ContractID
        {
            get
            {
                if (chkContract.Checked && cboContract.EditValue != null)
                    return Convert.ToString(cboContract.EditValue);
                else
                    return "";
            }
        }
        public string BankID
        {
            get
            {
                if (chkBank.Checked && cboBank.EditValue != null)
                    return Convert.ToString(cboBank.EditValue);
                else
                    return "";
            }
        }
        public string ActivityId
        {
            get
            {
                if (chkWork.Checked && cboWork.EditValue != null)
                    return Convert.ToString(cboWork.EditValue);
                else
                    return "";
            }
        }
        public string CapitalPlanID
        {
            get
            {
                if (chkCapitalPlan.Checked && cboCapitalPlan.EditValue != null)
                    return Convert.ToString(cboCapitalPlan.EditValue);
                else
                    return "";
            }
        }
        public string CurrencyCode
        {
            get
            {
                if (chkCurrency.Checked && cboCurrency.EditValue != null)
                    return Convert.ToString(cboCurrency.EditValue);
                else
                    return "";
            }
        }
        public string FixedAssetId
        {
            get
            {
                if (chkFixedAsset.Checked && cboFixedAsset.EditValue != null)
                    return Convert.ToString(cboFixedAsset.EditValue);
                else
                    return "";
            }
        }
        public string InventoryItemId
        {
            get
            {
                if (chkInventoryItem.Checked && cboInventoryItem.EditValue != null)
                    return Convert.ToString(cboInventoryItem.EditValue);
                else
                    return "";
            }
        }
        #endregion
        #region ----IsGroup----
        public bool IsAccountingObjectID
        {
            get
            {
                return chkAccountingObject.Checked;
            }
        }
        public bool ISCustomer
        {
            get
            {
                return chkCustomer.Checked;
            }
        }
        public bool ISVendor
        {
            get
            {
                return chkVendor.Checked;
            }
        }
        public bool ISEmployee
        {
            get
            {
                return chkEmployee.Checked;
            }
        }
        public bool IsGroupBudgetSourceID
        {
            get
            {
                return chkBudgetSource.Checked;
            }
        }
        public bool IsGroupFundStructureID
        {
            get
            {
                return chkExpend.Checked;
            }
        }
        public bool IsGroupBudgetChapterCode
        {
            get
            {
                return chkBudgetChapter.Checked;
            }
        }
        public bool IsGroupBudgetKindItemCode
        {
            get
            {
                return chkBudgetCategory.Checked;
            }
        }
        public bool IsGroupBudgetItemCode
        {
            get
            {
                return chkBudgetItem.Checked;
            }
        }
        public bool IsGroupProjectID
        {
            get
            {
                return chkProject.Checked;
            }
        }
        public bool IsGroupContractID
        {
            get
            {
                return chkContract.Checked;
            }
        }
        public bool IsGroupBankID
        {
            get
            {
                return chkBank.Checked;
            }
        }
        public bool IsGroupActivityId
        {
            get
            {
                return chkWork.Checked;
            }
        }
        public bool IsGroupCapitalPlanID
        {
            get
            {
                return chkCapitalPlan.Checked;
            }
        }
        public bool IsGroupCurrencyCode
        {
            get
            {
                return chkCurrency.Checked;
            }
        }
        public bool IsGroupFixedAssetId
        {
            get
            {
                return chkFixedAsset.Checked;
            }
        }
        public bool IsGroupInventoryItemId
        {
            get
            {
                return chkInventoryItem.Checked;
            }
        }
        #endregion
        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        /// <summary>
        /// The columns collection account
        /// </summary>
        public List<XtraColumn> ColumnsCollectionAccount = new List<XtraColumn>();
        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>The selection.</value>
        internal GridCheckMarksSelection Selection { get; set; }
        /// <summary>
        /// Gets the selection account.
        /// </summary>
        /// <value>The selection account.</value>
        internal GridCheckMarksSelection SelectionAccount { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS31H"/> class.
        /// </summary>
        public FrmS31H()
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            _accountingObjectCategoriessPresenter = new AccountingObjectCategoriesPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _currenciesPresenter = new CurrenciesPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _contractsPresenter = new ContractsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _FixedAssetsPresenter = new FixedAssetsPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
        }

        #region IView

        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <value>The accounting objects.</value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {

                GrdAccountingObject(cboCustomer, "Mã khách hàng", "Tên khách hàng", (List<AccountingObjectModel>)value, "KH", false);
                GrdAccountingObject(cboVendor, "Mã nhà cc", "Tên nhà cung cấp", (List<AccountingObjectModel>)value, "NCC", false);
                GrdAccountingObject(cboAccountingObject, "Mã đối tượng", "Tên đối tượng", (List<AccountingObjectModel>)value, "DTK", false);
                GrdAccountingObject(cboEmployee, "Mã nhân viên", "Tên nhân viên", (List<AccountingObjectModel>)value, "", true);
            }
        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                AccoutsCurrents = value.ToList();
                GrdAccount(grdLookUpAccount, (List<AccountModel>)value ?? new List<AccountModel>());
                GrdAccount(grdLookUpCorrespondingAccount, (List<AccountModel>)value ?? new List<AccountModel>());
            }
        }
        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                cboBudgetChapter.Properties.DataSource = value ?? new List<BudgetChapterModel>();
                cboBudgetChapter.Properties.ForceInitialize();
                cboBudgetChapter.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Mã Chương",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterName",
                    ColumnCaption = "Tên Chương",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250,

                });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboBudgetChapter.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetChapter.Properties.DisplayMember = "BudgetChapterCode";
                cboBudgetChapter.Properties.ValueMember = "BudgetChapterCode";
            }
        }
        #region Projects
        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public IList<ProjectModel> Projects
        {
            set
            {
                cboProject.Properties.DataSource = value ?? new List<ProjectModel>();
                cboProject.Properties.ForceInitialize();
                cboProject.Properties.PopulateColumns();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectCode",
                    ColumnCaption = "Mã Dự án",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectName",
                    ColumnCaption = "Tên Dự án",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectBanks", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });
                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboProject.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboProject.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboProject.Properties.SortColumnIndex = column.ColumnPosition;

                    }
                    else
                        cboProject.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboProject.Properties.DisplayMember = "ProjectCode";
                cboProject.Properties.ValueMember = "ProjectId";

            }
        }
        #endregion
        /// <summary>
        /// Sets the budget kind items.
        /// </summary>
        /// <value>The budget kind items.</value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                cboBudgetCategory.Properties.DataSource = value ?? new List<BudgetKindItemModel>();
                cboBudgetCategory.Properties.ForceInitialize();
                cboBudgetCategory.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetKindItemCode",
                    ColumnCaption = "Mã Khoản",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetKindItemName",
                    ColumnCaption = "Tên Khoản",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetCategory.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetCategory.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetCategory.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetCategory.Properties.DisplayMember = "BudgetKindItemCode";
                cboBudgetCategory.Properties.ValueMember = "BudgetKindItemCode";
            }
        }
        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {

                cboBudgetSource.Properties.DataSource = value ?? new List<BudgetSourceModel>();
                cboBudgetSource.Properties.ForceInitialize();
                cboBudgetSource.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCode",
                    ColumnCaption = "Mã nguồn vốn",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceName",
                    ColumnPosition = 2,
                    ColumnCaption = "Tên nguồn vốn",
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSavingExpenses", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceProperty", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankAccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "PayableBankAccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSelfControl", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceType", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetSource.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetSource.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetSource.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetSource.Properties.DisplayMember = "BudgetSourceCode";
                cboBudgetSource.Properties.ValueMember = "BudgetSourceId";
            }
        }
        /// <summary>
        /// Sets the Accounting Object Categories
        /// </summary>
        /// <value>The Accounting Object Categories.</value>
        public IList<AccountingObjectCategoryModel> AccountingObjectCategories { get; set; }
        /// <summary>
        /// Sets the Departments
        /// </summary>
        /// <value>The Departments.</value>
        /// <summary>
        /// Sets the Currencies
        /// </summary>
        /// <value>The Currencies.</value>
        public IList<CurrencyModel> Currencies
        {
            set
            {
                cboCurrency.Properties.DataSource = value ?? new List<CurrencyModel>();
                cboCurrency.Properties.ForceInitialize();
                cboCurrency.Properties.PopulateColumns();
                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyId", ColumnCaption = "Mã tiền tệ", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Mã tiền tệ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyName", ColumnCaption = "Tên tiền tệ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 300, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Prefix", ColumnCaption = "Tiền tố", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Suffix", ColumnCaption = "Hậu tố", ColumnPosition = 5, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsMain", ColumnCaption = "Là đồng tiền hạch toán", ColumnPosition = 6, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 7, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboCurrency.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboCurrency.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboCurrency.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboCurrency.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboCurrency.Properties.DisplayMember = "CurrencyCode";
                cboCurrency.Properties.ValueMember = "CurrencyCode";
            }
        }
        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>The fund structures.</value>
        public IList<FundStructureModel> FundStructures
        {
            set
            {
                cboExpend.Properties.DataSource = value ?? new List<FundStructureModel>();
                cboExpend.Properties.ForceInitialize();
                cboExpend.Properties.PopulateColumns();
                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureCode", ColumnCaption = "Mã khoản chi", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureName", ColumnCaption = "Tên khoản chi", ColumnPosition = 2, ColumnWith = 300, ColumnVisible = true });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });


                ColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentPeriod", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsProjectExpense", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsAllocateExpense", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsExpenseNoBuilding", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Inactive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnWith = 100, ColumnVisible = false });

                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboExpend.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboExpend.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboExpend.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboExpend.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboExpend.Properties.DisplayMember = "FundStructureCode";
                cboExpend.Properties.ValueMember = "FundStructureId";
            }
        }
        /// <summary>
        /// Sets the Contracts.
        /// </summary>
        /// <value>The Contracts.</value>
        public IList<ContractModel> Contracts
        {
            set
            {
                try
                {
                    cboContract.Properties.DataSource = value ?? new List<ContractModel>();
                    cboContract.Properties.ForceInitialize();
                    cboContract.Properties.PopulateColumns();
                    var ColumnsCollection = new List<XtraColumn>();
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractNo", ColumnCaption = "Số hợp đồng", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractName", ColumnCaption = "Tên hợp đồng", ColumnPosition = 2, ColumnWith = 300, ColumnVisible = true });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractId", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractNameEnglish", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "SignDate", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "EndDate", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorBankAccountId", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnWith = 100, ColumnVisible = false });
                    //ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractDetails", ColumnVisible = false });
                    foreach (var column in ColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            cboContract.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            cboContract.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                            cboContract.Properties.SortColumnIndex = column.ColumnPosition;
                        }
                        else
                            cboContract.Properties.Columns[column.ColumnName].Visible = false;
                    }
                    cboContract.Properties.DisplayMember = "ContractNo";
                    cboContract.Properties.ValueMember = "ContractId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Thông báo lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>The BudgetItems.</value>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {


                cboBudgetItem.Properties.DataSource = value ?? new List<BudgetItemModel>();
                cboBudgetItem.Properties.ForceInitialize();
                cboBudgetItem.Properties.PopulateColumns();
                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300, });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemType", ColumnCaption = "Loại", ColumnVisible = false, ColumnPosition = 3, ColumnWith = 30, AllowEdit = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 30 });
                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetItem.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboBudgetItem.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetItem.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetItem.Properties.DisplayMember = "BudgetItemCode";
                cboBudgetItem.Properties.ValueMember = "BudgetItemCode";
            }
        }
        public IList<BankModel> Banks
        {
            set
            {
                cboBank.Properties.DataSource = value ?? new List<BankModel>();
                cboBank.Properties.ForceInitialize();
                cboBank.Properties.PopulateColumns();
                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số tài khoản ngân hàng, kho bạc", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên tài khoản ngân hàng, kho bạc", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAddress", ColumnCaption = "Địa chỉ", ColumnPosition = 3, ColumnVisible = false, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsOpenInBank", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnVisible = false, ColumnWith = 20 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Used", ColumnCaption = "Used", ColumnPosition = 5, ColumnVisible = false, ColumnWith = 20 });
                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBank.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBank.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboBank.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBank.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBank.Properties.DisplayMember = "BankAccount";
                cboBank.Properties.ValueMember = "BankId";
            }
        }
        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>The inventory items.</value> 
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                cboInventoryItem.Properties.DataSource = value ?? new List<InventoryItemModel>();
                cboInventoryItem.Properties.ForceInitialize();
                cboInventoryItem.Properties.PopulateColumns();
                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SalePrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultStockId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "COGSAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SaleAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CostMethod", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TaxRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsService", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsTaxable", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsStock", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitsInStock", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCode",
                    ColumnCaption = "Mã vật tư/CCDC",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 70
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemName",
                    ColumnCaption = "Tên vật tư/CCDC",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 200
                });

                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboInventoryItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboInventoryItem.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboInventoryItem.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboInventoryItem.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboInventoryItem.Properties.DisplayMember = "InventoryItemCode";
                cboInventoryItem.Properties.ValueMember = "InventoryItemId";
            }
        }
        /// <summary>
        /// Sets the FixedAssets.
        /// </summary>
        /// <value>The FixedAssets.</value> 
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                cboFixedAsset.Properties.DataSource = value ?? new List<FixedAssetModel>();
                cboFixedAsset.Properties.ForceInitialize();
                cboFixedAsset.Properties.PopulateColumns();
                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCode", ColumnVisible = true, ColumnCaption = "Mã tài sản", ColumnPosition = 1, ColumnWith = 100 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetName", ColumnVisible = true, ColumnCaption = "Tên tài sản", ColumnPosition = 2, ColumnWith = 300 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnCaption = "Nhóm tài sản ", ColumnPosition = 3, ColumnVisible = false, ColumnWith = 50 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProductionYear", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "SerialNumber", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "Accessories", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "GuaranteeDuration", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSecondHand", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "LastState", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedReason", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PurchasedDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "UsedDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IncrementDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPrice", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationValueCaculated", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccumDepreciationAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "LifeTime", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationRate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PeriodDepreciationAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingLifeTime", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "EndYear", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPriceAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditDepreciationAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitDepreciationAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsFixedAssetTransfer", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationTimeCaculated", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "Source", ColumnVisible = false });

                //ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetActivities", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "UsingRatio", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationPeriod", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationLifeTime", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationRate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationCreditAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationDebitAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RevenueAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccumDevaluationAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetDetailAccessories", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetVoucherAttachs", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "EndDevaluationDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PeriodDevaluationAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboFixedAsset.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboFixedAsset.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboFixedAsset.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboFixedAsset.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboFixedAsset.Properties.DisplayMember = "FixedAssetCode";
                cboFixedAsset.Properties.ValueMember = "FixedAssetId";
            }
        }
        /// <summary>
        /// Sets the Activity
        /// </summary>
        /// <value>The Activity.</value> 
        public IList<ActivityModel> Activitys
        {
            set
            {
                cboWork.Properties.DataSource = value ?? new List<ActivityModel>();
                cboWork.Properties.ForceInitialize();
                cboWork.Properties.PopulateColumns();
                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityCode", ColumnCaption = "Mã công việc", ColumnVisible = true, ColumnWith = 30 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityName", ColumnCaption = "Tên công việc", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnVisible = false, ColumnWith = 20 });
                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboWork.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboWork.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboWork.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboWork.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboWork.Properties.DisplayMember = "ActivityCode";
                cboWork.Properties.ValueMember = "ActivityId";
            }
        }
        // <summary>
        // CapitalPlan
        // </summary>
        public IList<CapitalPlanModel> CapitalPlans
        {
            set
            {

                cboCapitalPlan.Properties.DataSource = value ?? new List<CapitalPlanModel>();
                cboCapitalPlan.Properties.ForceInitialize();
                cboCapitalPlan.Properties.PopulateColumns();
                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanCode", ColumnCaption = "Mã kế hoạch vốn", ColumnVisible = true, ColumnWith = 50, ColumnPosition = 1 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanId", ColumnCaption = "Tên kế hoạch vốn", ColumnVisible = false, });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanName", ColumnCaption = "Tên kế hoạch vốn", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 2 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboCapitalPlan.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboCapitalPlan.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        cboCapitalPlan.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboCapitalPlan.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboCapitalPlan.Properties.DisplayMember = "CapitalPlanCode";
                cboCapitalPlan.Properties.ValueMember = "CapitalPlanId";
            }
        }
        #endregion

        #region Event 
        /// <summary>
        /// Handles the Load event of the FrmS31H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmS31H_Load(object sender, EventArgs e)
        {
            _accountsPresenter.DisplayActive();
            _accountingObjectCategoriessPresenter.Display();
            _accountingObjectsPresenter.DisplayActive(true);
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _projectsPresenter.DisplayActive();
            _currenciesPresenter.DisplayActive();
            _fundStructuresPresenter.DisplayActive(true);
            _contractsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _banksPresenter.DisplayActive(true);
            _inventoryItemsPresenter.DisplayByIsActive(true);
            _FixedAssetsPresenter.DisplayByActive(true);
            _activitysPresenter.DisplayActive(true);
            _capitalPlansPresenter.Display();
            dateTimeRangeV1.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
        }

        #endregion

        #region Event CheckBox

        private void chkBudgetCategory_CheckedChanged(object sender, EventArgs e)
        {
            cboBudgetCategory.Enabled = chkBudgetCategory.Checked;
            cboBudgetCategory.EditValue = null;
        }

        private void chkBudgetChapter_CheckedChanged(object sender, EventArgs e)
        {
            cboBudgetChapter.Enabled = chkBudgetChapter.Checked;
            cboBudgetChapter.EditValue = null;
        }

        private void chkWork_CheckedChanged(object sender, EventArgs e)
        {
            cboWork.Enabled = chkWork.Checked;
            cboWork.EditValue = null;
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            cboCustomer.Enabled = chkCustomer.Checked;
            cboCustomer.EditValue = null;
        }

        private void chkProject_CheckedChanged(object sender, EventArgs e)
        {
            cboProject.Enabled = chkProject.Checked;
            cboProject.EditValue = null;
        }

        private void chkBudgetItem_CheckedChanged(object sender, EventArgs e)
        {
            cboBudgetItem.Enabled = chkBudgetItem.Checked;
            cboBudgetItem.EditValue = null;
        }

        private void chkFixedAsset_CheckedChanged(object sender, EventArgs e)
        {
            cboFixedAsset.Enabled = chkFixedAsset.Checked;
            cboFixedAsset.EditValue = null;
        }

        private void chkVoucherType_CheckedChanged(object sender, EventArgs e)
        {
            cboCapitalPlan.Enabled = chkCapitalPlan.Checked;
            cboCapitalPlan.EditValue = null;

        }

        private void chkBudgetSource_CheckedChanged(object sender, EventArgs e)
        {
            cboBudgetSource.Enabled = chkBudgetSource.Checked;
            cboBudgetSource.EditValue = null;
        }

        private void chkCurrency_CheckedChanged(object sender, EventArgs e)
        {
            cboCurrency.Enabled = chkCurrency.Checked;
            cboCurrency.EditValue = null;
        }

        private void chkAccountingObject_CheckedChanged(object sender, EventArgs e)
        {
            cboAccountingObject.Enabled = chkAccountingObject.Checked;
            cboAccountingObject.EditValue = null;
        }

        private void chkEmployee_CheckedChanged(object sender, EventArgs e)
        {
            cboEmployee.Enabled = chkEmployee.Checked;
            cboEmployee.EditValue = null;
        }

        private void chkVendor_CheckedChanged(object sender, EventArgs e)
        {
            cboVendor.Enabled = chkVendor.Checked;
            cboVendor.EditValue = null;
        }

        private void chkExpend_CheckedChanged(object sender, EventArgs e)
        {
            cboExpend.Enabled = chkExpend.Checked;
            cboExpend.EditValue = null;
        }

        private void chkContract_CheckedChanged(object sender, EventArgs e)
        {
            cboContract.Enabled = chkContract.Checked;
            cboContract.EditValue = null;
        }

        private void chkBank_CheckedChanged(object sender, EventArgs e)
        {
            cboBank.Enabled = chkBank.Checked;
            cboBank.EditValue = null;
        }

        private void chkCapitalPlan_CheckedChanged(object sender, EventArgs e)
        {
            cboCapitalPlan.Enabled = chkCapitalPlan.Checked;
            cboCapitalPlan.EditValue = null;
        }
        private void chkInventoryItem_CheckedChanged(object sender, EventArgs e)
        {
            cboInventoryItem.Enabled = chkInventoryItem.Checked;
            cboInventoryItem.EditValue = null;
        }
        #endregion
        private void GrdAccount(LookUpEdit LookUpAccount, object value)
        {
            LookUpAccount.Properties.DataSource = value;
            LookUpAccount.Properties.ForceInitialize();
            LookUpAccount.Properties.PopulateColumns();
            var columnsCollection = new List<XtraColumn>();
            columnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
            columnsCollection.Add(new XtraColumn
            {
                ColumnName = "AccountNumber",
                ColumnCaption = "Số tài khoản",
                ColumnPosition = 1,
                ColumnVisible = true,
                ColumnWith = 100
            });
            columnsCollection.Add(new XtraColumn
            {
                ColumnName = "AccountName",
                ColumnCaption = "Tên tài khỏan",
                ColumnPosition = 2,
                ColumnVisible = true,
                ColumnWith = 250
            });
            columnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
            columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
            columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
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
                    LookUpAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    LookUpAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    LookUpAccount.Properties.SortColumnIndex = column.ColumnPosition;
                }
                else
                    LookUpAccount.Properties.Columns[column.ColumnName].Visible = false;
            }
            LookUpAccount.Properties.DisplayMember = "AccountNumber";
            LookUpAccount.Properties.ValueMember = "AccountNumber";
        }
        private void GrdAccountingObject(LookUpEdit LookUpAccount, string Caption1, string Caption2, List<AccountingObjectModel> value, string AccountingObjectCategoryCode, bool IsEmployee)
        {
            if (!IsEmployee)
            {
                LookUpAccount.Properties.DataSource = (List<AccountingObjectModel>)value.Where(o => o.AccountingObjectCategoryId == (AccountingObjectCategories.FirstOrDefault(a => a.AccountingObjectCategoryCode == AccountingObjectCategoryCode) == null ? "" : AccountingObjectCategories.FirstOrDefault(a => a.AccountingObjectCategoryCode == AccountingObjectCategoryCode).AccountingObjectCategoryId)).ToList() ?? new List<AccountingObjectModel>();
            }
            else
            {
                LookUpAccount.Properties.DataSource = (List<AccountingObjectModel>)value.Where(o => o.IsEmployee == true).ToList() ?? new List<AccountingObjectModel>();
            }
            LookUpAccount.Properties.PopulateColumns();

            var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "AccountingObjectBanks", ColumnVisible = false },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = Caption1,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = Caption2,
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectCategoryId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Address", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Tel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Fax", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Website", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CompanyTaxCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AreaCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactTitle", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactSex", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactMobile", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactEmail", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactOfficeTel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactHomeTel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactAddress", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsEmployee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPersonal", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IdentificationNumber", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IssueDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IssueBy", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryScaleId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Insured", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LabourUnionFee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FamilyDeductionAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsCustomerVendor", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryCoefficient", ColumnVisible = false},
                    new XtraColumn {ColumnName = "NumberFamilyDependent", ColumnVisible = false},
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryForm", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryPercentRate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPayInsuranceOnSalary", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InsuranceAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsUnEmploymentInsurance", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefTypeAO", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryGrade", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField1", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField2", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField3", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField4", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField5", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPaidInsuranceForPayrollItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBornLeave", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxDepartmentName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TreasuryName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false }
                };
            foreach (var column in columnsCollection)
            {
                if (column.ColumnVisible)
                {
                    LookUpAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    LookUpAccount.Properties.SortColumnIndex = column.ColumnPosition;
                    LookUpAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                }
                else
                {
                    LookUpAccount.Properties.Columns[column.ColumnName].Visible = false;
                }
            }
            LookUpAccount.Properties.DisplayMember = "AccountingObjectCode";
            LookUpAccount.Properties.ValueMember = "AccountingObjectId";

        }
        private void EnableChekEdit(AccountModel accountModel)
        {
            if (accountModel == null)
            {
                chkCustomer.Enabled = false;
                chkVendor.Enabled = false;
                chkEmployee.Enabled = false;
                chkAccountingObject.Enabled = false;
                chkCurrency.Enabled = false;
                chkBudgetSource.Enabled = false;
                chkExpend.Enabled = false;
                chkProject.Enabled = false;
                chkContract.Enabled = false;
                chkBudgetChapter.Enabled = false;
                chkBudgetCategory.Enabled = false;
                chkBudgetItem.Enabled = false;
                chkBank.Enabled = false;
                chkInventoryItem.Enabled = false;
                chkFixedAsset.Enabled = false;
                chkWork.Enabled = false;
                chkCapitalPlan.Enabled = false;
            }
            else
            {
                chkCustomer.Enabled = accountModel.DetailByAccountingObject;
                chkVendor.Enabled = accountModel.DetailByAccountingObject;
                chkEmployee.Enabled = accountModel.DetailByAccountingObject;
                chkAccountingObject.Enabled = accountModel.DetailByAccountingObject;
                chkCurrency.Enabled = accountModel.DetailByCurrency;
                chkBudgetSource.Enabled = accountModel.DetailByBudgetSource;
                chkExpend.Enabled = accountModel.DetailByExpense;
                chkProject.Enabled = accountModel.DetailByProject;
                chkContract.Enabled = accountModel.DetailByContract;
                chkBudgetChapter.Enabled = accountModel.DetailByBudgetChapter;
                chkBudgetCategory.Enabled = accountModel.DetailByBudgetKindItem;
                chkBudgetItem.Enabled = accountModel.DetailByBudgetItem;
                chkBank.Enabled = accountModel.DetailByBankAccount;
                chkInventoryItem.Enabled = accountModel.DetailByInventoryItem;
                chkFixedAsset.Enabled = accountModel.DetailByFixedAsset;
                chkWork.Enabled = true;
                chkCapitalPlan.Enabled = accountModel.DetailByCapitalPlan;
            }
            chkCustomer.Checked = false;
            chkVendor.Checked = false;
            chkEmployee.Checked = false;
            chkAccountingObject.Checked = false;
            chkCurrency.Checked = false;
            chkBudgetSource.Checked = false;
            chkExpend.Checked = false;
            chkProject.Checked = false;
            chkContract.Checked = false;
            chkBudgetChapter.Checked = false;
            chkBudgetCategory.Checked = false;
            chkBudgetItem.Checked = false;
            chkBank.Checked = false;
            chkInventoryItem.Checked = false;
            chkFixedAsset.Checked = false;
            chkWork.Checked = false;
            chkCapitalPlan.Checked = false;
        }
        private void grdLookUpAccount_EditValueChanged(object sender, EventArgs e)
        {
            AccountModel account = null;
            if (grdLookUpAccount.EditValue != null)
            {
                account = AccoutsCurrents.FirstOrDefault(o => o.AccountNumber == grdLookUpAccount.EditValue.ToString());
            }
            EnableChekEdit(account);
        }
        protected override bool ValidData()
        {
            if (grdLookUpAccount.EditValue == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn tài khoản", @"Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                grdLookUpAccount.Focus();
                return false;
            }
            return true;
        }
     
    }

}
