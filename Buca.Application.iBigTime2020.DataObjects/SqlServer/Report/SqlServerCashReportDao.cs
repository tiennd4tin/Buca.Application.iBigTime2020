/***********************************************************************
 * <copyright file="SqlServerCashReportDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, November 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, November 30, 2017Author SonTV  Description 
 * Date Tuesday, August 28, 2018        Author        Tudt       Description: Fomat code
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Report.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    /// <summary>
    /// Class SqlServerCashReportDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report.ICashReportDao" />
    public class SqlServerCashReportDao : ICashReportDao
    {
        /// <summary>
        /// Gets the cash in bank confirmation balance sheet.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="bankAccount">The bank account.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <returns>
        /// IList&lt;CashInBankConfirmationBalanceSheetEntity&gt;.
        /// </returns>
        public IList<CashInBankConfirmationBalanceSheetEntity> GetCashInBankConfirmationBalanceSheet(DateTime fromDate, DateTime toDate, string bankAccount, string projectId, bool isSummaryProject)
        {
            const string sql = @"uspReport_CashInBankConfirmationBalanceSheet";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@BankAccount",bankAccount,
                "@pProjectID",projectId,
                "@pIsSummaryProject",isSummaryProject
            };

            Func<IDataReader, CashInBankConfirmationBalanceSheetEntity> makeCashInBankConfirmationBalanceSheet = reader =>
                new CashInBankConfirmationBalanceSheetEntity
                {
                    ProjectCode = reader["ProjectCode"].AsString(),
                    ProjectId = reader["ProjectID"].AsString(),
                    BankAccount = reader["BankAccount"].AsString(),
                    BankDistributionCode = reader["BankDistributionCode"].AsString(),
                    ClosingBalance = reader["ClosingBalance"].AsDecimal(),
                    ClosingBalance112 = reader["ClosingBalance112"].AsDecimal(),
                    MovementCredit112 = reader["MovementCredit112"].AsDecimal(),
                    MovementCreditAmount = reader["MovementCreditAmount"].AsDecimal(),
                    MovementDebitAmount = reader["MovementDebitAmount"].AsDecimal(),
                    OpeningBalance = reader["OpeningBalance"].AsDecimal(),
                    MovementDebit112 = reader["MovementDebit112"].AsDecimal(),
                    OpenningBalance112 = reader["OpenningBalance112"].AsDecimal(),

                };

            return Db.ReadList(sql, true, makeCashInBankConfirmationBalanceSheet, parms);
        }

        /// <summary>
        /// Gets the N02 SDKP DVDT t T77.
        /// </summary>
        /// <param name="dbStartdate">The database startdate.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="pBudgetSourceId">The p budget source identifier.</param>
        /// <param name="pBudgetChapterCode">The p budget chapter code.</param>
        /// <param name="pBudgetSubKindItemCode">The p budget sub kind item code.</param>
        /// <param name="pMethodDistributeId">The p method distribute identifier.</param>
        /// <param name="pBudgetSourceKind">Kind of the p budget source.</param>
        /// <param name="pBankAccount">The p bank account.</param>
        /// <param name="pSummaryBudgetSource">if set to <c>true</c> [p summary budget source].</param>
        /// <param name="pSummaryBudgetChapter">if set to <c>true</c> [p summary budget chapter].</param>
        /// <param name="pSummaryBudgetSubKindItem">if set to <c>true</c> [p summary budget sub kind item].</param>
        /// <param name="pSummaryMethodDistribute">if set to <c>true</c> [p summary method distribute].</param>
        /// <param name="pIsAdjustTemplete">if set to <c>true</c> [p is adjust templete].</param>
        /// <param name="pIsPrintMonth13">if set to <c>true</c> [p is print month13].</param>
        /// <param name="pIsPrintAllYearAndMonth13">if set to <c>true</c> [p is print all year and month13].</param>
        /// <returns></returns>
        public IList<N02_SDKP_DVDT_TT77Entity> GetN02_SDKP_DVDT_TT77(DateTime dbStartdate, DateTime startDate, DateTime fromDate, DateTime toDate,
                string pBudgetSourceId, string pBudgetChapterCode, string pBudgetSubKindItemCode, int pMethodDistributeId, string pBudgetSourceKind,
                string pBankAccount, bool pSummaryBudgetSource, bool pSummaryBudgetChapter, bool pSummaryBudgetSubKindItem, bool pSummaryMethodDistribute, bool pIsAdjustTemplete, bool pIsPrintMonth13, bool pIsPrintAllYearAndMonth13)
        {
            //const string sql = @"uspReport_N02_SDKP_DVDT_TT77";
            const string sql = @"uspReport_N02_SDKP_DVDT_2019";
            object[] parms =
            {
                        "@DBStartDate", dbStartdate,
                        "@StartDate", startDate,
                        "@FromDate",fromDate,
                        "@ToDate",toDate,
                        "@BudgetSourceID",pBudgetSourceId,
                        "@BudgetChapterCode",pBudgetChapterCode,
                        "@BudgetSubKindItemCode",pBudgetSubKindItemCode,
                        "@MethodDistributeID",pMethodDistributeId,
                        "@SummaryBudgetSource",pSummaryBudgetSource,
                        "@SummaryBudgetChapter",pSummaryBudgetChapter,
                        "@SummaryBudgetSubKindItem",pSummaryBudgetSubKindItem,
                        "@SummaryMethodDistribute",pSummaryMethodDistribute,
                        "@IsAdjustTemplete",pIsAdjustTemplete,
                        "@IsPrintMonth13",pIsPrintMonth13,
                        "@IsPrintAllYearAndMonth13",pIsPrintAllYearAndMonth13
                    };

            Func <IDataReader, N02_SDKP_DVDT_TT77Entity> MakeN02_SDKP_DVDT = reader =>
                new N02_SDKP_DVDT_TT77Entity
                {
                    //IsPrintMonth13 = reader["IsPrintMonth13"].AsBool(),
                    //BudgetChapterName = reader["BudgetChapterCodeName"].AsString(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    //BudgetChapterName = reader["BudgetChapterCodeName"].AsString(),
                    MethodDistributeId = reader["MethodDistributeID"].AsString(),
                    // MethodDistributeIdName = reader["MethodDistributeIDName"].AsString(),
                    BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                    BudgetSourceCodeName = reader["BudgetSourceName"].AsString(),
                    //  BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    //BudgetKindItemCodeName = reader["BudgetKindItemCodeName"].AsString(),
                    BudgetSubKindItemCodeName = reader["BudgetKindItemName"].AsString(),
                    BudgetItemCode = reader["BudgetItemCode"].AsString(),
                    BudgetItemCodeName = reader["BudgetItemName"].AsString(),
                    BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                    BudgetSubItemCodeName = reader["BudgetSubItemName"].AsString(),
                    ProjectCode = reader["ProjectCode"].AsString(),
                    //ProjectCodeName = reader["ProjectCodeName"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    ProjectCodeName = reader["ProjectCode"].AsString(),
                    Col1 = reader["Col1"].AsDecimal(),
                    Col2 = reader["Col2"].AsDecimal(),
                    Col3 = reader["Col3"].AsDecimal(),
                    Col4 = reader["Col4"].AsDecimal(),
                    Col5 = reader["Col5"].AsDecimal(),
                    Col6 = reader["Col6"].AsDecimal(),
                    ItemType = reader["ItemType"].AsInt(),
                    Part = reader["Part"].AsInt()
                };

            return Db.ReadList(sql, true, MakeN02_SDKP_DVDT, parms);
        }

        /// <summary>
        /// Gets the N01 SDKP DVDT.
        /// </summary>
        /// <param name="dbStartdate">The database startdate.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="pBudgetSourceId">The p budget source identifier.</param>
        /// <param name="pBudgetChapterCode">The p budget chapter code.</param>
        /// <param name="pBudgetSubKindItemCode">The p budget sub kind item code.</param>
        /// <param name="pMethodDistributeId">The p method distribute identifier.</param>
        /// <param name="pBudgetSourceKind">Kind of the p budget source.</param>
        /// <param name="pSummaryBudgetSource">if set to <c>true</c> [p summary budget source].</param>
        /// <param name="pSummaryBudgetChapter">if set to <c>true</c> [p summary budget chapter].</param>
        /// <param name="pSummaryBudgetSubKindItem">if set to <c>true</c> [p summary budget sub kind item].</param>
        /// <param name="pSummaryMethodDistribute">if set to <c>true</c> [p summary method distribute].</param>
        /// <param name="pIsAdjustTemplete">if set to <c>true</c> [p is adjust templete].</param>
        /// <param name="pIsPrintMonth13">if set to <c>true</c> [p is print month13].</param>
        /// <param name="pIsPrintAllYearAndMonth13">if set to <c>true</c> [p is print all year and month13].</param>
        /// <param name="isStateTreasury">if set to <c>true</c> [is state treasury].</param>
        /// <returns></returns>
        public IList<N01_SDKP_DVDTEntity> GetN01_SDKP_DVDT(DateTime dbStartdate, DateTime startDate, DateTime fromDate, DateTime toDate,
              string pBudgetSourceId, string pBudgetChapterCode, string pBudgetSubKindItemCode, int pMethodDistributeId, string pBudgetSourceKind,
              bool pSummaryBudgetSource, bool pSummaryBudgetChapter, bool pSummaryBudgetSubKindItem, bool pSummaryMethodDistribute, bool pIsAdjustTemplete, bool pIsPrintMonth13, bool pIsPrintAllYearAndMonth13, bool isStateTreasury)
        {
            //const string sql = @"uspReport_N01_SDKP_DVDT";
            const string sql = @"uspReport_N01_SDKP_DVDT_2019";
            object[] parms =
                    {
                        "@DBStartDate", dbStartdate,
                        "@StartDate", startDate,
                        "@FromDate",fromDate,
                        "@ToDate",toDate,
                        "@BudgetSourceID",pBudgetSourceId,
                        "@BudgetChapterCode",pBudgetChapterCode,
                        "@BudgetSubKindItemCode",pBudgetSubKindItemCode,
                        //"@pMethodDistributeID",pMethodDistributeId,
                        //"@pBudgetSourceKind",-1,
                        //"@pSummaryBudgetSource",pSummaryBudgetSource,
                        "@SummaryBudgetChapter",pSummaryBudgetChapter,
                        "@SummaryBudgetSource",pSummaryBudgetSource,
                        "@SummaryBudgetSubKindItem",pSummaryBudgetSubKindItem,
                        //"@pSummaryMethodDistribute",pSummaryMethodDistribute,
                        "@IsAdjustTemplete",pIsAdjustTemplete,
                        "@IsPrintMonth13",pIsPrintMonth13,
                        "@IsPrintAllYearAndMonth13",pIsPrintAllYearAndMonth13,
                        "@IsStateTreasury", isStateTreasury
                    };

            Func<IDataReader, N01_SDKP_DVDTEntity> MakeN01_SDKP_DVDT = reader =>
                new N01_SDKP_DVDTEntity
                {
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetSourceId = reader["BudgetSourceID"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    ProjectId = reader["ProjectID"].AsString(),
                    DebitAmount = reader["DebitAmount"].AsDecimal(),
                    CreditAmount = reader["CreditAmount"].AsDecimal(),
                    MovementDebitAmount = reader["MovementDebitAmount"].AsDecimal(),
                    SumDebit = reader["SumDebit"].AsDecimal(),
                    SumCredit = reader["SumCredit"].AsDecimal(),
                    EarlySumDebit = reader["EarlySumDebit"].AsDecimal(),
                    Commitment = reader["Commitment"].AsDecimal(),
                    SumCommitment = reader["SumCommitment"].AsDecimal(),
                    Reserved = reader["Reserved"].AsDecimal(),
                    UseableAmount = reader["UseableAmount"].AsDecimal(),
                    RemainingAmount = reader["RemainingAmount"].AsDecimal(),
                    ItemType = reader["ItemType"].AsInt(),
                    Part = reader["Part"].AsInt()
                };

            return Db.ReadList(sql, true, MakeN01_SDKP_DVDT, parms);
        }
    }
}
