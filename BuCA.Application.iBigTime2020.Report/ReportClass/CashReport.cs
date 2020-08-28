/***********************************************************************
 * <copyright file="CashReport.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, November 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, November 30, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Cash;
using BuCA.Application.iBigTime2020.Report.ParameterReportForm;
using BuCA.Application.iBigTime2020.Session;
using RSSHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Ledger;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    /// <summary>
    /// Class CashReport.
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.ReportClass.BaseReport" />
    public class CashReport : BaseReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashReport"/> class.
        /// </summary>
        public CashReport()
        {
            Model = new Model();
        }

        /// <summary>
        /// Gets the report S22 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;CashInBankConfirmationBalanceSheetModel&gt;.</returns>
        public IList<CashInBankConfirmationBalanceSheetModel> GetCashInBankConfirmationBalanceSheet(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<CashInBankConfirmationBalanceSheetModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmCash05())
                {
                    GlobalVariable.IsDisplayNewLicenseInfo = false;
                    frmParam.Text = @"Bảng xác nhận số dư tài khoản tiền gửi tại KBNN";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        if (frmParam.selectReport == 1)
                        {
                            oRsTool.ReportFileName = "CashInBankConfirmationBalanceSheetTT61.rst";
                        }
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyCode"))
                            oRsTool.Parameters.Add("CompanyCode", string.IsNullOrEmpty(GlobalVariable.CompanyCode) ? string.Empty : GlobalVariable.CompanyCode);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("OpenningBalance112"))
                            oRsTool.Parameters.Add("OpenningBalance112", frmParam.OpenningBalance112);
                        if (!oRsTool.Parameters.ContainsKey("MovementDebit112"))
                            oRsTool.Parameters.Add("MovementDebit112", frmParam.MovementDebit112);
                        if (!oRsTool.Parameters.ContainsKey("MovementCredit112"))
                            oRsTool.Parameters.Add("MovementCredit112", frmParam.MovementCredit112);
                        if (!oRsTool.Parameters.ContainsKey("ClosingBalance112"))
                            oRsTool.Parameters.Add("ClosingBalance112", frmParam.ClosingBalance112);

                        if (!oRsTool.Parameters.ContainsKey("IsRenderKBNN"))
                            oRsTool.Parameters.Add("IsRenderKBNN", frmParam.IsRenderKBNN);

                        reports = Model.GetCashInBankConfirmationBalanceSheet(fromDate, toDate, frmParam.BankAccount, frmParam.ProjectID, frmParam.IsSummaryProject);

                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// Gets the N02 SDKP DVDT t T77.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;N02_SDKP_DVDT_TT77Model&gt;.</returns>
        public IList<N02_SDKP_DVDT_TT77Model> GetN02_SDKP_DVDT_TT77(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<N02_SDKP_DVDT_TT77Model> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFinance())
                {
                    GlobalVariable.IsDisplayNewLicenseInfo = false;
                    frmParam.Text = @"Bảng đối chiếu tình hình sử dụng kinh phí tại KBNN";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        if (frmParam.selectReport == 1)
                        {
                            oRsTool.ReportFileName = "N02_SDKP_DVDT_TT61.rst";
                        }
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyCode"))
                            oRsTool.Parameters.Add("CompanyCode", string.IsNullOrEmpty(GlobalVariable.CompanyCode) ? string.Empty : GlobalVariable.CompanyCode);

                        reports = Model.GetN02_SDKP_DVDT_TT77(DateTime.Parse(GlobalVariable.SystemDate), DateTime.Parse(GlobalVariable.SystemDate),
                            fromDate, toDate, frmParam.ListBudgetSourceId, frmParam.BudgetChapterCode,
                            frmParam.BudgetSubKindItemCode,
                            frmParam.MethodDistributeId, frmParam.ExpendKind, null, frmParam.IsSummaryBudgetSource,
                            frmParam.IsSummaryBudgetChapter, frmParam.IsSummaryBudgetSubKindItem,
                            frmParam.SummaryMethodDistribute, true, false, false);

                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// Gets the N01 SDKP DVDT.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;N01_SDKP_DVDTModel&gt;.</returns>
        public IList<N01_SDKP_DVDTModel> GetN01_SDKP_DVDT(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<N01_SDKP_DVDTModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFinance01())
                {
                    GlobalVariable.IsDisplayNewLicenseInfo = false;
                    frmParam.Text = @"Bảng đối chiếu dự toán kinh phí ngân sách tại KBNN";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var isPrintMonth13 = frmParam.IsPrintMonth13;
                        var isStateTreasury = frmParam.IsStateTreasury;
                        if (frmParam.selectReport == 1)
                        {
                            oRsTool.ReportFileName = "N01_SDKP_DVDT_TT61.rst";
                        }
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("isPrintMonth13"))
                            oRsTool.Parameters.Add("isPrintMonth13", isPrintMonth13);
                        if (!oRsTool.Parameters.ContainsKey("IsStateTreasury"))
                            oRsTool.Parameters.Add("IsStateTreasury", isStateTreasury);
                        if (!oRsTool.Parameters.ContainsKey("CompanyCode"))
                            oRsTool.Parameters.Add("CompanyCode", string.IsNullOrEmpty(GlobalVariable.CompanyCode) ? string.Empty : GlobalVariable.CompanyCode);
                        reports = Model.GetN01_SDKP_DVDT(DateTime.Parse(GlobalVariable.SystemDate), DateTime.Parse(GlobalVariable.SystemDate),
                            fromDate, toDate, frmParam.ListBudgetSourceId, frmParam.BudgetChapterCode,
                            frmParam.BudgetSubKindItemCode,
                            frmParam.MethodDistributeId, "0", frmParam.IsSummaryBudgetSource,
                            frmParam.IsSummaryBudgetChapter, frmParam.IsSummaryBudgetSubKindItem,
                            true, false, isPrintMonth13, false, isStateTreasury);

                    }
                }
            }
            return reports;
        }

        public IList<S01HLedgerModel> GetReportS01HLedger(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S01HLedgerModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            var isTotalBandInNewPage = false;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS03H())
                {
                    GlobalVariable.IsDisplayNewLicenseInfo = false;
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

                        list = Model.GetReportS01HLedger(fromDate, fromDate, toDate, frmParam.AddSameEntry,
                            frmParam.BudgetSourceCode, frmParam.BudgetChapterCode, frmParam.BudgetKindItemCode,
                            frmParam.IsSummaryBudgetSource, frmParam.IsSummaryBudgetChapter,
                            frmParam.IsSummaryBudgetSubKindItem, frmParam.AccountList, frmParam.IsPrintMonth13, frmParam.IsPrintAllYearAndMonth13);
                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            return list;
        }

        public IList<S01HLedgerModel> GetReportS01HLedger(ReportParameter reportParameter, ReportSharpHelper oRsTool, object [] param = null)
        {
            IList<S01HLedgerModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            var isTotalBandInNewPage = false;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                GlobalVariable.IsDisplayNewLicenseInfo = false;
                if (param != null)
                {
                    var fromDate = DateTime.Parse(param[2].ToString());
                    var toDate = DateTime.Parse(param[3].ToString());
                    if (!oRsTool.Parameters.ContainsKey("FromDate"))
                        oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                    if (!oRsTool.Parameters.ContainsKey("ToDate"))
                        oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                    if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                        oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                    if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                        oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                    list = Model.GetReportS01HLedger(fromDate, fromDate, toDate, false,
                         ",00000000-0000-0000-0000-000000000000,", null, null,
                       true, true,
                        true, "," + param[1].ToString() + ",", false, false);
                }
                else
                {
                    list = null;
                }
            }
            return list;
        }
    }
}
