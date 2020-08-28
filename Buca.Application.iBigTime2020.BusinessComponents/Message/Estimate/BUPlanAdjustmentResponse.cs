using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate
{
   public  class BUPlanAdjustmentResponse:ResponseBase
    {
        public BUPlanAdjustmentEntity BuPlanAdjustment { get; set; }

       
        public string RefId { get; set; }
    }
}
