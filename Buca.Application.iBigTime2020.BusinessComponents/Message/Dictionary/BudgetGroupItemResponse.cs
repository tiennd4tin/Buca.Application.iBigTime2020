/***********************************************************************
 * <copyright file="BudgetGroupItemResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Wednesday, October 10, 2018
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
    /// BudgetGroupItemResponse
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessComponents.Message.ResponseBase" />
    public class BudgetGroupItemResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the budget group item entity.
        /// </summary>
        /// <value>
        /// The budget group item entity.
        /// </value>
        public BudgetGroupItemEntity BudgetGroupItemEntity { get; set; }

        /// <summary>
        /// Gets or sets the budget group item identifier.
        /// </summary>
        /// <value>
        /// The budget group item identifier.
        /// </value>
        public string BudgetGroupItemId { get; set; }
    }
}
