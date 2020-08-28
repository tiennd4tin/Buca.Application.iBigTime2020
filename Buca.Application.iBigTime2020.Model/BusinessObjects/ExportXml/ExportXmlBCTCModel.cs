using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.ExportXml
{
    public class ExportXmlBCTCModel
    {
        public string ReportId { get; set; }
        public string ParentName { get; set; }
        public string ReportName { get; set; }
        public int SortOrder { get; set; }
        public string ProcedureName { get; set; }
        public string InputTypeName { get; set; }
        public string FunctionName { get; set; }
        public string ReportNameId { get; set; }
    }
}
