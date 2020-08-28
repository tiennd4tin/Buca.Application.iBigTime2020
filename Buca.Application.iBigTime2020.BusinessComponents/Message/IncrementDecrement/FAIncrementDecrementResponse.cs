/***********************************************************************
 * <copyright file="FAIncrementDecrementResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.IncrementDecrement
{
    /// <summary>
    ///     FAIncrementDecrementResponse
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessComponents.Message.ResponseBase" />
    public class FAIncrementDecrementResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        ///     Gets or sets the fa increment decrement entity.
        /// </summary>
        /// <value>
        ///     The fa increment decrement entity.
        /// </value>
        public FAIncrementDecrementEntity FAIncrementDecrementEntity { get; set; }
    }
}