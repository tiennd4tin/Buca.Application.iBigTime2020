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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Presenter.Report;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Currency;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.ExportXml;
using Buca.Application.iBigTime2020.Model.BusinessObjects.ExportXml;
using Buca.Application.iBigTime2020.Presenter.ExportXml;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using System.Xml;
using Buca.Application.iBigTime2020.Presenter.Dictionary.DBOption;
using DevExpress.XtraGrid;
using RSSHelper;
using System.Net;
using System.Text;

namespace BuCA.Application.iBigTime2020.Report.MainReport
{
    /// <summary>
    /// FrmXtraReportList
    /// </summary>
    public partial class FrmXtraExportXMLToTreasury : XtraForm
    {

        #region Variables
        public int ReportType
        {
            get { return rb1.Checked ? 0 : 1; }
        }

        public int ReportYear
        {
            get { return Convert.ToInt32(cbxYear.SelectedItem); }
        }

        public string UnitCode
        {
            get { return txtUnitCode.Text; }
        }
        public string UnitName
        {
            get { return txtUnitName.Text; }
            set { txtUnitName.Text = value; }
        }

        public DateTime ReportTime
        {
            get { return ReportTime; }
        }
        public DateTime SignTime
        {
            get { return SignTime; }
        }

        public string CreatedBy
        {
            get { return txtCreatedBy.Text; }
            set { txtCreatedBy.Text = value; }
        }

        public string SignedBy
        {
            get { return txtSignedBy.Text; }
            set { txtSignedBy.Text = value; }
        }

        public string ControlBy
        {
            get { return txtControlBy.Text; }
            set { txtControlBy.Text = value; }
        }

        public string SavePath
        {
            get { return txtPath.Text; }
        }

        public DateTime FromDate
        {
            get
            {
                return new DateTime(ReportYear, 1, 1);
            }
        }
        public DateTime ToDate
        {
            get
            {
                return new DateTime(ReportYear, 12, 31);
            }
        }
        #endregion

        #region Initialize
        private void FrmXtraExportXMLToTreasury_Load(object sender, EventArgs e)
        {
            dateTimeCreateReport.CustomFormat = "dd/MM/yyyy";
            dateTimeSign.CustomFormat = "dd/MM/yyyy";
            cbxYear.SelectedIndex = 0;//set năm BC về index = 0
            CheckAndCreatePath("ExportKBNN");
            txtUnitCode.Text = "Nhập mã đơn vị đăng ký với hệ thống TKT của Kho bạc Nhà nước";
            txtUnitCode.ForeColor = Color.DarkGray;
        }

        public FrmXtraExportXMLToTreasury()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kiểm tra và khởi tạo thư mục Export nếu chưa có
        /// </summary>
        /// <param name="folderName"></param>
        private void CheckAndCreatePath(string folderName)
        {
            var endPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\" + folderName;//Set đường dẫn mặc định nằm trong thư mục phần mềm
            if (!System.IO.Directory.Exists(endPath))
                System.IO.Directory.CreateDirectory(endPath);
            txtPath.Text = endPath;
        }
        #endregion

