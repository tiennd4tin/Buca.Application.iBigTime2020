﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.System
{
    public class DashBoardBudgetEntity
    {
        public decimal BudgetRecive { get; set; }
        public decimal BudgetGive { get; set; }
        public decimal Remaining { get; set; }
        public string BudgetSourceName { get; set; }
        public string BudgetSourceCode { get; set; }
        public string BudgetSourceId { get; set; }
    }
}
