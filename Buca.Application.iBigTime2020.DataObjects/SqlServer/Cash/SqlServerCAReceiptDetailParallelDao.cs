using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Cash
{

    public class SqlServerCAReceiptDetailParallelDao : ICAReceiptDetailParallelDao
    {
        /// <summary>
        /// Deletes the ca payment detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteCAReceiptDetailParallelId(string refId)
        {
            const string procedures = @"uspDelete_CAReceiptDetailParallel_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the ca receipt detail parallelby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;CAReceiptDetailParallelEntity&gt;.</returns>
        public List<CAReceiptDetailParallelEntity> GetCAReceiptDetailParallelbyRefId(string refId)
        {
            const string procedures = @"uspGet_CAReceiptDetailParallel_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the ca payment detail parallel.
        /// </summary>
        /// <param name="receiptDetail">The ca payment detail.</param>
        /// <returns>System.String.</returns>
        public string InsertCAReceiptDetailParallel(CAReceiptDetailParallelEntity receiptDetail)
        {
            const string procedures = @"uspInsert_CAReceiptDetailParallel";
            return Db.Insert(procedures, true, Take(receiptDetail));
        }

        /// <summary>
        /// Updates the ca payment detail parallel.
        /// </summary>
        /// <param name="receiptDetail">The ca payment detail.</param>
        /// <returns>System.String.</returns>
        public string UpdateCAReceiptDetailParallel(CAReceiptDetailParallelEntity receiptDetail)
        {
            const string procedures = @"uspUpdate_CAReceiptDetailParallel";
            return Db.Update(procedures, true, Take(receiptDetail));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CAReceiptDetailParallelEntity> Make = reader =>
            new CAReceiptDetailParallelEntity
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
            };

        /// <summary>
        /// Takes the specified c a payment detail parallel entity.
        /// </summary>
        /// <param name="cAPaymentDetailParallelEntity">The c a payment detail parallel entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(CAReceiptDetailParallelEntity cAPaymentDetailParallelEntity)
        {
            return new object[]
            {
                "@RefDetailID",cAPaymentDetailParallelEntity.RefDetailId,
                "@RefID",cAPaymentDetailParallelEntity.RefId,
                "@Description",cAPaymentDetailParallelEntity.Description,
                "@DebitAccount",cAPaymentDetailParallelEntity.DebitAccount,
                "@CreditAccount",cAPaymentDetailParallelEntity.CreditAccount,
                "@Amount",cAPaymentDetailParallelEntity.Amount,
                "@AmountOC",cAPaymentDetailParallelEntity.AmountOC,
                "@BudgetSourceID",cAPaymentDetailParallelEntity.BudgetSourceId,
                "@BudgetChapterCode",cAPaymentDetailParallelEntity.BudgetChapterCode,
                "@BudgetKindItemCode",cAPaymentDetailParallelEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",cAPaymentDetailParallelEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",cAPaymentDetailParallelEntity.BudgetItemCode,
                "@BudgetSubItemCode",cAPaymentDetailParallelEntity.BudgetSubItemCode,
                "@BudgetDetailItemCode",cAPaymentDetailParallelEntity.BudgetDetailItemCode,
                "@MethodDistributeID",cAPaymentDetailParallelEntity.MethodDistributeId,
                "@CashWithdrawTypeID",cAPaymentDetailParallelEntity.CashWithdrawTypeId,
                "@AccountingObjectID",cAPaymentDetailParallelEntity.AccountingObjectId,
                "@ActivityID",cAPaymentDetailParallelEntity.ActivityId,
                "@ProjectID",cAPaymentDetailParallelEntity.ProjectId,
                "@TaskID",cAPaymentDetailParallelEntity.TaskId,
                "@ListItemID",cAPaymentDetailParallelEntity.ListItemId,
                "@Approved",cAPaymentDetailParallelEntity.Approved,
                "@SortOrder",cAPaymentDetailParallelEntity.SortOrder,
                "@OrgRefNo",cAPaymentDetailParallelEntity.OrgRefNo,
                "@OrgRefDate",cAPaymentDetailParallelEntity.OrgRefDate,
                "@FundStructureID",cAPaymentDetailParallelEntity.FundStructureId,
                "@BankID",cAPaymentDetailParallelEntity.BankId,
                "@BudgetExpenseID",cAPaymentDetailParallelEntity.BudgetExpenseId,
                "@BudgetProvideCode",cAPaymentDetailParallelEntity.BudgetProvideCode,
                "@ContractID", cAPaymentDetailParallelEntity.ContractId,
                "@CapitalPlanID", cAPaymentDetailParallelEntity.CapitalPlanId,
                "@AutoBusinessID", cAPaymentDetailParallelEntity.AutoBusinessId
            };
        }
    }

}