/***********************************************************************
 * <copyright file="buvoucherlistfacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, June 5, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using BuCA.Enum;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Estimate
{
    /// <summary>
    ///     BUVoucherListFacade
    /// </summary>
    public class BUVoucherListFacade
    {
        /// <summary>
        ///     The bu voucher list DAO
        /// </summary>
        private static readonly IBUVoucherListDao BUVoucherListDao = DataAccess.DataAccess.BUVoucherListDao;

        /// <summary>
        ///     The bu voucher list detail DAO
        /// </summary>
        private static readonly IBUVoucherListDetailDao BUVoucherListDetailDao =
            DataAccess.DataAccess.BUVoucherListDetailDao;

        /// <summary>
        ///     The bu voucher list detail parallel DAO
        /// </summary>
        private static readonly IBUVoucherListDetailParallelDao BUVoucherListDetailParallelDao =
            DataAccess.DataAccess.BUVoucherListDetailParallelDao;

        /// <summary>
        ///     The account balance DAO
        /// </summary>
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;

        /// <summary>
        ///     The general ledger DAO
        /// </summary>
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;

        /// <summary>
        ///     The original general ledger DAO
        /// </summary>
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao =
            DataAccess.DataAccess.OriginalGeneralLedgerDao;

        /// <summary>
        ///     The bu voucher list detail transfer DAO
        /// </summary>
        private static readonly IBUVoucherListDetailTransferDao BUVoucherListDetailTransferDao =
            DataAccess.DataAccess.BUVoucherListDetailTransferDao;

        /// <summary>
        /// Gets the bu voucher list entity.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="includeDetail">if set to <c>true</c> [include detail].</param>
        /// <param name="includeDetailParallel">if set to <c>true</c> [include detail parallel].</param>
        /// <param name="includeDetailTransfer">if set to <c>true</c> [include detail transfer].</param>
        /// <returns></returns>
        public BUVoucherListEntity GetBUVoucherListEntity(string refId,
            bool includeDetail, bool includeDetailParallel, bool includeDetailTransfer)
        {
            var bUVoucherList = BUVoucherListDao.GetBUVoucherListByRefId(refId);
            if (bUVoucherList != null)
            {
                if (includeDetail)
                {
                    bUVoucherList.BUVoucherListDetailEntities =
                        BUVoucherListDetailDao.GetBUVoucherListDetailbyRefId(bUVoucherList.RefId);
                    var voucherList = bUVoucherList.BUVoucherListDetailEntities.ToList();
                }
                if (includeDetailParallel)
                    bUVoucherList.BUVoucherListDetailParallelEntities =
                        BUVoucherListDetailParallelDao.GetBUVoucherListDetailParallelByRefId(bUVoucherList.RefId);
                if (includeDetailTransfer)
                    bUVoucherList.BUVoucherListDetailTransferEntities =
                        BUVoucherListDetailTransferDao.GetBUVoucherListDetailTransferByRefId(bUVoucherList.RefId);
            }
            return bUVoucherList;
        }

        /// <summary>
        /// Gets the bu voucher list by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        public BUVoucherListEntity GetBUVoucherListByRefNo(string refNo)
        {
            return BUVoucherListDao.GetBUVoucherListByRefNo(refNo);
        }

        /// <summary>
        ///     Gets the bu voucher list entities.
        /// </summary>
        /// <returns></returns>
        public IList<BUVoucherListEntity> GetBUVoucherListEntities()
        {
            return BUVoucherListDao.GetBUVoucherList();
        }

        /// <summary>
        /// Gets the bu voucher list entities by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public IList<BUVoucherListEntity> GetBUVoucherListEntitiesByRefTypeId(int refTypeId)
        {
            return BUVoucherListDao.GetBUVoucherListsByRefTypeId(refTypeId);
        }

        /// <summary>
        ///     Inserts the bu voucher list.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u voucher list entity.</param>
        /// <returns></returns>
        public BUVoucherListResponse InsertBUVoucherList(BUVoucherListEntity bUVoucherListEntity)
        {
            var bUVoucherListResponse = new BUVoucherListResponse { Acknowledge = AcknowledgeType.Success };
            if (bUVoucherListEntity != null && !bUVoucherListEntity.Validate())
            {
                foreach (var error in bUVoucherListEntity.ValidationErrors)
                    bUVoucherListResponse.Message += error + Environment.NewLine;
                bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                return bUVoucherListResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (bUVoucherListEntity != null)
                {
                    var bUVoucherListByRefNo =
                        BUVoucherListDao.GetBUVoucherListByRefNo(bUVoucherListEntity.RefNo,
                            bUVoucherListEntity.PostedDate);
                    if (bUVoucherListByRefNo != null && bUVoucherListByRefNo.PostedDate.Year == bUVoucherListEntity.PostedDate.Year)
                    {
                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                        bUVoucherListResponse.Message =
                            string.Format("Số chứng từ \'{0}\' đã tồn tại!", bUVoucherListEntity.RefNo);
                        return bUVoucherListResponse;
                    }

                    bUVoucherListEntity.RefId = Guid.NewGuid().ToString();
                    bUVoucherListResponse.Message = BUVoucherListDao.InsertBUVoucherList(bUVoucherListEntity);

                    if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                    {
                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUVoucherListResponse;
                    }

                    #region Insert bUVoucherListDetailEntity

                    if (bUVoucherListEntity.BUVoucherListDetailEntities != null)
                        foreach (var bUVoucherListDetailEntity in bUVoucherListEntity.BUVoucherListDetailEntities)
                        {
                            bUVoucherListDetailEntity.RefId = bUVoucherListEntity.RefId;
                            bUVoucherListDetailEntity.RefDetailId = Guid.NewGuid().ToString();
                            if (!bUVoucherListDetailEntity.Validate())
                            {
                                foreach (var error in bUVoucherListDetailEntity.ValidationErrors)
                                    bUVoucherListResponse.Message += error + Environment.NewLine;
                                bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUVoucherListResponse;
                            }
                            bUVoucherListResponse.Message =
                                BUVoucherListDetailDao.InsertBUVoucherListDetail(bUVoucherListDetailEntity);
                            if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                            {
                                bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUVoucherListResponse;
                            }
                        }

                    #endregion

                    if (bUVoucherListEntity.RefType != (int)BuCA.Enum.RefType.BUCashBasicVoucherList)
                    {
                        #region insert bUVoucherListDetailTransfer

                        if (bUVoucherListEntity.BUVoucherListDetailTransferEntities != null)
                            foreach (var bUVoucherListDetailTransfer in bUVoucherListEntity
                                .BUVoucherListDetailTransferEntities)
                            {
                                bUVoucherListDetailTransfer.RefId = bUVoucherListEntity.RefId;
                                bUVoucherListDetailTransfer.RefDetailId = Guid.NewGuid().ToString();
                                if (!bUVoucherListDetailTransfer.Validate())
                                {
                                    foreach (var error in bUVoucherListDetailTransfer.ValidationErrors)
                                        bUVoucherListResponse.Message += error + Environment.NewLine;
                                    bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bUVoucherListResponse;
                                }
                                bUVoucherListResponse.Message =
                                    BUVoucherListDetailTransferDao.InsertBUVoucherListDetailTransfer(
                                        bUVoucherListDetailTransfer);
                                if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                                {
                                    bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bUVoucherListResponse;
                                }

                                //#region Insert to AccountBalance

                                //InsertAccountBalance(bUVoucherListEntity, bUVoucherListDetailTransfer);

                                //#endregion

                                #region Insert GeneralLedger

                                if (bUVoucherListDetailTransfer.DebitAccount != null && bUVoucherListDetailTransfer.CreditAccount != null)
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = bUVoucherListEntity.RefType,
                                        RefNo = bUVoucherListEntity.RefNo,
                                        AccountingObjectId = bUVoucherListDetailTransfer.AccountingObjectId,
                                        //BankId = bUTransfer.BankId,
                                        BudgetChapterCode = bUVoucherListDetailTransfer.BudgetChapterCode,
                                        ProjectId = bUVoucherListDetailTransfer.ProjectId,
                                        BudgetSourceId = bUVoucherListDetailTransfer.BudgetSourceId,
                                        Description = bUVoucherListDetailTransfer.Description,
                                        RefDetailId = bUVoucherListDetailTransfer.RefDetailId,
                                        ExchangeRate = bUVoucherListDetailTransfer.ExchangeRate,
                                        ActivityId = bUVoucherListDetailTransfer.ActivityId,
                                        BudgetSubKindItemCode = bUVoucherListDetailTransfer.BudgetSubKindItemCode,
                                        CurrencyCode = bUVoucherListDetailTransfer.CurrencyCode,
                                        BudgetKindItemCode = bUVoucherListDetailTransfer.BudgetKindItemCode,
                                        RefId = bUVoucherListEntity.RefId,
                                        PostedDate = bUVoucherListEntity.PostedDate,
                                        MethodDistributeId = bUVoucherListDetailTransfer.MethodDistributeId,
                                        //OrgRefNo = bUVoucherListDetailTransfer.OrgRefNo,
                                        //OrgRefDate = bUVoucherListDetailTransfer.OrgRefDate,
                                        BudgetItemCode = bUVoucherListDetailTransfer.BudgetItemCode,
                                        ListItemId = bUVoucherListDetailTransfer.ListItemId,
                                        BudgetSubItemCode = bUVoucherListDetailTransfer.BudgetSubItemCode,
                                        BudgetDetailItemCode = bUVoucherListDetailTransfer.BudgetDetailItemCode,
                                        CashWithDrawTypeId = bUVoucherListDetailTransfer.CashWithDrawTypeId,
                                        AccountNumber = bUVoucherListDetailTransfer.DebitAccount,
                                        CorrespondingAccountNumber = bUVoucherListDetailTransfer.CreditAccount,
                                        DebitAmount = bUVoucherListDetailTransfer.Amount,
                                        DebitAmountOC = bUVoucherListDetailTransfer.AmountOC ?? 0,
                                        CreditAmount = 0,
                                        CreditAmountOC = 0,
                                        FundStructureId = bUVoucherListDetailTransfer.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = bUVoucherListEntity.JournalMemo,
                                        RefDate = bUVoucherListEntity.RefDate
                                    };
                                    bUVoucherListResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                                    {
                                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUVoucherListResponse;
                                    }

                                    //insert lan 2
                                    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                    generalLedgerEntity.AccountNumber = bUVoucherListDetailTransfer.CreditAccount;
                                    generalLedgerEntity.CorrespondingAccountNumber = bUVoucherListDetailTransfer.DebitAccount;
                                    generalLedgerEntity.DebitAmount = 0;
                                    generalLedgerEntity.DebitAmountOC = 0;
                                    generalLedgerEntity.CreditAmount = bUVoucherListDetailTransfer.Amount;
                                    //generalLedgerEntity.CreditAmountOC = bUTransferDetail.AmountOC;
                                    bUVoucherListResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                }
                                else //ghi don
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = bUVoucherListEntity.RefType,
                                        RefNo = bUVoucherListEntity.RefNo,
                                        AccountingObjectId = bUVoucherListDetailTransfer.AccountingObjectId,
                                        BudgetChapterCode = bUVoucherListDetailTransfer.BudgetChapterCode,
                                        ProjectId = bUVoucherListDetailTransfer.ProjectId,
                                        BudgetSourceId = bUVoucherListDetailTransfer.BudgetSourceId,
                                        Description = bUVoucherListDetailTransfer.Description,
                                        RefDetailId = bUVoucherListDetailTransfer.RefDetailId,
                                        ActivityId = bUVoucherListDetailTransfer.ActivityId,
                                        BudgetSubKindItemCode = bUVoucherListDetailTransfer.BudgetSubKindItemCode,
                                        BudgetKindItemCode = bUVoucherListDetailTransfer.BudgetKindItemCode,
                                        RefId = bUVoucherListEntity.RefId,
                                        PostedDate = bUVoucherListEntity.PostedDate,
                                        MethodDistributeId = bUVoucherListDetailTransfer.MethodDistributeId,
                                        BudgetItemCode = bUVoucherListDetailTransfer.BudgetItemCode,
                                        ListItemId = bUVoucherListDetailTransfer.ListItemId,
                                        BudgetSubItemCode = bUVoucherListDetailTransfer.BudgetSubItemCode,
                                        BudgetDetailItemCode = bUVoucherListDetailTransfer.BudgetDetailItemCode,
                                        CashWithDrawTypeId = bUVoucherListDetailTransfer.CashWithDrawTypeId,
                                        AccountNumber = bUVoucherListDetailTransfer.DebitAccount ?? bUVoucherListDetailTransfer.CreditAccount,
                                        DebitAmount = bUVoucherListDetailTransfer.DebitAccount == null ? 0 : bUVoucherListDetailTransfer.Amount,
                                        DebitAmountOC = bUVoucherListDetailTransfer.DebitAccount == null ? 0 : bUVoucherListDetailTransfer.Amount,
                                        CreditAmount = bUVoucherListDetailTransfer.CreditAccount == null ? 0 : bUVoucherListDetailTransfer.Amount,
                                        CreditAmountOC = bUVoucherListDetailTransfer.CreditAccount == null ? 0 : bUVoucherListDetailTransfer.Amount,
                                        FundStructureId = bUVoucherListDetailTransfer.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = bUVoucherListEntity.JournalMemo,
                                        RefDate = bUVoucherListEntity.RefDate,
                                        SortOrder = bUVoucherListDetailTransfer.SortOrder
                                    };
                                    bUVoucherListResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                                    {
                                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUVoucherListResponse;
                                    }
                                }

                                #endregion

                                #region Insert OriginalGeneralLedger

                                var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                {
                                    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                    RefType = bUVoucherListEntity.RefType,
                                    RefId = bUVoucherListEntity.RefId,
                                    RefDetailId = bUVoucherListDetailTransfer.RefDetailId,
                                    //OrgRefDate = bUVoucherListDetailTransfer.OrgRefDate,
                                    //OrgRefNo = bUVoucherListDetailTransfer.OrgRefNo,
                                    RefDate = bUVoucherListEntity.RefDate,
                                    RefNo = bUVoucherListEntity.RefNo,
                                    AccountingObjectId = bUVoucherListDetailTransfer.AccountingObjectId,
                                    ActivityId = bUVoucherListDetailTransfer.ActivityId,
                                    Amount = bUVoucherListDetailTransfer.Amount,
                                    AmountOC = bUVoucherListDetailTransfer.AmountOC,
                                    //Approved = bUVoucherListDetailTransfer.Approved,
                                    //       BankId = bUTransferDetail.BankId,
                                    BudgetChapterCode = bUVoucherListDetailTransfer.BudgetChapterCode,
                                    BudgetDetailItemCode = bUVoucherListDetailTransfer.BudgetDetailItemCode,
                                    BudgetItemCode = bUVoucherListDetailTransfer.BudgetItemCode,
                                    BudgetKindItemCode = bUVoucherListDetailTransfer.BudgetKindItemCode,
                                    BudgetSourceId = bUVoucherListDetailTransfer.BudgetSourceId,
                                    BudgetSubItemCode = bUVoucherListDetailTransfer.BudgetSubItemCode,
                                    BudgetSubKindItemCode = bUVoucherListDetailTransfer.BudgetSubKindItemCode,
                                    CashWithDrawTypeId = bUVoucherListDetailTransfer.CashWithDrawTypeId,
                                    CreditAccount = bUVoucherListDetailTransfer.CreditAccount,
                                    DebitAccount = bUVoucherListDetailTransfer.DebitAccount,
                                    Description = bUVoucherListDetailTransfer.Description,
                                    FundStructureId = bUVoucherListDetailTransfer.FundStructureId,
                                    //       TaxAmount = bUTransferDetail.TaxAmount,
                                    ProjectActivityId = bUVoucherListDetailTransfer.ProjectActivityId,
                                    MethodDistributeId = bUVoucherListDetailTransfer.MethodDistributeId,
                                    JournalMemo = bUVoucherListEntity.JournalMemo,
                                    ProjectId = bUVoucherListDetailTransfer.ProjectId,
                                    PostedDate = bUVoucherListEntity.PostedDate,
                                    //       ToBankId = bUTransferDetail.BankId,
                                    CurrencyCode = bUVoucherListDetailTransfer.CurrencyCode,
                                    ExchangeRate = bUVoucherListDetailTransfer.ExchangeRate,
                                };
                                bUVoucherListResponse.Message =
                                    OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                                {
                                    bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bUVoucherListResponse;
                                }

                                #endregion
                            }

                        #endregion

                        #region BUVoucherListDetailParallel

                        if (bUVoucherListEntity.BUVoucherListDetailParallelEntities != null)
                            foreach (var bUVoucherListDetailParallel in bUVoucherListEntity
                                .BUVoucherListDetailParallelEntities)
                            {
                                #region Insert Receipt Detail Parallel

                                bUVoucherListDetailParallel.RefId = bUVoucherListEntity.RefId;
                                bUVoucherListDetailParallel.RefDetailId = Guid.NewGuid().ToString();

                                if (!bUVoucherListDetailParallel.Validate())
                                {
                                    foreach (var error in bUVoucherListDetailParallel.ValidationErrors)
                                        bUVoucherListResponse.Message += error + Environment.NewLine;
                                    bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bUVoucherListResponse;
                                }

                                bUVoucherListResponse.Message =
                                    BUVoucherListDetailParallelDao.InsertBUVoucherListDetailParallel(
                                        bUVoucherListDetailParallel);
                                if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                                {
                                    bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bUVoucherListResponse;
                                }

                                #endregion
                            }

                        #endregion
                    }

                    if (bUVoucherListResponse.Message != null)
                    {
                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUVoucherListResponse;
                    }
                    bUVoucherListResponse.RefId = bUVoucherListEntity.RefId;
                    scope.Complete();
                }

                return bUVoucherListResponse;
            }
        }

        /// <summary>
        ///     Updates the bu voucher list.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u voucher list entity.</param>
        /// <returns></returns>
        public BUVoucherListResponse UpdateBUVoucherList(BUVoucherListEntity bUVoucherListEntity)
        {
            var bUVoucherListResponse = new BUVoucherListResponse { Acknowledge = AcknowledgeType.Success };
            if (bUVoucherListEntity != null && !bUVoucherListEntity.Validate())
            {
                foreach (var error in bUVoucherListEntity.ValidationErrors)
                    bUVoucherListResponse.Message += error + Environment.NewLine;
                bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                return bUVoucherListResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (bUVoucherListEntity != null)
                {
                    var bUVoucherListByRefNo =
                        BUVoucherListDao.GetBUVoucherListByRefNo(bUVoucherListEntity.RefNo,
                            bUVoucherListEntity.PostedDate);
                    if (bUVoucherListByRefNo != null && bUVoucherListByRefNo.RefId != bUVoucherListEntity.RefId && bUVoucherListByRefNo.PostedDate.Year == bUVoucherListEntity.PostedDate.Year)
                    {
                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                        bUVoucherListResponse.Message =
                            string.Format("Số chứng từ \'{0}\' đã tồn tại!", bUVoucherListEntity.RefNo);
                        return bUVoucherListResponse;
                    }

                    bUVoucherListResponse.Message = BUVoucherListDao.UpdateBUVoucherList(bUVoucherListEntity);

                    if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                    {
                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUVoucherListResponse;
                    }

                    if (bUVoucherListEntity.RefType != (int)BuCA.Enum.RefType.BUCashBasicVoucherList)
                    {
                        #region Delete GeneralLedger

                        bUVoucherListResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(bUVoucherListEntity.RefId);
                        if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                        {
                            bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                            return bUVoucherListResponse;
                        }

                        #endregion

                        #region Delete OriginalGeneralLedger

                        bUVoucherListResponse.Message =
                            OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bUVoucherListEntity.RefId);
                        if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                        {
                            bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                            return bUVoucherListResponse;
                        }

                        #endregion
                    }

                    #region Insert bUVoucherListDetailEntity

                    bUVoucherListResponse.Message =
                        BUVoucherListDetailDao.DeleteBUVoucherListDetail(bUVoucherListEntity.RefId);
                    if (bUVoucherListEntity.BUVoucherListDetailEntities != null)
                        foreach (var bUVoucherListDetailEntity in bUVoucherListEntity.BUVoucherListDetailEntities)
                        {
                            bUVoucherListDetailEntity.RefId = bUVoucherListEntity.RefId;
                            bUVoucherListDetailEntity.RefDetailId = Guid.NewGuid().ToString();
                            if (!bUVoucherListDetailEntity.Validate())
                            {
                                foreach (var error in bUVoucherListDetailEntity.ValidationErrors)
                                    bUVoucherListResponse.Message += error + Environment.NewLine;
                                bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUVoucherListResponse;
                            }
                            bUVoucherListResponse.Message =
                                BUVoucherListDetailDao.InsertBUVoucherListDetail(bUVoucherListDetailEntity);
                            if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                            {
                                bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUVoucherListResponse;
                            }
                        }

                    #endregion

                    if (bUVoucherListEntity.RefType != (int)BuCA.Enum.RefType.BUCashBasicVoucherList)
                    {

                        #region insert bUVoucherListDetailTransfer

                        bUVoucherListResponse.Message =
                            BUVoucherListDetailTransferDao.DeleteBUVoucherListDetailTransferById(
                                bUVoucherListEntity.RefId);
                        if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                        {
                            bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                            return bUVoucherListResponse;
                        }
                        if (bUVoucherListEntity.BUVoucherListDetailTransferEntities != null)
                            foreach (var bUVoucherListDetailTransfer in bUVoucherListEntity
                                .BUVoucherListDetailTransferEntities)
                            {
                                bUVoucherListDetailTransfer.RefId = bUVoucherListEntity.RefId;
                                bUVoucherListDetailTransfer.RefDetailId = Guid.NewGuid().ToString();
                                if (!bUVoucherListDetailTransfer.Validate())
                                {
                                    foreach (var error in bUVoucherListDetailTransfer.ValidationErrors)
                                        bUVoucherListResponse.Message += error + Environment.NewLine;
                                    bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bUVoucherListResponse;
                                }
                                bUVoucherListResponse.Message =
                                    BUVoucherListDetailTransferDao.InsertBUVoucherListDetailTransfer(
                                        bUVoucherListDetailTransfer);
                                if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                                {
                                    bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bUVoucherListResponse;
                                }

                                //#region Insert to AccountBalance

                                //InsertAccountBalance(bUVoucherListEntity, bUVoucherListDetailTransfer);

                                //#endregion

                                #region Insert GeneralLedger

                                if (bUVoucherListDetailTransfer.DebitAccount != null &&
                                    bUVoucherListDetailTransfer.CreditAccount != null)
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = bUVoucherListEntity.RefType,
                                        RefNo = bUVoucherListEntity.RefNo,
                                        AccountingObjectId = bUVoucherListDetailTransfer.AccountingObjectId,
                                        //BankId = bUTransfer.BankId,
                                        BudgetChapterCode = bUVoucherListDetailTransfer.BudgetChapterCode,
                                        ProjectId = bUVoucherListDetailTransfer.ProjectId,
                                        BudgetSourceId = bUVoucherListDetailTransfer.BudgetSourceId,
                                        Description = bUVoucherListDetailTransfer.Description,
                                        RefDetailId = bUVoucherListDetailTransfer.RefDetailId,
                                        ExchangeRate = bUVoucherListDetailTransfer.ExchangeRate,
                                        ActivityId = bUVoucherListDetailTransfer.ActivityId,
                                        BudgetSubKindItemCode = bUVoucherListDetailTransfer.BudgetSubKindItemCode,
                                        CurrencyCode = bUVoucherListDetailTransfer.CurrencyCode,
                                        BudgetKindItemCode = bUVoucherListDetailTransfer.BudgetKindItemCode,
                                        RefId = bUVoucherListEntity.RefId,
                                        PostedDate = bUVoucherListEntity.PostedDate,
                                        MethodDistributeId = bUVoucherListDetailTransfer.MethodDistributeId,
                                        //OrgRefNo = bUVoucherListDetailTransfer.OrgRefNo,
                                        //OrgRefDate = bUVoucherListDetailTransfer.OrgRefDate,
                                        BudgetItemCode = bUVoucherListDetailTransfer.BudgetItemCode,
                                        ListItemId = bUVoucherListDetailTransfer.ListItemId,
                                        BudgetSubItemCode = bUVoucherListDetailTransfer.BudgetSubItemCode,
                                        BudgetDetailItemCode = bUVoucherListDetailTransfer.BudgetDetailItemCode,
                                        CashWithDrawTypeId = bUVoucherListDetailTransfer.CashWithDrawTypeId,
                                        AccountNumber = bUVoucherListDetailTransfer.DebitAccount,
                                        CorrespondingAccountNumber = bUVoucherListDetailTransfer.CreditAccount,
                                        DebitAmount = bUVoucherListDetailTransfer.Amount,
                                        DebitAmountOC = bUVoucherListDetailTransfer.AmountOC ?? 0,
                                        CreditAmount = 0,
                                        CreditAmountOC = 0,
                                        FundStructureId = bUVoucherListDetailTransfer.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = bUVoucherListEntity.JournalMemo,
                                        RefDate = bUVoucherListEntity.RefDate
                                    };
                                    bUVoucherListResponse.Message =
                                        GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                                    {
                                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUVoucherListResponse;
                                    }

                                    //insert lan 2
                                    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                    generalLedgerEntity.AccountNumber = bUVoucherListDetailTransfer.CreditAccount;
                                    generalLedgerEntity.CorrespondingAccountNumber =
                                        bUVoucherListDetailTransfer.DebitAccount;
                                    generalLedgerEntity.DebitAmount = 0;
                                    generalLedgerEntity.DebitAmountOC = 0;
                                    generalLedgerEntity.CreditAmount = bUVoucherListDetailTransfer.Amount;
                                    //generalLedgerEntity.CreditAmountOC = bUTransferDetail.AmountOC;
                                    bUVoucherListResponse.Message =
                                        GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                }
                                else //ghi don
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = bUVoucherListEntity.RefType,
                                        RefNo = bUVoucherListEntity.RefNo,
                                        AccountingObjectId = bUVoucherListDetailTransfer.AccountingObjectId,
                                        BudgetChapterCode = bUVoucherListDetailTransfer.BudgetChapterCode,
                                        ProjectId = bUVoucherListDetailTransfer.ProjectId,
                                        BudgetSourceId = bUVoucherListDetailTransfer.BudgetSourceId,
                                        Description = bUVoucherListDetailTransfer.Description,
                                        RefDetailId = bUVoucherListDetailTransfer.RefDetailId,
                                        ActivityId = bUVoucherListDetailTransfer.ActivityId,
                                        BudgetSubKindItemCode = bUVoucherListDetailTransfer.BudgetSubKindItemCode,
                                        BudgetKindItemCode = bUVoucherListDetailTransfer.BudgetKindItemCode,
                                        RefId = bUVoucherListEntity.RefId,
                                        PostedDate = bUVoucherListEntity.PostedDate,
                                        MethodDistributeId = bUVoucherListDetailTransfer.MethodDistributeId,
                                        BudgetItemCode = bUVoucherListDetailTransfer.BudgetItemCode,
                                        ListItemId = bUVoucherListDetailTransfer.ListItemId,
                                        BudgetSubItemCode = bUVoucherListDetailTransfer.BudgetSubItemCode,
                                        BudgetDetailItemCode = bUVoucherListDetailTransfer.BudgetDetailItemCode,
                                        CashWithDrawTypeId = bUVoucherListDetailTransfer.CashWithDrawTypeId,
                                        AccountNumber =
                                            bUVoucherListDetailTransfer.DebitAccount ??
                                            bUVoucherListDetailTransfer.CreditAccount,
                                        DebitAmount =
                                            bUVoucherListDetailTransfer.DebitAccount == null
                                                ? 0
                                                : bUVoucherListDetailTransfer.Amount,
                                        DebitAmountOC =
                                            bUVoucherListDetailTransfer.DebitAccount == null
                                                ? 0
                                                : bUVoucherListDetailTransfer.Amount,
                                        CreditAmount =
                                            bUVoucherListDetailTransfer.CreditAccount == null
                                                ? 0
                                                : bUVoucherListDetailTransfer.Amount,
                                        CreditAmountOC =
                                            bUVoucherListDetailTransfer.CreditAccount == null
                                                ? 0
                                                : bUVoucherListDetailTransfer.Amount,
                                        FundStructureId = bUVoucherListDetailTransfer.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = bUVoucherListEntity.JournalMemo,
                                        RefDate = bUVoucherListEntity.RefDate,
                                        SortOrder = bUVoucherListDetailTransfer.SortOrder
                                    };
                                    bUVoucherListResponse.Message =
                                        GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                                    {
                                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUVoucherListResponse;
                                    }
                                }

                                #endregion

                                #region Insert OriginalGeneralLedger

                                var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                {
                                    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                    RefType = bUVoucherListEntity.RefType,
                                    RefId = bUVoucherListEntity.RefId,
                                    RefDetailId = bUVoucherListDetailTransfer.RefDetailId,
                                    //OrgRefDate = bUVoucherListDetailTransfer.OrgRefDate,
                                    //OrgRefNo = bUVoucherListDetailTransfer.OrgRefNo,
                                    RefDate = bUVoucherListEntity.RefDate,
                                    RefNo = bUVoucherListEntity.RefNo,
                                    AccountingObjectId = bUVoucherListDetailTransfer.AccountingObjectId,
                                    ActivityId = bUVoucherListDetailTransfer.ActivityId,
                                    Amount = bUVoucherListDetailTransfer.Amount,
                                    //Approved = bUVoucherListDetailTransfer.Approved,
                                    //       BankId = bUTransferDetail.BankId,
                                    BudgetChapterCode = bUVoucherListDetailTransfer.BudgetChapterCode,
                                    BudgetDetailItemCode = bUVoucherListDetailTransfer.BudgetDetailItemCode,
                                    BudgetItemCode = bUVoucherListDetailTransfer.BudgetItemCode,
                                    BudgetKindItemCode = bUVoucherListDetailTransfer.BudgetKindItemCode,
                                    BudgetSourceId = bUVoucherListDetailTransfer.BudgetSourceId,
                                    BudgetSubItemCode = bUVoucherListDetailTransfer.BudgetSubItemCode,
                                    BudgetSubKindItemCode = bUVoucherListDetailTransfer.BudgetSubKindItemCode,
                                    CashWithDrawTypeId = bUVoucherListDetailTransfer.CashWithDrawTypeId,
                                    CreditAccount = bUVoucherListDetailTransfer.CreditAccount,
                                    DebitAccount = bUVoucherListDetailTransfer.DebitAccount,
                                    Description = bUVoucherListDetailTransfer.Description,
                                    FundStructureId = bUVoucherListDetailTransfer.FundStructureId,
                                    //       TaxAmount = bUTransferDetail.TaxAmount,
                                    ProjectActivityId = bUVoucherListDetailTransfer.ProjectActivityId,
                                    MethodDistributeId = bUVoucherListDetailTransfer.MethodDistributeId,
                                    JournalMemo = bUVoucherListEntity.JournalMemo,
                                    ProjectId = bUVoucherListDetailTransfer.ProjectId,
                                    PostedDate = bUVoucherListEntity.PostedDate,
                                    //       ToBankId = bUTransferDetail.BankId,
                                    CurrencyCode = bUVoucherListDetailTransfer.CurrencyCode,
                                    ExchangeRate = bUVoucherListDetailTransfer.ExchangeRate,
                                };
                                bUVoucherListResponse.Message =
                                    OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                                {
                                    bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bUVoucherListResponse;
                                }

                                #endregion
                            }

                        #endregion

                        #region BUVoucherListDetailParallel

                        bUVoucherListResponse.Message =
                            BUVoucherListDetailParallelDao.DeleteBUVoucherListDetailParallelById(
                                bUVoucherListEntity.RefId);
                        if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                        {
                            bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                            return bUVoucherListResponse;
                        }
                        if (bUVoucherListEntity.BUVoucherListDetailParallelEntities != null)
                            foreach (var bUVoucherListDetailParallel in bUVoucherListEntity
                                .BUVoucherListDetailParallelEntities)
                            {
                                #region Insert Receipt Detail Parallel

                                bUVoucherListDetailParallel.RefId = bUVoucherListEntity.RefId;
                                bUVoucherListDetailParallel.RefDetailId = Guid.NewGuid().ToString();

                                if (!bUVoucherListDetailParallel.Validate())
                                {
                                    foreach (var error in bUVoucherListDetailParallel.ValidationErrors)
                                        bUVoucherListResponse.Message += error + Environment.NewLine;
                                    bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bUVoucherListResponse;
                                }

                                bUVoucherListResponse.Message =
                                    BUVoucherListDetailParallelDao.InsertBUVoucherListDetailParallel(
                                        bUVoucherListDetailParallel);
                                if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                                {
                                    bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bUVoucherListResponse;
                                }

                                #endregion
                            }

                        #endregion
                    }

                    if (bUVoucherListResponse.Message != null)
                    {
                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUVoucherListResponse;
                    }
                    bUVoucherListResponse.RefId = bUVoucherListEntity.RefId;
                    scope.Complete();
                }

                return bUVoucherListResponse;
            }
        }

        /// <summary>
        ///     Deletes the bu commitment request.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        ///     BUTransferResponse.
        /// </returns>
        public BUVoucherListResponse DeleteBUVoucherList(string refId)
        {
            var bUVoucherListResponse = new BUVoucherListResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                var bUVoucherListForDelete = BUVoucherListDao.GetBUVoucherListByRefId(refId);

                bUVoucherListResponse.Message = BUVoucherListDao.DeleteBUVoucherList(bUVoucherListForDelete);
                if (bUVoucherListResponse.Message != null)
                {
                    bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return bUVoucherListResponse;
                }

                if (bUVoucherListForDelete.RefType != (int)BuCA.Enum.RefType.BUCashBasicVoucherList)
                {

                    #region Delete GeneralLedger

                    if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                    {
                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUVoucherListResponse;
                    }
                    bUVoucherListResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(bUVoucherListForDelete.RefId);

                    #endregion

                    #region Delete OriginalGeneralLedger

                    if (!string.IsNullOrEmpty(bUVoucherListResponse.Message))
                    {
                        bUVoucherListResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUVoucherListResponse;
                    }
                    bUVoucherListResponse.Message =
                        OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bUVoucherListForDelete.RefId);

                    #endregion
                }

                scope.Complete();
            }

            return bUVoucherListResponse;
        }

        /// <summary>
        /// Gets the original general ledger not in bu voucher list detail by cash withdraw no.
        /// </summary>
        /// <param name="cashWithdrawNo">The cash withdraw no.</param>
        /// <returns></returns>
        public List<BUVoucherListDetailEntity> GetOriginalGeneralLedgerNotInBUVoucherListDetailByCashWithdrawNo(
            string cashWithdrawNo)
        {
            return BUVoucherListDetailDao.GetOriginalGeneralLedgerNotInBUVoucherListDetailByCashWithdrawNo(
                cashWithdrawNo);
        }

        #region Insert/Update AccountBalance Function

        /// <summary>
        ///     Adds the account balance for debit.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u voucher list entity.</param>
        /// <param name="bUVoucherListDetailTransferEntity">The b u voucher list detail transfer entity.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(BUVoucherListEntity bUVoucherListEntity,
            BUVoucherListDetailTransferEntity bUVoucherListDetailTransferEntity)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = bUVoucherListDetailTransferEntity.DebitAccount,
                CurrencyCode = bUVoucherListDetailTransferEntity.CurrencyCode,
                ExchangeRate = bUVoucherListDetailTransferEntity.ExchangeRate,
                BalanceDate = bUVoucherListEntity.PostedDate,
                MovementDebitAmountOC = bUVoucherListDetailTransferEntity.AmountOC ?? 0,
                MovementDebitAmount = bUVoucherListDetailTransferEntity.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = bUVoucherListDetailTransferEntity.BudgetSourceId,
                BudgetChapterCode = bUVoucherListDetailTransferEntity.BudgetChapterCode,
                BudgetKindItemCode = bUVoucherListDetailTransferEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = bUVoucherListDetailTransferEntity.BudgetSubKindItemCode,
                BudgetItemCode = bUVoucherListDetailTransferEntity.BudgetItemCode,
                BudgetSubItemCode = bUVoucherListDetailTransferEntity.BudgetSubItemCode,
                MethodDistributeId = bUVoucherListDetailTransferEntity.MethodDistributeId,
                AccountingObjectId = bUVoucherListDetailTransferEntity.AccountingObjectId,
                ActivityId = bUVoucherListDetailTransferEntity.ActivityId,
                ProjectId = bUVoucherListDetailTransferEntity.ProjectId,
                BankAccount = bUVoucherListDetailTransferEntity.BankAccount,
                FundStructureId = bUVoucherListDetailTransferEntity.FundStructureId,
                ProjectActivityId = bUVoucherListDetailTransferEntity.ProjectActivityId,
                BudgetDetailItemCode = bUVoucherListDetailTransferEntity.BudgetDetailItemCode
            };
        }

        /// <summary>
        ///     Adds the account balance for credit.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u voucher list entity.</param>
        /// <param name="bUVoucherListDetailTransferEntity">The b u voucher list detail entity.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(BUVoucherListEntity bUVoucherListEntity,
            BUVoucherListDetailTransferEntity bUVoucherListDetailTransferEntity)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = bUVoucherListDetailTransferEntity.CreditAccount,
                CurrencyCode = bUVoucherListDetailTransferEntity.CurrencyCode,
                ExchangeRate = bUVoucherListDetailTransferEntity.ExchangeRate,
                BalanceDate = bUVoucherListEntity.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = bUVoucherListDetailTransferEntity.AmountOC ?? 0,
                MovementCreditAmount = bUVoucherListDetailTransferEntity.Amount,
                BudgetSourceId = bUVoucherListDetailTransferEntity.BudgetSourceId,
                BudgetChapterCode = bUVoucherListDetailTransferEntity.BudgetChapterCode,
                BudgetKindItemCode = bUVoucherListDetailTransferEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = bUVoucherListDetailTransferEntity.BudgetSubKindItemCode,
                BudgetItemCode = bUVoucherListDetailTransferEntity.BudgetItemCode,
                BudgetSubItemCode = bUVoucherListDetailTransferEntity.BudgetSubItemCode,
                MethodDistributeId = bUVoucherListDetailTransferEntity.MethodDistributeId,
                AccountingObjectId = bUVoucherListDetailTransferEntity.AccountingObjectId,
                ActivityId = bUVoucherListDetailTransferEntity.ActivityId,
                ProjectId = bUVoucherListDetailTransferEntity.ProjectId,
                BankAccount = bUVoucherListDetailTransferEntity.BankAccount,
                FundStructureId = bUVoucherListDetailTransferEntity.FundStructureId,
                ProjectActivityId = bUVoucherListDetailTransferEntity.ProjectActivityId,
                BudgetDetailItemCode = bUVoucherListDetailTransferEntity.BudgetDetailItemCode
            };
        }

        /// <summary>
        ///     Updates the account balance.
        /// </summary>
        /// <param name="accountBalanceEntity">The account balance entity.</param>
        /// <param name="movementAmount">The movement amount.</param>
        /// <param name="movementAmountExchange">The movement amount exchange.</param>
        /// <param name="isMovementAmount">if set to <c>true</c> [is movement amount].</param>
        /// <param name="balanceSide">The balance side.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(AccountBalanceEntity accountBalanceEntity, decimal movementAmount,
            decimal movementAmountExchange,
            bool isMovementAmount, int balanceSide)
        {
            string message;
            // cập nhật bên TK nợ
            if (balanceSide == 1)
            {
                accountBalanceEntity.ExchangeRate = accountBalanceEntity.ExchangeRate;
                if (isMovementAmount)
                {
                    accountBalanceEntity.MovementDebitAmount =
                        accountBalanceEntity.MovementDebitAmount + movementAmount;
                    accountBalanceEntity.MovementDebitAmountOC =
                        accountBalanceEntity.MovementDebitAmountOC + movementAmountExchange;
                }
                else
                {
                    accountBalanceEntity.MovementDebitAmount =
                        accountBalanceEntity.MovementDebitAmount - movementAmount;
                    accountBalanceEntity.MovementDebitAmountOC =
                        accountBalanceEntity.MovementDebitAmountOC - movementAmountExchange;
                }
                message = AccountBalanceDao.UpdateAccountBalance(accountBalanceEntity);
                if (message != null)
                    return message;
            }
            else
            {
                accountBalanceEntity.ExchangeRate = accountBalanceEntity.ExchangeRate;
                if (isMovementAmount)
                {
                    accountBalanceEntity.MovementCreditAmount =
                        accountBalanceEntity.MovementCreditAmount + movementAmount;
                    accountBalanceEntity.MovementCreditAmountOC =
                        accountBalanceEntity.MovementCreditAmountOC + movementAmountExchange;
                }
                else
                {
                    accountBalanceEntity.MovementCreditAmount =
                        accountBalanceEntity.MovementCreditAmount - movementAmount;
                    accountBalanceEntity.MovementCreditAmountOC =
                        accountBalanceEntity.MovementCreditAmountOC - movementAmountExchange;
                }
                message = AccountBalanceDao.UpdateAccountBalance(accountBalanceEntity);
                if (message != null)
                    return message;
            }
            return null;
        }

        /// <summary>
        ///     Updates the account balance.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u voucher list entity.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(BUVoucherListEntity bUVoucherListEntity)
        {
            var bUVoucherListDetailTransfers =
                BUVoucherListDetailTransferDao.GetBUVoucherListDetailTransferByRefId(bUVoucherListEntity.RefId);
            foreach (var bUVoucherListDetailTransfer in bUVoucherListDetailTransfers)
            {
                string message;
                var accountBalanceForDebit =
                    AddAccountBalanceForDebit(bUVoucherListEntity, bUVoucherListDetailTransfer);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit,
                        accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }

                var accountBalanceForCredit =
                    AddAccountBalanceForCredit(bUVoucherListEntity, bUVoucherListDetailTransfer);
                var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
                if (accountBalanceForCreditExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForCreditExit,
                        accountBalanceForCredit.MovementCreditAmountOC,
                        accountBalanceForCredit.MovementCreditAmount, false, 2);
                    if (message != null)
                        return message;
                }
            }
            return null;
        }

        /// <summary>
        ///     Inserts the account balance.
        /// </summary>
        /// <param name="bUVoucherListEntity">The b u voucher list entity.</param>
        /// <param name="bUVoucherListDetailTransferEntity">The b u voucher list detail transfer entity.</param>
        public void InsertAccountBalance(BUVoucherListEntity bUVoucherListEntity,
            BUVoucherListDetailTransferEntity bUVoucherListDetailTransferEntity)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit =
                AddAccountBalanceForDebit(bUVoucherListEntity, bUVoucherListDetailTransferEntity);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit =
                AddAccountBalanceForCredit(bUVoucherListEntity, bUVoucherListDetailTransferEntity);
            var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
            if (accountBalanceForCreditExit != null)
                UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                    accountBalanceForCredit.MovementCreditAmount, true, 2);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
        }

        #endregion
    }
}