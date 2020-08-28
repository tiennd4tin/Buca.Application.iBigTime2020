/***********************************************************************
 * <copyright file="CAReceiptFacade.cs" company="BUCA JSC">
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
 * 25/9/2014    LinhMC  Them dieu kien kiem tra trung so chung tu: neu la chuyen doi du lieu thi khong check
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Cash;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Cash
{
    /// <summary>
    /// CAReceiptFacade class
    /// </summary>
    public class CAReceiptFacade
    {
        #region Data Transfer Object

        private static readonly ICAReceiptDao CAReceiptDao = DataAccess.DataAccess.CAReceiptDao;
        private static readonly ICAReceiptDetailDao CAReceiptDetailDao = DataAccess.DataAccess.CAReceiptDetailDao;
        private static readonly ICAReceiptDetailTaxDao CAReceiptDetailTaxDao = DataAccess.DataAccess.CAReceiptDetailTaxDao;
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly ICAReceiptDetailParallelDao CAReceiptDetailParallelDao = DataAccess.DataAccess.CAReceiptDetailParallelDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;

        //private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;

        //private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;

        //private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;

        #endregion

        /// <summary>
        /// Gets the ca receipts.
        /// </summary>
        /// <returns>List&lt;CAReceiptEntity&gt;.</returns>
        public List<CAReceiptEntity> GetCAReceipts()
        {
            return CAReceiptDao.GetCAReceipts();
        }

        /// <summary>
        /// Gets the ca receipt by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>CAReceiptEntity.</returns>
        public CAReceiptEntity GetCAReceiptByRefNo(string refNo)
        {
            return CAReceiptDao.GetCAReceiptByRefNo(refNo);
        }
        public List<CAReceiptEntity> GetCAReceiptByRefTypeID(int refTypeId)
        {
            return CAReceiptDao.GetCAReceiptByRefTypeID(refTypeId);
        }

        public CAReceiptEntity GetCAReceiptsByBUPlanWithdrawRefID(string BUPlanWithdrawRefID)
        {
            return CAReceiptDao.GetCAReceiptByBuPlanWithDrawRefID(BUPlanWithdrawRefID);
        }

        /// <summary>
        /// Gets the ca receipt by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedCAReceiptDetail">if set to <c>true</c> [is included ca receipt detail].</param>
        /// <returns>CAReceiptEntity.</returns>
        public CAReceiptEntity GetCAReceiptByRefId(string refId, bool isIncludedCAReceiptDetail)
        {
            var receipt = CAReceiptDao.GetCAReceipt(refId);
            if (isIncludedCAReceiptDetail && receipt != null)
            {
                receipt.CAReceiptDetails = CAReceiptDetailDao.GetCAReceiptDetailsByRefId(receipt.RefId);
            }
            return receipt;
        }

        /// <summary>
        /// Gets the ca receipt by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedCAReceiptDetail">if set to <c>true</c> [is included ca receipt detail].</param>
        /// <param name="isIncludedCAReceiptDetailTax">if set to <c>true</c> [is included ca receipt detail tax].</param>
        /// <returns>CAReceiptEntity.</returns>
        public CAReceiptEntity GetCAReceiptByRefId(string refId, bool isIncludedCAReceiptDetail, bool isIncludedCAReceiptDetailTax)
        {
            var receipt = CAReceiptDao.GetCAReceipt(refId);
            if (receipt == null)
                return new CAReceiptEntity();

            if (isIncludedCAReceiptDetail)
            {
                receipt.CAReceiptDetails = CAReceiptDetailDao.GetCAReceiptDetailsByRefId(receipt.RefId);
            }
            if (isIncludedCAReceiptDetailTax)
            {
                receipt.CAReceiptDetailTaxes = CAReceiptDetailTaxDao.GetCAReceiptDetailTaxesByRefId(receipt.RefId);
            }

            //default get detail parallel
            receipt.CAReceiptDetailParallels = CAReceiptDetailParallelDao.GetCAReceiptDetailParallelbyRefId(receipt.RefId);
            return receipt;
        }

        /// <summary>
        /// Inserts the ca receipt.
        /// </summary>
        /// <param name="receiptEntity">The receipt entity.</param>
        /// <param name="isConvertData">if set to <c>true</c> [is convert data].</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>CAReceiptResponse.</returns>
        public CAReceiptResponse InsertCAReceipt(CAReceiptEntity receiptEntity, bool isConvertData, bool isAutoGenerateParallel = false)
        {
            var receiptResponse = new CAReceiptResponse { Acknowledge = AcknowledgeType.Success };
            if (receiptEntity != null && !receiptEntity.Validate())
            {
                foreach (var error in receiptEntity.ValidationErrors)
                    receiptResponse.Message += error + Environment.NewLine;
                receiptResponse.Acknowledge = AcknowledgeType.Failure;
                return receiptResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (receiptEntity != null)
                {
                    var receiptEntityExited = CAReceiptDao.GetCAReceiptByRefNo(receiptEntity.RefNo.Trim(), receiptEntity.PostedDate);
                    if (receiptEntityExited != null && receiptEntityExited.PostedDate.Year == receiptEntity.PostedDate.Year)
                    {
                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                        receiptResponse.Message = @"Số chứng từ '" + receiptEntityExited.RefNo + @"' đã tồn tại!";
                        return receiptResponse;
                    }

                    receiptEntity.RefId = Guid.NewGuid().ToString();
                    receiptResponse.Message = CAReceiptDao.InsertCAReceipt(receiptEntity);

                    if (!string.IsNullOrEmpty(receiptResponse.Message))
                    {
                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                        return receiptResponse;
                    }
                    if (receiptEntity.CAReceiptDetails != null && receiptEntity.CAReceiptDetails.Count > 0)
                    {
                        foreach (var receiptDetail in receiptEntity.CAReceiptDetails)
                        {
                            receiptDetail.RefId = receiptEntity.RefId;
                            receiptDetail.RefDetailId = Guid.NewGuid().ToString();
                            if (!receiptDetail.Validate())
                            {
                                foreach (var error in receiptDetail.ValidationErrors)
                                    receiptResponse.Message += error + Environment.NewLine;
                                receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return receiptResponse;
                            }
                            receiptResponse.Message = CAReceiptDetailDao.InsertCAReceiptDetail(receiptDetail);
                            if (!string.IsNullOrEmpty(receiptResponse.Message))
                            {
                                receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return receiptResponse;
                            }

                            #region Insert General Ledger Entity

                            if (receiptDetail.DebitAccount != null && receiptDetail.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = receiptEntity.RefType,
                                    RefNo = receiptEntity.RefNo,
                                    AccountingObjectId = receiptDetail.AccountingObjectId,
                                    BankId = receiptDetail.BankId,
                                    BudgetChapterCode = receiptDetail.BudgetChapterCode,
                                    ProjectId = receiptDetail.ProjectId,
                                    BudgetSourceId = receiptDetail.BudgetSourceId,
                                    Description = receiptDetail.Description,
                                    RefDetailId = receiptDetail.RefDetailId,
                                    ExchangeRate = receiptEntity.ExchangeRate,
                                    ActivityId = receiptDetail.ActivityId,
                                    BudgetSubKindItemCode = receiptDetail.BudgetSubKindItemCode,
                                    CurrencyCode = receiptEntity.CurrencyCode,
                                    BudgetKindItemCode = receiptDetail.BudgetKindItemCode,
                                    RefId = receiptEntity.RefId,
                                    PostedDate = receiptEntity.PostedDate,
                                    MethodDistributeId = receiptDetail.MethodDistributeId,
                                    OrgRefNo = receiptDetail.OrgRefNo,
                                    OrgRefDate = receiptDetail.OrgRefDate,
                                    BudgetItemCode = receiptDetail.BudgetItemCode,
                                    ListItemId = receiptDetail.ListItemId,
                                    BudgetSubItemCode = receiptDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = receiptDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = receiptDetail.CashWithdrawTypeId,
                                    AccountNumber = receiptDetail.DebitAccount,
                                    CorrespondingAccountNumber = receiptDetail.CreditAccount,
                                    DebitAmount = receiptDetail.Amount,
                                    DebitAmountOC = receiptDetail.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = receiptDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = receiptEntity.JournalMemo,
                                    RefDate = receiptEntity.RefDate,
                                    BudgetExpenseId = receiptDetail.BudgetExpenseId,
                                    ContractId = receiptDetail.ContractId,
                                    CapitalPlanId = receiptDetail.CapitalPlanId
                                };
                                receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(receiptResponse.Message))
                                {
                                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                    return receiptResponse;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = receiptDetail.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = receiptDetail.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = receiptDetail.Amount;
                                generalLedgerEntity.CreditAmountOC = receiptDetail.AmountOC;
                                receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(receiptResponse.Message))
                                {
                                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                    return receiptResponse;
                                }
                            }
                            else //ghi don
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = receiptEntity.RefType,
                                    RefNo = receiptEntity.RefNo,
                                    AccountingObjectId = receiptEntity.AccountingObjectId,
                                    BankId = receiptDetail.BankId,
                                    BudgetChapterCode = receiptDetail.BudgetChapterCode,
                                    ProjectId = receiptDetail.ProjectId,
                                    BudgetSourceId = receiptDetail.BudgetSourceId,
                                    Description = receiptDetail.Description,
                                    RefDetailId = receiptDetail.RefDetailId,
                                    ExchangeRate = receiptEntity.ExchangeRate,
                                    ActivityId = receiptDetail.ActivityId,
                                    BudgetSubKindItemCode = receiptDetail.BudgetSubKindItemCode,
                                    CurrencyCode = receiptEntity.CurrencyCode,
                                    BudgetKindItemCode = receiptDetail.BudgetKindItemCode,
                                    RefId = receiptEntity.RefId,
                                    PostedDate = receiptEntity.PostedDate,
                                    MethodDistributeId = receiptDetail.MethodDistributeId,
                                    OrgRefNo = receiptDetail.OrgRefNo,
                                    OrgRefDate = receiptDetail.OrgRefDate,
                                    BudgetItemCode = receiptDetail.BudgetItemCode,
                                    ListItemId = receiptDetail.ListItemId,
                                    BudgetSubItemCode = receiptDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = receiptDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = receiptDetail.CashWithdrawTypeId,
                                    AccountNumber = receiptDetail.DebitAccount ?? receiptDetail.CreditAccount,
                                    DebitAmount =
                                        receiptDetail.DebitAccount == null
                                            ? 0
                                            : receiptDetail.Amount,
                                    DebitAmountOC = receiptDetail.DebitAccount == null ? 0 : receiptDetail.Amount,
                                    CreditAmount =
                                        receiptDetail.CreditAccount == null
                                            ? 0
                                            : receiptDetail.Amount,
                                    CreditAmountOC = receiptDetail.CreditAccount == null ? 0 : receiptDetail.Amount,
                                    FundStructureId = receiptDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = receiptEntity.JournalMemo,
                                    RefDate = receiptEntity.RefDate,
                                    BudgetExpenseId = receiptDetail.BudgetExpenseId,
                                    ContractId = receiptDetail.ContractId,
                                    CapitalPlanId = receiptDetail.CapitalPlanId
                                };
                                receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(receiptResponse.Message))
                                {
                                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                    return receiptResponse;
                                }
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger

                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = receiptEntity.RefType,
                                RefId = receiptEntity.RefId,
                                RefDetailId = receiptDetail.RefDetailId,
                                OrgRefDate = receiptDetail.OrgRefDate,
                                OrgRefNo = receiptDetail.OrgRefNo,
                                RefDate = receiptEntity.RefDate,
                                RefNo = receiptEntity.RefNo,
                                AccountingObjectId = receiptDetail.AccountingObjectId,
                                ActivityId = receiptDetail.ActivityId,
                                Amount = receiptDetail.Amount,
                                AmountOC = receiptDetail.AmountOC,
                                //Approved = receiptDetail.Approved,
                                BankId = receiptDetail.BankId,
                                BudgetChapterCode = receiptDetail.BudgetChapterCode,
                                BudgetDetailItemCode = receiptDetail.BudgetDetailItemCode,
                                BudgetItemCode = receiptDetail.BudgetItemCode,
                                BudgetKindItemCode = receiptDetail.BudgetKindItemCode,
                                BudgetSourceId = receiptDetail.BudgetSourceId,
                                BudgetSubItemCode = receiptDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = receiptDetail.BudgetSubKindItemCode,
                                CashWithDrawTypeId = receiptDetail.CashWithdrawTypeId,
                                CreditAccount = receiptDetail.CreditAccount,
                                DebitAccount = receiptDetail.DebitAccount,
                                Description = receiptDetail.Description,
                                FundStructureId = receiptDetail.FundStructureId,
                                ProjectActivityId = receiptDetail.ProjectActivityId,
                                MethodDistributeId = receiptDetail.MethodDistributeId,
                                JournalMemo = receiptEntity.JournalMemo,
                                ProjectId = receiptDetail.ProjectId,
                                ToBankId = receiptDetail.BankId,
                                PostedDate = receiptEntity.PostedDate,
                                CurrencyCode = receiptEntity.CurrencyCode,
                                ExchangeRate = receiptEntity.ExchangeRate,
                                BudgetExpenseId = receiptDetail.BudgetExpenseId,
                                ContractId = receiptDetail.ContractId,
                            };
                            receiptResponse.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(receiptResponse.Message))
                            {
                                receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return receiptResponse;
                            }

                            #endregion

                            #region Insert to AccountBalance

                            InsertAccountBalance(receiptEntity, receiptDetail);

                            #endregion
                        }
                    }
                    //insert by tax
                    if (receiptEntity.CAReceiptDetailTaxes != null && receiptEntity.CAReceiptDetailTaxes.Count > 0)
                        foreach (var receiptDetailTax in receiptEntity.CAReceiptDetailTaxes)
                        {
                            receiptDetailTax.RefId = receiptEntity.RefId;
                            receiptDetailTax.RefDetailId = Guid.NewGuid().ToString();
                            if (!receiptDetailTax.Validate())
                            {
                                foreach (var error in receiptDetailTax.ValidationErrors)
                                    receiptResponse.Message += error + Environment.NewLine;
                                receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return receiptResponse;
                            }
                            receiptResponse.Message = CAReceiptDetailTaxDao.InsertCAReceiptDetailTax(receiptDetailTax);
                            if (!string.IsNullOrEmpty(receiptResponse.Message))
                            {
                                receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return receiptResponse;
                            }
                        }

                    #region Sinh dinh khoan dong thoi

                    //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                    if (!isAutoGenerateParallel)
                    {
                        #region CAReceiptDetailParallel

                        if (receiptEntity.CAReceiptDetailParallels != null)
                        {
                            //insert dl moi
                            foreach (var receiptDetailParallel in receiptEntity.CAReceiptDetailParallels)
                            {
                                #region Insert Receipt Detail Parallel

                                receiptDetailParallel.RefId = receiptEntity.RefId;
                                receiptDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                receiptDetailParallel.Amount = receiptDetailParallel.Amount;

                                if (!receiptDetailParallel.Validate())
                                {
                                    foreach (var error in receiptDetailParallel.ValidationErrors)
                                        receiptResponse.Message += error + Environment.NewLine;
                                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                    return receiptResponse;
                                }

                                receiptResponse.Message = CAReceiptDetailParallelDao.InsertCAReceiptDetailParallel(receiptDetailParallel);
                                if (!string.IsNullOrEmpty(receiptResponse.Message))
                                {
                                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                    return receiptResponse;
                                }

                                #endregion

                                #region Insert General Ledger Entity
                                if (receiptDetailParallel.DebitAccount != null && receiptDetailParallel.CreditAccount != null)
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = receiptEntity.RefType,
                                        RefNo = receiptEntity.RefNo,
                                        AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                        BankId = receiptDetailParallel.BankId,
                                        BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                        ProjectId = receiptDetailParallel.ProjectId,
                                        BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                        Description = receiptDetailParallel.Description,
                                        RefDetailId = receiptDetailParallel.RefDetailId,
                                        ExchangeRate = receiptEntity.ExchangeRate,
                                        ActivityId = receiptDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = receiptEntity.CurrencyCode,
                                        BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                        RefId = receiptEntity.RefId,
                                        PostedDate = receiptEntity.PostedDate,
                                        MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                        OrgRefNo = receiptDetailParallel.OrgRefNo,
                                        OrgRefDate = receiptDetailParallel.OrgRefDate,
                                        BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                        ListItemId = receiptDetailParallel.ListItemId,
                                        BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = receiptDetailParallel.DebitAccount,
                                        CorrespondingAccountNumber = receiptDetailParallel.CreditAccount,
                                        DebitAmount = receiptDetailParallel.Amount,
                                        DebitAmountOC = receiptDetailParallel.AmountOC,
                                        CreditAmount = 0,
                                        CreditAmountOC = 0,
                                        FundStructureId = receiptDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = receiptEntity.JournalMemo,
                                        RefDate = receiptEntity.RefDate,
                                        BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                        ContractId = receiptDetailParallel.ContractId,
                                        CapitalPlanId = receiptDetailParallel.CapitalPlanId
                                    };
                                    receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(receiptResponse.Message))
                                    {
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }

                                    //insert lan 2
                                    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                    generalLedgerEntity.AccountNumber = receiptDetailParallel.CreditAccount;
                                    generalLedgerEntity.CorrespondingAccountNumber = receiptDetailParallel.DebitAccount;
                                    generalLedgerEntity.DebitAmount = 0;
                                    generalLedgerEntity.DebitAmountOC = 0;
                                    generalLedgerEntity.CreditAmount = receiptDetailParallel.Amount;
                                    generalLedgerEntity.CreditAmountOC = receiptDetailParallel.AmountOC;
                                    receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(receiptResponse.Message))
                                    {
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }
                                }
                                else
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = receiptEntity.RefType,
                                        RefNo = receiptEntity.RefNo,
                                        AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                        BankId = receiptDetailParallel.BankId,
                                        BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                        ProjectId = receiptDetailParallel.ProjectId,
                                        BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                        Description = receiptDetailParallel.Description,
                                        RefDetailId = receiptDetailParallel.RefDetailId,
                                        ExchangeRate = receiptEntity.ExchangeRate,
                                        ActivityId = receiptDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = receiptEntity.CurrencyCode,
                                        BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                        RefId = receiptEntity.RefId,
                                        PostedDate = receiptEntity.PostedDate,
                                        MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                        OrgRefNo = receiptDetailParallel.OrgRefNo,
                                        OrgRefDate = receiptDetailParallel.OrgRefDate,
                                        BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                        ListItemId = receiptDetailParallel.ListItemId,
                                        BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = receiptDetailParallel.DebitAccount ?? receiptDetailParallel.CreditAccount,
                                        DebitAmount = receiptDetailParallel.DebitAccount == null ? 0 : receiptDetailParallel.Amount,
                                        DebitAmountOC = receiptDetailParallel.DebitAccount == null ? 0 : receiptDetailParallel.AmountOC,
                                        CreditAmount = receiptDetailParallel.CreditAccount == null ? 0 : receiptDetailParallel.Amount,
                                        CreditAmountOC = receiptDetailParallel.CreditAccount == null ? 0 : receiptDetailParallel.AmountOC,
                                        FundStructureId = receiptDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = receiptEntity.JournalMemo,
                                        RefDate = receiptEntity.RefDate,
                                        BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                        ContractId = receiptDetailParallel.ContractId,
                                        CapitalPlanId = receiptDetailParallel.CapitalPlanId
                                    };
                                    receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(receiptResponse.Message))
                                    {
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }
                                }


                                #endregion

                                #region Insert OriginalGeneralLedger

                                var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                {
                                    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                    RefType = receiptEntity.RefType,
                                    RefId = receiptEntity.RefId,
                                    RefDetailId = receiptDetailParallel.RefDetailId,
                                    OrgRefDate = receiptDetailParallel.OrgRefDate,
                                    OrgRefNo = receiptDetailParallel.OrgRefNo,
                                    RefDate = receiptEntity.RefDate,
                                    RefNo = receiptEntity.RefNo,
                                    AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                    ActivityId = receiptDetailParallel.ActivityId,
                                    Amount = receiptDetailParallel.Amount,
                                    AmountOC = receiptDetailParallel.AmountOC,
                                    //Approved = receiptDetail.Approved,
                                    BankId = receiptDetailParallel.BankId,
                                    BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                    BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                    BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                    BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                    BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                    BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                    BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                    CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                    CreditAccount = receiptDetailParallel.CreditAccount,
                                    DebitAccount = receiptDetailParallel.DebitAccount,
                                    Description = receiptDetailParallel.Description,
                                    FundStructureId = receiptDetailParallel.FundStructureId,
                                    //ProjectActivityId = receiptDetailParallel.ProjectActivityId,
                                    MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                    JournalMemo = receiptEntity.JournalMemo,
                                    ProjectId = receiptDetailParallel.ProjectId,
                                    ToBankId = receiptDetailParallel.BankId,
                                    ExchangeRate = receiptEntity.ExchangeRate,
                                    CurrencyCode = receiptEntity.CurrencyCode,
                                    PostedDate = receiptEntity.PostedDate,
                                    BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                    ContractId = receiptDetailParallel.ContractId,
                                };
                                receiptResponse.Message =
                                    OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                if (!string.IsNullOrEmpty(receiptResponse.Message))
                                {
                                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                    return receiptResponse;
                                }

                                #endregion
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        //truong hop sinh tu dong se sinh theo chung tu chi tiet
                        foreach (var receiptDetail in receiptEntity.CAReceiptDetails)
                        {
                            //insert dl moi
                            var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                    receiptDetail.DebitAccount, receiptDetail.CreditAccount,
                                    receiptDetail.BudgetSourceId,
                                    receiptDetail.BudgetChapterCode, receiptDetail.BudgetKindItemCode,
                                    receiptDetail.BudgetSubKindItemCode, receiptDetail.BudgetItemCode,
                                    receiptDetail.BudgetSubItemCode,
                                    receiptDetail.MethodDistributeId, receiptDetail.CashWithdrawTypeId);

                            if (autoBusinessParallelEntitys != null)
                            {
                                foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                {
                                    #region CAReceiptDetailParallel

                                    var receiptDetailParallel = new CAReceiptDetailParallelEntity()
                                    {
                                        RefId = receiptEntity.RefId,
                                        Description = receiptDetail.Description,
                                        RefDetailId = Guid.NewGuid().ToString(),
                                        DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                        CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                        Amount = receiptDetail.Amount,
                                        AmountOC = receiptDetail.AmountOC,
                                        BudgetSourceId =
                                            autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                            receiptDetail.BudgetSourceId,
                                        BudgetChapterCode =
                                            autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                            receiptDetail.BudgetChapterCode,
                                        BudgetKindItemCode =
                                            autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                            receiptDetail.BudgetKindItemCode,
                                        BudgetSubKindItemCode =
                                            autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                            receiptDetail.BudgetSubKindItemCode,
                                        BudgetItemCode =
                                            autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                            receiptDetail.BudgetItemCode,
                                        BudgetSubItemCode =
                                            autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                            receiptDetail.BudgetSubItemCode,
                                        MethodDistributeId =
                                            autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                            receiptDetail.MethodDistributeId,
                                        CashWithdrawTypeId =
                                            autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                            receiptDetail.CashWithdrawTypeId,
                                        AccountingObjectId = receiptDetail.AccountingObjectId,
                                        ActivityId = receiptDetail.ActivityId,
                                        ProjectId = receiptDetail.ProjectId,
                                        ListItemId = receiptDetail.ListItemId,
                                        Approved = true,
                                        SortOrder = receiptDetail.SortOrder,
                                        OrgRefNo = receiptDetail.OrgRefNo,
                                        OrgRefDate = receiptDetail.OrgRefDate,
                                        FundStructureId = receiptDetail.FundStructureId,
                                        BankId = receiptDetail.BankId,
                                        BudgetExpenseId = receiptDetail.BudgetExpenseId
                                        //receiptDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                        //receiptDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                    };
                                    if (!receiptDetailParallel.Validate())
                                    {
                                        foreach (var error in receiptDetailParallel.ValidationErrors)
                                            receiptResponse.Message += error + Environment.NewLine;
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }
                                    receiptResponse.Message =
                                        CAReceiptDetailParallelDao.InsertCAReceiptDetailParallel(receiptDetailParallel);
                                    if (!string.IsNullOrEmpty(receiptResponse.Message))
                                    {
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (receiptDetailParallel.DebitAccount != null && receiptDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = receiptEntity.RefType,
                                            RefNo = receiptEntity.RefNo,
                                            AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                            BankId = receiptDetailParallel.BankId,
                                            BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                            ProjectId = receiptDetailParallel.ProjectId,
                                            BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                            Description = receiptDetailParallel.Description,
                                            RefDetailId = receiptDetailParallel.RefDetailId,
                                            ExchangeRate = receiptEntity.ExchangeRate,
                                            ActivityId = receiptDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = receiptEntity.CurrencyCode,
                                            BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                            RefId = receiptEntity.RefId,
                                            PostedDate = receiptEntity.PostedDate,
                                            MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                            OrgRefNo = receiptDetailParallel.OrgRefNo,
                                            OrgRefDate = receiptDetailParallel.OrgRefDate,
                                            BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                            ListItemId = receiptDetailParallel.ListItemId,
                                            BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = receiptDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = receiptDetailParallel.CreditAccount, // Thêm TK Có
                                            DebitAmount = receiptDetailParallel.Amount,
                                            DebitAmountOC = receiptDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = receiptDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = receiptEntity.JournalMemo,
                                            RefDate = receiptEntity.RefDate,
                                            BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                            ContractId = receiptDetailParallel.ContractId,
                                            CapitalPlanId = receiptDetailParallel.CapitalPlanId
                                        };
                                        receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(receiptResponse.Message))
                                        {
                                            receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                            return receiptResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = receiptDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = receiptDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = receiptDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = receiptDetailParallel.AmountOC;
                                        receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = receiptEntity.RefType,
                                            RefNo = receiptEntity.RefNo,
                                            AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                            BankId = receiptDetailParallel.BankId,
                                            BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                            ProjectId = receiptDetailParallel.ProjectId,
                                            BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                            Description = receiptDetailParallel.Description,
                                            RefDetailId = receiptDetailParallel.RefDetailId,
                                            ExchangeRate = receiptEntity.ExchangeRate,
                                            ActivityId = receiptDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = receiptEntity.CurrencyCode,
                                            BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                            RefId = receiptEntity.RefId,
                                            PostedDate = receiptEntity.PostedDate,
                                            MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                            OrgRefNo = receiptDetailParallel.OrgRefNo,
                                            OrgRefDate = receiptDetailParallel.OrgRefDate,
                                            BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                            ListItemId = receiptDetailParallel.ListItemId,
                                            BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                            AccountNumber =
                                            receiptDetailParallel.DebitAccount ?? receiptDetailParallel.CreditAccount,
                                            DebitAmount =
                                            receiptDetailParallel.DebitAccount == null
                                                ? 0
                                                : receiptDetailParallel.Amount,
                                            DebitAmountOC =
                                            receiptDetailParallel.DebitAccount == null
                                                ? 0
                                                : receiptDetailParallel.AmountOC,
                                            CreditAmount =
                                            receiptDetailParallel.CreditAccount == null
                                                ? 0
                                                : receiptDetailParallel.Amount,
                                            CreditAmountOC =
                                            receiptDetailParallel.CreditAccount == null
                                                ? 0
                                                : receiptDetailParallel.AmountOC,
                                            FundStructureId = receiptDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = receiptEntity.JournalMemo,
                                            RefDate = receiptEntity.RefDate,
                                            BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                            ContractId = receiptDetailParallel.ContractId,
                                            CapitalPlanId = receiptDetailParallel.CapitalPlanId
                                        };
                                        receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(receiptResponse.Message))
                                        {
                                            receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                            return receiptResponse;
                                        }
                                    }


                                    #endregion

                                    #region Insert OriginalGeneralLedger

                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = receiptEntity.RefType,
                                        RefId = receiptEntity.RefId,
                                        RefDetailId = receiptDetailParallel.RefDetailId,
                                        OrgRefDate = receiptDetailParallel.OrgRefDate,
                                        OrgRefNo = receiptDetailParallel.OrgRefNo,
                                        RefDate = receiptEntity.RefDate,
                                        RefNo = receiptEntity.RefNo,
                                        AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                        ActivityId = receiptDetailParallel.ActivityId,
                                        Amount = receiptDetailParallel.Amount,
                                        AmountOC = receiptDetailParallel.AmountOC,
                                        //Approved = receiptDetail.Approved,
                                        BankId = receiptDetailParallel.BankId,
                                        BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = receiptDetailParallel.CreditAccount,
                                        DebitAccount = receiptDetailParallel.DebitAccount,
                                        Description = receiptDetailParallel.Description,
                                        FundStructureId = receiptDetailParallel.FundStructureId,
                                        //ProjectActivityId = receiptDetailParallel.ProjectActivityId,
                                        MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                        JournalMemo = receiptEntity.JournalMemo,
                                        ProjectId = receiptDetailParallel.ProjectId,
                                        ToBankId = receiptDetailParallel.BankId,
                                        ExchangeRate = receiptEntity.ExchangeRate,
                                        CurrencyCode = receiptEntity.CurrencyCode,
                                        PostedDate = receiptEntity.PostedDate,
                                        BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                        ContractId = receiptDetailParallel.ContractId,
                                    };
                                    receiptResponse.Message =
                                        OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                            originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(receiptResponse.Message))
                                    {
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }

                                    #endregion
                                }
                            }
                        }
                    }

                    #endregion

                    receiptResponse.RefId = receiptEntity.RefId;
                }

                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }
                scope.Complete();
            }
            return receiptResponse;
        }

        /// <summary>
        /// Updates the ca receipt.
        /// </summary>
        /// <param name="receiptEntity">The receipt entity.</param>
        /// <param name="isConvertData">if set to <c>true</c> [is convert data].</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>CAReceiptResponse.</returns>
        public CAReceiptResponse UpdateCAReceipt(CAReceiptEntity receiptEntity, bool isConvertData, bool isAutoGenerateParallel = false)
        {
            var receiptResponse = new CAReceiptResponse { Acknowledge = AcknowledgeType.Success };
            if (receiptEntity != null && !receiptEntity.Validate())
            {
                foreach (var error in receiptEntity.ValidationErrors)
                    receiptResponse.Message += error + Environment.NewLine;
                receiptResponse.Acknowledge = AcknowledgeType.Failure;
                return receiptResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (receiptEntity != null)
                {
                    var receiptEntityExited = CAReceiptDao.GetCAReceiptByRefNo(receiptEntity.RefNo.Trim(), receiptEntity.PostedDate);
                    if (receiptEntityExited != null && receiptEntityExited.RefId != receiptEntity.RefId && receiptEntityExited.PostedDate.Year == receiptEntity.PostedDate.Year)
                    {
                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                        receiptResponse.Message = @"Số chứng từ '" + receiptEntityExited.RefNo + @"' đã tồn tại!";
                        return receiptResponse;
                    }

                    receiptResponse.Message = CAReceiptDao.UpdateCAReceipt(receiptEntity);
                    if (receiptResponse.Message != null)
                    {
                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return receiptResponse;
                    }

                    #region Update account balance
                    //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                    UpdateAccountBalance(receiptEntity);
                    if (receiptResponse.Message != null)
                    {
                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return receiptResponse;
                    }

                    #endregion

                    #region Delete bussiness logic

                    receiptResponse.Message = CAReceiptDetailDao.DeleteCAReceiptDetailByRefId(receiptEntity.RefId);
                    if (receiptResponse.Message != null)
                    {
                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return receiptResponse;
                    }

                    receiptResponse.Message = CAReceiptDetailTaxDao.DeleteCAReceiptDetailTaxByRefId(receiptEntity.RefId);
                    if (receiptResponse.Message != null)
                    {
                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return receiptResponse;
                    }

                    // Xóa bảng GeneralLedger
                    receiptResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(receiptEntity.RefId);
                    if (receiptResponse.Message != null)
                    {
                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return receiptResponse;
                    }

                    // Xóa bảng OriginalGeneralLedger
                    receiptResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(receiptEntity.RefId);
                    if (receiptResponse.Message != null)
                    {
                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return receiptResponse;
                    }

                    // Xóa bảng CAPaymentDetailParallel
                    receiptResponse.Message = CAReceiptDetailParallelDao.DeleteCAReceiptDetailParallelId(receiptEntity.RefId);
                    if (receiptResponse.Message != null)
                    {
                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return receiptResponse;
                    }

                    #endregion

                    foreach (var receiptDetail in receiptEntity.CAReceiptDetails)
                    {
                        receiptDetail.RefId = receiptEntity.RefId;
                        receiptDetail.RefDetailId = Guid.NewGuid().ToString();

                        if (!receiptDetail.Validate())
                        {
                            foreach (string error in receiptDetail.ValidationErrors)
                                receiptResponse.Message += error + Environment.NewLine;
                            receiptResponse.Acknowledge = AcknowledgeType.Failure;
                            return receiptResponse;
                        }
                        receiptResponse.Message = CAReceiptDetailDao.InsertCAReceiptDetail(receiptDetail);
                        if (!string.IsNullOrEmpty(receiptResponse.Message))
                        {
                            receiptResponse.Acknowledge = AcknowledgeType.Failure;
                            return receiptResponse;
                        }

                        #region Insert General Ledger Entity

                        if (receiptDetail.DebitAccount != null && receiptDetail.CreditAccount != null)
                        {
                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = receiptEntity.RefType,
                                RefNo = receiptEntity.RefNo,
                                AccountingObjectId = receiptDetail.AccountingObjectId,
                                BankId = receiptDetail.BankId,
                                BudgetChapterCode = receiptDetail.BudgetChapterCode,
                                ProjectId = receiptDetail.ProjectId,
                                BudgetSourceId = receiptDetail.BudgetSourceId,
                                Description = receiptDetail.Description,
                                RefDetailId = receiptDetail.RefDetailId,
                                ExchangeRate = receiptEntity.ExchangeRate,
                                ActivityId = receiptDetail.ActivityId,
                                BudgetSubKindItemCode = receiptDetail.BudgetSubKindItemCode,
                                CurrencyCode = receiptEntity.CurrencyCode,
                                BudgetKindItemCode = receiptDetail.BudgetKindItemCode,
                                RefId = receiptEntity.RefId,
                                PostedDate = receiptEntity.PostedDate,
                                MethodDistributeId = receiptDetail.MethodDistributeId,
                                OrgRefNo = receiptDetail.OrgRefNo,
                                OrgRefDate = receiptDetail.OrgRefDate,
                                BudgetItemCode = receiptDetail.BudgetItemCode,
                                ListItemId = receiptDetail.ListItemId,
                                BudgetSubItemCode = receiptDetail.BudgetSubItemCode,
                                BudgetDetailItemCode = receiptDetail.BudgetDetailItemCode,
                                CashWithDrawTypeId = receiptDetail.CashWithdrawTypeId,
                                AccountNumber = receiptDetail.DebitAccount,
                                CorrespondingAccountNumber = receiptDetail.CreditAccount,
                                DebitAmount = receiptDetail.Amount,
                                DebitAmountOC = receiptDetail.AmountOC,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                FundStructureId = receiptDetail.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = receiptEntity.JournalMemo,
                                RefDate = receiptEntity.RefDate,
                                BudgetExpenseId = receiptDetail.BudgetExpenseId,
                                ContractId = receiptDetail.ContractId,
                                CapitalPlanId = receiptDetail.CapitalPlanId
                            };
                            receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(receiptResponse.Message))
                            {
                                receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return receiptResponse;
                            }

                            //insert lan 2
                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                            generalLedgerEntity.AccountNumber = receiptDetail.CreditAccount;
                            generalLedgerEntity.CorrespondingAccountNumber = receiptDetail.DebitAccount;
                            generalLedgerEntity.DebitAmount = 0;
                            generalLedgerEntity.DebitAmountOC = 0;
                            generalLedgerEntity.CreditAmount = receiptDetail.Amount;
                            generalLedgerEntity.CreditAmountOC = receiptDetail.AmountOC;
                            receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(receiptResponse.Message))
                            {
                                receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return receiptResponse;
                            }
                        }
                        else //ghi don
                        {
                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = receiptEntity.RefType,
                                RefNo = receiptEntity.RefNo,
                                AccountingObjectId = receiptEntity.AccountingObjectId,
                                BankId = receiptDetail.BankId,
                                BudgetChapterCode = receiptDetail.BudgetChapterCode,
                                ProjectId = receiptDetail.ProjectId,
                                BudgetSourceId = receiptDetail.BudgetSourceId,
                                Description = receiptDetail.Description,
                                RefDetailId = receiptDetail.RefDetailId,
                                ExchangeRate = receiptEntity.ExchangeRate,
                                ActivityId = receiptDetail.ActivityId,
                                BudgetSubKindItemCode = receiptDetail.BudgetSubKindItemCode,
                                CurrencyCode = receiptEntity.CurrencyCode,
                                BudgetKindItemCode = receiptDetail.BudgetKindItemCode,
                                RefId = receiptEntity.RefId,
                                PostedDate = receiptEntity.PostedDate,
                                MethodDistributeId = receiptDetail.MethodDistributeId,
                                OrgRefNo = receiptDetail.OrgRefNo,
                                OrgRefDate = receiptDetail.OrgRefDate,
                                BudgetItemCode = receiptDetail.BudgetItemCode,
                                ListItemId = receiptDetail.ListItemId,
                                BudgetSubItemCode = receiptDetail.BudgetSubItemCode,
                                BudgetDetailItemCode = receiptDetail.BudgetDetailItemCode,
                                CashWithDrawTypeId = receiptDetail.CashWithdrawTypeId,
                                AccountNumber = receiptDetail.DebitAccount ?? receiptDetail.CreditAccount,
                                DebitAmount = receiptDetail.DebitAccount == null ? 0 : receiptDetail.Amount,
                                DebitAmountOC = receiptDetail.DebitAccount == null ? 0 : receiptDetail.AmountOC,
                                CreditAmount = receiptDetail.CreditAccount == null ? 0 : receiptDetail.Amount,
                                CreditAmountOC = receiptDetail.CreditAccount == null ? 0 : receiptDetail.AmountOC,
                                FundStructureId = receiptDetail.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = receiptEntity.JournalMemo,
                                RefDate = receiptEntity.RefDate,
                                BudgetExpenseId = receiptDetail.BudgetExpenseId,
                                ContractId = receiptDetail.ContractId,
                                CapitalPlanId = receiptDetail.CapitalPlanId
                            };
                            receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(receiptResponse.Message))
                            {
                                receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                return receiptResponse;
                            }
                        }

                        #endregion

                        #region Insert OriginalGeneralLedger
                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = receiptEntity.RefType,
                            RefId = receiptEntity.RefId,
                            RefDetailId = receiptDetail.RefDetailId,
                            OrgRefDate = receiptDetail.OrgRefDate,
                            OrgRefNo = receiptDetail.OrgRefNo,
                            RefDate = receiptEntity.RefDate,
                            RefNo = receiptEntity.RefNo,
                            AccountingObjectId = receiptDetail.AccountingObjectId,
                            ActivityId = receiptDetail.ActivityId,
                            Amount = receiptDetail.Amount,
                            AmountOC = receiptDetail.AmountOC,
                            //Approved = receiptDetail.Approved,
                            BankId = receiptDetail.BankId,
                            BudgetChapterCode = receiptDetail.BudgetChapterCode,
                            BudgetDetailItemCode = receiptDetail.BudgetDetailItemCode,
                            BudgetItemCode = receiptDetail.BudgetItemCode,
                            BudgetKindItemCode = receiptDetail.BudgetKindItemCode,
                            BudgetSourceId = receiptDetail.BudgetSourceId,
                            BudgetSubItemCode = receiptDetail.BudgetSubItemCode,
                            BudgetSubKindItemCode = receiptDetail.BudgetSubKindItemCode,
                            CashWithDrawTypeId = receiptDetail.CashWithdrawTypeId,
                            CreditAccount = receiptDetail.CreditAccount,
                            DebitAccount = receiptDetail.DebitAccount,
                            Description = receiptDetail.Description,
                            FundStructureId = receiptDetail.FundStructureId,
                            ProjectActivityId = receiptDetail.ProjectActivityId,
                            MethodDistributeId = receiptDetail.MethodDistributeId,
                            JournalMemo = receiptEntity.JournalMemo,
                            ProjectId = receiptDetail.ProjectId,
                            ToBankId = receiptDetail.BankId,
                            PostedDate = receiptEntity.PostedDate,
                            CurrencyCode = receiptEntity.CurrencyCode,
                            ExchangeRate = receiptEntity.ExchangeRate,
                            BudgetExpenseId = receiptDetail.BudgetExpenseId,
                            ContractId = receiptDetail.ContractId,
                        };
                        receiptResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                        if (!string.IsNullOrEmpty(receiptResponse.Message))
                        {
                            receiptResponse.Acknowledge = AcknowledgeType.Failure;
                            return receiptResponse;
                        }

                        #endregion

                        #region Insert to AccountBalance

                        InsertAccountBalance(receiptEntity, receiptDetail);

                        #endregion
                    }

                    //insert by tax
                    foreach (var receiptDetailTax in receiptEntity.CAReceiptDetailTaxes)
                    {
                        receiptDetailTax.RefId = receiptEntity.RefId;
                        receiptDetailTax.RefDetailId = Guid.NewGuid().ToString();
                        if (!receiptDetailTax.Validate())
                        {
                            foreach (var error in receiptDetailTax.ValidationErrors)
                                receiptResponse.Message += error + Environment.NewLine;
                            receiptResponse.Acknowledge = AcknowledgeType.Failure;
                            return receiptResponse;
                        }
                        receiptResponse.Message = CAReceiptDetailTaxDao.InsertCAReceiptDetailTax(receiptDetailTax);
                        if (!string.IsNullOrEmpty(receiptResponse.Message))
                        {
                            receiptResponse.Acknowledge = AcknowledgeType.Failure;
                            return receiptResponse;
                        }
                    }

                    #region Sinh dinh khoan dong thoi

                    //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                    if (!isAutoGenerateParallel)
                    {
                        #region CAReceiptDetailParallel

                        if (receiptEntity.CAReceiptDetailParallels != null)
                        {
                            //insert dl moi
                            foreach (var receiptDetailParallel in receiptEntity.CAReceiptDetailParallels)
                            {
                                #region Insert Receipt Detail Parallel

                                receiptDetailParallel.RefId = receiptEntity.RefId;
                                receiptDetailParallel.RefDetailId = Guid.NewGuid().ToString();

                                if (!receiptDetailParallel.Validate())
                                {
                                    foreach (var error in receiptDetailParallel.ValidationErrors)
                                        receiptResponse.Message += error + Environment.NewLine;
                                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                    return receiptResponse;
                                }

                                receiptResponse.Message = CAReceiptDetailParallelDao.InsertCAReceiptDetailParallel(receiptDetailParallel);
                                if (!string.IsNullOrEmpty(receiptResponse.Message))
                                {
                                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                    return receiptResponse;
                                }

                                #endregion

                                #region Insert General Ledger Entity
                                if (receiptDetailParallel.DebitAccount != null && receiptDetailParallel.CreditAccount != null)
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = receiptEntity.RefType,
                                        RefNo = receiptEntity.RefNo,
                                        AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                        BankId = receiptDetailParallel.BankId,
                                        BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                        ProjectId = receiptDetailParallel.ProjectId,
                                        BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                        Description = receiptDetailParallel.Description,
                                        RefDetailId = receiptDetailParallel.RefDetailId,
                                        ExchangeRate = receiptEntity.ExchangeRate,
                                        ActivityId = receiptDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = receiptEntity.CurrencyCode,
                                        BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                        RefId = receiptEntity.RefId,
                                        PostedDate = receiptEntity.PostedDate,
                                        MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                        OrgRefNo = receiptDetailParallel.OrgRefNo,
                                        OrgRefDate = receiptDetailParallel.OrgRefDate,
                                        BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                        ListItemId = receiptDetailParallel.ListItemId,
                                        BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = receiptDetailParallel.DebitAccount,
                                        CorrespondingAccountNumber = receiptDetailParallel.CreditAccount,
                                        DebitAmount = receiptDetailParallel.Amount,
                                        DebitAmountOC = receiptDetailParallel.AmountOC,
                                        CreditAmount = 0,
                                        CreditAmountOC = 0,
                                        FundStructureId = receiptDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = receiptEntity.JournalMemo,
                                        RefDate = receiptEntity.RefDate,
                                        BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                        ContractId = receiptDetailParallel.ContractId,
                                        CapitalPlanId = receiptDetailParallel.CapitalPlanId
                                    };
                                    receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(receiptResponse.Message))
                                    {
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }

                                    //insert lan 2
                                    generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                    generalLedgerEntity.AccountNumber = receiptDetailParallel.CreditAccount;
                                    generalLedgerEntity.CorrespondingAccountNumber = receiptDetailParallel.DebitAccount;
                                    generalLedgerEntity.DebitAmount = 0;
                                    generalLedgerEntity.DebitAmountOC = 0;
                                    generalLedgerEntity.CreditAmount = receiptDetailParallel.Amount;
                                    generalLedgerEntity.CreditAmountOC = receiptDetailParallel.AmountOC;
                                    receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(receiptResponse.Message))
                                    {
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }
                                }
                                else
                                {
                                    var generalLedgerEntity = new GeneralLedgerEntity
                                    {
                                        RefType = receiptEntity.RefType,
                                        RefNo = receiptEntity.RefNo,
                                        AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                        BankId = receiptDetailParallel.BankId,
                                        BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                        ProjectId = receiptDetailParallel.ProjectId,
                                        BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                        Description = receiptDetailParallel.Description,
                                        RefDetailId = receiptDetailParallel.RefDetailId,
                                        ExchangeRate = receiptEntity.ExchangeRate,
                                        ActivityId = receiptDetailParallel.ActivityId,
                                        BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                        CurrencyCode = receiptEntity.CurrencyCode,
                                        BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                        RefId = receiptEntity.RefId,
                                        PostedDate = receiptEntity.PostedDate,
                                        MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                        OrgRefNo = receiptDetailParallel.OrgRefNo,
                                        OrgRefDate = receiptDetailParallel.OrgRefDate,
                                        BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                        ListItemId = receiptDetailParallel.ListItemId,
                                        BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                        BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                        CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                        AccountNumber = receiptDetailParallel.DebitAccount ?? receiptDetailParallel.CreditAccount,
                                        DebitAmount = receiptDetailParallel.DebitAccount == null ? 0 : receiptDetailParallel.Amount,
                                        DebitAmountOC = receiptDetailParallel.DebitAccount == null ? 0 : receiptDetailParallel.AmountOC,
                                        CreditAmount = receiptDetailParallel.CreditAccount == null ? 0 : receiptDetailParallel.Amount,
                                        CreditAmountOC = receiptDetailParallel.CreditAccount == null ? 0 : receiptDetailParallel.AmountOC,
                                        FundStructureId = receiptDetailParallel.FundStructureId,
                                        GeneralLedgerId = Guid.NewGuid().ToString(),
                                        JournalMemo = receiptEntity.JournalMemo,
                                        RefDate = receiptEntity.RefDate,
                                        BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                        ContractId = receiptDetailParallel.ContractId,
                                        CapitalPlanId = receiptDetailParallel.CapitalPlanId
                                    };
                                    receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    if (!string.IsNullOrEmpty(receiptResponse.Message))
                                    {
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }
                                }


                                #endregion

                                #region Insert OriginalGeneralLedger

                                var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                {
                                    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                    RefType = receiptEntity.RefType,
                                    RefId = receiptEntity.RefId,
                                    RefDetailId = receiptDetailParallel.RefDetailId,
                                    OrgRefDate = receiptDetailParallel.OrgRefDate,
                                    OrgRefNo = receiptDetailParallel.OrgRefNo,
                                    RefDate = receiptEntity.RefDate,
                                    RefNo = receiptEntity.RefNo,
                                    AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                    ActivityId = receiptDetailParallel.ActivityId,
                                    Amount = receiptDetailParallel.Amount,
                                    AmountOC = receiptDetailParallel.AmountOC,
                                    //Approved = receiptDetail.Approved,
                                    BankId = receiptDetailParallel.BankId,
                                    BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                    BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                    BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                    BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                    BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                    BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                    BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                    CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                    CreditAccount = receiptDetailParallel.CreditAccount,
                                    DebitAccount = receiptDetailParallel.DebitAccount,
                                    Description = receiptDetailParallel.Description,
                                    FundStructureId = receiptDetailParallel.FundStructureId,
                                    //ProjectActivityId = receiptDetailParallel.ProjectActivityId,
                                    MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                    JournalMemo = receiptEntity.JournalMemo,
                                    ProjectId = receiptDetailParallel.ProjectId,
                                    ToBankId = receiptDetailParallel.BankId,
                                    PostedDate = receiptEntity.PostedDate,
                                    CurrencyCode = receiptEntity.CurrencyCode,
                                    ExchangeRate = receiptEntity.ExchangeRate,
                                    BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                    ContractId = receiptDetailParallel.ContractId,
                                };
                                receiptResponse.Message =
                                    OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                if (!string.IsNullOrEmpty(receiptResponse.Message))
                                {
                                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                    return receiptResponse;
                                }

                                #endregion
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        //truong hop sinh tu dong se sinh theo chung tu chi tiet
                        foreach (var receiptDetail in receiptEntity.CAReceiptDetails)
                        {
                            //insert dl moi
                            var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                    receiptDetail.DebitAccount,
                                    receiptDetail.CreditAccount,
                                    receiptDetail.BudgetSourceId,
                                    receiptDetail.BudgetChapterCode,
                                    receiptDetail.BudgetKindItemCode,
                                    receiptDetail.BudgetSubKindItemCode,
                                    receiptDetail.BudgetItemCode,
                                    receiptDetail.BudgetSubItemCode,
                                    receiptDetail.MethodDistributeId,
                                    receiptDetail.CashWithdrawTypeId);

                            if (autoBusinessParallelEntitys != null)
                            {
                                foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                {
                                    #region CAReceiptDetailParallel

                                    var receiptDetailParallel = new CAReceiptDetailParallelEntity()
                                    {
                                        RefId = receiptEntity.RefId,
                                        Description = receiptDetail.Description,
                                        DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                        CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                        Amount = receiptDetail.Amount,
                                        AmountOC = receiptDetail.AmountOC,
                                        BudgetSourceId =
                                            autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                            receiptDetail.BudgetSourceId,
                                        BudgetChapterCode =
                                            autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                            receiptDetail.BudgetChapterCode,
                                        BudgetKindItemCode =
                                            autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                            receiptDetail.BudgetKindItemCode,
                                        BudgetSubKindItemCode =
                                            autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                            receiptDetail.BudgetSubKindItemCode,
                                        BudgetItemCode =
                                            autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                            receiptDetail.BudgetItemCode,
                                        BudgetSubItemCode =
                                            autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                            receiptDetail.BudgetSubItemCode,
                                        MethodDistributeId =
                                            autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                            receiptDetail.MethodDistributeId,
                                        CashWithdrawTypeId =
                                            autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                            receiptDetail.CashWithdrawTypeId,
                                        AccountingObjectId = receiptDetail.AccountingObjectId,
                                        ActivityId = receiptDetail.ActivityId,
                                        ProjectId = receiptDetail.ProjectId,
                                        ListItemId = receiptDetail.ListItemId,
                                        Approved = true,
                                        SortOrder = receiptDetail.SortOrder,
                                        OrgRefNo = receiptDetail.OrgRefNo,
                                        OrgRefDate = receiptDetail.OrgRefDate,
                                        FundStructureId = receiptDetail.FundStructureId,
                                        BankId = receiptDetail.BankId,
                                        BudgetExpenseId = receiptDetail.BudgetExpenseId,
                                        ContractId = receiptDetail.ContractId,
                                        CapitalPlanId = receiptDetail.CapitalPlanId
                                        //receiptDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                        //receiptDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                    };
                                    if (!receiptDetailParallel.Validate())
                                    {
                                        foreach (var error in receiptDetailParallel.ValidationErrors)
                                            receiptResponse.Message += error + Environment.NewLine;
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }
                                    receiptDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    receiptResponse.Message =
                                        CAReceiptDetailParallelDao.InsertCAReceiptDetailParallel(receiptDetailParallel);
                                    if (!string.IsNullOrEmpty(receiptResponse.Message))
                                    {
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (receiptDetailParallel.DebitAccount != null && receiptDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = receiptEntity.RefType,
                                            RefNo = receiptEntity.RefNo,
                                            AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                            BankId = receiptDetailParallel.BankId,
                                            BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                            ProjectId = receiptDetailParallel.ProjectId,
                                            BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                            Description = receiptDetailParallel.Description,
                                            RefDetailId = receiptDetailParallel.RefDetailId,
                                            ExchangeRate = receiptEntity.ExchangeRate,
                                            ActivityId = receiptDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = receiptEntity.CurrencyCode,
                                            BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                            RefId = receiptEntity.RefId,
                                            PostedDate = receiptEntity.PostedDate,
                                            MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                            OrgRefNo = receiptDetailParallel.OrgRefNo,
                                            OrgRefDate = receiptDetailParallel.OrgRefDate,
                                            BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                            ListItemId = receiptDetailParallel.ListItemId,
                                            BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                            AccountNumber =
                                            receiptDetailParallel.DebitAccount ?? receiptDetailParallel.CreditAccount,
                                            CorrespondingAccountNumber = receiptDetailParallel.CreditAccount, // Thêm TK Có
                                            DebitAmount = receiptDetailParallel.Amount,
                                            DebitAmountOC = receiptDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = receiptDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = receiptEntity.JournalMemo,
                                            RefDate = receiptEntity.RefDate,
                                            BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                            ContractId = receiptDetailParallel.ContractId,
                                            CapitalPlanId = receiptDetailParallel.CapitalPlanId
                                        };
                                        receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(receiptResponse.Message))
                                        {
                                            receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                            return receiptResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = receiptDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = receiptDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = receiptDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = receiptDetailParallel.AmountOC;
                                        receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = receiptEntity.RefType,
                                            RefNo = receiptEntity.RefNo,
                                            AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                            BankId = receiptDetailParallel.BankId,
                                            BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                            ProjectId = receiptDetailParallel.ProjectId,
                                            BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                            Description = receiptDetailParallel.Description,
                                            RefDetailId = receiptDetailParallel.RefDetailId,
                                            ExchangeRate = receiptEntity.ExchangeRate,
                                            ActivityId = receiptDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = receiptEntity.CurrencyCode,
                                            BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                            RefId = receiptEntity.RefId,
                                            PostedDate = receiptEntity.PostedDate,
                                            MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                            OrgRefNo = receiptDetailParallel.OrgRefNo,
                                            OrgRefDate = receiptDetailParallel.OrgRefDate,
                                            BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                            ListItemId = receiptDetailParallel.ListItemId,
                                            BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                            AccountNumber =
                                            receiptDetailParallel.DebitAccount ?? receiptDetailParallel.CreditAccount,
                                            DebitAmount =
                                            receiptDetailParallel.DebitAccount == null
                                                ? 0
                                                : receiptDetailParallel.Amount,
                                            DebitAmountOC =
                                            receiptDetailParallel.DebitAccount == null
                                                ? 0
                                                : receiptDetailParallel.AmountOC,
                                            CreditAmount =
                                            receiptDetailParallel.CreditAccount == null
                                                ? 0
                                                : receiptDetailParallel.Amount,
                                            CreditAmountOC =
                                            receiptDetailParallel.CreditAccount == null
                                                ? 0
                                                : receiptDetailParallel.AmountOC,
                                            FundStructureId = receiptDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = receiptEntity.JournalMemo,
                                            RefDate = receiptEntity.RefDate,
                                            BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                            ContractId = receiptDetailParallel.ContractId,
                                            CapitalPlanId = receiptDetailParallel.CapitalPlanId
                                        };
                                        receiptResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(receiptResponse.Message))
                                        {
                                            receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                            return receiptResponse;
                                        }
                                    }


                                    #endregion

                                    #region Insert OriginalGeneralLedger

                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = receiptEntity.RefType,
                                        RefId = receiptEntity.RefId,
                                        RefDetailId = receiptDetailParallel.RefDetailId,
                                        OrgRefDate = receiptDetailParallel.OrgRefDate,
                                        OrgRefNo = receiptDetailParallel.OrgRefNo,
                                        RefDate = receiptEntity.RefDate,
                                        RefNo = receiptEntity.RefNo,
                                        AccountingObjectId = receiptDetailParallel.AccountingObjectId,
                                        ActivityId = receiptDetailParallel.ActivityId,
                                        Amount = receiptDetailParallel.Amount,
                                        AmountOC = receiptDetailParallel.AmountOC,
                                        //Approved = receiptDetail.Approved,
                                        BankId = receiptDetailParallel.BankId,
                                        BudgetChapterCode = receiptDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = receiptDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = receiptDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = receiptDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = receiptDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = receiptDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = receiptDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = receiptDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = receiptDetailParallel.CreditAccount,
                                        DebitAccount = receiptDetailParallel.DebitAccount,
                                        Description = receiptDetailParallel.Description,
                                        FundStructureId = receiptDetailParallel.FundStructureId,
                                        //ProjectActivityId = receiptDetailParallel.ProjectActivityId,
                                        MethodDistributeId = receiptDetailParallel.MethodDistributeId,
                                        JournalMemo = receiptEntity.JournalMemo,
                                        ProjectId = receiptDetailParallel.ProjectId,
                                        ToBankId = receiptDetailParallel.BankId,
                                        PostedDate = receiptEntity.PostedDate,
                                        CurrencyCode = receiptEntity.CurrencyCode,
                                        ExchangeRate = receiptEntity.ExchangeRate,
                                        BudgetExpenseId = receiptDetailParallel.BudgetExpenseId,
                                        ContractId = receiptDetailParallel.ContractId,
                                    };
                                    receiptResponse.Message =
                                        OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                            originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(receiptResponse.Message))
                                    {
                                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                                        return receiptResponse;
                                    }

                                    #endregion
                                }
                            }
                        }
                    }

                    #endregion

                    if (receiptResponse.Message != null)
                    {
                        receiptResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return receiptResponse;
                    }
                    receiptResponse.RefId = receiptEntity.RefId;
                }
                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }
                scope.Complete();
            }

            return receiptResponse;
        }

        /// <summary>
        /// Deletes the ca receipt.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAReceiptResponse.</returns>
        public CAReceiptResponse DeleteCAReceipt(string refId)
        {
            var receiptResponse = new CAReceiptResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                var receiptEntityForDelete = CAReceiptDao.GetCAReceipt(refId);

                #region Update account balance

                // Cập nhật giá trị vào account balance trước khi xóa
                receiptResponse.Message = UpdateAccountBalance(receiptEntityForDelete);
                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }

                #endregion

                receiptResponse.Message = CAReceiptDao.DeleteCAReceipt(receiptEntityForDelete);
                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }

                receiptResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(receiptEntityForDelete.RefId);
                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }

                receiptResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(receiptEntityForDelete.RefId);
                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }

                #region Delete Parallel

                // Xóa bảng CAPaymentDetailParallel
                receiptResponse.Message = CAReceiptDetailParallelDao.DeleteCAReceiptDetailParallelId(receiptEntityForDelete.RefId);
                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }

                #endregion

                scope.Complete();
            }

            return receiptResponse;
        }

        public CAReceiptResponse DeleteCAReceiptByBUPlanWithdrawRefID(string BUPlanWithdrawRefID)
        {
            var receiptResponse = new CAReceiptResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                var receiptEntityForDelete = CAReceiptDao.GetCAReceiptByBuPlanWithDrawRefID(BUPlanWithdrawRefID);

                #region Update account balance

                // Cập nhật giá trị vào account balance trước khi xóa
                receiptResponse.Message = UpdateAccountBalance(receiptEntityForDelete);
                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }

                #endregion

                receiptResponse.Message = CAReceiptDao.DeleteCAReceipt(receiptEntityForDelete);
                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }

                receiptResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(receiptEntityForDelete.RefId);
                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }

                receiptResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(receiptEntityForDelete.RefId);
                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }

                #region Delete Parallel

                // Xóa bảng CAPaymentDetailParallel
                receiptResponse.Message = CAReceiptDetailParallelDao.DeleteCAReceiptDetailParallelId(receiptEntityForDelete.RefId);
                if (receiptResponse.Message != null)
                {
                    receiptResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return receiptResponse;
                }

                #endregion

                scope.Complete();
            }

            return receiptResponse;
        }

        #region Insert/Update AccountBalance Function

        /// <summary>
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="receiptDetail">The payment detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(CAReceiptEntity caPaymentEntity, CAReceiptDetailEntity receiptDetail)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = receiptDetail.DebitAccount,
                CurrencyCode = caPaymentEntity.CurrencyCode,
                ExchangeRate = caPaymentEntity.ExchangeRate,
                BalanceDate = caPaymentEntity.PostedDate,
                MovementDebitAmountOC = receiptDetail.AmountOC,
                MovementDebitAmount = receiptDetail.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = receiptDetail.BudgetSourceId,
                BudgetChapterCode = receiptDetail.BudgetChapterCode,
                BudgetKindItemCode = receiptDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = receiptDetail.BudgetSubKindItemCode,
                BudgetItemCode = receiptDetail.BudgetItemCode,
                BudgetSubItemCode = receiptDetail.BudgetSubItemCode,
                MethodDistributeId = receiptDetail.MethodDistributeId,
                AccountingObjectId = caPaymentEntity.AccountingObjectId,
                ActivityId = receiptDetail.ActivityId,
                ProjectId = receiptDetail.ProjectId,
                BankAccount = receiptDetail.BankId,
                FundStructureId = receiptDetail.FundStructureId,
                ProjectActivityId = receiptDetail.ProjectActivityId,
                BudgetDetailItemCode = receiptDetail.BudgetDetailItemCode
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="receiptDetail">The payment detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(CAReceiptEntity caPaymentEntity, CAReceiptDetailEntity receiptDetail)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = receiptDetail.CreditAccount,
                CurrencyCode = caPaymentEntity.CurrencyCode,
                ExchangeRate = caPaymentEntity.ExchangeRate,
                BalanceDate = caPaymentEntity.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = receiptDetail.AmountOC,
                MovementCreditAmount = receiptDetail.Amount,
                BudgetSourceId = receiptDetail.BudgetSourceId,
                BudgetChapterCode = receiptDetail.BudgetChapterCode,
                BudgetKindItemCode = receiptDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = receiptDetail.BudgetSubKindItemCode,
                BudgetItemCode = receiptDetail.BudgetItemCode,
                BudgetSubItemCode = receiptDetail.BudgetSubItemCode,
                MethodDistributeId = receiptDetail.MethodDistributeId,
                AccountingObjectId = caPaymentEntity.AccountingObjectId,
                ActivityId = receiptDetail.ActivityId,
                ProjectId = receiptDetail.ProjectId,
                BankAccount = receiptDetail.BankId,
                FundStructureId = receiptDetail.FundStructureId,
                ProjectActivityId = receiptDetail.ProjectActivityId,
                BudgetDetailItemCode = receiptDetail.BudgetDetailItemCode
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
        public string UpdateAccountBalance(CAReceiptEntity caPaymentEntity)
        {
            var receiptDetails = CAReceiptDetailDao.GetCAReceiptDetailsByRefId(caPaymentEntity.RefId);
            foreach (var receiptDetail in receiptDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(caPaymentEntity, receiptDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(caPaymentEntity, receiptDetail);
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
        /// <param name="receiptDetail">The payment detail.</param>
        public void InsertAccountBalance(CAReceiptEntity caPaymentEntity, CAReceiptDetailEntity receiptDetail)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(caPaymentEntity, receiptDetail);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(caPaymentEntity, receiptDetail);
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