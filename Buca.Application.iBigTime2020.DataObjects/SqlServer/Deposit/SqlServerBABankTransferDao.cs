using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit
{
    public class SqlServerBABankTransferDao : IBABankTransferDao
    {
        private static readonly Func<IDataReader, BABankTransferEntity> Make = reader =>
           new BABankTransferEntity
           {
               RefId = reader["RefID"].AsString(),
               RefType = reader["RefType"].AsInt(),
               RefDate = reader["RefDate"].AsDateTime(),
               PostedDate = reader["PostedDate"].AsDateTime(),
               RefNo = reader["RefNo"].AsString(),
               ParalellRefNo = reader["ParalellRefNo"].AsString(),
               JournalMemo = reader["JournalMemo"].AsString(),
               TotalAmount = reader["TotalAmount"].AsDecimal(),
               Posted = reader["Posted"].AsBool(),
               PostVersion = reader["PostVersion"].AsInt(),
               EditVersion = reader["EditVersion"].AsInt(),
               CurrencyCode = reader["CurrencyCode"].AsString(),
               ExchangeRate = reader["ExchangeRate"].AsDecimal(),
               TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),

           };

        private static object[] Take(BABankTransferEntity bABankTransferEntity)
        {
            return new object[]
            {

        "@RefID",bABankTransferEntity.RefId,
        "@RefType",bABankTransferEntity.RefType,
        "@RefDate",bABankTransferEntity.RefDate,
        "@PostedDate",bABankTransferEntity.PostedDate,
        "@RefNo",bABankTransferEntity.RefNo,
        "@ParalellRefNo",bABankTransferEntity.ParalellRefNo,
        "@JournalMemo",bABankTransferEntity.JournalMemo,
        "@TotalAmount",bABankTransferEntity.TotalAmount,
        "@Posted",bABankTransferEntity.Posted,
        "@PostVersion",bABankTransferEntity.PostVersion,
        "@EditVersion",bABankTransferEntity.EditVersion,
        "@CurrencyCode",bABankTransferEntity.CurrencyCode,
        "@ExchangeRate",bABankTransferEntity.ExchangeRate,
        "@TotalAmountOC",bABankTransferEntity.TotalAmountOC,
            };
        }

        public BABankTransferEntity GetBABankTransfer(string refId)
        {
            const string procedures = @"uspGet_BABankTransfer_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }
        public IList<BABankTransferEntity> GetBABankTransfers()
        {
            const string procedures = @"uspGet_All_BABankTransfer";
            return Db.ReadList(procedures, true, Make);
        }
        public BABankTransferEntity GetBABankTransferByRefNo(string refNo)
        {
            const string procedures = @"uspGet_BABankTransfer_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }
        public BABankTransferEntity GetBABankTransferByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_BABankTransfer_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }
        public string InsertBABankTransfer(BABankTransferEntity bABankTransfer)
        {
            const string sql = @"uspInsert_BABankTransfer";
            return Db.Insert(sql, true, Take(bABankTransfer));
        }
        public string UpdateBABankTransfer(BABankTransferEntity bABankTransfer)
        {
            const string sql = @"uspUpdate_BABankTransfer";
            return Db.Update(sql, true, Take(bABankTransfer));
        }
        public string DeleteBABankTransfer(BABankTransferEntity bABankTransfer)
        {
            const string sql = @"uspDelete_BABankTransfer";

            object[] parms = { "@RefID", bABankTransfer.RefId };
            return Db.Delete(sql, true, parms);
        }
    }

}
