/***********************************************************************
 * <copyright file="IBudgetProvidenceView.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    ///     IBudgetProvidenceView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IBudgetProvidenceView : IView
    {
        /// <summary>
        ///     Gets or sets the budget provide identifier.
        /// </summary>
        /// <value>
        ///     The budget provide identifier.
        /// </value>
        string BudgetProvideId { get; set; }

        /// <summary>
        ///     Gets or sets the budget provide code.
        /// </summary>
        /// <value>
        ///     The budget provide code.
        /// </value>
        string BudgetProvideCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the budget provide.
        /// </summary>
        /// <value>
        ///     The name of the budget provide.
        /// </value>
        string BudgetProvideName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is system; otherwise, <c>false</c>.
        /// </value>
        bool IsSystem { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}