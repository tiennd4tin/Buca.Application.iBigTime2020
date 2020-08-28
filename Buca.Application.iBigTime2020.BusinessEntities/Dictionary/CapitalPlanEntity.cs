using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    public class CapitalPlanEntity
    {
        public string CapitalPlanId { get; set; }
        public string CapitalPlanCode { get; set; }
        public string CapitalPlanName { get; set; }
        public int PlanYear { get; set; }
        public int PlanTypeId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsActive { get; set; }
    }
}
