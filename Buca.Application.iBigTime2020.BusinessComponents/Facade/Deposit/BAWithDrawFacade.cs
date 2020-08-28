/***********************************************************************
 * <copyright file="bawithdrawfacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 23, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Deposit;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory;
using Buca.Application.iBigTime2020.DataAccess.SqlServer;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.System;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Deposit
{
    /// <summary>
    ///     BAWithDrawFacade
    /// </summary>
    public class BAWithDrawFacade : FacadeBase
    {
        private static readonly IBAWithDrawDao BAWithDrawDao = DataAccess.DataAccess.BAWithDrawDao;
        private static readonly IBAWithDrawDetailDao BAWithDrawDetailDao = DataAccess.DataAccess.BAWithDrawDetailDao;
        private static readonly IBAWithDrawDetailFixedAssetDao BAWithDrawDetailFixedAssetDao = DataAccess.DataAccess.BAWithDrawDetailFixedAssetDao;
        private static readonly IBAWithDrawDetailPurchaseDao BAWithDrawDetailPurchaseDao = DataAccess.DataAccess.BAWithDrawDetailPurchaseDao;
        private static readonly IBAWithdrawDetailSalaryDao BAWithdrawDetailSalaryDao = DataAccess.DataAccess.BAWithdrawDetailSalaryDao;
        private static readonly IBAWithdrawDetailTaxDao BAWithdrawDetailTaxDao = DataAccess.DataAccess.BAWithdrawDetailTaxDao;
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IInventoryLedgerDao InventoryLedgerDao = DataAccess.DataAccess.InventoryLedgerDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;
        private static readonly IBAWithDrawDetailParallelDao BAWithDrawDetailParallelDao = DataAccess.DataAccess.BAWithDrawDetailParallelDao;
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;

        /// <summary>
        ///     Gets the ba deposits.
        /// </summary>
        /// <returns></returns>
        public List<BAWithDrawEntity> GetBAWithDraws()
        {
            return BAWithDrawDao.GetBAWithDraws();
        }

        /// <summary>
        ///     Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public List<BAWithDrawEntity> GetBAWithDrawsByRefTypeId(int refTypeId)
        {
            return BAWithDrawDao.GetBAWithDrawsByRefTypeId(refTypeId);
        }

        /// <summary>
        ///     Gets the ba deposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public List<BAWithDrawEntity> GetBAWithDrawsByRefTypeId(int refTypeId, DateTime refDate)
        {
            return BAWithDrawDao.GetBAWithDrawsByYearOfRefDate(refTypeId, (short)refDate.Year);
        }

        /// <summary>
        ///     Gets the ba deposit by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasFixedAsset">if set to <c>true</c> [has fixed asset].</param>
        /// <param name="hasPurchase">if set to <c>true</c> [has purchase].</param>
        /// <param name="hasSalary">if set to <c>true</c> [has salary].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        /// <returns></returns>
        public BAWithDrawEntity GetBAWithDrawByRefNo(string refNo, bool hasDetail, bool hasFixedAsset, bool hasPurchase,
            bool hasSalary, bool hasTax)
        {
            var bAWithDraw = BAWithDrawDao.GetBAWithDrawByRefNo(refNo);
            if (bAWithDraw == null)
                return null;
            if (hasDetail)
                bAWithDraw.BAWithDrawDetails = BAWithDrawDetailDao.GetBAWithDrawDetailEntitysByRefId(bAWithDraw.RefId);
            if (hasFixedAsset)
                bAWithDraw.BAWithDrawDetailFixedAssets =
                    BAWithDrawDetailFixedAssetDao.GetBAWithDrawDetailFixedAssetEntitysByRefId(
                        bAWithDraw.RefId);
            if (hasPurchase)
                bAWithDraw.BAWithDrawDetailPurchases =
                    BAWithDrawDetailPurchaseDao.GetBAWithDrawDetailPurchaseEntitysByRefId(bAWithDraw.RefId);
            if (hasSalary)
                bAWithDraw.BAWithdrawDetailSalarys =
                    BAWithdrawDetailSalaryDao.GetBAWithdrawDetailSalaryEntitysByRefId(bAWithDraw.RefId);
            if (hasTax)
                bAWithDraw.BAWithdrawDetailTaxs =
                    BAWithdrawDetailTaxDao.GetBAWithdrawDetailTaxEntitysByRefId(bAWithDraw.RefId);
            return bAWithDraw;
        }

        /// <summary>
        ///     Gets the ba deposit by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="hasDetail">if set to <c>true</c> [has detail].</param>
        /// <param name="hasFixedAsset">if set to <c>true</c> [has fixed asset].</param>
        /// <param name="hasPurchase">if set to <c>true</c> [has purchase].</param>
        /// <param name="hasSalary">if set to <c>true</c> [has salary].</param>
        /// <param name="hasTax">if set to <c>true</c> [has tax].</param>
        /// <returns></returns>
        public BAWithDrawEntity GetBAWithDrawByRefId(string refId, bool hasDetail, bool hasFixedAsset, bool hasPurchase,
            bool hasSalary, bool hasTax)
        {
            var bAWithDraw = BAWithDrawDao.GetBAWithDraw(refId);
            if (bAWithDraw == null)
                return null;
            if (hasDetail)
                bAWithDraw.BAWithDrawDetails = BAWithDrawDetailDao.GetBAWithDrawDetailEntitysByRefId(bAWithDraw.RefId);
            if (hasFixedAsset)
                bAWithDraw.BAWithDrawDetailFixedAssets =
                    BAWithDrawDetailFixedAssetDao.GetBAWithDrawDetailFixedAssetEntitysByRefId(
                        bAWithDraw.RefId);
            if (hasPurchase)
                bAWithDraw.BAWithDrawDetailPurchases =
                    BAWithDrawDetailPurchaseDao.GetBAWithDrawDetailPurchaseEntitysByRefId(bAWithDraw.RefId);
            if (hasSalary)
                bAWithDraw.BAWithdrawDetailSalarys =
                    BAWithdrawDetailSalaryDao.GetBAWithdrawDetailSalaryEntitysByRefId(bAWithDraw.RefId);
            if (hasTax)
                bAWithDraw.BAWithdrawDetailTaxs =
                    BAWithdrawDetailTaxDao.GetBAWithdrawDetailTaxEntitysByRefId(bAWithDraw.RefId);

            //get parallel default
            bAWithDraw.BAWithDrawDetailParallels = BAWithDrawDetailParallelDao.GetBAWithDrawDetailParallelByRefId(bAWithDraw.RefId);

            return bAWithDraw;
        }

        /// <summary>
        ///     Gets the ba deposit by date month.
        /// </summary>
        /// <param name="dateMonth">The date month.</param>
        /// <returns></returns>
        public BAWithDrawEntity GetBAWithDrawByDateMonth(DateTime dateMonth)
        {
            return BAWithDrawDao.GetBAWithDrawBySalary(dateMonth);
        }

        /// <summary>
        /// Inserts the ba deposit.
        /// </summary>
        /// <param name="bAWithDrawEntity">The b a deposit entity.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>BAWithDrawResponse.</returns>
        public BAWithDrawResponse InsertBAWithDraw(BAWithDrawEntity bAWithDrawEntity, bool isAutoGenerateParallel = false)
        {
            var response = new BAWithDrawResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!bAWithDrawEntity.Validate())
                {
                    foreach (var error in bAWithDrawEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    //check ma trung
                    var bAWithDrawEntityExited = BAWithDrawDao.GetBAWithDrawByRefNo(bAWithDrawEntity.RefNo.Trim(), bAWithDrawEntity.PostedDate);
                    if (bAWithDrawEntityExited != null && bAWithDrawEntityExited.PostedDate.Year == bAWithDrawEntity.PostedDate.Year)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Số chứng từ '" + bAWithDrawEntity.RefNo + @"' đã tồn tại!";
                        return response;
                    }

                    bAWithDrawEntity.RefId = Guid.NewGuid().ToString();
                    bAWithDrawEntity.RefType = (int)BuCA.Enum.RefType.BAWithDraw;
                    response.Message = BAWithDrawDao.InsertBAWithDraw(bAWithDrawEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region insert bAWithDrawDetailEntity

                    if (bAWithDrawEntity.BAWithDrawDetails != null)
                    {
                        foreach (var bAWithDrawDetailEntity in bAWithDrawEntity.BAWithDrawDetails)
                        {
                            bAWithDrawDetailEntity.RefDetailId = Guid.NewGuid().ToString();
                            bAWithDrawDetailEntity.RefId = bAWithDrawEntity.RefId;
                            response.Message = BAWithDrawDetailDao.InsertBAWithDrawDetailEntity(bAWithDrawDetailEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region insert bang GeneralLedger

                            if (bAWithDrawDetailEntity.DebitAccount != null && bAWithDrawDetailEntity.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    ProjectId = bAWithDrawDetailEntity.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailEntity.BudgetSourceId,
                                    Description = bAWithDrawDetailEntity.Description,
                                    RefDetailId = bAWithDrawDetailEntity.RefDetailId,
                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                    BudgetSubKindItemCode = bAWithDrawDetailEntity.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailEntity.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    BudgetItemCode = bAWithDrawDetailEntity.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailEntity.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailEntity.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailEntity.BudgetDetailItemCode,
                                    AccountNumber = bAWithDrawDetailEntity.DebitAccount,
                                    CorrespondingAccountNumber = bAWithDrawDetailEntity.CreditAccount,
                                    DebitAmount =
                                        bAWithDrawDetailEntity.DebitAccount == null ? 0 : bAWithDrawDetailEntity.Amount,
                                    DebitAmountOC =
                                        bAWithDrawDetailEntity.DebitAccount == null ? 0 : bAWithDrawDetailEntity.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = bAWithDrawDetailEntity.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    OrgRefNo = bAWithDrawDetailEntity.OrgRefNo,
                                    OrgRefDate = bAWithDrawDetailEntity.OrgRefDate,
                                    BankId = bAWithDrawDetailEntity.BankId,
                                    BudgetExpenseId = bAWithDrawDetailEntity.BudgetExpenseId,
                                    BudgetChapterCode = bAWithDrawDetailEntity.BudgetChapterCode,
                                    AccountingObjectId = bAWithDrawDetailEntity.AccountingObjectId,
                                    ActivityId = bAWithDrawDetailEntity.ActivityId,
                                };

                                // Thêm 2 dòng vào bảng GeneralLedger
                                // dòng 1 là Debit amount
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                // dòng 2 credit amount
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = bAWithDrawDetailEntity.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = bAWithDrawDetailEntity.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = bAWithDrawDetailEntity.Amount;
                                generalLedgerEntity.CreditAmountOC = bAWithDrawDetailEntity.AmountOC;
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                // Chỗ này insert thừa rồi a thắng ơi
                                //generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                //generalLedgerEntity.AccountNumber = bAWithDrawDetailEntity.CreditAccount;
                                //generalLedgerEntity.CorrespondingAccountNumber = bAWithDrawDetailEntity.DebitAccount;
                                //generalLedgerEntity.DebitAmount = 0;
                                //generalLedgerEntity.DebitAmountOC = 0;
                                //generalLedgerEntity.CreditAmount = bAWithDrawDetailEntity.Amount;
                                //generalLedgerEntity.CreditAmountOC = bAWithDrawDetailEntity.AmountOC;
                                //response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                //if (!string.IsNullOrEmpty(response.Message))
                                //{
                                //    response.Acknowledge = AcknowledgeType.Failure;
                                //    return response;
                                //}
                            }
                            else
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    AccountingObjectId = bAWithDrawDetailEntity.AccountingObjectId,
                                    BankId = bAWithDrawDetailEntity.BankId,
                                    BudgetChapterCode = bAWithDrawDetailEntity.BudgetChapterCode,
                                    ProjectId = bAWithDrawDetailEntity.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailEntity.BudgetSourceId,
                                    Description = bAWithDrawDetailEntity.Description,
                                    RefDetailId = bAWithDrawDetailEntity.RefDetailId,
                                    // ExchangeRate = bAWithDrawDetailEntity.ExchangeRate,
                                    ActivityId = bAWithDrawDetailEntity.ActivityId,
                                    BudgetSubKindItemCode = bAWithDrawDetailEntity.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailEntity.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    MethodDistributeId = bAWithDrawDetailEntity.MethodDistributeId,
                                    //OrgRefNo = string.Empty,
                                    //OrgRefDate = null,
                                    OrgRefNo = bAWithDrawDetailEntity.OrgRefNo,
                                    OrgRefDate = bAWithDrawDetailEntity.OrgRefDate,
                                    BudgetItemCode = bAWithDrawDetailEntity.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailEntity.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailEntity.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailEntity.BudgetDetailItemCode,
                                    //CashWithDrawTypeId = bAWithDrawDetailEntity.CashWithdrawTypeId,
                                    AccountNumber = bAWithDrawDetailEntity.DebitAccount ?? bAWithDrawDetailEntity.CreditAccount,
                                    DebitAmount = bAWithDrawDetailEntity.DebitAccount == null ? 0 : bAWithDrawDetailEntity.Amount,
                                    DebitAmountOC = bAWithDrawDetailEntity.DebitAccount == null ? 0 : bAWithDrawDetailEntity.AmountOC,
                                    CreditAmount = bAWithDrawDetailEntity.CreditAccount == null ? 0 : bAWithDrawDetailEntity.Amount,
                                    CreditAmountOC = bAWithDrawDetailEntity.CreditAccount == null ? 0 : bAWithDrawDetailEntity.AmountOC,
                                    FundStructureId = bAWithDrawDetailEntity.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    BudgetExpenseId = bAWithDrawDetailEntity.BudgetExpenseId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }

                            #endregion

                            InsertAccountBalance(bAWithDrawEntity, bAWithDrawDetailEntity);

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bAWithDrawEntity.RefType,
                                RefId = bAWithDrawEntity.RefId,
                                RefDetailId = bAWithDrawDetailEntity.RefDetailId,
                                OrgRefDate = bAWithDrawDetailEntity.OrgRefDate,
                                OrgRefNo = bAWithDrawDetailEntity.OrgRefNo,
                                RefDate = bAWithDrawEntity.RefDate,
                                PostedDate = bAWithDrawEntity.PostedDate,
                                RefNo = bAWithDrawEntity.RefNo,
                                AccountingObjectId = bAWithDrawDetailEntity.AccountingObjectId,
                                ActivityId = bAWithDrawDetailEntity.ActivityId,
                                Amount = bAWithDrawDetailEntity.Amount,
                                AmountOC = bAWithDrawDetailEntity.AmountOC,
                                Approved = null,
                                BankId = bAWithDrawDetailEntity.BankId,
                                BudgetChapterCode = bAWithDrawDetailEntity.BudgetChapterCode,
                                BudgetDetailItemCode = bAWithDrawDetailEntity.BudgetDetailItemCode,
                                BudgetItemCode = bAWithDrawDetailEntity.BudgetItemCode,
                                BudgetKindItemCode = bAWithDrawDetailEntity.BudgetKindItemCode,
                                BudgetSourceId = bAWithDrawDetailEntity.BudgetSourceId,
                                BudgetSubItemCode = bAWithDrawDetailEntity.BudgetSubItemCode,
                                BudgetSubKindItemCode = bAWithDrawDetailEntity.BudgetSubKindItemCode,
                                CashWithDrawTypeId = bAWithDrawDetailEntity.CashWithDrawTypeId,
                                CreditAccount = bAWithDrawDetailEntity.CreditAccount,
                                DebitAccount = bAWithDrawDetailEntity.DebitAccount,
                                Description = bAWithDrawDetailEntity.Description,
                                FundStructureId = bAWithDrawDetailEntity.FundStructureId,
                                TaxAmount = bAWithDrawEntity.TotalTaxAmount,
                                ProjectActivityId = bAWithDrawDetailEntity.ProjectActivityId,
                                MethodDistributeId = bAWithDrawDetailEntity.MethodDistributeId,
                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                ProjectId = bAWithDrawDetailEntity.ProjectId,
                                ToBankId = bAWithDrawEntity.BankId,
                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                BudgetExpenseId = bAWithDrawDetailEntity.BudgetExpenseId,
                                ContractId = bAWithDrawDetailEntity.ContractId,
                            };
                            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            #endregion                        
                        }
                        #region Sinh dinh khoan dong thoi

                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region CAReceiptDetailParallel

                            if (bAWithDrawEntity.BAWithDrawDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var baWithDrawDetailParallel in bAWithDrawEntity.BAWithDrawDetailParallels)
                                {
                                    #region Insert Receipt Detail Parallel

                                    baWithDrawDetailParallel.RefId = bAWithDrawEntity.RefId;
                                    baWithDrawDetailParallel.RefDetailId = Guid.NewGuid().ToString();

                                    if (!baWithDrawDetailParallel.Validate())
                                    {
                                        foreach (var error in baWithDrawDetailParallel.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    response.Message = BAWithDrawDetailParallelDao.InsertBAWithDrawDetailParallel(baWithDrawDetailParallel);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (baWithDrawDetailParallel.DebitAccount != null && baWithDrawDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bAWithDrawEntity.RefType,
                                            RefNo = bAWithDrawEntity.RefNo,
                                            AccountingObjectId = baWithDrawDetailParallel.AccountingObjectId,
                                            BankId = baWithDrawDetailParallel.BankId,
                                            BudgetChapterCode = baWithDrawDetailParallel.BudgetChapterCode,
                                            ProjectId = baWithDrawDetailParallel.ProjectId,
                                            BudgetSourceId = baWithDrawDetailParallel.BudgetSourceId,
                                            Description = baWithDrawDetailParallel.Description,
                                            RefDetailId = baWithDrawDetailParallel.RefDetailId,
                                            ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                            ActivityId = baWithDrawDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = baWithDrawDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                            BudgetKindItemCode = baWithDrawDetailParallel.BudgetKindItemCode,
                                            RefId = bAWithDrawEntity.RefId,
                                            PostedDate = bAWithDrawEntity.PostedDate,
                                            MethodDistributeId = baWithDrawDetailParallel.MethodDistributeId,
                                            OrgRefNo = baWithDrawDetailParallel.OrgRefNo,
                                            OrgRefDate = baWithDrawDetailParallel.OrgRefDate,
                                            BudgetItemCode = baWithDrawDetailParallel.BudgetItemCode,
                                            ListItemId = baWithDrawDetailParallel.ListItemId,
                                            BudgetSubItemCode = baWithDrawDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = baWithDrawDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = baWithDrawDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = baWithDrawDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = baWithDrawDetailParallel.CreditAccount,
                                            DebitAmount = baWithDrawDetailParallel.Amount,
                                            DebitAmountOC = baWithDrawDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = baWithDrawDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bAWithDrawEntity.JournalMemo,
                                            RefDate = bAWithDrawEntity.RefDate,
                                            BudgetExpenseId = baWithDrawDetailParallel.BudgetExpenseId,
                                            ContractId = baWithDrawDetailParallel.ContractId,
                                            CapitalPlanId = baWithDrawDetailParallel.CapitalPlanId
                                        };
                                        response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = baWithDrawDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = baWithDrawDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = baWithDrawDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = baWithDrawDetailParallel.AmountOC;
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
                                            RefType = bAWithDrawEntity.RefType,
                                            RefNo = bAWithDrawEntity.RefNo,
                                            AccountingObjectId = baWithDrawDetailParallel.AccountingObjectId,
                                            BankId = baWithDrawDetailParallel.BankId,
                                            BudgetChapterCode = baWithDrawDetailParallel.BudgetChapterCode,
                                            ProjectId = baWithDrawDetailParallel.ProjectId,
                                            BudgetSourceId = baWithDrawDetailParallel.BudgetSourceId,
                                            Description = baWithDrawDetailParallel.Description,
                                            RefDetailId = baWithDrawDetailParallel.RefDetailId,
                                            ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                            ActivityId = baWithDrawDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = baWithDrawDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                            BudgetKindItemCode = baWithDrawDetailParallel.BudgetKindItemCode,
                                            RefId = bAWithDrawEntity.RefId,
                                            PostedDate = bAWithDrawEntity.PostedDate,
                                            MethodDistributeId = baWithDrawDetailParallel.MethodDistributeId,
                                            OrgRefNo = baWithDrawDetailParallel.OrgRefNo,
                                            OrgRefDate = baWithDrawDetailParallel.OrgRefDate,
                                            BudgetItemCode = baWithDrawDetailParallel.BudgetItemCode,
                                            ListItemId = baWithDrawDetailParallel.ListItemId,
                                            BudgetSubItemCode = baWithDrawDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = baWithDrawDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = baWithDrawDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = baWithDrawDetailParallel.DebitAccount ?? baWithDrawDetailParallel.CreditAccount,
                                            DebitAmount = baWithDrawDetailParallel.DebitAccount == null ? 0 : baWithDrawDetailParallel.Amount,
                                            DebitAmountOC = baWithDrawDetailParallel.DebitAccount == null ? 0 : baWithDrawDetailParallel.AmountOC,
                                            CreditAmount = baWithDrawDetailParallel.CreditAccount == null ? 0 : baWithDrawDetailParallel.Amount,
                                            CreditAmountOC = baWithDrawDetailParallel.CreditAccount == null ? 0 : baWithDrawDetailParallel.AmountOC,
                                            FundStructureId = baWithDrawDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bAWithDrawEntity.JournalMemo,
                                            RefDate = bAWithDrawEntity.RefDate,
                                            BudgetExpenseId = baWithDrawDetailParallel.BudgetExpenseId,
                                            ContractId = baWithDrawDetailParallel.ContractId,
                                            CapitalPlanId = baWithDrawDetailParallel.CapitalPlanId
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
                                        RefType = bAWithDrawEntity.RefType,
                                        RefId = bAWithDrawEntity.RefId,
                                        RefDetailId = baWithDrawDetailParallel.RefDetailId,
                                        OrgRefDate = baWithDrawDetailParallel.OrgRefDate,
                                        OrgRefNo = baWithDrawDetailParallel.OrgRefNo,
                                        RefDate = bAWithDrawEntity.RefDate,
                                        RefNo = bAWithDrawEntity.RefNo,
                                        AccountingObjectId = baWithDrawDetailParallel.AccountingObjectId,
                                        ActivityId = baWithDrawDetailParallel.ActivityId,
                                        Amount = baWithDrawDetailParallel.Amount,
                                        AmountOC = baWithDrawDetailParallel.AmountOC,
                                        //Approved = receiptDetail.Approved,
                                        BankId = baWithDrawDetailParallel.BankId,
                                        BudgetChapterCode = baWithDrawDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = baWithDrawDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = baWithDrawDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = baWithDrawDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = baWithDrawDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = baWithDrawDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = baWithDrawDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = baWithDrawDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = baWithDrawDetailParallel.CreditAccount,
                                        DebitAccount = baWithDrawDetailParallel.DebitAccount,
                                        Description = baWithDrawDetailParallel.Description,
                                        FundStructureId = baWithDrawDetailParallel.FundStructureId,
                                        //ProjectActivityId = baWithDrawDetailParallel.ProjectActivityId,
                                        MethodDistributeId = baWithDrawDetailParallel.MethodDistributeId,
                                        JournalMemo = bAWithDrawEntity.JournalMemo,
                                        ProjectId = baWithDrawDetailParallel.ProjectId,
                                        ToBankId = baWithDrawDetailParallel.BankId,
                                        PostedDate = bAWithDrawEntity.PostedDate,
                                        CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                        ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                        BudgetExpenseId = baWithDrawDetailParallel.BudgetExpenseId,
                                        ContractId = baWithDrawDetailParallel.ContractId,
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
                        }
                        else
                        {
                            //truong hop sinh tu dong se sinh theo chung tu chi tiet
                            if (bAWithDrawEntity.BAWithDrawDetails != null)
                            {
                                foreach (var depositDetail in bAWithDrawEntity.BAWithDrawDetails)
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

                                            var withDrawDetailParallel = new BAWithDrawDetailParallelEntity()
                                            {
                                                RefId = bAWithDrawEntity.RefId,
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
                                                OrgRefNo = depositDetail.OrgRefNo,
                                                OrgRefDate = depositDetail.OrgRefDate,
                                                FundStructureId = depositDetail.FundStructureId,
                                                BudgetExpenseId = depositDetail.BudgetExpenseId,
                                                BankId = depositDetail.BankId
                                                //withDrawDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                                //withDrawDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                            };
                                            if (!withDrawDetailParallel.Validate())
                                            {
                                                foreach (var error in withDrawDetailParallel.ValidationErrors)
                                                    response.Message += error + Environment.NewLine;
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                            response.Message =
                                                BAWithDrawDetailParallelDao.InsertBAWithDrawDetailParallel(
                                                    withDrawDetailParallel);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (withDrawDetailParallel.DebitAccount != null && withDrawDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber = withDrawDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = withDrawDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = withDrawDetailParallel.Amount,
                                                    DebitAmountOC = withDrawDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(response.Message))
                                                {
                                                    response.Acknowledge = AcknowledgeType.Failure;
                                                    return response;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = withDrawDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = withDrawDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = withDrawDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = withDrawDetailParallel.AmountOC;
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
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    withDrawDetailParallel.DebitAccount ??
                                                    withDrawDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    withDrawDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    withDrawDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    withDrawDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    withDrawDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.AmountOC,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
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
                                                RefType = bAWithDrawEntity.RefType,
                                                RefId = bAWithDrawEntity.RefId,
                                                RefDetailId = withDrawDetailParallel.RefDetailId,
                                                OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                RefDate = bAWithDrawEntity.RefDate,
                                                PostedDate = bAWithDrawEntity.PostedDate,
                                                RefNo = bAWithDrawEntity.RefNo,
                                                AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                ActivityId = withDrawDetailParallel.ActivityId,
                                                Amount = withDrawDetailParallel.Amount,
                                                AmountOC = withDrawDetailParallel.AmountOC,
                                                //Approved = receiptDetail.Approved,
                                                BankId = withDrawDetailParallel.BankId,
                                                BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = withDrawDetailParallel.CreditAccount,
                                                DebitAccount = withDrawDetailParallel.DebitAccount,
                                                Description = withDrawDetailParallel.Description,
                                                FundStructureId = withDrawDetailParallel.FundStructureId,
                                                //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                                MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                                ProjectId = withDrawDetailParallel.ProjectId,
                                                ToBankId = withDrawDetailParallel.BankId,
                                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId,
                                                ContractId = withDrawDetailParallel.ContractId,
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
                    }
                    #endregion

                    #region insert BaWithDrawDetailFixedAssets

                    if (bAWithDrawEntity.BAWithDrawDetailFixedAssets != null)
                    {
                        foreach (var bAWithDrawDetailFixedAsset in bAWithDrawEntity.BAWithDrawDetailFixedAssets)
                        {
                            bAWithDrawDetailFixedAsset.RefDetailId = Guid.NewGuid().ToString();
                            bAWithDrawDetailFixedAsset.RefId = bAWithDrawEntity.RefId;
                            response.Message =
                                BAWithDrawDetailFixedAssetDao.InsertBAWithDrawDetailFixedAssetEntity(
                                    bAWithDrawDetailFixedAsset);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bAWithDrawEntity.RefType,
                                RefId = bAWithDrawEntity.RefId,
                                RefDetailId = bAWithDrawDetailFixedAsset.RefDetailId,
                                OrgRefDate = bAWithDrawDetailFixedAsset.OrgRefDate,
                                OrgRefNo = bAWithDrawDetailFixedAsset.OrgRefNo,
                                RefDate = bAWithDrawEntity.RefDate,
                                PostedDate = bAWithDrawEntity.PostedDate,
                                RefNo = bAWithDrawEntity.RefNo,
                                AccountingObjectId = bAWithDrawDetailFixedAsset.AccountingObjectId,
                                ActivityId = bAWithDrawDetailFixedAsset.ActivityId,
                                Amount = bAWithDrawDetailFixedAsset.Amount,
                                AmountOC = bAWithDrawDetailFixedAsset.Amount,
                                Approved = null,
                                BankId = bAWithDrawDetailFixedAsset.BankId,
                                BudgetChapterCode = bAWithDrawDetailFixedAsset.BudgetChapterCode,
                                BudgetDetailItemCode = bAWithDrawDetailFixedAsset.BudgetDetailItemCode,
                                BudgetItemCode = bAWithDrawDetailFixedAsset.BudgetItemCode,
                                BudgetKindItemCode = bAWithDrawDetailFixedAsset.BudgetKindItemCode,
                                BudgetSourceId = bAWithDrawDetailFixedAsset.BudgetSourceId,
                                BudgetSubItemCode = bAWithDrawDetailFixedAsset.BudgetSubItemCode,
                                BudgetSubKindItemCode = bAWithDrawDetailFixedAsset.BudgetSubKindItemCode,
                                CashWithDrawTypeId = bAWithDrawDetailFixedAsset.CashWithdrawTypeId,
                                CreditAccount = bAWithDrawDetailFixedAsset.CreditAccount,
                                DebitAccount = bAWithDrawDetailFixedAsset.DebitAccount,
                                Description = bAWithDrawDetailFixedAsset.Description,
                                FundStructureId = bAWithDrawDetailFixedAsset.FundStructureId,
                                TaxAmount = bAWithDrawEntity.TotalTaxAmount,
                                ProjectActivityId = bAWithDrawDetailFixedAsset.ProjectActivityId,
                                MethodDistributeId = bAWithDrawDetailFixedAsset.MethodDistributeId,
                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                ProjectId = bAWithDrawDetailFixedAsset.ProjectId,
                                ToBankId = bAWithDrawEntity.BankId,
                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                BudgetExpenseId = bAWithDrawDetailFixedAsset.BudgetExpenseId,
                            };
                            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            #endregion

                            #region insert bang GeneralLedger

                            if (bAWithDrawDetailFixedAsset.DebitAccount != null && bAWithDrawDetailFixedAsset.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    ProjectId = bAWithDrawDetailFixedAsset.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailFixedAsset.BudgetSourceId,
                                    Description = bAWithDrawDetailFixedAsset.Description,
                                    RefDetailId = bAWithDrawDetailFixedAsset.RefDetailId,
                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                    BudgetSubKindItemCode = bAWithDrawDetailFixedAsset.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailFixedAsset.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    BudgetItemCode = bAWithDrawDetailFixedAsset.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailFixedAsset.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailFixedAsset.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailFixedAsset.BudgetDetailItemCode,
                                    AccountNumber = bAWithDrawDetailFixedAsset.DebitAccount,
                                    CorrespondingAccountNumber = bAWithDrawDetailFixedAsset.CreditAccount,
                                    DebitAmount =
                                        bAWithDrawDetailFixedAsset.DebitAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    DebitAmountOC =
                                        bAWithDrawDetailFixedAsset.DebitAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = bAWithDrawDetailFixedAsset.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    OrgRefNo = bAWithDrawDetailFixedAsset.OrgRefNo,
                                    OrgRefDate = bAWithDrawDetailFixedAsset.OrgRefDate,
                                    BankId = bAWithDrawDetailFixedAsset.BankId,
                                    BudgetExpenseId = bAWithDrawDetailFixedAsset.BudgetExpenseId,
                                    BudgetChapterCode = bAWithDrawDetailFixedAsset.BudgetChapterCode,
                                    AccountingObjectId = bAWithDrawDetailFixedAsset.AccountingObjectId
                                };

                                // Thêm 2 dòng vào bảng GeneralLedger
                                // dòng 1 là Debit amount
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                // dòng 2 credit amount
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = bAWithDrawDetailFixedAsset.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = bAWithDrawDetailFixedAsset.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = bAWithDrawDetailFixedAsset.Amount;
                                generalLedgerEntity.CreditAmountOC = bAWithDrawDetailFixedAsset.Amount;
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                // Chỗ này insert thừa rồi a thắng ơi
                                //generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                //generalLedgerEntity.AccountNumber = bAWithDrawDetailFixedAsset.CreditAccount;
                                //generalLedgerEntity.CorrespondingAccountNumber = bAWithDrawDetailFixedAsset.DebitAccount;
                                //generalLedgerEntity.DebitAmount = 0;
                                //generalLedgerEntity.DebitAmountOC = 0;
                                //generalLedgerEntity.CreditAmount = bAWithDrawDetailFixedAsset.Amount;
                                //generalLedgerEntity.CreditAmountOC = bAWithDrawDetailFixedAsset.AmountOC;
                                //response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                //if (!string.IsNullOrEmpty(response.Message))
                                //{
                                //    response.Acknowledge = AcknowledgeType.Failure;
                                //    return response;
                                //}
                            }
                            else
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    AccountingObjectId = bAWithDrawDetailFixedAsset.AccountingObjectId,
                                    BankId = bAWithDrawDetailFixedAsset.BankId,
                                    BudgetChapterCode = bAWithDrawDetailFixedAsset.BudgetChapterCode,
                                    ProjectId = bAWithDrawDetailFixedAsset.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailFixedAsset.BudgetSourceId,
                                    Description = bAWithDrawDetailFixedAsset.Description,
                                    RefDetailId = bAWithDrawDetailFixedAsset.RefDetailId,
                                    ExchangeRate = 1,
                                    ActivityId = bAWithDrawDetailFixedAsset.ActivityId,
                                    BudgetSubKindItemCode = bAWithDrawDetailFixedAsset.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailFixedAsset.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    MethodDistributeId = bAWithDrawDetailFixedAsset.MethodDistributeId,
                                    //OrgRefNo = string.Empty,
                                    //OrgRefDate = null,
                                    OrgRefNo = bAWithDrawDetailFixedAsset.OrgRefNo,
                                    OrgRefDate = bAWithDrawDetailFixedAsset.OrgRefDate,
                                    BudgetItemCode = bAWithDrawDetailFixedAsset.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailFixedAsset.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailFixedAsset.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailFixedAsset.BudgetDetailItemCode,
                                    CashWithDrawTypeId = bAWithDrawDetailFixedAsset.CashWithdrawTypeId,
                                    AccountNumber = bAWithDrawDetailFixedAsset.DebitAccount ?? bAWithDrawDetailFixedAsset.CreditAccount,
                                    DebitAmount = bAWithDrawDetailFixedAsset.DebitAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    DebitAmountOC = bAWithDrawDetailFixedAsset.DebitAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    CreditAmount = bAWithDrawDetailFixedAsset.CreditAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    CreditAmountOC = bAWithDrawDetailFixedAsset.CreditAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    FundStructureId = bAWithDrawDetailFixedAsset.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    BudgetExpenseId = bAWithDrawDetailFixedAsset.BudgetExpenseId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }

                            #endregion

                            #region FixedAsset Ledger

                            if (bAWithDrawDetailFixedAsset.DebitAccount.StartsWith("21"))
                            {
                                AutoMapper(InsertFixAssetLedger(bAWithDrawDetailFixedAsset, bAWithDrawEntity),
                                    response);
                                if (!string.IsNullOrEmpty(response.Message))
                                    goto Error;
                            }

                            #endregion
                        }

                        #region Sinh dinh khoan dong thoi

                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region CAReceiptDetailParallel

                            if (bAWithDrawEntity.BAWithDrawDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var withDrawDetailParallel in bAWithDrawEntity.BAWithDrawDetailParallels)
                                {
                                    #region Insert Receipt Detail Parallel

                                    withDrawDetailParallel.RefId = bAWithDrawEntity.RefId;
                                    withDrawDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    withDrawDetailParallel.Amount = withDrawDetailParallel.Amount;

                                    if (!withDrawDetailParallel.Validate())
                                    {
                                        foreach (var error in withDrawDetailParallel.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    response.Message = BAWithDrawDetailParallelDao.InsertBAWithDrawDetailParallel(withDrawDetailParallel);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity

                                    if (withDrawDetailParallel.DebitAccount != null && withDrawDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bAWithDrawEntity.RefType,
                                            RefNo = bAWithDrawEntity.RefNo,
                                            AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                            BankId = withDrawDetailParallel.BankId,
                                            BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                            ProjectId = withDrawDetailParallel.ProjectId,
                                            BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                            Description = withDrawDetailParallel.Description,
                                            RefDetailId = withDrawDetailParallel.RefDetailId,
                                            ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                            ActivityId = withDrawDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                            BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                            RefId = bAWithDrawEntity.RefId,
                                            PostedDate = bAWithDrawEntity.PostedDate,
                                            MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                            OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                            OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                            BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                            ListItemId = withDrawDetailParallel.ListItemId,
                                            BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = withDrawDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = withDrawDetailParallel.CreditAccount,
                                            DebitAmount = withDrawDetailParallel.Amount,
                                            DebitAmountOC = withDrawDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = withDrawDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bAWithDrawEntity.JournalMemo,
                                            RefDate = bAWithDrawEntity.RefDate,
                                            BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                        };
                                        response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = withDrawDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = withDrawDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = withDrawDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = withDrawDetailParallel.AmountOC;
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
                                            RefType = bAWithDrawEntity.RefType,
                                            RefNo = bAWithDrawEntity.RefNo,
                                            AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                            BankId = withDrawDetailParallel.BankId,
                                            BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                            ProjectId = withDrawDetailParallel.ProjectId,
                                            BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                            Description = withDrawDetailParallel.Description,
                                            RefDetailId = withDrawDetailParallel.RefDetailId,
                                            ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                            ActivityId = withDrawDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                            BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                            RefId = bAWithDrawEntity.RefId,
                                            PostedDate = bAWithDrawEntity.PostedDate,
                                            MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                            OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                            OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                            BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                            ListItemId = withDrawDetailParallel.ListItemId,
                                            BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = withDrawDetailParallel.DebitAccount ?? withDrawDetailParallel.CreditAccount,
                                            DebitAmount = withDrawDetailParallel.DebitAccount == null ? 0 : withDrawDetailParallel.Amount,
                                            DebitAmountOC = withDrawDetailParallel.DebitAccount == null ? 0 : withDrawDetailParallel.AmountOC,
                                            CreditAmount = withDrawDetailParallel.CreditAccount == null ? 0 : withDrawDetailParallel.Amount,
                                            CreditAmountOC = withDrawDetailParallel.CreditAccount == null ? 0 : withDrawDetailParallel.AmountOC,
                                            FundStructureId = withDrawDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bAWithDrawEntity.JournalMemo,
                                            RefDate = bAWithDrawEntity.RefDate,
                                            BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
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
                                        RefType = bAWithDrawEntity.RefType,
                                        RefId = bAWithDrawEntity.RefId,
                                        RefDetailId = withDrawDetailParallel.RefDetailId,
                                        OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                        OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                        RefDate = bAWithDrawEntity.RefDate,
                                        PostedDate = bAWithDrawEntity.PostedDate,
                                        RefNo = bAWithDrawEntity.RefNo,
                                        AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                        ActivityId = withDrawDetailParallel.ActivityId,
                                        Amount = withDrawDetailParallel.Amount,
                                        AmountOC = withDrawDetailParallel.AmountOC,
                                        //Approved = receiptDetail.Approved,
                                        BankId = withDrawDetailParallel.BankId,
                                        BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = withDrawDetailParallel.CreditAccount,
                                        DebitAccount = withDrawDetailParallel.DebitAccount,
                                        Description = withDrawDetailParallel.Description,
                                        FundStructureId = withDrawDetailParallel.FundStructureId,
                                        //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                        MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                        JournalMemo = bAWithDrawEntity.JournalMemo,
                                        ProjectId = withDrawDetailParallel.ProjectId,
                                        ToBankId = withDrawDetailParallel.BankId,
                                        ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                        CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                        BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId,
                                        ContractId = withDrawDetailParallel.ContractId,
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
                            if (bAWithDrawEntity.BAWithDrawDetailFixedAssets != null)
                            {
                                foreach (var depositDetail in bAWithDrawEntity.BAWithDrawDetailFixedAssets)
                                {
                                    var autoBusinessParallelEntitys = new List<AutoBusinessParallelEntity>();
                                    if (bAWithDrawEntity.Parallels != null && bAWithDrawEntity.Parallels.Count > 0)
                                    {
                                        bAWithDrawEntity.Parallels.ForEach(panal =>
                                        {
                                            var autoBusinessParallelEntity = new AutoBusinessParallelEntity()
                                            {
                                                DebitAccountParallel = panal.Debit,
                                                CreditAccountParallel = panal.Credit
                                            };
                                            autoBusinessParallelEntitys.Add(autoBusinessParallelEntity);
                                        });
                                    }
                                    else
                                    {
                                        autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                                 depositDetail.DebitAccount, depositDetail.CreditAccount,
                                                 depositDetail.BudgetSourceId,
                                                 depositDetail.BudgetChapterCode, depositDetail.BudgetKindItemCode,
                                                 depositDetail.BudgetSubKindItemCode, depositDetail.BudgetItemCode,
                                                 depositDetail.BudgetSubItemCode,
                                                 depositDetail.MethodDistributeId, depositDetail.CashWithdrawTypeId);
                                    }
                                    //insert dl moi
                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region BADepositDetails

                                            var withDrawDetailParallel = new BAWithDrawDetailParallelEntity()
                                            {
                                                RefId = bAWithDrawEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = depositDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = depositDetail.Amount * bAWithDrawEntity.ExchangeRate,
                                                AmountOC = depositDetail.Amount,
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
                                                    depositDetail.CashWithdrawTypeId,
                                                AccountingObjectId = depositDetail.AccountingObjectId,
                                                ActivityId = depositDetail.ActivityId,
                                                ProjectId = depositDetail.ProjectId,
                                                ListItemId = depositDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = depositDetail.SortOrder,
                                                OrgRefNo = depositDetail.OrgRefNo,
                                                OrgRefDate = depositDetail.OrgRefDate,
                                                FundStructureId = depositDetail.FundStructureId,
                                                BudgetExpenseId = depositDetail.BudgetExpenseId,
                                                BankId = depositDetail.BankId
                                                //withDrawDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                                //withDrawDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                            };
                                            if (!withDrawDetailParallel.Validate())
                                            {
                                                foreach (var error in withDrawDetailParallel.ValidationErrors)
                                                    response.Message += error + Environment.NewLine;
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                            response.Message =
                                                BAWithDrawDetailParallelDao.InsertBAWithDrawDetailParallel(
                                                    withDrawDetailParallel);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (withDrawDetailParallel.DebitAccount != null && withDrawDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    withDrawDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = withDrawDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = withDrawDetailParallel.AmountOC *
                                                          bAWithDrawEntity.ExchangeRate,
                                                    DebitAmountOC = withDrawDetailParallel.Amount,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(response.Message))
                                                {
                                                    response.Acknowledge = AcknowledgeType.Failure;
                                                    return response;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = withDrawDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = withDrawDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = withDrawDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = withDrawDetailParallel.AmountOC;
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
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    withDrawDetailParallel.DebitAccount ??
                                                    withDrawDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    withDrawDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    withDrawDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    CreditAmount =
                                                    withDrawDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    withDrawDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
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
                                                RefType = bAWithDrawEntity.RefType,
                                                RefId = bAWithDrawEntity.RefId,
                                                RefDetailId = withDrawDetailParallel.RefDetailId,
                                                OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                RefDate = bAWithDrawEntity.RefDate,
                                                PostedDate = bAWithDrawEntity.PostedDate,
                                                RefNo = bAWithDrawEntity.RefNo,
                                                AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                ActivityId = withDrawDetailParallel.ActivityId,
                                                Amount = withDrawDetailParallel.Amount,
                                                AmountOC = withDrawDetailParallel.AmountOC,
                                                //Approved = receiptDetail.Approved,
                                                BankId = withDrawDetailParallel.BankId,
                                                BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = withDrawDetailParallel.CreditAccount,
                                                DebitAccount = withDrawDetailParallel.DebitAccount,
                                                Description = withDrawDetailParallel.Description,
                                                FundStructureId = withDrawDetailParallel.FundStructureId,
                                                //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                                MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                                ProjectId = withDrawDetailParallel.ProjectId,
                                                ToBankId = withDrawDetailParallel.BankId,
                                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId,
                                                ContractId = withDrawDetailParallel.ContractId,
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
                    }
                    #endregion

                    #region insert BaWithDrawDetailPurchases

                    if (bAWithDrawEntity.BAWithDrawDetailPurchases != null)
                    {
                        foreach (var bAWithDrawDetailSale in bAWithDrawEntity.BAWithDrawDetailPurchases)
                        {
                            bAWithDrawDetailSale.RefDetailId = Guid.NewGuid().ToString();
                            bAWithDrawDetailSale.RefId = bAWithDrawEntity.RefId;
                            response.Message =
                                BAWithDrawDetailPurchaseDao.InsertBAWithDrawDetailPurchaseEntity(bAWithDrawDetailSale);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert InventoryLedger
                            var inventoryLedgerEntity = new InventoryLedgerEntity
                            {
                                InventoryLedgerId = Guid.NewGuid().ToString(),
                                RefId = bAWithDrawEntity.RefId,
                                RefType = bAWithDrawEntity.RefType,
                                RefNo = bAWithDrawEntity.RefNo,
                                RefDate = bAWithDrawEntity.RefDate,
                                PostedDate = bAWithDrawEntity.PostedDate,
                                StockId = bAWithDrawDetailSale.StockId,
                                InventoryItemId = bAWithDrawDetailSale.InventoryItemId,
                                BudgetSourceId = bAWithDrawDetailSale.BudgetSourceId,
                                Description = bAWithDrawDetailSale.Description,
                                RefDetailId = bAWithDrawDetailSale.RefDetailId,
                                Unit = bAWithDrawDetailSale.Unit,
                                UnitPrice = bAWithDrawDetailSale.UnitPrice,
                                InwardQuantity = (bAWithDrawEntity.RefType == 201 || bAWithDrawEntity.RefType == 158) ? bAWithDrawDetailSale.Quantity : 0,
                                OutwardQuantity = bAWithDrawEntity.RefType == 202 ? bAWithDrawDetailSale.Quantity : 0,
                                OutwardAmount = bAWithDrawEntity.RefType == 202 ? bAWithDrawDetailSale.Amount : 0,
                                InwardAmount = (bAWithDrawEntity.RefType == 201 || bAWithDrawEntity.RefType == 158) ? bAWithDrawDetailSale.Amount : 0,
                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                ExpiryDate = bAWithDrawDetailSale.ExpiryDate,
                                LotNo = bAWithDrawDetailSale.LotNo,
                                RefOrder = bAWithDrawEntity.RefOrder,
                                SortOrder = bAWithDrawDetailSale.SortOrder,
                                AccountNumber = bAWithDrawDetailSale.DebitAccount,
                                CorrespondingAccountNumber = bAWithDrawDetailSale.CreditAccount,
                                InwardAmountBalance = 0,
                                InwardAmountBalanceAfter = 0,
                                InwardQuantityBalance = 0,
                                UnitPriceBalance = 0
                            };
                            response.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion

                            #region insert bang GeneralLedger

                            if (bAWithDrawDetailSale.DebitAccount != null && bAWithDrawDetailSale.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    ProjectId = bAWithDrawDetailSale.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailSale.BudgetSourceId,
                                    Description = bAWithDrawDetailSale.Description,
                                    RefDetailId = bAWithDrawDetailSale.RefDetailId,
                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                    BudgetSubKindItemCode = bAWithDrawDetailSale.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailSale.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    BudgetItemCode = bAWithDrawDetailSale.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailSale.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailSale.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailSale.BudgetDetailItemCode,
                                    AccountNumber = bAWithDrawDetailSale.DebitAccount,
                                    CorrespondingAccountNumber = bAWithDrawDetailSale.CreditAccount,
                                    DebitAmount =
                                        bAWithDrawDetailSale.DebitAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    DebitAmountOC =
                                        bAWithDrawDetailSale.DebitAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = bAWithDrawDetailSale.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    OrgRefNo = bAWithDrawDetailSale.OrgRefNo,
                                    OrgRefDate = bAWithDrawDetailSale.OrgRefDate,
                                    BankId = bAWithDrawDetailSale.BankId,
                                    BudgetExpenseId = bAWithDrawDetailSale.BudgetExpenseId,
                                    BudgetChapterCode = bAWithDrawDetailSale.BudgetChapterCode,
                                    AccountingObjectId = bAWithDrawDetailSale.AccountingObjectId
                                };

                                // Thêm 2 dòng vào bảng GeneralLedger
                                // dòng 1 là Debit amount
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                // dòng 2 credit amount
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = bAWithDrawDetailSale.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = bAWithDrawDetailSale.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = bAWithDrawDetailSale.Amount;
                                generalLedgerEntity.CreditAmountOC = bAWithDrawDetailSale.Amount;
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                // Chỗ này insert thừa rồi a thắng ơi
                                //generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                //generalLedgerEntity.AccountNumber = bAWithDrawDetailSale.CreditAccount;
                                //generalLedgerEntity.CorrespondingAccountNumber = bAWithDrawDetailSale.DebitAccount;
                                //generalLedgerEntity.DebitAmount = 0;
                                //generalLedgerEntity.DebitAmountOC = 0;
                                //generalLedgerEntity.CreditAmount = bAWithDrawDetailSale.Amount;
                                //generalLedgerEntity.CreditAmountOC = bAWithDrawDetailSale.AmountOC;
                                //response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                //if (!string.IsNullOrEmpty(response.Message))
                                //{
                                //    response.Acknowledge = AcknowledgeType.Failure;
                                //    return response;
                                //}
                            }
                            else
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    AccountingObjectId = bAWithDrawDetailSale.AccountingObjectId,
                                    BankId = bAWithDrawDetailSale.BankId,
                                    BudgetChapterCode = bAWithDrawDetailSale.BudgetChapterCode,
                                    ProjectId = bAWithDrawDetailSale.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailSale.BudgetSourceId,
                                    Description = bAWithDrawDetailSale.Description,
                                    RefDetailId = bAWithDrawDetailSale.RefDetailId,
                                    ExchangeRate = 1,
                                    ActivityId = bAWithDrawDetailSale.ActivityId,
                                    BudgetSubKindItemCode = bAWithDrawDetailSale.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailSale.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    MethodDistributeId = bAWithDrawDetailSale.MethodDistributeId,
                                    //OrgRefNo = string.Empty,
                                    //OrgRefDate = null,
                                    OrgRefNo = bAWithDrawDetailSale.OrgRefNo,
                                    OrgRefDate = bAWithDrawDetailSale.OrgRefDate,
                                    BudgetItemCode = bAWithDrawDetailSale.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailSale.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailSale.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailSale.BudgetDetailItemCode,
                                    CashWithDrawTypeId = bAWithDrawDetailSale.CashWithdrawTypeId,
                                    AccountNumber = bAWithDrawDetailSale.DebitAccount ?? bAWithDrawDetailSale.CreditAccount,
                                    DebitAmount = bAWithDrawDetailSale.DebitAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    DebitAmountOC = bAWithDrawDetailSale.DebitAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    CreditAmount = bAWithDrawDetailSale.CreditAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    CreditAmountOC = bAWithDrawDetailSale.CreditAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    FundStructureId = bAWithDrawDetailSale.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    BudgetExpenseId = bAWithDrawDetailSale.BudgetExpenseId
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
                                RefType = bAWithDrawEntity.RefType,
                                RefId = bAWithDrawEntity.RefId,
                                RefDetailId = bAWithDrawDetailSale.RefDetailId,
                                OrgRefDate = bAWithDrawDetailSale.OrgRefDate,
                                OrgRefNo = bAWithDrawDetailSale.OrgRefNo,
                                RefDate = bAWithDrawEntity.RefDate,
                                PostedDate = bAWithDrawEntity.PostedDate,
                                RefNo = bAWithDrawEntity.RefNo,
                                AccountingObjectId = bAWithDrawDetailSale.AccountingObjectId,
                                ActivityId = bAWithDrawDetailSale.ActivityId,
                                Amount = bAWithDrawDetailSale.Amount,
                                AmountOC = bAWithDrawDetailSale.Amount,
                                Approved = null,
                                BankId = bAWithDrawDetailSale.BankId,
                                BudgetChapterCode = bAWithDrawDetailSale.BudgetChapterCode,
                                BudgetDetailItemCode = bAWithDrawDetailSale.BudgetDetailItemCode,
                                BudgetItemCode = bAWithDrawDetailSale.BudgetItemCode,
                                BudgetKindItemCode = bAWithDrawDetailSale.BudgetKindItemCode,
                                BudgetSourceId = bAWithDrawDetailSale.BudgetSourceId,
                                BudgetSubItemCode = bAWithDrawDetailSale.BudgetSubItemCode,
                                BudgetSubKindItemCode = bAWithDrawDetailSale.BudgetSubKindItemCode,
                                CashWithDrawTypeId = bAWithDrawDetailSale.CashWithdrawTypeId,
                                CreditAccount = bAWithDrawDetailSale.CreditAccount,
                                DebitAccount = bAWithDrawDetailSale.DebitAccount,
                                Description = bAWithDrawDetailSale.Description,
                                FundStructureId = bAWithDrawDetailSale.FundStructureId,
                                TaxAmount = bAWithDrawEntity.TotalTaxAmount,
                                ProjectActivityId = bAWithDrawDetailSale.ProjectActivityId,
                                MethodDistributeId = bAWithDrawDetailSale.MethodDistributeId,
                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                ProjectId = bAWithDrawDetailSale.ProjectId,
                                ToBankId = bAWithDrawEntity.BankId,
                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                BudgetExpenseId = bAWithDrawDetailSale.BudgetExpenseId,
                            };
                            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            #endregion                        
                        }

                        #region Sinh dinh khoan dong thoi

                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            
                        }
                        else
                        {
                            //truong hop sinh tu dong se sinh theo chung tu chi tiet
                            if (bAWithDrawEntity.BAWithDrawDetailPurchases != null)
                            {
                                foreach (var depositDetail in bAWithDrawEntity.BAWithDrawDetailPurchases)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                            depositDetail.DebitAccount, depositDetail.CreditAccount,
                                            depositDetail.BudgetSourceId,
                                            depositDetail.BudgetChapterCode, depositDetail.BudgetKindItemCode,
                                            depositDetail.BudgetSubKindItemCode, depositDetail.BudgetItemCode,
                                            depositDetail.BudgetSubItemCode,
                                            depositDetail.MethodDistributeId, depositDetail.CashWithdrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region BADepositDetails

                                            var withDrawDetailParallel = new BAWithDrawDetailParallelEntity()
                                            {
                                                RefId = bAWithDrawEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = depositDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = depositDetail.Amount * bAWithDrawEntity.ExchangeRate,
                                                AmountOC = depositDetail.Amount,
                                                BudgetSourceId = autoBusinessParallelEntity.BudgetSourceIdParallel ?? depositDetail.BudgetSourceId,
                                                BudgetChapterCode = autoBusinessParallelEntity.BudgetChapterCodeParallel ?? depositDetail.BudgetChapterCode,
                                                BudgetKindItemCode = autoBusinessParallelEntity.BudgetKindItemCodeParallel ?? depositDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode = autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ?? depositDetail.BudgetSubKindItemCode,
                                                BudgetItemCode = autoBusinessParallelEntity.BudgetItemCodeParallel ?? depositDetail.BudgetItemCode,
                                                BudgetSubItemCode = autoBusinessParallelEntity.BudgetSubItemCodeParallel ?? depositDetail.BudgetSubItemCode,
                                                MethodDistributeId = autoBusinessParallelEntity.MethodDistributeIdParallel ?? depositDetail.MethodDistributeId,
                                                CashWithdrawTypeId = autoBusinessParallelEntity.CashWithDrawTypeIdParallel ?? depositDetail.CashWithdrawTypeId,
                                                AccountingObjectId = depositDetail.AccountingObjectId,
                                                ActivityId = depositDetail.ActivityId,
                                                ProjectId = depositDetail.ProjectId,
                                                ListItemId = depositDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = depositDetail.SortOrder,
                                                OrgRefNo = depositDetail.OrgRefNo,
                                                OrgRefDate = depositDetail.OrgRefDate,
                                                FundStructureId = depositDetail.FundStructureId,
                                                BudgetExpenseId = depositDetail.BudgetExpenseId,
                                                BankId = depositDetail.BankId,
                                            };
                                            if (!withDrawDetailParallel.Validate())
                                            {
                                                foreach (var error in withDrawDetailParallel.ValidationErrors)
                                                    response.Message += error + Environment.NewLine;
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                            response.Message = BAWithDrawDetailParallelDao.InsertBAWithDrawDetailParallel(withDrawDetailParallel);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (withDrawDetailParallel.DebitAccount != null && withDrawDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber = withDrawDetailParallel.CreditAccount,
                                                    CorrespondingAccountNumber = withDrawDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = withDrawDetailParallel.Amount,
                                                    DebitAmountOC = withDrawDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(response.Message))
                                                {
                                                    response.Acknowledge = AcknowledgeType.Failure;
                                                    return response;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = withDrawDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = withDrawDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = withDrawDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = withDrawDetailParallel.AmountOC;
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
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber = withDrawDetailParallel.DebitAccount ?? withDrawDetailParallel.CreditAccount,
                                                    DebitAmount = withDrawDetailParallel.DebitAccount == null ? 0 : withDrawDetailParallel.Amount,
                                                    DebitAmountOC = withDrawDetailParallel.DebitAccount == null ? 0 : withDrawDetailParallel.AmountOC,
                                                    CreditAmount = withDrawDetailParallel.CreditAccount == null ? 0 : withDrawDetailParallel.Amount,
                                                    CreditAmountOC = withDrawDetailParallel.CreditAccount == null ? 0 : withDrawDetailParallel.AmountOC,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
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
                                                RefType = bAWithDrawEntity.RefType,
                                                RefId = bAWithDrawEntity.RefId,
                                                RefDetailId = withDrawDetailParallel.RefDetailId,
                                                OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                RefDate = bAWithDrawEntity.RefDate,
                                                PostedDate = bAWithDrawEntity.PostedDate,
                                                RefNo = bAWithDrawEntity.RefNo,
                                                AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                ActivityId = withDrawDetailParallel.ActivityId,
                                                Amount = withDrawDetailParallel.Amount,
                                                AmountOC = withDrawDetailParallel.AmountOC,
                                                //Approved = receiptDetail.Approved,
                                                BankId = withDrawDetailParallel.BankId,
                                                BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = withDrawDetailParallel.CreditAccount,
                                                DebitAccount = withDrawDetailParallel.DebitAccount,
                                                Description = withDrawDetailParallel.Description,
                                                FundStructureId = withDrawDetailParallel.FundStructureId,
                                                //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                                MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                                ProjectId = withDrawDetailParallel.ProjectId,
                                                ToBankId = withDrawDetailParallel.BankId,
                                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId,
                                                ContractId = withDrawDetailParallel.ContractId,
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
                    }
                    #endregion

                    #region insert BaWithdrawDetailSalarys

                    if (bAWithDrawEntity.BAWithdrawDetailSalarys != null)
                        foreach (var bAWithDrawDetailTax in bAWithDrawEntity.BAWithdrawDetailSalarys)
                        {
                            bAWithDrawDetailTax.RefDetailId = Guid.NewGuid().ToString();
                            bAWithDrawDetailTax.RefId = bAWithDrawEntity.RefId;
                            response.Message =
                                BAWithdrawDetailSalaryDao.InsertBAWithdrawDetailSalaryEntity(bAWithDrawDetailTax);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    #region insert BaWithdrawDetailTaxs

                    if (bAWithDrawEntity.BAWithdrawDetailTaxs != null)
                        foreach (var bAWithDrawDetailTax in bAWithDrawEntity.BAWithdrawDetailTaxs)
                        {
                            bAWithDrawDetailTax.RefDetailId = Guid.NewGuid().ToString();
                            bAWithDrawDetailTax.RefId = bAWithDrawEntity.RefId;
                            response.Message =
                                BAWithdrawDetailTaxDao.InsertBAWithdrawDetailTaxEntity(bAWithDrawDetailTax);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    Error:
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.RefId = bAWithDrawEntity.RefId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message + "" + ex.StackTrace;
                return response;
            }
        }

        /// <summary>
        /// Updates the ba deposit.
        /// </summary>
        /// <param name="bAWithDrawEntity">The b a deposit entity.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>BAWithDrawResponse.</returns>
        public BAWithDrawResponse UpdateBAWithDraw(BAWithDrawEntity bAWithDrawEntity, bool isAutoGenerateParallel = false)
        {
            var response = new BAWithDrawResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!bAWithDrawEntity.Validate())
                {
                    foreach (var error in bAWithDrawEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    //check ma trung
                    var bAWithDrawEntityExited = BAWithDrawDao.GetBAWithDrawByRefNo(bAWithDrawEntity.RefNo.Trim(), bAWithDrawEntity.PostedDate);
                    if (bAWithDrawEntityExited != null && bAWithDrawEntityExited.PostedDate.Year == bAWithDrawEntity.PostedDate.Year)
                    {
                        if (bAWithDrawEntityExited.RefId != bAWithDrawEntity.RefId)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Số chứng từ '" + bAWithDrawEntity.RefNo + @"' đã tồn tại!";
                            return response;
                        }
                    }

                    response.Message = BAWithDrawDao.UpdateBAWithDraw(bAWithDrawEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // Update account balance
                    // Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới
                    UpdateAccountBalance(bAWithDrawEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    // delete bang BAWithDrawDetailParallel
                    response.Message = BAWithDrawDetailParallelDao.DeleteBAWithDrawDetailParallelById(bAWithDrawEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #region insert bAWithDrawDetailEntity

                    response.Message = BAWithDrawDetailDao.DeleteBAWithDrawDetailEntityByRefId(bAWithDrawEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // delete bang GeneralLedger
                    response.Message = GeneralLedgerDao.DeleteGeneralLedger(bAWithDrawEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    // delete bang DeleteOriginalGeneralLedger
                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bAWithDrawEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    if (bAWithDrawEntity.BAWithDrawDetails != null)
                    {
                        foreach (var bAWithDrawDetailEntity in bAWithDrawEntity.BAWithDrawDetails)
                        {
                            bAWithDrawDetailEntity.RefDetailId = Guid.NewGuid().ToString();
                            bAWithDrawDetailEntity.RefId = bAWithDrawEntity.RefId;
                            response.Message = BAWithDrawDetailDao.InsertBAWithDrawDetailEntity(bAWithDrawDetailEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            // Update account balance
                            // Cộng thêm số tiền mới sau khi sửa chứng từ
                            InsertAccountBalance(bAWithDrawEntity, bAWithDrawDetailEntity);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            #region insert bang GeneralLedger

                            if (bAWithDrawDetailEntity.DebitAccount != null && bAWithDrawDetailEntity.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    ProjectId = bAWithDrawDetailEntity.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailEntity.BudgetSourceId,
                                    Description = bAWithDrawDetailEntity.Description,
                                    RefDetailId = bAWithDrawDetailEntity.RefDetailId,
                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                    BudgetSubKindItemCode = bAWithDrawDetailEntity.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailEntity.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    BudgetItemCode = bAWithDrawDetailEntity.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailEntity.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailEntity.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailEntity.BudgetDetailItemCode,
                                    AccountNumber = bAWithDrawDetailEntity.DebitAccount,
                                    CorrespondingAccountNumber = bAWithDrawDetailEntity.CreditAccount,
                                    DebitAmount =
                                        bAWithDrawDetailEntity.DebitAccount == null ? 0 : bAWithDrawDetailEntity.Amount,
                                    DebitAmountOC =
                                        bAWithDrawDetailEntity.DebitAccount == null ? 0 : bAWithDrawDetailEntity.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = bAWithDrawDetailEntity.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    BankId = bAWithDrawDetailEntity.BankId,
                                    BudgetExpenseId = bAWithDrawDetailEntity.BudgetExpenseId,
                                    BudgetChapterCode = bAWithDrawDetailEntity.BudgetChapterCode,
                                    AccountingObjectId = bAWithDrawDetailEntity.AccountingObjectId,
                                    ActivityId = bAWithDrawDetailEntity.ActivityId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = bAWithDrawDetailEntity.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = bAWithDrawDetailEntity.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = bAWithDrawDetailEntity.Amount;
                                generalLedgerEntity.CreditAmountOC = bAWithDrawDetailEntity.AmountOC;
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
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    AccountingObjectId = bAWithDrawDetailEntity.AccountingObjectId,
                                    BankId = bAWithDrawDetailEntity.BankId,
                                    BudgetChapterCode = bAWithDrawDetailEntity.BudgetChapterCode,
                                    ProjectId = bAWithDrawDetailEntity.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailEntity.BudgetSourceId,
                                    Description = bAWithDrawDetailEntity.Description,
                                    RefDetailId = bAWithDrawDetailEntity.RefDetailId,
                                    // ExchangeRate = bAWithDrawDetailEntity.ExchangeRate,
                                    ActivityId = bAWithDrawDetailEntity.ActivityId,
                                    BudgetSubKindItemCode = bAWithDrawDetailEntity.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailEntity.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    MethodDistributeId = bAWithDrawDetailEntity.MethodDistributeId,
                                    OrgRefNo = string.Empty,
                                    OrgRefDate = null,
                                    BudgetItemCode = bAWithDrawDetailEntity.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailEntity.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailEntity.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailEntity.BudgetDetailItemCode,
                                    //CashWithDrawTypeId = bAWithDrawDetailEntity.CashWithdrawTypeId,
                                    AccountNumber = bAWithDrawDetailEntity.DebitAccount ?? bAWithDrawDetailEntity.CreditAccount,
                                    DebitAmount = bAWithDrawDetailEntity.DebitAccount == null ? 0 : bAWithDrawDetailEntity.Amount,
                                    DebitAmountOC = bAWithDrawDetailEntity.DebitAccount == null ? 0 : bAWithDrawDetailEntity.AmountOC,
                                    CreditAmount = bAWithDrawDetailEntity.CreditAccount == null ? 0 : bAWithDrawDetailEntity.Amount,
                                    CreditAmountOC = bAWithDrawDetailEntity.CreditAccount == null ? 0 : bAWithDrawDetailEntity.AmountOC,
                                    FundStructureId = bAWithDrawDetailEntity.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    BudgetExpenseId = bAWithDrawDetailEntity.BudgetExpenseId
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
                                RefType = bAWithDrawEntity.RefType,
                                RefId = bAWithDrawEntity.RefId,
                                RefDetailId = bAWithDrawDetailEntity.RefDetailId,
                                OrgRefDate = bAWithDrawDetailEntity.OrgRefDate,
                                OrgRefNo = bAWithDrawDetailEntity.OrgRefNo,
                                RefDate = bAWithDrawEntity.RefDate,
                                PostedDate = bAWithDrawEntity.PostedDate,
                                RefNo = bAWithDrawEntity.RefNo,
                                AccountingObjectId = bAWithDrawDetailEntity.AccountingObjectId,
                                ActivityId = bAWithDrawDetailEntity.ActivityId,
                                Amount = bAWithDrawDetailEntity.Amount,
                                AmountOC = bAWithDrawDetailEntity.AmountOC,
                                Approved = null,
                                BankId = bAWithDrawDetailEntity.BankId,
                                BudgetChapterCode = bAWithDrawDetailEntity.BudgetChapterCode,
                                BudgetDetailItemCode = bAWithDrawDetailEntity.BudgetDetailItemCode,
                                BudgetItemCode = bAWithDrawDetailEntity.BudgetItemCode,
                                BudgetKindItemCode = bAWithDrawDetailEntity.BudgetKindItemCode,
                                BudgetSourceId = bAWithDrawDetailEntity.BudgetSourceId,
                                BudgetSubItemCode = bAWithDrawDetailEntity.BudgetSubItemCode,
                                BudgetSubKindItemCode = bAWithDrawDetailEntity.BudgetSubKindItemCode,
                                CashWithDrawTypeId = bAWithDrawDetailEntity.CashWithDrawTypeId,
                                CreditAccount = bAWithDrawDetailEntity.CreditAccount,
                                DebitAccount = bAWithDrawDetailEntity.DebitAccount,
                                Description = bAWithDrawDetailEntity.Description,
                                FundStructureId = bAWithDrawDetailEntity.FundStructureId,
                                TaxAmount = bAWithDrawEntity.TotalTaxAmount,
                                ProjectActivityId = bAWithDrawDetailEntity.ProjectActivityId,
                                MethodDistributeId = bAWithDrawDetailEntity.MethodDistributeId,
                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                ProjectId = bAWithDrawDetailEntity.ProjectId,
                                ToBankId = bAWithDrawEntity.BankId,
                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                BudgetExpenseId = bAWithDrawDetailEntity.BudgetExpenseId,
                                ContractId = bAWithDrawDetailEntity.ContractId,
                            };
                            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion
                        }
                        #region Sinh dinh khoan dong thoi

                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region CAReceiptDetailParallel

                            if (bAWithDrawEntity.BAWithDrawDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var withDrawDetailParallel in bAWithDrawEntity.BAWithDrawDetailParallels)
                                {
                                    #region Insert Receipt Detail Parallel

                                    withDrawDetailParallel.RefId = bAWithDrawEntity.RefId;
                                    withDrawDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    withDrawDetailParallel.Amount = withDrawDetailParallel.Amount;

                                    if (!withDrawDetailParallel.Validate())
                                    {
                                        foreach (var error in withDrawDetailParallel.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    response.Message = BAWithDrawDetailParallelDao.InsertBAWithDrawDetailParallel(withDrawDetailParallel);
                                    if (!string.IsNullOrEmpty(response.Message))
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (withDrawDetailParallel.DebitAccount != null && withDrawDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bAWithDrawEntity.RefType,
                                            RefNo = bAWithDrawEntity.RefNo,
                                            AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                            BankId = withDrawDetailParallel.BankId,
                                            BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                            ProjectId = withDrawDetailParallel.ProjectId,
                                            BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                            Description = withDrawDetailParallel.Description,
                                            RefDetailId = withDrawDetailParallel.RefDetailId,
                                            ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                            ActivityId = withDrawDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                            BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                            RefId = bAWithDrawEntity.RefId,
                                            PostedDate = bAWithDrawEntity.PostedDate,
                                            MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                            OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                            OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                            BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                            ListItemId = withDrawDetailParallel.ListItemId,
                                            BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = withDrawDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = withDrawDetailParallel.CreditAccount,
                                            DebitAmount = withDrawDetailParallel.Amount,
                                            DebitAmountOC = withDrawDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = withDrawDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bAWithDrawEntity.JournalMemo,
                                            RefDate = bAWithDrawEntity.RefDate,
                                            BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                        };
                                        response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(response.Message))
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = withDrawDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = withDrawDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = withDrawDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = withDrawDetailParallel.AmountOC;
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
                                            RefType = bAWithDrawEntity.RefType,
                                            RefNo = bAWithDrawEntity.RefNo,
                                            AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                            BankId = withDrawDetailParallel.BankId,
                                            BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                            ProjectId = withDrawDetailParallel.ProjectId,
                                            BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                            Description = withDrawDetailParallel.Description,
                                            RefDetailId = withDrawDetailParallel.RefDetailId,
                                            ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                            ActivityId = withDrawDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                            BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                            RefId = bAWithDrawEntity.RefId,
                                            PostedDate = bAWithDrawEntity.PostedDate,
                                            MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                            OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                            OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                            BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                            ListItemId = withDrawDetailParallel.ListItemId,
                                            BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = withDrawDetailParallel.DebitAccount ?? withDrawDetailParallel.CreditAccount,
                                            DebitAmount = withDrawDetailParallel.DebitAccount == null ? 0 : withDrawDetailParallel.Amount,
                                            DebitAmountOC = withDrawDetailParallel.DebitAccount == null ? 0 : withDrawDetailParallel.AmountOC,
                                            CreditAmount = withDrawDetailParallel.CreditAccount == null ? 0 : withDrawDetailParallel.Amount,
                                            CreditAmountOC = withDrawDetailParallel.CreditAccount == null ? 0 : withDrawDetailParallel.AmountOC,
                                            FundStructureId = withDrawDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bAWithDrawEntity.JournalMemo,
                                            RefDate = bAWithDrawEntity.RefDate,
                                            BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
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
                                        RefType = bAWithDrawEntity.RefType,
                                        RefId = bAWithDrawEntity.RefId,
                                        RefDetailId = withDrawDetailParallel.RefDetailId,
                                        OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                        OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                        RefDate = bAWithDrawEntity.RefDate,
                                        RefNo = bAWithDrawEntity.RefNo,
                                        AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                        ActivityId = withDrawDetailParallel.ActivityId,
                                        Amount = withDrawDetailParallel.Amount,
                                        AmountOC = withDrawDetailParallel.AmountOC,
                                        //Approved = receiptDetail.Approved,
                                        BankId = withDrawDetailParallel.BankId,
                                        BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = withDrawDetailParallel.CreditAccount,
                                        DebitAccount = withDrawDetailParallel.DebitAccount,
                                        Description = withDrawDetailParallel.Description,
                                        FundStructureId = withDrawDetailParallel.FundStructureId,
                                        //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                        MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                        JournalMemo = bAWithDrawEntity.JournalMemo,
                                        ProjectId = withDrawDetailParallel.ProjectId,
                                        ToBankId = withDrawDetailParallel.BankId,
                                        ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                        CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                        PostedDate = bAWithDrawEntity.PostedDate,
                                        BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId,
                                        ContractId = withDrawDetailParallel.ContractId,
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
                            if (bAWithDrawEntity.BAWithDrawDetails != null)
                            {
                                foreach (var depositDetail in bAWithDrawEntity.BAWithDrawDetails)
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

                                            var withDrawDetailParallel = new BAWithDrawDetailParallelEntity()
                                            {
                                                RefId = bAWithDrawEntity.RefId,
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
                                                OrgRefNo = depositDetail.OrgRefNo,
                                                OrgRefDate = depositDetail.OrgRefDate,
                                                FundStructureId = depositDetail.FundStructureId,
                                                BudgetExpenseId = depositDetail.BudgetExpenseId,
                                                BankId = depositDetail.BankId
                                                //withDrawDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                                //withDrawDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                            };
                                            if (!withDrawDetailParallel.Validate())
                                            {
                                                foreach (var error in withDrawDetailParallel.ValidationErrors)
                                                    response.Message += error + Environment.NewLine;
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                            response.Message = BAWithDrawDetailParallelDao.InsertBAWithDrawDetailParallel(withDrawDetailParallel);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (withDrawDetailParallel.DebitAccount != null && withDrawDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    withDrawDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = withDrawDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = withDrawDetailParallel.Amount,
                                                    DebitAmountOC = withDrawDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(response.Message))
                                                {
                                                    response.Acknowledge = AcknowledgeType.Failure;
                                                    return response;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = withDrawDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = withDrawDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = withDrawDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = withDrawDetailParallel.AmountOC;
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
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    withDrawDetailParallel.DebitAccount ??
                                                    withDrawDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    withDrawDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    withDrawDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    withDrawDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    withDrawDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.AmountOC,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
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
                                                RefType = bAWithDrawEntity.RefType,
                                                RefId = bAWithDrawEntity.RefId,
                                                RefDetailId = withDrawDetailParallel.RefDetailId,
                                                OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                RefDate = bAWithDrawEntity.RefDate,
                                                PostedDate = bAWithDrawEntity.PostedDate,
                                                RefNo = bAWithDrawEntity.RefNo,
                                                AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                ActivityId = withDrawDetailParallel.ActivityId,
                                                Amount = withDrawDetailParallel.Amount,
                                                AmountOC = withDrawDetailParallel.AmountOC,
                                                //Approved = receiptDetail.Approved,
                                                BankId = withDrawDetailParallel.BankId,
                                                BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = withDrawDetailParallel.CreditAccount,
                                                DebitAccount = withDrawDetailParallel.DebitAccount,
                                                Description = withDrawDetailParallel.Description,
                                                FundStructureId = withDrawDetailParallel.FundStructureId,
                                                //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                                MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                                ProjectId = withDrawDetailParallel.ProjectId,
                                                ToBankId = withDrawDetailParallel.BankId,
                                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId,
                                                ContractId = withDrawDetailParallel.ContractId,
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
                                }
                            }
                        }

                        #endregion
                    }
                    #endregion

                    #region insert BaWithDrawDetailFixedAssets

                    response.Message =
                        BAWithDrawDetailFixedAssetDao.DeleteBAWithDrawDetailFixedAssetEntityByRefId(
                            bAWithDrawEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    if (bAWithDrawEntity.BAWithDrawDetailFixedAssets != null)
                    {
                        DeleteFixAssetLedger(bAWithDrawEntity.RefId, bAWithDrawEntity.RefType);

                        foreach (var bAWithDrawDetailFixedAsset in bAWithDrawEntity.BAWithDrawDetailFixedAssets)
                        {
                            bAWithDrawDetailFixedAsset.RefDetailId = Guid.NewGuid().ToString();
                            bAWithDrawDetailFixedAsset.RefId = bAWithDrawEntity.RefId;
                            response.Message =
                                BAWithDrawDetailFixedAssetDao.InsertBAWithDrawDetailFixedAssetEntity(
                                    bAWithDrawDetailFixedAsset);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bAWithDrawEntity.RefType,
                                RefId = bAWithDrawEntity.RefId,
                                RefDetailId = bAWithDrawDetailFixedAsset.RefDetailId,
                                OrgRefDate = bAWithDrawDetailFixedAsset.OrgRefDate,
                                OrgRefNo = bAWithDrawDetailFixedAsset.OrgRefNo,
                                RefDate = bAWithDrawEntity.RefDate,
                                PostedDate = bAWithDrawEntity.PostedDate,
                                RefNo = bAWithDrawEntity.RefNo,
                                AccountingObjectId = bAWithDrawDetailFixedAsset.AccountingObjectId,
                                ActivityId = bAWithDrawDetailFixedAsset.ActivityId,
                                Amount = bAWithDrawDetailFixedAsset.Amount,
                                AmountOC = bAWithDrawDetailFixedAsset.Amount,
                                Approved = null,
                                BankId = bAWithDrawDetailFixedAsset.BankId,
                                BudgetChapterCode = bAWithDrawDetailFixedAsset.BudgetChapterCode,
                                BudgetDetailItemCode = bAWithDrawDetailFixedAsset.BudgetDetailItemCode,
                                BudgetItemCode = bAWithDrawDetailFixedAsset.BudgetItemCode,
                                BudgetKindItemCode = bAWithDrawDetailFixedAsset.BudgetKindItemCode,
                                BudgetSourceId = bAWithDrawDetailFixedAsset.BudgetSourceId,
                                BudgetSubItemCode = bAWithDrawDetailFixedAsset.BudgetSubItemCode,
                                BudgetSubKindItemCode = bAWithDrawDetailFixedAsset.BudgetSubKindItemCode,
                                CashWithDrawTypeId = bAWithDrawDetailFixedAsset.CashWithdrawTypeId,
                                CreditAccount = bAWithDrawDetailFixedAsset.CreditAccount,
                                DebitAccount = bAWithDrawDetailFixedAsset.DebitAccount,
                                Description = bAWithDrawDetailFixedAsset.Description,
                                FundStructureId = bAWithDrawDetailFixedAsset.FundStructureId,
                                TaxAmount = bAWithDrawEntity.TotalTaxAmount,
                                ProjectActivityId = bAWithDrawDetailFixedAsset.ProjectActivityId,
                                MethodDistributeId = bAWithDrawDetailFixedAsset.MethodDistributeId,
                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                ProjectId = bAWithDrawDetailFixedAsset.ProjectId,
                                ToBankId = bAWithDrawEntity.BankId,
                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                BudgetExpenseId = bAWithDrawDetailFixedAsset.BudgetExpenseId,
                            };
                            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            #endregion

                            #region insert bang GeneralLedger

                            if (bAWithDrawDetailFixedAsset.DebitAccount != null && bAWithDrawDetailFixedAsset.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    ProjectId = bAWithDrawDetailFixedAsset.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailFixedAsset.BudgetSourceId,
                                    Description = bAWithDrawDetailFixedAsset.Description,
                                    RefDetailId = bAWithDrawDetailFixedAsset.RefDetailId,
                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                    BudgetSubKindItemCode = bAWithDrawDetailFixedAsset.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailFixedAsset.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    BudgetItemCode = bAWithDrawDetailFixedAsset.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailFixedAsset.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailFixedAsset.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailFixedAsset.BudgetDetailItemCode,
                                    AccountNumber = bAWithDrawDetailFixedAsset.DebitAccount,
                                    CorrespondingAccountNumber = bAWithDrawDetailFixedAsset.CreditAccount,
                                    DebitAmount =
                                        bAWithDrawDetailFixedAsset.DebitAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    DebitAmountOC =
                                        bAWithDrawDetailFixedAsset.DebitAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = bAWithDrawDetailFixedAsset.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    OrgRefNo = bAWithDrawDetailFixedAsset.OrgRefNo,
                                    OrgRefDate = bAWithDrawDetailFixedAsset.OrgRefDate,
                                    BankId = bAWithDrawDetailFixedAsset.BankId,
                                    BudgetExpenseId = bAWithDrawDetailFixedAsset.BudgetExpenseId,
                                    BudgetChapterCode = bAWithDrawDetailFixedAsset.BudgetChapterCode,
                                    AccountingObjectId = bAWithDrawDetailFixedAsset.AccountingObjectId
                                };

                                // Thêm 2 dòng vào bảng GeneralLedger
                                // dòng 1 là Debit amount
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                // dòng 2 credit amount
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = bAWithDrawDetailFixedAsset.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = bAWithDrawDetailFixedAsset.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = bAWithDrawDetailFixedAsset.Amount;
                                generalLedgerEntity.CreditAmountOC = bAWithDrawDetailFixedAsset.Amount;
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
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    AccountingObjectId = bAWithDrawDetailFixedAsset.AccountingObjectId,
                                    BankId = bAWithDrawDetailFixedAsset.BankId,
                                    BudgetChapterCode = bAWithDrawDetailFixedAsset.BudgetChapterCode,
                                    ProjectId = bAWithDrawDetailFixedAsset.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailFixedAsset.BudgetSourceId,
                                    Description = bAWithDrawDetailFixedAsset.Description,
                                    RefDetailId = bAWithDrawDetailFixedAsset.RefDetailId,
                                    ExchangeRate = 1,
                                    ActivityId = bAWithDrawDetailFixedAsset.ActivityId,
                                    BudgetSubKindItemCode = bAWithDrawDetailFixedAsset.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailFixedAsset.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    MethodDistributeId = bAWithDrawDetailFixedAsset.MethodDistributeId,
                                    //OrgRefNo = string.Empty,
                                    //OrgRefDate = null,
                                    OrgRefNo = bAWithDrawDetailFixedAsset.OrgRefNo,
                                    OrgRefDate = bAWithDrawDetailFixedAsset.OrgRefDate,
                                    BudgetItemCode = bAWithDrawDetailFixedAsset.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailFixedAsset.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailFixedAsset.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailFixedAsset.BudgetDetailItemCode,
                                    CashWithDrawTypeId = bAWithDrawDetailFixedAsset.CashWithdrawTypeId,
                                    AccountNumber = bAWithDrawDetailFixedAsset.DebitAccount ?? bAWithDrawDetailFixedAsset.CreditAccount,
                                    DebitAmount = bAWithDrawDetailFixedAsset.DebitAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    DebitAmountOC = bAWithDrawDetailFixedAsset.DebitAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    CreditAmount = bAWithDrawDetailFixedAsset.CreditAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    CreditAmountOC = bAWithDrawDetailFixedAsset.CreditAccount == null ? 0 : bAWithDrawDetailFixedAsset.Amount,
                                    FundStructureId = bAWithDrawDetailFixedAsset.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    BudgetExpenseId = bAWithDrawDetailFixedAsset.BudgetExpenseId
                                };
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }

                            #endregion

                            #region FixedAsset Ledger

                            if (bAWithDrawDetailFixedAsset.DebitAccount.StartsWith("21"))
                            {
                                AutoMapper(InsertFixAssetLedger(bAWithDrawDetailFixedAsset, bAWithDrawEntity),
                                    response);
                                if (!string.IsNullOrEmpty(response.Message))
                                    goto Error;
                            }

                            #endregion
                        }
                        #region Sinh dinh khoan dong thoi

                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            
                        }
                        else
                        {
                            //truong hop sinh tu dong se sinh theo chung tu chi tiet
                            if (bAWithDrawEntity.BAWithDrawDetailFixedAssets != null)
                            {
                                foreach (var depositDetail in bAWithDrawEntity.BAWithDrawDetailFixedAssets)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                            depositDetail.DebitAccount, depositDetail.CreditAccount,
                                            depositDetail.BudgetSourceId,
                                            depositDetail.BudgetChapterCode, depositDetail.BudgetKindItemCode,
                                            depositDetail.BudgetSubKindItemCode, depositDetail.BudgetItemCode,
                                            depositDetail.BudgetSubItemCode,
                                            depositDetail.MethodDistributeId, depositDetail.CashWithdrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region BADepositDetails

                                            var withDrawDetailParallel = new BAWithDrawDetailParallelEntity()
                                            {
                                                RefId = bAWithDrawEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = depositDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = depositDetail.Amount * bAWithDrawEntity.ExchangeRate,
                                                AmountOC = depositDetail.Amount,
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
                                                    depositDetail.CashWithdrawTypeId,
                                                AccountingObjectId = depositDetail.AccountingObjectId,
                                                ActivityId = depositDetail.ActivityId,
                                                ProjectId = depositDetail.ProjectId,
                                                ListItemId = depositDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = depositDetail.SortOrder,
                                                OrgRefNo = depositDetail.OrgRefNo,
                                                OrgRefDate = depositDetail.OrgRefDate,
                                                FundStructureId = depositDetail.FundStructureId,
                                                BudgetExpenseId = depositDetail.BudgetExpenseId,
                                                BankId = depositDetail.BankId
                                                //withDrawDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                                //withDrawDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                            };
                                            if (!withDrawDetailParallel.Validate())
                                            {
                                                foreach (var error in withDrawDetailParallel.ValidationErrors)
                                                    response.Message += error + Environment.NewLine;
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                            response.Message =
                                                BAWithDrawDetailParallelDao.InsertBAWithDrawDetailParallel(
                                                    withDrawDetailParallel);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (withDrawDetailParallel.DebitAccount != null && withDrawDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    withDrawDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = withDrawDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = withDrawDetailParallel.Amount,
                                                    DebitAmountOC = withDrawDetailParallel.Amount,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(response.Message))
                                                {
                                                    response.Acknowledge = AcknowledgeType.Failure;
                                                    return response;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = withDrawDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = withDrawDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = withDrawDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = withDrawDetailParallel.AmountOC;
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
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    withDrawDetailParallel.DebitAccount ??
                                                    withDrawDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    withDrawDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    withDrawDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    CreditAmount =
                                                    withDrawDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    withDrawDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
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
                                                RefType = bAWithDrawEntity.RefType,
                                                RefId = bAWithDrawEntity.RefId,
                                                RefDetailId = withDrawDetailParallel.RefDetailId,
                                                OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                RefDate = bAWithDrawEntity.RefDate,
                                                PostedDate = bAWithDrawEntity.PostedDate,
                                                RefNo = bAWithDrawEntity.RefNo,
                                                AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                ActivityId = withDrawDetailParallel.ActivityId,
                                                Amount = withDrawDetailParallel.Amount,
                                                AmountOC = withDrawDetailParallel.AmountOC,
                                                //Approved = receiptDetail.Approved,
                                                BankId = withDrawDetailParallel.BankId,
                                                BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = withDrawDetailParallel.CreditAccount,
                                                DebitAccount = withDrawDetailParallel.DebitAccount,
                                                Description = withDrawDetailParallel.Description,
                                                FundStructureId = withDrawDetailParallel.FundStructureId,
                                                //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                                MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                                ProjectId = withDrawDetailParallel.ProjectId,
                                                ToBankId = withDrawDetailParallel.BankId,
                                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId,
                                                ContractId = withDrawDetailParallel.ContractId,
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
                    }

                    #endregion

                    #region insert BaWithDrawDetailPurchases

                    response.Message =
                        BAWithDrawDetailPurchaseDao.DeleteBAWithDrawDetailPurchaseEntityByRefId(bAWithDrawEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    //delete DeleteInventoryLedger
                    response.Message = InventoryLedgerDao.DeleteInventoryLedger(bAWithDrawEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    if (bAWithDrawEntity.BAWithDrawDetailPurchases != null)
                    {

                        // Xóa bảng FixAssetLedger
                        //response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(bAWithDrawEntity.RefId, bAWithDrawEntity.RefType);
                        //if (!string.IsNullOrEmpty(response.Message))
                        //{
                        //    response.Acknowledge = AcknowledgeType.Failure;
                        //    scope.Dispose();
                        //    return response;
                        //}
                        foreach (var bAWithDrawDetailSale in bAWithDrawEntity.BAWithDrawDetailPurchases)
                        {
                            bAWithDrawDetailSale.RefDetailId = Guid.NewGuid().ToString();
                            bAWithDrawDetailSale.RefId = bAWithDrawEntity.RefId;
                            response.Message =
                                BAWithDrawDetailPurchaseDao.InsertBAWithDrawDetailPurchaseEntity(bAWithDrawDetailSale);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #region Insert InventoryLedger

                            var inventoryLedgerEntity = new InventoryLedgerEntity
                            {
                                InventoryLedgerId = Guid.NewGuid().ToString(),
                                RefId = bAWithDrawEntity.RefId,
                                RefType = bAWithDrawEntity.RefType,
                                RefNo = bAWithDrawEntity.RefNo,
                                RefDate = bAWithDrawEntity.RefDate,
                                PostedDate = bAWithDrawEntity.PostedDate,
                                StockId = bAWithDrawDetailSale.StockId,
                                InventoryItemId = bAWithDrawDetailSale.InventoryItemId,
                                BudgetSourceId = bAWithDrawDetailSale.BudgetSourceId,
                                Description = bAWithDrawDetailSale.Description,
                                RefDetailId = bAWithDrawDetailSale.RefDetailId,
                                Unit = bAWithDrawDetailSale.Unit,
                                UnitPrice = bAWithDrawDetailSale.UnitPrice,
                                InwardQuantity = (bAWithDrawEntity.RefType == 201 || bAWithDrawEntity.RefType == 158) ? bAWithDrawDetailSale.Quantity : 0,
                                OutwardQuantity = bAWithDrawEntity.RefType == 202 ? bAWithDrawDetailSale.Quantity : 0,
                                OutwardAmount = bAWithDrawEntity.RefType == 202 ? bAWithDrawDetailSale.Amount : 0,
                                InwardAmount = (bAWithDrawEntity.RefType == 201 || bAWithDrawEntity.RefType == 158) ? bAWithDrawDetailSale.Amount : 0,
                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                ExpiryDate = bAWithDrawDetailSale.ExpiryDate,
                                LotNo = bAWithDrawDetailSale.LotNo,
                                RefOrder = bAWithDrawEntity.RefOrder,
                                SortOrder = bAWithDrawDetailSale.SortOrder,
                                AccountNumber = bAWithDrawDetailSale.DebitAccount,
                                CorrespondingAccountNumber = bAWithDrawDetailSale.CreditAccount,
                                InwardAmountBalance = 0,
                                InwardAmountBalanceAfter = 0,
                                InwardQuantityBalance = 0,
                                UnitPriceBalance = 0
                            };
                            response.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion

                            #region insert bang GeneralLedger

                            if (bAWithDrawDetailSale.DebitAccount != null && bAWithDrawDetailSale.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    ProjectId = bAWithDrawDetailSale.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailSale.BudgetSourceId,
                                    Description = bAWithDrawDetailSale.Description,
                                    RefDetailId = bAWithDrawDetailSale.RefDetailId,
                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                    BudgetSubKindItemCode = bAWithDrawDetailSale.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailSale.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    BudgetItemCode = bAWithDrawDetailSale.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailSale.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailSale.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailSale.BudgetDetailItemCode,
                                    AccountNumber = bAWithDrawDetailSale.DebitAccount,
                                    CorrespondingAccountNumber = bAWithDrawDetailSale.CreditAccount,
                                    DebitAmount =
                                        bAWithDrawDetailSale.DebitAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    DebitAmountOC =
                                        bAWithDrawDetailSale.DebitAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = bAWithDrawDetailSale.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    OrgRefNo = bAWithDrawDetailSale.OrgRefNo,
                                    OrgRefDate = bAWithDrawDetailSale.OrgRefDate,
                                    BankId = bAWithDrawDetailSale.BankId,
                                    BudgetExpenseId = bAWithDrawDetailSale.BudgetExpenseId,
                                    BudgetChapterCode = bAWithDrawDetailSale.BudgetChapterCode,
                                    AccountingObjectId = bAWithDrawDetailSale.AccountingObjectId
                                };

                                // Thêm 2 dòng vào bảng GeneralLedger
                                // dòng 1 là Debit amount
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                //insert lan 2
                                // dòng 2 credit amount
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = bAWithDrawDetailSale.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = bAWithDrawDetailSale.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = bAWithDrawDetailSale.Amount;
                                generalLedgerEntity.CreditAmountOC = bAWithDrawDetailSale.Amount;
                                response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(response.Message))
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                // Chỗ này insert thừa rồi a thắng ơi
                                //generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                //generalLedgerEntity.AccountNumber = bAWithDrawDetailSale.CreditAccount;
                                //generalLedgerEntity.CorrespondingAccountNumber = bAWithDrawDetailSale.DebitAccount;
                                //generalLedgerEntity.DebitAmount = 0;
                                //generalLedgerEntity.DebitAmountOC = 0;
                                //generalLedgerEntity.CreditAmount = bAWithDrawDetailSale.Amount;
                                //generalLedgerEntity.CreditAmountOC = bAWithDrawDetailSale.AmountOC;
                                //response.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                //if (!string.IsNullOrEmpty(response.Message))
                                //{
                                //    response.Acknowledge = AcknowledgeType.Failure;
                                //    return response;
                                //}
                            }
                            else
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bAWithDrawEntity.RefType,
                                    RefNo = bAWithDrawEntity.RefNo,
                                    AccountingObjectId = bAWithDrawDetailSale.AccountingObjectId,
                                    BankId = bAWithDrawDetailSale.BankId,
                                    BudgetChapterCode = bAWithDrawDetailSale.BudgetChapterCode,
                                    ProjectId = bAWithDrawDetailSale.ProjectId,
                                    BudgetSourceId = bAWithDrawDetailSale.BudgetSourceId,
                                    Description = bAWithDrawDetailSale.Description,
                                    RefDetailId = bAWithDrawDetailSale.RefDetailId,
                                    ExchangeRate = 1,
                                    ActivityId = bAWithDrawDetailSale.ActivityId,
                                    BudgetSubKindItemCode = bAWithDrawDetailSale.BudgetSubKindItemCode,
                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                    BudgetKindItemCode = bAWithDrawDetailSale.BudgetKindItemCode,
                                    RefId = bAWithDrawEntity.RefId,
                                    PostedDate = bAWithDrawEntity.PostedDate,
                                    MethodDistributeId = bAWithDrawDetailSale.MethodDistributeId,
                                    //OrgRefNo = string.Empty,
                                    //OrgRefDate = null,
                                    OrgRefNo = bAWithDrawDetailSale.OrgRefNo,
                                    OrgRefDate = bAWithDrawDetailSale.OrgRefDate,
                                    BudgetItemCode = bAWithDrawDetailSale.BudgetItemCode,
                                    ListItemId = bAWithDrawDetailSale.ListItemId,
                                    BudgetSubItemCode = bAWithDrawDetailSale.BudgetSubItemCode,
                                    BudgetDetailItemCode = bAWithDrawDetailSale.BudgetDetailItemCode,
                                    CashWithDrawTypeId = bAWithDrawDetailSale.CashWithdrawTypeId,
                                    AccountNumber = bAWithDrawDetailSale.DebitAccount ?? bAWithDrawDetailSale.CreditAccount,
                                    DebitAmount = bAWithDrawDetailSale.DebitAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    DebitAmountOC = bAWithDrawDetailSale.DebitAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    CreditAmount = bAWithDrawDetailSale.CreditAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    CreditAmountOC = bAWithDrawDetailSale.CreditAccount == null ? 0 : bAWithDrawDetailSale.Amount,
                                    FundStructureId = bAWithDrawDetailSale.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                    RefDate = bAWithDrawEntity.RefDate,
                                    BudgetExpenseId = bAWithDrawDetailSale.BudgetExpenseId
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
                                RefType = bAWithDrawEntity.RefType,
                                RefId = bAWithDrawEntity.RefId,
                                RefDetailId = bAWithDrawDetailSale.RefDetailId,
                                OrgRefDate = bAWithDrawDetailSale.OrgRefDate,
                                OrgRefNo = bAWithDrawDetailSale.OrgRefNo,
                                RefDate = bAWithDrawEntity.RefDate,
                                PostedDate = bAWithDrawEntity.PostedDate,
                                RefNo = bAWithDrawEntity.RefNo,
                                AccountingObjectId = bAWithDrawDetailSale.AccountingObjectId,
                                ActivityId = bAWithDrawDetailSale.ActivityId,
                                Amount = bAWithDrawDetailSale.Amount,
                                //AmountOC = bAWithDrawDetailSale.AmountOC,
                                Approved = null,
                                BankId = bAWithDrawDetailSale.BankId,
                                BudgetChapterCode = bAWithDrawDetailSale.BudgetChapterCode,
                                BudgetDetailItemCode = bAWithDrawDetailSale.BudgetDetailItemCode,
                                BudgetItemCode = bAWithDrawDetailSale.BudgetItemCode,
                                BudgetKindItemCode = bAWithDrawDetailSale.BudgetKindItemCode,
                                BudgetSourceId = bAWithDrawDetailSale.BudgetSourceId,
                                BudgetSubItemCode = bAWithDrawDetailSale.BudgetSubItemCode,
                                BudgetSubKindItemCode = bAWithDrawDetailSale.BudgetSubKindItemCode,
                                // CashWithDrawTypeId = bAWithDrawDetailSale.CashWithDrawTypeId,
                                CreditAccount = bAWithDrawDetailSale.CreditAccount,
                                DebitAccount = bAWithDrawDetailSale.DebitAccount,
                                Description = bAWithDrawDetailSale.Description,
                                FundStructureId = bAWithDrawDetailSale.FundStructureId,
                                TaxAmount = bAWithDrawEntity.TotalTaxAmount,
                                ProjectActivityId = bAWithDrawDetailSale.ProjectActivityId,
                                MethodDistributeId = bAWithDrawDetailSale.MethodDistributeId,
                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                ProjectId = bAWithDrawDetailSale.ProjectId,
                                ToBankId = bAWithDrawEntity.BankId,
                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                            };
                            response.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            #endregion                        
                        }
                        #region Sinh dinh khoan dong thoi

                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {                            
                        }
                        else
                        {
                            //truong hop sinh tu dong se sinh theo chung tu chi tiet
                            if (bAWithDrawEntity.BAWithDrawDetailPurchases != null)
                            {
                                foreach (var depositDetail in bAWithDrawEntity.BAWithDrawDetailPurchases)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                            depositDetail.DebitAccount, depositDetail.CreditAccount,
                                            depositDetail.BudgetSourceId,
                                            depositDetail.BudgetChapterCode, depositDetail.BudgetKindItemCode,
                                            depositDetail.BudgetSubKindItemCode, depositDetail.BudgetItemCode,
                                            depositDetail.BudgetSubItemCode,
                                            depositDetail.MethodDistributeId, depositDetail.CashWithdrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region BADepositDetails

                                            var withDrawDetailParallel = new BAWithDrawDetailParallelEntity()
                                            {
                                                RefId = bAWithDrawEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = depositDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = depositDetail.Amount * bAWithDrawEntity.ExchangeRate,
                                                AmountOC = depositDetail.Amount,
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
                                                    depositDetail.CashWithdrawTypeId,
                                                AccountingObjectId = depositDetail.AccountingObjectId,
                                                ActivityId = depositDetail.ActivityId,
                                                ProjectId = depositDetail.ProjectId,
                                                ListItemId = depositDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = depositDetail.SortOrder,
                                                OrgRefNo = depositDetail.OrgRefNo,
                                                OrgRefDate = depositDetail.OrgRefDate,
                                                FundStructureId = depositDetail.FundStructureId,
                                                BudgetExpenseId = depositDetail.BudgetExpenseId,
                                                BankId = depositDetail.BankId
                                            };
                                            if (!withDrawDetailParallel.Validate())
                                            {
                                                foreach (var error in withDrawDetailParallel.ValidationErrors)
                                                    response.Message += error + Environment.NewLine;
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }
                                            response.Message =
                                                BAWithDrawDetailParallelDao.InsertBAWithDrawDetailParallel(
                                                    withDrawDetailParallel);
                                            if (!string.IsNullOrEmpty(response.Message))
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (withDrawDetailParallel.DebitAccount != null && withDrawDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    withDrawDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = withDrawDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = withDrawDetailParallel.Amount,
                                                    DebitAmountOC = withDrawDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(response.Message))
                                                {
                                                    response.Acknowledge = AcknowledgeType.Failure;
                                                    return response;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = withDrawDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = withDrawDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = withDrawDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = withDrawDetailParallel.AmountOC;
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
                                                    RefType = bAWithDrawEntity.RefType,
                                                    RefNo = bAWithDrawEntity.RefNo,
                                                    AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                    BankId = withDrawDetailParallel.BankId,
                                                    BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                    ProjectId = withDrawDetailParallel.ProjectId,
                                                    BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                    Description = withDrawDetailParallel.Description,
                                                    RefDetailId = withDrawDetailParallel.RefDetailId,
                                                    ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                    ActivityId = withDrawDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                    BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                    RefId = bAWithDrawEntity.RefId,
                                                    PostedDate = bAWithDrawEntity.PostedDate,
                                                    MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                    OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                    OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                    BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                    ListItemId = withDrawDetailParallel.ListItemId,
                                                    BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    withDrawDetailParallel.DebitAccount ??
                                                    withDrawDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    withDrawDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    withDrawDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    withDrawDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    withDrawDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : withDrawDetailParallel.AmountOC,
                                                    FundStructureId = withDrawDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bAWithDrawEntity.JournalMemo,
                                                    RefDate = bAWithDrawEntity.RefDate,
                                                    BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId
                                                };
                                                response.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
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
                                                RefType = bAWithDrawEntity.RefType,
                                                RefId = bAWithDrawEntity.RefId,
                                                RefDetailId = withDrawDetailParallel.RefDetailId,
                                                OrgRefDate = withDrawDetailParallel.OrgRefDate,
                                                OrgRefNo = withDrawDetailParallel.OrgRefNo,
                                                RefDate = bAWithDrawEntity.RefDate,
                                                PostedDate = bAWithDrawEntity.PostedDate,
                                                RefNo = bAWithDrawEntity.RefNo,
                                                AccountingObjectId = withDrawDetailParallel.AccountingObjectId,
                                                ActivityId = withDrawDetailParallel.ActivityId,
                                                Amount = withDrawDetailParallel.Amount,
                                                AmountOC = withDrawDetailParallel.AmountOC,
                                                //Approved = receiptDetail.Approved,
                                                BankId = withDrawDetailParallel.BankId,
                                                BudgetChapterCode = withDrawDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = withDrawDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = withDrawDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = withDrawDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = withDrawDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = withDrawDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = withDrawDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = withDrawDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = withDrawDetailParallel.CreditAccount,
                                                DebitAccount = withDrawDetailParallel.DebitAccount,
                                                Description = withDrawDetailParallel.Description,
                                                FundStructureId = withDrawDetailParallel.FundStructureId,
                                                //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                                MethodDistributeId = withDrawDetailParallel.MethodDistributeId,
                                                JournalMemo = bAWithDrawEntity.JournalMemo,
                                                ProjectId = withDrawDetailParallel.ProjectId,
                                                ToBankId = withDrawDetailParallel.BankId,
                                                ExchangeRate = bAWithDrawEntity.ExchangeRate,
                                                CurrencyCode = bAWithDrawEntity.CurrencyCode,
                                                BudgetExpenseId = withDrawDetailParallel.BudgetExpenseId,
                                                ContractId = withDrawDetailParallel.ContractId,
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
                    }

                    #endregion

                    #region insert BaWithdrawDetailSalarys

                    response.Message =
                        BAWithdrawDetailSalaryDao.DeleteBAWithdrawDetailSalaryEntityByRefId(bAWithDrawEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    if (bAWithDrawEntity.BAWithdrawDetailSalarys != null)
                        foreach (var bAWithDrawDetailTax in bAWithDrawEntity.BAWithdrawDetailSalarys)
                        {
                            bAWithDrawDetailTax.RefDetailId = Guid.NewGuid().ToString();
                            bAWithDrawDetailTax.RefId = bAWithDrawEntity.RefId;
                            response.Message =
                                BAWithdrawDetailSalaryDao.InsertBAWithdrawDetailSalaryEntity(bAWithDrawDetailTax);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    #region insert BaWithdrawDetailTaxs

                    response.Message =
                        BAWithdrawDetailTaxDao.DeleteBAWithdrawDetailTaxEntityByRefId(bAWithDrawEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    if (bAWithDrawEntity.BAWithdrawDetailTaxs != null)
                        foreach (var bAWithDrawDetailTax in bAWithDrawEntity.BAWithdrawDetailTaxs)
                        {
                            bAWithDrawDetailTax.RefDetailId = Guid.NewGuid().ToString();
                            bAWithDrawDetailTax.RefId = bAWithDrawEntity.RefId;
                            response.Message =
                                BAWithdrawDetailTaxDao.InsertBAWithdrawDetailTaxEntity(bAWithDrawDetailTax);
                            if (!string.IsNullOrEmpty(response.Message))
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                    #endregion

                    Error:
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.RefId = bAWithDrawEntity.RefId;
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
        /// <param name="bAWithDrawId">The b a deposit identifier.</param>
        /// <returns></returns>
        public BAWithDrawResponse DeleteBAWithDraw(string bAWithDrawId)
        {
            var response = new BAWithDrawResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var bAWithDrawEntity = BAWithDrawDao.GetBAWithDraw(bAWithDrawId);
                if (bAWithDrawEntity == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Dữ liệu cần xóa không tồn tại!";
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = BAWithDrawDao.DeleteBAWithDraw(bAWithDrawEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // delete bang GeneralLedger
                    response.Message = GeneralLedgerDao.DeleteGeneralLedger(bAWithDrawEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    // Update account balance
                    // Cập nhật giá trị vào account balance trước khi xóa
                    response.Message = UpdateAccountBalance(bAWithDrawEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    //delete DeleteInventoryLedger
                    response.Message = InventoryLedgerDao.DeleteInventoryLedger(bAWithDrawEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    //delete FixedAssetLedger
                    response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(bAWithDrawEntity.RefId, bAWithDrawEntity.RefType);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }


                    //DeleteOriginalGeneralLedger
                    response.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bAWithDrawEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    // delete bang BAWithDrawDetailParallel
                    response.Message = BAWithDrawDetailParallelDao.DeleteBAWithDrawDetailParallelById(bAWithDrawEntity.RefId);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    if (bAWithDrawEntity.RefType == (int)BuCA.Enum.RefType.BAWithDrawFixedAsset)
                    {
                        // Xóa bảng FixedAssetLedger
                        response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(bAWithDrawEntity.RefId, bAWithDrawEntity.RefType);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                    }

                    scope.Complete();
                }
                response.RefId = bAWithDrawEntity.RefId;
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
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="baWithDrawEntity">The ba with draw entity.</param>
        /// <param name="baWithDrawDetailEntity">The ba deposit detail entity.</param>
        /// <returns>AccountBalanceEntity.</returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(BAWithDrawEntity baWithDrawEntity, BAWithDrawDetailEntity baWithDrawDetailEntity)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = baWithDrawDetailEntity.DebitAccount,
                CurrencyCode = baWithDrawEntity.CurrencyCode,
                ExchangeRate = baWithDrawEntity.ExchangeRate,
                BalanceDate = baWithDrawEntity.PostedDate,
                MovementDebitAmountOC = baWithDrawDetailEntity.AmountOC,
                MovementDebitAmount = baWithDrawDetailEntity.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = baWithDrawDetailEntity.BudgetSourceId,
                BudgetChapterCode = baWithDrawDetailEntity.BudgetChapterCode,
                BudgetKindItemCode = baWithDrawDetailEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = baWithDrawDetailEntity.BudgetSubKindItemCode,
                BudgetItemCode = baWithDrawDetailEntity.BudgetItemCode,
                BudgetSubItemCode = baWithDrawDetailEntity.BudgetSubItemCode,
                MethodDistributeId = baWithDrawDetailEntity.MethodDistributeId,
                AccountingObjectId = baWithDrawEntity.AccountingObjectId,
                ActivityId = baWithDrawDetailEntity.ActivityId,
                ProjectId = baWithDrawDetailEntity.ProjectId,
                BankAccount = baWithDrawEntity.BankId,
                FundStructureId = baWithDrawDetailEntity.FundStructureId,
                ProjectActivityId = baWithDrawDetailEntity.ProjectActivityId,
                BudgetDetailItemCode = baWithDrawDetailEntity.BudgetDetailItemCode
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="baWithDrawEntity">The ba deposit entity.</param>
        /// <param name="baWithDrawDetailEntity">The payment detail.</param>
        /// <returns>AccountBalanceEntity.</returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(BAWithDrawEntity baWithDrawEntity, BAWithDrawDetailEntity baWithDrawDetailEntity)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = baWithDrawDetailEntity.CreditAccount,
                CurrencyCode = baWithDrawEntity.CurrencyCode,
                ExchangeRate = baWithDrawEntity.ExchangeRate,
                BalanceDate = baWithDrawEntity.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = baWithDrawDetailEntity.AmountOC,
                MovementCreditAmount = baWithDrawDetailEntity.Amount,
                BudgetSourceId = baWithDrawDetailEntity.BudgetSourceId,
                BudgetChapterCode = baWithDrawDetailEntity.BudgetChapterCode,
                BudgetKindItemCode = baWithDrawDetailEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = baWithDrawDetailEntity.BudgetSubKindItemCode,
                BudgetItemCode = baWithDrawDetailEntity.BudgetItemCode,
                BudgetSubItemCode = baWithDrawDetailEntity.BudgetSubItemCode,
                MethodDistributeId = baWithDrawDetailEntity.MethodDistributeId,
                AccountingObjectId = baWithDrawEntity.AccountingObjectId,
                ActivityId = baWithDrawDetailEntity.ActivityId,
                ProjectId = baWithDrawDetailEntity.ProjectId,
                BankAccount = baWithDrawEntity.BankId,
                FundStructureId = baWithDrawDetailEntity.FundStructureId,
                ProjectActivityId = baWithDrawDetailEntity.ProjectActivityId,
                BudgetDetailItemCode = baWithDrawDetailEntity.BudgetDetailItemCode
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
        /// <param name="baWithDrawEntity">The ca payment entity.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(BAWithDrawEntity baWithDrawEntity)
        {
            var baDepositDetails = BAWithDrawDetailDao.GetBAWithDrawDetailEntitysByRefId(baWithDrawEntity.RefId);
            foreach (var baDepositDetailEntity in baDepositDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(baWithDrawEntity, baDepositDetailEntity);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(baWithDrawEntity, baDepositDetailEntity);
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
        /// <param name="baWithDrawEntity">The ba deposit entity.</param>
        /// <param name="baWithDrawDetailEntity">The payment detail.</param>
        public void InsertAccountBalance(BAWithDrawEntity baWithDrawEntity, BAWithDrawDetailEntity baWithDrawDetailEntity)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(baWithDrawEntity, baWithDrawDetailEntity);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(baWithDrawEntity, baWithDrawDetailEntity);
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