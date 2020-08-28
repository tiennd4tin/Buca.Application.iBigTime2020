using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit
{
    public class SqlServerBAWithdrawDetailTaxDao:IBAWithdrawDetailTaxDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BAWithdrawDetailTaxEntity> Make = reader =>
            new BAWithdrawDetailTaxEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                Description = reader["Description"].AsString(),
                VATAmount = reader["VATAmount"].AsDecimal(),
                VATRate = reader["VATRate"].AsDecimal(),
                TurnOver = reader["TurnOver"].AsDecimal(),
                InvType = reader["InvType"].AsInt(),
                InvDate = reader["InvDate"].AsDateTimeForNull(),
                InvSeries = reader["InvSeries"].AsString(),
                InvNo = reader["InvNo"].AsString(),
                PurchasePurposeId = reader["PurchasePurposeID"].AsString(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                CompanyTaxCode = reader["CompanyTaxCode"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                InvoiceTypeCode = reader["InvoiceTypeCode"].AsString()
            };

        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<BAWithdrawDetailTaxEntity> GetBAWithdrawDetailTaxEntitysByRefId(string refId)
        {
            const string procedures = @"uspGet_BAWithdrawDetailTax_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bAWithdrawDetailTax">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertBAWithdrawDetailTaxEntity(BAWithdrawDetailTaxEntity bAWithdrawDetailTax)
        {
            const string sql = @"uspInsert_BAWithdrawDetailTax";
            return Db.Insert(sql, true, Take(bAWithdrawDetailTax));
        }

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public string DeleteBAWithdrawDetailTaxEntityByRefId(string refId)
        {
            const string procedures = @"uspDelete_BAWithdrawDetailTax_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified bADeposit.
        /// </summary>
        /// <param name="bAWithdrawDetailTaxEntity">The b a with draw detail purchase entity.</param>
        /// <returns></returns>
        private object[] Take(BAWithdrawDetailTaxEntity bAWithdrawDetailTaxEntity)
        {
            return new object[]
            {
                "@RefDetailID",bAWithdrawDetailTaxEntity.RefDetailId,
                "@RefID",bAWithdrawDetailTaxEntity.RefId,
                "@Description",bAWithdrawDetailTaxEntity.Description,
                "@VATAmount",bAWithdrawDetailTaxEntity.VATAmount,
                "@VATRate",bAWithdrawDetailTaxEntity.VATRate,
                "@TurnOver",bAWithdrawDetailTaxEntity.TurnOver,
                "@InvType",bAWithdrawDetailTaxEntity.InvType,
                "@InvDate",bAWithdrawDetailTaxEntity.InvDate,
                "@InvSeries",bAWithdrawDetailTaxEntity.InvSeries,
                "@InvNo",bAWithdrawDetailTaxEntity.InvNo,
                "@PurchasePurposeID",bAWithdrawDetailTaxEntity.PurchasePurposeId,
                "@AccountingObjectID",bAWithdrawDetailTaxEntity.AccountingObjectId,
                "@CompanyTaxCode",bAWithdrawDetailTaxEntity.CompanyTaxCode,
                "@SortOrder",bAWithdrawDetailTaxEntity.SortOrder,
                "@InvoiceTypeCode",bAWithdrawDetailTaxEntity.InvoiceTypeCode
            };
        }
    }
}