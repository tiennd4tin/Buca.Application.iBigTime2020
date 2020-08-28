/***********************************************************************
 * <copyright file="SqlServerFAIncrementDecrementDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.IncrementDecrement
{
    /// <summary>
    /// SqlServerFAAdjustmentDetailDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement.IFAAdjustmentDetailDao" />
    public class SqlServerFAAdjustmentDetailDao : IFAAdjustmentDetailDao

    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, FAAdjustmentDetailEntity> Make = reader =>
            new FAAdjustmentDetailEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                Description = reader["Description"].AsString(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                Amount = reader["Amount"].AsDecimal(),
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
                //ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
                //TaskId = reader["TaskID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                FundStructureId = reader["FundStructureID"].AsString(),
                BankId = reader["BankID"].AsString(),
                ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
                ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
                //BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
                //TopicId = reader["TopicID"].AsString(),
                BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
                ContractId = reader["ContractID"].AsString(),
                CapitalPlanId = reader["CapitalPlanID"].AsString(),
            };

        public List<FAAdjustmentDetailEntity> GetFAAdjustmentDetailsByRefId(string refId)
        {
            const string procedures = @"uspGet_FAAdjustmentDetailsByRefId";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public string InsertFAAdjustmentDetail(FAAdjustmentDetailEntity fAAdjustmentEntity)
        {
            const string sql = @"uspInsert_FAAdjustmentDetail";
            return Db.Insert(sql, true, Take(fAAdjustmentEntity));
        }
        public string DeleteFAAdjustmentDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_FAAdjustmentDetailByRefId";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        public string DeleteFAAdjustmentDetail(string refId)
        {
            const string sql = @"uspDelete_FAAdjustmentDetail";
            object[] parms = { "@RefID", refId };
            return Db.Delete(sql, true, parms);
        }
        //public FAIncrementDecrementEntity GetFAIncrementDecrementByRefNo(string refNo)
        //{
        //    const string procedures = @"uspGet_FAIncrementDecrement_ByRefNo";
        //    object[] parms = {"@RefNo", refNo};
        //    return Db.Read(procedures, true, Make, parms);
        //}

        private static object[] Take(FAAdjustmentDetailEntity fAAdjustmentEntity)
        {
            return new object[]
            {
                "@RefDetailID" ,  fAAdjustmentEntity.RefDetailId,
                "@RefID" ,  fAAdjustmentEntity.RefId,
                "@Description"  , fAAdjustmentEntity.Description,
                "@DebitAccount",  fAAdjustmentEntity.DebitAccount,
                "@CreditAccount", fAAdjustmentEntity.CreditAccount,
                "@Amount", fAAdjustmentEntity.Amount,
                "@BudgetSourceID", fAAdjustmentEntity.BudgetSourceId,
                "@BudgetChapterCode", fAAdjustmentEntity.BudgetChapterCode,
                "@BudgetKindItemCode", fAAdjustmentEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", fAAdjustmentEntity.BudgetSubKindItemCode,
                "@BudgetItemCode", fAAdjustmentEntity.BudgetItemCode,
                "@BudgetSubItemCode", fAAdjustmentEntity.BudgetSubItemCode,
                "@MethodDistributeID", fAAdjustmentEntity.MethodDistributeId,
                "@CashWithDrawTypeID", fAAdjustmentEntity.CashWithDrawTypeId,
                "@AccountingObjectID", fAAdjustmentEntity.AccountingObjectId,
                "@ActivityID", fAAdjustmentEntity.ActivityId,
                "@ProjectID", fAAdjustmentEntity.ProjectId,
                "@ProjectActivityID", fAAdjustmentEntity.ProjectActivityId,
                "@ProjectExpenseID", fAAdjustmentEntity.ProjectExpenseId,
                "@TaskID", fAAdjustmentEntity.TaskId,
                "@ListItemID", fAAdjustmentEntity.ListItemId,
                "@SortOrder", fAAdjustmentEntity.SortOrder,
                "@BudgetDetailItemCode", fAAdjustmentEntity.BudgetDetailItemCode,
                "@FundStructureID", fAAdjustmentEntity.FundStructureId,
                "@BankID", fAAdjustmentEntity.BankId,
                "@ProjectExpenseEAID", fAAdjustmentEntity.ProjectExpenseEAId,
                "@ProjectActivityEAID", fAAdjustmentEntity.ProjectActivityEAId,
                "@BudgetProvideCode", fAAdjustmentEntity.BudgetProvideCode,
                "@TopicID", fAAdjustmentEntity.TopicId,
                "@BudgetExpenseID", fAAdjustmentEntity.BudgetExpenseId,
                "@ContractID", fAAdjustmentEntity.ContractId,
                "@CapitalPlanID", fAAdjustmentEntity.CapitalPlanId,

            };
        }
    }
}