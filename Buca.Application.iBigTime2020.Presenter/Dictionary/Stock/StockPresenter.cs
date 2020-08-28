/***********************************************************************
 * <copyright file="StockPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.Stock
{
    /// <summary>
    /// Class StockPresenter.
    /// </summary>
    public class StockPresenter : Presenter<IStockView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public StockPresenter(IStockView view)
            : base(view)
        {

        }

        /// <summary>
        /// Displays the specified stock identifier.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        public void Display(string stockId)
        {
            if (stockId == null)
            {
                View.StockId = null;
                return;
            }
            var stock = Model.GetStock(stockId);
            View.StockId = stock.StockId;
            View.StockCode = stock.StockCode;
            View.StockName = stock.StockName;
            View.Description = stock.Description;
            View.IsActive = stock.IsActive;
            View.DefaultAccountNumber = stock.DefaultAccountNumber;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var stock = new StockModel
            {
                StockId = View.StockId,
                StockCode = View.StockCode,
                StockName = View.StockName,
                Description = View.Description,
                IsActive = View.IsActive,
                DefaultAccountNumber = View.DefaultAccountNumber
            };
            return View.StockId == null ? Model.InsertStock(stock) : Model.UpdateStock(stock);
        }

        /// <summary>
        /// Deletes the specified stock identifier.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns>System.Int32.</returns>
        public string Delete(string stockId)
        {
            return Model.DeleteStock(stockId);
        }
    }
}
