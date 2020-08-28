using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class TaxTypeResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the tax type entity.
        /// </summary>
        /// <value>The tax type entity.</value>
        public TaxTypeEntity TaxTypeEntity { get; set; }
        /// <summary>
        /// Gets or sets the tax type identifier.
        /// </summary>
        /// <value>The tax type identifier.</value>
        public string TaxTypeId { get; set; }
    }
}
