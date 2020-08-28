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
    public interface IFAAdjustmentDao
    {
        
        List<FAAdjustmentEntity> GetFAAdjustments();

         FAAdjustmentEntity GetFAAdjustmentbyRefId(string refId);

        FAAdjustmentEntity GetFAAdjustment_fordelete_byRefId(string refId);
        string InsertFAAdjustment(FAAdjustmentEntity fAAdjustmentEntity);
        string InsertFAAdjustmentDetailFA(FAAdjustmentEntity fAAdjustmentEntity);

        string DeleteFAAdjustment(FAAdjustmentEntity fAAdjustment);

        string DeleteFAAdjustmentDetailFA(string refId);

        //    FAIncrementDecrementEntity GetFAIncrementDecrementByRefNo(string refNo);
    }
}