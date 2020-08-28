using System.Linq.Expressions;

namespace Buca.Application.iBigTime2020.DataHelpers.DynamicLinq.cs
{
    /// <summary>
    /// 
    /// </summary>
    internal class DynamicOrdering
    {
        /// <summary>
        /// The selector
        /// </summary>
        public Expression Selector;
        /// <summary>
        /// The ascending
        /// </summary>
        public bool Ascending;
    }
}
