using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BUVoucherListEntityDao : IEntityBUVoucherListDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<BUVoucherListEntity> GetBUVoucherLists(string connectionString)
        {
            List<BUVoucherListEntity> buentity = new List<BUVoucherListEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.BUVoucherListDetails.ToList();
                var projects = context.Projects.ToList();
                var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
                var listitems = context.ListItems.ToList();
                var funds = context.Funds.ToList();
                var fundstructures = context.FundStructures.ToList();
                var budgetproviders = context.BudgetProvidences.ToList();
                var accountingobject = context.AccountingObjects.ToList();
                var projectexpenses = context.ProjectExpenses.ToList();
                var activity = context.Activities.ToList();
                var tasks = context.Tasks.ToList();
                var topics = context.Topics.ToList();
                banks = context.BankInfoes.ToList();
                var parallel = context.BUVoucherListDetailParallels.ToList();
                var detailtransfers = context.BUVoucherListDetailTransfers.ToList();
                var resultcontext = context.BUVoucherLists.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new BUVoucherListEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.FromDate = result.FromDate;
                    newresult.ToDate = result.ToDate;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.Posted = result.Posted;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.PostVersion = result.PostVersion;
                    newresult.EditVersion = result.EditVersion;
                    newresult.BUVoucherListDetailEntities = result.BUVoucherListDetails.Count <= 0 ? null : BUVoucherListDetails(result.BUVoucherListDetails.ToList(), result.RefID.ToString());
                    newresult.BUVoucherListDetailParallelEntities = result.BUVoucherListDetailParallels.Count <= 0 ? null : BuVoucherListDetailParallels(result.BUVoucherListDetailParallels.ToList(), result.RefID.ToString());
                    newresult.BUVoucherListDetailTransferEntities = result.BUVoucherListDetailTransfers.Count <= 0 ? null : BUVoucherListDetailTransfers(result.BUVoucherListDetailTransfers.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }

        public List<BUVoucherListDetailEntity> BUVoucherListDetails(List<BUVoucherListDetail> details, string refid)
        {
            List<BUVoucherListDetailEntity> lstDetailEntities = new List<BUVoucherListDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new BUVoucherListDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.VoucherRefType = result.VoucherRefType;
                newresult.VoucherRefDetailId = result.VoucherRefDetailID.ToString();
                newresult.RefDate = result.RefDate;
                newresult.PostedDate = result.PostedDate;
                newresult.RefNo = result.RefNo;
                newresult.Description = result.Description;
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Amount = result.Amount;
                newresult.BudgetSourceId = result.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithdrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                newresult.ProjectId = result.ProjectID.ToString();
                newresult.ActivityId = result.ActivityID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.Approved = result.Approved;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.AmountOC = result.AmountOC;
                newresult.CurrencyCode = result.CurrencyID;
                newresult.ExchangeRate = result.ExchangeRate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankAccount = result.BankAccount;
                newresult.AccountingObjectId = result.AccountingObjectID.ToString();
                newresult.ProjectActivityId = result.ProjectActivityID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpenseID.ToString();
                newresult.VoucherRefId = result.VoucherRefDetailID.ToString();
                newresult.ListItemId = result.ListItemID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpenseEAID.ToString();
                newresult.ProjectActivityEAId = result.ProjectActivityEAID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                //newresult.BudgetExpenseId = result.budgete;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BUVoucherListDetailParallelEntity> BuVoucherListDetailParallels(List<BUVoucherListDetailParallel> details, string refid)
        {
            List<BUVoucherListDetailParallelEntity> lstDetailEntities = new List<BUVoucherListDetailParallelEntity>();

            foreach (var result in details)
            {
                var newresult = new BUVoucherListDetailParallelEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.ParentRefDetailId = result.ParentRefDetailID.ToString();
                newresult.RefId = refid;
                newresult.Description = result.Description;
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Amount = result.Amount;
                newresult.AmountOC = result.AmountOC;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithdrawTypeId = ConvertCash.ConvertCash(result.CashWithdrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.Approved = result.Approved;
                newresult.SortOrder = result.SortOrder;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankAccount = result.BankAccount;
                newresult.BudgetExpenseId = result.BudgetExpenseID.ToString();

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BUVoucherListDetailTransferEntity> BUVoucherListDetailTransfers(List<BUVoucherListDetailTransfer> details, string refid)
        {
            List<BUVoucherListDetailTransferEntity> lstDetailEntities = new List<BUVoucherListDetailTransferEntity>();

            foreach (var result in details)
            {
                var newresult = new BUVoucherListDetailTransferEntity();

                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.Amount = result.Amount;
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Description = result.Description;
                newresult.ActivityId = result.ActivityID.ToString();
                newresult.ProjectId = result.ProjectID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.AmountOC = result.AmountOC;
                newresult.CurrencyCode = result.CurrencyID;
                newresult.ExchangeRate = result.ExchangeRate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankAccount = result.BankAccount;
                newresult.AccountingObjectId = result.AccountingObjectID.ToString();
                newresult.ProjectActivityId = result.ProjectActivityID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpenseID.ToString();
                newresult.ListItemId = result.ListItemID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpenseEAID.ToString();
                newresult.ProjectActivityEAId = result.ProjectActivityEAID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                //newresult.BudgetExpenseId = result.budgete;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
