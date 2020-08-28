using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Opening
{
    public class OpeningAccountEntryReponse : ResponseBase
    {
        public OpeningAccountEntryEntity OpeningAccountEntry { get; set; }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
    }
}
