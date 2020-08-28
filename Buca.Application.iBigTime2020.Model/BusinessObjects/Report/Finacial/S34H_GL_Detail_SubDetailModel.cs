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

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial
{
    /// <summary>
    /// Class S03BHModel.
    /// </summary>
   public class S34H_GL_Detail_SubDetailModel
    {

        public string RefId { get; set; }
        public int RefType { get; set; }
        public string RefNo { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime RefDate { get; set; }
        public string JournalMemo { get; set; }
        public string Description { get; set; }
        public string AccountNumber { get; set; }
        public string CorrespondingAccountNumber { get; set; }
        public int AccountCategoryKind { get; set; }
        public string AccountingObjectId { get; set; }
        public int MonthYear { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal Amount { get; set; }
        public  int ItemCode { get; set; }
        public int SortOrder { get; set; }
    }
}
