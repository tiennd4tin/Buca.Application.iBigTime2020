/***********************************************************************
 * <copyright file="PurchasePurposeResponse.cs" company="BUCA JSC">
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

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    /// <summary>
    ///     PurchasePurposeResponse
    /// </summary>
    public class PurchasePurposeResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the purchase purpose entity.
        /// </summary>
        /// <value>
        ///     The purchase purpose entity.
        /// </value>
        public PurchasePurposeEntity PurchasePurposeEntity { get; set; }

        /// <summary>
        ///     Gets or sets the purchase purpose identifier.
        /// </summary>
        /// <value>
        ///     The purchase purpose identifier.
        /// </value>
        public string PurchasePurposeId { get; set; }
    }
}