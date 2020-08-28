/*********************************************************************** 
* <copyright file="AccountTransferEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 28 September 2017
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
    /// BudgetSourceCategoryResponse
    /// </summary>
    public class BudgetSourceCategoryResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the account transfer.
        /// </summary>
        /// <value>The account transfer.</value>
        public BudgetSourceCategoryEntity BudgetSourceCategoryEntity { get; set; }

        /// <summary>
        /// Gets or sets the account transfer identifier.
        /// </summary>
        /// <value>The account transfer identifier.</value>
        public string BudgetSourceCategoryId { get; set; }
    }
}
