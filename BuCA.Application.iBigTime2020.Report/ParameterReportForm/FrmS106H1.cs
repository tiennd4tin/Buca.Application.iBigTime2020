using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmS106H1 :  FrmXtraBaseParameter, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IActivitysView
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
        private readonly ActivitysPresenter _ActivityPresenter;

        #endregion

        #region Variable
        private List<AccountModel> _accountModel;


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
                if (cboActivity.EditValue.ToString() == "<<Tổng hợp>>")
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
                if (cboBudgetSource.EditValue.ToString() == "<<Tổng hợp>>")
                {
                    return ",91e02a45-a08a-483c-bba1-80bb73ef38e4,";
                }
               else if (cboBudgetSource.EditValue.ToString() == "<<Tất cả>>")
                {
                    return ",a0624cfa-d105-422f-bf20-11f246704dc3,";
                }
                return "," + cboBudgetSource.EditValue.ToString() + ",";
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
                if ((cboActivity.EditValue.ToString() == "<<Tổng hợp>>") || cboActivity.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                return cboActivity.EditValue.ToString();
            }
        }

        public string ActivityID
        {
            get
            {
                if (cboActivity.EditValue.ToString() == "<<Tổng hợp>>" || cboActivity.EditValue.ToString() == "<<Tất cả>>")
                {
                    return ",a0624cfa-d105-422f-bf20-11f246704dc3,";
                }
                return "," + cboActivity.EditValue.ToString() + ",";
            }
        }

        #endregion

        public FrmS106H1()
        {
            InitializeComponent();
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _ActivityPresenter = new ActivitysPresenter(this);
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
        /// Handles the Load event of the FrmS106H1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmS106H1_Load(object sender, EventArgs e)
        {
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _ActivityPresenter.DisplayActive(true);
            cboBudgetSource.EditValue = @"<<Tổng hợp>>";
            cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
            cboBudgetKindItem.EditValue = @"<<Tổng hợp>>";
            cboActivity.EditValue = @"<<Tổng hợp>>";
        }




        #region Activitys
        public IList<ActivityModel> Activitys
        {
            set
            {
                var result = new List<ActivityModel>
                {
                    new ActivityModel {ActivityCode = "<<Tổng hợp>>", ActivityName = "<<Tổng hợp>>"},
                    new ActivityModel {ActivityCode = "<<Tất cả>>", ActivityName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboActivity.Properties.DataSource = result;
                cboActivity.Properties.ForceInitialize();
                cboActivity.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ActivityCode",
                    ColumnCaption = "Mã hoạt động",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ActivityName",
                    ColumnCaption = "Tên hoạt động",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboActivity.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboActivity.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboActivity.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboActivity.Properties.DisplayMember = "ActivityCode";
                cboActivity.Properties.ValueMember = "ActivityCode";
            }
        }
        #endregion	

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rndOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rndOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rndOption.SelectedIndex == 0)
            {
                cboBudgetSource.EditValue = @"<<Tất cả>>";
                cboBudgetChapter.EditValue = @"<<Tất cả>>";
                cboBudgetKindItem.EditValue = @"<<Tất cả>>";
                cboActivity.EditValue = @"<<Tất cả>>";
            }
            else
            {
                if (rndOption.SelectedIndex == 1)
                {
                    cboBudgetSource.EditValue = @"<<Tổng hợp>>";
                    cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
                    cboBudgetKindItem.EditValue = @"<<Tổng hợp>>";
                    cboActivity.EditValue = @"<<Tổng hợp>>";
                }
                //else
                //{
                //    cboBudgetSource.EditValue = "";
                //    cboBudgetChapter.EditValue = "";
                //    cboBudgetKindItem.EditValue = "";
                //    cboActivity.EditValue = "";
                //}
            }
        }
    }
}
