using Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    public class SqlServerToolIncrementDecrementDao : IToolIncrementDecrementDao
    {
     

        public IList<ToolIncrementDecrementEntity> ReportToolIncrementDecrementEntitiesToolIncrementDecrement(DateTime fromDate, DateTime toDate, string departmentId, string inventoryItemId)
        {
            const string sql = @"uspReport_IncreDecreSupply";
            object[] parms =
            {
                "@fromDate", fromDate,
                "@toDate", toDate,
                "@pDepartmentID", departmentId,
                "@pInventoryIDs", inventoryItemId,
            };


            Func<IDataReader, ToolIncrementDecrementEntity> make = reader =>
              new ToolIncrementDecrementEntity
              {
                  InventoryItemId = reader["InventoryItemId"].AsString(),
                  InventoryItemCode = reader["InventoryItemCode"].AsString(),
                  InventoryItemName = reader["InventoryItemName"].AsString(),
                  Unit = reader["Unit"].AsString(),
                  DepartmentId = reader["DepartmentId"].AsString(),
                  DepartmentName = reader["DepartmentName"].AsString(),
                  InventoryCategoryId = reader["InventoryItemCategoryID"].AsString(),
                  InventoryCategoryName = reader["InventoryItemCategoryName"].AsString(),
                  OPeningQuantity = reader["EarlyPeriodQty"].AsDecimal(),
                  OPeningAmount = reader["EarlyPeriodAmount"].AsDecimal(),
                  IncreaseQuantity = reader["IncreInPeriodQty"].AsDecimal(),
                  IncreaseAmount = reader["IncreInPeriodAmount"].AsDecimal(),
                  DecreaseQuantity = reader["DecreInPeriodQty"].AsDecimal(),
                  DecreaseAmount = reader["DecreInPeriodAmount"].AsDecimal(),
                  ClosingQuantity = reader["EndPeriodQty"].AsDecimal(),
                  ClosingAmount = reader["EnndPeriodAmount"].AsDecimal(),
                  Stt = reader["Stt"].AsId()
              };

            return Db.ReadList(sql, true, make, parms);
        }
    }
}
