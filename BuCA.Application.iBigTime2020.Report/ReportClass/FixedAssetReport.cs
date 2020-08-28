/***********************************************************************
 * <copyright file="FixedAssetReport.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, January 12, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, January 12, 2018 Author SonTV  Description 
 * 
 * ************************************************************************/


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.ParameterReportForm;
using BuCA.Application.iBigTime2020.Session;
using RSSHelper;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.FixedAsset;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Inventory;
using DevExpress.Data.Linq;
using DevExpress.XtraLayout.Converter;
using PerpetuumSoft.Framework.Drawing;
using PerpetuumSoft.Reporting.Components;
using PerpetuumSoft.Reporting.DOM;
using System.Reflection;
using System.Xml;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using System.Reflection.Emit;
using Label = System.Windows.Forms.Label;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    /// <summary>
    /// FixedAssetReport
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.ReportClass.BaseReport" />
    public class FixedAssetReport : BaseReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetReport"/> class.
        /// </summary>
        public FixedAssetReport()
        {
            Model = new Model();
        }

        /// <summary>
        /// Gets the report minutes get count fixed asset.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>
        /// IList&lt;FixedAssetS24HModel&gt;.
        /// </returns>
        public IList<MinutesFixedAssetModel> GetReportMinutesGetCountFixedAsset(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<MinutesFixedAssetModel> minutesGetCountFixedAssets = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmMinutesInventoryFixedAsset())
                {
                    frmParam.Text = @"Biên bản kiểm kê TSCĐ";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate);
                        var toDate = DateTime.Parse(frmParam.ToDate);
                        var dateInventory = DateTime.Parse(frmParam.DateInventory.ToString());
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("DateInventory"))
                            oRsTool.Parameters.Add("DateInventory", dateInventory.ToString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince) ? string.Empty : GlobalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("CounCilList"))
                            oRsTool.Parameters.Add("CounCilList", frmParam.CounCilList);
                        // lấy dữ liệu báo cáo
                        var reports = Model.GetReportMinutesGetCountFixedAsset(fromDate, toDate, frmParam.DepartmentId,
                            frmParam.FixedAssetCategoryId, frmParam.SumFixedCategory);
                        // Lấy biên bản kiểm kê
                        //listMinutes = frmParam.listMinutes;
                        if (reports.Count > 0)
                        {
                            minutesGetCountFixedAssets = new List<MinutesFixedAssetModel>();
                            MinutesFixedAssetModel master = new MinutesFixedAssetModel()
                            {
                                FAMinutesInventoryFixedAssets = null,
                                MinutesGetCountFixedAssets = reports.Where(c => c.BookQuantity != 0).ToList(),
                            };
                            minutesGetCountFixedAssets.Add(master);
                        }
                    }
                    //if (minutesGetCountFixedAssets == null || minutesGetCountFixedAssets.Count <= 0)
                    //    minutesGetCountFixedAssets = null;
                }
            }
            return minutesGetCountFixedAssets;
        }

        /// <summary>
        /// Gets the report fixed asset S24 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns>
        /// System.Collections.Generic.IList&lt;Buca.Application.iBigTime2020.Model.BusinessObjects.Report.FixedAsset.FixedAssetS24HModel&gt;.
        /// </returns>
        public IList<FixedAssetS24HModel> GetReportFixedAssetS24H(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<FixedAssetS24HModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFixedAssetS24H())
                {
                    frmParam.Text = @"S24-H: Sổ tài sản cố định";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = DateTime.Parse(frmParam.FromDate).ToShortDateString();
                        var toDate = DateTime.Parse(frmParam.ToDate);

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate);
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("GroupByFACategory"))
                            oRsTool.Parameters.Add("GroupByFACategory", false);
                        if (!oRsTool.Parameters.ContainsKey("SummaryByDepartment"))
                        {
                            oRsTool.Parameters.Add("SummaryByDepartment", string.IsNullOrEmpty(frmParam.DepartmentId));
                        }
                        if (!oRsTool.Parameters.ContainsKey("DateSystemDay"))
                            oRsTool.Parameters.Add("DateSystemDay", DateTime.Today.Day);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemMonth"))
                            oRsTool.Parameters.Add("DateSystemMonth", DateTime.Today.Month);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemYear"))
                            oRsTool.Parameters.Add("DateSystemYear", DateTime.Today.Year);
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", toDate.ToString());


                        if (!oRsTool.Parameters.ContainsKey("ReportSubTitle"))
                        {
                            oRsTool.Parameters.Add("ReportSubTitle",
                                ConvertDateToStringForReport(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate)));
                        }

                        reports = Model.GetFixedAssetS24H(frmParam.FromDate, frmParam.ToDate, 0, frmParam.DepartmentId,
                            frmParam.FixedAssetCategoryId, frmParam.FixedAssetCategoryGrade,
                            frmParam.PrintByCondition, frmParam.PrintFixedAssetOpening,
                            frmParam.PrintFixedAssetIncrementInYear, frmParam.PrintFixedAssetNotIncrement,
                            frmParam.ListFixedAssetId,
                            GlobalVariable.AmountTypeViewReport, GlobalVariable.CurrencyViewReport);
                        if (frmParam.ShowQuantity == 0)
                        {
                            oRsTool.ReportFileName = "S24H.rst";
                        }
                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// Gets the report fixed asset S26 h.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<S26HModel> GetReportFixedAssetS26H(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            IList<S26HModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmS26HFixedAsset())
                {
                    frmParam.Text = @"S26-H: Sổ theo dõi tài sản cố định tại nơi sử dụng";
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
                        if (!oRsTool.Parameters.ContainsKey("CurrencyUnitPriceDigitsInReport"))
                            oRsTool.Parameters.Add("CurrencyUnitPriceDigitsInReport",
                                GlobalVariable.CurrencyUnitPriceDigitsInReport);
                        if (!oRsTool.Parameters.ContainsKey("CurrencySymbol"))
                            oRsTool.Parameters.Add("CurrencySymbol", oRsTool.RssObject.Nfi.CurrencySymbol);
                        if (!oRsTool.Parameters.ContainsKey("CurrencyGroupSeparator"))
                            oRsTool.Parameters.Add("CurrencyGroupSeparator",
                                oRsTool.RssObject.Nfi.CurrencyGroupSeparator);
                        if (!oRsTool.Parameters.ContainsKey("CurrencyDecimalSeparator"))
                            oRsTool.Parameters.Add("CurrencyDecimalSeparator",
                                oRsTool.RssObject.Nfi.CurrencyDecimalSeparator);

                        reports = Model.GetReportFixedAssetS26H(fromDate, toDate, frmParam.DepartmentId,
                            frmParam.InventoryItemCategoryId, amountType, currencyCode);
                    }
                } 
            }
            return reports;
        }

        /// <summary>
        /// Reports the inventory fixed asset entities.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<InventoryFixedAssetModel> ReportInventoryFixedAssetEntities(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<InventoryFixedAssetModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmInventoryFixedAsset())
                {
                    frmParam.Text = @"Báo cáo kiểm kê tài sản cố định";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = frmParam.FromDate;
                        var toDate = frmParam.ToDate;
                        if (!oRsTool.Parameters.ContainsKey("DateSystemDay"))
                            oRsTool.Parameters.Add("DateSystemDay", DateTime.Today.Day);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemMonth"))
                            oRsTool.Parameters.Add("DateSystemMonth", DateTime.Today.Month);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemYear"))
                            oRsTool.Parameters.Add("DateSystemYear", DateTime.Today.Year);
                        if (!oRsTool.Parameters.ContainsKey("ReportSubTitle"))
                            oRsTool.Parameters.Add("ReportSubTitle", ConvertDateToStringForReport(fromDate, toDate));
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);

                        reports = Model.ReportInventoryFixedAssetEntities(frmParam.FromDate, frmParam.ToDate,
                            true);


                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// Reports the fixed asset decrease list entities.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetDecreaseModel> ReportFixedAssetDecreaseListEntities(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<FixedAssetDecreaseModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFixedAssetDecreaseList())
                {
                    frmParam.Text = @"Báo cáo kiểm kê tài sản cố định";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = frmParam.FromDate;
                        var toDate = frmParam.ToDate;
                        if (!oRsTool.Parameters.ContainsKey("DateSystemDay"))
                            oRsTool.Parameters.Add("DateSystemDay", DateTime.Today.Day);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemMonth"))
                            oRsTool.Parameters.Add("DateSystemMonth", DateTime.Today.Month);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemYear"))
                            oRsTool.Parameters.Add("DateSystemYear", DateTime.Today.Year);
                        if (!oRsTool.Parameters.ContainsKey("ReportSubTitle"))
                            oRsTool.Parameters.Add("ReportSubTitle", ConvertDateToStringForReport(fromDate, toDate));
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);

                        if (!oRsTool.Parameters.ContainsKey("DecreaseReason"))
                        {
                            oRsTool.Parameters.Add("DecreaseReason",
                                frmParam.DecreaseReasonId == -1 ? "" : frmParam.DecreaseReasonId.ToString());
                        }
                        reports = Model.ReportFixedAssetDecreaseListEntities(frmParam.FromDate, frmParam.ToDate,
                            frmParam.DecreaseReasonId);


                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// ReportFixedAssetIncreaseDecrease
        /// </summary>
        /// <param name="reportParameter"></param>
        /// <param name="oRsTool"></param>
        /// <returns></returns>
        public IList<FixedAssetIncreaseDecreaseModel> ReportFixedAssetIncreaseDecrease(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<FixedAssetIncreaseDecreaseModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = true;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmInventoryFixedAsset())
                {
                    frmParam.Text = @"Báo cáo tình hình tăng giảm tài sản cố định";
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = frmParam.FromDate;
                        var toDate = frmParam.ToDate;
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("DateSystemDay"))
                            oRsTool.Parameters.Add("DateSystemDay", DateTime.Today.Day);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemMonth"))
                            oRsTool.Parameters.Add("DateSystemMonth", DateTime.Today.Month);
                        if (!oRsTool.Parameters.ContainsKey("DateSystemYear"))
                            oRsTool.Parameters.Add("DateSystemYear", DateTime.Today.Year);
                        if (!oRsTool.Parameters.ContainsKey("ReportSubTitle"))
                            oRsTool.Parameters.Add("ReportSubTitle", ConvertDateToStringForReport(fromDate, toDate));
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);

                        reports = Model.ReportFixedAssetIncreaseDecrease(frmParam.FromDate, frmParam.ToDate);

                    }
                }
            }
            return reports;
        }

        /// <summary>
        /// Gets the report fixed asset C55 hd.
        /// </summary>
        /// <param name="reportParameter">The report parameter.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FixedAssetC55HDModel> GetReportFixedAssetC55HD(ReportParameter reportParameter,
            ReportSharpHelper oRsTool)
        {
            IList<FixedAssetC55HDModel> reports = null;
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmC55HD())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = frmParam.FromDate;
                        var toDate = frmParam.ToDate;
                        var isDetailByFixedAsset = frmParam.IsDetailByFixedAsset;
                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince)? "": GlobalVariable.CompanyProvince);

                        reports = Model.GetC55HDReport(fromDate, toDate, isDetailByFixedAsset);
                    }
                }
            }
            return reports;
        }

        public IList<object> GetReportFixedAssetC56HD(ReportParameter reportParameter, ReportSharpHelper oRsTool)
        {
            List<object> result = new List<object>();
            GlobalVariable.IsDisplayNewLicenseInfo = false;

            if (!oRsTool.IsRefresh)
            {
                using (var frmParam = new FrmFixedAssetC56())
                {
                    if (frmParam.ShowDialog() == DialogResult.OK)
                    {
                        var fromDate = frmParam.FromDate;
                        var toDate = frmParam.ToDate;
                        var list = frmParam.ListFixedAssetId;
                        var isPeriod = frmParam.IsPeriod;
                        var isType = frmParam.IsType;
                        DataTable tbl = Model.GetAttributionDepreciationFA(fromDate, toDate, list, isPeriod, isType);

                        DataTable dtPivotReturn = GetInversedDataTable(tbl, "CorrespondingCode", "FixedAssetID",
                            "AccountAmount", "", true);

                        var test1 = JoinDataTables(tbl, dtPivotReturn,
                            (row1, row2) => row1.Field<string>("FixedAssetID") == row2.Field<string>("FixedAssetID"));
                        var test = RemoveDuplicateRows(test1, "FixedAssetID");

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
                                else
                                {
                                    if (value.Contains(","))  value = value.Replace(",", ".");
                                    propertyInfos.SetValue(dynamicObj, value, null);

                                }
                            }

                            result.Add(dynamicObj);

                        }

                        RenderDynamic(test);

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", fromDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", toDate.ToShortDateString());
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", GlobalVariable.PostedDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", string.IsNullOrEmpty(GlobalVariable.CompanyProvince
                                ) ? string.Empty : GlobalVariable.CompanyProvince);

                    }
                    else result = null;
                }
            }
            return result;
        }

        #region Comment

        //private readonly GlobalVariable _globalVariable;
        ///// <summary>
        ///// Initializes a new instance of the <see cref="FixedAssetReport"/> class.
        ///// </summary>
        //public FixedAssetReport()
        //{
        //    Model = new Model();
        //    _globalVariable = new GlobalVariable();

        //}

        ///// <summary>
        ///// Báo cáo tình hình tăng giảm tài sản cố định
        ///// Gets the report fixed asset B03 h.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<FixedAssetB03HModel> GetReportFixedAssetB03H(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAssetB03HModel> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetB03H())
        //        {
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
        //                //list = Model.GetFixedAssetB03H(GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //                list = amountType == 1 ? Model.GetFixedAssetB03HAmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetB03H(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        list = amountType == 1 ? Model.GetFixedAssetB03HAmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetB03H(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (amountType == 1)
        //        {
        //            if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //                oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
        //        }
        //        else
        //        {
        //            if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //                oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
        //        }
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());

        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);

        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// Báo cáo tình hình tăng giảm tài sản cố định
        ///// Gets the report fixed asset B03 h.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<FixedAssetB01Model> GetReportFixedAssetB01(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAssetB01Model> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetB01())
        //        {
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
        //                list = amountType == 1 ? Model.GetFixedAssetB01AmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetB01(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //list = Model.GetFixedAssetB01(GlobalVariable.FromDate.ToShortDateString(), GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //        list = amountType == 1 ? Model.GetFixedAssetB01AmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                      GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetB01(GlobalVariable.FromDate.ToShortDateString(),
        //                      GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (amountType == 1)
        //        {
        //            if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //                oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (qui đổi): " + currencyCode);
        //        }
        //        else
        //        {
        //            if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //                oRsTool.Parameters.Add("CurrencyCodeUnit", "Đơn vị tính (nguyên tệ): " + currencyCode);
        //        }
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());

        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
        //        if (!oRsTool.Parameters.ContainsKey("DateOfInventory"))
        //            oRsTool.Parameters.Add("DateOfInventory", _globalVariable.DateOfInventory);
        //        if (!oRsTool.Parameters.ContainsKey("HourOfInventory"))
        //            oRsTool.Parameters.Add("HourOfInventory", _globalVariable.HourOfInventory);
        //        if (!oRsTool.Parameters.ContainsKey("MinuteOfInventory"))
        //            oRsTool.Parameters.Add("MinuteOfInventory", _globalVariable.MinuteOfInventory);

        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory1"))
        //            oRsTool.Parameters.Add("JobOfInventory1", _globalVariable.JobOfInventory1);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory3"))
        //            oRsTool.Parameters.Add("JobOfInventory3", _globalVariable.JobOfInventory3);
        //        // JobOfInventoryName 
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory1"))
        //            oRsTool.Parameters.Add("NameOfInventory1", _globalVariable.NameOfInventory1);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory3"))
        //            oRsTool.Parameters.Add("NameOfInventory3", _globalVariable.NameOfInventory3);

        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// Báo cáo tăng tài sản cố định
        ///// Gets the report fixed asset B02.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<FixedAssetB02Model> GetReportFixedAssetB02(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{

        //    IList<FixedAssetB02Model> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var reportDate = _globalVariable.PostedDate;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetB02())
        //        {
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;

        //                list = amountType == 1
        //                    ? Model.GetFixedAssetB02AmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits)
        //                    : Model.GetFixedAssetB02(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode);

        //            }
        //        }
        //    }
        //    else
        //    {
        //        list = amountType == 1
        //                    ? Model.GetFixedAssetB02AmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits)
        //                    : Model.GetFixedAssetB02(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", reportDate);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

        //        if (!oRsTool.Parameters.ContainsKey("DateOfInventory"))
        //            oRsTool.Parameters.Add("DateOfInventory", _globalVariable.DateOfInventory);
        //        if (!oRsTool.Parameters.ContainsKey("HourOfInventory"))
        //            oRsTool.Parameters.Add("HourOfInventory", _globalVariable.HourOfInventory);
        //        if (!oRsTool.Parameters.ContainsKey("MinuteOfInventory"))
        //            oRsTool.Parameters.Add("MinuteOfInventory", _globalVariable.MinuteOfInventory);

        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory1"))
        //            oRsTool.Parameters.Add("JobOfInventory1", _globalVariable.JobOfInventory1);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory3"))
        //            oRsTool.Parameters.Add("JobOfInventory3", _globalVariable.JobOfInventory3);
        //        // JobOfInventoryName 
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory1"))
        //            oRsTool.Parameters.Add("NameOfInventory1", _globalVariable.NameOfInventory1);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory3"))
        //            oRsTool.Parameters.Add("NameOfInventory3", _globalVariable.NameOfInventory3);

        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// Gets the report fixed asset c55a hd.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<FixedAssetC55aHDModel> GetReportFixedAssetC55aHD(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAssetC55aHDModel> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetS31HTreeList())
        //        {
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = frmParam.FromDate;
        //                GlobalVariable.ToDate = frmParam.ToDate;
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
        //                frmParam.Text = "Báo cáo hao mòn TSCĐ";

        //                var listFixedAssetCategoryId = frmParam.SelectedFixedAssetCategory;
        //                if (!oRsTool.Parameters.ContainsKey("ListFixedAssetCategoryId"))
        //                    oRsTool.Parameters.Add("ListFixedAssetCategoryId", listFixedAssetCategoryId);

        //                //list = Model.GetFixedAssetC55aHD(GlobalVariable.FromDate.ToShortDateString(),
        //                //        GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId,
        //                //    listFixedAssetCategoryId, currencyCode);

        //                list = amountType == 1
        //                    ? Model.GetFixedAssetC55aHDAmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId, listFixedAssetCategoryId, currencyDecimalDigits)
        //                    : Model.GetFixedAssetC55aHD(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId,
        //                  listFixedAssetCategoryId, currencyCode);


        //            }
        //        }
        //    }
        //    else
        //    {
        //        var listFixedAssetCategoryId = oRsTool.Parameters["ListFixedAssetCategoryId"].ToString();
        //        list = Model.GetFixedAssetC55aHD(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId,
        //                    listFixedAssetCategoryId, currencyCode);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);

        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);

        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());

        //        if (!oRsTool.Parameters.ContainsKey("DateOfInventory"))
        //            oRsTool.Parameters.Add("DateOfInventory", _globalVariable.DateOfInventory);
        //        if (!oRsTool.Parameters.ContainsKey("HourOfInventory"))
        //            oRsTool.Parameters.Add("HourOfInventory", _globalVariable.HourOfInventory);
        //        if (!oRsTool.Parameters.ContainsKey("MinuteOfInventory"))
        //            oRsTool.Parameters.Add("MinuteOfInventory", _globalVariable.MinuteOfInventory);

        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory1"))
        //            oRsTool.Parameters.Add("JobOfInventory1", _globalVariable.JobOfInventory1);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory3"))
        //            oRsTool.Parameters.Add("JobOfInventory3", _globalVariable.JobOfInventory3);
        //        // JobOfInventoryName 
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory1"))
        //            oRsTool.Parameters.Add("NameOfInventory1", _globalVariable.NameOfInventory1);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory3"))
        //            oRsTool.Parameters.Add("NameOfInventory3", _globalVariable.NameOfInventory3);

        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// Gets the report fixed asset S31 h.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<FixedAssetS31HModel> GetReportFixedAssetS31H(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAssetS31HModel> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetS31HTreeList())
        //        {
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = frmParam.FromDate;
        //                GlobalVariable.ToDate = frmParam.ToDate;
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;

        //                var listFixedAssetCategoryId = frmParam.SelectedFixedAssetCategory;
        //                if (!oRsTool.Parameters.ContainsKey("ListFixedAssetCategoryId"))
        //                    oRsTool.Parameters.Add("ListFixedAssetCategoryId", listFixedAssetCategoryId);

        //                list = Model.GetFixedAssetS31H(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId,
        //                    listFixedAssetCategoryId, currencyCode);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        var listFixedAssetCategoryId = oRsTool.Parameters["ListFixedAssetCategoryId"].ToString();
        //        list = Model.GetFixedAssetS31H(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), listFixedAssetCategoryId,
        //                    listFixedAssetCategoryId, currencyCode);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// Báo cáo kiểm kê tài sản cố định
        ///// Gets the report fixed asset fa inventory.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<FixedAssetFAInventoryModel> GetReportFixedAssetFAInventory(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAssetFAInventoryModel> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetFAInventory())
        //        {
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;

        //                list = amountType == 1 ? Model.GetFixedAssetFAInventoryAmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventory(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode, currencyDecimalDigits);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        list = amountType == 1 ? Model.GetFixedAssetFAInventoryAmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventory(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode, currencyDecimalDigits);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);

        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

        //        if (!oRsTool.Parameters.ContainsKey("DateOfInventory"))
        //            oRsTool.Parameters.Add("DateOfInventory", _globalVariable.DateOfInventory);
        //        if (!oRsTool.Parameters.ContainsKey("HourOfInventory"))
        //            oRsTool.Parameters.Add("HourOfInventory", _globalVariable.HourOfInventory);
        //        if (!oRsTool.Parameters.ContainsKey("MinuteOfInventory"))
        //            oRsTool.Parameters.Add("MinuteOfInventory", _globalVariable.MinuteOfInventory);

        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory1"))
        //            oRsTool.Parameters.Add("JobOfInventory1", _globalVariable.JobOfInventory1);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory3"))
        //            oRsTool.Parameters.Add("JobOfInventory3", _globalVariable.JobOfInventory3);
        //        // JobOfInventoryName 
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory1"))
        //            oRsTool.Parameters.Add("NameOfInventory1", _globalVariable.NameOfInventory1);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory3"))
        //            oRsTool.Parameters.Add("NameOfInventory3", _globalVariable.NameOfInventory3);

        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());

        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //    }
        //    return list;
        //}

        ///// <summary>
        ///// Báo cáo kiểm kê tài sản cố định trên 3000USD
        ///// Gets the report fixed asset fa inventory3000.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<FixedAssetFAInventoryModel> GetReportFixedAssetFAInventory3000(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{

        //    IList<FixedAssetFAInventoryModel> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetFAInventory())
        //        {
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
        //                list = amountType == 1
        //                    ? Model.GetFixedAssetFAInventoryAmountType3000(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString())
        //                    : Model.GetFixedAssetFAInventory3000(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        list = amountType == 1
        //                    ? Model.GetFixedAssetFAInventoryAmountType3000(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString())
        //                    : Model.GetFixedAssetFAInventory3000(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);

        //        if (!oRsTool.Parameters.ContainsKey("DateOfInventory"))
        //            oRsTool.Parameters.Add("DateOfInventory", _globalVariable.DateOfInventory);
        //        if (!oRsTool.Parameters.ContainsKey("HourOfInventory"))
        //            oRsTool.Parameters.Add("HourOfInventory", _globalVariable.HourOfInventory);
        //        if (!oRsTool.Parameters.ContainsKey("MinuteOfInventory"))
        //            oRsTool.Parameters.Add("MinuteOfInventory", _globalVariable.MinuteOfInventory);

        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory1"))
        //            oRsTool.Parameters.Add("JobOfInventory1", _globalVariable.JobOfInventory1);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory3"))
        //            oRsTool.Parameters.Add("JobOfInventory3", _globalVariable.JobOfInventory3);
        //        // JobOfInventoryName 
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory1"))
        //            oRsTool.Parameters.Add("NameOfInventory1", _globalVariable.NameOfInventory1);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory3"))
        //            oRsTool.Parameters.Add("NameOfInventory3", _globalVariable.NameOfInventory3);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //    }
        //    return list;
        //}

        //public IList<FixedAssetFAInventoryHouseModel> GetReportFixedAssetFAInventoryHouse(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAssetFAInventoryHouseModel> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetFAInventoryHouse())
        //        {
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                var totalArea = frmParam.AreaOfBuilding.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var housingArea = frmParam.HousingArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var workingArea = frmParam.WorkingArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var guestHouseArea = frmParam.GuestHouseArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var vacancyArea = frmParam.OccupiedArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var otherArea = frmParam.OtherArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var accountBook = frmParam.AccountingValue.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var other = frmParam.Attachments;

        //                oRsTool.Parameters.Add("TotalArea", totalArea);
        //                oRsTool.Parameters.Add("HousingArea", housingArea);
        //                oRsTool.Parameters.Add("WorkingArea", workingArea);
        //                oRsTool.Parameters.Add("GuestHouseArea", guestHouseArea);
        //                oRsTool.Parameters.Add("VacancyArea", vacancyArea);
        //                oRsTool.Parameters.Add("OtherArea", otherArea);
        //                oRsTool.Parameters.Add("AccountBook", accountBook);
        //                oRsTool.Parameters.Add("Other", other);
        //                oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
        //                list = Model.GetFixedAssetFAInventoryHouseAmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                    GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        list = amountType == 1 ? Model.GetFixedAssetFAInventoryHouseAmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventoryHouse(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}


        //public IList<FixedAssetFAInventoryHouseModel> GetReportFixedAssetFAB01House(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAssetFAInventoryHouseModel> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetFAInventoryHouseB01())
        //        {
        //            frmParam.Text = "Danh mục trụ sở làm việc , nhà ở cơ sở hoạt động sự nghiệp đề nghị xử lý ";
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                var totalArea = frmParam.AreaOfBuilding.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var housingArea = frmParam.HousingArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var workingArea = frmParam.WorkingArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var guestHouseArea = frmParam.GuestHouseArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var vacancyArea = frmParam.OccupiedArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var otherArea = frmParam.OtherArea.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var accountBook = frmParam.AccountingValue.ToString(@"c" + (new GlobalVariable()).CurrencyDecimalDigits);
        //                var other = frmParam.Attachments;


        //                oRsTool.Parameters.Add("TotalArea", totalArea);
        //                oRsTool.Parameters.Add("HousingArea", housingArea);
        //                oRsTool.Parameters.Add("WorkingArea", workingArea);
        //                oRsTool.Parameters.Add("GuestHouseArea", guestHouseArea);
        //                oRsTool.Parameters.Add("VacancyArea", vacancyArea);
        //                oRsTool.Parameters.Add("OtherArea", otherArea);
        //                oRsTool.Parameters.Add("AccountBook", accountBook);
        //                oRsTool.Parameters.Add("Other", other);

        //                oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
        //                list = Model.GetFixedAssetFAB01House(GlobalVariable.FromDate.ToShortDateString(),
        //                    GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        list = amountType == 1 ? Model.GetFixedAssetFAB01House(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventoryHouse(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}


        ///// <summary>
        ///// Báo cáo kiểm kê tài sản cố định
        ///// Gets the report fixed asset fa inventory.
        ///// </summary>
        ///// <param name="frmParent">The FRM parent.</param>
        ///// <param name="commonVariable">The common variable.</param>
        ///// <param name="oRsTool">The o rs tool.</param>
        ///// <returns></returns>
        //public IList<FixedAssetFAInventoryCarModel> GetReportFixedAssetFAInventoryCar(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAssetFAInventoryCarModel> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetFAInventoryCar())
        //        {
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
        //                list = Model.GetFixedAssetFAInventoryCarAmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                    GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        list = amountType == 1 ? Model.GetFixedAssetFAInventoryCarAmountType(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventoryCar(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}

        //public IList<FixedAssetFAInventoryCarModel> GetReportFixedAssetFAB01Car(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAssetFAInventoryCarModel> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetFAInventoryCar())
        //        {
        //            frmParam.Text = "Danh mục xe ô tô đề nghị xử lý ";
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
        //                list = Model.GetFixedAssetFAB01Car(GlobalVariable.FromDate.ToShortDateString(),
        //                    GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        list = amountType == 1 ? Model.GetFixedAssetFAB01Car(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits) : Model.GetFixedAssetFAInventoryCar(GlobalVariable.FromDate.ToShortDateString(),
        //                        GlobalVariable.ToDate.ToShortDateString(), currencyCode);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}

        //public IList<FixedAsset30KPart2Model> GetFixedAsset30KPart2(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAsset30KPart2Model> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetFAInventoryCar())
        //        {
        //            frmParam.Text = "Báo cáo kê khai tài sản cố định có nguyên giá 30.000 trở lên ( Mẫu mới)";
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
        //                list = Model.GetFixedAsset30KPart2(GlobalVariable.FromDate.ToShortDateString(),
        //                    GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        list = Model.GetFixedAsset30KPart2(GlobalVariable.FromDate.ToShortDateString(),
        //            GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}

        //public IList<FixedAssetB03H30KModel> GetFixedAssetB03H30K(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAssetB03H30KModel> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetFAInventoryCar())
        //        {
        //            frmParam.Text = "Báo cáo tình hình tăng, giảm tài sản nhà nước";
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                isTotalBandInNewPage = frmParam.IsTotalBandInNewPage;
        //                list = Model.GetFixedAssetB03H30K(GlobalVariable.FromDate.ToShortDateString(),
        //                    GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        list = Model.GetFixedAssetB03H30K(GlobalVariable.FromDate.ToShortDateString(),
        //            GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);
        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}

        //public IList<FixedAsset30KPart2Model> GetFixedAssetFAB0130KPart2(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    IList<FixedAsset30KPart2Model> list = null;
        //    var amountType = GlobalVariable.AmountTypeViewReport;
        //    var currencyCode = GlobalVariable.CurrencyViewReport;
        //    var isTotalBandInNewPage = false;
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (!oRsTool.IsRefresh)
        //    {
        //        using (var frmParam = new FrmXtraFixedAssetFAInventoryCar())
        //        {
        //            frmParam.Text = "Danh mục tài sản khác (trừ trụ sở làm việc và xe ô tô) đề nghị xử lý ";
        //            if (frmParam.ShowDialog() == DialogResult.OK)
        //            {
        //                GlobalVariable.FromDate = DateTime.Parse(frmParam.FromDate);
        //                GlobalVariable.ToDate = DateTime.Parse(frmParam.ToDate);
        //                checked
        //                {

        //                }
        //                list = Model.GetFixedAssetFAB0130KPart2(GlobalVariable.FromDate.ToShortDateString(),
        //                    GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        list = Model.GetFixedAssetFAB0130KPart2(GlobalVariable.FromDate.ToShortDateString(),
        //            GlobalVariable.ToDate.ToShortDateString(), currencyDecimalDigits);
        //    }
        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
        //            oRsTool.Parameters.Add("CurrencyCodeUnit",
        //                "Đơn vị tính " + (amountType == 2 ? "(nguyên tệ): " : "(quy đổi): ") + currencyCode);
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("IsTotalBandInNewPage"))
        //            oRsTool.Parameters.Add("IsTotalBandInNewPage", isTotalBandInNewPage);

        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);
        //    }
        //    return list;
        //}

        //public IList<FixedAssetCardModel> GetReportFixedAssetCard(XtraForm frmParent, Session.GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        //{
        //    int currencyDecimalDigits = int.Parse(_globalVariable.CurrencyDecimalDigits);
        //    if (commonVariable.RefIdList == null)
        //    {
        //        commonVariable.RefIdList = commonVariable.RefId.ToString(CultureInfo.InvariantCulture);
        //    }

        //    IList<FixedAssetCardModel> list = Model.GetFixedAssetCard(commonVariable.RefIdList, currencyDecimalDigits);


        //    if (list != null && list.Count > 0)
        //    {
        //        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
        //            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("FromDate"))
        //            oRsTool.Parameters.Add("FromDate", GlobalVariable.FromDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("ToDate"))
        //            oRsTool.Parameters.Add("ToDate", GlobalVariable.ToDate.ToShortDateString());
        //        if (!oRsTool.Parameters.ContainsKey("Province"))
        //            oRsTool.Parameters.Add("Province", _globalVariable.CompanyProvince);
        //        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
        //            oRsTool.Parameters.Add("ReportDate", _globalVariable.PostedDate);
        //        if (!oRsTool.Parameters.ContainsKey("JobOfInventory2"))
        //            oRsTool.Parameters.Add("JobOfInventory2", _globalVariable.JobOfInventory2);
        //        if (!oRsTool.Parameters.ContainsKey("NameOfInventory2"))
        //            oRsTool.Parameters.Add("NameOfInventory2", _globalVariable.NameOfInventory2);

        //        if (!oRsTool.Parameters.ContainsKey("CurrencyLocal"))
        //            oRsTool.Parameters.Add("CurrencyLocal", _globalVariable.CurrencyLocal);
        //    }

        //    return list;
        //}

        #endregion

        public static void RenderDynamic(DataTable dtSource)
        {
            var reportSlot = new FileReportSlot { FilePath = GlobalVariable.ReportPath + "C56-HD.rst" };

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
            "if (GetData(\"Targets\").ToString().StartsWith(\"I-\")) txtdetailNumber1.Text = \"1\";else if (GetData(\"Targets\").ToString().StartsWith(\"II-\")) txtdetailNumber1.Text = \"2\";" +
            "else if (GetData(\"Targets\").ToString().StartsWith(\"III-\")) txtdetailNumber1.Text = \"3\";" +
            "else if (GetData(\"Targets\").ToString().StartsWith(\"IV-\")) txtdetailNumber1.Text = \"4\";" +
            "else txtdetailNumber1.Text = \"\";" +
                       "decimal rate =  decimal.Parse(GetData(\"AnnualDepreciationRate\").ToString() == \"0\"?\"0\":GetData(\"AnnualDepreciationRate\").ToString()); " +
                                    "txtDetailAmountRate.Value= rate==0 ? \"\": rate.ToString(\"0.##\"); " +
                                    "txtDetailOrg.Value = GetData(\"OrgPrice\").ToString() == \"0\"?\"\":((decimal) GetData(\"OrgPrice\")).ToString(\"N0\") ; " +
                                    //"txtDetailOrg.TextFormat =(PerpetuumSoft.Framework.Text.TextFormat)GetData(\"RssObject.CurrencyFormat\"); " +                                   
                                    "txtDetailAnnualDepreciationAmount.Value = GetData(\"AnnualDepreciationAmount\").ToString() == \"0\"?\"\":((decimal)GetData(\"AnnualDepreciationAmount\")).ToString(\"N0\") ;" +
                                     //"txtDetailAnnualDepreciationAmount.TextFormat=(PerpetuumSoft.Framework.Text.TextFormat)GetData(\"RssObject.CurrencyFormat\"); "
                                     "if(GetData(\"ChildrenId\").ToString()==\"0\") " +
                                    "{ txtdetailNumber1.StyleName =  \"DetailNormalBold\"; txtDetailTargets.StyleName =  \"DetailNormalBold\";  txtDetailAmountRate.StyleName =  \"DetailNormalBold\";  txtDetailOrg.StyleName =  \"DetailNormalBold\"; txtDetailAnnualDepreciationAmount.StyleName =  \"DetailNormalBold\";" + "}"
                                    + "else { txtdetailNumber1.StyleName = \"DetailNormal\"; txtDetailTargets.StyleName =  \"DetailNormal\"; txtDetailAmountRate.StyleName =  \"DetailNormal\";  txtDetailOrg.StyleName =  \"DetailNormal\"; txtDetailAnnualDepreciationAmount.StyleName =  \"DetailNormal\";  }";


            #endregion

            double marginLeft = 16.7f;
            int countDynamicColumn = 0;
            int numberheader3 = 4;

            Dictionary<string, Type> fieldList = new Dictionary<string, Type>();

            foreach (DataColumn dtCol in dtSource.Columns)
            {
                if (dtCol.Caption.Contains("Dynamic"))
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
                if (dtColumn.Key.Contains("Dynamic"))
                {
                    #region Header

                    textBoxHeader = new PerpetuumSoft.Reporting.DOM.TextBox();
                    textBoxHeader.Name = "txt" + dtColumn.Key.Replace("Dynamic", "");
                    textBoxHeader.Text = "TK " + dtColumn.Key.Replace("Dynamic", "");
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
                    textBoxDetail.Name = "txtDetail" + dtColumn.Key.Replace("Dynamic", "");
                    textBoxDetail.Text = dtColumn.Key.Replace("Dynamic", "");
                    textBoxDetail.GenerateScript = textBoxDetail.Name.ToString() + ".Value= GetData(\"" + dtColumn.Key + "\");"
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

                //textBoxFooter.GenerateScript = textBoxFooter.Name + ".Value=\"Trang \" + PageNumber.ToString()+"+
                //   "\"/"+ n+"\";";
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

                    if (dtColumn.Key.Contains("Dynamic"))
                    {
                        #region Header

                        textBoxHeader2N = new PerpetuumSoft.Reporting.DOM.TextBox();
                        textBoxHeader2N.Name = "txt" + dtColumn.Key.Replace("Dynamic", "");
                        textBoxHeader2N.Text = "TK " + dtColumn.Key.Replace("Dynamic", "");
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
                        textBoxDetailN.Name = "txtDetail" + dtColumn.Key.Replace("Dynamic", "");
                        textBoxDetailN.Text = dtColumn.Key.Replace("Dynamic", "");
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
    }

}




