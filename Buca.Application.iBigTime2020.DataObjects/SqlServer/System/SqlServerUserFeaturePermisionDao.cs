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
    /// class SqlServerPermissionDao
    /// </summary>
    public class SqlServerUserFeaturePermisionDao : IUserFeaturePermisionDao
    {


        public string DeleteUserFeaturePermision(string featureID, string UserProfileID)
        {
            const string procedures = @"uspDelete_UserFeaturePermision_ByFeatureID_And_UserProfileID";
            object[] parms = { "@FeatureID", featureID, "@UserProfileID", UserProfileID };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the feature permision entities by user profile identifier and feature identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        public IList<UserFeaturePermisionEntity> GetUserFeaturePermisionEntitiesByUserProfileIdAndFeatureId(string userProfileId, string featureId)
        {
            const string procedures = @"[dbo].[uspGet_All_UserFeaturePermision_ByUserProfileIDAndFeatureID]";
            object[] parms = { "@UserProfileID", userProfileId, "@FeatureID",featureId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the name of the user feature permision entities by user profile identifier and form.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="formName">Name of the form.</param>
        /// <returns></returns>
        public IList<UserFeaturePermisionEntity> GetUserFeaturePermisionEntitiesByUserProfileIdAndFormName(string userProfileId, string formName)
        {
            const string procedures = @"[dbo].[uspGet_All_UserFeaturePermision_ByUserProfileIDAndFormName]";
            object[] parms = { "@UserProfileID", userProfileId, "@FormName", formName };
            return Db.ReadList(procedures, true, MakeInCludeFormName, parms);
        }

        /// <summary>
        /// The make in clude form name
        /// </summary>
        private static readonly Func<IDataReader, UserFeaturePermisionEntity> MakeInCludeFormName = reader =>
            new UserFeaturePermisionEntity
            {
                FeatureEntity = new FeatureEntity
                {
                    ParentID = reader["FormMasterName"].AsString(),
                    MenuItemCode = reader["FormDetailName"].AsString()
                },
                FeatureID = reader["FeatureID"].AsString(),
                UserFeaturePermisionID = reader["UserFeaturePermisionID"].AsString(),
                UserPermisionID = reader["UserPermisionID"].AsString(),
                UserProfileID = reader["UserProfileID"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
                UserPermisionEntity = new UserPermisionEntity
                {
                    Code = reader["Code"].AsString(),
                    Name = reader["Name"].AsString()
                }
            };

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, UserFeaturePermisionEntity> Make = reader =>
            new UserFeaturePermisionEntity
            {
                FeatureEntity = new FeatureEntity
                {
                    ParentID = reader["ParentID"].AsString(),
                    MenuItemCode = reader["MenuItemCode"].AsString(),
                    Name = reader["Name"].AsString()
                },
                FeatureID = reader["FeatureID"].AsString(),
                UserFeaturePermisionID = reader["UserFeaturePermisionID"].AsString(),
                UserPermisionID = reader["UserPermisionID"].AsString(),
                UserProfileID = reader["UserProfileID"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
            };

        public string InsertUserFeaturePermision(UserFeaturePermisionEntity userfeaturePermision)
        {
            const string sql = @"uspInsert_UserFeaturePermision";
            return Db.Update(sql, true, Take(userfeaturePermision));
        }

        private object[] Take(UserFeaturePermisionEntity permission)
        {
            return new object[]
            {
                 @"UserFeaturePermisionID", permission.UserFeaturePermisionID,
                 @"FeatureID", permission.FeatureID,
                 @"UserPermisionID", permission.UserPermisionID,
                 @"UserProfileID", permission.UserProfileID,
                 @"IsActive", permission.IsActive
            };

        }
    }
}