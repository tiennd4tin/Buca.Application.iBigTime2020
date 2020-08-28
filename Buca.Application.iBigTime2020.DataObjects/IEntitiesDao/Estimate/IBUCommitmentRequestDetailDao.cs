/***********************************************************************
 * <copyright file="IBUCommitmentRequestDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Tuesday, December 5, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateTuesday, December 5, 2017Author SonTV  Description 
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
    /// Interface IBUCommitmentRequestDetailDao
    /// </summary>
    public interface IBUCommitmentRequestDetailDao
    {
        /// <summary>
        /// Deletes the bu commitment request detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteBUCommitmentRequestDetail(string refId);
        /// <summary>
        /// Gets the bu commitment request detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestDetailEntity&gt;.</returns>
        List<BUCommitmentRequestDetailEntity> GetBUCommitmentRequestDetailbyRefId(string refId);
        /// <summary>
        /// Inserts the bu plan receipt detail.
        /// </summary>
        /// <param name="bUCommitmentRequestDetail">The b u commitment request detail.</param>
        /// <returns>System.String.</returns>
        string InsertBUPlanReceiptDetail(BUCommitmentRequestDetailEntity bUCommitmentRequestDetail);
    }
}
