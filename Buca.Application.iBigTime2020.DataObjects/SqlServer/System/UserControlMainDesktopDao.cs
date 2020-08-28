using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;
using Buca.Application.iBigTime2020.DataHelpers;
using Buca.Application.iBigTime2020.BusinessEntities.System;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.System
{
    public class UserControlMainDesktopDao:IUserControlMainDesktopDao
    {
        #region DashBoard 1
        public List<UserControlMainDesktopEntity> GetUserControlMainDesktop(int year)
        {
            const string procedures = @"uspGet_Dashboard_Estimate";

            object[] parms = { "@Year", year };
            return Db.ReadList(procedures, true, Make, parms);
        }
        private static readonly Func<IDataReader, UserControlMainDesktopEntity> Make = reader =>
            new UserControlMainDesktopEntity
            {
                WithDraw = reader["WithDraw"].AsDecimal(),
                Cancel = reader["Cancel"].AsDecimal(),
                Remaining = reader["Remaining"].AsDecimal(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetSourceName = reader["BudgetSourceName"].AsString(),
            };
        private object[] Take(UserControlMainDesktopEntity usercontrol)
        {
            return new object[]
            {
                @"WithDraw", usercontrol.WithDraw,
                @"Cancel", usercontrol.Cancel,
                @"Remaining", usercontrol.Remaining,
                @"BudgetSourceID", usercontrol.BudgetSourceId,
                @"BudgetSourceCode", usercontrol.BudgetSourceCode,
                @"BudgetSourceName", usercontrol.BudgetSourceName
            };
        }
        #endregion

        #region DashBoard 2
        public List<DashBoardBudgetEntity> GetBoardBudget(int year)
        {
            const string procedures = @"uspGet_Dashboard_Budget";

            object[] parms = { "@Year", year };
            return Db.ReadList(procedures, true, Make2, parms);
        }
        private static readonly Func<IDataReader, DashBoardBudgetEntity> Make2 = reader =>
            new DashBoardBudgetEntity
            {
                BudgetGive = reader["BudgetGive"].AsDecimal(),
                BudgetRecive = reader["BudgetRecive"].AsDecimal(),
                Remaining = reader["Remaining"].AsDecimal(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                BudgetSourceName = reader["BudgetSourceName"].AsString(),
            };
        #endregion

        #region DashBoard 3
        public List<DashBoardCashEntity> GetDashBoardCash(int month, int year)
        {
            const string procedures = @"uspGet_Dashboard_Cash";

            object[] parms = { "@Month", month, "@Year", year };
            return Db.ReadList(procedures, true, Make3, parms);
        }
        private static readonly Func<IDataReader, DashBoardCashEntity> Make3 = reader =>
            new DashBoardCashEntity
            {

                PrevCash = reader["PrevCash"].AsDecimal(),
                PrevCashInBank = reader["PrevCashInBank"].AsDecimal(),
                PrevCashInTransit = reader["PrevCashInTransit"].AsDecimal(),
                PrevTime = reader["PrevTime"].AsDateTime(),
                ThisCash = reader["ThisCash"].AsDecimal(),
                ThisCashInBank = reader["ThisCashInBank"].AsDecimal(),
                ThisCashInTransit = reader["ThisCashInTransit"].AsDecimal(),
                ThisTime = reader["ThisTime"].AsDateTime(),
                NextCash = reader["NextCash"].AsDecimal(),
                NextCashInBank = reader["NextCashInBank"].AsDecimal(),
                NextCashInTransit = reader["NextCashInTransit"].AsDecimal(),
                NextTime = reader["NextTime"].AsDateTime(),
            };
        #endregion

        #region DashBoard 4
        public List<DashBoardActivityEntity> GetDashBoardActivity(int year)
        {
            const string procedures = @"uspGet_Dashboard_Activity";

            object[] parms = { "@Year", year };
            return Db.ReadList(procedures, true, Make4, parms);
        }
        private static readonly Func<IDataReader, DashBoardActivityEntity> Make4 = reader =>
            new DashBoardActivityEntity
            {

                Time = reader["Time"].AsInt(),
                Revenue = reader["Revenue"].AsDecimal(),
                Expense = reader["Expense"].AsDecimal(),
                Differences = reader["Differences"].AsDecimal(),
            };
        #endregion
    }
}
