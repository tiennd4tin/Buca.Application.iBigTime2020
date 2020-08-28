using Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Ledger;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    /// <summary>
    /// Class ReportLedgerAccountingDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report.IReportLedgerAccountingDao" />
    public class SqlServerReportLedgerAccountingDao : DaoBase, IReportLedgerAccountingDao
    {

        public IList<S27Entity> GetReportS27(DateTime fromDate, DateTime toDate, string accountCode,
            string currencyCode,
            string budgetSourceId, string projectId, int amountType)
        {
            const string sql = @"uspReportLedgerAccounting_S27";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@CurrencyCode", currencyCode,
                "@AccountCode", accountCode,
                "@WhereProject", projectId,
                "@AmountType", amountType,
                "@WhereBudgetSource", budgetSourceId

            };
            return Db.ReadList(sql, true, Make<S27Entity>, parms);
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
            Func<IDataReader, S04HEntity> makeS04H = reader =>
               new S04HEntity
               {
                   BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                   BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                   BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                   BudgetSourceName = reader["BudgetSourceName"].AsString(),
                   RefId = reader["RefID"].AsString(),
                   RefNo = reader["RefNo"].AsString(),
                   RefDate = reader["RefDate"].AsDateTime(),
                   RefDetailId = reader["RefDetailID"].AsString(),
                   RefType = reader["RefType"].AsInt(),
                   Posted = reader["Posted"].AsBool(),
                   PostedDate = reader["PostedDate"].AsDateTime(),
                   AccountNumber = reader["AccountNumber"].AsString(),
                   CreditAmount = reader["CreditAmount"].AsDecimal(),
                   DebitAmount = reader["DebitAmount"].AsDecimal(),
                   CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                   Description = reader["Description"].AsString(),
                   //  JournalMemo = reader[""].AsString(),
                   //SortOrder = reader["SortOrder"].AsInt(),                  
               };

            const string sql = @"uspReport_S04H";
            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@AddSameEntry", addSameEntry,
                "@BudgetSourceCode",budgetSourceCode,
                "@BudgetChapterCode", budgetChapterCode,
                "@BudgetSubKindItemCode", budgetSubKindItemCode,
                "@IsSummaryBudgetSource",isSummaryBudgetSource,
                "@IsSummaryBudgetChapter", isSummaryBudgetChapter,
                "@IsSummaryBudgetSubKindItem", summaryBudgetSubKindItem,
                "@AmountType", amountType,
                "@CurrencyCode", currencyCode

            };
            return Db.ReadList(sql, true, makeS04H, parms);

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
            Func<IDataReader, S05HEntity> makeS05H = reader =>
              new S05HEntity
              {
                  AccountCategory = reader["AccountCategory"].AsInt(),
                  BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                  AccountCategoryKind = reader["AccountCategoryKind"].AsInt(),
                  AccountName = reader["AccountName"].AsString(),
                  ClosingCreditAmount = reader["ClosingCreditAmount"].AsDecimal(),
                  ClosingDebitAmount = reader["ClosingDebitAmount"].AsDecimal(),
                  Grade = reader["Grade"].AsInt(),
                  IsParent = reader["IsParent"].AsBool(),
                  LKDN_CreditAmount = reader["LKDN_CreditAmount"].AsDecimal(),
                  LKDN_DebitAmount = reader["LKDN_DebitAmount"].AsDecimal(),
                  MovementCreditAmount = reader["MovementCreditAmount"].AsDecimal(),
                  AccountNumber = reader["AccountNumber"].AsString(),
                  MovementDebitAmount = reader["MovementDebitAmount"].AsDecimal(),
                  OpenAjustCreditAmount = reader["OpenAjustCreditAmount"].AsDecimal(),
                  OpenAjustDebitAmount = reader["OpenAjustDebitAmount"].AsDecimal(),
                  OpenCreditAmount = reader["OpenCreditAmount"].AsDecimal(),
                  OpenDebitAmount = reader["OpenDebitAmount"].AsDecimal()
              };

            object[] parms =
            {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@budgetChapterCode", budgetChapterCode,
                "@pSummaryBudgetChapter", isSummaryBudgetChapter,
                "@amountType", amounttype,
                "@currencyCode", currencycode
            };

            return Db.ReadList("uspReport_S05H", true, makeS05H, parms);
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
        public IList<S31HEntity> GetReportS31H(DateTime startDate, DateTime fromDate, DateTime toDate, string accountNumber, int amountType, string currencyCode, string CorrespondingAccountNumber, string AccountingObjectID, string BudgetSourceID, string FundStructureID, string BudgetChapterCode, string BudgetKindItemCode, string BudgetItemCode, string ProjectID, string ContractID, string BankID, string ActivityId, string CapitalPlanID, bool IsAccountingObjectID, bool IsGroupBudgetSourceID, bool IsGroupFundStructureID, bool IsGroupBudgetChapterCode, bool IsGroupBudgetKindItemCode, bool IsGroupBudgetItemCode, bool IsGroupProjectID, bool IsGroupContractID, bool IsGroupBankID, bool IsGroupActivityId, bool IsGroupCapitalPlanID, bool IsGroupCurrencyCode, bool ISCustomer, bool ISVendor, bool ISEmployee, string CustomerID, string VendorID, string EmployeeID, string FixedAssetId, string InventoryItemId, bool IsGroupFixedAssetId, bool IsGroupInventoryItemId)
        {
            Func<IDataReader, S31HEntity> makeS31H = reader =>
               new S31HEntity
               {
                   BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                   BudgetSourceName = reader["BudgetSourceName"].AsString(),
                   RefId = reader["RefID"].AsString(),
                   RefNo = reader["RefNo"].AsString(),
                   RefDate = reader["RefDate"].AsDateTime(),
                   RefType = reader["RefType"].AsInt(),
                   PostedDate = reader["PostedDate"].AsDateTime(),
                   AccountNumber = reader["AccountNumber"].AsString(),
                   CreditAmount = reader["CreditAmount"].AsDecimal(),
                   DebitAmount = reader["DebitAmount"].AsDecimal(),
                   AccountCategoryKind = reader["AccountCategoryKind"].AsInt(),
                   AccountingObjectCode = reader["AccountingObjectID"].AsString(),
                   AccountingObjectName = reader["AccountingObjectName"].AsString(),
                   ClosingCreditAmount = reader["ClosingCreditAmount"].AsDecimal(),
                   ClosingDebitAmount = reader["ClosingDebitAmount"].AsDecimal(),
                   AccountName = reader["AccountName"].AsString(),
                   JournalMemo = reader["JournalMemo"].AsString(),
                   OrderType = reader["OrderType"].AsInt(),
                   CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                   Description = reader["Description"].AsString(),
                   ProjectName= reader["ProjectName"].AsString(),
                   ProjectID = reader["ProjectID"].AsString(),
                   FundStructureName= reader["FundStructureName"].AsString(),
                   FundStructureID= reader["FundStructureID"].AsString(),
                   CurrencyName= reader["CurrencyName"].AsString(),
                   CurrencyCode= reader["CurrencyCode"].AsString(),
                   ContractName= reader["ContractName"].AsString(),
                   ContractID= reader["ContractID"].AsString(),
                   CapitalPlanName= reader["CapitalPlanName"].AsString(),
                   CapitalPlanID= reader["CapitalPlanID"].AsString(),
                   ActivityId= reader["ActivityId"].AsString(),
                   ActivityName= reader["ActivityName"].AsString(),
                   BankID= reader["BankID"].AsString(),
                   BankName = reader["BankName"].AsString(),
                   BudgetChapterName= reader["BudgetChapterName"].AsString(),
                   BudgetItemCode= reader["BudgetItemCode"].AsString(),
                   BudgetItemName= reader["BudgetItemName"].AsString(),
                   BudgetKindItemCode= reader["BudgetKindItemCode"].AsString(),
                   BudgetKindItemName= reader["BudgetKindItemName"].AsString(),
                   BudgetSourceID= reader["BudgetSourceID"].AsString(),
                   FixedAssetId= reader["FixedAssetId"].AsString(),
                   FixedAssetName = reader["FixedAssetName"].AsString(),
                   InventoryItemId = reader["InventoryItemId"].AsString(),
                   InventoryItemName = reader["InventoryItemName"].AsString(),
               };

            object[] parms =
          {
               "@pStartDate",startDate,
               "@pFromDate",fromDate,
               "@pTodate",toDate,
               "@pAccountNumber",accountNumber,
               "@CorrespondingAccountNumber",CorrespondingAccountNumber,
              "@AccountingObjectID",AccountingObjectID,
              "@BudgetSourceID",BudgetSourceID,
              "@FundStructureID",FundStructureID,
              "@BudgetChapterCode",BudgetChapterCode,
              "@BudgetKindItemCode",BudgetKindItemCode,
              "@BudgetItemCode",BudgetItemCode,
              "@ProjectID",ProjectID,
              "@ContractID",ContractID,
              "@BankID",BankID,
              "@ActivityId",ActivityId,
              "@CapitalPlanID",CapitalPlanID,
              "@AmountType" ,amountType,
              "@CurrencyCode",currencyCode,
              "@IsAccountingObjectID",IsAccountingObjectID,
              "@IsGroupBudgetSourceID",IsGroupBudgetSourceID,
              "@IsGroupFundStructureID",IsGroupFundStructureID,
              "@IsGroupBudgetChapterCode",IsGroupBudgetChapterCode,
              "@IsGroupBudgetKindItemCode",IsGroupBudgetKindItemCode,
              "@IsGroupBudgetItemCode",IsGroupBudgetItemCode,
              "@IsGroupProjectID",IsGroupProjectID,
              "@IsGroupContractID",IsGroupContractID,
              "@IsGroupBankID",IsGroupBankID,
              "@IsGroupActivityId",IsGroupActivityId,
              "@IsGroupCapitalPlanID",IsGroupCapitalPlanID,
              "@IsGroupCurrencyCode",IsGroupCurrencyCode,
              "@ISCustomer",ISCustomer,
              "@ISVendor",ISVendor,
              "@ISEmployee",ISEmployee,
              "@CustomerID",CustomerID,
              "@VendorID",VendorID,
              "@EmployeeID",EmployeeID,
              "@FixedAssetId",FixedAssetId,
              "@InventoryItemId",InventoryItemId,
              "@IsGroupFixedAssetId",IsGroupFixedAssetId,
              "@IsGroupInventoryItemId",IsGroupInventoryItemId,
              

          };
            return Db.ReadList("uspReport_S31H", true, makeS31H, parms);
        }

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
            Func<IDataReader, S03HEntity> makeS03H = reader =>
               new S03HEntity
               {
                   StartOfMonth = reader["StartOfMONTH"].AsDateTime(),
                   OrderType = reader["OrderType"].AsInt(),
                   RefId = reader["RefID"].AsString(),
                   RefType = reader["RefType"].AsInt(),
                   RefNo = reader["RefNo"].AsString(),
                   PostedDate = reader["PostedDate"].AsDateTime(),
                   RefDate = reader["RefDate"].AsDateTime(),
                   JournalMemo = reader["JournalMemo"].AsString(),
                   RefDetailID = reader["RefDetailID"].AsString(),
                   GeneralLedgerID = reader["GeneralLedgerID"].AsString(),
                   Description = reader["Description"].AsString(),
                   AccountNumberLevelOne = reader["AccountNumberLevelOne"].AsString(),
                   AccountNumber = reader["AccountNumber"].AsString(),
                   AccountName = reader["AccountName"].AsString(),
                   AccountCategoryKind = reader["AccountCategoryKind"].AsString(),
                   CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                   BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                   BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                   BudgetSourceName = reader["BudgetSourceName"].AsString(),
                   BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                   SortOrder = reader["SortOrder"].AsString(),
                   Cot1 = reader["Cot1"].AsDecimal(),
                   Cot2 = reader["Cot2"].AsDecimal(),
                   AccCot2 = reader["AccCot2"].AsDecimal(),
                   QuyCot2 = reader["QuyCot2"].AsDecimal(),
                   Cot3 = reader["Cot3"].AsDecimal(),
                   AccCot3 = reader["AccCot3"].AsDecimal(),
                   QuyCot3 = reader["QuyCot3"].AsDecimal(),
                   StartOfQuater = reader["StartOfQuater"].AsDateTime(),
                   IsOneBudgetChapterCode = reader["IsOneBudgetChapterCode"].AsInt(),
                   IsOneBudgetSourceCode = reader["IsOneBudgetSourceCode"].AsInt(),
                   IsOneBudgetSubKindItemCode = reader["IsOneBudgetSubKindItemCode"].AsInt()
               };

            const string sql = @"uspReport_S03H";

            object[] parms =
            {
                    "@pStartDate", startDate,
                    "@pFromDate", fromDate,
                    "@pTodate", toDate,
                    "@pBudgetSourceID",budgetSourceCode,
                    "@AccountNumberList" ,accountnumberlist,
                    "@AddSameEntry", addSameEntry,
                    "@IsForeignCurrency" , false,
                    "@BudgetChapterCode", budgetChapterCode,
                    "@pBudgetSubKindItemCode", budgetSubKindItemCode,
                    "@pIsSummarySource",isSummaryBudgetSource,
                    "@pSummaryBudgetChapter", isSummaryBudgetChapter,
                    "@pSummaryBudgetSubKindItem", summaryBudgetSubKindItem,
                    "@pIsPrintMonth13", isPrintMonth13,
                    "@pIsPrintAllYearAndMonth13", isPrintAllYearAndMonth13,
                "@AmountType" ,amountType,
                "@CurrencyCode",currencyCode,
                "@pIsDetail", isDetail

                };
            return Db.ReadList(sql, true, makeS03H, parms);

        }

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
        public IList<S03HEntity> GetReportS02CH(DateTime startDate, DateTime fromDate, DateTime toDate, bool addSameEntry, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
                                         bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem, string accountnumberlist, bool isPrintMonth13, bool isPrintAllYearAndMonth13, bool IsForeinCurrency, int AmountType, string CurrencyCode)
        {
            Func<IDataReader, S03HEntity> makeS03H = reader =>
               new S03HEntity
               {
                   StartOfMonth = reader["StartOfMONTH"].AsDateTime(),
                   OrderType = reader["OrderType"].AsInt(),
                   RefId = reader["RefID"].AsString(),
                   RefType = reader["RefType"].AsInt(),
                   RefNo = reader["RefNo"].AsString(),
                   PostedDate = reader["PostedDate"].AsDateTime(),
                   RefDate = reader["RefDate"].AsDateTime(),
                   JournalMemo = reader["JournalMemo"].AsString(),
                   RefDetailID = reader["RefDetailID"].AsString(),
                   GeneralLedgerID = reader["GeneralLedgerID"].AsString(),
                   Description = reader["Description"].AsString(),
                   AccountNumberLevelOne = reader["AccountNumberLevelOne"].AsString(),
                   AccountNumber = reader["AccountNumber"].AsString(),
                   AccountName = reader["AccountName"].AsString(),
                   AccountCategoryKind = reader["AccountCategoryKind"].AsString(),
                   CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                   BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                   BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                   BudgetSourceName = reader["BudgetSourceName"].AsString(),
                   BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                   CurrencyCode = reader["CurrencyCode"].AsString(),
                   SortOrder = reader["SortOrder"].AsString(),
                   Cot1 = reader["Cot1"].AsDecimal(),
                   Cot2 = reader["Cot2"].AsDecimal(),
                   AccCot2 = reader["AccCot2"].AsDecimal(),
                   QuyCot2 = reader["QuyCot2"].AsDecimal(),
                   Cot3 = reader["Cot3"].AsDecimal(),
                   AccCot3 = reader["AccCot3"].AsDecimal(),
                   QuyCot3 = reader["QuyCot3"].AsDecimal(),
                   StartOfQuater = reader["StartOfQuater"].AsDateTime(),
                   IsOneBudgetChapterCode = reader["IsOneBudgetChapterCode"].AsInt(),
                   IsOneBudgetSourceCode = reader["IsOneBudgetSourceCode"].AsInt(),
                   IsOneBudgetSubKindItemCode = reader["IsOneBudgetSubKindItemCode"].AsInt(),
                   OpeningAmount = reader["OpeningAmount"].AsDecimal()
               };

            const string sql = @"uspReport_S02CH";

            object[] parms =
            {
                    "@pStartDate", startDate,
                    "@pFromDate", fromDate,
                    "@pTodate", toDate,
                    "@pBudgetSourceID",budgetSourceCode,
                    "@AccountNumberList" ,accountnumberlist,
                    "@AddSameEntry", addSameEntry,
                    "@IsForeignCurrency" , IsForeinCurrency,
                    "@BudgetChapterCode", budgetChapterCode,
                    "@pBudgetSubKindItemCode", budgetSubKindItemCode,
                    "@pIsSummarySource",isSummaryBudgetSource,
                    "@pSummaryBudgetChapter", isSummaryBudgetChapter,
                    "@pSummaryBudgetSubKindItem", summaryBudgetSubKindItem,
                    "@pIsPrintMonth13", isPrintMonth13,
                    "@pIsPrintAllYearAndMonth13", isPrintAllYearAndMonth13,
                    "@AmountType", AmountType,
                    "@CurrencyCode", CurrencyCode

                };
            return Db.ReadList(sql, true, makeS03H, parms);

        }

        /// <summary>
        /// Gets the C33 bb.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="DepartmentId">The department identifier.</param>
        /// <param name="AccountingObjectList">The accounting object list.</param>
        /// <returns></returns>
        public IList<C33BBEntity> GetC33BB(DateTime fromDate, DateTime toDate, string DepartmentId, string AccountingObjectList)
        {
            Func<IDataReader, C33BBEntity> makeC33BB = reader =>
               new C33BBEntity
               {
                   RefId = reader["RefID"].AsString(),
                   RefDate = reader["RefDate"].AsDateTime(),
                   RefNo = reader["RefNo"].AsString(),
                   PostedDate = reader["PostedDate"].AsDateTime(),
                   Description = reader["Description"].AsString(),
                   SortOrder = reader["SortOrder"].AsInt(),
                   AccountingObjectName = reader["AccountingObjectName"].AsString(),
                   Amount = reader["Amount"].AsDecimal(),
                   IsBold = reader["IsBold"].AsBool(),
                   LineDetail = reader["LineDetail"].AsString(),
                   AccountingObjectId = reader["AccountingObjectID"].AsString(),
                   AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
                   Part = reader["Part"].AsInt()
               };

            const string sql = @"uspReport_GetData_ForReport_C33BB";
            object[] parms =
            {
                    "@pFromDate", fromDate,
                    "@pToDate", toDate,
                    "@pDepartmentID",DepartmentId,
                    "@pAccountingObjectIDList" ,AccountingObjectList,
                };
            return Db.ReadList(sql, true, makeC33BB, parms);

        }
        /// <summary>
        /// Gets the S34 h.
        /// </summary>
        /// <param name="startdate">The startdate.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountnumber">The account.</param>
        /// <param name="correspondingAccount">The corresponding account.</param>
        /// <param name="AccountingObjectList">The accounting object list.</param>
        /// <param name="ProjectList">The project list.</param>
        /// <param name="issumaccount">if set to <c>true</c> [issumaccount].</param>
        /// <param name="groupsameitem">if set to <c>true</c> [groupsameitem].</param>
        /// <returns></returns>
        public IList<S34H_GL_MasterEntity> GetS34H(DateTime startdate, DateTime fromDate, DateTime toDate, string accountnumber, string correspondingAccount, string AccountingObjectList, string ProjectList, bool issumaccount, bool groupsameitem,bool isDetail, int amountType, string currencyCode)
        {
            IList<S34H_GL_MasterEntity> list = new List<S34H_GL_MasterEntity>();
            const string sql = @"uspReport_GetS34H";
            object[] parms =
            {
                "@pStartDate",startdate,
                "@pFromDate", fromDate,
                "@pTodate", toDate,
                "@AccountNumber",accountnumber,
                "@CorrespondingAccount",correspondingAccount,
                "@pAccountingObjectID_List" ,AccountingObjectList,
                "@pProjectID_List" ,ProjectList,
                "@IsSummaryAccountNumber", issumaccount,
                "@pGroupTheSameItem",groupsameitem,
                "@pIsDetail", isDetail,
                "@AmountType",amountType,
                "@CurrencyCode",currencyCode,
                };
            var listobj = Db.ReadList(sql, true, makeS34, parms);
            foreach (var s34master in listobj)
            {
                bool sumaccount = true;
                if (s34master.AccountNumber != null)
                    sumaccount = false;
                IList<S34H_GL_Master_LineDetailEntity> details = GetS34H_GL_Master_LineDetail(startdate, fromDate, toDate, s34master.AccountNumber, s34master.CorrespondingAccount, s34master.AccountingObjectId + ";", s34master.ProjectId + ";", sumaccount, groupsameitem, isDetail, amountType, currencyCode).ToList();
                s34master.GL_Master_LineDetail = details;
                list.Add(s34master);
            }
            return list;

        }
        /// <summary>
        /// Gets the S34 h gl detail sub detail.
        /// </summary>
        /// <param name="startdate">The startdate.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountnumber">The account.</param>
        /// <param name="correspondingAccount">The corresponding account.</param>
        /// <param name="AccountingObjectList">The accounting object list.</param>
        /// <param name="ProjectList">The project list.</param>
        /// <param name="issumaccount">if set to <c>true</c> [issumaccount].</param>
        /// <param name="groupsameitem">if set to <c>true</c> [groupsameitem].</param>
        /// <param name="monthyear">The monthyear.</param>
        /// <returns></returns>
        public IList<S34H_GL_Detail_SubDetailEntity> GetS34H_GL_Detail_SubDetail(DateTime startdate, DateTime fromDate, DateTime toDate, string accountnumber, string correspondingAccount, string AccountingObjectList, string ProjectList, bool issumaccount, bool groupsameitem, int monthyear, bool isDetail, int amountType, string currencyCode)
        {
            IList<S34H_GL_Detail_SubDetailEntity> list = new List<S34H_GL_Detail_SubDetailEntity>();
            const string sql = @"uspReport_GetS34H";
            object[] parms =
            {
                "@pStartDate",startdate,
                "@pFromDate", fromDate,
                "@pTodate", toDate,
                "@AccountNumber",accountnumber,
                "@CorrespondingAccount",correspondingAccount,
                "@pAccountingObjectID_List" ,AccountingObjectList,
                "@pProjectID_List" ,ProjectList,
                "@IsSummaryAccountNumber", issumaccount,
                "@pGroupTheSameItem",groupsameitem,
                "@tableOutput",3,
                "@monthyear",monthyear,
                "@pIsDetail",isDetail,
                "@AmountType",amountType,
                "@CurrencyCode",currencyCode,
                };
            return Db.ReadList(sql, true, makeS34_SubDetail, parms); 
        }
        /// <summary>
        /// Gets the S34 h gl master line detail.
        /// </summary>
        /// <param name="startdate">The startdate.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="accountnumber">The accountnumber.</param>
        /// <param name="correspondingAccount">The corresponding account.</param>
        /// <param name="AccountingObjectList">The accounting object list.</param>
        /// <param name="ProjectList">The project list.</param>
        /// <param name="issumaccount">if set to <c>true</c> [issumaccount].</param>
        /// <param name="groupsameitem">if set to <c>true</c> [groupsameitem].</param>
        /// <returns></returns>
        public IList<S34H_GL_Master_LineDetailEntity> GetS34H_GL_Master_LineDetail(DateTime startdate, DateTime fromDate, DateTime toDate, string accountnumber, string correspondingAccount, string AccountingObjectList, string ProjectList, bool issumaccount, bool groupsameitem,bool isDetail, int amountType, string currencyCode)
        {
            IList<S34H_GL_Master_LineDetailEntity> list = new List<S34H_GL_Master_LineDetailEntity>();
            const string sql = @"uspReport_GetS34H";
            object[] parms =
            {
                "@pStartDate",startdate,
                "@pFromDate", fromDate,
                "@pTodate", toDate,
                "@AccountNumber",accountnumber,
                "@CorrespondingAccount",correspondingAccount,
                "@pAccountingObjectID_List" ,AccountingObjectList,
                "@pProjectID_List" ,ProjectList,
                "@IsSummaryAccountNumber", issumaccount,
                "@pGroupTheSameItem",groupsameitem,
                "@tableOutput",2,
                "@pIsDetail",isDetail,
                "@AmountType",amountType,
                "@CurrencyCode",currencyCode,
                };
            var listobj = Db.ReadList(sql, true, makeS34_detail, parms);

            //S34H_GL_Detail_SubDetailEntity GL_Detail_SubDetail = new S34H_GL_Detail_SubDetailEntity();
            IList<S34H_GL_Detail_SubDetailEntity> listGl = new List<S34H_GL_Detail_SubDetailEntity>();

            foreach (var s34detail in listobj)
            {
                if (s34detail.ItemCode == 2)
                {
                    IList<S34H_GL_Detail_SubDetailEntity> subdetails =
                        GetS34H_GL_Detail_SubDetail(startdate, fromDate, toDate, accountnumber,correspondingAccount,
                            AccountingObjectList,ProjectList, false, groupsameitem, s34detail.MonthYear,isDetail,amountType,currencyCode).ToList();
                    s34detail.GL_Detail_SubDetail = subdetails;
                }
                else
                {
                    s34detail.GL_Detail_SubDetail = listGl;
                }
                list.Add(s34detail);
            }
            return list;

        }
        /// <summary>
        /// The make S34
        /// </summary>
        Func<IDataReader, S34H_GL_MasterEntity> makeS34 = reader =>
              new S34H_GL_MasterEntity
              {
                  AccountNumber = reader["AccountNumber"].AsString(),
                  CorrespondingAccount = reader["CorrespondingAccount"].AsString(),
                  AccountCategoryKind = reader["AccountCategoryKind"].AsInt(),
                  AccountName = reader["AccountName"].AsString(),
                  AccountingObjectCode = reader["AccountingObjectCode"].AsString(),
                  AccountingObjectId = reader["AccountingObjectId"].AsString(),
                  ProjectId= reader["ProjectId"].AsString(),
                  ProjectName= reader["ProjectName"].AsString(),
                  AccountingObjectName = reader["AccountingObjectName"].AsString(),

              };
        /// <summary>
        /// The make S34 sub detail
        /// </summary>
        Func<IDataReader, S34H_GL_Detail_SubDetailEntity> makeS34_SubDetail = reader =>
              new S34H_GL_Detail_SubDetailEntity
              {
                  AccountNumber = reader["AccountNumber"].AsString(),
                  AccountCategoryKind = reader["AccountCategoryKind"].AsInt(),
                  AccountingObjectId = reader["AccountingObjectId"].AsString(),
                  CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                  CreditAmount = reader["CreditAmount"].AsDecimal(),
                  DebitAmount = reader["DebitAmount"].AsDecimal(),
                  Description = reader["Description"].AsString(),
                  ItemCode = reader["ItemCode"].AsInt(),
                  JournalMemo = reader["JournalMemo"].AsString(),
                  MonthYear = reader["MonthYear"].AsInt(),
                  PostedDate = reader["PostedDate"].AsDateTime(),
                  RefDate = reader["RefDate"].AsDateTime(),
                  RefId = reader["RefId"].AsString(),
                  RefNo = reader["RefNo"].AsString(),
                  RefType = reader["RefType"].AsInt(),
                  SortOrder = reader["SortOrder"].AsInt(),
                  Amount = reader["Amount"].AsDecimal()
              };
        /// <summary>
        /// The make S34 detail
        /// </summary>
        Func<IDataReader, S34H_GL_Master_LineDetailEntity> makeS34_detail = reader =>
              new S34H_GL_Master_LineDetailEntity
              {
                  AccountNumber = reader["AccountNumber"].AsString(),
                  AccountCategoryKind = reader["AccountCategoryKind"].AsInt(),
                  AccountingObjectId = reader["AccountingObjectId"].AsString(),
                  ItemCode = reader["ItemCode"].AsInt(),
                  MonthYear = reader["MonthYear"].AsInt(),
                  CreditAmount = reader["CreditAmount"].AsDecimal(),
                  DebitAmount = reader["DebitAmount"].AsDecimal(),
                  ItemName = reader["ItemName"].AsString(),
                  MonthPeriod = reader["MonthPeriod"].AsInt()
              };

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
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<S13HEntity> GetReportS13H(DateTime startDate, DateTime fromDate, DateTime toDate, string accounts, string currencyCode, bool isDetail,bool isDetailMonth, string bankAccount)
        {
            Func<IDataReader, S13HEntity> makeS03H = reader =>
                new S13HEntity
                {
                    RefId = reader["RefID"].AsString(),
                    RefType = reader["RefType"].AsInt(),
                    RefNo = reader["RefNo"].AsString(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    //Description = reader["Description"].AsString(),
                    AccountNumber = reader["AccountNumber"].AsString(),
                    AccountName = reader["AccountName"].AsString(),
                    OrderType = reader["OrderType"].AsInt(),
                    SortOrder = reader["SortOrder"].AsString(),
                    CurrencyCode = reader["CurrencyCode"].AsString(),
                    //CurrencyName = reader["CurrencyName"].AsString(),
                    ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                    Cot1 = reader["Cot1"].AsDecimal(),
                    Cot1OC = reader["Cot1OC"].AsDecimal(),
                    Cot2 = reader["Cot2"].AsDecimal(),
                    Cot2OC = reader["Cot2OC"].AsDecimal(),
                    Cot3 = reader["Cot3"].AsDecimal(),
                    Cot3OC = reader["Cot3OC"].AsDecimal(),
                    StartOfMonth = reader["StartOfMonth"].AsDateTime()
                };

            const string sql = @"uspReport_S13H";
            object[] parms =
            {
                "@pStartDate", startDate,
                "@pFromDate", fromDate  ,
                "@pToDate", toDate,
                "@Account", accounts,
                "@pCurrencyCode", currencyCode,
                "@pIsDetail", isDetail,
                "@pIsDetailMonth", isDetailMonth,
                "@BankAccount", bankAccount
            };
            return Db.ReadList(sql, true, makeS03H, parms);
        }

        /// <summary>
        /// Gets the report S01 h.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="addSameEntry">if set to <c>true</c> [add same entry].</param>
        /// <param name="isviewoutAccount">if set to <c>true</c> [isviewout account].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="isSummaryBudgetSource">if set to <c>true</c> [is summary budget source].</param>
        /// <param name="isSummaryBudgetChapter">if set to <c>true</c> [is summary budget chapter].</param>
        /// <param name="summaryBudgetSubKindItem">if set to <c>true</c> [summary budget sub kind item].</param>
        /// <returns></returns>
        public DataTable GetReportS01H(DateTime fromDate, DateTime toDate, bool addSameEntry, bool isviewoutAccount, string budgetSourceCode, string budgetChapterCode, string budgetSubKindItemCode,
                                         bool isSummaryBudgetSource, bool isSummaryBudgetChapter, bool summaryBudgetSubKindItem)
        {
            const string sql = @"uspReportS01H";
            object[] parms =
            {
                "@pStartDate",fromDate,
                "@pFromDate", fromDate,
                "@pToDate", toDate,
                "@pIsSumSameEntry", addSameEntry,
                "@pBudgetSourceID",budgetSourceCode,
                "@pBudgetChapterCode", budgetChapterCode,
                "@pBudgetSubKindItemCode", budgetSubKindItemCode,
                "@IsSummaryByBudgetSource",isSummaryBudgetSource,
                "@IsSummaryByBudgetChapter", isSummaryBudgetChapter,
                "@IsSummaryByBudgetSubKindItem", summaryBudgetSubKindItem,
                "@IsViewOutsideAccount",true
            };
            return Db.ReadDataTable(sql, true, parms);
           // return Db.ReadList(sql, true, parms);
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
            Func<IDataReader, S01HLedgerEntity> makeS03H = reader =>
               new S01HLedgerEntity
               {
                   StartOfMonth = reader["StartOfMONTH"].AsDateTime(),
                   OrderType = reader["OrderType"].AsInt(),
                   RefId = reader["RefID"].AsString(),
                   RefType = reader["RefType"].AsInt(),
                   RefNo = reader["RefNo"].AsString(),
                   PostedDate = reader["PostedDate"].AsDateTime(),
                   RefDate = reader["RefDate"].AsDateTime(),
                   JournalMemo = reader["JournalMemo"].AsString(),
                   RefDetailId = reader["RefDetailID"].AsString(),
                   GeneralLedgerId = reader["GeneralLedgerID"].AsString(),
                   Description = reader["Description"].AsString(),
                   AccountNumberLevelOne = reader["AccountNumberLevelOne"].AsString(),
                   AccountNumber = reader["AccountNumber"].AsString(),
                   AccountName = reader["AccountName"].AsString(),
                   AccountCategoryKind = reader["AccountCategoryKind"].AsString(),
                   CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
                   BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                   BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                   BudgetSourceName = reader["BudgetSourceName"].AsString(),
                   BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                   SortOrder = reader["SortOrder"].AsString(),
                   Cot1 = reader["Cot1"].AsDecimal(),
                   Cot2 = reader["Cot2"].AsDecimal(),
                   AccCot2 = reader["AccCot2"].AsDecimal(),
                   QuyCot2 = reader["QuyCot2"].AsDecimal(),
                   Cot3 = reader["Cot3"].AsDecimal(),
                   AccCot3 = reader["AccCot3"].AsDecimal(),
                   QuyCot3 = reader["QuyCot3"].AsDecimal(),
                   StartOfQuater = reader["StartOfQuater"].AsDateTime(),
                   IsOneBudgetChapterCode = reader["IsOneBudgetChapterCode"].AsInt(),
                   IsOneBudgetSourceCode = reader["IsOneBudgetSourceCode"].AsInt(),
                   IsOneBudgetSubKindItemCode = reader["IsOneBudgetSubKindItemCode"].AsInt(),
                   RowAccountNumber = reader["RowAccountNumber"].AsString(),
                   OpeningAmount = reader["OpeningAmount"].AsDecimal()
               };

            const string sql = @"uspReport_S03H1";

            object[] parms =
            {
                    "@pStartDate", startDate,
                    "@pFromDate", fromDate,
                    "@pTodate", toDate,
                    "@pBudgetSourceID",budgetSourceCode,
                    "@AccountNumberList" ,accountnumberlist,
                    "@AddSameEntry", addSameEntry,
                    "@IsForeignCurrency" , false,
                    "@BudgetChapterCode", budgetChapterCode,
                    "@pBudgetSubKindItemCode", budgetSubKindItemCode,
                    "@pIsSummarySource",isSummaryBudgetSource,
                    "@pSummaryBudgetChapter", isSummaryBudgetChapter,
                    "@pSummaryBudgetSubKindItem", summaryBudgetSubKindItem,
                    "@pIsPrintMonth13", isPrintMonth13,
                    "@pIsPrintAllYearAndMonth13", isPrintAllYearAndMonth13

                };
            return Db.ReadList(sql, true, makeS03H, parms);

        }
      
    }
}
