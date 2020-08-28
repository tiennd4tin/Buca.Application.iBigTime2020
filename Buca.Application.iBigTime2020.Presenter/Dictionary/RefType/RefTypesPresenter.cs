/***********************************************************************
 * <copyright file="RefTypesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.RefType
{
    public class RefTypesPresenter : Presenter<IRefTypesView>
    {
        /// <summary>
        /// RefTypets the presenter.
        /// </summary>
        /// <param name="view">The view.</param>
        public RefTypesPresenter(IRefTypesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.RefTypes = Model.GetRefTypes();
        }
    }
}
