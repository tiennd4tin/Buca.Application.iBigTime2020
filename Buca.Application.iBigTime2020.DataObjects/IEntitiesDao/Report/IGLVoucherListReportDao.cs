using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Ledger;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report
{
    /// <summary>
    /// IGLVoucherListReportDao
    /// </summary>
    public interface IGLVoucherListReportDao
    {
        /// <summary>
        /// Reports the gl voucher list detail.
        /// </summary>
        /// <param name="RefId">The reference identifier.</param>
        /// <param name="IsShowSameRow">if set to <c>true</c> [is show same row].</param>
        /// <param name="IsShowOriginalCurrency">if set to <c>true</c> [is show original currency].</param>
        /// <returns></returns>
        IList<GLVoucherListDetailEntity> ReportGLVoucherListDetail(string RefId, bool IsShowSameRow, bool IsShowOriginalCurrency);

        /// <summary>
        /// BC chứng từ kế toán
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="refType"></param>
        /// <returns></returns>
        IList<AccountingVoucherEntity> ReportAccountingVoucher(string refId, int refType);

        /// <summary>
        /// Reports the gl voucher list.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        IList<GLVoucherListEntity> ReportGLVoucherList(DateTime fromDate, DateTime toDate, bool isNotShowSignAccount, int amountType, string currencyCode);

        /// <summary>
        /// Reports the gl voucher list ledger.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummarrySource">if set to <c>true</c> [is summarry source].</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="isSummarySubKindItem">if set to <c>true</c> [is summary sub kind item].</param>
        /// <param name="accountList">The account list.</param>
        /// <returns></returns>
        IList<GLVoucherListLedgerEntity> ReportGLVoucherListLedger(DateTime fromDate, DateTime toDate, string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, bool isSummarrySource, bool isSummaryChapter, bool isSummarySubKindItem, string accountList);

        /// <summary>
        /// Reports the S02 ch.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummarrySource">if set to <c>true</c> [is summarry source].</param>
        /// <param name="isSummaryChapter">if set to <c>true</c> [is summary chapter].</param>
        /// <param name="isSummarySubKindItem">if set to <c>true</c> [is summary sub kind item].</param>
        /// <param name="accountList">The account list.</param>
        /// <returns></returns>
        IList<S02CHEntity> GetReportS02CH(DateTime fromDate, DateTime toDate, DateTime startDate, string budgetSourceId,
            string budgetChapterCode, string budgetSubKindItemCode, bool isSummarrySource, bool isSummaryChapter,
            bool isSummarySubKindItem, string accountList);

        /// <summary>
        /// Gets the report S51 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="isSummaryInventory">if set to <c>true</c> [is summary inventory].</param>
        /// <param name="isSummaryActivity">if set to <c>true</c> [is summary activity].</param>
        /// <returns></returns>
        IList<S51HEntity> GetReportS51H(DateTime fromDate, DateTime toDate, DateTime startDate,
        string inventoryItemId, string activityId, bool isSummaryInventory, bool isSummaryActivity);

    }

}
