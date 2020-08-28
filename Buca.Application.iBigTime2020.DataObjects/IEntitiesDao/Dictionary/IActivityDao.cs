using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    public interface IActivityDao
    {
        ActivityEntity GetActivity(string activityId);
        List<ActivityEntity> GetActivitys();
        List<ActivityEntity> GetActivitysByActive(bool isActive);
        List<ActivityEntity> GetActivityByCode(string activityCode); 
        string InsertActivity(ActivityEntity activity);
        string UpdateActivity(ActivityEntity activity);
        string DeleteActivity(ActivityEntity activity);

        string DeleteActivityConvert();
    }
}
