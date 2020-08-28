/***********************************************************************
 * <copyright file="PermissionsPresenter.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.View.System;


namespace Buca.Application.iBigTime2020.Presenter.System.Permission
{
    /// <summary>
    /// class PermissionsPresenter
    /// </summary>
    public class UserFeaturePermisionPresenter : Presenter<IUserFeaturePermisionView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UserFeaturePermisionPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public UserFeaturePermisionPresenter(IUserFeaturePermisionView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves the specified user feature permision models.
        /// </summary>
        /// <param name="userFeaturePermisionModels">The user feature permision models.</param>
        /// <returns></returns>
        public string Save(IList<UserFeaturePermisionModel> userFeaturePermisionModels)
        {
            return Model.InsertUserFeaturePermision(userFeaturePermisionModels);
        }

        /// <summary>
        /// Deletes the specified feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <param name="UserProfileID">The user profile identifier.</param>
        /// <returns></returns>
        public string Delete(string featureId, string UserProfileID)
        {
            return Model.DeleteUserFeaturePermision(featureId, UserProfileID);
        }

    }
}