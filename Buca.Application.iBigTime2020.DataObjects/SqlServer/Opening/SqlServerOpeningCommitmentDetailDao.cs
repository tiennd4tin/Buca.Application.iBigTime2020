/***********************************************************************
 * <copyright file="SqlServerOpeningCommitmentDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, December 8, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, December 8, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Opening
{
    public class SqlServerOpeningCommitmentDetailDao : IOpeningCommitmentDetailDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningCommitmentDetailEntity> Make = reader =>
   new OpeningCommitmentDetailEntity
   {
       RefDetailId = reader["RefDetailID"].AsString(),
       RefId = reader["RefID"].AsString(),
       Description = reader["Description"].AsString(),
       CurrencyId = reader["CurrencyID"].AsString(),
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

   };

        /// <summary>
        /// Takes the specified b u commitment request detail entity.
        /// </summary>
        /// <param name="bUCommitmentRequestDetailEntity">The b u commitment request detail entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(OpeningCommitmentDetailEntity openingCommitmentDetailEntity)
        {
            return new object[]
            {

        "@RefDetailID",openingCommitmentDetailEntity.RefDetailId,
        "@RefID",openingCommitmentDetailEntity.RefId,
        "@Description",openingCommitmentDetailEntity.Description,
        "@CurrencyID",openingCommitmentDetailEntity.CurrencyId,
        "@ExchangeRate",openingCommitmentDetailEntity.ExchangeRate,
        "@Amount",openingCommitmentDetailEntity.Amount,
        "@AmountOC",openingCommitmentDetailEntity.AmountOC,
        "@BudgetSourceID",openingCommitmentDetailEntity.BudgetSourceId,
        "@BudgetChapterCode",openingCommitmentDetailEntity.BudgetChapterCode,
        "@BudgetKindItemCode",openingCommitmentDetailEntity.BudgetKindItemCode,
        "@BudgetSubKindItemCode",openingCommitmentDetailEntity.BudgetSubKindItemCode,
        "@BudgetItemCode",openingCommitmentDetailEntity.BudgetItemCode,
        "@BudgetSubItemCode",openingCommitmentDetailEntity.BudgetSubItemCode,
        "@BudgetDetailItemCode",openingCommitmentDetailEntity.BudgetDetailItemCode,
        "@MethodDistributeID",openingCommitmentDetailEntity.MethodDistributeId,
        "@CashWithDrawTypeID",openingCommitmentDetailEntity.CashWithDrawTypeId,
        "@ActivityID",openingCommitmentDetailEntity.ActivityId,
        "@ProjectID",openingCommitmentDetailEntity.ProjectId,
        "@ProjectActivityID",openingCommitmentDetailEntity.ProjectActivityId,
        "@ProjectExpenseID",openingCommitmentDetailEntity.ProjectExpenseId,
        "@TaskID",openingCommitmentDetailEntity.TaskId,
        "@ListItemID",openingCommitmentDetailEntity.ListItemId,
        "@Approved",openingCommitmentDetailEntity.Approved,
        "@FundStructureID",openingCommitmentDetailEntity.FundStructureId,
        "@SortOrder",openingCommitmentDetailEntity.SortOrder,
        "@BankAccount",openingCommitmentDetailEntity.BankAccount,
        "@BudgetProvideCode",openingCommitmentDetailEntity.BudgetProvideCode,
            };
        }

        /// <summary>
        /// Deletes the bu commitment request detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteOpeningCommitmentDetail(string refId)
        {
            const string procedures = @"uspDelete_OpeningCommitmentDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }
        /// <summary>
        /// Gets the bu commitment request detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestDetailEntity&gt;.</returns>
        public List<OpeningCommitmentDetailEntity> GetOpeningCommitmentDetailbyRefId(string refId)
        {
            const string procedures = @"uspGet_OpeningCommitmentDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }
        /// <summary>
        /// Inserts the bu plan receipt detail.
        /// </summary>
        /// <param name="bUCommitmentRequestDetail">The b u commitment request detail.</param>
        /// <returns>System.String.</returns>
        public string InsertOpeningCommitmentDetail(OpeningCommitmentDetailEntity openingCommitmentDetail)
        {
            const string procedures = @"uspInsert_OpeningCommitmentDetail";
            return Db.Insert(procedures, true, Take(openingCommitmentDetail));
        }
    }
}
