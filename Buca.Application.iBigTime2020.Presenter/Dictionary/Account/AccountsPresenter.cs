/***********************************************************************
 * <copyright file="AccountsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Account
{
    /// <summary>
    /// class AccountsPresenter
    /// </summary>
    public class AccountsPresenter : Presenter<IAccountsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountsPresenter(IAccountsView view)
            : base(view)
        {
        }

  
        public void Display()
        {
            View.Accounts = Model.GetAccounts();
        }
        public IList<Model.BusinessObjects.Dictionary.AccountModel> GetAccounts()
        {
            return Model.GetAccounts();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.Accounts = Model.GetAccountsByIsActive(true);
        }
        /// <summary>
        /// Displays the IsParent
        /// </summary>
        public void DisplayByIsDetail(bool IsParent)
        {
            View.Accounts = Model.GetAccountsByIsDetail(IsParent);
        }
        public void DisplayForComboTree(string accountId)
        {
            View.Accounts = Model.GetAccountsForComboTree(accountId);
        }

        /// <summary>
        /// Displays the by detail by inventory item.
        /// </summary>
        /// <param name="detailByInventoryItem">if set to <c>true</c> [detail by inventory item].</param>
        public void DisplayByDetailByInventoryItem(bool detailByInventoryItem)
        {
            var acounts = Model.GetAccountsByIsActive(true);
            View.Accounts = acounts.Where(x => x.DetailByInventoryItem == detailByInventoryItem).ToList();
        }
    }
}
