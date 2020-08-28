using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class AccountingObjectCategoryFacade
    {
        private static readonly IAccountingObjectCategoryDao AccountingObjectCategoryDao = DataAccess.DataAccess.AccountingObjectCategoryDao;
        public IList<AccountingObjectCategoryEntity> GetAccountingObjectCategories()
        {
            return AccountingObjectCategoryDao.GetAccountingObjectCategories();
        }
    }
}
