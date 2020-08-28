using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Deposit
{
    public class BABankTransferResponse : ResponseBase
    {
        public BABankTransferEntity BABankTransferEntity { get; set; }
        public string RefId { get; set; }
    }
}
