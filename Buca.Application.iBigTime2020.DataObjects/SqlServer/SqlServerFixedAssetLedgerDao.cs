/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   
 * Email:    
 * Website:
 * Create Date: December 06, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    06/12/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer
{
    /// <summary>
    /// SqlServerFixedAssetLedgerDao
    /// </summary>
    public class SqlServerFixedAssetLedgerDao : IFixedAssetLedgerDao
    {
        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public FixedAssetLedgerEntity GetFixedAssetLedgerByRefId(string refId, int refTypeId)
        {
            const string procedures = @"uspGet_FixedAssetLedger_ByRefID";
            object[] parms = { "@RefID", refId, "@RefTypeID", refTypeId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public FixedAssetLedgerEntity GetFixedAssetLedgerByFixedAssetId(string fixedAssetId, int refTypeId)
        {
            const string procedures = @"uspGet_GetFixedAssetLedgerByFixedAssetIdAndRefType";
            object[] parms = { "@FixedAssetID", fixedAssetId, "@RefType", refTypeId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        public List<FixedAssetLedgerEntity> GetFixedAssetLedger_ByFixedAssetId(string fixedAssetId)
        {
            const string procedures = @"uspGet_GetFixedAssetLedgerByFixedAssetId";
            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.ReadList(procedures, true, Make, parms);
        }
        /// <summary>
        /// Posts the fixed asset get lasted information for post by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="reftype">The reftype.</param>
        /// <param name="isForceGetOnLedger">if set to <c>true</c> [is force get on ledger].</param>
        /// <returns></returns>
        public List<FixedAssetLedgerEntity> PostFixedAsset_GetLastedInfoForPost_ByFixedAssetId(string fixedAssetId, DateTime postedDate, int reftype, bool isForceGetOnLedger, string refId = null)
        {
            const string procedures = @"usp_PostFixedAsset_GetLastedInfoForPost";
            object[] parms = {  "@ListFixedAssetID", fixedAssetId,
                                "@PostedDate", postedDate,
                                "@Reftype", reftype,
                                "@IsForceGetOnLedger", isForceGetOnLedger,
            "@RefId",refId};
            return Db.ReadList(procedures, true, Make_FixedAsset, parms);
        }

        /// <summary>
        /// The make fixed asset
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetLedgerEntity> Make_FixedAsset = reader =>
       new FixedAssetLedgerEntity
       {
           FixedAssetId = reader["FixedAssetID"].AsString(),
           FixedAssetCode = reader["FixedAssetCode"].AsString(),
           FixedAssetName = reader["FixedAssetName"].AsString(),
           AnnualDepreciationRate = reader["AnnualDepreciationRate"].AsDecimal(),
           AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
           Quantity = reader["Quantity"].AsDecimal(),
           RemainingLifeTime = reader["RemainingLifeTime"].AsInt(),
           EndYear = reader["EndYear"].AsInt(),
           DepartmentId = reader["DepartmentID"].AsString(),
           OrgPriceAccount = reader["OrgPriceAccount"].AsString(),
           DepreciationAccount = reader["DepreciationAccount"].AsString(),
           DevaluationRate = reader["DevaluationRate"].AsDecimal(),
           DevaluationPeriod = reader["DevaluationPeriod"].AsInt(),
           PeriodDevaluationAmount = reader["PeriodDevaluationAmount"].AsDecimal(),
           DevaluationAmount = reader["DevaluationAmount"].AsDecimal(),
           RemainingDevaluationLifeTime = reader["RemainingDevaluationLifeTime"].AsDecimal(),
           EndDevaluationDate = reader["EndDevaluationDate"].AsDateTimeForNull(),
           OrgPriceDebitAmount = reader["OrgPriceDebitAmount"].AsDecimal(),
           OrgPriceCreditAmount = reader["OrgPriceCreditAmount"].AsDecimal(),
           DepreciationDebitAmount = reader["DepreciationDebitAmount"].AsDecimal(),
           DepreciationCreditAmount = reader["DepreciationCreditAmount"].AsDecimal(),
           DevaluationDebitAmount = reader["DevaluationDebitAmount"].AsDecimal(),
           DevaluationCreditAmount = reader["DevaluationCreditAmount"].AsDecimal(),
       };

        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string InsertFixedAssetLedger(FixedAssetLedgerEntity fixedAssetLedger)
        {
            const string sql = @"uspInsert_FixedAssetLedger";
            return Db.Insert(sql, true, Take(fixedAssetLedger));
        }

        /// <summary>
        /// Deletes the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public string DeleteFixedAssetLedgerByRefId(string refId, int refTypeId)
        {
            const string procedures = @"uspDelete_FixedAssetLedger_ByRefIDAndRefType";
            object[] parms = { "@RefID", refId, "@RefType", refTypeId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Deletes the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public string DeleteFixedAssetLedgerByFixedAssetId(string fixedAssetId, int refTypeId)
        {
            const string procedures = @"uspDelete_FixedAssetLedger_ByFixedAssetID";
            object[] parms = { "@FixedAssetID", fixedAssetId, "@RefType", refTypeId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetLedgerEntity> Make = reader =>
            new FixedAssetLedgerEntity
            {
                FixedAssetLedgerId = reader["FixedAssetLedgerID"].AsGuid().AsString(),
                RefId = reader["RefID"].AsString(),
                RefType = reader["RefType"].AsInt(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                FixedAssetId = reader["FixedAssetID"].AsString(),
                DepartmentId = reader["DepartmentID"].AsString(),
                LifeTime = reader["LifeTime"].AsDecimal(),
                AnnualDepreciationRate = reader["AnnualDepreciationRate"].AsDecimal(),
                AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
                OrgPriceAccount = reader["OrgPriceAccount"].AsString(),
                OrgPriceDebitAmount = reader["OrgPriceDebitAmount"].AsDecimal(),
                OrgPriceCreditAmount = reader["OrgPriceCreditAmount"].AsDecimal(),
                DepreciationAccount = reader["DepreciationAccount"].AsString(),
                DepreciationDebitAmount = reader["DepreciationDebitAmount"].AsDecimal(),
                DepreciationCreditAmount = reader["DepreciationCreditAmount"].AsDecimal(),
                CapitalAccount = reader["CapitalAccount"].AsString(),
                CapitalDebitAmount = reader["CapitalDebitAmount"].AsDecimal(),
                CapitalCreditAmount = reader["CapitalCreditAmount"].AsDecimal(),
                JournalMemo = reader["JournalMemo"].AsString(),
                Description = reader["Description"].AsString(),
                RemainingLifeTime = reader["RemainingLifeTime"].AsInt(),
                EndYear = reader["EndYear"].AsInt(),
                FARefOrder = reader["FARefOrder"].AsInt(),
                FixedAssetOrder = reader["FixedAssetOrder"].AsInt(),
                Quantity = reader["Quantity"].AsDecimal(),
                DifferenceQuantity = reader["DifferenceQuantity"].AsDecimal(),
                FixedAssetCode = reader["FixedAssetCode"].AsString(),
                FixedAssetName = reader["FixedAssetName"].AsString(),
                DevaluationPeriod = reader["DevaluationPeriod"].AsInt(),
                DevaluationRate = reader["DevaluationRate"].AsDecimal(),
                PeriodDevaluationAmount = reader["PeriodDevaluationAmount"].AsDecimal(),
                DevaluationDebitAmount = reader["DevaluationDebitAmount"].AsDecimal(),
                DevaluationCreditAmount = reader["DevaluationCreditAmount"].AsDecimal(),
                RemainingDevaluationLifeTime = reader["RemainingDevaluationLifeTime"].AsDecimal(),
                EndDevaluationDate = reader["EndDevaluationDate"].AsDateTimeForNull(),
                DevaluationAmount = reader["DevaluationAmount"].AsDecimal()
            };

        /// <summary>
        /// Takes the specified fixed asset ledger.
        /// </summary>
        /// <param name="fixedAssetLedger">The fixed asset ledger.</param>
        /// <returns></returns>
        private static object[] Take(FixedAssetLedgerEntity fixedAssetLedger)
        {
            return new object[]
            {
                "@FixedAssetLedgerID",fixedAssetLedger.FixedAssetLedgerId,
                "@RefID",fixedAssetLedger.RefId,
                "@RefType",fixedAssetLedger.RefType,
                "@RefNo",fixedAssetLedger.RefNo,
                "@RefDate",fixedAssetLedger.RefDate,
                "@PostedDate",fixedAssetLedger.PostedDate,
                "@FixedAssetID",fixedAssetLedger.FixedAssetId,
                "@DepartmentID",fixedAssetLedger.DepartmentId,
                "@LifeTime",fixedAssetLedger.LifeTime,
                "@AnnualDepreciationRate",fixedAssetLedger.AnnualDepreciationRate,
                "@AnnualDepreciationAmount",fixedAssetLedger.AnnualDepreciationAmount,
                "@OrgPriceAccount",fixedAssetLedger.OrgPriceAccount,
                "@OrgPriceDebitAmount",fixedAssetLedger.OrgPriceDebitAmount,
                "@OrgPriceCreditAmount",fixedAssetLedger.OrgPriceCreditAmount,
                "@DepreciationAccount",fixedAssetLedger.DepreciationAccount,
                "@DepreciationDebitAmount",fixedAssetLedger.DepreciationDebitAmount,
                "@DepreciationCreditAmount",fixedAssetLedger.DepreciationCreditAmount,
                "@CapitalAccount",fixedAssetLedger.CapitalAccount,
                "@CapitalDebitAmount",fixedAssetLedger.CapitalDebitAmount,
                "@CapitalCreditAmount",fixedAssetLedger.CapitalCreditAmount,
                "@JournalMemo",fixedAssetLedger.JournalMemo,
                "@Description",fixedAssetLedger.Description,
                "@RemainingLifeTime",fixedAssetLedger.RemainingLifeTime,
                "@EndYear",fixedAssetLedger.EndYear,
                "@FARefOrder",fixedAssetLedger.FARefOrder,
                "@FixedAssetOrder",fixedAssetLedger.FixedAssetOrder,
                "@Quantity",fixedAssetLedger.Quantity,
                "@DifferenceQuantity",fixedAssetLedger.DifferenceQuantity,
                "@FixedAssetCode",fixedAssetLedger.FixedAssetCode,
                "@FixedAssetName",fixedAssetLedger.FixedAssetName,
                "@DevaluationPeriod",fixedAssetLedger.DevaluationPeriod,
                "@DevaluationRate",fixedAssetLedger.DevaluationRate,
                "@PeriodDevaluationAmount",fixedAssetLedger.PeriodDevaluationAmount,
                "@DevaluationDebitAmount",fixedAssetLedger.DevaluationDebitAmount,
                "@DevaluationCreditAmount",fixedAssetLedger.DevaluationCreditAmount,
                "@RemainingDevaluationLifeTime",fixedAssetLedger.RemainingDevaluationLifeTime,
                "@EndDevaluationDate",fixedAssetLedger.EndDevaluationDate,
                "@DevaluationAmount",fixedAssetLedger.DevaluationAmount,
                "@DecreaseReasonID",fixedAssetLedger.DecreaseReasonId,
            };
        }


    }
}