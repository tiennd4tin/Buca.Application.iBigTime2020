using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.IncrementDecrement
{
    public class SqlServerFAAdjustmentDetailParallelDao : IFAAdjustmentDetailParallelDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, FAAdjustmentDetailParallelEntity> Make = reader =>
     new FAAdjustmentDetailParallelEntity
     {
         RefDetailId = reader["RefDetailID"].AsString(),
         ParentRefDetailId = reader["ParentRefDetailID"].AsString(),
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
         FundId = reader["FundID"].AsString(),
         TaskId = reader["TaskID"].AsString(),
         ListItemId = reader["ListItemID"].AsString(),
         SortOrder = reader["SortOrder"].AsInt(),
         OrgRefNo = reader["OrgRefNo"].AsString(),
         OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
         FundStructureId = reader["FundStructureID"].AsString(),
         BankId = reader["BankID"].AsString(),
         BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
         TopicId = reader["TopicID"].AsString(),
         BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
         Approved = reader["Approved"].AsBool(),
         ContractId = reader["ContractID"].AsString(),
         CapitalPlanId = reader["CapitalPlanID"].AsString(),
     };

        //public FAIncrementDecrementEntity GetFAIncrementDecrementByRefNo(string refNo)
        //{
        //    const string procedures = @"uspGet_FAIncrementDecrement_ByRefNo";
        //    object[] parms = {"@RefNo", refNo};
        //    return Db.Read(procedures, true, Make, parms);
        //}

        private static object[] Take(FAAdjustmentDetailParallelEntity fAAdjustmentEntity)
        {
            return new object[]
            {
                "@RefDetailID",fAAdjustmentEntity.RefDetailId,
                "@ParentRefDetailID",fAAdjustmentEntity.ParentRefDetailId,
                "@RefID",fAAdjustmentEntity.RefId,
                "@Description",fAAdjustmentEntity.Description,
                "@DebitAccount",fAAdjustmentEntity.DebitAccount,
                "@CreditAccount",fAAdjustmentEntity.CreditAccount,
                "@Amount",fAAdjustmentEntity.Amount,
                "@AmountOC",fAAdjustmentEntity.AmountOC,
                "@BudgetSourceID",fAAdjustmentEntity.BudgetSourceId,
                "@BudgetChapterCode",fAAdjustmentEntity.BudgetChapterCode,
                "@BudgetKindItemCode",fAAdjustmentEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",fAAdjustmentEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",fAAdjustmentEntity.BudgetItemCode,
                "@BudgetSubItemCode",fAAdjustmentEntity.BudgetSubItemCode,
                "@BudgetDetailItemCode",fAAdjustmentEntity.BudgetDetailItemCode,
                "@MethodDistributeID",fAAdjustmentEntity.MethodDistributeId,
                "@CashWithdrawTypeID",fAAdjustmentEntity.CashWithdrawTypeId,
                "@AccountingObjectID",fAAdjustmentEntity.AccountingObjectId,
                "@ActivityID",fAAdjustmentEntity.ActivityId,
                "@ProjectID",fAAdjustmentEntity.ProjectId,
                "@FundID",fAAdjustmentEntity.FundId,
                "@TaskID",fAAdjustmentEntity.TaskId,
                "@ListItemID",fAAdjustmentEntity.ListItemId,
                "@SortOrder",fAAdjustmentEntity.SortOrder,
                "@OrgRefNo",fAAdjustmentEntity.OrgRefNo,
                "@OrgRefDate",fAAdjustmentEntity.OrgRefDate,
                "@FundStructureID",fAAdjustmentEntity.FundStructureId,
                "@BankID",fAAdjustmentEntity.BankId,
                "@BudgetProvideCode",fAAdjustmentEntity.BudgetProvideCode,
                "@TopicID",fAAdjustmentEntity.TopicId,
                "@BudgetExpenseID",fAAdjustmentEntity.BudgetExpenseId,
                "@Approved",fAAdjustmentEntity.Approved,
                "@ContractID", fAAdjustmentEntity.ContractId,
                "@CapitalPlanID", fAAdjustmentEntity.CapitalPlanId,
            };
        }

        public string InsertFAAdjustmentDetailParallel(FAAdjustmentDetailParallelEntity fAAdjustmentDetailParallelEntity)
        {
            const string sql = @"uspInsert_FAAdjustmentDetailParallel";
            return Db.Insert(sql, true, Take(fAAdjustmentDetailParallelEntity));
        }

        public string DeleteFAAdjustmentDetailParallelByRefId(string refId)
        {
            const string procedures = @"uspDelete_FAAdjustmentDetailParallel_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        public List<FAAdjustmentDetailParallelEntity> GetFAAdjustmentDetailParallelsByRefId(string refId)
        {
            const string procedures = @"uspGet_FAAdjustmentDetailParallel_ByRefId";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

    }
}
