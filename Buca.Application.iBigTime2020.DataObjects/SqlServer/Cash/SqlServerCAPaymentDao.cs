using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Cash{

    /// <summary>
    /// SqlServerCAPaymentDao
    /// </summary>
    public class SqlServerCAPaymentDao : ICAPaymentDao
    {
        public string DeleteCAPayment(CAPaymentEntity caPayment)
        {
            const string procedures = @"uspDelete_CAPayment";
            object[] parms = { "@RefId", caPayment.RefId};
            return Db.Delete(procedures, true, parms);
        }

        public string DeleteCAPaymentByRefId(string refId)
        {
            const string procedures = @"uspDelete_CAPayment";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the ca payment.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        public CAPaymentEntity GetCaPayment(string refNo, DateTime postedDate)
        {
            const string procedures = @"uspGet_CAPayment_ByRefNoAndPostedDate";

            object[] parms = { "@RefNo", refNo, "@PostedDate", postedDate };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the ca payment.
        /// </summary>
        /// <returns></returns>
        public List<CAPaymentEntity> GetCaPayment()
        {
            const string procedures = @"uspGet_All_CAPayment";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the ca payments by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<CAPaymentEntity> GetCaPaymentsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_CAPaymentByRefTypeId";
            object[] parms = { "@RefTypeID", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public CAPaymentEntity GetCaPaymentEntitybyRefId(string refId)
        {
            const string procedures = @"uspGet_CAPayment_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.Read(procedures, true, MakeDetail, parms);
        }

        public CAPaymentEntity GetCaPaymentEntitybyRefNo(string refNo, int refType)
        {
            const string procedures = @"uspGet_CAPayment_ByRefNo";
            object[] parms = { "@RefNo", refNo, "@RefType", refType };
            return Db.Read(procedures, true, Make, parms);
        }

        public string InsertCAPayment(CAPaymentEntity caPayment)
        {
            const string procedures = @"uspInsert_CAPayment";
            return Db.Insert(procedures, true, TakeInsert(caPayment));
        }
         
        public string UpdateCAPayment(CAPaymentEntity caPayment)
        {
            const string procedures = @"uspUpdate_CAPayment";
            return Db.Update(procedures, true, TakeInsert(caPayment));
        }

        private static readonly Func< IDataReader, CAPaymentEntity> Make = reader =>
            new CAPaymentEntity
            {
                RefId = reader["RefId"].AsString(),
                RefType = reader["RefType"].AsInt(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                ParalellRefNo = reader["ParalellRefNo"].AsString(),
                IncrementRefNo = reader["IncrementRefNo"].AsString(),
                InwardRefNo = reader["InwardRefNo"].AsString(),
                AccountingObjectId = reader["AccountingObjectId"].AsString(),
                JournalMemo = reader["JournalMemo"].AsString(),
                DocumentIncluded = reader["DocumentIncluded"].AsString(),
                BankId = reader["BankId"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                TotalTaxAmount = reader["TotalTaxAmount"].AsDecimal(),
                TotalFreightAmount = reader["TotalFreightAmount"].AsDecimal(),
                TotalInwardAmount = reader["TotalInwardAmount"].AsDecimal(),
                Posted = reader["Posted"].AsBool(),
                RefOrder = reader["RefOrder"].AsInt(),
                RelationRefId = reader["RelationRefId"].AsString(),
                TotalPaymentAmount = reader["TotalPaymentAmount"].AsDecimal(),
                Receiver = reader["Receiver"].AsString(),

            };
        private static readonly Func<IDataReader, CAPaymentEntity> MakeDetail = reader =>
         new CAPaymentEntity
         {
             RefId = reader["RefId"].AsString(),
             RefType = reader["RefType"].AsInt(),
             Address = reader["Address"].AsString(),
             RefDate = reader["RefDate"].AsDateTime(),
             PostedDate = reader["PostedDate"].AsDateTime(),
             RefNo = reader["RefNo"].AsString(),
             CurrencyCode = reader["CurrencyCode"].AsString(),
             ExchangeRate = reader["ExchangeRate"].AsDecimal(),
             ParalellRefNo = reader["ParalellRefNo"].AsString(),
             IncrementRefNo = reader["IncrementRefNo"].AsString(),
             InwardRefNo = reader["InwardRefNo"].AsString(),
             AccountingObjectId = reader["AccountingObjectId"].AsString(),
             JournalMemo = reader["JournalMemo"].AsString(),
             DocumentIncluded = reader["DocumentIncluded"].AsString(),
             BankId = reader["BankId"].AsString(),
             TotalAmount = reader["TotalAmount"].AsDecimal(),
             TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
             TotalTaxAmount = reader["TotalTaxAmount"].AsDecimal(),
             TotalFreightAmount = reader["TotalFreightAmount"].AsDecimal(),
             TotalInwardAmount = reader["TotalInwardAmount"].AsDecimal(),
             Posted = reader["Posted"].AsBool(),
             RefOrder = reader["RefOrder"].AsInt(),
             RelationRefId = reader["RelationRefId"].AsString(),
             TotalPaymentAmount = reader["TotalPaymentAmount"].AsDecimal(),
             Receiver = reader["Receiver"].AsString(),

         };
        private static object[] Take(CAPaymentEntity cAPaymentEntity)
        {
            return new object[]
            {

                "@RefId", cAPaymentEntity.RefId,
                "@RefType", cAPaymentEntity.RefType,
                "@RefDate", cAPaymentEntity.RefDate,
                "@PostedDate", cAPaymentEntity.PostedDate,
                "@RefNo", cAPaymentEntity.RefNo,
                "@CurrencyCode", cAPaymentEntity.CurrencyCode,
                "@ExchangeRate", cAPaymentEntity.ExchangeRate,
                "@ParalellRefNo", cAPaymentEntity.ParalellRefNo,
                "@IncrementRefNo", cAPaymentEntity.IncrementRefNo,
                "@InwardRefNo", cAPaymentEntity.InwardRefNo,
                "@AccountingObjectId", cAPaymentEntity.AccountingObjectId,
                "@JournalMemo", cAPaymentEntity.JournalMemo,
                "@DocumentIncluded", cAPaymentEntity.DocumentIncluded,
                "@BankId", cAPaymentEntity.BankId,
                "@TotalAmount", cAPaymentEntity.TotalAmount,
                "@TotalAmountOC", cAPaymentEntity.TotalAmountOC,
                "@TotalTaxAmount", cAPaymentEntity.TotalTaxAmount,
                "@TotalFreightAmount", cAPaymentEntity.TotalFreightAmount,
                "@TotalInwardAmount", cAPaymentEntity.TotalInwardAmount,
                "@Posted", cAPaymentEntity.Posted,
                "@RefOrder", cAPaymentEntity.RefOrder,
                "@RelationRefId", cAPaymentEntity.RelationRefId,
                "@TotalPaymentAmount", cAPaymentEntity.TotalPaymentAmount,
                "@Receiver", cAPaymentEntity.Receiver
            };
        }
        private static object[] TakeInsert(CAPaymentEntity cAPaymentEntity)
        {
            return new object[]
            {

                "@RefId", cAPaymentEntity.RefId,
                "@RefType", cAPaymentEntity.RefType,
                "@RefDate", cAPaymentEntity.RefDate,
                "@PostedDate", cAPaymentEntity.PostedDate,
                "@RefNo", cAPaymentEntity.RefNo,
                "@CurrencyCode", cAPaymentEntity.CurrencyCode,
                "@ExchangeRate", cAPaymentEntity.ExchangeRate,
                "@ParalellRefNo", cAPaymentEntity.ParalellRefNo,
                "@IncrementRefNo", cAPaymentEntity.IncrementRefNo,
                "@InwardRefNo", cAPaymentEntity.InwardRefNo,
                "@AccountingObjectId", cAPaymentEntity.AccountingObjectId,
                "@JournalMemo", cAPaymentEntity.JournalMemo,
                "@DocumentIncluded", cAPaymentEntity.DocumentIncluded,
                "@BankId", cAPaymentEntity.BankId,
                "@TotalAmount", cAPaymentEntity.TotalAmount,
                "@TotalAmountOC", cAPaymentEntity.TotalAmountOC,
                "@TotalTaxAmount", cAPaymentEntity.TotalTaxAmount,
                "@TotalFreightAmount", cAPaymentEntity.TotalFreightAmount,
                "@TotalInwardAmount", cAPaymentEntity.TotalInwardAmount,
                "@Posted", cAPaymentEntity.Posted,
                "@RefOrder", cAPaymentEntity.RefOrder,
                "@RelationRefId", cAPaymentEntity.RelationRefId,
                "@TotalPaymentAmount", cAPaymentEntity.TotalPaymentAmount,
                "@Receiver", cAPaymentEntity.Receiver,
                "@Address",cAPaymentEntity.Address
            };
        }
    }

}