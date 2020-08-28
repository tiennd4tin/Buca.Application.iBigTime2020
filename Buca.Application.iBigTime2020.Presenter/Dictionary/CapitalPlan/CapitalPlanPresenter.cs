using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan
{
    public class CapitalPlanPresenter : Presenter<ICapitalPlanView>
    {
        public CapitalPlanPresenter(ICapitalPlanView view) : base(view) { }
        public void Display(string capitalplanId)
        {
            var capitalplan = Model.GetCapitalPlan(capitalplanId);
            View.CapitalPlanId = capitalplan.CapitalPlanId;
            View.CapitalPlanCode = capitalplan.CapitalPlanCode;
            View.CapitalPlanName = capitalplan.CapitalPlanName;
            View.IsActive = capitalplan.IsActive;
        }
        public string Save()
        {
            var capitalplan = new CapitalPlanModel
            {
                CapitalPlanId = View.CapitalPlanId,
                CapitalPlanCode = View.CapitalPlanCode,
                CapitalPlanName = View.CapitalPlanName,
                IsActive = View.IsActive,
            };
            return string.IsNullOrEmpty(View.CapitalPlanId) ? Model.AddCapitalPlan(capitalplan) : Model.UpdateCapitalPlan(capitalplan);
        }
        public string Delete(string capitalplanId)
        {
            return Model.DeleteCapitalPlan(capitalplanId);
        }

        public bool CodeIsExist(string p)
        {
            return Model.GetCapitalPlans().Where(x => x.CapitalPlanCode == p).Count() > 0;
        }
    }
}
