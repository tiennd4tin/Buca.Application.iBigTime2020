using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using BuCA.Application.iBigTime2020.Session;
using System.Linq;
using System.Xml;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    public class ExportXmlBCTC : BaseReport
    {
        public ExportXmlBCTC()
        {
            Model = new Model();
        }

        private IList<object> MappingDataset(DataSet ds, int slotArray)
        {
            IList<object> list = new List<object>();
            Dictionary<string, Type> fieldList = new Dictionary<string, Type>();

            foreach (DataColumn dtCol in ds.Tables[slotArray].Columns)
            {
                fieldList.Add(dtCol.ColumnName, dtCol.DataType);
            }

            int i = 0;

            foreach (DataRow dtRow in ds.Tables[slotArray].Rows)
            {
                object dynamicObj = DynamicObject.DynamicObject.CreateNewObject(fieldList);
                foreach (var field in fieldList.OrderBy(r => r.Key))
                {
                    PropertyInfo propertyInfos = dynamicObj.GetType().GetProperty(field.Key);

                    var value = string.Empty;
                    value = dtRow[field.Key].ToString();

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
            return list;
        }

        /// <summary>
        /// B01/BCQT: Báo cáo quyết toán kinh phí hoạt động
        /// </summary>
        public DataSet GetReportB01BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportB01BCQT_XmlBCTC(startDate,
                fromDate, toDate, procedureName, false);
            return ds;
        }

        /// <summary>
        /// B03/BCQT: Thuyết minh báo cáo quyết toán
        /// </summary>
        public DataSet GetReportB03BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportB03BCQT_XmlBCTC(startDate,
                fromDate, toDate, procedureName);
            return ds;
        }

        /// <summary>
        /// BCTC01: Báo cáo tình hình tài chính
        /// </summary>
        public DataSet GetReportBCTC01_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportBCTC01_XmlBCTC(startDate, fromDate, toDate, procedureName, null,
                false);
            return ds;
        }

        /// <summary>
        /// BCTC02: Báo cáo kết quả hoạt động
        /// </summary>
        public DataSet GetReportBCTC02_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportBCTC02_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return ds;
        }

        /// <summary>
        /// BCTC04: Thuyết minh báo cáo tài chính
        /// </summary>
        public DataSet GetReportBCTC04_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportBCTC04_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return ds;
        }

        /// <summary>
        /// B03bBCTC: Báo cáo lưu chuyển tiền tệ gián tiếp
        /// </summary>
        public DataSet GetReportB03bBCTC_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportB03bBCTC_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return ds;
        }

        /// <summary>
        /// B05/BCTC: Báo cáo tài chính mẫu đơn giản
        /// </summary>
        public DataSet GetReportBCTC05_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportBCTC05_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return ds;
        }

        /// <summary>
        /// F01/01 BCQT: Báo cáo chi tiết nguồn NSNN khấu trừ để lại
        /// </summary>
        public DataSet GetReportF0101BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportF0101BCQT_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return ds;
        }

        /// <summary>
        /// Phụ biểu F01-02/BCQT - Phần 1: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
        /// </summary>
        public DataSet GetReportF0102BCQTP1_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportF0102BCQTP1_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return ds;
        }

        /// <summary>
        /// Phụ biểu F01-02/BCQT - Phần 2: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
        /// </summary>
        public DataSet GetReportF0102BCQTP2_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportF0102BCQTP2_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return ds;
        }

        /// <summary>
        /// B01/BSTT: Báo cáo bổ sung thông tin tài chính
        /// </summary>
        public DataSet GetReportB01BSTT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportB01BSTT_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return ds;
        }

        /// <summary>
        /// S05H: Bảng cân đối số phát sinh
        /// </summary>
        public DataSet GetReportS05H_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            DataSet ds = Model.GetReportS05H_XmlBCTC(startDate, fromDate, toDate, procedureName);
            return ds;
        }
    }
}
