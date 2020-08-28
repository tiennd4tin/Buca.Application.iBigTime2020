using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
     public interface IActivityView : IView
    {
         string ActivityId { get; set; }
         string ActivityCode { get; set; }
         string ActivityName { get; set; }
         string ParentID { get; set; }
         bool IsActive { get; set; }
         bool IsParent { get; set; }
         bool IsSystem { get; set; }
         int Grade { get; set; }
    }
}
