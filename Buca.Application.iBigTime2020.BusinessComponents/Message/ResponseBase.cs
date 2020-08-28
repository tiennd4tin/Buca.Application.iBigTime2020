using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message
{
    public class ResponseBase
    {
        public string Message { get; set; }

        public AcknowledgeType Acknowledge { get; set; }
    }
}
