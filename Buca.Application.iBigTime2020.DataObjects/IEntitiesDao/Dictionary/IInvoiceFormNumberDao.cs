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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IInvoiceFormNumberDao
    /// </summary>
   public interface IInvoiceFormNumberDao
    {
        /// <summary>
        /// Gets the specified cus identifier.
        /// </summary>
        /// <param name="invoiceFormNumberId">The invoice form number identifier.</param>
        /// <returns></returns>
       InvoiceFormNumberEntity GetInvoiceFormNumberById(string invoiceFormNumberId);

       /// <summary>
       /// Getses this instance.
       /// </summary>
       /// <returns></returns>
       List<InvoiceFormNumberEntity> GetInvoiceFormNumbers();

       /// <summary>
       /// Gets the invoice form numbers by active.
       /// </summary>
       /// <returns></returns>
       List<InvoiceFormNumberEntity> GetInvoiceFormNumbersByActive();

       /// <summary>
       /// Gets the voucher lists by code.
       /// </summary>
       /// <param name="invoiceFormNumberCode">The invoice form number code.</param>
       /// <returns></returns>
       InvoiceFormNumberEntity GetInvoiceFormNumbersByCode(string invoiceFormNumberCode);

       /// <summary>
       /// Inserts the specified object.
       /// </summary>
       /// <param name="invoiceFormNumberEntity">The invoice form number entity.</param>
       /// <returns></returns>
       string InsertInvoiceFormNumber(InvoiceFormNumberEntity invoiceFormNumberEntity);

       /// <summary>
       /// Updates the specified object.
       /// </summary>
       /// <param name="invoiceFormNumberEntity">The invoice form number entity.</param>
       /// <returns></returns>
       string UpdateInvoiceFormNumber(InvoiceFormNumberEntity invoiceFormNumberEntity);

       /// <summary>
       /// Deletes the specified object.
       /// </summary>
       /// <param name="invoiceFormNumberEntity">The invoice form number entity.</param>
       /// <returns></returns>
       string DeleteInvoiceFormNumber(InvoiceFormNumberEntity invoiceFormNumberEntity);
        string DeleteInvoiceFormNumberConvert();
    }
}
