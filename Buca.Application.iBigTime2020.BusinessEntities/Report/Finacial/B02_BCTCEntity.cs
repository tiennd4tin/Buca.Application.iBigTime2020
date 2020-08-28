using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial
{
    public class B02_BCTCEntity : BusinessEntities
    {
        public string MasterId { get; set; }
        public string DetailId { get; set; }
        public string ColA { get; set; }
        public string ReportItemAlias { get; set; }
        public string ReportItemName { get; set; }
        public string ReportItemCode { get; set; }
        public decimal Col1 { get; set; }
        public decimal Col2 { get; set; }
        public int SortOrder { get; set; }
        public bool IsBold { get; set; }
        public string Description { get; set; }
        public string BudgetChapterCode { get; set; }
        public string Formula { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int DayOfDateSystem { get; set; }
        public int MonthOfDateSystem { get; set; }
        public int YearOfDateSystem { get; set; }
        public string CompanyChiefAccountant { get; set; }
        public string CompanyReportPreparer { get; set; }
        public string CompanyDirector { get; set; }

    }
}
