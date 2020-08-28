using Buca.Application.iBigTime2020.BusinessEntities.Business.PUInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.PUInvoice
{
    public class PUInvoiceResponse : ResponseBase
    {
        public PUInvoiceEntity PUInvoiceRequest { get; set; }
        public string RefId { get; set; }
    }
}
