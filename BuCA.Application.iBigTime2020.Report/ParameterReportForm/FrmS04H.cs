/***********************************************************************
 * <copyright file="FrmS04H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, November 20, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using DateTimeRangeBlockDev.Helper;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS04H.
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    public partial class FrmS04H : FrmXtraBaseParameter,IBudgetSourcesView,IBudgetChaptersView,IBudgetKindItemsView
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

        #endregion

        #region Variable
        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget source.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget source; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetSource
        {
            get
            {
                if (Convert.ToString(checkcboBudgetSource.EditValue).Contains("<<Tổng hợp>>"))
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget chapter.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget chapter; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetChapter
        {
            get
            {
                if (Convert.ToString(checkcboBudgetChapter.EditValue).Contains("<<Tổng hợp>>"))
                    return true;
                else
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
                if (Convert.ToString(checkcboBudgetKindItem.EditValue).Contains("<<Tổng hợp>>"))
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [add same entry].
        /// </summary>
        /// <value><c>true</c> if [add same entry]; otherwise, <c>false</c>.</value>
        public bool AddSameEntry
        {
            get { return checkAddSameEntry.Checked; }
        }
        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>The budget source code.</value>
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
                    return sBudgetSourceCode;
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
                var sBudgetChapterCode = Convert.ToString(checkcboBudgetChapter.EditValue);
                if (string.IsNullOrEmpty(sBudgetChapterCode) ||
                    sBudgetChapterCode.Contains("<<Tổng hợp>>") ||
                    sBudgetChapterCode.Contains("<<Tất cả>>"))
                {
                    return null;
                }
                else
                    return sBudgetChapterCode;
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
                var sBudgetKindItemCode = Convert.ToString(checkcboBudgetKindItem.EditValue);
                if (string.IsNullOrEmpty(sBudgetKindItemCode) ||
                    sBudgetKindItemCode.Contains("<<Tổng hợp>>") ||
                    sBudgetKindItemCode.Contains("<<Tất cả>>"))
                {
                    return null;
                }
                else
                    return sBudgetKindItemCode;
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
        /// Gets the selection.
        /// </summary>
        /// <value>The selection.</value>
        internal GridCheckMarksSelection SelectionBudgetSource { get; private set; }
        /// <summary>
        /// Gets the selection budget chapter.
        /// </summary>
        /// <value>The selection budget chapter.</value>
        internal GridCheckMarksSelection SelectionBudgetChapter { get; private set; }
        /// <summary>
        /// Gets the selection budget subkind item.
        /// </summary>
        /// <value>The selection budget subkind item.</value>
        internal GridCheckMarksSelection SelectionBudgetSubkindItem { get; private set; }
        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS04H"/> class.
        /// </summary>
        public FrmS04H()
        {
            InitializeComponent();
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
           

            //dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.All;
            //dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
        }


        #region IView
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
                checkcboBudgetChapter.Properties.DataSource = result;

                //cboBudgetChapter.Properties.ForceInitialize();
                //cboBudgetChapter.Properties.PopulateColumns();
                //var columnsCollection = new List<XtraColumn>();
                //columnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "BudgetChapterCode",
                //    ColumnCaption = "Mã Chương",
                //    ColumnPosition = 1,
                //    ColumnVisible = false,
                //    ColumnWith = 100
                //});
                //columnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "BudgetChapterName",
                //    ColumnCaption = "Tên Chương",
                //    ColumnPosition = 2,
                //    ColumnVisible = true,
                //    ColumnWith = 250,

                //});
                //columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        cboBudgetChapter.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        cboBudgetChapter.Properties.SortColumnIndex = column.ColumnPosition;
                //    }
                //    else
                //        cboBudgetChapter.Properties.Columns[column.ColumnName].Visible = false;
                //}

                checkcboBudgetChapter.Properties.DisplayMember = "BudgetChapterName";
                checkcboBudgetChapter.Properties.ValueMember = "BudgetChapterCode";
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
                checkcboBudgetKindItem.Properties.DataSource = result;

                //cboBudgetKindItem.Properties.ForceInitialize();
                //cboBudgetKindItem.Properties.PopulateColumns();
                //var columnsCollection = new List<XtraColumn>();
                //columnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemId", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "BudgetKindItemCode",
                //    ColumnCaption = "Mã Khoản",
                //    ColumnPosition = 1,
                //    ColumnVisible = false,
                //    ColumnWith = 100
                //});
                //columnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "BudgetKindItemName",
                //    ColumnCaption = "Tên Khoản",
                //    ColumnPosition = 2,
                //    ColumnVisible = true,
                //    ColumnWith = 250
                //});
                //columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        cboBudgetKindItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        cboBudgetKindItem.Properties.SortColumnIndex = column.ColumnPosition;
                //    }
                //    else
                //        cboBudgetKindItem.Properties.Columns[column.ColumnName].Visible = false;
                //}

                checkcboBudgetKindItem.Properties.DisplayMember = "BudgetKindItemName";
                checkcboBudgetKindItem.Properties.ValueMember = "BudgetKindItemCode";
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
                checkcboBudgetSource.Properties.ValueMember = "BudgetSourceCode";
            }
        }

        /// <summary>
        /// Binds the select design report.
        /// </summary>
        protected void BindSelectDesignReport()
        {
            //var bankSource = new List<LookUpItem> { new LookUpItem { Id = 0, Name = "Thông tư số 79/2019/TT-BTC" } };
            //cboSelectDesignReport.Properties.DataSource = bankSource;
            //cboSelectDesignReport.Properties.PopulateColumns();
            //var treeColumnsCollection = new List<XtraColumn> {
            //                                    new XtraColumn { ColumnName = "Id", ColumnVisible = false },
            //                                    new XtraColumn { ColumnName = "Name", ColumnPosition = 1, ColumnVisible = true }
            //                                };
            //foreach (var column in treeColumnsCollection)
            //{
            //    if (column.ColumnVisible)
            //    {
            //        cboSelectDesignReport.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
            //        cboSelectDesignReport.Properties.SortColumnIndex = column.ColumnPosition;
            //    }
            //    //else cboSelectDesignReport.Properties.Columns[column.ColumnName].Visible = false;
            //}
            //cboSelectDesignReport.Properties.ValueMember = "Id";
            //cboSelectDesignReport.Properties.DisplayMember = "Name";
        }

        #endregion

        #region Event
        /// <summary>
        /// Handles the Load event of the FrmS04H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmS04H_Load(object sender, EventArgs e)
        {
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            checkAddSameEntry.Checked = false;
            BindSelectDesignReport();
            dateTimeRangeV1.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
            cboSelectDesignReport.SelectionStart = 1;
            checkcboBudgetSource.EditValue = "<<Tổng hợp>>";
            checkcboBudgetChapter.EditValue = "<<Tổng hợp>>";
            checkcboBudgetKindItem.EditValue = "<<Tổng hợp>>";
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rndOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rndOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rndOption.SelectedIndex == 0)
            {
                checkcboBudgetSource.EditValue = "<<Tất cả>>";
                checkcboBudgetChapter.EditValue = "<<Tất cả>>";
                checkcboBudgetKindItem.EditValue = "<<Tất cả>>";
            }
            if (rndOption.SelectedIndex == 1)
            {
                checkcboBudgetSource.EditValue = "<<Tổng hợp>>";
                checkcboBudgetChapter.EditValue = "<<Tổng hợp>>";
                checkcboBudgetKindItem.EditValue = "<<Tổng hợp>>";
            }

        }

    

        private void cboBudgetSource_EditValueChanged(object sender, EventArgs e)
        {
            //SelectionBudgetSource = new GridCheckMarksSelection(_);
            //SelectionBudgetSource.CheckMarkColumn.VisibleIndex = 0;
            //SelectionBudgetSource.CheckMarkColumn.Width = 10;
        }
        #endregion
    }
}
