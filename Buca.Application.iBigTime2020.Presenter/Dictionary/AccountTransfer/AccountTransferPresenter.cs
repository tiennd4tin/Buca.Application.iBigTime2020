/***********************************************************************
 * <copyright file="AutoBusinessEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 27 September 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.AccountTransfer
{
    public class AccountTransferPresenter : Presenter<IAccountTransferView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTransferPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountTransferPresenter(IAccountTransferView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified account category identifier.
        /// </summary>
        /// <param name="accountTransferId">The account transfer identifier.</param>
        public void Display(string accountTransferId)
        {
            if (accountTransferId == null)
            {
                View.AccountTransferId = null;
                return;
            }

            var accountTransfer = Model.GetAccountTransfer(accountTransferId);

            View.AccountTransferId = accountTransfer.AccountTransferId;
            View.BusinessType = accountTransfer.BusinessType;
            View.AccountTransferCode = accountTransfer.AccountTransferCode;
            View.ReferentAccount = accountTransfer.ReferentAccount;
            View.TransferOrder = accountTransfer.TransferOrder;
            View.FromAccount = accountTransfer.FromAccount;
            View.ToAccount = accountTransfer.ToAccount;
            View.TransferSide = accountTransfer.TransferSide;
            View.BudgetSourceId = accountTransfer.BudgetSourceId;
            View.Description = accountTransfer.Description;
            View.IsSystem = accountTransfer.IsSystem;
            View.IsActive = accountTransfer.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var accountTransfer = new AccountTransferModel()
            {
                AccountTransferId = View.AccountTransferId,
                BusinessType = View.BusinessType,
                AccountTransferCode = View.AccountTransferCode,
                ReferentAccount = View.ReferentAccount,
                TransferOrder = View.TransferOrder,
                FromAccount = View.FromAccount,
                ToAccount = View.ToAccount,
                TransferSide = View.TransferSide,
                BudgetSourceId = View.BudgetSourceId,
                Description = View.Description,
                IsSystem = View.IsSystem,
                IsActive = View.IsActive
            };

            if (View.AccountTransferId == null)
                return Model.AddAccountTransfer(accountTransfer);
            return Model.UpdateAccountTransfer(accountTransfer);
        }

        /// <summary>
        /// Deletes the specified account category identifier.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        public string Delete(string accountTranferId)
        {
            return Model.DeleteAccountTransfer(accountTranferId);
        }
    }
}
