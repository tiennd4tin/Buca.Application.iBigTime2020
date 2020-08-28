/***********************************************************************
 * <copyright file="ISqlServerTreasuaryReportDao.cs" company="BUCA JSC">
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
using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Report.TreasuaryReport;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report
{
    /// <summary>
    /// Interface ISqlServerTreasuaryReportDao
    /// </summary>
    public interface ITreasuaryReportDao
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
        IList<S52H_GL_MasterEntity> GetS52H(DateTime startdate, DateTime fromDate, DateTime toDate, string accountnumber,
             bool issumaccount, bool groupsameitem);

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
        IList<S101HEntity> GetS101H(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string accountNumber, string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory);

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
        DataSet GetS101HPartI(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string accountNumber, string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory);

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
        DataTable GetS101H1(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string accountNumber, string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory);

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
        IList<S101HPartIIEntity> GetS101HPartII(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode, string accountNumber, 
           string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, int? budgetSourceKind, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject,
            bool isSummaryBudgetSourceCategory);

        /// <summary>
        /// Gets the report S104 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <param name="isSummaryBudgetSourceCategory">if set to <c>true</c> [is summary budget source category].</param>
        /// <returns></returns>
        IList<S104HEntity> GetReportS104H(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string budgetCategoryCode, string budgetItemCode, string projectCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory);

        /// <summary>
        /// Gets the S101 h part iii.
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
        /// IList{S101HPartIIEntity}.
        /// </returns>
        IList<S101HPartIIIEntity> GetS101HPartIII(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode, string accountNumber,
           string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, int? budgetSourceKind, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory);

        /// <summary>
        /// Gets the S102 h1.
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
        /// <returns>IList{S102H1Entity}.</returns>
        IList<S102H1Entity> GetS102H1(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject);

        /// <summary>
        /// Gets the S102 h2.
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
        /// <returns>IList{S102H2Entity}.</returns>
        IList<S102H2Entity> GetS102H2(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
           string budgetSourceId, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject);

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
        IList<S105H1Entity> GetS105H1(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetExpenseList);

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
        IList<S105H2Entity> GetS105H2(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetItemCode);

        /// <summary>
        /// S106H2
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
        IList<S106H2Entity> GetS106H2(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetItemCode);
        /// <summary>
        /// Get S106H1
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
        IList<S106H1Entity> GetS106H1(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetExpenseList);
    }
}
