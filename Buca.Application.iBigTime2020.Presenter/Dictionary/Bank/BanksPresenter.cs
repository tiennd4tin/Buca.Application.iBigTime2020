﻿/***********************************************************************
 * <copyright file="BanksPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 08 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Bank
{
    /// <summary>
    /// BanksPresenter
    /// </summary>
    public class BanksPresenter : Presenter<IBanksView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BanksPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BanksPresenter(IBanksView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Banks = Model.GetBanks();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive(bool isActive)
        {
            View.Banks = Model.GetBanksActive(isActive);
        }
    }
}
