using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmS27 : FrmXtraBaseParameter, IBudgetSourcesView, IAccountsView, IProjectsView
    {
        #region Variables
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();

        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>The selection.</value>
        internal GridCheckMarksSelection Selection { get; private set; }
        public string BudgetSourceCode
        {
            get
            {
                var sBudgetSourceCode = Convert.ToString(checkcboBudgetSource.EditValue);
                if (string.IsNullOrEmpty(sBudgetSourceCode) ||
                    sBudgetSourceCode.Contains("<<Tổng hợp>>") ||
                    sBudgetSourceCode.Contains("<<Tất cả>>"))
                {
                    return null;
                }
                else
                {
                    sBudgetSourceCode = sBudgetSourceCode.Replace(",,", "");
                    if (sBudgetSourceCode == ", ") sBudgetSourceCode = null;
                    return sBudgetSourceCode;
                }
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

        public string AccountNumber
        {
            get { return cbxAccount.EditValue.ToString(); }
        }

        public string ProjectIdList
        {
            get
            {
                var selectInventoryItem = "";
                //if (Selection.IsSelectedAll)
                 //   return selectInventoryItem;
                if (Selection.SelectedCount > 0)
                {
                    for (int i = 0; i < gridProjectView.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            selectInventoryItem += (selectInventoryItem != "") ? "," + gridProjectView.GetRowCellValue(i, "ProjectId") : "" + gridProjectView.GetRowCellValue(i, "ProjectId");
                        }
                    }
                }
                if (selectInventoryItem != "")
                    selectInventoryItem += ',';
                if (string.IsNullOrEmpty(selectInventoryItem))
                    return null;
                return selectInventoryItem;
            }
        }
        #endregion

        #region Presenters

        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly ProjectsPresenter _projectsPresenter; 
        #endregion

        public FrmS27()
        {
            InitializeComponent();            
            _projectsPresenter = new ProjectsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
        }

        #region IViews
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                var result = new List<BudgetSourceModel>
                {
                    new BudgetSourceModel {BudgetSourceCode = "<<Tổng hợp>>", BudgetSourceName = "<<Tổng hợp>>"},
                    new BudgetSourceModel {BudgetSourceCode = "<<Tất cả>>", BudgetSourceName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                checkcboBudgetSource.Properties.DataSource = result;

                //cboBudgetSource.Properties.ForceInitialize();
                //cboBudgetSource.Properties.PopulateColumns();
                //var columnsCollection = new List<XtraColumn>();
                //columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "BudgetSourceCode",
                //    ColumnCaption = "Mã nguồn vốn",
                //    ColumnPosition = 1,
                //    ColumnVisible = false,
                //    ColumnWith = 100
                //});
                //columnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "BudgetSourceName",
                //    ColumnPosition = 2,
                //    ColumnCaption = "Tên nguồn vốn",
                //    ColumnVisible = true,
                //    ColumnWith = 250
                //});
                //columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "IsSavingExpenses", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceProperty", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "BankAccountId", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "PayableBankAccountId", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "IsSelfControl", ColumnVisible = false });
                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        cboBudgetSource.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        cboBudgetSource.Properties.SortColumnIndex = column.ColumnPosition;
                //    }
                //    else
                //        cboBudgetSource.Properties.Columns[column.ColumnName].Visible = false;
                //}

                checkcboBudgetSource.Properties.DisplayMember = "BudgetSourceName";
                checkcboBudgetSource.Properties.ValueMember = "BudgetSourceId";
            }
        }

        public IList<AccountModel> Accounts
        {
            set
            {
                var result = new List<AccountModel>
                {
                    //new AccountModel {  AccountNumber = "<<Tất cả>>", AccountName = "<<Tất cả>>"}
                };

                //result.AddRange(value.Where(v => v.AccountNumber == "331" || v.AccountNumber == "131").ToList());
                // Tài khoản phải cho hiện tài khoản 131, 331 và các tk con
                //var acount241 = value.FirstOrDefault(m => m.AccountNumber.Equals("241"));
                //var acount243 = value.FirstOrDefault(m => m.AccountNumber.Equals("243"));
                //if (acount241 != null)
                //{
                //    result.AddRange(value.Where(v => v.AccountNumber.Equals(acount241.AccountNumber)).ToList());
                //    result.AddRange(value.Where(v => (v.ParentId ?? string.Empty).Equals(acount241.AccountId))
                //        .ToList());
                //}
                //if (acount243 != null)
                //{
                //    result.AddRange(value.Where(v => v.AccountNumber.Equals(acount243.AccountNumber)).ToList());
                //    result.AddRange(value.Where(v => (v.ParentId ?? string.Empty).Equals(acount243.AccountId))
                //        .ToList());
                //}
                result.AddRange(value.Where(v => v.AccountNumber.Contains("241")).ToList());
                result.AddRange(value.Where(v => v.AccountNumber.Contains("243")).ToList());
                cbxAccount.Properties.DataSource = result;
                cbxAccount.Properties.ForceInitialize();
                cbxAccount.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn {ColumnName = "AccountId", ColumnVisible = false});
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
                columnsCollection.Add(new XtraColumn {ColumnName = "AccountCategoryId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "AccountCategoryKind", ColumnVisible = false,});
                columnsCollection.Add(new XtraColumn {ColumnName = "ParentId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "AccountForeignName", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Description", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByBudgetSource", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByBudgetChapter", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByBudgetKindItem", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByBudgetItem", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByBudgetSubItem", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByMethodDistribute", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByAccountingObject", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByActivity", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByProject", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByTask", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailBySupply", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByInventoryItem", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByFixedAsset", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByFund", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByBankAccount", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByProjectActivity", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DetailByInvestor", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Grade", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsParent", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsActive", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsDisplayOnAccountBalanceSheet",
                    ColumnVisible = false
                });
                columnsCollection.Add(new XtraColumn {ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false});

                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        cbxAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        cbxAccount.Properties.SortColumnIndex = column.ColumnPosition;
                //    }
                //    else
                //        cbxAccount.Properties.Columns[column.ColumnName].Visible = false;
                //}

                ShowXtraColumnInLookUpEdit<AccountModel>(columnsCollection, cbxAccount);

                cbxAccount.Properties.DisplayMember = "AccountNumber";
                cbxAccount.Properties.ValueMember = "AccountNumber";
            }
        }

        public IList<ProjectModel> Projects
        {
            set
            {
                    bindingSource.DataSource = value;
                gridProjectControl.DataSource = value;
                    gridProjectView.PopulateColumns(value);

                //bindingSource.DataSource = value;
                //gridProjectView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectCode",
                    ColumnCaption = "Mã dự án",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectName",
                    ColumnCaption = "Tên dự án",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectBanks", ColumnVisible = false });

                if (ColumnsCollection == null) return;
                foreach (var column in ColumnsCollection)
                {
                    if (gridProjectView.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {

                            gridProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridProjectView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            gridProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                            gridProjectView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            gridProjectView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            gridProjectView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            gridProjectView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            gridProjectView.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;
                        }
                        else
                            gridProjectView.Columns[column.ColumnName].Visible = false;
                    }

                }
            }
        }
        #endregion

        #region Events

        private void FrmS27_Load(object sender, EventArgs e)
        {
            _accountsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _projectsPresenter.DisplayActive();
            checkcboBudgetSource.EditValue = "<<Tổng hợp>>";            
            cbxAccount.ItemIndex = 6;
            Selection = new GridCheckMarksSelection(gridProjectView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            dateTimeRangeV1.cboDateRange.SelectedItem = GlobalVariable.DateRangeSelected;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
            gridProjectView.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridProjectView.OptionsSelection.EnableAppearanceFocusedCell = false;
        } 
        #endregion
    }
}
