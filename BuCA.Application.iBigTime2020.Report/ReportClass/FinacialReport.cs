/***********************************************************************
 * <copyright file="FinacialReport.cs" company="BUCA JSC">
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
 * 10/9/2014    LinhMC               Sửa lại toàn bộ method check điều kiện nếu nạp lại dữ liệu thì ko show form param
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial;
using BuCA.Application.iBigTime2020.Report.ParameterReportForm;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraEditors;
using RSSHelper;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    /// <summary>
    ///     FinacialReport
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.ReportClass.BaseReport" />
    public class FinacialReport : BaseReport
    {
                                                        ///     Initializes a new instance of the <see cref="FinacialReport" /> class.
                                                        /// </summary>
        public FinacialReport()
        {
            Model = new Model();
        }

        /// <summary>
        ///     Bảng cân đối tài khoản
        ///     Gets the report B01 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>
        ///     IList&lt;B01HModel&gt;.
        /// </returns>
        public IList<B01HModel> GetReportB01H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            try
            {
                IList<B01HModel> list = null;
                var amountType = GlobalVariable.AmountTypeViewReport;
                var currencyCode = GlobalVariable.CurrencyViewReport;
                var reportDate = GlobalVariable.PostedDate;
                GlobalVariable.IsDisplayNewLicenseInfo = false;
                var ReportID = "";
                var accountingBooksType = GlobalVariable.AccountingBooksType;
                switch (accountingBooksType)
                {

                    case 0:
                        ReportID = "S03-H";

                        break;
                    case 1:
                        ReportID = "S01-H";
                        break;
                    case 2:
                        ReportID = "S02c-H";
                        break;
                    case 3:
                        ReportID = "S03-H";
                        break;

                }

                if (!oRsTool.IsRefresh)
                {
                    using (var frmParam = new FrmB01H())
                    {
                        if (frmParam.ShowDialog() == DialogResult.OK)
                        {
                            var startDate = new DateTime(DateTime.Parse(frmParam.FromDate).Year, 1, 1);
                            var fromDate = DateTime.Parse(frmParam.FromDate);
                            var toDate = DateTime.Parse(frmParam.ToDate);
                            var budgetSourceId = frmParam.BudgetSourceId;
                            var budgetChapterCode = frmParam.BudgetChapterCode;
                            var budgetSubKindItem = frmParam.BudgetSubKindItemCode;
                            var iAccountGrade = frmParam.AccountGrade;
                            var isSummarySource = frmParam.IsSummarySource;
                            var isSummaryChapter = string.IsNullOrEmpty(budgetChapterCode);
                            var isSummarySubKindItem = string.IsNullOrEmpty(budgetSubKindItem);
                            var pIsPrintMonth13 = frmParam.IsPrintMonth13;
                            var pIsAddDataMonth13 = frmParam.IsAddDataMonth13;
                            var pIsPrintAccountDetailByBudgetSource = frmParam.IsSummarySource;
                            var pIsPrintAccountDecided = frmParam.IsPrintAccountDecided;
                            list = Model.GetReportB01H(startDate, fromDate, toDate, budgetSourceId,
                                budgetChapterCode, budgetSubKindItem, iAccountGrade, isSummarySource, isSummaryChapter,
                                isSummarySubKindItem, pIsPrintMonth13, pIsAddDataMonth13,
                                pIsPrintAccountDetailByBudgetSource,
                                pIsPrintAccountDecided, amountType, currencyCode);

                            if (list != null && list.Count > 0)
                            {
                                foreach (var obj in list.ToList())
                                    if (obj.ClosingCredit == 0 && obj.ClosingDebit == 0 && obj.MovementAccumCredit == 0 &&
                                        obj.MovementAccumDebit == 0 && obj.MovementCredit == 0 && obj.MovementDebit == 0 &&
                                        obj.OpeningCredit == 0 && obj.OpeningDebit == 0)
                                        list.Remove(obj);
                                if (!oRsTool.Parameters.ContainsKey("IsPrintMonth13"))
                                {
                                    var isPrintMonth13 = pIsPrintMonth13
                                        ? "Tháng chỉnh lý quyết toán"
                                        : ConvertDateToStringForReport(fromDate, toDate);
                                    oRsTool.Parameters.Add("IsPrintMonth13", isPrintMonth13);
                                }
                                if (!oRsTool.Parameters.ContainsKey("IsSummaryBudgetChapterCode"))
                                    oRsTool.Parameters.Add("IsSummaryBudgetChapterCode", isSummaryChapter ? 1 : 0);

                                if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                                    oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                                    oRsTool.Parameters.Add("ReportDate", reportDate);
                                if (amountType == 1)
                                {
                                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                                        oRsTool.Parameters.Add("CurrencyCodeUnit",
                                            "Đơn vị tính (qui đổi): " + currencyCode);
                                }
                                else
                                {
                                    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                                        oRsTool.Parameters.Add("CurrencyCodeUnit",
                                            "Đơn vị tính (nguyên tệ): " + currencyCode);
                                }
                                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                                    oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                                    oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                                if (!oRsTool.Parameters.ContainsKey("ReportID"))
                                    oRsTool.Parameters.Add("ReportID", ReportID);

                                //tài khoản trong bảng
                                var totalOpeningCredit = list.Where(x => x.Grade == 1 && x.AccountCategory == 1).Sum(x => x.OpeningCredit);
                                var totalOpeningDebit = list.Where(x => x.Grade == 1 && x.AccountCategory == 1).Sum(x => x.OpeningDebit);
                                var totalMovementAccumCredit =
                                    list.Where(x => x.Grade == 1 && x.AccountCategory == 1).Sum(x => x.MovementAccumCredit);
                                var totalMovementAccumDebit = list.Where(x => x.Grade == 1 && x.AccountCategory == 1).Sum(x => x.MovementAccumDebit);
                                var totalMovementCredit = list.Where(x => x.Grade == 1 && x.AccountCategory == 1).Sum(x => x.MovementCredit);
                                var totalMovementDebit = list.Where(x => x.Grade == 1 && x.AccountCategory == 1).Sum(x => x.MovementDebit);
                                var totalClosingCredit = list.Where(x => x.Grade == 1 && x.AccountCategory == 1).Sum(x => x.ClosingCredit);
                                var totalClosingDebit = list.Where(x => x.Grade == 1 && x.AccountCategory == 1).Sum(x => x.ClosingDebit);

                                //Tài khoản ngoài bảng (AnhNT)

                                var totalOpeningCredit2 = list.Where(x => x.Grade == 1 && x.AccountCategory != 1).Sum(x => x.OpeningCredit);
                                var totalOpeningDebit2 = list.Where(x => x.Grade == 1 && x.AccountCategory != 1).Sum(x => x.OpeningDebit);
                                var totalMovementAccumCredit2 =
                                    list.Where(x => x.Grade == 1 && x.AccountCategory != 1).Sum(x => x.MovementAccumCredit);
                                var totalMovementAccumDebit2 = list.Where(x => x.Grade == 1 && x.AccountCategory != 1).Sum(x => x.MovementAccumDebit);
                                var totalMovementCredit2 = list.Where(x => x.Grade == 1 && x.AccountCategory != 1).Sum(x => x.MovementCredit);
                                var totalMovementDebit2 = list.Where(x => x.Grade == 1 && x.AccountCategory != 1).Sum(x => x.MovementDebit);
                                var totalClosingCredit2 = list.Where(x => x.Grade == 1 && x.AccountCategory != 1).Sum(x => x.ClosingCredit);
                                var totalClosingDebit2 = list.Where(x => x.Grade == 1 && x.AccountCategory != 1).Sum(x => x.ClosingDebit);
                                //-------------------------------------------

                                //Parameter tài khoản trong bảng
                                if (!oRsTool.Parameters.ContainsKey("TotalMovementCredit"))
                                    oRsTool.Parameters.Add("TotalMovementCredit",
                                        totalMovementCredit == 0 ? 0 : totalMovementCredit);
                                if (!oRsTool.Parameters.ContainsKey("TotalMovementDebit"))
                                    oRsTool.Parameters.Add("TotalMovementDebit",
                                        totalMovementDebit == 0 ? 0 : totalMovementDebit);
                                if (!oRsTool.Parameters.ContainsKey("TotalClosingCredit"))
                                    oRsTool.Parameters.Add("TotalClosingCredit",
                                        totalClosingCredit == 0 ? 0 : totalClosingCredit);
                                if (!oRsTool.Parameters.ContainsKey("TotalClosingDebit"))
                                    oRsTool.Parameters.Add("TotalClosingDebit",
                                        totalClosingDebit == 0 ? 0 : totalClosingDebit);
                                if (!oRsTool.Parameters.ContainsKey("TotalOpeningCredit"))
                                    oRsTool.Parameters.Add("TotalOpeningCredit",
                                        totalOpeningCredit == 0 ? 0 : totalOpeningCredit);
                                if (!oRsTool.Parameters.ContainsKey("TotalOpeningDebit"))
                                    oRsTool.Parameters.Add("TotalOpeningDebit",
                                        totalOpeningDebit == 0 ? 0 : totalOpeningDebit);
                                if (!oRsTool.Parameters.ContainsKey("TotalMovementAccumCredit"))
                                    oRsTool.Parameters.Add("TotalMovementAccumCredit",
                                        totalMovementAccumCredit == 0 ? 0 : totalMovementAccumCredit);
                                if (!oRsTool.Parameters.ContainsKey("TotalMovementAccumDebit"))
                                    oRsTool.Parameters.Add("TotalMovementAccumDebit",
                                        totalMovementAccumDebit == 0 ? 0 : totalMovementAccumDebit);

                                //Parameter tài khoản ngoài bảng
                                if (!oRsTool.Parameters.ContainsKey("TotalMovementCredit2"))
                                    oRsTool.Parameters.Add("TotalMovementCredit2",
                                        totalMovementCredit2 == 0 ? 0 : totalMovementCredit2);
                                if (!oRsTool.Parameters.ContainsKey("TotalMovementDebit2"))
                                    oRsTool.Parameters.Add("TotalMovementDebit2",
                                        totalMovementDebit2 == 0 ? 0 : totalMovementDebit2);
                                if (!oRsTool.Parameters.ContainsKey("TotalClosingCredit2"))
                                    oRsTool.Parameters.Add("TotalClosingCredit2",
                                        totalClosingCredit2 == 0 ? 0 : totalClosingCredit2);
                                if (!oRsTool.Parameters.ContainsKey("TotalClosingDebit2"))
                                    oRsTool.Parameters.Add("TotalClosingDebit2",
                                        totalClosingDebit2 == 0 ? 0 : totalClosingDebit2);
                                if (!oRsTool.Parameters.ContainsKey("TotalOpeningCredit2"))
                                    oRsTool.Parameters.Add("TotalOpeningCredit2",
                                        totalOpeningCredit2 == 0 ? 0 : totalOpeningCredit2);
                                if (!oRsTool.Parameters.ContainsKey("TotalOpeningDebit2"))
                                    oRsTool.Parameters.Add("TotalOpeningDebit2",
                                        totalOpeningDebit2 == 0 ? 0 : totalOpeningDebit2);
                                if (!oRsTool.Parameters.ContainsKey("TotalMovementAccumCredit2"))
                                    oRsTool.Parameters.Add("TotalMovementAccumCredit2",
                                        totalMovementAccumCredit2 == 0 ? 0 : totalMovementAccumCredit2);
                                if (!oRsTool.Parameters.ContainsKey("TotalMovementAccumDebit2"))
                                    oRsTool.Parameters.Add("TotalMovementAccumDebit2",
                                        totalMovementAccumDebit2 == 0 ? 0 : totalMovementAccumDebit2);
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Gets the report B01 BCTC.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;B01_BCTCModel&gt;.</returns>
        public IList<B01_BCTCModel> GetReportB01_BCTC(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<B01_BCTCModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            var currencyPrefix = Model.GetCurrencyByCurrencyCode(currencyCode).Prefix ??"";
            GlobalVariable.IsDisplayNewLicenseInfo = true;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFinacialReport01())
                {
                    frmParam.Text = "Báo cáo tình hình tài chính";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startdate = DateTime.Parse(frmParam.StartDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("CurrencyPrefix"))
                            oRsTool.Parameters.Add("CurrencyPrefix", currencyPrefix);

                        list = Model.GetReportB01_BCTC(startdate, fromDate, toDate, frmParam.BudgetChapterCode, frmParam.IsSummaryBudgetChapter, false, null,amountType,currencyCode);
                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Gets the report B02 BCTC.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;B02_BCTCModel&gt;.</returns>
        public IList<B02_BCTCModel> GetReportB02_BCTC(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<B02_BCTCModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var currencyPrefix = Model.GetCurrencyByCurrencyCode(currencyCode).Prefix ?? "";
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = true;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFinacialReportB02BCTC())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startdate = DateTime.Parse(frmParam.StartDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("prToDate"))
                            oRsTool.Parameters.Add("prToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("prReportDate"))
                            oRsTool.Parameters.Add("prReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("CurrencyPrefix"))
                            oRsTool.Parameters.Add("CurrencyPrefix", currencyPrefix);


                        list = Model.GetReportB02_BCTC(startdate, fromDate, toDate, frmParam.BudgetChapterCode, frmParam.IsSummaryBudgetChapter, false, null,amountType,currencyCode);
                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Gets the report B04 BCTC.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;B04_BCTCModel&gt;.</returns>
        public IList<B04_BCTCModel> GetReportB04BCTC(XtraForm frmParent, ReportSharpHelper oRsTool)
        {
            try
            {
                // Tudt comment để lấy theo mẫu cũ trước - 30/05/2020

                //List<ReportB04BCTCModel> lstResults = null;
                //var amountType = GlobalVariable.AmountTypeViewReport;
                //var currencyCode = GlobalVariable.CurrencyViewReport;
                //var reportDate = DateTime.Now;
                //var fromDate = GlobalVariable.FromDate;
                //var toDate = GlobalVariable.ToDate;
                //var periodName = string.Empty;

                //var paramater01 = string.Empty;
                //var paramater02 = string.Empty;
                //var paramater03 = string.Empty;
                //DateTime? paramater04 = null;
                //var paramater05 = string.Empty;
                //var paramater06 = string.Empty;
                //var paramater07 = string.Empty;
                //var paramater08 = string.Empty;
                //var paramater09 = string.Empty;
                //DateTime? paramater10 = null;

                //if (!oRsTool.IsRefresh)
                //{
                //    using (var frmParam = new FrmB04BCTC())
                //    {
                //        frmParam.Text = "Thuyết minh báo cáo tài chính";

                //        if (frmParam.ShowDialog() == DialogResult.OK)
                //        {
                //            fromDate = frmParam.FromDate;
                //            toDate = frmParam.ToDate;
                //            periodName = frmParam.PeriodName;

                //            paramater01 = frmParam.Paramater01;
                //            paramater02 = frmParam.Paramater02;
                //            paramater03 = frmParam.Paramater03;
                //            paramater04 = frmParam.Paramater04;
                //            paramater05 = frmParam.Paramater05;
                //            paramater06 = frmParam.Paramater06;
                //            paramater07 = frmParam.Paramater07;
                //            paramater08 = frmParam.Paramater08;
                //            paramater09 = frmParam.Paramater09;
                //            paramater10 = frmParam.Paramater10;
                //        }
                //        else
                //            return null;
                //    }
                //}

                //lstResults = Model.GetB04BCTC("uspReport_Get04_BCTC",fromDate.ToShortDateString(), toDate.ToShortDateString(), currencyCode, amountType).ToList();

                //if (!oRsTool.Parameters.ContainsKey("PostedDate"))
                //    oRsTool.Parameters.Add("PostedDate", Convert.ToDateTime(GlobalVariable.PostedDate).ToString("dd/MM/yyyy")) ;
                //if (!oRsTool.Parameters.ContainsKey("FromDate"))
                //    oRsTool.Parameters.Add("FromDate", fromDate.ToString("dd/MM/yyyy"));
                //if (!oRsTool.Parameters.ContainsKey("ToDate"))
                //    oRsTool.Parameters.Add("ToDate", toDate.ToString("dd/MM/yyyy"));
                //if (!oRsTool.Parameters.ContainsKey("PeriodName"))
                //    oRsTool.Parameters.Add("PeriodName", periodName);
                //if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                //    oRsTool.Parameters.Add("CompanyProvince", GlobalVariable.CompanyProvince);
                //if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                //    oRsTool.Parameters.Add("ReportDate", string.Format("Lập, ngày {0} tháng {1} năm {2}", reportDate.Day, reportDate.Month, reportDate.Year));
                //if (!oRsTool.Parameters.ContainsKey("DecisionNo"))
                //    oRsTool.Parameters.Add("DecisionNo", paramater01);
                //if (!oRsTool.Parameters.ContainsKey("DecisionDate"))
                //    oRsTool.Parameters.Add("DecisionDate", paramater04 == (DateTime?)null ? null : paramater04.Value.ToString("dd/MM/yyyy"));
                //if (!oRsTool.Parameters.ContainsKey("HandOverDecision"))
                //    oRsTool.Parameters.Add("HandOverDecision", paramater02);
                //if (!oRsTool.Parameters.ContainsKey("Mission"))
                //    oRsTool.Parameters.Add("Mission", paramater03);
                //if (!oRsTool.Parameters.ContainsKey("CompanyName"))
                //    oRsTool.Parameters.Add("CompanyName", GlobalVariable.CompanyName);
                //if (!oRsTool.Parameters.ContainsKey("CompanyParentName"))
                //    oRsTool.Parameters.Add("CompanyParentName", "Bộ công thương");
                //if (!oRsTool.Parameters.ContainsKey("Paramater05"))
                //    oRsTool.Parameters.Add("Paramater05", paramater05);
                //if (!oRsTool.Parameters.ContainsKey("Paramater06"))
                //    oRsTool.Parameters.Add("Paramater06", paramater06);
                //if (!oRsTool.Parameters.ContainsKey("Paramater07"))
                //    oRsTool.Parameters.Add("Paramater07", paramater07);
                //if (!oRsTool.Parameters.ContainsKey("Paramater08"))
                //    oRsTool.Parameters.Add("Paramater08", paramater08);
                //if (!oRsTool.Parameters.ContainsKey("Paramater09"))
                //    oRsTool.Parameters.Add("Paramater09", paramater09);
                //if (!oRsTool.Parameters.ContainsKey("Paramater10"))
                //    oRsTool.Parameters.Add("Paramater10", paramater10 == (DateTime?)null ? null : paramater04.Value.ToString("dd/MM/yyyy"));
                //if (amountType == 1)
                //{
                //    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                //        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
                //}
                //else
                //{
                //    if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                //        oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
                //}
                //if (!oRsTool.Parameters.ContainsKey("CurrencyNegativePattern"))
                //    oRsTool.Parameters.Add("CurrencyNegativePattern", GlobalVariable.CurrencyNegativePattern);

                //return lstResults;

                IList<B04_BCTCModel> list = null;
                var amountType = GlobalVariable.AmountTypeViewReport;
                var currencyCode = GlobalVariable.CurrencyViewReport;
                var reportDate = GlobalVariable.PostedDate;
                GlobalVariable.IsDisplayNewLicenseInfo = true;
                if (!oRsTool.IsRefresh)
                {
                    using (var frmParam = new FrmFinacialReport01())
                    {
                        if (frmParam.ShowDialog() == DialogResult.OK)
                        {
                            var fromDate = DateTime.Parse(frmParam.FromDate);
                            var toDate = DateTime.Parse(frmParam.ToDate);
                            var startdate = DateTime.Parse(frmParam.StartDate);
                            if (!oRsTool.Parameters.ContainsKey("FromDate"))
                                oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                            if (!oRsTool.Parameters.ContainsKey("ToDate"))
                                oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                            if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                                oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                            if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                                oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                            list = Model.GetReportB04_BCTC(startdate, fromDate, toDate, frmParam.BudgetChapterCode, frmParam.IsSummaryBudgetChapter, false, null);
                        }
                        else
                        {
                            list = null;
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Gets the report B05 BCTC.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;B05_BCTCModel&gt;.</returns>
        public IList<B05_BCTCModel> GetReportB05_BCTC(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<B05_BCTCModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = true;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFinacialReport01())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startdate = DateTime.Parse(frmParam.StartDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        list = Model.GetReportB05_BCTC(startdate, fromDate, toDate, frmParam.BudgetChapterCode, frmParam.IsSummaryBudgetChapter);
                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Gets the report b03a_ BCTC.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList{B03a_BCTCModel}.</returns>
        public IList<B03a_BCTCModel> GetReportB03a_BCTC(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<B03a_BCTCModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            var currencyPrefix = Model.GetCurrencyByCurrencyCode(currencyCode).Prefix ?? "";
            GlobalVariable.IsDisplayNewLicenseInfo = true;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFinancialReportB03aBCTC())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startdate = DateTime.Parse(frmParam.StartDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("CurrencyPrefix"))
                            oRsTool.Parameters.Add("CurrencyPrefix", currencyPrefix);
                        list = Model.GetReportB03a_BCTC(startdate, fromDate, toDate, frmParam.BudgetChapterCode, frmParam.IsSummaryBudgetChapter, false, null,amountType,currencyCode);
                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            return list;
        }

        public IList<B03b_BCTCModel> GetReportB03b_BCTC(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<B03b_BCTCModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = true;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFinancialReportB03aBCTC())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startdate = DateTime.Parse(frmParam.StartDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        list = Model.GetReportB03b_BCTC(startdate, fromDate, toDate, frmParam.BudgetChapterCode, frmParam.IsSummaryBudgetChapter, amountType, currencyCode);
                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            return list;
        }
    }
}