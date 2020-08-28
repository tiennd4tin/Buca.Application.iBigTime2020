/***********************************************************************
 * <copyright file="bawithdrawresponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 23, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Deposit
{
    /// <summary>
    ///     BAWithDrawResponse
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessComponents.Message.ResponseBase" />
    public class BAWithDrawResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the ba deposit entity.
        /// </summary>
        /// <value>
        ///     The ba deposit entity.
        /// </value>
        public BAWithDrawEntity BAWithDrawEntity { get; set; }

        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public string RefId { get; set; }
    }
}