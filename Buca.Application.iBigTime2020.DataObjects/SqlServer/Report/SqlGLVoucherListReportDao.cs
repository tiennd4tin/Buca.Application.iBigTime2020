using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Ledger;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    /// <summary>
    /// SqlGLVoucherListReportDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report.IGLVoucherListReportDao" />
    public class SqlGLVoucherListReportDao : DaoBase, IGLVoucherListReportDao

    {
        /// <summary>
        /// Reports the gl voucher list detail.
        /// </summary>
        /// <param name="RefId">The reference identifier.</param>
        /// <param name="IsShowSameRow">if set to <c>true</c> [is show same row].</param>
        /// <param name="IsShowOriginalCurrency">if set to <c>true</c> [is show original currency].</param>
        /// <returns></returns>
        public IList<GLVoucherListDetailEntity> ReportGLVoucherListDetail(string RefId, bool IsShowSameRow,
            bool IsShowOriginalCurrency)
        {
            const string sql = @"uspReport_GLVoucherListDetail";
            object[] parms =
            {
                "@RefID", RefId,
                "@IsShowSameRow", IsShowSameRow,
                "@IsShowOriginalCurrency", IsShowOriginalCurrency
            };

            Func<IDataReader, GLVoucherListDetailEntity> makeGLVoucherListReport = reader =>
                new GLVoucherListDetailEntity
                {
                    RefDetailId = reader["RefDetailId"].AsString(),
                    RefId = reader["RefId"].AsString(),
                    DetailRefType = reader["DetailRefType"].AsInt(),
                    DetailId = reader["DetailId"].AsString(),
                    SortOrder = reader["SortOrder"].AsInt(),
                    EntryType = reader["EntryType"].AsInt(),
                    BudgetSourceId = reader["BudgetSourceId"].AsString(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    RefNo = reader["RefNo"].AsString(),
                    Description = reader["Description"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    CurrencyCode = reader["CurrencyCode"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                    RefNoTotal = reader["RefNoTotal"].AsString(),
                    RefDateTotal = reader["RefDateTotal"].AsDateTime(),
                    RefNoCount = reader["RefNoCount"].AsString(),
                };

            return Db.ReadList(sql, true, makeGLVoucherListReport, parms);
        }

        /// <summary>
        /// Chứng từ kế toán
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="refType"></param>
        /// <returns></returns>
        public IList<AccountingVoucherEntity> ReportAccountingVoucher(string refId, int refType)
        {
            const string sql = @"uspReport_AccountingVoucherDetail_Accountant";
            object[] parms =
            {
                "@RefID", refId,
                "@RefType", refType
            };
            return Db.ReadList(sql, true, Make<AccountingVoucherEntity>, parms);
        }

        /// <summary>
        /// Reports the gl voucher list.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public IList<GLVoucherListEntity> ReportGLVoucherList(DateTime fromDate, DateTime toDate, bool isNotShowSignAccount, int amountType, string currencyCode)
        {
            const string sql = @"uspReport_GLVoucherList";
            object[] parms =
            {
                "@fromDate",fromDate,
                "@toDate" , toDate,
                "@isNotShowSignAccount", isNotShowSignAccount,
                "@AmountType", amountType,
                "@CurrencyCode", currencyCode,
            };

            Func<IDataReader, GLVoucherListEntity> makeGLVoucherListReport = reader =>
                new GLVoucherListEntity
                {
                    RefId = reader["RefID"].AsString(),
                    RefType = reader["RefType"].AsInt(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    RefNo = reader["RefNo"].AsString(),
                    VoucherTypeId = reader["VoucherTypeID"].AsString(),
                    SetupType = reader["SetupType"].AsShort(),
                    FromDate = reader["FromDate"].AsDateTime(),
                    ToDate = reader["ToDate"].AsDateTime(),
                    Description = reader["Description"].AsString(),
                    TotalAmount = reader["TotalAmount"].AsDecimal(),
                    EditVersion = reader["EditVersion"].AsInt(),

                };

            return Db.ReadList(sql, true, makeGLVoucherListReport, parms);
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
        public IList<GLVoucherListLedgerEntity> ReportGLVoucherListLedger(DateTime fromDate, DateTime toDate,string budgetSourceId,
            string budgetChapterCode,string budgetSubKindItemCode,bool isSummarrySource,bool isSummaryChapter,bool isSummarySubKindItem,string accountList)
        {
            // const string sql = @"uspReport_S02c_H_GLVoucherListLedger"; 
            const string sql = @"uspReport_GLVoucherListLedger";
            object[] parms =
            {
                "@fromDate",fromDate,
                "@toDate" , toDate,
                "@pBudgetSourceID",budgetSourceId,
                "@pBudgetChapterCode",budgetChapterCode,
                "@pBudgetSubKindItemCode",budgetSubKindItemCode,
                "@isSummarySource",isSummarrySource,
                "@isSummaryChapter",isSummaryChapter,
                "@isSummarySubKindItem",isSummarySubKindItem,
                "@AcountNumberList",accountList
            };
            //        Func<IDataReader, S02_c_H_Entity> makeGLVoucherListReport = reader =>
            //        new S02_c_H_Entity
            //        {
            //        BudgetChapterCode = reader["RefDetailID"].AsString(),
            //        BudgetSourceCode = reader["RefDetailID"].AsString(),
            //            BudgetSourceName = reader["RefDetailID"].AsString(),
            //            BudgetSubKindItemCode = reader["RefDetailID"].AsString(),
            //            RefID = reader["RefDetailID"].AsString(),
            //            RefType = reader["RefDetailID"].AsString(),
            //            RefNo = reader["RefDetailID"].AsString(),
            //            RefDate = reader["RefDetailID"].AsDateTime(),
            //            Description = reader["RefDetailID"].AsString(),
            //            CorrespondingAccountNumber = reader["RefDetailID"].AsString(),
            //            DebitAmount = reader["RefDetailID"].AsDecimal(),
            //            CreditAmount = reader["RefDetailID"].AsDecimal(),
            //            AccountNumber = reader["RefDetailID"].AsString(),
            //            OpeningAmount = reader["RefDetailID"].AsDecimal(),
            //            AccumDebitAmountQuater = reader["RefDetailID"].AsDecimal(),
            //            AccumCreditAmountQuater = reader["RefDetailID"].AsDecimal(),
            //            AccumDebitAmountYear = reader["RefDetailID"].AsDecimal(),
            //            AccumCreditAmountYear = reader["RefDetailID"].AsDecimal(),
            //            Month = reader["RefDetailID"].AsString(),
            //            BeginMonth = reader["RefDetailID"].AsDateTime(),
            //            BeginQuarter = reader["RefDetailID"].AsDateTime(),
            //            AccountCategoryKind = reader["RefDetailID"].AsString(),
            //            Grade = reader["RefDetailID"].AsString(),
            //            AccLevel = reader["RefDetailID"].AsString()
            //        };

            //    return Db.ReadList(sql, true, makeGLVoucherListReport, parms);
            //}

            Func<IDataReader, GLVoucherListLedgerEntity> makeGLVoucherListReport = reader =>
                        new GLVoucherListLedgerEntity
                        {
                            RefDetailId = reader["RefDetailID"].AsString(),
                            RefId = reader["RefID"].AsString(),
                            RefNo = reader["RefNo"].AsString(),
                            PostedDate = reader["PostedDate"].AsDateTime(),
                            RefDate = reader["RefDate"].AsDateTime(),
                            AccountNumber = reader["AccountNumber"].AsString(),
                            CorrespondingAccount = reader["CorrespondingAccount"].AsString(),
                            DebitAmount = reader["DebitAmount"].AsDecimal(),
                            CreditAmount = reader["CreditAmount"].AsDecimal(),
                            BudgetSourceId = reader["BudgetSourceID"].AsString(),
                            BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                            BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                            BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                            Description = reader["Description"].AsString(),
                            StartOfMonth = reader["StarOfMonth"].AsDateTime()
                        };

            return Db.ReadList(sql, true, makeGLVoucherListReport, parms);
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
        public IList<S02CHEntity> GetReportS02CH(DateTime fromDate, DateTime toDate, DateTime startDate, string budgetSourceId,
            string budgetChapterCode, string budgetSubKindItemCode, bool isSummarrySource, bool isSummaryChapter, bool isSummarySubKindItem, string accountList)
        {
            const string sql = @"uspReport_S02cH_P2";
            object[] parms =
            {
                "@FromDate",fromDate,
                "@ToDate" , toDate,
                "@StartDate", startDate,
                "@pBudgetSourceID",budgetSourceId,
                "@pBudgetChapterCode",budgetChapterCode,
                "@pBudgetSubKindItemCode",budgetSubKindItemCode,
                "@isSummarySource",isSummarrySource,
                "@isSummaryChapter",isSummaryChapter,
                "@isSummarySubKindItem",isSummarySubKindItem,
                "@AcountNumberList",accountList,
                "@PeriodType",2
            };

            Func<IDataReader, S02CHEntity> MakeS02CH = reader =>
                new S02CHEntity
                {
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                    BudgetSourceName = reader["BudgetSourceName"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    RefID = reader["RefID"].AsString(),
                    RefType = reader["RefType"].AsInt(),
                    RefNo = reader["RefNo"].AsString(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    Description = reader["Description"].AsString(),
                    CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                    DebitAmount = reader["DebitAmount"].AsDecimal(),
                    CreditAmount = reader["CreditAmount"].AsDecimal(),
                    AccountNumber = reader["AccountNumber"].AsString(),
                    OpeningAmount = reader["OpeningAmount"].AsDecimal(),
                    AccumDebitAmountQuater = reader["AccumDebitAmountQuater"].AsDecimal(),
                    AccumCreditAmountQuater = reader["AccumCreditAmountQuater"].AsDecimal(),
                    AccumDebitAmountYear = reader["AccumDebitAmountYear"].AsDecimal(),
                    AccumCreditAmountYear = reader["AccumCreditAmountYear"].AsDecimal(),
                    Month = reader["Month"].AsInt(),
                    BeginMonth = reader["BeginMonth"].AsDateTime(),
                    BeginQuarter = reader["BeginQuarter"].AsDateTime(),
                    AccountCategoryKind = reader["AccountCategoryKind"].AsInt(),
                    Grade = reader["Grade"].AsInt(),
                    AccLevel = reader["AccLevel"].AsString()
                };

            return Db.ReadList(sql, true, MakeS02CH, parms);
        }

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
        public IList<S51HEntity> GetReportS51H(DateTime fromDate, DateTime toDate, DateTime startDate,
        string inventoryItemId, string activityId, bool isSummaryInventory, bool isSummaryActivity)
        {
            const string sql = @"uspReport_S51H";
            object[] parms =
            {
                "@DBStartDate", startDate,
                "@FromDate",fromDate,
                "@ToDate" , toDate,
                "@StartDate", startDate,
                "@ActivityID",activityId,
                "@InventoryItemID",inventoryItemId,
                "@IsSummaryActivity",isSummaryActivity,
                "@IsSummaryInventory",isSummaryInventory
            };

            Func<IDataReader, S51HEntity> MakeS02CH = reader =>
                new S51HEntity
                {
                    RefNo = reader["RefNo"].AsString(),
                    RefId = reader["RefID"].AsString(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    Description = reader["Description"].AsString(),
                    Quantity = reader["Quantity"].AsDecimal(),
                    UnitPrice = reader["UnitPrice"].AsDecimal(),
                    TotalAmount = reader["TotalAmount"].AsDecimal(),
                    DiscountAmount = reader["DiscountAmount"].AsDecimal(),
                    Part = reader["Part"].AsInt(),
                    ActivityId = reader["ActivityId"].AsString(),
                    ActivityCode = reader["ActivityCode"].AsString(),
                    ActivityName = reader["ActivityName"].AsString(),
                    InventoryItemId = reader["InventoryItemId"].AsString(),
                    InventoryItemCode = reader["InventoryItemCode"].AsString(),
                    InventoryItemName = reader["InventoryItemName"].AsString(),
                    RefType = reader["RefType"].AsInt()
                };

            return Db.ReadList(sql, true, MakeS02CH, parms);
        }
    }
}


