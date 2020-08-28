/***********************************************************************
 * <copyright file="IOpeningCommitmentsView.cs" company="BUCA JSC">
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
 using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.OpeningCommitment
{
    /// <summary>
    /// Interface IOpeningCommitmentsView
    /// </summary>
    public interface IOpeningCommitmentsView
    {
        /// <summary>
        /// Gets or sets the opening commitments.
        /// </summary>
        /// <value>The opening commitments.</value>
        IList<OpeningCommitmentModel> OpeningCommitments { set; }
    }
}
