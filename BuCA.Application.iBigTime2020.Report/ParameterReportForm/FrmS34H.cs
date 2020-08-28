using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory;
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
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmS34H : FrmXtraBaseParameter, IAccountsView, IAccountingObjectsView, IAccountingObjectCategoriesView
    {
        internal GridCheckMarksSelection Selection { get; private set; }
        private readonly AccountsPresenter _accountsPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly AccountingObjectCategoriesPresenter _accountingObjectCategoriesPresenter;
        public string ProjectIdList { get; set; }

        #region Variable

        public string AccountNumber
        {
            get
            {
                if (cboAccount.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                else
                    return cboAccount.EditValue.ToString();
            }
        }

        public string CorrespondingAccount
        {
            get
            {
                return cboCorrespondingAccount.EditValue == null ? null : cboCorrespondingAccount.EditValue.ToString();
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
        public string StartDate
        {
            get { return GlobalVariable.StartedDate; }
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

        public bool pGroupTheSameItem
        {
            get { return chkGroupTheSameItem.Checked; }
        }
        public bool IsDetail { get { return ckbDetail.Checked; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS03H"/> class.
        /// </summary>

        public FrmS34H()
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _accountingObjectCategoriesPresenter = new AccountingObjectCategoriesPresenter(this);
        }

        #region IView


        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                var result = new List<AccountModel>
                {
                    new AccountModel {  AccountNumber = "<<Tất cả>>", AccountName = "<<Tất cả>>"}
                };

                ////result.AddRange(value.Where(v => v.AccountNumber == "331" || v.AccountNumber == "131").ToList());
                //// Tài khoản phải cho hiện tài khoản 131, 331 và các tk con
                //var acount131 = value.FirstOrDefault(m => m.AccountNumber.Equals("131"));
                //var acount331 = value.FirstOrDefault(m => m.AccountNumber.Equals("331"));
                //if (acount131 != null)
                //{
                //    result.AddRange(value.Where(v => v.AccountNumber.Equals(acount131.AccountNumber)).ToList());
                //    result.AddRange(value.Where(v => (v.ParentId ?? string.Empty).Equals(acount131.AccountId)).ToList());
                //}
                //if (acount331 != null)
                //{
                //    result.AddRange(value.Where(v => v.AccountNumber.Equals(acount331.AccountNumber)).ToList());
                //    result.AddRange(value.Where(v => (v.ParentId ?? string.Empty).Equals(acount331.AccountId)).ToList());
                //}

                //cboAccount.Properties.DataSource = GetChildByParentIDs(value.Where(p => p.AccountNumber.Equals("131") || p.AccountNumber.Equals("331")).ToList(), value.Where(p => !string.IsNullOrEmpty(p.ParentId)).ToList()).OrderBy(o => o.AccountNumber).ToList() ;
                
                result.AddRange(value.Where(p => p.AccountNumber.StartsWith("131") || p.AccountNumber.StartsWith("138") || p.AccountNumber.StartsWith("331") || p.AccountNumber.StartsWith("338")).ToList());
                cboAccount.Properties.DataSource = result;
                cboAccount.Properties.ForceInitialize();
                cboAccount.Properties.PopulateColumns();
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
                    ColumnCaption = "Tên tài khoản",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false, });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
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

                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        cboAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        cboAccount.Properties.SortColumnIndex = column.ColumnPosition;
                //    }
                //    else
                //        cboAccount.Properties.Columns[column.ColumnName].Visible = false;
                //}

                ShowXtraColumnInLookUpEdit<AccountModel>(columnsCollection, cboAccount);

                cboAccount.Properties.DisplayMember = "AccountNumber";
                cboAccount.Properties.ValueMember = "AccountNumber";

                //
                cboCorrespondingAccount.Properties.DataSource = value.Where(p=>!p.AccountNumber.StartsWith("0")).ToList();
                cboCorrespondingAccount.Properties.ForceInitialize();
                cboCorrespondingAccount.Properties.PopulateColumns();
                cboCorrespondingAccount.Properties.DisplayMember = "AccountNumber";
                cboCorrespondingAccount.Properties.ValueMember = "AccountNumber";
                ShowXtraColumnInLookUpEdit<AccountModel>(columnsCollection, cboCorrespondingAccount);
            }
        }

        public IList<AccountingObjectCategoryModel> AccountingObjectCategories
        {
            set
            {
                var result = new List<AccountingObjectCategoryModel>
                {
                    new AccountingObjectCategoryModel { AccountingObjectCategoryId="ALL",  AccountingObjectCategoryCode = "<<Tất cả>>", AccountingObjectCategoryName = "<<Tất cả>>" }
                };
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectCategoryCode",
                    ColumnCaption = "Mã đối tượng",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectCategoryName",
                    ColumnCaption = "Tên đối tượng",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                result.AddRange(value);
                cboAccountingObjectCategory.Properties.DataSource = result;
                cboAccountingObjectCategory.Properties.ForceInitialize();
                cboAccountingObjectCategory.Properties.PopulateColumns();
                cboAccountingObjectCategory.Properties.DisplayMember = "AccountingObjectCategoryName";
                cboAccountingObjectCategory.Properties.ValueMember = "AccountingObjectCategoryId";
                ShowXtraColumnInLookUpEdit<AccountingObjectCategoryModel>(columnsCollection, cboAccountingObjectCategory);
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã đối tượng", ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectName", ColumnCaption = "Tên đối tượng", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 120 });

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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false });
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
            _accountsPresenter.Display();
            _accountingObjectsPresenter.Display();
            _accountingObjectCategoriesPresenter.Display();
            cboAccount.Text = "<<Tất cả>>";
            cboAccountingObjectCategory.EditValue = "ALL";
            Selection = new GridCheckMarksSelection(gridviewAccountingObject);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedCell = false;

            gridviewAccountingObject.OptionsView.ShowGroupPanel = false;
            gridviewAccountingObject.OptionsView.ShowIndicator = false;

            dateTimeRangeV1.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
        }

        private string GetClause()
        {
            string Clause = "";

            if (gridviewAccountingObject.DataSource != null && gridviewAccountingObject.RowCount > 0)
            {
                for (var i = 0; i < gridviewAccountingObject.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (AccountingObjectModel)gridviewAccountingObject.GetRow(i);
                        Clause = Clause + row.AccountingObjectId.ToUpper() + ";";
                    }
                }
            }
            return Clause;
        }

        private void cboAccountingObjectCategory_EditValueChanged(object sender, EventArgs e)
        {
            var dt = ((AccountingObjectCategoryModel)cboAccountingObjectCategory.GetSelectedDataRow()).AccountingObjectCategoryCode;
            switch (dt)
            {
                case "NCC":
                    {
                        cboAccount.EditValue = "331";
                        break;
                    }
                case "KH":
                    {
                        cboAccount.EditValue = "131";
                        break;
                    }
                default:
                    cboAccount.EditValue = "<<Tất cả>>";
                    break;
            }
            var _accountingObjectCategoryId = (string)cboAccountingObjectCategory.EditValue;
            List<AccountingObjectModel> _ListObjs = new List<AccountingObjectModel>();
            foreach (var item in bindingSource.Cast<AccountingObjectModel>().Where(p =>(_accountingObjectCategoryId== "ALL" || p.AccountingObjectCategoryId == _accountingObjectCategoryId) && !string.IsNullOrEmpty(p.AccountingObjectCategoryId) ).ToList())
            {
                AccountingObjectModel _obj = new AccountingObjectModel();

                foreach (PropertyInfo info in item.GetType().GetProperties())
                {
                    info.SetValue(_obj, info.GetValue(item, null), null);
                }
                _ListObjs.Add(_obj);
            }
            grdAccountingObject.DataSource = null;
            grdAccountingObject.DataSource = _ListObjs;
            grdAccountingObject.Refresh();
            gridviewAccountingObject.RefreshData();
        }

        private void btChooseProject_Click(object sender, EventArgs e)
        {
            FrmGetProject frm = new FrmGetProject();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ProjectIdList = frm.ListProjectId;
                //ProjectList = frm.ProjectIdList;
                frm.Close();
            }
        }

        public static List<AccountModel> GetChildByParentIDs(List<AccountModel> _Parents, List<AccountModel> _objs)
        {
            bool f = true;
            List<AccountModel> _ls = new List<AccountModel>(_objs.Where(p => _Parents.Any(n => n.AccountId == p.ParentId)).ToList());
            foreach(var p in _Parents)
            {
                _ls.Add(p);
            }
            List<AccountModel> _childs = new List<AccountModel>(_objs.Where(p => _Parents.Any(n => n.AccountId == p.ParentId)).ToList());
            while (f)
            {
                f = false;
                _childs = _objs.Where(p => _childs.Any(n => n.AccountId == p.ParentId)).ToList();
                if(_childs.Count>0)
                {
                    foreach(var i in _childs)
                    {
                        _ls.Add(i);
                    }
                    f = true;
                }
            }
            return _ls;
        }
    }
}
