using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial
{
    public class S27Model
    {
        public string RefId { get; set; }
        public int RefTypeId { get; set; }
        public string ProjectId { get; set; }
        public string ParentId { get; set; }
        public string ProjectRun { get; set; }
        public string ProjectName { get; set; }     // day la projectId cua du an cha
        public string SubProjectName { get; set; }  // them thang nay de hien thi ten du an con
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
        public List<S27Model> Details { get; set; }
        public decimal TotalOpen { get; set; }
        public decimal TotalMovement { get; set; }
        public decimal TotalAccumlate { get; set; }
        public decimal TotalClosing { get; set; }
        public decimal TotalInit { get; set; }
        public decimal Open101 { get; set; }
        public decimal Open102 { get; set; }
        public decimal Open103 { get; set; }
        public decimal Open104 { get; set; }
        public decimal Open105 { get; set; }
        public decimal Open106 { get; set; }
        public decimal Movement101 { get; set; }
        public decimal Movement102 { get; set; }
        public decimal Movement103 { get; set; }
        public decimal Movement104 { get; set; }
        public decimal Movement105 { get; set; }
        public decimal Movement106 { get; set; }
        public decimal Accumlate101 { get; set; }
        public decimal Accumlate102 { get; set; }
        public decimal Accumlate103 { get; set; }
        public decimal Accumlate104 { get; set; }
        public decimal Accumlate105 { get; set; }
        public decimal Accumlate106 { get; set; }
        public decimal Closing101 { get; set; }
        public decimal Closing102 { get; set; }
        public decimal Closing103 { get; set; }
        public decimal Closing104 { get; set; }
        public decimal Closing105 { get; set; }
        public decimal Closing106 { get; set; }
        public decimal Init101 { get; set; }
        public decimal Init102 { get; set; }
        public decimal Init103 { get; set; }
        public decimal Init104 { get; set; }
        public decimal Init105 { get; set; }
        public decimal Init106 { get; set; }
        public bool ShowDetail { get; set; }
        public int Level { get; set; }
    }
}
