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

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    /// <summary>
    /// InvoiceFormNumberCategoryResponse
    /// </summary>
    public class InvoiceFormNumberCategoryResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the invoice form number categor entity.
        /// </summary>
        /// <value>
        /// The invoice form number categor entity.
        /// </value>
        public InvoiceTypeEntity InvoiceFormNumberCategorEntity { get; set; }
    }
}
