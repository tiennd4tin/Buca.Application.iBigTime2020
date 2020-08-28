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
    /// IAutoBusinessDao
    /// </summary>
    public interface IAutoBusinessDao
    {
        /// <summary>
        /// Gets the autoBusiness.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns></returns>
        AutoBusinessEntity GetAutoBusiness(string autoBusinessId);

        /// <summary>
        /// Gets the AutoBusinesses.
        /// </summary>
        /// <returns></returns>
        List<AutoBusinessEntity> GetAutoBusinesses();

        /// <summary>
        /// Gets the AutoBusinesses by autoBusiness account.
        /// </summary>
        /// <param name="autoBusinessAccount">The autoBusiness account.</param>
        /// <returns></returns>
        AutoBusinessEntity GetAutoBusinessesByAutoBusinessCode(string autoBusinessAccount);

        /// <summary>
        /// Gets the AutoBusinesses by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<AutoBusinessEntity> GetAutoBusinessesByActive(bool isActive);

        /// <summary>
        /// Gets the automatic business.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<AutoBusinessEntity> GetAutoBusinessByRefType(int refTypeId, bool isActive);

        /// <summary>
        /// Inserts the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        string InsertAutoBusiness(AutoBusinessEntity autoBusiness);

        /// <summary>
        /// Updates the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        string UpdateAutoBusiness(AutoBusinessEntity autoBusiness);

        /// <summary>
        /// Deletes the autoBusiness.
        /// </summary>
        /// <param name="autoBusiness">The autoBusiness.</param>
        /// <returns></returns>
        string DeleteAutoBusiness(AutoBusinessEntity autoBusiness);

        string DeleteAutoBusinessConvert();
    }
}
