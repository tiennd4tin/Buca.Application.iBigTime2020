/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    11/12/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    /// <summary>
    /// IBUBudgetReserveDetailDao
    /// </summary>
    public interface IBUBudgetReserveDetailDao
    {
        /// <summary>
        /// Deletes the bu budget reserve detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteBUBudgetReserveDetail(string refId);

        /// <summary>
        /// Gets the bu budget reserve details by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<BUBudgetReserveDetailEntity> GetBUBudgetReserveDetailsByRefId(string refId);

        /// <summary>
        /// Inserts the bu budget reserve detail.
        /// </summary>
        /// <param name="buBudgetReserveDetail">The bu budget reserve detail.</param>
        /// <returns></returns>
        string InsertBUBudgetReserveDetail(BUBudgetReserveDetailEntity buBudgetReserveDetail);
    }
}
