using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    public class CalculateClosingFacade
    {
        private static readonly ICalculateClosingDao CalculateClosingDao = DataAccess.DataAccess.CalculateClosingDao;

        public CalculateClosingResponse GetCalculateClosing(CalculateClosingRequest request)
        {
            var response = new CalculateClosingResponse();
            if (request.LoadOptions.Contains("CalculateClosing"))
            {
                response.CalculateClosing = CalculateClosingDao.GetCalculateClosing(request.PaymentAccountId, request.CurrencyCode, request.ToDate,request.RefId,request.RefTypeId);
                response.Acknowledge = AcknowledgeType.Success;
            }
            return response;
        }
    }
}
