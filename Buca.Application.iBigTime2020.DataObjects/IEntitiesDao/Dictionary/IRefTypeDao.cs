/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IRefTypeDao
    /// </summary>
    public interface IRefTypeDao
    {
        /// <summary>
        /// Gets the reference types.
        /// </summary>
        /// <returns></returns>
        List<RefTypeEntity> GetRefTypes();

        /// <summary>
        /// Gets the reference type search.
        /// </summary>
        /// <returns></returns>
        List<RefTypeEntity> GetRefTypeSearch();

        /// <summary>
        /// Gets the type of the reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        RefTypeEntity GetRefType(int refTypeId);

        /// <summary>
        /// Updates the type of the reference.
        /// </summary>
        /// <param name="refTypeEntity">The reference type entity.</param>
        /// <returns></returns>
        string UpdateRefType(RefTypeEntity refTypeEntity);

        string DeleteRefTypeConvert();

        string InsertReftype(RefTypeEntity refTypeEntity);

    }
}
