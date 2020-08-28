/***********************************************************************
 * <copyright file="SqlServerBUTransferDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Estimate
{
    /// <summary>
    /// Class SqlServerBUTransferDetailDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate.IBUTransferDetailDao" />
    public class SqlServerBUTransferDetailPurchaseDao : DaoBase, IBUTransferDetailPurchaseDao
    {
        private static object[] Take(BUTransferDetailPurchaseEntity bUTransferDetailPurchaseEntity)
        {
            return new object[]
            {
                "@RefDetailID",bUTransferDetailPurchaseEntity.RefDetailId,
                "@RefID",bUTransferDetailPurchaseEntity.RefId,
                "@InventoryItemID",bUTransferDetailPurchaseEntity.InventoryItemId,
                "@Description",bUTransferDetailPurchaseEntity.Description,
                "@StockID",bUTransferDetailPurchaseEntity.StockId,
                "@DebitAccount",bUTransferDetailPurchaseEntity.DebitAccount,
                "@CreditAccount",bUTransferDetailPurchaseEntity.CreditAccount,
                "@Unit",bUTransferDetailPurchaseEntity.Unit,
                "@Quantity",bUTransferDetailPurchaseEntity.Quantity,
                "@QuantityConvert",bUTransferDetailPurchaseEntity.QuantityConvert,
                "@UnitPrice",bUTransferDetailPurchaseEntity.UnitPrice,
                "@UnitPriceConvert",bUTransferDetailPurchaseEntity.UnitPriceConvert,
                "@Amount",bUTransferDetailPurchaseEntity.Amount,
                "@TaxRate",bUTransferDetailPurchaseEntity.TaxRate,
                "@TaxAmount",bUTransferDetailPurchaseEntity.TaxAmount,
                "@FreightAmount",bUTransferDetailPurchaseEntity.FreightAmount,
                "@InwardAmount",bUTransferDetailPurchaseEntity.InwardAmount,
                "@BudgetSourceID",bUTransferDetailPurchaseEntity.BudgetSourceId,
                "@BudgetChapterCode",bUTransferDetailPurchaseEntity.BudgetChapterCode,
                "@BudgetKindItemCode",bUTransferDetailPurchaseEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",bUTransferDetailPurchaseEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",bUTransferDetailPurchaseEntity.BudgetItemCode,
                "@BudgetSubItemCode",bUTransferDetailPurchaseEntity.BudgetSubItemCode,
                "@MethodDistributeID",bUTransferDetailPurchaseEntity.MethodDistributeId,
                "@CashWithdrawTypeId",bUTransferDetailPurchaseEntity.CashWithdrawTypeId,
                "@AccountingObjectID",bUTransferDetailPurchaseEntity.AccountingObjectId,
                "@ActivityID",bUTransferDetailPurchaseEntity.ActivityId,
                "@ProjectID",bUTransferDetailPurchaseEntity.ProjectId,
                "@ProjectActivityID",bUTransferDetailPurchaseEntity.ProjectActivityId,
                "@ProjectExpenseID",bUTransferDetailPurchaseEntity.ProjectExpenseId,
                "@TaskID",bUTransferDetailPurchaseEntity.TaskId,
                "@ListItemID",bUTransferDetailPurchaseEntity.ListItemId,
                "@ExpiryDate",bUTransferDetailPurchaseEntity.ExpiryDate,
                "@LotNo",bUTransferDetailPurchaseEntity.LotNo,
                "@Approved",bUTransferDetailPurchaseEntity.Approved,
                "@SortOrder",bUTransferDetailPurchaseEntity.SortOrder,
                "@BudgetDetailItemCode",bUTransferDetailPurchaseEntity.BudgetDetailItemCode,
                "@OrgRefNo",bUTransferDetailPurchaseEntity.OrgRefNo,
                "@OrgRefDate",bUTransferDetailPurchaseEntity.OrgRefDate,
                "@FundStructureID",bUTransferDetailPurchaseEntity.FundStructureId,
                "@ProjectExpenseEAID",bUTransferDetailPurchaseEntity.ProjectExpenseEAId,
                "@ProjectActivityEAID",bUTransferDetailPurchaseEntity.ProjectActivityEAId,
                "@BudgetProvideCode",bUTransferDetailPurchaseEntity.BudgetProvideCode,
                "@TopicID",bUTransferDetailPurchaseEntity.TopicId,
                "@CreateDate",bUTransferDetailPurchaseEntity.CreateDate,
                "@BankID",bUTransferDetailPurchaseEntity.BankId,
                "@BudgetExpenseID",bUTransferDetailPurchaseEntity.BudgetExpenseId,
            };
        }

        /// <summary>
        /// Takes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        private static object[] Take(BUTransferDetailFixedAssetEntity bUTransferDetailFixedAssetEntity)
        {
            return new object[]
            {
                "@RefDetailID",bUTransferDetailFixedAssetEntity.RefDetailId,
                "@RefID",bUTransferDetailFixedAssetEntity.RefId,
                "@FixedAssetID",bUTransferDetailFixedAssetEntity.FixedAssetId,
                "@Description",bUTransferDetailFixedAssetEntity.Description,
                "@DepartmentID",bUTransferDetailFixedAssetEntity.DepartmentId,
                "@DebitAccount",bUTransferDetailFixedAssetEntity.DebitAccount,
                "@CreditAccount",bUTransferDetailFixedAssetEntity.CreditAccount,
                "@Amount",bUTransferDetailFixedAssetEntity.Amount,
                "@TaxRate",bUTransferDetailFixedAssetEntity.TaxRate,
                "@TaxAmount",bUTransferDetailFixedAssetEntity.TaxAmount,
                "@FreightAmount",bUTransferDetailFixedAssetEntity.FreightAmount,
                "@OrgPrice",bUTransferDetailFixedAssetEntity.OrgPrice,
                "@BudgetSourceID",bUTransferDetailFixedAssetEntity.BudgetSourceId,
                "@BudgetChapterCode",bUTransferDetailFixedAssetEntity.BudgetChapterCode,
                "@BudgetKindItemCode",bUTransferDetailFixedAssetEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",bUTransferDetailFixedAssetEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",bUTransferDetailFixedAssetEntity.BudgetItemCode,
                "@BudgetSubItemCode",bUTransferDetailFixedAssetEntity.BudgetSubItemCode,
                "@MethodDistributeID",bUTransferDetailFixedAssetEntity.MethodDistributeId,
                "@CashWithdrawTypeID",bUTransferDetailFixedAssetEntity.CashWithdrawTypeId,
                "@AccountingObjectID",bUTransferDetailFixedAssetEntity.AccountingObjectId,
                "@ActivityID",bUTransferDetailFixedAssetEntity.ActivityId,
                "@ProjectID",bUTransferDetailFixedAssetEntity.ProjectId,
                "@ProjectActivityID",bUTransferDetailFixedAssetEntity.ProjectActivityId,
                "@ProjectExpenseID",bUTransferDetailFixedAssetEntity.ProjectExpenseId,
                "@TaskID",bUTransferDetailFixedAssetEntity.TaskId,
                "@ListItemID",bUTransferDetailFixedAssetEntity.ListItemId,
                "@Approved",bUTransferDetailFixedAssetEntity.Approved,
                "@SortOrder",bUTransferDetailFixedAssetEntity.SortOrder,
                "@BudgetDetailItemCode",bUTransferDetailFixedAssetEntity.BudgetDetailItemCode,
                "@OrgRefNo",bUTransferDetailFixedAssetEntity.OrgRefNo,
                "@OrgRefDate",bUTransferDetailFixedAssetEntity.OrgRefDate,
                "@FundStructureID",bUTransferDetailFixedAssetEntity.FundStructureId,
                "@ProjectExpenseEAID",bUTransferDetailFixedAssetEntity.ProjectExpenseEAId,
                "@ProjectActivityEAID",bUTransferDetailFixedAssetEntity.ProjectActivityEAId,
                "@BudgetProvideCode",bUTransferDetailFixedAssetEntity.BudgetProvideCode,
                "@TopicID",bUTransferDetailFixedAssetEntity.TopicId,
                "@CreatedDate",bUTransferDetailFixedAssetEntity.CreatedDate,
                "@BankID",bUTransferDetailFixedAssetEntity.BankId,
                "@BudgetExpenseID",bUTransferDetailFixedAssetEntity.BudgetExpenseId,
            };
        }

        private static readonly Func<IDataReader, BUTransferDetailFixedAssetEntity> Make = reader =>
        new BUTransferDetailFixedAssetEntity
        {
            RefDetailId = reader["RefDetailID"].AsString(),
            RefId = reader["RefID"].AsString(),
            OrgRefNo = reader["OrgRefNo"].AsString(),
            OrgRefDate =  reader["OrgRefDate"].AsDateTimeForNull(),
            FixedAssetId = reader["FixedAssetId"].AsString(),
            Description = reader["Description"].AsString(),
            DepartmentId = reader["DepartmentID"].AsString(),
            DebitAccount = reader["DebitAccount"].AsString(),
            CreditAccount = reader["CreditAccount"].AsString(),
            Amount = reader["Amount"].AsDecimal(),
            TaxRate = reader["TaxRate"].AsInt(),
            TaxAmount = reader["TaxAmount"].AsInt(),
            BudgetSourceId = reader["BudgetSourceID"].AsString(),
            BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
            BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
            BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
            BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            MethodDistributeId = reader["MethodDistributeID"].AsInt(),
            CashWithdrawTypeId = reader["CashWithDrawTypeID"].AsInt(),
            AccountingObjectId = reader["AccountingObjectID"].AsString(),
            ActivityId = reader["ActivityID"].AsString(),
            BankId = reader["BankID"].AsString(),
            BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
            ProjectId = reader["ProjectID"].AsString(),
            SortOrder = reader["SortOrder"].AsInt(),
        };

        /// <summary>
        /// The make bu transfer detail purchase
        /// </summary>
        private static readonly Func<IDataReader, BUTransferDetailPurchaseEntity> MakeBUTransferDetailPurchase = reader =>
           new BUTransferDetailPurchaseEntity
           {
               RefDetailId = reader["RefDetailID"].AsString(),
               RefId = reader["RefID"].AsString(),
               InventoryItemId = reader["InventoryItemID"].AsString(),
               Description = reader["Description"].AsString(),
               StockId = reader["StockID"].AsString(),
               DebitAccount = reader["DebitAccount"].AsString(),
               CreditAccount = reader["CreditAccount"].AsString(),
               Unit = reader["Unit"].AsString(),
               Quantity = reader["Quantity"].AsDecimal(),
               QuantityConvert = reader["QuantityConvert"].AsDecimal(),
               UnitPrice = reader["UnitPrice"].AsDecimal(),
               UnitPriceConvert = reader["UnitPriceConvert"].AsDecimal(),
               Amount = reader["Amount"].AsDecimal(),
               TaxRate = reader["TaxRate"].AsInt(),
               TaxAmount = reader["TaxAmount"].AsDecimal(),
               FreightAmount = reader["FreightAmount"].AsDecimal(),
               InwardAmount = reader["InwardAmount"].AsDecimal(),
               BudgetSourceId = reader["BudgetSourceID"].AsString(),
               BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
               BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
               BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
               BudgetItemCode = reader["BudgetItemCode"].AsString(),
               BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
               MethodDistributeId = reader["MethodDistributeID"].AsInt(),
               CashWithdrawTypeId = reader["CashWithdrawTypeId"].AsInt(),
               AccountingObjectId = reader["AccountingObjectID"].AsString(),
               ActivityId = reader["ActivityID"].AsString(),
               ProjectId = reader["ProjectID"].AsString(),
               ProjectActivityId = reader["ProjectActivityID"].AsString(),
               ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
               TaskId = reader["TaskID"].AsString(),
               ListItemId = reader["ListItemID"].AsString(),
               ExpiryDate = reader["ExpiryDate"].AsDateTime(),
               LotNo = reader["LotNo"].AsString(),
               Approved = reader["Approved"].AsBool(),
               SortOrder = reader["SortOrder"].AsInt(),
               BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
               OrgRefNo = reader["OrgRefNo"].AsString(),
               OrgRefDate = reader["OrgRefDate"].AsDateTime(),
               FundStructureId = reader["FundStructureID"].AsString(),
               ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
               ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
               BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
               TopicId = reader["TopicID"].AsString(),
               CreateDate = reader["CreateDate"].AsDateTime(),
               BankId = reader["BankID"].AsString(),
               BudgetExpenseId = reader["BudgetExpenseID"].AsString(),

           };

        /// <summary>
        /// Deletes the bu commitment request detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteBUTransferDetailPurchaseByRefId(string refId)
        {
            const string procedures = @"uspDelete_BUTransferDetail_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the bu commitment request detailby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;BUCommitmentRequestDetailEntity&gt;.</returns>
        public List<BUTransferDetailPurchaseEntity> GetBUTransferDetailPurchasesByRefId(string refId)
        {
            const string procedures = @"uspGet_BUTransferDetailPurchase_ByRefId";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make<BUTransferDetailPurchaseEntity>, parms);
        }

        /// <summary>
        /// Inserts the bu plan receipt detail.
        /// </summary>
        /// <param name="bUTransferDetail">The b u commitment adjustment detail.</param>
        /// <returns>System.String.</returns>
        public string InsertBUTransferDetailPurchase(BUTransferDetailPurchaseEntity bUTransferDetailPurchase)
        {
            const string procedures = @"uspInsert_BUTransferDetailPurchase";
            return Db.Insert(procedures, true, Take(bUTransferDetailPurchase));
        }

        public List<BUTransferDetailFixedAssetEntity> GetBUTransferDetailFixedAssetsByRefId(string refId)
        {
            const string procedures = @"uspGet_BUTransferDetailFixedAsset_ByRefId";
            object[] parms = { "@RefID", refId };
            //return Db.ReadList(procedures, true, Make<BUTransferDetailFixedAssetEntity>, parms);
            return Db.ReadList(procedures, true, Make, parms);
        }

        public string InsertBUTransferDetailFixedAsset(BUTransferDetailFixedAssetEntity entity)
        {
            const string procedures = @"uspInsert_BUTransferDetailFixedAsset";
            return Db.Insert(procedures, true, Take(entity));
        }

        public string DeleteBUTransferDetailPurchases(string refId)
        {
            const string procedures = @"uspDelete_BUTransferDetailPurchases";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        public string DeleteBUTransferDetailFixedAssets(string refId)
        {
            const string procedures = @"uspDelete_BUTransferDetailFixedAssets";
            object[] parms = { "@RefID", refId };
            return Db.Insert(procedures, true, parms);
        }
    }
}
