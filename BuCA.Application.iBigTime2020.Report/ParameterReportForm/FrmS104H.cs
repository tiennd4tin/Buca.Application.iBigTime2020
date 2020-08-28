/***********************************************************************
 * <copyright file="FrmS101H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Friday, March 30, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSourceCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS101H.
    /// </summary>
    public partial class FrmS104H : FrmXtraBaseParameter, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, IProjectsView, IBudgetSourceCategoriesView
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
        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        /// <summary>
        /// The _projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;
        /// <summary>
        /// The _budget source category model
        /// </summary>
        private readonly BudgetSourceCategoriesPresenter _budgetSourceCategoriesPresenter;

        #endregion

        #region Repository
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        private GridView _gridLookUpEditBudgetChapterView;

        #endregion

        #region Variable

        private List<BudgetChapterModel> _budgetChapterModel;
        private List<BudgetSourceModel> _budgetSourceModel;
        private List<BudgetKindItemModel> _budgetKindItemModel;
        private List<ProjectModel> _projectModel;
        private List<BudgetSourceCategoryModel> _budgetSourceCategoryModel;


        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>The selection.</value>
        internal GridCheckMarksSelection Selection { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget source.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget source; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetSource
        {
            get
            {
                if (cboBudgetSource.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public string StartDate
        {
            get { return GlobalVariable.StartedDate; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget chapter.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget chapter; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetChapter
        {
            get
            {
                if (cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is summary project.
        /// </summary>
        /// <value><c>true</c> if this instance is summary project; otherwise, <c>false</c>.</value>
        public bool IsSummaryProject
        {
            get
            {
                if (cboProject.EditValue.ToString() == "00000000-0000-0000-0000-000000000000")
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is summary project category.
        /// </summary>
        /// <value><c>true</c> if this instance is summary project category; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetSourceCategory
        {
            get
            {
                if (cboBudgetSourceCategory.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget sub kind item.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget sub kind item; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetSubKindItem
        {
            get
            {
                if (cboBudgetKindItem.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>The budget source code.</value>
        public string BudgetSourceCode
        {
            get
            {
                if (cboBudgetSource.EditValue.ToString() == "<<Tổng hợp>>" || cboBudgetSource.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                return cboBudgetSource.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode
        {
            get
            {
                if ((cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>") || cboBudgetChapter.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                return cboBudgetChapter.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>The budget kind item code.</value>
        public string BudgetKindItemCode
        {
            get
            {
                if (cboBudgetKindItem.EditValue.ToString() == "<<Tổng hợp>>" || cboBudgetKindItem.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                return cboBudgetKindItem.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets the budget expend.
        /// </summary>
        /// <value>The budget expend.</value>
        public string BudgetExpend
        {
            get
            {
                if ((cboBudgetSourceCategory.EditValue.ToString() == "<<Tổng hợp>>") || (cboBudgetSourceCategory.EditValue.ToString() == "<<Tất cả>>"))
                {
                    return null;
                }
                return cboBudgetSourceCategory.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets the budget item list.
        /// </summary>
        /// <value>The budget item list.</value>
        public string BudgetItemList
        {
            get
            {
                var budgetItemCodes = GetBudgetItems();
                if (budgetItemCodes == ";")
                    return null;
                return budgetItemCodes;
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

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <value>The project code.</value>
        public string ProjectCode
        {
            get
            {
                if ((cboProject.EditValue.ToString() == "00000000-0000-0000-0000-000000000000") || cboProject.EditValue.ToString() == "00000000-0000-0000-0000-000000000001")
                {
                    return null;
                }
                return cboProject.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets the budget source category.
        /// </summary>
        /// <value>The budget source category.</value>
        public string BudgetSourceCategory
        {
            get
            {
                string budgetSourceCategory = "";
                if ((cboBudgetSourceCategory.EditValue.ToString() == "<<Tổng hợp>>") || cboBudgetSourceCategory.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                if (cboBudgetSourceCategory.Text.Trim() == "Kinh phí thường xuyên")
                    budgetSourceCategory = "2";
                if (cboBudgetSourceCategory.Text.Trim() == "Kinh phí không thường xuyên")
                    budgetSourceCategory = "3";

                return budgetSourceCategory;
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS101H"/> class.
        /// </summary>
        public FrmS104H()
        {
            InitializeComponent();
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetSourceCategoriesPresenter = new BudgetSourceCategoriesPresenter(this);
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                _budgetSourceModel = value.ToList();
                var result = new List<BudgetSourceModel>
                {
                    new BudgetSourceModel {BudgetSourceCode = "<<Tổng hợp>>", BudgetSourceName = "<<Tổng hợp>>"},
                    new BudgetSourceModel {BudgetSourceCode = "<<Tất cả>>", BudgetSourceName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboBudgetSource.Properties.DataSource = result;
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
                cboBudgetSource.Properties.ValueMember = "BudgetSourceCode";
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
                _budgetChapterModel = value.ToList();

                var result = new List<BudgetChapterModel>
                {
                    new BudgetChapterModel {BudgetChapterCode = "<<Tổng hợp>>", BudgetChapterName = "<<Tổng hợp>>"},
                    new BudgetChapterModel {BudgetChapterCode = "<<Tất cả>>", BudgetChapterName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboBudgetChapter.Properties.DataSource = result;
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
                        cboBudgetChapter.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetChapter.Properties.DisplayMember = "BudgetChapterCode";
                cboBudgetChapter.Properties.ValueMember = "BudgetChapterCode";
            }
        }

        /// <summary>
        /// Sets the budget kind items.
        /// </summary>
        /// <value>The budget kind items.</value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                _budgetKindItemModel = value.ToList();
                var result = new List<BudgetKindItemModel>
                {
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tổng hợp>>", BudgetKindItemName = "<<Tổng hợp>>"},
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tất cả>>", BudgetKindItemName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboBudgetKindItem.Properties.DataSource = result;
                cboBudgetKindItem.Properties.ForceInitialize();
                cboBudgetKindItem.Properties.PopulateColumns();
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
                        cboBudgetKindItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetKindItem.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetKindItem.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                cboBudgetKindItem.Properties.ValueMember = "BudgetKindItemCode";
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
                var budgetItems = value.Where(x => x.BudgetItemCode.StartsWith("5") || x.BudgetItemCode.StartsWith("6") || x.BudgetItemCode.StartsWith("7") || x.BudgetItemCode.StartsWith("8") || x.BudgetItemCode.StartsWith("9"));
                bindingSource.DataSource = budgetItems ?? new List<BudgetItemModel>();
                gridViewBudgetItem.PopulateColumns(budgetItems);
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mã Mục",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemName",
                    ColumnCaption = "Tên Mục",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 550
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                gridViewBudgetItem = InitGridLayout(columnsCollection, gridViewBudgetItem);
                gridViewBudgetItem.OptionsView.ShowFooter = false;
            }
        }

        /// <summary>
        /// Gets the budget items.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetBudgetItems()
        {
            string budgetItems = ",";

            if (gridViewBudgetItem.DataSource != null && gridViewBudgetItem.RowCount > 0)
            {
                for (var i = 0; i < gridViewBudgetItem.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (BudgetItemModel)gridViewBudgetItem.GetRow(i);
                        budgetItems = budgetItems  + row.BudgetItemCode + ",";
                    }
                }
            }
            return budgetItems;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rndOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void rndOption_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (rndOption.SelectedIndex == 0)
            {
                cboBudgetSource.EditValue = @"<<Tất cả>>";
                cboBudgetChapter.EditValue = @"<<Tất cả>>";
                cboBudgetSourceCategory.EditValue = @"<<Tất cả>>";
                cboBudgetKindItem.EditValue = @"<<Tất cả>>";
                cboProject.EditValue = "00000000-0000-0000-0000-000000000001";
                cboBudgetSourceCategory.EditValue = @"<<Tất cả>>";
            }
            else
            {
                if (rndOption.SelectedIndex == 1)
                {
                    cboBudgetSource.EditValue = @"<<Tổng hợp>>";
                    cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
                    cboBudgetSourceCategory.EditValue = @"<<Tổng hợp>>";
                    cboBudgetKindItem.EditValue = @"<<Tổng hợp>>";
                    cboProject.EditValue = "00000000-0000-0000-0000-000000000000";
                    cboBudgetSourceCategory.EditValue = @"<<Tổng hợp>>";
                }
                else
                {
                    cboBudgetSource.EditValue = "";
                    cboBudgetChapter.EditValue = "";
                    cboBudgetSourceCategory.EditValue = "";
                    cboBudgetKindItem.EditValue = "";
                    cboProject.EditValue = "";
                    cboBudgetSourceCategory.EditValue = "";
                }
            }
        }

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>GridView.</returns>
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

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public IList<ProjectModel> Projects
        {
            set
            {
                _projectModel = value.ToList();
                var result = new List<ProjectModel>
                    {
                        new ProjectModel {ProjectId = "00000000-0000-0000-0000-000000000000", ProjectCode = "<<Tổng hợp>>", ProjectName = "<<Tổng hợp>>"},
                        new ProjectModel {ProjectId = "00000000-0000-0000-0000-000000000001", ProjectCode = "<<Tất cả>>", ProjectName = "<<Tất cả>>"}

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
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
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
                cboProject.Properties.ValueMember = "ProjectId";
            }
        }

        /// <summary>
        /// Sets the budget source categories.
        /// </summary>
        /// <value>The budget source categories.</value>
        public IList<BudgetSourceCategoryModel> BudgetSourceCategories
        {
            set
            {
                _budgetSourceCategoryModel = value.Where(c => c.BudgetSourceCategoryCode.Contains("01") || c.BudgetSourceCategoryCode.Contains("02")).ToList();
                var result = new List<BudgetSourceCategoryModel>
                {
                    new BudgetSourceCategoryModel {BudgetSourceCategoryId = "00000000-0000-0000-0000-000000000000", BudgetSourceCategoryCode = "<<Tổng hợp>>", BudgetSourceCategoryName = "<<Tổng hợp>>"},
                    new BudgetSourceCategoryModel {BudgetSourceCategoryId = "00000000-0000-0000-0000-000000000001", BudgetSourceCategoryCode = "<<Tất cả>>", BudgetSourceCategoryName = "<<Tất cả>>"},
                    new BudgetSourceCategoryModel {BudgetSourceCategoryId = "00000000-0000-0000-0000-000000000002", BudgetSourceCategoryCode = "0", BudgetSourceCategoryName = "Kinh phí thường xuyên"},
                    new BudgetSourceCategoryModel {BudgetSourceCategoryId = "00000000-0000-0000-0000-000000000003", BudgetSourceCategoryCode = "1", BudgetSourceCategoryName = "Kinh phí không thường xuyên"}
                };
                //result.AddRange(value.Where(c => c.BudgetSourceCategoryCode.Contains("01") || c.BudgetSourceCategoryCode.Contains("02")).ToList());
                cboBudgetSourceCategory.Properties.DataSource = result;
                cboBudgetSourceCategory.Properties.ForceInitialize();
                cboBudgetSourceCategory.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCategoryCode",
                    ColumnCaption = "Mã loại nguồn vốn",
                    ColumnPosition = 1,
                    ColumnVisible = false,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCategoryName",
                    ColumnPosition = 2,
                    ColumnCaption = "Tên loại nguồn vốn",
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetSourceCategory.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetSourceCategory.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetSourceCategory.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetSourceCategory.Properties.DisplayMember = "BudgetSourceCategoryName";
                cboBudgetSourceCategory.Properties.ValueMember = "BudgetSourceCategoryCode";
            }
        }

        /// <summary>
        /// Handles the Load event of the FrmS101HPartII control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmS101HPartII_Load(object sender, EventArgs e)
        {
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _budgetSourceCategoriesPresenter.DisplayActive();

            cboBudgetSource.EditValue = @"<<Tổng hợp>>";
            cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
            cboBudgetKindItem.EditValue = @"<<Tổng hợp>>";
            
            cboBudgetSourceCategory.EditValue = @"<<Tổng hợp>>";
            cboProject.EditValue = "00000000-0000-0000-0000-000000000000";
            cboBudgetSourceCategory.EditValue = @"<<Tổng hợp>>";
            Selection = new GridCheckMarksSelection(gridViewBudgetItem);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            gridViewBudgetItem.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridViewBudgetItem.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
