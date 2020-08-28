using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BudgetSourceEntityDao : IEntityBudgetSourceDao
    {

        
       

        public List<BudgetSourceEntity> GetBudgetSource(string connectionString)
        {
            List<BudgetSourceEntity> listBudgetSource = new List<BudgetSourceEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var lstBudgetProperties = context.BudgetSourceProperties.ToList();
                var lstBudgetSource = context.BudgetSources.ToList().OrderBy(x=>x.Grade);

                foreach (var result in lstBudgetSource)
                {

                    var budgetSource = new BudgetSourceEntity();

                    budgetSource.BudgetSourceId = result.BudgetSourceID.ToString();
                    budgetSource.BudgetSourceCode = result.BudgetSourceCode;
                    budgetSource.BudgetSourceName = result.BudgetSourceName;
                    budgetSource.ParentId = result.ParentID.ToString();
                    budgetSource.IsParent = result.IsParent;
                    budgetSource.BudgetSourceCategoryId = "ea7f3053-ed52-4048-9659-027481d03d25";
                    budgetSource.BudgetSourceProperty = 0;
                    budgetSource.IsSelfControl = true;
                    budgetSource.IsActive = result.Inactive == true ? false : true;
                    budgetSource.Grade = result.Grade;
                    budgetSource.BudgetCode = result.BudgetDistributionCode;
                    if (result.BudgetSourceProperty ==null)
                    {
                        budgetSource.BudgetSourceType = 0;
                    }
                    else
                    {
                        switch (result.BudgetSourceProperty.GroupPropertyID)
                        {
                            case 0:
                                budgetSource.BudgetSourceType = 2;
                                break;
                            case 1:
                                budgetSource.BudgetSourceType = 0;
                                break;
                            case 2:
                                budgetSource.BudgetSourceType = 1;
                                break;

                        }
                       
                    }



                listBudgetSource.Add(budgetSource);
                    

                }

            }

            return listBudgetSource;
        }
    }
}
