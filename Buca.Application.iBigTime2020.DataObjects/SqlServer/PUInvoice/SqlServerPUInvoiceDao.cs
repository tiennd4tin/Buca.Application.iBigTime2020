using Buca.Application.iBigTime2020.BusinessEntities.Business.PUInvoice;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.PUInvoice;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.PUInvoice
{
    public class SqlServerPUInvoiceDao : DaoBase, IPUInvoiceDao
    {
        public List<PUInvoiceEntity> GetPUInvoicesByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_PUInvoice_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make<PUInvoiceEntity>, parms);
        }

        public List<PUInvoiceEntity> GetPUInvoices( )
        {
            const string procedures = @"uspGet_PUInvoices";
            object[] parms = { };
            return Db.ReadList(procedures, true, Make<PUInvoiceEntity>, parms);
        }
        public PUInvoiceEntity GetPUInvoice(string refId)
        {
            const string procedures = @"uspGet_PUInvoice_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.Read(procedures, true, Make<PUInvoiceEntity>, parms);
        }

        public PUInvoiceEntity GetPUInvoiceByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_PUInvoice_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make<PUInvoiceEntity>, parms);
        }

        public string UpdatePUInvoice(PUInvoiceEntity entity)
        {
            const string procedures = @"uspInsert_PUInvoice";
            return Db.Insert(procedures, true, Take(entity));
        }

        public string DeletePUInvoice(string refId)
        {
            const string procedures = @"uspDelete_PUInvoice";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        private static object[] Take(PUInvoiceEntity entity)
        {
            return new object[]
            {
                "@RefID",entity.RefId,
                "@RefType",entity.RefType,
                "@RefDate",entity.RefDate,
                "@PostedDate",entity.PostedDate,
                "@RefNo",entity.RefNo,
                "@IncrementRefNo",entity.IncrementRefNo,
                "@AccountingObjectId",entity.AccountingObjectId,
                "@CompanyTaxCode",entity.CompanyTaxCode,
                "@AccountingObjectContactName",entity.AccountingObjectContactName,
                "@JournalMemo",entity.JournalMemo,
                "@TotalAmount",entity.TotalAmount,
                "@TotalTaxAmount",entity.TotalTaxAmount,
                "@TotalAmountOC",entity.TotalAmountOC,
                "@CurrencyCode",entity.CurrencyCode,
                "@ExchangeRate",entity.ExchangeRate,
            };
        }
    }
}
