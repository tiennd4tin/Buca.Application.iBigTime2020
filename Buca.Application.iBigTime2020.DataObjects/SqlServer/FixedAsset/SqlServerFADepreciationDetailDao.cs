/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAsset;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.FixedAsset
{
    /// <summary>
    /// SqlServerFADepreciationDetailDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset.IFADepreciationDetailDao" />
    public class SqlServerFADepreciationDetailDao : IFADepreciationDetailDao
    {
        /// <summary>
        /// Gets the fa armortization details by fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<FADepreciationDetailEntity> GetFADepreciationDetailsByFADepreciation(string refId)
        {
            const string procedures = @"uspGet_FADepreciationDetail_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the fa devaluation details by fa depreciation.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public List<FADepreciationDetailEntity> GetFADevaluationDetailsByFADepreciation(string refId)
        {
            const string procedures = @"uspGet_FADevaluationDetail_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, MakeDevaluation, parms);
        }

        /// <summary>
        /// Gets the fa depreciation details by fa depreciation.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>
        /// List&lt;FADepreciationDetailEntity&gt;.
        /// </returns>
        public List<FADepreciationDetailEntity> GetFADepreciationDetailsByFADepreciation(DateTime fromDate, DateTime toDate)
        {
            const string procedures = @"uspGet_FixedAssetDepreciation_Not_Parallel";

            object[] parms = { "@FromDate", fromDate, "@ToDate", toDate };
            return Db.ReadList(procedures, true, MakeNewVoucher, parms);
        }

        /// <summary>
        /// Gets the fa depreciation details by fa depreciation.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="periodType">Type of the period.</param>
        /// <returns></returns>
        public List<FADepreciationDetailEntity> GetFADepreciationDetailsByFADepreciation(DateTime fromDate, DateTime toDate, int periodType)
        {
            const string procedures = @"uspGet_DevaluationInfo";

            object[] parms = { "@FromDate", fromDate, "@ToDate", toDate, "@DevaluationPeriodType", periodType };
            return Db.ReadList(procedures, true, MakeNewDevaluationVoucher, parms);
        }

        /// <summary>
        /// Gets the fa decrement by fa increment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public List<FADepreciationDetailEntity> GetFADepreciationByFAIncrement(string refId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the automatic fa armortization details by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="yearOfDeprecation">The year of deprecation.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public List<FADepreciationDetailEntity> GetAutoFADepreciationDetailsByCurrencyCode(string currencyCode, int yearOfDeprecation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the fa armortization detail.
        /// </summary>
        /// <param name="fADepreciationDetail">The f a depreciation detail.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string InsertFADepreciationDetail(FADepreciationDetailEntity fADepreciationDetail)
        {
            const string sql = @"uspInsert_FADepreciationDetail"; 
            return Db.Insert(sql, true, Take(fADepreciationDetail));
        }

        /// <summary>
        /// Deletes the fa armortization detail by fa armortization identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string DeleteFADepreciationDetailByFADepreciationId(string refId)
        {
            const string procedures = @"uspDelete_FADepreciationDetail_ByRefID";

            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FADepreciationDetailEntity> Make = reader =>
        new FADepreciationDetailEntity
        {
            RefDetailId = reader["RefDetailID"].AsString(),
            RefId = reader["RefID"].AsString(),
            FixedAssetId = reader["FixedAssetID"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            AnnualDepreciationRate = reader["AnnualDepreciationRate"].AsDecimal(),
            AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
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
            ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
            TaskId = reader["TaskID"].AsString(),
            ListItemId = reader["ListItemID"].AsString(),
            SortOrder = reader["SortOrder"].AsInt(),
            BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
            FundStructureId = reader["FundStructureID"].AsString(),
            ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
            ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
            BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
            TopicId = reader["TopicID"].AsString(),
            BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
            ContractId = reader["ContractID"].AsString(),
            CapitalPlanId = reader["CapitalPlanID"].AsString(),
            IsParallel = reader["IsParallel"].AsBool()
        };

        private static readonly Func<IDataReader, FADepreciationDetailEntity> MakeDevaluation = reader =>
        new FADepreciationDetailEntity
        {
            RefDetailId = reader["RefDetailID"].AsString(),
            RefId = reader["RefID"].AsString(),
            FixedAssetId = reader["FixedAssetID"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            AnnualDepreciationRate = reader["AnnualDepreciationRate"].AsDecimal(),
            AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
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
            ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
            TaskId = reader["TaskID"].AsString(),
            ListItemId = reader["ListItemID"].AsString(),
            SortOrder = reader["SortOrder"].AsInt(),
            BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
            FundStructureId = reader["FundStructureID"].AsString(),
            ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
            ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
            BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
            TopicId = reader["TopicID"].AsString(),
            DepartmentId = reader["DepartmentID"].AsString(),
            BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
            DevaluationAmount = reader["DevaluationAmount"].AsDecimal(),
            ContractId = reader["ContractID"].AsString(),
            CapitalPlanId = reader["CapitalPlanID"].AsString(),
        };

        /// <summary>
        /// The make new voucher
        /// </summary>
        private static readonly Func<IDataReader, FADepreciationDetailEntity> MakeNewVoucher = reader =>
        new FADepreciationDetailEntity
        {

            FixedAssetId = reader["FixedAssetID"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            Source = reader["Source"].AsInt(),
            BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
            BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
            BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
            DebitAccount = reader["DebitAccount"].AsString(),
            CreditAccount = reader["CreditAccount"].AsString(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            Amount = reader["Amount"].AsDecimal(),
            AnnualDepreciationRate = reader["AnnualDepreciationRate"].AsDecimal(),
            BudgetSourceId = reader["DefaultBudgetSource"].AsString(),
            AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
        };

        /// <summary>
        /// The make new devaluation voucher
        /// </summary>
        private static readonly Func<IDataReader, FADepreciationDetailEntity> MakeNewDevaluationVoucher = reader =>
        new FADepreciationDetailEntity
        {

            FixedAssetId = reader["FixedAssetID"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            Source = reader["Source"].AsInt(),
            BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
            BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
            BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
            DebitAccount = reader["DebitAccount"].AsString(),
            CreditAccount = reader["CreditAccount"].AsString(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            Amount = reader["AnnualDepreciationAmount"].AsDecimal(),
            AnnualDepreciationRate = reader["AnnualDepreciationRate"].AsDecimal(),
            AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
            BudgetSourceId = reader["DefaultBudgetSource"].AsString(),
            MethodDistributeId = reader["DefaultMethodDistributeID"].AsInt(),
            CashWithDrawTypeId = reader["DefaultCashWithDrawTypeID"].AsInt(),
        };

        /// <summary>
        /// Takes the specified f a depreciation detail entity.
        /// </summary>
        /// <param name="fADepreciationDetailEntity">The f a depreciation detail entity.</param>
        /// <returns></returns>
        private static object[] Take(FADepreciationDetailEntity fADepreciationDetailEntity)
        {
            return new object[]
                {

                    "@RefDetailID", fADepreciationDetailEntity.RefDetailId,
                    "@RefID", fADepreciationDetailEntity.RefId,
                    "@FixedAssetID", fADepreciationDetailEntity.FixedAssetId,
                    "@FixedAssetName", fADepreciationDetailEntity.FixedAssetName,
                    "@OrgPrice", fADepreciationDetailEntity.OrgPrice,
                    "@AnnualDepreciationRate", fADepreciationDetailEntity.AnnualDepreciationRate,
                    "@AnnualDepreciationAmount", fADepreciationDetailEntity.AnnualDepreciationAmount,
                    "@Description", fADepreciationDetailEntity.Description,
                    "@DebitAccount", fADepreciationDetailEntity.DebitAccount,
                    "@CreditAccount", fADepreciationDetailEntity.CreditAccount,
                    "@Amount", fADepreciationDetailEntity.Amount,
                    "@BudgetSourceID", fADepreciationDetailEntity.BudgetSourceId,
                    "@BudgetChapterCode", fADepreciationDetailEntity.BudgetChapterCode,
                    "@BudgetKindItemCode", fADepreciationDetailEntity.BudgetKindItemCode,
                    "@BudgetSubKindItemCode", fADepreciationDetailEntity.BudgetSubKindItemCode,
                    "@BudgetItemCode", fADepreciationDetailEntity.BudgetItemCode,
                    "@BudgetSubItemCode", fADepreciationDetailEntity.BudgetSubItemCode,
                    "@MethodDistributeID", fADepreciationDetailEntity.MethodDistributeId,
                    "@CashWithDrawTypeID", fADepreciationDetailEntity.CashWithDrawTypeId,
                    "@AccountingObjectID", fADepreciationDetailEntity.AccountingObjectId,
                    "@ActivityID", fADepreciationDetailEntity.ActivityId,
                    "@ProjectID", fADepreciationDetailEntity.ProjectId,
                    "@ProjectActivityID", fADepreciationDetailEntity.ProjectActivityId,
                    "@ProjectExpenseID", fADepreciationDetailEntity.ProjectExpenseId,
                    "@TaskID", fADepreciationDetailEntity.TaskId,
                    "@ListItemID", fADepreciationDetailEntity.ListItemId,
                    "@SortOrder", fADepreciationDetailEntity.SortOrder,
                    "@BudgetDetailItemCode", fADepreciationDetailEntity.BudgetDetailItemCode,
                    "@FundStructureID", fADepreciationDetailEntity.FundStructureId,
                    "@ProjectExpenseEAID", fADepreciationDetailEntity.ProjectExpenseEAId,
                    "@ProjectActivityEAID", fADepreciationDetailEntity.ProjectActivityEAId,
                    "@BudgetProvideCode", fADepreciationDetailEntity.BudgetProvideCode,
                    "@TopicID", fADepreciationDetailEntity.TopicId,
                    "@BudgetExpenseID", fADepreciationDetailEntity.BudgetExpenseId,
                    "@ContractID", fADepreciationDetailEntity.ContractId,
                    "@CapitalPlanID", fADepreciationDetailEntity.CapitalPlanId,
                     "@IsParallel", fADepreciationDetailEntity.IsParallel,
                };
        }
    }
}
