/***********************************************************************
 * <copyright file="IJournalEntryAccountDao.cs" company="BUCA JSC">
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
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao
{
    /// <summary>
    /// IJournalEntryAccountDao
    /// </summary>
    public interface IOriginalGeneralLedgerDao
    {
        /// <summary>
        /// Inserts the general ledger.
        /// </summary>
        /// <param name="generalLedgerEntity">The general ledger entity.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        string InsertOriginalGeneralLedger(OriginalGeneralLedgerEntity generalLedgerEntity);

        /// <summary>
        /// Gets the search voucher.
        /// </summary>
        /// <param name="FromDate">From date.</param>
        /// <param name="ToDate">To date.</param>
        /// <param name="Refno">The refno.</param>
        /// <param name="DepartmentCode">The department code.</param>
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
        /// <param name="projectID">The project identifier.</param>
        /// <param name="contractID">The project identifier.</param>

        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        List<OriginalGeneralLedgerEntity> GetSearchVoucher(string FromDate, string ToDate, string Refno, string DepartmentCode, string debitaccount, string credittaccount, string amountOCFrom, string amountOCTo,
            string budgechaptercode, string budgetSourceCode, string budgetItemCode, string inventoryitemid, string reftypeid, string currencycode, string amountExchange, string cashWithDrawTypeID
            , string methodDistributeID, string budgetSubKindItemCode, string accountingObjectID, string accountingObjectCode, string fixedAssetCode, string activityID,
            string bankID, string projectID,string contractID, string whereClause);

        /// <summary>
        /// Gets the search voucher.
        /// </summary>
        /// <param name="whereClause">The where clause.</param>
        /// <returns></returns>
        List<OriginalGeneralLedgerEntity> GetSearchVoucher(string whereClause);

        /// <summary>
        /// Deletes the general ledger.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string DeleteOriginalGeneralLedger(string refId);

        string DeleteOriginalGeneralLedgerByRefTypeRefNo(string reftype, string refno);
    }
}
