using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.BusinessEntities.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents
{   
    public class FeaturePermisionResponse : ResponseBase
    {
        public FeaturePermisionEntity FeaturePermision { get; set; }

        public string FeaturePermisionID { get; set; }
    }
}
