using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    public interface ICapitalPlanDao
    {
        List<CapitalPlanEntity> GetAllCapitalPlan();
        CapitalPlanEntity GetCapitalPlan(string capitalplan);
        CapitalPlanEntity GetCapitalPlanByCode(string capitalplanCode);
        string InsertCapitalPlan(CapitalPlanEntity capitalPlan);
        string UpdateCapitalPlan(CapitalPlanEntity capitalPlan);
        string DeleteCapitalPlan(string capitalPlanId);
    }
}
