
using System.Linq;
using Buca.Application.iBigTime2020.BusinessComponents.Messages.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.DataAccess;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class LockFacade
    {
        private static readonly ILockDao LockDao = DataAccess.DataAccess.LockDao;


        public LockResponse GetLock(LockRequest request)
        {
            var response = new LockResponse();
            response.Acknowledge = AcknowledgeType.Success;
            if (request.LoadOptions.Contains("Get"))
            {
                response.Lock = LockDao.GetLock();
                
            }
            if (request.LoadOptions.Contains("CheckPostedDate"))
            {
                response.Lock = LockDao.CheckLock(request.RefId, request.RefTypeId, request.RefDate);
            }

            if (request.LoadOptions.Contains("CheckRefID"))
            {
                response.Lock = LockDao.CheckLock(request.RefId, request.RefTypeId);
            }

            return response;
        }

        /// <summary>
        /// Sets the sites.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public LockResponse SetLock(LockRequest request)
        {
            var response = new LockResponse();

            if (request.LoadOptions.Contains("ExcuteLock"))
            {
                response.Message = LockDao.ExcuteUnLock(request.Lock);
            }

            return response;
        }
    }
}
