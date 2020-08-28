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
using System.Collections.Generic;
using System.Data;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer
{
    /// <summary>
    /// SqlServerJournalEntryAccountDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IOriginalGeneralLedgerDao" />
    public class SqlServerOriginalGeneralLedgerDao : IOriginalGeneralLedgerDao
    {
        /// <summary>
        /// Inserts the general ledger.
        /// </summary>
        /// <param name="generalLedgerEntity">The general ledger entity.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public string InsertOriginalGeneralLedger(OriginalGeneralLedgerEntity generalLedgerEntity)
        {
            const string procedures = @"uspInsert_OriginalGeneralLedger";
            return Db.Insert(procedures, true, Take(generalLedgerEntity));
        }

        /// <summary>
        /// Gets the search voucher.
        /// </summary>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="Refno">The refno.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="debitaccount">The debitaccount.</param>
        /// <param name="credittaccount">The credittaccount.</param>
        /// <param name="amountOCFrom">The amount oc from.</param>
        /// <param name="amountOCTo">The amount oc to.</param>
        /// <param name="budgechaptercode">The budgechaptercode.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="inventoryitemid">The inventoryitemid.</param>
        /// <param name="reftypeid">The reftypeid.</param>
        /// <param name="currencycode">The currencycode.</param>
        /// <param name="amountExchange">The amount exchange.</param>
        /// <param name="cashWithDrawTypeID">The cash with draw type identifier.</param>
        /// <param name="methodDistributeID">The method distribute identifier.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="accountingObjectID">The accounting object identifier.</param>
        /// <param name="accountingObjectCode">The accounting object code.</param>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <param name="activityID">The activity identifier.</param>
        /// <param name="bankID">The bank identifier.</param>
        /// <param name="contractID">The bank identifier.</param>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public List<OriginalGeneralLedgerEntity> GetSearchVoucher(string FromDate, string ToDate, string Refno, string departmentCode, string debitaccount, string credittaccount, string amountOCFrom, string amountOCTo,
            string budgechaptercode, string budgetSourceCode, string budgetItemCode, string inventoryitemid, string reftypeid, string currencycode, string amountExchange, string cashWithDrawTypeID
            , string methodDistributeID, string budgetSubKindItemCode, string accountingObjectID, string accountingObjectCode, string fixedAssetCode, string activityID,
            string bankID, string projectID,string contractID,string whereClause)
        {
            const string procedures = @"[dbo].[GetSearchVoucher]";
            object[] parms ={
                             "@FromDate", FromDate,
                             "@ToDate", ToDate,
                             "@RefNo", Refno,
                             "@DepartmentCode", departmentCode,
                             "@Debitaccount", debitaccount,
                             "@Credittaccount", credittaccount,
                             "@AmountOCFrom", amountOCFrom,
                             "@AmountOCTo", amountOCTo,
                             "@Budgechaptercode", budgechaptercode,
                             "@BudgetSourceCode", budgetSourceCode,
                             "@BudgetItemCode", budgetItemCode,
                             "@Inventoryitemid", inventoryitemid,

                             "@Reftypeid", reftypeid,
                             "@CurrencyCode", currencycode,
                             "@AmountExchange", amountExchange,
                             "@CashWithDrawTypeID", cashWithDrawTypeID,
                             "@MethodDistributeID", methodDistributeID,
                             "@BudgetSubKindItemCode", budgetSubKindItemCode,
                             "@AccountingObjectID", accountingObjectID,
                             "@AccountingObjectCode", accountingObjectCode,
                             "@FixedAssetCode", fixedAssetCode,
                             "@ActivityID", activityID,
                             "@BankID", bankID,
                             "@ProjectID", projectID,
                             "@ContractID", contractID

            };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the search voucher.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        public List<OriginalGeneralLedgerEntity> GetSearchVoucher(string whereClause)
        {
            const string procedures = @"[dbo].[GetSearchVoucher1]";
            object[] parms = { "@WhereClause", whereClause };
            return Db.ReadList(procedures, true, MakeForSearch, parms);
        }

        /// <summary>
        /// The make for search
        /// </summary>
        private static readonly Func<IDataReader, OriginalGeneralLedgerEntity> Make = reader =>
       new OriginalGeneralLedgerEntity
       {
           OriginalGeneralLedgerId = reader["OriginalGeneralLedgerID"].AsString(),
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
           DebitAccount = reader["DebitAccount"].AsString(),
           CreditAccount = reader["CreditAccount"].AsString(),
           AmountOC = reader["AmountOC"].AsDecimal(),
           Amount = reader["Amount"].AsDecimal(),
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
           CreditAccountingObjectId = reader["CreditAccountingObjectID"].AsString(),
           ActivityId = reader["ActivityID"].AsString(),
           ProjectId = reader["ProjectID"].AsString(),
           ProjectActivityId = reader["ProjectActivityID"].AsString(),
           ListItemId = reader["ListItemID"].AsString(),
           PurchasePurposeId = reader["PurchasePurposeID"].AsString(),
           PurchasePurposeCode = reader["PurchasePurposeCode"].AsString(),
           OrgPrice = reader["OrgPrice"].AsDecimal(),
           BankId = reader["BankID"].AsString(),
           BankName = reader["BankName"].AsString(),
           ToBankId = reader["ToBankID"].AsString(),
           Approved = reader["Approved"].AsBool(),
           InvType = reader["InvType"].AsInt(),
           TaxAccount = reader["TaxAccount"].AsString(),
           TaxAmount = reader["TaxAmount"].AsDecimal(),
           BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
           SortOrder = reader["SortOrder"].AsInt(),
           OrgRefNo = reader["OrgRefNo"].AsString(),
           OrgRefDate = reader["OrgRefDate"].AsDateTime(),
           FundStructureId = reader["FundStructureID"].AsString(),
           BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
           DepartmentName = reader["DepartmentID"].AsString(),
           FixedAssetCode = reader["FixedAssetID"].AsString(),
           BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
           ContractId = reader["ContractID"].AsString()
       };

        /// <summary>
        /// The make for search
        /// </summary>
        private static readonly Func<IDataReader, OriginalGeneralLedgerEntity> MakeForSearch = reader =>
       new OriginalGeneralLedgerEntity
       {
           OriginalGeneralLedgerId = reader["OriginalGeneralLedgerID"].AsString(),
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
           DebitAccount = reader["DebitAccount"].AsString(),
           CreditAccount = reader["CreditAccount"].AsString(),
           AmountOC = reader["AmountOC"].AsDecimal(),
           Amount = reader["Amount"].AsDecimal(),
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
           CreditAccountingObjectId = reader["CreditAccountingObjectID"].AsString(),
           ActivityId = reader["ActivityID"].AsString(),
           ProjectId = reader["ProjectID"].AsString(),
           ProjectActivityId = reader["ProjectActivityID"].AsString(),
           ListItemId = reader["ListItemID"].AsString(),
           PurchasePurposeId = reader["PurchasePurposeID"].AsString(),
           PurchasePurposeCode = reader["PurchasePurposeCode"].AsString(),
           OrgPrice = reader["OrgPrice"].AsDecimal(),
           BankId = reader["BankID"].AsString(),
           BankName = reader["BankName"].AsString(),
           ToBankId = reader["ToBankID"].AsString(),
           Approved = reader["Approved"].AsBool(),
           InvType = reader["InvType"].AsInt(),
           TaxAccount = reader["TaxAccount"].AsString(),
           TaxAmount = reader["TaxAmount"].AsDecimal(),
           BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
           SortOrder = reader["SortOrder"].AsInt(),
           OrgRefNo = reader["OrgRefNo"].AsString(),
           OrgRefDate = reader["OrgRefDate"].AsDateTime(),
           FundStructureId = reader["FundStructureID"].AsString(),
           BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
           DepartmentName = reader["DepartmentID"].AsString(),
           FixedAssetCode = reader["FixedAssetID"].AsString(),
           BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
           ContractId = reader["ContractID"].AsString()
       };

        /// <summary>
        /// Deletes the general ledger.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        public string DeleteOriginalGeneralLedger(string refId)
        {
            const string procedures = @"uspDelete_OriginalGeneralLedger_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        public string DeleteOriginalGeneralLedgerByRefTypeRefNo(string reftype, string refno)
        {
            const string procedures = @"uspDelete_OriginalGeneralLedger_ByRefTypeRefNo";
            object[] parms = { "@RefType",  reftype , "@RefNo", refno };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Takes the specified original general ledger entity.
        /// </summary>
        /// <param name="originalGeneralLedgerEntity">The original general ledger entity.</param>
        /// <returns>
        /// System.Object[].
        /// </returns>
        private object[] Take(OriginalGeneralLedgerEntity originalGeneralLedgerEntity)
        {
            return new object[]
            {
                "@OriginalGeneralLedgerID",originalGeneralLedgerEntity.OriginalGeneralLedgerId,
                "@RefID",originalGeneralLedgerEntity.RefId,
                "@RefDetailID",originalGeneralLedgerEntity.RefDetailId,
                "@RefType",originalGeneralLedgerEntity.RefType,
                "@RefNo",originalGeneralLedgerEntity.RefNo,
                "@CurrencyCode",originalGeneralLedgerEntity.CurrencyCode,
                "@ExchangeRate",originalGeneralLedgerEntity.ExchangeRate,
                "@RefDate",originalGeneralLedgerEntity.RefDate,
                "@PostedDate",originalGeneralLedgerEntity.PostedDate,
                "@InvNo",originalGeneralLedgerEntity.InvNo,
                "@InvDate",originalGeneralLedgerEntity.InvDate,
                "@DebitAccount",originalGeneralLedgerEntity.DebitAccount,
                "@CreditAccount",originalGeneralLedgerEntity.CreditAccount,
                "@AmountOC",originalGeneralLedgerEntity.AmountOC,
                "@Amount",originalGeneralLedgerEntity.Amount,
                "@JournalMemo",originalGeneralLedgerEntity.JournalMemo,
                "@Description",originalGeneralLedgerEntity.Description,
                "@BudgetSourceID",originalGeneralLedgerEntity.BudgetSourceId,
                "@BudgetChapterCode",originalGeneralLedgerEntity.BudgetChapterCode,
                "@BudgetKindItemCode",originalGeneralLedgerEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",originalGeneralLedgerEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",originalGeneralLedgerEntity.BudgetItemCode,
                "@BudgetSubItemCode",originalGeneralLedgerEntity.BudgetSubItemCode,
                "@MethodDistributeID",originalGeneralLedgerEntity.MethodDistributeId,
                "@CashWithDrawTypeID",originalGeneralLedgerEntity.CashWithDrawTypeId,
                "@AccountingObjectID",originalGeneralLedgerEntity.AccountingObjectId,
                "@CreditAccountingObjectID",originalGeneralLedgerEntity.CreditAccountingObjectId,
                "@ActivityID",originalGeneralLedgerEntity.ActivityId,
                "@ProjectID",originalGeneralLedgerEntity.ProjectId,
                "@ProjectActivityID",originalGeneralLedgerEntity.ProjectActivityId,
                "@ProjectExpenseID",originalGeneralLedgerEntity.ProjectExpenseId,
                "@ListItemID",originalGeneralLedgerEntity.ListItemId,
                "@PurchasePurposeID",originalGeneralLedgerEntity.PurchasePurposeId,
                "@PurchasePurposeCode",originalGeneralLedgerEntity.PurchasePurposeCode,
                "@OrgPrice",originalGeneralLedgerEntity.OrgPrice,
                "@BankID",originalGeneralLedgerEntity.BankId,
                "@BankName",originalGeneralLedgerEntity.BankName,
                "@ToBankID",originalGeneralLedgerEntity.ToBankId,
                "@Approved",originalGeneralLedgerEntity.Approved,
                "@InvType",originalGeneralLedgerEntity.InvType,
                "@TaxAccount",originalGeneralLedgerEntity.TaxAccount,
                "@TaxAmount",originalGeneralLedgerEntity.TaxAmount,
                "@BudgetDetailItemCode",originalGeneralLedgerEntity.BudgetDetailItemCode,
                "@SortOrder",originalGeneralLedgerEntity.SortOrder,
                "@OrgRefNo",originalGeneralLedgerEntity.OrgRefNo,
                "@OrgRefDate",originalGeneralLedgerEntity.OrgRefDate,
                "@FundStructureID",originalGeneralLedgerEntity.FundStructureId,
                "@BudgetProvideCode",originalGeneralLedgerEntity.BudgetProvideCode,
                "@BudgetExpenseID", originalGeneralLedgerEntity.BudgetExpenseId,
                "@ContractID", originalGeneralLedgerEntity.ContractId
            };
        }
    }
}
