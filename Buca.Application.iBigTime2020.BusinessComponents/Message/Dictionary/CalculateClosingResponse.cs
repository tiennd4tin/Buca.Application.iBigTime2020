using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class CalculateClosingResponse : ResponseBase
    {
        public CalculateClosingEntity CalculateClosing;
        public int CalculateClosingId { get; set; }
    }
}
