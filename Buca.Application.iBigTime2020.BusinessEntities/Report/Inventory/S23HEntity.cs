using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory
{
   public class S23HEntity :BusinessEntities
    {
        public string AccountNumber { get; set; }
        public string InventoryCategoryId { get; set; }
        public string InventoryCategoryCode { get; set; }
        public string InventoryCategoryName { get; set; }
        public string InventoryItemId { get; set; }
        public string InventoryItemCode { get; set; }
        public string InventoryItemName { get; set; }
        public decimal OpeningAmount { get; set; }
        public decimal InwardAmount { get; set; }
        public decimal OutwardAmount { get; set; }
        public decimal ClosingAmount { get; set; }
    }
}
