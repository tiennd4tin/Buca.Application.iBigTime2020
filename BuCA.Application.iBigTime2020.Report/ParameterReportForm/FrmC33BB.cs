using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmC33BB : FrmXtraBaseParameter, IDepartmentsView,IAccountingObjectsView
    {
        internal GridCheckMarksSelection Selection { get; private set; }
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;


        #region Variable
       
        public string DepartmentId
        {
            get
            {
                if (cboDepartment.EditValue.ToString() == "a7f14b9e-71a8-42fd-9cfc-9315e6551a03")
                {
                    return null;
                }
                else
                    return cboDepartment.EditValue.ToString();
            }
        }
  
        public string AccountingObjectList
        {
            get
            {
                var clause = GetClause();
                return clause;
            }
        }

        /// <summary>
        /// Gets from date.
        /// </summary>
        /// <value>From date.</value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }
        /// <summary>
        /// Gets to date.
        /// </summary>
        /// <value>To date.</value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }
        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS03H"/> class.
        /// </summary>
       
        public FrmC33BB()
        {
            InitializeComponent();
            _departmentsPresenter = new DepartmentsPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
        }

        #region IView
       
        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<DepartmentModel> Departments
        {
            set
            {
                var result = new List<DepartmentModel>
                {
                    new DepartmentModel { DepartmentId = "a7f14b9e-71a8-42fd-9cfc-9315e6551a03", DepartmentCode = "<<Tất cả>>", DepartmentName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboDepartment.Properties.DataSource = result;
                cboDepartment.Properties.ForceInitialize();
                cboDepartment.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId",ColumnVisible = false});
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentCode",
                    ColumnCaption = "Mã phòng/ban",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentName",
                    ColumnCaption = "Tên phòng ban",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 200,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnVisible = false,
                    ColumnPosition = 3,
                    ColumnWith = 400,
                    AllowEdit = false,
                    ColumnCaption = @"Diễn giải"
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsActive",
                    ColumnCaption = "Được sử dụng",
                    ColumnVisible = false,
                    ColumnPosition = 4,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Grade",
                    ColumnVisible = false,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsParent",
                    ColumnVisible = false,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ParentId",
                    ColumnVisible = false,
                    AllowEdit = false
                });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboDepartment.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDepartment.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboDepartment.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboDepartment.Properties.DisplayMember = "DepartmentCode";
                cboDepartment.Properties.ValueMember = "DepartmentId";
            }
        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                bindingSource.DataSource = value ?? new List<AccountingObjectModel>();
                gridviewAccountingObject.PopulateColumns(value);
                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectBanks", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã đối tượng", ColumnVisible = true, ColumnWith = 20 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectName", ColumnCaption = "Tên đối tượng", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCategoryId", ColumnVisible = false });
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnVisible = false, ColumnWith = 20 });

                gridviewAccountingObject = InitGridLayout(ColumnsCollection, gridviewAccountingObject);
                gridviewAccountingObject.OptionsView.ShowFooter = false;
            }
        }

        #endregion
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
            {
                if (grdView.Columns[column.ColumnName] != null)
                    if (column.ColumnVisible)
                    {
                        grdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        grdView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        grdView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        grdView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        grdView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        grdView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                        if (column.IsSummaryText)
                        {
                            grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = @"Tổng cộng";
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
            }
            return grdView;
        }

        private void FrmS03H_Load(object sender, EventArgs e)
        {
            _departmentsPresenter.Display();
            _accountingObjectsPresenter.Display();
            cboDepartment.Text = "<<Tất cả>>";
            Selection = new GridCheckMarksSelection(gridviewAccountingObject);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private string GetClause()
        {
            string Clause = ",";

            if (gridviewAccountingObject.DataSource != null && gridviewAccountingObject.RowCount > 0)
            {
                for (var i = 0; i < gridviewAccountingObject.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (AccountingObjectModel)gridviewAccountingObject.GetRow(i);
                            Clause = Clause + row.AccountingObjectId + ",";
                    }
                }
            }
            return Clause;
        }

        private void cboDepartment_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartment.EditValue != "a7f14b9e-71a8-42fd-9cfc-9315e6551a03")
            {
                _accountingObjectsPresenter.DisplayByDepartment(cboDepartment.EditValue.ToString().Trim());
                Selection = new GridCheckMarksSelection(gridviewAccountingObject);
                Selection.CheckMarkColumn.VisibleIndex = 0;
                Selection.CheckMarkColumn.Width = 40;
                gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedRow = true;
                gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedCell = false;
            }
        }
    }
}
