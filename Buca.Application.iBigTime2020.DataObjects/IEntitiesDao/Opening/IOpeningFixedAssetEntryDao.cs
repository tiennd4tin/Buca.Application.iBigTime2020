using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening
{
    public interface IOpeningFixedAssetEntryDao
    {
        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <returns></returns>
        List<OpeningFixedAssetEntryEntity> GetOpeningAccountEntries();

        /// <summary>
        /// Gets the opening account entry entity by account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <param name="refId"> </param>
        /// <returns></returns>
        List<OpeningFixedAssetEntryEntity> GetOpeningFixedAssetEntryEntityByAccountCode(string accountCode);

        OpeningFixedAssetEntryEntity GetOpeningFixedAssetEntry(long refId);
        /// <summary>
        /// Inserts the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        string InsertOpeningFixedAssetEntry(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity);

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        string UpdateOpeningFixedAssetEntry(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity);

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        string DeleteOpeningFixedAssetEntry(string refId);

        /// <summary>
        /// Deletes the opening fixed asset entry by reference fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteOpeningFixedAssetEntryByRefFixedAssetId(string fixedAssetId);

        /// <summary>
        /// Deletes the opening account entry detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteOpeningFixedAssetEntryByRefId(long refId);
    }
}
