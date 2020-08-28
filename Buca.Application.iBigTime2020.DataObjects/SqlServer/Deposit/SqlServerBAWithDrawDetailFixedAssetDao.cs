/***********************************************************************
 * <copyright file="sqlserverbawithdrawdetailfixedassetdao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 23, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Deposit
{
    /// <summary>
    ///     SqlServerBAWithDrawDetailFixedAssetDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit.IBAWithDrawDetailFixedAssetDao" />
    public class SqlServerBAWithDrawDetailFixedAssetDao : IBAWithDrawDetailFixedAssetDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, BAWithDrawDetailFixedAssetEntity> Make = reader =>
            new BAWithDrawDetailFixedAssetEntity
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
                ProjectActivityId = reader["ProjectActivityID"].AsString(),
                FundId = reader["FundID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                SortOrder = reader["SortOrder"].AsInt(),
                BudgetDetailItemCode = reader["BudgetDetailItemCode"].AsString(),
                InvoiceTypeCode = reader["InvoiceTypeCode"].AsString(),
                OrgRefNo = reader["OrgRefNo"].AsString(),
                OrgRefDate = reader["OrgRefDate"].AsDateTimeForNull(),
                FundStructureId = reader["FundStructureID"].AsString(),
                BankId = reader["BankID"].AsString(),
                ProjectActivityEAId = reader["ProjectActivityEAID"].AsString(),
                BudgetExpenseId = reader["BudgetExpenseID"].AsString(),
            };

        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<BAWithDrawDetailFixedAssetEntity> GetBAWithDrawDetailFixedAssetEntitysByRefId(string refId)
        {
            const string procedures = @"uspGet_BAWithDrawDetailFixedAsset_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="bAWithDrawDetailFixedAsset">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertBAWithDrawDetailFixedAssetEntity(
            BAWithDrawDetailFixedAssetEntity bAWithDrawDetailFixedAsset)
        {
            const string sql = @"uspInsert_BAWithDrawDetailFixedAsset";
            return Db.Insert(sql, true, Take(bAWithDrawDetailFixedAsset));
        }

        /// <summary>
        ///     Deletes the bADeposit detail by bADeposit identifier.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public string DeleteBAWithDrawDetailFixedAssetEntityByRefId(string refId)
        {
            const string procedures = @"uspDelete_BAWithDrawDetailFixedAsset_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified bADeposit.
        /// </summary>
        /// <param name="bAWithDrawDetailFixedAssetEntity">The b a with draw detail fixed asset entity.</param>
        /// <returns></returns>
        private object[] Take(BAWithDrawDetailFixedAssetEntity bAWithDrawDetailFixedAssetEntity)
        {
            return new object[]
            {
                "@RefDetailID", bAWithDrawDetailFixedAssetEntity.RefDetailId,
                "@RefID", bAWithDrawDetailFixedAssetEntity.RefId,
                "@FixedAssetID", bAWithDrawDetailFixedAssetEntity.FixedAssetId,
                "@Description", bAWithDrawDetailFixedAssetEntity.Description,
                "@DepartmentID", bAWithDrawDetailFixedAssetEntity.DepartmentId,
                "@DebitAccount", bAWithDrawDetailFixedAssetEntity.DebitAccount,
                "@CreditAccount", bAWithDrawDetailFixedAssetEntity.CreditAccount,
                "@Amount", bAWithDrawDetailFixedAssetEntity.Amount,
                "@TaxRate", bAWithDrawDetailFixedAssetEntity.TaxRate,
                "@TaxAmount", bAWithDrawDetailFixedAssetEntity.TaxAmount,
                "@TaxAccount", bAWithDrawDetailFixedAssetEntity.TaxAccount,
                "@InvType", bAWithDrawDetailFixedAssetEntity.InvType,
                "@InvDate", bAWithDrawDetailFixedAssetEntity.InvDate,
                "@InvSeries", bAWithDrawDetailFixedAssetEntity.InvSeries,
                "@InvNo", bAWithDrawDetailFixedAssetEntity.InvNo,
                "@PurchasePurposeID", bAWithDrawDetailFixedAssetEntity.PurchasePurposeId,
                "@FreightAmount", bAWithDrawDetailFixedAssetEntity.FreightAmount,
                "@OrgPrice", bAWithDrawDetailFixedAssetEntity.OrgPrice,
                "@BudgetSourceID", bAWithDrawDetailFixedAssetEntity.BudgetSourceId,
                "@BudgetChapterCode", bAWithDrawDetailFixedAssetEntity.BudgetChapterCode,
                "@BudgetKindItemCode", bAWithDrawDetailFixedAssetEntity.BudgetKindItemCode,
                "@BudgetSubKindItemCode", bAWithDrawDetailFixedAssetEntity.BudgetSubKindItemCode,
                "@BudgetItemCode", bAWithDrawDetailFixedAssetEntity.BudgetItemCode,
                "@BudgetSubItemCode", bAWithDrawDetailFixedAssetEntity.BudgetSubItemCode,
                "@MethodDistributeID", bAWithDrawDetailFixedAssetEntity.MethodDistributeId,
                "@CashWithdrawTypeID", bAWithDrawDetailFixedAssetEntity.CashWithdrawTypeId,
                "@AccountingObjectID", bAWithDrawDetailFixedAssetEntity.AccountingObjectId,
                "@ActivityID", bAWithDrawDetailFixedAssetEntity.ActivityId,
                "@ProjectID", bAWithDrawDetailFixedAssetEntity.ProjectId,
                "@ProjectActivityID", bAWithDrawDetailFixedAssetEntity.ProjectActivityId,
                "@FundID", bAWithDrawDetailFixedAssetEntity.FundId,
                "@ListItemID", bAWithDrawDetailFixedAssetEntity.ListItemId,
                "@SortOrder", bAWithDrawDetailFixedAssetEntity.SortOrder,
                "@BudgetDetailItemCode", bAWithDrawDetailFixedAssetEntity.BudgetDetailItemCode,
                "@InvoiceTypeCode", bAWithDrawDetailFixedAssetEntity.InvoiceTypeCode,
                "@OrgRefNo", bAWithDrawDetailFixedAssetEntity.OrgRefNo,
                "@OrgRefDate", bAWithDrawDetailFixedAssetEntity.OrgRefDate,
                "@FundStructureID", bAWithDrawDetailFixedAssetEntity.FundStructureId,
                "@BankID", bAWithDrawDetailFixedAssetEntity.BankId,
                "@ProjectActivityEAID", bAWithDrawDetailFixedAssetEntity.ProjectActivityEAId,
                "@BudgetExpenseID", bAWithDrawDetailFixedAssetEntity.BudgetExpenseId,
            };
        }
    }
}