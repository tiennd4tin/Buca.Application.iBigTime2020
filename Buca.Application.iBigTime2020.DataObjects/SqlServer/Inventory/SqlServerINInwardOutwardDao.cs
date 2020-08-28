/***********************************************************************
 * <copyright file="SqlServerCashDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Inventory
{

    /// <summary>
    /// SqlServerCashDao class
    /// </summary>
    public class SqlServerINInwardOutwardDao : IINInwardOutwardDao
    {

        /// <summary>
        /// Gets the cash.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>INInwardOutwardEntity.</returns>
        public INInwardOutwardEntity GetINInwardOutward(string refId)
        {
            const string procedures = @"uspGet_INInwardOutward_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        public List<INInwardOutwardEntity> GetINInwardOutwardByRefTypeId(int refTypeId)
        {
            const string sql = @"uspGet_INInwardOutward_ByRefTypeID";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(sql, true, Make, parms);
        }
       
        /// <summary>
        /// Gets the ca inwardOutward by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;INInwardOutwardEntity&gt;.</returns>
        public INInwardOutwardEntity GetINInwardOutwardByRefNo(string refNo)
        {
            const string procedures = @"uspGet_INInwardOutward_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the ca inwardOutward by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;INInwardOutwardEntity&gt;.</returns>
        public INInwardOutwardEntity GetINInwardOutwardByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_INInwardOutward_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo,"@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the ca inwardOutwards.
        /// </summary>
        /// <returns>List&lt;INInwardOutwardEntity&gt;.</returns>
        public List<INInwardOutwardEntity> GetINInwardOutwards()
        {
            const string procedures = @"uspGet_All_INInwardOutward";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the ca inwardOutward.
        /// </summary>
        /// <param name="inwardOutward">The inwardOutward.</param>
        /// <returns>System.String.</returns>
        public string InsertINInwardOutward(INInwardOutwardEntity inwardOutward)

        {
            const string procedures = @"uspInsert_INInwardOutward";
            return Db.Update(procedures, true, Take(inwardOutward));
        }

        /// <summary>
        /// Updates the cash entity.
        /// </summary>
        /// <param name="inwardOutward">The inwardOutward.</param>
        /// <returns>System.String.</returns>
        public string UpdateINInwardOutward(INInwardOutwardEntity inwardOutward)
        {
            const string procedures = @"uspUpdate_INInwardOutward";
            return Db.Update(procedures, true, Take(inwardOutward));
        }

        /// <summary>
        /// Deletes the cash entity.
        /// </summary>
        /// <param name="inwardOutward">The inwardOutward.</param>
        /// <returns>System.String.</returns>
        public string DeleteINInwardOutward(INInwardOutwardEntity inwardOutward)
        {
            const string procedures = @"uspDelete_INInwardOutward";
            object[] parms = { "@RefID", inwardOutward.RefId };
            return Db.Delete(procedures, true, parms);
        }

        public List<INInwardOutwardEntity> CheckExistVoucher(DateTime fromDate, DateTime toDate, string inventoryItem)
        {
            const string sql = @"uspGetOutwardInventory_ByInventoryItem";
            object[] parms = { "@FromDate", fromDate, "@ToDate", toDate, "@InventoryItemID", inventoryItem };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, INInwardOutwardEntity> Make = reader =>
           new INInwardOutwardEntity
           {
               RefId = reader["RefID"].AsString(),
               RefType = reader["RefType"].AsInt(),
               RefDate = reader["RefDate"].AsDateTime(),
               PostedDate = reader["PostedDate"].AsDateTime(),
               RefNo = reader["RefNo"].AsString(),
               ParalellRefNo = reader["ParalellRefNo"].AsString(),
               AccountingObjectId = reader["AccountingObjectID"].AsString(),
               JournalMemo = reader["JournalMemo"].AsString(),
               TotalAmount = reader["TotalAmount"].AsDecimal(),
               TotalTaxAmount = reader["TotalTaxAmount"].AsDecimal(),
               GeneratedRefId = reader["GeneratedRefID"].AsString(),
               RefOrder = reader["RefOrder"].AsInt(),
               DocumentInclued = reader["DocumentInclued"].AsString(),
               CurrencyCode= reader["CurrencyCode"].AsString(),
               ExchangeRate= reader["ExchangeRate"].AsDecimal(),
           };

        /// <summary>
        /// Takes the specified i n inward outward entity.
        /// </summary>
        /// <param name="iNInwardOutwardEntity">The i n inward outward entity.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(INInwardOutwardEntity iNInwardOutwardEntity)
        {
            return new object[]
            {
                "@RefID",iNInwardOutwardEntity.RefId,
                "@RefType",iNInwardOutwardEntity.RefType,
                "@RefDate",iNInwardOutwardEntity.RefDate,
                "@PostedDate",iNInwardOutwardEntity.PostedDate,
                "@RefNo",iNInwardOutwardEntity.RefNo,
                "@ParalellRefNo",iNInwardOutwardEntity.ParalellRefNo,
                "@AccountingObjectID",iNInwardOutwardEntity.AccountingObjectId,
                "@JournalMemo",iNInwardOutwardEntity.JournalMemo,
                "@TotalAmount",iNInwardOutwardEntity.TotalAmount,
                "@TotalTaxAmount",iNInwardOutwardEntity.TotalTaxAmount,
                "@GeneratedRefID",iNInwardOutwardEntity.GeneratedRefId,
                "@RefOrder",iNInwardOutwardEntity.RefOrder,
                "@DocumentInclued",iNInwardOutwardEntity.DocumentInclued,
                "@CurrencyCode",iNInwardOutwardEntity.CurrencyCode,
                 "@ExchangeRate",iNInwardOutwardEntity.ExchangeRate,
            };
        }
    }
}
