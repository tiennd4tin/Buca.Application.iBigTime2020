using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan
{
    public class CapitalPlansPresenter : Presenter<ICapitalPlansView>
    {
        public CapitalPlansPresenter(ICapitalPlansView view)
            : base(view)
        {
        }
        public void Display()
        {
            View.CapitalPlans = Model.GetCapitalPlans();
        }

    }
}
