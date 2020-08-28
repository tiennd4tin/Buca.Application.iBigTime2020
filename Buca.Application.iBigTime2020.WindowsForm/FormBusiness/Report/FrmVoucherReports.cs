using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Presenter.Report;
using Buca.Application.iBigTime2020.View.Report;
using BuCA.Enum;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Report
{
    /// <summary>
    /// Class FrmVoucherReports.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmVoucherReports : XtraForm, IReportsView
    {
        private List<ReportListModel> _reportList;
        private ReportListPresenter _reportListPresenter;
        private ReportHelper _reportHelper;

        /// <summary>
        /// Gets or sets the reference type voucher.
        /// </summary>
        /// <value>The reference type voucher.</value>
        public RefType RefTypeVoucher { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
        public bool IsInTheoLo { get { return checkEdit2.Checked; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmVoucherReports"/> class.
        /// </summary>
        public FrmVoucherReports()
        {
            InitializeComponent();
            _reportListPresenter = new ReportListPresenter(this);
            _reportHelper = new ReportHelper();
        }
        private object DataSource { get; set; }
        public FrmVoucherReports(object dataSource)
        {
            InitializeComponent();
            DataSource = dataSource;
            _reportListPresenter = new ReportListPresenter(this);
            _reportHelper = new ReportHelper();
        }
        /// <summary>
        /// Handles the Load event of the FrmVoucherReports control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FrmVoucherReports_Load(object sender, System.EventArgs e)
        {
            if (RefTypeVoucher == RefType.BUTransferFixedAsset || RefTypeVoucher == RefType.BAWithDrawFixedAsset || RefTypeVoucher == RefType.PUInvoiceFixedAsset || RefTypeVoucher == RefType.FAIncrementDecrement)
            {
                RefTypeVoucher = RefType.CAPaymentDetailFixedAsset;
            }
            _reportListPresenter.GetReportsByRefType((int)RefTypeVoucher);
        }

        /// <summary>
        /// Sets the report lists.
        /// </summary>
        /// <value>The report lists.</value>
        public List<ReportListModel> ReportLists
        {
            get { return _reportList; }
            set
            {

                // check hiển thị mẫu chứng từ giấy rút vốn đầu tư của CKKB, Phiếu thu và chi tiền gửi by NgocPT
                // chuyển khoản kho bạc
                if (DataSource != null)
                {
                    // Bảng kê nội dung thanh toán tạm ứng
                    if ((int)RefTypeVoucher == 63)
                    {
                        IList<BUVoucherListDetailModel> details = (IList<BUVoucherListDetailModel>)DataSource;
                        value = value.Where(w => w.ReportId.Contains("63_BK.TT39.2016")).ToList();
                        //value = value.Where(w => details.Any(d => (d.CreditAccount.Contains("112")) || !w.ReportId.Equals("C402a_TT77_158"))).ToList();
                    }

                    if ((int)RefTypeVoucher == 56)
                    {
                        IList<BUTransferDetailModel> details = (IList<BUTransferDetailModel>)DataSource;
                        value = value.Where(w => details.Any(d => (d.CreditAccount.Contains("343")) || !w.ReportId.Equals("56_C03_01_TT77"))).ToList();
                        // value = value.Where(w => details.Any(d => (d.CashWithDrawTypeId == 1 || d.CashWithDrawTypeId == 2) || !w.ReportId.Equals("11_ND11_TT52"))).ToList();
                    }
                    // piếu thu
                    if ((int)RefTypeVoucher == 101)
                    {
                        IList<CAReceiptDetailModel> details = (IList<CAReceiptDetailModel>)DataSource;
                        value = value.Where(w => details.Any(d => (d.CreditAccount.Contains("343")) || !w.ReportId.Equals("56_C03_01_TT77PT"))).ToList();
                    }
                    // Chi tiền gửi
                    if ((int)RefTypeVoucher == (int)BuCA.Enum.RefType.BADeposit)
                    {
                        IList<BADepositDetailModel> details = (IList<BADepositDetailModel>)DataSource;
                        value = value.Where(w => details.Any(d => (d.CreditAccount.Contains("343")) || !w.ReportId.Equals("56_C03_01_TT77TTG"))).ToList();
                    }
                    // Phiếu chi mua tài sản cố định
                    if ((int)RefTypeVoucher == (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset)
                    {
                        //IList<CAPaymentDetailFixedAssetModel> details = (IList<CAPaymentDetailFixedAssetModel>)DataSource;
                        //value = value.Where(w => details.Any(d => (d.CreditAccount.Contains("112")) || !w.ReportId.Equals("58_BK.TT39.2016"))).ToList();
                        IList<CAPaymentDetailFixedAssetModel> details = (IList<CAPaymentDetailFixedAssetModel>)DataSource;
                        //Ghi tăng bằng tiền mặt (111) thì chứng từ cần In : 3 mẫu phiếu chi như cửa sổ phiếu chi
                        if (details.Any(d => d.CreditAccount.Contains("111")))
                        {
                            value = value.Where(w => w.ReportId.Equals("108.1") || w.ReportId.Equals("108.111_1") || w.ReportId.Equals("108.111_2")).ToList();
                        }
                        //Ghi tăng bằng tiền gửi NG (112) thì chứng từ cần In: 2 mẫu UNC + Bảng kê nội dung thanh toán giống Chi tiền gửi
                        if (details.Any(d => d.CreditAccount.Contains("112")))
                        {
                            value = value.Where(w => w.ReportId.Equals("108.112") || w.ReportId.Equals("108.112_1") || w.ReportId.Equals("108.112_2")).ToList();
                        }

                        if (details.Any(d => d.CreditAccount.StartsWith("241")) || details.Any(d => d.CreditAccount.StartsWith("366")))
                        {
                            value = new List<ReportListModel>();
                        }
                    }
                    // Phiếu chi mua tài sản cố định
                    if ((int)RefTypeVoucher == (int)BuCA.Enum.RefType.BAWithDraw)
                    {
                        IList<BAWithDrawDetailModel> details = (IList<BAWithDrawDetailModel>)DataSource;
                        value = value.Where(w => details.Any(d => (d.CreditAccount.Contains("112")) || !w.ReportId.Equals("157_BK.TT39.2016"))).ToList();
                    }
                    //// Chứng từ chung
                    //if ((int)RefTypeVoucher == (int)BuCA.Enum.RefType.GLVoucher)
                    //{
                    //    IList<GLVoucherDetailModel> details = (IList<GLVoucherDetailModel>)DataSource;
                    //    value = value.Where(w => details.Any(d => (d.CreditAccount.Contains("112")) || !w.ReportId.Equals("401_BK.TT39.2016"))).ToList();
                    //}

                    // Nhập kho
                    if ((int)RefTypeVoucher == 201)
                    {
                        IList<CAPaymentDetailPurchaseModel> details = (IList<CAPaymentDetailPurchaseModel>)DataSource;
                        var detail = details.Any(d => d.CreditAccount.Contains("112"));
                        if (!detail)
                        {
                            value = value.Where(w => !w.ReportId.Contains("C402a_TT77_158") && !w.ReportId.Contains("C402c_TT77_158") && !w.ReportId.Contains("401_BK.TT39.2016")).ToList();
                        }
                        //value = value.Where(w => details.Any(d => (d.CreditAccount.Contains("112")) || !w.ReportId.Equals("C402a_TT77_158"))).ToList();
                    }

                    // Chứng từ chung
                    if ((int)RefTypeVoucher == 401)
                    {
                        IList<GLVoucherDetailModel> details = (IList<GLVoucherDetailModel>)DataSource;
                        var detail = details.Any(d => d.CreditAccount.Contains("112"));
                        if (!detail)
                        {
                            value = value.Where(w => !w.ReportId.Contains("401_BK.TT39.2016")).ToList();
                        }
                        //value = value.Where(w => details.Any(d => (d.CreditAccount.Contains("112")) || !w.ReportId.Equals("C402a_TT77_158"))).ToList();
                    }

                }

                _reportList = value;
                grdReportDetail.DataSource = _reportList;
                grdReportDetailView.PopulateColumns(_reportList);

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "ReportId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ReportName",
                    ColumnCaption = "Chọn mẫu chứng từ cần in",
                    ColumnWith = 470,
                    ColumnVisible = true
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ReportFile", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "OutputAssembly", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "InputTypeName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "FunctionReportName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProcedureName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "TableName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "TrackType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProcNameByLot", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProcNameVoucherList", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Inactive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "PrintVoucherDefault", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "LicenceType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Particularity", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsReportBeConfigured", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Standard", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AllowBatchPrinting", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "GetParamFromDialog", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DataBandSortReportId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ReportType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Level", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Visible", ColumnVisible = false });
                grdReportDetailView = InitGridLayout(columnsCollection, grdReportDetailView);
                grdReportDetailView.OptionsView.ShowFooter = false;
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
                        grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
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
        /// Handles the Click event of the btnPreview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void btnPreview_Click(object sender, System.EventArgs e)
        {
            try
            {
                var reportId = grdReportDetailView.GetFocusedRowCellValue("ReportId").ToString();
                _reportHelper = new ReportHelper
                {
                    ReportParameter = new ReportParameter { RefId = RefId, RefType = (int)RefTypeVoucher, IsInTheoLo = IsInTheoLo },
                    ReportLists = _reportList,
                };
                if (chkPrintSystemDate.Checked && !chkPrintVoucherDate.Checked)
                    GlobalVariable.PrintSystemDate = 1;
                else if (!chkPrintSystemDate.Checked && chkPrintVoucherDate.Checked)
                    GlobalVariable.PrintSystemDate = 2;
                else
                    GlobalVariable.PrintSystemDate = 3;

                _reportHelper.PrintPreviewReport(null, reportId, false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkPrintVoucherDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkPrintVoucherDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrintSystemDate.Checked && chkPrintVoucherDate.Checked)
                chkPrintSystemDate.Checked = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkPrintSystemDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkPrintSystemDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrintSystemDate.Checked && chkPrintVoucherDate.Checked)
                chkPrintVoucherDate.Checked = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var reportFile = grdReportDetailView.GetFocusedRowCellValue("ReportFile").ToString();
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

        private void grdReportDetail_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var reportId = grdReportDetailView.GetFocusedRowCellValue("ReportId").ToString();
                _reportHelper = new ReportHelper
                {
                    ReportParameter = new ReportParameter { RefId = RefId, RefType = (int)RefTypeVoucher },
                    ReportLists = _reportList,
                };
                if (chkPrintSystemDate.Checked && !chkPrintVoucherDate.Checked)
                    GlobalVariable.PrintSystemDate = 1;
                else if (!chkPrintSystemDate.Checked && chkPrintVoucherDate.Checked)
                    GlobalVariable.PrintSystemDate = 2;
                else
                    GlobalVariable.PrintSystemDate = 3;

                _reportHelper.PrintPreviewReport(null, reportId, false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var reportId = grdReportDetailView.GetFocusedRowCellValue("ReportId").ToString();
                _reportHelper = new ReportHelper
                {
                    ReportParameter = new ReportParameter { RefId = RefId, RefType = (int)RefTypeVoucher },
                    ReportLists = _reportList,
                };
                _reportHelper.ExtractXMLKhoBac(reportId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdReportDetailView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var reportId = grdReportDetailView.GetFocusedRowCellValue("ReportId").ToString();
            if (reportId.StartsWith("C409") || reportId.StartsWith("C3-04") || reportId.StartsWith("C2_05") || reportId.EndsWith("DeNghiThanhToanVonDauTuTT08") || reportId.EndsWith("PaymentPurchaseInformationTT349"))
                btnExport.Visible = true;
            else
            {
                btnExport.Visible = false;
            }
        }
    }
}
