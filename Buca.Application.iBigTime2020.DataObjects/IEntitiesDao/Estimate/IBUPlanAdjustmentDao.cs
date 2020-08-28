using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
    public interface IBUPlanAdjustmentDao
    {

        BUPlanAdjustmentEntity GetBuPlanAdjustmentEntitybyRefId(string refId);

        List<BUPlanAdjustmentEntity> GetBuPlanAdjustmentVoucherbyRefId(string refId);

        List<BUPlanAdjustmentEntity> GetBuPlanAdjustment();

        BUPlanAdjustmentEntity GetBuPlanAdjustmentEntitybyRefNo(string refNo);

        BUPlanAdjustmentEntity GetBuPlanAdjustmentEntitybyRefNo(string refNo, DateTime postedDate);

        List<BUPlanAdjustmentEntity> GetBuPlanAdjustmentEntitybyReftypeId(string refTypeId);

        string InsertBUPlanAdjustment(BUPlanAdjustmentEntity buPlanAdjustment);
        string UpdateBUPlanAdjustment(BUPlanAdjustmentEntity buPlanAdjustment);
        string DeleteBUPlanAdjustment(BUPlanAdjustmentEntity buPlanAdjustment);  
    }
}
