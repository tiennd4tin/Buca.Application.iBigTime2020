/***********************************************************************
 * <copyright file="SqlServerBUTrasferDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    /// <summary>
    /// Class SqlServerBUTrasferDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate.IBUTransferDao" />
    public class SqlServerBUTrasferDao : IBUTransferDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUTransferEntity> Make = reader =>
   new BUTransferEntity
   {
       RefId = reader["RefID"].AsString(),
       RefType = reader["RefType"].AsInt(),
       RefDate = reader["RefDate"].AsDateTime(),
       PostedDate = reader["PostedDate"].AsDateTime(),
       RefNo = reader["RefNo"].AsString(),
       CurrencyCode = reader["CurrencyCode"].AsString(),
       ExchangeRate = reader["ExchangeRate"].AsDecimal(),
       ParalellRefNo = reader["ParalellRefNo"].AsString(),
       JournalMemo = reader["JournalMemo"].AsString(),
       TargetProgramId = reader["TargetProgramID"].AsString(),
       BankInfoId = reader["BankInfoID"].AsString(),
       AccountingObjectId = reader["AccountingObjectID"].AsString(),
       AccountingObjectName = reader["AccountingObjectName"].AsString(),
       AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
       AccountingObjectBankAccount = reader["AccountingObjectBankAccount"].AsString(),
       AccountingObjectBankName = reader["AccountingObjectBankName"].AsString(),
       DocumentIncluded = reader["DocumentIncluded"].AsString(),
       InwardStockRefNo = reader["InwardStockRefNo"].AsString(),
       WithdrawRefDate = reader["WithdrawRefDate"].AsDateTime(),
       WithdrawRefNo = reader["WithdrawRefNo"].AsString(),
       IncrementRefNo = reader["IncrementRefNo"].AsString(),
       TotalAmount = reader["TotalAmount"].AsDecimal(),
       TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
       TotalTaxAmount = reader["TotalTaxAmount"].AsDecimal(),
       TotalFreightAmount = reader["TotalFreightAmount"].AsDecimal(),
       TotalInwardAmount = reader["TotalInwardAmount"].AsDecimal(),
       Posted = reader["Posted"].AsBool(),
       PostVersion = reader["PostVersion"].AsInt(),
       EditVersion = reader["EditVersion"].AsInt(),
       RefOrder = reader["RefOrder"].AsInt(),
       LinkRefNo = reader["LinkRefNo"].AsString(),
       gLVouchersRefId = reader["GLVouchersRefID"].AsString(),
       RelationRefId = reader["RelationRefID"].AsString(),
       BUCommitmentRequestId = reader["BUCommitmentRequestID"].AsString(),
       TotalFixedAssetAmount = reader["TotalFixedAssetAmount"].AsDecimal(),

   };

        private static readonly Func<IDataReader, BUTransferEntity> MakeWithBUTransfer = reader =>
   new BUTransferEntity
   {
       RefId = reader["RefID"].AsString(),
       RefType = reader["RefType"].AsInt(),
       RefDate = reader["RefDate"].AsDateTime(),
       PostedDate = reader["PostedDate"].AsDateTime(),
       RefNo = reader["RefNo"].AsString(),
       CurrencyCode = reader["CurrencyCode"].AsString(),
       ExchangeRate = reader["ExchangeRate"].AsDecimal(),
       ParalellRefNo = reader["ParalellRefNo"].AsString(),
       JournalMemo = reader["JournalMemo"].AsString(),
       TargetProgramId = reader["TargetProgramID"].AsString(),
       BankInfoId = reader["BankInfoID"].AsString(),
       AccountingObjectId = reader["AccountingObjectID"].AsString(),
       AccountingObjectName = reader["AccountingObjectName"].AsString(),
       AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
       AccountingObjectBankAccount = reader["AccountingObjectBankAccount"].AsString(),
       AccountingObjectBankName = reader["AccountingObjectBankName"].AsString(),
       DocumentIncluded = reader["DocumentIncluded"].AsString(),
       InwardStockRefNo = reader["InwardStockRefNo"].AsString(),
       WithdrawRefDate = reader["WithdrawRefDate"].AsDateTime(),
       WithdrawRefNo = reader["WithdrawRefNo"].AsString(),
       IncrementRefNo = reader["IncrementRefNo"].AsString(),
       TotalAmount = reader["TotalAmount"].AsDecimal(),
       TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
       TotalTaxAmount = reader["TotalTaxAmount"].AsDecimal(),
       TotalFreightAmount = reader["TotalFreightAmount"].AsDecimal(),
       TotalInwardAmount = reader["TotalInwardAmount"].AsDecimal(),
       Posted = reader["Posted"].AsBool(),
       PostVersion = reader["PostVersion"].AsInt(),
       EditVersion = reader["EditVersion"].AsInt(),
       RefOrder = reader["RefOrder"].AsInt(),

       gLVouchersRefId = reader["GLVouchersRefID"].AsString(),
       RelationRefId = reader["RelationRefID"].AsString(),
       BUCommitmentRequestId = reader["BUCommitmentRequestID"].AsString(),
       TotalFixedAssetAmount = reader["TotalFixedAssetAmount"].AsDecimal(),
       BUPlanWithdrawRefId = reader["BUPlanWithdrawRefID"].AsString(),
   };

        /// <summary>
        /// Takes the specified b u transfer entity.
        /// </summary>
        /// <param name="bUTransferEntity">The b u transfer entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(BUTransferEntity bUTransferEntity)
        {
            return new object[]
            {
                "@RefID",bUTransferEntity.RefId,
                "@RefType",bUTransferEntity.RefType,
                "@RefDate",bUTransferEntity.RefDate,
                "@PostedDate",bUTransferEntity.PostedDate,
                "@RefNo",bUTransferEntity.RefNo,
                "@CurrencyCode",bUTransferEntity.CurrencyCode,
                "@ExchangeRate",bUTransferEntity.ExchangeRate,
                "@ParalellRefNo",bUTransferEntity.ParalellRefNo,
                "@JournalMemo",bUTransferEntity.JournalMemo,
                "@TargetProgramID",bUTransferEntity.TargetProgramId,
                "@BankInfoID",bUTransferEntity.BankInfoId,
                "@AccountingObjectID",bUTransferEntity.AccountingObjectId,
                "@AccountingObjectName",bUTransferEntity.AccountingObjectName,
                "@AccountingObjectAddress",bUTransferEntity.AccountingObjectAddress,
                "@AccountingObjectBankAccount",bUTransferEntity.AccountingObjectBankAccount,
                "@AccountingObjectBankName",bUTransferEntity.AccountingObjectBankName,
                "@DocumentIncluded",bUTransferEntity.DocumentIncluded,
                "@InwardStockRefNo",bUTransferEntity.InwardStockRefNo,
                "@WithdrawRefDate",bUTransferEntity.WithdrawRefDate,
                "@WithdrawRefNo",bUTransferEntity.WithdrawRefNo,
                "@IncrementRefNo",bUTransferEntity.IncrementRefNo,
                "@TotalAmount",bUTransferEntity.TotalAmount,
                "@TotalAmountOC",bUTransferEntity.TotalAmountOC,
                "@TotalTaxAmount",bUTransferEntity.TotalTaxAmount,
                "@TotalFreightAmount",bUTransferEntity.TotalFreightAmount,
                "@TotalInwardAmount",bUTransferEntity.TotalInwardAmount,
                "@Posted",bUTransferEntity.Posted,
                "@PostVersion",bUTransferEntity.PostVersion,
                "@EditVersion",bUTransferEntity.EditVersion,
                "@RefOrder",bUTransferEntity.RefOrder,

                "@GLVouchersRefID",bUTransferEntity.gLVouchersRefId,
                "@RelationRefID",bUTransferEntity.RelationRefId,
                "@BUCommitmentRequestID",bUTransferEntity.BUCommitmentRequestId,
                "@TotalFixedAssetAmount",bUTransferEntity.TotalFixedAssetAmount,
                "@BUPlanWithdrawRefId",bUTransferEntity.BUPlanWithdrawRefId
            };
        }

        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUTransferEntity.</returns>
        public BUTransferEntity GetBUTransferbyRefId(string refId)
        {
            const string procedures = @"uspGet_BUTransfer_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="BUPlanWithdrawRefId">The bu plan withdraw reference identifier.</param>
        /// <returns>
        /// BUTransferEntity.
        /// </returns>
        public BUTransferEntity GetBUTransferByBUPlanWithdrawRefId(string BUPlanWithdrawRefId)
        {
            const string procedures = @"uspGet_BUTransfer_ByBUPlanWithdrawRefID";
            object[] parms = { "@BUPlanWithdrawRefID", BUPlanWithdrawRefId };
            return Db.Read(procedures, true, MakeWithBUTransfer, parms);
        }

        /// <summary>
        /// Gets the bu transferby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>BUTransferEntity.</returns>
        public BUTransferEntity GetBUTransferbyRefNo(string refNo)
        {
            const string procedures = @"uspGet_BUTransfer_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }
        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUTransferEntity&gt;.</returns>
        public List<BUTransferEntity> GetBUTransfer()
        {
            const string procedures = @"uspGet_All_BUTransfer";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUTransferEntity&gt;.</returns>
        public List<BUTransferEntity> GetBUTransfersByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_BUTransfer_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUTransfer">The b u commitment adjustment.</param>
        /// <returns>System.String.</returns>
        public string InsertBUTransfer(BUTransferEntity bUTransfer)
        {
            const string procedures = @"uspInsert_BUTransfer";
            return Db.Insert(procedures, true, Take(bUTransfer));
        } 

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUTransfer">The b u commitment adjustment.</param>
        /// <returns>System.String.</returns>
        public string UpdateBUTransfer(BUTransferEntity bUTransfer)
        {
            const string procedures = @"uspUpdate_BUTransfer";
            return Db.Update(procedures, true, Take(bUTransfer));
        }


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUTransfer">The b u commitment adjustment.</param>
        /// <returns>System.String.</returns>
        public string DeleteBUTransfer(BUTransferEntity bUTransfer)
        {
            const string procedures = @"uspDelete_BUTransfer";
            object[] parms = { "@RefId", bUTransfer.RefId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Deletes the bu transfer by bu plan withdraw reference identifier.
        /// </summary>
        /// <param name="buPlanWithdrawRefId">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        public string DeleteBUTransferByBUPlanWithdrawRefId(BUTransferEntity buPlanWithdrawRefId)
        {
            const string procedures = @"uspDelete_BUTransferDetail_ByBUPlanWithdrawRefID";
            object[] parms = { "@BUPlanWithdrawRefID", buPlanWithdrawRefId.BUPlanWithdrawRefId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the bu transferby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        public BUTransferEntity GetBUTransferbyRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_BUTransfer_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }
    }
}
