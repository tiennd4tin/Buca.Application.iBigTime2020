/***********************************************************************
 * <copyright file="IBUCommitmentAdjustmentDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, December 11, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    public interface IBUCommitmentAdjustmentDao
    {
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        BUCommitmentAdjustmentEntity GetBUCommitmentAdjustmentbyRefId(string refId);
        
        /// <summary>
        /// Gets the bu commitment adjustments by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;BUCommitmentAdjustmentEntity&gt;.</returns>
        BUCommitmentAdjustmentEntity GetBUCommitmentAdjustmentsByRefNo(string refNo);

        /// <summary>
        /// Gets the bu commitment adjustments by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;BUCommitmentAdjustmentEntity&gt;.</returns>
        BUCommitmentAdjustmentEntity GetBUCommitmentAdjustmentsByRefNo(string refNo, DateTime postedDate);

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns></returns>
        List<BUCommitmentAdjustmentEntity> GetBUCommitmentAdjustment();

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<BUCommitmentAdjustmentEntity> GetBUCommitmentAdjustmentsByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        string InsertBUCommitmentAdjustment(BUCommitmentAdjustmentEntity bUCommitmentAdjustment);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        string UpdateBUCommitmentAdjustment(BUCommitmentAdjustmentEntity bUCommitmentAdjustment);


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="buPlanReceipt">The bu plan receipt.</param>
        /// <returns></returns>
        string DeleteBUCommitmentAdjustment(BUCommitmentAdjustmentEntity bUCommitmentAdjustment);
    }
}
