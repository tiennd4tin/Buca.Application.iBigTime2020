using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BUPlanWithdrawEntityDao : IEntityBUPlanWithdrawDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<BUPlanWithdrawEntity> GetBUPlanWithdraws(string connectionString)
        {
            List<BUPlanWithdrawEntity> buplanwithdraws = new List<BUPlanWithdrawEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.BUPlanWithdrawDetails.ToList();
                var projects = context.Projects.ToList();
                var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
                var listitems = context.ListItems.ToList();
                var fundstructures = context.FundStructures.ToList();
                var budgetproviders = context.BudgetProvidences.ToList();
                var accountingobject = context.AccountingObjects.ToList();
                banks = context.BankInfoes.ToList();
                var resultcontext = context.BUPlanWithdraws.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new BUPlanWithdrawEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.CashWithDrawType = result.CashWithDrawType;
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.CurrencyCode = result.CCY == null ? null : result.CCY.CurrencyID;
                    newresult.ExchangeRate = result.ExchangeRate;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.TargetProgramId = result.Project == null? null: result.Project.ProjectID.ToString();
                    newresult.BankId = result.BankInfo.BankInfoID.ToString();
                    newresult.AccountingObjectId = result.AccountingObject == null? null: result.AccountingObject.AccountingObjectID.ToString();
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.GeneratedRefId = result.GeneratedRefID.ToString();
                    newresult.Posted = result.Posted;
                    newresult.BUCommitmentRequestId = result.BUCommitmentRequestID.ToString();
                    newresult.AccountingObjectBankId = result.AccountingObjectBankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.AccountingObjectBankAccount).BankInfoID.ToString();
                    //newresult.CAReceiptRefId = result.id;
                    //newresult.LinkRefNo = result.l;
                    //newresult.BeneficiaryAccount = result.BeneficiaryAccount;
                    //newresult.BeneficiaryBank = result.BeneficiaryBank;
                    //newresult.BudgetExpenseID = result.BudgetExpenseID;
                    newresult.BUPlanWithdrawDetails = BuPlanWithDrawDetails(result.BUPlanWithdrawDetails.ToList(), newresult.RefId);
                    buplanwithdraws.Add(newresult);
                }
            }

            return buplanwithdraws;
        }
        public List<BUPlanWithdrawDetailEntity> BuPlanWithDrawDetails(List<BUPlanWithdrawDetail> details, string refid)
        {
            List<BUPlanWithdrawDetailEntity> lstBuPlanReceiptDetailEntities = new List<BUPlanWithdrawDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new BUPlanWithdrawDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.Description = result.Description;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetItemCode = result.BudgetItemCode;
                newresult.BudgetSubItemCode = result.BudgetSubItemCode;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Amount = result.Amount;
                newresult.AmountOC = result.AmountOC;
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.BankId = result.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == result.BankAccount).BankInfoID.ToString();
                newresult.ProjectActivityEAId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                //newresult.BudgetExpenseId = result.buget
                lstBuPlanReceiptDetailEntities.Add(newresult);
            }
            return lstBuPlanReceiptDetailEntities;
        }
    }
}
