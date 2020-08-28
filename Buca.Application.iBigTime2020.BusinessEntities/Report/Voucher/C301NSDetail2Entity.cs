using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    public class C301NSDetail2Entity
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaymentInAmount { get; set; }
        public decimal PaymentOutAmount { get; set; }
        public int Sort { get; set; }
    }
}
