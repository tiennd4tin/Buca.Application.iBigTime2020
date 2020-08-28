/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.VoucherList
{

    /// <summary>
    /// VoucherListPresenter class
    /// </summary>
    public class VoucherListPresenter : Presenter<IVoucherListView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherListPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public VoucherListPresenter(IVoucherListView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified voucher identifier.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        public void Display(string voucherListId)
        {
            if (voucherListId == null) { View.VoucherListId = null; return; }
            var voucherList = Model.GetVoucherList(voucherListId);
            View.VoucherListId = voucherList.VoucherListId;
            View.VoucherListCode = voucherList.VoucherListCode;
            View.VoucherListName = voucherList.VoucherListName;
            View.FromDate = voucherList.FromDate;
            View.ToDate = voucherList.ToDate;
            View.DocumentAttached = voucherList.DocumentAttached;
            View.Description = voucherList.Description;
            View.IsActive = voucherList.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            var voucherList = new VoucherListModel
                {
                    VoucherListId = View.VoucherListId,
                    VoucherListCode = View.VoucherListCode,
                    VoucherListName = View.VoucherListName,
                    DocumentAttached = View.DocumentAttached,
                    FromDate = View.FromDate,
                    ToDate = View.ToDate,
                    Description = View.Description,
                    IsActive = View.IsActive
                };
            return View.VoucherListId == null ? Model.InsertVoucherList(voucherList) : Model.UpdateVoucherList(voucherList);
            
        }

        /// <summary>
        /// Deletes the specified accont identifier.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <returns></returns>
        public string Delete(string voucherListId)
        {
            return Model.DeleteVoucherList(voucherListId);
        }
    }
}
