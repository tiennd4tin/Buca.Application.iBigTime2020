using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    /// <summary>
    /// Class SqlServerBUPlanWithdrawDetailDao.
    /// </summary>
    public class SqlServerBUPlanWithdrawDetailDao : IBUPlanWithdrawDetailDao
    {
        /// <summary>
        /// Gets the bu plan withdraw details by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUPlanWithdrawDetailEntity&gt;.</returns>
        public List<BUPlanWithdrawDetailEntity> GetBUPlanWithdrawDetailsByRefId(string refId)
        {
            const string procedures = @"uspGet_BUPlanWithdrawDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the bu plan withdraw detail.
        /// </summary>
        /// <param name="planWithdrawDetailEntity">The plan withdraw detail entity.</param>
        /// <returns>System.String.</returns>
        public string InsertBUPlanWithdrawDetail(BUPlanWithdrawDetailEntity planWithdrawDetailEntity)
        {
            const string procedures = @"uspInsert_BUPlanWithdrawDetail";
            return Db.Insert(procedures, true, Take(planWithdrawDetailEntity));
        }

        /// <summary>
        /// Deletes the bu plan withdraw detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string DeleteBUPlanWithdrawDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_BUPlanWithdrawDetail_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUPlanWithdrawDetailEntity> Make = reader =>
           new BUPlanWithdrawDetailEntity
           {
               RefDetailId = reader["RefDetailID"].AsString(),
               RefId = reader["RefID"].AsString(),
               Description = reader["Description"].AsString(),
               BudgetSourceId = reader["BudgetSourceID"].AsString(),
               BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
               BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
               BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
               BudgetItemCode = reader["BudgetItemCode"].AsString(),
               BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
               CreditAccount = reader["CreditAccount"].AsString(),
               Amount = reader["Amount"].AsDecimal(),
               AmountOC = reader["AmountOC"].AsDecimal(),
               ProjectId = reader["ProjectID"].AsString(),
               ListItemId = reader["ListItemID"].AsString(),
               SortOrder = reader["SortOrder"].AsInt(),
               BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
               OrgRefNo = reader["OrgRefNo"].AsString(),
               OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
               FundStructureId = reader["FundStructureID"].AsString(),
               BankId = reader["BankID"].AsString(),
               ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
               BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
               BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
           };

        /// <summary>
        /// Takes the specified information.
        /// </summary>
        /// <param name="bUPlanWithdrawDetailEntity">The b u plan withdraw detail entity.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(BUPlanWithdrawDetailEntity bUPlanWithdrawDetailEntity)
        {
            return new object[]
            {
                "@RefDetailID",bUPlanWithdrawDetailEntity.RefDetailId,
                "@RefID",bUPlanWithdrawDetailEntity.RefId,
                "@Description",bUPlanWithdrawDetailEntity.Description,
                "@BudgetSourceID",bUPlanWithdrawDetailEntity.BudgetSourceId,
                "@BudgetChapterCode",bUPlanWithdrawDetailEntity.BudgetChapterCode,
                "@BudgetKindItemCode",bUPlanWithdrawDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",bUPlanWithdrawDetailEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",bUPlanWithdrawDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode",bUPlanWithdrawDetailEntity.BudgetSubItemCode,
                "@CreditAccount",bUPlanWithdrawDetailEntity.CreditAccount,
                "@Amount",bUPlanWithdrawDetailEntity.Amount,
                "@AmountOC",bUPlanWithdrawDetailEntity.AmountOC,
                "@ProjectID",bUPlanWithdrawDetailEntity.ProjectId,
                "@ListItemID",bUPlanWithdrawDetailEntity.ListItemId,
                "@SortOrder",bUPlanWithdrawDetailEntity.SortOrder,
                "@BudgetDetailItemCode",bUPlanWithdrawDetailEntity.BudgetDetailItemCode,
                "@OrgRefNo",bUPlanWithdrawDetailEntity.OrgRefNo,
                "@OrgRefDate",bUPlanWithdrawDetailEntity.OrgRefDate,
                "@FundStructureID",bUPlanWithdrawDetailEntity.FundStructureId,
                "@BankID",bUPlanWithdrawDetailEntity.BankId,
                "@ProjectActivityEAID",bUPlanWithdrawDetailEntity.ProjectActivityEAId,
                "@BudgetProvideCode",bUPlanWithdrawDetailEntity.BudgetProvideCode,
                "@BudgetExpenseID",bUPlanWithdrawDetailEntity.BudgetExpenseId
            };
        }
    }
}
