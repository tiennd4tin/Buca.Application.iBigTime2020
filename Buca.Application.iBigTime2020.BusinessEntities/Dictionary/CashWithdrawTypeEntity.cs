/***********************************************************************
 * <copyright file="CashWithdrawTypeEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Friday, September 29, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    ///     CashWithdrawTypeEntity
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class CashWithdrawTypeEntity : BusinessEntities
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CashWithdrawTypeEntity" /> class.
        /// </summary>
        public CashWithdrawTypeEntity()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CashWithdrawTypeEntity" /> class.
        /// </summary>
        /// <param name="cashWithdrawTypeId">The cash withdraw type identifier.</param>
        /// <param name="cashWithdrawTypeName">Name of the cash withdraw type.</param>
        /// <param name="cashWithdrawNo">The cash withdraw no.</param>
        /// <param name="subSystemId">The sub system identifier.</param>
        public CashWithdrawTypeEntity(int cashWithdrawTypeId, string cashWithdrawTypeName, string cashWithdrawNo,
            int subSystemId)
            : this()
        {
            CashWithdrawTypeId = cashWithdrawTypeId;
            CashWithdrawTypeName = cashWithdrawTypeName;
            CashWithdrawNo = cashWithdrawNo;
            SubSystemId = subSystemId;
        }

        /// <summary>
        ///     Gets or sets the cash withdraw type identifier.
        /// </summary>
        /// <value>
        ///     The cash withdraw type identifier.
        /// </value>
        public int CashWithdrawTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the cash withdraw type.
        /// </summary>
        /// <value>
        ///     The name of the cash withdraw type.
        /// </value>
        public string CashWithdrawTypeName { get; set; }

        /// <summary>
        ///     Gets or sets the cash withdraw no.
        /// </summary>
        /// <value>
        ///     The cash withdraw no.
        /// </value>
        public string CashWithdrawNo { get; set; }

        /// <summary>
        ///     Gets or sets the sub system identifier.
        /// </summary>
        /// <value>
        ///     The sub system identifier.
        /// </value>
        public int SubSystemId { get; set; }
    }
}