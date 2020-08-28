/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerRefTypeDao
    /// </summary>
    public class SqlServerRefTypeDao : IRefTypeDao
    {
        /// <summary>
        ///     Takes the specified department.
        /// </summary>
        /// <param name="refTypeEntity">The department.</param>
        /// <returns></returns>
        private static object[] Take(RefTypeEntity refTypeEntity)
        {
            return new object[]
            {
                "@RefTypeID", refTypeEntity.RefTypeId,
                "@DefaultCreditAccountCategoryID", refTypeEntity.DefaultCreditAccountCategoryId,
                "@DefaultCreditAccountID", refTypeEntity.DefaultCreditAccountId,
                "@DefaultDebitAccountCategoryID", refTypeEntity.DefaultDebitAccountCategoryId,
                "@DefaultDebitAccountID", refTypeEntity.DefaultDebitAccountId,
                "@DefaultTaxAccountCategoryID", refTypeEntity.DefaultTaxAccountCategoryId,
                "@DefaultTaxAccountID", refTypeEntity.DefaultTaxAccountId
            };
        }


        private static object[] TakeInsert(RefTypeEntity refTypeEntity)
        {
            return new object[]
            {
                "@RefTypeID" ,refTypeEntity.RefTypeId,                                                
                "@RefTypeName" ,refTypeEntity.RefTypeName,
                "@FunctionID" , refTypeEntity.FunctionId,
                "@RefTypeCategoryID ", refTypeEntity.RefTypeCategoryId,
                "@MasterTableName ", refTypeEntity.MasterTableName,
                "@DetailTableName ", refTypeEntity.DetailTableName,
                "@LayoutMaster ", refTypeEntity.LayoutMaster,
                "@LayoutDetail ", refTypeEntity.LayoutDetail,
                "@DefaultDebitAccountCategoryID ", refTypeEntity.DefaultDebitAccountCategoryId,
                "@DefaultDebitAccountID ", refTypeEntity.DefaultDebitAccountId,
                "@DefaultCreditAccountCategoryID ", refTypeEntity.DefaultCreditAccountCategoryId,
                "@DefaultCreditAccountID ", refTypeEntity.DefaultCreditAccountId,
                "@DefaultTaxAccountCategoryID ", refTypeEntity.DefaultTaxAccountCategoryId,
                "@DefaultTaxAccountID ", refTypeEntity.DefaultTaxAccountId,
                "@AllowDefaultSetting ", refTypeEntity.AllowDefaultSetting,
                "@Postable ", refTypeEntity.Postable,
                "@Searchable ", refTypeEntity.Searchable,
                "@SortOrder ", refTypeEntity.SortOrder,
                "@SubSystem ", refTypeEntity.SubSystem,
            };
        }



        /// <summary>
        /// Gets the reference types.
        /// </summary>
        /// <returns></returns>
        public List<RefTypeEntity> GetRefTypes()
        {
            const string procedures = @"uspGet_All_RefType";
            return Db.ReadList(procedures, true, Make);
        }


        /// <summary>
        /// Gets the reference type Search.
        /// </summary>
        /// <returns></returns>
        public List<RefTypeEntity> GetRefTypeSearch()
        {
            const string procedures = @"uspGet_All_RefTypeSearch";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the type of the reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public RefTypeEntity GetRefType(int refTypeId)
        {
            const string sql = @"uspGet_RefType_ByID";

            object[] parms = { "@RefTypeID", refTypeId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Updates the type of the reference.
        /// </summary>
        /// <param name="refTypeEntity">The reference type entity.</param>
        /// <returns></returns>
        public string UpdateRefType(RefTypeEntity refTypeEntity)
        {
            const string sql = @"uspUpdate_RefType";
            return Db.Update(sql, true, Take(refTypeEntity));
        }

        public string DeleteRefTypeConvert()
        {
            const string sql = @"usp_ConvertAccountDefault";
            object[] parms = { };
            return Db.Delete(sql, true,parms);
        }

        public string InsertReftype(RefTypeEntity refTypeEntity)
        {
            const string sql = @"uspInsert_RefType";
            return Db.Update(sql, true, TakeInsert(refTypeEntity));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, RefTypeEntity> Make = reader =>
           new RefTypeEntity
           {
               RefTypeId = reader["RefTypeId"].AsInt(),
               RefTypeName = reader["RefTypeName"].AsString(),
               FunctionId = reader["FunctionId"].AsString(),
               RefTypeCategoryId = reader["RefTypeCategoryId"].AsInt(),
               MasterTableName = reader["MasterTableName"].AsString(),
               DetailTableName = reader["DetailTableName"].AsString(),
               LayoutMaster = reader["LayoutMaster"].AsBool(),
               LayoutDetail = reader["LayoutDetail"].AsBool(),
               DefaultDebitAccountCategoryId = reader["DefaultDebitAccountCategoryId"].AsString(),
               DefaultDebitAccountId = reader["DefaultDebitAccountId"].AsString(),
               DefaultCreditAccountCategoryId = reader["DefaultCreditAccountCategoryId"].AsString(),
               DefaultCreditAccountId = reader["DefaultCreditAccountId"].AsString(),
               DefaultTaxAccountCategoryId = reader["DefaultTaxAccountCategoryId"].AsString(),
               DefaultTaxAccountId = reader["DefaultTaxAccountId"].AsString(),
               AllowDefaultSetting = reader["AllowDefaultSetting"].AsBool(),
               Postable = reader["Postable"].AsBool(),
               Searchable = reader["Searchable"].AsBool(),
               SortOrder = reader["SortOrder"].AsInt(),
               SubSystem = reader["SubSystem"].AsString()
           };
    }
}
