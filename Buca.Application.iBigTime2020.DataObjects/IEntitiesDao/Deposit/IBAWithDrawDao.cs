using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit
{
    public interface IBAWithDrawDao
    {
        /// <summary>
        ///     Gets the bAWithDraw.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BAWithDrawEntity.</returns>
        BAWithDrawEntity GetBAWithDraw(string refId);

        /// <summary>
        ///     Gets the bAWithDraw by refdate and reftype.
        /// </summary>
        /// <param name="bAWithDraw">The ob bAWithDraw entity.</param>
        /// <returns></returns>
        BAWithDrawEntity GetBAWithDrawByRefdateAndReftype(BAWithDrawEntity bAWithDraw);

        /// <summary>
        ///     Gets the bAWithDraws by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List{BAWithDrawEntity}.</returns>
        List<BAWithDrawEntity> GetBAWithDrawsByRefTypeId(int refTypeId);

        /// <summary>
        ///     Gets the bAWithDraws by year of reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfRefDate">The year of reference date.</param>
        /// <returns></returns>
        List<BAWithDrawEntity> GetBAWithDrawsByYearOfRefDate(int refTypeId, short yearOfRefDate);

        /// <summary>
        ///     Gets the bAWithDraws by reference no and reference date.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<BAWithDrawEntity> GetBAWithDrawsByRefNoAndRefDate(int refTypeId, string refNo, DateTime refDate,
            string currencyCode);

        /// <summary>
        ///     Gets the bAWithDraws.
        /// </summary>
        /// <returns>List{BAWithDrawEntity}.</returns>
        List<BAWithDrawEntity> GetBAWithDraws();

        /// <summary>
        ///     Inserts the bAWithDraw.
        /// </summary>
        /// <param name="bAWithDraw">The bAWithDraw.</param>
        /// <returns>System.Int32.</returns>
        string InsertBAWithDraw(BAWithDrawEntity bAWithDraw);

        /// <summary>
        ///     Updates the bAWithDraw.
        /// </summary>
        /// <param name="bAWithDraw">The bAWithDraw.</param>
        /// <returns>System.String.</returns>
        string UpdateBAWithDraw(BAWithDrawEntity bAWithDraw);

        /// <summary>
        ///     Deletes the bAWithDraw.
        /// </summary>
        /// <param name="bAWithDraw">The bAWithDraw.</param>
        /// <returns>System.String.</returns>
        string DeleteBAWithDraw(BAWithDrawEntity bAWithDraw);

        /// <summary>
        ///     Gets the BAWithDraw by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        BAWithDrawEntity GetBAWithDrawByRefNo(string refNo);

        /// <summary>
        /// Gets the ba with draw by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns>BAWithDrawEntity.</returns>
        BAWithDrawEntity GetBAWithDrawByRefNo(string refNo, DateTime postedDate);

        /// <summary>
        ///     Gets the ba deposit by salary.
        /// </summary>
        /// <param name="dateMonth">The date month.</param>
        /// <returns></returns>
        BAWithDrawEntity GetBAWithDrawBySalary(DateTime dateMonth);

        /// <summary>
        ///     Gets the ba deposits by salary.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        BAWithDrawEntity GetBAWithDrawsBySalary(int refTypeId, string postedDate, string refNo, string currencyCode);
    }
}