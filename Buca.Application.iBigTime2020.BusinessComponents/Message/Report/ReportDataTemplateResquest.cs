using Buca.Application.iBigTime2020.BusinessComponents.Messages.MessageBase;
using Buca.Application.iBigTime2020.BusinessEntities.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Messages.Report
{
    public class ReportDataTemplateResquest : RequestBase
    {
        public long Index { get; set; }
        public ReportDataTemplateEntity ReportDataTemplate { get; set; }
    }
}
