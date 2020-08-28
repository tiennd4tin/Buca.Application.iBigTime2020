/***********************************************************************
 * <copyright file="ReportHelper.cs" company="BUCA JSC">
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
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.MainReport;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraEditors;
using PerpetuumSoft.Framework.Drawing;
using PerpetuumSoft.Framework.Text;
using PerpetuumSoft.Reporting.DOM;
using RSSHelper;
using System.Globalization;
using System.Data;
using PerpetuumSoft.Reporting.Components;
using PerpetuumSoft.Reporting.View;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using PerpetuumSoft.Reporting.Windows.Forms;
using BuCA.Enum;
using DevExpress.XtraRichEdit.Layout;
using System.Threading;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    /// <summary>
    /// ReportHelper
    /// </summary>
    public class ReportHelper
    {
        #region "Fields"

        /// <summary>
        /// The _o rs tool
        /// </summary>
        private ReportSharpHelper _rsTool;

        /// <summary>
        /// The _report list model
        /// </summary>
        private ReportListModel _reportListModel;

        /// <summary>
        /// The _FRM parent form
        /// </summary>
        private XtraForm _frmParentForm;

        /// <summary>
        /// Gets or sets the is display new license information.
        /// </summary>
        /// <value>The is display new license information.</value>
        public bool IsDisplayNewLicenseInfo;

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets or sets the report lists.
        /// </summary>
        /// <value>
        /// The report lists.
        /// </value>
        public List<ReportListModel> ReportLists { get; set; }

        /// <summary>
        /// Gets or sets the currency models.
        /// </summary>
        /// <value>
        /// The currency models.
        /// </value>
        public IList<CurrencyModel> CurrencyModels { get; set; }

        /// <summary>
        /// The report parameter
        /// </summary>
        public ReportParameter ReportParameter { get; set; }

        /// <summary>
        /// Gets or sets the rs tool.
        /// </summary>
        /// <value>
        /// The rs tool.
        /// </value>
        public ReportSharpHelper ReportSharpTool
        {
            get
            {
                return _rsTool;
            }
            set
            {
                var handler1 = new ReportSharpHelper.RefreshEventHandler(RefreshReport);
                var handler2 = new ReportSharpHelper.DrilldownVoucherEventHandler(ReportDrillDownVoucher);
                var handler3 = new ReportSharpHelper.DrilldownLedgerReportHandler(ReportDrillDownLedgerReport);
                var handler4 = new ReportSharpHelper.ReportAboutEventHandler(ReportAbout);
                _rsTool = value;
                if (_rsTool == null)
                    return;
                _rsTool.RefreshEvent += handler1;
                _rsTool.DrilldownVoucherEvent += handler2;
                _rsTool.DrilldownLedgerReportEvent += handler3;
                _rsTool.ReportAboutEvent += handler4;
                
            }
        }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public SortedList Parameters { get; set; }

        /// <summary>
        /// Gets or sets the data member.
        /// </summary>
        /// <value>
        /// The data member.
        /// </value>
        public string DataMember { get; set; }

        #endregion

        #region "Methods"

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportHelper" /> class.
        /// </summary>
        public ReportHelper()
        {
            //ReportSharpTool = new ReportSharpHelper();

            //var a = new NumberFormatInfo();

            //// Định dạng số tiền trên report
            //ReportSharpTool.RssObject.Nfi.CurrencyDecimalDigits = GlobalVariable.CurrencyDecimalDigitsInReport;

            try
            {
                //var dbOptionHelper = new GlobalVariable();
                System.Globalization.NumberFormatInfo Nfi = Thread.CurrentThread.CurrentCulture.NumberFormat;
                Nfi.CurrencyNegativePattern = Convert.ToInt32(GlobalVariable.CurrencyNegativePatternInReport);
                //Nfi.NumberDecimalDigits = Convert.ToInt32(GlobalVariable.ExchangeRateDecimalDigits);
                Nfi.NumberDecimalDigits = Convert.ToInt32(GlobalVariable.NumberDecimalDigits);
                Nfi.CurrencyDecimalDigits = Convert.ToInt32(GlobalVariable.CurrencyDecimalDigits);
                ReportSharpTool = new ReportSharpHelper(Nfi);
            }
            catch
            {
                ReportSharpTool = new ReportSharpHelper();
            }
        }

        /// <summary>
        /// Reports the about.
        /// </summary>
        private static void ReportAbout()
        {
            using (var frmAbout = new XtraAboutFormReport())
            {
                frmAbout.ShowDialog();
            }
        }

        /// <summary>
        /// Refreshes the report.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        private void RefreshReport(ref ICollection dataSource)
        {
            try
            {
                if (dataSource == null)
                    return;
                if (_reportListModel == null)
                    return;
                ReportSharpTool.IsRefresh = true;
                var data = GetDataSource(_frmParentForm, _reportListModel);
                if (data != null)
                {
                    dataSource = data;
                    if (dataSource.Count < 1)
                    {
                        XtraMessageBox.Show("Không có bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    ReportSharpTool.IsRefresh = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra trong quá trình truy vấn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Reports the drill down voucher.
        /// </summary>
        /// <param name="refType">The reftype.</param>
        /// <param name="refId">The refid.</param>
        private void ReportDrillDownVoucher(string refType, string refId)
        {
            GlobalVariable.IsViewVoucher = false;
            try
            {
                var pageIndex = ReportSharpTool.oPreviewForm.ReportViewer.PageIndex;
                ReportTool.DrillDownReportVoucher(refType, refId);
                //AnhNT disable đoạn dưới để không refresh báo cáo
                //ReportSharpTool.PreviewForm.ReportViewer.Actions["RefreshReport"].ExecuteAction();
                //var reportFileName = ReportSharpTool.ReportFileName;
                //ReportSharpTool.PreviewForm.Text = ReportSharpTool.ReportTitle + @"  [" + reportFileName.Substring((reportFileName.LastIndexOf("\\", StringComparison.Ordinal) + 1),
                //                                                              ((reportFileName.Length - reportFileName.LastIndexOf("\\", StringComparison.Ordinal)) - 1)) +
                //                                                          @"] - Xem báo cáo";
                //ReportSharpTool.oPreviewForm.ReportViewer.PageIndex = pageIndex;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra trong quá trình truy vấn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Reports the drill down ledger report.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eParam">The e parameter.</param>
        private void ReportDrillDownLedgerReport(object sender, DrilldownReportParam eParam)
        {

            try
            {
                var pageIndex = ReportSharpTool.oPreviewForm.ReportViewer.PageIndex;
                ReportTool.DrillDownReport(sender, eParam);

                //var zoom = ReportSharpTool.PreviewForm.ReportViewer.Zoom;
                //var templateFile = ReportSharpTool.ReportSlot.FilePath;
                //ReportSharpTool.ReportSlot.FilePath = ReportSharpTool.ReportFileName;
                //ReportSharpTool.ReportSlot.Document = ReportSharpTool.ReportSlot.LoadReport();

                //ReportSharpTool.RefreshInfo(ReportSharpTool.ReportSlot.Document);

                //ReportSharpTool.ReportSlot.FilePath = templateFile;
                //ReportSharpTool.ReportSlot.SaveReport(ReportSharpTool.ReportSlot.Document);
                //ReportSharpTool.ReportSlot.RenderDocument();


                //ReportSharpTool.PreviewForm.ReportViewer.Actions["RefreshReport"].ExecuteAction();

                //var reportFileName = ReportSharpTool.ReportFileName;
                //ReportSharpTool.PreviewForm.Text = ReportSharpTool.ReportTitle + @"  [" + reportFileName.Substring((reportFileName.LastIndexOf("\\", StringComparison.Ordinal) + 1),
                //                                                              ((reportFileName.Length - reportFileName.LastIndexOf("\\", StringComparison.Ordinal)) - 1)) +
                //                                                          @"] - Xem báo cáo";
                ////ReportSharpTool.PreviewForm.ReportViewer.Zoom = zoom;
                //ReportSharpTool.oPreviewForm.ReportViewer.PageIndex = pageIndex;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra trong quá trình truy vấn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <returns></returns>
        /// ReSharper disable once UnusedMember.Local
        /// ReSharper disable once UnusedParameter.Local
        private bool AddParameter(ref ICollection dataSource)
        {
            try
            {
                var oRsTool = ReportSharpTool;

                if (ReportSharpTool != null)
                {
                    oRsTool.Parameters.Add("CompanyAccountant", GlobalVariable.CompanyAccountant ?? string.Empty);
                    oRsTool.Parameters.Add("CompanyCashier", GlobalVariable.CompanyCashier ?? string.Empty);
                    oRsTool.Parameters.Add("CompanyChiefAccountant", GlobalVariable.CompanyChiefAccountant ?? string.Empty);
                    oRsTool.Parameters.Add("CompanyDirector", GlobalVariable.CompanyDirector ?? string.Empty);
                    oRsTool.Parameters.Add("CompanyReportPreparer", GlobalVariable.CompanyReportPreparer ?? string.Empty);
                    oRsTool.Parameters.Add("CompanyStoreKeeper", GlobalVariable.CompanyStoreKeeper ?? string.Empty);
                    oRsTool.Parameters.Add("DecimalPlaces", GlobalVariable.CurrencyUnitPriceDigits);
                    if (GlobalVariable.IsValidLicense)
                    {

                        if (!oRsTool.Parameters.ContainsKey("BUCACompanyParentName"))
                            oRsTool.Parameters.Add("BUCACompanyParentName", GlobalVariable.CompanyInCharge.ToUpper());

                        if (!oRsTool.Parameters.ContainsKey("BUCACompanyName"))
                            oRsTool.Parameters.Add("BUCACompanyName", GlobalVariable.CompanyName);

                        if (!oRsTool.Parameters.ContainsKey("BUCACompanyAddress"))
                            oRsTool.Parameters.Add("BUCACompanyAddress", "Mã đơn vị: " + GlobalVariable.CompanyCode);
                    }

                    if (!GlobalVariable.IsValidLicense)
                    {

                        if (!oRsTool.Parameters.ContainsKey("BUCACompanyParentName"))
                            oRsTool.Parameters.Add("BUCACompanyParentName", "CHƯA ĐĂNG KÝ BẢN QUYỀN");

                        if (!oRsTool.Parameters.ContainsKey("BUCACompanyName"))
                            oRsTool.Parameters.Add("BUCACompanyName", "LIÊN HỆ VỚI BUCA");

                        if (!oRsTool.Parameters.ContainsKey("BUCACompanyAddress"))
                            oRsTool.Parameters.Add("BUCACompanyAddress", "Mã đơn vị: " + "Chưa có bản quyền");
                    }



                    // viết hoa các tiêu đề của chữ kí
                    if (!oRsTool.Parameters.ContainsKey("CompanyAccountantTitle"))
                        oRsTool.Parameters.Add("CompanyAccountantTitle", GlobalVariable.CompanyAccountantTitle == null ? string.Empty : GlobalVariable.CompanyAccountantTitle);
                    if (!oRsTool.Parameters.ContainsKey("CompanyCashierTitle"))
                        oRsTool.Parameters.Add("CompanyCashierTitle", GlobalVariable.CompanyCashierTitle == null ? string.Empty : GlobalVariable.CompanyCashierTitle);
                    if (!oRsTool.Parameters.ContainsKey("CompanyChiefAccountantTitle"))
                        oRsTool.Parameters.Add("CompanyChiefAccountantTitle", GlobalVariable.CompanyChiefAccountantTitle == null ? string.Empty : GlobalVariable.CompanyChiefAccountantTitle);
                    if (!oRsTool.Parameters.ContainsKey("CompanyDirectorTitle"))
                        oRsTool.Parameters.Add("CompanyDirectorTitle", GlobalVariable.CompanyDirectorTitle == null ? string.Empty : GlobalVariable.CompanyDirectorTitle);
                    if (!oRsTool.Parameters.ContainsKey("CompanyReportPreparerTitle"))
                        oRsTool.Parameters.Add("CompanyReportPreparerTitle", GlobalVariable.CompanyReportPreparerTitle == null ? string.Empty : GlobalVariable.CompanyReportPreparerTitle);
                    if (!oRsTool.Parameters.ContainsKey("CompanyStoreKeeperTitle"))
                        oRsTool.Parameters.Add("CompanyStoreKeeperTitle", GlobalVariable.CompanyStoreKeeperTitle == null ? string.Empty : GlobalVariable.CompanyStoreKeeperTitle);


                    //Tham số định dạng báo cáo ==============================================
                    //Kí tự phân cách phần thập phân
                    if (!oRsTool.Parameters.ContainsKey("GeneralGroupSeparator"))
                        oRsTool.Parameters.Add("GeneralGroupSeparator", GlobalVariable.GeneralGroupSeparator ?? string.Empty);
                    //Kí tự phân cách hàng nghìn
                    if (!oRsTool.Parameters.ContainsKey("GeneralDecimalSeparator"))
                        oRsTool.Parameters.Add("GeneralDecimalSeparator", GlobalVariable.GeneralDecimalSeparator ?? string.Empty);

                    if (!oRsTool.Parameters.ContainsKey("CurrencySymbolInReport"))
                        oRsTool.Parameters.Add("CurrencySymbolInReport", GlobalVariable.CurrencySymbolInReport ?? "");
                    if (!oRsTool.Parameters.ContainsKey("CurrencyDecimalDigitsInReport"))
                        oRsTool.Parameters.Add("CurrencyDecimalDigitsInReport", GlobalVariable.CurrencyDecimalDigitsInReport);
                    if (!oRsTool.Parameters.ContainsKey("CurrencyUnitPriceDigitsInReport"))
                        oRsTool.Parameters.Add("CurrencyUnitPriceDigitsInReport", GlobalVariable.CurrencyUnitPriceDigitsInReport);
                    //=========================================================================
                }
                else
                {
                    oRsTool.Parameters.Add("CompanyAccountant", "");
                    oRsTool.Parameters.Add("CompanyCashier", "");
                    oRsTool.Parameters.Add("CompanyChiefAccountant", "");
                    oRsTool.Parameters.Add("CompanyDirector", "");
                    oRsTool.Parameters.Add("CompanyReportPreparer", "");
                    oRsTool.Parameters.Add("CompanyStoreKeeper", "");
                }
           
                oRsTool.Parameters.Add("PrintSystemDate", GlobalVariable.PrintSystemDate);
                oRsTool.Parameters.Add("DBPostedDate", GlobalVariable.PostedDate ?? string.Empty);

                oRsTool.Parameters.Add("StartDate", GlobalVariable.StartedDate ?? string.Empty);
                oRsTool.Parameters.Add("AmountType", GlobalVariable.AmountTypeViewReport);
                oRsTool.Parameters.Add("CurrencyCode", GlobalVariable.CurrencyViewReport ?? string.Empty);
                oRsTool.Parameters.Add("MainCurrencyId", GlobalVariable.MainCurrencyId ?? string.Empty);

                //Ẩn thành phố
                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                    oRsTool.Parameters.Add("CompanyProvince", ".............");
                
                var licenseParameter = oRsTool.LicenseParameters;

                licenseParameter.Add("IsValidLicense",GlobalVariable.IsValidLicense);

                licenseParameter.Add("OwnerCompanyName", GlobalVariable.OwnerCompanyName ?? string.Empty);

                var parentCompanyFont = GlobalVariable.CompanyInChargeFont != null ? GlobalVariable.CompanyInChargeFont.Split(';') : null;
                if (parentCompanyFont != null && parentCompanyFont.Length != 0)
                {
                    var fontstyle = (FontStyle)System.Enum.Parse(typeof(FontStyle), parentCompanyFont[2], true);
                    var font = new Font(parentCompanyFont[0], float.Parse(parentCompanyFont[1]), fontstyle);
                    licenseParameter.Add("CompanyParentNameFont", new FontDescriptor(font));
                }
                else
                {
                    licenseParameter.Add("CompanyParentNameFont", new FontDescriptor("Times New Roman", 11, FontStyleMode.On, FontStyleMode.Off, FontStyleMode.Off, FontStyleMode.Off));
                }

                // Sửa theo template mới
                if (GlobalVariable.IsDisplayNewLicenseInfo)
                {
                    //licenseParameter.Add("CompanyName", "" + GlobalVariable.OwnerCompanyName ?? string.Empty);
                    oRsTool.Parameters.Add("CompanyName", GlobalVariable.CompanyName ?? string.Empty);
                    //licenseParameter.Add("CompanyAddress", "" + GlobalVariable.CompanyName ?? string.Empty);
                    oRsTool.Parameters.Add("CompanyAddress", GlobalVariable.CompanyAddress ?? string.Empty);
                    oRsTool.Parameters.Add("OwnerCompanyName", GlobalVariable.OwnerCompanyName ?? string.Empty);
                    oRsTool.MarginRight = 20;
                }
                else
                {
                    //licenseParameter.Add("CompanyName", "ĐƠN VỊ: " + GlobalVariable.CompanyName ?? string.Empty);
                    oRsTool.Parameters.Add("CompanyName", GlobalVariable.CompanyName ?? string.Empty);
                    oRsTool.Parameters.Add("OwnerCompanyName", GlobalVariable.OwnerCompanyName ?? string.Empty);
                    //licenseParameter.Add("CompanyCode", "Mã QHNS: " + GlobalVariable.CompanyCode ?? string.Empty);
                    //oRsTool.Parameters.Add("CompanyCode", GlobalVariable.CompanyCode ?? string.Empty);
                    if (!oRsTool.Parameters.ContainsKey("CompanyAddress"))
                        oRsTool.Parameters.Add("CompanyAddress", GlobalVariable.CompanyAddress ?? string.Empty);
                    if (!oRsTool.Parameters.ContainsKey("CompanyCode"))
                        oRsTool.Parameters.Add("CompanyCode", GlobalVariable.CompanyCode ?? string.Empty);
                }




                

                var companyNameFont = GlobalVariable.CompanyNameFont != null ? GlobalVariable.CompanyNameFont.Split(';') : null;
                if (companyNameFont != null && companyNameFont.Length != 0)
                {
                    var fontstyle = (FontStyle)System.Enum.Parse(typeof(FontStyle), companyNameFont[1], true);
                    var font = new Font(companyNameFont[0], float.Parse(companyNameFont[2]), fontstyle);
                    licenseParameter.Add("CompanyNameFont", new FontDescriptor(font));
                }
                else
                {
                    licenseParameter.Add("CompanyNameFont", new FontDescriptor("Times New Roman", 11, FontStyleMode.On, FontStyleMode.Off, FontStyleMode.Off, FontStyleMode.Off));
                }

                // Sửa theo template mới
                var companyAddressFont = GlobalVariable.CompanyAddressFont != null ? GlobalVariable.CompanyAddressFont.Split(';') : null;
                if (companyAddressFont != null && companyAddressFont.Length != 0)
                {
                    var fontstyle = (FontStyle)System.Enum.Parse(typeof(FontStyle), companyAddressFont[1], true);
                    var font = new Font(companyAddressFont[0], float.Parse(companyAddressFont[2]), fontstyle);
                    licenseParameter.Add("CompanyAddressFont", new FontDescriptor(font));
                }
                else
                {
                    licenseParameter.Add("CompanyAddressFont", new FontDescriptor("Times New Roman", 11, FontStyleMode.On, FontStyleMode.Off, FontStyleMode.Off, FontStyleMode.Off));
                }
                // Sửa theo template mới
                var companyCodeFont = GlobalVariable.CompanyCodeFont != null ? GlobalVariable.CompanyCodeFont.Split(';') : null;
                if (companyCodeFont != null && companyCodeFont.Length != 0)
                {
                    var fontstyle = (FontStyle)System.Enum.Parse(typeof(FontStyle), companyCodeFont[1], true);
                    var font = new Font(companyCodeFont[0], float.Parse(companyCodeFont[2]), fontstyle);
                    licenseParameter.Add("CompanyCodeFont", new FontDescriptor(font));
                }
                else
                {
                    licenseParameter.Add("CompanyCodeFont", new FontDescriptor("Times New Roman", 11, FontStyleMode.On, FontStyleMode.Off, FontStyleMode.Off, FontStyleMode.Off));
                }

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Designs the report template.
        /// </summary>
        /// <param name="reportPathFile">The sreportpathfile.</param>
        /// ReSharper disable once UnusedMember.Local
        public void DesignReportTemplate(string reportPathFile)
        {
            try
            {
                ReportSharpTool.ReportFileName = reportPathFile;
                ReportSharpTool.DesignReport();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary> 19006600
        /// Prints the preview report.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="reportId">The s report identifier.</param>
        /// <param name="isPrint">if set to <c>true</c> [is print].</param>
        public void PrintPreviewReport(XtraForm frmParent, string reportId, bool isPrint)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _reportListModel = ReportLists.Find(item => item.ReportId == reportId); 
                if (_reportListModel == null)
                    return;
                _frmParentForm = frmParent;
                var reportListSource = GetDataSource(frmParent, _reportListModel);
                if (reportListSource == null || reportListSource.Count < 0)
                    return;
                if (reportListSource.Count > 0)
                {
                    if (!string.IsNullOrEmpty(_reportListModel.TableName))
                    {
                        DataMember = _reportListModel.TableName.Trim();
                    }
                    DisplayReport(ref reportListSource, _reportListModel, false, frmParent, false, isPrint, DateTime.MinValue);
                    //DisplayReport(reportListSource, _reportListModel, frmParent);
                }
                else
                {
                    XtraMessageBox.Show("Dữ liệu báo cáo Không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ExtractXMLKhoBac(string reportId)
        {
            _reportListModel = ReportLists.Find(item => item.ReportId == reportId);
            if (!string.IsNullOrEmpty(_reportListModel.InputTypeName))
            {
                var type = Assembly.GetExecutingAssembly().GetType(GetType().Namespace + "." + "ExportXML");
                var target = (BaseReport)Activator.CreateInstance(type);
                if (!string.IsNullOrEmpty(_reportListModel.ProcedureName))
                {
                    var args = new object[] { ReportParameter, _rsTool ,null, false};
                    var dataSource = (IList)(type.InvokeMember(_reportListModel.FunctionReportName + "XML", BindingFlags.InvokeMethod, null, target, args));
                }
            }
        }

        /// <summary>
        /// Prints the preview report by report.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="param">The e parameter.</param>
        /// <param name="isPrint">if set to <c>true</c> [is print].</param>
        public void PrintPreviewReportByReport(XtraForm frmParent, DrilldownReportParam param, bool isPrint)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _reportListModel = ReportLists.Find(item => item.ReportId == param.ArgParameter[0].ToString());
                if (_reportListModel == null)
                    return;
                _frmParentForm = frmParent;

                var reportListSource = GetDrillDownDataSource(frmParent, _reportListModel, param.ArgParameter);
                if (reportListSource == null || reportListSource.Count <= 0)
                    return;
                if (reportListSource.Count > 0)
                {
                    if (!string.IsNullOrEmpty(_reportListModel.TableName))
                    {
                        DataMember = _reportListModel.TableName.Trim();
                    }
                    DisplayReport(ref reportListSource, _reportListModel, false, frmParent, false, isPrint, DateTime.MinValue);
                }
                else
                {
                    XtraMessageBox.Show("Dữ liệu báo cáo Không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Gets the drill down data source.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="reportList">The report list.</param>
        /// <param name="parramDrilldown">The parram drilldown.</param>
        /// <returns></returns>
        private ICollection GetDrillDownDataSource(XtraForm frmParent, ReportListModel reportList, object[] parramDrilldown)
        {
            IList dataSource = null;
            try
            {
                if (!string.IsNullOrEmpty(reportList.InputTypeName))
                {
                    var type = Assembly.GetExecutingAssembly().GetType((GetType().Namespace + "." + reportList.InputTypeName));
                    var target = (BaseReport)Activator.CreateInstance(type);
                    if (!string.IsNullOrEmpty(reportList.ProcedureName))
                    {
                        if (ReportParameter == null)
                        {
                            ReportParameter = new ReportParameter();
                        }
                        //if (CommonVariable == null)
                        //{
                        //    CommonVariable = new GlobalVariable();
                        //}
                        //CommonVariable.StoreProcedureName = reportList.ProcedureName;
                        //CommonVariable.ReportList = reportList;
                        //CommonVariable.DrillDownParram = parramDrilldown;
                        //CommonVariable.IsDrillDownReport = true;

                        var args = new object[] { ReportParameter, _rsTool , parramDrilldown };
                        dataSource = (IList)(type.InvokeMember(reportList.FunctionReportName, BindingFlags.InvokeMethod, null, target, args));
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataSource;
        }

        /// <summary>
        /// Gets the data source.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="reportList">The report list.</param>
        /// <returns></returns>
        private ICollection GetDataSource(XtraForm frmParent, ReportListModel reportList)
        {
            IList dataSource = null;
            try
            {
                if (!string.IsNullOrEmpty(reportList.InputTypeName))
                {
                    var type = Assembly.GetExecutingAssembly().GetType(GetType().Namespace + "." + reportList.InputTypeName);
                    var target = (BaseReport)Activator.CreateInstance(type);
                    if (!string.IsNullOrEmpty(reportList.ProcedureName))
                    {
                        //if (CommonVariable == null)
                        //{
                        //    CommonVariable = new GlobalVariable();
                        //}
                        //CommonVariable.StoreProcedureName = reportList.ProcedureName;
                        //CommonVariable.ReportList = reportList;
                        //CommonVariable.IsDrillDownReport = false;
                        var args = new object[] { ReportParameter, _rsTool };
                        dataSource = (IList)(type.InvokeMember(reportList.FunctionReportName, BindingFlags.InvokeMethod, null, target, args));
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataSource;
        }
        /// <summary>
        /// Displays the report.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="reportList">The report list.</param>
        /// <param name="isVoucher">if set to <c>true</c> [b is voucher].</param>
        /// <param name="frmForm">The   form.</param>
        /// <param name="isShowDialog">if set to <c>true</c> [b show dialog].</param>
        /// <param name="isPrint">if set to <c>true</c> [is print].</param>
        /// <param name="voucherDate">The d voucher date.</param>
        public void DisplayReport(ref ICollection dataSource, ReportListModel reportList, bool isVoucher, XtraForm frmForm, bool isShowDialog, bool isPrint, DateTime voucherDate)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (dataSource == null)
                    return;
                //CommonVariable = new GlobalVariable();
                var oRsTool = ReportSharpTool;
                var str = GlobalVariable.ReportPath + (string.IsNullOrEmpty(oRsTool.ReportFileName) ? reportList.ReportFile : oRsTool.ReportFileName);
                oRsTool.RssObject.VoucherDate = voucherDate;
                oRsTool.ListDataSource = dataSource;
                oRsTool.DataMember = reportList.TableName.Trim();
                oRsTool.LayoutReportPath = GlobalVariable.ReportPath;
                oRsTool.ReportFileName = str;

                if (!AddParameter(ref dataSource))
                    return;
                oRsTool.IsPrint = isPrint;
                oRsTool.ReportTitle = reportList.ReportName;
                oRsTool.ProductName = GlobalVariable.ProducName;
                oRsTool.DisplayProductName = false;
                _frmParentForm = frmForm;
                var model = new Model();
                //tam thoi comment
                CurrencyModels = model.GetCurrencies();
                NumberToWord.Currencies = new List<Currency>();
                foreach (var currencyModel in CurrencyModels)
                {
                    NumberToWord.Currencies.Add(new Currency
                    {
                        //CurrencyId = currencyModel.CurrencyId,
                        CurrencyCode = currencyModel.CurrencyCode,
                        CurrencyName = currencyModel.CurrencyName,
                        Prefix = currencyModel.Prefix,
                        Suffix = currencyModel.Suffix
                    });
                }
                oRsTool.RunReport(frmForm, isShowDialog);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString() + ex.InnerException, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #region Preview Report Using DataSet
        Dictionary<string, object> ParamReport;
        public void PreviewReportUsingDataSet(XtraForm frmParent, ReportListModel reportListModel, object[] paramStore, Dictionary<string, object> paramReport)
        {
            if (reportListModel == null)
                return;
            _frmParentForm = frmParent;
            ParamReport = paramReport;
            var dataSet = GetDataSet(frmParent, reportListModel, paramStore);
            if (dataSet == null)
                return;

            DisplayReport(dataSet, reportListModel, frmParent);
        }

        void AddParamSystem()
        {
            if (ParamReport == null)
                ParamReport = new Dictionary<string, object>();

            ParamReport.Add(nameof(GlobalVariable.PostedDate), GlobalVariable.PostedDate);
            ParamReport.Add("DayOfDateSystem", Convert.ToDateTime(GlobalVariable.PostedDate).ToString("dd"));
            ParamReport.Add("MonthOfDateSystem", Convert.ToDateTime(GlobalVariable.PostedDate).ToString("MM"));
            ParamReport.Add("YearOfDateSystem", Convert.ToDateTime(GlobalVariable.PostedDate).ToString("yyyy"));
            ParamReport.Add(nameof(GlobalVariable.CompanyReportPreparer), GlobalVariable.CompanyReportPreparer ?? string.Empty);
            ParamReport.Add(nameof(GlobalVariable.CompanyChiefAccountant), GlobalVariable.CompanyChiefAccountant ?? string.Empty);
            ParamReport.Add(nameof(GlobalVariable.CompanyDirector), GlobalVariable.CompanyDirector ?? string.Empty);
            ParamReport.Add("RepeatHeaderOnReport", true);
            ParamReport.Add(nameof(GlobalVariable.CompanyCode), CommonText.CompanyCodeTitle + GlobalVariable.CompanyCode ?? string.Empty);
            ParamReport.Add(nameof(GlobalVariable.CompanyName), CommonText.CompanyNameTitle + GlobalVariable.CompanyName ?? string.Empty);
        }

        private DataSet GetDataSet(XtraForm frmParent, ReportListModel reportList, object[] parms)
            {
            DataSet ds = new DataSet();
            if (!string.IsNullOrEmpty(reportList.InputTypeName))
            {
                var type = Assembly.GetExecutingAssembly().GetType(GetType().Namespace + "." + reportList.InputTypeName);
                var target = (BaseReport)Activator.CreateInstance(type);
                if (!string.IsNullOrEmpty(reportList.ProcedureName))
                {
                    var args = new object[] { reportList.ProcedureName, parms };
                    ds = (DataSet)(type.InvokeMember(reportList.FunctionReportName, BindingFlags.InvokeMethod, null, target, args));
                }
            }
            return ds;
        }

        public void DisplayReport(DataSet dataSource, ReportListModel reportList, XtraForm frmForm)
        {
            dataSource.DataSetName = "DataSource";
            var manager = new ReportManager();
            manager.GetReportParameter += manager_GetReportParameter;
            manager.OwnerForm = frmForm;

            if (string.IsNullOrEmpty(reportList.TableName))
                return;

            var objectPointerCollection = new ObjectPointerCollection();
            // Các table name cách nhau = dấu ;
            var _listTableName = reportList.TableName.Split(';');
            if (_listTableName.Length > dataSource.Tables.Count || (dataSource.Tables.Count > 0 && dataSource.Tables[0].Rows.Count <= 0))
            {
                XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < _listTableName.Length; i++)
            {
                DataTable dt = new DataTable();
                dt = dataSource.Tables[i];
                dt.TableName = _listTableName[i];

                var colDecimalPlaces = new DataColumn();
                colDecimalPlaces.ColumnName = nameof(TextFormat.DecimalPlaces); // Số chữ số sau dấu phẩy
                colDecimalPlaces.DataType = typeof(int);
                colDecimalPlaces.DefaultValue = ReportSharpTool?.RssObject?.CurrencyFormat?.DecimalPlaces;

                var colDecimalSeparator = new DataColumn();
                colDecimalSeparator.ColumnName = nameof(TextFormat.DecimalSeparator);
                colDecimalSeparator.DataType = typeof(string);
                colDecimalSeparator.DefaultValue = ReportSharpTool?.RssObject?.CurrencyFormat?.DecimalSeparator;

                var colGroupSeparator = new DataColumn();
                colGroupSeparator.ColumnName = nameof(TextFormat.GroupSeparator);
                colGroupSeparator.DataType = typeof(string);
                colGroupSeparator.DefaultValue = ReportSharpTool?.RssObject?.CurrencyFormat?.GroupSeparator;
                dt.Columns.AddRange(new DataColumn[] { colDecimalPlaces, colDecimalSeparator, colGroupSeparator });

                objectPointerCollection.Add(dt.TableName, dt);
            }
            //objectPointerCollection.Add(nameof(dataSource), dataSource);
            manager.DataSources = objectPointerCollection;

            var reportSlot = new FileReportSlot { FilePath = GlobalVariable.ReportPath + reportList.ReportFile };
            manager.Reports.Add(reportSlot);
            AddParamSystem();
            reportSlot.RenderDocument();
            reportSlot.Document.Name = reportList.ReportName;

            var previewForm = new PreviewForm(reportSlot);
            previewForm.WindowState = FormWindowState.Maximized;
            previewForm.ReportViewer.DocumentLoaded += ReportViewer_DocumentLoaded;
            previewForm.ShowDialog();
        }

        private void ReportViewer_DocumentLoaded(object sender, EventArgs e)
        {
            ReportViewer rv = sender as ReportViewer;
            if (rv == null)
                return;
            rv.Actions[ReportViewerActions.ActualSize].ExecuteAction();
        }

        void manager_GetReportParameter(object sender, GetReportParameterEventArgs e)
        {
            foreach (var item in ParamReport)
            {
                e.Parameters.Add(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Lí do ghi giảm TSCĐ
        /// </summary>
        /// <returns></returns>
        public static string GetDecreaseReason(int decreaseReasonId)
        {
            return ((DecreaseReason)decreaseReasonId + 1).GetDescription(); // Không hiểu viết enum làm cái gì nữa
        }

        public enum ValueDataType
        {
            StringValue = 0,
            QuantityValue = 1,
            MoneyValue = 2,
            DateValue = 3,
            BooleanValue = 4,
        }

        public static void BindingData(ref PerpetuumSoft.Reporting.DOM.TextBox control, object bindingValue, ValueDataType ValueType = ValueDataType.StringValue)
        {
            PerpetuumSoft.Framework.Text.TextFormat currencyFormat = new PerpetuumSoft.Framework.Text.TextFormat();
            currencyFormat.FormatStyle = PerpetuumSoft.Framework.Text.TextFormatStyle.Currency;
            currencyFormat.UseCultureSettings = false;
            currencyFormat.DecimalPlaces = GlobalVariable.CurrencyDecimalDigitsInReport;
            var _nfi = new NumberFormatInfo();
            currencyFormat.DecimalSeparator = _nfi.CurrencyDecimalSeparator;
            currencyFormat.GroupSeparator = _nfi.CurrencyGroupSeparator;
            switch (ValueType)
            {
                case ValueDataType.StringValue:
                    if (bindingValue != null)
                        control.Value = bindingValue;
                    break;
                case ValueDataType.QuantityValue:
                    if (bindingValue == null)
                        bindingValue = 0;
                    if (bindingValue.Equals(0))
                        control.Value = string.Empty;
                    else
                        control.Value = bindingValue;
                    control.TextFormat = currencyFormat;
                    break;
                case ValueDataType.MoneyValue:
                    if (bindingValue == null)
                        bindingValue = 0;
                    if (bindingValue.Equals(0))
                        control.Value = string.Empty;
                    else
                        control.Value = bindingValue;
                    control.TextFormat = currencyFormat;
                    control.TextFormat.CurrencySymbol = string.Empty;
                    break;
                case ValueDataType.DateValue:
                    if (bindingValue != null)
                        control.Value = Convert.ToDateTime(bindingValue).ToShortDateString();
                    break;
                case ValueDataType.BooleanValue:
                    if (bindingValue != null)
                    {
                        if (bindingValue.Equals(1))
                            control.Value = "V";
                        else
                            control.Value = string.Empty;
                    }
                    break;
            }
        }
        #endregion

        #region DataTable
        private DataTable GetDataSourceDataTable(XtraForm frmParent, ReportListModel reportList)
        {
            DataTable dataSource = null;
            try
            {
                if (!string.IsNullOrEmpty(reportList.InputTypeName))
                {
                    var type = Assembly.GetExecutingAssembly().GetType(GetType().Namespace + "." + reportList.InputTypeName);
                    var target = (BaseReport)Activator.CreateInstance(type);
                    if (!string.IsNullOrEmpty(reportList.ProcedureName))
                    {

                        var args = new object[] { ReportParameter, _rsTool };
                        dataSource = (DataTable)(type.InvokeMember(reportList.FunctionReportName, BindingFlags.InvokeMethod, null, target, args));
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra trong quá trình truy vấn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataSource;
        }

        public void DisplayReportDataTable(ref DataSet dataSource, ReportListModel reportList, bool isVoucher, XtraForm frmForm, bool isShowDialog, bool isPrint, DateTime voucherDate)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (dataSource == null)
                    return;
                //CommonVariable = new GlobalVariable();
                var oRsTool = ReportSharpTool;
                var str = GlobalVariable.ReportPath + (string.IsNullOrEmpty(oRsTool.ReportFileName) ? reportList.ReportFile : oRsTool.ReportFileName);
                oRsTool.RssObject.VoucherDate = voucherDate;
                oRsTool.DataSource = dataSource;
                oRsTool.DataMember = reportList.TableName.Trim();
                oRsTool.LayoutReportPath = GlobalVariable.ReportPath;
                oRsTool.ReportFileName = str;



                //if (!AddParameter(ref dataSource))
                // return;
                oRsTool.IsPrint = isPrint;
                oRsTool.ReportTitle = reportList.ReportName;
                oRsTool.ProductName = GlobalVariable.ProducName;
                oRsTool.DisplayProductName = true;
                _frmParentForm = frmForm;
                var model = new Model();
                //tam thoi comment
                CurrencyModels = model.GetCurrencies();
                NumberToWord.Currencies = new List<Currency>();
                foreach (var currencyModel in CurrencyModels)
                {
                    NumberToWord.Currencies.Add(new Currency
                    {
                        //CurrencyId = currencyModel.CurrencyId,
                        CurrencyCode = currencyModel.CurrencyCode,
                        CurrencyName = currencyModel.CurrencyName,
                        Prefix = currencyModel.Prefix,
                        Suffix = currencyModel.Suffix
                    });
                }
                oRsTool.RunReport(frmForm, isShowDialog);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra trong quá trình truy vấn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region RenderDynamic

        #endregion
    }
}