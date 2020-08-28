/***********************************************************************
 * <copyright file="OpeningFixedAssetResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Friday, April 20, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Opening
{
    /// <summary>
    /// Class OpeningFixedAssetResponse.
    /// </summary>
    public class OpeningFixedAssetResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the su increment decrement entity.
        /// </summary>
        /// <value>The su increment decrement entity.</value>
        public OpeningFixedAssetEntryEntity OpeningFixedAssetEntry { get; set; }
    }
}
