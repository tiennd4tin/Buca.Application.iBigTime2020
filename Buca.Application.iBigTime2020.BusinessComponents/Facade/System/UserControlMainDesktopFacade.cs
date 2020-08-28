using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.System;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.System
{
    public class UserControlMainDesktopFacade
    {
        private static readonly IUserControlMainDesktopDao UserControlDao = DataAccess.DataAccess.UserControlMainDesktopDao;

        public IList<UserControlMainDesktopEntity> GetUserControlMainDesktop(int year)
        {
            return UserControlDao.GetUserControlMainDesktop(year);
        }
        public IList<DashBoardBudgetEntity> GetDashBoardBudget(int year)
        {
            return UserControlDao.GetBoardBudget(year);
        }
        public IList<DashBoardCashEntity> GetDashBoardCash(int month, int year)
        {
            return UserControlDao.GetDashBoardCash(month, year);
        }
        public IList<DashBoardActivityEntity> GetDashBoardActivity(int year)
        {
            return UserControlDao.GetDashBoardActivity(year);
        }
    }
}
