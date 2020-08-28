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
    public class UserPermisionsPresenter : Presenter<IUserPermisionsView>
    {
 
        public UserPermisionsPresenter(IUserPermisionsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
           View.UserPermisions = Model.GetUserPermisions();
        }
        /// <summary>
        /// Displays the active.
        /// </summary>
        public void Display(string FeatureID, string UserProfileID)
        {
           View.UserPermisionsByFeatureID = Model.GetUserPermisionsByFeature(FeatureID, UserProfileID);
        }

        /// <summary>
        /// Displays the specified feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        public void Display(string featureId)
        {
            var userPermissions = Model.GetUserPermisionByFeatureId(featureId);
            //var userPermissions = Model.GetUserPermisions();
            View.UserPermisions = userPermissions==null?new List<UserPermisionModel>() : userPermissions;
        }
    }
}