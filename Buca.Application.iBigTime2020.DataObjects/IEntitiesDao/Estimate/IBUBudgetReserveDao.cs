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

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    /// <summary>
    /// IBUBudgetReserveDao
    /// </summary>
   public interface IBUBudgetReserveDao
    {
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        BUBudgetReserveEntity GetBUBudgetReserveByRefId(string refId);

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns></returns>
        List<BUBudgetReserveEntity> GetBUBudgetReserves();

        /// <summary>
        /// Gets the bu budget reserves by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<BUBudgetReserveEntity> GetBUBudgetReservesByRefId(string refId);

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        BUBudgetReserveEntity GetBUBudgetReserve(string refNo);

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        BUBudgetReserveEntity GetBUBudgetReserve(string refNo, DateTime postedDate);

        /// <summary>
        /// Gets the bu plan receipt entity.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<BUBudgetReserveEntity> GetBUBudgetReserves(string refTypeId);

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<BUBudgetReserveEntity> GetBUBudgetReservesByRefTypeId(int refTypeId);

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="buBudgetReserve">The bu budget reserve.</param>
        /// <returns></returns>
        string InsertBUBudgetReserve(BUBudgetReserveEntity buBudgetReserve);

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="buBudgetReserve">The bu budget reserve.</param>
        /// <returns></returns>
        string UpdateBUBudgetReserve(BUBudgetReserveEntity buBudgetReserve);


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="buBudgetReserve">The bu budget reserve.</param>
        /// <returns></returns>
        string DeleteBUBudgetReserve(BUBudgetReserveEntity buBudgetReserve);
    }
}
