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
    public class SqlServerFeatureDao : IFeatureDao
    {
        public List<FeatureEntity> GetFeatures()
        {
            const string procedures = @"uspGet_All_Feature";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the feature entities is parent.
        /// </summary>
        /// <returns></returns>
        public IList<FeatureEntity> GetFeatureEntitiesIsParent()
        {
            const string procedures = @"[dbo].[uspGet_Feature_IsParent]";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FeatureEntity> Make = reader =>
            new FeatureEntity
            {
                FeatureID = reader["FeatureID"].AsString(),

                Code = reader["Code"].AsString(),
                Name = reader["Name"].AsString(),
                ParentID = reader["ParentID"].AsString(),
                MenuItemCode = reader["MenuItemCode"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
                FormMasterName = reader["FormMasterName"].AsString(),
                FormDetailName = reader["FormDetailName"].AsString(),
                SortOrder=reader["SortOrder"].AsInt()
            };

        /// <summary>
        /// Takes the specified permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        private object[] Take(FeatureEntity permission)
        {
            return new object[]
            {
                 "@FeatureID", permission.FeatureID,
                 "@Code", permission.Code,
                 "@Name", permission.Name,
                 "@ParentID", permission.ParentID,
                 "@MenuItemCode", permission.MenuItemCode,
                 "@Description", permission.Description,
                 "@IsActive", permission.IsActive,
                 "@FormMasterName",permission.FormMasterName,
                 "@FormDetailName",permission.FormDetailName
            };
        }

        /// <summary>
        /// Inserts the feature.
        /// </summary>
        /// <param name="feature">The feature.</param>
        /// <returns></returns>
        public string InsertFeature(FeatureEntity feature)
        {
            const string procedures = @"uspInsert_Feature  ";
            return Db.Insert(procedures, true, Take(feature));
        }
    }
}