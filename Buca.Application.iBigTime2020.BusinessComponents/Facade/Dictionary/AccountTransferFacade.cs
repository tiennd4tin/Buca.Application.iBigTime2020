/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// AccountTransferFacade
    /// </summary>
    public class AccountTransferFacade
    {
        /// <summary>
        /// The account category DAO
        /// </summary>
        private static readonly IAccountTransferDao AccountTransferDao = DataAccess.DataAccess.AccountTransferDao;

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<AccountTransferEntity> GetAccountTransfers()
        {
            return AccountTransferDao.GetAccountTransfers();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// List&lt;AccountCategoryEntity&gt;.
        /// </returns>
        public List<AccountTransferEntity> GetAccountTransfersByIsActive(bool isActive)
        {
            return AccountTransferDao.GetAccountTransfersByActive(isActive);
        }

        /// <summary>
        /// Gets the account category by identifier.
        /// </summary>
        /// <param name="accountTransferId">The account transfer identifier.</param>
        /// <returns>
        /// AccountCategoryEntity.
        /// </returns>
        public AccountTransferEntity GetAccountTransferById(string accountTransferId)
        {
            return AccountTransferDao.GetAccountTransfer(accountTransferId);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="accountTransferEntity">The account transfer entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public AccountTransferResponse InsertAccountTransfer(AccountTransferEntity accountTransferEntity)
        {
            var response = new AccountTransferResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!accountTransferEntity.Validate())
                {
                    foreach (string error in accountTransferEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var accountTransfer = AccountTransferDao.GetAccountTransfersByAccountTransferCode(accountTransferEntity.AccountTransferCode.Trim());
                if (accountTransfer != null)
                {
                    if (accountTransfer.AccountTransferId != accountTransferEntity.AccountTransferId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã tài khoản kết chuyển " + accountTransferEntity.AccountTransferCode.Trim() + @" đã tồn tại !";
                        return response;
                    }
                }

                accountTransferEntity.AccountTransferId = Guid.NewGuid().ToString();
                response.Message = AccountTransferDao.InsertAccountTransfer(accountTransferEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountTransferId = accountTransferEntity.AccountTransferId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public AccountTransferResponse InsertAccountTransferConvert(AccountTransferEntity accountTransferEntity)
        {
            var response = new AccountTransferResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!accountTransferEntity.Validate())
                {
                    foreach (string error in accountTransferEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var accountTransfer = AccountTransferDao.GetAccountTransfersByAccountTransferCode(accountTransferEntity.AccountTransferCode.Trim());
                if (accountTransfer != null)
                {
                    if (accountTransfer.AccountTransferId != accountTransferEntity.AccountTransferId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã tài khoản kết chuyển " + accountTransferEntity.AccountTransferCode.Trim() + @" đã tồn tại !";
                        return response;
                    }
                }
                response.Message = AccountTransferDao.InsertAccountTransfer(accountTransferEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountTransferId = accountTransferEntity.AccountTransferId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="accountTransferEntity">The account transfer entity.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public AccountTransferResponse UpdateAccountTransfer(AccountTransferEntity accountTransferEntity)
        {
            var response = new AccountTransferResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!accountTransferEntity.Validate())
                {
                    foreach (string error in accountTransferEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                var accountTransfer = AccountTransferDao.GetAccountTransfersByAccountTransferCode(accountTransferEntity.AccountTransferCode.Trim());
                if (accountTransfer != null)
                {
                    if (accountTransfer.AccountTransferId != accountTransferEntity.AccountTransferId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã tài khoản kết chuyển " + accountTransferEntity.AccountTransferCode.Trim() + @" đã tồn tại !";
                    return response;
                    }
                }

                response.Message = AccountTransferDao.UpdateAccountTransfer(accountTransferEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountTransferId = accountTransferEntity.AccountTransferId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="accountTransferEId">The account transfer e identifier.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public AccountTransferResponse DeleteAccountTransfer(string accountTransferEId)
        {
            var response = new AccountTransferResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var accountTransferEntity = AccountTransferDao.GetAccountTransfer(accountTransferEId);
                response.Message = AccountTransferDao.DeleteAccountTransfer(accountTransferEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountTransferId = accountTransferEntity.AccountTransferId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public AccountTransferResponse DeleteAccountTransferConvert()
        {
            var response = new AccountTransferResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
               
                response.Message = AccountTransferDao.DeleteAccountTransferConvert();
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
