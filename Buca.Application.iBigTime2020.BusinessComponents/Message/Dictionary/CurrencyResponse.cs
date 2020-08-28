using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class CurrencyResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the account transfer.
        /// </summary>
        /// <value>The account transfer.</value>
        public CurrencyEntity CurrencyEntity { get; set; }

        /// <summary>
        /// Gets or sets the account transfer identifier.
        /// </summary>
        /// <value>The account transfer identifier.</value>
        public string CurrencyId { get; set; }
    }
}
