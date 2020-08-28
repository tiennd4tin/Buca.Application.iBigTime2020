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
    public class FeaturePermisionEntity : BusinessEntities
    {
 
        public string FeaturePermisionID  { get; set; }

         public string UserPermisionID { get; set; }

         public string FeatureID { get; set; }

       
      
    }
}
