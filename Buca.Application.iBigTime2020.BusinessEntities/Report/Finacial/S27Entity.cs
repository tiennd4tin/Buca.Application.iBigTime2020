using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial
{
    public class S27Entity
    {
        public string RefId { get; set; }
        public int RefTypeId { get; set; }
        public string ProjectId { get; set; }
        public string ProjectRun { get; set; }
        public string ParentId { get; set; }
        public string ProjectName { get; set; }
        public string SubProjectName { get; set; }
        public string InitDate { get; set; }
        public string FinishDate { get; set; }
        public string BudgetSourceId { get; set; }
        public string BudgetSourceName { get; set; }
        public string PostedDate { get; set; }
        public string RefDate { get; set; }
        public string RefNo { get; set; }
        public string Description { get; set; }
        public string AccountNumberCode { get; set; }
        public string CorrespondingAccountNumberCode { get; set; }
        public decimal EstimateTotal { get; set; }
        public decimal Expend101 { get; set; }
        public decimal Expend102 { get; set; }
        public decimal Expend103 { get; set; }
        public decimal Expend104 { get; set; }
        public decimal Expend105 { get; set; }
        public decimal Expend106 { get; set; }
        public decimal TotalExpend { get; set; }
        public string AccountName { get; set; }
        public string FontStyle { get; set; }
        public int OrderNumber { get; set; }   
        public int Level { get; set; }
    }
}
