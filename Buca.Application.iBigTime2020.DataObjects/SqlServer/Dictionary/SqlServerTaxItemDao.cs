using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    public class SqlServerTaxItemDao : ITaxItemDao
    {
        /// <summary>
        /// Gets the tax item.
        /// </summary>
        /// <param name="taxItemId">The tax item identifier.</param>
        /// <returns>Buca.Application.iBigTime2020.BusinessEntities.Dictionary.TaxItemEntity.</returns>
        public TaxItemEntity GetTaxItem(string taxItemId)
        {
            const string sql = @"uspGet_TaxItem_ByID";

            object[] parms = { "@TaxItemID", taxItemId };
            return Db.Read(sql, true, Make, parms);
        }
        /// <summary>
        /// Gets the tax items.
        /// </summary>
        /// <returns>List&lt;TaxItemEntity&gt;.</returns>
        public List<TaxItemEntity> GetTaxItems()
        {
            const string procedures = @"uspGet_All_TaxItem";
            return Db.ReadList(procedures, true, Make);
        }
        /// <summary>
        /// Gets the tax items by tax item code.
        /// </summary>
        /// <param name="taxItemCode">The tax item code.</param>
        /// <returns>System.Collections.Generic.List&lt;Buca.Application.iBigTime2020.BusinessEntities.Dictionary.TaxItemEntity&gt;.</returns>
        public List<TaxItemEntity> GetTaxItemsByTaxItemCode(string taxItemCode)
        {
            const string sql = @"uspGet_TaxItem_ByTaxItemCode";

            object[] parms = { "@TaxItemCode", taxItemCode };
            return Db.ReadList(sql, true, Make, parms);
        }
        /// <summary>
        /// Gets the tax items by active.
        /// </summary>
        /// <param name="isActive">The is active.</param>
        /// <returns>System.Collections.Generic.List&lt;Buca.Application.iBigTime2020.BusinessEntities.Dictionary.TaxItemEntity&gt;.</returns>
        public List<TaxItemEntity> GetTaxItemsByActive(bool isActive)
        {
            const string sql = @"uspGet_TaxItem_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }
        /// <summary>
        /// Inserts the tax item.
        /// </summary>
        /// <param name="taxItem">The tax item.</param>
        /// <returns>System.String.</returns>
        public string InsertTaxItem(TaxItemEntity taxItem)
        {
            const string sql = @"uspInsert_TaxItem";
            return Db.Insert(sql, true, Take(taxItem));
        }
        /// <summary>
        /// Updates the tax item.
        /// </summary>
        /// <param name="taxItem">The tax item.</param>
        /// <returns>System.String.</returns>
        public string UpdateTaxItem(TaxItemEntity taxItem)
        {
            const string sql = @"uspUpdate_TaxItem";
            return Db.Update(sql, true, Take(taxItem));
        }
        /// <summary>
        /// Deletes the tax item.
        /// </summary>
        /// <param name="taxItemId">The tax item identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteTaxItem(string taxItemId)
        {
            const string sql = @"uspDelete_TaxItem";

            object[] parms = { "@TaxItemId", taxItemId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, TaxItemEntity> Make = reader =>
            new TaxItemEntity
            {
                TaxItemId = reader["TaxItemId"].AsString(),
                TaxItemCode = reader["TaxItemCode"].AsString(),
                TaxItemName = reader["TaxItemName"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified tax item.
        /// </summary>
        /// <param name="taxItem">The tax item.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(TaxItemEntity taxItem)
        {
            return new object[]
            {
                "@TaxItemID", taxItem.TaxItemId,
                "@TaxItemCode",taxItem.TaxItemCode,
                "@TaxItemName",taxItem.TaxItemName,
                "@IsActive",taxItem.IsActive
            };
        }
    }
}
