/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 27, 2017
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
    /// SUTransferResponse
    /// </summary>
    public class SUTransferResponse : ResponseBase
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
        public SUTransferEntity SUTransferEntity { get; set; }
    }
}
