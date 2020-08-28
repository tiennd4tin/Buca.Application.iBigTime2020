using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Deposit;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    public class SqlServerDepositReportDao : IDepositReportDao
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
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<S12HEntity> ReportS12H(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, string budgetSubKindItemCode,
            string accountNumber, string bankId, bool summaryBankId, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem,bool IsDetail, int amountType, string currencyCode)
        {
            const string sql = @"uspReport_S12H";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapterCode", budgetChapterCode,
                "@pBudgetSubKindItemCode", budgetSubKindItemCode,
                "@pAccountNumber", accountNumber,
                "@pBankID", bankId,
                "@SummaryBankID", summaryBankId,
                "@IsSummaryBudgetChapter", isSummaryBudgetChapter,
                "@pSummaryBudgetSubKindItem", summaryBudgetSubKindItem,
                "@pIsDetail",IsDetail,
                "@AmountType", amountType,
                "@CurrencyCode", currencyCode
            };

            Func<IDataReader, S12HEntity> makeS12H = reader =>
                new S12HEntity
                {
                    StartOfMonth = reader["StartOfMonth"].AsDateTime(),
                    StartOfQuater = reader["StartOfQuater"].AsDateTime(),
                    OrderType = reader["OrderType"].AsInt(),
                    RefType = reader["RefType"].AsInt(),
                    RefId = reader["RefId"].AsString(),
                    RefNo = reader["RefNo"].AsString(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    SortOrder = reader["SortOrder"].AsString(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    BankId = reader["BankId"].AsString(),
                    BankAccount = reader["BankAccount"].AsString(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    AccountNumber = reader["AccountNumber"].AsString(),
                    AccCot2 = reader["AccCot2"].AsDecimal(),
                    AccCot3 = reader["AccCot3"].AsDecimal(),
                    AccountName = reader["AccountName"].AsString(),
                    AccountingObjectName = reader["AccountingObjectName"].AsString(),
                    BankName = reader["BankName"].AsString(),
                    BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                    BudgetSourceName = reader["BudgetSourceName"].AsString(),
                    Cot1 = reader["Cot1"].AsDecimal(),
                    Cot2 = reader["Cot2"].AsDecimal(),
                    Cot3 = reader["Cot3"].AsDecimal(),
                    QuyCot2 = reader["QuyCot2"].AsDecimal(),
                    QuyCot3 = reader["QuyCot3"].AsDecimal(),
                    IsOneBudgetChapterCode = reader["IsOneBudgetChapterCode"].AsInt(),
                    IsOneBudgetSourceCode = reader["IsOneBudgetSourceCode"].AsInt(),
                    IsOneBudgetSubKindItemCode = reader["IsOneBudgetSubKindItemCode"].AsInt()
                };

            return Db.ReadList(sql, true, makeS12H, parms);
        }

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
        public IList<S12HDetailEntity> ReportS12Detail(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode, 
            string budgetSubKindItemCode, string accountNumber, string bankId, bool summaryBankId, bool isSummaryBudgetChapter, 
            bool summaryBudgetSubKindItem)
        {
            const string sql = @"uspReport_S12HDetail";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapterCode", budgetChapterCode,
                "@pBudgetSubKindItemCode", budgetSubKindItemCode,
                "@pAccountNumber", accountNumber,
                "@pBankID", bankId,
                "@SummaryBankAccount", summaryBankId,
                "@IsSummaryBudgetChapter", isSummaryBudgetChapter,
                "@pSummaryBudgetSubKindItem", summaryBudgetSubKindItem
            };

            Func<IDataReader, S12HDetailEntity> makeS12HDetail = reader =>
                new S12HDetailEntity
                {
                    StartOfMonth = reader["StartOfMonth"].AsDateTime(),
                    StartOfQuater = reader["StartOfQuater"].AsDateTime(),
                    OrderType = reader["OrderType"].AsInt(),
                    RefType = reader["RefType"].AsInt(),
                    RefId = reader["RefId"].AsString(),
                    RefNo = reader["RefNo"].AsString(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    SortOrder = reader["SortOrder"].AsString(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    BankId = reader["BankId"].AsString(),
                    BankAccount = reader["BankAccount"].AsString(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    AccountNumber = reader["AccountNumber"].AsString(),
                    AccCot2 = reader["AccCot2"].AsDecimal(),
                    AccCot3 = reader["AccCot3"].AsDecimal(),
                    AccountName = reader["AccountName"].AsString(),
                    AccountingObjectName = reader["AccountingObjectName"].AsString(),
                    BankName = reader["BankName"].AsString(),
                    BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                    BudgetSourceName = reader["BudgetSourceName"].AsString(),
                    Cot1 = reader["Cot1"].AsDecimal(),
                    Cot2 = reader["Cot2"].AsDecimal(),
                    Cot3 = reader["Cot3"].AsDecimal(),
                    QuyCot2 = reader["QuyCot2"].AsDecimal(),
                    QuyCot3 = reader["QuyCot3"].AsDecimal(),
                    IsOneBudgetChapterCode = reader["IsOneBudgetChapterCode"].AsInt(),
                    IsOneBudgetSourceCode = reader["IsOneBudgetSourceCode"].AsInt(),
                    IsOneBudgetSubKindItemCode = reader["IsOneBudgetSubKindItemCode"].AsInt(),
                    CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString()
                };

            return Db.ReadList(sql, true, makeS12HDetail, parms);
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
                                           string accountNumber, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem, bool isSummarySource, bool showAccountingObjectInfo, string budgetSourceId,bool IsDetail,bool IsDetailMonth,int amountType, string currencyCode)
        {
            const string sql = @"uspReport_S11H";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapterCode", budgetChapterCode,
                "@pBudgetSubKindItemCode", budgetSubKindItemCode,
                "@pAccountNumber", accountNumber,
                "@IsSummaryBudgetChapter", isSummaryBudgetChapter,
                "@pSummaryBudgetSubKindItem", summaryBudgetSubKindItem,
                "@pIsSummarySource",isSummarySource,
                "@ShowAccountingObjectInfo",showAccountingObjectInfo,
                "@pBudgetSourceID",budgetSourceId,
                "@IsSummaryFund",0,
                "@FundID",null, 
                "@pIsDetail",IsDetail,
                "@pIsDetailMonth",IsDetailMonth,
                "@AmountType", amountType,
                "@CurrencyCode", currencyCode

            };

            Func<IDataReader, S11HEntity> makeS11H = reader =>
                new S11HEntity
                {
                    StartOfMonth = reader["StartOfMONTH"].AsDateTime(),
                    OrderType = reader["OrderType"].AsInt(),
                    RefType = reader["RefType"].AsInt(),
                    RefId = reader["RefId"].AsString(),
                    RefNo = reader["RefNo"].AsString(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    SortOrder = reader["SortOrder"].AsString(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    AccountNumber = reader["AccountNumber"].AsString(),
                    AccCot2 = reader["AccCot2"].AsDecimal(),
                    AccCot3 = reader["AccCot3"].AsDecimal(),
                    AccountName = reader["AccountName"].AsString(),
                    AccountingObjectName = reader["AccountingObjectName"].AsString(),
                    BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                    BudgetSourceName = reader["BudgetSourceName"].AsString(),
                    Cot1 = reader["Cot1"].AsDecimal(),
                    Cot2 = reader["Cot2"].AsDecimal(),
                    Cot3 = reader["Cot3"].AsDecimal(),
                    QuyCot2 = reader["QuyCot2"].AsDecimal(),
                    QuyCot3 = reader["QuyCot3"].AsDecimal()
                };

            return Db.ReadList(sql, true, makeS11H, parms);
        }



        public IList<S11HDetailEntity> ReportS11Detail(DateTime startDate, DateTime fromDate, DateTime toDate, string budgetChapterCode,
          string budgetSubKindItemCode, string accountNumber,  bool isSummaryBudgetChapter,
          bool summaryBudgetSubKindItem)
        {
            const string sql = @"uspReport_S11HDetail";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pBudgetChapterCode", budgetChapterCode,
                "@pBudgetSubKindItemCode", budgetSubKindItemCode,
                "@pAccountNumber", accountNumber,               
                "@IsSummaryBudgetChapter", isSummaryBudgetChapter,
                "@pSummaryBudgetSubKindItem", summaryBudgetSubKindItem
            };

            Func<IDataReader, S11HDetailEntity> makeS11HDetail = reader =>
                new S11HDetailEntity
                {
                    StartOfMonth = reader["StartOfMonth"].AsDateTime(),
                    StartOfQuater = reader["StartOfQuater"].AsDateTime(),
                    OrderType = reader["OrderType"].AsInt(),
                    RefType = reader["RefType"].AsInt(),
                    RefId = reader["RefId"].AsString(),
                    RefNo = reader["RefNo"].AsString(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                    SortOrder = reader["SortOrder"].AsString(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    AccountNumber = reader["AccountNumber"].AsString(),
                    AccCot2 = reader["AccCot2"].AsDecimal(),
                    AccCot3 = reader["AccCot3"].AsDecimal(),
                    AccountName = reader["AccountName"].AsString(),
                    AccountingObjectName = reader["AccountingObjectName"].AsString(),
                    BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                    BudgetSourceName = reader["BudgetSourceName"].AsString(),
                    Cot1 = reader["Cot1"].AsDecimal(),
                    Cot2 = reader["Cot2"].AsDecimal(),
                    Cot3 = reader["Cot3"].AsDecimal(),
                    QuyCot2 = reader["QuyCot2"].AsDecimal(),
                    QuyCot3 = reader["QuyCot3"].AsDecimal(),
                    IsOneBudgetChapterCode = reader["IsOneBudgetChapterCode"].AsInt(),
                    IsOneBudgetSourceCode = reader["IsOneBudgetSourceCode"].AsInt(),
                    IsOneBudgetSubKindItemCode = reader["IsOneBudgetSubKindItemCode"].AsInt()
                };

            return Db.ReadList(sql, true, makeS11HDetail, parms);
        }

    }
}
