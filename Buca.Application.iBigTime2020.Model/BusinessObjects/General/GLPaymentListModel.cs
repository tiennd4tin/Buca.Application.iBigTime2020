using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.General
{
    public class GLPaymentListModel
    {
        public string RefId { get; set; }

        public int RefType { get; set; }

        public DateTime RefDate { get; set; }
        public DateTime PostedDate { get; set; }

        public string RefNo { get; set; }

        public string VoucherTypeId { get; set; }

        public int SetupType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Description { get; set; }

        public decimal TotalAmount { get; set; }

        public int EditVersion { get; set; }

        public IList<GLPaymentListDetailModel> GLPaymentListDetails { get; set; }
    }
}
