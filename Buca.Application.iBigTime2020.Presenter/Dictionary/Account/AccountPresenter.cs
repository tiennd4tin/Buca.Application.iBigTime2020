/***********************************************************************
 * <copyright file="AccountPresenter.cs" company="BUCA JSC">
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


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Account
{
    /// <summary>
    /// class AccountPresenter 
    /// </summary>
    public class AccountPresenter : Presenter<IAccountView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountPresenter(IAccountView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        public void Display(string accountId)
        {
            if (accountId == null)
            {
                View.AccountId =null;
                return;
            }

            var account = Model.GetAccount(accountId);

            View.AccountId = account.AccountId;
            View.AccountNumber = account.AccountNumber;
            View.AccountCategoryId = account.AccountCategoryId;
            View.ParentId = account.ParentId;
            View.AccountName = account.AccountName;
            View.AccountForeignName = account.AccountForeignName;
            View.Description = account.Description;
            View.AccountCategoryKind = account.AccountCategoryKind;
            View.DetailByBudgetSource = account.DetailByBudgetSource;
            View.DetailByBudgetChapter = account.DetailByBudgetChapter;
            View.DetailByBudgetKindItem = account.DetailByBudgetKindItem;
            View.DetailByBudgetItem = account.DetailByBudgetItem;
            View.DetailByBudgetSubItem = account.DetailByBudgetSubItem;
            View.DetailByMethodDistribute = account.DetailByMethodDistribute;
            View.DetailByAccountingObject = account.DetailByAccountingObject;
            View.DetailByActivity = account.DetailByActivity;
            View.DetailByProject = account.DetailByProject;
            View.DetailByTask = account.DetailByTask;
            View.DetailBySupply = account.DetailBySupply;
            View.DetailByInventoryItem = account.DetailByInventoryItem;
            View.DetailByFixedAsset = account.DetailByFixedAsset;
            View.DetailByFund = account.DetailByFund;
            View.DetailByBankAccount = account.DetailByBankAccount;
            View.DetailByProjectActivity = account.DetailByProjectActivity;
            View.DetailByInvestor = account.DetailByInvestor;
            View.Grade = account.Grade;
            View.IsParent = account.IsParent;
            View.IsActive = account.IsActive;
            View.IsDisplayOnAccountBalanceSheet = account.IsDisplayOnAccountBalanceSheet;
            View.IsDisplayBalanceOnReport = account.IsDisplayBalanceOnReport;
            View.DetailByCurrency = account.DetailByCurrency;
            View.DetailByBudgetExpense = account.DetailByBudgetExpense;
            View.DetailByExpense = account.DetailByExpense;
            View.DetailByContract = account.DetailByContract;
            View.DetailByCapitalPlan = account.DetailByCapitalPlan;
        }

        /// <summary>
        /// Displays the by account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        public void DisplayByAccountCode(string accountNumber)
        {
            if (accountNumber == null)
            {
                View.AccountId = null; 
                return;
            }

            var account = Model.GetAccountbyAccountNumber(accountNumber);
            View.AccountId = account.AccountId;
            View.AccountNumber = account.AccountNumber;
            View.AccountCategoryId = account.AccountCategoryId;
            View.ParentId = account.ParentId;
            View.AccountName = account.AccountName;
            View.AccountForeignName = account.AccountForeignName;
            View.Description = account.Description;
            View.AccountCategoryKind = account.AccountCategoryKind;
            View.DetailByBudgetSource = account.DetailByBudgetSource;
            View.DetailByBudgetChapter = account.DetailByBudgetChapter;
            View.DetailByBudgetKindItem = account.DetailByBudgetKindItem;
            View.DetailByBudgetItem = account.DetailByBudgetItem;
            View.DetailByBudgetSubItem = account.DetailByBudgetSubItem;
            View.DetailByMethodDistribute = account.DetailByMethodDistribute;
            View.DetailByAccountingObject = account.DetailByAccountingObject;
            View.DetailByActivity = account.DetailByActivity;
            View.DetailByProject = account.DetailByProject;
            View.DetailByTask = account.DetailByTask;
            View.DetailBySupply = account.DetailBySupply;
            View.DetailByInventoryItem = account.DetailByInventoryItem;
            View.DetailByFixedAsset = account.DetailByFixedAsset;
            View.DetailByFund = account.DetailByFund;
            View.DetailByBankAccount = account.DetailByBankAccount;
            View.DetailByProjectActivity = account.DetailByProjectActivity;
            View.DetailByInvestor = account.DetailByInvestor;
            View.Grade = account.Grade;
            View.IsParent = account.IsParent;
            View.IsActive = account.IsActive;
            View.IsDisplayOnAccountBalanceSheet = account.IsDisplayOnAccountBalanceSheet;
            View.IsDisplayBalanceOnReport = account.IsDisplayBalanceOnReport;
            View.DetailByCurrency = account.DetailByCurrency;
            View.DetailByBudgetExpense = account.DetailByBudgetExpense;
            View.DetailByExpense = account.DetailByExpense;
            View.DetailByContract = account.DetailByContract;
            View.DetailByCapitalPlan = account.DetailByCapitalPlan;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var account = new AccountModel
            {
                AccountId = View.AccountId,
                AccountNumber = View.AccountNumber,
                AccountCategoryId = View.AccountCategoryId,
                ParentId = View.ParentId,
                AccountName = View.AccountName,
                AccountForeignName = View.AccountForeignName,
                Description = View.Description,
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
                DetailByFund = View.DetailByFund,
                DetailByBankAccount = View.DetailByBankAccount,
                DetailByProjectActivity = View.DetailByProjectActivity,
                DetailByInvestor = View.DetailByInvestor,
                Grade = View.Grade,
                IsParent = View.IsParent,
                IsActive = View.IsActive,
                IsDisplayOnAccountBalanceSheet = View.IsDisplayOnAccountBalanceSheet,
                IsDisplayBalanceOnReport = View.IsDisplayBalanceOnReport,
                DetailByCurrency = View.DetailByCurrency,
           DetailByBudgetExpense = View.DetailByBudgetExpense,
           DetailByExpense = View.DetailByExpense,
           DetailByContract = View.DetailByContract,
           DetailByCapitalPlan = View.DetailByCapitalPlan,

            };
         if (View.AccountId == null)
                return Model.AddAccount(account);
            return Model.UpdateAccount(account);
        }

        /// <summary>
        /// Deletes the specified accont identifier.
        /// </summary>
        /// <param name="accountId">The accont identifier.</param>
        /// <returns></returns>
        public string Delete(string accountId)
        {
            return Model.DeleteAccount(accountId);
        }
        public string CheckExistAccountNumber(string accountId, string accountNumber)
        {
            return Model.CheckExistAccountNumber(accountId, accountNumber);
        }
    }
}
