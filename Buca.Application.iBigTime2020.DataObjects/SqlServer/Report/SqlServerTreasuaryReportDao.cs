/***********************************************************************
 * <copyright file="SqlServerTreasuaryReportDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Monday, April 09, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Buca.Application.iBigTime2020.BusinessEntities.Report.TreasuaryReport;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    /// <summary>
    /// Class SqlServerTreasuaryReportDao.
    /// </summary>
    public class SqlServerTreasuaryReportDao : ITreasuaryReportDao
    {
        /// <summary>
        /// Gets the S52 h.
        /// </summary>
        /// <param name="startdate">The startdate.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountnumber">The accountnumber.</param>
        /// <param name="issumaccount">if set to <c>true</c> [issumaccount].</param>
        /// <param name="groupsameitem">if set to <c>true</c> [groupsameitem].</param>
        /// <returns>IList{S52H_GL_MasterEntity}.</returns>
        public IList<S52H_GL_MasterEntity> GetS52H(DateTime startdate, DateTime fromDate, DateTime toDate, string accountnumber, bool issumaccount, bool groupsameitem)
        {
            IList<S52H_GL_MasterEntity> list = new List<S52H_GL_MasterEntity>();
            const string sql = @"uspReport_GetS52H";
            object[] parms =
            {
                "@StartDate",startdate,
                "@FromDate", fromDate,
                "@Todate", toDate,
                "@AccountNumberList",accountnumber,
                "@IsPrintSummaryAccount", issumaccount,
                "@IsSameSummary",groupsameitem,
                };
            var listobj = Db.ReadList(sql, true, makeS52, parms);

            //S34H_GL_Detail_SubDetailEntity GL_Detail_SubDetail = new S34H_GL_Detail_SubDetailEntity();
            IList<GL_Master_DetailEntity> listGl = new List<GL_Master_DetailEntity>();

            foreach (var s52 in listobj)
            {
                if (s52.PartId == 3)
                {
                    IList<GL_Master_DetailEntity> subdetails =
                        GetS52H_GL_Detail(startdate, fromDate, toDate, "," + s52.AccountNumber + ",", false, groupsameitem, s52.MonthYear).ToList();
                    s52.GL_Master_Detail = subdetails;
                }
                else
                {
                    s52.GL_Master_Detail = listGl;
                }
                list.Add(s52);
            }
            return list;

        }
        /// <summary>
        /// Gets the S52 h_ g l_ detail.
        /// </summary>
        /// <param name="startdate">The startdate.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountnumber">The accountnumber.</param>
        /// <param name="issumaccount">if set to <c>true</c> [issumaccount].</param>
        /// <param name="groupsameitem">if set to <c>true</c> [groupsameitem].</param>
        /// <param name="monthyear">The monthyear.</param>
        /// <returns>IList{GL_Master_DetailEntity}.</returns>
        public IList<GL_Master_DetailEntity> GetS52H_GL_Detail(DateTime startdate, DateTime fromDate, DateTime toDate, string accountnumber, bool issumaccount, bool groupsameitem, int monthyear)
        {
            IList<GL_Master_DetailEntity> list = new List<GL_Master_DetailEntity>();
            const string sql = @"uspReport_GetS52H";
            object[] parms =
            {
                 "@StartDate",startdate,
                "@FromDate", fromDate,
                "@Todate", toDate,
                "@AccountNumberList",accountnumber,
                "@IsPrintSummaryAccount", issumaccount,
                "@IsSameSummary",groupsameitem,
                "@monthyear" ,monthyear,
                "@tableType" ,1
                };
            return Db.ReadList(sql, true, makeS52Detail, parms);
        }

        /// <summary>
        /// The make S52
        /// </summary>
        Func<IDataReader, S52H_GL_MasterEntity> makeS52 = reader =>
             new S52H_GL_MasterEntity
             {
                 AccountNumber = reader["AccountNumber"].AsString(),
                 AccountName = reader["AccountName"].AsString(),
                 PartName = reader["PartName"].AsString(),
                 MonthYear = reader["MonthYear"].AsInt(),
                 PartId = reader["PartID"].AsInt(),
                 Amount = reader["Amount"].AsDecimal(),
                 BudgetAmount = reader["BudgetAmount"].AsDecimal(),
                 ReceiptAmount = reader["ReceiptAmount"].AsDecimal(),
                 RevenueAmount = reader["RevenueAmount"].AsDecimal(),
                 SuperiorPaymentAmount = reader["SuperiorPaymentAmount"].AsDecimal(),
                 OtherPaymentAmount = reader["OtherPaymentAmount"].AsDecimal()
             };

        /// <summary>
        /// The make S52 detail
        /// </summary>
        Func<IDataReader, GL_Master_DetailEntity> makeS52Detail = reader =>
            new GL_Master_DetailEntity
            {
                AccountNumber = reader["AccountNumber"].AsString(),
                MonthYear = reader["MonthYear"].AsInt(),
                PartId = reader["PartID"].AsInt(),
                Amount = reader["Amount"].AsDecimal(),
                BudgetAmount = reader["BudgetAmount"].AsDecimal(),
                ReceiptAmount = reader["ReceiptAmount"].AsDecimal(),
                RevenueAmount = reader["RevenueAmount"].AsDecimal(),
                SuperiorPaymentAmount = reader["SuperiorPaymentAmount"].AsDecimal(),
                RefNo = reader["RefNo"].AsString(),
                JournalMemo = reader["JournalMemo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefType = reader["RefType"].AsInt(),
                RefId = reader["RefID"].AsString(),
                DisplayMonth = reader["DisplayMonth"].AsInt(),
                OtherPaymentAmount = reader["OtherPaymentAmount"].AsDecimal()

            };

        /// <summary>
        /// Gets the S101 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">if set to <c>true</c> [is summary account number].</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns>IList{S101HEntity}.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<S101HEntity> GetS101H(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string accountNumber, string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            IList<S101HEntity> s101HEntity = new List<S101HEntity>();
            const string sql = @"uspReport_S101H_Part1";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@AccountNumber",accountNumber,
                "@BudgetSourceCode", budgetSourceId,
                "@BudgetChapterCode",budgetChapterCode,
                "@BudgetSubKindItemCode" ,budgetSubKindItemCode,
                "@ProjectCode" ,projectCode,
                "@BudgetSourceCategoryID" ,budgetCategoryCode,
                "@BudgetItemCode" ,budgetItemCode,
                "@IsSummaryAccountNumber" ,isSummaryAccountNumber,
                "@IsSummaryBudgetSource" ,isSummaryBudgetSource,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@IsSummaryProject" ,isSummaryProject,
                "@IsSummaryBudgetSourceCategory" ,isSummaryBudgetSourceCategory
            };

            //var s101HEntities = Db.ReadList(sql, true, MakeS101H, parms);

            ////S34H_GL_Detail_SubDetailEntity GL_Detail_SubDetail = new S34H_GL_Detail_SubDetailEntity();
            //IList<GL_Master_DetailEntity> listGl = new List<GL_Master_DetailEntity>();

            //foreach (var s101H in s101HEntities)
            //{
            //    if (s101H.PartId == 3)
            //    {
            //        IList<GL_Master_DetailEntity> subdetails =
            //            GetS52H_GL_Detail(startdate, fromDate, toDate, "," + s52.AccountNumber + ",", false, groupsameitem, s52.MonthYear).ToList();
            //        s101H.GL_Master_Detail = subdetails;
            //    }
            //    else
            //    {
            //        s101H.GL_Master_Detail = listGl;
            //    }
            //    s101HEntities.Add(s101H);
            //}
            //return s101HEntities;

            return Db.ReadList(sql, true, MakeS101H, parms);
        }

        /// <summary>
        /// Gets the S101 h part i.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">if set to <c>true</c> [is summary account number].</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns></returns>
        public DataSet GetS101HPartI(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string accountNumber, string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            const string sql = @"uspReport_S101H_Part1_Nov";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@AccountNumber",accountNumber,
                "@BudgetSourceCode", budgetSourceId,
                "@BudgetChapterCode",budgetChapterCode,
                "@BudgetSubKindItemCode" ,budgetSubKindItemCode,
                "@ProjectCode" ,projectCode,
                "@BudgetSourceCategoryID" ,budgetCategoryCode,
                "@BudgetItemCode" ,budgetItemCode,
                "@IsSummaryAccountNumber" ,isSummaryAccountNumber,
                "@IsSummaryBudgetSource" ,isSummaryBudgetSource,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@IsSummaryProject" ,isSummaryProject,
                "@IsSummaryBudgetSourceCategory" ,isSummaryBudgetSourceCategory
            };
            return Db.ReadDataSet(sql, true, parms);

        }

        /// <summary>
        /// Gets the S101 h1.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">if set to <c>true</c> [is summary account number].</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns></returns>
        public DataTable GetS101H1(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string accountNumber, string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            const string sql = @"uspReport_S101H_Part1_Nov3";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@CurrencyCode", currencyCode,
                "@AccountNumber",accountNumber,
                "@BudgetSourceCode", budgetSourceId,
                "@BudgetChapterCode",budgetChapterCode,
                "@BudgetSubKindItemCode" ,budgetSubKindItemCode,
                "@BudgetSourceKind" ,budgetCategoryCode,
                "@ProjectID" ,projectCode,
                "@IsSummaryAccountNumber" ,isSummaryAccountNumber,
                "@IsSummaryBudgetSource" ,isSummaryBudgetSource,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@IsSummaryProject" ,isSummaryProject,
                "@IsSummaryBudgetSourceCategory" ,isSummaryBudgetSourceCategory
            };
            return Db.ReadDataTable(sql, true, parms);

        }

        /// <summary>
        /// The make S101 h
        /// </summary>
        Func<IDataReader, S101HEntity> MakeS101H = reader =>
            new S101HEntity
            {
                EstimateItemName = reader["ItemName"].AsString(),
                ItemCode = reader["ItemCode"].AsString(),
                ItemType = reader["ItemType"].AsInt(),
                OrderNumber = reader["OrderNumber"].AsInt(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                AccountNumber = reader["AccountNumber"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                PostedDate = reader["PostedDate"].AsDateTimeForNull(),
                IsBold = reader["IsBold"].AsBool(),
                ItemId = reader["ItemID"].AsString(),
                ParentId = reader["ParentID"].AsString(),
                BudgetSourceCategoryName = reader["BudgetSourceCategoryName"].AsString()
            };

        /// <summary>
        /// Gets the S101 h part ii.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetSourceKind">Kind of the budget source.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">if set to <c>true</c> [is summary account number].</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns>
        /// IList{S101HPIIEntity}.
        /// </returns>
        public IList<S101HPartIIEntity> GetS101HPartII(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode, string accountNumber, 
           string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, int? budgetSourceKind, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            const string sql = @"uspReport_S101H_Part2_Nov";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@CurrencyCode", currencyCode,
                "@BudgetSourceID", budgetSourceId,
                "@BudgetChapterCode",budgetChapterCode,
                "@BudgetSubKindItemCode" ,budgetSubKindItemCode,
                "@ProjectID" ,projectCode,
                "@BudgetSourceKind" ,budgetSourceKind,
                "@BudgetItemCode" ,budgetItemCode,
                "@IsSummaryAccountNumber" ,isSummaryAccountNumber,
                "@IsSummaryBudgetSource" ,isSummaryBudgetSource,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@IsSummaryProject" ,isSummaryProject,
                "@IsSummaryBudgetSourceCategory" ,isSummaryBudgetSourceCategory
            };

            return Db.ReadList(sql, true, MakeS101HPartII, parms);
        }

        /// <summary>
        /// The make S101 h part ii
        /// </summary>
        Func<IDataReader, S101HPartIIEntity> MakeS101HPartII = reader =>
            new S101HPartIIEntity
            {
                //BudgetSourceCategoryId = reader["BudgetSourceCategoryId"].AsString(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                //AccountNumber = reader["AccountNumber"].AsString(),
                RefNo = reader["RefNo"].AsString(),
                PostedDate = reader["PostedDate"].AsString(),
                //Description = reader["Description"].AsString(),
                //ItemId = reader["ItemID"].AsString(),
                ItemCode = reader["ItemCode"].AsString(),
                ItemName = reader["ItemName"].AsString(),
                GroupCode = reader["ItemCode"].AsString(),
                //ParentId = reader["ParentID"].AsString(),
                ItemType = reader["ItemType"].AsInt(),
                OpeningAmount = reader["OpeningAmount"].AsDecimal(),
                MovementAmount = reader["MovementAmount"].AsDecimal(),
                ClosingAmount = reader["ClosingAmount"].AsDecimal(),
                BalanceAmount = reader["BalanceAmount"].AsDecimal(),
                //OrderNumber = reader["OrderNumber"].AsInt(),
                //IsBold = reader["IsBold"].AsBool(),
                BudgetSourceKind = reader["BudgetSourceKind"].AsInt(),
                BudgetSourceKindName = reader["BudgetSourceKindName"].AsString(),
                ProjectId = reader["ProjectId"].AsString(),
                ProjectCode = reader["ProjectCode"].AsString()
            };


        /// <summary>
        /// Gets the report S104 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="budgetSourceKind">Kind of the budget source.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns></returns>
        public IList<S104HEntity> GetReportS104H(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string budgetCategoryCode, string budgetItemCode, string projectCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            //const string sql = @"GetReportS104H";
            const string sql = @"uspReport_S104H";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@BudgetSource", budgetSourceId,
                "@BudgetChapter",budgetChapterCode,
                "@BudgetSubKindItem" ,budgetSubKindItemCode,
                "@BudgetItem" ,budgetItemCode,
                "@BudgetSourceKind" ,budgetCategoryCode,
                "@ProjectTargetID" ,projectCode,
                "@IsSummaryBudgetSource" ,isSummaryBudgetSource,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@IsSummaryProject" ,isSummaryProject,
                "@IsSummaryBudgetSourceKind" ,isSummaryBudgetSourceCategory,
                //"@HasInThangChinhly", 0,
                //"@HasBaoGomChungTuChinhLy", 0
            };
            return Db.ReadList(sql, true, MakeS104H, parms);
        }

        /// <summary>
        /// The make S104 h
        /// </summary>
        Func<IDataReader, S104HEntity> MakeS104H = reader =>
            new S104HEntity
            {
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetSourceName = reader["BudgetSourceName"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetSubKindItemName = reader["BudgetSubKindItemName"].AsString(),
                BudgetSourceKindName = reader["BudgetSourceKindName"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                ProjectId = reader["ProjectID"].AsString(),
                ProjectCode = reader["ProjectCode"].AsString(),
                ProjectName = reader["ProjectName"].AsString(),
                ItemName = reader["ItemName"].AsString(),
                ItemCode = reader["ItemCode"].AsString(),
                //YearPeriod = reader["YearPeriod"].AsInt(),
                //MonthPeriod = reader["MonthPeriod"].AsInt(),

                Col1=reader["Col1"].AsDecimal(),
                Col2=reader["Col2"].AsDecimal(),
                Col3=reader["Col3"].AsDecimal(),
                Col4=reader["Col4"].AsDecimal(),
                Col5=reader["Col5"].AsDecimal(),
                Col6=reader["Col6"].AsDecimal(),
                Col7=reader["Col7"].AsDecimal(),


                RefId = reader["RefID"].AsString(),
                RefType = reader["RefType"].AsInt(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                Description = reader["Description"].AsString(),
                ReportType = reader["ReportType"].AsInt()
            };

        /// <summary>
        /// Gets the S101 h part ii.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetSourceKind">Kind of the budget source.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">if set to <c>true</c> [is summary account number].</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns>
        /// IList{S101HPIIEntity}.
        /// </returns>
        public IList<S101HPartIIIEntity> GetS101HPartIII(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode, string accountNumber,
           string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, int? budgetSourceKind, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            const string sql = @"uspReport_S101H_Part3_Nov";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@AccountNumber",accountNumber,
                "@CurrencyCode",currencyCode,
                "@BudgetSourceCode", budgetSourceId,
                "@BudgetChapterCode",budgetChapterCode,
                "@BudgetSubKindItemCode" ,budgetSubKindItemCode,
                "@ProjectCode" ,projectCode,
                "@BudgetSourceKind" ,budgetSourceKind,
                "@BudgetItemCode" ,budgetItemCode,
                "@IsSummaryAccountNumber" ,isSummaryAccountNumber,
                "@IsSummaryBudgetSource" ,isSummaryBudgetSource,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@IsSummaryProject" ,isSummaryProject,
                "@IsSummaryBudgetSourceCategory" ,isSummaryBudgetSourceCategory
            };

            return Db.ReadList(sql, true, MakeS101HPartIII, parms);
        }

        /// <summary>
        /// The make S101 h part ii
        /// </summary>
        Func<IDataReader, S101HPartIIIEntity> MakeS101HPartIII = reader =>
            new S101HPartIIIEntity
            {
                //BudgetSourceCategoryId = reader["BudgetSourceCategoryId"].AsString(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                AccountNumber = reader["AccountNumber"].AsString(),
                RefNo = reader["RefNo"].AsString(),
                PostedDate = reader["PostedDate"].AsString(),
                //Description = reader["Description"].AsString(),
                //ItemId = reader["ItemID"].AsString(),
                ItemCode = reader["ItemCode"].AsString(),
                ItemName = reader["ItemName"].AsString(),
                GroupCode = reader["ItemCode"].AsString(),
                //ParentId = reader["ParentID"].AsString(),
                ItemType = reader["ItemType"].AsInt(),
                BudgetAdvanceAmount = reader["BudgetAdvanceAmount"].AsDecimal(),
                BudgetAdvancePaymentAmount = reader["BudgetAdvancePaymentAmount"].AsDecimal(),
                AdvanceBalanceAmount = reader["AdvanceBalanceAmount"].AsDecimal(),
                ActualExpenseAmount = reader["ActualExpenseAmount"].AsDecimal(),
                CashBackAmount = reader["CashBackAmount"].AsDecimal(),
                ActualReceitpAmount = reader["ActualReceitpAmount"].AsDecimal(),
                FinalizationAmount = reader["FinalizationAmount"].AsDecimal(),
                //OrderNumber = reader["OrderNumber"].AsInt(),
                //IsBold = reader["IsBold"].AsBool(),
                BudgetSourceKind = reader["BudgetSourceKind"].AsInt(),
                BudgetSourceKindName = reader["BudgetSourceKindName"].AsString(),
                ProjectId = reader["ProjectId"].AsString(),
                ProjectCode = reader["ProjectCode"].AsString()
            };

        /// <summary>
        /// Gets the S102 h1.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">if set to <c>true</c> [is summary account number].</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns>IList{S102H1Entity}.</returns>
        public IList<S102H1Entity> GetS102H1(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject)
        {
            const string sql = @"uspReport_S102H_Part1";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@CurrencyCode",currencyCode,
                "@BudgetSourceCode", budgetSourceId,
                "@BudgetChapterCode",budgetChapterCode,
                "@BudgetSubKindItemCode" ,budgetSubKindItemCode,
                "@ProjectCode" ,projectCode,
                "@IsSummaryBudgetSource" ,isSummaryBudgetSource,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@IsSummaryProject" ,isSummaryProject
            };
            return Db.ReadList(sql, true, MakeS102H1, parms);
        }
        /// <summary>
        /// The make S101 h
        /// </summary>
        Func<IDataReader, S102H1Entity> MakeS102H1 = reader =>
            new S102H1Entity
            {
                EstimateItemName = reader["ItemName"].AsString(),
                ItemCode = reader["ItemCode"].AsString(),
                ItemType = reader["ItemType"].AsInt(),
                OrderNumber = reader["OrderNumber"].AsInt(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                PostedDate = reader["PostedDate"].AsDateTimeForNull(),
                IsBold = reader["IsBold"].AsBool(),
                ItemId = reader["ItemID"].AsString(),
                ParentId = reader["ParentID"].AsString()
            };
        public IList<S102H2Entity> GetS102H2(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
           string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject)
        {
            const string sql = @"uspReport_S102H_Part2";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@CurrencyCode",currencyCode,
                "@BudgetSourceCode", budgetSourceId,
                "@BudgetChapterCode",budgetChapterCode,
                "@BudgetSubKindItemCode" ,budgetSubKindItemCode,
                "@ProjectCode" ,projectCode,
                "@BudgetItemCode" ,budgetItemCode,
                "@IsSummaryBudgetSource" ,isSummaryBudgetSource,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@IsSummaryProject" ,isSummaryProject,
            };

            return Db.ReadList(sql, true, MakeS102H2, parms);
        }

        /// <summary>
        /// The make S101 h part ii
        /// </summary>
        Func<IDataReader, S102H2Entity> MakeS102H2 = reader =>
            new S102H2Entity
            {
                EstimateItemName = reader["ItemName"].AsString(),
                ItemCode = reader["ItemCode"].AsString(),
                ItemType = reader["ItemType"].AsInt(),
                OrderNumber = reader["OrderNumber"].AsInt(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetAdvanceAmount = reader["BudgetAdvanceAmount"].AsDecimal(),
                BudgetAdvancePaymentAmount = reader["BudgetAdvancePaymentAmount"].AsDecimal(),
                AdvanceBalanceAmount = reader["AdvanceBalanceAmount"].AsDecimal(),
                ActualExpenseAmount = reader["ActualExpenseAmount"].AsDecimal(),
                CashBackAmount = reader["CashBackAmount"].AsDecimal(),
                ActualReceiptAmount = reader["ActualReceitpAmount"].AsDecimal(),
                FinalizationAmount = reader["FinalizationAmount"].AsDecimal(),
                RefNo = reader["RefNo"].AsString(),
                PostedDate = reader["PostedDate"].AsDateTimeForNull(),
                IsBold = reader["IsBold"].AsBool(),
                ItemId = reader["ItemID"].AsString(),
                ParentId = reader["ParentID"].AsString()
            };

        /// <summary>
        /// Gets the S105 h1.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="isSameSummary">if set to <c>true</c> [is same summary].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="budgetExpenseList">The budget expense list.</param>
        /// <returns></returns>
        public IList<S105H1Entity> GetS105H1(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetExpenseList)
        {
            const string sql = @"uspReport_S105H_1";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@IsSameSummary", isSameSummary,
                "@BudgetSourceID", budgetSourceCode,
                "@BudgetChapterCode",budgetChapterCode,
                "@BudgetSubKindItemCode" ,budgetSubKindItemCode,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@ListBudgetExpenseID" ,budgetExpenseList
            };

            return Db.ReadList(sql, true, MakeS105H1, parms);
        }
        /// <summary>
        /// S106H1
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="isSameSummary"></param>
        /// <param name="budgetSourceCode"></param>
        /// <param name="budgetChapterCode"></param>
        /// <param name="budgetSubKindItemCode"></param>
        /// <param name="isSummaryBudgetChapter"></param>
        /// <param name="isSummaryBudgetSubKindItem"></param>
        /// <param name="budgetExpenseList"></param>
        /// <returns></returns>
        public IList<S106H1Entity> GetS106H1(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetExpenseList)
        {
            const string sql = @"uspReport_S106H1";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@IsSameSummary", isSameSummary,
                "@BudgetSourceID", budgetSourceCode,
                "@BudgetChapterCode",budgetChapterCode,
                "@BudgetSubKindItemCode" ,budgetSubKindItemCode,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@ActivityID" ,budgetExpenseList
            };

            return Db.ReadList(sql, true, MakeS106H1, parms);
        }

        /// <summary>
        /// Gets the S105 h2.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="isSameSummary"></param>
        /// <param name="budgetSourceCode"></param>
        /// <param name="budgetChapterCode"></param>
        /// <param name="budgetSubKindItemCode"></param>
        /// <param name="isSummaryBudgetChapter"></param>
        /// <param name="isSummaryBudgetSubKindItem"></param>
        /// <param name="budgetItemCode"></param>
        /// <returns></returns>
        public IList<S105H2Entity> GetS105H2(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetItemCode)
        {
            const string sql = @"uspReport_S105H2";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@IsSameSummary", isSameSummary,
                "@BudgetSourceID", budgetSourceCode,
                "@BudgetChapterCode",budgetChapterCode,
                "@BudgetSubKindItemCode" ,budgetSubKindItemCode,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@BudgetItemCode" ,budgetItemCode
            };

            return Db.ReadList(sql, true, MakeS105H2, parms);
        }
        public IList<S106H2Entity> GetS106H2(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetItemCode)
        {
            const string sql = @"uspReport_S106H_2";
            object[] parms =
            {
                "@StartDate",startDate,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@IsSameSummary", isSameSummary,
                "@BudgetSourceID", budgetSourceCode,
                "@BudgetChapterCode",budgetChapterCode,
                "@BudgetSubKindItemCode" ,budgetSubKindItemCode,
                "@IsSummaryBudgetChapter" ,isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem" ,isSummaryBudgetSubKindItem,
                "@BudgetItemCode" ,budgetItemCode
            };

            return Db.ReadList(sql, true, MakeS106H2, parms);
        }
        /// <summary>
        /// The make S105 h1
        /// </summary>
        Func<IDataReader, S105H1Entity> MakeS105H1 = reader =>
            new S105H1Entity
            {
                PartId = reader["ReportType"].AsInt(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetSourceName = reader["BudgetSourceName"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                RefId = reader["RefId"].AsString(),
                RefDetailId = reader["RefDetailId"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                RefType = reader["RefType"].AsInt(),
                RefNo = reader["RefNo"].AsString(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefDate = reader["RefDate"].AsDateTime(),
                JournalMemo = reader["JournalMemo"].AsString(),
                MonthYear = reader["MonthYear"].AsInt(),
                DisplayMonth = reader["DisplayMonth"].AsInt(),
                DetailType = reader["DetailType"].AsInt(),
                BudgetExpenseName = reader["BudgetExpenseName"].AsString(),
                BudgetExpenseCode = reader["BudgetExpenseCode"].AsString(),
                RegularAmount = reader["RegularAmount"].AsDecimal(),
                NoRegularAmount = reader["NoRegularAmount"].AsDecimal(),
                //OpeningAmount = reader["OpeningAmount"].AsDecimal(),
                //BeginBalance = reader["BeginingBalance"].AsDecimal(),
                //BeginBalance1 = reader["BeginingBalance1"].AsDecimal(),
                //BeginBalance2 = reader["BeginingBalance2"].AsDecimal(),
            };
        /// <summary>
        /// S106H1
        /// </summary>
        Func<IDataReader, S106H1Entity> MakeS106H1 = reader =>
            new S106H1Entity
            {
                PartId = reader["ReportType"].AsInt(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetSourceName = reader["BudgetSourceName"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                RefId = reader["RefId"].AsString(),
                RefDetailId = reader["RefDetailId"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                RefType = reader["RefType"].AsInt(),
                RefNo = reader["RefNo"].AsString(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefDate = reader["RefDate"].AsDateTime(),
                JournalMemo = reader["JournalMemo"].AsString(),
                MonthYear = reader["MonthYear"].AsInt(),
                DisplayMonth = reader["DisplayMonth"].AsInt(),
                DetailType = reader["DetailType"].AsInt(),
                BudgetExpenseName = reader["ActivityName"].AsString(),
                BudgetExpenseCode = reader["ActivityCode"].AsString(),
                RegularAmount = reader["RegularAmount"].AsDecimal(),
                NoRegularAmount = reader["NoRegularAmount"].AsDecimal(),
                OpeningAmount = reader["OpeningAmount"].AsDecimal(),
                BeginBalance = reader["BeginingBalance"].AsDecimal(),
                BeginBalance1 = reader["BeginingBalance1"].AsDecimal(),
                BeginBalance2 = reader["BeginingBalance2"].AsDecimal(),
            };
        /// <summary>
        /// 
        /// </summary>
        Func<IDataReader, S105H2Entity> MakeS105H2 = reader =>
            new S105H2Entity
            {
                RefDetailID = reader["RefDetailID"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetSourceName = reader["BudgetSourceName"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                //LineDetail = reader["LineDetail"].AsString(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                //YearPeriod = reader["YearPeriod"].AsInt(),
                //MonthYear = reader["MonthYear"].AsInt(),
                Name = reader["Description"].AsString(),
                PartID = reader["PartID"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                RefType = reader["RefType"].AsString(),
                RefID = reader["RefID"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                //Amount = reader["Amount"].AsDecimal(),
                //Amount0141xCol1 = reader["Amount0141xCol1"].AsDecimal(),
                Amount0141xCol2 = reader["Amount0141xCol2"].AsDecimal(),
                Amount0141xCol3 = reader["Amount0141xCol3"].AsDecimal(),
                //Amount0142xCol1 = reader["Amount0142xCol1"].AsDecimal(),
                Amount0142xCol2 = reader["Amount0142xCol2"].AsDecimal(),
                Amount0142xCol3 = reader["Amount0142xCol3"].AsDecimal(),
                //BeginingBalance2 = reader["BeginingBalance2"].AsDecimal(),
                //BeginingBalance3 = reader["BeginingBalance3"].AsDecimal(),
                //BeginingBalance5 = reader["BeginingBalance5"].AsDecimal(),
                //BeginingBalance6 = reader["BeginingBalance6"].AsDecimal(),
                //BeginingBalance1 = reader["BeginingBalance1"].AsDecimal(),
                //BeginingBalance4 = reader["BeginingBalance4"].AsDecimal(),
            };
        Func<IDataReader, S106H2Entity> MakeS106H2 = reader =>
            new S106H2Entity
            {
                RefDetailID = reader["RefDetailID"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetSourceName = reader["BudgetSourceName"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                //LineDetail = reader["LineDetail"].AsString(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                //YearPeriod = reader["YearPeriod"].AsInt(),
                //MonthYear = reader["MonthYear"].AsInt(),
                Name = reader["Description"].AsString(),
                PartID = reader["PartID"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                RefType = reader["RefType"].AsString(),
                RefID = reader["RefID"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                //Amount = reader["Amount"].AsDecimal(),
                Amount0181 = reader["Amount0181xCol2"].AsDecimal(),
                //Amount0141xCol2 = reader["Amount0141xCol2"].AsDecimal(),
                //Amount0141xCol3 = reader["Amount0141xCol3"].AsDecimal(),
                Amount0182 = reader["Amount0182xCol2"].AsDecimal(),
                // Amount0142xCol2 = reader["Amount0142xCol2"].AsDecimal(),
                // Amount0142xCol3 = reader["Amount0142xCol3"].AsDecimal(),
                //BeginingBalance2 = reader["BeginingBalance2"].AsDecimal(),
                //BeginingBalance3 = reader["BeginingBalance3"].AsDecimal(),
                //BeginingBalance5 = reader["BeginingBalance5"].AsDecimal(),
                //BeginingBalance6 = reader["BeginingBalance6"].AsDecimal(),
                //BeginingBalance1 = reader["BeginingBalance1"].AsDecimal(),
                //BeginingBalance4 = reader["BeginingBalance4"].AsDecimal(),
            };
    }
}
