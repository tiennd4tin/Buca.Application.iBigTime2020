/***********************************************************************
 * <copyright file="BUTransferResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate
{
    /// <summary>
    /// Class BUTransferResponse.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessComponents.Message.ResponseBase" />
    public class BUTransferResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the bu commitment request.
        /// </summary>
        /// <value>The bu commitment request.</value>
        public BUTransferEntity BUCommitmentRequest { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
    }
}
