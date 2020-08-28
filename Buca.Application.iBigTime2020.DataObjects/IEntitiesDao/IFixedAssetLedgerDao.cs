/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: December 06, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    06/12/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using System;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao
{
    /// <summary>
    /// IFixedAssetLedgerDao
    /// </summary>
    public interface IFixedAssetLedgerDao
    {
        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        FixedAssetLedgerEntity GetFixedAssetLedgerByRefId(string refId, int refTypeId);

        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        FixedAssetLedgerEntity GetFixedAssetLedgerByFixedAssetId(string fixedAssetId, int refTypeId);

        /// <summary>
        /// Gets the fixed asset ledger by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        //List<FixedAssetLedgerEntity> GetFixedAssetLedgerByFixedAssetId(string fixedAssetId);

        List<FixedAssetLedgerEntity> GetFixedAssetLedger_ByFixedAssetId(string fixedAssetId);

        /// <summary>
        /// Posts the fixed asset get lasted information for post by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="reftype">The reftype.</param>
        /// <param name="isForceGetOnLedger">if set to <c>true</c> [is force get on ledger].</param>
        /// <returns></returns>
        List<FixedAssetLedgerEntity> PostFixedAsset_GetLastedInfoForPost_ByFixedAssetId(string fixedAssetId, DateTime postedDate, int reftype, bool isForceGetOnLedger,string refId = null);

        /// <summary>
        /// Inserts the fixed asset ledger.
        /// </summary>
        /// <param name="fixedAssetLedger">The fixed asset ledger.</param>
        /// <returns></returns>
        string InsertFixedAssetLedger(FixedAssetLedgerEntity fixedAssetLedger);

        /// <summary>
        /// Deletes the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        string DeleteFixedAssetLedgerByRefId(string refId, int refTypeId);

        /// <summary>
        /// Deletes the fixed asset ledger by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        string DeleteFixedAssetLedgerByFixedAssetId(string fixedAssetId, int refTypeId);
    }
}
