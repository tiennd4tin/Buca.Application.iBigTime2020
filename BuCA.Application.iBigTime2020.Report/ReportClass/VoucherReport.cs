/***********************************************************************
 * <copyright file="VoucherReport.cs" company="BUCA JSC">
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
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher;
using BuCA.Application.iBigTime2020.Report.ParameterReportForm;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraEditors;
using RSSHelper;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using System.Data;
using BuCA.Enum;
using System.Xml;
using System.Text;
using System.IO;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate;
using DevExpress.XtraSplashScreen;
using System.Threading;


namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    /// <summary>
    /// Voucher Report
    /// </summary>
    public class VoucherReport : BaseReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherReport"/> class.
        /// </summary>
        public VoucherReport()
        {
            Model = new Model();
            exportXml = new ExportXML();
        }

        protected static ExportXML exportXml { get; set; }
        #region Phiếu chi

        /// <summary>
        /// Reports the cash payment C31 bb.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        public IList<C41BBModel> ReportCashPaymentC41BB(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            List<C41BBModel> reports = new List<C41BBModel>();

            if (reportParameter.IsInTheoLo)
            {
                var choseCAReceipt = new FrmChooseCaPayment();
                choseCAReceipt.ShowDialog();
                if (choseCAReceipt.DialogResult == DialogResult.OK)
                {
                    if (choseCAReceipt.RefIds.Count == 0)
                    {
                        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        return null;
                    }
                    choseCAReceipt.RefIds.ForEach(refId =>
                    {
                        var response = Model.ReportCashPaymentC41BB(refId);
                        reports.AddRange(response);
                    });

                }
                if (choseCAReceipt.DialogResult == DialogResult.Cancel)
                {
                    return null;
                }

            }
            else
            {
                reports = Model.ReportCashPaymentC41BB(reportParameter.RefId).ToList();
            }
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var result = new List<C41BBModel>();
            var groupBy = reports.GroupBy(r => r.RefId);
            string debitlist = reports.Any()
                ? reports.Where(a => a.DebitAccount != null)
                    .Select(i => i.DebitAccount.ToString())
                    .Distinct()
                    .Aggregate(string.Empty, (i, j) => i + "," + j)
                : "";
            string creditlist = reports.Any()
                ? reports.Where(a => a.CreditAccount != null)
                    .Select(i => i.CreditAccount.ToString())
                    .Distinct()
                    .Aggregate(string.Empty, (i, j) => i + "," + j)
                : "";

            if (!string.IsNullOrEmpty(debitlist) && debitlist[0] == ',')
                debitlist = debitlist.Substring(1, debitlist.Length - 1);

            if (!string.IsNullOrEmpty(creditlist) && creditlist[0] == ',')
                creditlist = creditlist.Substring(1, creditlist.Length - 1);
            var _exchangeRateDecimalDigits = string.IsNullOrEmpty(GlobalVariable.ExchangeRateDecimalDigits) ? "0" : GlobalVariable.ExchangeRateDecimalDigits;
            foreach (var item in groupBy)
            {
                var c31BBModel = reports.FirstOrDefault(r => r.RefId == item.Key.ToString() && r.CreditAccount.StartsWith("111"));
                if (c31BBModel == null)
                    break;
                result.Add(new C41BBModel
                {
                    RefId = item.Key,
                    RefDate = c31BBModel.RefDate,
                    PostedDate = c31BBModel.PostedDate,
                    RefNo = c31BBModel.RefNo,
                    AccountingObjectName = string.IsNullOrEmpty(c31BBModel.Receiver) ? c31BBModel.AccountingObjectName : c31BBModel.Receiver,
                    Address = c31BBModel.Address,
                    JournalMemo = c31BBModel.JournalMemo,
                    DocumentIncluded = c31BBModel.DocumentIncluded,
                    Description = c31BBModel.Description,
                    SumAmount = item.Select(c => c.Amount).Sum(),
                    SumAmountOC = item.Select(c => c.AmountOC).Sum(),
                    CurrencyCode = c31BBModel.CurrencyCode,
                    DebitAccountAll = c31BBModel.DebitAccount,
                    CreditAccountAll = c31BBModel.CreditAccount,
                    DebitAccount = c31BBModel.DebitAccount,
                    CreditAccount = c31BBModel.CreditAccount,
                    ExchangeRate = c31BBModel.ExchangeRate,
                    ExChangeRateFormat = c31BBModel.ExchangeRate.ToString("c" + Convert.ToString(_exchangeRateDecimalDigits)),
                    C41BBDetails = c31BBModel.C41BBDetails.Where(c => c.CreditAccount.StartsWith("111")).ToList(),
                });
            }
            return result;
        }
        public IList<TT39Model> ReportCashPaymentTT39(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var result = new List<TT39Model>();
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            try
            {
                using (var frmParam = new FrmPaymentVoucherListPrintFromVoucher_TT39 { RefId = reportParameter.RefId, ReportId = "" })
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        result = frmParam.BUTransfer_TT39Models.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
            return result;
        }

        public IList<TT39Model> ReportBUNoEstimateVoucherListTT39(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var result = new List<TT39Model>();
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            try
            {
                var bUTransfer = Model.GetBUVoucherList(reportParameter.RefId, true, false, true);
                foreach (var item in bUTransfer.BUVoucherListDetailModels)
                {
                    result.Add(new TT39Model
                    {
                        RefDate = bUTransfer.PostedDate,
                        PostedDate = bUTransfer.PostedDate,
                        RefNo = bUTransfer.RefNo,
                        Description = item.Description,
                        Amount = item.Amount,
                        BudgetItemCode = item.BudgetItemCode,
                        BudgetSubItemCode = item.BudgetSubItemCode
                    });
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
            return result;
        }


        /// <summary>
        /// Reports the cash payment fixed asset C41 bb.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        public IList<C41BBModel> ReportCashPaymentFixedAssetC41BB(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<C41BBModel> reports = Model.ReportCashPaymentFixedAssetC41BB(reportParameter.RefId);
            var result = new List<C41BBModel>();
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            var groupBy = reports.GroupBy(r => r.RefId);
            string debitlist = reports.Any()
                ? reports.Where(a => a.DebitAccount != null)
                    .Select(i => i.DebitAccount.ToString())
                    .Distinct()
                    .Aggregate(string.Empty, (i, j) => i + "," + j)
                : "";
            string creditlist = reports.Any()
                ? reports.Where(a => a.CreditAccount != null)
                    .Select(i => i.CreditAccount.ToString())
                    .Distinct()
                    .Aggregate(string.Empty, (i, j) => i + "," + j)
                : "";

            if (!string.IsNullOrEmpty(debitlist) && debitlist[0] == ',')
                debitlist = debitlist.Substring(1, debitlist.Length - 1);

            if (!string.IsNullOrEmpty(creditlist) && creditlist[0] == ',')
                creditlist = creditlist.Substring(1, creditlist.Length - 1);
            foreach (var item in groupBy)
            {
                var c31BBModel = reports.FirstOrDefault(r => r.RefId == item.Key.ToString()
                // && r.CreditAccount.StartsWith("111")
                );
                if (c31BBModel == null)
                    break;
                result.Add(new C41BBModel
                {
                    RefId = item.Key,
                    RefDate = c31BBModel.RefDate,
                    PostedDate = c31BBModel.PostedDate,
                    RefNo = c31BBModel.RefNo,
                    AccountingObjectName = c31BBModel.AccountingObjectName,
                    Address = c31BBModel.Address,
                    JournalMemo = c31BBModel.JournalMemo,
                    DocumentIncluded = c31BBModel.DocumentIncluded,
                    Description = c31BBModel.Description,
                    SumAmount = item.Select(c => c.Amount).Sum(),
                    SumAmountOC = item.Select(c => c.AmountOC).Sum(),
                    CurrencyCode = c31BBModel.CurrencyCode,
                    DebitAccountAll = debitlist,
                    CreditAccountAll = creditlist,
                    C41BBDetails = c31BBModel.C41BBDetails.Where(c => c.CreditAccount.StartsWith("111")).ToList()
                });
            }
            return result;
        }

        /// <summary>
        /// Reports the cash deposit C41 bb.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        public IList<C41BBModel> ReportCashDepositC41BB(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<C41BBModel> reports = Model.ReportCashDepositC41BB(reportParameter.RefId);
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var result = new List<C41BBModel>();
            var groupBy = reports.GroupBy(r => r.RefId);

            string debitlist = reports.Any()
                ? reports.Where(a => a.DebitAccount != null)
                    .Select(i => i.DebitAccount.ToString())
                    .Distinct()
                    .Aggregate(string.Empty, (i, j) => i + "," + j)
                : "";
            string creditlist = reports.Any()
                ? reports.Where(a => a.CreditAccount != null)
                    .Select(i => i.CreditAccount.ToString())
                    .Distinct()
                    .Aggregate(string.Empty, (i, j) => i + "," + j)
                : "";

            if (!string.IsNullOrEmpty(debitlist) && debitlist[0] == ',')
                debitlist = debitlist.Substring(1, debitlist.Length - 1);

            if (!string.IsNullOrEmpty(creditlist) && creditlist[0] == ',')
                creditlist = creditlist.Substring(1, creditlist.Length - 1);

            foreach (var item in groupBy)
            {
                var c31BBModel = reports.FirstOrDefault(r => r.RefId == item.Key.ToString() && r.CreditAccount.StartsWith("111"));
                if (c31BBModel == null)
                    break;
                result.Add(new C41BBModel
                {
                    RefId = item.Key,
                    RefDate = c31BBModel.RefDate,
                    PostedDate = c31BBModel.PostedDate,
                    RefNo = c31BBModel.RefNo,
                    AccountingObjectName = string.IsNullOrEmpty(c31BBModel.Receiver) ? c31BBModel.AccountingObjectName : c31BBModel.Receiver,
                    Address = c31BBModel.Address,
                    JournalMemo = c31BBModel.JournalMemo,
                    DocumentIncluded = c31BBModel.DocumentIncluded,
                    Description = c31BBModel.Description,
                    SumAmount = item.Select(c => c.Amount).Sum(),
                    SumAmountOC = item.Select(c => c.AmountOC).Sum(),
                    ExchangeRate = c31BBModel.ExchangeRate,
                    CurrencyCode = c31BBModel.CurrencyCode,
                    DebitAccountAll = debitlist,
                    CreditAccountAll = creditlist,
                    C41BBDetails = c31BBModel.C41BBDetails.Where(c => c.CreditAccount.StartsWith("111")).ToList()
                });
            }


            return result;
        }

        /// <summary>
        /// Reports the cash payment get from ba deposit.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        public IList<C41BBModel> ReportCashPaymentGetFromBADeposit(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<C41BBModel> reports = Model.ReportCashPaymentGetFromBADeposit(reportParameter.RefId);
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var result = new List<C41BBModel>();
            var groupBy = reports.GroupBy(r => r.RefId);
            foreach (var item in groupBy)
            {
                var c31BBModel = reports.FirstOrDefault(r => r.RefId == item.Key.ToString() && r.CreditAccount.StartsWith("111"));
                if (c31BBModel == null)
                    break;
                result.Add(new C41BBModel
                {
                    RefId = item.Key,
                    RefDate = c31BBModel.RefDate,
                    PostedDate = c31BBModel.PostedDate,
                    RefNo = c31BBModel.RefNo,
                    AccountingObjectName = string.IsNullOrEmpty(c31BBModel.Payer) ? c31BBModel.AccountingObjectName : c31BBModel.Payer,
                    Address = c31BBModel.Address,
                    JournalMemo = c31BBModel.JournalMemo,
                    DocumentIncluded = c31BBModel.DocumentIncluded,
                    Description = c31BBModel.Description,
                    SumAmount = item.Select(c => c.Amount).Sum(),
                    SumAmountOC = item.Select(c => c.AmountOC).Sum(),
                    CurrencyCode = c31BBModel.CurrencyCode,
                    DebitAccountAll = reports.GroupBy(r => r.DebitAccount)
                        .Select(
                            g => new { DebitAccountAll = g.Aggregate(string.Empty, (x, i) => x + "," + i.DebitAccount) })
                        .ToList()[0].DebitAccountAll,
                    CreditAccountAll = reports.GroupBy(r => r.CreditAccount).
                        Select(
                            g => new { CreditAccountAll = g.Aggregate(string.Empty, (x, i) => x + "," + i.CreditAccount) })
                        .ToList()[0].CreditAccountAll
                });
            }
            return result;
        }

        /// <summary>
        /// Reports the cash payment purchase C41 bb.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;C41BBModel&gt;.</returns>
        public IList<C41BBModel> ReportCashPaymentPurchaseC41BB(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<C41BBModel> reports = Model.ReportCashPaymentPurchaseC41BB(reportParameter.RefId);
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var result = new List<C41BBModel>();
            var groupBy = reports.GroupBy(r => r.RefId);

            string debitlist = reports.Any()
                ? reports.Where(a => a.DebitAccount != null)
                    .Select(i => i.DebitAccount.ToString())
                    .Distinct()
                    .Aggregate(string.Empty, (i, j) => i + "," + j)
                : "";
            string creditlist = reports.Any()
                ? reports.Where(a => a.CreditAccount != null)
                    .Select(i => i.CreditAccount.ToString())
                    .Distinct()
                    .Aggregate(string.Empty, (i, j) => i + "," + j)
                : "";

            if (!string.IsNullOrEmpty(debitlist) && debitlist[0] == ',')
                debitlist = debitlist.Substring(1, debitlist.Length - 1);

            if (!string.IsNullOrEmpty(creditlist) && creditlist[0] == ',')
                creditlist = creditlist.Substring(1, creditlist.Length - 1);
            foreach (var item in groupBy)
            {
                var c31BBModel = reports.FirstOrDefault(r => r.RefId == item.Key.ToString() && r.CreditAccount.StartsWith("111"));
                if (c31BBModel == null)
                    break;
                result.Add(new C41BBModel
                {
                    RefId = item.Key,
                    RefDate = c31BBModel.RefDate,
                    PostedDate = c31BBModel.PostedDate,
                    RefNo = c31BBModel.RefNo,
                    AccountingObjectName = c31BBModel.AccountingObjectName,
                    Address = c31BBModel.Address,
                    JournalMemo = c31BBModel.JournalMemo,
                    DocumentIncluded = c31BBModel.DocumentIncluded,
                    Description = c31BBModel.Description,
                    SumAmount = item.Select(c => c.Amount).Sum(),
                    SumAmountOC = item.Select(c => c.AmountOC).Sum(),
                    CurrencyCode = c31BBModel.CurrencyCode,
                    DebitAccountAll = debitlist,
                    CreditAccountAll = creditlist,
                    DebitAccount = debitlist,
                    CreditAccount = debitlist,
                    C41BBDetails = c31BBModel.C41BBDetails.Where(c => c.CreditAccount.StartsWith("111")).ToList()
                });
            }
            return result;
        }

        /// <summary>
        /// Reports the C402 CKB.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<C402CKBModel> ReportC402CKB(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            // var storeProcedure = "uspReport_BAV_Withdraw_TT08_C402";
            var storeProcedure = "";
            if (reportParameter.RefType.Equals(157))
                storeProcedure = "uspReport_BAV_Withdraw_TT08_C402";
            else if (reportParameter.RefType.Equals(201))
                storeProcedure = "uspReport_CAPaymentDetailPurchase_C402A";
            else
                storeProcedure = "uspReport_BAV_Withdraw_TT08_C402_158";
            //var storeProcedure = reportParameter.RefType.Equals(157) ? "uspReport_BAV_Withdraw_TT08_C402" : "uspReport_BAV_Withdraw_TT08_C402_158";
            IList<C402CKBModel> reports = Model.ReportC402CKB(storeProcedure, reportParameter.RefId);

            if (reports == null)
                return null;
            //var result = new List<C402CKBModel>();
            List<C402CKBModel> result = null;
            var taxPayers = "";
            decimal totalAmount = 0;
            string taxCode = "";
            string budgetSubItem = "";
            var chapter = "";
            var organization = "";
            var organizationCode = "";
            var bank = "";
            var formatNumberIsssuaTax = "";
            var formatNumberDeclaration = "";
            decimal totalPayment = 0;
            decimal totalTax = 0;
            string taxPayDebitAccount1 = "";
            string taxPayCreditAccount1 = "";
            string taxPayDebitAccount2 = "";
            string taxPayCreditAccount2 = "";
            string taxPayOrganizationCode = "";
            string taxPayDBHCCode = "";
            string unitEnjoyPayDebitAccount = "";
            string unitEnjoyPayCreditAccount = "";
            using (var frmParam = new FrmC402CKB(reportParameter.RefId, storeProcedure))
            {
                if (frmParam.ShowDialog() == DialogResult.OK)
                {
                    result = new List<C402CKBModel>();
                    result = frmParam.C402CkbModelDetails.ToList();
                    totalAmount = result.Sum(x => x.Amount);
                    taxPayers = frmParam.TaxPayers;
                    taxCode = frmParam.TaxCode;
                    budgetSubItem = frmParam.BudgetSubItem;
                    chapter = frmParam.ChapterCode;
                    organization = frmParam.Organization;
                    organizationCode = frmParam.OrganizationCode;
                    bank = frmParam.AccountBank;
                    formatNumberIsssuaTax = frmParam.FormatNumberIsssuaTax;
                    formatNumberDeclaration = frmParam.FormatNumberDeclaration;
                    totalPayment = result.Sum(x => x.Payment);
                    totalTax = result.Sum(x => x.Tax);
                    taxPayDebitAccount1 = frmParam.TaxPayDebitAccount1;
                    taxPayCreditAccount1 = frmParam.TaxPayCreditAccount1;
                    taxPayDebitAccount2 = frmParam.TaxPayDebitAccount2;
                    taxPayCreditAccount2 = frmParam.TaxPayCreditAccount2;
                    taxPayOrganizationCode = frmParam.TaxPayOrganizationCode;
                    taxPayDBHCCode = frmParam.TaxPayDBHCCode;
                    unitEnjoyPayDebitAccount = frmParam.UnitEnjoyPayDebitAccount;
                    unitEnjoyPayCreditAccount = frmParam.UnitEnjoyPayCreditAccount;
                    var resultFirst = result.FirstOrDefault();
                    var accountingObject = resultFirst == null ? null : Model.GetAccountingObject(resultFirst.ReceiptObjectName);
                    if (totalTax > (decimal)0)
                    {
                        var allBudgetItems = Model.GetBudgetItems();
                        var allBudgetChapters = Model.GetBudgetChapters();
                        if (allBudgetItems == null)
                        {
                            allBudgetItems = new List<BudgetItemModel>();
                        }
                        if (allBudgetChapters == null)
                        {
                            allBudgetChapters = new List<BudgetChapterModel>();
                        }
                        if (accountingObject != null)
                        {
                            taxPayers = accountingObject.AccountingObjectName;
                            taxCode = accountingObject.CompanyTaxCode;
                            organization = accountingObject.OrganizationManageFee;
                            organizationCode = accountingObject.OrganizationFeeCode;
                            bank = accountingObject.TreasuryManageFee;
                            budgetSubItem = allBudgetItems.FirstOrDefault(o => o.BudgetItemId == accountingObject.BudgetItemId)?.BudgetItemCode;
                            chapter = allBudgetChapters.FirstOrDefault(o => o.BudgetChapterId == accountingObject.BudgetChapterId)?.BudgetChapterCode;
                        }
                    }
                    result.ForEach(item =>
                    {
                        item.ReceiptObjectName = accountingObject == null ? "" : accountingObject.AccountingObjectName;
                    });

                    //Xuất XML
                    if (!frmParam.IsPreviewOrExportXML)
                    {
                        if (result.Count > 0)
                        {
                            using (var fbd = new FolderBrowserDialog())
                            {
                                DialogResult results = DialogResult.Cancel;
                                if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                                    results = fbd.ShowDialog();
                                else
                                { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                                //if (result == null && !isParamater)
                                //{
                                //    var storeProcedure = "uspReport_BAV_Withdraw_TT08_C402";
                                //    result = Model.ReportC402CKB(storeProcedure, reportParameter.RefId).ToList();
                                //}
                                //if (result.Count <= 0)
                                //{
                                //    XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                                //        MessageBoxIcon.Information);
                                //    return null;
                                //}
                                if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                                {
                                    GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                                        ? fbd.SelectedPath
                                        : GlobalVariable.PathXML;
                                    string reportName = "C402C";
                                    string fileName = result[0].RefNo;
                                    string savepath = reportName + fileName + @".xml";
                                    Cursor.Current = Cursors.WaitCursor;
                                    XmlTextWriter writer = new XmlTextWriter(savepath,
                                        Encoding.UTF8);
                                    writer.Formatting = Formatting.Indented;
                                    writer.WriteStartDocument();

                                    writer.WriteStartElement("java");
                                    writer.WriteAttributeString("version", "1.7.0_17");
                                    writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                                    writer.WriteStartElement("object");
                                    writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "dmDvTratien");
                                    writer.WriteStartElement("string");
                                    writer.WriteString(GlobalVariable.CompanyCode);
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();
                                    //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dmTiente");//Field name
                                    writer.WriteStartElement("string");//Start string
                                    writer.WriteString(result[0].CurencyCode);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNhantienCtmt");//Field name
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNhantienDiachi");//Field name
                                    writer.WriteStartElement("string");//Start string
                                    writer.WriteString(result[0].AccountingObjectAddress);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNhantienKbnn");//Field name
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNhantienKbnnNhTen");//Field name
                                    writer.WriteStartElement("string");//Start string
                                    writer.WriteString(result[0].ReceiptAccountInBank);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNhantienLoai");//Field name
                                    writer.WriteStartElement("long");//Start string
                                    writer.WriteValue((long)(result[0].IsOpenInBank ? 0 : 1));//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNhantienMa");//Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].BudgetCode); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNhantienNganhang");//Field name
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNhantienSotien");//Field name
                                    writer.WriteStartElement("double");//Start string
                                    writer.WriteValue((double)result[0].Amount);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNhantienSotkSo");//Field name
                                    writer.WriteStartElement("string");//Start string
                                    writer.WriteString(result[0].AccountingObjectBankAccount);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNhantienTen");//Field name
                                    writer.WriteStartElement("string");//Start string
                                    writer.WriteString(result[0].ReceiptObjectName);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNopthueChuong");//Field name
                                    if (!string.IsNullOrEmpty(chapter))
                                    {
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(chapter); //Values
                                        writer.WriteEndElement(); //End string
                                    }
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNopthueCqthu");//Field name
                                    if (!string.IsNullOrEmpty(chapter))
                                    {
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(organizationCode); //Values
                                        writer.WriteEndElement(); //End string
                                    }
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNopthueCqthuMa");//Field name
                                    if (!string.IsNullOrEmpty(organizationCode))
                                    {
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(organizationCode); //Values
                                        writer.WriteEndElement(); //End string
                                    }
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNopthueCqthuTen");//Field name
                                    if (!string.IsNullOrEmpty(organization))
                                    {
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(organization); //Values
                                        writer.WriteEndElement(); //End string
                                    }
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNopthueHachtoan");//Field name
                                    if (!string.IsNullOrEmpty(bank))
                                    {
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(bank); //Values
                                        writer.WriteEndElement(); //End string
                                    }
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNopthueKythue");//Field name
                                    if (!string.IsNullOrEmpty(formatNumberIsssuaTax))
                                    {
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(formatNumberIsssuaTax); //Values
                                        writer.WriteEndElement(); //End string
                                    }
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNopthueMa");//Field name
                                    if (!string.IsNullOrEmpty(taxCode))
                                    {
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(taxCode); //Values
                                        writer.WriteEndElement(); //End string
                                    }
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNopthueNdkt");//Field name
                                    if (!string.IsNullOrEmpty(budgetSubItem))
                                    {
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(budgetSubItem); //Values
                                        writer.WriteEndElement(); //End string
                                    }
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNopthueStk");//Field name
                                    if (!string.IsNullOrEmpty(formatNumberDeclaration))
                                    {
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(formatNumberDeclaration); //Values
                                        writer.WriteEndElement(); //End string
                                    }
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvNopthueTen");//Field name
                                    if (!string.IsNullOrEmpty(taxPayers))
                                    {
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(taxPayers); //Values
                                        writer.WriteEndElement(); //End string
                                    }
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvTratienCtmt");//Field name
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvTratienDiachi");//Field name
                                    writer.WriteStartElement("string");//Start string
                                    writer.WriteString(GlobalVariable.CompanyAddress);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvTratienKbnn");//Field name
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvTratienKbnnNhTen");//Field name
                                    writer.WriteStartElement("string");//Start string
                                    writer.WriteString(result[0].AccountInBank);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvTratienLoai");//Field name
                                    writer.WriteStartElement("long");//Start string
                                    writer.WriteValue((long)(result[0].IsOpenInBank ? 0 : 1)); //Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvTratienMa");//Field name
                                    writer.WriteStartElement("string");//Start string
                                    writer.WriteString(GlobalVariable.CompanyCode);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "dvTratienTen");//Field name
                                    writer.WriteStartElement("string");//Start string
                                    writer.WriteString(GlobalVariable.CompanyName);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void


                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "gnHosoC402GtByGnHosoC402");

                                    writer.WriteStartElement("object");
                                    writer.WriteAttributeString("class", "java.util.ArrayList");

                                    //Detail
                                    // var detaillist = Model.GetBAWithDraw(result[0].RefId, true, true, true, true, true);
                                    var detaillist = result.ToList();
                                    var count = detaillist.Count;
                                    for (int i = 0; i < count; i++)
                                    {
                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("method", "add");
                                        writer.WriteStartElement("object");
                                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                                        //New field
                                        writer.WriteStartElement("void");//Start void
                                        writer.WriteAttributeString("property", "maHang");//Field name
                                        writer.WriteStartElement("string");//Start string
                                        writer.WriteString((i + 1).ToString());//Values
                                        writer.WriteEndElement();//End string
                                        writer.WriteEndElement();//End void
                                                                 //New field
                                        writer.WriteStartElement("void");//Start void
                                        writer.WriteAttributeString("property", "noiDung");//Field name
                                        writer.WriteStartElement("string");//Start string
                                        writer.WriteString(detaillist[i].Description);//Values
                                        writer.WriteEndElement();//End string
                                        writer.WriteEndElement();//End void
                                                                 //New field
                                        writer.WriteStartElement("void");//Start void
                                        writer.WriteAttributeString("property", "nopThue");//Field name
                                        writer.WriteStartElement("double");//Start string
                                        writer.WriteValue(detaillist[i].Tax);//Values
                                        writer.WriteEndElement();//End string
                                        writer.WriteEndElement();//End void
                                                                 //New field
                                        writer.WriteStartElement("void");//Start void
                                        writer.WriteAttributeString("property", "soTien");//Field name
                                        writer.WriteStartElement("double");//Start string
                                        writer.WriteValue(detaillist[i].Amount);//Values
                                        writer.WriteEndElement();//End string
                                        writer.WriteEndElement();//End void
                                                                 //New field
                                        writer.WriteStartElement("void");//Start void
                                        writer.WriteAttributeString("property", "thanhToan");//Field name
                                        writer.WriteStartElement("double");//Start string
                                        writer.WriteValue(detaillist[i].Amount);//Values
                                        writer.WriteEndElement();//End string
                                        writer.WriteEndElement();//End void

                                        writer.WriteEndElement(); // dvc.service.custom.TemplateChungTuGt
                                        writer.WriteEndElement(); // Add

                                    }
                                    //}
                                    writer.WriteEndElement(); // arrayList
                                    writer.WriteEndElement(); // gnHosoC202GtByGnHosoC202

                                    //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "gnTaiLieuId");//Field name
                                    writer.WriteStartElement("long");//Start string
                                    writer.WriteValue((long)421);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void

                                    //New field
                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "ngayChungTu");
                                    writer.WriteStartElement("object");
                                    writer.WriteAttributeString("class", "java.sql.Timestamp");
                                    writer.WriteStartElement("long");
                                    writer.WriteValue((long)(result[0].RefDate
                                        .ToUniversalTime()
                                        .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();
                                    writer.WriteEndElement(); // ngayChungtu

                                    //New field
                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "par1");
                                    writer.WriteStartElement("string");
                                    writer.WriteString(RSSHelper.NumberToWord.Read(result[0].Amount, "đồng", "", "#.0000"));
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();

                                    //New field
                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "par2");
                                    writer.WriteEndElement();

                                    //New field
                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "par3");
                                    writer.WriteStartElement("string");
                                    writer.WriteString(RSSHelper.NumberToWord.Read(result[0].Amount, "đồng", "", "#.0000"));
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();
                                    //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "soChungTu");//Field name
                                    writer.WriteStartElement("string");//Start string
                                    writer.WriteString(result[0].RefNo);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "tongSoTien");//Field name
                                    writer.WriteStartElement("double");//Start string
                                    writer.WriteValue((double)result[0].Amount);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void
                                                             //New field
                                    writer.WriteStartElement("void");//Start void
                                    writer.WriteAttributeString("property", "typeChungTu");//Field name
                                    writer.WriteStartElement("long");//Start string
                                    writer.WriteValue(13);//reportParameter.RefType);//Values
                                    writer.WriteEndElement();//End string
                                    writer.WriteEndElement();//End void

                                    writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                                    writer.WriteEndElement(); //java

                                    writer.WriteEndDocument();
                                    writer.Close();
                                    if (exportXml.CreateZip(fileName, fbd.SelectedPath, reportName))
                                        XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                                    else
                                        XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");
                                }
                            }
                        }
                        //  exportXml.ReportC402CKBXML(reportParameter, oRsTool, result);

                        if (result.Count <= 0)
                        {
                            XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return null;
                        }
                        return null;
                    }
                }
            }
            oRsTool.Parameters.Add("PaymentObjectName", GlobalVariable.IsValidLicense ? GlobalVariable.CompanyName : "");
            oRsTool.Parameters.Add("CompanyAddress", GlobalVariable.IsValidLicense ? GlobalVariable.CompanyAddress : "");
            if (!oRsTool.Parameters.ContainsKey("TaxPayers"))
                oRsTool.Parameters.Add("TaxPayers", taxPayers);

            if (!oRsTool.Parameters.ContainsKey("TotalAmount"))
                oRsTool.Parameters.Add("TotalAmount", totalAmount);

            if (!oRsTool.Parameters.ContainsKey("TaxCode"))
                oRsTool.Parameters.Add("TaxCode", taxCode);

            if (!oRsTool.Parameters.ContainsKey("BudgetSubItem"))
                oRsTool.Parameters.Add("BudgetSubItem", budgetSubItem);

            if (!oRsTool.Parameters.ContainsKey("Chapter"))
                oRsTool.Parameters.Add("Chapter", chapter);

            if (!oRsTool.Parameters.ContainsKey("Organization"))
                oRsTool.Parameters.Add("Organization", organization);

            if (!oRsTool.Parameters.ContainsKey("OrganizationCode"))
                oRsTool.Parameters.Add("OrganizationCode", organizationCode);

            if (!oRsTool.Parameters.ContainsKey("Bank"))
                oRsTool.Parameters.Add("Bank", bank);

            if (!oRsTool.Parameters.ContainsKey("FormatNumberIsssuaTax"))
                oRsTool.Parameters.Add("FormatNumberIsssuaTax", formatNumberIsssuaTax);

            if (!oRsTool.Parameters.ContainsKey("FormatNumberDeclaration"))
                oRsTool.Parameters.Add("FormatNumberDeclaration", formatNumberDeclaration);

            if (!oRsTool.Parameters.ContainsKey("TotalPayment"))
                oRsTool.Parameters.Add("TotalPayment", totalPayment);

            if (!oRsTool.Parameters.ContainsKey("TotalTax"))
                oRsTool.Parameters.Add("TotalTax", totalTax);

            if (!oRsTool.Parameters.ContainsKey("TaxPayDebitAccount1"))
                oRsTool.Parameters.Add("TaxPayDebitAccount1", taxPayDebitAccount1);

            if (!oRsTool.Parameters.ContainsKey("TaxPayCreditAccount1"))
                oRsTool.Parameters.Add("TaxPayCreditAccount1", taxPayCreditAccount1);

            if (!oRsTool.Parameters.ContainsKey("TaxPayDebitAccount2"))
                oRsTool.Parameters.Add("TaxPayDebitAccount2", taxPayDebitAccount2);

            if (!oRsTool.Parameters.ContainsKey("TaxPayCreditAccount2"))
                oRsTool.Parameters.Add("TaxPayCreditAccount2", taxPayCreditAccount2);

            if (!oRsTool.Parameters.ContainsKey("TaxPayOrganizationCode"))
                oRsTool.Parameters.Add("TaxPayOrganizationCode", taxPayOrganizationCode);

            if (!oRsTool.Parameters.ContainsKey("TaxPayDBHCCode"))
                oRsTool.Parameters.Add("TaxPayDBHCCode", taxPayDBHCCode);

            if (!oRsTool.Parameters.ContainsKey("UnitEnjoyPayDebitAccount"))
                oRsTool.Parameters.Add("UnitEnjoyPayDebitAccount", unitEnjoyPayDebitAccount);

            if (!oRsTool.Parameters.ContainsKey("UnitEnjoyPayCreditAccount"))
                oRsTool.Parameters.Add("UnitEnjoyPayCreditAccount", unitEnjoyPayCreditAccount);

            return result;
        }



        /// <summary>
        /// Reports the C402 CKB.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<C402CKBModel> ReportC402BKB(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            //var storeProcedure = "uspReport_BAV_Withdraw_TT08_C402";
            var storeProcedure = reportParameter.RefType.Equals(157) ? "uspReport_BAV_Withdraw_TT08_C402" : "uspReport_BAV_Withdraw_TT08_C402_158";
            IList<C402CKBModel> reports = Model.ReportC402CKB(storeProcedure, reportParameter.RefId);
            if (reports == null)
                return null;
            //var result = new List<C402CKBModel>();
            List<C402CKBModel> result = null;
            var taxPayers = "";
            decimal totalAmount = 0;
            string taxCode = "";
            string budgetSubItem = "";
            var chapter = "";
            var organization = "";
            var organizationCode = "";
            var bank = "";
            var formatNumberIsssuaTax = "";
            var formatNumberDeclaration = "";
            decimal totalPayment = 0;
            decimal totalTax = 0;
            string taxPayDebitAccount1 = "";
            string taxPayCreditAccount1 = "";
            string taxPayDebitAccount2 = "";
            string taxPayCreditAccount2 = "";
            string taxPayOrganizationCode = "";
            string taxPayDBHCCode = "";
            string unitEnjoyPayDebitAccount = "";
            string unitEnjoyPayCreditAccount = "";
            using (var frmParam = new FrmC402CKB(reportParameter.RefId, storeProcedure))
            {
                if (frmParam.ShowDialog() == DialogResult.OK)
                {
                    result = new List<C402CKBModel>();
                    result = reports.ToList();
                    totalAmount = result.Sum(x => x.Amount);
                    taxPayers = frmParam.TaxPayers;
                    taxCode = frmParam.TaxCode;
                    budgetSubItem = frmParam.BudgetSubItem;
                    chapter = frmParam.ChapterCode;
                    organization = frmParam.Organization;
                    organizationCode = frmParam.OrganizationCode;
                    bank = frmParam.AccountBank;
                    formatNumberIsssuaTax = frmParam.FormatNumberIsssuaTax;
                    formatNumberDeclaration = frmParam.FormatNumberDeclaration;
                    totalPayment = result.Sum(x => x.Payment);
                    totalTax = result.Sum(x => x.Tax);
                    taxPayDebitAccount1 = frmParam.TaxPayDebitAccount1;
                    taxPayCreditAccount1 = frmParam.TaxPayCreditAccount1;
                    taxPayDebitAccount2 = frmParam.TaxPayDebitAccount2;
                    taxPayCreditAccount2 = frmParam.TaxPayCreditAccount2;
                    taxPayOrganizationCode = frmParam.TaxPayOrganizationCode;
                    taxPayDBHCCode = frmParam.TaxPayDBHCCode;
                    unitEnjoyPayDebitAccount = frmParam.UnitEnjoyPayDebitAccount;
                    unitEnjoyPayCreditAccount = frmParam.UnitEnjoyPayCreditAccount;

                    //Xuất XML
                    if (!frmParam.IsPreviewOrExportXML)
                    {
                        if (result.Count > 0)
                            exportXml.ReportC402BKBXML(reportParameter, oRsTool, result);

                        if (result.Count <= 0)
                        {
                            XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return null;
                        }
                        return null;
                    }
                }
            }
            oRsTool.Parameters.Add("PaymentObjectName", GlobalVariable.IsValidLicense ? GlobalVariable.CompanyName : "");
            oRsTool.Parameters.Add("CompanyAddress", GlobalVariable.IsValidLicense ? GlobalVariable.CompanyAddress : "");
            if (!oRsTool.Parameters.ContainsKey("TaxPayers"))
                oRsTool.Parameters.Add("TaxPayers", taxPayers);

            if (!oRsTool.Parameters.ContainsKey("TotalAmount"))
                oRsTool.Parameters.Add("TotalAmount", totalAmount);

            if (!oRsTool.Parameters.ContainsKey("TaxCode"))
                oRsTool.Parameters.Add("TaxCode", taxCode);

            if (!oRsTool.Parameters.ContainsKey("BudgetSubItem"))
                oRsTool.Parameters.Add("BudgetSubItem", budgetSubItem);

            if (!oRsTool.Parameters.ContainsKey("Chapter"))
                oRsTool.Parameters.Add("Chapter", chapter);

            if (!oRsTool.Parameters.ContainsKey("Organization"))
                oRsTool.Parameters.Add("Organization", organization);

            if (!oRsTool.Parameters.ContainsKey("OrganizationCode"))
                oRsTool.Parameters.Add("OrganizationCode", organizationCode);

            if (!oRsTool.Parameters.ContainsKey("Bank"))
                oRsTool.Parameters.Add("Bank", bank);

            if (!oRsTool.Parameters.ContainsKey("FormatNumberIsssuaTax"))
                oRsTool.Parameters.Add("FormatNumberIsssuaTax", formatNumberIsssuaTax);

            if (!oRsTool.Parameters.ContainsKey("FormatNumberDeclaration"))
                oRsTool.Parameters.Add("FormatNumberDeclaration", formatNumberDeclaration);

            if (!oRsTool.Parameters.ContainsKey("TotalPayment"))
                oRsTool.Parameters.Add("TotalPayment", totalPayment);

            if (!oRsTool.Parameters.ContainsKey("TotalTax"))
                oRsTool.Parameters.Add("TotalTax", totalTax);

            if (!oRsTool.Parameters.ContainsKey("TaxPayDebitAccount1"))
                oRsTool.Parameters.Add("TaxPayDebitAccount1", taxPayDebitAccount1);

            if (!oRsTool.Parameters.ContainsKey("TaxPayCreditAccount1"))
                oRsTool.Parameters.Add("TaxPayCreditAccount1", taxPayCreditAccount1);

            if (!oRsTool.Parameters.ContainsKey("TaxPayDebitAccount2"))
                oRsTool.Parameters.Add("TaxPayDebitAccount2", taxPayDebitAccount2);

            if (!oRsTool.Parameters.ContainsKey("TaxPayCreditAccount2"))
                oRsTool.Parameters.Add("TaxPayCreditAccount2", taxPayCreditAccount2);

            if (!oRsTool.Parameters.ContainsKey("TaxPayOrganizationCode"))
                oRsTool.Parameters.Add("TaxPayOrganizationCode", taxPayOrganizationCode);

            if (!oRsTool.Parameters.ContainsKey("TaxPayDBHCCode"))
                oRsTool.Parameters.Add("TaxPayDBHCCode", taxPayDBHCCode);

            if (!oRsTool.Parameters.ContainsKey("UnitEnjoyPayDebitAccount"))
                oRsTool.Parameters.Add("UnitEnjoyPayDebitAccount", unitEnjoyPayDebitAccount);

            if (!oRsTool.Parameters.ContainsKey("UnitEnjoyPayCreditAccount"))
                oRsTool.Parameters.Add("UnitEnjoyPayCreditAccount", unitEnjoyPayCreditAccount);

            return result;
        }

        /// <summary>
        /// Reports the C402 CKB.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>


        public IList<C402CKBModel> ReportC402AKB(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var storeProcedure = "";
            if (reportParameter.RefType.Equals(157))
                storeProcedure = "uspReport_BAV_Withdraw_TT08_C402";
            else if (reportParameter.RefType.Equals(201))
                storeProcedure = "uspReport_CAPaymentDetailPurchase_C402A";
            else if (reportParameter.RefType.Equals(108))
                storeProcedure = "uspReport_CAPaymentDetailFixedAsset_C402A";
            else
                storeProcedure = "uspReport_BAV_Withdraw_TT08_C402_158";
            //reportParameter.RefType.Equals(157) ? "uspReport_BAV_Withdraw_TT08_C402" : "uspReport_BAV_Withdraw_TT08_C402_158";
            IList<C402CKBModel> reports = Model.ReportC402CKB(storeProcedure, reportParameter.RefId);
            //var result = new List<C402CKBModel>();
            List<C402CKBModel> result = null;
            var taxPayers = "";
            decimal totalAmount = reports == null ? 0 : reports.Sum(x => x.Amount);
            string taxCode = "";
            string budgetSubItem = "";
            var chapter = "";
            var organization = "";
            var organizationCode = "";
            var bank = "";
            var formatNumberIsssuaTax = "";
            var formatNumberDeclaration = "";
            var donorsCode = "";
            decimal totalPayment = 0;
            decimal totalTax = 0;
            bool checkBankTransfer=false;
            bool checkCashInBank=false;
            bool checkCashInTreasury=false;

            using (var frmParam = new FrmC402CKB(reportParameter.RefId, storeProcedure))
            {
                frmParam.ShowDialog();
                if (frmParam.DialogResult == DialogResult.OK)
                {
                    result = new List<C402CKBModel>();
                    result = reports.ToList();
                    totalAmount = result.Sum(x => x.Amount);
                    taxPayers = frmParam.TaxPayers;
                    donorsCode = frmParam.DonorsCode;
                    taxCode = frmParam.TaxCode;
                    budgetSubItem = frmParam.BudgetSubItem;
                    chapter = frmParam.ChapterCode;
                    organization = frmParam.Organization;
                    organizationCode = frmParam.OrganizationCode;
                    bank = frmParam.AccountBank;
                    formatNumberIsssuaTax = frmParam.FormatNumberIsssuaTax;
                    formatNumberDeclaration = frmParam.FormatNumberDeclaration;
                    totalPayment = result.Sum(x => x.Payment);
                    totalTax = result.Sum(x => x.Tax);
                    checkBankTransfer = frmParam.CheckBankTransfer;
                    checkCashInBank = frmParam.CheckCashInBank;
                    checkCashInTreasury = frmParam.CheckCashInTreasury;

                    var resultFirst = result.FirstOrDefault();
                    if (resultFirst != null)
                    {
                        var accountingObject = Model.GetAccountingObject(resultFirst.ReceiptObjectName);
                        result.ForEach(item =>
                        {
                            item.ReceiptObjectName = accountingObject == null ? "" : accountingObject.AccountingObjectName;
                        });
                    }
                    if (!frmParam.IsMultiView && result.Any() && result.Count > 1)
                    {
                        string activeCode = "";
                        int countResult = 1;
                        var resultActiveCodeList = result.Select(s => s.ActivityCode).Distinct().ToList();
                        resultActiveCodeList.ForEach(itemResult =>
                        {
                            activeCode = activeCode + itemResult;
                            if (countResult < resultActiveCodeList.Count())
                            {
                                activeCode = activeCode + ", ";
                            }
                            countResult++;
                        });
                        var item = new C402CKBModel
                        {
                            Description = result.First().DescriptionReplaced,
                            Amount = result.Sum(x => x.Amount),
                            RefId = result.First().RefId,
                            RefNo = result.First().RefNo,
                            EditVersion = result.First().EditVersion,
                            AccountingObjectAddress = result.First().AccountingObjectAddress,
                            Tax = result.Sum(x => x.Tax),
                            DescriptionReplaced = result.First().DescriptionReplaced,
                            BankAccount = result.First().BankAccount,
                            ReceiptObjectName = result.First().ReceiptObjectName,
                            ReceiptCode = result.First().ReceiptCode,
                            AccountInBank = result.First().AccountInBank,
                            AccountingObjectBankAccount = result.First().AccountingObjectBankAccount,
                            ReceiptTargetProgram = result.First().ReceiptTargetProgram,
                            RefDate = result.First().RefDate,
                            Payment = result.Sum(x => x.Payment),
                            ReceiptAccountInBank = result.First().ReceiptAccountInBank,
                            CurencyCode = result.First().CurencyCode,
                            IsOpenInBank = result.First().IsOpenInBank,
                            BudgetCode = result.First().BudgetCode,
                            ActivityGrade = result.First().ActivityGrade,
                            ActivityCode = activeCode, //result.First().ActivityCode,
                            ReceiveId = result.First().ReceiveId,
                            ReceiveIssueDate = result.First().ReceiveIssueDate,
                            ReceiveIssueLocation = result.First().ReceiveIssueLocation,
                            ReceiveName = result.First().ReceiveName,
                        };
                        result = new List<C402CKBModel> { item };
                    }
                }
                if (frmParam.DialogResult == DialogResult.Cancel)
                {
                    return null;
                }

                //Xuất XML
                if (!frmParam.IsPreviewOrExportXML)
                {
                    if (result.Count > 0)
                    {

                        exportXml.ReportC402AKBXML(reportParameter, oRsTool, result);
                    }

                    if (result.Count <= 0)
                    {
                        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return null;
                    }
                    return null;
                }
            }
            if (!oRsTool.Parameters.ContainsKey("DonorsCode"))
                oRsTool.Parameters.Add("DonorsCode", donorsCode);
            if (!oRsTool.Parameters.ContainsKey("TaxPayers"))
                oRsTool.Parameters.Add("TaxPayers", taxPayers);
            if (!oRsTool.Parameters.ContainsKey("ReceiveIssueLocation"))
                oRsTool.Parameters.Add("ReceiveIssueLocation", result[0].ReceiveIssueLocation);
            if (!oRsTool.Parameters.ContainsKey("ReceiveName"))
                oRsTool.Parameters.Add("ReceiveName", result[0].ReceiveName);
            if (!oRsTool.Parameters.ContainsKey("ReceiveId"))
                oRsTool.Parameters.Add("ReceiveId", result[0].ReceiveId);
            if (!oRsTool.Parameters.ContainsKey("ReceiveIssueDate"))
                oRsTool.Parameters.Add("ReceiveIssueDate", result[0].ReceiveIssueDate);
            if (!oRsTool.Parameters.ContainsKey("TotalAmount"))
                oRsTool.Parameters.Add("TotalAmount", totalAmount);
            oRsTool.Parameters.Add("PaymentObjectName", GlobalVariable.IsValidLicense ? GlobalVariable.CompanyName : "");
            oRsTool.Parameters.Add("CompanyAddress", GlobalVariable.IsValidLicense ? GlobalVariable.CompanyAddress : "");
            if (!oRsTool.Parameters.ContainsKey("TaxCode"))
                oRsTool.Parameters.Add("TaxCode", taxCode);

            if (!oRsTool.Parameters.ContainsKey("BudgetSubItem"))
                oRsTool.Parameters.Add("BudgetSubItem", budgetSubItem);

            if (!oRsTool.Parameters.ContainsKey("Chapter"))
                oRsTool.Parameters.Add("Chapter", chapter);

            if (!oRsTool.Parameters.ContainsKey("Organization"))
                oRsTool.Parameters.Add("Organization", organization);

            if (!oRsTool.Parameters.ContainsKey("OrganizationCode"))
                oRsTool.Parameters.Add("OrganizationCode", organizationCode);

            if (!oRsTool.Parameters.ContainsKey("Bank"))
                oRsTool.Parameters.Add("Bank", bank);

            if (!oRsTool.Parameters.ContainsKey("FormatNumberIsssuaTax"))
                oRsTool.Parameters.Add("FormatNumberIsssuaTax", formatNumberIsssuaTax);

            if (!oRsTool.Parameters.ContainsKey("FormatNumberDeclaration"))
                oRsTool.Parameters.Add("FormatNumberDeclaration", formatNumberDeclaration);

            if (!oRsTool.Parameters.ContainsKey("TotalPayment"))
                oRsTool.Parameters.Add("TotalPayment", totalPayment);

            if (!oRsTool.Parameters.ContainsKey("TotalTax"))
                oRsTool.Parameters.Add("TotalTax", totalTax);

            if (!oRsTool.Parameters.ContainsKey("checkBankTransfer"))
                oRsTool.Parameters.Add("checkBankTransfer", checkBankTransfer);
            if (!oRsTool.Parameters.ContainsKey("checkCashInBank"))
                oRsTool.Parameters.Add("checkCashInBank", checkCashInBank);
            if (!oRsTool.Parameters.ContainsKey("checkCashInTreasury"))
                oRsTool.Parameters.Add("checkCashInTreasury", checkCashInTreasury);
            return result;
        }



        public IList<TT39Model> ReportTT39(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var result = new List<TT39Model>();
            try
            {// TT39 chi tiền gửi
                using (var frmParam = new FrmPaymentVoucherListPrintFromVoucher_TT39 { RefId = reportParameter.RefId, ReportId = "157_BK.TT39.2016", RefType = reportParameter.RefType })
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {

                        result = frmParam.TT39Models.ToList();
                        //var bUTransfer = Model.GetBAWithDrawFixedAccess(reportParameter.RefId, true, false, false, false, true);
                        //foreach (var item in bUTransfer.BAWithDrawDetailFixedAssets)
                        //{
                        //    result.Add(new TT39Model
                        //    {
                        //        RefDate = bUTransfer.PostedDate,
                        //        PostedDate = bUTransfer.PostedDate,
                        //        RefNo = bUTransfer.RefNo,
                        //        Description = item.Description,
                        //        Amount = item.Amount,
                        //        BudgetItemCode = item.BudgetItemCode,
                        //        BudgetSubItemCode = item.BudgetSubItemCode,

                        //    });
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
            return result;
        }

        #endregion

        #region Giấy nộp tiền vào kho bạc

        /// <summary>
        /// Reports the cash payment C408.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<C408Model> ReportCashPaymentC408(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<C408Model> reports = Model.ReportCashPaymentC408(reportParameter.RefType, reportParameter.RefId);
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            var result = new List<C408Model>();
            var groupBy = reports.GroupBy(r => r.RefId);
            foreach (var item in groupBy)
            {
                var c408Model = reports.FirstOrDefault(r => r.RefId == item.Key.ToString());
                if (c408Model == null)
                    break;
                result.Add(new C408Model
                {
                    RefId = item.Key,
                    RefDate = c408Model.RefDate,
                    PostedDate = c408Model.PostedDate,
                    RefNo = c408Model.RefNo,
                    //AccountingObjectName = c408Model.AccountingObjectName,
                    AccountingObjectName = string.IsNullOrEmpty(c408Model.Payer) ? c408Model.AccountingObjectName : c408Model.Payer,
                    AccountingObjectAddress = c408Model.AccountingObjectAddress,
                    BankAccount = c408Model.BankAccount,
                    BankName = c408Model.BankName,
                    RefType = c408Model.RefType,
                    SumAmount = c408Model.C408Details.Select(c => c.Amount).Sum(),
                    SumAmountOC = c408Model.C408Details.Select(c => c.AmountOC).Sum(),
                    DebitAccountAll =
                        c408Model.C408Details.Select(c => c.DebitAccount).Aggregate(string.Empty, (x, i) => x + "," + i),
                    CreditAccountAll =
                        c408Model.C408Details.Select(c => c.CreditAccount)
                            .Aggregate(string.Empty, (x, i) => x + "," + i),
                    C408Details = c408Model.C408Details
                });
            }
            return result;
        }

        #endregion

        #region Phiếu thu 

        public IList<C40BBModel> ReportCashReceiptC30BB(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            List<C40BBModel> reports = new List<C40BBModel>();
            if (reportParameter.IsInTheoLo)
            {
                var choseCAReceipt = new FrmChooseCaReceipt();
                choseCAReceipt.ShowDialog();
                if (choseCAReceipt.DialogResult == DialogResult.OK)
                {
                    if (choseCAReceipt.RefIds.Count == 0)
                    {
                        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        return null;
                    }
                    choseCAReceipt.RefIds.ForEach(refId =>
                    {
                        var response = Model.ReportCashReceiptC30BB(refId);
                        reports.AddRange(response);
                    });

                }
                if (choseCAReceipt.DialogResult == DialogResult.Cancel)
                {
                    return null;
                }

            }
            else
            {

                reports = Model.ReportCashReceiptC30BB(reportParameter.RefId).ToList();
            }
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var result = new List<C40BBModel>();
            var groupBy = reports.GroupBy(r => r.RefId);
            string debitlist = reports.Any()
                ? reports.Where(a => a.DebitAccount != null)
                    .Select(i => i.DebitAccount.ToString())
                    .Distinct()
                    .Aggregate((i, j) => i + "," + j)
                : "";
            string creditlist = reports.Any()
                ? reports.Where(a => a.CreditAccount != null)
                    .Select(i => i.CreditAccount.ToString())
                    .Distinct()
                    .Aggregate((i, j) => i + "," + j)
                : "";
            var _exchangeRateDecimalDigits = string.IsNullOrEmpty(GlobalVariable.ExchangeRateDecimalDigits) ? "0" : GlobalVariable.ExchangeRateDecimalDigits;
            foreach (var item in groupBy)
            {
                var c30BBModel = reports.FirstOrDefault(r => r.RefId == item.Key.ToString());
                if (c30BBModel == null)
                    break;

                result.Add(new C40BBModel
                {
                    RefId = c30BBModel.RefId,
                    RefType = c30BBModel.RefType,
                    RefDate = c30BBModel.RefDate,
                    PostedDate = c30BBModel.PostedDate,
                    RefNo = c30BBModel.RefNo,
                    OutwardRefNo = c30BBModel.OutwardRefNo,
                    Address = c30BBModel.Address,
                    AccountingObjectContactName = string.IsNullOrEmpty(c30BBModel.Payer) ? c30BBModel.AccountingObjectContactName : c30BBModel.Payer,
                    JournalMemo = c30BBModel.JournalMemo,
                    DocumentIncluded = c30BBModel.DocumentIncluded,
                    TotalAmount = c30BBModel.TotalAmount,
                    TotalAmountOC = c30BBModel.TotalAmountOC,
                    TotalCashAmount = c30BBModel.TotalCashAmount,
                    TotalCashAmountOC = c30BBModel.TotalCashAmountOC,
                    Description = c30BBModel.Description,
                    Amount = c30BBModel.Amount,
                    BudgetChapterCode = c30BBModel.BudgetChapterCode,
                    BudgetKindItemCode = c30BBModel.BudgetKindItemCode,
                    AmountOC = c30BBModel.AmountOC,
                    ExchangeRate = c30BBModel.ExchangeRate,
                    ExChangeRateFormat = c30BBModel.ExchangeRate.ToString("c" + Convert.ToString(_exchangeRateDecimalDigits)),
                    CurrencyCode = c30BBModel.CurrencyCode,
                    SortOrder = c30BBModel.SortOrder,
                    DebitAccount = c30BBModel.DebitAccount,
                    CreditAccount = c30BBModel.CreditAccount,
                    C40Details = c30BBModel.C40Details
                });

                DateTime dt = DateTime.Now;
                if (GlobalVariable.PrintSystemDate == 1)
                {
                    dt = DateTime.Now;
                }
                else if (GlobalVariable.PrintSystemDate == 2)
                {
                    dt = c30BBModel.RefDate;
                }
                if (!oRsTool.Parameters.ContainsKey("ParamDate"))
                    oRsTool.Parameters.Add("ParamDate", dt.ToShortDateString());
            }
            return result;
        }

        public IList<C45_BBModel> ReportCashRecepitC45BB(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<C45_BBModel> reports = Model.ReportCashRecepitC45BB(reportParameter.RefId);
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var result = new List<C45_BBModel>();
            var groupBy = reports.GroupBy(r => r.RefId);
            string debitlist = string.Empty;
            string creditlist = string.Empty;
            foreach (var item in groupBy)
            {
                var c30BBModel = reports.FirstOrDefault(r => r.RefId == item.Key.ToString());
                if (c30BBModel == null)
                    break;
                result.Add(new C45_BBModel
                {
                    RefId = c30BBModel.RefId,
                    RefDate = c30BBModel.RefDate,
                    PostedDate = c30BBModel.PostedDate,
                    RefNo = c30BBModel.RefNo,
                    OutwardRefNo = c30BBModel.OutwardRefNo,
                    Address = c30BBModel.Address,
                    AccountingObjectContactName = c30BBModel.AccountingObjectContactName,
                    JournalMemo = c30BBModel.JournalMemo,
                    TotalAmount = c30BBModel.TotalAmount,
                });
            }
            return result;
        }

        #endregion

        #region Phiếu xuất kho

        /// <summary>
        /// Reports the cash receipt sale outward stock.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>System.Collections.Generic.IList&lt;Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher.C21HDModel&gt;.</returns>
        public IList<C21HDModel> ReportCashReceiptSaleOutwardStock(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            var list = Model.ReportCashReceiptSaleOutwardStock(reportParameter.RefId);
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            if (list == null)
            {
                return new List<C21HDModel>();
                foreach (var c21HD in list.ToList())
                {

                    if (list.Count > 1)
                    {
                        if (c21HD.Details.Count == 0)
                        {
                            list.Remove(c21HD);
                        }
                    }
                    else
                    {
                        if (c21HD.Details.Count == 0)
                        {
                            return new List<C21HDModel>();
                        }
                    }

                }
            }
            foreach (var item in list)
            {
                if (item.RefId == null)
                {
                    return new List<C21HDModel>();
                }
            }
            DateTime dt = DateTime.Now;
            if (GlobalVariable.PrintSystemDate == 1)
            {
                dt = DateTime.Now;
            }
            else if (GlobalVariable.PrintSystemDate == 2)
            {
                dt = list[0].RefDate;
            }
            if (!oRsTool.Parameters.ContainsKey("DateParam"))
                oRsTool.Parameters.Add("DateParam", dt.ToShortDateString());
            return list;
        }

        #endregion#

        #region Phiếu nhập kho

        /// <summary>
        /// Reports the cash receipt sale C20 hd.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;C20HDModel&gt;.</returns>
        public IList<C20HDModel> ReportCashReceiptSaleC20HD(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var list = Model.ReportCashReceiptSaleC20HD(reportParameter.RefId, reportParameter.RefType);
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            if (list == null)
            {
                return new List<C20HDModel>();
            }
            foreach (var item in list)
            {
                //if (item.RefId == null)
                //{
                //    return new List<C20HDModel>();
                //}
                DateTime dt = DateTime.Now;
                if (GlobalVariable.PrintSystemDate == 1)
                {
                    dt = DateTime.Now;
                }
                else if (GlobalVariable.PrintSystemDate == 2)
                {
                    dt = item.RefDate;
                }
                if (!oRsTool.Parameters.ContainsKey("ParamDate"))
                    oRsTool.Parameters.Add("ParamDate", dt.ToShortDateString());
            }
            return list;
        }

        #endregion

        #region Phiếu thu rút tiền gửi NH, KB

        public IList<C4_09Model> ReportCAReceipt_C4_09(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            try
            {
                IList<C4_09Model> list = null;
                GlobalVariable.IsDisplayNewLicenseInfo = false;
                list = Model.ReportCAReceipt_C4_09(reportParameter.RefId, (Enum.RefType)reportParameter.RefType);

                int isshowdetail = 1;
                int isshowdate = 1;
                string accountdebit = "", accountcredit = "";
                //AnhNT: Thêm đoạn này để hiển thị người nộp tiền thay thế cho tên đối tượng nộp tiền nếu có nhập
                foreach (var listdetail in list)
                {
                    listdetail.AccountingObjectName = string.IsNullOrEmpty(listdetail.Payer)
                        ? listdetail.AccountingObjectName
                        : listdetail.Payer;
                }
                //------------------------------------------------
                //using (var frmParam = new FrmC4_09())
                //{
                //    if (frmParam.ShowDialog() == DialogResult.OK)
                //    {
                //        isshowdate = Convert.ToInt32(frmParam.isshowdate);
                //        isshowdetail = Convert.ToInt32(frmParam.isshowdetail);
                //        accountcredit = frmParam.accountcredit;
                //        accountdebit = frmParam.accountdebit;

                //    }
                //    else
                //    {
                //        return null;
                //    }
                //}
                if (!oRsTool.Parameters.ContainsKey("IsShowDate"))
                    oRsTool.Parameters.Add("IsShowDate", isshowdate);

                if (!oRsTool.Parameters.ContainsKey("IsShowDetail"))
                    oRsTool.Parameters.Add("IsShowDetail", isshowdetail);

                if (!oRsTool.Parameters.ContainsKey("AccountDebit"))
                    oRsTool.Parameters.Add("AccountDebit", accountdebit);

                if (!oRsTool.Parameters.ContainsKey("AccountCredit"))
                    oRsTool.Parameters.Add("AccountCredit", accountcredit);
                if (!oRsTool.Parameters.ContainsKey("CompanyCode"))
                    oRsTool.Parameters.Add("CompanyCode",
                        string.IsNullOrEmpty(GlobalVariable.CompanyCode) ? string.Empty : GlobalVariable.CompanyCode);
                return list;
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
        }


        #endregion

        public IList<TT39Model> ReportVoucherListTT39(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var result = new List<TT39Model>();
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            try
            {   // TT39 chuyển khoản kho bạc
                //using (var frmParam = new FrmPaymentVoucherListPrintFromVoucher_TT39 { ReportId = "56.01.TT39.2016", RefId = reportParameter.RefId })
                using (var frmParam = new FrmPaymentVoucherListPrintFromVoucher_TT39 { RefType = reportParameter.RefType, RefId = reportParameter.RefId })
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        result = frmParam.BUTransfer_TT39Models.OrderBy(c => c.BudgetSourceCode).ToList();
                        var isInvisibleOrgVoucher = frmParam.IsInvisibleVoucherInfo;
                        var isInvisibleWhenEmptyOrgVoucher = frmParam.IsInvisibleWhenEmptyOrgVoucher;
                        var isDisplayVoucherDate = frmParam.IsDisplayVoucherDate;
                        var hasRepeatEveryPage = frmParam.HasRepeatEveryPage;
                        var sourceCode = frmParam.SourceCode;
                        var evictionNumber = frmParam.EvictionNumber;

                        if (!oRsTool.Parameters.ContainsKey("PostedDate"))
                            oRsTool.Parameters.Add("PostedDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyCode"))
                            oRsTool.Parameters.Add("CompanyCode", string.IsNullOrEmpty(GlobalVariable.CompanyCode) ? string.Empty : GlobalVariable.CompanyCode);


                        if (!oRsTool.Parameters.ContainsKey("IsInvisibleVoucherInfo"))
                            oRsTool.Parameters.Add("IsInvisibleVoucherInfo", isInvisibleOrgVoucher);
                        if (!oRsTool.Parameters.ContainsKey("IsInvisibleVoucherInfo"))
                            oRsTool.Parameters.Add("IsInvisibleVoucherInfo", isInvisibleOrgVoucher);
                        if (!oRsTool.Parameters.ContainsKey("IsInvisibleWhenEmptyOrgVoucher"))
                            oRsTool.Parameters.Add("IsInvisibleWhenEmptyOrgVoucher", isInvisibleWhenEmptyOrgVoucher);
                        if (!oRsTool.Parameters.ContainsKey("IsDisplayVoucherDate"))
                            oRsTool.Parameters.Add("IsDisplayVoucherDate", isDisplayVoucherDate);
                        if (!oRsTool.Parameters.ContainsKey("HasRepeatEveryPage"))
                            oRsTool.Parameters.Add("HasRepeatEveryPage", hasRepeatEveryPage);
                        if (!oRsTool.Parameters.ContainsKey("SourceCode"))
                            oRsTool.Parameters.Add("SourceCode", sourceCode);
                        if (!oRsTool.Parameters.ContainsKey("EvictionNumber"))
                            oRsTool.Parameters.Add("EvictionNumber", evictionNumber);
                        //Xuất XML
                        if (!frmParam.IsPreviewOrExportXML)
                        {
                            if (result.Count > 0)
                            {
                                exportXml.ReportVoucherListTT39XML(reportParameter, oRsTool, result);
                            }
                            if (result.Count <= 0)
                            {
                                XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                return null;
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
            if (result.Count <= 0)
                result = null;
            return result;
        }

        public IList<C203NSModel> ReportC203NSTT77(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var frmParam = new FrmC203NS();
            var result = new List<C203NSModel>();
            if (frmParam.ShowDialog() == DialogResult.OK)
            {
                result = Model.ReportC203NSTT77("," + reportParameter.RefId + ",",
                    Convert.ToDateTime(GlobalVariable.DBStartDate),
                         Convert.ToDateTime(GlobalVariable.DBStartDate),
                         frmParam.BudgetSourceKind,
                         frmParam.ProjectID,
                         frmParam.BankID,
                         frmParam.BudgetSourceID,
                         frmParam.BudgetChapterCode,
                         frmParam.BudgetSubKindItemCode,
                         frmParam.MethodDistributeId,
                         frmParam.BudgetItemCodeList,
                         false,
                        Convert.ToDateTime("2018-12-31 00:00:00"),
                         false, false, false
                         ).ToList();
                //Xuất XML
                if (!frmParam.IsPreviewOrExportXML)
                {
                    if (result.Count > 0)
                    {
                        //exportXml.ReportC203NSTT77XML(reportParameter, result);
                        using (var fbd = new FolderBrowserDialog())
                        {
                            DialogResult results = DialogResult.Cancel;
                            if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                                results = fbd.ShowDialog();
                            else
                            { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                            //if (result == null && isParamater) return null;
                            if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                            {
                                GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                                    ? fbd.SelectedPath
                                    : GlobalVariable.PathXML;
                                #region Dữ liệu xml

                                string reportName = "C203NS";
                                string fileName = result[0].RefNo;
                                string savepath = reportName + fileName + @".xml";
                                Cursor.Current = Cursors.WaitCursor;
                                XmlTextWriter writer = new XmlTextWriter(savepath,
                                    Encoding.UTF8);
                                writer.Formatting = Formatting.Indented;
                                writer.WriteStartDocument();

                                writer.WriteStartElement("java");
                                writer.WriteAttributeString("version", "1.7.0_17");
                                writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                                writer.WriteStartElement("object");
                                writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "dmTiente");
                                writer.WriteStartElement("string");
                                writer.WriteString("VND");
                                writer.WriteEndElement();
                                writer.WriteEndElement();

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsCancuTuUt"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(frmParam.TUTC.ToString()); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsCancuTuUtKbnn"); //Field name
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsCancuTuUtKbnnTen"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(" "); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "dvqhnsCancuTuUtNgay");
                                writer.WriteStartElement("object");
                                writer.WriteAttributeString("class", "java.sql.Timestamp");
                                writer.WriteStartElement("long");
                                writer.WriteValue((long)(result[0].RefDate
                                    .ToUniversalTime()
                                    .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteEndElement(); // ngayChungtu

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsCapns"); //Field name
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsCtmt"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(result[0].TargetProgramCode); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsCtmtMa"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(" "); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsCtmtTen"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(" "); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsKbnn"); //Field name
                                writer.WriteEndElement(); //End string

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsMa"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(GlobalVariable.CompanyCode); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsNamns"); //Field name
                                writer.WriteStartElement("long"); //Start string
                                writer.WriteValue((long)result[0].RefDate.Year); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsSotk"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteValue(" "); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsSotkSo"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteValue(" "); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsTen"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteValue(GlobalVariable.CompanyName); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsThanhtoanThanhTcUt"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteValue(frmParam.TUTC.ToString()); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "dvqhnsThanhtoanTuUt"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteValue(frmParam.TUTC.ToString()); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "gnHosoC203GtByGnHosoC203");
                                writer.WriteStartElement("object");
                                writer.WriteAttributeString("class", "java.util.ArrayList");

                                //Detail
                                //var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                                var count = result.Count;

                                for (int i = 0; i < count; i++)
                                {
                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("method", "add");
                                    writer.WriteStartElement("object");
                                    writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dmChuong"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[i].BudgetChapterCode); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dmNdkt"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[i].BudgetSubItemCode); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dmNganhKt"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[i].BudgetSubKindItemCode); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dmNguonchi"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[i].BudgetSourceCode); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "maHang"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString((i + 1).ToString()); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "soDeNghi"); //Field name
                                    writer.WriteStartElement("double"); //Start string
                                    writer.WriteValue((double)result[i].Col3); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "soPheDuyet"); //Field name
                                    writer.WriteStartElement("double"); //Start string
                                    writer.WriteValue((double)result[i].Col2); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "soUngTruoc"); //Field name
                                    writer.WriteStartElement("double"); //Start string
                                    writer.WriteValue((double)result[i].Col1); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //End add
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();
                                }
                                //End add
                                writer.WriteEndElement();
                                writer.WriteEndElement();

                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                                writer.WriteStartElement("long"); //Start string
                                writer.WriteValue((long)88); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "ngayChungTu");
                                writer.WriteStartElement("object");
                                writer.WriteAttributeString("class", "java.sql.Timestamp");
                                writer.WriteStartElement("long");
                                writer.WriteValue((long)(result[0].RefDate
                                    .ToUniversalTime()
                                    .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteEndElement(); // ngayChungtu

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "par1"); //Field name
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "soChungTu"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteString(result[0].RefNo); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "tongSoTien"); //Field name
                                writer.WriteStartElement("double"); //Start string
                                writer.WriteValue(0); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "tuUt"); //Field name
                                writer.WriteStartElement("string"); //Start string
                                writer.WriteValue(frmParam.TUTC.ToString()); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                //New field
                                writer.WriteStartElement("void"); //Start void
                                writer.WriteAttributeString("property", "typeChungTu"); //Field name
                                writer.WriteStartElement("long"); //Start string
                                writer.WriteValue(2); //Values
                                writer.WriteEndElement(); //End string
                                writer.WriteEndElement(); //End void

                                writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                                writer.WriteEndElement(); //java

                                writer.WriteEndDocument();
                                writer.Close();
                                if (exportXml.CreateZip(fileName, fbd.SelectedPath, reportName))
                                    XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                                else
                                    XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                                //result = null;

                                #endregion
                            }
                        }
                    }
                    if (result.Count <= 0)
                    {
                        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return null;
                    }
                    return null;
                }

            }
            if (result.Count <= 0)
                result = null;
            return result;
        }


        public List<C302NSModel> GetReportC302NS(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var frmParam = new FrmC302NS();
            var result = new List<C302NSModel>();
            var response = new List<C302NSModel>();
            var ckcHdth = "";
            var investmentText = "";
            var ctmtDaName = "";
            var ctmtDaCode = "";
            bool checkCashWithDrawTypeOne;
            bool checkCashWithDrawTypeTwo;
            bool paymentTypeOne;
            bool paymentTypeTwo;
            bool paymentTypeThree;
            bool paymentTypeFour;
            if (frmParam.ShowDialog() == DialogResult.OK)
            {
                response = Model.GetReportC302NS(reportParameter.RefId,
                    Convert.ToDateTime(GlobalVariable.DBStartDate),
                    frmParam.PayType,
                    frmParam.ProjectID,
                    frmParam.BudgetSourceID,
                    frmParam.BudgetChapterCode,
                    frmParam.BudgetSubKindItemCode,
                    frmParam.MethodDistributeId,
                    frmParam.BudgetItemCodeList,
                    frmParam.InvestmentNumber,
                    frmParam.InvestmentDate,
                    frmParam.YearPlan,
                    true//frmParam.CheckCashWithDrawType
                ).ToList();
                if (response.Count <= 0)
                {
                    XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return null;
                }
                result.Add(response[0]);
                ckcHdth = frmParam.CkcHdth;
                investmentText = frmParam.InvestmentNumber;
                ctmtDaName = frmParam.CtmtDaName;
                ctmtDaCode = frmParam.CtmtDaCode;
                checkCashWithDrawTypeOne = frmParam.CheckCashWithDrawTypeOne;
                checkCashWithDrawTypeTwo = frmParam.CheckCashWithDrawTypeTwo;
                paymentTypeOne = frmParam.PaymentTypeOne;
                paymentTypeTwo = frmParam.PaymentTypeTwo;
                paymentTypeThree = frmParam.PaymentTypeThree;
                paymentTypeFour = frmParam.PaymentTypeFour;

                //Xuất XML
                if (!frmParam.IsPreviewOrExportXML)
                {
                    if (response.Count > 0)
                    {
                        exportXml.GetReportC302NSXML(reportParameter, response);
                    }

                    if (response.Count <= 0)
                    {
                        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return null;
                    }
                    return null;
                }
                if (response.Count() > 1)
                {
                    for (var i = 1; i < response.Count(); i++)
                    {
                        response[i].AdvancePaymentAmount = 0;
                    }
                }
                var sumPayAmount = response.Sum(s => s.PayAmount);
                var sumPayableAmount = response.Sum(s => s.PayableAmount);
                var sumAdvancePaymentAmount = response.Sum(s => s.AdvancePaymentAmount);
                if (!oRsTool.Parameters.ContainsKey("SumPayAmount"))
                    oRsTool.Parameters.Add("SumPayAmount", sumPayAmount);
                if (!oRsTool.Parameters.ContainsKey("SumPayAmountReverse"))
                    oRsTool.Parameters.Add("SumPayAmountReverse", string.Format("{0:N0}", sumPayAmount));
                if (!oRsTool.Parameters.ContainsKey("SumPayableAmount"))
                    oRsTool.Parameters.Add("SumPayableAmount", sumPayableAmount);
                if (!oRsTool.Parameters.ContainsKey("SumAdvancePaymentAmount"))
                    oRsTool.Parameters.Add("SumAdvancePaymentAmount", sumAdvancePaymentAmount);
                if (!oRsTool.Parameters.ContainsKey("CkcHdth"))
                    oRsTool.Parameters.Add("CkcHdth", ckcHdth);
                if (!oRsTool.Parameters.ContainsKey("InvestmentText"))
                    oRsTool.Parameters.Add("InvestmentText", investmentText);
                if (!oRsTool.Parameters.ContainsKey("CtmtDaName"))
                    oRsTool.Parameters.Add("CtmtDaName", ctmtDaName);
                if (!oRsTool.Parameters.ContainsKey("CtmtDaCode"))
                    oRsTool.Parameters.Add("CtmtDaCode", ctmtDaCode);
                if (!oRsTool.Parameters.ContainsKey("checkCashWithDrawTypeOne"))
                    oRsTool.Parameters.Add("checkCashWithDrawTypeOne", checkCashWithDrawTypeOne);
                if (!oRsTool.Parameters.ContainsKey("checkCashWithDrawTypeTwo"))
                    oRsTool.Parameters.Add("checkCashWithDrawTypeTwo", checkCashWithDrawTypeTwo);
                if (!oRsTool.Parameters.ContainsKey("paymentTypeOne"))
                    oRsTool.Parameters.Add("paymentTypeOne", paymentTypeOne);
                if (!oRsTool.Parameters.ContainsKey("paymentTypeTwo"))
                    oRsTool.Parameters.Add("paymentTypeTwo", paymentTypeTwo);
                if (!oRsTool.Parameters.ContainsKey("paymentTypeThree"))
                    oRsTool.Parameters.Add("paymentTypeThree", paymentTypeThree);
                if (!oRsTool.Parameters.ContainsKey("paymentTypeFour"))
                    oRsTool.Parameters.Add("paymentTypeFour", paymentTypeFour);
                if (response.Count <= 0)
                    result = null;
                result.ForEach(item => item.Details = response);
                //  result.Details = response;
            }
            if (result.Count <= 0)
                result = null;
            return result;
        }
        #region Giấy rút dự toán ngân sách

        public IList<C2_02a_NSModel> ReportBUPlanWithDraw(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<C2_02a_NSModel> list = null;

            GlobalVariable.IsDisplayNewLicenseInfo = false;
            try
            {

                ProjectModel target = null;
                BankModel bank = null;
                int IsRealytoPay = 0;

                switch (reportParameter.RefType)
                {
                    case (int)Enum.RefType.BUPlanWithDrawCash:
                    case (int)Enum.RefType.BUPlanWithDrawTransfer:
                    case (int)Enum.RefType.BUPlanWithDrawDeposit:
                    case (int)Enum.RefType.BUPlanWithdrawTransferInsurrance:
                        BUPlanWithdrawModel listbuplan = new BUPlanWithdrawModel();
                        listbuplan = Model.GetBUPlanWithdrawByRefId(reportParameter.RefId, false);
                        if (listbuplan != null)
                        {
                            target = Model.GetProject(listbuplan.TargetProgramId);
                            bank = Model.GetBank(listbuplan.AccountingObjectBankId);

                        }
                        break;

                    case (int)Enum.RefType.CAReceiptEstimate:

                        CAReceiptModel itemCA = new CAReceiptModel();
                        itemCA = Model.GetReceiptVoucher(reportParameter.RefId, true, true);
                        if (itemCA != null)
                        {
                            target = Model.GetProject(itemCA.CAReceiptDetails.FirstOrDefault().ProjectId);
                            bank = Model.GetBank(itemCA.CAReceiptDetails.FirstOrDefault().BankId);
                        }

                        break;

                    case (int)Enum.RefType.BUTransfer:
                    case (int)Enum.RefType.BUTransferFixedAsset:
                    case (int)Enum.RefType.BUTransferPurchase:
                    case (int)Enum.RefType.BUTransferPayWage:
                    case (int)Enum.RefType.BUTransferPayInsurrance:
                        BUTransferModel item = new BUTransferModel();
                        item = Model.GetBUTransferVoucher(reportParameter.RefId, true);
                        if (item != null)
                        {
                            target = Model.GetProject(item.TargetProgramId);
                            bank = Model.GetBank(item.BankInfoId);
                        }

                        break;
                    case (int)Enum.RefType.BUTransferDeposits:
                        BUTransferModel items = new BUTransferModel();
                        items = Model.GetBUTransferVoucher(reportParameter.RefId, true);
                        if (items != null)
                        {
                            target = Model.GetProject(items.TargetProgramId);
                            bank = Model.GetBank(items.BankInfoId);
                        }

                        break;
                }

                string _projectCode;
                string _projectName;
                string _bankAccount;
                string _bankName;
                string CKC_HDK = "";
                string HDTH = "";
                string TKNO1 = "";
                string TKNO2 = "";
                string TKNO3 = "";
                string TKCO1 = "";
                string TKCO2 = "";
                string TKCO3 = "";
                string DBHC = "";
                int fontsize = 10;
                int numberonpage = 10;
                int numberonlastpage = 10;
                bool IsLoopSubtilte = true;
                int IsGroupDetail = 0;
                int IsShowDuplicate = 0;
                string IsCash = "0";
                int content = 1;
                using (
                    var frmParam = new FrmC2_02aNS(target == null ? null : target.ProjectCode,
                        bank == null ? null : bank.BankAccount))
                {
                    frmParam.ShowDialog();
                    if (frmParam.DialogResult == DialogResult.OK && frmParam.IsPreviewOrExportXML)
                    {
                        _projectCode = frmParam.ProjectCode;
                        _projectName = frmParam.ProjectName;
                        _bankAccount = frmParam.BankAccount;
                        _bankName = frmParam.BankName;
                        CKC_HDK = frmParam.CKC_HDK;
                        HDTH = frmParam.HDTH;
                        TKNO1 = frmParam.TKNO1;
                        TKNO2 = frmParam.TKNO2;
                        TKNO3 = frmParam.TKNO3;
                        TKCO1 = frmParam.TKCO1;
                        TKCO2 = frmParam.TKCO2;
                        TKCO3 = frmParam.TKCO3;
                        DBHC = frmParam.DBHC;
                        fontsize = frmParam.fontsize;
                        numberonpage = frmParam.numberonpage;
                        numberonlastpage = frmParam.numberonlastpage;
                        IsLoopSubtilte = frmParam.LoopSubtilte;
                        if (frmParam.RealytoPay != 0)
                        {
                            IsRealytoPay = frmParam.RealytoPay;
                        }
                        IsGroupDetail = Convert.ToInt16(frmParam.IsGroupDetail);
                        IsShowDuplicate = Convert.ToInt16(frmParam.IsShowDuplicate);

                        if (frmParam.content >= 0)
                            content = frmParam.content + 1;

                        if (!oRsTool.Parameters.ContainsKey("IsRealytoPay"))
                            oRsTool.Parameters.Add("IsRealytoPay", IsRealytoPay);

                        if (!oRsTool.Parameters.ContainsKey("TargetProgram"))
                            oRsTool.Parameters.Add("TargetProgram", _projectCode);

                        if (!oRsTool.Parameters.ContainsKey(nameof(frmParam.ProjectName)))
                            oRsTool.Parameters.Add(nameof(frmParam.ProjectName), _projectName);

                        if (!oRsTool.Parameters.ContainsKey(nameof(frmParam.BankName)))
                            oRsTool.Parameters.Add(nameof(frmParam.BankName), _bankName);

                        if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                            oRsTool.Parameters.Add("AccountNumber", _bankAccount);

                        if (!oRsTool.Parameters.ContainsKey("CKC_HDK"))
                            oRsTool.Parameters.Add("CKC_HDK", CKC_HDK);

                        if (!oRsTool.Parameters.ContainsKey("HDTH"))
                            oRsTool.Parameters.Add("HDTH", HDTH);

                        if (!oRsTool.Parameters.ContainsKey("TKNO1"))
                            oRsTool.Parameters.Add("TKNO1", TKNO1);

                        if (!oRsTool.Parameters.ContainsKey("TKNO2"))
                            oRsTool.Parameters.Add("TKNO2", TKNO2);

                        if (!oRsTool.Parameters.ContainsKey("TKNO3"))
                            oRsTool.Parameters.Add("TKNO3", TKNO3);

                        if (!oRsTool.Parameters.ContainsKey("TKCO1"))
                            oRsTool.Parameters.Add("TKCO1", TKCO1);

                        if (!oRsTool.Parameters.ContainsKey("TKCO2"))
                            oRsTool.Parameters.Add("TKCO2", TKCO2);

                        if (!oRsTool.Parameters.ContainsKey("TKCO3"))
                            oRsTool.Parameters.Add("TKCO3", TKCO3);

                        if (!oRsTool.Parameters.ContainsKey("DBHC"))
                            oRsTool.Parameters.Add("DBHC", DBHC);

                        list = Model.ReportBUPlanWithDraw(reportParameter.RefId, IsGroupDetail, IsShowDuplicate, content,
                            (Enum.RefType)reportParameter.RefType);


                        if (frmParam.IsCash == true)
                        {
                            IsCash = "7";
                        }
                        else
                        {
                            if (reportParameter.RefType == (int)RefType.BUPlanWithDrawCash ||
                                reportParameter.RefType == (int)RefType.CAReceiptEstimate)
                            {
                                IsCash = "4";
                            }
                            else { IsCash = "3"; }
                        }

                        if (!oRsTool.Parameters.ContainsKey("IsCash"))
                            oRsTool.Parameters.Add("IsCash", IsCash);

                        string cashWithDraw = "0";
                        if (IsRealytoPay == 0)
                        {
                            if
                            (
                                reportParameter.RefType == (int)RefType.BUPlanWithDrawCash ||
                                reportParameter.RefType == (int)RefType.BUPlanWithDrawTransfer ||
                                reportParameter.RefType == (int)RefType.BUPlanReceiptAddition ||
                                reportParameter.RefType == (int)RefType.BUPlanReceiptEarlyYear ||
                                reportParameter.RefType == (int)RefType.BUPlanWithDrawDeposit ||
                                reportParameter.RefType == (int)RefType.BUPlanWithdrawTransferInsurrance
                                )
                            {
                                if (list.Any())
                                {
                                    var cashWithDrawType = list.FirstOrDefault().CashWithDrawType;
                                    cashWithDraw = cashWithDrawType.Equals(4) ? "4" : "1";
                                }
                            }
                            else
                            {
                                var obj = list.Select(r => r.Details).ToList();
                                foreach (var result1 in obj)
                                {
                                    foreach (var result in result1)
                                    {

                                        if (result.CashWithDrawType == 1 || result.CashWithDrawType == 2)
                                        {
                                            cashWithDraw = cashWithDraw + "1";
                                        }
                                        if (result.CashWithDrawType == 4)
                                        {
                                            cashWithDraw = cashWithDraw + "4";
                                        }
                                    }
                                }
                            }
                        }
                        if (!oRsTool.Parameters.ContainsKey("CashWithDrawStr"))
                            oRsTool.Parameters.Add("CashWithDrawStr", cashWithDraw);
                        string employee = null;
                        string accountingObj = null;

                        string accountingObjAddress = null;
                        string accountingObjBankAccount = null;
                        string accountingObjBankName = null;

                        if (reportParameter.RefType == (int)Enum.RefType.BUTransferDeposits)
                        {
                            accountingObj = GlobalVariable.CompanyName;
                            accountingObjAddress = GlobalVariable.CompanyAddress;
                            if (Model.GetBank(list.FirstOrDefault().EmployeeBankAccount) != null)
                            {
                                accountingObjBankAccount = Model.GetBank(list.FirstOrDefault().EmployeeBankAccount).BankAccount;
                            }
                            accountingObjBankName = list.FirstOrDefault().EmployeeBankName;
                        }
                        else
                        {

                            if (list.FirstOrDefault().IsEmployee == true)
                            {
                                employee = list.FirstOrDefault().Employee;
                            }
                            else
                            {
                                accountingObj = list.FirstOrDefault().AccountingObjectName;
                                accountingObjAddress = list.FirstOrDefault().Address;
                                accountingObjBankName = list.FirstOrDefault().BankName_Object;
                                accountingObjBankAccount = list.FirstOrDefault().BankAccount_Object;

                            }

                        }

                        if (!oRsTool.Parameters.ContainsKey("Employee"))
                            oRsTool.Parameters.Add("Employee", employee);
                        if (!oRsTool.Parameters.ContainsKey("AccountingObj"))
                            oRsTool.Parameters.Add("AccountingObj", accountingObj);
                        if (!oRsTool.Parameters.ContainsKey("AccountingObjAddress"))
                            oRsTool.Parameters.Add("AccountingObjAddress", accountingObjAddress);
                        if (!oRsTool.Parameters.ContainsKey("AccountingObjBankName"))
                            oRsTool.Parameters.Add("AccountingObjBankName", accountingObjBankName);
                        if (!oRsTool.Parameters.ContainsKey("AccountingObjBankAccount"))
                            oRsTool.Parameters.Add("AccountingObjBankAccount", accountingObjBankAccount);

                        string dateReport = string.Empty;
                        if (GlobalVariable.PrintSystemDate == 1)
                        {
                            dateReport = GlobalVariable.PostedDate;
                        }
                        else if (GlobalVariable.PrintSystemDate == 2)
                        {
                            dateReport = list.FirstOrDefault().PostedDate.ToShortDateString();
                        }
                        if (!oRsTool.Parameters.ContainsKey("dateReport"))
                            oRsTool.Parameters.Add("dateReport", dateReport);
                    }

                    // Export XML file
                    if (frmParam.DialogResult == DialogResult.OK && !frmParam.IsPreviewOrExportXML)
                    {
                        _projectCode = frmParam.ProjectCode;
                        _projectName = frmParam.ProjectName;
                        _bankAccount = frmParam.BankAccount;
                        _bankName = frmParam.BankName;
                        CKC_HDK = frmParam.CKC_HDK;
                        HDTH = frmParam.HDTH;
                        TKNO1 = frmParam.TKNO1;
                        TKNO2 = frmParam.TKNO2;
                        TKNO3 = frmParam.TKNO3;
                        TKCO1 = frmParam.TKCO1;
                        TKCO2 = frmParam.TKCO2;
                        TKCO3 = frmParam.TKCO3;
                        DBHC = frmParam.DBHC;
                        fontsize = frmParam.fontsize;
                        numberonpage = frmParam.numberonpage;
                        numberonlastpage = frmParam.numberonlastpage;
                        IsLoopSubtilte = frmParam.LoopSubtilte;
                        if (frmParam.RealytoPay != 0)
                        {
                            IsRealytoPay = frmParam.RealytoPay;
                        }
                        IsGroupDetail = Convert.ToInt16(frmParam.IsGroupDetail);
                        IsShowDuplicate = Convert.ToInt16(frmParam.IsShowDuplicate);

                        if (frmParam.content >= 0)
                            content = frmParam.content + 1;

                        list = Model.ReportBUPlanWithDraw(reportParameter.RefId, IsGroupDetail, IsShowDuplicate, content,
                            (Enum.RefType)reportParameter.RefType);


                        if (frmParam.IsCash == true)
                        {
                            IsCash = "7";
                        }
                        else
                        {
                            if (reportParameter.RefType == (int)RefType.BUPlanWithDrawCash ||
                                reportParameter.RefType == (int)RefType.CAReceiptEstimate)
                            {
                                IsCash = "4";
                            }
                            else { IsCash = "3"; }
                        }

                        string cashWithDraw = "0";
                        if (IsRealytoPay == 0)
                        {
                            if
                            (
                                reportParameter.RefType == (int)RefType.BUPlanWithDrawCash ||
                                reportParameter.RefType == (int)RefType.BUPlanWithDrawTransfer ||
                                reportParameter.RefType == (int)RefType.BUPlanReceiptAddition ||
                                reportParameter.RefType == (int)RefType.BUPlanReceiptEarlyYear ||
                                reportParameter.RefType == (int)RefType.BUPlanWithDrawDeposit ||
                                reportParameter.RefType == (int)RefType.BUPlanWithdrawTransferInsurrance
                                )
                            {
                                if (list.Any())
                                {
                                    var cashWithDrawType = list.FirstOrDefault().CashWithDrawType;
                                    cashWithDraw = cashWithDrawType.Equals(4) ? "4" : "1";
                                }
                            }
                            else
                            {
                                var obj = list.Select(r => r.Details).ToList();
                                foreach (var result1 in obj)
                                {
                                    foreach (var result in result1)
                                    {

                                        if (result.CashWithDrawType == 1 || result.CashWithDrawType == 2)
                                        {
                                            cashWithDraw = cashWithDraw + "1";
                                        }
                                        if (result.CashWithDrawType == 4)
                                        {
                                            cashWithDraw = cashWithDraw + "4";
                                        }
                                    }
                                }
                            }
                        }

                        string employee = null;
                        string accountingObj = null;

                        string accountingObjAddress = null;
                        string accountingObjBankAccount = null;
                        string accountingObjBankName = null;

                        if (reportParameter.RefType == (int)Enum.RefType.BUTransferDeposits)
                        {
                            accountingObj = GlobalVariable.CompanyName;
                            accountingObjAddress = GlobalVariable.CompanyAddress;
                            if (Model.GetBank(list.FirstOrDefault().EmployeeBankAccount) != null)
                            {
                                accountingObjBankAccount = Model.GetBank(list.FirstOrDefault().EmployeeBankAccount).BankAccount;
                            }
                            accountingObjBankName = list.FirstOrDefault().EmployeeBankName;
                        }
                        else
                        {

                            if (list.FirstOrDefault().IsEmployee == true)
                            {
                                employee = list.FirstOrDefault().Employee;
                            }
                            else
                            {
                                accountingObj = list.FirstOrDefault().AccountingObjectName;
                                accountingObjAddress = list.FirstOrDefault().Address;
                                accountingObjBankName = list.FirstOrDefault().BankName_Object;
                                accountingObjBankAccount = list.FirstOrDefault().BankAccount_Object;

                            }

                        }
                        string dateReport = string.Empty;
                        if (GlobalVariable.PrintSystemDate == 1)
                        {
                            dateReport = GlobalVariable.PostedDate;
                        }
                        else if (GlobalVariable.PrintSystemDate == 2)
                        {
                            dateReport = list.FirstOrDefault().PostedDate.ToShortDateString();
                        }
                        try
                        {
                            string reportName = "C202a";
                            string fileName = list[0].RefNo;
                            string savepath = reportName + fileName + @".xml";
                            Cursor.Current = Cursors.WaitCursor;
                            XmlTextWriter writer = new XmlTextWriter(savepath,
                                Encoding.UTF8);

                            //Cursor.Current = Cursors.WaitCursor;
                            //XmlTextWriter writer = new XmlTextWriter(@"C:\" + @"C202A" + list[0].RefNo + @".xml", Encoding.UTF8);
                            writer.Formatting = Formatting.Indented;
                            writer.WriteStartDocument();

                            writer.WriteStartElement("java");
                            writer.WriteAttributeString("version", "1.7.0_17");
                            writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "chuyenkhoanTienmat");
                            writer.WriteStartElement("string");
                            writer.WriteString(IsCash.Equals("3") ? "0" : (IsCash.Equals("4") ? "2" : "3"));
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dmDvqhns");
                            writer.WriteStartElement("string");
                            writer.WriteString(GlobalVariable.CompanyAddress);
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dmTiente");
                            writer.WriteStartElement("string");
                            writer.WriteString(GlobalVariable.MainCurrencyId);
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvNhantienCtmt");
                            if (!string.IsNullOrEmpty(list[0].ProjectCode))
                            {
                                writer.WriteStartElement("string");
                                writer.WriteString(list[0].ProjectCode);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvNhantienDiachi");
                            if (accountingObjAddress != null)
                            {
                                writer.WriteStartElement("string");
                                writer.WriteString(accountingObjAddress);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvNhantienKbnn");
                            if (!string.IsNullOrEmpty(list[0].EmployeeBankAccount))
                            {
                                writer.WriteStartElement("string");
                                writer.WriteString(list[0].EmployeeBankAccount);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvNhantienKbnnTen");
                            if (accountingObj != null)
                            {
                                writer.WriteStartElement("string");
                                writer.WriteString(list[0].BankName_Object);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvNhantienLoai");
                            if (!IsCash.Equals("3"))
                            {
                                writer.WriteStartElement("long");
                                writer.WriteValue(IsCash.Equals("4") ? 0 : 1);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvNhantienMa");
                            if (!string.IsNullOrEmpty(list[0].EmployeeCode))
                            {
                                writer.WriteStartElement("string");
                                writer.WriteString(list[0].EmployeeCode);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvNhantienSotiennhan");
                            writer.WriteStartElement("double");
                            writer.WriteValue((double)list[0].Details.Sum(x => x.Amount));
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvNhantienSotkSo");
                            if (accountingObj != null)
                            {
                                writer.WriteStartElement("string");
                                writer.WriteString(list[0].BankAccount_Object);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvNhantienTen");
                            if (!string.IsNullOrEmpty(accountingObj))
                            {
                                writer.WriteStartElement("string");
                                writer.WriteString(accountingObj);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvNopthueSotiennop");
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvqhnsCapns");
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvqhnsCkcHdk");
                            if (!string.IsNullOrEmpty(CKC_HDK))
                            {
                                writer.WriteStartElement("string");
                                writer.WriteString(CKC_HDK);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvqhnsCkcHdth");
                            if (!string.IsNullOrEmpty(HDTH))
                            {
                                writer.WriteStartElement("string");
                                writer.WriteString(HDTH);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvqhnsCtmt");
                            if (!string.IsNullOrEmpty(_projectCode))
                            {
                                writer.WriteStartElement("string");
                                writer.WriteString(_projectCode);
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvqhnsKbnn");
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvqhnsMa");
                            writer.WriteStartElement("string");
                            writer.WriteString(GlobalVariable.CompanyCode);
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvqhnsNamns");
                            writer.WriteStartElement("long");
                            writer.WriteValue((long)list[0].PostedDate.Year);
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "dvqhnsTen");
                            writer.WriteStartElement("string");
                            writer.WriteString(GlobalVariable.CompanyName);
                            writer.WriteEndElement();
                            writer.WriteEndElement();

                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "gnHosoC202GtByGnHosoC202");

                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "java.util.ArrayList");

                            for (int i = 0; i < list[0].Details.Count; i++)
                            {
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("method", "add");

                                writer.WriteStartElement("object");
                                writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "dmChuong");
                                writer.WriteStartElement("string");
                                writer.WriteString(list[0].Details[i].BudgetChapterCode);
                                writer.WriteEndElement();
                                ; writer.WriteEndElement();
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "dmNdkt");
                                writer.WriteStartElement("string");
                                writer.WriteString(list[0].Details[i].BudgetSubItemCode);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "dmNganhKt");
                                writer.WriteStartElement("string");
                                writer.WriteString(list[0].Details[i].BudgetSubKindItemCode);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "dmNguonchi");
                                writer.WriteStartElement("string");
                                writer.WriteString(list[0].Details[i].BudgetSourceCode);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "dvNhantien");
                                writer.WriteStartElement("double");
                                writer.WriteValue((double)0);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "dvNopthue");
                                writer.WriteStartElement("double");
                                writer.WriteValue((double)0);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "maHang");
                                writer.WriteStartElement("string");
                                writer.WriteString(list[0].Details[i].CashWithDrawType.ToString());
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "noiDung");
                                writer.WriteStartElement("string");
                                writer.WriteString(list[0].Details[i].Memo);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                                writer.WriteStartElement("void");
                                writer.WriteAttributeString("property", "soTien");
                                writer.WriteStartElement("double");
                                writer.WriteValue(list[0].Details[i].Amount);
                                writer.WriteEndElement();
                                writer.WriteEndElement();

                                writer.WriteEndElement(); // dvc.service.custom.TemplateChungTuGt
                                writer.WriteEndElement(); // Add
                            }
                            writer.WriteEndElement(); // arrayList
                            writer.WriteEndElement(); // gnHosoC202GtByGnHosoC202

                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "gnTaiLieuId");
                            writer.WriteStartElement("long");
                            writer.WriteValue((long)423);
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "ngayChungTu");
                            writer.WriteStartElement("object");
                            writer.WriteAttributeString("class", "java.sql.Timestamp");
                            writer.WriteStartElement("long");
                            writer.WriteValue((long)(list[0].PostedDate
                                .ToUniversalTime()
                                .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteEndElement(); // ngayChungtu
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "par1");
                            writer.WriteStartElement("string");
                            writer.WriteString(RSSHelper.NumberToWord.Read(list[0].Details.Sum(item => item.Amount), "đồng", "", "#.0000"));
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "soChungTu");
                            writer.WriteStartElement("string");
                            writer.WriteString(list[0].RefNo.ToString());
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "thucchiTamung");
                            writer.WriteStartElement("string");
                            writer.WriteString(IsRealytoPay.Equals(2) ? "2" : IsRealytoPay.Equals(1) ? "3" : IsRealytoPay.Equals(0) ? (cashWithDraw.Equals("0") || cashWithDraw.Equals("1")) ? "1" : "0" : "");
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "tongSoTien");
                            writer.WriteStartElement("double");
                            writer.WriteValue(list[0].Details.Sum(item => item.Amount));
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteStartElement("void");
                            writer.WriteAttributeString("property", "typeChungTu");
                            writer.WriteStartElement("long");
                            writer.WriteValue((long)1);
                            writer.WriteEndElement();
                            writer.WriteEndElement();



                            writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                            writer.WriteEndElement(); //java

                            writer.WriteEndDocument();
                            writer.Close();
                            DialogResult results = DialogResult.Cancel;
                            var fbd = new FolderBrowserDialog();
                            if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                                results = fbd.ShowDialog();
                            else
                            { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                            if (exportXml.CreateZip(fileName, fbd.SelectedPath, reportName))
                                XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                            else
                                XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");
                            //XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                        Cursor.Current = Cursors.Default;
                        list = null;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
            return list;
        }

        public IList<C2_02a_NSModel> ReportBUPlanWithDraw_C2_02B(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<C2_02a_NSModel> list = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            try
            {
                ProjectModel target = null;
                BankModel bank = null;
                int IsRealytoPay = 0;

                switch (reportParameter.RefType)
                {
                    case (int)Enum.RefType.BUPlanWithDrawCash:
                    case (int)Enum.RefType.BUPlanWithDrawTransfer:
                    case (int)Enum.RefType.BUPlanWithDrawDeposit:
                    case (int)Enum.RefType.BUPlanWithdrawTransferInsurrance:
                        BUPlanWithdrawModel listbuplan = new BUPlanWithdrawModel();
                        listbuplan = Model.GetBUPlanWithdrawByRefId(reportParameter.RefId, false);
                        if (listbuplan != null)
                        {
                            target = Model.GetProject(listbuplan.TargetProgramId);
                            bank = Model.GetBank(listbuplan.AccountingObjectBankId);
                            // IsRealytoPay = listbuplan.CashWithDrawType;
                        }
                        break;

                    case (int)Enum.RefType.CAReceiptEstimate:
                        CAReceiptModel itemCA = new CAReceiptModel();
                        itemCA = Model.GetReceiptVoucher(reportParameter.RefId, true, true);
                        if (itemCA != null)
                        {
                            target = Model.GetProject(itemCA.CAReceiptDetails.FirstOrDefault().ProjectId);
                            bank = Model.GetBank(itemCA.CAReceiptDetails.FirstOrDefault().BankId);
                        }
                        break;

                    case (int)Enum.RefType.BUTransfer:
                    case (int)Enum.RefType.BUTransferDeposits:
                    case (int)Enum.RefType.BUTransferFixedAsset:
                    case (int)Enum.RefType.BUTransferPurchase:
                    case (int)Enum.RefType.BUTransferPayWage:
                    case (int)Enum.RefType.BUTransferPayInsurrance:
                        BUTransferModel item = new BUTransferModel();
                        item = Model.GetBUTransferVoucher(reportParameter.RefId, true);
                        if (item != null)
                        {
                            target = Model.GetProject(item.TargetProgramId);
                            bank = Model.GetBank(item?.BankInfoId);
                        }
                        //IsRealytoPay = item == null ? 0 : item.CashWithDrawType;
                        break;
                }

                string _projectCode;
                string _projectName;
                string _bankAccount;
                string _bankName;
                string CKC_HDK = "";
                string HDTH = "";
                string TKNO1 = "";
                string TKNO2 = "";
                string TKNO3 = "";
                string TKCO1 = "";
                string TKCO2 = "";
                string TKCO3 = "";
                string DBHC = "";
                int fontsize = 10;
                int numberonpage = 10;
                int numberonlastpage = 10;
                bool IsLoopSubtilte = true;
                int IsGroupDetail = 0;
                int IsShowDuplicate = 0;
                string IsCash = "0";
                int content = 1;
                string TaxDebitBankAccount1_NoChangeSize = "";
                string TaxDebitBankAccount2_NoChangeSize = "";
                string TaxDebitBankAccount3_NoChangeSize = "";
                string TaxCreditBankAccount1_NoChangeSize = "";
                string TaxCreditBankAccount2_NoChangeSize = "";
                string TaxCreditBankAccount3_NoChangeSize = "";
                string TaxOrganizationCode_NoChangeSize = "";
                string TaxLocationCode_NoChangeSize = "";
                string taxAccountingObjectName = "";
                string taxCompanyTaxCode = "";
                string taxTaxPeriod = "";
                string taxBudgetSubItemCose = "";
                string taxBudgetChapterCode = "";
                string taxOrganizationManageFee = "";
                string taxOrganizationFeeCode = "";
                string taxTreasuryManageFee = "";
                using (
                    var frmParam = new FrmC2_02bNS(reportParameter.RefId, target == null ? null : target.ProjectCode,
                        bank == null ? null : bank.BankAccount, (Enum.RefType)reportParameter.RefType))
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        // lấy thông tin voucher 
                        var voucher = Model.GetPaymentVoucher(reportParameter.RefId, false, false, false, true);


                        taxTaxPeriod = frmParam.taxTaxPeriod;
                        _projectCode = frmParam.ProjectCode;
                        _projectName = frmParam.ProjectName;
                        _bankAccount = frmParam.BankAccount;
                        _bankName = frmParam.BankName;
                        CKC_HDK = frmParam.CKC_HDK;
                        HDTH = frmParam.HDTH;
                        TKNO1 = frmParam.TKNO1;
                        TKNO2 = frmParam.TKNO2;
                        TKNO3 = frmParam.TKNO3;
                        TKCO1 = frmParam.TKCO1;
                        TKCO2 = frmParam.TKCO2;
                        TKCO3 = frmParam.TKCO3;
                        DBHC = frmParam.DBHC;
                        TaxDebitBankAccount1_NoChangeSize = frmParam.TaxDebitBankAccount1_NoChangeSize;
                        TaxDebitBankAccount2_NoChangeSize = frmParam.TaxDebitBankAccount2_NoChangeSize;
                        TaxDebitBankAccount3_NoChangeSize = frmParam.TaxDebitBankAccount3_NoChangeSize;
                        TaxCreditBankAccount1_NoChangeSize = frmParam.TaxCreditBankAccount1_NoChangeSize;
                        TaxCreditBankAccount2_NoChangeSize = frmParam.TaxCreditBankAccount2_NoChangeSize;
                        TaxCreditBankAccount3_NoChangeSize = frmParam.TaxCreditBankAccount3_NoChangeSize;
                        TaxOrganizationCode_NoChangeSize = frmParam.TaxOrganizationCode_NoChangeSize;
                        TaxLocationCode_NoChangeSize = frmParam.TaxLocationCode_NoChangeSize;





                        fontsize = frmParam.fontsize;
                        numberonpage = frmParam.numberonpage;
                        numberonlastpage = frmParam.numberonlastpage;
                        IsLoopSubtilte = frmParam.LoopSubtilte;
                        IsRealytoPay = frmParam.RealytoPay;
                        IsGroupDetail = Convert.ToInt16(frmParam.IsGroupDetail);
                        IsShowDuplicate = Convert.ToInt16(frmParam.IsShowDuplicate);

                        list = Model.ReportBUPlanWithDraw(reportParameter.RefId, IsGroupDetail, 1, 1,
                            (Enum.RefType)reportParameter.RefType);

                        //if (IsGroupDetail.Equals(1))
                        if (frmParam.C2_02a_NSDetailModels.Count > 0)
                            list.First().Details = frmParam.C2_02a_NSDetailModels;
                        //IList<C2_02a_NSDetailModel> test = frmParam.C2_02a_NSDetailModels.GroupBy(x => x.BudgetChapterCode);

                        if (voucher != null)
                        {
                            var accountingObject = Model.GetAccountingObject(voucher.AccountingObjectId);
                            if (accountingObject != null && frmParam.C2_02a_NSDetailModels.Sum(s => s.AmountTax) > 0)
                            {
                                taxAccountingObjectName = accountingObject.AccountingObjectName;
                                taxCompanyTaxCode = accountingObject.CompanyTaxCode;
                                taxTreasuryManageFee = accountingObject.TreasuryManageFee;
                                taxBudgetChapterCode = frmParam.BudgetChapters.FirstOrDefault(b => b.BudgetChapterId == accountingObject.BudgetChapterId)?.BudgetChapterCode;
                                taxBudgetSubItemCose = frmParam.BudgetItems.FirstOrDefault(b => b.BudgetItemId == accountingObject.BudgetItemId)?.BudgetItemCode;
                                taxOrganizationFeeCode = accountingObject.OrganizationFeeCode;
                                taxOrganizationManageFee = accountingObject.OrganizationManageFee;
                            }
                            else
                            {
                                taxAccountingObjectName = frmParam.taxAccountingObjectName;
                                taxCompanyTaxCode = frmParam.CompanyTaxCode;
                                taxBudgetChapterCode = frmParam.taxBudgetChapterCode;
                                taxBudgetSubItemCose = frmParam.taxBudgetSubItemCose;
                                taxTreasuryManageFee = frmParam.taxTreasuryManageFee;
                                taxOrganizationFeeCode = frmParam.taxOrganizationFeeCode;
                                taxOrganizationManageFee = frmParam.taxOrganizationManageFee;
                            }
                        }
                        if (frmParam.content >= 0)
                            content = frmParam.content + 1;

                        if (!oRsTool.Parameters.ContainsKey("IsRealytoPay"))
                            oRsTool.Parameters.Add("IsRealytoPay", IsRealytoPay);

                        if (!oRsTool.Parameters.ContainsKey("TargetProgram"))
                            oRsTool.Parameters.Add("TargetProgram", _projectCode);

                        if (!oRsTool.Parameters.ContainsKey(nameof(frmParam.ProjectName)))
                            oRsTool.Parameters.Add(nameof(frmParam.ProjectName), _projectName);

                        if (!oRsTool.Parameters.ContainsKey(nameof(frmParam.BankName)))
                            oRsTool.Parameters.Add(nameof(frmParam.BankName), _bankName);

                        if (!oRsTool.Parameters.ContainsKey("AccountNumber"))
                            oRsTool.Parameters.Add("AccountNumber", _bankAccount);

                        if (!oRsTool.Parameters.ContainsKey("CKC_HDK"))
                            oRsTool.Parameters.Add("CKC_HDK", CKC_HDK);

                        if (!oRsTool.Parameters.ContainsKey("HDTH"))
                            oRsTool.Parameters.Add("HDTH", HDTH);

                        if (!oRsTool.Parameters.ContainsKey("TKNO1"))
                            oRsTool.Parameters.Add("TKNO1", TKNO1);

                        if (!oRsTool.Parameters.ContainsKey("TKNO2"))
                            oRsTool.Parameters.Add("TKNO2", TKNO2);

                        if (!oRsTool.Parameters.ContainsKey("TKNO3"))
                            oRsTool.Parameters.Add("TKNO3", TKNO3);

                        if (!oRsTool.Parameters.ContainsKey("TKCO1"))
                            oRsTool.Parameters.Add("TKCO1", TKCO1);

                        if (!oRsTool.Parameters.ContainsKey("TKCO2"))
                            oRsTool.Parameters.Add("TKCO2", TKCO2);

                        if (!oRsTool.Parameters.ContainsKey("TKCO3"))
                            oRsTool.Parameters.Add("TKCO3", TKCO3);

                        if (!oRsTool.Parameters.ContainsKey("DBHC"))
                            oRsTool.Parameters.Add("DBHC", DBHC);

                        if (!oRsTool.Parameters.ContainsKey("TaxDebitBankAccount1_NoChangeSize"))
                            oRsTool.Parameters.Add("TaxDebitBankAccount1_NoChangeSize",
                                TaxDebitBankAccount1_NoChangeSize);

                        if (!oRsTool.Parameters.ContainsKey("TaxDebitBankAccount2_NoChangeSize"))
                            oRsTool.Parameters.Add("TaxDebitBankAccount2_NoChangeSize",
                                TaxDebitBankAccount2_NoChangeSize);

                        if (!oRsTool.Parameters.ContainsKey("TaxDebitBankAccount3_NoChangeSize"))
                            oRsTool.Parameters.Add("TaxDebitBankAccount3_NoChangeSize",
                                TaxDebitBankAccount3_NoChangeSize);

                        if (!oRsTool.Parameters.ContainsKey("TaxCreditBankAccount1_NoChangeSize"))
                            oRsTool.Parameters.Add("TaxCreditBankAccount1_NoChangeSize",
                                TaxCreditBankAccount1_NoChangeSize);

                        if (!oRsTool.Parameters.ContainsKey("TaxCreditBankAccount2_NoChangeSize"))
                            oRsTool.Parameters.Add("TaxCreditBankAccount2_NoChangeSize",
                                TaxCreditBankAccount2_NoChangeSize);

                        if (!oRsTool.Parameters.ContainsKey("TaxCreditBankAccount3_NoChangeSize"))
                            oRsTool.Parameters.Add("TaxCreditBankAccount3_NoChangeSize",
                                TaxCreditBankAccount3_NoChangeSize);

                        if (!oRsTool.Parameters.ContainsKey("TaxOrganizationCode_NoChangeSize"))
                            oRsTool.Parameters.Add("TaxOrganizationCode_NoChangeSize", TaxOrganizationCode_NoChangeSize);

                        if (!oRsTool.Parameters.ContainsKey("TaxLocationCode_NoChangeSize"))
                            oRsTool.Parameters.Add("TaxLocationCode_NoChangeSize", TaxLocationCode_NoChangeSize);

                        if (!oRsTool.Parameters.ContainsKey("taxAccountingObjectName"))
                            oRsTool.Parameters.Add("taxAccountingObjectName", taxAccountingObjectName);

                        if (!oRsTool.Parameters.ContainsKey("taxBudgetChapterCode"))
                            oRsTool.Parameters.Add("taxBudgetChapterCode", taxBudgetChapterCode);

                        if (!oRsTool.Parameters.ContainsKey("taxBudgetSubItemCose"))
                            oRsTool.Parameters.Add("taxBudgetSubItemCose", taxBudgetSubItemCose);

                        if (!oRsTool.Parameters.ContainsKey("taxCompanyTaxCode"))
                            oRsTool.Parameters.Add("taxCompanyTaxCode", taxCompanyTaxCode);

                        if (!oRsTool.Parameters.ContainsKey("taxOrganizationFeeCode"))
                            oRsTool.Parameters.Add("taxOrganizationFeeCode", taxOrganizationFeeCode);

                        if (!oRsTool.Parameters.ContainsKey("taxOrganizationManageFee"))
                            oRsTool.Parameters.Add("taxOrganizationManageFee", taxOrganizationManageFee);

                        if (!oRsTool.Parameters.ContainsKey("taxTaxPeriod"))
                            oRsTool.Parameters.Add("taxTaxPeriod", taxTaxPeriod);

                        if (!oRsTool.Parameters.ContainsKey("taxTreasuryManageFee"))
                            oRsTool.Parameters.Add("taxTreasuryManageFee", taxTreasuryManageFee);
                        string cashWithDraw = "0";

                        if (frmParam.IsCash == true)
                        {
                            IsCash = "7";
                        }
                        else
                        {
                            if (reportParameter.RefType == (int)RefType.BUPlanWithDrawCash ||
                                reportParameter.RefType == (int)RefType.CAReceiptEstimate)
                            {
                                IsCash = "4";
                            }
                            else { IsCash = "3"; }
                        }

                        if (!oRsTool.Parameters.ContainsKey("IsCash"))
                            oRsTool.Parameters.Add("IsCash", IsCash);
                        if (IsRealytoPay == 0)
                        {
                            if (reportParameter.RefType == (int)RefType.BUPlanWithDrawCash ||
                                reportParameter.RefType == (int)RefType.BUPlanWithDrawTransfer ||
                                reportParameter.RefType == (int)RefType.BUPlanReceiptAddition ||
                                reportParameter.RefType == (int)RefType.BUPlanReceiptEarlyYear ||
                                reportParameter.RefType == (int)RefType.BUPlanWithDrawDeposit ||
                                reportParameter.RefType == (int)RefType.BUPlanWithdrawTransferInsurrance
                                )
                            {
                                if (list.Any())
                                {
                                    var cashWithDrawType = list.FirstOrDefault().CashWithDrawType;
                                    cashWithDraw = cashWithDrawType.Equals(4) ? "4" : "1";
                                }
                            }
                            else
                            {
                                var obj = list.Select(r => r.Details).ToList();
                                foreach (var result1 in obj)
                                {
                                    foreach (var result in result1)
                                    {
                                        if (result.CashWithDrawType == 1 || result.CashWithDrawType == 2)
                                        {
                                            cashWithDraw = cashWithDraw + "1";
                                        }
                                        if (result.CashWithDrawType == 4)
                                        {
                                            cashWithDraw = cashWithDraw + "4";
                                        }
                                    }
                                }
                            }
                        }

                        if (!oRsTool.Parameters.ContainsKey("CashWithDrawStr"))
                            oRsTool.Parameters.Add("CashWithDrawStr", cashWithDraw);

                        string employee = null;
                        string accountingObj = null;

                        string accountingObjAddress = null;
                        string accountingObjBankAccount = null;
                        string accountingObjBankName = null;
                        if (reportParameter.RefType == (int)Enum.RefType.BUTransferDeposits)
                        {
                            accountingObj = GlobalVariable.CompanyName;
                            accountingObjAddress = GlobalVariable.CompanyAddress;
                            if (Model.GetBank(list.FirstOrDefault().EmployeeBankAccount) != null)
                            {
                                accountingObjBankAccount = Model.GetBank(list.FirstOrDefault().EmployeeBankAccount).BankAccount;
                            }
                            accountingObjBankName = list.FirstOrDefault().EmployeeBankName;
                        }
                        else
                        {
                            if (list.FirstOrDefault().IsEmployee == true)
                            {
                                employee = list.FirstOrDefault().Employee;
                            }
                            else
                            {
                                accountingObj = list.FirstOrDefault().AccountingObjectName;
                                accountingObjAddress = list.FirstOrDefault().Address;
                                accountingObjBankName = list.FirstOrDefault().BankName_Object;
                                accountingObjBankAccount = list.FirstOrDefault().BankAccount_Object;
                            }
                        }
                        if (!oRsTool.Parameters.ContainsKey("Employee"))
                            oRsTool.Parameters.Add("Employee", employee);
                        if (!oRsTool.Parameters.ContainsKey("AccountingObj"))
                            oRsTool.Parameters.Add("AccountingObj", accountingObj);
                        if (!oRsTool.Parameters.ContainsKey("AccountingObjAddress"))
                            oRsTool.Parameters.Add("AccountingObjAddress", accountingObjAddress);
                        if (!oRsTool.Parameters.ContainsKey("AccountingObjBankName"))
                            oRsTool.Parameters.Add("AccountingObjBankName", accountingObjBankName);
                        if (!oRsTool.Parameters.ContainsKey("AccountingObjBankAccount"))
                            oRsTool.Parameters.Add("AccountingObjBankAccount", accountingObjBankAccount);
                        string dateReport = string.Empty;
                        if (GlobalVariable.PrintSystemDate == 1)
                        {
                            dateReport = GlobalVariable.PostedDate;
                        }
                        else if (GlobalVariable.PrintSystemDate == 2)
                        {
                            dateReport = list.FirstOrDefault().PostedDate.ToShortDateString();
                        }
                        if (!oRsTool.Parameters.ContainsKey("dateReport"))
                            oRsTool.Parameters.Add("dateReport", dateReport);
                        //Xuất xml
                        if (!frmParam.IsPreviewOrExportXML)
                        {
                            if (list.Count > 0)
                            {
                                var result = list;
                                decimal totalAmount = 0;
                                using (var fbd = new FolderBrowserDialog())
                                {
                                    DialogResult results = DialogResult.Cancel;
                                    if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                                        results = fbd.ShowDialog();
                                    else
                                    { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                                    //if (result == null && !isParamater)
                                    //{
                                    //    result = Model.ReportBUPlanWithDraw(reportParameter.RefId, 0, 1, 1,
                                    //        (Enum.RefType)reportParameter.RefType).ToList();

                                    //    if (result.Count <= 0)
                                    //    {
                                    //        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                                    //            MessageBoxIcon.Information);
                                    //        return null;
                                    //    }
                                    //}
                                    if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                                    {
                                        GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                                            ? fbd.SelectedPath
                                            : GlobalVariable.PathXML;
                                        #region Dữ liệu xml


                                        string reportName = "C202b";
                                        string fileName = result[0].RefNo;
                                        string savepath = reportName + fileName + @".xml";
                                        Cursor.Current = Cursors.WaitCursor;
                                        XmlTextWriter writer = new XmlTextWriter(savepath,
                                            Encoding.UTF8);
                                        writer.Formatting = Formatting.Indented;
                                        writer.WriteStartDocument();

                                        writer.WriteStartElement("java");
                                        writer.WriteAttributeString("version", "1.7.0_17");
                                        writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                                        writer.WriteStartElement("object");
                                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");
                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "chuyenkhoanTienmat"); //Field name
                                        writer.WriteStartElement("string");
                                        writer.WriteString(IsCash.Equals("3") ? "0" : (IsCash.Equals("4") ? "2" : "3"));
                                        //writer.WriteString(IsCash.Equals("3") ? "0" : (IsCash.Equals("4") ? "1" : "2"));
                                        writer.WriteEndElement();
                                        writer.WriteEndElement(); //End void

                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("property", "dmDvqhns");
                                        writer.WriteStartElement("string");
                                        writer.WriteString(GlobalVariable.CompanyCode);
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();

                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("property", "dmTiente");
                                        writer.WriteStartElement("string");
                                        writer.WriteString("VND");
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNhantienDiachi"); //Field name
                                        if (accountingObjAddress != null)
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(accountingObjAddress);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNhantienKbnn"); //Field name
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNhantienKbnnTen"); //Field name
                                        if (!string.IsNullOrEmpty(result[0].BankName))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(result[0].BankName);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNhantienLoai"); //Field name
                                        if (!IsCash.Equals("3"))
                                        {
                                            writer.WriteStartElement("long");
                                            writer.WriteValue(IsCash.Equals("4") ? 0 : 1);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNhantienMa"); //Field name
                                        if (!string.IsNullOrEmpty(list[0].EmployeeCode))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(list[0].EmployeeCode);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void
                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNhantienSotiennhan"); //Field name
                                        writer.WriteStartElement("double"); //Start string
                                        writer.WriteValue((double)result[0].Details.Sum(x => x.Amount)); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNhantienSotkSo"); //Field name
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNhantienTen"); //Field name
                                        if (!string.IsNullOrEmpty(accountingObj))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(accountingObj);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNopthueChuong"); //Field name
                                        if (!string.IsNullOrEmpty(frmParam.taxBudgetChapterCode))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(frmParam.taxBudgetChapterCode);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNopthueCqthuMa"); //Field name     
                                        if (!string.IsNullOrEmpty(frmParam.taxOrganizationFeeCode))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(frmParam.taxOrganizationFeeCode);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNopthueCqthuTen"); //Field name
                                        if (!string.IsNullOrEmpty(frmParam.taxOrganizationManageFee))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(frmParam.taxOrganizationManageFee);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNopthueKbHachtoan"); //Field name
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNopthueKbHachtoanTen"); //Field name
                                        if (!string.IsNullOrEmpty(frmParam.taxTreasuryManageFee))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(frmParam.taxTreasuryManageFee);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNopthueKythue"); //Field name
                                        if (!string.IsNullOrEmpty(frmParam.taxTaxPeriod))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(frmParam.taxTaxPeriod);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNopthueMasothue"); //Field name
                                        if (!string.IsNullOrEmpty(frmParam.CompanyTaxCode))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(frmParam.CompanyTaxCode);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNopthueNdkt"); //Field name
                                        if (!string.IsNullOrEmpty(frmParam.taxBudgetSubItemCose))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(frmParam.taxBudgetSubItemCose);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNopthueSotiennop"); //Field name
                                        writer.WriteStartElement("double"); //Start string
                                        writer.WriteValue(0); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvNopthueTen"); //Field name
                                        if (!string.IsNullOrEmpty(frmParam.taxAccountingObjectName))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(frmParam.taxAccountingObjectName);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field (Chưa lấy dc)
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvqhnsCapns"); //Field name
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(" "); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvqhnsCkcHdk"); //Field name
                                        if (!string.IsNullOrEmpty(CKC_HDK))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(CKC_HDK);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvqhnsCkcHdth"); //Field name
                                        if (!string.IsNullOrEmpty(HDTH))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(HDTH);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvqhnsCtmt"); //Field name
                                        if (!string.IsNullOrEmpty(_projectCode))
                                        {
                                            writer.WriteStartElement("string");
                                            writer.WriteString(_projectCode);
                                            writer.WriteEndElement();
                                        }
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dvqhnsKbnn"); //Field name
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("property", "dvqhnsMa");
                                        writer.WriteStartElement("string");
                                        writer.WriteString(GlobalVariable.CompanyCode);
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();

                                        //New field
                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("property", "dvqhnsNamns");
                                        writer.WriteStartElement("long");
                                        writer.WriteValue(result[0].PostedDate.Year);
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();

                                        //New field
                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("property", "dvqhnsTen");
                                        writer.WriteStartElement("string");
                                        writer.WriteString(GlobalVariable.CompanyName);
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();

                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("property", "gnHosoC202GtByGnHosoC202");

                                        writer.WriteStartElement("object");
                                        writer.WriteAttributeString("class", "java.util.ArrayList");
                                        //Detail
                                        //var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                                        var count = result[0].Details.Count;

                                        for (int i = 0; i < count; i++)
                                        {
                                            writer.WriteStartElement("void");
                                            writer.WriteAttributeString("method", "add");
                                            writer.WriteStartElement("object");
                                            writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                                            //New field
                                            writer.WriteStartElement("void"); //Start void
                                            writer.WriteAttributeString("property", "dmChuong"); //Field name
                                            writer.WriteStartElement("string"); //Start string
                                            writer.WriteString(result[0].Details[i].BudgetChapterCode); //Values
                                            writer.WriteEndElement(); //End string
                                            writer.WriteEndElement(); //End void

                                            //New field
                                            writer.WriteStartElement("void"); //Start void
                                            writer.WriteAttributeString("property", "dmNdkt"); //Field name
                                            writer.WriteStartElement("string"); //Start string
                                            writer.WriteString(result[0].Details[i].BudgetSubItemCode); //Values
                                            writer.WriteEndElement(); //End string
                                            writer.WriteEndElement(); //End void

                                            //New field
                                            writer.WriteStartElement("void"); //Start void
                                            writer.WriteAttributeString("property", "dmNganhKt"); //Field name
                                            writer.WriteStartElement("string"); //Start string
                                            writer.WriteString(result[0].Details[i].BudgetSubKindItemCode); //Values
                                            writer.WriteEndElement(); //End string
                                            writer.WriteEndElement(); //End void

                                            //New field
                                            writer.WriteStartElement("void"); //Start void
                                            writer.WriteAttributeString("property", "dmNguonchi"); //Field name
                                            writer.WriteStartElement("string"); //Start string
                                            writer.WriteString(result[0].Details[i].BudgetSourceCode); //Values
                                            writer.WriteEndElement(); //End string
                                            writer.WriteEndElement(); //End void

                                            //New field
                                            writer.WriteStartElement("void"); //Start void
                                            writer.WriteAttributeString("property", "dvNhantien"); //Field name
                                            writer.WriteStartElement("double"); //Start string
                                            writer.WriteValue(result[0].Details[i].AmountNet); //Values
                                            writer.WriteEndElement(); //End string
                                            writer.WriteEndElement(); //End void
                                            //New field
                                            writer.WriteStartElement("void"); //Start void
                                            writer.WriteAttributeString("property", "dvNopthue"); //Field name
                                            writer.WriteStartElement("double"); //Start string
                                            writer.WriteValue((double)result[0].Details[i].AmountTax); //Values
                                            writer.WriteEndElement(); //End string
                                            writer.WriteEndElement(); //End void

                                            //New field
                                            writer.WriteStartElement("void"); //Start void
                                            writer.WriteAttributeString("property", "maHang"); //Field name
                                            writer.WriteStartElement("string"); //Start string
                                            writer.WriteString((i + 1).ToString()); //Values
                                            writer.WriteEndElement(); //End string
                                            writer.WriteEndElement(); //End void

                                            //New field
                                            writer.WriteStartElement("void"); //Start void
                                            writer.WriteAttributeString("property", "noiDung"); //Field name
                                            writer.WriteStartElement("string"); //Start string
                                            writer.WriteString(result[0].JournalMemo); //Values
                                            writer.WriteEndElement(); //End string
                                            writer.WriteEndElement(); //End void

                                            //New field
                                            writer.WriteStartElement("void"); //Start void
                                            writer.WriteAttributeString("property", "soTien"); //Field name
                                            writer.WriteStartElement("double"); //Start string
                                            writer.WriteValue(result[0].Details[i].Amount); //Values
                                            writer.WriteEndElement(); //End string
                                            writer.WriteEndElement(); //End void

                                            //End add
                                            writer.WriteEndElement();
                                            writer.WriteEndElement();
                                        }
                                        //End add
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();

                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                                        writer.WriteStartElement("long"); //Start string
                                        writer.WriteValue((long)500); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("property", "ngayChungTu");
                                        writer.WriteStartElement("object");
                                        writer.WriteAttributeString("class", "java.sql.Timestamp");
                                        writer.WriteStartElement("long");
                                        writer.WriteValue((long)(result[0].PostedDate
                                            .ToUniversalTime()
                                            .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();
                                        writer.WriteEndElement(); // ngayChungtu

                                        //New field
                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("property", "par1");
                                        writer.WriteStartElement("string");
                                        writer.WriteString(RSSHelper.NumberToWord.Read(result[0].Details.Sum(x => x.Amount), "đồng", "", "#.0000"));
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();

                                        //New field
                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("property", "par2");
                                        writer.WriteEndElement();

                                        //New field
                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("property", "par3");
                                        writer.WriteStartElement("string");
                                        writer.WriteString(RSSHelper.NumberToWord.Read(result[0].Details.Sum(x => x.Amount), "đồng", "", "#.0000"));
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "soChungTu"); //Field name
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(result[0].RefNo); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "thucchiTamung"); //Field name
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(IsRealytoPay.Equals(2) ? "2" : IsRealytoPay.Equals(1) ? "3" : IsRealytoPay.Equals(0) ? (cashWithDraw.Equals("0") || cashWithDraw.Equals("1")) ? "1" : "0" : "");
                                        //writer.WriteString(result[0].CashWithDrawType.Equals(6) ? "0" : "1"); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "tongSoTien"); //Field name
                                        writer.WriteStartElement("double"); //Start string
                                        writer.WriteValue((double)list[0].Details.Sum(x => x.Amount)); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "typeChungTu"); //Field name
                                        writer.WriteStartElement("long"); //Start string
                                        writer.WriteValue(1); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                                        writer.WriteEndElement(); //java

                                        writer.WriteEndDocument();
                                        writer.Close();
                                        if (exportXml.CreateZip(fileName, fbd.SelectedPath, reportName))
                                            XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                                        else
                                            XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                                        //result = null;

                                        #endregion
                                    }
                                }
                            }
                            //exportXml.ReportBUPlanWithDraw_C2_02BXML(reportParameter, list.ToList());

                            if (list.Count <= 0)
                            {
                                XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                return null;
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
            return list;
        }


        #endregion

        #region Phiếu kế toán

        public IList<VoucherModel> GetVoucherData(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<VoucherModel> reports = Model.GetVoucherData(reportParameter.RefId, reportParameter.RefType);
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var result = new List<VoucherModel>();
            var groupBy = reports.GroupBy(r => r.RefId);
            string debitlist = string.Empty;
            string creditlist = string.Empty;
            for (int i = 0; i < reports.Count(); i++)
            {
                if (debitlist.Contains(reports[i].DebitAccount.ToString()) == false)
                {
                    debitlist = debitlist + reports[i].DebitAccount + ",";
                }
            }
            for (int i = 0; i < reports.Count(); i++)
            {
                if (creditlist.Contains(reports[i].CreditAccount.ToString()) == false)
                {
                    creditlist = creditlist + reports[i].CreditAccount + ",";
                }
            }

            string dateReport = string.Empty;
            if (GlobalVariable.PrintSystemDate == 1)
            {
                dateReport = GlobalVariable.PostedDate;
            }
            else if (GlobalVariable.PrintSystemDate == 2)
            {
                dateReport = reports.FirstOrDefault().PostedDate.ToShortDateString();
            }
            if (!oRsTool.Parameters.ContainsKey("dateReport"))
                oRsTool.Parameters.Add("dateReport", dateReport);
            return reports;
        }

        #endregion

        #region C2-12/NS: Giấy đề nghị cam kết chi NSNN (Thông tư số 77/2017/TT-BTC)

        /// <summary>
        /// Reports the C212 ns.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>System.Collections.Generic.IList&lt;Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher.C212NSModel&gt;.</returns>
        public IList<C212NSModel> GetC212NS(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<C212NSModel> list = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            try
            {
                string bankOpen = "";
                string refID = "," + reportParameter.RefId + ",";
                list = Model.GetC212NS(refID);
                var bUCommitmentRequest = Model.GetProjectBank(list.FirstOrDefault().ProId);
                //var pro = Model.GetProject(list.FirstOrDefault().ProId);
                //BankModel bank = null;

                //    bank = Model.GetBank(list.FirstOrDefault().ProId);

                //foreach (var item in list)
                //{

                //    item.BankOpen = bank != null ? bank.BankName : "";
                //}
                string dateReport = string.Empty;
                if (GlobalVariable.PrintSystemDate == 1)
                {
                    dateReport = GlobalVariable.PostedDate;
                }
                else if (GlobalVariable.PrintSystemDate == 2)
                {
                    dateReport = list.FirstOrDefault().PostedDate.ToShortDateString();
                }
                if (!oRsTool.Parameters.ContainsKey("dateReport"))
                    oRsTool.Parameters.Add("dateReport", dateReport);
                if (!oRsTool.Parameters.ContainsKey("CompanyCode"))
                    oRsTool.Parameters.Add("CompanyCode", GlobalVariable.CompanyCode);
                //foreach (var ls in list)
                //{
                //    if (!string.IsNullOrEmpty(ls.BankOpen))
                //    {
                //        bankOpen = ls.BankOpen;
                //        break;
                //    }

                //}

                if (!oRsTool.Parameters.ContainsKey("BankOpen"))
                    oRsTool.Parameters.Add("BankOpen", bUCommitmentRequest != null && bUCommitmentRequest.Count > 0 ? bUCommitmentRequest.FirstOrDefault().BankName : "");


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
            return list;
        }

        #endregion

        #region C2-13/NS: Phiếu điều chỉnh số liệu cam kết chi (TT số 77/2017/TT-BTC)

        /// <summary>
        /// Gets the C213 ns.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList&lt;C213NSModel&gt;.</returns>
        public IList<C213NSModel> GetC213NS(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<C213NSModel> list = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            try
            {
                string bankOpen = "";
                string refID = "," + reportParameter.RefId + ",";
                list = Model.GetC213NS(refID);
                string dateReport = string.Empty;
                if (GlobalVariable.PrintSystemDate == 1)
                {
                    dateReport = GlobalVariable.PostedDate;
                }
                else if (GlobalVariable.PrintSystemDate == 2)
                {
                    dateReport = list.FirstOrDefault().PostedDate.ToShortDateString();
                }

                foreach (var ls in list)
                {
                    if (!string.IsNullOrEmpty(ls.BankOpen))
                    {
                        bankOpen = ls.BankOpen;
                    }

                }
                if (!oRsTool.Parameters.ContainsKey("dateReport"))
                    oRsTool.Parameters.Add("dateReport", dateReport);
                if (!oRsTool.Parameters.ContainsKey("BankOpen"))
                    oRsTool.Parameters.Add("BankOpen", bankOpen);

                if (!oRsTool.Parameters.ContainsKey("CompanyNameTag"))
                    oRsTool.Parameters.Add("CompanyNameTag", GlobalVariable.CompanyName);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                return null;
            }
            return list;
        }

        #endregion

        #region

        ///// <summary>
        ///// Gets the report C22 h.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<C22HModel> GetReportC22H(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    if (commonVariable.RefIdList == null)
        //    {
        //        commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
        //    }

        //    IList<C22HModel> list = Model.GetC22H(commonVariable.ReportList.ProcedureName, commonVariable.RefIdList) ;
        //    foreach (var c22HModel in list)
        //    {
        //        if (c22HModel.AccountingObjectAddress==null)
        //        {
        //            c22HModel.AccountingObjectAddress = "";
        //        }
        //        if (c22HModel.AccountingObjectName == null)
        //        {
        //            c22HModel.AccountingObjectName = "";
        //        }
        //        if (c22HModel.DocumentInclude == null)
        //        {
        //            c22HModel.DocumentInclude = "";
        //        }
        //    }

        //    return list;
        //}

        ///// <summary>
        ///// Gets the report C30 bb.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<C30BBModel> GetReportC30BB(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    if (commonVariable.RefIdList == null)
        //    {
        //        commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
        //    }
        //    string[] lstId = commonVariable.RefIdList.Split(';');
        //    IList<C30BBModel> list = Model.GetC30BBWithStoreProdure(DateTime.Parse(commonVariable.PostedDate).Year, commonVariable.ReportList.RefRypeVoucherID);
        //    IList<C30BBModel> listTemp = new List<C30BBModel>();
        //    foreach (var it in list)
        //    {
        //        if (lstId.Any())
        //        {
        //            for (int i = 0; i < lstId.Count();i++ )
        //            {
        //                if (int.Parse(lstId[i])==it.RefId)
        //                {
        //                    listTemp.Add(it);
        //                }
        //            }
        //        }

        //    }
        //    return listTemp;
        //}

        ///// <summary>
        ///// Gets the report C30 BB501 models.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<C30BB501Model> GetReportC30Bb501Models(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    if (commonVariable.RefIdList == null)
        //    {
        //        commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
        //    }

        //    IList<C30BB501Model> list = Model.GetC30BB501(commonVariable.ReportList.ProcedureName, commonVariable.RefIdList);
        //    foreach (var c30BB501Model in list)
        //    {
        //        if (c30BB501Model.Trader == null)
        //        {
        //            c30BB501Model.Trader = "";
        //        }
        //        if (c30BB501Model.DocumentInclude == null)
        //        {
        //            c30BB501Model.DocumentInclude = "";
        //        }
        //    }

        //    return list;
        //}
        ///// <summary>
        ///// Gets the report C30 bb.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<C30BBModel> GetReportC30BBItem(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    if (commonVariable.RefIdList == null)
        //    {
        //        commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
        //    }
        //    string[] lstId = commonVariable.RefIdList.Split(';');
        //    IList<C30BBModel> list = Model.GetC30BBItemWithStoreProdure(DateTime.Parse(commonVariable.PostedDate).Year, commonVariable.ReportList.RefRypeVoucherID);
        //    IList<C30BBModel> listTemp = new List<C30BBModel>();
        //    foreach (var it in list)
        //    {
        //        if (lstId.Any())
        //        {
        //            for (int i = 0; i < lstId.Count(); i++)
        //            {
        //                if (int.Parse(lstId[i]) == it.RefId)
        //                {
        //                    listTemp.Add(it);
        //                }
        //            }
        //        }

        //    }
        //    return listTemp;
        //}

        ///// <summary>
        ///// Gets the report C11 h.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<C11HModel> GetReportC11H(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool) 
        //{
        //    if (commonVariable.RefIdList ==null)
        //    {
        //        commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
        //    }
        //    IList<C11HModel> list = Model.GetC11H(commonVariable.ReportList.ProcedureName, commonVariable.RefIdList);
        //    return list;
        //}

        /// <summary>
        /// Chứng từ kế toán.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<AccountingVoucherModel> GetReportAccountingVoucher(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            //if (commonVariable.RefIdList == null)
            //{
            //    commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
            //}
            IList<AccountingVoucherModel> results = Model.ReportAccountingVoucher(reportParameter.RefId, reportParameter.RefType);

            // DUNGTD truyền parmater bổ sung liên 1 khi chọn phiếu thu và phiếu chi
            //int CheckC30 = GlobalVariable.IsCheckC30BC31B;
            //if (!oRsTool.Parameters.ContainsKey("CheckC30"))
            //{
            //    oRsTool.Parameters.Add("CheckC30", CheckC30);
            //}

            if (results.Count > 0)
            {
                string todate = results[0].PostedDate.ToString();
                if (!oRsTool.Parameters.ContainsKey("ToDate"))
                    oRsTool.Parameters.Add("ToDate", todate);

                string budgetSourceCode = results[0].BudgetSourceCode;
                string currencyCode = results[0].CurrencyCode;

                var count = results.Count;
                for (int i = 0; i < count; i++)
                {
                    if (results[i].CurrencyCode == null)
                        results[i].CurrencyCode = "";
                }

                if (!oRsTool.Parameters.ContainsKey("BudgetSourceCode"))
                    oRsTool.Parameters.Add("BudgetSourceCode", budgetSourceCode);
                if (!oRsTool.Parameters.ContainsKey("pCurrencyCode"))
                    oRsTool.Parameters.Add("pCurrencyCode", currencyCode);

                if (!oRsTool.Parameters.ContainsKey("CompanyReport"))
                    oRsTool.Parameters.Add("CompanyReport", GlobalVariable.CompanyName);
                if (!oRsTool.Parameters.ContainsKey("CompanyCodeReport"))
                    oRsTool.Parameters.Add("CompanyCodeReport", GlobalVariable.CompanyCode);

            }
            return results;
        }

        #endregion

        #region Chứng từ ghi sổ

        /// <summary>
        /// Chứng từ
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<GLVoucherListDetailModel> ReportGlVoucherListDetail(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<GLVoucherListDetailModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {

                using (var frmParam = new FrmGLVoucherListDetailParamaterReport())
                {
                    string RefIdTemp = ',' + reportParameter.RefId + ',';
                    frmParam.Text = @"Chứng từ ghi sổ";
                    string isShowRefNo = "";
                    isShowRefNo = frmParam.isShowRefNo == true ? "1" : "0";
                    string isShowSingleAccount = frmParam.isNotShowSingleAccount == false ? "1" : "0";
                    //reports = Model.ReportGlVoucherListDetail(RefIdTemp, frmParam.isGroupSameRow,
                    //    frmParam.isShowOriginalCurrency);

                    reports = Model.ReportGlVoucherListDetail(RefIdTemp, true,
                        true);
                    //var glVoucherList = Model.GetGLVoucherListByRefId(reportParameter.RefId);
                    //if (!oRsTool.Parameters.ContainsKey("ParamDate"))
                    //    oRsTool.Parameters.Add("ParamDate", glVoucherList.RefDate.ToShortDateString());
                    //if (!oRsTool.Parameters.ContainsKey("ParamRefNo"))
                    //    oRsTool.Parameters.Add("ParamRefNo", glVoucherList.RefNo);
                    if (!oRsTool.Parameters.ContainsKey("ShowRefNo"))
                        oRsTool.Parameters.Add("ShowRefNo", "1");
                    if (!oRsTool.Parameters.ContainsKey("ShowSingleAccount"))
                        oRsTool.Parameters.Add("ShowSingleAccount", "1");

                    //if (!oRsTool.Parameters.ContainsKey("CompanyChiefAccountant"))
                    //    oRsTool.Parameters.Add("CompanyChiefAccountant", GlobalVariable.CompanyChiefAccountant);
                    //if (!oRsTool.Parameters.ContainsKey("CompanyReportPreparer"))
                    //    oRsTool.Parameters.Add("CompanyReportPreparer", GlobalVariable.CompanyReportPreparer);

                    //}
                }
            }
            return reports;
        }


        /// <summary>
        /// Báo cáo
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<GLVoucherListDetailModel> ReportGlVoucherListDetailBC(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<GLVoucherListDetailModel> reports = null;

            if (!oRsTool.IsRefresh)
            {

                using (var frmParam = new FrmS02aH())
                {
                    frmParam.Text = @"Chứng từ ghi sổ";

                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        //string isShowRefNo = "";
                        //isShowRefNo = frmParam.isShowRefNo == true ? "1" : "0";
                        //string isShowSingleAccount = frmParam.isNotShowSingleAccount == false ? "1" : "0";

                        //reports = Model.ReportGlVoucherListDetail(reportParameter.RefId, frmParam.isGroupSameRow,
                        //    frmParam.isShowOriginalCurrency);

                        reports = Model.ReportGlVoucherListDetail(frmParam.ListRefId, frmParam.isGroupSameRow,
                            frmParam.isShowOriginalCurrency);

                        if (GlobalVariable.AmountTypeViewReport == 2 && reports != null && reports.Count > 0)
                        {
                            reports = reports.Where(o => o.CurrencyCode == GlobalVariable.CurrencyViewReport).ToList();
                        }
                        else if (GlobalVariable.AmountTypeViewReport == 1)
                        {
                            foreach (var item in reports)
                            {
                                if (item.CurrencyCode != GlobalVariable.MainCurrencyId)
                                {
                                    item.Amount = item.Amount * item.ExchangeRate;
                                }
                            }
                        }
                        //var glVoucherList = Model.GetGLVoucherListByRefId(frmParam.ListRefId);
                        //if (!oRsTool.Parameters.ContainsKey("ParamDate"))
                        //    oRsTool.Parameters.Add("ParamDate", glVoucherList.RefDate.ToShortDateString());
                        //if (!oRsTool.Parameters.ContainsKey("ParamRefNo"))
                        //    oRsTool.Parameters.Add("ParamRefNo", frmParam.ListRefNo);
                        if (!oRsTool.Parameters.ContainsKey("ShowRefNo"))
                            oRsTool.Parameters.Add("ShowRefNo", 1);
                        if (!oRsTool.Parameters.ContainsKey("ShowSingleAccount"))
                            oRsTool.Parameters.Add("ShowSingleAccount", 1);
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", frmParam.ToDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                    }
                }
            }
            return reports;
        }


        public IList<GLVoucherListModel> ReportGlVoucherList(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<GLVoucherListModel> reports = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmGLVoucherListParamaterReport())
                {
                    frmParam.Text = @"Chứng từ ghi sổ";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        //reports = Model.ReportGlVoucherList(frmParam.fromDate, frmParam.toDate, frmParam.isNotShowSignAccount);
                        reports = Model.ReportGlVoucherList(frmParam.fromDate, frmParam.toDate, false, GlobalVariable.AmountTypeViewReport, GlobalVariable.CurrencyViewReport);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", frmParam.fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", frmParam.toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// Reports the gl voucher list ledger.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<GLVoucherListLedgerModel> ReportGlVoucherListLedger(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<GLVoucherListLedgerModel> reports = null;
            if (!oRsTool.IsRefresh)
            {

                using (var frmParam = new FrmGLVoucherListLedger())
                {
                    frmParam.Text = @"Sổ cái - hình thức kế toán chứng từ ghi sổ";

                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        reports = Model.ReportGLVoucherListLedger(frmParam.FromDate, frmParam.ToDate,
                            frmParam.ListBudgetSourceId, frmParam.BudgetChapterCode, frmParam.BudgetSubKindItemCode,
                            frmParam.IsSummaryBudgetSource, frmParam.IsSummaryBudgetChapter,
                            frmParam.IsSummaryBudgetSubKindItem, frmParam.Account);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", frmParam.FromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", frmParam.ToDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", GlobalVariable.CompanyProvince);
                        if (reports.Count <= 0)
                        {
                            XtraMessageBox.Show("Dữ liệu lấy lên không có bản ghi nào", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return reports;

                        }

                    }
                }
            }
            return reports;

        }

        #endregion

        #region GetDataSet()

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <param name="storeProcedure">The store procedure.</param>
        /// <param name="parms">The parms.</param>
        /// <returns></returns>
        public DataSet GetDataSet(string storeProcedure, object[] parms)
        {
            return Model.GetDataSet(storeProcedure, parms);
        }


        #endregion

        #region Giấy nộp trả vốn đầu tư

        public IList<C304NSModel> GetReportC304NS(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var result = Model.ReportC304NS(reportParameter.RefId).ToList();
            return null;
        }

        #endregion

        #region Giấy rút tiền mặt
        public IList<C409KBModel> GetReportC409KB(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            oRsTool.HideLicenseText = true;
            //if (commonVariable.RefIdList == null)
            //{
            //    commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
            //}
            IList<C409KBModel> list = Model.GetReportC409KB(reportParameter.RefId, false);

            if (list == null)
            {
                return new List<C409KBModel>();
            }
            if (list != null)
            {
                var count = list.Count;
                for (int i = 0; i < count; i++)
                {
                    if (list[i].RefNo == null)
                    {
                        list.Remove(list[i]);
                    }
                    list[i].Details =
                        Model.GetReportC409KBDetail(reportParameter.RefId, true)
                            .ToList();
                    if (list[i].Details.Count == 0)
                    {
                        list.Remove(list[i]);
                    }
                }
            }
            if (!oRsTool.Parameters.ContainsKey("BudgetRalationship"))
                oRsTool.Parameters.Add("BudgetRalationship", "");//GlobalVariable.BudgetRalationship);
            if (!oRsTool.Parameters.ContainsKey("TargetProgramCode"))
                oRsTool.Parameters.Add("TargetProgramCode", GlobalVariable.TargetProgramIDTargetProgamForm);
            //if (!oRsTool.Parameters.ContainsKey("CompanyAddress"))
            //    oRsTool.Parameters.Add("CompanyAddress", GlobalVariable.CompanyAddress);
            if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
            //if (!oRsTool.Parameters.ContainsKey("CompanyName"))
            //    oRsTool.Parameters.Add("CompanyName", GlobalVariable.CompanyName);

            return list;
        }
        #endregion

        /// <summary>
        /// Báo cáo C205a
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<C402CKBModel> GetReportC205A(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var storeProcedure = reportParameter.RefType.Equals(157) ? "uspReport_BAV_Withdraw_C205" : "usp_BAV_InvestmentFundPayment_C2_05_NS_TT77";
            IList<C402CKBModel> reports = Model.ReportC205ANS(storeProcedure, reportParameter.RefId);
            var taxPayers = "";
            decimal totalAmount = reports == null ? 0 : reports.Sum(x => x.Amount);
            var ctmtDa = "";
            var ckcHdk = "";
            var codeCtmtDa = "";
            var txtDecisionNo = "";
            string txtDecisionDate = "";
            var ckcHdth = "";
            decimal totalPayment = 0;
            decimal totalTax = 0;
            using (var frmParam = new FrmC205ANS_Params(reportParameter.RefId, storeProcedure))
            {
                frmParam.ShowDialog();
                if (frmParam.DialogResult == DialogResult.OK)
                {
                    totalAmount = reports.Sum(x => x.Amount);
                    taxPayers = frmParam.TaxPayers;
                    ctmtDa = frmParam.CtmtDa;
                    txtDecisionNo = frmParam.DecisionNo;
                    if (frmParam.DecisionDate != null && frmParam.DecisionDate != DateTime.MinValue)
                    {
                        txtDecisionDate = frmParam.DecisionDate?.ToString("dd/MM/yyyy");
                    }

                    ckcHdk = frmParam.CkcHdk;
                    codeCtmtDa = frmParam.CodeCtmtDa;
                    ckcHdth = frmParam.CkcHdth;
                    totalPayment = reports.Sum(x => x.Payment);
                    totalTax = reports.Sum(x => x.Tax);
                }
                if (frmParam.DialogResult == DialogResult.Cancel)
                {
                    return null;
                }
                //Xuất XML
                if (!frmParam.IsPreviewOrExportXML)
                {
                    if (reports.Count > 0)
                    {

                        exportXml.ReportC402AKBXML(reportParameter, oRsTool, reports.ToList());
                    }

                    if (reports.Count <= 0)
                    {
                        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return null;
                    }
                    return null;
                }
            }
            if (!oRsTool.Parameters.ContainsKey("DecisionDate"))
                oRsTool.Parameters.Add("DecisionDate", txtDecisionDate);
            if (!oRsTool.Parameters.ContainsKey("DecisionNo"))
                oRsTool.Parameters.Add("DecisionNo", txtDecisionNo);
            if (!oRsTool.Parameters.ContainsKey("TaxPayers"))
                oRsTool.Parameters.Add("TaxPayers", taxPayers);
            if (!oRsTool.Parameters.ContainsKey("ProjectName"))
                oRsTool.Parameters.Add("ProjectName", reports[0].ProjectName);
            if (!oRsTool.Parameters.ContainsKey("Investment"))
                oRsTool.Parameters.Add("Investment", reports[0].Investment);
            if (!oRsTool.Parameters.ContainsKey("ProjectBankName"))
                oRsTool.Parameters.Add("ProjectBankName", reports[0].ProjectBankName);
            if (!oRsTool.Parameters.ContainsKey("ProjectBankAccount"))
                oRsTool.Parameters.Add("ProjectBankAccount", reports[0].ProjectBankAccount);
            if (!oRsTool.Parameters.ContainsKey("TotalAmount"))
                oRsTool.Parameters.Add("TotalAmount", totalAmount);
            oRsTool.Parameters.Add("PaymentObjectName", GlobalVariable.IsValidLicense ? GlobalVariable.CompanyName : "");
            oRsTool.Parameters.Add("CompanyAddress", GlobalVariable.IsValidLicense ? GlobalVariable.CompanyAddress : "");
            if (!oRsTool.Parameters.ContainsKey("CtmtDa"))
                oRsTool.Parameters.Add("CtmtDa", ctmtDa);
            if (reportParameter.RefType.Equals(106))
            {
                if (!oRsTool.Parameters.ContainsKey("CashOrTransfer"))
                    oRsTool.Parameters.Add("CashOrTransfer", "1");

            }
            else
            {
                if (!oRsTool.Parameters.ContainsKey("CashOrTransfer"))
                    oRsTool.Parameters.Add("CashOrTransfer", "2");
            }
            if (!oRsTool.Parameters.ContainsKey("CkcHdk"))
                oRsTool.Parameters.Add("CkcHdk", ckcHdk);

            if (!oRsTool.Parameters.ContainsKey("CodeCtmtDa"))
                oRsTool.Parameters.Add("CodeCtmtDa", codeCtmtDa);

            if (!oRsTool.Parameters.ContainsKey("CkcHdth"))
                oRsTool.Parameters.Add("CkcHdth", ckcHdth);

            if (!oRsTool.Parameters.ContainsKey("TotalPayment"))
                oRsTool.Parameters.Add("TotalPayment", totalPayment);

            if (!oRsTool.Parameters.ContainsKey("TotalTax"))
                oRsTool.Parameters.Add("TotalTax", totalTax);
            return reports;
        }
        /// <summary>
        /// Báo cáo C206NS
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<C206NSModel> GetReportC206NS(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var frmParam = new FrmC206NS();
            var result = new List<C206NSModel>();
            if (frmParam.ShowDialog() == DialogResult.OK)
            {
                result = Model.ReportC206NS(reportParameter.RefId).ToList();
                int IsRealytoPay = 0;
                if (frmParam.RealytoPay != 0)
                {
                    IsRealytoPay = frmParam.RealytoPay;
                }
                string cashWithDraw = "0";
                if (IsRealytoPay == 0)
                {
                    if
                    (
                        reportParameter.RefType == (int)RefType.BUPlanWithDrawCash ||
                        reportParameter.RefType == (int)RefType.BUPlanWithDrawTransfer ||
                        reportParameter.RefType == (int)RefType.BUPlanReceiptAddition ||
                        reportParameter.RefType == (int)RefType.BUPlanReceiptEarlyYear ||
                        reportParameter.RefType == (int)RefType.BUPlanWithDrawDeposit ||
                        reportParameter.RefType == (int)RefType.BUPlanWithdrawTransferInsurrance
                        )
                    {
                        if (result.Any())
                        {
                            var cashWithDrawType = result.FirstOrDefault().CashWithDrawType;
                            cashWithDraw = cashWithDrawType.Equals(4) ? "4" : "1";
                        }
                    }
                    else
                    {
                        if (result[0].CashWithDrawType == 1 || result[0].CashWithDrawType == 2)
                        {
                            cashWithDraw = cashWithDraw + "1";
                        }
                        if (result[0].CashWithDrawType == 4)
                        {
                            cashWithDraw = cashWithDraw + "4";
                        }
                    }
                }
                //Xuất XML
                if (!frmParam.IsPreviewOrExportXML)
                {
                    if (result.Count > 0)
                    {
                        decimal totalAmount = 0;
                        try
                        {
                            //if (result == null && !isParamater)
                            //{
                            //    result = Model.ReportC206NS(reportParameter.RefId).ToList();
                            //    if (result.Count <= 0)
                            //    {
                            //        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                            //            MessageBoxIcon.Information);
                            //        return null;
                            //    }
                            //}
                            using (var fbd = new FolderBrowserDialog())
                            {
                                DialogResult results = DialogResult.Cancel;
                                if (string.IsNullOrEmpty(GlobalVariable.PathXML))
                                    results = fbd.ShowDialog();
                                else
                                { fbd.SelectedPath = GlobalVariable.PathXML; results = DialogResult.OK; }
                                if (results == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                                {
                                    GlobalVariable.PathXML = string.IsNullOrEmpty(GlobalVariable.PathXML)
                                        ? fbd.SelectedPath
                                        : GlobalVariable.PathXML;
                                    #region Dữ liệu xml


                                    string reportName = "C206";
                                    string fileName = result[0].RefNo;
                                    string savepath = reportName + fileName + @".xml";
                                    Cursor.Current = Cursors.WaitCursor;
                                    XmlTextWriter writer = new XmlTextWriter(savepath,
                                        Encoding.UTF8);
                                    writer.Formatting = Formatting.Indented;
                                    writer.WriteStartDocument();

                                    writer.WriteStartElement("java");
                                    writer.WriteAttributeString("version", "1.7.0_17");
                                    writer.WriteAttributeString("class", "java.beans.XMLDecoder");

                                    writer.WriteStartElement("object");
                                    writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTu");

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "bkNganHang"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "bkNganHangTrungGianTen"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "bkNhSwiftCode"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "bkNhTgSwiftCode"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "bkSoTaiKhoan"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].AccountingObjectBankAccount); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "bkTaiNganHang"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].AccountingObjectBankName); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "bkTenTaiKhoan"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dmDvqhns"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(GlobalVariable.CompanyCode); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dmTiente"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].CurrencyCode); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dvqhnsCapns"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dvqhnsCkcHdk"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dvqhnsCkcHdth"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dvqhnsCtmt"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].TargetProgramCode); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dvqhnsKbnn"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dvqhnsMa"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(GlobalVariable.CompanyCode); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dvqhnsNamns"); //Field name
                                    writer.WriteStartElement("long"); //Start string
                                    writer.WriteValue(result[0].PostedDate.Year); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dvqhnsNoidung"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].JournalMemo); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dvqhnsSotk"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].BankAccount); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dvqhnsSotkSo"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].BankAccount); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dvqhnsTen"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(GlobalVariable.CompanyName); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "gnHosoC206GtByGnHosoC206");

                                    writer.WriteStartElement("object");
                                    writer.WriteAttributeString("class", "java.util.ArrayList");

                                    ////Detail
                                    //var detaillist = Model.GetReceiptVoucher(list[0].RefId, true, true);
                                    var count = result.Count;

                                    for (int i = 0; i < count; i++)
                                    {
                                        writer.WriteStartElement("void");
                                        writer.WriteAttributeString("method", "add");
                                        writer.WriteStartElement("object");
                                        writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dmChuong"); //Field name
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(result[i].BudgetChapterCode); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dmNdkt"); //Field name
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(result[i].BudgetSubItemCode); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dmNganhKt"); //Field name
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(result[i].BudgetSubKindItemCode); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dmNguonchi"); //Field name
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(result[i].BudgetSourceCode); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "dmTiente"); //Field name
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString(result[i].CurrencyCode); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "maHang"); //Field name
                                        writer.WriteStartElement("string"); //Start string
                                        writer.WriteString("1." + (i + 1).ToString()); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "soTienNT"); //Field name
                                        writer.WriteStartElement("double"); //Start string
                                        writer.WriteValue(result[0].AmountOC); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void
                                        totalAmount += result[i].Amount;

                                        //New field
                                        writer.WriteStartElement("void"); //Start void
                                        writer.WriteAttributeString("property", "soTienVnd"); //Field name
                                        writer.WriteStartElement("double"); //Start string
                                        writer.WriteValue(result[i].Amount); //Values
                                        writer.WriteEndElement(); //End string
                                        writer.WriteEndElement(); //End void
                                        //End add
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();
                                    }
                                    //Phần add này nằm cuối detail

                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("method", "add");
                                    writer.WriteStartElement("object");
                                    writer.WriteAttributeString("class", "dvc.service.custom.TemplateChungTuGt");

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dmChuong"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dmNdkt"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dmNganhKt"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dmNguonchi"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "dmTiente"); //Field name
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "maHang"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString("2.1"); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "soTienNT"); //Field name
                                    writer.WriteStartElement("double"); //Start string
                                    writer.WriteValue(0); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "soTienVnd"); //Field name
                                    writer.WriteStartElement("double"); //Start string
                                    writer.WriteValue(0); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //End add
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();
                                    //======================================================
                                    //End for
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();

                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "gnTaiLieuId"); //Field name
                                    writer.WriteStartElement("long"); //Start string
                                    writer.WriteValue((long)160); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "ngayChungTu");
                                    writer.WriteStartElement("object");
                                    writer.WriteAttributeString("class", "java.sql.Timestamp");
                                    writer.WriteStartElement("long");
                                    writer.WriteValue((long)(result[0].RefDate
                                        .ToUniversalTime()
                                        .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();
                                    writer.WriteEndElement(); // ngayChungtu

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "nguoinhanCmndNgaycap"); //Field name
                                    writer.WriteStartElement("object");
                                    writer.WriteAttributeString("class", "java.sql.Timestamp");
                                    writer.WriteStartElement("long");
                                    writer.WriteValue((long)(result[0].IssueDate
                                        .ToUniversalTime()
                                        .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds));
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "nguoinhanCmndNoicap"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].IssueBy); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "nguoinhanCmndSo"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].IdentificationNumber); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "nguoinhanHoten"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].AccountingObjectName); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "par1");
                                    writer.WriteStartElement("string");
                                    writer.WriteString(RSSHelper.NumberToWord.Read(result.Sum(x => x.Amount), "đồng", "", "#.0000"));
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();

                                    //New field
                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "par2");
                                    writer.WriteStartElement("string");
                                    writer.WriteString(RSSHelper.NumberToWord.Read(result.Sum(x => x.Amount), "đồng", "", "#.0000"));
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();

                                    //New field
                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "par3");
                                    writer.WriteStartElement("string");
                                    writer.WriteString(result.Sum(x => x.Amount).ToString());
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();

                                    //New field
                                    writer.WriteStartElement("void");
                                    writer.WriteAttributeString("property", "par4");
                                    writer.WriteStartElement("string");
                                    writer.WriteString(result.Sum(x => x.Amount).ToString());
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "soChungTu"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(result[0].RefNo); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "tcTu"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(IsRealytoPay.Equals(1) ? "2" : IsRealytoPay.Equals(2) ? "3" : IsRealytoPay.Equals(0) ? (cashWithDraw.Equals("0") || cashWithDraw.Equals("1")) ? "1" : "0" : "");
                                    //writer.WriteString("0"); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "ckTm"); //Field name
                                    writer.WriteStartElement("string"); //Start string
                                    writer.WriteString(reportParameter.RefType.Equals(55) ? "0" : "1"); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    //New field
                                    writer.WriteStartElement("void"); //Start void
                                    writer.WriteAttributeString("property", "typeChungTu"); //Field name
                                    writer.WriteStartElement("long"); //Start string
                                    writer.WriteValue(5); //Values
                                    writer.WriteEndElement(); //End string
                                    writer.WriteEndElement(); //End void

                                    writer.WriteEndElement(); //dvc.service.custom.TemplateChungTu
                                    writer.WriteEndElement(); //java

                                    writer.WriteEndDocument();
                                    writer.Close();
                                    if (exportXml.CreateZip(fileName, fbd.SelectedPath, reportName))
                                        XtraMessageBox.Show("Xuất Xml thành công", "Thông báo");
                                    else
                                        XtraMessageBox.Show("Xuất Xml không thành công", "Thông báo");

                                    //result = null;

                                    #endregion
                                }
                            }
                            return null;
                        }

                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Lỗi ở chỗ này " + ex.InnerException + ex.Message + ex.StackTrace);
                            return null;
                        }
                        //exportXml.GetReportC206NSXML(reportParameter, oRsTool);
                    }
                    return null;
                }

            }
            if (result.Count <= 0)
                result = null;
            return result;
            //var result = Model.ReportC205A(reportParameter.RefId).ToList();
            //return null;
        }

        /// <summary>
        /// Giấy rút vốn đầu tư TT77
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<C301NSModel> GetReportC301NS(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var frmSelect = new FrmC301NS_SelectParent();

            var result = new List<C301NSModel>();

            //Chọn dự án cha con
            if (frmSelect.ShowDialog() == DialogResult.OK)
            {
                var isParent = frmSelect.IsParent;
                //Chọn param và xem BC
                var frmParam = new FrmC301NS_Param(reportParameter.RefId, 0);
                if (frmParam.ShowDialog() == DialogResult.OK)
                {
                    result = Model.ReportC301NS(reportParameter.RefId, reportParameter.RefType, false, isParent, 0).ToList();
                    if (!oRsTool.Parameters.ContainsKey("TaxYear"))
                        oRsTool.Parameters.Add("TaxYear", frmParam.TaxYear.ToString());
                    if (!oRsTool.Parameters.ContainsKey("ProjectCode"))
                        oRsTool.Parameters.Add("ProjectCode", frmParam.ProjectCode);
                    if (!oRsTool.Parameters.ContainsKey("ProjectName"))
                        oRsTool.Parameters.Add("ProjectName", frmParam.ProjectName);
                    if (!oRsTool.Parameters.ContainsKey("CKCHDK"))
                        oRsTool.Parameters.Add("CKCHDK", frmParam.CKCHDK);
                    if (!oRsTool.Parameters.ContainsKey("CKCHDTH"))
                        oRsTool.Parameters.Add("CKCHDTH", frmParam.CKCHDTH);
                    if (!oRsTool.Parameters.ContainsKey("ListDetails"))
                        oRsTool.Parameters.Add("ListDetails", frmParam.ListDetails);
                }
                else
                {
                    return null;
                }
                if (result != null)
                {
                    var count = result.Count;
                    for (int i = 0; i < count; i++)
                    {
                        result[i].Details = Model.ReportC301NSDetail(reportParameter.RefId, reportParameter.RefType, true, isParent, 0).ToList();
                        if (result[i].Details.Count > 0)
                        {
                            for (int j = 0; j < result[i].Details.Count; j++)
                            {
                                for (int x = 0; x < frmParam.ListDetails.Count; x++)
                                {
                                    if (result[i].Details[j].RefDetailID.ToString() == frmParam.ListDetails[x].RefDetailId)
                                    {
                                        result[i].Details[j].TaxAmount = frmParam.ListDetails[x].Tax;
                                        result[i].Details[j].CompanyAmount = frmParam.ListDetails[x].TotalAmount;
                                        break;
                                    }
                                }
                            }
                            var sumAmount = result[0].Details.Sum(x => x.TotalAmount);
                            result[i].SumAmount = sumAmount;
                            var sumTax = result[0].Details.Sum(x => x.TaxAmount);
                            result[i].TaxAmount = sumTax;
                            var sumGetCompany = result[0].Details.Sum(x => x.CompanyAmount);
                            result[i].ObAmount = sumGetCompany;
                            //if (sumTax <= 0)
                            //{
                            //    result[i].TaxName = "";
                            //    result[i].TaxIDVAT = "";
                            //    result[i].TaxIDNKT = "";
                            //    result[i].TaxChapter = "";

                            //    result[i].TaxCompanyGet =
                            //        "Cơ quan quản lý thu:                             	Mã CQ thu:";
                            //    result[i].TaxKBNN = "KBNN hạch toán khoản thu: ";
                            //}

                            ////Xóa nếu tổng = 0
                            //if (result[i].SumAmount == 0)
                            //{
                            //    result.Remove(result[i]);
                            //}

                            ////Xóa nếu ko có refno (AnhNT: giữ nguyên yêu cầu nghiệp vụ cũ như inet)
                            //if (result[i].RefNo == null)
                            //{
                            //    result.Remove(result[i]);
                            //}
                        }
                    }
                }

                //Add param
                if (!oRsTool.Parameters.ContainsKey("check1"))
                    oRsTool.Parameters.Add("check1", frmParam.Check1 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check2"))
                    oRsTool.Parameters.Add("check2", frmParam.Check2 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check3"))
                    oRsTool.Parameters.Add("check3", frmParam.Check3 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check4"))
                    oRsTool.Parameters.Add("check4", frmParam.Check4 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check5"))
                    oRsTool.Parameters.Add("check5", frmParam.Check5 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check6"))
                    oRsTool.Parameters.Add("check6", frmParam.Check6 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check7"))
                    oRsTool.Parameters.Add("check7", frmParam.Check7 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check7"))
                    oRsTool.Parameters.Add("check7", frmParam.Check7 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("CKPTTTM"))
                    oRsTool.Parameters.Add("CKPTTTM", 0);
            }

            if (result.Count <= 0)
            {
                XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return null;
            }

            if (result.Count <= 0)
                result = null;
            return result;
        }
        public IList<C301NSModel> GetReportC301NSPT(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var frmSelect = new FrmC301NS_SelectParent();

            var result = new List<C301NSModel>();

            //Chọn dự án cha con
            if (frmSelect.ShowDialog() == DialogResult.OK)
            {
                var isParent = frmSelect.IsParent;
                //Chọn param và xem BC
                var frmParam = new FrmC301NS_Param(reportParameter.RefId, 1);
                if (frmParam.ShowDialog() == DialogResult.OK)
                {
                    result = Model.ReportC301NS(reportParameter.RefId, reportParameter.RefType, false, isParent, 1).ToList();
                    if (!oRsTool.Parameters.ContainsKey("TaxYear"))
                        oRsTool.Parameters.Add("TaxYear", frmParam.TaxYear.ToString());
                    if (!oRsTool.Parameters.ContainsKey("ProjectCode"))
                        oRsTool.Parameters.Add("ProjectCode", frmParam.ProjectCode);
                    if (!oRsTool.Parameters.ContainsKey("ProjectName"))
                        oRsTool.Parameters.Add("ProjectName", frmParam.ProjectName);
                    if (!oRsTool.Parameters.ContainsKey("CKCHDK"))
                        oRsTool.Parameters.Add("CKCHDK", frmParam.CKCHDK);
                    if (!oRsTool.Parameters.ContainsKey("CKCHDTH"))
                        oRsTool.Parameters.Add("CKCHDTH", frmParam.CKCHDTH);
                    if (!oRsTool.Parameters.ContainsKey("ListDetails"))
                        oRsTool.Parameters.Add("ListDetails", frmParam.ListDetailCAReceipts);
                }
                else
                {
                    return null;
                }
                if (result != null)
                {
                    var count = result.Count;
                    for (int i = 0; i < count; i++)
                    {
                        result[i].Details = Model.ReportC301NSDetail(reportParameter.RefId, reportParameter.RefType, true, isParent, 1).ToList();
                        if (result[i].Details.Count > 0)
                        {
                            for (int j = 0; j < result[i].Details.Count; j++)
                            {
                                for (int x = 0; x < frmParam.ListDetailCAReceipts.Count; x++)
                                {
                                    if (result[i].Details[j].RefDetailID.ToString() == frmParam.ListDetailCAReceipts[x].RefDetailId)
                                    {
                                        result[i].Details[j].TaxAmount = frmParam.ListDetailCAReceipts[x].Tax;
                                        result[i].Details[j].CompanyAmount = frmParam.ListDetailCAReceipts[x].TotalAmount;
                                        break;
                                    }
                                }
                            }
                            var sumAmount = result[0].Details.Sum(x => x.TotalAmount);
                            result[i].SumAmount = sumAmount;
                            var sumTax = result[0].Details.Sum(x => x.TaxAmount);
                            result[i].TaxAmount = sumTax;
                            var sumGetCompany = result[0].Details.Sum(x => x.CompanyAmount);
                            result[i].ObAmount = sumGetCompany;
                            //if (sumTax <= 0)
                            //{
                            //    result[i].TaxName = "";
                            //    result[i].TaxIDVAT = "";
                            //    result[i].TaxIDNKT = "";
                            //    result[i].TaxChapter = "";

                            //    result[i].TaxCompanyGet =
                            //        "Cơ quan quản lý thu:                             	Mã CQ thu:";
                            //    result[i].TaxKBNN = "KBNN hạch toán khoản thu: ";
                            //}

                            ////Xóa nếu tổng = 0
                            //if (result[i].SumAmount == 0)
                            //{
                            //    result.Remove(result[i]);
                            //}

                            ////Xóa nếu ko có refno (AnhNT: giữ nguyên yêu cầu nghiệp vụ cũ như inet)
                            //if (result[i].RefNo == null)
                            //{
                            //    result.Remove(result[i]);
                            //}
                        }
                    }
                }

                //Add param
                if (!oRsTool.Parameters.ContainsKey("check1"))
                    oRsTool.Parameters.Add("check1", frmParam.Check1 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check2"))
                    oRsTool.Parameters.Add("check2", frmParam.Check2 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check3"))
                    oRsTool.Parameters.Add("check3", frmParam.Check3 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check4"))
                    oRsTool.Parameters.Add("check4", frmParam.Check4 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check5"))
                    oRsTool.Parameters.Add("check5", frmParam.Check5 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check6"))
                    oRsTool.Parameters.Add("check6", frmParam.Check6 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check7"))
                    oRsTool.Parameters.Add("check7", frmParam.Check7 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check7"))
                    oRsTool.Parameters.Add("check7", frmParam.Check7 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("CKPTTTM"))
                    oRsTool.Parameters.Add("CKPTTTM", 1);
            }

            if (result.Count <= 0)
            {
                XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return null;
            }

            if (result.Count <= 0)
                result = null;
            return result;
        }
        public IList<C301NSModel> GetReportC301NSTTG(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var frmSelect = new FrmC301NS_SelectParent();

            var result = new List<C301NSModel>();

            //Chọn dự án cha con
            if (frmSelect.ShowDialog() == DialogResult.OK)
            {
                var isParent = frmSelect.IsParent;
                //Chọn param và xem BC
                var frmParam = new FrmC301NS_Param(reportParameter.RefId, 2);
                if (frmParam.ShowDialog() == DialogResult.OK)
                {
                    result = Model.ReportC301NS(reportParameter.RefId, reportParameter.RefType, false, isParent, 2).ToList();
                    if (!oRsTool.Parameters.ContainsKey("TaxYear"))
                        oRsTool.Parameters.Add("TaxYear", frmParam.TaxYear.ToString());
                    if (!oRsTool.Parameters.ContainsKey("ProjectCode"))
                        oRsTool.Parameters.Add("ProjectCode", frmParam.ProjectCode);
                    if (!oRsTool.Parameters.ContainsKey("ProjectName"))
                        oRsTool.Parameters.Add("ProjectName", frmParam.ProjectName);
                    if (!oRsTool.Parameters.ContainsKey("CKCHDK"))
                        oRsTool.Parameters.Add("CKCHDK", frmParam.CKCHDK);
                    if (!oRsTool.Parameters.ContainsKey("CKCHDTH"))
                        oRsTool.Parameters.Add("CKCHDTH", frmParam.CKCHDTH);
                    if (!oRsTool.Parameters.ContainsKey("ListDetails"))
                        oRsTool.Parameters.Add("ListDetails", frmParam.ListDetailBADeposit);
                }
                else
                {
                    return null;
                }
                if (result != null)
                {
                    var count = result.Count;
                    for (int i = 0; i < count; i++)
                    {
                        result[i].Details = Model.ReportC301NSDetail(reportParameter.RefId, reportParameter.RefType, true, isParent, 2).ToList();
                        if (result[i].Details.Count > 0)
                        {
                            for (int j = 0; j < result[i].Details.Count; j++)
                            {
                                for (int x = 0; x < frmParam.ListDetailBADeposit.Count; x++)
                                {
                                    if (result[i].Details[j].RefDetailID.ToString() == frmParam.ListDetailBADeposit[x].RefDetailId)
                                    {
                                        result[i].Details[j].TaxAmount = frmParam.ListDetailBADeposit[x].Tax;
                                        result[i].Details[j].CompanyAmount = frmParam.ListDetailBADeposit[x].TotalAmount;
                                        break;
                                    }
                                }
                            }
                            var sumAmount = result[0].Details.Sum(x => x.TotalAmount);
                            result[i].SumAmount = sumAmount;
                            var sumTax = result[0].Details.Sum(x => x.TaxAmount);
                            result[i].TaxAmount = sumTax;
                            var sumGetCompany = result[0].Details.Sum(x => x.CompanyAmount);
                            result[i].ObAmount = sumGetCompany;
                            //if (sumTax <= 0)
                            //{
                            //    result[i].TaxName = "";
                            //    result[i].TaxIDVAT = "";
                            //    result[i].TaxIDNKT = "";
                            //    result[i].TaxChapter = "";

                            //    result[i].TaxCompanyGet =
                            //        "Cơ quan quản lý thu:                             	Mã CQ thu:";
                            //    result[i].TaxKBNN = "KBNN hạch toán khoản thu: ";
                            //}

                            ////Xóa nếu tổng = 0
                            //if (result[i].SumAmount == 0)
                            //{
                            //    result.Remove(result[i]);
                            //}

                            ////Xóa nếu ko có refno (AnhNT: giữ nguyên yêu cầu nghiệp vụ cũ như inet)
                            //if (result[i].RefNo == null)
                            //{
                            //    result.Remove(result[i]);
                            //}
                        }
                    }
                }

                //Add param
                if (!oRsTool.Parameters.ContainsKey("check1"))
                    oRsTool.Parameters.Add("check1", frmParam.Check1 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check2"))
                    oRsTool.Parameters.Add("check2", frmParam.Check2 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check3"))
                    oRsTool.Parameters.Add("check3", frmParam.Check3 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check4"))
                    oRsTool.Parameters.Add("check4", frmParam.Check4 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check5"))
                    oRsTool.Parameters.Add("check5", frmParam.Check5 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check6"))
                    oRsTool.Parameters.Add("check6", frmParam.Check6 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check7"))
                    oRsTool.Parameters.Add("check7", frmParam.Check7 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("check7"))
                    oRsTool.Parameters.Add("check7", frmParam.Check7 ? 1 : 0);
                if (!oRsTool.Parameters.ContainsKey("CKPTTTM"))
                    oRsTool.Parameters.Add("CKPTTTM", 0);
            }

            if (result.Count <= 0)
            {
                XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return null;
            }

            if (result.Count <= 0)
                result = null;
            return result;
        }

        /// <summary>
        /// Giấy rút vốn đầu tư TT77
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<C301NSModel> GetReportND11TT52(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var frmSelect = new FrmC301NS_SelectParent();

            var result = new List<C301NSModel>();

            //Chọn dự án cha con
            if (frmSelect.ShowDialog() == DialogResult.OK)
            {
                var isParent = frmSelect.IsParent;
                //Chọn param và xem BC
                var frmParam = new FrmB01KB_Param(reportParameter.RefId);
                if (frmParam.ShowDialog() == DialogResult.OK)
                {
                    result = Model.ReportC301NS(reportParameter.RefId, reportParameter.RefType, false, isParent, 0).ToList();
                    var accumulatedAmount = string.Empty;
                    if (result.Count() > 0 && result[0].LKT > 0)
                    {
                        var amount = result[0].LKT;
                        string.Format("c:0", result[0].LKT.ToString());
                        accumulatedAmount = string.Concat(decimal.Parse(result[0].LKT.ToString("0.##")).ToString("C0"), " đồng");
                    }
                    var openAdvanceAmount = string.Empty;
                    if (result.Count() > 0 && result[0].SDTU > 0)
                    {
                        var amount = result[0].SDTU;
                        string.Format("c:0", result[0].SDTU.ToString());
                        openAdvanceAmount = string.Concat(decimal.Parse(result[0].SDTU.ToString("0.##")).ToString("C0"), " đồng");
                    }
                    if (!oRsTool.Parameters.ContainsKey("AccumulatedAmount"))
                        oRsTool.Parameters.Add("AccumulatedAmount", accumulatedAmount);
                    if (!oRsTool.Parameters.ContainsKey("OpenAdvanceAmount"))
                        oRsTool.Parameters.Add("OpenAdvanceAmount", openAdvanceAmount);
                    if (!oRsTool.Parameters.ContainsKey("TGTNN"))
                        oRsTool.Parameters.Add("TGTNN", frmParam.TGTNN);
                    if (!oRsTool.Parameters.ContainsKey("TGTTN"))
                        oRsTool.Parameters.Add("TGTTN", frmParam.TGTTN);
                    if (!oRsTool.Parameters.ContainsKey("TBHNN"))
                        oRsTool.Parameters.Add("TBHNN", frmParam.TBHNN);
                    if (!oRsTool.Parameters.ContainsKey("TBHTN"))
                        oRsTool.Parameters.Add("TBHTN", frmParam.TBHTN);
                }
                else
                {
                    return null;
                }

                decimal TotalEstimateAmount = 0;
                decimal TotalYTDInAmount = 0;
                decimal TotalYTDOutAmount = 0;
                decimal TotalPaymentInAmount = 0;
                decimal TotalPaymentOutAmount = 0;

                if (result != null)
                {
                    var count = result.Count;

                    for (int i = 0; i < count; i++)
                    {
                        result[i].Details = Model.ReportC301NSDetail(reportParameter.RefId, reportParameter.RefType, true, isParent, 0).ToList();
                        result[i].Details2 = Model.ReportC301NSDetail2(reportParameter.RefId, reportParameter.RefType, true, isParent, 0).ToList();
                        if (result[i].Details.Count > 0)
                        {
                            var sumAmount = result[0].Details.Sum(x => x.TotalAmount);
                            result[i].SumAmount = sumAmount;
                            var sumTax = result[0].Details.Sum(x => x.TaxAmount);
                            result[i].TaxAmount = sumTax;
                            var sumGetCompany = result[0].Details.Sum(x => x.CompanyAmount);
                            result[i].ObAmount = sumGetCompany;

                            TotalEstimateAmount = result[i].Details.Sum(s => s.EstimateAmount);
                            TotalYTDInAmount = result[i].Details.Sum(s => s.YTDInAmount);
                            TotalYTDOutAmount = result[i].Details.Sum(s => s.YTDOutAmount);
                            TotalPaymentInAmount = result[i].Details.Sum(s => s.PaymentInAmount);
                            TotalPaymentOutAmount = result[i].Details.Sum(s => s.PaymentOutAmount);
                        }
                    }
                }

                //Add param
                if (!oRsTool.Parameters.ContainsKey("TotalEstimateAmount"))
                    oRsTool.Parameters.Add("TotalEstimateAmount", TotalEstimateAmount);
                if (!oRsTool.Parameters.ContainsKey("TotalYTDInAmount"))
                    oRsTool.Parameters.Add("TotalYTDInAmount", TotalYTDInAmount);
                if (!oRsTool.Parameters.ContainsKey("TotalYTDOutAmount"))
                    oRsTool.Parameters.Add("TotalYTDOutAmount", TotalYTDOutAmount);
                if (!oRsTool.Parameters.ContainsKey("TotalPaymentInAmount"))
                    oRsTool.Parameters.Add("TotalPaymentInAmount", TotalPaymentInAmount);
                if (!oRsTool.Parameters.ContainsKey("TotalPaymentOutAmount"))
                    oRsTool.Parameters.Add("TotalPaymentOutAmount", TotalPaymentOutAmount);
                if (!oRsTool.Parameters.ContainsKey("SumPaymentAmount"))
                    oRsTool.Parameters.Add("SumPaymentAmount", Math.Round(TotalPaymentInAmount + TotalPaymentOutAmount));
            }

            if (result.Count <= 0)
            {
                XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return null;
            }

            if (result.Count <= 0)
                result = null;
            return result;
        }
        /// <summary>
        /// Giấy rút vốn đầu tư TT77
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<C301NSModel> GetReportBusC302(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            var frmSelect = new FrmC301NS_SelectParent();

            var result = new List<C301NSModel>();

            //Chọn dự án cha con
            if (frmSelect.ShowDialog() == DialogResult.OK)
            {
                var isParent = frmSelect.IsParent;
                //Chọn param và xem BC
                var frmParam = new FrmB01KB_Param(reportParameter.RefId);
                if (frmParam.ShowDialog() == DialogResult.OK)
                {
                    result = Model.ReportC301NS(reportParameter.RefId, reportParameter.RefType, false, isParent, 0).ToList();
                    if (result.Count <= 0)
                    {
                        XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return null;
                    }
                    if (!oRsTool.Parameters.ContainsKey("TGTNN"))
                        oRsTool.Parameters.Add("TGTNN", frmParam.TGTNN);
                    if (!oRsTool.Parameters.ContainsKey("TGTTN"))
                        oRsTool.Parameters.Add("TGTTN", frmParam.TGTTN);
                    if (!oRsTool.Parameters.ContainsKey("TBHNN"))
                        oRsTool.Parameters.Add("TBHNN", frmParam.TBHNN);
                    if (!oRsTool.Parameters.ContainsKey("TBHTN"))
                        oRsTool.Parameters.Add("TBHTN", frmParam.TBHTN);
                }
                else
                {
                    return null;
                }

                decimal TotalEstimateAmount = 0;
                decimal TotalYTDInAmount = 0;
                decimal TotalYTDOutAmount = 0;
                decimal TotalPaymentInAmount = 0;
                decimal TotalPaymentOutAmount = 0;

                if (result != null)
                {
                    var count = result.Count;

                    for (int i = 0; i < count; i++)
                    {
                        result[i].Details = Model.ReportC301NSDetail(reportParameter.RefId, reportParameter.RefType, true, isParent, 0).ToList();
                        if (result[i].Details.Count > 0)
                        {
                            var sumAmount = result[0].Details.Sum(x => x.TotalAmount);
                            result[i].SumAmount = sumAmount;
                            var sumTax = result[0].Details.Sum(x => x.TaxAmount);
                            result[i].TaxAmount = sumTax;
                            var sumGetCompany = result[0].Details.Sum(x => x.CompanyAmount);
                            result[i].ObAmount = sumGetCompany;

                            TotalEstimateAmount = result[i].Details.Sum(s => s.EstimateAmount);
                            TotalYTDInAmount = result[i].Details.Sum(s => s.YTDInAmount);
                            TotalYTDOutAmount = result[i].Details.Sum(s => s.YTDOutAmount);
                            TotalPaymentInAmount = result[i].Details.Sum(s => s.PaymentInAmount);
                            TotalPaymentOutAmount = result[i].Details.Sum(s => s.PaymentOutAmount);
                        }
                    }
                }

                //Add param
                if (!oRsTool.Parameters.ContainsKey("TotalEstimateAmount"))
                    oRsTool.Parameters.Add("TotalEstimateAmount", TotalEstimateAmount);
                if (!oRsTool.Parameters.ContainsKey("TotalYTDInAmount"))
                    oRsTool.Parameters.Add("TotalYTDInAmount", TotalYTDInAmount);
                if (!oRsTool.Parameters.ContainsKey("TotalYTDOutAmount"))
                    oRsTool.Parameters.Add("TotalYTDOutAmount", TotalYTDOutAmount);
                if (!oRsTool.Parameters.ContainsKey("TotalPaymentInAmount"))
                    oRsTool.Parameters.Add("TotalPaymentInAmount", TotalPaymentInAmount);
                if (!oRsTool.Parameters.ContainsKey("TotalPaymentOutAmount"))
                    oRsTool.Parameters.Add("TotalPaymentOutAmount", TotalPaymentOutAmount);
                if (!oRsTool.Parameters.ContainsKey("SumPaymentAmount"))
                    oRsTool.Parameters.Add("SumPaymentAmount", Math.Round(TotalPaymentInAmount + TotalPaymentOutAmount));
            }

            if (result.Count <= 0)
            {
                XtraMessageBox.Show("Dữ liệu báo cáo không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return null;
            }

            if (result.Count <= 0)
                result = null;
            return result;
        }
        public IList<PaymentPurchaseModel> GetPaymentPurchase(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            //var frmParam = new FrmC301NS();
            //var result = new List<C301NSModel>();
            //if (frmParam.ShowDialog() == DialogResult.OK)
            //{
            //    result = Model.ReportC301NS(reportParameter.RefId, reportParameter.RefType).ToList();
            //    //Xuất XML
            //    if (!frmParam.IsPreviewOrExportXML)
            //    {
            //        if (result.Count > 0)
            //        {
            //            exportXml.GetReportC206NSXML(reportParameter, oRsTool);
            //        }
            //        return null;
            //    }

            //}
            //if (result.Count <= 0)
            //    result = null;
            return null;
            //var result = Model.ReportC205A(reportParameter.RefId).ToList();
            //return null;
        }


    }
}
