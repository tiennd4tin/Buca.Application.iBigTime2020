/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;

namespace Buca.Application.iBigTime2020.View.General
{
    /// <summary>
    /// GLVouchersView
    /// </summary>
    public interface IGLVouchersEarlyYearView: IView
    {
        IList<GLVoucherModel> GLVouchers { set; }

        /// <summary>
        /// Sets the fa depreciations.
        /// </summary>
        /// <value>
        /// The fa depreciations.
        /// </value>
        IList<GLVoucherDetailModel> GLVoucherDetails { set; }

        /// <summary>
        /// Gets the gl voucher detail taxes.
        /// </summary>
        /// <value>
        /// The gl voucher detail taxes.
        /// </value>
        IList<GLVoucherDetailTaxModel> GLVoucherDetailTaxes { get; }
    }
}
