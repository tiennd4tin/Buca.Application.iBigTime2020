using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class SUIncrementDecrementEntityDao : IEntitySUIncrementDecrementDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        //private List<BankInfo> banks;
        public List<SUIncrementDecrementEntity> GetSUIncrementDecrements(string connectionString)
        {
            List<SUIncrementDecrementEntity> buentity = new List<SUIncrementDecrementEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.SUIncrementDecrementDetails.ToList();
                //var projects = context.Projects.ToList();
                //var currencys = context.CCies.ToList();
                var budgetsource = context.BudgetSources.ToList();
                var listitems = context.ListItems.ToList();
                //var funds = context.Funds.ToList();
                //var fundstructures = context.FundStructures.ToList();
                var budgetproviders = context.BudgetProvidences.ToList();
                var accountingobject = context.AccountingObjects.ToList();
                //var projectexpenses = context.ProjectExpenses.ToList();
                //var activity = context.Activities.ToList();
                //var tasks = context.Tasks.ToList();
                //var stocks = context.Stocks.ToList();
                var topics = context.Topics.ToList();
                //var fixedassets = context.FixedAssets.ToList();
                var departments = context.Departments.ToList();
                //var purchasepurposes = context.PurchasePurposes.ToList();
                var inventoryitems = context.InventoryItems.ToList();
                // banks = context.BankInfoes.ToList();
                var resultcontext = context.SUIncrementDecrements.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new SUIncrementDecrementEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.EditVersion = result.EditVersion;
                    newresult.SUIncrementDecrementDetails = result.SUIncrementDecrementDetails.Count <= 0 ? null : SUIncrementDecrementDetails(result.SUIncrementDecrementDetails.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }

        public List<SUIncrementDecrementDetailEntity> SUIncrementDecrementDetails(List<SUIncrementDecrementDetail> details, string refid)
        {
            List<SUIncrementDecrementDetailEntity> lstDetailEntities = new List<SUIncrementDecrementDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new SUIncrementDecrementDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.InventoryItemId = result.InventoryItem == null ? null : result.InventoryItem.InventoryItemID.ToString();
                newresult.Description = result.Description;
                newresult.DepartmentId = result.Department == null ? null : result.Department.DepartmentID.ToString();
                newresult.DebitAccount = result.DebitAccount;
                newresult.CreditAccount = result.CreditAccount;
                newresult.Quantity = result.Quantity;
                newresult.QuantityConvert = result.QuantityConvert;
                newresult.UnitPrice = result.UnitPrice;
                newresult.UnitPriceConvert = result.UnitPriceConvert;
                newresult.Amount = result.Amount;
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetSourceId = result.BudgetSource == null ? null : result.BudgetSource.BudgetSourceID.ToString();
                newresult.BudgetKindItemCode = result.BudgetKindItemCode;
                newresult.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();

                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
