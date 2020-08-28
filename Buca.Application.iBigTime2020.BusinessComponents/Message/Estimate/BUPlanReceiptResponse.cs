using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate
{
   public class BUPlanReceiptResponse:ResponseBase
    {

        public BUPlanReceiptEntity BUPlanReceipt { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
    }
}
