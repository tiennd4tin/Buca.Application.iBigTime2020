/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// IAccountTranferView
    /// </summary>
    public  interface IAccountTransferView : IView
    {
        /// <summary>
        /// Gets or sets the account tranfer identifier.
        /// </summary>
        /// <value>
        /// The account tranfer identifier.
        /// </value>
         string AccountTransferId { get; set; }

        /// <summary>
        /// Gets or sets the account tranfer code.
        /// </summary>
        /// <value>
        /// The account tranfer code.
        /// </value>
         string AccountTransferCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the business.
        /// </summary>
        /// <value>
        /// The type of the business.
        /// </value>
         int BusinessType { get; set; }

        /// <summary>
        /// Gets or sets the referent account.
        /// </summary>
        /// <value>
        /// The referent account.
        /// </value>
         string ReferentAccount { get; set; }

        /// <summary>
        /// Gets or sets the transfer order.
        /// </summary>
        /// <value>
        /// The transfer order.
        /// </value>
         int TransferOrder { get; set; }

        /// <summary>
        /// Gets or sets from account.
        /// </summary>
        /// <value>
        /// From account.
        /// </value>
         string FromAccount { get; set; }

        /// <summary>
        /// Gets or sets to account.
        /// </summary>
        /// <value>
        /// To account.
        /// </value>
         string ToAccount { get; set; }

        /// <summary>
        /// Gets or sets the transfer side.
        /// </summary>
        /// <value>
        /// The transfer side.
        /// </value>
         int TransferSide { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        /// The budget source identifier.
        /// </value>
         string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
         string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is system].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is system]; otherwise, <c>false</c>.
        /// </value>
         bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
         bool IsActive { get; set; }
    }
}
