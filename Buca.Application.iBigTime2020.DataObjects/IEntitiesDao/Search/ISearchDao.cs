using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Search;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Search
{
   public interface ISearchDao
   {
       IList<SearchEntity> GetSearch(string whereClause, string fromDate, string toDate, string currencyCode,string departmentCode,string fixedAssetCode, string budgetGroupCode);
   }
}
