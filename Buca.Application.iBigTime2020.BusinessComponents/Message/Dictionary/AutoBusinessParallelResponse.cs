/*********************************************************************** 
* <copyright file="AccountTransferEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 25 September 2017
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
    /// AutoBusinessParallelResponse
    /// </summary>
    public class AutoBusinessParallelResponse: ResponseBase
    {
        /// <summary>
        /// Gets or sets the AutoBusinessParallel.
        /// </summary>
        /// <value>
        /// The AutoBusinessParallel.
        /// </value>
        public AutoBusinessParallelEntity AutoBusinessParallelEntity { get; set; }

        /// <summary>
        /// Gets or sets the AutoBusinessParallel identifier.
        /// </summary>
        /// <value>
        /// The AutoBusinessParallel identifier.
        /// </value>
        public string AutoBusinessParallelId { get; set; }
    }
}
