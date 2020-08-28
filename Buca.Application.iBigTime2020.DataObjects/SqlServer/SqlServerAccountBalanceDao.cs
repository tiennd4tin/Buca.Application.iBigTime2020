/***********************************************************************
 * <copyright file="SqlServerAccountBalanceDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataHelpers;
using System.Data;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer
{
    /// <summary>
    /// SqlServerAccountBalanceDao
    /// </summary>
    public class SqlServerAccountBalanceDao : IAccountBalanceDao
    {
        /// <summary>
        /// Gets the accountBalance.
        /// </summary>
        /// <param name="accountBalanceId">The accountBalance identifier.</param>
        /// <returns></returns>
        public AccountBalanceEntity GetAccountBalance(int accountBalanceId)
        {
            const string sql = @"uspGet_AccountBalance_ByID";

            object[] parms = { "@AccountBalanceId", accountBalanceId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the account balance by account number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns></returns>
        public AccountBalanceEntity GetAccountBalanceByAccountNumber(string accountNumber)
        {
            const string sql = @"uspGet_AccountBalance_ByAccountNumber";

            object[] parms = { "@AccountNumber", accountNumber };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the exits account balance.
        /// </summary>
        /// <param name="accountBalance">The account balance.</param>
        /// <returns></returns>
        public AccountBalanceEntity GetExitsAccountBalance(AccountBalanceEntity accountBalance)
        {
            const string sql = @"uspCheckExist_AccountBalance";

            object[] parms = { "@AccountNumber", accountBalance.AccountNumber,
                               "@BalanceDate", accountBalance.BalanceDate,
                               "@CurrencyCode", accountBalance.CurrencyCode,
                               "@BudgetSourceID", accountBalance.BudgetSourceId,
                               "@BudgetChapterCode", accountBalance.BudgetChapterCode,
                               "@BudgetKindItemCode", accountBalance.BudgetKindItemCode,
                               "@BudgetSubKindItemCode", accountBalance.BudgetSubKindItemCode,
                               "@BudgetItemCode", accountBalance.BudgetItemCode,
                               "@BudgetSubItemCode", accountBalance.BudgetSubItemCode,
                               "@MethodDistributeID", accountBalance.MethodDistributeId,
                               "@AccountingObjectID", accountBalance.AccountingObjectId,
                               "@ActivityID", accountBalance.ActivityId,
                               "@ProjectID", accountBalance.ProjectId,
                               "@ProjectActivityID",accountBalance.ProjectActivityId,
                               "@ProjectExpenseID", accountBalance.ProjectExpenseId,
                               "@FundID",accountBalance.FundId,
                               "@TaskID",accountBalance.TaskId,
                               "@BankID",accountBalance.BankAccount
                             };

            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the account balance.
        /// </summary>
        /// <param name="accountBalance">The account balance.</param>
        /// <returns></returns>
        public string InsertAccountBalance(AccountBalanceEntity accountBalance)
        {
            const string sql = @"uspInsert_AccountBalance";
            return Db.Insert(sql, true, Take(accountBalance));
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="accountBalance">The journal entry account.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(AccountBalanceEntity accountBalance)
        {
            const string sql = @"uspUpdate_AccountBalance";
            return Db.Update(sql, true, Take(accountBalance));
        }

        /// <summary>
        /// Updates the account balance for existed.
        /// </summary>
        /// <param name="accountBalance">The account balance.</param>
        /// <returns></returns>
        public string UpdateAccountBalanceForExisted(AccountBalanceEntity accountBalance)
        {
            const string sql = @"uspUpdate_AccountBalance_ForExisted";
            return Db.Update(sql, true, TakeUpdate(accountBalance));
        }

        /// <summary>
        /// Deletes the account balance.
        /// </summary>
        /// <param name="accountBalanceId">The account balance identifier.</param>
        /// <returns></returns>
        public string DeleteAccountBalance(string accountBalanceId)
        {
            const string sql = @"uspDelete_AccountBalance";

            object[] parms = { "@AccountBalanceID", accountBalanceId };
            return Db.Delete(sql, true, parms);
        }
        /// <summary>
        /// Deletes the account balance.
        /// </summary>
        /// <returns></returns>
        public string DeleteAccountBalance()
        {
            const string sql = @"uspDelete_AccountBalance_SumAmountNull";
            return Db.Delete(sql, true);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, AccountBalanceEntity> Make = reader =>
            new AccountBalanceEntity
            {
                AccountBalanceId = reader["AccountBalanceID"].AsGuid().AsString(),
                AccountNumber = reader["AccountNumber"].AsString(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                BalanceDate = reader["BalanceDate"].AsDateTime(),
                MovementDebitAmountOC = reader["MovementDebitAmountOC"].AsDecimal(),
                MovementDebitAmount = reader["MovementDebitAmount"].AsDecimal(),
                MovementCreditAmountOC = reader["MovementCreditAmountOC"].AsDecimal(),
                MovementCreditAmount = reader["MovementCreditAmount"].AsDecimal(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                MethodDistributeId = reader["MethodDistributeID"].AsInt(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                ActivityId = reader["ActivityID"].AsString(),
                ProjectId = reader["ProjectID"].AsString(),
                ProjectActivityId = reader["ProjectActivityID"].AsString(),
                ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
                FundId = reader["FundID"].AsString(),
                TaskId = reader["TaskID"].AsString(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                BankAccount = reader["BankAccount"].AsString(),
                FundStructureId = reader["FundStructureID"].AsString(),
            };

        /// <summary>
        /// Takes the specified account balance.
        /// </summary>
        /// <param name="accountBalance">The account balance.</param>
        /// <returns></returns>
        private static object[] Take(AccountBalanceEntity accountBalance)
        {
            return new object[]  
            {
                @"AccountBalanceID", accountBalance.AccountBalanceId,
                @"AccountNumber", accountBalance.AccountNumber,
                @"CurrencyCode", accountBalance.CurrencyCode,
                @"ExchangeRate", accountBalance.ExchangeRate,
                @"BalanceDate", accountBalance.BalanceDate,
                @"MovementDebitAmountOC", accountBalance.MovementDebitAmountOC,
                @"MovementDebitAmount", accountBalance.MovementDebitAmount,
                @"MovementCreditAmountOC", accountBalance.MovementCreditAmountOC,
                @"MovementCreditAmount", accountBalance.MovementCreditAmount,
                @"BudgetSourceID", accountBalance.BudgetSourceId,
                @"BudgetChapterCode", accountBalance.BudgetChapterCode,
                @"BudgetKindItemCode", accountBalance.BudgetKindItemCode,
                @"BudgetSubKindItemCode", accountBalance.BudgetSubKindItemCode,
                @"BudgetItemCode", accountBalance.BudgetItemCode,
                @"BudgetSubItemCode", accountBalance.BudgetSubItemCode,
                @"BudgetDetailItemCode", accountBalance.BudgetDetailItemCode,
                @"MethodDistributeID", accountBalance.MethodDistributeId,
                @"AccountingObjectID", accountBalance.AccountingObjectId,
                @"ActivityID", accountBalance.ActivityId,
                @"ProjectID", accountBalance.ProjectId,
                @"ProjectActivityID", accountBalance.ProjectActivityId,
                @"ProjectExpenseID", accountBalance.ProjectExpenseId,
                @"FundID", accountBalance.FundId,
                @"TaskID", accountBalance.TaskId,
                @"BankAccount", accountBalance.BankAccount,
                @"FundStructureID", accountBalance.FundStructureId
            };
        }

        /// <summary>
        /// Takes the specified account balance.
        /// </summary>
        /// <param name="accountBalance">The account balance.</param>
        /// <returns></returns>
        private static object[] TakeUpdate(AccountBalanceEntity accountBalance)
        {
            return new object[]  
            {
                @"AccountBalanceID", accountBalance.AccountBalanceId,
                @"AccountNumber", accountBalance.AccountNumber,
                @"CurrencyCode", accountBalance.CurrencyCode,
                @"ExchangeRate", accountBalance.ExchangeRate,
                @"MovementDebitAmountOC", accountBalance.MovementDebitAmountOC,
                @"MovementDebitAmount", accountBalance.MovementDebitAmount,
                @"MovementCreditAmountOC", accountBalance.MovementCreditAmountOC,
                @"MovementCreditAmount", accountBalance.MovementCreditAmount
            };
        }
    }
}