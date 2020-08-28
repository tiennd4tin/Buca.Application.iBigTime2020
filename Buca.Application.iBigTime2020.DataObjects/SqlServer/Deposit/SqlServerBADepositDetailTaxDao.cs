/***********************************************************************
 * <copyright file="SqlServerBADepositDetailTaxDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 18, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit
{
    /// <summary>
    ///     SqlServerBADepositDetailTaxDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit.IBADepositDetailTaxDao" />
    public class SqlServerBADepositDetailTaxDao : IBADepositDetailTaxDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BADepositDetailTaxEntity> Make = reader =>
            new BADepositDetailTaxEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                Description = reader["Description"].AsString(),
                VATAmount = reader["VATAmount"].AsDecimal(),
                VATRate = reader["VATRate"].AsDecimal(),
                TurnOver = reader["TurnOver"].AsDecimal(),
                InvType = reader["InvType"].AsInt(),
                InvDate = reader["InvDate"].AsString().AsDateTimeForNull(),
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
        /// Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<BADepositDetailTaxEntity> GetBADepositDetailTaxsByRefId(string refId)
        {
            const string procedures = @"uspGet_BADepositDetailTax_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bADepositDetailTax">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertBADepositDetailTax(BADepositDetailTaxEntity bADepositDetailTax)
        {
            const string sql = @"uspInsert_BADepositDetailTax";
            return Db.Insert(sql, true, Take(bADepositDetailTax));
        }

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public string DeleteBADepositDetailTaxByRefId(string refId)
        {
            const string procedures = @"uspDelete_BADepositDetailTax_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified bADeposit.
        /// </summary>
        /// <param name="bADepositDetailTaxEntity">The b a deposit detail sale entity.</param>
        /// <returns></returns>
        private static object[] Take(BADepositDetailTaxEntity bADepositDetailTaxEntity)
        {
            return new object[]
            {
                "@RefDetailID", bADepositDetailTaxEntity.RefDetailId,
                "@RefID", bADepositDetailTaxEntity.RefId,
                "@Description", bADepositDetailTaxEntity.Description,
                "@VATAmount", bADepositDetailTaxEntity.VATAmount,
                "@VATRate", bADepositDetailTaxEntity.VATRate,
                "@TurnOver", bADepositDetailTaxEntity.TurnOver,
                "@InvType", bADepositDetailTaxEntity.InvType,
                "@InvDate", bADepositDetailTaxEntity.InvDate,
                "@InvSeries", bADepositDetailTaxEntity.InvSeries,
                "@InvNo", bADepositDetailTaxEntity.InvNo,
                "@PurchasePurposeID", bADepositDetailTaxEntity.PurchasePurposeId,
                "@AccountingObjectID", bADepositDetailTaxEntity.AccountingObjectId,
                "@AccountingObjectName", bADepositDetailTaxEntity.AccountingObjectName,
                "@AccountingObjectAddress", bADepositDetailTaxEntity.AccountingObjectAddress,
                "@CompanyTaxCode", bADepositDetailTaxEntity.CompanyTaxCode,
                "@SortOrder", bADepositDetailTaxEntity.SortOrder,
                "@InvoiceTypeCode", bADepositDetailTaxEntity.InvoiceTypeCode
            };
        }
    }
}