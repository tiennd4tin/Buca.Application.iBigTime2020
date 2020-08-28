/***********************************************************************
 * <copyright file="AccountCategoryFacade.cs" company="BUCA JSC">
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
    /// Class AccountCategoryFacade.
    /// </summary>
    public class AccountCategoryFacade
    {
        /// <summary>
        /// The account category DAO
        /// </summary>
        private static readonly IAccountCategoryDao AccountCategoryDao = DataAccess.DataAccess.AccountCategoryDao;

        /// <summary>
        /// Gets the account categories.
        /// </summary>
        /// <returns>List&lt;AccountCategoryEntity&gt;.</returns>
        public List<AccountCategoryEntity> GetAccountCategories()
        {
            return AccountCategoryDao.GetAccountCategories();
        }

        /// <summary>
        /// Gets the account categories by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;AccountCategoryEntity&gt;.</returns>
        public List<AccountCategoryEntity> GetAccountCategoriesByIsActive(bool isActive)
        {
            return AccountCategoryDao.GetAccountCategoriesByIsActive(isActive);
        }

        /// <summary>
        /// Gets the account category by identifier.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>AccountCategoryEntity.</returns>
        public AccountCategoryEntity GetAccountCategoryById(string accountCategoryId)
        {
            return AccountCategoryDao.GetAccountCategory(accountCategoryId);
        }

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="accountCategoryEntity">The account category entity.</param>
        /// <returns>AccountCategoryResponse.</returns>
        public AccountCategoryResponse InsertAccountCategory(AccountCategoryEntity accountCategoryEntity)
        {
            var response = new AccountCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!accountCategoryEntity.Validate())
                {
                    foreach (string error in accountCategoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                accountCategoryEntity.AccountCategoryId = AccountCategoryDao.InsertAccountCategory(accountCategoryEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountCategoryId = accountCategoryEntity.AccountCategoryId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="accountCategoryEntity">The account category entity.</param>
        /// <returns>AccountCategoryResponse.</returns>
        public AccountCategoryResponse UpdateAccountCategory(AccountCategoryEntity accountCategoryEntity)
        {
            var response = new AccountCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!accountCategoryEntity.Validate())
                {
                    foreach (string error in accountCategoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.Message = AccountCategoryDao.UpdateAccountCategory(accountCategoryEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountCategoryId = accountCategoryEntity.AccountCategoryId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>AccountCategoryResponse.</returns>
        public AccountCategoryResponse DeleteAccountCategory(string accountCategoryId)
        {
            var response = new AccountCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var accountCategoryEntity = AccountCategoryDao.GetAccountCategory(accountCategoryId);
                response.Message = AccountCategoryDao.DeleteAccountCategory(accountCategoryEntity);
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountCategoryId = accountCategoryEntity.AccountCategoryId;
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }

        public AccountCategoryResponse DeleteConvertAccountCategory()
        {
            var response = new AccountCategoryResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                response.Message = AccountCategoryDao.DeleteConvertAccountCategorry();
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}