        #region Functions
        /// <summary>
        /// Check dữ liệu trước khi xuất
        /// </summary>
        /// <returns></returns>
        private bool Valid()
        {
            if (txtUnitCode.Text.StartsWith("Nhập mã") || string.IsNullOrEmpty(txtUnitCode.Text.Trim()))
            {
                XtraMessageBox.Show("Bạn chưa nhập mã đơn vị.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtUnitName.Text))
            {
                XtraMessageBox.Show("Bạn chưa nhập tên đơn vị.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnitName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCreatedBy.Text))
            {
                XtraMessageBox.Show("Bạn chưa nhập người lập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCreatedBy.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSignedBy.Text))
            {
                XtraMessageBox.Show("Bạn chưa nhập người ký.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSignedBy.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtControlBy.Text))
            {
                XtraMessageBox.Show("Bạn chưa nhập người kiểm soát.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtControlBy.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                XtraMessageBox.Show("Bạn chưa chọn nơi lưu tệp.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thực hiện xuất dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                try
                {
                    btnExport.Enabled = false;
                    #region Chạy function get dữ liệu về dataset
                    List<string> listReport = new List<string>();
                    string classNameExport = "ExportXmlToTreasury";//Tên class chứa các hàm export
                    listReport.Add("GetSumReportB01BCTC_XmlToTreasury");
                    listReport.Add("GetSumReportB02BCTC_XmlToTreasury");
                    listReport.Add("GetSumReportB03aBCTC_XmlToTreasury");//Phương pháp trực tiếp
                    listReport.Add("GetSumReportB03bBCTC_XmlToTreasury");//Phương pháp gián tiếp
                    listReport.Add("GetSumReportB04BCTC_XmlToTreasury");
                    listReport.Add("GetSumReportB01BSTT_XmlToTreasury");
                    listReport.RemoveAt(ReportType.Equals(0) ? 2 : 3);
                    DataSet[] resultReports = new DataSet[listReport.Count];
                    for (int i = 0; i < resultReports.Length; i++)
                    {
                        var type = Assembly.GetExecutingAssembly()
                            .GetType("BuCA.Application.iBigTime2020.Report.ReportClass." + classNameExport);
                        var target = (BaseReport)Activator.CreateInstance(type);
                        //check có tồn tại hàm không 
                        MethodInfo myMethod = type.GetMethod(listReport[i]);
                        if (myMethod == null) continue;
                        if (!string.IsNullOrEmpty(listReport[i]))
                        {
                            var args = new object[] { Convert.ToDateTime(GlobalVariable.DBStartDate), FromDate, ToDate };
                            resultReports[i] = (DataSet)(type.InvokeMember(listReport[i], BindingFlags.InvokeMethod,
                                null, target, args));
                        }
                    }
                    #endregion

                    #region Thực hiện ghi data ra file XML

                    string reportName = ReportYear + "-BCTC_107_" + (ReportType.Equals(0) ? "GT-" : "TT-") + DateTime.Now.ToString("ddmmyyyy");//GlobalVariable.CompanyName;
                    string savepath = reportName + (@".xml");
                    Cursor.Current = Cursors.WaitCursor;
                    XmlTextWriter writer = new XmlTextWriter(txtPath.Text + @"/" + savepath, Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();

                    writer.WriteStartElement("BCCCTT");
                    writer.WriteAttributeString("xmlns", "https://bctcnn.vst.mof.gov.vn/BCCCTT");

                    //Phần thông tin chung
                    #region Phần thông tin chung
                    writer.WriteStartElement("TTChung");//Start thông tin chung

                    //phienBan
                    writer.WriteStartElement("phienBan");
                    writer.WriteString("001");
                    writer.WriteEndElement();
                    //-------------------------
                    //mauBC
                    writer.WriteStartElement("mauBC");
                    writer.WriteString("BCTC_107_" + (ReportType.Equals(0) ? "G" : "T") + "T");
                    writer.WriteEndElement();
                    //-------------------------
                    //tenBC
                    writer.WriteStartElement("tenBC");
                    writer.WriteString("Báo cáo tài chính TT107/2017/TT-BTC (Lưu chuyển tiền tệ phương pháp " + (ReportType.Equals(0) ? "gián" : "trực") + " tiếp)");
                    writer.WriteEndElement();
                    //-------------------------
                    //kyBC
                    writer.WriteStartElement("kyBC");
                    writer.WriteString(ReportYear.ToString());
                    writer.WriteEndElement();
                    //-------------------------
                    //maDonvi
                    writer.WriteStartElement("maDonvi");
                    writer.WriteString(txtUnitCode.Text);
                    writer.WriteEndElement();
                    //-------------------------
                    //tenDonVi
                    writer.WriteStartElement("tenDonVi");
                    writer.WriteString(txtUnitName.Text);
                    writer.WriteEndElement();
                    //-------------------------
                    //ngayLapBC
                    writer.WriteStartElement("ngayLapBC");
                    writer.WriteString(dateTimeCreateReport.Value.Day + @"/" + dateTimeCreateReport.Value.Month + @"/" + dateTimeCreateReport.Value.Year);
                    writer.WriteEndElement();
                    //-------------------------
                    //nguoiLapBC
                    writer.WriteStartElement("nguoiLapBC");
                    writer.WriteString(txtCreatedBy.Text);
                    writer.WriteEndElement();
                    //-------------------------
                    //ngayKy
                    writer.WriteStartElement("ngayKy");
                    writer.WriteString(dateTimeSign.Value.Day + @"/" + dateTimeSign.Value.Month + @"/" + dateTimeSign.Value.Year);
                    writer.WriteEndElement();
                    //-------------------------
                    //nguoiKy
                    writer.WriteStartElement("nguoiKy");
                    writer.WriteString(txtSignedBy.Text);
                    writer.WriteEndElement();
                    //-------------------------
                    //nguoiKsoat
                    writer.WriteStartElement("nguoiKsoat");
                    writer.WriteString(txtControlBy.Text);
                    writer.WriteEndElement();
                    //-------------------------

                    writer.WriteEndElement(); //End thông tin chung 
                    #endregion

                    #region Phần thông tin chi tiết
                    writer.WriteStartElement("TTBaoCao");

                    #region B01BCTC
                    writer.WriteStartElement("THTC");
                    string[] reportItemCode = new string[36] { "", "01", "05", "10", "11", "12", "13", "14", "20", "25", "30", "31", "32", "33", "35", "36", "37", "40", "45", "50", "", "60", "61", "62", "63", "64", "65", "67", "66", "68", "70", "71", "72", "73", "74", "80" };
                    //if (resultReports[0].Tables[0].Rows.Count > 0)
                    {
                        #region Mã TaiSan
                        writer.WriteStartElement("TaiSan");
                        for (int i = 0; i < 20; i++)
                        {
                            if (!string.IsNullOrEmpty(reportItemCode[i]))
                            {
                                writer.WriteStartElement("CT" + reportItemCode[i] + "D");
                                writer.WriteString("");
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "1");
                                writer.WriteValue(resultReports[0].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[0].Tables[0].Rows[i][5]) : 0);
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "2");
                                writer.WriteValue(resultReports[0].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[0].Tables[0].Rows[i][6]) : 0);
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region Mã NguonVon
                        writer.WriteStartElement("NguonVon");
                        for (int i = 20; i < 36; i++)
                        {
                            if (!string.IsNullOrEmpty(reportItemCode[i]))
                            {
                                writer.WriteStartElement("CT" + reportItemCode[i] + "D");
                                writer.WriteString("");
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "1");
                                writer.WriteValue(resultReports[0].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[0].Tables[0].Rows[i][5]) : 0);
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "2");
                                writer.WriteValue(resultReports[0].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[0].Tables[0].Rows[i][6]) : 0);
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                        #endregion
                    }
                    writer.WriteEndElement();

                    #endregion

                    #region B02BCTC

                    reportItemCode = new string[]
                    {
                        "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "20", "21", "22", "30",
                        "31", "32", "40", "50", "51", "52", "53"
                    };
                    writer.WriteStartElement("KQHD");

                    //if (resultReports[1].Tables[0].Rows.Count > 0)
                    {

                        #region Mã HDHCSN
                        writer.WriteStartElement("HDHCSN");
                        for (int i = 0; i < 9; i++)
                        {
                            if (!string.IsNullOrEmpty(reportItemCode[i]))
                            {
                                writer.WriteStartElement("CT" + reportItemCode[i] + "D");
                                writer.WriteString("");
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "1");
                                writer.WriteValue(resultReports[1].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[1].Tables[0].Rows[i][3]) : 0);
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "2");
                                writer.WriteValue(resultReports[1].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[1].Tables[0].Rows[i][4]) : 0);
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region Mã HDSXKD
                        writer.WriteStartElement("HDSXKD");
                        for (int i = 9; i < 12; i++)
                        {
                            if (!string.IsNullOrEmpty(reportItemCode[i]))
                            {
                                writer.WriteStartElement("CT" + reportItemCode[i] + "D");
                                writer.WriteString("");
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "1");
                                writer.WriteValue(resultReports[1].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[1].Tables[0].Rows[i][3]) : 0);
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "2");
                                writer.WriteValue(resultReports[1].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[1].Tables[0].Rows[i][4]) : 0);
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region Mã HDTC
                        writer.WriteStartElement("HDTC");
                        for (int i = 12; i < 15; i++)
                        {
                            if (!string.IsNullOrEmpty(reportItemCode[i]))
                            {
                                writer.WriteStartElement("CT" + reportItemCode[i] + "D");
                                writer.WriteString("");
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "1");
                                writer.WriteValue(resultReports[1].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[1].Tables[0].Rows[i][3]) : 0);
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "2");
                                writer.WriteValue(resultReports[1].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[1].Tables[0].Rows[i][4]) : 0);
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region Mã HDKhac
                        writer.WriteStartElement("HDKhac");
                        for (int i = 15; i < 23; i++)
                        {
                            if (!string.IsNullOrEmpty(reportItemCode[i]))
                            {
                                writer.WriteStartElement("CT" + reportItemCode[i] + "D");
                                writer.WriteString("");
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "1");
                                writer.WriteValue(resultReports[1].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[1].Tables[0].Rows[i][3]) : 0);
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "2");
                                writer.WriteValue(resultReports[1].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[1].Tables[0].Rows[i][4]) : 0);
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                        #endregion

                    }
                    writer.WriteEndElement();

                    #endregion

                    #region LCTTTT/LCTTGT
                    writer.WriteStartElement("LCTT" + (ReportType.Equals(0) ? "G" : "T") + "T");
                    reportItemCode = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "21", "22", "23", "24", "30", "31", "32", "33", "34", "35", "40", "50", "60", "70", "80"};
                    string[] reportItemCode2 = new string[] { "01", "02", "03", "04", "05", "06", "10", "11", "12", "13", "20", "21", "22", "23", "24", "30", "31", "32", "33", "34", "35", "40", "50", "60", "70", "80" };
                    //if (resultReports[2].Tables[0].Rows.Count > 0)
                    {

                        #region Mã HDC
                        writer.WriteStartElement("HDC");
                        for (int i = 0; i < (ReportType.Equals(0) ? 10 : 11); i++)
                        {
                            if (!string.IsNullOrEmpty((ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i])))
                            {
                                writer.WriteStartElement("CT" + (ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i]) + "D");
                                writer.WriteString("");
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + (ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i]) + "1");
                                writer.WriteValue(resultReports[2].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[2].Tables[0].Rows[i][3]) : 0);
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + (ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i]) + "2");
                                writer.WriteValue(resultReports[2].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[2].Tables[0].Rows[i][4]) : 0);
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region Mã HDDT
                        writer.WriteStartElement("HDDT");
                        for (int i = (ReportType.Equals(0) ? 10 : 11); i < (ReportType.Equals(0) ? 15 : 16); i++)
                        {
                            if (!string.IsNullOrEmpty((ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i])))
                            {
                                writer.WriteStartElement("CT" + (ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i]) + "D");
                                writer.WriteString("");
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + (ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i]) + "1");
                                writer.WriteValue(resultReports[2].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[2].Tables[0].Rows[i][3]) : 0);
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + (ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i]) + "2");
                                writer.WriteValue(resultReports[2].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[2].Tables[0].Rows[i][4]) : 0);
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region Mã HDTC
                        writer.WriteStartElement("HDTC");
                        for (int i = (ReportType.Equals(0) ? 15 : 16); i < (ReportType.Equals(0) ? 25 : 26); i++)
                        {
                            if (!string.IsNullOrEmpty((ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i])))
                            {
                                writer.WriteStartElement("CT" + (ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i]) + "D");
                                writer.WriteString("");
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + (ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i]) + "1");
                                writer.WriteValue(resultReports[2].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[2].Tables[0].Rows[i][3]) : 0);
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + (ReportType.Equals(0) ? reportItemCode[i] : reportItemCode2[i]) + "2");
                                writer.WriteValue(resultReports[2].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[2].Tables[0].Rows[i][4]) : 0);
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteEndElement();
                        #endregion

                    }
                    writer.WriteEndElement();

                    #endregion

                    #region B04BCTC
                    reportItemCode = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100", "101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "120", "121", "122", "123", "124", "125", "126", "127", "128", "129", "130", "131", "132", "133", "134", "135", "136", "137", "138", "139", "140", "141", "142", "143", "144", "145", "146", "147", "148", "149", "150", "151", "152", "153", "154", "155", "156", "157", "158", "159", "160" };
                    writer.WriteStartElement("TMBCTC");

                    //if (resultReports[3].Tables[0].Rows.Count > 0)
                    {

                        #region Mã TMTCTH
                        writer.WriteStartElement("TMTCTH");
                        #region Tien
                        writer.WriteStartElement("Tien");
                        for (int i = 0; i < 5; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region ThuKhac
                        writer.WriteStartElement("ThuKhac");
                        for (int i = 5; i < 21; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region TonKho
                        writer.WriteStartElement("TonKho");
                        for (int i = 21; i < 27; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region TSCD
                        writer.WriteStartElement("TSCD");
                        for (int i = 27; i < 33; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "TC");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][7]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "HH");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][5]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "VH");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][6]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region XDCB
                        writer.WriteStartElement("XDCB");
                        for (int i = 33; i < 37; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region TSKhac
                        writer.WriteStartElement("TSKhac");
                        for (int i = 37; i < 38; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region TraNoVay
                        writer.WriteStartElement("TraNoVay");
                        for (int i = 38; i < 41; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region TamThu
                        writer.WriteStartElement("TamThu");
                        for (int i = 41; i < 47; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region QuyDacThu
                        writer.WriteStartElement("QuyDacThu");
                        for (int i = 47; i < 48; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region NhanChuaThu
                        writer.WriteStartElement("NhanChuaThu");
                        for (int i = 48; i < 59; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region NoKhac
                        writer.WriteStartElement("NoKhac");
                        for (int i = 59; i < 80; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region VonKDoanh
                        writer.WriteStartElement("VonKDoanh");
                        for (int i = 80; i < 84; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region Quy
                        writer.WriteStartElement("Quy");
                        for (int i = 84; i < 90; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region TSThuan
                        writer.WriteStartElement("TSThuan");
                        for (int i = 90; i < 94; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "CN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "DN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region BDongNVon
                        writer.WriteStartElement("BDongNVon");
                        for (int i = 94; i < 98; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "KD");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][8]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "CL");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][9]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "TD");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][10]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "QU");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][11]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "TL");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][12]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "KC");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][13]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "CG");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][14]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        writer.WriteEndElement();
                        #endregion

                        #region Mã TMKQHD
                        writer.WriteStartElement("TMKQHD");

                        #region HCSN
                        writer.WriteStartElement("HCSN");
                        for (int i = 98; i < 128; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "NN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "NT");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region KDDV
                        writer.WriteStartElement("KDDV");
                        for (int i = 128; i < 136; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "NN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "NT");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region HDTC
                        writer.WriteStartElement("HDTC");
                        for (int i = 136; i < 138; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "NN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "NT");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region HDK
                        writer.WriteStartElement("HDK");
                        for (int i = 138; i < 140; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "NN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "NT");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region TNDN
                        writer.WriteStartElement("TNDN");
                        for (int i = 140; i < 143; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "NN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "NT");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region PPCQ
                        writer.WriteStartElement("PPCQ");
                        for (int i = 143; i < 150; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "NN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "NT");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        #region DVHC
                        writer.WriteStartElement("DVHC");
                        for (int i = 150; i < 154; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "NN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "NT");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        #endregion

                        writer.WriteEndElement();
                        #endregion

                        #region Mã TMLCTT
                        writer.WriteStartElement("TMLCTT");

                        for (int i = 154; i < 160; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "NN");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();

                            writer.WriteStartElement("CT" + reportItemCode[i] + "NT");
                            writer.WriteValue(resultReports[3].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[3].Tables[0].Rows[i][4]) : 0);
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                        #endregion

                    }
                    writer.WriteEndElement();

                    #endregion

                    #region B01BSTT
                    reportItemCode = new string[] { "01", "02", "03", "05", "06", "07", "08", "10", "11", "12", "18", "20", "21", "22", "50", "51", "52", "53", "60", "61", "62", "63", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100", "101", "102", "103", "104", "105", "106", "107", "108" };
                    writer.WriteStartElement("BSTT");

                    //if (resultReports[4].Tables[0].Rows.Count > 0)
                    {

                        #region Mã TaiChinhTongHop
                        writer.WriteStartElement("TaiChinhTongHop");

                        for (int i = 0; i < 25; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "1");
                            writer.WriteValue(resultReports[4].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[4].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();
                            if (!reportItemCode[i].ToString().Equals("70"))
                            {
                                writer.WriteStartElement("CT" + reportItemCode[i] + "5");
                                writer.WriteValue(resultReports[4].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[4].Tables[0].Rows[i][7]) : 0);
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "6");
                                writer.WriteValue(resultReports[4].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[4].Tables[0].Rows[i][8]) : 0);
                                writer.WriteEndElement();

                                writer.WriteStartElement("CT" + reportItemCode[i] + "7");
                                writer.WriteValue(resultReports[4].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[4].Tables[0].Rows[i][9]) : 0);
                                writer.WriteEndElement();
                            }
                        }

                        writer.WriteEndElement();
                        #endregion

                        #region Mã TMTaiChinh
                        writer.WriteStartElement("TMTaiChinh");

                        for (int i = 25; i < 61; i++)
                        {
                            writer.WriteStartElement("CT" + reportItemCode[i] + "NN");
                            writer.WriteValue(resultReports[4].Tables[0].Rows.Count > 0 ? Convert.ToInt64(resultReports[4].Tables[0].Rows[i][3]) : 0);
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                        #endregion

                    }
                    writer.WriteEndElement();
                    #endregion

                    writer.WriteEndElement();
                    #endregion

                    writer.WriteEndElement(); //java
                    writer.WriteEndDocument();
                    writer.Close();
                    #endregion
                    btnExport.Enabled = true;

                    DialogResult dialogResult = MessageBox.Show("Bạn có muốn mở thư mục xuất dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Process.Start(txtPath.Text);
                    }
                }
                catch (Exception exception)
                {
                    btnExport.Enabled = true;
                    XtraMessageBox.Show("Không thể xuất dữ liệu\nLỗi: " + exception,
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //Console.WriteLine(exception);
                    throw;
                }
            }

        }

        #region Giao diện thực thi textbox và button

        /// <summary>
        /// Rời textbox mã
        /// </summary>
        private void txtUnitCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnitCode.Text))
            {
                txtUnitCode.Text = "Nhập mã đơn vị đăng ký với hệ thống TKT của Kho bạc Nhà nước";
                txtUnitCode.ForeColor = Color.DarkGray;
            }
            else
            {
                txtUnitCode.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Trỏ tới textbox mã
        /// </summary>
        private void txtUnitCode_Enter(object sender, EventArgs e)
        {
            txtUnitCode.ForeColor = Color.Black;
            if (txtUnitCode.Text.StartsWith("Nhập mã"))
            {
                txtUnitCode.Text = "";
            }
        }

        /// <summary>
        /// Chọn đường dẫn
        /// </summary>
        private void btnBrower_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult results = DialogResult.Cancel;
                results = fbd.ShowDialog();
                if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    txtPath.Text = fbd.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Thoát form khi bấm ESC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmXtraExportXMLToTreasury_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        #endregion

        #endregion

    }
}