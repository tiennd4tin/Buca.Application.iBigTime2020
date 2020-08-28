using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher
{
    public class C2_02aEntity : BusinessEntities
    {
        public C2_02aEntity()
        {
            Details = new List<C2_02aDetailEntity>();
        }
        public string RefNo { get; set; }
        public DateTime PostedDate { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string AccountingObjectName { get; set; }
        public string Address { get; set; }
        public string BankAccount_Object { get; set; }
        public string BankName_Object { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssueBy { get; set; }
        public decimal TotalAmount { get; set; }
        public int CashWithDrawType { get; set; }
        public int RefType { get; set; }
        public string EmployeeCode { get; set; }
        public string Employee { get; set; }
        public IList<C2_02aDetailEntity> Details { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeBankAccount { get; set; }
        public string EmployeeBankName { get; set; }

        public bool IsEmployee { get; set; }
        public string JournalMemo { get; set; }
        public string BudgetCode { get; set; }
    }
}
