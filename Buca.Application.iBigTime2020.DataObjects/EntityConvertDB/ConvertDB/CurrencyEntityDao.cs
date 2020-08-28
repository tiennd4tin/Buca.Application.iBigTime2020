using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class CurrencyEntityDao : IEntityCurrencyDao
    {
       
       public  List<CurrencyEntity> GetCurrency(string connectionString)
        {  
            List<CurrencyEntity> listCurrency = new List<CurrencyEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.CCies.ToList();
                foreach (var result in categories)
                {
                    var currency = new CurrencyEntity
                    {
                        CurrencyCode = result.CurrencyID,
                        CurrencyName = result.CurrencyName,

                        IsMain = result.CurrencyID.Contains("VND"),
                        IsActive = result.Inactive != true
                    };

                    listCurrency.Add(currency);

                }

               
            }

            return listCurrency;
        }

      
    }
}
