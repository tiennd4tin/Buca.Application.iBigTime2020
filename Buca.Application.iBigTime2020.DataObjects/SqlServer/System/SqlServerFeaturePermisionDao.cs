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
    public class SqlServerFeaturePermisionDao : IFeaturePermisionDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, FeaturePermisionEntity> Make = reader =>
            new FeaturePermisionEntity
            {
                FeaturePermisionID = reader["FeaturePermisionID"].AsString(),
                FeatureID = reader["FeatureID"].AsString(),
                UserPermisionID = reader["UserPermisionID"].AsString()
            };

        /// <summary>
        ///     Deletes the feature permision.
        /// </summary>
        /// <param name="featureID">The feature identifier.</param>
        /// <returns></returns>
        public string DeleteFeaturePermision(string featureID)
        {
            const string procedures = @"uspDelete_FeaturePermision_ByFeatureID";
            object[] parms = {"@FeatureID", featureID};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Gets the feature permisions by feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        public IList<FeaturePermisionEntity> GetFeaturePermisionsByFeatureId(string featureId)
        {
            const string procedures = @"uspGet_FeaturePermision_FeatureID";
            // object[] parms = { "@FeatureID", Feature };
            object[] parms = {"@FeatureID", featureId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the feature permision.
        /// </summary>
        /// <param name="featurePermision">The feature permision.</param>
        /// <returns></returns>
        public string InsertFeaturePermision(FeaturePermisionEntity featurePermision)
        {
            const string sql = @"uspInsert_FeaturePermision";
            return Db.Update(sql, true, Take(featurePermision));
        }

        /// <summary>
        ///     Takes the specified permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        private object[] Take(FeaturePermisionEntity permission)
        {
            return new object[]
            {
                @"FeaturePermisionID", permission.FeaturePermisionID,
                @"FeatureID", permission.FeatureID,
                @"UserPermisionID", permission.UserPermisionID
            };
        }
    }
}