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
    /// <summary>
    /// Class SqlServerTaxTypeDao.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary.ITaxTypeDao" />
    public class SqlServerTaxTypeDao : ITaxTypeDao
    {
        /// <summary>
        /// Gets the type of the tax.
        /// </summary>
        /// <param name="taxTypeId">The tax type identifier.</param>
        /// <returns>Buca.Application.iBigTime2020.BusinessEntities.Dictionary.TaxTypeEntity.</returns>
        public TaxTypeEntity GetTaxType(string taxTypeId)
        {
            const string sql = @"uspGet_TaxType_ByID";

            object[] parms = { "@TaxTypeID", taxTypeId };
            return Db.Read(sql, true, Make, parms);
        }
        /// <summary>
        /// Gets the tax types.
        /// </summary>
        /// <returns>List&lt;TaxTypeEntity&gt;.</returns>
        public List<TaxTypeEntity> GetTaxTypes()
        {
            const string procedures = @"uspGet_All_TaxType";
            return Db.ReadList(procedures, true, Make);
        }
        /// <summary>
        /// Gets the tax types by tax type code.
        /// </summary>
        /// <param name="taxTypeCode">The tax type code.</param>
        /// <returns>List&lt;TaxTypeEntity&gt;.</returns>
        public List<TaxTypeEntity> GetTaxTypesByTaxTypeCode(string taxTypeCode)
        {
            const string sql = @"uspGet_TaxType_ByTaxTypeCode";

            object[] parms = { "@TaxTypeCode", taxTypeCode };
            return Db.ReadList(sql, true, Make, parms);
        }
        /// <summary>
        /// Gets the tax types by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;TaxTypeEntity&gt;.</returns>
        public List<TaxTypeEntity> GetTaxTypesByActive(bool isActive)
        {
            const string sql = @"uspGet_TaxType_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }
        /// <summary>
        /// Inserts the type of the tax.
        /// </summary>
        /// <param name="taxType">Type of the tax.</param>
        /// <returns>System.String.</returns>
        public string InsertTaxType(TaxTypeEntity taxType)
        {
            const string sql = @"uspInsert_TaxType";
            return Db.Insert(sql, true, Take(taxType));
        }
        /// <summary>
        /// Updates the type of the tax.
        /// </summary>
        /// <param name="taxType">Type of the tax.</param>
        /// <returns>System.String.</returns>
        public string UpdateTaxType(TaxTypeEntity taxType)
        {
            const string sql = @"uspUpdate_TaxType";
            return Db.Update(sql, true, Take(taxType));
        }
        /// <summary>
        /// Deletes the type of the tax.
        /// </summary>
        /// <param name="taxTypeId">The tax type identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteTaxType(string taxTypeId)
        {
            const string sql = @"uspDelete_TaxType";

            object[] parms = { "@TaxTypeId", taxTypeId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, TaxTypeEntity> Make = reader =>
            new TaxTypeEntity
            {
                TaxTypeId = reader["TaxTypeId"].AsString(),
                TaxTypeCode = reader["TaxTypeCode"].AsString(),
                TaxTypeName = reader["TaxTypeName"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified tax type.
        /// </summary>
        /// <param name="taxType">Type of the tax.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(TaxTypeEntity taxType)
        {
            return new object[]
            {
                "@TaxTypeID", taxType.TaxTypeId,
                "@TaxTypeCode",taxType.TaxTypeCode,
                "@TaxTypeName",taxType.TaxTypeName,
                "@IsActive",taxType.IsActive
            };
        }
    }
}
