using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Inventory
{
    public class InventoryBookModel
    {
        public string StockId { get; set; }
        public string InventoryItemId { get; set; }
        public decimal OpeningQuantity { get; set; }
        public decimal OpeningAmount { get; set; }
        public decimal InwardQuantity { get; set; }
        public decimal InwardAmount { get; set; }
        public decimal OutwardQuantity { get; set; }
        public decimal OutwardAmount { get; set; }
        public decimal ClosingQuantity { get; set; }
        public decimal ClosingAmount { get; set; }
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public string InventoryCategoryId { get; set; }
        public string InventoryCategoryCode { get; set; }
        public string InventoryCategoryName { get; set; }
        public string InventoryItemCode { get; set; }
        public string InventoryItemName { get; set; }
        public string Unit { get; set; }
    }
}
