using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.General
{
    public class GLPaymentListEntity : BusinessEntities
    {
        public GLPaymentListEntity()
        {
            AddRule(new ValidateRequired("RefType"));
            AddRule(new ValidateRequired("RefDate"));
        }
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

        public IList<GLPaymentListDetailEntity> GLPaymentListDetails { get; set; }
    }
}
