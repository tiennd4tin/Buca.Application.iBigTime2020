/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 27, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement
{
    /// <summary>
    /// ISUTransferDao
    /// </summary>
    public interface IFAAdjustmentDetailFADao
    {
        FAAdjustmentDetailFAEntity GetFAAdjustmentDetailFAByFixedAssetID(string fixedAssetID);
    }
}
