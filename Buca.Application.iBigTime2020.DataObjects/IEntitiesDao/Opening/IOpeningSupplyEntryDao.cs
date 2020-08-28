/***********************************************************************
 * <copyright file="IOpeningSupplyEntryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, January 3, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, January 3, 2018 Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening
{
    public interface IOpeningSupplyEntryDao
    {
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>OpeningSupplyEntryEntity.</returns>
        OpeningSupplyEntryEntity GetOpeningSupplyEntrybyRefId(string refId);

        /// <summary>
        /// Gets the opening commitmentby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>OpeningSupplyEntryEntity.</returns>
        OpeningSupplyEntryEntity GetOpeningSupplyEntrybyRefNo(string refNo);
        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;OpeningSupplyEntryEntity&gt;.</returns>
        List<OpeningSupplyEntryEntity> GetOpeningSupplyEntry();

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;OpeningSupplyEntryEntity&gt;.</returns>
        List<OpeningSupplyEntryEntity> GetOpeningSupplyEntrysByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="openingCommitment">The opening commitment.</param>
        /// <returns>System.String.</returns>
        string InsertOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="openingCommitment">The opening commitment.</param>
        /// <returns>System.String.</returns>
        string UpdateOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment);


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="openingCommitment">The opening commitment.</param>
        /// <returns>System.String.</returns>
        string DeleteOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment);

        /// <summary>
        /// Deletes the opening supply entry.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteOpeningSupplyEntry(string refId);

        string DeleteOpeningSupplyEntries();
    }
}
