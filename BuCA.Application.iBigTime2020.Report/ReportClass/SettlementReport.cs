/***********************************************************************
 * <copyright file="SettlementReport.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Wednesday, May 23, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Settlement;
using BuCA.Application.iBigTime2020.Report.ParameterReportForm;
using BuCA.Application.iBigTime2020.Session;
using PerpetuumSoft.Framework.Drawing;
using PerpetuumSoft.Reporting.Components;
using PerpetuumSoft.Reporting.DOM;
using RSSHelper;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    /// <summary>
    ///     Class SettlementReport.
    /// </summary>
    public class SettlementReport : BaseReport
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SettlementReport" /> class.
        /// </summary>
        public SettlementReport()
        {
            Model = new Model();
        }

        /// <summary>
        ///     Gets the report B03 BCQT.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList{B03BCQTModel}.</returns>
        public IList<B03BCQTModel> GetReportB03BCQT(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<B03BCQTModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
                using (var frmParam = new FrmFinacialReportB02BCTC())
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

                        list = Model.GetReportB03BCQT(startdate, fromDate, toDate, frmParam.BudgetChapterCode,
                            frmParam.IsSummaryBudgetChapter, false, false);
                    }
                    else
                    {
                        list = null;
                    }
                }
            return list;
        }

        /// <summary>
        ///     Gets the report F01001 BCQT.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList{B03BCQTModel}.</returns>
        public IList<F0101BCQTModel> GetReportF01001BCQT(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<F0101BCQTModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            var currencyPrefix = Model.GetCurrencyByCurrencyCode(currencyCode).Prefix ?? "";
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
                using (var frmParam = new FrmF0101BCQT())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startdate = DateTime.Parse(frmParam.StartDate);
                        var budgetSource = frmParam.BudgetSourceCode;
                        var budgetChapter = frmParam.BudgetChapterCode;
                        var budgetSubKindItem = frmParam.BudgetSubKindItemCode;
                        var isSummaryBudgetSource = frmParam.IsSummaryBudgetSource;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;

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
                        list = Model.GetReportF01001BCQT(startdate, fromDate, toDate, budgetSource, budgetChapter,
                            budgetSubKindItem, isSummaryBudgetSource, isSummaryBudgetChapter,
                            isSummaryBudgetSubKindItem,amountType,currencyCode);
                    }
                    else
                    {
                        list = null;
                    }
                }
            return list;
        }

        
        public IList<Object> GetReportF0102BCQT(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<object> list = new List<object>();
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
                using (var frmParam = new FrmF0102BCQT())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startdate = DateTime.Parse(frmParam.StartDate);
                        var budgetSource = frmParam.BudgetSourceCode;
                        var budgetChapter = frmParam.BudgetChapterCode;
                        var budgetSubKindItem = frmParam.BudgetSubKindItemCode;
                        var isSummaryBudgetSource = frmParam.IsSummaryBudgetSource;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var projectID = frmParam.ProjectID;
                        var methodDistribute = frmParam.MethodDistributeId;
                        var isProject = frmParam.IsSummaryProject;
                        var isMethodDistribute = frmParam.IsSummaryMethodDistribute;
                        var budgetKindItemCode = budgetSubKindItem;
                        if (isSummaryBudgetSubKindItem)
                            budgetKindItemCode = "<<Tổng hợp>>";
                        if (!oRsTool.Parameters.ContainsKey("BudgetKindItem"))
                            oRsTool.Parameters.Add("BudgetKindItem", budgetKindItemCode);
                        var budgetKindItem = Model.GetBudgetKindItemsByCodeIncludeParentCode(budgetKindItemCode);
                        var budgetKindItemParentCode = "Loại";
                        if (budgetKindItem != null && !string.IsNullOrEmpty(budgetKindItem.ParentId))
                            budgetKindItemParentCode = budgetKindItem.ParentId;
                        if (!oRsTool.Parameters.ContainsKey("BudgetKindItemParent"))
                            oRsTool.Parameters.Add("BudgetKindItemParent", budgetKindItemParentCode);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemDay"))
                            oRsTool.Parameters.Add("DateSystemDay", DateTime.Today.Day);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemMonth"))
                            oRsTool.Parameters.Add("DateSystemMonth", DateTime.Today.Month);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemYear"))
                            oRsTool.Parameters.Add("DateSystemYear", DateTime.Today.Year);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("ReportSubTitle"))
                            oRsTool.Parameters.Add("ReportSubTitle", ConvertDateToStringForReport(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate)));
                       
                     
                        DataSet ds = Model.GetReportF0102BCQT(startdate, fromDate, toDate, budgetSource, budgetChapter,
                            budgetSubKindItem, isSummaryBudgetSource, isSummaryBudgetChapter,
                            isSummaryBudgetSubKindItem, projectID, methodDistribute, isMethodDistribute, isProject);
                        if (ds.Tables.Count < 3) return list;
                        if (ds.Tables[0].Rows.Count < 1) return list;
                        //Convert Datatable to List DataSource
                        var result = RenderDynamic(ds.Tables[1]);
                        if (ds.Tables.Count == 3 && result == true)
                        {
                            Dictionary<string, Type> fieldList = new Dictionary<string, Type>();

                            foreach (DataColumn dtCol in ds.Tables[0].Columns)
                            {
                                fieldList.Add(dtCol.ColumnName, dtCol.DataType);
                            }

                            fieldList.Add("Details", typeof(List<object>));


                            Dictionary<string, string> details = new Dictionary<string, string>();
                            int i = 0;
                            foreach (DataRow dtRow in ds.Tables[0].Rows)
                            {
                                object dynamicObj = DynamicObject.DynamicObject.CreateNewObject(fieldList);
                                foreach (var field in fieldList.OrderBy(r => r.Key))
                                {
                                    PropertyInfo propertyInfos = dynamicObj.GetType().GetProperty(field.Key);

                                    var value = string.Empty;
                                    if (field.Key == "Details") propertyInfos.SetValue(dynamicObj, null, null);
                                    else
                                    {
                                        value = dtRow[field.Key].ToString();
                                    }

                                    if (propertyInfos.PropertyType == typeof(decimal))
                                    {
                                        decimal valueDecimal = string.IsNullOrEmpty(value) ? 0 : decimal.Parse(value);
                                        propertyInfos.SetValue(dynamicObj, valueDecimal, null);
                                    }
                                    else if (propertyInfos.PropertyType == typeof(int))
                                    {
                                        int valueint = string.IsNullOrEmpty(value) ? 0 : int.Parse(value);
                                        propertyInfos.SetValue(dynamicObj, valueint, null);
                                    }
                                    else if (propertyInfos.PropertyType == typeof(DateTime))
                                    {
                                        DateTime valueDate = string.IsNullOrEmpty(value)
                                            ? DateTime.MinValue
                                            : DateTime.Parse(value);
                                        propertyInfos.SetValue(dynamicObj, valueDate, null);
                                    }
                                    else if (propertyInfos.PropertyType == typeof(bool))
                                    {
                                        bool valueBit = string.IsNullOrEmpty(value) ? false : bool.Parse(value);
                                        propertyInfos.SetValue(dynamicObj, valueBit, null);
                                    }
                                    else if (propertyInfos.PropertyType == typeof(Guid))
                                    {
                                        Guid valueGuild = string.IsNullOrEmpty(value) ? Guid.Empty : new Guid(value);
                                        propertyInfos.SetValue(dynamicObj, valueGuild, null);
                                    }
                                    else if (propertyInfos.PropertyType == typeof(string))
                                    {
                                        string valueString = string.IsNullOrEmpty(value) ? "" : value;
                                        propertyInfos.SetValue(dynamicObj, valueString, null);
                                    }
                                    else
                                    {
                                        propertyInfos.SetValue(dynamicObj, null, null);
                                    }
                                }

                                list.Add(dynamicObj);
                            }
                        }
                    }
                    else
                    {
                        list = null;
                    }
                }
            
            return list;
        }

        public bool RenderDynamic(DataTable dtSource)
        {


            var reportSlot = new FileReportSlot { FilePath = GlobalVariable.ReportPath + "F01_02_BCQT.rst" };

            Document doc = reportSlot.LoadReport();



            while (doc.Pages.Count > 2)
            {
                doc.Pages.RemoveAt(2);
            }

            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeaderDynamic = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();

          

            FontDescriptor fontHead = new FontDescriptor("Times New Roman", 9, FontStyleMode.On, FontStyleMode.Off,
                FontStyleMode.Off);

            Header header = (Header)doc.ControlByName("HeaderGroup");
            Header header3 = (Header)doc.ControlByName("HeaderSubGroup");
            Detail detail = (Detail)doc.ControlByName("DetailGroup");
            PageFooter pageFooter = (PageFooter)doc.ControlByName("pageFooter");
            header.Controls.Clear();
            header3.Controls.Clear();
            detail.Controls.Clear();

            //header.StyleName = "HeaderFooter1";
            //header3.StyleName = "HeaderFooter1";
            Border oBorder = new Border();
            BorderLine oBorderLine = new BorderLine();
            oBorderLine.Width = 1;
            oBorderLine.Color = System.Drawing.Color.Black;
            oBorderLine.Style = PerpetuumSoft.Framework.Drawing.LineStyle.Solid;
            oBorder = new Border(oBorderLine, oBorderLine, oBorderLine, oBorderLine);

            #region Header

            //Tạo cột STT
            textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader.Name = "txtNumber";
            textBoxHeader.Text = "STT";
            header.Controls.Add(textBoxHeader);
            textBoxHeader.Location = new Vector(1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.Size = new Vector(0.8f, 1.8f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader.Border = oBorder;
            textBoxHeader.Font = fontHead;

            //Tạo cột Chỉ tiêu
            textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader.Name = "txtCT";
            textBoxHeader.Text = "Chỉ tiêu";
            header.Controls.Add(textBoxHeader);
            textBoxHeader.Location = new Vector(1.8f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.Size = new Vector(8.3f, 1.8f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader.Border = oBorder;
            textBoxHeader.Font = fontHead;

            //Tạo cột mã số
            textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader.Name = "txtMS";
            textBoxHeader.Text = "Mã số";
            header.Controls.Add(textBoxHeader);
            textBoxHeader.Location = new Vector(10.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.Size = new Vector(1f, 1.8f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader.Border = oBorder;
            textBoxHeader.Font = fontHead;


            //Tạo cột năm nay

            textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader2.Name = "txtNamNay";
            textBoxHeader2.Text = "Năm nay";
            header.Controls.Add(textBoxHeader2);
            textBoxHeader2.Location = new Vector(11.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.Size = new Vector(8.8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader2.Border = oBorder;
            textBoxHeader2.Font = fontHead;



            //Tạo cột lũy kế

            textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader2.Name = "txtLuyKe";
            textBoxHeader2.Text = "Lũy kế từ khi khởi đầu";
            header.Controls.Add(textBoxHeader2);
            textBoxHeader2.Location = new Vector(19.9f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.Size = new Vector(8.8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader2.Border = oBorder;
            textBoxHeader2.Font = fontHead;


            #endregion

            #region Header3

            //Tạo cột STT
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtNumber3";
            textBoxHeader3.Text = "A";
            header3.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(0.8f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;
            textBoxHeader3.Font = fontHead;

            //Tạo cột Chỉ tiêu
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtCT3";
            textBoxHeader3.Text = "B";
            header3.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(1.8f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(8.3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;
            textBoxHeader3.Font = fontHead;

            //Tạo cột mã số
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtMS3";
            textBoxHeader3.Text = "C";
            header3.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(10.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(1f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;
            textBoxHeader3.Font = fontHead;

            #endregion

            #region Detail

            //Tạo cột STT
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtdetailNumber1";
            textBoxDetail.Text = "";
            detail.Controls.Add(textBoxDetail);
            textBoxDetail.Location = new Vector(1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(0.8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;

            //Tạo cột Chỉ tiêu
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtDetailTargets";
            textBoxDetail.Text = "";
            detail.Controls.Add(textBoxDetail);
            textBoxDetail.Location = new Vector(1.8f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(8.3f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;


            //Tạo cột mã số
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtDetailMS";
            textBoxDetail.Text = "";
            detail.Controls.Add(textBoxDetail);
            textBoxDetail.Location = new Vector(10.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(1f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;

            detail.GenerateScript = "txtDetailTargets.Text = GetData(\"ReportItemName\").ToString(); " +
                                    "txtdetailNumber1.Text= GetData(\"ReportItemAlias\").ToString(); " +
                                    "txtDetailMS.Text = GetData(\"ReportItemCode\").ToString(); " +
                                    "if(GetData(\"IsBold\").ToString()==\"True\")" +
                                    "{ txtDetailTargets.Font =  detaiBold;  txtdetailNumber1.Font =  detaiBold;  txtDetailMS.Font =  detaiBold;}"
                                    + "else { txtDetailTargets.Font =  detaiNormal; txtdetailNumber1.Font =  detaiNormal;  txtDetailMS.Font =  detaiNormal;}";

            #endregion

            #region Tạo cột tổng số của mục năm nay và lũy kế 

            DataTable dtThisYear = null;
            DataTable dtAccumulated = null;
            string columnTotalThisYearName = "TotalThisYear";
            string columnTotalAccumulatedName = "TotalAccumulated";
            var dataRowThisYear = dtSource.AsEnumerable().Where(x =>
                x.Field<string>("ParentID") == "1_SUM_Part" && x.Field<string>("BudgetSourceCode") == "SUM_Part");
            if (dataRowThisYear.Count() > 0)
            {
                dtThisYear = dataRowThisYear.CopyToDataTable();
                columnTotalThisYearName = dtThisYear.Rows[0]["PayrollItemColumnID"].ToString();
            }

            var dataRowAccumulated = dtSource.AsEnumerable().Where(x =>
                x.Field<string>("ParentID") == "2_SUM_Part" && x.Field<string>("BudgetSourceCode") == "SUM_Part");

            if (dataRowThisYear.Count() > 0)
            {
                dtAccumulated = dataRowAccumulated.CopyToDataTable();
                columnTotalAccumulatedName = dtAccumulated.Rows[0]["PayrollItemColumnID"].ToString();
            }

            //năm nay

            textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader.Name = "txtHead" + columnTotalThisYearName;
            textBoxHeader.Text = "Tổng số";
            header.Controls.Add(textBoxHeader);
            textBoxHeader.Location = new Vector(11.1f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.Size = new Vector(2.2f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader.Border = oBorder;
            textBoxHeader.Font = fontHead;

            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txt3" + columnTotalThisYearName;
            ;
            textBoxHeader3.Text = "";
            header3.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(11.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;

            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtDetail" + columnTotalThisYearName;
            textBoxDetail.Text = "";
            detail.Controls.Add(textBoxDetail);
            textBoxDetail.Location = new Vector(11.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;

            if (!columnTotalThisYearName.Contains("TotalThisYear"))
            {
                textBoxDetail.GenerateScript = textBoxDetail.Name + ".Value=GetData(\"" +
                                               dtThisYear.Rows[0]["PayrollItemColumnID"] + "\").ToString(); "
                                               + textBoxDetail.Name + ".TextFormat = "
                                               + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");"; 
            }

            //lũy kế
            textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader.Name = "txtHead" + columnTotalAccumulatedName;
            textBoxHeader.Text = "Tổng số";
            header.Controls.Add(textBoxHeader);
            textBoxHeader.Location = new Vector(19.9f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.Size = new Vector(2.2f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
            textBoxHeader.Border = oBorder;
            textBoxHeader.Font = fontHead;


            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txt3" + columnTotalAccumulatedName;
            textBoxHeader3.Text = "";
            header3.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(19.9f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;
            textBoxHeader3.Font = fontHead;


            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtDetail" + columnTotalAccumulatedName;
            textBoxDetail.Text = "";
            detail.Controls.Add(textBoxDetail);
            textBoxDetail.Location = new Vector(19.9f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;

            if (!columnTotalAccumulatedName.Contains("TotalAccumulated"))
            {
                textBoxDetail.GenerateScript = textBoxDetail.Name + ".Value= decimal.Parse(GetData(\"" +
                                               dtAccumulated.Rows[0]["PayrollItemColumnID"] + "\").ToString())==0 ?\"\":"+ "GetData(\"" 
                                               +   dtAccumulated.Rows[0]["PayrollItemColumnID"] + "\").ToString();"
                                               + textBoxDetail.Name + ".TextFormat = "
                                               + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");";
            }


            #endregion

            #region  tạo cột động loại khoản 

            int countPage = 0;
            DataTable dtThisYearBudget = dtSource.Select("ParentID ='1_SUM_Part' AND BudgetSourceCode <> 'SUM_Part'")
                .CopyToDataTable();

            //Mỗi loại sẽ tạo 1 trang mới 
            if(dtThisYearBudget!=null)
                for (int p = 0; p < dtThisYearBudget.Rows.Count; p++)

                {
                    if (p == 0)
                    {
                        //tạo template loại
                        textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader2.Name =
                            "txtThisYear" + dtThisYearBudget.Rows[p]["PayrollItemColumnID"].ToString() + p;
                        textBoxHeader2.Text = dtThisYearBudget.Rows[p]["TitleColumn"].ToString();
                        header.Controls.Add(textBoxHeader2);
                        textBoxHeader2.Location =
                            new Vector(13.3f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2.Size = new Vector(6.6f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                        textBoxHeader2.Border = oBorder;
                        textBoxHeader2.Font = fontHead;

                        textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader2.Name =
                            "txtAccumulated" + dtThisYearBudget.Rows[p]["PayrollItemColumnID"].ToString() + p;
                        textBoxHeader2.Text = dtThisYearBudget.Rows[p]["TitleColumn"].ToString();
                        header.Controls.Add(textBoxHeader2);
                        textBoxHeader2.Location =
                            new Vector(22.1f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2.Size = new Vector(6.6f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                        textBoxHeader2.Border = oBorder;
                        textBoxHeader2.Font = fontHead;

                        DataTable dtResult = dtSource
                            .Select("ParentID ='" + dtThisYearBudget.Rows[p]["PayrollItemColumnID"].ToString() + "'")
                            .CopyToDataTable();

                        DataTable dtResultFist = dtResult.Select().Skip(0).Take(3).CopyToDataTable();

                        int countSubKind = dtResult.Rows.Count;

                        int surPlusSubKind = (countSubKind) % 3;
                        int pageIndexSubkind = (countSubKind) / 3;
                        if (surPlusSubKind > 0) pageIndexSubkind = pageIndexSubkind + 1;
                        //else pageIndexSubkind = pageIndexSubkind + 1;

                        //tạo trang đầu tiên của khoản

                        double margin = 0;
                        int countColumn = 0;
                        foreach (DataRow dr in dtResultFist.Rows)
                        {
                            #region

                            //năm nay
                            textBoxHeaderDynamic = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeaderDynamic.Name = "txtThisYear" + dr["PayrollItemColumnID"];
                            textBoxHeaderDynamic.Text = dr["TitleColumn"].ToString();
                            header.Controls.Add(textBoxHeaderDynamic);
                            textBoxHeaderDynamic.Location =
                                new Vector(13.3f + margin, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamic.Size =
                                new Vector(2.2f, 0.7f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeaderDynamic.CanGrow =
                                textBoxHeaderDynamic.CanShrink = textBoxHeaderDynamic.GrowToBottom = true;
                            textBoxHeaderDynamic.Border = oBorder;
                            textBoxHeaderDynamic.Font = fontHead;

                            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeader3.Name = "txt3ThisYear" + dr["PayrollItemColumnID"];
                            textBoxHeader3.Text = "";
                            header3.Controls.Add(textBoxHeader3);
                            textBoxHeader3.Location =
                                new Vector(13.3f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3.Size =
                                new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
                            textBoxHeader3.Border = oBorder;
                            textBoxHeader3.Font = fontHead;

                            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxDetail.Name = "txtDetailThisYear" + dr["PayrollItemColumnID"];
                            textBoxDetail.Text = "";
                            detail.Controls.Add(textBoxDetail);
                            textBoxDetail.Location =
                                new Vector(13.3f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetail.Size =
                                new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
                            textBoxDetail.Border = oBorder;
                            textBoxDetail.GenerateScript = textBoxDetail.Name + ".Value= decimal.Parse(GetData(\"" +
                                                           dr["PayrollItemColumnID"] + "\").ToString()) ==0 ?(object)null:  " +
                                                           "decimal.Parse(GetData(\""
                                                           + dr["PayrollItemColumnID"] + "\").ToString());"
                                                           + textBoxDetail.Name + ".TextFormat = "
                                                           + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");"
                                                           + "if (GetData(\"IsBold\").ToString()==\"True\"){" +
                                                           textBoxDetail.Name + ".Font =detaiBold;} else{" +
                                                           textBoxDetail.Name + ".Font =detaiNormal;}";

                            //lũy kế

                            DataRow drAcc = dtSource
                                .Select("ParentID like '2%' AND  BudgetSourceCode <> 'SUM_Part' AND TitleColumn = '" +
                                        dr["TitleColumn"].ToString() + "'").FirstOrDefault();

                            textBoxHeaderDynamic = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeaderDynamic.Name = "txtAccumulated" + drAcc["PayrollItemColumnID"];
                            textBoxHeaderDynamic.Text = drAcc["TitleColumn"].ToString();
                            header.Controls.Add(textBoxHeaderDynamic);
                            textBoxHeaderDynamic.Location =
                                new Vector(22.1f + margin, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamic.Size =
                                new Vector(2.2f, 0.7f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeaderDynamic.CanGrow =
                                textBoxHeaderDynamic.CanShrink = textBoxHeaderDynamic.GrowToBottom = true;
                            textBoxHeaderDynamic.Border = oBorder;
                            textBoxHeaderDynamic.Font = fontHead;

                            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeader3.Name = "txt3Accumulated" + drAcc["PayrollItemColumnID"];
                            textBoxHeader3.Text = "";
                            header3.Controls.Add(textBoxHeader3);
                            textBoxHeader3.Location =
                                new Vector(22.1f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3.Size =
                                new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
                            textBoxHeader3.Border = oBorder;
                            textBoxHeader3.Font = fontHead;

                            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxDetail.Name = "txtDetailAccumulated" + drAcc["PayrollItemColumnID"];
                            textBoxDetail.Text = "";
                            detail.Controls.Add(textBoxDetail);
                            textBoxDetail.Location =
                                new Vector(22.1f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetail.Size =
                                new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
                            textBoxDetail.Border = oBorder;
                            textBoxDetail.GenerateScript = textBoxDetail.Name + ".Value= decimal.Parse(GetData(\"" +
                                                           drAcc["PayrollItemColumnID"] + "\").ToString()) ==0 ?(object)null: "
                                                           + "decimal.Parse(GetData(\"" +
                                                           drAcc["PayrollItemColumnID"] + "\").ToString()); "
                                                           + textBoxDetail.Name + ".TextFormat = "
                                                           + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");"
                                                           + "if (GetData(\"IsBold\").ToString()==\"True\"){" +
                                                           textBoxDetail.Name + ".Font =detaiBold;} else{" +
                                                           textBoxDetail.Name + ".Font =detaiNormal;}";

                            countColumn = countColumn + 1;
                            margin = margin + 2.2f;

                            #endregion
                        }

                        for (int i = countColumn; i < 3; i++)
                        {
                            #region

                            //năm nay
                            textBoxHeaderDynamic = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeaderDynamic.Name = "txtThisYearEx" + i;
                            textBoxHeaderDynamic.Text = "";
                            header.Controls.Add(textBoxHeaderDynamic);
                            textBoxHeaderDynamic.Location =
                                new Vector(13.3f + margin, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamic.Size =
                                new Vector(2.2f, 0.7f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeaderDynamic.CanGrow =
                                textBoxHeaderDynamic.CanShrink = textBoxHeaderDynamic.GrowToBottom = true;
                            textBoxHeaderDynamic.Border = oBorder;


                            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeader3.Name = "txt3ThisYearEx" + i;
                            textBoxHeader3.Text = "";
                            header3.Controls.Add(textBoxHeader3);
                            textBoxHeader3.Location =
                                new Vector(13.3f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3.Size =
                                new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
                            textBoxHeader3.Border = oBorder;

                            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxDetail.Name = "txtDetailThisYearEx" + i;
                            textBoxDetail.Text = "";
                            detail.Controls.Add(textBoxDetail);
                            textBoxDetail.Location =
                                new Vector(13.3f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetail.Size =
                                new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
                            textBoxDetail.Border = oBorder;


                            //lũy kế

                            textBoxHeaderDynamic = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeaderDynamic.Name = "txtAccumulatedEx" + i;
                            textBoxHeaderDynamic.Text = "";
                            header.Controls.Add(textBoxHeaderDynamic);
                            textBoxHeaderDynamic.Location =
                                new Vector(22.1f + margin, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamic.Size =
                                new Vector(2.2f, 0.7f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeaderDynamic.CanGrow =
                                textBoxHeaderDynamic.CanShrink = textBoxHeaderDynamic.GrowToBottom = true;
                            textBoxHeaderDynamic.Border = oBorder;


                            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeader3.Name = "txt3AccumulatedEx" + i;
                            textBoxHeader3.Text = "";
                            header3.Controls.Add(textBoxHeader3);
                            textBoxHeader3.Location =
                                new Vector(22.1f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3.Size =
                                new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeader3.CanGrow = textBoxHeader3.CanShrink = textBoxHeader3.GrowToBottom = true;
                            textBoxHeader3.Border = oBorder;

                            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxDetail.Name = "txtDetailAccumulatedEx" + i;
                            textBoxDetail.Text = "";
                            detail.Controls.Add(textBoxDetail);
                            textBoxDetail.Location =
                                new Vector(22.1f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetail.Size =
                                new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxDetail.CanGrow = textBoxDetail.CanShrink = textBoxDetail.GrowToBottom = true;
                            textBoxDetail.Border = oBorder;
                            margin = margin + 2.2f;

                            #endregion
                        }

                        #region Tạo page N phát sinh cột Khoản tự động --

                        //#region Các cột mẫu tất cả các trang tạo mới đều phải có
                        //Page checkpage = (Page)doc.ControlByName("page" + countPage);
                        //if (checkpage != null) doc.Pages.Remove(checkpage);

                        if (pageIndexSubkind > 1)
                            for (int n = 0; n < pageIndexSubkind; n++)
                            {
                                #region tạo cột cố định 

                                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeaderN =
                                    new PerpetuumSoft.Reporting.DOM.TextBox();
                                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeaderDynamicN =
                                    new PerpetuumSoft.Reporting.DOM.TextBox();
                                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader2N =
                                    new PerpetuumSoft.Reporting.DOM.TextBox();
                                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader3N =
                                    new PerpetuumSoft.Reporting.DOM.TextBox();
                                PerpetuumSoft.Reporting.DOM.TextBox textBoxDetailN =
                                    new PerpetuumSoft.Reporting.DOM.TextBox();
                                PerpetuumSoft.Reporting.DOM.TextBox textBoxFooter =
                                    new PerpetuumSoft.Reporting.DOM.TextBox();

                                Page page = new Page();
                                page.Name = "page" + countPage;
                                page.Margins = new Margins(1f, 1f, 1.1f, 1.1f);
                                page.Orientation = PageOrientation.Landscape;
                                doc.Pages.Add(page);



                                PageHeader pageHeader = new PageHeader();
                                pageHeader.Name = "pageHeader" + countPage;
                                pageHeader.Location =
                                    new Vector(0f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                pageHeader.Size =
                                    new Vector(29.7f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                page.Controls.Add(pageHeader);

                                PageFooter pagefooter = new PageFooter();
                                pagefooter.Name = "pagefooter" + countPage;

                                page.Controls.Add(pagefooter);

                                textBoxFooter = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxFooter.Name = "txtfooter" + countPage;

                                //textBoxFooter.GenerateScript = textBoxFooter.Name + ".Value=\"Trang \" + PageNumber.ToString()+"+
                                //   "\"/"+ n+"\";";
                                pagefooter.Controls.Add(textBoxFooter);

                                textBoxFooter.Location =
                                    new Vector(12f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxFooter.Size =
                                    new Vector(8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                                DataBand dataBand = new DataBand();
                                dataBand.Name = "dataBand" + countPage;
                                page.Controls.Add(dataBand);
                                dataBand.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.3f).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                dataBand.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 15f).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                dataBand.DataSource = "F0102";

                                GroupBand grBand = new GroupBand();
                                dataBand.Controls.Add(grBand);
                                grBand.Name = "groupBandSalary" + countPage;
                                grBand.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                grBand.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 13.9f).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                grBand.GroupExpression = "1";

                                Header header1N = new Header();
                                grBand.Controls.Add(header1N);
                                header1N.Name = "header1N" + countPage;
                                header1N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header1N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 1.6).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header1N.StyleName = "HeaderFooter2Bold";
                                header1N.CanGrow = header1N.CanShrink = false;

                                Header header2N = new Header();
                                grBand.Controls.Add(header2N);
                                header2N.Name = "header2N" + countPage;
                                header2N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 2.4f).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header2N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 1.6).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header2N.StyleName = "HeaderFooter2Bold";
                                header2N.CanGrow = header2N.CanShrink = false;

                                Header header3N = new Header();
                                grBand.Controls.Add(header3N);
                                header3N.Name = "header3N" + countPage;
                                header3N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.3f).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header3N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 1.6).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header3N.StyleName = "HeaderFooter2Bold";
                                header3N.CanGrow = header3N.CanShrink = false;

                                Header header4N = new Header();
                                grBand.Controls.Add(header4N);
                                header4N.Name = "header4N" + countPage;
                                header4N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.3f).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header4N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 1.6).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header4N.StyleName = "HeaderFooter2Bold";
                                header4N.CanGrow = header4N.CanShrink = false;


                                GroupBand grBandMethod = new GroupBand();
                                grBand.Controls.Add(grBandMethod);
                                grBandMethod.Name = "groupBandMethod" + countPage;
                                grBandMethod.Location =
                                    new PerpetuumSoft.Framework.Drawing.Vector(0f, 5.1f).ConvertUnits(
                                        Unit.Centimeter,
                                        Unit.InternalUnit);
                                grBandMethod.Size =
                                    new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 7.8f).ConvertUnits(
                                        Unit.Centimeter,
                                        Unit.InternalUnit);
                                grBandMethod.GroupExpression = "1";

                                Header header5N = new Header();
                                grBandMethod.Controls.Add(header5N);
                                header5N.Name = "header5N" + countPage;
                                header5N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header5N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 0.5).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header5N.StyleName = "HeaderFooter2Bold";
                                header5N.CanGrow = header5N.CanShrink = false;

                                Header header6N = new Header();
                                grBandMethod.Controls.Add(header6N);
                                header6N.Name = "header6N" + countPage;
                                header6N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 1.3f).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header6N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 0.6).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                header6N.StyleName = "HeaderFooter2Bold";
                                header6N.CanGrow = header6N.CanShrink = false;

                                GroupBand grBandN = new GroupBand();
                                grBandMethod.Controls.Add(grBandN);
                                grBandN.Name = "groupBandN" + countPage;
                                grBandN.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 2.3f).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                grBandMethod.Size =
                                    new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 5.3f).ConvertUnits(
                                        Unit.Centimeter,
                                        Unit.InternalUnit);
                                grBandN.GroupExpression = "1";

                                Header headerGroupN = new Header();
                                grBandN.Controls.Add(headerGroupN);
                                headerGroupN.Name = "headerGroupN" + countPage;
                                headerGroupN.Location =
                                    new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(
                                        Unit.Centimeter,
                                        Unit.InternalUnit);
                                headerGroupN.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 1.8).ConvertUnits(
                                    Unit.Centimeter,
                                    Unit.InternalUnit);
                                headerGroupN.StyleName = "HeaderFooter2Bold";

                                Header headerSubGroupN = new Header();
                                grBandN.Controls.Add(headerSubGroupN);
                                headerSubGroupN.Name = "headerSubGroupN" + countPage;
                                headerSubGroupN.Location =
                                    new PerpetuumSoft.Framework.Drawing.Vector(0f, 2.6f).ConvertUnits(Unit.Centimeter,
                                        Unit.InternalUnit);
                                headerSubGroupN.Size =
                                    new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 0.6).ConvertUnits(
                                        Unit.Centimeter,
                                        Unit.InternalUnit);
                                headerSubGroupN.StyleName = "HeaderFooter2Bold";

                                Detail detailGroupN = new Detail();
                                detailGroupN.Name = "detailGroupN" + countPage;
                                grBandN.Controls.Add(detailGroupN);
                                detailGroupN.Location =
                                    new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.6f).ConvertUnits(
                                        Unit.Centimeter,
                                        Unit.InternalUnit);
                                detailGroupN.Size =
                                    new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 0.5f).ConvertUnits(
                                        Unit.Centimeter,
                                        Unit.InternalUnit);
                                detailGroupN.CanGrow = detailGroupN.CanShrink = true;
                                detailGroupN.StyleName = "DetailNormal";

                                #region Header

                                //Tạo cột STT
                                textBoxHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeaderN.Name = "txtNumber" + countPage;
                                textBoxHeaderN.Text = "STT";
                                headerGroupN.Controls.Add(textBoxHeaderN);
                                textBoxHeaderN.Location =
                                    new Vector(1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeaderN.Size =
                                    new Vector(0.8f, 1.8f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeaderN.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                                textBoxHeaderN.Border = oBorder;
                                textBoxHeaderN.Font = fontHead;

                                //Tạo cột Chỉ tiêu
                                textBoxHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeaderN.Name = "txtCT" + countPage;
                                textBoxHeaderN.Text = "Chỉ tiêu";
                                headerGroupN.Controls.Add(textBoxHeaderN);
                                textBoxHeaderN.Location =
                                    new Vector(1.8f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeaderN.Size =
                                    new Vector(8.3f, 1.8f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeaderN.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                                textBoxHeaderN.Border = oBorder;
                                textBoxHeaderN.Font = fontHead;

                                //Tạo cột mã số
                                textBoxHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeaderN.Name = "txtMS" + countPage;
                                textBoxHeaderN.Text = "Mã số";
                                headerGroupN.Controls.Add(textBoxHeaderN);
                                textBoxHeaderN.Location =
                                    new Vector(10.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeaderN.Size =
                                    new Vector(1f, 1.8f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeaderN.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                                textBoxHeaderN.Border = oBorder;
                                textBoxHeaderN.Font = fontHead;


                                //Tạo cột năm nay

                                textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeader2N.Name = "txtNamNay" + countPage;
                                textBoxHeader2N.Text = "Năm nay";
                                headerGroupN.Controls.Add(textBoxHeader2N);
                                textBoxHeader2N.Location =
                                    new Vector(11.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader2N.Size =
                                    new Vector(8.8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                                textBoxHeader2N.Border = oBorder;
                                textBoxHeader2N.Font = fontHead;

                                //Tạo cột lũy kế

                                textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeader2N.Name = "txtLuyKe" + countPage;
                                textBoxHeader2N.Text = "Lũy kế từ khi khởi đầu";
                                headerGroupN.Controls.Add(textBoxHeader2N);
                                textBoxHeader2N.Location =
                                    new Vector(19.9f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader2N.Size =
                                    new Vector(8.8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                                textBoxHeader2N.Border = oBorder;
                                textBoxHeader2N.Font = fontHead;




                                #endregion

                                #region Header3

                                //Tạo cột STT
                                textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeader3N.Name = "txtNumber3N" + countPage;
                                textBoxHeader3N.Text = "A";
                                headerSubGroupN.Controls.Add(textBoxHeader3N);
                                textBoxHeader3N.Location =
                                    new Vector(1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader3N.Size =
                                    new Vector(0.8f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeader3N.CanGrow =
                                    textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = true;
                                textBoxHeader3N.Border = oBorder;
                                textBoxHeader3N.Font = fontHead;

                                //Tạo cột Chỉ tiêu
                                textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeader3N.Name = "txtCT3N" + countPage;
                                textBoxHeader3N.Text = "B";
                                headerSubGroupN.Controls.Add(textBoxHeader3N);
                                textBoxHeader3N.Location =
                                    new Vector(1.8f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader3N.Size =
                                    new Vector(8.3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeader3N.CanGrow =
                                    textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = true;
                                textBoxHeader3N.Border = oBorder;
                                textBoxHeader3N.Font = fontHead;

                                //Tạo cột mã số
                                textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeader3N.Name = "txtMS3N" + countPage;
                                textBoxHeader3N.Text = "C";
                                headerSubGroupN.Controls.Add(textBoxHeader3N);
                                textBoxHeader3N.Location =
                                    new Vector(10.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader3N.Size =
                                    new Vector(1f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeader3N.CanGrow =
                                    textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = true;
                                textBoxHeader3N.Border = oBorder;
                                textBoxHeader3N.Font = fontHead;

                                #endregion

                                #region Detail

                                //Tạo cột STT
                                textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxDetailN.Name = "txtdetailNumber1" + countPage;
                                textBoxDetailN.Text = "";
                                detailGroupN.Controls.Add(textBoxDetailN);
                                textBoxDetailN.Location =
                                    new Vector(1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxDetailN.Size =
                                    new Vector(0.8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                                textBoxDetailN.Border = oBorder;

                                //Tạo cột Chỉ tiêu
                                textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxDetailN.Name = "txtDetailTargets" + countPage;
                                textBoxDetailN.Text = "";
                                detailGroupN.Controls.Add(textBoxDetailN);
                                textBoxDetailN.Location =
                                    new Vector(1.8f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxDetailN.Size =
                                    new Vector(8.3f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                                textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                                textBoxDetailN.Border = oBorder;


                                //Tạo cột mã số
                                textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxDetailN.Name = "txtDetailMS" + countPage;
                                textBoxDetailN.Text = "";
                                detailGroupN.Controls.Add(textBoxDetailN);
                                textBoxDetailN.Location =
                                    new Vector(10.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxDetailN.Size =
                                    new Vector(1f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                                textBoxDetailN.Border = oBorder;


                                detailGroupN.GenerateScript =
                                    "txtDetailTargets" + countPage +
                                    ".Text = GetData(\"ReportItemName\").ToString(); " +
                                    "txtdetailNumber1" + countPage +
                                    ".Text= GetData(\"ReportItemAlias\").ToString(); " +
                                    "txtDetailMS" + countPage + ".Text = GetData(\"ReportItemCode\").ToString(); " +
                                    "if(GetData(\"IsBold\").ToString()==\"1\") " +
                                    "{ txtDetailTargets" + countPage +
                                    ".StyleName =  \"DetailNormalBold\";  txtdetailNumber1" + countPage +
                                    ".StyleName =  \"DetailNormalBold\";  txtDetailMS" + countPage +
                                    ".StyleName =  \"DetailNormalBold\";}"
                                    + "else { txtDetailTargets" + countPage +
                                    ".StyleName =  \"DetailNormal\"; txtdetailNumber1" + countPage +
                                    ".StyleName =  \"DetailNormal\";  txtDetailMS" + countPage +
                                    ".StyleName =  \"DetailNormal\";  }";


                                #endregion

                                #region Tạo cột tổng số của mục năm nay và lũy kế 



                                //năm nay

                                textBoxHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeaderN.Name = "txtHead" + columnTotalThisYearName + countPage;
                                textBoxHeaderN.Text = "Tổng số";
                                headerGroupN.Controls.Add(textBoxHeaderN);
                                textBoxHeaderN.Location =
                                    new Vector(11.1f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeaderN.Size =
                                    new Vector(2.2f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeaderN.CanGrow = textBoxHeaderN.CanShrink = textBoxHeaderN.GrowToBottom = true;
                                textBoxHeaderN.Border = oBorder;

                                textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeader3N.Name = "txt3" + columnTotalThisYearName + countPage;
                                textBoxHeader3N.Text = "";
                                headerSubGroupN.Controls.Add(textBoxHeader3N);
                                textBoxHeader3N.Location =
                                    new Vector(11.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader3N.Size =
                                    new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeader3N.CanGrow =
                                    textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = true;
                                textBoxHeader3N.Border = oBorder;

                                textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxDetailN.Name = "txtDetail" + columnTotalThisYearName + countPage;
                                textBoxDetailN.Text = "";
                                detailGroupN.Controls.Add(textBoxDetailN);
                                textBoxDetailN.Location =
                                    new Vector(11.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxDetailN.Size =
                                    new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                                textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                                textBoxDetailN.Border = oBorder;

                                if (!columnTotalThisYearName.Contains("TotalThisYear"))
                                {
                                    textBoxDetailN.GenerateScript = textBoxDetailN.Name + ".Value=GetData(\"" +
                                                                    dtThisYear.Rows[0]["PayrollItemColumnID"] +
                                                                    "\").ToString(); "
                                                                    + textBoxDetailN.Name + ".TextFormat = "
                                                                    + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");";
                                }

                                //lũy kế
                                textBoxHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeaderN.Name = "txtHead" + columnTotalAccumulatedName + countPage;
                                textBoxHeaderN.Text = "Tổng số";
                                headerGroupN.Controls.Add(textBoxHeaderN);
                                textBoxHeaderN.Location =
                                    new Vector(19.9f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeaderN.Size =
                                    new Vector(2.2f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeaderN.CanGrow = textBoxHeaderN.CanShrink = textBoxHeaderN.GrowToBottom = true;
                                textBoxHeaderN.Border = oBorder;
                                textBoxHeaderN.Font = fontHead;


                                textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxHeader3N.Name = "txt3" + columnTotalAccumulatedName + countPage;
                                textBoxHeader3N.Text = "";
                                headerSubGroupN.Controls.Add(textBoxHeader3N);
                                textBoxHeader3N.Location =
                                    new Vector(19.9f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader3N.Size =
                                    new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                textBoxHeader3N.CanGrow =
                                    textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = true;
                                textBoxHeader3N.Border = oBorder;
                                textBoxHeader3N.Font = fontHead;


                                textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                textBoxDetailN.Name = "txtDetail" + columnTotalAccumulatedName + countPage;
                                textBoxDetailN.Text = "";
                                detailGroupN.Controls.Add(textBoxDetailN);
                                textBoxDetailN.Location =
                                    new Vector(19.9f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxDetailN.Size =
                                    new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                                textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                                textBoxDetailN.Border = oBorder;

                                if (!columnTotalAccumulatedName.Contains("TotalAccumulated"))
                                {
                                    textBoxDetailN.GenerateScript = textBoxDetailN.Name + ".Value=GetData(\"" +
                                                                    dtAccumulated.Rows[0]["PayrollItemColumnID"] +
                                                                    "\").ToString(); "
                                                                    + textBoxDetailN.Name + ".TextFormat = "
                                                                    + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");";
                                }

                                #endregion

                                #endregion

                            }


                        #endregion

                    }
                    else
                    {
                        #region tạo cột cố định 

                        PerpetuumSoft.Reporting.DOM.TextBox textBoxHeaderN =
                            new PerpetuumSoft.Reporting.DOM.TextBox();
                        PerpetuumSoft.Reporting.DOM.TextBox textBoxHeaderDynamicN =
                            new PerpetuumSoft.Reporting.DOM.TextBox();
                        PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader2N =
                            new PerpetuumSoft.Reporting.DOM.TextBox();
                        PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader3N =
                            new PerpetuumSoft.Reporting.DOM.TextBox();
                        PerpetuumSoft.Reporting.DOM.TextBox textBoxDetailN =
                            new PerpetuumSoft.Reporting.DOM.TextBox();
                        PerpetuumSoft.Reporting.DOM.TextBox textBoxFooter =
                            new PerpetuumSoft.Reporting.DOM.TextBox();

                        Page page = new Page();
                        page.Name = "page" + countPage + p;
                        page.Margins = new Margins(1f, 1f, 1f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        page.Orientation = PageOrientation.Landscape;
                        page.GenerateScript = "iPageNumber=0;";
                        doc.Pages.Add(page);



                        PageHeader pageHeader = new PageHeader();
                        pageHeader.Name = "pageHeader" + countPage + p;
                        pageHeader.Location =
                            new Vector(0f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        pageHeader.Size =
                            new Vector(29.7f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        
                        page.Controls.Add(pageHeader);

                        PageFooter pagefooterN = new PageFooter();
                        pagefooterN.Name = "pagefooter" + countPage;

                        pagefooterN.Location = pageFooter.Location;
                        pagefooterN.Size = pageFooter.Size;
                        pagefooterN.Mode = pageFooter.Mode;
                        pagefooterN.CanGrow = pageFooter.CanGrow;
                        pagefooterN.CanShrink = pageFooter.CanShrink;
                       
                        page.Controls.Add(pagefooterN);

                        textBoxFooter = new PerpetuumSoft.Reporting.DOM.TextBox();



                        textBoxFooter.Size = new Vector(9.4f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxFooter.Location = new Vector(19.3f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxFooter.Name = "txtLabelN" + countPage;
                        textBoxFooter.Font = new FontDescriptor("Times New Roman", 9.75f);
                        textBoxFooter.TextAlign = ContentAlignment.MiddleRight;
                        textBoxFooter.GenerateScript = textBoxFooter.Name + ".Value =\"Trang " + (p + 1) + "/ " + "\"" + "+(PageNumber -(iLineNumber*" + p + ")).ToString();";

                        //textBoxFooter.GenerateScript = textBoxFooter.Name + ".Value=\"Trang \" + PageNumber.ToString()+"+
                        //   "\"/"+ n+"\";";
                        pagefooterN.Controls.Add(textBoxFooter);

                        textBoxFooter.Location =
                            new Vector(12f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxFooter.Size =
                            new Vector(8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                        DataBand dataBand = new DataBand();
                        dataBand.Name = "dataBand" + countPage + p;
                        page.Controls.Add(dataBand);
                        dataBand.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.3f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        dataBand.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 15f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        dataBand.DataSource = "F0102";

                        GroupBand grBand = new GroupBand();
                        dataBand.Controls.Add(grBand);
                        grBand.Name = "groupBandSalary" + countPage + p;
                        grBand.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        grBand.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 13.9f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        grBand.GroupExpression = "GetData(\"BudgetChapterCode\").ToString() + GetData(\"ProjectCode\").ToString();";

                        Header header1N = new Header();
                        grBand.Controls.Add(header1N);
                        header1N.Name = "header1N" + countPage + p;
                        header1N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header1N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 1.6).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header1N.StyleName = "HeaderFooter2Bold";
                        header1N.CanGrow = header1N.CanShrink = false;
                        header1N.NewPageBefore = true;

                        Header header2N = new Header();
                        grBand.Controls.Add(header2N);
                        header2N.Name = "header2N" + countPage + p;
                        header2N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 2.4f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header2N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 2f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header2N.StyleName = "HeaderFooter2Bold";
                        header2N.CanGrow = header2N.CanShrink = false;

                        Header header3N = new Header();
                        grBand.Controls.Add(header3N);
                        header3N.Name = "header3N" + countPage + p;
                        header3N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.3f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header3N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 1.6).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header3N.StyleName = "HeaderFooter2Bold";
                        header3N.CanGrow = header3N.CanShrink = false;

                        Header header4N = new Header();
                        grBand.Controls.Add(header4N);
                        header4N.Name = "header4N" + countPage + p;
                        header4N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.3f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header4N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 1.6).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header4N.StyleName = "HeaderFooter2Bold";
                        header4N.CanGrow = header4N.CanShrink = false;


                        GroupBand grBandMethod = new GroupBand();
                        grBand.Controls.Add(grBandMethod);
                        grBandMethod.Name = "groupBandMethod" + countPage + p;
                        grBandMethod.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(0f, 5.1f).ConvertUnits(
                                Unit.Centimeter,
                                Unit.InternalUnit);
                        grBandMethod.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 7.8f).ConvertUnits(
                                Unit.Centimeter,
                                Unit.InternalUnit);
                        grBandMethod.GroupExpression = "1";

                        Header header5N = new Header();
                        grBandMethod.Controls.Add(header5N);
                        header5N.Name = "header5N" + countPage + p;
                        header5N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header5N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 0.5).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header5N.StyleName = "HeaderFooter2Bold";
                        header5N.CanGrow = header5N.CanShrink = false;

                        Header header6N = new Header();
                        grBandMethod.Controls.Add(header6N);
                        header6N.Name = "header6N" + countPage + p;
                        header6N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 1.3f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header6N.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 0.6).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        header6N.StyleName = "HeaderFooter2Bold";
                        header6N.CanGrow = header6N.CanShrink = false;

                        GroupBand grBandN = new GroupBand();
                        grBandMethod.Controls.Add(grBandN);
                        grBandN.Name = "groupBandN" + countPage + p;
                        grBandN.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 2.3f).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        grBandMethod.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 5.3f).ConvertUnits(
                                Unit.Centimeter,
                                Unit.InternalUnit);
                        grBandN.GroupExpression = "1";

                        Header headerGroupN = new Header();
                        grBandN.Controls.Add(headerGroupN);
                        headerGroupN.Name = "headerGroupN" + countPage + p;
                        headerGroupN.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(
                                Unit.Centimeter,
                                Unit.InternalUnit);
                        headerGroupN.Size = new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 1.8).ConvertUnits(
                            Unit.Centimeter,
                            Unit.InternalUnit);
                        headerGroupN.StyleName = "HeaderFooter2Bold";
                        headerGroupN.RepeatEveryPage = true;
                        Header headerSubGroupN = new Header();
                        grBandN.Controls.Add(headerSubGroupN);
                        headerSubGroupN.Name = "headerSubGroupN" + countPage + p;
                        headerSubGroupN.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(0f, 2.6f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        headerSubGroupN.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 0.6).ConvertUnits(
                                Unit.Centimeter,
                                Unit.InternalUnit);
                        headerSubGroupN.StyleName = "HeaderFooter2Bold";
                        headerSubGroupN.RepeatEveryPage = true;
                        Detail detailGroupN = new Detail();
                        detailGroupN.Name = "detailGroupN" + countPage + p;
                        grBandN.Controls.Add(detailGroupN);
                        detailGroupN.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.6f).ConvertUnits(
                                Unit.Centimeter,
                                Unit.InternalUnit);
                        detailGroupN.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(29.7f, 0.5f).ConvertUnits(
                                Unit.Centimeter,
                                Unit.InternalUnit);
                        detailGroupN.CanGrow = detailGroupN.CanShrink = true;
                        detailGroupN.StyleName = "DetailNormal";

                        #region Header

                        //Tạo cột STT
                        textBoxHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeaderN.Name = "txtNumber" + countPage + p;
                        textBoxHeaderN.Text = "STT";
                        headerGroupN.Controls.Add(textBoxHeaderN);
                        textBoxHeaderN.Location =
                            new Vector(1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeaderN.Size =
                            new Vector(0.8f, 1.8f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeaderN.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = false;
                        textBoxHeaderN.Border = oBorder;
                        textBoxHeaderN.Font = fontHead;

                        //Tạo cột Chỉ tiêu
                        textBoxHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeaderN.Name = "txtCT" + countPage;
                        textBoxHeaderN.Text = "Chỉ tiêu";
                        headerGroupN.Controls.Add(textBoxHeaderN);
                        textBoxHeaderN.Location =
                            new Vector(1.8f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeaderN.Size =
                            new Vector(8.3f, 1.8f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeaderN.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = false;
                        textBoxHeaderN.Border = oBorder;
                        textBoxHeaderN.Font = fontHead;

                        //Tạo cột mã số
                        textBoxHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeaderN.Name = "txtMS" + countPage + p;
                        textBoxHeaderN.Text = "Mã số";
                        headerGroupN.Controls.Add(textBoxHeaderN);
                        textBoxHeaderN.Location =
                            new Vector(10.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeaderN.Size =
                            new Vector(1f, 1.8f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeaderN.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = false;
                        textBoxHeaderN.Border = oBorder;
                        textBoxHeaderN.Font = fontHead;


                        //Tạo cột năm nay

                        textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader2N.Name = "txtNamNay" + countPage + p;
                        textBoxHeader2N.Text = "Năm nay";
                        headerGroupN.Controls.Add(textBoxHeader2N);
                        textBoxHeader2N.Location =
                            new Vector(11.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2N.Size =
                            new Vector(8.8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = false;
                        textBoxHeader2N.Border = oBorder;
                        textBoxHeader2N.Font = fontHead;

                        //Tạo cột lũy kế

                        textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader2N.Name = "txtLuyKe" + countPage + p;
                        textBoxHeader2N.Text = "Lũy kế từ khi khởi đầu";
                        headerGroupN.Controls.Add(textBoxHeader2N);
                        textBoxHeader2N.Location =
                            new Vector(19.9f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2N.Size =
                            new Vector(8.8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = false;
                        textBoxHeader2N.Border = oBorder;
                        textBoxHeader2N.Font = fontHead;




                        #endregion

                        #region Header3

                        //Tạo cột STT
                        textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader3N.Name = "txtNumber3N" + countPage + p;
                        textBoxHeader3N.Text = "A";
                        headerSubGroupN.Controls.Add(textBoxHeader3N);
                        textBoxHeader3N.Location =
                            new Vector(1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.Size =
                            new Vector(0.8f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader3N.CanGrow =
                            textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = false;
                        textBoxHeader3N.Border = oBorder;
                        textBoxHeader3N.Font = fontHead;

                        //Tạo cột Chỉ tiêu
                        textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader3N.Name = "txtCT3N" + countPage + p;
                        textBoxHeader3N.Text = "B";
                        headerSubGroupN.Controls.Add(textBoxHeader3N);
                        textBoxHeader3N.Location =
                            new Vector(1.8f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.Size =
                            new Vector(8.3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader3N.CanGrow =
                            textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = false;
                        textBoxHeader3N.Border = oBorder;
                        textBoxHeader3N.Font = fontHead;

                        //Tạo cột mã số
                        textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader3N.Name = "txtMS3N" + countPage + p;
                        textBoxHeader3N.Text = "C";
                        headerSubGroupN.Controls.Add(textBoxHeader3N);
                        textBoxHeader3N.Location =
                            new Vector(10.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.Size =
                            new Vector(1f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader3N.CanGrow =
                            textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = false;
                        textBoxHeader3N.Border = oBorder;
                        textBoxHeader3N.Font = fontHead;

                        #endregion

                        #region Detail

                        //Tạo cột STT
                        textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxDetailN.Name = "txtdetailNumber1" + countPage + p;
                        textBoxDetailN.Text = "";
                        detailGroupN.Controls.Add(textBoxDetailN);
                        textBoxDetailN.Location =
                            new Vector(1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxDetailN.Size =
                            new Vector(0.8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                        textBoxDetailN.Border = oBorder;

                        //Tạo cột Chỉ tiêu
                        textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxDetailN.Name = "txtDetailTargets" + countPage + p;
                        textBoxDetailN.Text = "";
                        detailGroupN.Controls.Add(textBoxDetailN);
                        textBoxDetailN.Location =
                            new Vector(1.8f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxDetailN.Size =
                            new Vector(8.3f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                        textBoxDetailN.Border = oBorder;


                        //Tạo cột mã số
                        textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxDetailN.Name = "txtDetailMS" + countPage + p;
                        textBoxDetailN.Text = "";
                        detailGroupN.Controls.Add(textBoxDetailN);
                        textBoxDetailN.Location =
                            new Vector(10.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxDetailN.Size =
                            new Vector(1f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                        textBoxDetailN.Border = oBorder;


                        detailGroupN.GenerateScript =
                            "txtDetailTargets" + countPage + p +
                            ".Text = GetData(\"ReportItemName\").ToString(); " +
                            "txtdetailNumber1" + countPage + p +
                            ".Text= GetData(\"ReportItemAlias\").ToString(); " +
                            "txtDetailMS" + countPage + p + ".Text = GetData(\"ReportItemCode\").ToString(); " +
                            "if(GetData(\"IsBold\").ToString()==\"1\") " +
                            "{ txtDetailTargets" + countPage + p +
                            ".StyleName =  \"DetailNormalBold\";  txtdetailNumber1" + countPage + p +
                            ".StyleName =  \"DetailNormalBold\";  txtDetailMS" + countPage + p +
                            ".StyleName =  \"DetailNormalBold\";}"
                            + "else { txtDetailTargets" + countPage + p +
                            ".StyleName =  \"DetailNormal\"; txtdetailNumber1" + countPage + p +
                            ".StyleName =  \"DetailNormal\";  txtDetailMS" + countPage + p +
                            ".StyleName =  \"DetailNormal\";  }";


                        #endregion

                        #region Tạo cột tổng số của mục năm nay và lũy kế 



                        //năm nay

                        textBoxHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeaderN.Name = "txtHead" + columnTotalThisYearName + countPage + p;
                        textBoxHeaderN.Text = "Tổng số";
                        headerGroupN.Controls.Add(textBoxHeaderN);
                        textBoxHeaderN.Location =
                            new Vector(11.1f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeaderN.Size =
                            new Vector(2.2f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeaderN.CanGrow = textBoxHeaderN.CanShrink = textBoxHeaderN.GrowToBottom = false;
                        textBoxHeaderN.Border = oBorder;

                        textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader3N.Name = "txt3" + columnTotalThisYearName + countPage + p;
                        textBoxHeader3N.Text = "";
                        headerSubGroupN.Controls.Add(textBoxHeader3N);
                        textBoxHeader3N.Location =
                            new Vector(11.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.Size =
                            new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader3N.CanGrow =
                            textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = false;
                        textBoxHeader3N.Border = oBorder;

                        textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxDetailN.Name = "txtDetail" + columnTotalThisYearName + countPage + p;
                        textBoxDetailN.Text = "";
                        detailGroupN.Controls.Add(textBoxDetailN);
                        textBoxDetailN.Location =
                            new Vector(11.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxDetailN.Size =
                            new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                        textBoxDetailN.Border = oBorder;

                        if (!columnTotalThisYearName.Contains("TotalThisYear"))
                        {
                            textBoxDetailN.GenerateScript = textBoxDetailN.Name + ".Value=GetData(\"" +
                                                            dtThisYear.Rows[0]["PayrollItemColumnID"] +
                                                            "\").ToString(); "
                                                            + textBoxDetailN.Name + ".TextFormat = "
                                                            + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");";
                        }

                        //lũy kế
                        textBoxHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeaderN.Name = "txtHead" + columnTotalAccumulatedName + countPage + p;
                        textBoxHeaderN.Text = "Tổng số";
                        headerGroupN.Controls.Add(textBoxHeaderN);
                        textBoxHeaderN.Location =
                            new Vector(19.9f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeaderN.Size =
                            new Vector(2.2f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeaderN.CanGrow = textBoxHeaderN.CanShrink = textBoxHeaderN.GrowToBottom = false;
                        textBoxHeaderN.Border = oBorder;
                        textBoxHeaderN.Font = fontHead;


                        textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader3N.Name = "txt3" + columnTotalAccumulatedName + countPage + p;
                        textBoxHeader3N.Text = "";
                        headerSubGroupN.Controls.Add(textBoxHeader3N);
                        textBoxHeader3N.Location =
                            new Vector(19.9f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.Size =
                            new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader3N.CanGrow =
                            textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = false;
                        textBoxHeader3N.Border = oBorder;
                        textBoxHeader3N.Font = fontHead;


                        textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxDetailN.Name = "txtDetail" + columnTotalAccumulatedName + countPage + p;
                        textBoxDetailN.Text = "";
                        detailGroupN.Controls.Add(textBoxDetailN);
                        textBoxDetailN.Location =
                            new Vector(19.9f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxDetailN.Size =
                            new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                        textBoxDetailN.Border = oBorder;

                        if (!columnTotalAccumulatedName.Contains("TotalAccumulated"))
                        {
                            textBoxDetailN.GenerateScript = textBoxDetailN.Name + ".Value=GetData(\"" +
                                                            dtAccumulated.Rows[0]["PayrollItemColumnID"] +
                                                            "\").ToString(); "
                                                            + textBoxDetailN.Name + ".TextFormat = "
                                                            + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");";
                        }

                        #endregion

                        #endregion

                        //tạo template loại
                        textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader2N.Name =
                            "txtThisYear" + dtThisYearBudget.Rows[p]["PayrollItemColumnID"].ToString() + p;
                        textBoxHeader2N.Text = dtThisYearBudget.Rows[p]["TitleColumn"].ToString();
                        headerGroupN.Controls.Add(textBoxHeader2N);
                        textBoxHeader2N.Location =
                            new Vector(13.3f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2N.Size = new Vector(6.6f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader2N.CanShrink = textBoxHeader2N.GrowToBottom = false;
                        textBoxHeader2N.Border = oBorder;
                        textBoxHeader2N.Font = fontHead;

                        textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader2N.Name =
                            "txtAccumulated" + dtThisYearBudget.Rows[p]["PayrollItemColumnID"].ToString() + p;
                        textBoxHeader2N.Text = dtThisYearBudget.Rows[p]["TitleColumn"].ToString();
                        headerGroupN.Controls.Add(textBoxHeader2N);
                        textBoxHeader2N.Location =
                            new Vector(22.1f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2N.Size = new Vector(6.6f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader2N.CanShrink = textBoxHeader2N.GrowToBottom = false;
                        textBoxHeader2N.Border = oBorder;
                        textBoxHeader2N.Font = fontHead;


                        DataTable dtResult = dtSource
                            .Select("ParentID ='" + dtThisYearBudget.Rows[p]["PayrollItemColumnID"].ToString() + "'")
                            .CopyToDataTable();

                        DataTable dtResultFist = dtResult.Select().Skip(0).Take(3).CopyToDataTable();

                        int countSubKind = dtResult.Rows.Count;

                        int surPlusSubKind = (countSubKind) % 3;
                        int pageIndexSubkind = (countSubKind) / 3;
                        if (surPlusSubKind > 0) pageIndexSubkind = pageIndexSubkind + 1;
                        //else pageIndexSubkind = pageIndexSubkind + 1;

                        //tạo trang đầu tiên của khoản

                        double margin = 0;
                        int countColumn = 0;
                        foreach (DataRow dr in dtResultFist.Rows)
                        {
                            #region

                            //năm nay
                            textBoxHeaderDynamicN = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeaderDynamicN.Name = "txtThisYear" + dr["PayrollItemColumnID"]+countPage;
                            textBoxHeaderDynamicN.Text = dr["TitleColumn"].ToString();
                            headerGroupN.Controls.Add(textBoxHeaderDynamicN);
                            textBoxHeaderDynamicN.Location =
                                new Vector(13.3f + margin, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamicN.Size =
                                new Vector(2.2f, 0.7f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamicN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeaderDynamicN.CanGrow =
                                textBoxHeaderDynamicN.CanShrink = textBoxHeaderDynamicN.GrowToBottom = false;
                            textBoxHeaderDynamicN.Border = oBorder;
                            textBoxHeaderDynamicN.Font = fontHead;

                            textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeader3N.Name = "txt3ThisYear" + dr["PayrollItemColumnID"]+countPage;
                            textBoxHeader3N.Text = "";
                            headerSubGroupN.Controls.Add(textBoxHeader3N);
                            textBoxHeader3N.Location =
                                new Vector(13.3f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3N.Size =
                                new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeader3N.CanGrow = textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = false;
                            textBoxHeader3N.Border = oBorder;
                            textBoxHeader3N.Font = fontHead;

                            textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxDetailN.Name = "txtDetailThisYear" + dr["PayrollItemColumnID"] + countPage;
                            textBoxDetailN.Text = "";
                            detailGroupN.Controls.Add(textBoxDetailN);
                            textBoxDetailN.Location =
                                new Vector(13.3f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetailN.Size =
                                new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                            textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                            textBoxDetailN.Border = oBorder;
                            textBoxDetailN.GenerateScript = textBoxDetailN.Name + ".Value= decimal.Parse(GetData(\"" +
                                                           dr["PayrollItemColumnID"] + "\").ToString())==0 ?(object)null: " +
                                                           "decimal.Parse(GetData(\""
                                                           + dr["PayrollItemColumnID"] + "\").ToString());"
                                                           + textBoxDetailN.Name + ".TextFormat = "
                                                           + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");"
                                                           + "if (GetData(\"IsBold\").ToString()==\"True\"){" +
                                                           textBoxDetailN.Name + ".Font =detaiBold;} else{" +
                                                           textBoxDetailN.Name + ".Font =detaiNormal;}";

                            //lũy kế

                            DataRow drAcc = dtSource
                                .Select("ParentID like '2%' AND  BudgetSourceCode <> 'SUM_Part' AND TitleColumn = '" +
                                        dr["TitleColumn"].ToString() + "'").FirstOrDefault();

                            textBoxHeaderDynamicN = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeaderDynamicN.Name = "txtAccumulated" + drAcc["PayrollItemColumnID"] + countPage;
                            textBoxHeaderDynamicN.Text = drAcc["TitleColumn"].ToString();
                            headerGroupN.Controls.Add(textBoxHeaderDynamicN);
                            textBoxHeaderDynamicN.Location =
                                new Vector(22.1f + margin, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamicN.Size =
                                new Vector(2.2f, 0.7f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamicN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeaderDynamicN.CanGrow =
                                textBoxHeaderDynamicN.CanShrink = textBoxHeaderDynamicN.GrowToBottom = false;
                            textBoxHeaderDynamicN.Border = oBorder;
                            textBoxHeaderDynamicN.Font = fontHead;

                            textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeader3N.Name = "txt3Accumulated" + drAcc["PayrollItemColumnID"] + countPage;
                            textBoxHeader3N.Text = "";
                            headerSubGroupN.Controls.Add(textBoxHeader3N);
                            textBoxHeader3N.Location =
                                new Vector(22.1f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3N.Size =
                                new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeader3N.CanGrow = textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = false;
                            textBoxHeader3N.Border = oBorder;
                            textBoxHeader3N.Font = fontHead;

                            textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxDetailN.Name = "txtDetailAccumulated" + drAcc["PayrollItemColumnID"] + countPage;
                            textBoxDetailN.Text = "";
                            detailGroupN.Controls.Add(textBoxDetailN);
                            textBoxDetailN.Location =
                                new Vector(22.1f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetailN.Size =
                                new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                            textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                            textBoxDetailN.Border = oBorder;
                            textBoxDetailN.TextAlign = ContentAlignment.MiddleRight;
                            textBoxDetailN.GenerateScript = textBoxDetailN.Name + ".Value= decimal.Parse(GetData(\"" +
                                                           drAcc["PayrollItemColumnID"] + "\").ToString()) ==0 ?(object)null: "
                                                           + "decimal.Parse(GetData(\"" +
                                                           drAcc["PayrollItemColumnID"] + "\").ToString()); "
                                                           + textBoxDetailN.Name + ".TextFormat = "
                                                           + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");"
                                                           + "if (GetData(\"IsBold\").ToString()==\"True\"){" +
                                                           textBoxDetailN.Name + ".Font =detaiBold;} else{" +
                                                           textBoxDetailN.Name + ".Font =detaiNormal;}";

                            countColumn = countColumn + 1;
                            margin = margin + 2.2f;

                        }

                        #endregion tạo cột cố định

                        for (int i = countColumn; i < 3; i++)
                        {
                            #region

                            //năm nay
                            textBoxHeaderDynamicN = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeaderDynamicN.Name = "txtThisYearEx" + i;
                            textBoxHeaderDynamicN.Text = "";
                            headerGroupN.Controls.Add(textBoxHeaderDynamicN);
                            textBoxHeaderDynamicN.Location =
                                new Vector(13.3f + margin, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamicN.Size =
                                new Vector(2.2f, 0.7f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamicN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeaderDynamicN.CanGrow =
                                textBoxHeaderDynamicN.CanShrink = textBoxHeaderDynamicN.GrowToBottom = true;
                            textBoxHeaderDynamicN.Border = oBorder;


                            textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeader3N.Name = "txt3ThisYearEx" + i;
                            textBoxHeader3N.Text = "";
                            headerSubGroupN.Controls.Add(textBoxHeader3N);
                            textBoxHeader3N.Location =
                                new Vector(13.3f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3N.Size =
                                new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeader3N.CanGrow = textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = true;
                            textBoxHeader3N.Border = oBorder;

                            textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxDetailN.Name = "txtDetailThisYearEx" + i;
                            textBoxDetailN.Text = "";
                            detailGroupN.Controls.Add(textBoxDetailN);
                            textBoxDetailN.Location =
                                new Vector(13.3f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetailN.Size =
                                new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                            textBoxDetailN.Border = oBorder;


                            //lũy kế

                            textBoxHeaderDynamicN = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeaderDynamicN.Name = "txtAccumulatedEx" + i;
                            textBoxHeaderDynamicN.Text = "";
                            headerGroupN.Controls.Add(textBoxHeaderDynamicN);
                            textBoxHeaderDynamicN.Location =
                                new Vector(22.1f + margin, 1.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamicN.Size =
                                new Vector(2.2f, 0.7f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeaderDynamicN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeaderDynamicN.CanGrow =
                                textBoxHeaderDynamicN.CanShrink = textBoxHeaderDynamicN.GrowToBottom = true;
                            textBoxHeaderDynamicN.Border = oBorder;


                            textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxHeader3N.Name = "txt3AccumulatedEx" + i;
                            textBoxHeader3N.Text = "";
                            headerSubGroupN.Controls.Add(textBoxHeader3N);
                            textBoxHeader3N.Location =
                                new Vector(22.1f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3N.Size =
                                new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxHeader3N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxHeader3N.CanGrow = textBoxHeader3N.CanShrink = textBoxHeader3N.GrowToBottom = true;
                            textBoxHeader3N.Border = oBorder;

                            textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textBoxDetailN.Name = "txtDetailAccumulatedEx" + i;
                            textBoxDetailN.Text = "";
                            detailGroupN.Controls.Add(textBoxDetailN);
                            textBoxDetailN.Location =
                                new Vector(22.1f + margin, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetailN.Size =
                                new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textBoxDetailN.CanGrow = textBoxDetailN.CanShrink = textBoxDetailN.GrowToBottom = true;
                            textBoxDetailN.Border = oBorder;
                            margin = margin + 2.2f;

                            #endregion
                        }

                        countPage = countPage + 1;
                    }


                }

            #endregion
            reportSlot.SaveReport(doc);
            //reportSlot.DesignTemplate();
            return true;

        }
        /// <summary>
        ///     Gets the report B01 BCQT.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<Object> GetReportB01BCQT(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<object> list = new List<object>();
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var currencyPrefix = Model.GetCurrencyByCurrencyCode(currencyCode).Prefix ?? "";

            if (!oRsTool.IsRefresh)
                using (var frmParam = new FrmB01BCQT())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startdate = DateTime.Parse(frmParam.StartDate);
                        var budgetSource = frmParam.BudgetSourceCode;
                        var budgetChapter = frmParam.BudgetChapterCode;
                        var budgetSubKindItem = frmParam.BudgetSubKindItemCode;
                        var isSummaryBudgetSource = frmParam.IsSummaryBudgetSource;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var budgetKindItemCode = budgetSubKindItem;
                        if (isSummaryBudgetSubKindItem)
                            budgetKindItemCode = "<<Tổng hợp>>";
                        if (!oRsTool.Parameters.ContainsKey("BudgetKindItem"))
                            oRsTool.Parameters.Add("BudgetKindItem", budgetKindItemCode);
                        var budgetKindItem = Model.GetBudgetKindItemsByCodeIncludeParentCode(budgetKindItemCode);
                        var budgetKindItemParentCode = "Loại";
                        if (budgetKindItem != null && !string.IsNullOrEmpty(budgetKindItem.ParentId))
                            budgetKindItemParentCode = budgetKindItem.ParentId;
                        if (!oRsTool.Parameters.ContainsKey("BudgetKindItemParent"))
                            oRsTool.Parameters.Add("BudgetKindItemParent", budgetKindItemParentCode);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemDay"))
                            oRsTool.Parameters.Add("DateSystemDay", DateTime.Today.Day);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemMonth"))
                            oRsTool.Parameters.Add("DateSystemMonth", DateTime.Today.Month);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemYear"))
                            oRsTool.Parameters.Add("DateSystemYear", DateTime.Today.Year);
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("CompanyCode"))
                            oRsTool.Parameters.Add("CompanyCode", string.IsNullOrEmpty(GlobalVariable.CompanyCode) ? string.Empty : GlobalVariable.CompanyCode);
                        if (!oRsTool.Parameters.ContainsKey("ReportSubTitle"))
                            oRsTool.Parameters.Add("ReportSubTitle", ConvertDateToStringForReport(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate)));
                        if (!oRsTool.Parameters.ContainsKey("CurrencyPrefix"))
                            oRsTool.Parameters.Add("CurrencyPrefix", currencyPrefix);
                        DataSet ds = Model.GetReportB01BCQT(startdate, fromDate, toDate, budgetSource, budgetChapter,
                            budgetSubKindItem, isSummaryBudgetSource, isSummaryBudgetChapter,
                            isSummaryBudgetSubKindItem, amountType, currencyCode );
                        if (ds.Tables.Count < 2 || ds.Tables[0].Rows.Count < 1)
                        {
                            return list;
                        }
                        //Render Report Template
                       var result= RenderDynamicReportMultiPage(ds.Tables[1], "01_BCQT.rst",1);
                        if (result == false)
                        {
                            return null;
                        }
                        //Convert DataTable to List
                        if (ds.Tables.Count == 2 && result == true)
                        {
                            Dictionary<string, Type> fieldList = new Dictionary<string, Type>();

                            foreach (DataColumn dtCol in ds.Tables[0].Columns)
                            {
                                fieldList.Add(dtCol.ColumnName, dtCol.DataType);
                            }

                            fieldList.Add("Details", typeof(List<object>));


                            Dictionary<string, string> details = new Dictionary<string, string>();
                            int i = 0;

                            foreach (DataRow dtRow in ds.Tables[0].Rows)
                            {
                                object dynamicObj = DynamicObject.DynamicObject.CreateNewObject(fieldList);
                                foreach (var field in fieldList.OrderBy(r => r.Key))
                                {
                                    PropertyInfo propertyInfos = dynamicObj.GetType().GetProperty(field.Key);

                                    var value = string.Empty;
                                    if (field.Key == "Details") propertyInfos.SetValue(dynamicObj, null, null);
                                    else
                                    {
                                        value = dtRow[field.Key].ToString();
                                    }

                                    if (propertyInfos.PropertyType == typeof(decimal))
                                    {
                                        decimal valueDecimal = string.IsNullOrEmpty(value) ? 0 : decimal.Parse(value);
                                        propertyInfos.SetValue(dynamicObj, valueDecimal, null);
                                    }
                                    else if (propertyInfos.PropertyType == typeof(int))
                                    {
                                        int valueint = string.IsNullOrEmpty(value) ? 0 : int.Parse(value);
                                        propertyInfos.SetValue(dynamicObj, valueint, null);
                                    }
                                    else if (propertyInfos.PropertyType == typeof(DateTime))
                                    {
                                        DateTime valueDate = string.IsNullOrEmpty(value)
                                            ? DateTime.MinValue
                                            : DateTime.Parse(value);
                                        propertyInfos.SetValue(dynamicObj, valueDate, null);
                                    }
                                    else if (propertyInfos.PropertyType == typeof(bool))
                                    {
                                        bool valueBit = string.IsNullOrEmpty(value) ? false : bool.Parse(value);
                                        propertyInfos.SetValue(dynamicObj, valueBit, null);
                                    }
                                    else if (propertyInfos.PropertyType == typeof(Guid))
                                    {
                                        Guid valueGuild = string.IsNullOrEmpty(value) ? Guid.Empty : new Guid(value);
                                        propertyInfos.SetValue(dynamicObj, valueGuild, null);
                                    }
                                    else if (propertyInfos.PropertyType == typeof(string))
                                    {
                                        string valueString = string.IsNullOrEmpty(value) ? "" : value;
                                        propertyInfos.SetValue(dynamicObj, valueString, null);
                                    }
                                    else
                                    {
                                        propertyInfos.SetValue(dynamicObj, null, null);
                                    }
                                }

                                list.Add(dynamicObj);
                            }
                        }
                    }
                    else
                    {
                        list = null;
                    }
                }
            return list;
        }

        public IList<B02BCQTModel> GetReportB02BCQT(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<B02BCQTModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
                using (var frmParam = new FrmFinacialReportB02BCTC())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startdate = DateTime.Parse(frmParam.StartDate);
                        var budgetChapter = frmParam.BudgetChapterCode;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("CompanyCode"))
                            oRsTool.Parameters.Add("CompanyCode", string.IsNullOrEmpty(GlobalVariable.CompanyCode) ? string.Empty : GlobalVariable.CompanyCode);
                        if (!oRsTool.Parameters.ContainsKey("BudgetChapterCode"))
                            oRsTool.Parameters.Add("BudgetChapterCode", budgetChapter);
                        list = Model.GetReportB02BCQT(startdate, fromDate, toDate, frmParam.BudgetChapterCode,
                            frmParam.IsSummaryBudgetChapter, false, false);
                    }
                    else
                    {
                        list = null;
                    }
                }
            return list;
        }

        /// <summary>
        /// Recursives the report B01 BCQT.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="amounts">The amounts.</param>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        private List<decimal> RecursiveReportB01BCQT(DataTable dataTable, List<decimal> amounts, string str)
        {
            var strSplit = str.Split('=');
            foreach (var s in strSplit[1].Split('+'))
            {
                var rowAmount = from dataRow in dataTable.AsEnumerable()
                                where dataRow.Field<string>("ReportItemCode") == s.Trim()
                                select dataRow;
                var rowAmountFirt = rowAmount.FirstOrDefault();
                if (rowAmountFirt != null)
                {
                    var reportItemNameChild = rowAmountFirt[7].ToString();
                    if (!string.IsNullOrEmpty(reportItemNameChild) && reportItemNameChild.Contains("(") && reportItemNameChild.Contains(")"))
                    {
                        var reportItemNameSubStringChild = "";
                        reportItemNameSubStringChild = reportItemNameChild.Substring(reportItemNameChild.IndexOf("(", StringComparison.Ordinal) + 1,
                            (reportItemNameChild.IndexOf(")", StringComparison.Ordinal) - reportItemNameChild.IndexOf("(", StringComparison.Ordinal) - 1));
                        if (!string.IsNullOrEmpty(reportItemNameSubStringChild))
                        {
                            RecursiveReportB01BCQT(dataTable, amounts, reportItemNameSubStringChild);
                        }
                    }
                    for (int i = 0; i < amounts.Count; i++)
                    {
                        for (int j = 11; j < rowAmountFirt.Table.Columns.Count; j++)
                        {
                            amounts[i] += decimal.Parse(rowAmountFirt[j].ToString());
                        }
                    }
                }
            }
            return amounts;
        }
    }

}