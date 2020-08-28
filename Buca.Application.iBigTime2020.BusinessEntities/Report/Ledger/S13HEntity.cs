/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 24, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Ledger
{
    /// <summary>
    /// S13HEntity
    /// </summary>
    public class S13HEntity
    {

        public string RefId { get; set; }
        public int RefType { get; set; }
        public int RefTypeCategory { get; set; }
        public string RefNo { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime RefDate { get; set; }
        public string JournalMemo { get; set; }
        public string Description { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string CorrespondingAccountNumber { get; set; }
        public decimal DebitAmountOC { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmountOC { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal ClosingDebitAmountOC { get; set; }
        public decimal ClosingDebitAmount { get; set; }
        public decimal ClosingCreditAmountOC { get; set; }
        public decimal ClosingCreditAmount { get; set; }
        public int OrderType { get; set; }
        public string SortOrder { get; set; }  
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTime StartOfMonth { get; set; }
        public decimal Cot1 { get; set; }
        public decimal Cot2 { get; set; }
        public decimal Cot1OC { get; set; }
        public decimal Cot2OC { get; set; }
        public decimal Cot3 { get; set; }
        public decimal Cot3OC { get; set; }
        public string BankAccount { get; set; }    
    }
}
