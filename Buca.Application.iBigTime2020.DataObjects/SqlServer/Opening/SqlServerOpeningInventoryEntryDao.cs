/***********************************************************************
 * <copyright file="SqlServerOpeningInventoryEntryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using Buca.Application.iBigTime2020.DataHelpers;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Opening
{
    /// <summary>
    /// SqlServerOpeningInventoryEntryDao
    /// </summary>
    public class SqlServerOpeningInventoryEntryDao : DaoBase, IOpeningInventoryEntryDao
    {
        public List<OpeningInventoryEntryEntity> GetOpeningInventoryEntries(string acccountNumber)
        {
            const string procedures = @"uspGet_All_OpeningInventoryEntry";
            object[] parms = { "@AccountNumber", acccountNumber };
            return Db.ReadList(procedures, true, Make<OpeningInventoryEntryEntity>, parms);
        }

        public string UpdateOpeningInventoryEntry(OpeningInventoryEntryEntity openingCommitment)
        {
            const string procedures = @"uspUpdate_OpeningInventoryEntry";
            return Db.Insert(procedures, true, Take(openingCommitment));
        }

        public string DeleteOpeningInventoryEntries(string acccountNumber)
        {
            const string procedures = @"uspDelete_OpeningInventoryEntries";
            object[] parms = { "@AccountNumber", acccountNumber };
            return Db.Delete(procedures, true, parms);
        }

        private static object[] Take(OpeningInventoryEntryEntity openingInventoryEntryEntity)
        {
            return new object[]
            {
                "@RefID", openingInventoryEntryEntity.RefId,
                "@RefType", openingInventoryEntryEntity.RefType,
                "@PostedDate", openingInventoryEntryEntity.PostedDate,
                "@CurrencyCode", openingInventoryEntryEntity.CurrencyCode,
                "@ExchangeRate", openingInventoryEntryEntity.ExchangeRate,
                "@AccountNumber", openingInventoryEntryEntity.AccountNumber,
                "@InventoryItemID", openingInventoryEntryEntity.InventoryItemId,
                "@StockID", openingInventoryEntryEntity.StockId,
                "@BudgetSourceID", openingInventoryEntryEntity.BudgetSourceId,
                "@BudgetChapterCode", openingInventoryEntryEntity.BudgetChapterCode,
                "@BudgetKindItemCode", openingInventoryEntryEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", openingInventoryEntryEntity.BudgetSubKindItemCode,
                "@BudgetItemCode", openingInventoryEntryEntity.BudgetItemCode,
                "@BudgetSubItemCode", openingInventoryEntryEntity.BudgetSubItemCode,
                "@Quantity", openingInventoryEntryEntity.Quantity,
                "@UnitPriceOC", openingInventoryEntryEntity.UnitPriceOC,
                "@UnitPrice", openingInventoryEntryEntity.UnitPrice,
                "@AmountOC", openingInventoryEntryEntity.AmountOC,
                "@Amount", openingInventoryEntryEntity.Amount,
                "@ExpiryDate", openingInventoryEntryEntity.ExpiryDate,
                "@LotNo", openingInventoryEntryEntity.LotNo,
                "@SortOrder", openingInventoryEntryEntity.SortOrder,
                "@RefOrder", openingInventoryEntryEntity.RefOrder,
                "@ContractID", openingInventoryEntryEntity.ContractId,
                "@CapitalPlanID", openingInventoryEntryEntity.CapitalPlanId,
            };
        }
    }
}
