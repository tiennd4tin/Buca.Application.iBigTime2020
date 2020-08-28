using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Ledger;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Report
{
    /// <summary>
    /// 
    /// </summary>
    public class GLVoucherListReportFacade
    {
        /// <summary>
        /// The gl voucher list report DAO
        /// </summary>
        private static readonly IGLVoucherListReportDao GlVoucherListReportDao = DataAccess.DataAccess.GLVoucherListReportDao;

        /// <summary>
        /// Reports the gl voucher list detail.
        /// </summary>
        /// <param name="RefId">The reference identifier.</param>
        /// <param name="IsShowSameRow">if set to <c>true</c> [is show same row].</param>
        /// <param name="IsShowOriginalCurrency">if set to <c>true</c> [is show original currency].</param>
        /// <returns></returns>
        public IList<GLVoucherListDetailEntity> ReportGlVoucherListDetail(string RefId,bool IsShowSameRow,bool IsShowOriginalCurrency)
        {
            return GlVoucherListReportDao.ReportGLVoucherListDetail(RefId,IsShowSameRow,IsShowOriginalCurrency);
        }

        /// <summary>
        /// BC chứng từ kế toán
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="refType"></param>
        /// <returns></returns>
        public IList<AccountingVoucherEntity> ReportAccountingVoucher(string refId, int refType)
        {
            return GlVoucherListReportDao.ReportAccountingVoucher(refId, refType);
        }

        /// <summary>
        /// Reports the gl voucher list.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public IList<GLVoucherListEntity> ReportGlVoucherList(DateTime fromDate, DateTime toDate, bool isNotShowSignAccount, int amountType, string currencyCode)
        {
            return GlVoucherListReportDao.ReportGLVoucherList(fromDate, toDate, isNotShowSignAccount, amountType, currencyCode);
        }

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
        public IList<GLVoucherListLedgerEntity> ReportGLVoucherListLedger(DateTime fromDate, DateTime toDate,
            string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, bool isSummarrySource,
            bool isSummaryChapter, bool isSummarySubKindItem, string accountList)
        {
            return GlVoucherListReportDao.ReportGLVoucherListLedger(fromDate, toDate, budgetSourceId, budgetChapterCode,
                budgetSubKindItemCode, isSummarrySource, isSummaryChapter, isSummarySubKindItem, accountList);
        }

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
        public IList<S02CHEntity> ReportS02CH(DateTime fromDate, DateTime toDate, DateTime startDate,
            string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, bool isSummarrySource,
            bool isSummaryChapter, bool isSummarySubKindItem, string accountList)
        {
            return GlVoucherListReportDao.GetReportS02CH(fromDate, toDate, startDate, budgetSourceId, budgetChapterCode,
                budgetSubKindItemCode, isSummarrySource, isSummaryChapter, isSummarySubKindItem, accountList);
        }

        /// <summary>
        /// Reports the S02 ch.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <param name="activityId">The activity identifier.</param>
        /// <param name="isSummaryInventory">if set to <c>true</c> [is summary inventory].</param>
        /// <param name="isSummaryActivity">if set to <c>true</c> [is summary activity].</param>
        /// <returns></returns>
        public IList<S51HEntity> ReportS51H(DateTime fromDate, DateTime toDate, DateTime startDate,
            string inventoryItemId, string activityId, bool isSummaryInventory, bool isSummaryActivity)
        {
            return GlVoucherListReportDao.GetReportS51H(fromDate, toDate, startDate, inventoryItemId, activityId, isSummaryInventory, isSummaryActivity);
        }
    }
}
