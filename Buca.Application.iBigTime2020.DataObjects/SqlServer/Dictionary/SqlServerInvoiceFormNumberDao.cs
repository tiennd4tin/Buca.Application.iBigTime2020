/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 12, 2017
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
    /// SqlServerInvoiceFormNumberDao
    /// </summary>
    public class SqlServerInvoiceFormNumberDao : IInvoiceFormNumberDao
    {
        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="invoiceFormNumberId">The invoice form number identifier.</param>
        /// <returns></returns>
        public InvoiceFormNumberEntity GetInvoiceFormNumberById(string invoiceFormNumberId)
        {
            const string sql = @"uspGet_All_InvoiceFormNumber_ByID";
            object[] parms = { "@InvoiceFormNumberID", invoiceFormNumberId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Getses this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<InvoiceFormNumberEntity> GetInvoiceFormNumbers()
        {
            const string sql = @"uspGet_All_InvoiceFormNumber";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        /// Gets the invoice form numbers by active.
        /// </summary>
        /// <returns></returns>
        public List<InvoiceFormNumberEntity> GetInvoiceFormNumbersByActive()
        {
            const string sql = @"uspGet_All_InvoiceFormNumber_ByActive";
            return Db.ReadList(sql, true, Make);
        }

        /// <summary>
        /// Gets the voucher lists by code.
        /// </summary>
        /// <param name="invoiceFormNumberCode">The invoice form number code.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public InvoiceFormNumberEntity GetInvoiceFormNumbersByCode(string invoiceFormNumberCode)
        {
            const string sql = @"uspGet_All_InvoiceFormNumber_ByCode";
            object[] parms = { "@InvoiceFormNumberCode", invoiceFormNumberCode };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the specified object.
        /// </summary>
        /// <param name="invoiceFormNumberEntity">The invoice form number entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string InsertInvoiceFormNumber(InvoiceFormNumberEntity invoiceFormNumberEntity)
        {
            const string sql = @"uspInsert_InvoiceFormNumber";
            return Db.Insert(sql, true, Take(invoiceFormNumberEntity));
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="invoiceFormNumberEntity">The invoice form number entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string UpdateInvoiceFormNumber(InvoiceFormNumberEntity invoiceFormNumberEntity)
        {
            const string sql = @"uspUpdate_InvoiceFormNumber";
            return Db.Insert(sql, true, Take(invoiceFormNumberEntity));
        }

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <param name="invoiceFormNumberEntity">The invoice form number entity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string DeleteInvoiceFormNumber(InvoiceFormNumberEntity invoiceFormNumberEntity)
        {
            const string sql = @"uspDelete_InvoiceFormNumber";
            object[] parms = { "@InvoiceFormNumberID", invoiceFormNumberEntity.InvoiceFormNumberId };
            return Db.Delete(sql, true, parms);
        }

        public string DeleteInvoiceFormNumberConvert( )
        {
            const string sql = @"usp_ConvertInvoiceFormNumber";
            object[] parms = {  };
            return Db.Delete(sql, true, parms);
        }
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, InvoiceFormNumberEntity> Make = reader =>
        new InvoiceFormNumberEntity
        {

            InvoiceFormNumberId = reader["InvoiceFormNumberID"].AsGuid().AsString(),
            InvoiceFormNumberCode = reader["InvoiceFormNumberCode"].AsString(),
            InvoiceFormNumberName = reader["InvoiceFormNumberName"].AsString(),
            InvoiceType = reader["InvoiceTypeID"].AsInt(),
            IsSystem = reader["IsSystem"].AsBool(),
            IsActive = reader["IsActive"].AsBool()
        };

        /// <summary>
        /// Takes the specified invoice form number entity.
        /// </summary>
        /// <param name="invoiceFormNumberEntity">The invoice form number entity.</param>
        /// <returns></returns>
        private static object[] Take(InvoiceFormNumberEntity invoiceFormNumberEntity)
        {
            return new object[]
            {
                "@InvoiceFormNumberID", invoiceFormNumberEntity.InvoiceFormNumberId,
                "@InvoiceFormNumberCode", invoiceFormNumberEntity.InvoiceFormNumberCode,
                "@InvoiceFormNumberName", invoiceFormNumberEntity.InvoiceFormNumberName,
                "@InvoiceTypeID", invoiceFormNumberEntity.InvoiceType,
                "@IsSystem", invoiceFormNumberEntity.IsSystem,
                "@IsActive", invoiceFormNumberEntity.IsActive
            };
        }
    }
}
