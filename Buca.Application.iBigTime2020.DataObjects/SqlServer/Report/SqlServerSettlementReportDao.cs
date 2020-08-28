/***********************************************************************
 * <copyright file="SqlServerSettlementReportDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, March 29, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using Buca.Application.iBigTime2020.BusinessEntities.Report.SettlementReport;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    /// <summary>
    /// Class SqlServerSettlementReportDao.
    /// </summary>
    public class SqlServerSettlementReportDao : ISettlementReportDao
    {
        /// <summary>
        /// Gets the report B02 BCQT.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="isPrintMonth13">if set to <c>true</c> [is print month13].</param>
        /// <param name="isAddDataMonth13">if set to <c>true</c> [is add data month13].</param>
        /// <returns></returns>
        public IList<B02BCQTEntity> GetReportB02BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode,
            bool isSummaryChapter, bool isPrintMonth13, bool isAddDataMonth13)
        {
            const string sql = @"[dbo].[uspReport_GetB02BCQT]";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate
            };

            Func<IDataReader, B02BCQTEntity> MakeB02BCQT = reader =>
                new B02BCQTEntity
                {
                    ReportItemIndex = reader["ReportItemIndex"].AsString(),
                    ReportItemCode = reader["ReportItemCode"].AsString(),
                    ReportItemName = reader["ReportItemName"].AsString()
                };

            return Db.ReadList(sql, true, MakeB02BCQT, parms);
        }

        /// <summary>
        /// Gets the report B03 BCQT.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="isPrintMonth13">if set to <c>true</c> [is print month13].</param>
        /// <param name="isAddDataMonth13">if set to <c>true</c> [is add data month13].</param>
        /// <returns></returns>
        public IList<B03BCQTEntity> GetReportB03BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode,
            bool isSummaryChapter, bool isPrintMonth13, bool isAddDataMonth13)
        {
            const string sql = @"[dbo].[uspReport_GetB03BCQT]";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", budgetChapterCode,
                "@pSummaryBudgetChapter", isSummaryChapter,
                "@IsPrintMonth13", isPrintMonth13,
                "@IsAddDataMonth13", isAddDataMonth13
            };

            Func<IDataReader, B03BCQTEntity> MakeB03BCQT = reader =>
                new B03BCQTEntity
                {
                    ReportItemIndex = reader["ReportItemIndex"].AsInt(),
                    ReportItemAlias = reader["ReportItemAlias"].AsString(),
                    ReportItemCode = reader["ReportItemCode"].AsString(),
                    ReportItemName = reader["ReportItemName"].AsString(),
                    Grade = reader["Type"].AsInt(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    GroupName = reader["GroupName"].AsString(),
                    GroupTypeChild = reader["GroupTypeChild"].AsString(),
                    GroupType = reader["GroupType"].AsString(),
                    IsBold = reader["IsBold"].AsBool(),
                    IsItalic = reader["IsItalic"].AsBool(),
                    Col1 = reader["Col1"].AsDecimal(),
                    Col2 = reader["Col2"].AsDecimal(),
                    Col3 = reader["Col2"].AsDecimal()
                };

            return Db.ReadList(sql, true, MakeB03BCQT, parms);
        }

        /// <summary>
        /// Gets the report F01001 BCQT.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItem">The budget sub kind item.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <returns>IList{F0101BCQTEntity}.</returns>
        public IList<F0101BCQTEntity> GetReportF01001BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceCode,
            string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, int amountType, string CurrencyCode)
        {
            const string sql = @"[dbo].[uspReport_GetF0101BCQT]";
            object[] parms =
            {
                "@StartDate", startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@BudgetSource", budgetSourceCode,
                "@BudgetChapter", budgetChapterCode,
                "@BudgetSubKindItem", budgetSubKindItem,
                "@SummaryBudgetSource", isSummaryBudgetSource,
                "@SummaryBudgetChapter", isSummaryBudgetChapter,
                "@SummaryBudgetSubKindItem", isSummaryBudgetSubKindItem,
                "@AmountType", amountType,
                "CurrencyCode", CurrencyCode
            };

            Func<IDataReader, F0101BCQTEntity> MakeF0101BCQT = reader =>
                new F0101BCQTEntity
                {
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    ReportItemName = reader["ReportItemName"].AsString(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    BudgetSubKindItemName = reader["BudgetSubKindItemName"].AsString(),
                    BudgetItemCode = reader["BudgetItemCode"].AsString(),
                    BudgetItemName = reader["BudgetItemName"].AsString(),
                    BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                    BudgetSubItemName = reader["BudgetSubItemName"].AsString(),
                    TotalAmount = reader["TotalAmount"].AsDecimal(),
                    DomesticBudgetAmount = reader["DomesticBudgetAmount"].AsDecimal(),
                    AidBudgetAmount = reader["AidBudgetAmount"].AsDecimal(),
                    ForeignLoansBudgetAmount = reader["ForeignLoansBudgetAmount"].AsDecimal(),
                    DeductibleBudgetAmount = reader["DeductibleBudgetAmount"].AsDecimal(),
                    OtherBudgetAmount = reader["OtherBudgetAmount"].AsDecimal()
                };

            return Db.ReadList(sql, true, MakeF0101BCQT, parms);
        }

        /// <summary>
        /// Gets the report B01 BCQT.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItem">The budget sub kind item.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <returns></returns>
        public DataSet GetReportB01BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceCode,
            string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem, int amountType, string currencyCode)
        {
            const string sql = @"[dbo].[uspReport_FIR_Get01_BCQT]";
            object[] parms =
            {
                "@StartDate", startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@ListBudgetSourceID", budgetSourceCode,
                "@BudgetChapterCode", budgetChapterCode,
                "@ListBudgetKindItemCode", budgetSubKindItem,
                "@IsSummaryBudgetSource", isSummaryBudgetSource,
                "@IsSummaryBudgetChapter", isSummaryBudgetChapter,
                "@IsSummaryBudgetKindItem", isSummaryBudgetSubKindItem,
                "@AmountType", amountType,
                "@CurrencyCode", currencyCode,
            };
            return Db.ReadDataSet(sql, true, parms);
        }

        public DataSet GetReportF0102BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceCode,
            string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource, bool isSummaryBudgetChapter,
            bool isSummaryBudgetSubKindItem,string listprojectID,int methodDistribute,bool isMethodDistribute,bool isProject)
        {
            const string sql = @"[dbo].[Proc_FIR_GetF01_02_BCQT]";
            object[] parms =
            {
                "@StartDate", startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@ListBudgetSourceID", budgetSourceCode,
                "@BudgetChapterCode", budgetChapterCode,
                "@ProjectID",listprojectID,
                "@EnumMethodDistributeID",methodDistribute ,
                "@ListBudgetKindItemCode", budgetSubKindItem,
                "@IsSummaryBudgetSource", isSummaryBudgetSource,
                "@IsSummaryBudgetChapter", isSummaryBudgetChapter,
                "@IsSummaryBudgetKindItem", isSummaryBudgetSubKindItem,
                "@IsSummaryMethodDistribute" , isMethodDistribute,
                "@IsSummaryProject",isProject
            };
            return Db.ReadDataSet(sql, true, parms);
        }

        #region Nhóm báo cáo xuất XML Báo cáo tài chính
        /// <summary>
        /// B01/BCQT: Báo cáo quyết toán kinh phí hoạt động xuất xml
        /// </summary>
        public DataSet GetReportB01BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName, bool isSummaryXKKD)
        {
            //const string sql = @"Proc_FIR_Get01_BCQT_ToX1";
            object[] parms =
            {
                "@StartDate", startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@IsSummarySXKD", isSummaryXKKD,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }

        /// <summary>
        /// Thuyết minh báo cáo quyết toán
        /// </summary>
        public DataSet GetReportB03BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 0,
                "@IsPrintMonth13", 0,
                "@IsAddDataMonth13", 1,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }

        /// <summary>
        /// Báo cáo tình hình tài chính
        /// </summary>
        public DataSet GetReportBCTC01_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName, string budgetChapterCode, bool isSummaryBudgetChapter)
        {
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 0,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }

        /// <summary>
        /// Báo cáo kết quả hoạt động
        /// </summary>
        public DataSet GetReportBCTC02_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 0,
                "@pMasterID", null,
                "@pIsPrintMonth13", null,
                "@pIsPrintAllYearAndMonth13", null,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }

        /// <summary>
        /// B04/BCTC: Thuyết minh báo cáo tài chính
        /// </summary>
        public DataSet GetReportBCTC04_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 0,
                "@pMasterID", null,
                "@pIsPrintMonth13", null,
                "@pIsPrintAllYearAndMonth13", null,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }


        /// <summary>
        /// B03bBCTC: Báo cáo lưu chuyển tiền tệ gián tiếp
        /// </summary>
        public DataSet GetReportB03bBCTC_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 0,
                "@pMasterID", null,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }

        /// <summary>
        /// B05/BCTC: Báo cáo tài chính mẫu đơn giản
        /// </summary>
        public DataSet GetReportBCTC05_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 0,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }

        /// <summary>
        /// F01/01 BCQT: Báo cáo chi tiết nguồn NSNN khấu trừ để lại
        /// </summary>
        public DataSet GetReportF0101BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetSource", null,
                "@pBudgetChapter", null,
                "@pBudgetSubKindItem", null,
                "@pSummaryBudgetSource", 0,
                "@pSummaryBudgetChapter", 0,
                "@pSummaryBudgetSubKindItem", 0,
                "@IsSummarySXKD", 0,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }

        /// <summary>
        /// Phụ biểu F01-02/BCQT - Phần 2: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
        /// </summary>
        public DataSet GetReportF0102BCQTP2_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            object[] parms =
            {
                "@StartDate", startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@ListBudgetSourceID", null,
                "@BudgetChapterCode", null,
                "@ListBudgetKindItemCode", null,
                "@EnumMethodDistributeID", null,
                "@ProjectID", null,
                "@IsSummaryBudgetSource", 0,
                "@IsSummaryBudgetChapter", 0,
                "@IsSummaryBudgetKindItem", 0,
                "@IsSummaryMethodDistribute", 0,
                "@IsSummaryProject", 0,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }
        

        /// <summary>
        /// Phụ biểu F01-02/BCQT - Phần 1: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
        /// </summary>
        public DataSet GetReportF0102BCQTP1_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            object[] parms =
            {
                "@StartDate", startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@ListBudgetSourceID", null,
                "@BudgetChapterCode", null,
                "@ListBudgetKindItemCode", null,
                "@EnumMethodDistributeID", null,
                "@ProjectID", null,
                "@IsSummaryBudgetSource", 0,
                "@IsSummaryBudgetChapter", 0,
                "@IsSummaryBudgetKindItem", 0,
                "@IsSummaryMethodDistribute", 0,
                "@IsSummaryProject", 0,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }

        /// <summary>
        /// B01/BSTT: Báo cáo bổ sung thông tin tài chính
        /// </summary>
        public DataSet GetReportB01BSTT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 0,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }
        #endregion

        #region Nhóm xuất khẩu BC gửi kho bạc nhà nước
        /// <summary>
        /// B01/BCTC
        /// </summary>
        public DataSet GetSumReportB01BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            const string sql = @"usp_Get_SumReport_B01BCTC";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 1,
            };
            return Db.ReadDataSet(sql, true, parms);
        } 

        /// <summary>
        /// B02/BCTC
        /// </summary>
        public DataSet GetSumReportB02BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            const string sql = @"usp_Get_SumReport_B02BCTC";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 1,
            };
            return Db.ReadDataSet(sql, true, parms);
        } 

        /// <summary>
        /// B03a/BCTC
        /// </summary>
        public DataSet GetSumReportB03aBCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            const string sql = @"usp_Get_SumReport_B03aBCTC";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 1,
            };
            return Db.ReadDataSet(sql, true, parms);
        } 

        /// <summary>
        /// B03b/BCTC
        /// </summary>
        public DataSet GetSumReportB03bBCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            const string sql = @"usp_Get_SumReport_B03bBCTC";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 1,
            };
            return Db.ReadDataSet(sql, true, parms);
        } 

        /// <summary>
        /// B04/BCTC
        /// </summary>
        public DataSet GetSumReportB04BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            const string sql = @"usp_Get_SumReport_B04BCTC";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 1,
            };
            return Db.ReadDataSet(sql, true, parms);
        }

        /// <summary>
        /// B01BSTT
        /// </summary>
        public DataSet GetSumReportB01BSTT_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            const string sql = @"usp_Get_SumReport_B01BSTT";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", null,
                "@pSummaryBudgetChapter", 1,
            };
            return Db.ReadDataSet(sql, true, parms);
        }
        #endregion


        /// <summary>
        /// S05H: Bảng cân đối số phát sinh
        /// </summary>
        public DataSet GetReportS05H_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName)
        {
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@budgetChapterCode", null,
                "@pSummaryBudgetChapter", 0,
                "@BudgetSourceID", "a0624cfa-d105-422f-bf20-11f246704dc3",
                "@ListBudgetKindItemCode", null,
                "@pSummaryBudgetSubKindItem", 0,
            };
            return Db.ReadDataSet(procedureName, true, parms);
        }
    }
}
