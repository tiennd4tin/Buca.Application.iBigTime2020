/***********************************************************************
 * <copyright file="IStockDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface IStockDao
    /// </summary>
  public  interface IStockDao
    {
        /// <summary>
        /// Gets the stock.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns></returns>
        StockEntity GetStock(string stockId);

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <returns></returns>
        List<StockEntity> GetStocks();

        /// <summary>
        /// Inserts the stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns></returns>
        string InsertStock(StockEntity stock);

        /// <summary>
        /// Updates the stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns></returns>
        string UpdateStock(StockEntity stock);

        /// <summary>
        /// Deletes the stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns>System.String.</returns>
        string DeleteStock(StockEntity stock);
        string DeleteStockConvert();

        /// <summary>
        /// Gets the stocks by is active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List&lt;StockEntity&gt;.</returns>
        List<StockEntity> GetStocksByIsActive(bool isActive);

        /// <summary>
        /// Lấy danh sách các kho theo mã
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        StockEntity GetStocksByStockCode(string stockCode);
    }
}
