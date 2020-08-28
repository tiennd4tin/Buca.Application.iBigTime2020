using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.FixedAsset;

namespace Buca.Application.iBigTime2020.View.FixedAsset
{
    /// <summary>
    /// interface IFixedAssetIncrementsView
    /// </summary>
    public interface IFixedAssetVouchersView : IView
    {
        /// <summary>
        /// Sets the fixed asset increment.
        /// </summary>
        /// <value>
        /// The fixed asset increment.
        /// </value>
        IList<FixedAssetVoucherModel> FixedAssetVouchers { set; }
    }
}
