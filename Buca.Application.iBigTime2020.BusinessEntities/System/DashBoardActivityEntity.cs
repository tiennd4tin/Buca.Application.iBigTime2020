using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.System
{
    public class DashBoardActivityEntity
    {
        public int Time { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expense { get; set; }
        public decimal Differences { get; set; }
    }
}
