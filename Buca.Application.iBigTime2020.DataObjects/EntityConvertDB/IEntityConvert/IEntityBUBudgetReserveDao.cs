﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert
{
    public interface IEntityBUBudgetReserveDao
    {
        List<BUBudgetReserveEntity> GetBUBudgetReserves(string connectionString);
    }
}
