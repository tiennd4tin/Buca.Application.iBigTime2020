/***********************************************************************
 * <copyright file="PermissionEntity.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.BusinessEntities.System
{
    /// <summary>
    ///     PermissionEntity
    /// </summary>
    public class UserFeaturePermisionEntity : BusinessEntities
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
        ///     Gets or sets the feature entity.
        /// </summary>
        /// <value>
        ///     The feature entity.
        /// </value>
        public FeatureEntity FeatureEntity { get; set; }

        /// <summary>
        /// Gets or sets the user permision entity.
        /// </summary>
        /// <value>
        /// The user permision entity.
        /// </value>
        public UserPermisionEntity UserPermisionEntity { get; set; }
    }
}