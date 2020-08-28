using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    public interface ITaxTypeView : IView
    {
        /// <summary>
        /// Gets or sets the tax type identifier.
        /// </summary>
        /// <value>The tax type identifier.</value>
        string TaxTypeId { get; set; }

        /// <summary>
        /// Gets or sets the tax type code.
        /// </summary>
        /// <value>The tax type code.</value>
        string TaxTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the tax type.
        /// </summary>
        /// <value>The name of the tax type.</value>
        string TaxTypeName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        bool IsActive { get; set; }
    }
}
