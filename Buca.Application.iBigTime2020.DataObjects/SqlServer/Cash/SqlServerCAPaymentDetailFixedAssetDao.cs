/***********************************************************************
 * <copyright file="SqlServerCAPaymentDetailFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateMonday, October 30, 2017Author SonTV  Description 
 * 
 * ************************************************************************/
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.DataHelpers;
using System;


using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Cash
{
    /// <summary>
    /// Class SqlServerCAPaymentDetailFixedAssetDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash.ICAPaymentDetailFixedAssetDao" />
    public class SqlServerCAPaymentDetailFixedAssetDao : ICAPaymentDetailFixedAssetDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, CAPaymentDetailFixedAssetEntity> Make = reader =>
   new CAPaymentDetailFixedAssetEntity
   {
       RefDetailId = reader["RefDetailID"].AsString(),
       RefId = reader["RefID"].AsString(),
       FixedAssetId = reader["FixedAssetID"].AsString(),
       Description = reader["Description"].AsString(),
       DepartmentId = reader["DepartmentID"].AsString(),
       DebitAccount = reader["DebitAccount"].AsString(),
       CreditAccount = reader["CreditAccount"].AsString(),
       Amount = reader["Amount"].AsDecimal(),
       TaxRate = reader["TaxRate"].AsDecimal(),
       TaxAmount = reader["TaxAmount"].AsDecimal(),
       TaxAccount = reader["TaxAccount"].AsString(),
       InvType = reader["InvType"].AsInt(),
       InvDate = reader["InvDate"].AsDateTimeForNull(),
       InvSeries = reader["InvSeries"].AsString(),
       InvNo = reader["InvNo"].AsString(),
       PurchasePurposeId = reader["PurchasePurposeID"].AsString(),
       FreightAmount = reader["FreightAmount"].AsDecimal(),
       OrgPrice = reader["OrgPrice"].AsDecimal(),
       BudgetSourceId = reader["BudgetSourceID"].AsString(),
       BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
       BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
       BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
       BudgetItemCode = reader["BudgetItemCode"].AsString(),
       BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
       MethodDistributeId = reader["MethodDistributeID"].AsInt(),
       CashWithdrawTypeId = reader["CashWithdrawTypeID"].AsInt(),
       AccountingObjectId = reader["AccountingObjectID"].AsString(),
       ActivityId = reader["ActivityID"].AsString(),
       ProjectId = reader["ProjectID"].AsString(),
       FundId = reader["FundID"].AsString(),
       ProjectActivityId = reader["ProjectActivityID"].AsString(),
       ProjectExpenseId = reader["ProjectExpenseID"].AsString(),
       ListItemId = reader["ListItemID"].AsString(),
       Approved = reader["Approved"].AsBool(),
       SortOrder = reader["SortOrder"].AsInt(),
       BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
       InvoiceTypeCode = reader["InvoiceTypeCode"].AsString(),
       OrgRefNo = reader["OrgRefNo"].AsString(),
       OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
       FundStructureId = reader["FundStructureID"].AsString(),
       BankId = reader["BankID"].AsString(),
       ProjectExpenseEAId = reader["ProjectExpenseEAID"].AsString(),
       ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
       BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
       ContractId = reader["ContractID"].AsString(),
       CapitalPlanId = reader["CapitalPlanID"].AsString(),
       Quantity = reader["Quantity"].AsDecimalForNull(),
       AmountOC= reader["AmountOC"].AsDecimal()
   };
        /// <summary>
        /// Takes the specified c a payment detail fixed asset entity.
        /// </summary>
        /// <param name="cAPaymentDetailFixedAssetEntity">The c a payment detail fixed asset entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(CAPaymentDetailFixedAssetEntity cAPaymentDetailFixedAssetEntity)
        {
            return new object[]
            {
        "@RefDetailID",cAPaymentDetailFixedAssetEntity.RefDetailId,
        "@RefID",cAPaymentDetailFixedAssetEntity.RefId,
        "@FixedAssetID",cAPaymentDetailFixedAssetEntity.FixedAssetId,
        "@Description",cAPaymentDetailFixedAssetEntity.Description,
        "@DepartmentID",cAPaymentDetailFixedAssetEntity.DepartmentId,
        "@DebitAccount",cAPaymentDetailFixedAssetEntity.DebitAccount,
        "@CreditAccount",cAPaymentDetailFixedAssetEntity.CreditAccount,
        "@Amount",cAPaymentDetailFixedAssetEntity.Amount,
        "@TaxRate",cAPaymentDetailFixedAssetEntity.TaxRate,
        "@TaxAmount",cAPaymentDetailFixedAssetEntity.TaxAmount,
        "@TaxAccount",cAPaymentDetailFixedAssetEntity.TaxAccount,
        "@InvType",cAPaymentDetailFixedAssetEntity.InvType,
        "@InvDate",cAPaymentDetailFixedAssetEntity.InvDate,
        "@InvSeries",cAPaymentDetailFixedAssetEntity.InvSeries,
        "@InvNo",cAPaymentDetailFixedAssetEntity.InvNo,
        "@PurchasePurposeID",cAPaymentDetailFixedAssetEntity.PurchasePurposeId,
        "@FreightAmount",cAPaymentDetailFixedAssetEntity.FreightAmount,
        "@OrgPrice",cAPaymentDetailFixedAssetEntity.OrgPrice,
        "@BudgetSourceID",cAPaymentDetailFixedAssetEntity.BudgetSourceId,
        "@BudgetChapterCode",cAPaymentDetailFixedAssetEntity.BudgetChapterCode,
        "@BudgetKindItemCode",cAPaymentDetailFixedAssetEntity.BudgetKindItemCode,
        "@BudgetSubKindItemCode",cAPaymentDetailFixedAssetEntity.BudgetSubKindItemCode,
        "@BudgetItemCode",cAPaymentDetailFixedAssetEntity.BudgetItemCode,
        "@BudgetSubItemCode",cAPaymentDetailFixedAssetEntity.BudgetSubItemCode,
        "@MethodDistributeID",cAPaymentDetailFixedAssetEntity.MethodDistributeId,
        "@CashWithdrawTypeID",cAPaymentDetailFixedAssetEntity.CashWithdrawTypeId,
        "@AccountingObjectID",cAPaymentDetailFixedAssetEntity.AccountingObjectId,
        "@ActivityID",cAPaymentDetailFixedAssetEntity.ActivityId,
        "@ProjectID",cAPaymentDetailFixedAssetEntity.ProjectId,
        "@FundID",cAPaymentDetailFixedAssetEntity.FundId,
        "@ProjectActivityID",cAPaymentDetailFixedAssetEntity.ProjectActivityId,
        "@ProjectExpenseID",cAPaymentDetailFixedAssetEntity.ProjectExpenseId,
        "@ListItemID",cAPaymentDetailFixedAssetEntity.ListItemId,
        "@Approved",cAPaymentDetailFixedAssetEntity.Approved,
        "@SortOrder",cAPaymentDetailFixedAssetEntity.SortOrder,
        "@BudgetDetailItemCode",cAPaymentDetailFixedAssetEntity.BudgetDetailItemCode,
        "@InvoiceTypeCode",cAPaymentDetailFixedAssetEntity.InvoiceTypeCode,
        "@OrgRefNo",cAPaymentDetailFixedAssetEntity.OrgRefNo,
        "@OrgRefDate",cAPaymentDetailFixedAssetEntity.OrgRefDate,
        "@FundStructureID",cAPaymentDetailFixedAssetEntity.FundStructureId,
        "@BankID",cAPaymentDetailFixedAssetEntity.BankId,
        "@ProjectExpenseEAID",cAPaymentDetailFixedAssetEntity.ProjectExpenseEAId,
        "@ProjectActivityEAID",cAPaymentDetailFixedAssetEntity.ProjectActivityEAId,
        "@BudgetExpenseID",cAPaymentDetailFixedAssetEntity.BudgetExpenseId,
        "@ContractID", cAPaymentDetailFixedAssetEntity.ContractId,
        "@CapitalPlanID", cAPaymentDetailFixedAssetEntity.CapitalPlanId,
        "@Quantity", cAPaymentDetailFixedAssetEntity.Quantity,
        "@AmountOC",cAPaymentDetailFixedAssetEntity.AmountOC
            };
        }

        /// <summary>
        /// Deletes the ca payment detail fixed asset.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteCAPaymentDetailFixedAsset(string refId)
        {
            const string procedures = @"uspDelete_CAPaymentDetailFixedAsset_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Gets the ca payment detail fixed assets by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;CAPaymentDetailFixedAssetEntity&gt;.</returns>
        public List<CAPaymentDetailFixedAssetEntity> GetCAPaymentDetailFixedAssetsByRefId(string refId)
        {
            const string procedures = @"uspGet_CAPaymentDetailFixedAsset_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the ca payment detail fixed asset.
        /// </summary>
        /// <param name="cAPaymentDetailFixedAsset">The c a payment detail fixed asset.</param>
        /// <returns>System.String.</returns>
        public string InsertCAPaymentDetailFixedAsset(CAPaymentDetailFixedAssetEntity cAPaymentDetailFixedAsset)
        {
            const string procedures = @"uspInsert_CAPaymentDetailFixedAsset";
            return Db.Insert(procedures, true, Take(cAPaymentDetailFixedAsset));
        }

    }
}
