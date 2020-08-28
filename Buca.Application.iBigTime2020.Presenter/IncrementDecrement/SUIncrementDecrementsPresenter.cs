/***********************************************************************
 * <copyright file="suincrementdecrementspresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, October 25, 2017
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
    ///     SUIncrementDecrementsPresenter
    /// </summary>
    /// <seealso
    ///     cref="Buca.Application.iBigTime2020.Presenter.Presenter{ISUIncrementDecrementsView}" />
    public class SUIncrementDecrementsPresenter : Presenter<ISUIncrementDecrementsView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SUIncrementDecrementsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public SUIncrementDecrementsPresenter(ISUIncrementDecrementsView view) : base(view)
        {
        }
        
        /// <summary>
        ///     Displays this instance.
        /// </summary>
        public void Display()
        {
            View.SUIncrementDecrementModels = Model.GetSUIncrementDecrements();
        }

        /// <summary>
        /// Displays the specified reference type.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        public void Display(int refType)
        {
            View.SUIncrementDecrementModels = Model.GetSUIncrementDecrementsByRefTypeId(refType);
        }
    }
}