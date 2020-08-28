/***********************************************************************
 * <copyright file="SqlCAReceiptDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataHelpers;


namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Cash
{
    /// <summary>
    /// SqlCAReceiptDetail class
    /// </summary>
    public class SqlServerCAReceiptDetailDao : ICAReceiptDetailDao
    {
        /// <summary>
        /// Gets the ca receipt details by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;CAReceiptDetailEntity&gt;.</returns>
        public List<CAReceiptDetailEntity> GetCAReceiptDetailsByRefId(string refId)
        {
            const string procedures = @"uspGet_CAReceiptDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the ca receipt detail.
        /// </summary>
        /// <param name="receiptDetailEntity">The receipt detail entity.</param>
        /// <returns>System.String.</returns>
        public string InsertCAReceiptDetail(CAReceiptDetailEntity receiptDetailEntity)
        {
            const string procedures = @"uspInsert_CAReceiptDetail";
            return Db.Insert(procedures, true, Take(receiptDetailEntity));
        }

        /// <summary>
        /// Deletes the ca receipt detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteCAReceiptDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_CAReceiptDetail_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CAReceiptDetailEntity> Make = reader =>
           new CAReceiptDetailEntity
           {
               RefDetailId = reader["RefDetailId"].AsString(),
               RefId = reader["RefId"].AsString(),
               Description = reader["Description"].AsString(),
               DebitAccount = reader["DebitAccount"].AsString(),
               CreditAccount = reader["CreditAccount"].AsString(),
               Amount = reader["Amount"].AsDecimal(),
               AmountOC = reader["AmountOC"].AsDecimal(),
               BudgetSourceId = reader["BudgetSourceId"].AsString(),
               BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
               BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
               BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
               BudgetItemCode = reader["BudgetItemCode"].AsString(),
               BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
               MethodDistributeId = reader["MethodDistributeId"].AsInt(),
               CashWithdrawTypeId = reader["CashWithdrawTypeId"].AsInt(),
               AccountingObjectId = reader["AccountingObjectId"].AsString(),
               ActivityId = reader["ActivityId"].AsString(),
               ProjectId = reader["ProjectId"].AsString(),
               ProjectActivityId = reader["ProjectActivityId"].AsString(),
               ProjectExpenseId = reader["ProjectExpenseId"].AsString(),
               ListItemId = reader["ListItemId"].AsString(),
               SortOrder = reader["SortOrder"].AsInt(),
               BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
               OrgRefNo = reader["OrgRefNo"].AsString(),
               OrgRefDate = reader["OrgRefDate"].AsDateTime(),
               FundStructureId = reader["FundStructureId"].AsString(),
               BankId = reader["BankId"].AsString(),
               ProjectActivityEAId = reader["ProjectActivityEAId"].AsString(),
               WithdrawDetailId = reader["WithdrawDetailId"].AsString(),
               BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
               ContractId = reader["ContractID"].AsString(),
               CapitalPlanId = reader["CapitalPlanID"].AsString(),
               AutoBusinessId = reader["AutoBusinessID"].AsString()
           };

        /// <summary>
        /// Takes the specified information.
        /// </summary>
        /// <param name="cAReceiptDetailEntity">The c a receipt detail entity.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(CAReceiptDetailEntity cAReceiptDetailEntity)
        {
            return new object[]
            {
                "@RefDetailId",cAReceiptDetailEntity.RefDetailId,
                "@RefId",cAReceiptDetailEntity.RefId,
                "@Description",cAReceiptDetailEntity.Description,
                "@DebitAccount",cAReceiptDetailEntity.DebitAccount,
                "@CreditAccount",cAReceiptDetailEntity.CreditAccount,
                "@Amount",cAReceiptDetailEntity.Amount,
                "@AmountOC",cAReceiptDetailEntity.AmountOC,
                "@BudgetSourceId",cAReceiptDetailEntity.BudgetSourceId,
                "@BudgetChapterCode",cAReceiptDetailEntity.BudgetChapterCode,
                "@BudgetKindItemCode",cAReceiptDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",cAReceiptDetailEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",cAReceiptDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode",cAReceiptDetailEntity.BudgetSubItemCode,
                "@MethodDistributeId",cAReceiptDetailEntity.MethodDistributeId,
                "@CashWithdrawTypeId",cAReceiptDetailEntity.CashWithdrawTypeId,
                "@AccountingObjectId",cAReceiptDetailEntity.AccountingObjectId,
                "@ActivityId",cAReceiptDetailEntity.ActivityId,
                "@ProjectId",cAReceiptDetailEntity.ProjectId,
                "@ProjectActivityId",cAReceiptDetailEntity.ProjectActivityId,
                "@ProjectExpenseId",cAReceiptDetailEntity.ProjectExpenseId,
                "@ListItemId",cAReceiptDetailEntity.ListItemId,
                "@SortOrder",cAReceiptDetailEntity.SortOrder,
                "@BudgetDetailItemCode",cAReceiptDetailEntity.BudgetDetailItemCode,
                "@OrgRefNo",cAReceiptDetailEntity.OrgRefNo,
                "@OrgRefDate",cAReceiptDetailEntity.OrgRefDate,
                "@FundStructureId",cAReceiptDetailEntity.FundStructureId,
                "@BankId",cAReceiptDetailEntity.BankId,
                "@ProjectActivityEAId",cAReceiptDetailEntity.ProjectActivityEAId,
                "@WithdrawDetailId",cAReceiptDetailEntity.WithdrawDetailId,
                "@BudgetExpenseID",cAReceiptDetailEntity.BudgetExpenseId,
                "@ContractID", cAReceiptDetailEntity.ContractId,
                "@CapitalPlanID", cAReceiptDetailEntity.CapitalPlanId,
                "@AutoBusinessID", cAReceiptDetailEntity.AutoBusinessId,
            };
        }
    }
}
