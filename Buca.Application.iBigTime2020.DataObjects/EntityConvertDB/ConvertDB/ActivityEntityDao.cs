using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class ActivityEntityDao : IEntityActivityDao
    {
       
       public  List<ActivityEntity> GetActivity(string connectionString)
        {  
            List<ActivityEntity> listActivity = new List<ActivityEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.Activities.ToList();
                foreach (var result in categories)
                {
                    var activity = new ActivityEntity();
                    activity.ActivityId = result.ActivityID.ToString();
                    activity.ActivityCode = result.ActivityCode;
                    activity.ActivityName = result.ActivityName;
                    activity.ParentID = result.ParentID.ToString();
                    activity.Grade = result.Grade;
                    activity.IsParent = result.IsParent;
                    activity.IsSystem = result.IsSystem;
                    activity.IsActive = result.Inactive ==true?false:true;


                    listActivity.Add(activity);

                }

               
            }

            return listActivity;
        }

      
    }
}
