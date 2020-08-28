/***********************************************************************
 * <copyright file="DepositReport.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.ParameterReportForm;
using BuCA.Application.iBigTime2020.Session;
using RSSHelper;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    /// <summary>
    /// DepositReport
    /// </summary>
    public class DepositReport : BaseReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepositReport"/> class.
        /// </summary>
        public DepositReport()
        {
            Model = new Model();
        }

        /// <summary>
        /// Gets the cash report S11 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;CashReportModel&gt;.</returns>
        public IList<S12HModel> ReportS12H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S12HModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            //var isTotalBandInNewPage = false;

            var fromDate = DateTime.Now;
            var toDate = DateTime.Now;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS12H())
                {
                    frmParam.Text = @"S12-H: Sổ tiền gửi ngân hàng, kho bạc";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var startDate = DateTime.Parse(frmParam.StartDate);
                        fromDate = DateTime.Parse(frmParam.FromDate);
                        toDate = DateTime.Parse(frmParam.ToDate);

                        //isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        //var accountNumber = frmParam.AccountCode;
                        //if (!oRsTool.Parameters.ContainsKey("Account"))
                        //    oRsTool.Parameters.Add("Account",
                        //        "Tài khoản: " + accountNumber + " - " + frmParam.AccountName);
                        //if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                        //    oRsTool.Parameters.Add("AccountNumber", accountNumber);
                        if (!oRsTool.Parameters.ContainsKey("IsDetail"))
                            oRsTool.Parameters.Add("IsDetail", frmParam.IsDetail);

                        reports = Model.ReportS12H(startDate, fromDate, toDate, frmParam.BudgetChapterCode, frmParam.BudgetSubKindItemCode,
                            frmParam.AccountNumber, frmParam.BankId, frmParam.IsSummaryBankId,
                            frmParam.IsSummaryBudgetChapter, frmParam.IsSummaryBudgetSubKindItem,frmParam.IsDetail, amountType, currencyCode);
                    }
                }
            }
            //else
            //{
            //    var accountNumber = oRsTool.Parameters["AccountNumber"].ToString();
            //    list = Model.GetCashS12HWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(),
            //                GlobalVariable.ToDate.ToShortDateString(), amountType, accountNumber, currencyCode, false, null);
            //}

            if (reports != null && reports.Count > 0)
            {
                //if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))

                //    oRsTool.Parameters.Add("CurrencyCodeUnit",
                //        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);

                //if (!oRsTool.Parameters.ContainsKey("Year"))
                //    oRsTool.Parameters.Add("Year", "Năm:" + GlobalVariable.ToDate.Year);

                if (!oRsTool.Parameters.ContainsKey("FromDate"))
                    oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());

                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());

                //if (!oRsTool.Parameters.ContainsKey("Province"))
                //    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);

                //if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                //    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);

                //// ThoDD add trạng thái chuyển sang trang sau
                //if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                //    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                ////làm Footer  để có cấu trúc sang trang
                //if (!oRsTool.Parameters.ContainsKey("footClosing"))
                //    oRsTool.Parameters.Add("footClosing", list[list.Count - 1].RestAmount);
                //list.RemoveAt(list.Count - 1);
                //if (!oRsTool.Parameters.ContainsKey("footReceipt"))
                //    oRsTool.Parameters.Add("footReceipt", list[list.Count - 1].ReceiptAmount);
                //if (!oRsTool.Parameters.ContainsKey("footPay"))
                //    oRsTool.Parameters.Add("footPay", list[list.Count - 1].PayAmount);
                //if (!oRsTool.Parameters.ContainsKey("footExist"))
                //    oRsTool.Parameters.Add("footExist", list[list.Count - 1].RestAmount);

                //list.RemoveAt(list.Count - 1);
                //list.RemoveAt(list.Count - 1);

            }
            return reports;
        }

        /// <summary>
        /// Reports the S12 h detail.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;S12HDetailModel&gt;.</returns>
        public IList<S12HDetailModel> ReportS12HDetail(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S12HDetailModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            //var amountType = GlobalVariable.AmountTypeViewReport;
            //var currencyCode = GlobalVariable.CurrencyViewReport;
            //var isTotalBandInNewPage = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS12HDetail())
                {
                    frmParam.Text = @"S12-H: Sổ chi tiết tiền gửi ngân hàng, kho bạc";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var startDate = DateTime.Parse(frmParam.StartDate);
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);

                        //isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
                        //var accountNumber = frmParam.AccountCode;
                        //if (!oRsTool.Parameters.ContainsKey("Account"))
                        //    oRsTool.Parameters.Add("Account",
                        //        "Tài khoản: " + accountNumber + " - " + frmParam.AccountName);
                        //if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                        //    oRsTool.Parameters.Add("AccountNumber", accountNumber);

                        reports = Model.ReportS12HDetail(startDate, fromDate, toDate, frmParam.BudgetChapterCode, frmParam.BudgetSubKindItemCode,
                            frmParam.AccountNumber, frmParam.BankId, frmParam.IsSummaryBankId,
                            frmParam.IsSummaryBudgetChapter, frmParam.IsSummaryBudgetSubKindItem);
                    }
                }
            }
            //else
            //{
            //    var accountNumber = oRsTool.Parameters["AccountNumber"].ToString();
            //    list = Model.GetCashS12HWithStoreProdure(commonVariable.ReportList.ProcedureName, GlobalVariable.FromDate.ToShortDateString(),
            //                GlobalVariable.ToDate.ToShortDateString(), amountType, accountNumber, currencyCode, false, null);
            //}

            if (reports != null && reports.Count > 0)
            {
                //if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))

                //    oRsTool.Parameters.Add("CurrencyCodeUnit",
                //        "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);

                //if (!oRsTool.Parameters.ContainsKey("Year"))
                //    oRsTool.Parameters.Add("Year", "Năm:" + GlobalVariable.ToDate.Year);

                //if (!oRsTool.Parameters.ContainsKey("FromDate"))
                //    oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());

                //if (!oRsTool.Parameters.ContainsKey("ToDate"))
                //    oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

                //if (!oRsTool.Parameters.ContainsKey("Province"))
                //    oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);

                //if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                //    oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);

                //// ThoDD add trạng thái chuyển sang trang sau
                //if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
                //    oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

                ////làm Footer  để có cấu trúc sang trang
                //if (!oRsTool.Parameters.ContainsKey("footClosing"))
                //    oRsTool.Parameters.Add("footClosing", list[list.Count - 1].RestAmount);
                //list.RemoveAt(list.Count - 1);
                //if (!oRsTool.Parameters.ContainsKey("footReceipt"))
                //    oRsTool.Parameters.Add("footReceipt", list[list.Count - 1].ReceiptAmount);
                //if (!oRsTool.Parameters.ContainsKey("footPay"))
                //    oRsTool.Parameters.Add("footPay", list[list.Count - 1].PayAmount);
                //if (!oRsTool.Parameters.ContainsKey("footExist"))
                //    oRsTool.Parameters.Add("footExist", list[list.Count - 1].RestAmount);

                //list.RemoveAt(list.Count - 1);
                //list.RemoveAt(list.Count - 1);

            }
            return reports;
        }

        /// <summary>
        /// Reports the S11 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;S11HModel&gt;.</returns>
        /// 

        public IList<S11HModel> ReportS11H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S11HModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {

                using (var frmParam = new FrmS11H())
                {
                    frmParam.Text = @"S11-H: Sổ tiền mặt";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {

                        var startDate = DateTime.Parse(frmParam.StartDate);
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var isbudgetchapter = "";
                        if (frmParam.IsSummaryBudgetChapter != true)
                            isbudgetchapter = "0";
                        else isbudgetchapter = "1";

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("IsBudgetChapter"))
                            oRsTool.Parameters.Add("IsBudgetChapter", isbudgetchapter);
                        if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                            oRsTool.Parameters.Add("AccountNumber", frmParam.Account);
                        if (!oRsTool.Parameters.ContainsKey("IsDetail"))
                            oRsTool.Parameters.Add("IsDetail", frmParam.IsDetailMonth);

                        reports = Model.ReportS11H(startDate, fromDate, toDate, frmParam.BudgetChapterCode,
                                frmParam.BudgetSubKindItemCode,
                                frmParam.AccountNumber, frmParam.IsSummaryBudgetChapter,
                                frmParam.IsSummaryBudgetSubKindItem, frmParam.IsSummaryBudgetSource, true,
                                frmParam.ListBudgetSourceId,frmParam.IsDetail,frmParam.IsDetailMonth, GlobalVariable.AmountTypeViewReport, GlobalVariable.CurrencyViewReport);
                    }


                }


            }


            return reports;
        }


        public IList<S11HDetailModel> ReportS11HDetail(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S11HDetailModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            //var amountType = GlobalVariable.AmountTypeViewReport;
            //var currencyCode = GlobalVariable.CurrencyViewReport;
            //var isTotalBandInNewPage = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS11HDetail())

                {
                    frmParam.Text = @"S11-H: Sổ chi tiết tiền mặt";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var startDate = DateTime.Parse(frmParam.StartDate);
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var isbudgetchapter = "";
                        if (frmParam.IsSummaryBudgetChapter != true)
                            isbudgetchapter = "0";
                        else isbudgetchapter = "1";

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("IsBudgetChapter"))
                            oRsTool.Parameters.Add("IsBudgetChapter", isbudgetchapter);


                        reports = Model.ReportS11HDetail(startDate, fromDate, toDate, frmParam.BudgetChapterCode, frmParam.BudgetSubKindItemCode,
                            frmParam.AccountNumber, frmParam.IsSummaryBudgetChapter, frmParam.IsSummaryBudgetSubKindItem);
                    }
                }
            }

            return reports;
        }
    }
}
