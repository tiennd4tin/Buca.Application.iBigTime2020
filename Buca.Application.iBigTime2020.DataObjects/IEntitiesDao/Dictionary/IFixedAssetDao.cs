/***********************************************************************
 * <copyright file="IFixedAsset.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, February 27, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IFixedAssetDao
    /// </summary>
    public interface IFixedAssetDao
    {
        /// <summary>
        /// Gets the fixed asset on fixed asset increment.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetOnFixedAssetIncrement(int fixedAssetId);

        /// <summary>
        /// Gets the fixed asset by code.
        /// </summary>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetByCode(string fixedAssetCode);

        /// <summary>
        /// Gets the fixed asset by identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetById(string fixedAssetId);

        /// <summary>
        /// Gets the fixed asset activity by identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        List<FixedAssetActivityEntity>  GetFixedAssetActivityById(string fixedAssetId);

        /// <summary>
        /// Gets the fixed assets by code.
        /// </summary>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <returns></returns>
        List<FixedAssetEntity> GetFixedAssetsByCode(string fixedAssetCode);

        /// <summary>
        /// Gets the fixed assets by fixed asset category code.
        /// </summary>
        /// <param name="fixedAssetCategoryCode">The fixed asset category code.</param>
        /// <returns></returns>
        List<FixedAssetEntity> GetFixedAssetsByFixedAssetCategoryCode(string fixedAssetCategoryCode);

        /// <summary>
        /// Gets the fixed assets by fixed asset TMDT.
        /// </summary>
        /// <param name="yearPosted">The year posted.</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        List<FixedAssetEntity> GetFixedAssetsByFixedAssetTMDT(int yearPosted);

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, int refTypeId);

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetOpening(int fixedAssetId);

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, string currencyCode, DateTime postedDate);

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, string currencyCode, int refTypeId);

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAsset(int fixedAssetId);

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetRemainingQuantity(int fixedAssetId);

        /// <summary>
        /// Gets all fixed assets with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <returns></returns>
        List<FixedAssetEntity> GetAllFixedAssetsWithStoreProdure(string storeProdure);

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <returns></returns>
        List<FixedAssetEntity> GetFixedAssets();

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<FixedAssetEntity> GetFixedAssetsByActive(bool isActive);
        List<FixedAssetEntity> GetFixedAssetsActiveDecre(bool isActive, string refId);

        /// <summary>
        /// Gets the fixed assets for decrement.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        List<FixedAssetEntity> GetFixedAssetsForDecrement(bool isActive, DateTime refDate);

        /// <summary>
        /// Gets the fixed assets for decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="isForceGetOnLedger">if set to <c>true</c> [is force get on ledger].</param>
        /// <returns></returns>
        List<FixedAssetEntity> GetFixedAssetsForAdjustment(string fixedAssetId, DateTime postedDate, int refType,
            bool isForceGetOnLedger);

        /// <summary>
        /// Gets the fixed assets by increment.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        List<FixedAssetEntity> GetFixedAssetsByIncrement(string fixedAssetId);

        /// <summary>
        /// Gets the fixed assets by fixed asset category identifier.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns></returns>
        List<FixedAssetEntity> GetFixedAssetsByFixedAssetCategoryId(int fixedAssetCategoryId);

        /// <summary>
        /// Inserts the fixed asset category.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset category.</param>
        /// <returns></returns>
        string InsertFixedAsset(FixedAssetEntity fixedAsset);

        /// <summary>
        /// Updates the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns></returns>
        string UpdateFixedAsset(FixedAssetEntity fixedAsset);

        /// <summary>
        /// Deletes the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns></returns>
        string DeleteFixedAsset(FixedAssetEntity fixedAsset);
        string DeleteFixedAssetConvert( );

        /// <summary>
        /// Deletes the fixed asset activity.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns></returns>
        string DeleteFixedAssetActivity(FixedAssetEntity fixedAsset);

        /// <summary>
        /// Inserts the fixed asset activity.
        /// </summary>
        /// <param name="fixedAssetActivity">The fixed asset activity.</param>
        /// <returns></returns>
        string InsertFixedAssetActivity(FixedAssetActivityEntity fixedAssetActivity);

        /// <summary>
        /// Gets the fixed asset voucher attach by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        List<FixedAssetVoucherAttachEntity> GetFixedAssetVoucherAttachByFixedAssetId(string fixedAssetId);
    }
}
