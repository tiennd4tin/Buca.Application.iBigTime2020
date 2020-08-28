/***********************************************************************
 * <copyright file="SqlServerBADepositDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 16, 2017
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
    ///     SqlServerBADepositDao
    /// </summary>
    /// <seealso cref="IBADepositDao" />
    public class SqlServerBADepositDao : IBADepositDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BADepositEntity> Make = reader =>
            new BADepositEntity
            {
                RefId = reader["RefID"].AsString(),
                RefType = reader["RefType"].AsInt(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                ParalellRefNo = reader["ParalellRefNo"].AsString(),
                OutwardRefNo = reader["OutwardRefNo"].AsString(),
                AccountingObjectId = reader["AccountingObjectId"].AsString(),
                BankId = reader["BankId"].AsString(),
                InvType = reader["InvType"].AsString().AsIntForNull(),
                InvDate = reader["InvDate"].AsString().AsDateTimeForNull(),
                InvSeries = reader["InvSeries"].AsString(),
                InvNo = reader["InvNo"].AsString(),
                JournalMemo = reader["JournalMemo"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                TotalTaxAmount = reader["TotalTaxAmount"].AsDecimal(),
                TotalOutwardAmount = reader["TotalOutwardAmount"].AsDecimal(),
                Reconciled = reader["Reconciled"].AsBool(),
                Posted = reader["Posted"].AsBool(),
                PostVersion = reader["PostVersion"].AsString().AsIntForNull(),
                EditVersion = reader["EditVersion"].AsString().AsIntForNull(),
                RefOrder = reader["RefOrder"].AsString().AsIntForNull(),
                InvoiceForm = reader["InvoiceForm"].AsString().AsIntForNull(),
                InvoiceFormNumberId = reader["InvoiceFormNumberId"].AsString(),
                InvSeriesPrefix = reader["InvSeriesPrefix"].AsString(),
                InvSeriesSuffix = reader["InvSeriesSuffix"].AsString(),
                PayForm = reader["PayForm"].AsString(),
                ComPanyTaxcode = reader["ComPanyTaxcode"].AsString(),
                AccountingObjectContactName = reader["AccountingObjectContactName"].AsString(),
                ListNo = reader["ListNo"].AsString(),
                ListDate = reader["ListDate"].AsString().AsDateTimeForNull(),
                IsAttachList = reader["IsAttachList"].AsBool(),
                ListCommonNameInventory = reader["ListCommonNameInventory"].AsString(),
                BUCommitmentRequestId = reader["BUCommitmentRequestId"].AsString(),
                TotalReceiptAmount = reader["TotalReceiptAmount"].AsDecimal(),
                Payer = reader["Payer"].AsString(),
            };

        /// <summary>
        ///     Gets the bADeposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     BADepositEntity.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public BADepositEntity GetBADeposit(string refId)
        {
            const string procedures = @"uspGet_BADeposit_ByID";
            object[] parms = {"@RefID", refId};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the bADeposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>
        ///     List{BADepositEntity}.
        /// </returns>
        public List<BADepositEntity> GetBADepositsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_BADeposit_ByRefType";

            object[] parms = {"@RefType", refTypeId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the bADeposits by year of reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfRefDate">The year of reference date.</param>
        /// <returns></returns>
        public List<BADepositEntity> GetBADepositsByYearOfRefDate(int refTypeId, short yearOfRefDate)
        {
            const string procedures = @"uspGet_BADeposit_ByRefType_By_PostedYear";
            object[] parms = {"@PostedDate", yearOfRefDate, "@RefType", refTypeId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the bADeposits by reference no and reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        public List<BADepositEntity> GetBADepositsByRefNoAndRefDate(int refTypeId, string refNo, DateTime refDate,
            string currencyCode)
        {
            const string procedures = @"uspGet_BADeposit_ByRefNoAndRefDate";
            object[] parms =
                {"@RefType", refTypeId, "@RefNo", refNo, "@RefDate", refDate, "CurrencyCode", currencyCode};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the BADeposit by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public BADepositEntity GetBADepositByRefNo(string refNo, int refTypeId)
        {
            const string procedures = @"uspGet_BADeposit_ByRefNoAndRefType";
            object[] parms = {"@RefNo", refNo,"@RefType" ,refTypeId};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the BADeposit by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public BADepositEntity GetBADepositByRefNo(string refNo, int refTypeId, DateTime postedDate)
        {
            const string procedures = @"uspGet_BADeposit_ByRefNoAndRefTypeAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@RefType", refTypeId, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the ba deposit by salary.
        /// </summary>
        /// <param name="dateMonth">The date month.</param>
        /// <returns></returns>
        public BADepositEntity GetBADepositBySalary(DateTime dateMonth)
        {
            const string procedures = @"uspGet_BADeposit_BySalaryDateMonth";
            object[] parms = {"@DateMonth", dateMonth.Month + "/" + dateMonth.Day + "/" + dateMonth.Year};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Gets the bADeposits.
        /// </summary>
        /// <returns>
        ///     List{BADepositEntity}.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BADepositEntity> GetBADeposits()
        {
            const string procedures = @"uspGet_All_BADeposit";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        ///     Gets the bADeposit by refdate and reftype.
        /// </summary>
        /// <param name="bBADepositEntity">The ob bADeposit entity.</param>
        /// <returns></returns>
        public BADepositEntity GetBADepositByRefdateAndReftype(BADepositEntity bBADepositEntity)
        {
            const string procedures = @"uspGet_BADeposit_ForSalary";
            object[] parms =
            {
                "@RefType", bBADepositEntity.RefType, "@PostedDate", bBADepositEntity.PostedDate, "@RefNo",
                bBADepositEntity.RefNo
            };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit.
        /// </summary>
        /// <param name="bADeposit">The bADeposit.</param>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public string InsertBADeposit(BADepositEntity bADeposit)
        {
            const string sql = @"uspInsert_BADeposit";
            return Db.Insert(sql, true, Take(bADeposit));
        }

        /// <summary>
        ///     Updates the bADeposit.
        /// </summary>
        /// <param name="bADeposit">The bADeposit.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public string UpdateBADeposit(BADepositEntity bADeposit)
        {
            const string sql = @"uspUpdate_BADeposit";
            return Db.Update(sql, true, Take(bADeposit));
        }

        /// <summary>
        ///     Deletes the bADeposit.
        /// </summary>
        /// <param name="bADeposit">The bADeposit.</param>
        /// <returns>
        ///     System.String.
        /// </returns>
        public string DeleteBADeposit(BADepositEntity bADeposit)
        {
            const string sql = @"uspDelete_BADeposit";

            object[] parms = {"@RefID", bADeposit.RefId};
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
        public BADepositEntity GetBADepositsBySalary(int refTypeId, string postedDate, string refNo,
            string currencyCode)
        {
            const string procedures = @"uspGet_BADeposit_BySalaryDateMonthAndRefNoAndCurrencyCode";
            object[] parms =
                {"@PostedDate", postedDate, "@RefTypeID", refTypeId, "@RefNo", refNo, "@CurrencyCode", currencyCode};
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Takes the specified receipt voucher.
        /// </summary>
        /// <param name="bADeposit">The receipt voucher.</param>
        /// <returns></returns>
        private object[] Take(BADepositEntity bADeposit)
        {
            return new object[]
            {
                "@RefID", bADeposit.RefId,
                "@RefType", bADeposit.RefType,
                "@RefNo", bADeposit.RefNo,
                "@RefDate", bADeposit.RefDate,
                "@PostedDate", bADeposit.PostedDate,
                "@CurrencyCode", bADeposit.CurrencyCode,
                "@ExchangeRate", bADeposit.ExchangeRate,
                "@ParalellRefNo", bADeposit.ParalellRefNo,
                "@OutwardRefNo", bADeposit.OutwardRefNo,
                "@AccountingObjectID", bADeposit.AccountingObjectId,
                "@BankID", bADeposit.BankId,
                "@InvType", bADeposit.InvType,
                "@InvDate", bADeposit.InvDate,
                "@InvSeries", bADeposit.InvSeries,
                "@InvNo", bADeposit.InvNo,
                "@JournalMemo", bADeposit.JournalMemo,
                "@TotalAmount", bADeposit.TotalAmount,
                "@TotalAmountOC", bADeposit.TotalAmountOC,
                "@TotalTaxAmount", bADeposit.TotalTaxAmount,
                "@TotalOutwardAmount", bADeposit.TotalOutwardAmount,
                "@Reconciled", bADeposit.Reconciled,
                "@Posted", bADeposit.Posted,
                "@PostVersion", bADeposit.PostVersion,
                "@EditVersion", bADeposit.EditVersion,
                "@RefOrder", bADeposit.RefOrder,
                "@InvoiceForm", bADeposit.InvoiceForm,
                "@InvoiceFormNumberID", bADeposit.InvoiceFormNumberId,
                "@InvSeriesPrefix", bADeposit.InvSeriesPrefix,
                "@InvSeriesSuffix", bADeposit.InvSeriesSuffix,
                "@PayForm", bADeposit.PayForm,
                "@ComPanyTaxcode", bADeposit.ComPanyTaxcode,
                "@AccountingObjectContactName", bADeposit.AccountingObjectContactName,
                "@ListNo", bADeposit.ListNo,
                "@ListDate", bADeposit.ListDate,
                "@IsAttachList", bADeposit.IsAttachList,
                "@ListCommonNameInventory", bADeposit.ListCommonNameInventory,
                "@BUCommitmentRequestId", bADeposit.BUCommitmentRequestId,
                "@TotalReceiptAmount", bADeposit.TotalReceiptAmount,
                "@Payer", bADeposit.Payer,
            };
        }
    }
}