using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class FixedAssetCategoryEntityDao : IEntityFixedAssetCategoryDao
    {
       
       public  List<FixedAssetCategoryEntity> GetFixedAssetCategory(string connectionString)
        {  
            List<FixedAssetCategoryEntity> listFixedAssetCategory = new List<FixedAssetCategoryEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.FixedAssetCategories.ToList().OrderBy(x=>x.Grade);
                foreach (var result in categories)
                {
                    var fixedAssetCategory = new FixedAssetCategoryEntity();
                    fixedAssetCategory.FixedAssetCategoryId = result.FixedAssetCategoryID.ToString();
                    fixedAssetCategory.FixedAssetCategoryCode = result.FixedAssetCategoryCode;
                    fixedAssetCategory.FixedAssetCategoryName = result.FixedAssetCategoryName;
                    fixedAssetCategory.Description = result.Description;
                    fixedAssetCategory.ParentId = result.ParentID.ToString();
                    fixedAssetCategory.Grade = result.Grade;
                    fixedAssetCategory.IsParent = result.IsParent;
                    fixedAssetCategory.LifeTime = result.LifeTime??0;
                    fixedAssetCategory.DepreciationRate = result.DepreciationRate??0;
                    fixedAssetCategory.OrgPriceAccount = result.OrgPriceAccount;
                    fixedAssetCategory.DepreciationAccount = result.DepreciationAccount;
                    fixedAssetCategory.CapitalAccount = result.CapitalAccount;
                    fixedAssetCategory.BudgetChapterCode = result.BudgetChapterCode;
                    fixedAssetCategory.BudgetKindItemCode = result.BudgetKindItemCode;
                    fixedAssetCategory.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                    fixedAssetCategory.BudgetItemCode = result.BudgetItemCode;
                    fixedAssetCategory.BudgetSubItemCode = result.BudgetSubItemCode;
                    fixedAssetCategory.IsActive = true;


                    listFixedAssetCategory.Add(fixedAssetCategory);

                }

               
            }

            return listFixedAssetCategory;
        }

      
    }
}
