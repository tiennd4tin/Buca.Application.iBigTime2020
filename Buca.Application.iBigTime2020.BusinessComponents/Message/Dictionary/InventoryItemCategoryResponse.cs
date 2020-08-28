
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class InventoryItemCategoryResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the inventory item category entity.
        /// </summary>
        /// <value>The inventory item category entity.</value>
        public InventoryItemCategoryEntity InventoryItemCategoryEntity { get; set; }

        /// <summary>
        /// Gets or sets the inventory item category identifier.
        /// </summary>
        /// <value>The inventory item category identifier.</value>
        public string InventoryItemCategoryId { get; set; }
    }
}
