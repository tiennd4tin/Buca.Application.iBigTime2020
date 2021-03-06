﻿/***********************************************************************
 * <copyright file="ICashReportDao.cs" company="BUCA JSC">
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
using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report
{
    /// <summary>
    /// Interface ICashReportDao
    /// </summary>
    public interface ICashReportDao
    {
        /// <summary>
        /// Gets the cash in bank confirmation balance sheet.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="BankAccount">The bank account.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <returns>
        /// IList&lt;CashInBankConfirmationBalanceSheetEntity&gt;.
        /// </returns>
        IList<CashInBankConfirmationBalanceSheetEntity> GetCashInBankConfirmationBalanceSheet(DateTime fromDate, DateTime toDate, string BankAccount, string projectId, bool isSummaryProject);

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
        IList<N02_SDKP_DVDT_TT77Entity> GetN02_SDKP_DVDT_TT77(DateTime dbStartdate, DateTime startDate,
            DateTime fromDate, DateTime toDate,
            string pBudgetSourceId, string pBudgetChapterCode, string pBudgetSubKindItemCode, int pMethodDistributeId,
            string pBudgetSourceKind,
            string pBankAccount, bool pSummaryBudgetSource, bool pSummaryBudgetChapter, bool pSummaryBudgetSubKindItem,
            bool pSummaryMethodDistribute, bool pIsAdjustTemplete, bool pIsPrintMonth13, bool pIsPrintAllYearAndMonth13);

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
        IList<N01_SDKP_DVDTEntity> GetN01_SDKP_DVDT(DateTime dbStartdate, DateTime startDate, DateTime fromDate, DateTime toDate, string pBudgetSourceId, string pBudgetChapterCode, string pBudgetSubKindItemCode, int pMethodDistributeId, string pBudgetSourceKind, bool pSummaryBudgetSource, bool pSummaryBudgetChapter, bool pSummaryBudgetSubKindItem, bool pSummaryMethodDistribute, bool pIsAdjustTemplete, bool pIsPrintMonth13, bool pIsPrintAllYearAndMonth13, bool isStateTreasury);
    }
}
