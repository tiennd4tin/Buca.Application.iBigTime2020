
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class InventoryItemResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the inventory item entity.
        /// </summary>
        /// <value>The inventory item entity.</value>
        public InventoryItemEntity InventoryItemEntity { get; set; }

        /// <summary>
        /// Gets or sets the inventory item identifier.
        /// </summary>
        /// <value>The inventory item identifier.</value>
        public string InventoryItemId { get; set; }
    }
}
