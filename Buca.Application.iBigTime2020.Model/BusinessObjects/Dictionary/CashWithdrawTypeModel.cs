/***********************************************************************
 * <copyright file="CashWithdrawTypeModel.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    ///     CashWithdrawTypeModel
    /// </summary>
    public class CashWithdrawTypeModel
    {
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