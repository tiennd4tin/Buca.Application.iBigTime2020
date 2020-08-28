﻿/***********************************************************************
 * <copyright file="IAccountCategoryDao.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface IAccountCategoryDao
    /// </summary>
    public interface IAccountCategoryDao
    {
        /// <summary>
        /// Gets the account category.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>AccountCategoryEntity.</returns>
        AccountCategoryEntity GetAccountCategory(string accountCategoryId);

        /// <summary>
        /// Gets the account categorys.
        /// </summary>
        /// <returns>List{AccountCategoryEntity}.</returns>
        List<AccountCategoryEntity> GetAccountCategories();

        /// <summary>
        /// Gets the account categorys active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List{AccountCategoryEntity}.</returns>
        List<AccountCategoryEntity> GetAccountCategoriesByIsActive(bool isActive);

        /// <summary>
        /// Inserts the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>System.Int32.</returns>
        string InsertAccountCategory(AccountCategoryEntity accountCategory);

        /// <summary>
        /// Updates the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>System.String.</returns>
        string UpdateAccountCategory(AccountCategoryEntity accountCategory);

        /// <summary>
        /// Deletes the account category.
        /// </summary>
        /// <param name="accountCategory">The account category.</param>
        /// <returns>System.String.</returns>
        string DeleteAccountCategory(AccountCategoryEntity accountCategory);

        string DeleteConvertAccountCategorry();
    }
}
