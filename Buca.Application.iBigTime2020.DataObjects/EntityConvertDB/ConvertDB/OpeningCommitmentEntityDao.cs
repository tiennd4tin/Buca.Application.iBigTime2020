using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class OpeningCommitmentEntityDao : IEntityOpeningCommitmentDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        //private List<BankInfo> banks;
        public List<OpeningCommitmentEntity> GetOpeningCommitments(string connectionString)
        {
            List<OpeningCommitmentEntity> buentity = new List<OpeningCommitmentEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.OpeningCommitmentDetails.ToList();
                //var projects = context.Projects.ToList();
                // var currencys = context.CCies.ToList();
                //var budgetsource = context.BudgetSources.ToList();
                //var listitems = context.ListItems.ToList();
                //var fundstructures = context.FundStructures.ToList();
                var budgetproviders = context.BudgetProvidences.ToList();
                //var accountingobject = context.AccountingObjects.ToList();
                //var projectexpenses = context.ProjectExpenses.ToList();
                //var activity = context.Activities.ToList();
                //var tasks = context.Tasks.ToList();
                //banks = context.BankInfoes.ToList();
                var resultcontext = context.OpeningCommitments.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new OpeningCommitmentEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefDate = result.PostedDate;//DB misa không có field refdate
                    newresult.RefNo = result.RefNo;
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.BudgetSourceKind = result.BudgetSourceKind;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.IsForeignCurrency = result.IsForeignCurrency;
                    newresult.EditVersion = result.EditVersion;
                    newresult.PostVersion = result.PostVersion;
                    newresult.AccountingObjectId = result.AccountingObjectID.ToString();
                    newresult.AccountingObjectName = result.AccountingObjectName;
                    newresult.TABMISCode = result.TABMISCode;
                    newresult.BankAccount = result.BankAccount;
                    newresult.BankName = result.BankName;
                    newresult.ContractNo = result.ContractNo;
                    newresult.ContractFrameNo = result.ContractFrameNo;
                    newresult.ProjectInvestmentCode = result.ProjectInvestmentCode;
                    newresult.ProjectInvestmentName = result.ProjectInvestmentName;
                    newresult.SignDate = result.SignDate;
                    newresult.ContractAmount = result.ContractAmount;
                    newresult.PrevYearCommitmentAmount = result.PrevYearCommitmentAmount;
                    newresult.OpeningCommitmentDetails = OpeningCommitmentDetails(result.OpeningCommitmentDetails.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
        public List<OpeningCommitmentDetailEntity> OpeningCommitmentDetails(List<OpeningCommitmentDetail> details, string refid)
        {
            List<OpeningCommitmentDetailEntity> lstDetailEntities = new List<OpeningCommitmentDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new OpeningCommitmentDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.Description = result.Description;
                newresult.CurrencyId = result.CurrencyID;
                newresult.ExchangeRate = result.ExchangeRate;
                newresult.Amount = result.Amount;
                newresult.AmountOC = result.AmountOC;
                newresult.BudgetSourceId = result.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.ActivityId = result.ActivityID.ToString();
                newresult.ProjectId = result.ProjectID.ToString();
                newresult.ProjectActivityId = result.ProjectActivityID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpenseID.ToString();
                newresult.TaskId = result.TaskID.ToString();
                newresult.ListItemId = result.ListItemID.ToString();
                newresult.Approved = result.Approved;
                newresult.FundStructureId = result.FundStructureID.ToString();
                newresult.BankAccount = result.BankAccount;
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
