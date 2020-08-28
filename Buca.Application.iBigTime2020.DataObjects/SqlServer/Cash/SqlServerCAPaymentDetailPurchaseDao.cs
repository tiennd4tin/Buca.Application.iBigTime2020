using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Cash
{
    /// <summary>
    /// Class SqlServerCAPaymentDetailPurchaseDao.
    /// </summary>
    public class SqlServerCAPaymentDetailPurchaseDao : ICAPaymentDetailPurchaseDao
    {
        /// <summary>
        /// Gets the ca payment detail purchases by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.Collections.Generic.List&lt;Buca.Application.iBigTime2020.BusinessEntities.Business.Cash.CAPaymentDetailPurchaseEntity&gt;.</returns>
        public List<CAPaymentDetailPurchaseEntity> GetCAPaymentDetailPurchasesByRefId(string refId)
        {
            const string procedures = @"uspGet_CAPaymentDetailPurchase_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Deletes the ca payment detail purchase.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteCAPaymentDetailPurchase(string refId)
        {
            const string procedures = @"uspDelete_CAPaymentDetailPurchase_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Inserts the ca payment detail purchase.
        /// </summary>
        /// <param name="caPaymentDetail">The ca payment detail.</param>
        /// <returns>System.String.</returns>
        public string InsertCAPaymentDetailPurchase(CAPaymentDetailPurchaseEntity caPaymentDetail)
        {
            const string procedures = @"uspInsert_CAPaymentDetailPurchase";
            return Db.Insert(procedures, true, Take(caPaymentDetail));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CAPaymentDetailPurchaseEntity> Make = reader =>
            new CAPaymentDetailPurchaseEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                InventoryItemId = reader["InventoryItemID"].AsString(),
                Description = reader["Description"].AsString(),
                StockId = reader["StockID"].AsString(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                Unit = reader["Unit"].AsString(),
                Quantity = reader["Quantity"].AsDecimal(),
                QuantityConvert = reader["QuantityConvert"].AsDecimal(),
                UnitPrice = reader["UnitPrice"].AsDecimal(),
                UnitPriceConvert = reader["UnitPriceConvert"].AsDecimal(),
                Amount = reader["Amount"].AsDecimal(),
                InvType = reader["InvType"].AsInt(),
                InvDate = reader["InvDate"].AsDateTimeForNull(),
                InvSeries = reader["InvSeries"].AsString(),
                InvNo = reader["InvNo"].AsString(),
                TaxRate = reader["TaxRate"].AsDecimalForNull(),
                TaxAmount = reader["TaxAmount"].AsDecimal(),
                TaxAccount = reader["TaxAccount"].AsString(),
                PurchasePurposeId = reader["PurchasePurposeID"].AsString(),
                FreightAmount = reader["FreightAmount"].AsDecimal(),
                InwardAmount = reader["InwardAmount"].AsDecimal(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetItemCode = reader["BudgetItemCode"].AsString(),
                BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                MethodDistributeId = reader["MethodDistributeID"].AsInt(),
                CashWithdrawTypeId = reader["CashWithdrawTypeID"].AsInt(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                ActivityId = reader["ActivityID"].AsString(),
                ProjectId = reader["ProjectID"].AsString(),
                ProjectActivityId = reader["ProjectActivityID"].AsString(),
                ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                ExpiryDate = reader["ExpiryDate"].AsDateTimeForNull(),
                LotNo = reader["LotNo"].AsString(),
                Approved = reader["Approved"].AsBool(),
                SortOrder = reader["SortOrder"].AsInt(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                InvoiceTypeCode = reader["InvoiceTypeCode"].AsString(),
                OrgRefNo = reader["OrgRefNo"].AsString(),
                OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
                FundStructureId = reader["FundStructureID"].AsString(),
                ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
                ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
                BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
                ContractId = reader["ContractID"].AsString(),
                CapitalPlanId = reader["CapitalPlanID"].AsString(),
                AutoBusinessId = reader["AutoBusinessID"].AsString(),
                BankId = reader["BankID"].AsString(),
                AmountExchange = reader["AmountExchange"].AsDecimal()
            };

        /// <summary>
        /// Takes the specified c a payment detail entity.
        /// </summary>
        /// <param name="cAPaymentDetailEntity">The c a payment detail entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(CAPaymentDetailPurchaseEntity cAPaymentDetailEntity)
        {
            return new object[]
            {
                "@RefDetailID",cAPaymentDetailEntity.RefDetailId,
                "@RefID",cAPaymentDetailEntity.RefId,
                "@InventoryItemID",cAPaymentDetailEntity.InventoryItemId,
                "@Description",cAPaymentDetailEntity.Description,
                "@StockID",cAPaymentDetailEntity.StockId,
                "@DebitAccount",cAPaymentDetailEntity.DebitAccount,
                "@CreditAccount",cAPaymentDetailEntity.CreditAccount,
                "@Unit",cAPaymentDetailEntity.Unit,
                "@Quantity",cAPaymentDetailEntity.Quantity,
                "@QuantityConvert",cAPaymentDetailEntity.QuantityConvert,
                "@UnitPrice",cAPaymentDetailEntity.UnitPrice,
                "@UnitPriceConvert",cAPaymentDetailEntity.UnitPriceConvert,
                "@Amount",cAPaymentDetailEntity.Amount,
                "@InvType",cAPaymentDetailEntity.InvType,
                "@InvDate",cAPaymentDetailEntity.InvDate,
                "@InvSeries",cAPaymentDetailEntity.InvSeries,
                "@InvNo",cAPaymentDetailEntity.InvNo,
                "@TaxRate",cAPaymentDetailEntity.TaxRate,
                "@TaxAmount",cAPaymentDetailEntity.TaxAmount,
                "@TaxAccount",cAPaymentDetailEntity.TaxAccount,
                "@PurchasePurposeID",cAPaymentDetailEntity.PurchasePurposeId,
                "@FreightAmount",cAPaymentDetailEntity.FreightAmount,
                "@InwardAmount",cAPaymentDetailEntity.InwardAmount,
                "@BudgetSourceID",cAPaymentDetailEntity.BudgetSourceId,
                "@BudgetChapterCode",cAPaymentDetailEntity.BudgetChapterCode,
                "@BudgetKindItemCode",cAPaymentDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",cAPaymentDetailEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",cAPaymentDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode",cAPaymentDetailEntity.BudgetSubItemCode,
                "@MethodDistributeID",cAPaymentDetailEntity.MethodDistributeId,
                "@CashWithdrawTypeID",cAPaymentDetailEntity.CashWithdrawTypeId,
                "@AccountingObjectID",cAPaymentDetailEntity.AccountingObjectId,
                "@ActivityID",cAPaymentDetailEntity.ActivityId,
                "@ProjectID",cAPaymentDetailEntity.ProjectId,
                "@ProjectActivityID",cAPaymentDetailEntity.ProjectActivityId,
                "@ProjectExpenseID",cAPaymentDetailEntity.ProjectExpenseId,
                "@ListItemID",cAPaymentDetailEntity.ListItemId,
                "@ExpiryDate",cAPaymentDetailEntity.ExpiryDate,
                "@LotNo",cAPaymentDetailEntity.LotNo,
                "@Approved",cAPaymentDetailEntity.Approved,
                "@SortOrder",cAPaymentDetailEntity.SortOrder,
                "@BudgetDetailItemCode",cAPaymentDetailEntity.BudgetDetailItemCode,
                "@InvoiceTypeCode",cAPaymentDetailEntity.InvoiceTypeCode,
                "@OrgRefNo",cAPaymentDetailEntity.OrgRefNo,
                "@OrgRefDate",cAPaymentDetailEntity.OrgRefDate,
                "@FundStructureID",cAPaymentDetailEntity.FundStructureId,
                "@ProjectExpenseEAID",cAPaymentDetailEntity.ProjectExpenseEAId,
                "@ProjectActivityEAID",cAPaymentDetailEntity.ProjectActivityEAId,
                "@BudgetExpenseID",cAPaymentDetailEntity.BudgetExpenseId,
                "@ContractID", cAPaymentDetailEntity.ContractId,
                "@CapitalPlanID", cAPaymentDetailEntity.CapitalPlanId,
                "@AutoBusinessID", cAPaymentDetailEntity.AutoBusinessId,
                "@BankID", cAPaymentDetailEntity.BankId,
                "@AmountExchange", cAPaymentDetailEntity.AmountExchange
            };
        }
    }

}