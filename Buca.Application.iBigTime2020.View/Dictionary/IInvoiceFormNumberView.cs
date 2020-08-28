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

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// IInvoiceFormNumberView
    /// </summary>
    public interface IInvoiceFormNumberView : IView
    {
        /// <summary>
        /// Gets or sets the invoice form number identifier.
        /// </summary>
        /// <value>
        /// The invoice form number identifier.
        /// </value>
        string InvoiceFormNumberId { get; set; }

        /// <summary>
        /// Gets or sets the invoice form number code.
        /// </summary>
        /// <value>
        /// The invoice form number code.
        /// </value>
        string InvoiceFormNumberCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the invoice form number.
        /// </summary>
        /// <value>
        /// The name of the invoice form number.
        /// </value>
        string InvoiceFormNumberName { get; set; }

        /// <summary>
        /// Gets or sets the type of the invoice.
        /// </summary>
        /// <value>
        /// The type of the invoice.
        /// </value>
        int InvoiceType { get; set; }

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
