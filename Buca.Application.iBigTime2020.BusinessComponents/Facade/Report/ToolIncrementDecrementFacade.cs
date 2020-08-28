using Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Report
{
   public class ToolIncrementDecrementFacade
    {
        private static readonly IToolIncrementDecrementDao ToolIncrementDecrementDao = DataAccess.DataAccess.ToolIncrementDecrementDao;
        public IList<ToolIncrementDecrementEntity> ReportToolIncrementDecrementEntitiesToolIncrementDecrement(DateTime fromDate, DateTime toDate, string departmentId,
            string inventoryItemId )
        {
            return ToolIncrementDecrementDao.ReportToolIncrementDecrementEntitiesToolIncrementDecrement(fromDate, toDate, departmentId, inventoryItemId);
        }
    }
}
