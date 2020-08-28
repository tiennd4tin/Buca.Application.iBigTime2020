using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    public class SqlServerCapitalPlanDao : DaoBase, ICapitalPlanDao
    {
        public List<CapitalPlanEntity> GetAllCapitalPlan()
        {
            const string sql = @"uspCapitalPlan_GetAll";
            return Db.ReadList(sql, true, Make< CapitalPlanEntity>);
        }

        public CapitalPlanEntity GetCapitalPlan(string capitalplanId)
        {
            const string sql = @"uspCapitalPlan_Get_ByCapitalPlanID";
            object[] parms = { "@CapitalPlanID", capitalplanId };
            return Db.Read(sql, true, Make< CapitalPlanEntity>, parms);
        }

        public CapitalPlanEntity GetCapitalPlanByCode(string capitalplanCode)
        {
            const string sql = @"uspCapitalPlan_Get_ByCapitalPlanCode";
            object[] parms = { "@CapitalPlanCode", capitalplanCode };
            return Db.Read(sql, true, Make<CapitalPlanEntity>, parms);
        }

        public string InsertCapitalPlan(CapitalPlanEntity capitalPlan)
        {
            const string sql = "uspCapitalPlan_Insert";
            return Db.Insert(sql, true, Take(capitalPlan));
        }
        public string UpdateCapitalPlan(CapitalPlanEntity capitalPlan)
        {
            const string sql = "uspCapitalPlan_Update";
            return Db.Update(sql, true, Take(capitalPlan));
        }
        public string DeleteCapitalPlan(string capitalPlanId)
        {
            const string sql = "uspCapitalPlan_Delete_ByCapitalPlanID";
            //Sua lai tham so nay
            object[] parms = { "@CapitalPlanID", capitalPlanId};
            return Db.Delete(sql, true, parms);
        }
    }
}
