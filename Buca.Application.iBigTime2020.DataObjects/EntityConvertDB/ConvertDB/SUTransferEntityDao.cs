using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class SUTransferEntityDao : IEntitySUTransferDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        //private List<BankInfo> banks;
        public List<SUTransferEntity> GetSUTransfers(string connectionString)
        {
            List<SUTransferEntity> buentity = new List<SUTransferEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.SUTransferDetails.ToList();
                //var projects = context.Projects.ToList();
                //var currencys = context.CCies.ToList();
                //var budgetsource = context.BudgetSources.ToList();
                var listitems = context.ListItems.ToList();
                //var funds = context.Funds.ToList();
                //var fundstructures = context.FundStructures.ToList();
                //var budgetproviders = context.BudgetProvidences.ToList();
                //var accountingobject = context.AccountingObjects.ToList();
                //var projectexpenses = context.ProjectExpenses.ToList();
                //var activity = context.Activities.ToList();
                //var tasks = context.Tasks.ToList();
                //var stocks = context.Stocks.ToList();
                //var topics = context.Topics.ToList();
                //var fixedassets = context.FixedAssets.ToList();
                var departments = context.Departments.ToList();
                //var purchasepurposes = context.PurchasePurposes.ToList();
                var inventoryitems = context.InventoryItems.ToList();
                //banks = context.BankInfoes.ToList();
                var resultcontext = context.SUTransfers.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new SUTransferEntity();
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
                    newresult.SUTransferDetails = result.SUTransferDetails.Count <= 0 ? null : SUTransferDetails(result.SUTransferDetails.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }

        public List<SUTransferDetailEntity> SUTransferDetails(List<SUTransferDetail> details, string refid)
        {
            List<SUTransferDetailEntity> lstDetailEntities = new List<SUTransferDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new SUTransferDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.InventoryItemId = result.InventoryItem == null ? null : result.InventoryItem.InventoryItemID.ToString();
                newresult.Description = result.Description;
                newresult.FromDepartmentId = result.Department==null?null: result.Department.DepartmentID.ToString();
                newresult.ToDepartmentId = result.Department1 == null ? null : result.Department1.DepartmentID.ToString();
                newresult.Unit = result.Unit;
                newresult.Quantity = result.Quantity;
                newresult.UnitPrice = result.UnitPrice;
                newresult.Amount = result.Amount;
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.CreditAccount = result.CreditAccount;
                newresult.DebitAccount = result.DebitAccount;
                newresult.BudgetChapterCode = result.BudgetChapterCode;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
