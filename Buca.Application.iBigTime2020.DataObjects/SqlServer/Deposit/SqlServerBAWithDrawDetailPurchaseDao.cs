/***********************************************************************
 * <copyright file="sqlserverbawithdrawdetailpurchasedao.cs" company="BUCA JSC">
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
    ///     SqlServerBAWithDrawDetailPurchaseDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit.IBAWithDrawDetailPurchaseDao" />
    public class SqlServerBAWithDrawDetailPurchaseDao : IBAWithDrawDetailPurchaseDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BAWithDrawDetailPurchaseEntity> Make = reader =>
            new BAWithDrawDetailPurchaseEntity
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
                UnitPrice = reader["UnitPrice"].AsDecimal(),
                QuantityConvert = reader["QuantityConvert"].AsDecimal(),
                UnitPriceConvert = reader["UnitPriceConvert"].AsDecimal(),
                Amount = reader["Amount"].AsDecimal(),
                TaxRate = reader["TaxRate"].AsDecimal(),
                TaxAmount = reader["TaxAmount"].AsDecimal(),
                TaxAccount = reader["TaxAccount"].AsString(),
                InvType = reader["InvType"].AsInt(),
                InvDate = reader["InvDate"].AsDateTimeForNull(),
                InvSeries = reader["InvSeries"].AsString(),
                InvNo = reader["InvNo"].AsString(),
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
                FundId = reader["FundID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                ExpiryDate = reader["ExpiryDate"].AsDateTimeForNull(),
                LotNo = reader["LotNo"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                InvoiceTypeCode = reader["InvoiceTypeCode"].AsString(),
                OrgRefNo = reader["OrgRefNo"].AsString(),
                OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
                FundStructureId = reader["FundStructureID"].AsString(),
                ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
                BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
                BankId = reader["BankID"].AsString(),
            };

        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<BAWithDrawDetailPurchaseEntity> GetBAWithDrawDetailPurchaseEntitysByRefId(string refId)
        {
            const string procedures = @"uspGet_BAWithDrawDetailPurchase_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bAWithDrawDetailPurchase">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertBAWithDrawDetailPurchaseEntity(BAWithDrawDetailPurchaseEntity bAWithDrawDetailPurchase)
        {
            const string sql = @"uspInsert_BAWithDrawDetailPurchase";
            return Db.Insert(sql, true, Take(bAWithDrawDetailPurchase));
        }

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public string DeleteBAWithDrawDetailPurchaseEntityByRefId(string refId)
        {
            const string procedures = @"uspDelete_BAWithDrawDetailPurchase_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified bADeposit.
        /// </summary>
        /// <param name="bAWithDrawDetailPurchaseEntity">The b a with draw detail purchase entity.</param>
        /// <returns></returns>
        private object[] Take(BAWithDrawDetailPurchaseEntity bAWithDrawDetailPurchaseEntity)
        {
            return new object[]
            {
                "@RefDetailID", bAWithDrawDetailPurchaseEntity.RefDetailId,
                "@RefID", bAWithDrawDetailPurchaseEntity.RefId,
                "@InventoryItemID", bAWithDrawDetailPurchaseEntity.InventoryItemId,
                "@Description", bAWithDrawDetailPurchaseEntity.Description,
                "@StockID", bAWithDrawDetailPurchaseEntity.StockId,
                "@DebitAccount", bAWithDrawDetailPurchaseEntity.DebitAccount,
                "@CreditAccount", bAWithDrawDetailPurchaseEntity.CreditAccount,
                "@Unit", bAWithDrawDetailPurchaseEntity.Unit,
                "@Quantity", bAWithDrawDetailPurchaseEntity.Quantity,
                "@UnitPrice", bAWithDrawDetailPurchaseEntity.UnitPrice,
                "@QuantityConvert", bAWithDrawDetailPurchaseEntity.QuantityConvert,
                "@UnitPriceConvert", bAWithDrawDetailPurchaseEntity.UnitPriceConvert,
                "@Amount", bAWithDrawDetailPurchaseEntity.Amount,
                "@TaxRate", bAWithDrawDetailPurchaseEntity.TaxRate,
                "@TaxAmount", bAWithDrawDetailPurchaseEntity.TaxAmount,
                "@TaxAccount", bAWithDrawDetailPurchaseEntity.TaxAccount,
                "@InvType", bAWithDrawDetailPurchaseEntity.InvType,
                "@InvDate", bAWithDrawDetailPurchaseEntity.InvDate,
                "@InvSeries", bAWithDrawDetailPurchaseEntity.InvSeries,
                "@InvNo", bAWithDrawDetailPurchaseEntity.InvNo,
                "@PurchasePurposeID", bAWithDrawDetailPurchaseEntity.PurchasePurposeId,
                "@FreightAmount", bAWithDrawDetailPurchaseEntity.FreightAmount,
                "@InwardAmount", bAWithDrawDetailPurchaseEntity.InwardAmount,
                "@BudgetSourceID", bAWithDrawDetailPurchaseEntity.BudgetSourceId,
                "@BudgetChapterCode", bAWithDrawDetailPurchaseEntity.BudgetChapterCode,
                "@BudgetKindItemCode", bAWithDrawDetailPurchaseEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", bAWithDrawDetailPurchaseEntity.BudgetSubKindItemCode,
                "@BudgetItemCode", bAWithDrawDetailPurchaseEntity.BudgetItemCode,
                "@BudgetSubItemCode", bAWithDrawDetailPurchaseEntity.BudgetSubItemCode,
                "@MethodDistributeID", bAWithDrawDetailPurchaseEntity.MethodDistributeId,
                "@CashWithdrawTypeID", bAWithDrawDetailPurchaseEntity.CashWithdrawTypeId,
                "@AccountingObjectID", bAWithDrawDetailPurchaseEntity.AccountingObjectId,
                "@ActivityID", bAWithDrawDetailPurchaseEntity.ActivityId,
                "@ProjectID", bAWithDrawDetailPurchaseEntity.ProjectId,
                "@ProjectActivityID", bAWithDrawDetailPurchaseEntity.ProjectActivityId,
                "@FundID", bAWithDrawDetailPurchaseEntity.FundId,
                "@ListItemID", bAWithDrawDetailPurchaseEntity.ListItemId,
                "@ExpiryDate", bAWithDrawDetailPurchaseEntity.ExpiryDate,
                "@LotNo", bAWithDrawDetailPurchaseEntity.LotNo,
                "@SortOrder", bAWithDrawDetailPurchaseEntity.SortOrder,
                "@BudgetDetailItemCode", bAWithDrawDetailPurchaseEntity.BudgetDetailItemCode,
                "@InvoiceTypeCode", bAWithDrawDetailPurchaseEntity.InvoiceTypeCode,
                "@OrgRefNo", bAWithDrawDetailPurchaseEntity.OrgRefNo,
                "@OrgRefDate", bAWithDrawDetailPurchaseEntity.OrgRefDate,
                "@FundStructureID", bAWithDrawDetailPurchaseEntity.FundStructureId,
                "@ProjectActivityEAID", bAWithDrawDetailPurchaseEntity.ProjectActivityEAId,
                "@BudgetExpenseID", bAWithDrawDetailPurchaseEntity.BudgetExpenseId,
                "@BankID", bAWithDrawDetailPurchaseEntity.BankId,
            };
        }
    }
}