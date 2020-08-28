using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    public class SqlServerBUPlanReceipDetailDao : IBUPlanReceiptDetailDao
    {
        public string DeleteBUPlanReceiptDetail(string refId)
        {
            const string procedures = @"uspDelete_BUPlanReceiptDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        public List<BUPlanReceiptDetailEntity> GetBUPlanReceiptDetailbyRefId(string refId)
        {
            const string procedures = @"uspGet_BUPlanReceiptDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms); 
        }

        public string InsertBUPlanReceiptDetail(BUPlanReceiptDetailEntity buPlanReceiptDetail)
        {
            const string procedures = @"uspInsert_BUPlanReceiptDetail";
            return Db.Insert(procedures, true, Take(buPlanReceiptDetail));   
        }



        private static readonly Func<IDataReader, BUPlanReceiptDetailEntity> Make = reader =>
                 new BUPlanReceiptDetailEntity
                 {
                     RefDetailId = reader["RefDetailID"].AsString(),
                     RefId = reader["RefID"].AsString(),
                     Description = reader["Description"].AsString(),
                     BudgetSourceId = reader["BudgetSourceID"].AsString(),
                     ActivityId = reader["ActivityID"].AsString(),
                     BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                     BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                     BudgetGroupItemCode = reader["BudgetGroupItemCode"].AsString(),
                     BudgetParentItemCode = reader["BudgetParentItemCode"].AsString(),
                     BudgetItemCode = reader["BudgetItemCode"].AsString(),
                     BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
                     DebitAccount = reader["DebitAccount"].AsString(),
                     Amount = reader["Amount"].AsDecimal(),
                     AmountOC = reader["AmountOC"].AsDecimal(),
                     ProjectId = reader["ProjectID"].AsString(),
                     ListItemId = reader["ListItemID"].AsString(),
                     SortOrder = reader["SortOrder"].AsInt(),
                     BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                     FundStructureId = reader["FundStructureID"].AsString(),
                     BankId = reader["BankID"].AsString(),
                     ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
                     AmountQuater1 = reader["AmountQuater1"].AsDecimal(),
                     AmountQuater1OC = reader["AmountQuater1OC"].AsDecimal(),
                     AmountQuater2 = reader["AmountQuater2"].AsDecimal(),
                     AmountQuater2OC = reader["AmountQuater2OC"].AsDecimal(),
                     AmountQuater3 = reader["AmountQuater3"].AsDecimal(),
                     AmountQuater3OC = reader["AmountQuater3OC"].AsDecimal(),
                     AmountQuater4 = reader["AmountQuater4"].AsDecimal(),
                     AmountQuater4OC = reader["AmountQuater4OC"].AsDecimal(),
                     AmountMonth1 = reader["AmountMonth1"].AsDecimal(),
                     AmountMonth1OC = reader["AmountMonth1OC"].AsDecimal(),
                     AmountMonth2 = reader["AmountMonth2"].AsDecimal(),
                     AmountMonth2OC = reader["AmountMonth2OC"].AsDecimal(),
                     AmountMonth3 = reader["AmountMonth3"].AsDecimal(),
                     AmountMonth3OC = reader["AmountMonth3OC"].AsDecimal(),
                     AmountMonth4 = reader["AmountMonth4"].AsDecimal(),
                     AmountMonth4OC = reader["AmountMonth4OC"].AsDecimal(),
                     AmountMonth5 = reader["AmountMonth5"].AsDecimal(),
                     AmountMonth5OC = reader["AmountMonth5OC"].AsDecimal(),
                     AmountMonth6 = reader["AmountMonth6"].AsDecimal(),
                     AmountMonth6OC = reader["AmountMonth6OC"].AsDecimal(),
                     AmountMonth7 = reader["AmountMonth7"].AsDecimal(),
                     AmountMonth7OC = reader["AmountMonth7OC"].AsDecimal(),
                     AmountMonth8 = reader["AmountMonth8"].AsDecimal(),
                     AmountMonth8OC = reader["AmountMonth8OC"].AsDecimal(),
                     AmountMonth9 = reader["AmountMonth9"].AsDecimal(),
                     AmountMonth9OC = reader["AmountMonth9OC"].AsDecimal(),
                     AmountMonth10 = reader["AmountMonth10"].AsDecimal(),
                     AmountMonth10OC = reader["AmountMonth10OC"].AsDecimal(),
                     AmountMonth11 = reader["AmountMonth11"].AsDecimal(),
                     AmountMonth11OC = reader["AmountMonth11OC"].AsDecimal(),
                     AmountMonth12 = reader["AmountMonth12"].AsDecimal(),
                     AmountMonth12OC = reader["AmountMonth12OC"].AsDecimal(),
                     BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
                     MethodDistributeId = reader["MethodDistributeID"].AsInt()      ,
                     ContractId = reader["ContractID"].AsString(),
                     CapitalPlanId = reader["CapitalPlanID"].AsString(),
                     BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                     //RefDate = reader["BudgetChapterCode"].AsString()
                 };



        private static object[] Take(BUPlanReceiptDetailEntity bUPlanReceiptDetailEntity)
        {
            return new object[]
            {

                "@RefDetailID", bUPlanReceiptDetailEntity.RefDetailId,
                "@RefID", bUPlanReceiptDetailEntity.RefId,
                "@Description", bUPlanReceiptDetailEntity.Description,
                "@BudgetSourceID", bUPlanReceiptDetailEntity.BudgetSourceId,
                "@BudgetKindItemCode", bUPlanReceiptDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", bUPlanReceiptDetailEntity.BudgetSubKindItemCode,
                "@BudgetGroupItemCode", bUPlanReceiptDetailEntity.BudgetGroupItemCode,
                "@BudgetParentItemCode", bUPlanReceiptDetailEntity.BudgetParentItemCode,
                "@BudgetItemCode", bUPlanReceiptDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode", bUPlanReceiptDetailEntity.BudgetSubItemCode,
                "@DebitAccount", bUPlanReceiptDetailEntity.DebitAccount,
                "@Amount", bUPlanReceiptDetailEntity.Amount,
                "@AmountOC", bUPlanReceiptDetailEntity.AmountOC,
                "@ProjectID", bUPlanReceiptDetailEntity.ProjectId,
                "@ListItemID", bUPlanReceiptDetailEntity.ListItemId,
                "@SortOrder", bUPlanReceiptDetailEntity.SortOrder,
                "@BudgetDetailItemCode", bUPlanReceiptDetailEntity.BudgetDetailItemCode,
                "@FundStructureID", bUPlanReceiptDetailEntity.FundStructureId,
                "@BankID", bUPlanReceiptDetailEntity.BankId,
                "@ProjectActivityEAID", bUPlanReceiptDetailEntity.ProjectActivityEAId,
                "@AmountQuater1", bUPlanReceiptDetailEntity.AmountQuater1,
                "@AmountQuater1OC", bUPlanReceiptDetailEntity.AmountQuater1OC,
                "@AmountQuater2", bUPlanReceiptDetailEntity.AmountQuater2,
                "@AmountQuater2OC", bUPlanReceiptDetailEntity.AmountQuater2OC,
                "@AmountQuater3", bUPlanReceiptDetailEntity.AmountQuater3,
                "@AmountQuater3OC", bUPlanReceiptDetailEntity.AmountQuater3OC,
                "@AmountQuater4", bUPlanReceiptDetailEntity.AmountQuater4,
                "@AmountQuater4OC", bUPlanReceiptDetailEntity.AmountQuater4OC,
                "@AmountMonth1", bUPlanReceiptDetailEntity.AmountMonth1,
                "@AmountMonth1OC", bUPlanReceiptDetailEntity.AmountMonth1OC,
                "@AmountMonth2", bUPlanReceiptDetailEntity.AmountMonth2,
                "@AmountMonth2OC", bUPlanReceiptDetailEntity.AmountMonth2OC,
                "@AmountMonth3", bUPlanReceiptDetailEntity.AmountMonth3,
                "@AmountMonth3OC", bUPlanReceiptDetailEntity.AmountMonth3OC,
                "@AmountMonth4", bUPlanReceiptDetailEntity.AmountMonth4,
                "@AmountMonth4OC", bUPlanReceiptDetailEntity.AmountMonth4OC,
                "@AmountMonth5", bUPlanReceiptDetailEntity.AmountMonth5,
                "@AmountMonth5OC", bUPlanReceiptDetailEntity.AmountMonth5OC,
                "@AmountMonth6", bUPlanReceiptDetailEntity.AmountMonth6,
                "@AmountMonth6OC", bUPlanReceiptDetailEntity.AmountMonth6OC,
                "@AmountMonth7", bUPlanReceiptDetailEntity.AmountMonth7,
                "@AmountMonth7OC", bUPlanReceiptDetailEntity.AmountMonth7OC,
                "@AmountMonth8", bUPlanReceiptDetailEntity.AmountMonth8,
                "@AmountMonth8OC", bUPlanReceiptDetailEntity.AmountMonth8OC,
                "@AmountMonth9", bUPlanReceiptDetailEntity.AmountMonth9,
                "@AmountMonth9OC", bUPlanReceiptDetailEntity.AmountMonth9OC,
                "@AmountMonth10", bUPlanReceiptDetailEntity.AmountMonth10,
                "@AmountMonth10OC", bUPlanReceiptDetailEntity.AmountMonth10OC,
                "@AmountMonth11", bUPlanReceiptDetailEntity.AmountMonth11,
                "@AmountMonth11OC", bUPlanReceiptDetailEntity.AmountMonth11OC,
                "@AmountMonth12", bUPlanReceiptDetailEntity.AmountMonth12,
                "@AmountMonth12OC", bUPlanReceiptDetailEntity.AmountMonth12OC,
                "@BudgetProvideCode", bUPlanReceiptDetailEntity.BudgetProvideCode,
                "@MethodDistributeID", bUPlanReceiptDetailEntity.MethodDistributeId,
                "@ContractID", bUPlanReceiptDetailEntity.ContractId,
                "@CapitalPlanID", bUPlanReceiptDetailEntity.CapitalPlanId,
                "@BudgetChapterCode", bUPlanReceiptDetailEntity.BudgetChapterCode,
                "@ActivityID", bUPlanReceiptDetailEntity.ActivityId
                ,
            };

        }
    }
}