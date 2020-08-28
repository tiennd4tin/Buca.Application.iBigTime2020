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
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.IncrementDecrement
{
    /// <summary>
    /// SqlServerSUTransferDao
    /// </summary>
    public class SqlServerFAAdjustmentDetailFADao : IFAAdjustmentDetailFADao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FAAdjustmentDetailFAEntity> Make = reader =>
            new FAAdjustmentDetailFAEntity
            {
               RefDetailID = reader["RefDetailID"].AsString(),
               RefID = reader["RefDetailID"].AsString(),
               FixedAssetID = reader["RefDetailID"].AsString(),
               DepartmentID = reader["RefDetailID"].AsString(),
               OldOrgPrice = reader["RefDetailID"].AsDecimal(),
               OldDevaluationAmount = reader["RefDetailID"].AsDecimal(),
               OldAccumDevaluationAmount = reader["RefDetailID"].AsDecimal(),
               OldAccumDepreciationAmount = reader["RefDetailID"].AsDecimal(),
               OldRemainingAmount = reader["RefDetailID"].AsDecimal(),
               OldAnnualDepreciationRate = reader["RefDetailID"].AsDecimal(),
               OldAnnualDepreciationAmount = reader["RefDetailID"].AsDecimal(),
               OldPeriodDevaluationAmount = reader["RefDetailID"].AsDecimal(),
               OldQuantity = reader["RefDetailID"].AsDecimal(),
               OldProductionRate = reader["RefDetailID"].AsDecimal(),
               OldDevaluationRate = reader["RefDetailID"].AsDecimal(),
               OldRemainingDevaluationLifeTime = reader["RefDetailID"].AsDecimal(),
               NewOrgPrice = reader["RefDetailID"].AsDecimal(),
               NewDevaluationAmount = reader["RefDetailID"].AsDecimal(),
               NewAccumDevaluationAmount = reader["RefDetailID"].AsDecimal(),
               NewAccumDepreciationAmount = reader["RefDetailID"].AsDecimal(),
               NewRemainingAmount = reader["RefDetailID"].AsDecimal(),
               NewAnnualDepreciationRate = reader["RefDetailID"].AsDecimal(),
               NewAnnualDepreciationAmount = reader["RefDetailID"].AsDecimal(),
               NewPeriodDevaluationAmount = reader["RefDetailID"].AsDecimal(),
               NewQuantity = reader["RefDetailID"].AsDecimal(),
               NewProductionRate = reader["RefDetailID"].AsDecimal(),
               NewDevaluationRate = reader["RefDetailID"].AsDecimal(),
               NewRemainingDevaluationLifeTime = reader["RefDetailID"].AsDecimal(),
               NewRemainingLifeTime = reader["RefDetailID"].AsInt(),
               DiffOrgPrice = reader["RefDetailID"].AsDecimal(),
               DiffDevaluationAmount = reader["RefDetailID"].AsDecimal(),
               DiffAccumDevaluationAmount = reader["RefDetailID"].AsDecimal(),
               DiffAccumDepreciationAmount = reader["RefDetailID"].AsDecimal(),
               DiffRemainingAmount = reader["RefDetailID"].AsDecimal(),
               DiffAnnualDepreciationRate = reader["RefDetailID"].AsDecimal(),
               DiffAnnualDepreciationAmount = reader["RefDetailID"].AsDecimal(),
               DiffPeriodDevaluationAmount = reader["RefDetailID"].AsDecimal(),
               DiffQuantity = reader["RefDetailID"].AsDecimal(),
               SortOrder = reader["RefDetailID"].AsInt(),
               EndYear = reader["RefDetailID"].AsInt()
            };
 
        public FAAdjustmentDetailFAEntity GetFAAdjustmentDetailFAByFixedAssetID(string fixedAssetID)
        {
            const string procedures = @"GetTop1FAAdjustmentDetailFAByFixedAssetID";
            object[] parms = { "@fixedAssetID", fixedAssetID };
            return Db.Read(procedures, true, Make, parms);
        }
        /// <summary>
        /// Takes the specified s u increment decrement entity.
        /// </summary>
        /// <returns></returns>
        private static object[] Take(FAAdjustmentDetailFAEntity suTransferEntity)
        {
            return new object[]
            {
                "@RefID", suTransferEntity.RefID,
            };
        }
    }
}
