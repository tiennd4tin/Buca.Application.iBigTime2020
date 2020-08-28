using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit
{
    public class SqlServerBABankTransferDetailDao : IBABankTransferDetailDao
    {
        private static object[] Take(BABankTransferDetailEntity bABankTransferDetailEntity)
        {
                return new object[]
                {

            "@RefDetailID",bABankTransferDetailEntity.RefDetailId,
            "@RefID",bABankTransferDetailEntity.RefId,
            "@Description",bABankTransferDetailEntity.Description,
            "@DebitAccount",bABankTransferDetailEntity.DebitAccount,
            "@CreditAccount",bABankTransferDetailEntity.CreditAccount,
            "@FromBankID",bABankTransferDetailEntity.FromBankId,
            "@ToBankID",bABankTransferDetailEntity.ToBankId,
            "@Amount",bABankTransferDetailEntity.Amount,
            "@BudgetSourceID",bABankTransferDetailEntity.BudgetSourceId,
            "@BudgetChapterCode",bABankTransferDetailEntity.BudgetChapterCode,
            "@BudgetKindItemCode",bABankTransferDetailEntity.BudgetKindItemCode,
            "@BudgetSubKindItemCode",bABankTransferDetailEntity.BudgetSubKindItemCode,
            "@BudgetItemCode",bABankTransferDetailEntity.BudgetItemCode,
            "@BudgetSubItemCode",bABankTransferDetailEntity.BudgetSubItemCode,
            "@MethodDistributeID",bABankTransferDetailEntity.MethodDistributeId,
            "@CashWithDrawTypeID",bABankTransferDetailEntity.CashWithDrawTypeId,
            "@AccountingObjectID",bABankTransferDetailEntity.AccountingObjectId,
            "@ActivityID",bABankTransferDetailEntity.ActivityId,
            "@ProjectID",bABankTransferDetailEntity.ProjectId,
            "@ProjectActivityID",bABankTransferDetailEntity.ProjectActivityId,
            "@ListItemID",bABankTransferDetailEntity.ListItemId,
            "@SortOrder",bABankTransferDetailEntity.SortOrder,
            "@BudgetDetailItemCode",bABankTransferDetailEntity.BudgetDetailItemCode,
            "@AmountOC",bABankTransferDetailEntity.AmountOC,
            "@FundStructureID",bABankTransferDetailEntity.FundStructureId,
            "@ProjectActivityEAID",bABankTransferDetailEntity.ProjectActivityEAId,
            "@BudgetExpenseID",bABankTransferDetailEntity.BudgetExpenseId,
                };

        }
        private static readonly Func<IDataReader, BABankTransferDetailEntity> Make = reader =>
           new BABankTransferDetailEntity
           {
               RefDetailId = reader["RefDetailID"].AsString(),
               RefId = reader["RefID"].AsString(),
               Description = reader["Description"].AsString(),
               DebitAccount = reader["DebitAccount"].AsString(),
               CreditAccount = reader["CreditAccount"].AsString(),
               FromBankId = reader["FromBankID"].AsString(),
               ToBankId = reader["ToBankID"].AsString(),
               Amount = reader["Amount"].AsDecimal(),
               BudgetSourceId = reader["BudgetSourceID"].AsString(),
               BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
               BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
               BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
               BudgetItemCode = reader["BudgetItemCode"].AsString(),
               BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
               MethodDistributeId = reader["MethodDistributeID"].AsInt(),
               CashWithDrawTypeId = reader["CashWithDrawTypeID"].AsInt(),
               AccountingObjectId = reader["AccountingObjectID"].AsString(),
               ActivityId = reader["ActivityID"].AsString(),
               ProjectId = reader["ProjectID"].AsString(),
               ProjectActivityId = reader["ProjectActivityID"].AsString(),
               ListItemId = reader["ListItemID"].AsString(),
               SortOrder = reader["SortOrder"].AsInt(),
               BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
               AmountOC = reader["AmountOC"].AsDecimal(),
               FundStructureId = reader["FundStructureID"].AsString(),
               ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
               BudgetExpenseId = reader["BudgetExpenseID"].AsString(),

           };

        public IList<BABankTransferDetailEntity> GetBABankTransferDetailsByRefId(string refId)
        {
            const string procedures = @"uspGet_BABankTransferDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }
        public string InsertBABankTransferDetail(BABankTransferDetailEntity bABankTransferDetailEntity)
        {
            const string sql = @"uspInsert_BABankTransferDetail";
            return Db.Insert(sql, true, Take(bABankTransferDetailEntity));
        }
        public string DeleteBABankTransferDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_BABankTransferDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }
    }
}
