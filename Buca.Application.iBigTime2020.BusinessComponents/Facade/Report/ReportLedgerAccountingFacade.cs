/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   
 * Email:   
 * Website:
 * Create Date: 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    24/11/2017     Author       tudt        Description add new funtion
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Ledger;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using System;
using System.Collections.Generic;
using System.Data;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Report
{
    /// <summary>
    /// Class ReportLedgerAccountingFacade.
    /// </summary>
    public class ReportLedgerAccountingFacade
    {
        /// <summary>
        /// The report ledger accounting DAO
        /// </summary>
        private static readonly IReportLedgerAccountingDao ReportLedgerAccountingDao = DataAccess.DataAccess.ReportLedgerAccountingDao;


        public IList<S27Entity> GetReportS27(DateTime fromDate, DateTime toDate, string accountCode,
            string currencyCode, string budgetSourceId, string projectId, int amountType)
        {
            return ReportLedgerAccountingDao.GetReportS27(fromDate, toDate, accountCode, currencyCode, budgetSourceId, projectId, amountType);
        }

        /// <summary>
        /// Gets the report S04 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="addSameEntry">if set to <c>true</c> [add same entry].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <returns>
        /// IList&lt;S04HEntity&gt;.
        /// </returns>
        public IList<S04HEntity> GetReportS04H(DateTime fromDate, DateTime toDate, bool addSameEntry, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
                                          bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem, int amountType, string currencyCode)
        {
            return ReportLedgerAccountingDao.GetReportS04H(fromDate, toDate, addSameEntry, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetSource, isSummaryBudgetChapter, summaryBudgetSubKindItem,amountType,currencyCode);
        }
        /// <summary>
        /// Gets the report S05 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <returns>
        /// IList&lt;S05HEntity&gt;.
        /// </returns>
        public IList<S05HEntity> GetReportS05H(DateTime fromDate, DateTime toDate, string budgetChapterCode, bool isSummaryBudgetChapter, bool amounttype, string currencycode)
        {
            return ReportLedgerAccountingDao.GetReportS05H(fromDate, toDate, budgetChapterCode, isSummaryBudgetChapter,  amounttype,  currencycode);
        }
        /// <summary>
        /// Gets the report S31 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="isSumaryGroupBudgetSource">if set to <c>true</c> [is sumary group budget source].</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSumaryGroupBudgetChapterCode">if set to <c>true</c> [is sumary group budget chapter code].</param>
        /// <param name="isSumaryGroupBudgetSubKindItemCode">if set to <c>true</c> [is sumary group budget sub kind item code].</param>
        /// <returns>
        /// IList&lt;S31HEntity&gt;.
        /// </returns>
        public IList<S31HEntity> GetReportS31H(DateTime startDate, DateTime fromDate, DateTime toDate, string accountNumber, int amountType, string currencyCode, string CorrespondingAccountNumber, string AccountingObjectID, string BudgetSourceID, string FundStructureID, string BudgetChapterCode, string BudgetKindItemCode, string BudgetItemCode, string ProjectID, string ContractID, string BankID, string ActivityId, string CapitalPlanID, bool IsAccountingObjectID, bool IsGroupBudgetSourceID, bool IsGroupFundStructureID, bool IsGroupBudgetChapterCode, bool IsGroupBudgetKindItemCode, bool IsGroupBudgetItemCode, bool IsGroupProjectID, bool IsGroupContractID, bool IsGroupBankID, bool IsGroupActivityId, bool IsGroupCapitalPlanID, bool IsGroupCurrencyCode, bool ISCustomer, bool ISVendor, bool ISEmployee, string CustomerID, string VendorID, string EmployeeID,string FixedAssetId, string InventoryItemId, bool IsGroupFixedAssetId, bool IsGroupInventoryItemId)
        {

            return ReportLedgerAccountingDao.GetReportS31H(startDate, fromDate, toDate, accountNumber, amountType, currencyCode, CorrespondingAccountNumber, AccountingObjectID, BudgetSourceID, FundStructureID, BudgetChapterCode, BudgetKindItemCode, BudgetItemCode, ProjectID, ContractID, BankID, ActivityId, CapitalPlanID, IsAccountingObjectID, IsGroupBudgetSourceID, IsGroupFundStructureID, IsGroupBudgetChapterCode, IsGroupBudgetKindItemCode, IsGroupBudgetItemCode, IsGroupProjectID, IsGroupContractID, IsGroupBankID, IsGroupActivityId, IsGroupCapitalPlanID, IsGroupCurrencyCode, ISCustomer, ISVendor, ISEmployee, CustomerID, VendorID, EmployeeID, FixedAssetId, InventoryItemId, IsGroupFixedAssetId, IsGroupInventoryItemId);
        }

        //public IList<S31HNoAccountingObjectEntity> GetReportS31HNoAccountingObject(DateTime startDate, DateTime fromDate, DateTime toDate, string accountNumber, string budgetSourceId,
        //                        bool isSumaryGroupBudgetSource, string budgetChapterCode, string budgetSubKindItemCode, bool isSumaryGroupBudgetChapterCode, bool isSumaryGroupBudgetSubKindItemCode, int amountType, string currencyCode)
        //{
        //    return ReportLedgerAccountingDao.GetReportS31HNoAccountingObject(startDate, fromDate, toDate, accountNumber,  budgetSourceId, isSumaryGroupBudgetSource, budgetChapterCode,
        //                               budgetSubKindItemCode, isSumaryGroupBudgetChapterCode, isSumaryGroupBudgetSubKindItemCode, amountType, currencyCode);
        //}

        /// <summary>
        /// Gets the report S03 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="addSameEntry">if set to <c>true</c> [add same entry].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <param name="accountnumberlist">The accountnumberlist.</param>
        /// <param name="isPrintMonth13">if set to <c>true</c> [is print month13].</param>
        /// <param name="isPrintAllYearAndMonth13">if set to <c>true</c> [is print all year and month13].</param>
        /// <returns></returns>
        public IList<S03HEntity> GetReportS03H(DateTime startDate, DateTime fromDate, DateTime toDate, bool addSameEntry, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
                                         bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem, string accountnumberlist, bool isPrintMonth13, bool isPrintAllYearAndMonth13, int amountType, string currencyCode, bool isDetail)
        {
            return ReportLedgerAccountingDao.GetReportS03H(startDate, fromDate, toDate, addSameEntry, budgetSourceCode,
                budgetChapterCode, budgetSubKindItemCode,
                isSummaryBudgetSource, isSummaryBudgetChapter, summaryBudgetSubKindItem, accountnumberlist,
                isPrintMonth13, isPrintAllYearAndMonth13,amountType,currencyCode, isDetail);
        }

        /// <summary>
        /// Gets the report S02 ch.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="addSameEntry">if set to <c>true</c> [add same entry].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <param name="accountnumberlist">The accountnumberlist.</param>
        /// <param name="isPrintMonth13">if set to <c>true</c> [is print month13].</param>
        /// <param name="isPrintAllYearAndMonth13">if set to <c>true</c> [is print all year and month13].</param>
        /// <returns></returns>
        public IList<S03HEntity> GetReportS02CH(DateTime startDate, DateTime fromDate, DateTime toDate, bool addSameEntry, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
                                         bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem, string accountnumberlist, bool isPrintMonth13, bool isPrintAllYearAndMonth13, bool IsForeinCurrency, int AmountType, string CurrencyCode)
        {
            return ReportLedgerAccountingDao.GetReportS02CH(startDate, fromDate, toDate, addSameEntry, budgetSourceCode,
                budgetChapterCode, budgetSubKindItemCode,
                isSummaryBudgetSource, isSummaryBudgetChapter, summaryBudgetSubKindItem, accountnumberlist,
                isPrintMonth13, isPrintAllYearAndMonth13, IsForeinCurrency, AmountType, CurrencyCode);
        }


        /// <summary>
        /// Gets the C33 bb.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="accountingObjectList">The accounting object list.</param>
        /// <returns></returns>
        public IList<C33BBEntity> GetC33BB(DateTime fromDate, DateTime toDate, string departmentId,
            string accountingObjectList)
        {
            return ReportLedgerAccountingDao.GetC33BB(fromDate, toDate, departmentId, accountingObjectList);
        }

        /// <summary>
        /// Gets the S34 h.
        /// </summary>
        /// <param name="startdate">The startdate.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountnumber">The accountnumber.</param>
        /// <param name="AccountingObjectList">The accounting object list.</param>
        /// <param name="issumaccount">if set to <c>true</c> [issumaccount].</param>
        /// <param name="groupsameitem">if set to <c>true</c> [groupsameitem].</param>
        /// <returns></returns>
        public IList<S34H_GL_MasterEntity> GetS34H(DateTime startdate, DateTime fromDate, DateTime toDate,
            string accountnumber, string correspondingAccount,
            string AccountingObjectList, string ProjectList, bool issumaccount, bool groupsameitem, bool IsDetail, int amountType, string currencyCode)
        {
            return ReportLedgerAccountingDao.GetS34H( startdate,  fromDate,  toDate,  accountnumber, correspondingAccount,
             AccountingObjectList, ProjectList, issumaccount,  groupsameitem,IsDetail,amountType,currencyCode);
        }

        /// <summary>
        /// Gets the report S13 h.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accounts">The accounts.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="isDetail">if set to <c>true</c> [is detail].</param>
        /// <returns></returns>
        public IList<S13HEntity> GetReportS13H(DateTime startDate, DateTime fromDate, DateTime toDate, string accounts,
                                               string currencyCode, bool isDetail,bool isDetailMonth, string bankAccount)
        {
            return ReportLedgerAccountingDao.GetReportS13H(startDate, fromDate, toDate, accounts, currencyCode, isDetail,isDetailMonth, bankAccount);
        }
        /// <summary>
        /// Gets the report S01 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="addSameEntry">if set to <c>true</c> [add same entry].</param>
        /// <param name="isViewOutAccount">if set to <c>true</c> [is view out account].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <returns></returns>
        public DataTable GetReportS01H(DateTime fromDate, DateTime toDate, bool addSameEntry, bool isViewOutAccount, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
                                         bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem)
        {
            return ReportLedgerAccountingDao.GetReportS01H(fromDate, toDate, addSameEntry, isViewOutAccount, budgetSourceCode, budgetChapterCode, budgetSubKindItemCode, isSummaryBudgetSource, isSummaryBudgetChapter, summaryBudgetSubKindItem);
        }

        /// <summary>
        /// Gets the report S01 h ledger.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="addSameEntry">if set to <c>true</c> [add same entry].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <param name="accountnumberlist">The accountnumberlist.</param>
        /// <param name="isPrintMonth13">if set to <c>true</c> [is print month13].</param>
        /// <param name="isPrintAllYearAndMonth13">if set to <c>true</c> [is print all year and month13].</param>
        /// <returns></returns>
        public IList<S01HLedgerEntity> GetReportS01HLedger(DateTime startDate, DateTime fromDate, DateTime toDate, bool addSameEntry, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
                                        bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem, string accountnumberlist, bool isPrintMonth13, bool isPrintAllYearAndMonth13)
        {
            return ReportLedgerAccountingDao.GetReportS01HLedger(startDate, fromDate, toDate, addSameEntry, budgetSourceCode,
                budgetChapterCode, budgetSubKindItemCode,
                isSummaryBudgetSource, isSummaryBudgetChapter, summaryBudgetSubKindItem, accountnumberlist,
                isPrintMonth13, isPrintAllYearAndMonth13);
        }
    }
}
