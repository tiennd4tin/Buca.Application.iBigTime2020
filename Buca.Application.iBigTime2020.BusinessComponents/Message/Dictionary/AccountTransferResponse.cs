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
    /// AccountTransferResponse
    /// </summary>
    public class AccountTransferResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the account transfer.
        /// </summary>
        /// <value>The account transfer.</value>
        public AccountTransferEntity AccountTransferEntity { get; set; }

        /// <summary>
        /// Gets or sets the account transfer identifier.
        /// </summary>
        /// <value>The account transfer identifier.</value>
        public string AccountTransferId { get; set; }
    }
}
