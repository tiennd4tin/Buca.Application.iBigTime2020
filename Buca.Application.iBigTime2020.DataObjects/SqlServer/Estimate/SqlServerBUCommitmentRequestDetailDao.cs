/***********************************************************************
 * <copyright file="SqlServerBUCommitmentRequestDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Tuesday, December 5, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateTuesday, December 5, 2017Author SonTV  Description 
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
    public class SqlServerBUCommitmentRequestDetailDao : IBUCommitmentRequestDetailDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUCommitmentRequestDetailEntity> Make = reader =>
        new BUCommitmentRequestDetailEntity
        {
            RefDetailId = reader["RefDetailID"].AsString(),
            RefId = reader["RefID"].AsString(),
            Description = reader["Description"].AsString(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
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
            CashWithDrawTypeId = reader["CashWithDrawTypeID"].AsInt(),
            ActivityId = reader["ActivityID"].AsString(),
            ProjectId = reader["ProjectID"].AsString(),
            ProjectActivityId = reader["ProjectActivityID"].AsString(),
            ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
            TaskId = reader["TaskID"].AsString(),
            ListItemId = reader["ListItemID"].AsString(),
            Approved = reader["Approved"].AsBool(),
            FundStructureId = reader["FundStructureID"].AsString(),
            SortOrder = reader["SortOrder"].AsInt(),
            BankAccount = reader["BankAccount"].AsString(),
            BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
            ContractId = reader["ContractID"].AsString(),
            CapitalPlanId = reader["CapitalPlanID"].AsString(),
        };

        /// <summary>
        /// Takes the specified b u commitment request detail entity.
        /// </summary>
        /// <param name="bUCommitmentRequestDetailEntity">The b u commitment request detail entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(BUCommitmentRequestDetailEntity bUCommitmentRequestDetailEntity)
        {
            return new object[]
            {
                "@RefDetailID",bUCommitmentRequestDetailEntity.RefDetailId,
                "@RefID",bUCommitmentRequestDetailEntity.RefId,
                "@Description",bUCommitmentRequestDetailEntity.Description,
                "@CurrencyCode",bUCommitmentRequestDetailEntity.CurrencyCode,
                "@ExchangeRate",bUCommitmentRequestDetailEntity.ExchangeRate,
                "@Amount",bUCommitmentRequestDetailEntity.Amount,
                "@AmountOC",bUCommitmentRequestDetailEntity.AmountOC,
                "@BudgetSourceID",bUCommitmentRequestDetailEntity.BudgetSourceId,
                "@BudgetChapterCode",bUCommitmentRequestDetailEntity.BudgetChapterCode,
                "@BudgetKindItemCode",bUCommitmentRequestDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",bUCommitmentRequestDetailEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",bUCommitmentRequestDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode",bUCommitmentRequestDetailEntity.BudgetSubItemCode,
                "@BudgetDetailItemCode",bUCommitmentRequestDetailEntity.BudgetDetailItemCode,
                "@MethodDistributeID",bUCommitmentRequestDetailEntity.MethodDistributeId,
                "@CashWithDrawTypeID",bUCommitmentRequestDetailEntity.CashWithDrawTypeId,
                "@ActivityID",bUCommitmentRequestDetailEntity.ActivityId,
                "@ProjectID",bUCommitmentRequestDetailEntity.ProjectId,
                "@ProjectActivityID",bUCommitmentRequestDetailEntity.ProjectActivityId,
                "@ProjectExpenseID",bUCommitmentRequestDetailEntity.ProjectExpenseId,
                "@TaskID",bUCommitmentRequestDetailEntity.TaskId,
                "@ListItemID",bUCommitmentRequestDetailEntity.ListItemId,
                "@Approved",bUCommitmentRequestDetailEntity.Approved,
                "@FundStructureID",bUCommitmentRequestDetailEntity.FundStructureId,
                "@SortOrder",bUCommitmentRequestDetailEntity.SortOrder,
                "@BankAccount",bUCommitmentRequestDetailEntity.BankAccount,
                "@BudgetProvideCode",bUCommitmentRequestDetailEntity.BudgetProvideCode,
                "@ContractID",bUCommitmentRequestDetailEntity.ContractId,
                "@CapitalPlanID", bUCommitmentRequestDetailEntity.CapitalPlanId,
            };
        }

        /// <summary>
        /// Deletes the bu commitment request detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteBUCommitmentRequestDetail(string refId)
        {
            const string procedures = @"uspDelete_BUCommitmentRequestDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }
        /// <summary>
        /// Gets the bu commitment request detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestDetailEntity&gt;.</returns>
        public List<BUCommitmentRequestDetailEntity> GetBUCommitmentRequestDetailbyRefId(string refId)
        {
            const string procedures = @"uspGet_BUCommitmentRequestDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }
        /// <summary>
        /// Inserts the bu plan receipt detail.
        /// </summary>
        /// <param name="bUCommitmentRequestDetail">The b u commitment request detail.</param>
        /// <returns>System.String.</returns>
        public string InsertBUPlanReceiptDetail(BUCommitmentRequestDetailEntity bUCommitmentRequestDetail)
        {
            const string procedures = @"uspInsert_BUCommitmentRequestDetail";
            return Db.Insert(procedures, true, Take(bUCommitmentRequestDetail));
        }
    }
}
