using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Cash
{

    public class SqlServerCAPaymentDetailParallelDao : ICAPaymentDetailParallelDao
    {
        /// <summary>
        /// Deletes the ca payment detail parallel identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteCAPaymentDetailParallelId(string refId)
        {
            const string procedures = @"uspDelete_CAPaymentDetailParallel_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the ca payment detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.Collections.Generic.List&lt;Buca.Application.iBigTime2020.BusinessEntities.Business.Cash.CAPaymentDetailParallelEntity&gt;.</returns>
        public List<CAPaymentDetailParallelEntity> GetCaPaymentDetailbyRefId(string refId)
        {
            const string procedures = @"uspGet_CAPaymentDetailParallel_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the ca payment detail parallel.
        /// </summary>
        /// <param name="caPaymentDetail">The ca payment detail.</param>
        /// <returns>System.String.</returns>
        public string InsertCAPaymentDetailParallel(CAPaymentDetailParallelEntity caPaymentDetail)
        {
            const string procedures = @"uspInsert_CAPaymentDetailParallel";
            return Db.Insert(procedures, true, Take(caPaymentDetail));
        }

        /// <summary>
        /// Updates the ca payment detail parallel.
        /// </summary>
        /// <param name="caPaymentDetail">The ca payment detail.</param>
        /// <returns>System.String.</returns>
        public string UpdateCAPaymentDetailParallel(CAPaymentDetailParallelEntity caPaymentDetail)
        {
            const string procedures = @"uspUpdate_CAPaymentDetailParallel";
            return Db.Update(procedures, true, Take(caPaymentDetail));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CAPaymentDetailParallelEntity> Make = reader =>
            new CAPaymentDetailParallelEntity
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
                Quantity = reader["Quantity"].AsDecimal(),
                UnitPrice = reader["UnitPrice"].AsDecimal(),
                FixedAssetId = reader["FixedAssetId"].AsString(),
            };

        /// <summary>
        /// Takes the specified c a payment detail parallel entity.
        /// </summary>
        /// <param name="cAPaymentDetailParallelEntity">The c a payment detail parallel entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(CAPaymentDetailParallelEntity cAPaymentDetailParallelEntity)
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
                    "@Quantity", cAPaymentDetailParallelEntity.Quantity,
                        "@UnitPrice", cAPaymentDetailParallelEntity.UnitPrice,
                            "@FixedAssetId", cAPaymentDetailParallelEntity.FixedAssetId,
            };
        }


    }

}