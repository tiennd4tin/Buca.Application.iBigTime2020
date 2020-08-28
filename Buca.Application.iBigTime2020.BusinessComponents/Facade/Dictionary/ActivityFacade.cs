
using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using System.Data.SqlClient;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class ActivityFacade
    {
        private static readonly IActivityDao ActivityDao = DataAccess.DataAccess.ActivityDao;
        public ActivityEntity GetActivitys(string ActivityId)
        {

            return ActivityDao.GetActivity(ActivityId);
        }
        public IList<ActivityEntity> GetActivitys()
        {

            return ActivityDao.GetActivitys();
        }
        public IList<ActivityEntity> GetActivityByActive(bool isActive)
        {

            return ActivityDao.GetActivitysByActive(isActive);
        }
        public ActivityResponse InsertActivity(ActivityEntity Activity)
        {
            var response = new ActivityResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var activity = ActivityDao.GetActivityByCode(Activity.ActivityCode.Trim());
                if (activity.Count != 0)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã công việc " + Activity.ActivityCode.Trim() + @" đã tồn tại!";
                    return response;
                }
                if (!Activity.Validate())
                {
                    foreach (string error in Activity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                Activity.ActivityId = Guid.NewGuid().ToString();
                response.Message = ActivityDao.InsertActivity(Activity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.ActivityId = Activity.ActivityId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public ActivityResponse InsertActivityConvert(ActivityEntity Activity)
        {
            var response = new ActivityResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var activity = ActivityDao.GetActivityByCode(Activity.ActivityCode.Trim());
                if (activity.Count != 0)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã công việc " + Activity.ActivityCode.Trim() + @" đã tồn tại!";
                    return response;
                }
                if (!Activity.Validate())
                {
                    foreach (string error in Activity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
             
                response.Message = ActivityDao.InsertActivity(Activity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.ActivityId = Activity.ActivityId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public ActivityResponse UpdateActivity(ActivityEntity Activity)
        {
            var response = new ActivityResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!Activity.Validate())
                {
                    foreach (string error in Activity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = ActivityDao.UpdateActivity(Activity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.ActivityId = Activity.ActivityId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public ActivityResponse DeleteActivity(string ActivityId)
        {
            var response = new ActivityResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var ActivityEntity = ActivityDao.GetActivity(ActivityId);
                if (ActivityEntity.IsParent)
                {
                    response.Message = @"Bạn không thể xóa hoạt động cha !";
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = ActivityDao.DeleteActivity(ActivityEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK"))
                        response.Message = @"Bạn không thể xóa HĐSN " + ActivityEntity.ActivityCode + " , vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.ActivityId = ActivityEntity.ActivityId;
                return response;
            }
            catch (SqlException sqlException)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = sqlException.Message;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
        public ActivityResponse DeleteActivityConvert( )
        {
            var response = new ActivityResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
               
           
                response.Message = ActivityDao.DeleteActivityConvert();
                if (!string.IsNullOrEmpty(response.Message))
                {
                   
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                return response;
            }
            catch (SqlException sqlException)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = sqlException.Message;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
