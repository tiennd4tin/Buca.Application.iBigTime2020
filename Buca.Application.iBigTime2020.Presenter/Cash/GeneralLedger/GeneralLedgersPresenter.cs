/***********************************************************************
 * <copyright file="GeneralLedgersPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Cash;


namespace Buca.Application.iBigTime2020.Presenter.Cash.GeneralLedger
{
    /// <summary>
    /// class GeneralLedgersPresenter
    /// </summary>
    public class GeneralLedgersPresenter : Presenter<IGeneralLedgersView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralLedgersPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public GeneralLedgersPresenter(IGeneralLedgersView view)
            : base(view)
        {
        }
        public void Display()
        {
             //View.GeneralLedgers = Model.GetSearchVoucher(FromDate, ToDate, CurrencyCode, DepartmentCode, FixedAssetCode, BudgetGroupCode);
           // View.GeneralLedgers = GeneralLedgerDao.GetSearchVoucher(FromDate, ToDate, CurrencyCode, DepartmentCode, FixedAssetCode, BudgetGroupCode);

        }
    }
}
