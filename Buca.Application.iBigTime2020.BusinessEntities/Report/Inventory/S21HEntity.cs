using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory
{
    /// <summary>
    /// Class S22HEntity.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class S21HEntity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo { get; set; }
        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime RefDate { get; set; }
        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime PostedDate { get; set; }
        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo { get; set; }
        /// <summary>
        /// Gets or sets the stock identifier.
        /// </summary>
        /// <value>The stock identifier.</value>
        public string StockId { get; set; }
        /// <summary>
        /// Gets or sets the stock code.
        /// </summary>
        /// <value>The stock code.</value>
        public string StockCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the stock.
        /// </summary>
        /// <value>The name of the stock.</value>
        public string StockName { get; set; }
        /// <summary>
        /// Gets or sets the inventory item identifier.
        /// </summary>
        /// <value>The inventory item identifier.</value>
        public string InventoryItemId { get; set; }
        /// <summary>
        /// Gets or sets the inventory item code.
        /// </summary>
        /// <value>The inventory item code.</value>
        public string InventoryItemCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the inventory item.
        /// </summary>
        /// <value>The name of the inventory item.</value>
        public string InventoryItemName { get; set; }
        /// <summary>
        /// Gets or sets the type of the order.
        /// </summary>
        /// <value>The type of the order.</value>
        public int OrderType { get; set; }
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public string Unit { get; set; }
        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// Gets or sets the inward amount.
        /// </summary>
        /// <value>The inward amount.</value>
        public decimal InwardAmount { get; set; }
        /// <summary>
        /// Gets or sets the inward quantity.
        /// </summary>
        /// <value>The inward quantity.</value>
        public decimal InwardQuantity { get; set; }
        /// <summary>
        /// Gets or sets the outward amount.
        /// </summary>
        /// <value>The outward amount.</value>
        public decimal OutwardAmount { get; set; }
        /// <summary>
        /// Gets or sets the outward quantity.
        /// </summary>
        /// <value>The outward quantity.</value>
        public decimal OutwardQuantity { get; set; }
        /// <summary>
        /// Gets or sets the closing amount.
        /// </summary>
        /// <value>The closing amount.</value>
        public decimal ClosingAmount { get; set; }
        /// <summary>
        /// Gets or sets the closing quantity.
        /// </summary>
        /// <value>The closing quantity.</value>
        public decimal ClosingQuantity { get; set; }
        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int RefOrder { get; set; }
        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int Month { get; set; }
        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int RefTypeOrder { get; set; }
        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public string InventoryItemDescription { get; set; }
        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public DateTime FromDateInCurrentMonth { get; set; }
        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public DateTime ToDateInCurrentMonth { get; set; }
        public int AccumulatedIn { get; set; } // số lũy kế nhập
        public int AccumulatedOut { get; set; } // số lũy kế xuất
    }
}
