/***********************************************************************
 * <copyright file="SqlServerPermissionDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.System;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.System
{
    /// <summary>
    ///     class SqlServerPermissionDao
    /// </summary>
    public class SqlServerUserPermisionDao : IUserPermisionDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, UserPermisionEntity> Make = reader =>
            new UserPermisionEntity
            {
                UserPermisionID = reader["UserPermisionID"].AsString(),
                Code = reader["Code"].AsString(),
                Name = reader["Name"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        ///     Gets the user permisions.
        /// </summary>
        /// <returns></returns>
        public List<UserPermisionEntity> GetUserPermisions()
        {
            const string procedures = @"uspGet_All_UserPermision";
            return Db.ReadList(procedures, true, Make);
        }


        /// <summary>
        ///     Gets the user permisions by feature.
        /// </summary>
        /// <param name="Feature">The feature.</param>
        /// <param name="UserProfileID">The user profile identifier.</param>
        /// <returns></returns>
        public List<UserPermisionEntity> GetUserPermisionsByFeature(string Feature, string UserProfileID)
        {
            const string procedures = @"uspGet_UserPermision_ByFeatureAndUserPermisionID";
            // object[] parms = { "@FeatureID", Feature };
            object[] parms = {"@FeatureID", Feature, "@UserProfileID", UserProfileID};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the user permision bỳeature i by feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        public IList<UserPermisionEntity> GetUserPermisionByFeatureId(string featureId)
        {
            const string procedures = @"uspGet_UserPermision_FeatureID";
            // object[] parms = { "@FeatureID", Feature };
            object[] parms = {"@FeatureID", featureId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Takes the specified permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        private object[] Take(UserPermisionEntity permission)
        {
            return new object[]
            {
                @"UserPermisionID", permission.UserPermisionID,
                @"Code", permission.Code,
                @"Name", permission.Name,
                @"Description", permission.Description,
                @"IsActive", permission.IsActive
            };
        }
    }
}