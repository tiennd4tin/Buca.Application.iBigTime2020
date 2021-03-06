﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher
{
    public class C2_02a_NSDetailModel
    {
        public  string Memo { get; set; }
        public string BudgetSubItemCode { get; set; }
        public  string BudgetChapterCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string BudgetSourceCode { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountTax { get; set; }
        public decimal AmountNet { get; set; }
        public int CashWithDrawType { get; set; }
    }
}
