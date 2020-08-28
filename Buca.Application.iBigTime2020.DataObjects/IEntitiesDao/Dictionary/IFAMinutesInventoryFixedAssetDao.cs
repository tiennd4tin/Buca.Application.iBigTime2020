/***********************************************************************
 * <copyright file="IFAMinutesInventoryFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IFAMinutesInventoryFixedAssetDao
    /// </summary>
    public interface IFAMinutesInventoryFixedAssetDao
    {
        /// <summary>
        /// Gets the fa minutes inventory fixed assets.
        /// </summary>
        /// <returns>IList&lt;FAMinutesInventoryFixedAssetEntity&gt;.</returns>
        IList<FAMinutesInventoryFixedAssetEntity> GetFAMinutesInventoryFixedAssets();

        /// <summary>
        /// Inserts the fa minutes inventory fixed asset.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns>System.String.</returns>
        string InsertFAMinutesInventoryFixedAsset(FAMinutesInventoryFixedAssetEntity bank);

        /// <summary>
        /// Updates the fa minutes inventory fixed asset.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns>System.String.</returns>
        string UpdateFAMinutesInventoryFixedAsset(FAMinutesInventoryFixedAssetEntity bank);

        /// <summary>
        /// Deletes the fa minutes inventory fixed asset.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns>System.String.</returns>
        string DeleteFAMinutesInventoryFixedAsset(FAMinutesInventoryFixedAssetEntity bank);
    }
}
