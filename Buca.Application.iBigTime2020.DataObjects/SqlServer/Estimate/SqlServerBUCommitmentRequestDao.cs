/***********************************************************************
 * <copyright file="SqlServerBUCommitmentRequestDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Tuesday, December 5, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateTuesday, December 5, 2017Author SonTV  Description 
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
    /// Class SqlServerBUCommitmentRequestDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate.IBUCommitmentRequestDao" />
    public class SqlServerBUCommitmentRequestDao : IBUCommitmentRequestDao
    {

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUCommitmentRequestEntity> Make = reader =>
   new BUCommitmentRequestEntity
   {
       RefId = reader["RefID"].AsString(),
       RefDate = reader["RefDate"].AsDateTime(),
       PostedDate = reader["PostedDate"].AsDateTime(),
       RefNo = reader["RefNo"].AsString(),
       RefType = reader["RefType"].AsInt(),
       AccountingObjectId = reader["AccountingObjectID"].AsString(),
       AccountingObjectName = reader["AccountingObjectName"].AsString(),
       TABMISCode = reader["TABMISCode"].AsString(),
       BankAccount = reader["BankAccount"].AsString(),
       BankName = reader["BankName"].AsString(),
       ContractNo = reader["ContractNo"].AsString(),
       ContractFrameNo = reader["ContractFrameNo"].AsString(),
       BudgetSourceKind = reader["BudgetSourceKind"].AsInt(),
       TotalAmount = reader["TotalAmount"].AsDecimal(),
       TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
       IsForeignCurrency = reader["IsForeignCurrency"].AsBool(),
       Posted = reader["Posted"].AsBool(),
       EditVersion = reader["EditVersion"].AsInt(),
       PostVersion = reader["PostVersion"].AsInt(),
       ProjectInvestmentCode = reader["ProjectInvestmentCode"].AsString(),
       ProjectInvestmentName = reader["ProjectInvestmentName"].AsString(),
       SignDate = reader["SignDate"].AsDateTime(),
       ContractAmount = reader["ContractAmount"].AsDecimal(),
       PrevYearCommitmentAmount = reader["PrevYearCommitmentAmount"].AsDecimal()

   };
        /// <summary>
        /// Takes the specified b u commitment request entity.
        /// </summary>
        /// <param name="bUCommitmentRequestEntity">The b u commitment request entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(BUCommitmentRequestEntity bUCommitmentRequestEntity)
        {
            return new object[]
            {

        "@RefID",bUCommitmentRequestEntity.RefId,
        "@RefDate",bUCommitmentRequestEntity.RefDate,
        "@PostedDate",bUCommitmentRequestEntity.PostedDate,
        "@RefNo",bUCommitmentRequestEntity.RefNo,
        "@RefType",bUCommitmentRequestEntity.RefType,
        "@AccountingObjectID",bUCommitmentRequestEntity.AccountingObjectId,
        "@AccountingObjectName",bUCommitmentRequestEntity.AccountingObjectName,
        "@TABMISCode",bUCommitmentRequestEntity.TABMISCode,
        "@BankAccount",bUCommitmentRequestEntity.BankAccount,
        "@BankName",bUCommitmentRequestEntity.BankName,
        "@ContractNo",bUCommitmentRequestEntity.ContractNo,
        "@ContractFrameNo",bUCommitmentRequestEntity.ContractFrameNo,
        "@BudgetSourceKind",bUCommitmentRequestEntity.BudgetSourceKind,
        "@TotalAmount",bUCommitmentRequestEntity.TotalAmount,
        "@TotalAmountOC",bUCommitmentRequestEntity.TotalAmountOC,
        "@IsForeignCurrency",bUCommitmentRequestEntity.IsForeignCurrency,
        "@Posted",bUCommitmentRequestEntity.Posted,
        "@EditVersion",bUCommitmentRequestEntity.EditVersion,
        "@PostVersion",bUCommitmentRequestEntity.PostVersion,
        "@ProjectInvestmentCode",bUCommitmentRequestEntity.ProjectInvestmentCode,
        "@ProjectInvestmentName",bUCommitmentRequestEntity.ProjectInvestmentName,
        "@SignDate",bUCommitmentRequestEntity.SignDate,
        "@ContractAmount",bUCommitmentRequestEntity.ContractAmount,
        "@PrevYearCommitmentAmount",bUCommitmentRequestEntity.PrevYearCommitmentAmount

            };
        }



        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUCommitmentRequestEntity.</returns>
        public BUCommitmentRequestEntity GetBUCommitmentRequestbyRefId(string refId)
        {
            const string procedures = @"uspGet_BUCommitmentRequest_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;BUCommitmentRequestEntity&gt;.</returns>
        public List<BUCommitmentRequestEntity> GetBUCommitmentRequest()
        {
            const string procedures = @"uspGet_All_BUCommitmentRequest";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the bu plan receipt entity.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestEntity&gt;.</returns>
        public List<BUCommitmentRequestEntity> GetBUCommitmentRequest(string refTypeId)
        {
            const string procedures = @"uspGet_BUCommitmentRequest_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }
        public BUCommitmentRequestEntity GetBUCommitmentRequestByRefNo(string refNo)
        {
            const string procedures = @"uspGet_BUCommitmentRequest_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }
        public BUCommitmentRequestEntity GetBUCommitmentRequestByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_BUCommitmentRequest_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestEntity&gt;.</returns>
        public List<BUCommitmentRequestEntity> GetBUCommitmentRequestsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_BUCommitmentRequest_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        public string InsertBUCommitmentRequest(BUCommitmentRequestEntity bUCommitmentRequest)
        {
            const string procedures = @"uspInsert_BUCommitmentRequest";
            return Db.Insert(procedures, true, Take(bUCommitmentRequest));
        }

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        public string UpdateBUCommitmentRequest(BUCommitmentRequestEntity bUCommitmentRequest)
        {
            const string procedures = @"uspUpdate_BUCommitmentRequest";
            return Db.Update(procedures, true, Take(bUCommitmentRequest));
        }


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        public string DeleteBUCommitmentRequest(BUCommitmentRequestEntity bUCommitmentRequest)
        {
            const string procedures = @"uspDelete_BUCommitmentRequest";
            object[] parms = { "@RefId", bUCommitmentRequest.RefId };
            return Db.Delete(procedures, true, parms);
        }
    }
}
