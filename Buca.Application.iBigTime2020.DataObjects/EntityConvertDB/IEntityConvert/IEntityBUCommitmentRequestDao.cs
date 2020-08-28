using System;
using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert
{
    public interface IEntityBUCommitmentRequestDao
    {
        List<BUCommitmentRequestEntity> GetBUCommitmentRequests(string connectionString);
    }
}
