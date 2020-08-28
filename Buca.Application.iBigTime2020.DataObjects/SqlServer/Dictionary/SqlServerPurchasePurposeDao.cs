/***********************************************************************
 * <copyright file="SqlServerPurchasePurposeDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 12, 2017
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
    ///     SqlServerPurchasePurposeDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary.IPurchasePurposeDao" />
    public class SqlServerPurchasePurposeDao : IPurchasePurposeDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, PurchasePurposeEntity> Make = reader =>
            new PurchasePurposeEntity
            {
                PurchasePurposeId = reader["PurchasePurposeId"].AsString(),
                PurchasePurposeCode = reader["PurchasePurposeCode"].AsString(),
                PurchasePurposeName = reader["PurchasePurposeName"].AsString(),
                Description = reader["Description"].AsString(),
                IsSystem = reader["IsSystem"].AsBool(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        ///     Lấy kho theo purchasePurposeId
        /// </summary>
        /// <param name="purchasePurposeId">The identifier.</param>
        /// <returns>PurchasePurposeEntity.</returns>
        public PurchasePurposeEntity GetPurchasePurpose(string purchasePurposeId)
        {
            const string sql = @"uspGet_PurchasePurpose_ByID";
            object[] parms = {"@PurchasePurposeID", purchasePurposeId};
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        ///     Lấy danh sách các kho
        /// </summary>
        /// <returns>List{PurchasePurposeEntity}.</returns>
        public List<PurchasePurposeEntity> GetPurchasePurposes()
        {
            const string sql = @"uspGet_All_PurchasePurpose";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        ///     Inserts the purchasePurpose.
        /// </summary>
        /// <param name="purchasePurpose">The purchasePurpose.</param>
        /// <returns></returns>
        public string InsertPurchasePurpose(PurchasePurposeEntity purchasePurpose)
        {
            const string sql = @"uspInsert_PurchasePurpose";
            return Db.Insert(sql, true, Take(purchasePurpose));
        }

        /// <summary>
        ///     Updates the purchasePurpose.
        /// </summary>
        /// <param name="purchasePurpose">The purchasePurpose.</param>
        /// <returns></returns>
        public string UpdatePurchasePurpose(PurchasePurposeEntity purchasePurpose)
        {
            const string sql = @"uspUpdate_PurchasePurpose";
            return Db.Update(sql, true, Take(purchasePurpose));
        }

        /// <summary>
        ///     Deletes the purchasePurpose.
        /// </summary>
        /// <param name="purchasePurpose">The purchasePurpose.</param>
        /// <returns>System.String.</returns>
        public string DeletePurchasePurpose(PurchasePurposeEntity purchasePurpose)
        {
            const string sql = @"uspDelete_PurchasePurpose";
            object[] parms = {"@PurchasePurposeID", purchasePurpose.PurchasePurposeId};
            return Db.Delete(sql, true, parms);
        }

        public string DeletePurchasePurposeConvert()
        {
            const string sql = @"usp_ConvertPurchasePurpose";
            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }


        /// <summary>
        ///     Lấy danh sách Kho được hoạt động.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List{PurchasePurposeEntity}.</returns>
        public List<PurchasePurposeEntity> GetPurchasePurposesByIsActive(bool isActive)
        {
            const string sql = @"uspGet_PurchasePurpose_ByIsActive";
            object[] parms = {"@IsActive", isActive};
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        ///     Lấy danh sách kho theo mã
        /// </summary>
        /// <param name="purchasePurposeCode"></param>
        /// <returns></returns>
        public PurchasePurposeEntity GetPurchasePurposesByPurchasePurposeCode(string purchasePurposeCode)
        {
            const string sql = @"uspGet_PurchasePurpose_ByPurchasePurposeCode";
            object[] parms = {"@PurchasePurposeCode", purchasePurposeCode};
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        ///     Takes the specified purchasePurpose.
        /// </summary>
        /// <param name="purchasePurpose">The purchasePurpose.</param>
        /// <returns></returns>
        private object[] Take(PurchasePurposeEntity purchasePurpose)
        {
            return new object[]
            {
                "@PurchasePurposeID", purchasePurpose.PurchasePurposeId,
                "@PurchasePurposeCode", purchasePurpose.PurchasePurposeCode,
                "@PurchasePurposeName", purchasePurpose.PurchasePurposeName,
                "@Description", purchasePurpose.Description,
                "@IsSystem", purchasePurpose.IsSystem,
                "@IsActive", purchasePurpose.IsActive
            };
        }
    }
}