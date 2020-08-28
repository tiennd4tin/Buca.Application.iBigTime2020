/***********************************************************************
 * <copyright file="BudgetProvidenceEntity.cs" company="BUCA JSC">
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

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    ///     BudgetProvidenceEntity
    /// </summary>
    /// <seealso cref="BusinessEntities" />
    public class BudgetProvidenceEntity : BusinessEntities
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BudgetProvidenceEntity" /> class.
        /// </summary>
        public BudgetProvidenceEntity()
        {
            AddRule(new ValidateRequired("BudgetProvideCode"));
            AddRule(new ValidateRequired("BudgetProvideName"));
        }

        /// <summary>
        ///     Gets or sets the budget provide identifier.
        /// </summary>
        /// <value>
        ///     The budget provide identifier.
        /// </value>
        public string BudgetProvideId { get; set; }

        /// <summary>
        ///     Gets or sets the budget provide code.
        /// </summary>
        /// <value>
        ///     The budget provide code.
        /// </value>
        public string BudgetProvideCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the budget provide.
        /// </summary>
        /// <value>
        ///     The name of the budget provide.
        /// </value>
        public string BudgetProvideName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is system; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}