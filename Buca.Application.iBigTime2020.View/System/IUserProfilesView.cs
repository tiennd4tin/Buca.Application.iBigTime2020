/***********************************************************************
 * <copyright file="IUserProfilesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 24 October 2016
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;


namespace Buca.Application.iBigTime2020.View.System
{
    /// <summary>
    /// IUserProfilesView
    /// </summary>
    public interface IUserProfilesView : IView
    {
        /// <summary>
        /// Sets the user profiles.
        /// </summary>
        /// <value>
        /// The user profiles.
        /// </value>
        IList<UserProfileModel> UserProfiles { set; }
    }
}
