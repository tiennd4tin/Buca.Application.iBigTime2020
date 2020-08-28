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
    /// PermissionModel
    /// </summary>
    public class FeaturesModel
    {

        public string FeatureID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string ParentID { get; set; }

        public string MenuItemCode { get; set; }
        public string Description { get; set; }

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
