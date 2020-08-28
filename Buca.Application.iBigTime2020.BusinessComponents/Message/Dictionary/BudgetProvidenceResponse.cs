/***********************************************************************
 * <copyright file="BudgetProvidenceResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 26, 2017
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
    ///     BudgetProvidenceResponse
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessComponents.Message.ResponseBase" />
    public class BudgetProvidenceResponse : ResponseBase
    {
        /// <summary>
        ///     Gets or sets the budget providence entity.
        /// </summary>
        /// <value>
        ///     The budget providence entity.
        /// </value>
        public BudgetProvidenceEntity BudgetProvidenceEntity { get; set; }

        /// <summary>
        ///     Gets or sets the budget providence identifier.
        /// </summary>
        /// <value>
        ///     The budget providence identifier.
        /// </value>
        public string BudgetProvidenceId { get; set; }
    }
}