/***********************************************************************
 * <copyright file="FinacialReportFacade.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Report
{
    /// <summary>
    /// FinacialReportFacade
    /// </summary>
    public class FinacialReportFacade
    {
        /// <summary>
        /// The finacial report DAO
        /// </summary>
        private static readonly IFinacialReportDao FinacialReportDao = DataAccess.DataAccess.FinacialReportDao;

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
            bool isSummaryChapter, bool isSummarySubKindItem, bool pIsPrintMonth13, bool pIsAddDataMonth13,
            bool pIsPrintAccountDetailByBudgetSource, bool pIsPrintAccountDecided,
            int amountType,
            string currencyCode)
        {
            return FinacialReportDao.GetReportB01H(startDate, fromDate, toDate, budgetSourceId, budgetChapterCode,
                budgetSubKindItem, iAccountGrade, isSummarySource, isSummaryChapter,
                isSummarySubKindItem, pIsPrintMonth13, pIsAddDataMonth13, pIsPrintAccountDetailByBudgetSource,
                pIsPrintAccountDecided, amountType, currencyCode);
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
        public IList<B01_BCTCEntity> GetReportB01_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId, int AmountType, string CurrencyCode)
        {
            return FinacialReportDao.GetReportB01_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter, pIsGetFromGLFIRSetting, masterId,AmountType,CurrencyCode);
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
        /// IList&lt;B02_BCTCEntity&gt;.
        /// </returns>
        public IList<B02_BCTCEntity> GetReportB02_BCTC(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetChapterCode, bool isSummaryChapter, bool pIsGetFromGLFIRSetting, string masterId,int amountType,string currencyCode)
        {
            return FinacialReportDao.GetReportB02_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter, pIsGetFromGLFIRSetting, masterId,amountType,currencyCode);
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
            return FinacialReportDao.GetReportB04_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter, pIsGetFromGLFIRSetting, masterId);
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
            return FinacialReportDao.GetReportB05_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter);
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
            return FinacialReportDao.GetReportB03a_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter, pIsGetFromGLFIRSetting, masterId,amountType,currencyCode);
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
            return FinacialReportDao.GetReportB03b_BCTC(startDate, fromDate, toDate,
                budgetChapterCode, isSummaryChapter, amountType, currencyCode);
        }
    }
}