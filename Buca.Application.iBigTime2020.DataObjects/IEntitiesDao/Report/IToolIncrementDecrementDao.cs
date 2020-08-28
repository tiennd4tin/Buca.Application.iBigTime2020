using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report
{
   public interface  IToolIncrementDecrementDao
   {
       IList<ToolIncrementDecrementEntity> ReportToolIncrementDecrementEntitiesToolIncrementDecrement(DateTime fromDate,DateTime toDate,string departmentId,string inventoryItemId);
   }
}
