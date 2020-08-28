/***********************************************************************
 * <copyright file="SqlEmployeeTypeDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, September 28, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    ///     SqlEmployeeTypeDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary.IEmployeeTypeDao" />
    public class SqlServerEmployeeTypeDao : IEmployeeTypeDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, EmployeeTypeEntity> Make = reader =>
            new EmployeeTypeEntity
            {
                EmployeeTypeId = reader["EmployeeTypeId"].AsString(),
                EmployeeTypeName = reader["EmployeeTypeName"].AsString(),
                Description = reader["Description"].AsString(),
                EmployeeTypeCode = reader["EmployeeTypeCode"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        ///     Lấy kho theo employeeTypeId
        /// </summary>
        /// <param name="employeeTypeId">The identifier.</param>
        /// <returns>EmployeeTypeEntity.</returns>
        public EmployeeTypeEntity GetEmployeeType(string employeeTypeId)
        {
            const string sql = @"uspGet_EmployeeType_ByID";
            object[] parms = {"@EmployeeTypeID", employeeTypeId};
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        ///     Lấy danh sách các kho
        /// </summary>
        /// <returns>List{EmployeeTypeEntity}.</returns>
        public List<EmployeeTypeEntity> GetEmployeeTypes()
        {
            const string sql = @"uspGet_All_EmployeeType";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        ///     Inserts the employeeType.
        /// </summary>
        /// <param name="employeeType">The employeeType.</param>
        /// <returns></returns>
        public string InsertEmployeeType(EmployeeTypeEntity employeeType)
        {
            const string sql = @"uspInsert_EmployeeType";
            return Db.Insert(sql, true, Take(employeeType));
        }

        /// <summary>
        ///     Updates the employeeType.
        /// </summary>
        /// <param name="employeeType">The employeeType.</param>
        /// <returns></returns>
        public string UpdateEmployeeType(EmployeeTypeEntity employeeType)
        {
            const string sql = @"uspUpdate_EmployeeType";
            return Db.Update(sql, true, Take(employeeType));
        }

        /// <summary>
        ///     Deletes the employeeType.
        /// </summary>
        /// <param name="employeeType">The employeeType.</param>
        /// <returns>System.String.</returns>
        public string DeleteEmployeeType(EmployeeTypeEntity employeeType)
        {
            const string sql = @"uspDelete_EmployeeType";
            object[] parms = {"@EmployeeTypeID", employeeType.EmployeeTypeId};
            return Db.Delete(sql, true, parms);
        }
        public string DeleteEmployeeTypeConvert( )
        {
            const string sql = @"uspDelete_EmployeeType";
            object[] parms = {  };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        ///     Lấy danh sách Kho được hoạt động.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List{EmployeeTypeEntity}.</returns>
        public List<EmployeeTypeEntity> GetEmployeeTypesByIsActive(bool isActive)
        {
            const string sql = @"uspGet_EmployeeType_ByIsActive";
            object[] parms = {"@IsActive", isActive};
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        ///     Lấy danh sách kho theo mã
        /// </summary>
        /// <param name="employeeTypeCode"></param>
        /// <returns></returns>
        public List<EmployeeTypeEntity> GetEmployeeTypesByEmployeeTypeCode(string employeeTypeCode)
        {
            const string sql = @"uspGet_EmployeeType_ByEmployeeTypeCode";
            object[] parms = {"@EmployeeTypeCode", employeeTypeCode};
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        ///     Takes the specified employeeType.
        /// </summary>
        /// <param name="employeeType">The employeeType.</param>
        /// <returns></returns>
        private object[] Take(EmployeeTypeEntity employeeType)
        {
            return new object[]
            {
                "@EmployeeTypeID", employeeType.EmployeeTypeId,
                "@EmployeeTypeName", employeeType.EmployeeTypeName,
                "@Description", employeeType.Description,
                "@EmployeeTypeCode", employeeType.EmployeeTypeCode,
                "@IsActive", employeeType.IsActive
            };
        }
    }
}