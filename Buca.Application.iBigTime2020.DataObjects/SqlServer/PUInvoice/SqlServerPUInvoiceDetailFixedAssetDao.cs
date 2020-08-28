using Buca.Application.iBigTime2020.BusinessEntities.Business.PUInvoice;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.PUInvoice;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.PUInvoice
{
    public class SqlServerPUInvoiceDetailFixedAssetDao : DaoBase, IPUInvoiceDetailFixedAssetDao
    {
        public List<PUInvoiceDetailFixedAssetEntity> GetPUInvoiceDetailFixedAssets(string refId)
        {
            const string procedures = @"uspGet_PUInvoiceDetailFixedAssets_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make<PUInvoiceDetailFixedAssetEntity>, parms);
        }

        public string DeletePUInvoiceDetailFixedAssets(string refId)
        {
            const string procedures = @"uspDelete_PUInvoiceDetailFixedAssets_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        public string UpdatePUInvoiceDetailFixedAsset(PUInvoiceDetailFixedAssetEntity entity)
        {
            const string procedures = @"uspInsert_PUInvoiceDetailFixedAsset";
            return Db.Insert(procedures, true, Take(entity));
        }

        private static object[] Take(PUInvoiceDetailFixedAssetEntity pUInvoiceDetailFixedAssetEntity)
        {
            return new object[]
            {
                "@RefDetailID",pUInvoiceDetailFixedAssetEntity.RefDetailId,
                "@RefID",pUInvoiceDetailFixedAssetEntity.RefId,
                "@FixedAssetID",pUInvoiceDetailFixedAssetEntity.FixedAssetId,
                "@Description",pUInvoiceDetailFixedAssetEntity.Description,
                "@DepartmentID",pUInvoiceDetailFixedAssetEntity.DepartmentId,
                "@DebitAccount",pUInvoiceDetailFixedAssetEntity.DebitAccount,
                "@CreditAccount",pUInvoiceDetailFixedAssetEntity.CreditAccount,
                "@Amount",pUInvoiceDetailFixedAssetEntity.Amount,
                "@TaxRate",pUInvoiceDetailFixedAssetEntity.TaxRate,
                "@TaxAmount",pUInvoiceDetailFixedAssetEntity.TaxAmount,
                "@TaxAccount",pUInvoiceDetailFixedAssetEntity.TaxAccount,
                "@InvDate",pUInvoiceDetailFixedAssetEntity.InvDate,
                "@InvSeries",pUInvoiceDetailFixedAssetEntity.InvSeries,
                "@InvNo",pUInvoiceDetailFixedAssetEntity.InvNo,
                "@InvType",pUInvoiceDetailFixedAssetEntity.InvType,
                "@InvoiceTypeCode",pUInvoiceDetailFixedAssetEntity.InvoiceTypeCode,
                "@PurchasePurposeID",pUInvoiceDetailFixedAssetEntity.PurchasePurposeId,
                "@FreightAmount",pUInvoiceDetailFixedAssetEntity.FreightAmount,
                "@OrgPrice",pUInvoiceDetailFixedAssetEntity.OrgPrice,
                "@BudgetSourceID",pUInvoiceDetailFixedAssetEntity.BudgetSourceId,
                "@BudgetChapterCode",pUInvoiceDetailFixedAssetEntity.BudgetChapterCode,
                "@BudgetKindItemCode",pUInvoiceDetailFixedAssetEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",pUInvoiceDetailFixedAssetEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",pUInvoiceDetailFixedAssetEntity.BudgetItemCode,
                "@BudgetSubItemCode",pUInvoiceDetailFixedAssetEntity.BudgetSubItemCode,
                "@MethodDistributeID",pUInvoiceDetailFixedAssetEntity.MethodDistributeId,
                "@CashWithDrawTypeID",pUInvoiceDetailFixedAssetEntity.CashWithDrawTypeId,
                "@AccountingObjectID",pUInvoiceDetailFixedAssetEntity.AccountingObjectId,
                "@ActivityID",pUInvoiceDetailFixedAssetEntity.ActivityId,
                "@ProjectID",pUInvoiceDetailFixedAssetEntity.ProjectId,
                "@ProjectActivityID",pUInvoiceDetailFixedAssetEntity.ProjectActivityId,
                "@ProjectExpenseID",pUInvoiceDetailFixedAssetEntity.ProjectExpenseId,
                "@TaskID",pUInvoiceDetailFixedAssetEntity.TaskId,
                "@ListItemID",pUInvoiceDetailFixedAssetEntity.ListItemId,
                "@Approved",pUInvoiceDetailFixedAssetEntity.Approved,
                "@SortOrder",pUInvoiceDetailFixedAssetEntity.SortOrder,
                "@BudgetDetailItemCode",pUInvoiceDetailFixedAssetEntity.BudgetDetailItemCode,
                "@OrgRefNo",pUInvoiceDetailFixedAssetEntity.OrgRefNo,
                "@OrgRefDate",pUInvoiceDetailFixedAssetEntity.OrgRefDate,
                "@FundStructureID",pUInvoiceDetailFixedAssetEntity.FundStructureId,
                "@BankAccount",pUInvoiceDetailFixedAssetEntity.BankAccount,
                "@ProjectExpenseEAID",pUInvoiceDetailFixedAssetEntity.ProjectExpenseEAId,
                "@ProjectActivityEAID",pUInvoiceDetailFixedAssetEntity.ProjectActivityEAId,
                "@BudgetProvideCode",pUInvoiceDetailFixedAssetEntity.BudgetProvIdeCode,
                "@TopicID",pUInvoiceDetailFixedAssetEntity.TopicId,
                "@BudgetExpenseID",pUInvoiceDetailFixedAssetEntity.BudgetExpenseId,
            };
        }
    }
}
