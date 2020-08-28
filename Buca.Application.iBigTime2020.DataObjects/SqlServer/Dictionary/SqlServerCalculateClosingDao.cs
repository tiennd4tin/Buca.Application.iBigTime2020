using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    public class SqlServerCalculateClosingDao : ICalculateClosingDao
    {

        private static readonly Func<IDataReader, CalculateClosingEntity> Make = reader =>
       new CalculateClosingEntity
       {
           ClosingAmounts = reader["ClosingAmount"].AsDecimal(),
           
       };

        public CalculateClosingEntity AmountExist(string accountCode, string currentcyCode)
        {
            throw new NotImplementedException();
        }


        public CalculateClosingEntity GetCalculateClosing(string PaymentAccountCode, string currentcyCode, DateTime toDate, string RefId, int RefTypeId)
        {
            const string procedures = @"uspPaymentCalculateClosing";
            object[] parms =
            {
                "@AccountNumber", PaymentAccountCode,
                "@CurrencyCode", currentcyCode,
                "@AmountType", 2,
                "@ToDate", toDate,
                "@RefID",RefId,
                "@RefTypeID",RefTypeId,

            };
            return Db.Read(procedures, true, Make, parms);
        }
    }

}

