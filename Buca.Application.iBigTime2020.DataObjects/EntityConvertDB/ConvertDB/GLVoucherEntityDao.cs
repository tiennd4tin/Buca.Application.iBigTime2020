using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class GLVoucherEntityDao : IEntityGLVoucherDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        private readonly ConvertCashWithdrawType ConvertCash = new ConvertCashWithdrawType();
        private List<BankInfo> banks;
        public List<GLVoucherEntity> GetGLVouchers(string connectionString)
        {
            List<GLVoucherEntity> buentity = new List<GLVoucherEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.GLVoucherDetails.ToList();
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
                var fixedasset = context.FixedAssets.ToList();
                var inventoryitems = context.InventoryItems.ToList();
                var stocks = context.Stocks.ToList();
                var resultcontext = context.GLVouchers.ToList();
                var budgetexpense = context.BudgetExpenses.ToList();
                //Detail
                var butransfers = context.GLVouchers.ToList();
                var parallel = context.GLVoucherDetailParallels.ToList();
                var detailtaxs = context.GLVoucherDetailTaxes.ToList();
                //BATranfers
                var batranfers = context.BATransfers.ToList();
                var batranferdetails = context.BATransferDetails.ToList();
                var batranferparallels = context.BATransferDetailParallels.ToList();
                #region Detail
                foreach (var result in resultcontext)
                {
                    var newresult = new GLVoucherEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.CurrencyCode = result.CCY == null ? null : result.CCY.CurrencyID;
                    newresult.ExchangeRate = result.ExchangeRate;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    newresult.ParentRefId = result.ParentRefID.ToString();
                    newresult.Posted = result.Posted;
                    newresult.PostVersion = result.PostVersion;
                    newresult.EditVersion = result.EditVersion;
                    newresult.AdvancePaymentOrder = result.AdvancePaymentOrder;
                    newresult.BUTransferRefId = string.IsNullOrEmpty(result.QLTSRefNo) ? null : butransfers.FirstOrDefault(x => x.RefNo == result.QLTSRefNo).RefID.ToString();
                    newresult.GLVoucherDetails = result.GLVoucherDetails.Count <= 0 ? null : GLVoucherDetails(result.GLVoucherDetails.ToList(), result.RefID.ToString());
                    newresult.GLVoucherDetailParallels = result.GLVoucherDetailParallels.Count <= 0 ? null : GLVoucherDetailParallels(result.GLVoucherDetailParallels.ToList(), result.RefID.ToString());
                    newresult.GLVoucherDetailTaxes = result.GLVoucherDetailTaxes.Count <= 0 ? null : GLVoucherDetailTaxes(result.GLVoucherDetailTaxes.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
                #endregion

                #region BATranfers
                foreach (var result in batranfers)
                {
                    var newresult = new GLVoucherEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.PostedDate = result.PostedDate;
                    newresult.RefNo = result.RefNo;
                    newresult.CurrencyCode = result.CCY == null ? null : result.CCY.CurrencyID;
                    newresult.ExchangeRate = result.ExchangeRate;
                    newresult.ParalellRefNo = result.ParalellRefNo;
                    newresult.JournalMemo = result.JournalMemo;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.TotalAmountOC = result.TotalAmountOC;
                    //newresult.ParentRefId = result.ParentRefID.ToString();
                    newresult.Posted = result.Posted;
                    newresult.PostVersion = result.PostVersion;
                    newresult.EditVersion = result.EditVersion;
                    //newresult.AdvancePaymentOrder = result.AdvancePaymentOrder;
                    //newresult.BUTransferRefId = string.IsNullOrEmpty(result.QLTSRefNo) ? null : butransfers.FirstOrDefault(x => x.RefNo == result.QLTSRefNo).RefID.ToString();
                    newresult.GLVoucherDetails = result.BATransferDetails.Count <= 0 ? null : GLVoucherDetailFromBATransfers(result.BATransferDetails.ToList(), result.RefID.ToString());
                    newresult.GLVoucherDetailParallels = result.BATransferDetailParallels.Count <= 0 ? null : GLVoucherDetailParallelFromBATransfers(result.BATransferDetailParallels.ToList(), result.RefID.ToString());
                    //newresult.GLVoucherDetailTaxes = result.GLVoucherDetailTaxes.Count <= 0 ? null : GLVoucherDetailTaxes(result.GLVoucherDetailTaxes.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
                #endregion
            }
            return buentity;
        }

        public List<GLVoucherDetailEntity> GLVoucherDetails(List<GLVoucherDetail> details, string refid)
        {
            List<GLVoucherDetailEntity> lstDetailEntities = new List<GLVoucherDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new GLVoucherDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
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
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                newresult.CreditAccountingObjectId = result.AccountingObject1 == null ? null : result.AccountingObject1.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
                newresult.Approved = result.Approved;
                newresult.ParentRefDetailId = result.ParentRefDetailID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                newresult.OrgRefNo = result.OrgRefNo;
                newresult.OrgRefDate = result.OrgRefDate;
                newresult.BankAccount = result.BankAccount;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();
                newresult.BudgetExpenseId = result.BudgetExpense == null ? null : result.BudgetExpense.BudgetExpenseID.ToString();
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<GLVoucherDetailParallelEntity> GLVoucherDetailParallels(List<GLVoucherDetailParallel> details, string refid)
        {
            List<GLVoucherDetailParallelEntity> lstDetailEntities = new List<GLVoucherDetailParallelEntity>();

            foreach (var result in details)
            {
                var newresult = new GLVoucherDetailParallelEntity();
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
        public List<GLVoucherDetailTaxEntity> GLVoucherDetailTaxes(List<GLVoucherDetailTax> details, string refid)
        {
            List<GLVoucherDetailTaxEntity> lstDetailEntities = new List<GLVoucherDetailTaxEntity>();

            foreach (var result in details)
            {
                var newresult = new GLVoucherDetailTaxEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.Description = result.Description;
                newresult.VATAmount = result.VATAmount;
                newresult.VATRate = result.VATRate;
                newresult.TurnOver = result.TurnOver;
                newresult.InvType = result.InvType;
                newresult.InvDate = result.InvDate;
                newresult.InvSeries = result.InvSeries;
                newresult.InvNo = result.InvNo;
                newresult.PurchasePurposeId = result.PurchasePurposeID.ToString();
                newresult.AccountingObjectId = result.AccountingObjectID.ToString();
                newresult.AccountingObjectName = result.AccountingObjectName;
                newresult.AccountingObjectAddress = result.AccountingObjectAddress;
                newresult.CompanyTaxCode = result.CompanyTaxCode;
                newresult.SortOrder = result.SortOrder;
                newresult.InvoiceTypeCode = result.InvoiceTypeCode;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }

        //BATransfers
        public List<GLVoucherDetailEntity> GLVoucherDetailFromBATransfers(List<BATransferDetail> details, string refid)
        {
            List<GLVoucherDetailEntity> lstDetailEntities = new List<GLVoucherDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new GLVoucherDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
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
                newresult.MethodDistributeId = result.MethodDistributeID;
                newresult.CashWithDrawTypeId = ConvertCash.ConvertCash(result.CashWithDrawTypeID);
                newresult.AccountingObjectId = result.AccountingObject == null ? null : result.AccountingObject.AccountingObjectID.ToString();
                //newresult.CreditAccountingObjectId = result.AccountingObject1 == null ? null : result.AccountingObject1.AccountingObjectID.ToString();
                newresult.ActivityId = result.Activity == null ? null : result.Activity.ActivityID.ToString();
                newresult.ProjectId = result.Project == null ? null : result.Project.ProjectID.ToString();
                newresult.ProjectActivityId = result.Project1 == null ? null : result.Project1.ProjectID.ToString();
                newresult.ProjectExpenseId = result.ProjectExpense == null ? null : result.ProjectExpense.ProjectExpenseID.ToString();
                newresult.TaskId = result.Task == null ? null : result.Task.TaskID.ToString();
                newresult.ListItemId = result.ListItem == null ? null : result.ListItem.ListItemID.ToString();
               // newresult.Approved = result.Approved;
               // newresult.ParentRefDetailId = result.ParentRefDetailID.ToString();
                newresult.SortOrder = result.SortOrder;
                newresult.BudgetDetailItemCode = result.BudgetDetailItemCode;
                //newresult.OrgRefNo = result.OrgRefNo;
                //newresult.OrgRefDate = result.OrgRefDate;
                //newresult.BankAccount = result.BankAccount;
                newresult.FundStructureId = result.FundStructure == null ? null : result.FundStructure.FundStructureID.ToString();
                newresult.ProjectExpenseEAId = result.ProjectExpense1 == null ? null : result.ProjectExpense1.ProjectExpenseID.ToString();
                newresult.ProjectActivityEAId = result.Project2 == null ? null : result.Project2.ProjectID.ToString();
                newresult.BudgetProvideCode = result.BudgetProvidence == null ? null : result.BudgetProvidence.BudgetProvideCode;
                //newresult.TopicId = result.Topic == null ? null : result.Topic.TopicID.ToString();
                //newresult.BudgetExpenseId = result.BudgetExpense == null ? null : result.BudgetExpense.BudgetExpenseID.ToString();
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
        public List<GLVoucherDetailParallelEntity> GLVoucherDetailParallelFromBATransfers(List<BATransferDetailParallel> details, string refid)
        {
            List<GLVoucherDetailParallelEntity> lstDetailEntities = new List<GLVoucherDetailParallelEntity>();

            foreach (var result in details)
            {
                var newresult = new GLVoucherDetailParallelEntity();
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
