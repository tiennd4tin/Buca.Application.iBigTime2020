﻿/***********************************************************************
 * <copyright file="IStockDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface IElectricalWorkDao
    /// </summary>
    public interface IElectricalWorkDao
    {

        ElectricalWorkEntity GetElectricalWork(int yearPosted);
        string UpdateInsertElectricalWork(ElectricalWorkEntity electricalWorkEntity);
    }
}
