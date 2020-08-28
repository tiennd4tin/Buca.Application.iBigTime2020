/***********************************************************************
 * <copyright file="BUTransfersPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    public class BUTransferDetailPurchasePresenter : Presenter<IBUTransferDetailPurchasesView>
    {
        public BUTransferDetailPurchasePresenter(IBUTransferDetailPurchasesView view)
            : base(view)
        {
        }
        
        public void DisplayByRefId(string refId)
        {
            View.BUTransferDetailPurchases = Model.GetBUTransferDetailPurchasesByRefId(refId);
        }
    }
}
