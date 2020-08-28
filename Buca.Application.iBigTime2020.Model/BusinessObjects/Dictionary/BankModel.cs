/***********************************************************************
 * <copyright file="BankModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// BankModel
    /// </summary>
    public class BankModel
    {
        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>
        /// The bank account.
        /// </value>
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the bank address.
        /// </summary>
        /// <value>
        /// The bank address.
        /// </value>
        public string BankAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>
        /// The name of the bank.
        /// </value>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the budget code.
        /// </summary>
        /// <value>The budget code.</value>
        public string BudgetCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is open in bank.
        /// </summary>
        /// <value><c>true</c> if this instance is open in bank; otherwise, <c>false</c>.</value>
        public bool IsOpenInBank { get; set; }
        public bool Used { get; set; }
        public int SortBank { get; set; }
    }
}
