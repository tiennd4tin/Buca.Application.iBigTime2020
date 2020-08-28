using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.View.Estimate
{
    public interface IBUTransferDetailPurchasesView : IView
    {
        IList<BUTransferDetailPurchaselModel> BUTransferDetailPurchases { get; set; }
    }
}
