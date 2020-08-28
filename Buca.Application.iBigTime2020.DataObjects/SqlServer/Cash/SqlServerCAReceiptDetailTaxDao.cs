/***********************************************************************
 * <copyright file="SqlCAReceiptDetailTax.cs" company="BUCA JSC">
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
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataHelpers;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Cash
{
    /// <summary>
    /// SqlCAReceiptDetailTax class
    /// </summary>
    public class SqlServerCAReceiptDetailTaxDao : ICAReceiptDetailTaxDao
    {
        /// <summary>
        /// Gets the ca receipt details by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;CAReceiptDetailTaxEntity&gt;.</returns>
        public List<CAReceiptDetailTaxEntity> GetCAReceiptDetailTaxesByRefId(string refId)
        {
            const string procedures = @"uspGet_CAReceiptDetailTax_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);

        }

        /// <summary>
        /// Inserts the ca receipt detail.
        /// </summary>
        /// <param name="receiptDetailEntity">The receipt detail entity.</param>
        /// <returns>System.String.</returns>
        public string InsertCAReceiptDetailTax(CAReceiptDetailTaxEntity receiptDetailEntity)
        {
            const string procedures = @"uspInsert_CAReceiptDetailTax";
            return Db.Insert(procedures, true, Take(receiptDetailEntity));
        }

        /// <summary>
        /// Deletes the ca receipt detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteCAReceiptDetailTaxByRefId(string refId)
        {
            const string procedures = @"uspDelete_CAReceiptDetailTax_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }
     
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CAReceiptDetailTaxEntity> Make = reader =>
           new CAReceiptDetailTaxEntity
           {
               RefDetailId = reader["RefDetailId"].AsString(),
               RefId = reader["RefId"].AsString(),
               Description = reader["Description"].AsString(),
               VATAmount = reader["VATAmount"].AsDecimal(),
               VATRate = reader["VATRate"].AsDecimalForNull(),
               TurnOver = reader["TurnOver"].AsDecimal(),
               InvType = reader["InvType"].AsInt(),
               InvDate = reader["InvDate"].AsDateTimeForNull(),
               InvSeries = reader["InvSeries"].AsString(),
               InvNo = reader["InvNo"].AsString(),
               PurchasePurposeId = reader["PurchasePurposeId"].AsString(),
               AccountingObjectId = reader["AccountingObjectId"].AsString(),
               CompanyTaxCode = reader["CompanyTaxCode"].AsString(),
               SortOrder = reader["SortOrder"].AsInt(),
               InvoiceTypeCode = reader["InvoiceTypeCode"].AsString()
           };

        /// <summary>
        /// Takes the specified information.
        /// </summary>
        /// <param name="cAReceiptDetailTaxEntity">The c a receipt detail tax entity.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(CAReceiptDetailTaxEntity cAReceiptDetailTaxEntity)
        {
            return new object[]
            {
                "@RefDetailId",cAReceiptDetailTaxEntity.RefDetailId,
                "@RefId",cAReceiptDetailTaxEntity.RefId,
                "@Description",cAReceiptDetailTaxEntity.Description,
                "@VATAmount",cAReceiptDetailTaxEntity.VATAmount,
                "@VATRate",cAReceiptDetailTaxEntity.VATRate,
                "@TurnOver",cAReceiptDetailTaxEntity.TurnOver,
                "@InvType",cAReceiptDetailTaxEntity.InvType,
                "@InvDate",cAReceiptDetailTaxEntity.InvDate,
                "@InvSeries",cAReceiptDetailTaxEntity.InvSeries,
                "@InvNo",cAReceiptDetailTaxEntity.InvNo,
                "@PurchasePurposeId",cAReceiptDetailTaxEntity.PurchasePurposeId,
                "@AccountingObjectId",cAReceiptDetailTaxEntity.AccountingObjectId,
                "@CompanyTaxCode",cAReceiptDetailTaxEntity.CompanyTaxCode,
                "@SortOrder",cAReceiptDetailTaxEntity.SortOrder,
                "@InvoiceTypeCode",cAReceiptDetailTaxEntity.InvoiceTypeCode
            };
        }
    }
}
