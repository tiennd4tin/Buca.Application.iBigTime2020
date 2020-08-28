/***********************************************************************
 * <copyright file="FrmB01H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    tuanhm@buca.vn
 * Website:
 * Create Date: Thursday, July 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Session;
using DateTimeRangeBlockDev.Helper;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    ///     FrmB01H
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    public partial class FrmB01H : FrmXtraBaseParameter, IBudgetChaptersView, IBudgetKindItemsView, IBudgetSourcesView
    {
        /// <summary>
        ///     The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        /// <summary>
        ///     The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        /// <summary>
        ///     The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        ///     The currency accounting
        /// </summary>
        protected string CurrencyAccounting;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmB01H" /> class.
        /// </summary>
        public FrmB01H()
        {
            InitializeComponent();
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
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
        ///     Handles the Load event of the FrmB01H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmB01H_Load(object sender, EventArgs e)
        {
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            
            _budgetSourcesPresenter.DisplayActive();
            cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
            cboBudgetKindItem.EditValue = @"<<Tổng hợp>>";
            cboBudgetSourceId.SetEditValue(@"00000000-0000-0000-0000-000000000000");
            cboAccountGrade.EditValue = -1;
            lookUpEdit1.EditValue = 1;
            InitRepositoryControlData();
        }

        /// <summary>
        ///     Handles the EditValueChanged event of the lookUpEdit1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (TemplateReport == 2)
            {
                dateTimeRangeV1.Enabled = false;
                chkIsAddDataMonth13.Enabled = false;
                chkIsPrintAccountDecided.Enabled = false;
                chkIsPrintMonth13.Enabled = false;
                chkIsSummarySource.Enabled = false;
            }
            else
            {
                dateTimeRangeV1.Enabled = true;
                if (IsPrintMonth13)
                    chkIsAddDataMonth13.Checked = !IsPrintMonth13;
                else
                    chkIsAddDataMonth13.Enabled = true;
                chkIsPrintAccountDecided.Enabled = true;
                chkIsPrintMonth13.Enabled = true;
                chkIsSummarySource.Enabled = true;
            }
        }

        /// <summary>
        ///     Handles the CheckedChanged event of the checkEdit3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            chkIsAddDataMonth13.Enabled = !IsPrintMonth13;
            if (IsPrintMonth13)
                chkIsAddDataMonth13.Checked = !IsPrintMonth13;
        }

        /// <summary>
        ///     Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {
            var accountGrade = new List<LookUpItem>
            {
                new LookUpItem {Id = -1, Name = "<<Tất cả>>"},
                new LookUpItem {Id = 1, Name = "1"},
                new LookUpItem {Id = 2, Name = "2"},
                new LookUpItem {Id = 3, Name = "3"}
            };
            cboAccountGrade.Properties.DataSource = accountGrade;
            cboAccountGrade.Properties.PopulateColumns();
            var accountGradeColumnsCollection = new List<XtraColumn>
            {
                new XtraColumn {ColumnName = "Id", ColumnVisible = false},
                new XtraColumn {ColumnName = "Name", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100}
            };
            foreach (var column in accountGradeColumnsCollection)
                if (column.ColumnVisible)
                {
                    cboAccountGrade.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    cboAccountGrade.Properties.SortColumnIndex = column.ColumnPosition;
                    cboAccountGrade.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                }
                else
                {
                    cboAccountGrade.Properties.Columns[column.ColumnName].Visible = false;
                }
            cboAccountGrade.Properties.ValueMember = "Id";
            cboAccountGrade.Properties.DisplayMember = "Name";

            var templateReport = new List<LookUpItem>
            {
                new LookUpItem {Id = 1, Name = "Mẫu Quyết định 19"},
                new LookUpItem {Id = 2, Name = "Mẫu số dư hai bên"}
            };
            lookUpEdit1.Properties.DataSource = templateReport;
            lookUpEdit1.Properties.PopulateColumns();
            var templateReportColumnsCollection = new List<XtraColumn>
            {
                new XtraColumn {ColumnName = "Id", ColumnVisible = false},
                new XtraColumn {ColumnName = "Name", ColumnPosition = 1, ColumnVisible = true}
            };
        }

        #region IView

        /// <summary>
        ///     Sets the budget chapters.
        /// </summary>
        /// <value>
        ///     The budget chapters.
        /// </value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                var result = new List<BudgetChapterModel>
                {
                    new BudgetChapterModel {BudgetChapterCode = "<<Tổng hợp>>", BudgetChapterName = "<<Tổng hợp>>"}
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
                    if (column.ColumnVisible)
                    {
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetChapter.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                    {
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Visible = false;
                    }
                cboBudgetChapter.Properties.DisplayMember = "BudgetChapterCode";
                cboBudgetChapter.Properties.ValueMember = "BudgetChapterCode";
            }
        }

        /// <summary>
        ///     Sets the budget kind items.
        /// </summary>
        /// <value>
        ///     The budget kind items.
        /// </value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                var result = new List<BudgetKindItemModel>
                {
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tổng hợp>>", BudgetKindItemName = "<<Tổng hợp>>"}
                };
                result.AddRange(value);
                cboBudgetKindItem.Properties.DataSource = result;
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetKindItemCode",
                    ColumnCaption = "Mã Khoản",
                    ColumnPosition = 1,
                    ColumnVisible = false,
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
                cboBudgetKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                cboBudgetKindItem.Properties.ValueMember = "BudgetKindItemCode";
            }
        }

        /// <summary>
        ///     Sets the budget sources.
        /// </summary>
        /// <value>
        ///     The budget sources.
        /// </value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                var result = new List<BudgetSourceModel>
                {
                    new BudgetSourceModel {BudgetSourceId = "00000000-0000-0000-0000-000000000000",BudgetSourceCode = "<<Tổng hợp>>", BudgetSourceName = "<<Tổng hợp>>"}
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
                    if (column.ColumnVisible)
                    {
                    }
                cboBudgetSourceId.Properties.DisplayMember = "BudgetSourceCode";
                cboBudgetSourceId.Properties.ValueMember = "BudgetSourceId";
            }
        }

        /// <summary>
        ///     Gets the budget source identifier.
        /// </summary>
        /// <value>
        ///     The budget source identifier.
        /// </value>
        public string BudgetSourceId
        {
            get
            {
                if (cboBudgetSourceId.EditValue.ToString() == "00000000-0000-0000-0000-000000000000")
                    return "";
                var listKey = "";
                var list = cboBudgetSourceId.Properties.GetItems().GetCheckedValues();
                foreach (var key in list)
                    listKey = listKey + key+",";
               // if (list.Count != 0)
                   // listKey = listKey.Remove(0, 1);
                //listKey = listKey + ",";
                return listKey ;
            }
        }

        /// <summary>
        ///     Gets the budget chapter code.
        /// </summary>
        /// <value>
        ///     The budget chapter code.
        /// </value>
        public string BudgetChapterCode
        {
            get
            {
                if (cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>")
                    return "";
                return cboBudgetChapter.EditValue == null ? "" : cboBudgetChapter.EditValue.ToString();
            }
        }

        /// <summary>
        ///     Gets the budget sub kind item code.
        /// </summary>
        /// <value>
        ///     The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode
        {
            get
            {
                if (cboBudgetKindItem.EditValue.ToString().Contains("<<Tổng hợp>>"))
                    return "";
                var listKey = "";
                var list = cboBudgetKindItem.Properties.GetItems().GetCheckedValues();
                foreach (var key in list)
                    listKey = listKey + key + ",";
                //if (list.Count != 0)
                //    listKey = listKey.Remove(0, 1);
                return listKey;
            }
        }

        /// <summary>
        ///     Gets the account grade.
        /// </summary>
        /// <value>
        ///     The account grade.
        /// </value>
        public int AccountGrade
        {
            get { return (int)cboAccountGrade.EditValue; }
        }

        /// <summary>
        ///     Gets the template report.
        /// </summary>
        /// <value>
        ///     The template report.
        /// </value>
        public int TemplateReport
        {
            get { return (int)lookUpEdit1.EditValue; }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is summary source.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is summary source; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummarySource
        {
            get { return chkIsSummarySource.Checked; }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is print account decided.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is print account decided; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrintAccountDecided
        {
            get { return chkIsPrintAccountDecided.Checked; }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is print month13.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is print month13; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrintMonth13
        {
            get { return chkIsPrintMonth13.Checked; }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is add data month13.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is add data month13; otherwise, <c>false</c>.
        /// </value>
        public bool IsAddDataMonth13
        {
            get { return chkIsAddDataMonth13.Checked; }
        }

        /// <summary>
        ///     Gets or sets from date.
        /// </summary>
        /// <value>
        ///     From date.
        /// </value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }

        /// <summary>
        ///     Gets or sets the reference date.
        /// </summary>
        /// <value>
        ///     The reference date.
        /// </value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}