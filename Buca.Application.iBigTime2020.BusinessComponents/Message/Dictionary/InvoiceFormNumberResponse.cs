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

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class InvoiceFormNumberResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the InvoiceFormNumber.
        /// </summary>
        /// <value>
        /// The InvoiceFormNumber.
        /// </value>
        public InvoiceFormNumberEntity InvoiceFormNumberEntity { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceFormNumber identifier.
        /// </summary>
        /// <value>
        /// The InvoiceFormNumber identifier.
        /// </value>
        public string InvoiceFormNumberId { get; set; }
    }
}
