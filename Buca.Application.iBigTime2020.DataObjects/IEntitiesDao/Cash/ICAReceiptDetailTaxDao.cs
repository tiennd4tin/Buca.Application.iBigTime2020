/***********************************************************************
 * <copyright file="ICAReceiptDetailTaxDao.cs" company="BUCA JSC">
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
    /// ICAReceiptDetailTaxDao interface
    /// </summary>
    public interface ICAReceiptDetailTaxDao
    {
        /// <summary>
        /// Gets the ca receipt detail taxes by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;CAReceiptDetailTaxEntity&gt;.</returns>
        List<CAReceiptDetailTaxEntity> GetCAReceiptDetailTaxesByRefId(string refId);

        /// <summary>
        /// Inserts the ca receipt detail.
        /// </summary>
        /// <param name="receiptDetailTaxEntity">The receipt detail entity.</param>
        string InsertCAReceiptDetailTax(CAReceiptDetailTaxEntity receiptDetailTaxEntity);

        /// <summary>
        /// Deletes the ca receipt detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteCAReceiptDetailTaxByRefId(string refId);
    }
}