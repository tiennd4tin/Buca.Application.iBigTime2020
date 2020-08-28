using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class TaxItemResponse : ResponseBase
    {
        public TaxItemEntity TaxItemEntity { get; set; }
        public string TaxItemId { get; set; }
    }
}
