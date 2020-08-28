using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BABankTransferEntityDao : IEntityBABankTransferDao
    {
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private List<BankInfo> banks;
        public List<BABankTransferEntity> GetBABankTransfers(string connectionString)
        {
            List<BABankTransferEntity> buentity = new List<BABankTransferEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.BABankTransferDetails.ToList();
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
                var department = context.Departments.ToList();
                var resultcontext = context.BABankTransfers.ToList();
                var fixedasset = context.FixedAssets.ToList();
                var inventoryitems = context.InventoryItems.ToList();
                var stocks = context.Stocks.ToList();
                //Detail
                var parallel = context.BABankTransferDetailParallels.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new BABankTransferEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.Posted = result.Posted;
                    newresult.PostVersion = result.PostVersion;
                    newresult.EditVersion = result.EditVersion;
                    newresult.CurrencyCode = result.CCY == null ? null : result.CCY.CurrencyID;
                    newresult.ExchangeRate = result.ExchangeRate ?? 0;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.BABankTransferDetails = result.BABankTransferDetails.Count <= 0 ? null : BABankTransferDetails(result.BABankTransferDetails.ToList(), result.RefID.ToString());
                    newresult.BABankTransferDetailParallels = result.BABankTransferDetailParallels.Count <= 0 ? null : BABankTransferDetailParallels(result.BABankTransferDetailParallels.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
        public List<BABankTransferDetailEntity> BABankTransferDetails(List<BABankTransferDetail> details, string refid)
        {
            List<BABankTransferDetailEntity> lstDetailEntities = new List<BABankTransferDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new BABankTransferDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.Description = result.Description;
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.FromBankId = result.FromBankAccount == null && banks == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.FromBankAccount).BankInfoID.ToString();
                newresult.ToBankId = result.ToBankAccount == null && banks == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.ToBankAccount).BankInfoID.ToString();
                newresult.Amount = result.Amount;
                newresult.BudgetSourceId = result.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.AccountingObjectId = result.AccountingObjectID.ToString();
                newresult.ActivityId = result.ActivityID.ToString();
                newresult.ProjectId =  result.ProjectID.ToString();
                newresult.ProjectActivityId = result.ProjectActivityID.ToString();
                newresult.ListItemId = result.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.AmountOC = result.AmountOC;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectActivityEAId = result.Project == null ? null : result.Project.ProjectID.ToString();
                //newresult.BudgetExpenseId = result.Budgete;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<BABankTransferDetailParallelEntity> BABankTransferDetailParallels(List<BABankTransferDetailParallel> details, string refid)
        {
            List<BABankTransferDetailParallelEntity> lstDetailEntities = new List<BABankTransferDetailParallelEntity>();

            foreach (var result in details)
            {
                var newresult = new BABankTransferDetailParallelEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.ParentRefDetailId = result.ParentRefDetailID.ToString();
                newresult.RefId = refid;
                newresult.Description = result.Description;
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Amount = result.Amount;
                newresult.AmountOC = result.AmountOC;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithdrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.FundId = result.Fund == null ? null : result.Fund.FundID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();
                newresult.BudgetExpenseId = result.BudgetExpenseID.ToString();
                newresult.Approved = result.Approved;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
