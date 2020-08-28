using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher
{
    public class C409KBModel
    {
        public int RefID { get; set; }
        public string RefNo { get; set; }
        public string CompanyBankAccount { get; set; }
        public string CompanyBankName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCMT { get; set; }
        public DateTime DateRange { get; set; }
        public DateTime RefDate { get; set; }
        public string IssuedWhere { get; set; }
        public IList<C409KBDetailsModel> Details { get; set; }
    }
}
