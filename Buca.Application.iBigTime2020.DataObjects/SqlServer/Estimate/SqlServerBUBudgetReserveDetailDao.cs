/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    11/12/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlServerBUBudgetReserveDetailDao : IBUBudgetReserveDetailDao
    {
        /// <summary>
        /// Deletes the bu budget reserve detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public string DeleteBUBudgetReserveDetail(string refId)
        {
            const string procedures = @"uspDelete_BUBudgetReserveDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the bu budget reserve details by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public List<BUBudgetReserveDetailEntity> GetBUBudgetReserveDetailsByRefId(string refId)
        {
            const string procedures = @"uspGet_BUBudgetReserveDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms); 
        }

        /// <summary>
        /// Inserts the bu budget reserve detail.
        /// </summary>
        /// <param name="buBudgetReserveDetail">The bu budget reserve detail.</param>
        /// <returns></returns>
        public string InsertBUBudgetReserveDetail(BUBudgetReserveDetailEntity buBudgetReserveDetail)
        {
            const string procedures = @"uspInsert_BUBudgetReserveDetail";
            return Db.Insert(procedures, true, Take(buBudgetReserveDetail));   
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUBudgetReserveDetailEntity> Make = reader =>
          new BUBudgetReserveDetailEntity
          {
              RefDetailId = reader["RefDetailID"].AsGuid().AsString(),
              RefId = reader["RefID"].AsString(),
              Description = reader["Description"].AsString(),
              Amount = reader["Amount"].AsDecimal(),
              AmountOC = reader["AmountOC"].AsDecimal(),
              BudgetSourceId = reader["BudgetSourceID"].AsString(),
              BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
              BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
              BudgetItemCode = reader["BudgetItemCode"].AsString(),
              BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
              BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
              MethodDistributeId = reader["MethodDistributeID"].AsInt(),
              CashWithDrawTypeId = reader["CashWithDrawTypeID"].AsInt(),
              ActivityId = reader["ActivityID"].AsString(),
              ProjectId = reader["ProjectID"].AsString(),
              ProjectActivityId = reader["ProjectActivityID"].AsString(),
              ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
              ListItemId = reader["ListItemID"].AsString(),
              Approved = reader["Approved"].AsBool(),
              FundStructureId = reader["FundStructureID"].AsString(),
              SortOrder = reader["SortOrder"].AsInt(),
              BudgetGroupItemCode = reader["BudgetGroupItemCode"].AsString(),
              BankAccount = reader["BankAccount"].AsString(),
              BudgetProvideCode = reader["BudgetProvideCode"].AsString()
          };

        /// <summary>
        /// Takes the specified b u budget reserve entity.
        /// </summary>
        /// <param name="bUBudgetReserveDetailEntity">The b u budget reserve detail entity.</param>
        /// <returns></returns>
        private static object[] Take(BUBudgetReserveDetailEntity bUBudgetReserveDetailEntity)
        {
            return new object[]
            {
                "@RefDetailID",bUBudgetReserveDetailEntity.RefDetailId,
		        "@RefID",bUBudgetReserveDetailEntity.RefId,
		        "@Description",bUBudgetReserveDetailEntity.Description,
		        "@Amount",bUBudgetReserveDetailEntity.Amount,
		        "@AmountOC",bUBudgetReserveDetailEntity.AmountOC,
		        "@BudgetSourceID",bUBudgetReserveDetailEntity.BudgetSourceId,
		        "@BudgetKindItemCode",bUBudgetReserveDetailEntity.BudgetKindItemCode,
		        "@BudgetSubKindItemCode",bUBudgetReserveDetailEntity.BudgetSubKindItemCode,
		        "@BudgetItemCode",bUBudgetReserveDetailEntity.BudgetItemCode,
		        "@BudgetSubItemCode",bUBudgetReserveDetailEntity.BudgetSubItemCode,
		        "@BudgetDetailItemCode",bUBudgetReserveDetailEntity.BudgetDetailItemCode,
		        "@MethodDistributeID",bUBudgetReserveDetailEntity.MethodDistributeId,
		        "@CashWithDrawTypeID",bUBudgetReserveDetailEntity.CashWithDrawTypeId,
		        "@ActivityID",bUBudgetReserveDetailEntity.ActivityId,
		        "@ProjectID",bUBudgetReserveDetailEntity.ProjectId,
		        "@ProjectActivityID",bUBudgetReserveDetailEntity.ProjectActivityId,
		        "@ProjectExpenseID",bUBudgetReserveDetailEntity.ProjectExpenseId,
		        "@ListItemID",bUBudgetReserveDetailEntity.ListItemId,
		        "@Approved",bUBudgetReserveDetailEntity.Approved,
		        "@FundStructureID",bUBudgetReserveDetailEntity.FundStructureId,
		        "@SortOrder",bUBudgetReserveDetailEntity.SortOrder,
		        "@BudgetGroupItemCode",bUBudgetReserveDetailEntity.BudgetGroupItemCode,
		        "@BankAccount",bUBudgetReserveDetailEntity.BankAccount,
		        "@BudgetProvideCode",bUBudgetReserveDetailEntity.BudgetProvideCode
            };
        }
    }
}
