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
    /// AutoBusinessResponse
    /// </summary>
    public class AutoBusinessResponse: ResponseBase
    {
        /// <summary>
        /// Gets or sets the AutoBusiness.
        /// </summary>
        /// <value>
        /// The AutoBusiness.
        /// </value>
        public AutoBusinessEntity AutoBusinessEntity { get; set; }

        /// <summary>
        /// Gets or sets the AutoBusiness identifier.
        /// </summary>
        /// <value>
        /// The AutoBusiness identifier.
        /// </value>
        public string AutoBusinessId { get; set; }
    }
}
