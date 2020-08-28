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

using Buca.Application.iBigTime2020.View.General;

namespace Buca.Application.iBigTime2020.Presenter.General
{
    /// <summary>
    /// GLVouchersPresenter
    /// </summary>
    public class GLVouchersPresenter : Presenter<IGLVouchersView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GLVouchersPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public GLVouchersPresenter(IGLVouchersView view) : base(view)
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
