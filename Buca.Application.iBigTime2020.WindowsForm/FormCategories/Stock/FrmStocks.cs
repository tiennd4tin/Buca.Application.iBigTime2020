/***********************************************************************
 * <copyright file="UserControlStockList.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using DevExpress.Utils;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Stock
{
    /// <summary>
    /// Class UserControlStockList.
    /// </summary>
    public partial class FrmStocks : FrmBaseList, IStocksView
    {
        /// <summary>
        /// The _stocks presenter
        /// </summary>
        private readonly StocksPresenter _stocksPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmStocks"/> class.
        /// </summary>
        public FrmStocks()
        {
            InitializeComponent();
            _stocksPresenter = new StocksPresenter(this);
        }

        /// <summary>
        /// Sets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public IList<StockModel> Stocks
        {
            set
            {
                var stocks = value.OrderBy(v => v.StockCode).ToList();
                ListBindingSource.DataSource = stocks;
                gridView.PopulateColumns(stocks);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultAccountNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StockCode", ColumnCaption = "Mã kho", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StockName", ColumnCaption = "Tên kho", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 30
                });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _stocksPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new StockPresenter(null).Delete(PrimaryKeyValue);
        }
    }
}
