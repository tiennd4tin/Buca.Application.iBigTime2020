﻿/***********************************************************************
 * <copyright file="CalulateClosingsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, December 25, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.CalculateClosing
{

    /// <summary>
    /// CalulateClosingsPresenter class
    /// </summary>
    public class CalulateClosingsPresenter : Presenter<ICalculateClosingsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalulateClosingsPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CalulateClosingsPresenter(ICalculateClosingsView view)
            : base(view)
        {
        }

    }
}
