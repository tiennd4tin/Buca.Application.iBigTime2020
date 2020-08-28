/***********************************************************************
 * <copyright file="AutoBusinessEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 26 September 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AccountTransfer
{
    public class AccountTransfersPresenter : Presenter<IAccountTransfersView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTransfersPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountTransfersPresenter(IAccountTransfersView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.AccountTranfers = Model.GetAccountTransfers();
        }

        /// <summary>
        /// Get list Account Category
        /// </summary>
        /// <returns>IList{Model.BusinessObjects.Dictionary.AccountCategoryModel}.</returns>
        public IList<Model.BusinessObjects.Dictionary.AccountTransferModel> GetAccountTransfers()
        {
            return Model.GetAccountTransfers();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.AccountTranfers = Model.GetAccountTransfersActive();
        }
    }
}
