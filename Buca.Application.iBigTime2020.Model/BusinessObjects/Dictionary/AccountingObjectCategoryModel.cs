using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    public class AccountingObjectCategoryModel
    {
        public string AccountingObjectCategoryId { get; set; }
        public string AccountingObjectCategoryCode { get; set; }
        public string AccountingObjectCategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsSystem { get; set; }
    } 
}
