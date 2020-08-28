using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial
{
    public class S34H_GL_Master_LineDetailEntity : BusinessEntities
    {
        public string AccountNumber { get; set; }
        public int AccountCategoryKind { get; set; }
        public string AccountingObjectId { get; set; }
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public int MonthYear { get; set; }
        public int MonthPeriod { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public IList<S34H_GL_Detail_SubDetailEntity> GL_Detail_SubDetail { get; set; }
    }
}
