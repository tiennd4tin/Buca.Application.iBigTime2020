/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer
{
    public class SqlServerSupplyLedgerDao : ISupplyLedgerDao
    {
        public SupplyLedgerEntity GetSupplyLedgerByRefId(string refId, int refTypeId)
        {
            throw new NotImplementedException();
        }

        public SupplyLedgerEntity GetSupplyLedgerByInventoryItemId(string inventoryItemId, int refTypeId)
        {
            throw new NotImplementedException();
        }

        public List<SupplyLedgerEntity> GetSupplyLedgerByInventoryItemId(string inventoryItemId)
        {
            throw new NotImplementedException();
        }

        public string InsertSupplyLedger(SupplyLedgerEntity supplyLedger)
        {
            const string sql = @"uspInsert_SupplyLedger";
            return Db.Insert(sql, true, Take(supplyLedger));
        }

        public string DeleteSupplyLedgerByRefId(string refId, int refTypeId)
        {
            const string procedures = @"uspDelete_SupplyLedger_ByRefIDAndRefType";

            object[] parms = { "@RefID", refId, "@RefType", refTypeId };
            return Db.Delete(procedures, true, parms);
        }
        public string DeleteSupplyLedgerByRefId(string refId)
        {
            const string procedures = @"uspDelete_SupplyLedger_ByRefID";

            object[] parms = { "@RefID", refId};
            return Db.Delete(procedures, true, parms);
        }

        public string DeleteSupplyLedgerByOPN()
        {
            const string procedures = @"uspDelete_SupplyLedger_ByOPN";

            object[] parms = {};
            return Db.Delete(procedures, true, parms);
        }

        
        public string DeleteSupplyLedgerByInventoryItemId(string inventoryItemId, int refTypeId)
        {
            throw new NotImplementedException();
        }

        private static readonly Func<IDataReader, SupplyLedgerEntity> Make = reader =>
            new SupplyLedgerEntity
            {
                SupplyLedgerId = reader["SupplyLedgerID"].AsGuid().AsString(),
                RefId = reader["RefID"].AsString(),
                RefType = reader["RefType"].AsInt(),
                RefNo = reader["RefNo"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                DepartmentId = reader["DepartmentID"].AsString(),
                InventoryItemId = reader["InventoryItemID"].AsString(),
                Unit = reader["Unit"].AsString(),
                UnitPrice = reader["UnitPrice"].AsDecimal(),
                IncrementQuantity = reader["IncrementQuantity"].AsDecimal(),
                DecrementQuantity = reader["DecrementQuantity"].AsDecimal(),
                IncrementAmount = reader["IncrementAmount"].AsDecimal(),
                DecrementAmount = reader["DecrementAmount"].AsDecimal(),
                JournalMemo = reader["JournalMemo"].AsString(),
                Description = reader["Description"].AsString(),
                AccountNumber = reader["AccountNumber"].AsString(),
                RefDetailId = reader["RefDetailID"].AsString()
            };

        /// <summary>
        /// Takes the specified fixed asset ledger.
        /// </summary>
        /// <param name="supplyLedgerEntity">The supply ledger entity.</param>
        /// <returns></returns>
        private static object[] Take(SupplyLedgerEntity supplyLedgerEntity)
        {
            return new object[]  
            {
                "@SupplyLedgerID",supplyLedgerEntity.SupplyLedgerId,
		        "@RefID",supplyLedgerEntity.RefId,
		        "@RefType",supplyLedgerEntity.RefType,
		        "@RefNo",supplyLedgerEntity.RefNo,
		        "@RefDate",supplyLedgerEntity.RefDate,
		        "@PostedDate",supplyLedgerEntity.PostedDate,
		        "@DepartmentID",supplyLedgerEntity.DepartmentId,
		        "@InventoryItemID",supplyLedgerEntity.InventoryItemId,
		        "@Unit",supplyLedgerEntity.Unit,
		        "@UnitPrice",supplyLedgerEntity.UnitPrice,
		        "@IncrementQuantity",supplyLedgerEntity.IncrementQuantity,
		        "@DecrementQuantity",supplyLedgerEntity.DecrementQuantity,
		        "@IncrementAmount",supplyLedgerEntity.IncrementAmount,
		        "@DecrementAmount",supplyLedgerEntity.DecrementAmount,
		        "@JournalMemo",supplyLedgerEntity.JournalMemo,
		        "@Description",supplyLedgerEntity.Description,
		        "@AccountNumber",supplyLedgerEntity.AccountNumber,
		        "@RefDetailID",supplyLedgerEntity.RefDetailId 
            };
        }
    }
}
