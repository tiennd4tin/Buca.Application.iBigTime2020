using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial
{
    public class B05_BCTCModel
    {
        public string ReportItemIndex { get; set; }
        public string ReportItemAlias { get; set; }
        public string ReportItemName { get; set; }
        public string ReportItemCode { get; set; }
        public int Type { get; set; }
        public decimal Col1 { get; set; }
        public decimal Col2 { get; set; }
        public int SortOrder { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public string BudgetChapterCode { get; set; }
        public string GroupName { get; set; }
        public string GroupType { get; set; }

    }
}
