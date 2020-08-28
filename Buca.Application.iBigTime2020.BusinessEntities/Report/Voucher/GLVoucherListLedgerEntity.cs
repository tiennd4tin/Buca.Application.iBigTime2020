using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    public class GLVoucherListLedgerEntity : BusinessEntities

    {

        public string RefDetailId { get; set; }
        public string RefId { get; set; }
        public string RefNo { get; set; }
        public string Description { get; set; }        
        public string BudgetSourceCode { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime RefDate { get; set; }
        public string AccountNumber { get; set; }
        public string CorrespondingAccount { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public string BudgetSourceId { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public DateTime StartOfMonth { get; set; }
    }
}