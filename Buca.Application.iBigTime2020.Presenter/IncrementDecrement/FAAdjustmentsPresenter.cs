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
 
    public class FAAdjustmentsPresenter : Presenter<IFAAdjustmenstView>
    {

        public FAAdjustmentsPresenter(IFAAdjustmenstView view) : base(view)
        {
        }
        public void Display()
        {
           View.FAAdjustments = Model.GetFAAdjustments();
        }

        public void Display(int refType)
        {
           // View.FAIncrementDecrements = Model.GetFAIncrementDecrementsByRefTypeId(refType);
        }
    }
}