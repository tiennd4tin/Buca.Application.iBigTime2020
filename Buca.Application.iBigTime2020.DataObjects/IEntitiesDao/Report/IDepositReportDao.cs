
using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Deposit;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report
{
    /// <summary>
    /// Interface IDepositReportDao
    /// </summary>
    public interface IDepositReportDao
    {
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
        IList<S12HEntity> ReportS12H(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
                                             string accountNumber, string bankId, bool summaryBankId, bool isSummaryBudgetChapter, 
                                             bool summaryBudgetSubKindItem,bool IsDetail, int amountType, string currencyCode);

        /// <summary>
        /// Reports the S12 detail.
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
        /// <returns>IList&lt;S12DetailEntity&gt;.</returns>
        IList<S12HDetailEntity> ReportS12Detail(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
                                             string accountNumber, string bankId, bool summaryBankId, bool isSummaryBudgetChapter,
                                             bool summaryBudgetSubKindItem);


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
        IList<S11HEntity> ReportS11H(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
                                           string accountNumber, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem,bool isSummarySource,bool showAccountingObjectInfo,string budgetSourceId,bool IsDetail, bool IsDetailMonth, int amountType, string currencyCode);
        IList<S11HDetailEntity> ReportS11Detail(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
                                            string accountNumber, bool isSummaryBudgetChapter,
                                            bool summaryBudgetSubKindItem);

    }
}
