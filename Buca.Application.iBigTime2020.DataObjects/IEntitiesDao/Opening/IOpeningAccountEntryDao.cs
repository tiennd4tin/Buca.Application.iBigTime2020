/***********************************************************************
 * <copyright file="IOpeningAccountEntryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening
{
    /// <summary>
    /// IOpeningAccountEntryDao
    /// </summary>
    public interface IOpeningAccountEntryDao
    {
        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <returns></returns>
        List<OpeningAccountEntryEntity> GetOpeningAccountEntries();
        List<OpeningAccountEntryEntity> GetOpeningAccountEntriesConvert();

        /// <summary>
        /// Gets the opening account entry entity by account code.
        /// </summary>
        /// <param name="accountNumber">The account code.</param>
        /// <returns></returns>
        List<OpeningAccountEntryEntity> GetOpeningAccountEntriesByAccountNumber(string accountNumber);

        /// <summary>
        /// Inserts the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        string InsertOpeningAccountEntry(OpeningAccountEntryEntity openingAccountEntryEntity);

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        string UpdateOpeningAccountEntry(OpeningAccountEntryEntity openingAccountEntryEntity);
        string DeleteOpeningAccountEntryByAccountNumber(string accountnumber);
    }
}
