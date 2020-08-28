using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;

namespace Buca.Application.iBigTime2020.View.Cash
{
    /// <summary>
    /// Class CAPaymentDetailParallelModel.
    /// </summary>
    public interface ICAPaymentDetailParallels
    {
        /// <summary>
        /// Sets the ca payment detail parallels.
        /// </summary>
        /// <value>The ca payment detail parallels.</value>
        IList<CAPaymentDetailParallelModel> CAPaymentDetailParallels { set; }
    }
}
