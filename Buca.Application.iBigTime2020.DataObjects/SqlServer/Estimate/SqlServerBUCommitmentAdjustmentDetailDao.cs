/***********************************************************************
 * <copyright file="SqlServerBUCommitmentAdjustmentDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, December 11, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    /// <summary>
    /// Class SqlServerBUCommitmentAdjustmentDetailDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate.IBUCommitmentAdjustmentDetailDao" />
    public class SqlServerBUCommitmentAdjustmentDetailDao : IBUCommitmentAdjustmentDetailDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUCommitmentAdjustmentDetailEntity> Make = reader =>
        new BUCommitmentAdjustmentDetailEntity
        {
            RefDetailId = reader["RefDetailId"].AsString(),
            RefId = reader["RefId"].AsString(),
            Description = reader["Description"].AsString(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            Amount = reader["Amount"].AsDecimal(),
            AmountOC = reader["AmountOC"].AsDecimal(),
            BudgetSourceId = reader["BudgetSourceId"].AsString(),
            BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
            BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
            BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
            BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
            MethodDistributeId = reader["MethodDistributeId"].AsInt(),
            CashWithDrawTypeId = reader["CashWithDrawTypeId"].AsInt(),
            ActivityId = reader["ActivityId"].AsString(),
            ProjectId = reader["ProjectId"].AsString(),
            ProjectActivityId = reader["ProjectActivityId"].AsString(),
            ProjectExpenseId = reader["ProjectExpenseId"].AsString(),
            TaskId = reader["TaskId"].AsString(),
            ListItemId = reader["ListItemId"].AsString(),
            Approved = reader["Approved"].AsBool(),
            FundStructureId = reader["FundStructureId"].AsString(),
            SortOrder = reader["SortOrder"].AsInt(),
            BankAccount = reader["BankAccount"].AsString(),
            BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
            ToCurrencyCode = reader["ToCurrencyCode"].AsString(),
            ToExchangeRate = reader["ToExchangeRate"].AsDecimal(),
            ToAmountOC = reader["ToAmountOC"].AsDecimal(),
            ToAmount = reader["ToAmount"].AsDecimal(),
            ToBudgetSourceId = reader["ToBudgetSourceId"].AsString(),
            ToBudgetProvideCode = reader["ToBudgetProvideCode"].AsString(),
            ToBudgetChapterCode = reader["ToBudgetChapterCode"].AsString(),
            ToBudgetKindItemCode = reader["ToBudgetKindItemCode"].AsString(),
            ToBudgetSubKindItemCode = reader["ToBudgetSubKindItemCode"].AsString(),
            ToBudgetItemCode = reader["ToBudgetItemCode"].AsString(),
            ToBudgetSubItemCode = reader["ToBudgetSubItemCode"].AsString(),
            ToProjectId = reader["ToProjectId"].AsString(),
            RemainAmountOC = reader["RemainAmountOC"].AsDecimal(),
            RemainAmount = reader["RemainAmount"].AsDecimal(),
            RemainExchangeRate = reader["RemainExchangeRate"].AsDecimal(),
            RemainCurrencyCode = reader["RemainCurrencyCode"].AsString(),
            BUCommitmentRequestDetailId = reader["BUCommitmentRequestDetailId"].AsString(),
            ContractId = reader["ContractID"].AsString(),
            CapitalPlanId = reader["CapitalPlanID"].AsString(),
        };

        /// <summary>
        /// Takes the specified b u commitment adjustment detail entity.
        /// </summary>
        /// <param name="bUCommitmentAdjustmentDetailEntity">The b u commitment adjustment detail entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(BUCommitmentAdjustmentDetailEntity bUCommitmentAdjustmentDetailEntity)
        {
            return new object[]
            {
                "@RefDetailID",bUCommitmentAdjustmentDetailEntity.RefDetailId,
                "@RefID",bUCommitmentAdjustmentDetailEntity.RefId,
                "@Description",bUCommitmentAdjustmentDetailEntity.Description,
                "@CurrencyCode",bUCommitmentAdjustmentDetailEntity.CurrencyCode,
                "@ExchangeRate",bUCommitmentAdjustmentDetailEntity.ExchangeRate,
                "@Amount",bUCommitmentAdjustmentDetailEntity.Amount,
                "@AmountOC",bUCommitmentAdjustmentDetailEntity.AmountOC,
                "@BudgetSourceID",bUCommitmentAdjustmentDetailEntity.BudgetSourceId,
                "@BudgetChapterCode",bUCommitmentAdjustmentDetailEntity.BudgetChapterCode,
                "@BudgetKindItemCode",bUCommitmentAdjustmentDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",bUCommitmentAdjustmentDetailEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",bUCommitmentAdjustmentDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode",bUCommitmentAdjustmentDetailEntity.BudgetSubItemCode,
                "@BudgetDetailItemCode",bUCommitmentAdjustmentDetailEntity.BudgetDetailItemCode,
                "@MethodDistributeID",bUCommitmentAdjustmentDetailEntity.MethodDistributeId,
                "@CashWithDrawTypeID",bUCommitmentAdjustmentDetailEntity.CashWithDrawTypeId,
                "@ActivityID",bUCommitmentAdjustmentDetailEntity.ActivityId,
                "@ProjectID",bUCommitmentAdjustmentDetailEntity.ProjectId,
                "@ProjectActivityID",bUCommitmentAdjustmentDetailEntity.ProjectActivityId,
                "@ProjectExpenseID",bUCommitmentAdjustmentDetailEntity.ProjectExpenseId,
                "@TaskID",bUCommitmentAdjustmentDetailEntity.TaskId,
                "@ListItemID",bUCommitmentAdjustmentDetailEntity.ListItemId,
                "@Approved",bUCommitmentAdjustmentDetailEntity.Approved,
                "@FundStructureID",bUCommitmentAdjustmentDetailEntity.FundStructureId,
                "@SortOrder",bUCommitmentAdjustmentDetailEntity.SortOrder,
                "@BankAccount",bUCommitmentAdjustmentDetailEntity.BankAccount,
                "@BudgetProvideCode",bUCommitmentAdjustmentDetailEntity.BudgetProvideCode,
                "@ToCurrencyCode",bUCommitmentAdjustmentDetailEntity.ToCurrencyCode,
                "@ToExchangeRate",bUCommitmentAdjustmentDetailEntity.ToExchangeRate,
                "@ToAmountOC",bUCommitmentAdjustmentDetailEntity.ToAmountOC,
                "@ToAmount",bUCommitmentAdjustmentDetailEntity.ToAmount,
                "@ToBudgetSourceID",bUCommitmentAdjustmentDetailEntity.ToBudgetSourceId,
                "@ToBudgetProvideCode",bUCommitmentAdjustmentDetailEntity.ToBudgetProvideCode,
                "@ToBudgetChapterCode",bUCommitmentAdjustmentDetailEntity.ToBudgetChapterCode,
                "@ToBudgetKindItemCode",bUCommitmentAdjustmentDetailEntity.ToBudgetKindItemCode,
                "@ToBudgetSubKindItemCode",bUCommitmentAdjustmentDetailEntity.ToBudgetSubKindItemCode,
                "@ToBudgetItemCode",bUCommitmentAdjustmentDetailEntity.ToBudgetItemCode,
                "@ToBudgetSubItemCode",bUCommitmentAdjustmentDetailEntity.ToBudgetSubItemCode,
                "@ToProjectID",bUCommitmentAdjustmentDetailEntity.ToProjectId,
                "@RemainAmountOC",bUCommitmentAdjustmentDetailEntity.RemainAmountOC,
                "@RemainAmount",bUCommitmentAdjustmentDetailEntity.RemainAmount,
                "@RemainExchangeRate",bUCommitmentAdjustmentDetailEntity.RemainExchangeRate,
                "@RemainCurrencyCode",bUCommitmentAdjustmentDetailEntity.RemainCurrencyCode,
                "@BUCommitmentDetailId",bUCommitmentAdjustmentDetailEntity.BUCommitmentRequestDetailId,
                "@ContractID", bUCommitmentAdjustmentDetailEntity.ContractId,
                "@CapitalPlanID", bUCommitmentAdjustmentDetailEntity.CapitalPlanId,
            };
        }

        /// <summary>
        /// Deletes the bu commitment request detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteBUCommitmentAdjustmentDetail(string refId)
        {
            const string procedures = @"uspDelete_BUCommitmentAdjustmentDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }
        /// <summary>
        /// Gets the bu commitment request detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestDetailEntity&gt;.</returns>
        public List<BUCommitmentAdjustmentDetailEntity> GetBUCommitmentAdjustmentDetailbyRefId(string refId)
        {
            const string procedures = @"uspGet_BUCommitmentAdjustmentDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }
        /// <summary>
        /// Inserts the bu plan receipt detail.
        /// </summary>
        /// <param name="bUCommitmentAdjustmentDetail">The b u commitment adjustment detail.</param>
        /// <returns>System.String.</returns>
        public string InsertBUCommitmentAdjustmenttDetail(BUCommitmentAdjustmentDetailEntity bUCommitmentAdjustmentDetail)
        {
            const string procedures = @"uspInsert_BUCommitmentAdjustmentDetail";
            return Db.Insert(procedures, true, Take(bUCommitmentAdjustmentDetail));
        }
    }
}
