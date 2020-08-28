using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;

namespace Buca.Application.iBigTime2020.View.Estimate
{
  public  interface IBUPlanAdjustmentsView 
    {
        IList<BUPlanAdjustmentModel> BUPlanAdjustment {set; }
    }
}
