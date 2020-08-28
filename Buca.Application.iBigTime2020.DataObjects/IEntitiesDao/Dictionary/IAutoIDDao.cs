/***********************************************************************
 * <copyright file="IAutoIDDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IAutoIDDao
    /// </summary>
    public interface IAutoIDDao
    {
        /// <summary>
        /// Gets the automatic identifier by reference type category identifier.
        /// </summary>
        /// <param name="refTypeCategoryId">The reference type category identifier.</param>
        /// <returns>AutoIDEntity.</returns>
        AutoIDEntity GetAutoIDByRefTypeCategoryId(int refTypeCategoryId);

        /// <summary>
        /// Gets the automatic numbers.
        /// </summary>
        /// <returns></returns>
        List<AutoIDEntity> GetAutoIDs();

        /// <summary>
        /// Updates the automatic number.
        /// </summary>
        /// <param name="autoID">The automatic number.</param>
        /// <returns></returns>
        string UpdateAutoID(AutoIDEntity autoID);
    }
}
