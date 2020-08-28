/***********************************************************************
 * <copyright file="SqlServerBAWithDrawDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 23, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit
{
    /// <summary>
    ///     SqlServerBAWithDrawDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit.IBAWithDrawDao" />
    public class SqlServerBAWithDrawDao : IBAWithDrawDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BAWithDrawEntity> Make = reader =>
            new BAWithDrawEntity
            {
                RefId = reader["RefID"].AsString(),
                RefType = reader["RefType"].AsInt(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                ParalellRefNo = reader["ParalellRefNo"].AsString(),
                InwardRefNo = reader["InwardRefNo"].AsString(),
                IncrementRefNo = reader["IncrementRefNo"].AsString(),
                BankId = reader["BankID"].AsString(),
                BankName = reader["BankName"].AsString(),
                JournalMemo = reader["JournalMemo"].AsString(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                TotalTaxAmount = reader["TotalTaxAmount"].AsDecimal(),
                TotalFreightAmount = reader["TotalFreightAmount"].AsDecimal(),
                TotalInwardAmount = reader["TotalInwardAmount"].AsDecimal(),
                Reconciled = reader["Reconciled"].AsBool(),
                Posted = reader["Posted"].AsBool(),
                PostVersion = reader["PostVersion"].AsInt(),
                EditVersion = reader["EditVersion"].AsInt(),
                RefOrder = reader["RefOrder"].AsInt(),
                RelationRefId = reader["RelationRefID"].AsString(),
                RelationType = reader["RelationType"].AsInt(),
                TotalPaymentAmount = reader["TotalPaymentAmount"].AsDecimal(),
                ReceiveId = reader["ReceiveId"].AsString(),
                ReceiveIssueLocation = reader["ReceiveIssueLocation"].AsString(),
                ReceiveName = reader["ReceiveName"].AsString(),
                ReceiveIssueDate = reader["ReceiveIssueDate"].AsDateTimeForNull(),
                AccountingObjectBankAccount = reader["AccountingObjectBankAccount"].AsString()
            };

        /// <summary>
        ///     Gets the bAWithDraw.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     BAWithDrawEntity.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public BAWithDrawEntity GetBAWithDraw(string refId)
        {
            const string procedures = @"uspGet_BAWithDraw_ByID";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the bAWithDraws by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     List{BAWithDrawEntity}.
        /// </returns>
        public List<BAWithDrawEntity> GetBAWithDrawsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_BAWithDraw_ByRefType";

            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the bAWithDraws by year of reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfRefDate">The year of reference date.</param>
        /// <returns></returns>
        public List<BAWithDrawEntity> GetBAWithDrawsByYearOfRefDate(int refTypeId, short yearOfRefDate)
        {
            const string procedures = @"uspGet_BAWithDraw_ByRefType_By_PostedYear";
            object[] parms = { "@PostedDate", yearOfRefDate, "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the bAWithDraws by reference no and reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        public List<BAWithDrawEntity> GetBAWithDrawsByRefNoAndRefDate(int refTypeId, string refNo, DateTime refDate,
            string currencyCode)
        {
            const string procedures = @"uspGet_BAWithDraw_ByRefNoAndRefDate";
            object[] parms =
                {"@RefType", refTypeId, "@RefNo", refNo, "@RefDate", refDate, "CurrencyCode", currencyCode};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the BAWithDraw by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public BAWithDrawEntity GetBAWithDrawByRefNo(string refNo)
        {
            const string procedures = @"uspGet_BAWithDraw_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        public BAWithDrawEntity GetBAWithDrawByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_BAWithDraw_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the ba deposit by salary.
        /// </summary>
        /// <param name="dateMonth">The date month.</param>
        /// <returns></returns>
        public BAWithDrawEntity GetBAWithDrawBySalary(DateTime dateMonth)
        {
            const string procedures = @"uspGet_BAWithDraw_BySalaryDateMonth";
            object[] parms = { "@DateMonth", dateMonth.Month + "/" + dateMonth.Day + "/" + dateMonth.Year };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the bAWithDraws.
        /// </summary>
        /// <returns>
        ///     List{BAWithDrawEntity}.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BAWithDrawEntity> GetBAWithDraws()
        {
            const string procedures = @"uspGet_All_BAWithDraw";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        ///     Gets the bAWithDraw by refdate and reftype.
        /// </summary>
        /// <param name="bBAWithDrawEntity">The ob bAWithDraw entity.</param>
        /// <returns></returns>
        public BAWithDrawEntity GetBAWithDrawByRefdateAndReftype(BAWithDrawEntity bBAWithDrawEntity)
        {
            const string procedures = @"uspGet_BAWithDraw_ForSalary";
            object[] parms =
            {
                "@RefType", bBAWithDrawEntity.RefType, "@PostedDate", bBAWithDrawEntity.PostedDate, "@RefNo",
                bBAWithDrawEntity.RefNo
            };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bAWithDraw.
        /// </summary>
        /// <param name="bAWithDraw">The bAWithDraw.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public string InsertBAWithDraw(BAWithDrawEntity bAWithDraw)
        {
            const string sql = @"uspInsert_BAWithDraw";
            return Db.Insert(sql, true, Take(bAWithDraw));
        }

        /// <summary>
        ///     Updates the bAWithDraw.
        /// </summary>
        /// <param name="bAWithDraw">The bAWithDraw.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public string UpdateBAWithDraw(BAWithDrawEntity bAWithDraw)
        {
            const string sql = @"uspUpdate_BAWithDraw";
            return Db.Update(sql, true, Take(bAWithDraw));
        }

        /// <summary>
        ///     Deletes the bAWithDraw.
        /// </summary>
        /// <param name="bAWithDraw">The bAWithDraw.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string DeleteBAWithDraw(BAWithDrawEntity bAWithDraw)
        {
            const string sql = @"uspDelete_BAWithDraw";

            object[] parms = { "@RefID", bAWithDraw.RefId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        ///     Gets the ba deposits by salary.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        public BAWithDrawEntity GetBAWithDrawsBySalary(int refTypeId, string postedDate, string refNo,
            string currencyCode)
        {
            const string procedures = @"uspGet_BAWithDraw_BySalaryDateMonthAndRefNoAndCurrencyCode";
            object[] parms =
                {"@PostedDate", postedDate, "@RefTypeID", refTypeId, "@RefNo", refNo, "@CurrencyCode", currencyCode};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Takes the specified receipt voucher.
        /// </summary>
        /// <param name="bAWithDraw">The receipt voucher.</param>
        /// <returns></returns>
        private object[] Take(BAWithDrawEntity bAWithDraw)
        {
            return new object[]
            {
                "@RefID", bAWithDraw.RefId,
                "@RefType", bAWithDraw.RefType,
                "@RefDate", bAWithDraw.RefDate,
                "@PostedDate", bAWithDraw.PostedDate,
                "@RefNo", bAWithDraw.RefNo,
                "@CurrencyCode", bAWithDraw.CurrencyCode,
                "@ExchangeRate", bAWithDraw.ExchangeRate,
                "@ParalellRefNo", bAWithDraw.ParalellRefNo,
                "@InwardRefNo", bAWithDraw.InwardRefNo,
                "@IncrementRefNo", bAWithDraw.IncrementRefNo,
                "@BankID", bAWithDraw.BankId,
                "@BankName", bAWithDraw.BankName,
                "@JournalMemo", bAWithDraw.JournalMemo,
                "@AccountingObjectID", bAWithDraw.AccountingObjectId,
                "@TotalAmount", bAWithDraw.TotalAmount,
                "@TotalAmountOC", bAWithDraw.TotalAmountOC,
                "@TotalTaxAmount", bAWithDraw.TotalTaxAmount,
                "@TotalFreightAmount", bAWithDraw.TotalFreightAmount,
                "@TotalInwardAmount", bAWithDraw.TotalInwardAmount,
                "@Reconciled", bAWithDraw.Reconciled,
                "@Posted", bAWithDraw.Posted,
                "@PostVersion", bAWithDraw.PostVersion,
                "@EditVersion", bAWithDraw.EditVersion,
                "@RefOrder", bAWithDraw.RefOrder,
                "@RelationRefID", bAWithDraw.RelationRefId,
                "@TotalPaymentAmount", bAWithDraw.TotalPaymentAmount,
                 "@RelationType",bAWithDraw.RelationType,
                "@ReceiveName",bAWithDraw.ReceiveName,
                "@ReceiveId",bAWithDraw.ReceiveId,
                "@ReceiveIssueDate",bAWithDraw.ReceiveIssueDate,
                "@ReceiveIssueLocation",bAWithDraw.ReceiveIssueLocation,
                "@AccountingObjectBankAccount",bAWithDraw.AccountingObjectBankAccount
            };
        }
    }
}