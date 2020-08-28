using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    public interface IBudgetSourcePropertyDao
    {
        /// <summary>
        /// Gets the budget source property.
        /// </summary>
        /// <param name="budgetSourcePropertyID">The budget source property identifier.</param>
        /// <returns></returns>
        BudgetSourcePropertyEntity GetBudgetSourceProperty(int budgetSourcePropertyID);
        /// <summary>
        /// Gets the budget source properties.
        /// </summary>
        /// <returns></returns>
        List<BudgetSourcePropertyEntity> GetBudgetSourceProperties();
        /// <summary>
        /// Inserts the budget source property.
        /// </summary>
        /// <param name="budgetSourceproperty">The budget sourceproperty.</param>
        /// <returns></returns>
        int InsertBudgetSourceProperty(BudgetSourcePropertyEntity budgetSourceproperty);
        /// <summary>
        /// Updates the budget source property.
        /// </summary>
        /// <param name="budgetSourceproperty">The budget sourceproperty.</param>
        string UpdateBudgetSourceProperty(BudgetSourcePropertyEntity budgetSourceproperty);
        /// <summary>
        /// Deletes the budget source property.
        /// </summary>
        /// <param name="budgetSourceproperty">The budget sourceproperty.</param>
        string DeleteBudgetSourceProperty(BudgetSourcePropertyEntity budgetSourceproperty);
    }
}
