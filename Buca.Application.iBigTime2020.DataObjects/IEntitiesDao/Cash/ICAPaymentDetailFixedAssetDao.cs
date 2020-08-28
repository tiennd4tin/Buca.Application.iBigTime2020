/***********************************************************************
 * <copyright file="icapaymentdetailfixedassetdao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, October 30, 2017 Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash
{
    public interface ICAPaymentDetailFixedAssetDao
    {

        /// <summary>
        /// Gets the ca payment detail fixed assets by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;CAPaymentDetailFixedAssetEntity&gt;.</returns>
        List<CAPaymentDetailFixedAssetEntity> GetCAPaymentDetailFixedAssetsByRefId(string refId);
        /// <summary>
        /// Inserts the ca payment detail fixed asset.
        /// </summary>
        /// <param name="cAPaymentDetailFixedAsset">The c a payment detail fixed asset.</param>
        /// <returns>System.String.</returns>
        string InsertCAPaymentDetailFixedAsset(CAPaymentDetailFixedAssetEntity cAPaymentDetailFixedAsset);
        /// <summary>
        /// Deletes the ca payment detail fixed asset.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteCAPaymentDetailFixedAsset(string refId);
    }
}
