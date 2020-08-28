using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class BankResponse : ResponseBase
    {
        public BankEntity BankEntity { get; set; }
        public string BankId { get; set; }
    }
}
