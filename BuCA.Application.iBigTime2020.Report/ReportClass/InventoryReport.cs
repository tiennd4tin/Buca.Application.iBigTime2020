using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Inventory;
using BuCA.Application.iBigTime2020.Report.ParameterReportForm;
using BuCA.Application.iBigTime2020.Session;
using RSSHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    /// <summary>
    /// Class InventoryReport.
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.ReportClass.BaseReport" />
    public class InventoryReport : BaseReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryReport"/> class.
        /// </summary>
        public InventoryReport()
        {
            Model = new Model();
        }

        /// <summary>
        /// Reports the S11 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;S22HModel&gt;.</returns>
        public IList<S22HModel> GetReportS22H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S22HModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS22H(true,true))
                {                    
                    frmParam.Text = @"Sổ chi tiết nguyên liệu, vật liệu, CCDC";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);

                        if (!oRsTool.Parameters.ContainsKey("isGroupByInventoryItem"))
                            oRsTool.Parameters.Add("isGroupByInventoryItem", frmParam.isGroupByInventoryItem);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());

                        string _InventoryItem = frmParam.InventoryItemIds == ""
                            ? frmParam.AllInventoryItemIds
                            : frmParam.InventoryItemIds;
                        reports = Model.GetReportS22H(fromDate, toDate, frmParam.StockId, _InventoryItem, frmParam.AccountNumber, GlobalVariable.AmountTypeViewReport, GlobalVariable.CurrencyViewReport);

                        // check để group theo đối tượng
                        if (frmParam.isGroupByInventoryItem)
                        {
                            foreach (var report in reports)
                            {
                                report.GroupName = report.AccountNumber + report.StockCode + report.InventoryItemCode;
                                report.GroupDetail = "1";
                            }
                        }
                        else
                        {
                            foreach (var report in reports)
                            {
                                report.GroupName = report.AccountNumber + report.StockCode;
                                report.GroupDetail = report.InventoryItemCode;
                            }
                        }
                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// Reports the S21 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;S22HModel&gt;.</returns>
        public IList<S21HModel> GetReportS21H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S21HModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS21H(false,true))
                {
                    frmParam.Text = @"Sổ kho";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if(!oRsTool.Parameters.ContainsKey("IsDetailMonth"))
                        oRsTool.Parameters.Add("IsDetailMonth", frmParam.IsDetailMonth);
                        reports = Model.GetReportS21H(fromDate, toDate, frmParam.StockId, frmParam.InventoryIDs,frmParam.IsDetailMonth);
                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// Gets the report S23 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;S23HModel&gt;.</returns>
        public IList<S23HModel> GetReportS23H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S23HModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS22H(true, false))
                {
                    frmParam.Text = @"Bảng tổng hợp chi tiết nguyên liệu vật liệu, CCDC, SPHH";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());

                        string _InventoryItem = frmParam.InventoryItemIds == ""
                            ? frmParam.AllInventoryItemIds
                            : frmParam.InventoryItemIds;

                        reports = Model.GetReportS23H(fromDate, toDate, _InventoryItem, frmParam.AccountNumber);
                    }
                }
            }
            return reports;
        }

        public IList<InventoryBookModel> GetInventoryBook(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<InventoryBookModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS22H(false, true))
                {
                    frmParam.Text = @"Báo cáo tồn kho";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        reports = Model.GetInventoryBook(fromDate, toDate, frmParam.StockId, frmParam.InventoryIDs);
                    }
                }
            }
            return reports;
        }

        public IList<ToolIncrementDecrementModel> ReportToolIncrementDecrement(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<ToolIncrementDecrementModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmToolIncreDecre())
                {
                    frmParam.Text = @"Báo cáo tình hình tăng giảm CCDC";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        string _ItemsList = frmParam.InventoryItemsList == ","
                            ? frmParam.AllInventoryItemsList
                            : frmParam.InventoryItemsList;
                        reports = Model.ReportToolIncrementDecrement(fromDate, toDate, frmParam.DepartmentId, _ItemsList);
                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// Gets the report S26 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;S26HModel&gt;.</returns>
        public IList<S26HModel> GetReportS26H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S26HModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS26H())
                {
                    frmParam.Text = @"S26-H: Sổ theo dõi CCDC tại nơi sử dụng";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("GroupByFACategory"))
                            oRsTool.Parameters.Add("GroupByFACategory", frmParam.GroupByFACategory);

                        reports = Model.GetReportS26H(fromDate,toDate,frmParam.InventoryItemCategoryId, frmParam.InventoryIDs, GlobalVariable.AmountTypeViewReport, GlobalVariable.CurrencyViewReport);
                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// Gets the minutes inventory tool.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;MinutesInventoryToolModel&gt;.</returns>
        public IList<MinutesInventoryTool> GetMinutesInventoryTool(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<MinutesInventoryTool> listMaster = null;
            IList<Minutes> listMinutes = null;
            IList<MinutesInventoryToolModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmMinutesInventoryTool())
                {
                    frmParam.Text = @"Biên bản kiểm kê CCDC";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("GroupByFACategory"))
                            oRsTool.Parameters.Add("GroupByFACategory", frmParam.GroupByFACategory);
                        // lấy dữ liệu báo cáo
                        reports = Model.GetMinutesInventoryTool(fromDate, toDate, frmParam.DepartmentId, frmParam.MinutesEuqalBook, frmParam.InventoryItemCategoryId,frmParam.SumInventoryCategory);
                        if (reports.Count > 0)
                        {
                            listMaster = new List<MinutesInventoryTool>();
                            // Lấy biên bản kiểm kê
                            //if(frmParam.listMinutes != null)
                            listMinutes = frmParam.listMinutes;

                            MinutesInventoryTool master = new MinutesInventoryTool()
                            {
                                refId = 1,
                                listMinutes = listMinutes,
                                MinutesInventoryTools = reports,
                            };
                            listMaster.Add(master);
                        }
                        else
                        {
                            listMaster = new List<MinutesInventoryTool>();
                        }
                    }
                    //else
                    //{
                    //    listMaster = null;
                    //}
                }
            }
            return listMaster;
        }
    }
}
