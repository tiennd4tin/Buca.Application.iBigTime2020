using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.View.System;

namespace Buca.Application.iBigTime2020.Presenter.System.UserProfile
{
    public class DashBoardCashPresenter : Presenter<IDashBoardCashView>
    {
        public DashBoardCashPresenter(IDashBoardCashView view)
            : base(view)
        {
        }
        public void Display(int month, int year)
        {
            View.DashBoardCash = Model.GetDashBoardCashModels(month, year);
        }

        public void Refresh(int month, int year)
        {
            View.DashBoardCash = Model.GetDashBoardCashModels(month, year);
        }
    }
}
