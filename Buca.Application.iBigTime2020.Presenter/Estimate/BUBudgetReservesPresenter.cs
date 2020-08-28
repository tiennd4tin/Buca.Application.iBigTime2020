/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: December 11, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    11/12/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Estimate;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    /// <summary>
    /// BUBudgetReservesPresenter
    /// </summary>
    public class BUBudgetReservesPresenter : Presenter<IBUBudgetReservesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BUBudgetReservesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUBudgetReservesPresenter(IBUBudgetReservesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BUBudgetReserves = Model.GetBUBudgetReserves();
        }

        /// <summary>
        /// Displays the by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void DisplayByRefId(string refId)
        {
            View.BUBudgetReserves = Model.GetBUBudgetReservesByRefId(refId);
        }

        /// <summary>
        /// Displays the by reference identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.BUBudgetReserves = Model.GetBUBudgetReservesByRefType(refTypeId);
        }
    }
}
