using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class CapitalPlanResponse : ResponseBase
    {
        public IList<CapitalPlanEntity> CapitalPlans;
        public CapitalPlanEntity CapitalPlan;
        public string CapitalPlanId { get; set; }
    }
}
