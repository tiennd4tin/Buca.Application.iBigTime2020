using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.FixedAsset;
using Buca.Application.iBigTime2020.View.FixedAsset;

namespace Buca.Application.iBigTime2020.Presenter.FixedAsset.FixedAssetLedger
{
    /// <summary>
    /// class FixedAssetLedgersPresenter
    /// </summary>
    public class FixedAssetLedgersPresenter : Presenter<IFixedAssetLedgersView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetLedgersPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetLedgersPresenter(IFixedAssetLedgersView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the by year.
        /// </summary>
        /// 
        //public IList<FixedAssetLedgerModel>  Display(int fixedAssetId)
        //{
        //    //var fixedAssetLedgers = Model.GetFixedAssetLedgerByFixedAssets(fixedAssetId);
        //   // return fixedAssetLedgers;
        //}

 
    }
}
