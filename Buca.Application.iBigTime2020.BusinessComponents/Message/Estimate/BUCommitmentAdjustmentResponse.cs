using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate
{
    public class BUCommitmentAdjustmentResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the bu commitment request.
        /// </summary>
        /// <value>The bu commitment request.</value>
        public BUCommitmentAdjustmentEntity BUCommitmentAdjustment { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
    }
}
