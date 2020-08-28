/***********************************************************************
 * <copyright file="IOpeningCommitmentDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, December 7, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, December 7, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening
{
    /// <summary>
    /// Interface IOpeningCommitmentDao
    /// </summary>
    public interface IOpeningCommitmentDao
    {
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>OpeningCommitmentEntity.</returns>
        OpeningCommitmentEntity GetOpeningCommitmentbyRefId(string refId);

        /// <summary>
        /// Gets the opening commitmentby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>OpeningCommitmentEntity.</returns>
        OpeningCommitmentEntity GetOpeningCommitmentbyRefNo(string refNo);
        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;OpeningCommitmentEntity&gt;.</returns>
        List<OpeningCommitmentEntity> GetOpeningCommitment();

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;OpeningCommitmentEntity&gt;.</returns>
        List<OpeningCommitmentEntity> GetOpeningCommitmentsByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="openingCommitment">The opening commitment.</param>
        /// <returns>System.String.</returns>
        string InsertOpeningCommitment(OpeningCommitmentEntity openingCommitment);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="openingCommitment">The opening commitment.</param>
        /// <returns>System.String.</returns>
        string UpdateOpeningCommitment(OpeningCommitmentEntity openingCommitment);


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="openingCommitment">The opening commitment.</param>
        /// <returns>System.String.</returns>
        string DeleteOpeningCommitment(OpeningCommitmentEntity openingCommitment);
    }
}
