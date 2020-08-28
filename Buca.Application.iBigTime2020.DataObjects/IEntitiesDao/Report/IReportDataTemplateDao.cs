using Buca.Application.iBigTime2020.BusinessEntities.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report
{
    public interface IReportDataTemplateDao
    {
        ReportDataTemplateEntity GetReportDataTemplateByCode(string dataTemplateCode);
        long ReportDataTemplate_InsertOrUpdate(ReportDataTemplateEntity reportDataTemplate);
    }
}
