/***********************************************************************
 * <copyright file="IPaymentBUPlanWithdrawDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{

    /// <summary>
    /// IPaymentBUPlanWithdrawDao interface
    /// </summary>
    public interface IBUPlanWithdrawDao
    {
        /// <summary>
        /// Gets the bu plan withdraw.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUPlanWithdrawEntity.</returns>
        BUPlanWithdrawEntity GetBUPlanWithdraw(string refId);

        /// <summary>
        /// Gets the bu plan withdraw by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUPlanWithdrawEntity&gt;.</returns>
        IList<BUPlanWithdrawEntity> GetBUPlanWithdrawByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the bu plan withdraw by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>BUPlanWithdrawEntity.</returns>
        BUPlanWithdrawEntity GetBUPlanWithdrawByRefNo(string refNo);

        /// <summary>
        /// Gets the type of the bu plan withdraw by reference no reference.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns>BUPlanWithdrawEntity.</returns>
        BUPlanWithdrawEntity GetBUPlanWithdrawByRefNoRefType(string refNo, int refType);

        BUPlanWithdrawEntity GetBUPlanWithdrawByRefNoRefType(string refNo, int refType, DateTime postedDate);

        /// <summary>
        /// Gets the bu plan withdraws.
        /// </summary>
        /// <returns>List&lt;BUPlanWithdrawEntity&gt;.</returns>
        IList<BUPlanWithdrawEntity> GetBUPlanWithdraws();

        /// <summary>
        /// Inserts the bu plan withdraw.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        string InsertBUPlanWithdraw(BUPlanWithdrawEntity receipt);

        /// <summary>
        /// Updates the bu plan withdraw.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        string UpdateBUPlanWithdraw(BUPlanWithdrawEntity receipt);

        /// <summary>
        /// Deletes the bu plan withdraw.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        string DeleteBUPlanWithdraw(BUPlanWithdrawEntity receipt);
    }
}
