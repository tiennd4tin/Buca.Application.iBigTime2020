/***********************************************************************
 * <copyright file="SqlServerJournalEntryAccountDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 20 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Data;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer
{
    /// <summary>
    /// SqlServerJournalEntryAccountDao
    /// </summary>
    public class SqlServerGeneralLedgerDao : DaoBase, IGeneralLedgerDao
    {
        /// <summary>
        /// Inserts the general ledger.
        /// </summary>
        /// <param name="generalLedgerEntity">The general ledger entity.</param>
        /// <returns>System.Int32.</returns>
        public string InsertGeneralLedger(GeneralLedgerEntity generalLedgerEntity)
        {
            const string procedures = @"uspInsert_GeneralLedger";
            return Db.Insert(procedures, true, Take(generalLedgerEntity));
        }

        /// <summary>
        /// Deletes the general ledger.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteGeneralLedger(string refId)
        {
            const string procedures = @"uspDelete_GeneralLedger_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Deletes the general ledger.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns></returns>
        public string DeleteGeneralLedger(string accountNumber, int refType)
        {
            const string procedures = @"uspDelete_GeneralLedger_ByAccountNumberAndRefType";
            object[] parms = { "@AccountNumber", accountNumber, "@RefType", refType };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the main currency identifier from database option.
        /// </summary>
        /// <param name="OptionID">The option identifier.</param>
        /// <returns>System.String.</returns>
        public DataTable GetMainCurrencyIDFromDBOption(string OptionID)
        {
            const string procedures = @"uspGet_DBOption_ByID";
            object[] parms = { "@OptionID", OptionID};
            return Db.ReadDataTable(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, GeneralLedgerEntity> Make = reader =>
         new GeneralLedgerEntity
         {
             GeneralLedgerId = reader["GeneralLedgerID"].AsString(),
             RefId = reader["RefID"].AsString(),
             RefDetailId = reader["RefDetailID"].AsString(),
             RefType = reader["RefType"].AsInt(),
             RefNo = reader["RefNo"].AsString(),
             CurrencyCode = reader["CurrencyCode"].AsString(),
             ExchangeRate = reader["ExchangeRate"].AsDecimal(),
             RefDate = reader["RefDate"].AsDateTime(),
             PostedDate = reader["PostedDate"].AsDateTime(),
             InvNo = reader["InvNo"].AsString(),
             InvDate = reader["InvDate"].AsDateTime(),
             AccountNumber = reader["AccountNumber"].AsString(),
             CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
             DebitAmountOC = reader["DebitAmountOC"].AsDecimal(),
             DebitAmount = reader["DebitAmount"].AsDecimal(),
             CreditAmountOC = reader["CreditAmountOC"].AsDecimal(),
             CreditAmount = reader["CreditAmount"].AsDecimal(),
             JournalMemo = reader["JournalMemo"].AsString(),
             Description = reader["Description"].AsString(),
             BudgetSourceId = reader["BudgetSourceID"].AsString(),
             BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
             BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
             BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
             BudgetItemCode = reader["BudgetItemCode"].AsString(),
             BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
             MethodDistributeId = reader["MethodDistributeID"].AsInt(),
             CashWithDrawTypeId = reader["CashWithDrawTypeID"].AsInt(),
             AccountingObjectId = reader["AccountingObjectID"].AsString(),
             ActivityId = reader["ActivityID"].AsString(),
             ProjectId = reader["ProjectID"].AsString(),
             ListItemId = reader["ListItemID"].AsString(),
             Approved = reader["Approved"].AsBool(),
             BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
             BankId = reader["BankId"].AsString(),
             IsReadjust = reader["IsReadjust"].AsBool(),
             OrgRefNo = reader["OrgRefNo"].AsString(),
             OrgRefDate = reader["OrgRefDate"].AsDateTime(),
             FundStructureId = reader["FundStructureID"].AsString(),
             SortOrder = reader["SortOrder"].AsInt(),
             BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
             BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
             ContractId = reader["ContractID"].AsString(),
             CapitalPlanId = reader["CapitalPlanID"].AsString(),
         };

        /// <summary>
        /// Takes the specified general ledger entity.
        /// </summary>
        /// <param name="generalLedgerEntity">The general ledger entity.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(GeneralLedgerEntity generalLedgerEntity)
        {
            return new object[]
            {
                "@GeneralLedgerID", generalLedgerEntity.GeneralLedgerId,
                "@RefID", generalLedgerEntity.RefId,
                "@RefDetailID", generalLedgerEntity.RefDetailId,
                "@RefType", generalLedgerEntity.RefType,
                "@RefNo", generalLedgerEntity.RefNo,
                "@CurrencyCode", generalLedgerEntity.CurrencyCode,
                "@ExchangeRate", generalLedgerEntity.ExchangeRate,
                "@RefDate", generalLedgerEntity.RefDate,
                "@PostedDate", generalLedgerEntity.PostedDate,
                "@InvNo", generalLedgerEntity.InvNo,
                "@InvDate", generalLedgerEntity.InvDate,
                "@AccountNumber", generalLedgerEntity.AccountNumber,
                "@CorrespondingAccountNumber", generalLedgerEntity.CorrespondingAccountNumber,
                "@DebitAmountOC", generalLedgerEntity.DebitAmountOC,
                "@DebitAmount", generalLedgerEntity.DebitAmount,
                "@CreditAmountOC", generalLedgerEntity.CreditAmountOC,
                "@CreditAmount", generalLedgerEntity.CreditAmount,
                "@JournalMemo", generalLedgerEntity.JournalMemo,
                "@Description", generalLedgerEntity.Description,
                "@BudgetSourceID", generalLedgerEntity.BudgetSourceId,
                "@BudgetChapterCode", generalLedgerEntity.BudgetChapterCode,
                "@BudgetKindItemCode", generalLedgerEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", generalLedgerEntity.BudgetSubKindItemCode,
                "@BudgetItemCode", generalLedgerEntity.BudgetItemCode,
                "@BudgetSubItemCode", generalLedgerEntity.BudgetSubItemCode,
                "@MethodDistributeID", generalLedgerEntity.MethodDistributeId,
                "@CashWithDrawTypeID", generalLedgerEntity.CashWithDrawTypeId,
                "@AccountingObjectID", generalLedgerEntity.AccountingObjectId,
                "@ActivityID", generalLedgerEntity.ActivityId,
                "@ProjectID", generalLedgerEntity.ProjectId,
                "@ListItemID", generalLedgerEntity.ListItemId,
                "@Approved", generalLedgerEntity.Approved,
                "@BudgetDetailItemCode", generalLedgerEntity.BudgetDetailItemCode,
                "@BankId", generalLedgerEntity.BankId,
                "@IsReadjust", generalLedgerEntity.IsReadjust,
                "@OrgRefNo", generalLedgerEntity.OrgRefNo,
                "@OrgRefDate", generalLedgerEntity.OrgRefDate,
                "@FundStructureID", generalLedgerEntity.FundStructureId,
                "@SortOrder", generalLedgerEntity.SortOrder,
                "@BudgetProvideCode", generalLedgerEntity.BudgetProvideCode,
                "@BudgetExpenseID",generalLedgerEntity.BudgetExpenseId,
                "@ContractID", generalLedgerEntity.ContractId,
                "@CapitalPlanID", generalLedgerEntity.CapitalPlanId,
            };
        }
    }
}
