/***********************************************************************
 * <copyright file="AccountTransferEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 25 September 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// AccountTransferEntity
    /// </summary>
    public class AccountTransferEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTransferEntity"/> class.
        /// </summary>
        public AccountTransferEntity()
        {
            AddRule(new ValidateRequired("AccountTransferCode"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTransferEntity"/> class.
        /// </summary>
        /// <param name="accountTransferId">The account transfer identifier.</param>
        /// <param name="accountTransferCode">The account transfer code.</param>
        /// <param name="businessType">Type of the business.</param>
        /// <param name="referentAccount">The referent account.</param>
        /// <param name="transferOrder">The transfer order.</param>
        /// <param name="fromAccount">From account.</param>
        /// <param name="toAccount">To account.</param>
        /// <param name="transferSide">The transfer side.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="description">The description.</param>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public AccountTransferEntity(string accountTransferId, string accountTransferCode, int businessType, string referentAccount, int transferOrder, string fromAccount,
           string toAccount, int transferSide, string budgetSourceId, string description, bool isSystem, bool isActive)
            : this()
        {
            AccountTransferId = accountTransferId;
            AccountTransferCode = accountTransferCode;
            BusinessType = businessType;
            ReferentAccount = referentAccount;
            TransferOrder = transferOrder;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            TransferSide = transferSide;
            BudgetSourceId = budgetSourceId;
            Description = description;
            IsSystem = isSystem;
            IsActive = isActive;
        }

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
