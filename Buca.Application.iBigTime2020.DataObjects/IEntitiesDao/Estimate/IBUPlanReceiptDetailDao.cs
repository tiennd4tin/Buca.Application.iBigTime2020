using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate
{
   public interface IBUPlanReceiptDetailDao
    {
        string DeleteBUPlanReceiptDetail(string refId);
        List<BUPlanReceiptDetailEntity> GetBUPlanReceiptDetailbyRefId(string refId);  
        string InsertBUPlanReceiptDetail(BUPlanReceiptDetailEntity buPlanReceiptDetail);

    }
}
