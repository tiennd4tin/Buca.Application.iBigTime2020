using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    public class SqlServerFixedAssetDetailAccessoryDao : IFixedAssetDetailAccessoryDao
    {
        /// <summary>
        /// Gets the fixed asset by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public List<FixedAssetDetailAccessoryEntity> GetFixedAssetByFixedAssetId(string fixedAssetId)
        {
            object[] parms = { "@FixedAssetID", fixedAssetId };
            const string sql = @"uspGet_FixedAssetDetailAccessory_ByFixedAssetId";
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the fixed asset detail accessory.
        /// </summary>
        /// <param name="fixedAssetDetailAccessory">The fixed asset detail accessory.</param>
        /// <returns></returns>
        public string InsertFixedAssetDetailAccessory(FixedAssetDetailAccessoryEntity fixedAssetDetailAccessory)
        {
            const string sql = "uspInsert_FixedAssetDetailAccessory";
            return Db.Insert(sql, true, Take(fixedAssetDetailAccessory));
        }

        /// <summary>
        /// Updates the fixed asset detail accessory.
        /// </summary>
        /// <param name="fixedAssetDetailAccessory">The fixed asset detail accessory.</param>
        /// <returns></returns>
        public string UpdateFixedAssetDetailAccessory(FixedAssetDetailAccessoryEntity fixedAssetDetailAccessory)
        {
            const string sql = "uspUpdate_FixedAssetDetailAccessory";
            return Db.Insert(sql, true, Take(fixedAssetDetailAccessory));
        }

        /// <summary>
        /// Deletes the fixed asset detail accessory.
        /// </summary>
        /// <param name="fixedAssetDetailAccessoryId">The fixed asset detail accessory identifier.</param>
        /// <returns></returns>
        public string DeleteFixedAssetDetailAccessory(int fixedAssetDetailAccessoryId)
        {
            const string sql = @"uspDelete_FixedAssetDetailAccessory";
            object[] parms = { "@FixedAssetDetailAccessoryID", fixedAssetDetailAccessoryId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Deletes the fixed asset detail accessory by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public string DeleteFixedAssetDetailAccessoryByFixedAssetId(string fixedAssetId)
        {
            const string sql = @"uspDelete_FixedAssetDetailAccessory_ByFixedAssetID";
            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetDetailAccessoryEntity> Make = reader =>
            new FixedAssetDetailAccessoryEntity
            {
                FixedAssetDetailAccessoryId = reader["FixedAssetDetailAccessoryID"].AsInt(),
                FixedAssetId = reader["FixedAssetID"].AsString(),
                Description = reader["Description"].AsString(),
                Unit = reader["Unit"].AsString(),
                Quantity = reader["Quantity"].AsDecimal(),
                Amount = reader["Amount"].AsDecimal(),
                SortOrder = reader["SortOrder"].AsInt()
            };

        /// <summary>
        /// Takes the specified fixed asset detail accessory entity.
        /// </summary>
        /// <param name="entity">The fixed asset detail accessory entity.</param>
        /// <returns></returns>
        private static object[] Take(FixedAssetDetailAccessoryEntity entity)
        {
            return new object[]
            {

                "@FixedAssetDetailAccessoryID", entity.FixedAssetDetailAccessoryId,
                "@FixedAssetID", entity.FixedAssetId,
                "@Description", entity.Description,
                "@Unit", entity.Unit,
                "@Quantity", entity.Quantity,
                "@Amount", entity.Amount,
                "@SortOrder", entity.SortOrder
            };
        }

    }
}
