using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Cash;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BUPlanReceiptEntityDao : IEntityBUPlanReceiptDao
    {
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<BUPlanReceiptEntity> GetBuPlanReceipts(string connectionString)
        {
            List<BUPlanReceiptEntity> buplanreceipts = new List<BUPlanReceiptEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.BUPlanReceiptDetails.ToList();
                var projects = context.Projects.ToList();
                var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
                var listitems = context.ListItems.ToList();
                var fundstructures = context.FundStructures.ToList();
                var budgetproviders = context.BudgetProvidences.ToList();
                banks = context.BankInfoes.ToList();
                var categories = context.BUPlanReceipts.ToList();
                foreach (var result in categories)
                {
                    var buplan = new BUPlanReceiptEntity();
                    buplan.RefId = result.RefID.ToString();
                    buplan.RefType = result.RefType;
                    buplan.RefDate = result.RefDate;
                    buplan.PostedDate = result.PostedDate;
                    buplan.RefNo = result.RefNo;
                    buplan.CurrencyCode = result.CCY == null ? null : result.CCY.CurrencyID;
                    buplan.ExchangeRate = result.ExchangeRate ?? 0;
                    buplan.ParalellRefNo = result.ParalellRefNo;
                    buplan.DecisionDate = result.DecisionDate;
                    buplan.DecisionNo = result.DecisionNo;
                    buplan.BudgetChapterCode = result.BudgetChapterCode;
                    buplan.JournalMemo = result.JournalMemo;
                    buplan.Posted = result.Posted;
                    buplan.TotalAmount = result.TotalAmount;
                    buplan.TotalAmountOC = result.TotalAmountOC;
                    buplan.AllocationConfig = result.AllocationConfig;
                    buplan.BuPlanReceiptDetails = BuPlanReceiptDetails(result.BUPlanReceiptDetails.ToList(), result.RefID.ToString());
                    buplanreceipts.Add(buplan);
                }
            }

            return buplanreceipts;
        }

        public List<BUPlanReceiptDetailEntity> BuPlanReceiptDetails(List<BUPlanReceiptDetail> buPlanDetail, string refid)
        {
            List<BUPlanReceiptDetailEntity> lstBuPlanReceiptDetailEntities = new List<BUPlanReceiptDetailEntity>();

            foreach (var buPlan in buPlanDetail)
            {
                var objBuPlanReceipt = new BUPlanReceiptDetailEntity();
                objBuPlanReceipt.RefDetailId = buPlan.RefDetailID.ToString();
                objBuPlanReceipt.RefId = refid;
                objBuPlanReceipt.Description = buPlan.Description;
                objBuPlanReceipt.BudgetSourceId = buPlan.BudgetSource == null ? null : buPlan.BudgetSource.BudgetSourceID.ToString();
                objBuPlanReceipt.BudgetKindItemCode = buPlan.BudgetKindItemCode;
                objBuPlanReceipt.BudgetSubKindItemCode = buPlan.BudgetSubKindItemCode;
                objBuPlanReceipt.BudgetGroupItemCode = buPlan.BudgetGroupItemCode;
                objBuPlanReceipt.BudgetItemCode = buPlan.BudgetItemCode;
                objBuPlanReceipt.BudgetSubItemCode = buPlan.BudgetSubItemCode;
                objBuPlanReceipt.DebitAccount = buPlan.DebitAccount;
                objBuPlanReceipt.Amount = buPlan.Amount;
                objBuPlanReceipt.AmountOC = buPlan.AmountOC;
                objBuPlanReceipt.ProjectId = buPlan.Project == null ? null : buPlan.Project.ProjectID.ToString();
                objBuPlanReceipt.ListItemId = buPlan.ListItem == null ? null : buPlan.ListItem.ListItemID.ToString();
                objBuPlanReceipt.SortOrder = buPlan.SortOrder ?? 0;
                objBuPlanReceipt.BudgetDetailItemCode = buPlan.BudgetDetailItemCode;
                objBuPlanReceipt.FundStructureId = buPlan.FundStructure == null ? null : buPlan.FundStructure.FundStructureID.ToString();
                objBuPlanReceipt.BankId = buPlan.BankAccount == null ? null : banks.FirstOrDefault(x => x.BankAccount == buPlan.BankAccount).BankInfoID.ToString();
                objBuPlanReceipt.ProjectActivityEAId = buPlan.Project1 == null ? null : buPlan.Project1.ProjectID.ToString();
                objBuPlanReceipt.AmountQuater1 = buPlan.AmountQuater1;
                objBuPlanReceipt.AmountQuater1OC = buPlan.AmountQuater1OC;
                objBuPlanReceipt.AmountQuater2 = buPlan.AmountQuater2;
                objBuPlanReceipt.AmountQuater2OC = buPlan.AmountQuater2OC;
                objBuPlanReceipt.AmountQuater3 = buPlan.AmountQuater3;
                objBuPlanReceipt.AmountQuater3OC = buPlan.AmountQuater3OC;
                objBuPlanReceipt.AmountQuater4 = buPlan.AmountQuater4;
                objBuPlanReceipt.AmountQuater4OC = buPlan.AmountQuater4OC;
                objBuPlanReceipt.AmountMonth1 = buPlan.AmountMonth1;
                objBuPlanReceipt.AmountMonth1OC = buPlan.AmountMonth1OC;
                objBuPlanReceipt.AmountMonth2 = buPlan.AmountMonth2;
                objBuPlanReceipt.AmountMonth2OC = buPlan.AmountMonth2OC;
                objBuPlanReceipt.AmountMonth3 = buPlan.AmountMonth3;
                objBuPlanReceipt.AmountMonth3OC = buPlan.AmountMonth3OC;
                objBuPlanReceipt.AmountMonth4 = buPlan.AmountMonth4;
                objBuPlanReceipt.AmountMonth4OC = buPlan.AmountMonth4OC;
                objBuPlanReceipt.AmountMonth5 = buPlan.AmountMonth5;
                objBuPlanReceipt.AmountMonth5OC = buPlan.AmountMonth5OC;
                objBuPlanReceipt.AmountMonth6 = buPlan.AmountMonth6;
                objBuPlanReceipt.AmountMonth6OC = buPlan.AmountMonth6OC;
                objBuPlanReceipt.AmountMonth7 = buPlan.AmountMonth7;
                objBuPlanReceipt.AmountMonth7OC = buPlan.AmountMonth7OC;
                objBuPlanReceipt.AmountMonth8 = buPlan.AmountMonth8;
                objBuPlanReceipt.AmountMonth8OC = buPlan.AmountMonth8OC;
                objBuPlanReceipt.AmountMonth9 = buPlan.AmountMonth9;
                objBuPlanReceipt.AmountMonth9OC = buPlan.AmountMonth9OC;
                objBuPlanReceipt.AmountMonth10 = buPlan.AmountMonth10;
                objBuPlanReceipt.AmountMonth10OC = buPlan.AmountMonth10OC;
                objBuPlanReceipt.AmountMonth11 = buPlan.AmountMonth11;
                objBuPlanReceipt.AmountMonth11OC = buPlan.AmountMonth11OC;
                objBuPlanReceipt.AmountMonth12 = buPlan.AmountMonth12;
                objBuPlanReceipt.AmountMonth12OC = buPlan.AmountMonth12OC;
                objBuPlanReceipt.BudgetProvideCode = buPlan.BudgetProvidence == null ? null : buPlan.BudgetProvidence.BudgetProvideCode;
                //objBuPlanReceipt.MethodDistributeId = buPlan.m;
                //objBuPlanReceipt.BudgetParentItemCode = buPlan.BudgetDetailItemCode;

                lstBuPlanReceiptDetailEntities.Add(objBuPlanReceipt);

            }
            return lstBuPlanReceiptDetailEntities;
        }
    }
}
