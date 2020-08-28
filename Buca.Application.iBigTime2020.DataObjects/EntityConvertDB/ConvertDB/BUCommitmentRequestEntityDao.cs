using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BUCommitmentRequestEntityDao : IEntityBUCommitmentRequestDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<BUCommitmentRequestEntity> GetBUCommitmentRequests(string connectionString)
        {
            List<BUCommitmentRequestEntity> buentity = new List<BUCommitmentRequestEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.BUCommitmentRequestDetails.ToList();
                var projects = context.Projects.ToList();
                var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
                var listitems = context.ListItems.ToList();
                var fundstructures = context.FundStructures.ToList();
                var budgetproviders = context.BudgetProvidences.ToList();
                var accountingobject = context.AccountingObjects.ToList();
                var projectexpenses = context.ProjectExpenses.ToList();
                var activity = context.Activities.ToList();
                var tasks = context.Tasks.ToList();
                banks = context.BankInfoes.ToList();
                var resultcontext = context.BUCommitmentRequests.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new BUCommitmentRequestEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                    newresult.AccountingObjectName = result.AccountingObjectName;
                    newresult.TABMISCode = result.TABMISCode;
                    newresult.BankAccount = result.BankAccount;
                    newresult.BankName = result.BankName;
                    newresult.ContractNo = result.ContractNo;
                    newresult.ContractFrameNo = result.ContractFrameNo;
                    newresult.BudgetSourceKind = result.BudgetSourceKind;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.IsForeignCurrency = result.IsForeignCurrency;
                    newresult.Posted = result.Posted;
                    newresult.EditVersion = result.EditVersion;
                    newresult.PostVersion = result.PostVersion;
                    newresult.ProjectInvestmentCode = result.ProjectInvestmentCode;
                    newresult.ProjectInvestmentName = result.ProjectInvestmentName;
                    newresult.SignDate = result.SignDate;
                    newresult.ContractAmount = result.ContractAmount;
                    newresult.PrevYearCommitmentAmount = result.PrevYearCommitmentAmount ?? 0;
                    newresult.BUCommitmentRequestDetails = BUCommitmentRequestDetails(result.BUCommitmentRequestDetails.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
        public List<BUCommitmentRequestDetailEntity> BUCommitmentRequestDetails(List<BUCommitmentRequestDetail> details, string refid)
        {
            List<BUCommitmentRequestDetailEntity> lstDetailEntities = new List<BUCommitmentRequestDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new BUCommitmentRequestDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.Description = result.Description;
                newresult.CurrencyCode = result.CCY == null ? null : result.CCY.CurrencyID;
                newresult.ExchangeRate = result.ExchangeRate;
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
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.ProjectActivityID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.Approved = result.Approved;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BankAccount = result.BankAccount;
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
