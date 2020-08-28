/***********************************************************************
 * <copyright file="BUVoucherListResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, May 31, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate
{
    /// <summary>
    ///     BUVoucherListResponse
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessComponents.Message.ResponseBase" />
    public class BUVoucherListResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the bu voucher list entity.
        /// </summary>
        /// <value>
        ///     The bu voucher list entity.
        /// </value>
        public BUVoucherListEntity BUVoucherListEntity { get; set; }

        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public string RefId { get; set; }
    }
}