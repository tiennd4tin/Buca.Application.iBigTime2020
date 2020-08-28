using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Cash
{

    /// <summary>
    /// Class CAPaymentResponse.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessComponents.Message.ResponseBase" />
    public class CAPaymentResponse :ResponseBase
    {
        /// <summary>
        /// Gets or sets the ca payment.
        /// </summary>
        /// <value>The ca payment.</value>
        public CAPaymentEntity CaPayment { get; set; }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
    }

}