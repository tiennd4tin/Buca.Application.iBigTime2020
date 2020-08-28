/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 26, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Ledger
{
    /// <summary>
    /// S13HModel
    /// </summary>
    public class S01HModel
    {
        public string BudgetSourceCode { get; set; }
        public string BudgetSourceName { get; set; }
        public string RowID { get; set; }
        public DateTime RefDate { get; set; }
        public DateTime PostedDate { get; set; }
        public string Description { get; set; }
        public string RefType { get; set; }
        public string RefID { get; set; }
        public string RefNo { get; set; }
        public string DebitAmount { get; set; }
        public string CreditAmount { get; set; }
        public string OrderType { get; set; }
        public string AccountNumber { get; set; }
        public string CorrespondingAccountNumber { get; set; }
        public string MonthRow { get; set; }
        public string YearRow { get; set; }
        public string BudgetChapterCode { get; set; }
        public string BudgetKindItemCode { get; set; }
        public string BudgetSubKindItemCode { get; set; }
        public string BudgetSourceID { get; set; }
        public int LineNumber { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }

    }
}
