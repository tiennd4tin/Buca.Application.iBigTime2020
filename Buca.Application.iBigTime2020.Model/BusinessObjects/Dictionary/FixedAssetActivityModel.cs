using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    public class FixedAssetActivityModel
    {
        public string FixedAssetId { get; set; }
        public string FixedAssetActivityId { get; set; }
        public string CreditDepreciationAccount { get; set; }
        public string DebitDepreciationAccount { get; set; }
        public decimal DepreciationValueCaculated { get; set; }

    }
}
