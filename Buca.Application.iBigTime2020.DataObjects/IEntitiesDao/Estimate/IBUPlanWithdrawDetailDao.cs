/***********************************************************************
 * <copyright file="IBUPlanWithdrawDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{

    /// <summary>
    /// IBUPlanWithdrawDetailDao interface
    /// </summary>
    public interface IBUPlanWithdrawDetailDao
    {
        /// <summary>
        /// Gets the bu plan withdraw details by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUPlanWithdrawDetailEntity&gt;.</returns>
        List<BUPlanWithdrawDetailEntity> GetBUPlanWithdrawDetailsByRefId(string refId);

        /// <summary>
        /// Inserts the bu plan withdraw detail.
        /// </summary>
        /// <param name="receiptDetailEntity">The receipt detail entity.</param>
        /// <returns>System.String.</returns>
        string InsertBUPlanWithdrawDetail(BUPlanWithdrawDetailEntity receiptDetailEntity);

        /// <summary>
        /// Deletes the bu plan withdraw detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteBUPlanWithdrawDetailByRefId(string refId);
    }
}