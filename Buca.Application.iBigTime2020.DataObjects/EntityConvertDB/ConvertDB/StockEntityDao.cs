using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class StockEntityDao : IEntityStockDao
    {
       
       public  List<StockEntity> GetStocks(string connectionString)
        {  
            List<StockEntity> listStock = new List<StockEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.Stocks.ToList();
                foreach (var result in categories)
                {
                    var stock = new StockEntity();
                    stock.StockId = result.StockID.ToString();
                    stock.StockCode = result.StockCode;
                    stock.StockName = result.StockName;
                    stock.Description = result.Description;
                    stock.DefaultAccountNumber = result.DefaultAccountNumber;
                    stock.IsActive = result.Inactive ==true?false:true;
                    listStock.Add(stock);
                }
            }
            return listStock;
        }

      
    }
}
