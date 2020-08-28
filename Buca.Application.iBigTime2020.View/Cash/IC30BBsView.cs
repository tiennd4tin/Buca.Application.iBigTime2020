/***********************************************************************
 * <copyright file="IReceiptVouchersView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher;

namespace Buca.Application.iBigTime2020.View.Cash
{
    /// <summary>
    /// interface IC30BBsVie
    /// </summary>
    public interface IC30BBsView : IView
    {
        /// <summary>
        /// Sets the C30 b bs.
        /// </summary>
        /// <value>
        /// The C30 b bs.
        /// </value>
        IList<C40BBModel> C30BBs { set; }
    }
}
