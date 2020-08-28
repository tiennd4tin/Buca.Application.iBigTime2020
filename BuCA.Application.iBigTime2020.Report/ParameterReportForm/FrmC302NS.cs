/***********************************************************************
 * <copyright file="FrmC302NS.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, June 13, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// FrmC302NS
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    public partial class FrmC302NS : FrmXtraBaseParameter, IBudgetChaptersView, IBudgetSourcesView, IBudgetKindItemsView, IBudgetItemsView, IProjectsView
    {
        #region Presenter

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

        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly BanksPresenter _banksPresenter;
        internal GridCheckMarksSelection Selection { get; private set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmC302NS"/> class.
        /// </summary>
        public FrmC302NS()
        {
            InitializeComponent();
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
        }

        #region Variable

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget source.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is summary budget source; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryBudgetSource
        {get;
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public string StartDate
        {
            get { return GlobalVariable.StartedDate; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget chapter.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is summary budget chapter; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryBudgetChapter
        {
            get;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget sub kind item.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is summary budget sub kind item; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryBudgetSubKindItem
        {
            get;
        }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceID
        {
            get;
        }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode
        {
            get;
        }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        /// The budget kind item code.
        /// </value>
        public string BudgetSubKindItemCode
        {
            get;
        }

        /// <summary>
        /// Gets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate.ToShortDateString();
            }
        }
        public int MethodDistributeId
        {
            get;
        }
        /// <summary>
        /// Gets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public string ToDate
        {
            get
            {
                return dateTimeRangeV1.ToDate.ToShortDateString();
            }
        }
        public string ProjectID
        {
            get
            {
                if (
                    cboProject.EditValue.ToString() == "<<Không chọn>>")
                {
                    return null;
                }

                return (string)cboProject.GetColumnValue("ProjectId");
            }
        }
        public string CtmtDaName
        {
            get
            {
                if (
                    cboProject.EditValue.ToString() == "<<Không chọn>>")
                {
                    return null;
                }

                return (string)cboProject.GetColumnValue("ProjectName");
            }
        }
        public string CtmtDaCode
        {
            get
            {
                if (
                      cboProject.EditValue.ToString() == "<<Không chọn>>")
                {
                    return null;
                }

                return (string)cboProject.GetColumnValue("ProjectCode");
            }
        }
        /// <summary>
        /// Gets the inventory item ids.
        /// </summary>
        /// <value>The inventory item ids.</value>
        public string BudgetItemCodeList
        {
            get;set;
        }

        /// <summary>
        /// Kiểu thanh toán
        /// </summary>
        public int PayType
        {
            get;
        }

        /// <summary>
        /// Căn cứ vốn đầu tư số
        /// </summary>
        public string InvestmentNumber
        {
            get { return InvestmentNumbertxt.Text; }
        }

        /// <summary>
        /// Ngay
        /// </summary>
        public DateTime InvestmentDate
        {
            get { return InvestmentDatedtime.Value; }
        }

        /// <summary>
        /// Kế hoạch năm
        /// </summary>
        public string YearPlan
        {
            get { return YearPlannumber.Text; }
        }

        /// <summary>
        /// 0 là tạm ứng sang thực chi, 1 là ứng trước
        /// </summary>
        public bool CheckCashWithDrawTypeOne
        {
            get
            {
                if (ck_CashWithDrawTypeOne.Checked) return true;
                return false;
            }
        }
        public bool CheckCashWithDrawTypeTwo
        {
            get
            {
                if (ck_CashWithDrawTypeTwo.Checked) return true;
                return false;
            }
        }
        public bool PaymentTypeOne
        { 
            get
            {
                if (ck_PaymentTypeOne.Checked) return true;
                return false;
            }
        }
        public bool PaymentTypeTwo
        {
            get
            {
                if (ck_PaymentTypeTwo.Checked) return true;
                return false;
            }
        }
        public bool PaymentTypeThree
        {
            get
            {
                if (ck_PaymentTypeThree.Checked) return true;
                return false;
            }
        }
        public bool PaymentTypeFour
        {
            get
            {
                if (ck_PaymentTypeFour.Checked) return true;
                return false;
            }
        }

        public string CkcHdth { get { return txtCkcHdth.Text; } }
        #endregion

        #region IView Extend

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>
        /// The budget chapters.
        /// </value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            get; set;
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>
        /// The budget sources.
        /// </value>
        public IList<BudgetSourceModel> BudgetSources
        {
            get; set;
        }

        /// <summary>
        /// Sets the budget kind items.
        /// </summary>
        /// <value>
        /// The budget kind items.
        /// </value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            get; set;
        }

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>The BudgetItems.</value>
        public IList<BudgetItemModel> BudgetItems
        {
            get; set;
        }
        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>GridView.</returns>

        public IList<ProjectModel> Projects
        {
            set
            {
                var result = new List<ProjectModel>
                {
                    new ProjectModel {ProjectCode = "<<Không chọn>>", ProjectName = "<<Không chọn>>"}

                };
                result.AddRange(value);
                cboProject.Properties.DataSource = result;
                cboProject.Properties.ForceInitialize();
                cboProject.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectCode",
                    ColumnCaption = "Mã CTMT, dự án",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectName",
                    ColumnCaption = "Tên CTMT, dự án",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboProject.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboProject.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboProject.Properties.Columns[column.ColumnName].Visible = false;
                }

                cboProject.Properties.DisplayMember = "ProjectCode";
                cboProject.Properties.ValueMember = "ProjectCode";
            }
        }


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
        #endregion

        /// <summary>
        /// Handles the Load event of the FrmC302NS control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmC302NS_Load(object sender, EventArgs e)
        {
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            //lookupBudgetSourceKind.EditValue = @"<<Tất cả>>";
            cboProject.EditValue = @"<<Không chọn>>";
          //  Selection.CheckMarkColumn.VisibleIndex = 0;
           // Selection.CheckMarkColumn.Width = 10;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            IsPreviewOrExportXML = false;
            DialogResult = DialogResult.OK;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
