﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert
{
    public  interface IEntityInventoryItemDao
    {
        List<InventoryItemEntity> GetInventoryItem(string connectionString);
    }

}
