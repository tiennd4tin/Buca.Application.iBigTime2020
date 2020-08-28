using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Inventory
{
    public class SqlINInwardOutwardDetailParallelDao : IINInwardOutwardDetailParallelDao
    {
        /// <summary>
        /// Deletes the InInwardOutwardDetailParallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteINInwardOutwardDetailParallelId(string refId)
        {
            const string procedures = @"uspDelete_INInwardOutwardDetailParallel_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }
        /// <summary>
        /// Gets the InInwardOutwardDetailParallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;INInwardOutwardDetailParallelEntity&gt;.</returns>
        public List<INInwardOutwardDetailParallelEntity> GetINInwardOutwardDetailParallelbyRefId(string refId)
        {
            const string procedures = @"uspGet_INInwardOutwardDetailParallel_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }
        /// <summary>
        /// Insert the InInwardOutwardDetailParallel.
        /// </summary>
        /// <param name="InwardOutwardDetail">The InInwardOutwardDetailParallel.</param>
        /// <returns>System.string</returns>
        public string InsertINInwardOutwardDetailParallel(INInwardOutwardDetailParallelEntity InwardOutwardDetail)
        {
            const string procedures = @"uspInsert_INInwardOutwardDetailParallel";
            return Db.Insert(procedures, true, Take(InwardOutwardDetail));
        }
        /// <summary>
        /// Update the InInwardOutwardDetailParallel.
        /// </summary>
        /// <param name="InwardOutwardDetail">The InInwardOutwardDetailParallel.</param>
        /// <returns>System.string</returns>
        public string UpdateINInwardOutwardDetailParallel(INInwardOutwardDetailParallelEntity InwardOutwardDetail)
        {
            throw new NotImplementedException();
        }
        private static readonly Func<IDataReader, INInwardOutwardDetailParallelEntity> Make = reader =>
         new INInwardOutwardDetailParallelEntity
         {
             RefDetailId = reader["RefDetailID"].AsString(),
             RefId = reader["RefID"].AsString(),
             Description = reader["Description"].AsString(),
             DebitAccount = reader["DebitAccount"].AsString(),
             CreditAccount = reader["CreditAccount"].AsString(),
             Amount = reader["Amount"].AsDecimal(),
             AmountOC = reader["AmountOC"].AsDecimal(),
             BudgetSourceId = reader["BudgetSourceID"].AsString(),
             BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
             BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
             BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
             BudgetItemCode = reader["BudgetItemCode"].AsString(),
             BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
             BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
             MethodDistributeId = reader["MethodDistributeID"].AsInt(),
             CashWithdrawTypeId = reader["CashWithdrawTypeID"].AsInt(),
             AccountingObjectId = reader["AccountingObjectID"].AsString(),
             ActivityId = reader["ActivityID"].AsString(),
             ProjectId = reader["ProjectID"].AsString(),
             TaskId = reader["TaskID"].AsString(),
             ListItemId = reader["ListItemID"].AsString(),
             Approved = reader["Approved"].AsBool(),
             SortOrder = reader["SortOrder"].AsInt(),
             OrgRefNo = reader["OrgRefNo"].AsString(),
             OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
             FundStructureId = reader["FundStructureID"].AsString(),
             BankId = reader["BankID"].AsString(),
             BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
             BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
             ContractId = reader["ContractID"].AsString(),
             CapitalPlanId = reader["CapitalPlanID"].AsString(),
             Quantity=reader["Quantity"].AsDecimal(),
             UnitPrice=reader["UnitPrice"].AsDecimal(),
             InventoryItemId=reader["InventoryItemId"].AsString(),
         };

        /// <summary>
        /// Takes the specified c a payment detail parallel entity.
        /// </summary>
        /// <param name="cAPaymentDetailParallelEntity">The c a payment detail parallel entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(INInwardOutwardDetailParallelEntity iNInwardOutwardDetailParallelEntity)
        {
            return new object[]
            {
                "@RefDetailID",iNInwardOutwardDetailParallelEntity.RefDetailId,
                "@RefID",iNInwardOutwardDetailParallelEntity.RefId,
                "@Description",iNInwardOutwardDetailParallelEntity.Description,
                "@DebitAccount",iNInwardOutwardDetailParallelEntity.DebitAccount,
                "@CreditAccount",iNInwardOutwardDetailParallelEntity.CreditAccount,
                "@Amount",iNInwardOutwardDetailParallelEntity.Amount,
                "@AmountOC",iNInwardOutwardDetailParallelEntity.AmountOC,
                "@BudgetSourceID",iNInwardOutwardDetailParallelEntity.BudgetSourceId,
                "@BudgetChapterCode",iNInwardOutwardDetailParallelEntity.BudgetChapterCode,
                "@BudgetKindItemCode",iNInwardOutwardDetailParallelEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",iNInwardOutwardDetailParallelEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",iNInwardOutwardDetailParallelEntity.BudgetItemCode,
                "@BudgetSubItemCode",iNInwardOutwardDetailParallelEntity.BudgetSubItemCode,
                "@BudgetDetailItemCode",iNInwardOutwardDetailParallelEntity.BudgetDetailItemCode,
                "@MethodDistributeID",iNInwardOutwardDetailParallelEntity.MethodDistributeId,
                "@CashWithdrawTypeID",iNInwardOutwardDetailParallelEntity.CashWithdrawTypeId,
                "@AccountingObjectID",iNInwardOutwardDetailParallelEntity.AccountingObjectId,
                "@ActivityID",iNInwardOutwardDetailParallelEntity.ActivityId,
                "@ProjectID",iNInwardOutwardDetailParallelEntity.ProjectId,
                "@TaskID",iNInwardOutwardDetailParallelEntity.TaskId,
                "@ListItemID",iNInwardOutwardDetailParallelEntity.ListItemId,
                "@Approved",iNInwardOutwardDetailParallelEntity.Approved,
                "@SortOrder",iNInwardOutwardDetailParallelEntity.SortOrder,
                "@OrgRefNo",iNInwardOutwardDetailParallelEntity.OrgRefNo,
                "@OrgRefDate",iNInwardOutwardDetailParallelEntity.OrgRefDate,
                "@FundStructureID",iNInwardOutwardDetailParallelEntity.FundStructureId,
                "@BankID",iNInwardOutwardDetailParallelEntity.BankId,
                "@BudgetExpenseID",iNInwardOutwardDetailParallelEntity.BudgetExpenseId,
                "@BudgetProvideCode",iNInwardOutwardDetailParallelEntity.BudgetProvideCode,
                "@ContractID", iNInwardOutwardDetailParallelEntity.ContractId,
                "@CapitalPlanID", iNInwardOutwardDetailParallelEntity.CapitalPlanId,
                "@AutoBusinessID", iNInwardOutwardDetailParallelEntity.AutoBusinessId,
                "@Quantity",iNInwardOutwardDetailParallelEntity.Quantity,
                "@UnitPrice",iNInwardOutwardDetailParallelEntity.UnitPrice,
                "@InventoryItemId",iNInwardOutwardDetailParallelEntity.InventoryItemId,
            };
        }
    }

}
