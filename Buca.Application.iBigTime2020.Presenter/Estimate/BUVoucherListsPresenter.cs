/***********************************************************************
 * <copyright file="BUVoucherListsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, June 5, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.View.Estimate;

namespace Buca.Application.iBigTime2020.Presenter.Estimate
{
    /// <summary>
    ///     BUVoucherListsPresenter
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.Presenter.Presenter{IBUVoucherListsView}" />
    public class BUVoucherListsPresenter : Presenter<IBUVoucherListsView>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BUVoucherListsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BUVoucherListsPresenter(IBUVoucherListsView view) : base(view)
        {
        }

        /// <summary>
        ///     Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BUVoucherListModels = Model.GetBUVoucherList();
        }

        /// <summary>
        ///     Displays the by reference identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.BUVoucherListModels = Model.GetBUVoucherListsByRefTypeId(refTypeId);
        }

        /// <summary>
        ///     Displays the specified list reference type.
        /// </summary>
        /// <param name="listRefType">Type of the list reference.</param>
        public void Display(List<RefTypeModel> listRefType)
        {
            var _bUVoucherLists = new List<BUVoucherListModel>();
            listRefType.ForEach(m => { _bUVoucherLists.AddRange(Model.GetBUVoucherListsByRefTypeId(m.RefTypeId)); });
            View.BUVoucherListModels = _bUVoucherLists;
        }
    }
}