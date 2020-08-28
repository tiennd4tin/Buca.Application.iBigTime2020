using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    public class SqlServerBUPlanAdjustmentDetailDao : IBUPlanAdjustmentDetailDao
    {
        public string DeleteBUPlanAdjustmentDetail(string refId)
        {
            const string procedures = @"uspDelete_BUPlanAdjustmentDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        public List<BUPlanAdjustmentDetailEntity> GetBUPlanAdjustmentDetailbyRefId(string refId)
        {
            const string procedures = @"uspGet_BUPlanAdjustmentDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public string InsertBUPlanAdjustmentDetail(BUPlanAdjustmentDetailEntity buPlanAdjustmentDetail)
        {
            const string procedures = @"uspInsert_BUPlanAdjustmentDetail";
            return Db.Insert(procedures, true, Take(buPlanAdjustmentDetail));
        }
         
        private static object[] Take(BUPlanAdjustmentDetailEntity bUPlanAdjustmentDetailEntity)
        {
            return new object[]
            {

                "@RefDetailID", bUPlanAdjustmentDetailEntity.RefDetailId,
                "@RefID", bUPlanAdjustmentDetailEntity.RefId,
                "@ItemName", bUPlanAdjustmentDetailEntity.ItemName,
                "@BudgetSourceID", bUPlanAdjustmentDetailEntity.BudgetSourceId,
                "@BudgetChapterCode", bUPlanAdjustmentDetailEntity.BudgetChapterCode,
                "@BudgetKindItemCode", bUPlanAdjustmentDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", bUPlanAdjustmentDetailEntity.BudgetSubKindItemCode,
                "@BudgetGroupItemCode", bUPlanAdjustmentDetailEntity.BudgetGroupItemCode,
                "@BudgetItemCode", bUPlanAdjustmentDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode", bUPlanAdjustmentDetailEntity.BudgetSubItemCode,
                "@DebitAccount", bUPlanAdjustmentDetailEntity.DebitAccount,
                "@AdjustmentAmount", bUPlanAdjustmentDetailEntity.AdjustmentAmount,
                "@ProjectID", bUPlanAdjustmentDetailEntity.ProjectId,
                "@ListItemID", bUPlanAdjustmentDetailEntity.ListItemId,
                "@SortOrder", bUPlanAdjustmentDetailEntity.SortOrder,
                "@TaskID", bUPlanAdjustmentDetailEntity.TaskId,
                "@BudgetDetailItemCode", bUPlanAdjustmentDetailEntity.BudgetDetailItemCode,
                "@FundStructureID", bUPlanAdjustmentDetailEntity.FundStructureId,
                "@BankAccount", bUPlanAdjustmentDetailEntity.BankAccount,
                "@ProjectExpenseEAID", bUPlanAdjustmentDetailEntity.ProjectExpenseEAID,
                "@ProjectActivityEAID", bUPlanAdjustmentDetailEntity.ProjectActivityEAID,
                "@BudgetProvideCode", bUPlanAdjustmentDetailEntity.BudgetProvideCode,
                "@ContractID", bUPlanAdjustmentDetailEntity.ContractId,
                "@CapitalPlanID", bUPlanAdjustmentDetailEntity.CapitalPlanId,
                "@MethodDistributeId", bUPlanAdjustmentDetailEntity.MethodDistributeId,
                "@ActivityID", bUPlanAdjustmentDetailEntity.ActivityId,
                "@Amount",bUPlanAdjustmentDetailEntity.Amount
            };
        }

        private static readonly Func<IDataReader, BUPlanAdjustmentDetailEntity> Make = reader =>
   new BUPlanAdjustmentDetailEntity
   {
       RefDetailId = reader["RefDetailID"].AsString(),
       RefId = reader["RefID"].AsString(),
       ItemName = reader["ItemName"].AsString(),
       BudgetSourceId = reader["BudgetSourceID"].AsString(),
       BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
       BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
       BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
       BudgetGroupItemCode = reader["BudgetGroupItemCode"].AsString(),
       BudgetItemCode = reader["BudgetItemCode"].AsString(),
       BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
       DebitAccount = reader["DebitAccount"].AsString(),
       AdjustmentAmount = reader["AdjustmentAmount"].AsDecimal(),
       ProjectId = reader["ProjectID"].AsString(),
       ListItemId = reader["ListItemID"].AsString(),
       SortOrder = reader["SortOrder"].AsInt(),
       TaskId = reader["TaskID"].AsString(),
       BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
       FundStructureId = reader["FundStructureID"].AsString(),
       BankAccount = reader["BankAccount"].AsString(),
       ProjectExpenseEAID = reader["ProjectExpenseEAID"].AsString(),
       ProjectActivityEAID = reader["ProjectActivityEAID"].AsString(),
       BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
       ContractId = reader["ContractID"].AsString(),
       CapitalPlanId = reader["CapitalPlanID"].AsString(),
       MethodDistributeId = reader["MethodDistributeId"].AsString(),
       ActivityId = reader["ActivityID"].AsString(),
       Amount=reader["Amount"].AsDecimal()
   };


    }
}
