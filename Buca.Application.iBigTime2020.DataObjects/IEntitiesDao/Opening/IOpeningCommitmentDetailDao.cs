/***********************************************************************
 * <copyright file="IOpeningCommitmentDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, December 8, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, December 8, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening
{
    /// <summary>
    /// Interface IOpeningCommitmentDetailDao
    /// </summary>
    public interface IOpeningCommitmentDetailDao
    {
        /// <summary>
        /// Deletes the bu commitment request detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteOpeningCommitmentDetail(string refId);
        /// <summary>
        /// Gets the bu commitment request detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestDetailEntity&gt;.</returns>
        List<OpeningCommitmentDetailEntity> GetOpeningCommitmentDetailbyRefId(string refId);
        /// <summary>
        /// Inserts the bu plan receipt detail.
        /// </summary>
        /// <param name="openingCommitmentDetail">The opening commitment detail.</param>
        /// <returns>System.String.</returns>
        string InsertOpeningCommitmentDetail(OpeningCommitmentDetailEntity openingCommitmentDetail);
    }
}
