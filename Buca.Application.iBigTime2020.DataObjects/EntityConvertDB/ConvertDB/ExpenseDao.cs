using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class ExpenseDao : IEntityExpenseDao
    {
       
       public  List<BudgetExpenseEntity> GetExpense(string connectionString)
        {  
            List<BudgetExpenseEntity> listExpense = new List<BudgetExpenseEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.BudgetExpenses.ToList();
                foreach (var result in categories)
                {
                    var budgetExpense = new BudgetExpenseEntity();
                    budgetExpense.BudgetExpenseId = result.BudgetExpenseID.ToString();
                    budgetExpense.BudgetExpenseCode = result.BudgetExpenseCode;
                    budgetExpense.BudgetExpenseName = result.BudgetExpenseName;
                    budgetExpense.IsActive = result.Inactive ==true?false:true;
                    budgetExpense.IsSystem = result.IsSystem;
                    budgetExpense.BudgetExpenseType = result.BudgetExpenseType;


                    listExpense.Add(budgetExpense);

                }

               
            }

            return listExpense;
        }

      
    }
}
