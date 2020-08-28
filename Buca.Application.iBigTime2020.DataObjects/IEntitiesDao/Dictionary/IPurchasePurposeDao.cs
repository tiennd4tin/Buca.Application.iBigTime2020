/***********************************************************************
 * <copyright file="IPurchasePurposeDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 12, 2017
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
    ///     IPurchasePurposeDao
    /// </summary>
    public interface IPurchasePurposeDao
    {
        /// <summary>
        ///     Gets the purchasePurpose.
        /// </summary>
        /// <param name="purchasePurposeId">The purchasePurpose identifier.</param>
        /// <returns></returns>
        PurchasePurposeEntity GetPurchasePurpose(string purchasePurposeId);

        /// <summary>
        ///     Gets the purchasePurposes.
        /// </summary>
        /// <returns></returns>
        List<PurchasePurposeEntity> GetPurchasePurposes();

        /// <summary>
        ///     Inserts the purchasePurpose.
        /// </summary>
        /// <param name="purchasePurpose">The purchasePurpose.</param>
        /// <returns></returns>
        string InsertPurchasePurpose(PurchasePurposeEntity purchasePurpose);

        /// <summary>
        ///     Updates the purchasePurpose.
        /// </summary>
        /// <param name="purchasePurpose">The purchasePurpose.</param>
        /// <returns></returns>
        string UpdatePurchasePurpose(PurchasePurposeEntity purchasePurpose);

        /// <summary>
        ///     Deletes the purchasePurpose.
        /// </summary>
        /// <param name="purchasePurpose">The purchasePurpose.</param>
        /// <returns>System.String.</returns>
        string DeletePurchasePurpose(PurchasePurposeEntity purchasePurpose);
        string DeletePurchasePurposeConvert();

        /// <summary>
        ///     Gets the purchasePurposes by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;PurchasePurposeEntity&gt;.</returns>
        List<PurchasePurposeEntity> GetPurchasePurposesByIsActive(bool isActive);

        /// <summary>
        ///     Lấy danh sách các kho theo mã
        /// </summary>
        /// <param name="purchasePurposeCode"></param>
        /// <returns></returns>
        PurchasePurposeEntity GetPurchasePurposesByPurchasePurposeCode(string purchasePurposeCode);
    }
}