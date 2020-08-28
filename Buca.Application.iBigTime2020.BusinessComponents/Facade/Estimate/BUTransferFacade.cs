/***********************************************************************
 * <copyright file="BUTransferFacade.cs" company="BUCA JSC">
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

using Buca.Application.iBigTime2020.BusinessComponents.Facade.System;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Estimate
{
    /// <summary>
    /// Class BUTransferFacade.
    /// </summary>
    public class BUTransferFacade : FacadeBase
    {
        private static readonly DataAccess.IEntitiesDao.Inventory.IInventoryLedgerDao InventoryLedgerDao = DataAccess.DataAccess.InventoryLedgerDao;
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        private static readonly IFixedAssetDao FixedAssetDao = DataAccess.DataAccess.FixedAssetDao;

        /// <summary>
        /// The bu commitment request DAO
        /// </summary>
        private static readonly IBUTransferDao BUTransferDao = DataAccess.DataAccess.BUTransferDao;
        private static readonly ICAPaymentDao CAPaymentDao = DataAccess.DataAccess.CAPaymentDao;
        private static readonly ICAPaymentDetailFixedAssetDao CAPaymentDetailFixedAssetDao = DataAccess.DataAccess.CAPaymentDetailFixedAssetDao;
        /// <summary>
        /// The bu transfer detail DAO
        /// </summary>
        private static readonly IBUTransferDetailDao BUTransferDetailDao = DataAccess.DataAccess.BUTransferDetailDao;
        /// <summary>
        /// The general ledger DAO
        /// </summary>
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;

        /// <summary>
        /// The original general ledger DAO
        /// </summary>
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;

        /// <summary>
        /// The account balance DAO
        /// </summary>
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;

        private static readonly IBUTransferDetailParallelDao BuTransferDetailParallelDao = DataAccess.DataAccess.BUTransferDetailParallelDao;

        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;

        private static readonly IBUTransferDetailPurchaseDao BUTransferDetailPurchaseDao = DataAccess.DataAccess.BUTransferDetailPurchaseDao;

        /// <summary>
        /// Gets the bu commitment requestby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUTransferEntity.</returns>
        public BUTransferEntity GetBUTransferbyRefId(string refId)
        {
            return BUTransferDao.GetBUTransferbyRefId(refId);
        }

        /// <summary>
        /// Gets the bu transfer by bu plan withdraw reference identifier.
        /// </summary>
        /// <param name="buPlanWithdrawRefId">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        public BUTransferEntity GetBUTransferByBUPlanWithdrawRefId(string buPlanWithdrawRefId)
        {
            return BUTransferDao.GetBUTransferByBUPlanWithdrawRefId(buPlanWithdrawRefId);
        }

        /// <summary>
        /// Gets the bu plan receipt voucher by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedBUTransferDetail">if set to <c>true</c> [is included bu commitment request detail].</param>
        /// <returns>BUTransferEntity.</returns>
        public BUTransferEntity GetBUTransferVoucherByRefId(string refId, bool isIncludedBUTransferDetail)
        {
            var bUTransfer = BUTransferDao.GetBUTransferbyRefId(refId);
            if (isIncludedBUTransferDetail && bUTransfer != null)
            {
                switch (bUTransfer.RefType)
                {
                    case (int)BuCA.Enum.RefType.BUTransferPurchase:
                        bUTransfer.BUTransferDetailPurchases = BUTransferDetailPurchaseDao.GetBUTransferDetailPurchasesByRefId(refId);
                        break;
                    case (int)BuCA.Enum.RefType.BUTransferFixedAsset:
                        bUTransfer.BUTransferDetailFixedAssets = BUTransferDetailPurchaseDao.GetBUTransferDetailFixedAssetsByRefId(refId);
                        break;

                    default:
                        bUTransfer.BUTransferDetails = BUTransferDetailDao.GetBUTransferDetailbyRefId(bUTransfer.RefId);
                        break;
                }

                bUTransfer.BUTransferDetailParallels = BuTransferDetailParallelDao.GetBUTransferDetailParallelByRefId(bUTransfer.RefId);
            }
            return bUTransfer;
        }
        public CAPaymentEntity CAPaymentFixedAsset(string refId, bool isIncludedBUTransferDetail)
        {
            var caPayment = CAPaymentDao.GetCaPaymentEntitybyRefId(refId);
            if (isIncludedBUTransferDetail && caPayment != null)
            {


                caPayment.CAPaymentDetailFixedAssets = CAPaymentDetailFixedAssetDao.GetCAPaymentDetailFixedAssetsByRefId(caPayment.RefId);
            }
            return caPayment;
        }

        /// <summary>
        /// Gets the bu commitment request.
        /// </summary>
        /// <returns>List&lt;BUTransferEntity&gt;.</returns>
        public List<BUTransferEntity> GetBUTransfer()
        {
            return BUTransferDao.GetBUTransfer();
        }
        /// <summary>
        /// Gets the bu commitment requests by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;BUTransferEntity&gt;.</returns>
        public List<BUTransferEntity> GetBUTransfersByRefTypeId(int refTypeId)
        {
            return BUTransferDao.GetBUTransfersByRefTypeId(refTypeId);
        }
        /// <summary>
        /// Inserts the bu commitment request.
        /// </summary>
        /// <param name="bUTransfer">The b u commitment request.</param>
        /// <returns>BUTransferResponse.</returns>
        public BUTransferResponse InsertBUTransfer(BUTransferEntity bUTransfer, bool isAutoGenerateParallel)
        {
            var bUTransferResponse = new BUTransferResponse { Acknowledge = AcknowledgeType.Success };

            if (bUTransfer != null && !bUTransfer.Validate())
            {
                foreach (var error in bUTransfer.ValidationErrors)
                    bUTransferResponse.Message += error + Environment.NewLine;
                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                return bUTransferResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (bUTransfer != null)
                {
                    //thangnd edit lay by refno khong all ve su dung linq
                    var bUTransferByRefNo = BUTransferDao.GetBUTransferbyRefNo(bUTransfer.RefNo, bUTransfer.PostedDate);
                    if (bUTransferByRefNo != null && bUTransferByRefNo.PostedDate.Year == bUTransfer.PostedDate.Year)
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        bUTransferResponse.Message = string.Format("Số chứng từ \'{0}\' đã tồn tại!", bUTransfer.RefNo);
                        return bUTransferResponse;
                    }

                    bUTransfer.RefId = Guid.NewGuid().ToString();
                    bUTransferResponse.Message = BUTransferDao.InsertBUTransfer(bUTransfer);

                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUTransferResponse;
                    }

                    #region Details
                    if (bUTransfer.BUTransferDetails != null)
                    {
                        foreach (var bUTransferDetail in bUTransfer.BUTransferDetails)
                        {
                            bUTransferDetail.RefId = bUTransfer.RefId;
                            bUTransferDetail.RefDetailId = Guid.NewGuid().ToString();
                            if (!bUTransferDetail.Validate())
                            {
                                foreach (var error in bUTransferDetail.ValidationErrors)
                                    bUTransferResponse.Message += error + Environment.NewLine;
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }
                            bUTransferResponse.Message =
                                BUTransferDetailDao.InsertBUTransferDetail(bUTransferDetail);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            #region Insert to AccountBalance
                            InsertAccountBalance(bUTransfer, bUTransferDetail);
                            #endregion

                            #region Insert GeneralLedger

                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = bUTransfer.RefType,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = bUTransferDetail.AccountingObjectId,
                                BankId = bUTransferDetail.BankId,
                                BudgetChapterCode = bUTransferDetail.BudgetChapterCode,
                                ProjectId = bUTransferDetail.ProjectId,
                                BudgetSourceId = bUTransferDetail.BudgetSourceId,
                                Description = bUTransferDetail.Description,
                                RefDetailId = bUTransferDetail.RefDetailId,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                ActivityId = bUTransferDetail.ActivityId,
                                BudgetSubKindItemCode = bUTransferDetail.BudgetSubKindItemCode,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                BudgetKindItemCode = bUTransferDetail.BudgetKindItemCode,
                                RefId = bUTransfer.RefId,
                                PostedDate = bUTransfer.PostedDate,
                                MethodDistributeId = bUTransferDetail.MethodDistributeId,
                                OrgRefNo = bUTransferDetail.OrgRefNo,
                                OrgRefDate = bUTransferDetail.OrgRefDate,
                                BudgetItemCode = bUTransferDetail.BudgetItemCode,
                                ListItemId = bUTransferDetail.ListItemId,
                                BudgetSubItemCode = bUTransferDetail.BudgetSubItemCode,
                                BudgetDetailItemCode = bUTransferDetail.BudgetDetailItemCode,
                                CashWithDrawTypeId = bUTransferDetail.CashWithDrawTypeId,
                                AccountNumber = bUTransferDetail.DebitAccount,
                                CorrespondingAccountNumber = bUTransferDetail.CreditAccount,
                                DebitAmount = bUTransferDetail.Amount,
                                DebitAmountOC = bUTransferDetail.AmountOC,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                FundStructureId = bUTransferDetail.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = bUTransfer.JournalMemo,
                                RefDate = bUTransfer.RefDate,
                                BudgetExpenseId = bUTransferDetail.BudgetExpenseId,
                                SortOrder = bUTransferDetail.SortOrder,
                                ContractId = bUTransferDetail.ContractId,
                                CapitalPlanId = bUTransferDetail.CapitalPlanId
                            };
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            //insert lan 2
                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                            generalLedgerEntity.AccountNumber = bUTransferDetail.CreditAccount;
                            generalLedgerEntity.CorrespondingAccountNumber = bUTransferDetail.DebitAccount;
                            generalLedgerEntity.DebitAmount = 0;
                            generalLedgerEntity.DebitAmountOC = 0;
                            generalLedgerEntity.CreditAmount = bUTransferDetail.Amount;
                            generalLedgerEntity.CreditAmountOC = bUTransferDetail.AmountOC;
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                            #endregion

                            #region Insert OriginalGeneralLedger

                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bUTransfer.RefType,
                                RefId = bUTransfer.RefId,
                                RefDetailId = bUTransferDetail.RefDetailId,
                                OrgRefDate = bUTransferDetail.OrgRefDate,
                                OrgRefNo = bUTransferDetail.OrgRefNo,
                                RefDate = bUTransfer.RefDate,
                                PostedDate = bUTransfer.PostedDate,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = bUTransferDetail.AccountingObjectId,
                                ActivityId = bUTransferDetail.ActivityId,
                                Amount = bUTransferDetail.Amount,
                                AmountOC = bUTransferDetail.AmountOC,
                                Approved = bUTransferDetail.Approved,
                                BankId = bUTransferDetail.BankId,
                                BudgetChapterCode = bUTransferDetail.BudgetChapterCode,
                                BudgetDetailItemCode = bUTransferDetail.BudgetDetailItemCode,
                                BudgetItemCode = bUTransferDetail.BudgetItemCode,
                                BudgetKindItemCode = bUTransferDetail.BudgetKindItemCode,
                                BudgetSourceId = bUTransferDetail.BudgetSourceId,
                                BudgetSubItemCode = bUTransferDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = bUTransferDetail.BudgetSubKindItemCode,
                                CashWithDrawTypeId = bUTransferDetail.CashWithDrawTypeId,
                                CreditAccount = bUTransferDetail.CreditAccount,
                                DebitAccount = bUTransferDetail.DebitAccount,
                                Description = bUTransferDetail.Description,
                                FundStructureId = bUTransferDetail.FundStructureId,
                                //       TaxAmount = bUTransferDetail.TaxAmount,
                                ProjectActivityId = bUTransferDetail.ProjectActivityId,
                                MethodDistributeId = bUTransferDetail.MethodDistributeId,
                                JournalMemo = bUTransfer.JournalMemo,
                                ProjectId = bUTransferDetail.ProjectId,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                BudgetExpenseId = bUTransferDetail.BudgetExpenseId,
                                //       ToBankId = bUTransferDetail.BankId,
                                SortOrder = bUTransferDetail.SortOrder,
                                ContractId = bUTransferDetail.ContractId,
                            };
                            bUTransferResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            #endregion
                        }

                        #region Sinh dinh khoan dong thoi
                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region BUTransferDetailParallel

                            if (bUTransfer.BUTransferDetailParallels != null)
                            {
                                var i = 0;

                                //insert dl moi
                                foreach (var buTransferDetailParallel in bUTransfer.BUTransferDetailParallels)
                                {
                                    #region Insert Receipt Detail Parallel

                                    i = i + 1;
                                    buTransferDetailParallel.RefId = bUTransfer.RefId;
                                    buTransferDetailParallel.SortOrder = i;
                                    buTransferDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    buTransferDetailParallel.Amount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;

                                    if (!buTransferDetailParallel.Validate())
                                    {
                                        foreach (var error in buTransferDetailParallel.ValidationErrors)
                                            bUTransferResponse.Message += error + Environment.NewLine;
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }

                                    bUTransferResponse.Message = BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallel);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (buTransferDetailParallel.DebitAccount != null && buTransferDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder,
                                            ContractId = buTransferDetailParallel.ContractId,
                                            CapitalPlanId = buTransferDetailParallel.CapitalPlanId
                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = buTransferDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = buTransferDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;
                                        generalLedgerEntity.CreditAmountOC = buTransferDetailParallel.AmountOC;
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }

                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount ?? buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder,
                                            ContractId = buTransferDetailParallel.ContractId,
                                            CapitalPlanId = buTransferDetailParallel.CapitalPlanId
                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }
                                    }

                                    #endregion

                                    #region Insert OriginalGeneralLedger

                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = bUTransfer.RefType,
                                        RefId = bUTransfer.RefId,
                                        RefDetailId = buTransferDetailParallel.RefDetailId,
                                        OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                        OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                        RefDate = bUTransfer.RefDate,
                                        RefNo = bUTransfer.RefNo,
                                        AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                        ActivityId = buTransferDetailParallel.ActivityId,
                                        Amount = buTransferDetailParallel.Amount,
                                        AmountOC = buTransferDetailParallel.AmountOC,
                                        BankId = buTransferDetailParallel.BankId,
                                        BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = buTransferDetailParallel.CreditAccount,
                                        DebitAccount = buTransferDetailParallel.DebitAccount,
                                        Description = buTransferDetailParallel.Description,
                                        FundStructureId = buTransferDetailParallel.FundStructureId,
                                        MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                        JournalMemo = bUTransfer.JournalMemo,
                                        ProjectId = buTransferDetailParallel.ProjectId,
                                        ToBankId = buTransferDetailParallel.BankId,
                                        ExchangeRate = bUTransfer.ExchangeRate,
                                        CurrencyCode = bUTransfer.CurrencyCode,
                                        PostedDate = bUTransfer.PostedDate,
                                        SortOrder = buTransferDetailParallel.SortOrder,
                                        BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                        ContractId = buTransferDetailParallel.ContractId,
                                    };
                                    bUTransferResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }

                                    #endregion
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            AutoMapper(InsertParallel(bUTransfer, InsertParallelBy.Details), bUTransferResponse);
                        }

                        #endregion
                    }
                    #endregion

                    #region Nhập mua hàng hóa chuyển khoản
                    if (bUTransfer.BUTransferDetailPurchases != null && bUTransfer.BUTransferDetailPurchases.Count > 0)
                    {
                        #region Xóa 1 số thứ trước khi thêm
                        // xóa tất rồi thêm lại => nông dân
                        bUTransferResponse.Message = BUTransferDetailPurchaseDao.DeleteBUTransferDetailPurchases(bUTransfer.RefId);
                        if (bUTransferResponse.Message != null)
                        {
                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bUTransferResponse;
                        }

                        // Xóa bảng InventoryLedger
                        bUTransferResponse.Message = InventoryLedgerDao.DeleteInventoryLedger(bUTransfer.RefId);
                        if (bUTransferResponse.Message != null)
                        {
                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bUTransferResponse;
                        }
                        #endregion

                        foreach (var item in bUTransfer.BUTransferDetailPurchases)
                        {
                            #region Detail
                            item.RefId = bUTransfer.RefId;
                            //if (string.IsNullOrEmpty(item.RefDetailId))
                            item.RefDetailId = Guid.NewGuid().ToString();

                            if (!item.Validate())
                            {
                                foreach (var error in item.ValidationErrors)
                                    bUTransferResponse.Message += error + Environment.NewLine;
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            bUTransferResponse.Message = BUTransferDetailPurchaseDao.InsertBUTransferDetailPurchase(item);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }
                            #endregion

                            #region Insert to AccountBalance
                            InsertAccountBalance(bUTransfer, item);
                            #endregion

                            #region Insert GeneralLedger
                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = bUTransfer.RefType,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = item.AccountingObjectId,
                                BankId = bUTransfer.BankInfoId,
                                BudgetChapterCode = item.BudgetChapterCode,
                                //ProjectId = item.ProjectId,
                                BudgetSourceId = item.BudgetSourceId,
                                Description = item.Description,
                                RefDetailId = item.RefDetailId,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                ActivityId = item.ActivityId,
                                BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                BudgetKindItemCode = item.BudgetKindItemCode,
                                RefId = bUTransfer.RefId,
                                PostedDate = bUTransfer.PostedDate,
                                MethodDistributeId = item.MethodDistributeId,
                                //OrgRefNo = item.OrgRefNo,
                                OrgRefDate = item.OrgRefDate,
                                BudgetItemCode = item.BudgetItemCode,
                                //ListItemId = item.ListItemId,
                                BudgetSubItemCode = item.BudgetSubItemCode,
                                //BudgetDetailItemCode = item.BudgetDetailItemCode,
                                CashWithDrawTypeId = item.CashWithdrawTypeId,
                                AccountNumber = item.DebitAccount,
                                CorrespondingAccountNumber = item.CreditAccount,
                                DebitAmount = item.Amount,
                                DebitAmountOC = item.Amount,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                //FundStructureId = item.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = bUTransfer.JournalMemo,
                                RefDate = bUTransfer.RefDate,
                                BudgetExpenseId = item.BudgetExpenseId,
                                SortOrder = item.SortOrder,
                            };
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            //insert lan 2
                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                            generalLedgerEntity.AccountNumber = item.CreditAccount;
                            generalLedgerEntity.CorrespondingAccountNumber = item.DebitAccount;
                            generalLedgerEntity.DebitAmount = 0;
                            generalLedgerEntity.DebitAmountOC = 0;
                            generalLedgerEntity.CreditAmount = item.Amount;
                            //generalLedgerEntity.CreditAmountOC = bUTransferDetail.AmountOC;
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bUTransfer.RefType,
                                RefId = bUTransfer.RefId,
                                RefDetailId = item.RefDetailId,
                                OrgRefDate = item.OrgRefDate,
                                //OrgRefNo = item.OrgRefNo,
                                RefDate = bUTransfer.RefDate,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = item.AccountingObjectId,
                                ActivityId = item.ActivityId,
                                Amount = item.Amount,
                                AmountOC = item.Amount,
                                //Approved = item.Approved,
                                BankId = bUTransfer.BankInfoId,
                                BudgetChapterCode = item.BudgetChapterCode,
                                //BudgetDetailItemCode = item.BudgetDetailItemCode,
                                BudgetItemCode = item.BudgetItemCode,
                                BudgetKindItemCode = item.BudgetKindItemCode,
                                BudgetSourceId = item.BudgetSourceId,
                                BudgetSubItemCode = item.BudgetSubItemCode,
                                BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                CashWithDrawTypeId = item.CashWithdrawTypeId,
                                CreditAccount = item.CreditAccount,
                                DebitAccount = item.DebitAccount,
                                Description = item.Description,
                                //FundStructureId = item.FundStructureId,
                                //       TaxAmount = bUTransferDetail.TaxAmount,
                                //ProjectActivityId = item.ProjectActivityId,
                                MethodDistributeId = item.MethodDistributeId,
                                JournalMemo = bUTransfer.JournalMemo,
                                //ProjectId = item.ProjectId,
                                ToBankId = bUTransfer.BankInfoId,
                                PostedDate = bUTransfer.PostedDate,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                SortOrder = item.SortOrder,
                                BudgetExpenseId = item.BudgetExpenseId,
                            };
                            bUTransferResponse.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }
                            #endregion

                            #region Insert into Inventory Ledger
                            var inventoryLedgerEntity = new BusinessEntities.Business.InwardOutward.InventoryLedgerEntity
                            {

                                InventoryLedgerId = Guid.NewGuid().ToString(),
                                RefId = item.RefId,
                                RefType = bUTransfer.RefType,
                                RefNo = bUTransfer.RefNo,
                                RefDate = bUTransfer.RefDate,
                                PostedDate = bUTransfer.PostedDate,
                                StockId = item.StockId,
                                InventoryItemId = item.InventoryItemId,
                                BudgetSourceId = item.BudgetSourceId,
                                Description = item.Description,
                                RefDetailId = item.RefDetailId,
                                Unit = item.Unit,
                                UnitPrice = item.UnitPrice,
                                InwardQuantity = item.Quantity,
                                OutwardQuantity = 0,
                                OutwardAmount = 0,
                                InwardAmount = item.Amount,
                                //JournalMemo = item.JournalMemo,
                                //ExpiryDate = item.ExpiryDate,
                                //LotNo = item.LotNo,
                                RefOrder = bUTransfer.RefOrder,
                                SortOrder = item.SortOrder,
                                AccountNumber = item.DebitAccount,
                                CorrespondingAccountNumber = item.CreditAccount,
                                InwardAmountBalance = 0,
                                InwardAmountBalanceAfter = 0,
                                InwardQuantityBalance = 0,
                                UnitPriceBalance = 0,
                            };
                            bUTransferResponse.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return bUTransferResponse;
                            }
                            #endregion
                        }

                        #region Sinh dinh khoan dong thoi
                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region BUTransferDetailParallel
                            if (bUTransfer.BUTransferDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var buTransferDetailParallel in bUTransfer.BUTransferDetailParallels)
                                {
                                    #region Insert Receipt Detail Parallel
                                    buTransferDetailParallel.RefId = bUTransfer.RefId;
                                    buTransferDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    buTransferDetailParallel.Amount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;

                                    if (!buTransferDetailParallel.Validate())
                                    {
                                        foreach (var error in buTransferDetailParallel.ValidationErrors)
                                            bUTransferResponse.Message += error + Environment.NewLine;
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }

                                    bUTransferResponse.Message = BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallel);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }
                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (buTransferDetailParallel.DebitAccount != null && buTransferDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder
                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = buTransferDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = buTransferDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;
                                        generalLedgerEntity.CreditAmountOC = buTransferDetailParallel.AmountOC;
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount ?? buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC,
                                            CreditAmount = buTransferDetailParallel.CreditAccount == null ? 0 : buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            CreditAmountOC = buTransferDetailParallel.CreditAccount == null ? 0 : buTransferDetailParallel.AmountOC,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder
                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }
                                    }

                                    #endregion

                                    #region Insert OriginalGeneralLedger
                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = bUTransfer.RefType,
                                        RefId = bUTransfer.RefId,
                                        RefDetailId = buTransferDetailParallel.RefDetailId,
                                        OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                        OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                        RefDate = bUTransfer.RefDate,
                                        RefNo = bUTransfer.RefNo,
                                        AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                        ActivityId = buTransferDetailParallel.ActivityId,
                                        Amount = buTransferDetailParallel.Amount,
                                        AmountOC = buTransferDetailParallel.AmountOC,
                                        //Approved = bUTransfer.Approved,
                                        BankId = buTransferDetailParallel.BankId,
                                        BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = buTransferDetailParallel.CreditAccount,
                                        DebitAccount = buTransferDetailParallel.DebitAccount,
                                        Description = buTransferDetailParallel.Description,
                                        FundStructureId = buTransferDetailParallel.FundStructureId,
                                        //ProjectActivityId = buTransferDetailParallel.ProjectActivityId,
                                        MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                        JournalMemo = bUTransfer.JournalMemo,
                                        ProjectId = buTransferDetailParallel.ProjectId,
                                        ToBankId = buTransferDetailParallel.BankId,
                                        ExchangeRate = bUTransfer.ExchangeRate,
                                        CurrencyCode = bUTransfer.CurrencyCode,
                                        PostedDate = bUTransfer.PostedDate,
                                        SortOrder = buTransferDetailParallel.SortOrder,
                                        BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                        ContractId = buTransferDetailParallel.ContractId
                                    };
                                    bUTransferResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            AutoMapper(InsertParallel(bUTransfer, InsertParallelBy.Purchases), bUTransferResponse);
                        }
                        #endregion
                    }
                    #endregion

                    #region Nhập mua TSCĐ chuyển khoản
                    if (bUTransfer.BUTransferDetailFixedAssets != null && bUTransfer.BUTransferDetailFixedAssets.Count > 0)
                    {
                        #region Xóa 1 số thứ trước khi thêm
                        // xóa tất rồi thêm lại => nông dân
                        bUTransferResponse.Message = BUTransferDetailPurchaseDao.DeleteBUTransferDetailFixedAssets(bUTransfer.RefId);
                        if (bUTransferResponse.Message != null)
                        {
                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bUTransferResponse;
                        }

                        // Xóa bảng FixAssetLedger
                        bUTransferResponse.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(bUTransfer.RefId, bUTransfer.RefType);
                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                        {
                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bUTransferResponse;
                        }
                        #endregion

                        foreach (var item in bUTransfer.BUTransferDetailFixedAssets)
                        {
                            #region Detail
                            item.RefId = bUTransfer.RefId;
                            //if (string.IsNullOrEmpty(item.RefDetailId))
                            item.RefDetailId = Guid.NewGuid().ToString();

                            if (!item.Validate())
                            {
                                foreach (var error in item.ValidationErrors)
                                    bUTransferResponse.Message += error + Environment.NewLine;
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            bUTransferResponse.Message = BUTransferDetailPurchaseDao.InsertBUTransferDetailFixedAsset(item);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }
                            #endregion

                            #region Insert to AccountBalance
                            InsertAccountBalance(bUTransfer, item);
                            #endregion

                            #region Insert GeneralLedger

                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = bUTransfer.RefType,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = item.AccountingObjectId,
                                BankId = bUTransfer.BankInfoId,
                                BudgetChapterCode = item.BudgetChapterCode,
                                //ProjectId = item.ProjectId,
                                BudgetSourceId = item.BudgetSourceId,
                                Description = item.Description,
                                RefDetailId = item.RefDetailId,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                ActivityId = item.ActivityId,
                                BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                BudgetKindItemCode = item.BudgetKindItemCode,
                                RefId = bUTransfer.RefId,
                                PostedDate = bUTransfer.PostedDate,
                                MethodDistributeId = item.MethodDistributeId,
                                OrgRefNo = item.OrgRefNo,
                                OrgRefDate = item.OrgRefDate,
                                BudgetItemCode = item.BudgetItemCode,
                                ListItemId = item.ListItemId,
                                BudgetSubItemCode = item.BudgetSubItemCode,
                                BudgetDetailItemCode = item.BudgetDetailItemCode,
                                CashWithDrawTypeId = item.CashWithdrawTypeId,
                                AccountNumber = item.DebitAccount,
                                CorrespondingAccountNumber = item.CreditAccount,
                                DebitAmount = item.Amount,
                                DebitAmountOC = item.Amount,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                FundStructureId = item.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = bUTransfer.JournalMemo,
                                RefDate = bUTransfer.RefDate,
                                BudgetExpenseId = item.BudgetExpenseId,
                                SortOrder = item.SortOrder
                            };
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            //insert lan 2
                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                            generalLedgerEntity.AccountNumber = item.CreditAccount;
                            generalLedgerEntity.CorrespondingAccountNumber = item.DebitAccount;
                            generalLedgerEntity.DebitAmount = 0;
                            generalLedgerEntity.DebitAmountOC = 0;
                            generalLedgerEntity.CreditAmount = item.Amount;
                            generalLedgerEntity.CreditAmountOC = item.Amount;
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bUTransfer.RefType,
                                RefId = bUTransfer.RefId,
                                RefDetailId = item.RefDetailId,
                                OrgRefDate = item.OrgRefDate,
                                OrgRefNo = item.OrgRefNo,
                                RefDate = bUTransfer.RefDate,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = item.AccountingObjectId,
                                ActivityId = item.ActivityId,
                                Amount = item.Amount,
                                AmountOC = item.Amount,
                                //Approved = item.Approved,
                                BankId = bUTransfer.BankInfoId,
                                BudgetChapterCode = item.BudgetChapterCode,
                                BudgetDetailItemCode = item.BudgetDetailItemCode,
                                BudgetItemCode = item.BudgetItemCode,
                                BudgetKindItemCode = item.BudgetKindItemCode,
                                BudgetSourceId = item.BudgetSourceId,
                                BudgetSubItemCode = item.BudgetSubItemCode,
                                BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                CashWithDrawTypeId = item.CashWithdrawTypeId,
                                CreditAccount = item.CreditAccount,
                                DebitAccount = item.DebitAccount,
                                Description = item.Description,
                                //FundStructureId = item.FundStructureId,
                                //       TaxAmount = bUTransferDetail.TaxAmount,
                                //ProjectActivityId = item.ProjectActivityId,
                                MethodDistributeId = item.MethodDistributeId,
                                JournalMemo = bUTransfer.JournalMemo,
                                //ProjectId = item.ProjectId,
                                ToBankId = bUTransfer.BankInfoId,
                                PostedDate = bUTransfer.PostedDate,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                SortOrder = item.SortOrder,
                                BudgetExpenseId = item.BudgetExpenseId,
                            };
                            bUTransferResponse.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }
                            #endregion

                            #region Insert FixedAssetLedger
                            if (item.DebitAccount.StartsWith("21"))
                            {
                                var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(item.FixedAssetId);

                                var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
                                {
                                    FixedAssetLedgerId = Guid.NewGuid().ToString(),
                                    RefId = bUTransfer.RefId,
                                    RefType = bUTransfer.RefType,
                                    RefNo = bUTransfer.RefNo,
                                    RefDate = bUTransfer.RefDate,
                                    PostedDate = bUTransfer.PostedDate,
                                    FixedAssetId = item.FixedAssetId,
                                    DepartmentId = fixedAssetEntity.DepartmentId,
                                    LifeTime = fixedAssetEntity.LifeTime,
                                    AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                                    AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                                    OrgPriceAccount = null,
                                    OrgPriceDebitAmount = item.Amount,
                                    OrgPriceCreditAmount = 0,
                                    DepreciationAccount = null,
                                    DepreciationDebitAmount = 0,
                                    DepreciationCreditAmount = fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount,
                                    CapitalAccount = item.DebitAccount,
                                    CapitalDebitAmount = item.Amount,
                                    CapitalCreditAmount = 0,
                                    JournalMemo = bUTransfer.JournalMemo,
                                    Description = item.Description,
                                    RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                                    EndYear = fixedAssetEntity.EndYear,
                                    DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                                    DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                                    EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                                    PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,
                                    Quantity = fixedAssetEntity.Quantity,
                                };
                                bUTransferResponse.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                {
                                    bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return bUTransferResponse;
                                }
                            }
                            #endregion
                        }

                        #region Sinh dinh khoan dong thoi
                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region BUTransferDetailParallel
                            if (bUTransfer.BUTransferDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var buTransferDetailParallel in bUTransfer.BUTransferDetailParallels)
                                {
                                    #region Insert Receipt Detail Parallel
                                    buTransferDetailParallel.RefId = bUTransfer.RefId;
                                    buTransferDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    buTransferDetailParallel.Amount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;

                                    if (!buTransferDetailParallel.Validate())
                                    {
                                        foreach (var error in buTransferDetailParallel.ValidationErrors)
                                            bUTransferResponse.Message += error + Environment.NewLine;
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }

                                    bUTransferResponse.Message = BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallel);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }
                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (buTransferDetailParallel.DebitAccount != null && buTransferDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder
                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = buTransferDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = buTransferDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;
                                        generalLedgerEntity.CreditAmountOC = buTransferDetailParallel.AmountOC;
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount ?? buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC,
                                            CreditAmount = buTransferDetailParallel.CreditAccount == null ? 0 : buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            CreditAmountOC = buTransferDetailParallel.CreditAccount == null ? 0 : buTransferDetailParallel.AmountOC,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder
                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }
                                    }

                                    #endregion

                                    #region Insert OriginalGeneralLedger
                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = bUTransfer.RefType,
                                        RefId = bUTransfer.RefId,
                                        RefDetailId = buTransferDetailParallel.RefDetailId,
                                        OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                        OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                        RefDate = bUTransfer.RefDate,
                                        RefNo = bUTransfer.RefNo,
                                        AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                        ActivityId = buTransferDetailParallel.ActivityId,
                                        Amount = buTransferDetailParallel.Amount,
                                        AmountOC = buTransferDetailParallel.AmountOC,
                                        //Approved = bUTransfer.Approved,
                                        BankId = buTransferDetailParallel.BankId,
                                        BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = buTransferDetailParallel.CreditAccount,
                                        DebitAccount = buTransferDetailParallel.DebitAccount,
                                        Description = buTransferDetailParallel.Description,
                                        FundStructureId = buTransferDetailParallel.FundStructureId,
                                        //ProjectActivityId = buTransferDetailParallel.ProjectActivityId,
                                        MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                        JournalMemo = bUTransfer.JournalMemo,
                                        ProjectId = buTransferDetailParallel.ProjectId,
                                        ToBankId = buTransferDetailParallel.BankId,
                                        ExchangeRate = bUTransfer.ExchangeRate,
                                        CurrencyCode = bUTransfer.CurrencyCode,
                                        PostedDate = bUTransfer.PostedDate,
                                        SortOrder = buTransferDetailParallel.SortOrder,
                                        BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                        ContractId = buTransferDetailParallel.ContractId,
                                    };
                                    bUTransferResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            AutoMapper(InsertParallel(bUTransfer, InsertParallelBy.FixedAssets), bUTransferResponse);
                        }
                        #endregion
                    }
                    #endregion

                    if (bUTransferResponse.Message != null)
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUTransferResponse;
                    }
                    bUTransferResponse.RefId = bUTransfer.RefId;
                    scope.Complete();
                }

                return bUTransferResponse;
            }
        }

        /// <summary>
        /// Updates the bu commitment request.
        /// </summary>
        /// <param name="bUTransfer">The b u commitment request.</param>
        /// <returns>BUTransferResponse.</returns>
        public BUTransferResponse UpdateBUTransfer(BUTransferEntity bUTransfer, bool isAutoGenerateParallel)
        {
            var bUTransferResponse = new BUTransferResponse { Acknowledge = AcknowledgeType.Success };

            if (bUTransfer != null && !bUTransfer.Validate())
            {
                foreach (var error in bUTransfer.ValidationErrors)
                    bUTransferResponse.Message += error + Environment.NewLine;
                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                return bUTransferResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (bUTransfer != null)
                {
                    var bUTransferByRefNo = BUTransferDao.GetBUTransferbyRefNo(bUTransfer.RefNo, bUTransfer.PostedDate);
                    if (bUTransferByRefNo != null && bUTransferByRefNo.RefId != bUTransfer.RefId && bUTransferByRefNo.PostedDate.Year == bUTransfer.PostedDate.Year)
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        bUTransferResponse.Message = string.Format("Số chứng từ \'{0}\' đã tồn tại!", bUTransfer.RefNo);
                        return bUTransferResponse;
                    }

                    bUTransferResponse.Message = BUTransferDao.UpdateBUTransfer(bUTransfer);

                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUTransferResponse;
                    }
                    bUTransferResponse.Message = BUTransferDetailDao.DeleteBUTransferDetail(bUTransfer.RefId);

                    #region Update account balance
                    //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                    UpdateAccountBalance(bUTransfer);
                    if (bUTransferResponse.Message != null)
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUTransferResponse;
                    }

                    #endregion

                    #region Delete GeneralLedger
                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUTransferResponse;
                    }
                    bUTransferResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(bUTransfer.RefId);
                    #endregion

                    #region Delete OriginalGeneralLedger
                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUTransferResponse;
                    }
                    bUTransferResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bUTransfer.RefId);
                    #endregion

                    // Xóa bảng BUTransferDetailParallel
                    bUTransferResponse.Message = BuTransferDetailParallelDao.DeleteBUTransferDetailParallelById(bUTransfer.RefId);
                    if (bUTransferResponse.Message != null)
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUTransferResponse;
                    }

                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUTransferResponse;
                    }

                    #region Details
                    if (bUTransfer.BUTransferDetails != null && bUTransfer.BUTransferDetails.Count > 0)
                    {
                        foreach (var bUTransferDetail in bUTransfer.BUTransferDetails)
                        {
                            bUTransferDetail.RefId = bUTransfer.RefId;
                            bUTransferDetail.RefDetailId = Guid.NewGuid().ToString();
                            if (!bUTransferDetail.Validate())
                            {
                                foreach (var error in bUTransferDetail.ValidationErrors)
                                    bUTransferResponse.Message += error + Environment.NewLine;
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }
                            bUTransferResponse.Message =
                                BUTransferDetailDao.InsertBUTransferDetail(bUTransferDetail);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            #region Insert to AccountBalance

                            InsertAccountBalance(bUTransfer, bUTransferDetail);

                            #endregion

                            #region Insert GeneralLedger

                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = bUTransfer.RefType,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = bUTransferDetail.AccountingObjectId,// bUTransfer.AccountingObjectId,
                                BankId = bUTransferDetail.BankId,
                                BudgetChapterCode = bUTransferDetail.BudgetChapterCode,
                                ProjectId = bUTransferDetail.ProjectId,
                                BudgetSourceId = bUTransferDetail.BudgetSourceId,
                                Description = bUTransferDetail.Description,
                                RefDetailId = bUTransferDetail.RefDetailId,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                ActivityId = bUTransferDetail.ActivityId,
                                BudgetSubKindItemCode = bUTransferDetail.BudgetSubKindItemCode,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                BudgetKindItemCode = bUTransferDetail.BudgetKindItemCode,
                                RefId = bUTransfer.RefId,
                                PostedDate = bUTransfer.PostedDate,
                                MethodDistributeId = bUTransferDetail.MethodDistributeId,
                                OrgRefNo = bUTransferDetail.OrgRefNo,
                                OrgRefDate = bUTransferDetail.OrgRefDate,
                                BudgetItemCode = bUTransferDetail.BudgetItemCode,
                                ListItemId = bUTransferDetail.ListItemId,
                                BudgetSubItemCode = bUTransferDetail.BudgetSubItemCode,
                                BudgetDetailItemCode = bUTransferDetail.BudgetDetailItemCode,
                                CashWithDrawTypeId = bUTransferDetail.CashWithDrawTypeId,
                                AccountNumber = bUTransferDetail.DebitAccount,
                                CorrespondingAccountNumber = bUTransferDetail.CreditAccount,
                                DebitAmount = bUTransferDetail.Amount,
                                DebitAmountOC = bUTransferDetail.AmountOC,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                FundStructureId = bUTransferDetail.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = bUTransfer.JournalMemo,
                                RefDate = bUTransfer.RefDate,
                                BudgetExpenseId = bUTransferDetail.BudgetExpenseId,
                                SortOrder = bUTransferDetail.SortOrder,
                                ContractId = bUTransferDetail.ContractId,
                                CapitalPlanId = bUTransferDetail.CapitalPlanId

                            };
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            //insert lan 2
                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                            generalLedgerEntity.AccountNumber = bUTransferDetail.CreditAccount;
                            generalLedgerEntity.CorrespondingAccountNumber = bUTransferDetail.DebitAccount;
                            generalLedgerEntity.DebitAmount = 0;
                            generalLedgerEntity.DebitAmountOC = 0;
                            generalLedgerEntity.CreditAmount = bUTransferDetail.Amount;
                            generalLedgerEntity.CreditAmountOC = bUTransferDetail.AmountOC;
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                            #endregion

                            #region Insert OriginalGeneralLedger

                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bUTransfer.RefType,
                                RefId = bUTransfer.RefId,
                                RefDetailId = bUTransferDetail.RefDetailId,
                                OrgRefDate = bUTransferDetail.OrgRefDate,
                                OrgRefNo = bUTransferDetail.OrgRefNo,
                                RefDate = bUTransfer.RefDate,
                                RefNo = bUTransfer.RefNo,

                                AccountingObjectId = bUTransferDetail.AccountingObjectId,
                                ActivityId = bUTransferDetail.ActivityId,
                                Amount = bUTransferDetail.Amount,
                                AmountOC = bUTransferDetail.AmountOC,
                                Approved = bUTransferDetail.Approved,
                                BankId = bUTransferDetail.BankId,
                                BudgetChapterCode = bUTransferDetail.BudgetChapterCode,
                                BudgetDetailItemCode = bUTransferDetail.BudgetDetailItemCode,
                                BudgetItemCode = bUTransferDetail.BudgetItemCode,
                                BudgetKindItemCode = bUTransferDetail.BudgetKindItemCode,
                                BudgetSourceId = bUTransferDetail.BudgetSourceId,
                                BudgetSubItemCode = bUTransferDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = bUTransferDetail.BudgetSubKindItemCode,
                                CashWithDrawTypeId = bUTransferDetail.CashWithDrawTypeId,
                                CreditAccount = bUTransferDetail.CreditAccount,
                                DebitAccount = bUTransferDetail.DebitAccount,
                                Description = bUTransferDetail.Description,
                                FundStructureId = bUTransferDetail.FundStructureId,
                                //       TaxAmount = bUTransferDetail.TaxAmount,
                                ProjectActivityId = bUTransferDetail.ProjectActivityId,
                                MethodDistributeId = bUTransferDetail.MethodDistributeId,
                                JournalMemo = bUTransfer.JournalMemo,
                                ProjectId = bUTransferDetail.ProjectId,
                                ToBankId = bUTransfer.BankInfoId,
                                PostedDate = bUTransfer.PostedDate,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                BudgetExpenseId = bUTransferDetail.BudgetExpenseId,
                                SortOrder = bUTransferDetail.SortOrder,
                                ContractId = bUTransferDetail.ContractId,
                            };
                            bUTransferResponse.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            #endregion

                        }

                        #region Sinh dinh khoan dong thoi

                        // delete bang BAWithDrawDetailParallel
                        bUTransferResponse.Message = BuTransferDetailParallelDao.DeleteBUTransferDetailParallelById(bUTransfer.RefId);

                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                        {
                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            return bUTransferResponse;
                        }

                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region CAReceiptDetailParallel

                            if (bUTransfer.BUTransferDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var buTransferDetailParallel in bUTransfer.BUTransferDetailParallels)
                                {
                                    #region Insert Receipt Detail Parallel

                                    buTransferDetailParallel.RefId = bUTransfer.RefId;
                                    buTransferDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    

                                    if (!buTransferDetailParallel.Validate())
                                    {
                                        foreach (var error in buTransferDetailParallel.ValidationErrors)
                                            bUTransferResponse.Message += error + Environment.NewLine;
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }

                                    bUTransferResponse.Message = BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallel);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (buTransferDetailParallel.DebitAccount != null && buTransferDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder,
                                            ContractId = buTransferDetailParallel.ContractId,
                                            CapitalPlanId = buTransferDetailParallel.CapitalPlanId
                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = buTransferDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = buTransferDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;
                                        generalLedgerEntity.CreditAmountOC = buTransferDetailParallel.AmountOC;
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount ?? buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC,
                                            CreditAmount = buTransferDetailParallel.CreditAccount == null ? 0 : buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            CreditAmountOC = buTransferDetailParallel.CreditAccount == null ? 0 : buTransferDetailParallel.AmountOC,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder,
                                            ContractId = buTransferDetailParallel.ContractId,
                                            CapitalPlanId = buTransferDetailParallel.CapitalPlanId
                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }
                                    }


                                    #endregion

                                    #region Insert OriginalGeneralLedger

                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = bUTransfer.RefType,
                                        RefId = bUTransfer.RefId,
                                        RefDetailId = buTransferDetailParallel.RefDetailId,
                                        OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                        OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                        RefDate = bUTransfer.RefDate,
                                        RefNo = bUTransfer.RefNo,
                                        AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                        ActivityId = buTransferDetailParallel.ActivityId,
                                        Amount = buTransferDetailParallel.Amount,
                                        AmountOC = buTransferDetailParallel.AmountOC,
                                        //Approved = receiptDetail.Approved,
                                        BankId = buTransferDetailParallel.BankId,
                                        BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = buTransferDetailParallel.CreditAccount,
                                        DebitAccount = buTransferDetailParallel.DebitAccount,
                                        Description = buTransferDetailParallel.Description,
                                        FundStructureId = buTransferDetailParallel.FundStructureId,
                                        //ProjectActivityId = buTransferDetailParallel.ProjectActivityId,
                                        MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                        JournalMemo = bUTransfer.JournalMemo,
                                        ProjectId = buTransferDetailParallel.ProjectId,
                                        ToBankId = buTransferDetailParallel.BankId,
                                        ExchangeRate = bUTransfer.ExchangeRate,
                                        CurrencyCode = bUTransfer.CurrencyCode,
                                        PostedDate = bUTransfer.PostedDate,
                                        SortOrder = buTransferDetailParallel.SortOrder,
                                        BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                        ContractId = buTransferDetailParallel.ContractId
                                    };
                                    bUTransferResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }

                                    #endregion
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            AutoMapper(InsertParallel(bUTransfer, InsertParallelBy.Details), bUTransferResponse);
                        }

                        #endregion
                    }
                    #endregion

                    #region Nhập mua hàng hóa chuyển khoản
                    if (bUTransfer.BUTransferDetailPurchases != null && bUTransfer.BUTransferDetailPurchases.Count > 0)
                    {
                        #region Xóa 1 số thứ trước khi thêm
                        // xóa tất rồi thêm lại => nông dân
                        bUTransferResponse.Message = BUTransferDetailPurchaseDao.DeleteBUTransferDetailPurchases(bUTransfer.RefId);
                        if (bUTransferResponse.Message != null)
                        {
                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bUTransferResponse;
                        }

                        // Xóa bảng InventoryLedger
                        bUTransferResponse.Message = InventoryLedgerDao.DeleteInventoryLedger(bUTransfer.RefId);
                        if (bUTransferResponse.Message != null)
                        {
                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bUTransferResponse;
                        }

                        // Xóa bảng BUTransferDetailParallel
                        bUTransferResponse.Message = BuTransferDetailParallelDao.DeleteBUTransferDetailParallelById(bUTransfer.RefId);
                        if (bUTransferResponse.Message != null)
                        {
                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bUTransferResponse;
                        }
                        #endregion

                        foreach (var item in bUTransfer.BUTransferDetailPurchases)
                        {
                            #region Detail
                            item.RefId = bUTransfer.RefId;
                            //if (string.IsNullOrEmpty(item.RefDetailId))
                            item.RefDetailId = Guid.NewGuid().ToString();

                            if (!item.Validate())
                            {
                                foreach (var error in item.ValidationErrors)
                                    bUTransferResponse.Message += error + Environment.NewLine;
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            bUTransferResponse.Message = BUTransferDetailPurchaseDao.InsertBUTransferDetailPurchase(item);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }
                            #endregion

                            #region Insert to AccountBalance
                            InsertAccountBalance(bUTransfer, item);
                            #endregion

                            #region Insert GeneralLedger
                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = bUTransfer.RefType,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = item.AccountingObjectId,
                                BankId = bUTransfer.BankInfoId,
                                BudgetChapterCode = item.BudgetChapterCode,
                                ProjectId = item.ProjectId,
                                BudgetSourceId = item.BudgetSourceId,
                                Description = item.Description,
                                RefDetailId = item.RefDetailId,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                ActivityId = item.ActivityId,
                                BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                BudgetKindItemCode = item.BudgetKindItemCode,
                                RefId = bUTransfer.RefId,
                                PostedDate = bUTransfer.PostedDate,
                                MethodDistributeId = item.MethodDistributeId,
                                OrgRefNo = item.OrgRefNo,
                                OrgRefDate = item.OrgRefDate,
                                BudgetItemCode = item.BudgetItemCode,
                                ListItemId = item.ListItemId,
                                BudgetSubItemCode = item.BudgetSubItemCode,
                                BudgetDetailItemCode = item.BudgetDetailItemCode,
                                CashWithDrawTypeId = item.CashWithdrawTypeId,
                                AccountNumber = item.DebitAccount,
                                CorrespondingAccountNumber = item.CreditAccount,
                                DebitAmount = item.Amount,
                                DebitAmountOC = item.Amount,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                FundStructureId = item.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = bUTransfer.JournalMemo,
                                RefDate = bUTransfer.RefDate,
                                BudgetExpenseId = item.BudgetExpenseId,
                                SortOrder = item.SortOrder
                            };
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            //insert lan 2
                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                            generalLedgerEntity.AccountNumber = item.CreditAccount;
                            generalLedgerEntity.CorrespondingAccountNumber = item.DebitAccount;
                            generalLedgerEntity.DebitAmount = 0;
                            generalLedgerEntity.DebitAmountOC = 0;
                            generalLedgerEntity.CreditAmount = item.Amount;
                            generalLedgerEntity.CreditAmountOC = item.Amount;
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bUTransfer.RefType,
                                RefId = bUTransfer.RefId,
                                RefDetailId = item.RefDetailId,
                                OrgRefDate = item.OrgRefDate,
                                OrgRefNo = item.OrgRefNo,
                                RefDate = bUTransfer.RefDate,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = item.AccountingObjectId,
                                ActivityId = item.ActivityId,
                                Amount = item.Amount,
                                AmountOC = item.Amount,
                                Approved = item.Approved,
                                BankId = bUTransfer.BankInfoId,
                                BudgetChapterCode = item.BudgetChapterCode,
                                BudgetDetailItemCode = item.BudgetDetailItemCode,
                                BudgetItemCode = item.BudgetItemCode,
                                BudgetKindItemCode = item.BudgetKindItemCode,
                                BudgetSourceId = item.BudgetSourceId,
                                BudgetSubItemCode = item.BudgetSubItemCode,
                                BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                CashWithDrawTypeId = item.CashWithdrawTypeId,
                                CreditAccount = item.CreditAccount,
                                DebitAccount = item.DebitAccount,
                                Description = item.Description,
                                FundStructureId = item.FundStructureId,
                                TaxAmount = item.TaxAmount,
                                ProjectActivityId = item.ProjectActivityId,
                                MethodDistributeId = item.MethodDistributeId,
                                JournalMemo = bUTransfer.JournalMemo,
                                ProjectId = item.ProjectId,
                                ToBankId = bUTransfer.BankInfoId,
                                PostedDate = bUTransfer.PostedDate,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                SortOrder = item.SortOrder,
                                BudgetExpenseId = item.BudgetExpenseId,
                            };
                            bUTransferResponse.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }
                            #endregion

                            #region Insert into Inventory Ledger
                            var inventoryLedgerEntity = new BusinessEntities.Business.InwardOutward.InventoryLedgerEntity
                            {

                                InventoryLedgerId = Guid.NewGuid().ToString(),
                                RefId = item.RefId,
                                RefType = bUTransfer.RefType,
                                RefNo = bUTransfer.RefNo,
                                RefDate = bUTransfer.RefDate,
                                PostedDate = bUTransfer.PostedDate,
                                StockId = item.StockId,
                                InventoryItemId = item.InventoryItemId,
                                BudgetSourceId = item.BudgetSourceId,
                                Description = item.Description,
                                RefDetailId = item.RefDetailId,
                                Unit = item.Unit,
                                UnitPrice = item.UnitPrice,
                                InwardQuantity = item.Quantity,
                                OutwardQuantity = 0,
                                OutwardAmount = 0,
                                InwardAmount = item.Amount,
                                JournalMemo = item.Description,
                                ExpiryDate = item.ExpiryDate,
                                LotNo = item.LotNo,
                                RefOrder = bUTransfer.RefOrder,
                                SortOrder = item.SortOrder,
                                AccountNumber = item.DebitAccount,
                                CorrespondingAccountNumber = item.CreditAccount,
                                InwardAmountBalance = 0,
                                InwardAmountBalanceAfter = 0,
                                InwardQuantityBalance = 0,
                                UnitPriceBalance = 0,
                            };
                            bUTransferResponse.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return bUTransferResponse;
                            }
                            #endregion
                        }

                        #region Sinh dinh khoan dong thoi
                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region BUTransferDetailParallel
                            if (bUTransfer.BUTransferDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var buTransferDetailParallel in bUTransfer.BUTransferDetailParallels)
                                {
                                    #region Insert Receipt Detail Parallel
                                    buTransferDetailParallel.RefId = bUTransfer.RefId;
                                    buTransferDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    buTransferDetailParallel.Amount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;

                                    if (!buTransferDetailParallel.Validate())
                                    {
                                        foreach (var error in buTransferDetailParallel.ValidationErrors)
                                            bUTransferResponse.Message += error + Environment.NewLine;
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }

                                    bUTransferResponse.Message = BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallel);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }
                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (buTransferDetailParallel.DebitAccount != null && buTransferDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = bUTransfer.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder

                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = buTransferDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = buTransferDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;
                                        generalLedgerEntity.CreditAmountOC = buTransferDetailParallel.AmountOC;
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = bUTransfer.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount ?? buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC,
                                            CreditAmount = buTransferDetailParallel.CreditAccount == null ? 0 : buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            CreditAmountOC = buTransferDetailParallel.CreditAccount == null ? 0 : buTransferDetailParallel.AmountOC,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder

                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }
                                    }
                                    #endregion

                                    #region Insert OriginalGeneralLedger
                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = bUTransfer.RefType,
                                        RefId = bUTransfer.RefId,
                                        RefDetailId = buTransferDetailParallel.RefDetailId,
                                        OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                        OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                        RefDate = bUTransfer.RefDate,
                                        RefNo = bUTransfer.RefNo,
                                        AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                        ActivityId = buTransferDetailParallel.ActivityId,
                                        Amount = buTransferDetailParallel.Amount,
                                        AmountOC = buTransferDetailParallel.AmountOC,
                                        //Approved = bUTransfer.Approved,
                                        BankId = buTransferDetailParallel.BankId,
                                        BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = buTransferDetailParallel.CreditAccount,
                                        DebitAccount = buTransferDetailParallel.DebitAccount,
                                        Description = buTransferDetailParallel.Description,
                                        FundStructureId = buTransferDetailParallel.FundStructureId,
                                        //ProjectActivityId = buTransferDetailParallel.ProjectActivityId,
                                        MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                        JournalMemo = bUTransfer.JournalMemo,
                                        ProjectId = buTransferDetailParallel.ProjectId,
                                        ToBankId = buTransferDetailParallel.BankId,
                                        ExchangeRate = bUTransfer.ExchangeRate,
                                        CurrencyCode = bUTransfer.CurrencyCode,
                                        PostedDate = bUTransfer.PostedDate,
                                        SortOrder = buTransferDetailParallel.SortOrder,
                                        BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                        ContractId = buTransferDetailParallel.ContractId,
                                    };
                                    bUTransferResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            AutoMapper(InsertParallel(bUTransfer, InsertParallelBy.Purchases), bUTransferResponse);
                        }
                        #endregion
                    }
                    #endregion

                    #region Nhập mua TSCĐ chuyển khoản
                    if (bUTransfer.BUTransferDetailFixedAssets != null && bUTransfer.BUTransferDetailFixedAssets.Count > 0)
                    {
                        #region Xóa 1 số thứ trước khi thêm
                        // xóa tất rồi thêm lại => nông dân
                        bUTransferResponse.Message = BUTransferDetailPurchaseDao.DeleteBUTransferDetailFixedAssets(bUTransfer.RefId);

                        if (bUTransferResponse.Message != null)
                        {
                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bUTransferResponse;
                        }

                        // Xóa bảng FixAssetLedger
                        bUTransferResponse.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(bUTransfer.RefId, bUTransfer.RefType);
                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                        {
                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bUTransferResponse;
                        }

                        // Xóa bảng BUTransferDetailParallel
                        bUTransferResponse.Message = BuTransferDetailParallelDao.DeleteBUTransferDetailParallelById(bUTransfer.RefId);
                        if (bUTransferResponse.Message != null)
                        {
                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bUTransferResponse;
                        }
                        #endregion

                        foreach (var item in bUTransfer.BUTransferDetailFixedAssets)
                        {
                            #region Detail
                            item.RefId = bUTransfer.RefId;
                            //if (string.IsNullOrEmpty(item.RefDetailId))
                            item.RefDetailId = Guid.NewGuid().ToString();

                            if (!item.Validate())
                            {
                                foreach (var error in item.ValidationErrors)
                                    bUTransferResponse.Message += error + Environment.NewLine;
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            bUTransferResponse.Message = BUTransferDetailPurchaseDao.InsertBUTransferDetailFixedAsset(item);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }
                            #endregion

                            #region Insert to AccountBalance
                            InsertAccountBalance(bUTransfer, item);
                            #endregion

                            #region Insert GeneralLedger
                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = bUTransfer.RefType,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = item.AccountingObjectId,
                                BankId = bUTransfer.BankInfoId,
                                BudgetChapterCode = item.BudgetChapterCode,
                                ProjectId = item.ProjectId,
                                BudgetSourceId = item.BudgetSourceId,
                                Description = item.Description,
                                RefDetailId = item.RefDetailId,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                ActivityId = item.ActivityId,
                                BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                BudgetKindItemCode = item.BudgetKindItemCode,
                                RefId = bUTransfer.RefId,
                                PostedDate = bUTransfer.PostedDate,
                                MethodDistributeId = item.MethodDistributeId,
                                OrgRefNo = item.OrgRefNo,
                                OrgRefDate = item.OrgRefDate,
                                BudgetItemCode = item.BudgetItemCode,
                                ListItemId = item.ListItemId,
                                BudgetSubItemCode = item.BudgetSubItemCode,
                                BudgetDetailItemCode = item.BudgetDetailItemCode,
                                CashWithDrawTypeId = item.CashWithdrawTypeId,
                                AccountNumber = item.DebitAccount,
                                CorrespondingAccountNumber = item.CreditAccount,
                                DebitAmount = item.Amount,
                                DebitAmountOC = item.Amount,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                FundStructureId = item.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = bUTransfer.JournalMemo,
                                RefDate = bUTransfer.RefDate,
                                BudgetExpenseId = item.BudgetExpenseId,
                                SortOrder = item.SortOrder
                            };
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }

                            //insert lan 2
                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                            generalLedgerEntity.AccountNumber = item.CreditAccount;
                            generalLedgerEntity.CorrespondingAccountNumber = item.DebitAccount;
                            generalLedgerEntity.DebitAmount = 0;
                            generalLedgerEntity.DebitAmountOC = 0;
                            generalLedgerEntity.CreditAmount = item.Amount;
                            generalLedgerEntity.CreditAmountOC = item.Amount;
                            bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bUTransfer.RefType,
                                RefId = bUTransfer.RefId,
                                RefDetailId = item.RefDetailId,
                                OrgRefDate = item.OrgRefDate,
                                OrgRefNo = item.OrgRefNo,
                                RefDate = bUTransfer.RefDate,
                                RefNo = bUTransfer.RefNo,
                                AccountingObjectId = item.AccountingObjectId,
                                ActivityId = item.ActivityId,
                                Amount = item.Amount,
                                AmountOC = item.Amount,
                                Approved = item.Approved,
                                BankId = bUTransfer.BankInfoId,
                                BudgetChapterCode = item.BudgetChapterCode,
                                BudgetDetailItemCode = item.BudgetDetailItemCode,
                                BudgetItemCode = item.BudgetItemCode,
                                BudgetKindItemCode = item.BudgetKindItemCode,
                                BudgetSourceId = item.BudgetSourceId,
                                BudgetSubItemCode = item.BudgetSubItemCode,
                                BudgetSubKindItemCode = item.BudgetSubKindItemCode,
                                CashWithDrawTypeId = item.CashWithdrawTypeId,
                                CreditAccount = item.CreditAccount,
                                DebitAccount = item.DebitAccount,
                                Description = item.Description,
                                FundStructureId = item.FundStructureId,
                                TaxAmount = item.TaxAmount,
                                ProjectActivityId = item.ProjectActivityId,
                                MethodDistributeId = item.MethodDistributeId,
                                JournalMemo = bUTransfer.JournalMemo,
                                ProjectId = item.ProjectId,
                                ToBankId = bUTransfer.BankInfoId,
                                PostedDate = bUTransfer.PostedDate,
                                CurrencyCode = bUTransfer.CurrencyCode,
                                ExchangeRate = bUTransfer.ExchangeRate,
                                SortOrder = item.SortOrder,
                                BudgetExpenseId = item.BudgetExpenseId,
                            };
                            bUTransferResponse.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                            {
                                bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bUTransferResponse;
                            }
                            #endregion

                            #region Insert FixedAssetLedger
                            if (item.DebitAccount.StartsWith("21"))
                            {
                                var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(item.FixedAssetId);

                                var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
                                {
                                    FixedAssetLedgerId = Guid.NewGuid().ToString(),
                                    RefId = bUTransfer.RefId,
                                    RefType = bUTransfer.RefType,
                                    RefNo = bUTransfer.RefNo,
                                    RefDate = bUTransfer.RefDate,
                                    PostedDate = bUTransfer.PostedDate,
                                    FixedAssetId = item.FixedAssetId,
                                    DepartmentId = fixedAssetEntity.DepartmentId,
                                    LifeTime = fixedAssetEntity.LifeTime,
                                    AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                                    AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                                    OrgPriceAccount = item.DebitAccount,
                                    OrgPriceDebitAmount = item.Amount,
                                    OrgPriceCreditAmount = 0,
                                    DepreciationAccount = null,
                                    DepreciationDebitAmount = 0,
                                    DepreciationCreditAmount = fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount,
                                    CapitalAccount = item.DebitAccount,
                                    CapitalDebitAmount = item.Amount,
                                    CapitalCreditAmount = 0,
                                    JournalMemo = bUTransfer.JournalMemo,
                                    Description = item.Description,
                                    RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                                    EndYear = fixedAssetEntity.EndYear,
                                    DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                                    DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                                    EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                                    PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,
                                    Quantity = fixedAssetEntity.Quantity,
                                };
                                bUTransferResponse.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                {
                                    bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return bUTransferResponse;
                                }
                            }
                            #endregion
                        }

                        #region Sinh dinh khoan dong thoi
                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region BUTransferDetailParallel
                            if (bUTransfer.BUTransferDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var buTransferDetailParallel in bUTransfer.BUTransferDetailParallels)
                                {
                                    #region Insert Receipt Detail Parallel
                                    buTransferDetailParallel.RefId = bUTransfer.RefId;
                                    buTransferDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    buTransferDetailParallel.Amount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;

                                    if (!buTransferDetailParallel.Validate())
                                    {
                                        foreach (var error in buTransferDetailParallel.ValidationErrors)
                                            bUTransferResponse.Message += error + Environment.NewLine;
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }

                                    bUTransferResponse.Message = BuTransferDetailParallelDao.InsertBUTransferDetailParallel(buTransferDetailParallel);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }
                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (buTransferDetailParallel.DebitAccount != null && buTransferDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder
                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = buTransferDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = buTransferDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;
                                        generalLedgerEntity.CreditAmountOC = buTransferDetailParallel.AmountOC;
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bUTransfer.RefType,
                                            RefNo = bUTransfer.RefNo,
                                            AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                            //BankId = bUTransfer.BankId,
                                            BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = buTransferDetailParallel.ProjectId,
                                            BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                            Description = buTransferDetailParallel.Description,
                                            RefDetailId = buTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bUTransfer.ExchangeRate,
                                            ActivityId = buTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bUTransfer.CurrencyCode,
                                            BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bUTransfer.RefId,
                                            PostedDate = bUTransfer.PostedDate,
                                            MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                            ListItemId = buTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = buTransferDetailParallel.DebitAccount ?? buTransferDetailParallel.CreditAccount,
                                            DebitAmount = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            DebitAmountOC = buTransferDetailParallel.DebitAccount == null ? 0 : buTransferDetailParallel.AmountOC,
                                            CreditAmount = buTransferDetailParallel.CreditAccount == null ? 0 : buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate,
                                            CreditAmountOC = buTransferDetailParallel.CreditAccount == null ? 0 : buTransferDetailParallel.AmountOC,
                                            FundStructureId = buTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bUTransfer.JournalMemo,
                                            RefDate = bUTransfer.RefDate,
                                            BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                            SortOrder = buTransferDetailParallel.SortOrder
                                        };
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                        {
                                            bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bUTransferResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = buTransferDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = buTransferDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = buTransferDetailParallel.AmountOC * bUTransfer.ExchangeRate;
                                        generalLedgerEntity.CreditAmountOC = buTransferDetailParallel.AmountOC;
                                        bUTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    }
                                       
                                    #endregion

                                    #region Insert OriginalGeneralLedger
                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = bUTransfer.RefType,
                                        RefId = bUTransfer.RefId,
                                        RefDetailId = buTransferDetailParallel.RefDetailId,
                                        OrgRefDate = buTransferDetailParallel.OrgRefDate,
                                        OrgRefNo = buTransferDetailParallel.OrgRefNo,
                                        RefDate = bUTransfer.RefDate,
                                        RefNo = bUTransfer.RefNo,
                                        AccountingObjectId = buTransferDetailParallel.AccountingObjectId,
                                        ActivityId = buTransferDetailParallel.ActivityId,
                                        Amount = buTransferDetailParallel.Amount,
                                        AmountOC = buTransferDetailParallel.AmountOC,
                                        //Approved = bUTransfer.Approved,
                                        BankId = buTransferDetailParallel.BankId,
                                        BudgetChapterCode = buTransferDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = buTransferDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = buTransferDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = buTransferDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = buTransferDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = buTransferDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = buTransferDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = buTransferDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = buTransferDetailParallel.CreditAccount,
                                        DebitAccount = buTransferDetailParallel.DebitAccount,
                                        Description = buTransferDetailParallel.Description,
                                        FundStructureId = buTransferDetailParallel.FundStructureId,
                                        //ProjectActivityId = buTransferDetailParallel.ProjectActivityId,
                                        MethodDistributeId = buTransferDetailParallel.MethodDistributeId,
                                        JournalMemo = bUTransfer.JournalMemo,
                                        ProjectId = buTransferDetailParallel.ProjectId,
                                        ToBankId = buTransferDetailParallel.BankId,
                                        ExchangeRate = bUTransfer.ExchangeRate,
                                        CurrencyCode = bUTransfer.CurrencyCode,
                                        PostedDate = bUTransfer.PostedDate,
                                        SortOrder = buTransferDetailParallel.SortOrder,
                                        BudgetExpenseId = buTransferDetailParallel.BudgetExpenseId,
                                        ContractId = buTransferDetailParallel.ContractId,
                                    };
                                    bUTransferResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                                    {
                                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bUTransferResponse;
                                    }
                                    #endregion
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            AutoMapper(InsertParallel(bUTransfer, InsertParallelBy.FixedAssets), bUTransferResponse);
                        }
                        #endregion
                    }
                    #endregion

                    if (bUTransferResponse.Message != null)
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUTransferResponse;
                    }
                    bUTransferResponse.RefId = bUTransfer.RefId;
                    scope.Complete();
                }

                return bUTransferResponse;
            }
        }

        /// <summary>
        /// Deletes the bu commitment request.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BUTransferResponse.</returns>
        public BUTransferResponse DeleteBUTransfer(string refId)
        {
            var bUTransferResponse = new BUTransferResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                try
                {
                    var bUTransferForDelete = BUTransferDao.GetBUTransferbyRefId(refId);

                    bUTransferResponse.Message = BUTransferDao.DeleteBUTransfer(bUTransferForDelete);

                    if (bUTransferResponse.Message != null)
                    {
                        if (bUTransferResponse.Message.Contains("BUTransferRefID"))
                            bUTransferResponse.Message = "Chứng từ chuyển khoản trả lương đã được liên kết với chứng từ khác. Bạn không thể xóa!";

                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUTransferResponse;
                    }

                    #region Update account balance
                    //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                    UpdateAccountBalance(bUTransferForDelete);
                    if (bUTransferResponse.Message != null)
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUTransferResponse;
                    }

                    #endregion

                    #region Delete GeneralLedger
                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUTransferResponse;
                    }
                    bUTransferResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(bUTransferForDelete.RefId);
                    #endregion

                    #region Delete OriginalGeneralLedger
                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUTransferResponse;
                    }
                    bUTransferResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bUTransferForDelete.RefId);
                    #endregion

                    #region DeleteInventoryLedger

                    bUTransferResponse.Message = InventoryLedgerDao.DeleteInventoryLedger(bUTransferForDelete.RefId);
                    if (bUTransferResponse.Message != null)
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUTransferResponse;
                    }

                    #endregion

                    scope.Complete();
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("BUTransferRefID"))
                        bUTransferResponse.Message = "Chứng từ chuyển khoản trả lương đã được liên kết với chứng từ khác. Bạn không thể xóa!";

                    bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return bUTransferResponse;
                }

            }

            return bUTransferResponse;
        }

        /// <summary>
        /// Deletes the bu transfer by bu plan withdraw reference identifier.
        /// </summary>
        /// <param name="buPlanWithdrawRefId">The bu plan withdraw reference identifier.</param>
        /// <returns></returns>
        public BUTransferResponse DeleteBUTransferByBUPlanWithdrawRefId(string buPlanWithdrawRefId)
        {
            var bUTransferResponse = new BUTransferResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                try
                {
                    var bUTransferForDelete = BUTransferDao.GetBUTransferByBUPlanWithdrawRefId(buPlanWithdrawRefId);

                    bUTransferResponse.Message = BUTransferDao.DeleteBUTransferByBUPlanWithdrawRefId(bUTransferForDelete);

                    if (bUTransferResponse.Message != null)
                    {
                        if (bUTransferResponse.Message.Contains("BUPlanWithdrawRefID"))
                            bUTransferResponse.Message = "Chứng từ chuyển khoản trả lương đã được liên kết với chứng từ khác. Bạn không thể xóa!";

                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUTransferResponse;
                    }

                    #region Update account balance
                    //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                    UpdateAccountBalance(bUTransferForDelete);
                    if (bUTransferResponse.Message != null)
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUTransferResponse;
                    }

                    #endregion

                    #region Delete GeneralLedger
                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUTransferResponse;
                    }
                    bUTransferResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(bUTransferForDelete.RefId);
                    #endregion

                    #region Delete OriginalGeneralLedger
                    if (!string.IsNullOrEmpty(bUTransferResponse.Message))
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        return bUTransferResponse;
                    }
                    bUTransferResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bUTransferForDelete.RefId);
                    #endregion

                    #region DeleteInventoryLedger

                    bUTransferResponse.Message = InventoryLedgerDao.DeleteInventoryLedger(bUTransferForDelete.RefId);
                    if (bUTransferResponse.Message != null)
                    {
                        bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bUTransferResponse;
                    }

                    #endregion

                    scope.Complete();
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("BUPlanWithdrawRefID"))
                        bUTransferResponse.Message = "Chứng từ chuyển khoản trả lương đã được liên kết với chứng từ khác. Bạn không thể xóa!";

                    bUTransferResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return bUTransferResponse;
                }

            }

            return bUTransferResponse;
        }

        #region Insert/Update AccountBalance Function

        /// <summary>
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="paymentDetail">The payment detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(BUTransferEntity bUTransferEntity, BUTransferDetailEntity bUTransferDetailEntity)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = bUTransferDetailEntity.DebitAccount,
                //CurrencyCode = bUTransferEntity.CurrencyCode,
                ExchangeRate = bUTransferEntity.ExchangeRate,
                BalanceDate = bUTransferEntity.PostedDate,
                MovementDebitAmountOC = bUTransferDetailEntity.AmountOC,
                MovementDebitAmount = bUTransferDetailEntity.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = bUTransferDetailEntity.BudgetSourceId,
                BudgetChapterCode = bUTransferDetailEntity.BudgetChapterCode,
                BudgetKindItemCode = bUTransferDetailEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = bUTransferDetailEntity.BudgetSubKindItemCode,
                BudgetItemCode = bUTransferDetailEntity.BudgetItemCode,
                BudgetSubItemCode = bUTransferDetailEntity.BudgetSubItemCode,
                MethodDistributeId = bUTransferDetailEntity.MethodDistributeId,
                AccountingObjectId = bUTransferEntity.AccountingObjectId,
                ActivityId = bUTransferDetailEntity.ActivityId,
                ProjectId = bUTransferDetailEntity.ProjectId,
                //   BankAccount = bUTransferDetailEntity.BankId,
                FundStructureId = bUTransferDetailEntity.FundStructureId,
                ProjectActivityId = bUTransferDetailEntity.ProjectActivityId,
                BudgetDetailItemCode = bUTransferDetailEntity.BudgetDetailItemCode
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="paymentDetail">The payment detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(BUTransferEntity bUTransferEntity, BUTransferDetailEntity bUTransferDetailEntity)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = bUTransferDetailEntity.CreditAccount,
                //   CurrencyCode = bUTransferEntity.CurrencyCode,
                ExchangeRate = bUTransferEntity.ExchangeRate,
                BalanceDate = bUTransferEntity.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = bUTransferDetailEntity.AmountOC,
                MovementCreditAmount = bUTransferDetailEntity.Amount,
                BudgetSourceId = bUTransferDetailEntity.BudgetSourceId,
                BudgetChapterCode = bUTransferDetailEntity.BudgetChapterCode,
                BudgetKindItemCode = bUTransferDetailEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = bUTransferDetailEntity.BudgetSubKindItemCode,
                BudgetItemCode = bUTransferDetailEntity.BudgetItemCode,
                BudgetSubItemCode = bUTransferDetailEntity.BudgetSubItemCode,
                MethodDistributeId = bUTransferDetailEntity.MethodDistributeId,
                AccountingObjectId = bUTransferEntity.AccountingObjectId,
                ActivityId = bUTransferDetailEntity.ActivityId,
                ProjectId = bUTransferDetailEntity.ProjectId,
                //    BankAccount = bUTransferDetailEntity.BankId,
                FundStructureId = bUTransferDetailEntity.FundStructureId,
                ProjectActivityId = bUTransferDetailEntity.ProjectActivityId,
                BudgetDetailItemCode = bUTransferDetailEntity.BudgetDetailItemCode
            };
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="accountBalanceEntity">The account balance entity.</param>
        /// <param name="movementAmount">The movement amount.</param>
        /// <param name="movementAmountExchange">The movement amount exchange.</param>
        /// <param name="isMovementAmount">if set to <c>true</c> [is movement amount].</param>
        /// <param name="balanceSide">The balance side.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(AccountBalanceEntity accountBalanceEntity, decimal movementAmount, decimal movementAmountExchange,
            bool isMovementAmount, int balanceSide)
        {
            string message;
            // cập nhật bên TK nợ
            if (balanceSide == 1)
            {
                accountBalanceEntity.ExchangeRate = accountBalanceEntity.ExchangeRate;
                if (isMovementAmount)
                {
                    accountBalanceEntity.MovementDebitAmount = accountBalanceEntity.MovementDebitAmount + movementAmount;
                    accountBalanceEntity.MovementDebitAmountOC = accountBalanceEntity.MovementDebitAmountOC + movementAmountExchange;
                }
                else
                {
                    accountBalanceEntity.MovementDebitAmount = accountBalanceEntity.MovementDebitAmount - movementAmount;
                    accountBalanceEntity.MovementDebitAmountOC = accountBalanceEntity.MovementDebitAmountOC - movementAmountExchange;
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
                    accountBalanceEntity.MovementCreditAmount = accountBalanceEntity.MovementCreditAmount + movementAmount;
                    accountBalanceEntity.MovementCreditAmountOC = accountBalanceEntity.MovementCreditAmountOC + movementAmountExchange;
                }
                else
                {
                    accountBalanceEntity.MovementCreditAmount = accountBalanceEntity.MovementCreditAmount - movementAmount;
                    accountBalanceEntity.MovementCreditAmountOC = accountBalanceEntity.MovementCreditAmountOC - movementAmountExchange;
                }
                message = AccountBalanceDao.UpdateAccountBalance(accountBalanceEntity);
                if (message != null)
                    return message;
            }
            return null;
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(BUTransferEntity bUTransferEntity)
        {
            var bUTransferDetails = BUTransferDetailDao.GetBUTransferDetailbyRefId(bUTransferEntity.RefId);
            foreach (var bUTransferDetail in bUTransferDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(bUTransferEntity, bUTransferDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(bUTransferEntity, bUTransferDetail);
                var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
                if (accountBalanceForCreditExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                        accountBalanceForCredit.MovementCreditAmount, false, 2);
                    if (message != null)
                        return message;
                }
            }
            return null;
        }

        /// <summary>
        /// Inserts the account balance.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="paymentDetail">The payment detail.</param>
        public void InsertAccountBalance(BUTransferEntity bUTransferEntity, BUTransferDetailEntity bUTransferDetailEntity)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(bUTransferEntity, bUTransferDetailEntity);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(bUTransferEntity, bUTransferDetailEntity);
            var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
            if (accountBalanceForCreditExit != null)
                UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                    accountBalanceForCredit.MovementCreditAmount, true, 2);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
        }
        #endregion

        #region Thêm số dư đầu kì tài khoản khi nhập mới hàng hóa qua chuyển khoản
        public void InsertAccountBalance(BUTransferEntity bUTransferEntity, BUTransferDetailPurchaseEntity entityDetail)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(bUTransferEntity, entityDetail);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(bUTransferEntity, entityDetail);
            var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
            if (accountBalanceForCreditExit != null)
                UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                    accountBalanceForCredit.MovementCreditAmount, true, 2);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
        }

        public AccountBalanceEntity AddAccountBalanceForDebit(BUTransferEntity bUTransferEntity, BUTransferDetailPurchaseEntity entityDetail)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = entityDetail.DebitAccount,
                //CurrencyCode = bUTransferEntity.CurrencyCode,
                ExchangeRate = bUTransferEntity.ExchangeRate,
                BalanceDate = bUTransferEntity.PostedDate,
                MovementDebitAmount = entityDetail.Amount,
                MovementDebitAmountOC = entityDetail.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = entityDetail.BudgetSourceId,
                BudgetChapterCode = entityDetail.BudgetChapterCode,
                //BudgetKindItemCode = entityDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = entityDetail.BudgetSubKindItemCode,
                BudgetItemCode = entityDetail.BudgetItemCode,
                BudgetSubItemCode = entityDetail.BudgetSubItemCode,
                MethodDistributeId = entityDetail.MethodDistributeId,
                AccountingObjectId = bUTransferEntity.AccountingObjectId,
                ActivityId = entityDetail.ActivityId,
                //ProjectId = entityDetail.ProjectId,
                //   BankAccount = bUTransferDetailEntity.BankId,
                //FundStructureId = entityDetail.FundStructureId,
                //ProjectActivityId = entityDetail.ProjectActivityId,
                //BudgetDetailItemCode = entityDetail.BudgetDetailItemCode
            };
        }

        public AccountBalanceEntity AddAccountBalanceForCredit(BUTransferEntity bUTransferEntity, BUTransferDetailPurchaseEntity entityDetail)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = entityDetail.CreditAccount,
                //   CurrencyCode = bUTransferEntity.CurrencyCode,
                ExchangeRate = bUTransferEntity.ExchangeRate,
                BalanceDate = bUTransferEntity.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = entityDetail.Amount,
                MovementCreditAmount = entityDetail.Amount,
                BudgetSourceId = entityDetail.BudgetSourceId,
                BudgetChapterCode = entityDetail.BudgetChapterCode,
                //BudgetKindItemCode = entityDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = entityDetail.BudgetSubKindItemCode,
                BudgetItemCode = entityDetail.BudgetItemCode,
                BudgetSubItemCode = entityDetail.BudgetSubItemCode,
                MethodDistributeId = entityDetail.MethodDistributeId,
                AccountingObjectId = bUTransferEntity.AccountingObjectId,
                ActivityId = entityDetail.ActivityId,
                //ProjectId = entityDetail.ProjectId,
                //    BankAccount = bUTransferDetailEntity.BankId,
                //FundStructureId = entityDetail.FundStructureId,
                //ProjectActivityId = entityDetail.ProjectActivityId,
                //BudgetDetailItemCode = entityDetail.BudgetDetailItemCode
            };
        }
        #endregion

        #region Thêm số dư đầu kì tài khoản khi nhập mới TSCĐ qua chuyển khoản
        public void InsertAccountBalance(BUTransferEntity bUTransferEntity, BUTransferDetailFixedAssetEntity entityDetail)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(bUTransferEntity, entityDetail);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(bUTransferEntity, entityDetail);
            var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
            if (accountBalanceForCreditExit != null)
                UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                    accountBalanceForCredit.MovementCreditAmount, true, 2);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
        }

        public AccountBalanceEntity AddAccountBalanceForDebit(BUTransferEntity bUTransferEntity, BUTransferDetailFixedAssetEntity entityDetail)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = entityDetail.DebitAccount,
                //CurrencyCode = bUTransferEntity.CurrencyCode,
                ExchangeRate = bUTransferEntity.ExchangeRate,
                BalanceDate = bUTransferEntity.PostedDate,
                MovementDebitAmount = entityDetail.Amount,
                MovementDebitAmountOC = entityDetail.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = entityDetail.BudgetSourceId,
                BudgetChapterCode = entityDetail.BudgetChapterCode,
                //BudgetKindItemCode = entityDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = entityDetail.BudgetSubKindItemCode,
                BudgetItemCode = entityDetail.BudgetItemCode,
                BudgetSubItemCode = entityDetail.BudgetSubItemCode,
                MethodDistributeId = entityDetail.MethodDistributeId,
                AccountingObjectId = bUTransferEntity.AccountingObjectId,
                ActivityId = entityDetail.ActivityId,
                //ProjectId = entityDetail.ProjectId,
                //   BankAccount = bUTransferDetailEntity.BankId,
                //FundStructureId = entityDetail.FundStructureId,
                //ProjectActivityId = entityDetail.ProjectActivityId,
                //BudgetDetailItemCode = entityDetail.BudgetDetailItemCode
            };
        }

        public AccountBalanceEntity AddAccountBalanceForCredit(BUTransferEntity bUTransferEntity, BUTransferDetailFixedAssetEntity entityDetail)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = entityDetail.CreditAccount,
                //   CurrencyCode = bUTransferEntity.CurrencyCode,
                ExchangeRate = bUTransferEntity.ExchangeRate,
                BalanceDate = bUTransferEntity.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = entityDetail.Amount,
                MovementCreditAmount = entityDetail.Amount,
                BudgetSourceId = entityDetail.BudgetSourceId,
                BudgetChapterCode = entityDetail.BudgetChapterCode,
                //BudgetKindItemCode = entityDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = entityDetail.BudgetSubKindItemCode,
                BudgetItemCode = entityDetail.BudgetItemCode,
                BudgetSubItemCode = entityDetail.BudgetSubItemCode,
                MethodDistributeId = entityDetail.MethodDistributeId,
                AccountingObjectId = bUTransferEntity.AccountingObjectId,
                ActivityId = entityDetail.ActivityId,
                //ProjectId = entityDetail.ProjectId,
                //    BankAccount = bUTransferDetailEntity.BankId,
                //FundStructureId = entityDetail.FundStructureId,
                //ProjectActivityId = entityDetail.ProjectActivityId,
                //BudgetDetailItemCode = entityDetail.BudgetDetailItemCode
            };
        }
        #endregion
    }
}
