/***********************************************************************
 * <copyright file="AccountCategoryPresenter.cs" company="BUCA JSC">
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

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AccountCategory
{
    /// <summary>
    /// Class AccountCategoryPresenter.
    /// </summary>
    public class AccountCategoryPresenter : Presenter<IAccountCategoryView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCategoryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountCategoryPresenter(IAccountCategoryView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified account category identifier.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        public void Display(string accountCategoryId)
        {
            if (accountCategoryId == null)
            {
                View.AccountCategoryId = null;
                return;
            }

            var accountCategory = Model.GetAccountCategory(accountCategoryId);

            View.AccountCategoryId = accountCategory.AccountCategoryId;
            View.AccountCategoryName = accountCategory.AccountCategoryName;
            View.AccountCategoryKind = accountCategory.AccountCategoryKind;
            View.DetailByBudgetSource = accountCategory.DetailByBudgetSource;
            View.DetailByBudgetChapter = accountCategory.DetailByBudgetChapter;
            View.DetailByBudgetKindItem = accountCategory.DetailByBudgetKindItem;
            View.DetailByBudgetItem = accountCategory.DetailByBudgetItem;
            View.DetailByBudgetSubItem = accountCategory.DetailByBudgetSubItem;
            View.DetailByMethodDistribute = accountCategory.DetailByMethodDistribute;
            View.DetailByAccountingObject = accountCategory.DetailByAccountingObject;
            View.DetailByActivity = accountCategory.DetailByActivity;
            View.DetailByProject = accountCategory.DetailByProject;
            View.DetailByTask = accountCategory.DetailByTask;
            View.DetailBySupply = accountCategory.DetailBySupply;
            View.DetailByInventoryItem = accountCategory.DetailByInventoryItem;
            View.DetailByFixedAsset = accountCategory.DetailByFixedAsset;
            View.DetailByBankAccount = accountCategory.DetailByBankAccount;
            View.DetailByFund = accountCategory.DetailByFund;
            View.IsActive = accountCategory.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var accountCategory = new AccountCategoryModel
            {
                AccountCategoryId = View.AccountCategoryId,
                AccountCategoryName = View.AccountCategoryName,
                AccountCategoryKind = View.AccountCategoryKind,
                DetailByBudgetSource = View.DetailByBudgetSource,
                DetailByBudgetChapter = View.DetailByBudgetChapter,
                DetailByBudgetKindItem = View.DetailByBudgetKindItem,
                DetailByBudgetItem = View.DetailByBudgetItem,
                DetailByBudgetSubItem = View.DetailByBudgetSubItem,
                DetailByMethodDistribute = View.DetailByMethodDistribute,
                DetailByAccountingObject = View.DetailByAccountingObject,
                DetailByActivity = View.DetailByActivity,
                DetailByProject = View.DetailByProject,
                DetailByTask = View.DetailByTask,
                DetailBySupply = View.DetailBySupply,
                DetailByInventoryItem = View.DetailByInventoryItem,
                DetailByFixedAsset = View.DetailByFixedAsset,
                DetailByBankAccount = View.DetailByBankAccount,
                DetailByFund = View.DetailByFund,
                IsActive = View.IsActive
            };

            if (View.AccountCategoryId == null)
                return Model.AddAccountCategory(accountCategory);
            return Model.UpdateAccountCategory(accountCategory);
        }

        /// <summary>
        /// Deletes the specified account category identifier.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>System.Int32.</returns>
        public string Delete(string accountCategoryId)
        {
            return Model.DeleteAccountCategory(accountCategoryId);
        }
    }
}
