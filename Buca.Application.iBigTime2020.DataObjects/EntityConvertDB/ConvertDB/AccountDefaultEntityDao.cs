using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class AccountDefaultEntityDao : IEntityAccountDefaultDao
    {

        public List<RefTypeEntity> GetAccountsDefault(string connectionString)
        {
            List<RefTypeEntity> listAccount = new List<RefTypeEntity>();
            using (var context = new MISAEntity(connectionString))
            {

                var lstaccountDefault = context.RefTypes.ToList();
                foreach (var result in lstaccountDefault)
                {
                    var accountDefault = new RefTypeEntity();
                    accountDefault.RefTypeId = result.RefType1;
                    accountDefault.RefTypeName = result.RefTypeName;
                    accountDefault.FunctionId = result.FunctionID;
                    accountDefault.RefTypeCategoryId = result.RefTypeCategory;
                    accountDefault.MasterTableName = result.MasterTableName;
                    accountDefault.DetailTableName = result.DetailTableName;
                    accountDefault.LayoutMaster = result.LayoutMaster;
                    accountDefault.LayoutDetail = result.LayoutDetail;
                    accountDefault.DefaultDebitAccountCategoryId = result.DefaultDebitAccountCategoryID;
                    accountDefault.DefaultDebitAccountId = result.DefaultDebitAccountID;
                    accountDefault.DefaultCreditAccountCategoryId = result.DefaultCreditAccountCategoryID;
                    accountDefault.DefaultCreditAccountId = result.DefaultCreditAccountID;
                    accountDefault.DefaultTaxAccountCategoryId = result.DefaultTaxAccountCategoryID;
                    accountDefault.DefaultTaxAccountId = result.DefaultTaxAccountID;
                    accountDefault.AllowDefaultSetting = result.AllowDefaultSetting;
                    accountDefault.Postable = result.Postable;
                    accountDefault.Searchable = result.Searchable;
                    accountDefault.SortOrder = result.SortOrder;
                    accountDefault.SubSystem = result.SubSystem;

                    listAccount.Add(accountDefault);

                }


            }

            return listAccount;
        }


    }
}
