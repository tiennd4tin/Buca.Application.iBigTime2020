using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.ExportXml
{
    public class ExportXmlBCTCBudgetSourceEntity : BusinessEntities
    {
        public ExportXmlBCTCBudgetSourceEntity()
        {
            
        }
        public string BudgetSourceId { get; set; }
        public string BudgetSourceCode { get; set; }
        public string BudgetSourceName { get; set; }
        public string BudgetSourceCodeOwner { get; set; }
        public string BudgetSourceNameOwner { get; set; }
    }
}
