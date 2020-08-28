/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    /// <summary>
    /// BudgetKindItemResponse
    /// </summary>
    public class BudgetKindItemResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the account transfer.
        /// </summary>
        /// <value>
        /// The account transfer.
        /// </value>
        public BudgetKindItemEntity BudgetKindItemEntity { get; set; }

        /// <summary>
        /// Gets or sets the account transfer identifier.
        /// </summary>
        /// <value>
        /// The account transfer identifier.
        /// </value>
        public string BudgetKindItemId { get; set; }
    }
}
