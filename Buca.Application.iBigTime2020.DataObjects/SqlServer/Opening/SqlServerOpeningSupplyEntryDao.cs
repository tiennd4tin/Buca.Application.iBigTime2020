/***********************************************************************
 * <copyright file="SqlServerOpeningSupplyEntryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, January 3, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, January 3, 2018Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using System.Data;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Opening
{
    /// <summary>
    /// Class SqlServerOpeningSupplyEntryDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening.IOpeningSupplyEntryDao" />
    public class SqlServerOpeningSupplyEntryDao : DaoBase, IOpeningSupplyEntryDao
    {
        /// <summary>
        /// Takes the specified opening supply entry entity.
        /// </summary>
        /// <param name="openingSupplyEntryEntity">The opening supply entry entity.</param>
        /// <returns>System.Object[].</returns>
        private static object[] Take(OpeningSupplyEntryEntity openingSupplyEntryEntity)
        {
            return new object[]
            {
                "@RefID",openingSupplyEntryEntity.RefId,
                "@RefType",openingSupplyEntryEntity.RefType,
                "@PostedDate",openingSupplyEntryEntity.PostedDate,
                "@CurrencyCode",openingSupplyEntryEntity.CurrencyCode,
                "@ExchangeRate",openingSupplyEntryEntity.ExchangeRate,
                "@AccountNumber",openingSupplyEntryEntity.AccountNumber,
                "@InventoryItemID",openingSupplyEntryEntity.InventoryItemId,
                "@InventoryItemCode",openingSupplyEntryEntity.InventoryItemCode,
                "@InventoryItemName",openingSupplyEntryEntity.InventoryItemName,
                "@DepartmentID",openingSupplyEntryEntity.DepartmentId,
                "@BudgetChapterCode",openingSupplyEntryEntity.BudgetChapterCode,
                "@Quantity",openingSupplyEntryEntity.Quantity,
                "@UnitPriceOC",openingSupplyEntryEntity.UnitPriceOC,
                "@UnitPrice",openingSupplyEntryEntity.UnitPrice,
                "@AmountOC",openingSupplyEntryEntity.AmountOC,
                "@Amount",openingSupplyEntryEntity.Amount,
                "@PostVersion",openingSupplyEntryEntity.PostVersion,
                "@EditVersion",openingSupplyEntryEntity.EditVersion,
                "@SortOrder",openingSupplyEntryEntity.SortOrder,
            };
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, OpeningSupplyEntryEntity> Make = reader =>
        new OpeningSupplyEntryEntity
        {
            RefId = reader["RefID"].AsString(),
            RefType = reader["RefType"].AsInt(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            AccountNumber = reader["AccountNumber"].AsString(),
            InventoryItemId = reader["InventoryItemID"].AsString(),
            InventoryItemCode = reader["InventoryItemCode"].AsString(),
            InventoryItemName = reader["InventoryItemName"].AsString(),
            DepartmentId = reader["DepartmentID"].AsString(),
            BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
            Quantity = reader["Quantity"].AsDecimal(),
            UnitPriceOC = reader["UnitPriceOC"].AsDecimal(),
            UnitPrice = reader["UnitPrice"].AsDecimal(),
            AmountOC = reader["AmountOC"].AsDecimal(),
            Amount = reader["Amount"].AsDecimal(),
            PostVersion = reader["PostVersion"].AsInt(),
            EditVersion = reader["EditVersion"].AsInt(),
            SortOrder = reader["SortOrder"].AsInt()
        };


        /// <summary>
        /// Gets the bu plan receipt entityby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>OpeningSupplyEntryEntity.</returns>
        public OpeningSupplyEntryEntity GetOpeningSupplyEntrybyRefId(string refId)
        {
            const string procedures = @"uspGet_OpeningSupplyEntry_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipt.
        /// </summary>
        /// <returns>List&lt;OpeningSupplyEntryEntity&gt;.</returns>
        public List<OpeningSupplyEntryEntity> GetOpeningSupplyEntry()
        {
            const string procedures = @"uspGet_All_OpeningSupplyEntry";
            return Db.ReadList(procedures, true, Make<OpeningSupplyEntryEntity>);
        }

        /// <summary>
        /// Gets the bu plan receipt entity.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;OpeningSupplyEntryEntity&gt;.</returns>
        public List<OpeningSupplyEntryEntity> GetOpeningSupplyEntry(string refTypeId)
        {
            const string procedures = @"uspGet_OpeningSupplyEntry_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the opening commitmentby reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns>OpeningSupplyEntryEntity.</returns>
        public OpeningSupplyEntryEntity GetOpeningSupplyEntrybyRefNo(string refNo)
        {
            const string procedures = @"uspGet_OpeningSupplyEntry_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the bu plan receipts by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;OpeningSupplyEntryEntity&gt;.</returns>
        public List<OpeningSupplyEntryEntity> GetOpeningSupplyEntrysByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_OpeningSupplyEntry_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        public string InsertOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment)
        {
            const string procedures = @"uspInsert_OpeningSupplyEntry";
            return Db.Insert(procedures, true, Take(openingCommitment));
        }

        /// <summary>
        /// Updates the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        public string UpdateOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment)
        {
            const string procedures = @"uspUpdate_OpeningSupplyEntry";
            return Db.Update(procedures, true, Take(openingCommitment));
        }

        /// <summary>
        /// Deletes the bu plan receipt.
        /// </summary>
        /// <param name="bUCommitmentRequest">The b u commitment request.</param>
        /// <returns>System.String.</returns>
        public string DeleteOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment)
        {
            const string procedures = @"uspDelete_OpeningSupplyEntry";
            object[] parms = { "@RefId", openingCommitment.RefId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// Deletes the opening supply entry.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteOpeningSupplyEntry(string refId)
        {
            const string procedures = @"uspDelete_OpeningSupplyEntry";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        public string DeleteOpeningSupplyEntries()
        {
            const string procedures = @"uspDelete_OpeningSupplyEntries";
            object[] parms = {};
            return Db.Delete(procedures, true, parms);
        }
    }
}
