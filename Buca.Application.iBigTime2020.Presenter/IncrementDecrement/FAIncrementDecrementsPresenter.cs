/***********************************************************************
 * <copyright file="FAIncrementDecrementsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.IncrementDecrement;

namespace Buca.Application.iBigTime2020.Presenter.IncrementDecrement
{
    /// <summary>
    ///     FAIncrementDecrementsPresenter
    /// </summary>
    /// <seealso
    ///     cref="Buca.Application.iBigTime2020.Presenter.Presenter{IFAIncrementDecrementsView}" />
    public class FAIncrementDecrementsPresenter : Presenter<IFAIncrementDecrementsView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FAIncrementDecrementsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FAIncrementDecrementsPresenter(IFAIncrementDecrementsView view) : base(view)
        {
        }

        /// <summary>
        ///     Displays this instance.
        /// </summary>
        public void Display()
        {
            View.FAIncrementDecrements = Model.GetFAIncrementDecrements();
        }

        /// <summary>
        ///     Displays the specified reference type.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        public void Display(int refType)
        {
            View.FAIncrementDecrements = Model.GetFAIncrementDecrementsByRefTypeId(refType);
        }
    }
}