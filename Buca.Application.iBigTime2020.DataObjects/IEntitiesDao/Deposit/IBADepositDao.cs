/***********************************************************************
 * <copyright file="ibadepositdao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 16, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit
{
    /// <summary>
    ///     IBADepositDao
    /// </summary>
    public interface IBADepositDao
    {
        /// <summary>
        ///     Gets the bADeposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BADepositEntity.</returns>
        BADepositEntity GetBADeposit(string refId);

        /// <summary>
        ///     Gets the bADeposit by refdate and reftype.
        /// </summary>
        /// <param name="bADeposit">The ob bADeposit entity.</param>
        /// <returns></returns>
        BADepositEntity GetBADepositByRefdateAndReftype(BADepositEntity bADeposit);

        /// <summary>
        ///     Gets the bADeposits by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List{BADepositEntity}.</returns>
        List<BADepositEntity> GetBADepositsByRefTypeId(int refTypeId);

        /// <summary>
        ///     Gets the bADeposits by year of reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfRefDate">The year of reference date.</param>
        /// <returns></returns>
        List<BADepositEntity> GetBADepositsByYearOfRefDate(int refTypeId, short yearOfRefDate);

        /// <summary>
        ///     Gets the bADeposits by reference no and reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<BADepositEntity> GetBADepositsByRefNoAndRefDate(int refTypeId, string refNo, DateTime refDate,
            string currencyCode);

        /// <summary>
        ///     Gets the bADeposits.
        /// </summary>
        /// <returns>List{BADepositEntity}.</returns>
        List<BADepositEntity> GetBADeposits();

        /// <summary>
        ///     Inserts the bADeposit.
        /// </summary>
        /// <param name="bADeposit">The bADeposit.</param>
        /// <returns>System.Int32.</returns>
        string InsertBADeposit(BADepositEntity bADeposit);

        /// <summary>
        ///     Updates the bADeposit.
        /// </summary>
        /// <param name="bADeposit">The bADeposit.</param>
        /// <returns>System.String.</returns>
        string UpdateBADeposit(BADepositEntity bADeposit);

        /// <summary>
        ///     Deletes the bADeposit.
        /// </summary>
        /// <param name="bADeposit">The bADeposit.</param>
        /// <returns>System.String.</returns>
        string DeleteBADeposit(BADepositEntity bADeposit);

        /// <summary>
        /// Gets the BADeposit by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        BADepositEntity GetBADepositByRefNo(string refNo,int refTypeId);
                
        /// <summary>
        /// Gets the BADeposit by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        BADepositEntity GetBADepositByRefNo(string refNo, int refTypeId, DateTime postedDate);

        /// <summary>
        ///     Gets the ba deposit by salary.
        /// </summary>
        /// <param name="dateMonth">The date month.</param>
        /// <returns></returns>
        BADepositEntity GetBADepositBySalary(DateTime dateMonth);

        /// <summary>
        ///     Gets the ba deposits by salary.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        BADepositEntity GetBADepositsBySalary(int refTypeId, string postedDate, string refNo, string currencyCode);
    }
}