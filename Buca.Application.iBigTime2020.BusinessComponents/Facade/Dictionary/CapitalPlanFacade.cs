using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class CapitalPlanFacade
    {
        private static readonly ICapitalPlanDao CapitalPlanDao = DataAccess.DataAccess.CapitalPlanDao;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CapitalPlanId"></param>
        /// <returns></returns>
        public CapitalPlanEntity GetCapitalPlan(string CapitalPlanId)
        {
            return CapitalPlanDao.GetCapitalPlan(CapitalPlanId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CapitalPlanEntity> GetCapitalPlans()
        {
            return CapitalPlanDao.GetAllCapitalPlan();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capitalPlan"></param>
        /// <returns></returns>
        public CapitalPlanResponse InsertCapitalPlan(CapitalPlanEntity capitalPlan)
        {
            var response = new CapitalPlanResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var CapitalPlan = CapitalPlanDao.GetCapitalPlanByCode(capitalPlan.CapitalPlanCode);
                if (CapitalPlan != null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã " + CapitalPlan.CapitalPlanCode + @" đã tồn tại!";

                    return response;
                }
                capitalPlan.CapitalPlanId = Guid.NewGuid().ToString();
                response.Message = CapitalPlanDao.InsertCapitalPlan(capitalPlan);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.CapitalPlanId = capitalPlan.CapitalPlanId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capitalPlan"></param>
        /// <returns></returns>
        public CapitalPlanResponse UpdateCapitalPlan(CapitalPlanEntity capitalPlan)
        {
            var response = new CapitalPlanResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var CapitalPlan = CapitalPlanDao.GetCapitalPlanByCode(capitalPlan.CapitalPlanCode);
                if (CapitalPlan != null && capitalPlan.CapitalPlanId != CapitalPlan.CapitalPlanId)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã " + CapitalPlan.CapitalPlanCode + @" đã tồn tại!";

                    return response;
                }
                //CapitalPlan.CapitalPlanId = Guid.NewGuid().ToString();
                response.Message = CapitalPlanDao.UpdateCapitalPlan(capitalPlan);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.CapitalPlanId = CapitalPlan.CapitalPlanId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CapitalPlanId"></param>
        /// <returns></returns>
        public CapitalPlanResponse DeleteCapitalPlan(string CapitalPlanId)
        {
            var response = new CapitalPlanResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var CapitalPlan = CapitalPlanDao.GetCapitalPlan(CapitalPlanId);

                response.Message = CapitalPlanDao.DeleteCapitalPlan(CapitalPlanId);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK")
                    )
                        response.Message = @"Bạn không thể xóa kế hoạch " + CapitalPlan.CapitalPlanCode + " , vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.CapitalPlanId = CapitalPlanId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
