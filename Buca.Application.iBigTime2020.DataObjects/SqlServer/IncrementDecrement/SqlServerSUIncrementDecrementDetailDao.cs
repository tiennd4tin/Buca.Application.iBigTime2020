/***********************************************************************
 * <copyright file="SqlServerSUIncrementDecrementDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 25, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.IncrementDecrement
{
    /// <summary>
    ///     SqlServerSUIncrementDecrementDetailDao
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement.ISUIncrementDecrementDetailDao" />
    public class SqlServerSUIncrementDecrementDetailDao : ISUIncrementDecrementDetailDao
    {
        /// <summary>
        ///     The make
        /// </summary>
        private static readonly Func<IDataReader, SUIncrementDecrementDetailEntity> Make = reader =>
            new SUIncrementDecrementDetailEntity
            {
                RefDetailId = reader["RefDetailID"].AsString(),
                RefId = reader["RefID"].AsString(),
                InventoryItemId = reader["InventoryItemID"].AsString(),
                Description = reader["Description"].AsString(),
                DepartmentId = reader["DepartmentID"].AsString(),
                DebitAccount = reader["DebitAccount"].AsString(),
                CreditAccount = reader["CreditAccount"].AsString(),
                Quantity = reader["Quantity"].AsDecimal(),
                QuantityConvert = reader["QuantityConvert"].AsDecimal(),
                UnitPrice = reader["UnitPrice"].AsDecimal(),
                UnitPriceConvert = reader["UnitPriceConvert"].AsDecimal(),
                Amount = reader["Amount"].AsDecimal(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                AccountingObjectId = reader["AccountingObjectID"].AsString(),
                ListItemId = reader["ListItemID"].AsString(),
                SortOrder = reader["SortOrder"].AsIntForNull(),
                BudgetSourceId = reader["BudgetSourceID"].AsString(),
                BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
                BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
                BudgetProvideCode = reader["BudgetProvideCode"].AsString(),
                TopicId = reader["TopicID"].AsString()
            };

        /// <summary>
        ///     Gets the bADeposit details by bADeposit.
        /// </summary>
        /// <param name="refId">The bADeposit identifier.</param>
        /// <returns></returns>
        public List<SUIncrementDecrementDetailEntity> GetSUIncrementDecrementDetailsByRefId(string refId)
        {
            const string procedures = @"uspGet_SUIncrementDecrementDetail_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        ///     Inserts the bADeposit detail.
        /// </summary>
        /// <param name="sUIncrementDecrementDetail">The bADeposit detail.</param>
        /// <returns></returns>
        public string InsertSUIncrementDecrementDetail(SUIncrementDecrementDetailEntity sUIncrementDecrementDetail)
        {
            const string sql = @"uspInsert_SUIncrementDecrementDetail";
            return Db.Insert(sql, true, Take(sUIncrementDecrementDetail));
        }

        public string DeleteSUIncrementDecrementDetailByRefId(string refId)
        {
            const string procedures = @"uspDelete_SUIncrementDecrementDetail_ByMaster";
            object[] parms = {"@RefID", refId};
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        ///     Takes the specified bADeposit.
        /// </summary>
        /// <param name="sUIncrementDecrementDetail">The bADeposit.</param>
        /// <returns></returns>
        private object[] Take(SUIncrementDecrementDetailEntity sUIncrementDecrementDetail)
        {
            return new object[]
            {
                "@RefDetailID", sUIncrementDecrementDetail.RefDetailId,
                "@RefID", sUIncrementDecrementDetail.RefId,
                "@InventoryItemID", sUIncrementDecrementDetail.InventoryItemId,
                "@Description", sUIncrementDecrementDetail.Description,
                "@DepartmentID", sUIncrementDecrementDetail.DepartmentId,
                "@DebitAccount", sUIncrementDecrementDetail.DebitAccount,
                "@CreditAccount", sUIncrementDecrementDetail.CreditAccount,
                "@Quantity", sUIncrementDecrementDetail.Quantity,
                "@QuantityConvert", sUIncrementDecrementDetail.QuantityConvert,
                "@UnitPrice", sUIncrementDecrementDetail.UnitPrice,
                "@UnitPriceConvert", sUIncrementDecrementDetail.UnitPriceConvert,
                "@Amount", sUIncrementDecrementDetail.Amount,
                "@BudgetChapterCode", sUIncrementDecrementDetail.BudgetChapterCode,
                "@AccountingObjectID", sUIncrementDecrementDetail.AccountingObjectId,
                "@ListItemID", sUIncrementDecrementDetail.ListItemId,
                "@SortOrder", sUIncrementDecrementDetail.SortOrder,
                "@BudgetSourceID", sUIncrementDecrementDetail.BudgetSourceId,
                "@BudgetKindItemCode", sUIncrementDecrementDetail.BudgetKindItemCode,
                "@BudgetSubKindItemCode", sUIncrementDecrementDetail.BudgetSubKindItemCode,
                "@BudgetProvideCode", sUIncrementDecrementDetail.BudgetProvideCode,
                "@TopicID", sUIncrementDecrementDetail.TopicId
            };
        }
    }
}