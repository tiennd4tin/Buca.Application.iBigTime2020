/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao
{
    /// <summary>
    /// ISupplyLedgerDao
    /// </summary>
    public interface ISupplyLedgerDao
    {
        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        SupplyLedgerEntity GetSupplyLedgerByRefId(string refId, int refTypeId);

        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        SupplyLedgerEntity GetSupplyLedgerByInventoryItemId(string inventoryItemId, int refTypeId);

        /// <summary>
        /// Gets the fixed asset ledger by fixed asset identifier.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns></returns>
        List<SupplyLedgerEntity> GetSupplyLedgerByInventoryItemId(string inventoryItemId);
        /// <summary>
        /// Inserts the fixed asset ledger.
        /// </summary>
        /// <param name="supplyLedger">The fixed asset ledger.</param>
        /// <returns></returns>
        string InsertSupplyLedger(SupplyLedgerEntity supplyLedger);

        /// <summary>
        /// Deletes the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        string DeleteSupplyLedgerByRefId(string refId, int refTypeId);

        string DeleteSupplyLedgerByRefId(string refId);


        string DeleteSupplyLedgerByOPN();

        /// <summary>
        /// Deletes the fixed asset ledger by fixed asset identifier.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        string DeleteSupplyLedgerByInventoryItemId(string inventoryItemId, int refTypeId);
    }
}
