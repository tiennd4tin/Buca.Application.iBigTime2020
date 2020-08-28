/***********************************************************************
 * <copyright file="SqlServerOpeningCommitmentDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, December 7, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, December 7, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Opening
{
    public class SqlServerOpeningCommitmentDao : IOpeningCommitmentDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningCommitmentEntity> Make = reader =>
   new OpeningCommitmentEntity
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
     //  Posted = reader["Posted"].AsBool(),
       EditVersion = reader["EditVersion"].AsInt(),
       PostVersion = reader["PostVersion"].AsInt(),
       ProjectInvestmentCode = reader["ProjectInvestmentCode"].AsString(),
       ProjectInvestmentName = reader["ProjectInvestmentName"].AsString(),
       SignDate = reader["SignDate"].AsDateTime(),
       ContractAmount = reader["ContractAmount"].AsDecimal(),
       PrevYearCommitmentAmount = reader["PrevYearCommitmentAmount"].AsDecimal(),

   };
        /// <summary>
        /// Takes the specified b u commitment request entity.
        /// </summary>
        /// <param name="bUCommitmentRequestEntity">The b u commitment request entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(OpeningCommitmentEntity bUCommitmentRequestEntity)
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
       // "@Posted",bUCommitmentRequestEntity.Posted,
        "@EditVersion",bUCommitmentRequestEntity.EditVersion,
        "@PostVersion",bUCommitmentRequestEntity.PostVersion,
        "@ProjectInvestmentCode",bUCommitmentRequestEntity.ProjectInvestmentCode,
        "@ProjectInvestmentName",bUCommitmentRequestEntity.ProjectInvestmentName,
        "@SignDate",bUCommitmentRequestEntity.SignDate,
        "@ContractAmount",bUCommitmentRequestEntity.ContractAmount,
        "@PrevYearCommitmentAmount",bUCommitmentRequestEntity.PrevYearCommitmentAmount,
            };
        }



        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>OpeningCommitmentEntity.</returns>
        public OpeningCommitmentEntity GetOpeningCommitmentbyRefId(string refId)
        {
            const string procedures = @"uspGet_OpeningCommitment_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;OpeningCommitmentEntity&gt;.</returns>
        public List<OpeningCommitmentEntity> GetOpeningCommitment()
        {
            const string procedures = @"uspGet_All_OpeningCommitment";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the bu plan receipt entity.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;OpeningCommitmentEntity&gt;.</returns>
        public List<OpeningCommitmentEntity> GetOpeningCommitment(string refTypeId)
        {
            const string procedures = @"uspGet_OpeningCommitment_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }
       public OpeningCommitmentEntity GetOpeningCommitmentbyRefNo(string refNo)
        {
            const string procedures = @"uspGet_OpeningCommitment_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }


        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;OpeningCommitmentEntity&gt;.</returns>
        public List<OpeningCommitmentEntity> GetOpeningCommitmentsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_OpeningCommitment_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        public string InsertOpeningCommitment(OpeningCommitmentEntity openingCommitment)
        {
            const string procedures = @"uspInsert_OpeningCommitment";
            return Db.Insert(procedures, true, Take(openingCommitment));
        }

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        public string UpdateOpeningCommitment(OpeningCommitmentEntity openingCommitment)
        {
            const string procedures = @"uspUpdate_OpeningCommitment";
            return Db.Update(procedures, true, Take(openingCommitment));
        }


        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        public string DeleteOpeningCommitment(OpeningCommitmentEntity openingCommitment)
        {
            const string procedures = @"uspDelete_OpeningCommitment";
            object[] parms = { "@RefId", openingCommitment.RefId };
            return Db.Delete(procedures, true, parms);
        }
    }
}
