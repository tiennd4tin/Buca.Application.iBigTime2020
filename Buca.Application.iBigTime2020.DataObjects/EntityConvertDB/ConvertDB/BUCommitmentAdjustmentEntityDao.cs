using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BUCommitmentAdjustmentEntityDao: IEntityBUCommitmentAdjustmentDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<BUCommitmentAdjustmentEntity> GetBUCommitmentAdjustments(string connectionString)
        {
            List<BUCommitmentAdjustmentEntity> buentity = new List<BUCommitmentAdjustmentEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.BUCommitmentAdjustmentDetails.ToList();
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
                var resultcontext = context.BUCommitmentAdjustments.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new BUCommitmentAdjustmentEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.BUCommitmentRequestId = result.BUCommitmentRequestID.ToString();
                    newresult.ContractNo = result.ContractNo;
                    newresult.ContractFrameNo = result.ContractFrameNo;
                    newresult.RealContractNo = result.RealContractNo;
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.IsForeignCurrency = result.IsForeignCurrency;
                    newresult.Posted = result.Posted;
                    newresult.EditVersion = result.EditVersion;
                    newresult.PostVersion = result.PostVersion;
                    newresult.IsSuggestAdjustment = result.IsSuggestAdjustment;
                    newresult.IsSuggestSupplement = result.IsSuggestSupplement;
                    newresult.AdjustmentProviderBankAccount = result.AdjustmentProviderBankAccount;
                    newresult.AdjustmentProviderBankName = result.AdjustmentProviderBankName;
                    newresult.BankAccount = result.BankAccount;
                    newresult.BankName = result.BankName;
                    newresult.BUCommitmentAdjustmentDetails = BUCommitmentAdjustmentDetails(result.BUCommitmentAdjustmentDetails.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
        public List<BUCommitmentAdjustmentDetailEntity> BUCommitmentAdjustmentDetails(List<BUCommitmentAdjustmentDetail> details, string refid)
        {
            List<BUCommitmentAdjustmentDetailEntity> lstDetailEntities = new List<BUCommitmentAdjustmentDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new BUCommitmentAdjustmentDetailEntity();
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
                newresult.ToCurrencyCode = result.ToCurrencyID;
                newresult.ToExchangeRate = result.ToExchangeRate;
                newresult.ToAmountOC = result.ToAmountOC;
                newresult.ToAmount = result.ToAmount;
                newresult.ToBudgetSourceId = result.ToBudgetSourceID.ToString();
                newresult.ToBudgetProvideCode = result.ToBudgetProvideCode;
                newresult.ToBudgetChapterCode = result.ToBudgetChapterCode;
                newresult.ToBudgetKindItemCode = result.ToBudgetKindItemCode;
                newresult.ToBudgetSubKindItemCode = result.ToBudgetSubKindItemCode;
                newresult.ToBudgetItemCode = result.ToBudgetItemCode;
                newresult.ToBudgetSubItemCode = result.ToBudgetSubItemCode;
                newresult.ToProjectId = result.ToProjectID.ToString();
                newresult.RemainAmountOC = result.RemainAmountOC;
                newresult.RemainAmount = result.RemainAmount;
                newresult.RemainExchangeRate = result.RemainExchangeRate;
                newresult.RemainCurrencyCode = result.RemainCurrencyID;
                //newresult.BUCommitmentRequestDetailId = result.id;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
