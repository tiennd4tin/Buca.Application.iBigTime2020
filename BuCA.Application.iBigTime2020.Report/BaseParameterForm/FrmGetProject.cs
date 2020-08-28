using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuCA.Application.iBigTime2020.Report.BaseParameterForm
{
    public partial class FrmGetProject : FrmXtraBaseParameter, IProjectsView
    {
        internal GridCheckMarksSelection Selection { get; private set; }
        private readonly ProjectsPresenter _projectsPresenter;
        public string ListProjectId
        {
            get
            {
                var clause = GetListProjectId();
                return clause;
            }
        }
        private string GetListProjectId()
        {

            string Clause = "";

            if (gridviewProject.DataSource != null && gridviewProject.RowCount > 0)
            {
                for (var i = 0; i < gridviewProject.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (ProjectModel)gridviewProject.GetRow(i);
                        Clause = Clause + row.ProjectId.ToUpper() + ";";
                    }
                }
            }
            return Clause;
        }

        public IList<ProjectModel> Projects
        {
            set
            {
                var ColumnsCollection = new List<XtraColumn>();
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense",ColumnVisible = false });
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectBanks", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });

                grdProject.DataSource = value;
                gridviewProject = InitGridLayout(ColumnsCollection, gridviewProject);
                gridviewProject.OptionsView.ShowFooter = false;
            }
        }

        public FrmGetProject()
        {
            InitializeComponent();
            _projectsPresenter = new ProjectsPresenter(this);
        }
        private void FrmGetProject_Load(object sender, EventArgs e)
        {
            _projectsPresenter.Display();
            Selection = new GridCheckMarksSelection(gridviewProject);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            gridviewProject.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridviewProject.OptionsSelection.EnableAppearanceFocusedCell = false;

            gridviewProject.OptionsView.ShowGroupPanel = false;
            gridviewProject.OptionsView.ShowIndicator = false;
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
        
    }
}
