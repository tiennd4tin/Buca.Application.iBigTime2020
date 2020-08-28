/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.General
{
    /// <summary>
    /// SqlServerGLVoucherDetailDao
    /// </summary>
    public class SqlServerGLVoucherDetailDao : IGLVoucherDetailDao
    {
        /// <summary>
        /// Gets the fa armortization details by fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<GLVoucherDetailEntity> GetGLVoucherDetailsByRefId(string refId)
        {
            const string procedures = @"uspGet_GLVoucherDetail_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public List<GLVoucherDetailEntity> GetGLVoucherDetailsEndYear(DateTime date)
        {

            const string procedures = @"Proc_GLEndYearTransfer";

            object[] parms = { "@SystemDate", date, "@BusinessType", 1, "@CashWithDrawTypeID", 0 };
            return Db.ReadList(procedures, true, MakeEndYear, parms);
        }
        public List<GLVoucherDetailEntity> GetGLSettlementOfCompletedProjects(DateTime date,string projectIds)
        {

            const string procedures = @"Proc_Get_GL_Settlement_of_completed_projects";

            object[] parms = { "@SystemDate", date, "@BusinessType", 3, "@CashWithDrawTypeID", 0 , "@ProjectIds", projectIds };
            return Db.ReadList(procedures, true, MakeEndYear, parms);
        }
        public List<GLVoucherDetailEntity> GetGLVoucherDetailsEarlyYear(DateTime date)
        {

            const string procedures = @"Proc_GetAccountForGeneralVoucher";

            object[] parms = { "@SystemDate", date, "@BusinessType", 0, "@CashWithDrawTypeID", 0 };
            return Db.ReadList(procedures, true, MakeEarlyYear, parms);
        }
        public List<GLVoucherDetailEntity> GetGLVoucherExpensesWaitingSettlement(DateTime date, string projectIds = null)
        {

            const string procedures = @"Proc_Get_GL_Expenses_Waiting_Settlement";

            object[] parms = { "@SystemDate", date, "@BusinessType", 2, "@CashWithDrawTypeID", 0, "@ProjectIds", projectIds };
            return Db.ReadList(procedures, true, MakeEarlyYear, parms);
        }
        
        public List<GLVoucherDetailEntity> GetGLVoucherDetailsPerformanceResults(DateTime date)
        {

            const string procedures = @"Proc_GetGLInterestAndLossTransfer";

            object[] parms = { "@SystemDate", date, "@BusinessType", 1, "@CashWithDrawTypeID", 0 };
            return Db.ReadList(procedures, true, MakeResult, parms);
        }
        /// <summary>
        /// Gets the fa decrement by fa increment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<GLVoucherDetailEntity> GetGLVoucherDetailByGLVoucher(string refId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the automatic fa armortization details by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="yearOfDeprecation">The year of deprecation.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<GLVoucherDetailEntity> GetAutoGLVoucherDetailsByCurrencyCode(string currencyCode, int yearOfDeprecation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the fa armortization detail.
        /// </summary>
        /// <param name="glVoucherDetail">The f a armortization detail.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string InsertGLVoucherDetail(GLVoucherDetailEntity glVoucherDetail)
        {
            const string sql = @"uspInsert_GLVoucherDetail";
            return Db.Insert(sql, true, Take(glVoucherDetail));
        }

        /// <summary>
        /// Deletes the fa armortization detail by fa armortization identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string DeleteGLVoucherDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_GLVoucherDetail_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, GLVoucherDetailEntity> Make = reader =>
        new GLVoucherDetailEntity
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
            CreditAccountingObjectId = reader["CreditAccountingObjectID"].AsString(),
            ActivityId = reader["ActivityID"].AsString(),
            ProjectId = reader["ProjectID"].AsString(),
            ProjectActivityId = reader["ProjectActivityID"].AsString(),
            ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
            TaskId = reader["TaskID"].AsString(),
            ListItemId = reader["ListItemID"].AsString(),
            Approved = reader["Approved"].AsBool(),
            ParentRefDetailId = reader["ParentRefDetailID"].AsString(),
            SortOrder = reader["SortOrder"].AsInt(),
            BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
            OrgRefNo = reader["OrgRefNo"].AsString(),
            OrgRefDate = reader["OrgRefDate"].AsDateTime(),
            BankAccount = reader["BankAccount"].AsString(),
            FundStructureId = reader["FundStructureID"].AsString(),
            ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
            ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
            BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
            TopicId = reader["TopicID"].AsString(),
            BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
            BankId = reader["BankAccount"].AsString(),
            ContractId = reader["ContractID"].AsString(),
            CapitalPlanId = reader["CapitalPlanID"].AsString(),
            AutoBusinessID = reader["AutoBusinessID"].AsString(),
        };

        /// <summary>
        /// Takes the specified f a depreciation detail entity.
        /// </summary>
        /// <param name="glVoucherDetailEntity">The f a depreciation detail entity.</param>
        /// <returns></returns>
        private static object[] Take(GLVoucherDetailEntity glVoucherDetailEntity)
        {
            return new object[]
                {

                    "@RefDetailID",glVoucherDetailEntity.RefDetailId,
                    "@RefID",glVoucherDetailEntity.RefId,
                    "@Description",glVoucherDetailEntity.Description,
                    "@DebitAccount",glVoucherDetailEntity.DebitAccount,
                    "@CreditAccount",glVoucherDetailEntity.CreditAccount,
                    "@Amount",glVoucherDetailEntity.Amount,
                    "@AmountOC",glVoucherDetailEntity.AmountOC,
                    "@BudgetSourceID",glVoucherDetailEntity.BudgetSourceId,
                    "@BudgetChapterCode",glVoucherDetailEntity.BudgetChapterCode,
                    "@BudgetKindItemCode",glVoucherDetailEntity.BudgetKindItemCode,
                    "@BudgetSubKindItemCode",glVoucherDetailEntity.BudgetSubKindItemCode,
                    "@BudgetItemCode",glVoucherDetailEntity.BudgetItemCode,
                    "@BudgetSubItemCode",glVoucherDetailEntity.BudgetSubItemCode,
                    "@MethodDistributeID",glVoucherDetailEntity.MethodDistributeId,
                    "@CashWithDrawTypeID",glVoucherDetailEntity.CashWithDrawTypeId,
                    "@AccountingObjectID",glVoucherDetailEntity.AccountingObjectId,
                    "@CreditAccountingObjectID",glVoucherDetailEntity.CreditAccountingObjectId,
                    "@ActivityID",glVoucherDetailEntity.ActivityId,
                    "@ProjectID",glVoucherDetailEntity.ProjectId,
                    "@ProjectActivityID",glVoucherDetailEntity.ProjectActivityId,
                    "@ProjectExpenseID",glVoucherDetailEntity.ProjectExpenseId,
                    "@TaskID",glVoucherDetailEntity.TaskId,
                    "@ListItemID",glVoucherDetailEntity.ListItemId,
                    "@Approved",glVoucherDetailEntity.Approved,
                    "@ParentRefDetailID",glVoucherDetailEntity.ParentRefDetailId,
                    "@SortOrder",glVoucherDetailEntity.SortOrder,
                    "@BudgetDetailItemCode",glVoucherDetailEntity.BudgetDetailItemCode,
                    "@OrgRefNo",glVoucherDetailEntity.OrgRefNo,
                    "@OrgRefDate",glVoucherDetailEntity.OrgRefDate,
                    "@BankAccount",glVoucherDetailEntity.BankId,
                    "@FundStructureID",glVoucherDetailEntity.FundStructureId,
                    "@ProjectExpenseEAID",glVoucherDetailEntity.ProjectExpenseEAId,
                    "@ProjectActivityEAID",glVoucherDetailEntity.ProjectActivityEAId,
                    "@BudgetProvideCode",glVoucherDetailEntity.BudgetProvideCode,
                    "@TopicID",glVoucherDetailEntity.TopicId,
                    "@BudgetExpenseID",glVoucherDetailEntity.BudgetExpenseId,
                    "@ContractID", glVoucherDetailEntity.ContractId,
                    "@CapitalPlanID", glVoucherDetailEntity.CapitalPlanId,
                    "@AutoBusinessID", glVoucherDetailEntity.AutoBusinessID,


                };
        }
        private static readonly Func<IDataReader, GLVoucherDetailEntity> MakeEarlyYear = reader =>
       new GLVoucherDetailEntity
       {

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
           Approved = reader["Approved"].AsBool(),
           SortOrder = reader["SortOrder"].AsInt(),
           BankAccount = reader["BankAccount"].AsString(),
           FundStructureId = reader["FundStructureID"].AsString(),
           BudgetProvideCode = reader["BudgetProvideCode"].AsString(),

       };

        private static readonly Func<IDataReader, GLVoucherDetailEntity> MakeEndYear = reader =>
   new GLVoucherDetailEntity
   {

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
       Approved = reader["Approved"].AsBool(),
       SortOrder = reader["SortOrder"].AsInt(),
       BankAccount = reader["BankAccount"].AsString(),
       BudgetProvideCode = reader["BudgetProvideCode"].AsString(),

   };

        private static readonly Func<IDataReader, GLVoucherDetailEntity> MakeResult = reader =>
            new GLVoucherDetailEntity
            {

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
                SortOrder = reader["SortOrder"].AsInt(),
            };
    }
}
