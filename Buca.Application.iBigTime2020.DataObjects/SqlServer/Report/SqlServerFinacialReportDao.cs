/***********************************************************************
 * <copyright file="sqlserverfinacialreportdao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    /// <summary>
    /// SqlServerFinacialReportDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report.IFinacialReportDao" />
    public class SqlServerFinacialReportDao : IFinacialReportDao
    {
        /// <summary>
        /// Gets the report B01 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItem">The budget sub kind item.</param>
        /// <param name="iAccountGrade">The i account grade.</param>
        /// <param name="isSummarySource">if set to <c>true</c> [is summary source].</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="isSummarySubKindItem">if set to <c>true</c> [is summary sub kind item].</param>
        /// <param name="pIsPrintMonth13">if set to <c>true</c> [p is print month13].</param>
        /// <param name="pIsAddDataMonth13">if set to <c>true</c> [p is add data month13].</param>
        /// <param name="pIsPrintAccountDetailByBudgetSource">if set to <c>true</c> [p is print account detail by budget source].</param>
        /// <param name="pIsPrintAccountDecided">if set to <c>true</c> [p is print account decided].</param>
        /// <returns></returns>
        public IList<B01HEntity> GetReportB01H(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceId,
            string budgetChapterCode, string budgetSubKindItem, int iAccountGrade, bool isSummarySource,
            bool isSummaryChapter,
            bool isSummarySubKindItem, bool pIsPrintMonth13, bool pIsAddDataMonth13,
            bool pIsPrintAccountDetailByBudgetSource,
            bool pIsPrintAccountDecided,
            int amountType,
            string currencyCode)
        {
            const string sql = @"[dbo].[uspGet_ReportB01H]";
            object[] parms =
            {
                "@StartDate", startDate,
                "@FromDate", fromDate,
                "@Todate", toDate,
                "@BudgetSourceID", budgetSourceId,
                "@BudgetChapterCode", budgetChapterCode,
                "@BudgetSubKindItem", budgetSubKindItem,
                "@iAccountGrade", iAccountGrade,
                "@isSummarySource", isSummarySource,
                "@isSummaryChapter", isSummaryChapter,
                "@isSummarySubKindItem", isSummarySubKindItem,
                "@pIsPrintMonth13", pIsPrintMonth13,
                "@pIsAddDataMonth13", pIsAddDataMonth13,
                "@pIsPrintAccountDetailByBudgetSource", pIsPrintAccountDetailByBudgetSource,
                "@pIsPrintAccountDecided", pIsPrintAccountDecided,
                "@AmountType", amountType,
                "@CurrencyCode", currencyCode
            };

            Func<IDataReader, B01HEntity> makeB01H = reader =>
                new B01HEntity
                {
                    AccountCategory = reader["AccountCategory"].AsString().AsIntForNull(),
                    AccountCategoryKind = reader["AccountCategoryKind"].AsString().AsIntForNull(),
                    AccountGrade = reader["AccountGrade"].AsString().AsIntForNull(),
                    AccountNumber = reader["AccountNumber"].AsString(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                    BudgetSourceId = reader["BudgetSourceID"].AsString(),
                    BudgetSourceName = reader["BudgetSourceName"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    ClosingCredit = reader["ClosingCredit"].AsDecimal(),
                    ClosingDebit = reader["ClosingDebit"].AsDecimal(),
                    Grade = reader["Grade"].AsInt(),
                    MovementAccumCredit = reader["MovementAccumCredit"].AsDecimal(),
                    MovementAccumDebit = reader["MovementAccumDebit"].AsDecimal(),
                    MovementCredit = reader["MovementCredit"].AsDecimal(),
                    MovementDebit = reader["MovementDebit"].AsDecimal(),
                    OpeningCredit = reader["OpeningCredit"].AsDecimal(),
                    OpeningDebit = reader["OpeningDebit"].AsDecimal(),
                    SortOrder = reader["SortOrder"].AsString().AsIntForNull(),
                    IsPrintMonth13 = reader["IsPrintMonth13"].AsBool(),
                    AccountName = reader["AccountName"].AsString()
                };

            return Db.ReadList(sql, true, makeB01H, parms);
        }
        /// <summary>
        /// Gets the report B01 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>
        /// IList&lt;B01_BCTCEntity&gt;.
        /// </returns>
        public IList<B01_BCTCEntity> GetReportB01_BCTC( DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter,bool pIsGetFromGLFIRSetting, string masterId, int AmountType, string CurrencyCode)
        {
            const string sql = @"[dbo].[uspReport_Get01_BCTC]";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", budgetChapterCode,
                "@pSummaryBudgetChapter", isSummaryChapter,
                "@pIsGetFromGLFIRSetting",pIsGetFromGLFIRSetting,
                "@pMasterID",masterId,
                "@AmountType" ,AmountType,
                "@CurrencyCode" ,CurrencyCode
            };

            Func<IDataReader, B01_BCTCEntity> makeB01_BCTC = reader =>
                new B01_BCTCEntity
                {
                    MasterId = reader["MasterID"].AsString(),
                    DetailId = reader["DetailID"].AsString(),
                    ColA = reader["ColA"].AsString(),
                    ReportItemAlias = reader["ReportItemAlias"].AsString(),
                    ReportItemName = reader["ReportItemName"].AsString(),
                    ReportItemCode = reader["ReportItemCode"].AsString(),
                    Col1 = reader["Col1"].AsDecimal(),
                    Col2 = reader["Col2"].AsDecimal(),
                    SortOrder = reader["SortOrder"].AsInt(),
                    IsBold = reader["IsBold"].AsBool(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    Formula = reader["Formula"].AsString(),
                    CreatedDate = reader["CreatedDate"].AsDateTime(),
                    DayOfDateSystem = reader["DayOfDateSystem"].AsInt(),
                    MonthOfDateSystem = reader["MonthOfDateSystem"].AsInt(),
                    YearOfDateSystem = reader["YearOfDateSystem"].AsInt(),
                    CompanyChiefAccountant = reader["CompanyChiefAccountant"].AsString(),
                    CompanyReportPreparer = reader["CompanyReportPreparer"].AsString(),
                    CompanyDirector = reader["CompanyDirector"].AsString()


                };

            return Db.ReadList(sql, true, makeB01_BCTC, parms);
        }
        /// <summary>
        /// Gets the report B02 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>
        /// IList&lt;B01_BCTCEntity&gt;.
        /// </returns>
        public IList<B02_BCTCEntity> GetReportB02_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId,int amountType,string currencyCode)
        {
            const string sql = @"[dbo].[Proc_FIR_Get02_BCTC]";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", budgetChapterCode,
                "@pSummaryBudgetChapter", isSummaryChapter,
                "@pIsGetFromGLFIRSetting",pIsGetFromGLFIRSetting,
                "@pMasterID",masterId,
                "@AmountType",amountType,
                "@CurrencyCode",currencyCode
            };

            Func<IDataReader, B02_BCTCEntity> makeB02_BCTC = reader =>
                new B02_BCTCEntity
                {
                    MasterId = reader["MasterID"].AsString(),
                    DetailId = reader["DetailID"].AsString(),
                    ColA = reader["ColA"].AsString(),
                    //ReportItemAlias = reader["ReportItemAlias"].AsString(),
                    ReportItemName = reader["ReportItemName"].AsString(),
                    ReportItemCode = reader["ReportItemCode"].AsString(),
                    Col1 = reader["Col1"].AsDecimal(),
                    Col2 = reader["Col2"].AsDecimal(),
                    SortOrder = reader["SortOrder"].AsInt(),
                    IsBold = reader["IsBold"].AsBool(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    Formula = reader["Formula"].AsString(),
                    CreatedDate = reader["CreatedDate"].AsDateTimeForNull(),
                    DayOfDateSystem = reader["DayOfDateSystem"].AsInt(),
                    MonthOfDateSystem = reader["MonthOfDateSystem"].AsInt(),
                    YearOfDateSystem = reader["YearOfDateSystem"].AsInt(),
                    CompanyChiefAccountant = reader["CompanyChiefAccountant"].AsString(),
                    CompanyReportPreparer = reader["CompanyReportPreparer"].AsString(),
                    CompanyDirector = reader["CompanyDirector"].AsString(),
                    //Description = reader["Description"].AsString()

                };

            return Db.ReadList(sql, true, makeB02_BCTC, parms);
        }
        /// <summary>
        /// Gets the report B05 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <returns>
        /// IList&lt;B05_BCTCEntity&gt;.
        /// </returns>
        public IList<B05_BCTCEntity> GetReportB05_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter)
        {
            const string sql = @"[dbo].[uspReport_Get05_BCTC]";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", budgetChapterCode,
                "@pSummaryBudgetChapter", isSummaryChapter
            };

            Func<IDataReader, B05_BCTCEntity> makeB05_BCTC = reader =>
                new B05_BCTCEntity
                {
                    ReportItemIndex = reader["ReportItemIndex"].AsString(),
                    ReportItemAlias = reader["ReportItemAlias"].AsString(),
                    ReportItemName = reader["ReportItemName"].AsString(),
                    ReportItemCode = reader["ReportItemCode"].AsString(),
                    Type = reader["Type"].AsInt(),
                    Col1 = reader["Col1"].AsDecimal(),
                    Col2 = reader["Col2"].AsDecimal(),
                    SortOrder = reader["SortOrder"].AsInt(),
                    IsBold = reader["IsBold"].AsBool(),
                    IsItalic = reader["IsItalic"].AsBool(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    GroupName = reader["GroupName"].AsString(),
                    GroupType = reader["GroupType"].AsString()
                };

            return Db.ReadList(sql, true, makeB05_BCTC, parms);
        }
        /// <summary>
        /// Gets the report B04 BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns>
        /// IList&lt;B04_BCTCEntity&gt;.
        /// </returns>
        public IList<B04_BCTCEntity> GetReportB04_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
           string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId)
        {
            const string sql = @"[dbo].[uspReport_Get04_BCTC]";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", budgetChapterCode,
                "@pSummaryBudgetChapter", isSummaryChapter,
                "@pIsGetFromGLFIRSetting",pIsGetFromGLFIRSetting,
                "@pMasterID",masterId
            };

            Func<IDataReader, B04_BCTCEntity> makeB04_BCTC = reader =>
                new B04_BCTCEntity
                {
                    MasterId = reader["MasterID"].AsString(),
                    DetailId = reader["DetailID"].AsString(),
                    ReportItemCode = reader["ReportItemCode"].AsInt(),
                    ReportItemName = reader["ReportItemName"].AsString(),
                    ContentString = reader["ContentString"].AsString(),
                    //ContentNumber = reader["ContentNumber"].AsDecimal(),
                    IsBold = reader["IsBold"].AsBool(),
                    Type = reader["Type"].AsInt(),
                    GroupType = reader["GroupType"].AsString(),
                    GroupCode = reader["GroupCode"].AsInt(),
                    SortOrder = reader["SortOrder"].AsInt(),
                    Col1 = reader["Col1"].AsDecimal(),
                    Col2 = reader["Col2"].AsDecimal(),
                    Col3 = reader["Col3"].AsDecimal(),
                    Col4 = reader["Col4"].AsDecimal(),
                    Col5 = reader["Col5"].AsDecimal(),
                    Col6 = reader["Col6"].AsDecimal(),
                    Col7 = reader["Col7"].AsDecimal(),
                    Col8 = reader["Col8"].AsDecimal(),
                    Col9 = reader["Col9"].AsDecimal(),
                    Col10 = reader["Col10"].AsDecimal(),
                    Col11 = reader["Col11"].AsDecimal(),
                    Col12 = reader["Col12"].AsDecimal(),
                    Formula = reader["Formula"].AsString(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    CreatedDate = reader["CreatedDate"].AsDateTime(),
                    DayOfDateSystem = reader["DayOfDateSystem"].AsInt(),
                    MonthOfDateSystem = reader["MonthOfDateSystem"].AsInt(),
                    YearOfDateSystem = reader["YearOfDateSystem"].AsInt(),
                    CompanyChiefAccountant = reader["CompanyChiefAccountant"].AsString(),
                    CompanyReportPreparer = reader["CompanyReportPreparer"].AsString(),
                    CompanyDirector = reader["CompanyDirector"].AsString()
                };

            return Db.ReadList(sql, true, makeB04_BCTC, parms);
        }

        /// <summary>
        /// Gets the report b03a BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns></returns>
        public IList<B03a_BCTCEntity> GetReportB03a_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId, int amountType, string currencyCode)
        {
            const string sql = @"[dbo].[uspReport_Get03a_BCTC]";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter", budgetChapterCode,
                "@pSummaryBudgetChapter", isSummaryChapter,
                "@pIsGetFromGLFIRSetting",pIsGetFromGLFIRSetting,
                "@pMasterID",masterId,
                "@AmountType",amountType,
                "@CurrencyCode",currencyCode
            };

            Func<IDataReader, B03a_BCTCEntity> makeB03a_BCTC = reader =>
                new B03a_BCTCEntity
                {
                    MasterId = reader["MasterID"].AsString(),
                    DetailId = reader["DetailID"].AsString(),
                    ColA = reader["ColA"].AsString(),
                    ReportItemAlias = reader["ReportItemAlias"].AsString(),
                    ReportItemName = reader["ReportItemName"].AsString(),
                    ReportItemCode = reader["ReportItemCode"].AsString(),
                    Col1 = reader["Col1"].AsDecimal(),
                    Col2 = reader["Col2"].AsDecimal(),
                    SortOrder = reader["SortOrder"].AsInt(),
                    IsBold = reader["HasBold"].AsBool(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    Formula = reader["Formula"].AsString(),
                    CreatedDate = reader["CreatedDate"].AsDateTime(),
                    DayOfDateSystem = reader["DayOfDateSystem"].AsInt(),
                    MonthOfDateSystem = reader["MonthOfDateSystem"].AsInt(),
                    YearOfDateSystem = reader["YearOfDateSystem"].AsInt(),
                    CompanyChiefAccountant = reader["CompanyChiefAccountant"].AsString(),
                    CompanyReportPreparer = reader["CompanyReportPreparer"].AsString(),
                    CompanyDirector = reader["CompanyDirector"].AsString()


                };

            return Db.ReadList(sql, true, makeB03a_BCTC, parms);
        }

        /// <summary>
        /// Gets the report B03B BCTC.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="pIsGetFromGLFIRSetting">if set to <c>true</c> [p is get from glfir setting].</param>
        /// <param name="masterId">The master identifier.</param>
        /// <returns></returns>
        public IList<B03b_BCTCEntity> GetReportB03b_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, int amountType, string currencyCode)
        {
            const string sql = @"[dbo].[uspReport_GetB03bBCTC]";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapter",budgetChapterCode,
                "@pSummaryBudgetChapter",isSummaryChapter,
                "@pAmountType",amountType,
                "@pCurrencyCode",currencyCode,

            };

            Func<IDataReader, B03b_BCTCEntity> makeB03a_BCTC = reader =>
                new B03b_BCTCEntity
                {
                    ReportItemName = reader["ReportItemName"].AsString(),
                    ReportItemCode = reader["ReportItemCode"].AsString(),
                    ReportItemIndex = reader["ColA"].AsString(),
                    Col1 = reader["Col1"].AsDecimal(),
                    Col2 = reader["Col2"].AsDecimal()
                };

            return Db.ReadList(sql, true, makeB03a_BCTC, parms);
        }
    }
}