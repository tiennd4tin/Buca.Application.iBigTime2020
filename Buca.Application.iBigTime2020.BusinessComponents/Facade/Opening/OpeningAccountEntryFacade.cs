/***********************************************************************
 * <copyright file="OpeningAccountEntryFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using System.Linq;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Opening;


namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Opening
{
    /// <summary>
    /// OpeningAccountEntryFacade
    /// </summary>
    public class OpeningAccountEntryFacade
    {
        private static readonly IOpeningAccountEntryDao OpeningAccountEntryDao = DataAccess.DataAccess.OpeningAccountEntryDao;
        //private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;
        private static readonly IGeneralLedgerDao JournalEntryAccountDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IAccountDao AccountDao = DataAccess.DataAccess.AccountDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;

        public List<OpeningAccountEntryEntity> GetOpeningAccountEntries()
        {
            return OpeningAccountEntryDao.GetOpeningAccountEntries();
        }
        public List<OpeningAccountEntryEntity> GetOpeningAccountEntriesConvert()
        {
            return OpeningAccountEntryDao.GetOpeningAccountEntriesConvert();
        }

        public List<OpeningAccountEntryEntity> GetOpeningAccountEntriesByAccountNumber(string accountNumber)
        {
            return OpeningAccountEntryDao.GetOpeningAccountEntriesByAccountNumber(accountNumber);
        }

        public OpeningAccountEntryReponse UpdateOpeningAccountEntry(
            IList<OpeningAccountEntryEntity> openingAccountEntryDetails)
        {
            var openingAccountEntryResponse = new OpeningAccountEntryReponse { Acknowledge = AcknowledgeType.Success };
            try
            {

                using (var scope = new TransactionScope())
                {
                    if (openingAccountEntryDetails != null && openingAccountEntryDetails.Count>0)
                    {
                        openingAccountEntryResponse.Message =
                            OpeningAccountEntryDao.DeleteOpeningAccountEntryByAccountNumber(
                                openingAccountEntryDetails.First().AccountNumber);

                        // Xóa bảng GeneralLedger
                        openingAccountEntryResponse.Message =
                            //GeneralLedgerDao.DeleteGeneralLedger(openingAccountEntry.AccountNumber, openingAccountEntry.RefType);
                            GeneralLedgerDao.DeleteGeneralLedger(openingAccountEntryDetails.First().AccountNumber,
                                openingAccountEntryDetails.First().RefType);
                        if (openingAccountEntryResponse.Message != null)
                        {
                            openingAccountEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return openingAccountEntryResponse;
                        }
                        foreach (var openingAccountEntry in openingAccountEntryDetails)
                        {
                            openingAccountEntry.RefId = Guid.NewGuid().ToString();
                            openingAccountEntry.BudgetChapterCode =  openingAccountEntry.BudgetChapterCode == null ? null : openingAccountEntry.BudgetChapterCode;

                            if (!openingAccountEntry.Validate())
                            {
                                foreach (string error in openingAccountEntry.ValidationErrors)
                                    openingAccountEntryResponse.Message += error + Environment.NewLine;
                                openingAccountEntryResponse.Acknowledge = AcknowledgeType.Failure;
                                return openingAccountEntryResponse;
                            }
                            openingAccountEntryResponse.Message =
                                OpeningAccountEntryDao.InsertOpeningAccountEntry(openingAccountEntry);
                            if (!string.IsNullOrEmpty(openingAccountEntryResponse.Message))
                            {
                                openingAccountEntryResponse.Acknowledge = AcknowledgeType.Failure;
                                return openingAccountEntryResponse;
                            }

                            #region Insert Ledger

                            // Insert số tiền theo tính chất của tài khoản
                            // Nếu tài khoản có tính chất dư nợ: Insert số tiền vào cột DebitAmount
                            // Nếu tài khoản có tính chất dư có: Insert số tiền vào cột CreditAmount

                            var account = AccountDao.GetAccountByAccountNumber(openingAccountEntry.AccountNumber);

                            var accountCategoryKind = account.AccountCategoryKind;

                            // insert bang GeneralLedger

                            if (openingAccountEntry.AccountNumber != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = openingAccountEntry.RefType,
                                    RefNo = "OPN",
                                    CurrencyCode = String.IsNullOrEmpty(openingAccountEntry.CurrencyCode)? "VND" :openingAccountEntry.CurrencyCode,
                                    ExchangeRate = openingAccountEntry.ExchangeRate,
                                    AccountingObjectId = openingAccountEntry.AccountingObjectId,
                                    BudgetChapterCode = openingAccountEntry.BudgetChapterCode,
                                    ProjectId = openingAccountEntry.ProjectId,
                                    BudgetSourceId = openingAccountEntry.BudgetSourceId,
                                    RefDetailId = openingAccountEntry.RefId,
                                    ActivityId = openingAccountEntry.ActivityId,
                                    BudgetSubKindItemCode = openingAccountEntry.BudgetSubKindItemCode,
                                    BudgetKindItemCode = openingAccountEntry.BudgetKindItemCode,
                                    RefId = openingAccountEntry.RefId,
                                    PostedDate = openingAccountEntry.PostedDate,
                                    MethodDistributeId = openingAccountEntry.MethodDistributeId,
                                    BudgetItemCode = openingAccountEntry.BudgetItemCode,
                                    BudgetSubItemCode = openingAccountEntry.BudgetSubItemCode,
                                    BudgetDetailItemCode = openingAccountEntry.BudgetDetailItemCode,
                                    CashWithDrawTypeId = openingAccountEntry.CashWithdrawTypeId,
                                    AccountNumber = openingAccountEntry.AccountNumber,
                                    DebitAmount = openingAccountEntry.DebitAmount,
                                    DebitAmountOC = openingAccountEntry.DebitAmountOC,
                                    CreditAmount = openingAccountEntry.CreditAmount,
                                    CreditAmountOC = openingAccountEntry.CreditAmountOC,
                                    FundStructureId = openingAccountEntry.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    RefDate = openingAccountEntry.PostedDate,
                                    BudgetExpenseId = openingAccountEntry.BudgetExpenseId,
                                    BankId = openingAccountEntry.BankId,
                                    ContractId = openingAccountEntry.ContractId,
                                    CapitalPlanId = openingAccountEntry.CapitalPlanId
                                };
                                openingAccountEntryResponse.Message =
                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(openingAccountEntryResponse.Message))
                                {
                                    openingAccountEntryResponse.Acknowledge = AcknowledgeType.Failure;
                                    return openingAccountEntryResponse;
                                }

                                #endregion

                            #region Insert OriginalGeneralLedger

                                // Tạm thời chưa dùng đến đoạn insert vào bảng này

                                //var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                //{
                                //    OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                //    RefType = openingAccountEntry.RefType,
                                //    RefId = openingAccountEntry.RefId,
                                //    CurrencyCode = openingAccountEntry.CurrencyId,
                                //    ExchangeRate = openingAccountEntry.ExchangeRate,
                                //    RefDetailId = openingAccountEntry.RefId,
                                //    RefDate = openingAccountEntry.PostedDate,
                                //    RefNo = "OPN",
                                //    AccountingObjectId = openingAccountEntry.AccountingObjectId,
                                //    ActivityId = openingAccountEntry.ActivityId,
                                //    Amount = openingAccountEntry.DebitAmount,
                                //    AmountOC = openingAccountEntry.DebitAmountOC,
                                //    Approved = openingAccountEntry.Approved,
                                //    BudgetChapterCode = openingAccountEntry.BudgetChapterCode,
                                //    BudgetDetailItemCode = openingAccountEntry.BudgetDetailItemCode,
                                //    BudgetItemCode = openingAccountEntry.BudgetItemCode,
                                //    BudgetKindItemCode = openingAccountEntry.BudgetKindItemCode,
                                //    BudgetSourceId = openingAccountEntry.BudgetSourceId,
                                //    BudgetSubItemCode = openingAccountEntry.BudgetSubItemCode,
                                //    BudgetSubKindItemCode = openingAccountEntry.BudgetSubKindItemCode,
                                //    CashWithDrawTypeId = openingAccountEntry.CashWithdrawTypeId,
                                //    DebitAccount = openingAccountEntry.AccountNumber,
                                //    FundStructureId = openingAccountEntry.FundStructureId,
                                //    ProjectActivityId = openingAccountEntry.ProjectActivityId,
                                //    MethodDistributeId = openingAccountEntry.MethodDistributeId,
                                //    ProjectId = openingAccountEntry.ProjectId,
                                //    PostedDate = openingAccountEntry.PostedDate,
                                //};
                                //openingAccountEntryResponse.Message =
                                //    OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                //if (!string.IsNullOrEmpty(openingAccountEntryResponse.Message))
                                //{
                                //    openingAccountEntryResponse.Acknowledge = AcknowledgeType.Failure;
                                //    return openingAccountEntryResponse;
                                //}

                                #endregion

                            }

                            openingAccountEntryResponse.RefId = openingAccountEntryDetails.First().RefId;
                        }
                        scope.Complete();
                    }
                }
                return openingAccountEntryResponse;
            }

            catch (Exception ex)
            {
                openingAccountEntryResponse.Message = ex.Message;
                return openingAccountEntryResponse;
            }
        }

        public OpeningAccountEntryReponse DeleteOpeningAccountEntry(string accountNumber)
        {
            var openingAccountEntryResponse = new OpeningAccountEntryReponse { Acknowledge = AcknowledgeType.Success };
            try
            {

                using (var scope = new TransactionScope())
                {
                    var openingAccountEntryDelete =
                        OpeningAccountEntryDao.GetOpeningAccountEntriesByAccountNumber(accountNumber);

                    //.Xóa bảng OpeningAccountEntry
                    openingAccountEntryResponse.Message =
                        OpeningAccountEntryDao.DeleteOpeningAccountEntryByAccountNumber(accountNumber);
                    if (openingAccountEntryResponse.Message != null)
                    {
                        openingAccountEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingAccountEntryResponse;
                    }
                    //.Xóa bảng GeneralLedger
                    openingAccountEntryResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(accountNumber, (int)BuCA.Enum.RefType.OpeningAccountEntry);
                    if (openingAccountEntryResponse.Message != null)
                    {
                        openingAccountEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingAccountEntryResponse;
                    }
                    if (openingAccountEntryDelete == null || openingAccountEntryDelete.Count <=0)
                        openingAccountEntryResponse.RefId = "0";
                    else
                        openingAccountEntryResponse.RefId = openingAccountEntryDelete.First().RefId;
                    
                    scope.Complete();
                }
                return openingAccountEntryResponse;
            }

            catch (Exception ex)
            {
                openingAccountEntryResponse.Message = ex.Message;
                return openingAccountEntryResponse;
            }
        }

        public OpeningAccountEntryReponse DeleteOpeningAccountEntryConvert(string accountNumber,int refType)
        {
            var openingAccountEntryResponse = new OpeningAccountEntryReponse { Acknowledge = AcknowledgeType.Success };
            try
            {

                using (var scope = new TransactionScope())
                {
                    var openingAccountEntryDelete =
                        OpeningAccountEntryDao.GetOpeningAccountEntriesByAccountNumber(accountNumber);

                    //.Xóa bảng OpeningAccountEntry
                    openingAccountEntryResponse.Message =
                        OpeningAccountEntryDao.DeleteOpeningAccountEntryByAccountNumber(accountNumber);
                    if (openingAccountEntryResponse.Message != null)
                    {
                        openingAccountEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingAccountEntryResponse;
                    }
                    //.Xóa bảng GeneralLedger
                    openingAccountEntryResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(accountNumber, refType);
                    if (openingAccountEntryResponse.Message != null)
                    {
                        openingAccountEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingAccountEntryResponse;
                    }
                    if (openingAccountEntryDelete == null || openingAccountEntryDelete.Count <= 0)
                        openingAccountEntryResponse.RefId = "0";
                    else
                        openingAccountEntryResponse.RefId = openingAccountEntryDelete.First().RefId;

                    scope.Complete();
                }
                return openingAccountEntryResponse;
            }

            catch (Exception ex)
            {
                openingAccountEntryResponse.Message = ex.Message;
                return openingAccountEntryResponse;
            }
        }

        //#region private function

        ///// <summary>
        ///// Adds the journal entry account.
        ///// </summary>
        ///// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        ///// <param name="openingAccountEntryDetailEntity">The opening account entry detail entity.</param>
        ///// <param name="balanceSide">The balance side.</param>
        ///// <returns></returns>
        //public JournalEntryAccountEntity AddJournalEntryAccount(OpeningAccountEntryEntity openingAccountEntryEntity,
        //    OpeningAccountEntryDetailEntity openingAccountEntryDetailEntity, int balanceSide)
        //{
        //    decimal amountOC;
        //    decimal amountExchange;
        //    int journalType;
        //    switch (balanceSide)
        //    {
        //        case 0:
        //            amountOC = openingAccountEntryDetailEntity.DebitAmountOC;
        //            amountExchange = openingAccountEntryDetailEntity.DebitAmountExchange;
        //            journalType = 1;
        //            break;
        //        case 1:
        //            amountOC = openingAccountEntryDetailEntity.CreditAmountOC * (-1);
        //            amountExchange = openingAccountEntryDetailEntity.CreditAmountExchange  * (-1);
        //            journalType = 2;
        //            break;
        //        default:
        //            if (openingAccountEntryDetailEntity.DebitAmountOC > openingAccountEntryDetailEntity.CreditAmountOC)
        //            {
        //                amountOC = Math.Abs(openingAccountEntryDetailEntity.DebitAmountOC - openingAccountEntryDetailEntity.CreditAmountOC);
        //                amountExchange = Math.Abs(openingAccountEntryDetailEntity.DebitAmountExchange - openingAccountEntryDetailEntity.CreditAmountExchange);
        //                journalType = 1;
        //            }
        //            else
        //            {
        //                amountOC = openingAccountEntryDetailEntity.DebitAmountOC - openingAccountEntryDetailEntity.CreditAmountOC;
        //                amountExchange = openingAccountEntryDetailEntity.DebitAmountExchange - openingAccountEntryDetailEntity.CreditAmountExchange;
        //                journalType = 2;
        //            }
        //            break;
        //    }
        //    return new JournalEntryAccountEntity
        //    {
        //        RefId = openingAccountEntryEntity.RefId,
        //        RefTypeId = openingAccountEntryEntity.RefType,
        //        RefNo = "OPN",
        //        RefDate = openingAccountEntryEntity.PostedDate,
        //        PostedDate = openingAccountEntryEntity.PostedDate,
        //        JournalMemo = null,
        //        CurrencyCode = openingAccountEntryDetailEntity.CurrencyCode,
        //        ExchangeRate = (decimal)openingAccountEntryDetailEntity.ExchangeRate,
        //        BankAccount = null,
        //        RefDetailId = openingAccountEntryDetailEntity.RefDetailId,
        //        AccountNumber = openingAccountEntryEntity.AccountCode,
        //        CorrespondingAccountNumber = null,
        //        AmountOc = amountOC,
        //        BankId = openingAccountEntryDetailEntity.BankId,
        //        Description = null,
        //        JournalType = journalType,
        //        AmountExchange = amountExchange,
        //        BudgetSourceCode = openingAccountEntryDetailEntity.BudgetSourceCode,
        //        BudgetItemCode = openingAccountEntryDetailEntity.BudgetItemCode,
        //        AccountingObjectId = openingAccountEntryDetailEntity.AccountingObjectId,
        //        EmployeeId = openingAccountEntryDetailEntity.EmployeeId,
        //        CustomerId = openingAccountEntryDetailEntity.CustomerId,
        //        VendorId = openingAccountEntryDetailEntity.VendorId,
        //        MergerFundId = openingAccountEntryDetailEntity.MergerFundId,
        //        VoucherTypeId = null,
        //        ProjectId = openingAccountEntryDetailEntity.ProjectId
        //    };
        //}

        ///// <summary>
        ///// Inserts the account balance.
        ///// </summary>
        ///// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        ///// <param name="openingAccountEntryDetailEntity">The opening account entry detail entity.</param>
        ///// <param name="balanceSide">The balance side.</param>
        //public void InsertAccountBalance(OpeningAccountEntryEntity openingAccountEntryEntity, OpeningAccountEntryDetailEntity openingAccountEntryDetailEntity,
        //    int balanceSide)
        //{
        //    //check balance side

        //    switch (balanceSide)
        //    {
        //        case 0: //ben no
        //            var accountBalanceForDebit = AddAccountBalanceForDebit(openingAccountEntryEntity, openingAccountEntryDetailEntity);
        //            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
        //            if (accountBalanceForDebitExit != null)
        //                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
        //                    accountBalanceForDebit.MovementDebitAmountExchange, true, 1);
        //            else
        //                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);
        //            break;
        //        case 1: //ben co
        //            var accountBalanceForCredit = AddAccountBalanceForCredit(openingAccountEntryEntity, openingAccountEntryDetailEntity);
        //            var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
        //            if (accountBalanceForCreditExit != null)
        //                UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
        //                    accountBalanceForCredit.MovementCreditAmountExchange, true, 2);
        //            else
        //                AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
        //            break;
        //        case 2:
        //            if (openingAccountEntryDetailEntity.DebitAmountOC == 0)
        //            {
        //                accountBalanceForCredit = AddAccountBalanceForCredit(openingAccountEntryEntity, openingAccountEntryDetailEntity);
        //                accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
        //                if (accountBalanceForCreditExit != null)
        //                    UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
        //                        accountBalanceForCredit.MovementCreditAmountExchange, true, 2);
        //                else
        //                    AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
        //            }
        //            else
        //            {
        //                accountBalanceForDebit = AddAccountBalanceForDebit(openingAccountEntryEntity, openingAccountEntryDetailEntity);
        //                accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
        //                if (accountBalanceForDebitExit != null)
        //                    UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
        //                        accountBalanceForDebit.MovementDebitAmountExchange, true, 1);
        //                else
        //                    AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);
        //            }
        //            break; //luong tinh
        //    }
        //}

        ///// <summary>
        ///// Updates the account balance.
        ///// </summary>
        ///// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        ///// <param name="balanceSide">The balance side.</param>
        ///// <returns></returns>
        //public string UpdateAccountBalance(OpeningAccountEntryEntity openingAccountEntryEntity, int balanceSide)
        //{
        //    var openingAccountEntryDetails = OpeningAccountEntryDetailDao.GetOpeningAccountEntryDetailsByRefId(openingAccountEntryEntity.RefId);
        //    foreach (var openingAccountEntryDetail in openingAccountEntryDetails)
        //    {
        //        string message;
        //        switch (balanceSide)
        //        {
        //            case 0:
        //                var accountBalanceForDebit = AddAccountBalanceForDebit(openingAccountEntryEntity, openingAccountEntryDetail);
        //                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
        //                if (accountBalanceForDebitExit != null)
        //                {
        //                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
        //                        accountBalanceForDebit.MovementDebitAmountExchange, false, 1);
        //                    if (message != null) return message;
        //                }
        //                break;
        //            case 1:
        //                var accountBalanceForCredit = AddAccountBalanceForCredit(openingAccountEntryEntity, openingAccountEntryDetail);
        //                var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
        //                if (accountBalanceForCreditExit != null)
        //                {
        //                    message = UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
        //                        accountBalanceForCredit.MovementCreditAmountExchange, false, 2);
        //                    if (message != null) return message;
        //                }
        //                break;
        //            case 2:
        //                break;
        //        }
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Adds the account balance for debit.
        ///// </summary>
        ///// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        ///// <param name="openingAccountEntryDetailEntity">The opening account entry detail entity.</param>
        ///// <returns></returns>
        //public AccountBalanceEntity AddAccountBalanceForDebit(OpeningAccountEntryEntity openingAccountEntryEntity,
        //    OpeningAccountEntryDetailEntity openingAccountEntryDetailEntity)
        //{
        //    return new AccountBalanceEntity
        //    {
        //        BalanceDate = openingAccountEntryEntity.PostedDate,
        //        CurrencyCode = openingAccountEntryDetailEntity.CurrencyCode,
        //        ExchangeRate = (decimal)openingAccountEntryDetailEntity.ExchangeRate,
        //        AccountNumber = openingAccountEntryEntity.AccountCode,
        //        MovementDebitAmountOC = openingAccountEntryDetailEntity.DebitAmountOC,
        //        MovementDebitAmountExchange = openingAccountEntryDetailEntity.DebitAmountExchange,
        //        BudgetSourceCode = openingAccountEntryDetailEntity.BudgetSourceCode,
        //        BudgetItemCode = openingAccountEntryDetailEntity.BudgetItemCode,
        //        CustomerId = openingAccountEntryDetailEntity.CustomerId,
        //        VendorId = openingAccountEntryDetailEntity.VendorId,
        //        EmployeeId = openingAccountEntryDetailEntity.EmployeeId,
        //        AccountingObjectId = openingAccountEntryDetailEntity.AccountingObjectId,
        //        MergerFundId = openingAccountEntryDetailEntity.MergerFundId,
        //        BankId = openingAccountEntryDetailEntity.BankId,
        //        ProjectId = openingAccountEntryDetailEntity.ProjectId,
        //        //InventoryItemId = openingAccountEntryDetailEntityy.InventoryItemId,
        //        MovementCreditAmountOC = 0,
        //        MovementCreditAmountExchange = 0
        //    };
        //}

        ///// <summary>
        ///// Updates the account balance.
        ///// </summary>
        ///// <param name="accountBalanceEntity">The account balance entity.</param>
        ///// <param name="movementAmount">The movement amount.</param>
        ///// <param name="movementAmountExchange">The movement amount exchange.</param>
        ///// <param name="isMovementAmount">if set to <c>true</c> [is movement amount].</param>
        ///// <param name="balanceSide">The balance side.</param>
        ///// <returns></returns>
        //public string UpdateAccountBalance(AccountBalanceEntity accountBalanceEntity, decimal movementAmount, decimal movementAmountExchange,
        //    bool isMovementAmount, int balanceSide)
        //{
        //    string message;
        //    // cập nhật bên TK nợ
        //    if (balanceSide == 1)
        //    {
        //        accountBalanceEntity.ExchangeRate = accountBalanceEntity.ExchangeRate;
        //        if (isMovementAmount)
        //        {
        //            accountBalanceEntity.MovementDebitAmountExchange = accountBalanceEntity.MovementDebitAmountExchange + movementAmountExchange;
        //            accountBalanceEntity.MovementDebitAmountOC = accountBalanceEntity.MovementDebitAmountOC + movementAmount;
        //        }
        //        else
        //        {
        //            accountBalanceEntity.MovementDebitAmountExchange = accountBalanceEntity.MovementDebitAmountExchange - movementAmountExchange;
        //            accountBalanceEntity.MovementDebitAmountOC = accountBalanceEntity.MovementDebitAmountOC - movementAmount;
        //        }
        //        message = AccountBalanceDao.UpdateAccountBalance(accountBalanceEntity);
        //        if (message != null)
        //            return message;
        //    }
        //    else
        //    {
        //        accountBalanceEntity.ExchangeRate = accountBalanceEntity.ExchangeRate;
        //        if (isMovementAmount)
        //        {
        //            accountBalanceEntity.MovementCreditAmountExchange = accountBalanceEntity.MovementCreditAmountExchange + movementAmountExchange;
        //            accountBalanceEntity.MovementCreditAmountOC = accountBalanceEntity.MovementCreditAmountOC + movementAmount;
        //        }
        //        else
        //        {
        //            accountBalanceEntity.MovementCreditAmountExchange = accountBalanceEntity.MovementCreditAmountExchange - movementAmountExchange;
        //            accountBalanceEntity.MovementCreditAmountOC = accountBalanceEntity.MovementCreditAmountOC - movementAmount;
        //        }
        //        message = AccountBalanceDao.UpdateAccountBalance(accountBalanceEntity);
        //        if (message != null)
        //            return message;
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Adds the account balance for credit.
        ///// </summary>
        ///// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        ///// <param name="openingAccountEntryDetailEntityy">The opening account entry detail entityy.</param>
        ///// <returns></returns>
        //public AccountBalanceEntity AddAccountBalanceForCredit(OpeningAccountEntryEntity openingAccountEntryEntity,
        //    OpeningAccountEntryDetailEntity openingAccountEntryDetailEntityy)
        //{
        //    //credit account
        //    return new AccountBalanceEntity
        //    {
        //        BalanceDate = openingAccountEntryEntity.PostedDate,
        //        CurrencyCode = openingAccountEntryDetailEntityy.CurrencyCode,
        //        ExchangeRate = (decimal)openingAccountEntryDetailEntityy.ExchangeRate,
        //        AccountNumber = openingAccountEntryEntity.AccountCode,
        //        MovementCreditAmountOC = openingAccountEntryDetailEntityy.CreditAmountOC,
        //        MovementCreditAmountExchange = openingAccountEntryDetailEntityy.CreditAmountExchange,
        //        BudgetSourceCode = openingAccountEntryDetailEntityy.BudgetSourceCode,
        //        BudgetItemCode = openingAccountEntryDetailEntityy.BudgetItemCode,
        //        CustomerId = openingAccountEntryDetailEntityy.CustomerId,
        //        VendorId = openingAccountEntryDetailEntityy.VendorId,
        //        EmployeeId = openingAccountEntryDetailEntityy.EmployeeId,
        //        AccountingObjectId = openingAccountEntryDetailEntityy.AccountingObjectId,
        //        MergerFundId = openingAccountEntryDetailEntityy.MergerFundId,
        //        BankId = openingAccountEntryDetailEntityy.BankId,
        //        ProjectId = openingAccountEntryDetailEntityy.ProjectId,
        //        //InventoryItemId = openingAccountEntryDetailEntityy.InventoryItemId,
        //        MovementDebitAmountOC = 0,
        //        MovementDebitAmountExchange = 0
        //    };
        //}

        //#endregion
    }
}