using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Inventory
{
   public class ToolIncrementDecrementModel
    {
        public string InventoryItemId { get; set; }
        public string InventoryItemCode { get; set; }
        public string InventoryItemName { get; set; }
        public string Unit { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string InventoryCategoryId { get; set; }
        public string InventoryCategoryName { get; set; }
        public decimal OPeningQuantity { get; set; }
        public decimal OPeningAmount { get; set; }
        public decimal IncreaseQuantity { get; set; }
        public decimal IncreaseAmount { get; set; }
        public decimal DecreaseQuantity { get; set; }
        public decimal DecreaseAmount { get; set; }
        public decimal ClosingQuantity { get; set; }
        public decimal ClosingAmount { get; set; }
        public int Stt { get; set; }
    }
}

