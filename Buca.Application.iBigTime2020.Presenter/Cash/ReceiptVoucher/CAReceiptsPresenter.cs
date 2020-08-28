/***********************************************************************
 * <copyright file="ReceiptVouchersPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 19, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.View.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Presenter.Cash.ReceiptVoucher
{
    /// <summary>
    /// ReceiptVouchersPresenter class
    /// </summary>
    public class CAReceiptsPresenter : Presenter<ICAReceiptsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CAReceiptsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CAReceiptsPresenter(ICAReceiptsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.CAReceipts = Model.GetCAReceipts();
        }

        public void DisplayByRefType(int refTypeId)
        {
            View.CAReceipts = Model.GetCAReceiptByRefTypeId(refTypeId);
        }

        public void Display(List<RefTypeModel> listRefType)
        {
            var _cAReceipts = new List<CAReceiptModel>();
            listRefType.ForEach(m => { _cAReceipts.AddRange(Model.GetCAReceiptByRefTypeId(m.RefTypeId)); });
            View.CAReceipts = _cAReceipts;
        }
    }
}
