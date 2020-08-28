/***********************************************************************
 * <copyright file="IOpeningInventoryEntryDao.cs" company="BUCA JSC">
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
    /// IOpeningInventoryEntryDao
    /// </summary>
    public interface IOpeningInventoryEntryDao
    {
        List<OpeningInventoryEntryEntity> GetOpeningInventoryEntries(string acccountNumber);
        string UpdateOpeningInventoryEntry(OpeningInventoryEntryEntity openingCommitment);

        string DeleteOpeningInventoryEntries(string acccountNumber);

        ///// <summary>
        ///// Gets the opening account entry entity by account code.
        ///// </summary>
        ///// <param name="accountCode">The account code.</param>
        ///// <returns></returns>
        //OpeningInventoryEntryEntity GetOpeningInventoryEntryEntityByAccountCodeForMaster(string accountCode); 

        ///// <summary>
        ///// Gets the opening account entry entity by account code.
        ///// </summary>
        ///// <param name="accountCode">The account code.</param>
        ///// <returns></returns>
        //List<OpeningInventoryEntryEntity> GetOpeningInventoryEntryEntityByAccountCode(string accountCode);

        ///// <summary>
        ///// Inserts the opening account entry.
        ///// </summary>
        ///// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        ///// <returns></returns>
        //long InsertOpeningInventoryEntry(OpeningInventoryEntryEntity openingAccountEntryEntity);

        ///// <summary>
        ///// Updates the opening account entry.
        ///// </summary>
        ///// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        ///// <returns></returns>
        //string UpdateOpeningInventoryEntry(OpeningInventoryEntryEntity openingAccountEntryEntity);

        ///// <summary>
        ///// Updates the opening account entry.
        ///// </summary>
        ///// <param name="openingAccountEntryEntity">The opening account entry entity.</param> 
        ///// <returns></returns>
        //string DeleteOpeningInventoryEntryByAccountCode(OpeningInventoryEntryEntity openingAccountEntryEntity);
    }
}
