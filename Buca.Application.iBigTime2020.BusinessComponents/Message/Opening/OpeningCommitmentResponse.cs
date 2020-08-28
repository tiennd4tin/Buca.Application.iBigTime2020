/***********************************************************************
 * <copyright file="OpeningCommitmentResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, December 8, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, December 8, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Opening
{
    public class OpeningCommitmentResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the bu commitment request.
        /// </summary>
        /// <value>The bu commitment request.</value>
        public OpeningCommitmentEntity OpeningCommitment { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
    }
}
