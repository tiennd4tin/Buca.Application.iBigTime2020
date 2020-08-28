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

    public class SqlServerFixedAssetCategoryDao : IFixedAssetCategoryDao
    {
        public SqlServerFixedAssetCategoryDao() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }
        public FixedAssetCategoryEntity GetFixedAssetCategory(string fixedAssetCategoryId)
        {
            const string sql = @"uspGet_FixedAssetCategory_ById";
            object[] parms = { "@FixedAssetCategoryId", fixedAssetCategoryId };
            return Db.Read(sql, true, Make, parms);
        }

        public FixedAssetCategoryEntity GetFixedAssetCategorybyCode(string fixedAssetCategoryCode)
        {
            const string sql = @"uspGet_FixedAssetCategory_ByCode";
            object[] parms = { "@FixedAssetCategoryCode", fixedAssetCategoryCode };
            return Db.Read(sql, true, Make, parms);
        }
        public List<FixedAssetCategoryEntity> GetFixedAssetCategories()
        {
            const string sql = @"uspGet_All_FixedAssetCategory";
            return Db.ReadList(sql, true, Make);
        }

        public string InsertFixedAssetCategory(FixedAssetCategoryEntity fixedAssetCategory)
        {
            const string sql = "uspInsert_FixedAssetCategory";
            return Db.Insert(sql, true, Take(fixedAssetCategory));
        }
        public string UpdateFixedAssetCategory(FixedAssetCategoryEntity fixedAssetCategory)
        {
            const string sql = "uspUpdate_FixedAssetCategory";
            return Db.Update(sql, true, Take(fixedAssetCategory));
        }
        public string DeleteFixedAssetCategory(FixedAssetCategoryEntity fixedAssetCategory)
        {
            const string sql = @"uspDelete_FixedAssetCategory";
            object[] parms = { "@FixedAssetCategoryId", fixedAssetCategory.FixedAssetCategoryId };
            return Db.Delete(sql, true, parms);
        }

        public string DeleteFixedAssetCategoryConvert( )
        {
            const string sql = @"usp_ConvertFixedAssetCategory";
            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }


        private static readonly Func<IDataReader, FixedAssetCategoryEntity> Make = reader =>
   new FixedAssetCategoryEntity
   {
       FixedAssetCategoryId = reader["FixedAssetCategoryID"].AsString(),
       FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
       FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString(),
       Description = reader["Description"].AsString(),
       ParentId = reader["ParentID"].AsString(),
       Grade = reader["Grade"].AsInt(),
       IsParent = reader["IsParent"].AsBool(),
       LifeTime = reader["LifeTime"].AsDecimal(),
       DepreciationRate = reader["DepreciationRate"].AsDecimal(),
       OrgPriceAccount = reader["OrgPriceAccount"].AsString(),
       DepreciationAccount = reader["DepreciationAccount"].AsString(),
       CapitalAccount = reader["CapitalAccount"].AsString(),
       BudgetChapterCode = reader["BudgetChapterCode"].AsString(),
       BudgetKindItemCode = reader["BudgetKindItemCode"].AsString(),
       BudgetSubKindItemCode = reader["BudgetSubKindItemCode"].AsString(),
       BudgetItemCode = reader["BudgetItemCode"].AsString(),
       BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
       IsActive = reader["IsActive"].AsBool()

   };
        private object[] Take(FixedAssetCategoryEntity fixedAssetCategory)
        {
            return new object[]
                {

           "@FixedAssetCategoryID", fixedAssetCategory.FixedAssetCategoryId,
           "@FixedAssetCategoryCode", fixedAssetCategory.FixedAssetCategoryCode,
           "@FixedAssetCategoryName", fixedAssetCategory.FixedAssetCategoryName,
           "@Description", fixedAssetCategory.Description,
           "@ParentID", fixedAssetCategory.ParentId,
           "@Grade", fixedAssetCategory.Grade,
           "@IsParent", fixedAssetCategory.IsParent,
           "@LifeTime", fixedAssetCategory.LifeTime,
           "@DepreciationRate", fixedAssetCategory.DepreciationRate,
           "@OrgPriceAccount", fixedAssetCategory.OrgPriceAccount,
           "@DepreciationAccount", fixedAssetCategory.DepreciationAccount,
           "@CapitalAccount", fixedAssetCategory.CapitalAccount,
           "@BudgetChapterCode", fixedAssetCategory.BudgetChapterCode,
           "@BudgetKindItemCode", fixedAssetCategory.BudgetKindItemCode,
           "@BudgetSubKindItemCode", fixedAssetCategory.BudgetSubKindItemCode,
           "@BudgetItemCode", fixedAssetCategory.BudgetItemCode,
           "@BudgetSubItemCode", fixedAssetCategory.BudgetSubItemCode,
           "@IsActive", fixedAssetCategory.IsActive
                };
        }

    }



}