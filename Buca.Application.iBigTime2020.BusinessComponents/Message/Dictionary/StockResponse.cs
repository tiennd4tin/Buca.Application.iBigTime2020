
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class StockResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the stock entity.
        /// </summary>
        /// <value>The stock entity.</value>
        public StockEntity StockEntity { get; set; }

        /// <summary>
        /// Gets or sets the stock identifier.
        /// </summary>
        /// <value>The stock identifier.</value>
        public string StockId { get; set; }
    }
}
