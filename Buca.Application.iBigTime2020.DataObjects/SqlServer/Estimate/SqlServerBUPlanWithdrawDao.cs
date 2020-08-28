/***********************************************************************
 * <copyright file="SqlServerCashDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{

    /// <summary>
    /// SqlServerCashDao class
    /// </summary>
    public class SqlServerBUPlanWithdrawDao : DaoBase, IBUPlanWithdrawDao
    {

        /// <summary>
        /// Gets the cash.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUPlanWithdrawEntity.</returns>
        public BUPlanWithdrawEntity GetBUPlanWithdraw(string refId)
        {
            const string procedures = @"uspGet_BUPlanWithdraw_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make<BUPlanWithdrawEntity>, parms);
        }

        public IList<BUPlanWithdrawEntity> GetBUPlanWithdrawByRefTypeId(int refTypeId)
        {
            const string sql = @"uspGet_BUPlanWithdraw_ByRefTypeID";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(sql, true, Make<BUPlanWithdrawEntity>, parms);
        }

        /// <summary>
        /// Gets the ca receipt by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;BUPlanWithdrawEntity&gt;.</returns>
        public BUPlanWithdrawEntity GetBUPlanWithdrawByRefNo(string refNo)
        {
            const string procedures = @"uspGet_BUPlanWithdraw_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }
        /// <summary>
        /// Gets the type of the bu plan withdraw by reference no reference.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns>BUPlanWithdrawEntity.</returns>
        public BUPlanWithdrawEntity GetBUPlanWithdrawByRefNoRefType(string refNo, int refType)
        {
            const string procedures = @"uspGet_BUPlanWithdraw_ByRefNoRefType";
            object[] parms = { "@RefNo", refNo, "@RefType", refType };
            return Db.Read(procedures, true, Make, parms);
        }

        public BUPlanWithdrawEntity GetBUPlanWithdrawByRefNoRefType(string refNo, int refType, DateTime postedDate)
        {
            const string procedures = @"uspGet_BUPlanWithdraw_ByRefNoRefTypeAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@RefType", refType, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the ca receipts.
        /// </summary>
        /// <returns>List&lt;BUPlanWithdrawEntity&gt;.</returns>
        public IList<BUPlanWithdrawEntity> GetBUPlanWithdraws()
        {
            const string procedures = @"uspGet_All_BUPlanWithdraw";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the ca receipt.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        public string InsertBUPlanWithdraw(BUPlanWithdrawEntity receipt)

        {
            const string procedures = @"uspInsert_BUPlanWithdraw";
            return Db.Insert(procedures, true, Take(receipt));
        }

        /// <summary>
        /// Updates the cash entity.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        public string UpdateBUPlanWithdraw(BUPlanWithdrawEntity receipt)
        {
            const string procedures = @"uspUpdate_BUPlanWithdraw";
            return Db.Update(procedures, true, Take(receipt));
        }

        /// <summary>
        /// Deletes the cash entity.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        public string DeleteBUPlanWithdraw(BUPlanWithdrawEntity receipt)
        {
            const string procedures = @"uspDelete_BUPlanWithdraw";
            object[] parms = { "@RefID", receipt.RefId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUPlanWithdrawEntity> Make = reader =>
            new BUPlanWithdrawEntity
            {
                RefId = reader["RefID"].AsString(),
                CashWithDrawType = reader["CashWithDrawType"].AsInt(),
                RefType = reader["RefType"].AsInt(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                ParalellRefNo = reader["ParalellRefNo"].AsString(),
                TargetProgramId = reader["TargetProgramID"].AsString(),
                BankId = reader["BankID"].AsString(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                JournalMemo = reader["JournalMemo"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                GeneratedRefId = reader["GeneratedRefID"].AsString(),
                Posted = reader["Posted"].AsBool(),
                BUCommitmentRequestId = reader["BUCommitmentRequestID"].AsString(),
                AccountingObjectBankId = reader["AccountingObjectBankID"].AsString(),
            };

        /// <summary>
        /// Takes the specified take.
        /// </summary>
        /// <param name="bUPlanWithdrawEntity">The b u plan withdraw entity.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(BUPlanWithdrawEntity bUPlanWithdrawEntity)
        {
            return new object[]
            {
                "@RefID",bUPlanWithdrawEntity.RefId,
                "@CashWithDrawType",bUPlanWithdrawEntity.CashWithDrawType,
                "@RefType",bUPlanWithdrawEntity.RefType,
                "@RefDate",bUPlanWithdrawEntity.RefDate,
                "@PostedDate",bUPlanWithdrawEntity.PostedDate,
                "@RefNo",bUPlanWithdrawEntity.RefNo,
                "@CurrencyCode",bUPlanWithdrawEntity.CurrencyCode,
                "@ExchangeRate",bUPlanWithdrawEntity.ExchangeRate,
                "@ParalellRefNo",bUPlanWithdrawEntity.ParalellRefNo,
                "@TargetProgramID",bUPlanWithdrawEntity.TargetProgramId,
                "@BankID",bUPlanWithdrawEntity.BankId,
                "@AccountingObjectID",bUPlanWithdrawEntity.AccountingObjectId,
                "@JournalMemo",bUPlanWithdrawEntity.JournalMemo,
                "@TotalAmount",bUPlanWithdrawEntity.TotalAmount,
                "@TotalAmountOC",bUPlanWithdrawEntity.TotalAmountOC,
                "@GeneratedRefID",bUPlanWithdrawEntity.GeneratedRefId,
                "@Posted",bUPlanWithdrawEntity.Posted,
                "@BUCommitmentRequestID",bUPlanWithdrawEntity.BUCommitmentRequestId,
                "@AccountingObjectBankID",bUPlanWithdrawEntity.AccountingObjectBankId
            };
        }
    }
}
