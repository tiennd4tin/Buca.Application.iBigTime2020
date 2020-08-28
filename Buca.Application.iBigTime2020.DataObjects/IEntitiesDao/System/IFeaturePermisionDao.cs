/***********************************************************************
 * <copyright file="IPermissionDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 26 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.System;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System
{
    /// <summary>
    ///     IPermissionDao
    /// </summary>
    public interface IFeaturePermisionDao
    {
        /// <summary>
        ///     Inserts the feature permision.
        /// </summary>
        /// <param name="FeaturePermision">The feature permision.</param>
        /// <returns></returns>
        string InsertFeaturePermision(FeaturePermisionEntity FeaturePermision);

        /// <summary>
        ///     Deletes the feature permision.
        /// </summary>
        /// <param name="featureID">The feature identifier.</param>
        /// <returns></returns>
        string DeleteFeaturePermision(string featureID);

        /// <summary>
        ///     Gets the feature permisions by feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        IList<FeaturePermisionEntity> GetFeaturePermisionsByFeatureId(string featureId);
    }
}