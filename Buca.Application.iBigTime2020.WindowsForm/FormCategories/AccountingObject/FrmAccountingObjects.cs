using System.Collections.Generic;
using System.Drawing;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject
{
    /// <summary>
    /// Class FrmAccountingCategories.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseList" />
    public partial class FrmAccountingObjects : FrmBaseList, IAccountingObjectsView, IAccountingObjectCategoriesView
    {
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly AccountingObjectCategoriesPresenter _accountingObjectCategoriesPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObjectCategories;
        private GridView _gridLookUpEditAccountingObjectCategoriesView;

        #region event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAccountingObjects"/> class.
        /// </summary>
        public FrmAccountingObjects()
        {
            InitializeComponent();
            //InitRepositoryControlData();
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _accountingObjectCategoriesPresenter = new AccountingObjectCategoriesPresenter(this);
        }

        #endregion

        #region properties

        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectBanks", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã đối tượng", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 20});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectName", ColumnCaption = "Tên đối tượng", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150 });
            
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCategoryId", ColumnCaption = "Loại đối tượng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 80, RepositoryControl = _gridLookUpEditAccountingObjectCategories});

                ColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Tel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Fax", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Website", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CompanyTaxCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AreaCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactTitle", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactSex", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactMobile", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactEmail", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactOfficeTel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactHomeTel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactAddress", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsPersonal", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IdentificationNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IssueDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IssueBy", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryScaleId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Insured", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "LabourUnionFee", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FamilyDeductionAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsCustomerVendor", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryCoefficient", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "NumberFamilyDependent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryForm", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryPercentRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsPayInsuranceOnSalary", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InsuranceAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsUnEmploymentInsurance", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeAO", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryGrade", ColumnVisible = false }); 
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField1", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField2", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField3", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField4", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField5", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsPaidInsuranceForPayrollItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsBornLeave", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TaxDepartmentName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 20 });
            }
        }

        #endregion

        #region override methods

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _accountingObjectCategoriesPresenter.Display();
            _accountingObjectsPresenter.DisplayByIsEmployee(false);
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new AccountingObjectPresenter(null).Delete(PrimaryKeyValue);
        }

        #endregion

        #region IView
        public IList<AccountingObjectCategoryModel> AccountingObjectCategories
        {
            set
            {
                _gridLookUpEditAccountingObjectCategoriesView = new GridView();
                _gridLookUpEditAccountingObjectCategoriesView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpEditAccountingObjectCategories = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditAccountingObjectCategoriesView,
                    TextEditStyle = TextEditStyles.Standard,
                };
                _gridLookUpEditAccountingObjectCategories.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditAccountingObjectCategories.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditAccountingObjectCategories.PopupFormSize = new Size(368, 150);
                _gridLookUpEditAccountingObjectCategories.View.BestFitColumns();

                _gridLookUpEditAccountingObjectCategories.DataSource = value;
                _gridLookUpEditAccountingObjectCategoriesView.PopulateColumns(value);

                var gridColumnsCollection = new List<XtraColumn>();
                
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectCategoryCode",
                    ColumnCaption = "Mã loại đối tượng",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnPosition = 1
                });
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectCategoryName",
                    ColumnCaption = "Tên loại đối tượng",
                    ColumnVisible = true,
                    ColumnWith = 250,
                    ColumnPosition = 2
                });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCategoryId", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });

                XtraColumnCollectionHelper<AccountingObjectCategoryModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountingObjectCategoriesView);
                _gridLookUpEditAccountingObjectCategories.DisplayMember = "AccountingObjectCategoryName";
                _gridLookUpEditAccountingObjectCategories.ValueMember = "AccountingObjectCategoryId";
            }
        }
        #endregion
    }
}
