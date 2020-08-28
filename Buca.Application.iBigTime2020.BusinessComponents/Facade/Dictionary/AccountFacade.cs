/***********************************************************************
 * <copyright file="AccountFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
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


namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class AccountFacade.
    /// </summary>
    public class AccountFacade
    {
        /// <summary>
        /// The account DAO
        /// </summary>
        private static readonly IAccountDao AccountDao = DataAccess.DataAccess.AccountDao;

        public List<AccountEntity> GetAccounts()
        {
            return AccountDao.GetAccounts();
        }

        public List<AccountEntity> GetAccountByIsActive(bool isActive)
        {
            return AccountDao.GetAccountsActive(isActive);
        }

        public List<AccountEntity> GetAccountsIsDetail(bool isDetail)
        {
            return AccountDao.GetAccountsIsDetail(isDetail);
        }

        public List<AccountEntity> GetAccountsForComboTree(string accountId)
        {
            return AccountDao.GetAccountsForComboTree(accountId);
        }

        public AccountEntity GetAccountbyAccountNumber(string accountNumber)
        {
            return AccountDao.GetAccountByAccountNumber(accountNumber);
        }

        public AccountEntity GetAccountById(string accountId)
        {
            return AccountDao.GetAccount(accountId);
        }

        public AccountResponse InsertAccount(AccountEntity accountEntity)
        {
            var response = new AccountResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                if (!accountEntity.Validate())
                {
                    foreach (string error in accountEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                accountEntity.AccountNumber = accountEntity.AccountNumber.Trim();

                var acount = AccountDao.GetAccountByAccountNumber(accountEntity.AccountNumber);
                if (acount != null && !string.IsNullOrEmpty(acount.AccountNumber))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã tài khoản " + acount.AccountNumber + @" đã tồn tại !";
                    return response;
                }

                accountEntity.AccountId = Guid.NewGuid().ToString();
                accountEntity.AccountId = AccountDao.InsertAccount(accountEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountId = accountEntity.AccountId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public AccountResponse InsertConvertAccount(AccountEntity accountEntity)
        {
            var response = new AccountResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!accountEntity.Validate())
                {
                    foreach (string error in accountEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                accountEntity.AccountNumber = accountEntity.AccountNumber.Trim();

                var acount = AccountDao.GetAccountByAccountNumber(accountEntity.AccountNumber);
                if (acount != null && !string.IsNullOrEmpty(acount.AccountNumber))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã tài khoản " + acount.AccountNumber + @" đã tồn tại !";
                    return response;
                }

                accountEntity.AccountId = AccountDao.InsertAccount(accountEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountId = accountEntity.AccountId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        public AccountResponse UpdateAccount(AccountEntity accountEntity)
        {
            var response = new AccountResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                if (!accountEntity.Validate())
                {
                    foreach (string error in accountEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var acount = AccountDao.GetAccountByAccountNumber(accountEntity.AccountNumber);
                if (acount != null && !string.IsNullOrEmpty(acount.AccountNumber))
                {
                    if (!acount.AccountId.Equals(accountEntity.AccountId))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã tài khoản " + acount.AccountNumber + @" đã tồn tại !";
                        return response;
                    }
                }

                response.Message = AccountDao.UpdateAccount(accountEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountId = accountEntity.AccountId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public AccountResponse DeleteAccount(string accountId)
        {
            var response = new AccountResponse {Acknowledge = AcknowledgeType.Success};
            try
            {
                var accountEntity = AccountDao.GetAccount(accountId);
                response.Message = AccountDao.DeleteAccount(accountEntity);
                //if (!string.IsNullOrEmpty(response.Message))
                //{
                //    response.Acknowledge = AcknowledgeType.Failure;
                //    return response;
                //}

                if (!string.IsNullOrEmpty(response.Message))
                {
                    if (response.Message.Contains("FK_FAIncrementDecrementDetail_Account") ||
                        response.Message.Contains("FK_FAIncrementDecrementDetail_Account1") ||
                        response.Message.Contains("FK_CAReceiptDetailParallel_Account") ||
                        response.Message.Contains("FK_CAReceiptDetailParallel_Account1") ||
                        response.Message.Contains("FK_BAWithDrawDetail_Account") ||
                        response.Message.Contains("FK_BAWithDrawDetail_Account1") ||
                        response.Message.Contains("FK_BADepositDetailFixedAsset_Account") ||
                        response.Message.Contains("FK_BADepositDetailFixedAsset_Account1") ||
                        response.Message.Contains("FK_BUTransferDetail_Account") ||
                        response.Message.Contains("FK_BUTransferDetail_Account1") ||
                        response.Message.Contains("FK_BUTransferDetail_Account2") ||
                        response.Message.Contains("FK_CAReceiptDetail_Account") ||
                        response.Message.Contains("FK_GLVoucherDetailParallel_Account_CreditAccount") ||
                        response.Message.Contains("FK_BABankTransferDetail_Account") ||
                        response.Message.Contains("FK_CAReceiptDetail_Account1") ||
                        response.Message.Contains("FK_GLVoucherDetailParallel_Account_DebitAccount") ||
                        response.Message.Contains("FK_BABankTransferDetail_Account1") ||
                        response.Message.Contains("FK_CAPaymentDetailPurchase_Account") ||
                        response.Message.Contains("FK_CAPaymentDetailPurchase_Account1") ||
                        response.Message.Contains("FK_CAReceiptDetailFixedAsset_Account") ||
                        response.Message.Contains("FK_CAReceiptDetailFixedAsset_Account1") ||
                        response.Message.Contains("FK_BAWithDrawDetailFixedAsset_Account") ||
                        response.Message.Contains("FK_BUPlanReceiptDetail_Account") ||
                        response.Message.Contains("FK_BAWithDrawDetailFixedAsset_Account1") ||
                        response.Message.Contains("FK_BADepositDetailSale_Account") ||
                        response.Message.Contains("FK_BADepositDetailSale_Account1") ||
                        response.Message.Contains("FK_BAWithDrawDetailParallel_Account_CreditAccount") ||
                        response.Message.Contains("FK_BAWithDrawDetailParallel_Account_DebitAccount") ||
                        response.Message.Contains("FK_BABankTransferDetailParallel_Account_CreditAccount") ||
                        response.Message.Contains("FK_BABankTransferDetailParallel_Account_DebitAccount") ||
                        response.Message.Contains("FK_CAPaymentDetail_DebitAccount") ||
                        response.Message.Contains("FK_CAPaymentDetail_Account") ||
                        response.Message.Contains("FK_BUTransferDetailPurchase_Account") ||
                        response.Message.Contains("FK_CAPaymentDetailFixedAsset_Account") ||
                        response.Message.Contains("FK_BUTransferDetailPurchase_Account1") ||
                        response.Message.Contains("FK_CAPaymentDetailFixedAsset_Account1") ||
                        response.Message.Contains("FK_BUTransferDetailPurchase_Account2") ||
                        response.Message.Contains("FK_BADepositDetail_Account") ||
                        response.Message.Contains("FK_BADepositDetail_Account1") ||
                        response.Message.Contains("FK_BUTransferDetailParallel_Account_CreditAccount") ||
                        response.Message.Contains("FK_FADepreciationDetail_Account") ||
                        response.Message.Contains("FK_BUPlanAdjustmentDetail_Account") ||
                        response.Message.Contains("FK_BUTransferDetailParallel_Account_DebitAccount") ||
                        response.Message.Contains("FK_FADepreciationDetail_Account1") ||
                        response.Message.Contains("FK_BAWithDrawDetailPurchase_Account") ||
                        response.Message.Contains("FK_BAWithDrawDetailPurchase_Account1") ||
                        response.Message.Contains("FK_BADepositDetailParallel_Account_DebitAccount") ||
                        response.Message.Contains("FK_BADepositDetailParallel_Account_CreditAccount") ||
                        response.Message.Contains("FK_BUVoucherListDetail_Account") ||
                        response.Message.Contains("FK_BUVoucherListDetail_Account1") ||
                        response.Message.Contains("FK_CAPaymentDetailParallel_Account") ||
                        response.Message.Contains("FK_CAPaymentDetailParallel_Account1") ||
                        response.Message.Contains("FK_OpeningAccountEntry_Account") ||
                        response.Message.Contains("FK_BUPlanWithdrawDetail_Account"))
                    {
                        response.Message = @"Bạn không thể xóa Tài khoản " + accountEntity.AccountNumber +
                                           " vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    }
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountId = accountEntity.AccountId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public AccountResponse DeleteConvertAccount()
        {
            var response = new AccountResponse { Acknowledge = AcknowledgeType.Success };
            response.Message = AccountDao.DeleteConvertAccount();
            return response;
        }
        public AccountResponse CheckExistAccountNumber(string accountId,string accountNumber)
        {
            var response = new AccountResponse { Acknowledge = AcknowledgeType.Success };
            response.Message = AccountDao.CheckExistAccountNumber(accountId,accountNumber);
            return response;
        }
    }
}
