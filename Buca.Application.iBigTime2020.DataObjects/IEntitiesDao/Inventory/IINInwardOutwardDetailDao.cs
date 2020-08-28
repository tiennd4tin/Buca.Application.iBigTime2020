/***********************************************************************
 * <copyright file="IINInwardOutwardDetailDao.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory
{

    /// <summary>
    /// IINInwardOutwardDetailDao interface
    /// </summary>
    public interface IINInwardOutwardDetailDao
    {
        /// <summary>
        /// Gets the ca inwardOutward details by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;INInwardOutwardDetailEntity&gt;.</returns>
        List<INInwardOutwardDetailEntity> GetINInwardOutwardDetailsByRefId(string refId);

        /// <summary>
        /// Inserts the ca inwardOutward detail.
        /// </summary>
        /// <param name="inwardOutwardDetailEntity">The inwardOutward detail entity.</param>
        /// <returns>System.String.</returns>
        string InsertINInwardOutwardDetail(INInwardOutwardDetailEntity inwardOutwardDetailEntity);

        /// <summary>
        /// Deletes the ca inwardOutward detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteINInwardOutwardDetailByRefId(string refId);
    }
}