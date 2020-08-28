using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.View.System;

namespace Buca.Application.iBigTime2020.Presenter.System.UserProfile
{
    public class DashBoardBudgetPresenter : Presenter<IDashBoardBudgetView>
    {
        public DashBoardBudgetPresenter(IDashBoardBudgetView view)
            : base(view)
        {
        }
        public void Display(int year)
        {
            View.DashBoardBudget = Model.GetDashBoardBudgetModels(year);
        }

        public void Refresh(int year)
        {
            View.DashBoardBudget = Model.GetDashBoardBudgetModels(year);
        }
    }
}
