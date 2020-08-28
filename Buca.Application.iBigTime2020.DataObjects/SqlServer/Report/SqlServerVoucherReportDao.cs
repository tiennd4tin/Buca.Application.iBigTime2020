using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;
using System.Linq;
using BuCA.Enum;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    public class SqlServerVoucherReportDao : DaoBase, IVoucherReportDao
    {
        #region Phiếu chi
        /// <summary>
        /// Reports the cash payment C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C31BBEntity&gt;.</returns>
        public IList<C41BBEntity> ReportCashPaymentC41BB(string refId)
        {
            const string sql = @"uspReport_CashPayment_C41BB";
            object[] parms = { "@RefID", refId + "," };

            Func<IDataReader, C41BBEntity> makeC41BB = reader =>
                new C41BBEntity
                {
                    RefId = reader["RefID"].AsString(),
                    RefType = reader["RefType"].AsInt(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    RefNo = reader["RefNo"].AsString(),
                    InwardRefNo = reader["InwardRefNo"].AsString(),
                    AccountingObjectName = reader["AccountingObjectName"].AsString(),
                    ContactName = reader["ContactName"].AsString(),
                    Address = reader["Address"].AsString(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    DocumentIncluded = reader["DocumentIncluded"].AsString(),
                    TotalAmount = reader["TotalAmount"].AsDecimal(),
                    Description = reader["JournalMemo"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    SortOrder = reader["SortOrder"].AsInt(),
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                    ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                    CurrencyCode = reader["CurrencyCode"].AsString(),
                    Receiver = reader["Receiver"].AsString(),
                };

            return Db.ReadList(sql, true, makeC41BB, parms);
        }

        /// <summary>
        /// Reports the cash deposit C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBEntity&gt;.</returns>
        public IList<C41BBEntity> ReportCashDepositC41BB(string refId)
        {
            const string sql = @"uspReport_CashDeposit_C41BB";
            object[] parms = { "@RefID", refId + "," };

            Func<IDataReader, C41BBEntity> makeC41BB = reader =>
                new C41BBEntity
                {
                    RefId = reader["RefID"].AsString(),
                    RefType = reader["RefType"].AsInt(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    RefNo = reader["RefNo"].AsString(),
                    InwardRefNo = reader["InwardRefNo"].AsString(),
                    AccountingObjectName = reader["AccountingObjectName"].AsString(),
                    ContactName = reader["ContactName"].AsString(),
                    Address = reader["Address"].AsString(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    DocumentIncluded = reader["DocumentIncluded"].AsString(),
                    TotalAmount = reader["TotalAmount"].AsDecimal(),
                    Description = reader["JournalMemo"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    //SortOrder = reader["SortOrder"].AsInt(),
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                    ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                    CurrencyCode = reader["CurrencyCode"].AsString(),
                    Receiver = reader["Receiver"].AsString(),
                };

            return Db.ReadList(sql, true, makeC41BB, parms);
        }

        /// <summary>
        /// Reports the cash payment get from ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBEntity&gt;.</returns>
        public IList<C41BBEntity> ReportCashPaymentGetFromBADeposit(string refId)
        {
            const string sql = @"uspReport_CashPayment_GetFromBADeposit";
            object[] parms = { "@RefID", refId + "," };

            Func<IDataReader, C41BBEntity> makeC41BB = reader =>
                new C41BBEntity
                {
                    RefId = reader["RefID"].AsString(),
                    RefType = reader["RefType"].AsInt(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    RefNo = reader["RefNo"].AsString(),
                    InwardRefNo = reader["InwardRefNo"].AsString(),
                    AccountingObjectName = reader["AccountingObjectName"].AsString(),
                    ContactName = reader["ContactName"].AsString(),
                    Address = reader["Address"].AsString(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    DocumentIncluded = reader["DocumentIncluded"].AsString(),
                    TotalAmount = reader["TotalAmount"].AsDecimal(),
                    Description = reader["JournalMemo"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    SortOrder = reader["SortOrder"].AsInt(),
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                    ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                    CurrencyCode = reader["CurrencyCode"].AsString(),
                    Payer = reader["Payer"].AsString(),
                };

            return Db.ReadList(sql, true, makeC41BB, parms);
        }

        /// <summary>
        /// Reports the cash payment purchase C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBEntity&gt;.</returns>
        public IList<C41BBEntity> ReportCashPaymentPurchaseC41BB(string refId)
        {
            const string sql = @"uspReport_CashPaymentPurchase_C41BB";
            object[] parms = { "@RefID", refId + "," };

            Func<IDataReader, C41BBEntity> makeC41BB = reader =>
                new C41BBEntity
                {
                    RefId = reader["RefID"].AsString(),
                    RefType = reader["RefType"].AsInt(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    RefNo = reader["RefNo"].AsString(),
                    InwardRefNo = reader["InwardRefNo"].AsString(),
                    AccountingObjectName = reader["AccountingObjectName"].AsString(),
                    ContactName = reader["ContactName"].AsString(),
                    Address = reader["Address"].AsString(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    DocumentIncluded = reader["DocumentIncluded"].AsString(),
                    TotalAmount = reader["TotalAmount"].AsDecimal(),
                    Description = reader["JournalMemo"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    //SortOrder = reader["SortOrder"].AsInt(),
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                    ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                    CurrencyCode = reader["CurrencyCode"].AsString()
                };

            return Db.ReadList(sql, true, makeC41BB, parms);
        }

        /// <summary>
        /// Reports the cash payment fixed asset C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBEntity&gt;.</returns>
        public IList<C41BBEntity> ReportCashPaymentFixedAssetC41BB(string refId)
        {
            const string sql = @"uspReport_CashPaymentFixedAsset_C41BB";
            object[] parms = { "@RefID", refId + "," };

            Func<IDataReader, C41BBEntity> makeC41BB = reader =>
                new C41BBEntity
                {
                    RefId = reader["RefID"].AsString(),
                    RefType = reader["RefType"].AsInt(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    RefNo = reader["RefNo"].AsString(),
                    InwardRefNo = reader["InwardRefNo"].AsString(),
                    AccountingObjectName = reader["AccountingObjectName"].AsString(),
                    ContactName = reader["ContactName"].AsString(),
                    Address = reader["Address"].AsString(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    DocumentIncluded = reader["DocumentIncluded"].AsString(),
                    TotalAmount = reader["TotalAmount"].AsDecimal(),
                    Description = reader["JournalMemo"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    //SortOrder = reader["SortOrder"].AsInt,
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                    ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                    CurrencyCode = reader["CurrencyCode"].AsString()
                };

            return Db.ReadList(sql, true, makeC41BB, parms);
        }

        /// <summary>
        /// Reports the cash payment C41 bb details.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<C41BBDetailEntity> ReportCashPaymentC41BBDetails(string refId)
        {
            const string sql = @"uspReport_CashPayment_C41BBDetail";
            object[] parms = { "@RefID", refId + "," };
            Func<IDataReader, C41BBDetailEntity> makeC41BBDetail = reader =>
                new C41BBDetailEntity
                {
                    OrderNo = reader["OrderNo"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    BudgetItemCode = reader["BudgetItemCode"].AsString(),
                    BudgetSubItemCode = reader["BudgetSubItemCode"].AsString()
                };
            return Db.ReadList(sql, true, makeC41BBDetail, parms);
        }

        /// <summary>
        /// Reports the cash Deposit C41 bb details
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        public IList<C41BBDetailEntity> ReportCashDepositC41BBDetails(string refId)
        {
            const string sql = @"uspReport_CashDeposit_C41BBDetail";
            object[] parms = { "@RefID", refId + "," };
            Func<IDataReader, C41BBDetailEntity> makeC41BBDetail = reader =>
                new C41BBDetailEntity
                {
                    OrderNo = reader["OrderNo"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    BudgetItemCode = reader["BudgetItemCode"].AsString(),
                    BudgetSubItemCode = reader["BudgetSubItemCode"].AsString()
                };
            return Db.ReadList(sql, true, makeC41BBDetail, parms);
        }

        /// <summary>
        /// Reports the cash Deposit C41 bb Purchase
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        public IList<C41BBDetailEntity> ReportCashPaymentPurchaseC41BBDetails(string refId)
        {
            const string sql = @"uspReport_CashPaymentPuchase_C41BBDetail";
            object[] parms = { "@RefID", refId + "," };
            Func<IDataReader, C41BBDetailEntity> makeC41BBDetail = reader =>
                new C41BBDetailEntity
                {
                    OrderNo = reader["OrderNo"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    //AmountOC = reader["AmountOC"].AsDecimal(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    BudgetItemCode = reader["BudgetItemCode"].AsString(),
                    BudgetSubItemCode = reader["BudgetSubItemCode"].AsString()
                };
            return Db.ReadList(sql, true, makeC41BBDetail, parms);
        }

        /// <summary>
        /// Reports the cash FixedAsset C41 bb details
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        public IList<C41BBDetailEntity> ReportCashPaymentFixedAssetC41BBDetails(string refId)
        {
            const string sql = @"uspReport_CashPaymentFixedAsset_C41BBDetail";
            object[] parms = { "@RefID", refId + "," };
            Func<IDataReader, C41BBDetailEntity> makeC41BBDetail = reader =>
                new C41BBDetailEntity
                {
                    OrderNo = reader["OrderNo"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    //AmountOC = reader["AmountOC"].AsDecimal(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    BudgetItemCode = reader["BudgetItemCode"].AsString(),
                    BudgetSubItemCode = reader["BudgetSubItemCode"].AsString()
                };
            return Db.ReadList(sql, true, makeC41BBDetail, parms);
        }

        #endregion

        #region Phiếu thu

        public IList<C30BBEntity> ReportCashRecepitC30BB(string refId)
        {
            const string sql = @"uspReport_CashReceipt_C40BB";
            object[] parms = { "@RefID", refId + "," };
            Func<IDataReader, C30BBEntity> makeC30BB = reader =>
                new C30BBEntity
                {
                    RefId = reader["RefID"].AsString(),
                    RefType = reader["RefType"].AsInt(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    RefNo = reader["RefNo"].AsString(),
                    OutwardRefNo = reader["OutwardRefNo"].AsString(),
                    AccountingObjectContactName = reader["AccountingObjectName"].AsString(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    DocumentIncluded = reader["DocumentIncluded"].AsString(),
                    TotalAmount = reader["TotalAmount"].AsDecimal(),
                    TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                    Description = reader["JournalMemo"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    SortOrder = reader["SortOrder"].AsInt(),
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                    CurrencyCode = reader["CurrencyCode"].AsString(),
                    Address = reader["Address"].AsString(),
                    TotalCashAmount = reader["TotalCashAmount"].AsDecimal(),
                    TotalCashAmountOC = reader["TotalCashAmountOC"].AsDecimal(),
                    Payer = reader["Payer"].AsString(),
                };

            return Db.ReadList(sql, true, makeC30BB, parms);

        }

        public IList<C40BBDetailEntity> ReportCashRecepitC40BBDetails(string refId)
        {
            const string sql = @"uspReport_CashReceipt_C40BBDetail";
            object[] parms = { "@RefID", refId + "," };
            Func<IDataReader, C40BBDetailEntity> makeC40BBDetail = reader =>
                new C40BBDetailEntity
                {
                    OrderNo = reader["OrderNo"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    BudgetItemCode = reader["BudgetItemCode"].AsString(),
                    BudgetSubItemCode = reader["BudgetSubItemCode"].AsString()
                };
            return Db.ReadList(sql, true, makeC40BBDetail, parms);
        }


        public IList<C45_BBEntity> ReportCashRecepitC45BB(string refId)
        {
            const string sql = @"uspReport_CashReceipt_C30BB";
            object[] parms = { "@RefID", refId + "," };
            Func<IDataReader, C45_BBEntity> makeC45BB = reader =>
                new C45_BBEntity
                {
                    RefId = reader["RefID"].AsString(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    RefNo = reader["RefNo"].AsString(),
                    OutwardRefNo = reader["OutwardRefNo"].AsString(),
                    AccountingObjectContactName = reader["AccountingObjectName"].AsString(),
                    JournalMemo = reader["JournalMemo"].AsString(),
                    TotalAmount = reader["TotalAmount"].AsDecimal(),
                    Address = reader["Address"].AsString()
                };

            return Db.ReadList(sql, true, makeC45BB, parms);

        }

        #endregion

        #region Giấy rút tiền mặt từ tài khoản
        /// <summary>
        /// Reftype defaule là phiếu thu
        /// </summary>
        /// <returns></returns>
        public IList<C4_09Entity> ReportCAReceipt_C4_09(string refId, BuCA.Enum.RefType refType = BuCA.Enum.RefType.CAReceipt)
        {
            var list = new List<C4_09Entity>();

            string sql = string.Empty;
            if (refType == BuCA.Enum.RefType.BADeposit) // Thu tiền gửi
                sql = @"uspReport_BADeposit_C4_09";
            else
                sql = @"uspReport_CAReciept_C4_09";

            foreach (var item in refId.Split(';').ToList())
            {
                object[] parms = { "@RefID", item, "@Option", 1 };
                var obj = Db.Read(sql, true, (sql == @"uspReport_CAReciept_C4_09" ? Make<C4_09Entity> : makeC4_09), parms);
                if (obj != null)
                {
                    obj.Details = ReportC4_09Detail(item);
                    list.Add(obj);
                }
            }
            return list;
        }

        private static readonly Func<IDataReader, C4_09Entity> makeC4_09 = reader =>
               new C4_09Entity
               {
                   PostedDate = reader["PostedDate"].AsDateTime(),
                   RefNo = reader["RefNo"].AsString(),
                   BankAccount = reader["BankAccount"].AsString(),
                   BankName = reader["BankName"].AsString(),
                   AccountingObjectName = reader["AccountingObjectName"].AsString(),
                   IdentificationNumber = reader["IdentificationNumber"].AsString(),
                   IssueDate = reader["IssueDate"].AsDateTime(),
                   IssueBy = reader["IssueBy"].AsString(),
                   Address = reader["Address"].AsString(),
                   JournalMemo = reader["JournalMemo"].AsString(),
                   TotalAmount = reader["TotalAmount"].AsDecimal(),
                   CurrencyCode = reader["CurrencyCode"].AsString(),
                   TotalCashAmount = reader["TotalCashAmount"].AsDecimal(),
                   TotalCashAmountOC = reader["TotalCashAmountOC"].AsDecimal(),
                   RefId = reader["RefId"].AsString(),
                   RefType = reader["RefType"].AsInt(),
                   Payer = reader["Payer"].AsString(),
               };
        /// <summary>
        /// Reports the cash receipt sale outward stock detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDDetailEntity&gt;.</returns>
        public IList<C4_09DetailEntity> ReportC4_09Detail(string refId)
        {
            const string sql = @"uspReport_CAReciept_C4_09";
            object[] parms = { "@RefID", refId, "@Option", 2 };

            Func<IDataReader, C4_09DetailEntity> makeC4_09Detail = reader =>
                new C4_09DetailEntity
                {
                    Description = reader["Description"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    AmountOC = reader["AmountOC"].AsDecimal()
                };

            return Db.ReadList(sql, true, makeC4_09Detail, parms);
        }
        #endregion

        #region C203

        public IList<C203NSEntity> ReportC203NSTT77(string refId, DateTime StartDate, DateTime FiscalStartDate,
            string BudgetSourceKind, string TargetProgramID, string BankInfoID, string BudgetSourceID,
            string BudgetChapterCode, string BudgetSubKindItemCode, int MethodDistributeID,
            string BudgetItemCodeList, bool IsActiveTemplate, DateTime SystemDate, bool IsSystemDate, bool IsRefDate,
            bool CheckCashWithDrawType)
        {
            var list = new List<C203NSEntity>();

            string sql = @"usp_GetC203NS_TT77";
            object[] parms = { "@pRefID", refId,
                "@pStartDate", StartDate,
                "@pFiscalStartDate", FiscalStartDate,
                "@pBudgetSourceKind", BudgetSourceKind,
                "@pTargetProgramID", TargetProgramID,
                "@pBankInfoID", BankInfoID,
                "@pBudgetSourceID", BudgetSourceID,
                "@pBudgetChapterCode", BudgetChapterCode,
                "@pBudgetSubKindItemCode", BudgetSubKindItemCode,
                "@pMethodDistributeID", MethodDistributeID,
                "@pBudgetItemCodeList", BudgetItemCodeList,
                "@pIsActiveTemplate", IsActiveTemplate,
                "@pSystemDate", SystemDate,
                "@pIsSystemDate", IsSystemDate,
                "@pIsRefDate", IsRefDate,
                "@CheckCashWithDrawType", CheckCashWithDrawType
                };
            return Db.ReadList(sql, true, Make<C203NSEntity>, parms);
        }

        #endregion

        #region C302

        public IList<C302NSEntity> GetReportC302NS(string refId, DateTime StartDate, int PayType,
            string TargetProgramID,
            string BudgetSourceID, string BudgetChapterCode, string BudgetSubKindItemCode, int MethodDistributeID,
            string BudgetItemCodeList, string InvestmentNumber, DateTime InvestmentDate, string YearPlan,
            bool CheckCashWithDrawType)
        {
            string sql = @"uspReportVoucher_C302NS";
            object[] parms = { "@RefID", refId
                //"@StartDate"            ,StartDate            ,
                //"@PayType"              ,PayType              ,
                //"@TargetProgramID"      ,TargetProgramID      ,
                //"@BudgetSourceID"       ,BudgetSourceID       ,
                //"@BudgetChapterCode"    ,BudgetChapterCode    ,
                //"@BudgetSubKindItemCode",BudgetSubKindItemCode,
                //"@MethodDistributeID"   ,MethodDistributeID   ,
                //"@BudgetItemCodeList"   ,BudgetItemCodeList   ,
                //"@InvestmentNumber"     ,InvestmentNumber     ,
                //"@InvestmentDate"       ,InvestmentDate       ,
                //"@YearPlan"             ,YearPlan             ,
                //"@CheckCashWithDrawType",CheckCashWithDrawType,
            };
            return Db.ReadList(sql, true, Make<C302NSEntity>, parms);
        }

        #endregion

        #region Giấy rút dự toán
        public IList<C2_02aEntity> ReportBUPlanWithDraw(string refId, int IsGroupDetail, int IsShowDuplicate,
            int content, BuCA.Enum.RefType refType = BuCA.Enum.RefType.BUPlanWithDrawCash)
        {
            var list = new List<C2_02aEntity>();
            string sql = @"uspReport_BUPlanWithDraw";
            switch (refType)
            {
                case BuCA.Enum.RefType.BUPlanWithDrawCash:
                case BuCA.Enum.RefType.BUPlanWithDrawTransfer:
                case BuCA.Enum.RefType.BUPlanWithDrawDeposit:
                    sql = @"uspReport_BUPlanWithDraw";
                    break;

                case BuCA.Enum.RefType.CAReceiptEstimate:
                    sql = @"uspReport_CAReceipt_C202A";
                    break;

                case BuCA.Enum.RefType.BUTransfer:
                case BuCA.Enum.RefType.BUTransferDeposits:
                case BuCA.Enum.RefType.BUTransferPayWage:
                case BuCA.Enum.RefType.BUTransferPayInsurrance:
                    sql = @"uspReport_BUTransfer_C202A";
                    break;

                case BuCA.Enum.RefType.BUTransferFixedAsset:
                    sql = @"uspReport_BUTransferDetailFixedAsset_C202A";
                    break;

                case BuCA.Enum.RefType.BUTransferPurchase:
                    sql = @"uspReport_BUTransferDetailPurchase_C202A";
                    break;
            }

            foreach (var item in refId.Split(';').ToList())
            {
                object[] parms = { "@RefID", item, "@Option", 1, "@IsSum", IsGroupDetail, "@IsDeleteDuplicate", IsShowDuplicate, "@ShowContent", content };
                var obj = Db.Read(sql, true, Make<C2_02aEntity>, parms);
                obj.Details = ReportBUPlanWithDrawDetail(item, IsGroupDetail, IsShowDuplicate,
             content, refType);
                list.Add(obj);
            }
            return list;
        }
        private static readonly Func<IDataReader, C2_02aEntity> makeBUPlanWithDraw = reader =>
               new C2_02aEntity
               {
                   RefNo = reader["RefNo"].AsString(),
                   PostedDate = reader["PostedDate"].AsDateTime(),
                   BankAccount = reader["BankAccount"].AsString(),
                   BankName = reader["BankName"].AsString(),
                   ProjectCode = reader["ProjectCode"].AsString(),
                   ProjectName = reader["ProjectName"].AsString(),
                   AccountingObjectName = reader["AccountingObjectName"].AsString(),
                   Address = reader["Address"].AsString(),
                   BankAccount_Object = reader["BankAccount_Object"].AsString(),
                   BankName_Object = reader["BankName_Object"].AsString(),
                   IdentificationNumber = reader["IdentificationNumber"].AsString(),
                   IssueDate = reader["IssueDate"].AsDateTime(),
                   IssueBy = reader["IssueBy"].AsString(),
                   RefType = reader["RefType"].AsInt(),
                   CashWithDrawType = reader["CashWithDrawType"].AsInt(),
                   Employee = reader["Employee"].AsString(),
                   EmployeeCode = reader["EmployeeCode"].AsString(),
                   IsEmployee = reader["IsEmployee"].AsBool()

               };
        public IList<C2_02aDetailEntity> ReportBUPlanWithDrawDetail(string refId, int IsGroupDetail, int IsShowDuplicate,
            int content, BuCA.Enum.RefType refType = BuCA.Enum.RefType.BUPlanWithDrawCash)
        {
            string sql = @"uspReport_BUPlanWithDraw";
            switch (refType)
            {
                case BuCA.Enum.RefType.BUPlanWithDrawCash:
                case BuCA.Enum.RefType.BUPlanWithDrawTransfer:
                case BuCA.Enum.RefType.BUPlanWithDrawDeposit:
                    sql = @"uspReport_BUPlanWithDraw";
                    break;

                case BuCA.Enum.RefType.CAReceiptEstimate:
                    sql = @"uspReport_CAReceipt_C202A";
                    break;
                case BuCA.Enum.RefType.BUTransfer:
                case BuCA.Enum.RefType.BUTransferDeposits:
                case BuCA.Enum.RefType.BUTransferPayWage:
                case BuCA.Enum.RefType.BUTransferPayInsurrance:
                    sql = @"uspReport_BUTransfer_C202A";
                    break;

                case BuCA.Enum.RefType.BUTransferFixedAsset:
                    sql = @"uspReport_BUTransferDetailFixedAsset_C202A";
                    break;

                case BuCA.Enum.RefType.BUTransferPurchase:
                    sql = @"uspReport_BUTransferDetailPurchase_C202A";
                    break;
            }


            object[] parms = { "@RefID", refId, "@Option", 2, "@IsSum", IsGroupDetail, "@IsDeleteDuplicate", IsShowDuplicate, "@ShowContent", content };


            Func<IDataReader, C2_02aDetailEntity> makeBUPlanWithDrawDetail = reader =>
                new C2_02aDetailEntity
                {

                    BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                    Memo = reader["memo"].AsString()
                };
            Func<IDataReader, C2_02aDetailEntity> makeBUPlanWithDrawDetailCashWithDraw = reader =>
               new C2_02aDetailEntity
               {

                   BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                   Amount = reader["Amount"].AsDecimal(),
                   BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                   BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                   BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                   Memo = reader["memo"].AsString(),
                   CashWithDrawType = reader["CashWithDrawType"].AsInt()

               };
            if (
                refType == RefType.BUPlanWithDrawCash ||
                refType == RefType.BUPlanWithDrawTransfer ||
                refType == RefType.BUPlanReceiptAddition ||
                refType == RefType.BUPlanReceiptEarlyYear ||
                refType == RefType.BUPlanWithDrawDeposit ||
                refType == RefType.BUPlanWithdrawTransferInsurrance
                //refType ==RefType.BUTransferPurchase||
                //refType ==RefType.BUTransferFixedAsset

                )

            {

                return Db.ReadList(sql, true, makeBUPlanWithDrawDetail, parms);
            }
            else
            {

                return Db.ReadList(sql, true, makeBUPlanWithDrawDetailCashWithDraw, parms);
            }
        }
        #endregion

        #region Phiếu xuất kho

        /// <summary>
        /// Reports the cash receipt sale outward stock.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDEntity&gt;.</returns>
        public IList<C21HDEntity> ReportCashReceiptSaleOutwardStock(string refId)
        {
            var list = new List<C21HDEntity>();
            const string sql = @"uspReport__CashReceiptSale_C21HD";
            foreach (var item in refId.Split(';').ToList())
            {
                object[] parms = { "@RefID", item, "@Option", 1 };
                var obj = Db.Read(sql, true, makeC21HD, parms);
                obj.Details = ReportCashReceiptSaleOutwardStockDetail(item);
                list.Add(obj);
            }
            return list;
        }
        /// <summary>
        /// The make C21 hd
        /// </summary>
        private static readonly Func<IDataReader, C21HDEntity> makeC21HD = reader =>
             new C21HDEntity
             {
                 RefId = reader["RefID"].AsString(),
                 RefDate = reader["RefDate"].AsDateTime(),
                 PostedDate = reader["PostedDate"].AsDateTime(),
                 RefNo = reader["RefNo"].AsString(),
                 Receiver = reader["Receiver"].AsString(),
                 Address = reader["Address"].AsString(),
                 JournalMemo = reader["JournalMemo"].AsString(),
                 DocumentInclude = reader["DocumentInclude"].AsString(),
                 TotalAmount = reader["TotalAmount"].AsDecimal(),
                 DebitAccounts = reader["DebitAccounts"].AsString(),
                 CreditAccounts = reader["CreditAccounts"].AsString(),
                 StockId = reader["StockID"].AsString(),
                 StockName = reader["StockName"].AsString(),
                 ReceiverAddress = reader["ReceiverAddress"].AsString()
             };

        /// <summary>
        /// Reports the cash receipt sale outward stock detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDDetailEntity&gt;.</returns>
        public IList<C21HDDetailEntity> ReportCashReceiptSaleOutwardStockDetail(string refId)
        {
            const string sql = @"uspReport__CashReceiptSale_C21HD";
            object[] parms = { "@RefID", refId, "@Option", 2 };

            Func<IDataReader, C21HDDetailEntity> makeC21HDDetail = reader =>
                new C21HDDetailEntity
                {
                    PriceUnit = reader["UnitPrice"].AsDecimal(),
                    Amount = reader["Amount"].AsDecimal(),
                    Unit = reader["Unit"].AsString(),
                    InventoryItemName = reader["InventoryItemName"].AsString(),
                    InventoryItemCode = reader["InventoryItemCode"].AsString(),
                    InventoryItemId = reader["InventoryItemID"].AsString(),
                    Stt = reader["Stt"].AsInt(),
                    Quantity = reader["Quantity"].AsDecimal()
                };

            return Db.ReadList(sql, true, makeC21HDDetail, parms);
        }
        #endregion

        #region Phiếu nhập kho
        /// <summary>
        /// Reports the cash receipt sale outward stock.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDEntity&gt;.</returns>
        public IList<C20HDEntity> ReportCashReceiptSaleC20HD(string refId, int refType)
        {
            var list = new List<C20HDEntity>();

            string sql = string.Empty;
            switch (refType)
            {
                case (int)BuCA.Enum.RefType.BUTransferPurchase:
                    sql = @"uspReport_BUTransferDetailPurchase_C20HD";
                    break;

                default:
                    sql = @"uspReport__CashReceiptSale_C20HD";
                    break;
            }

            foreach (var item in refId.Split(';').ToList())
            {
                object[] parms = { "@RefID", item, "@Option", 1, "@RefType", refType };
                var obj = Db.Read(sql, true, makeC20HD, parms);
                obj.Details = ReportCashReceiptSaleC20HDDetail(item, refType);
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// Reports the cash payment.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<C408Entity> ReportCashPaymentC408(int refType, string refId)
        {
            string sql;
            if (refType == 113)
                sql = @"uspReport_CashPaymentC408";
            else if (refType == 561)
                sql = @"uspReport_BUTransferC408";
            else
                sql = @"uspReport_BADepositC408";

            var c408Entities = new List<C408Entity>();

            foreach (var item in refId.Split(';').ToList())
            {
                object[] parms = { "@RefID", item + "," };
                var c408Entity = Db.Read(sql, true, (sql == @"uspReport_CashPaymentC408" ? makeC4082 : sql == @"uspReport_BADepositC408" ? makeC4083 : makeC408), parms);
                if (c408Entity != null)
                {
                    c408Entity.C408Details = ReportCashPaymentC408Detail(refType, item);
                    c408Entities.Add(c408Entity);
                }
            }
            return c408Entities;
        }

        /// <summary>
        /// The make C21 hd
        /// </summary>
        private static readonly Func<IDataReader, C20HDEntity> makeC20HD = reader =>
             new C20HDEntity
             {
                 RefId = reader["RefID"].AsString(),
                 RefDate = reader["RefDate"].AsDateTime(),
                 PostedDate = reader["PostedDate"].AsDateTime(),
                 RefNo = reader["RefNo"].AsString(),
                 Receiver = reader["Receiver"].AsString(),
                 Address = reader["Address"].AsString(),
                 JournalMemo = reader["JournalMemo"].AsString(),
                 DocumentInclude = reader["DocumentInclude"].AsString(),
                 TotalAmount = reader["TotalAmount"].AsDecimal(),
                 DebitAccounts = reader["DebitAccounts"].AsString(),
                 CreditAccounts = reader["CreditAccounts"].AsString(),
                 StockId = reader["StockID"].AsString(),
                 StockName = reader["StockName"].AsString(),
                 ReceiverAddress = reader["ReceiverAddress"].AsString()
             };

        /// <summary>
        /// The make C408
        /// </summary>
        private static readonly Func<IDataReader, C408Entity> makeC408 = reader =>
             new C408Entity
             {
                 RefId = reader["RefID"].AsString(),
                 RefDate = reader["RefDate"].AsDateTime(),
                 PostedDate = reader["PostedDate"].AsDateTime(),
                 RefNo = reader["RefNo"].AsString(),
                 TotalAmount = reader["TotalAmount"].AsDecimal(),
                 AccountingObjectName = reader["AccountingObjectName"].AsString(),
                 AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
                 BankAccount = reader["BankAccount"].AsString(),
                 BankName = reader["BankName"].AsString(),
                 RefType = reader["RefType"].AsInt()
             };
        private static readonly Func<IDataReader, C408Entity> makeC4082 = reader =>
            new C408Entity
            {
                RefId = reader["RefID"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                AccountingObjectName = reader["AccountingObjectName"].AsString(),
                AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
                BankAccount = reader["BankAccount"].AsString(),
                BankName = reader["BankName"].AsString(),
                RefType = reader["RefType"].AsInt(),
                Receiver = reader["Receiver"].AsString()
            };
        private static readonly Func<IDataReader, C408Entity> makeC4083 = reader =>
            new C408Entity
            {
                RefId = reader["RefID"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefNo = reader["RefNo"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                AccountingObjectName = reader["AccountingObjectName"].AsString(),
                AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
                BankAccount = reader["BankAccount"].AsString(),
                BankName = reader["BankName"].AsString(),
                RefType = reader["RefType"].AsInt(),
                Payer = reader["Payer"].AsString()
            };

        /// <summary>
        /// Reports the cash receipt sale outward stock detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDDetailEntity&gt;.</returns>
        public IList<C20HDDetailEntity> ReportCashReceiptSaleC20HDDetail(string refId, int refType)
        {
            string sql = string.Empty;
            switch (refType)
            {
                case (int)BuCA.Enum.RefType.BUTransferPurchase:
                    sql = @"uspReport_BUTransferDetailPurchase_C20HD";
                    break;

                default:
                    sql = @"uspReport__CashReceiptSale_C20HD";
                    break;
            }

            object[] parms = { "@RefID", refId, "@Option", 2, "@RefType", refType };

            Func<IDataReader, C20HDDetailEntity> makeC20HDDetail = reader =>
                new C20HDDetailEntity
                {
                    PriceUnit = reader["UnitPrice"].AsDecimal(),
                    Amount = reader["Amount"].AsDecimal(),
                    Unit = reader["Unit"].AsString(),
                    InventoryItemName = reader["InventoryItemName"].AsString(),
                    InventoryItemCode = reader["InventoryItemCode"].AsString(),
                    InventoryItemId = reader["InventoryItemID"].AsString(),
                    Stt = reader["Stt"].AsInt(),
                    Quantity = reader["Quantity"].AsDecimal()
                };

            return Db.ReadList(sql, true, makeC20HDDetail, parms);
        }

        /// <summary>
        /// Reports the cash payment C408 detail.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<C408DetailEntity> ReportCashPaymentC408Detail(int refType, string refId)
        {
            string sql;
            if (refType == 113)
                sql = @"uspReport_CashPaymentC408Detail";
            else if (refType == 561)
                sql = @"uspReport_BUTransferC408Detail";
            else
                sql = @"uspReport_BADepositC408Detail";

            object[] parms = { "@RefID", refId };

            Func<IDataReader, C408DetailEntity> makeC408Detail = reader =>
                new C408DetailEntity
                {
                    Amount = reader["Amount"].AsDecimal(),
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    Description = reader["Description"].AsString(),
                    DebitAccount = reader["DebitAccount"].AsString(),
                    CreditAccount = reader["CreditAccount"].AsString()
                };

            return Db.ReadList(sql, true, makeC408Detail, parms);
        }
        #endregion

        /// <summary>
        /// Gets the report C402 c.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns></returns>
        public IList<C402CKBEntity> GetReportC402C(string storeProdure, string refIdList)
        {
            string sql = storeProdure;
            IList<C402CKBEntity> list = new List<C402CKBEntity>();
            foreach (var refID in refIdList.Split(';'))
            {
                object[] parms = { "@RefID", refID };
                IList<C402CKBEntity> obj = Db.ReadList(sql, true, MakeC402CKB, parms);
                if (list.Any() || list.Count == 0)
                    list = obj;
                else
                    list.ToList().AddRange(obj);
            }
            return list;
        }
        public IList<C402CKBEntity> ReportC205ANS(string storeProdure, string refIdList)
        {
            string sql = storeProdure;
            IList<C402CKBEntity> list = new List<C402CKBEntity>();
            foreach (var refID in refIdList.Split(';'))
            {
                object[] parms = { "@RefID", refID };
                IList<C402CKBEntity> obj = Db.ReadList(sql, true, MakeC402CKB, parms);
                if (list.Any() || list.Count == 0)
                    list = obj;
                else
                    list.ToList().AddRange(obj);
            }
            return list;
        }
        /// <summary>
        /// Gets the report C402 c.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns></returns>
        public IList<C4_09Entity> GetReportC409(string storeProdure, string refIdList)
        {
            string sql = storeProdure;
            IList<C4_09Entity> list = new List<C4_09Entity>();
            foreach (var refID in refIdList.Split(';'))
            {
                object[] parms = { "@RefID", refID };
                IList<C4_09Entity> obj = Db.ReadList(sql, true, MakeC409, parms);
                if (list.Any() || list.Count == 0)
                    list = obj;
                else
                    list.ToList().AddRange(obj);
            }
            return list;
        }

        public IList<VoucherEntity> GetVoucherData(string refIdList, int reftype)
        {
            string sql = "";
            if (reftype == 101 || reftype == 105)
                sql = "Proc_CAV_CashReceipt_GetAccountVoucher";
            if (reftype == 114)
                sql = "uspReport_BUV_CashReceipt_GetAccountVoucher";
            if (reftype == 106 || reftype == 113)
                sql = "uspReport_CAV_CashPayment_GetAccountVoucher";
            if (reftype == 153)
                sql = "uspReport_BAV_Deposit_GetAccountVoucher";
            if (reftype == 157)
                sql = "uspReport_BAV_Withdraw";
            if (reftype == 107)
                sql = "uspReport_CAV_CashPaymentPurchase_GetAccountVoucher";
            if (reftype == 158)
                sql = "uspReport_BAV_WithdrawPurchase";
            if (reftype == 201 || reftype == 202)
                sql = "uspReport_INV_InwardStock_GetAccountVoucher";

            switch (reftype)
            {
                case (int)BuCA.Enum.RefType.GLVoucher: // Chứng từ chung
                    sql = "uspReport_GLVoucher_GetAccountVoucher";
                    break;

                case (int)BuCA.Enum.RefType.BUTransferFixedAsset: // Mua TSCĐ bằng chuyển khoản
                    sql = "uspReport_BUTransferDetailFixedAsset_GetAccountVoucher";
                    break;

                case (int)BuCA.Enum.RefType.BUTransferPurchase: // Mua hàng hóa bằng chuyển khoản
                    sql = "uspReport_BUTransferDetailPurchase_GetAccountVoucher";
                    break;
            }

            IList<VoucherEntity> list = new List<VoucherEntity>();
            foreach (var refID in refIdList.Split(';'))
            {
                object[] parms = { "@RefID", refID };
                IList<VoucherEntity> obj = Db.ReadList(sql, true, MakeVoucher, parms);
                if (list.Any() || list.Count == 0)
                    list = obj;
                else
                    list.ToList().AddRange(obj);
            }
            return list;
        }

        /// <summary>
        /// The make C402 CKB
        /// </summary>
        private static readonly Func<IDataReader, C402CKBEntity> MakeC402CKB = reader =>
            new C402CKBEntity
            {
                RefId = reader["RefID"].AsString(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                AccountInBank = reader["AccountInBank"].AsString(),
                BankAccount = reader["BankAccount"].AsString(),
                ReceiptObjectName = reader["ReceiptObjectName"].AsString(),
                ReceiptCode = reader["ReceiptCode"].AsString(),
                AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
                AccountingObjectBankAccount = reader["AccountingObjectBankAccount"].AsString(),
                Payment = reader["Payment"].AsDecimal(),
                Amount = reader["Amount"].AsDecimal(),
                EditVersion = reader["EditVersion"].AsInt(),
                ReceiptTargetProgram = reader["ReceiptTargetProgram"].AsString(),
                ReceiptAccountInBank = reader["ReceiptAccountInBank"].AsString(),
                Description = reader["Description"].AsString(),
                DescriptionReplaced = reader["DescriptionReplaced"].AsString(),
                Tax = reader["Tax"].AsDecimal(),
                CurencyCode = reader["CurrencyCode"].AsString(),
                RefType = reader["RefType"].AsInt(),
                IsOpenInBank = reader["IsOpenInBank"].AsBool(),
                BudgetCode = reader["BudgetCode"].AsString(),
                ActivityCode = reader["ActivityCode"].AsString(),
                ActivityGrade = reader["ActivityGrade"].AsString(),
                ReceiveName = reader["ReceiveName"].AsString(),
                ReceiveIssueLocation = reader["ReceiveIssueLocation"].AsString(),
                ReceiveId = reader["ReceiveId"].AsString(),
                ReceiveIssueDate = reader["ReceiveIssueDate"].AsString(),
                OrgRefNo = reader["OrgRefNo"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                ProjectBankName = reader["ProjectBankName"].AsString(),
                ProjectBankAccount = reader["ProjectBankAccount"].AsString(),
                ProjectName = reader["ProjectName"].AsString(),
                Investment = reader["Investment"].AsString(),
                CashWithDrawTypeID = reader["CashWithDrawTypeID"].AsInt()
            };

        /// <summary>
        /// The make C402 CKB
        /// </summary>
        private static readonly Func<IDataReader, C4_09Entity> MakeC409 = reader =>
            new C4_09Entity
            {
                AccountingObjectName = reader["AccountingObjectName"].AsString(),
                // RefId = reader["RefID"].AsString(),
                RefNo = reader["RefNo"].AsString(),
                //RefDate = reader["RefDate"].AsDateTime(),
                //AccountInBank = reader["AccountInBank"].AsString(),
                BankAccount = reader["BankAccount"].AsString(),
                //ReceiptObjectName = reader["ReceiptObjectName"].AsString(),
                //ReceiptCode = reader["ReceiptCode"].AsString(),
                //AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
                //AccountingObjectBankAccount = reader["AccountingObjectBankAccount"].AsString(),
                //Payment = reader["Payment"].AsDecimal(),
                //Amount = reader["Amount"].AsDecimal(),
                //EditVersion = reader["EditVersion"].AsInt(),
                //ReceiptTargetProgram = reader["ReceiptTargetProgram"].AsString(),
                //ReceiptAccountInBank = reader["ReceiptAccountInBank"].AsString(),
                //Description = reader["Description"].AsString(),
                //DescriptionReplaced = reader["DescriptionReplaced"].AsString(),
                //Tax = reader["Tax"].AsDecimal(),
                //CurencyCode = reader["CurrencyCode"].AsString(),
                //RefType = reader["RefType"].AsInt()
            };
        private static readonly Func<IDataReader, VoucherEntity> MakeVoucher = reader =>
            new VoucherEntity
            {
                RefId = reader["RefId"].AsString(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                RefType = reader["RefType"].AsInt(),
                AccountingObjectName = reader["AccountingObjectName"].AsString(),
                AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
                JournalMemo = reader["JournalMemo"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                Description = reader["Description"].AsString(),
                Amount = reader["Amount"].AsDecimal()
            };

        #region C2-12/NS: Giấy đề nghị cam kết chi NSNN (Thông tư số 77/2017/TT-BTC)
        /// <summary>
        /// Gets the C212 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C212NSEntity&gt;.</returns>
        public IList<C212NSEntity> GetC212NS(string refId)
        {
            const string sql = @"uspReport_C212NS_TT772017";
            object[] parms = { "@RefID", refId };

            Func<IDataReader, C212NSEntity> makeC212NS = reader =>
                new C212NSEntity
                {
                    RefId = reader["RefID"].AsString(),
                    PROID = reader["PROMATERID"].AsString(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    RefNo = reader["RefNo"].AsString(),
                    RefType = reader["RefType"].AsString(),
                    AccountingObjectId = reader["AccountingObjectId"].AsString(),
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
                    Description = reader["Description"].AsString(),
                    CurrencyCode = reader["CurrencyCode"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                    BudgetDistributionCode = reader["BudgetDistributionCode"].AsString(),
                    BudgetSourcePropertyCode = reader["BudgetSourcePropertyCode"].AsString(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    BudgetItemCode = reader["BudgetItemCode"].AsString(),
                    BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                    ProjectCode = reader["ProjectCode"].AsString(),
                    SortOrder = reader["SortOrder"].AsString(),
                    ProjectInvestmentCode = reader["ProjectInvestmentCode"].AsString(),
                    ProjectInvestmentName = reader["ProjectInvestmentName"].AsString(),
                    SignDate = reader["SignDate"].AsDateTime(),
                    ContractAmount = reader["ContractAmount"].AsDecimal(),
                    PrevYearCommitmentAmount = reader["PrevYearCommitmentAmount"].AsDecimal(),
                    BudgetCode = reader["BudgetCode"].AsString(),
                    BankOpen = reader["BankOpen"].AsString()
                };

            return Db.ReadList(sql, true, makeC212NS, parms);
        }
        #endregion

        #region C2-13/NS: Phiếu điều chỉnh số liệu cam kết chi (TT số 77/2017/TT-BTC)
        /// <summary>
        /// Gets the C213 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C213NSEntity&gt;.</returns>
        public IList<C213NSEntity> GetC213NS(string refId)
        {
            const string sql = @"uspReport_C213NS_TT772017";
            object[] parms = { "@RefID", refId };

            Func<IDataReader, C213NSEntity> makeC213NS = reader =>
                new C213NSEntity
                {
                    RefId = reader["RefID"].AsString(),
                    RefDate = reader["RefDate"].AsDateTime(),
                    PostedDate = reader["PostedDate"].AsDateTime(),
                    RefNo = reader["RefNo"].AsString(),
                    AccountingObjectName = reader["AccountingObjectName"].AsString(),
                    BankAccount = reader["BankAccount"].AsString(),
                    BankName = reader["BankName"].AsString(),
                    ContractNo = reader["ContractNo"].AsString(),
                    ContractFrameNo = reader["ContractFrameNo"].AsString(),
                    BudgetSourceKind = reader["BudgetSourceKind"].AsInt(),
                    TotalAmount = reader["TotalAmount"].AsDecimal(),
                    TotalAmountOC = reader["TotalAmountOC"].AsDecimal(),
                    IsForeignCurrency = reader["IsForeignCurrency"].AsBool(),
                    CurrencyCode = reader["CurrencyCode"].AsString(),
                    Amount = reader["Amount"].AsDecimal(),
                    AmountOC = reader["AmountOC"].AsDecimal(),
                    BudgetDistributionCode = reader["BudgetDistributionCode"].AsString(),
                    BudgetSourcePropertyCode = reader["BudgetSourcePropertyCode"].AsString(),
                    BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                    BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                    BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                    ProjectCode = reader["ProjectCode"].AsString(),
                    SortOrder = reader["SortOrder"].AsInt(),
                    ProjectInvestmentCode = reader["ProjectInvestmentCode"].AsString(),
                    ProjectInvestmentName = reader["ProjectInvestmentName"].AsString(),
                    SignDate = reader["SignDate"].AsDateTime(),
                    AccountingObjectCode = reader["AccountingObjectCode"].AsString(),
                    AdjustmentProviderBankAccount = reader["AdjustmentProviderBankAccount"].AsString(),
                    AdjustmentProviderBankName = reader["AdjustmentProviderBankName"].AsString(),
                    BUCommitmentRequestRefNo = reader["BUCommitmentRequestRefNo"].AsString(),
                    BudgetYear = reader["BudgetYear"].AsInt(),
                    DeToAmount = reader["DeToAmount"].AsDecimal(),
                    DeToAmountOC = reader["DeToAmountOC"].AsDecimal(),
                    IsBlankPart2 = reader["IsBlankPart2"].AsBool(),
                    IsBlankPart3 = reader["IsBlankPart3"].AsBool(),
                    IsSuggestAdjustment = reader["IsSuggestAdjustment"].AsBool(),
                    IsSuggestSupplement = reader["IsSuggestSupplement"].AsBool(),
                    OrgProviderBankAccount = reader["OrgProviderBankAccount"].AsString(),
                    OrgProviderBankName = reader["OrgProviderBankName"].AsString(),
                    Part = reader["Part"].AsInt(),
                    RealContractNo = reader["RealContractNo"].AsString(),
                    RefIDSortOrder = reader["RefIDSortOrder"].AsInt(),
                    RemainAmount = reader["RemainAmount"].AsDecimal(),
                    RemainAmountOC = reader["RemainAmountOC"].AsDecimal(),
                    ToAmount = reader["ToAmount"].AsDecimal(),
                    ToAmountOC = reader["ToAmountOC"].AsDecimal(),
                    ToBudgetChapterCode = reader["ToBudgetChapterCode"].AsString(),
                    ToBudgetDistributionCode = reader["ToBudgetDistributionCode"].AsString(),
                    ToBudgetSourcePropertyCode = reader["ToBudgetSourcePropertyCode"].AsString(),
                    ToBudgetSubItemCode = reader["ToBudgetSubItemCode"].AsString(),
                    ToBudgetSubKindItemCode = reader["ToBudgetSubKindItemCode"].AsString(),
                    ToCurrencyCode = reader["ToCurrencyCode"].AsString(),
                    ToProjectCode = reader["ToProjectCode"].AsString(),
                    BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
                    BudgetCode = reader["BudgetCode"].AsString(),
                    BankOpen = reader["BankOpen"].AsString()

                };

            return Db.ReadList(sql, true, makeC213NS, parms);
        }
        #endregion

        #region C3-01/NS – Giấy rút vốn đầu tư

        /// <summary>
        /// Reports the cash payment C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C31BBEntity&gt;.</returns>
        public IList<C301NSEntity> ReportC301NS(string refId, int refTypeId, bool isDetail, bool isParent, int mH)
        {
            string sql = @"uspReportVoucher_C301NS";

            object[] parms =
            {
                "@RefID", refId ,
                "@RefTypeID", refTypeId,
                "@IsDetail", Convert.ToInt32(isDetail),
                "@IsParentProject", Convert.ToInt32(isParent),
                "@MH", Convert.ToInt32(mH)
            };

            return Db.ReadList(sql, true, Make<C301NSEntity>, parms);
        }

        public IList<C301NSDetailEntity> ReportC301NSDetail(string refId, int refTypeId, bool isDetail, bool isParent, int mH)
        {
            string sql = @"uspReportVoucher_C301NS";

            object[] parms =
            {
                "@RefID", refId,
                "@RefTypeID", refTypeId ,
                "@IsDetail", Convert.ToInt32(isDetail),
                "@IsParentProject", Convert.ToInt32(isParent),
                "@MH", Convert.ToInt32(mH)
            };

            return Db.ReadList(sql, true, Make<C301NSDetailEntity>, parms);
        }

        public IList<C301NSDetail2Entity> ReportC301NSDetail2(string refId, int refTypeId, bool isDetail, bool isParent, int mH)
        {
            string sql = @"uspReportVoucher_C301NSDetail2";

            object[] parms =
            {
                "@RefID", refId,
                "@RefTypeID", refTypeId ,
                "@IsDetail", Convert.ToInt32(isDetail),
                "@IsParentProject", Convert.ToInt32(isParent),
                "@MH", Convert.ToInt32(mH)
            };

            return Db.ReadList(sql, true, Make<C301NSDetail2Entity>, parms);
        }

        #endregion

        #region C3-04/NS – Giấy nộp trả vốn đầu tư

        /// <summary>
        /// Reports the cash payment C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C31BBEntity&gt;.</returns>
        public IList<C304NSEntity> ReportC304NS(string refId)
        {
            string sql = @"usp_GetC3_04NS_TT77";

            object[] parms = { "@RefID", refId + "," };
            return Db.ReadList(sql, true, Make<C304NSEntity>, parms);
        }

        /// <summary>
        /// Giấy rút tiền mặt
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        public IList<C409KBEntity> ReportC409KB(string refId, bool isDetail)
        {
            string sql = @"uspReportVoucher_C409KB";

            object[] parms =
            {
                "@RefID", refId,
                "@IsDetail", isDetail
            };
            return Db.ReadList(sql, true, Make<C409KBEntity>, parms);
        }
        public IList<C409KBDetailsEntity> ReportC409KBDetail(string refId, bool isDetail)
        {
            string sql = @"uspReportVoucher_C409KB";

            object[] parms =
            {
                "@RefID", refId,
                "@IsDetail", isDetail
            };
            return Db.ReadList(sql, true, Make<C409KBDetailsEntity>, parms);
        }

        /// <summary>
        /// Giấy đề nghị thanh toán vốn đầu tư
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        public IList<PaymentPurchaseEntity> ReportPaymentPurchase(string refId)
        {
            string sql = @"usp_BUV_PaymentPurchase";

            object[] parms = { "@RefID", refId + "," };
            return Db.ReadList(sql, true, Make<PaymentPurchaseEntity>, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        public IList<C205aEntity> ReportC205A(string refId)
        {
            string sql = @"usp_BAV_InvestmentFundPayment_C2_05_NS_TT77";

            object[] parms = { "@RefID", refId + "," };
            return Db.ReadList(sql, true, Make<C205aEntity>, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        public IList<C206NSEntity> ReportC206NS(string refId)
        {
            string sql = @"usp_BUV_PlanWithdraw_GetCashWithdraw_C206NS_QD759";

            object[] parms = { "@pRefID", refId + "," };
            return Db.ReadList(sql, true, Make<C206NSEntity>, parms);
        }
        #endregion

        #region DataSet
        public DataSet GetDataSet(string storeProcedure, object[] parms)
        {
            return Db.ReadDataSet(storeProcedure, true, parms);
        }
        #endregion
    }
}
