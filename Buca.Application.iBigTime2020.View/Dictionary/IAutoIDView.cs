/***********************************************************************
 * <copyright file="IAutoNumberView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 14 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// IAutoNumberView
    /// </summary>
    public interface IAutoIDView : IView
    {
        /// <summary>
        /// Gets or sets the reference type category identifier.
        /// </summary>
        /// <value>The reference type category identifier.</value>
        int RefTypeCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the reference type category.
        /// </summary>
        /// <value>The name of the reference type category.</value>
        string RefTypeCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>The prefix.</value>
        string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the length of value.
        /// </summary>
        /// <value>The length of value.</value>
        int LengthOfValue { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>The suffix.</value>
        string Suffix { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        bool IsSystem { get; set; }
    }
}
