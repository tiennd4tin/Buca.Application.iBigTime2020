/***********************************************************************
 * <copyright file="Mapper.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 08 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAsset;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAssetArmortization;
using Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAssetIncrement;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Search;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Report;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Report.FixedAsset;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;
using Buca.Application.iBigTime2020.BusinessEntities.Salary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Model.BusinessObjects.FixedAsset;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Inventory;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Estimate;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.FixedAsset;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Salary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAssetDecrement;
using System;
using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Search;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.BusinessEntities.System;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Inventory;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Inventory;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Cash;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Cash;
using System.Reflection;
using Buca.Application.iBigTime2020.BusinessEntities;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Ledger;
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Ledger;

/// <summary>
/// The DataTransferObjectMapper namespace.
/// </summary>
namespace Buca.Application.iBigTime2020.Model.DataTransferObjectMapper
{
    /// <summary>ToDataTransferObject
    /// Class Mapper.
    /// </summary>
    public class Mapper
    {
        #region FromDataTransferObject
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static OriginalGeneralLedgerModel FromDataTransferObject(OriginalGeneralLedgerEntity entity)
        {
            if (entity == null)
                return null;
            return new OriginalGeneralLedgerModel
            {
                OriginalGeneralLedgerId = entity.OriginalGeneralLedgerId,
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                RefType = entity.RefType,
                RefNo = entity.RefNo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate.ToString() == "01/01/0001 12:00:00 SA" ? entity.RefDate : entity.PostedDate,
                InvNo = entity.InvNo,
                InvDate = entity.InvDate,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                AmountOC = entity.AmountOC,
                Amount = entity.Amount,
                JournalMemo = entity.JournalMemo,
                Description = entity.Description,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                CreditAccountingObjectId = entity.CreditAccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ListItemId = entity.ListItemId,
                PurchasePurposeId = entity.PurchasePurposeId,
                PurchasePurposeCode = entity.PurchasePurposeCode,
                OrgPrice = entity.OrgPrice,
                BankId = entity.BankId,
                BankName = entity.BankName,
                ToBankId = entity.ToBankId,
                Approved = entity.Approved,
                InvType = entity.InvType,
                TaxAccount = entity.TaxAccount,
                TaxAmount = entity.TaxAmount,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                SortOrder = entity.SortOrder,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BudgetProvideCode = entity.BudgetProvideCode,
                DepartmentName = entity.DepartmentName,
                FixedAssetCode = entity.FixedAssetCode,
                ProjectExpenseId = entity.BudgetExpenseId,
                BudgetExpenseId = entity.BudgetExpenseId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BUVoucherListModel FromDataTransferObject(BUVoucherListEntity entity)
        {
            if (entity == null)
                return null;
            return new BUVoucherListModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                ParalellRefNo = entity.ParalellRefNo,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                JournalMemo = entity.JournalMemo,
                Posted = entity.Posted,
                TotalAmount = entity.TotalAmount,
                PostVersion = entity.PostVersion,
                EditVersion = entity.EditVersion,
                CurrencyCode = entity.CurrencyCode,
                TotalAmountOC = entity.TotalAmountOC,
                ExchangeRate = entity.ExchangeRate,
                BUVoucherListDetailModels = FromDataTransferObjects(entity.BUVoucherListDetailEntities),
                BUVoucherListDetailTransferModels = FromDataTransferObjects(entity.BUVoucherListDetailTransferEntities),
                BUVoucherListDetailParallelModels = FromDataTransferObjects(entity.BUVoucherListDetailParallelEntities)
            };
        }

        #region Get DashBoard 1
        internal static IList<UserControlMainDesktopModel> FromDataTransferObjects(
            IList<UserControlMainDesktopEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }


        internal static UserControlMainDesktopModel FromDataTransferObject(UserControlMainDesktopEntity entity)
        {
            if (entity == null)
                return null;
            return new UserControlMainDesktopModel
            {
                WithDraw = entity.WithDraw,
                Cancel = entity.Cancel,
                Remaining = entity.Remaining,
                BudgetSourceName = entity.BudgetSourceName,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSourceId = entity.BudgetSourceId
            };
        }
        #endregion

        #region Get DashBoard 2
        internal static IList<DashBoardBudgetModel> FromDataTransferObjects(
            IList<DashBoardBudgetEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }


        internal static DashBoardBudgetModel FromDataTransferObject(DashBoardBudgetEntity entity)
        {
            if (entity == null)
                return null;
            return new DashBoardBudgetModel
            {
                BudgetRecive = entity.BudgetRecive,
                BudgetGive = entity.BudgetGive,
                Remaining = entity.Remaining,
                BudgetSourceName = entity.BudgetSourceName,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSourceId = entity.BudgetSourceId
            };
        }
        #endregion

        #region Get DashBoard 3
        internal static IList<DashBoardCashModel> FromDataTransferObjects(
            IList<DashBoardCashEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }


        internal static DashBoardCashModel FromDataTransferObject(DashBoardCashEntity entity)
        {
            if (entity == null)
                return null;
            return new DashBoardCashModel
            {
                PrevCash = entity.PrevCash,
                PrevCashInBank = entity.PrevCashInBank,
                PrevCashInTransit = entity.PrevCashInTransit,
                PrevTime = entity.PrevTime,
                ThisCash = entity.ThisCash,
                ThisCashInBank = entity.ThisCashInBank,
                ThisCashInTransit = entity.ThisCashInTransit,
                ThisTime = entity.ThisTime,
                NextCash = entity.NextCash,
                NextCashInBank = entity.NextCashInBank,
                NextCashInTransit = entity.NextCashInTransit,
                NextTime = entity.NextTime
            };
        }
        #endregion

        #region Get DashBoard 4
        internal static IList<DashBoardAcitityModel> FromDataTransferObjects(
            IList<DashBoardActivityEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }


        internal static DashBoardAcitityModel FromDataTransferObject(DashBoardActivityEntity entity)
        {
            if (entity == null)
                return null;
            return new DashBoardAcitityModel
            {
                Time = entity.Time,
                Revenue = entity.Revenue,
                Expense = entity.Expense,
                Differences = entity.Differences,
            };
        }
        #endregion
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BUVoucherListDetailModel FromDataTransferObject(BUVoucherListDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BUVoucherListDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                VoucherRefType = entity.VoucherRefType,
                VoucherRefId = entity.VoucherRefId,
                VoucherRefDetailId = entity.VoucherRefDetailId,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                ProjectId = entity.ProjectId,
                ActivityId = entity.ActivityId,
                SortOrder = entity.SortOrder,
                Approved = entity.Approved,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                AmountOC = entity.AmountOC,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                FundStructureId = entity.FundStructureId,
                BankAccount = entity.BankAccount,
                AccountingObjectId = entity.AccountingObjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                ListItemId = entity.ListItemId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetProvideCode = entity.BudgetProvideCode,
                BudgetExpenseId = entity.BudgetExpenseId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BUVoucherListDetailParallelModel FromDataTransferObject(BUVoucherListDetailParallelEntity entity)
        {
            if (entity == null)
                return null;
            return new BUVoucherListDetailParallelModel
            {
                RefDetailId = entity.RefDetailId,
                ParentRefDetailId = entity.ParentRefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetProvideCode = entity.BudgetProvideCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                SortOrder = entity.SortOrder,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankAccount = entity.BankAccount,
                BudgetExpenseId = entity.BudgetExpenseId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BUVoucherListDetailTransferModel FromDataTransferObject(BUVoucherListDetailTransferEntity entity)
        {
            if (entity == null)
                return null;
            return new BUVoucherListDetailTransferModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                Amount = entity.Amount,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Description = entity.Description,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                AmountOC = entity.AmountOC,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                FundStructureId = entity.FundStructureId,
                BankAccount = entity.BankAccount,
                AccountingObjectId = entity.AccountingObjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                ListItemId = entity.ListItemId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetProvideCode = entity.BudgetProvideCode,
                BudgetExpenseId = entity.BudgetExpenseId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>AutoBusinessParallelModel.</returns>
        internal static AutoBusinessParallelModel FromDataTransferObject(AutoBusinessParallelEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new AutoBusinessParallelModel
            {
                AutoBusinessParallelId = entity.AutoBusinessParallelId,
                AutoBusinessCode = entity.AutoBusinessCode,
                AutoBusinessName = entity.AutoBusinessName,
                Description = entity.Description,
                IsActive = entity.IsActive,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                DebitAccountParallel = entity.DebitAccountParallel,
                CreditAccountParallel = entity.CreditAccountParallel,
                BudgetSourceIdParallel = entity.BudgetSourceIdParallel,
                BudgetChapterCodeParallel = entity.BudgetChapterCodeParallel,
                BudgetKindItemCodeParallel = entity.BudgetKindItemCodeParallel,
                BudgetSubKindItemCodeParallel = entity.BudgetSubKindItemCodeParallel,
                BudgetItemCodeParallel = entity.BudgetItemCodeParallel,
                BudgetSubItemCodeParallel = entity.BudgetSubItemCodeParallel,
                MethodDistributeIdParallel = entity.MethodDistributeIdParallel,
                CashWithDrawTypeIdParallel = entity.CashWithDrawTypeIdParallel,
                SortOrder = entity.SortOrder
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BudgetExpenseModel.</returns>
        internal static BudgetExpenseModel FromDataTransferObject(BudgetExpenseEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new BudgetExpenseModel
            {
                BudgetExpenseId = entity.BudgetExpenseId,
                BudgetExpenseCode = entity.BudgetExpenseCode,
                BudgetExpenseName = entity.BudgetExpenseName,
                IsActive = entity.IsActive,
                IsSystem = entity.IsSystem,
                BudgetExpenseType = entity.BudgetExpenseType
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FAIncrementDecrementModel FromDataTransferObject(FAIncrementDecrementEntity entity)
        {
            if (entity == null)
                return null;
            return new FAIncrementDecrementModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                ParalellRefNo = entity.ParalellRefNo,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                GeneratedRefId = entity.GeneratedRefId,
                FAIncrementDecrementDetails = FromDataTransferObjects(entity.FAIncrementDecrementDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>VoucherModel.</returns>
        internal static VoucherModel FromDataTransferObject(VoucherEntity entity)
        {
            if (entity == null)
                return null;
            return new VoucherModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefType = entity.RefType,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectAddress = entity.AccountingObjectAddress,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Description = entity.Description,
                Amount = entity.Amount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FAIncrementDecrementDetailModel FromDataTransferObject(FAIncrementDecrementDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new FAIncrementDecrementDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                DecreaseReasonId = entity.DecreaseReasonId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetProvidenceModel FromDataTransferObject(BudgetProvidenceEntity entity)
        {
            if (entity == null)
                return null;
            return new BudgetProvidenceModel
            {
                BudgetProvideId = entity.BudgetProvideId,
                BudgetProvideCode = entity.BudgetProvideCode,
                BudgetProvideName = entity.BudgetProvideName,
                IsSystem = entity.IsSystem,
                IsActive = entity.IsActive
            };
        }


        internal static FAAdjustmentModel FromDataTransferObjectFA(FAAdjustmentEntity entity)
        {
            if (entity == null)
                return null;
            return new FAAdjustmentModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                ParalellRefNo = entity.ParalellRefNo,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetName = entity.FixedAssetName,
                NewOrgPrice = entity.NewOrgPrice,
                OldOrgPrice = entity.OldOrgPrice,
                DiffOrgPrice = entity.DiffOrgPrice,
                NewDevaluationAmount = entity.NewDevaluationAmount,
                OldDevaluationAmount = entity.OldDevaluationAmount,
                DiffDevaluationAmount = entity.DiffDevaluationAmount,
                NewAccumDevaluationAmount = entity.NewAccumDevaluationAmount,
                OldAccumDevaluationAmount = entity.OldAccumDevaluationAmount,
                DiffAccumDevaluationAmount = entity.DiffAccumDevaluationAmount,
                NewRemainingAmount = entity.NewRemainingAmount,
                OldRemainingAmount = entity.OldRemainingAmount,
                DiffRemainingAmount = entity.DiffRemainingAmount,
                NewQuantity = entity.NewQuantity,
                OldQuantity = entity.OldQuantity,
                DiffQuantity = entity.DiffQuantity,
                OldAnnualDepreciationAmount = entity.OldAnnualDepreciationAmount,
                NewAnnualDepreciationAmount = entity.NewAnnualDepreciationAmount,
                NewAccumDepreciationAmount = entity.NewAccumDepreciationAmount,
                DiffAccumDepreciationAmount = entity.DiffAccumDepreciationAmount,
                DiffAnnualDepreciationAmount = entity.DiffAnnualDepreciationAmount,
                OldAccumDepreciationAmount = entity.OldAccumDepreciationAmount,
                FAAdjustmentDetails = FromDataTransferObjects(entity.FAAdjustmentDetails),
                FAAdjustmentDetailParallels = FromDataTransferObjects(entity.FAAdjustmentDetailParallels)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FAAdjustmentDetailModel FromDataTransferObject(FAAdjustmentDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new FAAdjustmentDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                BudgetChapterCode = entity.BudgetChapterCode,
                AccountingObjectId = entity.AccountingObjectId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetProvideCode = entity.BudgetProvideCode,
                TopicId = entity.TopicId,
                BudgetExpenseId = entity.BudgetExpenseId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                BankId = entity.BankId,
                FundStructureId = entity.FundStructureId,
                ActivityId = entity.ActivityId

            };
        }
        internal static FAAdjustmentDetailParallelModel FromDataTransferObject(FAAdjustmentDetailParallelEntity entity)
        {
            if (entity == null)
                return null;
            return new FAAdjustmentDetailParallelModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                BudgetChapterCode = entity.BudgetChapterCode,
                AccountingObjectId = entity.AccountingObjectId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetProvideCode = entity.BudgetProvideCode,
                TopicId = entity.TopicId,
                BudgetExpenseId = entity.BudgetExpenseId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                BankId = entity.BankId,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                FundStructureId = entity.FundStructureId,
                ActivityId = entity.ActivityId
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static SUIncrementDecrementModel FromDataTransferObject(SUIncrementDecrementEntity entity)
        {
            if (entity == null)
                return null;
            return new SUIncrementDecrementModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                ParalellRefNo = entity.ParalellRefNo,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                EditVersion = entity.EditVersion,
                SUIncrementDecrementDetails = FromDataTransferObjects(entity.SUIncrementDecrementDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static SUIncrementDecrementDetailModel FromDataTransferObject(SUIncrementDecrementDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new SUIncrementDecrementDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                InventoryItemId = entity.InventoryItemId,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Quantity = entity.Quantity,
                QuantityConvert = entity.QuantityConvert,
                UnitPrice = entity.UnitPrice,
                UnitPriceConvert = entity.UnitPriceConvert,
                Amount = entity.Amount,
                BudgetChapterCode = entity.BudgetChapterCode,
                AccountingObjectId = entity.AccountingObjectId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetProvideCode = entity.BudgetProvideCode,
                TopicId = entity.TopicId,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static SUTransferModel FromDataTransferObject(SUTransferEntity entity)
        {
            if (entity == null)
                return null;
            return new SUTransferModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                ParalellRefNo = entity.ParalellRefNo,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                EditVersion = entity.EditVersion,
                SUTransferDetails = FromDataTransferObjects(entity.SUTransferDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static SUTransferDetailModel FromDataTransferObject(SUTransferDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new SUTransferDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                InventoryItemId = entity.InventoryItemId,
                Description = entity.Description,
                FromDepartmentId = entity.FromDepartmentId,
                ToDepartmentId = entity.ToDepartmentId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                Amount = entity.Amount,
                BudgetChapterCode = entity.BudgetChapterCode,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FADepreciationModel FromDataTransferObject(FADepreciationEntity entity)
        {
            if (entity == null)
                return null;
            return new FADepreciationModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                ParalellRefNo = entity.ParalellRefNo,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                PeriodType = entity.PeriodType,
                PeriodTypeName = entity.PeriodTypeName,
                FADepreciationDetails = FromDataTransferObjects(entity.FADepreciationDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FADepreciationDetailModel FromDataTransferObject(FADepreciationDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new FADepreciationDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetName = entity.FixedAssetName,
                OrgPrice = entity.OrgPrice,
                AnnualDepreciationRate = entity.AnnualDepreciationRate,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                //Description = entity.Description,
                Description = "Hao mòn tài sản cố định",
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                FundStructureId = entity.FundStructureId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetProvideCode = entity.BudgetProvideCode,
                TopicId = entity.TopicId,
                DepartmentId = entity.DepartmentId,
                DevaluationAmount = entity.DevaluationAmount,
                BudgetExpenseId = entity.BudgetExpenseId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                IsParallel = entity.IsParallel
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BAWithDrawModel FromDataTransferObject(BAWithDrawEntity entity)
        {
            if (entity == null)
                return null;
            return new BAWithDrawModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                ParalellRefNo = entity.ParalellRefNo,
                InwardRefNo = entity.InwardRefNo,
                IncrementRefNo = entity.IncrementRefNo,
                BankId = entity.BankId,
                BankName = entity.BankName,
                JournalMemo = entity.JournalMemo,
                AccountingObjectId = entity.AccountingObjectId,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                TotalTaxAmount = entity.TotalTaxAmount,
                TotalFreightAmount = entity.TotalFreightAmount,
                TotalInwardAmount = entity.TotalInwardAmount,
                Reconciled = entity.Reconciled,
                Posted = entity.Posted,
                PostVersion = entity.PostVersion,
                EditVersion = entity.EditVersion,
                RefOrder = entity.RefOrder,
                RelationRefId = entity.RelationRefId,
                RelationType = entity.RelationType,
                AccountingObjectBankAccount = entity.AccountingObjectBankAccount,
                TotalPaymentAmount = entity.TotalPaymentAmount,
                BAWithDrawDetails = FromDataTransferObjects(entity.BAWithDrawDetails),
                BAWithDrawDetailFixedAssets = FromDataTransferObjects(entity.BAWithDrawDetailFixedAssets),
                BAWithDrawDetailPurchases = FromDataTransferObjects(entity.BAWithDrawDetailPurchases),
                BAWithdrawDetailSalarys = FromDataTransferObjects(entity.BAWithdrawDetailSalarys),
                BAWithdrawDetailTaxs = FromDataTransferObjects(entity.BAWithdrawDetailTaxs),
                BAWithDrawDetailParallels = FromDataTransferObjects(entity.BAWithDrawDetailParallels),
                ReceiveName = entity.ReceiveName,
                ReceiveId = entity.ReceiveId,
                ReceiveIssueDate = entity.ReceiveIssueDate,
                ReceiveIssueLocation = entity.ReceiveIssueLocation,
            };
        }
        internal static BAWithDrawModel FromDataTransferObjectCA(CAPaymentEntity entity)
        {
            if (entity == null)
                return null;
            return new BAWithDrawModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                ParalellRefNo = entity.ParalellRefNo,
                InwardRefNo = entity.InwardRefNo,
                IncrementRefNo = entity.IncrementRefNo,
                BankId = entity.BankId,
                //   BankName = entity.BankName,
                JournalMemo = entity.JournalMemo,
                AccountingObjectId = entity.AccountingObjectId,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                TotalTaxAmount = entity.TotalTaxAmount,
                TotalFreightAmount = entity.TotalFreightAmount,
                TotalInwardAmount = entity.TotalInwardAmount,
                //  Reconciled = entity.Reconciled,
                Posted = entity.Posted,
                // PostVersion = entity.PostVersion,
                // EditVersion = entity.EditVersion,
                RefOrder = entity.RefOrder,
                RelationRefId = entity.RelationRefId,
                // RelationType = entity.RelationType,
                TotalPaymentAmount = entity.TotalPaymentAmount,
                BAWithDrawDetails = FromDataTransferObjectsCA(entity.CaPaymentDetails),
                BAWithDrawDetailFixedAssets = FromDataTransferObjectsCA(entity.CAPaymentDetailFixedAssets),
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BAWithDrawDetailModel FromDataTransferObject(BAWithDrawDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BAWithDrawDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                FundId = entity.FundId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                OrgRefNo = entity.OrgRefNo,//entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetExpenseId = entity.BudgetExpenseId,
                BankId = entity.BankId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                AutoBusinessId = entity.AutoBusinessId
            };
        }
        internal static BAWithDrawDetailModel FromDataTransferObjectCA(CAPaymentDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BAWithDrawDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                //  FundId = entity.FundId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                OrgRefNo = entity.OrgRefNo,//entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetExpenseId = entity.BudgetExpenseId,
                BankId = entity.BankId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                AutoBusinessId = entity.AutoBusinessId
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BAWithDrawDetailFixedAssetModel FromDataTransferObject(BAWithDrawDetailFixedAssetEntity entity)
        {
            if (entity == null)
                return null;
            return new BAWithDrawDetailFixedAssetModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                TaxRate = entity.TaxRate,
                TaxAmount = entity.TaxAmount,
                TaxAccount = entity.TaxAccount,
                InvType = entity.InvType,
                InvDate = entity.InvDate,
                InvSeries = entity.InvSeries,
                InvNo = entity.InvNo,
                PurchasePurposeId = entity.PurchasePurposeId,
                FreightAmount = entity.FreightAmount,
                OrgPrice = entity.OrgPrice,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                FundId = entity.FundId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                InvoiceTypeCode = entity.InvoiceTypeCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetExpenseId = entity.BudgetExpenseId
            };
        }
        internal static BAWithDrawDetailFixedAssetModel FromDataTransferObjectCA(CAPaymentDetailFixedAssetEntity entity)
        {
            if (entity == null)
                return null;
            return new BAWithDrawDetailFixedAssetModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                TaxRate = entity.TaxRate,
                TaxAmount = entity.TaxAmount,
                TaxAccount = entity.TaxAccount,
                InvType = entity.InvType,
                InvDate = entity.InvDate,
                InvSeries = entity.InvSeries,
                InvNo = entity.InvNo,
                PurchasePurposeId = entity.PurchasePurposeId,
                FreightAmount = entity.FreightAmount,
                OrgPrice = entity.OrgPrice,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                FundId = entity.FundId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                InvoiceTypeCode = entity.InvoiceTypeCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetExpenseId = entity.BudgetExpenseId
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BAWithDrawDetailPurchaseModel FromDataTransferObject(BAWithDrawDetailPurchaseEntity entity)
        {
            if (entity == null)
                return null;
            return new BAWithDrawDetailPurchaseModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                InventoryItemId = entity.InventoryItemId,
                Description = entity.Description,
                StockId = entity.StockId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Unit = entity.Unit,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                QuantityConvert = entity.QuantityConvert,
                UnitPriceConvert = entity.UnitPriceConvert,
                Amount = entity.Amount,
                TaxRate = entity.TaxRate,
                TaxAmount = entity.TaxAmount,
                TaxAccount = entity.TaxAccount,
                InvType = entity.InvType,
                InvDate = entity.InvDate,
                InvSeries = entity.InvSeries,
                InvNo = entity.InvNo,
                PurchasePurposeId = entity.PurchasePurposeId,
                FreightAmount = entity.FreightAmount,
                InwardAmount = entity.InwardAmount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                FundId = entity.FundId,
                ListItemId = entity.ListItemId,
                ExpiryDate = entity.ExpiryDate,
                LotNo = entity.LotNo,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                InvoiceTypeCode = entity.InvoiceTypeCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetExpenseId = entity.BudgetExpenseId,
                BankId = entity.BankId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BAWithdrawDetailSalaryModel FromDataTransferObject(BAWithdrawDetailSalaryEntity entity)
        {
            if (entity == null)
                return null;
            return new BAWithdrawDetailSalaryModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                EmployeeId = entity.EmployeeId,
                NetWageAmount = entity.NetWageAmount,
                SortOrder = entity.SortOrder,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BAWithdrawDetailTaxModel FromDataTransferObject(BAWithdrawDetailTaxEntity entity)
        {
            if (entity == null)
                return null;
            return new BAWithdrawDetailTaxModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                VATAmount = entity.VATAmount,
                VATRate = entity.VATRate,
                TurnOver = entity.TurnOver,
                InvType = entity.InvType,
                InvDate = entity.InvDate,
                InvSeries = entity.InvSeries,
                InvNo = entity.InvNo,
                PurchasePurposeId = entity.PurchasePurposeId,
                AccountingObjectId = entity.AccountingObjectId,
                CompanyTaxCode = entity.CompanyTaxCode,
                SortOrder = entity.SortOrder,
                InvoiceTypeCode = entity.InvoiceTypeCode,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BADepositModel FromDataTransferObject(BADepositEntity entity)
        {
            if (entity == null)
                return null;

            return new BADepositModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                ParalellRefNo = entity.ParalellRefNo,
                OutwardRefNo = entity.OutwardRefNo,
                AccountingObjectId = entity.AccountingObjectId,
                BankId = entity.BankId,
                InvType = entity.InvType,
                InvDate = entity.InvDate,
                InvSeries = entity.InvSeries,
                InvNo = entity.InvNo,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                TotalTaxAmount = entity.TotalTaxAmount,
                TotalOutwardAmount = entity.TotalOutwardAmount,
                Reconciled = entity.Reconciled,
                Posted = entity.Posted,
                PostVersion = entity.PostVersion,
                EditVersion = entity.EditVersion,
                RefOrder = entity.RefOrder,
                InvoiceForm = entity.InvoiceForm,
                InvoiceFormNumberId = entity.InvoiceFormNumberId,
                InvSeriesPrefix = entity.InvSeriesPrefix,
                InvSeriesSuffix = entity.InvSeriesSuffix,
                PayForm = entity.PayForm,
                ComPanyTaxcode = entity.ComPanyTaxcode,
                AccountingObjectContactName = entity.AccountingObjectContactName,
                ListNo = entity.ListNo,
                ListDate = entity.ListDate,
                IsAttachList = entity.IsAttachList,
                ListCommonNameInventory = entity.ListCommonNameInventory,
                BUCommitmentRequestId = entity.BUCommitmentRequestId,
                TotalReceiptAmount = entity.TotalReceiptAmount,
                BADepositDetailModels = FromDataTransferObjects(entity.BADepositDetails),
                BADepositDetailFixedAssetModels = FromDataTransferObjects(entity.BADepositDetailFixedAssetEntities),
                BADepositDetailSaleModels = FromDataTransferObjects(entity.BADepositDetailSaleEntities),
                BADepositDetailTaxModels = FromDataTransferObjects(entity.BADepositDetailTaxEntities),
                BADepositDetailParallels = FromDataTransferObjects(entity.BADepositDetailParallels),
                Payer = entity.Payer
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BUTransferModel.</returns>
        internal static BUTransferModel FromDataTransferObject(BUTransferEntity entity)
        {
            if (entity == null)
                return null;
            return new BUTransferModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                ParalellRefNo = entity.ParalellRefNo,
                JournalMemo = entity.JournalMemo,
                TargetProgramId = entity.TargetProgramId,
                BankInfoId = entity.BankInfoId,
                AccountingObjectId = entity.AccountingObjectId,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectAddress = entity.AccountingObjectAddress,
                AccountingObjectBankAccount = entity.AccountingObjectBankAccount,
                AccountingObjectBankName = entity.AccountingObjectBankName,
                DocumentIncluded = entity.DocumentIncluded,
                InwardStockRefNo = entity.InwardStockRefNo,
                WithdrawRefDate = entity.WithdrawRefDate,
                WithdrawRefNo = entity.WithdrawRefNo,
                IncrementRefNo = entity.IncrementRefNo,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                TotalTaxAmount = entity.TotalTaxAmount,
                TotalFreightAmount = entity.TotalFreightAmount,
                TotalInwardAmount = entity.TotalInwardAmount,
                Posted = entity.Posted,
                PostVersion = entity.PostVersion,
                EditVersion = entity.EditVersion,
                RefOrder = entity.RefOrder,
                RelationRefId = entity.RelationRefId,
                LinkRefNo = entity.LinkRefNo,
                BUCommitmentRequestId = entity.BUCommitmentRequestId,
                TotalFixedAssetAmount = entity.TotalFixedAssetAmount,
                BUTransferDetails = FromDataTransferObjects(entity.BUTransferDetails),
                BUTransferDetailParallel = FromDataTransferObjects(entity.BUTransferDetailParallels),
                gLVouchersRefId = entity.gLVouchersRefId,
                BUTransferDetailPurchases = entity.BUTransferDetailPurchases?.Select(m => AutoMapper(m, new BUTransferDetailPurchaselModel())).ToList(),
                BUTransferDetailFixedAssets = entity.BUTransferDetailFixedAssets?.Select(m => AutoMapper(m, new BUTransferDetailFixedAssetlModel())).ToList(),
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BUTransferDetailModel.</returns>
        internal static BUTransferDetailModel FromDataTransferObject(BUTransferDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BUTransferDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                FundId = entity.FundId,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                WithdrawRefDetailId = entity.WithdrawRefDetailId,
                BudgetProvideCode = entity.BudgetProvideCode,
                TopicId = entity.TopicId,
                BankId = entity.BankId,
                BudgetExpenseId = entity.BudgetExpenseId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                AdvanceRecovery = entity.AdvanceRecovery,
                AutoBusinessID = entity.AutoBusinessID,
                OldAdvanceRecovery = entity.OldAdvanceRecovery
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>INInwardOutwardModel.</returns>
        internal static INInwardOutwardModel FromDataTransferObject(INInwardOutwardEntity entity)
        {
            if (entity == null)
                return null;
            return new INInwardOutwardModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                ParalellRefNo = entity.ParalellRefNo,
                AccountingObjectId = entity.AccountingObjectId,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                TotalTaxAmount = entity.TotalTaxAmount,
                GeneratedRefId = entity.GeneratedRefId,
                RefOrder = entity.RefOrder,
                InwardOutwardDetails = FromDataTransferObjects(entity.InwardOutwardDetails),
                DocumentInclued = entity.DocumentInclued,
                InwardOutwardDetailParallels = FromDataTransferObjects(entity.INInwardOutwardDetailParallels),
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>INInwardOutwardDetailParallelModel.</returns>
        internal static INInwardOutwardDetailParallelModel FromDataTransferObject(INInwardOutwardDetailParallelEntity entity)
        {
            if (entity == null)
                return null;
            return new INInwardOutwardDetailParallelModel
            {
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                Approved = entity.Approved,
                AutoBusinessId = entity.AutoBusinessId,
                BankId = entity.BankId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                BudgetExpenseId = entity.BudgetExpenseId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetProvideCode = entity.BudgetProvideCode,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                CapitalPlanId = entity.CapitalPlanId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                ContractId = entity.ContractId,
                CreditAccount = entity.CreditAccount,
                DebitAccount = entity.DebitAccount,
                Description = entity.Description,
                FundStructureId = entity.FundStructureId,
                ListItemId = entity.ListItemId,
                MethodDistributeId = entity.MethodDistributeId,
                OrgRefDate = entity.OrgRefDate,
                OrgRefNo = entity.OrgRefNo,
                ProjectId = entity.ProjectId,
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                SortOrder = entity.SortOrder,
                TaskId = entity.TaskId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                InventoryItemId = entity.InventoryItemId,
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BADepositDetailModel FromDataTransferObject(BADepositDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BADepositDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                FundStructureId = entity.FundStructureId,
                BudgetExpenseId = entity.BudgetExpenseId,
                BankId = entity.BankId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                AutoBusinessId = entity.AutoBusinessId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>INInwardOutwardDetailModel.</returns>
        internal static INInwardOutwardDetailModel FromDataTransferObject(INInwardOutwardDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new INInwardOutwardDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                InventoryItemId = entity.InventoryItemId,
                Description = entity.Description,
                StockId = entity.StockId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Unit = entity.Unit,
                Quantity = entity.Quantity,
                QuantityConvert = entity.QuantityConvert,
                UnitPrice = entity.UnitPrice,
                UnitPriceConvert = entity.UnitPriceConvert,
                Amount = entity.Amount,
                AmountExchange = entity.AmountOC,
                OutwardPurpose = entity.OutwardPurpose,
                TaxRate = entity.TaxRate,
                TaxAmount = entity.TaxAmount,
                InwardAmount = entity.InwardAmount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                DepartmentId = entity.DepartmentId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ListItemId = entity.ListItemId,
                ConfrontingRefId = entity.ConfrontingRefId,
                ConfrontingRefNo = entity.ConfrontingRefNo,
                ExpiryDate = entity.ExpiryDate,
                LotNo = entity.LotNo,
                Approved = entity.Approved,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetExpenseId = entity.BudgetExpenseId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                AutoBusinessId = entity.AutoBusinessId,


            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BADepositDetailFixedAssetModel FromDataTransferObject(BADepositDetailFixedAssetEntity entity)
        {
            if (entity == null)
                return null;
            return new BADepositDetailFixedAssetModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                TaxRate = entity.TaxRate,
                TaxAmount = entity.TaxAmount,
                TaxAccount = entity.TaxAccount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                FundStructureId = entity.FundStructureId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BADepositDetailSaleModel FromDataTransferObject(BADepositDetailSaleEntity entity)
        {
            if (entity == null)
                return null;
            return new BADepositDetailSaleModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                InventoryItemId = entity.InventoryItemId,
                Description = entity.Description,
                StockId = entity.StockId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Unit = entity.Unit,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                QuantityConvert = entity.QuantityConvert,
                UnitPriceConvert = entity.UnitPriceConvert,
                Amount = entity.Amount,
                TaxRate = entity.TaxRate,
                TaxAmount = entity.TaxAmount,
                TaxAccount = entity.TaxAccount,
                OutwardPrice = entity.OutwardPrice,
                OutwardAmount = entity.OutwardAmount,
                InventoryAccount = entity.InventoryAccount,
                COGSAccount = entity.COGSAccount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                ListItemId = entity.ListItemId,
                ConfrontingRefId = entity.ConfrontingRefId,
                ConfrontingRefNo = entity.ConfrontingRefNo,
                ExpiryDate = entity.ExpiryDate,
                LotNo = entity.LotNo,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                FundStructureId = entity.FundStructureId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                DiscountRate = entity.DiscountRate,
                DiscountAmount = entity.DiscountAmount,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BABankTransferModel.</returns>
        internal static BABankTransferModel FromDataTransferObject(BABankTransferEntity entity)
        {
            if (entity == null)
                return null;
            return new BABankTransferModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                ParalellRefNo = entity.ParalellRefNo,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                Posted = entity.Posted,
                PostVersion = entity.PostVersion,
                EditVersion = entity.EditVersion,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountOC = entity.TotalAmountOC,
                BABankTransferDetail = entity.BABankTransferDetails == null ? new List<BABankTransferDetailModel>() : FromDataTransferObjects(entity.BABankTransferDetails),
                BABankTransferDetailParallels = entity.BABankTransferDetailParallels == null ? new List<BABankTransferDetailParallelModel>() : FromDataTransferObjects(entity.BABankTransferDetailParallels)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BABankTransferDetailModel.</returns>
        internal static BABankTransferDetailModel FromDataTransferObject(BABankTransferDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BABankTransferDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                FromBankId = entity.FromBankId,
                ToBankId = entity.ToBankId,
                Amount = entity.Amount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                AmountOC = entity.AmountOC,
                FundStructureId = entity.FundStructureId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetExpenseId = entity.BudgetExpenseId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BADepositDetailTaxModel FromDataTransferObject(BADepositDetailTaxEntity entity)
        {
            if (entity == null)
                return null;
            return new BADepositDetailTaxModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                VATAmount = entity.VATAmount,
                VATRate = entity.VATRate,
                TurnOver = entity.TurnOver,
                InvType = entity.InvType,
                InvDate = entity.InvDate,
                InvSeries = entity.InvSeries,
                InvNo = entity.InvNo,
                PurchasePurposeId = entity.PurchasePurposeId,
                AccountingObjectId = entity.AccountingObjectId,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectAddress = entity.AccountingObjectAddress,
                CompanyTaxCode = entity.CompanyTaxCode,
                SortOrder = entity.SortOrder,
                InvoiceTypeCode = entity.InvoiceTypeCode,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BUCommitmentRequestModel.</returns>
        internal static BUCommitmentRequestModel FromDataTransferObject(BUCommitmentRequestEntity entity)
        {
            if (entity == null)
                return null;
            return new BUCommitmentRequestModel
            {
                RefId = entity.RefId,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo.Trim(),
                RefType = entity.RefType,
                AccountingObjectId = entity.AccountingObjectId,
                AccountingObjectName = entity.AccountingObjectName,
                TABMISCode = entity.TABMISCode,
                BankAccount = entity.BankAccount,
                BankName = entity.BankName,
                ContractNo = entity.ContractNo,
                ContractFrameNo = entity.ContractFrameNo,
                BudgetSourceKind = entity.BudgetSourceKind,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                IsForeignCurrency = entity.IsForeignCurrency,
                Posted = entity.Posted,
                EditVersion = entity.EditVersion,
                PostVersion = entity.PostVersion,
                ProjectInvestmentCode = entity.ProjectInvestmentCode,
                ProjectInvestmentName = entity.ProjectInvestmentName,
                SignDate = entity.SignDate,
                ContractAmount = entity.ContractAmount,
                PrevYearCommitmentAmount = entity.PrevYearCommitmentAmount,
                BUCommitmentRequestDetails = FromDataTransferObjects(entity.BUCommitmentRequestDetails),
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BUCommitmentRequestDetailModel.</returns>
        internal static BUCommitmentRequestDetailModel FromDataTransferObject(BUCommitmentRequestDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BUCommitmentRequestDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                FundStructureId = entity.FundStructureId,
                SortOrder = entity.SortOrder,
                BankAccount = entity.BankAccount,
                BudgetProvideCode = entity.BudgetProvideCode,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BUCommitmentAdjustmentModel.</returns>
        internal static BUCommitmentAdjustmentModel FromDataTransferObject(BUCommitmentAdjustmentEntity entity)
        {
            if (entity == null)
                return null;
            return new BUCommitmentAdjustmentModel
            {
                RefId = entity.RefId,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                BUCommitmentRequestId = entity.BUCommitmentRequestId,
                ContractNo = entity.ContractNo,
                ContractFrameNo = entity.ContractFrameNo,
                RealContractNo = entity.RealContractNo,
                RefType = entity.RefType,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                IsForeignCurrency = entity.IsForeignCurrency,
                Posted = entity.Posted,
                EditVersion = entity.EditVersion,
                PostVersion = entity.PostVersion,
                IsSuggestAdjustment = entity.IsSuggestAdjustment,
                IsSuggestSupplement = entity.IsSuggestSupplement,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                AdjustmentProviderBankAccount = entity.AdjustmentProviderBankAccount,
                AdjustmentProviderBankName = entity.AdjustmentProviderBankName,
                BankAccount = entity.BankAccount == null ? string.Empty : entity.BankAccount,
                BankName = entity.BankName == null ? string.Empty : entity.BankName,
                BUCommitmentAdjustmentDetails = FromDataTransferObjects(entity.BUCommitmentAdjustmentDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BUCommitmentAdjustmentDetailModel.</returns>
        internal static BUCommitmentAdjustmentDetailModel FromDataTransferObject(BUCommitmentAdjustmentDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BUCommitmentAdjustmentDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                FundStructureId = entity.FundStructureId,
                SortOrder = entity.SortOrder,
                BankAccount = entity.BankAccount,
                BudgetProvideCode = entity.BudgetProvideCode,
                ToCurrencyCode = entity.ToCurrencyCode,
                ToExchangeRate = entity.ToExchangeRate,
                ToAmountOC = entity.ToAmountOC,
                ToAmount = entity.ToAmount,
                ToBudgetSourceId = entity.ToBudgetSourceId,
                ToBudgetProvideCode = entity.ToBudgetProvideCode,
                ToBudgetChapterCode = entity.ToBudgetChapterCode,
                ToBudgetKindItemCode = entity.ToBudgetKindItemCode,
                ToBudgetSubKindItemCode = entity.ToBudgetSubKindItemCode,
                ToBudgetItemCode = entity.ToBudgetItemCode,
                ToBudgetSubItemCode = entity.ToBudgetSubItemCode,
                ToProjectId = entity.ToProjectId,
                RemainAmountOC = entity.RemainAmountOC,
                RemainAmount = entity.RemainAmount,
                RemainExchangeRate = entity.RemainExchangeRate,
                RemainCurrencyCode = entity.RemainCurrencyCode,
                BUCommitmentRequestDetailId = entity.BUCommitmentRequestDetailId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>OpeningCommitmentModel.</returns>
        internal static OpeningCommitmentModel FromDataTransferObject(OpeningCommitmentEntity entity)
        {
            if (entity == null)
                return null;
            return new OpeningCommitmentModel
            {
                RefId = entity.RefId,
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo.Trim(),
                RefType = entity.RefType,
                BudgetSourceKind = entity.BudgetSourceKind,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                IsForeignCurrency = entity.IsForeignCurrency,
                EditVersion = entity.EditVersion,
                PostVersion = entity.PostVersion,
                AccountingObjectId = entity.AccountingObjectId,
                AccountingObjectName = entity.AccountingObjectName,
                TABMISCode = entity.TABMISCode,
                BankAccount = entity.BankAccount,
                BankName = entity.BankName,
                ContractNo = entity.ContractNo,
                ContractFrameNo = entity.ContractFrameNo,
                ProjectInvestmentCode = entity.ProjectInvestmentCode,
                ProjectInvestmentName = entity.ProjectInvestmentName,
                SignDate = entity.SignDate,
                ContractAmount = entity.ContractAmount,
                PrevYearCommitmentAmount = entity.PrevYearCommitmentAmount,
                OpeningCommitmentDetails = FromDataTransferObjects(entity.OpeningCommitmentDetails),

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>OpeningCommitmentDetailModel.</returns>
        internal static OpeningCommitmentDetailModel FromDataTransferObject(OpeningCommitmentDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new OpeningCommitmentDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                CurrencyId = entity.CurrencyId,
                ExchangeRate = entity.ExchangeRate,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                FundStructureId = entity.FundStructureId,
                BankAccount = entity.BankAccount,
                SortOrder = entity.SortOrder,
                BudgetProvideCode = entity.BudgetProvideCode,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>OpeningSupplyEntryModel.</returns>
        internal static OpeningSupplyEntryModel FromDataTransferObject(OpeningSupplyEntryEntity entity)
        {
            if (entity == null)
                return null;
            return new OpeningSupplyEntryModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                PostedDate = entity.PostedDate,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                AccountNumber = entity.AccountNumber,
                InventoryItemId = entity.InventoryItemId,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemName = entity.InventoryItemName,
                DepartmentId = entity.DepartmentId,
                BudgetChapterCode = entity.BudgetChapterCode,
                Quantity = entity.Quantity,
                UnitPriceOC = entity.UnitPriceOC,
                UnitPrice = entity.UnitPrice,
                AmountOC = entity.AmountOC,
                Amount = entity.Amount,
                PostVersion = entity.PostVersion,
                EditVersion = entity.EditVersion,
                SortOrder = entity.SortOrder,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static PurchasePurposeModel FromDataTransferObject(PurchasePurposeEntity entity)
        {
            if (entity == null)
                return null;
            return new PurchasePurposeModel
            {
                PurchasePurposeId = entity.PurchasePurposeId,
                PurchasePurposeCode = entity.PurchasePurposeCode,
                PurchasePurposeName = entity.PurchasePurposeName,
                Description = entity.Description,
                IsSystem = entity.IsSystem,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CashWithdrawTypeModel FromDataTransferObject(CashWithdrawTypeEntity entity)
        {
            if (entity == null)
                return null;
            return new CashWithdrawTypeModel
            {
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                CashWithdrawTypeName = entity.CashWithdrawTypeName,
                CashWithdrawNo = entity.CashWithdrawNo,
                SubSystemId = entity.SubSystemId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>LockModel.</returns>
        internal static LockModel FromDataTransferObject(LockEntity entity)
        {
            if (entity == null)
                return null;
            return new LockModel
            {
                LockDate = entity.LockDate,
                IsLock = entity.IsLock,
                Content = entity.Content
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>SalaryVoucherModel.</returns>
        internal static SalaryVoucherModel FromDataTransferObject(SalaryVoucherEntity entity)
        {
            if (entity == null)
                return null;
            return new SalaryVoucherModel
            {
                RefTypeId = entity.RefTypeId,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>AutoNumberListModel.</returns>
        internal static AutoNumberListModel FromDataTransferObject(AutoNumberListEntity entity)
        {
            if (entity == null)
                return null;
            return new AutoNumberListModel
            {
                TableCode = entity.TableCode,
                LengthOfValue = entity.LengthOfValue,
                Prefix = entity.Prefix,
                Suffix = entity.Suffix,
                TableName = entity.TableName,
                Value = entity.Value
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ElectricalWorkModel.</returns>
        internal static ElectricalWorkModel FromDataTransferObject(ElectricalWorkEntity model)
        {
            if (model == null)
                return null;
            return new ElectricalWorkModel
            {
                ElectricalWorkId = model.ElectricalWorkId,
                Name = model.Name,
                PostedDate = model.PostedDate
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>MutualModel.</returns>
        internal static MutualModel FromDataTransferObject(MutualEntity model)
        {
            if (model == null)
                return null;
            return new MutualModel
            {
                Address = model.Address,
                Area = model.Area,
                Description = model.Description,
                IsActive = model.IsActive,
                JobCandidate = model.JobCandidate,
                MutualCode = model.MutualCode,
                MutualId = model.MutualId,
                MutualName = model.MutualName,
                State = model.State,
                TotalFloor = model.TotalFloor,
                UseDate = model.UseDate
            };
        }

        internal static FeaturePermisionModel FromDataTransferObject(FeaturePermisionEntity model)
        {
            if (model == null)
                return null;
            return new FeaturePermisionModel
            {
                FeaturePermisionID = model.FeaturePermisionID,
                FeatureID = model.FeatureID,
                UserPermisionID = model.UserPermisionID,

            };
        }

        internal static UserFeaturePermisionModel FromDataTransferObject(UserFeaturePermisionEntity model)
        {
            if (model == null)
                return null;
            return new UserFeaturePermisionModel
            {
                UserFeaturePermisionID = model.UserFeaturePermisionID,
                UserPermisionID = model.UserPermisionID,
                FeatureID = model.FeatureID,
                UserProfileID = model.UserProfileID,
                IsActive = model.IsActive,
                FeaturesModel = FromDataTransferObject(model.FeatureEntity),
                UserPermisionModel = FromDataTransferObject(model.UserPermisionEntity)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GeneralDetailEntity ToDataTransferObject(GeneralVoucherDetailModel model)
        {
            if (model == null)
                return null;
            return new GeneralDetailEntity
            {
                RefId = model.RefId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                ProjectId = model.ProjectId,
                RefDetailId = model.RefDetailId,
                CurrencyCode = model.CurrencyCode,
                EmployeeId = model.EmployeeId,
                CustomerId = model.CustomerId,
                DepartmentId = model.DepartmentId,
                VendorId = model.VendorId,
                BankId = model.BankId,
                ExchangeRate = model.ExchangeRate

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>AutoBusinessParallelEntity.</returns>
        internal static AutoBusinessParallelEntity ToDataTransferObject(AutoBusinessParallelModel model)
        {
            if (model == null)
                return null;
            return new AutoBusinessParallelEntity
            {
                AutoBusinessParallelId = model.AutoBusinessParallelId,
                AutoBusinessCode = model.AutoBusinessCode,
                AutoBusinessName = model.AutoBusinessName,
                Description = model.Description,
                IsActive = model.IsActive,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                DebitAccountParallel = model.DebitAccountParallel,
                CreditAccountParallel = model.CreditAccountParallel,
                BudgetSourceIdParallel = model.BudgetSourceIdParallel,
                BudgetChapterCodeParallel = model.BudgetChapterCodeParallel,
                BudgetKindItemCodeParallel = model.BudgetKindItemCodeParallel,
                BudgetSubKindItemCodeParallel = model.BudgetSubKindItemCodeParallel,
                BudgetItemCodeParallel = model.BudgetItemCodeParallel,
                BudgetSubItemCodeParallel = model.BudgetSubItemCodeParallel,
                MethodDistributeIdParallel = model.MethodDistributeIdParallel,
                CashWithDrawTypeIdParallel = model.CashWithDrawTypeIdParallel,
                SortOrder = model.SortOrder
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>BudgetExpenseEntity.</returns>
        internal static BudgetExpenseEntity ToDataTransferObject(BudgetExpenseModel model)
        {
            if (model == null)
                return null;
            return new BudgetExpenseEntity
            {
                BudgetExpenseId = model.BudgetExpenseId,
                BudgetExpenseCode = model.BudgetExpenseCode.Trim(),
                BudgetExpenseName = model.BudgetExpenseName.Trim(),
                IsActive = model.IsActive,
                IsSystem = model.IsSystem,
                BudgetExpenseType = model.BudgetExpenseType,
            };
        }

        /// <summary>
        /// Froms the payment detail data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CAReceiptDetailModel FromDataTransferObject(CAReceiptDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new CAReceiptDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                WithdrawDetailId = entity.WithdrawDetailId,
                BudgetExpenseId = entity.BudgetExpenseId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                AutoBusinessId = entity.AutoBusinessId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>CAReceiptDetailTaxModel.</returns>
        internal static CAReceiptDetailTaxModel FromDataTransferObject(CAReceiptDetailTaxEntity entity)
        {
            if (entity == null)
                return null;
            return new CAReceiptDetailTaxModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                VATAmount = entity.VATAmount,
                VATRate = entity.VATRate == null ? -1 : entity.VATRate,
                TurnOver = entity.TurnOver,
                InvType = entity.InvType,
                InvDate = entity.InvDate,
                InvSeries = entity.InvSeries,
                InvNo = entity.InvNo,
                PurchasePurposeId = entity.PurchasePurposeId,
                AccountingObjectId = entity.AccountingObjectId,
                CompanyTaxCode = entity.CompanyTaxCode,
                SortOrder = entity.SortOrder,
                InvoiceTypeCode = entity.InvoiceTypeCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static SalaryModel FromDataTransferObject(SalaryEntity entity)
        {
            if (entity == null)
                return null;

            return new SalaryModel
            {
                EmployeePayrollId = entity.EmployeePayrollId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate.ToShortDateString(),
                TotalAmountOc = entity.TotalAmountOc,
                PostedDate = entity.PostedDate.ToShortDateString(),
                CurrencyCode = entity.CurrencyCode,
                JournalMemo = entity.JournalMemo,
                EmployeeId = entity.EmployeeId,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountExchange = entity.TotalAmountExchange,
                Employees = entity.Employees == null ? null : FromDataTransferObjects(entity.Employees)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CapitalAllocateModel FromDataTransferObject(CapitalAllocateEntity entity)
        {
            if (entity == null)
                return null;

            return new CapitalAllocateModel
            {
                CapitalAllocateId = entity.CapitalAllocateId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                ActivityId = entity.Activityid,
                AllocatePercent = entity.AllocatePercent,
                AllocateType = entity.AllocateType,
                //  DeterminedDate = entity.DeterminedDate,
                DeterminedDate = entity.DeterminedDate == null ? null : DateTime.Parse(entity.DeterminedDate.ToString()).ToShortDateString(),

                CapitalAccountCode = entity.CapitalAccountCode,
                RevenueAccountCode = entity.RevenueAccountCode,
                ExpenseAccountCode = entity.ExpenseAccountCode,
                Description = entity.Description,
                IsActive = entity.IsActive,
                WaitBudgetSourceCode = entity.WaitBudgetSourceCode,
                CapitalAllocateCode = entity.CapitalAllocateCode,
                FromDate = entity.FromDate.ToShortDateString(),
                ToDate = entity.ToDate.ToShortDateString(),
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CurrencyModel FromDataTransferObject(CurrencyEntity entity)
        {
            if (entity == null)
                return null;

            return new CurrencyModel
            {
                CurrencyCode = entity.CurrencyCode,
                CurrencyId = entity.CurrencyId,
                CurrencyName = entity.CurrencyName,
                Prefix = entity.Prefix,
                Suffix = entity.Suffix,
                IsMain = entity.IsMain,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountModel FromDataTransferObject(AccountEntity entity)
        {
            if (entity == null)
                return null;

            return new AccountModel
            {
                AccountId = entity.AccountId,
                AccountNumber = entity.AccountNumber,
                AccountCategoryId = entity.AccountCategoryId,
                ParentId = entity.ParentId,
                AccountName = entity.AccountName,
                AccountForeignName = entity.AccountForeignName,
                Description = entity.Description,
                AccountCategoryKind = entity.AccountCategoryKind,
                DetailByBudgetSource = entity.DetailByBudgetSource,
                DetailByBudgetChapter = entity.DetailByBudgetChapter,
                DetailByBudgetKindItem = entity.DetailByBudgetKindItem,
                DetailByBudgetItem = entity.DetailByBudgetItem,
                DetailByBudgetSubItem = entity.DetailByBudgetSubItem,
                DetailByMethodDistribute = entity.DetailByMethodDistribute,
                DetailByAccountingObject = entity.DetailByAccountingObject,
                DetailByActivity = entity.DetailByActivity,
                DetailByProject = entity.DetailByProject,
                DetailByTask = entity.DetailByTask,
                DetailBySupply = entity.DetailBySupply,
                DetailByInventoryItem = entity.DetailByInventoryItem,
                DetailByFixedAsset = entity.DetailByFixedAsset,
                DetailByFund = entity.DetailByFund,
                DetailByBankAccount = entity.DetailByBankAccount,
                DetailByProjectActivity = entity.DetailByProjectActivity,
                DetailByInvestor = entity.DetailByInvestor,
                Grade = entity.Grade,
                IsParent = entity.IsParent,
                IsActive = entity.IsActive,
                IsDisplayOnAccountBalanceSheet = entity.IsDisplayOnAccountBalanceSheet,
                IsDisplayBalanceOnReport = entity.IsDisplayBalanceOnReport,
                DetailByCurrency = entity.DetailByCurrency,
                DetailByBudgetExpense = entity.DetailByBudgetExpense,
                DetailByExpense = entity.DetailByExpense,
                DetailByContract = entity.DetailByContract,
                DetailByCapitalPlan = entity.DetailByCapitalPlan,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountCategoryModel FromDataTransferObject(AccountCategoryEntity entity)
        {
            if (entity == null)
                return null;

            return new AccountCategoryModel
            {
                AccountCategoryId = entity.AccountCategoryId,
                AccountCategoryName = entity.AccountCategoryName,
                AccountCategoryKind = entity.AccountCategoryKind,
                DetailByBudgetSource = entity.DetailByBudgetSource,
                DetailByBudgetChapter = entity.DetailByBudgetChapter,
                DetailByBudgetKindItem = entity.DetailByBudgetKindItem,
                DetailByBudgetItem = entity.DetailByBudgetItem,
                DetailByBudgetSubItem = entity.DetailByBudgetSubItem,
                DetailByMethodDistribute = entity.DetailByMethodDistribute,
                DetailByAccountingObject = entity.DetailByAccountingObject,
                DetailByActivity = entity.DetailByActivity,
                DetailByProject = entity.DetailByProject,
                DetailByTask = entity.DetailByTask,
                DetailBySupply = entity.DetailBySupply,
                DetailByInventoryItem = entity.DetailByInventoryItem,
                DetailByFixedAsset = entity.DetailByFixedAsset,
                DetailByBankAccount = entity.DetailByBankAccount,
                DetailByFund = entity.DetailByFund,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AutoIDModel FromDataTransferObject(AutoIDEntity entity)
        {
            if (entity == null)
                return null;

            return new AutoIDModel
            {
                RefTypeCategoryId = entity.RefTypeCategoryId,
                RefTypeCategoryName = entity.RefTypeCategoryName,
                Prefix = entity.Prefix,
                Value = (int)entity.Value,
                LengthOfValue = entity.LengthOfValue,
                Suffix = entity.Suffix,
                IsSystem = entity.IsSystem
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>CalculateClosingModel.</returns>
        internal static CalculateClosingModel FromDataTransferObject(CalculateClosingEntity entity)
        {
            if (entity == null)
                return null;

            return new CalculateClosingModel
            {
                AccountId = entity.AccountId,
                AccountCode = entity.AccountCode,
                AccountName = entity.AccountName,
                ParentId = entity.AccountId,
                ClosingAmount = entity.ClosingAmounts,
            };
        }


        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static DepartmentModel FromDataTransferObject(DepartmentEntity entity)
        {
            if (entity == null)
                return null;

            return new DepartmentModel
            {
                DepartmentId = entity.DepartmentId,
                DepartmentCode = entity.DepartmentCode,
                DepartmentName = entity.DepartmentName,
                Description = entity.Description,
                IsActive = entity.IsActive,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                IsParent = entity.IsParent
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EmployeeTypeModel FromDataTransferObject(EmployeeTypeEntity entity)
        {
            if (entity == null)
                return null;

            return new EmployeeTypeModel
            {
                EmployeeTypeId = entity.EmployeeTypeId,
                EmployeeTypeName = entity.EmployeeTypeName,
                Description = entity.Description,
                IsActive = entity.IsActive,
                EmployeeTypeCode = entity.EmployeeTypeCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetSourceCategoryModel FromDataTransferObject(BudgetSourceCategoryEntity entity)
        {
            if (entity == null)
                return null;

            return new BudgetSourceCategoryModel
            {
                BudgetSourceCategoryId = entity.BudgetSourceCategoryId,
                BudgetSourceCategoryCode = entity.BudgetSourceCategoryCode,
                BudgetSourceCategoryName = entity.BudgetSourceCategoryName,
                ParentId = entity.ParentId,
                IsParent = entity.IsParent,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetItemModel FromDataTransferObject(BudgetItemEntity entity)
        {
            if (entity == null)
                return null;
            return new BudgetItemModel
            {
                BudgetItemId = entity.BudgetItemId,
                ParentId = entity.ParentId,
                BudgetItemType = entity.BudgetItemType,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                BudgetGroupItemCode = entity.BudgetGroupItemCode,
                Grade = entity.Grade,
                IsParent = entity.IsParent,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetGroupItemModel FromDataTransferObject(BudgetGroupItemEntity entity)
        {
            if (entity == null) return null;
            return new BudgetGroupItemModel
            {
                BudgetGroupItemId = entity.BudgetGroupItemId,
                BudgetGroupItemCode = entity.BudgetGroupItemCode,
                BudgetGroupItemName = entity.BudgetGroupItemName,
                RepBudgetItemCode = entity.RepBudgetItemCode,
                IsActive = entity.IsActive,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetKindItemModel FromDataTransferObject(BudgetKindItemEntity entity)
        {
            if (entity == null)
                return null;
            return new BudgetKindItemModel
            {
                BudgetKindItemId = entity.BudgetKindItemId,
                ParentId = entity.ParentId,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetKindItemName = entity.BudgetKindItemName,
                Grade = entity.Grade,
                IsParent = entity.IsParent,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static PlanTemplateListModel FromDataTransferObject(PlanTemplateListEntity entity)
        {
            if (entity == null)
                return null;
            return new PlanTemplateListModel
            {
                PlanTemplateListId = entity.PlanTemplateListId,
                PlanTemplateListCode = entity.PlanTemplateListCode,
                PlanTemplateListName = entity.PlanTemplateListName,
                PlanType = entity.PlanType,
                PlanYear = entity.PlanYear,
                ParentId = entity.ParentId,
                PlanTemplateItems = entity.PlanTemplateItems == null ? null : FromDataTransferObjects(entity.PlanTemplateItems)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static PlanTemplateItemModel FromDataTransferObject(PlanTemplateItemEntity entity)
        {
            if (entity == null)
                return null;
            return new PlanTemplateItemModel
            {
                PlanTemplateItemId = entity.PlanTemplateItemId,
                PlanTemplateListId = entity.PlanTemplateListId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                PreviousYearOfEstimateAmountUSD = entity.PreviousYearOfEstimateAmountUSD,
                PreviousYearOfEstimateAmount = entity.PreviousYearOfEstimateAmount,
                PreviousYearOfAutonomyBudget = entity.PreviousYearOfAutonomyBudget,
                PreviousYearOfNonAutonomyBudget = entity.PreviousYearOfNonAutonomyBudget,
                SixMonthBeginingAutonomyBudget = entity.SixMonthBeginingAutonomyBudget,
                SixMonthBeginingNonAutonomyBudget = entity.SixMonthBeginingNonAutonomyBudget,
                TotalAmountSixMonthBegining = entity.TotalAmountSixMonthBegining,
                TotalAmountThisYear = entity.TotalAmountThisYear,
                ItemCodeList = entity.ItemCodeList,
                NumberOrder = entity.NumberOrder,
                FontStyle = entity.FontStyle
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetCategoryModel FromDataTransferObject(FixedAssetCategoryEntity entity)
        {
            if (entity == null)
                return null;

            return new FixedAssetCategoryModel
            {
                FixedAssetCategoryId = entity.FixedAssetCategoryId,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetCategoryName = entity.FixedAssetCategoryName,
                Description = entity.Description,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                IsParent = entity.IsParent,
                LifeTime = entity.LifeTime,
                DepreciationRate = entity.DepreciationRate,
                OrgPriceAccount = entity.OrgPriceAccount,
                DepreciationAccount = entity.DepreciationAccount,
                CapitalAccount = entity.CapitalAccount,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                IsActive = entity.IsActive
            };
        }


        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetModel FromDataTransferObject(FixedAssetEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetModel
            {
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCategoryId = entity.FixedAssetCategoryId,
                DepartmentId = entity.DepartmentId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                Quantity = entity.Quantity,
                Description = entity.Description,
                ProductionYear = entity.ProductionYear,
                MadeIn = entity.MadeIn,
                SerialNumber = entity.SerialNumber,
                Accessories = entity.Accessories,
                VendorId = entity.VendorId,
                GuaranteeDuration = entity.GuaranteeDuration,
                IsSecondHand = entity.IsSecondHand,
                LastState = entity.LastState,
                DisposedDate = entity.DisposedDate,
                DisposedAmount = entity.DisposedAmount,
                DisposedReason = entity.DisposedReason,
                PurchasedDate = entity.PurchasedDate,
                UsedDate = entity.UsedDate,
                DepreciationDate = entity.DepreciationDate,
                IncrementDate = entity.IncrementDate,
                OrgPrice = entity.OrgPrice,
                DepreciationValueCaculated = entity.DepreciationValueCaculated,
                AccumDepreciationAmount = entity.AccumDepreciationAmount,
                LifeTime = entity.LifeTime,
                DepreciationRate = entity.DepreciationRate,
                PeriodDepreciationAmount = entity.PeriodDepreciationAmount,
                RemainingAmount = entity.RemainingAmount,
                RemainingLifeTime = entity.RemainingLifeTime,
                EndYear = entity.EndYear,
                OrgPriceAccount = entity.OrgPriceAccount,
                CapitalAccount = entity.CapitalAccount,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                CreditDepreciationAccount = entity.CreditDepreciationAccount,
                DebitDepreciationAccount = entity.DebitDepreciationAccount,
                IsFixedAssetTransfer = entity.IsFixedAssetTransfer,
                DepreciationTimeCaculated = entity.DepreciationTimeCaculated,
                Unit = entity.Unit,
                RevenueAccount = entity.RevenueAccount,
                Source = entity.Source,
                IsActive = entity.IsActive,
                UsingRatio = entity.UsingRatio,
                DevaluationLifeTime = entity.DevaluationLifeTime,
                DevaluationRate = entity.DevaluationRate,
                DevaluationDate = entity.DevaluationDate,
                DevaluationPeriod = entity.DevaluationPeriod,
                DevaluationDebitAccount = entity.DevaluationDebitAccount,
                DevaluationCreditAccount = entity.DevaluationCreditAccount,
                AccumDevaluationAmount = entity.AccumDevaluationAmount,
                EndDevaluationDate = entity.EndDevaluationDate,
                PeriodDevaluationAmount = entity.PeriodDevaluationAmount,
                DevaluationAmount = entity.DevaluationAmount,
                FundStructureId = entity.FundStructureId,
                FixedAssetDetailAccessories = FromDataTransferObjects(entity.FixedAssetDetailAccessories) == null ? new List<FixedAssetDetailAccessoryModel>() : FromDataTransferObjects(entity.FixedAssetDetailAccessories),
                FixedAssetVoucherAttachs = FromDataTransferObjects(entity.FixedAssetVoucherAttachs) == null ? new List<FixedAssetVoucherAttachModel>() : FromDataTransferObjects(entity.FixedAssetVoucherAttachs),
                //OrgPriceCreditAmount = entity.OrgPriceCreditAmount,
                //DepreciationDebitAmount = entity.DepreciationDebitAmount,
                //DepreciationCreditAmount = entity.DepreciationCreditAmount,
                //DevaluationDebitAmount = entity.DevaluationDebitAmount,
                //DevaluationCreditAmount = entity.DevaluationCreditAmount

            };
        }

        internal static FixedAssetVoucherAttachModel FromDataTransferObject(FixedAssetVoucherAttachEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetVoucherAttachModel
            {
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                AmountOC = entity.AmountOC,
                Amount = entity.Amount
            };
        }


        internal static IList<FixedAssetVoucherAttachModel> FromDataTransferObjects(IList<FixedAssetVoucherAttachEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        internal static List<INInwardOutwardDetailParallelModel> FromDataTransferObjects(IList<INInwardOutwardDetailParallelEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        //internal static IList<GeneralLedgerModel> FromDataTransferObjects(IList<GeneralLedgerEntity> entities)
        //{
        //    return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        //}
        //internal static GeneralLedgerModel FromDataTransferObject(GeneralLedgerEntity entity)
        //{
        //    if (entity == null)
        //        return null;
        //    return new GeneralLedgerEntity
        //    {
        //        // GeneralLedgerId= entity.GeneralLedgerId,
        //        //RefId= entity.RefId,
        //        //RefDetailId= entity.RefDetailId,
        //        //RefType= entity.RefType,
        //        //RefNo= entity.RefNo,
        //        //CurrencyCode= entity.CurrencyCode,
        //        //ExchangeRate= entity.ExchangeRate,
        //        //RefDate= entity.RefDate,
        //        //PostedDate= entity.PostedDate,
        //        //InvNo= entity.InvNo,
        //        //InvDate= entity.InvDate,
        //        //AccountNumber= entity.AccountNumber,
        //        //CorrespondingAccountNumber= entity.CorrespondingAccountNumber,
        //        //DebitAmountOC= entity.DebitAmountOC,
        //        //DebitAmount= entity.DebitAmount,
        //        //CreditAmountOC= entity.CreditAmountOC,
        //        //CreditAmount= entity.CreditAmount,
        //        //JournalMemo= entity.JournalMemo,
        //        //Description= entity.Description,
        //        //BudgetSourceId= entity.BudgetSourceId,
        //        //BudgetChapterCode= entity.BudgetChapterCode,
        //        //BudgetKindItemCode= entity.BudgetKindItemCode,
        //        //BudgetSubKindItemCode= entity.BudgetSubKindItemCode,
        //        //BudgetItemCode= entity.BudgetItemCode,
        //        //BudgetSubItemCode= entity.BudgetSubItemCode,
        //        //MethodDistributeId= entity.MethodDistributeId,
        //        //CashWithDrawTypeId= entity.CashWithDrawTypeId,
        //        //AccountingObjectId= entity.AccountingObjectId,
        //        //ActivityId= entity.ActivityId,
        //        //ProjectId= entity.ProjectId,
        //        //ListItemId= entity.ListItemId,
        //        //Approved= entity.Approved,
        //        //BudgetDetailItemCode= entity.BudgetDetailItemCode,
        //        //BankId= entity.BankId,
        //        //IsReadjust= entity.IsReadjust,
        //        //OrgRefNo= entity.OrgRefNo,
        //        //OrgRefDate= entity.OrgRefDate,
        //        //FundStructureId= entity.FundStructureId,
        //        //SortOrder= entity.SortOrder,
        //        //BudgetProvideCode= entity.BudgetProvideCode
        //    };
        //}


        internal static FixedAssetActivityModel FromDataTransferObject(FixedAssetActivityEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetActivityModel
            {
                FixedAssetId = entity.FixedAssetId,
                FixedAssetActivityId = entity.FixedAssetActivityId,
                CreditDepreciationAccount = entity.CreditDepreciationAccount,
                DebitDepreciationAccount = entity.DebitDepreciationAccount,
                DepreciationValueCaculated = entity.DepreciationValueCaculated
            };
        }

        internal static IList<FeaturesModel> FromDataTransferObjects(IList<FeatureEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }


        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FeaturesModel FromDataTransferObject(FeatureEntity entity)
        {
            if (entity == null)
                return null;
            return new FeaturesModel
            {
                FeatureID = entity.FeatureID,
                Code = entity.Code,
                Name = entity.Name,
                ParentID = entity.ParentID,
                MenuItemCode = entity.MenuItemCode,
                Description = entity.Description,
                IsActive = entity.IsActive,
                FormMasterName = entity.FormMasterName,
                FormDetailName = entity.FormDetailName,
                SortOrder = entity.SortOrder
            };
        }
        internal static IList<UserPermisionModel> FromDataTransferObjects(IList<UserPermisionEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        internal static UserPermisionModel FromDataTransferObject(UserPermisionEntity entity)
        {
            if (entity == null)
                return null;
            return new UserPermisionModel
            {
                UserPermisionID = entity.UserPermisionID,
                Code = entity.Code,
                Name = entity.Name,
                Description = entity.Description,
                IsActive = entity.IsActive
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CustomerModel FromDataTransferObject(CustomerEntity entity)
        {
            if (entity == null)
                return null;
            return new CustomerModel
            {
                CustomerId = entity.CustomerId,
                CustomerCode = entity.CustomerCode,
                CustomerName = entity.CustomerName,
                Address = entity.Address,
                ContactName = entity.ContactName,
                ContactRegency = entity.ContactRegency,
                Phone = entity.Phone,
                Mobile = entity.Mobile,
                Fax = entity.Fax,
                Email = entity.Email,
                TaxCode = entity.TaxCode,
                Website = entity.Website,
                Province = entity.Province,
                City = entity.City,
                ZipCode = entity.ZipCode,
                Area = entity.Area,
                Country = entity.Country,
                BankNumber = entity.BankNumber,
                BankId = entity.BankId,
                IsActive = entity.IsActive,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static VendorModel FromDataTransferObject(VendorEntity entity)
        {
            if (entity == null)
                return null;
            return new VendorModel
            {
                VendorId = entity.VendorId,
                VendorCode = entity.VendorCode,
                VendorName = entity.VendorName,
                Address = entity.Address,
                ContactName = entity.ContactName,
                ContactRegency = entity.ContactRegency,
                Phone = entity.Phone,
                Mobile = entity.Mobile,
                Fax = entity.Fax,
                Email = entity.Email,
                TaxCode = entity.TaxCode,
                Website = entity.Website,
                Province = entity.Province,
                City = entity.City,
                ZipCode = entity.ZipCode,
                Area = entity.Area,
                Country = entity.Country,
                BankNumber = entity.BankNumber,
                BankId = entity.BankId,
                IsActive = entity.IsActive,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountingObjectModel FromDataTransferObject(AccountingObjectEntity entity)
        {
            if (entity == null)
                return null;
            return new AccountingObjectModel
            {
                AccountingObjectId = entity.AccountingObjectId,
                AccountingObjectCode = entity.AccountingObjectCode,
                AccountingObjectCategoryId = entity.AccountingObjectCategoryId,
                AccountingObjectName = entity.AccountingObjectName,
                Address = entity.Address,
                Tel = entity.Tel,
                Fax = entity.Fax,
                Website = entity.Website,
                BankAccount = entity.BankAccount,
                BankName = entity.BankName,
                CompanyTaxCode = entity.CompanyTaxCode,
                BudgetCode = entity.BudgetCode,
                AreaCode = entity.AreaCode,
                Description = entity.Description,
                ContactName = entity.ContactName,
                ContactTitle = entity.ContactTitle,
                ContactSex = entity.ContactSex,
                ContactMobile = entity.ContactMobile,
                ContactEmail = entity.ContactEmail,
                ContactOfficeTel = entity.ContactOfficeTel,
                ContactHomeTel = entity.ContactHomeTel,
                ContactAddress = entity.ContactAddress,
                IsEmployee = entity.IsEmployee,
                IsPersonal = entity.IsPersonal,
                IdentificationNumber = entity.IdentificationNumber,
                IssueDate = entity.IssueDate == null ? DateTime.Now : entity.IssueDate,
                IssueBy = entity.IssueBy,
                DepartmentId = entity.DepartmentId,
                SalaryScaleId = entity.SalaryScaleId,
                Insured = entity.Insured,
                LabourUnionFee = entity.LabourUnionFee,
                FamilyDeductionAmount = entity.FamilyDeductionAmount,
                IsActive = entity.IsActive,
                ProjectId = entity.ProjectId,
                IsCustomerVendor = entity.IsCustomerVendor,
                SalaryCoefficient = entity.SalaryCoefficient,
                NumberFamilyDependent = entity.NumberFamilyDependent,
                EmployeeTypeId = entity.EmployeeTypeId,
                SalaryForm = entity.SalaryForm,
                SalaryPercentRate = entity.SalaryPercentRate,
                SalaryAmount = entity.SalaryAmount,
                IsPayInsuranceOnSalary = entity.IsPayInsuranceOnSalary,
                InsuranceAmount = entity.InsuranceAmount,
                IsUnEmploymentInsurance = entity.IsUnEmploymentInsurance,
                RefTypeAO = entity.RefTypeAO,
                SalaryGrade = entity.SalaryGrade,
                CustomField1 = entity.CustomField1,
                CustomField2 = entity.CustomField2,
                CustomField3 = entity.CustomField3,
                CustomField4 = entity.CustomField4,
                CustomField5 = entity.CustomField5,
                IsPaidInsuranceForPayrollItem = entity.IsPaidInsuranceForPayrollItem,
                IsBornLeave = entity.IsBornLeave,
                TaxDepartmentName = entity.TaxDepartmentName,
                BudgetChapterId = entity.BudgetChapterId,
                BudgetItemId = entity.BudgetItemId,
                TreasuryName = entity.TreasuryName,
                TreasuryManageFee = entity.TreasuryManageFee,
                OrganizationFeeCode = entity.OrganizationFeeCode,
                OrganizationManageFee = entity.OrganizationManageFee,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountingObjectCategoryModel FromDataTransferObject(AccountingObjectCategoryEntity entity)
        {
            if (entity == null)
                return null;
            return new AccountingObjectCategoryModel
            {
                AccountingObjectCategoryId = entity.AccountingObjectCategoryId,
                AccountingObjectCategoryCode = entity.AccountingObjectCategoryCode,
                AccountingObjectCategoryName = entity.AccountingObjectCategoryName,
                IsActive = entity.IsActive,
                IsSystem = entity.IsSystem
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static VoucherListModel FromDataTransferObject(VoucherListEntity entity)
        {
            return new VoucherListModel
            {
                VoucherListId = entity.VoucherListId,
                VoucherListCode = entity.VoucherListCode,
                DocumentAttached = entity.DocumentAttached,
                Description = entity.Description,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                IsActive = entity.IsActive,
                VoucherListName = entity.VoucherListName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static InvoiceFormNumberModel FromDataTransferObject(InvoiceFormNumberEntity entity)
        {
            return new InvoiceFormNumberModel
            {
                InvoiceFormNumberId = entity.InvoiceFormNumberId,
                InvoiceFormNumberCode = entity.InvoiceFormNumberCode,
                InvoiceFormNumberName = entity.InvoiceFormNumberName,
                InvoiceType = entity.InvoiceType,
                IsSystem = entity.IsSystem,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static InvoiceTypeModel FromDataTransferObject(InvoiceTypeEntity entity)
        {
            return new InvoiceTypeModel
            {
                InvoiceTypeId = entity.InvoiceTypeId,
                InvoiceTypeCode = entity.InvoiceTypeCode,
                InvoiceTypeName = entity.InvoiceTypeName,
                Description = entity.Description,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static PayItemModel FromDataTransferObject(PayItemEntity entity)
        {
            if (entity == null)
                return null;

            return new PayItemModel
            {
                PayItemId = entity.PayItemId,
                PayItemCode = entity.PayItemCode,
                PayItemName = entity.PayItemName,
                Type = entity.Type,
                IsCalculateRatio = entity.IsCalculateRatio,
                IsSocialInsurance = entity.IsSocialInsurance,
                IsCareInsurance = entity.IsCareInsurance,
                IsTradeUnionFee = entity.IsTradeUnionFee,
                Description = entity.Description,
                DebitAccountCode = entity.DebitAccountCode,
                CreditAccountCode = entity.CreditAccountCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                IsDefault = entity.IsDefault,
                IsActive = entity.IsActive,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetGroupCode = entity.BudgetGroupCode,
                BudgetItemCode = entity.BudgetItemCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetChapterModel FromDataTransferObject(BudgetChapterEntity entity)
        {
            if (entity == null)
                return null;

            return new BudgetChapterModel
            {
                BudgetChapterCode = entity.BudgetChapterCode.Trim(),
                BudgetChapterName = entity.BudgetChapterName.Trim(),
                IsActive = entity.IsActive,
                BudgetChapterId = entity.BudgetChapterId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetCategoryModel FromDataTransferObject(BudgetCategoryEntity entity)
        {
            if (entity == null)
                return null;

            return new BudgetCategoryModel
            {
                BudgetCategoryId = entity.BudgetCategoryId,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetCategoryName = entity.BudgetCategoryName,
                ParentId = entity.ParentId,
                IsParent = entity.IsParent,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsSystem = entity.IsSystem,
                Grade = entity.Grade,
                ForeignName = entity.ForeignName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static MergerFundModel FromDataTransferObject(MergerFundEntity entity)
        {
            if (entity == null)
                return null;

            return new MergerFundModel
            {
                MergerFundId = entity.MergerFundId,
                MergerFundCode = entity.MergerFundCode,
                MergerFundName = entity.MergerFundName,
                ParentId = entity.ParentId,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsSystem = entity.IsSystem,
                Grade = entity.Grade,
                ForeignName = entity.ForeignName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BudgetSourceModel
            FromDataTransferObject(BudgetSourceEntity entity)
        {
            if (entity == null)
                return null;

            return new BudgetSourceModel
            {
                BudgetSourceId = entity.BudgetSourceId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSourceName = entity.BudgetSourceName,
                ParentId = entity.ParentId,
                IsParent = entity.IsParent,
                IsSavingExpenses = entity.IsSavingExpenses,
                BudgetSourceCategoryId = entity.BudgetSourceCategoryId,
                BudgetSourceProperty = entity.BudgetSourceProperty,
                BankAccountId = entity.BankAccountId,
                PayableBankAccountId = entity.PayableBankAccountId,
                ProjectId = entity.ProjectId,
                IsSelfControl = entity.IsSelfControl,
                IsActive = entity.IsActive,
                BudgetCode = entity.BudgetCode,
                BudgetSourceType = entity.BudgetSourceType
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EmployeeModel FromDataTransferObject(EmployeeEntity entity)
        {
            if (entity == null)
                return null;

            return new EmployeeModel
            {
                EmployeeId = entity.EmployeeId,
                EmployeeCode = entity.EmployeeCode,
                EmployeeName = entity.EmployeeName,
                JobCandidateName = entity.JobCandidateName,
                SortOrder = entity.SortOrder,
                BirthDate = entity.BirthDate == null ? null : DateTime.Parse(entity.BirthDate.ToString()).ToShortDateString(),
                TypeOfSalary = entity.TypeOfSalary,
                Sex = entity.Sex,
                LevelOfSalary = entity.LevelOfSalary,
                DepartmentId = entity.DepartmentId,
                CurrencyCode = entity.CurrencyCode,
                IdentityNo = entity.IdentityNo,
                IssueDate = entity.IssueDate == null ? null : DateTime.Parse(entity.IssueDate.ToString()).ToShortDateString(),
                IssueBy = entity.IssueBy,
                IsActive = entity.IsActive,
                Description = entity.Description,
                Address = entity.Address,
                PhoneNumber = entity.PhoneNumber,
                IsOffice = entity.IsOffice,
                RetiredDate = entity.RetiredDate == null ? null : DateTime.Parse(entity.RetiredDate.ToString()).ToShortDateString(),
                StartingDate = entity.StartingDate == null ? null : DateTime.Parse(entity.StartingDate.ToString()).ToShortDateString(),
                EmployeePayItems = entity.EmployeePayItems == null ? null : FromDataTransferObjects(entity.EmployeePayItems)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EmployeePayItemModel FromDataTransferObject(EmployeePayItemEntity entity)
        {
            if (entity == null)
                return null;

            return new EmployeePayItemModel
            {
                EmployeeId = entity.EmployeeId,
                EmployeePayItemId = entity.EmployeePayItemId,
                PayItemId = entity.PayItemId,
                Amount = entity.Amount,
                SalaryRatio = entity.SalaryRatio
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static StockModel FromDataTransferObject(StockEntity entity)
        {
            if (entity == null)
                return null;

            return new StockModel
            {
                StockId = entity.StockId,
                StockCode = entity.StockCode.Trim(),
                Description = entity.Description,
                StockName = entity.StockName.Trim(),
                IsActive = entity.IsActive,
                DefaultAccountNumber = entity.DefaultAccountNumber
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CaptitalAllocateVoucherModel FromDataTransferObject(CaptitalAllocateVoucherEntity entity)
        {
            if (entity == null)
                return null;

            return new CaptitalAllocateVoucherModel
            {
                ActivityId = entity.ActivityId,
                AllocatePercent = entity.AllocatePercent,
                AllocateType = entity.AllocateType,
                Amount = entity.Amount,
                TotalAmount = entity.TotalAmount,
                RefId = entity.RefId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                CapitalAccountCode = entity.CapitalAccountCode,
                CapitalAllocateCode = entity.CapitalAllocateCode,
                RefDetailId = entity.RefDetailId,
                Description = entity.Description,
                DeterminedDate = entity.DeterminedDate,
                ExpenseAccountCode = entity.ExpenseAccountCode,
                ExpenseAmount = entity.ExpenseAmount,
                IsActive = entity.IsActive,
                RevenueAccountCode = entity.RevenueAccountCode,
                WaitBudgetSourceCode = entity.WaitBudgetSourceCode,
                CurrencyCode = entity.CurrencyCode,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                BudgetSourceName = entity.BudgetSourceName,
                ExchangeRate = entity.ExchangeRate
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountTranferVourcherModel FromDataTransferObject(AccountTranferVourcherEntity entity)
        {
            if (entity == null)
                return null;

            return new AccountTranferVourcherModel
            {
                RefId = entity.RefId,
                BudgetSourceCode = entity.BudgetSourceCode,
                RefDetailId = entity.RefDetailId,
                Description = entity.Description,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                AmountExchange = entity.AmountExchange,
                AmountOc = entity.AmountOc,
                PostedDate = entity.PostedDate

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static InventoryItemModel FromDataTransferObject(InventoryItemEntity entity)
        {
            if (entity == null)
                return null;

            return new InventoryItemModel
            {
                InventoryItemId = entity.InventoryItemId,
                InventoryCategoryId = entity.InventoryCategoryId,
                InventoryItemCode = string.IsNullOrEmpty(entity.InventoryItemCode) ? string.Empty : entity.InventoryItemCode.Trim(),
                InventoryItemName = string.IsNullOrEmpty(entity.InventoryItemName) ? string.Empty : entity.InventoryItemName.Trim(),
                Description = entity.Description,
                Unit = entity.Unit,
                ConvertUnit = entity.ConvertUnit,
                ConvertRate = entity.ConvertRate,
                UnitPrice = entity.UnitPrice,
                SalePrice = entity.SalePrice,
                DefaultStockId = entity.DefaultStockId,
                DepartmentId = entity.DepartmentId,
                InventoryAccount = entity.InventoryAccount,
                COGSAccount = entity.COGSAccount,
                SaleAccount = entity.SaleAccount,
                CostMethod = entity.CostMethod,
                AccountingObjectId = entity.AccountingObjectId,
                TaxRate = entity.TaxRate,
                IsTool = entity.IsTool,
                IsService = entity.IsService,
                IsActive = entity.IsActive,
                IsTaxable = entity.IsTaxable,
                IsStock = entity.IsStock,
                MadeIn = entity.MadeIn,
                UnitsInStock = entity.UnitsInStock
            };
        }

        internal static InventoryItemdestinationModel FromDataTransferObject(InventoryItemdestinationEntity entity)
        {
            if (entity == null)
                return null;
            return new InventoryItemdestinationModel
            {
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                StockId = entity.StockId,
                InventoryItemId = entity.InventoryItemId,
                StockCode = entity.StockCode,
                MainUnitPrice = entity.MainUnitPrice,
                UnitPrice = entity.UnitPrice,
                Quantity = entity.Quantity,
                ExpiryDate = entity.ExpiryDate,
                InwardAmount = entity.InwardAmount,
                LotNo = entity.LotNo,
                Unit = entity.Unit
            };
        }
        internal static InventoryItemCategoryModel FromDataTransferObject(InventoryItemCategoryEntity entity)
        {
            if (entity == null)
                return null;

            return new InventoryItemCategoryModel
            {
                InventoryItemCategoryId = entity.InventoryItemCategoryId,
                InventoryItemCategoryCode = entity.InventoryItemCategoryCode,
                InventoryItemCategoryName = entity.InventoryItemCategoryName,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                IsParent = entity.IsParent,
                IsTool = entity.IsTool,
                IsSystem = entity.IsSystem,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BankModel FromDataTransferObject(BankEntity entity)
        {
            if (entity == null)
                return null;

            return new BankModel
            {
                BankId = entity.BankId,
                BankAccount = entity.BankAccount,
                BankAddress = entity.BankAddress,
                BankName = entity.BankName,
                BudgetCode = entity.BudgetCode,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsOpenInBank = entity.IsOpenInBank,
                Used = entity.Used,
                SortBank = entity.SortBank,
            };
        }
        internal static ActivityModel FromDataTransferObject(ActivityEntity entity)
        {
            if (entity == null)
                return null;

            return new ActivityModel
            {
                ActivityId = entity.ActivityId,
                ActivityCode = entity.ActivityCode,
                ActivityName = entity.ActivityName,
                ParentID = entity.ParentID,
                IsActive = entity.IsActive,
                Grade = entity.Grade,
                IsParent = entity.IsParent,
                IsSystem = entity.IsSystem
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static ExchangeRateModel FromDataTransferObject(ExchangeRateEntity entity)
        {
            if (entity == null)
                return null;

            return new ExchangeRateModel
            {
                ExchangeRateId = entity.ExchangeRateId,
                BudgetSourceCode = entity.BudgetSourceCode,
                ExchangeRate = entity.ExchangeRate,
                Description = entity.Description,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                Inactive = entity.Inactive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountTransferModel FromDataTransferObject(AccountTransferEntity entity)
        {
            if (entity == null)
                return null;

            return new AccountTransferModel
            {
                AccountTransferId = entity.AccountTransferId,
                BusinessType = entity.BusinessType,
                AccountTransferCode = entity.AccountTransferCode,
                ReferentAccount = entity.ReferentAccount,
                TransferOrder = entity.TransferOrder,
                FromAccount = entity.FromAccount,
                ToAccount = entity.ToAccount,
                TransferSide = entity.TransferSide,
                BudgetSourceId = entity.BudgetSourceId,
                Description = entity.Description,
                IsSystem = entity.IsSystem,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static DBOptionModel FromDataTransferObject(DBOptionEntity entity)
        {
            if (entity == null)
                return null;

            return new DBOptionModel
            {
                OptionId = entity.OptionId,
                OptionValue = entity.OptionValue,
                ValueType = entity.ValueType,
                IsSystem = entity.IsSystem,
                Description = entity.Description
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static ReportListModel FromDataTransferObject(ReportListEntity entity)
        {
            if (entity == null)
                return null;

            return new ReportListModel
            {
                ReportId = entity.ReportId,
                ReportName = entity.ReportName,
                Description = entity.Description,
                ReportFile = entity.ReportFile,
                OutputAssembly = entity.OutputAssembly,
                InputTypeName = entity.InputTypeName,
                FunctionReportName = entity.FunctionReportName,
                ProcedureName = entity.ProcedureName,
                TableName = entity.TableName,
                TrackType = entity.TrackType,
                ProcNameByLot = entity.ProcNameByLot,
                ProcNameVoucherList = entity.ProcNameVoucherList,
                Inactive = entity.Inactive,
                PrintVoucherDefault = entity.PrintVoucherDefault,
                LicenceType = entity.LicenceType,
                RefType = entity.RefType,
                Particularity = entity.Particularity,
                SortOrder = entity.SortOrder,
                IsReportBeConfigured = entity.IsReportBeConfigured,
                Standard = entity.Standard,
                AllowBatchPrinting = entity.AllowBatchPrinting,
                GetParamFromDialog = entity.GetParamFromDialog,
                DataBandSortReportId = entity.DataBandSortReportId,
                ReportType = entity.ReportType,
                ParentId = entity.ParentId,
                Level = entity.Level,
                Visible = entity.Visible
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static ReportGroupModel FromDataTransferObject(ReportGroupEntity entity)
        {
            if (entity == null)
                return null;

            return new ReportGroupModel
            {
                ReportGroupID = entity.ReportGroupId,
                ReportGroupName = entity.ReportGroupName,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsVoucher = entity.IsVoucher,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AudittingLogModel FromDataTransferObject(AudittingLogEntity entity)
        {
            if (entity == null)
                return null;

            return new AudittingLogModel
            {
                EventId = entity.EventId,
                LoginName = entity.LoginName,
                ComputerName = entity.ComputerName,
                EventTime = entity.EventTime,
                ComponentName = entity.ComponentName,
                EventAction = entity.EventAction,
                Reference = entity.Reference,
                Amount = entity.Amount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BUPlanWithdrawModel.</returns>
        internal static BUPlanWithdrawModel FromDataTransferObject(BUPlanWithdrawEntity entity)
        {
            if (entity == null)
                return null;
            return new BUPlanWithdrawModel
            {
                RefId = entity.RefId,
                CashWithDrawType = entity.CashWithDrawType,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                ParalellRefNo = entity.ParalellRefNo,
                TargetProgramId = entity.TargetProgramId,
                BankId = entity.BankId,
                AccountingObjectId = entity.AccountingObjectId,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                GeneratedRefId = entity.GeneratedRefId,
                Posted = entity.Posted,
                BUCommitmentRequestId = entity.BUCommitmentRequestId,
                BUPlanWithdrawDetails = FromDataTransferObjects(entity.BUPlanWithdrawDetails),
                AccountingObjectBankId = entity.AccountingObjectBankId,

                CAReceiptRefId = entity.CAReceiptRefId,
                LinkRefNo = entity.LinkRefNo,
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BUPlanWithdrawDetailModel.</returns>
        internal static BUPlanWithdrawDetailModel FromDataTransferObject(BUPlanWithdrawDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BUPlanWithdrawDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                ProjectId = entity.ProjectId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetProvideCode = entity.BudgetProvideCode,
                BudgetExpenseId = entity.BudgetExpenseId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralVocherModel FromGeneralDataTransferObject(GeneralEntity entity)
        {
            if (entity == null)
                return null;

            return new GeneralVocherModel
            {
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                JournalMemo = entity.JournalMemo,
                PostedDate = entity.PostedDate,
                GeneralVoucherDetails = ToGeneralVoucherDetailDataTransferObjects(entity.GeneralDetails),
            };
        }

        /// <summary>
        /// Froms the payment data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CAReceiptModel FromDataTransferObject(CAReceiptEntity entity)
        {
            if (entity == null)
                return null;

            return new CAReceiptModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                ParalellRefNo = entity.ParalellRefNo,
                OutwardRefNo = entity.OutwardRefNo,
                AccountingObjectId = entity.AccountingObjectId,
                JournalMemo = entity.JournalMemo,
                DocumentIncluded = entity.DocumentIncluded,
                InvType = entity.InvType,
                InvDateOrWithdrawRefDate = entity.InvDateOrWithdrawRefDate,
                InvSeries = entity.InvSeries,
                InvNoOrWithdrawRefNo = entity.InvNoOrWithdrawRefNo,
                BankId = entity.BankId,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                TotalTaxAmount = entity.TotalTaxAmount,
                TotalOutwardAmount = entity.TotalOutwardAmount,
                Posted = entity.Posted,
                RefOrder = entity.RefOrder,
                InvoiceForm = entity.InvoiceForm,
                InvoiceFormNumberId = entity.InvoiceFormNumberId,
                InvSeriesPrefix = entity.InvSeriesPrefix,
                InvSeriesSuffix = entity.InvSeriesSuffix,
                Address = entity.Address,
                PayForm = entity.PayForm,
                CompanyTaxcode = entity.CompanyTaxcode,
                RelationRefId = entity.RelationRefId,
                BUCommitmentRequestId = entity.BUCommitmentRequestId,
                AccountingObjectContactName = entity.AccountingObjectContactName,
                ListNo = entity.ListNo,
                ListDate = entity.ListDate,
                IsAttachList = entity.IsAttachList,
                ListCommonNameInventory = entity.ListCommonNameInventory,
                TotalReceiptAmount = entity.TotalReceiptAmount,
                CAReceiptDetails = FromDataTransferObjects(entity.CAReceiptDetails),
                CAReceiptDetailTaxes = FromDataTransferObjects(entity.CAReceiptDetailTaxes),
                CAReceiptDetailParallels = FromDataTransferObjects(entity.CAReceiptDetailParallels),
                Payer = entity.Payer
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CAPaymentModel FromDataTransferObject(CAPaymentEntity entity)
        {
            if (entity == null)
                return null;
            return new CAPaymentModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                ParalellRefNo = entity.ParalellRefNo,
                IncrementRefNo = entity.IncrementRefNo,
                InwardRefNo = entity.InwardRefNo,
                AccountingObjectId = entity.AccountingObjectId,
                JournalMemo = entity.JournalMemo,
                DocumentIncluded = entity.DocumentIncluded,
                Address = entity.Address,
                BankId = entity.BankId,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                TotalTaxAmount = entity.TotalTaxAmount,
                TotalFreightAmount = entity.TotalFreightAmount,
                TotalInwardAmount = entity.TotalInwardAmount,
                Posted = entity.Posted,
                Receiver = entity.Receiver,

                RefOrder = entity.RefOrder,
                RelationRefId = entity.RelationRefId,
                TotalPaymentAmount = entity.TotalPaymentAmount,
                CAPaymentDetails = FromDataTranferObjects(entity.CaPaymentDetails),
                CaPaymentDetailTaxes = FromDataTranferObjects(entity.CaPaymentDetailTaxes),
                CAPaymentDetailPurchases = FromDataTranferObjects(entity.CAPaymentDetailPurchases),
                CAPaymentDetailFixedAssets = FromDataTransferObjects(entity.CAPaymentDetailFixedAssets),
                CAPaymentDetailParallels = FromDataTransferObjects(entity.CAPaymentDetailParallels)

                //
            };
        }
        internal static BUTransferModel FromDataTransferObjectBU(CAPaymentEntity entity)
        {
            if (entity == null)
                return null;
            return new BUTransferModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                ParalellRefNo = entity.ParalellRefNo,
                IncrementRefNo = entity.IncrementRefNo,
                //  InwardRefNo = entity.InwardRefNo,
                AccountingObjectId = entity.AccountingObjectId,
                JournalMemo = entity.JournalMemo,
                DocumentIncluded = entity.DocumentIncluded,
                //  BankId = entity.BankId,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                TotalTaxAmount = entity.TotalTaxAmount,
                TotalFreightAmount = entity.TotalFreightAmount,
                TotalInwardAmount = entity.TotalInwardAmount,
                Posted = entity.Posted,
                //    Receiver = entity.Receiver,

                RefOrder = entity.RefOrder,
                RelationRefId = entity.RelationRefId,
                //    TotalPaymentAmount = entity.TotalPaymentAmount,
                BUTransferDetailFixedAssets = FromDataTransferObjectsBU(entity.CAPaymentDetailFixedAssets),

                //
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static CAPaymentDetailModel FromDataTransferObject(CAPaymentDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new CAPaymentDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                BudgetExpenseId = entity.BudgetExpenseId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                AutoBusinessId = entity.AutoBusinessId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>CAPaymentDetailTaxModel.</returns>
        internal static CAPaymentDetailTaxModel FromDataTransferObject(CAPaymentDetailTaxEntity entity)
        {
            if (entity == null)
                return null;
            return new CAPaymentDetailTaxModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                VATAmount = entity.VATAmount,
                VATRate = entity.VATRate == null ? -1 : entity.VATRate,
                TurnOver = entity.TurnOver,
                InvType = entity.InvType,
                InvDate = entity.InvDate,
                InvSeries = entity.InvSeries,
                InvNo = entity.InvNo,
                PurchasePurposeId = entity.PurchasePurposeId,
                AccountingObjectId = entity.AccountingObjectId,
                CompanyTaxCode = entity.CompanyTaxCode,
                SortOrder = entity.SortOrder,
                InvoiceTypeCode = entity.InvoiceTypeCode,

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>CAPaymentDetailPurchaseModel.</returns>
        internal static CAPaymentDetailPurchaseModel FromDataTransferObject(CAPaymentDetailPurchaseEntity entity)
        {
            if (entity == null)
                return null;
            return new CAPaymentDetailPurchaseModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                InventoryItemId = entity.InventoryItemId,
                Description = entity.Description,
                StockId = entity.StockId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Unit = entity.Unit,
                Quantity = entity.Quantity,
                QuantityConvert = entity.QuantityConvert,
                UnitPrice = entity.UnitPrice,
                UnitPriceConvert = entity.UnitPriceConvert,
                Amount = entity.Amount,
                InvType = entity.InvType,
                InvDate = entity.InvDate,
                InvSeries = entity.InvSeries,
                InvNo = entity.InvNo,
                TaxRate = entity.TaxRate == null ? -1 : entity.TaxRate,
                TaxAmount = entity.TaxAmount,
                TaxAccount = entity.TaxAccount,
                PurchasePurposeId = entity.PurchasePurposeId,
                FreightAmount = entity.FreightAmount,
                InwardAmount = entity.InwardAmount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                ListItemId = entity.ListItemId,
                ExpiryDate = entity.ExpiryDate,
                LotNo = entity.LotNo,
                Approved = entity.Approved,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                InvoiceTypeCode = entity.InvoiceTypeCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetExpenseId = entity.BudgetExpenseId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                AutoBusinessId = entity.AutoBusinessId,
                BankId = entity.BankId,
                AmountExchange = entity.AmountExchange
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>CAPaymentDetailFixedAssetModel.</returns>
        internal static CAPaymentDetailFixedAssetModel FromDataTransferObject(CAPaymentDetailFixedAssetEntity entity)
        {
            if (entity == null)
                return null;
            return new CAPaymentDetailFixedAssetModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.AmountOC,
                TaxRate = entity.TaxRate,
                TaxAmount = entity.TaxAmount,
                TaxAccount = entity.TaxAccount,
                InvType = entity.InvType,
                InvDate = entity.InvDate,
                InvSeries = entity.InvSeries,
                InvNo = entity.InvNo,
                PurchasePurposeId = entity.PurchasePurposeId,
                FreightAmount = entity.FreightAmount,
                OrgPrice = entity.OrgPrice,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                FundId = entity.FundId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                InvoiceTypeCode = entity.InvoiceTypeCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetExpenseId = entity.BudgetExpenseId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                Quantity = entity.Quantity,
                ExchangeAmount = entity.Amount
            };
        }
        internal static BUTransferDetailFixedAssetlModel FromDataTransferObjectBU(CAPaymentDetailFixedAssetEntity entity)
        {
            if (entity == null)
                return null;
            return new BUTransferDetailFixedAssetlModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                // TaxRate = entity.TaxRate,
                TaxAmount = entity.TaxAmount,
                //   TaxAccount = entity.TaxAccount,
                //  InvType = entity.InvType,
                //  InvDate = entity.InvDate,
                //  InvSeries = entity.InvSeries,
                //   InvNo = entity.InvNo,
                //  PurchasePurposeId = entity.PurchasePurposeId,
                FreightAmount = entity.FreightAmount,
                OrgPrice = entity.OrgPrice,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                //    FundId = entity.FundId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                //     InvoiceTypeCode = entity.InvoiceTypeCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetExpenseId = entity.BudgetExpenseId,
                //   ContractId = entity.ContractId,
                //   CapitalPlanId = entity.CapitalPlanId,
                //  Quantity = entity.Quantity
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>CAPaymentDetailParallelModel.</returns>
        internal static CAPaymentDetailParallelModel FromDataTransferObject(CAPaymentDetailParallelEntity entity)
        {
            if (entity == null)
                return null;
            return new CAPaymentDetailParallelModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                SortOrder = entity.SortOrder,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                BudgetExpenseId = entity.BudgetExpenseId,
                BudgetProvideCode = entity.BudgetProvideCode,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                Quantity = entity.Quantity,
                FixedAssetId = entity.FixedAssetId,
                UnitPrice = entity.UnitPrice
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BADepositDetailParallelModel.</returns>
        internal static BADepositDetailParallelModel FromDataTransferObject(BADepositDetailParallelEntity entity)
        {
            if (entity == null)
                return null;
            return new BADepositDetailParallelModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                FundId = entity.FundId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                BudgetProvideCode = entity.BudgetProvideCode,
                TopicId = entity.TopicId,
                BudgetExpenseId = entity.BudgetExpenseId,
                Approved = entity.Approved,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BAWithDrawDetailParallelModel.</returns>
        internal static BAWithDrawDetailParallelModel FromDataTransferObject(BAWithDrawDetailParallelEntity entity)
        {
            if (entity == null)
                return null;
            return new BAWithDrawDetailParallelModel
            {
                RefDetailId = entity.RefDetailId,
                ParentRefDetailId = entity.ParentRefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                FundId = entity.FundId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                BudgetProvideCode = entity.BudgetProvideCode,
                TopicId = entity.TopicId,
                BudgetExpenseId = entity.BudgetExpenseId,
                Approved = entity.Approved,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId
            };
        }
        internal static BUTransferDetailParallelModel FromDataTransferObject(BUTransferDetailParallelEntity entity)
        {
            if (entity == null)
                return null;
            return new BUTransferDetailParallelModel
            {
                RefDetailId = entity.RefDetailId,
                ParentRefDetailId = entity.ParentRefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                FundId = entity.FundId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                BudgetProvideCode = entity.BudgetProvideCode,
                TopicId = entity.TopicId,
                BudgetExpenseId = entity.BudgetExpenseId,
                Approved = entity.Approved,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                AdvanceRecovery = entity.AdvanceRecovery
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>GLVoucherDetailParallelModel.</returns>
        internal static GLVoucherDetailParallelModel FromDataTransferObject(GLVoucherDetailParallelEntity entity)
        {
            if (entity == null)
                return null;
            return new GLVoucherDetailParallelModel
            {
                RefDetailId = entity.RefDetailId,
                ParentRefDetailId = entity.ParentRefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                FundId = entity.FundId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                BudgetProvideCode = entity.BudgetProvideCode,
                TopicId = entity.TopicId,
                BudgetExpenseId = entity.BudgetExpenseId,
                Approved = entity.Approved,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>BABankTransferDetailParallelModel.</returns>
        internal static BABankTransferDetailParallelModel FromDataTransferObject(BABankTransferDetailParallelEntity entity)
        {
            if (entity == null)
                return null;
            return new BABankTransferDetailParallelModel
            {
                RefDetailId = entity.RefDetailId,
                ParentRefDetailId = entity.ParentRefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                FundId = entity.FundId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                BudgetProvideCode = entity.BudgetProvideCode,
                TopicId = entity.TopicId,
                BudgetExpenseId = entity.BudgetExpenseId,
                Approved = entity.Approved
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>CAReceiptDetailParallelModel.</returns>
        internal static CAReceiptDetailParallelModel FromDataTransferObject(CAReceiptDetailParallelEntity entity)
        {
            if (entity == null)
                return null;
            return new CAReceiptDetailParallelModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                SortOrder = entity.SortOrder,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                BudgetExpenseId = entity.BudgetExpenseId,
                BudgetProvideCode = entity.BudgetProvideCode,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BUPlanReceiptModel FromDataTransferObject(BUPlanReceiptEntity entity)
        {
            if (entity == null)
                return null;
            return new BUPlanReceiptModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                ParalellRefNo = entity.ParalellRefNo,
                DecisionDate = entity.DecisionDate,
                DecisionNo = entity.DecisionNo,
                BudgetChapterCode = entity.BudgetChapterCode,
                JournalMemo = entity.JournalMemo,
                Posted = entity.Posted,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                AllocationConfig = entity.AllocationConfig,
                BUPlanReceiptDetails = FromDataTranferObjects(entity.BuPlanReceiptDetails)

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BUPlanReceiptDetailModel FromDataTransferObject(BUPlanReceiptDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BUPlanReceiptDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetGroupItemCode = entity.BudgetGroupItemCode,
                BudgetParentItemCode = entity.BudgetParentItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                DebitAccount = entity.DebitAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                ProjectId = entity.ProjectId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                FundStructureId = entity.FundStructureId,
                BankId = entity.BankId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                AmountQuater1 = entity.AmountQuater1,
                AmountQuater1OC = entity.AmountQuater1OC,
                AmountQuater2 = entity.AmountQuater2,
                AmountQuater2OC = entity.AmountQuater2OC,
                AmountQuater3 = entity.AmountQuater3,
                AmountQuater3OC = entity.AmountQuater3OC,
                AmountQuater4 = entity.AmountQuater4,
                AmountQuater4OC = entity.AmountQuater4OC,
                AmountMonth1 = entity.AmountMonth1,
                AmountMonth1OC = entity.AmountMonth1OC,
                AmountMonth2 = entity.AmountMonth2,
                AmountMonth2OC = entity.AmountMonth2OC,
                AmountMonth3 = entity.AmountMonth3,
                AmountMonth3OC = entity.AmountMonth3OC,
                AmountMonth4 = entity.AmountMonth4,
                AmountMonth4OC = entity.AmountMonth4OC,
                AmountMonth5 = entity.AmountMonth5,
                AmountMonth5OC = entity.AmountMonth5OC,
                AmountMonth6 = entity.AmountMonth6,
                AmountMonth6OC = entity.AmountMonth6OC,
                AmountMonth7 = entity.AmountMonth7,
                AmountMonth7OC = entity.AmountMonth7OC,
                AmountMonth8 = entity.AmountMonth8,
                AmountMonth8OC = entity.AmountMonth8OC,
                AmountMonth9 = entity.AmountMonth9,
                AmountMonth9OC = entity.AmountMonth9OC,
                AmountMonth10 = entity.AmountMonth10,
                AmountMonth10OC = entity.AmountMonth10OC,
                AmountMonth11 = entity.AmountMonth11,
                AmountMonth11OC = entity.AmountMonth11OC,
                AmountMonth12 = entity.AmountMonth12,
                AmountMonth12OC = entity.AmountMonth12OC,
                BudgetProvideCode = entity.BudgetProvideCode,
                MethodDistributeId = entity.MethodDistributeId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                BudgetChapterCode = entity.BudgetChapterCode,
                ActivityId = entity.ActivityId
            };
        }
        internal static BUPlanAdjustmentModel FromDataTransferObject(BUPlanAdjustmentEntity entity)
        {
            if (entity == null)
                return null;
            return new BUPlanAdjustmentModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                ParalellRefNo = entity.ParalellRefNo,
                DecisionDate = entity.DecisionDate,
                DecisionNo = entity.DecisionNo,
                JournalMemo = entity.JournalMemo,
                Posted = entity.Posted,
                TotalPreAdjustmentAmount = entity.TotalPreAdjustmentAmount,
                TotalAdjustmentAmount = entity.TotalAdjustmentAmount,
                TotalPostAdjustmentAmount = entity.TotalPostAdjustmentAmount,
                PostVersion = entity.PostVersion,
                EditVersion = entity.EditVersion,
                BuPlanAdjustmentDetailModels = FromDataTranferObjects(entity.BUPlanAdjustmentDetails),
                ExchangeRate = entity.ExchangeRate,
                CurrencyCode = entity.CurrencyCode,
                TotalAmount = entity.TotalAmount
            };
        }

        internal static BUPlanAdjustmentDetailModel FromDataTransferObject(BUPlanAdjustmentDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BUPlanAdjustmentDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                ItemName = entity.ItemName,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetGroupItemCode = entity.BudgetGroupItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                DebitAccount = entity.DebitAccount,
                AdjustmentAmount = entity.AdjustmentAmount,
                ProjectId = entity.ProjectId,
                ListItemId = entity.ListItemId,
                SortOrder = entity.SortOrder,
                TaskId = entity.TaskId,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                FundStructureId = entity.FundStructureId,
                BankAccount = entity.BankAccount,
                ProjectExpenseEAID = entity.ProjectExpenseEAID,
                ProjectActivityEAID = entity.ProjectActivityEAID,
                BudgetProvideCode = entity.BudgetProvideCode,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                MethodDistributeId = entity.MethodDistributeId,
                ActivityId = entity.ActivityId,
                Amount = entity.Amount
            };
        }


        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BUBudgetReserveModel FromDataTransferObject(BUBudgetReserveEntity entity)
        {
            if (entity == null)
                return null;
            return new BUBudgetReserveModel
            {
                RefId = entity.RefId,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                RefType = entity.RefType,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetChapterName = entity.BudgetChapterName,
                JournalMemo = entity.JournalMemo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                Posted = entity.Posted,
                EditVersion = entity.EditVersion,
                PostVersion = entity.PostVersion,
                BUBudgetReserveDetails = FromDataTranferObjects(entity.BudgetReserveDetails)

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BUBudgetReserveDetailModel FromDataTransferObject(BUBudgetReserveDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new BUBudgetReserveDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                FundStructureId = entity.FundStructureId,
                SortOrder = entity.SortOrder,
                BudgetGroupItemCode = entity.BudgetGroupItemCode,
                BankAccount = entity.BankAccount,
                BudgetProvideCode = entity.BudgetProvideCode

            };
        }


        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralVocherModel FromDataTransferObject(GeneralEntity entity)
        {
            if (entity == null)
                return null;

            return new GeneralVocherModel
            {
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                JournalMemo = entity.JournalMemo,
                TotalAmountExchange = entity.TotalAmountExchange,
                TotalAmountOc = entity.TotalAmountOc,
                GeneralVoucherDetails = ToDataTransferObjects(entity.GeneralDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static VoucherTypeModel FromDataTransferObject(VoucherTypeEntity entity)
        {
            if (entity == null)
                return null;

            return new VoucherTypeModel
            {
                VoucherTypeId = entity.VoucherTypeId,
                VoucherTypeName = entity.VoucherTypeName,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AutoBusinessModel FromDataTransferObject(AutoBusinessEntity entity)
        {
            if (entity == null)
                return null;

            return new AutoBusinessModel
            {
                AutoBusinessId = entity.AutoBusinessId,
                AutoBusinessCode = entity.AutoBusinessCode,
                AutoBusinessName = entity.AutoBusinessName,
                RefTypeId = entity.RefTypeId,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                Description = entity.Description,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static RefTypeModel FromDataTransferObject(RefTypeEntity entity)
        {
            if (entity == null)
                return null;

            return new RefTypeModel
            {
                RefTypeId = entity.RefTypeId,
                RefTypeName = entity.RefTypeName,
                FunctionId = entity.FunctionId,
                RefTypeCategoryId = entity.RefTypeCategoryId,
                MasterTableName = entity.MasterTableName,
                DetailTableName = entity.DetailTableName,
                LayoutMaster = entity.LayoutMaster,
                LayoutDetail = entity.LayoutDetail,
                DefaultDebitAccountCategoryId = entity.DefaultDebitAccountCategoryId,
                DefaultDebitAccountId = entity.DefaultDebitAccountId,
                DefaultCreditAccountCategoryId = entity.DefaultCreditAccountCategoryId,
                DefaultCreditAccountId = entity.DefaultCreditAccountId,
                DefaultTaxAccountCategoryId = entity.DefaultTaxAccountCategoryId,
                DefaultTaxAccountId = entity.DefaultTaxAccountId,
                AllowDefaultSetting = entity.AllowDefaultSetting,
                Postable = entity.Postable,
                Searchable = entity.Searchable,
                SortOrder = entity.SortOrder,
                SubSystem = entity.SubSystem
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static ProjectModel FromDataTransferObject(ProjectEntity entity)
        {
            if (entity == null)
                return null;
            return new ProjectModel
            {
                ProjectId = entity.ProjectId,
                ProjectCode = entity.ProjectCode,
                ProjectNumber = entity.ProjectNumber,
                ProjectName = entity.ProjectName,
                ProjectEnglishName = entity.ProjectEnglishName,
                BUCACodeID = entity.BUCACodeID,
                StartDate = entity.StartDate,
                FinishDate = entity.FinishDate,
                ExecutionUnit = entity.ExecutionUnit,
                DepartmentID = entity.DepartmentID,
                TotalAmountApproved = entity.TotalAmountApproved,
                ParentID = entity.ParentID,
                Grade = entity.Grade,
                IsParent = entity.IsParent,
                IsDetailbyActivityAndExpense = entity.IsDetailbyActivityAndExpense,
                IsSystem = entity.IsSystem,
                IsActive = entity.IsActive,
                ObjectType = entity.ObjectType,
                ContractorID = entity.ContractorID,
                ContractorName = entity.ContractorName,
                ContractorAddress = entity.ContractorAddress,
                Description = entity.Description,
                ProjectSize = entity.ProjectSize,
                BuildLocation = entity.BuildLocation,
                InvestmentClass = entity.InvestmentClass,
                CDCActivityType = entity.CDCActivityType,
                Investment = entity.Investment,
                BankId = entity.BankId

            }
            ;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static ContractDetailsModel FromDataTransferObject(ContractDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new ContractDetailsModel
            {
                ContractDetailID = entity.ContractDetailID,
                ContractID = entity.ContractID,
                AddendumNo = entity.AddendumNo,
                BudgetSourceId = entity.BudgetSourceId,
                Prices = entity.Prices,
                ExchangeValue = entity.ExchangeValue,
                ExchangeRate = entity.ExchangeRate,
                CurrencyId = entity.CurrencyId,
                Description = entity.Description,
                SignDate = entity.SignDate
            }
            ;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static ContractModel FromDataTransferObject(ContractEntity entity)
        {
            if (entity == null)
                return null;
            return new ContractModel
            {
                ContractId = entity.ContractId,
                ContractNo = entity.ContractNo,
                ContractName = entity.ContractName,
                ContractNameEnglish = entity.ContractNameEnglish,
                SignDate = entity.SignDate,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                AmountOC = entity.AmountOC,
                ProjectId = entity.ProjectId,
                Description = entity.Description,
                VendorId = entity.VendorId,
                VendorBankAccountId = entity.VendorBankAccountId,
                IsActive = entity.IsActive,

            };
        }

        internal static TaxItemModel FromDataTransferObject(TaxItemEntity entity)
        {
            if (entity == null)
                return null;
            return new TaxItemModel
            {
                TaxItemId = entity.TaxItemId,
                TaxItemCode = entity.TaxItemCode,
                TaxItemName = entity.TaxItemName,
                IsActive = entity.IsActive,

            };
        }
        internal static TaxTypeModel FromDataTransferObject(TaxTypeEntity entity)
        {
            if (entity == null)
                return null;
            return new TaxTypeModel
            {
                TaxTypeId = entity.TaxTypeId,
                TaxTypeCode = entity.TaxTypeCode,
                TaxTypeName = entity.TaxTypeName,
                IsActive = entity.IsActive,

            };
        }
        internal static FundStructureModel FromDataTransferObject(FundStructureEntity entity)
        {
            if (entity == null)
                return null;
            return new FundStructureModel
            {
                FundStructureId = entity.FundStructureId,
                FundStructureCode = entity.FundStructureCode,
                FundStructureName = entity.FundStructureName,
                BUCACodeId = entity.BUCACodeId,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                IsParent = entity.IsParent,
                Inactive = entity.Inactive,
                IsSystem = entity.IsSystem,
                InvestmentPeriod = entity.InvestmentPeriod

                ,
                BudgetItemId = entity.BudgetItemId
                ,
                CashWithdrawTypeId = entity.CashWithdrawTypeId
                ,
                IsProjectExpense = entity.IsProjectExpense
                ,
                IsAllocateExpense = entity.IsAllocateExpense
                ,
                IsExpenseNoBuilding = entity.IsExpenseNoBuilding

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetArmortizationModel FromDataTransferObject(FAArmortizationEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetArmortizationModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate.ToShortDateString(),
                PostedDate = entity.PostedDate.ToShortDateString(),
                RefTypeId = entity.RefTypeId,
                TotalAmountOC = entity.TotalAmountOC,
                TotalAmountExchange = entity.TotalAmountExchange,
                JournalMemo = entity.JournalMemo,
                CurrencyCode = entity.CurrencyCode,
                FixedAssetArmortizationDetails = entity.FAArmortizationDetails == null ? null : FromDataTransferObjects(entity.FAArmortizationDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetArmortizationDetailModel FromDataTransferObject(FAArmortizationDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetArmortizationDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Quantity = entity.Quantity,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                AmountOC = entity.AmountOC,
                AmountExchange = entity.AmountExchange,
                VoucherTypeId = entity.VoucherTypeId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                ProjectId = entity.ProjectId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetDecrementModel FromDataTransferObject(FADecrementEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetDecrementModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate.ToShortDateString(),
                PostedDate = entity.PostedDate.ToShortDateString(),
                RefTypeId = entity.RefTypeId,
                AccountingObjectType = entity.AccountingObjectType,
                AccountingObjectId = entity.AccountingObjectId,
                CustomerId = entity.CustomerId,
                VendorId = entity.VendorId,
                EmployeeId = entity.EmployeeId,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountExchange = entity.TotalAmountExchange,
                TotalAmountOC = entity.TotalAmountOC,
                JournalMemo = entity.JournalMemo,
                DocumentInclude = entity.DocumentInclude,
                Trader = entity.Trader,
                BankId = entity.BankId,
                FixedAssetDecrementDetails = entity.FADecrementDetails == null ? null : FromDataTransferObjects(entity.FADecrementDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetDecrementDetailModel FromDataTransferObject(FADecrementDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetDecrementDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Quantity = entity.Quantity,
                AmountExchange = entity.AmountExchange,
                VoucherTypeId = entity.VoucherTypeId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                ProjectId = entity.ProjectId,
                AccountingObjectId = entity.AccountingObjectId,
                AutoBusinessId = entity.AutoBusinessId,
                UnitPriceExchange = entity.UnitPriceExchange,
                AmountOC = entity.AmountOC,
                UnitPriceOC = entity.UnitPriceOC
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetIncrementModel FromDataTransferObject(FAIncrementEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetIncrementModel
            {
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate.ToShortDateString(),
                PostedDate = entity.PostedDate.ToShortDateString(),
                RefTypeId = entity.RefTypeId,
                AccountingObjectType = entity.AccountingObjectType,
                AccountingObjectId = entity.AccountingObjectId,
                CustomerId = entity.CustomerId,
                VendorId = entity.VendorId,
                EmployeeId = entity.EmployeeId,
                Trader = entity.Trader,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                TotalAmountExchange = entity.TotalAmountExchange,
                TotalAmountOC = entity.TotalAmountOC,
                JournalMemo = entity.JournalMemo,
                DocumentInclude = entity.DocumentInclude,
                BankId = entity.BankId,
                FixedAssetIncrementDetails = entity.FAIncrementDetails == null ? null : FromDataTransferObjects(entity.FAIncrementDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetIncrementDetailModel FromDataTransferObject(FAIncrementDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetIncrementDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                FixedAssetId = entity.FixedAssetId,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                Quantity = entity.Quantity,
                AmountExchange = entity.AmountExchange,
                VoucherTypeId = entity.VoucherTypeId,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                ProjectId = entity.ProjectId,
                AccountingObjectId = entity.AccountingObjectId,
                AutoBusinessId = entity.AutoBusinessId,
                UnitPriceExchange = entity.UnitPriceExchange,
                AmountOC = entity.AmountOC,
                UnitPriceOC = entity.UnitPriceOC
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralVoucherDetailModel FromDataTransferObject(GeneralDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new GeneralVoucherDetailModel
            {
                RefId = entity.RefId,
                RefDetailId = entity.RefDetailId,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                AmountExchange = entity.AmountExchange,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetItemCode = entity.BudgetItemCode,
                Description = entity.Description,
                ProjectId = entity.ProjectId,
                AccountingObjectId = entity.AccountingObjectId,
                CurrencyCode = entity.CurrencyCode,
                CustomerId = entity.CustomerId,
                EmployeeId = entity.EmployeeId,
                ExchangeRate = entity.ExchangeRate,
                VendorId = entity.VendorId,
                AmountOc = entity.AmountOc,
                VoucherTypeId = entity.VoucherTypeId,
                DepartmentId = entity.DepartmentId,
                InventoryItemId = entity.InventoryItemId,
                BankId = entity.BankId,
                CapitalAllocateCode = entity.CapitalAllocateCode

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetCurrencyModel FromDataTransferObject(FixedAssetCurrencyEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetCurrencyModel
            {
                FixedAssetCurrencyId = entity.FixedAssetCurrencyId,
                FixedAssetId = entity.FixedAssetId,
                CurrencyCode = entity.CurrencyCode,
                UnitPrice = entity.UnitPrice,
                UnitPriceUSD = entity.UnitPriceUSD,
                OrgPrice = entity.OrgPrice,
                OrgPriceUSD = entity.OrgPriceUSD,
                AccumDepreciationAmount = entity.AccumDepreciationAmount,
                AccumDepreciationAmountUSD = entity.AccumDepreciationAmountUSD,
                RemainingAmount = entity.RemainingAmount,
                RemainingAmountUSD = entity.RemainingAmountUSD,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                AnnualDepreciationAmountUSD = entity.AnnualDepreciationAmountUSD,
                ExchangeRate = entity.ExchangeRate
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static OpeningAccountEntryModel FromDataTransferObject(OpeningAccountEntryEntity entity)
        {
            if (entity == null)
                return null;
            return new OpeningAccountEntryModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                PostedDate = entity.PostedDate,
                CurrencyId = entity.CurrencyId,
                ExchangeRate = entity.ExchangeRate,
                AccountNumber = entity.AccountNumber,
                AccountName = entity.AccountName,
                AccBeginningDebitAmountOC = entity.AccBeginningDebitAmountOC,
                AccBeginningDebitAmount = entity.AccBeginningDebitAmount,
                AccBeginningCreditAmountOC = entity.AccBeginningCreditAmountOC,
                AccBeginningCreditAmount = entity.AccBeginningCreditAmount,
                DebitAmountOC = entity.DebitAmountOC,
                DebitAmount = entity.DebitAmount,
                CreditAmountOC = entity.CreditAmountOC,
                CreditAmount = entity.CreditAmount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithdrawTypeId = entity.CashWithdrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                TaskId = entity.TaskId,
                BankId = entity.BankId,
                Approved = entity.Approved,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                ProjectActivityId = entity.ProjectActivityId,
                ApprovedDate = entity.ApprovedDate,
                FundStructureId = entity.FundStructureId,
                ProjectActivityEAID = entity.ProjectActivityEAID,
                BudgetProvideCode = entity.BudgetProvideCode,
                ParentId = entity.ParentId,
                AccountId = entity.AccountId,
                BudgetExpenseId = entity.BudgetExpenseId,
                CurrencyCode = entity.CurrencyCode,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static OpeningAccountEntryDetailModel FromDataTransferObject(OpeningAccountEntryDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new OpeningAccountEntryDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefTypeId = entity.RefTypeId,
                PostedDate = entity.PostedDate,
                AccountCode = entity.AccountCode,
                AccountName = entity.AccountName,
                AccountId = entity.AccountId,
                ParentId = entity.ParentId,
                AccountBeginningDebitAmountOC = entity.AccountBeginningDebitAmountOC,
                AccountBeginningCreditAmountOC = entity.AccountBeginningCreditAmountOC,
                DebitAmountOC = entity.DebitAmountOC,
                CreditAmountOC = entity.CreditAmountOC,
                AccountBeginningDebitAmountExchange = entity.AccountBeginningDebitAmountExchange,
                AccountBeginningCreditAmountExchange = entity.AccountBeginningCreditAmountExchange,
                DebitAmountExchange = entity.DebitAmountExchange,
                CreditAmountExchange = entity.CreditAmountExchange,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetCategoryCode = entity.BudgetCategoryCode,
                BudgetGroupItemCode = entity.BudgetGroupItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                MergerFundId = entity.MergerFundId,
                EmployeeId = entity.EmployeeId,
                CustomerId = entity.CustomerId,
                VendorId = entity.VendorId,
                AccountingObjectId = entity.AccountingObjectId,
                ProjectId = entity.ProjectId,
                BankId = entity.BankId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralReceiptEstimateModel FromDataTransferObject(GeneralReceiptEstimateEntity entity)
        {
            if (entity == null)
                return null;
            return new GeneralReceiptEstimateModel
            {
                Id = entity.Id,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                PreviousYearOfTotalEstimateAmount = entity.PreviousYearOfTotalEstimateAmount,
                YearOfEstimateAmount = entity.YearOfEstimateAmount,
                NextYearOfEstimateAmount = entity.NextYearOfEstimateAmount,
                Description = entity.Description,
                ItemCodeList = entity.ItemCodeList,
                NumberOrder = entity.NumberOrder,
                FontStyle = entity.FontStyle,
                IsParent = entity.IsParent
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralPaymentEstimateModel FromDataTransferObject(GeneralPaymentEstimateEntity entity)
        {
            if (entity == null)
                return null;
            return new GeneralPaymentEstimateModel
            {
                BudgetItemId = entity.BudgetItemId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                TotalEstimateAmountUSD = entity.TotalEstimateAmountUSD,
                YearOfEstimateAmount = entity.YearOfEstimateAmount,
                NextYearOfEstimateAmount = entity.NextYearOfEstimateAmount,
                AutonomyBudget = entity.AutonomyBudget,
                NonAutonomyBudget = entity.NonAutonomyBudget,
                TotalNextYearOfEstimateAmount = entity.TotalNextYearOfEstimateAmount,
                Description = entity.Description,
                BudgetSourceCategoryName = entity.BudgetSourceCategoryName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralEstimateModel FromDataTransferObject(GeneralEstimateEntity entity)
        {
            if (entity == null)
                return null;
            return new GeneralEstimateModel
            {
                BudgetItemName = entity.BudgetItemName,
                PreviousYearOfTotalEstimateAmount = entity.PreviousYearOfTotalEstimateAmount,
                YearOfEstimateAmount = entity.YearOfEstimateAmount,
                NextYearOfEstimateAmount = entity.NextYearOfEstimateAmount,
                Description = entity.Description
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GeneralPaymentDetailEstimateModel FromDataTransferObject(GeneralPaymentDetailEstimateEntity entity)
        {
            if (entity == null)
                return null;
            return new GeneralPaymentDetailEstimateModel
            {
                BudgetItemId = entity.BudgetItemId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetItemName = entity.BudgetItemName,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                TotalEstimateAmountUSD = entity.TotalEstimateAmountUSD,
                YearOfEstimateAmount = entity.YearOfEstimateAmount,
                NextYearOfEstimateAmount = entity.NextYearOfEstimateAmount,
                AutonomyBudget = entity.AutonomyBudget,
                NonAutonomyBudget = entity.NonAutonomyBudget,
                TotalNextYearOfEstimateAmount = entity.TotalNextYearOfEstimateAmount,
                Description = entity.Description,
                BudgetSourceCategoryName = entity.BudgetSourceCategoryName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetFAInventoryModel FromDataTransferObject(FixedAssetFAInventoryEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetFAInventoryModel
            {
                OrderNumber = entity.OrderNumber,
                FixedAssetCategoryCode = entity.FixedAssetCategoryCode,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                ParentId = entity.ParentId,
                YearOfUsing = entity.YearOfUsing,
                Description = entity.Description,
                Unit = entity.Unit,
                DepreciationRate = entity.DepreciationRate,
                SerialNumber = entity.SerialNumber,
                CountryProduction = entity.CountryProduction,
                Quantity = entity.Quantity,
                OrgPrice = entity.OrgPrice,
                OrgPriceUsd = entity.OrgPriceUsd,
                OrgPriceCurrencyUsd = entity.OrgPriceCurrencyUsd,
                TotalOrgPriceUsd = entity.TotalOrgPriceUsd,

                QuantityInvetory = entity.QuantityInvetory,
                OrgPriceInvetory = entity.OrgPriceInvetory,
                OrgPriceCurrencyInvetoryUsd = entity.OrgPriceCurrencyInvetoryUsd,
                OrgPriceInvetoryUsd = entity.OrgPriceInvetoryUsd,
                TotalOrgPriceInvetoryUsd = entity.TotalOrgPriceInvetoryUsd,

                QuantityDifference = entity.QuantityDifference,
                OrgPriceDifference = entity.OrgPriceDifference,
                OrgPriceCurrencyDifferenceUsd = entity.OrgPriceCurrencyDifferenceUsd,
                OrgPriceDifferenceUsd = entity.OrgPriceDifferenceUsd,
                TotalOrgPriceDifferenceUsd = entity.TotalOrgPriceDifferenceUsd,

                Grade = entity.Grade,
                Sort = entity.Sort

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetFAInventoryHouseModel FromDataTransferObject(FixedAssetFAInventoryHouseEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetFAInventoryHouseModel
            {
                OrderNumber = entity.OrderNumber,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                UsedDate = entity.UsedDate,
                ProductionYear = entity.ProductionYear,
                Description = entity.Description,
                OrgPrice = entity.OrgPrice,
                OrgPriceUsd = entity.OrgPriceUsd,
                OrgPriceCurrencyUsd = entity.OrgPriceCurrencyUsd,
                OrgPriceDifference = entity.OrgPriceDifference,
                OrgPriceCurrencyDifferenceUsd = entity.OrgPriceCurrencyDifferenceUsd,
                OrgPriceDifferenceUsd = entity.OrgPriceDifferenceUsd,
                AreaOfBuilding = entity.AreaOfBuilding,
                AreaOfFloor = entity.AreaOfFloor,
                NumberOfFloor = entity.NumberOfFloor,
                WorkingArea = entity.WorkingArea,
                GradeHouse = entity.GradeHouse,
                GuestHouseArea = entity.GuestHouseArea,
                HousingArea = entity.HousingArea,
                OtherArea = entity.OtherArea,
                RemainingAmount = entity.RemainingAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetFAInventoryCarModel FromDataTransferObject(FixedAssetFAInventoryCarEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetFAInventoryCarModel
            {
                OrderNumber = entity.OrderNumber,
                FixedAssetId = entity.FixedAssetId,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                UsedDate = entity.UsedDate,
                Description = entity.Description,
                SerialNumber = entity.SerialNumber,
                Brand = entity.Brand,
                CountryProduction = entity.CountryProduction,
                OrgPrice = entity.OrgPrice,
                OrgPriceUsd = entity.OrgPriceUsd,
                OrgPriceCurrencyUsd = entity.OrgPriceCurrencyUsd,
                OrgPriceDifference = entity.OrgPriceDifference,
                OrgPriceDifferenceUsd = entity.OrgPriceDifferenceUsd,
                OrgPriceCurrencyDifferenceUsd = entity.OrgPriceCurrencyDifferenceUsd,
                ControlPlate = entity.ControlPlate,
                NumberOfSeat = entity.NumberOfSeat,
                ProductionYear = entity.ProductionYear,
                Car1 = entity.Car1,
                Car2 = entity.Car2,
                Car = entity.Car,
                RemainingAmount = entity.RemainingAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static SearchModel FromDataTransferObject(SearchEntity entity)
        {
            if (entity == null)
                return null;
            return new SearchModel
            {
                //RefId = entity.RefId,
                //RefNo = entity.RefNo,
                //RefDate = DateTime.Parse(entity.RefDate).ToShortDateString(),
                //PostedDate = DateTime.Parse(entity.PostedDate).ToShortDateString(),
                //RefTypeId = entity.RefTypeId,
                //CurrencyCode = entity.CurrencyCode,
                //JournalMemo = entity.JournalMemo,
                //TotalAmount = entity.AmountOc,

                //AccountNumber = entity.AccountNumber,
                //CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                //AmountExchange = entity.AmountExchange,
                //BudgetSourceCode = entity.BudgetSourceCode,
                //BudgetItemCode = entity.BudgetItemCode,
                //AccountingObjectId = entity.AccountingObjectId,
                //CustomerId = entity.CustomerId,
                //EmployeeId = entity.EmployeeId,
                //VendorId = entity.VendorId,
                //AccountingObjectCode = entity.AccountingObjectCode,
                //CustomerCode = entity.CustomerCode,
                //EmployeeCode = entity.EmployeeCode,
                //VendorCode = entity.VendorCode,
                //ProjectId = entity.ProjectId,
                //ProjectCode = entity.ProjectCode,
                //InventoryItemCode = entity.InventoryItemCode,
                //InventoryItemId = entity.InventoryItemId,
                //VoucherTypeId = entity.VoucherTypeId,
                //VoucherTypeName = entity.VoucherTypeName,
                //RefTypeName = entity.RefTypeName,
                //BudgetGroupCode = entity.BudgetGroupCode,
                //DepartmentCode = entity.DepartmentCode,
                //FixedAssetCode = entity.FixedAssetCode
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetLedgerModel FromDataTransferObject(FixedAssetLedgerEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetLedgerModel
            {
                FixedAssetLedgerId = entity.FixedAssetLedgerId,
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                FixedAssetId = entity.FixedAssetId,
                DepartmentId = entity.DepartmentId,
                LifeTime = entity.LifeTime,
                AnnualDepreciationRate = entity.AnnualDepreciationRate,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                OrgPriceAccount = entity.OrgPriceAccount,
                OrgPriceDebitAmount = entity.OrgPriceDebitAmount,
                OrgPriceCreditAmount = entity.OrgPriceCreditAmount,
                DepreciationAccount = entity.DepreciationAccount,
                DepreciationDebitAmount = entity.DepreciationDebitAmount,
                DepreciationCreditAmount = entity.DepreciationCreditAmount,
                CapitalAccount = entity.CapitalAccount,
                CapitalDebitAmount = entity.CapitalDebitAmount,
                CapitalCreditAmount = entity.CapitalCreditAmount,
                JournalMemo = entity.JournalMemo,
                Description = entity.Description,
                RemainingLifeTime = entity.RemainingLifeTime,
                EndYear = entity.EndYear,
                FARefOrder = entity.FARefOrder,
                FixedAssetOrder = entity.FixedAssetOrder,
                Quantity = entity.Quantity,
                DifferenceQuantity = entity.DifferenceQuantity,
                FixedAssetCode = entity.FixedAssetCode,
                FixedAssetName = entity.FixedAssetName,
                DevaluationPeriod = entity.DevaluationPeriod,
                DevaluationRate = entity.DevaluationRate,
                PeriodDevaluationAmount = entity.PeriodDevaluationAmount,
                DevaluationDebitAmount = entity.DevaluationDebitAmount,
                DevaluationCreditAmount = entity.DevaluationCreditAmount,
                RemainingDevaluationLifeTime = entity.RemainingDevaluationLifeTime,
                EndDevaluationDate = entity.EndDevaluationDate,
                DevaluationAmount = entity.DevaluationAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetVoucherModel FromDataTransferObject(FixedAssetVoucherEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetVoucherModel
            {
                RefId = entity.RefId,
                RefTypeId = entity.RefTypeId,
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate.ToString("dd/MM/yyyy"),
                Description = entity.Description,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                AmountExchange = entity.AmountExchange,
                AmountOC = entity.AmountOC,
                AccumDepreciationAmount = entity.AccumDepreciationAmount,
                AccumDepreciationAmountUSD = entity.AccumDepreciationAmountUSD,
                RemainingAmount = entity.RemainingAmount,
                RemainingAmountUSD = entity.RemainingAmountUSD,
                AnnualDepreciationAmount = entity.AnnualDepreciationAmount,
                AnnualDepreciationAmountUSD = entity.AnnualDepreciationAmountUSD

            };

        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static RoleModel FromDataTransferObject(RoleEntity entity)
        {
            if (entity == null)
                return null;
            return new RoleModel
            {
                RoleId = entity.RoleId,
                RoleName = entity.RoleName,
                Description = entity.Description,
                IsActive = entity.IsActive,
                RoleSiteModels = FromDataTransferObjects(entity.RoleSiteEntities)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static SiteModel FromDataTransferObject(SiteEntity entity)
        {
            if (entity == null)
                return null;
            return new SiteModel
            {
                SiteId = entity.SiteId,
                SiteCode = entity.SiteCode,
                SiteName = entity.SiteName,
                Description = entity.Description,
                ParentId = entity.ParentId,
                Order = entity.Order,
                IsActive = entity.IsActive,
                PermissionSiteModels = FromDataTransferObjects(entity.PermissionSiteEntities)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static PermissionModel FromDataTransferObject(PermissionEntity entity)
        {
            if (entity == null)
                return null;
            return new PermissionModel
            {
                PermissionId = entity.PermissionId,
                PermissionCode = entity.PermissionCode,
                PermissionName = entity.PermissionName,
                Description = entity.Description,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static PermissionSiteModel FromDataTransferObject(PermissionSiteEntity entity)
        {
            return new PermissionSiteModel
            {
                PermissionSiteId = entity.PermissionSiteId,
                SiteId = entity.SiteId,
                PermissionId = entity.PermissionId,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static RoleSiteModel FromDataTransferObject(RoleSiteEntity entity)
        {
            return new RoleSiteModel
            {
                RoleSiteId = entity.RoleSiteId,
                RoleId = entity.RoleId,
                SiteId = entity.SiteId,
                PermissionId = entity.PermissionId
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static OpeningFixedAssetEntryModel FromDataTransferObject(OpeningFixedAssetEntryEntity entity)
        {
            return new OpeningFixedAssetEntryModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                PostedDate = entity.PostedDate,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                FixedAssetId = entity.FixedAssetId,
                DepartmentId = entity.DepartmentId,
                BudgetChapterCode = entity.BudgetChapterCode,
                OrgPriceAccount = entity.OrgPriceAccount,
                OrgPriceDebitAmountOC = entity.OrgPriceDebitAmountOC,
                OrgPriceDebitAmount = entity.OrgPriceDebitAmount,
                DepreciationAccount = entity.DepreciationAccount,
                DepreciationCreditAmountOC = entity.DepreciationCreditAmountOC,
                DepreciationCreditAmount = entity.DepreciationCreditAmount,
                CapitalAccount = entity.CapitalAccount,
                CapitalCreditAmountOC = entity.CapitalCreditAmountOC,
                CapitalCreditAmount = entity.CapitalCreditAmount,
                SortOrder = entity.SortOrder,
                DevaluationCreditAmount = entity.DevaluationCreditAmount
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EmployeeLeasingModel FromDataTransferObject(EmployeeLeasingEntity entity)
        {
            return new EmployeeLeasingModel
            {
                OrderNumber = entity.OrderNumber,
                EmployeeLeasingId = entity.EmployeeLeasingId,
                EmployeeLeasingCode = entity.EmployeeLeasingCode,
                EmployeeLeasingName = entity.EmployeeLeasingName,
                JobCandidate = entity.JobCandidate,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Description = entity.Description,
                IsActive = entity.IsActive,
                IsLeasing = entity.IsLeasing,
                InsurancePrice = entity.InsurancePrice,
                SalaryPrice = entity.SalaryPrice,
                UniformPrice = entity.UniformPrice
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static BuildingModel FromDataTransferObject(BuildingEntity entity)
        {
            return new BuildingModel
            {
                OrderNumber = entity.OrderNumber,
                BuildingId = entity.BuildingId,
                BuildingCode = entity.BuildingCode,
                BuildingName = entity.BuildingName,
                JobCandidate = entity.JobCandidate,
                Address = entity.Address,
                Area = entity.Area,
                UnitPrice = entity.UnitPrice,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Description = entity.Description,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EmployeeForEstimateModel FromDataTransferObject(EmployeeForEstimateEntity entity)
        {
            return new EmployeeForEstimateModel
            {
                OrderNumber = entity.OrderNumber,
                EmployeeName = entity.EmployeeName,
                JobCandidateName = entity.JobCandidateName,
                SubsitenceFee = entity.SubsitenceFee,
                WomenAllowance = entity.WomenAllowance,
                PluralityAllowance = entity.PluralityAllowance,
                StartedDate = entity.StartedDate,
                FinishedDate = entity.FinishedDate,
                Description = entity.Description
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetForEstimateModel FromDataTransferObject(FixedAssetForEstimateEntity entity)
        {
            return new FixedAssetForEstimateModel
            {
                OrderNumber = entity.OrderNumber,
                EmployeeName = entity.EmployeeName,
                JobCandidateName = entity.JobCandidateName,
                Address = entity.Address,
                UsingOfArea = entity.UsingOfArea,
                Description = entity.Description,
                PurchasedDate = entity.PurchasedDate
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementModel FromDataTransferObject(EstimateDetailStatementEntity entity)
        {
            return new EstimateDetailStatementModel
            {
                Employees = FromDataTransferObjects(entity.Employees),
                EmployeeOthers = FromDataTransferObjects(entity.EmployeeOthers),
                EmployeeLeasings = FromDataTransferObjects(entity.EmployeeLeasings),
                FixedAssets = FromDataTransferObjects(entity.FixedAssets),
                Buildings = FromDataTransferObjects(entity.Buildings),
                EstimateDetailStatementPartBs = FromDataTransferObjects(entity.EstimateDetailStatementPartBs),
                EstimateDetailStatementFixedAssets = FromDataTransferObjects(entity.EstimateDetailStatementFixedAssets),
                Mutuals = FromDataTransferObjects(entity.Mutuals),
                FixedAssetCars = FromDataTransferObjects(entity.FixedAssetCars)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FundStuationModel FromDataTransferObject(FundStuationEntity entity)
        {
            return new FundStuationModel
            {
                BudgetItemId = entity.BudgetItemId,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                BudgetItemName = entity.BudgetItemName,
                ParentId = entity.ParentId,
                Grade = entity.Grade,
                Sort = entity.Sort,
                BudgetItemType = entity.BudgetItemType,
                PreviousYearOfAutonomyBudget = entity.PreviousYearOfAutonomyBudget,
                PreviousYearOfNonAutonomyBudget = entity.PreviousYearOfNonAutonomyBudget,
                TotalEstimateAmountUSD = entity.TotalEstimateAmountUSD,
                YearOfAutonomyBudget = entity.YearOfAutonomyBudget,
                YearOfNonAutonomyBudget = entity.YearOfNonAutonomyBudget,
                YearOfEstimateAmount = entity.YearOfEstimateAmount,
                SixMonthBeginingAutonomyBudget = entity.SixMonthBeginingAutonomyBudget,
                SixMonthBeginingNonAutonomyBudget = entity.SixMonthBeginingNonAutonomyBudget,
                TotalAmountSixMonthBegining = entity.TotalAmountSixMonthBegining,
                SixMonthEndingAutonomyBudget = entity.SixMonthEndingAutonomyBudget,
                SixMonthEndingNonAutonomyBudget = entity.SixMonthEndingNonAutonomyBudget,
                TotalAmountSixMonthEnding = entity.TotalAmountSixMonthEnding,
                YearOfAmountAutonomyBudget = entity.YearOfAmountAutonomyBudget,
                YearOfAmountNonAutonomyBudget = entity.YearOfAmountNonAutonomyBudget,
                YearOfTotalAmount = entity.YearOfTotalAmount,
                YearOfDifferenceAmountAutonomyBudget = entity.YearOfDifferenceAmountAutonomyBudget,
                YearOfDifferenceAmountNonAutonomyBudget = entity.YearOfDifferenceAmountNonAutonomyBudget,
                YearOfDifferenceTotalAmount = entity.YearOfDifferenceTotalAmount,
                Description = entity.Description,
                BudgetSourceCategoryName = entity.BudgetSourceCategoryName
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementInfoModel FromDataTransferObject(EstimateDetailStatementInfoEntity entity)
        {
            if (entity == null)
                return null;
            return new EstimateDetailStatementInfoModel
            {
                EstimateDetailStatementId = entity.EstimateDetailStatementId,
                GeneralDescription = entity.GeneralDescription,
                EmployeeContractDescription = entity.EmployeeContractDescription,
                EmployeeLeasingDescription = entity.EmployeeLeasingDescription,
                BuildingOfFixedAssetDescription = entity.BuildingOfFixedAssetDescription,
                CarDescription = entity.CarDescription,
                DescriptionForBuilding = entity.DescriptionForBuilding,
                InventoryDescription = entity.InventoryDescription,
                PartC = entity.PartC,
                PartC1 = entity.PartC1,
                IsActive = entity.IsActive
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementPartBModel FromDataTransferObject(EstimateDetailStatementPartBEntity entity)
        {
            if (entity == null)
                return null;
            return new EstimateDetailStatementPartBModel
            {
                EstimateDetailStatementPartBId = entity.EstimateDetailStatementPartBId,
                OrderNumber = entity.OrderNumber,
                Description = entity.Description,
                Amount = entity.Amount,
                Note = entity.Note,
                IsActive = entity.IsActive
            };
        }

        internal static EstimateDetailStatementFixedAssetModel FromDataTransferObject(EstimateDetailStatementFixedAssetEntity entity)
        {
            if (entity == null)
                return null;
            return new EstimateDetailStatementFixedAssetModel
            {
                EstimateDetailStatementFixedAssetId = entity.EstimateDetailStatementFixedAssetId,
                OrderNumber = entity.OrderNumber,
                PurchasedYear = entity.PurchasedYear,
                OrgPriceUsd = entity.OrgPriceUsd,
                PurchasedOrgPriceUsd = entity.PurchasedOrgPriceUsd,
                Department = entity.Department,
                ReplacementReason = entity.ReplacementReason,
                PostedYear = entity.PostedYear,
                IsActive = entity.IsActive
            };
        }


        internal static CompanyProfileModel FromDataTransferObject(CompanyProfileEntity entity)
        {
            if (entity == null)
                return null;
            return new CompanyProfileModel
            {
                LineId = entity.LineId,
                AssetOwnArea = entity.AssetOwnArea,
                AssetOwnRoom = entity.AssetOwnRoom,
                AssetBuyDate = entity.AssetBuyDate,
                AssetOwnDescription = entity.AssetOwnDescription,
                AssetMutualArea = entity.AssetMutualArea,
                AssetMutualRoom = entity.AssetMutualRoom,
                AssetMutualMethod = entity.AssetMutualMethod,
                AssetMutualDescription = entity.AssetMutualDescription,
                AssetRentContractLen = entity.AssetRentContractLen,
                AssetRentPrice = entity.AssetRentPrice,
                AssetRentRoom = entity.AssetRentRoom,
                AssetRentArea = entity.AssetRentArea,
                AssetRentDescription = entity.AssetRentDescription,
                AssetNumberOfCars = entity.AssetNumberOfCars,
                AssetCarDetail = entity.AssetCarDetail,
                EmployeePayrollsTotal = entity.EmployeePayrollsTotal,
                EmployeeNumberOfWifeOrHusband = entity.EmployeeNumberOfWifeOrHusband,
                EmployeeNumberOfOfficers = entity.EmployeeNumberOfOfficers,
                EmployeeNumberOfStaff = entity.EmployeeNumberOfStaff,
                EmployeeOtherCompany = entity.EmployeeOtherCompany,
                EmployeeNumberOfSecondingOfficers = entity.EmployeeNumberOfSecondingOfficers,
                EmployeeDetail = entity.EmployeeDetail,
                EmployeeNumberOfRentLocal = entity.EmployeeNumberOfRentLocal,
                ProfileAddress = entity.ProfileAddress,
                ProfileFoundDate = entity.ProfileFoundDate,
                ProfileHeadPhone = entity.ProfileHeadPhone,
                ProfileAmbassadorName = entity.ProfileAmbassadorName,
                ProfileAmbassadorPhone = entity.ProfileAmbassadorPhone,
                ProfileAmbassadorStartDate = entity.ProfileAmbassadorStartDate,
                ProfileAmbassadorFinishDate = entity.ProfileAmbassadorFinishDate,
                ProfileAccountingManagerName = entity.ProfileAccountingManagerName,
                ProfileAccountingManagerPhone = entity.ProfileAccountingManagerPhone,
                ProfileAccountingManagerStartDate = entity.ProfileAccountingManagerStartDate,
                ProfileAccountingManagerFinishDate = entity.ProfileAccountingManagerFinishDate,
                ProfileAccountantName = entity.ProfileAccountantName,
                ProfileAccountantPhone = entity.ProfileAccountantPhone,
                ProfileAccountantStartDate = entity.ProfileAccountantStartDate,
                ProfileAccountantFinishDate = entity.ProfileAccountantFinishDate,
                ProfileMinimumSalary = entity.ProfileMinimumSalary,
                ProfileSalaryGroup = entity.ProfileSalaryGroup,
                ProfileWorkingArea = entity.ProfileWorkingArea,
                ProfileCurrencyCodeFinalization = entity.ProfileCurrencyCodeFinalization,
                ProfileServices = entity.ProfileServices,
                ProfileReportHeader = entity.ProfileReportHeader,
                ProfileBankName = entity.ProfileBankName,
                ProfileBankAddress = entity.ProfileBankAddress,
                ProfileBankAccount = entity.ProfileBankAccount,
                ProfileBankCIF = entity.ProfileBankCIF,
                OtherNote = entity.OtherNote,
                NativeCategory = entity.NativeCategory,
                ManagementArea = entity.ManagementArea
            };
        }

        internal static FixedAssetDetailAccessoryModel FromDataTransferObject(FixedAssetDetailAccessoryEntity entity)
        {
            if (entity == null)
                return null;
            return new FixedAssetDetailAccessoryModel
            {
                FixedAssetDetailAccessoryId = entity.FixedAssetDetailAccessoryId,
                FixedAssetId = entity.FixedAssetId,
                Description = entity.Description,
                Unit = entity.Unit,
                Quantity = entity.Quantity,
                Amount = entity.Amount,
                SortOrder = entity.SortOrder
            };
        }
        #endregion

        #region FromDataTransferObjects

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<UserFeaturePermisionModel> FromDataTransferObjects(IList<UserFeaturePermisionEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<OriginalGeneralLedgerModel> FromDataTransferObjects(IList<OriginalGeneralLedgerEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BUVoucherListModel> FromDataTransferObjects(IList<BUVoucherListEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BUVoucherListDetailModel> FromDataTransferObjects(IList<BUVoucherListDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BUVoucherListDetailParallelModel> FromDataTransferObjects(IList<BUVoucherListDetailParallelEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BUVoucherListDetailTransferModel> FromDataTransferObjects(IList<BUVoucherListDetailTransferEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BudgetExpenseModel> FromDataTransferObjects(IList<BudgetExpenseEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;AutoBusinessParallelModel&gt;.</returns>
        internal static List<AutoBusinessParallelModel> FromDataTransferObjects(IList<AutoBusinessParallelEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<FAIncrementDecrementModel> FromDataTransferObjects(IList<FAIncrementDecrementEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static List<FAAdjustmentModel> FromDataTransferObjects(IList<FAAdjustmentEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObjectFA).ToList();
        }

        internal static List<FAAdjustmentDetailModel> FromDataTransferObjects(IList<FAAdjustmentDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        internal static List<FAAdjustmentDetailParallelModel> FromDataTransferObjects(IList<FAAdjustmentDetailParallelEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;VoucherModel&gt;.</returns>
        internal static List<VoucherModel> FromDataTransferObjects(IList<VoucherEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<FAIncrementDecrementDetailModel> FromDataTransferObjects(IList<FAIncrementDecrementDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BudgetProvidenceModel> FromDataTransferObjects(IList<BudgetProvidenceEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<SUIncrementDecrementModel> FromDataTransferObjects(IList<SUIncrementDecrementEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<SUIncrementDecrementDetailModel> FromDataTransferObjects(IList<SUIncrementDecrementDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<SUTransferModel> FromDataTransferObjects(IList<SUTransferEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<SUTransferDetailModel> FromDataTransferObjects(IList<SUTransferDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<FADepreciationModel> FromDataTransferObjects(IList<FADepreciationEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<FADepreciationDetailModel> FromDataTransferObjects(IList<FADepreciationDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BAWithDrawModel> FromDataTransferObjects(IList<BAWithDrawEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BAWithDrawDetailModel> FromDataTransferObjects(IList<BAWithDrawDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        internal static List<BAWithDrawDetailModel> FromDataTransferObjectsCA(IList<CAPaymentDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObjectCA).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BAWithDrawDetailFixedAssetModel> FromDataTransferObjects(IList<BAWithDrawDetailFixedAssetEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        internal static List<BAWithDrawDetailFixedAssetModel> FromDataTransferObjectsCA(IList<CAPaymentDetailFixedAssetEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObjectCA).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BAWithDrawDetailPurchaseModel> FromDataTransferObjects(IList<BAWithDrawDetailPurchaseEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BAWithdrawDetailSalaryModel> FromDataTransferObjects(IList<BAWithdrawDetailSalaryEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BAWithdrawDetailTaxModel> FromDataTransferObjects(IList<BAWithdrawDetailTaxEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;BAWithDrawDetailParallelModel&gt;.</returns>
        internal static List<BAWithDrawDetailParallelModel> FromDataTransferObjects(IList<BAWithDrawDetailParallelEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        internal static List<BUTransferDetailParallelModel> FromDataTransferObjects(IList<BUTransferDetailParallelEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;BABankTransferDetailParallelModel&gt;.</returns>
        internal static List<BABankTransferDetailParallelModel> FromDataTransferObjects(IList<BABankTransferDetailParallelEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<CashWithdrawTypeModel> FromDataTransferObjects(IList<CashWithdrawTypeEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BADepositModel> FromDataTransferObjects(IList<BADepositEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>List&lt;INInwardOutwardModel&gt;.</returns>
        internal static List<INInwardOutwardModel> FromDataTransferObjects(IList<INInwardOutwardEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BADepositDetailModel> FromDataTransferObjects(IList<BADepositDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BADepositDetailSaleModel> FromDataTransferObjects(IList<BADepositDetailSaleEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BADepositDetailTaxModel> FromDataTransferObjects(IList<BADepositDetailTaxEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<BADepositDetailFixedAssetModel> FromDataTransferObjects(IList<BADepositDetailFixedAssetEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;BABankTransferModel&gt;.</returns>
        internal static IList<BABankTransferModel> FromDataTransferObjects(IList<BABankTransferEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;BABankTransferDetailModel&gt;.</returns>
        internal static IList<BABankTransferDetailModel> FromDataTransferObjects(IList<BABankTransferDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;BUCommitmentRequestModel&gt;.</returns>
        internal static IList<BUCommitmentRequestModel> FromDataTransferObjects(IList<BUCommitmentRequestEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;BUCommitmentRequestDetailModel&gt;.</returns>
        internal static IList<BUCommitmentRequestDetailModel> FromDataTransferObjects(IList<BUCommitmentRequestDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;BUCommitmentAdjustmentModel&gt;.</returns>
        internal static IList<BUCommitmentAdjustmentModel> FromDataTransferObjects(IList<BUCommitmentAdjustmentEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;BUCommitmentAdjustmentDetailModel&gt;.</returns>
        internal static IList<BUCommitmentAdjustmentDetailModel> FromDataTransferObjects(IList<BUCommitmentAdjustmentDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;OpeningCommitmentModel&gt;.</returns>
        internal static IList<OpeningCommitmentModel> FromDataTransferObjects(IList<OpeningCommitmentEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;OpeningSupplyEntryModel&gt;.</returns>
        internal static IList<OpeningSupplyEntryModel> FromDataTransferObjects(IList<OpeningSupplyEntryEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(m => AutoMapper(m, new OpeningSupplyEntryModel())).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;OpeningCommitmentDetailModel&gt;.</returns>
        internal static IList<OpeningCommitmentDetailModel> FromDataTransferObjects(IList<OpeningCommitmentDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>System.Collections.Generic.IList&lt;Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate.BUTransferModel&gt;.</returns>
        internal static IList<BUTransferModel> FromDataTransferObjects(IList<BUTransferEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>System.Collections.Generic.IList&lt;Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate.BUTransferDetailModel&gt;.</returns>
        internal static IList<BUTransferDetailModel> FromDataTransferObjects(IList<BUTransferDetailEntity> entities)
        {

            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        internal static List<INInwardOutwardDetailModel> FromDataTransferObjects(IList<INInwardOutwardDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<PurchasePurposeModel> FromDataTransferObjects(IList<PurchasePurposeEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static List<SalaryVoucherModel> FromDataTransferObjects(IList<SalaryVoucherEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static List<AutoNumberListModel> FromDataTransferObjects(IList<AutoNumberListEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static List<MutualModel> FromDataTransferObjects(IList<MutualEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<SearchModel> FromDataTransferObjects(IList<SearchEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetHousingReportModel> FromDataTransferObjects(IList<FixedAssetHousingReportEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountingVoucherModel> FromDataTransferObjects(IList<AccountingVoucherEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;CAReceiptModel&gt;.</returns>
        internal static IList<CAReceiptModel> FromDataTransferObjects(IList<CAReceiptEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;CAReceiptModel&gt;.</returns>
        internal static IList<CAReceiptDetailModel> FromDataTransferObjects(IList<CAReceiptDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;CAReceiptDetailTaxModel&gt;.</returns>
        internal static IList<CAReceiptDetailTaxModel> FromDataTransferObjects(IList<CAReceiptDetailTaxEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;CAReceiptDetailParallelModel&gt;.</returns>
        internal static IList<CAReceiptDetailParallelModel> FromDataTransferObjects(IList<CAReceiptDetailParallelEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;CAPaymentModel&gt;.</returns>
        internal static IList<CAPaymentModel> FromDataTranferObjects(IList<CAPaymentEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;CAPaymentDetailModel&gt;.</returns>
        internal static IList<CAPaymentDetailModel> FromDataTranferObjects(IList<CAPaymentDetailEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();

        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;CAPaymentDetailTaxModel&gt;.</returns>
        internal static IList<CAPaymentDetailTaxModel> FromDataTranferObjects(IList<CAPaymentDetailTaxEntity> entities)
        {
            if (entities == null)
            { return null; }
            return entities.Select(FromDataTransferObject).ToList();

        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;CAPaymentDetailPurchaseModel&gt;.</returns>
        internal static IList<CAPaymentDetailPurchaseModel> FromDataTranferObjects(IList<CAPaymentDetailPurchaseEntity> entities)
        {
            if (entities == null)
            { return null; }
            return entities.Select(FromDataTransferObject).ToList();

        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<CAPaymentDetailFixedAssetModel> FromDataTransferObjects(IList<CAPaymentDetailFixedAssetEntity> entities)
        {
            if (entities == null)
            { return null; }
            return entities.Select(FromDataTransferObject).ToList();
        }
        internal static IList<BUTransferDetailFixedAssetlModel> FromDataTransferObjectsBU(IList<CAPaymentDetailFixedAssetEntity> entities)
        {
            if (entities == null)
            { return null; }
            return entities.Select(FromDataTransferObjectBU).ToList();
        }
        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;CAPaymentDetailParallelModel&gt;.</returns>
        internal static IList<CAPaymentDetailParallelModel> FromDataTransferObjects(IList<CAPaymentDetailParallelEntity> entities)
        {
            if (entities == null)
            { return null; }
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;BADepositDetailParallelModel&gt;.</returns>
        internal static IList<BADepositDetailParallelModel> FromDataTransferObjects(IList<BADepositDetailParallelEntity> entities)
        {
            if (entities == null)
            { return null; }
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BUPlanReceiptModel> FromDataTransferObjects(IList<BUPlanReceiptEntity> entities)
        {
            if (entities == null)
            { return null; }
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BUPlanReceiptDetailModel> FromDataTranferObjects(IList<BUPlanReceiptDetailEntity> entities)
        {
            if (entities == null)
            { return null; }
            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<BUPlanAdjustmentModel> FromDataTranferObjects(IList<BUPlanAdjustmentEntity> entities)
        {
            if (entities == null)
            {
                return null;
            }
            return entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<BUPlanAdjustmentDetailModel> FromDataTranferObjects(IList<BUPlanAdjustmentDetailEntity> entities)
        {
            if (entities == null)
            {
                return null;
            }
            return entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BUBudgetReserveModel> FromDataTransferObjects(IList<BUBudgetReserveEntity> entities)
        {
            if (entities == null)
            { return null; }
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BUBudgetReserveDetailModel> FromDataTranferObjects(IList<BUBudgetReserveDetailEntity> entities)
        {
            if (entities == null)
            { return null; }
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GLVoucherModel> FromDataTranferObjects(IList<GLVoucherEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GLVoucherDetailModel> FromDataTranferObjects(IList<GLVoucherDetailEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GLVoucherDetailTaxModel> FromDataTranferObjects(IList<GLVoucherDetailTaxEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;GLVoucherDetailParallelModel&gt;.</returns>
        internal static IList<GLVoucherDetailParallelModel> FromDataTranferObjects(IList<GLVoucherDetailParallelEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;GLVoucherListModel&gt;.</returns>
        internal static IList<GLVoucherListModel> FromDataTranferObjects(IList<GLVoucherListEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;GLVoucherListModel&gt;.</returns>
        internal static IList<GLPaymentListModel> FromDataTranferObjects(IList<GLPaymentListEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;GLVoucherListDetailModel&gt;.</returns>
        internal static IList<GLVoucherListDetailModel> FromDataTranferObjects(IList<GLVoucherListDetailEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;GLVoucherListDetailModel&gt;.</returns>
        internal static IList<GLPaymentListDetailModel> FromDataTranferObjects(IList<GLPaymentListDetailEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;GLVoucherListParamaterModel&gt;.</returns>
        internal static IList<GLVoucherListParamaterModel> FromDataTranferObjects(IList<GLVoucherListParamaterEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GLVoucherListLedgerModel> FromDataTranferObjects(IList<GLVoucherListLedgerEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<S02CHModel> FromDataTranferObjects(IList<S02CHEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data tranfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<S51HModel> FromDataTranferObjects(IList<S51HEntity> entities)
        {

            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GLVoucherModel FromDataTransferObject(GLVoucherEntity entity)
        {
            if (entity == null)
                return null;
            return new GLVoucherModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate,
                ParalellRefNo = entity.ParalellRefNo,
                JournalMemo = entity.JournalMemo,
                TotalAmount = entity.TotalAmount,
                TotalAmountOC = entity.TotalAmountOC,
                ParentRefId = entity.ParentRefId,
                Posted = entity.Posted,
                PostVersion = entity.PostVersion,
                EditVersion = entity.EditVersion,
                BUTransferRefId = entity.BUTransferRefId,
                BUTransferType = entity.BUTransferType,
                AccountingObjectId = entity.AccountingObjectId,
                GLVoucherDetails = FromDataTranferObjects(entity.GLVoucherDetails),
                GLVoucherDetailTaxes = FromDataTranferObjects(entity.GLVoucherDetailTaxes),
                GLVoucherDetailParalles = FromDataTranferObjects(entity.GLVoucherDetailParallels),
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GLVoucherDetailModel FromDataTransferObject(GLVoucherDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new GLVoucherDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetKindItemCode = entity.BudgetKindItemCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                MethodDistributeId = entity.MethodDistributeId,
                CashWithDrawTypeId = entity.CashWithDrawTypeId,
                AccountingObjectId = entity.AccountingObjectId,
                CreditAccountingObjectId = entity.CreditAccountingObjectId,
                ActivityId = entity.ActivityId,
                ProjectId = entity.ProjectId,
                ProjectActivityId = entity.ProjectActivityId,
                ProjectExpenseId = entity.ProjectExpenseId,
                TaskId = entity.TaskId,
                ListItemId = entity.ListItemId,
                Approved = entity.Approved,
                ParentRefDetailId = entity.ParentRefDetailId,
                SortOrder = entity.SortOrder,
                BudgetDetailItemCode = entity.BudgetDetailItemCode,
                OrgRefNo = entity.OrgRefNo,
                OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,
                BankAccount = entity.BankAccount,
                FundStructureId = entity.FundStructureId,
                ProjectExpenseEAId = entity.ProjectExpenseEAId,
                ProjectActivityEAId = entity.ProjectActivityEAId,
                BudgetProvideCode = entity.BudgetProvideCode,
                TopicId = entity.TopicId,
                BudgetExpenseId = entity.BudgetExpenseId,
                BankId = entity.BankId,
                ContractId = entity.ContractId,
                CapitalPlanId = entity.CapitalPlanId,
                AutoBusinessId = entity.AutoBusinessID,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static GLVoucherDetailTaxModel FromDataTransferObject(GLVoucherDetailTaxEntity entity)
        {
            if (entity == null)
                return null;
            return new GLVoucherDetailTaxModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                Description = entity.Description,
                VATAmount = entity.VATAmount,
                VATRate = entity.VATRate,
                TurnOver = entity.TurnOver,
                InvType = entity.InvType,
                InvDate = entity.InvDate,
                InvSeries = entity.InvSeries,
                InvNo = entity.InvNo,
                PurchasePurposeId = entity.PurchasePurposeId,
                AccountingObjectId = entity.AccountingObjectId,
                AccountingObjectName = entity.AccountingObjectName,
                AccountingObjectAddress = entity.AccountingObjectAddress,
                CompanyTaxCode = entity.CompanyTaxCode,
                SortOrder = entity.SortOrder,
                InvoiceTypeCode = entity.InvoiceTypeCode

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>GLVoucherListModel.</returns>
        internal static GLVoucherListModel FromDataTransferObject(GLVoucherListEntity entity)
        {
            if (entity == null)
                return null;
            return new GLVoucherListModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                VoucherTypeId = entity.VoucherTypeId,
                SetupType = entity.SetupType,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                Description = entity.Description,
                TotalAmount = entity.TotalAmount,
                EditVersion = entity.EditVersion,
                GlVoucherListDetails = FromDataTranferObjects(entity.GlVoucherListDetails)

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static GLPaymentListModel FromDataTransferObject(GLPaymentListEntity entity)
        {
            if (entity == null)
                return null;
            return new GLPaymentListModel
            {
                RefId = entity.RefId,
                RefType = entity.RefType,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                VoucherTypeId = entity.VoucherTypeId,
                SetupType = entity.SetupType,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                Description = entity.Description,
                TotalAmount = entity.TotalAmount,
                EditVersion = entity.EditVersion,
                GLPaymentListDetails = FromDataTranferObjects(entity.GLPaymentListDetails)

            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>GLVoucherListDetailModel.</returns>
        internal static GLVoucherListDetailModel FromDataTransferObject(GLVoucherListDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new GLVoucherListDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                DetailRefType = entity.DetailRefType,
                DetailRefId = entity.DetailRefId,
                DetailId = entity.DetailId,
                SortOrder = entity.SortOrder,
                EntryType = entity.EntryType,
                BudgetSourceId = entity.BudgetSourceId,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                RefNoTotal = entity.RefNoTotal,
                RefDateTotal = entity.RefDateTotal,
                RefNoCount = entity.RefNoCount,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>GLVoucherListDetailModel.</returns>
        internal static GLPaymentListDetailModel FromDataTransferObject(GLPaymentListDetailEntity entity)
        {
            if (entity == null)
                return null;
            return new GLPaymentListDetailModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                DetailRefType = entity.DetailRefType,
                DetailRefId = entity.DetailRefId,
                DetailId = entity.DetailId,
                SortOrder = entity.SortOrder,
                EntryType = entity.EntryType,
                BudgetSourceId = entity.BudgetSourceId,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                RefNoTotal = entity.RefNoTotal,
                RefDateTotal = entity.RefDateTotal,
                RefNoCount = entity.RefNoCount,
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>GLVoucherListParamaterModel.</returns>
        internal static GLVoucherListParamaterModel FromDataTransferObject(GLVoucherListParamaterEntity entity)
        {
            if (entity == null)
                return null;
            return new GLVoucherListParamaterModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                DetailRefType = entity.DetailRefType,
                BudgetSourceId = entity.BudgetSourceId,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                RefNo = entity.RefNo,
                Description = entity.Description,
                DebitAccount = entity.DebitAccount,
                CreditAccount = entity.CreditAccount,
                Amount = entity.Amount,
                AmountOC = entity.AmountOC,
                OrgRefNo = entity.OrgRefNo,
                //OrgRefDate = entity.OrgRefDate == DateTime.MinValue ? null : entity.OrgRefDate,  -- AnhNT comment vi gay loi project
                OrgRefDate = entity.OrgRefDate,
                ProjectId = entity.ProjectId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetItemCode = entity.BudgetItemCode,
                BudgetSubItemCode = entity.BudgetSubItemCode,
                CurrencyCode = entity.CurrencyCode,
                ExchangeRate = entity.ExchangeRate


            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>GLVoucherListLedgerModel.</returns>
        internal static GLVoucherListLedgerModel FromDataTransferObject(GLVoucherListLedgerEntity entity)
        {
            if (entity == null)
                return null;
            return new GLVoucherListLedgerModel
            {
                RefDetailId = entity.RefDetailId,
                RefId = entity.RefId,
                RefNo = entity.RefNo,
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccount = entity.CorrespondingAccount,
                DebitAmount = entity.DebitAmount,
                CreditAmount = entity.CreditAmount,
                BudgetSourceId = entity.BudgetSourceId,
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                Description = entity.Description,
                StartOfMonth = entity.StartOfMonth
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S02CHModel FromDataTransferObject(S02CHEntity entity)
        {
            if (entity == null)
                return null;
            return new S02CHModel
            {
                BudgetChapterCode = entity.BudgetChapterCode,
                BudgetSourceCode = entity.BudgetSourceCode,
                BudgetSourceName = entity.BudgetSourceName,
                BudgetSubKindItemCode = entity.BudgetSubKindItemCode,
                RefID = entity.RefID,
                RefType = entity.RefType,
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                Description = entity.Description,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                DebitAmount = entity.DebitAmount,
                CreditAmount = entity.CreditAmount,
                AccountNumber = entity.AccountNumber,
                OpeningAmount = entity.OpeningAmount,
                AccumDebitAmountQuater = entity.AccumDebitAmountQuater,
                AccumCreditAmountQuater = entity.AccumCreditAmountQuater,
                AccumDebitAmountYear = entity.AccumDebitAmountYear,
                AccumCreditAmountYear = entity.AccumCreditAmountYear,
                Month = entity.Month,
                BeginMonth = entity.BeginMonth,
                BeginQuarter = entity.BeginQuarter,
                AccountCategoryKind = entity.AccountCategoryKind,
                Grade = entity.Grade,
                AccLevel = entity.AccLevel
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static S51HModel FromDataTransferObject(S51HEntity entity)
        {
            if (entity == null)
                return null;
            return new S51HModel
            {
                RefNo = entity.RefNo,
                RefDate = entity.RefDate,
                PostedDate = entity.PostedDate,
                Description = entity.Description,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
                TotalAmount = entity.TotalAmount,
                DiscountAmount = entity.DiscountAmount,
                Part = entity.Part,
                ActivityId = entity.ActivityId,
                ActivityCode = entity.ActivityCode,
                ActivityName = entity.ActivityName,
                InventoryItemId = entity.InventoryItemId,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemName = entity.InventoryItemName,
                RefType = entity.RefType,
                RefId = entity.RefId
            };
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;MinutesInventoryToolModel&gt;.</returns>
        internal static IList<MinutesInventoryToolModel> FromDataTransferObjects(IList<MinutesInventoryToolEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<InventoryBookModel> FromDataTransferObjects(IList<InventoryBookEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<ToolIncrementDecrementModel> FromDataTransferObjects(
            IList<ToolIncrementDecrementEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>IList&lt;CashInBankConfirmationBalanceSheetModel&gt;.</returns>
        internal static IList<CashInBankConfirmationBalanceSheetModel> FromDataTransferObjects(IList<CashInBankConfirmationBalanceSheetEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<SalaryModel> FromDataTransferObjects(IList<SalaryEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<CapitalAllocateModel> FromDataTransferObjects(IList<CapitalAllocateEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<CurrencyModel> FromDataTransferObjects(IList<CurrencyEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetSourcePropertyModel> FromDataTransferObjects(IList<BudgetSourcePropertyEntity> entities)
        {
            if (entities == null)
                return null;

            //return entities.Select(FromDataTransferObject).ToList();
            return null;
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountModel> FromDataTransferObjects(IList<AccountEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountCategoryModel> FromDataTransferObjects(IList<AccountCategoryEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<DepartmentModel> FromDataTransferObjects(IList<DepartmentEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EmployeeTypeModel> FromDataTransferObjects(IList<EmployeeTypeEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetSourceCategoryModel> FromDataTransferObjects(IList<BudgetSourceCategoryEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetItemModel> FromDataTransferObjects(IList<BudgetItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetGroupItemModel> FromDataTransferObjects(IList<BudgetGroupItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetKindItemModel> FromDataTransferObjects(IList<BudgetKindItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<PlanTemplateListModel> FromDataTransferObjects(IList<PlanTemplateListEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<PlanTemplateItemModel> FromDataTransferObjects(IList<PlanTemplateItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetCategoryModel> FromDataTransferObjects(IList<FixedAssetCategoryEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetModel> FromDataTransferObjects(IList<FixedAssetEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        internal static IList<FixedAssetActivityModel> FromDataTransferObjects(IList<FixedAssetActivityEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<PayItemModel> FromDataTransferObjects(IList<PayItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetChapterModel> FromDataTransferObjects(IList<BudgetChapterEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetCategoryModel> FromDataTransferObjects(IList<BudgetCategoryEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<MergerFundModel> FromDataTransferObjects(IList<MergerFundEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BudgetSourceModel> FromDataTransferObjects(IList<BudgetSourceEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<VendorModel> FromDataTransferObjects(List<VendorEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountingObjectModel> FromDataTransferObjects(IList<AccountingObjectEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        internal static IList<AccountingObjectCategoryModel> FromDataTransferObjects(IList<AccountingObjectCategoryEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<CustomerModel> FromDataTransferObjects(List<CustomerEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<VoucherListModel> FromDataTransferObjects(IList<VoucherListEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<InvoiceFormNumberModel> FromDataTransferObjects(IList<InvoiceFormNumberEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<InvoiceTypeModel> FromDataTransferObjects(IList<InvoiceTypeEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EmployeeModel> FromDataTransferObjects(IList<EmployeeEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EmployeePayItemModel> FromDataTransferObjects(IList<EmployeePayItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<StockModel> FromDataTransferObjects(IList<StockEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<CaptitalAllocateVoucherModel> FromDataTransferObjects(IList<CaptitalAllocateVoucherEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountTranferVourcherModel> FromDataTransferObjects(IList<AccountTranferVourcherEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<InventoryItemModel> FromDataTransferObjects(IList<InventoryItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<InventoryItemdestinationModel> FromDataTransferObjects(IList<InventoryItemdestinationEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }


        internal static IList<InventoryItemCategoryModel> FromDataTransferObjects(IList<InventoryItemCategoryEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BankModel> FromDataTransferObjects(IList<BankEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        internal static IList<ActivityModel> FromDataTransferObjects(IList<ActivityEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<ExchangeRateModel> FromDataTransferObjects(IList<ExchangeRateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountTransferModel> FromDataTransferObjects(IList<AccountTransferEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<DBOptionModel> FromDataTransferObjects(IList<DBOptionEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<ReportListModel> FromDataTransferObjects(List<ReportListEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<ReportGroupModel> FromDataTransferObjects(List<ReportGroupEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AudittingLogModel> FromDataTransferObjects(IList<AudittingLogEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<BUPlanWithdrawModel> FromDataTransferObjects(IList<BUPlanWithdrawEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }
        internal static IList<BUPlanWithdrawDetailModel> FromDataTransferObjects(IList<BUPlanWithdrawDetailEntity> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<GeneralVocherModel> FromDataTransferObjects(IList<GeneralEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<VoucherTypeModel> FromDataTransferObjects(IList<VoucherTypeEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AutoBusinessModel> FromDataTransferObjects(IList<AutoBusinessEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<ProjectModel> FromDataTransferObjects(IList<ProjectEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        internal static IList<ContractModel> FromDataTransferObjects(IList<ContractEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        internal static IList<ContractDetailsModel> FromDataTransferObjects(IList<ContractDetailEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        internal static IList<TaxItemModel> FromDataTransferObjects(IList<TaxItemEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        internal static IList<TaxTypeModel> FromDataTransferObjects(IList<TaxTypeEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        internal static IList<FundStructureModel> FromDataTransferObjects(IList<FundStructureEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<CompanyProfileModel> FromDataTransferObjects(IList<CompanyProfileEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<RefTypeModel> FromDataTransferObjects(IList<RefTypeEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetArmortizationModel> FromDataTransferObjects(IList<FAArmortizationEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetArmortizationDetailModel> FromDataTransferObjects(IList<FAArmortizationDetailEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetDecrementModel> FromDataTransferObjects(IList<FADecrementEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetDecrementDetailModel> FromDataTransferObjects(IList<FADecrementDetailEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetIncrementModel> FromDataTransferObjects(IList<FAIncrementEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetIncrementDetailModel> FromDataTransferObjects(IList<FAIncrementDetailEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetCurrencyModel> FromDataTransferObjects(IList<FixedAssetCurrencyEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<OpeningAccountEntryModel> FromDataTransferObjects(IList<OpeningAccountEntryEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        internal static IList<OpeningAccountEntryEntity> ToDataTransferObjects(IList<OpeningAccountEntryModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<OpeningInventoryEntryModel> FromDataTransferObjects(IList<OpeningInventoryEntryEntity> entities)
        {
            return entities == null ? null : entities.Select(m => AutoMapper(m, new OpeningInventoryEntryModel())).ToList();
        }
        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<OpeningAccountEntryDetailModel> FromDataTransferObjects(IList<OpeningAccountEntryDetailEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GeneralReceiptEstimateModel> FromDataTransferObjects(IList<GeneralReceiptEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GeneralPaymentEstimateModel> FromDataTransferObjects(IList<GeneralPaymentEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GeneralEstimateModel> FromDataTransferObjects(IList<GeneralEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<GeneralPaymentDetailEstimateModel> FromDataTransferObjects(IList<GeneralPaymentDetailEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }



        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetFAInventoryModel> FromDataTransferObjects(IList<FixedAssetFAInventoryEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetFAInventoryCarModel> FromDataTransferObjects(IList<FixedAssetFAInventoryCarEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetFAInventoryHouseModel> FromDataTransferObjects(IList<FixedAssetFAInventoryHouseEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }


        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<AutoIDModel> FromDataTransferObjects(IList<AutoIDEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetLedgerModel> FromDataTransferObjects(IList<FixedAssetLedgerEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetVoucherModel> FromDataTransferObjects(IList<FixedAssetVoucherEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<RoleModel> FromDataTransferObjects(IList<RoleEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<SiteModel> FromDataTransferObjects(IList<SiteEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<PermissionModel> FromDataTransferObjects(IList<PermissionEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<PermissionSiteModel> FromDataTransferObjects(IList<PermissionSiteEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<RoleSiteModel> FromDataTransferObjects(IList<RoleSiteEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<OpeningFixedAssetEntryModel> FromDataTransferObjects(IList<OpeningFixedAssetEntryEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EmployeeLeasingModel> FromDataTransferObjects(IList<EmployeeLeasingEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<BuildingModel> FromDataTransferObjects(IList<BuildingEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EmployeeForEstimateModel> FromDataTransferObjects(IList<EmployeeForEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FixedAssetForEstimateModel> FromDataTransferObjects(IList<FixedAssetForEstimateEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }


        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<FundStuationModel> FromDataTransferObjects(IList<FundStuationEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementInfoModel> FromDataTransferObjects(IList<EstimateDetailStatementInfoEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementPartBModel> FromDataTransferObjects(IList<EstimateDetailStatementPartBEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementFixedAssetModel> FromDataTransferObjects(IList<EstimateDetailStatementFixedAssetEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }

        internal static IList<FixedAssetDetailAccessoryModel> FromDataTransferObjects(IList<FixedAssetDetailAccessoryEntity> entities)
        {
            return entities == null ? null : entities.Select(FromDataTransferObject).ToList();
        }
        #endregion

        #region ToDataTransferObject

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FeatureEntity ToDataTransferObject(FeaturesModel model)
        {
            return new FeatureEntity
            {
                FeatureID = model.FeatureID,
                IsActive = model.IsActive,
                Code = model.Code,
                Name = model.Name,
                Description = model.Description,
                FormMasterName = model.FormMasterName,
                MenuItemCode = model.MenuItemCode,
                ParentID = model.ParentID,
                FormDetailName = model.FormDetailName
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FeaturePermisionEntity ToDataTransferObject(FeaturePermisionModel model)
        {
            return new FeaturePermisionEntity
            {
                UserPermisionID = model.UserPermisionID,
                FeatureID = model.FeatureID,
                FeaturePermisionID = model.FeaturePermisionID
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static UserFeaturePermisionEntity ToDataTransferObject(UserFeaturePermisionModel model)
        {
            return new UserFeaturePermisionEntity
            {
                UserPermisionID = model.UserPermisionID,
                FeatureID = model.FeatureID,
                IsActive = model.IsActive,
                UserFeaturePermisionID = model.UserFeaturePermisionID,
                UserProfileID = model.UserProfileID
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BUVoucherListEntity ToDataTransferObject(BUVoucherListModel model)
        {
            return new BUVoucherListEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                ParalellRefNo = model.ParalellRefNo,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                JournalMemo = model.JournalMemo,
                Posted = model.Posted,
                TotalAmount = model.TotalAmount,
                PostVersion = model.PostVersion,
                EditVersion = model.EditVersion,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                TotalAmountOC = model.TotalAmountOC,

                BUVoucherListDetailEntities = ToDataTransferObjects(model.BUVoucherListDetailModels),
                BUVoucherListDetailParallelEntities = ToDataTransferObjects(model.BUVoucherListDetailParallelModels),
                BUVoucherListDetailTransferEntities = ToDataTransferObjects(model.BUVoucherListDetailTransferModels)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BUVoucherListDetailTransferEntity ToDataTransferObject(BUVoucherListDetailTransferModel model)
        {
            return new BUVoucherListDetailTransferEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                Amount = model.Amount,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Description = model.Description,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                AmountOC = model.AmountOC,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                FundStructureId = model.FundStructureId,
                BankAccount = model.BankAccount,
                AccountingObjectId = model.AccountingObjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                ListItemId = model.ListItemId,
                ProjectExpenseEAId = model.ProjectExpenseEAId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BudgetProvideCode = model.BudgetProvideCode,
                BudgetExpenseId = model.BudgetExpenseId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BUVoucherListDetailParallelEntity ToDataTransferObject(BUVoucherListDetailParallelModel model)
        {
            return new BUVoucherListDetailParallelEntity
            {
                RefDetailId = model.RefDetailId,
                ParentRefDetailId = model.ParentRefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetProvideCode = model.BudgetProvideCode,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                SortOrder = model.SortOrder,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankAccount = model.BankAccount,
                BudgetExpenseId = model.BudgetExpenseId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BUVoucherListDetailEntity ToDataTransferObject(BUVoucherListDetailModel model)
        {
            return new BUVoucherListDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                VoucherRefType = model.VoucherRefType,
                VoucherRefId = model.VoucherRefId,
                VoucherRefDetailId = model.VoucherRefDetailId,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                ProjectId = model.ProjectId,
                ActivityId = model.ActivityId,
                SortOrder = model.SortOrder,
                Approved = model.Approved,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                AmountOC = model.AmountOC,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                FundStructureId = model.FundStructureId,
                BankAccount = model.BankAccount,
                AccountingObjectId = model.AccountingObjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                ListItemId = model.ListItemId,
                ProjectExpenseEAId = model.ProjectExpenseEAId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BudgetProvideCode = model.BudgetProvideCode,
                BudgetExpenseId = model.BudgetExpenseId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FAIncrementDecrementEntity ToDataTransferObject(FAIncrementDecrementModel model)
        {
            return new FAIncrementDecrementEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                ParalellRefNo = model.ParalellRefNo,
                JournalMemo = model.JournalMemo,
                TotalAmount = model.TotalAmount,
                GeneratedRefId = model.GeneratedRefId,
                FAIncrementDecrementDetails = ToDataTransferObjects(model.FAIncrementDecrementDetails)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FAIncrementDecrementDetailEntity ToDataTransferObject(FAIncrementDecrementDetailModel model)
        {
            return new FAIncrementDecrementDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                FixedAssetId = model.FixedAssetId,
                Description = model.Description,
                DepartmentId = model.DepartmentId,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                ProjectExpenseEAId = model.ProjectExpenseEAId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                DecreaseReasonId = model.DecreaseReasonId,

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BudgetProvidenceEntity ToDataTransferObject(BudgetProvidenceModel model)
        {
            return new BudgetProvidenceEntity
            {
                BudgetProvideId = model.BudgetProvideId,
                BudgetProvideCode = model.BudgetProvideCode,
                BudgetProvideName = model.BudgetProvideName,
                IsSystem = model.IsSystem,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static SUIncrementDecrementEntity ToDataTransferObject(SUIncrementDecrementModel model)
        {
            return new SUIncrementDecrementEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                ParalellRefNo = model.ParalellRefNo,
                JournalMemo = model.JournalMemo,
                TotalAmount = model.TotalAmount,
                EditVersion = model.EditVersion,
                SUIncrementDecrementDetails = ToDataTransferObjects(model.SUIncrementDecrementDetails)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static SUIncrementDecrementDetailEntity ToDataTransferObject(SUIncrementDecrementDetailModel model)
        {
            return new SUIncrementDecrementDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                InventoryItemId = model.InventoryItemId,
                Description = model.Description,
                DepartmentId = model.DepartmentId,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Quantity = model.Quantity,
                QuantityConvert = model.QuantityConvert,
                UnitPrice = model.UnitPrice,
                UnitPriceConvert = model.UnitPriceConvert,
                Amount = model.Amount,
                BudgetChapterCode = model.BudgetChapterCode,
                AccountingObjectId = model.AccountingObjectId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                BudgetSourceId = model.BudgetSourceId,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetProvideCode = model.BudgetProvideCode,
                TopicId = model.TopicId,

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static SUTransferEntity ToDataTransferObject(SUTransferModel model)
        {
            return new SUTransferEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                ParalellRefNo = model.ParalellRefNo,
                JournalMemo = model.JournalMemo,
                TotalAmount = model.TotalAmount,
                EditVersion = model.EditVersion,
                SUTransferDetails = ToDataTransferObjects(model.SUTransferDetails)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static SUTransferDetailEntity ToDataTransferObject(SUTransferDetailModel model)
        {
            return new SUTransferDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                InventoryItemId = model.InventoryItemId,
                Description = model.Description,
                FromDepartmentId = model.FromDepartmentId,
                ToDepartmentId = model.ToDepartmentId,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                Amount = model.Amount,
                BudgetChapterCode = model.BudgetChapterCode,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FADepreciationEntity ToDataTransferObject(FADepreciationModel model)
        {
            return new FADepreciationEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                ParalellRefNo = model.ParalellRefNo,
                JournalMemo = model.JournalMemo,
                TotalAmount = model.TotalAmount,
                PeriodType = model.PeriodType,
                PeriodTypeName = model.PeriodTypeName,
                FADepreciationDetails = ToDataTransferObjects(model.FADepreciationDetails)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FADepreciationDetailEntity ToDataTransferObject(FADepreciationDetailModel model)
        {
            return new FADepreciationDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                FixedAssetId = model.FixedAssetId,
                FixedAssetName = model.FixedAssetName,
                OrgPrice = model.OrgPrice,
                AnnualDepreciationRate = model.AnnualDepreciationRate,
                AnnualDepreciationAmount = model.AnnualDepreciationAmount,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                FundStructureId = model.FundStructureId,
                ProjectExpenseEAId = model.ProjectExpenseEAId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BudgetProvideCode = model.BudgetProvideCode,
                TopicId = model.TopicId,
                BudgetExpenseId = model.BudgetExpenseId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                IsParallel = model.IsParallel
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BAWithDrawEntity ToDataTransferObject(BAWithDrawModel model)
        {
            ////var parallels = new List<SelectItemEntity>();
            ////if (model.Parallels != null)
            ////{
            ////    model.Parallels.ForEach(item =>
            ////    {
            ////        var parallel = new SelectItemEntity()
            ////        {
            ////            Credit = item.Credit,
            ////            Debit = item.Debit
            ////        };
            ////        parallels.Add(parallel);
            ////    });
            ////}
            return new BAWithDrawEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                ParalellRefNo = model.ParalellRefNo,
                InwardRefNo = model.InwardRefNo,
                IncrementRefNo = model.IncrementRefNo,
                BankId = model.BankId,
                BankName = model.BankName,
                JournalMemo = model.JournalMemo,
                AccountingObjectId = model.AccountingObjectId,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                TotalTaxAmount = model.TotalTaxAmount,
                TotalFreightAmount = model.TotalFreightAmount,
                TotalInwardAmount = model.TotalInwardAmount,
                Reconciled = model.Reconciled,
                Posted = model.Posted,
                PostVersion = model.PostVersion,
                EditVersion = model.EditVersion,
                RefOrder = model.RefOrder,
                RelationRefId = model.RelationRefId,
                RelationType = model.RelationType,
                TotalPaymentAmount = model.TotalPaymentAmount,
                AccountingObjectBankAccount = model.AccountingObjectBankAccount,
                BAWithDrawDetails = ToDataTransferObjects(model.BAWithDrawDetails),
                BAWithDrawDetailFixedAssets = ToDataTransferObjects(model.BAWithDrawDetailFixedAssets),
                BAWithDrawDetailPurchases = ToDataTransferObjects(model.BAWithDrawDetailPurchases),
                BAWithdrawDetailSalarys = ToDataTransferObjects(model.BAWithdrawDetailSalarys),
                BAWithdrawDetailTaxs = ToDataTransferObjects(model.BAWithdrawDetailTaxs),
                BAWithDrawDetailParallels = ToDataTransferObjects(model.BAWithDrawDetailParallels),
                ReceiveId = model.ReceiveId,
                ReceiveIssueDate = model.ReceiveIssueDate,
                ReceiveName = model.ReceiveName,
                ReceiveIssueLocation = model.ReceiveIssueLocation

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BAWithDrawDetailEntity ToDataTransferObject(BAWithDrawDetailModel model)
        {
            return new BAWithDrawDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                FundId = model.FundId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BudgetExpenseId = model.BudgetExpenseId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BankId = model.BankId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                AutoBusinessId = model.AutoBusinessId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BAWithDrawDetailFixedAssetEntity ToDataTransferObject(BAWithDrawDetailFixedAssetModel model)
        {
            return new BAWithDrawDetailFixedAssetEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                FixedAssetId = model.FixedAssetId,
                Description = model.Description,
                DepartmentId = model.DepartmentId,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                TaxRate = model.TaxRate,
                TaxAmount = model.TaxAmount,
                TaxAccount = model.TaxAccount,
                InvType = model.InvType,
                InvDate = model.InvDate,
                InvSeries = model.InvSeries,
                InvNo = model.InvNo,
                PurchasePurposeId = model.PurchasePurposeId,
                FreightAmount = model.FreightAmount,
                OrgPrice = model.OrgPrice,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                FundId = model.FundId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                InvoiceTypeCode = model.InvoiceTypeCode,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BudgetExpenseId = model.BudgetExpenseId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BAWithDrawDetailPurchaseEntity ToDataTransferObject(BAWithDrawDetailPurchaseModel model)
        {
            return new BAWithDrawDetailPurchaseEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                InventoryItemId = model.InventoryItemId,
                Description = model.Description,
                StockId = model.StockId,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Unit = model.Unit,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                QuantityConvert = model.QuantityConvert,
                UnitPriceConvert = model.UnitPriceConvert,
                Amount = model.Amount,
                TaxRate = model.TaxRate,
                TaxAmount = model.TaxAmount,
                TaxAccount = model.TaxAccount,
                InvType = model.InvType,
                InvDate = model.InvDate,
                InvSeries = model.InvSeries,
                InvNo = model.InvNo,
                PurchasePurposeId = model.PurchasePurposeId,
                FreightAmount = model.FreightAmount,
                InwardAmount = model.InwardAmount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                FundId = model.FundId,
                ListItemId = model.ListItemId,
                ExpiryDate = model.ExpiryDate,
                LotNo = model.LotNo,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                InvoiceTypeCode = model.InvoiceTypeCode,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BudgetExpenseId = model.BudgetExpenseId,
                BankId = model.BankId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BAWithdrawDetailSalaryEntity ToDataTransferObject(BAWithdrawDetailSalaryModel model)
        {
            return new BAWithdrawDetailSalaryEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                EmployeeId = model.EmployeeId,
                NetWageAmount = model.NetWageAmount,
                SortOrder = model.SortOrder,

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BAWithdrawDetailTaxEntity ToDataTransferObject(BAWithdrawDetailTaxModel model)
        {
            return new BAWithdrawDetailTaxEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                VATAmount = model.VATAmount,
                VATRate = model.VATRate,
                TurnOver = model.TurnOver,
                InvType = model.InvType,
                InvDate = model.InvDate,
                InvSeries = model.InvSeries,
                InvNo = model.InvNo,
                PurchasePurposeId = model.PurchasePurposeId,
                AccountingObjectId = model.AccountingObjectId,
                CompanyTaxCode = model.CompanyTaxCode,
                SortOrder = model.SortOrder,
                InvoiceTypeCode = model.InvoiceTypeCode,

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BADepositDetailEntity ToDataTransferObject(BADepositDetailModel model)
        {
            return new BADepositDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                FundStructureId = model.FundStructureId,
                BudgetExpenseId = model.BudgetExpenseId,
                BankId = model.BankId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                AutoBusinessId = model.AutoBusinessId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BADepositEntity ToDataTransferObject(BADepositModel model)
        {
            return new BADepositEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                ParalellRefNo = model.ParalellRefNo,
                OutwardRefNo = model.OutwardRefNo,
                AccountingObjectId = model.AccountingObjectId,
                BankId = model.BankId,
                InvType = model.InvType,
                InvDate = model.InvDate,
                InvSeries = model.InvSeries,
                InvNo = model.InvNo,
                JournalMemo = model.JournalMemo,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                TotalTaxAmount = model.TotalTaxAmount,
                TotalOutwardAmount = model.TotalOutwardAmount,
                Reconciled = model.Reconciled,
                Posted = model.Posted,
                PostVersion = model.PostVersion,
                EditVersion = model.EditVersion,
                RefOrder = model.RefOrder,
                InvoiceForm = model.InvoiceForm,
                InvoiceFormNumberId = model.InvoiceFormNumberId,
                InvSeriesPrefix = model.InvSeriesPrefix,
                InvSeriesSuffix = model.InvSeriesSuffix,
                PayForm = model.PayForm,
                ComPanyTaxcode = model.ComPanyTaxcode,
                AccountingObjectContactName = model.AccountingObjectContactName,
                ListNo = model.ListNo,
                ListDate = model.ListDate,
                IsAttachList = model.IsAttachList,
                ListCommonNameInventory = model.ListCommonNameInventory,
                BUCommitmentRequestId = model.BUCommitmentRequestId,
                TotalReceiptAmount = model.TotalReceiptAmount,
                BADepositDetails = ToDataTransferObjects(model.BADepositDetailModels),
                BADepositDetailTaxEntities = ToDataTransferObjects(model.BADepositDetailTaxModels),
                BADepositDetailSaleEntities = ToDataTransferObjects(model.BADepositDetailSaleModels),
                BADepositDetailFixedAssetEntities = ToDataTransferObjects(model.BADepositDetailFixedAssetModels),
                BADepositDetailParallels = ToDataTransferObjects(model.BADepositDetailParallels),
                Payer = model.Payer,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>INInwardOutwardEntity.</returns>
        internal static INInwardOutwardEntity ToDataTransferObject(INInwardOutwardModel model)
        {
            return new INInwardOutwardEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo.Trim(),
                ParalellRefNo = model.ParalellRefNo,
                AccountingObjectId = model.AccountingObjectId,
                JournalMemo = model.JournalMemo.Trim(),
                TotalAmount = model.TotalAmount,
                TotalTaxAmount = model.TotalTaxAmount,
                GeneratedRefId = model.GeneratedRefId,
                RefOrder = model.RefOrder,
                InwardOutwardDetails = ToDataTransferObjects(model.InwardOutwardDetails),
                DocumentInclued = model.DocumentInclued.Trim(),
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                INInwardOutwardDetailParallels = ToDataTransferObjects(model.InwardOutwardDetailParallels),
            };
        }
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>INInwardOutwardDetailParallelModel.</returns>
        internal static INInwardOutwardDetailParallelEntity FromDataTransferObject(INInwardOutwardDetailParallelModel model)
        {
            if (model == null)
                return null;
            return new INInwardOutwardDetailParallelEntity
            {
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                Approved = model.Approved,
                AutoBusinessId = model.AutoBusinessId,
                BankId = model.BankId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                BudgetExpenseId = model.BudgetExpenseId,
                BudgetItemCode = model.BudgetItemCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetProvideCode = model.BudgetProvideCode,
                BudgetSourceId = model.BudgetSourceId,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                CapitalPlanId = model.CapitalPlanId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                ContractId = model.ContractId,
                CreditAccount = model.CreditAccount,
                DebitAccount = model.DebitAccount,
                Description = model.Description,
                FundStructureId = model.FundStructureId,
                ListItemId = model.ListItemId,
                MethodDistributeId = model.MethodDistributeId,
                OrgRefDate = model.OrgRefDate,
                OrgRefNo = model.OrgRefNo,
                ProjectId = model.ProjectId,
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                SortOrder = model.SortOrder,
                TaskId = model.TaskId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                InventoryItemId = model.InventoryItemId,
            };
        }
        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>INInwardOutwardDetailEntity.</returns>
        internal static INInwardOutwardDetailEntity ToDataTransferObject(INInwardOutwardDetailModel model)
        {
            return new INInwardOutwardDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                InventoryItemId = model.InventoryItemId,
                Description = model.Description,
                StockId = model.StockId,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Unit = model.Unit,
                Quantity = model.Quantity,
                QuantityConvert = model.QuantityConvert,
                UnitPrice = model.UnitPrice,
                UnitPriceConvert = model.UnitPriceConvert,
                Amount = model.Amount,
                AmountOC = model.AmountExchange,
                OutwardPurpose = model.OutwardPurpose,
                TaxRate = model.TaxRate,
                TaxAmount = model.TaxAmount,
                InwardAmount = model.InwardAmount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                DepartmentId = model.DepartmentId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ListItemId = model.ListItemId,
                ConfrontingRefId = model.ConfrontingRefId,
                ConfrontingRefNo = model.ConfrontingRefNo,
                ExpiryDate = model.ExpiryDate,
                LotNo = model.LotNo,
                Approved = model.Approved,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BudgetExpenseId = model.BudgetExpenseId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                AutoBusinessId = model.AutoBusinessId

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BADepositDetailFixedAssetEntity ToDataTransferObject(BADepositDetailFixedAssetModel model)
        {
            return new BADepositDetailFixedAssetEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                FixedAssetId = model.FixedAssetId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                TaxRate = model.TaxRate,
                TaxAmount = model.TaxAmount,
                TaxAccount = model.TaxAccount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                FundStructureId = model.FundStructureId,
                ProjectExpenseEAId = model.ProjectExpenseEAId,
                ProjectActivityEAId = model.ProjectActivityEAId,

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BADepositDetailSaleEntity ToDataTransferObject(BADepositDetailSaleModel model)
        {
            return new BADepositDetailSaleEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                InventoryItemId = model.InventoryItemId,
                Description = model.Description,
                StockId = model.StockId,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Unit = model.Unit,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                QuantityConvert = model.QuantityConvert,
                UnitPriceConvert = model.UnitPriceConvert,
                Amount = model.Amount,
                TaxRate = model.TaxRate,
                TaxAmount = model.TaxAmount,
                TaxAccount = model.TaxAccount,
                OutwardPrice = model.OutwardPrice,
                OutwardAmount = model.OutwardAmount,
                InventoryAccount = model.InventoryAccount,
                COGSAccount = model.COGSAccount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                ListItemId = model.ListItemId,
                ConfrontingRefId = model.ConfrontingRefId,
                ConfrontingRefNo = model.ConfrontingRefNo,
                ExpiryDate = model.ExpiryDate,
                LotNo = model.LotNo,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                FundStructureId = model.FundStructureId,
                ProjectExpenseEAId = model.ProjectExpenseEAId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                DiscountRate = model.DiscountRate,
                DiscountAmount = model.DiscountAmount,

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>BABankTransferEntity.</returns>
        internal static BABankTransferEntity ToDataTransferObject(BABankTransferModel model)
        {
            return new BABankTransferEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo.Trim(),
                ParalellRefNo = model.ParalellRefNo,
                JournalMemo = model.JournalMemo.Trim(),
                TotalAmount = model.TotalAmount,
                Posted = model.Posted,
                PostVersion = model.PostVersion,
                EditVersion = model.EditVersion,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                TotalAmountOC = model.TotalAmountOC,
                BABankTransferDetails = ToDataTransferObjects(model.BABankTransferDetail),
                BABankTransferDetailParallels = ToDataTransferObjects(model.BABankTransferDetailParallels)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>BABankTransferDetailEntity.</returns>
        internal static BABankTransferDetailEntity ToDataTransferObject(BABankTransferDetailModel model)
        {
            return new BABankTransferDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                FromBankId = model.FromBankId,
                ToBankId = model.ToBankId,
                Amount = model.Amount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                AmountOC = model.AmountOC,
                FundStructureId = model.FundStructureId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BudgetExpenseId = model.BudgetExpenseId

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BADepositDetailTaxEntity ToDataTransferObject(BADepositDetailTaxModel model)
        {
            return new BADepositDetailTaxEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                VATAmount = model.VATAmount,
                VATRate = model.VATRate,
                TurnOver = model.TurnOver,
                InvType = model.InvType,
                InvDate = model.InvDate,
                InvSeries = model.InvSeries,
                InvNo = model.InvNo,
                PurchasePurposeId = model.PurchasePurposeId,
                AccountingObjectId = model.AccountingObjectId,
                AccountingObjectName = model.AccountingObjectName,
                AccountingObjectAddress = model.AccountingObjectAddress,
                CompanyTaxCode = model.CompanyTaxCode,
                SortOrder = model.SortOrder,
                InvoiceTypeCode = model.InvoiceTypeCode,

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>BUCommitmentRequestEntity.</returns>
        internal static BUCommitmentRequestEntity ToDataTransferObject(BUCommitmentRequestModel model)
        {
            return new BUCommitmentRequestEntity
            {
                RefId = model.RefId,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                RefType = model.RefType,
                AccountingObjectId = model.AccountingObjectId,
                AccountingObjectName = model.AccountingObjectName,
                TABMISCode = model.TABMISCode,
                BankAccount = model.BankAccount,
                BankName = model.BankName,
                ContractNo = model.ContractNo,
                ContractFrameNo = model.ContractFrameNo,
                BudgetSourceKind = model.BudgetSourceKind,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                IsForeignCurrency = model.IsForeignCurrency,
                Posted = model.Posted,
                EditVersion = model.EditVersion,
                PostVersion = model.PostVersion,
                ProjectInvestmentCode = model.ProjectInvestmentCode,
                ProjectInvestmentName = model.ProjectInvestmentName,
                SignDate = model.SignDate,
                ContractAmount = model.ContractAmount,
                PrevYearCommitmentAmount = model.PrevYearCommitmentAmount,
                BUCommitmentRequestDetails = ToDataTransferObjects(model.BUCommitmentRequestDetails)

            };
        }
        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>BUCommitmentRequestDetailEntity.</returns>
        internal static BUCommitmentRequestDetailEntity ToDataTransferObject(BUCommitmentRequestDetailModel model)
        {
            return new BUCommitmentRequestDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                FundStructureId = model.FundStructureId,
                SortOrder = model.SortOrder,
                BankAccount = model.BankAccount,
                BudgetProvideCode = model.BudgetProvideCode,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId

            };
        }
        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>BUCommitmentAdjustmentEntity.</returns>
        internal static BUCommitmentAdjustmentEntity ToDataTransferObject(BUCommitmentAdjustmentModel model)
        {
            return new BUCommitmentAdjustmentEntity
            {
                RefId = model.RefId,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                BUCommitmentRequestId = model.BUCommitmentRequestId,
                ContractNo = model.ContractNo,
                ContractFrameNo = model.ContractFrameNo,
                RealContractNo = model.RealContractNo,
                RefType = model.RefType,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                IsForeignCurrency = model.IsForeignCurrency,
                Posted = model.Posted,
                ExchangeRate = model.ExchangeRate,
                CurrencyCode = model.CurrencyCode,
                EditVersion = model.EditVersion,
                PostVersion = model.PostVersion,
                IsSuggestAdjustment = model.IsSuggestAdjustment,
                IsSuggestSupplement = model.IsSuggestSupplement,
                AdjustmentProviderBankAccount = model.AdjustmentProviderBankAccount,
                AdjustmentProviderBankName = model.AdjustmentProviderBankName,
                BankAccount = model.BankAccount,
                BankName = model.BankName,
                BUCommitmentAdjustmentDetails = ToDataTransferObjects(model.BUCommitmentAdjustmentDetails)

            };
        }
        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>BUCommitmentAdjustmentDetailEntity.</returns>
        internal static BUCommitmentAdjustmentDetailEntity ToDataTransferObject(BUCommitmentAdjustmentDetailModel model)
        {
            return new BUCommitmentAdjustmentDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                FundStructureId = model.FundStructureId,
                SortOrder = model.SortOrder,
                BankAccount = model.BankAccount,
                BudgetProvideCode = model.BudgetProvideCode,
                ToCurrencyCode = model.ToCurrencyCode,
                ToExchangeRate = model.ToExchangeRate,
                ToAmountOC = model.ToAmountOC,
                ToAmount = model.ToAmount,
                ToBudgetSourceId = model.ToBudgetSourceId,
                ToBudgetProvideCode = model.ToBudgetProvideCode,
                ToBudgetChapterCode = model.ToBudgetChapterCode,
                ToBudgetKindItemCode = model.ToBudgetKindItemCode,
                ToBudgetSubKindItemCode = model.ToBudgetSubKindItemCode,
                ToBudgetItemCode = model.ToBudgetItemCode,
                ToBudgetSubItemCode = model.ToBudgetSubItemCode,
                ToProjectId = model.ToProjectId,
                RemainAmountOC = model.RemainAmountOC,
                RemainAmount = model.RemainAmount,
                RemainExchangeRate = model.RemainExchangeRate,
                RemainCurrencyCode = model.RemainCurrencyCode,
                BUCommitmentRequestDetailId = model.BUCommitmentRequestDetailId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId
            };
        }


        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>OpeningCommitmentEntity.</returns>
        internal static OpeningCommitmentEntity ToDataTransferObject(OpeningCommitmentModel model)
        {
            return new OpeningCommitmentEntity
            {
                RefId = model.RefId,
                PostedDate = model.PostedDate,
                RefDate = model.RefDate,
                RefNo = model.RefNo,
                RefType = model.RefType,
                BudgetSourceKind = model.BudgetSourceKind,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                IsForeignCurrency = model.IsForeignCurrency,
                EditVersion = model.EditVersion,
                PostVersion = model.PostVersion,
                AccountingObjectId = model.AccountingObjectId,
                AccountingObjectName = model.AccountingObjectName,
                TABMISCode = model.TABMISCode,
                BankAccount = model.BankAccount,
                BankName = model.BankName,
                ContractNo = model.ContractNo,
                ContractFrameNo = model.ContractFrameNo,
                ProjectInvestmentCode = model.ProjectInvestmentCode,
                ProjectInvestmentName = model.ProjectInvestmentName,
                SignDate = model.SignDate,
                ContractAmount = model.ContractAmount,
                PrevYearCommitmentAmount = model.PrevYearCommitmentAmount,
                OpeningCommitmentDetails = ToDataTransferObjects(model.OpeningCommitmentDetails),
            };
        }
        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>OpeningCommitmentDetailEntity.</returns>
        internal static OpeningCommitmentDetailEntity ToDataTransferObject(OpeningCommitmentDetailModel model)
        {
            return new OpeningCommitmentDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                CurrencyId = model.CurrencyId,
                ExchangeRate = model.ExchangeRate,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                FundStructureId = model.FundStructureId,
                BankAccount = model.BankAccount,
                SortOrder = model.SortOrder,
                BudgetProvideCode = model.BudgetProvideCode,

            };
        }
        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>OpeningSupplyEntryEntity.</returns>
        internal static OpeningSupplyEntryEntity ToDataTransferObject(OpeningSupplyEntryModel model)
        {
            return new OpeningSupplyEntryEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                PostedDate = model.PostedDate,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                AccountNumber = model.AccountNumber,
                InventoryItemId = model.InventoryItemId,
                InventoryItemCode = model.InventoryItemCode,
                InventoryItemName = model.InventoryItemName,
                DepartmentId = model.DepartmentId,
                BudgetChapterCode = model.BudgetChapterCode,
                Quantity = model.Quantity,
                UnitPriceOC = model.UnitPriceOC,
                UnitPrice = model.UnitPrice,
                AmountOC = model.AmountOC,
                Amount = model.Amount,
                PostVersion = model.PostVersion,
                EditVersion = model.EditVersion,
                SortOrder = model.SortOrder,

            };
        }

        internal static List<ContractDetailsModel> FromDataTransferObject(IList<ContractDetailEntity> contractDetail)
        {
            if (contractDetail == null)
                return null;

            return contractDetail.Select(FromDataTransferObject).ToList();
        }


        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>BUTransferEntity.</returns>
        internal static BUTransferEntity ToDataTransferObject(BUTransferModel model)
        {
            return new BUTransferEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                ParalellRefNo = model.ParalellRefNo,
                JournalMemo = model.JournalMemo,
                TargetProgramId = model.TargetProgramId,
                BankInfoId = model.BankInfoId,
                AccountingObjectId = model.AccountingObjectId,
                AccountingObjectName = model.AccountingObjectName,
                AccountingObjectAddress = model.AccountingObjectAddress,
                AccountingObjectBankAccount = model.AccountingObjectBankAccount,
                AccountingObjectBankName = model.AccountingObjectBankName,
                DocumentIncluded = model.DocumentIncluded,
                InwardStockRefNo = model.InwardStockRefNo,
                WithdrawRefDate = model.WithdrawRefDate,
                WithdrawRefNo = model.WithdrawRefNo,
                IncrementRefNo = model.IncrementRefNo,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                TotalTaxAmount = model.TotalTaxAmount,
                TotalFreightAmount = model.TotalFreightAmount,
                TotalInwardAmount = model.TotalInwardAmount,
                Posted = model.Posted,
                PostVersion = model.PostVersion,
                EditVersion = model.EditVersion,
                RefOrder = model.RefOrder,
                RelationRefId = model.RelationRefId,

                BUCommitmentRequestId = model.BUCommitmentRequestId,
                TotalFixedAssetAmount = model.TotalFixedAssetAmount,
                BUTransferDetails = ToDataTransferObjects(model.BUTransferDetails),
                BUTransferDetailParallels = ToDataTransferObjects(model.BUTransferDetailParallel),
                BUTransferDetailPurchases = model.BUTransferDetailPurchases?.Select(m => AutoMapper(m, new BUTransferDetailPurchaseEntity())).ToList(),
                BUTransferDetailFixedAssets = model.BUTransferDetailFixedAssets?.Select(m => AutoMapper(m, new BUTransferDetailFixedAssetEntity())).ToList(),
                //BUTransferDetailFixedAssets = model.BUTransferDetailFixedAssets,
                BUPlanWithdrawRefId = model.BUPlanWithdrawRefId,

            };
        }
        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>BUTransferDetailEntity.</returns>
        internal static BUTransferDetailEntity ToDataTransferObject(BUTransferDetailModel model)
        {
            return new BUTransferDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                FundId = model.FundId,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                ProjectExpenseEAId = model.ProjectExpenseEAId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                WithdrawRefDetailId = model.WithdrawRefDetailId,
                BudgetProvideCode = model.BudgetProvideCode,
                TopicId = model.TopicId,
                BudgetExpenseId = model.BudgetExpenseId,
                BankId = model.BankId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                OldAdvanceRecovery = model.OldAdvanceRecovery,
                AdvanceRecovery = model.AdvanceRecovery,
                AutoBusinessID = model.AutoBusinessID
            };
        }



        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static PurchasePurposeEntity ToDataTransferObject(PurchasePurposeModel model)
        {
            return new PurchasePurposeEntity
            {
                PurchasePurposeId = model.PurchasePurposeId,
                PurchasePurposeCode = model.PurchasePurposeCode,
                PurchasePurposeName = model.PurchasePurposeName,
                Description = model.Description,
                IsSystem = model.IsSystem,
                IsActive = model.IsActive
            };
        }

        internal static LockEntity ToDataTransferObject(LockModel model)
        {
            return new LockEntity
            {
                IsLock = model.IsLock,
                Content = model.Content,
                LockDate = model.LockDate
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static RefTypeEntity ToDataTransferObject(RefTypeModel model)
        {
            return new RefTypeEntity
            {
                RefTypeId = model.RefTypeId,
                DefaultTaxAccountId = model.DefaultTaxAccountId,
                DefaultCreditAccountCategoryId = model.DefaultCreditAccountCategoryId,
                AllowDefaultSetting = model.AllowDefaultSetting,
                DefaultDebitAccountId = model.DefaultDebitAccountId,
                RefTypeName = model.RefTypeName,
                DefaultCreditAccountId = model.DefaultCreditAccountId,
                DefaultTaxAccountCategoryId = model.DefaultTaxAccountCategoryId,
                DefaultDebitAccountCategoryId = model.DefaultDebitAccountCategoryId,
                DetailTableName = model.DetailTableName,
                FunctionId = model.FunctionId,
                LayoutDetail = model.LayoutDetail,
                LayoutMaster = model.LayoutMaster,
                MasterTableName = model.MasterTableName,
                Postable = model.Postable,
                RefTypeCategoryId = model.RefTypeCategoryId,
                Searchable = model.Searchable,
                SortOrder = model.SortOrder,
                SubSystem = model.SubSystem
            };
        }

        internal static SalaryVoucherEntity ToDataTransferObject(SalaryVoucherModel model)
        {
            return new SalaryVoucherEntity
            {
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                RefTypeId = model.RefTypeId

            };
        }

        internal static AutoNumberListEntity ToDataTransferObject(AutoNumberListModel model)
        {
            return new AutoNumberListEntity
            {
                TableCode = model.TableCode,
                LengthOfValue = model.LengthOfValue,
                Prefix = model.Prefix,
                Suffix = model.Suffix,
                TableName = model.TableName,
                Value = model.Value
            };
        }

        internal static ElectricalWorkEntity ToDataTransferObject(ElectricalWorkModel model)
        {
            return new ElectricalWorkEntity
            {
                ElectricalWorkId = model.ElectricalWorkId,
                Name = model.Name,
                PostedDate = model.PostedDate
            };
        }

        internal static MutualEntity ToDataTransferObject(MutualModel model)
        {
            return new MutualEntity
            {
                IsActive = model.IsActive,
                Address = model.Address,
                Description = model.Description,
                Area = model.Area,
                UseDate = model.UseDate,
                TotalFloor = model.TotalFloor,
                State = model.State,
                JobCandidate = model.JobCandidate,
                MutualName = model.MutualName,
                MutualCode = model.MutualCode,
                MutualId = model.MutualId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static SalaryEntity ToDataTransferObject(SalaryModel model)
        {
            return new SalaryEntity
            {
                EmployeePayrollId = model.EmployeePayrollId,
                RefTypeId = model.RefTypeId,
                RefNo = model.RefNo,
                RefDate = DateTime.Parse(model.RefDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                TotalAmountOc = model.TotalAmountOc,
                PostedDate = DateTime.Parse(model.PostedDate),
                CurrencyCode = model.CurrencyCode,
                JournalMemo = model.JournalMemo,
                EmployeeId = model.EmployeeId,
                ExchangeRate = model.ExchangeRate,
                TotalAmountExchange = model.TotalAmountExchange,
                Employees = ToDataTransferObjects(model.Employees)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CapitalAllocateEntity ToDataTransferObject(CapitalAllocateModel model)
        {
            return new CapitalAllocateEntity
            {
                CapitalAllocateId = model.CapitalAllocateId,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSourceCode = model.BudgetSourceCode,
                Activityid = model.ActivityId,
                AllocatePercent = model.AllocatePercent,
                AllocateType = model.AllocateType,
                DeterminedDate = model.DeterminedDate == null ? (DateTime?)null : DateTime.Parse(model.DeterminedDate),
                CapitalAccountCode = model.CapitalAccountCode,
                RevenueAccountCode = model.RevenueAccountCode,
                ExpenseAccountCode = model.ExpenseAccountCode,
                Description = model.Description,
                IsActive = model.IsActive,
                WaitBudgetSourceCode = model.WaitBudgetSourceCode,
                CapitalAllocateCode = model.CapitalAllocateCode,
                FromDate = DateTime.Parse(model.FromDate),
                ToDate = DateTime.Parse(model.ToDate),
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CurrencyEntity ToDataTransferObject(CurrencyModel model)
        {
            return new CurrencyEntity
            {
                CurrencyCode = model.CurrencyCode,
                CurrencyId = model.CurrencyId,
                CurrencyName = model.CurrencyName,
                Prefix = model.Prefix,
                Suffix = model.Suffix,
                IsMain = model.IsMain,
                IsActive = model.IsActive
            };
        }

        ///// <summary>
        ///// To the data transfer object.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns></returns>
        //internal static BudgetSourcePropertyEntity ToDataTransferObject(BudgetSourcePropertyModel model)
        //{
        //    return new BudgetSourcePropertyEntity
        //    {
        //        BudgetSourcePropertyID = model.BudgetSourcePropertyID,
        //        BudgetSourcePropertyCode = model.BudgetSourcePropertyCode,
        //        BudgetSourcePropertyName = model.BudgetSourcePropertyName,
        //        Description = model.Description,
        //        IsActive = model.IsActive,
        //        IsSystem = model.IsSystem
        //    };
        //}

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AccountEntity ToDataTransferObject(AccountModel model)
        {
            return new AccountEntity
            {
                AccountId = model.AccountId,
                AccountNumber = model.AccountNumber,
                AccountCategoryId = model.AccountCategoryId,
                ParentId = model.ParentId,
                AccountName = model.AccountName,
                AccountForeignName = model.AccountForeignName,
                Description = model.Description,
                AccountCategoryKind = model.AccountCategoryKind,
                DetailByBudgetSource = model.DetailByBudgetSource,
                DetailByBudgetChapter = model.DetailByBudgetChapter,
                DetailByBudgetKindItem = model.DetailByBudgetKindItem,
                DetailByBudgetItem = model.DetailByBudgetItem,
                DetailByBudgetSubItem = model.DetailByBudgetSubItem,
                DetailByMethodDistribute = model.DetailByMethodDistribute,
                DetailByAccountingObject = model.DetailByAccountingObject,
                DetailByActivity = model.DetailByActivity,
                DetailByProject = model.DetailByProject,
                DetailByTask = model.DetailByTask,
                DetailBySupply = model.DetailBySupply,
                DetailByInventoryItem = model.DetailByInventoryItem,
                DetailByFixedAsset = model.DetailByFixedAsset,
                DetailByFund = model.DetailByFund,
                DetailByBankAccount = model.DetailByBankAccount,
                DetailByProjectActivity = model.DetailByProjectActivity,
                DetailByInvestor = model.DetailByInvestor,
                Grade = model.Grade,
                IsParent = model.IsParent,
                IsActive = model.IsActive,
                IsDisplayOnAccountBalanceSheet = model.IsDisplayOnAccountBalanceSheet,
                IsDisplayBalanceOnReport = model.IsDisplayBalanceOnReport,
                DetailByCurrency = model.DetailByCurrency,
                DetailByBudgetExpense = model.DetailByBudgetExpense,
                DetailByExpense = model.DetailByExpense,
                DetailByContract = model.DetailByContract,
                DetailByCapitalPlan = model.DetailByCapitalPlan,
            };
        }

        internal static AccountingObjectCategoryEntity ToDataTransferObject(AccountingObjectCategoryModel model)
        {
            return new AccountingObjectCategoryEntity
            {
                AccountingObjectCategoryId = model.AccountingObjectCategoryId,
                AccountingObjectCategoryCode = model.AccountingObjectCategoryCode,
                AccountingObjectCategoryName = model.AccountingObjectCategoryName,
                IsActive = model.IsActive,
                IsSystem = model.IsSystem
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AccountCategoryEntity ToDataTransferObject(AccountCategoryModel model)
        {
            return new AccountCategoryEntity
            {
                AccountCategoryId = model.AccountCategoryId,
                AccountCategoryName = model.AccountCategoryName,
                AccountCategoryKind = model.AccountCategoryKind,
                DetailByBudgetSource = model.DetailByBudgetSource,
                DetailByBudgetChapter = model.DetailByBudgetChapter,
                DetailByBudgetKindItem = model.DetailByBudgetKindItem,
                DetailByBudgetItem = model.DetailByBudgetItem,
                DetailByBudgetSubItem = model.DetailByBudgetSubItem,
                DetailByMethodDistribute = model.DetailByMethodDistribute,
                DetailByAccountingObject = model.DetailByAccountingObject,
                DetailByActivity = model.DetailByActivity,
                DetailByProject = model.DetailByProject,
                DetailByTask = model.DetailByTask,
                DetailBySupply = model.DetailBySupply,
                DetailByInventoryItem = model.DetailByInventoryItem,
                DetailByFixedAsset = model.DetailByFixedAsset,
                DetailByBankAccount = model.DetailByBankAccount,
                DetailByFund = model.DetailByFund,
                IsActive = model.IsActive
            };
        }

        internal static ReportListEntity ToReceiptDataTransferObject(ReportListModel model)
        {
            if (model == null)
                return null;
            return new ReportListEntity
            {
                ReportId = model.ReportId,
                PrintVoucherDefault = model.PrintVoucherDefault
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CAReceiptEntity ToDataTransferObject(CAReceiptModel model)
        {
            if (model == null)
                return null;
            return new CAReceiptEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo.Trim(),
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                ParalellRefNo = model.ParalellRefNo,
                OutwardRefNo = model.OutwardRefNo,
                AccountingObjectId = model.AccountingObjectId,
                JournalMemo = model.JournalMemo,
                DocumentIncluded = model.DocumentIncluded,
                InvType = model.InvType,
                InvDateOrWithdrawRefDate = model.InvDateOrWithdrawRefDate,
                InvSeries = model.InvSeries,
                InvNoOrWithdrawRefNo = model.InvNoOrWithdrawRefNo,
                BankId = model.BankId,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                Address = model.Address,
                TotalTaxAmount = model.TotalTaxAmount,
                TotalOutwardAmount = model.TotalOutwardAmount,
                Posted = model.Posted,
                RefOrder = model.RefOrder,
                InvoiceForm = model.InvoiceForm,
                InvoiceFormNumberId = model.InvoiceFormNumberId,
                InvSeriesPrefix = model.InvSeriesPrefix,
                InvSeriesSuffix = model.InvSeriesSuffix,
                PayForm = model.PayForm,
                CompanyTaxcode = model.CompanyTaxcode,
                RelationRefId = model.RelationRefId,
                BUCommitmentRequestId = model.BUCommitmentRequestId,
                AccountingObjectContactName = model.AccountingObjectContactName,
                ListNo = model.ListNo,
                ListDate = model.ListDate,
                IsAttachList = model.IsAttachList,
                ListCommonNameInventory = model.ListCommonNameInventory,
                TotalReceiptAmount = model.TotalReceiptAmount,
                CAReceiptDetails = ToDataTransferObjects(model.CAReceiptDetails),
                CAReceiptDetailTaxes = ToDataTransferObjects(model.CAReceiptDetailTaxes),
                CAReceiptDetailParallels = ToDataTransferObjects(model.CAReceiptDetailParallels),

                BUPlanWithdrawRefId = model.BUPlanWithdrawRefId,
                Payer = model.Payer
            };
        }

        internal static CAReceiptDetailEntity ToDataTransferObject(CAReceiptDetailModel model)
        {
            if (model == null)
                return null;
            return new CAReceiptDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                WithdrawDetailId = model.WithdrawDetailId,
                BudgetExpenseId = model.BudgetExpenseId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                AutoBusinessId = model.AutoBusinessId
            };
        }

        internal static CAReceiptDetailTaxEntity ToDataTransferObject(CAReceiptDetailTaxModel model)
        {
            if (model == null)
                return null;
            return new CAReceiptDetailTaxEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                VATAmount = model.VATAmount,
                VATRate = model.VATRate,
                TurnOver = model.TurnOver,
                InvType = model.InvType,
                InvDate = model.InvDate,
                InvSeries = model.InvSeries,
                InvNo = model.InvNo,
                PurchasePurposeId = model.PurchasePurposeId,
                AccountingObjectId = model.AccountingObjectId,
                CompanyTaxCode = model.CompanyTaxCode,
                SortOrder = model.SortOrder,
                InvoiceTypeCode = model.InvoiceTypeCode
            };
        }

        internal static CAPaymentDetailEntity ToDataTransferObject(CAPaymentDetailModel model)
        {
            return new CAPaymentDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BudgetExpenseId = model.BudgetExpenseId,
                ProjectExpenseEAId = model.ProjectExpenseEAId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BankId = model.BankId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                AutoBusinessId = model.AutoBusinessId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>CAPaymentDetailPurchaseEntity.</returns>
        internal static CAPaymentDetailPurchaseEntity ToDataTransferObject(CAPaymentDetailPurchaseModel model)
        {
            return new CAPaymentDetailPurchaseEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                InventoryItemId = model.InventoryItemId,
                Description = model.Description,
                StockId = model.StockId,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Unit = model.Unit,
                Quantity = model.Quantity,
                QuantityConvert = model.QuantityConvert,
                UnitPrice = model.UnitPrice,
                UnitPriceConvert = model.UnitPriceConvert,
                Amount = model.Amount,
                AmountExchange = model.AmountExchange,
                InvType = model.InvType,
                InvDate = model.InvDate,
                InvSeries = model.InvSeries,
                InvNo = model.InvNo,
                TaxRate = model.TaxRate,
                TaxAmount = model.TaxAmount,
                TaxAccount = model.TaxAccount,
                PurchasePurposeId = model.PurchasePurposeId,
                FreightAmount = model.FreightAmount,
                InwardAmount = model.InwardAmount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                ListItemId = model.ListItemId,
                ExpiryDate = model.ExpiryDate,
                LotNo = model.LotNo,
                Approved = model.Approved,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                InvoiceTypeCode = model.InvoiceTypeCode,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                ProjectExpenseEAId = model.ProjectExpenseEAId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BudgetExpenseId = model.BudgetExpenseId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                AutoBusinessId = model.AutoBusinessId,
                BankId = model.BankId,
                CurrencyCode = model.CurrencyCode,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>CAPaymentDetailFixedAssetEntity.</returns>
        internal static CAPaymentDetailFixedAssetEntity ToDataTransferObject(CAPaymentDetailFixedAssetModel model)
        {
            return new CAPaymentDetailFixedAssetEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                FixedAssetId = model.FixedAssetId,
                Description = model.Description,
                DepartmentId = model.DepartmentId,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.ExchangeAmount ?? 0,
                TaxRate = model.TaxRate,
                TaxAmount = model.TaxAmount,
                TaxAccount = model.TaxAccount,
                InvType = model.InvType,
                InvDate = model.InvDate,
                InvSeries = model.InvSeries,
                InvNo = model.InvNo,
                PurchasePurposeId = model.PurchasePurposeId,
                FreightAmount = model.FreightAmount,
                OrgPrice = model.OrgPrice,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                Quantity = model.Quantity,
                FundId = model.FundId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                InvoiceTypeCode = model.InvoiceTypeCode,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                ProjectExpenseEAId = model.ProjectExpenseEAId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BudgetExpenseId = model.BudgetExpenseId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                AmountOC = model.Amount
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>CAPaymentDetailParallelEntity.</returns>
        internal static CAPaymentDetailParallelEntity ToDataTransferObject(CAPaymentDetailParallelModel model)
        {
            return new CAPaymentDetailParallelEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                SortOrder = model.SortOrder,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                BudgetExpenseId = model.BudgetExpenseId,
                BudgetProvideCode = model.BudgetProvideCode,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                FixedAssetId = model.FixedAssetId,
                AutoBusinessId = model.AutoBusinessId

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>BADepositDetailParallelEntity.</returns>
        internal static BADepositDetailParallelEntity ToDataTransferObject(BADepositDetailParallelModel model)
        {
            return new BADepositDetailParallelEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                FundId = model.FundId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                BudgetProvideCode = model.BudgetProvideCode,
                TopicId = model.TopicId,
                BudgetExpenseId = model.BudgetExpenseId,
                Approved = model.Approved,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId
            };
        }

        /// <summary>
        /// To data transfer object ba with draw detail parallel parallel model
        /// </summary>  
        internal static BAWithDrawDetailParallelEntity ToDataTransferObject(BAWithDrawDetailParallelModel model)
        {
            return new BAWithDrawDetailParallelEntity
            {
                RefDetailId = model.RefDetailId,
                ParentRefDetailId = model.ParentRefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                FundId = model.FundId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                BudgetProvideCode = model.BudgetProvideCode,
                TopicId = model.TopicId,
                BudgetExpenseId = model.BudgetExpenseId,
                Approved = model.Approved,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId
            };
        }
        internal static BUTransferDetailParallelEntity ToDataTransferObject(BUTransferDetailParallelModel model)
        {
            return new BUTransferDetailParallelEntity
            {
                RefDetailId = model.RefDetailId,
                ParentRefDetailId = model.ParentRefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                FundId = model.FundId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                BudgetProvideCode = model.BudgetProvideCode,
                TopicId = model.TopicId,
                BudgetExpenseId = model.BudgetExpenseId,
                Approved = model.Approved,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                AdvanceRecovery = model.AdvanceRecovery
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>GLVoucherDetailParallelEntity.</returns>
        internal static GLVoucherDetailParallelEntity ToDataTransferObject(GLVoucherDetailParallelModel model)
        {
            return new GLVoucherDetailParallelEntity
            {
                RefDetailId = model.RefDetailId,
                ParentRefDetailId = model.ParentRefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                FundId = model.FundId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                BudgetProvideCode = model.BudgetProvideCode,
                TopicId = model.TopicId,
                BudgetExpenseId = model.BudgetExpenseId,
                Approved = model.Approved,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>BABankTransferDetailParallelEntity.</returns>
        internal static BABankTransferDetailParallelEntity ToDataTransferObject(BABankTransferDetailParallelModel model)
        {
            return new BABankTransferDetailParallelEntity
            {
                RefDetailId = model.RefDetailId,
                ParentRefDetailId = model.ParentRefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                FundId = model.FundId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                BudgetProvideCode = model.BudgetProvideCode,
                TopicId = model.TopicId,
                BudgetExpenseId = model.BudgetExpenseId,
                Approved = model.Approved,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>CAReceiptDetailParallelEntity.</returns>
        internal static CAReceiptDetailParallelEntity ToDataTransferObject(CAReceiptDetailParallelModel model)
        {

            return new CAReceiptDetailParallelEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                SortOrder = model.SortOrder,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                BudgetExpenseId = model.BudgetExpenseId,
                BudgetProvideCode = model.BudgetProvideCode,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                AutoBusinessId = model.AutoBusinessId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CAPaymentDetailTaxEntity ToDataTransferObject(CAPaymentDetailTaxModel model)
        {
            return new CAPaymentDetailTaxEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                VATAmount = model.VATAmount,
                VATRate = model.VATRate,
                TurnOver = model.TurnOver,
                InvType = model.InvType,
                InvDate = model.InvDate,
                InvSeries = model.InvSeries,
                InvNo = model.InvNo,
                PurchasePurposeId = model.PurchasePurposeId,
                AccountingObjectId = model.AccountingObjectId,
                CompanyTaxCode = model.CompanyTaxCode,
                SortOrder = model.SortOrder,
                InvoiceTypeCode = model.InvoiceTypeCode,

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CAPaymentEntity ToDataTransferObject(CAPaymentModel model)
        {
            var parallels = new List<SelectItemEntity>();
            if (model.Parallels != null)
            {
                model.Parallels.ForEach(item =>
                {
                    var parallel = new SelectItemEntity()
                    {
                        Credit = item.Credit,
                        Debit = item.Debit,
                    };
                    parallels.Add(parallel);
                });
            }
            return new CAPaymentEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo.Trim(),
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                ParalellRefNo = model.ParalellRefNo,
                IncrementRefNo = model.IncrementRefNo,
                InwardRefNo = model.InwardRefNo,
                Address = model.Address,
                AccountingObjectId = model.AccountingObjectId,
                JournalMemo = model.JournalMemo.Trim(),
                DocumentIncluded = model.DocumentIncluded,
                BankId = model.BankId,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                TotalTaxAmount = model.TotalTaxAmount,
                TotalFreightAmount = model.TotalFreightAmount,
                TotalInwardAmount = model.TotalInwardAmount,
                Posted = model.Posted,
                RefOrder = model.RefOrder,
                RelationRefId = model.RelationRefId,
                TotalPaymentAmount = model.TotalPaymentAmount,
                CaPaymentDetails = ToDataTransferObjects(model.CAPaymentDetails),
                CaPaymentDetailTaxes = ToDataTranferObjects(model.CaPaymentDetailTaxes),
                CAPaymentDetailPurchases = ToDataTranferObjects(model.CAPaymentDetailPurchases),
                CAPaymentDetailFixedAssets = ToDataTranferObjects(model.CAPaymentDetailFixedAssets),
                CAPaymentDetailParallels = ToDataTranferObjects(model.CAPaymentDetailParallels),
                Receiver = model.Receiver,
                Parallels = parallels
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BUPlanReceiptEntity ToDataTransferObject(BUPlanReceiptModel model)
        {
            return new BUPlanReceiptEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                ParalellRefNo = model.ParalellRefNo,
                DecisionDate = model.DecisionDate,
                DecisionNo = model.DecisionNo,
                BudgetChapterCode = model.BudgetChapterCode,
                JournalMemo = model.JournalMemo,
                Posted = model.Posted,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                AllocationConfig = model.AllocationConfig,
                BuPlanReceiptDetails = ToDataTransferObjects(model.BUPlanReceiptDetails)

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BUPlanReceiptDetailEntity ToDataTransferObject(BUPlanReceiptDetailModel model)
        {
            return new BUPlanReceiptDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetSourceId = model.BudgetSourceId,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetGroupItemCode = model.BudgetGroupItemCode,
                BudgetParentItemCode = model.BudgetParentItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                DebitAccount = model.DebitAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                ProjectId = model.ProjectId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                AmountQuater1 = model.AmountQuater1,
                AmountQuater1OC = model.AmountQuater1OC,
                AmountQuater2 = model.AmountQuater2,
                AmountQuater2OC = model.AmountQuater2OC,
                AmountQuater3 = model.AmountQuater3,
                AmountQuater3OC = model.AmountQuater3OC,
                AmountQuater4 = model.AmountQuater4,
                AmountQuater4OC = model.AmountQuater4OC,
                AmountMonth1 = model.AmountMonth1,
                AmountMonth1OC = model.AmountMonth1OC,
                AmountMonth2 = model.AmountMonth2,
                AmountMonth2OC = model.AmountMonth2OC,
                AmountMonth3 = model.AmountMonth3,
                AmountMonth3OC = model.AmountMonth3OC,
                AmountMonth4 = model.AmountMonth4,
                AmountMonth4OC = model.AmountMonth4OC,
                AmountMonth5 = model.AmountMonth5,
                AmountMonth5OC = model.AmountMonth5OC,
                AmountMonth6 = model.AmountMonth6,
                AmountMonth6OC = model.AmountMonth6OC,
                AmountMonth7 = model.AmountMonth7,
                AmountMonth7OC = model.AmountMonth7OC,
                AmountMonth8 = model.AmountMonth8,
                AmountMonth8OC = model.AmountMonth8OC,
                AmountMonth9 = model.AmountMonth9,
                AmountMonth9OC = model.AmountMonth9OC,
                AmountMonth10 = model.AmountMonth10,
                AmountMonth10OC = model.AmountMonth10OC,
                AmountMonth11 = model.AmountMonth11,
                AmountMonth11OC = model.AmountMonth11OC,
                AmountMonth12 = model.AmountMonth12,
                AmountMonth12OC = model.AmountMonth12OC,
                BudgetProvideCode = model.BudgetProvideCode,
                MethodDistributeId = model.MethodDistributeId,
                CapitalPlanId = model.CapitalPlanId,
                ContractId = model.ContractId,
                ActivityId = model.ActivityId

            };
        }

        internal static BUPlanAdjustmentEntity ToDataTransferObject(BUPlanAdjustmentModel model)
        {
            return new BUPlanAdjustmentEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                ParalellRefNo = model.ParalellRefNo,
                DecisionDate = model.DecisionDate,
                DecisionNo = model.DecisionNo,
                JournalMemo = model.JournalMemo,
                Posted = model.Posted,
                TotalPreAdjustmentAmount = model.TotalPreAdjustmentAmount,
                TotalAdjustmentAmount = model.TotalAdjustmentAmount,
                TotalPostAdjustmentAmount = model.TotalPostAdjustmentAmount,
                PostVersion = model.PostVersion,
                EditVersion = model.EditVersion,
                BUPlanAdjustmentDetails = ToDataTransferObjects(model.BuPlanAdjustmentDetailModels),
                ExchangeRate = model.ExchangeRate,
                CurrencyCode = model.CurrencyCode,
                TotalAmount = model.TotalAmount,
            };
        }


        internal static BUPlanAdjustmentDetailEntity ToDataTransferObject(BUPlanAdjustmentDetailModel model)
        {
            return new BUPlanAdjustmentDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                ItemName = model.ItemName,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetGroupItemCode = model.BudgetGroupItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                DebitAccount = model.DebitAccount,
                AdjustmentAmount = model.AdjustmentAmount,
                ProjectId = model.ProjectId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                TaskId = model.TaskId,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                FundStructureId = model.FundStructureId,
                BankAccount = model.BankAccount,
                ProjectExpenseEAID = model.ProjectExpenseEAID,
                ProjectActivityEAID = model.ProjectActivityEAID,
                BudgetProvideCode = model.BudgetProvideCode,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                MethodDistributeId = model.MethodDistributeId,
                ActivityId = model.ActivityId,
                Amount = model.Amount
            };
        }


        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BUBudgetReserveEntity ToDataTransferObject(BUBudgetReserveModel model)
        {
            return new BUBudgetReserveEntity
            {
                RefId = model.RefId,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                RefType = model.RefType,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetChapterName = model.BudgetChapterName,
                JournalMemo = model.JournalMemo,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                Posted = model.Posted,
                EditVersion = model.EditVersion,
                PostVersion = model.PostVersion,
                BudgetReserveDetails = ToDataTransferObjects(model.BUBudgetReserveDetails)

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BUBudgetReserveDetailEntity ToDataTransferObject(BUBudgetReserveDetailModel model)
        {
            return new BUBudgetReserveDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                FundStructureId = model.FundStructureId,
                SortOrder = model.SortOrder,
                BudgetGroupItemCode = model.BudgetGroupItemCode,
                BankAccount = model.BankAccount,
                BudgetProvideCode = model.BudgetProvideCode

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GLVoucherEntity ToDataTransferObject(GLVoucherModel model)
        {
            return new GLVoucherEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                ParalellRefNo = model.ParalellRefNo,
                JournalMemo = model.JournalMemo,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                ParentRefId = model.ParentRefId,
                AccountingObjectId = model.AccountingObjectId,
                Posted = model.Posted,
                Approved = model.Approved,
                PostVersion = model.PostVersion,
                EditVersion = model.EditVersion,
                AdvancePaymentOrder = model.AdvancePaymentOrder,
                BUTransferRefId = model.BUTransferRefId,
                BUTransferType = model.BUTransferType,
                GLVoucherDetails = ToDataTransferObjects(model.GLVoucherDetails),
                GLVoucherDetailParallels = ToDataTransferObjects(model.GLVoucherDetailParalles),
                // LinkRefNo = entity.LinkRefNo
                GLVoucherDetailTaxes = ToDataTransferObjects(model.GLVoucherDetailTaxes)

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GLVoucherDetailEntity ToDataTransferObject(GLVoucherDetailModel model)
        {
            return new GLVoucherDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                CreditAccountingObjectId = model.CreditAccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                ProjectActivityId = model.ProjectActivityId,
                ProjectExpenseId = model.ProjectExpenseId,
                TaskId = model.TaskId,
                ListItemId = model.ListItemId,
                Approved = model.Approved,
                ParentRefDetailId = model.ParentRefDetailId,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                BankAccount = model.BankAccount,
                FundStructureId = model.FundStructureId,
                ProjectExpenseEAId = model.ProjectExpenseEAId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BudgetProvideCode = model.BudgetProvideCode,
                TopicId = model.TopicId,
                BudgetExpenseId = model.BudgetExpenseId,
                BankId = model.BankId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId,
                AutoBusinessID = model.AutoBusinessId
            };
        }
        internal static GLVoucherListEntity ToDataTransferObject(GLVoucherListModel model)
        {
            return new GLVoucherListEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                RefNo = model.RefNo,
                VoucherTypeId = model.VoucherTypeId,
                SetupType = model.SetupType,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                Description = model.Description,
                TotalAmount = model.TotalAmount,
                EditVersion = model.EditVersion,
                GlVoucherListDetails = ToDataTransferObjects(model.GlVoucherListDetails)

            };
        }
        internal static GLPaymentListEntity ToDataTransferObject(GLPaymentListModel model)
        {
            return new GLPaymentListEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                VoucherTypeId = model.VoucherTypeId,
                SetupType = model.SetupType,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                Description = model.Description,
                TotalAmount = model.TotalAmount,
                EditVersion = model.EditVersion,
                GLPaymentListDetails = ToDataTransferObjects(model.GLPaymentListDetails)

            };
        }
        internal static GLVoucherListDetailEntity ToDataTransferObject(GLVoucherListDetailModel model)
        {
            return new GLVoucherListDetailEntity
            {
                RefId = model.RefId,
                DetailRefType = model.DetailRefType,
                DetailRefId = model.DetailRefId,
                DetailId = model.DetailId,
                SortOrder = model.SortOrder,
                EntryType = model.EntryType,
                BudgetSourceId = model.BudgetSourceId,
                RefDate = (model.RefDate == null || model.RefDate == DateTime.MinValue) ? null : model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.Amount,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,


            };
        }
        internal static GLPaymentListDetailEntity ToDataTransferObject(GLPaymentListDetailModel model)
        {
            return new GLPaymentListDetailEntity
            {
                RefId = model.RefId,
                DetailRefType = model.DetailRefType,
                DetailRefId = model.DetailRefId,
                DetailId = model.DetailId,
                SortOrder = model.SortOrder,
                EntryType = model.EntryType,
                BudgetSourceId = model.BudgetSourceId,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                Description = model.Description,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,

            };
        }


        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GLVoucherDetailTaxEntity ToDataTransferObject(GLVoucherDetailTaxModel model)
        {
            return new GLVoucherDetailTaxEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                VATAmount = model.VATAmount,
                VATRate = model.VATRate,
                TurnOver = model.TurnOver,
                InvType = model.InvType,
                InvDate = model.InvDate,
                InvSeries = model.InvSeries,
                InvNo = model.InvNo,
                PurchasePurposeId = model.PurchasePurposeId,
                AccountingObjectId = model.AccountingObjectId,
                AccountingObjectName = model.AccountingObjectName,
                AccountingObjectAddress = model.AccountingObjectAddress,
                CompanyTaxCode = model.CompanyTaxCode,
                SortOrder = model.SortOrder,
                InvoiceTypeCode = model.InvoiceTypeCode
            };
        }




        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GeneralEntity ToDataTransferObject(GeneralVocherModel model)
        {
            if (model == null)
                return null;
            return new GeneralEntity
            {
                RefId = model.RefId,
                RefTypeId = model.RefTypeId,
                RefNo = model.RefNo,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                JournalMemo = model.JournalMemo,
                TotalAmountExchange = model.TotalAmountExchange,
                TotalAmountOc = model.TotalAmountOc,
                GeneralDetails = ToGeneralVoucherDetailDataTransferObject(model.GeneralVoucherDetails)
            };
        }

        /// <summary>
        /// To the general detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GeneralVoucherDetailModel ToGeneralDetailDataTransferObject(GeneralDetailEntity model)
        {
            if (model == null)
                return null;
            return new GeneralVoucherDetailModel
            {
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                RefId = model.RefId,
                ProjectId = model.ProjectId,
                CurrencyCode = model.CurrencyCode,
                CustomerId = model.CustomerId,
                DepartmentId = model.DepartmentId,
                EmployeeId = model.EmployeeId,
                ExchangeRate = model.ExchangeRate,
                VendorId = model.VendorId,
                BankId = model.BankId,
                RefDetailId = model.RefDetailId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GeneralVoucherDetailModel ToDataTransferObject(GeneralDetailEntity model)
        {
            if (model == null)
                return null;
            return new GeneralVoucherDetailModel
            {
                RefDetailId = model.RefDetailId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                ProjectId = model.ProjectId,
                CurrencyCode = model.CurrencyCode,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                VendorId = model.VendorId,
                BankId = model.BankId,
                DepartmentId = model.DepartmentId,
                ExchangeRate = model.ExchangeRate,
                RefId = model.RefId,
                InventoryItemId = model.InventoryItemId
            };
        }

        /// <summary>
        /// To the general voucher detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static GeneralDetailEntity ToGeneralVoucherDetailDataTransferObject(GeneralVoucherDetailModel model)
        {
            if (model == null)
                return null;
            return new GeneralDetailEntity
            {
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Description = model.Description,
                AmountOc = model.AmountOc,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                AccountingObjectId = model.AccountingObjectId,
                RefId = model.RefId,
                CurrencyCode = model.CurrencyCode,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                ExchangeRate = model.ExchangeRate,
                ProjectId = model.ProjectId,
                DepartmentId = model.DepartmentId,
                VendorId = model.VendorId,
                BankId = model.BankId,
                InventoryItemId = model.InventoryItemId

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static DepartmentEntity ToDataTransferObject(DepartmentModel model)
        {
            return new DepartmentEntity
            {
                DepartmentId = model.DepartmentId,
                DepartmentCode = model.DepartmentCode,
                DepartmentName = model.DepartmentName,
                Description = model.Description,
                IsActive = model.IsActive,
                ParentId = model.ParentId,
                Grade = model.Grade,
                IsParent = model.IsParent
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EmployeeTypeEntity ToDataTransferObject(EmployeeTypeModel model)
        {
            return new EmployeeTypeEntity
            {
                EmployeeTypeId = model.EmployeeTypeId,
                EmployeeTypeName = model.EmployeeTypeName,
                Description = model.Description,
                IsActive = model.IsActive,
                EmployeeTypeCode = model.EmployeeTypeCode
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BudgetSourceCategoryEntity ToDataTransferObject(BudgetSourceCategoryModel model)
        {
            return new BudgetSourceCategoryEntity
            {
                BudgetSourceCategoryId = model.BudgetSourceCategoryId,
                BudgetSourceCategoryCode = model.BudgetSourceCategoryCode,
                BudgetSourceCategoryName = model.BudgetSourceCategoryName,
                ParentId = model.ParentId,
                IsParent = model.IsParent,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <returns></returns>
        internal static BudgetItemEntity ToDataTransferObject(BudgetItemModel model)
        {
            return new BudgetItemEntity
            {
                BudgetItemId = model.BudgetItemId,
                ParentId = model.ParentId,
                BudgetItemType = model.BudgetItemType,
                BudgetItemCode = model.BudgetItemCode,
                BudgetItemName = model.BudgetItemName,
                BudgetGroupItemCode = model.BudgetGroupItemCode,
                Grade = model.Grade,
                IsParent = model.IsParent,
                IsActive = model.IsActive
            };
        }

        internal static BudgetKindItemEntity ToDataTransferObject(BudgetKindItemModel model)
        {
            return new BudgetKindItemEntity
            {
                BudgetKindItemId = model.BudgetKindItemId,
                ParentId = model.ParentId,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetKindItemName = model.BudgetKindItemName,
                Grade = model.Grade,
                IsParent = model.IsParent,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <returns></returns>
        internal static PlanTemplateListEntity ToDataTransferObject(PlanTemplateListModel model)
        {
            return new PlanTemplateListEntity
            {
                PlanTemplateListId = model.PlanTemplateListId,
                PlanTemplateListCode = model.PlanTemplateListCode,
                PlanType = model.PlanType,
                PlanYear = model.PlanYear,
                PlanTemplateListName = model.PlanTemplateListName,
                ParentId = model.ParentId,
                PlanTemplateItems = ToDataTransferObjects(model.PlanTemplateItems)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AutoIDEntity ToDataTransferObject(AutoIDModel model)
        {
            return new AutoIDEntity
            {
                RefTypeCategoryId = model.RefTypeCategoryId,
                RefTypeCategoryName = model.RefTypeCategoryName,
                Prefix = model.Prefix,
                Value = model.Value,
                LengthOfValue = model.LengthOfValue,
                Suffix = model.Suffix,
                IsSystem = model.IsSystem
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static PlanTemplateItemEntity ToDataTransferObject(PlanTemplateItemModel model)
        {
            return new PlanTemplateItemEntity
            {
                PlanTemplateItemId = model.PlanTemplateItemId,
                PlanTemplateListId = model.PlanTemplateListId,
                BudgetItemCode = model.BudgetItemCode,
                BudgetItemName = model.BudgetItemName,
                IsInserted = model.IsInserted //LINHMC ADD
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetCategoryEntity ToDataTransferObject(FixedAssetCategoryModel model)
        {
            return new FixedAssetCategoryEntity
            {
                FixedAssetCategoryId = model.FixedAssetCategoryId
             ,
                FixedAssetCategoryCode = model.FixedAssetCategoryCode
             ,
                FixedAssetCategoryName = model.FixedAssetCategoryName
             ,
                Description = model.Description
             ,
                ParentId = model.ParentId
             ,
                Grade = model.Grade
             ,
                IsParent = model.IsParent
             ,
                LifeTime = model.LifeTime
             ,
                DepreciationRate = model.DepreciationRate
             ,
                OrgPriceAccount = model.OrgPriceAccount
             ,
                DepreciationAccount = model.DepreciationAccount
             ,
                CapitalAccount = model.CapitalAccount
             ,
                BudgetChapterCode = model.BudgetChapterCode
             ,
                BudgetKindItemCode = model.BudgetKindItemCode
             ,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode
             ,
                BudgetItemCode = model.BudgetItemCode
             ,
                BudgetSubItemCode = model.BudgetSubItemCode
             ,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetEntity ToDataTransferObject(FixedAssetModel model)
        {
            return new FixedAssetEntity
            {
                FixedAssetId = model.FixedAssetId,
                FixedAssetCategoryId = model.FixedAssetCategoryId,
                DepartmentId = model.DepartmentId,
                FixedAssetCode = model.FixedAssetCode,
                FixedAssetName = model.FixedAssetName,
                Quantity = model.Quantity,
                Description = model.Description,
                ProductionYear = model.ProductionYear,
                MadeIn = model.MadeIn,
                SerialNumber = model.SerialNumber,
                Accessories = model.Accessories,
                VendorId = model.VendorId,
                GuaranteeDuration = model.GuaranteeDuration,
                IsSecondHand = model.IsSecondHand,
                LastState = model.LastState,
                DisposedDate = model.DisposedDate,
                DisposedAmount = model.DisposedAmount,
                DisposedReason = model.DisposedReason,
                PurchasedDate = model.PurchasedDate,
                UsedDate = model.UsedDate,
                DepreciationDate = model.DepreciationDate,
                IncrementDate = model.IncrementDate,
                OrgPrice = model.OrgPrice,
                DepreciationValueCaculated = model.DepreciationValueCaculated,
                AccumDepreciationAmount = model.AccumDepreciationAmount,
                LifeTime = model.LifeTime,
                DepreciationRate = model.DepreciationRate,
                PeriodDepreciationAmount = model.PeriodDepreciationAmount,
                RemainingAmount = model.RemainingAmount,
                RemainingLifeTime = model.RemainingLifeTime,
                EndYear = model.EndYear,
                OrgPriceAccount = model.OrgPriceAccount,
                CapitalAccount = model.CapitalAccount,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                CreditDepreciationAccount = model.CreditDepreciationAccount,
                DebitDepreciationAccount = model.DebitDepreciationAccount,
                IsFixedAssetTransfer = model.IsFixedAssetTransfer,
                DepreciationTimeCaculated = model.DepreciationTimeCaculated,
                Unit = model.Unit,
                RevenueAccount = model.RevenueAccount,
                Source = model.Source,
                IsActive = model.IsActive,
                UsingRatio = model.UsingRatio,
                DevaluationLifeTime = model.DevaluationLifeTime,
                DevaluationRate = model.DevaluationRate,
                DevaluationPeriod = model.DevaluationPeriod,
                DevaluationDate = model.DevaluationDate,
                DevaluationCreditAccount = model.DevaluationCreditAccount,
                DevaluationDebitAccount = model.DevaluationDebitAccount,
                AccumDevaluationAmount = model.AccumDevaluationAmount,
                EndDevaluationDate = model.EndDevaluationDate,
                PeriodDevaluationAmount = model.PeriodDevaluationAmount,
                DevaluationAmount = model.DevaluationAmount,
                FixedAssetDetailAccessories = ToDataTransferObjects(model.FixedAssetDetailAccessories),
                FundStructureId = model.FundStructureId
                //FixedAssetActivities = ToDataTransferObjects(model.FixedAssetActivities) 
            };
        }

        internal static FixedAssetActivityEntity ToDataTransferObject(FixedAssetActivityModel model)
        {
            return new FixedAssetActivityEntity
            {
                FixedAssetId = model.FixedAssetId,
                FixedAssetActivityId = model.FixedAssetActivityId,
                DepreciationValueCaculated = model.DepreciationValueCaculated,
                DebitDepreciationAccount = model.DebitDepreciationAccount,
                CreditDepreciationAccount = model.CreditDepreciationAccount
            };
        }

        internal static IList<FixedAssetActivityEntity> ToDataTransferObjects(IList<FixedAssetActivityModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        internal static IList<FixedAssetDetailAccessoryEntity> ToDataTransferObjects(IList<FixedAssetDetailAccessoryModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }


        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static PayItemEntity ToDataTransferObject(PayItemModel model)
        {
            return new PayItemEntity
            {
                PayItemId = model.PayItemId,
                PayItemCode = model.PayItemCode,
                PayItemName = model.PayItemName,
                Type = model.Type,
                IsCalculateRatio = model.IsCalculateRatio,
                IsSocialInsurance = model.IsSocialInsurance,
                IsCareInsurance = model.IsCareInsurance,
                IsTradeUnionFee = model.IsTradeUnionFee,
                Description = model.Description,
                DebitAccountCode = model.DebitAccountCode,
                CreditAccountCode = model.CreditAccountCode,
                BudgetChapterCode = model.BudgetChapterCode,
                IsDefault = model.IsDefault,
                IsActive = model.IsActive,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetGroupCode = model.BudgetGroupCode,
                BudgetItemCode = model.BudgetItemCode
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CustomerEntity ToDataTransferObject(CustomerModel model)
        {
            if (model == null)
                return null;
            return new CustomerEntity
            {
                CustomerId = model.CustomerId,
                CustomerCode = model.CustomerCode,
                CustomerName = model.CustomerName,
                Address = model.Address,
                ContactName = model.ContactName,
                ContactRegency = model.ContactRegency,
                Phone = model.Phone,
                Mobile = model.Mobile,
                Fax = model.Fax,
                Email = model.Email,
                TaxCode = model.TaxCode,
                Website = model.Website,
                Province = model.Province,
                City = model.City,
                ZipCode = model.ZipCode,
                Area = model.Area,
                Country = model.Country,
                BankNumber = model.BankNumber,
                BankId = model.BankId,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static VendorEntity ToDataTransferObject(VendorModel model)
        {
            if (model == null)
                return null;
            return new VendorEntity
            {
                VendorId = model.VendorId,
                VendorCode = model.VendorCode,
                VendorName = model.VendorName,
                Address = model.Address,
                ContactName = model.ContactName,
                ContactRegency = model.ContactRegency,
                Phone = model.Phone,
                Mobile = model.Mobile,
                Fax = model.Fax,
                Email = model.Email,
                TaxCode = model.TaxCode,
                Website = model.Website,
                Province = model.Province,
                City = model.City,
                ZipCode = model.ZipCode,
                Area = model.Area,
                Country = model.Country,
                BankNumber = model.BankNumber,
                BankId = model.BankId,
                IsActive = model.IsActive,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static VoucherListEntity ToDataTransferObject(VoucherListModel model)
        {
            return new VoucherListEntity
            {
                VoucherListId = model.VoucherListId,
                VoucherListCode = model.VoucherListCode,
                VoucherListName = model.VoucherListName,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                DocumentAttached = model.DocumentAttached,
                Description = model.Description,
                IsActive = model.IsActive

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static InvoiceFormNumberEntity ToDataTransferObject(InvoiceFormNumberModel model)
        {
            return new InvoiceFormNumberEntity
            {
                InvoiceFormNumberId = model.InvoiceFormNumberId,
                InvoiceFormNumberCode = model.InvoiceFormNumberCode,
                InvoiceFormNumberName = model.InvoiceFormNumberName,
                InvoiceType = model.InvoiceType,
                IsSystem = model.IsSystem,
                IsActive = model.IsActive

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AccountingObjectEntity ToDataTransferObject(AccountingObjectModel model)
        {
            if (model == null)
                return null;
            var newProjectBanks = new List<BankEntity>();
            if (model.AccountingObjectBanks != null)
            {
                foreach (var bank in model.AccountingObjectBanks)
                {
                    var newBank = new BankEntity()
                    {
                        BankAccount = bank.BankAccount,
                        BankName = bank.BankName,
                        BankId = bank.BankId,
                        SortBank = bank.SortBank,
                    };
                    newProjectBanks.Add(newBank);
                }
            }
            return new AccountingObjectEntity
            {
                AccountingObjectId = model.AccountingObjectId,
                AccountingObjectCode = model.AccountingObjectCode,
                AccountingObjectCategoryId = model.AccountingObjectCategoryId,
                AccountingObjectName = model.AccountingObjectName,
                Address = model.Address,
                Tel = model.Tel,
                Fax = model.Fax,
                Website = model.Website,
                BankAccount = model.BankAccount,
                BankName = model.BankName,
                CompanyTaxCode = model.CompanyTaxCode,
                BudgetCode = model.BudgetCode,
                AreaCode = model.AreaCode,
                Description = model.Description,
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                ContactSex = model.ContactSex,
                ContactMobile = model.ContactMobile,
                ContactEmail = model.ContactEmail,
                ContactOfficeTel = model.ContactOfficeTel,
                ContactHomeTel = model.ContactHomeTel,
                ContactAddress = model.ContactAddress,
                IsEmployee = model.IsEmployee,
                IsPersonal = model.IsPersonal,
                IdentificationNumber = model.IdentificationNumber,
                IssueDate = model.IssueDate,
                IssueBy = model.IssueBy,
                DepartmentId = model.DepartmentId,
                SalaryScaleId = model.SalaryScaleId,
                Insured = model.Insured,
                LabourUnionFee = model.LabourUnionFee,
                FamilyDeductionAmount = model.FamilyDeductionAmount,
                IsActive = model.IsActive,
                ProjectId = model.ProjectId,
                IsCustomerVendor = model.IsCustomerVendor,
                SalaryCoefficient = model.SalaryCoefficient,
                NumberFamilyDependent = model.NumberFamilyDependent,
                EmployeeTypeId = model.EmployeeTypeId,
                SalaryForm = model.SalaryForm,
                SalaryPercentRate = model.SalaryPercentRate,
                SalaryAmount = model.SalaryAmount,
                IsPayInsuranceOnSalary = model.IsPayInsuranceOnSalary,
                InsuranceAmount = model.InsuranceAmount,
                IsUnEmploymentInsurance = model.IsUnEmploymentInsurance,
                RefTypeAO = model.RefTypeAO,
                SalaryGrade = model.SalaryGrade,
                CustomField1 = model.CustomField1,
                CustomField2 = model.CustomField2,
                CustomField3 = model.CustomField3,
                CustomField4 = model.CustomField4,
                CustomField5 = model.CustomField5,
                IsPaidInsuranceForPayrollItem = model.IsPaidInsuranceForPayrollItem,
                IsBornLeave = model.IsBornLeave,
                TaxDepartmentName = model.TaxDepartmentName,
                TreasuryName = model.TreasuryName,
                BudgetChapterId = model.BudgetChapterId,
                BudgetItemId = model.BudgetItemId,
                OrganizationManageFee = model.OrganizationManageFee,
                OrganizationFeeCode = model.OrganizationFeeCode,
                TreasuryManageFee = model.TreasuryManageFee,
                AccountingObjectBanks = newProjectBanks
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BudgetChapterEntity ToDataTransferObject(BudgetChapterModel model)
        {
            return new BudgetChapterEntity
            {
                BudgetChapterId = model.BudgetChapterId,
                BudgetChapterCode = model.BudgetChapterCode.Trim(),
                BudgetChapterName = model.BudgetChapterName.Trim(),
                IsActive = model.IsActive,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BudgetCategoryEntity ToDataTransferObject(BudgetCategoryModel model)
        {
            return new BudgetCategoryEntity
            {
                BudgetCategoryId = model.BudgetCategoryId,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetCategoryName = model.BudgetCategoryName,
                ParentId = model.ParentId,
                Description = model.Description,
                IsParent = model.IsParent,
                IsActive = model.IsActive,
                IsSystem = model.IsSystem,
                Grade = model.Grade,
                ForeignName = model.ForeignName

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static MergerFundEntity ToDataTransferObject(MergerFundModel model)
        {
            return new MergerFundEntity
            {
                MergerFundId = model.MergerFundId,
                MergerFundCode = model.MergerFundCode,
                MergerFundName = model.MergerFundName,
                ParentId = model.ParentId,
                Description = model.Description,
                IsActive = model.IsActive,
                IsSystem = model.IsSystem,
                Grade = model.Grade,
                ForeignName = model.ForeignName
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BudgetSourceEntity ToDataTransferObject(BudgetSourceModel model)
        {
            return new BudgetSourceEntity
            {
                BudgetSourceId = model.BudgetSourceId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetSourceName = model.BudgetSourceName,
                ParentId = model.ParentId,
                IsParent = model.IsParent,
                IsSavingExpenses = model.IsSavingExpenses,
                BudgetSourceCategoryId = model.BudgetSourceCategoryId,
                BudgetSourceProperty = model.BudgetSourceProperty,
                BankAccountId = model.BankAccountId,
                PayableBankAccountId = model.PayableBankAccountId,
                ProjectId = model.ProjectId,
                IsSelfControl = model.IsSelfControl,
                IsActive = model.IsActive,
                BudgetCode = model.BudgetCode,
                BudgetSourceType = model.BudgetSourceType
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EmployeeEntity ToDataTransferObject(EmployeeModel model)
        {
            return new EmployeeEntity
            {
                EmployeeId = model.EmployeeId,
                EmployeeCode = model.EmployeeCode,
                EmployeeName = model.EmployeeName,
                JobCandidateName = model.JobCandidateName,
                SortOrder = model.SortOrder,
                BirthDate = model.BirthDate == null ? (DateTime?)null : DateTime.Parse(model.BirthDate),
                TypeOfSalary = model.TypeOfSalary,
                Sex = model.Sex,
                LevelOfSalary = model.LevelOfSalary,
                DepartmentId = model.DepartmentId,
                CurrencyCode = model.CurrencyCode,
                IdentityNo = model.IdentityNo,
                IssueDate = model.IssueDate == null ? (DateTime?)null : DateTime.Parse(model.IssueDate),
                IssueBy = model.IssueBy,
                IsActive = model.IsActive,
                Description = model.Description,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                IsOffice = model.IsOffice,
                RetiredDate = model.RetiredDate == null ? (DateTime?)null : DateTime.Parse(model.RetiredDate),
                StartingDate = model.StartingDate == null ? (DateTime?)null : DateTime.Parse(model.StartingDate),
                EmployeePayItems = ToDataTransferObjects(model.EmployeePayItems)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static StockEntity ToDataTransferObject(StockModel model)
        {
            return new StockEntity
            {
                StockId = model.StockId,
                StockCode = model.StockCode.Trim(),
                StockName = model.StockName.Trim(),
                Description = model.Description.Trim(),
                IsActive = model.IsActive,
                DefaultAccountNumber = model.DefaultAccountNumber
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static CaptitalAllocateVoucherEntity ToDataTransferObject(CaptitalAllocateVoucherModel model)
        {
            return new CaptitalAllocateVoucherEntity
            {
                ActivityId = model.ActivityId,
                AllocatePercent = model.AllocatePercent,
                AllocateType = model.AllocateType,
                Amount = model.Amount,
                TotalAmount = model.TotalAmount,
                RefId = model.RefId,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSourceCode = model.BudgetSourceCode,
                CapitalAccountCode = model.CapitalAccountCode,
                CapitalAllocateCode = model.CapitalAllocateCode,
                RefDetailId = model.RefDetailId,
                Description = model.Description,
                DeterminedDate = model.DeterminedDate,
                ExpenseAccountCode = model.ExpenseAccountCode,
                ExpenseAmount = model.ExpenseAmount,
                IsActive = model.IsActive,
                RevenueAccountCode = model.RevenueAccountCode,
                WaitBudgetSourceCode = model.WaitBudgetSourceCode,
                CurrencyCode = model.CurrencyCode,
                FromDate = model.FromDate,
                ToDate = model.ToDate
            };
        }


        internal static AccountTranferVourcherEntity ToDataTransferObject(AccountTranferVourcherModel model)
        {
            return new AccountTranferVourcherEntity
            {


                BudgetSourceCode = model.BudgetSourceCode,
                RefDetailId = model.RefDetailId,
                Description = model.Description,
                CurrencyCode = model.CurrencyCode,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                AmountExchange = model.AmountExchange,
                AmountOc = model.AmountOc,
                ExchangeRate = model.ExchangeRate,
                RefId = model.RefId,
                PostedDate = model.PostedDate,


            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static InventoryItemEntity ToDataTransferObject(InventoryItemModel model)
        {
            return new InventoryItemEntity
            {
                InventoryItemId = model.InventoryItemId,
                InventoryCategoryId = model.InventoryCategoryId,
                InventoryItemCode = model.InventoryItemCode.Trim(),
                InventoryItemName = model.InventoryItemName.Trim(),
                Description = model.Description,
                Unit = model.Unit,
                ConvertUnit = model.ConvertUnit,
                ConvertRate = model.ConvertRate,
                UnitPrice = model.UnitPrice,
                SalePrice = model.SalePrice,
                DefaultStockId = model.DefaultStockId,
                DepartmentId = model.DepartmentId,
                InventoryAccount = model.InventoryAccount,
                COGSAccount = model.COGSAccount,
                SaleAccount = model.SaleAccount,
                CostMethod = model.CostMethod,
                AccountingObjectId = model.AccountingObjectId,
                TaxRate = model.TaxRate,
                IsTool = model.IsTool,
                IsService = model.IsService,
                IsActive = model.IsActive,
                IsTaxable = model.IsTaxable,
                IsStock = model.IsStock,
                MadeIn = model.MadeIn
            };
        }

        internal static InventoryItemCategoryEntity ToDataTransferObject(InventoryItemCategoryModel model)
        {
            return new InventoryItemCategoryEntity
            {
                InventoryItemCategoryId = model.InventoryItemCategoryId,
                InventoryItemCategoryCode = model.InventoryItemCategoryCode,
                InventoryItemCategoryName = model.InventoryItemCategoryName,
                ParentId = model.ParentId,
                Grade = model.Grade,
                IsParent = model.IsParent,
                IsTool = model.IsTool,
                IsSystem = model.IsSystem,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EmployeePayItemEntity ToDataTransferObject(EmployeePayItemModel model)
        {
            return new EmployeePayItemEntity
            {
                EmployeeId = model.EmployeeId,
                EmployeePayItemId = model.EmployeePayItemId,
                PayItemId = model.PayItemId,
                Amount = model.Amount,
                SalaryRatio = model.SalaryRatio
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BankEntity ToDataTransferObject(BankModel model)
        {
            return new BankEntity
            {
                BankId = model.BankId,
                BankAccount = string.IsNullOrEmpty(model.BankAccount) ? null : model.BankAccount.Trim(),
                BankAddress = string.IsNullOrEmpty(model.BankAddress) ? null : model.BankAddress.Trim(),
                BankName = string.IsNullOrEmpty(model.BankName) ? null : model.BankName.Trim(),
                BudgetCode = model.BudgetCode,
                Description = string.IsNullOrEmpty(model.Description) ? null : model.Description.Trim(),
                IsActive = model.IsActive,
                IsOpenInBank = model.IsOpenInBank,
                SortBank = model.SortBank,
            };
        }
        internal static ActivityEntity ToDataTransferObject(ActivityModel model)
        {
            return new ActivityEntity
            {
                ActivityId = model.ActivityId,
                ActivityCode = model.ActivityCode.Trim(),
                ActivityName = model.ActivityName.Trim(),
                Grade = model.Grade,
                IsSystem = model.IsSystem,
                IsParent = model.IsParent,
                IsActive = model.IsActive,
                ParentID = model.ParentID
            };
        }


        internal static ExchangeRateEntity ToDataTransferObject(ExchangeRateModel model)
        {
            return new ExchangeRateEntity
            {
                ExchangeRateId = model.ExchangeRateId,
                Description = model.Description,
                FromDate = model.FromDate,
                ToDate = model.ToDate,
                ExchangeRate = model.ExchangeRate,
                Inactive = model.Inactive,
                BudgetSourceCode = model.BudgetSourceCode
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AccountTransferEntity ToDataTransferObject(AccountTransferModel model)
        {
            return new AccountTransferEntity
            {
                AccountTransferId = model.AccountTransferId,
                BusinessType = model.BusinessType,
                AccountTransferCode = model.AccountTransferCode,
                ReferentAccount = model.ReferentAccount,
                TransferOrder = model.TransferOrder,
                FromAccount = model.FromAccount,
                ToAccount = model.ToAccount,
                TransferSide = model.TransferSide,
                BudgetSourceId = model.BudgetSourceId,
                Description = model.Description,
                IsSystem = model.IsSystem,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AudittingLogEntity ToDataTransferObject(AudittingLogModel model)
        {
            return new AudittingLogEntity
            {
                EventId = model.EventId,
                LoginName = model.LoginName,
                ComputerName = model.ComputerName,
                EventTime = model.EventTime,
                ComponentName = model.ComponentName,
                EventAction = model.EventAction,
                Reference = model.Reference,
                Amount = model.Amount
            };
        }
        ///// <summary>
        ///// To the data transfer object.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns>
        ///// DepositEntity.
        ///// </returns>
        //internal static DepositEntity ToDataTransferObject(DepositModel model)
        //{
        //    return new DepositEntity
        //    {
        //        RefId = model.RefId,
        //        RefTypeId = model.RefTypeId,
        //        RefDate = DateTime.Parse(model.RefDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
        //        PostedDate = DateTime.Parse(model.PostedDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
        //        RefNo = model.RefNo,
        //        AccountingObjectType = model.AccountingObjectType,
        //        AccountingObjectId = model.AccountingObjectId,
        //        Trader = model.Trader,
        //        CustomerId = model.CustomerId,
        //        VendorId = model.VendorId,
        //        EmployeeId = model.EmployeeId,
        //        BankAccountCode = model.BankAccountCode,
        //        CurrencyCode = model.CurrencyCode,
        //        ExchangeRate = model.ExchangeRate,
        //        TotalAmountOc = model.TotalAmountOc,
        //        TotalAmountExchange = model.TotalAmountExchange,
        //        JournalMemo = model.JournalMemo,
        //        BankId = model.BankId,
        //        DepositDetails = ToDataTransferObjects(model.DepositDetails)
        //    };
        //}

        ///// <summary>
        ///// To the data transfer object.
        ///// </summary>
        ///// <param name="model">The model.</param>
        ///// <returns>
        ///// DepositDetailEntity.
        ///// </returns>
        //internal static DepositDetailEntity ToDataTransferObject(DepositDetailModel model)
        //{
        //    return new DepositDetailEntity
        //    {
        //        RefDetailId = model.RefDetailId,
        //        RefId = model.RefId,
        //        Description = model.Description,
        //        AccountNumber = model.AccountNumber,
        //        CorrespondingAccountNumber = model.CorrespondingAccountNumber,
        //        AmountOc = model.AmountOc,
        //        AmountExchange = model.AmountExchange,
        //        VoucherTypeId = model.VoucherTypeId,
        //        BudgetSourceCode = model.BudgetSourceCode,
        //        AccountingObjectId = model.AccountingObjectId,
        //        BudgetItemCode = model.BudgetItemCode,
        //        DepartmentId = model.DepartmentId,
        //        MergerFundId = model.MergerFundId,
        //        ProjectId = model.ProjectId,
        //        AutoBusinessId = model.AutoBusinessId
        //    };
        //}

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static AutoBusinessEntity ToDataTransferObject(AutoBusinessModel model)
        {
            return new AutoBusinessEntity
            {
                AutoBusinessId = model.AutoBusinessId,
                AutoBusinessCode = model.AutoBusinessCode,
                AutoBusinessName = model.AutoBusinessName,
                RefTypeId = model.RefTypeId,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithDrawTypeId = model.CashWithDrawTypeId,
                Description = model.Description,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static DBOptionEntity ToDataTransferObject(DBOptionModel model)
        {
            return new DBOptionEntity
            {
                OptionId = model.OptionId,
                OptionValue = model.OptionValue,
                ValueType = model.ValueType,
                IsSystem = model.IsSystem,
                Description = model.Description
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <returns></returns>
        internal static ProjectEntity ToDataTransferObject(ProjectModel model)
        {
            var newProjectBanks = new List<BankEntity>();
            if (model.ProjectBanks != null)
            {
                foreach (var bank in model.ProjectBanks)
                {
                    var newBank = new BankEntity()
                    {
                        BankAccount = bank.BankAccount,
                        BankName = bank.BankName,
                        BankId = bank.BankId,
                        SortBank = bank.SortBank
                    };
                    newProjectBanks.Add(newBank);
                }
            }
            return new ProjectEntity
            {
                ProjectId = model.ProjectId,
                ProjectCode = model.ProjectCode.Trim(),
                ProjectNumber = model.ProjectNumber,
                ProjectName = model.ProjectName.Trim(),
                ProjectEnglishName = model.ProjectEnglishName,
                BUCACodeID = model.BUCACodeID,
                StartDate = model.StartDate,
                FinishDate = model.FinishDate,
                ExecutionUnit = model.ExecutionUnit,
                DepartmentID = model.DepartmentID,
                TotalAmountApproved = model.TotalAmountApproved,
                ParentID = model.ParentID,
                Grade = model.Grade,
                IsParent = model.IsParent,
                IsDetailbyActivityAndExpense = model.IsDetailbyActivityAndExpense,
                IsSystem = model.IsSystem,
                IsActive = model.IsActive,
                ObjectType = model.ObjectType,
                ContractorID = model.ContractorID,
                ContractorName = model.ContractorName,
                ContractorAddress = model.ContractorAddress,
                Description = model.Description,
                ProjectSize = model.ProjectSize,
                BuildLocation = model.BuildLocation,
                InvestmentClass = model.InvestmentClass,
                CDCActivityType = model.CDCActivityType,
                Investment = model.Investment,
                BankId = model.BankId,
                ProjectBanks = newProjectBanks

            };
        }

        internal static ContractEntity ToDataTransferObject(ContractModel model)
        {
            return new ContractEntity
            {
                ContractId = model.ContractId,
                ContractNo = model.ContractNo,
                ContractName = model.ContractName,
                ContractNameEnglish = model.ContractNameEnglish,
                SignDate = model.SignDate,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                AmountOC = model.AmountOC,
                ProjectId = model.ProjectId,
                Description = model.Description,
                VendorId = model.VendorId,
                VendorBankAccountId = model.VendorBankAccountId,
                IsActive = model.IsActive,
                ContractDetails = ToDataTransferObjects(model.ContractDetails),
            };
        }
        internal static ContractDetailEntity ToDataTransferObject(ContractDetailsModel model)
        {
            return new ContractDetailEntity
            {
                AddendumNo = model.AddendumNo,
                BudgetSourceId = model.BudgetSourceId,
                ContractDetailID = model.ContractDetailID,
                ContractID = model.ContractID,
                CurrencyId = model.CurrencyId,
                Description = model.Description,
                ExchangeRate = model.ExchangeRate,
                ExchangeValue = model.ExchangeValue,
                Prices = model.Prices,
                SignDate = model.SignDate,
                Stt = model.Stt
            };
        }
        internal static TaxItemEntity ToDataTransferObject(TaxItemModel model)
        {
            return new TaxItemEntity
            {
                TaxItemId = model.TaxItemId,
                TaxItemCode = model.TaxItemCode,
                TaxItemName = model.TaxItemName,
                IsActive = model.IsActive,

            };
        }
        internal static TaxTypeEntity ToDataTransferObject(TaxTypeModel model)
        {
            return new TaxTypeEntity
            {
                TaxTypeId = model.TaxTypeId,
                TaxTypeCode = model.TaxTypeCode,
                TaxTypeName = model.TaxTypeName,
                IsActive = model.IsActive,

            };
        }

        internal static FundStructureEntity ToDataTransferObject(FundStructureModel model)
        {
            return new FundStructureEntity
            {
                FundStructureId = model.FundStructureId,
                FundStructureCode = model.FundStructureCode,
                FundStructureName = model.FundStructureName,
                BUCACodeId = model.BUCACodeId,
                ParentId = model.ParentId,
                Grade = model.Grade,
                IsParent = model.IsParent,
                Inactive = model.Inactive,
                IsSystem = model.IsSystem,
                InvestmentPeriod = model.InvestmentPeriod
                ,
                BudgetItemId = model.BudgetItemId
                ,
                CashWithdrawTypeId = model.CashWithdrawTypeId
                ,
                IsProjectExpense = model.IsProjectExpense
                ,
                IsAllocateExpense = model.IsAllocateExpense
                ,
                IsExpenseNoBuilding = model.IsExpenseNoBuilding

            };
        }

        internal static CompanyProfileEntity ToDataTransferObject(CompanyProfileModel model)
        {
            return new CompanyProfileEntity
            {
                LineId = model.LineId,
                AssetOwnArea = model.AssetOwnArea,
                AssetOwnRoom = model.AssetOwnRoom,
                AssetBuyDate = model.AssetBuyDate,
                AssetOwnDescription = model.AssetOwnDescription,
                AssetMutualArea = model.AssetMutualArea,
                AssetMutualRoom = model.AssetMutualRoom,
                AssetMutualMethod = model.AssetMutualMethod,
                AssetMutualDescription = model.AssetMutualDescription,
                AssetRentContractLen = model.AssetRentContractLen,
                AssetRentPrice = model.AssetRentPrice,
                AssetRentRoom = model.AssetRentRoom,
                AssetRentArea = model.AssetRentArea,
                AssetRentDescription = model.AssetRentDescription,
                AssetNumberOfCars = model.AssetNumberOfCars,
                AssetCarDetail = model.AssetCarDetail,
                EmployeePayrollsTotal = model.EmployeePayrollsTotal,
                EmployeeNumberOfWifeOrHusband = model.EmployeeNumberOfWifeOrHusband,
                EmployeeNumberOfOfficers = model.EmployeeNumberOfOfficers,
                EmployeeNumberOfStaff = model.EmployeeNumberOfStaff,
                EmployeeOtherCompany = model.EmployeeOtherCompany,
                EmployeeNumberOfSecondingOfficers = model.EmployeeNumberOfSecondingOfficers,
                EmployeeDetail = model.EmployeeDetail,
                EmployeeNumberOfRentLocal = model.EmployeeNumberOfRentLocal,
                ProfileAddress = model.ProfileAddress,
                ProfileFoundDate = model.ProfileFoundDate,
                ProfileHeadPhone = model.ProfileHeadPhone,
                ProfileAmbassadorName = model.ProfileAmbassadorName,
                ProfileAmbassadorPhone = model.ProfileAmbassadorPhone,
                ProfileAmbassadorStartDate = model.ProfileAmbassadorStartDate,
                ProfileAmbassadorFinishDate = model.ProfileAmbassadorFinishDate,
                ProfileAccountingManagerName = model.ProfileAccountingManagerName,
                ProfileAccountingManagerPhone = model.ProfileAccountingManagerPhone,
                ProfileAccountingManagerStartDate = model.ProfileAccountingManagerStartDate,
                ProfileAccountingManagerFinishDate = model.ProfileAccountingManagerFinishDate,
                ProfileAccountantName = model.ProfileAccountantName,
                ProfileAccountantPhone = model.ProfileAccountantPhone,
                ProfileAccountantStartDate = model.ProfileAccountantStartDate,
                ProfileAccountantFinishDate = model.ProfileAccountantFinishDate,
                ProfileMinimumSalary = model.ProfileMinimumSalary,
                ProfileSalaryGroup = model.ProfileSalaryGroup,
                ProfileWorkingArea = model.ProfileWorkingArea,
                ProfileCurrencyCodeFinalization = model.ProfileCurrencyCodeFinalization,
                ProfileServices = model.ProfileServices,
                ProfileReportHeader = model.ProfileReportHeader,
                ProfileBankName = model.ProfileBankName,
                ProfileBankAddress = model.ProfileBankAddress,
                ProfileBankAccount = model.ProfileBankAccount,
                ProfileBankCIF = model.ProfileBankCIF,
                OtherNote = model.OtherNote,
                NativeCategory = model.NativeCategory,
                ManagementArea = model.ManagementArea
            };
        }
        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FAArmortizationEntity ToDataTransferObject(FixedAssetArmortizationModel model)
        {
            return new FAArmortizationEntity
            {
                RefId = model.RefId,
                RefNo = model.RefNo,
                RefDate = DateTime.Parse(model.RefDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                PostedDate = DateTime.Parse(model.PostedDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                RefTypeId = model.RefTypeId,
                TotalAmountOC = model.TotalAmountOC,
                TotalAmountExchange = model.TotalAmountExchange,
                JournalMemo = model.JournalMemo,
                CurrencyCode = model.CurrencyCode,
                FAArmortizationDetails = ToDataTransferObjects(model.FixedAssetArmortizationDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FAArmortizationDetailEntity ToDataTransferObject(FixedAssetArmortizationDetailModel model)
        {
            return new FAArmortizationDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                FixedAssetId = model.FixedAssetId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Quantity = model.Quantity,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                AmountOC = model.AmountOC,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetChapterCode = model.BudgetChapterCode,
                Description = model.Description,
                DepartmentId = model.DepartmentId,
                ProjectId = model.ProjectId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FADecrementEntity ToDataTransferObject(FixedAssetDecrementModel model)
        {
            return new FADecrementEntity
            {
                RefId = model.RefId,
                RefNo = model.RefNo,
                RefDate = DateTime.Parse(model.RefDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                PostedDate = DateTime.Parse(model.PostedDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                RefTypeId = model.RefTypeId,
                AccountingObjectId = model.AccountingObjectId,
                AccountingObjectType = model.AccountingObjectType,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                VendorId = model.VendorId,
                TotalAmountExchange = model.TotalAmountExchange,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                TotalAmountOC = model.TotalAmountOC,
                JournalMemo = model.JournalMemo,
                DocumentInclude = model.DocumentInclude,
                Trader = model.Trader,
                BankId = model.BankId,
                FADecrementDetails = ToDataTransferObjects(model.FixedAssetDecrementDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FADecrementDetailEntity ToDataTransferObject(FixedAssetDecrementDetailModel model)
        {
            return new FADecrementDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                FixedAssetId = model.FixedAssetId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Quantity = model.Quantity,
                AmountOC = model.AmountOC,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetChapterCode = model.BudgetChapterCode,
                Description = model.Description,
                DepartmentId = model.DepartmentId,
                ProjectId = model.ProjectId,
                AccountingObjectId = model.AccountingObjectId,
                AutoBusinessId = model.AutoBusinessId,
                UnitPriceExchange = model.UnitPriceExchange,
                UnitPriceOC = model.UnitPriceOC
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FAIncrementEntity ToDataTransferObject(FixedAssetIncrementModel model)
        {
            return new FAIncrementEntity
            {
                RefId = model.RefId,
                RefNo = model.RefNo,
                RefDate = DateTime.Parse(model.RefDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                PostedDate = DateTime.Parse(model.PostedDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                RefTypeId = model.RefTypeId,
                AccountingObjectId = model.AccountingObjectId,
                AccountingObjectType = model.AccountingObjectType,
                CustomerId = model.CustomerId,
                EmployeeId = model.EmployeeId,
                VendorId = model.VendorId,
                Trader = model.Trader,
                TotalAmountExchange = model.TotalAmountExchange,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                TotalAmountOC = model.TotalAmountOC,
                JournalMemo = model.JournalMemo,
                DocumentInclude = model.DocumentInclude,
                BankId = model.BankId,
                FAIncrementDetails = ToDataTransferObjects(model.FixedAssetIncrementDetails)
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FAIncrementDetailEntity ToDataTransferObject(FixedAssetIncrementDetailModel model)
        {
            return new FAIncrementDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                FixedAssetId = model.FixedAssetId,
                AccountNumber = model.AccountNumber,
                CorrespondingAccountNumber = model.CorrespondingAccountNumber,
                Quantity = model.Quantity,
                AmountOC = model.AmountOC,
                AmountExchange = model.AmountExchange,
                VoucherTypeId = model.VoucherTypeId,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetChapterCode = model.BudgetChapterCode,
                Description = model.Description,
                DepartmentId = model.DepartmentId,
                ProjectId = model.ProjectId,
                AccountingObjectId = model.AccountingObjectId,
                AutoBusinessId = model.AutoBusinessId,
                UnitPriceExchange = model.UnitPriceExchange,
                UnitPriceOC = model.UnitPriceOC
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetCurrencyEntity ToDataTransferObject(FixedAssetCurrencyModel model)
        {
            return new FixedAssetCurrencyEntity
            {
                FixedAssetCurrencyId = model.FixedAssetCurrencyId,
                FixedAssetId = model.FixedAssetId,
                CurrencyCode = model.CurrencyCode,
                UnitPrice = model.UnitPrice,
                UnitPriceUSD = model.UnitPriceUSD,
                OrgPrice = model.OrgPrice,
                OrgPriceUSD = model.OrgPriceUSD,
                AccumDepreciationAmount = model.AccumDepreciationAmount,
                AccumDepreciationAmountUSD = model.AccumDepreciationAmountUSD,
                RemainingAmount = model.RemainingAmount,
                RemainingAmountUSD = model.RemainingAmountUSD,
                AnnualDepreciationAmount = model.AnnualDepreciationAmount,
                AnnualDepreciationAmountUSD = model.AnnualDepreciationAmountUSD,
                ExchangeRate = model.ExchangeRate
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static OpeningAccountEntryDetailEntity ToDataTransferObject(OpeningAccountEntryDetailModel model)
        {
            return new OpeningAccountEntryDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefTypeId = model.RefTypeId,
                PostedDate = model.PostedDate,
                AccountCode = model.AccountCode,
                AccountName = model.AccountName,
                AccountId = model.AccountId,
                ParentId = model.ParentId,
                AccountBeginningDebitAmountOC = model.AccountBeginningDebitAmountOC,
                AccountBeginningCreditAmountOC = model.AccountBeginningCreditAmountOC,
                DebitAmountOC = model.DebitAmountOC,
                CreditAmountOC = model.CreditAmountOC,
                AccountBeginningDebitAmountExchange = model.AccountBeginningDebitAmountExchange,
                AccountBeginningCreditAmountExchange = model.AccountBeginningCreditAmountExchange,
                DebitAmountExchange = model.DebitAmountExchange,
                CreditAmountExchange = model.CreditAmountExchange,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                BudgetSourceCode = model.BudgetSourceCode,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetCategoryCode = model.BudgetCategoryCode,
                BudgetGroupItemCode = model.BudgetGroupItemCode,
                BudgetItemCode = model.BudgetItemCode,
                MergerFundId = model.MergerFundId,
                EmployeeId = model.EmployeeId,
                CustomerId = model.CustomerId,
                VendorId = model.VendorId,
                AccountingObjectId = model.AccountingObjectId,
                ProjectId = model.ProjectId,
                BankId = model.BankId,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static OpeningAccountEntryEntity ToDataTransferObject(OpeningAccountEntryModel model)
        {
            return new OpeningAccountEntryEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                PostedDate = model.PostedDate,
                CurrencyId = model.CurrencyId,
                ExchangeRate = model.ExchangeRate,
                AccountNumber = model.AccountNumber,
                AccountName = model.AccountName,
                AccBeginningDebitAmountOC = model.AccBeginningDebitAmountOC,
                AccBeginningDebitAmount = model.AccBeginningDebitAmount,
                AccBeginningCreditAmountOC = model.AccBeginningCreditAmountOC,
                AccBeginningCreditAmount = model.AccBeginningCreditAmount,
                DebitAmountOC = model.DebitAmountOC,
                DebitAmount = model.DebitAmount,
                CreditAmountOC = model.CreditAmountOC,
                CreditAmount = model.CreditAmount,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                MethodDistributeId = model.MethodDistributeId,
                CashWithdrawTypeId = model.CashWithdrawTypeId,
                AccountingObjectId = model.AccountingObjectId,
                ActivityId = model.ActivityId,
                ProjectId = model.ProjectId,
                TaskId = model.TaskId,
                BankId = model.BankId,
                Approved = model.Approved,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                ProjectActivityId = model.ProjectActivityId,
                ApprovedDate = model.ApprovedDate,
                FundStructureId = model.FundStructureId,
                ProjectActivityEAID = model.ProjectActivityEAID,
                BudgetProvideCode = model.BudgetProvideCode,
                BudgetExpenseId = model.BudgetExpenseId,
                CurrencyCode = model.CurrencyCode,
                ContractId = model.ContractId,
                CapitalPlanId = model.CapitalPlanId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetB03HEntity ToDataTransferObject(FixedAssetB03HModel model)
        {
            return new FixedAssetB03HEntity
            {
                FixedAssetCategoryId = model.FixedAssetCategoryId,
                FixedAssetCategoryCode = model.FixedAssetCategoryCode,
                FixedAssetCategoryName = model.FixedAssetCategoryName,
                ParentId = model.ParentId,
                Unit = model.Unit,
                QuantityOpening = model.QuantityOpening,
                QuantityIncrement = model.QuantityIncrement,
                QuantityDecrement = model.QuantityDecrement,
                QuantityClosing = model.QuantityClosing,
                OrgPriceOpening = model.OrgPriceOpening,
                OrgPriceOpeningUSD = model.OrgPriceOpeningUSD,
                OrgPriceOpeningCurrencyUSD = model.OrgPriceOpeningCurrencyUSD,
                TotalOrgPriceOpeningUSD = model.TotalOrgPriceOpeningUSD,
                OrgPriceIncrement = model.OrgPriceIncrement,
                OrgPriceIncrementUSD = model.OrgPriceIncrementUSD,
                OrgPriceIncrementCurrencyUSD = model.OrgPriceIncrementCurrencyUSD,
                TotalOrgPriceIncrementUSD = model.TotalOrgPriceIncrementUSD,
                OrgPriceDecrement = model.OrgPriceDecrement,
                OrgPriceDecrementUSD = model.OrgPriceDecrementUSD,
                OrgPriceDecrementCurrencyUSD = model.OrgPriceDecrementCurrencyUSD,
                TotalOrgPriceDecrementUSD = model.TotalOrgPriceDecrementUSD,
                OrgPriceClosing = model.OrgPriceClosing,
                OrgPriceClosingUSD = model.OrgPriceClosingUSD,
                OrgPriceClosingCurrencyUSD = model.OrgPriceClosingCurrencyUSD,
                TotalOrgPriceClosingUSD = model.TotalOrgPriceClosingUSD,
                Grade = model.Grade,
                Sort = model.Sort
            };
        }

        /// <summary>
        /// Froms the payment detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetC55aHDEntity FromDataTransferObject(FixedAssetC55aHDModel model)
        {
            if (model == null)
                return null;
            return new FixedAssetC55aHDEntity
            {
                OrderNumber = model.OrderNumber,
                FixedAssetId = model.FixedAssetId,
                FixedAssetName = model.FixedAssetName,
                FixedAssetCategoryCode = model.FixedAssetCategoryCode,
                FixedAssetCategoryName = model.FixedAssetCategoryName,
                YearOfUsing = model.YearOfUsing,
                AddressUsing = model.AddressUsing,
                Unit = model.Unit,
                SerialNumber = model.SerialNumber,
                OrgPrice = model.OrgPrice,
                OrgPriceUSD = model.OrgPriceUSD,
                OrgPriceCurrencyUSD = model.OrgPriceCurrencyUSD,
                TotalOrgPriceUSD = model.TotalOrgPriceUSD,
                AnnualDepreciationAmount = model.AnnualDepreciationAmount,
                RemainigAmount = model.RemainigAmount,
                LifeTime = model.LifeTime,
                AnnualDepreciationRate = model.AnnualDepreciationRate,
                DepreciationYearAmount = model.DepreciationYearAmount,
                DepreciationYearAmountUSD = model.DepreciationYearAmountUSD,
                DepreciationYearAmountCurrencyUSD = model.DepreciationYearAmountCurrencyUSD,
                TotalDepreciationYearAmountUSD = model.TotalDepreciationYearAmountUSD
            };
        }

        /// <summary>
        /// Froms the payment detail data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetFAInventoryEntity FromDataTransferObject(FixedAssetFAInventoryModel model)
        {
            if (model == null)
                return null;
            return new FixedAssetFAInventoryEntity
            {
                OrderNumber = model.OrderNumber,
                FixedAssetCategoryCode = model.FixedAssetCategoryCode,
                FixedAssetId = model.FixedAssetId,
                FixedAssetCode = model.FixedAssetCode,
                FixedAssetName = model.FixedAssetName,
                ParentId = model.ParentId,
                YearOfUsing = model.YearOfUsing,
                Description = model.Description,
                Unit = model.Unit,
                DepreciationRate = model.DepreciationRate,
                SerialNumber = model.SerialNumber,
                CountryProduction = model.CountryProduction,
                Quantity = model.Quantity,
                OrgPrice = model.OrgPrice,
                OrgPriceUsd = model.OrgPriceUsd,
                OrgPriceCurrencyUsd = model.OrgPriceCurrencyUsd,
                TotalOrgPriceUsd = model.TotalOrgPriceUsd,

                QuantityInvetory = model.QuantityInvetory,
                OrgPriceInvetory = model.OrgPriceInvetory,
                OrgPriceCurrencyInvetoryUsd = model.OrgPriceCurrencyInvetoryUsd,
                OrgPriceInvetoryUsd = model.OrgPriceInvetoryUsd,
                TotalOrgPriceInvetoryUsd = model.TotalOrgPriceInvetoryUsd,

                QuantityDifference = model.QuantityDifference,
                OrgPriceDifference = model.OrgPriceDifference,
                OrgPriceCurrencyDifferenceUsd = model.OrgPriceCurrencyDifferenceUsd,
                OrgPriceDifferenceUsd = model.OrgPriceDifferenceUsd,
                TotalOrgPriceDifferenceUsd = model.TotalOrgPriceDifferenceUsd,

                Grade = model.Grade,
                Sort = model.Sort
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static RoleEntity ToDataTransferObject(RoleModel model)
        {
            return new RoleEntity
            {
                RoleId = model.RoleId,
                RoleName = model.RoleName,
                Description = model.Description,
                IsActive = model.IsActive,
                RoleSiteEntities = ToDataTransferObjects(model.RoleSiteModels)
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static SiteEntity ToDataTransferObject(SiteModel model)
        {
            return new SiteEntity
            {
                SiteId = model.SiteId,
                SiteCode = model.SiteCode,
                SiteName = model.SiteName,
                Description = model.Description,
                ParentId = model.ParentId,
                Order = model.Order,
                IsActive = model.IsActive,
                PermissionSiteEntities = ToDataTransferObjects(model.PermissionSiteModels),
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static PermissionEntity ToDataTransferObject(PermissionModel model)
        {
            return new PermissionEntity
            {
                PermissionId = model.PermissionId,
                PermissionCode = model.PermissionCode,
                PermissionName = model.PermissionName,
                Description = model.Description,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static PermissionSiteEntity ToDataTransferObject(PermissionSiteModel model)
        {
            return new PermissionSiteEntity
            {
                PermissionSiteId = model.PermissionSiteId,
                SiteId = model.SiteId,
                PermissionId = model.PermissionId,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static RoleSiteEntity ToDataTransferObject(RoleSiteModel model)
        {
            return new RoleSiteEntity
            {
                RoleSiteId = model.RoleSiteId,
                RoleId = model.RoleId,
                SiteId = model.SiteId,
                PermissionId = model.PermissionId
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static OpeningFixedAssetEntryEntity ToDataTransferObject(OpeningFixedAssetEntryModel model)
        {
            return new OpeningFixedAssetEntryEntity
            {
                RefId = model.RefId,
                RefType = model.RefType,
                PostedDate = model.PostedDate,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                FixedAssetId = model.FixedAssetId,
                DepartmentId = model.DepartmentId,
                BudgetChapterCode = model.BudgetChapterCode,
                OrgPriceAccount = model.OrgPriceAccount,
                OrgPriceDebitAmountOC = model.OrgPriceDebitAmountOC,
                OrgPriceDebitAmount = model.OrgPriceDebitAmount,
                DepreciationAccount = model.DepreciationAccount,
                DepreciationCreditAmountOC = model.DepreciationCreditAmountOC,
                DepreciationCreditAmount = model.DepreciationCreditAmount,
                CapitalAccount = model.CapitalAccount,
                CapitalCreditAmountOC = model.CapitalCreditAmountOC,
                CapitalCreditAmount = model.CapitalCreditAmount,
                SortOrder = model.SortOrder,
                DevaluationCreditAmount = model.DevaluationCreditAmount
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EmployeeLeasingEntity ToDataTransferObject(EmployeeLeasingModel model)
        {
            return new EmployeeLeasingEntity
            {
                EmployeeLeasingId = model.EmployeeLeasingId,
                EmployeeLeasingCode = model.EmployeeLeasingCode,
                EmployeeLeasingName = model.EmployeeLeasingName,
                JobCandidate = model.JobCandidate,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Description = model.Description,
                IsActive = model.IsActive,
                IsLeasing = model.IsLeasing,
                InsurancePrice = model.InsurancePrice,
                SalaryPrice = model.SalaryPrice,
                UniformPrice = model.UniformPrice
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static BuildingEntity ToDataTransferObject(BuildingModel model)
        {
            return new BuildingEntity
            {
                OrderNumber = model.OrderNumber,
                BuildingId = model.BuildingId,
                BuildingCode = model.BuildingCode,
                BuildingName = model.BuildingName,
                JobCandidate = model.JobCandidate,
                Address = model.Address,
                Area = model.Area,
                UnitPrice = model.UnitPrice,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Description = model.Description,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementInfoEntity ToDataTransferObject(EstimateDetailStatementInfoModel model)
        {
            return new EstimateDetailStatementInfoEntity
            {
                EstimateDetailStatementId = model.EstimateDetailStatementId,
                GeneralDescription = model.GeneralDescription,
                EmployeeContractDescription = model.EmployeeContractDescription,
                EmployeeLeasingDescription = model.EmployeeLeasingDescription,
                BuildingOfFixedAssetDescription = model.BuildingOfFixedAssetDescription,
                CarDescription = model.CarDescription,
                DescriptionForBuilding = model.DescriptionForBuilding,
                InventoryDescription = model.InventoryDescription,
                PartC = model.PartC,
                PartC1 = model.PartC1,
                IsActive = model.IsActive,
                Type = model.Type

            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementPartBEntity ToDataTransferObject(EstimateDetailStatementPartBModel model)
        {
            return new EstimateDetailStatementPartBEntity
            {
                EstimateDetailStatementPartBId = model.EstimateDetailStatementPartBId,
                OrderNumber = model.OrderNumber,
                Description = model.Description,
                Amount = model.Amount,
                Note = model.Note,
                IsActive = model.IsActive
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static EstimateDetailStatementFixedAssetEntity ToDataTransferObject(EstimateDetailStatementFixedAssetModel model)
        {
            return new EstimateDetailStatementFixedAssetEntity
            {
                EstimateDetailStatementFixedAssetId = model.EstimateDetailStatementFixedAssetId,
                OrderNumber = model.OrderNumber,
                PurchasedYear = model.PurchasedYear,
                OrgPriceUsd = model.OrgPriceUsd,
                PurchasedOrgPriceUsd = model.PurchasedOrgPriceUsd,
                Department = model.Department,
                ReplacementReason = model.ReplacementReason,
                PostedYear = model.PostedYear,
                IsActive = model.IsActive
            };
        }
        internal static BUPlanWithdrawDetailEntity ToDataTransferObject(BUPlanWithdrawDetailModel model)
        {
            return new BUPlanWithdrawDetailEntity
            {
                RefDetailId = model.RefDetailId,
                RefId = model.RefId,
                Description = model.Description,
                BudgetSourceId = model.BudgetSourceId,
                BudgetChapterCode = model.BudgetChapterCode,
                BudgetKindItemCode = model.BudgetKindItemCode,
                BudgetSubKindItemCode = model.BudgetSubKindItemCode,
                BudgetItemCode = model.BudgetItemCode,
                BudgetSubItemCode = model.BudgetSubItemCode,
                CreditAccount = model.CreditAccount,
                Amount = model.Amount,
                AmountOC = model.AmountOC,
                ProjectId = model.ProjectId,
                ListItemId = model.ListItemId,
                SortOrder = model.SortOrder,
                BudgetDetailItemCode = model.BudgetDetailItemCode,
                OrgRefNo = model.OrgRefNo,
                OrgRefDate = model.OrgRefDate,
                FundStructureId = model.FundStructureId,
                BankId = model.BankId,
                ProjectActivityEAId = model.ProjectActivityEAId,
                BudgetProvideCode = model.BudgetProvideCode,
                BudgetExpenseId = model.BudgetExpenseId,
            };
        }

        internal static BUPlanWithdrawEntity ToDataTransferObject(BUPlanWithdrawModel model)
        {
            return new BUPlanWithdrawEntity
            {
                RefId = model.RefId,
                CashWithDrawType = model.CashWithDrawType,
                RefType = model.RefType,
                RefDate = model.RefDate,
                PostedDate = model.PostedDate,
                RefNo = model.RefNo,
                CurrencyCode = model.CurrencyCode,
                ExchangeRate = model.ExchangeRate,
                ParalellRefNo = model.ParalellRefNo,
                TargetProgramId = model.TargetProgramId,
                BankId = model.BankId,
                AccountingObjectId = model.AccountingObjectId,
                JournalMemo = model.JournalMemo,
                TotalAmount = model.TotalAmount,
                TotalAmountOC = model.TotalAmountOC,
                GeneratedRefId = model.GeneratedRefId,
                Posted = model.Posted,
                BUCommitmentRequestId = model.BUCommitmentRequestId,
                BUPlanWithdrawDetails = ToDataTransferObjects(model.BUPlanWithdrawDetails),
                AccountingObjectBankId = model.AccountingObjectBankId
            };
        }

        internal static FixedAssetDetailAccessoryEntity ToDataTransferObject(FixedAssetDetailAccessoryModel model)
        {
            return new FixedAssetDetailAccessoryEntity
            {
                FixedAssetDetailAccessoryId = model.FixedAssetDetailAccessoryId,
                FixedAssetId = model.FixedAssetId,
                Description = model.Description,
                Unit = model.Unit,
                Quantity = model.Quantity,
                Amount = model.Amount,
                SortOrder = model.SortOrder
            };
        }
        internal static AudittingLogEntity ToDataTransferObjectAu(AudittingLogModel model)
        {
            return new AudittingLogEntity
            {
                EventAction = model.EventAction,
                ComputerName = model.ComputerName,
                Amount = model.Amount,
                ComponentName = model.ComponentName,
                EventTime = model.EventTime,
                LoginName = model.LoginName,
                Reference = model.Reference,
                EventId = model.EventId
            };
        }

        #endregion

        #region ToDataTransferObjects

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FeatureEntity> ToDataTransferObjects(IList<FeaturesModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        internal static List<ContractDetailEntity> ToDataTransferObjects(List<ContractDetailsModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        internal static IList<UserFeaturePermisionEntity> ToDataTransferObjects(IList<UserFeaturePermisionModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        internal static IList<FeaturePermisionEntity> ToDataTransferObjects(IList<FeaturePermisionModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BUVoucherListEntity> ToDataTransferObjects(IList<BUVoucherListModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BUVoucherListDetailEntity> ToDataTransferObjects(IList<BUVoucherListDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BUVoucherListDetailParallelEntity> ToDataTransferObjects(IList<BUVoucherListDetailParallelModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BUVoucherListDetailTransferEntity> ToDataTransferObjects(IList<BUVoucherListDetailTransferModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FAIncrementDecrementEntity> ToDataTransferObjects(IList<FAIncrementDecrementModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        internal static IList<BUPlanWithdrawEntity> ToDataTransferObjects(IList<BUPlanWithdrawModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        internal static IList<BUPlanWithdrawDetailEntity> ToDataTransferObjects(IList<BUPlanWithdrawDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FAIncrementDecrementDetailEntity> ToDataTransferObjects(IList<FAIncrementDecrementDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BudgetProvidenceEntity> ToDataTransferObjects(IList<BudgetProvidenceModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<SUIncrementDecrementEntity> ToDataTransferObjects(IList<SUIncrementDecrementModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<SUTransferEntity> ToDataTransferObjects(IList<SUTransferModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<SUTransferDetailEntity> ToDataTransferObjects(IList<SUTransferDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FADepreciationEntity> ToDataTransferObjects(IList<FADepreciationModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FADepreciationDetailEntity> ToDataTransferObjects(IList<FADepreciationDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<SUIncrementDecrementDetailEntity> ToDataTransferObjects(IList<SUIncrementDecrementDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BAWithDrawEntity> ToDataTransferObjects(IList<BAWithDrawModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BAWithDrawDetailEntity> ToDataTransferObjects(IList<BAWithDrawDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BAWithDrawDetailFixedAssetEntity> ToDataTransferObjects(IList<BAWithDrawDetailFixedAssetModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BAWithDrawDetailPurchaseEntity> ToDataTransferObjects(IList<BAWithDrawDetailPurchaseModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BAWithdrawDetailSalaryEntity> ToDataTransferObjects(IList<BAWithdrawDetailSalaryModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BAWithdrawDetailTaxEntity> ToDataTransferObjects(IList<BAWithdrawDetailTaxModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;SalaryVoucherEntity&gt;.</returns>
        internal static IList<SalaryVoucherEntity> ToDataTransferObjects(IList<SalaryVoucherModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;INInwardOutwardDetailEntity&gt;.</returns>
        internal static IList<INInwardOutwardDetailEntity> ToDataTransferObjects(IList<INInwardOutwardDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;INInwardOutwardDetailEntity&gt;.</returns>
        internal static IList<INInwardOutwardDetailParallelEntity> ToDataTransferObjects(IList<INInwardOutwardDetailParallelModel> models)
        {
            if (models == null)
                return null;
            return models.Select(FromDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BADepositEntity> ToDataTransferObjects(IList<BADepositModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BADepositDetailEntity> ToDataTransferObjects(IList<BADepositDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BADepositDetailTaxEntity> ToDataTransferObjects(IList<BADepositDetailTaxModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BADepositDetailSaleEntity> ToDataTransferObjects(IList<BADepositDetailSaleModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BADepositDetailFixedAssetEntity> ToDataTransferObjects(IList<BADepositDetailFixedAssetModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        internal static IList<BABankTransferDetailEntity> ToDataTransferObjects(IList<BABankTransferDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        internal static IList<BABankTransferEntity> ToDataTransferObjects(IList<BABankTransferModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;BUCommitmentRequestEntity&gt;.</returns>
        internal static IList<BUCommitmentRequestEntity> ToDataTransferObjects(IList<BUCommitmentRequestModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;BUCommitmentRequestDetailEntity&gt;.</returns>
        internal static IList<BUCommitmentRequestDetailEntity> ToDataTransferObjects(IList<BUCommitmentRequestDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;BUCommitmentAdjustmentEntity&gt;.</returns>
        internal static IList<BUCommitmentAdjustmentEntity> ToDataTransferObjects(IList<BUCommitmentAdjustmentModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;BUCommitmentAdjustmentDetailEntity&gt;.</returns>
        internal static IList<BUCommitmentAdjustmentDetailEntity> ToDataTransferObjects(IList<BUCommitmentAdjustmentDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;OpeningCommitmentEntity&gt;.</returns>
        internal static IList<OpeningCommitmentEntity> ToDataTransferObjects(IList<OpeningCommitmentModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;OpeningCommitmentDetailEntity&gt;.</returns>
        internal static IList<OpeningCommitmentDetailEntity> ToDataTransferObjects(IList<OpeningCommitmentDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;OpeningSupplyEntryEntity&gt;.</returns>
        internal static IList<OpeningSupplyEntryEntity> ToDataTransferObjects(IList<OpeningSupplyEntryModel> models)
        {
            if (models == null)
                return null;
            return models.Select(m => AutoMapper(m, new OpeningSupplyEntryEntity())).ToList();
        }
        internal static IList<BUTransferEntity> ToDataTransferObjects(IList<BUTransferModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        internal static IList<BUTransferDetailEntity> ToDataTransferObjects(IList<BUTransferDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<PurchasePurposeEntity> ToDataTransferObjects(IList<PurchasePurposeModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<RefTypeEntity> ToDataTransferObjects(IList<RefTypeModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        internal static IList<AutoNumberListEntity> ToDataTransferObjects(IList<AutoNumberListModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        internal static IList<MutualEntity> ToDataTransferObjects(IList<MutualModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<OpeningInventoryEntryEntity> ToDataTransferObjects(IList<OpeningInventoryEntryModel> models)
        {
            if (models == null)
                return null;

            return models.Select(m => AutoMapper(m, new OpeningInventoryEntryEntity())).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<AutoIDEntity> ToDataTransferObjects(IList<AutoIDModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<EmployeeEntity> ToDataTransferObjects(IList<EmployeeModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<SalaryEntity> ToDataTransferObjects(IList<SalaryModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<EmployeeTypeEntity> ToDataTransferObjects(IList<EmployeeTypeModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<CapitalAllocateEntity> ToDataTransferObjects(IList<CapitalAllocateModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the general voucher detail data transfer object.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<GeneralDetailEntity> ToGeneralVoucherDetailDataTransferObject(IList<GeneralVoucherDetailModel> entities)
        {
            return entities == null ? null : entities.Select(ToGeneralVoucherDetailDataTransferObject).ToList();
        }

        /// <summary>
        /// To the general data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<GeneralDetailEntity> ToGeneralDataTransferObjects(IList<GeneralVoucherDetailModel> entities)
        {
            if (entities == null)
                return null;

            return entities.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<CustomerEntity> ToDataTransferObjects(IList<CustomerModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<VoucherListEntity> ToDataTransferObjects(IList<VoucherListModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<InvoiceFormNumberEntity> ToDataTransferObjects(IList<InvoiceFormNumberModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountCategoryEntity> ToDataTransferObjects(IList<AccountCategoryModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<AccountTransferEntity> ToDataTransferObjects(IList<AccountTransferModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }



        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<StockEntity> ToDataTransferObjects(IList<StockModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<InventoryItemEntity> ToDataTransferObjects(IList<InventoryItemModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        internal static IList<InventoryItemCategoryEntity> ToDataTransferObjects(IList<InventoryItemCategoryModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<EmployeePayItemEntity> ToDataTransferObjects(IList<EmployeePayItemModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<PlanTemplateItemEntity> ToDataTransferObjects(IList<PlanTemplateItemModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        ///// <summary>
        ///// To the data transfer objects.
        ///// </summary>
        ///// <param name="models">The models.</param>
        ///// <returns>
        ///// IList{DepositEntity}.
        ///// </returns>
        //internal static IList<DepositEntity> ToDataTransferObjects(IList<DepositModel> models)
        //{
        //    if (models == null)
        //        return null;
        //    return models.Select(ToDataTransferObject).ToList();
        //}

        ///// <summary>
        ///// To the data transfer objects.
        ///// </summary>
        ///// <param name="models">The models.</param>
        ///// <returns>
        ///// IList{DepositDetailEntity}.
        ///// </returns>
        //internal static IList<DepositDetailEntity> ToDataTransferObjects(IList<DepositDetailModel> models)
        //{
        //    if (models == null)
        //        return null;
        //    return models.Select(ToDataTransferObject).ToList();
        //}

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;CAReceiptDetailEntity&gt;.</returns>
        internal static IList<CAReceiptDetailEntity> ToDataTransferObjects(IList<CAReceiptDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;CAReceiptDetailTaxEntity&gt;.</returns>
        internal static IList<CAReceiptDetailTaxEntity> ToDataTransferObjects(IList<CAReceiptDetailTaxModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;CAReceiptDetailParallelEntity&gt;.</returns>
        internal static IList<CAReceiptDetailParallelEntity> ToDataTransferObjects(IList<CAReceiptDetailParallelModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;CAPaymentDetailEntity&gt;.</returns>
        internal static IList<CAPaymentDetailEntity> ToDataTransferObjects(IList<CAPaymentDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data tranfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;CAPaymentDetailTaxEntity&gt;.</returns>
        internal static IList<CAPaymentDetailTaxEntity> ToDataTranferObjects(IList<CAPaymentDetailTaxModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data tranfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;CAPaymentDetailPurchaseEntity&gt;.</returns>
        internal static IList<CAPaymentDetailPurchaseEntity> ToDataTranferObjects(IList<CAPaymentDetailPurchaseModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data tranfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;CAPaymentDetailFixedAssetEntity&gt;.</returns>
        internal static IList<CAPaymentDetailFixedAssetEntity> ToDataTranferObjects(IList<CAPaymentDetailFixedAssetModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data tranfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;CAPaymentDetailParallelEntity&gt;.</returns>
        internal static IList<CAPaymentDetailParallelEntity> ToDataTranferObjects(IList<CAPaymentDetailParallelModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data tranfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;BADepositDetailParallelEntity&gt;.</returns>
        internal static IList<BADepositDetailParallelEntity> ToDataTransferObjects(IList<BADepositDetailParallelModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;BAWithDrawDetailParallelEntity&gt;.</returns>
        internal static IList<BAWithDrawDetailParallelEntity> ToDataTransferObjects(IList<BAWithDrawDetailParallelModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }

        internal static IList<BUTransferDetailParallelEntity> ToDataTransferObjects(IList<BUTransferDetailParallelModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;BABankTransferDetailParallelEntity&gt;.</returns>
        internal static IList<BABankTransferDetailParallelEntity> ToDataTransferObjects(IList<BABankTransferDetailParallelModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;CAPaymentModel&gt;.</returns>
        internal static IList<CAPaymentModel> ToDataTransferObjects(IList<CAPaymentModel> models)
        {
            //if (models == null)
            //    return null;
            //return models.Select(ToDataTransferObject).ToList();
            return null;
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BUPlanReceiptEntity> ToDataTransferObjects(IList<BUPlanReceiptModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BUPlanReceiptDetailEntity> ToDataTransferObjects(IList<BUPlanReceiptDetailModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }

        internal static IList<BUPlanAdjustmentEntity> ToDataTransferObjects(IList<BUPlanAdjustmentModel> models)
        {
            if (models == null)
            {
                return null;
            }
            return models.Select(ToDataTransferObject).ToList();
        }

        internal static IList<BUPlanAdjustmentDetailEntity> ToDataTransferObjects(IList<BUPlanAdjustmentDetailModel> models)
        {
            if (models == null)
            {
                return null;
            }
            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BUBudgetReserveEntity> ToDataTransferObjects(IList<BUBudgetReserveModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<BUBudgetReserveDetailEntity> ToDataTransferObjects(IList<BUBudgetReserveDetailModel> models)
        {
            if (models == null)
            { return null; }
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<GLVoucherEntity> ToDataTransferObjects(IList<GLVoucherModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<GLVoucherDetailEntity> ToDataTransferObjects(IList<GLVoucherDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;GLVoucherDetailParallelEntity&gt;.</returns>
        internal static IList<GLVoucherDetailParallelEntity> ToDataTransferObjects(IList<GLVoucherDetailParallelModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<GLVoucherDetailTaxEntity> ToDataTransferObjects(IList<GLVoucherDetailTaxModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        internal static IList<GLVoucherListEntity> ToDataTransferObjects(IList<GLVoucherListModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        internal static IList<GLVoucherListDetailEntity> ToDataTransferObjects(IList<GLVoucherListDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        internal static IList<GLPaymentListDetailEntity> ToDataTransferObjects(IList<GLPaymentListDetailModel> models)
        {
            if (models == null)
                return null;
            return models.Select(ToDataTransferObject).ToList();
        }
        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The entities.</param>
        /// <returns></returns>
        internal static IList<DBOptionEntity> ToDataTransferObjects(IList<DBOptionModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FAArmortizationDetailEntity> ToDataTransferObjects(IList<FixedAssetArmortizationDetailModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FADecrementDetailEntity> ToDataTransferObjects(IList<FixedAssetDecrementDetailModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FAIncrementDetailEntity> ToDataTransferObjects(IList<FixedAssetIncrementDetailModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FixedAssetCurrencyEntity> ToDataTransferObjects(IList<FixedAssetCurrencyModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FAIncrementEntity> ToDataTransferObjects(IList<FixedAssetIncrementModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<FADecrementEntity> ToDataTransferObjects(IList<FixedAssetDecrementModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<OpeningAccountEntryDetailEntity> ToDataTransferObjects(IList<OpeningAccountEntryDetailModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<GeneralVoucherDetailModel> ToDataTransferObjects(List<GeneralDetailEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the general voucher detail data transfer objects.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        internal static List<GeneralVoucherDetailModel> ToGeneralVoucherDetailDataTransferObjects(List<GeneralDetailEntity> entities)
        {
            if (entities == null)
                return null;
            return entities.Select(ToGeneralDetailDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<PermissionEntity> ToDataTransferObjects(IList<PermissionModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<PermissionSiteEntity> ToDataTransferObjects(IList<PermissionSiteModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<RoleSiteEntity> ToDataTransferObjects(IList<RoleSiteModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<OpeningFixedAssetEntryEntity> ToDataTransferObjects(IList<OpeningFixedAssetEntryModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementInfoEntity> ToDataTransferObjects(IList<EstimateDetailStatementInfoModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementPartBEntity> ToDataTransferObjects(IList<EstimateDetailStatementPartBModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns></returns>
        internal static IList<EstimateDetailStatementFixedAssetEntity> ToDataTransferObjects(IList<EstimateDetailStatementFixedAssetModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }
        #endregion

        #region Report Mapper
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static FixedAssetHousingReportModel FromDataTransferObject(FixedAssetHousingReportEntity entity)
        {
            if (entity == null)
                return null;

            return new FixedAssetHousingReportModel
            {
                FixedAssetHousingReportId = entity.FixedAssetHousingReportId,
                AreaOfBuilding = entity.AreaOfBuilding,
                WorkingArea = entity.WorkingArea,
                HousingArea = entity.HousingArea,
                GuestHouseArea = entity.GuestHouseArea,
                OccupiedArea = entity.OccupiedArea,
                OtherArea = entity.OtherArea,
                AccountingValue = entity.AccountingValue,
                Attachments = entity.Attachments
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static AccountingVoucherModel FromDataTransferObject(AccountingVoucherEntity entity)
        {
            if (entity == null)
                return null;

            return new AccountingVoucherModel
            {
                CurrencyCode = entity.CurrencyCode,
                PostedDate = entity.PostedDate,
                RefDate = entity.RefDate,
                RefNo = entity.RefNo,
                Description = entity.Description,
                AccountNumber = entity.AccountNumber,
                CorrespondingAccountNumber = entity.CorrespondingAccountNumber,
                OrderNumber = entity.OrderNumber,
                //AmountOC = entity.AmountOC,
            };
        }

        /// <summary>
        /// To the data transfer object.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        internal static FixedAssetHousingReportEntity ToDataTransferObject(FixedAssetHousingReportModel model)
        {
            return new FixedAssetHousingReportEntity
            {
                FixedAssetHousingReportId = model.FixedAssetHousingReportId,
                AreaOfBuilding = model.AreaOfBuilding,
                WorkingArea = model.WorkingArea,
                HousingArea = model.HousingArea,
                GuestHouseArea = model.GuestHouseArea,
                OccupiedArea = model.OccupiedArea,
                OtherArea = model.OtherArea,
                AccountingValue = model.AccountingValue,
                Attachments = model.Attachments
            };
        }

        /// <summary>
        /// To the data transfer objects.
        /// </summary>
        /// <param name="models">The models.</param>
        /// <returns>IList&lt;FixedAssetHousingReportEntity&gt;.</returns>
        internal static IList<FixedAssetHousingReportEntity> ToDataTransferObjects(IList<FixedAssetHousingReportModel> models)
        {
            if (models == null)
                return null;

            return models.Select(ToDataTransferObject).ToList();
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>MinutesInventoryToolModel.</returns>
        internal static MinutesInventoryToolModel FromDataTransferObject(MinutesInventoryToolEntity entity)
        {
            if (entity == null)
                return null;

            return new MinutesInventoryToolModel
            {

                DepartmentName = entity.DepartmentName,
                InventoryCategoryName = entity.InventoryCategoryName,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemName = entity.InventoryItemName,
                AmountBook = entity.AmountBook,
                AmountMinutes = entity.AmountMinutes,
                DepartmentId = entity.DepartmentId,
                InventoryCategoryId = entity.InventoryCategoryId,
                InventoryItemId = entity.InventoryItemId,
                QuantityBook = entity.QuantityBook,
                QuantityMinutes = entity.QuantityMinutes,
                SumInventoryCategory = entity.SumInventoryCategory
            };
        }

        internal static ToolIncrementDecrementModel FromDataTransferObject(ToolIncrementDecrementEntity entity)
        {
            if (entity == null)
                return null;
            return new ToolIncrementDecrementModel
            {
                InventoryItemId = entity.InventoryItemId,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemName = entity.InventoryItemName,
                Unit = entity.Unit,
                DepartmentId = entity.DepartmentId,
                DepartmentName = entity.DepartmentName,
                InventoryCategoryId = entity.InventoryCategoryId,
                InventoryCategoryName = entity.InventoryCategoryName,
                OPeningQuantity = entity.OPeningQuantity,
                OPeningAmount = entity.OPeningAmount,
                IncreaseQuantity = entity.IncreaseQuantity,
                IncreaseAmount = entity.IncreaseAmount,
                DecreaseQuantity = entity.DecreaseQuantity,
                DecreaseAmount = entity.DecreaseAmount,
                ClosingQuantity = entity.ClosingQuantity,
                ClosingAmount = entity.ClosingAmount,
                Stt = entity.Stt
            };
        }

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>S22HModel.</returns>
        internal static InventoryBookModel FromDataTransferObject(InventoryBookEntity entity)
        {
            if (entity == null)
                return null;

            return new InventoryBookModel
            {
                StockId = entity.StockId,
                InventoryItemId = entity.InventoryItemId,
                OpeningQuantity = entity.OpeningQuantity,
                OpeningAmount = entity.OpeningAmount,
                InwardQuantity = entity.InwardQuantity,
                InwardAmount = entity.InwardAmount,
                OutwardQuantity = entity.OutwardQuantity,
                OutwardAmount = entity.OutwardAmount,
                ClosingQuantity = entity.ClosingQuantity,
                ClosingAmount = entity.ClosingAmount,
                StockCode = entity.StockCode,
                StockName = entity.StockName,
                InventoryCategoryId = entity.InventoryCategoryId,
                InventoryCategoryCode = entity.InventoryCategoryCode,
                InventoryCategoryName = entity.InventoryCategoryName,
                InventoryItemCode = entity.InventoryItemCode,
                InventoryItemName = entity.InventoryItemName,
                Unit = entity.Unit
            };
        }

        #region Cash

        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        internal static UserProfileModel FromDataTransferObject(UserProfileEntity entity)
        {
            if (entity == null)
                return null;

            return new UserProfileModel
            {
                Description = entity.Description,
                IsActive = entity.IsActive,
                UserProfileId = entity.UserProfileId,
                FullName = entity.FullName,
                IsSystem = entity.IsSystem,
                JobTitle = entity.JobTitle,
                UserName = entity.UserName
            };
        }

        // Bảng xác nhận số dư tài khoản tiền gửi tại KBNNFixedAssetB03HModel
        #endregion
        /// <summary>
        /// Froms the data transfer object.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>CashInBankConfirmationBalanceSheetModel.</returns>
        internal static CashInBankConfirmationBalanceSheetModel FromDataTransferObject(CashInBankConfirmationBalanceSheetEntity entity)
        {
            if (entity == null)
                return null;

            return new CashInBankConfirmationBalanceSheetModel
            {
                BankAccount = entity.BankAccount,
                BankDistributionCode = entity.BankDistributionCode,
                ClosingBalance = entity.ClosingBalance,
                ClosingBalance112 = entity.ClosingBalance112,
                MovementCredit112 = entity.MovementCredit112,
                MovementCreditAmount = entity.MovementCreditAmount,
                MovementDebit112 = entity.MovementDebit112,
                MovementDebitAmount = entity.MovementDebitAmount,
                OpeningBalance = entity.OpeningBalance,
                OpenningBalance112 = entity.OpenningBalance112,
                ProjectCode = entity.ProjectCode,
                ProjectId = entity.ProjectId
            };
        }

        public static TTarget AutoMapper<TSource, TTarget>(TSource aSource, TTarget aTarget)
        {
            if (aSource == null)
                return aTarget;

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var srcFields = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                             where aProp.CanRead
                             select new
                             {
                                 Name = aProp.Name,
                                 Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
                             }).ToList();
            var trgFields = (from PropertyInfo aProp in aTarget.GetType().GetProperties(flags)
                             where aProp.CanWrite
                             select new
                             {
                                 Name = aProp.Name,
                                 Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
                             }).ToList();

            var commonFields = srcFields.Intersect(trgFields).ToList();

            foreach (var aField in commonFields)
            {
                var value = aSource.GetType().GetProperty(aField.Name).GetValue(aSource, null);
                PropertyInfo propertyInfos = aTarget.GetType().GetProperty(aField.Name);
                propertyInfos.SetValue(aTarget, value, null);
            }
            return aTarget;
        }
        #endregion
    }
}