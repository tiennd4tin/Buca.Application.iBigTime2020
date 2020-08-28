using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Report
{
    public interface IReportDataTemplatesView
    {
        IList<ReportDataTemplateModel> ReportDataTemplates { get; set; }
    }
}
