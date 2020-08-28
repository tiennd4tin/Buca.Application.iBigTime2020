using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.View.System;

namespace Buca.Application.iBigTime2020.Presenter.System.UserProfile
{
    public class UserControlMainDesktopPresenter : Presenter<IUserControlMainDesktopView>
    {
        public UserControlMainDesktopPresenter(IUserControlMainDesktopView view)
            : base(view)
        {
        }
        public void Display(int year)
        {
            View.UserControlMainDesktop1 = Model.GetUserControlModel(year);
        }

        public void Refresh(int year)
        {
            View.UserControlMainDesktop1 = Model.GetUserControlModel(year);
        }
    }
}
