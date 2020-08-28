/***********************************************************************
 * <copyright file="PurchasePurposeModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Thursday, October 12, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    ///     PurchasePurposeModel
    /// </summary>
    public class PurchasePurposeModel
    {
        /// <summary>
        ///     Gets or sets the purchase purpose identifier.
        /// </summary>
        /// <value>
        ///     The purchase purpose identifier.
        /// </value>
        public string PurchasePurposeId { get; set; }

        /// <summary>
        ///     Gets or sets the purchase purpose code.
        /// </summary>
        /// <value>
        ///     The purchase purpose code.
        /// </value>
        public string PurchasePurposeCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the purchase purpose.
        /// </summary>
        /// <value>
        ///     The name of the purchase purpose.
        /// </value>
        public string PurchasePurposeName { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is system; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="PurchasePurposeModel" /> is inactive.
        /// </summary>
        /// <value>
        ///     <c>true</c> if isactive; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}