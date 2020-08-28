using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    public class FixedAssetActivityEntity : BusinessEntities
    {
        public string FixedAssetId { get; set; }
        public string FixedAssetActivityId { get; set; }
        public string CreditDepreciationAccount { get; set; }
        public string DebitDepreciationAccount { get; set; }
        public decimal DepreciationValueCaculated { get; set; }
    }
}
