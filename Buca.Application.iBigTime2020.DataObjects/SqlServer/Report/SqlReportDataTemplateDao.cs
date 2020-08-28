using Buca.Application.iBigTime2020.BusinessEntities.Report;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Report
{
    public class SqlReportDataTemplateDao : IReportDataTemplateDao
    {
        public ReportDataTemplateEntity GetReportDataTemplateByCode(string dataTemplateCode)
        {
            const string sql = @"uspReportDataTemplate_GetByCode";
            object[] parms = { "@DataTemplateCode", dataTemplateCode };
            return Db.Read(sql, true, Make, parms);
        }

        public long ReportDataTemplate_InsertOrUpdate(ReportDataTemplateEntity reportDataTemplate)
        {
            const string sql = @"uspReportDataTemplate_InsertOrUpdate";
            var reportDataTemplateByCode = GetReportDataTemplateByCode(reportDataTemplate.DataTemplateCode);
            if (reportDataTemplateByCode != null)
                return Db.Update(sql, true, Take(reportDataTemplate)) == "1" ? 1 : 0;
            return Db.InsertInt(sql, true, Take(reportDataTemplate));
        }

        private static readonly Func<IDataReader, ReportDataTemplateEntity> Make = reader => new ReportDataTemplateEntity()
        {
            DataTemplateCode = reader["DataTemplateCode"].AsString(),
            Value = reader["Value"].AsString(),
            Description = reader["Description"].AsString(),
        };

        private object[] Take(ReportDataTemplateEntity reportDataTemplate)
        {
            return new object[]
            {
                 "@DataTemplateCode", reportDataTemplate.DataTemplateCode,
                 "@Value", reportDataTemplate.Value,
                 "@Description", reportDataTemplate.Description,
            };
        }
    }
}
