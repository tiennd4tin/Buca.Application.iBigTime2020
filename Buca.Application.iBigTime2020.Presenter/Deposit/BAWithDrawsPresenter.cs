/***********************************************************************
 * <copyright file="BAWithDrawsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, October 24, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Deposit;
using System.Collections.Generic;
using System.Linq;

namespace Buca.Application.iBigTime2020.Presenter.Deposit
{
    /// <summary>
    ///     BAWithDrawsPresenter
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{IBAWithDrawsView}" />
    public class BAWithDrawsPresenter : Presenter<IBAWithDrawsView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BAWithDrawsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BAWithDrawsPresenter(IBAWithDrawsView view) : base(view)
        {
        }

        /// <summary>
        ///     Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BaWithDraws = Model.GetBAWithDraws();
        }
        public void Display(int reftype)
        {
            View.BaWithDraws = Model.GetBAWithDrawsByRefTypeId(reftype);
        }

        public void Display(List<RefTypeModel> listRefType)
        {
            var _bUTransfers = new List<BAWithDrawModel>();
            listRefType.ForEach(m => { _bUTransfers.AddRange(Model.GetBAWithDrawsByRefTypeId(m.RefTypeId)); });
            View.BaWithDraws = _bUTransfers;
        }
    }
}