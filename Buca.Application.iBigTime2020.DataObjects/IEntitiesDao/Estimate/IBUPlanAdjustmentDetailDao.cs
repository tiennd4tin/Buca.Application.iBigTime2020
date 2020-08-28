using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    public interface IBUPlanAdjustmentDetailDao
    {
        string DeleteBUPlanAdjustmentDetail(string refId);
        List<BUPlanAdjustmentDetailEntity> GetBUPlanAdjustmentDetailbyRefId(string refId);
        string InsertBUPlanAdjustmentDetail(BUPlanAdjustmentDetailEntity buPlanAdjustmentDetail);

      
    }
}
