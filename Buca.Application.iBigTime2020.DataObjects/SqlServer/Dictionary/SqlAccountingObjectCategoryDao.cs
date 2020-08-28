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
    public class SqlAccountingObjectCategoryDao : IAccountingObjectCategoryDao 
    {
        public List<AccountingObjectCategoryEntity> GetAccountingObjectCategories()
        {
            const string sql = @"uspGet_All_AccountingObjectCategory";
            return Db.ReadList(sql, true, Make);
        }

        public AccountingObjectCategoryEntity GetAccountingObjectCategory(string accountingObjectCategoryId)
        {

            const string sql = @"uspGet_AccountingObjectCategory_ByID";
            object[] parms = { "@AccountingObjectCategoryID", accountingObjectCategoryId };
            return Db.Read(sql, true, Make, parms);
        }
        private static readonly Func<IDataReader, AccountingObjectCategoryEntity> Make = reader =>
           new AccountingObjectCategoryEntity
           {
               AccountingObjectCategoryId = reader["AccountingObjectCategoryID"].AsString(),
               AccountingObjectCategoryCode = reader["AccountingObjectCategoryCode"].AsString(),
               AccountingObjectCategoryName = reader["AccountingObjectCategoryName"].AsString(),
               IsActive = reader["IsActive"].AsBool(),
               IsSystem  = reader["IsSystem"].AsBool()
           };

        private static object[] Take(AccountingObjectCategoryEntity accountingObjectCategoryEntity)
        {
            return new object[]
            {
                "@AccountingObjectCategoryId", accountingObjectCategoryEntity.AccountingObjectCategoryId,
                "@AccountingObjectCategoryCode", accountingObjectCategoryEntity.AccountingObjectCategoryCode,
                "@AccountingObjectCategoryName", accountingObjectCategoryEntity.AccountingObjectCategoryName,
                "@IsActive", accountingObjectCategoryEntity.IsActive,
                "@IsSystem",accountingObjectCategoryEntity.IsSystem
            };
        }
    }
}
