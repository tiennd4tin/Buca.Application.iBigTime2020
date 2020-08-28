/***********************************************************************
 * <copyright file="sqlserverbadepositdetailsaledao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 18, 2017
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
    ///     SqlServerBADepositDetailSaleDao
    /// </summary>
    public class SqlServerBADepositDetailSaleDao : IBADepositDetailSaleDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BADepositDetailSaleEntity> Make = reader =>
            new BADepositDetailSaleEntity
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
                OutwardPrice = reader["OutwardPrice"].AsDecimal(),
                OutwardAmount = reader["OutwardAmount"].AsDecimal(),
                InventoryAccount = reader["InventoryAccount"].AsString(),
                COGSAccount = reader["COGSAccount"].AsString(),
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
                ConfrontingRefId = reader["ConfrontingRefID"].AsString(),
                ConfrontingRefNo = reader["ConfrontingRefNo"].AsString(),
                ExpiryDate = reader["ExpiryDate"].AsString().AsDateTimeForNull(),
                LotNo = reader["LotNo"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                FundStructureId = reader["FundStructureID"].AsString(),
                ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
                ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
                DiscountRate = reader["DiscountRate"].AsDecimal(),
                DiscountAmount = reader["DiscountAmount"].AsDecimal()
            };

        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<BADepositDetailSaleEntity> GetBADepositDetailSalesByRefId(string refId)
        {
            const string procedures = @"uspGet_BADepositDetailSale_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bADepositDetailSale">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertBADepositDetailSale(BADepositDetailSaleEntity bADepositDetailSale)
        {
            const string sql = @"uspInsert_BADepositDetailSale";
            return Db.Insert(sql, true, Take(bADepositDetailSale));
        }

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public string DeleteBADepositDetailSaleByRefId(string refId)
        {
            const string procedures = @"uspDelete_BADepositDetailSale_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified bADeposit.
        /// </summary>
        /// <param name="bADepositDetailSaleEntity">The b a deposit detail sale entity.</param>
        /// <returns></returns>
        private static object[] Take(BADepositDetailSaleEntity bADepositDetailSaleEntity)
        {
            return new object[]
            {
                "@RefDetailID", bADepositDetailSaleEntity.RefDetailId,
                "@RefID", bADepositDetailSaleEntity.RefId,
                "@InventoryItemID", bADepositDetailSaleEntity.InventoryItemId,
                "@Description", bADepositDetailSaleEntity.Description,
                "@StockID", bADepositDetailSaleEntity.StockId,
                "@DebitAccount", bADepositDetailSaleEntity.DebitAccount,
                "@CreditAccount", bADepositDetailSaleEntity.CreditAccount,
                "@Unit", bADepositDetailSaleEntity.Unit,
                "@Quantity", bADepositDetailSaleEntity.Quantity,
                "@UnitPrice", bADepositDetailSaleEntity.UnitPrice,
                "@QuantityConvert", bADepositDetailSaleEntity.QuantityConvert,
                "@UnitPriceConvert", bADepositDetailSaleEntity.UnitPriceConvert,
                "@Amount", bADepositDetailSaleEntity.Amount,
                "@TaxRate", bADepositDetailSaleEntity.TaxRate,
                "@TaxAmount", bADepositDetailSaleEntity.TaxAmount,
                "@TaxAccount", bADepositDetailSaleEntity.TaxAccount,
                "@OutwardPrice", bADepositDetailSaleEntity.OutwardPrice,
                "@OutwardAmount", bADepositDetailSaleEntity.OutwardAmount,
                "@InventoryAccount", bADepositDetailSaleEntity.InventoryAccount,
                "@COGSAccount", bADepositDetailSaleEntity.COGSAccount,
                "@BudgetSourceID", bADepositDetailSaleEntity.BudgetSourceId,
                "@BudgetChapterCode", bADepositDetailSaleEntity.BudgetChapterCode,
                "@BudgetKindItemCode", bADepositDetailSaleEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", bADepositDetailSaleEntity.BudgetSubKindItemCode,
                "@BudgetItemCode", bADepositDetailSaleEntity.BudgetItemCode,
                "@BudgetSubItemCode", bADepositDetailSaleEntity.BudgetSubItemCode,
                "@MethodDistributeID", bADepositDetailSaleEntity.MethodDistributeId,
                "@CashWithdrawTypeID", bADepositDetailSaleEntity.CashWithdrawTypeId,
                "@AccountingObjectID", bADepositDetailSaleEntity.AccountingObjectId,
                "@ActivityID", bADepositDetailSaleEntity.ActivityId,
                "@ProjectID", bADepositDetailSaleEntity.ProjectId,
                "@ProjectActivityID", bADepositDetailSaleEntity.ProjectActivityId,
                "@ProjectExpenseID", bADepositDetailSaleEntity.ProjectExpenseId,
                "@ListItemID", bADepositDetailSaleEntity.ListItemId,
                "@ConfrontingRefID", bADepositDetailSaleEntity.ConfrontingRefId,
                "@ConfrontingRefNo", bADepositDetailSaleEntity.ConfrontingRefNo,
                "@ExpiryDate", bADepositDetailSaleEntity.ExpiryDate,
                "@LotNo", bADepositDetailSaleEntity.LotNo,
                "@SortOrder", bADepositDetailSaleEntity.SortOrder,
                "@BudgetDetailItemCode", bADepositDetailSaleEntity.BudgetDetailItemCode,
                "@FundStructureID", bADepositDetailSaleEntity.FundStructureId,
                "@ProjectExpenseEAID", bADepositDetailSaleEntity.ProjectExpenseEAId,
                "@ProjectActivityEAID", bADepositDetailSaleEntity.ProjectActivityEAId,
                "@DiscountRate", bADepositDetailSaleEntity.DiscountRate,
                "@DiscountAmount", bADepositDetailSaleEntity.DiscountAmount
            };
        }
    }
}