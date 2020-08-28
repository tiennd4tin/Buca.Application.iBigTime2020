/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System;
using Buca.Application.iBigTime2020.View.General;

namespace Buca.Application.iBigTime2020.Presenter.General
{
    /// <summary>
    /// GLVouchersPresenter
    /// </summary>
    public class GLVouchersLastYearPresenter : Presenter<IGLVouchersLastYearView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GLVouchersLastYearPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public GLVouchersLastYearPresenter(IGLVouchersLastYearView view) : base(view)
        {
        }

        /// <summary>
        ///     Displays this instance.
        /// </summary>
        public void Display()
        {
            View.GLVouchers = Model.GetGLVouchers();
        }

        /// <summary>
        /// Displays the specified reference type.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        public void Display(int refType)
        {
            View.GLVouchers = Model.GetGLVouchersByRefTypeId(refType);
        }

     
    }
}
