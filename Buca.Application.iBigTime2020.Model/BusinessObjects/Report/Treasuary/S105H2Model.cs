/***********************************************************************
 * <copyright file="S105H2Model.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Tuesday, July 17, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Treasuary
{
   public class S105H2Model
    {
        public string RefDetailID { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetSourceCode { get; set; }
        public string BudgetSourceName { get; set; }
        public string BudgetKindItemCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string LineDetail { get; set; }
        public DateTime PostedDate { get; set; }
        public string RefNo { get; set; }
        public DateTime RefDate { get; set; }
        public int YearPeriod { get; set; }
        public int MonthYear { get; set; }
        public string Name { get; set; }
        public string PartID { get; set; }
        public string BudgetItemCode { get; set; }
        public string BudgetSubItemCode { get; set; }
        public string RefType { get; set; }
        public string RefID { get; set; }
        public int SortOrder { get; set; }
        public decimal Amount { get; set; }
        public decimal Amount0141xCol1 { get; set; }
        public decimal Amount0141xCol2 { get; set; }
        public decimal Amount0141xCol3 { get; set; }
        public decimal Amount0142xCol1 { get; set; }
        public decimal Amount0142xCol2 { get; set; }
        public decimal Amount0142xCol3 { get; set; }
        public decimal BeginingBalance2 { get; set; }
        public decimal BeginingBalance3 { get; set; }
        public decimal BeginingBalance5 { get; set; }
        public decimal BeginingBalance6 { get; set; }
        public decimal BeginingBalance1 { get; set; }
        public decimal BeginingBalance4 { get; set; }
    }
}
