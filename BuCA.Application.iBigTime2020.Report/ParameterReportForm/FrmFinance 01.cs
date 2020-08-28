﻿/***********************************************************************
 * <copyright file="FrmFinance 01.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Kiennt
 * Email:    kiennt@buca.vn
 * Website:
 * Create Date: 
 * Usage: 
 * 
 * RevisionHistory: 
 * Date: Thursday, August 30, 2018         Author: Tudt               Description: Fixbug
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors.Repository;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// FrmFinance01
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    public partial class FrmFinance01 : FrmXtraBaseParameter, IBudgetChaptersView, IBudgetKindItemsView, IBudgetSourcesView
    {
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
        /// The repository method distribute identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmFinance01"/> class.
        /// </summary>
        public FrmFinance01()
        {
            InitializeComponent();
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
           // dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;            
        }

        public int selectReport
        {
            get { return lookUpEdit1.SelectedIndex; }
        }

        /// <summary>
        /// Gets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }

        /// <summary>
        /// Gets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
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
        /// Gets a value indicating whether this instance is print all year and month13.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is print all year and month13; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrintAllYearAndMonth13
        {
            get { return isPrintMonth13.Checked; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is state treasury.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is state treasury; otherwise, <c>false</c>.
        /// </value>
        public bool IsStateTreasury
        {
            get { return isStateTreasury.Checked; }
        }

        /// <summary>
        /// Gets the list budget source identifier.
        /// </summary>
        /// <value>
        /// The list budget source identifier.
        /// </value>
        public string ListBudgetSourceId
        {
            get
            {
                if ((cboBudgetSourceId.EditValue.ToString().Contains("<<Tất cả>>")) || (cboBudgetSourceId.EditValue.ToString().Contains("<<Tổng hợp>>")))
                {
                    return null;
                }
                string listKey = "";
                var list = cboBudgetSourceId.Properties.GetItems().GetCheckedValues();
                foreach (var key in list)
                {
                    listKey = listKey + key + ",";
                }
                if (list.Count != 0)
                {
                    listKey = listKey.Remove(0, 0);
                }
                if (listKey == ",")
                    return null;
                return listKey;
            }
        }

        /// <summary>
        /// Gets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode
        {
            get
            {
                if (cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>" ||
                    cboBudgetChapter.EditValue.ToString() == "<<Tất cả>>")
                    return null;
                return cboBudgetChapter.EditValue == null ? "" : cboBudgetChapter.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets the budget sub kind item code.
        /// </summary>
        /// <value>
        /// The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode
        {
            get
            {
                if (cboBudgetKindItem.EditValue.ToString() == "<<Tổng hợp>>" ||
                    cboBudgetKindItem.EditValue.ToString() == "<<Tất cả>>")
                    return null;
                return cboBudgetKindItem.EditValue == null ? "" : cboBudgetKindItem.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>
        /// The method distribute identifier.
        /// </value>
        public int MethodDistributeId { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is summary budget source.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is summary budget source; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryBudgetSource
        {
            get
            {
                if (cboBudgetSourceId.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget chapter.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is summary budget chapter; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryBudgetChapter
        {
            get
            {
                if (cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget sub kind item.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is summary budget sub kind item; otherwise, <c>false</c>.
        /// </value>
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
        /// Gets or sets a value indicating whether [summary method distribute].
        /// </summary>
        /// <value>
        /// <c>true</c> if [summary method distribute]; otherwise, <c>false</c>.
        /// </value>
        public bool SummaryMethodDistribute { get; set; }

        //public bool IsPrintAllYearAndMonth13
        //{
        //    get { return chkIsPrintAllYearAndMonth13.Checked; }
        //}
        /// <summary>
        /// Gets a value indicating whether this instance is print month13.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is print month13; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrintMonth13
        {
            get { return isPrintMonth13.Checked; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [add same entry].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [add same entry]; otherwise, <c>false</c>.
        /// </value>
        //public bool AddSameEntry
        //{
        //    get { return checkAddSameEntry.Checked; }
        //}

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
                    ColumnWith = 250
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
        /// <value>
        /// The budget kind items.
        /// </value>
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
        /// Sets the budget sources.
        /// </summary>
        /// <value>
        /// The budget sources.
        /// </value>
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
                cboBudgetSourceId.Properties.DataSource = result;
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCode",
                    ColumnCaption = "Mã nguồn vốn",
                    ColumnPosition = 1,
                    ColumnVisible = false,
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
                    }
                }
                cboBudgetSourceId.Properties.DisplayMember = "BudgetSourceCode";
                cboBudgetSourceId.Properties.ValueMember = "BudgetSourceId";
            }
        }

        /// <summary>
        /// Handles the Load event of the FrmFinance control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmFinance_Load(object sender, EventArgs e)
        {
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
            cboBudgetKindItem.EditValue = @"<<Tổng hợp>>";
            cboBudgetSourceId.EditValue = @"<<Tổng hợp>>";
            lookUpEdit1.SelectedIndex = 0;
            rndOption.SelectedIndex = 1;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rndOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void rndOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rndOption.SelectedIndex == 0)
            {
                cboBudgetSourceId.EditValue = @"<<Tất cả>>";
                cboBudgetChapter.EditValue = @"<<Tất cả>>";
                cboBudgetKindItem.EditValue = @"<<Tất cả>>";
            }
            if (rndOption.SelectedIndex == 1)
            {
                cboBudgetSourceId.EditValue = @"<<Tổng hợp>>";
                cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
                cboBudgetKindItem.EditValue = @"<<Tổng hợp>>";
            }
        }
    }
}