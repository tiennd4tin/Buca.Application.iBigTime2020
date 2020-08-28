using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.View.System;

namespace Buca.Application.iBigTime2020.Presenter.System.UserProfile
{
    public class DashBoardActivityPresenter : Presenter<IDashBoardActivityView>
    {
        public DashBoardActivityPresenter(IDashBoardActivityView view)
            : base(view)
        {
        }
        public void Display(int year)
        {
            View.DashBoardAcitity = Model.GetDashBoardAcitityModels(year);
        }

        public void Refresh(int year)
        {
            View.DashBoardAcitity = Model.GetDashBoardAcitityModels(year);
        }
    }
}
