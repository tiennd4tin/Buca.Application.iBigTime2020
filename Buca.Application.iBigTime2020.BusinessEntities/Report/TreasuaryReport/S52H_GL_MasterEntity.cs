﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.TreasuaryReport
{
    public class S52H_GL_MasterEntity : BusinessEntities
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string PartName { get; set; }
        public int MonthYear { get; set; }
        public int PartId { get; set; }
        public decimal Amount { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal ReceiptAmount { get; set; }
        public decimal RevenueAmount { get; set; }
        public decimal SuperiorPaymentAmount { get; set; }
        public decimal OtherPaymentAmount { get; set; }
        public IList<GL_Master_DetailEntity> GL_Master_Detail { get; set; }
    }
}
