/***********************************************************************
 * <copyright file="IExchangeRatesView.cs" company="BUCA JSC">
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

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using System.Collections.Generic;


namespace Buca.Application.iBigTime2020.View.Dictionary
{
    public interface IExchangeRatesView : IView
    {
        /// <summary>
        /// Sets the exchange rate models.
        /// </summary>
        /// <value>
        /// The exchange rate models.
        /// </value>
        IList<ExchangeRateModel> ExchangeRateModels { set; }
    }
}