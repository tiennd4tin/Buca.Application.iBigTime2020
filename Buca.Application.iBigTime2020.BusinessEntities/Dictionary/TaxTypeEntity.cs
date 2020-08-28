﻿using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    public class TaxTypeEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxTypeEntity"/> class.
        /// </summary>
        public TaxTypeEntity()
        {
            AddRule(new ValidateRequired("TaxTypeCode"));
            AddRule(new ValidateRequired("TaxTypeName"));
        }
        /// <summary>
        /// Gets or sets the tax type identifier.
        /// </summary>
        /// <value>The tax type identifier.</value>
        public string TaxTypeId { get; set; }
        /// <summary>
        /// Gets or sets the tax type code.
        /// </summary>
        /// <value>The tax type code.</value>
        public string TaxTypeCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the tax type.
        /// </summary>
        /// <value>The name of the tax type.</value>
        public string TaxTypeName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
    }
}
