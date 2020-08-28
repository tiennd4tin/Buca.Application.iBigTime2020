﻿/***********************************************************************
 * <copyright file="IExchangeRateView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Tuesday, August 18, 2015
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    public interface IExchangeRateView : IView
    {
        /// <summary>
        /// Gets or sets the exchange rate identifier.
        /// </summary>
        /// <value>
        /// The exchange rate identifier.
        /// </value>
        int ExchangeRateId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        DateTime FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        DateTime ToDate { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IExchangeRateView"/> is inactive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if inactive; otherwise, <c>false</c>.
        /// </value>
        bool Inactive { get; set; }
    }
}