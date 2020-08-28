/***********************************************************************
 * <copyright file="badepositfacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 18, 2017
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
using Buca.Application.iBigTime2020.BusinessComponents.Message.Deposit;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Deposit
{
    /// <summary>
    ///     BADepositFacade
    /// </summary>
    public class BADepositFacade
    {
        private static readonly IBADepositDao BADepositDao = DataAccess.DataAccess.BADepositDao;
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IBADepositDetailDao BADepositDetailDao = DataAccess.DataAccess.BADepositDetailDao;
        private static readonly IBADepositDetailFixedAssetDao BADepositDetailFixedAssetDao = DataAccess.DataAccess.BADepositDetailFixedAssetDao;
        private static readonly IBADepositDetailSaleDao BADepositDetailSaleDao = DataAccess.DataAccess.BADepositDetailSaleDao;
        private static readonly IBADepositDetailTaxDao BADepositDetailTaxDao = DataAccess.DataAccess.BADepositDetailTaxDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;
        private static readonly IBADepositDetailParallelDao BADepositDetailParallelDao = DataAccess.DataAccess.BADepositDetailParallelDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;

        /// <summary>
        ///     Gets the ba deposits.
        /// </summary>
        /// <returns></returns>
        public List<BADepositEntity> GetBADeposits()
        {
            return BADepositDao.GetBADeposits();
        }

        /// <summary>
        ///     Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<BADepositEntity> GetBADepositsByRefTypeId(int refTypeId)
        {
            return BADepositDao.GetBADepositsByRefTypeId(refTypeId);
        }

        /// <summary>
        ///     Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public List<BADepositEntity> GetBADepositsByRefTypeId(int refTypeId, DateTime refDate)
        {
            return BADepositDao.GetBADepositsByYearOfRefDate(refTypeId, (short)refDate.Year);
        }

        /// <summary>
        ///     Gets the ba deposit by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasFixedAsset">if set to <c>true</c> [has fixed asset].</param>
        /// <param name="hasSale">if set to <c>true</c> [has sale].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        /// <returns></returns>
        public BADepositEntity GetBADepositByRefId(string refId, bool hasDetail, bool hasFixedAsset, bool hasSale, bool hasTax)
        {
            var bADeposit = BADepositDao.GetBADeposit(refId);
            if (bADeposit == null)
                return null;
            if (hasDetail)
                bADeposit.BADepositDetails = BADepositDetailDao.GetBADepositDetailsByRefId(bADeposit.RefId);
            if (hasFixedAsset)
                bADeposit.BADepositDetailFixedAssetEntities = BADepositDetailFixedAssetDao.GetBADepositDetailFixedAssetsByRefId(bADeposit.RefId);
            if (hasSale)
                bADeposit.BADepositDetailSaleEntities = BADepositDetailSaleDao.GetBADepositDetailSalesByRefId(bADeposit.RefId);
            if (hasTax)
                bADeposit.BADepositDetailTaxEntities = BADepositDetailTaxDao.GetBADepositDetailTaxsByRefId(bADeposit.RefId);

            //default get parallel
            bADeposit.BADepositDetailParallels = BADepositDetailParallelDao.GetBADepositDetailParallelByRefId(bADeposit.RefId);

            return bADeposit;
        }

        /// <summary>
        ///     Gets the ba deposit by date month.
        /// </summary>
        /// <param name="dateMonth">The date month.</param>
        /// <returns></returns>
        public BADepositEntity GetBADepositByDateMonth(DateTime dateMonth)
        {
            return BADepositDao.GetBADepositBySalary(dateMonth);
        }

        /// <summary>
        /// Inserts the ba deposit.
        /// </summary>
        /// <param name="bADepositEntity">The b a deposit entity.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>BADepositResponse.</returns>
        public BADepositResponse InsertBADeposit(BADepositEntity bADepositEntity, bool isAutoGenerateParallel = false)
        {
            var response = new BADepositResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!bADepositEntity.Validate())
                {
                    foreach (var error in bADepositEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var bADepositByRefNo = BADepositDao.GetBADepositByRefNo(bADepositEntity.RefNo, bADepositEntity.RefType, bADepositEntity.PostedDate);
                    if (bADepositByRefNo != null && bADepositByRefNo.PostedDate.Year == bADepositEntity.PostedDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = string.Format("Số chứng từ \'{0}\' đã tồn tại!", bADepositEntity.RefNo);
                        return response;
                    }
                    bADepositEntity.RefId = Guid.NewGuid().ToString();
                    response.Message = BADepositDao.InsertBADeposit(bADepositEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region insert baDepositDetailEntity

                    if (bADepositEntity.BADepositDetails != null)
                        foreach (var baDepositDetailEntity in bADepositEntity.BADepositDetails)
                        {
                            baDepositDetailEntity.RefDetailId = Guid.NewGuid().ToString();
                            baDepositDetailEntity.RefId = bADepositEntity.RefId;
                            response.Message = BADepositDetailDao.InsertBADepositDetail(baDepositDetailEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            InsertAccountBalance(bADepositEntity, baDepositDetailEntity);

                            #region Insert into GeneralLedger

                            if (baDepositDetailEntity.DebitAccount != null && baDepositDetailEntity.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bADepositEntity.RefType,
                                    RefNo = bADepositEntity.RefNo,
                                    AccountingObjectId = baDepositDetailEntity.AccountingObjectId,
                                    BankId = baDepositDetailEntity.BankId,
                                    BudgetChapterCode = baDepositDetailEntity.BudgetChapterCode,
                                    ProjectId = baDepositDetailEntity.ProjectId,
                                    BudgetSourceId = baDepositDetailEntity.BudgetSourceId,
                                    Description = baDepositDetailEntity.Description,
                                    RefDetailId = baDepositDetailEntity.RefDetailId,
                                    ExchangeRate = bADepositEntity.ExchangeRate,
                                    ActivityId = baDepositDetailEntity.ActivityId,
                                    BudgetSubKindItemCode = baDepositDetailEntity.BudgetSubKindItemCode,
                                    CurrencyCode = bADepositEntity.CurrencyCode,
                                    BudgetKindItemCode = baDepositDetailEntity.BudgetKindItemCode,
                                    RefId = baDepositDetailEntity.RefId,
                                    PostedDate = bADepositEntity.PostedDate,
                                    MethodDistributeId = baDepositDetailEntity.MethodDistributeId,
                                    OrgRefNo = string.Empty,
                                    OrgRefDate = null,
                                    BudgetItemCode = baDepositDetailEntity.BudgetItemCode,
                                    ListItemId = baDepositDetailEntity.ListItemId,
                                    BudgetSubItemCode = baDepositDetailEntity.BudgetSubItemCode,
                                    BudgetDetailItemCode = baDepositDetailEntity.BudgetDetailItemCode,
                                    CashWithDrawTypeId = baDepositDetailEntity.CashWithDrawTypeId,
                                    AccountNumber = baDepositDetailEntity.DebitAccount,
                                    CorrespondingAccountNumber = baDepositDetailEntity.CreditAccount,
                                    DebitAmount = baDepositDetailEntity.Amount,
                                    DebitAmountOC = baDepositDetailEntity.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = baDepositDetailEntity.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = baDepositDetailEntity.Description,
                                    RefDate = bADepositEntity.RefDate,
                                    BudgetExpenseId = baDepositDetailEntity.BudgetExpenseId,
                                    ContractId = baDepositDetailEntity.ContractId,
                                    CapitalPlanId = baDepositDetailEntity.CapitalPlanId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = baDepositDetailEntity.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = baDepositDetailEntity.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = baDepositDetailEntity.Amount;
                                generalLedgerEntity.CreditAmountOC = baDepositDetailEntity.AmountOC;
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }
                            else //ghi don
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bADepositEntity.RefType,
                                    RefNo = bADepositEntity.RefNo,
                                    AccountingObjectId = bADepositEntity.AccountingObjectId,
                                    BankId = baDepositDetailEntity.BankId,
                                    BudgetChapterCode = baDepositDetailEntity.BudgetChapterCode,
                                    ProjectId = baDepositDetailEntity.ProjectId,
                                    BudgetSourceId = baDepositDetailEntity.BudgetSourceId,
                                    Description = baDepositDetailEntity.Description,
                                    RefDetailId = baDepositDetailEntity.RefDetailId,
                                    ExchangeRate = bADepositEntity.ExchangeRate,
                                    ActivityId = baDepositDetailEntity.ActivityId,
                                    BudgetSubKindItemCode = baDepositDetailEntity.BudgetSubKindItemCode,
                                    CurrencyCode = bADepositEntity.CurrencyCode,
                                    BudgetKindItemCode = baDepositDetailEntity.BudgetKindItemCode,
                                    RefId = bADepositEntity.RefId,
                                    PostedDate = bADepositEntity.PostedDate,
                                    MethodDistributeId = baDepositDetailEntity.MethodDistributeId,
                                    OrgRefNo = string.Empty,
                                    OrgRefDate = null,
                                    BudgetItemCode = baDepositDetailEntity.BudgetItemCode,
                                    ListItemId = baDepositDetailEntity.ListItemId,
                                    BudgetSubItemCode = baDepositDetailEntity.BudgetSubItemCode,
                                    BudgetDetailItemCode = baDepositDetailEntity.BudgetDetailItemCode,
                                    CashWithDrawTypeId = baDepositDetailEntity.CashWithDrawTypeId,
                                    AccountNumber = baDepositDetailEntity.DebitAccount ?? baDepositDetailEntity.CreditAccount,
                                    DebitAmount = baDepositDetailEntity.DebitAccount == null ? 0 : baDepositDetailEntity.Amount,
                                    DebitAmountOC = baDepositDetailEntity.DebitAccount == null ? 0 : baDepositDetailEntity.AmountOC,
                                    CreditAmount = baDepositDetailEntity.CreditAccount == null ? 0 : baDepositDetailEntity.Amount,
                                    CreditAmountOC = baDepositDetailEntity.CreditAccount == null ? 0 : baDepositDetailEntity.AmountOC,
                                    FundStructureId = baDepositDetailEntity.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bADepositEntity.JournalMemo,
                                    RefDate = bADepositEntity.RefDate,
                                    BudgetExpenseId = baDepositDetailEntity.BudgetExpenseId,
                                    ContractId = baDepositDetailEntity.ContractId,
                                    CapitalPlanId = baDepositDetailEntity.CapitalPlanId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger

                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bADepositEntity.RefType,
                                RefId = bADepositEntity.RefId,
                                RefDetailId = baDepositDetailEntity.RefDetailId,
                                OrgRefDate = null,
                                OrgRefNo = null,
                                RefDate = bADepositEntity.RefDate,
                                PostedDate = bADepositEntity.PostedDate,
                                RefNo = bADepositEntity.RefNo,
                                AccountingObjectId = baDepositDetailEntity.AccountingObjectId,
                                ActivityId = baDepositDetailEntity.ActivityId,
                                Amount = baDepositDetailEntity.Amount,
                                AmountOC = baDepositDetailEntity.AmountOC,
                                Approved = null,
                                BankId = baDepositDetailEntity.BankId,
                                BudgetChapterCode = baDepositDetailEntity.BudgetChapterCode,
                                BudgetDetailItemCode = baDepositDetailEntity.BudgetDetailItemCode,
                                BudgetItemCode = baDepositDetailEntity.BudgetItemCode,
                                BudgetKindItemCode = baDepositDetailEntity.BudgetKindItemCode,
                                BudgetSourceId = baDepositDetailEntity.BudgetSourceId,
                                BudgetSubItemCode = baDepositDetailEntity.BudgetSubItemCode,
                                BudgetSubKindItemCode = baDepositDetailEntity.BudgetSubKindItemCode,
                                CashWithDrawTypeId = baDepositDetailEntity.CashWithDrawTypeId,
                                CreditAccount = baDepositDetailEntity.CreditAccount,
                                DebitAccount = baDepositDetailEntity.DebitAccount,
                                Description = baDepositDetailEntity.Description,
                                FundStructureId = baDepositDetailEntity.FundStructureId,
                                TaxAmount = null,
                                ProjectActivityId = baDepositDetailEntity.ProjectActivityId,
                                MethodDistributeId = baDepositDetailEntity.MethodDistributeId,
                                JournalMemo = bADepositEntity.JournalMemo,
                                ProjectId = baDepositDetailEntity.ProjectId,
                                ToBankId = bADepositEntity.BankId,
                                CurrencyCode = bADepositEntity.CurrencyCode,
                                ExchangeRate = bADepositEntity.ExchangeRate,
                                BudgetExpenseId = baDepositDetailEntity.BudgetExpenseId,
                                ContractId = baDepositDetailEntity.ContractId,
                            };
                            response.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion
                        }

                    #endregion

                    #region insert bADepositDetailFixedAsset

                    if (bADepositEntity.BADepositDetailFixedAssetEntities != null)
                        foreach (var bADepositDetailFixedAsset in bADepositEntity.BADepositDetailFixedAssetEntities)
                        {
                            bADepositDetailFixedAsset.RefDetailId = Guid.NewGuid().ToString();
                            bADepositDetailFixedAsset.RefId = bADepositEntity.RefId;
                            response.Message =
                                BADepositDetailFixedAssetDao.InsertBADepositDetailFixedAsset(bADepositDetailFixedAsset);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    #region insert bADepositDetailSale

                    if (bADepositEntity.BADepositDetailSaleEntities != null)
                        foreach (var bADepositDetailSale in bADepositEntity.BADepositDetailSaleEntities)
                        {
                            bADepositDetailSale.RefDetailId = Guid.NewGuid().ToString();
                            bADepositDetailSale.RefId = bADepositEntity.RefId;
                            response.Message = BADepositDetailSaleDao.InsertBADepositDetailSale(bADepositDetailSale);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    #region insert bADepositDetailTax

                    if (bADepositEntity.BADepositDetailTaxEntities != null)
                        foreach (var bADepositDetailTax in bADepositEntity.BADepositDetailTaxEntities)
                        {
                            bADepositDetailTax.RefDetailId = Guid.NewGuid().ToString();
                            bADepositDetailTax.RefId = bADepositEntity.RefId;
                            response.Message = BADepositDetailTaxDao.InsertBADepositDetailTax(bADepositDetailTax);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    #region Sinh dinh khoan dong thoi

                    //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                    if (!isAutoGenerateParallel)
                    {
                        #region CAReceiptDetailParallel

                        if (bADepositEntity.BADepositDetailParallels != null)
                        {
                            //insert dl moi
                            foreach (var depositDetailParallel in bADepositEntity.BADepositDetailParallels)
                            {
                                #region Insert Receipt Detail Parallel

                                depositDetailParallel.RefId = bADepositEntity.RefId;
                                depositDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                depositDetailParallel.Amount = depositDetailParallel.Amount;

                                if (!depositDetailParallel.Validate())
                                {
                                    foreach (var error in depositDetailParallel.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                response.Message = BADepositDetailParallelDao.InsertBADepositDetailParallel(depositDetailParallel);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                #endregion

                                #region Insert General Ledger Entity
                                if (depositDetailParallel.DebitAccount != null && depositDetailParallel.CreditAccount != null)
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = bADepositEntity.RefType,
                                        RefNo = bADepositEntity.RefNo,
                                        AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                        BankId = depositDetailParallel.BankId,
                                        BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                        ProjectId = depositDetailParallel.ProjectId,
                                        BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                        Description = depositDetailParallel.Description,
                                        RefDetailId = depositDetailParallel.RefDetailId,
                                        ExchangeRate = bADepositEntity.ExchangeRate,
                                        ActivityId = depositDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = bADepositEntity.CurrencyCode,
                                        BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                        RefId = bADepositEntity.RefId,
                                        PostedDate = bADepositEntity.PostedDate,
                                        MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                        OrgRefNo = depositDetailParallel.OrgRefNo,
                                        OrgRefDate = depositDetailParallel.OrgRefDate,
                                        BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                        ListItemId = depositDetailParallel.ListItemId,
                                        BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = depositDetailParallel.DebitAccount,
                                        CorrespondingAccountNumber = depositDetailParallel.CreditAccount,
                                        DebitAmount = depositDetailParallel.Amount,
                                        DebitAmountOC = depositDetailParallel.AmountOC,
                                        CreditAmount = 0,
                                        CreditAmountOC = 0,
                                        FundStructureId = depositDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = bADepositEntity.JournalMemo,
                                        RefDate = bADepositEntity.RefDate,
                                        BudgetExpenseId = depositDetailParallel.BudgetExpenseId,
                                        ContractId = depositDetailParallel.ContractId,
                                        CapitalPlanId = depositDetailParallel.CapitalPlanId
                                    };
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    //insert lan 2
                                    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                    generalLedgerEntity.AccountNumber = depositDetailParallel.CreditAccount;
                                    generalLedgerEntity.CorrespondingAccountNumber = depositDetailParallel.DebitAccount;
                                    generalLedgerEntity.DebitAmount = 0;
                                    generalLedgerEntity.DebitAmountOC = 0;
                                    generalLedgerEntity.CreditAmount = depositDetailParallel.Amount;
                                    generalLedgerEntity.CreditAmountOC = depositDetailParallel.AmountOC;
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }
                                else
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = bADepositEntity.RefType,
                                        RefNo = bADepositEntity.RefNo,
                                        AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                        BankId = depositDetailParallel.BankId,
                                        BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                        ProjectId = depositDetailParallel.ProjectId,
                                        BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                        Description = depositDetailParallel.Description,
                                        RefDetailId = depositDetailParallel.RefDetailId,
                                        ExchangeRate = bADepositEntity.ExchangeRate,
                                        ActivityId = depositDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = bADepositEntity.CurrencyCode,
                                        BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                        RefId = bADepositEntity.RefId,
                                        PostedDate = bADepositEntity.PostedDate,
                                        MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                        OrgRefNo = depositDetailParallel.OrgRefNo,
                                        OrgRefDate = depositDetailParallel.OrgRefDate,
                                        BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                        ListItemId = depositDetailParallel.ListItemId,
                                        BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = depositDetailParallel.DebitAccount ?? depositDetailParallel.CreditAccount,
                                        DebitAmount = depositDetailParallel.DebitAccount == null ? 0 : depositDetailParallel.Amount,
                                        DebitAmountOC = depositDetailParallel.DebitAccount == null ? 0 : depositDetailParallel.AmountOC,
                                        CreditAmount = depositDetailParallel.CreditAccount == null ? 0 : depositDetailParallel.Amount,
                                        CreditAmountOC = depositDetailParallel.CreditAccount == null ? 0 : depositDetailParallel.AmountOC,
                                        FundStructureId = depositDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = bADepositEntity.JournalMemo,
                                        RefDate = bADepositEntity.RefDate,
                                        BudgetExpenseId = depositDetailParallel.BudgetExpenseId,
                                        ContractId = depositDetailParallel.ContractId,
                                        CapitalPlanId = depositDetailParallel.CapitalPlanId
                                    };
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }


                                #endregion

                                #region Insert OriginalGeneralLedger

                                var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                {
                                    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                    RefType = bADepositEntity.RefType,
                                    RefId = bADepositEntity.RefId,
                                    RefDetailId = depositDetailParallel.RefDetailId,
                                    OrgRefDate = depositDetailParallel.OrgRefDate,
                                    OrgRefNo = depositDetailParallel.OrgRefNo,
                                    RefDate = bADepositEntity.RefDate,
                                    RefNo = bADepositEntity.RefNo,
                                    AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                    ActivityId = depositDetailParallel.ActivityId,
                                    Amount = depositDetailParallel.Amount,
                                    AmountOC = depositDetailParallel.AmountOC,
                                    //Approved = receiptDetail.Approved,
                                    BankId = depositDetailParallel.BankId,
                                    BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                    BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                    BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                    BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                    BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                    BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                    BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                    CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                    CreditAccount = depositDetailParallel.CreditAccount,
                                    DebitAccount = depositDetailParallel.DebitAccount,
                                    Description = depositDetailParallel.Description,
                                    FundStructureId = depositDetailParallel.FundStructureId,
                                    //ProjectActivityId = depositDetailParallel.ProjectActivityId,
                                    MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                    JournalMemo = bADepositEntity.JournalMemo,
                                    ProjectId = depositDetailParallel.ProjectId,
                                    ToBankId = depositDetailParallel.BankId,
                                    ExchangeRate = bADepositEntity.ExchangeRate,
                                    CurrencyCode = bADepositEntity.CurrencyCode,
                                    PostedDate = bADepositEntity.PostedDate,
                                    BudgetExpenseId = depositDetailParallel.BudgetExpenseId,
                                    ContractId = depositDetailParallel.ContractId,
                                };
                                response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                #endregion
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        //truong hop sinh tu dong se sinh theo chung tu chi tiet
                        if (bADepositEntity.BADepositDetails != null)
                        {
                            foreach (var depositDetail in bADepositEntity.BADepositDetails)
                            {
                                //insert dl moi
                                var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                        depositDetail.DebitAccount, depositDetail.CreditAccount,
                                        depositDetail.BudgetSourceId,
                                        depositDetail.BudgetChapterCode, depositDetail.BudgetKindItemCode,
                                        depositDetail.BudgetSubKindItemCode, depositDetail.BudgetItemCode,
                                        depositDetail.BudgetSubItemCode,
                                        depositDetail.MethodDistributeId, depositDetail.CashWithDrawTypeId);

                                if (autoBusinessParallelEntitys != null)
                                {
                                    foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                    {
                                        #region BADepositDetails

                                        var depositDetailParallel = new BADepositDetailParallelEntity()
                                        {
                                            RefId = bADepositEntity.RefId,
                                            RefDetailId = Guid.NewGuid().ToString(),
                                            Description = depositDetail.Description,
                                            DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                            CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                            Amount = depositDetail.Amount,
                                            AmountOC = depositDetail.AmountOC,
                                            BudgetSourceId =
                                                autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                depositDetail.BudgetSourceId,
                                            BudgetChapterCode =
                                                autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                depositDetail.BudgetChapterCode,
                                            BudgetKindItemCode =
                                                autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                depositDetail.BudgetKindItemCode,
                                            BudgetSubKindItemCode =
                                                autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                depositDetail.BudgetSubKindItemCode,
                                            BudgetItemCode =
                                                autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                depositDetail.BudgetItemCode,
                                            BudgetSubItemCode =
                                                autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                depositDetail.BudgetSubItemCode,
                                            MethodDistributeId =
                                                autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                depositDetail.MethodDistributeId,
                                            CashWithdrawTypeId =
                                                autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                depositDetail.CashWithDrawTypeId,
                                            AccountingObjectId = depositDetail.AccountingObjectId,
                                            ActivityId = depositDetail.ActivityId,
                                            ProjectId = depositDetail.ProjectId,
                                            ListItemId = depositDetail.ListItemId,
                                            Approved = true,
                                            SortOrder = depositDetail.SortOrder,
                                            //OrgRefNo = depositDetail.OrgRefNo,
                                            //OrgRefDate = depositDetail.OrgRefDate,
                                            FundStructureId = depositDetail.FundStructureId,
                                            BankId = depositDetail.BankId,
                                            BudgetExpenseId = depositDetail.BudgetExpenseId,
                                            ContractId = depositDetail.ContractId,
                                            CapitalPlanId = depositDetail.CapitalPlanId
                                            //depositDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                            //depositDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                        };
                                        if (!depositDetailParallel.Validate())
                                        {
                                            foreach (var error in depositDetailParallel.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }
                                        response.Message =
                                            BADepositDetailParallelDao.InsertBADepositDetailParallel(
                                                depositDetailParallel);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        #endregion

                                        #region Insert General Ledger Entity
                                        if (depositDetailParallel.DebitAccount != null && depositDetailParallel.CreditAccount != null)
                                        {
                                            var generalLedgerEntity = new GeneralLedgerEntity
                                            {
                                                RefType = bADepositEntity.RefType,
                                                RefNo = bADepositEntity.RefNo,
                                                AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                                BankId = depositDetailParallel.BankId,
                                                BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                                ProjectId = depositDetailParallel.ProjectId,
                                                BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                                Description = depositDetailParallel.Description,
                                                RefDetailId = depositDetailParallel.RefDetailId,
                                                ExchangeRate = bADepositEntity.ExchangeRate,
                                                ActivityId = depositDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = bADepositEntity.CurrencyCode,
                                                BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                                RefId = bADepositEntity.RefId,
                                                PostedDate = bADepositEntity.PostedDate,
                                                MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                                OrgRefNo = depositDetailParallel.OrgRefNo,
                                                OrgRefDate = depositDetailParallel.OrgRefDate,
                                                BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                                ListItemId = depositDetailParallel.ListItemId,
                                                BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                                AccountNumber = depositDetailParallel.DebitAccount,
                                                CorrespondingAccountNumber = depositDetailParallel.CreditAccount, // Thêm TK Có
                                                DebitAmount = depositDetailParallel.Amount,
                                                DebitAmountOC = depositDetailParallel.AmountOC,
                                                CreditAmount = depositDetailParallel.Amount,
                                                CreditAmountOC = depositDetailParallel.AmountOC,
                                                FundStructureId = depositDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = bADepositEntity.JournalMemo,
                                                RefDate = bADepositEntity.RefDate,
                                                BudgetExpenseId = depositDetailParallel.BudgetExpenseId,
                                                ContractId = depositDetailParallel.ContractId,
                                                CapitalPlanId = depositDetailParallel.CapitalPlanId
                                            };
                                            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }

                                            //insert lan 2
                                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                            generalLedgerEntity.AccountNumber = depositDetailParallel.CreditAccount;
                                            generalLedgerEntity.CorrespondingAccountNumber = depositDetailParallel.DebitAccount;
                                            generalLedgerEntity.DebitAmount = 0;
                                            generalLedgerEntity.DebitAmountOC = 0;
                                            generalLedgerEntity.CreditAmount = depositDetailParallel.Amount;
                                            generalLedgerEntity.CreditAmountOC = depositDetailParallel.AmountOC;
                                            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                        }
                                        else
                                        {
                                            var generalLedgerEntity = new GeneralLedgerEntity
                                            {
                                                RefType = bADepositEntity.RefType,
                                                RefNo = bADepositEntity.RefNo,
                                                AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                                BankId = depositDetailParallel.BankId,
                                                BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                                ProjectId = depositDetailParallel.ProjectId,
                                                BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                                Description = depositDetailParallel.Description,
                                                RefDetailId = depositDetailParallel.RefDetailId,
                                                ExchangeRate = bADepositEntity.ExchangeRate,
                                                ActivityId = depositDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = bADepositEntity.CurrencyCode,
                                                BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                                RefId = bADepositEntity.RefId,
                                                PostedDate = bADepositEntity.PostedDate,
                                                MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                                OrgRefNo = depositDetailParallel.OrgRefNo,
                                                OrgRefDate = depositDetailParallel.OrgRefDate,
                                                BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                                ListItemId = depositDetailParallel.ListItemId,
                                                BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                                AccountNumber =
                                                depositDetailParallel.DebitAccount ??
                                                depositDetailParallel.CreditAccount,
                                                DebitAmount =
                                                depositDetailParallel.DebitAccount == null
                                                    ? 0
                                                    : depositDetailParallel.Amount,
                                                DebitAmountOC =
                                                depositDetailParallel.DebitAccount == null
                                                    ? 0
                                                    : depositDetailParallel.AmountOC,
                                                CreditAmount =
                                                depositDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : depositDetailParallel.Amount,
                                                CreditAmountOC =
                                                depositDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : depositDetailParallel.AmountOC,
                                                FundStructureId = depositDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = bADepositEntity.JournalMemo,
                                                RefDate = bADepositEntity.RefDate,
                                                BudgetExpenseId = depositDetailParallel.BudgetExpenseId,
                                                ContractId = depositDetailParallel.ContractId,
                                                CapitalPlanId = depositDetailParallel.CapitalPlanId
                                            };
                                            response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                        }


                                        #endregion

                                        #region Insert OriginalGeneralLedger

                                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                        {
                                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                            RefType = bADepositEntity.RefType,
                                            RefId = bADepositEntity.RefId,
                                            RefDetailId = depositDetailParallel.RefDetailId,
                                            OrgRefDate = depositDetailParallel.OrgRefDate,
                                            OrgRefNo = depositDetailParallel.OrgRefNo,
                                            RefDate = bADepositEntity.RefDate,
                                            PostedDate = bADepositEntity.PostedDate,
                                            RefNo = bADepositEntity.RefNo,
                                            AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                            ActivityId = depositDetailParallel.ActivityId,
                                            Amount = depositDetailParallel.Amount,
                                            AmountOC = depositDetailParallel.AmountOC,
                                            //Approved = receiptDetail.Approved,
                                            BankId = depositDetailParallel.BankId,
                                            BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                            BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                            BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                            BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                            BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                            BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                            BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                            CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                            CreditAccount = depositDetailParallel.CreditAccount,
                                            DebitAccount = depositDetailParallel.DebitAccount,
                                            Description = depositDetailParallel.Description,
                                            FundStructureId = depositDetailParallel.FundStructureId,
                                            //ProjectActivityId = depositDetailParallel.ProjectActivityId,
                                            MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                            JournalMemo = bADepositEntity.JournalMemo,
                                            ProjectId = depositDetailParallel.ProjectId,
                                            ToBankId = depositDetailParallel.BankId,
                                            ExchangeRate = bADepositEntity.ExchangeRate,
                                            CurrencyCode = bADepositEntity.CurrencyCode,
                                            BudgetExpenseId = depositDetailParallel.BudgetExpenseId,
                                            ContractId = depositDetailParallel.ContractId,
                                        };
                                        response.Message =
                                            OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                originalGeneralLedgerEntity);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        #endregion
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    scope.Complete();
                }
                response.RefId = bADepositEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Updates the ba deposit.
        /// </summary>
        /// <param name="bADepositEntity">The b a deposit entity.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>BADepositResponse.</returns>
        public BADepositResponse UpdateBADeposit(BADepositEntity bADepositEntity, bool isAutoGenerateParallel = false)
        {
            var response = new BADepositResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!bADepositEntity.Validate())
                {
                    foreach (var error in bADepositEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    var bADepositByRefNo = BADepositDao.GetBADepositByRefNo(bADepositEntity.RefNo, bADepositEntity.RefType, bADepositEntity.PostedDate);
                    if (bADepositByRefNo != null && !bADepositByRefNo.RefId.Equals(bADepositEntity.RefId) && bADepositByRefNo.PostedDate.Year == bADepositEntity.PostedDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = String.Format("Số chứng từ \'{0}\' đã tồn tại!", bADepositEntity.RefNo);
                        return response;
                    }
                    response.Message = BADepositDao.UpdateBADeposit(bADepositEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // Update account balance
                    // Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới
                    UpdateAccountBalance(bADepositEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #region Delete detail and insert detail

                    response.Message = BADepositDetailDao.DeleteBADepositDetailByRefId(bADepositEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // delete bang GeneralLedger
                    response.Message = GeneralLedgerDao.DeleteGeneralLedger(bADepositEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    //DeleteOriginalGeneralLedger
                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bADepositEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    //delete parallel
                    response.Message = BADepositDetailParallelDao.DeleteBADepositDetailParallelById(bADepositEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    if (bADepositEntity.BADepositDetails != null)
                    {
                        foreach (var baDepositDetailEntity in bADepositEntity.BADepositDetails)
                        {
                            baDepositDetailEntity.RefDetailId = Guid.NewGuid().ToString();
                            baDepositDetailEntity.RefId = bADepositEntity.RefId;
                            response.Message = BADepositDetailDao.InsertBADepositDetail(baDepositDetailEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            // Update account balance
                            // Cộng thêm số tiền mới sau khi sửa chứng từ
                            InsertAccountBalance(bADepositEntity, baDepositDetailEntity);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            // insert bang GeneralLedger

                            #region Insert into GeneralLedger

                            if (baDepositDetailEntity.DebitAccount != null &&
                                baDepositDetailEntity.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bADepositEntity.RefType,
                                    RefNo = bADepositEntity.RefNo,
                                    AccountingObjectId = baDepositDetailEntity.AccountingObjectId,
                                    BankId = baDepositDetailEntity.BankId,
                                    BudgetChapterCode = baDepositDetailEntity.BudgetChapterCode,
                                    ProjectId = baDepositDetailEntity.ProjectId,
                                    BudgetSourceId = baDepositDetailEntity.BudgetSourceId,
                                    Description = baDepositDetailEntity.Description,
                                    RefDetailId = baDepositDetailEntity.RefDetailId,
                                    ExchangeRate = bADepositEntity.ExchangeRate,
                                    ActivityId = baDepositDetailEntity.ActivityId,
                                    BudgetSubKindItemCode = baDepositDetailEntity.BudgetSubKindItemCode,
                                    CurrencyCode = bADepositEntity.CurrencyCode,
                                    BudgetKindItemCode = baDepositDetailEntity.BudgetKindItemCode,
                                    RefId = baDepositDetailEntity.RefId,
                                    PostedDate = bADepositEntity.PostedDate,
                                    MethodDistributeId = baDepositDetailEntity.MethodDistributeId,
                                    OrgRefNo = string.Empty,
                                    OrgRefDate = null,
                                    BudgetItemCode = baDepositDetailEntity.BudgetItemCode,
                                    ListItemId = baDepositDetailEntity.ListItemId,
                                    BudgetSubItemCode = baDepositDetailEntity.BudgetSubItemCode,
                                    BudgetDetailItemCode = baDepositDetailEntity.BudgetDetailItemCode,
                                    CashWithDrawTypeId = baDepositDetailEntity.CashWithDrawTypeId,
                                    AccountNumber = baDepositDetailEntity.DebitAccount,
                                    CorrespondingAccountNumber = baDepositDetailEntity.CreditAccount,
                                    DebitAmount = baDepositDetailEntity.Amount,
                                    DebitAmountOC = baDepositDetailEntity.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = baDepositDetailEntity.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = baDepositDetailEntity.Description,
                                    RefDate = bADepositEntity.RefDate,
                                    BudgetExpenseId = baDepositDetailEntity.BudgetExpenseId,
                                    ContractId = baDepositDetailEntity.ContractId,
                                    CapitalPlanId = baDepositDetailEntity.CapitalPlanId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = baDepositDetailEntity.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = baDepositDetailEntity.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = baDepositDetailEntity.Amount;
                                generalLedgerEntity.CreditAmountOC = baDepositDetailEntity.AmountOC;
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }
                            else //ghi don
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bADepositEntity.RefType,
                                    RefNo = bADepositEntity.RefNo,
                                    AccountingObjectId = bADepositEntity.AccountingObjectId,
                                    BankId = baDepositDetailEntity.BankId,
                                    BudgetChapterCode = baDepositDetailEntity.BudgetChapterCode,
                                    ProjectId = baDepositDetailEntity.ProjectId,
                                    BudgetSourceId = baDepositDetailEntity.BudgetSourceId,
                                    Description = baDepositDetailEntity.Description,
                                    RefDetailId = baDepositDetailEntity.RefDetailId,
                                    ExchangeRate = bADepositEntity.ExchangeRate,
                                    ActivityId = baDepositDetailEntity.ActivityId,
                                    BudgetSubKindItemCode = baDepositDetailEntity.BudgetSubKindItemCode,
                                    CurrencyCode = bADepositEntity.CurrencyCode,
                                    BudgetKindItemCode = baDepositDetailEntity.BudgetKindItemCode,
                                    RefId = bADepositEntity.RefId,
                                    PostedDate = bADepositEntity.PostedDate,
                                    MethodDistributeId = baDepositDetailEntity.MethodDistributeId,
                                    OrgRefNo = string.Empty,
                                    OrgRefDate = null,
                                    BudgetItemCode = baDepositDetailEntity.BudgetItemCode,
                                    ListItemId = baDepositDetailEntity.ListItemId,
                                    BudgetSubItemCode = baDepositDetailEntity.BudgetSubItemCode,
                                    BudgetDetailItemCode = baDepositDetailEntity.BudgetDetailItemCode,
                                    CashWithDrawTypeId = baDepositDetailEntity.CashWithDrawTypeId,
                                    AccountNumber =
                                        baDepositDetailEntity.DebitAccount ?? baDepositDetailEntity.CreditAccount,
                                    DebitAmount =
                                        baDepositDetailEntity.DebitAccount == null ? 0 : baDepositDetailEntity.Amount,
                                    DebitAmountOC =
                                        baDepositDetailEntity.DebitAccount == null ? 0 : baDepositDetailEntity.AmountOC,
                                    CreditAmount =
                                        baDepositDetailEntity.CreditAccount == null ? 0 : baDepositDetailEntity.Amount,
                                    CreditAmountOC =
                                        baDepositDetailEntity.CreditAccount == null ? 0 : baDepositDetailEntity.AmountOC,
                                    FundStructureId = baDepositDetailEntity.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bADepositEntity.JournalMemo,
                                    RefDate = bADepositEntity.RefDate,
                                    BudgetExpenseId = baDepositDetailEntity.BudgetExpenseId,
                                    ContractId = baDepositDetailEntity.ContractId,
                                    CapitalPlanId = baDepositDetailEntity.CapitalPlanId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger

                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bADepositEntity.RefType,
                                RefId = bADepositEntity.RefId,
                                RefDetailId = baDepositDetailEntity.RefDetailId,
                                OrgRefDate = null,
                                OrgRefNo = null,
                                RefDate = bADepositEntity.RefDate,
                                PostedDate = bADepositEntity.PostedDate,
                                RefNo = bADepositEntity.RefNo,
                                AccountingObjectId = baDepositDetailEntity.AccountingObjectId,
                                ActivityId = baDepositDetailEntity.ActivityId,
                                Amount = baDepositDetailEntity.Amount,
                                AmountOC = baDepositDetailEntity.AmountOC,
                                Approved = null,
                                BankId = baDepositDetailEntity.BankId,
                                BudgetChapterCode = baDepositDetailEntity.BudgetChapterCode,
                                BudgetDetailItemCode = baDepositDetailEntity.BudgetDetailItemCode,
                                BudgetItemCode = baDepositDetailEntity.BudgetItemCode,
                                BudgetKindItemCode = baDepositDetailEntity.BudgetKindItemCode,
                                BudgetSourceId = baDepositDetailEntity.BudgetSourceId,
                                BudgetSubItemCode = baDepositDetailEntity.BudgetSubItemCode,
                                BudgetSubKindItemCode = baDepositDetailEntity.BudgetSubKindItemCode,
                                CashWithDrawTypeId = baDepositDetailEntity.CashWithDrawTypeId,
                                CreditAccount = baDepositDetailEntity.CreditAccount,
                                DebitAccount = baDepositDetailEntity.DebitAccount,
                                Description = baDepositDetailEntity.Description,
                                FundStructureId = baDepositDetailEntity.FundStructureId,
                                TaxAmount = null,
                                ProjectActivityId = baDepositDetailEntity.ProjectActivityId,
                                MethodDistributeId = baDepositDetailEntity.MethodDistributeId,
                                JournalMemo = bADepositEntity.JournalMemo,
                                ProjectId = baDepositDetailEntity.ProjectId,
                                ToBankId = baDepositDetailEntity.BankId,
                                CurrencyCode = bADepositEntity.CurrencyCode,
                                ExchangeRate = bADepositEntity.ExchangeRate,
                                BudgetExpenseId = baDepositDetailEntity.BudgetExpenseId,
                                ContractId = baDepositDetailEntity.ContractId,
                            };
                            response.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion

                        }
                    }

                    #endregion

                    #region delete and insert detail bADepositDetailFixedAsset

                    response.Message =
                        BADepositDetailFixedAssetDao.DeleteBADepositDetailFixedAssetByRefId(bADepositEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    if (bADepositEntity.BADepositDetailFixedAssetEntities != null)
                        foreach (var bADepositDetailFixedAsset in bADepositEntity.BADepositDetailFixedAssetEntities)
                        {
                            bADepositDetailFixedAsset.RefDetailId = Guid.NewGuid().ToString();
                            bADepositDetailFixedAsset.RefId = bADepositEntity.RefId;
                            response.Message =
                                BADepositDetailFixedAssetDao.InsertBADepositDetailFixedAsset(bADepositDetailFixedAsset);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    #region delete and insert bADepositDetailSale

                    response.Message = BADepositDetailSaleDao.DeleteBADepositDetailSaleByRefId(bADepositEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    if (bADepositEntity.BADepositDetailSaleEntities != null)
                        foreach (var bADepositDetailSale in bADepositEntity.BADepositDetailSaleEntities)
                        {
                            bADepositDetailSale.RefDetailId = Guid.NewGuid().ToString();
                            bADepositDetailSale.RefId = bADepositEntity.RefId;
                            response.Message = BADepositDetailSaleDao.InsertBADepositDetailSale(bADepositDetailSale);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    #region delete and insert bADepositDetailTax

                    response.Message = BADepositDetailTaxDao.DeleteBADepositDetailTaxByRefId(bADepositEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    if (bADepositEntity.BADepositDetailTaxEntities != null)
                        foreach (var bADepositDetailTax in bADepositEntity.BADepositDetailTaxEntities)
                        {
                            bADepositDetailTax.RefDetailId = Guid.NewGuid().ToString();
                            bADepositDetailTax.RefId = bADepositEntity.RefId;
                            response.Message = BADepositDetailTaxDao.InsertBADepositDetailTax(bADepositDetailTax);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    #region Sinh dinh khoan dong thoi

                    //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                    if (!isAutoGenerateParallel)
                    {
                        #region CAReceiptDetailParallel

                        if (bADepositEntity.BADepositDetailParallels != null)
                        {
                            //insert dl moi
                            foreach (var depositDetailParallel in bADepositEntity.BADepositDetailParallels)
                            {
                                #region Insert Receipt Detail Parallel

                                depositDetailParallel.RefId = bADepositEntity.RefId;
                                depositDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                depositDetailParallel.Amount = depositDetailParallel.Amount;

                                if (!depositDetailParallel.Validate())
                                {
                                    foreach (var error in depositDetailParallel.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                response.Message = BADepositDetailParallelDao.InsertBADepositDetailParallel(depositDetailParallel);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                #endregion

                                #region Insert General Ledger Entity
                                if (depositDetailParallel.DebitAccount != null && depositDetailParallel.CreditAccount != null)
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = bADepositEntity.RefType,
                                        RefNo = bADepositEntity.RefNo,
                                        AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                        BankId = depositDetailParallel.BankId,
                                        BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                        ProjectId = depositDetailParallel.ProjectId,
                                        BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                        Description = depositDetailParallel.Description,
                                        RefDetailId = depositDetailParallel.RefDetailId,
                                        ExchangeRate = bADepositEntity.ExchangeRate,
                                        ActivityId = depositDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = bADepositEntity.CurrencyCode,
                                        BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                        RefId = bADepositEntity.RefId,
                                        PostedDate = bADepositEntity.PostedDate,
                                        MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                        OrgRefNo = depositDetailParallel.OrgRefNo,
                                        OrgRefDate = depositDetailParallel.OrgRefDate,
                                        BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                        ListItemId = depositDetailParallel.ListItemId,
                                        BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = depositDetailParallel.DebitAccount,
                                        CorrespondingAccountNumber = depositDetailParallel.CreditAccount,
                                        DebitAmount = depositDetailParallel.Amount,
                                        DebitAmountOC = depositDetailParallel.Amount,
                                        CreditAmount = 0,
                                        CreditAmountOC = 0,
                                        FundStructureId = depositDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = bADepositEntity.JournalMemo,
                                        RefDate = bADepositEntity.RefDate,
                                        BudgetExpenseId = depositDetailParallel.BudgetExpenseId,
                                        ContractId = depositDetailParallel.ContractId,
                                        CapitalPlanId = depositDetailParallel.CapitalPlanId
                                    };
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    //insert lan 2
                                    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                    generalLedgerEntity.AccountNumber = depositDetailParallel.CreditAccount;
                                    generalLedgerEntity.CorrespondingAccountNumber = depositDetailParallel.DebitAccount;
                                    generalLedgerEntity.DebitAmount = 0;
                                    generalLedgerEntity.DebitAmountOC = 0;
                                    generalLedgerEntity.CreditAmount = depositDetailParallel.Amount;
                                    generalLedgerEntity.CreditAmountOC = depositDetailParallel.AmountOC;
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }
                                else
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = bADepositEntity.RefType,
                                        RefNo = bADepositEntity.RefNo,
                                        AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                        BankId = depositDetailParallel.BankId,
                                        BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                        ProjectId = depositDetailParallel.ProjectId,
                                        BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                        Description = depositDetailParallel.Description,
                                        RefDetailId = depositDetailParallel.RefDetailId,
                                        ExchangeRate = bADepositEntity.ExchangeRate,
                                        ActivityId = depositDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = bADepositEntity.CurrencyCode,
                                        BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                        RefId = bADepositEntity.RefId,
                                        PostedDate = bADepositEntity.PostedDate,
                                        MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                        OrgRefNo = depositDetailParallel.OrgRefNo,
                                        OrgRefDate = depositDetailParallel.OrgRefDate,
                                        BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                        ListItemId = depositDetailParallel.ListItemId,
                                        BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = depositDetailParallel.DebitAccount ?? depositDetailParallel.CreditAccount,
                                        DebitAmount = depositDetailParallel.DebitAccount == null ? 0 : depositDetailParallel.Amount,
                                        DebitAmountOC = depositDetailParallel.DebitAccount == null ? 0 : depositDetailParallel.AmountOC,
                                        CreditAmount = depositDetailParallel.CreditAccount == null ? 0 : depositDetailParallel.Amount,
                                        CreditAmountOC = depositDetailParallel.CreditAccount == null ? 0 : depositDetailParallel.AmountOC,
                                        FundStructureId = depositDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = bADepositEntity.JournalMemo,
                                        RefDate = bADepositEntity.RefDate,
                                        BudgetExpenseId = depositDetailParallel.BudgetExpenseId,
                                        ContractId = depositDetailParallel.ContractId,
                                        CapitalPlanId = depositDetailParallel.CapitalPlanId
                                    };
                                    response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                }

                                #endregion

                                #region Insert OriginalGeneralLedger

                                var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                {
                                    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                    RefType = bADepositEntity.RefType,
                                    RefId = bADepositEntity.RefId,
                                    RefDetailId = depositDetailParallel.RefDetailId,
                                    OrgRefDate = depositDetailParallel.OrgRefDate,
                                    OrgRefNo = depositDetailParallel.OrgRefNo,
                                    RefDate = bADepositEntity.RefDate,
                                    RefNo = bADepositEntity.RefNo,
                                    AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                    ActivityId = depositDetailParallel.ActivityId,
                                    Amount = depositDetailParallel.Amount,
                                    AmountOC = depositDetailParallel.AmountOC,
                                    //Approved = receiptDetail.Approved,
                                    BankId = depositDetailParallel.BankId,
                                    BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                    BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                    BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                    BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                    BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                    BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                    BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                    CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                    CreditAccount = depositDetailParallel.CreditAccount,
                                    DebitAccount = depositDetailParallel.DebitAccount,
                                    Description = depositDetailParallel.Description,
                                    FundStructureId = depositDetailParallel.FundStructureId,
                                    //ProjectActivityId = depositDetailParallel.ProjectActivityId,
                                    MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                    JournalMemo = bADepositEntity.JournalMemo,
                                    ProjectId = depositDetailParallel.ProjectId,
                                    ToBankId = depositDetailParallel.BankId,
                                    ExchangeRate = bADepositEntity.ExchangeRate,
                                    CurrencyCode = bADepositEntity.CurrencyCode,
                                    PostedDate = bADepositEntity.PostedDate,
                                    ContractId = depositDetailParallel.ContractId,
                                };
                                response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                #endregion
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        //truong hop sinh tu dong se sinh theo chung tu chi tiet
                        foreach (var depositDetail in bADepositEntity.BADepositDetails)
                        {
                            //insert dl moi
                            var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                    depositDetail.DebitAccount, depositDetail.CreditAccount,
                                    depositDetail.BudgetSourceId,
                                    depositDetail.BudgetChapterCode, depositDetail.BudgetKindItemCode,
                                    depositDetail.BudgetSubKindItemCode, depositDetail.BudgetItemCode,
                                    depositDetail.BudgetSubItemCode,
                                    depositDetail.MethodDistributeId, depositDetail.CashWithDrawTypeId);

                            if (autoBusinessParallelEntitys != null)
                            {
                                foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                {
                                    #region BADepositDetails

                                    var depositDetailParallel = new BADepositDetailParallelEntity()
                                    {
                                        RefId = bADepositEntity.RefId,
                                        RefDetailId = Guid.NewGuid().ToString(),
                                        Description = depositDetail.Description,
                                        DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                        CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                        Amount = depositDetail.Amount,
                                        AmountOC = depositDetail.AmountOC,
                                        BudgetSourceId =
                                            autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                            depositDetail.BudgetSourceId,
                                        BudgetChapterCode =
                                            autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                            depositDetail.BudgetChapterCode,
                                        BudgetKindItemCode =
                                            autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                            depositDetail.BudgetKindItemCode,
                                        BudgetSubKindItemCode =
                                            autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                            depositDetail.BudgetSubKindItemCode,
                                        BudgetItemCode =
                                            autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                            depositDetail.BudgetItemCode,
                                        BudgetSubItemCode =
                                            autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                            depositDetail.BudgetSubItemCode,
                                        MethodDistributeId =
                                            autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                            depositDetail.MethodDistributeId,
                                        CashWithdrawTypeId =
                                            autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                            depositDetail.CashWithDrawTypeId,
                                        AccountingObjectId = depositDetail.AccountingObjectId,
                                        ActivityId = depositDetail.ActivityId,
                                        ProjectId = depositDetail.ProjectId,
                                        ListItemId = depositDetail.ListItemId,
                                        Approved = true,
                                        SortOrder = depositDetail.SortOrder,
                                        //OrgRefNo = depositDetail.OrgRefNo,
                                        //OrgRefDate = depositDetail.OrgRefDate,
                                        FundStructureId = depositDetail.FundStructureId,
                                        BankId = depositDetail.BankId,
                                        BudgetExpenseId = depositDetail.BudgetExpenseId,
                                        ContractId = depositDetail.ContractId,
                                        CapitalPlanId = depositDetail.CapitalPlanId
                                        //depositDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                        //depositDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                    };
                                    if (!depositDetailParallel.Validate())
                                    {
                                        foreach (var error in depositDetailParallel.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    response.Message =
                                        BADepositDetailParallelDao.InsertBADepositDetailParallel(depositDetailParallel);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (depositDetailParallel.DebitAccount != null && depositDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bADepositEntity.RefType,
                                            RefNo = bADepositEntity.RefNo,
                                            AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                            BankId = depositDetailParallel.BankId,
                                            BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                            ProjectId = depositDetailParallel.ProjectId,
                                            BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                            Description = depositDetailParallel.Description,
                                            RefDetailId = depositDetailParallel.RefDetailId,
                                            ExchangeRate = bADepositEntity.ExchangeRate,
                                            ActivityId = depositDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bADepositEntity.CurrencyCode,
                                            BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                            RefId = bADepositEntity.RefId,
                                            PostedDate = bADepositEntity.PostedDate,
                                            MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                            OrgRefNo = depositDetailParallel.OrgRefNo,
                                            OrgRefDate = depositDetailParallel.OrgRefDate,
                                            BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                            ListItemId = depositDetailParallel.ListItemId,
                                            BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                            AccountNumber =
                                           depositDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = depositDetailParallel.CreditAccount, // Thêm TK Có
                                            DebitAmount = depositDetailParallel.Amount,
                                            DebitAmountOC = depositDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = depositDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bADepositEntity.JournalMemo,
                                            RefDate = bADepositEntity.RefDate,
                                            BudgetExpenseId = depositDetailParallel.BudgetExpenseId,
                                            ContractId = depositDetailParallel.ContractId,
                                            CapitalPlanId = depositDetailParallel.CapitalPlanId
                                        };
                                        response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = depositDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = depositDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = depositDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = depositDetailParallel.AmountOC;
                                        response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bADepositEntity.RefType,
                                            RefNo = bADepositEntity.RefNo,
                                            AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                            BankId = depositDetailParallel.BankId,
                                            BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                            ProjectId = depositDetailParallel.ProjectId,
                                            BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                            Description = depositDetailParallel.Description,
                                            RefDetailId = depositDetailParallel.RefDetailId,
                                            ExchangeRate = bADepositEntity.ExchangeRate,
                                            ActivityId = depositDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bADepositEntity.CurrencyCode,
                                            BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                            RefId = bADepositEntity.RefId,
                                            PostedDate = bADepositEntity.PostedDate,
                                            MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                            OrgRefNo = depositDetailParallel.OrgRefNo,
                                            OrgRefDate = depositDetailParallel.OrgRefDate,
                                            BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                            ListItemId = depositDetailParallel.ListItemId,
                                            BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                            AccountNumber =
                                           depositDetailParallel.DebitAccount ?? depositDetailParallel.CreditAccount,
                                            DebitAmount =
                                           depositDetailParallel.DebitAccount == null
                                               ? 0
                                               : depositDetailParallel.Amount,
                                            DebitAmountOC =
                                           depositDetailParallel.DebitAccount == null
                                               ? 0
                                               : depositDetailParallel.AmountOC,
                                            CreditAmount =
                                           depositDetailParallel.CreditAccount == null
                                               ? 0
                                               : depositDetailParallel.Amount,
                                            CreditAmountOC =
                                           depositDetailParallel.CreditAccount == null
                                               ? 0
                                               : depositDetailParallel.AmountOC,
                                            FundStructureId = depositDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bADepositEntity.JournalMemo,
                                            RefDate = bADepositEntity.RefDate,
                                            BudgetExpenseId = depositDetailParallel.BudgetExpenseId,
                                            ContractId = depositDetailParallel.ContractId,
                                            CapitalPlanId = depositDetailParallel.CapitalPlanId
                                        };
                                        response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }
                                    }


                                    #endregion

                                    #region Insert OriginalGeneralLedger

                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = bADepositEntity.RefType,
                                        RefId = bADepositEntity.RefId,
                                        RefDetailId = depositDetailParallel.RefDetailId,
                                        OrgRefDate = depositDetailParallel.OrgRefDate,
                                        OrgRefNo = depositDetailParallel.OrgRefNo,
                                        RefDate = bADepositEntity.RefDate,
                                        PostedDate = bADepositEntity.PostedDate,
                                        RefNo = bADepositEntity.RefNo,
                                        AccountingObjectId = depositDetailParallel.AccountingObjectId,
                                        ActivityId = depositDetailParallel.ActivityId,
                                        Amount = depositDetailParallel.Amount,
                                        AmountOC = depositDetailParallel.AmountOC,
                                        //Approved = receiptDetail.Approved,
                                        BankId = depositDetailParallel.BankId,
                                        BudgetChapterCode = depositDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = depositDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = depositDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = depositDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = depositDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = depositDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = depositDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = depositDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = depositDetailParallel.CreditAccount,
                                        DebitAccount = depositDetailParallel.DebitAccount,
                                        Description = depositDetailParallel.Description,
                                        FundStructureId = depositDetailParallel.FundStructureId,
                                        //ProjectActivityId = depositDetailParallel.ProjectActivityId,
                                        MethodDistributeId = depositDetailParallel.MethodDistributeId,
                                        JournalMemo = bADepositEntity.JournalMemo,
                                        ProjectId = depositDetailParallel.ProjectId,
                                        ToBankId = depositDetailParallel.BankId,
                                        ExchangeRate = bADepositEntity.ExchangeRate,
                                        CurrencyCode = bADepositEntity.CurrencyCode,
                                        BudgetExpenseId = depositDetailParallel.BudgetExpenseId,
                                        ContractId = depositDetailParallel.ContractId
                                    };
                                    response.Message =
                                        OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                            originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    #endregion
                                }
                            }
                        }
                    }

                    #endregion

                    scope.Complete();
                }
                response.RefId = bADepositEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        ///     Deletes the ba deposit.
        /// </summary>
        /// <param name="bADepositId">The b a deposit identifier.</param>
        /// <returns></returns>
        public BADepositResponse DeleteBADeposit(string bADepositId)
        {
            var response = new BADepositResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var bADepositEntity = BADepositDao.GetBADeposit(bADepositId);
                if (bADepositEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = BADepositDao.DeleteBADeposit(bADepositEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // Update account balance
                    // Cập nhật giá trị vào account balance trước khi xóa
                    response.Message = UpdateAccountBalance(bADepositEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    // delete bang GeneralLedger
                    response.Message = GeneralLedgerDao.DeleteGeneralLedger(bADepositEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    //DeleteOriginalGeneralLedger
                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bADepositEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    //delete parallel
                    response.Message = BADepositDetailParallelDao.DeleteBADepositDetailParallelById(bADepositEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    scope.Complete();
                }
                response.RefId = bADepositEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        #region Insert/Update AccountBalance Function

        /// <summary>
        ///     Adds the account balance for debit.
        /// </summary>
        /// <param name="baDepositEntity">The ca payment entity.</param>
        /// <param name="baDepositDetailEntity">The ba deposit detail entity.</param>
        /// <returns>AccountBalanceEntity.</returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(BADepositEntity baDepositEntity,
            BADepositDetailEntity baDepositDetailEntity)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = baDepositDetailEntity.DebitAccount,
                CurrencyCode = baDepositEntity.CurrencyCode,
                ExchangeRate = baDepositEntity.ExchangeRate,
                BalanceDate = baDepositEntity.PostedDate,
                MovementDebitAmountOC = baDepositDetailEntity.AmountOC,
                MovementDebitAmount = baDepositDetailEntity.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = baDepositDetailEntity.BudgetSourceId,
                BudgetChapterCode = baDepositDetailEntity.BudgetChapterCode,
                BudgetKindItemCode = baDepositDetailEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = baDepositDetailEntity.BudgetSubKindItemCode,
                BudgetItemCode = baDepositDetailEntity.BudgetItemCode,
                BudgetSubItemCode = baDepositDetailEntity.BudgetSubItemCode,
                MethodDistributeId = baDepositDetailEntity.MethodDistributeId,
                AccountingObjectId = baDepositEntity.AccountingObjectId,
                ActivityId = baDepositDetailEntity.ActivityId,
                ProjectId = baDepositDetailEntity.ProjectId,
                BankAccount = baDepositEntity.BankId,
                FundStructureId = baDepositDetailEntity.FundStructureId,
                ProjectActivityId = baDepositDetailEntity.ProjectActivityId,
                BudgetDetailItemCode = baDepositDetailEntity.BudgetDetailItemCode
            };
        }

        /// <summary>
        ///     Adds the account balance for credit.
        /// </summary>
        /// <param name="baDepositEntity">The ba deposit entity.</param>
        /// <param name="baDepositDetailEntity">The payment detail.</param>
        /// <returns>AccountBalanceEntity.</returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(BADepositEntity baDepositEntity,
            BADepositDetailEntity baDepositDetailEntity)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = baDepositDetailEntity.CreditAccount,
                CurrencyCode = baDepositEntity.CurrencyCode,
                ExchangeRate = baDepositEntity.ExchangeRate,
                BalanceDate = baDepositEntity.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = baDepositDetailEntity.AmountOC,
                MovementCreditAmount = baDepositDetailEntity.Amount,
                BudgetSourceId = baDepositDetailEntity.BudgetSourceId,
                BudgetChapterCode = baDepositDetailEntity.BudgetChapterCode,
                BudgetKindItemCode = baDepositDetailEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = baDepositDetailEntity.BudgetSubKindItemCode,
                BudgetItemCode = baDepositDetailEntity.BudgetItemCode,
                BudgetSubItemCode = baDepositDetailEntity.BudgetSubItemCode,
                MethodDistributeId = baDepositDetailEntity.MethodDistributeId,
                AccountingObjectId = baDepositEntity.AccountingObjectId,
                ActivityId = baDepositDetailEntity.ActivityId,
                ProjectId = baDepositDetailEntity.ProjectId,
                BankAccount = baDepositEntity.BankId,
                FundStructureId = baDepositDetailEntity.FundStructureId,
                ProjectActivityId = baDepositDetailEntity.ProjectActivityId,
                BudgetDetailItemCode = baDepositDetailEntity.BudgetDetailItemCode
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
        /// <param name="baDepositEntity">The ca payment entity.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(BADepositEntity baDepositEntity)
        {
            var baDepositDetails = BADepositDetailDao.GetBADepositDetailsByRefId(baDepositEntity.RefId);
            foreach (var baDepositDetailEntity in baDepositDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(baDepositEntity, baDepositDetailEntity);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit,
                        accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(baDepositEntity, baDepositDetailEntity);
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
        /// <param name="baDepositEntity">The ba deposit entity.</param>
        /// <param name="baDepositDetailEntity">The payment detail.</param>
        public void InsertAccountBalance(BADepositEntity baDepositEntity, BADepositDetailEntity baDepositDetailEntity)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(baDepositEntity, baDepositDetailEntity);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(baDepositEntity, baDepositDetailEntity);
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