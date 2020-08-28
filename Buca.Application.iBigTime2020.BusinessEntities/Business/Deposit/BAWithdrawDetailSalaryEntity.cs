/***********************************************************************
 * <copyright file="BAWithdrawDetailSalaryEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Monday, October 23, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit
{
    /// <summary>
    ///     BAWithdrawDetailSalaryEntity
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class BAWithdrawDetailSalaryEntity : BusinessEntities
    {
        /// <summary>
        ///     Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>
        ///     The reference detail identifier.
        /// </value>
        public string RefDetailId { get; set; }

        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        ///     Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        ///     The employee identifier.
        /// </value>
        public string EmployeeId { get; set; }

        /// <summary>
        ///     Gets or sets the net wage amount.
        /// </summary>
        /// <value>
        ///     The net wage amount.
        /// </value>
        public decimal NetWageAmount { get; set; }

        /// <summary>
        ///     Gets or sets the sort order.
        /// </summary>
        /// <value>
        ///     The sort order.
        /// </value>
        public int SortOrder { get; set; }
    }
}