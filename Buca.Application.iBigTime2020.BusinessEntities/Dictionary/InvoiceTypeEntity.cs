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

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// InvoiceTypeEntity
    /// </summary>
   public class InvoiceTypeEntity
    {
        /// <summary>
        /// Gets or sets the invoice form number category identifier.
        /// </summary>
        /// <value>
        /// The invoice form number category identifier.
        /// </value>
        public int InvoiceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the invoice form number category code.
        /// </summary>
        /// <value>
        /// The invoice form number category code.
        /// </value>
        public string InvoiceTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the invoice form number category.
        /// </summary>
        /// <value>
        /// The name of the invoice form number category.
        /// </value>
        public string InvoiceTypeName { get; set; }

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
    }
}
