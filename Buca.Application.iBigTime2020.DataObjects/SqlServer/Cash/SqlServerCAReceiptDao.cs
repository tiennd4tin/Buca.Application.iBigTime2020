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
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataHelpers;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Cash
{

    /// <summary>
    /// SqlServerCashDao class
    /// </summary>
    public class SqlServerCAReceiptDao : ICAReceiptDao
    {

        /// <summary>
        /// Gets the cash.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAReceiptEntity.</returns>
        public CAReceiptEntity GetCAReceipt(string refId)
        {
            const string procedures = @"uspGet_CAReceipt_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, MakeDetail, parms); 
        }

        public List<CAReceiptEntity> GetCAReceiptByRefTypeID(int refTypeId)
        {
            const string sql = @"uspGet_CAReceipt_ByRefTypeID";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the ca receipt by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>List&lt;CAReceiptEntity&gt;.</returns>
        public CAReceiptEntity GetCAReceiptByRefNo(string refNo)
        {
            const string procedures = @"uspGet_CAReceipt_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the ca receipt by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns>CAReceiptEntity.</returns>
        public CAReceiptEntity GetCAReceiptByRefNo(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_CAReceipt_ByRefNoAndPostedDate";
            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }
        /// <summary>
        /// Gets the ca receipt by planWithDrawRefID.
        /// </summary>
        /// <param name="planWithDrawRefID">The planWithDrawRefID.</param>     
        /// <returns>CAReceiptEntity.</returns>
        public CAReceiptEntity GetCAReceiptByBuPlanWithDrawRefID(string planWithDrawRefID)
        {
            const string procedures = @"uspGet_CAReceipt_ByBUPlanWithDrawRefID";
            object[] parms = { "@ByBUPlanWithDrawRefID", planWithDrawRefID };
            return Db.Read(procedures, true, Make, parms);
        }
        /// <summary>
        /// Gets the ca receipts.
        /// </summary>
        /// <returns>List&lt;CAReceiptEntity&gt;.</returns>
        public List<CAReceiptEntity> GetCAReceipts()
        {
            const string procedures = @"uspGet_All_CAReceipt";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the ca receipt.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        public string InsertCAReceipt(CAReceiptEntity receipt)

        {
            const string procedures = @"uspInsert_CAReceipt";
            return Db.Update(procedures, true, TakeInsert(receipt)); 
        }

        /// <summary>
        /// Updates the cash entity.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        public string UpdateCAReceipt(CAReceiptEntity receipt)
        {
            const string procedures = @"uspUpdate_CAReceipt";
            return Db.Update(procedures, true, TakeInsert(receipt));
        }

        /// <summary>
        /// Deletes the cash entity.
        /// </summary>
        /// <param name="receipt">The receipt.</param>
        /// <returns>System.String.</returns>
        public string DeleteCAReceipt(CAReceiptEntity receipt)
        {
            const string procedures = @"uspDelete_CAReceipt";
            object[] parms = { "@RefID", receipt.RefId };
            return Db.Delete(procedures, true, parms);
        }

        //public  string UpdateEmployeePayroll(string orgrefNo,string replaceRefNo, string monthDate)
        //{
        //    const string procedures = @"uspUpdate_CashSalaryReNo";
        //    object[] parms = { "@RefNo", orgrefNo, "@ReplaceRefNo", replaceRefNo, "@MonthDate", monthDate };
        //    return Db.Update(procedures, true, parms);
        //}

        //public string DeleteEmployeePayroll(string refNo, string postedDate)
        //{
        //    const string sql = @"uspDelete_EmployeePayroll";
        //    object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
        //    return Db.Delete(sql, true, parms);
        //}

        //public List<CAReceiptEntity> GetCashesByRefNoAndRefDate(int refTypeId, DateTime refDate, string refNo, string currencyCode)
        //{
        //    const string procedures = @"uspGet_Cash_ByRefNo_RefDate";
        //    object[] parms = { "@RefTypeID", refTypeId, "@RefDate", refDate, "RefNo", refNo, "@CurrencyCode", currencyCode };
        //    return Db.ReadList(procedures, true, Make, parms);
        //}

        //public CAReceiptEntity GetCashByRefdateAndReftype(CAReceiptEntity obCashEntity)
        //{
        //    const string procedures = @"uspGet_Cash_ForSalary";
        //    object[] parms = { "@RefTypeID", obCashEntity.RefTypeId, "@PostedDate", obCashEntity.PostedDate, "@RefNo", obCashEntity.RefNo };
        //    return Db.Read(procedures, true, Make, parms);
        //}

        //public CAReceiptEntity GetCashForSalaryByRefNo(string refNo)
        //{
        //    const string procedures = @"uspGet_Cash_ByRefNo";
        //    object[] parms = { "@RefNo", refNo };
        //    return Db.Read(procedures, true, Make, parms);
        //}

        //public CAReceiptEntity GetCashForSalaryByDateMonth(DateTime dateMonth)
        //{
        //    const string procedures = @"uspGet_Cash_BySalaryDateMonth";
        //    object[] parms = { "@DateMonth", dateMonth.Month + "/" + dateMonth.Day + "/" + dateMonth.Year };
        //    return Db.Read(procedures, true, Make, parms);
        //}

        //public CAReceiptEntity GetCashBySalary(int refTypeId, string postedDate, string refNo, string currencyCode)
        //{
        //    const string procedures = @"uspGet_Cash_BySalaryDateMonthAndRefNoAndCurrencyCode";
        //    object[] parms = { "@PostedDate", postedDate, "@RefTypeID", refTypeId, "@RefNo", refNo, "@CurrencyCode", currencyCode };
        //    return Db.Read(procedures, true, Make, parms);
        //}

        //public List<CAReceiptEntity> GetCashesByRefTypeId(int refTypeId, int year)
        //{
        //    const string procedures = @"uspGet_Cash_ByRefTypeID";
        //    object[] parms = { "@RefTypeID", refTypeId };
        //    return Db.ReadList(procedures, true, Make, parms);
        //}


        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CAReceiptEntity> Make = reader =>
           new CAReceiptEntity
           {
               RefId = reader["RefId"].AsString(),
               RefType = reader["RefType"].AsInt(),
               RefDate = reader["RefDate"].AsDateTime(),
               PostedDate = reader["PostedDate"].AsDateTime(),
               RefNo = reader["RefNo"].AsString(),
               CurrencyCode = reader["CurrencyCode"].AsString(),
               ExchangeRate = reader["ExchangeRate"].AsDecimal(),
               ParalellRefNo = reader["ParalellRefNo"].AsString(),
               OutwardRefNo = reader["OutwardRefNo"].AsString(),
               AccountingObjectId = reader["AccountingObjectId"].AsString(),
               JournalMemo = reader["JournalMemo"].AsString(),
               DocumentIncluded = reader["DocumentIncluded"].AsString(),
               InvType = reader["InvType"].AsInt(),
               InvDateOrWithdrawRefDate = reader["InvDateOrWithdrawRefDate"].AsDateTimeForNull(),
               InvSeries = reader["InvSeries"].AsString(),
               InvNoOrWithdrawRefNo = reader["InvNoOrWithdrawRefNo"].AsString(),
               BankId = reader["BankId"].AsString(),
               TotalAmount = reader["TotalAmount"].AsDecimal(),
               TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
               TotalTaxAmount = reader["TotalTaxAmount"].AsDecimal(),
               TotalOutwardAmount = reader["TotalOutwardAmount"].AsDecimal(),
               Posted = reader["Posted"].AsBool(),
               RefOrder = reader["RefOrder"].AsInt(),
               InvoiceForm = reader["InvoiceForm"].AsInt(),
               InvoiceFormNumberId = reader["InvoiceFormNumberId"].AsString(),
               InvSeriesPrefix = reader["InvSeriesPrefix"].AsString(),
               InvSeriesSuffix = reader["InvSeriesSuffix"].AsString(),
               PayForm = reader["PayForm"].AsString(),
               CompanyTaxcode = reader["CompanyTaxcode"].AsString(),
               RelationRefId = reader["RelationRefId"].AsString(),
               BUCommitmentRequestId = reader["BUCommitmentRequestId"].AsString(),
               AccountingObjectContactName = reader["AccountingObjectContactName"].AsString(),
               ListNo = reader["ListNo"].AsString(),
               ListDate = reader["ListDate"].AsDateTimeForNull(),
               IsAttachList = reader["IsAttachList"].AsBool(),
               ListCommonNameInventory = reader["ListCommonNameInventory"].AsString(),
               TotalReceiptAmount = reader["TotalReceiptAmount"].AsDecimal(),
               Payer = reader["Payer"].AsString()
           };
        private static readonly Func<IDataReader, CAReceiptEntity> MakeDetail = reader =>
           new CAReceiptEntity
           {
               RefId = reader["RefId"].AsString(),
               RefType = reader["RefType"].AsInt(),
               RefDate = reader["RefDate"].AsDateTime(),
               PostedDate = reader["PostedDate"].AsDateTime(),
               Address = reader["Address"].AsString(),
               RefNo = reader["RefNo"].AsString(),
               CurrencyCode = reader["CurrencyCode"].AsString(),
               ExchangeRate = reader["ExchangeRate"].AsDecimal(),
               ParalellRefNo = reader["ParalellRefNo"].AsString(),
               OutwardRefNo = reader["OutwardRefNo"].AsString(),
               AccountingObjectId = reader["AccountingObjectId"].AsString(),
               JournalMemo = reader["JournalMemo"].AsString(),
               DocumentIncluded = reader["DocumentIncluded"].AsString(),
               InvType = reader["InvType"].AsInt(),
               InvDateOrWithdrawRefDate = reader["InvDateOrWithdrawRefDate"].AsDateTimeForNull(),
               InvSeries = reader["InvSeries"].AsString(),
               InvNoOrWithdrawRefNo = reader["InvNoOrWithdrawRefNo"].AsString(),
               BankId = reader["BankId"].AsString(),
               TotalAmount = reader["TotalAmount"].AsDecimal(),
               TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
               TotalTaxAmount = reader["TotalTaxAmount"].AsDecimal(),
               TotalOutwardAmount = reader["TotalOutwardAmount"].AsDecimal(),
               Posted = reader["Posted"].AsBool(),
               RefOrder = reader["RefOrder"].AsInt(),
               InvoiceForm = reader["InvoiceForm"].AsInt(),
               InvoiceFormNumberId = reader["InvoiceFormNumberId"].AsString(),
               InvSeriesPrefix = reader["InvSeriesPrefix"].AsString(),
               InvSeriesSuffix = reader["InvSeriesSuffix"].AsString(),
               PayForm = reader["PayForm"].AsString(),
               CompanyTaxcode = reader["CompanyTaxcode"].AsString(),
               RelationRefId = reader["RelationRefId"].AsString(),
               BUCommitmentRequestId = reader["BUCommitmentRequestId"].AsString(),
               AccountingObjectContactName = reader["AccountingObjectContactName"].AsString(),
               ListNo = reader["ListNo"].AsString(),
               ListDate = reader["ListDate"].AsDateTimeForNull(),
               IsAttachList = reader["IsAttachList"].AsBool(),
               ListCommonNameInventory = reader["ListCommonNameInventory"].AsString(),
               TotalReceiptAmount = reader["TotalReceiptAmount"].AsDecimal(),
               Payer = reader["Payer"].AsString()
           };
        /// <summary>
        /// Takes the specified take.
        /// </summary>
        /// <param name="cAReceiptEntity">The c a receipt entity.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(CAReceiptEntity cAReceiptEntity)
        {
            return new object[]
            {
                "@RefId",cAReceiptEntity.RefId,
                "@RefType",cAReceiptEntity.RefType,
                "@RefDate",cAReceiptEntity.RefDate,
                "@PostedDate",cAReceiptEntity.PostedDate,
                "@RefNo",cAReceiptEntity.RefNo,
                "@CurrencyCode",cAReceiptEntity.CurrencyCode,
                "@ExchangeRate",cAReceiptEntity.ExchangeRate,
                "@ParalellRefNo",cAReceiptEntity.ParalellRefNo,
                "@OutwardRefNo",cAReceiptEntity.OutwardRefNo,
                "@AccountingObjectId",cAReceiptEntity.AccountingObjectId,
                "@JournalMemo",cAReceiptEntity.JournalMemo,
                "@DocumentIncluded",cAReceiptEntity.DocumentIncluded,
                "@InvType",cAReceiptEntity.InvType,
                "@InvDateOrWithdrawRefDate",cAReceiptEntity.InvDateOrWithdrawRefDate,
                "@InvSeries",cAReceiptEntity.InvSeries,
                "@InvNoOrWithdrawRefNo",cAReceiptEntity.InvNoOrWithdrawRefNo,
                "@BankId",cAReceiptEntity.BankId,
                "@TotalAmount",cAReceiptEntity.TotalAmount,
                "@TotalAmountOC",cAReceiptEntity.TotalAmountOC,
                "@TotalTaxAmount",cAReceiptEntity.TotalTaxAmount,
                "@TotalOutwardAmount",cAReceiptEntity.TotalOutwardAmount,
                "@Posted",cAReceiptEntity.Posted,
                "@RefOrder",cAReceiptEntity.RefOrder,
                "@InvoiceForm",cAReceiptEntity.InvoiceForm,
                "@InvoiceFormNumberId",cAReceiptEntity.InvoiceFormNumberId,
                "@InvSeriesPrefix",cAReceiptEntity.InvSeriesPrefix,
                "@InvSeriesSuffix",cAReceiptEntity.InvSeriesSuffix,
                "@PayForm",cAReceiptEntity.PayForm,
                "@CompanyTaxcode",cAReceiptEntity.CompanyTaxcode,
                "@RelationRefId",cAReceiptEntity.RelationRefId,
                "@BUCommitmentRequestId",cAReceiptEntity.BUCommitmentRequestId,
                "@AccountingObjectContactName",cAReceiptEntity.AccountingObjectContactName,
                "@ListNo",cAReceiptEntity.ListNo,
                "@ListDate",cAReceiptEntity.ListDate,
                "@IsAttachList",cAReceiptEntity.IsAttachList,
                "@ListCommonNameInventory",cAReceiptEntity.ListCommonNameInventory,
                "@TotalReceiptAmount",cAReceiptEntity.TotalReceiptAmount,
                "@BUPlanWithdrawRefID",cAReceiptEntity.BUPlanWithdrawRefId,
                "@Payer",cAReceiptEntity.Payer

            };
        }
        private object[] TakeInsert(CAReceiptEntity cAReceiptEntity)
        {
            return new object[]
            {
                "@RefId",cAReceiptEntity.RefId,
                "@RefType",cAReceiptEntity.RefType,
                "@RefDate",cAReceiptEntity.RefDate,
                "@PostedDate",cAReceiptEntity.PostedDate,
                "@RefNo",cAReceiptEntity.RefNo,
                "@CurrencyCode",cAReceiptEntity.CurrencyCode,
                "@ExchangeRate",cAReceiptEntity.ExchangeRate,
                "@ParalellRefNo",cAReceiptEntity.ParalellRefNo,
                "@OutwardRefNo",cAReceiptEntity.OutwardRefNo,
                "@AccountingObjectId",cAReceiptEntity.AccountingObjectId,
                "@JournalMemo",cAReceiptEntity.JournalMemo,
                "@DocumentIncluded",cAReceiptEntity.DocumentIncluded,
                "@InvType",cAReceiptEntity.InvType,
                "@InvDateOrWithdrawRefDate",cAReceiptEntity.InvDateOrWithdrawRefDate,
                "@InvSeries",cAReceiptEntity.InvSeries,
                "@InvNoOrWithdrawRefNo",cAReceiptEntity.InvNoOrWithdrawRefNo,
                "@BankId",cAReceiptEntity.BankId,
                "@TotalAmount",cAReceiptEntity.TotalAmount,
                "@TotalAmountOC",cAReceiptEntity.TotalAmountOC,
                "@TotalTaxAmount",cAReceiptEntity.TotalTaxAmount,
                "@TotalOutwardAmount",cAReceiptEntity.TotalOutwardAmount,
                "@Posted",cAReceiptEntity.Posted,
                "@RefOrder",cAReceiptEntity.RefOrder,
                "@InvoiceForm",cAReceiptEntity.InvoiceForm,
                "@InvoiceFormNumberId",cAReceiptEntity.InvoiceFormNumberId,
                "@InvSeriesPrefix",cAReceiptEntity.InvSeriesPrefix,
                "@InvSeriesSuffix",cAReceiptEntity.InvSeriesSuffix,
                "@PayForm",cAReceiptEntity.PayForm,
                "@CompanyTaxcode",cAReceiptEntity.CompanyTaxcode,
                "@RelationRefId",cAReceiptEntity.RelationRefId,
                "@BUCommitmentRequestId",cAReceiptEntity.BUCommitmentRequestId,
                "@AccountingObjectContactName",cAReceiptEntity.AccountingObjectContactName,
                "@ListNo",cAReceiptEntity.ListNo,
                "@ListDate",cAReceiptEntity.ListDate,
                "@IsAttachList",cAReceiptEntity.IsAttachList,
                "@ListCommonNameInventory",cAReceiptEntity.ListCommonNameInventory,
                "@TotalReceiptAmount",cAReceiptEntity.TotalReceiptAmount,
                "@BUPlanWithdrawRefID",cAReceiptEntity.BUPlanWithdrawRefId,
                "@Payer",cAReceiptEntity.Payer,
                "@Address",cAReceiptEntity.Address

            };
        }

    }
}
