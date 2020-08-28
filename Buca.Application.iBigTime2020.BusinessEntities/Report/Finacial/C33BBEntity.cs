using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial
{
    public class C33BBEntity : BusinessEntities
    {
        public int Part { get; set; }
        public int SortOrder { get; set; }
        public string AccountingObjectId { get; set; }
        public string AccountingObjectName { get; set; }
        public string RefNo { get; set; }
        public string AccountingObjectAddress { get; set; }
        public string Description { get; set; }
        public string RefId { get; set; }
        public DateTime RefDate { get; set; }
        public DateTime PostedDate { get; set; }
        public decimal Amount { get; set; }
        public string LineDetail { get; set; }
        public bool IsBold { get; set; }
    }
}
