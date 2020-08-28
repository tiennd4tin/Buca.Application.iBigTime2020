/***********************************************************************
 * <copyright file="SqlServerBUTransferDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
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
    /// Class SqlServerBUTransferDetailDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate.IBUTransferDetailDao" />
    public class SqlServerBUTransferDetailDao : IBUTransferDetailDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BUTransferDetailEntity> Make = reader =>
   new BUTransferDetailEntity
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
       ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
       TaskId = reader["TaskID"].AsString(),
       ListItemId = reader["ListItemID"].AsString(),
       Approved = reader["Approved"].AsBool(),
       SortOrder = reader["SortOrder"].AsInt(),
       BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
       FundId = reader["FundID"].AsString(),
       OrgRefNo = reader["OrgRefNo"].AsString(),
       OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
       FundStructureId = reader["FundStructureID"].AsString(),
       ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
       ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
       WithdrawRefDetailId = reader["WithdrawRefDetailID"].AsString(),
       BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
       TopicId = reader["TopicID"].AsString(),
       BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
       BankId = reader["BankID"].AsString(),
       ContractId = reader["ContractID"].AsString(),
       CapitalPlanId = reader["CapitalPlanID"].AsString(),
       AdvanceRecovery = reader["AdvanceRecovery"].AsDecimal(),
       AutoBusinessID = reader["AutoBusinessID"].AsString()
   };

        private static readonly Func<IDataReader, BUTransferDetailEntity> MakeDetail = reader =>
   new BUTransferDetailEntity
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
       ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
       TaskId = reader["TaskID"].AsString(),
       ListItemId = reader["ListItemID"].AsString(),
       Approved = reader["Approved"].AsBool(),
       SortOrder = reader["SortOrder"].AsInt(),
       BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
       FundId = reader["FundID"].AsString(),
       OrgRefNo = reader["OrgRefNo"].AsString(),
       OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
       FundStructureId = reader["FundStructureID"].AsString(),
       ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
       ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
       WithdrawRefDetailId = reader["WithdrawRefDetailID"].AsString(),
       BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
       TopicId = reader["TopicID"].AsString(),
       BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
       BankId = reader["BankID"].AsString(),
       ContractId = reader["ContractID"].AsString(),
       CapitalPlanId = reader["CapitalPlanID"].AsString(),
       OldAdvanceRecovery = reader["OldAdvanceRecovery"].AsDecimal(),
       AdvanceRecovery = reader["AdvanceRecovery"].AsDecimal(),
       AutoBusinessID = reader["AutoBusinessID"].AsString()
   };

        /// <summary>
        /// Takes the specified b u transfer detail entity.
        /// </summary>
        /// <param name="bUTransferDetailEntity">The b u transfer detail entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(BUTransferDetailEntity bUTransferDetailEntity)
        {
            return new object[]
            {

                "@RefDetailID",bUTransferDetailEntity.RefDetailId,
                "@RefID",bUTransferDetailEntity.RefId,
                "@Description",bUTransferDetailEntity.Description,
                "@DebitAccount",bUTransferDetailEntity.DebitAccount,
                "@CreditAccount",bUTransferDetailEntity.CreditAccount,
                "@Amount",bUTransferDetailEntity.Amount,
                "@AmountOC",bUTransferDetailEntity.AmountOC,
                "@BudgetSourceID",bUTransferDetailEntity.BudgetSourceId,
                "@BudgetChapterCode",bUTransferDetailEntity.BudgetChapterCode,
                "@BudgetKindItemCode",bUTransferDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",bUTransferDetailEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",bUTransferDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode",bUTransferDetailEntity.BudgetSubItemCode,
                "@MethodDistributeID",bUTransferDetailEntity.MethodDistributeId,
                "@CashWithDrawTypeID",bUTransferDetailEntity.CashWithDrawTypeId,
                "@AccountingObjectID",bUTransferDetailEntity.AccountingObjectId,
                "@ActivityID",bUTransferDetailEntity.ActivityId,
                "@ProjectID",bUTransferDetailEntity.ProjectId,
                "@ProjectActivityID",bUTransferDetailEntity.ProjectActivityId,
                "@ProjectExpenseID",bUTransferDetailEntity.ProjectExpenseId,
                "@TaskID",bUTransferDetailEntity.TaskId,
                "@ListItemID",bUTransferDetailEntity.ListItemId,
                "@Approved",bUTransferDetailEntity.Approved,
                "@SortOrder",bUTransferDetailEntity.SortOrder,
                "@BudgetDetailItemCode",bUTransferDetailEntity.BudgetDetailItemCode,
                "@FundID",bUTransferDetailEntity.FundId,
                "@OrgRefNo",bUTransferDetailEntity.OrgRefNo,
                "@OrgRefDate",bUTransferDetailEntity.OrgRefDate,
                "@FundStructureID",bUTransferDetailEntity.FundStructureId,
                "@ProjectExpenseEAID",bUTransferDetailEntity.ProjectExpenseEAId,
                "@ProjectActivityEAID",bUTransferDetailEntity.ProjectActivityEAId,
                "@WithdrawRefDetailID",bUTransferDetailEntity.WithdrawRefDetailId,
                "@BudgetProvideCode",bUTransferDetailEntity.BudgetProvideCode,
                "@TopicID",bUTransferDetailEntity.TopicId,
                "@BudgetExpenseID",bUTransferDetailEntity.BudgetExpenseId,
                "@BankID",bUTransferDetailEntity.BankId,
                "@ContractID", bUTransferDetailEntity.ContractId,
                "@CapitalPlanID", bUTransferDetailEntity.CapitalPlanId,
                  "@OldAdvanceRecovery", bUTransferDetailEntity.OldAdvanceRecovery,
                "@AdvanceRecovery", bUTransferDetailEntity.AdvanceRecovery,
                "@AutoBusinessID", bUTransferDetailEntity.AutoBusinessID,
            };
        }

        /// <summary>
        /// Deletes the bu commitment request detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteBUTransferDetail(string refId)
        {
            const string procedures = @"uspDelete_BUTransferDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }
        /// <summary>
        /// Gets the bu commitment request detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestDetailEntity&gt;.</returns>
        public List<BUTransferDetailEntity> GetBUTransferDetailbyRefId(string refId)
        { 
            const string procedures = @"uspGet_BUTransferDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, MakeDetail, parms);
        }
        /// <summary>
        /// Inserts the bu plan receipt detail.
        /// </summary>
        /// <param name="bUTransferDetail">The b u commitment adjustment detail.</param>
        /// <returns>System.String.</returns>
        public string InsertBUTransferDetail(BUTransferDetailEntity bUTransferDetail)
        {
            const string procedures = @"uspInsert_BUTransferDetail";
            return Db.Insert(procedures, true, Take(bUTransferDetail)); 
        }
    }
}
