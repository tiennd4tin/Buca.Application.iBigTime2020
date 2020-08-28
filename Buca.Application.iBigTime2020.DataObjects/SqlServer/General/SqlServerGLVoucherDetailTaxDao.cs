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
    /// SqlServerGLVoucherDetailTaxDao
    /// </summary>
    public class SqlServerGLVoucherDetailTaxDao : IGLVoucherDetailTaxDao
    {
        /// <summary>
        /// Gets the fa armortization details by fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<GLVoucherDetailTaxEntity> GetGLVoucherDetailTaxesByGLVoucher(string refId)
        {
            const string procedures = @"uspGet_GLVoucherDetailTax_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the automatic fa armortization details by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="yearOfDeprecation">The year of deprecation.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<GLVoucherDetailTaxEntity> GetAutoGLVoucherDetailTaxesByCurrencyCode(string currencyCode, int yearOfDeprecation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the fa armortization detail.
        /// </summary>
        /// <param name="glVoucherDetailTax">The gl voucher detail tax.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string InsertGLVoucherDetailTax(GLVoucherDetailTaxEntity glVoucherDetailTax)
        {
            const string sql = @"uspInsert_GLVoucherDetailTax";
            return Db.Insert(sql, true, Take(glVoucherDetailTax));
        }

        /// <summary>
        /// Deletes the fa armortization detail by fa armortization identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string DeleteGLVoucherDetailTaxByRefId(string refId)
        {
            const string procedures = @"uspDelete_GLVoucherDetailTax_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, GLVoucherDetailTaxEntity> Make = reader =>
        new GLVoucherDetailTaxEntity
        {
            RefDetailId = reader["RefDetailID"].AsString(),
            RefId = reader["RefID"].AsString(),
            Description = reader["Description"].AsString(),
            VATAmount = reader["VATAmount"].AsDecimal(),
            VATRate = reader["VATRate"].AsDecimal(),
            TurnOver = reader["TurnOver"].AsDecimal(),
            InvType = reader["InvType"].AsInt(),
            InvDate = reader["InvDate"].AsDateTime(),
            InvSeries = reader["InvSeries"].AsString(),
            InvNo = reader["InvNo"].AsString(),
            PurchasePurposeId = reader["PurchasePurposeID"].AsString(),
            AccountingObjectId = reader["AccountingObjectID"].AsString(),
            AccountingObjectName = reader["AccountingObjectName"].AsString(),
            AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
            CompanyTaxCode = reader["CompanyTaxCode"].AsString(),
            SortOrder = reader["SortOrder"].AsInt(),
            InvoiceTypeCode = reader["InvoiceTypeCode"].AsString()
        };

        /// <summary>
        /// Takes the specified f a depreciation detail entity.
        /// </summary>
        /// <param name="glVoucherDetailTaxEntity">The f a depreciation detail entity.</param>
        /// <returns></returns>
        private static object[] Take(GLVoucherDetailTaxEntity glVoucherDetailTaxEntity)
        {
            return new object[]
                {

                    "@RefDetailID",glVoucherDetailTaxEntity.RefDetailId,
		            "@RefID",glVoucherDetailTaxEntity.RefId,
		            "@Description",glVoucherDetailTaxEntity.Description,
		            "@VATAmount",glVoucherDetailTaxEntity.VATAmount,
		            "@VATRate",glVoucherDetailTaxEntity.VATRate,
		            "@TurnOver",glVoucherDetailTaxEntity.TurnOver,
		            "@InvType",glVoucherDetailTaxEntity.InvType,
		            "@InvDate",glVoucherDetailTaxEntity.InvDate,
		            "@InvSeries",glVoucherDetailTaxEntity.InvSeries,
		            "@InvNo",glVoucherDetailTaxEntity.InvNo,
		            "@PurchasePurposeID",glVoucherDetailTaxEntity.PurchasePurposeId,
		            "@AccountingObjectID",glVoucherDetailTaxEntity.AccountingObjectId,
		            "@AccountingObjectName",glVoucherDetailTaxEntity.AccountingObjectName,
		            "@AccountingObjectAddress",glVoucherDetailTaxEntity.AccountingObjectAddress,
		            "@CompanyTaxCode",glVoucherDetailTaxEntity.CompanyTaxCode,
		            "@SortOrder",glVoucherDetailTaxEntity.SortOrder,
		            "@InvoiceTypeCode",glVoucherDetailTaxEntity.InvoiceTypeCode
                };
        }
    }
}
