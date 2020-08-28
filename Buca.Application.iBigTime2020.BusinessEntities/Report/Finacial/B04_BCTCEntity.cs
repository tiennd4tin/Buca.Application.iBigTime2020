using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial
{
    public class B04_BCTCEntity : BusinessEntities
    {
        public string MasterId { get; set; }
        public string DetailId { get; set; }
        public int ReportItemCode { get; set; }
        public string ReportItemName { get; set; }
        public string ContentString { get; set; }
        public decimal ContentNumber { get; set; }
        public bool IsBold { get; set; }
        public int Type { get; set; }
        public string GroupType { get; set; }
        public int GroupCode { get; set; }
        public int SortOrder { get; set; }
        public decimal Col1 { get; set; }
        public decimal Col2 { get; set; }
        public decimal Col3 { get; set; }
        public decimal Col4 { get; set; }
        public decimal Col5 { get; set; }
        public decimal Col6 { get; set; }
        public decimal Col7 { get; set; }
        public decimal Col8 { get; set; }
        public decimal Col9 { get; set; }
        public decimal Col10 { get; set; }
        public decimal Col11 { get; set; }
        public decimal Col12 { get; set; }
        public string Formula { get; set; }
        public string BudgetChapterCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public int DayOfDateSystem { get; set; }
        public int MonthOfDateSystem { get; set; }
        public int YearOfDateSystem { get; set; }
        public string CompanyChiefAccountant { get; set; }
        public string CompanyReportPreparer { get; set; }
        public string CompanyDirector { get; set; }

    }
}
