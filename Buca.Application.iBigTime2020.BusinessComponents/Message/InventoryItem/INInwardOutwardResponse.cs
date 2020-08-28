using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.InventoryItem
{
    /// <summary>
    /// Class INInwardOutwardResponse.
    /// </summary>
    public class INInwardOutwardResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the in inward outward.
        /// </summary>
        /// <value>The in inward outward.</value>
        public INInwardOutwardEntity INInwardOutward { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
    }
}
