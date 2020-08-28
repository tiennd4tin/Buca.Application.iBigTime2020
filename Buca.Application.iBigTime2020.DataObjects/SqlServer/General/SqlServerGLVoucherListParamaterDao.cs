using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.General
{
    public class SqlServerGLVoucherListParamaterDao : IGLVoucherListParamaterDao
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">0: gọi từ chứng từ ghi sổ</param>
        /// <returns></returns>
        public List<GLVoucherListParamaterEntity> GetGlVoucherListParamater(int type)
        {
            string procedures = type.Equals(0) ? "uspGet_All_GLVoucherListParamater" : "uspGet_All_GLPaymentListParamater";
            return Db.ReadList(procedures, true, Make);
        }

        public List<GLVoucherListDetailEntity> GetGlVoucherListDetailParamaterFilter(string refTypeId, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }


        private static readonly Func<IDataReader, GLVoucherListParamaterEntity> Make = reader =>
   new GLVoucherListParamaterEntity
   {
       RefDetailId = reader["RefDetailID"].AsString(),
       RefId = reader["RefID"].AsString(),
       DetailRefType = reader["RefType"].AsInt(),
       RefDate = reader["RefDate"].AsDateTime(),
       PostedDate = reader["PostedDate"].AsDateTime(),
       RefNo = reader["RefNo"].AsString(),
       Description = reader["Description"].AsString(),
       DebitAccount = reader["DebitAccount"].AsString(),
       CreditAccount = reader["CreditAccount"].AsString(),
       Amount = reader["Amount"].AsDecimal(),
       AmountOC = reader["AmountOC"].AsDecimal(),
       OrgRefNo = reader["OrgRefNo"].AsString(),
       OrgRefDate = reader["OrgRefDate"].AsDateTime(),
       ProjectId = reader["ProjectId"].AsString(),
       BudgetSourceId = reader["BudgetSourceID"].AsString(),
       BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
       BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
       BudgetItemCode = reader["BudgetItemCode"].AsString(),
       BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
       CurrencyCode = reader["CurrencyCode"].AsString(),
       ExchangeRate = reader["ExchangeRate"].AsDecimal(),
   };
    }
}
