using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BudgetChapterEntityDao : IEntityBudgetChapterDao
    {              
        public List<BudgetChapterEntity> GetBudgetChapters(string connectionString)
        {
            List<BudgetChapterEntity> listBudgetChapter = new List<BudgetChapterEntity>();
            using (var context = new MISAEntity(connectionString))
            {              
                var lstBudgetChapter = context.BudgetChapters.ToList();

                foreach (var result in lstBudgetChapter)
                {
                    var budgetChapter = new BudgetChapterEntity();
                    budgetChapter.BudgetChapterId = result.BudgetChapterID.ToString();
                    budgetChapter.BudgetChapterCode = result.BudgetChapterCode;
                    budgetChapter.BudgetChapterName = result.BudgetChapterName;
                    budgetChapter.IsActive = result.Active;
                    listBudgetChapter.Add(budgetChapter);                    
                }
            }
            return listBudgetChapter;
        }
    }
}
