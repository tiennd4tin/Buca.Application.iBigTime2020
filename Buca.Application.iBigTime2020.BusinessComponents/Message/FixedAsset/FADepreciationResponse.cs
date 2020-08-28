/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAsset;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.FixedAsset
{
    /// <summary>
    /// FADepreciationResponse
    /// </summary>
    public class FADepreciationResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        ///     Gets or sets the su increment decrement entity.
        /// </summary>
        /// <value>
        ///     The su increment decrement entity.
        /// </value>
        public FADepreciationEntity FADepreciationEntity { get; set; }
    }
}
