/***********************************************************************
 * <copyright file="FrmF0101BCQT.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, May 24, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Session;
using DateTimeRangeBlockDev.Helper;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmF0101BCQT.
    /// </summary>
    public partial class FrmF0102BCQT : FrmXtraBaseParameter, IBudgetChaptersView, IBudgetSourcesView,
        IBudgetKindItemsView, IProjectsView
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

        private readonly ProjectsPresenter _projectsPresenter;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmF0101BCQT"/> class.
        /// </summary>
        public FrmF0102BCQT()
        {
            InitializeComponent();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
        }

        #region Variable

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget source.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget source; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetSource
        {
            get
            {
                if (cboBudgetSource.EditValue.ToString() == "<<Tổng hợp>>"|| cboBudgetSource.EditValue.ToString() == "<<Tất cả>>")
                    return true;
                else
                    return false;
            }
        }

        public int MethodDistributeId
        {
            get
            {
                if (cboMethod.EditValue.ToString() == "<<Tổng hợp>>" ||
                    cboMethod.EditValue.ToString() == "<<Tất cả>>")
                    return -1;
                return cboMethod.SelectedIndex;
            }
        }

        public bool IsSummaryMethodDistribute
        {
            get
            {
                if (cboMethod.EditValue.ToString() == "<<Tổng hợp>>")
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

        public bool IsSummaryProject
        {
            get
            {
                if (cboProject.EditValue.ToString() == "<<Tổng hợp>>")
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
                if (cboBudgetSubKindItem.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
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
                if (cboBudgetSource.EditValue.ToString() == "<<Tổng hợp>>" ||
                    cboBudgetSource.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }

                return "," + (string) cboBudgetSource.GetColumnValue("BudgetSourceId") + ",";
            }
        }
        public string ProjectID
        {
            get
            {
                if (cboProject.EditValue.ToString() == "<<Tổng hợp>>" ||
                    cboProject.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }

                return (string)cboProject.GetColumnValue("ProjectId");
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
                if ((cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>") ||
                    cboBudgetChapter.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }

                return "," + cboBudgetChapter.EditValue + ",";
            }
        }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>The budget kind item code.</value>
        public string BudgetSubKindItemCode
        {
            get
            {
                if (cboBudgetSubKindItem.EditValue.ToString() == "<<Tổng hợp>>" ||
                    cboBudgetSubKindItem.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }

                return "," + cboBudgetSubKindItem.EditValue + ",";
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

        #region IView Extend

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
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
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetChapterId", ColumnVisible = false});
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
                columnsCollection.Add(new XtraColumn {ColumnName = "IsActive", ColumnVisible = false});

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
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
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
                cboBudgetSource.Properties.DataSource = result;
                cboBudgetSource.Properties.ForceInitialize();
                cboBudgetSource.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false});
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
                columnsCollection.Add(new XtraColumn {ColumnName = "ParentId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsParent", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsActive", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsSavingExpenses", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetSourceCategoryId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetSourceProperty", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BankAccountId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "PayableBankAccountId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsSelfControl", ColumnVisible = false});
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
        /// Sets the budget kind items.
        /// </summary>
        /// <value>The budget kind items.</value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                var result = new List<BudgetKindItemModel>
                {
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tổng hợp>>", BudgetKindItemName = "<<Tổng hợp>>"},
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tất cả>>", BudgetKindItemName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboBudgetSubKindItem.Properties.DataSource = result;
                cboBudgetSubKindItem.Properties.ForceInitialize();
                cboBudgetSubKindItem.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetKindItemId", ColumnVisible = false});
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
                columnsCollection.Add(new XtraColumn {ColumnName = "ParentId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Grade", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsParent", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsActive", ColumnVisible = false});
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetSubKindItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetSubKindItem.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetSubKindItem.Properties.Columns[column.ColumnName].Visible = false;
                }

                cboBudgetSubKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                cboBudgetSubKindItem.Properties.ValueMember = "BudgetKindItemCode";
            }
        }

        public IList<ProjectModel> Projects
        {
            set
            {
                var result = new List<ProjectModel>
                {
                    new ProjectModel {ProjectCode = "<<Tổng hợp>>", ProjectName = "<<Tổng hợp>>"},
                    new ProjectModel {ProjectCode = "<<Tất cả>>", ProjectName = "<<Tất cả>>"}

                };
                result.AddRange(value);
                cboProject.Properties.DataSource = result;
                cboProject.Properties.ForceInitialize();
                cboProject.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false});
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
                columnsCollection.Add(new XtraColumn {ColumnName = "ProjectNumber", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ProjectEnglishName", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BUCACodeID", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "StartDate", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "FinishDate", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ExecutionUnit", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DepartmentID", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "TotalAmountApproved", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ParentID", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Grade", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsParent", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn
                    {ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsActive", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ObjectType", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ContractorID", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ContractorName", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ContractorAddress", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Description", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ProjectSize", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BuildLocation", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "InvestmentClass", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "CDCActivityType", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BankId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Investment", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ObjectTypeName", ColumnVisible = false});
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

        #endregion

        /// <summary>
        /// Handles the Load event of the FrmF0101BCQT control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FrmF0102BCQT_Load(object sender, System.EventArgs e)
        {
            //dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            //dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _projectsPresenter.DisplayActive();
            cboBudgetSource.EditValue = @"<<Tổng hợp>>";
            cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
            cboBudgetSubKindItem.EditValue = @"<<Tổng hợp>>";
            cboProject.EditValue = @"<<Tổng hợp>>";
            cboMethod.EditValue = @"<<Tổng hợp>>";

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
                cboBudgetSubKindItem.EditValue = @"<<Tất cả>>";
                cboProject.EditValue = @"<<Tất cả>>";
                cboMethod.EditValue = @"<<Tất cả>>";
            }
            else
            {
                if (rndOption.SelectedIndex == 1)
                {
                    cboBudgetSource.EditValue = @"<<Tổng hợp>>";
                    cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
                    cboBudgetSubKindItem.EditValue = @"<<Tổng hợp>>";
                    cboProject.EditValue = @"<<Tổng hợp>>";
                    cboMethod.EditValue = @"<<Tổng hợp>>";
                }
                else
                {
                    cboBudgetSource.EditValue = "";
                    cboBudgetChapter.EditValue = "";
                    cboBudgetSubKindItem.EditValue = "";
                    cboProject.EditValue = "";
                    cboMethod.EditValue = "";
                }
            }
        }
    }
}