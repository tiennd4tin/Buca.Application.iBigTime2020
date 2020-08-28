/***********************************************************************
 * <copyright file="PermissionModel.cs" company="BUCA JSC">
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


namespace Buca.Application.iBigTime2020.Model.BusinessObjects.System
{
    /// <summary>
    ///     PermissionModel
    /// </summary>
    public class UserFeaturePermisionModel
    {
        /// <summary>
        ///     Gets or sets the user feature permision identifier.
        /// </summary>
        /// <value>
        ///     The user feature permision identifier.
        /// </value>
        public string UserFeaturePermisionID { get; set; }

        /// <summary>
        ///     Gets or sets the user profile identifier.
        /// </summary>
        /// <value>
        ///     The user profile identifier.
        /// </value>
        public string UserProfileID { get; set; }

        /// <summary>
        ///     Gets or sets the user permision identifier.
        /// </summary>
        /// <value>
        ///     The user permision identifier.
        /// </value>
        public string UserPermisionID { get; set; }

        /// <summary>
        ///     Gets or sets the feature identifier.
        /// </summary>
        /// <value>
        ///     The feature identifier.
        /// </value>
        public string FeatureID { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets the features model.
        /// </summary>
        /// <value>
        ///     The features model.
        /// </value>
        public FeaturesModel FeaturesModel { get; set; }

        /// <summary>
        /// Gets or sets the user permision model.
        /// </summary>
        /// <value>
        /// The user permision model.
        /// </value>
        public UserPermisionModel UserPermisionModel { get; set; }
    }
}