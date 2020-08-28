using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.System;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System
{
    public interface IUserControlMainDesktopDao
    {
        List<UserControlMainDesktopEntity> GetUserControlMainDesktop(int year);
        List<DashBoardBudgetEntity> GetBoardBudget(int year);
        List<DashBoardCashEntity> GetDashBoardCash(int month, int year);
        List<DashBoardActivityEntity> GetDashBoardActivity(int year);
    }
}
