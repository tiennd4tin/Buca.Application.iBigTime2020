using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class ProjectResponse : ResponseBase
    {
        public ProjectEntity ProjectEntity { get; set; }
        public string ProjectId { get; set; }
    }
}
