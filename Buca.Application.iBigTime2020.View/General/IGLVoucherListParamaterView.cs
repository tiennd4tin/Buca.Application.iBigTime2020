using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;

namespace Buca.Application.iBigTime2020.View.General
{
    public interface IGLVoucherListParamaterView :IView
    {
        string RefDetailId { get; set; }
        string RefId { get; set; }
        int DetailRefType { get; set; }
        string DetailId { get; set; }
        int SortOrder { get; set; }
        int EntryType { get; set; }
        string BudgetSourceId { get; set; }
        DateTime RefDate { get; set; }
        DateTime PostedDate { get; set; }
        string RefNo { get; set; }
        string JournalMemo { get; set; }
        string DebitAccount { get; set; }
        string CreditAccount { get; set; }
        decimal Amount { get; set; }
        string VoucherRefId { get; set; }
        string OrgRefNo { get; set; }
        DateTime OrgRefDate { get; set; }
        string ProjectId { get; set; }
        string FundId { get; set; }
        string BudgetChapterId { get; set; }
        string BudgetSubKindItemId { get; set; }
        string BudgetItemId { get; set; }
        string BudgetSubItemId { get; set; }
    }
}
