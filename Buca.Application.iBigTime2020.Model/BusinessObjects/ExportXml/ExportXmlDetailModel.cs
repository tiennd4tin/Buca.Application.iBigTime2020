using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.ExportXml
{
  public   class ExportXmlDetailModel
    {
        public int RefType { get; set; }
        public string RefID { get; set; }
        public string RefDetailID { get; set; }
        public string RefNo { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime RefDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

    }
}
