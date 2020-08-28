using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    public class TaxItemEntity : BusinessEntities
    {
        public TaxItemEntity()
        {
            AddRule(new ValidateRequired("TaxTypeCode"));
            AddRule(new ValidateRequired("TaxTypeName"));
        }
        public string TaxItemId { get; set; }
        public string TaxItemCode { get; set; }
        public string TaxItemName { get; set; }
        public bool IsActive { get; set; }
    }
}
