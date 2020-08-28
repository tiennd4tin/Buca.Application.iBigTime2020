/***********************************************************************
 * <copyright file="ISettlementReportDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Wednesday, May 23, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Report.SettlementReport;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report
{
    /// <summary>
    /// Interface ISettlementReportDao
    /// </summary>
    public interface ISettlementReportDao
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
        IList<B02BCQTEntity> GetReportB02BCQT(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode,
            bool isSummaryChapter, bool isPrintMonth13, bool isAddDataMonth13);

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
        IList<B03BCQTEntity> GetReportB03BCQT(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode,
            bool isSummaryChapter, bool isPrintMonth13, bool isAddDataMonth13);

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
        IList<F0101BCQTEntity> GetReportF01001BCQT(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, int amountType, string CurrencyCode);

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
        DataSet GetReportB01BCQT(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, int amountType, string currencyCode);
        DataSet GetReportF0102BCQT(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItem, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string listprojectID, int methodDistribute, bool isMethodDistribute, bool isProject);

        #region Nhóm báo cáo xuất XML Báo cáo tài chính
        /// <summary>
        /// B01/BCQT: Báo cáo quyết toán kinh phí hoạt động, xuất xml
        /// </summary>
        DataSet GetReportB01BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName, bool isSummaryXKKD);

        /// <summary>
        /// Thuyết minh báo cáo quyết toán
        /// </summary>
        DataSet GetReportB03BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// Báo cáo tình hình tài chính
        /// </summary>
        DataSet GetReportBCTC01_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName, string budgetChapterCode, bool isSummaryBudgetChapter);

        /// <summary>
        /// Báo cáo kết quả hoạt động
        /// </summary>
        DataSet GetReportBCTC02_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// B04/BCTC: Thuyết minh báo cáo tài chính
        /// </summary>
        DataSet GetReportBCTC04_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);


        /// <summary>
        /// B03bBCTC: Báo cáo lưu chuyển tiền tệ gián tiếp
        /// </summary>
        DataSet GetReportB03bBCTC_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// B05/BCTC: Báo cáo tài chính mẫu đơn giản
        /// </summary>
        DataSet GetReportBCTC05_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// F01/01 BCQT: Báo cáo chi tiết nguồn NSNN khấu trừ để lại
        /// </summary>
        DataSet GetReportF0101BCQT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// Phụ biểu F01-02/BCQT - Phần 1: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
        /// </summary>
        DataSet GetReportF0102BCQTP1_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// Phụ biểu F01-02/BCQT - Phần 2: Báo cáo chi tiết theo chương, nguồn, loại, khoản, cấp phát, chương trình mục tiêu, dự án
        /// </summary>
        DataSet GetReportF0102BCQTP2_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);

        /// <summary>
        /// B01/BSTT: Báo cáo bổ sung thông tin tài chính
        /// </summary>
        DataSet GetReportB01BSTT_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);
        #endregion

        #region Nhóm xuất khẩu BC gửi kho bạc nhà nước

        /// <summary>
        /// B01/BCTC
        /// </summary>
        DataSet GetSumReportB01BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// B02/BCTC
        /// </summary>
        DataSet GetSumReportB02BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// B03a/BCTC
        /// </summary>
        DataSet GetSumReportB03aBCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// B03b/BCTC
        /// </summary>
        DataSet GetSumReportB03bBCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// B04/BCTC
        /// </summary>
        DataSet GetSumReportB04BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        /// <summary>
        /// B01BSTT
        /// </summary>
        DataSet GetSumReportB01BSTT_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate);

        #endregion

        /// <summary>
        /// S05H: Bảng cân đối số phát sinh
        /// </summary>
        DataSet GetReportS05H_XmlBCTC(DateTime startDate, DateTime fromDate, DateTime toDate, string procedureName);
    }
}
