using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
   public class TaxItemModel
    {
        /// <summary>
        /// Gets or sets the tax item identifier.
        /// </summary>
        /// <value>The tax item identifier.</value>
        public string TaxItemId { get; set; }
        /// <summary>
        /// Gets or sets the tax item code.
        /// </summary>
        /// <value>The tax item code.</value>
        public string TaxItemCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the tax item.
        /// </summary>
        /// <value>The name of the tax item.</value>
        public string TaxItemName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
    }
}
