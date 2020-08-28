/***********************************************************************
 * <copyright file="AccountTranferModel.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// AccountTranferModel
    /// </summary>
    public class AccountTransferModel
    {
        /// <summary>
        /// Gets or sets the account tranfer identifier.
        /// </summary>
        /// <value>
        /// The account tranfer identifier.
        /// </value>
        public string AccountTransferId { get; set; }

        /// <summary>
        /// Gets or sets the account tranfer code.
        /// </summary>
        /// <value>
        /// The account tranfer code.
        /// </value>
        public string AccountTransferCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the business.
        /// </summary>
        /// <value>
        /// The type of the business.
        /// </value>
        public int BusinessType { get; set; }

        /// <summary>
        /// Gets or sets the referent account.
        /// </summary>
        /// <value>
        /// The referent account.
        /// </value>
        public string ReferentAccount { get; set; }

        /// <summary>
        /// Gets or sets the transfer order.
        /// </summary>
        /// <value>
        /// The transfer order.
        /// </value>
        public int TransferOrder { get; set; }

        /// <summary>
        /// Gets or sets from account.
        /// </summary>
        /// <value>
        /// From account.
        /// </value>
        public string FromAccount { get; set; }

        /// <summary>
        /// Gets or sets to account.
        /// </summary>
        /// <value>
        /// To account.
        /// </value>
        public string ToAccount { get; set; }

        /// <summary>
        /// Gets or sets the transfer side.
        /// </summary>
        /// <value>
        /// The transfer side.
        /// </value>
        public int TransferSide { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        /// The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is system].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is system]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
