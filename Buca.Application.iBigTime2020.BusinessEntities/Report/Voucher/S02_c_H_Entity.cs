using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    public class S02_c_H_Entity : BusinessEntities

    {

        public string BudgetChapterCode { get; set; }
        public string BudgetSourceCode { get; set; }
        public string BudgetSourceName { get; set; }
        public string BudgetSubKindItemCode { get; set; }        
        public string RefID { get; set; }
        public string RefType { get; set; }
        public string RefNo { get; set; }
        public DateTime RefDate { get; set; }
        public string Description { get; set; }
        public string CorrespondingAccountNumber { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public string AccountNumber { get; set; }
        public decimal OpeningAmount { get; set; }
        public decimal AccumDebitAmountQuater { get; set; }
        public decimal AccumCreditAmountQuater { get; set; }
        public decimal AccumDebitAmountYear { get; set; }
        public decimal AccumCreditAmountYear { get; set; }
        public string Month { get; set; }
        public DateTime BeginMonth { get; set; }
        public DateTime BeginQuarter { get; set; }
        public string AccountCategoryKind { get; set; }
        public string Grade { get; set; }
        public string AccLevel { get; set; }
    }
}