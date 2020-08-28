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

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;


namespace Buca.Application.iBigTime2020.BusinessEntities.System
{
    /// <summary>
    /// PermissionEntity
    /// </summary>
    public class FeatureEntity : BusinessEntities
    {

        /// <summary>
        /// Gets or sets the feature identifier.
        /// </summary>
        /// <value>
        /// The feature identifier.
        /// </value>
        public string FeatureID { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public string ParentID { get; set; }

        /// <summary>
        /// Gets or sets the menu item code.
        /// </summary>
        /// <value>
        /// The menu item code.
        /// </value>
        public string MenuItemCode { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the name of the form master.
        /// </summary>
        /// <value>
        /// The name of the form master.
        /// </value>
        public string FormMasterName { get; set; }

        /// <summary>
        /// Gets or sets the name of the form detail.
        /// </summary>
        /// <value>
        /// The name of the form detail.
        /// </value>
        public string FormDetailName { get; set; }

        public int SortOrder { get; set; }
    }
}
