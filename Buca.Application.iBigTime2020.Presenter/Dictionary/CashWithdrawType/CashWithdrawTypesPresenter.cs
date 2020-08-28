/***********************************************************************
 * <copyright file="CashWithdrawTypesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Friday, September 29, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
 
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType
{
    /// <summary>
    ///     CashWithdrawTypesPresenter
    /// </summary>
    /// <seealso cref="ICashWithdrawTypesView" />
    public class CashWithdrawTypesPresenter : Presenter<ICashWithdrawTypesView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CashWithdrawTypesPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CashWithdrawTypesPresenter(ICashWithdrawTypesView view) : base(view)
        {
        }

        /// <summary>
        ///     Dises the play.
        /// </summary>
        /// <param name="cashWithdrawType">Type of the cash withdraw.</param>
        public void DisPlay(int cashWithdrawType)
        {
           // View.CashWithdrawTypeModel = Model.GetCashWithdrawTypeModel(cashWithdrawType);
        }

        /// <summary>
        ///     Displays the list.
        /// </summary>
        public void DisplayList()
        {
            View.CashWithdrawTypeModels = Model.GetCashWithdrawTypeModels();
        }
    }
}