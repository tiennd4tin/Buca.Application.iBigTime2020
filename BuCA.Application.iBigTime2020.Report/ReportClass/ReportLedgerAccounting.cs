
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.ParameterReportForm;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Ledger;
using RSSHelper;
using System.Reflection;
using System.Linq;
using DevExpress.XtraEditors;
using PerpetuumSoft.Framework.Drawing;
using PerpetuumSoft.Reporting.DOM;
using PerpetuumSoft.Reporting.Components;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    /// <summary>
    /// ReportLedgerAccounting
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.ReportClass.BaseReport" />
    public class ReportLedgerAccounting : BaseReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportLedgerAccounting" /> class.
        /// </summary>
        public ReportLedgerAccounting()
        {
            Model = new Model();
        }

        /// <summary>
        /// Gets the report S04 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>
        /// System.Collections.Generic.IList&lt;Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial.S04HModel&gt;.
        /// </returns>
        public IList<S04HModel> GetReportS04H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S04HModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS04H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());

                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());

                        list = Model.GetReportS04H(fromDate, toDate, frmParam.AddSameEntry, frmParam.BudgetSourceCode, frmParam.BudgetChapterCode, frmParam.BudgetKindItemCode, frmParam.IsSummaryBudgetSource,
                            frmParam.IsSummaryBudgetChapter, frmParam.IsSummaryBudgetSubKindItem, amountType, currencyCode);
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
        /// Sổ chi phí đầu tư xây dựng
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<S27Model> GetReportS27(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S27Model> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS27())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var budgetSourceList = frmParam.BudgetSourceCode;
                        var accountNumber = frmParam.AccountNumber;
                        var projectlist = frmParam.ProjectIdList;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());

                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());

                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", reportDate);

                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        if (!oRsTool.Parameters.ContainsKey("UnitCalcName"))
                            oRsTool.Parameters.Add("UnitCalcName", GlobalVariable.CurrencyViewReport);

                        if (!oRsTool.Parameters.ContainsKey("Year"))
                            oRsTool.Parameters.Add("Year", DateTime.Parse(frmParam.ToDate).Year);

                        list = Model.GetReportS27(fromDate, toDate, frmParam.AccountNumber, currencyCode,
                            frmParam.BudgetSourceCode, frmParam.ProjectIdList, amountType);

                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            else
            {
                return null;
            }

            if (list != null)
            {
                decimal totalOpen = list.Where(x => x.OrderNumber == -1).Sum(x => x.TotalExpend);
                decimal open101 = list.Where(x => x.OrderNumber == -1).Sum(x => x.Expend101);
                decimal open102 = list.Where(x => x.OrderNumber == -1).Sum(x => x.Expend102);
                decimal open103 = list.Where(x => x.OrderNumber == -1).Sum(x => x.Expend103);
                decimal open104 = list.Where(x => x.OrderNumber == -1).Sum(x => x.Expend104);
                decimal open105 = list.Where(x => x.OrderNumber == -1).Sum(x => x.Expend105);
                decimal open106 = list.Where(x => x.OrderNumber == -1).Sum(x => x.Expend106);


                if (!oRsTool.Parameters.ContainsKey("TotalOpen"))
                    oRsTool.Parameters.Add("TotalOpen", totalOpen);
                if (!oRsTool.Parameters.ContainsKey("Open101"))
                    oRsTool.Parameters.Add("Open101", open101);
                if (!oRsTool.Parameters.ContainsKey("Open102"))
                    oRsTool.Parameters.Add("Open102", open102);
                if (!oRsTool.Parameters.ContainsKey("Open103"))
                    oRsTool.Parameters.Add("Open103", open103);
                if (!oRsTool.Parameters.ContainsKey("Open104"))
                    oRsTool.Parameters.Add("Open104", open104);
                if (!oRsTool.Parameters.ContainsKey("Open105"))
                    oRsTool.Parameters.Add("Open105", open105);
                if (!oRsTool.Parameters.ContainsKey("Open106"))
                    oRsTool.Parameters.Add("Open106", open106);

                decimal totalMovement = list.Where(x => x.OrderNumber == 2).Sum(x => x.TotalExpend);
                decimal movement101 = list.Where(x => x.OrderNumber == 2).Sum(x => x.Expend101);
                decimal movement102 = list.Where(x => x.OrderNumber == 2).Sum(x => x.Expend102);
                decimal movement103 = list.Where(x => x.OrderNumber == 2).Sum(x => x.Expend103);
                decimal movement104 = list.Where(x => x.OrderNumber == 2).Sum(x => x.Expend104);
                decimal movement105 = list.Where(x => x.OrderNumber == 2).Sum(x => x.Expend105);
                decimal movement106 = list.Where(x => x.OrderNumber == 2).Sum(x => x.Expend106);

                if (!oRsTool.Parameters.ContainsKey("TotalMovement"))
                    oRsTool.Parameters.Add("TotalMovement", totalMovement);
                if (!oRsTool.Parameters.ContainsKey("Movement101"))
                    oRsTool.Parameters.Add("Movement101", movement101);
                if (!oRsTool.Parameters.ContainsKey("Movement102"))
                    oRsTool.Parameters.Add("Movement102", movement102);
                if (!oRsTool.Parameters.ContainsKey("Movement103"))
                    oRsTool.Parameters.Add("Movement103", movement103);
                if (!oRsTool.Parameters.ContainsKey("Movement104"))
                    oRsTool.Parameters.Add("Movement104", movement104);
                if (!oRsTool.Parameters.ContainsKey("Movement105"))
                    oRsTool.Parameters.Add("Movement105", movement105);
                if (!oRsTool.Parameters.ContainsKey("Movement106"))
                    oRsTool.Parameters.Add("Movement106", movement106);


                decimal totalAccumlate = list.Where(x => x.OrderNumber == 3).Sum(x => x.TotalExpend);
                decimal accumlate101 = list.Where(x => x.OrderNumber == 3).Sum(x => x.Expend101);
                decimal accumlate102 = list.Where(x => x.OrderNumber == 3).Sum(x => x.Expend102);
                decimal accumlate103 = list.Where(x => x.OrderNumber == 3).Sum(x => x.Expend103);
                decimal accumlate104 = list.Where(x => x.OrderNumber == 3).Sum(x => x.Expend104);
                decimal accumlate105 = list.Where(x => x.OrderNumber == 3).Sum(x => x.Expend105);
                decimal accumlate106 = list.Where(x => x.OrderNumber == 3).Sum(x => x.Expend106);

                if (!oRsTool.Parameters.ContainsKey("TotalAccumlate"))
                    oRsTool.Parameters.Add("TotalAccumlate", totalAccumlate);
                if (!oRsTool.Parameters.ContainsKey("Accumlate101"))
                    oRsTool.Parameters.Add("Accumlate101", accumlate101);
                if (!oRsTool.Parameters.ContainsKey("Accumlate102"))
                    oRsTool.Parameters.Add("Accumlate102", accumlate102);
                if (!oRsTool.Parameters.ContainsKey("Accumlate103"))
                    oRsTool.Parameters.Add("Accumlate103", accumlate103);
                if (!oRsTool.Parameters.ContainsKey("Accumlate104"))
                    oRsTool.Parameters.Add("Accumlate104", accumlate104);
                if (!oRsTool.Parameters.ContainsKey("Accumlate105"))
                    oRsTool.Parameters.Add("Accumlate105", accumlate105);
                if (!oRsTool.Parameters.ContainsKey("Accumlate106"))
                    oRsTool.Parameters.Add("Accumlate106", accumlate106);


                decimal totalClosing = list.Where(x => x.OrderNumber == 4).Sum(x => x.TotalExpend);
                decimal closing101 = list.Where(x => x.OrderNumber == 4).Sum(x => x.Expend101);
                decimal closing102 = list.Where(x => x.OrderNumber == 4).Sum(x => x.Expend102);
                decimal closing103 = list.Where(x => x.OrderNumber == 4).Sum(x => x.Expend103);
                decimal closing104 = list.Where(x => x.OrderNumber == 4).Sum(x => x.Expend104);
                decimal closing105 = list.Where(x => x.OrderNumber == 4).Sum(x => x.Expend105);
                decimal closing106 = list.Where(x => x.OrderNumber == 4).Sum(x => x.Expend106);

                if (!oRsTool.Parameters.ContainsKey("TotalClosing"))
                    oRsTool.Parameters.Add("TotalClosing", totalClosing);
                if (!oRsTool.Parameters.ContainsKey("Closing101"))
                    oRsTool.Parameters.Add("Closing101", closing101);
                if (!oRsTool.Parameters.ContainsKey("Closing102"))
                    oRsTool.Parameters.Add("Closing102", closing102);
                if (!oRsTool.Parameters.ContainsKey("Closing103"))
                    oRsTool.Parameters.Add("Closing103", closing103);
                if (!oRsTool.Parameters.ContainsKey("Closing104"))
                    oRsTool.Parameters.Add("Closing104", closing104);
                if (!oRsTool.Parameters.ContainsKey("Closing105"))
                    oRsTool.Parameters.Add("Closing105", closing105);
                if (!oRsTool.Parameters.ContainsKey("Closing106"))
                    oRsTool.Parameters.Add("Closing106", closing106);





                decimal totalInit = list.Where(x => x.OrderNumber == 5).Sum(x => x.TotalExpend);
                decimal init101 = list.Where(x => x.OrderNumber == 5).Sum(x => x.Expend101);
                decimal init102 = list.Where(x => x.OrderNumber == 5).Sum(x => x.Expend102);
                decimal init103 = list.Where(x => x.OrderNumber == 5).Sum(x => x.Expend103);
                decimal init104 = list.Where(x => x.OrderNumber == 5).Sum(x => x.Expend104);
                decimal init105 = list.Where(x => x.OrderNumber == 5).Sum(x => x.Expend105);
                decimal init106 = list.Where(x => x.OrderNumber == 5).Sum(x => x.Expend106);

                if (!oRsTool.Parameters.ContainsKey("TotalInit"))
                    oRsTool.Parameters.Add("TotalInit", totalInit);
                if (!oRsTool.Parameters.ContainsKey("Init101"))
                    oRsTool.Parameters.Add("Init101", init101);
                if (!oRsTool.Parameters.ContainsKey("Init102"))
                    oRsTool.Parameters.Add("Init102", init102);
                if (!oRsTool.Parameters.ContainsKey("Init103"))
                    oRsTool.Parameters.Add("Init103", init103);
                if (!oRsTool.Parameters.ContainsKey("Init104"))
                    oRsTool.Parameters.Add("Init104", init104);
                if (!oRsTool.Parameters.ContainsKey("Init105"))
                    oRsTool.Parameters.Add("Init105", init105);
                if (!oRsTool.Parameters.ContainsKey("Init106"))
                    oRsTool.Parameters.Add("Init106", init106);

                foreach (var item in list)
                {
                    //item.TotalOpen = list.Where(x => x.OrderNumber == -1 && x.ProjectId == item.ProjectId).Sum(x => x.TotalExpend);
                    item.Open101 = list.Where(x => x.OrderNumber == -1 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend101);
                    item.Open102 = list.Where(x => x.OrderNumber == -1 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend102);
                    item.Open103 = list.Where(x => x.OrderNumber == -1 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend103);
                    item.Open104 = list.Where(x => x.OrderNumber == -1 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend104);
                    item.Open105 = list.Where(x => x.OrderNumber == -1 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend105);
                    item.Open106 = list.Where(x => x.OrderNumber == -1 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend106);
                    item.TotalOpen = item.Open101 + item.Open102 + item.Open103 + item.Open104 + item.Open105 + item.Open106;
                    //item.TotalMovement = list.Where(x => x.OrderNumber == 2 && x.ProjectId == item.ProjectId).Sum(x => x.TotalExpend);
                    item.Movement101 = list.Where(x => x.OrderNumber == 2 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend101);
                    item.Movement102 = list.Where(x => x.OrderNumber == 2 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend102);
                    item.Movement103 = list.Where(x => x.OrderNumber == 2 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend103);
                    item.Movement104 = list.Where(x => x.OrderNumber == 2 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend104);
                    item.Movement105 = list.Where(x => x.OrderNumber == 2 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend105);
                    item.Movement106 = list.Where(x => x.OrderNumber == 2 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend106);

                    item.TotalMovement = item.Movement101 + item.Movement102 + item.Movement103 + item.Movement104 + item.Movement105 + item.Movement106;

                    //item.TotalAccumlate = list.Where(x => x.OrderNumber == 4 && x.ProjectId == item.ProjectId).Sum(x => x.TotalExpend);
                    item.Accumlate101 = list.Where(x => x.OrderNumber == 4 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend101);
                    item.Accumlate102 = list.Where(x => x.OrderNumber == 4 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend102);
                    item.Accumlate103 = list.Where(x => x.OrderNumber == 4 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend103);
                    item.Accumlate104 = list.Where(x => x.OrderNumber == 4 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend104);
                    item.Accumlate105 = list.Where(x => x.OrderNumber == 4 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend105);
                    item.Accumlate106 = list.Where(x => x.OrderNumber == 4 && x.ProjectRun == item.ProjectRun).Sum(x => x.Expend106);
                    item.TotalAccumlate = item.Accumlate101 + item.Accumlate102 + item.Accumlate103 + item.Accumlate104 + item.Accumlate105 + item.Accumlate106;

                    //item.TotalClosing = item.TotalMovement + item.TotalOpen;
                    item.Closing101 = item.Movement101 + item.Open101;
                    item.Closing102 = item.Movement102 + item.Open102;
                    item.Closing103 = item.Movement103 + item.Open103;
                    item.Closing104 = item.Movement104 + item.Open104;
                    item.Closing105 = item.Movement105 + item.Open105;
                    item.Closing106 = item.Movement106 + item.Open106;
                    item.TotalClosing = item.TotalMovement + item.TotalOpen;
                    if (!string.IsNullOrEmpty(item.PostedDate))
                    {
                        item.PostedDate = DateTime.Parse(item.PostedDate).ToString("dd-MM-yyyy");

                    }
                    //item.TotalInit = list.Where(x => x.OrderNumber == 5 && x.ProjectId == item.ProjectId).Sum(x => x.TotalExpend);
                    //item.Init101 = list.Where(x => x.OrderNumber == 5 && x.ProjectId == item.ProjectId).Sum(x => x.Expend101);
                    //item.Init102 = list.Where(x => x.OrderNumber == 5 && x.ProjectId == item.ProjectId).Sum(x => x.Expend102);
                    //item.Init103 = list.Where(x => x.OrderNumber == 5 && x.ProjectId == item.ProjectId).Sum(x => x.Expend103);
                    //item.Init104 = list.Where(x => x.OrderNumber == 5 && x.ProjectId == item.ProjectId).Sum(x => x.Expend104);
                    //item.Init105 = list.Where(x => x.OrderNumber == 5 && x.ProjectId == item.ProjectId).Sum(x => x.Expend105);
                    //item.Init106 = list.Where(x => x.OrderNumber == 5 && x.ProjectId == item.ProjectId).Sum(x => x.Expend106);
                    // nghiệp vụ bằng số dư cuối kỳ
                    item.TotalInit = item.TotalMovement + item.TotalOpen;
                    item.Init101 = item.Movement101 + item.Open101;
                    item.Init102 = item.Movement102 + item.Open102;
                    item.Init103 = item.Movement103 + item.Open103;
                    item.Init104 = item.Movement104 + item.Open104;
                    item.Init105 = item.Movement105 + item.Open105;
                    item.Init106 = item.Movement106 + item.Open106;
                    item.TotalExpend = item.Expend101 + item.Expend102 + item.Expend103 + item.Expend104 + item.Expend105 + item.Expend106;
                }
            }
            else
            {
                XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                return null;
            }

            var newList = list.Where(l => !string.IsNullOrEmpty(l.RefNo)).ToList();
            // check xem có tồn tại các thông số về đầu kỳ không
            foreach (var item in list)
            {
                if ((newList.Count() == 0 || !newList.Any(nl => nl.ProjectId.ToLower() == item.ProjectId.ToLower())) && item.OrderNumber == -1)
                {
                    item.Description = "";
                    item.Expend105 = 0;
                    item.Movement105 = 0;
                    item.Expend101 = 0;
                    item.Movement101 = 0;
                    item.Expend102 = 0;
                    item.Movement102 = 0;
                    item.Expend103 = 0;
                    item.Movement103 = 0;
                    item.Expend104 = 0;
                    item.Movement104 = 0;
                    item.Expend106 = 0;
                    item.Movement106 = 0;
                    //item.EstimateTotal = 0;
                    newList.Add(item);
                }
            }
            //var projectIds = list.Where(l => newList.Any(nl => l.ProjectId != nl.ProjectId)).ToList();
            //projectIds.ForEach(item =>
            //{
            //    if (newList.Any(nl => nl.ProjectId != item.ProjectId))
            //    {
            //        newList.Add(item);
            //    }
            //});
            // check de show detail
            newList.ForEach(item =>
            {
                item.ShowDetail = list.Any(l => !string.IsNullOrEmpty(l.RefNo) && item.ProjectId.ToLower() == l.ProjectId.ToLower());
            });
            var reportList = newList.ToList();
            return reportList;
        }


        /// <summary>
        /// Gets the report S05 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param> 0
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>
        /// IList&lt;S05HModel&gt;.
        /// </returns>
        public IList<S05HModel> GetReportS05H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S05HModel> list = null;
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
                    ReportID = "S31-H";
                    break;

            }

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS05H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());

                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());

                        if (!oRsTool.Parameters.ContainsKey("ReportID"))
                            oRsTool.Parameters.Add("ReportID", ReportID);

                        if (!oRsTool.Parameters.ContainsKey("CompanyCode"))
                            oRsTool.Parameters.Add("CompanyCode", string.IsNullOrEmpty(GlobalVariable.CompanyCode) ? string.Empty : GlobalVariable.CompanyCode);

                        list = Model.GetReportS05H(fromDate, toDate, frmParam.BudgetChapterCode, frmParam.IsSummaryBudgetChapter, amountType == 1 ? true : false, currencyCode);
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
        /// Gets the report S31 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>
        /// IList&lt;S31HModel&gt;.
        /// </returns>
        public IList<S31HModel> GetReportS31H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S31HModel> list = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS31H())
                {
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

                        list = Model.GetReportS31H(fromDate, fromDate, toDate, frmParam.AccountNumber, amountType, String.IsNullOrEmpty(frmParam.CurrencyCode) ? currencyCode : frmParam.CurrencyCode, frmParam.CorrespondingAccountNumber, frmParam.AccountingObjectID, frmParam.BudgetSourceID, frmParam.FundStructureID, frmParam.BudgetChapterCode, frmParam.BudgetKindItemCode, frmParam.BudgetItemCode, frmParam.ProjectID, frmParam.ContractID, frmParam.BankID, frmParam.ActivityId, frmParam.CapitalPlanID, frmParam.IsAccountingObjectID, frmParam.IsGroupBudgetSourceID, frmParam.IsGroupFundStructureID, frmParam.IsGroupBudgetChapterCode, frmParam.IsGroupBudgetKindItemCode, frmParam.IsGroupBudgetItemCode, frmParam.IsGroupProjectID, frmParam.IsGroupContractID, frmParam.IsGroupBankID, frmParam.IsGroupActivityId, frmParam.IsGroupCapitalPlanID, frmParam.IsGroupCurrencyCode, frmParam.ISCustomer, frmParam.ISVendor, frmParam.ISEmployee, frmParam.CustomerID, frmParam.VendorID, frmParam.EmployeeID, frmParam.FixedAssetId, frmParam.InventoryItemId, frmParam.IsGroupFixedAssetId, frmParam.IsGroupInventoryItemId);
                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            return list;
        }
        //public IList<S31HNoAccoutingObjectModel> GetReportS31HNoAccoutingObject(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        //{
        //    IList<S31HNoAccoutingObjectModel> list = null;
        //    GlobalVariable.IsDisplayNewLicenseInfo = false;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;

        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmS31H())
        //        {
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                var fromDate = DateTime.Parse(frmParam.FromDate);
        //                var toDate = DateTime.Parse(frmParam.ToDate);
        //                if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //                    oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
        //                if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //                    oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
        //                if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //                    oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
        //                list = Model.GetReportS31HNoAccoutingObject(fromDate, fromDate, toDate, frmParam.AccountNumber,frmParam.BudgetSourceID, frmParam.IsSumaryGroupBudgetSource, frmParam.BudgetChapterCode,
        //                               frmParam.BudgetSubKindItemCode, frmParam.IsSumaryGroupBudgetChapterCode, frmParam.IsSumaryGroupBudgetSubKindItemCode, amountType, currencyCode);
        //            }
        //            else
        //            {
        //                list = null;
        //            }
        //        }
        //    }
        //    return list;
        //}

        /// <summary>
        /// Sổ nhật ký chung
        /// Gets the report S03 ah.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>
        /// IList&lt;S04HModel&gt;.
        /// </returns>
        public IList<S03HModel> GetReportS03H(ReportParameter reportParameter, ReportSharpHelper oRsTool, object[] param = null)
        {
            IList<S03HModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
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

                    list = Model.GetReportS03H(fromDate, fromDate, toDate, false,
                        ",00000000-0000-0000-0000-000000000000,", null, null,
                        true, true,
                        true, "," + param[1].ToString() + ",", false, false, amountType, currencyCode, false);
                }
            }

            return list;
        }
        public IList<S03HModel> GetReportS03H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S03HModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS03H())
                {
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
                        if (!oRsTool.Parameters.ContainsKey("IsDetail"))
                            oRsTool.Parameters.Add("IsDetail", frmParam.IsDetail);
                        list = Model.GetReportS03H(fromDate, fromDate, toDate, frmParam.AddSameEntry,
                            frmParam.BudgetSourceCode, frmParam.BudgetChapterCode, frmParam.BudgetKindItemCode,
                            frmParam.IsSummaryBudgetSource, frmParam.IsSummaryBudgetChapter,
                            frmParam.IsSummaryBudgetSubKindItem, frmParam.AccountList, frmParam.IsPrintMonth13, frmParam.IsPrintAllYearAndMonth13, amountType, currencyCode, frmParam.IsDetail);
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
        /// Gets the report S02 ch.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<S03HModel> GetReportS02CH(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S03HModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS03H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        frmParam.ckbDetail.Visible = false;
                        frmParam.labelControl3.Visible = false;
                        var startDate = DateTime.Parse(frmParam.StartDate);
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
                        string budgetSourceCode = frmParam.BudgetSourceCode;
                        try
                        {
                            bool IsForeincurrency = true;
                            if (GlobalVariable.AmountTypeViewReport == 1)
                                IsForeincurrency = false;

                            list = Model.GetReportS02CH(startDate, fromDate, toDate, frmParam.AddSameEntry,
                                budgetSourceCode, frmParam.BudgetChapterCode, frmParam.BudgetKindItemCode,
                                frmParam.IsSummaryBudgetSource, frmParam.IsSummaryBudgetChapter,
                                frmParam.IsSummaryBudgetSubKindItem, frmParam.AccountList, frmParam.IsPrintMonth13, frmParam.IsPrintAllYearAndMonth13, IsForeincurrency, amountType, currencyCode);

                            if (GlobalVariable.AmountTypeViewReport == 2 && list != null && list.Count > 0)
                            {
                                list = list.Where(o => o.CurrencyCode == GlobalVariable.CurrencyViewReport).ToList();
                            }
                            else if (GlobalVariable.AmountTypeViewReport == 1)
                            {
                                foreach (var item in list)
                                {
                                    if (item.CurrencyCode != GlobalVariable.MainCurrencyId)
                                    {
                                        //item.Cot2 = item. * item.ExchangeRate;
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            XtraMessageBox.Show(e.ToString());
                            throw;
                        }
                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            return list;
        }

        public IList<S03HModel> GetReportS02CH(ReportParameter reportParameter, ReportSharpHelper oRsTool, object[] param = null)
        {
            IList<S03HModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
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

                list = Model.GetReportS03H(fromDate, fromDate, toDate, false,
                                     ",00000000-0000-0000-0000-000000000000,", null, null,
                                     true, true,
                                     true, "," + param[1].ToString() + ",", false, false, amountType, currencyCode, true);
            }

            return list;
        }

        /// <summary>
        /// Gets the C33 bb.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<C33BBModel> GetC33BB(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<C33BBModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmC33BB())
                {
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
                        list = Model.GetC33BB(fromDate, toDate, frmParam.DepartmentId, frmParam.AccountingObjectList);
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
        /// Gets the report S13 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<S13HModel> GetReportS13H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S13HModel> s13HModels = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS13H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var bankAccount = frmParam.BankAccount;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("IsDetail"))
                            oRsTool.Parameters.Add("IsDetail", frmParam.IsDetailMonth);

                        s13HModels = Model.GetReportS13H(fromDate, fromDate, toDate, frmParam.AccountNumber, frmParam.CurrencyCode, frmParam.IsDetail, frmParam.IsDetailMonth, bankAccount);
                    }
                }
            }
            return s13HModels;
        }


        //public IList<Object> GetReportS01H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        //{
        //    List<object> obj = new List<object>();
        //}

        public IList<object> GetReportS01H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            // IList<S01HModel> obj = null;
            // List<S01HModel> obj = new List<S01HModel>();

            List<object> result = new List<object>();
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS01H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());

                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());

                        DataTable test = new DataTable();
                        test = Model.GetReportS01H(fromDate, toDate, frmParam.AddSameEntry, frmParam.IsViewOutsideAccount, frmParam.BudgetSourceCode, frmParam.BudgetChapterCode, frmParam.BudgetKindItemCode, frmParam.IsSummaryBudgetSource,
                            frmParam.IsSummaryBudgetChapter, frmParam.IsSummaryBudgetSubKindItem);

                        //Convert Datatable to List DataSource
                        Dictionary<string, Type> fieldList = new Dictionary<string, Type>();

                        foreach (DataColumn dtCol in test.Columns)
                        {
                            fieldList.Add(dtCol.ColumnName, dtCol.DataType);

                        }
                        foreach (DataRow dtRow in test.Rows)
                        {
                            object dynamicObj = DynamicObject.DynamicObject.CreateNewObject(fieldList);
                            foreach (var field in fieldList.OrderBy(r => r.Key))
                            {
                                var value = dtRow[field.Key].ToString();
                                PropertyInfo propertyInfos = dynamicObj.GetType().GetProperty(field.Key);

                                if (propertyInfos.PropertyType == typeof(decimal))
                                {
                                    decimal valueDecimal = string.IsNullOrEmpty(value) ? 0 : decimal.Parse(value);
                                    propertyInfos.SetValue(dynamicObj, valueDecimal, null);
                                }
                                else if (propertyInfos.PropertyType == typeof(DateTime))
                                {
                                    DateTime valueDate = string.IsNullOrEmpty(value) ? DateTime.MinValue : DateTime.Parse(value);
                                    propertyInfos.SetValue(dynamicObj, valueDate, null);
                                }
                                else if (propertyInfos.PropertyType == typeof(int))
                                {
                                    int valueint = string.IsNullOrEmpty(value) ? 0 : int.Parse(value);
                                    propertyInfos.SetValue(dynamicObj, valueint, null);
                                }
                                else if (propertyInfos.PropertyType == typeof(Guid))
                                {
                                    Guid valueguid = string.IsNullOrEmpty(value) ? Guid.Empty : new Guid(value);
                                    propertyInfos.SetValue(dynamicObj, valueguid, null);
                                }
                                else
                                {
                                    propertyInfos.SetValue(dynamicObj, value, null);
                                }
                            }
                            result.Add(dynamicObj);
                        }
                        RenderDynamic(test);
                    }
                }
            }
            return result;
            // return obj;
        }
        public static void RenderDynamic(DataTable dtSource)
        {

            var reportSlot = new FileReportSlot { FilePath = GlobalVariable.ReportPath + "S01-H_LandScape.rst" };
            Document doc = reportSlot.LoadReport();
            int pag = doc.Pages.Count;
            for (int i = 1; i < pag; i++)
            {
                doc.Pages.RemoveAt(i);
            }
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader1 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();


            Header header = (Header)doc.ControlByName("header2");
            Header header3 = (Header)doc.ControlByName("header3");
            Detail detail = (Detail)doc.ControlByName("detail1");
            header.Controls.Clear();
            header3.Controls.Clear();
            detail.Controls.Clear();

            Border oBorder = new Border();
            BorderLine oBorderLine = new BorderLine();
            oBorderLine.Width = 1;
            oBorderLine.Color = System.Drawing.Color.Black;
            oBorderLine.Style = PerpetuumSoft.Framework.Drawing.LineStyle.Solid;
            oBorder = new Border(oBorderLine, oBorderLine, oBorderLine, oBorderLine);

            #region Header2

            //Tạo cột STT
            textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader.Name = "txtNumber";
            textBoxHeader.Text = "STT";
            header.Controls.Add(textBoxHeader);
            textBoxHeader.Location = new Vector(0.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.Size = new Vector(1f, 2.4f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader.Border = oBorder;

            //Tạo cột Chỉ tiêu
            textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader.Name = "txtCT";
            textBoxHeader.Text = "Chỉ tiêu";
            header.Controls.Add(textBoxHeader);
            textBoxHeader.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.Size = new Vector(7.6f, 2.4f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader.Border = oBorder;

            //Tạo cột tỷ lệ khấu hao
            textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader.Name = "txtTLKH";
            textBoxHeader.Text = "Tỷ lệ khấu hao (%) hoặc thời gian sử dụng";
            header.Controls.Add(textBoxHeader);
            textBoxHeader.Location = new Vector(9.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.Size = new Vector(2.6f, 2.4f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader.Border = oBorder;

            //Tạo cột tổng số
            textBoxHeader1 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader1.Name = "txtTS";
            textBoxHeader1.Text = "Tổng số";
            header.Controls.Add(textBoxHeader1);
            textBoxHeader1.Location = new Vector(11.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader1.Size = new Vector(5f, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader1.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader1.Border = oBorder;

            //Tạo cột nguyên giá
            textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader.Name = "txtNG";
            textBoxHeader.Text = "Nguyên giá TSCĐ";
            header.Controls.Add(textBoxHeader);
            textBoxHeader.Location = new Vector(11.7f, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.Size = new Vector(2.5f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader.Border = oBorder;

            //Tạo cột số khấu hao
            textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader.Name = "txtKH";
            textBoxHeader.Text = "Số Khấu Hao";
            header.Controls.Add(textBoxHeader);
            textBoxHeader.Location = new Vector(14.2f, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.Size = new Vector(2.5f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader.Border = oBorder;

            //Tạo cột phân bổ
            textBoxHeader1 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader1.Name = "txtPB";
            textBoxHeader1.Text = "Phân Bổ";
            header.Controls.Add(textBoxHeader1);
            textBoxHeader1.Location = new Vector(16.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader1.Size = new Vector(12.5f, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader1.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader1.Border = oBorder;

            #endregion

            #region Header3

            //Tạo cột STT
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtNumber3";
            textBoxHeader3.Text = "A";
            header3.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(0.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(1f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;

            //Tạo cột Chỉ tiêu
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtCT3";
            textBoxHeader3.Text = "B";
            header3.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(7.6f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;

            //Tạo cột tỷ lệ khấu hao
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtTLKH3";
            textBoxHeader3.Text = "1";
            header3.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(9.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(2.6f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;

            //Tạo cột nguyên giá
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtNG3";
            textBoxHeader3.Text = "2";
            header3.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(11.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;

            //Tạo cột số khấu hao
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtKH3";
            textBoxHeader3.Text = "3";
            header3.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(14.2f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;
            #endregion

            #region Detail

            //Tạo cột STT
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtdetailNumber1";
            textBoxDetail.Text = "";
            detail.Controls.Add(textBoxDetail);
            textBoxDetail.Location = new Vector(0.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(1f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;

            //Tạo cột Chỉ tiêu
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtDetailTargets";
            textBoxDetail.Text = "";
            detail.Controls.Add(textBoxDetail);
            textBoxDetail.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(7.6f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;


            //Tạo cột tỷ lệ khấu hao
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtDetailAmountRate";
            textBoxDetail.Text = "";
            detail.Controls.Add(textBoxDetail);
            textBoxDetail.Location = new Vector(9.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(2.6f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;

            //Tạo cột nguyên giá
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtDetailOrg";
            textBoxDetail.Text = "2";
            detail.Controls.Add(textBoxDetail);
            textBoxDetail.Location = new Vector(11.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;


            //Tạo cột số khấu hao
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtDetailAnnualDepreciationAmount";
            textBoxDetail.Text = "";
            detail.Controls.Add(textBoxDetail);
            textBoxDetail.Location = new Vector(14.2f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;

            detail.GenerateScript = "txtDetailTargets.Text = GetData(\"Targets\").ToString(); " +
                                    "txtDetailAmountRate.Value= GetData(\"AnnualDepreciationRate\").ToString() == \"0\"?\"\":GetData(\"AnnualDepreciationRate\").ToString(); " +
                                    "txtDetailAmountRate.TextFormat=(PerpetuumSoft.Framework.Text.TextFormat)GetData(\"RssObject.CurrencyFormat\"); " +
                                    "txtDetailOrg.Value = GetData(\"OrgPrice\").ToString() == \"0\"?\"\":GetData(\"OrgPrice\").ToString() ; " +
                                    "txtDetailOrg.TextFormat =(PerpetuumSoft.Framework.Text.TextFormat)GetData(\"RssObject.CurrencyFormat\"); " +
                                    "txtDetailAnnualDepreciationAmount.Value = GetData(\"AnnualDepreciationAmount\").ToString() == \"0\"?\"\":GetData(\"AnnualDepreciationAmount\").ToString() ;" +
                                    "txtDetailAnnualDepreciationAmount.TextFormat=(PerpetuumSoft.Framework.Text.TextFormat)GetData(\"RssObject.CurrencyFormat\"); "
                                    + "if(GetData(\"ChildrenId\").ToString()==\"0\") " +
                                    "{ txtDetailTargets.StyleName =  \"DetailNormalBold\";  txtDetailAmountRate.StyleName =  \"DetailNormalBold\";  txtDetailOrg.StyleName =  \"DetailNormalBold\"; txtDetailAnnualDepreciationAmount.StyleName =  \"DetailNormalBold\";" + "}"
                                    + "else { txtDetailTargets.StyleName =  \"DetailNormal\"; txtDetailAmountRate.StyleName =  \"DetailNormal\";  txtDetailOrg.StyleName =  \"DetailNormal\"; txtDetailAnnualDepreciationAmount.StyleName =  \"DetailNormal\";  }";


            #endregion

            double marginLeft = 16.7f;
            int countDynamicColumn = 0;
            int numberheader3 = 4;

            Dictionary<string, Type> fieldList = new Dictionary<string, Type>();

            foreach (DataColumn dtCol in dtSource.Columns)
            {
                if (dtCol.Caption.Contains("Debit"))
                {
                    fieldList.Add(dtCol.ColumnName, dtCol.DataType);
                }

            }
            var fieldlistOrder = fieldList.OrderBy(r => r.Key).ToList();
            int surPlus = (fieldList.Count - 5) % 10;
            int pageIndex =
                (fieldList.Count - 5) / 10;
            if (surPlus > 0) pageIndex = pageIndex + 2;
            else pageIndex = pageIndex + 1;

            var listpage1 = fieldlistOrder.Skip(0).Take(5);
            foreach (var dtColumn in listpage1)
            {
                //Tạo header
                if (dtColumn.Key.Contains("Debit"))
                {
                    #region Header

                    textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader.Name = "txt" + dtColumn.Key.Replace("Debit", "");

                    textBoxHeader.Text = "TK " + dtColumn.Key.Replace("Debit", "");

                    header.Controls.Add(textBoxHeader);
                    textBoxHeader.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 1.1f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(2.5f, 1.3f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                    textBoxHeader.Border = oBorder;

                    #endregion

                    #region Header3

                    textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader3.Name = "txthead3" + numberheader3.ToString();
                    textBoxHeader3.Text = numberheader3.ToString();
                    header3.Controls.Add(textBoxHeader3);
                    textBoxHeader3.Location = new Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                    textBoxHeader3.Size = new Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                    textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
                    textBoxHeader3.Border = oBorder;
                    numberheader3 = numberheader3 + 1;

                    #endregion

                    #region Detail

                    textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxDetail.Name = "txtDetail" + dtColumn.Key.Replace("Debit", "");
                    textBoxDetail.Text = dtColumn.Key.Replace("Debit", "");
                    textBoxDetail.GenerateScript = textBoxDetail.Name.ToString() + ".Value=GetData(\"" + dtColumn.Key + "\").ToString(); "
                                                 + textBoxDetail.Name + ".TextFormat = "
                                                 + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");"
                                                 + "if(GetData(\"ChildrenId\").ToString()==\"0\") "
                                                 + "{" + textBoxDetail.Name + ".StyleName  =  \"DetailNormalBold\";}"
                                                 + "else {" + textBoxDetail.Name + ".StyleName =  \"DetailNormal\";}";
                    detail.Controls.Add(textBoxDetail);
                    textBoxDetail.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetail.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
                    textBoxDetail.Border = oBorder;
                    countDynamicColumn = countDynamicColumn + 1;
                    marginLeft = marginLeft + 2.5f;

                    #endregion

                }
            }
            for (int i = countDynamicColumn; i < 5; i++)
            {
                #region Header

                textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader.Name = "txt" + i.ToString();
                header.Controls.Add(textBoxHeader);
                textBoxHeader.Location =
                    new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 1.1f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxHeader.Size =
                    new PerpetuumSoft.Framework.Drawing.Vector(2.5f, 1.3f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                textBoxHeader.Border = oBorder;

                #endregion

                #region Header3

                textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader3.Name = "txthead3" + numberheader3.ToString();
                textBoxHeader3.Text = "";
                header3.Controls.Add(textBoxHeader3);
                textBoxHeader3.Location = new Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.Size = new Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
                textBoxHeader3.Border = oBorder;
                numberheader3 = numberheader3 + 1;

                #endregion

                #region detail

                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txtDetail" + i.ToString();
                textBoxDetail.Text = "";
                detail.Controls.Add(textBoxDetail);
                textBoxDetail.Location =
                    new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxDetail.Size =
                    new PerpetuumSoft.Framework.Drawing.Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                #endregion

                marginLeft = marginLeft + 2.5f;

            }
            //page 2
            for (int n = 2; n <= pageIndex; n++)
            {
                double marginLeftN = 1.1f;

                var listpageN = fieldlistOrder.Skip((n - 1) * 10 - 5).Take(10);
                int countDynamicColumnN = 0;

                Page checkpage = (Page)doc.ControlByName("page" + n);
                if (checkpage != null) doc.Pages.Remove(checkpage);

                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader1N = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxFooter = new PerpetuumSoft.Reporting.DOM.TextBox();

                Page page = new Page();
                page.Name = "page" + n;
                page.Margins = new Margins(1f, 1f, 1.1f, 1.1f);
                page.Orientation = PageOrientation.Landscape;
                doc.Pages.Add(page);



                PageHeader pageHeader = new PageHeader();
                pageHeader.Name = "pageHeader" + n;
                pageHeader.Location = new Vector(0f, 1.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                pageHeader.Size = new Vector(29.7f, 1.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                page.Controls.Add(pageHeader);

                PageFooter pagefooter = new PageFooter();
                pagefooter.Name = "pagefooter" + n;

                page.Controls.Add(pagefooter);

                textBoxFooter = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxFooter.Name = "txtfooter" + n;

                pagefooter.Controls.Add(textBoxFooter);

                textBoxFooter.Location = new Vector(12f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxFooter.Size = new Vector(8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                DataBand dataBand = new DataBand();
                dataBand.Name = "dataBand" + n;
                page.Controls.Add(dataBand);
                dataBand.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.3f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                dataBand.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 15f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                dataBand.DataSource = "FIXED_ASSET";


                Header header1N = new Header();
                dataBand.Controls.Add(header1N);
                header1N.Name = "header1N" + n;
                header1N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.5f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header1N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 2.5).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header1N.StyleName = "HeaderFooter2Bold";

                Header header2N = new Header();
                dataBand.Controls.Add(header2N);
                header2N.Name = "header2N" + n;
                header2N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.5f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header2N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 2.4).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header2N.StyleName = "HeaderFooter2Bold";

                Header header3N = new Header();
                dataBand.Controls.Add(header3N);
                header3N.Name = "header3N" + n;
                header3N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 6.1f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header3N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 0.5).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header3N.StyleName = "HeaderFooter2Bold";
                GroupBand grBand = new GroupBand();
                dataBand.Controls.Add(grBand);
                grBand.Name = "groupBand" + n;
                grBand.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 7.2f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                grBand.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 1.6f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                grBand.GroupExpression = "1";

                Detail detailN = new Detail();
                detailN.Name = "detailN" + n;
                grBand.Controls.Add(detailN);
                detailN.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                detailN.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 0.5f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                detailN.CanGrow = detailN.CanShrink = true;
                detailN.StyleName = "DetailNormal";

                textBoxHeader1N = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader1N.Name = "txtPBN";
                textBoxHeader1N.Text = "Phân Bổ";
                header2N.Controls.Add(textBoxHeader1N);
                textBoxHeader1N.Location = new Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader1N.Size = new Vector(27.5f, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader1N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader1N.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                textBoxHeader1N.Border = oBorder;



                foreach (var dtColumn in listpageN)
                {

                    if (dtColumn.Key.Contains("Debit"))
                    {
                        #region Header

                        textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader2N.Name = "txt" + dtColumn.Key.Replace("Debit", "");
                        textBoxHeader2N.Text = "TK " + dtColumn.Key.Replace("Debit", "");
                        header2N.Controls.Add(textBoxHeader2N);
                        textBoxHeader2N.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 1.1f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxHeader2N.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(2.5f, 1.3f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader2N.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                        textBoxHeader2N.Border = oBorder;

                        #endregion

                        #region Header3

                        textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader3N.Name = "txthead3" + numberheader3.ToString();
                        textBoxHeader3N.Text = numberheader3.ToString();
                        header3N.Controls.Add(textBoxHeader3N);
                        textBoxHeader3N.Location = new Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.Size = new Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader3N.CanGrow = textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = true;
                        textBoxHeader3N.Border = oBorder;
                        numberheader3 = numberheader3 + 1;

                        #endregion

                        #region Detail

                        textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxDetailN.Name = "txtDetail" + dtColumn.Key.Replace("Debit", "");
                        textBoxDetailN.Text = dtColumn.Key.Replace("Debit", "");
                        textBoxDetailN.GenerateScript = textBoxDetailN.Name.ToString() + ".Value=GetData(\"" + dtColumn.Key + "\").ToString(); "
                         + textBoxDetailN.Name + ".TextFormat = " + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");"
                         + "if(GetData(\"ChildrenId\").ToString()==\"0\") "
                         + "{" + textBoxDetailN.Name + ".StyleName  =  \"DetailNormalBold\";}"
                         + "else {" + textBoxDetailN.Name + ".StyleName =  \"DetailNormal\";}";
                        detailN.Controls.Add(textBoxDetailN);
                        textBoxDetailN.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxDetailN.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        textBoxDetailN.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
                        textBoxDetailN.Border = oBorder;
                        countDynamicColumnN = countDynamicColumnN + 1;
                        marginLeftN = marginLeftN + 2.5f;

                        #endregion

                    }
                }
                for (int i = countDynamicColumnN; i < 11; i++)
                {
                    #region Header

                    textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader2N.Name = "txtN" + i.ToString();
                    header2N.Controls.Add(textBoxHeader2N);
                    textBoxHeader2N.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 1.1f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader2N.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(2.5f, 1.3f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxHeader2N.CanGrow = textBoxHeader2N.CanShrink = textBoxHeader2N.GrowToBottom = true;
                    textBoxHeader2N.Border = oBorder;

                    #endregion

                    #region Header3

                    textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader3N.Name = "txthead3N" + numberheader3.ToString();
                    textBoxHeader3N.Text = "";
                    header3N.Controls.Add(textBoxHeader3N);
                    textBoxHeader3N.Location = new Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                    textBoxHeader3N.Size = new Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                    textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxHeader3N.CanGrow = textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = true;
                    textBoxHeader3N.Border = oBorder;
                    numberheader3 = numberheader3 + 1;

                    #endregion

                    #region detail

                    textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxDetailN.Name = "txtDetailN" + i.ToString();
                    textBoxDetailN.Text = "";
                    detailN.Controls.Add(textBoxDetailN);
                    textBoxDetailN.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetailN.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(2.5f, 0.5f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxDetailN.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
                    textBoxDetailN.Border = oBorder;

                    #endregion

                    marginLeftN = marginLeftN + 2.5f;

                }
            }

            reportSlot.SaveReport(doc);


        }


        /// <summary>
        /// Gets the S34.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<S34H_GL_MasterModel> GetS34(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S34H_GL_MasterModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            var issumaccount = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS34H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startdate = DateTime.Parse(frmParam.StartDate);
                        if (frmParam.AccountNumber == null)
                            issumaccount = true;
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("IsDetail"))
                            oRsTool.Parameters.Add("IsDetail", frmParam.IsDetail);

                        list = Model.GetS34H(startdate, fromDate, toDate, frmParam.AccountNumber, frmParam.CorrespondingAccount, frmParam.AccountingObjectList, frmParam.ProjectIdList, issumaccount, frmParam.pGroupTheSameItem, frmParam.IsDetail, GlobalVariable.AmountTypeViewReport, GlobalVariable.CurrencyViewReport);
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
        /// Reports the S02 ch.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<S02CHModel> ReportS02CH(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S02CHModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {

                using (var frmParam = new FrmGLVoucherListLedger())
                {
                    frmParam.Text = @"Sổ cái - hình thức kế toán chứng từ ghi sổ";

                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var startDate = frmParam.FromDate;
                        reports = Model.ReportS02CH(frmParam.FromDate, frmParam.ToDate, startDate, frmParam.ListBudgetSourceId, frmParam.BudgetChapterCode, frmParam.BudgetSubKindItemCode, frmParam.IsSummaryBudgetSource, frmParam.IsSummaryBudgetChapter, frmParam.IsSummaryBudgetSubKindItem, frmParam.Account);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", frmParam.FromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", frmParam.ToDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// Reports the S51 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<S51HModel> GetReportS51H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S51HModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {

                using (var frmParam = new FrmS51H())
                {
                    frmParam.Text = @"Tham số báo cáo";

                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var startDate = DateTime.Parse(frmParam.FromDate);
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        reports = Model.ReportS51H(fromDate, toDate, startDate, frmParam.InventoryItemIds, frmParam.ActivityId, frmParam.IsSummaryInventory, frmParam.IsSummaryActivity);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                    }
                }
            }
            return reports;
        }
    }
}
