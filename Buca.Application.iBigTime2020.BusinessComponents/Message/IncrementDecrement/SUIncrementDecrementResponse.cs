/***********************************************************************
 * <copyright file="SUIncrementDecrementResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 25, 2017
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
    ///     SUIncrementDecrementResponse
    /// </summary>
    public class SUIncrementDecrementResponse : ResponseBase
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
        public SUIncrementDecrementEntity SUIncrementDecrementEntity { get; set; }
    }
}