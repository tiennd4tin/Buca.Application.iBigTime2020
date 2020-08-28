
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class DBOptionResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the database option entity.
        /// </summary>
        /// <value>The database option entity.</value>
        public DBOptionEntity DBOptionEntity { get; set; }

        /// <summary>
        /// Gets or sets the option identifier.
        /// </summary>
        /// <value>The option identifier.</value>
        public string OptionId { get; set; }
    }
}
