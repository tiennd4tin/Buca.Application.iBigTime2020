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
    public interface IUserFeaturePermisionDao
    {
        /// <summary>
        ///     Inserts the user feature permision.
        /// </summary>
        /// <param name="userFeaturePermision">The user feature permision.</param>
        /// <returns></returns>
        string InsertUserFeaturePermision(UserFeaturePermisionEntity userFeaturePermision);

        /// <summary>
        ///     Deletes the user feature permision.
        /// </summary>
        /// <param name="userfeatureID">The userfeature identifier.</param>
        /// <param name="UserProfileID">The user profile identifier.</param>
        /// <returns></returns>
        string DeleteUserFeaturePermision(string userfeatureID, string UserProfileID);

        /// <summary>
        ///     Gets the feature permision entities by user profile identifier and feature identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        IList<UserFeaturePermisionEntity> GetUserFeaturePermisionEntitiesByUserProfileIdAndFeatureId(string userProfileId,
            string featureId);

        /// <summary>
        /// Gets the name of the user feature permision entities by user profile identifier and form.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="formName">Name of the form.</param>
        /// <returns></returns>
        IList<UserFeaturePermisionEntity> GetUserFeaturePermisionEntitiesByUserProfileIdAndFormName(
            string userProfileId, string formName);
    }
}