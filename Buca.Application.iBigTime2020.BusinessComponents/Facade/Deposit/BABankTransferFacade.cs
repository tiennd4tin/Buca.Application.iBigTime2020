using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Deposit;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Deposit
{
    /// <summary>
    /// Class BABankTransferFacade.
    /// </summary>
    public class BABankTransferFacade
    {
        private static readonly IBABankTransferDao BABankTransferDao = new SqlServerBABankTransferDao();
        private static readonly IBABankTransferDetailDao BABankTransferDetailDao = new SqlServerBABankTransferDetailDao();
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;
        private static readonly IBABankTransferDetailParallelDao BABankTransferDetailParallelDao = DataAccess.DataAccess.BABankTransferDetailParallelDao;

        /// <summary>
        /// Gets the ba bank transfer.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BABankTransferEntity.</returns>
        public BABankTransferEntity GetBABankTransfer(string refId)
        {
            var bABankTransfer = BABankTransferDao.GetBABankTransfer(refId);
            return bABankTransfer ?? new BABankTransferEntity();
        }

        /// <summary>
        /// Gets the ca receipt by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedbBABankTransferDetail">if set to <c>true</c> [is includedb ba bank transfer detail].</param>
        /// <returns>BABankTransferEntity.</returns>
        public BABankTransferEntity GetCAReceiptByRefId(string refId, bool isIncludedbBABankTransferDetail)
        {
            var bABankTransfer = BABankTransferDao.GetBABankTransfer(refId);
            if (bABankTransfer == null)
                return new BABankTransferEntity();
            if (isIncludedbBABankTransferDetail)
            {
                bABankTransfer.BABankTransferDetails = BABankTransferDetailDao.GetBABankTransferDetailsByRefId(bABankTransfer.RefId);
            }

            //default get parallel 
            bABankTransfer.BABankTransferDetailParallels = BABankTransferDetailParallelDao.GetBABankTransferDetailParallelByRefId(bABankTransfer.RefId);

            return bABankTransfer;
        }

        /// <summary>
        /// Gets the ba bank transfers.
        /// </summary>
        /// <returns>IList&lt;BABankTransferEntity&gt;.</returns>
        public IList<BABankTransferEntity> GetBABankTransfers()
        {
            return BABankTransferDao.GetBABankTransfers();
        }

        /// <summary>
        /// Gets the ba bank transfer by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>BABankTransferEntity.</returns>
        public BABankTransferEntity GetBABankTransferByRefNo(string refNo)
        {
            return BABankTransferDao.GetBABankTransferByRefNo(refNo);
        }

        /// <summary>
        /// Inserts the ba bank transfer.
        /// </summary>
        /// <param name="bABankTransfer">The b a bank transfer.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>BABankTransferResponse.</returns>
        public BABankTransferResponse InsertBABankTransfer(BABankTransferEntity bABankTransfer, bool isAutoGenerateParallel = false)
        {
            var bABankTransferResponse = new BABankTransferResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (bABankTransfer != null && !bABankTransfer.Validate())
                {
                    foreach (var error in bABankTransfer.ValidationErrors)
                        bABankTransferResponse.Message += error + Environment.NewLine;
                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                    return bABankTransferResponse;
                }

                using (var scope = new TransactionScope())
                {
                    if (bABankTransfer != null)
                    {
                        var bABankTransfers = BABankTransferDao.GetBABankTransferByRefNo(bABankTransfer.RefNo, bABankTransfer.PostedDate);
                        if (bABankTransfers != null && bABankTransfers.PostedDate.Year == bABankTransfer.PostedDate.Year)
                        {
                            bABankTransferResponse.Message = string.Format("Số chứng từ \'{0}\' đã tồn tại!", bABankTransfer.RefNo);
                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            return bABankTransferResponse;
                        }

                        bABankTransfer.RefId = Guid.NewGuid().ToString();
                        bABankTransferResponse.Message = BABankTransferDao.InsertBABankTransfer(bABankTransfer);

                        if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                        {
                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            return bABankTransferResponse;
                        }
                        if (bABankTransfer.BABankTransferDetails != null &&
                            bABankTransfer.BABankTransferDetails.Count > 0)
                        {
                            foreach (var bABankTransferDetail in bABankTransfer.BABankTransferDetails)
                            {
                                bABankTransferDetail.RefId = bABankTransfer.RefId;
                                bABankTransferDetail.RefDetailId = Guid.NewGuid().ToString();
                                if (!bABankTransferDetail.Validate())
                                {
                                    foreach (var error in bABankTransferDetail.ValidationErrors)
                                        bABankTransferResponse.Message += error + Environment.NewLine;
                                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bABankTransferResponse;
                                }
                                bABankTransferResponse.Message =
                                    BABankTransferDetailDao.InsertBABankTransferDetail(bABankTransferDetail);
                                if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                {
                                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bABankTransferResponse;
                                }

                            }

                            foreach (var bankTranferDetail in bABankTransfer.BABankTransferDetails)
                            {
                                #region Insert to AccountBalance

                                InsertAccountBalance(bABankTransfer, bankTranferDetail);

                                #endregion

                                #region GeneralLedger

                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = bABankTransfer.RefType,
                                    RefNo = bABankTransfer.RefNo,
                                    AccountingObjectId = bankTranferDetail.AccountingObjectId,
                                    BankId = bankTranferDetail.ToBankId,
                                    BudgetChapterCode = bankTranferDetail.BudgetChapterCode,
                                    ProjectId = bankTranferDetail.ProjectId,
                                    BudgetSourceId = bankTranferDetail.BudgetSourceId,
                                    Description = bankTranferDetail.Description,
                                    RefDetailId = bankTranferDetail.RefDetailId,
                                    ExchangeRate = bABankTransfer.ExchangeRate,
                                    ActivityId = bankTranferDetail.ActivityId,
                                    BudgetSubKindItemCode = bankTranferDetail.BudgetSubKindItemCode,
                                    CurrencyCode = bABankTransfer.CurrencyCode,
                                    BudgetKindItemCode = bankTranferDetail.BudgetKindItemCode,
                                    RefId = bABankTransfer.RefId,
                                    PostedDate = bABankTransfer.PostedDate,
                                    MethodDistributeId = bankTranferDetail.MethodDistributeId,
                                    //OrgRefNo = bankTranferDetail.,
                                    // OrgRefDate = bankTranferDetail.OrgRefDate,
                                    BudgetItemCode = bankTranferDetail.BudgetItemCode,
                                    ListItemId = bankTranferDetail.ListItemId,
                                    BudgetSubItemCode = bankTranferDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = bankTranferDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = bankTranferDetail.CashWithDrawTypeId,
                                    AccountNumber = bankTranferDetail.DebitAccount,
                                    CorrespondingAccountNumber = bankTranferDetail.CreditAccount,
                                    DebitAmount = bankTranferDetail.Amount,
                                    DebitAmountOC = bankTranferDetail.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = bankTranferDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = bABankTransfer.JournalMemo,
                                    RefDate = bABankTransfer.RefDate,
                                    BudgetExpenseId = bankTranferDetail.BudgetExpenseId
                                };
                                bABankTransferResponse.Message =
                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                {
                                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bABankTransferResponse;
                                }
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = bankTranferDetail.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = bankTranferDetail.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = bankTranferDetail.Amount;
                                generalLedgerEntity.CreditAmountOC = bankTranferDetail.AmountOC;
                                generalLedgerEntity.BankId = bankTranferDetail.FromBankId;
                                bABankTransferResponse.Message =
                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                {
                                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bABankTransferResponse;
                                }

                                #endregion

                                #region Insert OriginalGeneralLedger

                                var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                {
                                    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                    RefType = bABankTransfer.RefType,
                                    RefId = bABankTransfer.RefId,
                                    RefDetailId = bankTranferDetail.RefDetailId,
                                    RefDate = bABankTransfer.RefDate,
                                    RefNo = bABankTransfer.RefNo,
                                    AccountingObjectId = bankTranferDetail.AccountingObjectId,
                                    ActivityId = bankTranferDetail.ActivityId,
                                    Amount = bankTranferDetail.Amount,
                                    AmountOC = bankTranferDetail.AmountOC,
                                    BudgetChapterCode = bankTranferDetail.BudgetChapterCode,
                                    BudgetDetailItemCode = bankTranferDetail.BudgetDetailItemCode,
                                    BudgetItemCode = bankTranferDetail.BudgetItemCode,
                                    BudgetKindItemCode = bankTranferDetail.BudgetKindItemCode,
                                    BudgetSourceId = bankTranferDetail.BudgetSourceId,
                                    BudgetSubItemCode = bankTranferDetail.BudgetSubItemCode,
                                    BudgetSubKindItemCode = bankTranferDetail.BudgetSubKindItemCode,
                                    CashWithDrawTypeId = bankTranferDetail.CashWithDrawTypeId,
                                    CreditAccount = bankTranferDetail.CreditAccount,
                                    DebitAccount = bankTranferDetail.DebitAccount,
                                    Description = bankTranferDetail.Description,
                                    FundStructureId = bankTranferDetail.FundStructureId,
                                    ProjectActivityId = bankTranferDetail.ProjectActivityId,
                                    MethodDistributeId = bankTranferDetail.MethodDistributeId,
                                    JournalMemo = bABankTransfer.JournalMemo,
                                    ProjectId = bankTranferDetail.ProjectId,
                                    PostedDate = bABankTransfer.PostedDate,
                                    CurrencyCode = bABankTransfer.CurrencyCode,
                                    ExchangeRate = bABankTransfer.ExchangeRate,
                                    BudgetExpenseId = bankTranferDetail.BudgetExpenseId,
                                    BankId = bankTranferDetail.FromBankId,
                                    ToBankId = bankTranferDetail.ToBankId,
                                };
                                bABankTransferResponse.Message =
                                    OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                {
                                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                    return bABankTransferResponse;
                                }

                                #endregion
                            }
                        }

                        #region Sinh dinh khoan dong thoi

                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region CAReceiptDetailParallel

                            if (bABankTransfer.BABankTransferDetails != null)
                            {
                                //insert dl moi
                                if (bABankTransfer.BABankTransferDetailParallels != null)
                                    foreach (var bankTransferDetailParallel in bABankTransfer.BABankTransferDetailParallels)
                                    {
                                        #region Insert Receipt Detail Parallel

                                        bankTransferDetailParallel.RefId = bABankTransfer.RefId;
                                        bankTransferDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                        //bankTransferDetailParallel.Amount = bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate;

                                        if (!bankTransferDetailParallel.Validate())
                                        {
                                            foreach (var error in bankTransferDetailParallel.ValidationErrors)
                                                bABankTransferResponse.Message += error + Environment.NewLine;
                                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bABankTransferResponse;
                                        }

                                        bABankTransferResponse.Message = BABankTransferDetailParallelDao.InsertBABankTransferDetailParallel(bankTransferDetailParallel);
                                        if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                        {
                                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bABankTransferResponse;
                                        }

                                        #endregion

                                        #region Insert General Ledger Entity

                                        if (bankTransferDetailParallel.DebitAccount != null && bankTransferDetailParallel.CreditAccount != null)
                                        {
                                            var generalLedgerEntity = new GeneralLedgerEntity
                                            {
                                                RefType = bABankTransfer.RefType,
                                                RefNo = bABankTransfer.RefNo,
                                                AccountingObjectId = bankTransferDetailParallel.AccountingObjectId,
                                                BankId = bankTransferDetailParallel.BankId,
                                                BudgetChapterCode = bankTransferDetailParallel.BudgetChapterCode,
                                                ProjectId = bankTransferDetailParallel.ProjectId,
                                                BudgetSourceId = bankTransferDetailParallel.BudgetSourceId,
                                                Description = bankTransferDetailParallel.Description,
                                                RefDetailId = bankTransferDetailParallel.RefDetailId,
                                                ExchangeRate = bABankTransfer.ExchangeRate,
                                                ActivityId = bankTransferDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = bankTransferDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = bABankTransfer.CurrencyCode,
                                                BudgetKindItemCode = bankTransferDetailParallel.BudgetKindItemCode,
                                                RefId = bABankTransfer.RefId,
                                                PostedDate = bABankTransfer.PostedDate,
                                                MethodDistributeId = bankTransferDetailParallel.MethodDistributeId,
                                                OrgRefNo = bankTransferDetailParallel.OrgRefNo,
                                                OrgRefDate = bankTransferDetailParallel.OrgRefDate,
                                                BudgetItemCode = bankTransferDetailParallel.BudgetItemCode,
                                                ListItemId = bankTransferDetailParallel.ListItemId,
                                                BudgetSubItemCode = bankTransferDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = bankTransferDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = bankTransferDetailParallel.CashWithdrawTypeId,
                                                AccountNumber = bankTransferDetailParallel.DebitAccount,
                                                CorrespondingAccountNumber = bankTransferDetailParallel.CreditAccount,
                                                DebitAmount = bankTransferDetailParallel.Amount,
                                                //DebitAmount = bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                                DebitAmountOC = bankTransferDetailParallel.AmountOC,
                                                CreditAmount = 0,
                                                CreditAmountOC = 0,
                                                FundStructureId = bankTransferDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = bABankTransfer.JournalMemo,
                                                RefDate = bABankTransfer.RefDate,
                                                BudgetExpenseId = bankTransferDetailParallel.BudgetExpenseId
                                            };
                                            bABankTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                            {
                                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                return bABankTransferResponse;
                                            }

                                            //insert lan 2
                                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                            generalLedgerEntity.AccountNumber = bankTransferDetailParallel.CreditAccount;
                                            generalLedgerEntity.CorrespondingAccountNumber = bankTransferDetailParallel.DebitAccount;
                                            generalLedgerEntity.DebitAmount = 0;
                                            generalLedgerEntity.DebitAmountOC = 0;
                                            generalLedgerEntity.CreditAmount = bankTransferDetailParallel.Amount;
                                            generalLedgerEntity.CreditAmountOC = bankTransferDetailParallel.AmountOC;
                                            bABankTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                            {
                                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                return bABankTransferResponse;
                                            }
                                        }
                                        else
                                        {
                                            var generalLedgerEntity = new GeneralLedgerEntity
                                            {
                                                RefType = bABankTransfer.RefType,
                                                RefNo = bABankTransfer.RefNo,
                                                AccountingObjectId = bankTransferDetailParallel.AccountingObjectId,
                                                BankId = bankTransferDetailParallel.BankId,
                                                BudgetChapterCode = bankTransferDetailParallel.BudgetChapterCode,
                                                ProjectId = bankTransferDetailParallel.ProjectId,
                                                BudgetSourceId = bankTransferDetailParallel.BudgetSourceId,
                                                Description = bankTransferDetailParallel.Description,
                                                RefDetailId = bankTransferDetailParallel.RefDetailId,
                                                ExchangeRate = bABankTransfer.ExchangeRate,
                                                ActivityId = bankTransferDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = bankTransferDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = bABankTransfer.CurrencyCode,
                                                BudgetKindItemCode = bankTransferDetailParallel.BudgetKindItemCode,
                                                RefId = bABankTransfer.RefId,
                                                PostedDate = bABankTransfer.PostedDate,
                                                MethodDistributeId = bankTransferDetailParallel.MethodDistributeId,
                                                OrgRefNo = bankTransferDetailParallel.OrgRefNo,
                                                OrgRefDate = bankTransferDetailParallel.OrgRefDate,
                                                BudgetItemCode = bankTransferDetailParallel.BudgetItemCode,
                                                ListItemId = bankTransferDetailParallel.ListItemId,
                                                BudgetSubItemCode = bankTransferDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = bankTransferDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = bankTransferDetailParallel.CashWithdrawTypeId,
                                                AccountNumber = bankTransferDetailParallel.DebitAccount ?? bankTransferDetailParallel.CreditAccount,
                                                //DebitAmount = bankTransferDetailParallel.DebitAccount == null ? 0 : bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                                DebitAmount = bankTransferDetailParallel.DebitAccount == null ? 0 : bankTransferDetailParallel.Amount,
                                                DebitAmountOC = bankTransferDetailParallel.DebitAccount == null ? 0 : bankTransferDetailParallel.AmountOC,
                                                //CreditAmount = bankTransferDetailParallel.CreditAccount == null ? 0 : bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                                CreditAmount = bankTransferDetailParallel.CreditAccount == null ? 0 : bankTransferDetailParallel.Amount,
                                                CreditAmountOC = bankTransferDetailParallel.CreditAccount == null ? 0 : bankTransferDetailParallel.AmountOC,
                                                FundStructureId = bankTransferDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = bABankTransfer.JournalMemo,
                                                RefDate = bABankTransfer.RefDate,
                                                BudgetExpenseId = bankTransferDetailParallel.BudgetExpenseId
                                            };
                                            bABankTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                            {
                                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                return bABankTransferResponse;
                                            }
                                        }


                                        #endregion

                                        #region Insert OriginalGeneralLedger

                                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                        {
                                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                            RefType = bABankTransfer.RefType,
                                            RefId = bABankTransfer.RefId,
                                            RefDetailId = bankTransferDetailParallel.RefDetailId,
                                            OrgRefDate = bankTransferDetailParallel.OrgRefDate,
                                            OrgRefNo = bankTransferDetailParallel.OrgRefNo,
                                            RefDate = bABankTransfer.RefDate,
                                            RefNo = bABankTransfer.RefNo,
                                            AccountingObjectId = bankTransferDetailParallel.AccountingObjectId,
                                            ActivityId = bankTransferDetailParallel.ActivityId,
                                            Amount = bankTransferDetailParallel.Amount,
                                            AmountOC = bankTransferDetailParallel.AmountOC,
                                            //Approved = receiptDetail.Approved,
                                            BankId = bankTransferDetailParallel.BankId,
                                            BudgetChapterCode = bankTransferDetailParallel.BudgetChapterCode,
                                            BudgetDetailItemCode = bankTransferDetailParallel.BudgetDetailItemCode,
                                            BudgetItemCode = bankTransferDetailParallel.BudgetItemCode,
                                            BudgetKindItemCode = bankTransferDetailParallel.BudgetKindItemCode,
                                            BudgetSourceId = bankTransferDetailParallel.BudgetSourceId,
                                            BudgetSubItemCode = bankTransferDetailParallel.BudgetSubItemCode,
                                            BudgetSubKindItemCode = bankTransferDetailParallel.BudgetSubKindItemCode,
                                            CashWithDrawTypeId = bankTransferDetailParallel.CashWithdrawTypeId,
                                            CreditAccount = bankTransferDetailParallel.CreditAccount,
                                            DebitAccount = bankTransferDetailParallel.DebitAccount,
                                            Description = bankTransferDetailParallel.Description,
                                            FundStructureId = bankTransferDetailParallel.FundStructureId,
                                            //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                            MethodDistributeId = bankTransferDetailParallel.MethodDistributeId,
                                            JournalMemo = bABankTransfer.JournalMemo,
                                            ProjectId = bankTransferDetailParallel.ProjectId,
                                            ToBankId = bankTransferDetailParallel.BankId,
                                            ExchangeRate = bABankTransfer.ExchangeRate,
                                            CurrencyCode = bABankTransfer.CurrencyCode,
                                            PostedDate = bABankTransfer.PostedDate,
                                        };
                                        bABankTransferResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                        if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                        {
                                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bABankTransferResponse;
                                        }

                                        #endregion
                                    }
                            }

                            #endregion
                        }
                        else
                        {
                            //truong hop sinh tu dong se sinh theo chung tu chi tiet
                            if (bABankTransfer.BABankTransferDetails != null)
                            {
                                foreach (var bABankTransferDetail in bABankTransfer.BABankTransferDetails)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                            bABankTransferDetail.DebitAccount, bABankTransferDetail.CreditAccount,
                                            bABankTransferDetail.BudgetSourceId,
                                            bABankTransferDetail.BudgetChapterCode, bABankTransferDetail.BudgetKindItemCode,
                                            bABankTransferDetail.BudgetSubKindItemCode, bABankTransferDetail.BudgetItemCode,
                                            bABankTransferDetail.BudgetSubItemCode,
                                            bABankTransferDetail.MethodDistributeId, bABankTransferDetail.CashWithDrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region BABankTransferDetailParallel

                                            var bankTransferDetailParallel = new BABankTransferDetailParallelEntity
                                            {
                                                RefId = bABankTransfer.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = bABankTransferDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                //Amount = bABankTransferDetail.AmountOC * bABankTransfer.ExchangeRate,
                                                Amount = bABankTransferDetail.Amount,
                                                AmountOC = bABankTransferDetail.AmountOC,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    bABankTransferDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    bABankTransferDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    bABankTransferDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    bABankTransferDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    bABankTransferDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    bABankTransferDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    bABankTransferDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    bABankTransferDetail.CashWithDrawTypeId,
                                                AccountingObjectId = bABankTransferDetail.AccountingObjectId,
                                                ActivityId = bABankTransferDetail.ActivityId,
                                                ProjectId = bABankTransferDetail.ProjectId,
                                                ListItemId = bABankTransferDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = bABankTransferDetail.SortOrder,
                                                //OrgRefNo = bABankTransferDetail.OrgRefNo,
                                                //OrgRefDate = bABankTransferDetail.OrgRefDate,
                                                FundStructureId = bABankTransferDetail.FundStructureId,
                                                BudgetExpenseId = bABankTransferDetail.BudgetExpenseId,
                                                BankId = bABankTransferDetail.ToBankId
                                                //withDrawDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                                //withDrawDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                            };
                                            if (!bankTransferDetailParallel.Validate())
                                            {
                                                foreach (var error in bankTransferDetailParallel.ValidationErrors)
                                                    bABankTransferResponse.Message += error + Environment.NewLine;
                                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                return bABankTransferResponse;
                                            }
                                            bABankTransferResponse.Message =
                                                BABankTransferDetailParallelDao.InsertBABankTransferDetailParallel(
                                                    bankTransferDetailParallel);
                                            if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                            {
                                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                return bABankTransferResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (bankTransferDetailParallel.DebitAccount != null && bankTransferDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = bABankTransfer.RefType,
                                                    RefNo = bABankTransfer.RefNo,
                                                    AccountingObjectId = bankTransferDetailParallel.AccountingObjectId,
                                                    BankId = bankTransferDetailParallel.BankId,
                                                    BudgetChapterCode = bankTransferDetailParallel.BudgetChapterCode,
                                                    ProjectId = bankTransferDetailParallel.ProjectId,
                                                    BudgetSourceId = bankTransferDetailParallel.BudgetSourceId,
                                                    Description = bankTransferDetailParallel.Description,
                                                    RefDetailId = bankTransferDetailParallel.RefDetailId,
                                                    ExchangeRate = bABankTransfer.ExchangeRate,
                                                    ActivityId = bankTransferDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = bankTransferDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bABankTransfer.CurrencyCode,
                                                    BudgetKindItemCode = bankTransferDetailParallel.BudgetKindItemCode,
                                                    RefId = bABankTransfer.RefId,
                                                    PostedDate = bABankTransfer.PostedDate,
                                                    MethodDistributeId = bankTransferDetailParallel.MethodDistributeId,
                                                    //OrgRefNo = bABankTransferDetail.OrgRefNo,
                                                    //OrgRefDate = bABankTransferDetail.OrgRefDate,
                                                    BudgetItemCode = bankTransferDetailParallel.BudgetItemCode,
                                                    ListItemId = bankTransferDetailParallel.ListItemId,
                                                    BudgetSubItemCode = bankTransferDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = bankTransferDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = bankTransferDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber = bankTransferDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = bankTransferDetailParallel.CreditAccount,
                                                    //DebitAmount = bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                                    DebitAmount = bankTransferDetailParallel.Amount,
                                                    DebitAmountOC = bankTransferDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = bankTransferDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bABankTransfer.JournalMemo,
                                                    RefDate = bABankTransfer.RefDate,
                                                    BudgetExpenseId = bankTransferDetailParallel.BudgetExpenseId
                                                };
                                                bABankTransferResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                                {
                                                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return bABankTransferResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = bankTransferDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = bankTransferDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = bankTransferDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = bankTransferDetailParallel.AmountOC;
                                                bABankTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                                {
                                                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return bABankTransferResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = bABankTransfer.RefType,
                                                    RefNo = bABankTransfer.RefNo,
                                                    AccountingObjectId = bankTransferDetailParallel.AccountingObjectId,
                                                    BankId = bankTransferDetailParallel.BankId,
                                                    BudgetChapterCode = bankTransferDetailParallel.BudgetChapterCode,
                                                    ProjectId = bankTransferDetailParallel.ProjectId,
                                                    BudgetSourceId = bankTransferDetailParallel.BudgetSourceId,
                                                    Description = bankTransferDetailParallel.Description,
                                                    RefDetailId = bankTransferDetailParallel.RefDetailId,
                                                    ExchangeRate = bABankTransfer.ExchangeRate,
                                                    ActivityId = bankTransferDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = bankTransferDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bABankTransfer.CurrencyCode,
                                                    BudgetKindItemCode = bankTransferDetailParallel.BudgetKindItemCode,
                                                    RefId = bABankTransfer.RefId,
                                                    PostedDate = bABankTransfer.PostedDate,
                                                    MethodDistributeId = bankTransferDetailParallel.MethodDistributeId,
                                                    //OrgRefNo = bABankTransferDetail.OrgRefNo,
                                                    //OrgRefDate = bABankTransferDetail.OrgRefDate,
                                                    BudgetItemCode = bankTransferDetailParallel.BudgetItemCode,
                                                    ListItemId = bankTransferDetailParallel.ListItemId,
                                                    BudgetSubItemCode = bankTransferDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = bankTransferDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = bankTransferDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                bankTransferDetailParallel.DebitAccount ??
                                                bankTransferDetailParallel.CreditAccount,
                                                //    DebitAmount =
                                                //bankTransferDetailParallel.DebitAccount == null
                                                //    ? 0
                                                //    : bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                                    DebitAmount =
                                                bankTransferDetailParallel.DebitAccount == null
                                                    ? 0
                                                    : bankTransferDetailParallel.Amount,
                                                    DebitAmountOC =
                                                bankTransferDetailParallel.DebitAccount == null
                                                    ? 0
                                                    : bankTransferDetailParallel.AmountOC,
                                                //    CreditAmount =
                                                //bankTransferDetailParallel.CreditAccount == null
                                                //    ? 0
                                                //    : bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                                    CreditAmount =
                                                bankTransferDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : bankTransferDetailParallel.Amount,
                                                    CreditAmountOC =
                                                bankTransferDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : bankTransferDetailParallel.AmountOC,
                                                    FundStructureId = bankTransferDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bABankTransfer.JournalMemo,
                                                    RefDate = bABankTransfer.RefDate,
                                                    BudgetExpenseId = bankTransferDetailParallel.BudgetExpenseId
                                                };
                                                bABankTransferResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                                {
                                                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return bABankTransferResponse;
                                                }
                                            }


                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = bABankTransfer.RefType,
                                                RefId = bABankTransfer.RefId,
                                                RefDetailId = bABankTransferDetail.RefDetailId,
                                                //OrgRefDate = bABankTransferDetail.OrgRefDate,
                                                //OrgRefNo = bABankTransferDetail.OrgRefNo,
                                                RefDate = bABankTransfer.RefDate,
                                                RefNo = bABankTransfer.RefNo,
                                                AccountingObjectId = bABankTransferDetail.AccountingObjectId,
                                                ActivityId = bABankTransferDetail.ActivityId,
                                                Amount = bABankTransferDetail.Amount,
                                                AmountOC = bABankTransferDetail.AmountOC,
                                                //Approved = receiptDetail.Approved,
                                                BankId = bABankTransferDetail.ToBankId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    bABankTransferDetail.BudgetChapterCode,
                                                BudgetDetailItemCode = bABankTransferDetail.BudgetDetailItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    bABankTransferDetail.BudgetItemCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    bABankTransferDetail.BudgetKindItemCode,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    bABankTransferDetail.BudgetSourceId,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    bABankTransferDetail.BudgetSubItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    bABankTransferDetail.BudgetSubKindItemCode,
                                                CashWithDrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    bABankTransferDetail.CashWithDrawTypeId,
                                                CreditAccount = bankTransferDetailParallel.CreditAccount,
                                                DebitAccount = bankTransferDetailParallel.DebitAccount,
                                                Description = bABankTransferDetail.Description,
                                                FundStructureId = bABankTransferDetail.FundStructureId,
                                                //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    bABankTransferDetail.MethodDistributeId,
                                                JournalMemo = bABankTransfer.JournalMemo,
                                                ProjectId = bABankTransferDetail.ProjectId,
                                                ToBankId = bABankTransferDetail.ToBankId,
                                                ExchangeRate = bABankTransfer.ExchangeRate,
                                                CurrencyCode = bABankTransfer.CurrencyCode,
                                                PostedDate = bABankTransfer.PostedDate,
                                            };
                                            bABankTransferResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                            {
                                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                return bABankTransferResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }
                        }

                        #endregion

                        bABankTransferResponse.RefId = bABankTransfer.RefId;
                        if (bABankTransferResponse.Message != null)
                        {
                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bABankTransferResponse;
                        }
                        scope.Complete();
                    }
                    return bABankTransferResponse;
                }
            }
            catch (Exception ex)
            {
                bABankTransferResponse.Message = ex.Message;
                return bABankTransferResponse;
            }
        }

        /// <summary>
        /// Updates the ba bank transfer.
        /// </summary>
        /// <param name="bABankTransfer">The b a bank transfer.</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>BABankTransferResponse.</returns>
        public BABankTransferResponse UpdateBABankTransfer(BABankTransferEntity bABankTransfer, bool isAutoGenerateParallel = false)
        {
            var bABankTransferResponse = new BABankTransferResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (bABankTransfer != null && !bABankTransfer.Validate())
                {
                    foreach (var error in bABankTransfer.ValidationErrors)
                        bABankTransferResponse.Message += error + Environment.NewLine;
                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                    return bABankTransferResponse;
                }

                using (var scope = new TransactionScope())
                {
                    if (bABankTransfer != null)
                    {
                        var bABankTransfers = BABankTransferDao.GetBABankTransferByRefNo(bABankTransfer.RefNo, bABankTransfer.PostedDate);
                        if (bABankTransfers != null && bABankTransfers.RefId != bABankTransfer.RefId && bABankTransfers.PostedDate.Year == bABankTransfer.PostedDate.Year)
                        {
                            bABankTransferResponse.Message = string.Format("Số chứng từ \'{0}\' đã tồn tại!", bABankTransfer.RefNo);
                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            return bABankTransferResponse;
                        }

                        bABankTransferResponse.Message = BABankTransferDetailDao.DeleteBABankTransferDetailByRefId(bABankTransfer.RefId);
                        if (bABankTransferResponse.Message != null)
                        {
                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bABankTransferResponse;
                        }

                        bABankTransferResponse.Message = BABankTransferDao.UpdateBABankTransfer(bABankTransfer);
                        if (bABankTransferResponse.Message != null)
                        {
                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bABankTransferResponse;
                        }

                        #region Delete GeneralLedger

                        bABankTransferResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(bABankTransfer.RefId);
                        if (bABankTransferResponse.Message != null)
                        {
                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bABankTransferResponse;
                        }

                        #endregion

                        // Xóa bảng OriginalGeneralLedger
                        bABankTransferResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(bABankTransfer.RefId);
                        if (bABankTransferResponse.Message != null)
                        {
                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bABankTransferResponse;
                        }

                        #region Update account balance
                        //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                        UpdateAccountBalance(bABankTransfer);
                        if (bABankTransferResponse.Message != null)
                        {
                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return bABankTransferResponse;
                        }

                        #endregion

                        foreach (var receiptDetail in bABankTransfer.BABankTransferDetails)
                        {
                            receiptDetail.RefId = bABankTransfer.RefId;
                            receiptDetail.RefDetailId = Guid.NewGuid().ToString();

                            if (!receiptDetail.Validate())
                            {
                                foreach (string error in receiptDetail.ValidationErrors)
                                    bABankTransferResponse.Message += error + Environment.NewLine;
                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bABankTransferResponse;
                            }
                            bABankTransferResponse.Message = BABankTransferDetailDao.InsertBABankTransferDetail(receiptDetail);
                            if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                            {
                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bABankTransferResponse;
                            }
                            #region generalLedger

                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = bABankTransfer.RefType,
                                RefNo = bABankTransfer.RefNo,
                                AccountingObjectId = receiptDetail.AccountingObjectId,
                                BankId = receiptDetail.ToBankId,
                                BudgetChapterCode = receiptDetail.BudgetChapterCode,
                                ProjectId = receiptDetail.ProjectId,
                                BudgetSourceId = receiptDetail.BudgetSourceId,
                                Description = receiptDetail.Description,
                                RefDetailId = receiptDetail.RefDetailId,
                                ExchangeRate = bABankTransfer.ExchangeRate,
                                ActivityId = receiptDetail.ActivityId,
                                BudgetSubKindItemCode = receiptDetail.BudgetSubKindItemCode,
                                CurrencyCode = bABankTransfer.CurrencyCode,
                                BudgetKindItemCode = receiptDetail.BudgetKindItemCode,
                                RefId = bABankTransfer.RefId,
                                PostedDate = bABankTransfer.PostedDate,
                                MethodDistributeId = receiptDetail.MethodDistributeId,
                                //OrgRefNo = bankTranferDetail.,
                                // OrgRefDate = bankTranferDetail.OrgRefDate,
                                BudgetItemCode = receiptDetail.BudgetItemCode,
                                ListItemId = receiptDetail.ListItemId,
                                BudgetSubItemCode = receiptDetail.BudgetSubItemCode,
                                BudgetDetailItemCode = receiptDetail.BudgetDetailItemCode,
                                CashWithDrawTypeId = receiptDetail.CashWithDrawTypeId,
                                AccountNumber = receiptDetail.DebitAccount,
                                CorrespondingAccountNumber = receiptDetail.CreditAccount,
                                DebitAmount = receiptDetail.Amount,
                                DebitAmountOC = receiptDetail.AmountOC,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                FundStructureId = receiptDetail.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = bABankTransfer.JournalMemo,
                                RefDate = bABankTransfer.RefDate,
                                BudgetExpenseId = receiptDetail.BudgetExpenseId
                            };
                            bABankTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                            {
                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bABankTransferResponse;
                            }
                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                            generalLedgerEntity.AccountNumber = receiptDetail.CreditAccount;
                            generalLedgerEntity.CorrespondingAccountNumber = receiptDetail.DebitAccount;
                            generalLedgerEntity.DebitAmount = 0;
                            generalLedgerEntity.DebitAmountOC = 0;
                            generalLedgerEntity.CreditAmount = receiptDetail.Amount;
                            generalLedgerEntity.CreditAmountOC = receiptDetail.AmountOC;
                            generalLedgerEntity.BankId = receiptDetail.FromBankId;
                            bABankTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                            {
                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bABankTransferResponse;
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = bABankTransfer.RefType,
                                RefId = bABankTransfer.RefId,
                                RefDetailId = receiptDetail.RefDetailId,
                                //      OrgRefDate = receiptDetail.OrgRefDate,
                                //     OrgRefNo = receiptDetail.OrgRefNo,
                                RefDate = bABankTransfer.RefDate,
                                RefNo = bABankTransfer.RefNo,
                                AccountingObjectId = receiptDetail.AccountingObjectId,
                                ActivityId = receiptDetail.ActivityId,
                                Amount = receiptDetail.Amount,
                                AmountOC = receiptDetail.AmountOC,
                                // Approved = receiptDetail.Approved,
                                //      BankId = receiptDetail.BankId,
                                //    BudgetChapterCode = receiptDetail.BudgetChapterCode,
                                BudgetDetailItemCode = receiptDetail.BudgetDetailItemCode,
                                BudgetItemCode = receiptDetail.BudgetItemCode,
                                BudgetKindItemCode = receiptDetail.BudgetKindItemCode,
                                BudgetSourceId = receiptDetail.BudgetSourceId,
                                BudgetSubItemCode = receiptDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = receiptDetail.BudgetSubKindItemCode,
                                CashWithDrawTypeId = receiptDetail.CashWithDrawTypeId,
                                CreditAccount = receiptDetail.CreditAccount,
                                DebitAccount = receiptDetail.DebitAccount,
                                Description = receiptDetail.Description,
                                FundStructureId = receiptDetail.FundStructureId,
                                ProjectActivityId = receiptDetail.ProjectActivityId,
                                MethodDistributeId = receiptDetail.MethodDistributeId,
                                JournalMemo = bABankTransfer.JournalMemo,
                                ProjectId = receiptDetail.ProjectId,
                                // ToBankId = receiptDetail.BankId,
                                PostedDate = bABankTransfer.PostedDate,
                                CurrencyCode = bABankTransfer.CurrencyCode,
                                ExchangeRate = bABankTransfer.ExchangeRate,
                                BudgetExpenseId = receiptDetail.BudgetExpenseId,
                                BankId = receiptDetail.FromBankId,
                                ToBankId = receiptDetail.ToBankId
                            };
                            bABankTransferResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                            {
                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                return bABankTransferResponse;
                            }

                            #endregion
                        }

                        #region Sinh dinh khoan dong thoi

                        // delete bang BAWithDrawDetailParallel
                        bABankTransferResponse.Message = BABankTransferDetailParallelDao.DeleteBABankTransferDetailParallelById(bABankTransfer.RefId);
                        if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                        {
                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                            return bABankTransferResponse;
                        }

                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region CAReceiptDetailParallel

                            if (bABankTransfer.BABankTransferDetails != null)
                            {
                                //insert dl moi
                                foreach (var bankTransferDetailParallel in bABankTransfer.BABankTransferDetailParallels)
                                {
                                    #region Insert Receipt Detail Parallel

                                    bankTransferDetailParallel.RefId = bABankTransfer.RefId;
                                    bankTransferDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    //bankTransferDetailParallel.Amount = bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate;
                                    bankTransferDetailParallel.Amount = bankTransferDetailParallel.Amount;

                                    if (!bankTransferDetailParallel.Validate())
                                    {
                                        foreach (var error in bankTransferDetailParallel.ValidationErrors)
                                            bABankTransferResponse.Message += error + Environment.NewLine;
                                        bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bABankTransferResponse;
                                    }

                                    bABankTransferResponse.Message = BABankTransferDetailParallelDao.InsertBABankTransferDetailParallel(bankTransferDetailParallel);
                                    if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                    {
                                        bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bABankTransferResponse;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity

                                    if (bankTransferDetailParallel.DebitAccount != null && bankTransferDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bABankTransfer.RefType,
                                            RefNo = bABankTransfer.RefNo,
                                            AccountingObjectId = bankTransferDetailParallel.AccountingObjectId,
                                            BankId = bankTransferDetailParallel.BankId,
                                            BudgetChapterCode = bankTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = bankTransferDetailParallel.ProjectId,
                                            BudgetSourceId = bankTransferDetailParallel.BudgetSourceId,
                                            Description = bankTransferDetailParallel.Description,
                                            RefDetailId = bankTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bABankTransfer.ExchangeRate,
                                            ActivityId = bankTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = bankTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bABankTransfer.CurrencyCode,
                                            BudgetKindItemCode = bankTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bABankTransfer.RefId,
                                            PostedDate = bABankTransfer.PostedDate,
                                            MethodDistributeId = bankTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = bankTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = bankTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = bankTransferDetailParallel.BudgetItemCode,
                                            ListItemId = bankTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = bankTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = bankTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = bankTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = bankTransferDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = bankTransferDetailParallel.CreditAccount,
                                            //DebitAmount = bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                            DebitAmount = bankTransferDetailParallel.Amount,
                                            DebitAmountOC = bankTransferDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = bankTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bABankTransfer.JournalMemo,
                                            RefDate = bABankTransfer.RefDate,
                                            BudgetExpenseId = bankTransferDetailParallel.BudgetExpenseId
                                        };
                                        bABankTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                        {
                                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bABankTransferResponse;
                                        }


                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = bankTransferDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = bankTransferDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = bankTransferDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = bankTransferDetailParallel.AmountOC;
                                        bABankTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                        {
                                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bABankTransferResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = bABankTransfer.RefType,
                                            RefNo = bABankTransfer.RefNo,
                                            AccountingObjectId = bankTransferDetailParallel.AccountingObjectId,
                                            BankId = bankTransferDetailParallel.BankId,
                                            BudgetChapterCode = bankTransferDetailParallel.BudgetChapterCode,
                                            ProjectId = bankTransferDetailParallel.ProjectId,
                                            BudgetSourceId = bankTransferDetailParallel.BudgetSourceId,
                                            Description = bankTransferDetailParallel.Description,
                                            RefDetailId = bankTransferDetailParallel.RefDetailId,
                                            ExchangeRate = bABankTransfer.ExchangeRate,
                                            ActivityId = bankTransferDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = bankTransferDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = bABankTransfer.CurrencyCode,
                                            BudgetKindItemCode = bankTransferDetailParallel.BudgetKindItemCode,
                                            RefId = bABankTransfer.RefId,
                                            PostedDate = bABankTransfer.PostedDate,
                                            MethodDistributeId = bankTransferDetailParallel.MethodDistributeId,
                                            OrgRefNo = bankTransferDetailParallel.OrgRefNo,
                                            OrgRefDate = bankTransferDetailParallel.OrgRefDate,
                                            BudgetItemCode = bankTransferDetailParallel.BudgetItemCode,
                                            ListItemId = bankTransferDetailParallel.ListItemId,
                                            BudgetSubItemCode = bankTransferDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = bankTransferDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = bankTransferDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = bankTransferDetailParallel.DebitAccount ?? bankTransferDetailParallel.CreditAccount,
                                            //DebitAmount = bankTransferDetailParallel.DebitAccount == null ? 0 : bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                            DebitAmount = bankTransferDetailParallel.DebitAccount == null ? 0 : bankTransferDetailParallel.Amount,
                                            DebitAmountOC = bankTransferDetailParallel.DebitAccount == null ? 0 : bankTransferDetailParallel.AmountOC,
                                            //CreditAmount = bankTransferDetailParallel.CreditAccount == null ? 0 : bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                            CreditAmount = bankTransferDetailParallel.CreditAccount == null ? 0 : bankTransferDetailParallel.Amount,
                                            CreditAmountOC = bankTransferDetailParallel.CreditAccount == null ? 0 : bankTransferDetailParallel.AmountOC,
                                            FundStructureId = bankTransferDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = bABankTransfer.JournalMemo,
                                            RefDate = bABankTransfer.RefDate,
                                            BudgetExpenseId = bankTransferDetailParallel.BudgetExpenseId
                                        };
                                        bABankTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                        {
                                            bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                            return bABankTransferResponse;
                                        }
                                    }


                                    #endregion

                                    #region Insert OriginalGeneralLedger

                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = bABankTransfer.RefType,
                                        RefId = bABankTransfer.RefId,
                                        RefDetailId = bankTransferDetailParallel.RefDetailId,
                                        OrgRefDate = bankTransferDetailParallel.OrgRefDate,
                                        OrgRefNo = bankTransferDetailParallel.OrgRefNo,
                                        RefDate = bABankTransfer.RefDate,
                                        RefNo = bABankTransfer.RefNo,  
                                        AccountingObjectId = bankTransferDetailParallel.AccountingObjectId,
                                        ActivityId = bankTransferDetailParallel.ActivityId,
                                        Amount = bankTransferDetailParallel.Amount,
                                        AmountOC = bankTransferDetailParallel.AmountOC,
                                        //Approved = receiptDetail.Approved,
                                        BankId = bankTransferDetailParallel.BankId,
                                        BudgetChapterCode = bankTransferDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = bankTransferDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = bankTransferDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = bankTransferDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = bankTransferDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = bankTransferDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = bankTransferDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = bankTransferDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = bankTransferDetailParallel.CreditAccount,
                                        DebitAccount = bankTransferDetailParallel.DebitAccount,
                                        Description = bankTransferDetailParallel.Description,
                                        FundStructureId = bankTransferDetailParallel.FundStructureId,
                                        //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                        MethodDistributeId = bankTransferDetailParallel.MethodDistributeId,
                                        JournalMemo = bABankTransfer.JournalMemo,
                                        ProjectId = bankTransferDetailParallel.ProjectId,
                                        ToBankId = bankTransferDetailParallel.BankId,
                                        ExchangeRate = bABankTransfer.ExchangeRate,
                                        CurrencyCode = bABankTransfer.CurrencyCode,
                                        PostedDate = bABankTransfer.PostedDate,
                                    };
                                    bABankTransferResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                    {
                                        bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                        return bABankTransferResponse;
                                    }

                                    #endregion
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            //truong hop sinh tu dong se sinh theo chung tu chi tiet
                            if (bABankTransfer.BABankTransferDetails != null)
                            {
                                foreach (var bABankTransferDetail in bABankTransfer.BABankTransferDetails)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                            bABankTransferDetail.DebitAccount, bABankTransferDetail.CreditAccount,
                                            bABankTransferDetail.BudgetSourceId,
                                            bABankTransferDetail.BudgetChapterCode, bABankTransferDetail.BudgetKindItemCode,
                                            bABankTransferDetail.BudgetSubKindItemCode, bABankTransferDetail.BudgetItemCode,
                                            bABankTransferDetail.BudgetSubItemCode,
                                            bABankTransferDetail.MethodDistributeId, bABankTransferDetail.CashWithDrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region BABankTransferDetailParallel

                                            var bankTransferDetailParallel = new BABankTransferDetailParallelEntity
                                            {
                                                RefId = bABankTransfer.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = bABankTransferDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                //Amount = bABankTransferDetail.AmountOC * bABankTransfer.ExchangeRate,
                                                Amount = bABankTransferDetail.Amount,
                                                AmountOC = bABankTransferDetail.AmountOC,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    bABankTransferDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    bABankTransferDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    bABankTransferDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    bABankTransferDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    bABankTransferDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    bABankTransferDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    bABankTransferDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    bABankTransferDetail.CashWithDrawTypeId,
                                                AccountingObjectId = bABankTransferDetail.AccountingObjectId,
                                                ActivityId = bABankTransferDetail.ActivityId,
                                                ProjectId = bABankTransferDetail.ProjectId,
                                                ListItemId = bABankTransferDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = bABankTransferDetail.SortOrder,
                                                //OrgRefNo = bABankTransferDetail.OrgRefNo,
                                                //OrgRefDate = bABankTransferDetail.OrgRefDate,
                                                FundStructureId = bABankTransferDetail.FundStructureId,
                                                BudgetExpenseId = bABankTransferDetail.BudgetExpenseId,
                                                BankId = bABankTransferDetail.ToBankId
                                                //withDrawDetailParallel.BudgetExpenseId = receiptDetail.BudgetExpenseId;
                                                //withDrawDetailParallel.BudgetProvideCode = receiptDetail.BudgetProvideCode;
                                            };
                                            if (!bankTransferDetailParallel.Validate())
                                            {
                                                foreach (var error in bankTransferDetailParallel.ValidationErrors)
                                                    bABankTransferResponse.Message += error + Environment.NewLine;
                                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                return bABankTransferResponse;
                                            }
                                            bABankTransferResponse.Message =
                                                BABankTransferDetailParallelDao.InsertBABankTransferDetailParallel(
                                                    bankTransferDetailParallel);
                                            if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                            {
                                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                return bABankTransferResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (bankTransferDetailParallel.DebitAccount != null && bankTransferDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = bABankTransfer.RefType,
                                                    RefNo = bABankTransfer.RefNo,
                                                    AccountingObjectId = bankTransferDetailParallel.AccountingObjectId,
                                                    BankId = bankTransferDetailParallel.BankId,
                                                    BudgetChapterCode = bankTransferDetailParallel.BudgetChapterCode,
                                                    ProjectId = bankTransferDetailParallel.ProjectId,
                                                    BudgetSourceId = bankTransferDetailParallel.BudgetSourceId,
                                                    Description = bankTransferDetailParallel.Description,
                                                    RefDetailId = bankTransferDetailParallel.RefDetailId,
                                                    ExchangeRate = bABankTransfer.ExchangeRate,
                                                    ActivityId = bankTransferDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = bankTransferDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bABankTransfer.CurrencyCode,
                                                    BudgetKindItemCode = bankTransferDetailParallel.BudgetKindItemCode,
                                                    RefId = bABankTransfer.RefId,
                                                    PostedDate = bABankTransfer.PostedDate,
                                                    MethodDistributeId = bankTransferDetailParallel.MethodDistributeId,
                                                    //OrgRefNo = bABankTransferDetail.OrgRefNo,
                                                    //OrgRefDate = bABankTransferDetail.OrgRefDate,
                                                    BudgetItemCode = bankTransferDetailParallel.BudgetItemCode,
                                                    ListItemId = bankTransferDetailParallel.ListItemId,
                                                    BudgetSubItemCode = bankTransferDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = bankTransferDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = bankTransferDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber = bankTransferDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = bankTransferDetailParallel.CreditAccount,
                                                    //DebitAmount = bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                                    DebitAmount = bankTransferDetailParallel.Amount,
                                                    DebitAmountOC = bankTransferDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = bankTransferDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bABankTransfer.JournalMemo,
                                                    RefDate = bABankTransfer.RefDate,
                                                    BudgetExpenseId = bankTransferDetailParallel.BudgetExpenseId
                                                };
                                                bABankTransferResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                                {
                                                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return bABankTransferResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = bankTransferDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = bankTransferDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = bankTransferDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = bankTransferDetailParallel.AmountOC;
                                                bABankTransferResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                                {
                                                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return bABankTransferResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = bABankTransfer.RefType,
                                                    RefNo = bABankTransfer.RefNo,
                                                    AccountingObjectId = bankTransferDetailParallel.AccountingObjectId,
                                                    BankId = bankTransferDetailParallel.BankId,
                                                    BudgetChapterCode = bankTransferDetailParallel.BudgetChapterCode,
                                                    ProjectId = bankTransferDetailParallel.ProjectId,
                                                    BudgetSourceId = bankTransferDetailParallel.BudgetSourceId,
                                                    Description = bankTransferDetailParallel.Description,
                                                    RefDetailId = bankTransferDetailParallel.RefDetailId,
                                                    ExchangeRate = bABankTransfer.ExchangeRate,
                                                    ActivityId = bankTransferDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = bankTransferDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = bABankTransfer.CurrencyCode,
                                                    BudgetKindItemCode = bankTransferDetailParallel.BudgetKindItemCode,
                                                    RefId = bABankTransfer.RefId,
                                                    PostedDate = bABankTransfer.PostedDate,
                                                    MethodDistributeId = bankTransferDetailParallel.MethodDistributeId,
                                                    //OrgRefNo = bABankTransferDetail.OrgRefNo,
                                                    //OrgRefDate = bABankTransferDetail.OrgRefDate,
                                                    BudgetItemCode = bankTransferDetailParallel.BudgetItemCode,
                                                    ListItemId = bankTransferDetailParallel.ListItemId,
                                                    BudgetSubItemCode = bankTransferDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = bankTransferDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = bankTransferDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    bankTransferDetailParallel.DebitAccount ??
                                                    bankTransferDetailParallel.CreditAccount,
                                                    //DebitAmount =
                                                    //bankTransferDetailParallel.DebitAccount == null
                                                    //    ? 0
                                                    //    : bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                                    DebitAmount =
                                                    bankTransferDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : bankTransferDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    bankTransferDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : bankTransferDetailParallel.AmountOC,
                                                    //CreditAmount =
                                                    //bankTransferDetailParallel.CreditAccount == null
                                                    //    ? 0
                                                    //    : bankTransferDetailParallel.AmountOC * bABankTransfer.ExchangeRate,
                                                    CreditAmount =
                                                    bankTransferDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : bankTransferDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    bankTransferDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : bankTransferDetailParallel.AmountOC,
                                                    FundStructureId = bankTransferDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = bABankTransfer.JournalMemo,
                                                    RefDate = bABankTransfer.RefDate,
                                                    BudgetExpenseId = bankTransferDetailParallel.BudgetExpenseId
                                                };
                                                bABankTransferResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                                {
                                                    bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return bABankTransferResponse;
                                                }
                                            }


                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = bABankTransfer.RefType,
                                                RefId = bABankTransfer.RefId,
                                                RefDetailId = bABankTransferDetail.RefDetailId,
                                                //OrgRefDate = bABankTransferDetail.OrgRefDate,
                                                //OrgRefNo = bABankTransferDetail.OrgRefNo,
                                                RefDate = bABankTransfer.RefDate,
                                                RefNo = bABankTransfer.RefNo,
                                                AccountingObjectId = bABankTransferDetail.AccountingObjectId,
                                                ActivityId = bABankTransferDetail.ActivityId,
                                                Amount = bABankTransferDetail.Amount,
                                                AmountOC = bABankTransferDetail.AmountOC,
                                                //Approved = receiptDetail.Approved,
                                                BankId = bABankTransferDetail.FromBankId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    bABankTransferDetail.BudgetChapterCode,
                                                BudgetDetailItemCode = bABankTransferDetail.BudgetDetailItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    bABankTransferDetail.BudgetItemCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    bABankTransferDetail.BudgetKindItemCode,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    bABankTransferDetail.BudgetSourceId,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    bABankTransferDetail.BudgetSubItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    bABankTransferDetail.BudgetSubKindItemCode,
                                                CashWithDrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    bABankTransferDetail.CashWithDrawTypeId,
                                                CreditAccount = bankTransferDetailParallel.CreditAccount,
                                                DebitAccount = bankTransferDetailParallel.DebitAccount,
                                                Description = bABankTransferDetail.Description,
                                                FundStructureId = bABankTransferDetail.FundStructureId,
                                                //ProjectActivityId = withDrawDetailParallel.ProjectActivityId,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    bABankTransferDetail.MethodDistributeId,
                                                JournalMemo = bABankTransfer.JournalMemo,
                                                ProjectId = bABankTransferDetail.ProjectId,
                                                ToBankId = bABankTransferDetail.ToBankId,
                                                ExchangeRate = bABankTransfer.ExchangeRate,
                                                CurrencyCode = bABankTransfer.CurrencyCode,
                                                PostedDate = bABankTransfer.PostedDate,
                                            };
                                            bABankTransferResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                                            {
                                                bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                                                return bABankTransferResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }
                        }

                        #endregion

                        bABankTransferResponse.RefId = bABankTransfer.RefId;
                    }
                    if (bABankTransferResponse.Message != null)
                    {
                        bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bABankTransferResponse;
                    }
                    scope.Complete();
                }

                return bABankTransferResponse;
            }
            catch (Exception ex)
            {
                bABankTransferResponse.Message = ex.Message;
                return bABankTransferResponse;
            }
        }

        /// <summary>
        /// Deletes the ba bank transfer.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BABankTransferResponse.</returns>
        public BABankTransferResponse DeleteBABankTransfer(string refId)
        {
            var bABankTransferResponse = new BABankTransferResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                using (var scope = new TransactionScope())
                {
                    var receiptEntityForDelete = BABankTransferDao.GetBABankTransfer(refId);

                    #region Update account balance

                    // Cập nhật giá trị vào account balance trước khi xóa
                    bABankTransferResponse.Message = UpdateAccountBalance(receiptEntityForDelete);
                    if (bABankTransferResponse.Message != null)
                    {
                        bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bABankTransferResponse;
                    }

                    #endregion

                    bABankTransferResponse.Message = BABankTransferDao.DeleteBABankTransfer(receiptEntityForDelete);
                    if (bABankTransferResponse.Message != null)
                    {
                        bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bABankTransferResponse;
                    }
                    bABankTransferResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(receiptEntityForDelete.RefId);
                    if (bABankTransferResponse.Message != null)
                    {
                        bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bABankTransferResponse;
                    }

                    // Xóa bảng OriginalGeneralLedger
                    bABankTransferResponse.Message =
                        OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(receiptEntityForDelete.RefId);
                    if (bABankTransferResponse.Message != null)
                    {
                        bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return bABankTransferResponse;
                    }

                    // delete bang BAWithDrawDetailParallel
                    bABankTransferResponse.Message = BABankTransferDetailParallelDao.DeleteBABankTransferDetailParallelById(receiptEntityForDelete.RefId);
                    if (!string.IsNullOrEmpty(bABankTransferResponse.Message))
                    {
                        bABankTransferResponse.Acknowledge = AcknowledgeType.Failure;
                        return bABankTransferResponse;
                    }

                    scope.Complete();
                }

                return bABankTransferResponse;
            }
            catch (Exception ex)
            {
                bABankTransferResponse.Message = ex.Message;
                return bABankTransferResponse;
            }
        }

        #region Insert/Update AccountBalance Function

        /// <summary>
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="bABankTransferEntity">The b a bank transfer entity.</param>
        /// <param name="bABankTransferDetailEntity">The b a bank transfer detail entity.</param>
        /// <returns>AccountBalanceEntity.</returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(BABankTransferEntity bABankTransferEntity, BABankTransferDetailEntity bABankTransferDetailEntity)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = bABankTransferDetailEntity.DebitAccount,
                CurrencyCode = bABankTransferEntity.CurrencyCode,
                ExchangeRate = bABankTransferEntity.ExchangeRate,
                BalanceDate = bABankTransferEntity.PostedDate,
                MovementDebitAmountOC = bABankTransferDetailEntity.AmountOC,
                MovementDebitAmount = bABankTransferDetailEntity.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = bABankTransferDetailEntity.BudgetSourceId,
                BudgetChapterCode = bABankTransferDetailEntity.BudgetChapterCode,
                BudgetKindItemCode = bABankTransferDetailEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = bABankTransferDetailEntity.BudgetSubKindItemCode,
                BudgetItemCode = bABankTransferDetailEntity.BudgetItemCode,
                BudgetSubItemCode = bABankTransferDetailEntity.BudgetSubItemCode,
                MethodDistributeId = bABankTransferDetailEntity.MethodDistributeId,
                //  AccountingObjectId = bABankTransferEntity.AccountingObjectId,
                ActivityId = bABankTransferDetailEntity.ActivityId,
                ProjectId = bABankTransferDetailEntity.ProjectId,
                // BankAccount = bABankTransferDetailEntity.BankId,
                FundStructureId = bABankTransferDetailEntity.FundStructureId,
                ProjectActivityId = bABankTransferDetailEntity.ProjectActivityId,
                BudgetDetailItemCode = bABankTransferDetailEntity.BudgetDetailItemCode
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="bABankTransferEntity">The b a bank transfer entity.</param>
        /// <param name="bABankTransferDetailEntity">The b a bank transfer detail entity.</param>
        /// <returns>AccountBalanceEntity.</returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(BABankTransferEntity bABankTransferEntity, BABankTransferDetailEntity bABankTransferDetailEntity)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = bABankTransferDetailEntity.CreditAccount,
                CurrencyCode = bABankTransferEntity.CurrencyCode,
                ExchangeRate = bABankTransferEntity.ExchangeRate,
                BalanceDate = bABankTransferEntity.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = bABankTransferDetailEntity.AmountOC,
                MovementCreditAmount = bABankTransferDetailEntity.Amount,
                BudgetSourceId = bABankTransferDetailEntity.BudgetSourceId,
                BudgetChapterCode = bABankTransferDetailEntity.BudgetChapterCode,
                BudgetKindItemCode = bABankTransferDetailEntity.BudgetKindItemCode,
                BudgetSubKindItemCode = bABankTransferDetailEntity.BudgetSubKindItemCode,
                BudgetItemCode = bABankTransferDetailEntity.BudgetItemCode,
                BudgetSubItemCode = bABankTransferDetailEntity.BudgetSubItemCode,
                MethodDistributeId = bABankTransferDetailEntity.MethodDistributeId,
                // AccountingObjectId = bABankTransferEntity.AccountingObjectId,
                ActivityId = bABankTransferDetailEntity.ActivityId,
                ProjectId = bABankTransferDetailEntity.ProjectId,
                //    BankAccount = bABankTransferEntity.BankId,
                FundStructureId = bABankTransferDetailEntity.FundStructureId,
                ProjectActivityId = bABankTransferDetailEntity.ProjectActivityId,
                BudgetDetailItemCode = bABankTransferDetailEntity.BudgetDetailItemCode
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
        /// <param name="bABankTransferEntity">The b a bank transfer entity.</param>
        /// <returns>System.String.</returns>
        public string UpdateAccountBalance(BABankTransferEntity bABankTransferEntity)
        {
            var paymentDetails = BABankTransferDetailDao.GetBABankTransferDetailsByRefId(bABankTransferEntity.RefId).ToList();
            foreach (var paymentDetail in paymentDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(bABankTransferEntity, paymentDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(bABankTransferEntity, paymentDetail);
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
        /// <param name="bABankTransferEntity">The b a bank transfer entity.</param>
        /// <param name="bABankTransferDetailEntity">The b a bank transfer detail entity.</param>
        public void InsertAccountBalance(BABankTransferEntity bABankTransferEntity, BABankTransferDetailEntity bABankTransferDetailEntity)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(bABankTransferEntity, bABankTransferDetailEntity);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(bABankTransferEntity, bABankTransferDetailEntity);
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
