using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    public interface IAccountingObjectCategoryView
    {
        string AccountingObjectCategoryId { get; set; }
        string AccountingObjectCategoryCode { get; set; }
        string AccountingObjectCategoryName { get; set; }
        bool IsActive { get; set; }
        bool IsSystem { get; set; }
    }
}
