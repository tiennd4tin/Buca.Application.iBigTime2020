using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Messages.MessageBase;
using Buca.Application.iBigTime2020.BusinessComponents.Messages.Report;
using Buca.Application.iBigTime2020.BusinessEntities.Report;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Report
{
    public class ReportDataTemplateFacade
    {
        private readonly static IReportDataTemplateDao ReportDataTemplateDao = DataAccess.DataAccess.ReportDataTemplateDao;

        public ReportDataTemplateEntity GetReportDataTemplate(string reportDataTemplate)
        {
            return ReportDataTemplateDao.GetReportDataTemplateByCode(reportDataTemplate);
        }
        public ReportDataTemplateResponse InsertOrUpdateReportDataTemplate(ReportDataTemplateEntity reportDataTemplate)
        {
            var response = new ReportDataTemplateResponse();
            try
            {
                if (reportDataTemplate != null)
                {
                    if (!reportDataTemplate.Validate())
                    {
                        foreach (string error in reportDataTemplate.ValidationErrors)
                            response.Message += error + Environment.NewLine;
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    if (reportDataTemplate.DataTemplateCode != null)
                    {
                        var index = ReportDataTemplateDao.ReportDataTemplate_InsertOrUpdate(reportDataTemplate);
                        if (index < 1)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        response.Index = index;
                    }
                }
            }
            catch (Exception) { }

            return response;
        }
    }
}
