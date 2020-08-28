using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class ContractResponse : ResponseBase
    {
        public ContractEntity ContractEntity { get; set; }
        public string ContractId { get; set; }
    }
}
