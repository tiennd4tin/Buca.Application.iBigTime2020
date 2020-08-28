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

using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory
{
    /// <summary>
    /// IJournalEntryAccountDao
    /// </summary>
    public interface IInventoryLedgerDao
    {
        /// <summary>
        /// Inserts the inventory ledger.
        /// </summary>
        /// <param name="inventoryLedgerEntity">The inventory ledger entity.</param>
        /// <returns></returns>
        string InsertInventoryLedger(InventoryLedgerEntity inventoryLedgerEntity);

        /// <summary>
        /// Deletes the general ledger.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteInventoryLedger(string refId);

        /// <summary>
        /// Deletes the inventory ledger.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns></returns>
        string DeleteInventoryLedger(string accountNumber, int refType);
    }
}
