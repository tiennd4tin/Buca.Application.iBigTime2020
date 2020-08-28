/***********************************************************************
 * <copyright file="FrmXtraReportList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, March 05, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Presenter.Report;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Report;
using Buca.Application.iBigTime2020.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Data.XtraReports.Wizard;
using DevExpress.XtraEditors;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ParameterReportForm;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Currency;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;

namespace BuCA.Application.iBigTime2020.Report.MainReport
{
    /// <summary>
    /// FrmXtraReportList
    /// </summary>
    public partial class FrmXtraReportList : XtraForm, IReportsView, IReportGroupView, ICurrenciesView
    {
        /// <summary>
        /// The _report list presenter
        /// </summary>
        private readonly ReportListPresenter _reportListPresenter;

        /// <summary>
        /// The _report group presenter
        /// </summary>
        private readonly ReportGroupPresenter _reportGroupPresenter;

        /// <summary>
        /// The _report helper
        /// </summary>
        private readonly ReportHelper _reportHelper;

        /// <summary>
        /// Gets or sets the common variable.
        /// </summary>
        /// <value>
        /// Currencies
        /// </value>
        private readonly CurrenciesPresenter _currenciesPresenter;

        /// <summary>
        /// The _report list
        /// </summary>
        private List<ReportListModel> _reportList;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraReportList"/> class.
        /// </summary>
        public FrmXtraReportList()
        {
            InitializeComponent();
            _reportGroupPresenter = new ReportGroupPresenter(this);
            _reportListPresenter = new ReportListPresenter(this);
            _reportHelper = new ReportHelper();
            _currenciesPresenter = new CurrenciesPresenter(this);
            dtReportPeriod.DateRangePeriodMode = DateRangeMode.Reduce;
            //dtReportPeriod.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dtReportPeriod.InitSelectedIndex = 0;
            var basePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dtReportPeriod.InitData(new DateTime(basePostedDate.Year, 1, 1));
            dtReportPeriod.FromDate = (new DateTime(basePostedDate.Year, 1, 1));
            dtReportPeriod.ToDate = (new DateTime(basePostedDate.Year, 12, 31));
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData()
        {
            try
            {
                _currenciesPresenter.DisplayActive();
                //cboCurrencyCode.Properties.Items.Add(GlobalVariable.MainCurrencyId);
                cboCurrencyCode.EditValue = GlobalVariable.MainCurrencyId;//cboCurrencyCode.Properties.Items[0];
                _reportListPresenter.GetReportsByIsActive(true,GlobalVariable.LoginName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// Views the report.
        /// </summary>
        private void ViewReport(bool isPrint)
        {
            try
            {
                var reportId = gridReportDetailView.GetFocusedRowCellValue("ReportId").ToString();
                GlobalVariable.DateRangeSelectedIndex = dtReportPeriod.cboDateRange.SelectedIndex;
                GlobalVariable.DateRangeSelected = dtReportPeriod.cboDateRange.EditValue.ToString();
                GlobalVariable.FromDate = dtReportPeriod.FromDate;
                GlobalVariable.ToDate = dtReportPeriod.ToDate;
                GlobalVariable.AmountTypeViewReport = cboAmountType.SelectedIndex + 1;
                GlobalVariable.CurrencyViewReport = cboCurrencyCode.EditValue.ToString();
                GlobalVariable.ServerName = dtReportPeriod.cboDateRange.EditValue == null ? null : dtReportPeriod.cboDateRange.EditValue.ToString();

                //ReportTool.CommonVariable = GlobalVariable;

                // Một số báo cáo dùng dataset sẽ in cách khác
                switch (reportId)
                {
                    case CommonText.ReportS33_H:
                        ShowS33H(reportId);
                        break;
                    case CommonText.ReportS61H:
                        ShowS61H(reportId);
                        break;

                    default:
                        ReportTool.PrintPreview(this, _reportList, reportId, isPrint);
                        break;
                }

                dtReportPeriod.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex + "Lỗi:" + ex.InnerException);
            }
        }

        /// <summary>
        /// Views the report.
        /// </summary>
        public void ViewReport(bool isPrint, string reportId)
        {
            try
            {                
                GlobalVariable.DateRangeSelectedIndex = dtReportPeriod.cboDateRange.SelectedIndex;
                GlobalVariable.FromDate = dtReportPeriod.FromDate;
                GlobalVariable.ToDate = dtReportPeriod.ToDate;
                GlobalVariable.AmountTypeViewReport = cboAmountType.SelectedIndex + 1;
                GlobalVariable.CurrencyViewReport = cboCurrencyCode.EditValue.ToString();
                //ReportTool.CommonVariable = GlobalVariable;

                // Một số báo cáo dùng dataset sẽ in cách khác
                switch (reportId)
                {
                    case CommonText.ReportS33_H:
                        ShowS33H(reportId);
                        break;
                    case CommonText.ReportS61H:
                        ShowS61H(reportId);
                        break;

                    default:
                        ReportTool.PrintPreview(this, _reportList, reportId, isPrint);
                        break;
                }

                dtReportPeriod.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex + "Lỗi:" + ex.InnerException);
            }
        }

        /// <summary>
        /// Loads the report group grid layout.
        /// </summary>
        private void LoadReportGroupGridLayout()
        {
            try
            {
                grdReportGroup.ForceInitialize();
                grdReportGroup.DataSource = _reportList.Where(r => r.ParentId == null && r.Visible == true && r.ReportType == 0).OrderBy(r => r.SortOrder).ToList();
                gridReportGroupView.PopulateColumns(grdReportGroup.DataSource);
                for (int i = 0; i < gridReportGroupView.Columns.Count; i++)
                {
                    if (gridReportGroupView.Columns[i].FieldName != "ReportName")
                    {
                        gridReportGroupView.Columns[i].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Loads the report detail grid layout.
        /// </summary>
        private void LoadReportDetailGridLayout(List<ReportListModel> value)
        {
            try
            {
                //Tin tv: Chi hien thi : S01-H: Nhật ký - Sổ cái, S02a-H: Chứng từ ghi sổ , S02b-H: Sổ đăng ký chứng từ ghi sổ , S02c-H: Sổ cái - Hình thức chứng từ ghi sổ khi chọn hình thức sổ kế toán là nhật ký sổ cái    
                if (GlobalVariable.AccountingBooksType == 0)//Nhat ky chung//S04-H
                {
                    grdReportDetail.DataSource = value.Where(o => o.ReportId != "S01-H" && o.ReportId != "S02a-H" && o.ReportId != "S02b-H" && o.ReportId != "S02c-H").ToList();
                    gridReportDetailView.PopulateColumns(grdReportDetail.DataSource);
                }
                else if (GlobalVariable.AccountingBooksType == 1 )//Nhat ky - So cai-S01H
                {
                    grdReportDetail.DataSource = value.Where(o => o.ReportId != "S04-H" && o.ReportId != "S02a-H" && o.ReportId != "S02b-H" && o.ReportId != "S02c-H").ToList();
                    gridReportDetailView.PopulateColumns(grdReportDetail.DataSource);
                }
                else if (GlobalVariable.AccountingBooksType == 2)//Chung tu - Ghi so   S02a-H,S02b-H,S02c-H
                {
                    grdReportDetail.DataSource = value.Where(o => o.ReportId != "S01-H" && o.ReportId != "S04-H").ToList();
                    gridReportDetailView.PopulateColumns(grdReportDetail.DataSource);
                }
                //else
                //{
                //    var data = value.ToList();
                //    grdReportDetail.DataSource = data;
                //    gridReportDetailView.PopulateColumns(grdReportDetail.DataSource);
                //}

                if (_reportList.Count <= 0)
                    return;
                for (int i = 0; i < gridReportDetailView.Columns.Count; i++)
                {
                    if (gridReportDetailView.Columns[i].FieldName != "ReportName")
                    {
                        gridReportDetailView.Columns[i].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region IReportView Members

        /// <summary>
        /// Gets or sets the report lists.
        /// </summary>
        /// <value>
        /// The report lists.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<ReportListModel> ReportLists
        {
            set
            {
                _reportList = value;
            }
        }

        /// <summary>
        /// Gets the report helper.
        /// </summary>
        /// <value>
        /// The report helper.
        /// </value>
        public ReportHelper ReportHelper
        {
            get { return _reportHelper; }
        }

        #endregion

        #region ICurrenciesView Members
        public IList<CurrencyModel> Currencies
        { set
            {
                foreach (var item in value)
                {
                    cboCurrencyCode.Properties.Items.Add(item.CurrencyCode); 
                }

            }
        }
        #endregion
        /// <summary>
        /// Handles the Load event of the FrmXtraReportList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraReportList_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadReportGroupGridLayout();
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            ViewReport(false);
        }

        /// <summary>
        /// Handles the DoubleClick event of the gridReportDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gridReportDetailView_DoubleClick(object sender, EventArgs e)
        {
            ViewReport(false);
        }

        #region IReportGroupView Members

        /// <summary>
        /// Sets the report groups.
        /// </summary>
        /// <value>
        /// The report groups.
        /// </value>
        public List<ReportGroupModel> ReportGroups
        {
            get { return new List<ReportGroupModel>(); }
            set { grdReportGroup.DataSource = value; }
        }



        #endregion


        /// <summary>
        /// Handles the FocusedRowChanged event of the gridReportGroupView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs"/> instance containing the event data.</param>
        private void gridReportGroupView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var reportGroupId = gridReportGroupView.GetFocusedRowCellValue("ReportId").ToString();
            if (_reportList == null)
                return;
            if(GlobalVariable.AccountingBooksType == 0)
            {
                LoadReportDetailGridLayout(_reportList.Where(item => item.ParentId == reportGroupId && item.Visible == true).OrderBy(r => r.SortOrder).ToList());
            }
            else
            {
                LoadReportDetailGridLayout(_reportList.Where(item => item.ParentId == reportGroupId && item.Visible == true && item.ReportId != "S03-H").OrderBy(r => r.SortOrder).ToList());
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ViewReport(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var reportFile = gridReportDetailView.GetFocusedRowCellValue("ReportFile").ToString();
                var fullPath = GlobalVariable.ReportPath + reportFile;
                if (File.Exists(fullPath))
                    _reportHelper.DesignReportTemplate(fullPath);
                else
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show("Tệp báo cáo không tồn tại, vui lòng kiểm tra lại đường dẫn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ViewReport(true);
        }

        //ThangNK bổ sung hàm này
        private void cboAmountType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboAmountType.SelectedIndex == 0)
            {
                cboCurrencyCode.EditValue = GlobalVariable.MainCurrencyId;
                cboCurrencyCode.Enabled = false;
            }
            else
            {
                cboCurrencyCode.Enabled = true;

            }

        }

        #region Show form report
        private void ShowS33H(string reportId)
        {
            var _frm = new frmS33_H(reportId);
            _frm.ShowDialog();
            if (_frm.DialogResult == DialogResult.OK)
            {
                var _reportListModel = _reportList.FirstOrDefault(m => m.ReportId.Equals(reportId));
                if (_reportListModel == null)
                    return;

                object[] paramsStore = { nameof(GlobalVariable.StartedDate), DateTime.Parse(GlobalVariable.SystemDate),
                                        nameof(GlobalVariable.FromDate), _frm.dateTimeRangeV1.FromDate,
                                        nameof(GlobalVariable.ToDate), _frm.dateTimeRangeV1.ToDate,
                                        nameof(_frm.AccountingObjectId), _frm.AccountingObjectId,
                                        nameof(_frm.AccountList), _frm.AccountList,
                                        "SummaryAccountingObject", false,
                                        "SummaryAccount", false,
                                        "IsSumSameEntry", false, };

                Dictionary<string, object> paramsReport = new Dictionary<string, object>()
                {
                    { nameof(GlobalVariable.FromDate), _frm.dateTimeRangeV1.FromDate.ToShortDateString() },
                    { nameof(GlobalVariable.ToDate), _frm.dateTimeRangeV1.ToDate.ToShortDateString() },
                };
                ReportTool.PreviewReport(this, _reportListModel, paramsStore, paramsReport);
            }
        }

        private void ShowS61H(string reportId)
        {
            var _frm = new frmS33_H(reportId);
            _frm.ShowDialog();
            if (_frm.DialogResult == DialogResult.OK)
            {
                var _reportListModel = _reportList.FirstOrDefault(m => m.ReportId.Equals(reportId));
                if (_reportListModel == null)
                    return;

                object[] paramsStore = { "StartDate", DateTime.Parse(GlobalVariable.SystemDate),
                                        nameof(GlobalVariable.FromDate), _frm.dateTimeRangeV1.FromDate,
                                        nameof(GlobalVariable.ToDate), _frm.dateTimeRangeV1.ToDate,
                                        "AccountNumberList", _frm.AccountList,
                                        "@IsSameSummary", false,
                                        "@AmountType",GlobalVariable.AmountTypeViewReport,
                                        "@CurrencyCode",GlobalVariable.CurrencyViewReport ,};

                Dictionary<string, object> paramsReport = new Dictionary<string, object>()
                {
                    { nameof(GlobalVariable.FromDate), _frm.dateTimeRangeV1.FromDate.ToShortDateString() },
                    { nameof(GlobalVariable.ToDate), _frm.dateTimeRangeV1.ToDate.ToShortDateString() },
                };
                ReportTool.PreviewReport(this, _reportListModel, paramsStore, paramsReport);
            }
        }
        #endregion
    }
}