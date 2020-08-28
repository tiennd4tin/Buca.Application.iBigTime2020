using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial
{
    public class S34H_GL_Detail_SubDetailEntity : BusinessEntities
    {
        public string RefId { get; set; }
        public int RefType { get; set; }
        public string RefNo { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime RefDate { get; set; }
        public string JournalMemo { get; set; }
        public string Description { get; set; }
        public string AccountNumber { get; set; }
        public string CorrespondingAccountNumber { get; set; }
        public int AccountCategoryKind { get; set; }
        public string AccountingObjectId { get; set; }
        public int MonthYear { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal Amount { get; set; }
        public int ItemCode { get; set; }
        public int SortOrder { get; set; }
    }
}
