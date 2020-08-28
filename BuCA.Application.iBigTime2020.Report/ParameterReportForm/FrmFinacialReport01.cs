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
    public partial class FrmFinacialReport01 : FrmXtraBaseParameter, IBudgetChaptersView
    {
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        protected string CurrencyAccounting;

        public FrmFinacialReport01()
        {
            InitializeComponent();
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            //dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            //dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
        }

        private void FrmB01H_Load(object sender, EventArgs e)
        {
            _budgetChaptersPresenter.DisplayByIsActive(true);
            cboBudgetChapter.EditValue = @"<<Tổng hợp>>";

            dateTimeRangeV1.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;

        }

        #region Properties
        public string StartDate
        {
            get { return GlobalVariable.StartedDate; }
        }

        public string BudgetChapterCode
        {
            get
            {
                if (cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>")
                    return string.Empty;
                return cboBudgetChapter.EditValue == null ? string.Empty : cboBudgetChapter.EditValue.ToString();
            }
        }

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

        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }

        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }
        #endregion

        #region IView
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                var result = new List<BudgetChapterModel>
                {
                    new BudgetChapterModel {BudgetChapterCode = @"<<Tổng hợp>>", BudgetChapterName = @"<<Tổng hợp>>"}
                };
                //result.AddRange(value.Where(v => v.BudgetChapterCode == "160" || v.BudgetChapterCode == "170" ||
                //                                 v.BudgetChapterCode == "422" || v.BudgetChapterCode == "423" ||
                //                                 v.BudgetChapterCode == "623" || v.BudgetChapterCode == "823"));

                result.AddRange(value.Where(y => y.IsActive = true));

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

                ShowXtraColumnInLookUpEdit<BudgetChapterModel>(columnsCollection, cboBudgetChapter);

                cboBudgetChapter.Properties.DisplayMember = "BudgetChapterCode";
                cboBudgetChapter.Properties.ValueMember = "BudgetChapterCode";
            }
        }
        #endregion
    }
}