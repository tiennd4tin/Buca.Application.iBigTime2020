/***********************************************************************
 * <copyright file="SqlServerJournalEntryAccountDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 20 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Inventory
{
    public class SqlServerInventoryLedgerDao : IInventoryLedgerDao
    {
        /// <summary>
        /// Inserts the general ledger.
        /// </summary>
        /// <param name="inventoryLedgerEntity">The general ledger entity.</param>
        /// <returns>System.Int32.</returns>
        public string InsertInventoryLedger(InventoryLedgerEntity inventoryLedgerEntity)
        {
            const string procedures = @"uspInsert_InventoryLedger";
            return Db.Insert(procedures, true, Take(inventoryLedgerEntity));
        }

        /// <summary>
        /// Deletes the general ledger.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteInventoryLedger(string refId)
        {
            const string procedures = @"uspDelete_InventoryLedger_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Deletes the inventory ledger.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns></returns>
        public string DeleteInventoryLedger(string accountNumber, int refType)
        {
            const string procedures = @"uspDelete_InventoryLedger_ByAccountNumberAndRefType";
            object[] parms = { "@AccountNumber", accountNumber, "@RefType", refType };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Takes the specified general ledger entity.
        /// </summary>
        /// <param name="inventoryLedgerEntity">The general ledger entity.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(InventoryLedgerEntity inventoryLedgerEntity)
        {
            return new object[]
            {
                "@InventoryLedgerID",inventoryLedgerEntity.InventoryLedgerId,
                "@RefID",inventoryLedgerEntity.RefId,
                "@RefType",inventoryLedgerEntity.RefType,
                "@RefNo",inventoryLedgerEntity.RefNo,
                "@RefDate",inventoryLedgerEntity.RefDate,
                "@PostedDate",inventoryLedgerEntity.PostedDate,
                "@AccountNumber",inventoryLedgerEntity.AccountNumber,
                "@CorrespondingAccountNumber",inventoryLedgerEntity.CorrespondingAccountNumber,
                "@BudgetSourceID",inventoryLedgerEntity.BudgetSourceId,
                "@StockID",inventoryLedgerEntity.StockId,
                "@InventoryItemID",inventoryLedgerEntity.InventoryItemId,
                "@Unit",inventoryLedgerEntity.Unit,
                "@UnitPrice",inventoryLedgerEntity.UnitPrice,
                "@InwardQuantity",inventoryLedgerEntity.InwardQuantity,
                "@OutwardQuantity",inventoryLedgerEntity.OutwardQuantity,
                "@InwardAmount",inventoryLedgerEntity.InwardAmount,
                "@OutwardAmount",inventoryLedgerEntity.OutwardAmount,
                "@InwardQuantityBalance",inventoryLedgerEntity.InwardQuantityBalance,
                "@InwardAmountBalance",inventoryLedgerEntity.InwardAmountBalance,
                "@JournalMemo",inventoryLedgerEntity.JournalMemo,
                "@Description",inventoryLedgerEntity.Description,
                "@OutwardPurpose",inventoryLedgerEntity.OutwardPurpose,
                "@ExpiryDate",inventoryLedgerEntity.ExpiryDate,
                "@LotNo",inventoryLedgerEntity.LotNo,
                "@RefOrder",inventoryLedgerEntity.RefOrder,
                "@RefDetailID",inventoryLedgerEntity.RefDetailId,
                "@SortOrder",inventoryLedgerEntity.SortOrder,
                "@ConfrontingRefID",inventoryLedgerEntity.ConfrontingRefId,
                "@InwardRefDetailID",inventoryLedgerEntity.InwardRefDetailId,
                "@UnitPriceBalance",inventoryLedgerEntity.UnitPriceBalance,
                "@InwardAmountBalanceAfter",inventoryLedgerEntity.InwardAmountBalanceAfter,
                "@BudgetProvideCode",inventoryLedgerEntity.BudgetProvideCode,
                "@InwardAmountOC",inventoryLedgerEntity.InwardAmountOC,
                "@OutwardAmountOC",inventoryLedgerEntity.OutwardAmountOC,
                "@CurrencyCode",inventoryLedgerEntity.CurrencyCode,
            };
        }
    }
}
