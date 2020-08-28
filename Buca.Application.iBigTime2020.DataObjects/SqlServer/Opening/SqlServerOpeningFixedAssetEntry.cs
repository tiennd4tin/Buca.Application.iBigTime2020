/***********************************************************************
 * <copyright file="SqlServerOpeningFixedAssetEntry.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Friday, April 20, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using System.Data;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Opening
{
    /// <summary>
    /// Class SqlServerOpeningFixedAssetEntry.
    /// </summary>
    public class SqlServerOpeningFixedAssetEntry : IOpeningFixedAssetEntryDao
    {
        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <returns>List{BusinessEntities.Business.Opening.OpeningFixedAssetEntryEntity}.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<OpeningFixedAssetEntryEntity> GetOpeningAccountEntries()
        {
            const string procedures = @"uspGet_All_OpeningFixedAssetEntry";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the opening account entry entity by account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns>List{BusinessEntities.Business.Opening.OpeningFixedAssetEntryEntity}.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<OpeningFixedAssetEntryEntity> GetOpeningFixedAssetEntryEntityByAccountCode(string accountCode)
        {
            const string procedures = @"uspGet_OpeningFixedAssetEntry_ByAccountNumber";

            object[] parms = { "@AccountNumber", accountCode };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the opening fixed asset entry.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>BusinessEntities.Business.Opening.OpeningFixedAssetEntryEntity.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public OpeningFixedAssetEntryEntity GetOpeningFixedAssetEntry(long refId)
        {
            const string procedures = @"uspGet_OpeningFixedAssetEntry_ByID";

            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string InsertOpeningFixedAssetEntry(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity)
        {
            const string sql = @"uspInsert_OpeningFixedAssetEntry";
            return Db.Insert(sql, true, Take(openingFixedAssetEntryEntity));
        }

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string UpdateOpeningFixedAssetEntry(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity)
        {
            const string sql = @"upsUpdate_OpeningFixedAssetEntry";
            return Db.Update(sql, true, Take(openingFixedAssetEntryEntity));
        }

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string DeleteOpeningFixedAssetEntry(string refId)
        {
            const string sql = @"uspDelete_OpeningFixedAssetEntry";
            object[] parms = { "@RefID", refId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Deletes the opening fixed asset entry by reference fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string DeleteOpeningFixedAssetEntryByRefFixedAssetId(string fixedAssetId)
        {
            const string sql = @"uspDelete_FixedAsset_FromOpeningFixedAssetEntry";
            object[] parms = { "@FixedAssetID", fixedAssetId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Deletes the opening account entry detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string DeleteOpeningFixedAssetEntryByRefId(long refId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningFixedAssetEntryEntity> Make = reader =>
            new OpeningFixedAssetEntryEntity
            {
                RefId = reader["RefID"].AsString(),
                RefType = reader["RefType"].AsInt(),
                PostedDate = reader["PostedDate"].AsDateTime(),
                CurrencyCode = reader["CurrencyCode"].AsString(),
                ExchangeRate = reader["ExchangeRate"].AsDecimal(),
                FixedAssetId = reader["FixedAssetID"].AsString(),
                DepartmentId = reader["DepartmentID"].AsString(),
                BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
                OrgPriceAccount = reader["OrgPriceAccount"].AsString(),
                OrgPriceDebitAmountOC = reader["OrgPriceDebitAmountOC"].AsDecimal(),
                OrgPriceDebitAmount = reader["OrgPriceDebitAmount"].AsDecimal(),
                DepreciationAccount = reader["DepreciationAccount"].AsString(),
                DepreciationCreditAmountOC = reader["DepreciationCreditAmountOC"].AsDecimal(),
                DepreciationCreditAmount = reader["DepreciationCreditAmount"].AsDecimal(),
                CapitalAccount = reader["CapitalAccount"].AsString(),
                CapitalCreditAmountOC = reader["CapitalCreditAmountOC"].AsDecimal(),
                CapitalCreditAmount = reader["CapitalCreditAmount"].AsDecimal(),
                SortOrder = reader["SortOrder"].AsInt(),
                DevaluationCreditAmount = reader["DevaluationCreditAmount"].AsDecimal()
            };

        /// <summary>
        /// Takes the specified fixed asset ledger.
        /// </summary>
        /// <param name="fixedAssetLedger">The fixed asset ledger.</param>
        /// <returns>System.Object[][].</returns>
        private static object[] Take(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity)
        {
            return new object[]
            {
                "@RefID",openingFixedAssetEntryEntity.RefId,
                "@RefType",openingFixedAssetEntryEntity.RefType,
                "@PostedDate",openingFixedAssetEntryEntity.PostedDate,
                "@CurrencyCode",openingFixedAssetEntryEntity.CurrencyCode,
                "@ExchangeRate",openingFixedAssetEntryEntity.ExchangeRate,
                "@FixedAssetID",openingFixedAssetEntryEntity.FixedAssetId,
                "@DepartmentID",openingFixedAssetEntryEntity.DepartmentId,
                "@BudgetChapterCode",openingFixedAssetEntryEntity.BudgetChapterCode,
                "@OrgPriceAccount",openingFixedAssetEntryEntity.OrgPriceAccount,
                "@OrgPriceDebitAmountOC",openingFixedAssetEntryEntity.OrgPriceDebitAmountOC,
                "@OrgPriceDebitAmount",openingFixedAssetEntryEntity.OrgPriceDebitAmount,
                "@DepreciationAccount",openingFixedAssetEntryEntity.DepreciationAccount,
                "@DepreciationCreditAmountOC",openingFixedAssetEntryEntity.DepreciationCreditAmountOC,
                "@DepreciationCreditAmount",openingFixedAssetEntryEntity.DepreciationCreditAmount,
                "@CapitalAccount",openingFixedAssetEntryEntity.CapitalAccount,
                "@CapitalCreditAmountOC",openingFixedAssetEntryEntity.CapitalCreditAmountOC,
                "@CapitalCreditAmount",openingFixedAssetEntryEntity.CapitalCreditAmount,
                "@SortOrder",openingFixedAssetEntryEntity.SortOrder,
                "@DevaluationCreditAmount",openingFixedAssetEntryEntity.DevaluationCreditAmount
            };
        }
    }
}
