using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.System
{
    public class UserControlMainDesktopModel
    {
        public decimal WithDraw { get; set; }
        public decimal Cancel { get; set; }
        public decimal Remaining { get; set; }
        public string BudgetSourceName { get; set; }
        public string BudgetSourceCode { get; set; }
        public string BudgetSourceId { get; set; }
    }
}
