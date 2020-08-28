
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Cash
{
    public class CAReceiptResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the cash.
        /// </summary>
        /// <value>The cash.</value>
        public CAReceiptEntity CAReceipt { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
    }
}
