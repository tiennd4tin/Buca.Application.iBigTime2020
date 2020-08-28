using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class GLVoucherListEntityDao : IEntityGLVoucherListDao
    {
        private readonly ConvertRefType ConvRefType = new ConvertRefType();
        //private List<BankInfo> banks;
        public List<GLVoucherListEntity> GetGLVoucherLists(string connectionString)
        {
            List<GLVoucherListEntity> buentity = new List<GLVoucherListEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var querry = context.GLVoucherListDetails.ToList();
                //var projects = context.Projects.ToList();
                //var currencys = context.CCies.ToList();
                //var budgetsource = context.BudgetSources.ToList();
                //var listitems = context.ListItems.ToList();
                //var funds = context.Funds.ToList();
                //var fundstructures = context.FundStructures.ToList();
                //var budgetproviders = context.BudgetProvidences.ToList();
                //var accountingobject = context.AccountingObjects.ToList();
                //var projectexpenses = context.ProjectExpenses.ToList();
                //var activity = context.Activities.ToList();
                //var tasks = context.Tasks.ToList();
                //var topics = context.Topics.ToList();
                //banks = context.BankInfoes.ToList();
                //var department = context.Departments.ToList();
                var resultcontext = context.GLVoucherLists.ToList();
                //var fixedasset = context.FixedAssets.ToList();
                //var inventoryitems = context.InventoryItems.ToList();
                //var stocks = context.Stocks.ToList();
                //Detail
                var vouchertype = context.VoucherTypes.ToList();
                foreach (var result in resultcontext)
                {
                    var newresult = new GLVoucherListEntity();
                    newresult.RefId = result.RefID.ToString();
                    newresult.RefType = ConvRefType.ConvRefType(result.RefType);
                    newresult.RefDate = result.RefDate;
                    newresult.RefNo = result.RefNo;
                    newresult.VoucherTypeId = result.VoucherType == null ? null : result.VoucherType.VoucherTypeID.ToString();
                    newresult.SetupType = result.SetupType ?? 0;
                    newresult.FromDate = result.FromDate ?? result.RefDate;
                    newresult.ToDate = result.ToDate ?? result.RefDate;
                    newresult.Description = result.Description;
                    newresult.TotalAmount = result.TotalAmount;
                    newresult.EditVersion = result.EditVersion ?? 0;
                    newresult.GlVoucherListDetails= result.GLVoucherListDetails.Count <= 0 ? null : GLVoucherListDetails(result.GLVoucherListDetails.ToList(), result.RefID.ToString());
                    buentity.Add(newresult);
                }
            }
            return buentity;
        }
        public List<GLVoucherListDetailEntity> GLVoucherListDetails(List<GLVoucherListDetail> details, string refid)
        {
            List<GLVoucherListDetailEntity> lstDetailEntities = new List<GLVoucherListDetailEntity>();

            foreach (var result in details)
            {
                var newresult = new GLVoucherListDetailEntity();
                newresult.RefDetailId = result.RefDetailID.ToString();
                newresult.RefId = refid;
                newresult.DetailRefType = result.DetailRefType??0;
                newresult.DetailId = result.DetailID.ToString();
                newresult.SortOrder = result.SortOrder??0;
                newresult.EntryType = result.EntryType??0;
                //newresult.DetailRefId = result.DetailRefID;
                lstDetailEntities.Add(newresult);
            }
            return lstDetailEntities;
        }
    }
}
