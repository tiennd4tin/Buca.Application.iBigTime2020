using Buca.Application.iBigTime2020.BusinessComponents.Messages.MessageBase;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class CalculateClosingRequest : RequestBase
    {

        public CalculateClosingEntity calculateClosing;

        public string PaymentAccountId { get; set; }

        public string CreditAccount { get; set; }

        public string WhereClause { get; set; }

        public string CurrencyCode { get; set; }

        public string CurrencyId { get; set; }

        public DateTime ToDate { get; set; }

        public bool IsApproximate { get; set; }

        public string RefId { get; set; }

        public int RefTypeId { get; set; }
    }
}
