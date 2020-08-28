/***********************************************************************
 * <copyright file="TreasuaryReport.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Monday, July 30, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.ParameterReportForm;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Ledger;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Treasuary;
using PerpetuumSoft.Framework.Drawing;
using PerpetuumSoft.Reporting.Components;
using PerpetuumSoft.Reporting.DOM;
using RSSHelper;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    /// <summary>
    /// TreasuaryReport
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.ReportClass.BaseReport" />
    public class TreasuaryReport : BaseReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreasuaryReport" /> class.
        /// </summary>
        public TreasuaryReport()
        {
            Model = new Model();
        }
        /// <summary>
        /// Gets the report S04 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>System.Collections.Generic.IList&lt;Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial.S04HModel&gt;.</returns>
        public IList<S52H_GL_MasterModel> GetS52H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S52H_GL_MasterModel> list = null; GlobalVariable.IsDisplayNewLicenseInfo = false;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS52H())
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

                        list = Model.GetS52H(startdate, fromDate, toDate, frmParam.AccountNumber, frmParam.issumaccount, frmParam.pGroupTheSameItem);
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
        /// Gets the report S101 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList{S101HModel}.</returns>
        public IList<S101HModel> GetReportS101H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            IList<S101HModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS101H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.StartDate);
                        var accountNumber = frmParam.AccountNumber;
                        var budgetSourceCode = frmParam.BudgetSourceCode;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var projectCode = frmParam.ProjectId;
                        var budgetSourceCategoryCode = "";
                        var isSummaryAccountNumber = frmParam.IsSummaryAccountNumber;
                        var isSummaryBudgetSource = frmParam.IsSummaryBudgetSource;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSummaryProject = frmParam.IsSummaryProject;
                        var isSummaryBudgetSourceCategory = frmParam.IsSummaryBudgetSourceCategory;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        list = Model.GetReportS101H(startDate, fromDate, toDate, currencyCode, accountNumber, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceCategoryCode, null,
                            isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);
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
        /// Gets the report S101 h part i.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<object> GetReportS101HPartI(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            IList<object> list = new List<object>();
            if (!oRsTool.IsRefresh)
                using (var frmParam = new FrmS101H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.StartDate);
                        var accountNumber = frmParam.AccountNumber;
                        var budgetSourceCode = frmParam.BudgetSourceCode;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var projectCode = frmParam.ProjectId;
                        var budgetSourceCategoryCode = "";
                        var isSummaryAccountNumber = frmParam.IsSummaryAccountNumber;
                        var isSummaryBudgetSource = frmParam.IsSummaryBudgetSource;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSummaryProject = frmParam.IsSummaryProject;
                        var isSummaryBudgetSourceCategory = frmParam.IsSummaryBudgetSourceCategory;
                        var currencyCode = GlobalVariable.CurrencyViewReport;

                        //var budgetKindItemCode = budgetSubKindItem;
                        //if (isSummaryBudgetSubKindItem)
                        //    budgetKindItemCode = "<<Tổng hợp>>";
                        //if (!oRsTool.Parameters.ContainsKey("BudgetKindItem"))
                        //    oRsTool.Parameters.Add("BudgetKindItem", budgetKindItemCode);
                        //var budgetKindItem = Model.GetBudgetKindItemsByCodeIncludeParentCode(budgetKindItemCode);
                        ////var budgetKindItemParentCode = "Loại";
                        //if (budgetKindItem != null && !string.IsNullOrEmpty(budgetKindItem.ParentId))
                        //    budgetKindItemParentCode = budgetKindItem.ParentId;
                        //if (!oRsTool.Parameters.ContainsKey("BudgetKindItemParent"))
                        //    oRsTool.Parameters.Add("BudgetKindItemParent", budgetKindItemParentCode);
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

                        DataSet ds = Model.GetReportS101HPartI(startDate, fromDate, toDate, currencyCode, accountNumber, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceCategoryCode, null,
                            isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);

                        if (ds.Tables[0].Rows.Count < 1)
                        {
                            return list;
                        }
                        //Render Report Template
                        var result = RenderDynamicReportMultiPage(ds.Tables[1], "S101-H1.rst", 1);
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
                        list = new List<object>();
                    }
                }
            return list;
        }

        public IList<object> GetReportS101HPart1(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            List<object> result = new List<object>();

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS101H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.StartDate);
                        var accountNumber = frmParam.AccountNumber;
                        var budgetSourceCode = frmParam.BudgetSourceCode;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var projectCode = frmParam.ProjectId;
                        var budgetSourceCategoryCode = "";
                        var isSummaryAccountNumber = frmParam.IsSummaryAccountNumber;
                        var isSummaryBudgetSource = frmParam.IsSummaryBudgetSource;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSummaryProject = frmParam.IsSummaryProject;
                        var isSummaryBudgetSourceCategory = frmParam.IsSummaryBudgetSourceCategory;
                        var isSummaryView = frmParam.IsSummaryView;
                        var currencyCode = GlobalVariable.CurrencyViewReport;

                        DataTable s101H = Model.GetReportS101H1(startDate, fromDate, toDate, currencyCode, accountNumber, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceCategoryCode, null,
                            isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);

                        //Convert Datatable to List DataSource
                        Dictionary<string, Type> fieldList = new Dictionary<string, Type>();

                        foreach (DataColumn dtCol in s101H.Columns)
                        {
                            fieldList.Add(dtCol.ColumnName, dtCol.DataType);
                        }

                        int i = 0;
                        foreach (DataRow dtRow in s101H.Rows)
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
                                else if (propertyInfos.PropertyType == typeof(bool))
                                {
                                    bool valueint = string.IsNullOrEmpty(value) || bool.Parse(value);
                                    propertyInfos.SetValue(dynamicObj, valueint, null);
                                }
                                else
                                {
                                    propertyInfos.SetValue(dynamicObj, value, null);

                                }
                            }

                            result.Add(dynamicObj);

                        }

                        if (isSummaryView)
                        {
                            RenderDynamicPointrait(s101H);
                            oRsTool.ReportFileName = "S101-H11_Pointrait.rst";
                        }
                        else RenderDynamic(s101H);

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
                    }
                    else result = null;
                }
            }
            return result;
        }

        /// <summary>
        /// Gets the report S101 h part ii.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList{S101HPartIIModel}.</returns>
        public IList<S101HPartIIModel> GetReportS101HPartII(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            IList<S101HPartIIModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS101HPartII())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.FromDate);
                        var budgetSourceCode = frmParam.BudgetSourceId;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var projectCode = frmParam.ProjectId;
                        var budgetItemCode = frmParam.BudgetItemList;
                        var budgetSourceKind = frmParam.BudgetSourceKind;
                        var isSummaryBudgetSource = frmParam.IsSummaryBudgetSource;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSummaryProject = frmParam.IsSummaryProject;
                        var isSummaryBudgetSourceCategory = frmParam.IsSummaryBudgetSourceCategory;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        list = Model.GetReportS101HPartII(startDate, fromDate, toDate, currencyCode, null, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceKind, budgetItemCode,
                            true, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);
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
        /// Gets the report S101 h part ii.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>IList{S101HPartIIModel}.</returns>
        public IList<S101HPartIIIModel> GetReportS101HPartIII(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            IList<S101HPartIIIModel> list = null;
            IList<S101HPartIIIModel> result = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS101H3())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.FromDate);
                        var accountNumber = frmParam.AccountNumber;
                        var budgetSourceCode = frmParam.BudgetSourceCode;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var projectCode = frmParam.ProjectCode;
                        var budgetSourceKind = frmParam.BudgetSourceKind;
                        var budgetItemCode = frmParam.BudgetItemList;
                        var isSummaryAccountNumber = frmParam.IsSummaryAccountNumber;
                        var isSummaryBudgetSource = frmParam.IsSummaryBudgetSource;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSummaryProject = frmParam.IsSummaryProject;
                        var isSummaryBudgetSourceCategory = frmParam.IsSummaryBudgetSourceCategory;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        list = Model.GetReportS101HPartIII(startDate, fromDate, toDate, currencyCode, accountNumber, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceKind, budgetItemCode,
                            isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);
                        if (accountNumber != null && list.Count > 0)
                        {
                            if (accountNumber.Contains("008"))
                            {
                                result = list.Where(x => x.AccountNumber.StartsWith("008")).ToList();
                            }
                            else if (accountNumber.Contains("009"))
                            {
                                result = list.Where(x => x.AccountNumber.StartsWith("009")).ToList();
                            }
                            else
                            {
                                result = list;
                            }
                        }
                        else
                        {
                            result = list;
                        }

                    }
                    else
                    {
                        result = null;
                    }
                }
            }
            return result;
        }

        public IList<S102H1Model> GetReportS102H1(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            IList<S102H1Model> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS102H1())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.StartDate);
                        var budgetSourceCode = frmParam.BudgetSourceCode;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var projectCode = frmParam.ProjectCode;
                        var isSummaryBudgetSource = frmParam.IsSummaryBudgetSource;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSummaryProject = frmParam.IsSummaryProject;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        list = Model.GetReportS102H1(startDate, fromDate, toDate, currencyCode, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, null,
                            isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject);
                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            return list;
        }

        public IList<S102H2Model> GetReportS102H2(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            IList<S102H2Model> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS102H1())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.FromDate);
                        var budgetSourceCode = frmParam.BudgetSourceCode;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var projectCode = frmParam.ProjectCode;
                        //var budgetItemCode = frmParam.BudgetItemList;
                        var isSummaryBudgetSource = frmParam.IsSummaryBudgetSource;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSummaryProject = frmParam.IsSummaryProject;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        list = Model.GetReportS102H2(startDate, fromDate, toDate, currencyCode, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, null,
                            isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject);
                    }
                    else
                    {
                        list = null;
                    }
                }
            }
            return list;
        }

        public IList<S105H1Model> GetReportS105H1(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            IList<S105H1Model> list = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS105H1())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.FromDate);
                        var budgetSourceCode = frmParam.BudgetSourceCode;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSameSummary = false;
                        var budgetExpenseList = frmParam.BudgetExpenseList;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        list = Model.GetReportS105H1(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, budgetExpenseList);
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
        /// 
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<S106H1Model> GetReportS106H1(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            IList<S106H1Model> list = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS106H1())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.FromDate);
                        var budgetSourceCode = frmParam.BudgetSourceCode;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSameSummary = false;
                        var activityid = frmParam.ActivityID;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        list = Model.GetReportS106H1(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, activityid);
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
        /// S106H2
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<S106H2Model> GetReportS106H2(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            IList<S106H2Model> list = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS106H2())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.FromDate);
                        var budgetSourceCode = frmParam.BudgetSourceCode;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSameSummary = false;
                        //  var budgetExpenseList = frmParam.BudgetExpenseList;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        //list = null;
                        list = Model.GetReportS106H2(startDate, fromDate, toDate, isSameSummary, budgetSourceCode,
                            budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter,
                            isSummaryBudgetSubKindItem, frmParam.BudgetItemList);
                        //list = Model.GetReportS105H2(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, "");
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
        /// Gets the report S105 h2.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<S105H2Model> GetReportS105H2(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            IList<S105H2Model> list = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS105H2())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.FromDate);
                        var budgetSourceCode = frmParam.BudgetSourceCode;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSameSummary = false;
                        //  var budgetExpenseList = frmParam.BudgetExpenseList;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        //list = null;
                        list = Model.GetReportS105H2(startDate, fromDate, toDate, isSameSummary, budgetSourceCode,
                            budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter,
                            isSummaryBudgetSubKindItem, frmParam.BudgetItemList);
                        //list = Model.GetReportS105H2(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, "");
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
        /// Gets the report S104 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<S104HModel> GetReportS104H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            IList<S104HModel> list = null;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            var reportDate = GlobalVariable.PostedDate;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS104H())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var startDate = DateTime.Parse(frmParam.FromDate);
                        var budgetSourceCode = frmParam.BudgetSourceCode;
                        var budgetChapterCode = frmParam.BudgetChapterCode;
                        var budgetSubKindItemCode = frmParam.BudgetKindItemCode;
                        var projectCode = frmParam.ProjectCode;
                        var budgetSourceCategoryCode = frmParam.BudgetSourceCategory;
                        var budgetItemCode = frmParam.BudgetItemList;
                        var isSummaryBudgetSource = frmParam.IsSummaryBudgetSource;
                        var isSummaryBudgetChapter = frmParam.IsSummaryBudgetChapter;
                        var isSummaryBudgetSubKindItem = frmParam.IsSummaryBudgetSubKindItem;
                        var isSummaryProject = frmParam.IsSummaryProject;
                        var isSummaryBudgetSourceCategory = frmParam.IsSummaryBudgetSourceCategory;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);

                        list = Model.GetReportS104H(startDate, fromDate, toDate, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, budgetSourceCategoryCode, budgetItemCode, projectCode,
                            isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);
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
        /// Renders the dynamic.
        /// </summary>
        /// <param name="dtSource">The dt source.</param>
        public static void RenderDynamic(DataTable dtSource)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var reportSlot = new FileReportSlot { FilePath = GlobalVariable.ReportPath + "S101-H11.rst" };
            var detailScript = "";

            Document doc = reportSlot.LoadReport();
            int pag = doc.Pages.Count;
            for (int i = 1; i < pag; i++)
            {
                doc.Pages.RemoveAt(i);
            }
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader1 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetail5 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetail6 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxFooter = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetailDyna1 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetailDyna2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetailDyna3 = new PerpetuumSoft.Reporting.DOM.TextBox();

            // Page header
            //PageHeader pageHeader = (PageHeader)doc.ControlByName("ReportHeader");

            // Data band
            DataBand dBand = (DataBand)doc.ControlByName("dataBand1");

            // Group band
            GroupBand gBand = (GroupBand)doc.ControlByName("groupBand1");
            GroupBand groupBand1 = (GroupBand)doc.ControlByName("groupBand1");
            GroupBand groupBand2 = (GroupBand)doc.ControlByName("groupBand2");
            GroupBand groupBand3 = (GroupBand)doc.ControlByName("groupBand3");

            // Header
            Header header = (Header)doc.ControlByName("header1");
            Header header1 = (Header)doc.ControlByName("header1");
            Header header2 = (Header)doc.ControlByName("header2");
            Header header3 = (Header)doc.ControlByName("header3");
            Header header4 = (Header)doc.ControlByName("header4");
            Header header5 = (Header)doc.ControlByName("header5");
            Header header6 = (Header)doc.ControlByName("header6");

            // Detail
            Detail detail = (Detail)doc.ControlByName("detail1");

            // Footer 
            PageFooter pageFooter = (PageFooter)doc.ControlByName("pageFooter");

            header3.Controls.Clear();
            header4.Controls.Clear();
            detail.Controls.Clear();
            detail.Controls.Clear();

            Border oBorder = new Border();
            BorderLine oBorderLine = new BorderLine();
            oBorderLine.Width = 1;
            oBorderLine.Color = System.Drawing.Color.Black;
            oBorderLine.Style = PerpetuumSoft.Framework.Drawing.LineStyle.Solid;
            oBorder = new Border(oBorderLine, oBorderLine, oBorderLine, oBorderLine);

            FontDescriptor fontHeader = new FontDescriptor("Times New Roman", 11, FontStyleMode.On, FontStyleMode.Off, FontStyleMode.Off);
            FontDescriptor fontSubHeader = new FontDescriptor("Times New Roman", 11, FontStyleMode.Off, FontStyleMode.Off, FontStyleMode.Off);

            header3.RepeatEveryPage = true;
            header4.RepeatEveryPage = true;

            #region Header3

            //Tạo cột STT
            textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader2.Name = "txtPostedDateHeader";
            textBoxHeader2.Text = "Ngày ghi sổ";
            header3.Controls.Add(textBoxHeader2);
            textBoxHeader2.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.Size = new Vector(2.2f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
            textBoxHeader2.Border = oBorder;
            textBoxHeader2.Font = fontHeader;

            //Tạo cột Chỉ tiêu
            textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader2.Name = "txtItemHeader";
            textBoxHeader2.Text = "Chỉ tiêu";
            header3.Controls.Add(textBoxHeader2);
            textBoxHeader2.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.Size = new Vector(7f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
            textBoxHeader2.Border = oBorder;
            textBoxHeader2.Font = fontHeader;

            //Tạo cột Tổng số
            textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader2.Name = "txtTotalAmountHeader";
            textBoxHeader2.Text = "Tổng số";
            header3.Controls.Add(textBoxHeader2);
            textBoxHeader2.Location = new Vector(10.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.Size = new Vector(3f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
            textBoxHeader2.Border = oBorder;
            textBoxHeader2.Font = fontHeader;

            #endregion

            #region Header4

            //Tạo cột STT
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtCollumnNumber1";
            textBoxHeader3.Text = "A";
            header4.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader2.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;
            textBoxHeader.Font = fontSubHeader;

            //Tạo cột Chỉ tiêu
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtCollumnNumber2";
            textBoxHeader3.Text = "B";
            header4.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(7f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;
            textBoxHeader.Font = fontSubHeader;

            //Tạo cột tỷ lệ khấu hao
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtCollumnNumber3";
            textBoxHeader3.Text = "1";
            header4.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(10.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(3f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader.CanGrow = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;
            textBoxHeader3.Font = fontSubHeader;


            #endregion

            #region Detail

            //Tạo cột Ngay ghi so
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtPostedDate";
            textBoxDetail.Text = "";
            textBoxDetail.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;
            detail.Controls.Add(textBoxDetail);

            //Tạo cột Chỉ tiêu
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtEstimateItemName";
            textBoxDetail.Text = "";
            textBoxDetail.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(7f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;
            detail.Controls.Add(textBoxDetail);

            //Tạo cột tong so tien
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtTotalAmount";
            textBoxDetail.Text = "";
            textBoxDetail.Location = new Vector(10.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;
            detail.Controls.Add(textBoxDetail);
            detail.CanGrow = true;
            detail.GenerateScript = "txtEstimateItemName.Value = GetData(\"ItemName\").ToString(); " +
                                    "decimal totalAmount = GetData(\"TotalValue\")  == null ? 0 : decimal.Parse(GetData(\"TotalValue\").ToString());" +
                                    "if(totalAmount == 0) {txtTotalAmount.Value =\"\";} else {txtTotalAmount.Value =  totalAmount;}" +
                                    "txtTotalAmount.TextFormat = (PerpetuumSoft.Framework.Text.TextFormat)GetData(\"RssObject.CurrencyFormat\");" +
                                    "txtTotalAmount.TextFormat.CurrencySymbol = \"\";" +
                                    "txtPostedDate.Value = GetData(\"PostedDate\") == null || DateTime.Parse(GetData(\"PostedDate\").ToString()).ToShortDateString() == \"01/01/0001\" ? \"\" : DateTime.Parse(GetData(\"PostedDate\").ToString()).ToShortDateString();"
                                    + "int isBold;" +
                                    "isBold = int.Parse(GetData(\"IsBold\").ToString());" +
                                    "if (isBold == 1)" +
                                    "{" +
                                    "    txtPostedDate.StyleName = \"DetailNormalBold\";" +
                                    "    txtEstimateItemName.StyleName = \"DetailNormalBold\";" +
                                    "    txtTotalAmount.StyleName = \"DetailNormalBold\";" +
                                    "}" +
                                    "else" +
                                    "{" +
                                    "    txtPostedDate.StyleName = \"DetailNormal\";" +
                                    "    txtEstimateItemName.StyleName = \"DetailNormal\";" +
                                    "    txtTotalAmount.StyleName = \"DetailNormal\";" +
                                    "}"
                                    + "txtEstimateItemName.CanGrow = true; "
                                    + "txtEstimateItemName.GrowToBottom = true; "
                                    + "txtTotalAmount.CanGrow = true; "
                                    + "txtTotalAmount.GrowToBottom = true; "
                                    + "txtPostedDate.CanGrow = true; "
                                    + "txtPostedDate.GrowToBottom = true; ";

            #endregion

            #region Gen page 1

            double marginLeft = 13.7f;
            int countDynamicColumn = 0;
            int numberheader3 = 5;            

            Dictionary<string, Type> fieldList = new Dictionary<string, Type>();

            foreach (DataColumn dtCol in dtSource.Columns)
            {
                if (dtCol.Caption.StartsWith("0") || dtCol.Caption.StartsWith("1") || dtCol.Caption.StartsWith("2") || dtCol.Caption.StartsWith("3") || dtCol.Caption.StartsWith("4") || dtCol.Caption.StartsWith("5") || dtCol.Caption.StartsWith("6") || dtCol.Caption.StartsWith("7") || dtCol.Caption.StartsWith("8") || dtCol.Caption.StartsWith("9") || dtCol.Caption.StartsWith("XXX"))
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
            var x = 2;
            foreach (var dtColumn in listpage1)
            {
                //Tạo header
                if (dtColumn.Key.StartsWith("0") || dtColumn.Key.StartsWith("1") || dtColumn.Key.StartsWith("2") || dtColumn.Key.StartsWith("3") || dtColumn.Key.StartsWith("4") || dtColumn.Key.StartsWith("5") || dtColumn.Key.StartsWith("6") || dtColumn.Key.StartsWith("7") || dtColumn.Key.StartsWith("8") || dtColumn.Key.StartsWith("9") || dtColumn.Key.StartsWith("XXX"))
                {
                    #region Header

                    textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();                    
                    textBoxHeader.Name = "txt" + dtColumn.Key.Replace("Dynamic", "");
                    if (dtColumn.Key.StartsWith("XXX"))
                        textBoxHeader.Text = "<<Tổng hợp>>";
                    else
                        textBoxHeader.Text = "Khoản " + dtColumn.Key.Replace("Dynamic", "");
                    header3.Controls.Add(textBoxHeader);
                    textBoxHeader.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(3f, 1f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxHeader.CanGrow = textBoxHeader.GrowToBottom = true;
                    textBoxHeader.Border = oBorder;
                    textBoxHeader.Font = fontHeader;

                    textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader.Name = "txt" + x.ToString();
                    textBoxHeader.Text = x.ToString();
                    header4.Controls.Add(textBoxHeader);
                    textBoxHeader.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(3f, 0.5f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxHeader.CanGrow = textBoxHeader.GrowToBottom = true;
                    textBoxHeader.Border = oBorder;
                    textBoxHeader.Font = fontSubHeader;

                    #endregion

                    #region Detail

                    textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxDetail.Name = "txtDetail" + dtColumn.Key.Replace("Dynamic", "");
                    //textBoxDetail.Text = dtColumn.Key.Replace("Dynamic", "");
                    textBoxDetail.GenerateScript =
                        "decimal detailValue = decimal.Parse(GetData(\"" + dtColumn.Key + "\").ToString());"
                        + "if (detailValue == 0)"
                        + "{" + textBoxDetail.Name.ToString() + ".Value= \"\"; } "
                        + "else {" + textBoxDetail.Name.ToString() + ".Value = detailValue;}"
                        + textBoxDetail.Name + ".TextFormat = "
                        +
                        "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");"
                        + textBoxDetail.Name + ".TextFormat.CurrencySymbol = \"\";"
                        + "int itemType = int.Parse(GetData(\"ItemType\").ToString());"
                    + "if (itemType == 1 || itemType == 4 || itemType == 3 || itemType == 6 || itemType == 7)"
                    + "{" + textBoxDetail.Name + ".StyleName = \"DetailNormalBold\";}"
                    + "else {" + textBoxDetail.Name + ".StyleName = \"DetailNormal\" ;}"
                            + textBoxDetail.Name + ".CanGrow = true; "
                            + textBoxDetail.Name + ".GrowToBottom = true; ";

                    //textBoxDetail.GenerateScript =
                    //    textBoxDetail.Name.ToString() + ".Value=GetData(\"" + dtColumn.Key + "\").ToString(); ";
                    textBoxDetail.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetail.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                    textBoxDetail.Border = oBorder;
                    detail.Controls.Add(textBoxDetail);

                    countDynamicColumn = countDynamicColumn + 1;
                    marginLeft = marginLeft + 3f;

                    #endregion

                    x++;
                }
            }
            var j = countDynamicColumn + 2;
            for (int i = countDynamicColumn; i < 5; i++)
            {
                var col = 3 - countDynamicColumn;

                #region Header

                textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader.Name = "txt" + i.ToString();
                header3.Controls.Add(textBoxHeader);
                textBoxHeader.Location =
                    new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxHeader.Size =
                    new PerpetuumSoft.Framework.Drawing.Vector(3f, 1f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader.CanGrow = textBoxHeader.GrowToBottom = true;
                textBoxHeader.Border = oBorder;
                textBoxHeader.Font = fontHeader;

                textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader.Name = "txt" + j.ToString();
                textBoxHeader.Text = j.ToString(); ;
                header4.Controls.Add(textBoxHeader);
                textBoxHeader.Location =
                    new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxHeader.Size =
                    new PerpetuumSoft.Framework.Drawing.Vector(3f, 0.5f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader.CanGrow = textBoxHeader.GrowToBottom = true;
                textBoxHeader.Border = oBorder;
                textBoxHeader.Font = fontSubHeader;

                #endregion

                #region detail

                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txtDetail" + i.ToString();
                textBoxDetail.Text = "";
                textBoxDetail.Location =
                    new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxDetail.Size =
                    new PerpetuumSoft.Framework.Drawing.Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                detail.CanGrow = textBoxDetail.GrowToBottom = true;
                detail.Controls.Add(textBoxDetail);
                textBoxDetail.Border = oBorder;

                #endregion

                marginLeft = marginLeft + 3f;
                j++;
            }

            #endregion

            #region Page 2

            var quantity = 0;
            var k = 4;
            //page 2
            for (int n = 2; n <= pageIndex; n++)
            {
                double marginLeftN = 11.6f;

                #region  Page component
                var listpageN = fieldlistOrder.Skip((n - 1) * 10 - 5).Take(10);
                int countDynamicColumnN = 0;
                var pagen = "page" + n;
                Page checkpage = (Page)doc.ControlByName("page" + n);
                if (checkpage != null) doc.Pages.Remove(checkpage);

                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader1N = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxFooter1 = new PerpetuumSoft.Reporting.DOM.TextBox();

                Page page = new Page();
                page.Name = "page" + n;
                page.Margins = new Margins(1f, 1f, 1.1f, 1.1f);
                page.Orientation = PageOrientation.Portrait;
                doc.Pages.Add(page);

                PageHeader pageHeader = new PageHeader();
                pageHeader.Name = "ReportHeader" + n;
                pageHeader.Location = new Vector(0f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                pageHeader.Size = new Vector(21f, 1.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                page.Controls.Add(pageHeader);
                pageHeader.GenerateScript = "txtCompanyNameN.Value = \"Đơn vị: \" + GetParameter(\"CompanyName\").ToString();"
                                            + "txtCompanyCodeN.Value = \"Mã QHNS: \" + GetParameter(\"CompanyCode\") == null ? \"\" : GetParameter(\"CompanyCode\").ToString();";

                PageFooter pagefooter = new PageFooter();
                pagefooter.Name = "pagefooter" + n;
                //textBoxFooter = new PerpetuumSoft.Reporting.DOM.TextBox();
                //textBoxFooter.Name = "txtfooter" + n;
                pagefooter.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 22.7f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                pagefooter.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 0.5f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                //textBoxFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                page.Controls.Add(pagefooter);

                DataBand dataBand = new DataBand();
                dataBand.Name = "dataBandDyna" + n;
                page.Controls.Add(dataBand);
                dataBand.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.2f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                dataBand.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 11f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                dataBand.DataSource = "S101H";

                GroupBand groupBand1N = new GroupBand();
                groupBand1N.Name = "groupBandDyna" + n;
                
                groupBand1N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                groupBand1N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 10.2f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                groupBand1N.GroupExpression = "GetData(\"AccountNumber\").ToString() + GetData(\"BudgetSourceKind\").ToString() + GetData(\"BudgetChapterCode\").ToString()";
                groupBand1N.NewPageBefore = true;
                dataBand.Controls.Add(groupBand1N);

                GroupBand groupBand2N = new GroupBand();
                groupBand2N.Name = "groupBand2Dyna" + n;
                groupBand1N.Controls.Add(groupBand2N);
                groupBand2N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 6.5f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                groupBand2N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 4.2).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                groupBand2N.GroupExpression = "GetData(\"AccountNumber\").ToString() + GetData(\"BudgetSourceKind\").ToString() + GetData(\"BudgetChapterCode\").ToString() + GetData(\"ProjectId\").ToString() + GetData(\"BudgetGroupItemCode\").ToString()";

                GroupBand groupBand3N = new GroupBand();
                groupBand3N.Name = "groupBand3Dyna" + n;
                groupBand2N.Controls.Add(groupBand3N);
                groupBand3N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 1.4f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                groupBand2N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 2.4f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                //groupBand3N.GroupExpression = "GetData(\"AccountNumber\").ToString() + GetData(\"BudgetSourceCategoryId\").ToString()";
                groupBand3N.GroupExpression = "GetData(\"AccountNumber\").ToString() + GetData(\"BudgetSourceKind\").ToString() + GetData(\"BudgetChapterCode\").ToString() + GetData(\"ProjectId\").ToString() + GetData(\"BudgetGroupItemCode\").ToString() ";

                Header header1N = new Header();
                dataBand.Controls.Add(header1N);
                header1N.Name = "header1N" + n;
                header1N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.8f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header1N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21, 2f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header1N.StyleName = "HeaderFooter2Bold";
                header1N.GenerateScript = "txtPeriodN.Text = RSSHelper.DateToWord.ReadDate(DateTime.Parse(GetParameter(\"FromDate\").ToString()), DateTime.Parse(GetParameter(\"ToDate\").ToString())); "
                + "string accountNumber = GetData(\"AccountNumber\").ToString() == \"XXX\" ? \"<<Tổng hợp>>\" : GetData(\"AccountNumber\").ToString();" +
                "txtAccountNameN.Value = \"Tài khoản: \" + accountNumber; ";
                header1N.RepeatEveryPage = true;
                

                Header header2N = new Header();
                dataBand.Controls.Add(header2N);
                header2N.Name = "header2N" + n;
                header2N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.2f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header2N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21, 1f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header2N.StyleName = "HeaderFooter2Bold";
                header2N.GenerateScript = "string budgetChapterCode = GetData(\"BudgetChapterCode\").ToString() == \"XXX\" ? \"<<Tổng hợp>>\" : GetData(\"BudgetChapterCode\").ToString();" +
                "txtBudgetSourceCategoryCode.Text = \"Kinh phí: \" + GetData(\"BudgetSourceCategoryName\").ToString() + \" - Chương: \" + budgetChapterCode;";

                Header header3N = new Header();
                groupBand1N.Controls.Add(header3N);
                header3N.Name = "header3N" + n;
                header3N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 4.2f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header3N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 1f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header3N.StyleName = "HeaderFooter2Bold";
                header3N.RepeatEveryPage = true;

                Header header4N = new Header();
                groupBand1N.Controls.Add(header4N);
                header4N.Name = "header4N" + n;
                header4N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 5.6f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header4N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 0.5f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header4N.StyleName = "HeaderFooter2Bold";
                //header4N.RepeatEveryPage = true;

                Header header5N = new Header();
                groupBand2N.Controls.Add(header5N);
                header5N.Name = "header5N" + n;
                header5N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header5N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 0.6f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header5N.StyleName = "HeaderFooter2Bold";

                Header header6N = new Header();
                groupBand3N.Controls.Add(header6N);
                header6N.Name = "header6N" + n;
                header6N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header6N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 0.6f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header6N.StyleName = "HeaderFooter2Bold";

                Detail detailN = new Detail();
                detailN.Name = "detailN" + n;
                groupBand3N.Controls.Add(detailN);
                detailN.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 1.3f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                detailN.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 0.6f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                detailN.CanGrow = true;

                #endregion
                #region ReportHeader
                //Teen don vi
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtCompanyNameN";
                textBoxHeader2.Text = "";
                pageHeader.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(15f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxHeader2.Font = fontHeader;

                //Ma don vi
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtCompanyCodeN";
                textBoxHeader2.Text = "";
                pageHeader.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(15f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxHeader2.Font = fontSubHeader;

                //Mẫu số: S101-H
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtFormNoN";
                textBoxHeader2.Text = "Mẫu số: S101-H";
                pageHeader.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(12f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.Font = fontHeader;

                //(Ban hành theo Thông tư số 107/2017/TT-BTC
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtIssueByN";
                textBoxHeader2.Text = "(Ban hành theo Thông tư số 107/2017/TT-BTC ";
                pageHeader.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(12f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.Font = fontSubHeader;

                //ngày 10 / 10 / 2017 của Bộ Tài chính)
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtIssueBy1N";
                textBoxHeader2.Text = "ngày 10 / 10 / 2017 của Bộ Tài chính)";
                pageHeader.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(12f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Font = fontSubHeader;

                #endregion

                #region Header1

                //SỔ THEO DÕI DỰ TOÁN TỪ NGUỒN NSNN TRONG NƯỚC
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtReportTitleN";
                textBoxHeader2.Text = "SỔ THEO DÕI DỰ TOÁN TỪ NGUỒN NSNN TRONG NƯỚC";
                header1N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(18.5f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.Font = fontHeader;


                //Tài khoản: {0}
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtAccountNameN";
                textBoxHeader2.Text = "Tài khoản: {0}";
                header1N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(18.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.Font = fontSubHeader;

                //Tháng {0}....năm {1}....
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtPeriodN";
                textBoxHeader2.Text = "Tháng {0}....năm {1}....";
                header1N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 1.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(18.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.Font = fontSubHeader;

                #endregion

                #region Header2

                //I. Dự toán NSNN giao
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtPartNameN";
                textBoxHeader2.Text = "I. Dự toán NSNN giao";
                header2N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(18.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxHeader2.Font = fontHeader;

                //Kinh phí: {0}
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtBudgetSourceCategoryCodeN";
                textBoxHeader2.Text = "Kinh phí: {0}";
                header2N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(18.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Font = fontSubHeader;

                #endregion

                #region Header3

                //Tạo cột STT
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtPostedDateHeaderN";
                textBoxHeader2.Text = "Ngày ghi sổ";
                header3N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(2.2f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Border = oBorder;
                textBoxHeader2.Font = fontHeader;

                //Tạo cột Chỉ tiêu
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtItemHeaderN";
                textBoxHeader2.Text = "Chỉ tiêu";
                header3N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(7f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Border = oBorder;
                textBoxHeader2.Font = fontHeader;

                //Tạo cột Tổng số
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtTotalAmountHeaderN";
                textBoxHeader2.Text = "Tổng số";
                header3N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(10.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(3f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Border = oBorder;
                textBoxHeader2.Font = fontHeader;

                #endregion

                #region Header4

                //Tạo cột STT
                textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader3.Name = "txtCollumnNumber1N";
                textBoxHeader3.Text = "A";
                header4N.Controls.Add(textBoxHeader3);
                textBoxHeader3.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.Size = new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader3.CanGrow = textBoxHeader3.GrowToBottom = true;
                textBoxHeader3.Border = oBorder;
                textBoxHeader.Font = fontSubHeader;

                //Tạo cột Chỉ tiêu
                textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader3.Name = "txtCollumnNumber2N";
                textBoxHeader3.Text = "B";
                header4N.Controls.Add(textBoxHeader3);
                textBoxHeader3.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.Size = new Vector(7f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader3.CanGrow = textBoxHeader3.GrowToBottom = true;
                textBoxHeader3.Border = oBorder;
                textBoxHeader.Font = fontSubHeader;

                //Tạo cột tổng số tiền
                textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader3.Name = "txtCollumnNumber3N";
                textBoxHeader3.Text = "1";
                header4N.Controls.Add(textBoxHeader3);
                textBoxHeader3.Location = new Vector(10.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.Size = new Vector(3f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader3.CanGrow = textBoxHeader3.GrowToBottom = true;
                textBoxHeader3.Border = oBorder;
                textBoxHeader3.Font = fontSubHeader;


                #endregion

                #region Footer
                //Page Number
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtPageNumberN";
                pagefooter.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(9.4f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(10.6f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Font = fontSubHeader;
                textBoxHeader2.GenerateScript = "txtPageNumber.Text = PageNumber.ToString();";
                #endregion

                #region Header 5
                //Tạo cột 1
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txtHeader5" + k;
                textBoxDetail.Text = "";
                header5N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột Chỉ tiêu
                textBoxDetail5 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail5.Name = "txtEstimateItemName5" + k;
                textBoxDetail5.Text = "";
                header5N.Controls.Add(textBoxDetail5);
                textBoxDetail5.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail5.Size = new Vector(5f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxDetail5.CanGrow = textBoxDetail5.GrowToBottom = true;
                textBoxDetail5.Border = oBorder;
                textBoxDetail5.GenerateScript = "string projectCode = GetData(\"ProjectCode\").ToString() == \"XXX\" ? \"<<Tổng hợp>>\" : GetData(\"ProjectCode\").ToString(); " +
                textBoxDetail5.Name + ".Value = \"Mã CTMT, DA: \" + projectCode;";

                //Tạo cột tong so tien
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txtTotalAmount5" + k;
                textBoxDetail.Text = "";
                header5N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(10.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt51" + k;
                textBoxDetail.Text = "";
                header5N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(13.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt51" + k;
                textBoxDetail.Text = "";
                header5N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(16.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt51" + k;
                textBoxDetail.Text = "";
                header5N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(19.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;
                #endregion

                #region Header 6
                //Tạo cột 1
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txtHeader6" + k;
                textBoxDetail.Text = "";
                header6N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột Chỉ tiêu
                textBoxDetail6 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail6.Name = "txtEstimateItemName6" + k;
                textBoxDetail6.Text = "";
                header6N.Controls.Add(textBoxDetail6);
                textBoxDetail6.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail6.Size = new Vector(7f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxDetail6.CanGrow = textBoxDetail6.CanShrink = textBoxDetail6.GrowToBottom = true;
                textBoxDetail6.Border = oBorder;
                textBoxDetail6.GenerateScript = "string budgetItemCode = GetData(\"BudgetGroupItemCode\").ToString() == \"XXX\" ? \"\" : GetData(\"BudgetGroupItemCode\").ToString();" +
                textBoxDetail6.Name + ".Value = \"Mã MLNS: \" + budgetItemCode;";

                //Tạo cột tong so tien
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txtTotalAmount6" + k;
                textBoxDetail.Text = "";
                header6N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(10.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt61" + k;
                textBoxDetail.Text = "";
                header6N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(13.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt61" + k;
                textBoxDetail.Text = "";
                header6N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(16.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt61" + k;
                textBoxDetail.Text = "";
                header6N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(19.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;
                #endregion

                #region Detail
                //Tạo cột Ngay ghi so
                textBoxDetailDyna1 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetailDyna1.Name = "txtPostedDateN" + n;
                textBoxDetailDyna1.Text = "";
                textBoxDetailDyna1.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna1.Size = new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxDetailDyna1.CanGrow = textBoxDetailDyna1.GrowToBottom = true;
                textBoxDetailDyna1.Border = oBorder;
                detailN.Controls.Add(textBoxDetailDyna1);
                //Tạo cột Chỉ tiêu
                textBoxDetailDyna2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetailDyna2.Name = "txtEstimateItemNameN" + n;
                textBoxDetailDyna2.Text = "";
                textBoxDetailDyna2.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna2.Size = new Vector(7f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxDetailDyna2.CanGrow = textBoxDetailDyna2.GrowToBottom = true;
                textBoxDetailDyna2.Border = oBorder;
                detailN.Controls.Add(textBoxDetailDyna2);

                //Tạo cột tong so tien
                textBoxDetailDyna3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetailDyna3.Name = "txtTotalAmountN" + n;
                textBoxDetailDyna3.Text = "";
                textBoxDetailDyna3.Location = new Vector(10.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna3.Size = new Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetailDyna3.CanGrow = true;
                textBoxDetailDyna3.GrowToBottom = true;
                textBoxDetailDyna3.Border = oBorder;
                detailN.Controls.Add(textBoxDetailDyna3);
                detailN.GenerateScript = "txtEstimateItemNameN" + n + ".Value = GetData(\"ItemName\").ToString(); " +
                                "txtPostedDateN" + n + ".Value = GetData(\"PostedDate\") == null || DateTime.Parse(GetData(\"PostedDate\").ToString()).ToShortDateString() == \"01/01/0001\" ? \"\" : DateTime.Parse(GetData(\"PostedDate\").ToString()).ToShortDateString();"
                               + "decimal totalAmountN = GetData(\"TotalValue\")  == null ? 0 : decimal.Parse(GetData(\"TotalValue\").ToString());"
                               + "if(totalAmountN == 0) {txtTotalAmountN" + n + ".Value = \"\";} else {txtTotalAmountN" + n + ".Value =  totalAmountN;}"
                               + "txtTotalAmountN" + n + ".TextFormat = (PerpetuumSoft.Framework.Text.TextFormat)GetData(\"RssObject.CurrencyFormat\");"
                               + "txtTotalAmountN" + n + ".TextFormat.CurrencySymbol = \"\";"
                                + "int isBold;" +
                                "isBold = int.Parse(GetData(\"IsBold\").ToString());" +
                                "if (isBold == 1)" +
                                "{" +
                                "    txtPostedDateN" + n + ".StyleName = \"DetailNormalBold\";" +
                                "    txtTotalAmountN" + n + ".StyleName = \"DetailNormalBold\";" +
                                "    txtEstimateItemNameN" + n + ".StyleName = \"DetailNormalBold\";" +
                                "}" +
                                "else" +
                                "{" +
                                "    txtPostedDateN" + n + ".StyleName = \"DetailNormal\";" +
                                "    txtTotalAmountN" + n + ".StyleName = \"DetailNormal\";" +
                                "    txtEstimateItemNameN" + n + ".StyleName = \"DetailNormal\";" +
                                "}";


                #endregion

                foreach (var dtColumn in listpageN)
                {
                    if (dtColumn.Key.StartsWith("0") || dtColumn.Key.StartsWith("1") || dtColumn.Key.StartsWith("2") || dtColumn.Key.StartsWith("3") || dtColumn.Key.StartsWith("4") || dtColumn.Key.StartsWith("5") || dtColumn.Key.StartsWith("6") || dtColumn.Key.StartsWith("7") || dtColumn.Key.StartsWith("8") || dtColumn.Key.StartsWith("9") || dtColumn.Key.StartsWith("XXX"))
                    {
                        #region Header 

                        textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader2N.Name = "txt" + dtColumn.Key.Replace("Dynamic", "");
                        textBoxHeader2N.Text = "Khoản " + dtColumn.Key.Replace("Dynamic", "");
                        header3N.Controls.Add(textBoxHeader2N);
                        textBoxHeader2N.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxHeader2N.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(3f, 1f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader2N.CanGrow = textBoxHeader2N.GrowToBottom = true;
                        textBoxHeader2N.Border = oBorder;
                        textBoxHeader2N.Font = fontHeader;

                        textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader.Name = "txt" + k.ToString();
                        textBoxHeader.Text = k.ToString(); ;
                        header4N.Controls.Add(textBoxHeader);
                        textBoxHeader.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxHeader.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(3f, 0.5f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader.CanGrow = textBoxHeader.GrowToBottom = true;
                        textBoxHeader.Border = oBorder;
                        textBoxHeader.Font = fontSubHeader;

                        #endregion

                        #region Detail                        

                        textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxDetailN.Name = "txtDetail" + dtColumn.Key.Replace("Dynamic", "");
                        textBoxDetailN.Text = dtColumn.Key.Replace("Dynamic", "");
                        textBoxDetailN.GenerateScript =
                            "decimal detailValue = decimal.Parse(GetData(\"" + dtColumn.Key + "\").ToString());"
                            + "if (detailValue == 0)"
                            + "{" + textBoxDetailN.Name.ToString() + ".Value= \"\"; } "
                            + "else {" + textBoxDetailN.Name.ToString() + ".Value = detailValue;}"
                            + textBoxDetailN.Name + ".TextFormat = "
                            + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");"
                            + textBoxDetailN.Name + ".TextFormat.CurrencySymbol = \"\";"
                            + "int itemType = int.Parse(GetData(\"ItemType\").ToString());"
                            + "if (itemType == 1 || itemType == 4 || itemType == 3 || itemType == 6 || itemType == 7)"
                            + "{" + textBoxDetailN.Name + ".StyleName = \"DetailNormalBold\";}"
                            + "else {" + textBoxDetailN.Name + ".StyleName = \"DetailNormal\" ;}"
                            + textBoxDetailN.Name + ".CanGrow = true; "
                            + textBoxDetailN.Name + ".GrowToBottom = true; ";
                        textBoxDetailN.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxDetailN.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        textBoxDetailN.CanGrow = textBoxDetailN.GrowToBottom = true;
                        textBoxDetailN.Border = oBorder;
                        detailN.Controls.Add(textBoxDetailN);

                        countDynamicColumnN = countDynamicColumnN + 1;
                        marginLeftN = marginLeftN + 3f;

                        #endregion
                        k++;
                    }
                }
                var m = 4;
                for (int i = countDynamicColumnN; i < 3; i++)
                {
                    #region Header

                    textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader2N.Name = "txtN" + k.ToString();
                    header3N.Controls.Add(textBoxHeader2N);
                    textBoxHeader2N.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader2N.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(3f, 1f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxDetailN.CanGrow = textBoxDetailN.GrowToBottom = true;
                    textBoxHeader2N.Border = oBorder;
                    textBoxHeader2N.Font = fontHeader;

                    textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader.Name = "txt" + m.ToString();
                    textBoxHeader.Text = ""; ;
                    header4N.Controls.Add(textBoxHeader);
                    textBoxHeader.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(3f, 0.5f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                    textBoxHeader.Border = oBorder;
                    textBoxHeader.Font = fontSubHeader;

                    #endregion

                    #region detail

                    textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxDetailN.Name = "txtDetailN" + k.ToString();
                    textBoxDetailN.Text = "";
                    detailN.Controls.Add(textBoxDetailN);
                    textBoxDetailN.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetailN.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxDetailN.CanGrow = textBoxDetail.GrowToBottom = true;
                    textBoxDetailN.Border = oBorder;
                    textBoxDetailN.GenerateScript =
                            textBoxDetailN.Name + ".CanGrow = true; "
                            + textBoxDetailN.Name + ".GrowToBottom = true; ";

                    #endregion

                    marginLeftN = marginLeftN + 3f;

                    m++;
                }
                k = k + 1;
            }

            #endregion

            //reportSlot.DesignTemplate();
            reportSlot.SaveReport(doc);
        }

        public static void RenderDynamicPointrait(DataTable dtSource)
        {
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var reportSlot = new FileReportSlot { FilePath = GlobalVariable.ReportPath + "S101-H11_Pointrait.rst" };
            var detailScript = "";

            Document doc = reportSlot.LoadReport();
            int pag = doc.Pages.Count;
            for (int i = 1; i < pag; i++)
            {
                doc.Pages.RemoveAt(i);
            }
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader1 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxTotalHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetail5 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetail6 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxFooter = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetailDyna1 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetailDyna2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            PerpetuumSoft.Reporting.DOM.TextBox textBoxDetailDyna3 = new PerpetuumSoft.Reporting.DOM.TextBox();

            // Page header
            //PageHeader pageHeader = (PageHeader)doc.ControlByName("ReportHeader");

            // Data band
            DataBand dBand = (DataBand)doc.ControlByName("dataBand1");

            // Group band
            GroupBand gBand = (GroupBand)doc.ControlByName("groupBand1");
            GroupBand groupBand1 = (GroupBand)doc.ControlByName("groupBand1");
            GroupBand groupBand2 = (GroupBand)doc.ControlByName("groupBand2");
            GroupBand groupBand3 = (GroupBand)doc.ControlByName("groupBand3");

            // Header
            Header header = (Header)doc.ControlByName("header1");
            Header header1 = (Header)doc.ControlByName("header1");
            Header header2 = (Header)doc.ControlByName("header2");
            Header header3 = (Header)doc.ControlByName("header3");
            Header header4 = (Header)doc.ControlByName("header4");
            Header header5 = (Header)doc.ControlByName("header5");
            Header header6 = (Header)doc.ControlByName("header6");

            // Detail
            Detail detail = (Detail)doc.ControlByName("detail1");

            // Footer 
            PageFooter pageFooter = (PageFooter)doc.ControlByName("pageFooter");

            header3.Controls.Clear();
            header4.Controls.Clear();
            detail.Controls.Clear();

            Border oBorder = new Border();
            BorderLine oBorderLine = new BorderLine();
            oBorderLine.Width = 1;
            oBorderLine.Color = System.Drawing.Color.Black;
            oBorderLine.Style = PerpetuumSoft.Framework.Drawing.LineStyle.Solid;
            oBorder = new Border(oBorderLine, oBorderLine, oBorderLine, oBorderLine);

            FontDescriptor fontHeader = new FontDescriptor("Times New Roman", 11, FontStyleMode.On, FontStyleMode.Off, FontStyleMode.Off);
            FontDescriptor fontSubHeader = new FontDescriptor("Times New Roman", 11, FontStyleMode.Off, FontStyleMode.Off, FontStyleMode.Off);

            header3.RepeatEveryPage = true;
            header4.RepeatEveryPage = true;

            #region Header3

            //Tạo cột STT
            textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader2.Name = "txtPostedDateHeader";
            textBoxHeader2.Text = "Ngày ghi sổ";
            header3.Controls.Add(textBoxHeader2);
            textBoxHeader2.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.Size = new Vector(2.2f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
            textBoxHeader2.Border = oBorder;
            textBoxHeader2.Font = fontHeader;

            //Tạo cột Chỉ tiêu
            textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader2.Name = "txtItemHeader";
            textBoxHeader2.Text = "Chỉ tiêu";
            header3.Controls.Add(textBoxHeader2);
            textBoxHeader2.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.Size = new Vector(5f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
            textBoxHeader2.Border = oBorder;
            textBoxHeader2.Font = fontHeader;

            //Tạo cột Tổng số
            textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader2.Name = "txtTotalAmountHeader";
            textBoxHeader2.Text = "Tổng số";
            textBoxHeader2.Location = new Vector(8.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.Size = new Vector(2.9f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
            textBoxHeader2.Border = oBorder;
            textBoxHeader2.Font = fontHeader;
            header3.Controls.Add(textBoxHeader2);

            #endregion

            #region Header4

            //Tạo cột STT
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtCollumnNumber1";
            textBoxHeader3.Text = "A";
            header4.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;
            textBoxHeader.Font = fontSubHeader;

            //Tạo cột Chỉ tiêu
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtCollumnNumber2";
            textBoxHeader3.Text = "B";
            header4.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;
            textBoxHeader.Font = fontSubHeader;

            //Tạo cột tỷ lệ khấu hao
            textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxHeader3.Name = "txtCollumnNumber3";
            textBoxHeader3.Text = "1";
            header4.Controls.Add(textBoxHeader3);
            textBoxHeader3.Location = new Vector(8.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.Size = new Vector(2.9f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxHeader3.CanGrow = textBoxHeader3.GrowToBottom = true;
            textBoxHeader3.Border = oBorder;
            textBoxHeader3.Font = fontSubHeader;


            #endregion

            #region Detail

            //Tạo cột Ngay ghi so
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtPostedDate";
            textBoxDetail.Text = "";
            textBoxDetail.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;
            detail.Controls.Add(textBoxDetail);

            //Tạo cột Chỉ tiêu
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtEstimateItemName";
            textBoxDetail.Text = "";
            textBoxDetail.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(5f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;
            detail.Controls.Add(textBoxDetail);

            //Tạo cột tong so tien
            textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
            textBoxDetail.Name = "txtTotalAmount";
            textBoxDetail.Text = "";
            textBoxDetail.Location = new Vector(8.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.Size = new Vector(2.9f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
            textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
            textBoxDetail.Border = oBorder;
            detail.Controls.Add(textBoxDetail);
            detail.CanGrow = true;
            detail.GenerateScript = "txtEstimateItemName.Value = GetData(\"ItemName\").ToString(); " +
                                    "decimal totalAmount = GetData(\"TotalValue\")  == null ? 0 : decimal.Parse(GetData(\"TotalValue\").ToString());" +
                                    "if(totalAmount == 0) {txtTotalAmount.Value =\"\";} else {txtTotalAmount.Value =  totalAmount;}" +
                                    "txtTotalAmount.TextFormat = (PerpetuumSoft.Framework.Text.TextFormat)GetData(\"RssObject.CurrencyFormat\");" +
                                    "txtTotalAmount.TextFormat.CurrencySymbol = \"\";" +
                                    "txtPostedDate.Value = GetData(\"PostedDate\") == null || DateTime.Parse(GetData(\"PostedDate\").ToString()).ToShortDateString() == \"01/01/0001\" ? \"\" : DateTime.Parse(GetData(\"PostedDate\").ToString()).ToShortDateString();"
                                    + "int isBold;" +
                                    "isBold = int.Parse(GetData(\"IsBold\").ToString());" +
                                    "if (isBold == 1)" +
                                    "{" +
                                    "    txtPostedDate.StyleName = \"DetailNormalBold\";" +
                                    "    txtEstimateItemName.StyleName = \"DetailNormalBold\";" +
                                    "    txtTotalAmount.StyleName = \"DetailNormalBold\";" +
                                    "}" +
                                    "else" +
                                    "{" +
                                    "    txtPostedDate.StyleName = \"DetailNormal\";" +
                                    "    txtEstimateItemName.StyleName = \"DetailNormal\";" +
                                    "    txtTotalAmount.StyleName = \"DetailNormal\";" +
                                    "}"
                                    + "txtEstimateItemName.CanGrow = true; "
                                    + "txtEstimateItemName.GrowToBottom = true; "
                                    + "txtTotalAmount.CanGrow = true; "
                                    + "txtTotalAmount.GrowToBottom = true; "
                                    + "txtPostedDate.CanGrow = true; "
                                    + "txtPostedDate.GrowToBottom = true; ";

            #endregion

            #region Gen page 1

            double marginLeft = 11.6f;
            int countDynamicColumn = 0;
            int numberheader3 = 3;

            Dictionary<string, Type> fieldList = new Dictionary<string, Type>();

            foreach (DataColumn dtCol in dtSource.Columns)
            {
                if (dtCol.Caption.StartsWith("0") || dtCol.Caption.StartsWith("1") || dtCol.Caption.StartsWith("2") || dtCol.Caption.StartsWith("3") || dtCol.Caption.StartsWith("4") || dtCol.Caption.StartsWith("5") || dtCol.Caption.StartsWith("6") || dtCol.Caption.StartsWith("7") || dtCol.Caption.StartsWith("8") || dtCol.Caption.StartsWith("9") || dtCol.Caption.StartsWith("XXX"))
                {
                    fieldList.Add(dtCol.ColumnName, dtCol.DataType);
                }

            }
            var fieldlistOrder = fieldList.OrderBy(r => r.Key).ToList();
            int surPlus = (fieldList.Count - 3) % 10;
            int pageIndex =
                (fieldList.Count - 3) / 10;
            if (surPlus > 0) pageIndex = pageIndex + 2;
            else pageIndex = pageIndex + 1;

            var listpage1 = fieldlistOrder.Skip(0).Take(3);
            var x = 2;
            foreach (var dtColumn in listpage1)
            {
                //Tạo header
                if (dtColumn.Key.StartsWith("0") || dtColumn.Key.StartsWith("1") || dtColumn.Key.StartsWith("2") || dtColumn.Key.StartsWith("3") || dtColumn.Key.StartsWith("4") || dtColumn.Key.StartsWith("5") || dtColumn.Key.StartsWith("6") || dtColumn.Key.StartsWith("7") || dtColumn.Key.StartsWith("8") || dtColumn.Key.StartsWith("9") || dtColumn.Key.StartsWith("XXX"))
                {
                    #region Header

                    textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader.Name = "txt" + dtColumn.Key.Replace("Dynamic", "");
                    if (dtColumn.Key.StartsWith("XXX"))
                        textBoxHeader.Text = "<<Tổng hợp>>";
                    else
                        textBoxHeader.Text = "Khoản " + dtColumn.Key.Replace("Dynamic", "");
                    header3.Controls.Add(textBoxHeader);
                    textBoxHeader.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 1f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxHeader.CanGrow = textBoxHeader.GrowToBottom = true;
                    textBoxHeader.Border = oBorder;
                    textBoxHeader.Font = fontHeader;

                    textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader.Name = "txt" + x.ToString();
                    textBoxHeader.Text = x.ToString();
                    header4.Controls.Add(textBoxHeader);
                    textBoxHeader.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 0.5f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxHeader.CanGrow = textBoxHeader.GrowToBottom = true;
                    textBoxHeader.Border = oBorder;
                    textBoxHeader.Font = fontSubHeader;

                    #endregion

                    #region Detail

                    textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxDetail.Name = "txtDetail" + dtColumn.Key.Replace("Dynamic", "");
                    textBoxDetail.Text = dtColumn.Key.Replace("Dynamic", "");
                    textBoxDetail.GenerateScript =
                        "decimal detailValue = decimal.Parse(GetData(\"" + dtColumn.Key + "\").ToString());"
                        + "if (detailValue == 0)"
                        + "{" + textBoxDetail.Name.ToString() + ".Value= \"\"; } "
                        + "else {" + textBoxDetail.Name.ToString() + ".Value = detailValue;}"
                        + textBoxDetail.Name + ".TextFormat = "
                        +
                        "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");"
                        + textBoxDetail.Name + ".TextFormat.CurrencySymbol = \"\";"
                        + "int itemType = int.Parse(GetData(\"ItemType\").ToString());"
                    + "if (itemType == 1 || itemType == 4 || itemType == 3 || itemType == 6 || itemType == 7)"
                    + "{" + textBoxDetail.Name + ".StyleName = \"DetailNormalBold\";}"
                    + "else {" + textBoxDetail.Name + ".StyleName = \"DetailNormal\" ;}"
                            + textBoxDetail.Name + ".CanGrow = true; "
                            + textBoxDetail.Name + ".GrowToBottom = true; ";

                    //textBoxDetail.GenerateScript =
                    //    textBoxDetail.Name.ToString() + ".Value=GetData(\"" + dtColumn.Key + "\").ToString(); ";
                    textBoxDetail.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetail.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 0.6f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                    textBoxDetail.Border = oBorder;
                    detail.Controls.Add(textBoxDetail);

                    countDynamicColumn = countDynamicColumn + 1;
                    marginLeft = marginLeft + 2.8f;

                    #endregion

                    x++;
                }
            }
            var j = 3;
            for (int i = countDynamicColumn; i < 3; i++)
            {
                var col = 3 - countDynamicColumn;

                #region Header

                textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader.Name = "txt" + i.ToString();
                header3.Controls.Add(textBoxHeader);
                textBoxHeader.Location =
                    new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxHeader.Size =
                    new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 1f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader.CanGrow = textBoxHeader.GrowToBottom = true;
                textBoxHeader.Border = oBorder;
                textBoxHeader.Font = fontHeader;

                textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader.Name = "txt" + j.ToString();
                textBoxHeader.Text = j.ToString(); ;
                header4.Controls.Add(textBoxHeader);
                textBoxHeader.Location =
                    new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxHeader.Size =
                    new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 0.5f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader.CanGrow = textBoxHeader.GrowToBottom = true;
                textBoxHeader.Border = oBorder;
                textBoxHeader.Font = fontSubHeader;

                #endregion

                #region detail

                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txtDetail" + i.ToString();
                textBoxDetail.Text = "";
                textBoxDetail.Location =
                    new PerpetuumSoft.Framework.Drawing.Vector(marginLeft, 0f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxDetail.Size =
                    new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 0.6f).ConvertUnits(Unit.Centimeter,
                        Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                detail.CanGrow = textBoxDetail.GrowToBottom = true;
                detail.Controls.Add(textBoxDetail);
                textBoxDetail.Border = oBorder;

                #endregion

                marginLeft = marginLeft + 2.8f;
                j++;
            }

            #endregion

            #region Page 2

            var quantity = 0;
            var k = 4;
            //page 2
            for (int n = 2; n <= pageIndex; n++)
            {
                double marginLeftN = 11.6f;

                #region  Page component
                var listpageN = fieldlistOrder.Skip((n - 1) * 3).Take(3);
                int countDynamicColumnN = 0;
                var pagen = "page" + n;
                Page checkpage = (Page)doc.ControlByName("page" + n);
                if (checkpage != null) doc.Pages.Remove(checkpage);

                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader1N = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxHeader3N = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textBoxFooter1 = new PerpetuumSoft.Reporting.DOM.TextBox();

                Page page = new Page();
                page.Name = "page" + n;
                page.Margins = new Margins(1f, 1f, 1.1f, 1.1f);
                page.Orientation = PageOrientation.Portrait;
                doc.Pages.Add(page);

                PageHeader pageHeader = new PageHeader();
                pageHeader.Name = "ReportHeader" + n;
                pageHeader.Location = new Vector(0f, 1.3f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                pageHeader.Size = new Vector(21f, 1.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                page.Controls.Add(pageHeader);
                pageHeader.GenerateScript = "txtCompanyNameN.Value = \"Đơn vị: \" + GetParameter(\"CompanyName\").ToString();"
                                            + "txtCompanyCodeN.Value = \"Mã QHNS: \" + GetParameter(\"CompanyCode\") == null ? \"\" : GetParameter(\"CompanyCode\").ToString();";

                PageFooter pagefooter = new PageFooter();
                pagefooter.Name = "pagefooter" + n;
                //textBoxFooter = new PerpetuumSoft.Reporting.DOM.TextBox();
                //textBoxFooter.Name = "txtfooter" + n;
                pagefooter.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 22.7f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                pagefooter.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 0.5f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                //textBoxFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                page.Controls.Add(pagefooter);

                DataBand dataBand = new DataBand();
                dataBand.Name = "dataBandDyna" + n;
                page.Controls.Add(dataBand);
                dataBand.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.2f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                dataBand.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 11f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                dataBand.DataSource = "S101H";

                GroupBand groupBand1N = new GroupBand();
                groupBand1N.Name = "groupBandDyna" + n;

                groupBand1N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                groupBand1N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 10.2f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                groupBand1N.GroupExpression = "GetData(\"AccountNumber\").ToString() + GetData(\"BudgetSourceKind\").ToString() + GetData(\"BudgetChapterCode\").ToString()";
                groupBand1N.NewPageBefore = true;
                dataBand.Controls.Add(groupBand1N);

                GroupBand groupBand2N = new GroupBand();
                groupBand2N.Name = "groupBand2Dyna" + n;
                groupBand1N.Controls.Add(groupBand2N);
                groupBand2N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 6.5f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                groupBand2N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 4.2).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                groupBand2N.GroupExpression = "GetData(\"AccountNumber\").ToString() + GetData(\"BudgetSourceKind\").ToString() + GetData(\"BudgetChapterCode\").ToString() + GetData(\"ProjectId\").ToString() + GetData(\"BudgetGroupItemCode\").ToString()";

                GroupBand groupBand3N = new GroupBand();
                groupBand3N.Name = "groupBand3Dyna" + n;
                groupBand2N.Controls.Add(groupBand3N);
                groupBand3N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 1.4f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                groupBand2N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 2.4f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                //groupBand3N.GroupExpression = "GetData(\"AccountNumber\").ToString() + GetData(\"BudgetSourceCategoryId\").ToString()";
                groupBand3N.GroupExpression = "GetData(\"AccountNumber\").ToString() + GetData(\"BudgetSourceKind\").ToString() + GetData(\"BudgetChapterCode\").ToString() + GetData(\"ProjectId\").ToString() + GetData(\"BudgetGroupItemCode\").ToString()";

                Header header1N = new Header();
                dataBand.Controls.Add(header1N);
                header1N.Name = "header1N" + n;
                header1N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.8f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header1N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21, 2f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header1N.StyleName = "HeaderFooter2Bold";
                header1N.GenerateScript = "txtPeriodN.Text = RSSHelper.DateToWord.ReadDate(DateTime.Parse(GetParameter(\"FromDate\").ToString()), DateTime.Parse(GetParameter(\"ToDate\").ToString())); "
                + "string accountNumber = GetData(\"AccountNumber\").ToString() == \"XXX\" ? \"<<Tổng hợp>>\" : GetData(\"AccountNumber\").ToString();" +
                "txtAccountNameN.Value = \"Tài khoản: \" + accountNumber; ";
                header1N.RepeatEveryPage = true;


                Header header2N = new Header();
                dataBand.Controls.Add(header2N);
                header2N.Name = "header2N" + n;
                header2N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 3.2f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header2N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21, 1f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header2N.StyleName = "HeaderFooter2Bold";
                header2N.GenerateScript = "string budgetChapterCode = GetData(\"BudgetChapterCode\").ToString() == \"XXX\" ? \"<<Tổng hợp>>\" : GetData(\"BudgetChapterCode\").ToString();" +
                "txtBudgetSourceCategoryCode.Text = \"Kinh phí: \" + GetData(\"BudgetSourceCategoryName\").ToString() + \" - Chương: \" + budgetChapterCode;";

                Header header3N = new Header();
                groupBand1N.Controls.Add(header3N);
                header3N.Name = "header3N" + n;
                header3N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 4.2f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header3N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 1f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header3N.StyleName = "HeaderFooter2Bold";
                header3N.RepeatEveryPage = true;

                Header header4N = new Header();
                groupBand1N.Controls.Add(header4N);
                header4N.Name = "header4N" + n;
                header4N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 5.6f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header4N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 0.5f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header4N.StyleName = "HeaderFooter2Bold";
                //header4N.RepeatEveryPage = true;

                Header header5N = new Header();
                groupBand2N.Controls.Add(header5N);
                header5N.Name = "header5N" + n;
                header5N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header5N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 0.6f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header5N.StyleName = "HeaderFooter2Bold";

                Header header6N = new Header();
                groupBand3N.Controls.Add(header6N);
                header6N.Name = "header6N" + n;
                header6N.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 0.4f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header6N.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 0.6f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                header6N.StyleName = "HeaderFooter2Bold";

                Detail detailN = new Detail();
                detailN.Name = "detailN" + n;
                groupBand3N.Controls.Add(detailN);
                detailN.Location = new PerpetuumSoft.Framework.Drawing.Vector(0f, 1.3f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                detailN.Size = new PerpetuumSoft.Framework.Drawing.Vector(21f, 0.6f).ConvertUnits(Unit.Centimeter,
                    Unit.InternalUnit);
                detailN.CanGrow = true;

                #endregion
                #region ReportHeader
                //Teen don vi
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtCompanyNameN";
                textBoxHeader2.Text = "";
                pageHeader.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(10f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxHeader2.Font = fontHeader;

                //Ma don vi
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtCompanyCodeN";
                textBoxHeader2.Text = "";
                pageHeader.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(10f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxHeader2.Font = fontSubHeader;

                //Mẫu số: S101-H
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtFormNoN";
                textBoxHeader2.Text = "Mẫu số: S101-H";
                pageHeader.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(12f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.Font = fontHeader;

                //(Ban hành theo Thông tư số 107/2017/TT-BTC
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtIssueByN";
                textBoxHeader2.Text = "(Ban hành theo Thông tư số 107/2017/TT-BTC ";
                pageHeader.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(12f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.Font = fontSubHeader;

                //ngày 10 / 10 / 2017 của Bộ Tài chính)
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtIssueBy1N";
                textBoxHeader2.Text = "ngày 10 / 10 / 2017 của Bộ Tài chính)";
                pageHeader.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(12f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(8f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Font = fontSubHeader;

                #endregion

                #region Header1

                //SỔ THEO DÕI DỰ TOÁN TỪ NGUỒN NSNN TRONG NƯỚC
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtReportTitleN";
                textBoxHeader2.Text = "SỔ THEO DÕI DỰ TOÁN TỪ NGUỒN NSNN TRONG NƯỚC";
                header1N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(18.5f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.Font = fontHeader;


                //Tài khoản: {0}
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtAccountNameN";
                textBoxHeader2.Text = "Tài khoản: {0}";
                header1N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(18.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.Font = fontSubHeader;

                //Tháng {0}....năm {1}....
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtPeriodN";
                textBoxHeader2.Text = "Tháng {0}....năm {1}....";
                header1N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 1.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(18.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.Font = fontSubHeader;

                #endregion

                #region Header2

                //I. Dự toán NSNN giao
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtPartNameN";
                textBoxHeader2.Text = "I. Dự toán NSNN giao";
                header2N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(18.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxHeader2.Font = fontHeader;

                //Kinh phí: {0}
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtBudgetSourceCategoryCodeN";
                textBoxHeader2.Text = "Kinh phí: {0}";
                header2N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(18.5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Font = fontSubHeader;

                #endregion

                #region Header3

                //Tạo cột STT
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtPostedDateHeaderN";
                textBoxHeader2.Text = "Ngày ghi sổ";
                header3N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(2.2f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Border = oBorder;
                textBoxHeader2.Font = fontHeader;

                //Tạo cột Chỉ tiêu
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtItemHeaderN";
                textBoxHeader2.Text = "Chỉ tiêu";
                header3N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(5f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Border = oBorder;
                textBoxHeader2.Font = fontHeader;

                //Tạo cột Tổng số
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtTotalAmountHeaderN";
                textBoxHeader2.Text = "Tổng số";
                header3N.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(8.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(2.9f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Border = oBorder;
                textBoxHeader2.Font = fontHeader;

                #endregion

                #region Header4

                //Tạo cột STT
                textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader3.Name = "txtCollumnNumber1N";
                textBoxHeader3.Text = "A";
                header4N.Controls.Add(textBoxHeader3);
                textBoxHeader3.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.Size = new Vector(2.2f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader3.CanGrow = textBoxHeader3.GrowToBottom = true;
                textBoxHeader3.Border = oBorder;
                textBoxHeader3.Font = fontSubHeader;

                //Tạo cột Chỉ tiêu
                textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader3.Name = "txtCollumnNumber2N";
                textBoxHeader3.Text = "B";
                header4N.Controls.Add(textBoxHeader3);
                textBoxHeader3.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.Size = new Vector(5f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader3.CanGrow = textBoxHeader3.GrowToBottom = true;
                textBoxHeader3.Border = oBorder;
                textBoxHeader3.Font = fontSubHeader;

                //Tạo cột tổng số tiền
                textBoxHeader3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader3.Name = "txtCollumnNumber3N";
                textBoxHeader3.Text = "1";
                header4N.Controls.Add(textBoxHeader3);
                textBoxHeader3.Location = new Vector(8.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.Size = new Vector(2.9f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader3.CanGrow = textBoxHeader3.GrowToBottom = true;
                textBoxHeader3.Border = oBorder;
                textBoxHeader3.Font = fontSubHeader;


                #endregion

                #region Footer
                //Page Number
                textBoxHeader2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxHeader2.Name = "txtPageNumberN";
                pagefooter.Controls.Add(textBoxHeader2);
                textBoxHeader2.Location = new Vector(9.4f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.Size = new Vector(10.6f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxHeader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxHeader2.CanGrow = textBoxHeader2.GrowToBottom = true;
                textBoxHeader2.Font = fontSubHeader;
                textBoxHeader2.GenerateScript = "txtPageNumber.Text = PageNumber.ToString();";
                #endregion

                #region Header 5
                //Tạo cột 1
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txtHeader5" + k;
                textBoxDetail.Text = "";
                header5N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột Chỉ tiêu
                textBoxDetail5 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail5.Name = "txtEstimateItemName5" + k;
                textBoxDetail5.Text = "";
                header5N.Controls.Add(textBoxDetail5);
                textBoxDetail5.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail5.Size = new Vector(5f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxDetail5.CanGrow = textBoxDetail5.GrowToBottom = true;
                textBoxDetail5.Border = oBorder;
                textBoxDetail5.GenerateScript = "string projectCode = GetData(\"ProjectCode\").ToString() == \"XXX\" ? \"<<Tổng hợp>>\" : GetData(\"ProjectCode\").ToString(); " +
                textBoxDetail5.Name +  ".Value = \"Mã CTMT, DA: \" + projectCode;";

                //Tạo cột tong so tien
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txtTotalAmount5" + k;
                textBoxDetail.Text = "";
                header5N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(8.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(2.9f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt51" + k;
                textBoxDetail.Text = "";
                header5N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(11.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(2.8f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt51" + k;
                textBoxDetail.Text = "";
                header5N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(14.3f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(2.8f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt51" + k;
                textBoxDetail.Text = "";
                header5N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(17.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(2.8f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;
                #endregion

                #region Header 6
                //Tạo cột 1
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txtHeader6" + k;
                textBoxDetail.Text = "";
                header6N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột Chỉ tiêu
                textBoxDetail6 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail6.Name = "txtEstimateItemName6" + k;
                textBoxDetail6.Text = "";
                header6N.Controls.Add(textBoxDetail6);
                textBoxDetail6.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail6.Size = new Vector(5f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxDetail6.CanGrow = textBoxDetail6.CanShrink = textBoxDetail6.GrowToBottom = true;
                textBoxDetail6.Border = oBorder;
                textBoxDetail6.GenerateScript = "string budgetItemCode = GetData(\"BudgetGroupItemCode\").ToString() == \"XXX\" ? \"\" : GetData(\"BudgetGroupItemCode\").ToString();" +
                textBoxDetail6.Name + ".Value = \"Mã MLNS: \" + budgetItemCode;";

                //Tạo cột tong so tien
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txtTotalAmount6" + k;
                textBoxDetail.Text = "";
                header6N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(8.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(2.9f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt61" + k;
                textBoxDetail.Text = "";
                header6N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(11.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(2.8f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt61" + k;
                textBoxDetail.Text = "";
                header6N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(14.3f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(3f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;

                //Tạo cột trống
                textBoxDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetail.Name = "txt61" + k;
                textBoxDetail.Text = "";
                header6N.Controls.Add(textBoxDetail);
                textBoxDetail.Location = new Vector(17.1f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.Size = new Vector(2.8f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetail.CanGrow = textBoxDetail.GrowToBottom = true;
                textBoxDetail.Border = oBorder;
                #endregion

                #region Detail
                //Tạo cột Ngay ghi so
                textBoxDetailDyna1 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetailDyna1.Name = "txtPostedDateN" + n;
                textBoxDetailDyna1.Text = "";
                textBoxDetailDyna1.Location = new Vector(1.5f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna1.Size = new Vector(2.2f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                textBoxDetailDyna1.CanGrow = textBoxDetailDyna1.GrowToBottom = true;
                textBoxDetailDyna1.Border = oBorder;
                detailN.Controls.Add(textBoxDetailDyna1);
                //Tạo cột Chỉ tiêu
                textBoxDetailDyna2 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetailDyna2.Name = "txtEstimateItemNameN" + n;
                textBoxDetailDyna2.Text = "";
                textBoxDetailDyna2.Location = new Vector(3.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna2.Size = new Vector(5f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                textBoxDetailDyna2.CanGrow = textBoxDetailDyna2.GrowToBottom = true;
                textBoxDetailDyna2.Border = oBorder;
                detailN.Controls.Add(textBoxDetailDyna2);

                //Tạo cột tong so tien
                textBoxDetailDyna3 = new PerpetuumSoft.Reporting.DOM.TextBox();
                textBoxDetailDyna3.Name = "txtTotalAmountN" + n;
                textBoxDetailDyna3.Text = "";
                textBoxDetailDyna3.Location = new Vector(8.7f, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna3.Size = new Vector(2.9f, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                textBoxDetailDyna3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                textBoxDetailDyna3.CanGrow = true;
                textBoxDetailDyna3.GrowToBottom = true;
                textBoxDetailDyna3.Border = oBorder;
                detailN.Controls.Add(textBoxDetailDyna3);
                detailN.GenerateScript = "txtEstimateItemNameN" + n + ".Value = GetData(\"ItemName\").ToString(); " +
                                "txtPostedDateN" + n + ".Value = GetData(\"PostedDate\") == null || DateTime.Parse(GetData(\"PostedDate\").ToString()).ToShortDateString() == \"01/01/0001\" ? \"\" : DateTime.Parse(GetData(\"PostedDate\").ToString()).ToShortDateString();"
                               + "decimal totalAmountN = GetData(\"TotalValue\")  == null ? 0 : decimal.Parse(GetData(\"TotalValue\").ToString());"
                               + "if(totalAmountN == 0) {txtTotalAmountN" + n + ".Value = \"\";} else {txtTotalAmountN" + n + ".Value =  totalAmountN;}"
                               + "txtTotalAmountN" + n + ".TextFormat = (PerpetuumSoft.Framework.Text.TextFormat)GetData(\"RssObject.CurrencyFormat\");"
                               + "txtTotalAmountN" + n + ".TextFormat.CurrencySymbol = \"\";"
                                + "int isBold;" +
                                "isBold = int.Parse(GetData(\"IsBold\").ToString());" +
                                "if (isBold == 1)" +
                                "{" +
                                "    txtPostedDateN" + n + ".StyleName = \"DetailNormalBold\";" +
                                "    txtTotalAmountN" + n + ".StyleName = \"DetailNormalBold\";" +
                                "    txtEstimateItemNameN" + n + ".StyleName = \"DetailNormalBold\";" +
                                "}" +
                                "else" +
                                "{" +
                                "    txtPostedDateN" + n + ".StyleName = \"DetailNormal\";" +
                                "    txtTotalAmountN" + n + ".StyleName = \"DetailNormal\";" +
                                "    txtEstimateItemNameN" + n + ".StyleName = \"DetailNormal\";" +
                                "}";


                #endregion

                foreach (var dtColumn in listpageN)
                {
                    if (dtColumn.Key.StartsWith("0") || dtColumn.Key.StartsWith("1") || dtColumn.Key.StartsWith("2") || dtColumn.Key.StartsWith("3") || dtColumn.Key.StartsWith("4") || dtColumn.Key.StartsWith("5") || dtColumn.Key.StartsWith("6") || dtColumn.Key.StartsWith("7") || dtColumn.Key.StartsWith("8") || dtColumn.Key.StartsWith("9") || dtColumn.Key.StartsWith("XXX"))
                    {
                        #region Header 

                        textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader2N.Name = "txt" + dtColumn.Key.Replace("Dynamic", "");
                        textBoxHeader2N.Text = "Khoản " + dtColumn.Key.Replace("Dynamic", "");
                        header3N.Controls.Add(textBoxHeader2N);
                        textBoxHeader2N.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxHeader2N.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 1f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader2N.CanGrow = textBoxHeader2N.GrowToBottom = true;
                        textBoxHeader2N.Border = oBorder;
                        textBoxHeader2N.Font = fontHeader;

                        textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader.Name = "txt" + k.ToString();
                        textBoxHeader.Text = k.ToString(); ;
                        header4N.Controls.Add(textBoxHeader);
                        textBoxHeader.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxHeader.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 0.5f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        textBoxHeader.CanGrow = textBoxHeader.GrowToBottom = true;
                        textBoxHeader.Border = oBorder;
                        textBoxHeader.Font = fontSubHeader;

                        #endregion

                        #region Detail


                        textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxDetailN.Name = "txtDetail" + dtColumn.Key.Replace("Dynamic", "");
                        textBoxDetailN.Text = dtColumn.Key.Replace("Dynamic", "");
                        textBoxDetailN.GenerateScript =
                            "decimal detailValue = decimal.Parse(GetData(\"" + dtColumn.Key + "\").ToString());"
                            + "if (detailValue == 0)"
                            + "{" + textBoxDetailN.Name.ToString() + ".Value= \"\"; } "
                            + "else {" + textBoxDetailN.Name.ToString() + ".Value = detailValue;}"
                            + textBoxDetailN.Name + ".TextFormat = "
                            + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");"
                            + textBoxDetailN.Name + ".TextFormat.CurrencySymbol = \"\";"
                            + "int itemType = int.Parse(GetData(\"ItemType\").ToString());"
                            + "if (itemType == 1 || itemType == 4 || itemType == 3 || itemType == 6 || itemType == 7)"
                            + "{" + textBoxDetailN.Name + ".StyleName = \"DetailNormalBold\";}"
                            + "else {" + textBoxDetailN.Name + ".StyleName = \"DetailNormal\" ;}"
                            + textBoxDetailN.Name + ".CanGrow = true; "
                            + textBoxDetailN.Name + ".GrowToBottom = true; ";
                        textBoxDetailN.Location =
                            new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxDetailN.Size =
                            new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 0.6f).ConvertUnits(Unit.Centimeter,
                                Unit.InternalUnit);
                        textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        textBoxDetailN.CanGrow = textBoxDetailN.GrowToBottom = true;
                        textBoxDetailN.Border = oBorder;
                        detailN.Controls.Add(textBoxDetailN);

                        countDynamicColumnN = countDynamicColumnN + 1;
                        marginLeftN = marginLeftN + 2.8f;

                        #endregion
                        k++;
                    }
                }
                var m = 4;
                for (int i = countDynamicColumnN; i < 3; i++)
                {
                    #region Header

                    textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader2N.Name = "txtN" + k.ToString();
                    header3N.Controls.Add(textBoxHeader2N);
                    textBoxHeader2N.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader2N.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 1f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader2N.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxHeader2N.CanGrow = textBoxHeader2N.GrowToBottom = true;
                    textBoxHeader2N.Border = oBorder;
                    textBoxHeader2N.Font = fontHeader;

                    textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader.Name = "txt" + m.ToString();
                    textBoxHeader.Text = ""; ;
                    header4N.Controls.Add(textBoxHeader);
                    textBoxHeader.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 0.5f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxHeader.CanGrow = textBoxHeader.CanShrink = textBoxHeader.GrowToBottom = true;
                    textBoxHeader.Border = oBorder;
                    textBoxHeader.Font = fontSubHeader;

                    #endregion

                    #region detail

                    textBoxDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxDetailN.Name = "txtDetailN" + k.ToString();
                    textBoxDetailN.Text = "";
                    detailN.Controls.Add(textBoxDetailN);
                    textBoxDetailN.Location =
                        new PerpetuumSoft.Framework.Drawing.Vector(marginLeftN, 0f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetailN.Size =
                        new PerpetuumSoft.Framework.Drawing.Vector(2.8f, 0.6f).ConvertUnits(Unit.Centimeter,
                            Unit.InternalUnit);
                    textBoxDetailN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    textBoxDetailN.CanGrow = textBoxDetailN.GrowToBottom = true;
                    textBoxDetailN.Border = oBorder;
                    textBoxDetailN.GenerateScript =
                            textBoxDetailN.Name + ".CanGrow = true; "
                            + textBoxDetailN.Name + ".GrowToBottom = true; ";

                    #endregion

                    marginLeftN = marginLeftN + 2.8f;

                    m++;

                }
                k = k + 1;
            }

            #endregion

            //reportSlot.DesignTemplate();
            reportSlot.SaveReport(doc);


        }

        public bool RenderDynamicReportMultiPage(DataTable dtSource, string ReportFileName, double pmargin)
        {

            GlobalVariable.IsDisplayNewLicenseInfo = false;
            try
            {
                var reportSlot = new FileReportSlot { FilePath = GlobalVariable.ReportPath + ReportFileName };

                Document doc = reportSlot.LoadReport();


                int pag = doc.Pages.Count;
                for (int i = 1; i < pag; i++)
                {
                    doc.Pages.RemoveAt(i);
                }
                PerpetuumSoft.Reporting.DOM.TextBox txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox textSubHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                PerpetuumSoft.Reporting.DOM.TextBox txtDetail = new PerpetuumSoft.Reporting.DOM.TextBox();

                FontDescriptor fontHead = new FontDescriptor("Times New Roman", 9, FontStyleMode.On, FontStyleMode.Off,
                    FontStyleMode.Off);

                // Page header
                PageHeader pageHeader = (PageHeader)doc.ControlByName("ReportHeader");

                // Data band
                DataBand dBand = (DataBand)doc.ControlByName("dataBand1");

                // Group band
                GroupBand gBand = (GroupBand)doc.ControlByName("groupBand1");
                GroupBand groupBand1 = (GroupBand)doc.ControlByName("groupBand1");
                GroupBand groupBand2 = (GroupBand)doc.ControlByName("groupBand2");
                GroupBand groupBand3 = (GroupBand)doc.ControlByName("groupBand3");

                // Header
                Header header = (Header)doc.ControlByName("header1");
                Header header1 = (Header)doc.ControlByName("header1");
                Header header2 = (Header)doc.ControlByName("header2");
                Header header3 = (Header)doc.ControlByName("header3");
                Header header4 = (Header)doc.ControlByName("header4");
                Header header5 = (Header)doc.ControlByName("header5");
                Header header6 = (Header)doc.ControlByName("header6");

                // Detail
                Detail detail = (Detail)doc.ControlByName("DetailGroup");

                // Footer 
                PageFooter pageFooter = (PageFooter)doc.ControlByName("pageFooter");

                header1.Controls.Clear();
                header2.Controls.Clear();
                header3.Controls.Clear();
                header4.Controls.Clear();
                header5.Controls.Clear();
                header6.Controls.Clear();
                detail.Controls.Clear();


                Border oBorder = new Border();
                BorderLine oBorderLine = new BorderLine();
                oBorderLine.Width = 1;
                oBorderLine.Color = System.Drawing.Color.Black;
                oBorderLine.Style = PerpetuumSoft.Framework.Drawing.LineStyle.Solid;
                oBorder = new Border(oBorderLine, oBorderLine, oBorderLine, oBorderLine);

                string columnName = "";
                string columnAlias = "";
                string subHeader = "";

                string alignment = "";
                int countcolumn = 0;

                double width = 0;
                double height = 0;
                double xPos = pmargin;
                double yPos = 0;
                double widthDynamic = 0;
                double widthPlus = 0;
                DataTable dtFixColumn = new DataTable();
                DataTable dtDynamicGroupColumn = new DataTable();
                DataTable dtDynamicDetailColumn = new DataTable();
                int countGroupPage = 0;

                //Lấy những cột fix cố định ở các trang báo cáo 
                var objFixColumn = dtSource.AsEnumerable().Where(x =>
                    x.Field<bool>("IsDetail") == true && x.Field<bool>("IsDynamic") == false);
                if (objFixColumn.Any())
                {
                    dtFixColumn = objFixColumn.CopyToDataTable();
                }
                //Lấy những cột group gen động 
                var objDynamicGroupColumn = dtSource.AsEnumerable().Where(x =>
                    x.Field<bool>("IsDetail") == false && x.Field<bool>("IsDynamic") == true);
                if (objDynamicGroupColumn.Any())
                {
                    dtDynamicGroupColumn = objDynamicGroupColumn.CopyToDataTable();
                }

                foreach (DataRow drDynamic in dtDynamicGroupColumn.Rows) //mỗi 1 group gen động tạo ra 1 trang mới
                {
                    if (countGroupPage == 0) // Trang dau
                    {
                        width = 0;
                        height = 0;
                        xPos = pmargin;
                        yPos = 0;
                        widthDynamic = 0;
                        widthPlus = 0;
                        ///Add cột fix
                        foreach (DataRow drFix in dtFixColumn.Rows)
                        {
                            columnName = drFix["PayrollItemColumnID"].ToString();
                            columnAlias = drFix["TitleColumn"].ToString();
                            subHeader = drFix["SubHeader"].ToString();
                            width = Double.Parse(drFix["Width"].ToString());
                            height = Double.Parse(drFix["Height"].ToString());
                            alignment = drFix["Alignment"].ToString();

                            //tạo header
                            txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                            txtHeader.Name = "txtHeader" + columnName + countGroupPage;
                            txtHeader.Text = columnAlias;
                            header.Controls.Add(txtHeader);
                            txtHeader.Location =
                                new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtHeader.Size = new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            txtHeader.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                            txtHeader.Border = oBorder;
                            txtHeader.Font = fontHead;

                            //tạo subheader
                            textSubHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                            textSubHeader.Name = "txtSubHeader" + columnName + countGroupPage;
                            textSubHeader.Text = subHeader;
                            header3.Controls.Add(textSubHeader);
                            textSubHeader.Location =
                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textSubHeader.Size =
                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            textSubHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            textSubHeader.CanGrow = textSubHeader.CanShrink = textSubHeader.GrowToBottom = true;
                            textSubHeader.Border = oBorder;
                            textSubHeader.Font = fontHead;

                            //Tạo detail
                            txtDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                            txtDetail.Name = "txtDetail" + columnName + countGroupPage;
                            txtDetail.Text = "";
                            detail.Controls.Add(txtDetail);
                            txtDetail.Location = new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtDetail.Size = new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                            txtDetail.CanGrow = txtDetail.CanShrink = txtDetail.GrowToBottom = true;
                            txtDetail.Border = oBorder;

                            txtDetail.GenerateScript = txtDetail.Name + ".Value=GetData(\"" +
                                                       columnName + "\").ToString();"
                                                       + txtDetail.Name + ".TextFormat = "
                                                       +
                                                       "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                       txtDetail.Name +
                                                       ".TextAlign = System.Drawing.ContentAlignment." + alignment + ";";
                            //+ "if(GetData(\"IsBold\").ToString()==\"True\") "
                            //+ "{" + txtDetail.Name + ".StyleName  =  \"DetailNormalBold\";}"
                            //+ "else {" + txtDetail.Name + ".StyleName =  \"DetailNormal\";}";

                            xPos = xPos + width;
                        }
                        //Add cột group động

                        columnName = drDynamic["PayrollItemColumnID"].ToString();
                        columnAlias = drDynamic["TitleColumn"].ToString();
                        subHeader = drDynamic["SubHeader"].ToString();
                        width = Double.Parse(drDynamic["Width"].ToString());
                        height = Double.Parse(drDynamic["Height"].ToString());
                        alignment = drDynamic["Alignment"].ToString();

                        //tạo header
                        txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                        txtHeader.Name = "txtHeader" + columnName + countGroupPage;
                        txtHeader.Text = columnAlias;
                        header.Controls.Add(txtHeader);
                        txtHeader.Location =
                            new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        txtHeader.Size = new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        txtHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        txtHeader.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                        txtHeader.Border = oBorder;
                        txtHeader.Font = fontHead;
                        yPos = height;
                        widthDynamic = width;

                        //Add cột detail động
                        var objDynamicDetailColumn = dtSource.AsEnumerable().Where(x =>
                            x.Field<string>("ParentID") == drDynamic["PayrollItemColumnID"].ToString()).ToList();
                        //phân trang 4 detail trên 1 báo cáo

                        int surPlus = (objDynamicDetailColumn.ToList().Count - 4) % 10;
                        int pageIndex =
                            (objDynamicDetailColumn.Count - 4) / 10;
                        if (surPlus > 0) pageIndex = pageIndex + 2;
                        else pageIndex = pageIndex + 1;
                        for (int n = 1; n <= pageIndex; n++)
                        {

                            if (objDynamicDetailColumn.Any())
                            {
                                if (n == 1)
                                {
                                    dtDynamicDetailColumn = objDynamicDetailColumn.Skip(0).Take(4).CopyToDataTable();
                                    foreach (DataRow drDetail in dtDynamicDetailColumn.Rows)
                                    {
                                        if (drDetail["IsDetail"].ToString() == "True")
                                        {
                                            columnName = drDetail["PayrollItemColumnID"].ToString();
                                            columnAlias = drDetail["TitleColumn"].ToString();
                                            subHeader = drDetail["SubHeader"].ToString();
                                            width = Double.Parse(drDetail["Width"].ToString());
                                            height = Double.Parse(drDetail["Height"].ToString());
                                            alignment = drDetail["Alignment"].ToString();

                                            txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            txtHeader.Name = "txtHeader" + columnName;
                                            txtHeader.Text = columnAlias;
                                            header.Controls.Add(txtHeader);
                                            txtHeader.Location =
                                                new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            txtHeader.Size =
                                                new Vector(width, height).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);
                                            txtHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                            txtHeader.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                                            txtHeader.Border = oBorder;
                                            txtHeader.Font = fontHead;

                                            textSubHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            textSubHeader.Name = "txtSubHeader" + columnName;
                                            textSubHeader.Text = subHeader;
                                            header3.Controls.Add(textSubHeader);
                                            textSubHeader.Location =
                                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            textSubHeader.Size =
                                                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);
                                            textSubHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                            textSubHeader.CanGrow =
                                                textSubHeader.CanShrink = textSubHeader.GrowToBottom = true;
                                            textSubHeader.Border = oBorder;
                                            textSubHeader.Font = fontHead;

                                            txtDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                                            txtDetail.Name = "txtDetail" + columnName;
                                            txtDetail.Text = "";
                                            detail.Controls.Add(txtDetail);
                                            txtDetail.Location =
                                                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                            txtDetail.Size =
                                                new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter,
                                                    Unit.InternalUnit);

                                            txtDetail.CanGrow = txtDetail.CanShrink = txtDetail.GrowToBottom = true;
                                            txtDetail.Border = oBorder;

                                            if (drDetail["DataType"].ToString() == "3")
                                            {
                                                txtDetail.GenerateScript =
                                                    txtDetail.Name + ".Value=decimal.Parse(GetData(\"" +
                                                    columnName + "\").ToString()) ==0 ?\"\" : " +
                                                    "GetData(\"" + columnName + "\").ToString();"
                                                    + txtDetail.Name + ".TextFormat = "
                                                    + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                                    txtDetail.Name +
                                                    ".TextAlign = System.Drawing.ContentAlignment." +
                                                    alignment + ";"
                                                    + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                                    + "{" + txtDetail.Name +
                                                    ".StyleName  =  \"DetailNormalBold\";}"
                                                    + "else {" + txtDetail.Name +
                                                    ".StyleName =  \"DetailNormal\";}";
                                            }

                                            xPos = xPos + width;
                                            if (drDetail["IsDynamic"].ToString() == "True")
                                            {
                                                widthPlus = widthPlus + width;
                                            }
                                        }
                                    }

                                    while (widthPlus < widthDynamic)
                                    {
                                        txtHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        txtHeader.Name = "txtHeaderP" + countGroupPage + countcolumn;
                                        header.Controls.Add(txtHeader);
                                        txtHeader.Location =
                                            new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtHeader.Size =
                                            new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                        txtHeader.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                                        txtHeader.Border = oBorder;
                                        txtHeader.Font = fontHead;

                                        textSubHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        textSubHeader.Name = "txtSubHeaderP" + countGroupPage + countcolumn;
                                        header3.Controls.Add(textSubHeader);
                                        textSubHeader.Location =
                                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        textSubHeader.Size =
                                            new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        textSubHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                        textSubHeader.CanGrow =
                                            textSubHeader.CanShrink = textSubHeader.GrowToBottom = true;
                                        textSubHeader.Border = oBorder;
                                        textSubHeader.Font = fontHead;

                                        txtDetail = new PerpetuumSoft.Reporting.DOM.TextBox();
                                        txtDetail.Name = "txtDetailP" + countGroupPage + countcolumn;
                                        txtDetail.Text = "";
                                        detail.Controls.Add(txtDetail);
                                        txtDetail.Location =
                                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                        txtDetail.Size =
                                            new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);

                                        txtDetail.CanGrow = txtDetail.CanShrink = txtDetail.GrowToBottom = true;
                                        txtDetail.Border = oBorder;

                                        xPos = xPos + width;
                                        countcolumn = countcolumn + 1;
                                        widthPlus = widthPlus + width;
                                    }
                                    countGroupPage = countGroupPage + 1;
                                }
                                else
                                {
                                    #region tạo trang mới

                                    //width = 0;
                                    //height = 0;
                                    //xPos = pmargin;
                                    //yPos = 0;
                                    //widthDynamic = 0;
                                    //widthPlus = 0;
                                    ////Khởi tạo page mới
                                    //Page pageN = new Page();
                                    //pageN.Orientation = PageOrientation.Landscape;
                                    //pageN.Name = "page" + countGroupPage;

                                    ////Khởi tạo DataBand mới
                                    //DataBand dBandN = new DataBand();
                                    //dBandN.DataSource = dBand.DataSource;
                                    //dBandN.Size = dBand.Size;
                                    //dBandN.Location = dBand.Location;
                                    //dBandN.Name = dBand.Name + countGroupPage;
                                    //dBandN.Controls.Clear();

                                    ////Khởi tạo GroupBand mới
                                    //GroupBand gBandN = new GroupBand();
                                    //gBandN.GroupExpression = gBand.GroupExpression;
                                    //gBandN.Location = gBand.Location;
                                    //gBandN.Size = gBand.Size;
                                    //gBandN.Name = gBand.Name + countGroupPage;
                                    //gBandN.Controls.Clear();

                                    ////Khởi tạo header,subheader,detail mới (lấy properties size,font,location theo header ở page 1  )
                                    //Header header1N = new Header();
                                    //header1N.Size = header1.Size;
                                    //header1N.Location = header1.Location;
                                    //header1N.CanGrow = header1.CanGrow;
                                    //header1N.CanBreak = header1.CanBreak;
                                    //header1N.CanShrink = header1.CanShrink;

                                    //header1N.Name = header1.Name + countGroupPage;



                                    //Header headerN = new Header();
                                    //headerN.Size = header.Size;
                                    //headerN.Location = header.Location;
                                    //headerN.CanGrow = header.CanGrow;
                                    //headerN.CanBreak = header.CanBreak;
                                    //headerN.CanShrink = header.CanShrink;
                                    //headerN.Name = header.Name + countGroupPage;
                                    //headerN.Controls.Clear();

                                    //Header subHeaderN = new Header();
                                    //subHeaderN.Location = header3.Location;
                                    //subHeaderN.Size = header3.Size;
                                    //subHeaderN.CanGrow = header3.CanGrow;
                                    //subHeaderN.CanBreak = header3.CanBreak;
                                    //subHeaderN.CanShrink = header3.CanShrink;
                                    //subHeaderN.Name = header3.Name + countGroupPage;
                                    //subHeaderN.Controls.Clear();

                                    //Detail detailN = new Detail();
                                    //detailN.Size = detail.Size;
                                    //detailN.Location = detail.Location;
                                    //detailN.CanGrow = detail.CanGrow;
                                    //detailN.CanBreak = detail.CanBreak;
                                    //detailN.CanShrink = detail.CanShrink;
                                    //detailN.Name = detail.Name + countGroupPage;
                                    //detailN.Controls.Clear();

                                    //gBandN.Controls.Add(header1N);
                                    //gBandN.Controls.Add(headerN);
                                    //gBandN.Controls.Add(subHeaderN);
                                    //gBandN.Controls.Add(detailN);

                                    //dBandN.Controls.Add(gBandN);
                                    //pageN.Controls.Add(dBandN);
                                    //doc.Pages.Add(pageN);

                                    //PerpetuumSoft.Reporting.DOM.TextBox txtHeaderN =
                                    //    new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //PerpetuumSoft.Reporting.DOM.TextBox textSubHeaderN =
                                    //    new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //PerpetuumSoft.Reporting.DOM.TextBox txtDetailN =
                                    //    new PerpetuumSoft.Reporting.DOM.TextBox();

                                    //foreach (DataRow drFix in dtFixColumn.Rows)
                                    //{
                                    //    columnName = drFix["PayrollItemColumnID"].ToString();
                                    //    columnAlias = drFix["TitleColumn"].ToString();
                                    //    subHeader = drFix["SubHeader"].ToString();
                                    //    width = Double.Parse(drFix["Width"].ToString());
                                    //    height = Double.Parse(drFix["Height"].ToString());
                                    //    alignment = drFix["Alignment"].ToString();

                                    //    //tạo header
                                    //    txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //    txtHeaderN.Name = "txtHeader" + columnName + countGroupPage;
                                    //    txtHeaderN.Text = columnAlias;
                                    //    headerN.Controls.Add(txtHeaderN);
                                    //    txtHeaderN.Location =
                                    //        new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    //    txtHeaderN.Size =
                                    //        new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    //    txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    //    txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                                    //    txtHeaderN.Border = oBorder;
                                    //    txtHeaderN.Font = fontHead;

                                    //    //tạo subheader
                                    //    textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //    textSubHeaderN.Name = "txtSubHeader" + columnName + countGroupPage;
                                    //    textSubHeaderN.Text = subHeader;
                                    //    subHeaderN.Controls.Add(textSubHeaderN);
                                    //    textSubHeaderN.Location =
                                    //        new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    //    textSubHeaderN.Size =
                                    //        new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    //    textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    //    textSubHeaderN.CanGrow =
                                    //        textSubHeaderN.CanShrink = textSubHeaderN.GrowToBottom = true;
                                    //    textSubHeaderN.Border = oBorder;
                                    //    textSubHeaderN.Font = fontHead;

                                    //    //Tạo detail
                                    //    txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //    txtDetailN.Name = "txtDetail" + columnName + countGroupPage;
                                    //    txtDetailN.Text = "";
                                    //    detailN.Controls.Add(txtDetailN);
                                    //    txtDetailN.Location =
                                    //        new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    //    txtDetailN.Size =
                                    //        new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    //    txtDetailN.CanGrow = txtDetailN.CanShrink = txtDetailN.GrowToBottom = true;
                                    //    txtDetailN.Border = oBorder;

                                    //    txtDetailN.GenerateScript = txtDetailN.Name + ".Value=GetData(\"" +
                                    //                                columnName + "\").ToString();"
                                    //                                + txtDetailN.Name + ".TextFormat = "
                                    //                                + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                    //                                txtDetailN.Name +
                                    //                                ".TextAlign = System.Drawing.ContentAlignment." +
                                    //                                alignment + ";"
                                    //                                + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                    //                                + "{" + txtDetailN.Name +
                                    //                                ".StyleName  =  \"DetailNormalBold\";}"
                                    //                                + "else {" + txtDetailN.Name +
                                    //                                ".StyleName =  \"DetailNormal\";}";

                                    //    xPos = xPos + width;
                                    //}

                                    //columnName = drDynamic["PayrollItemColumnID"].ToString();
                                    //columnAlias = drDynamic["TitleColumn"].ToString();
                                    //subHeader = drDynamic["SubHeader"].ToString();
                                    //width = Double.Parse(drDynamic["Width"].ToString());
                                    //height = Double.Parse(drDynamic["Height"].ToString());
                                    //alignment = drDynamic["Alignment"].ToString();

                                    ////tạo header
                                    //txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //txtHeaderN.Name = "txtHeader" + columnName + countGroupPage;
                                    //txtHeaderN.Text = columnAlias;
                                    //headerN.Controls.Add(txtHeaderN);
                                    //txtHeaderN.Location =
                                    //    new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    //txtHeaderN.Size =
                                    //    new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    //txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    //txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                                    //txtHeaderN.Border = oBorder;
                                    //txtHeaderN.Font = fontHead;
                                    //yPos = height;
                                    //widthDynamic = width;
                                    ////Add cột detail động

                                    //if (objDynamicDetailColumn.Any())
                                    //{
                                    //    dtDynamicDetailColumn = objDynamicDetailColumn.Skip((n - 1) * 4).Take(4)
                                    //        .CopyToDataTable();


                                    //    foreach (DataRow drDetail in dtDynamicDetailColumn.Rows)
                                    //    {
                                    //        if (drDetail["IsDetail"].ToString() == "True")
                                    //        {
                                    //            columnName = drDetail["PayrollItemColumnID"].ToString();
                                    //            columnAlias = drDetail["TitleColumn"].ToString();
                                    //            subHeader = drDetail["SubHeader"].ToString();
                                    //            width = Double.Parse(drDetail["Width"].ToString());
                                    //            height = Double.Parse(drDetail["Height"].ToString());
                                    //            alignment = drDetail["Alignment"].ToString();

                                    //            txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //            txtHeaderN.Name = "txtHeader" + columnName;
                                    //            txtHeaderN.Text = columnAlias;
                                    //            headerN.Controls.Add(txtHeaderN);
                                    //            txtHeaderN.Location =
                                    //                new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter,
                                    //                    Unit.InternalUnit);
                                    //            txtHeaderN.Size =
                                    //                new Vector(width, height).ConvertUnits(Unit.Centimeter,
                                    //                    Unit.InternalUnit);
                                    //            txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    //            txtHeaderN.CanGrow = txtHeaderN.CanShrink =
                                    //                txtHeaderN.GrowToBottom = false;
                                    //            txtHeaderN.Border = oBorder;
                                    //            txtHeaderN.Font = fontHead;

                                    //            textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //            textSubHeaderN.Name = "txtSubHeader" + columnName;
                                    //            textSubHeaderN.Text = subHeader;
                                    //            subHeaderN.Controls.Add(textSubHeaderN);
                                    //            textSubHeaderN.Location =
                                    //                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter,
                                    //                    Unit.InternalUnit);
                                    //            textSubHeaderN.Size =
                                    //                new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                    //                    Unit.InternalUnit);
                                    //            textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    //            textSubHeaderN.CanGrow = textSubHeaderN.CanShrink =
                                    //                textSubHeaderN.GrowToBottom = true;
                                    //            textSubHeaderN.Border = oBorder;
                                    //            textSubHeaderN.Font = fontHead;

                                    //            txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //            txtDetailN.Name = "txtDetail" + columnName;
                                    //            txtDetailN.Text = "";
                                    //            detailN.Controls.Add(txtDetailN);
                                    //            txtDetailN.Location =
                                    //                new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter,
                                    //                    Unit.InternalUnit);
                                    //            txtDetailN.Size =
                                    //                new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter,
                                    //                    Unit.InternalUnit);

                                    //            txtDetailN.CanGrow =
                                    //                txtDetailN.CanShrink = txtDetailN.GrowToBottom = true;
                                    //            txtDetailN.Border = oBorder;

                                    //            if (drDetail["DataType"].ToString() == "3")
                                    //            {
                                    //                txtDetailN.GenerateScript =
                                    //                    txtDetailN.Name + ".Value=decimal.Parse(GetData(\"" +
                                    //                    columnName + "\").ToString()) ==0 ?\"\" : " +
                                    //                    "GetData(\"" + columnName + "\").ToString();"
                                    //                    + txtDetailN.Name + ".TextFormat = "
                                    //                    + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                                    //                    txtDetailN.Name +
                                    //                    ".TextAlign = System.Drawing.ContentAlignment." +
                                    //                    alignment + ";"
                                    //                    + "if(GetData(\"IsBold\").ToString()==\"True\") "
                                    //                    + "{" + txtDetailN.Name +
                                    //                    ".StyleName  =  \"DetailNormalBold\";}"
                                    //                    + "else {" + txtDetailN.Name +
                                    //                    ".StyleName =  \"DetailNormal\";}";
                                    //            }

                                    //            xPos = xPos + width;
                                    //            if (drDetail["IsDynamic"].ToString() == "True")
                                    //            {
                                    //                widthPlus = widthPlus + width;
                                    //            }
                                    //        }
                                    //    }
                                    //    countcolumn = 0;
                                    //    while (widthPlus < widthDynamic)
                                    //    {
                                    //        txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //        txtHeaderN.Name = "txtHeaderN" + countGroupPage + countcolumn;
                                    //        headerN.Controls.Add(txtHeaderN);
                                    //        txtHeaderN.Location =
                                    //            new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    //        txtHeaderN.Size =
                                    //            new Vector(width, height).ConvertUnits(Unit.Centimeter,
                                    //                Unit.InternalUnit);
                                    //        txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    //        txtHeaderN.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                                    //        txtHeaderN.Border = oBorder;
                                    //        txtHeaderN.Font = fontHead;

                                    //        textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //        textSubHeaderN.Name = "txtSubHeaderN" + countGroupPage + countcolumn;
                                    //        subHeaderN.Controls.Add(textSubHeaderN);
                                    //        textSubHeaderN.Location =
                                    //            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    //        textSubHeaderN.Size =
                                    //            new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                                    //                Unit.InternalUnit);
                                    //        textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                                    //        textSubHeaderN.CanGrow = textSubHeaderN.CanShrink =
                                    //            textSubHeaderN.GrowToBottom = true;
                                    //        textSubHeaderN.Border = oBorder;
                                    //        textSubHeaderN.Font = fontHead;

                                    //        txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                                    //        txtDetailN.Name = "txtDetailN" + countGroupPage + countcolumn;
                                    //        txtDetailN.Text = "";
                                    //        detailN.Controls.Add(txtDetailN);
                                    //        txtDetailN.Location =
                                    //            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                                    //        txtDetailN.Size =
                                    //            new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter,
                                    //                Unit.InternalUnit);

                                    //        txtDetailN.CanGrow = txtDetailN.CanShrink = txtDetailN.GrowToBottom = true;
                                    //        txtDetailN.Border = oBorder;

                                    //        xPos = xPos + width;
                                    //        countcolumn = countcolumn + 1;
                                    //        widthPlus = widthPlus + width;
                                    //    }
                                    //}

                                    #endregion
                                }
                            }

                        }

                    } //end - trang dau
                    else
                    {
                        #region tạo trang mới

                        //width = 0;
                        //height = 0;
                        //xPos = pmargin;
                        //yPos = 0;
                        //widthDynamic = 0;
                        //widthPlus = 0;
                        ////Khởi tạo page mới
                        //Page pageN = new Page();
                        //pageN.Orientation = PageOrientation.Landscape;
                        //pageN.Name = "page" + countGroupPage;
                        //pageN.Margins = new Margins(1f, 1f, 1f, 1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);

                        ////Khởi tạo DataBand mới
                        //DataBand dBandN = new DataBand();
                        //dBandN.DataSource = dBand.DataSource;
                        //dBandN.Size = dBand.Size;
                        //dBandN.Location = dBand.Location;
                        //dBandN.Name = dBand.Name + countGroupPage;
                        //dBandN.Controls.Clear();

                        ////Khởi tạo GroupBand mới
                        //GroupBand gBandN = new GroupBand();
                        //gBandN.GroupExpression = gBand.GroupExpression;
                        //gBandN.Location = gBand.Location;
                        //gBandN.Size = gBand.Size;
                        //gBandN.NewPageBefore = true;
                        //gBandN.Name = gBand.Name + countGroupPage;
                        //gBandN.Controls.Clear();
                        ////Khởi tạo header,subheader,detail mới (lấy properties size,font,location theo header ở page 1 chỉ đổi tên )



                        //Header headerPageN = new Header();
                        //headerPageN.Size = headerPage.Size;
                        //headerPageN.Location = headerPage.Location;
                        //headerPageN.CanGrow = headerPage.CanGrow;
                        //headerPageN.CanBreak = headerPage.CanBreak;
                        //headerPageN.CanShrink = headerPage.CanShrink;
                        //headerPageN.NewPageAfter = headerPage.NewPageAfter;
                        //headerPageN.NewPageBefore = headerPage.NewPageBefore;
                        //headerPageN.RepeatEveryPage = headerPage.RepeatEveryPage;
                        //headerPageN.Name = headerPage.Name + countGroupPage;


                        //Header headerN = new Header();
                        //headerN.Size = header.Size;
                        //headerN.Location = header.Location;
                        //headerN.CanGrow = header.CanGrow;
                        //headerN.CanBreak = header.CanBreak;
                        //headerN.CanShrink = header.CanShrink;
                        //headerN.NewPageAfter = header.NewPageAfter;
                        //headerN.NewPageBefore = header.NewPageBefore;
                        //headerN.Name = header.Name + countGroupPage;
                        //headerN.Controls.Clear();

                        //Header subHeaderN = new Header();
                        //subHeaderN.Location = header3.Location;
                        //subHeaderN.Size = header3.Size;
                        //subHeaderN.CanGrow = header3.CanGrow;
                        //subHeaderN.CanBreak = header3.CanBreak;
                        //subHeaderN.CanShrink = header3.CanShrink;
                        //subHeaderN.Name = header3.Name + countGroupPage;
                        //subHeaderN.Controls.Clear();

                        //Detail detailN = new Detail();
                        //detailN.Size = detail.Size;
                        //detailN.Location = detail.Location;
                        //detailN.CanGrow = detail.CanGrow;
                        //detailN.CanBreak = detail.CanBreak;
                        //detailN.CanShrink = detail.CanShrink;
                        //detailN.Name = detail.Name + countGroupPage;
                        //detailN.Controls.Clear();

                        //Header header1N = new Header();
                        //header1N.Size = header1.Size;
                        //header1N.Location = header1.Location;
                        //header1N.CanGrow = header1.CanGrow;
                        //header1N.CanBreak = header1.CanBreak;
                        //header1N.CanShrink = header1.CanShrink;
                        //header1N.Name = header1.Name + countGroupPage;

                        //gBandN.Controls.Add(headerPageN);
                        //gBandN.Controls.Add(header1N);
                        //gBandN.Controls.Add(headerN);
                        //gBandN.Controls.Add(subHeaderN);
                        //gBandN.Controls.Add(detailN);

                        //dBandN.Controls.Add(gBandN);

                        //PageHeader pageHeaderN = new PageHeader();
                        //pageHeaderN.Location = pageHeader.Location;
                        //pageHeaderN.Size = pageHeader.Size;
                        //pageHeaderN.Mode = pageHeader.Mode;
                        //pageHeaderN.Name = "pageHeader" + countGroupPage;


                        //PageFooter pageFooterN = new PageFooter();
                        //pageFooterN.Location = pageFooter.Location;
                        //pageFooterN.Size = pageFooter.Size;
                        //pageFooterN.Mode = pageFooter.Mode;
                        //pageFooterN.CanGrow = pageFooter.CanGrow;
                        //pageFooterN.CanShrink = pageFooter.CanShrink;
                        //pageFooterN.Name = "pageFooter" + countGroupPage;

                        //pageN.Controls.Add(pageHeaderN);
                        //pageN.Controls.Add(pageFooterN);
                        //pageN.Controls.Add(dBandN);
                        //doc.Pages.Add(pageN);

                        //PerpetuumSoft.Reporting.DOM.TextBox txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //PerpetuumSoft.Reporting.DOM.TextBox textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //PerpetuumSoft.Reporting.DOM.TextBox txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //PerpetuumSoft.Reporting.DOM.TextBox txtPageFooterN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //PerpetuumSoft.Reporting.DOM.TextBox txtLabelHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();


                        //txtLabelHeaderN.Size = new Vector(4.6f, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //txtLabelHeaderN.Location = new Vector(24.1f, 0.1f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //txtLabelHeaderN.Name = "txtLabelN" + countGroupPage;
                        //txtLabelHeaderN.GenerateScript = txtLabelHeaderN.Name + ".Value= GetData(\"BudgetChapterCode\") == null ? \"Mã Chương: \" :\"Mã Chương: \" + GetData(\"BudgetChapterCode\").ToString();";
                        //headerPageN.Controls.Add(txtLabelHeaderN);

                        //foreach (DataRow drFix in dtFixColumn.Rows)
                        //{
                        //    columnName = drFix["PayrollItemColumnID"].ToString();
                        //    columnAlias = drFix["TitleColumn"].ToString();
                        //    subHeader = drFix["SubHeader"].ToString();
                        //    width = Double.Parse(drFix["Width"].ToString());
                        //    height = Double.Parse(drFix["Height"].ToString());
                        //    alignment = drFix["Alignment"].ToString();

                        //    //tạo header
                        //    txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //    txtHeaderN.Name = "txtHeader" + columnName + countGroupPage;
                        //    txtHeaderN.Text = columnAlias;
                        //    headerN.Controls.Add(txtHeaderN);
                        //    txtHeaderN.Location =
                        //        new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //    txtHeaderN.Size =
                        //        new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //    txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //    txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                        //    txtHeaderN.Border = oBorder;
                        //    txtHeaderN.Font = fontHead;

                        //    //tạo subheader
                        //    textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //    textSubHeaderN.Name = "txtSubHeader" + columnName + countGroupPage;
                        //    textSubHeaderN.Text = subHeader;
                        //    subHeaderN.Controls.Add(textSubHeaderN);
                        //    textSubHeaderN.Location =
                        //        new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //    textSubHeaderN.Size =
                        //        new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //    textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //    textSubHeaderN.CanGrow = textSubHeaderN.CanShrink = textSubHeaderN.GrowToBottom = true;
                        //    textSubHeaderN.Border = oBorder;
                        //    textSubHeaderN.Font = fontHead;

                        //    //Tạo detail
                        //    txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //    txtDetailN.Name = "txtDetail" + columnName + countGroupPage;
                        //    txtDetailN.Text = "";
                        //    detailN.Controls.Add(txtDetailN);
                        //    txtDetailN.Location = new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //    txtDetailN.Size = new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //    txtDetailN.CanGrow = txtDetailN.CanShrink = txtDetailN.GrowToBottom = true;
                        //    txtDetailN.Border = oBorder;

                        //    txtDetailN.GenerateScript = txtDetailN.Name + ".Value=GetData(\"" +
                        //                                columnName + "\").ToString();"
                        //                                + txtDetailN.Name + ".TextFormat = "
                        //                                + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                        //                                txtDetailN.Name +
                        //                                ".TextAlign = System.Drawing.ContentAlignment." + alignment +
                        //                                ";"
                        //                                + "if(GetData(\"IsBold\").ToString()==\"True\") "
                        //                                + "{" + txtDetailN.Name +
                        //                                ".StyleName  =  \"DetailNormalBold\";}"
                        //                                + "else {" + txtDetailN.Name +
                        //                                ".StyleName =  \"DetailNormal\";}";

                        //    xPos = xPos + width;
                        //}

                        //columnName = drDynamic["PayrollItemColumnID"].ToString();
                        //columnAlias = drDynamic["TitleColumn"].ToString();
                        //subHeader = drDynamic["SubHeader"].ToString();
                        //width = Double.Parse(drDynamic["Width"].ToString());
                        //height = Double.Parse(drDynamic["Height"].ToString());
                        //alignment = drDynamic["Alignment"].ToString();

                        ////tạo header
                        //txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //txtHeaderN.Name = "txtHeader" + columnName + countGroupPage;
                        //txtHeaderN.Text = columnAlias;
                        //headerN.Controls.Add(txtHeaderN);
                        //txtHeaderN.Location =
                        //    new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //txtHeaderN.Size = new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                        //txtHeaderN.Border = oBorder;
                        //txtHeaderN.Font = fontHead;
                        //yPos = height;
                        //widthDynamic = width;
                        ////Add cột detail động
                        //var objDynamicDetailColumnN = dtSource.AsEnumerable().Where(x =>
                        //    x.Field<string>("ParentID") == drDynamic["PayrollItemColumnID"].ToString()).ToList();

                        //int surPlus = (objDynamicDetailColumnN.ToList().Count - 4) % 10;
                        //int pageIndexN =
                        //    (objDynamicDetailColumnN.Count - 4) / 10;
                        //if (surPlus > 0) pageIndexN = pageIndexN + 2;
                        //else pageIndexN = pageIndexN + 1;

                        //if (objDynamicDetailColumnN.Any())
                        //{
                        //    for (int n = 1; n <= pageIndexN; n++)
                        //    {
                        //        if (n == 1)
                        //        {
                        //            dtDynamicDetailColumn = objDynamicDetailColumnN.Skip(0).Take(4).CopyToDataTable();


                        //            foreach (DataRow drDetail in dtDynamicDetailColumn.Rows)
                        //            {
                        //                if (drDetail["IsDetail"].ToString() == "True")
                        //                {
                        //                    columnName = drDetail["PayrollItemColumnID"].ToString();
                        //                    columnAlias = drDetail["TitleColumn"].ToString();
                        //                    subHeader = drDetail["SubHeader"].ToString();
                        //                    width = Double.Parse(drDetail["Width"].ToString());
                        //                    height = Double.Parse(drDetail["Height"].ToString());
                        //                    alignment = drDetail["Alignment"].ToString();

                        //                    txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                    txtHeaderN.Name = "txtHeader" + columnName;
                        //                    txtHeaderN.Text = columnAlias;
                        //                    headerN.Controls.Add(txtHeaderN);
                        //                    txtHeaderN.Location =
                        //                        new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                    txtHeaderN.Size =
                        //                        new Vector(width, height).ConvertUnits(Unit.Centimeter,
                        //                            Unit.InternalUnit);
                        //                    txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //                    txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                        //                    txtHeaderN.Border = oBorder;
                        //                    txtHeaderN.Font = fontHead;

                        //                    textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                    textSubHeaderN.Name = "txtSubHeader" + columnName;
                        //                    textSubHeaderN.Text = subHeader;
                        //                    subHeaderN.Controls.Add(textSubHeaderN);
                        //                    textSubHeaderN.Location =
                        //                        new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                    textSubHeaderN.Size =
                        //                        new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                        //                            Unit.InternalUnit);
                        //                    textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //                    textSubHeaderN.CanGrow = textSubHeaderN.CanShrink =
                        //                        textSubHeaderN.GrowToBottom = true;
                        //                    textSubHeaderN.Border = oBorder;
                        //                    textSubHeaderN.Font = fontHead;

                        //                    txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                    txtDetailN.Name = "txtDetail" + columnName;
                        //                    txtDetailN.Text = "";
                        //                    detailN.Controls.Add(txtDetailN);
                        //                    txtDetailN.Location =
                        //                        new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                    txtDetailN.Size =
                        //                        new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter,
                        //                            Unit.InternalUnit);

                        //                    txtDetailN.CanGrow = txtDetailN.CanShrink = txtDetailN.GrowToBottom = true;
                        //                    txtDetailN.Border = oBorder;

                        //                    if (drDetail["DataType"].ToString() == "3")
                        //                    {
                        //                        txtDetailN.GenerateScript =
                        //                            txtDetailN.Name + ".Value=decimal.Parse(GetData(\"" +
                        //                            columnName + "\").ToString()) ==0 ?\"\" : " +
                        //                            "GetData(\"" + columnName + "\").ToString();"
                        //                            + txtDetailN.Name + ".TextFormat = "
                        //                            + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                        //                            txtDetailN.Name +
                        //                            ".TextAlign = System.Drawing.ContentAlignment." +
                        //                            alignment + ";"
                        //                            + "if(GetData(\"IsBold\").ToString()==\"True\") "
                        //                            + "{" + txtDetailN.Name +
                        //                            ".StyleName  =  \"DetailNormalBold\";}"
                        //                            + "else {" + txtDetailN.Name +
                        //                            ".StyleName =  \"DetailNormal\";}";
                        //                    }

                        //                    xPos = xPos + width;
                        //                    if (drDetail["IsDynamic"].ToString() == "True")
                        //                    {
                        //                        widthPlus = widthPlus + width;
                        //                    }
                        //                }
                        //                countGroupPage = countGroupPage + 1;
                        //            }

                        //            countcolumn = 0;
                        //            while (widthPlus < widthDynamic)
                        //            {
                        //                txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                txtHeaderN.Name = "txtHeaderN" + countGroupPage + countcolumn;
                        //                headerN.Controls.Add(txtHeaderN);
                        //                txtHeaderN.Location =
                        //                    new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                txtHeaderN.Size =
                        //                    new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //                txtHeaderN.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                        //                txtHeaderN.Border = oBorder;
                        //                txtHeaderN.Font = fontHead;

                        //                textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                textSubHeaderN.Name = "txtSubHeaderN" + countGroupPage + countcolumn;
                        //                subHeaderN.Controls.Add(textSubHeaderN);
                        //                textSubHeaderN.Location =
                        //                    new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                textSubHeaderN.Size =
                        //                    new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //                textSubHeaderN.CanGrow =
                        //                    textSubHeaderN.CanShrink = textSubHeaderN.GrowToBottom = true;
                        //                textSubHeaderN.Border = oBorder;
                        //                textSubHeaderN.Font = fontHead;

                        //                txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                txtDetailN.Name = "txtDetailN" + countGroupPage + countcolumn;
                        //                txtDetailN.Text = "";
                        //                detailN.Controls.Add(txtDetailN);
                        //                txtDetailN.Location =
                        //                    new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                txtDetailN.Size =
                        //                    new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);

                        //                txtDetailN.CanGrow = txtDetailN.CanShrink = txtDetailN.GrowToBottom = true;
                        //                txtDetailN.Border = oBorder;

                        //                xPos = xPos + width;
                        //                countcolumn = countcolumn + 1;
                        //                widthPlus = widthPlus + width;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            #region tạo trang mới

                        //            width = 0;
                        //            height = 0;
                        //            xPos = pmargin;
                        //            yPos = 0;
                        //            widthDynamic = 0;
                        //            widthPlus = 0;
                        //            //Khởi tạo page mới
                        //            Page pageN1 = new Page();
                        //            pageN1.Orientation = PageOrientation.Landscape;
                        //            pageN1.Name = "page" + countGroupPage;

                        //            //Khởi tạo DataBand mới
                        //            DataBand dBandN1 = new DataBand();
                        //            dBandN1.DataSource = dBand.DataSource;
                        //            dBandN1.Size = dBand.Size;
                        //            dBandN1.Location = dBand.Location;
                        //            dBandN1.Name = dBand.Name + countGroupPage;
                        //            dBandN1.Controls.Clear();

                        //            //Khởi tạo GroupBand mới
                        //            GroupBand gBandN1 = new GroupBand();
                        //            gBandN1.GroupExpression = gBand.GroupExpression;
                        //            gBandN1.Location = gBand.Location;
                        //            gBandN1.Size = gBand.Size;
                        //            gBandN1.Name = gBand.Name + countGroupPage;
                        //            gBandN1.Controls.Clear();
                        //            //Khởi tạo header,subheader,detail mới (lấy properties size,font,location theo header ở page 1 chỉ đổi tên )

                        //            Header header1N1 = new Header();
                        //            header1N1.Size = header1.Size;

                        //            header1N1.Location = header1.Location;
                        //            header1N1.CanGrow = header1.CanGrow;
                        //            header1N1.CanBreak = header1.CanBreak;
                        //            header1N1.CanShrink = header1.CanShrink;
                        //            header1N1.Name = header1.Name + countGroupPage;

                        //            Header headerN1 = new Header();
                        //            headerN1.Size = header.Size;
                        //            headerN1.Location = header.Location;
                        //            headerN1.CanGrow = header.CanGrow;
                        //            headerN1.CanBreak = header.CanBreak;
                        //            headerN1.CanShrink = header.CanShrink;
                        //            headerN1.Name = header.Name + countGroupPage;
                        //            headerN1.Controls.Clear();

                        //            Header subHeaderN1 = new Header();
                        //            subHeaderN1.Location = header3.Location;
                        //            subHeaderN1.Size = header3.Size;
                        //            subHeaderN1.CanGrow = header3.CanGrow;
                        //            subHeaderN1.CanBreak = header3.CanBreak;
                        //            subHeaderN1.CanShrink = header3.CanShrink;
                        //            subHeaderN1.Name = header3.Name + countGroupPage;
                        //            subHeaderN1.Controls.Clear();

                        //            Detail detailN1 = new Detail();
                        //            detailN1.Size = detail.Size;
                        //            detailN1.Location = detail.Location;
                        //            detailN1.CanGrow = detail.CanGrow;
                        //            detailN1.CanBreak = detail.CanBreak;
                        //            detailN1.CanShrink = detail.CanShrink;
                        //            detailN1.Name = detail.Name + countGroupPage;
                        //            detailN1.Controls.Clear();

                        //            gBandN.Controls.Add(header1N1);
                        //            gBandN.Controls.Add(headerN);
                        //            gBandN.Controls.Add(subHeaderN);
                        //            gBandN.Controls.Add(detailN);

                        //            dBandN.Controls.Add(gBandN);
                        //            pageN.Controls.Add(dBandN);
                        //            doc.Pages.Add(pageN);

                        //            PerpetuumSoft.Reporting.DOM.TextBox txtHeaderN1 =
                        //                new PerpetuumSoft.Reporting.DOM.TextBox();
                        //            PerpetuumSoft.Reporting.DOM.TextBox textSubHeaderN1 =
                        //                new PerpetuumSoft.Reporting.DOM.TextBox();
                        //            PerpetuumSoft.Reporting.DOM.TextBox txtDetailN1 =
                        //                new PerpetuumSoft.Reporting.DOM.TextBox();

                        //            foreach (DataRow drFix in dtFixColumn.Rows)
                        //            {
                        //                columnName = drFix["PayrollItemColumnID"].ToString();
                        //                columnAlias = drFix["TitleColumn"].ToString();
                        //                subHeader = drFix["SubHeader"].ToString();
                        //                width = Double.Parse(drFix["Width"].ToString());
                        //                height = Double.Parse(drFix["Height"].ToString());
                        //                alignment = drFix["Alignment"].ToString();

                        //                //tạo header
                        //                txtHeaderN1 = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                txtHeaderN1.Name = "txtHeader" + columnName + countGroupPage + n;
                        //                txtHeaderN1.Text = columnAlias;
                        //                headerN1.Controls.Add(txtHeaderN1);
                        //                txtHeaderN1.Location =
                        //                    new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                txtHeaderN1.Size =
                        //                    new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                txtHeaderN1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //                txtHeaderN1.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                        //                txtHeaderN1.Border = oBorder;
                        //                txtHeaderN1.Font = fontHead;

                        //                //tạo subheader
                        //                textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                textSubHeaderN.Name = "txtSubHeader" + columnName + countGroupPage;
                        //                textSubHeaderN.Text = subHeader;
                        //                subHeaderN.Controls.Add(textSubHeaderN);
                        //                textSubHeaderN.Location =
                        //                    new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                textSubHeaderN.Size =
                        //                    new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //                textSubHeaderN.CanGrow =
                        //                    textSubHeaderN.CanShrink = textSubHeaderN.GrowToBottom = true;
                        //                textSubHeaderN.Border = oBorder;
                        //                textSubHeaderN.Font = fontHead;

                        //                //Tạo detail
                        //                txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                txtDetailN.Name = "txtDetail" + columnName + countGroupPage;
                        //                txtDetailN.Text = "";
                        //                detailN.Controls.Add(txtDetailN);
                        //                txtDetailN.Location =
                        //                    new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                txtDetailN.Size =
                        //                    new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                txtDetailN.CanGrow = txtDetailN.CanShrink = txtDetailN.GrowToBottom = true;
                        //                txtDetailN.Border = oBorder;

                        //                txtDetailN.GenerateScript = txtDetailN.Name + ".Value=GetData(\"" +
                        //                                            columnName + "\").ToString();"
                        //                                            + txtDetailN.Name + ".TextFormat = "
                        //                                            + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                        //                                            txtDetailN.Name +
                        //                                            ".TextAlign = System.Drawing.ContentAlignment." +
                        //                                            alignment + ";"
                        //                                            + "if(GetData(\"IsBold\").ToString()==\"True\") "
                        //                                            + "{" + txtDetailN.Name +
                        //                                            ".StyleName  =  \"DetailNormalBold\";}"
                        //                                            + "else {" + txtDetailN.Name +
                        //                                            ".StyleName =  \"DetailNormal\";}";

                        //                xPos = xPos + width;
                        //            }

                        //            columnName = drDynamic["PayrollItemColumnID"].ToString();
                        //            columnAlias = drDynamic["TitleColumn"].ToString();
                        //            subHeader = drDynamic["SubHeader"].ToString();
                        //            width = Double.Parse(drDynamic["Width"].ToString());
                        //            height = Double.Parse(drDynamic["Height"].ToString());
                        //            alignment = drDynamic["Alignment"].ToString();

                        //            //tạo header
                        //            txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //            txtHeaderN.Name = "txtHeader" + columnName + countGroupPage;
                        //            txtHeaderN.Text = columnAlias;
                        //            headerN.Controls.Add(txtHeaderN);
                        //            txtHeaderN.Location =
                        //                new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //            txtHeaderN.Size =
                        //                new Vector(width, height).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //            txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //            txtHeaderN.CanGrow = txtHeaderN.CanShrink = txtHeaderN.GrowToBottom = false;
                        //            txtHeaderN.Border = oBorder;
                        //            txtHeaderN.Font = fontHead;
                        //            yPos = height;
                        //            widthDynamic = width;
                        //            //Add cột detail động

                        //            if (objDynamicDetailColumnN.Any())
                        //            {
                        //                dtDynamicDetailColumn = objDynamicDetailColumnN.Skip((n - 1) * 4).Take(4)
                        //                    .CopyToDataTable();


                        //                foreach (DataRow drDetail in dtDynamicDetailColumn.Rows)
                        //                {
                        //                    if (drDetail["IsDetail"].ToString() == "True")
                        //                    {
                        //                        columnName = drDetail["PayrollItemColumnID"].ToString();
                        //                        columnAlias = drDetail["TitleColumn"].ToString();
                        //                        subHeader = drDetail["SubHeader"].ToString();
                        //                        width = Double.Parse(drDetail["Width"].ToString());
                        //                        height = Double.Parse(drDetail["Height"].ToString());
                        //                        alignment = drDetail["Alignment"].ToString();

                        //                        txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                        txtHeaderN.Name = "txtHeader" + columnName;
                        //                        txtHeaderN.Text = columnAlias;
                        //                        headerN.Controls.Add(txtHeaderN);
                        //                        txtHeaderN.Location =
                        //                            new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter,
                        //                                Unit.InternalUnit);
                        //                        txtHeaderN.Size =
                        //                            new Vector(width, height).ConvertUnits(Unit.Centimeter,
                        //                                Unit.InternalUnit);
                        //                        txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //                        txtHeaderN.CanGrow = txtHeaderN.CanShrink =
                        //                            txtHeaderN.GrowToBottom = false;
                        //                        txtHeaderN.Border = oBorder;
                        //                        txtHeaderN.Font = fontHead;

                        //                        textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                        textSubHeaderN.Name = "txtSubHeader" + columnName;
                        //                        textSubHeaderN.Text = subHeader;
                        //                        subHeaderN.Controls.Add(textSubHeaderN);
                        //                        textSubHeaderN.Location =
                        //                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter,
                        //                                Unit.InternalUnit);
                        //                        textSubHeaderN.Size =
                        //                            new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                        //                                Unit.InternalUnit);
                        //                        textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //                        textSubHeaderN.CanGrow = textSubHeaderN.CanShrink =
                        //                            textSubHeaderN.GrowToBottom = true;
                        //                        textSubHeaderN.Border = oBorder;
                        //                        textSubHeaderN.Font = fontHead;

                        //                        txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                        txtDetailN.Name = "txtDetail" + columnName;
                        //                        txtDetailN.Text = "";
                        //                        detailN.Controls.Add(txtDetailN);
                        //                        txtDetailN.Location =
                        //                            new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter,
                        //                                Unit.InternalUnit);
                        //                        txtDetailN.Size =
                        //                            new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter,
                        //                                Unit.InternalUnit);

                        //                        txtDetailN.CanGrow =
                        //                            txtDetailN.CanShrink = txtDetailN.GrowToBottom = true;
                        //                        txtDetailN.Border = oBorder;

                        //                        if (drDetail["DataType"].ToString() == "3")
                        //                        {
                        //                            txtDetailN.GenerateScript =
                        //                                txtDetailN.Name + ".Value=decimal.Parse(GetData(\"" +
                        //                                columnName + "\").ToString()) ==0 ?\"\" : " +
                        //                                "GetData(\"" + columnName + "\").ToString();"
                        //                                + txtDetailN.Name + ".TextFormat = "
                        //                                + "(PerpetuumSoft.Framework.Text.TextFormat) GetData(\"RssObject.CurrencyFormat\");" +
                        //                                txtDetailN.Name +
                        //                                ".TextAlign = System.Drawing.ContentAlignment." +
                        //                                alignment + ";"
                        //                                + "if(GetData(\"IsBold\").ToString()==\"True\") "
                        //                                + "{" + txtDetailN.Name +
                        //                                ".StyleName  =  \"DetailNormalBold\";}"
                        //                                + "else {" + txtDetailN.Name +
                        //                                ".StyleName =  \"DetailNormal\";}";
                        //                        }

                        //                        xPos = xPos + width;
                        //                        if (drDetail["IsDynamic"].ToString() == "True")
                        //                        {
                        //                            widthPlus = widthPlus + width;
                        //                        }
                        //                    }
                        //                }
                        //                countcolumn = 0;
                        //                while (widthPlus < widthDynamic)
                        //                {
                        //                    txtHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                    txtHeaderN.Name = "txtHeaderN" + countGroupPage + countcolumn;
                        //                    headerN.Controls.Add(txtHeaderN);
                        //                    txtHeaderN.Location =
                        //                        new Vector(xPos, yPos).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                    txtHeaderN.Size =
                        //                        new Vector(width, height).ConvertUnits(Unit.Centimeter,
                        //                            Unit.InternalUnit);
                        //                    txtHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //                    txtHeaderN.CanGrow = txtHeader.CanShrink = txtHeader.GrowToBottom = false;
                        //                    txtHeaderN.Border = oBorder;
                        //                    txtHeaderN.Font = fontHead;

                        //                    textSubHeaderN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                    textSubHeaderN.Name = "txtSubHeaderN" + countGroupPage + countcolumn;
                        //                    subHeaderN.Controls.Add(textSubHeaderN);
                        //                    textSubHeaderN.Location =
                        //                        new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                    textSubHeaderN.Size =
                        //                        new Vector(width, 0.6f).ConvertUnits(Unit.Centimeter,
                        //                            Unit.InternalUnit);
                        //                    textSubHeaderN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        //                    textSubHeaderN.CanGrow = textSubHeaderN.CanShrink =
                        //                        textSubHeaderN.GrowToBottom = true;
                        //                    textSubHeaderN.Border = oBorder;
                        //                    textSubHeaderN.Font = fontHead;

                        //                    txtDetailN = new PerpetuumSoft.Reporting.DOM.TextBox();
                        //                    txtDetailN.Name = "txtDetailN" + countGroupPage + countcolumn;
                        //                    txtDetailN.Text = "";
                        //                    detailN.Controls.Add(txtDetailN);
                        //                    txtDetailN.Location =
                        //                        new Vector(xPos, 0f).ConvertUnits(Unit.Centimeter, Unit.InternalUnit);
                        //                    txtDetailN.Size =
                        //                        new Vector(width, 0.5f).ConvertUnits(Unit.Centimeter,
                        //                            Unit.InternalUnit);

                        //                    txtDetailN.CanGrow = txtDetailN.CanShrink = txtDetailN.GrowToBottom = true;
                        //                    txtDetailN.Border = oBorder;

                        //                    xPos = xPos + width;
                        //                    countcolumn = countcolumn + 1;
                        //                    widthPlus = widthPlus + width;
                        //                }
                        //            }

                        //            #endregion

                        //        }
                        //    }

                        #endregion

                        // countGroupPage = countGroupPage + 1;

                        //}
                    }
                }//end - mỗi 1 group gen động tạo ra 1 trang mới

                reportSlot.SaveReport(doc);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

