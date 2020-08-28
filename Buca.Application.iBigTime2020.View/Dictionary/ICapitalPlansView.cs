using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    public interface ICapitalPlansView : IView
    {
        IList<CapitalPlanModel> CapitalPlans { set; }
    }
}
