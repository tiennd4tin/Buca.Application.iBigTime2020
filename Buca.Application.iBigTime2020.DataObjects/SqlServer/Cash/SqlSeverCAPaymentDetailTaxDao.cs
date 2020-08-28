using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Cash
{
    public class SqlSeverCAPaymentDetailTaxDao : ICAPaymentDetailTaxDao
    {
        public string DeleteCAPaymentDetailTax(string refId)
        {
            const string procedures = @"uspDelete_CAPaymentDetailTax_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        public List<CAPaymentDetailTaxEntity> GetCaPaymentDetailTaxByRefId(string refId)
        {
            const string procedures = @"uspGet_CAPaymentDetailTax_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public string InsertCAPaymentDetailTax(CAPaymentDetailTaxEntity paymentDetailTaxEntity)
        {
            const string procedures = @"uspInsert_CAPaymentDetailTax";
            return Db.Insert(procedures, true, Take(paymentDetailTaxEntity));
        }

        public string UpdateCAPaymentDetailTax(CAPaymentDetailTaxEntity paymentDetailTaxEntity)
        {
            return null;

        }

        private static readonly Func<IDataReader, CAPaymentDetailTaxEntity> Make = reader =>
   new CAPaymentDetailTaxEntity
   {
       RefDetailId = reader["RefDetailID"].AsString(),
       RefId = reader["RefID"].AsString(),
       Description = reader["Description"].AsString(),
       VATAmount = reader["VATAmount"].AsDecimal(),
       VATRate = reader["VATRate"].AsDecimalForNull(),
       TurnOver = reader["TurnOver"].AsDecimal(),
       InvType = reader["InvType"].AsInt(),
       InvDate = reader["InvDate"].AsDateTimeForNull(),
       InvSeries = reader["InvSeries"].AsString(),
       InvNo = reader["InvNo"].AsString(),
       PurchasePurposeId = reader["PurchasePurposeID"].AsString(),
       AccountingObjectId = reader["AccountingObjectID"].AsString(),
       CompanyTaxCode = reader["CompanyTaxCode"].AsString(),
       SortOrder = reader["SortOrder"].AsInt(),
       InvoiceTypeCode = reader["InvoiceTypeCode"].AsString(),

   };
        private static object[] Take(CAPaymentDetailTaxEntity cAPaymentDetailTaxEntity)
        {
            return new object[]
            {

                "@RefDetailID", cAPaymentDetailTaxEntity.RefDetailId,
                "@RefID", cAPaymentDetailTaxEntity.RefId,
                "@Description", cAPaymentDetailTaxEntity.Description,
                "@VATAmount", cAPaymentDetailTaxEntity.VATAmount,
                "@VATRate", cAPaymentDetailTaxEntity.VATRate,
                "@TurnOver", cAPaymentDetailTaxEntity.TurnOver,
                "@InvType", cAPaymentDetailTaxEntity.InvType,
                "@InvDate", cAPaymentDetailTaxEntity.InvDate,
                "@InvSeries", cAPaymentDetailTaxEntity.InvSeries,
                "@InvNo", cAPaymentDetailTaxEntity.InvNo,
                "@PurchasePurposeID", cAPaymentDetailTaxEntity.PurchasePurposeId,
                "@AccountingObjectID", cAPaymentDetailTaxEntity.AccountingObjectId,
                "@CompanyTaxCode", cAPaymentDetailTaxEntity.CompanyTaxCode,
                "@SortOrder", cAPaymentDetailTaxEntity.SortOrder,
                "@InvoiceTypeCode", cAPaymentDetailTaxEntity.InvoiceTypeCode,
            };
        }

    }
}
