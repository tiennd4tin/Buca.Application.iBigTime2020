/***********************************************************************
 * <copyright file="SqlServerOpeningAccountEntryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using Buca.Application.iBigTime2020.DataHelpers;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Opening
{
    /// <summary>
    /// SqlServerOpeningAccountEntryDao
    /// </summary>
    public class SqlServerOpeningAccountEntryDao : IOpeningAccountEntryDao
    {
        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <returns></returns>
        public List<OpeningAccountEntryEntity> GetOpeningAccountEntries()
        {
            const string procedures = @"uspGet_All_OpeningAccountEntry";
            return Db.ReadList(procedures, true, MakeList);
        }
        public List<OpeningAccountEntryEntity> GetOpeningAccountEntriesConvert()
        {
            const string procedures = @"uspGet_All_OpeningAccountEntryConvert";
            return Db.ReadList(procedures, true, MakeListConvert);
        }

        /// <summary>
        /// Gets the opening account entry entity by account code.
        /// </summary>
        /// <param name="accountNumber">The account code.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<OpeningAccountEntryEntity> GetOpeningAccountEntriesByAccountNumber(string accountNumber)
        {
            const string procedures = @"uspGet_OpeningAccountEntry_ByAccountCode";

            object[] parms = { "@AccountCode", accountNumber };
            return Db.ReadList(procedures, true, Make,parms);
        }

        /// <summary>
        /// Inserts the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        public string InsertOpeningAccountEntry(OpeningAccountEntryEntity openingAccountEntryEntity)
        {
            const string procedures = @"uspInsert_OpeningAccountEntry";
            return Db.Insert(procedures, true, Take(openingAccountEntryEntity));
        }

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        public string UpdateOpeningAccountEntry(OpeningAccountEntryEntity openingAccountEntryEntity)
        {
            const string sql = @"uspUpdate_OpeningAccountEntry";
            return Db.Update(sql, true, Take(openingAccountEntryEntity));
        }

        public string DeleteOpeningAccountEntryByAccountNumber(string accountnumber)
        {
            const string procedures = @"uspDelete_OpeningAccountEntry_ByAccountNumber";
            object[] parms = { "@AccountNumber", accountnumber };
            return Db.Delete(procedures, true, parms);
        }


        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningAccountEntryEntity> Make = reader =>
            new OpeningAccountEntryEntity
            {
                RefId = reader["RefID"].AsString(),
                RefType = reader["RefType"].AsInt(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                CurrencyId = reader["CurrencyID"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                AccountNumber = reader["AccountNumber"].AsString(),
                AccountName = reader["AccountName"].AsString(),
                AccBeginningDebitAmountOC = reader["AccBeginningDebitAmountOC"].AsDecimal(),
                AccBeginningDebitAmount = reader["AccBeginningDebitAmount"].AsDecimal(),
                AccBeginningCreditAmountOC = reader["AccBeginningCreditAmountOC"].AsDecimal(),
                AccBeginningCreditAmount = reader["AccBeginningCreditAmount"].AsDecimal(),
                DebitAmountOC = reader["DebitAmountOC"].AsDecimal(),
                DebitAmount = reader["DebitAmount"].AsDecimal(),
                CreditAmountOC = reader["CreditAmountOC"].AsDecimal(),
                CreditAmount = reader["CreditAmount"].AsDecimal(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                MethodDistributeId = reader["MethodDistributeID"].AsInt(),
                CashWithdrawTypeId = reader["CashWithdrawTypeID"].AsInt(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                ActivityId = reader["ActivityID"].AsString(),
                ProjectId = reader["ProjectID"].AsString(),
                TaskId = reader["TaskID"].AsString(),
                BankId = reader["BankID"].AsString(),
                Approved = reader["Approved"].AsBool(),
                SortOrder = reader["SortOrder"].AsInt(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                ProjectActivityId = reader["ProjectActivityID"].AsString(),
                ApprovedDate = reader["ApprovedDate"].AsDateTime(),
                FundStructureId = reader["FundStructureID"].AsString(),
                ProjectActivityEAID = reader["ProjectActivityEAID"].AsString(),
                BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
                AccountId = reader["AccountId"].AsString(),
                ParentId = reader["ParentId"].AsString(),
                BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
                ContractId = reader["ContractID"].AsString(),
                CapitalPlanId = reader["CapitalPlanID"].AsString(),
            };

        /// <summary>
        /// Takes the specified opening account entry.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry.</param>
        /// <returns></returns>
        private static object[] Take(OpeningAccountEntryEntity openingAccountEntryEntity)
        {
            return new object[]  
            {
            "@RefID",openingAccountEntryEntity.RefId,
            "@RefType",openingAccountEntryEntity.RefType,
            "@PostedDate",openingAccountEntryEntity.PostedDate,
            "@CurrencyID",openingAccountEntryEntity.CurrencyId,
            "@ExchangeRate",openingAccountEntryEntity.ExchangeRate,
            "@AccountNumber",openingAccountEntryEntity.AccountNumber,
            "@AccBeginningDebitAmountOC",openingAccountEntryEntity.AccBeginningDebitAmountOC,
            "@AccBeginningDebitAmount",openingAccountEntryEntity.AccBeginningDebitAmount,
            "@AccBeginningCreditAmountOC",openingAccountEntryEntity.AccBeginningCreditAmountOC,
            "@AccBeginningCreditAmount",openingAccountEntryEntity.AccBeginningCreditAmount,
            "@DebitAmountOC",openingAccountEntryEntity.DebitAmountOC,
            "@DebitAmount",openingAccountEntryEntity.DebitAmount,
            "@CreditAmountOC",openingAccountEntryEntity.CreditAmountOC,
            "@CreditAmount",openingAccountEntryEntity.CreditAmount,
            "@BudgetSourceId",openingAccountEntryEntity.BudgetSourceId,
            "@BudgetChapterCode",openingAccountEntryEntity.BudgetChapterCode,
            "@BudgetKindItemCode",openingAccountEntryEntity.BudgetKindItemCode,
            "@BudgetSubKindItemCode",openingAccountEntryEntity.BudgetSubKindItemCode,
            "@BudgetItemCode",openingAccountEntryEntity.BudgetItemCode,
            "@BudgetSubItemCode",openingAccountEntryEntity.BudgetSubItemCode,
            "@MethodDistributeId",openingAccountEntryEntity.MethodDistributeId,
            "@CashWithdrawTypeId",openingAccountEntryEntity.CashWithdrawTypeId,
            "@AccountingObjectId",openingAccountEntryEntity.AccountingObjectId,
            "@ActivityId",openingAccountEntryEntity.ActivityId,
            "@ProjectId",openingAccountEntryEntity.ProjectId,
            "@TaskId",openingAccountEntryEntity.TaskId,
            "@BankId",openingAccountEntryEntity.BankId,
            "@Approved",openingAccountEntryEntity.Approved,
            "@SortOrder",openingAccountEntryEntity.SortOrder,
            "@BudgetDetailItemCode",openingAccountEntryEntity.BudgetDetailItemCode,
            "@ProjectActivityId",openingAccountEntryEntity.ProjectActivityId,
            "@ApprovedDate",openingAccountEntryEntity.ApprovedDate,
            "@FundStructureId",openingAccountEntryEntity.FundStructureId,
            "@ProjectActivityEAID",openingAccountEntryEntity.ProjectActivityEAID,
            "@BudgetProvideCode",openingAccountEntryEntity.BudgetProvideCode,
            "@BudgetExpenseID", openingAccountEntryEntity.BudgetExpenseId,
                "@ContractID", openingAccountEntryEntity.ContractId,
                "@CapitalPlanID", openingAccountEntryEntity.CapitalPlanId,
            };
        }

        private static readonly Func<IDataReader, OpeningAccountEntryEntity> MakeList = reader =>
            new OpeningAccountEntryEntity
            {
                AccountNumber = reader["AccountNumber"].AsString(),
                AccountName = reader["AccountName"].AsString(),
                AccBeginningDebitAmountOC = reader["AccBeginningDebitAmountOC"].AsDecimal(),
                AccBeginningDebitAmount = reader["AccBeginningDebitAmount"].AsDecimal(),
                AccBeginningCreditAmountOC = reader["AccBeginningCreditAmountOC"].AsDecimal(),
                AccBeginningCreditAmount = reader["AccBeginningCreditAmount"].AsDecimal(),
                DebitAmountOC = reader["DebitAmountOC"].AsDecimal(),
                DebitAmount = reader["DebitAmount"].AsDecimal(),
                CreditAmountOC = reader["CreditAmountOC"].AsDecimal(),
                CreditAmount = reader["CreditAmount"].AsDecimal(),
                AccountId = reader["AccountId"].AsString(),
                ParentId = reader["ParentId"].AsString(),
               


            };
        private static readonly Func<IDataReader, OpeningAccountEntryEntity> MakeListConvert = reader =>
            new OpeningAccountEntryEntity
            {
                AccountNumber = reader["AccountNumber"].AsString(),
                RefType =  reader["RefType"].AsInt()
                



            };

    }
}
