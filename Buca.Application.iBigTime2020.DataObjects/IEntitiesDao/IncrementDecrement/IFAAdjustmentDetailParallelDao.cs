using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement
{
    public interface IFAAdjustmentDetailParallelDao
    {
        string InsertFAAdjustmentDetailParallel(FAAdjustmentDetailParallelEntity fAAdjustmentDetailParallelEntity);
        string DeleteFAAdjustmentDetailParallelByRefId(string refId);
        List<FAAdjustmentDetailParallelEntity> GetFAAdjustmentDetailParallelsByRefId(string refId);
    }
}
