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
    public interface IUserPermisionDao
    {
        /// <summary>
        ///     Gets the user permisions.
        /// </summary>
        /// <returns></returns>
        List<UserPermisionEntity> GetUserPermisions();

        /// <summary>
        ///     Gets the user permisions by feature.
        /// </summary>
        /// <param name="Feature">The feature.</param>
        /// <param name="UserProfileID">The user profile identifier.</param>
        /// <returns></returns>
        List<UserPermisionEntity> GetUserPermisionsByFeature(string Feature, string UserProfileID);

        /// <summary>
        ///     Gets the user permision bỳeature i by feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        IList<UserPermisionEntity> GetUserPermisionByFeatureId(string featureId);
    }
}