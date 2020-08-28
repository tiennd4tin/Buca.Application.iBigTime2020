using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Cash
{

    public class SqlServerCAPaymentDetailDao : ICAPaymentDetailDao
    {
        public string DeleteCAPaymentDetailId(string refId)
        {
            const string procedures = @"uspDelete_CAPaymentDetail_ByRefID";
            object[] parms = {"@RefId", refId};
            return Db.Delete(procedures, true, parms);
        }

        public List<CAPaymentDetailEntity> GetCaPaymentDetailbyRefId(string refId)
        {
            const string procedures = @"uspGet_CAPaymentDetail_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }
        
        public string InsertCAPaymentDetail(CAPaymentDetailEntity caPaymentDetail)
        {
            const string procedures = @"uspInsert_CAPaymentDetail";
            return Db.Insert(procedures, true, Take(caPaymentDetail));
        }
        public string UpdateCAPaymentDetail(CAPaymentDetailEntity caPaymentDetail)
        {
            const string procedures = @"uspUpdate_CAPaymentDetail";
            return Db.Update(procedures, true, Take(caPaymentDetail));
        }
        private static readonly Func<IDataReader, CAPaymentDetailEntity> Make = reader =>
       new CAPaymentDetailEntity
       {
           RefDetailId = reader["RefDetailId"].AsString(),
           RefId = reader["RefId"].AsString(),
           Description = reader["Description"].AsString(),
           DebitAccount = reader["DebitAccount"].AsString(),
           CreditAccount = reader["CreditAccount"].AsString(),
           Amount = reader["Amount"].AsDecimal(),
           AmountOC = reader["AmountOC"].AsDecimal(),
           BudgetSourceId = reader["BudgetSourceId"].AsString(),
           BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
           BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
           BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
           BudgetItemCode = reader["BudgetItemCode"].AsString(),
           BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
           MethodDistributeId = reader["MethodDistributeId"].AsInt(),
           CashWithDrawTypeId = reader["CashWithDrawTypeId"].AsInt(),
           AccountingObjectId = reader["AccountingObjectId"].AsString(),
           ActivityId = reader["ActivityId"].AsString(),
           ProjectId = reader["ProjectId"].AsString(),
           ProjectActivityId = reader["ProjectActivityId"].AsString(),
           ListItemId = reader["ListItemId"].AsString(),
           Approved = reader["Approved"].AsBool(),
           SortOrder = reader["SortOrder"].AsInt(),
           BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
           OrgRefNo = reader["OrgRefNo"].AsString(),
           OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
           FundStructureId = reader["FundStructureId"].AsString(),
           BankId = reader["BankId"].AsString(),
           ProjectExpenseEAId = reader["ProjectExpenseEAId"].AsString(),
           ProjectActivityEAId = reader["ProjectActivityEAId"].AsString(),
           BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
           ContractId = reader["ContractID"].AsString(),
           CapitalPlanId = reader["CapitalPlanID"].AsString(),
           AutoBusinessId = reader["AutoBusinessID"].AsString()
       };


        private static object[] Take(CAPaymentDetailEntity cAPaymentDetailEntity)
        {
            return new object[]
            {

                "@RefDetailId", cAPaymentDetailEntity.RefDetailId,
                "@RefId", cAPaymentDetailEntity.RefId,
                "@Description", cAPaymentDetailEntity.Description,
                "@DebitAccount", cAPaymentDetailEntity.DebitAccount,
                "@CreditAccount", cAPaymentDetailEntity.CreditAccount,
                "@Amount", cAPaymentDetailEntity.Amount,
                "@AmountOC", cAPaymentDetailEntity.AmountOC,
                "@BudgetSourceId", cAPaymentDetailEntity.BudgetSourceId,
                "@BudgetChapterCode", cAPaymentDetailEntity.BudgetChapterCode,
                "@BudgetKindItemCode", cAPaymentDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", cAPaymentDetailEntity.BudgetSubKindItemCode,
                "@BudgetItemCode", cAPaymentDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode", cAPaymentDetailEntity.BudgetSubItemCode,
                "@MethodDistributeId", cAPaymentDetailEntity.MethodDistributeId,
                "@CashWithDrawTypeId", cAPaymentDetailEntity.CashWithDrawTypeId,
                "@AccountingObjectId", cAPaymentDetailEntity.AccountingObjectId,
                "@ActivityId", cAPaymentDetailEntity.ActivityId,
                "@ProjectId", cAPaymentDetailEntity.ProjectId,
                "@ProjectActivityId", cAPaymentDetailEntity.ProjectActivityId,
                "@ListItemId", cAPaymentDetailEntity.ListItemId,
                "@Approved", cAPaymentDetailEntity.Approved,
                "@SortOrder", cAPaymentDetailEntity.SortOrder,
                "@BudgetDetailItemCode", cAPaymentDetailEntity.BudgetDetailItemCode,
                "@OrgRefNo", cAPaymentDetailEntity.OrgRefNo,
                "@OrgRefDate", cAPaymentDetailEntity.OrgRefDate,
                "@FundStructureId", cAPaymentDetailEntity.FundStructureId,
                "@BankId", cAPaymentDetailEntity.BankId,
                "@ProjectExpenseEAId", cAPaymentDetailEntity.ProjectExpenseEAId,
                "@ProjectActivityEAId", cAPaymentDetailEntity.ProjectActivityEAId,
                "@BudgetExpenseID", cAPaymentDetailEntity.BudgetExpenseId,
                "@ContractID", cAPaymentDetailEntity.ContractId,
                "@CapitalPlanID", cAPaymentDetailEntity.CapitalPlanId,
                 "@AutoBusinessID", cAPaymentDetailEntity.AutoBusinessId,
            };
        }

      
    }

}