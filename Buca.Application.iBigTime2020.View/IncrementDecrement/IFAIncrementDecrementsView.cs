using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;

namespace Buca.Application.iBigTime2020.View.IncrementDecrement
{
    /// <summary>
    ///     IFAIncrementDecrementsView
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.IView" />
    public interface IFAIncrementDecrementsView : IView
    {
        /// <summary>
        ///     Gets or sets the fa increment decrements.
        /// </summary>
        /// <value>
        ///     The fa increment decrements.
        /// </value>
        IList<FAIncrementDecrementModel> FAIncrementDecrements {set; }
    }
}