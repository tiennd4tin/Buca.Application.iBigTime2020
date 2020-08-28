/***********************************************************************
 * <copyright file="SqlServerBUCommitmentAdjustmentDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, December 11, 2017Author SonTV  Description 
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
    /// Class SqlServerBUCommitmentAdjustmentDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate.IBUCommitmentAdjustmentDao" />
    public class SqlServerBUCommitmentAdjustmentDao : IBUCommitmentAdjustmentDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUCommitmentAdjustmentEntity> Make = reader =>
 new BUCommitmentAdjustmentEntity
 {
     RefId = reader["RefID"].AsString(),
     RefDate = reader["RefDate"].AsDateTime(),
     PostedDate = reader["PostedDate"].AsDateTime(),
     RefNo = reader["RefNo"].AsString(),
     BUCommitmentRequestId = reader["BUCommitmentRequestID"].AsString(),
     ContractNo = reader["ContractNo"].AsString(),
     ContractFrameNo = reader["ContractFrameNo"].AsString(),
     RealContractNo = reader["RealContractNo"].AsString(),
     RefType = reader["RefType"].AsInt(),
     TotalAmount = reader["TotalAmount"].AsDecimal(),
     TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
     IsForeignCurrency = reader["IsForeignCurrency"].AsBool(),
     Posted = reader["Posted"].AsBool(),
     EditVersion = reader["EditVersion"].AsInt(),
     PostVersion = reader["PostVersion"].AsInt(),
     IsSuggestAdjustment = reader["IsSuggestAdjustment"].AsBool(),
     IsSuggestSupplement = reader["IsSuggestSupplement"].AsBool(),
     AdjustmentProviderBankAccount = reader["AdjustmentProviderBankAccount"].AsString(),
     AdjustmentProviderBankName = reader["AdjustmentProviderBankName"].AsString(),
     BankAccount = reader["BankAccount"].AsString(),
     BankName = reader["BankName"].AsString(),
     CurrencyCode = reader["CurrencyCode"].AsString(),
     ExchangeRate = reader["ExchangeRate"].AsDecimal(),


 };
        private static readonly Func<IDataReader, BUCommitmentAdjustmentEntity> MakeMore = reader =>
new BUCommitmentAdjustmentEntity
{
   RefId = reader["RefID"].AsString(),
   RefDate = reader["RefDate"].AsDateTime(),
   PostedDate = reader["PostedDate"].AsDateTime(),
   RefNo = reader["RefNo"].AsString(),
   BUCommitmentRequestId = reader["BUCommitmentRequestID"].AsString(),
   ContractNo = reader["ContractNo"].AsString(),
   ContractFrameNo = reader["ContractFrameNo"].AsString(),
   RealContractNo = reader["RealContractNo"].AsString(),
   RefType = reader["RefType"].AsInt(),
   TotalAmount = reader["TotalAmount"].AsDecimal(),
   TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
   IsForeignCurrency = reader["IsForeignCurrency"].AsBool(),
   Posted = reader["Posted"].AsBool(),
   EditVersion = reader["EditVersion"].AsInt(),
   PostVersion = reader["PostVersion"].AsInt(),
   IsSuggestAdjustment = reader["IsSuggestAdjustment"].AsBool(),
   IsSuggestSupplement = reader["IsSuggestSupplement"].AsBool(),
   AdjustmentProviderBankAccount = reader["AdjustmentProviderBankAccount"].AsString(),
   AdjustmentProviderBankName = reader["AdjustmentProviderBankName"].AsString(),
   BankAccount = reader["BankAccount"].AsString(),
   BankName = reader["BankName"].AsString(),
    CurrencyCode = reader["CurrencyCode"].AsString(),
    ExchangeRate = reader["ExchangeRate"].AsDecimal(),

};
        /// <summary>
        /// Takes the specified b u commitment adjustment entity.
        /// </summary>
        /// <param name="bUCommitmentAdjustmentEntity">The b u commitment adjustment entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(BUCommitmentAdjustmentEntity bUCommitmentAdjustmentEntity)
        {
            return new object[]
            {

        "@RefID",bUCommitmentAdjustmentEntity.RefId,
        "@RefDate",bUCommitmentAdjustmentEntity.RefDate,
        "@PostedDate",bUCommitmentAdjustmentEntity.PostedDate,
        "@RefNo",bUCommitmentAdjustmentEntity.RefNo,
        "@BUCommitmentRequestID",bUCommitmentAdjustmentEntity.BUCommitmentRequestId,
        "@ContractNo",bUCommitmentAdjustmentEntity.ContractNo,
        "@ContractFrameNo",bUCommitmentAdjustmentEntity.ContractFrameNo,
        "@RealContractNo",bUCommitmentAdjustmentEntity.RealContractNo,
        "@RefType",bUCommitmentAdjustmentEntity.RefType,
        "@TotalAmount",bUCommitmentAdjustmentEntity.TotalAmount,
        "@TotalAmountOC",bUCommitmentAdjustmentEntity.TotalAmountOC,
        "@IsForeignCurrency",bUCommitmentAdjustmentEntity.IsForeignCurrency,
        "@Posted",bUCommitmentAdjustmentEntity.Posted,
        "@EditVersion",bUCommitmentAdjustmentEntity.EditVersion,
        "@PostVersion",bUCommitmentAdjustmentEntity.PostVersion,
        "@IsSuggestAdjustment",bUCommitmentAdjustmentEntity.IsSuggestAdjustment,
        "@IsSuggestSupplement",bUCommitmentAdjustmentEntity.IsSuggestSupplement,
        "@AdjustmentProviderBankAccount",bUCommitmentAdjustmentEntity.AdjustmentProviderBankAccount,
        "@AdjustmentProviderBankName",bUCommitmentAdjustmentEntity.AdjustmentProviderBankName,
        "@BankAccount",bUCommitmentAdjustmentEntity.BankAccount,
        "@BankName",bUCommitmentAdjustmentEntity.BankName,
          "@CurrencyCode",bUCommitmentAdjustmentEntity.CurrencyCode,
            "@ExchangeRate",bUCommitmentAdjustmentEntity.ExchangeRate,
            };
        }
        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentAdjustmentEntity.</returns>
        public BUCommitmentAdjustmentEntity GetBUCommitmentAdjustmentbyRefId(string refId)
        {
            const string procedures = @"uspGet_BUCommitmentAdjustment_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.Read(procedures, true, MakeMore, parms);
        }

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUCommitmentAdjustmentEntity&gt;.</returns>
        public List<BUCommitmentAdjustmentEntity> GetBUCommitmentAdjustment()
        {
            const string procedures = @"uspGet_All_BUCommitmentAdjustment";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentAdjustmentEntity&gt;.</returns>
        public List<BUCommitmentAdjustmentEntity> GetBUCommitmentAdjustmentsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_BUCommitmentAdjustment_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu commitment adjustments by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;BUCommitmentAdjustmentEntity&gt;.</returns>
        public BUCommitmentAdjustmentEntity GetBUCommitmentAdjustmentsByRefNo(string refNo)
        {
            const string procedures = @"uspGet_BUCommitmentAdjustment_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu commitment adjustments by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;BUCommitmentAdjustmentEntity&gt;.</returns>
        public BUCommitmentAdjustmentEntity GetBUCommitmentAdjustmentsByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_BUCommitmentAdjustment_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentAdjustment">The b u commitment adjustment.</param>
        /// <returns>System.String.</returns>
        public string InsertBUCommitmentAdjustment(BUCommitmentAdjustmentEntity bUCommitmentAdjustment)
        {
            const string procedures = @"uspInsert_BUCommitmentAdjustment";
            return Db.Insert(procedures, true, Take(bUCommitmentAdjustment));
        }
         
        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentAdjustment">The b u commitment adjustment.</param>
        /// <returns>System.String.</returns>
        public string UpdateBUCommitmentAdjustment(BUCommitmentAdjustmentEntity bUCommitmentAdjustment)
        {
            const string procedures = @"uspUpdate_BUCommitmentAdjustment";
            return Db.Update(procedures, true, Take(bUCommitmentAdjustment));
        }


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentAdjustment">The b u commitment adjustment.</param>
        /// <returns>System.String.</returns>
        public string DeleteBUCommitmentAdjustment(BUCommitmentAdjustmentEntity bUCommitmentAdjustment)
        {
            const string procedures = @"uspDelete_BUCommitmentAdjustment";
            object[] parms = { "@RefId", bUCommitmentAdjustment.RefId };
            return Db.Delete(procedures, true, parms);
        }
    }
}
