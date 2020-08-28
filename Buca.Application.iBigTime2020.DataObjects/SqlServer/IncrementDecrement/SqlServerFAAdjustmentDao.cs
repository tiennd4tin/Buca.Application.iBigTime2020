/***********************************************************************
 * <copyright file="SqlServerFAIncrementDecrementDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.IncrementDecrement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement.IFAAdjustmentDao" />

    public class SqlServerFAAdjustmentDao : IFAAdjustmentDao

    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FAAdjustmentEntity> Make = reader =>
            new FAAdjustmentEntity
            {
                RefId = reader["RefID"].AsString(),
                RefType = reader["RefType"].AsInt(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                ParalellRefNo = reader["ParalellRefNo"].AsString(),
                JournalMemo = reader["JournalMemo"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                FixedAssetId = reader["FixedAssetID"].AsString(),
                FixedAssetName = reader["FixedAssetName"].AsString(),
                Posted = reader["Posted"].AsBool(),
                PostVersion = reader["PostVersion"].AsInt(),
                EditVersion = reader["EditVersion"].AsInt(),
                AppliedYear = reader["AppliedYear"].AsInt(),
                EndYear = reader["EndYear"].AsInt(),
                EndDevaluationDate = reader["EndDevaluationDate"].AsDateTime()

            };
        /// <summary>
        /// The make fa
        /// </summary>
        private static readonly Func<IDataReader, FAAdjustmentEntity> MakeFA = reader =>
    new FAAdjustmentEntity
    {
        RefId = reader["RefID"].AsString(),
        RefType = reader["RefType"].AsInt(),
        RefDate = reader["RefDate"].AsDateTime(),
        PostedDate = reader["PostedDate"].AsDateTime(),
        RefNo = reader["RefNo"].AsString(),
        ParalellRefNo = reader["ParalellRefNo"].AsString(),
        JournalMemo = reader["JournalMemo"].AsString(),
        TotalAmount = reader["TotalAmount"].AsDecimal(),
        FixedAssetId = reader["FixedAssetID"].AsString(),
        FixedAssetName = reader["FixedAssetName"].AsString(),
        Posted = reader["Posted"].AsBool(),
        PostVersion = reader["PostVersion"].AsInt(),
        EditVersion = reader["EditVersion"].AsInt(),
        AppliedYear = reader["AppliedYear"].AsInt(),
        EndYear = reader["EndYear"].AsInt(),
        EndDevaluationDate = reader["EndDevaluationDate"].AsDateTime(),

        NewOrgPrice = reader["NewOrgPrice"].AsDecimal(),
        OldOrgPrice = reader["OldOrgPrice"].AsDecimal(),
        DiffOrgPrice = reader["DiffOrgPrice"].AsDecimal(),
        NewDevaluationAmount = reader["NewDevaluationAmount"].AsDecimal(),
        OldDevaluationAmount = reader["OldDevaluationAmount"].AsDecimal(),
        DiffDevaluationAmount = reader["DiffDevaluationAmount"].AsDecimal(),
        NewAccumDepreciationAmount = reader["NewAccumDepreciationAmount"].AsDecimal(),
        OldAccumDepreciationAmount = reader["OldAccumDepreciationAmount"].AsDecimal(),
        DiffAccumDepreciationAmount = reader["DiffAccumDepreciationAmount"].AsDecimal(),
        NewAccumDevaluationAmount = reader["NewAccumDevaluationAmount"].AsDecimal(),
        OldAccumDevaluationAmount = reader["OldAccumDevaluationAmount"].AsDecimal(),
        DiffAccumDevaluationAmount = reader["DiffAccumDevaluationAmount"].AsDecimal(),
        NewRemainingAmount = reader["NewRemainingAmount"].AsDecimal(),
        OldRemainingAmount = reader["OldRemainingAmount"].AsDecimal(),
        DiffRemainingAmount = reader["DiffRemainingAmount"].AsDecimal(),
        NewQuantity = reader["NewQuantity"].AsDecimal(),
        OldQuantity = reader["OldQuantity"].AsDecimal(),
        DiffQuantity = reader["DiffQuantity"].AsDecimal(),
    };


        /// <summary>
        /// Gets the fa adjustments.
        /// </summary>
        /// <returns></returns>
        public List<FAAdjustmentEntity> GetFAAdjustments()
        {
            const string procedures = @"uspGet_All_FAAdjustments";
            return Db.ReadList(procedures, true, Make);
        }


        /// <summary>
        /// Gets the fa adjustmentby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public FAAdjustmentEntity GetFAAdjustmentbyRefId(string refId)
        {
            const string procedures = @"uspGet_FAAdjustmentbyRefId";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, MakeFA, parms);
        }

        /// <summary>
        /// Gets the fa adjustment fordelete by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public FAAdjustmentEntity GetFAAdjustment_fordelete_byRefId(string refId)
        {
            const string procedures = @"GetFAAdjustment_fordelete_byRefId";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the fa adjustment.
        /// </summary>
        /// <param name="fAAdjustmentEntity">The f a adjustment entity.</param>
        /// <returns></returns>
        public string InsertFAAdjustment(FAAdjustmentEntity fAAdjustmentEntity)
        {
            const string sql = @"uspInsert_FAAdjustment";
            return Db.Insert(sql, true, Take(fAAdjustmentEntity));
        }
        /// <summary>
        /// Inserts the fa adjustment.
        /// </summary>
        /// <param name="fAAdjustmentEntity">The f a adjustment entity.</param>
        /// <returns></returns>
        public string UpdateFAAdjustment(FAAdjustmentEntity fAAdjustmentEntity)
        {
            const string sql = @"uspUpdate_FAAdjustment";
            return Db.Insert(sql, true, Take(fAAdjustmentEntity));
        }

        /// <summary>
        /// Inserts the fa adjustment detail fa.
        /// </summary>
        /// <param name="fAAdjustmentEntity">The f a adjustment entity.</param>
        /// <returns></returns>
        public string InsertFAAdjustmentDetailFA(FAAdjustmentEntity fAAdjustmentEntity)
        {
            const string sql = @"uspInsert_FAAdjustmentDetailFA";
            return Db.Insert(sql, true, TakeFA(fAAdjustmentEntity));
        }


        /// <summary>
        /// Deletes the fa adjustment.
        /// </summary>
        /// <param name="fAAdjustment">The f a adjustment.</param>
        /// <returns></returns>
        public string DeleteFAAdjustment(FAAdjustmentEntity fAAdjustment)
        {
            const string sql = @"uspDelete_FAAdjustment";
            object[] parms = { "@RefID", fAAdjustment.RefId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Deletes the fa adjustment detail fa.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public string DeleteFAAdjustmentDetailFA(string refId)
        {
            const string sql = @"uspDelete_FAAdjustmentDetailFA";
            object[] parms = { "@RefID", refId };
            return Db.Delete(sql, true, parms);
        }

        //public FAIncrementDecrementEntity GetFAIncrementDecrementByRefNo(string refNo)
        //{
        //    const string procedures = @"uspGet_FAIncrementDecrement_ByRefNo";
        //    object[] parms = {"@RefNo", refNo};
        //    return Db.Read(procedures, true, Make, parms);
        //}

        /// <summary>
        /// Takes the specified s u increment decrement entity.
        /// </summary>
        /// <param name="fAAdjustmentEntity">The f a adjustment entity.</param>
        /// <returns></returns>
        private static object[] Take(FAAdjustmentEntity fAAdjustmentEntity)
        {
            return new object[]
            {
                 "@RefID" ,  fAAdjustmentEntity.RefId,
                 "@RefType" ,  fAAdjustmentEntity.RefType,
                 "@RefDate" ,  fAAdjustmentEntity.RefDate,
                 "@PostedDate" ,  fAAdjustmentEntity.PostedDate,
                 "@RefNo" ,  fAAdjustmentEntity.RefNo,
                 "@ParalellRefNo" ,  fAAdjustmentEntity.ParalellRefNo,
                 "@JournalMemo" ,  fAAdjustmentEntity.JournalMemo,
                 "@TotalAmount" ,  fAAdjustmentEntity.TotalAmount,
                 "@FixedAssetID" ,  fAAdjustmentEntity.FixedAssetId,
                 "@FixedAssetName" ,  fAAdjustmentEntity.FixedAssetName,
                 "@Posted" ,  fAAdjustmentEntity.Posted,
                 "@PostVersion" ,  fAAdjustmentEntity.PostVersion,
                 "@EditVersion" ,  fAAdjustmentEntity.EditVersion,
                 "@AppliedYear" ,  fAAdjustmentEntity.AppliedYear,
                 "@EndYear" ,  fAAdjustmentEntity.EndYear,
                 "@EndDevaluationDate" ,  fAAdjustmentEntity.EndDevaluationDate,
                 "@FARefOrder" ,  fAAdjustmentEntity.FARefOrder
            };
        }
        /// <summary>
        /// Takes the fa.
        /// </summary>
        /// <param name="fAAdjustmentEntity">The f a adjustment entity.</param>
        /// <returns></returns>
        private static object[] TakeFA(FAAdjustmentEntity fAAdjustmentEntity)
        {
            return new object[]
            {
                 "@RefDetailID" ,  fAAdjustmentEntity.RefDetailId,
                 "@RefID" ,  fAAdjustmentEntity.RefId,
                 "@FixedAssetID" ,  fAAdjustmentEntity.FixedAssetId,
                 "@NewOrgPrice" ,  fAAdjustmentEntity.NewOrgPrice,
                 "@OldOrgPrice" ,  fAAdjustmentEntity.OldOrgPrice,
                 "@DiffOrgPrice" ,  fAAdjustmentEntity.DiffOrgPrice,
                 "@NewDevaluationAmount" ,  fAAdjustmentEntity.NewDevaluationAmount,
                 "@OldDevaluationAmount" ,  fAAdjustmentEntity.OldDevaluationAmount,
                 "@DiffDevaluationAmount" ,  fAAdjustmentEntity.DiffDevaluationAmount,
                 "@NewAccumDepreciationAmount" ,  fAAdjustmentEntity.NewAccumDepreciationAmount,
                 "@OldAccumDepreciationAmount" ,  fAAdjustmentEntity.OldAccumDepreciationAmount,
                 "@DiffAccumDepreciationAmount" ,  fAAdjustmentEntity.DiffAccumDepreciationAmount,
                 "@NewAccumDevaluationAmount" ,  fAAdjustmentEntity.NewAccumDevaluationAmount,
                 "@OldAccumDevaluationAmount" ,  fAAdjustmentEntity.OldAccumDevaluationAmount,
                 "@DiffAccumDevaluationAmount" ,  fAAdjustmentEntity.DiffAccumDevaluationAmount,
                 "@NewRemainingAmount" ,  fAAdjustmentEntity.NewRemainingAmount,
                 "@OldRemainingAmount" ,  fAAdjustmentEntity.OldRemainingAmount,
                 "@DiffRemainingAmount" ,  fAAdjustmentEntity.DiffRemainingAmount,
                 "@NewQuantity" ,  fAAdjustmentEntity.NewQuantity,
                 "@OldQuantity" ,  fAAdjustmentEntity.OldQuantity,
                 "@DiffQuantity" ,  fAAdjustmentEntity.DiffQuantity,
                "@NewAnnualDepreciationAmount", fAAdjustmentEntity.NewAnnualDepreciationAmount,
                "@OldAnnualDepreciationAmount", fAAdjustmentEntity.OldAnnualDepreciationAmount,
                "@DiffAnnualDepreciationAmount", fAAdjustmentEntity.DiffAnnualDepreciationAmount
            };
        }

    }
}