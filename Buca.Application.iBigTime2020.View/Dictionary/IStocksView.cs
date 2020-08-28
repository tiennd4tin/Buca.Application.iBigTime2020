/***********************************************************************
 * <copyright file="IStocksView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;


namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// Interface IStocksView
    /// </summary>
   public interface IStocksView:IView
    {
        /// <summary>
        /// Sets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        IList<StockModel> Stocks { set; }
    }
}
