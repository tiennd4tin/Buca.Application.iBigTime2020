using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit
{
    public class SqlServerBAWithDrawDetailDao:IBAWithDrawDetailDao
    {
        private static readonly Func<IDataReader, BAWithDrawDetailEntity> Make = reader =>
            new BAWithDrawDetailEntity
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
                MethodDistributeId = reader["MethodDistributeID"].AsInt(),
                CashWithDrawTypeId = reader["CashWithDrawTypeID"].AsInt(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                ActivityId = reader["ActivityID"].AsString(),
                ProjectId = reader["ProjectID"].AsString(),
                ProjectActivityId = reader["ProjectActivityID"].AsString(),
                FundId = reader["FundID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                OrgRefNo = reader["OrgRefNo"].AsString(),
                OrgRefDate = reader["OrgRefDate"].AsDateTime(),
                FundStructureId = reader["FundStructureID"].AsString(),
                ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
                BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
                BankId = reader["BankID"].AsString(),
                ProjectCode = reader["ProjectCode"].AsString(),
                ContractId = reader["ContractID"].AsString(),
                CapitalPlanId = reader["CapitalPlanID"].AsString(),
                AutoBusinessId = reader["AutoBusinessID"].AsString()
            };

        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<BAWithDrawDetailEntity> GetBAWithDrawDetailEntitysByRefId(string refId)
        {
            const string procedures = @"uspGet_BAWithDrawDetail_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bAWithDrawDetail">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertBAWithDrawDetailEntity(BAWithDrawDetailEntity bAWithDrawDetail)
        {
            const string sql = @"uspInsert_BAWithDrawDetail";
            return Db.Insert(sql, true, Take(bAWithDrawDetail));
        }

        public string DeleteBAWithDrawDetailEntityByRefId(string refId)
        {
            const string procedures = @"uspDelete_BAWithDrawDetail_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified bADeposit.
        /// </summary>
        /// <param name="bAWithDrawDetail">The bADeposit.</param>
        /// <returns></returns>
        private object[] Take(BAWithDrawDetailEntity bAWithDrawDetailEntity)
        {
            return new object[]
            {
                "@RefDetailID",bAWithDrawDetailEntity.RefDetailId,
                "@RefID",bAWithDrawDetailEntity.RefId,
                "@Description",bAWithDrawDetailEntity.Description,
                "@DebitAccount",bAWithDrawDetailEntity.DebitAccount,
                "@CreditAccount",bAWithDrawDetailEntity.CreditAccount,
                "@Amount",bAWithDrawDetailEntity.Amount,
                "@AmountOC",bAWithDrawDetailEntity.AmountOC,
                "@BudgetSourceID",bAWithDrawDetailEntity.BudgetSourceId,
                "@BudgetChapterCode",bAWithDrawDetailEntity.BudgetChapterCode,
                "@BudgetKindItemCode",bAWithDrawDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",bAWithDrawDetailEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",bAWithDrawDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode",bAWithDrawDetailEntity.BudgetSubItemCode,
                "@MethodDistributeID",bAWithDrawDetailEntity.MethodDistributeId,
                "@CashWithDrawTypeID",bAWithDrawDetailEntity.CashWithDrawTypeId,
                "@AccountingObjectID",bAWithDrawDetailEntity.AccountingObjectId,
                "@ActivityID",bAWithDrawDetailEntity.ActivityId,
                "@ProjectID",bAWithDrawDetailEntity.ProjectId,
                "@ProjectActivityID",bAWithDrawDetailEntity.ProjectActivityId,
                "@FundID",bAWithDrawDetailEntity.FundId,
                "@ListItemID",bAWithDrawDetailEntity.ListItemId,
                "@SortOrder",bAWithDrawDetailEntity.SortOrder,
                "@BudgetDetailItemCode",bAWithDrawDetailEntity.BudgetDetailItemCode,
                "@OrgRefNo",bAWithDrawDetailEntity.OrgRefNo,
                "@OrgRefDate",bAWithDrawDetailEntity.OrgRefDate,
                "@FundStructureID",bAWithDrawDetailEntity.FundStructureId,
                "@ProjectActivityEAID",bAWithDrawDetailEntity.ProjectActivityEAId,
                "@BudgetExpenseID",bAWithDrawDetailEntity.BudgetExpenseId,
                "@BankID",bAWithDrawDetailEntity.BankId,
                "@ContractID", bAWithDrawDetailEntity.ContractId,
                "@CapitalPlanID", bAWithDrawDetailEntity.CapitalPlanId,
                "@AutoBusinessID", bAWithDrawDetailEntity.AutoBusinessId
            };
        }
    }
}