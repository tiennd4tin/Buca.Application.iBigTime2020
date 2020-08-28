using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    public interface ICapitalPlanView : IView
    {
        string CapitalPlanId { get; set; }
        string CapitalPlanCode { get; set; }
        string CapitalPlanName { get; set; }
        int PlanYear { get; set; }
        int PlanTypeId { get; set; }
        DateTime? FromDate { get; set; }
        DateTime? ToDate { get; set; }
        bool IsActive { get; set; }

    }
}
