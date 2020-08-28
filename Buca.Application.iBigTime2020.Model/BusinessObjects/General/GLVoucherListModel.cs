using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.General
{
   public class GLVoucherListModel
    {
        public string RefId { get; set; }

        public int RefType { get; set; }

        public string RefNo { get; set; }

        public DateTime RefDate { get; set; }

        public string VoucherTypeId { get; set; }

        public int SetupType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Description { get; set; }

        public decimal TotalAmount { get; set; }

        public int EditVersion { get; set; }

        public IList<GLVoucherListDetailModel> GlVoucherListDetails { get; set; }
    }
}
