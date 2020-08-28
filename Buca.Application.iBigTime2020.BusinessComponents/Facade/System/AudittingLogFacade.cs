using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using System.Linq;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary

{
    public class AudittingLogFacade
    {
        private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;

        public AudittingLogResponse InsertAudittingLog(AudittingLogEntity audittingLogEntity)
        {
            var response = new AudittingLogResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!audittingLogEntity.Validate())
                {
                    foreach (string error in audittingLogEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                audittingLogEntity.EventId = Guid.NewGuid().ToString();

                response.Message = AudittingLogDao.InsertAudittingLog(audittingLogEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.EventId = audittingLogEntity.EventId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }


        public IList<AudittingLogEntity> GetAudittingLogs()
        {

            return AudittingLogDao.GetAudittingLogs();
        }

    }
}
