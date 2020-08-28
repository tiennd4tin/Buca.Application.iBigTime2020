using Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Ledger;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Report.TreasuaryReport;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Report
{
    /// <summary>
    /// Class TreasuaryReportFacade.
    /// </summary>
    public class TreasuaryReportFacade
    {
        private static readonly ITreasuaryReportDao TreasuaryReportDao = DataAccess.DataAccess.TreasuaryReportDao;
        /// <summary>
        /// Gets the S52 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="isSumAccount">if set to <c>true</c> [is sum account].</param>
        /// <param name="groupSameItem">if set to <c>true</c> [group same item].</param>
        /// <returns>IList&lt;S52H_GL_MasterEntity&gt;.</returns>
        public IList<S52H_GL_MasterEntity> GetS52H(DateTime startDate, DateTime fromDate, DateTime toDate, string accountNumber,
             bool isSumAccount, bool groupSameItem)
        {
            return TreasuaryReportDao.GetS52H(startDate, fromDate, toDate, accountNumber, isSumAccount,
                groupSameItem);
        }

        /// <summary>
        /// Gets the S101 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryAccountNumber">The is summary account number.</param>
        /// <param name="isSummaryBudgetSource">The is summary budget source.</param>
        /// <param name="isSummaryBudgetChapter">The is summary budget chapter.</param>
        /// <param name="isSummaryBudgetSubKindItem">The is summary budget sub kind item.</param>
        /// <param name="isSummaryProject">The is summary project.</param>
        /// <param name="isSummaryBudgetSourceCategory">The is summary budget source category.</param>
        /// <returns>System.Collections.Generic.IList{Buca.Application.iBigTime2020.BusinessEntities.Report.TreasuaryReport.S101HEntity}.</returns>
        public IList<S101HEntity> GetS101H(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string accountNumber, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            return TreasuaryReportDao.GetS101H(startDate, fromDate, toDate, currencyCode, accountNumber, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetCategoryCode, budgetItemCode,
                            isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);
        }

        /// <summary>
        /// Gets the S101 h part i.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
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
            string accountNumber, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            return TreasuaryReportDao.GetS101HPartI(startDate, fromDate, toDate, currencyCode, accountNumber, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetCategoryCode, budgetItemCode,
                            isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);
        }

        /// <summary>
        /// Gets the S101 h1.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
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
            string accountNumber, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetCategoryCode, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            return TreasuaryReportDao.GetS101H1(startDate, fromDate, toDate, currencyCode, accountNumber, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetCategoryCode, budgetItemCode,
                            isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);
        }

        /// <summary>
        /// Gets the S101 h part ii.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
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
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, int? budgetSourceKind, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            return TreasuaryReportDao.GetS101HPartII(startDate, fromDate, toDate, currencyCode, accountNumber, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceKind, budgetItemCode,
                            isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);
        }

        /// <summary>
        /// Gets the report S104 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
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
        public IList<S104HEntity> GetReportS104H(DateTime startDate, DateTime fromDate, DateTime toDate,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string budgetCategoryCode, string budgetItemCode, string projectCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            return TreasuaryReportDao.GetReportS104H(startDate, fromDate, toDate, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, budgetCategoryCode, budgetItemCode, projectCode,
                            isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);
        }

        /// <summary>
        /// Gets the S101 h part iii.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
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
        /// IList{S101HPartIIIEntity}.
        /// </returns>
        public IList<S101HPartIIIEntity> GetS101HPartIII(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode, string accountNumber,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, int? budgetSourceKind, string budgetItemCode,
            bool isSummaryAccountNumber, bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject, bool isSummaryBudgetSourceCategory)
        {
            return TreasuaryReportDao.GetS101HPartIII(startDate, fromDate, toDate, currencyCode, accountNumber, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetSourceKind, budgetItemCode,
                            isSummaryAccountNumber, isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject, isSummaryBudgetSourceCategory);
        }

        /// <summary>
        /// Gets the S102 h1.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <returns>IList{S102H1Entity}.</returns>
        public IList<S102H1Entity> GetS102H1(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject)
        {
            return TreasuaryReportDao.GetS102H1(startDate, fromDate, toDate, currencyCode, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetItemCode,
                            isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject);
        }

        /// <summary>
        /// Gets the S102 h2.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="isSummaryBudgetSubKindItem">if set to <c>true</c> [is summary budget sub kind item].</param>
        /// <param name="isSummaryProject">if set to <c>true</c> [is summary project].</param>
        /// <returns>IList{S102H2Entity}.</returns>
        public IList<S102H2Entity> GetS102H2(DateTime startDate, DateTime fromDate, DateTime toDate, string currencyCode,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode, string projectCode, string budgetItemCode,
            bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, bool isSummaryProject)
        {
            return TreasuaryReportDao.GetS102H2(startDate, fromDate, toDate, currencyCode, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, projectCode, budgetItemCode,
                            isSummaryBudgetSource, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, isSummaryProject);
        }

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
            return TreasuaryReportDao.GetS105H1(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, budgetExpenseList);
        }

        /// <summary>
        /// 
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
            return TreasuaryReportDao.GetS105H2(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, budgetItemCode);
        }

        public IList<S106H2Entity> GetS106H2(DateTime startDate, DateTime fromDate, DateTime toDate, bool isSameSummary,
            string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
            bool isSummaryBudgetChapter, bool isSummaryBudgetSubKindItem, string budgetItemCode)
        {
            return TreasuaryReportDao.GetS106H2(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, budgetItemCode);
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
            return TreasuaryReportDao.GetS106H1(startDate, fromDate, toDate, isSameSummary, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetChapter, isSummaryBudgetSubKindItem, budgetExpenseList);
        }
    }
}
