/***********************************************************************
 * <copyright file="IBUTransferDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    /// <summary>
    /// Interface IBUTransferDetailDao
    /// </summary>
    public interface IBUTransferDetailDao
    {
        /// <summary>
        /// Deletes the bu commitment request detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteBUTransferDetail(string refId);
        /// <summary>
        /// Gets the bu commitment request detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestDetailEntity&gt;.</returns>
        List<BUTransferDetailEntity> GetBUTransferDetailbyRefId(string refId);
        /// <summary>
        /// Inserts the bu plan receipt detail.
        /// </summary>
        /// <param name="bUTransferDetail">The b u transfer detail.</param>
        /// <returns>System.String.</returns>
        string InsertBUTransferDetail(BUTransferDetailEntity bUTransferDetail);
    }
}
