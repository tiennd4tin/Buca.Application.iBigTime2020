/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmEmployees : FrmBaseList, IAccountingObjectsView, IDepartmentsView, IBanksView
    {
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        private GridView _gridLookUpEditDepartmentView;
        private readonly DepartmentsPresenter _departmentsPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;
        private readonly BanksPresenter _banksPresenter;


        /// <summary>
        /// Initializes a new instance of the <see cref="FrmEmployees"/> class.
        /// </summary>
        public FrmEmployees()
        {
            InitializeComponent();
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
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
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã cán bộ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectName", ColumnCaption = "Tên cán bộ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactTitle", ColumnCaption = "Chức danh", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 150, RepositoryControl = _gridLookUpEditDepartment });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số tài khoản", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectBanks", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCategoryId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Tel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Fax", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Website", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CompanyTaxCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AreaCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactName", ColumnVisible = false });
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false });
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
                try
                {
                    _gridLookUpEditDepartmentView = new GridView();
                    _gridLookUpEditDepartmentView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditDepartment = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditDepartmentView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowFooter = false
                    };
                    _gridLookUpEditDepartment.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDepartment.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDepartment.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
                    _gridLookUpEditDepartment.View.OptionsView.ShowColumnHeaders = false;
                    _gridLookUpEditDepartment.View.BestFitColumns();

                    _gridLookUpEditDepartment.DataSource = value;
                    _gridLookUpEditDepartmentView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DepartmentCode",  ColumnVisible = false },
                        new XtraColumn { ColumnName = "DepartmentName", ColumnCaption = "Tên phòng ban", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 320 },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false }
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditDepartment.DisplayMember = "DepartmentName";
                    _gridLookUpEditDepartment.ValueMember = "DepartmentId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>
        /// The banks.
        /// </value>
        public IList<BankModel> Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        #region override methods

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _departmentsPresenter.Display();
            _banksPresenter.Display();
            _accountingObjectsPresenter.DisplayByIsEmployee(true);
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new AccountingObjectPresenter(null).Delete(PrimaryKeyValue);
        }

        #endregion
    }
}
