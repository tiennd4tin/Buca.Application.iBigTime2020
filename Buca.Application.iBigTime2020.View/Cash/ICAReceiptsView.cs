/***********************************************************************
 * <copyright file="IReceiptVouchersView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;


namespace Buca.Application.iBigTime2020.View.Cash
{

    /// <summary>
    /// IReceiptVouchersView class
    /// </summary>
    public interface ICAReceiptsView : IView
    {
        /// <summary>
        /// Sets the ca receipts.
        /// </summary>
        /// <value>The ca receipts.</value>
        IList<CAReceiptModel> CAReceipts { set; }
    }
}
