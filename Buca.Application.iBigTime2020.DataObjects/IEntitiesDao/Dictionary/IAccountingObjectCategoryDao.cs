using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    public interface IAccountingObjectCategoryDao
    {
        List<AccountingObjectCategoryEntity> GetAccountingObjectCategories();
        AccountingObjectCategoryEntity GetAccountingObjectCategory(string accountingObjectCategoryId);
    }
}
