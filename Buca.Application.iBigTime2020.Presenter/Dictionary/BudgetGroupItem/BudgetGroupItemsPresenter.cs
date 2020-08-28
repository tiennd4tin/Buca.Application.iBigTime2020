/***********************************************************************
 * <copyright file="BudgetGroupItemsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Wednesday, October 10, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetGroupItem
{
    /// <summary>
    /// BudgetGroupItemsPresenter
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{Buca.Application.iBigTime2020.View.Dictionary.IBudgetGroupItemsView}" />
    public class BudgetGroupItemsPresenter : Presenter<IBudgetGroupItemsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetGroupItemsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetGroupItemsPresenter(IBudgetGroupItemsView view) : base(view)
        {
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BudgetGroupItems = Model.GetBudgetGroupItems();
        }
    }
}
