/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 12, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// 
    /// </summary>
    public class InvoiceFormNumberEntity : BusinessEntities
    {
        public InvoiceFormNumberEntity()
        {
            AddRule(new ValidateRequired("InvoiceFormNumberCode"));
            AddRule(new ValidateRequired("InvoiceFormNumberName"));
        }

        /// <summary>
        /// Gets or sets the invoice form number identifier.
        /// </summary>
        /// <value>
        /// The invoice form number identifier.
        /// </value>
        public string InvoiceFormNumberId { get; set; }

        /// <summary>
        /// Gets or sets the invoice form number code.
        /// </summary>
        /// <value>
        /// The invoice form number code.
        /// </value>
        public string InvoiceFormNumberCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the invoice form number.
        /// </summary>
        /// <value>
        /// The name of the invoice form number.
        /// </value>
        public string InvoiceFormNumberName { get; set; }

        /// <summary>
        /// Gets or sets the type of the invoice.
        /// </summary>
        /// <value>
        /// The type of the invoice.
        /// </value>
        public int InvoiceType { get; set; }

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
