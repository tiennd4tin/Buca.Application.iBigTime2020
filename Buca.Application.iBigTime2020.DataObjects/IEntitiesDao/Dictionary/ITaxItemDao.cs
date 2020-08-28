using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    public interface ITaxItemDao
    {
        TaxItemEntity GetTaxItem(string taxItemId);
        List<TaxItemEntity> GetTaxItems();
        List<TaxItemEntity> GetTaxItemsByTaxItemCode(string taxItemCode);
        List<TaxItemEntity> GetTaxItemsByActive(bool isActive);
        string InsertTaxItem(TaxItemEntity taxItem);
        string UpdateTaxItem(TaxItemEntity taxItem);
        string DeleteTaxItem(string taxItemId);

    }
}
