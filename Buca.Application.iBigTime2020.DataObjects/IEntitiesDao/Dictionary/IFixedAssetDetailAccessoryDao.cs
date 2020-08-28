using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    public interface IFixedAssetDetailAccessoryDao
    {
        /// <summary>
        /// Gets the fixed asset by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        List<FixedAssetDetailAccessoryEntity> GetFixedAssetByFixedAssetId(string fixedAssetId);

        /// <summary>
        /// Inserts the fixed asset detail accessory.
        /// </summary>
        /// <param name="fixedAssetDetailAccessory">The fixed asset detail accessory.</param>
        /// <returns></returns>
        string InsertFixedAssetDetailAccessory(FixedAssetDetailAccessoryEntity fixedAssetDetailAccessory);

        /// <summary>
        /// Updates the fixed asset detail accessory.
        /// </summary>
        /// <param name="fixedAssetDetailAccessory">The fixed asset detail accessory.</param>
        /// <returns></returns>
        string UpdateFixedAssetDetailAccessory(FixedAssetDetailAccessoryEntity fixedAssetDetailAccessory);

        /// <summary>
        /// Deletes the fixed asset detail accessory.
        /// </summary>
        /// <param name="fixedAssetDetailAccessoryId">The fixed asset detail accessory identifier.</param>
        /// <returns></returns>
        string DeleteFixedAssetDetailAccessory(int fixedAssetDetailAccessoryId);

        /// <summary>
        /// Deletes the fixed asset detail accessory by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        string DeleteFixedAssetDetailAccessoryByFixedAssetId(string fixedAssetId);
    }
}
