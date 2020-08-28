/*********************************************************************** 
* <copyright file="VoucherListResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 02 October 2017
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
    /// VoucherListResponse
    /// </summary>
    public class VoucherListResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the VoucherList.
        /// </summary>
        /// <value>
        /// The VoucherList.
        /// </value>
        public VoucherListEntity VoucherListEntity { get; set; }

        /// <summary>
        /// Gets or sets the VoucherList identifier.
        /// </summary>
        /// <value>
        /// The VoucherList identifier.
        /// </value>
        public string VoucherListId { get; set; }
    }
}
