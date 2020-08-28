/***********************************************************************
 * <copyright file="IFAIncrementDecrementDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement
{
    /// <summary>
    ///     IFAIncrementDecrementDao
    /// </summary>
    public interface IFAAdjustmentDetailDao
    {
        string InsertFAAdjustmentDetail(FAAdjustmentDetailEntity fAAdjustmentDetailEntity);
        string DeleteFAAdjustmentDetailByRefId(string refId);
        List<FAAdjustmentDetailEntity> GetFAAdjustmentDetailsByRefId(string refId);
        string DeleteFAAdjustmentDetail(string refId);
    }
}