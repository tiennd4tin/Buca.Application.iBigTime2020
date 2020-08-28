/***********************************************************************
 * <copyright file="SqlINInwardOutwardDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Inventory
{
    /// <summary>
    /// SqlINInwardOutwardDetail class
    /// </summary>
    public class SqlServerINInwardOutwardDetailDao : IINInwardOutwardDetailDao
    {
        /// <summary>
        /// Gets the ca receipt details by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;INInwardOutwardDetailEntity&gt;.</returns>
        public List<INInwardOutwardDetailEntity> GetINInwardOutwardDetailsByRefId(string refId)
        {
            const string procedures = @"uspGet_INInwardOutwardDetail_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);

        }
        
        /// <summary>
        /// Inserts the ca receipt detail.
        /// </summary>
        /// <param name="receiptDetailEntity">The receipt detail entity.</param>
        /// <returns>System.String.</returns>
        public string InsertINInwardOutwardDetail(INInwardOutwardDetailEntity receiptDetailEntity)
        {
            const string procedures = @"uspInsert_INInwardOutwardDetail";
            return Db.Insert(procedures, true, Take(receiptDetailEntity));
        }

        /// <summary>
        /// Deletes the ca receipt detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteINInwardOutwardDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_INInwardOutwardDetail_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, INInwardOutwardDetailEntity> Make = reader =>
           new INInwardOutwardDetailEntity
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
               OutwardPurpose = reader["OutwardPurpose"].AsInt(),
               TaxRate = reader["TaxRate"].AsDecimal(),
               TaxAmount = reader["TaxAmount"].AsDecimal(),
               InwardAmount = reader["InwardAmount"].AsDecimal(),
               BudgetSourceId = reader["BudgetSourceID"].AsString(),
               BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
               BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
               BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
               BudgetItemCode = reader["BudgetItemCode"].AsString(),
               BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
               MethodDistributeId = reader["MethodDistributeID"].AsInt(),
               CashWithDrawTypeId = reader["CashWithDrawTypeID"].AsInt(),
               AccountingObjectId = reader["AccountingObjectID"].AsString(),
               DepartmentId = reader["DepartmentID"].AsString(),
               ActivityId = reader["ActivityID"].AsString(),
               ProjectId = reader["ProjectID"].AsString(),
               ProjectActivityId = reader["ProjectActivityID"].AsString(),
               ListItemId = reader["ListItemID"].AsString(),
               ConfrontingRefId = reader["ConfrontingRefID"].AsString(),
               ConfrontingRefNo = reader["ConfrontingRefNo"].AsString(),
               ExpiryDate = reader["ExpiryDate"].AsDateTimeForNull(),
               LotNo = reader["LotNo"].AsString(),
               Approved = reader["Approved"].AsBool(),
               SortOrder = reader["SortOrder"].AsInt(),
               BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
               OrgRefNo = reader["OrgRefNo"].AsString(),
               OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
               FundStructureId = reader["FundStructureID"].AsString(),
               BankId = reader["BankID"].AsString(),
               ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
               BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
               ContractId = reader["ContractID"].AsString(),
               CapitalPlanId = reader["CapitalPlanID"].AsString(),
               AutoBusinessId = reader["AutoBusinessID"].AsString(),
               AmountOC= reader["AmountOC"].AsDecimal(),
           };

        /// <summary>
        /// Takes the specified information.
        /// </summary>
        /// <param name="iNInwardOutwardDetailEntity">The i n inward outward detail entity.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(INInwardOutwardDetailEntity iNInwardOutwardDetailEntity)
        {
            return new object[]
            {
                "@RefDetailID",iNInwardOutwardDetailEntity.RefDetailId,
                "@RefID",iNInwardOutwardDetailEntity.RefId,
                "@InventoryItemID",iNInwardOutwardDetailEntity.InventoryItemId,
                "@Description",iNInwardOutwardDetailEntity.Description,
                "@StockID",iNInwardOutwardDetailEntity.StockId,
                "@DebitAccount",iNInwardOutwardDetailEntity.DebitAccount,
                "@CreditAccount",iNInwardOutwardDetailEntity.CreditAccount,
                "@Unit",iNInwardOutwardDetailEntity.Unit,
                "@Quantity",iNInwardOutwardDetailEntity.Quantity,
                "@QuantityConvert",iNInwardOutwardDetailEntity.QuantityConvert,
                "@UnitPrice",iNInwardOutwardDetailEntity.UnitPrice,
                "@UnitPriceConvert",iNInwardOutwardDetailEntity.UnitPriceConvert,
                "@Amount",iNInwardOutwardDetailEntity.Amount,
                "@OutwardPurpose",iNInwardOutwardDetailEntity.OutwardPurpose,
                "@TaxRate",iNInwardOutwardDetailEntity.TaxRate,
                "@TaxAmount",iNInwardOutwardDetailEntity.TaxAmount,
                "@InwardAmount",iNInwardOutwardDetailEntity.InwardAmount,
                "@BudgetSourceID",iNInwardOutwardDetailEntity.BudgetSourceId,
                "@BudgetChapterCode",iNInwardOutwardDetailEntity.BudgetChapterCode,
                "@BudgetKindItemCode",iNInwardOutwardDetailEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode",iNInwardOutwardDetailEntity.BudgetSubKindItemCode,
                "@BudgetItemCode",iNInwardOutwardDetailEntity.BudgetItemCode,
                "@BudgetSubItemCode",iNInwardOutwardDetailEntity.BudgetSubItemCode,
                "@MethodDistributeID",iNInwardOutwardDetailEntity.MethodDistributeId,
                "@CashWithDrawTypeID",iNInwardOutwardDetailEntity.CashWithDrawTypeId,
                "@AccountingObjectID",iNInwardOutwardDetailEntity.AccountingObjectId,
                "@DepartmentID",iNInwardOutwardDetailEntity.DepartmentId,
                "@ActivityID",iNInwardOutwardDetailEntity.ActivityId,
                "@ProjectID",iNInwardOutwardDetailEntity.ProjectId,
                "@ProjectActivityID",iNInwardOutwardDetailEntity.ProjectActivityId,
                "@ListItemID",iNInwardOutwardDetailEntity.ListItemId,
                "@ConfrontingRefID",iNInwardOutwardDetailEntity.ConfrontingRefId,
                "@ConfrontingRefNo",iNInwardOutwardDetailEntity.ConfrontingRefNo,
                "@ExpiryDate",iNInwardOutwardDetailEntity.ExpiryDate,
                "@LotNo",iNInwardOutwardDetailEntity.LotNo,
                "@Approved",iNInwardOutwardDetailEntity.Approved,
                "@SortOrder",iNInwardOutwardDetailEntity.SortOrder,
                "@BudgetDetailItemCode",iNInwardOutwardDetailEntity.BudgetDetailItemCode,
                "@OrgRefNo",iNInwardOutwardDetailEntity.OrgRefNo,
                "@OrgRefDate",iNInwardOutwardDetailEntity.OrgRefDate,
                "@FundStructureID",iNInwardOutwardDetailEntity.FundStructureId,
                "@BankID",iNInwardOutwardDetailEntity.BankId,
                "@ProjectActivityEAID",iNInwardOutwardDetailEntity.ProjectActivityEAId,
                "@BudgetExpenseID",iNInwardOutwardDetailEntity.BudgetExpenseId,
                "@ContractID", iNInwardOutwardDetailEntity.ContractId,
                "@CapitalPlanID", iNInwardOutwardDetailEntity.CapitalPlanId,
                "@AutoBusinessID", iNInwardOutwardDetailEntity.AutoBusinessId,
                "@AmountOC",iNInwardOutwardDetailEntity.AmountOC,

            };
        }
    }
}
