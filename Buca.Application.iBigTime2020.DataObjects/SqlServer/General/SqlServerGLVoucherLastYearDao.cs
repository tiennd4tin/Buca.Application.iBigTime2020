/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.General
{
    /// <summary>
    /// SqlServerGLVoucherDao
    /// </summary>
    public class SqlServerGLVoucherLastYearDao : IGLVoucherLastYearDao
    {
        /// <summary>
        /// Gets the ca payment entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public GLVoucherEntity GetGLVoucherByRefId(string refId)
        {
            const string procedures = @"uspGet_GLVoucher_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the ca payment entityby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public GLVoucherEntity GetGLVoucherByRefNo(string refNo, int refType)
        {
            const string procedures = @"uspGet_GLVoucher_ByRefNo";

            object[] parms = { "@RefID", refNo, "@RefType", refType };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the ca payment.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public GLVoucherEntity GetGLVoucher(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_GLVoucher_ByRefNoAndPostedDate";

            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the ca payment.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<GLVoucherEntity> GetGLVouchers()
        {
            const string procedures = @"uspGet_All_GLVoucher";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the ca payments by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<GLVoucherEntity> GetGLVouchersByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_GLVouchers_ByRefTypeId";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public List<GLVoucherEntity> GetGLVouchersLastYearByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_GLVouchersLastYear_ByRefTypeId";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }
        /// <summary>
        /// Inserts the ca payment.
        /// </summary>
        /// <param name="glVoucher">The ca payment.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string InsertGLVoucher(GLVoucherEntity glVoucher)
        {
            const string sql = @"uspInsert_GLVoucher";
            return Db.Insert(sql, true, Take(glVoucher));
        }

        /// <summary>
        /// Updates the ca payment.
        /// </summary>
        /// <param name="glVoucher">The ca payment.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string UpdateGLVoucher(GLVoucherEntity glVoucher)
        {
            const string sql = @"uspUpdate_GLVoucher";
            return Db.Update(sql, true, Take(glVoucher));
        }

        /// <summary>
        /// Deletes the ca payment.
        /// </summary>
        /// <param name="glVoucher">The ca payment.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string DeleteGLVoucher(GLVoucherEntity glVoucher)
        {
            const string sql = @"uspDelete_GlVoucher";

            object[] parms = { "@RefID", glVoucher.RefId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, GLVoucherEntity> Make = reader =>
        new GLVoucherEntity
        {
            RefId = reader["RefID"].AsString(),
            RefType = reader["RefType"].AsInt(),
            RefDate = reader["RefDate"].AsDateTime(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            RefNo = reader["RefNo"].AsString(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            ParalellRefNo = reader["ParalellRefNo"].AsString(),
            JournalMemo = reader["JournalMemo"].AsString(),
            TotalAmount = reader["TotalAmount"].AsDecimal(),
            TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
            ParentRefId = reader["ParentRefID"].AsString(),
            Posted = reader["Posted"].AsBool(),
            PostVersion = reader["PostVersion"].AsInt(),
            EditVersion = reader["EditVersion"].AsInt(),
            AdvancePaymentOrder = reader["AdvancePaymentOrder"].AsInt(),
            BUTransferRefId = reader["BUTransferRefID"].AsString(),
            BUTransferType =reader["BUTransferType"].AsInt()
        };

        /// <summary>
        /// Takes the specified f a depreciation entity.
        /// </summary>
        /// <param name="glVoucherEntity">The gl voucher entity.</param>
        /// <returns></returns>
        private object[] Take(GLVoucherEntity glVoucherEntity)
        {
            return new object[]  
            {
                "@RefID",glVoucherEntity.RefId,
		        "@RefType",glVoucherEntity.RefType,
		        "@RefDate",glVoucherEntity.RefDate,
		        "@PostedDate",glVoucherEntity.PostedDate,
		        "@RefNo",glVoucherEntity.RefNo,
		        "@CurrencyCode",glVoucherEntity.CurrencyCode,
		        "@ExchangeRate",glVoucherEntity.ExchangeRate,
		        "@ParalellRefNo",glVoucherEntity.ParalellRefNo,
		        "@JournalMemo",glVoucherEntity.JournalMemo,
		        "@TotalAmount",glVoucherEntity.TotalAmount,
		        "@TotalAmountOC",glVoucherEntity.TotalAmountOC,
		        "@ParentRefID",glVoucherEntity.ParentRefId,
		        "@Posted",glVoucherEntity.Posted,
		        "@PostVersion",glVoucherEntity.PostVersion,
		        "@EditVersion",glVoucherEntity.EditVersion,
		        "@AdvancePaymentOrder",glVoucherEntity.AdvancePaymentOrder,
                "@BUTransferRefID",glVoucherEntity.BUTransferRefId,
                "@BUTransferType",glVoucherEntity.BUTransferType
            };
        }
    }
}
