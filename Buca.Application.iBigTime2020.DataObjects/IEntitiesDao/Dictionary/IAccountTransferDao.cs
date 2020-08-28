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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IAccountTransferDao
    /// </summary>
    public interface IAccountTransferDao
    {
        /// <summary>
        /// Gets the account tranfer.
        /// </summary>
        /// <param name="accountTransferId">The account transfer identifier.</param>
        /// <returns></returns>
        AccountTransferEntity GetAccountTransfer(string accountTransferId);

        /// <summary>
        /// Gets the account tranfers.
        /// </summary>
        /// <returns></returns>
        List<AccountTransferEntity> GetAccountTransfers();

        /// <summary>
        /// Gets the account tranfers by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<AccountTransferEntity> GetAccountTransfersByActive(bool isActive);

        /// <summary>
        /// Gets the account tranfers by account tranfer code.
        /// </summary>
        /// <param name="accountTransferCode">The account transfer code.</param>
        /// <returns></returns>
        AccountTransferEntity GetAccountTransfersByAccountTransferCode(string accountTransferCode);

        /// <summary>
        /// Inserts the account tranfer.
        /// </summary>
        /// <param name="accountTransfer">The account transfer.</param>
        /// <returns></returns>
        string InsertAccountTransfer(AccountTransferEntity accountTransfer);

        /// <summary>
        /// Updates the account tranfer.
        /// </summary>
        /// <param name="accountTransfer">The account transfer.</param>
        /// <returns></returns>
        string UpdateAccountTransfer(AccountTransferEntity accountTransfer);

        /// <summary>
        /// Deletes the account tranfer.
        /// </summary>
        /// <param name="accountTransfer">The account transfer.</param>
        /// <returns></returns>
        string DeleteAccountTransfer(AccountTransferEntity accountTransfer);
        string DeleteAccountTransferConvert();
    }
}
