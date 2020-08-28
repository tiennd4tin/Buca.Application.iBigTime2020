
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate
{
    /// <summary>
    /// Class BUPlanWithdrawResponse.
    /// </summary>
    public class BUPlanWithdrawResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the bu plan withdraw.
        /// </summary>
        /// <value>The bu plan withdraw.</value>
        public BUPlanWithdrawEntity BUPlanWithdraw { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
    }
}
