using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using System.Linq;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;
using Buca.Application.iBigTime2020.BusinessEntities.System;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary

{
    public class FeaturePermisionFacade
    {
        private static readonly IFeaturePermisionDao FeaturePermisionDao = DataAccess.DataAccess.FeaturePermisionDao;


        public FeaturePermisionResponse DeleteFeaturePermision(string FeatureID)
        {
            var response = new FeaturePermisionResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                //xóa quyền cũ trước khi phân quyền
                response.Message = FeaturePermisionDao.DeleteFeaturePermision(FeatureID);
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public FeaturePermisionResponse InsertFeaturePermision(FeaturePermisionEntity featurePermision)
        {
            var featurePermisionResponse = new FeaturePermisionResponse { Acknowledge = AcknowledgeType.Success };
            if (featurePermision != null)
            {
                if (!featurePermision.Validate())
                {
                    foreach (string error in featurePermision.ValidationErrors)
                        featurePermisionResponse.Message += error + Environment.NewLine;
                    featurePermisionResponse.Acknowledge = AcknowledgeType.Failure;
                    return featurePermisionResponse;
                }
                if (string.IsNullOrEmpty(featurePermision.FeaturePermisionID))
                    featurePermision.FeaturePermisionID = Guid.NewGuid().ToString();

                featurePermisionResponse.Message = FeaturePermisionDao.InsertFeaturePermision(featurePermision);
                featurePermisionResponse.FeaturePermisionID = featurePermision.FeaturePermisionID;

                if (!string.IsNullOrEmpty(featurePermisionResponse.Message))
                {
                    featurePermisionResponse.Acknowledge = AcknowledgeType.Failure;
                    return featurePermisionResponse;
                }
            }
            return featurePermisionResponse;
        }


    }
}
