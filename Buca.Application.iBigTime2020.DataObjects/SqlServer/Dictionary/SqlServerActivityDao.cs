﻿using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    public class SqlServerActivityDao : IActivityDao
    {
        public ActivityEntity GetActivity(string activityId)
        {
            const string sql = @"uspGet_Activity_ByID";

            object[] parms = { "@ActivityId", activityId };
            return Db.Read(sql, true, Make, parms);
        }

        public List<ActivityEntity> GetActivitys()
        {
            const string procedures = @"uspGet_All_Activity";
            return Db.ReadList(procedures, true, Make);
        }


        public List<ActivityEntity> GetActivitysByActive(bool isActive)
        {
            const string sql = @"uspGet_Activity_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        public List<ActivityEntity> GetActivityByCode(string activityCode)
        {
            const string sql = @"uspGet_Activity_ByCode";

            object[] parms = { "@ActivityCode", activityCode };
            return Db.ReadList(sql, true, Make, parms);
        }
        public string InsertActivity(ActivityEntity activity)
        {
            const string sql = @"uspInsert_Activity";
            return Db.Insert(sql, true, Take(activity));
        }

        public string UpdateActivity(ActivityEntity activity)
        {
            const string sql = @"uspUpdate_Activity";
            return Db.Update(sql, true, Take(activity));
        }

        public string DeleteActivity(ActivityEntity activity)
        {
            const string sql = @"uspDelete_Activity";

            object[] parms = { "@ActivityId", activity.ActivityId };
            return Db.Delete(sql, true, parms);
        }
        public string DeleteActivityConvert( )
        {
            const string sql = @"usp_ConvertCareerWork";

            object[] parms = {};
            return Db.Delete(sql, true, parms);
        }

        private static readonly Func<IDataReader, ActivityEntity> Make = reader =>
           new ActivityEntity
           {
               ActivityId = reader["ActivityID"].AsString(),
               ActivityCode = reader["ActivityCode"].AsString(),
               ActivityName = reader["ActivityName"].AsString(),
               ParentID = reader["ParentID"].AsString(),
               IsActive = reader["IsActive"].AsBool(),
               IsParent = reader["IsParent"].AsBool(),
               IsSystem = reader["IsSystem"].AsBool(),
               Grade = reader["Grade"].AsInt()
           };

        private static object[] Take(ActivityEntity activity)
        {
            return new object[]
            {
               "@ActivityId", activity.ActivityId,
               "@ActivityCode", activity.ActivityCode,
               "@ActivityName",activity.ActivityName,
               "@ParentID",activity.ParentID,
               "@IsActive",activity.IsActive,
               "@IsParent",activity.IsParent,
               "@Grade",activity.Grade,
               "@IsSystem",activity.IsSystem
            };
        }

    }
}
