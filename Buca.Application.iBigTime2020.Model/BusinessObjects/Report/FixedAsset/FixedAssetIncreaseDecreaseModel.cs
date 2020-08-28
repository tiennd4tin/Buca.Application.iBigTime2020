using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.FixedAsset
{
    public class FixedAssetIncreaseDecreaseModel
    {
        public string DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string FixedAssetId { get; set; }

        public string FixedAssetName { get; set; }

        public decimal OpenQty { get; set; }

        public decimal OpenAmount { get; set; }

        public decimal InwardQty { get; set; }

        public decimal InwardAmount { get; set; }

        public decimal OutwardQty { get; set; }

        public decimal OutwardAmount { get; set; }

        public string FixedAssetCode { get; set; }

        public decimal IsFixedAsset { get; set; }
    }
}
