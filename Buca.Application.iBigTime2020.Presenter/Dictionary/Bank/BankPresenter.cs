/***********************************************************************
 * <copyright file="BankPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 08 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using System.Linq;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Bank
{
    /// <summary>
    /// BankPresenter
    /// </summary>
    public class BankPresenter : Presenter<IBankView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BankPresenter(IBankView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified bank identifier.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        public void Display(string bankId)
        {
            if (bankId == null) { View.BankId = null; return; }

            var bank = Model.GetBank(bankId);

            View.BankId = bank.BankId;
            View.BankAccount = bank.BankAccount;
            View.BankAddress = bank.BankAddress;
            View.BankName = bank.BankName;
            View.BudgetCode = bank.BudgetCode;
            View.Description = bank.Description;
            View.IsActive = bank.IsActive;
            View.IsOpenInBank = bank.IsOpenInBank;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var bank = new BankModel
            {
                BankId = View.BankId,
                BankAccount = View.BankAccount,
                BankAddress = View.BankAddress,
                BankName = View.BankName,
                BudgetCode = View.BudgetCode,
                Description = View.Description,
                IsActive = View.IsActive,
                IsOpenInBank = View.IsOpenInBank
            };

            return View.BankId == null ? Model.AddBank(bank) : Model.UpdateBank(bank);
        }

        /// <summary>
        /// Deletes the specified bank identifier.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns></returns>
        public string Delete(string bankId)
        {
            return Model.DeleteBank(bankId);
        }

        /// <summary>
        /// Codes the is exist.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <param name="bankCode">The bank code.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CodeIsExist(string bankId, string bankCode)
        {
            var bank = Model.GetBanks()
                .Where(x => x.BankId != bankId && x.BankAccount == bankCode).ToList();
            return bank.Any();
        }
    }
}
