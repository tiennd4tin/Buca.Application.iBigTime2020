
using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Report
{
    /// <summary>
    /// Class DepositReportFacade.
    /// </summary>
    public class DepositReportFacade
    {
        private static readonly IDepositReportDao DepositReportDao = DataAccess.DataAccess.DepositReportDao;

        /// <summary>
        /// Reports the S12 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="bankId">The bank identifier.</param>
        /// <param name="summaryBankId">if set to <c>true</c> [summary bank identifier].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <returns>IList&lt;S12HEntity&gt;.</returns>
        public IList<S12HEntity> ReportS12H(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
            string accountNumber, string bankId, bool summaryBankId, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem,bool IsDetail, int amountType, string currencyCode)
        {
            return DepositReportDao.ReportS12H(startDate, fromDate, toDate, budgetChapterCode, budgetSubKindItemCode, accountNumber, bankId, summaryBankId,
                isSummaryBudgetChapter, summaryBudgetSubKindItem,IsDetail, amountType, currencyCode);
        }

        /// <summary>
        /// Reports the S12 h detail.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="bankId">The bank identifier.</param>
        /// <param name="summaryBankId">if set to <c>true</c> [summary bank identifier].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <returns>IList&lt;S12HDetailEntity&gt;.</returns>
        public IList<S12HDetailEntity> ReportS12HDetail(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
            string accountNumber, string bankId, bool summaryBankId, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem)
        {
            return DepositReportDao.ReportS12Detail(startDate, fromDate, toDate, budgetChapterCode, budgetSubKindItemCode, accountNumber, bankId, summaryBankId,
                isSummaryBudgetChapter, summaryBudgetSubKindItem);
        }

        /// <summary>
        /// Reports the S11 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <param name="isSummarySource">if set to <c>true</c> [is summary source].</param>
        /// <param name="showAccountingObjectInfo">if set to <c>true</c> [show accounting object information].</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <returns>IList&lt;S11HEntity&gt;.</returns>
        public IList<S11HEntity> ReportS11H(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
                                           string accountNumber, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem, bool isSummarySource, bool showAccountingObjectInfo, string budgetSourceId,bool IsDetail, bool IsDetailMonth, int amountType, string currencyCode)
        {
            return DepositReportDao.ReportS11H(startDate, fromDate, toDate, budgetChapterCode, budgetSubKindItemCode, accountNumber, 
                isSummaryBudgetChapter, summaryBudgetSubKindItem, isSummarySource, showAccountingObjectInfo, budgetSourceId,IsDetail,IsDetailMonth, amountType, currencyCode);

        }
        public IList<S11HDetailEntity> ReportS11HDetail(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
              string accountNumber, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem)
        {
            return DepositReportDao.ReportS11Detail(startDate, fromDate, toDate, budgetChapterCode, budgetSubKindItemCode, accountNumber,
                isSummaryBudgetChapter, summaryBudgetSubKindItem);
        }
    }
}
