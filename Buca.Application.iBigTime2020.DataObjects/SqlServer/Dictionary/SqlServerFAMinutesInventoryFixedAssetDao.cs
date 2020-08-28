/***********************************************************************
 * <copyright file="SqlServerFAMinutesInventoryFixedAssetDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    public class SqlServerFAMinutesInventoryFixedAssetDao : IFAMinutesInventoryFixedAssetDao
    {
        /// <summary>
        /// Gets the fa minutes inventory fixed assets.
        /// </summary>
        /// <returns>IList&lt;FAMinutesInventoryFixedAssetEntity&gt;.</returns>
        public IList<FAMinutesInventoryFixedAssetEntity> GetFAMinutesInventoryFixedAssets()
        {
            const string procedures = @"uspGet_All_FAMinutesInventoryFixedAsset";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the fa minutes inventory fixed asset.
        /// </summary>
        /// <param name="minutesInventoryFixedAsset">The minutesInventoryFixedAsset.</param>
        /// <returns>System.String.</returns>
        public string InsertFAMinutesInventoryFixedAsset(FAMinutesInventoryFixedAssetEntity minutesInventoryFixedAsset)
        {
            const string sql = @"uspInsert_FAMinutesInventoryFixedAsset";
            return Db.Insert(sql, true, Take(minutesInventoryFixedAsset));
        }

        /// <summary>
        /// Updates the fa minutes inventory fixed asset.
        /// </summary>
        /// <param name="minutesInventoryFixedAsset">The minutesInventoryFixedAsset.</param>
        /// <returns>System.String.</returns>
        public string UpdateFAMinutesInventoryFixedAsset(FAMinutesInventoryFixedAssetEntity minutesInventoryFixedAsset)
        {
            const string sql = @"uspUpdate_FAMinutesInventoryFixedAsset";
            return Db.Update(sql, true, Take(minutesInventoryFixedAsset));
        }

        /// <summary>
        /// Deletes the fa minutes inventory fixed asset.
        /// </summary>
        /// <param name="minutesInventoryFixedAsset">The minutesInventoryFixedAsset.</param>
        /// <returns>System.String.</returns>
        public string DeleteFAMinutesInventoryFixedAsset(FAMinutesInventoryFixedAssetEntity minutesInventoryFixedAsset)
        {
            const string sql = @"uspDelete_FAMinutesInventoryFixedAsset";
            return Db.Delete(sql, true);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FAMinutesInventoryFixedAssetEntity> Make = reader =>
            new FAMinutesInventoryFixedAssetEntity
            {
                FullName = reader["FullName"].AsString(),
                Representation = reader["Representation"].AsString(),
                Role = reader["Role"].AsString(),
                Title = reader["Title"].AsString()
            };

        private static object[] Take(FAMinutesInventoryFixedAssetEntity minutesInventoryFixedAsset)
        {
            return new object[]  
            {
                "@FullName", minutesInventoryFixedAsset.FullName,
                "@Representation", minutesInventoryFixedAsset.Representation,
                "@Role", minutesInventoryFixedAsset.Role,
                "@Title", minutesInventoryFixedAsset.Title
            };
        }
    }
}
