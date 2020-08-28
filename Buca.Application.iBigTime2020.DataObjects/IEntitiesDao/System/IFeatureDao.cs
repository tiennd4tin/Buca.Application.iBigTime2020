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
    /// IPermissionDao
    /// </summary>
    public interface IFeatureDao
    {
        List<FeatureEntity> GetFeatures();

        /// <summary>
        /// Gets the feature entities is parent.
        /// </summary>
        /// <returns></returns>
        IList<FeatureEntity> GetFeatureEntitiesIsParent();

        /// <summary>
        /// Inserts the feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns></returns>
        string InsertFeature(FeatureEntity feature);
    }
}