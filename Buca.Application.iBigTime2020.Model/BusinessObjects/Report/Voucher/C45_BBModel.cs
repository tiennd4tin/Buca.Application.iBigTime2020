using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher
{
    public class C45_BBModel
    {
        public string RefId { get; set; }
        public DateTime RefDate { get; set; }
        public DateTime PostedDate { get; set; }
        public string RefNo { get; set; }
        public string OutwardRefNo { get; set; }
        public string AccountingObjectContactName { get; set; }
        public string JournalMemo { get; set; }
        public decimal TotalAmount { get; set; }
        public string Address { get; set; }
    }
}
