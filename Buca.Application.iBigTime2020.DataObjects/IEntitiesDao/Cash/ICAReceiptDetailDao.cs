/***********************************************************************
 * <copyright file="ICAReceiptDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash
{

    /// <summary>
    /// ICAReceiptDetailDao interface
    /// </summary>
    public interface ICAReceiptDetailDao
    {
        /// <summary>
        /// Gets the ca receipt details by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;CAReceiptDetailEntity&gt;.</returns>
        List<CAReceiptDetailEntity> GetCAReceiptDetailsByRefId(string refId);

        /// <summary>
        /// Inserts the ca receipt detail.
        /// </summary>
        /// <param name="receiptDetailEntity">The receipt detail entity.</param>
        /// <returns>System.String.</returns>
        string InsertCAReceiptDetail(CAReceiptDetailEntity receiptDetailEntity);

        /// <summary>
        /// Deletes the ca receipt detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteCAReceiptDetailByRefId(string refId);
    }
}