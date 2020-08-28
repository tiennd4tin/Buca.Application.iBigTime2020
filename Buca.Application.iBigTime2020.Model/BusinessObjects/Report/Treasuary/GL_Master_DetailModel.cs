/***********************************************************************
 * <copyright file="S34H_GL_Detail_SubDetailModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungNs
 * Email:    tungns@buca.vn
 * Website:
 * Create Date: 28 Dec 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Treasuary
{
    /// <summary>
    /// Class S03BHModel.
    /// </summary>
    public class GL_Master_DetailModel
    {

        public string RefId { get; set; }
        public string RefDetailId { get; set; }
        public int RefType { get; set; }
        public string RefNo { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime RefDate { get; set; }
        public string JournalMemo { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public int MonthYear { get; set; }
        public int DisplayMonth { get; set; }
        public int DetailType { get; set; }
        public decimal Amount { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal ReceiptAmount { get; set; }
        public decimal RevenueAmount { get; set; }
        public decimal SuperiorPaymentAmount { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal OpenAmount { get; set; }
        public int SortOrder { get; set; }
        public int PartId { get; set; }
        public decimal OtherPaymentAmount { get; set; }
    }
}
