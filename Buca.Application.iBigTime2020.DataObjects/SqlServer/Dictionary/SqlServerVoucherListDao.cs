/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
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
    /// SqlServerVoucherListDao
    /// </summary>
    public class SqlServerVoucherListDao : IVoucherListDao
    {
        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <returns></returns>
        public VoucherListEntity GetVoucherListById(string voucherListId)
        {
            const string sql = @"uspGet_VoucherList_ById";
            object[] parms = { "@VoucherListID", voucherListId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns></returns>
        public List<VoucherListEntity> GetVoucherLists()
        {
            const string sql = @"uspGet_All_VoucherList";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        /// Gets the voucher lists by code.
        /// </summary>
        /// <param name="voucherListCode">The voucher list code.</param>
        /// <returns></returns>
        public VoucherListEntity GetVoucherListsByCode(string voucherListCode)
        {
            const string sql = @"uspGet_VoucherList_ByCode";
           
            object[] parms = { "@VoucherListCode", voucherListCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        public string InsertVoucherList(VoucherListEntity voucherListEntity)
        {
            const string sql = @"uspInsert_VoucherList";
            return Db.Insert(sql, true, Take(voucherListEntity));
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        public string UpdateVoucherList(VoucherListEntity voucherListEntity)
        {
            const string sql = @"uspUpdate_VoucherList";
            return Db.Update(sql, true, Take(voucherListEntity));
        }

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="voucherListEntity">The voucher list entity.</param>
        /// <returns></returns>
        public string DeleteVoucherList(VoucherListEntity voucherListEntity)
        {
            const string sql = @"uspDelete_VoucherList";
            object[] parms = { "@VoucherListID", voucherListEntity.VoucherListId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, VoucherListEntity> Make = reader =>
            new VoucherListEntity
            {
                VoucherListId = reader["VoucherListID"].AsGuid().AsString(),
                VoucherListCode = reader["VoucherListCode"].AsString(),
                VoucherListName = reader["VoucherListName"].AsString(),
                FromDate = reader["FromDate"].AsDateTimeForNull(),
                ToDate = reader["ToDate"].AsDateTimeForNull(),
                DocumentAttached = reader["DocumentAttached"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified budget source property.
        /// </summary>
        /// <param name="voucherList">The voucherList.</param>
        /// <returns></returns>
        private static object[] Take(VoucherListEntity voucherList)
        {
            return new object[]
             {
                "@VoucherListID",voucherList.VoucherListId,
                "@VoucherListCode",voucherList.VoucherListCode,
                "@VoucherListName",voucherList.VoucherListName,
                "@FromDate",voucherList.FromDate,
                "@ToDate",voucherList.ToDate,
                "@DocumentAttached",voucherList.DocumentAttached,			
                "@Description",voucherList.Description,
                "@IsActive",voucherList.IsActive
             };
        }
    }
}
